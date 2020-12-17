Public Class FRM_HEAD_ETRACKING_DATE_POPUP
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_E_TRACKING_HEAD_CURRENT_STATUS
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                If Request.QueryString("id_r") <> "" Then
                    Dim dao_rqt As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                    Try
                        dao_rqt.GetDataby_IDA(dao.fields.FK_IDA)
                        lbl_a_no.Text = dao_rqt.fields.RCVNO_DISPLAY
                    Catch ex As Exception

                    End Try

                End If
                Try
                    Dim dao_stat As New DAO_DRUG.TB_MAS_HEAD_STATUS_E_TRACKING
                    dao_stat.GetDataby_STATUS_ROW(dao.fields.HEAD_STATUS_ID)
                    lbl_head_status.Text = dao_stat.fields.FDA_STATUS
                Catch ex As Exception

                End Try
                Try
                    If dao.fields.HEAD_STATUS_ID = 10 Then
                        lbl_app.Style.Add("display", "block")
                        ddl_app.Style.Add("display", "block")
                        lbl_ref_no.Style.Add("display", "block")
                        txt_ref_no.Style.Add("display", "block")
                    Else
                        lbl_app.Style.Add("display", "none")
                        ddl_app.Style.Add("display", "none")
                        lbl_ref_no.Style.Add("display", "none")
                        txt_ref_no.Style.Add("display", "none")
                    End If
                Catch ex As Exception

                End Try
                Try
                    Dim bao As New BAO.ClsDBSqlcommand
                    Dim dt As New DataTable
                    dt = bao.SP_E_TRACKING_STATUS_DATE_NAME_BY_HEAD_STATUS(dao.fields.HEAD_STATUS_ID)
                    Dim field_long As String = ""

                    For Each dr As DataRow In dt.Rows
                        field_long = dr("date_stat")
                    Next
                    Dim arr As String() = field_long.Split(",")

                    lbl_start_date.Text = arr(0)
                    lbl_end_date.Text = arr(1)
                Catch ex As Exception

                End Try


                Try
                    'txt_start_date.Text = CDate(dao.fields.START_DATE).ToShortDateString()
                    rd_start_date.SelectedDate = CDate(dao.fields.START_DATE)
                Catch ex As Exception

                End Try
                Try
                    'txt_end_date.Text = CDate(dao.fields.END_DATE).ToShortDateString()
                    rd_end_date.SelectedDate = CDate(dao.fields.END_DATE)
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_E_TRACKING_HEAD_CURRENT_STATUS
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                dao.fields.START_DATE = rd_start_date.SelectedDate 'CDate(txt_start_date.Text)
            Catch ex As Exception
                dao.fields.START_DATE = Nothing
            End Try
            Try
                dao.fields.END_DATE = rd_end_date.SelectedDate 'CDate(txt_end_date.Text)
            Catch ex As Exception
                dao.fields.END_DATE = Nothing
            End Try

            Try
                If dao.fields.HEAD_STATUS_ID = 10 Then
                    dao.fields.REF_NO = txt_ref_no.Text
                    dao.fields.SUB_STATUS_ID = ddl_app.SelectedValue

                    Dim dao_d As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                    dao_d.GetDataby_IDA(Request.QueryString("id_r"))
                    dao_d.fields.SUB_STATUS = ddl_app.SelectedValue
                    dao_d.update()
                End If

                'Dim bao_update As New BAO.ClsDBSqlcommand
                'bao_update.SP_DRUG_CONSIDER_REQUESTS_FINISH_DATE(Request.QueryString("id_r"))
            Catch ex As Exception

            End Try
            Try
                Dim str As String = ""
                Dim start_date As String = ""
                Try
                    start_date = CDate(dao.fields.START_DATE).ToShortDateString
                Catch ex As Exception
                    start_date = "-"
                End Try
                Dim end_date As String = ""
                Try
                    end_date = CDate(dao.fields.END_DATE).ToShortDateString
                Catch ex As Exception
                    end_date = "-"
                End Try
                str = "เพิ่ม/แก้ไขวันที่เริ่มกระบวนการ " & start_date & " เป็น " & start_date & " และเพิ่ม/แก้ไขวันสิ้นสุดจาก " _
                    & end_date & " เป็น " & end_date & " และเพิ่ม/แก้ไขการอนุมัติเป็น " & ddl_app.SelectedItem.Text & " และเพิ่ม/แก้ไขเลขอ้างอิงโฆษณาจาก " & IIf(Len(dao.fields.REF_NO) <= 0, "-", dao.fields.REF_NO) & " เป็น " _
                    & txt_ref_no.Text & " เพิ่ม/แก้ไขหมายเหตุประกอบผลพิจารณาจาก " & "" & " เป็น " & txt_remark.Text

                'Dim ws As New AUTHEN_LOG.Authentication
                'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกวันที่เริ่ม-สิ้นสุดของช่วงเวลา", "")

                Dim ws_118 As New WS_AUTHENTICATION.Authentication
                Dim ws_66 As New Authentication_66.Authentication
                Dim ws_104 As New AUTHENTICATION_104.Authentication
                Try
                    ws_118.Timeout = 10000
                    ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกวันที่เริ่ม-สิ้นสุดของช่วงเวลา", "")
                Catch ex As Exception
                    Try
                        ws_66.Timeout = 10000
                        ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกวันที่เริ่ม-สิ้นสุดของช่วงเวลา", "")

                    Catch ex2 As Exception
                        Try
                            ws_104.Timeout = 10000
                            ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "บันทึกวันที่เริ่ม-สิ้นสุดของช่วงเวลา", "")

                        Catch ex3 As Exception
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                        End Try
                    End Try
                End Try
                AddLogStatusEtracking(status_id:=0, STATUS_TYPE:=1, iden:=_CLS.CITIZEN_ID, description:=str, PROCESS_NAME:="บันทึกวันที่เริ่ม-สิ้นสุดของช่วงเวลา", FK_IDA:=Request.QueryString("id_r"), SUB_IDA:=dao.fields.IDA, SUB_STATUS:=0, url:=HttpContext.Current.Request.Url.AbsoluteUri)

            Catch ex As Exception

            End Try

            Dim dao_d2 As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            dao_d2.GetDataby_IDA(Request.QueryString("id_r"))
            Dim str_acc As String = ""
            str_acc = "บันทึกเลข " & dao_d2.fields.RCVNO_DISPLAY & " เรียบร้อยแล้ว เมื่อเวลา " & Date.Now.ToString("HH:mm")

            dao.update()



            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

        End If
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url2 As String = ""
        'If Request.QueryString("extra") = "" Then
        If Request.QueryString("id_r") <> "" Then
            url2 = "../NEW/FRM_ETRACKING_STATUS_HEAD_MAIN_RQ_CENTER.aspx?id_r=" & Request.QueryString("id_r") & "&r=1"

        Else
            url2 = "../NEW/FRM_ETRACKING_STATUS_HEAD_MAIN.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&drgtpcd=" & Request.QueryString("drgtpcd")
        End If

        'Else
        'url2 = "../NEW/FRM_ETRACKING_STATUS_SUB_MAIN.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&extra=1"
        'End If

        Response.Redirect(url2)
    End Sub
End Class