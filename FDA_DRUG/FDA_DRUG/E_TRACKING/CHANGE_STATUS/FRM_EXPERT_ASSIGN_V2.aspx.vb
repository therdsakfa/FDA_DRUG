Public Class FRM_EXPERT_ASSIGN_V2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_skill()
            bind_expert()
           Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))

            For Each dr As DataRow In dt.Rows
                lbl_product_name.Text = dr("drgnm")
                lbl_lcnno_display.Text = dr("rcvno_display")
                lbl_lcnsnm.Text = dr("thanm")
            Next
            Try
                Dim dao As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                dao.GetDataby_rcvno_ctzid_rgttpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
                Dim dao_s As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS
                dao_s.GetDataby_STATUS_ID(dao.fields.STATUS_ID)
                lbl_stat.Text = dao_s.fields.STAFF_STATUS
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub bind_skill()
        Dim dao As New DAO_DRUG.TB_MAS_EXPERT_SKILL
        dao.GetDataALL()

        ddl_skill.DataSource = dao.datas
        ddl_skill.DataTextField = "EXPERT_SKILL"
        ddl_skill.DataValueField = "IDA"
        ddl_skill.DataBind()
    End Sub
    Sub bind_expert()
        Dim dao As New DAO_DRUG.TB_MAS_EXPERT_NAME
        dao.GetDataALL()

        ddl_expert.DataSource = dao.datas
        ddl_expert.DataTextField = "FULLNAME"
        ddl_expert.DataValueField = "IDA"
        ddl_expert.DataBind()
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            Dim dao As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
            dao.fields.FK_EXPERT = ddl_expert.SelectedValue
            dao.fields.FK_EXPERT_SKILL = ddl_skill.SelectedValue
            'dao.fields.NEWCODE = Request.QueryString("newcode")
            'dao.fields.FK_IDA = Request.QueryString("ida")
            dao.fields.ctzid = Request.QueryString("ctzid")
            dao.fields.rcvno = Request.QueryString("rcvno")
            dao.fields.PRODUCT_TYPE = Request.QueryString("b_type")
            dao.fields.SUB_PRODUCT_TYPE = Request.QueryString("s_type")
            Try
                dao.fields.rgttpcd = Request.QueryString("ntype")
            Catch ex As Exception

            End Try

            dao.insert()
        Catch ex As Exception

        End Try
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        Try
            dt = bao.SP_GET_EXPERT_SELECTED_V3(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"))
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
End Class