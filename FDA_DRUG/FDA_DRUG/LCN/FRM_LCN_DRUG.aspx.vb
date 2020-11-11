Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class FRM_LCN_DRUG
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
            _type = Request.QueryString("type")
            _process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        get_pvncd()
        If Request.QueryString("identify") <> "" Then
            If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                'AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ระบบตรวจพบว่าท่านเปิดการใช้งานหลายหน้าจอ จะทำการออกจากระบบโดยอัตโนมัติ');window.location.href = 'https://privus.fda.moph.go.th';", True)

            End If
        End If
        If Not IsPostBack Then
            If _process = "106" Then
                lbl_remark.Style.Add("display", "block")
            End If
            If _process = "201" Or _process = "202" Or _process = "203" Or _process = "204" Or _process = "205" Or _process = "206" Then
                lbl_head_org.Style.Add("display", "block")
                rdl_org.Style.Add("display", "block")
                Bind_rdl()

            End If


            'ให้รันฟังก์ชั่นลำดับที่ 2
            load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
            load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
            load_HL()


        End If
        UC_INFMT.Shows(_lct_ida)
    End Sub
    Sub Bind_rdl()
        Dim dao As New DAO_DRUG.TB_MAS_ORG_NAME_NYM
        dao.GetDataAll()

        rdl_org.DataSource = dao.datas
        rdl_org.DataBind()
    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffdrug"
        Else
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=drug"
        End If

        hl_pay.NavigateUrl = urls


        'hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & _lct_ida
        'If Request.QueryString("staff") <> "" Then
        '    hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        'End If
    End Sub
    Private Sub load_lbl_name()

        Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu.GetDataby_Process2(_process)

        Dim dao_menu2 As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu2.GetDataby_Process2(_process_for)
        If String.IsNullOrEmpty(_process_for) = False Then
            lbl_name_2.Text = " (" & dao_menu2.fields.NAME & ") > "
        End If

        lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง

    End Sub

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU       'ประกาศชื่อตัวแปร DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_Process(_process)             'ดึง dao.GetDataby_Process เพื่อมาโชว์ที่ Gridview ที่เป็นค่า String

        'bao.SP_LCN_DRUG_TYPE_MENU(_CLS.LCNSID, dao.fields.NAME)
        'bao.SP_DALCN_By_lcntpcd(_CLS.LCNSID_CUSTOMER, dao.fields.NAME) 'เรียกใช้ SP  bao.SP_DALCN_By_lcntpcd
        Dim process As String = _process
        If _process = "110" Then
            process = "106" 'ผย
        ElseIf _process = "111" Then
            If _type = "1" Then
                process = "101"  'ขย1
            ElseIf _type = "2" Then
                process = "102"  'ขย2
            ElseIf _type = "3" Then
                process = "103"  'ขย3
            ElseIf _type = "4" Then
                process = "104"  'ขย4
            Else

            End If
        ElseIf _process = "112" Then
            If _type = "1" Then
                process = "101"  'ขย1
            ElseIf _type = "2" Then
                process = "102"  'ขย2
            ElseIf _type = "3" Then
                process = "103"  'ขย3
            ElseIf _type = "4" Then
                process = "104"  'ขย4
            Else

            End If
        ElseIf _process = "113" Then
            process = "105" 'นย
        ElseIf _process = "114" Then
            process = "106" 'ผย
        ElseIf _process = "115" Then
            process = "101" 'ขย
        ElseIf _process = "116" Then
            process = "105" 'นย
        ElseIf _process = "117" Then
            If _type = "1" Then
                process = "101"  'ขย1
            ElseIf _type = "2" Then
                process = "102"  'ขย2
            ElseIf _type = "3" Then
                process = "103"  'ขย3
            ElseIf _type = "4" Then
                process = "104"  'ขย4
            Else

            End If
        ElseIf _process = "118" Then
            If _type = "1" Then
                process = "101"  'ขย1
            ElseIf _type = "2" Then
                process = "102"  'ขย2
            ElseIf _type = "3" Then
                process = "103"  'ขย3
            ElseIf _type = "4" Then
                process = "104"  'ขย4
            Else

            End If
        End If
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(process)
        bao.SP_CUSTOMER_LCN_BY_FK_IDA(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, _CLS.CITIZEN_ID_AUTHORIZE)
        'If Request.QueryString("identify") <> "" Then
        '    bao.SP_CUSTOMER_LCN_BY_FK_IDA_AND_PVNCD(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, Request.QueryString("identify"), _pvncd)
        'Else
        '    bao.SP_CUSTOMER_LCN_BY_FK_IDA_AND_PVNCD(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, _CLS.CITIZEN_ID_AUTHORIZE, _pvncd)
        'End If

        GV_lcnno.DataSource = bao.dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.Groups)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub

