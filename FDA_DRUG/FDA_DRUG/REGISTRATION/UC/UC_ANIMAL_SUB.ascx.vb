Imports Telerik.Web.UI
Public Class UC_ANIMAL_SUB
    Inherits System.Web.UI.UserControl

    Dim _IDA As String
    Dim r_id As String
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        r_id = Request.QueryString("r_id")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            bind_ddl_dramltype()
        End If
    End Sub
    Public Sub bind_ddl_dramltype()
        Dim dao As New DAO_DRUG.TB_dramlpart
        dao.GetDataAll()
        ddl_dramlpart.DataSource = dao.datas
        ddl_dramlpart.DataTextField = "ampartnm"
        ddl_dramlpart.DataValueField = "ampartcd"
        ddl_dramlpart.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_dramlpart.Items.Insert(0, item)
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim str As String = ""
        str = txt_STOP_VALUE1.Text & " " & ddl_STOP_UNIT1.SelectedItem.Text
        Dim dao_m As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL
            dao_m.GetData_by_IDA(_IDA)

        Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL_SUB
            dao.fields.ampartcd = ddl_dramlpart.SelectedValue
            dao.fields.amlsubcd = dao_m.fields.amlsubcd
            dao.fields.amltpcd = dao_m.fields.amltpcd
            dao.fields.FK_IDA = _IDA
            'dao.fields.nouse = txt_nouse.Text
            dao.fields.packuse = txt_packuse.Text
            dao.fields.usetpcd = dao_m.fields.usetpcd
            dao.fields.STOP_UNIT1 = ddl_STOP_UNIT1.SelectedValue
            dao.fields.STOP_VALUE1 = txt_STOP_VALUE1.Text
            'dao.fields.STOP_UNIT2 = ddl_STOP_UNIT2.SelectedValue
            'dao.fields.STOP_VALUE2 = txt_STOP_VALUE2.Text
            dao.fields.stpdrg = str
            dao.insert()

            alert("บันทึกข้อมูลเรียบร้อย")
       

        rgAnimals.Rebind()
    End Sub

    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub rgAnimals_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgAnimals.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            If e.CommandName = "_del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL_SUB
                    dao.GetDatabyIDA(IDA)
                    dao.delete()
                    alert("ลบข้อมูลเรียบร้อย")
                    rgAnimals.Rebind()
                ElseIf e.CommandName = "_sel" Then

                End If

        End If
    End Sub

    Private Sub rgAnimals_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAnimals.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
            Try
            dt = bao.SP_DRUG_REGISTRATION_ANIMAL_SUB_BY_FK_IDA(_IDA)
            Catch ex As Exception

            End Try
        rgAnimals.DataSource = dt
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        'FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & str_ID & "&req=1"
        If Request.QueryString("process") = "130002" Or Request.QueryString("process") = "130004" Then
            If Request.QueryString("a") = "" Then
                Response.Redirect("../REGISTRATION/FRM_REGISTRATION_ANIMAL_DETAIL_OTHER.aspx?IDA=" & r_id & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&tab=11")
            Else
                Response.Redirect("../REGISTRATION/FRM_REGISTRATION_ANIMAL_DETAIL_OTHER.aspx?IDA=" & r_id & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&tab=11&a=1")
            End If
        Else
            If Request.QueryString("a") = "" Then
                Response.Redirect("../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & r_id & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&tab=11")
            Else
                Response.Redirect("../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & r_id & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&tab=11&a=1")
            End If
        End If
       

    End Sub
End Class