Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class FRM_LCN_NCT
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                 'ประกาศชื่อตัวแปร _process
    Private _process_for As String
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""


    Private _type As String

    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()
        Try
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
        Catch ex As Exception

        End Try
        Try
            _process_for = Request.QueryString("process_for")
        Catch ex As Exception

        End Try
        Try
            _lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception

        End Try
        Try
            _lcn_ida = Request.QueryString("lcn_ida")
        Catch ex As Exception

        End Try

        Try

            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' UC_INFORPERMIT.Sho()
        RunSession()
        ' UC_Information1.Shows(_lcn_ida)
        'ให้รันฟังก์ชั่นลำดับที่ 1
        load_HL()
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2
            load_lbl_name()
            load_GV_lcnno()
            UC_Information1.Shows(_lcn_ida)
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If

    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & _lct_ida
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify")
        End If

        hl_pay.NavigateUrl = urls
        'If Request.QueryString("staff") <> "" Then
        '    hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        'End If
    End Sub
#Region "GRIDVIEW"

    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)


        End If

    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)


        End If
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU       'ประกาศชื่อตัวแปร DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_Process(_process)             'ดึง dao.GetDataby_Process เพื่อมาโชว์ที่ Gridview ที่เป็นค่า String

        'bao.SP_LCN_DRUG_TYPE_MENU(_CLS.LCNSID, dao.fields.NAME)
        'bao.SP_DALCN_By_lcntpcd(_CLS.LCNSID_CUSTOMER, dao.fields.NAME) 'เรียกใช้ SP  bao.SP_DALCN_By_lcntpcd
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_process)
        bao.SP_CUSTOMER_LCN_BY_FK_IDA(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, _CLS.CITIZEN_ID_AUTHORIZE)
        GV_lcnno.DataSource = bao.dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub

    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub
