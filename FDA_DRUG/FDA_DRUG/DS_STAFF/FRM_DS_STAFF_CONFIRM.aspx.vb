Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports System.Globalization

Public Class FRM_DS_STAFF_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
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
        ' _ProcessID = Request.QueryString("process")
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
            UC_GRID_ATTACH.load_gv(_TR_ID)
            set_hide(_IDA)

            'Try
            '    Dim dao As New DAO_DRUG.ClsDBdrsamp
            '    dao.GetDataby_IDA(_IDA)
            '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            '    dao_up.GetDataby_IDA(dao.fields.TR_ID)
            '    If dao_up.fields.PROCESS_ID = "1701" Or dao_up.fields.PROCESS_ID = "1702" Or dao_up.fields.PROCESS_ID = "1703" Or dao_up.fields.PROCESS_ID = "1704" Then
            '        btn_drug_group.Style.Add("display", "block")
            '    End If
            'Catch ex As Exception

            'End Try

        End If
        'set_lbl()
        show_btn(_IDA)
    End Sub

    Sub show_btn(ByVal ID As String) 'รับคำขอ
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(ID)

        If dao.fields.STATUS_ID <> 3 Then
            btn_preview.Enabled = False
            ' btn_cancel.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
            'btn_preview.CssClass = "btn-danger btn-lg"

        End If



    End Sub
    ''' <summary>
    ''' เปิด/ปิด เมนูด้านข้าง
    ''' </summary>
    ''' <param name="IDA"></param>
    Public Sub set_hide(ByVal IDA As String) 'อนุมัติ
        Dim dao As New DAO_DRUG.ClsDBdrsamp
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

        If dao.fields.STATUS_ID = 3 Then
            remark_box.Style.Add("display", "block")
        End If

    End Sub
    '''' <summary>
    '''' นำข้อมูลมาใส่ใน label
    '''' </summary>
    'Sub set_lbl()
    '    Dim dao As New DAO_DRUG.ClsDBdrsamp
    '    dao.GetDataby_IDA(_IDA)
    '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    dao_up.GetDataby_IDA(dao.fields.TR_ID)

    '    Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_OFFER
    '    Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS

    '    Try    'ชื่อผู้ลงนาม
    '        dao_s.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
    '        lbl_staff_consider.Text = dao_s.fields.STAFF_OFFER_NAME
    '    Catch ex As Exception
    '        lbl_staff_consider.Text = "-"
    '    End Try

    '    Try
    '        lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
    '    Catch ex As Exception
    '        lbl_app_date.Text = "-"
    '    End Try

    '    Try    ' วันที่เสนอลงนาม
    '        lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
    '    Catch ex As Exception
    '        lbl_consider_date.Text = "-"
    '    End Try

    '    Try
    '        dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 5)
    '        lbl_Status.Text = dao_stat.fields.STATUS_NAME
    '    Catch ex As Exception

    '    End Try


    'End Sub
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
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim bao As New BAO.ClsDBSqlcommand
        dao_up.GetDataby_IDA(_CLS.IDA)
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        pvncd = dao.fields.pvncd.ToString()
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

    ''' <summary>
    ''' กดยืนยัน
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click

        Dim dao As New DAO_DRUG.ClsDBdrsamp
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
        Dim ws As New AUTHEN_LOG.Authentication

        If STATUS_ID = 3 Then 'รับคำขอ
            dao.fields.STATUS_ID = STATUS_ID
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
            dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            dao.fields.rcvr_id = _CLS.CITIZEN_ID
            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
            dao.update()
            '-----------------ลิ้งไปหน้าคีย์มือ----------
            'Response.Redirect("FRM_DS_STAFF_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            '--------------------------------
            alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
            'ElseIf STATUS_ID = 6 Then 'เสนอลงนาม
            '    Response.Redirect("FRM_DS_STAFF_CONSIDER_DATE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        ElseIf STATUS_ID = 8 Then 'อนุมัติ

            'dao.fields.STATUS_ID = STATUS_ID
            'dao.fields.appdate = Date.Now.ToShortDateString()
            'dao.fields.staff_approved_iden = _CLS.CITIZEN_ID
            'dao.fields.REMARK = txt_REMARK.Text
            'package()
            Response.Redirect("FRM_DS_STAFF_REMARK2.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&PROCESS_ID=" & PROCESS_ID)
            AddLogStatus(8, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            'alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
            ' ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "อนุมัติคำขอยาตัวอย่าง", _ProcessID)
        ElseIf STATUS_ID = 7 Then
            Response.Redirect("FRM_DS_STAFF_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            dao.update()
            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "คืนคำขอยาตัวอย่าง", _ProcessID)
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

    Public Sub Bind_ddl_Status_staff() 'สถานะ
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        If dao.fields.STATUS_ID < 4 Then
            int_group_ddl = 0
        ElseIf dao.fields.STATUS_ID = 4 Then
            int_group_ddl = 33
        ElseIf dao.fields.STATUS_ID = 6 Then
            int_group_ddl = 33
        End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL8(9, int_group_ddl)
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
        Dim ws As New AUTHEN_LOG.Authentication
        ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด Modal ยาตัวอย่างฝั่งเจ้าหน้าที่", _ProcessID)
        Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim ws As New AUTHEN_LOG.Authentication
        ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "DOWNLOAD PDF ยาตัวอย่างฝั่งเจ้าหน้าที่", _ProcessID)
        load_pdf(HiddenField1.Value, HiddenField3.Value)
        'Dim clsds As New ClassDataset

        'Response.Clear()
        'Response.ContentType = "Application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        'Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

        'Response.Flush()
        'Response.Close()
        'Response.End()
    End Sub

    Sub load_pdf(ByVal path As String, ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename)

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

    Private Sub BindData_PDF(Optional _group As Integer = 0)
        'Dim bao As New BAO.AppSettings
        ''bao.RunAppSettings()
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)
        'Dim PROCESS_ID As String = ""
        'Dim lcnno_text As String = ""
        'Dim lcnno_auto As String = ""
        'Dim lcnno_format As String = ""
        'Dim pvncd As String = ""
        'Try
        '    lcnno_text = dao.fields.LCNNO_MANUAL
        'Catch ex As Exception

        'End Try
        'Try
        '    lcnno_auto = dao.fields.lcnno
        'Catch ex As Exception

        'End Try
        'Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        ''-------------------เก่า------------------
        '' dao_PHR.GetDataby_FK_IDA(_IDA)
        ''-------------------เก่า------------------
        'dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        ''------------------------------------
        'Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        'dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        'Dim ProcessID = dao_up.fields.PROCESS_ID
        'Try
        '    PROCESS_ID = dao_up.fields.PROCESS_ID
        'Catch ex As Exception

        'End Try
        'Try
        '    pvncd = dao.fields.pvncd
        'Catch ex As Exception

        'End Try
        'Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, dao.fields.lcnsid, lcnno:=lcnno_auto, lcntpcd:=dao.fields.lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        'Dim class_xml As New CLASS_DALCN
        'Dim bao_show As New BAO_SHOW
        ''class_xml = cls_dalcn.gen_xml()

        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        'class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        'Dim bao_master As New BAO_MASTER

        'class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA)
        'class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
        'class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        'class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        'class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        'class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        'class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        'class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        'class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"
        'Dim MAIN_LCN_IDA As Integer = 0
        ''If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        ''    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        ''        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        ''    End If
        ''End If
        'Try
        '    MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        'Catch ex As Exception

        'End Try
        'Try
        '    class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        'Catch ex As Exception

        'End Try
        'Try
        '    If Len(lcnno_auto) > 0 Then
        '        lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try

        ''class_xml.LCNNO_SHOW = lcnno_format
        ''class_xml.SHOW_LCNNO = lcnno_text
        'Dim dao_main As New DAO_DRUG.ClsDBdalcn
        'dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        'If MAIN_LCN_IDA = 0 Then
        '    class_xml.LCNNO_SHOW = lcnno_format
        '    class_xml.SHOW_LCNNO = lcnno_text
        'Else

        '    class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
        '    class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        'End If
        'class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        'If IsNothing(dao.fields.appdate) = False Then
        '    Dim appdate As Date
        '    If Date.TryParse(dao.fields.appdate, appdate) = True Then
        '        class_xml.SHOW_LCNDATE_DAY = appdate.Day
        '        class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
        '        class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)
        '        class_xml.RCVDAY = appdate.Day
        '        class_xml.RCVMONTH = appdate.ToString("MMMM")
        '        class_xml.RCVYEAR = con_year(appdate.Year)
        '        class_xml.EXP_YEAR = con_year(appdate.Year)
        '    End If
        'End If

        ''-------------------เก่า------------------
        ''For Each dao_PHR.fields In dao_PHR.datas
        ''    Dim cls_DALCN_PHR As New DALCN_PHRi
        ''    cls_DALCN_PHR = dao_PHR.fields
        ''    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        ''Next
        ''-------------------ใหม่------------------
        'For Each dao_PHR.fields In dao_PHR.Details
        '    class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        'Next
        ''-------------------------------------


        'For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
        '    Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
        '    cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
        '    class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        'Next

        'Try
        '    Dim rcvdate As Date = dao.fields.rcvdate
        '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
        '    class_xml.dalcns = dao.fields


        'Catch ex As Exception

        'End Try

        'p_dalcn = class_xml

        'Dim statusId As Integer = dao.fields.STATUS_ID
        'Dim lcntype As String = dao.fields.lcntpcd

        'Dim YEAR As String = dao_up.fields.YEAR
        'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'Dim template_id As Integer = 0
        'If statusId = 8 Then
        '    Dim Group As Integer
        '    If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
        '        Try
        '            template_id = dao.fields.TEMPLATE_ID
        '        Catch ex As Exception
        '            template_id = 0
        '        End Try
        '        If template_id = 2 Then
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        '        Else
        '            'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 0)
        '        End If
        '    Else

        '        Try
        '            template_id = dao.fields.TEMPLATE_ID
        '        Catch ex As Exception
        '            template_id = 0
        '        End Try
        '        If template_id = 2 Then
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        '        Else
        '            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 0)
        '        End If

        '    End If
        'Else

        '    Try
        '        template_id = dao.fields.TEMPLATE_ID
        '    Catch ex As Exception
        '        template_id = 0
        '    End Try
        '    'If template_id = 2 Then
        '    '    If statusId > 6 Then
        '    '        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        '    '    Else
        '    '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '    '    End If
        '    'Else
        '    If _group = 1 Then
        '        If template_id = 2 Then
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        '        Else
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
        '            'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '        End If

        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
        '        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '    End If

        '    'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
        '    'End If

        'End If

        'Dim paths As String = bao._PATH_DEFAULT
        'Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)
        'LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim bao_master As New BAO_MASTER
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        'Dim dao_pid As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        'dao_pid.GetDataby_IDA(dao.fields.PRODUCT_ID_IDA)
        Dim dao_pid As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_pid.GetDataby_IDA(dao.fields.PRODUCT_ID_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.lcnno)
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        'Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        'dao_phr.GetDataby_FK_IDA(dao.fields.PRODUCT_ID_IDA)
        Dim _YEARS As String = dao_tr.fields.YEAR
        Dim dao_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_pack.GetDataby_FK_IDA(dao.fields.IDA)

        Dim con_iden As String = ""
        Dim dao_staff_con As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Try
            dao_staff_con.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
        Catch ex As Exception

        End Try

        'Dim cls_regis As New CLASS_GEN_XML.drsamp2(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_pid.fields.FK_IDA, dao_pid.fields.FK_IDA, 0, dao.fields.TR_ID, dao.fields.phr_fk)
        Dim cls_regis As New CLASS_GEN_XML.drsamp2(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_pid.fields.FK_IDA, dao_pid.fields.IDA, dao.fields.TR_ID, dao.fields.phr_fk)

        Dim class_xml As New CLASS_DRSAMP
        class_xml = cls_regis.gen_xml()
        Try
            'cls_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_dalcn.fields.IDA) 'ผู้มีหน้าที่ปฏิบัติการ
            For Each dr As DataRow In BAO_MASTER.SP_DALCN_PHR_BY_FK_IDA(dao_lcn.fields.IDA).Rows
                If dr("IDA") = dao.fields.phr_fk Then
                    class_xml.phr_fullname = dr("PHR_FULLNAME")
                    class_xml.phr_nm = dr("FULLNAMEs")
                End If
            Next
        Catch ex As Exception

        End Try
        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            Dim write_date As Date = dao.fields.WRITE_DATE
            Dim app_date As Date = dao.fields.appdate
            dao.fields.WRITE_DATE = DateAdd(DateInterval.Year, 543, write_date)
            class_xml.WRITE_DATE = Format(DateAdd(DateInterval.Year, -543, write_date), "dd MMM yyyy")
            dao.fields.appdate = DateAdd(DateInterval.Year, 543, app_date)
            class_xml.drsamp = dao.fields
            class_xml.regis = dao_pid.fields
        Catch ex As Exception

        End Try

        Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
        unit_physic.GetDataby_sunitcd(dao_pack.fields.SMALL_UNIT)

        class_xml.IMPORT_AMOUNTS = dao.fields.QUANTITY & " " & unit_physic.fields.unit_name

        p_drsamp = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(dao_tr.fields.PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)

        Dim paths As String = bao._PATH_DEFAULT

        Dim PDF_TEMPLATE As String = ""

        If dao_tr.fields.PROCESS_ID = "1701" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf dao_tr.fields.PROCESS_ID = "1702" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf dao_tr.fields.PROCESS_ID = "1703" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf dao_tr.fields.PROCESS_ID = "1704" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf dao_tr.fields.PROCESS_ID = "1705" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        End If
        'If dao_tr.fields.PROCESS_ID = "1701" Thenx
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8pdf"
        'ElseIf dao_tr.fields.PROCESS_ID = "1702" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\PDF_DRUG_NORYOR8.pdf"
        'ElseIf dao_tr.fields.PROCESS_ID = "1703" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8.pdf"
        'ElseIf dao_tr.fields.PROCESS_ID = "1704" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
        'ElseIf dao_tr.fields.PROCESS_ID = "1705" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8(VEJAI).pdf"
        'End If


        'Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        'Dim filename As String = paths & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, dao_tr.fields.PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        HiddenField3.Value = NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Dim ws As New AUTHEN_LOG.Authentication
        ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด Modal ยาตัวอย่างฝั่งเจ้าหน้าที่", _ProcessID)
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
        Dim ws As New AUTHEN_LOG.Authentication
        ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "PREVIEW PDF ยาตัวอย่างฝั่งเจ้าหน้าที่", _ProcessID)
    End Sub


    Private Sub btn_drug_group_Click(sender As Object, e As EventArgs) Handles btn_drug_group.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx?ida=" & Request.QueryString("ida") & "'); ", True)
    End Sub

    Sub package()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        pack.GetData_chk_by_FK_IDA(_IDA)

        Dim date_add = Date.Now
        Dim order_id As Integer = 0

        For Each pack.fields In pack.datas
            order_id = order_id + 1
            pack.fields.DATE_ADD = date_add
            pack.fields.order_id = order_id
            pack.update()
        Next

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txt_REMARK.Visible = True
        Else
            txt_REMARK.Visible = False
        End If
    End Sub
End Class