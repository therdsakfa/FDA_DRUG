Imports Microsoft.Reporting.WebForms

Public Class FRM_REPORT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim util As New cls_utility.Report_Utility
            util.report = ReportViewer1
            util.configWidthHeight()
            runpdf(getReportData(), getReportDataHead(), util.root & "E_TRACKING\TIME_CALCULATE\Report\work_complete.rdlc", "Fields_Report_work_complete", "Fields_Report_work_head")
        End If
    End Sub
    Private Sub runpdf(ByVal dt1 As DataTable, ByVal dt2 As DataTable, ByVal path As String, ByVal report_datasource As String, ByVal report_datasource2 As String)
        Dim rsw As New LocalReport
        rsw.ReportPath = path
        Dim reportdatasource As New ReportDataSource
        'Dim reportdatasource2 As New ReportDataSource

        'reportdatasource.Value = dt1
        'reportdatasource.Value = dt2
        'reportdatasource.Name = report_datasource
        'reportdatasource.Name = report_datasource2
        'rsw.DataSources.Add(reportdatasource)
        rsw.DataSources.Add(New ReportDataSource(report_datasource, dt1))
        rsw.DataSources.Add(New ReportDataSource(report_datasource2, dt2))

        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = rsw.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        'ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        Response.AddHeader("Accept-Ranges", "bytes")
        Response.AddHeader("Accept-Header", "2222")
        Response.AddHeader("Cache-Control", "public")
        Response.AddHeader("Cache-Control", "must-revalidate")
        Response.AddHeader("Pragma", "public")
        'Response.AddHeader()
        'Response.AddHeader("Content-Encoding", "UTF-8")

        'Response.ContentEncoding = System.Text.Encoding.Unicode   'GetEncoding(874)
        'Response.Charset = "windows-874"
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline; filename=""" + "Test.pdf" + """")
        Response.AddHeader("expires", "0")


        Response.BinaryWrite(renderedbytes)
        Response.Flush()
    End Sub
    Public Function getReportData() As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_EDIT_HISTORY_REPORT_BY_FK_IDA(Request.QueryString("ida"))
        dt = bao.SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA(Request.QueryString("ida"))
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
        Return dt
    End Function
    Public Function getReportDataHead() As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_EDIT_HISTORY_REPORT_BY_FK_IDA(Request.QueryString("ida"))
        dt = bao.SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_REPORT_BY_IDA(Request.QueryString("ida"))
        
        Return dt
    End Function
End Class