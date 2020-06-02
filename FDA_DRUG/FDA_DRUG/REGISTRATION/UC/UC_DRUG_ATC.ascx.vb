Imports System.Globalization
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports Telerik.Web.UI
Public Class UC_DRUG_ATC
    Inherits System.Web.UI.UserControl
    Private _lcnno As String
    Private _lcntpcd As String
    Private _pvncd As String
    Private _lcnsid As String
    Private _thadrgnm As String
    Private _rgttpcd As String
    Private _rgtno As String
    Private _drgtpcd As String
    Public _Newcode As String
    Dim ThaiCulture As New CultureInfo("th-TH") 'วันที่แบบไทย
    Dim UsaCulture As New CultureInfo("en-US") 'วันที่แบบสากล
    'Private _dsgcd As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("tt") <> "" Then
                btn_atc.Visible = False
            End If
        End If
    End Sub
    Public Sub bind_ddl_atc()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_ATC_DRUG_ALL()
        'rcb_atc.DataSource = dt
        'rcb_atc.DataBind()
    End Sub


    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub btn_atc_Click(sender As Object, e As EventArgs) Handles btn_atc.Click
        'Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
        'Try
        '    dao.fields.ATC_CODE = rcb_atc.SelectedValue
        'Catch ex As Exception

        'End Try

        'dao.fields.FK_IDA = Request.QueryString("IDA")
        'dao.insert()
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        'RadGrid2.Rebind()


        For Each item As GridDataItem In rg_atc_search.SelectedItems
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
            Try
                dao.fields.ATC_CODE = item("atc_code").Text
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = Request.QueryString("IDA")
            dao.insert()
        Next
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "del" Then
                If Request.QueryString("tt") <> "" Then
                    alert("ไม่สามารถลบข้อมูลได้")
                Else
                    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                    RadGrid2.Rebind()
                End If

            End If

        End If
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim btn_del As LinkButton = CType(item("del").Controls(0), LinkButton)
            Try
                If Request.QueryString("tt") <> "" Then
                    btn_del.Visible = False
                End If
            Catch ex As Exception

            End Try
            
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
        RadGrid2.DataSource = dt
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        rg_atc_search.Rebind()
    End Sub

    Private Sub rg_atc_search_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_atc_search.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        If txt_search.Text <> "" Then
            dt = bao.SP_ATC_DRUG_SEARCH_V2(txt_search.Text, txt_atc_name.Text)
        End If
        rg_atc_search.DataSource = dt
    End Sub
End Class
