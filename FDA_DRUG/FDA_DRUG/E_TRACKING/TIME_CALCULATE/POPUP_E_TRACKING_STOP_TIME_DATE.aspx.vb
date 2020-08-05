Public Class POPUP_E_TRACKING_STOP_TIME_DATE
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
            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_DRUG.TB_E_TRACKING_STOP_TIME
                dao.GetDataby_IDA(Request.QueryString("ida"))

                Try
                    txt_start_date.Text = CDate(dao.fields.START_DATE).ToShortDateString()
                Catch ex As Exception

                End Try
                Try
                    txt_end_date.Text = CDate(dao.fields.END_DATE).ToShortDateString()
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If Request.QueryString("ida") <> "" Then

            If CHK_UPDATE() = True Then
                Dim dao As New DAO_DRUG.TB_E_TRACKING_STOP_TIME
                dao.GetDataby_IDA(Request.QueryString("ida"))

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
                str = "เพิ่ม/แก้ไขวันที่เริ่มหยุดเวลาจาก " & start_date & " เป็น " & txt_start_date.Text & " และเพิ่ม/แก้ไขวันที่เริมนับต่อจาก " & end_date & " เป็น " & txt_end_date.Text
                AddLogStatusEtracking(0, 1, _CLS.CITIZEN_ID, str, "TIME STOP", Request.QueryString("id_r"), dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
                'Request.QueryString("id_r") IDA เลข A
                Try
                    dao.fields.START_DATE = CDate(txt_start_date.Text)
                Catch ex As Exception

                End Try
                Try
                    dao.fields.END_DATE = CDate(txt_end_date.Text)
                Catch ex As Exception

                End Try
                'Try
                '    Dim ws As New WS_GETDATE_WORKING.Service1
                '    Dim date_result As Date
                '    Dim startdate As Date
                '    Dim enddate As Date
                '    If start_date <> "-" Then
                '        If end_date <> "-" Then
                '            'ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
                '            'ws.get
                '        End If
                '    End If



                '    'dao.fields.st = date_result.ToLongDateString()
                'Catch ex As Exception

                'End Try



                dao.update()
                Dim bao_update As New BAO.ClsDBSqlcommand
                Try
                    bao_update.SP_DRUG_CONSIDER_REQUESTS_STOP_DAY(dao.fields.FK_IDA)
                Catch ex As Exception

                End Try
                Try
                    bao_update.SP_DRUG_CONSIDER_REQUESTS_MAX_STOP_DAY(dao.fields.FK_IDA)
                Catch ex As Exception

                End Try
                Try
                    bao_update.SP_DRUG_CONSIDER_REQUESTS_FINISH_DATE(dao.fields.FK_IDA)
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลไม่ถูกต้อง');", True)
            End If

        End If
    End Sub
    Function Chk_date(ByVal str_date As String) As Boolean
        Dim bool As Boolean = True
        Dim Temp_date As Date
        Dim date_split As String()
        Try
            Temp_date = CDate(str_date)

            date_split = str_date.ToString.Split("/")
            If Len(date_split(2)) < 4 Then
                bool = False
            End If
        Catch ex As Exception
            bool = False
        End Try

        Return bool
    End Function
    Function CHK_UPDATE() As Boolean
        Dim bool As Boolean = True
        Dim bool_s As Boolean = Chk_date(txt_start_date.Text)
        Dim bool_e As Boolean = Chk_date(txt_end_date.Text)

        If bool_s = True And bool_e = True Then
            If CDate(txt_end_date.Text) < CDate(txt_start_date.Text) Then
                bool = False
            Else
                bool = True
            End If

        ElseIf bool_s = True And bool_e = False Then
            bool = True
        ElseIf bool_s = False Then
            bool = False
        ElseIf bool_s = False And bool_e = False Then
            bool = False
        End If

        Return bool
    End Function
    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url2 As String = ""

        If Request.QueryString("id_r") <> "" Then
            url2 = "POPUP_E_TRACKING_STOP_TIME.aspx?id_r=" & Request.QueryString("id_r")
        Else
            url2 = "CHANGE_STATUS/FRM_EXPERT_ASSIGN_V3.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&drgtpcd=" & Request.QueryString("drgtpcd")

        End If
        Response.Redirect(url2)
    End Sub
End Class