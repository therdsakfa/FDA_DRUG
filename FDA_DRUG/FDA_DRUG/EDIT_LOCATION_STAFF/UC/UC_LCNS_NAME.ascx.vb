Public Class UC_LCNS_NAME
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub
    Public Sub set_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)
        dao.fields.syslcnsnm_prefixcd = ddl_prefix.SelectedValue
        dao.fields.syslcnsnm_prefixnm = ddl_prefix.SelectedItem.Text
        dao.fields.syslcnsnm_thanm = txt_BSN_THAINAME.Text
        dao.fields.syslcnsnm_thalnm = txt_BSN_THAILASTNAME.Text
    End Sub

    Public Sub get_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)

        Dim dao_pre As New DAO_CPN.TB_sysprefix
        Try
            dao_pre.Getdata_byid(dao.fields.syslcnsnm_prefixcd)
            lb_prefix.Text = dao_pre.fields.thanm
        Catch ex As Exception
            lb_prefix.Text = "-"
        End Try

        lb_BSN_THAINAME.Text = dao.fields.syslcnsnm_thanm
        lb_BSN_THAILASTNAME.Text = dao.fields.syslcnsnm_thalnm

        '----------------------------

        txt_BSN_THAINAME.Text = dao.fields.syslcnsnm_thanm
        txt_BSN_THAILASTNAME.Text = dao.fields.syslcnsnm_thalnm
    End Sub

    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)

        dao.fields.BSN_PREFIXTHAICD_OLD = dao2.fields.syslcnsnm_prefixcd
        dao.fields.BSN_THAINAME_OLD = dao2.fields.syslcnsnm_thanm
        dao.fields.BSN_THAILASTNAME_OLD = dao2.fields.syslcnsnm_thalnm
        dao.fields.BSN_THAIFULLNAME_OLD = dao2.fields.syslcnsnm_prefixnm & dao2.fields.syslcnsnm_thanm & " " & dao2.fields.syslcnsnm_thalnm

        dao.fields.BSN_PREFIXTHAICD = ddl_prefix.SelectedValue
        dao.fields.BSN_THAINAME = txt_BSN_THAINAME.Text
        dao.fields.BSN_THAILASTNAME = txt_BSN_THAILASTNAME.Text
        dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text


    End Sub
End Class