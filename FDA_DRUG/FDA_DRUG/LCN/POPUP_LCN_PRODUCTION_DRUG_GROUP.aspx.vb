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
Public Class POPUP_LCN_PRODUCTION_DRUG_GROUP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UC_TABLE_DRUG_GROUP_CHANGE1.bind_table()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Using reader As New StreamReader(Server.MapPath("~") + "/LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx")
        '    Dim line As [String] = reader.ReadToEnd()
        '    Text2PDF(line)
        'End Using
        ' Read html file to a string
        'WebpageToPdf()
        'getPDF()
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
   

End Class