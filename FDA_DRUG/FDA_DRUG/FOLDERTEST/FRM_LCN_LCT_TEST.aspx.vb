Imports System.Xml.Serialization
Imports System.IO

Public Class FRM_LCN_LCT_TEST
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _type As String
    Private _ProcessID As Integer
    Private _ProcessID_KEEP As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        BindPDF()
    End Sub

    Private Sub BindPDF()
        Dim bao As New BAO.DOWNLOAD_TRANSECTION
        bao.CITIZEN_ID = _CLS.CITIZEN_ID
        bao.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        Dim down_ID As Integer = bao.insert_transection(_ProcessID) ' สร้างเลข DOWNLOAD_TRANSECTION

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, 0, 0, 0) 'หา  PDF TEMPLAETE


        Dim paths As String = _PATH_DEFALUT

        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE  'ระบุ PDF TEMPLAETE
        Dim PATH_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_DOWNLOAD("DA_CER", _ProcessID, con_year(Date.Now.Year), down_ID) 'สร้างชื่อ PDF 
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_DOWNLOAD("DA_CER", _ProcessID, con_year(Date.Now.Year), down_ID) 'สร้างชื่อ XML

        CREATE_XML(Path_XML, down_ID) 'ทำการสร้าง XML 
        convert_XML_To_PDF(PATH_PDF, Path_XML, PDF_TEMPLATE) 'ทำการนำ XML เข้าไปใส่ที่ PDF
        _CLS.FILENAME_PDF = PATH_PDF 'ที่อยู่ไฟล์ PDF เพื่อดาวโหลด
        _CLS.FILENAME_PDF_DOWNLOAD = NAME_DOWNLOAD_PDF("DA_CER", down_ID) 'ชื่อที่ตั้งให้ PDF
        Session("CLS") = _CLS 'เก็บใน Session

    End Sub


    ' ''' <summary>
    ' ''' สร้าง ไฟล์ XML
    ' ''' </summary>
    ' ''' <param name="PATH_XML"></param>
    ' ''' <remarks></remarks>
    Private Sub CREATE_XML(ByVal PATH_XML As String, ByVal DownID As Integer)
        Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
        Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE

        Dim Cls_NCT_LCT As New Gen_XML.GEN_XML_NCT_LCT_ADDR
        Cls_NCT_LCT.IDA = 0
        Cls_NCT_LCT.LCNSID = _CLS.LCNSID_CUSTOMER
        Cls_NCT_LCT.lcntpcd = _type
        Cls_NCT_LCT.CITIZEN_ID = _CLS.CITIZEN_ID
        Cls_NCT_LCT.CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        Cls_NCT_LCT.PVNCD = _CLS.PVCODE

        Dim cls_xml As New CLS_LOCATION
        cls_xml = Cls_NCT_LCT.gen_xml_nct_lctaddr()
        cls_xml.CITIZEN_ID = _CLS.CITIZEN_ID
        cls_xml.DOWNLOAD_ID = DownID
        cls_xml.lcntpcd = _type


        '_______________SHOW___________________

        Dim bao_show As New BAO_SHOW
        Try

            cls_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID) 'ชื่อผู้ ทำ PDF
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT5 = bao_show.SP_SP_SYSTHMBL() 'ตำบล ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT6 = bao_show.SP_SP_SYSAMPHR() 'อำเภอ ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT7 = bao_show.SP_SP_SYSCHNGWT() 'จังหวัด ไว้ใส่ ดรอปดาว

        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX() 'คำนำหน้า ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, LCNSID) 'สถานที่หลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID) 'ชื่อและข้อมูลผู้ประกอบการ
        cls_xml.SHOW_THAI_birthdate = " "

        Dim objStreamWriter As New StreamWriter(PATH_XML)
        Dim x As New XmlSerializer(Cls_XML.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub
End Class