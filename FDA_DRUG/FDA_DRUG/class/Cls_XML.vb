Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Cls_XML
    ''' <summary>
    ''' อ่าน ค่า XML 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadXml(ByVal path As String) As String
        Dim StrData As String
        Dim objXMLDoc As New System.Xml.XmlDocument()
        objXMLDoc.Load(path) 'xml data I need to send
        StrData = objXMLDoc.OuterXml
        Return StrData
    End Function



    Public doc As New System.Xml.XmlDocument


    ''' <summary>
    ''' แปลงค่า Content XML
    ''' </summary>
    ''' <param name="content"></param>
    ''' <remarks></remarks>
    Public Sub ReadData(ByVal content As String)
        Dim xmltxt As String = ""
        Dim xmlStream As New System.IO.MemoryStream()
        '  Dim doc As New System.Xml.XmlDocument
        doc.LoadXml(content)

        'Dim item_P_ID As String = ""
        'item_P_ID = Get_Value_Node(doc, "Txt_Remark")
        'Label1.Text = item_P_ID

        'xmltxt = GetValue_XML(doc, "Information")
    End Sub





    ''' <summary>
    ''' ดึงค่า Value จาก XML ออกมาตัวเดียว
    ''' </summary>
    ''' <param name="TagName">ชื่อ XML</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Value_XML(ByVal TagName As String) As String
        Dim value As String = ""
        Dim item_Node As System.Xml.XmlNodeList = doc.GetElementsByTagName(TagName)
        For Each item As System.Xml.XmlElement In item_Node
            value = item.InnerText
        Next
        Return value
    End Function


    ''' <summary>
    ''' ดึงค่า XML ใน Tag ทั้งหมด
    ''' </summary>
    ''' <param name="Element">Tag XML</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_ListValue_XML(ByVal Element As String) As String

        Dim items As System.Xml.XmlNodeList = doc.GetElementsByTagName(Element)
        Dim temp As String = ""
        Dim name As String = ""
        For Each item As System.Xml.XmlElement In items
            For i As Integer = 0 To item.ChildNodes.Count - 1
                If temp = "" Then
                    temp = item.ChildNodes(i).InnerText
                Else
                    temp = temp & "^" & item.ChildNodes(i).InnerText
                End If
            Next
        Next
        Return temp
    End Function

    Public Function CLASS_TO_XMLTYPE(ByVal cls_xml As Object)
        Dim mem As New MemoryStream()
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim x As New XmlSerializer(cls_xml.GetType())
        Dim abc As String = ""
        Using writer As XmlWriter = XmlWriter.Create(mem, settings)
            x.Serialize(writer, cls_xml)
            writer.Flush()
            writer.Close()
        End Using
        mem.Position = 0
        Dim sr As New StreamReader(mem)
        Dim xml As String = sr.ReadToEnd
        '----- insert  xml file to parth
        'Dim XML_TRADER As String = ""
        'XML_TRADER = _PATH_FILE & "XML_LOCATION\" & NAME_XML("MDC_MC_XML", 30001, chk_type, con_year, DAO.fields.IDA)   'ทำการกำหนดไฟล์ XML ว่าจะทำการบันทึกลงที่ไหน
        'Dim path As String = XML_TRADER
        'Dim objStreamWriter As New StreamWriter(path)
        'Dim xx As New XmlSerializer(cls_xml.GetType)
        'xx.Serialize(objStreamWriter, cls_xml)
        'objStreamWriter.Close()
        '-------
        Return XElement.Parse(xml)
    End Function
    Function ConvertXML_TO_CLASS(Of T As Class)(ByVal xml As XElement)
        Dim c As T = Nothing
        Try
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            Dim reader = xml.CreateReader
            c = TryCast(serializer.Deserialize(reader), T)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return c
    End Function
End Class
