Public Class FRM_DRRGT_STATUS_POPUP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            txt_stat_date.Text = Date.Now.ToShortDateString()
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Try
                dt = bao.Get_U1_Data_BY_U1(Request.QueryString("newcode"))
            Catch ex As Exception

            End Try

            For Each dr As DataRow In dt.Rows
                Try
                    lbl_engdrgtpnm.Text = dr("engdrgtpnm")
                Catch ex As Exception

                End Try
                Try
                    lbl_lcnno_display.Text = dr("lcnno_display")
                Catch ex As Exception

                End Try
                Try
                    lbl_product_name.Text = dr("product_name")
                Catch ex As Exception

                End Try
                Try
                    lbl_rgttpcd.Text = dr("rgttpcd")
                Catch ex As Exception

                End Try

                Try
                    Dim dao As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                    dao.GetDataby_U1(dr("Newcode"))
                    Dim dao_s As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS
                    dao_s.GetDataby_STATUS_ID(dao.fields.STATUS_ID)
                    lbl_stat.Text = dao_s.fields.STAFF_STATUS

                    If dao.fields.STATUS_ID > 0 Then
                        btn_add_expert.Style.Add("display", "block")
                    End If
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Try
            Dim dao_current As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            dao_current.GetDataby_U1(Request.QueryString("newcode"))
            If dao_current.fields.STATUS_ID = 1 Then
                Dim dao_ex As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                Dim have_expert As Boolean = False
                Try
                    have_expert = dao_ex.count_expert(Request.QueryString("newcode"))
                Catch ex As Exception

                End Try
                If have_expert = True Then
                    Dim bool As Boolean = False
                    Dim dao_count As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                    bool = dao_count.count_id(Request.QueryString("newcode"))
                    If bool = True Then
                        dao_count = New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                        dao_count.GetDataby_U1(Request.QueryString("newcode"))
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
                            dao_count.fields.NEWCODE = Request.QueryString("newcode")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_count.fields.STATUS_DATE = CDate(txt_stat_date.Text)
                        Catch ex As Exception

                        End Try
                        dao_count.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
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
                bool = dao_count.count_id(Request.QueryString("newcode"))
                If bool = True Then
                    dao_count = New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                    dao_count.GetDataby_U1(Request.QueryString("newcode"))
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
                        dao_count.fields.NEWCODE = Request.QueryString("newcode")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_count.fields.STATUS_DATE = CDate(txt_stat_date.Text)
                    Catch ex As Exception

                    End Try
                    dao_count.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
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
        dao.fields.U1_CODE = Request.QueryString("newcode")
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
       
        Dim dao_count As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
        dao_count.GetDataby_U1(Request.QueryString("newcode"))
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



        'If dao.fields.STATUS_ID <= 2 Then
        '    int_group_ddl = 1
        'ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
        '    int_group_ddl = 2
        'ElseIf dao.fields.STATUS_ID >= 6 Then
        '    int_group_ddl = 3
        'End If

        'bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        'dt = bao.dt

        ddl_cnsdcd.DataSource = dao_g.datas
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STAFF_STATUS"
        ddl_cnsdcd.DataBind()
    End Sub

    Private Sub btn_add_expert_Click(sender As Object, e As EventArgs) Handles btn_add_expert.Click
        'Response.Redirect("FRM_EXPERT_ASSIGN.aspx?ida=" & Request.QueryString("ida") & "&newcode=" & Request.QueryString("newcode"))
        'window.location.href = 'http://privus.fda.moph.go.th';
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('FRM_EXPERT_ASSIGN.aspx?ida=" & Request.QueryString("ida") & "&newcode=" & Request.QueryString("newcode") & "'); ", True)
    End Sub
End Class