Public Class FRM_CHEMICAL_SEARCH
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim bao As New BAO.ClsDBSqlcommand
        If String.IsNullOrEmpty(txt_casname.Text) = False Then
            '  GV_data.DataSource = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)
            Dim dt As New DataTable
            If Request.QueryString("aori") <> "" Then
                dt = bao.SP_MAS_CHEMICAL_by_IOWANM_AND_AORI(txt_casname.Text, Request.QueryString("aori"))
            Else
                dt = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)
            End If
            GV_data.DataSource = dt
            GV_data.DataBind()
        Else
            alert("กรุณากรอกชื่อสาร")
        End If

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        export_excel2()
        
    End Sub
    Private Sub export_excel()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        If String.IsNullOrEmpty(txt_casname.Text) = False Then
            'dt = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)
            If Request.QueryString("aori") <> "" Then
                dt = bao.SP_MAS_CHEMICAL_by_IOWANM_AND_AORI(txt_casname.Text, Request.QueryString("aori"))
            Else
                dt = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)
            End If


            Dim dt2 As New DataTable
            dt2.Columns.Add("code")
            dt2.Columns.Add("name")
            For Each dr As DataRow In dt.Rows
                Dim dr2 As DataRow = dt2.NewRow()
                dr2("code") = dr("IDA")
                dr2("name") = dr("iowanm")
                dt2.Rows.Add(dr2)
            Next
            Dim Source As String = ObjecttoCSV(dt2)
            Response.Clear()
            Response.Buffer = True
            Response.ClearContent()
            Response.Charset = "windows-874"
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
            Dim filename As String = ""
            filename = "Export_" & Date.Now.ToString("ddMMyyyy")
            Response.AddHeader("content-disposition", "attachment;filename=" & filename & ".xls")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.ms-excel"

            Response.Write(Source)
            Response.End()
        Else
            alert("ไม่พบข้อมูล")
        End If
    End Sub

    Private Sub export_excel2()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'If String.IsNullOrEmpty(txt_casname.Text) = False Then
        'dt = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)

        If Request.QueryString("aori") <> "" Then
            dt = bao.SP_MAS_CHEMICAL_by_IOWANM_AND_AORI(txt_casname.Text, Request.QueryString("aori"))
        Else
            dt = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)
        End If


        Dim dt2 As New DataTable
        dt2.Columns.Add("รหัสประจำสาร")
        dt2.Columns.Add("ชื่อสาร")
        For Each dr As DataRow In dt.Rows
            Dim dr2 As DataRow = dt2.NewRow()
            dr2("รหัสประจำสาร") = dr("IDA")
            dr2("ชื่อสาร") = dr("iowanm")
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
        Response.Charset = "windows-874"
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
        'Dim Source As String = ObjecttoCSV(dt2)
        'Response.Clear()
        'Response.Buffer = True
        'Response.ClearContent()
        'Response.Charset = "windows-874"
        'Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
        'Dim filename As String = ""
        'filename = "Export_" & Date.Now.ToString("ddMMyyyy")
        'Response.AddHeader("content-disposition", "attachment;filename=" & filename & ".xls")
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.ContentType = "application/vnd.ms-excel"

        'Response.Write(Source)
        'Response.End()
        'Else
        alert("ไม่พบข้อมูล")
        'End If
    End Sub
    Public Function ObjecttoCSV(table As DataTable) As String
        Dim result = New StringBuilder()
        For i As Integer = 0 To table.Columns.Count - 1
            result.Append(table.Columns(i).ColumnName)
            result.Append(If(i = table.Columns.Count - 1, vbLf, ","))
        Next

        For Each row As DataRow In table.Rows
            For i As Integer = 0 To table.Columns.Count - 1
                result.Append(row(i).ToString())
                result.Append(If(i = table.Columns.Count - 1, vbLf, ","))
            Next
        Next

        Return result.ToString()
    End Function
End Class