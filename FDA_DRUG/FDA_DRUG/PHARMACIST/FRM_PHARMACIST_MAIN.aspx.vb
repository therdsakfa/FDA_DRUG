Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class WebForm2
    Inherits System.Web.UI.Page


    Private _CLS As New CLS_SESSION
    Private _CITIZEN_ID As String
    Public bao_app As New BAO.AppSettings
    Sub RunSession()
        Try
            _CLS = Session("CLS_PHR")
            _CITIZEN_ID = _CLS.CITIZEN_ID
        Catch ex As Exception
            ' Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_GV_lcnno()
        End If
    End Sub
    Sub load_GV_lcnno()
        Dim bao As New BAO.ClsDBSqlcommand
        ' bao.GetData_dalcn_by_lcnsid(_CLS.LCNSID_CUSTOMER) 'เปลี่ยนเป็น SP join PHR และwhere PHR
        bao.SP_DALCN_PHR_BY_PHR_CTZNO(_CITIZEN_ID)
        GV_lcnno.DataSource = bao.dt
        GV_lcnno.DataBind()
    End Sub
    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("PHR_IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_TR As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        If e.CommandName = "down" Then

            Bind_PDF("PDFdalcn_14.pdf", str_ID)
            'dao.GetDataby_IDA(str_ID)
            'Create_downname()
            'XML_TO_PDF()
            ' convert_Database_To_XML("da-001")

            'Dim tr_id As Integer = 0
            'Try
            '    tr_id = dao.fields.TRANSECTION_ID_UPLOAD
            'Catch ex As Exception

            'End Try

        ElseIf e.CommandName = "up" Then
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
            dao_TR.GetDataby_IDA(dao.fields.TR_ID)
            '_CLS.LCNNO = dao_lcn.fields.lcnno.ToString()
            '_CLS.LCNSID_CUSTOMER = dao_lcn.fields.lcnsid.ToString()
            '_CLS.PVCODE = dao_lcn.fields.pvncd.ToString()
            Session("CLS") = _CLS
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_PHARMACIST_UPLOAD.aspx?lcnno=" & dao_lcn.fields.lcnno.ToString() & "&lcnsid=" & dao_lcn.fields.lcnsid.ToString() & "&IDA=" & str_ID & "&FK_IDA=" & dao.fields.FK_IDA & "&CITIZEN_ID=" & _CITIZEN_ID & "&PROCESS_ID=" & dao_TR.fields.PROCESS_ID & "');", True)

            '  Response.Redirect("../MAIN/FRM_NEWS.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&IDA=" & str_ID & "&fk_ida=" & str_ID)

        End If
    End Sub

    Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String, ByVal IDA As Integer)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer



        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = 14
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()


        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(14, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml, IDA)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)

        'Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)

        'Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
        'Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID)

        'convert_Database_To_XML("DA-" & down_ID.ToString(), IDA)
        'convert_XML_To_PDF(file_PDF, file_xml, file_template)

        '_CLS.FILENAME_PDF = file_PDF
        '_CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        'Session("CLS") = _CLS
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
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
    Private Sub XML_TO_PDF(ByVal IDA As Integer)
        bao_app.RunAppSettings()
        Dim pdftemplate As String = "PDFdalcn_14"

        Dim STATUS As String = 0

        Dim downname As String = Create_downname(IDA)

        Dim cls As New CLS_MAIN_XML
        Dim filename As String = ""
        filename = cls.XML_DALCN(_CLS.LCNSID_CUSTOMER, 2, downname) 'test 908 เป็น _CLS.LCNSID_CUSTOMER

        CreatePDF(filename, pdftemplate)

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "loadsuccess();", True)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub
    Private Sub LoadPdf()
        '   Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename= " & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Write("<script language=javascript>")
        Response.Write("alert('กรุณาตรวจสอบความถูกต้อง');")
        Response.Write("</script>")
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub


    Private Function Create_downname(ByVal IDA As Integer) As String
        'pdf.insert_TRANSACTION_DOWNLOAD(1)
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer
        Dim pdftemplate As String = "PDFdalcn_14"

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = 1
        '   dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        '   dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()

        down_ID = dao_down.fields.ID

        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()
        Dim downname As String = "DA-" & down_ID.ToString()
        convert_Database_To_XML(downname, IDA)
        Return downname
    End Function
    Private Sub convert_Database_To_XML(ByVal filename As String, ByVal IDA As Integer)



        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
        Dim dao_syslctnm As New DAO_CPN.clsDBsyslctnm
        Dim dao_syslctaddr As New DAO_CPN.clsDBsyslctaddr
        '  dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
        ' dao_syslcnsid.GetDataby_lcnsid(Integer.Parse(_CLS.LCNSID_CUSTOMER))
        ' dao_syslcnsnm.GetDataby_lcnsid(Integer.Parse(_CLS.LCNSID_CUSTOMER))

        Dim cls As New CLASS_GEN_XML.PHARMACIST(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao.fields.PHR_IDA)
        Dim cls_xml As New CLASS_PHARMACIST
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


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
    End Sub
End Class