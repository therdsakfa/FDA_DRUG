Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_DRUG_PROJECT_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _FK_IDA As String = ""
    Private _process As String = ""
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _FK_IDA = Request.QueryString("fk_ida")
        _process = Request.QueryString("process")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
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
        RunSession()
        load_lcnno()
        runQuery()
        If Not IsPostBack Then
            load_GV_data()
        End If
    End Sub
    Sub load_lcnno()
        'lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Sub load_GV_data()
        Dim bao As New BAO.ClsDBSqlcommand
        'นยม. 1
        bao.SP_DRUG_PROJECT_BY_IDA(_FK_IDA)
        GV_data.DataSource = bao.dt
        GV_data.DataBind()
    End Sub
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF()
    End Sub
    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_DRUG_PROJECT_UPLOAD.aspx?lct_ida=" & _lct_ida & "&lcn_ida=" & _lcn_ida & "&process=" & _process & "');", True)

    End Sub
    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer


        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)

        convert_Database_To_XML(file_xml)
        convert_XML_To_PDF(file_PDF, file_xml, file_template)

        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    'Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String)
    '    Dim bao_app As New BAO.AppSettings
    '    bao_app.RunAppSettings()

    '    Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
    '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    Dim down_ID As Integer



    '    Dim STATUS As String = 0
    '    Dim DOWNLOAD_DATE As Date = Date.Now()
    '    dao_down.fields.PROCESS_ID = _process
    '    dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
    '    dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '    dao_down.fields.STATUS = STATUS
    '    dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
    '    dao_down.insert()
    '    down_ID = dao_down.fields.ID
    '    dao_up.fields.DOWNLOAD_ID = down_ID
    '    dao_up.insert()

    '    'Dim dao As New DAO.clsDBfafdtype
    '    'dao.Getdata_by_fdtypecd(_CLS.FDTYPECD)

    '    '    _CLS.FATYPE = FATYPE

    '    Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)



    '    Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
    '    Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID)

    '    convert_Database_To_XML("DA-" & down_ID.ToString())
    '    convert_XML_To_PDF(file_PDF, file_xml, file_template)

    '    _CLS.FILENAME_PDF = file_PDF
    '    _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
    '    Session("CLS") = _CLS
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    'End Sub
    Private Sub convert_Database_To_XML(ByVal path As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)

        Dim cls_CER As New CLASS_GEN_XML.DRUG_PROJECT(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, IIf(IsDBNull(dao.fields.lcntpcd), "", dao.fields.lcntpcd), dao.fields.pvncd, dao.fields.IDA)
        Dim cls_xml As New CLASS_DRUG_PROJECT
        cls_xml = cls_CER.gen_xml()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

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

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_DRUG_PROJECT_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)
        ElseIf e.CommandName = "nym" Then
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            _CLS.LCNNO = dao.fields.LCNNO.ToString()
            Session("CLS") = _CLS

            _lct_ida = Request.QueryString("lct_ida")
            _lcn_ida = Request.QueryString("lcn_ida")
            ' Response.Redirect("../MAIN/FRM_NODE.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())
            Response.Redirect("../DRUG_CUSTOMER_NORYORMOR1/FRM_NORYORMOR1_MAIN.aspx?proj_ida=" & str_ID & "&lct_ida=" & _lct_ida & "&lcn_ida=" & _lcn_ida & "&process=1")

        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_data()
    End Sub
End Class