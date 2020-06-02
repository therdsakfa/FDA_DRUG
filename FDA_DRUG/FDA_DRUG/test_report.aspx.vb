Imports Microsoft.Reporting.WebForms
Public Class test_report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim util As New cls_utility.Report_Utility
            util.report = ReportViewer1
            util.configWidthHeight()
            runpdf(getReportData(), util.root & "post_extend.rdlc", "Fields_Report")
        End If
    End Sub
    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
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
        'rsw.DataSources.Add(New ReportDataSource(report_datasource2, dt2))

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
        dt.Columns.Add("name")
        dt.Columns.Add("addr")
        For i As Integer = 0 To 0
            Dim dr As DataRow = dt.NewRow()
            dr("name") = "เอกวนิชฟาร์มา"
            dr("addr") = "เอกวนิชฟาร์มา บ้านเลขที่ 2/8-9     ถนนอู่ทอง  ตำบลบ้านเหนือ อำเภอเมืองกาญจนบุรี จังหวัดกาญจนบุรี 71000 โทร.0 3451 1017 โทรสาร. -"
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function
End Class