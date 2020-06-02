Imports Microsoft.Reporting.WebForms
Public Class FRM_REPORT_ADDRESS
    Inherits System.Web.UI.Page
    Private u1 As String
    Private lcntpcd As String = ""
    Private lcnno As String = ""
    Private CITIZEN_AUTHORIZE As String = ""
    Private lcntpcd_old As String = ""
    Private FK_IDA As Integer = 0
    Sub runQuery()
        u1 = Request.QueryString("u1")  'เรียก Process ที่เราเรียก
        lcntpcd = Request.QueryString("lcncode")
        lcnno = Request.QueryString("lcn")
        CITIZEN_AUTHORIZE = Request.QueryString("c")
        lcntpcd_old = Request.QueryString("lcncode_o")
        FK_IDA = Request.QueryString("FK_IDA")
        'If u1 <> "" Then
        '    u1 = u1.DecodeBase64()
        'End If
        If lcntpcd <> "" Then
            lcntpcd = lcntpcd '.DecodeBase64
        End If
        If lcnno <> "" Then
            lcnno = lcnno '.DecodeBase64
        End If
        If CITIZEN_AUTHORIZE <> "" Then
            CITIZEN_AUTHORIZE = CITIZEN_AUTHORIZE '.DecodeBase64
        End If
        If lcntpcd_old <> "" Then
            lcntpcd_old = lcntpcd_old '.DecodeBase64
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
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
        'If Request.QueryString("type") = "2" Then
        dt = bao.SP_GET_LCN_EXTEND_BY_IDA(FK_IDA)
        'Else
        '    dt = bao.SP_XML_SEARCH_DRUG_LCN_by_U1(u1)
        'End If

        Return dt
    End Function
End Class