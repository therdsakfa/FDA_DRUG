Public Class UC_LCN_BSN_NAME
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        dao.fields.BSN_IDENTIFY = txt_BSN_IDENTIFY.Text
        dao.fields.BSN_PREFIXTHAICD = ddl_prefix.SelectedValue
        dao.fields.BSN_PREFIXENGCD = ddl_prefix.SelectedValue
        dao.fields.BSN_THAINAME = txt_BSN_THAINAME.Text
        dao.fields.BSN_THAILASTNAME = txt_BSN_THAILASTNAME.Text
        dao.fields.BSN_ENGNAME = txt_BSN_ENGNAME.Text
        dao.fields.BSN_ENGLASTNAME = txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_ENGFULLNAME = lbl_engprefixnm.Text & txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        txt_BSN_IDENTIFY.Text = dao.fields.BSN_IDENTIFY
        Try
            ddl_prefix.DropDownSelectData(dao.fields.BSN_PREFIXTHAICD)
        Catch ex As Exception

        End Try

        txt_BSN_THAINAME.Text = dao.fields.BSN_THAINAME
        txt_BSN_THAILASTNAME.Text = dao.fields.BSN_THAILASTNAME
        txt_BSN_ENGNAME.Text = dao.fields.BSN_ENGNAME
        txt_BSN_ENGLASTNAME.Text = dao.fields.BSN_ENGLASTNAME
        'dao.fields.BSN_ENGFULLNAME = lbl_engprefixnm.Text & txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        'dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub
    Private Sub ddl_prefix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_prefix.SelectedIndexChanged
        bind_lbl()
    End Sub
    Public Sub bind_lbl()
        Dim dao As New DAO_CPN.TB_sysprefix
        Try
            dao.Getdata_byid(ddl_prefix.SelectedValue)
            lbl_engprefixnm.Text = dao.fields.engnm
        Catch ex As Exception
            lbl_engprefixnm.Text = ""
        End Try
    End Sub
End Class