#Region "GRIDVIEW"

    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim btn_drug_group As Button = DirectCast(e.Row.FindControl("btn_drug_group"), Button)
            Dim btn_lcn As Button = DirectCast(e.Row.FindControl("btn_lcn"), Button)
            Dim btn_leaves As Button = DirectCast(e.Row.FindControl("btn_leaves"), Button)
            Dim btn_sell As Button = DirectCast(e.Row.FindControl("btn_sell"), Button)
            Dim id As String = GV_lcnno.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            'btn_Select.Style.Add("display", "none")
            btn_lcn.Style.Add("display", "none")
            btn_leaves.Style.Add("display", "none")
            btn_drug_group.Style.Add("display", "none")
            btn_sell.Style.Add("display", "none")
            Dim bool As Boolean = False
            Dim bool2 As Boolean = False
            If _process = "106" Then
                Dim dao_count As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
                'count_drug_group
                btn_drug_group.Style.Add("display", "block")
                Try
                    bool = dao_count.count_drug_group(id)
                Catch ex As Exception

                End Try
                'If bool = False Then
                '    btn_drug_group.Style.Add("display", "none")
                'Else
                btn_drug_group.Style.Add("display", "block")
                'End If

            ElseIf _process = "101" Then
                Dim dao_ky As New DAO_DRUG.ClsDBdalcn
                dao_ky.GetDataby_IDA(id)
                Dim sell_type As String = ""
                Try
                    sell_type = Trim(dao_ky.fields.CHK_SELL_TYPE1)
                Catch ex As Exception

                End Try
                If sell_type <> "" And sell_type <> "0" Then
                    btn_sell.Style.Add("display", "block")
                    Dim dao_c As New DAO_DRUG.TB_DALCN_SELL_TYPE

                    Try
                        bool = dao_c.count_sell(id)
                    Catch ex As Exception

                    End Try
                    If bool = False Then
                        btn_Select.Style.Add("display", "none")
                    Else
                        btn_Select.Style.Add("display", "block")
                    End If
                Else
                    btn_sell.Style.Add("display", "none")
                End If

            End If
            'If _process = 101 Then
            '    btn_Select.Style.Add("display", "block")
            'ElseIf _process = 102 Then
            '    btn_Select.Style.Add("display", "block")
            'ElseIf _process = 103 Then
            '    btn_Select.Style.Add("display", "block")
            'ElseIf _process = 104 Then
            '    btn_Select.Style.Add("display", "block")
            'ElseIf _process = 105 Then
            '    btn_Select.Style.Add("display", "block")
            '    btn_lcn.Style.Add("display", "block")
            'ElseIf _process = 106 Then
            '    btn_Select.Style.Add("display", "block")
            '    btn_lcn.Style.Add("display", "block")
            'ElseIf _process = 107 Then
            '    btn_Select.Style.Add("display", "block")
            'ElseIf _process = 108 Then
            '    btn_Select.Style.Add("display", "block")
            'ElseIf _process = 109 Then
            '    btn_Select.Style.Add("display", "block")
            'ElseIf _process = 110 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 111 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 112 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 113 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 114 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 115 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 116 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 117 Then
            '    btn_leaves.Style.Add("display", "block")
            'ElseIf _process = 118 Then
            '    btn_leaves.Style.Add("display", "block")
            'End If
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(id)

            'ไม่ให้แสดงคำว่า เลือกข้อมูล ถ้าสถานะไม่ใช่อนุมัติ
            If dao.fields.STATUS_ID <> 8 Then
                btn_lcn.Visible = False
            End If

        End If

    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

        ElseIf e.CommandName = "leaves" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Response.Redirect("FRM_LCN_NCT.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida & "&process=" & _process)
            'Response.Redirect("../EDIT_LOCATION/FRM_EDIT_LOCATION_MAIN.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida & "&process=" & process & "&process2=" & process2)

        ElseIf e.CommandName = "lcn" Then
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            _CLS.LCNNO = dao.fields.lcnno.ToString()
            _CLS.LCNSID_CUSTOMER = dao.fields.lcnsid.ToString()
            _CLS.PVCODE = dao.fields.pvncd.ToString()
            _CLS.IDA = str_ID
            Session("CLS") = _CLS

            ' Response.Redirect("../MAIN/FRM_NODE.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())
            Response.Redirect("../MAIN/FRM_NEWS.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida)
        ElseIf e.CommandName = "drug_group" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('" & "POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD.aspx?ida=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
        ElseIf e.CommandName = "sell" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups4('" & "POPUP_LCN_SELL_TYPE.aspx?ida=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
        End If
    End Sub


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub
#End Region

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()                             'เรียกฟังก์ชั่น  load_GV_lcnno   มาใช้งาน
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        If txt_bsn.Text = "" Then
            alert("กรุณากรอกเลขบัตรผู้ดำเนินกิจการ")
        Else
            If String.IsNullOrEmpty(_process) = False Then  'ถ้าให้ค่า _process เป็นค่าว่าง จะไม่เป็นความจริง
                If _process = "201" Or _process = "202" Or _process = "203" Or _process = "204" Or _process = "205" Or _process = "206" Then
                    If rdl_org.SelectedValue = "" Then
                        alert("กรุณาเลือกประเภทหน่วยงาน")
                    Else
                        Bind_PDF()
                    End If

                Else
                    Bind_PDF()
                End If
                'เรียกฟังก์ชั่น  Bind_PDF มาใช้งาน
            Else
                alert("กรุณาเลือกประเภทใบอนุญาตก่อนทำการดาวน์โหลด")  'ถ้าค่าว่างจะ ERROR
            End If
        End If



    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
    Sub Bind_PDF()
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
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 0

        Try
            lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, _CLS.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, _CLS.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        If cls_xml.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        If txt_bsn.Text <> "" Then
            ws2.insert_taxno(txt_bsn.Text)
        End If

        'Dim lcnno_auto As String = ""
        'Dim lcnno_format As String
        'Dim MAIN_LCN_IDA As Integer = 0
        'Dim dao_main As New DAO_DRUG.ClsDBdalcn
        'dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        'Try
        '    lcnno_auto = dao_main.fields.lcnno
        'Catch ex As Exception

        'End Try
        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If
        '        'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try
        'If MAIN_LCN_IDA <> 0 Then
        '    Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
        '    dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

        '    Try
        '        'lcnno_format = 
        '        cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
        '    Catch ex As Exception

        '    End Try

        'End If


        'Dim bao_cpn As New BAO.ClsDBSqlcommand

        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        'cls_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(_CLS.CITIZEN_ID_AUTHORIZE)
        'cls_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"

        'cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(txt_bsn.Text)
        'cls_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"


        Dim bao_master As New BAO_MASTER

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_lcn_ida)
        ' End If
        cls_xml.BSN_IDENTIFY = txt_bsn.Text


        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao.Getdata_by_fk_id2(_lct_ida)
        If _process = "201" Or _process = "202" Or _process = "203" Or _process = "204" Or _process = "205" Or _process = "206" Then
            cls_xml.dalcns.Co_name = rdl_org.SelectedValue
        End If
        Try
            If dao.fields.BSN_NATIONALITY_CD = 1 Then
                cls_xml.dalcns.NATION = "ไทย"
            End If
        Catch ex As Exception

        End Try
        cls_xml.DT_SHOW.DT20 = bao_show.SP_PHR_FUNCTION()


        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub


    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        If Request.QueryString("staff") = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_UPLOAD_ATTACH.aspx?type_id=" & _process & "&process=" & _process & "&IDA=" & _lct_ida & "');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_UPLOAD_ATTACH.aspx?type_id=" & _process & "&process=" & _process & "&IDA=" & _lct_ida & "&staff=1');", True)
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub
    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
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

    Protected Sub GV_lcnno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GV_lcnno.SelectedIndexChanged

    End Sub
End Class