Imports Microsoft.Reporting.WebForms

Public Class cls_utility
    Public Class Report_Utility

        Private _root As String
        Public Property root() As String
            Get
                Return _root
            End Get
            Set(ByVal value As String)
                _root = value
            End Set
        End Property
        ''' <summary>
        ''' Get Path Report
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            _root = Global.System.Configuration.ConfigurationManager.AppSettings("paths")
        End Sub
        ''' <summary>
        ''' Function สร้างรายงาน
        ''' </summary>
        ''' <param name="report">ชื่อ ReportViewer</param>
        ''' <param name="reportPath">ที่วางไฟล์ Report.rdlc</param>
        ''' <param name="reportDataSource">ชื่อ DataSource ใน Report</param>
        ''' <param name="dt">ตารางข้อมูลรายงาน</param>
        ''' <remarks></remarks>
        Public Sub ShowReport(ByVal report As ReportViewer, ByVal reportPath As String, ByVal reportDataSource As String, ByVal dt As DataTable)
            report.LocalReport.ReportPath = reportPath
            report.LocalReport.EnableExternalImages = True
            report.LocalReport.DataSources.Clear()
            'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
            Dim rds As New ReportDataSource(reportDataSource, dt)
            report.LocalReport.DataSources.Add(rds)
            report.LocalReport.Refresh()
            report.DataBind()
        End Sub
        ''' <summary>
        ''' ตัวแปรรับ ReportViewer ที่ส่งมา
        ''' </summary>
        ''' <remarks></remarks>
        Public report As ReportViewer
        ''' <summary>
        ''' Function กำหนดขนาดของ ReportViewer
        ''' </summary>
        ''' <param name="width">ความกว้าง</param>
        ''' <param name="height">ความสูง</param>
        ''' <remarks></remarks>
        Public Sub configWidthHeight(Optional ByVal width As Integer = 1600, Optional ByVal height As Integer = 600)
            report.Width = width 'กำหนดความกว้าง
            report.Height = height 'กำหนดความสูง
        End Sub

        Public Function get_short_month(date_ex As Date) As String
            Dim str_date As String = ""
            Dim str_month As String = ""
            Dim month_num As Integer = Month(date_ex)
            Dim get_day As Integer = date_ex.Day
            Dim get_year As Integer
            If date_ex.Year < 2500 Then
                get_year = date_ex.Year + 543
            End If

            Select Case month_num
                Case 1
                    str_month = "ม.ค."
                Case 2
                    str_month = "ก.พ."
                Case 3
                    str_month = "มี.ค."
                Case 4
                    str_month = "เม.ย."
                Case 5
                    str_month = "พ.ค."
                Case 6
                    str_month = "มิ.ย."
                Case 7
                    str_month = "ก.ค."
                Case 8
                    str_month = "ส.ค."
                Case 9
                    str_month = "ก.ย."
                Case 10
                    str_month = "ต.ค."
                Case 11
                    str_month = "พ.ย."
                Case 12
                    str_month = "ธ.ค."
            End Select
            str_date = get_day & " " & str_month & " " & get_year

            Return str_date
        End Function
        Public Function get_Long_month(date_ex As Date) As String
            Dim str_date As String = ""
            Dim str_month As String = ""
            Dim month_num As Integer = Month(date_ex)
            Dim get_day As Integer = date_ex.Day
            Dim get_year As Integer
            If date_ex.Year < 2500 Then
                get_year = date_ex.Year + 543
            End If

            Select Case month_num
                Case 1
                    str_month = "มกราคม"
                Case 2
                    str_month = "กุมภาพันธ์"
                Case 3
                    str_month = "มีนาคม"
                Case 4
                    str_month = "เมษายน"
                Case 5
                    str_month = "พฤษภาคม"
                Case 6
                    str_month = "มิถุนายน"
                Case 7
                    str_month = "กรกฎาคม"
                Case 8
                    str_month = "สิงหาคม"
                Case 9
                    str_month = "กันยายน"
                Case 10
                    str_month = "ตุลาคม"
                Case 11
                    str_month = "พฤศจิกายน"
                Case 12
                    str_month = "ธันวาคม"
            End Select
            str_date = get_day & " " & str_month & " " & get_year

            Return str_date
        End Function
        Public Function get_budget_month(month_ori As Integer) As Integer
            Dim month_digit As Integer = 0

            Select Case month_ori
                Case 10
                    month_digit = 1
                Case 11
                    month_digit = 2
                Case 12
                    month_digit = 3
                Case 1
                    month_digit = 4
                Case 2
                    month_digit = 5
                Case 3
                    month_digit = 6
                Case 4
                    month_digit = 7
                Case 5
                    month_digit = 8
                Case 6
                    month_digit = 9
                Case 7
                    month_digit = 10
                Case 8
                    month_digit = 11
                Case 9
                    month_digit = 12
            End Select

        End Function
        Public Function get_Long_month_BY_Number(ByVal month_num As Integer) As String
            Dim str_month As String = ""

            Select Case month_num
                Case 1
                    str_month = "มกราคม"
                Case 2
                    str_month = "กุมภาพันธ์"
                Case 3
                    str_month = "มีนาคม"
                Case 4
                    str_month = "เมษายน"
                Case 5
                    str_month = "พฤษภาคม"
                Case 6
                    str_month = "มิถุนายน"
                Case 7
                    str_month = "กรกฎาคม"
                Case 8
                    str_month = "สิงหาคม"
                Case 9
                    str_month = "กันยายน"
                Case 10
                    str_month = "ตุลาคม"
                Case 11
                    str_month = "พฤศจิกายน"
                Case 12
                    str_month = "ธันวาคม"
            End Select


            Return str_month
        End Function

        Function get_name_person_or_office_name(ByVal _type As Integer, ByVal identify As String) As String
            '_type = 2 คือบุคคล
            Dim nm As String = ""
            Dim prefix As String = ""
            Dim name As String = ""
            Dim l_name As String = ""
            Dim dao As New DAO_CPN.clsDBsyslcnsnm
            dao.GetDataby_identify(identify)

            Dim dao_pre As New DAO_CPN.TB_sysprefix
            Try
                dao_pre.Getdata_byid(dao.fields.prefixcd)
                prefix = dao_pre.fields.thanm
            Catch ex As Exception

            End Try
            Try
                name = dao.fields.thanm
            Catch ex As Exception

            End Try

            nm = prefix & name

            If _type = 2 Then
                nm &= " " & dao.fields.thalnm
            End If


            Return nm
        End Function

    End Class
End Class
