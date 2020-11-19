Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Public Class FRM_TABEAN_CONFIRM_STAFF
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _IDA_REGIS As String
    Private _TR_ID As String
    Private _process As String
    Private _YEARS As String
    Sub runSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

    End Sub
    Private Sub RunQuery()

        _IDA = Request.QueryString("IDA")
        _process = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            Try

                'lr_preview.Text = "<iframe id='iframe1'  style='height:500px;width:100%;' src='../PDF/FRM_PDF.aspx?ID=" & _IDA & "&ID_transection=0&PROCESS_ID=41&STATUS=0' ></iframe>"

            Catch ex As Exception

            End Try
            Bind_ddl_Status()
            load_fdpdtno()
            BindData_PDF()
            UC_GRID_ATTACH1.load_gv_V2(_TR_ID, _process)
        End If

    End Sub
    Sub load_fdpdtno()
        Dim bao As New BAO.ClsDBSqlcommand
        'lbl_fdpdtno.Text = get_fdpdtno().Substring(0, 2) & "-" & get_fdpdtno().Substring(2, 1) & "-" & get_fdpdtno().Substring(3, 5) & "-" & get_fdpdtno().Substring(8, 1) & "-"
        'lbl_fdpdtno2.Text = _CLS.IDA    'ปรับให้runno

    End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""

        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA)
        Try
            _IDA_REGIS = dao.fields.FK_IDA
        Catch ex As Exception

        End Try
        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_re.GetDataby_FK_IDA(dao.fields.FK_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao_re.fields.FK_IDA)

        Dim cls_regis As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao_lcn.fields.lcnno, dao.fields.pvncd, dao_lcn.fields.IDA)

        Dim class_xml As New CLASS_DR
        class_xml = cls_regis.gen_xml()
        Try
            rgttpcd = dao.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = dao.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            'Dim rcvdate As Date = dao.fields.rcvdate
            'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.drrgts = dao.fields
        Catch ex As Exception

        End Try

        Try
            If Len(lcnno_auto) > 0 Then
                lcnno_format = rgttpcd & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/25" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try

        ' p_ = class_xml
        Dim bao_show As New BAO_SHOW
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน

        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
        class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        class_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
        class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่


        class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(_IDA_REGIS)
        class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_2NO"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_3NO"
        class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 4)
        class_xml.DT_SHOW.DT17.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_4NO"

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_process, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _process, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
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
    Public Sub Bind_ddl_Status()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_STATUS_BY_GROUP(1)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataBind()
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer

        dao.GetDataby_IDA(_IDA)
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

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


            'dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            'dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
            dao.update()
            '-----------------ลิ้งไปหน้าคีย์มือ----------
            'Response.Redirect("FRM_STAFF_LCN_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            '--------------------------------
            alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        ElseIf STATUS_ID = 6 Then
            Response.Redirect("FRM_STAFF_LCN_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        ElseIf STATUS_ID = 8 Then
            dao.fields.STATUS_ID = STATUS_ID
            'dao.fields.appdate
            dao.update()
            '-----------------ลิ้งไปหน้าคีย์มือ----------
            'Response.Redirect("FRM_STAFF_LCN_LCNNO_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            '--------------------------------

            alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
            'alert_reload("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        ElseIf STATUS_ID = 7 Then
            Response.Redirect("FRM_STAFF_LCN_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            '_TR_ID = Request.QueryString("TR_ID")
            '_IDA = Request.QueryString("IDA")
            'dao.update()
            'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        End If

    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>self.close(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click

    End Sub

    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF(ByVal filename As String)
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & "PDFfregntfjod.pdf") 'C:\path\PDF_TEMPLATE\
    '        Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset

    '    Response.Clear()
    '    Response.ContentType = "Application/pdf"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
    '    Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

    '    Response.Flush()
    '    Response.Close()
    '    Response.End()
    'End Sub

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
    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF(ByVal filename As String)
    '    Dim path As String = "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader("C:\path\PDF_TEMPLATE\PDFfregntfjod.pdf")
    '        Using outputStream = New FileStream("C:\path\PDF_XML_CLASS\" & filename & ".pdf", FileMode.Create, FileAccess.Write)
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset

    '    Response.Clear()
    '    Response.ContentType = "Application/pdf"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=PDFfregntfjod.pdf")
    '    Response.BinaryWrite(clsds.UpLoadImageByte("C:\path\PDF_XML_CLASS\" & filename & ".pdf"))

    '    Response.Flush()
    '    Response.Close()
    '    Response.End()
    'End Sub

    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDFจดแจ้งรายละเอียด
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF2(ByVal filename As String)
    '    Dim path As String = "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader("C:\path\PDF_TEMPLATE\PDFfregntfjang.pdf")
    '        Using outputStream = New FileStream("C:\path\PDF_XML_CLASS\" & filename & ".pdf", FileMode.Create, FileAccess.Write)
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset

    '    Response.Clear()
    '    Response.ContentType = "Application/pdf"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=PDFfregntfjang.pdf")
    '    Response.BinaryWrite(clsds.UpLoadImageByte("C:\path\PDF_XML_CLASS\" & filename & ".pdf"))

    '    Response.Flush()
    '    Response.Close()
    '    Response.End()

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
    Protected Sub ddl_cnsdcd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cnsdcd.SelectedIndexChanged

    End Sub

    ''' <summary>
    ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF_Output(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_TRADER & filename & "-output.pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

    End Sub


End Class