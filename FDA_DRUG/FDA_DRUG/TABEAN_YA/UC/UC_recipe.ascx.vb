Imports System.Globalization
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports Telerik.Web.UI

Public Class UC_recipe
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
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()

        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub
    Public Sub bind_ddl_atc()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_ATC_DRUG_ALL()
        rcb_atc.DataSource = dt
        rcb_atc.DataBind()
    End Sub


    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub btn_atc_Click(sender As Object, e As EventArgs) Handles btn_atc.Click
        If STATUS_ID = 8 Then
            insert_atc_rgt()
        Else
            insert_atc_rqt()
        End If
    End Sub
    Sub insert_atc_rgt()
        If STATUS_ID = 8 Then
            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            dao1.GetDataby_FK_DRRQT(Request.QueryString("IDA"))
            Dim dao As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
            Try
                dao.fields.ATC_CODE = rcb_atc.SelectedValue
            Catch ex As Exception

            End Try

            dao.fields.FK_IDA = dao1.fields.IDA
            dao.insert()

            Dim dao_dr As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
            dao_dr.GetDataby_FKIDA(Request.QueryString("IDA"))
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_ATC_DETAIL", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try
            'Dim filename As String = ""
            'filename = "DRRGT_ATC_DETAIL_" & max_no + 1 & ".xml"
            'Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
            'bao_app.RunAppSettings()
            'Dim path As String = bao_app._PATH_EDIT & filename
            'Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
            'Dim x As New XmlSerializer(dao_dr.fields.GetType)                                                     'ประกาศ
            'x.Serialize(objStreamWriter, dao_dr.fields)
            'objStreamWriter.Close()

            'Dim dao_index As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            'With dao_index.fields
            '    .COUNT_EDIT = max_no + 1
            '    .CREATE_DATE = Date.Now
            '    .FILE_NAME = filename
            '    .FK_DRRGT_IDA = Request.QueryString("IDA")
            '    .FK_IDA = dao_dr.fields.IDA
            '    .TABLE_NAME = "DRRGT_ATC_DETAIL"
            'End With
            'dao_index.insert()
        Else
            Dim dao As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
            Try
                dao.fields.ATC_CODE = rcb_atc.SelectedValue
            Catch ex As Exception

            End Try

            dao.fields.FK_IDA = Request.QueryString("IDA")
            dao.insert()
        End If

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        RadGrid2.Rebind()
    End Sub
    Sub insert_atc_rqt()
        Dim dao As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
        Try
            dao.fields.ATC_CODE = rcb_atc.SelectedValue
        Catch ex As Exception

        End Try

        dao.fields.FK_IDA = Request.QueryString("IDA")
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
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
                If STATUS_ID = 8 Then
                    Dim dao As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                Else
                    Dim dao As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                End If

                RadGrid2.Rebind()
            End If

        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If STATUS_ID = 8 Then
            'Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            'dao1.GetDataby_FK_DRRQT(Request.QueryString("IDA"))
            dt = bao.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
        Else
            dt = bao.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
        End If

        RadGrid2.DataSource = dt
    End Sub
End Class