#End Region

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub

    Protected Sub btn_download_VJ_Click(sender As Object, e As EventArgs) Handles btn_download_VJ.Click
        If txt_bsn.Text = "" Then
            alert("กรุณากรอกเลขบัตรผู้ดำเนินกิจการ")
        Else
            If String.IsNullOrEmpty(_process) = False Then  'ถ้าให้ค่า _process เป็นค่าว่าง จะไม่เป็นความจริง
                Bind_PDF()                                  'เรียกฟังก์ชั่น  Bind_PDF มาใช้งาน
            Else
                alert("กรุณาเลือกประเภทใบอนุญาตก่อนทำการดาวน์โหลด")  'ถ้าค่าว่างจะ ERROR
            End If
        End If
    End Sub
    Private Sub load_lbl_name()
        Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu.GetDataby_Process2(_process)
        lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง
    End Sub
    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
        bao_app.RunAppSettings()                                                    'บอกที่อยู่ของไฟล์

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process                                       ' ชื่อ Process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID                               ' รับค่าจากเทเบิ้ล บัตรประชาชน
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE           ' รับ ชื่อประกอบการ
        dao_down.fields.STATUS = STATUS                                             ' รับเก็บค่า STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE                               'เวลา
        dao_down.insert()                                                           ' insert ค่าข้างบน
        down_ID = dao_down.fields.ID


        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)                   'จาวา .Gif
    End Sub
    ''' <summary>
    ''' แปลงค่าจากDatabase เป็น XML
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub convert_Database_To_XML(ByVal path As String)
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, "1", _CLS.PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN                                                                        ' ประกาศตัวแปรจาก CLASS_DALCN 
        Dim dao_dalcn_MAIN As New DAO_DRUG.ClsDBdalcn
        dao_dalcn_MAIN.GetDataby_IDA(_lcn_ida)

        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        cls_xml.dalcns.MAIN_LCN_IDA = _lcn_ida
        cls_xml.dalcns.BSN_IDENTIFY = txt_bsn.Text
        cls_xml.dalcns.AGE = dao_dalcn_MAIN.fields.AGE
        cls_xml.dalcns.NATION = dao_dalcn_MAIN.fields.NATION
        cls_xml.dalcns.NATIONALITY = dao_dalcn_MAIN.fields.NATIONALITY
        cls_xml.dalcns.LCNNO_DISPLAY = dao_dalcn_MAIN.fields.lcntpcd & " " & dao_dalcn_MAIN.fields.LCNNO_DISPLAY
        Dim lct_ida As Integer = 0
        Dim bsn_iden As String = ""

        Try
            lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception

        End Try
        Try
            Dim dao_bsn_h As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn_h.GetDataby_LCN_IDA(_lcn_ida)
            bsn_iden = Trim(txt_bsn.Text)
        Catch ex As Exception

        End Try
       
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง
        For Each drr As DataRow In cls_xml.DT_SHOW.DT9.Rows
            Try
                drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
            Catch ex As Exception

            End Try
            Try
                drr("fulladdr2") = NumEng2Thai(drr("fulladdr2"))
            Catch ex As Exception

            End Try
            Try
                drr("HOUSENO") = NumEng2Thai(drr("HOUSENO"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoom") = NumEng2Thai(drr("tharoom"))
            Catch ex As Exception

            End Try
            Try
                drr("thanameplace") = NumEng2Thai(drr("thanameplace"))
            Catch ex As Exception

            End Try
            Try
                drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
            Catch ex As Exception

            End Try
            Try
                drr("tel1") = NumEng2Thai(drr("tel1"))
            Catch ex As Exception

            End Try
            Try
                drr("thamu") = NumEng2Thai(drr("thamu"))
            Catch ex As Exception

            End Try
            Try
                drr("thafloor") = NumEng2Thai(drr("thafloor"))
            Catch ex As Exception

            End Try
            Try
                drr("thasoi") = NumEng2Thai(drr("thasoi"))
            Catch ex As Exception

            End Try
            Try
                drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
            Catch ex As Exception

            End Try
            Try
                drr("tharoad") = NumEng2Thai(drr("tharoad"))
            Catch ex As Exception

            End Try
            Try
                drr("zipcode") = NumEng2Thai(drr("zipcode"))
            Catch ex As Exception

            End Try
            Try
                drr("tel") = NumEng2Thai(drr("tel"))
            Catch ex As Exception

            End Try
            Try
                drr("fax") = NumEng2Thai(drr("fax"))
            Catch ex As Exception

            End Try
            Try
                drr("Mobile") = NumEng2Thai(drr("Mobile"))
            Catch ex As Exception

            End Try
            Try
                drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
            Catch ex As Exception

            End Try

        Next
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, _CLS.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Try

            For Each drr As DataRow In cls_xml.DT_SHOW.DT11.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, _CLS.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        Try
            For Each drr As DataRow In cls_xml.DT_SHOW.DT13.Rows
                Try
                    drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
                Catch ex As Exception

                End Try
                Try
                    drr("fulladdr_no") = NumEng2Thai(drr("fulladdr_no"))
                Catch ex As Exception

                End Try
                Try
                    drr("HOUSENO") = NumEng2Thai(drr("HOUSENO"))
                Catch ex As Exception

                End Try
                'Try
                '    drr("HOUSENO") = NumEng2Thai(drr("HOUSENO"))
                'Catch ex As Exception

                'End Try
                Try
                    drr("tharoom") = NumEng2Thai(drr("tharoom"))
                Catch ex As Exception

                End Try
                Try
                    drr("thamu") = NumEng2Thai(drr("thamu"))
                Catch ex As Exception

                End Try
                Try
                    drr("thafloor") = NumEng2Thai(drr("thafloor"))
                Catch ex As Exception

                End Try
                Try
                    drr("thasoi") = NumEng2Thai(drr("thasoi"))
                Catch ex As Exception

                End Try
                Try
                    drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
                Catch ex As Exception

                End Try
                Try
                    drr("tharoad") = NumEng2Thai(drr("tharoad"))
                Catch ex As Exception

                End Try
                Try
                    drr("zipcode") = NumEng2Thai(drr("zipcode"))
                Catch ex As Exception

                End Try
                Try
                    drr("tel") = NumEng2Thai(drr("tel"))
                Catch ex As Exception

                End Try
                Try
                    drr("fax") = NumEng2Thai(drr("fax"))
                Catch ex As Exception

                End Try
                Try
                    drr("Mobile") = NumEng2Thai(drr("Mobile"))
                Catch ex As Exception

                End Try
                Try
                    drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        ' cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(lct_ida) 'ผู้ดำเนิน

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        If txt_bsn.Text <> "" Then
            ws2.insert_taxno(txt_bsn.Text)
        End If
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        Try

            For Each drr As DataRow In cls_xml.DT_SHOW.DT14.Rows
                drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
                Try
                    drr("BSN_HOUSENO") = NumEng2Thai(drr("BSN_HOUSENO"))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        cls_xml.BSN_IDENTIFY = txt_bsn.Text

        Dim bao_master As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(_lcn_ida)
        cls_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(_lcn_ida)
        If dt.Rows.Count > 0 Then
            cls_xml.DT_MASTER.DT24 = dt
            cls_xml.DT_MASTER.DT24.TableName = "SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA"
        Else
            dt = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_DUMMY
            cls_xml.DT_MASTER.DT24 = dt
            cls_xml.DT_MASTER.DT24.TableName = "SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA"
        End If
        cls_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(_lcn_ida)
        cls_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(_lcn_ida, 1)
        cls_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(_lcn_ida, 2)
        cls_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        cls_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(_lcn_ida, 1)
        cls_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(_lcn_ida, 2)
        cls_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_lcn_ida)


        Dim lcnno_auto As String = ""
        Dim lcnno_format As String
        Dim MAIN_LCN_IDA As Integer = _lcn_ida
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        
        Try
            Dim dao_email As New DAO_CPN.TB_sysemail
            dao_email.GetDataby_CITIZEN_ID(txt_bsn.Text)
            cls_xml.EMAIL = dao_email.fields.EMAIL_FDA
        Catch ex As Exception

        End Try

        Dim bao_cpn As New BAO.ClsDBSqlcommand

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        cls_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(_CLS.CITIZEN_ID_AUTHORIZE)
        cls_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"
        For Each dr As DataRow In cls_xml.DT_SHOW.DT15.Rows
            Try
                dr("tel") = NumEng2Thai(dr("tel"))
            Catch ex As Exception

            End Try
            Try
                dr("fulladdr2") = NumEng2Thai(dr("fulladdr2"))
            Catch ex As Exception

            End Try
            Try
                dr("identify") = NumEng2Thai(dr("identify"))
            Catch ex As Exception

            End Try
        Next
        'cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(txt_bsn.Text)

        cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(txt_bsn.Text)
        For Each dr As DataRow In cls_xml.DT_SHOW.DT16.Rows
            Try
                dr("tel") = NumEng2Thai(dr("tel"))
            Catch ex As Exception

            End Try
            Try
                dr("fulladdr2") = NumEng2Thai(dr("fulladdr2"))
            Catch ex As Exception

            End Try
            Try
                dr("identify") = NumEng2Thai(dr("identify"))
            Catch ex As Exception

            End Try
        Next


        cls_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"





        cls_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(_lcn_ida)
        cls_xml.LCNNO_SHOW = dao_dalcn_MAIN.fields.lcntpcd & " " & dao_dalcn_MAIN.fields.LCNNO_DISPLAY
        'If _lcn_ida <> 0 Then
        '    Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
        '    dao_main2.GetDataby_IDA(_lcn_ida)

        '    Try
        '        'lcnno_format = 
        '        cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
        '    Catch ex As Exception

        '    End Try
        'Else
        '    cls_xml.HEAD_LCNNO = "-"
        'End If
        If _process = "125" Or _process = "126" Or _process = "135" Or _process = "136" Then
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(_lcn_ida)

            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    cls_xml.CHILD_LCNNO_NCT = "จ. " & CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    cls_xml.CHILD_LCNNO_NCT = dao_main2.fields.pvnabbr & " " & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                cls_xml.CHILD_LCNNO_NCT = NumEng2Thai(cls_xml.CHILD_LCNNO_NCT)
            Catch ex As Exception

            End Try

            Try
                Dim dao_main3 As New DAO_DRUG.ClsDBdalcn
                dao_main3.GetDataby_IDA(dao_main2.fields.MAIN_LCN_IDA)

                Try
                    'lcnno_format = 
                    'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                    If Right(Left(dao_main3.fields.lcnno, 3), 1) = "5" Then
                        cls_xml.HEAD_LCNNO_NCT = "จ. " & CStr(CInt(Right(dao_main3.fields.lcnno, 4))) & "/25" & Left(dao_main3.fields.lcnno, 2)
                    Else
                        cls_xml.HEAD_LCNNO_NCT = dao_main3.fields.pvnabbr & " " & CStr(CInt(Right(dao_main3.fields.lcnno, 5))) & "/25" & Left(dao_main3.fields.lcnno, 2)
                    End If

                    cls_xml.HEAD_LCNNO_NCT = NumEng2Thai(cls_xml.HEAD_LCNNO_NCT)
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        Else
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(_lcn_ida)



            Try
                'lcnno_format = 
                'class_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)

                If Right(Left(dao_main2.fields.lcnno, 3), 1) = "5" Then
                    cls_xml.HEAD_LCNNO_NCT = "จ. " & CStr(CInt(Right(dao_main2.fields.lcnno, 4))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                Else
                    cls_xml.HEAD_LCNNO_NCT = dao_main2.fields.pvnabbr & " " & CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
                End If

                cls_xml.HEAD_LCNNO_NCT = NumEng2Thai(cls_xml.HEAD_LCNNO_NCT)
            Catch ex As Exception

            End Try
        End If
        

        Dim dao As New DAO_CPN.TB_LOCATION_BSN
        dao.Getdata_by_fk_id2(_lct_ida)

        Try
            If dao.fields.BSN_NATIONALITY_CD = 1 Then
                cls_xml.dalcns.NATION = "ไทย"
            End If
            If _process = "114" Then
                cls_xml.dalcns.CHK_SELL_TYPE = "1"
            ElseIf _process = "116" Then
                cls_xml.dalcns.CHK_SELL_TYPE = "2"
            ElseIf _process = "117" Then
                cls_xml.dalcns.CHK_SELL_TYPE = "3"
            ElseIf _process = "115" Then
                cls_xml.dalcns.CHK_SELL_TYPE = "4"
            ElseIf _process = "127" Or _process = "123" Or _process = "125" Or _process = "129" Or _process = "131" Or _process = "133" Then
                cls_xml.dalcns.CHK_SELL_TYPE = "1"
            ElseIf _process = "128" Or _process = "124" Or _process = "126" Or _process = "130" Or _process = "132" Or _process = "134" Or _process = "135" Or _process = "136" Then
                cls_xml.dalcns.CHK_SELL_TYPE = "2"
            End If
        Catch ex As Exception

        End Try

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub


    Protected Sub btn_upload_VJ_Click(sender As Object, e As EventArgs) Handles btn_upload_VJ.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_UPLOAD_NCT.aspx?type_id=" & _process & "&process=" & _process & "&IDA=" & _CLS.IDA & "&lcn_ida=" & _lcn_ida & "&lct_ida=" & _lct_ida & "');", True)

    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
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




End Class