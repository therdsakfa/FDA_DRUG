Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_EXTEND_TIME_LOCATION_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _YEARS As String
    Private _lcn_ida As String
    Private _lct_ida As String
    Private _type_id As String

    Sub RunQuery()
        Try
            _process = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _lct_ida = Request.QueryString("lct_ida")
            _lcn_ida = Request.QueryString("lcn_ida")
            _TR_ID = Request.QueryString("TR_ID")

            _YEARS = con_year(Date.Now.Year)
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        show_panel()
        'show_check()
        If Not IsPostBack Then
            BindData_PDF()
            show_btn(_IDA)
            'UC_GRID_PHARMACIST.load_gv(_IDA)
            Open_or_Close()

            Dim check As New DAO_DRUG.TB_LCN_EXTEND_LITE
            check.GetDataby_IDA(_IDA)
            If check.fields.STATUS_ID = 5 Then
                UC_GRID_ATTACH.load_gv_V3(_TR_ID, 11)
                UC_GRID_ATTACH.load_gv_V3(_TR_ID, 22)
                UC_GRID_ATTACH.load_gv_V3(_TR_ID, 33)
            Else
                UC_GRID_ATTACH.load_gv(_TR_ID)
            End If
            'If check.fields.STATUS_ID <> 0 Then
            '    Me.chk1.Enabled = False
            '    Me.chk2.Enabled = False
            '    Me.chk3.Enabled = False
            '    Me.chk4.Enabled = False
            '    Me.chk5.Enabled = False
            'End If
            'If check.fields.lcntpcd = "ขย1" Then 'ขายปลีก
            '    chk1.Checked = True
            '    Try
            '        If check.fields.SALE_MEDICIAN2 = 2 Then
            '            chk2.Checked = True
            '        Else
            '            chk2.Checked = False
            '        End If
            '        If check.fields.SALE_MEDICIAN3 = 3 Then
            '            chk3.Checked = True
            '        Else
            '            chk3.Checked = False
            '        End If

            '    Catch ex As Exception

            '    End Try

            'ElseIf check.fields.lcntpcd = "ขย4" Then
            '    Try

            '        If check.fields.SALE_MEDICIAN1 = 1 Then
            '            chk4.Checked = True
            '        Else
            '            chk4.Checked = False
            '        End If
            '        If check.fields.SALE_MEDICIAN2 = 2 Then
            '            chk5.Checked = True
            '        Else
            '            chk5.Checked = False
            '        End If

            '        'ElseIf check.fields.SALE_MEDICIAN3 = "3" Then
            '        '    chk3.Checked = True
            '    Catch ex As Exception

            '    End Try
            'End If
        End If


    End Sub
    Sub Open_or_Close()
        If Request.QueryString("staff") = "" Then
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE_OPEN
            Dim i As Integer = 0
            i = dao.Sum_val()
            If i = 1 Then
                btn_confirm.Enabled = False
            End If
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Public Sub show_panel()
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(_IDA)
        'If dao.fields.lcntpcd = "ขย1" Then
        '    Panel1.Style.Add("display", "block")
        'ElseIf dao.fields.lcntpcd = "ขย4" Then
        '    Panel2.Style.Add("display", "block")
        'Else

        'End If
    End Sub

    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 0 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            If dao.fields.STATUS_ID > 1 Then
                btn_cancel.Enabled = False
                btn_cancel.CssClass = "btn-danger btn-lg"
            End If
            'ElseIf chk_pha() = True Then 'true คือเภสัชไม่ยืนยัน ,False คือเภสัชยืนยัน
            '    btn_confirm.Enabled = False
            '    btn_cancel.Enabled = False
            '    btn_confirm.CssClass = "btn-danger btn-lg"
            '    btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Private Function chk_pha() As Boolean
        Dim chk As Boolean = True
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_FK_IDA(_IDA)
        For Each row In dao.datas
            If row.PHR_STATUS_UPLOAD = "0" Then
                chk = False
            End If
        Next
        Return chk
    End Function
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        Dim dao_process As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_process.GetDataby_Process_ID(_process)
        dao.GetDataby_IDA(_IDA)


        'If dao.fields.lcntpcd = "ขย1" And (chk2.Checked = False And chk3.Checked = False And chk1.Checked = False) Then
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกลักษณะการประกอบการ');", True)
        'ElseIf dao.fields.lcntpcd = "ขย4" And (chk4.Checked = False And chk5.Checked = False) Then
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกลักษณะการประกอบการ');", True)
        'Else

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.ClsDBSqlcommand
            'Dim bao_num As New BAO.GenNumber
            'Dim RCVNO As Integer
            dao_lcn.GetDataby_IDA(_lcn_ida)
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)

            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
            Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
            dao_date.fields.FK_IDA = _IDA
            Try
                dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

        ''ขย1
        'If dao.fields.lcntpcd = "ขย1" Then
        '    If chk1.Checked = True Then         'ขายปลีก
        '        dao_lcn.fields.CHK_SELL_TYPE = 1
        '        dao.fields.SALE_MEDICIAN1 = 1
        '    End If
        '    If chk2.Checked = True Then     'ขายส่ง
        '        dao_lcn.fields.CHK_SELL_TYPE1 = 2
        '        dao.fields.SALE_MEDICIAN2 = 2
        '    End If
        '    If chk3.Checked = True Then     'ปรุงยาสำหรับผู้ป่วยเฉพาะราย(เฉพาะขายปลีกเท่านั้น)
        '        dao_lcn.fields.CHK_SELL_TYPE2 = 3
        '        dao.fields.SALE_MEDICIAN3 = 3
        '    End If

        '    'ขย4
        'ElseIf dao.fields.lcntpcd = "ขย4" Then
        '    If chk4.Checked = True Then     'ขายส่งยาสำเร็จรูป
        '        dao_lcn.fields.CHK_SELL_TYPE = 13
        '        dao.fields.SALE_MEDICIAN1 = 1
        '    End If
        '    If chk5.Checked = True Then '   ขายส่งเภสัชเคมีภัณฑ์
        '        dao_lcn.fields.CHK_SELL_TYPE1 = 14
        '        dao.fields.SALE_MEDICIAN2 = 2
        '    End If
        'End If
        'dao_lcn.update()
        'dao_date.fields.STATUS_GROUP = 6 'ใบอนุญาต ขย ต่างๆ
        'dao_date.fields.DATE_NOW = Date.Now
        dao.fields.STATUS_ID = 1

            'RCVNO = bao_num.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            'dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
            'dao.fields.RCVNO_DISPLAY = bao_num.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            'Try
            '    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try
            'dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()

            dao.update()
            AddLogStatus(1, _process, _CLS.CITIZEN_ID, _IDA)
            AddLogStatusEtracking(1, 0, _CLS.CITIZEN_ID, "ยื่นเรื่องต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
        alert("ยื่นเรื่องเรียบร้อยแล้ว หลังจากชำระเงินแล้วกรุณาตรวจสอบสถานะอีกครั้ง")
        'alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        'End If
        'End If
        Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอต่ออายุ", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอต่ออายุ", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอต่ออายุ", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอต่ออายุ", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ต้องการยกเลิกคำขอใช้หรือไม่?');", True)
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        Dim dao_process As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_process.GetDataby_Process_ID(_process)
        dao.fields.STATUS_ID = 7
        dao.update()
        AddLogStatus(7, _process, _CLS.CITIZEN_ID, _IDA)
        AddLogStatusEtracking(7, 0, _CLS.CITIZEN_ID, "ยกเลิกคำขอระบบต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
        Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยกเลิกคำขอต่ออายุ", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยกเลิกคำขอต่ออายุ", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยกเลิกคำขอต่ออายุ", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยกเลิกคำขอต่ออายุ", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click

        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)

    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_EXTEND
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_lcnre As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao_lcnre.GetDataby_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao_lcnre.fields.FK_IDA)


        Dim cls_dalcn As New CLASS_GEN_XML.EXTEND(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid, dao_lcnre.fields.lcnno, dao_lcnre.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.FK_IDA, _IDA)

        Dim class_xml As New CLASS_EXTEND
        class_xml = cls_dalcn.gen_xml()
        'class_xml.dalcns = dao.fields
        'p_lcnre = class_xml
        'class_xml.LCN_EXTEND_LITEs = dao_lcnre.fields
        extend = class_xml

        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()
        'Dim newyear As Integer = 0
        'Dim year_present As Integer = 0
        'Dim montn_present As Integer = 0
        'year_present = Year(Date.Now)
        'montn_present = Month(Date.Now)
        'If montn_present = 1 Then
        '    newyear = year_present
        'Else
        '    newyear = year_present + 1
        'End If
        class_xml.EXP_NEWYEAR = dao_lcnre.fields.extend_year 'ต่ออายุใบอนุญาติ
        class_xml.DT_SHOW.DT9 = bao_show.SP_GETDATA_EXTENDPDF_by_IDA(_IDA)
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
        If statusId = 0 Or statusId = 1 Then
            statusId = 5
        End If
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE2(_process, statusId, 0)



        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, dao_lcnre.fields.TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, dao_lcnre.fields.TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        'Dim cls_xml As New CLASS_GEN_XML.EXTEND
        'cls_xml.GEN_XML_EXTEND(Path_XML, extend)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _process, _YEARS, dao_lcnre.fields.TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class