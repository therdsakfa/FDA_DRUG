Imports Telerik.Web.UI

Public Class FRM_STAFF_SEARCH_REPORT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim chk_idens As Boolean
        chk_idens = chk_iden(txt_citizen.Text)
        '
        Dim big_type As String = ""
        Dim small_type As String = ""
        big_type = rdl_big_type.SelectedValue
        small_type = rdl_small_type.SelectedValue
        If big_type <> "" And small_type <> "" Then


            If chk_idens = True Then
                Dim bao As New BAO.ClsDBSqlcommand
                Dim dt As New DataTable
                Try
                    dt = bao.SP_MEMBER_THANM_THANM_by_IDENTIFY(txt_citizen.Text)
                    For Each dr As DataRow In dt.Rows
                        lbl_customer.Text = "ผู้รับอนุญาต : " & dr("fullname")
                    Next
                Catch ex As Exception

                End Try

                'Dim dao_iden As New DAO_CPN.clsDBsyslcnsnm
                'dao_iden.GetDataby_identify(txt_citizen.Text)
                'lbl_customer.Text = dao_iden.fields.thanm
                RadGrid1.Rebind()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกประเภทใบคำขอ');", True)
        End If
    End Sub
    Function chk_iden(ByVal iden As String) As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_CPN.clsDBsyslcnsid
        dao.GetDataby_identify(iden)
        Dim i As Integer = 0
        For Each dao.fields In dao.datas
            i += 1
        Next
        If i > 0 Then
            bool = True
        End If

        Return bool
    End Function

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            'Dim id As Integer = item("IDA").Text
            Dim rcvno As String = item("rcvno").Text
            Dim ctzid As String = item("ctzid").Text
            Dim rgttpcd As String = item("rgttpcd").Text
            Dim btn_print As LinkButton = DirectCast(item("report").Controls(0), LinkButton)
            'Dim url2 As String = "../TIME_CALCULATE/FRM_E_TRACKING_TIME_CAL_POPUP2.aspx?rcvno=" & rcvno & "&ctzid=" & ctzid & "&ntype=" & rgttpcd & "&new=1&b_type=" & rdl
            'btn_print.Attributes.Add("OnClick", "Popups2('" & url2 & "'); return false;")
        End If
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "report" Then
                Dim rcvno As String = item("rcvno").Text
                Dim ctzid As String = item("ctzid").Text
                Dim rgttpcd As String = item("rgttpcd").Text
                Dim lcnsid As String = item("lcnsid").Text
                Dim drgtpcd As String = item("drgtpcd").Text
                Dim url2 As String = "../TIME_CALCULATE/POPUP_E_TRACKING_STOP_TIME.aspx?rcvno=" & rcvno & "&ctzid=" & ctzid & "&ntype=" & rgttpcd & "&new=1&b_type=" & rdl_big_type.SelectedValue & "&s_type=" & rdl_small_type.SelectedValue & _
                    "&lcnsid=" & lcnsid & "&drgtpcd=" & drgtpcd
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url2 & "');", True)
            ElseIf e.CommandName = "stat" Then
                Dim rcvno As String = item("rcvno").Text
                Dim ctzid As String = item("ctzid").Text
                Dim rgttpcd As String = item("rgttpcd").Text
                Dim lcnsid As String = item("lcnsid").Text
                Dim drgtpcd As String = item("drgtpcd").Text
                Dim url2 As String = "../CHANGE_STATUS/NEW/FRM_ETRACKING_STATUS_HEAD_MAIN.aspx?rcvno=" & rcvno & "&ctzid=" & ctzid & "&ntype=" & rgttpcd & "&new=1&b_type=" & rdl_big_type.SelectedValue & "&s_type=" & rdl_small_type.SelectedValue & _
                    "&lcnsid=" & lcnsid & "&drgtpcd=" & drgtpcd
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('" & url2 & "');", True)
            End If

        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Try
            Dim big_type As String = ""
            Dim small_type As String = ""
            big_type = rdl_big_type.SelectedValue
            small_type = rdl_small_type.SelectedValue
            Dim chk_idens As Boolean
            chk_idens = chk_iden(txt_citizen.Text)
            Dim item As GridDataItem

            If big_type <> "" And small_type <> "" Then
                If big_type = "1" Then

                ElseIf big_type = "2" Then
                    If small_type = "1" Then
                        If chk_idens = True Then
                            Dim bao As New BAO.ClsDBSqlcommand
                            Dim dt As New DataTable
                            Dim dao As New DAO_CPN.clsDBsyslcnsid
                            dao.GetDataby_identify(txt_citizen.Text)
                            dt = bao.SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_RESULT_BY_LCNSID(dao.fields.lcnsid)
                            'dt = bao.SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_RESULT_ALL()
                            dt.Columns.Add("all_days", GetType(Double))
                            dt.Columns.Add("stop_days", GetType(Double))
                            dt.Columns.Add("extend_days", GetType(Double))
                            dt.Columns.Add("days_result", GetType(Double))

                            For Each dr As DataRow In dt.Rows
                                Dim all_days As Double = 0
                                Dim extend_days As Double = 0
                                Dim ws As New WS_GETDATE_WORKING.Service1

                                Dim dt_all As New DataTable
                                Dim bao_all As New BAO.ClsDBSqlcommand
                                'dt_all = bao_all.SP_E_TRACKING_HEAD_CURRENT_STATUS_ALL_PERIOD_TIME(dr("rcvno"), dr("rgttpcd"),  big_type, small_type, Request.QueryString("drgtpcd")

                                dt_all = bao_all.SP_E_TRACKING_HEAD_CURRENT_STATUS_MAX_DATE(dr("rcvno"), dr("rgttpcd"), big_type, small_type, dr("drgtpcd"))
                                Try
                                    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, CDate(dt_all(0)("END_DATE")), True, all_days, True) 'DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
                                Catch ex As Exception
                                    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, Date.Now, True, all_days, True)
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
                                    dtex = bao_ex.SP_GET_DAY_EXTEND_NEW_DATA_V3(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"), big_type, small_type, dr("drgtpcd"))
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
                                    dt_extend = bao_extend.SP_GET_DAY_EXTEND_NEW_DATA_V2_2(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"), big_type, small_type)
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
                        End If

                    ElseIf small_type = "2" Then
                        If chk_idens = True Then
                            Dim bao As New BAO.ClsDBSqlcommand
                            Dim dt As New DataTable
                            Dim dao As New DAO_CPN.clsDBsyslcnsid
                            dao.GetDataby_identify(txt_citizen.Text)
                            dt = bao.SP_GET_REPORT_DATA_EDIT_DR_E_TRACKING_WORK_DAY_RESULT_BY_LCNSID(dao.fields.lcnsid)
                            dt.Columns.Add("all_days", GetType(Double))
                            dt.Columns.Add("stop_days", GetType(Double))
                            dt.Columns.Add("extend_days", GetType(Double))
                            dt.Columns.Add("days_result", GetType(Double))

                            For Each dr As DataRow In dt.Rows
                                Dim all_days As Double = 0
                                Dim extend_days As Double = 0
                                Dim ws As New WS_GETDATE_WORKING.Service1

                                Try
                                    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, CDate(dr("appdate")), True, all_days, True) 'DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
                                Catch ex As Exception
                                    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, Date.Now, True, all_days, True)
                                End Try
                                dr("all_days") = all_days
                                Dim bao2 As New BAO.ClsDBSqlcommand
                                Dim stop_days As Double = 0
                                'Try
                                'stop_days = bao2.SP_GET_DAY_EXTEND_BY_RCVNO_RGTTPCD(dr("rcvno"), dr("rgttpcd"))
                                Dim bao_ex As New BAO.ClsDBSqlcommand
                                Dim dtex As New DataTable
                                dtex = bao_ex.SP_GET_DAY_EXTEND_NEW_DATA_V3(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"), big_type, small_type, dr("drgtpcd"))
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

                                'Try
                                '    Dim bao_extend As New BAO.ClsDBSqlcommand
                                '    Dim dt_extend As New DataTable
                                '    dt_extend = bao_extend.SP_GET_DAY_EXTEND_NEW_DATA_V2_2(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"), big_type, small_type)
                                '    For Each drex As DataRow In dt_extend.Rows
                                '        Dim ws2 As New WS_GETDATE_WORKING.Service1
                                '        Dim start_date2 As Date
                                '        Dim end_date2 As Date
                                '        Dim holiday2 As Integer = 0
                                '        Dim day_all2 As Integer = 0
                                '        Try
                                '            start_date2 = CDate(drex("START_DATE"))
                                '        Catch ex As Exception

                                '        End Try
                                '        Try
                                '            end_date2 = CDate(drex("END_DATE"))
                                '        Catch ex As Exception

                                '        End Try
                                '        day_all2 = DateDiff(DateInterval.Day, start_date2, end_date2)
                                '        ws2.GETDATE_COUNT_DAY(start_date2, True, end_date2, True, holiday2, True)

                                '        extend_days += (day_all2 - holiday2)

                                '    Next
                                'Catch ex As Exception

                                'End Try
                                'stop_days = bao2.SP_GET_DAY_EXTEND_NEW(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"))
                                'Catch ex As Exception

                                'End Try
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
                        End If
                    End If
                End If

            Else

            End If

            
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub

    Private Sub FRM_STAFF_SEARCH_REPORT_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        set_color_rg()
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
End Class