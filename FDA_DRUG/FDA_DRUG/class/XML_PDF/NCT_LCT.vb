Public Class XML_PDF_NCT_LCT

    Private _XML_PATH_PDF As String
    Public Property XML_PATH_PDF() As String
        Get
            Return _XML_PATH_PDF
        End Get
        Set(ByVal value As String)
            _XML_PATH_PDF = value
        End Set
    End Property


    Private _XML_CITIZEN_ID_AUTHORIZE As String
    Public Property XML_CITIZEN_ID_AUTHORIZE() As String
        Get
            Return _XML_CITIZEN_ID_AUTHORIZE
        End Get
        Set(ByVal value As String)
            _XML_CITIZEN_ID_AUTHORIZE = value
        End Set
    End Property

    Private _MAIN_IDA As Integer
    Public Property MAIN_IDA() As Integer
        Get
            Return _MAIN_IDA
        End Get
        Set(ByVal value As Integer)
            _MAIN_IDA = value
        End Set
    End Property



    Private _XML_TYPE As String
    Public Property XML_TYPE() As String
        Get
            Return _XML_TYPE
        End Get
        Set(ByVal value As String)
            _XML_TYPE = value
        End Set
    End Property



    Public Sub BindData_PDF(ByVal IDA As Integer)

        Dim statusID As Integer = 0
        Dim ProcessID As Integer = 0

        Dim grouptype As String = "00"

        Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        dao_la.GetDataby_IDA(IDA)

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao_la.fields.TR_ID)

        'Dim IDA As Integer = dao_la.fields.IDA
        Dim TR_ID As Integer = dao_la.fields.TR_ID
        Dim LCNSID As String = dao_la.fields.lcnsid
        Dim CITIZEN_ID_AUTHORIZE As String = _XML_CITIZEN_ID_AUTHORIZE
        Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID
        'Dim PROCESS_ID As Integer = dao_la.fields.PROCESS_ID
        statusID = dao_la.fields.STATUS_ID
        ProcessID = dao_up.fields.PROCESS_ID
       
      

        Dim cls_NCONVERTRQT As New Gen_XML.GEN_XML_NCT_LCT_ADDR

        cls_NCONVERTRQT.CITIZEN_ID = dao_la.fields.CITIZEN_ID
        cls_NCONVERTRQT.CITIZEN_AUTHORIZE = _XML_CITIZEN_ID_AUTHORIZE
        cls_NCONVERTRQT.IDA = IDA


        Dim class_xml As New CLS_LOCATION
        class_xml = cls_NCONVERTRQT.gen_xml_nct_lctaddr()
        class_xml.NCT_LCTADDRs = dao_la.fields


        Dim cls_LOCATION_BSN As New DAO_CPN.TB_LOCATION_BSN
        cls_LOCATION_BSN.Getdata_by_fk_id(IDA)
        class_xml.LOCATION_BSNs = cls_LOCATION_BSN.Details
        '_______________SHOW___________________

        Dim bao_show As New BAO_SHOW
        Try
            class_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(CITIZEN_ID) 'ชื่อผู้ ทำ PDF
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT5 = bao_show.SP_SP_SYSTHMBL() 'ตำบล ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT6 = bao_show.SP_SP_SYSAMPHR() 'อำเภอ ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT7 = bao_show.SP_SP_SYSCHNGWT() 'จังหวัด ไว้ใส่ ดรอปดาว

        class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX() 'คำนำหน้า ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, LCNSID) 'สถานที่หลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_XML_CITIZEN_ID_AUTHORIZE, LCNSID) 'ชื่อและข้อมูลผู้ประกอบการ



        class_xml.SHOW_THAI_birthdate = " "

        XML_LOCATIONs = class_xml

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(ProcessID, 0, statusID, grouptype, 0)

        Dim paths As String = _PATH_DEFALUT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DRUG", ProcessID, con_year(Date.Now.Year), TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DRUG", ProcessID, con_year(Date.Now.Year), TR_ID)

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, ProcessID, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        _XML_PATH_PDF = Path_PDF
        '      HiddenField1.Value = Path_PDF

        '      lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & Path_PDF & "' ></iframe>"
        '      hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & Path_PDF ' Link เปิดไฟล์ตัวใหญ่
        '   show_btn() 'ตรวจสอบปุ่ม
    End Sub
End Class
