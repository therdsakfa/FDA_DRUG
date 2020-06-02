Imports Telerik.Web.UI
Public Class FRM_SHOW_REPORT_CUSTOMER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then

        End If
    End Sub
    Sub Search_FN()
        Dim iden As String = ""
        Try
            iden = _CLS.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO_CUSTOMER(iden)
        Dim dt As New DataTable

        Try
            dt = bao.dt
        Catch ex As Exception

        End Try
        dt.Columns.Add("all_days", GetType(Double))
        dt.Columns.Add("stop_days", GetType(Double))
        dt.Columns.Add("extend_days", GetType(Double))
        dt.Columns.Add("days_result", GetType(Double))
        Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable
        If txt_type_request.Text = "" And txt_r_no.Text = "" Then
            cal_time(dt)
        Else
            If txt_type_request.Text <> "" Then
                str_where = "TYPE_REQUEST='" & txt_type_request.Text & "'"
                If txt_r_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and RCVNO_DISPLAY like '%" & txt_r_no.Text & "%'"
                    Else
                        str_where &= "RCVNO_DISPLAY like '%" & txt_r_no.Text & "%'"
                    End If

                End If
                r_result = dt.Select(str_where)
            Else
                If str_where = "" Then
                    If str_where <> "" Then
                        If txt_r_no.Text <> "" Then
                            str_where &= " and RCVNO_DISPLAY like '%" & txt_r_no.Text & "%'"
                        End If
                    Else
                        If txt_r_no.Text <> "" Then
                            str_where = "RCVNO_DISPLAY like '%" & txt_r_no.Text & "%'"

                        End If
                    End If
                    r_result = dt.Select(str_where)
                Else
                    If txt_r_no.Text <> "" Then
                        str_where = "RCVNO_DISPLAY like '%" & txt_r_no.Text & "%'"

                    End If
                    r_result = dt.Select(str_where)
                End If
            End If
            dt2 = dt.Clone

            For Each dr As DataRow In r_result
                dt2.Rows.Add(dr.ItemArray)
            Next

            cal_time(dt2)

        End If


    End Sub
    Sub cal_time(ByVal dt As DataTable)
        For Each dr As DataRow In dt.Rows
            Dim all_days As Double = 0
            Dim extend_days As Double = 0
            Dim ws As New WS_GETDATE_WORKING.Service1

            Dim dt_all As New DataTable
            Dim bao_all As New BAO.ClsDBSqlcommand
            'dt_all = bao_all.SP_E_TRACKING_HEAD_CURRENT_STATUS_ALL_PERIOD_TIME(dr("rcvno"), dr("rgttpcd"),  big_type, small_type, Request.QueryString("drgtpcd")

            dt_all = bao_all.SP_E_TRACKING_HEAD_CURRENT_STATUS_MAX_DATE_R(dr("IDA"))
            Try
                ws.GETDATE_COUNT_DAY(CDate(dr("REQUEST_DATE")), True, CDate(dt_all(0)("END_DATE")), True, all_days, True) 'DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
            Catch ex As Exception
                ws.GETDATE_COUNT_DAY(CDate(dr("REQUEST_DATE")), True, CDate(Date.Now), True, all_days, True)
            End Try
            'For Each dr_all As DataRow In dt.Rows

            'Next


            '------------เก่า-------------
            'Try
            '    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, CDate(dr("appdate")), True, all_days, True) 'DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
            'Catch ex As Exception
            '    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, Date.Now, True, all_days, True)
            'End Try



            dr("all_days") = all_days
            Dim bao2 As New BAO.ClsDBSqlcommand
            Dim stop_days As Double = 0
            Try
                'stop_days = bao2.SP_GET_DAY_EXTEND_BY_RCVNO_RGTTPCD(dr("rcvno"), dr("rgttpcd"))
                Dim bao_ex As New BAO.ClsDBSqlcommand
                Dim dtex As New DataTable
                dtex = bao_ex.SP_GET_DAY_EXTEND_NEW_DATA_V5(dr("IDA"))
                For Each drex As DataRow In dtex.Rows
                    Dim ws2 As New WS_GETDATE_WORKING.Service1
                    Dim start_date2 As Date
                    Dim end_date2 As Date
                    Dim holiday2 As Integer = 0
                    Dim day_all2 As Integer = 0
                    Try
                        start_date2 = CDate(drex("START_DATE"))
                    Catch ex As Exception

                    End Try
                    Try
                        end_date2 = CDate(drex("END_DATE"))
                    Catch ex As Exception

                    End Try
                    day_all2 = DateDiff(DateInterval.Day, start_date2, end_date2)
                    ws2.GETDATE_COUNT_DAY(start_date2, True, end_date2, True, holiday2, True)

                    stop_days += (day_all2 - holiday2)

                Next


                'stop_days = bao2.SP_GET_DAY_EXTEND_NEW(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"))
            Catch ex As Exception

            End Try

            Try
                Dim bao_extend As New BAO.ClsDBSqlcommand
                Dim dt_extend As New DataTable
                dt_extend = bao_extend.SP_GET_DAY_EXTEND_NEW_DATA_V2_3(dr("IDA"))
                For Each drex As DataRow In dt_extend.Rows
                    Dim ws2 As New WS_GETDATE_WORKING.Service1
                    Dim start_date2 As Date
                    Dim end_date2 As Date
                    Dim holiday2 As Integer = 0
                    Dim day_all2 As Integer = 0
                    Try
                        start_date2 = CDate(drex("START_DATE"))
                    Catch ex As Exception

                    End Try
                    Try
                        end_date2 = CDate(drex("END_DATE"))
                    Catch ex As Exception

                    End Try
                    day_all2 = DateDiff(DateInterval.Day, start_date2, end_date2)
                    ws2.GETDATE_COUNT_DAY(start_date2, True, end_date2, True, holiday2, True)

                    extend_days += (day_all2 - holiday2)

                Next
            Catch ex As Exception

            End Try
            dr("stop_days") = stop_days

            Dim days_result As Double = 0
            Try
                days_result = dr("stdno") + 1 + extend_days - all_days - stop_days '(all_days + 1) - stop_days  'Math.Abs((dr("stdno") + stop_days) - all_days)
            Catch ex As Exception

            End Try
            dr("days_result") = days_result
            dr("extend_days") = extend_days
        Next
        RadGrid1.DataSource = dt
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "report" Then
                Dim id_r As String = item("IDA").Text
                Dim url2 As String = "../TIME_CALCULATE/POPUP_E_TRACKING_STOP_TIME.aspx?id_r=" & id_r
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url2 & "');", True)
            ElseIf e.CommandName = "stat" Then
                Dim IDA As String = item("IDA").Text
                Dim url2 As String = "../CHANGE_STATUS/NEW/FRM_ETRACKING_STATUS_HEAD_MAIN_RQ_CENTER.aspx?id_r=" & IDA & "&r=1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('" & url2 & "');", True)
            ElseIf e.CommandName = "staff" Then
                Dim IDA As String = item("IDA").Text
                Dim url2 As String = "FRM_ADD_STAFF.aspx?ida=" & IDA
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups4('" & url2 & "');", True)
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        'Search_FN()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.ExportSettings.IgnorePaging = True
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub
    Public Sub set_color_rg()
        If RadGrid1.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In RadGrid1.Items
                Dim days_result As Double = 0

                Try
                    days_result = item("days_result").Text
                Catch ex As Exception

                End Try

                If days_result < 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                'i = i + 1
            Next
        End If
    End Sub

    Private Sub FRM_SHOW_REPORT_V2_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        set_color_rg()
    End Sub
End Class