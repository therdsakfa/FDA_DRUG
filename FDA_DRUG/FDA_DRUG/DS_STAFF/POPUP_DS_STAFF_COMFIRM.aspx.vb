Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf

Public Class POPUP_DS_STAFF_COMFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
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
            Bind_ddl_Status_staff()
            'UC_GRID_ATTACH.load_gv(_TR_ID)
            bind_lbl()
            show_btn(_IDA)
        End If
    End Sub
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID >= 7 Then
            btn_confirm.Enabled = False
            ' btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            'btn_preview.CssClass = "btn-danger btn-lg"

        End If


    End Sub
    Sub bind_lbl()
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        dao.GetDataby_IDA(_IDA)
        Try
            lbl_mobile.Text = dao.fields.MOBILE
        Catch ex As Exception
            lbl_mobile.Text = "-"
        End Try
        Dim uti As New cls_utility.Report_Utility
        Try
            lbl_person.Text = uti.get_name_person_or_office_name(2, dao.fields.CITIZEN_ID_UPLOAD)
        Catch ex As Exception

        End Try
        Try
            lbl_office.Text = uti.get_name_person_or_office_name(1, dao.fields.CITIZEN_ID_AUTHORIZE)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        If dao.fields.STATUS_ID <= 2 Then
            int_group_ddl = 1
        ElseIf dao.fields.STATUS_ID >= 3 Then
            int_group_ddl = 3
        End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()


        'Dim dt As New DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, 3)
        'dt = bao.dt

        'ddl_cnsdcd.DataSource = dt
        'ddl_cnsdcd.DataValueField = "STATUS_ID"
        'ddl_cnsdcd.DataTextField = "STATUS_NAME"
        'ddl_cnsdcd.DataBind()
    End Sub

    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "drimpfor")

        Try
            rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1
        Catch ex As Exception

        End Try


        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        'Dim RCVNO As Integer

        'If ddl_cnsdcd.SelectedValue = 3 Then
        '    Dim bao As New BAO.GenNumber
        '    RCVNO = bao.GEN_NO_04(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, dao.fields.lcnno, "", 0, _IDA, "")
        '    dao.fields.rcvno = RCVNO
        '    dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
        '    dao.fields.rcvdate = Date.Now
        '    dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        '    dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()

        '    dao.update()
        '    AddLogStatus(3, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        '    alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        If ddl_cnsdcd.SelectedValue = 7 Then
            Response.Redirect("FRM_DS_STAFF_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)

        ElseIf ddl_cnsdcd.SelectedValue = 8 Then
            Response.Redirect("FRM_DS_STAFF_REMARK2.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            'dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            'dao.update()

            'Dim dao2 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
            'dao2.GetDataby_FK_IDA(_IDA)
            'For Each dao2.fields In dao2.datas
            '    Dim dao_cas As New DAO_DRUG.TB_MAS_CHEMICAL
            '    dao_cas.GetDataby_IDA(dao2.fields.CAS_ID)


            '    Dim bao As New BAO.GenNumber 'test
            '    Dim run_number As String = ""
            '    run_number = bao.GEN_DH15TDGT_NO(_YEARS, dao_cas.fields.aori, _ProcessID, _IDA, dao2.fields.IDA, dao.fields.QUOTA_TYPE)

            '    Dim dao3 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
            '    dao3.GetDataby_IDA(dao2.fields.IDA)
            '    dao3.fields.phm15dgt = run_number
            '    dao3.update()
            'Next
            ' AddLogStatus(8, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            ' alert("ยืนยันการพิจารณาเรียบร้อยแล้ว")
        End If






    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub


    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

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
        Dim p2 As New CLASS_DH
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub
    Private Sub BindData_PDF()


        'Dim bao As New BAO.ClsDBSqlcommand

        'Dim dao As New DAO_DRUG.ClsDBdrsamp
        'dao.GetDataby_IDA(_IDA)
        'Dim dao_pid As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        'dao_pid.GetDataby_IDA(dao.fields.PRODUCT_ID_IDA)
        'Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        'dao_lcn.GetDataby_IDA(dao.fields.lcnno)
        'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        'Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        'dao_phr.GetDataby_FK_IDA(dao.fields.PRODUCT_ID_IDA)
        'Dim _YEARS As String = dao_tr.fields.YEAR


        'Dim dao_DH15_DETAIL_CER As New DAO_DRUG.TB_DH15_DETAIL_CER
        'dao_DH15_DETAIL_CER.GetDataby_FK_IDA(dao.fields.IDA)


        'Dim cls_regis As New CLASS_GEN_XML.drsamp2(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_pid.fields.LCN_IDA, dao_pid.fields.FK_IDA, dao_phr.fields.FK_IDA,)
        'Dim class_xml As New CLASS_DS
        ''class_xml = cls_regis.gen_xml()

        ''_______________SHOW_________________
        'Dim bao_show As New BAO_SHOW
        'class_xml.drsamp = dao_drsamp.fields  'ใบ
        'class_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(dao.fields.IDA) 'บัญชีรายการยา
        'class_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(dao.fields.LCN_IDA) 'เลขที่ใบอนุญาต
        'class_xml.DT_SHOW.DT3 = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(dao.fields.IDA) 'ตัวยาสำคัญ
        'class_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(dao.fields.IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.FK_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_dalcn.fields.LOCATION_ADDRESS_IDA) 'ผู้ดำเนิน
        'class_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_phr.fields.FK_IDA) 'ผู้มีหน้าที่ปฏิบัติการ


        ''_______________MASTER_________________
        'Dim bao_master As New BAO_MASTER
        'class_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_phr.fields.FK_IDA) 'ผู้มีหน้าที่ปฏิบัติการ

        ''Try
        ''    Dim appvdate As Date = class_xml.dalcns.appvdate
        ''    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        ''    class_xml.fregntf.appvdate = appvdate
        ''Catch ex As Exception

        ''End Try
        ''-------------------------ใส่ข้อมูลย่อยลงxml---------------------------
        'For Each dao_DH15_DETAIL_CER.fields In dao_DH15_DETAIL_CER.datas
        '    Dim cls_DH15_DETAIL_CER As New DH15_DETAIL_CER
        '    cls_DH15_DETAIL_CER = dao_DH15_DETAIL_CER.fields
        '    class_xml.DH15_DETAIL_CERs.Add(cls_DH15_DETAIL_CER)
        'Next

        'p_dh = class_xml

        'Dim statusId As Integer = dao.fields.STATUS_ID
        'Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)

        'Dim paths As String = bao._PATH_DEFAULT
        'Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        'LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        'hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        'HiddenField1.Value = filename
        '_CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        '_CLS.PDFNAME = filename
        ''    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    'Private Sub BindData_PDF()
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()


    '    Dim dao As New DAO_DRUG.ClsDBdh15rqt
    '    dao.GetDataby_IDA(_IDA)
    '    Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
    '    dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
    '    Dim dao_dalcntype As New DAO_DRUG.ClsDBdalcntype
    '    dao_dalcntype.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)


    '    Dim cls_regis As New CLASS_GEN_XML.DH(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao.fields.lcnno, dao.fields.lcntpcd, dao_lcn.fields.pvncd, dao.fields.FK_IDA)

    '    Dim class_xml As New CLASS_DH
    '    class_xml = cls_regis.gen_xml()

    '    '_______________SHOW_________________
    '    Dim bao_show As New BAO_SHOW
    '    class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
    '    class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _CLS.LCNSID_CUSTOMER) 'ข้อมูลที่ตั้งหลัก
    '    class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
    '    class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _CLS.LCNSID_CUSTOMER) 'ที่เก็บ
    '    class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
    '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน


    '    '_______________MASTER_________________
    '    Dim bao_master As New BAO_MASTER
    '    class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt() 'ประเทศ
    '    class_xml.DT_MASTER.DT18 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(dao.fields.TR_ID) 'สารที่เลือก
    '    class_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao.fields.FK_IDA) 'CER



    '    Try
    '        'Dim rcvdate As Date = dao.fields.rcvdate
    '        'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
    '        class_xml.dh15rqts = dao.fields

    '    Catch ex As Exception

    '    End Try

    '    'Try
    '    '    Dim appvdate As Date = class_xml.dalcns.appvdate
    '    '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
    '    '    class_xml.fregntf.appvdate = appvdate
    '    'Catch ex As Exception

    '    'End Try

    '    ' p_ = class_xml

    '    Dim statusId As Integer = dao.fields.STATUS_ID
    '    Dim lcntype As Integer = 0 'dao.fields.lcntpcd


    '    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '    dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)

    '    Dim paths As String = bao._PATH_DEFAULT
    '    Dim PDF_TEMPLATE As String = paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
    '    LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


    '    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
    '    hl_reader.NavigateUrl = "../PDF/PDF_PERVIEW2.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
    '    HiddenField1.Value = filename
    '    '    show_btn() 'ตรวจสอบปุ่ม
    'End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        'alert("กลับสู่หน้าหลัก")
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class