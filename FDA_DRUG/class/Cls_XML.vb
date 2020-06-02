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
End Class
