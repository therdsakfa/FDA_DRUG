Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_LCN_DOWNLOAD_DRUG
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

    Sub RunSession()
        Try
            _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

    End Sub

    Public bao_app As New BAO.AppSettings

    Sub insert_TRANSACTION(ByVal PROCESS_ID As Integer)
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer
        'Dim PROCESS_ID As Integer = 1
        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = PROCESS_ID
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()

        down_ID = dao_down.fields.ID

        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()
    End Sub
  
    Private Sub LoadPdf()
       Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    ''' <summary>
    ''' แปลงค่าจากDatabase เป็น XML
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub convert_Database_To_XML(ByVal filename As String)


        
        ' Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_CLS.IDA)

        Dim cls As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, "1", _CLS.PVCODE)
        Dim cls_xml As New CLASS_DALCN
        cls_xml = cls.gen_xml()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub
    'End Sub
    ''' <summary>
    ''' รวม XML เข้าไปที่ PDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF(ByVal path_XML As String, ByVal filename_XML As String, ByVal filename_PDF_TEMPLATE As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = path_XML
        path = path & filename_XML & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & filename_PDF_TEMPLATE & ".pdf") '"C:\path\PDF_TEMPLATE\"
            Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename_XML & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using


        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename= " & filename_XML & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename_XML & ".pdf")) '"C:\path\PDF_XML_CLASS\"
        Response.Write("<script language=javascript>")
        Response.Write("alert('กรุณาตรวจสอบความถูกต้อง');")
        Response.Write("</script>")
        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    Private Function Create_downname() As String
        'pdf.insert_TRANSACTION_DOWNLOAD(1)
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer
        Dim pdftemplate As String = "PDFdalcn"

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = 1
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()

        down_ID = dao_down.fields.ID

        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()
        Dim downname As String = "DA-" & down_ID.ToString()
        convert_Database_To_XML(downname)
        Return downname
    End Function

    'Protected Sub btn_manufacturt2_Click(sender As Object, e As EventArgs) Handles btn_manufacturt2.Click

    '    bao_app.RunAppSettings()
    '    Dim pdftemplate As String = "PDFdalcn"

    '    Dim STATUS As String = 0

    '    Dim downname As String = Create_downname()

    '    Dim cls As New CLS_MAIN_XML
    '    Dim filename As String = ""
    '    filename = cls.XML_DALCN(988, 2, downname)

    '    CreatePDF(filename, pdftemplate)

    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
    'End Sub

    Private Sub CreatePDF(ByVal filename As String, ByVal PDFTEMPLATE As String)


        Dim pdfname As String = ""
        '   Dim un As New .CLS_MAIN_PDF
        PATH_PDF_TEMPLATE = bao_app._PATH_PDF_TEMPLATE
        PATH_PDF_XML_CLASS = bao_app._PATH_PDF_XML_CLASS
        path_XML = bao_app._PATH_XML_CLASS
        pdfname = PDF_CENTER(filename, PDFTEMPLATE)
        _CLS.PDFNAME = pdfname
        Session("CLS") = _CLS
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub


#Region "MAINFUNCTION"

#End Region

    Protected Sub btn_1_Click(sender As Object, e As EventArgs) Handles btn_1.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_1"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_1.pdf", 1)
    End Sub

    Protected Sub btn_2_Click(sender As Object, e As EventArgs) Handles btn_2.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_2"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_2.pdf", 2)
    End Sub

    Protected Sub btn_3_Click(sender As Object, e As EventArgs) Handles btn_3.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_3"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_3.pdf", 3)
    End Sub

    Protected Sub btn_4_Click(sender As Object, e As EventArgs) Handles btn_4.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_4"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_4.pdf", 4)
    End Sub

    Protected Sub btn_5_Click(sender As Object, e As EventArgs) Handles btn_5.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_5"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_5.pdf", 5)
    End Sub

    Protected Sub btn_6_Click(sender As Object, e As EventArgs) Handles btn_6.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_6"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_6.pdf", 6)
    End Sub

    Protected Sub btn_7_Click(sender As Object, e As EventArgs) Handles btn_7.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_7"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_7.pdf", 7)
    End Sub

    Protected Sub btn_8_Click(sender As Object, e As EventArgs) Handles btn_8.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_8"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_8.pdf", 8)
    End Sub

    Protected Sub btn_9_Click(sender As Object, e As EventArgs) Handles btn_9.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_9"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_9.pdf", 9)
    End Sub

    Protected Sub btn_10_Click(sender As Object, e As EventArgs) Handles btn_10.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_10"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_10.pdf", 10)
    End Sub

    Protected Sub btn_11_Click(sender As Object, e As EventArgs) Handles btn_11.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_11"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_11.pdf", 11)
    End Sub

    Protected Sub btn_12_Click(sender As Object, e As EventArgs) Handles btn_12.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_12"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_12.pdf", 12)
    End Sub

    Protected Sub btn_13_Click(sender As Object, e As EventArgs) Handles btn_13.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_13"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_13.pdf", 13)
    End Sub

    'Protected Sub btn_14_Click(sender As Object, e As EventArgs) Handles btn_14.Click
    '    bao_app.RunAppSettings()
    '    Dim pdftemplate As String = "PDFdalcn_14"

    '    Dim STATUS As String = 0

    '    Dim downname As String = Create_downname()

    '    Dim cls As New CLS_MAIN_XML
    '    Dim filename As String = ""
    '    filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

    '    CreatePDF(filename, pdftemplate)

    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)

    'End Sub

    Protected Sub btn_15_Click(sender As Object, e As EventArgs) Handles btn_15.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_15"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_15.pdf", 15)
    End Sub

    Protected Sub btn_16_Click(sender As Object, e As EventArgs) Handles btn_16.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_16"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_16.pdf", 16)
    End Sub

    Protected Sub btn_17_Click(sender As Object, e As EventArgs) Handles btn_17.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_17"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_17.pdf", 17)
    End Sub

    Protected Sub btn_18_Click(sender As Object, e As EventArgs) Handles btn_18.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_18"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_18.pdf", 18)
    End Sub

    Protected Sub btn_19_Click(sender As Object, e As EventArgs) Handles btn_19.Click
        'bao_app.RunAppSettings()
        'Dim pdftemplate As String = "PDFdalcn_19"

        'Dim STATUS As String = 0

        'Dim downname As String = Create_downname()

        'Dim cls As New CLS_MAIN_XML
        'Dim filename As String = ""
        'filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname)

        'CreatePDF(filename, pdftemplate)

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)
        Bind_PDF("PDFdalcn_19.pdf", 19)
    End Sub


    Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String, ByVal process As Integer)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer



        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        'Dim dao As New DAO.clsDBfafdtype
        'dao.Getdata_by_fdtypecd(_CLS.FDTYPECD)

        '    _CLS.FATYPE = FATYPE

        Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)



        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
        Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID)

        convert_Database_To_XML("DA-" & down_ID.ToString())
        convert_XML_To_PDF(file_PDF, file_xml, file_template)


        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
End Class