Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Public Class FRM_REPORT_BEHIND
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            runreport()
        End If
    End Sub
    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData() As DataTable
        Dim dt As New DataTable
        'Dim bao As New BAO_BUDGET.Report
        'UC_Report_SelectDate_Single.getDateSelect()
        'Dim dt As DataTable = bao.getReportData_R2_025(UC_Report_SelectDate_Single.dateSelect) 'ส่ง Parameter วันที่ต้องการดูรายงานเข้าไป
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_EDIT_HISTORY_REPORT_BY_FK_IDA(Request.QueryString("ida"))
        dt = bao.SP_EDIT_HISTORY_REPORT_BY_FK_IDA(Request.QueryString("ida"))
        Return dt
    End Function

    Public Sub runreport()
        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "EDIT_LOCATION_STAFF\REPORT\edit_lcn.rdlc", "Fields_Report_EDIT", getReportData())
    End Sub
    'Protected Sub ReportViewer_OnLoad(sender As Object, e As EventArgs)
    '    'string exportOption = "Excel";
    '    Dim exportOption As String = "WORD"
    '    'Dim exportOption As String = "PDF"
    '    Dim extension As RenderingExtension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption, StringComparison.CurrentCultureIgnoreCase))
    '    If extension IsNot Nothing Then
    '        Dim fieldInfo As System.Reflection.FieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
    '        fieldInfo.SetValue(extension, False)
    '    End If
    'End Sub

    Protected Sub ExportReportsToWord()
        ' Variables
        Dim warnings As Warning()
        Dim streamIds As String()
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        ' reportViewer1 and reportViewer2 are reports on my asp.net page
        Dim bytes1 As Byte() = ReportViewer1.LocalReport.Render("WORD", Nothing, mimeType, encoding, extension, streamIds, _
            warnings)
        ReportViewer1.ShowPrintButton = True
        Me.ReportViewer1.LocalReport.Refresh()
        'create a single byte array out of multiple arrays
        Dim bytes As Byte() = (bytes1.Concat(bytes1)).ToArray()

        ' Now that you have all the bytes representing the Word report, buffer it and send it to the client.
        Response.Buffer = True
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=" + "singleReport" + ".") & extension)
        Response.BinaryWrite(bytes)
        ' create the file
        Response.Flush()
        ' send it to the client to download
        Response.[End]()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Export_to_Word()
        ''Get the data from database into datatable
        ''Dim strQuery As String = "select CustomerID, ContactName, City, " & _
        ''                              "PostalCode from customers"
        ''Dim cmd As New SqlCommand(strQuery)
        'Dim dt As DataTable = getReportData()

        'Dim dt2 As New DataTable
        'dt2.Columns.Add("txt")
        'Dim txt As String = ""
        'If dt.Rows.Count > 0 Then
        '    txt = dt(0)("lcnno_display") & vbCrLf & "รายการแก้ไขเปลี่ยนแปลงใบอนุญาต" & vbCrLf & dt(0)("count_edit") & vbCrLf & "ตามเลขรับที่ " & _
        '        dt(0)("RCVNO_T")
        '    For i As Integer = 0 To dt.Rows.Count - 1
        '        txt &= vbCrLf & dt(i)("edit_text")
        '    Next
        'End If

        'If txt <> "" Then
        '    Dim dr As DataRow = dt2.NewRow
        '    dr("txt") = txt
        '    dt2.Rows.Add(dr)
        '    'Create a dummy GridView
        '    Dim GridView1 As New GridView()
        '    GridView1.AllowPaging = False
        '    GridView1.DataSource = dt2
        '    GridView1.DataBind()

        '    Response.Clear()
        '    Response.Buffer = True
        '    Response.AddHeader("content-disposition", _
        '         "attachment;filename=DataTable.doc")
        '    Response.Charset = ""
        '    Response.ContentType = "application/vnd.ms-word "
        '    Dim sw As New StringWriter()
        '    Dim hw As New HtmlTextWriter(sw)
        '    GridView1.RenderControl(hw)
        '    Response.Output.Write(sw.ToString())
        '    Response.Flush()
        '    Response.End()
        'End If

    End Sub

    Private Sub Export_to_Word()
        Dim dt As DataTable = getReportData()

        Dim dt2 As New DataTable
        dt2.Columns.Add("txt")
        Dim txt As String = ""
        If dt.Rows.Count > 0 Then
            txt = dt(0)("lcnno_display") & vbCrLf & "รายการแก้ไขเปลี่ยนแปลงใบอนุญาต" & vbCrLf & dt(0)("count_edit") & vbCrLf & "ตามเลขรับที่ " & _
                dt(0)("RCVNO_T")
            For i As Integer = 0 To dt.Rows.Count - 1
                txt &= vbCrLf & dt(i)("edit_text")
            Next
            txt &= vbCrLf & "ทั้งนี้ ตั้งแต่วันที่"
        End If
        If txt <> "" Then
            'Dim dr As DataRow = dt2.NewRow
            'dr("txt") = txt
            'dt2.Rows.Add(dr)
            Dim strBuilder As StringBuilder = New StringBuilder()
            'strBuilder.Append("<div>")

            strBuilder.Append(txt)
            'strBuilder.Append("</div>".ToString())

            Response.Clear()
            Response.ContentType = "application/vnd.ms-word"
            Response.Charset = "TIS-620"
            Response.AddHeader("content-disposition", _
                 "attachment;filename=DataTable.doc")
            Response.Output.Write(strBuilder.ToString())
            Response.Flush()
            Response.End()
            'Response.Write(strBuilder.ToString())
            'Response.End()
        End If
    End Sub

End Class