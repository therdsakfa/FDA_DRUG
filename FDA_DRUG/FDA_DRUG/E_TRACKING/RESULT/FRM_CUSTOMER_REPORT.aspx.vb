Public Class FRM_CUSTOMER_REPORT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Try
            Dim big_type As String = ""
            Dim small_type As String = ""
            big_type = Request.QueryString("b_type")
            small_type = rdl_small_type.SelectedValue
            Dim chk_idens As Boolean
            chk_idens = chk_iden(txt_citizen.Text)
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

                                Try
                                    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, CDate(dr("appdate")), True, all_days, True) 'DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
                                Catch ex As Exception
                                    ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, Date.Now, True, all_days, True)
                                End Try
                                dr("all_days") = all_days
                                Dim bao2 As New BAO.ClsDBSqlcommand
                                Dim stop_days As Double = 0
                                Try
                                    'stop_days = bao2.SP_GET_DAY_EXTEND_BY_RCVNO_RGTTPCD(dr("rcvno"), dr("rgttpcd"))
                                    Dim bao_ex As New BAO.ClsDBSqlcommand
                                    Dim dtex As New DataTable
                                    dtex = bao_ex.SP_GET_DAY_EXTEND_NEW_DATA_V3(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"), big_type, small_type, Request.QueryString("drgtpcd"))
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
                                dtex = bao_ex.SP_GET_DAY_EXTEND_NEW_DATA_V3(dr("rcvno"), dr("rgttpcd"), dr("lcnsid"), big_type, small_type, Request.QueryString("drgtpcd"))
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

    Private Sub rdl_small_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_small_type.SelectedIndexChanged
        RadGrid1.Rebind()
    End Sub
End Class