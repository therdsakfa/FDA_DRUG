Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class FRM_RGT_EDIT_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _rgt_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()
        Try
            _rgt_ida = Request.QueryString("rgt_ida")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Request.QueryString("staff") <> "" Then
            If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                ' AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("staff"), 0, HttpContext.Current.Request.Url.AbsoluteUri)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ระบบตรวจพบว่าท่านเปิดการใช้งานหลายหน้าจอ จะทำการออกจากระบบโดยอัตโนมัติ');window.location.href = 'https://privus.fda.moph.go.th';", True)
            End If
        End If
        If Not IsPostBack Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Try
                dt = bao.SP_DRRGT_BY_IDA(Request.QueryString("rgt_ida"))
                lbl_rgtno.Text = dt(0)("rgtno_display")
            Catch ex As Exception

            End Try

            Try
                'dt = bao.SP_DRRGT_BY_IDA(Request.QueryString("rgt_ida"))
                'lbl_rgtno.Text = dt(0)("rgtno_display")
                Dim dao_e As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                dao_e.GetDataby_NEWCODE(Request.QueryString("newcode"))
                lbl_rgtno.Text = dao_e.fields.register


            Catch ex As Exception

            End Try
            Try
                Dim dao_e As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                dao_e.GetDataby_NEWCODE(Request.QueryString("newcode"))
                Dim dao_lcn As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
                dao_lcn.GetDataby_u1(dao_e.fields.Newcode_not)
                Bind_ddl_phr(dao_lcn.fields.IDA_dalcn)

            Catch ex As Exception

            End Try
            'Try
            '    'Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
            '    'dao_drrgt.GetDataby_IDA(_rgt_ida)
            '    Dim dao_drrgt As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
            '    dao_drrgt.GetDataby_IDA_drrgt(_rgt_ida)

            '    Dim dao_lcn As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
            '    dao_lcn.GetDataby_u1(dao_drrgt.fields.Newcode_not)
            '    Bind_ddl_phr(dao_lcn.fields.IDA_dalcn)
            'Catch ex As Exception

            'End Try
            load_HL()
        End If

    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify")
        End If

        hl_pay.NavigateUrl = urls


        'hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & _lct_ida
        'If Request.QueryString("staff") <> "" Then
        '    hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        'End If
    End Sub
    Public Sub Bind_ddl_phr(ByVal FK_IDA As Integer)
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        dt = bao.SP_GET_DDL_PHR_BY_FK_IDA(FK_IDA)
        rcb_phr_name.DataSource = dt
        rcb_phr_name.DataValueField = "PHR_CTZNO"
        rcb_phr_name.DataTextField = "PHR_NAME"
        rcb_phr_name.DataBind()


        Dim item As New RadComboBoxItem
        Dim item2 As New RadComboBoxItem
        item.Text = "กรุณาเลือกผู้ปฏิบัติการ"
        item.Value = "0"

        If Request.QueryString("staff") <> "" Then
            item2.Text = "ไม่ระบุผู้ปฏิบัติการ"
            item2.Value = "9999999999999"
        Else
        End If

        rcb_phr_name.Items.Insert(0, item)
        rcb_phr_name.Items.Insert(1, item2)
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
    Private Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        If rcb_phr_name.SelectedValue = "0" Or rcb_phr_name.SelectedItem.Text = "" Then
            alert("กรุณาเลือกผู้ปฏิบัติการ")
        Else
            Bind_PDF()
        End If

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

    Private Sub convert_Database_To_XML(ByVal path As String)
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.EDIT_DRRGT(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, "1", _CLS.PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_EDIT_DRRGT                                                                     ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 0

        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        dao_drrgt.GetDataby_IDA(_rgt_ida)

        Dim dao_sc As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        'dao_sc.GetDataby_IDA_drrgt(_rgt_ida)
        dao_sc.GetDataby_NEWCODE(Request.QueryString("newcode"))

        Dim dao_lcn_e As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
        Try
            dao_lcn_e.GetDataby_u1(dao_sc.fields.Newcode_not)
        Catch ex As Exception

        End Try


        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(dao_lcn_e.fields.IDA_dalcn)
        Catch ex As Exception

        End Try


        Dim lcnno As String = ""
        Dim rcvno_format As String = ""
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim TABEAN_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim rcvno As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnsid As String = ""
        Try
            rcvno_auto = dao_sc.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_sc.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = "" 'dao_drrgt.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_sc.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_sc.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_sc.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_sc.fields.thadrgnm & " / " & dao_sc.fields.engdrgnm
        Catch ex As Exception

        End Try
        Try
            If dao_lcn_e.fields.lcntpcd.Contains("ผยบ") Or dao_lcn_e.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao_lcn_e.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            If Right(Left(dao_lcn_e.fields.lcnno, 3), 1) <> "5" Then
                LCNNO_FORMAT = dao_lcn_e.fields.pvnabbr & " " & CStr(CInt(Right(dao_lcn_e.fields.lcnno, 5))) & "/25" & Left(dao_lcn_e.fields.lcnno, 2)
            Else
                LCNNO_FORMAT = dao_lcn_e.fields.pvnabbr & " " & CStr(CInt(Right(dao_lcn_e.fields.lcnno, 4))) & "/25" & Left(dao_lcn_e.fields.lcnno, 2)
            End If

        Catch ex As Exception

        End Try
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Dim dt_rgtno As New DataTable
        Dim bao_rgtno As New BAO.ClsDBSqlcommand
        dt_rgtno = bao_rgtno.SP_DRRGT_RGTNO_DISPLAY_BY_IDA(_rgt_ida)
        Try
            rgtno_format = dt_rgtno(0)("rgtno_display")
        Catch ex As Exception

        End Try

        cls_xml.LCN_TYPE = LCN_TYPE
        cls_xml.LCNTPCD_GROUP = LCNTPCD_GROUP
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.RCVNO_FORMAT = "" 'rcvno_format
        cls_xml.RGTNO_FORMAT = rgtno_format

        cls_xml.APP_TYPE1 = ""
        cls_xml.APP_TYPE2 = ""
        cls_xml.APP_TYPE2_PURPOSE = ""
        cls_xml.APP_TYPE3 = ""
        cls_xml.APP_TYPE3_PURPOSE = ""
        cls_xml.DRUG_NAME = drug_name
        cls_xml.OLD_NAME_TH = dao_sc.fields.thadrgnm
        cls_xml.OLD_NAME_EN = dao_sc.fields.engdrgnm
        Try
            cls_xml.PHR_IDENTIFY = rcb_phr_name.SelectedValue
            cls_xml.PHR_NAME = rcb_phr_name.SelectedItem.Text
        Catch ex As Exception

        End Try


        Dim UNIT_NAME As String = ""
        Dim dao_package As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
        dao_package.GetDataby_FKIDA(dao_drrgt.fields.IDA)
        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
        Try
            dao_unit.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
            UNIT_NAME = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
        Catch ex As Exception
        End Try
        cls_xml.UNIT_NAME = UNIT_NAME
        'Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
        'dao_color.GetDataby_FK_IDA(dao.fields.FK_IDA)
        'cls_xml.DRRGT_COLORs = dao_color.fields
        Dim bao_mas As New BAO_MASTER

        '------------------SHOW
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Try
            If Request.QueryString("identify") <> "" Then
                cls_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(Request.QueryString("identify"), lcnsid) 'ข้อมูลบริษัท
            Else
                cls_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, lcnsid) 'ข้อมูลบริษัท
            End If
        Catch ex As Exception

        End Try
        Try
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.GetDataby_IDA(dao_lcn_e.fields.IDA_dalcn)
            cls_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dal.fields.FK_IDA)
            cls_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        Catch ex As Exception

        End Try

        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn_e.fields.IDA_dalcn) 'ผู้ดำเนิน

            cls_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception
            cls_xml.BSN_THAIFULLNAME = ""
        End Try


        '-----------------------------MASTER
        'cls_xml.DT_MASTER.DT1 = bao_mas.SP_MASTER_driowa() 'สาร เอาออก
        'cls_xml.DT_MASTER.DT2 = bao_mas.SP_MASTER_drsunit() 'หน่วย


        Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                     'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings 'ทำการดาวห์โหลดลงเครื่อง
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
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            dao.GetDatabyIDA(IDA)
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                Dim _process_id As String = 0

                'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                'Try
                '    If Len(tr_id) >= 9 Then
                '        dao_tr.GetDataby_TR_ID_Process(tr_id, _process)
                '        _process_id = dao.fields.PROCESS_ID
                '    Else
                '        dao_tr.GetDataby_IDA(tr_id)
                '        _process_id = dao.fields.PROCESS_ID
                '    End If

                'Catch ex As Exception

                'End Try

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../RGT_EDIT/FRM_RGT_EDIT_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & item("TR_ID").Text & "&process=" & Request.QueryString("process") & "&newcode=" & Request.QueryString("newcode") & "');", True)
            ElseIf e.CommandName = "_report" Then
                Dim url As String = ""
                url = "../TABEAN_YA_STAFF/FRM_APPOINTMENT2.aspx?IDA=" & IDA & "&STATUS_ID=" & item("STATUS_ID").Text & "&status=" & item("STATUS_ID").Text & "&p=1"
                'RunSession()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "'); ", True)
            ElseIf e.CommandName = "_trid" Then
                Dim TR_ID1 As String = ""
                Dim _ProcessID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                Dim dao_rg As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                Try
                    dao_rg.GetDatabyIDA(item("IDA").Text)
                Catch ex As Exception

                End Try
                Try
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                Catch ex As Exception
                    bao_tran.CITIZEN_ID = ""
                End Try
                Try
                    bao_tran.CITIZEN_ID_AUTHORIZE = dao_rg.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception
                    bao_tran.CITIZEN_ID_AUTHORIZE = ""
                End Try
                Try
                    _ProcessID = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                TR_ID1 = bao_tran.insert_transection_new("130099")
                Try
                    dao_rg.fields.TR_ID = TR_ID1
                Catch ex As Exception

                End Try

                dao_rg.update()

                'Try
                '    Dim dao_rq As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                '    Try
                '        dao_rq.GetDatabyIDA(IDA)
                '        dao_rq.fields.TR_ID = TR_ID1
                '        dao_rq.update()
                '    Catch ex As Exception

                '    End Try
                'Catch ex As Exception

                'End Try

                RadGrid1.Rebind()

            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim _process_id As Integer = 0
            Dim IDA As String = item("IDA").Text

            Dim btn_report As LinkButton = DirectCast(item("btn_report2").Controls(0), LinkButton)
            Dim btn_trid As LinkButton = DirectCast(item("btn_trid").Controls(0), LinkButton)

            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            Dim tr_id As String = 0
            dao.GetDatabyIDA(IDA)

            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If tr_id = 0 Then
                btn_trid.Style.Add("display", "block")
            Else
                btn_trid.Style.Add("display", "none")
            End If
            Try
                If dao.fields.STATUS_ID >= 3 Then
                    btn_report.Style.Add("display", "block")
                Else
                    btn_report.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            'dt = bao.SP_DRRGT_EDIT_REQUEST_BY_FK_IDA(Request.QueryString("rgt_ida"))
            'dt = bao.SP_DRRGT_EDIT_REQUEST_BY_NEWCODE(Request.QueryString("newcode"))
            dt = bao.SP_DRRGT_EDIT_REQUEST_BY_NEWCODE_PROCESS(Request.QueryString("newcode"), _process)
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
End Class