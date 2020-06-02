Public Class FRM_RESULT_REPORT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString
            txt_dateend.Text = Date.Now.ToShortDateString
        End If
    End Sub

    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        bind_data()
    End Sub
    Sub bind_data()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_DATA_RCA_E_TRACKING_BY_DATE(CDate(txt_date.Text), CDate(txt_dateend.Text))
        Catch ex As Exception

        End Try
        dt.Columns.Add("FDA_STATUS")
        dt.Columns.Add("START_DATE")
        dt.Columns.Add("SUB_STATUS")
        dt.Columns.Add("stop_days")
        For Each dr As DataRow In dt.Rows
            Dim dao_stat As New DAO_DRUG.TB_E_TRACKING_HEAD_CURRENT_STATUS
            dao_stat.GetDataby_FK_IDA_MAX(dr("IDA"))
            Dim dao_snm As New DAO_DRUG.TB_MAS_HEAD_STATUS_E_TRACKING
            Try
                dao_snm.GetDataby_IDA(dao_stat.fields.HEAD_STATUS_ID)
                dr("FDA_STATUS") = dao_snm.fields.FDA_STATUS
            Catch ex As Exception

            End Try
            Try
                dr("START_DATE") = CDate(dao_stat.fields.START_DATE)
            Catch ex As Exception

            End Try
            Try
                If dao_stat.fields.HEAD_STATUS_ID = 10 Then
                    If dao_stat.fields.SUB_STATUS_ID = 1 Then
                        dr("SUB_STATUS") = "อนุญาต"
                    ElseIf dao_stat.fields.SUB_STATUS_ID = 2 Then
                        dr("SUB_STATUS") = "คืนคำขอ"
                    ElseIf dao_stat.fields.SUB_STATUS_ID = 3 Then
                        dr("SUB_STATUS") = "ยกเลิกคำขอ"
                    ElseIf dao_stat.fields.SUB_STATUS_ID = 4 Then
                        dr("SUB_STATUS") = "จำหน่ายคำขอ (บันทึกข้อมูลผิดพลาด)"
                    ElseIf dao_stat.fields.SUB_STATUS_ID = 5 Then
                        dr("SUB_STATUS") = "ไม่อนุญาต"
                    End If
                End If
            Catch ex As Exception

            End Try

            Dim stop_days As Double = 0
            Try
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
            Catch ex As Exception

            End Try
            dr("stop_days") = stop_days

        Next
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        Dim date_now As Date = Date.Now
        Dim file_name As String = ""
        Try
            file_name = "EXPORT_" & Year(date_now) & Month(date_now) & Day(date_now)
        Catch ex As Exception

        End Try

        RadGrid1.ExportSettings.FileName = file_name
        RadGrid1.ExportSettings.IgnorePaging = True
        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub
End Class