Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_EDIT_TABEAN_YA_DOWNLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    ' Private _NYM As String = ""
    Private _IDA As String = ""
    ' Private _fk_ida As String = ""
    Sub runQuery()
        '   _NYM = Request.QueryString("type")
        _IDA = Request.QueryString("IDA") 'test
        '_IDA = "631" 'test
        '   _fk_ida = Request.QueryString("fk_ida")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
    End Sub

    Protected Sub btn_auto_Click(sender As Object, e As EventArgs) Handles btn_auto.Click
        Bind_PDF("PDF_DRUG_Y5_DROPDOWN.pdf", "0")
    End Sub

    Protected Sub btn_manual_Click(sender As Object, e As EventArgs) Handles btn_manual.Click
        Bind_PDF("PDF_DRUG_Y5_TEXTBOX.pdf", "1")
    End Sub
    Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String, ByRef AUTO_ID As String)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer



        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = 355
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
        Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID) 'test
        ' Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & "DA-3227.xml" 'test

        convert_Database_To_XML("DA-" & down_ID.ToString(), AUTO_ID)
        convert_XML_To_PDF(file_PDF, file_xml, file_template)
        'LOAD_XML_PDF(file_xml, file_template, 355, file_PDF)

        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)

        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML(ByVal filename As String, ByVal AUTO_ID As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        Dim cls_CER As New CLASS_GEN_XML.EDIT_REQUEST(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, dao.fields.lctcd, dao.fields.IDA, AUTO_ID)
        Dim cls_xml As New CLASS_EDIT_REQUEST
        cls_xml = cls_CER.gen_xml_EDIT_REQUEST()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
End Class