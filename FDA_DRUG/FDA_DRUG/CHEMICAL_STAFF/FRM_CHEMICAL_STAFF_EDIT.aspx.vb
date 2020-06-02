Public Class FRM_CHEMICAL_STAFF_EDIT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                get_data(dao)
            ElseIf Request.QueryString("iowa") <> "" Then
                Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL
                dao.Get_data_by_iowa(Request.QueryString("iowa"))
                get_data(dao)

            End If
        End If

    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_MAS_CHEMICAL)
        txt_cas.Text = dao.fields.cas_number
        txt_INN.Text = dao.fields.INN
        txt_INN_TH.Text = dao.fields.INN_TH
        txt_iowacd.Text = dao.fields.iowacd
        Txt_Name.Text = dao.fields.iowanm
        txt_runno.Text = dao.fields.runno
        txt_salt.Text = dao.fields.salt
        txt_syn.Text = dao.fields.syn
        txt_version_update.Text = dao.fields.Version_update
        Try
            ddl_aori.DropDownSelectData(dao.fields.aori)
        Catch ex As Exception

        End Try
        Try
            ddl_Look.DropDownSelectData(dao.fields.look_type)
        Catch ex As Exception

        End Try
        Try
            ddl_Modern_drug.DropDownSelectData(dao.fields.MODERN_TRADITION)
        Catch ex As Exception

        End Try
        Try
            ddl_Regis.DropDownSelectData(dao.fields.REGIS_STATUS)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_MAS_CHEMICAL)
        dao.fields.cas_number = txt_cas.Text
        dao.fields.INN = txt_INN.Text
        dao.fields.INN_TH = txt_INN_TH.Text
        dao.fields.iowacd = txt_iowacd.Text
        dao.fields.iowanm = Txt_Name.Text
        dao.fields.runno = txt_runno.Text
        dao.fields.salt = txt_salt.Text
        dao.fields.syn = txt_syn.Text

        dao.fields.Version_update = txt_version_update.Text
        Try
            dao.fields.aori = ddl_aori.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.look_type = ddl_Look.SelectedValue
            If ddl_Look.SelectedItem.Text = "Look" Then
                dao.fields.IS_ACTIVE = 1
            ElseIf ddl_Look.SelectedItem.Text = "No Look" Then
                dao.fields.IS_ACTIVE = 2
            End If
        Catch ex As Exception

        End Try
        Try
            dao.fields.MODERN_TRADITION = ddl_Modern_drug.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.REGIS_STATUS = ddl_Regis.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.iowa = txt_iowacd.Text & txt_runno.Text & txt_salt.Text & txt_syn.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            set_data(dao)
            dao.update()
            alert("แก้ไขเรียบร้อยแล้ว")
        ElseIf Request.QueryString("iowa") <> "" Then
            Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL
            dao.Get_data_by_iowa(Request.QueryString("iowa"))
            set_data(dao)
            dao.update()
            alert("แก้ไขเรียบร้อยแล้ว")
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class