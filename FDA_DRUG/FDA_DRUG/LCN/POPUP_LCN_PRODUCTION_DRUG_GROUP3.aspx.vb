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
Public Class POPUP_LCN_PRODUCTION_DRUG_GROUP3
    Inherits System.Web.UI.Page
    Private StrHtmlGenerate As New StringBuilder()
    Private StrExport As New StringBuilder()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ex") <> "" Then
            UC_TABLE_DRUG_GROUP_CHANGE_V2.bind_table_export()
            btn_save.Style.Add("display", "none")
            btn_goto.Style.Add("display", "none")
        Else
            UC_TABLE_DRUG_GROUP_CHANGE_V2.bind_table()
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

                If Request.QueryString("edit") <> "" Then
                    btn_save.Style.Add("display", "block")
                End If
            End If
        Catch ex As Exception

        End Try

        If Not IsPostBack Then
            Dim dao_ih As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
            dao_ih.GetDataby_FKIDA(Request.QueryString("ida"))
            Try
                'rdl_drug_type.DataBind()
                'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
                If dao_ih.fields.DRUG_TYPE = 1 Then
                    cb_drug_type1.Checked = True
                End If

            Catch ex As Exception

            End Try
            Try
                'rdl_drug_type.DataBind()
                'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
                If dao_ih.fields.DRUG_TYPE2 = 1 Then
                    cb_drug_type2.Checked = True
                End If

            Catch ex As Exception

            End Try
            Try
                'rdl_drug_type.DataBind()
                'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
                If dao_ih.fields.DRUG_TYPE23 = 1 Then
                    cb_drug_type3.Checked = True
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_t As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
        dao_t.GetDataby_FKIDA(Request.QueryString("ida"))
        For Each dao_t.fields In dao_t.datas
            dao_t.delete()
        Next

        dao_t = New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
        dao_t.fields.FK_IDA = Request.QueryString("ida")

        If cb_drug_type1.Checked Then
            dao_t.fields.DRUG_TYPE = 1
        Else
            dao_t.fields.DRUG_TYPE = Nothing
            End If
        'dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue

        If cb_drug_type2.Checked Then
                dao_t.fields.DRUG_TYPE2 = 1
            Else
                dao_t.fields.DRUG_TYPE2 = Nothing
            End If
        'dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue

        If cb_drug_type3.Checked Then
                dao_t.fields.DRUG_TYPE23 = 1
            Else
                dao_t.fields.DRUG_TYPE23 = Nothing
            End If
        'dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue

        dao_t.insert()


        UC_TABLE_DRUG_GROUP_CHANGE_V2.save_data()
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
        UC_TABLE_DRUG_GROUP_CHANGE_V2.Page.RenderControl(hw)
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
        If Request.QueryString("edit") <> "" Then
            Response.Redirect("POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD.aspx?ida=" & Request.QueryString("ida") & "&edit=1")
        Else
            Response.Redirect("POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD.aspx?ida=" & Request.QueryString("ida"))
        End If

    End Sub

    Private Sub POPUP_LCN_PRODUCTION_DRUG_GROUP3_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub
End Class