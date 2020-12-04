Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Imports System.Globalization

Public Class POPUP_DS_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _lcn_ida As String

    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _lcn_ida = Request.QueryString("lcn_ida")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BindData_PDF()
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)

        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 0 Then '0 = รอชำระ , 1 = บันทึกรอส่งเรื่อง
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
        'Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        'dao_p.GetDataby_Process_ID(_ProcessID)
        'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then
        '    If dao.fields.STATUS_ID <> 1 Then
        '        btn_confirm.Enabled = False
        '        btn_cancel.Enabled = False
        '        btn_confirm.CssClass = "btn-danger btn-lg"
        '        btn_cancel.CssClass = "btn-danger btn-lg"
        '    End If
        'Else
        '    btn_confirm.Enabled = False
        '    btn_cancel.Enabled = False
        '    btn_confirm.CssClass = "btn-danger btn-lg"
        '    btn_cancel.CssClass = "btn-danger btn-lg"
        'End If

    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        Dim dao_auto As New DAO_DRUG.ClsDBdrsamp
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)
        Dim bao As New BAO.GenNumber

        'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then       'การทำงานของ DEMO
        '    'If dao_auto.fields.STATUS_ID = 8 Then
        '    dao.GetDataby_IDA(_IDA)
        '    dao.fields.STATUS_ID = 1
        '    dao.update()
        '    alert("ยืนยันข้อมูลเรียบร้อย")
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'Else
        '    'อนุมัติ AUTO
        '    dao.fields.STATUS_ID = 8
        '    Dim RCVNO As Integer
        '    RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
        '    dao.fields.rcvno = RCVNO
        '    dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
        '    dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        '    dao.fields.appdate = Date.Now.ToShortDateString()
        '    dao.fields.Ref_no = txt_ref_no.Text
        '    Try
        '        dao.fields.rcvdate = Date.Now
        '    Catch ex As Exception

        '    End Try

        '    'เตรียมข้อมูลเข้า LPI
        '    If dao.fields.STATUS_ID = 8 Then
        '        Dim pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        '        pack.GetData_chk_by_FK_drsamp(_IDA)

        '        Dim date_add = Date.Now
        '        Dim order_id As Integer = 0

        '        For Each pack.fields In pack.datas
        '            order_id = order_id + 1
        '            pack.fields.DATE_ADD = date_add
        '            pack.fields.order_id = order_id
        '            pack.update()
        '        Next
        '    End If

        '    dao.update()

        '    alert("อนุมัติข้อมูลเรียบร้อย")
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        ''End If
        'Else                                                            'ตัวจริง
        dao.GetDataby_IDA(Integer.Parse(_IDA))
            'dao_auto.by_lcntpcd_and_regis_status8(dao.fields.lcntpcd, dao.fields.PRODUCT_ID_IDA)        'ดึงข้อมูลการอนุมัติ
            dao_up.GetDataby_IDA(dao.fields.TR_ID)

        'If dao_auto.fields.STATUS_ID = 8 Then                                                       'เคยได้รับอนุมัติแล้ว

        '    Dim ws2 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT
        '    Dim result_pay As String = ""
        '    result_pay = ws2.CHECK_PRICE(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE)

        '    If _ProcessID = "1701" Or _ProcessID = "1702" Then          'ผย/นย
        '        If result_pay = "300" Then
        '            Dim result As String = ""
        '            result = ws2.CHECK_PAYMENT(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE, 1)
        '            If result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then
        Dim i As Integer = 0
        Try
            i = dao.fields.cndno
        Catch ex As Exception

        End Try
        If i > 0 Then
            dao.fields.STATUS_ID = 8
            Dim RCVNO As Integer
            Dim PROCESS_ID As Integer = dao.fields.PROCESS_ID
            RCVNO = bao.GEN_RCVNO_NO_50k(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
            dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        Else
            dao.fields.STATUS_ID = 1
        End If

        dao.update()
        AddLogStatusEtracking(1, 0, _CLS.CITIZEN_ID, "ยื่นเอกสารยาตัวอย่าง " & dao_p.fields.PROCESS_NAME, dao_p.fields.PROCESS_NAME, dao.fields.TR_ID, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
        'alert("ยืนยันข้อมูลเรียบร้อย")
        alert("ยืนยันข้อมูลเรียบร้อย เลขรับ คือ " & dao.fields.rcvno)
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
            Response.Write("</script type >")

        '            Else
        '                alert(result)
        '            End If
        '        Else
        '            alert(result_pay)
        '        End If
        '    ElseIf _ProcessID = "1703" Or _ProcessID = "1704" Then      'ผยบ/นยบ
        '        If result_pay = "100" Then
        '            Dim result As String = ""
        '            result = ws2.CHECK_PAYMENT(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE, 1)
        '            If result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then

        '                dao.fields.STATUS_ID = 2
        '                dao.update()
        '                alert("ยืนยันข้อมูลเรียบร้อย")
        '                Response.Write("<script type langue =javascript>")
        '                Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        '                Response.Write("</script type >")

        '            Else
        '                alert(result)
        '            End If
        '        Else
        '            alert(result_pay)
        '        End If
        '    End If
        'Else
        '    Dim ws2 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT
        '    Dim result_pay As String = ""
        '    result_pay = ws2.CHECK_PRICE(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE)

        '    If _ProcessID = "1701" Or _ProcessID = "1702" Then          'ผย/นย
        '        If result_pay = "300" Then
        '            Dim result As String = ""
        '            result = ws2.CHECK_PAYMENT(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE, 1)
        '            If result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then

        '                'อนุมัติ AUTO
        '                dao.fields.STATUS_ID = 8
        '                Dim RCVNO As Integer
        '                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
        '                dao.fields.rcvno = RCVNO
        '                dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
        '                dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        '                dao.fields.appdate = Date.Now.ToShortDateString()
        '                dao.fields.Ref_no = txt_ref_no.Text
        '                Try
        '                    dao.fields.rcvdate = Date.Now
        '                Catch ex As Exception

        '                End Try


        '                'เตรียมข้อมูลเข้า LPI
        '                If dao.fields.STATUS_ID = 8 Then
        '                    Dim pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        '                    pack.GetData_chk_by_FK_drsamp(_IDA)

        '                    Dim date_add = Date.Now
        '                    Dim order_id As Integer = 0

        '                    For Each pack.fields In pack.datas
        '                        order_id = order_id + 1
        '                        pack.fields.DATE_ADD = date_add
        '                        pack.fields.order_id = order_id
        '                        pack.update()
        '                    Next
        '                End If

        '                dao.update()

        '                alert("อนุมัติข้อมูลเรียบร้อย")
        '                Response.Write("<script type langue =javascript>")
        '                Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        '                Response.Write("</script type >")

        '            Else
        '                alert(result)
        '            End If
        '        Else
        '            alert(result_pay)
        '        End If
        '    ElseIf _ProcessID = "1703" Or _ProcessID = "1704" Then      'ผยบ/นยบ
        '        If result_pay = "100" Then
        '            Dim result As String = ""
        '            result = ws2.CHECK_PAYMENT(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE, 1)
        '            If result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then

        '                'อนุมัติ AUTO
        '                dao.fields.STATUS_ID = 8
        '                Dim RCVNO As Integer
        '                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
        '                dao.fields.rcvno = RCVNO
        '                dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
        '                dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        '                dao.fields.appdate = Date.Now.ToShortDateString()
        '                dao.fields.Ref_no = txt_ref_no.Text
        '                Try
        '                    dao.fields.rcvdate = Date.Now
        '                Catch ex As Exception

        '                End Try


        '                'เตรียมข้อมูลเข้า LPI
        '                If dao.fields.STATUS_ID = 8 Then
        '                    Dim pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        '                    pack.GetData_chk_by_FK_drsamp(_IDA)

        '                    Dim date_add = Date.Now
        '                    Dim order_id As Integer = 0

        '                    For Each pack.fields In pack.datas
        '                        order_id = order_id + 1
        '                        pack.fields.DATE_ADD = date_add
        '                        pack.fields.order_id = order_id
        '                        pack.update()
        '                    Next
        '                End If

        '                dao.update()

        '                alert("อนุมัติข้อมูลเรียบร้อย")
        '                Response.Write("<script type langue =javascript>")
        '                Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        '                Response.Write("</script type >")

        '            Else
        '                alert(result)
        '            End If
        '        Else
        '            alert(result_pay)
        '        End If
        '    End If

        'End If
        'End If
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ส่งเรื่องยาตัวอย่าง", _ProcessID)
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        dao.update()
        alert("ยกเลิกข้อมุลเรียบร้อยแล้ว")
        Dim ws As New AUTHEN_LOG.Authentication
        ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยกเลิกคำขอยาตัวอย่าง", _ProcessID)
        Response.Write("<script type langue =javascript>")
        Response.Write("window.location.href = ../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        Response.Write("</script type >")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "โหลด PDF คำขอยาตัวอย่าง", _ProcessID)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "โหลด PDF คำขอยาตัวอย่าง", _ProcessID)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "โหลด PDF คำขอยาตัวอย่าง", _ProcessID)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "โหลด PDF คำขอยาตัวอย่าง", _ProcessID)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.FILENAME_PDF)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.PDFNAME)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()
    End Sub
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
    ''' <summary>
    ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    ''' <summary>
    ''' รวม XML เข้าไปที่ PDFจดแจ้งรายละเอียด
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF2(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DS
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()

    End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim bao_master As New BAO_MASTER
        Dim bao2 As New BAO.ClsDBSqlcommand
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim dao_pid As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_pid.GetDataby_IDA(dao.fields.PRODUCT_ID_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.lcnno)
        Dim bao_show As New BAO_SHOW
        'Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        'dao_phr.GetDataby_FK_IDA(dao.fields.PRODUCT_ID_IDA)
        'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        Dim dao_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_pack.GetDataby_FK_IDA(dao_pid.fields.IDA)

        Dim cls_regis As New CLASS_GEN_XML.drsamp2(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_pid.fields.FK_IDA, dao_pid.fields.IDA, dao.fields.TR_ID, dao.fields.phr_fk)
        'Dim cls_regis As New CLASS_GEN_XML.drsamp2(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_lcn.fields.IDA, dao_pid.fields.FK_IDA, dao_phr.fields.FK_IDA, dao.fields.TR_ID)
        Dim class_xml As New CLASS_DRSAMP
        class_xml = cls_regis.gen_xml()
        Try
            class_xml.DT_SHOW.DT6 = bao2.SP_regis(dao_pid.fields.IDA)
            class_xml.DT_SHOW.DT9 = bao2.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(dao_pid.fields.IDA)
        Catch ex As Exception

        End Try
        Try
            class_xml.DT_SHOW.DT20 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW(dao_pid.fields.IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
        Catch ex As Exception

        End Try
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


        Catch ex As Exception

        End Try
        Try
            Dim write_date As Date = dao.fields.WRITE_DATE
            dao.fields.WRITE_DATE = DateAdd(DateInterval.Year, 543, write_date).ToString
            class_xml.WRITE_DATE = Format(DateAdd(DateInterval.Year, -543, write_date), "dd MMM yyyy")
        Catch ex As Exception

        End Try

        Try
                Dim app_date As Date = dao.fields.appdate
                dao.fields.appdate = DateAdd(DateInterval.Year, 543, app_date)
            Catch ex As Exception

            End Try
        Try
            class_xml.DRUG_COLOR = dao_pid.fields.DRUG_COLOR
        Catch ex As Exception

        End Try
        Try
            'PACK_SIZE = dao_pid.fields.PACKAGE_DETAIL 'dt_pack(0)("contain_detail")
            class_xml.PACK_SIZE = dao_pid.fields.PACKAGE_DETAIL
        Catch ex As Exception

        End Try

            class_xml.drsamp = dao.fields
        class_xml.regis = dao_pid.fields

        If IsNothing(dao.fields.rcvdate) = False Then
            Dim rcvdate As Date
            If Date.TryParse(dao.fields.rcvdate, rcvdate) = True Then
                class_xml.RCVDAY = rcvdate.Day.ToString()
                class_xml.RCVMONTH = rcvdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(rcvdate.Year)
                class_xml.RCVDATE = rcvdate.Day.ToString() & " " & rcvdate.ToString("MMM") & " " & con_year(rcvdate.Year)

            End If
        End If
        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.APPDAY = appdate.Day.ToString()
                class_xml.APPMONTH = appdate.ToString("MMMM")
                class_xml.APPYEAR = con_year(appdate.Year)
                class_xml.APPDATE = appdate.Day.ToString() & " " & appdate.ToString("MMM") & " " & con_year(appdate.Year)
            End If
        End If

        
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try
        Try
            Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
            unit_physic.GetDataby_sunitcd(dao_pack.fields.SMALL_UNIT)
            If dao.fields.QUANTITY <> "" Then
                class_xml.IMPORT_AMOUNTS = dao.fields.QUANTITY & " " & unit_physic.fields.unit_name
            Else
                class_xml.IMPORT_AMOUNTS = dao_pack.fields.SUM & " " & unit_physic.fields.unit_name
            End If
        Catch ex As Exception

        End Try

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT

        Dim PDF_TEMPLATE As String = ""
        If _ProcessID = "1701" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1702" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1703" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1704" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1705" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1706" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1707" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        End If

        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)

        Try
            Dim url As String = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
            'Dim ws As New WS_QR_CODE.WS_QR_CODE
            'class_xml.QR_CODE = ws.GetQRImgByte(url)
            'class_xml.QR_CODE = QR_CODE_IMG(url)
        Catch ex As Exception

        End Try

        p_drsamp = class_xml

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal ยาตัวอย่าง", _ProcessID)
        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal ยาตัวอย่าง", _ProcessID)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal ยาตัวอย่าง", _ProcessID)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิด modal ยาตัวอย่าง", _ProcessID)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try

        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
        'If _ProcessID = "1701" Or _ProcessID = "1702" Or _ProcessID = "1703" Or _ProcessID = "1704" Or _ProcessID = "1705" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'Else

        'End If
    End Sub
End Class