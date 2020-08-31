Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports FDA_DRUG.XML_CENTER
Imports System.Xml.Serialization
Imports System.IO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_DRUG_XML
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GET_PDF_DOWNLOAD(ByVal Process_id As String, ByVal System_ID As String, ByVal Bsn_Identify As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal PVCODE As String, ByVal lct_ida As String _
                                     , ByVal lcn_ida As String, ByVal CITIZEN_ID As String) As String
        Dim b64_str As String = ""
        'If Process_id = "101" Or Process_id = "102" Or Process_id = "103" Or Process_id = "104" Or Process_id = "105" Or Process_id = "106" Or _
        '    Process_id = "107" Or Process_id = "108" Or Process_id = "109" Or Process_id = "110" Or Process_id = "111" Or Process_id = "112" Or _
        '    Process_id = "113" Or Process_id = "114" Or Process_id = "115" Or Process_id = "116" Or Process_id = "117" Or Process_id = "118" Or Process_id = "119" Then

        Dim bind_pdf As New FRM_LCN_DRUG
        b64_str = GET_PDF(Process_id, CITIZEN_ID, CITIZEN_ID_AUTHORIZE, PVCODE, lct_ida, Bsn_Identify, lcn_ida)

        'ElseIf Process_id = "31" Or Process_id = "32" Or Process_id = "33" Or Process_id = "34" Or Process_id = "35" Or Process_id = "36" Then
        '    Dim bind_pdf As New FRM_LCN_DRUG
        '    b64_str = GET_PDF(Process_id, "", CITIZEN_ID_AUTHORIZE, PVCODE, lct_ida, Bsn_Identify)
        'End If

        Return b64_str
    End Function
    <WebMethod()> _
    Public Function SEND_PDF_UPLOAD(ByVal Process_id As String, ByVal B64_Str As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal CITIZEN_ID_UPLOAD As String, ByVal location_ida As Integer, ByVal pvncd As Integer) As String
        Dim result As String = ""
        If B64_Str <> "" Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()
            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = CITIZEN_ID_UPLOAD
            bao_tran.CITIZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(Process_id)
            Dim check As Boolean = True
            If Process_id = 101 Or Process_id = 102 Or Process_id = 103 _
            Or Process_id = 104 Or Process_id = 105 Or Process_id = 106 _
            Or Process_id = 107 Or Process_id = 108 Or Process_id = 109 _
             Or Process_id = 110 Or Process_id = 111 Or Process_id = 112 Or Process_id = 113 _
               Or Process_id = 114 Or Process_id = 115 Or Process_id = 116 Or Process_id = 117 Or Process_id = 118 _
               Or Process_id = 119 Or Process_id = 120 Or Process_id = 121 Or Process_id = 122 Or Process_id = 123 Or Process_id = 124 Or Process_id = 125 _
                    Or Process_id = 126 Or Process_id = 127 Or Process_id = 128 Then
                Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
                dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(Process_id, 1, 0)
                'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", Process_id, Date.Now.Year, TR_ID)
                'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", Process_id, Date.Now.Year, TR_ID)
                StremeFile(B64_Str, NAME_UPLOAD_PDF("DA", Process_id, Date.Now.Year, TR_ID), PDF_TRADER)
                convert_PDF_To_XML(PDF_TRADER, XML_TRADER)
                check = insrt_to_database_LCN(XML_TRADER, TR_ID, Process_id, CITIZEN_ID_AUTHORIZE, CITIZEN_ID_UPLOAD, location_ida, pvncd)
            End If
            If check = True Then
                'SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
                result = TR_ID
            Else
                result = "Fail"
            End If

        Else
            result = "Fail"
        End If
        Return result
    End Function
    <WebMethod()> _
    Public Function SEND_ATTACH(ByVal Process_id As String, ByVal B64_Str As String, ByVal TR_ID As String, ByVal FILE_NAME_REAL As String, ByVal file_seq As Integer) As String
        Dim result As String = ""
        If B64_Str <> "" Then
            Try
                ATTACH(B64_Str, FILE_NAME_REAL, TR_ID, Process_id, Date.Now.Year, file_seq)
                result = "Success"
            Catch ex As Exception
                result = "Fail"
            End Try
        Else
            result = "Fail"
        End If
        Return result
    End Function
    <WebMethod()> _
    Public Function GET_PDF_PREIVEW(ByVal Process_id As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal CITIZEN_ID As String, ByVal _IDA As String) As String
        Dim b64_str As String = ""
        Dim bind_pdf As New FRM_LCN_DRUG
        b64_str = GET_PREVIEW(Process_id, CITIZEN_ID, _IDA)
        Return b64_str
    End Function
    Private Function UpLoadImageFile_FLATTEN(ByVal info As String) As String
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        imgBin = reader.ReadBytes(stream.Length)

        Dim ws_F As New WS_FLATTEN.WS_FLATTEN

        Dim b_o As Byte() = ws_F.FlattenPDF_DIGITAL(imgBin)



        Dim base64 As String = Convert.ToBase64String(b_o)
        stream.Close()
        stream.Dispose()
        stream = Nothing
        reader.Close()
        reader = Nothing
        Return base64
    End Function
    Private Function GET_PDF(ByVal _process As String, ByVal CITIZEN_ID As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal PVCODE As String, ByVal lct_ida As String, ByVal bsn_iden As String, ByVal lcn_ida As String, Optional Tamrab_id As Integer = 0, Optional ByVal regist_ida As Integer = 0) As String
        Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
        bao_app.RunAppSettings()                                                    'บอกที่อยู่ของไฟล์
        Dim aa As String = ""
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process                                       ' ชื่อ Process
        dao_down.fields.CITIEZEN_ID = CITIZEN_ID                               ' รับค่าจากเทเบิ้ล บัตรประชาชน
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE           ' รับ ชื่อประกอบการ
        dao_down.fields.STATUS = STATUS                                             ' รับเก็บค่า STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE                               'เวลา
        dao_down.insert()                                                           ' insert ค่าข้างบน
        down_ID = dao_down.fields.ID


        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        If _process = "101" Or _process = "102" Or _process = "103" Or _process = "104" Or _process = "105" Or _process = "106" Or _
           _process = "107" Or _process = "108" Or _process = "109" Or _process = "110" Or _process = "111" Or _process = "112" Or _
           _process = "113" Or _process = "114" Or _process = "115" Or _process = "116" Or _process = "117" Or _process = "118" Or _
           _process = "119" Or _process = "120" Or _process = "121" Or _process = "122" Then

            convert_Database_To_XML_DALCN(file_xml, CITIZEN_ID_AUTHORIZE, "0", PVCODE, lct_ida, bsn_iden)

        ElseIf _process = "31" Or _process = "32" Or _process = "33" Or _process = "34" Or _process = "35" Or _process = "36" Then
            convert_Database_To_XML_DI(file_xml, CITIZEN_ID_AUTHORIZE, "0", PVCODE, lcn_ida, _process, CITIZEN_ID, lct_ida)
        ElseIf _process = "14" Or _process = "15" Or _process = "16" Or _process = "17" Then
            convert_Database_To_XML_DH(file_xml, CITIZEN_ID_AUTHORIZE, "0", PVCODE, lcn_ida, _process, CITIZEN_ID, lct_ida)
        ElseIf _process = "130001" Or _process = "130002" Or _process = "130003" Or _process = "130004" Then
            If Tamrab_id = 0 Then
                convert_Database_To_XML_REGIST(file_xml, CITIZEN_ID_AUTHORIZE, "0", PVCODE, lcn_ida, _process, CITIZEN_ID, lct_ida)
            Else
                convert_Database_To_XML_REGIST15(file_xml, CITIZEN_ID_AUTHORIZE, "0", PVCODE, lcn_ida, _process, CITIZEN_ID, lct_ida, Tamrab_id)
            End If
        ElseIf _process = "1400001" Then
            convert_Database_To_XML_DR(file_xml, CITIZEN_ID_AUTHORIZE, "0", PVCODE, lcn_ida, _process, CITIZEN_ID, lct_ida, regist_ida)
        End If
        ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        'NAME_DOWNLOAD_PDF("DA", down_ID)


        Dim clsds As New ClassDataset
        aa = clsds.UpLoadImageFile(file_PDF)

        Return aa
    End Function

    Private Function GET_PREVIEW(ByVal _process As String, ByVal CITIZEN_ID As String, ByVal IDA As String, Optional ByVal STATUS_ID As Integer = 0) As String
        Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
        bao_app.RunAppSettings()                                                    'บอกที่อยู่ของไฟล์
        Dim aa As String = ""
        Dim file_PDF As String = ""
        If _process = "101" Or _process = "102" Or _process = "103" Or _process = "104" Or _process = "105" Or _process = "106" Or _
           _process = "107" Or _process = "108" Or _process = "109" Or _process = "110" Or _process = "111" Or _process = "112" Or _
           _process = "113" Or _process = "114" Or _process = "115" Or _process = "116" Or _process = "117" Or _process = "118" Or _
           _process = "119" Or _process = "120" Or _process = "121" Or _process = "122" Then

            file_PDF = BindData_PDF_LCN(IDA, CITIZEN_ID)

        ElseIf _process = "31" Or _process = "32" Or _process = "33" Or _process = "34" Or _process = "35" Or _process = "36" Then
            file_PDF = BindData_PDF_DI(IDA, CITIZEN_ID, _process)
        ElseIf _process = "14" Or _process = "15" Or _process = "16" Or _process = "17" Then
            file_PDF = BindData_PDF_DH(IDA, CITIZEN_ID, _process)

        ElseIf _process = "130001" Or _process = "130002" Or _process = "130003" Or _process = "130004" Then
            file_PDF = BindData_PDF_REGIST(IDA, CITIZEN_ID, _process)
        ElseIf _process = "1400001" Then
            file_PDF = BindData_PDF_DR(IDA, CITIZEN_ID, _process, STATUS_ID)
        End If

        'Dim clsds As New ClassDataset
        'aa = clsds.UpLoadImageFile(file_PDF)
        aa = UpLoadImageFile_FLATTEN(file_PDF)
        Return aa
    End Function

    Private Sub convert_Database_To_XML_DALCN(ByVal path As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal LCNSID_CUSTOMER As String, ByVal PVCODE As String, ByVal lct_ida As String, ByVal bsn_iden As String)
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER, "1", PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN                                                                        ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml


        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        If cls_xml.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

        ws2.insert_taxno(bsn_iden)




        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(bsn_iden) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        'Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        Try
            cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(lct_ida)
        Catch ex As Exception

        End Try

        ' End If
        cls_xml.BSN_IDENTIFY = bsn_iden


        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao.Getdata_by_fk_id2(lct_ida)

        Try
            If dao.fields.BSN_NATIONALITY_CD = 1 Then
                cls_xml.dalcns.NATION = "ไทย"
            End If
        Catch ex As Exception

        End Try

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub

    Private Sub convert_Database_To_XML_DI(ByVal path As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal LCNSID_CUSTOMER As String, ByVal PVCODE As String, ByVal lcn_ida As String, ByVal Process_id As String, _
                                           ByVal CITIZEN_ID As String, ByVal lct_ida As String)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(lcn_ida)
        Dim dao_dalcntype As New DAO_DRUG.ClsDBdalcntype
        dao_dalcntype.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)
        Dim cls_CER As New CLASS_GEN_XML.Cer(CITIZEN_ID, LCNSID_CUSTOMER, 1, lcn_ida)
        Dim cls_xml As New CLASS_CER
        cls_xml = cls_CER.gen_xml_CER()
        cls_xml.CERs.CER_TYPE = Process_id

        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        cls_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(CITIZEN_ID)
        'ชื่อบริษัท
        cls_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID_CUSTOMER)

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lcn_ida) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(lct_ida) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER


        'ชื่อประเภทยา
        cls_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_dactg()

        'ประเทศ
        cls_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt()

        'เลขที่ใบอนุญาต
        cls_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(lcn_ida)

        ' bao_master.SP_MASTER_fafdtype.TableName = "ประกาศใบอนุญาต"
        cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(lcn_ida)

        'ประเภท Cer
        cls_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_lgt_impcertp()

        'สาร
        'cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()
        cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT(LCNSID_CUSTOMER) 'สาร แปลงเลข ID

        cls_xml.DT_MASTER.DT15 = bao_master.SP_PICS_NATIONAL()

        'cls_xml.URL_CHEMICAL_SEARCH = "http://10.111.28.101/FDA_DRUG/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + _lcn_ida + "&lcnsid=" + _CLS.LCNSID_CUSTOMER.ToString()

        Dim host As String = HttpContext.Current.Request.Url.Host
        cls_xml.URL_CHEMICAL_SEARCH = host & "/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + lcn_ida + "&lcnsid=" + LCNSID_CUSTOMER.ToString()

        cls_xml.LCNNO_SHOW = dao_lcn.fields.LCNNO_DISPLAY
        cls_xml.TYPE_IMPORT = dao_dalcntype.fields.lcntpnm

        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub

    Private Sub convert_Database_To_XML_DH(ByVal path As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal LCNSID_CUSTOMER As String, ByVal PVCODE As String, ByVal lcn_ida As String, ByVal Process_id As String, _
                                           ByVal CITIZEN_ID As String, ByVal lct_ida As String)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(lcn_ida)
        Dim dao_cer As New DAO_DRUG.TB_CER
        If Process_id <> "16" And Process_id <> "17" Then
            dao_cer.GetDataby_FK_IDA(lcn_ida)
        End If



        Dim cls_gen As New CLASS_GEN_XML.DH(CITIZEN_ID, LCNSID_CUSTOMER, dao_lcn.fields.lcnno, "1", dao_lcn.fields.pvncd, lcn_ida)
        Dim cls_xml As New CLASS_DH
        cls_xml = cls_gen.gen_xml()


        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        cls_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt() 'ประเทศ
        If Process_id <> "16" And Process_id <> "17" Then
            cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(dao_cer.fields.FK_IDA) 'สารที่เลือก
            cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao_cer.fields.FK_IDA) 'CER
        End If


        'สาร
        If Process_id = 16 Or Process_id = 17 Then
            cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT(LCNSID_CUSTOMER)  'สาร แปลงเลข ID
            Dim host As String = HttpContext.Current.Request.Url.Host
            'cls_xml.URL_CHEMICAL_SEARCH = "http://10.111.28.101/FDA_DRUG/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + _lcn_ida + "&lcnsid=" + _CLS.LCNSID_CUSTOMER.ToString()
            cls_xml.URL_CHEMICAL_SEARCH = host & "/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + lcn_ida + "&lcnsid=" + LCNSID_CUSTOMER.ToString()

        End If

        Try
            cls_xml.dh15rqts.LCNNO_DISPLAY = dao_lcn.fields.LCNNO_DISPLAY
            cls_xml.dh15rqts.lcnno = dao_lcn.fields.lcnno
            If dao_lcn.fields.lcntpcd = "ผย1" Then
                cls_xml.dh15rqts.CHK_TYPE_LCN = 1
            ElseIf dao_lcn.fields.lcntpcd = "นย1" Then
                cls_xml.dh15rqts.CHK_TYPE_LCN = 2
            End If

            If Process_id = 14 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "00"
            ElseIf Process_id = 15 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "01"
            ElseIf Process_id = 16 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "00"
            ElseIf Process_id = 17 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "01"
            ElseIf Process_id = 18 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "00"
            End If
        Catch ex As Exception

        End Try

        Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                     'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub

    Private Sub convert_Database_To_XML_REGIST(ByVal path As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal LCNSID_CUSTOMER As String, ByVal PVCODE As String, ByVal lcn_ida As String, ByVal Process_id As String, _
                                           ByVal CITIZEN_ID As String, ByVal lct_ida As String)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(Integer.Parse(lcn_ida))
        Dim dao_cer As New DAO_DRUG.TB_CER
        dao_cer.GetDataby_FK_IDA(lcn_ida)
        'Dim _product_id As Integer = 0
        'Try
        '    _product_id = ddl_product_id.SelectedValue
        'Catch ex As Exception

        'End Try
        Dim cls As New CLASS_GEN_XML.DRUG_REGISTRATION(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER, dao_lcn.fields.lcnno, Process_id, dao_lcn.fields.IDA)
        Dim cls_xml As New CLASS_REGISTRATION

        cls_xml = cls.gen_xml()
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        'Try
        '    cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน
        'Catch ex As Exception

        'End Try

        'cls_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(_product_id) 'ข้อมูลที่ดึงมาจาก Product ID


        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand

        'cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao_lcn.fields.IDA) 'CER
        'cls_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        'cls_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        'cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        'cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT(_CLS.LCNSID_CUSTOMER) 'สาร

        'cls_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL() 'กลุ่มตำรับ
        'cls_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา

        cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(0) 'CER
        cls_xml.DT_MASTER.DT15.TableName = "SP_MASTER_CER_PK_BY_FK_IDA"
        cls_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        cls_xml.DT_MASTER.DT16.TableName = "SP_dactg"
        'cls_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        'cls_xml.DT_MASTER.DT17.TableName = "SP_drkdofdrg"
        cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        cls_xml.DT_MASTER.DT18.TableName = "SP_CER_FOREIGN_BY_IDA"
        'Dim dt9 As DataTable = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI() 'สาร
        'Dim dt99 As New DataTable
        'dt99 = dt9.Clone()
        'For Each dr As DataRow In dt9.Select("aori='A'")
        '    Dim dr1 As DataRow = dt99.NewRow()
        '    dr1 = dr
        '    dt99.Rows.Add(dr1)
        'Next
        'cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI_V2("A") 'สาร
        'cls_xml.DT_MASTER.DT19.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        'cls_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL() 'กลุ่มตำรับ
        'cls_xml.DT_MASTER.DT20.TableName = "SP_ATC_DRUG_ALL"

        cls_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา
        cls_xml.DT_MASTER.DT21.TableName = "SP_dosage_form"
        cls_xml.DT_MASTER.DT22 = bao_master_2.SP_DRUG_UNIT_PHYSIC() 'หน่วยเล็กสุด
        cls_xml.DT_MASTER.DT22.TableName = "SP_DRUG_UNIT_PHYSIC"
        cls_xml.DT_MASTER.DT23 = bao_master_2.SP_MASTER_drsunit() 'หน่วย
        cls_xml.DT_MASTER.DT23.TableName = "SP_MASTER_drsunit"
        'cls_xml.DT_MASTER.DT24 = bao_master_2.SP_FOREIGN_ADDR_ALL()
        'cls_xml.DT_MASTER.DT24.TableName = "SP_FOREIGN_ADDR_ALL"

        Dim lcnno_raw As String = ""
        Dim lcnno As String = ""
        Try
            'lcnno_raw = dao_lcn.fields.LCNNO_DISPLAY
            'If lcnno_raw <> "" Then
            lcnno = dao_lcn.fields.lcntpcd & " " & CInt(Right(dao_lcn.fields.lcnno, 5)) & "/25" & Left(dao_lcn.fields.lcnno, 2)
            'End If
        Catch ex As Exception

        End Try
        cls_xml.SHOW_LCNNO = lcnno
        cls_xml.DRUG_REGISTRATIONs.LCNNO = dao_lcn.fields.lcnno
        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 1
        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 2
        End If


        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub
    Private Sub convert_Database_To_XML_REGIST15(ByVal path As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal LCNSID_CUSTOMER As String, ByVal PVCODE As String, ByVal lcn_ida As String, ByVal Process_id As String, _
                                          ByVal CITIZEN_ID As String, ByVal lct_ida As String, ByVal Tamrab_id As Integer)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(Integer.Parse(lcn_ida))
        Dim dao_cer As New DAO_DRUG.TB_CER
        dao_cer.GetDataby_FK_IDA(lcn_ida)
        'Dim _product_id As Integer = 0
        'Try
        '    _product_id = ddl_product_id.SelectedValue
        'Catch ex As Exception

        'End Try
        Dim cls As New CLASS_GEN_XML.DRUG_REGISTRATION(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER, dao_lcn.fields.lcnno, Process_id, dao_lcn.fields.IDA)
        Dim cls_xml As New CLASS_REGISTRATION



        cls_xml = cls.gen_xml()
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        'Try
        '    cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน
        'Catch ex As Exception

        'End Try

        'cls_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(_product_id) 'ข้อมูลที่ดึงมาจาก Product ID


        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand

        'cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao_lcn.fields.IDA) 'CER
        'cls_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        'cls_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        'cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        'cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT(_CLS.LCNSID_CUSTOMER) 'สาร

        'cls_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL() 'กลุ่มตำรับ
        'cls_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา

        cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(0) 'CER
        cls_xml.DT_MASTER.DT15.TableName = "SP_MASTER_CER_PK_BY_FK_IDA"
        cls_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        cls_xml.DT_MASTER.DT16.TableName = "SP_dactg"
        'cls_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        'cls_xml.DT_MASTER.DT17.TableName = "SP_drkdofdrg"
        cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        cls_xml.DT_MASTER.DT18.TableName = "SP_CER_FOREIGN_BY_IDA"
        'Dim dt9 As DataTable = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI() 'สาร
        'Dim dt99 As New DataTable
        'dt99 = dt9.Clone()
        'For Each dr As DataRow In dt9.Select("aori='A'")
        '    Dim dr1 As DataRow = dt99.NewRow()
        '    dr1 = dr
        '    dt99.Rows.Add(dr1)
        'Next
        'cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI_V2("A") 'สาร
        'cls_xml.DT_MASTER.DT19.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        'cls_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL() 'กลุ่มตำรับ
        'cls_xml.DT_MASTER.DT20.TableName = "SP_ATC_DRUG_ALL"

        cls_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา
        cls_xml.DT_MASTER.DT21.TableName = "SP_dosage_form"
        cls_xml.DT_MASTER.DT22 = bao_master_2.SP_DRUG_UNIT_PHYSIC() 'หน่วยเล็กสุด
        cls_xml.DT_MASTER.DT22.TableName = "SP_DRUG_UNIT_PHYSIC"
        cls_xml.DT_MASTER.DT23 = bao_master_2.SP_MASTER_drsunit() 'หน่วย
        cls_xml.DT_MASTER.DT23.TableName = "SP_MASTER_drsunit"
        'cls_xml.DT_MASTER.DT24 = bao_master_2.SP_FOREIGN_ADDR_ALL()
        'cls_xml.DT_MASTER.DT24.TableName = "SP_FOREIGN_ADDR_ALL"

        Dim lcnno_raw As String = ""
        Dim lcnno As String = ""
        Try
            'lcnno_raw = dao_lcn.fields.LCNNO_DISPLAY
            'If lcnno_raw <> "" Then
            lcnno = dao_lcn.fields.lcntpcd & " " & CInt(Right(dao_lcn.fields.lcnno, 5)) & "/25" & Left(dao_lcn.fields.lcnno, 2)
            'End If
        Catch ex As Exception

        End Try

        Dim dao As New DAO_DRUG.TB_MAS_TAMRAP_NAME
        dao.GetDataby_TAMRAP_ID(Tamrab_id)
        cls_xml.DRUG_REGISTRATIONs.DRUG_NAME_THAI = dao.fields.TAMRAP_NAME

        cls_xml.SHOW_LCNNO = lcnno
        cls_xml.DRUG_REGISTRATIONs.LCNNO = dao_lcn.fields.lcnno
        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 1
        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 2
        End If


        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub
    Private Sub convert_Database_To_XML_DR(ByVal path As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal LCNSID_CUSTOMER As String, ByVal PVCODE As String, ByVal lcn_ida As String, ByVal Process_id As String, _
                                           ByVal CITIZEN_ID As String, ByVal lct_ida As String, ByVal ida_regist As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(lcn_ida)
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        'Dim CHK_LCN_SUBTYPE1 As String = ""
        'Dim CHK_LCN_SUBTYPE2 As String = ""
        'Dim CHK_LCN_SUBTYPE3 As String = ""

        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                TABEAN_TYPE1 = "0"
                TABEAN_TYPE2 = "1"
            Else
                TABEAN_TYPE1 = "1"
                TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        'Try
        '    LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        'Catch ex As Exception

        'End Try
        Try

            If Len(dao.fields.lcnno) > 0 Then
                If dao.fields.pvnabbr <> "กท" Then
                    If Right(Left(dao.fields.lcnno, 3), 1) = "5" Then
                        LCNNO_FORMAT = "จ. " & CStr(CInt(Right(dao.fields.lcnno, 4))) & "/25" & Left(dao.fields.lcnno, 2)
                    Else
                        LCNNO_FORMAT = dao.fields.pvnabbr & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
                    End If
                Else
                    LCNNO_FORMAT = CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
                End If

            End If
        Catch ex As Exception

        End Try
        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_re.GetDataby_IDA(ida_regist)
        Try
            drug_name = dao_re.fields.DRUG_NAME_THAI & " / " & dao_re.fields.DRUG_NAME_OTHER
        Catch ex As Exception

        End Try

        'If Process_id = 11 Then
        Dim cls As New CLASS_GEN_XML.DR(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER, dao.fields.lcnno, Process_id, LCN_IDA:=lcn_ida)
        Dim cls_xml As New CLASS_DR
        cls_xml = cls.gen_xml()
        Try
            Dim dao_dos As New DAO_DRUG.TB_drdosage
            dao_dos.GetDataby_cd(dao_re.fields.FK_DOSAGE_FORM)
            cls_xml.Dossage_form = dao_dos.fields.thadsgnm & "/" & dao_dos.fields.engdsgnm
        Catch ex As Exception

        End Try
        Dim dt_pack As New DataTable
        Try
            'Dim bao_pack As New BAO_SHOW
            'dt_pack = bao_pack.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA_v2(_main_ida)
            'cls_xml.PACK_SIZE = dt_pack(0)("full_unit")
            cls_xml.PACK_SIZE = dao_re.fields.PACKAGE_DETAIL
        Catch ex As Exception

        End Try
        Try
            'Dim dao_det As New DAO_DRUG.TB_DRUG_REGISTRATION_PROP_AND_DETAIL
            'dao_det.GetDataby_FK_IDA(_main_ida)
            cls_xml.DRUG_PROPERTIES_AND_DETAIL = dao_re.fields.DRUG_COLOR
        Catch ex As Exception

        End Try


        cls_xml.LCN_TYPE = LCN_TYPE
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.DRUG_NAME = drug_name
        cls_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        cls_xml.TABEAN_TYPE2 = TABEAN_TYPE2
        cls_xml.DRUG_STRENGTH = dao_re.fields.DRUG_STR
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        Dim bao_ori As New BAO.ClsDBSqlcommand
        cls_xml.DT_SHOW.DT8 = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(ida_regist)
        cls_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        cls_xml.DT_SHOW.DT9 = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(ida_regist)
        cls_xml.DT_SHOW.DT9.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        cls_xml.DT_SHOW.DT10 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(ida_regist, "A")
        cls_xml.DT_SHOW.DT10.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_A"
        cls_xml.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(ida_regist, "I")
        cls_xml.DT_SHOW.DT11.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_I"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(ida_regist)
        cls_xml.DT_SHOW.DT12.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"
        cls_xml.DT_SHOW.DT7 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(1) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT7.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2"

        Dim dt13 As New DataTable
        Dim dt14 As New DataTable
        Dim dt15 As New DataTable
        dt13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_regist, 1, LCNTPCD_GROUP)
        dt14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_regist, 2, LCNTPCD_GROUP)
        dt15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_regist, 3, LCNTPCD_GROUP)
        If dt13.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_regist, 1, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        End If
        If dt14.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_regist, 2, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        End If
        If dt15.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_regist, 3, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
        End If
        cls_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_MASTER(ida_regist)
        cls_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_MASTER"
        cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID_CUSTOMER) 'ข้อมูลบริษัท


        cls_xml.DT_SHOW.DT18 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL(ida_regist)
        cls_xml.DT_SHOW.DT18.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL"

        cls_xml.DT_SHOW.DT20 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW(ida_regist) 'สารสำคัญ/ส่วนประกอบ(รวม)
        cls_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"

        cls_xml.DT_SHOW.DT21 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_regist, 9, LCNTPCD_GROUP)
        cls_xml.DT_SHOW.DT21.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_OTHER"

        cls_xml.DT_SHOW.DT22 = bao_show.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(ida_regist)
        cls_xml.DT_SHOW.DT22.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA"

        cls_xml.DT_SHOW.DT23 = bao_ori.SP_regis(ida_regist)
        cls_xml.DT_SHOW.DT23.TableName = "SP_regis"
        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand


        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
        'ElseIf Process_id = 7 Then

        '    Dim cls As New CLASS_GEN_XML.DS(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, Process_id, dao.fields.IDA)
        '    Dim cls_xml As New CLASS_DS
        '    cls_xml = cls.gen_xml()
        '    Dim bao_app As New BAO.AppSettings
        '    bao_app.RunAppSettings()
        '    Dim objStreamWriter As New StreamWriter(path)
        '    Dim x As New XmlSerializer(cls_xml.GetType)
        '    x.Serialize(objStreamWriter, cls_xml)
        '    objStreamWriter.Close()
        'End If




    End Sub

    Private Function BindData_PDF_LCN(ByVal _IDA As String, ByVal CITIZEN_ID As String, Optional _group As Integer = 0) As String
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim pvncd As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao.fields.PROCESS_ID
        End If
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = lcntpcd.Change_lcntpcd()
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(CITIZEN_ID, dao.fields.lcnsid, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        Try
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim BSN_IDENTIFY As String = ""
        Try
            BSN_IDENTIFY = dao.fields.BSN_IDENTIFY
        Catch ex As Exception

        End Try
        Dim MAIN_LCN_IDA As Integer = 0
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao.fields.IDA)


        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If

            End If
        Catch ex As Exception

        End Try
        class_xml.DT_MASTER.DT32 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT32.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"
        class_xml.DT_MASTER.DT33 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        class_xml.DT_MASTER.DT33.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_2_ROW"

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 3)
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.SHOW_LCNNO = lcnno_text

        Try

            class_xml.COUNT_PHESAJ1 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 1)
        Catch ex As Exception

        End Try

        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ2 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 2)
        Catch ex As Exception

        End Try
        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ3 = dao_PHR2.CountDataby_FK_IDA_and_Type(_IDA, 3)
        Catch ex As Exception

        End Try
        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)
                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(appdate.Year)
                End If
                class_xml.EXP_YEAR = expyear
            End If
        Else
            If IsNothing(dao.fields.expyear) = False Then
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                class_xml.EXP_YEAR = expyear
            End If
        End If

        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        p_dalcn = class_xml

        Dim p_dalcn2 As New XML_CENTER.CLASS_DALCN
        p_dalcn2 = p_dalcn
        ' p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dalcn2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_dalcn2)

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntype = lcntype.Change_lcntpcd()
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                Else
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 0, 0)
                End If
            Else

                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 0, 0)
                End If

            End If
        Else

            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try

            If _group = 1 Then
                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=0)
                End If

            Else
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=0)
            End If
        End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, dao.fields.TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, dao.fields.TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        Return filename
    End Function
    Private Function BindData_PDF_DH(ByVal _IDA As Integer, ByVal CITIZEN_ID As String, ByVal _ProcessID As String) As String
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        dao.GetDataby_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)

        Dim dao_DH15_DETAIL_CER As New DAO_DRUG.TB_DH15_DETAIL_CER
        dao_DH15_DETAIL_CER.GetDataby_FK_IDA(dao.fields.IDA)

        Dim dao_DH15_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
        dao_DH15_DETAIL_CASCHEMICAL.GetDataby_FK_IDA(dao.fields.IDA)

        Dim _YEAR As String = ""

        Try
            Dim dao_u As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_u.GetDataby_IDA(dao.fields.TR_ID)
            _YEAR = dao_u.fields.YEAR
        Catch ex As Exception

        End Try

        Dim cls_regis As New CLASS_GEN_XML.DH(CITIZEN_ID, dao_lcn.fields.lcnsid, dao.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.FK_IDA)

        Dim class_xml As New CLASS_DH
        'class_xml = cls_regis.gen_xml()

        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_lcn.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao_lcn.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt() 'ประเทศ
        class_xml.DT_MASTER.DT18 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(dao.fields.TR_ID) 'สารที่เลือก
        class_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao.fields.FK_IDA) 'CER
        If (_ProcessID <> 16 AndAlso _ProcessID <> 17) Then
            class_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA) 'สาร
            class_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA) 'สถานที่ผลิต

        End If
        class_xml.DT_MASTER.DT32 = bao_master.SP_MASTER_DH15_DETAIL_CER_by_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT33 = bao_master.SP_MASTER_DH15_DETAIL_CASCHEMICAL_by_FK_IDA(dao.fields.IDA) 'สารที่เลือกใน ภค
        Try
            'Dim rcvdate As Date = dao.fields.rcvdate
            'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.dh15rqts = dao.fields
            'class_xml.DH15_DETAIL_CERs = dao_DH15_DETAIL_CER.datas
        Catch ex As Exception

        End Try

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try
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
        p_dh = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEAR, dao.fields.TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEAR, dao.fields.TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        Return filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Function
    Private Function BindData_PDF_DI(ByVal _IDA As Integer, ByVal CITIZEN_ID As String, ByVal _ProcessID As String) As String
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
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim PROCESS_ID As String = dao_up.fields.PROCESS_ID.ToString()
        Dim Year As String = dao_up.fields.YEAR.ToString()
        Dim TR_ID As String = dao_up.fields.ID.ToString()
        'Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID


        Dim cls_cer As New CLASS_GEN_XML.Cer(CITIZEN_ID, LCNSID, 1, lcn_IDA)

        Dim class_xml As New CLASS_CER
        'class_xml = cls_cer.gen_xml_CER()'big 20/2/2560

        class_xml.CERs = dao.fields
        class_xml.CER_DETAIL_CASCHEMICALs = dao_CER_DETAIL_CASCHEMICAL.Details()
        p_cer = class_xml

        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Try
            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
            dao_iso.GetDataby_IDA(p_cer.CERs.COUNTRY_OF_DEPARTMENT_IDA)
            class_xml.COUNTRY_OF_DEPARTMENT_NAME = dao_iso.fields.engcntnm
        Catch ex As Exception

        End Try
        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(CITIZEN_ID)
        'ชื่อบริษัท
        class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID)

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_up.fields.CITIEZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.LCNSID) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao_up.fields.CITIEZEN_ID_AUTHORIZE) 'ที่เก็บ
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
        class_xml.LCNNO_SHOW = dao_lcn.fields.LCNNO_DISPLAY
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
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, Year, TR_ID) 'paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, Year, TR_ID) 'paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        Return filename
    End Function
    Private Function BindData_PDF_REGIST(ByVal _IDA As Integer, ByVal CITIZEN_ID As String, ByVal _ProcessID As String) As String
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()


        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim lcn_ida As Integer = 0
        Dim lct_ida As Integer = 0
        Try
            dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
            lcn_ida = dao.fields.FK_IDA
            lct_ida = dao_lcn.fields.FK_IDA
        Catch ex As Exception

        End Try


        Dim cls_regis As New CLASS_GEN_XML.DRUG_REGISTRATION(CITIZEN_ID, dao.fields.LCNSID, _ProcessID, dao.fields.PVNCD)

        Dim class_xml As New CLASS_REGISTRATION

        Try
            Dim dao_color As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)
            class_xml.DRUG_REGISTRATION_COLORs = dao_color.fields
        Catch ex As Exception

        End Try


        Try
            Dim rcvdate As Date = dao.fields.RCVDATE
            dao.fields.RCVDATE = DateAdd(DateInterval.Year, 543, rcvdate)

        Catch ex As Exception

        End Try
        Try
            class_xml.DRUG_REGISTRATIONs = dao.fields
        Catch ex As Exception

        End Try
        p_REGISTRATION = class_xml
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim Year As String = dao_up.fields.YEAR.ToString()
        Dim TR_ID As String = dao_up.fields.ID.ToString()


        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.LCNSID) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(lct_ida) 'ผู้ดำเนิน
        'class_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(_product_id) 'ข้อมูลที่ดึงมาจาก Product ID
        class_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_IDA)
        class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_IDA)
        class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        class_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V3(_IDA)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_IDA)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"
        class_xml.DT_SHOW.DT17 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(_IDA)
        class_xml.DT_SHOW.DT17.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA"

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        class_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(0) 'CER
        class_xml.DT_MASTER.DT15.TableName = "SP_MASTER_CER_PK_BY_FK_IDA"
        class_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        class_xml.DT_MASTER.DT16.TableName = "SP_dactg"
        class_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        class_xml.DT_MASTER.DT17.TableName = "SP_drkdofdrg"
        class_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        class_xml.DT_MASTER.DT18.TableName = "SP_CER_FOREIGN_BY_IDA"
        class_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI() 'สาร
        class_xml.DT_MASTER.DT19.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        class_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL() 'กลุ่มตำรับ
        class_xml.DT_MASTER.DT20.TableName = "SP_ATC_DRUG_ALL"
        class_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา
        class_xml.DT_MASTER.DT21.TableName = "SP_dosage_form"
        class_xml.DT_MASTER.DT22 = bao_master_2.SP_DRUG_UNIT_PHYSIC() 'หน่วยเล็กสุด
        class_xml.DT_MASTER.DT22.TableName = "SP_DRUG_UNIT_PHYSIC"
        class_xml.DT_MASTER.DT23 = bao_master_2.SP_MASTER_drsunit() 'หน่วย
        class_xml.DT_MASTER.DT23.TableName = "SP_MASTER_drsunit"
        class_xml.DT_MASTER.DT24 = bao_master_2.SP_FOREIGN_ADDR_ALL()
        class_xml.DT_MASTER.DT24.TableName = "SP_FOREIGN_ADDR_ALL"

        Dim lcnno As String = ""
        Try
            'lcnno_raw = dao_lcn.fields.LCNNO_DISPLAY
            'If lcnno_raw <> "" Then
            lcnno = dao_lcn.fields.lcntpcd & " " & CInt(Right(dao_lcn.fields.lcnno, 5)) & "/25" & Left(dao_lcn.fields.lcnno, 2)
            'End If
        Catch ex As Exception

        End Try
        class_xml.SHOW_LCNNO = lcnno


        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd
        class_xml = cls_regis.gen_xml()

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, Year, TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, Year, TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        Return filename
    End Function

    Private Function BindData_PDF_DR(ByVal _IDA As Integer, ByVal CITIZEN_ID As String, ByVal _ProcessID As String, ByVal STATUS_ID As Integer) As String
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim lcnsid As String = ""
        Dim regis_ida As Integer = 0
        Dim lcntpcd As String = ""
        Dim rcvno As String = ""
        Dim lcnno As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim thadrgnm As String = ""
        Dim engdrgnm As String = ""
        Dim appdate As Date
        Dim expdate As Date
        'Dim STATUS_ID As Integer = 0
        Dim dsgcd As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim TR_ID As Integer
        Dim class_xml As New CLASS_DR
        If STATUS_ID = "8" Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)
            lcnsid = dao.fields.lcnsid
            Dim dao2 As New DAO_DRUG.ClsDBdrrqt
            Try
                TR_ID = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Try
                dsgcd = dao.fields.dsgcd

            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try
            Try
                dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
                regis_ida = dao.fields.FK_IDA
            Catch ex As Exception

            End Try
            Try
                pvncd = dao.fields.pvncd
            Catch ex As Exception
                pvncd = ""
            End Try
            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Try
                rgttpcd = dao.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                rcvno = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                lcnno = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                pvnabbr = dao.fields.pvnabbr
            Catch ex As Exception

            End Try
            Try
                thadrgnm = dao.fields.thadrgnm
            Catch ex As Exception

            End Try
            Try
                engdrgnm = dao.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
            Catch ex As Exception

            End Try
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)
            Try
                TR_ID = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try
            Try
                dsgcd = dao.fields.dsgcd

            Catch ex As Exception

            End Try
            lcnsid = dao.fields.lcnsid
            regis_ida = dao.fields.FK_IDA
            Try
                pvncd = dao.fields.pvncd
            Catch ex As Exception
                pvncd = ""
            End Try
            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Try
                rgttpcd = dao.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                rcvno = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                lcnno = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                pvnabbr = dao.fields.pvnabbr
            Catch ex As Exception

            End Try
            Try
                thadrgnm = dao.fields.thadrgnm
            Catch ex As Exception

            End Try
            Try
                engdrgnm = dao.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try
                class_xml.drrqts = dao.fields
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
            Catch ex As Exception

            End Try
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try
        End If


        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(regis_ida)
        Catch ex As Exception

        End Try
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(FK_LCN_IDA)
            lcntpcd = dao_lcn.fields.lcntpcd
        Catch ex As Exception

        End Try

        Dim cls As New CLASS_GEN_XML.DR(CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        Try
            class_xml.DRUG_STRENGTH = DRUG_STRENGTH
        Catch ex As Exception

        End Try
        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_dos.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)
            class_xml.DRRGT_COLORs = dao_color.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try


        Try
            rcvno_auto = rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try

        Try
            If STATUS_ID = 8 Then
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                    dao4.GetDataby_IDA(_IDA)
                    'If dao4.fields.USE_PVNABBR2 IsNot Nothing Then
                    '    'If dao4.fields.USE_PVNABBR2 = "1" Then
                    '    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    'End If
                    'Else
                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                End If
            Else
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                    dao4.GetDataby_IDA(_IDA)
                    'If dao4.fields.USE_PVNABBR2 IsNot Nothing Then
                    '    'If dao4.fields.USE_PVNABBR2 = "1" Then
                    '    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    'End If
                    'Else
                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
        Dim aa As String = ""
        Dim aa2 As String = ""
        If STATUS_ID = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try

            Try
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
                daodrgtype2.GetDataby_drgtpcd(dao_rq.fields.rgtdrgtpcd)

                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            Dim dao3 As New DAO_DRUG.ClsDBdrrqt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype2.GetDataby_drgtpcd(dao3.fields.rgtdrgtpcd)
            Try
                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If
        Try

            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
                'pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        Try

            If Len(rcvno_auto) > 0 Then
                If aa2 = "(NG)" Then
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
                Else
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
                End If
            End If
        Catch ex As Exception

        End Try
        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            'drug_name = drug_name_th

            'drug_name = drug_name_th & " / " & drug_name_eng
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If
        If IsNothing(appdate) = False Then
            ''Dim appdate As Date
            If Date.TryParse(appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If
        If IsNothing(expdate) = False Then
            Dim expdate2 As Date
            If Date.TryParse(expdate, expdate2) = True Then
                class_xml.EXPDAY = expdate.Day
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXP_YEAR = con_year(expdate.Year)

                If class_xml.EXP_YEAR = 544 Then
                    class_xml.EXPDAY = ""
                    class_xml.EXPMONTH = ""
                    class_xml.EXP_YEAR = ""
                End If


            End If
        End If
        'Try
        '    If Len(rgtno_auto) > 0 Then
        '        rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try


        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try
        If STATUS_ID = 8 Then
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRGT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        Else
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRQT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        End If
        Dim DRUG_PROPERTIES_AND_DETAIL As String = ""

        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2
        'drrgts
        'Try
        '    Dim dao_dos As New DAO_DRUG.TB_drdosage
        '    dao_dos.GetDataby_cd(dsgcd)
        '    class_xml.Dossage_form = dao_dos.fields.engdsgnm
        'Catch ex As Exception

        'End Try




        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        Try
            If STATUS_ID = "8" Then
                Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, lcnsid) 'ข้อมูลบริษัท
            Else
                Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, lcnsid) 'ข้อมูลบริษัท
            End If
        Catch ex As Exception

        End Try


        'class_xml.DT_SHOW.DT3 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน

        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ



        'class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        'class_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
        'class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
        'class_xml.DT_SHOW.DT15.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_2NO"
        'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
        'class_xml.DT_SHOW.DT16.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_3NO"
        'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 4)
        'class_xml.DT_SHOW.DT17.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_4NO"


        If STATUS_ID <> 8 Then
            Dim dao_det_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FKIDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try
            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRQT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                PACK_SIZE = dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try

            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try
            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRQT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
            class_xml.DT_SHOW.DT20 = bao_show.SP_DRRQT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRQT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


            'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_DATA(_IDA)

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"


            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"

            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        Else
            Dim dao_det_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FK_IDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try
            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                PACK_SIZE = dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try
            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try
            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
            class_xml.DT_SHOW.DT20 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


            'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_DATA(_IDA)

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"



            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        End If

        Dim statusId As Integer = STATUS_ID
        Dim lcntype As String = "" 'dao.fields.lcntpcd
        'Try
        '    Dim rcvdate As Date = dao.fields.rcvdate
        '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
        '    class_xml.drrgts = dao.fields



        'Catch ex As Exception

        'End Try
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_ProcessID)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try

        p_dr = class_xml

        Dim p_dr2 As New CLASS_DR
        p_dr2 = p_dr
        ' p_dr2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dr2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_dr2)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_ProcessID, statusId, 0, 0)
        '------------------------(E)------------------------
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try
            If STATUS_ID = "8" Then
                Dim dao As New DAO_DRUG.ClsDBdrrgt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                E_VALUE = dao_drgtpcd.fields.engdrgtpnm
            Else
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                E_VALUE = dao_drgtpcd.fields.engdrgtpnm
            End If
        Catch ex As Exception

        End Try
        Dim NAME_TEMPLATE As String = ""
        If E_VALUE <> "(E)" Then
            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            If STATUS_ID = "8" Or STATUS_ID = "14" Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                End If
            Else

            End If
        Else
            If STATUS_ID = "8" Or STATUS_ID = "14" Then
                NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"

            Else
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If
        End If
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(TR_ID)
        Dim Year As String = dao_up.fields.YEAR.ToString()
        'Dim TR_ID As String = dao_up.fields.ID.ToString()

        '-----------------------------------------------------
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, Year, TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, Year, TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        Return filename
    End Function

    <WebMethod()>
    Public Function INSERT_EXTENDTIME(ByVal LCN_IDA As Integer, ByVal Process_ID As String, ByVal CITIZEN_ID As String, ByVal gpp As String, ByVal tel As String, ByVal _staff As String) As String
        Dim Result As String = ""
        Try
            Dim chk As Boolean = True
            Dim dao_edit As New DAO_DRUG.TB_LCN_EXTEND_LITE
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            Dim dao_process As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_process.GetDataby_Process_ID(Process_ID)
            Dim cyear As Integer '= 2563
            cyear = CInt(Year(Date.Now)) + 1
            If cyear < 2500 Then
                cyear += 543
            End If
            'dao_edit.GetDataby_FK_IDA(LCN_IDA)
            'dao_dal.GetDataby_IDA(LCN_IDA)
            If dao_edit.fields.FK_IDA = dao_dal.fields.IDA And dao_edit.fields.extend_year = cyear And dao_edit.fields.STATUS_ID <> 7 And dao_edit.fields.STATUS_ID <> 5 And dao_edit.fields.PROCESS_ID <> "100747" And dao_edit.fields.PROCESS_ID <> "100745" Then
                'Dim a As String = Replace("555555555", "o", "i")
            Else

                Dim TR_ID As String = ""
                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.CITIZEN_ID = CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = dao_dal.fields.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection(Process_ID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION

                Dim PDF_TRADER As String
                Dim XML_TRADER As String

                'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
                'dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
                'If dao_edit.fields.STATUS_ID = 5 Then
                '    PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                '    PDF_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & "-1" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, _TR_ID)
                '    PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                '    XML_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & "-1" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, _TR_ID)
                'Else


                '    PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                '    PDF_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, _TR_ID)
                '    PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                '    XML_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, _TR_ID)
                'End If
                'FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"

                'convert_PDF_To_XML(PDF_TRADER, XML_TRADER)

                Dim check As Boolean = True
                ' Try
                'If chk = True Then
                If dao_edit.fields.STATUS_ID = 5 Then
                    dao_edit.fields.STATUS_ID = 6
                    dao_edit.update()
                Else
                    insrt_extend_to_database(TR_ID, LCN_IDA, Process_ID, CITIZEN_ID, gpp:=gpp, tel:=tel)
                End If
                'If check = True Then
                '    SET_ATTACH(_TR_ID, _ProcessID, con_year(Date.Now.Year))
                '    If dao_edit.fields.STATUS_ID = 6 Then
                '        AddLogStatusEtracking(6, 0, _CLS.CITIZEN_ID, "อัพโหลดเอกสารต่ออายุ(แก้ไข) " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao_edit.fields.FK_IDA, dao_edit.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
                '    Else
                '        AddLogStatusEtracking(0, 0, _CLS.CITIZEN_ID, "อัพโหลดเอกสารต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, 0, 0, 0, HttpContext.Current.Request.Url.AbsoluteUri)
                '    End If
                '    alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + _TR_ID)
                'Else
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เกิดข้อผิดพลาดกรุณาตรวจสอบข้อมูลในไฟล์');", True)
                'End If

            End If
        Catch ex As Exception
            'Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
        Return Result
    End Function

    Private Sub insrt_extend_to_database(ByVal TR_ID As String, ByVal _lcn_ida As Integer, ByVal Process_id As String, ByVal CITIZEN_ID As String, Optional gpp As String = "", Optional tel As String = "", Optional _staff As String = "")
        Dim check As Boolean = True
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        Dim dao_address As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_address.GetDataby_IDA(dao_lcn.fields.FK_IDA)

        Dim dao_lcnre As New DAO_DRUG.TB_LCN_EXTEND_LITE
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao_t As New DAO_DRUG.TB_MAS_LCN_EXTEND_TYPE
        Try
            If dao_lcn.fields.lcntpcd = "ผยส" Then
                dao_lcn.fields.lcntpcd = "12"
            ElseIf dao_lcn.fields.lcntpcd = "จยส" Then
                dao_lcn.fields.lcntpcd = "13"
            ElseIf dao_lcn.fields.lcntpcd = "นยส" Then
                dao_lcn.fields.lcntpcd = "14"
            ElseIf dao_lcn.fields.lcntpcd = "สยส" Then
                dao_lcn.fields.lcntpcd = "15"
            ElseIf dao_lcn.fields.lcntpcd = "ผจ" Then
                dao_lcn.fields.lcntpcd = "02"
            ElseIf dao_lcn.fields.lcntpcd = "ขจ" Then
                dao_lcn.fields.lcntpcd = "03"
            ElseIf dao_lcn.fields.lcntpcd = "ขนจ" Then
                dao_lcn.fields.lcntpcd = "04"
            ElseIf dao_lcn.fields.lcntpcd = "นจ" Then
                dao_lcn.fields.lcntpcd = "05"
            ElseIf dao_lcn.fields.lcntpcd = "สวจ" Then
                dao_lcn.fields.lcntpcd = "06"
            End If
        Catch ex As Exception

        End Try

        If dao_lcn.fields.lcntpcd = "02" Then
            'If p2.CHK_TYPE = "3" Then
            'dao_lcn.fields.lcntpcd = "ผวจ3"
            dao_lcn.fields.lcntpcd = "ผจ"
            'Else
            '    dao_lcn.fields.lcntpcd = "ผวจ4"
            'End If
        End If
        If dao_lcn.fields.lcntpcd = "03" Then
            'If p2.CHK_TYPE = "3" Then
            'dao_lcn.fields.lcntpcd = "ขวจ3"
            dao_lcn.fields.lcntpcd = "ขจ"
            'Else
            '    dao_lcn.fields.lcntpcd = "ขวจ4"
            'End If
        End If
        If dao_lcn.fields.lcntpcd = "04" Then
            'If p2.CHK_TYPE = "3" Then
            dao_lcn.fields.lcntpcd = "ขนจ"
            'dao_lcn.fields.lcntpcd = "ขตวจ3"
            'Else
            '    dao_lcn.fields.lcntpcd = "ขตวจ4"
            'End If
        End If

        dao_t.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)
        dt = bao.SP_GET_ADDR(_lcn_ida)
        dao_lcnre.fields.lcnno = dao_lcn.fields.lcnno
        dao_lcnre.fields.CITIZEN_AUTHORIZE = dao_lcn.fields.CITIZEN_ID_AUTHORIZE
        dao_lcnre.fields.lcnsid = dao_lcn.fields.lcnsid
        'dao_lcnre.fields.thanm = dao_address.fields.thanameplace
        Try
            dao_lcnre.fields.thanm_address = dt(0)("thanm_addr")
        Catch ex As Exception

        End Try
        Dim newyear As Integer = 0
        Dim year_present As Integer = 0
        Dim montn_present As Integer = 0
        year_present = Year(Date.Now)
        montn_present = Month(Date.Now)
        If montn_present = 1 Then
            newyear = year_present
        Else
            newyear = year_present + 1
        End If
        dao_lcnre.fields.extend_year = newyear
        dao_lcnre.fields.lcnno_display_full = dao_lcn.fields.pvnabbr & " " & dao_lcn.fields.lcntpcd + " " + (Int(Right(dao_lcn.fields.lcnno, 5)).ToString + "/25" + Left(dao_lcn.fields.lcnno, 2))
        dao_lcnre.fields.lcnno_pvnabbr = (Int(Right(dao_lcn.fields.lcnno, 5)).ToString + "/25" + Left(dao_lcn.fields.lcnno, 2))
        dao_lcnre.fields.PROCESS_ID = Process_id
        dao_lcnre.fields.PAY_L44_STAMP = dao_t.fields.pay_amount44
        dao_lcnre.fields.PAY_STAMP = dao_t.fields.pay_amount
        dao_lcnre.fields.SALE_MEDICIAN1 = _staff
        Try
            dao_lcnre.fields.licen = dt(0)("licen")
        Catch ex As Exception
        End Try

        Try
            dao_lcnre.fields.licen_address = dt(0)("licen_addr")
        Catch ex As Exception
        End Try

        dao_lcnre.fields.licen_time = dao_lcn.fields.opentime
        Try
            dao_lcnre.fields.grannm_lo = dt(0)("grannm_lo")
        Catch ex As Exception
        End Try
        Try
            dao_lcnre.fields.grannm_address = dt(0)("grannm_addr")
        Catch ex As Exception
        End Try

        dao_lcnre.fields.thaamphrnm = dao_address.fields.thaamphrnm
        dao_lcnre.fields.thachngwtnm = dao_address.fields.thachngwtnm
        dao_lcnre.fields.typee = dao_lcn.fields.lcntpcd
        Try
            dao_lcnre.fields.GROUPNAME = dt(0)("GROUPNAME")
        Catch ex As Exception
        End Try
        Try
            dao_lcnre.fields.cncnm = dt(0)("cncnm")
        Catch ex As Exception

        End Try
        Try
            dao_lcnre.fields.thanm = dt(0)("thanm")
        Catch ex As Exception

        End Try
        dao_lcnre.fields.process_l44 = dao_t.fields.process_l44


        dao_lcnre.fields.pvncd = dao_lcn.fields.pvncd

        dao_lcnre.fields.lcntpcd = dao_lcn.fields.lcntpcd

        'dao_lcnre.fields.thanm_address = dt(0)("thanm_address")

        'dao_lcnre.fields.grannm_lo = dt(0)("grannm_lo")
        'dao_lcnre.fields.grannm_address = dt(0)("grannm_address") 'dao2.fields.grannm_address


        Try
            dao_lcnre.fields.CITIZEN_ID = CITIZEN_ID
        Catch ex As Exception

        End Try
        Dim chw As String = ""
        Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
        Try
            dao_cpn.GetData_by_chngwtcd(dao_lcn.fields.pvncd)
            chw = dao_cpn.fields.thachngwtnm
        Catch ex As Exception

        End Try
        Try
            dao_lcnre.fields.MOBILE = tel
        Catch ex As Exception

        End Try
        'If dao_lcn.fields.chngwtcd <> 10 Then
        Try
            dao_lcnre.fields.WRITE_AT = dao_address.fields.thanameplace '"สสจ. " & chw 'p2.dalcns.WRITE_AT
        Catch ex As Exception

        End Try

        dao_lcnre.fields.WRITE_DATE = Date.Now
        'End If

        'Try
        '    Dim newDate As DateTime = p2.dalcns.WRITE_DATE
        '    newDate = newDate.AddYears(543)
        '    dao_lcnre.fields.WRITE_DATE = newDate
        'Catch ex As Exception

        'End Try
        dao_lcnre.fields.FK_IDA = _lcn_ida

        dao_lcnre.fields.TR_ID = TR_ID
        'dao_lcnre.fields.Medic_4bsnname = Medic_4bsnname.Text
        'dao_lcnre.fields.Medic_4bsnlastname = Medic_4bsnlastname.Text
        'dao_lcnre.fields.Medic_4bsmnumber = Medic_4bsnnumber.Text
        'dao_lcnre.fields.Medic_4exname = Medic_4exname.Text
        'dao_lcnre.fields.Medic_4exlastname = Medic_4exlastname.Text
        'dao_lcnre.fields.Medic_4exnumber = Medic_4exnumber.Text
        dao_lcnre.fields.MAP_X = 0 'map_x.Text
        dao_lcnre.fields.MAP_Y = 0 'map_y.Text
        dao_lcnre.fields.STATUS_ID = 1
        dao_lcnre.fields.staff = CITIZEN_ID '_staff
        Try
            dao_lcnre.fields.U1_CODE = dt(0)("U1_CODE")
        Catch ex As Exception

        End Try

        dao_lcnre.insert()

        AddLogStatus(1, Process_id, CITIZEN_ID, dao_lcnre.fields.IDA)

        If gpp <> "" Then
            Dim i As Integer = 0
            Dim dao_gpp As New DAO_DRUG.TB_LCN_EXTEND_LITE_GPP
            i = dao_gpp.Countdata_by_FK_IDA_year(_lcn_ida, newyear)

            If i = 0 Then
                If dao_lcn.fields.lcntpcd = "ขย1" Then
                    dao_gpp = New DAO_DRUG.TB_LCN_EXTEND_LITE_GPP
                    dao_gpp.fields.FK_IDA = _lcn_ida
                    dao_gpp.fields.YEARS = newyear
                    dao_gpp.insert()
                End If

            End If

        End If
    End Sub

    Private Sub StremeFile(ByVal Str64 As String, ByVal Filename As String, ByVal serverpath As String)
        Dim basic As String = Str64
        Dim image As Byte() = Convert.FromBase64String(basic)
        Dim oFileStrem As System.IO.FileStream
        oFileStrem = New System.IO.FileStream(Filename, System.IO.FileMode.Create)
        oFileStrem.Write(image, 0, image.Length)
        oFileStrem.Close()
        oFileStrem.Dispose()
    End Sub
    Private Function insrt_to_database_LCN(ByVal FileName As String, ByVal TR_ID As String, ByVal _ProcessID As String, ByVal CITIZEN_ID_AUTHORIZE As String, ByVal CITIZEN_ID_UPLOAD As String, ByVal _fk_ida_locaion As Integer, ByVal pvncd As Integer) As Boolean
        Dim check As Boolean = True

        ' Try
        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()


        Dim cernumber As String = ""

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.fields = p2.dalcns

        dao.fields.IMAGE_BSN = p2.dalcns.IMAGE_BSN
        dao.fields.lcnsid = dao.fields.lcnsid
        dao.fields.PROCESS_ID = _ProcessID
        dao.fields.IDENTIFY = CITIZEN_ID_AUTHORIZE
        dao.fields.CITIZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE
        dao.fields.rcvdate = Date.Now
        dao.fields.lmdfdate = Date.Now
        dao.fields.STATUS_ID = 1
        dao.fields.TR_ID = TR_ID
        dao.fields.FK_IDA = _fk_ida_locaion
        dao.fields.CTZNO = CITIZEN_ID_UPLOAD
        dao.fields.lcntpcd = set_lcntpcd(_ProcessID)
        dao.fields.CITIZEN_ID_UPLOAD = CITIZEN_ID_UPLOAD
        Try
            dao.fields.pvncd = pvncd
        Catch ex As Exception

        End Try
        Try
            dao.fields.chngwtcd = pvncd
        Catch ex As Exception

        End Try
        Dim chw As String = ""
        Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
        Try
            dao_cpn.GetData_by_chngwtcd(pvncd)
            chw = dao_cpn.fields.thacwabbr
        Catch ex As Exception

        End Try
        dao.fields.pvnabbr = chw

        'If Request.QueryString("staff") <> "" Then
        '    dao.fields.OTHER = "1"
        'End If
        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
        dao_syslcnsnm.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
        dao.fields.thanm = dao_syslcnsnm.fields.thanm
        dao.fields.syslcnsnm_ID = dao_syslcnsnm.fields.ID
        dao.fields.syslcnsnm_identify = dao_syslcnsnm.fields.identify
        dao.fields.syslcnsnm_lcnsid = dao_syslcnsnm.fields.lcnsid
        dao.fields.syslcnsnm_lcnscd = dao_syslcnsnm.fields.lcnscd
        dao.fields.syslcnsnm_prefixcd = dao_syslcnsnm.fields.prefixcd
        dao.fields.syslcnsnm_prefixnm = dao_syslcnsnm.fields.prefixnm
        dao.fields.syslcnsnm_thanm = dao_syslcnsnm.fields.thanm
        dao.fields.syslcnsnm_engnm = dao_syslcnsnm.fields.engnm
        dao.fields.syslcnsnm_lctcd = dao_syslcnsnm.fields.lctcd
        dao.fields.syslcnsnm_thalnm = dao_syslcnsnm.fields.thalnm
        dao.fields.syslcnsnm_englnm = dao_syslcnsnm.fields.englnm
        dao.fields.syslcnsnm_suffixcd = dao_syslcnsnm.fields.suffixcd
        dao.fields.syslcnsnm_lcnsst = dao_syslcnsnm.fields.lcnsst
        dao.fields.syslcnsnm_grplcnscd = dao_syslcnsnm.fields.grplcnscd
        dao.fields.syslcnsnm_bsncd = dao_syslcnsnm.fields.bsncd
        dao.fields.syslcnsnm_lstfcd = dao_syslcnsnm.fields.lstfcd
        dao.fields.syslcnsnm_lmdfdate = dao_syslcnsnm.fields.lmdfdate
        dao.fields.syslcnsnm_lcnsidst = dao_syslcnsnm.fields.lcnsidst
        dao.fields.syslcnsnm_validdate = dao_syslcnsnm.fields.validdate
        dao.fields.syslcnsnm_oldid = dao_syslcnsnm.fields.oldid
        dao.fields.syslcnsnm_type = dao_syslcnsnm.fields.type
        dao.fields.syslcnsnm_update_date = dao_syslcnsnm.fields.update_date
        dao.fields.syslcnsnm_create_date = dao_syslcnsnm.fields.create_date


        Dim dao_location_address As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_location_address.GetDataby_IDA(_fk_ida_locaion)
        dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thanameplace
        dao.fields.LOCATION_ADDRESS_thaaddr = dao_location_address.fields.thaaddr
        dao.fields.LOCATION_ADDRESS_thasoi = dao_location_address.fields.thasoi
        dao.fields.LOCATION_ADDRESS_tharoad = dao_location_address.fields.tharoad
        dao.fields.LOCATION_ADDRESS_thamu = dao_location_address.fields.thamu
        dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thathmblnm
        dao.fields.LOCATION_ADDRESS_thaamphrnm = dao_location_address.fields.thaamphrnm
        dao.fields.LOCATION_ADDRESS_thachngwtnm = dao_location_address.fields.thachngwtnm
        dao.fields.LOCATION_ADDRESS_tel = dao_location_address.fields.tel
        dao.fields.LOCATION_ADDRESS_fax = dao_location_address.fields.fax
        dao.fields.LOCATION_ADDRESS_thanameplace = dao_location_address.fields.thanameplace
        dao.fields.LOCATION_ADDRESS_thaaddr = dao_location_address.fields.thaaddr
        dao.fields.LOCATION_ADDRESS_thasoi = dao_location_address.fields.thasoi
        dao.fields.LOCATION_ADDRESS_tharoad = dao_location_address.fields.tharoad
        dao.fields.LOCATION_ADDRESS_thamu = dao_location_address.fields.thamu
        dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thathmblnm
        dao.fields.LOCATION_ADDRESS_thaamphrnm = dao_location_address.fields.thaamphrnm
        dao.fields.LOCATION_ADDRESS_thachngwtnm = dao_location_address.fields.thachngwtnm
        dao.fields.LOCATION_ADDRESS_tel = dao_location_address.fields.tel
        dao.fields.LOCATION_ADDRESS_fax = dao_location_address.fields.fax
        dao.fields.LOCATION_ADDRESS_lcnsid = dao_location_address.fields.lcnsid
        dao.fields.LOCATION_ADDRESS_engaddr = dao_location_address.fields.engaddr
        dao.fields.LOCATION_ADDRESS_tharoom = dao_location_address.fields.tharoom
        dao.fields.LOCATION_ADDRESS_thabuilding = dao_location_address.fields.thabuilding
        dao.fields.LOCATION_ADDRESS_engsoi = dao_location_address.fields.engsoi
        dao.fields.LOCATION_ADDRESS_engroad = dao_location_address.fields.engroad
        dao.fields.LOCATION_ADDRESS_zipcode = dao_location_address.fields.zipcode
        dao.fields.LOCATION_ADDRESS_lstfcd = dao_location_address.fields.lstfcd
        dao.fields.LOCATION_ADDRESS_lmdfdate = dao_location_address.fields.lmdfdate
        dao.fields.LOCATION_ADDRESS_IDA = dao_location_address.fields.IDA
        dao.fields.LOCATION_ADDRESS_FK_IDA = dao_location_address.fields.FK_IDA
        dao.fields.LOCATION_ADDRESS_TR_ID = dao_location_address.fields.TR_ID
        dao.fields.LOCATION_ADDRESS_DOWN_ID = dao_location_address.fields.DOWN_ID
        dao.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_location_address.fields.CITIZEN_ID
        dao.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_location_address.fields.CITIZEN_ID_UPLOAD
        dao.fields.LOCATION_ADDRESS_XMLNAME = dao_location_address.fields.XMLNAME
        dao.fields.LOCATION_ADDRESS_engmu = dao_location_address.fields.engmu
        dao.fields.LOCATION_ADDRESS_engfloor = dao_location_address.fields.engfloor
        dao.fields.LOCATION_ADDRESS_engbuilding = dao_location_address.fields.engbuilding
        dao.fields.LOCATION_ADDRESS_rcvno = dao_location_address.fields.rcvno
        dao.fields.LOCATION_ADDRESS_rcvdate = dao_location_address.fields.rcvdate
        dao.fields.LOCATION_ADDRESS_lctcd = dao_location_address.fields.lctcd
        dao.fields.LOCATION_ADDRESS_engnameplace = dao_location_address.fields.engnameplace
        dao.fields.LOCATION_ADDRESS_STATUS_ID = dao_location_address.fields.STATUS_ID
        dao.fields.LOCATION_ADDRESS_HOUSENO = dao_location_address.fields.HOUSENO
        dao.fields.LOCATION_ADDRESS_Branch = dao_location_address.fields.Branch
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_location_address.fields.LOCATION_TYPE_NORMAL
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_location_address.fields.LOCATION_TYPE_OTHER
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_location_address.fields.LOCATION_TYPE_ID
        dao.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_location_address.fields.SYSTEM_NAME
        dao.fields.LOCATION_ADDRESS_thmblcd = dao_location_address.fields.thmblcd
        dao.fields.LOCATION_ADDRESS_chngwtcd = dao_location_address.fields.chngwtcd
        dao.fields.LOCATION_ADDRESS_engthmblnm = dao_location_address.fields.engthmblnm
        dao.fields.LOCATION_ADDRESS_engamphrnm = dao_location_address.fields.engamphrnm
        dao.fields.LOCATION_ADDRESS_engchngwtnm = dao_location_address.fields.engchngwtnm
        dao.fields.LOCATION_ADDRESS_IDENTIFY = dao_location_address.fields.IDENTIFY
        dao.fields.LOCATION_ADDRESS_REMARK = dao_location_address.fields.REMARK


        Dim bsn_den As String = ""
        Try
            bsn_den = Trim(p2.BSN_IDENTIFY)
        Catch ex As Exception

        End Try

        Dim dao_syslcnsnm2 As New DAO_CPN.clsDBsyslcnsnm
        dao_syslcnsnm2.GetDataby_identify(bsn_den)
        Try
            dao.fields.bsncd = dao_syslcnsnm2.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim bao_show11 As New BAO_SHOW
        Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(bsn_den)
        For Each dr As DataRow In dt_bsn.Rows
            Try
                dao.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ADDR = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_SOI = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ROAD = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_MOO = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_FAX = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THAINAME = dr("BSN_THAINAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.AMPHR_ID = dr("AMPHR_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.TUMBON_ID = dr("TUMBON_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_FLOOR = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_BUILDING = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CREATE_DATE = dr("CREATE_DATE")
            Catch ex As Exception

            End Try
            Try
                dao.fields.DOWN_ID = dr("DOWN_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CITIZEN_ID = dr("CITIZEN_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.XMLNAME = dr("XMLNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.NATIONALITY = dr("NATIONALITY")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGMU = dr("BSN_ENGMU")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.AGE = dr("AGE")
            Catch ex As Exception

            End Try
        Next
        dao.insert()

        Dim opentime As String = ""
        Dim dao_cn As New DAO_DRUG.ClsDBdalcn
        Try
            opentime = p2.dalcns.opentime
        Catch ex As Exception

        End Try
        For Each dr As DataRow In dt_bsn.Rows
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                dao_bsn.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ADDR = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_SOI = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ROAD = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_MOO = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FAX = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAINAME = dr("BSN_THAINAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AMPHR_ID = dr("AMPHR_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.TUMBON_ID = dr("TUMBON_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FLOOR = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_BUILDING = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CREATE_DATE = dr("CREATE_DATE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.DOWN_ID = dr("DOWN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CITIZEN_ID = dr("CITIZEN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.XMLNAME = dr("XMLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.NATIONALITY = dr("NATIONALITY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGMU = dr("BSN_ENGMU")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AGE = dr("AGE")
            Catch ex As Exception

            End Try
            dao_bsn.fields.LCN_IDA = dao.fields.IDA
            dao_bsn.fields.FK_IDA = dao.fields.FK_IDA
            dao_bsn.insert()
        Next

        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In p2.DALCN_DETAIL_LOCATION_KEEPs
            Dim LOCATION_IDA As Integer
            If Integer.TryParse(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_IDA, LOCATION_IDA) = True Then
                Dim dao_LOCATION_ADDRESS_2 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                dao_LOCATION_ADDRESS_2.GetDataby_IDA(LOCATION_IDA)
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = CITIZEN_ID_UPLOAD

                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.TR_ID = TR_ID
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.FK_IDA = dao.fields.IDA
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LCN_IDA = dao.fields.IDA
                Catch ex As Exception

                End Try

                dao_DALCN_DETAIL_LOCATION_KEEP.fields.IDENTIFY = CITIZEN_ID_AUTHORIZE
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thanameplace
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = dao_LOCATION_ADDRESS_2.fields.thanameplace
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lcnsid = dao_LOCATION_ADDRESS_2.fields.lcnsid
                Catch ex As Exception

                End Try

                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engaddr = dao_LOCATION_ADDRESS_2.fields.engaddr
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = dao_LOCATION_ADDRESS_2.fields.tharoom
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = dao_LOCATION_ADDRESS_2.fields.thabuilding
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engsoi = dao_LOCATION_ADDRESS_2.fields.engsoi
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engroad = dao_LOCATION_ADDRESS_2.fields.engroad
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = dao_LOCATION_ADDRESS_2.fields.zipcode
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lstfcd = dao_LOCATION_ADDRESS_2.fields.lstfcd
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lmdfdate = dao_LOCATION_ADDRESS_2.fields.lmdfdate
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDA = dao_LOCATION_ADDRESS_2.fields.IDA
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_FK_IDA = dao_LOCATION_ADDRESS_2.fields.FK_IDA
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_TR_ID = dao_LOCATION_ADDRESS_2.fields.TR_ID
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_DOWN_ID = dao_LOCATION_ADDRESS_2.fields.DOWN_ID
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID_UPLOAD
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_XMLNAME = dao_LOCATION_ADDRESS_2.fields.XMLNAME
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engmu = dao_LOCATION_ADDRESS_2.fields.engmu
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engfloor = dao_LOCATION_ADDRESS_2.fields.engfloor
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engbuilding = dao_LOCATION_ADDRESS_2.fields.engbuilding
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvno = dao_LOCATION_ADDRESS_2.fields.rcvno
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvdate = dao_LOCATION_ADDRESS_2.fields.rcvdate
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lctcd = dao_LOCATION_ADDRESS_2.fields.lctcd
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_STATUS_ID = dao_LOCATION_ADDRESS_2.fields.STATUS_ID
                Catch ex As Exception

                End Try


                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engnameplace = dao_LOCATION_ADDRESS_2.fields.engnameplace

                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_HOUSENO = dao_LOCATION_ADDRESS_2.fields.HOUSENO
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_NORMAL
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_OTHER
                Catch ex As Exception

                End Try

                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_ID
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thmblcd = dao_LOCATION_ADDRESS_2.fields.thmblcd

                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                Catch ex As Exception

                End Try
                Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_amphrcd = dao_LOCATION_ADDRESS_2.fields.amphrcd
                Catch ex As Exception

                End Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_LOCATION_ADDRESS_2.fields.SYSTEM_NAME
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engthmblnm = dao_LOCATION_ADDRESS_2.fields.engthmblnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engamphrnm = dao_LOCATION_ADDRESS_2.fields.engamphrnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engchngwtnm = dao_LOCATION_ADDRESS_2.fields.engchngwtnm
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDENTIFY = dao_LOCATION_ADDRESS_2.fields.IDENTIFY
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_REMARK = dao_LOCATION_ADDRESS_2.fields.REMARK
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = dao_LOCATION_ADDRESS_2.fields.Mobile
                dao_DALCN_DETAIL_LOCATION_KEEP.insert()
                dao_DALCN_DETAIL_LOCATION_KEEP = New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            End If
        Next


        'เภสัชกร
        Dim dao_DALCN_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        For Each dao_DALCN_PHR.fields In p2.DALCN_PHRs
            If (dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE = "1") Or (String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE) = True) Then
                'Dim PHR_NAME As String = ""
                'Try
                '    PHR_NAME = dao_DALCN_PHR.fields.PHR_NAME
                'Catch ex As Exception

                'End Try

                If String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_NAME) = False Then
                    Dim dao_prefix As New DAO_CPN.TB_sysprefix
                    Dim PHR_PREFIX_ID As String = ""
                    Try
                        PHR_PREFIX_ID = Trim(dao_DALCN_PHR.fields.PHR_PREFIX_ID)
                    Catch ex As Exception

                    End Try
                    If PHR_PREFIX_ID <> "" Then
                        dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                        dao_DALCN_PHR.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                        dao_DALCN_PHR.fields.PHR_PREFIX_ID = PHR_PREFIX_ID
                    Else
                        dao_DALCN_PHR.fields.PHR_PREFIX_NAME = "นาย"
                        dao_DALCN_PHR.fields.PHR_PREFIX_ID = "0"
                    End If
                    Try
                        'dao_DALCN_PHR.fields.PHR_NAME = p2.DALCN_PHRs.phr
                    Catch ex As Exception

                    End Try
                    dao_DALCN_PHR.fields.PHR_TEXT_WORK_TIME = opentime
                    dao_DALCN_PHR.fields.TR_ID = TR_ID
                    dao_DALCN_PHR.fields.FK_IDA = dao.fields.IDA
                    dao_DALCN_PHR.fields.PHR_STATUS_UPLOAD = 1
                    dao_DALCN_PHR.insert()
                    dao_DALCN_PHR = New DAO_DRUG.ClsDBDALCN_PHR


                End If
            End If
        Next

        Dim dao_DALCN_PHR_2 As New DAO_DRUG.ClsDBDALCN_PHR
        For Each dao_DALCN_PHR_2.fields In p2.DALCN_PHR_2s
            If dao_DALCN_PHR_2.fields.PHR_MEDICAL_TYPE = "2" Then
                If String.IsNullOrWhiteSpace(dao_DALCN_PHR_2.fields.PHR_NAME) = False Then
                    Dim dao_prefix As New DAO_CPN.TB_sysprefix
                    Dim PHR_PREFIX_ID As String = ""
                    Try
                        PHR_PREFIX_ID = Trim(dao_DALCN_PHR_2.fields.PHR_PREFIX_ID)
                    Catch ex As Exception

                    End Try
                    If PHR_PREFIX_ID <> "" Then
                        dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                        dao_DALCN_PHR_2.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                        dao_DALCN_PHR_2.fields.PHR_PREFIX_ID = PHR_PREFIX_ID
                    Else
                        dao_DALCN_PHR_2.fields.PHR_PREFIX_NAME = "นาย"
                        dao_DALCN_PHR_2.fields.PHR_PREFIX_ID = "0"
                    End If
                    dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME = opentime
                    dao_DALCN_PHR_2.fields.TR_ID = TR_ID
                    dao_DALCN_PHR_2.fields.FK_IDA = dao.fields.IDA
                    dao_DALCN_PHR_2.fields.PHR_STATUS_UPLOAD = 1
                    'dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME =
                    dao_DALCN_PHR_2.insert()
                    dao_DALCN_PHR_2 = New DAO_DRUG.ClsDBDALCN_PHR
                End If
            End If
        Next

        Dim dao_DALCN_PHR_3 As New DAO_DRUG.ClsDBDALCN_PHR
        For Each dao_DALCN_PHR_3.fields In p2.DALCN_PHR_3s
            If dao_DALCN_PHR_3.fields.PHR_MEDICAL_TYPE = "2" Then
                If String.IsNullOrWhiteSpace(dao_DALCN_PHR_3.fields.PHR_NAME) = False Then
                    Dim dao_prefix As New DAO_CPN.TB_sysprefix
                    Dim PHR_PREFIX_ID As String = ""
                    Try
                        PHR_PREFIX_ID = Trim(dao_DALCN_PHR_3.fields.PHR_PREFIX_ID)
                    Catch ex As Exception

                    End Try
                    If PHR_PREFIX_ID <> "" Then
                        dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_ID = PHR_PREFIX_ID
                    Else
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_NAME = "นาย"
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_ID = "0"
                    End If
                    dao_DALCN_PHR_3.fields.PHR_TEXT_WORK_TIME = opentime
                    dao_DALCN_PHR_3.fields.TR_ID = TR_ID
                    dao_DALCN_PHR_3.fields.FK_IDA = dao.fields.IDA
                    dao_DALCN_PHR_3.fields.PHR_STATUS_UPLOAD = 1
                    dao_DALCN_PHR_3.fields.PHR_MEDICAL_TYPE = 3
                    'dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME =
                    dao_DALCN_PHR_3.insert()
                    dao_DALCN_PHR_3 = New DAO_DRUG.ClsDBDALCN_PHR
                End If
            End If
        Next

        Return check
    End Function
    Private Function set_lcntpcd(ByVal _processid As String) As String
        Dim dao As New DAO_DRUG.ClsDBPROCESS_NAME
        dao.GetDataby_Process_ID(_ProcessID)
        Return dao.fields.PROCESS_NAME
    End Function

    Private Sub ATTACH(ByVal B64_Str As String, ByVal NAME_REAL As String, ByVal transection As String, ByVal PROCESS_ID As String, ByVal years As String, ByVal type As String) 'ปรับ เพิ่มtype

        Dim bao As New BAO.AppSettings
        Dim NAME_FAKE As String
        Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
        Dim Last_Length As Integer = Array_NAME_REAL.Length - 1
        NAME_FAKE = "DA-" & PROCESS_ID & "-" & years & "-" & transection & "-" & type & ".pdf" 'System.IO.Path.GetExtension(FileUpload1.FileName)
        Dim FILE_PATH As String = ""
        FILE_PATH = bao._PATH_DEFAULT & "upload\" & NAME_FAKE
        'FileUpload1.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE)
        StremeFile(B64_Str, NAME_FAKE, FILE_PATH)

        Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
        dao.fields.NAME_FAKE = NAME_FAKE
        dao.fields.NAME_REAL = NAME_REAL
        dao.fields.TYPE = type
        dao.fields.TRANSACTION_ID = transection
        dao.fields.PROCESS_ID = PROCESS_ID
        dao.insert()

    End Sub
End Class