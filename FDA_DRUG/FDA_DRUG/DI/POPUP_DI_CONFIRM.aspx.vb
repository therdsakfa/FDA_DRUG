Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_DI_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _FK_IDA As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("ProcessID")
            _IDA = Request.QueryString("IDA")
            _FK_IDA = Request.QueryString("FK_IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub reload_pdf(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, PATH_PDF_OUTPUT As String)
        Dim cls_xml As New CLASS_GEN_XML.Center
        cls_xml.GEN_XML_CER(PATH_XML, p_cer)
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                End Using
            End Using
        End Using
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Request.QueryString("s") <> "" Then
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)
        End If
        ' 
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:500px;width:100%;' src='../PDF/PDF_PERVIEW.aspx?ID=" & _CLS.IDA & "&ID_transection=" & _CLS.TR_ID & "&PROCESS_ID=5" & "&STATUS=" & load_STATUS() & "' ></iframe>"
            BindData_PDF()
            Try
                Dim dao As New DAO_DRUG.TB_CER
                dao.GetDataby_IDA2(_IDA)
                If dao.fields.STATUS_ID = 1 Then
                    If Trim(dao.fields.XML_NAME) = "" Then
                        ' reload_pdf(_CLS.PATH_XML, _CLS.PATH_PDF_TEMPLATE, _CLS.PDFNAME)
                        dao.fields.XML_NAME = _CLS.FILENAME_XML
                        dao.update()
                    End If

                End If
            Catch ex As Exception

            End Try
            show_btn()
        End If
    End Sub
    Private Sub show_btn()

        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-lg btn-danger"
            btn_cancel.CssClass = "btn-lg btn-danger"
            '  btn_cancel.Enabled = False
        End If


    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
 
  
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_CER
        Dim bao As New BAO.GenNumber
        dao.GetDataby_IDA2(Integer.Parse(_IDA))
        Dim date_now As Date = Date.Now
        Dim date_exp As Date
        Try
            date_exp = CDate(dao.fields.EXP_DOCUMENT_DATE) 'CDate(dao.fields.EXP_DOCUMENT_DATE).AddDays(180)
        Catch ex As Exception

        End Try
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอ Cert", _ProcessID)

        If date_now <= date_exp Then

            dao.fields.STATUS_ID = 2
            dao.fields.REQUEST_DATE = Date.Now
            Try
                dao.fields.lmdfdate = Bind_Date(CDate(Date.Now))
            Catch ex As Exception

            End Try
            dao.update()
            AddLogStatus(2, Request.QueryString("ProcessID"), _CLS.CITIZEN_ID, _IDA)

            alert("ยื่นคำขอเรียบร้อยแล้ว")
        Else
            alert("ไม่สารมารถยื่นคำขอได้ เนื่องจาก Cert หมดอายุ")
        End If

    End Sub
    Function Bind_Date(ByVal _date As Date) As Date
        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim date_result As Date
        ws.GETDATE_WORKING(_date, True, 5, True, date_result, True)
        Return date_result
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.TB_CER
        Dim bao As New BAO.GenNumber
        Dim cernumber As String = bao.GEN_CER_NO(con_year(Date.Now.Year.ToString()), _CLS.PVCODE(), _ProcessID, _CLS.LCNNO, "1", "1", _IDA, "")
        Dim rcvno As String = bao.GEN_CER_NO(con_year(Date.Now.Year.ToString()), _CLS.PVCODE(), _ProcessID, _CLS.LCNNO, "1", "2", _IDA, "")

        dao.GetDataby_IDA2(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        AddLogStatus(7, Request.QueryString("ProcessID"), _CLS.CITIZEN_ID, _IDA)
        dao.update()
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(Integer.Parse(_IDA))
        'Dim dao_TR As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        ''dao_TR.GetDataby_IDA(Integer.Parse(dao.fields.TR_ID))
        'If Len(_TR_ID) >= 9 Then
        '    Try
        '        dao_TR.GetDataby_IDA(_TR_ID)
        '    Catch ex As Exception

        '    End Try
        'Else
        '    dao_TR.GetDataby_TR_ID_Process(_TR_ID, _ProcessID)
        'End If
        'If dao.fields.lcnscd = 11 Then
        '    fusion_XML_To_PDF("DA-41-2558-" & _IDA.ToString())
        'Else
        ' fusion_XML_To_PDF("DA-" & dao_TR.fields.PROCESS_ID & "-" & dao_TR.fields.YEAR & "-" & _IDA.ToString())
        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
        'End If
    End Sub
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal filename As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename)
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
        Dim p2 As New CLASS_CER
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_dalcntype As New DAO_DRUG.ClsDBdalcntype
        dao_dalcntype.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)

        Dim dao_CER_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_CER_DETAIL_CASCHEMICAL
        dao_CER_DETAIL_CASCHEMICAL.GetDataby_FK_IDA_DET(dao.fields.IDA)
        Dim lcn_IDA As Integer
        Dim LCNSID As Integer
        Dim STATUS As Integer
        For Each dr In dao.datas
            lcn_IDA = dr.FK_IDA
            LCNSID = dr.LCNSID
            STATUS = dr.STATUS_ID
        Next
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        If Len(_TR_ID) >= 9 Then
            Try
                dao_up.GetDataby_IDA(_TR_ID)
            Catch ex As Exception

            End Try
        Else
            dao_up.GetDataby_TR_ID_Process(_TR_ID, _ProcessID)
        End If
        Dim CITIEZEN_ID_AUTHORIZE As String = ""


        'Dim PROCESS_ID As String = dao_up.fields.PROCESS_ID.ToString()


        Dim Year As String = dao_up.fields.YEAR.ToString()
        ' Dim TR_ID As String = dao_up.fields.ID.ToString()
        Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID


        Dim cls_cer As New CLASS_GEN_XML.Cer(_CLS.CITIZEN_ID, LCNSID, 1, lcn_IDA)

        Dim class_xml As New CLASS_CER
        'class_xml = cls_cer.gen_xml_CER()'big 20/2/2560

        class_xml.CERs = dao.fields
        'Try
        '    Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
        '    dao_iso.GetDataby_IDA(Trim(dao.fields.COUNTRY_OF_DEPARTMENT_IDA))
        '    class_xml.COUNTRY_OF_DEPARTMENT_NAME = dao_iso.fields.engcntnm
        'Catch ex As Exception

        'End Try
        class_xml.CER_DETAIL_CASCHEMICALs = dao_CER_DETAIL_CASCHEMICAL.Details()
        p_cer = class_xml

        'dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Try
            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
            dao_iso.GetDataby_IDA(p_cer.CERs.COUNTRY_OF_DEPARTMENT_IDA)
            class_xml.COUNTRY_OF_DEPARTMENT_NAME = dao_iso.fields.engcntnm
        Catch ex As Exception

        End Try
        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
        'ชื่อบริษัท
        class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID)

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, _CLS.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.LCNSID) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, _CLS.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER

        'ชื่อประเภทยา
        class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_dactg()

        'ประเทศ
        class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt()

        'เลขที่ใบอนุญาต
        class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(lcn_IDA)

        ' bao_master.SP_MASTER_fafdtype.TableName = "ประกาศใบอนุญาต"
        class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(lcn_IDA)

        'ประเภท Cer
        class_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_lgt_impcertp()

        'สาร
        class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()
        class_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(dao.fields.IDA) 'สาร
        class_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(dao.fields.IDA) 'สถานที่ผลิต



        Dim dao_CER_DETAIL_MANUFACTURE As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
        dao_CER_DETAIL_MANUFACTURE.GetDataby_FK_IDA(_IDA)
        'class_xml.CER_DETAIL_MANUFACTUREs = dao_CER_DETAIL_MANUFACTURE.datas
        
        '-------------------------ใส่ข้อมูลย่อยลง xml---------------------------
        For Each dao_CER_DETAIL_MANUFACTURE.fields In dao_CER_DETAIL_MANUFACTURE.datas
            Dim cls_CER_DETAIL_MANUFACTURE As New CER_DETAIL_MANUFACTURE
            cls_CER_DETAIL_MANUFACTURE = dao_CER_DETAIL_MANUFACTURE.fields
            class_xml.CER_DETAIL_MANUFACTUREs.Add(cls_CER_DETAIL_MANUFACTURE)
        Next

        '------------------------------------------
        Try
            Dim dao_iso1 As New DAO_DRUG.clsDBsysisocnt
            dao_iso1.GetDataby_IDA(dao_CER_DETAIL_MANUFACTURE.fields.COUNTRY_GMP)
            class_xml.COUNTRY_GMP_NAME = dao_iso1.fields.engcntnm
        Catch ex As Exception

        End Try
        Try
            Dim dao_iso2 As New DAO_DRUG.clsDBsysisocnt
            dao_iso2.GetDataby_IDA(dao_CER_DETAIL_MANUFACTURE.fields.COUNTRY_ID)
            class_xml.MANUFACTURE_COUNTRY_NAME = dao_iso2.fields.engcntnm
        Catch ex As Exception

        End Try
        Try
            Dim dao_iso3 As New DAO_DRUG.clsDBsysisocnt
            dao_iso3.GetDataby_IDA(dao.fields.LAB_COUNTRY_IDA)
            class_xml.LAB_COUNTRY_NAME = dao_iso3.fields.engcntnm

        Catch ex As Exception

        End Try
        Try
            Dim dao_iso4 As New DAO_DRUG.clsDBsysisocnt
            dao_iso4.GetDataby_IDA(dao.fields.BUYER_COUNTRY)
            class_xml.BUYER_COUNTRY_NAME = dao_iso4.fields.engcntnm
        Catch ex As Exception

        End Try
        Try
            If dao.fields.DEPARTMENT_REGIST_CER_TYPE = 1 Then
                class_xml.DEPARTMENT_REGIST_CER_NAME1 = dao.fields.DEPARTMENT_REGIST_CER_NAME
                class_xml.DEPARTMENT_REGIST_CER_NAME2 = ""
            ElseIf dao.fields.DEPARTMENT_REGIST_CER_TYPE = 2 Then
                class_xml.DEPARTMENT_REGIST_CER_NAME2 = ""
                class_xml.DEPARTMENT_REGIST_CER_NAME2 = dao.fields.DEPARTMENT_REGIST_CER_NAME
            End If
        Catch ex As Exception

        End Try
        class_xml.URL_CHEMICAL_SEARCH = "http://164.115.28.101/FDA_DRUG/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx"

        Dim lcnno_auto As Integer
        lcnno_auto = dao_lcn.fields.lcnno
        Dim lcnno_format As String = ""
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_lcn.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.TYPE_IMPORT = dao_dalcntype.fields.lcntpnm
        Try
            'Dim rcvdate As Date = dao.fields.rcvdate
            'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            'class_xml.CERs = dao.fields
        Catch ex As Exception

        End Try

        class_xml = cls_cer.gen_xml_CER()
        Dim statusId As Integer = STATUS
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID) 'paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID) 'paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        _CLS.PATH_PDF_TEMPLATE = PDF_TEMPLATE
        _CLS.PATH_XML = Path_XML

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        _CLS.PDFNAME = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.FILENAME_XML = NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class