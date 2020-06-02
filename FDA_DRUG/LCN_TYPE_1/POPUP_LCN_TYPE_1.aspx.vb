Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization

Public Class WebForm2
    Inherits System.Web.UI.Page
    Private _lcnsid As Integer
    Private _thanm As String
    Private _ID As String
    Private _PATH_PDF_TEMPLATE As String
    Private _PATH_XML_CLASS As String
    Private _PATH_PDF_XML_CLASS As String
    Private _PATH_PDF_TRADER As String
    Private _PATH_XML_TRADER As String
    Sub RunAppSettings()
        _PATH_PDF_TEMPLATE = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")
        _PATH_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")
        _PATH_PDF_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")
        _PATH_PDF_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")
        _PATH_XML_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")
    End Sub
    Sub RunSession()
        _lcnsid = Integer.Parse(Session("strlcnsid").ToString())
        _thanm = Session("strthanm").ToString()
        _ID = Session("ID")
    End Sub

    Sub RunID()

        Dim PDF_System As New PDF_System
        Dim intcomno As Integer
        PDF_System.insert_TRANSESSION_UPLOAD(2)
        intcomno = PDF_System.Run_TRANSESSIONID("ID", "TRANSESSION_UPLOAD")
        Session("ID") = intcomno.ToString()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        RunAppSettings()
        If Not IsPostBack Then
            RunID()
        End If
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        If FileUpload1.HasFile Then

            FileUpload1.SaveAs(_PATH_PDF_TRADER & FileUpload1.PostedFile.FileName)
            convert_PDF_To_XML(_PATH_PDF_TRADER & FileUpload1.PostedFile.FileName)
            insrt_to_database()
            alert("เลขTransession คือ DA-02-" + _ID)

        Else

        End If
    End Sub


    Private Sub convert_PDF_To_XML(ByVal FileName As String)
        Dim ob As String
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(FileName)
        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml

        Dim doc As New XmlDocument
        doc.LoadXml(ob)
        doc.Save(_PATH_XML_TRADER & "DA-02-" + _ID + ".xml")
    End Sub


    ''' <summary>
    ''' ดึงค่า PDF เข้าไปที่ XML_TRADER
    ''' </summary>
    ''' <remarks></remarks>
    Private Overloads Function convert_PDF_TRADER_To_XML_TRADER(ByVal bytepdf As Byte()) As String
        Dim ob As String
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(bytepdf)
        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml
        Return ob

    End Function



    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub insrt_to_database()

        Dim objStreamReader As New StreamReader(_PATH_XML_TRADER & "DA-02-" + _ID + ".xml")

        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)

        p2 = x.Deserialize(objStreamReader)

        objStreamReader.Close()

        Dim dao As New DAO.DBdarqt
        ' Dim dao_darqtphr As New DAO.DBdarqtphr
        ' Dim bao As New BAO.ClsDBSqlCommand
        ' bao.FAGencomno()

        'ฟิล
        dao.datas = p2.dalcn
        dao.fields.rcvno = _ID
        'dao.fields.rcvdate = p2.dalcn.rcvdate
        'dao.fields.bsnage = p2.dalcn.bsnage
        'dao.fields.bsnid = p2.dalcn.bsnid
        'dao.fields.lctcd = p2.dalcn.lctcd
        'dao.fields.lctnmcd = p2.dalcn.lctnmcd
        'dao.fields.jpctpcd = p2.dalcn.jpctpcd
        'dao.fields.cnsdcd = p2.dalcn.cnsdcd
        'dao.fields.cscd = p2.dalcn.cscd
        '' dao.fields.cnsddate = p2.cnsddate
        ''dao.fields.phrcd = p2.phrcd
        'dao.fields.opentime = p2.opentime
        dao.insert()

        'dao_darqtphr.fields.rcvno = _ID
        'dao_darqtphr.fields.phrcd = p2.phrcd
        'dao_darqtphr.fields.phrno = p2.phrno
        'dao_darqtphr.fields.opentime = p2.opentime_darqtphr
        ' dao_darqtphr.insert()


    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');self.close();</script> ")
    End Sub
    ''' <summary>
    ''' เปลี่ยนสถานะของTransessionเพื่อระบุว่ามีการอัพโหลดแล้ว
    ''' </summary>
    ''' <param name="TRANSESSION_ID"></param>
    ''' <remarks></remarks>
    Private Sub update_Transession(ByVal TRANSESSION_ID As Integer)
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
    Function chk_Transession(ByVal TRANSESSION_ID As Integer) As Boolean
        Dim chk As Boolean = False
        Dim dao As New DAO_CPN.clsDBTRANSESSION_UPLOAD
        dao.GetDataby_ID(TRANSESSION_ID)
        If dao.fields.STATUS = "0" Then
            chk = True
        End If
        Return chk
    End Function

End Class