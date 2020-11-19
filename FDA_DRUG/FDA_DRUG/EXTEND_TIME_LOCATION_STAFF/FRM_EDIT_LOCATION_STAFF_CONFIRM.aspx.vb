Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_STAFF_EDIT_LOCATION_CONFIRM2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _process As String
    Private _YEARS As String
    Private _TR_ID As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _IDA = Request.QueryString("IDA")
        _process = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'txt_app_date.Text = Date.Now.ToShortDateString()
            HiddenField2.Value = 0
            BindData_PDF()
            Bind_ddl_Status_staff()
            load_fdpdtno()
            'UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _process)
            set_hide(_IDA)

            'Try
            '    Dim dao As New DAO_DRUG.TB_lcnrequest
            '    dao.GetDataby_IDA(_IDA)
            '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            '    dao_up.GetDataby_IDA(dao.fields.TR_ID)
            '    If dao_up.fields.PROCESS_ID = "100741" Then
            '        btn_drug_group.Style.Add("display", "block")
            '    End If
            'Catch ex As Exception

            'End Try


        End If
        set_lbl()
        show_btn(_IDA)
    End Sub

    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.TB_lcnrequest
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 6 Then
            btn_preview.Enabled = False
            ' btn_cancel.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
            'btn_preview.CssClass = "btn-danger btn-lg"

        End If


    End Sub
    Public Sub set_hide(ByVal IDA As String)
        Dim dao As New DAO_DRUG.TB_lcnrequest
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID >= 8 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"

            ddl_cnsdcd.Style.Add("display", "none")
        End If

        'Try
        '    Dim dao_u As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        '    dao_u.GetDataby_IDA(_TR_ID)
        '    If dao_u.fields.PROCESS_ID = "104" Then
        '        ddl_template.Style.Add("display", "block")
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    Sub set_lbl()
        Dim dao As New DAO_DRUG.TB_lcnrequest
        dao.GetDataby_IDA(_IDA)

        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        Try
            dao_s.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
            lbl_staff_consider.Text = dao_s.fields.STAFF_OFFER_NAME
        Catch ex As Exception
            lbl_staff_consider.Text = "-"
        End Try
        Try
            lbl_app_date.Text = CDate(dao.fields.app_date).ToShortDateString()
        Catch ex As Exception
            lbl_app_date.Text = "-"
        End Try
        Try
            lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
        Catch ex As Exception

        End Try

        Try
            dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 2)
            lbl_Status.Text = dao_stat.fields.STATUS_NAME
        Catch ex As Exception

        End Try


    End Sub
    Sub load_fdpdtno()
        Dim bao As New BAO.ClsDBSqlcommand
        'lbl_fdpdtno.Text = get_fdpdtno().Substring(0, 2) & "-" & get_fdpdtno().Substring(2, 1) & "-" & get_fdpdtno().Substring(3, 5) & "-" & get_fdpdtno().Substring(8, 1) & "-"
        'lbl_fdpdtno2.Text = _CLS.IDA    'ปรับให้runno

    End Sub
    Function get_fdpdtno() As String
        Dim fdpdtno As String = String.Empty
        Dim pvncd As String = String.Empty
        Dim lcntypecd As String = String.Empty
        Dim lcnno_num As String = String.Empty
        Dim tpye As String = String.Empty
        Dim REF_NO As String = String.Empty
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao As New DAO_DRUG.TB_lcnrequest
        Dim bao As New BAO.ClsDBSqlcommand
        If Len(_TR_ID) >= 9 Then
            dao_up.GetDataby_TR_ID_Process(_TR_ID, _process)
        Else
            dao_up.GetDataby_IDA(_TR_ID)
        End If
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        'pvncd = dao.fields.pvncd.ToString()
        lcntypecd = dao.fields.lcntpcd.ToString()
        lcnno_num = dao.fields.lcnno.ToString().Trim().Substring(2, 5)
        If _CLS.PVCODE = 10 Then
            If lcntypecd = "1" Then
                tpye = "1"
            ElseIf lcntypecd = "2" Then
                tpye = "3"
            End If
        Else
            If lcntypecd = "1" Then
                tpye = "2"
            ElseIf lcntypecd = "2" Then
                tpye = "4"
            End If
        End If
        fdpdtno = pvncd & lcntypecd & lcnno_num & tpye
        Return fdpdtno
    End Function

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim fdpdtno As String = String.Empty
        'Dim num As Integer = 0
        'Dim str_num As String = String.Empty

        'Dim bao_gen As New BAO.GenNumber
        'Dim rcvno As String = ""

        'rcvno = bao_gen.GEN_LCNNO_RCVNO(_IDA, _CLS.PVCODE, 0)
        ''str_num = String.Format("{0:0000}", num.ToString("0000"))
        ''fdpdtno = str_num
        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(_TR_ID)
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        'dao.fields.lcnno = rcvno 'fdpdtno
        'dao.fields.STATUS_ID = Integer.Parse(ddl_cnsdcd.SelectedItem.Value())
        'dao.fields.cnccd = 1
        'dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        'dao.update()
        'Dim xmlname As String = NAME_OUTPUT_PDF("DA", _ProcessID, dao_up.fields.YEAR, dao_up.fields.ID)
        'BindData_PDF()
        'alert("ยืนยันเรียบร้อยแล้ว")


        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(_TR_ID)
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)

        Dim dao As New DAO_DRUG.TB_lcnrequest
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer

        dao.GetDataby_IDA(_IDA)
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)
        If Len(_TR_ID) >= 9 Then
            dao_up.GetDataby_TR_ID_Process(_TR_ID, _process)
        Else
            dao_up.GetDataby_IDA(_TR_ID)
        End If
        Dim PROCESS_ID As Integer = dao.fields.PROCESS_ID

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
        dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.fields.PROCESS_ID = 0
        dao_date.insert()


        If STATUS_ID = 3 Then
            dao.fields.STATUS_ID = STATUS_ID
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)


            dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
            dao.update()
            '-----------------ลิ้งไปหน้าคีย์มือ----------
            Response.Redirect("POPUP_EXTEND_TIME_LOCATION_STAFF_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            '--------------------------------
            alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        ElseIf STATUS_ID = 6 Then
            Response.Redirect("POPUP_EXTEND_TIME_LOCATION_STAFF_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        ElseIf STATUS_ID = 8 Then
                Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_p.GetDataby_Process_ID(PROCESS_ID)
                Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID
                Dim bao2 As New BAO.GenNumber
                Dim LCNNO As Integer
                LCNNO = bao2.GEN_NO_01(con_year(Date.Now.Year), _CLS.PVCODE, GROUP_NUMBER, PROCESS_ID, 0, 0, _IDA, "")
                'dao.fields.lcnno = LCNNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year), LCNNO)
                dao.fields.STATUS_ID = STATUS_ID
            'Dim chw As String = ""
            'Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            'Try
            '    dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
            '    chw = dao_cpn.fields.thacwabbr
            'Catch ex As Exception

            'End Try
            'If chw <> "" Then
            '    dao.fields.LCNNO_DISPLAY = chw & " " & bao.FORMAT_NUMBER_YEAR_FULL(con_year(Date.Now.Year), LCNNO) ' & " (ขย." & GROUP_NUMBER & ")"
            'Else
            '    dao.fields.LCNNO_DISPLAY = bao.FORMAT_NUMBER_YEAR_FULL(con_year(Date.Now.Year), LCNNO) ' & " (ขย." & GROUP_NUMBER & ")"
            'End If
            dao.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_LCN_LCNNO_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                '--------------------------------
                alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
                'alert_reload("ดำเนินการอนุมัติเรียบร้อยแล้ว")
            ElseIf STATUS_ID = 7 Then
            Response.Redirect("POPUP_EXTEND_TIME_LOCATION_STAFF_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            '_TR_ID = Request.QueryString("TR_ID")
            '_IDA = Request.QueryString("IDA")
            'dao.update()
            'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        End If



    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")

        Dim dao_n As New DAO_DRUG.ClsDBdalcn
        dao_n.GetDataby_IDA(_IDA)
        Try
            If dao_n.fields.SEND_POST = 1 Then
                '  Label2.Text = "รับด้วยตัวเอง"
            ElseIf dao_n.fields.SEND_POST = 2 Then
                '   Label2.Text = "ส่งไปรษณีย์"
            Else
                '   Label2.Text = "รับด้วยตัวเอง"
            End If
        Catch ex As Exception

        End Try

        Bind_ddl_Status_staff()
        BindData_PDF()
    End Sub

    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.TB_lcnrequest
        dao.GetDataby_IDA(_IDA)

        If dao.fields.STATUS_ID <= 2 Then
            int_group_ddl = 1
        ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
            int_group_ddl = 2
        ElseIf dao.fields.STATUS_ID >= 6 Then
            int_group_ddl = 3
        End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_pdf(HiddenField1.Value)
        Dim clsds As New ClassDataset

        'Response.Clear()
        'Response.ContentType = "Application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        'Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

        'Response.Flush()
        'Response.Close()
        'Response.End()
    End Sub

    Sub load_pdf(ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")

            Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

        Catch ex As Exception

        Finally

            Response.Flush()
            Response.Close()
            Response.End()
        End Try

    End Sub
    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        'UC_CONFIRM.load_SORBOR5(p2)
    End Sub
    '''' <summary>
    '''' รวม XML เข้าไปที่ PDF จดทะเบียน
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF_Output(ByVal filename As String)
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & "PDFdalcn_output_5.pdf") 'C:\path\PDF_TEMPLATE\
    '        Using outputStream = New FileStream(bao._PATH_PDF_TRADER & filename & "-output.pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset


    'End Sub

    Private Sub BindData_PDF(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_lcnre As New DAO_DRUG.TB_lcnrequest
        dao_lcnre.GetDataby_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao_lcnre.fields.FK_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao_lcnre.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim pvncd As String = ""
        Try
            lcnno_text = dao_lcn.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao_lcn.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim ProcessID = dao_up.fields.PROCESS_ID
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        'Try
        '    pvncd = dao.fields.pvncd
        'Catch ex As Exception

        'End Try
        Dim cls_dalcn As New CLASS_GEN_XML.lcnrequest(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid, dao_lcnre.fields.lcnno, dao_lcnre.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcnre.fields.FK_IDA, dao_lcn.fields.FK_IDA, _IDA)

        Dim class_xml As New CLASS_LCNREQUEST
        class_xml = cls_dalcn.gen_xml()
        'class_xml.dalcns = dao.fields
        p_lcnre = class_xml

        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao_lcn.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao_lcn.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน

        Dim bao_master As New BAO_MASTER
        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(dao_lcn.fields.FK_IDA)
        Try
            class_xml.DT_MASTER.DT29 = bao_master.SP_MASTER_DALCN_LCNREQUEST_by_IDA(_IDA) 'เลขรับ วันที่รับ
        Catch ex As Exception

        End Try

        'ขย15
        If dao_lcn.fields.lcntpcd = "ขย1" Then
            class_xml.CHK_TYPE = 1
            class_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย2" Then
            class_xml.CHK_TYPE = 3
            class_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย3" Then
            class_xml.CHK_TYPE = 4
            class_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย4" Then
            class_xml.CHK_TYPE = 2
            class_xml.CHK_NAME = "ขายส่งยาแผนปัจจุบันฯ"

            'ยบ13
        ElseIf dao_lcn.fields.lcntpcd = "ผยบ" Then
            class_xml.CHK_TYPE = 1
        ElseIf dao_lcn.fields.lcntpcd = "นยบ" Then
            class_xml.CHK_TYPE = 3
        ElseIf dao_lcn.fields.lcntpcd = "ขยบ" Then
            class_xml.CHK_TYPE = 2

            'สมพ
        ElseIf dao_lcn.fields.lcntpcd = "ผสม" Then
            class_xml.CHK_TYPE = 1
        ElseIf dao_lcn.fields.lcntpcd = "นสม" Then
            class_xml.CHK_TYPE = 3
        ElseIf dao_lcn.fields.lcntpcd = "ขสม" Then
            class_xml.CHK_TYPE = 2
        End If

        Dim statusId As Integer = dao_lcnre.fields.STATUS_ID
        Dim lcntype As String = dao_lcnre.fields.lcntpcd

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_process, lcntype, statusId, 0)

        'Try
        '    Dim rcvdate As Date = dao.fields.rcvdate
        '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
        '    class_xml.dalcns = dao.fields


        'Catch ex As Exception

        'End Try

        'p_dalcn = class_xml

        'Dim statusId As Integer = dao.fields.STATUS_ID
        'Dim lcntype As String = dao.fields.lcntpcd

        Dim YEAR As String = dao_up.fields.YEAR
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim _group As Integer = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 1
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 0
        End If
        'Dim template_id As Integer = 0
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        'Dim _group As Integer = 0
        'Try
        '    template_id = dao.fields.TEMPLATE_ID
        'Catch ex As Exception

        'End Try
        'If template_id = 2 Then
        '    _group = 9
        'End If

        '_group:=_group
        BindData_PDF(_group:=_group)

    End Sub


    Private Sub btn_drug_group_Click(sender As Object, e As EventArgs) Handles btn_drug_group.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx?ida=" & Request.QueryString("ida") & "'); ", True)
    End Sub
End Class