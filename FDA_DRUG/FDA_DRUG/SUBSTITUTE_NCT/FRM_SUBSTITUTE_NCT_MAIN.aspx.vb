Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_SUBSTITUTE_NCT_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _IDA As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _IDA = Request.QueryString("lcn_ida")
        Catch ex As Exception

        End Try

        Try
            _process_for = Request.QueryString("process_for")
        Catch ex As Exception

        End Try
        Try
            _type = Request.QueryString("type")
        Catch ex As Exception

        End Try
        Try
            _lct_ida = Request.QueryString("lct_ida")

        Catch ex As Exception

        End Try
        Try
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก

        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Try
                'dt = bao.SP_DRRGT_BY_IDA(Request.QueryString("rgt_ida"))
                'lbl_rgtno.Text = dt(0)("rgtno_display")
            Catch ex As Exception

            End Try

            Try
                'Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
                'dao_drrgt.GetDataby_IDA(_rgt_ida)

                'Bind_ddl_phr(dao_drrgt.fields.FK_LCN_IDA)
            Catch ex As Exception

            End Try
            'load_HL()
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
    Private Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        'If rcb_phr_name.SelectedValue = "0" Then
        '    alert("กรุณาเลือกเลขที่ใบอนุญาต")
        'Else
        Bind_PDF()
        'End If

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
        Dim bao_mas As New BAO_MASTER
        Dim cls As New CLASS_GEN_XML.DALCN_NCT_SUB(_CLS.CITIZEN_ID, _CLS.LCNSID, "1", _CLS.PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN_NCT_SUBSTITUTE                                                                ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()

        Dim identify As String = ""

        Dim dao As New DAO_DRUG.TB_DALCN_NCT_SUBSTITUTE
        dao.Getdata_by_ID(Request.QueryString("IDA"))
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_dal.GetDataby_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Try
            dao_bsn.GetDataby_LCN_IDA(dao_dal.fields.IDA)
        Catch ex As Exception

        End Try
        Try
            identify = dao_dal.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Try
            cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dal.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        Catch ex As Exception

        End Try


        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, identify) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_5"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(identify, _CLS.LCNSID) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, identify) 'ที่เก็บ
        If cls_xml.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        'If txt_bsn.Text <> "" Then
        '    ws2.insert_taxno(txt_bsn.Text)
        'End If


        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(dao_bsn.fields.BSN_IDENTIFY) 'ผู้ดำเนิน
            cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try


        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim MAIN_LCN_IDA As Integer = 0
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(dao_dal.fields.IDA)
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


        Dim bao_cpn As New BAO.ClsDBSqlcommand

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Try
            cls_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_bsn.fields.BSN_IDENTIFY)
            cls_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"
        Catch ex As Exception

        End Try

        Try
            cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_bsn.fields.BSN_IDENTIFY)
            cls_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"
        Catch ex As Exception

        End Try


        Dim bao_master As New BAO_MASTER
        Try
            cls_xml.DT_SHOW.DT10 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao_dal.fields.IDA)
        Catch ex As Exception

        End Try

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(dao_dal.fields.IDA)
        ' End If
        cls_xml.BSN_IDENTIFY = dao_bsn.fields.BSN_IDENTIFY
        cls_xml.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RCVNO_FORMAT = ""

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
            Dim dao As New DAO_DRUG.TB_DALCN_NCT_SUBSTITUTE
            dao.Getdata_by_ID(IDA)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                Dim _process_id As Integer = 0

                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                Try
                    dao_tr.GetDataby_IDA(tr_id)
                    _process_id = dao_tr.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                'Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                'dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../SUBSTITUTE_NCT/POPUP_SUBSTITUTE_NCT_CONFIRM.aspx.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&Process=" & _process_id & "');", True)

            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'Try
        '    dt = bao.SP_DRRGT_SUBSTITUTE_BY_FK_IDA(Request.QueryString("rgt_ida"))
        'Catch ex As Exception

        'End Try

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../SUBSTITUTE_NCT/POPUP_SUBSTITUTE_NCT_UPLOAD.aspx?IDA=" & Request.QueryString("lcn_ida") & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "');", True)
    End Sub
End Class