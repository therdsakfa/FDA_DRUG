Imports System.IO
Imports System.Xml.Serialization

Public Class GEN_XML_BC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN

        Dim xml_iow As New LGT_IOW_E
        Dim xml_str As String

        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(TextBox1.Text)
        If xml_str <> "FAIL" Then
            'MODEL.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)

            Dim pname As String = ""
            Dim Path As String = ""
            pname = TextBox1.Text + ".xml"
            Path = "D:\path\XML_BC\"

            Dim objStreamWriter As New StreamWriter(Path & pname)
            Dim x2 As New XmlSerializer(xml_iow.GetType)
            x2.Serialize(objStreamWriter, xml_iow)
            objStreamWriter.Close()


          
            Dim clsds As New ClassDataset

            Response.Clear()
            Response.ContentType = "Application/xml"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & pname)
            Response.BinaryWrite(clsds.UpLoadImageByte(Path & pname)) '"C:\path\PDF_XML_CLASS\"

            Response.Flush()
            Response.Close()
            Response.End()

         
        End If
    End Sub

End Class