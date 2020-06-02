Public Class FRM_E_TRACKING_SUB_STATUS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            txt_stat_date.Text = Date.Now.ToShortDateString()
            'Dim bao As New BAO.ClsDBSqlcommand
            'Dim dt As New DataTable
            'dt = bao.SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))

            'For Each dr As DataRow In dt.Rows
            '    lbl_product_name.Text = dr("drgnm")
            '    lbl_lcnno_display.Text = dr("rcvno_display")
            '    lbl_lcnsnm.Text = dr("thanm")
            'Next
            Try
                Dim dao As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                dao.GetDataby_rcvno_ctzid_rgttpcd_drgtpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"), Request.QueryString("drgtpcd"))
                Dim dao_s As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS
                dao_s.GetDataby_STATUS_ID(dao.fields.STATUS_ID)
                'lbl_stat.Text = dao_s.fields.STAFF_STATUS

                If dao.fields.STATUS_ID > 0 Then
                    btn_add_expert.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Try
            Dim dao_current As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            dao_current.GetDataby_rcvno_ctzid_rgttpcd_drgtpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"), Request.QueryString("drgtpcd"))
            If dao_current.fields.STATUS_ID = 1 Then
                Dim dao_ex As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                Dim have_expert As Boolean = False
                Try
                    have_expert = dao_ex.GetDataby_rcvno_ctzid_rgttpcd_drgtpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"), Request.QueryString("drgtpcd"))
                Catch ex As Exception

                End Try
                If have_expert = True Then
                    Dim bool As Boolean = False
                    Dim dao_count As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                    bool = dao_count.count_idV4(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"), Request.QueryString("drgtpcd"))
                    If bool = True Then
                        dao_count = New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                        dao_count.GetDataby_rcvno_ctzid_rgttpcd_drgtpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"), Request.QueryString("drgtpcd"))
                        dao_count.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
                        Try
                            dao_count.fields.STATUS_DATE = CDate(txt_stat_date.Text)
                        Catch ex As Exception

                        End Try
                        dao_count.update()
                    Else
                        dao_count = New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                        Try
                            dao_count.fields.FK_IDA = Request.QueryString("ida")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_count.fields.NEWCODE = "" 'Request.QueryString("newcode")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_count.fields.STATUS_DATE = CDate(txt_stat_date.Text)
                        Catch ex As Exception

                        End Try
                        dao_count.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
                        dao_count.fields.ctzid = Request.QueryString("ctzid")
                        dao_count.fields.rcvno = Request.QueryString("rcvno")
                        dao_count.fields.rgttpcd = Request.QueryString("ntype")
                        dao_count.fields.drgtpcd = Request.QueryString("drgtpcd")
                        dao_count.insert()
                    End If

                    Dim dao As New DAO_DRUG.TB_E_TRACKING_STATUS_ADD
                    set_data(dao)
                    dao.insert()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเพิ่มผู้เชี่ยวชาญ อย่างน้อย 1 ด้าน'); ", True)
                End If
            Else
                Dim bool As Boolean = False
                Dim dao_count As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                bool = dao_count.count_idV2(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
                If bool = True Then
                    dao_count = New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                    dao_count.GetDataby_rcvno_ctzid_rgttpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
                    dao_count.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
                    Try
                        dao_count.fields.STATUS_DATE = CDate(txt_stat_date.Text)
                    Catch ex As Exception

                    End Try
                    dao_count.update()
                Else
                    dao_count = New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                    Try
                        dao_count.fields.FK_IDA = Request.QueryString("ida")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_count.fields.NEWCODE = "" 'Request.QueryString("newcode")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_count.fields.STATUS_DATE = CDate(txt_stat_date.Text)
                    Catch ex As Exception

                    End Try
                    dao_count.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
                    dao_count.fields.ctzid = Request.QueryString("ctzid")
                    dao_count.fields.rcvno = Request.QueryString("rcvno")
                    dao_count.fields.rgttpcd = Request.QueryString("ntype")
                    dao_count.insert()
                End If

                Dim dao As New DAO_DRUG.TB_E_TRACKING_STATUS_ADD
                set_data(dao)
                dao.insert()
            End If

        Catch ex As Exception

        End Try
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Sub set_data(ByRef dao As DAO_DRUG.TB_E_TRACKING_STATUS_ADD)
        dao.fields.EMAIL_TEXT = txt_email.Text
        Try
            dao.fields.END_DATE = CDate(txt_stat_date.Text)
        Catch ex As Exception

        End Try
        Try
            dao.fields.FK_IDA = Request.QueryString("ida")
        Catch ex As Exception

        End Try
        Try
            dao.fields.IS_REJECT = False
        Catch ex As Exception

        End Try
        dao.fields.STAFF_IDEN = ""
        Try
            dao.fields.START_DATE = CDate(txt_stat_date.Text)
        Catch ex As Exception

        End Try
        dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao.fields.U1_CODE = "" 'Request.QueryString("newcode")
        Try
            dao.fields.ctzid = Request.QueryString("ctzid")
        Catch ex As Exception

        End Try
        Try
            dao.fields.rcvno = Request.QueryString("rcvno")
        Catch ex As Exception

        End Try
        Try
            dao.fields.rgttpcd = Request.QueryString("ntype")
        Catch ex As Exception

        End Try
        Try
            dao.fields.drgtpcd = Request.QueryString("drgtpcd")
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0

        Dim dao_count As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
        'dao_count.GetDataby_rcvno_ctzid_rgttpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
        dao_count.GetDataby_rcvno_rgttpcd_b_type_sub_type_v2(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), Request.QueryString("drgtpcd"))
        Dim c_stat As Integer = 0
        Dim g_stat As Integer = 0
        Try
            Dim dao_s As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS
            dao_s.GetDataby_STATUS_ID(dao_count.fields.STATUS_ID)
            c_stat = dao_s.fields.STATUS_ID
            g_stat = dao_s.fields.GROUP_STATUS
        Catch ex As Exception

        End Try

        Dim dao_g As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS
        If dao_count.fields.STATUS_ID = 8 Then
            dao_g.GetDataby_group(g_stat)
            ddl_cnsdcd.Enabled = False
        Else
            dao_g.GetDataby_group(g_stat + 1)
        End If


        ddl_cnsdcd.DataSource = dao_g.datas
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STAFF_STATUS"

        ddl_cnsdcd.DataBind()
    End Sub

    Private Sub btn_add_expert_Click(sender As Object, e As EventArgs) Handles btn_add_expert.Click
        'Response.Redirect("FRM_EXPERT_ASSIGN.aspx?ida=" & Request.QueryString("ida") & "&newcode=" & Request.QueryString("newcode"))
        'window.location.href = 'http://privus.fda.moph.go.th';
        'Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype")
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('FRM_EXPERT_ASSIGN_V2.aspx?ida=" & Request.QueryString("ida") & _
                                                          "&rcvno=" & Request.QueryString("rcvno") & "&ctzid=" & Request.QueryString("ctzid") & "&ntype=" & Request.QueryString("ntype") & "'); ", True)
    End Sub
End Class