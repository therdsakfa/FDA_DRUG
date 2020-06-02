Imports FDA_DRUG.Graph3DMultiple
Imports System.Web.Script.Serialization
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Public Class WebForm22
    Inherits System.Web.UI.Page
    Private StrHtmlGenerate As New StringBuilder()
    Private StrExport As New StringBuilder()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    'bind_graph_new()
        'End If
        'Dim ref2 As String = "47"
        'Dim ref As String = ""
        'ref2 = String.Format("{0:0000}", CInt(ref2))
        'Dim ddd As Date
        'ddd = CDate("2559-12-30")
        'Dim a As String = ""
        'For i As Integer = 0 To 0
        '    a = i
        'Next
        'Dim aaaa As String = ""
        'Dim uti As New cls_utility.Report_Utility
        'aaaa = uti.get_name_person_or_office_name(2, "3100903235319")
        ''Dim ws As New WS_PVNCD.WebService1
        'Dim aa As String = "0x7B005C0072007400660031005C0061006E00730069005C0061006E00730069006300700067003800370034005C007500630031005C00640065006600660030007B005C0066006F006E007400740062006C000D000A007B005C00660030005C006600730077006900730073005C00660063006800610072007300650074003200320032005C0066007000720071003200200044006F006B004300680061006D00700061003B007D000D000A007B005C00660031005C006600730077006900730073005C00660063006800610072007300650074003200320032005C006600700072007100320020005400610068006F006D0061003B007D000D000A007B005C00660032005C00660072006F006D0061006E005C006600630068006100720073006500740032005C00660070007200710032002000530079006D0062006F006C003B007D007D000D000A007B005C0063006F006C006F007200740062006C003B005C0072006500640030005C0067007200650065006E0030005C0062006C007500650030003B005C007200650064003200350035005C0067007200650065006E003200350035005C0062006C00750065003200350035003B007D000D000A007B005C007300740079006C006500730068006500650074007B005C00730030005C00690074006100700030005C00660030005C00660073003200340020005B004E006F0072006D0061006C005D003B007D007B005C002A005C0063007300310030005C00610064006400690074006900760065002000440065006600610075006C0074002000500061007200610067007200610070006800200046006F006E0074003B007D007D000D000A007B005C002A005C00670065006E0065007200610074006F0072002000540058005F00520054004600330032002000310031002E0030002E003400300031002E003500300032003B007D000D000A005C0064006500660074006100620031003100330034005C00700061007000650072007700310032003200340030005C00700061007000650072006800310035003800340030005C006D006100720067006C0030005C006D00610072006700740030005C006D00610072006700720030005C006D00610072006700620030005C0070006100720064005C00690074006100700030005C0070006C00610069006E005C00660031005C0066007300320030005C006C006F00630068005C00660031005C0068006900630068005C00660031005C002700620061005C002700630033005C002700630033005C002700610038005C007500330036003400300020003F005C002700650033005C002700620039005C002700650031005C002700620063005C002700610037005C002700620061005C002700630035005C007500330036003300360020003F005C002700630061005C002700650030005C002700620035005C002700630064005C002700630033005C007500330036003600300020003F005C002700630035005C0027006400300020003100300020005C002700650030005C002700630031005C007500330036003500350020003F005C00270062003400200020005C002700650033005C002700620039005C002700610031005C002700630035005C007500330036003500360020003F005C002700630064005C002700610037005C002700610031005C002700630033005C002700640030005C002700620034005C002700640032005C002700630039005C002700610031005C002700630035005C007500330036003500360020003F005C002700630064005C002700610037005C002700630035005C002700640030002000330020005C002700650031005C002700620063005C002700610037007D00"
        'Dim bb As String = ""

        'Dim bytes = Convert.FromBase64String(aa)
        'Dim text = DecodeServerName(aa)

        'Dim dt As New DataTable
        'dt = ws.getNewcode_Lcnno_by_identify_and_taxnoauthorize("1102001745831", "0715547000306")
    End Sub
    'Public Sub bind_graph_new()
    '   Dim dt As New DataTable
    '    dt.Columns.Add("proj_name")
    '    dt.Columns.Add("amount1", GetType(Double))
    '    dt.Columns.Add("amount2", GetType(Double))
    '    For i As Integer = 1 To 4
    '        Dim dr As DataRow = dt.NewRow()
    '        dr("proj_name") = "โครงการที่ " & i
    '        dr("amount1") = 100
    '        dr("amount2") = 20 * i
    '        dt.Rows.Add(dr)
    '    Next

    '    If dt.Rows.Count > 0 Then
    '        Dim rootobject As New Graph3DMultiple.Rootobject ' Rootobject

    '        Dim cha As New Graph3DMultiple.Chart
    '        cha.caption = "ตัวอย่างงงงงง"
    '        cha.yaxisname = ""
    '        cha.canvasbgcolor = "FEFEFE"
    '        cha.canvasbasecolor = "FEFEFE"
    '        cha.tooltipbgcolor = "DEDEBE"
    '        cha.tooltipborder = "889E6D"
    '        cha.divlinecolor = "999999"
    '        cha.showcolumnshadow = "0"
    '        cha.divlineisdashed = "1"
    '        cha.divlinedashlen = "1"
    '        cha.divlinedashgap = "2"
    '        cha.numberprefix = ""
    '        cha.numbersuffix = ""
    '        cha.showborder = "0"
    '        cha.formatnumberscale = "0"
    '        rootobject.chart = cha

    '        Dim category As New Category
    '        For Each dr As DataRow In dt.Rows
    '            Dim cat As New Category1
    '            cat.label = dr("proj_name")
    '            category.category.Add(cat)
    '        Next

    '        rootobject.categories.Add(category)

    '        Dim datase As New DataSet
    '        datase.seriesname = "แผน"
    '        'datase.color = "189100"

    '        Dim datase2 As New DataSet
    '        datase2.seriesname = "เบิกจริง"
    '        'datase2.color = "2ccf0c"

    '        For Each dr As DataRow In dt.Rows
    '            Dim datum As New Datum
    '            datum.value = dr("amount1")
    '            datum.link = ""


    '            datum.color = "189100"
    '            datase.data.Add(datum)

    '            Dim datum2 As New Datum
    '            datum2.value = dr("amount2")
    '            datum2.link = ""
    '            If dr("amount2") <= 30 Then
    '                datum2.color = "ff0000"
    '            ElseIf dr("amount2") > 30 And dr("amount2") <= 50 Then
    '                datum2.color = "f5f200"
    '            ElseIf dr("amount2") > 50 And dr("amount2") <= 70 Then
    '                datum2.color = "00ff60"
    '            ElseIf dr("amount2") > 70 Then
    '                datum2.color = "189100"
    '            End If
    '            datase2.data.Add(datum2)


    '        Next

    '        rootobject.dataset.Add(datase)
    '        rootobject.dataset.Add(datase2)

    '        Dim serializer As New JavaScriptSerializer()
    '        Dim serializedResult = serializer.Serialize(rootobject)

    '        HiddenField1.Value = serializedResult
    '    Else
    '        HiddenField1.Value = ""
    '    End If
    'End Sub
    Public Shared Function EncodeServerName(serverName As String) As String
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName))
    End Function

    Public Shared Function DecodeServerName(encodedServername As String) As String
        Return Encoding.UTF8.GetString(Convert.FromBase64String(encodedServername))
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim ws As New WS_GETDATE_WORKING.Service1
        'Dim start_date As Date = CDate("2559-12-01")
        'Dim end_date As Date = Date.Now
        'Dim holiday As Integer = 0
        'Dim day_all As Integer = 0
        'day_all = DateDiff(DateInterval.Day, start_date, end_date)
        'ws.GETDATE_COUNT_DAY(start_date, True, end_date, True, holiday, True)
        'Dim cal_day As Integer = 0
        'cal_day = day_all - holiday

        export_excel2()
    End Sub

    Private Sub export_excel2()
        Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        'dt = bao.SP_E_TRACKING_PERSON_WORK(Request.QueryString("gid"), Request.QueryString("col4"), "(" & Request.QueryString("col5") & ")", Request.QueryString("iden"), Request.QueryString("t"))
        'dt = bao.SP_E_TRACKING_PERSON_WORK_BY_IDEN_AND_COL5(Request.QueryString("iden"), Request.QueryString("col5"))
        Dim dt2 As New DataTable
        dt2.Columns.Add("เลขที่รับ")
        dt2.Columns.Add("วันที่รับคำขอ")
        dt2.Columns.Add("กลุ่มงาน")

        dt2.Columns.Add("ชื่อ-นามสกุลเจ้าหน้าที")
        dt2.Columns.Add("ประเภท")

        dt2.Columns.Add("ชื่อยา")
        dt2.Columns.Add("ผู้รับอนุญาต")

        dt2.Columns.Add("การรับคำขอ")
        Dim bao_list As New BAO.ClsDBSqlcommand
        Dim dt_list As New DataTable
        'dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL()
        'If Request.QueryString("ctzid") <> "" Then
        'dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL_BY_CTZID(Request.QueryString("gid"), Request.QueryString("ctzid"))
        dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL_BY_CTZID_V2("3830100303444")
        'Else
        '    dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP_NEW(Request.QueryString("gid"))
        'End If

        'RadGrid1.DataSource = dt_list
        For Each dr As DataRow In dt_list.Rows
            Dim dr2 As DataRow = dt2.NewRow()
            dr2("เลขที่รับ") = dr("rcvno_display")
            Try
                dr2("วันที่รับคำขอ") = CDate(dr("rcvdate")).ToShortDateString()
            Catch ex As Exception

            End Try

            dr2("กลุ่มงาน") = dr("wrkuntnm")

            dr2("ชื่อ-นามสกุลเจ้าหน้าที") = dr("stfthanm")
            dr2("ประเภท") = dr("WORK_NAME")

            dr2("ชื่อยา") = dr("drgnm")
            dr2("ผู้รับอนุญาต") = dr("thanm")

            dr2("การรับคำขอ") = "" 'dr("rqt_type")
            dt2.Rows.Add(dr2)
        Next

        'For ii As Integer = 0 To dt2.Columns.Count - 1
        '    If ii > 1 Then
        '        dt2.Columns.RemoveAt(ii)
        '    End If

        'Next



        Dim filename As String = ""
        filename = "Export_" & Date.Now.ToString("ddMMyyyy")

        Dim attachment As String = "attachment; filename=" & filename & ".xls"
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = "windows-874"
        'Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
        ' Response.Charset = "utf-8"
        Response.HeaderEncoding = System.Text.Encoding.GetEncoding(874)
        Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"



        Dim tab As String = ""
        For Each dc As DataColumn In dt2.Columns
            Response.Write(tab + dc.ColumnName)
            tab = vbTab
        Next
        Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dt2.Rows
            tab = ""
            For i = 0 To dt2.Columns.Count - 1
                Response.Write(tab & dr(i).ToString())
                tab = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()

    End Sub

    Private Sub trim_Click(sender As Object, e As EventArgs) Handles trim.Click
        Dim aaa As String = "tttsas ssasa  "
        Dim bb As String = RTrim(LTrim((aaa)))
    End Sub
    Function RemoveWhitespace(fullString As String) As String
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function
End Class