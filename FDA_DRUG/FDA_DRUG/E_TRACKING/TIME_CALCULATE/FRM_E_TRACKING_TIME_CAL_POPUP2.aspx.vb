Imports Telerik.Web.UI
Public Class FRM_E_TRACKING_TIME_CAL_POPUP2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_END_DATE_COUNT.Text = Date.Now.ToShortDateString
            txt_end_date_det.Text = Date.Now.ToShortDateString
            txt_START_DATE_COUNT.Text = Date.Now.ToShortDateString
            txt_start_date_det.Text = Date.Now.ToShortDateString
            bind_ddl_TYPE_REQUESTS()
            bind_ddl_period_name()
            bind_ddl_expert_type()
            'CHK_Rows
            Dim bool As Boolean = False
            Dim dao_c As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
            If Request.QueryString("rcvno") <> "" Then
                bool = dao_c.CHK_Rows(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
                If bool = True Then
                    Panel1.Style.Add("display", "block")
                    btn_edit.Style.Add("display", "block")
                    btn_save.Style.Add("display", "none")
                    Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
                    dao.GetDataby_rcvno_ctzid(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
                    get_data(dao)
                    btn_report.Style.Add("display", "block")
                Else
                    Panel1.Style.Add("display", "none")
                    btn_edit.Style.Add("display", "none")
                    btn_save.Style.Add("display", "block")
                    btn_report.Style.Add("display", "none")
                End If
            Else
                If Request.QueryString("ida") <> "" Then
                    Panel1.Style.Add("display", "block")
                    btn_edit.Style.Add("display", "block")
                    btn_save.Style.Add("display", "none")
                    Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
                    dao.GetDataby_IDA(Request.QueryString("ida"))
                    get_data(dao)
                    btn_report.Style.Add("display", "block")
                Else
                    Panel1.Style.Add("display", "none")
                    btn_edit.Style.Add("display", "none")
                    btn_save.Style.Add("display", "block")
                    btn_report.Style.Add("display", "none")
                End If
            End If
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            If Request.QueryString("new") = "" Then
                dt = bao.SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
            Else
                dt = bao.SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))

            End If
            For Each dr As DataRow In dt.Rows
                txt_DRUG_NAME.Text = dr("drgnm")
                txt_RCVNO_DISPLAY.Text = dr("rcvno_display")
            Next
            Cal_day()
        End If
    End Sub
    Sub bind_ddl_TYPE_REQUESTS()
        Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_REPORT_PROCESS
        dao.GetDataALL()

        ddl_TYPE_REQUESTS.DataSource = dao.datas
        ddl_TYPE_REQUESTS.DataTextField = "PROCESS_NAME"
        ddl_TYPE_REQUESTS.DataValueField = "IDA"
        ddl_TYPE_REQUESTS.DataBind()
    End Sub
    Sub bind_ddl_period_name()
        Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_PERIOD_NAME
        dao.GetDataALL()
        ddl_period.DataSource = dao.datas
        ddl_period.DataTextField = "PERIOD_NAME"
        ddl_period.DataValueField = "IDA"
        ddl_period.DataBind()
    End Sub
    Sub bind_ddl_expert_type()
        Dim dao As New DAO_DRUG.TB_MAS_EXPERT_SKILL
        dao.GetDataALL()

        ddl_expert_type.DataSource = dao.datas
        ddl_expert_type.DataTextField = "EXPERT_SKILL"
        ddl_expert_type.DataValueField = "IDA"
        ddl_expert_type.DataBind()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
        set_data(dao)
        dao.fields.IS_ENABLE = True
        dao.fields.CREATE_DATE = Date.Now
        If Request.QueryString("rcvno") <> "" Then
            dao.fields.CTZID = Request.QueryString("ctzid")
            dao.fields.RCVNO = Request.QueryString("rcvno")
            dao.fields.rgttpcd = Request.QueryString("ntype")
        End If
        dao.insert()

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&ida=" & dao.fields.IDA
        'If Request.QueryString("rcvno") <> "" Then
        '    uri &= "&rcvno=" & Request.QueryString("rcvno") & "&ctzid=" & Request.QueryString("ctzid") & "&ntype=" & Request.QueryString("ntype")
        'End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
    End Sub
    Sub set_data(ByRef dao As DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT)
        With dao.fields
            Try
                .DAY_ALL_CAL = txt_DAY_ALL_CAL.Text
            Catch ex As Exception
                .DAY_ALL_CAL = 0
            End Try
            Try
                .DAY_EXPAND_CAL = txt_DAY_EXPAND_CAL.Text
            Catch ex As Exception
                .DAY_EXPAND_CAL = 0
            End Try
            Try
                .DAY_EXPAND_PER_ROUND = txt_DAY_EXPAND_PER_ROUND.Text
            Catch ex As Exception
                .DAY_EXPAND_PER_ROUND = 0
            End Try
            Try
                .DAY_FIXED = txt_DAY_FIXED.Text
            Catch ex As Exception
                .DAY_FIXED = 0
            End Try
            Try
                .DAY_FIXED_CAL = txt_DAY_FIXED_CAL.Text
            Catch ex As Exception

            End Try
            Try
                .DAY_STOP_CAL = txt_DAY_STOP_CAL.Text
            Catch ex As Exception
                .DAY_STOP_CAL = 0
            End Try
            .DRUG_NAME = txt_DRUG_NAME.Text
            Try
                .END_DATE_COUNT = CDate(txt_END_DATE_COUNT.Text)
            Catch ex As Exception

            End Try
            Try
                .FK_TYPE_REQUESTS_IDA = ddl_TYPE_REQUESTS.SelectedValue
            Catch ex As Exception

            End Try
            .RCVNO_DISPLAY = txt_RCVNO_DISPLAY.Text
            '.RCVNO_FOLLOW = txt_RCVNO_FOLLOW.Text
            .RCVNO_TEXT = ""
            Try
                .REAL_DAY_USE = txt_REAL_DAY_USE.Text
            Catch ex As Exception

            End Try
            Try
                .ROUND_COUNT = txt_ROUND_COUNT.Text
            Catch ex As Exception

            End Try
            Try
                .START_DATE_COUNT = CDate(txt_START_DATE_COUNT.Text)
            Catch ex As Exception

            End Try

        End With
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT)
        With dao.fields
            Try
                txt_DAY_ALL_CAL.Text = .DAY_ALL_CAL
            Catch ex As Exception
                txt_DAY_ALL_CAL.Text = 0
            End Try
            Try
                txt_DAY_EXPAND_CAL.Text = .DAY_EXPAND_CAL
            Catch ex As Exception
                txt_DAY_EXPAND_CAL.Text = 0
            End Try
            Try
                txt_DAY_EXPAND_PER_ROUND.Text = .DAY_EXPAND_PER_ROUND
            Catch ex As Exception
                txt_DAY_EXPAND_PER_ROUND.Text = 0
            End Try
            Try
                txt_DAY_FIXED.Text = .DAY_FIXED
            Catch ex As Exception
                txt_DAY_FIXED.Text = 0
            End Try
            Try
                txt_DAY_FIXED_CAL.Text = .DAY_FIXED_CAL
            Catch ex As Exception
                txt_DAY_FIXED_CAL.Text = 0
            End Try
            Try
                txt_DAY_STOP_CAL.Text = .DAY_STOP_CAL
            Catch ex As Exception
                txt_DAY_STOP_CAL.Text = 0
            End Try
            txt_DRUG_NAME.Text = .DRUG_NAME
            Try
                txt_END_DATE_COUNT.Text = CDate(.END_DATE_COUNT).ToShortDateString()
            Catch ex As Exception

            End Try
            Try
                ddl_TYPE_REQUESTS.DropDownSelectData(.FK_TYPE_REQUESTS_IDA)
            Catch ex As Exception

            End Try
            txt_RCVNO_DISPLAY.Text = .RCVNO_DISPLAY
            'txt_RCVNO_FOLLOW.Text = .RCVNO_FOLLOW

            Try
                txt_REAL_DAY_USE.Text = .REAL_DAY_USE
            Catch ex As Exception

            End Try
            Try
                txt_ROUND_COUNT.Text = .ROUND_COUNT
            Catch ex As Exception

            End Try
            Try
                txt_START_DATE_COUNT.Text = CDate(.START_DATE_COUNT).ToShortDateString()
            Catch ex As Exception

            End Try

        End With
    End Sub
    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
        Dim head_id As Integer = 0
        If Request.QueryString("ida") <> "" Then
            head_id = Request.QueryString("ida")
        Else
            Dim dao_head As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
            dao_head.GetDataby_rcvno_ctzid(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
            head_id = dao_head.fields.IDA
        End If
        dao.GetDataby_IDA(head_id)
        set_data(dao)
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย');", True)

    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT_DETAIL
        Dim head_id As Integer = 0
        If Request.QueryString("ida") <> "" Then
            head_id = Request.QueryString("ida")
        Else
            Dim dao_head As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
            dao_head.GetDataby_rcvno_ctzid(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
            head_id = dao_head.fields.IDA
        End If
        With dao.fields
            Try
                .END_DATE = CDate(txt_end_date_det.Text)
            Catch ex As Exception

            End Try

            If ddl_period.SelectedValue = 2 Then
                .EXPERT_TYPE_ID = ddl_expert_type.SelectedValue
                .EXPERT_COUNT = ddl_expert_count.SelectedValue
            End If

            .FK_IDA = head_id
            .PERIOD_COUNT = ddl_period_count.SelectedValue
            Try
                .START_DATE = CDate(txt_start_date_det.Text)
            Catch ex As Exception

            End Try
            .TYPE_PERIOD = ddl_period.SelectedValue
        End With
        dao.insert()

        Dim dao2 As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
        dao2.GetDataby_IDA(head_id)
        set_data(dao2)
        dao2.update()
        Cal_day()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)



        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        If Request.QueryString("ida") <> "" Then
            Dim bao As New BAO.ClsDBSqlcommand
            dt = bao.SP_GET_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA(Request.QueryString("ida"))
            
        ElseIf Request.QueryString("rcvno") <> "" Then
            Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
            dao.GetDataby_rcvno_ctzid(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
            Dim bao As New BAO.ClsDBSqlcommand
            dt = bao.SP_GET_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA(dao.fields.IDA)
        End If
        For Each dr As DataRow In dt.Rows
            Dim ws2 As New WS_GETDATE_WORKING.Service1
            Dim start_date2 As Date
            Dim end_date2 As Date
            Dim holiday2 As Integer = 0
            Dim day_all2 As Integer = 0
            Try
                start_date2 = CDate(dr("START_DATE"))
            Catch ex As Exception

            End Try
            Try
                end_date2 = CDate(dr("END_DATE"))
            Catch ex As Exception

            End Try
            day_all2 = DateDiff(DateInterval.Day, start_date2, end_date2)
            ws2.GETDATE_COUNT_DAY(start_date2, True, end_date2, True, holiday2, True)

            dr("count_day") = day_all2 - holiday2

        Next
        RadGrid1.DataSource = dt
    End Sub

    Private Sub ddl_period_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_period.SelectedIndexChanged
        If ddl_period.SelectedValue = 2 Then
            Panel2.Style.Add("display", "block")
        Else
            Panel2.Style.Add("display", "none")
        End If
    End Sub

    Sub Cal_day()


        Try
            txt_DAY_EXPAND_CAL.Text = (CInt(txt_ROUND_COUNT.Text) - 1) * CInt(txt_DAY_EXPAND_PER_ROUND.Text)
        Catch ex As Exception

        End Try

        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim start_date As Date
        Dim end_date As Date
        Dim holiday As Integer = 0
        Dim day_all As Integer = 0
        Try
            start_date = CDate(txt_START_DATE_COUNT.Text)
        Catch ex As Exception

        End Try
        Try
            end_date = CDate(txt_END_DATE_COUNT.Text)
        Catch ex As Exception

        End Try
        day_all = DateDiff(DateInterval.Day, start_date, end_date)
        ws.GETDATE_COUNT_DAY(start_date, True, end_date, True, holiday, True)
        Dim cal_day As Integer = 0
        cal_day = day_all - holiday
        txt_DAY_ALL_CAL.Text = cal_day

        Dim stop_day As Integer = 0
        Dim dt As New DataTable
        If Request.QueryString("ida") <> "" Then
            Dim bao As New BAO.ClsDBSqlcommand
            dt = bao.SP_GET_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA(Request.QueryString("ida"))
        End If
        Dim cal_table As Integer = 0
        For Each dr As DataRow In dt.Rows
            Dim ws2 As New WS_GETDATE_WORKING.Service1
            Dim start_date2 As Date
            Dim end_date2 As Date
            Dim holiday2 As Integer = 0
            Dim day_all2 As Integer = 0
            Try
                start_date2 = CDate(dr("START_DATE"))
            Catch ex As Exception

            End Try
            Try
                end_date2 = CDate(dr("END_DATE"))
            Catch ex As Exception

            End Try
            day_all2 = DateDiff(DateInterval.Day, start_date2, end_date2)
            ws2.GETDATE_COUNT_DAY(start_date2, True, end_date2, True, holiday2, True)

            dr("count_day") = day_all2 - holiday2
            cal_table += day_all2 - holiday2
        Next

        txt_DAY_STOP_CAL.Text = cal_table

        txt_REAL_DAY_USE.Text = cal_day - cal_table

        Try
            Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_REPORT_PROCESS
            dao.GetDataby_IDA(ddl_TYPE_REQUESTS.SelectedValue)

            txt_DAY_FIXED_CAL.Text = dao.fields.DURATION_DAY
        Catch ex As Exception

        End Try
        Try
            txt_DAY_FIXED.Text = CInt(txt_DAY_FIXED_CAL.Text) + CInt(txt_DAY_EXPAND_CAL.Text)
        Catch ex As Exception
            txt_DAY_FIXED.Text = "0"
        End Try

        Try
            If txt_REAL_DAY_USE.Text > txt_DAY_FIXED.Text Then
                txt_REAL_DAY_USE.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddl_TYPE_REQUESTS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_TYPE_REQUESTS.SelectedIndexChanged
        Cal_day()
    End Sub

    Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        Dim url As String = "../TIME_CALCULATE/Report/FRM_REPORT.aspx?ida="
        If Request.QueryString("rcvno") <> "" Then
            Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
            dao.GetDataby_rcvno_ctzid(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
            url &= "" & dao.fields.IDA
        Else
            url &= "" & Request.QueryString("ida")
        End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)
    End Sub
End Class