Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.Web

Public Class PDF_System

#Region "ดาวโหลด"
    ''' <summary>
    ''' แปลงข้อมูลเป็น XML
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub convert_Database_To_XML(ByVal cls As CLASS_DARQT, ByVal path As String)

        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls.GetType)
        x.Serialize(objStreamWriter, cls)
        objStreamWriter.Close()

    End Sub

    

    ''' <summary>
    ''' รวม XML เข้ากับไฟล์ PDF
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub fusion_XML_To_PDF(ByVal path_XML_CLASS As String, ByVal path_PDF_TEMPLATE As String, ByVal path_PDF_XML As String)
        ' Dim path As String = "C:\path\XML_CLASS\"
        'path = path & "PDFfreg.xml"
        Using pdfReader__1 = New PdfReader(path_PDF_TEMPLATE)
            Using outputStream = New FileStream(path_PDF_XML, FileMode.Create, FileAccess.Write)
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path_XML_CLASS)
                End Using
            End Using
        End Using

    End Sub

#End Region


#Region "อัพโหลด"
    ''' <summary>
    ''' แปลงค่าจาก PDF เป็น XML
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <remarks></remarks>
    ''' 
    Public Sub convert_PDF_To_XML(ByVal path_XML_TRADER As String, ByVal FileName As String, ByVal ID As String)
        Dim ob As String
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(FileName)
        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml

        Dim doc As New XmlDocument
        doc.LoadXml(ob)
        doc.Save(path_XML_TRADER + FileName + ID + ".xml")
    End Sub
    ''' <summary>
    ''' สร้างเลข ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RunID(ByVal colum As String, ByVal table As String) As String
        Dim ID As String
        Dim bao As New BAO.ClsDBSqlCommand
        bao.FAGenID(colum, table)
        Dim intID As Integer
        intID = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1
        ID = intID.ToString()

        Return ID
    End Function
    ''' <summary>
    ''' สร้างเลข TRANSESSION ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Run_TRANSESSIONID(ByVal colum As String, ByVal table As String) As String
        Dim ID As String
        Dim bao As New BAO.ClsDBSqlCommand
        bao.FAGenID_CPN(colum, table)
        Dim intID As Integer
        intID = Integer.Parse(bao.dt.Rows(0)(0).ToString())
        ID = intID.ToString()

        Return ID
    End Function

    ''' <summary>
    ''' นำค่า XML มาinsert ลง DB
    ''' </summary>
    ''' <remarks>ใช้ XML_TRADER</remarks>
    Private Sub insrt_to_database(ByVal path_XML_TRADER As String, ByVal FileName As String, ByVal ID As String)

        Dim objStreamReader As New StreamReader(path_XML_TRADER + FileName + ID + ".xml")
        Dim p2 As New CLASS_DARQT
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()

    End Sub
#End Region


#Region "Transession"

    ''' <summary>
    ''' เพิ่ม Transession เพื่อนำ Transession_ID มาใช้กับ XML
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub insert_TRANSESSION_DOWNLOAD(ByVal PROCESS_ID As Integer)
        Dim dao As New DAO_CPN.clsDBTRANSESSION_DOWNLOAD
        dao.fields.STATUS = "0"
        dao.fields.PROCESS_ID = PROCESS_ID
        dao.fields.DOWNLOAD_DATE = Date.Now()
        dao.insert()
    End Sub
    ''' <summary>
    ''' เพิ่ม Transession เพื่อนำ Transession_ID มาใช้กับ XML
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub insert_TRANSESSION_UPLOAD(ByVal PROCESS_ID As Integer)
        Dim dao As New DAO_CPN.clsDBTRANSESSION_UPLOAD
        dao.fields.STATUS = "0"
        dao.fields.PROCESS_ID = PROCESS_ID
        dao.fields.UPLOAD_DATE = Date.Now()
        dao.insert()
    End Sub
    ''' <summary>
    ''' เปลี่ยนสถานะของTransessionเพื่อระบุว่ามีการอัพโหลดแล้ว
    ''' </summary>
    ''' <param name="TRANSESSION_ID"></param>
    ''' <remarks></remarks>
    Public Sub update_TRANSESSION_UPLOAD(ByVal TRANSESSION_ID As Integer)
        Dim dao As New DAO_CPN.clsDBTRANSESSION_UPLOAD
        dao.GetDataby_ID(TRANSESSION_ID)
        dao.fields.STATUS = "1"
        dao.update()
    End Sub
    ''' <summary>
    ''' ตรวจสอบสถานะของTransession(True ยังไม่มีการอัพโหลด,False มีการอัพโหลดแล้ว)
    ''' </summary>
    ''' <param name="TRANSESSION_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function chk_TRANSESSION_UPLOAD(ByVal TRANSESSION_ID As Integer) As Boolean
        Dim chk As Boolean = False
        Dim dao As New DAO_CPN.clsDBTRANSESSION_UPLOAD
        dao.GetDataby_ID(TRANSESSION_ID)
        If dao.fields.STATUS = "0" Then
            chk = True
        End If
        Return chk
    End Function

#End Region






End Class
