Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class TABEAN_YA_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    'Private _IDA As String = ""
    Private _FK_IDA As String = ""
    Private _process As String = ""
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _main_ida As String = ""
    Private _staff As String = ""
    Sub runQuery()
        '_IDA = Request.QueryString("IDA") 'IDA ของ REGIST
        _process = Request.QueryString("process")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _staff = Request.QueryString("staff")
        _main_ida = Request.QueryString("main_ida")
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
        load_lcnno()
        set_name()
        set_regis()
        load_HL()
        If Not IsPostBack Then
            load_GV_Tabean()
            'load_GV_Tabean2()
            ' load_GV_Drug_EX()
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
        If Request.QueryString("tt") <> "" Then
            btn_download_t2.Visible = False

            lbl_tabean.Text = "การขอขึ้นทะเบียนผลิตภัณฑ์สมุนไพร (ยาจากสมุนไพร)"

            hl_pay.Style.Add("display", "none")
        End If
        ' btn_upload_t.Attributes.Add("onclick", "return  Popups2('../DR/POPUP_DR_UPLOAD.aspx?IDA=" & _IDA & "&process=" & _process & "');")
        ' btn_upload_ex.Attributes.Add("onclick", "return  Popups2('../DS/POPUP_DS_UPLOAD.aspx?IDA=" & _IDA & "&process=" & _process & "');")
    End Sub
    Sub load_lcnno()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("lcn_ida"))
            lbl_lcnno.Text = dao.fields.lcntpcd & " " & dao.fields.pvnabbr & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub set_regis()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao.GetDataby_IDA(_main_ida)
        Catch ex As Exception

        End Try
        Try
            lbl_dl.Text = dao.fields.REGIS_NO
        Catch ex As Exception

        End Try

        Try
            lb_drug_name.Text = dao.fields.DRUG_NAME_THAI
        Catch ex As Exception

        End Try
        Try
            lb_drug_name_other.Text = dao.fields.DRUG_NAME_OTHER
        Catch ex As Exception

        End Try

        Try
            Dim dao2 As New DAO_DRUG.ClsDBdactg
            dao2.GetData_by_cd(dao.fields.DRUG_GROUP)
            lb_drug_group.Text = dao2.fields.ctgthanm
        Catch ex As Exception

        End Try

        Try
            Dim dao3 As New DAO_DRUG.TB_drkdofdrg
            dao3.GetData_by_kindcd(dao.fields.kindcd)
            lb_drug_type.Text = dao3.fields.thakindnm
        Catch ex As Exception

        End Try

    End Sub
    Private Sub set_name()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        Try
            dao.GetDataby_FK_IDA(_main_ida)
        Catch ex As Exception

        End Try


        Try
            lb_th_name.Text = dao.fields.thadrgnm
        Catch ex As Exception

        End Try
        Try
            lb_eng_name.Text = dao.fields.engdrgnm
        Catch ex As Exception

        End Try

        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        Try
            dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 8)
        Catch ex As Exception

        End Try
        Try
            lb_stat.Text = dao_stat.fields.STATUS_NAME
        Catch ex As Exception
            lb_stat.Text = "-"
        End Try
        Try
            lbl_lcn_name.Text = _CLS.THANM_CUSTOMER
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_download_t_Click(sender As Object, e As EventArgs) Handles btn_download_t.Click
        Bind_PDF(_process)   ' Bind_PDF("PDF_DRUG_Y1.pdf")
    End Sub

    Sub load_GV_Tabean()
        Dim dao As New DAO_DRUG.ClsDBdrrqt

        Dim stat As Integer = 0
        Try
            dao.GetDataby_FK_IDA(_main_ida)
            stat = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try
        Try
            Dim bao_DB As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            'If stat = 8 Then
            '    bao_DB.SP_DRSAMP_TABEAN_BY_FK_IDA(_main_ida)
            '    GV_Tabean.DataSource = bao_DB.dt
            '    GV_Tabean.DataBind()
            'Else
            bao_DB.SP_RQ_TABEAN_BY_FK_IDA(_main_ida)
            GV_Tabean.DataSource = bao_DB.dt
            GV_Tabean.DataBind()
            'End If
        Catch ex As Exception

        End Try


    End Sub
    Sub load_GV_Tabean2()
        Dim dao As New DAO_DRUG.ClsDBdrrqt

        Dim stat As Integer = 0
        Try
            dao.GetDataby_FK_IDA(_main_ida)
            stat = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try
        Try
            Dim bao_DB As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            bao_DB.SP_DRSAMP_TABEAN_BY_FK_IDA(_main_ida)
            GV_Tabean2.DataSource = bao_DB.dt
            GV_Tabean2.DataBind()

        Catch ex As Exception

        End Try


    End Sub
    Sub load_GV_Drug_EX()
        Dim bao As New BAO.ClsDBSqlcommand
        'ยาตัวอย่าง
        bao.SP_DRSAMP_BY_IDA(_main_ida)
        GV_Drug_EX.DataSource = bao.dt
        GV_Drug_EX.DataBind()
    End Sub
    Private Sub Bind_PDF(ByVal process As Integer)
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
        Dim PDF_TEMPLATE As String = ""
        Try
            If Request.QueryString("tt") <> "" Then
                PDF_TEMPLATE = "DA_YOR_1_AUTO.pdf"
            Else
                PDF_TEMPLATE = dao_TEMPLATE.fields.PDF_TEMPLATE
            End If
        Catch ex As Exception

        End Try
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE                             'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml, process)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub

    Private Sub convert_Database_To_XML(ByVal path As String, ByVal Process_id As Integer)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        'Dim CHK_LCN_SUBTYPE1 As String = ""
        'Dim CHK_LCN_SUBTYPE2 As String = ""
        'Dim CHK_LCN_SUBTYPE3 As String = ""

        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                TABEAN_TYPE1 = "0"
                TABEAN_TYPE2 = "1"
            Else
                TABEAN_TYPE1 = "1"
                TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        'Try
        '    LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        'Catch ex As Exception

        'End Try
        Try

            If Len(dao.fields.lcnno) > 0 Then
                If dao.fields.pvnabbr <> "กท" Then
                    If Right(Left(dao.fields.lcnno, 3), 1) = "5" Then
                        LCNNO_FORMAT = "จ. " & CStr(CInt(Right(dao.fields.lcnno, 4))) & "/25" & Left(dao.fields.lcnno, 2)
                    Else
                        LCNNO_FORMAT = dao.fields.pvnabbr & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
                    End If
                Else
                    If Right(Left(dao.fields.lcnno, 3), 1) = "5" Then
                        LCNNO_FORMAT = CStr(CInt(Right(dao.fields.lcnno, 4))) & "/25" & Left(dao.fields.lcnno, 2)
                    Else
                        LCNNO_FORMAT = CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
                    End If

                End If

            End If
        Catch ex As Exception

        End Try
        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_re.GetDataby_IDA(_main_ida)
        Try
            drug_name = dao_re.fields.DRUG_NAME_THAI & " / " & dao_re.fields.DRUG_NAME_OTHER
        Catch ex As Exception

        End Try

        'If Process_id = 11 Then
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, Process_id, LCN_IDA:=_lcn_ida)
        Dim cls_xml As New CLASS_DR
        cls_xml = cls.gen_xml()
        Try
            Dim dao_dos As New DAO_DRUG.TB_drdosage
            dao_dos.GetDataby_cd(dao_re.fields.FK_DOSAGE_FORM)
            cls_xml.Dossage_form = dao_dos.fields.thadsgnm & "/" & dao_dos.fields.engdsgnm
        Catch ex As Exception

        End Try
        Dim dt_pack As New DataTable
        Try
            'Dim bao_pack As New BAO_SHOW
            'dt_pack = bao_pack.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA_v2(_main_ida)
            'cls_xml.PACK_SIZE = dt_pack(0)("full_unit")
            cls_xml.PACK_SIZE = dao_re.fields.PACKAGE_DETAIL
        Catch ex As Exception

        End Try
        Try
            'Dim dao_det As New DAO_DRUG.TB_DRUG_REGISTRATION_PROP_AND_DETAIL
            'dao_det.GetDataby_FK_IDA(_main_ida)
            cls_xml.DRUG_PROPERTIES_AND_DETAIL = dao_re.fields.DRUG_COLOR
        Catch ex As Exception

        End Try


        cls_xml.LCN_TYPE = LCN_TYPE
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.DRUG_NAME = drug_name
        cls_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        cls_xml.TABEAN_TYPE2 = TABEAN_TYPE2
        cls_xml.DRUG_STRENGTH = dao_re.fields.DRUG_STR
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        Dim bao_ori As New BAO.ClsDBSqlcommand
        cls_xml.DT_SHOW.DT8 = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_main_ida)
        cls_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        cls_xml.DT_SHOW.DT9 = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_main_ida)
        cls_xml.DT_SHOW.DT9.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        cls_xml.DT_SHOW.DT10 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(_main_ida, "A")
        cls_xml.DT_SHOW.DT10.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_A"
        cls_xml.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(_main_ida, "I")
        cls_xml.DT_SHOW.DT11.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_I"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_main_ida)
        cls_xml.DT_SHOW.DT12.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"
        cls_xml.DT_SHOW.DT7 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(1) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT7.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2"

        Dim dt13 As New DataTable
        Dim dt14 As New DataTable
        Dim dt15 As New DataTable
        dt13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 1, LCNTPCD_GROUP)
        dt14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 2, LCNTPCD_GROUP)
        dt15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 3, LCNTPCD_GROUP)
        If dt13.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 1, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        End If
        If dt14.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 2, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        End If
        If dt15.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 3, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
        End If
        cls_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_MASTER(_main_ida)
        cls_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_MASTER"

        If Request.QueryString("identify") <> "" Then
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(Request.QueryString("identify"), _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        Else
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        End If


        cls_xml.DT_SHOW.DT18 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL(_main_ida)
        cls_xml.DT_SHOW.DT18.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL"

        cls_xml.DT_SHOW.DT20 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW(_main_ida) 'สารสำคัญ/ส่วนประกอบ(รวม)
        cls_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"

        cls_xml.DT_SHOW.DT21 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 9, LCNTPCD_GROUP)
        cls_xml.DT_SHOW.DT21.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_OTHER"

        cls_xml.DT_SHOW.DT22 = bao_show.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(_main_ida)
        cls_xml.DT_SHOW.DT22.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA"

        cls_xml.DT_SHOW.DT23 = bao_ori.SP_regis(_main_ida)
        cls_xml.DT_SHOW.DT23.TableName = "SP_regis"
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao.fields.IDA) 'ผู้ดำเนิน

            cls_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand


        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
        'ElseIf Process_id = 7 Then

        '    Dim cls As New CLASS_GEN_XML.DS(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, Process_id, dao.fields.IDA)
        '    Dim cls_xml As New CLASS_DS
        '    cls_xml = cls.gen_xml()
        '    Dim bao_app As New BAO.AppSettings
        '    bao_app.RunAppSettings()
        '    Dim objStreamWriter As New StreamWriter(path)
        '    Dim x As New XmlSerializer(cls_xml.GetType)
        '    x.Serialize(objStreamWriter, cls_xml)
        '    objStreamWriter.Close()
        'End If




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

    Private Sub GV_Tabean_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_Tabean.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_Tabean.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        Try
            dao.GetDataby_IDA(str_ID)
        Catch ex As Exception

        End Try

        Dim tr_id As Integer = 0
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        If e.CommandName = "sel" Then

            Dim url As String = ""

            'If Request.QueryString("staff") <> "" Then
            '    If dao.fields.STATUS_ID <> 8 And dao.fields.STATUS_ID < 10 Then
            '        url = "../TABEAN_YA_STAFF/POPUP_DR_STAFF_RECEIVE_PAPER.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process
            '    Else
            '        url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&status=" & dao.fields.STATUS_ID '& "&staff=1"
            '    End If

            'Else
            url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&r_process=" & Request.QueryString("r_process") '& "&staff=1"
            'End If
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
        ElseIf e.CommandName = "_add" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & Request.QueryString("process") & "&STATUS_ID=" & dao.fields.STATUS_ID  & "&rq=1'); ", True)

        End If
    End Sub
    Private Sub load_HL()
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_process)
        Try
            If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then
                hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE_DEMO/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
                If Request.QueryString("staff") = 1 Then
                    hl_pay.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
                End If
            Else
                hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
                If Request.QueryString("staff") = 1 Then
                    hl_pay.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub GV_Tabean_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_Tabean.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
            Dim btn_add As Button = DirectCast(e.Row.FindControl("btn_add"), Button)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_Tabean.DataKeys.Item(index).Value.ToString()
            Dim stat As String = e.Row.Cells(0).Text 'GV_data.Rows(index).Cells(0).Text

            Dim dao_rt As New DAO_DRUG.ClsDBdrrqt
            Dim rgttpcd As String = ""
            Try
                dao_rt.GetDataby_IDA(str_ID)
                rgttpcd = dao_rt.fields.rgttpcd
            Catch ex As Exception

            End Try
            If rgttpcd = "" Then
                btn_add.Style.Add("display", "none")
            End If
        End If
    End Sub
    Private Sub GV_Drug_EX_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_Drug_EX.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_Drug_EX.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../DS/POPUP_DS_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
            ' ElseIf e.CommandName = "sel" Then

        End If
    End Sub

    Private Sub TABEAN_YA_MAIN_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'If GV_Tabean.Rows.Count > 0 Then
        '    btn_download_t.Style.Add("display", "none")
        '    btn_upload_t.Style.Add("display", "none")
        'End If
    End Sub

    Protected Sub btn_download_ex_Click(sender As Object, e As EventArgs) Handles btn_download_ex.Click
        Bind_PDF(7)
        'Bind_PDF_EX("PDF_DRUG_PORYOR8.pdf")
        'Bind_PDF_EX("PDF_DRUG_KORYOR8.pdf")
        'Bind_PDF_EX("PDF_DRUG_NORYOR8.pdf")
        'Bind_PDF_EX("PDF_DRUG_YORBOR8.pdf")

    End Sub


    Private Sub Bind_PDF_EX(ByVal PDF_TEMPLATE As String)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
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
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        'Dim dao As New DAO.clsDBfafdtype
        'dao.Getdata_by_fdtypecd(_CLS.FDTYPECD)

        '    _CLS.FATYPE = FATYPE

        Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)



        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
        Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID) 'test
        ' Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & "DA-3227.xml" 'test

        convert_Database_To_XML_EX("DA-" & down_ID.ToString())
        convert_XML_To_PDF(file_PDF, file_xml, file_template)

        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML_EX(ByVal filename As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_FK_IDA)

        Dim cls As New CLASS_GEN_XML.DS(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao.fields.lcnno, "1", dao.fields.pvncd, dao.fields.IDA)
        Dim cls_xml As New CLASS_DS
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

    Protected Sub btn_upload_ex_Click(sender As Object, e As EventArgs) Handles btn_upload_ex.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../DS/POPUP_DS_UPLOAD.aspx?IDA=" & _main_ida & "&process=" & 7 & "');", True)

    End Sub

    Protected Sub btn_upload_t_Click(sender As Object, e As EventArgs) Handles btn_upload_t.Click
        If Request.QueryString("tt") <> "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../DR/POPUP_DR_UPLOAD.aspx?IDA=" & _main_ida & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "&tt=" & Request.QueryString("tt") & "');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../DR/POPUP_DR_UPLOAD.aspx?IDA=" & _main_ida & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "');", True)
        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_Drug_EX()
        load_GV_Tabean()
        load_GV_Tabean2()
        'ปิด
        '
        Try
            UC_DS_MAIN.GV_lcnno_DataBinding()
        Catch ex As Exception

        End Try
        rg_tabean1.Rebind()
        rg_tabean2.Rebind()


    End Sub

    Private Sub GV_Tabean2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_Tabean2.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_Tabean2.DataKeys.Item(int_index)("IDA").ToString()

        Dim STATUS_ID As String = ""

        Try
            'STATUS_ID = GV_Tabean2.DataKeys.Item(int_index)("STATUS_ID").ToString()
            STATUS_ID = GV_Tabean2.Rows(int_index).Cells(2).Text
        Catch ex As Exception

        End Try
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Try
            dao.GetDataby_IDA(str_ID)
        Catch ex As Exception

        End Try

        Dim tr_id As Integer = 0
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        If e.CommandName = "sel" Then

            Dim url As String = ""

            If Request.QueryString("staff") <> "" Then
                If dao.fields.STATUS_ID <> 8 And dao.fields.STATUS_ID < 10 Then
                    url = "../TABEAN_YA_STAFF/POPUP_DR_STAFF_RECEIVE_PAPER.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process
                Else
                    url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&status=" & dao.fields.STATUS_ID  '& "&staff=1"
                End If

            Else
                url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&status=" & dao.fields.STATUS_ID
            End If
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
        ElseIf e.CommandName = "_add" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & tr_id & "&process=" & Request.QueryString("process") & "&rq=1&type=rg'); ", True)

        End If
    End Sub

    Private Sub GV_Tabean2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_Tabean2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
            Dim btn_add As Button = DirectCast(e.Row.FindControl("btn_add"), Button)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_Tabean2.DataKeys.Item(index).Value.ToString()
            Dim stat As String = e.Row.Cells(0).Text 'GV_data.Rows(index).Cells(0).Text

            Dim dao_rt As New DAO_DRUG.ClsDBdrrgt
            Dim rgttpcd As String = ""
            Try
                dao_rt.GetDataby_IDA(str_ID)
                rgttpcd = dao_rt.fields.rgttpcd
            Catch ex As Exception

            End Try
            If rgttpcd = "" Then
                btn_add.Style.Add("display", "none")
            End If
        End If
    End Sub

    Private Sub rg_tabean2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_tabean2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim STATUS_ID As String = ""
            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(IDA)
            Dim fk_ida As String = ""
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Try
                fk_ida = dao.fields.FK_IDA
            Catch ex As Exception

            End Try
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                 Dim url As String = ""

                If Request.QueryString("staff") <> "" Then
                    If item("STATUS_ID").Text <> 8 And item("STATUS_ID").Text < 10 Then
                        url = "../TABEAN_YA_STAFF/POPUP_DR_STAFF_RECEIVE_PAPER.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & _process
                    Else
                        url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & _process & "&status=" & item("STATUS_ID").Text & "&STATUS_ID=" & item("STATUS_ID").Text  '& "&staff=1"
                    End If

                Else
                    url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & _process & "&status=" & item("STATUS_ID").Text & "&STATUS_ID=" & item("STATUS_ID").Text
                End If
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)

            ElseIf e.CommandName = "_add" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & tr_id & "&process=" & Request.QueryString("process") & "&status=" & item("STATUS_ID").Text & "&STATUS_ID=" & item("STATUS_ID").Text & "&rq=1&type=rg'); ", True)
            End If

        End If
    End Sub

    Private Sub rg_tabean2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_tabean2.NeedDataSource
        'Dim dao As New DAO_DRUG.ClsDBdrrqt

        'Dim stat As Integer = 0
        'Try
        '    dao.GetDataby_FK_IDA(_main_ida)
        '    stat = dao.fields.STATUS_ID
        'Catch ex As Exception

        'End Try
        Try
            Dim bao_DB As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            bao_DB.SP_DRSAMP_TABEAN_BY_FK_IDA(_main_ida)
            rg_tabean2.DataSource = bao_DB.dt
            ' GV_Tabean2.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rg_tabean1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_tabean1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(IDA)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Dim status_id As Integer = 0
            Try
                status_id = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                Dim url As String = ""

                'If Request.QueryString("staff") <> "" Then
                '    If dao.fields.STATUS_ID <> 8 And dao.fields.STATUS_ID < 10 Then
                '        url = "../TABEAN_YA_STAFF/POPUP_DR_STAFF_RECEIVE_PAPER.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process
                '    Else
                '        url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&status=" & dao.fields.STATUS_ID '& "&staff=1"
                '    End If

                'Else
                url = "../DR/POPUP_DR_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & _process & "&status=" & status_id '& "&staff=1"
                If Request.QueryString("tt") <> "" Then
                    url &= "&tt=" & Request.QueryString("tt")
                End If
                'End If
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
            ElseIf e.CommandName = "_add" Then
                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & Request.QueryString("process") & "&STATUS_ID=" & dao.fields.STATUS_ID & "&rq=1&tt=1'); ", True)

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & Request.QueryString("process") & "&STATUS_ID=" & dao.fields.STATUS_ID & "&rq=1'); ", True)

                End If
            ElseIf e.CommandName = "_report" Then
                Dim url As String = ""
                url = "../TABEAN_YA_STAFF/FRM_APPOINTMENT.aspx?IDA=" & IDA
                'RunSession()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "'); ", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
            ElseIf e.CommandName = "report2" Then
                'lbl_titlename.Text = "แบบฟอร์มทะเบียน"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/FRM_REPORT_TABEAN.aspx?IDA=" & IDA & "&TR_ID=" & item("TR_ID").Text & "&STATUS_ID=" & dao.fields.STATUS_ID & "&status=" & dao.fields.STATUS_ID & "');", True)
            End If

        End If

    End Sub

    Private Sub rg_tabean1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_tabean1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_report As LinkButton = DirectCast(item("btn_report").Controls(0), LinkButton)
            Dim btn_add As LinkButton = DirectCast(item("btn_add").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBdrrqt

            Try
                If Request.QueryString("tt") <> "" Then
                    btn_add.Text = "ตรวจสอบข้อมูล"
                    btn_add.Visible = False
                End If
            Catch ex As Exception

            End Try
            Try
                dao.GetDataby_IDA(IDA)
                If dao.fields.STATUS_ID >= 3 Then
                    btn_report.Style.Add("display", "block")
                Else
                    btn_report.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
           
        End If
    End Sub

    Private Sub rg_tabean1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_tabean1.NeedDataSource
        Dim dao As New DAO_DRUG.ClsDBdrrqt

        Dim stat As Integer = 0
        Try
            dao.GetDataby_FK_IDA(_main_ida)
            stat = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try
        Try
            Dim bao_DB As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            bao_DB.SP_RQ_TABEAN_BY_FK_IDA(_main_ida)
            rg_tabean1.DataSource = bao_DB.dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_download_t2_Click(sender As Object, e As EventArgs) Handles btn_download_t2.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../DR/POPUP_DR_TRANSFER_DL.aspx?IDA=" & _main_ida & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "');", True)
    End Sub
End Class