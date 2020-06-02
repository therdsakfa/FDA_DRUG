Public Class FRM_DRRGT_STATUS_EXPERT_POPUP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            txt_stat_date.Text = Date.Now.ToShortDateString()
            UC_INFORMATION_HEAD1.set_label()

            Dim dao_cur As New DAO_DRUG.TB_E_TRACKING_HEAD_CURRENT_STATUS
            dao_cur.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                Dim dao_stat As New DAO_DRUG.TB_MAS_HEAD_STATUS_E_TRACKING
                dao_stat.GetDataby_STATUS_ROW(dao_cur.fields.HEAD_STATUS_ID)
                lbl_head_status.Text = dao_stat.fields.FDA_STATUS
            Catch ex As Exception

            End Try


            Try
                Dim dao_date As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS_NAME
                dao_date.GetDataby_HEAD_ID(Request.QueryString("head"))
                lbl_date_name.Text = dao_date.fields.STATUS_DATE_NAME
            Catch ex As Exception

            End Try

            Try
                Dim dao As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                dao.GetDataby_rcvno_ctzid_rgttpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
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
        'GetDataby_GEN3

        Try
            Dim dao_current As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            'dao_current.GetDataby_rcvno_ctzid_rgttpcd(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
            dao_current.GetDataby_rcvno_rgttpcd_b_type_sub_type(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"))
           
            Dim dao_max As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            dao_max.GetDataby_GEN3(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"))
            Dim max_num As Integer = 0
            Try
                max_num = dao_max.fields.STATUS_INDEX
            Catch ex As Exception

            End Try
            Dim dao_count As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
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
            'dao_count.fields.ctzid = Request.QueryString("ctzid")
            dao_count.fields.rcvno = Request.QueryString("rcvno")
            dao_count.fields.rgttpcd = Request.QueryString("ntype")
            dao_count.fields.STATUS_INDEX = max_num + 1
            dao_count.fields.PRODUCT_TYPE = Request.QueryString("b_type")
            dao_count.fields.SUB_PRODUCT_TYPE = Request.QueryString("s_type")

            dao_count.insert()
            'End If

            Dim dao As New DAO_DRUG.TB_E_TRACKING_STATUS_ADD
            set_data(dao)
            dao.insert()
            'End If

        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกสถานะเรียบร้อย');", True)
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

    End Sub
    Public Sub Bind_ddl_Status_staff()

        Dim dao_g As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS_NAME
        dao_g.GetDataby_HEAD_ID(9)
        ddl_cnsdcd.DataSource = dao_g.datas
        ddl_cnsdcd.DataValueField = "IDA"
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

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url As String = ""
        Dim url2 As String = ""
        If Request.QueryString("extra") = "" Then
            url2 = "../CHANGE_STATUS/NEW/FRM_ETRACKING_STATUS_HEAD_MAIN.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type")
        Else
            url2 = "../CHANGE_STATUS/NEW/FRM_ETRACKING_STATUS_SUB_MAIN.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&extra=1"
        End If

        Response.Redirect(url2)
    End Sub
End Class