Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI
Public Class FRM_SUBSTITUTE_NCT_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _rgt_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _rgt_ida = Request.QueryString("rgt_ida")
        Catch ex As Exception

        End Try
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
        RunSession()
        If Not IsPostBack Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Try
                dt = bao.SP_DRRGT_BY_IDA(Request.QueryString("rgt_ida"))
                lbl_rgtno.Text = dt(0)("rgtno_display")
            Catch ex As Exception

            End Try

            Try
                Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
                dao_drrgt.GetDataby_IDA(_rgt_ida)

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
        Dim cls As New CLASS_GEN_XML.DRRGT_SUB(_CLS.CITIZEN_ID, _CLS.LCNSID, "1", _CLS.PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRGT_SUB                                                                 ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()



        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        dao_drrgt.GetDataby_IDA(Request.QueryString("rgt_ida"))
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(dao_drrgt.fields.FK_LCN_IDA)
        Catch ex As Exception

        End Try

        'Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        'Try
        '    dao_sub.GetDatabyIDA(Request.QueryString("IDA"))
        'Catch ex As Exception

        'End Try

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
        Dim lcnno As String = ""
        Dim lcnsid As String = ""
        Try
            rcvno_auto = "" 'dao_sub.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_drrgt.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = "" 'dao_sub.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_drrgt.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao_drrgt.fields.lcnsid
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_drrgt.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_drrgt.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_drrgt.fields.thadrgnm & " / " & dao_drrgt.fields.engdrgnm
        Catch ex As Exception

        End Try
        Try
            If dao_drrgt.fields.lcntpcd.Contains("ผยบ") Or dao_drrgt.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao_drrgt.fields.lcntpcd.Contains("ผย") Then
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
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
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
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                cls_xml.TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                cls_xml.TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_dg As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
            dao_dg.GetDataby_rgttpcd(dao_drrgt.fields.rgttpcd)
            cls_xml.CHK_LCN_SUBTYPE = dao_dg.fields.subtpcd
        Catch ex As Exception

        End Try
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.RCVNO_FORMAT = rcvno_format
        cls_xml.RGTNO_FORMAT = rgtno_format
        'cls_xml.TABEAN_TYPE1 = LCN_TYPE


        cls_xml.DRUG_NAME = drug_name        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml

        '------------------SHOW
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        If Request.QueryString("identify") <> "" Then
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(Request.QueryString("identify"), _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        Else
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        End If
        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_drrgt.fields.FK_LCN_IDA) 'ผู้ดำเนิน
        Catch ex As Exception

        End Try

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
            Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            dao.GetDatabyIDA(IDA)
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

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../SUBSTITUTE_TABEAN/FRM_SUBSTITUTE_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&Process=" & _process_id & "');", True)

            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_DRRGT_SUBSTITUTE_BY_FK_IDA(Request.QueryString("rgt_ida"))
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
End Class