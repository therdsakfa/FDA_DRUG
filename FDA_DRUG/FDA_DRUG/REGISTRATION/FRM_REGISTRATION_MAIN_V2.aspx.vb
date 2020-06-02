Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI
Public Class FRM_REGISTRATION_MAIN_V2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String = ""
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _r_process As String = ""
    Sub runQuery()
        _r_process = Request.QueryString("r_process")
        _process = "1400001" 'Request.QueryString("process")
        '_IDA = Request.QueryString("IDA")
        '_fk_ida = Request.QueryString("fk_ida")
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
        runQuery()
        set_lbl_header(lbl_Header_txt, _r_process)
        If Not IsPostBack() Then
            bind_ddl_product()
            'load_GV_data()
            Try
                UC_Information.Shows(_lcn_ida)
            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Sub bind_ddl_product()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            bao.SP_DRUG_PRODUCT_ID_BY_LCN_IDA(_lcn_ida)
        Catch ex As Exception

        End Try
        Try
            dt = bao.dt
            ddl_product_id.DataSource = dt
            ddl_product_id.DataTextField = "LCNNO_DISPLAY"
            ddl_product_id.DataValueField = "IDA"
            ddl_product_id.DataBind()
        Catch ex As Exception

        End Try


    End Sub
    Sub load_GV_data()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        'If _fk_ida <> "" Then
        bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID(_lcn_ida, _r_process)
        'Else
        '    bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA(_IDA)
        'End If

        'GV_data.DataSource = bao_DB.dt
        'GV_data.DataBind()
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF()
        Bind_PDF_T("1400001")
        'If _process = 9 Then
        '    Bind_PDF("PDF_REGISTRATION.pdf")
        'ElseIf _process = 19 Then
        '    Bind_PDF("PDF_REGISTRATION_ANIMAL.pdf")
        'End If
    End Sub


    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _r_process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_r_process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub Bind_PDF_T(ByVal process As String)
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

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_TABEAN(process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        'convert_Database_To_XML_T(file_xml, process)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML(ByVal path As String)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(Integer.Parse(_lcn_ida))
        Dim dao_cer As New DAO_DRUG.TB_CER
        dao_cer.GetDataby_FK_IDA(_lcn_ida)
        Dim _product_id As Integer = 0
        Try
            _product_id = ddl_product_id.SelectedValue
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DRUG_REGISTRATION(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao_lcn.fields.lcnno, _r_process, dao_lcn.fields.IDA)
        Dim cls_xml As New CLASS_REGISTRATION

        cls_xml = cls.gen_xml()
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(_product_id) 'ข้อมูลที่ดึงมาจาก Product ID


        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand


        cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(0) 'CER
        cls_xml.DT_MASTER.DT15.TableName = "SP_MASTER_CER_PK_BY_FK_IDA"
        cls_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        cls_xml.DT_MASTER.DT16.TableName = "SP_dactg"
        cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        cls_xml.DT_MASTER.DT18.TableName = "SP_CER_FOREIGN_BY_IDA"
        cls_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา
        cls_xml.DT_MASTER.DT21.TableName = "SP_dosage_form"
        cls_xml.DT_MASTER.DT22 = bao_master_2.SP_DRUG_UNIT_PHYSIC() 'หน่วยเล็กสุด
        cls_xml.DT_MASTER.DT22.TableName = "SP_DRUG_UNIT_PHYSIC"
        cls_xml.DT_MASTER.DT23 = bao_master_2.SP_MASTER_drsunit() 'หน่วย
        cls_xml.DT_MASTER.DT23.TableName = "SP_MASTER_drsunit"
        'cls_xml.DT_MASTER.DT24 = bao_master_2.SP_FOREIGN_ADDR_ALL()
        'cls_xml.DT_MASTER.DT24.TableName = "SP_FOREIGN_ADDR_ALL"

        Dim lcnno_raw As String = ""
        Dim lcnno As String = ""
        Try
            'lcnno_raw = dao_lcn.fields.LCNNO_DISPLAY
            'If lcnno_raw <> "" Then
            lcnno = dao_lcn.fields.lcntpcd & " " & CInt(Right(dao_lcn.fields.lcnno, 5)) & "/25" & Left(dao_lcn.fields.lcnno, 2)
            'End If
        Catch ex As Exception

        End Try
        cls_xml.SHOW_LCNNO = lcnno
        cls_xml.DRUG_REGISTRATIONs.LCNNO = dao_lcn.fields.lcnno
        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 1
        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 2
        End If


        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub
    'Private Sub convert_Database_To_XML_T(ByVal path As String, ByVal Process_id As Integer)

    '    Dim dao As New DAO_DRUG.ClsDBdalcn
    '    dao.GetDataby_IDA(_lcn_ida)
    '    Dim LCN_TYPE As String = ""
    '    Dim LCNNO_FORMAT As String = ""
    '    Dim LCNTPCD_GROUP As String = ""
    '    Dim drug_name As String = ""
    '    Dim TABEAN_TYPE1 As String = ""
    '    Dim TABEAN_TYPE2 As String = ""
    '    'Dim CHK_LCN_SUBTYPE1 As String = ""
    '    'Dim CHK_LCN_SUBTYPE2 As String = ""
    '    'Dim CHK_LCN_SUBTYPE3 As String = ""

    '    Try
    '        If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
    '            TABEAN_TYPE1 = "0"
    '            TABEAN_TYPE2 = "1"
    '        Else
    '            TABEAN_TYPE1 = "1"
    '            TABEAN_TYPE2 = "0"
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        If dao.fields.lcntpcd.Contains("ผย") Or dao.fields.lcntpcd.Contains("นยบ") Then
    '            LCN_TYPE = "2"
    '        Else
    '            LCN_TYPE = "1"
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        If dao.fields.lcntpcd.Contains("ผย") Then
    '            LCNTPCD_GROUP = "2"
    '        Else
    '            LCNTPCD_GROUP = "1"
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
    '    Catch ex As Exception

    '    End Try
    '    Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
    '    dao_re.GetDataby_IDA(_main_ida)
    '    Try
    '        drug_name = dao_re.fields.DRUG_NAME_THAI & " / " & dao_re.fields.DRUG_NAME_OTHER
    '    Catch ex As Exception

    '    End Try

    '    'If Process_id = 11 Then
    '    Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, Process_id, LCN_IDA:=_lcn_ida)
    '    Dim cls_xml As New CLASS_DR
    '    cls_xml = cls.gen_xml()
    '    Try
    '        Dim dao_dos As New DAO_DRUG.TB_drdosage
    '        dao_dos.GetDataby_cd(dao_re.fields.FK_DOSAGE_FORM)
    '        cls_xml.Dossage_form = dao_dos.fields.thadsgnm
    '    Catch ex As Exception

    '    End Try
    '    Dim dt_pack As New DataTable
    '    Try
    '        Dim bao_pack As New BAO_SHOW
    '        dt_pack = bao_pack.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA_v2(_main_ida)
    '        cls_xml.PACK_SIZE = dt_pack(0)("full_unit")
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        'Dim dao_det As New DAO_DRUG.TB_DRUG_REGISTRATION_PROP_AND_DETAIL
    '        'dao_det.GetDataby_FK_IDA(_main_ida)
    '        cls_xml.DRUG_PROPERTIES_AND_DETAIL = dao_re.fields.DRUG_COLOR
    '    Catch ex As Exception

    '    End Try

    '    cls_xml.LCN_TYPE = LCN_TYPE
    '    cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
    '    cls_xml.DRUG_NAME = drug_name
    '    cls_xml.TABEAN_TYPE1 = TABEAN_TYPE1
    '    cls_xml.TABEAN_TYPE2 = TABEAN_TYPE2
    '    cls_xml.DRUG_STRENGTH = dao_re.fields.DRUG_STR
    '    '_______________SHOW_________________
    '    Dim bao_show As New BAO_SHOW
    '    Dim bao_ori As New BAO.ClsDBSqlcommand
    '    cls_xml.DT_SHOW.DT8 = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_main_ida)
    '    cls_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
    '    cls_xml.DT_SHOW.DT9 = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_main_ida)
    '    cls_xml.DT_SHOW.DT9.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
    '    cls_xml.DT_SHOW.DT10 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(_main_ida, "A")
    '    cls_xml.DT_SHOW.DT10.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_A"
    '    cls_xml.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(_main_ida, "I")
    '    cls_xml.DT_SHOW.DT11.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_I"
    '    cls_xml.DT_SHOW.DT12 = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_main_ida)
    '    cls_xml.DT_SHOW.DT12.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"

    '    cls_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 1, LCNTPCD_GROUP)
    '    cls_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
    '    cls_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 2, LCNTPCD_GROUP)
    '    cls_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
    '    cls_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 3, LCNTPCD_GROUP)
    '    cls_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
    '    cls_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_MASTER(_main_ida)
    '    cls_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_MASTER"

    '    cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท

    '    cls_xml.DT_SHOW.DT18 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL(_main_ida)
    '    cls_xml.DT_SHOW.DT18.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL"

    '    cls_xml.DT_SHOW.DT20 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW(_main_ida) 'สารสำคัญ/ส่วนประกอบ(รวม)
    '    cls_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"

    '    cls_xml.DT_SHOW.DT21 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 9, LCNTPCD_GROUP)
    '    cls_xml.DT_SHOW.DT21.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_OTHER"

    '    cls_xml.DT_SHOW.DT22 = bao_show.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(_main_ida)
    '    cls_xml.DT_SHOW.DT22.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA"

    '    cls_xml.DT_SHOW.DT23 = bao_ori.SP_regis(_main_ida)
    '    cls_xml.DT_SHOW.DT23.TableName = "SP_regis"
    '    '_______________MASTER_________________
    '    Dim bao_master As New BAO_MASTER
    '    Dim bao_master_2 As New BAO.ClsDBSqlcommand


    '    Dim bao_app As New BAO.AppSettings
    '    bao_app.RunAppSettings()
    '    Dim objStreamWriter As New StreamWriter(path)
    '    Dim x As New XmlSerializer(cls_xml.GetType)
    '    x.Serialize(objStreamWriter, cls_xml)
    '    objStreamWriter.Close()
    '    'ElseIf Process_id = 7 Then

    '    '    Dim cls As New CLASS_GEN_XML.DS(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, Process_id, dao.fields.IDA)
    '    '    Dim cls_xml As New CLASS_DS
    '    '    cls_xml = cls.gen_xml()
    '    '    Dim bao_app As New BAO.AppSettings
    '    '    bao_app.RunAppSettings()
    '    '    Dim objStreamWriter As New StreamWriter(path)
    '    '    Dim x As New XmlSerializer(cls_xml.GetType)
    '    '    x.Serialize(objStreamWriter, cls_xml)
    '    '    objStreamWriter.Close()
    '    'End If




    'End Sub
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

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        'load_GV_data()
        Rg_regist.Rebind()
    End Sub

    Private Sub Rg_regist_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles Rg_regist.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item

            Dim str_ID As String = item("IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION

            If e.CommandName = "_sel" Then
                dao.GetDataby_IDA(str_ID)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('POPUP_REGISTRATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _r_process & "');", True)

            ElseIf e.CommandName = "_add2" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & str_ID & "&req=1" & "&process=" & _r_process & "');", True)
            ElseIf e.CommandName = "choose" Then
                Dim url As String = "../TABEAN_YA/TABEAN_YA_MAIN.aspx?main_ida=" & str_ID & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "&lct_ida=" & _lct_ida
                If Request.QueryString("staff") <> "" Then
                    url &= "&staff=1"
                End If
                Response.Redirect(url)
            End If
        End If
    End Sub

    Private Sub Rg_regist_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles Rg_regist.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_Select As LinkButton = DirectCast(item("_sel").Controls(0), LinkButton)
            Dim btn_Choose As LinkButton = DirectCast(item("choose").Controls(0), LinkButton)

            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            Dim lcntpcd As String = ""
            Try
                dao.GetDataby_IDA(IDA)
                dao_dal.GetDataby_IDA(dao.fields.FK_IDA)
                lcntpcd = dao_dal.fields.lcntpcd

                If dao.fields.STATUS_ID = 8 Then
                    btn_Choose.Style.Add("display", "block")
                Else
                    btn_Choose.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
            Dim count_chem As Integer = 0
            Dim count_pro As Integer = 0
            Dim dao_chem As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
            count_chem = dao_chem.CountDataby_IDA(IDA)

            If lcntpcd.Contains("ผย") Then
                Dim dao_pro As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                count_pro = dao_pro.CountDataby_FK_IDA(IDA)
            ElseIf lcntpcd.Contains("นย") Then
                Dim dao_pro As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
                count_pro = dao_pro.CountDataby_FK_IDA(IDA)
            End If


            If count_chem > 0 And count_pro > 0 Then
                btn_Select.Style.Add("display", "block")

            End If


            Try
                'dao.GetDataby_IDA(IDA)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Rg_regist_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_regist.NeedDataSource
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        'If _fk_ida <> "" Then
        bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID(_lcn_ida, _r_process)
        Rg_regist.DataSource = bao_DB.dt
    End Sub
End Class