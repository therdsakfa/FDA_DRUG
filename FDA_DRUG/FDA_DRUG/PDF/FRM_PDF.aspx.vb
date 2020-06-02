Imports System.Net
Imports System.IO
Imports iTextSharp.text.pdf
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class WebForm1
    Inherits System.Web.UI.Page
    Private _FileName As String
    Sub runQuery()
        _FileName = Request.QueryString("FileName")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        Try
            load_pdf(_FileName)
        Catch ex As Exception
            If ex.Message.Contains("another") Then
                Response.Write("<script type='text/javascript'>alert('ขออภัย ขณะนี้เจ้าหน้าที่กำลังเปิด pdf นี้อยู่');parent.close_modal();</script> ")
            Else
                Response.Write("<script type='text/javascript'>alert('เกิดข้อผิดพลาดบางประการ');parent.close_modal();</script> ")
            End If
        End Try

    End Sub

    'Private Sub load_pdf(ByVal FilePath As String)
    '    Response.ContentType = "Application/pdf"
    '    Response.WriteFile(FilePath)
    '    Response.End()
    'End Sub

    Private Sub load_pdf(ByVal FilePath As String)


        '  Response.ContentType = "Application/pdf"

        Dim clsds As New ClassDataset

        Dim bb As Byte()
        bb = clsds.UpLoadImageByte(FilePath)

        Dim ws_F As New WS_FLATTEN.WS_FLATTEN
        Dim b_o As Byte()
        'If Request.QueryString("status") = "1" Then
        '    b_o = ws_F.PDF_DIGITAL_SIGN(bb)
        'Else
        b_o = ws_F.FlattenPDF_DIGITAL(bb)
        'End If

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", b_o.Length.ToString())
        Response.BinaryWrite(b_o)



        'Response.Clear()
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment;filename=abc.pdf")

        'Response.BinaryWrite(clsds.UpLoadImageByte(FilePath))

        'Response.Flush()

        Response.End()
    End Sub


    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function
End Class