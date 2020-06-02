Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports iTextSharp.text
Imports iTextSharp.text.html
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports System.util
Imports System.Net
Imports System.Xml
Public Class POPUP_LCN_PRODUCTION_DRUG_GROUP2
    Inherits System.Web.UI.Page
    Private StrHtmlGenerate As New StringBuilder()
    Private StrExport As New StringBuilder()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ex") <> "" Then
            UC_TABLE_DRUG_GROUP_CHANGE1.bind_table_export()
            btn_save.Style.Add("display", "none")
            btn_goto.Style.Add("display", "none")
        Else
            UC_TABLE_DRUG_GROUP_CHANGE1.bind_table()
            btn_Export.Style.Add("display", "none")
        End If
        '
        If Request.QueryString("h") <> "" Then
            btn_back.Style.Add("display", "block")
        Else
            btn_back.Style.Add("display", "none")
        End If
        Try
            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(Request.QueryString("ida"))
                If dao.fields.STATUS_ID > 1 Then
                    btn_save.Style.Add("display", "none")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        UC_TABLE_DRUG_GROUP_CHANGE1.save_data()
        'UC_TABLE_DRUG_GROUP_CHANGE.bind_table()
        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        'Using reader As New StreamReader(Server.MapPath("~") + "/LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx")
        '    Dim line As [String] = reader.ReadToEnd()
        '    Text2PDF(line)
        'End Using
        ' Read html file to a string
        ' WebpageToPdf()

        ' UC_TABLE_DRUG_GROUP_CHANGE1.render_pdf()
        ' getPDF()
        ' WebpageToPdf()
        'sss()
        Export_Word_Work()

    End Sub
    Protected Sub htmltoword()
        Response.Clear()

        Response.Buffer = True

        Response.ContentType = "application/msword"
        Dim stringWriter As New StringWriter()
        Dim htmlTextWriter As New HtmlTextWriter(stringWriter)

        Me.RenderControl(htmlTextWriter)
        Response.Write(stringWriter.ToString())

        Response.[End]()
    End Sub
    Sub WebpageToPdf()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=Receipt_" & Session("InvoNo") & ".pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        pnlPerson.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        Dim msOutput As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, msOutput)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Dim filebytes As Byte() = msOutput.ToArray()
        Dim path As String = Server.MapPath("~/PDF/mypdf.pdf")
        File.WriteAllBytes(path, filebytes)
        Response.BinaryWrite(filebytes)
        Response.End()
    End Sub
    Sub getPDF()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=ConvertedPDF.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        ' Me.Page.RenderControl(hw)
        UC_TABLE_DRUG_GROUP_CHANGE1.Page.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.[End]()
    End Sub
    Sub sss()
        StrExport.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'><head><title>Time</title>")
        StrExport.Append("<body lang=th-TH style='mso-element:header' id=h1><span style='mso--code:DATE'></span><div class=Section1>")
        StrExport.Append("<DIV  style='font-size:12px;'>")
        StrExport.Append(ss2s.InnerText)
        StrExport.Append("</div></body></html>")
        Dim strFile As String = "StudentInformations_CODESCRATCHER.xls"
        Dim strcontentType As String = "application/excel"
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = "utf-8"
        Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)

        Response.BufferOutput = True
        Response.ContentType = strcontentType
        Response.AddHeader("Content-Disposition", Convert.ToString("attachment; filename=") & strFile)
        Response.Write(StrExport.ToString())
        Response.Flush()
        Response.Close()
        Response.[End]()
    End Sub
    Sub Export_Word_Work()
        Response.AddHeader("content-disposition", "attachment;filename=Export.doc")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.word"
        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
        ' Create a form to contain the grid
        Dim frm As New HtmlForm()
        pnlPerson.Parent.Controls.Add(frm)
        frm.Style.Add("font-family", "Angsana New")
        frm.Attributes("runat") = "server"
        frm.Controls.Add(pnlPerson)
        frm.RenderControl(htmlWrite)
        'GridView1.RenderControl(htw);
        Response.Write(stringWrite.ToString())
        Response.[End]()
    End Sub

    Private Sub btn_goto_Click(sender As Object, e As EventArgs) Handles btn_goto.Click
        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&ex=1"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.location='" & uri & "';", True)
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("POPUP_LCN_PRODUCTION_DRUG_GROUP2.aspx?ida=" & Request.QueryString("ida"))
    End Sub
End Class