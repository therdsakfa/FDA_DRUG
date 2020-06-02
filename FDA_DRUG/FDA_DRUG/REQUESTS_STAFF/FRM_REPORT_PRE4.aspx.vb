Imports Microsoft.Reporting.WebForms
Public Class FRM_REPORT_PRE4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_enddate.Text = Date.Now.ToShortDateString
            txt_startdate.Text = Date.Now.ToShortDateString
        End If
    End Sub
    Public Function getReportData() As DataTable
        Dim dtMain As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dtMain = bao.SP_MAS_PRE4_TEMPLATE()

        dtMain.Columns.Add("old_daywork")
        dtMain.Columns.Add("new_daywork")

        dtMain.Columns.Add("r_req") 'ยื่น
        dtMain.Columns.Add("r_wait_chk") 'รอตรวจฯ
        dtMain.Columns.Add("r_wait_edt") 'รอแก้ไข
        dtMain.Columns.Add("r_wait_pay_assess") 'รอชำระเงินค่าประเมิน
        dtMain.Columns.Add("r_no") 'ไม่รับ
        dtMain.Columns.Add("r_ok") 'รับ

        dtMain.Columns.Add("r_req2") 'ยื่น
        dtMain.Columns.Add("r_wait_stat_last") 'ยังไม่บันทึกสถานะสุดท้าย
        dtMain.Columns.Add("r_no2") 'ไม่รับ
        dtMain.Columns.Add("r_ok2") 'รับ

        dtMain.Columns.Add("c_ok_no_overtime") 'อนุญาตไม่เกินเวลา
        dtMain.Columns.Add("c_ok_overtime") 'เกินเวลา

        dtMain.Columns.Add("c_no_no_overtime") 'ไม่อนุญาตไม่เกินเวลา
        dtMain.Columns.Add("c_no_overtime") 'ไม่อนุญาตเกินเวลา

        dtMain.Columns.Add("c_reject_overtime") 'คืนคำขอเกินเวลา
        dtMain.Columns.Add("c_reject_intime") 'คืนคำขอเกินไม่เวลา

        dtMain.Columns.Add("c_error_overtime") 'จำหน่ายคำขอ
        dtMain.Columns.Add("c_error_intime") 'จำหน่ายคำขอ

        dtMain.Columns.Add("c_cancel") 'ยกเลิก

        dtMain.Columns.Add("w_overtime") 'อยู่ระหว่างพิจารณาไม่เกินเวลา
        dtMain.Columns.Add("w_no_overtime") 'อยู่ระหว่างพิจารณาเกินเวลา

        For Each drMain As DataRow In dtMain.Rows

            '----------------------พิจารณาแล้วเสร็จ (อนุญาต)----------------------
            Dim bao_allow As New BAO.ClsDBSqlcommand
            Dim dt_allow As New DataTable
            dt_allow = bao_allow.SP_PRE4_ALLOW_ALL(CDate(txt_startdate.Text), CDate(txt_enddate.Text), 1, drMain("group_process_ida"))

            drMain("c_ok_overtime") = GET_AMOUNT_ALLOW(1, dt_allow)
            drMain("c_ok_no_overtime") = GET_AMOUNT_ALLOW(0, dt_allow)
            '----------------------จบพิจารณาแล้วเสร็จ (อนุญาต)----------------------

            '----------------------พิจารณาแล้วเสร็จ (ไม่อนุญาต)----------------------
            Dim bao_allow_no As New BAO.ClsDBSqlcommand
            Dim dt_allow_no As New DataTable
            dt_allow_no = bao_allow.SP_PRE4_ALLOW_ALL(CDate(txt_startdate.Text), CDate(txt_enddate.Text), 5, drMain("group_process_ida"))

            drMain("c_no_no_overtime") = GET_AMOUNT_ALLOW(1, dt_allow_no)
            drMain("c_no_overtime") = GET_AMOUNT_ALLOW(0, dt_allow_no)
            '----------------------จบพิจารณาแล้วเสร็จ (ไม่อนุญาต)----------------------
            '----------------------คืนคำขอ----------------------
            Dim bao_reject As New BAO.ClsDBSqlcommand
            Dim dt_reject As New DataTable
            dt_reject = bao_allow.SP_PRE4_ALLOW_ALL(CDate(txt_startdate.Text), CDate(txt_enddate.Text), 2, drMain("group_process_ida"))

            drMain("c_reject_overtime") = GET_AMOUNT_ALLOW(1, dt_reject)
            drMain("c_reject_intime") = GET_AMOUNT_ALLOW(0, dt_reject)
            '----------------------จบคืนคำขอ----------------------

            '----------------------จำหน่ายคำขอ----------------------
            Dim bao_error As New BAO.ClsDBSqlcommand
            Dim dt_error As New DataTable
            dt_error = bao_allow.SP_PRE4_ALLOW_ALL(CDate(txt_startdate.Text), CDate(txt_enddate.Text), 4, drMain("group_process_ida"))

            drMain("c_error_overtime") = GET_AMOUNT_ALLOW(1, dt_reject)
            drMain("c_error_intime") = GET_AMOUNT_ALLOW(0, dt_reject)
            '----------------------จบจำหน่ายคำขอ----------------------

            '----------------------พิจารณาแล้วเสร็จ (ยกเลิก)----------------------
            Dim bao_cancel As New BAO.ClsDBSqlcommand
            Dim dt_cancel As New DataTable
            dt_cancel = bao_allow.SP_PRE4_ALLOW_ALL(CDate(txt_startdate.Text), CDate(txt_enddate.Text), 3, drMain("group_process_ida"))
            drMain("c_cancel") = dt_cancel.Rows.Count
            '----------------------จบพิจารณาแล้วเสร็จ (ยกเลิก)----------------------

            '----------------------อยู่ระหว่างพิจารณา----------------------
            Dim bao_wait_allow As New BAO.ClsDBSqlcommand
            Dim dt_wait_allow As New DataTable
            dt_wait_allow = bao_allow.SP_PRE4_WAIT_ALLOW_ALL(CDate(txt_startdate.Text), CDate(txt_enddate.Text), drMain("group_process_ida"))

            drMain("w_no_overtime") = GET_AMOUNT_ALLOW(1, dt_wait_allow)
            drMain("w_overtime") = GET_AMOUNT_ALLOW(0, dt_wait_allow)
            '----------------------จบอยู่ระหว่างพิจารณา----------------------

        Next

        Return dtMain
    End Function
    Public Function GET_AMOUNT_ALLOW(ByVal isover As Integer, ByVal dt As DataTable) As Integer
        Dim amount_in As Integer = 0
        Dim amount_over As Integer = 0
        For Each drallow As DataRow In dt.Rows
            Dim ws2 As New WS_GETDATE_WORKING.Service1
            Dim start_date2 As Date
            Dim end_date2 As Date
            Dim holiday2 As Integer = 0
            Dim day_all2 As Integer = 0
            Dim result_allow As Integer = 0
            Try
                start_date2 = CDate(drallow("START_DATE"))
            Catch ex As Exception

            End Try
            Try
                end_date2 = CDate(drallow("END_DATE"))
            Catch ex As Exception

            End Try
            day_all2 = DateDiff(DateInterval.Day, start_date2, end_date2)
            ws2.GETDATE_COUNT_DAY(start_date2, True, end_date2, True, holiday2, True)

            result_allow = day_all2 - holiday2
            If result_allow > drallow("DAY_WORK") Then
                amount_in += 1
            Else
                amount_over += 1
            End If
        Next
        If isover = 1 Then
            Return amount_over
        Else
            Return amount_in
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getReportData()
    End Sub
End Class