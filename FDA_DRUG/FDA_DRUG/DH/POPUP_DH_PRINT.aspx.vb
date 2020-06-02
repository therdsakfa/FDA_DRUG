Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Imports System.IO

Public Class POPUP_DH_PRINT
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _YEARS As String

    Sub RunSession()
        Try
            _process = Request.QueryString("process")
        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BindData_PDF()
        End If
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)

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
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        Dim dao_DH15_DETAIL_CER As New DAO_DRUG.TB_DH15_DETAIL_CER
        Dim dao_DH15_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL


        dao.GetDataby_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
        dao_DH15_DETAIL_CER.GetDataby_FK_IDA(dao.fields.IDA)
        dao_DH15_DETAIL_CASCHEMICAL.GetDataby_FK_IDA(dao.fields.IDA)


        Dim cls_regis As New CLASS_GEN_XML.DH(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao.fields.FK_IDA)

        Dim class_xml As New CLASS_DH
        ' class_xml = cls_regis.gen_xml()

        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao_lcn.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao_lcn.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน


        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER


        class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt() 'ประเทศ
        class_xml.DT_MASTER.DT18 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(dao.fields.TR_ID) 'สารที่เลือก
        class_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao.fields.FK_IDA) 'CER

        Try
            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
            dao_iso.GetDataby_IDA(dao.fields.AGENT_COUNTRY_ID)
            class_xml.AGENT_COUNTRY_NAME = dao_iso.fields.engcntnm
        Catch ex As Exception

        End Try
        Try
            '
            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
            dao_iso.GetDataby_IDA(dao.fields.FOREIGN_COUNTRY_CD)
            class_xml.FOREIGN_COUNTRY_NAME = dao_iso.fields.engcntnm
        Catch ex As Exception

        End Try

        Dim CER_DETAIL_CHEMICAL_IDA As Integer = 0
        Try
            CER_DETAIL_CHEMICAL_IDA = dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA
        Catch ex As Exception



        End Try


        '-------------------------ใส่ข้อมูลย่อยลงxml---------------------------
        For Each dao_DH15_DETAIL_CER.fields In dao_DH15_DETAIL_CER.datas
            Dim cls_DH15_DETAIL_CER As New DH15_DETAIL_CER
            cls_DH15_DETAIL_CER = dao_DH15_DETAIL_CER.fields
            class_xml.DH15_DETAIL_CERs.Add(cls_DH15_DETAIL_CER)
        Next


        For Each dao_DH15_DETAIL_CASCHEMICAL.fields In dao_DH15_DETAIL_CASCHEMICAL.datas
            Dim cls_DH15_DETAIL_CASCHEMICAL As New DH15_DETAIL_CASCHEMICAL
            cls_DH15_DETAIL_CASCHEMICAL = dao_DH15_DETAIL_CASCHEMICAL.fields
            class_xml.DH15_DETAIL_CASCHEMICALs.Add(cls_DH15_DETAIL_CASCHEMICAL)
        Next


        '------------------------------------------



        class_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(CER_DETAIL_CHEMICAL_IDA) 'สาร
        class_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(CER_DETAIL_CHEMICAL_IDA) 'สถานที่ผลิต


        class_xml.DT_MASTER.DT32 = bao_master.SP_MASTER_DH15_DETAIL_CER_by_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT33 = bao_master.SP_MASTER_DH15_DETAIL_CASCHEMICAL_by_FK_IDA(dao.fields.IDA) 'สารที่เลือกใน ภค
        Try
            'Dim rcvdate As Date = dao.fields.rcvdate
            'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.dh15rqts = dao.fields

        Catch ex As Exception

        End Try
        p_dh = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_process, _process, statusId, 99)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
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

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class