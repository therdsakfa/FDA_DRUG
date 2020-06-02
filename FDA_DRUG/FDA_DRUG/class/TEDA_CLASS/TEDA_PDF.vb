Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO

Module TEDA_PDF

#Region "LIST_CLASS_XML"

    Private _XML_LOCATIONs As CLS_LOCATION
    Public Property XML_LOCATIONs() As CLS_LOCATION
        Get
            Return _XML_LOCATIONs
        End Get
        Set(ByVal value As CLS_LOCATION)
            _XML_LOCATIONs = value
        End Set
    End Property

    Private _XML_TRANFER_LOCATIONs As XML_TRANFER_LOCATION
    Public Property XML_TRANFER_LOCATIONs() As XML_TRANFER_LOCATION
        Get
            Return _XML_TRANFER_LOCATIONs
        End Get
        Set(ByVal value As XML_TRANFER_LOCATION)
            _XML_TRANFER_LOCATIONs = value
        End Set
    End Property
    Private _XML_DRUGs As XML_DRUG
    Public Property XML_DRUGs() As XML_DRUG
        Get
            Return _XML_DRUGs
        End Get
        Set(ByVal value As XML_DRUG)
            _XML_DRUGs = value
        End Set
    End Property

#End Region



#Region "TEDA FORM"


    Public Function Checkfile(ByVal Path As String) As Boolean
        Dim check As Boolean = System.IO.File.Exists(Path)
        Return check
    End Function


    ' ''' <summary>
    ' ''' สำหรับ ผปก  Upload Pdf แล้ว แปลงเป็น XML
    ' ''' </summary>
    ' ''' <param name="PATH_PDF_TRADER"></param>
    ' ''' <param name="PATH_XML_TRADER"></param>
    ' ''' <remarks></remarks>
    'Public Sub convert_PDF_To_XML(ByVal PATH_PDF_TRADER As String, ByVal PATH_XML_TRADER As String)

    '    Dim outputStream As New System.IO.MemoryStream()
    '    Dim reader As New PdfReader(PATH_PDF_TRADER)
    '    Dim doc As New XmlDocument
    '    Dim ob As String
    '    ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml
    '    doc.LoadXml(ob)
    '    doc.Save(PATH_XML_TRADER) '"C:\path\XML_TRADER\"

    'End Sub



    ' ''' <summary>
    ' ''' นำข้อมูล XML เข้า PDFTEMPLATE แล้วทำการสร้าง PDF ขึ้นมาใหม่
    ' ''' </summary>
    ' ''' <param name="PATH_PDF_XML"></param>
    ' ''' <param name="PATH_XML_TRADER"></param>
    ' ''' <param name="PATH_PDF_TEMPLATE"></param>
    ' ''' <remarks></remarks>
    'Public Sub convert_XML_To_PDF(ByVal PATH_PDF_XML As String, ByVal PATH_XML_TRADER As String, ByVal PATH_PDF_TEMPLATE As String)
    '    Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) '"C:\path\PDF_TEMPLATE\"
    '        Using outputStream = New FileStream(PATH_PDF_XML, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(PATH_XML_TRADER)
    '            End Using
    '        End Using
    '    End Using

    'End Sub


    ' ''' <summary>
    ' ''' 
    ' ''' </summary>
    ' ''' <param name="PATH_XML">ที่อยู่ XML ที่ต้องใช้</param>
    ' ''' <param name="PATH_PDF_TEMPLATE">ที่อยู่ PDF TEMPLATE ที่ต้องใช้</param>
    ' ''' <param name="PROSESS_ID">รหัส Process</param>
    ' ''' <param name="PATH_PDF_OUTPUT">PDF ที่ต้องออกมาใช้งาน</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function LOAD_XML_PDF(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, ByVal PROSESS_ID As String, PATH_PDF_OUTPUT As String) As String

    '    If Checkfile(PATH_PDF_OUTPUT) = False Then
    '        'ตรวจสอบว่ามี XML มั้ย
    '        If Checkfile(PATH_XML) = False Then
    '            If PROSESS_ID = 1 Then 'ใบขอต่ออายุ
    '                Dim cls_xml As New CLASS_RENEW.PDF
    '                cls_xml.convert_Database_To_XML_Exten(PATH_XML, xml_renew)
    '            ElseIf PROSESS_ID = 2 Then 'ใบสั่งชำระ
    '                Dim cls_xml As New CLASS_RENEW.PDF
    '                cls_xml.convert_Database_To_XML_Payment(PATH_XML, xml_fee)
    '            ElseIf PROSESS_ID = 3 Then 'ใบอนุญาตต่ออายุ
    '                Dim cls_xml As New CLASS_RENEW.PDF
    '                cls_xml.convert_Database_To_XML_Approve(PATH_XML, xml_appr)
    '            ElseIf PROSESS_ID = 4 Then ' ใบอนุญาต NLLCN
    '                Dim cls_xml As New Gen_XML.GEN_XML_NLLCN
    '                cls_xml.CREATE_XML_NLLCNs(PATH_XML, XML_NLLCNs)
    '            ElseIf PROSESS_ID = 5 Then ' ใบทะเบียน ยาเสพติด
    '                Dim cls_xml As New Gen_XML.GEN_XML_NRRGT
    '                cls_xml.CREATE_XML_NRRGTs(PATH_XML, XML_NRRGTs)
    '            ElseIf PROSESS_ID = 6 Then ' อนุสัญญา

    '            ElseIf PROSESS_ID = 7 Then ' สถานที่จำลอง
    '                Dim cls_xml As New Gen_XML.GEN_XML_NCT_LCT_ADDR
    '                cls_xml.CREATE_XML_NCT_LCTADDR(PATH_XML, XML_NCT_LCTADDRs)

    '            ElseIf PROSESS_ID = 99 Then ' สถานที่จำลอง
    '                Dim cls_xml As New Gen_XML.GEN_XML_NCT_LCT_ADDR
    '                cls_xml.CREATE_XML_NCT_LCTADDR(PATH_XML, XML_NCT_LCTADDRs)

    '            ElseIf PROSESS_ID = 98 Then 'สถานที่เก็บ
    '                Dim cls_xml As New Gen_XML.GEN_XML_NCT_LCT_ADDR
    '                cls_xml.CREATE_XML_NCT_LCTADDR(PATH_XML, XML_NCT_LCTADDRs)
    '            ElseIf PROSESS_ID = 14100051 Or PROSESS_ID = 14100052 Or PROSESS_ID = 14100053 Or PROSESS_ID = 14100054 Or PROSESS_ID = 14100055 Or PROSESS_ID = 14100056 Then ' สถานที่จำลอง
    '                Dim cls_xml As New Gen_XML.GEN_XML_LICENSE_LOCATION
    '                cls_xml.CREATE_XML_LICENSE_LOCATION(PATH_XML, XML_LICENSE_LOCATIONs)
    '            ElseIf PROSESS_ID = 14200051 Or PROSESS_ID = 14200052 Or PROSESS_ID = 14200053 Or PROSESS_ID = 14200054 Or PROSESS_ID = 14200055 Or PROSESS_ID = 14200056 Then ' สถานที่จำลอง
    '                Dim cls_xml As New Gen_XML.GEN_XML_LICENSE_LOCATION
    '                cls_xml.CREATE_XML_LICENSE_LOCATION(PATH_XML, XML_LICENSE_LOCATIONs)
    '            ElseIf PROSESS_ID = 14300051 Or PROSESS_ID = 14300052 Or PROSESS_ID = 14300053 Or PROSESS_ID = 14300054 Or PROSESS_ID = 14300055 Or PROSESS_ID = 14300056 Then ' สถานที่จำลอง
    '                Dim cls_xml As New Gen_XML.GEN_XML_LICENSE_LOCATION
    '                cls_xml.CREATE_XML_LICENSE_LOCATION(PATH_XML, XML_LICENSE_LOCATIONs)
    '            ElseIf PROSESS_ID = 14400051 Or PROSESS_ID = 14400052 Or PROSESS_ID = 14400053 Or PROSESS_ID = 14400054 Or PROSESS_ID = 14500055 Or PROSESS_ID = 14600056 Then ' สถานที่จำลอง
    '                Dim cls_xml As New Gen_XML.GEN_XML_LICENSE_LOCATION
    '                cls_xml.CREATE_XML_LICENSE_LOCATION(PATH_XML, XML_LICENSE_LOCATIONs)
    '            End If
    '        End If
    '    'ตรวจสอบว่ามี PDF มั้ย
    '    If Checkfile(PATH_PDF_TEMPLATE) = False Then
    '        '
    '    End If
    '    Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
    '        Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
    '            End Using
    '        End Using
    '    End Using
    '    Else

    '    End If

    '    Return PATH_PDF_OUTPUT
    'End Function
#End Region
End Module
