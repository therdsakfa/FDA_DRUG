Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_EDIT_LCN_STAFF_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private b64 As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'If Session("b64") IsNot Nothing Then
        '    b64 = Session("b64")
        'End If
        If Not IsPostBack Then
            'txt_app_date.Text = Date.Now.ToShortDateString()
            HiddenField2.Value = 0

            Try
                BindData_PDF()
            Catch ex As Exception
                Response.Redirect("https://privus.fda.moph.go.th/")
            End Try
            Bind_ddl_Status_staff()
            load_fdpdtno()
            UC_GRID_PHARMACIST.load_gv(_IDA)
            If _TR_ID <> "" Then
                UC_GRID_ATTACH.load_gv(_TR_ID)
            End If

            set_hide(_IDA)
            Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
            dao.GetDataby_IDA(_IDA)

        End If
        set_lbl()
        'show_btn(_IDA)
    End Sub

    'Sub show_btn(ByVal ID As String)
    '    Dim dao As New DAO_DRUG.ClsDBdalcn
    '    dao.GetDataby_IDA(ID)
    '    If dao.fields.STATUS_ID <> 6 Then
    '        btn_preview.Enabled = False
    '        ' btn_cancel.Enabled = False
    '        btn_preview.CssClass = "btn-danger btn-lg"
    '        'btn_preview.CssClass = "btn-danger btn-lg"

    '    End If


    'End Sub
    Public Sub set_hide(ByVal IDA As String)
        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
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
        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        dao.GetDataby_IDA(_IDA)

        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        Try
            lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
        Catch ex As Exception
            lbl_app_date.Text = "-"
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
        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        Dim bao As New BAO.ClsDBSqlcommand
        dao_up.GetDataby_IDA(_CLS.IDA)
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        'pvncd = dao.fields.pvncd.ToString()


        'lcntypecd = dao.fields.lcntpcd.ToString()
        lcntypecd = lcntypecd.Change_lcntpcd()
        'lcnno_num = dao.fields.lcnno.ToString().Trim().Substring(2, 5)
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

        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer

        dao.GetDataby_IDA(_IDA)
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

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


            'dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            'dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
            dao.update()

            'Dim cls_sop As New CLS_SOP
            'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", PROCESS_ID, _CLS.PVCODE, 2, "รับคำขอ", "SOP-DRUG-10-" & PROCESS_ID & "-2", "เสนอลงนาม", "รอเจ้าหน้าที่เสนอลงนาม", "STAFF", _TR_ID, SOP_STATUS:="รับคำขอ")

            '-----------------ลิ้งไปหน้าคีย์มือ----------
            'Response.Redirect("FRM_STAFF_LCN_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            '--------------------------------
            alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO))
        ElseIf STATUS_ID = 6 Then
            Response.Redirect("FRM_EDIT_LCN_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        ElseIf STATUS_ID = 8 Then
            dao.fields.STATUS_ID = 8
            dao.update()
            '-----------------ลิ้งไปหน้าคีย์มือ----------
            'Response.Redirect("FRM_STAFF_LCN_LCNNO_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            '--------------------------------
            Dim cls_sop As New CLS_SOP
            cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", PROCESS_ID, _CLS.PVCODE, 8, "อนุมัติ", "SOP-DRUG-10-" & PROCESS_ID & "-3", "อนุมัติ", "เจ้าหน้าที่อนุมัติคำขอแล้ว", "STAFF", _TR_ID, SOP_STATUS:="อนุมัติ")

            alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
            'alert_reload("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        ElseIf STATUS_ID = 7 Then
            Response.Redirect("FRM_EDIT_LCN_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            AddLogStatus(STATUS_ID, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            'AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
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
        Dim dao As New DAO_DRUG.ClsDBdalcn
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
        'Dim clsds As New ClassDataset

        'Response.Clear()
        'Response.ContentType = "Application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        'Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

        'Response.Flush()
        'Response.Close()
        'Response.End()
    End Sub

    'Sub load_pdf(ByVal filename As String)
    '    Try

    '        Dim clsds As New ClassDataset
    '        Response.Clear()
    '        Response.ContentType = "Application/pdf"
    '        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")

    '        Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

    '    Catch ex As Exception

    '    Finally

    '        Response.Flush()
    '        Response.Close()
    '        Response.End()
    '    End Try

    'End Sub
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
    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ' ''' </summary>
    ' ''' <remarks></remarks>
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

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings

        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim cls_dalcn_edt As New CLASS_GEN_XML.DALCN_EDIT_REQUEST(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID, "1", "10")
        Dim lct_ida As Integer = 0 '101680

        Dim Cls_XML As New CLASS_DALCN_EDIT_REQUEST
        ' class_xml = cls_dalcn.gen_xml()
        Cls_XML.DALCN_EDIT_REQUESTs = dao.fields


        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Try
            dao_main.GetDataby_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Dim bao_show As New BAO_SHOW

        Try
            lct_ida = dao_main.fields.FK_IDA
        Catch ex As Exception

        End Try

        Dim dt_lo As New DataTable
        Dim dt_keep As New DataTable

        Try
            dt_lo = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.NEW_LO_IDA)
        Catch ex As Exception

        End Try
        Try
            dt_keep = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.NEW_KEEP_IDA)
        Catch ex As Exception

        End Try

        For Each dr As DataRow In dt_lo.Rows
            Try
                Cls_XML.LO_ADDR = dr("fulladdr3")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.LO_NAME = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.LO_TEL = dr("tel")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.LO_HOUSENO = dr("HOUSENO")
            Catch ex As Exception

            End Try
        Next
        For Each dr As DataRow In dt_keep.Rows
            Try
                Cls_XML.KEEP_ADDR = dr("fulladdr3")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.KEEP_NAME = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.KEEP_TEL = dr("tel")
            Catch ex As Exception

            End Try
        Next


        Cls_XML.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง

        Cls_XML.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Cls_XML.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_5"
        Cls_XML.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID) 'ข้อมูลบริษัท
        Cls_XML.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        If Cls_XML.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        Cls_XML.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        'If txt_bsn.Text <> "" Then
        '    ws2.insert_taxno(txt_bsn.Text)
        'End If




        Dim lcnno_auto As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim rcvno_format As String = ""
        'Dim MAIN_LCN_IDA As Integer = 61332

        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            If dao_main.fields.lcntpcd.Contains("4") And dao_main.fields.lcntpcd.Contains("ขย4") = False Then
                Cls_XML.LCN_TYPE = "1"
            ElseIf dao_main.fields.lcntpcd.Contains("3") And dao_main.fields.lcntpcd.Contains("ขย3") = False Then
                Cls_XML.LCN_TYPE = "2"
            End If

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
            If Len(rcvno_auto) > 0 Then
                lcnno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/25" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        'If MAIN_LCN_IDA <> 0 Then
        '    Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
        '    dao_main2.GetDataby_IDA(61332)

        '    Try
        '        'lcnno_format = 
        '        cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
        '    Catch ex As Exception

        '    End Try

        'End If
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_bsn.GetDataby_LCN_IDA(dao_main.fields.IDA)
        Catch ex As Exception

        End Try

        Dim bao_cpn As New BAO.ClsDBSqlcommand
        Cls_XML.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(dao_bsn.fields.BSN_IDENTIFY) 'ผู้ดำเนิน
        Cls_XML.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Cls_XML.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_main.fields.CITIZEN_ID_AUTHORIZE)
        Cls_XML.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"

        Cls_XML.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_main.fields.CITIZEN_ID_AUTHORIZE)
        Cls_XML.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"

        Dim bao_master As New BAO_MASTER
        Cls_XML.DT_SHOW.DT10 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao_main.fields.IDA)

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        Cls_XML.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(dao_main.fields.IDA)
        ' End If

        Try
            Cls_XML.BSN_IDENTIFY = dao_bsn.fields.BSN_IDENTIFY
        Catch ex As Exception

        End Try
        Try
            Cls_XML.RCVDATE_DISPLAY = CDate(dao.fields.rcvdate).ToShortDateString()
        Catch ex As Exception

        End Try

        Cls_XML.LCNNO_FORMAT = lcnno_format
        Cls_XML.RCVNO_FORMAT = rcvno_format
        Try
            'If dao.fields.BSN_NATIONALITY_CD = 1 Then
            'cls_xml.dalcns.NATION = "ไทย"
            'End If
        Catch ex As Exception

        End Try
        p_dalcn_rqt = Cls_XML


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_TABEAN(_ProcessID, 0, 0)
        Dim YEAR As String = dao_up.fields.YEAR

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, YEAR, _TR_ID)
        'load_PDF(filename)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, YEAR, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Private Sub btn_drug_group_Click(sender As Object, e As EventArgs) Handles btn_drug_group.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx?ida=" & Request.QueryString("ida") & "'); ", True)
    End Sub

    'Private Sub ddl_template_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_template.SelectedIndexChanged
    '    update_template(_IDA)
    '    BindData_PDF()
    'End Sub
    'Sub update_template(ByVal ida As String)
    '    If ddl_template.SelectedValue <> "0" Then
    '        Dim dao As New DAO_DRUG.ClsDBdalcn
    '        dao.GetDataby_IDA(ida)
    '        dao.fields.TEMPLATE_ID = ddl_template.SelectedValue
    '        dao.update()
    '    End If

    'End Sub
    Private Sub load_pdf(ByVal FilePath As String)


        ''  Response.ContentType = "Application/pdf"

        'Dim clsds As New ClassDataset

        'Dim bb As Byte() = clsds.UpLoadImageByte(FilePath)

        'Dim ws_F As New WS_FLATTEN.WS_FLATTEN

        'Dim b_o As Byte() = ws_F.FlattenPDF_DIGITAL(bb)

        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-length", b_o.Length.ToString())
        'Response.BinaryWrite(b_o)



        ''Response.Clear()
        ''Response.ContentType = "application/pdf"
        ''Response.AddHeader("Content-Disposition", "attachment;filename=abc.pdf")

        ''Response.BinaryWrite(clsds.UpLoadImageByte(FilePath))

        ''Response.Flush()

        'Response.End()


        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.FILENAME_PDF)
        Response.BinaryWrite(clsds.UpLoadImageByte(FilePath)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()


    End Sub


    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function
End Class