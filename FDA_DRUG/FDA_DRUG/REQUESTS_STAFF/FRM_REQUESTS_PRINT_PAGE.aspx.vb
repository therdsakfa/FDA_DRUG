Imports Microsoft.Reporting.WebForms

Public Class FRM_REQUESTS_PRINT_PAGE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            run_report()
        End If
    End Sub
    Public Sub run_report()
       

        Dim dao_his As New DAO_DRUG.TB_CONSIDER_REQ_PRINT_HISTORY
        dao_his.GetDataby_IDA(Request.QueryString("ida"))

        Dim dt As New DataTable
        'SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            If Request.QueryString("g") = "" Then
                dt = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO)

            Else
                If Request.QueryString("g") = 1 Then
                    dt = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 402)
                Else
                    dt = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 401)
                End If
            End If
        Catch ex As Exception

        End Try

        dt.Columns.Add("rows_count")
        dt.Columns.Add("bsn_count")
        dt.Columns.Add("SENT_DOCUMENT_NAME")
        dt.Columns.Add("PRINT_COUNT")
        dt.Columns.Add("PRINT_DATE")

        Dim rows_count As Integer = 0
        Dim bsn_count As Integer = 0
        Try
            rows_count = dt.Rows.Count
        Catch ex As Exception

        End Try
        Dim bao2 As New BAO.ClsDBSqlcommand
        Dim dt2 As New DataTable
        'SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP_NEW

        Try
            If Request.QueryString("g") = "" Then
                dt2 = bao2.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO)

            Else
                If Request.QueryString("g") = "1" Then
                    dt2 = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 402)
                Else
                    dt2 = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 401)
                End If
            End If
        Catch ex As Exception

        End Try

        Try
            bsn_count = dt2.Rows.Count
        Catch ex As Exception

        End Try

        For Each dr As DataRow In dt.Rows
            dr("rows_count") = rows_count
            dr("bsn_count") = bsn_count
            dr("SENT_DOCUMENT_NAME") = dao_his.fields.SENT_DOCUMENT_NAME
            Try
                dr("PRINT_COUNT") = dao_his.fields.PRINT_COUNT & "/" & Right(dao_his.fields.YEAR_PRINT, 2)
            Catch ex As Exception

            End Try
            dr("PRINT_DATE") = dao_his.fields.PRINT_DATE
        Next
        runpdf(dt, "RDLC\report_request.rdlc", "Fields_Report_request")
    End Sub
    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
        Dim rsw As New LocalReport
        rsw.ReportPath = path
        Dim reportdatasource As New ReportDataSource

        reportdatasource.Value = dt1
        reportdatasource.Name = report_datasource
        rsw.DataSources.Add(reportdatasource)


        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = rsw.Render(ReportType, Nothing, Nothing, Nothing, FileNameExtension, streams, warnings)

        'ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        Response.AddHeader("Accept-Ranges", "bytes")
        Response.AddHeader("Accept-Header", "2222")
        Response.AddHeader("Cache-Control", "public")
        Response.AddHeader("Cache-Control", "must-revalidate")
        Response.AddHeader("Pragma", "public")



        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline; filename=""" + "Test.pdf" + """")
        Response.AddHeader("expires", "0")


        Response.BinaryWrite(renderedbytes)
        Response.Flush()
    End Sub
End Class