Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_NORYORMOR1_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _proj_ida As String = ""
    Private _ProcessID As String = ""
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _tr_id As String = ""
    Sub runQuery()
        _proj_ida = Request.QueryString("proj_ida")
        _ProcessID = Request.QueryString("process")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _tr_id = Request.QueryString("TR_ID")
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
        bao.SP_DRIMPFOR_BY_IDA(_proj_ida, _ProcessID)
        GV_data.DataSource = bao.dt
        GV_data.DataBind()
    End Sub
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF()
    End Sub


    Private Sub Bind_PDF()
         Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer


        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _ProcessID
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 0, 0)

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

    Private Sub convert_Database_To_XML(ByVal filename As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)

        'Dim cls_CER As New CLASS_GEN_XML.NYM1(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno,
        '                                    IIf(IsDBNull(dao.fields.lcntpcd), "", dao.fields.lcntpcd), dao.fields.pvncd, dao.fields.IDA)
        Dim cls_xml As New CLASS_PROJECT_NYM1
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_lcn_ida)
        Dim dao_prj As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao_prj.GetDataby_TR_ID(_tr_id)
        Dim dao_place As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
        dao_place.GetDataby_PROJECT(dao_prj.fields.IDA)
        'cls_xml = cls_CER.gen_xml()
        If Left(dao.fields.lcntpcd, 1) = "ผ" Then
            cls_xml.drsamp.LCNNO_SHOWS = dao.fields.LCNNO_DISPLAY
            cls_xml.drsamp.IN_NAME_DETAIL3 = dao_addr.fields.thanameplace
        Else
            cls_xml.drsamp.LCNNO_SHOWS1 = dao.fields.LCNNO_DISPLAY
            cls_xml.drsamp.IN_NAME_DETAIL4 = dao_addr.fields.thanameplace
        End If
        cls_xml.drsamp.addr = dao_addr.fields.thaaddr
        cls_xml.drsamp.moo = dao_addr.fields.thamu
        cls_xml.drsamp.soi = dao_addr.fields.thasoi
        cls_xml.drsamp.road = dao_addr.fields.tharoad
        cls_xml.drsamp.thmblnm = dao_addr.fields.thathmblnm
        cls_xml.drsamp.amphrnm = dao_addr.fields.thaamphrnm
        cls_xml.drsamp.chngwtnm = dao_addr.fields.thachngwtnm
        cls_xml.drsamp.tel = dao_addr.fields.tel
        cls_xml.drsamp.PREFIX = dao_bsn.fields.BSN_PREFIXENGCD
        cls_xml.drsamp.NAME = dao_bsn.fields.BSN_THAIFULLNAME
        cls_xml.DRUG_PROJECT_SUMMARY.pj_enname = dao_prj.fields.pj_enname
        cls_xml.DRUG_PROJECT_SUMMARY.pj_thname = dao_prj.fields.pj_thname
        cls_xml.DRUG_PROJECT_SUMMARY.pj_code = dao_prj.fields.pj_code
        cls_xml.DRUG_PROJECT_SUMMARY.place = dao_place.fields.placenm

        If Right(dao.fields.lcntpcd, 1) = "บ" Then
            cls_xml.drsamp.CHK_PERMISSION_REQUEST = Right(dao.fields.lcntpcd, 2)
        Else
            cls_xml.drsamp.CHK_PERMISSION_REQUEST = Right(dao.fields.lcntpcd, 1)
        End If

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(filename)
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
        Dim dao As New DAO_DRUG.ClsDBdrimpfor

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_NORYORMOR1_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_data()
    End Sub
End Class