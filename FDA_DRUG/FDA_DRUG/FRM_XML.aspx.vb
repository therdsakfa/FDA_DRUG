Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class FRM_XML
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
    End Sub

    Protected Sub btn_dalcn_Click(sender As Object, e As EventArgs) Handles btn_dalcn.Click
        Dim filename As String = "DA_LCN.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN(cityzen_id, lcnsid, lcnno, "1", "10")
        Dim cls_xml As New CLASS_DALCN

        cls_xml = cls.gen_xml()

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(33) 'ข้อมูลสถานที่จำลอง
        'cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, 333) 'ข้อมูลที่ตั้งหลัก
        'cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("123131232412", 333) 'ข้อมูลบริษัท
        'cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 333) 'ที่เก็บ
        'cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(33) 'ผู้ดำเนิน




        Dim bao_master As New BAO_MASTER
        'cls_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(11)
        'cls_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(32)
        'cls_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(11)
        'cls_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(11, 1)
        'cls_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(11, 2)
        'cls_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        'cls_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(11, 1)
        'cls_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(11, 2)
        'cls_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"
        '' cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(100000)
        'cls_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(9999999)

        Dim url2 As String = "https://medicina.fda.moph.go.th/FDA_DRUG"
        Dim Cls_qr As New QR_CODE.GEN_QR_CODE
        Dim img_byte As String = Cls_qr.QR_CODE_IMG(url2) ' ws_qrs.QR_CODE_B64(url2) '


        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        Dim a As String = ""


        'Dim info() As System.Reflection.PropertyInfo = cls_xml.GetType().GetProperties()


        'For Each p As System.Reflection.PropertyInfo In cls_xml.GetType().GetProperties()

        'Next
        For Each p As System.Reflection.PropertyInfo In cls_xml.GetType().GetProperties()
            If p.CanRead Then
                Console.WriteLine("{0}: {1}", p.Name, p.GetValue(cls_xml, Nothing))

            End If
        Next
        cls_xml.QR_CODE = img_byte
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(path) '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim xx As New XmlSerializer(p2.GetType)
        p2 = xx.Deserialize(objStreamReader)
        
        For Each p As System.Reflection.PropertyInfo In p2.GetType().GetProperties()
            'p.GetValue(p2, Nothing)
            Try
                p.SetValue(p.GetType.Name, NumEng2Thai(p.GetValue(p2, Nothing)))
            Catch ex As Exception

            End Try

        Next


        objStreamReader.Close()


    End Sub

    Function NumEng2Thai(strEng As String) As String
        Dim strThai As String = ""
        Dim strTemp As Byte
        Dim i As Byte
        'strEng = "258963147"
        For i = 1 To Len(strEng)
            strTemp = Asc(Mid$(strEng, i, 1)) + 192
            strThai = strThai & Chr(strTemp)
        Next
        NumEng2Thai = strThai
    End Function
    Protected Sub btn_lcn_Click(sender As Object, e As EventArgs) Handles btn_lcn.Click
        Dim filename As String = "da_lcn"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 10484
        Dim lcnno As String = ""
        Dim lcntpcd As String = "11"
        Dim pvncd As String = "10"

        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN(cityzen_id, lcnsid, "1", pvncd)

        Dim cls_xml As New XML_CENTER.CLASS_DALCN
        cls_xml = cls.gen_xml()

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(33) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, 333) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("123131232412", 333) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 333) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(33) 'ผู้ดำเนิน

        Dim bao_master As New BAO_MASTER
        cls_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(11)
        cls_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(11)
        cls_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(11, 1)
        cls_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(11, 2)
        cls_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub

    Protected Sub btn_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_UPLOAD.Click
        '   Dim path As String = Server.MapPath("XML") & "\da_lcn.xml"
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim filename As String = "da_lcn"
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New XML_CENTER.CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        'Dim un As New Cls_untility.CLS_MAIN_PDF
        'un.PATH_PDF_TEMPLATE = bao._PATH_PDF_TEMPLATE
        'un.PATH_PDF_XML_CLASS = bao._PATH_PDF_XML_CLASS
        'un.path_XML = bao._PATH_XML_CLASS
        'un.PDF_CENTER("", "")
        'MsgBox("สำเร็จ")
    End Sub

    Protected Sub btn_UPLOAD0_Click(sender As Object, e As EventArgs) Handles btn_UPLOAD0.Click
        '   Dim path As String = Server.MapPath("XML") & "\da_lcn.xml"
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim filename As String = "da_lcn"
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New XML_CENTER.CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()


        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()


        'Dim un As New Cls_untility.CLS_MAIN_PDF
        'un.PATH_PDF_TEMPLATE = bao._PATH_PDF_TEMPLATE
        'un.PATH_PDF_XML_CLASS = bao._PATH_PDF_XML_CLASS
        'un.path_XML = bao._PATH_XML_CLASS
        'un.PDF_CENTER("", "")
    End Sub

    Protected Sub btn_lcn0_Click(sender As Object, e As EventArgs) Handles btn_lcn0.Click
        Dim cls As New CLS_MAIN_XML
        Dim filename As String = ""
        filename = cls.XML_DALCN_NEW(988, 2)
    End Sub



    Protected Sub btn_DS_Click(sender As Object, e As EventArgs) Handles btn_DS.Click
        Dim filename As String = "DA_DS"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 10484
        Dim lcnno As String = "5800001"
        Dim lcntpcd As String = "11"
        Dim pvncd As String = "10"

        Dim cls As New CLASS_GEN_XML.DS(cityzen_id, lcnsid, lcnno, lcntpcd, pvncd)

        Dim cls_xml As New CLASS_DS
        cls_xml = cls.gen_xml(1)

        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(33) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, 333) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("123131232412", 333) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 333) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(33) 'ผู้ดำเนิน

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        '  cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()  'สาร
        cls_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(34908) 'สาร
        cls_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(34908) 'สถานที่ผลิต
        cls_xml.DT_MASTER.DT23 = bao_master.SP_MASTER_DRUG_REGISTRATION_BY_IDA(34908) 'ทะเบียนยา

        cls_xml.SHOW_LCNNO = "1/2555"

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub

    Protected Sub btn_CER_Click(sender As Object, e As EventArgs) Handles btn_CER.Click
        Dim filename As String = "DA_CER"
        Dim cityzen_id As String = "1330400374116"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "2300015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls_CER As New CLASS_GEN_XML.Cer(cityzen_id, lcnsid, lcnno)
        Dim cls_xml As New CLASS_CER

        cls_xml = cls_CER.gen_xml_CER(1)
        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        cls_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(cityzen_id)
        'ชื่อบริษัท
        cls_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(333)

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(33) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, 333) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("123131232412", 333) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 333) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(33) 'ผู้ดำเนิน


        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER

        'ชื่อประเภทยา
        cls_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_dactg()

        'ประเทศ
        cls_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt()


        ' bao_master.SP_MASTER_fafdtype.TableName = "ประกาศใบอนุญาต"
        cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(33)

        'ประเภท Cer
        cls_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_lgt_impcertp()

        'สาร
        cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()

        cls_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(33) 'สาร
        cls_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(33) 'ผู้ผลิต

        cls_xml.URL_CHEMICAL_SEARCH = "http://10.111.28.101/FDA_DRUG/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx"

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\DA_CER.xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_EDIT_Click(sender As Object, e As EventArgs) Handles btn_EDIT.Click
        Dim filename As String = "DA_EDIT_REQUEST.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "2300015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls_CER As New CLASS_GEN_XML.EDIT_REQUEST(cityzen_id, lcnsid, lcnno)
        Dim cls_xml As New CLASS_EDIT_REQUEST

        cls_xml = cls_CER.gen_xml_EDIT_REQUEST(0)


        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_REGIS_Click(sender As Object, e As EventArgs) Handles btn_REGIS.Click
        Dim filename As String = "DA_REGISTRATION.xml"
        Dim cityzen_id As String = "1330400374116"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000001"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New CLASS_GEN_XML.DRUG_REGISTRATION(cityzen_id, lcnsid, lcnno, "1", "10")
        Dim cls_xml As New CLASS_REGISTRATION

        cls_xml = cls.gen_xml(0)


        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(106470) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(0, 252565) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(106470) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(2457) 'ข้อมูลที่ดึงมาจาก Product ID

        'cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(106470) 'ข้อมูลสถานที่จำลอง
        'cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(1, 252565) 'ข้อมูลที่ตั้งหลัก
        'cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", 252565) 'ข้อมูลบริษัท


        ''cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 252565) 'ที่เก็บ
        ''cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        ''cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(106470) 'ผู้ดำเนิน
        ''cls_xml.DT_SHOW.DT15 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(103) 'ข้อมูลที่ดึงมาจาก Product ID


        ''_______________MASTER_________________
        'Dim bao_master As New BAO_MASTER
        'cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(2540) 'CER
        ''  cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()  'สาร

        'Dim bao_master_2 As New BAO.ClsDBSqlcommand
        'cls_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(2540) 'สารจากCER
        ''cls_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(2540) 'สถานที่
        'cls_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        'cls_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        'cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        'cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT(lcnsid) 'สาร
        'cls_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL()

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand

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


        'cls_xml.DT_MASTER.DT24 = bao_master_2.SP_FOREIGN_ADDR_ALL() 'ที่อยู่ตปท.
        'cls_xml.DT_MASTER.DT24.TableName = "SP_FOREIGN_ADDR_ALL"


        cls_xml.DRUG_REGISTRATIONs.LCNNO = "1/2555"
        cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 2
        cls_xml.SHOW_LCNNO = "1/2555"

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub
    Protected Sub btn_REGIS_CONFIRM_Click(sender As Object, e As EventArgs) Handles btn_REGIS_CONFIRM.Click
        Dim filename As String = "DA_REGISTRATION_CONFIRM.xml"
        Dim cityzen_id As String = "1330400374116"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000001"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New CLASS_GEN_XML.DRUG_REGISTRATION(cityzen_id, lcnsid, lcnno, "1", "10")
        Dim cls_xml As New CLASS_REGISTRATION

        cls_xml = cls.gen_xml(0)
        p_REGISTRATION = cls_xml

        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(106470) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(0, 252565) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(106470) 'ผู้ดำเนิน
        'class_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(_product_id) 'ข้อมูลที่ดึงมาจาก Product ID
        cls_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(2046)
        cls_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(2046)
        cls_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        cls_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA(2046)
        cls_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA"
        cls_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(2046)
        cls_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"
        cls_xml.DT_SHOW.DT17 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(2046)
        cls_xml.DT_SHOW.DT17.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA"

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand

        cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(0) 'CER
        cls_xml.DT_MASTER.DT15.TableName = "SP_MASTER_CER_PK_BY_FK_IDA"
        cls_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        cls_xml.DT_MASTER.DT16.TableName = "SP_dactg"
        cls_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        cls_xml.DT_MASTER.DT17.TableName = "SP_drkdofdrg"
        cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        cls_xml.DT_MASTER.DT18.TableName = "SP_CER_FOREIGN_BY_IDA"

        cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI() 'สาร
        cls_xml.DT_MASTER.DT19.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        cls_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL() 'กลุ่มตำรับ
        cls_xml.DT_MASTER.DT20.TableName = "SP_ATC_DRUG_ALL"
        cls_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา
        cls_xml.DT_MASTER.DT21.TableName = "SP_dosage_form"
        cls_xml.DT_MASTER.DT22 = bao_master_2.SP_DRUG_UNIT_PHYSIC() 'หน่วยเล็กสุด
        cls_xml.DT_MASTER.DT22.TableName = "SP_DRUG_UNIT_PHYSIC"
        cls_xml.DT_MASTER.DT23 = bao_master_2.SP_MASTER_drsunit() 'หน่วย
        cls_xml.DT_MASTER.DT23.TableName = "SP_MASTER_drsunit"
        cls_xml.DT_MASTER.DT24 = bao_master_2.SP_FOREIGN_ADDR_ALL() 'ที่อยู่ตปท.
        cls_xml.DT_MASTER.DT24.TableName = "SP_FOREIGN_ADDR_ALL"


        cls_xml.DRUG_REGISTRATIONs.LCNNO = "1/2555"
        cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 2
        cls_xml.SHOW_LCNNO = "1/2555"

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub
    Protected Sub btn_DH_Click(sender As Object, e As EventArgs) Handles btn_DH.Click
        Dim filename As String = "DA_DH.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New CLASS_GEN_XML.DH(cityzen_id, lcnsid, lcnno, "1", "10", 3120)
        Dim cls_xml As New CLASS_DH

        cls_xml = cls.gen_xml(1)

        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(33) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, 333) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("123131232412", 333) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 333) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(33) 'ผู้ดำเนิน


        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER

        ' cls_xml.DT_MASTER.DT16 = bao_master.SP_LGT_IMPCER_by_FK_IDA(34908)



        cls_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt() 'ประเทศ
        cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(2203) 'สารที่เลือกจากCER
        cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(34908) 'CER
        '  cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()  'สาร
        cls_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(34908) 'สารที่เลือกจากDH
        cls_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(34908) 'สถานที่ผลิต

        cls_xml.DT_MASTER.DT32 = bao_master.SP_MASTER_DH15_DETAIL_CER_by_FK_IDA(55) 'cer ที่เลือกไว้
        cls_xml.DT_MASTER.DT33 = bao_master.SP_MASTER_DH15_DETAIL_CASCHEMICAL_by_FK_IDA(111111) 'สารที่เลือกใน ภค
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_DR_Click(sender As Object, e As EventArgs) Handles btn_DR.Click
        Dim filename As String = "DA_DR.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(39899)
        Dim _main_ida As Integer = 86929

        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New CLASS_GEN_XML.DR(cityzen_id, lcnsid, lcnno, "10", LCN_IDA:=39899)
        Dim cls_xml As New CLASS_DR
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try


        cls_xml = cls.gen_xml()
        cls_xml.LCN_TYPE = LCN_TYPE
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT8 = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_main_ida)
        cls_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        cls_xml.DT_SHOW.DT9 = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_main_ida)
        cls_xml.DT_SHOW.DT9.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        cls_xml.DT_SHOW.DT10 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(_main_ida, "A")
        cls_xml.DT_SHOW.DT10.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_A"
        cls_xml.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(_main_ida, "I")
        cls_xml.DT_SHOW.DT11.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_I"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_main_ida)
        cls_xml.DT_SHOW.DT12.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"

        cls_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 2, 2)
        cls_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 3, 2)
        cls_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        cls_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(_main_ida, 4, 2)
        cls_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

        cls_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_MASTER(_main_ida)
        cls_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_MASTER"

        ''_______________SHOW_________________
        'Dim bao_show As New BAO_SHOW
        'cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(33) 'ข้อมูลสถานที่จำลอง
        'cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, 333) 'ข้อมูลที่ตั้งหลัก
        'cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("123131232412", 333) 'ข้อมูลบริษัท
        'cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 333) 'ที่เก็บ
        'cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(33) 'ผู้ดำเนิน

        ''_______________MASTER_________________
        'Dim bao_master As New BAO_MASTER
        ''  cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()  'สาร
        'cls_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(34908) 'สารจากCER
        'cls_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(34908) 'สถานที่ผลิต
        'cls_xml.DT_MASTER.DT23 = bao_master.SP_MASTER_DRUG_REGISTRATION_BY_IDA(34908) 'ทะเบียนยา
        cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", "252565") 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT18 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL(_main_ida)
        cls_xml.DT_SHOW.DT18.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL"
        cls_xml.SHOW_LCNNO = LCNNO_FORMAT

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_DI_Click(sender As Object, e As EventArgs) Handles btn_DI.Click
        Dim filename As String = "DA_DI.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New CLASS_GEN_XML.DI(cityzen_id, lcnsid, lcnno, "1", "10")
        Dim cls_xml As New CLASS_DI

        cls_xml = cls.gen_xml(3)

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_DRUG_PROJECT_Click(sender As Object, e As EventArgs) Handles btn_DRUG_PROJECT.Click
        Dim filename As String = "DA_PROJECT.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New CLASS_GEN_XML.DRUG_PROJECT(cityzen_id, lcnsid, lcnno, "1", "10")
        Dim cls_xml As New CLASS_DRUG_PROJECT

        cls_xml = cls.gen_xml(3)

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_PHARMACIST_Click(sender As Object, e As EventArgs) Handles btn_PHARMACIST.Click

        Dim filename As String = "DA_PHARMACIST.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New CLASS_GEN_XML.PHARMACIST(cityzen_id, lcnsid, "909")
        Dim cls_xml As New CLASS_PHARMACIST

        cls_xml = cls.gen_xml(1)

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_DP_Click(sender As Object, e As EventArgs) Handles btn_DP.Click
        Dim filename As String = "DA_DP.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"

        Dim cls As New CLASS_GEN_XML.DP(cityzen_id, lcnsid, lcnno, "1", "10")
        Dim cls_xml As New CLASS_DP

        cls_xml = cls.gen_xml(2)

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_CHEMICAL_Click(sender As Object, e As EventArgs) Handles btn_CHEMICAL.Click
        Dim filename As String = "DA_CHEMICAL_REQUEST.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"

        Dim cls As New CLASS_GEN_XML.CHEMICAL_REQUEST()
        Dim cls_xml As New CLASS_CHEMICAL_REQUEST

        cls_xml = cls.gen_xml(1)

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_dalcn_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_dalcn_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_LCN.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New XML_CENTER.CLASS_DALCN 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_DS_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_DS_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_DS.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()
       


        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_DS 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_DR_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_DR_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_DR_READ.xml" 'เปลี่ยนชื่อไฟล์
        'Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()
        Dim _IDA As Integer = 82592
        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""

        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_re.GetDataby_FK_IDA(dao.fields.FK_IDA)
        'Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        'dao_lcn.GetDataby_IDA(dao_re.fields.FK_IDA)

        Dim cls_regis As New CLASS_GEN_XML.DR("1710500118665", 252565, "6100001", 10, 39902)
        '"1710500118665", dao.fields.lcnsid, "5700003", dao.fields.pvncd, 1

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
            class_xml.drrqts = dao.fields
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


        Dim bao_show As New BAO_SHOW
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(1) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0105540058096", 3350) 'ข้อมูลบริษัท
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(1) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT1 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(87469) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT2 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", "252565") 'ข้อมูลบริษัท

        class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        class_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
        class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(86790)
        class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_2NO"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_3NO"
        class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 4)
        class_xml.DT_SHOW.DT17.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_4NO"

        'Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd

        Dim path As String = bao_app._PATH_XML_CLASS & "\" & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(class_xml.GetType)
        x.Serialize(objStreamWriter, class_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_CER_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_CER_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_CER.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_CER 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_EDIT_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_EDIT_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_EDIT_REQUEST.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_EDIT_REQUEST 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_REGIS_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_REGIS_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_REGISTRATION_Confirm.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_REGISTRATION 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_DH_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_DH_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_DH.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_DH 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_DI_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_DI_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_DI.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_DI 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_DP_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_DP_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_DP.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_DP 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_DRUG_PROJECT_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_DRUG_PROJECT_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_PROJECT.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_DRUG_PROJECT 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_PHARMACIST_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_PHARMACIST_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_PHARMACIST.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_PHARMACIST 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_CHEMICAL_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_CHEMICAL_UPLOAD.Click
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "DA_CHEMICAL_REQUEST.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = bao_app._PATH_XML_CLASS & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New CLASS_CHEMICAL_REQUEST 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Protected Sub btn_TRANFER_LOCATION_Click(sender As Object, e As EventArgs) Handles btn_TRANFER_LOCATION.Click
        Dim filename As String = "DA_TRANFER_LOCATION.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 985
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        'filename = txt_cer_file.Text
        'cityzen_id = txt_cer_citizen.Text
        'lcnsid = txt_cer_lcnsid.Text

        Dim cls As New Gen_XML.GEN_XML_TRANFER_LOCATION()
        Dim cls_xml As New XML_TRANFER_LOCATION

        cls_xml = cls.GEN_XML_TRANFER_LOCATION()

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_show As New BAO_SHOW

        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(5783) 'ผู้ดำเนินกิจการ
        cls_xml.DT_SHOW.DT10 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, 5783) 'ข้อมูลที่ตั้งหลัก

        cls_xml.DT_MASTER.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(5783) 'สถานที่

        cls_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_dalcn_by_LCNSID(32670) 'ใบอนุญาต
        cls_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_drrgt_by_LCNSID(3335) 'ยา
        'cls_xml.DT_MASTER.DT16 = bao_master.SP_LGT_IMPCER_by_FK_IDA(34908)
        'cls_xml.DT_MASTER.DT17 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(2203)

        cls_xml.SHOW_LCNNO = "1/55"



        Dim path As String = _PATH_DEFALUT & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_TRANFER_LOCATION_UPLOAD_Click(sender As Object, e As EventArgs) Handles btn_TRANFER_LOCATION_UPLOAD.Click

        Dim filename As String = "DA_TRANFER_LOCATION.xml" 'เปลี่ยนชื่อไฟล์
        Dim path As String = _PATH_DEFALUT & filename.ToString()

        Dim objStreamReader As New StreamReader(path)
        Dim p2 As New XML_TRANFER_LOCATION 'เปลี่ยนclass
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()


    End Sub

    Protected Sub btn_flabel_Click(sender As Object, e As EventArgs) Handles btn_flabel.Click

    End Sub

    Protected Sub btn_location_Click(sender As Object, e As EventArgs) Handles btn_location.Click
        Dim filename As String = "DA_LOCATION.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 111111111
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        Dim Cls_NCT_LCT As New Gen_XML.GEN_XML_NCT_LCT_ADDR

        Dim cls_xml As New CLS_LOCATION
        cls_xml = Cls_NCT_LCT.gen_xml_nct_lctaddr()


        '_______________SHOW___________________

        Dim bao_show As New BAO_SHOW
        Try

            cls_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(cityzen_id) 'ชื่อผู้ ทำ PDF
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT5 = bao_show.SP_SP_SYSTHMBL() 'ตำบล ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT6 = bao_show.SP_SP_SYSAMPHR() 'อำเภอ ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT7 = bao_show.SP_SP_SYSCHNGWT() 'จังหวัด ไว้ใส่ ดรอปดาว

        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX() 'คำนำหน้า ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(lcnsid) 'bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, LCNSID) 'สถานที่หลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(cityzen_id, lcnsid) 'ชื่อและข้อมูลผู้ประกอบการ
        cls_xml.SHOW_THAI_birthdate = " "



        Dim path As String = _PATH_DEFALUT & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_DRUG_CONSIDER_REQUESTS_Click(sender As Object, e As EventArgs) Handles btn_DRUG_CONSIDER_REQUESTS.Click
        Dim filename As String = "DA_CONSIDER_REQUESTS.xml"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 111111111
        Dim lcnno As String = "5700015"
        Dim fdtypecd As String = "26"
        Dim fdtypenm As String = "นมโค"


        Dim cls As New CLASS_GEN_XML.DRUG_CONSIDER_REQUEST()

        Dim class_xml As New XML_CONSIDER_REQUESTS
        class_xml = cls.gen_xml()


        '_______________SHOW___________________

        Dim bao_show As New BAO_SHOW
        Try


        Catch ex As Exception

        End Try

     



        Dim path As String = _PATH_DEFALUT & filename
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(class_xml.GetType)
        x.Serialize(objStreamWriter, class_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_UPLOAD1_Click(sender As Object, e As EventArgs) Handles btn_UPLOAD1.Click
        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim date_result As Date
        ws.GETDATE_WORKING(Date.Now, True, 10, True, date_result, True)
        Label1.Text = date_result
    End Sub

    Protected Sub btn_ds_new_Click(sender As Object, e As EventArgs) Handles btn_ds_new.Click
        Dim filename As String = "DA_DS_NEW"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000001"
        Dim lcntpcd As String = "ผย1"
        Dim pvncd As String = "10"

        Dim dao_pro As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao_pro.GetDataby_IDA(19)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao_pro.fields.LCN_IDA)

        Try
            lcnno = dao_lcn.fields.lcnno
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DS_NEW(citizen_id:=cityzen_id, lcnsid:=lcnsid, lcnno:=lcnno, lcntpcd:=lcntpcd, pvncd:=pvncd, LCN_IDA:=dao_pro.fields.LCN_IDA, PRODUCT_ID:=dao_pro.fields.IDA)
        ' cityzen_id, lcnsid, lcnno, lcntpcd, pvncd, PRODUCT_ID:=9
        Dim cls_xml As New CLASS_DS
        cls_xml = cls.gen_xml(0)


        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        Dim bao_show2 As New BAO.ClsDBSqlcommand
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(1, 252565) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", 252565) 'ข้อมูลบริษัท ผู้รับอนุญาต
        'cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, 333) 'ที่เก็บ
        'cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT15 = bao_show2.SP_DRUG_PRODUCT_ID(19)
        cls_xml.DT_SHOW.DT15.TableName = "SP_DRUG_PRODUCT_ID"

        cls_xml.DT_SHOW.DT16 = bao_show2.SP_PRODUCT_ID_CHEMICAL_FK_IDA(18)
        cls_xml.DT_SHOW.DT16.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
        '



        '
        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master2 As New BAO.ClsDBSqlcommand

        ''  cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()  'สาร
        cls_xml.DT_MASTER.DT21 = bao_master2.SP_MASTER_drsunit()
        cls_xml.DT_MASTER.DT21.TableName = "SP_MASTER_drsunit"
        'cls_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(34908) 'สถานที่ผลิต
        'cls_xml.DT_MASTER.DT23 = bao_master.SP_MASTER_DRUG_REGISTRATION_BY_IDA(34908) 'ทะเบียนยา
        Dim show_lcn As String = ""
        Try
            show_lcn = CStr(CInt(Right(lcnno, 5))) & "/25" & Left(lcnno, 2)
        Catch ex As Exception

        End Try
        cls_xml.SHOW_LCNNO = show_lcn

        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        'dt = bao.SP_DRUG_UNIT_PHYSIC()

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Private Sub btn_cer_for_Click(sender As Object, e As EventArgs) Handles btn_cer_for.Click
        Dim filename As String = "CER_FOREIGN"
        Dim cityzen_id As String = "1729900157224"
        Dim lcnsid As Integer = 252565

        Dim cls_CER As New CLASS_GEN_XML.Cer_foreign("1710500118665", "252565", 1, 111111)
        Dim cls_xml As New CLASS_CER_FOREIGN
        cls_xml = cls_CER.gen_xml_CER_FOR()
        cls_xml.CER_FOREIGNs.CER_TYPE = "111000002"

        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        ''ชื่อผู้ใช้ระบบ
        'cls_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
        ''ชื่อบริษัท
        'cls_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID_CUSTOMER)

        'cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_lct_ida) 'ข้อมูลสถานที่จำลอง
        'cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _CLS.LCNSID_CUSTOMER) 'ข้อมูลที่ตั้งหลัก
        'cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        'cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _CLS.LCNSID_CUSTOMER) 'ที่เก็บ
        'cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(_lct_ida) 'ผู้ดำเนิน
        '_______________MASTER_________________

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_LCN_DRUG_Click(sender As Object, e As EventArgs) Handles btn_LCN_DRUG.Click

        Dim filename As String = "LCN_DRUG"
        Dim cityzen_id As String = "0000000000000"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000240"
        Dim lcntpcd As String = "ขย1"
        Dim pvncd As String = "10"

        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN(cityzen_id, lcnsid, "1", pvncd) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN                                                                        ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 106675

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, lcnsid) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(cityzen_id, lcnsid) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, lcnsid) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(lct_ida) 'ผู้ดำเนิน
        Dim bao_master As New BAO_MASTER

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_lcn_ida)
        ' End If

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(Path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    
    Protected Sub btn_edit_lcn_Click(sender As Object, e As EventArgs) Handles btn_edit_lcn.Click
        Dim filename As String = "EDIT_LCN"
        Dim cityzen_id As String = "0000000000000"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000240"
        Dim lcntpcd As String = "ขย1"
        Dim pvncd As String = "10"

        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.EDIT_LCN(cityzen_id, lcnsid, "1", pvncd) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_EDIT_LCN                                                                       ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 106675

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_unit_Click(sender As Object, e As EventArgs) Handles btn_unit.Click
        Dim filename As String = "DRUG_UNIT"
        Dim cityzen_id As String = "0000000000000"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000240"
        Dim lcntpcd As String = "ขย1"
        Dim pvncd As String = "10"

        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.OTHER_XML(cityzen_id, lcnsid, "1", pvncd) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_OTHER_XML                                                                    ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 106675

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_phr_cancel_Click(sender As Object, e As EventArgs) Handles btn_phr_cancel.Click
        Dim filename As String = "PHR_CANCEL"
        Dim cityzen_id As String = "0000000000000"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000240"
        Dim lcntpcd As String = "ขย1"
        Dim pvncd As String = "10"


        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.PHR_CANCEL(cityzen_id, lcnsid, "1", pvncd, _PHR_CTZNO:="4463216562337") 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_PHARMACIST_CANCEL                                                                    ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        cls_xml.DT_SHOW.DT1 = bao_show.SP_DALCN_PHR_by_PHR_CTZNO_TOP_ONE("4463216562337") 'ข้อมูลของเภสัช
        cls_xml.DT_SHOW.DT2 = bao_show.SP_GET_PHR_LOCATION_BY_PHR_CTZNO("4463216562337") 'ใบอนุญาตและที่ตั้งที่เภสัชสังกัดอยู่
        Dim lct_ida As Integer = 106675

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_drrgt_req_Click(sender As Object, e As EventArgs) Handles btn_drrgt_req.Click
        Dim filename As String = "EDIT_DRRGT"
        Dim cityzen_id As String = "0000000000000"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000240"
        Dim lcntpcd As String = "ขย1"
        Dim pvncd As String = "10"
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.EDIT_DRRGT(cityzen_id, lcnsid, "1", pvncd) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_EDIT_DRRGT                                                                 ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(1)

        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        dao_drrgt.GetDataby_IDA(1)

        Dim rcvno_format As String = ""
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim TABEAN_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim rcvno As String = ""
        Dim rcvno_auto As String = ""
        Try
            rcvno_auto = dao_drrgt.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_drrgt.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao_drrgt.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_drrgt.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_drrgt.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_drrgt.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_drrgt.fields.thadrgnm & " / " & dao_drrgt.fields.engdrgnm
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
        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        cls_xml.LCN_TYPE = LCN_TYPE
        cls_xml.LCNTPCD_GROUP = LCNTPCD_GROUP
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.RCVNO_FORMAT = "เลขรับ"
        cls_xml.RGTNO_FORMAT = rgtno_format

        cls_xml.APP_TYPE1 = ""
        cls_xml.APP_TYPE2 = ""
        cls_xml.APP_TYPE2_PURPOSE = ""
        cls_xml.APP_TYPE3 = ""
        cls_xml.APP_TYPE3_PURPOSE = ""
        cls_xml.DRUG_NAME = drug_name
        cls_xml.OLD_NAME_TH = dao_drrgt.fields.thadrgnm
        cls_xml.OLD_NAME_EN = dao_drrgt.fields.engdrgnm
        Try
            cls_xml.PHR_IDENTIFY = ""
            cls_xml.PHR_NAME = "เภสัช"
        Catch ex As Exception

        End Try
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim UNIT_NAME As String = ""
        Dim dao_package As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
        dao_package.GetDataby_FKIDA(dao_drrgt.fields.IDA)
        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
        Try
            dao_unit.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
            UNIT_NAME = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
        Catch ex As Exception
        End Try
        cls_xml.UNIT_NAME = UNIT_NAME
        Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
        dao_color.GetDataby_FK_IDA(dao.fields.FK_IDA)
        'cls_xml.DRRGT_COLORs = dao_color.fields
        Dim bao_mas As New BAO_MASTER

        '------------------SHOW
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        cls_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("", lcnsid) 'ข้อมูลบริษัท

        '-----------------------------MASTER
        'cls_xml.DT_MASTER.DT1 = bao_mas.SP_MASTER_driowa() 'สาร
        'cls_xml.DT_MASTER.DT2 = bao_mas.SP_MASTER_drsunit() 'หน่วย
        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_drrgt.fields.FK_LCN_IDA) 'ผู้ดำเนิน
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try
        Try
            If Request.QueryString("identify") <> "" Then
                cls_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(Request.QueryString("identify"), lcnsid) 'ข้อมูลบริษัท
            Else
                cls_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", lcnsid) 'ข้อมูลบริษัท
            End If
        Catch ex As Exception

        End Try
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_drrgt.fields.FK_LCN_IDA) 'ผู้ดำเนิน

            cls_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception
            cls_xml.BSN_THAIFULLNAME = ""
        End Try
        Dim lct_ida As Integer = 106675

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_drrgt_sub_Click(sender As Object, e As EventArgs) Handles btn_drrgt_sub.Click
        Dim filename As String = "DRRGT_SUB"
        Dim cityzen_id As String = "0000000000000"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000240"
        Dim lcntpcd As String = "ขย1"
        Dim pvncd As String = "10"
        Dim bao_show As New BAO_SHOW
        Dim bao_mas As New BAO_MASTER
        Dim cls As New CLASS_GEN_XML.DRRGT_SUB(cityzen_id, lcnsid, "1", pvncd) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRGT_SUB                                                                 ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(49409)

        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        dao_drrgt.GetDataby_IDA(1)

        Dim rcvno_format As String = ""
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim TABEAN_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim rcvno As String = ""
        Dim rcvno_auto As String = ""
        Try
            rcvno_auto = dao_drrgt.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_drrgt.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao_drrgt.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_drrgt.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_drrgt.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_drrgt.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_drrgt.fields.thadrgnm & " / " & dao_drrgt.fields.engdrgnm
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
        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                cls_xml.TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                cls_xml.TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_dg As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
            dao_dg.GetDataby_rgttpcd(dao_drrgt.fields.rgttpcd)
            cls_xml.CHK_LCN_SUBTYPE = dao_dg.fields.subtpcd
        Catch ex As Exception

        End Try
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.RCVNO_FORMAT = "" 'rcvno_format
        cls_xml.RGTNO_FORMAT = rgtno_format



        cls_xml.DRUG_NAME = drug_name        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml

        '------------------SHOW
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", lcnsid) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(49409) 'ผู้ดำเนิน
        '-----------------------------MASTER
        'cls_xml.DT_MASTER.DT1 = bao_mas.SP_MASTER_driowa() 'สาร
        'cls_xml.DT_MASTER.DT2 = bao_mas.SP_MASTER_drsunit() 'หน่วย

        Dim lct_ida As Integer = 106675

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_spc_Click(sender As Object, e As EventArgs) Handles btn_spc.Click
        Dim filename As String = "DRRGT_SPC"
        Dim cls As New CLASS_GEN_XML.DRRGT_SPC_GEN() 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRGT_SPC                                                               ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim rgtno_auto As String = ""
        Dim rgtno_format As String = ""
        Dim rgttpcd As String = ""
        Dim STATUS_ID As String = "8"
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(1)
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(1)
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        End If

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If


        Dim lcnno_auto As String = ""
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Dim lcnno_format As String = ""
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
            End If
        Catch ex As Exception

        End Try

        Dim aa As String = ""
        If STATUS_ID = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(1)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            Dim dao3 As New DAO_DRUG.ClsDBdrrqt
            dao3.GetDataby_IDA(1)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        cls_xml = cls.gen_xml()

        cls_xml.DRUG_NAME = drug_name
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RGTNO_FORMAT = rgtno_format

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_pi_Click(sender As Object, e As EventArgs) Handles btn_pi.Click
        Dim filename As String = "DRRGT_PI"
        Dim cls As New CLASS_GEN_XML.DRRGT_PI_GEN() 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRGT_PI                                                               ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_pil_Click(sender As Object, e As EventArgs) Handles btn_pil.Click
        Dim filename As String = "DRRGT_PIL"
        Dim cls As New CLASS_GEN_XML.DRRGT_PIL_GEN() 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRGT_PIL                                                              ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filename As String = "DRRGT_ORI"
        Dim cityzen_id As String = "0000000000000"
        Dim lcnsid As Integer = 252565
        Dim lcnno As String = "6000240"
        Dim lcntpcd As String = "ขย1"
        Dim pvncd As String = "10"
        Dim bao_show As New BAO_SHOW
        Dim bao_mas As New BAO_MASTER
        Dim cls As New CLASS_GEN_XML.DR_ORI(cityzen_id, lcnsid, "1", pvncd) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRTG_ORIGINAL
        cls._IDA = 86076  ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml_ori()

        Dim bao_app As New BAO.AppSettings

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bao_s As New BAO_SHOW
        Dim dt As DataTable = bao_s.SP_GET_ALL_DRRGT_EDIT_REQUEST_dt()
        Dim filename As String = "DRRGT_EDIT_REQUEST"

        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim ds As New DataSet
        ds.Tables.Add(dt)

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(ds.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, ds)
        objStreamWriter.Close()
    End Sub

    Public Function WS_GET_ALL_DRRGT_EDIT_REQUEST() As String
        Dim aa As String = ""
        Dim bao As New BAO_SHOW
        Try
            aa = bao.SP_GET_ALL_DRRGT_EDIT_REQUEST()
        Catch ex As Exception

        End Try

        Return aa
    End Function

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim aa As String = ""
        Dim bao As New BAO_SHOW
        'SP_GET_DRRQT_ALL_ACCEPT_dt
        Dim dt As DataTable = bao.SP_GET_DRRQT_ALL_ACCEPT_dt()
        Dim filename As String = "DRRQT_ALL_ACCEPT"

        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim ds As New DataSet
        ds.Tables.Add(dt)

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(ds.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, ds)
        objStreamWriter.Close()
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim filename As String = "VORJOR"
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN("0000000000000", 252565, "1", "10") 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN                                                                        ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 0

        Try
            lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, "0000000000000") 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", 252565) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, "0000000000000") 'ที่เก็บ
        If cls_xml.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        'If txt_bsn.Text <> "" Then
        '    ws2.insert_taxno(txt_bsn.Text)
        'End If



        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY("1710500118665") 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        Dim lcnno_auto As String = ""
        Dim lcnno_format As String
        Dim MAIN_LCN_IDA As Integer = 47250
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        If MAIN_LCN_IDA <> 0 Then
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(MAIN_LCN_IDA)

            Try
                'lcnno_format = 
                cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
            Catch ex As Exception

            End Try

        End If


        Dim bao_cpn As New BAO.ClsDBSqlcommand

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        cls_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2("0000000000000")
        cls_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"

        cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2("1710500118665")
        cls_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"

        Dim bao_master As New BAO_MASTER

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_lcn_ida)
        ' End If
        cls_xml.BSN_IDENTIFY = "1710500118665"


        'Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        'dao.Getdata_by_fk_id2(_lct_ida)

        Try
            'If dao.fields.BSN_NATIONALITY_CD = 1 Then
            cls_xml.dalcns.NATION = "ไทย"
            'End If
        Catch ex As Exception

        End Try

        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim filename As String = "TEMP_VORJOR"
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.T_NCT_DALCN_TEMP("0000000000000", 252565, "1", "10") 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_TEMP_NCT_DALCN
        Dim dao_t As New DAO_DRUG.TB_TEMP_NCT_DALCN
        dao_t.Getdata_by_ID(1)
        ' ประกาศตัวแปรจาก CLASS_DALCN 

        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        ' cls_xml.TEMP_NCT_DALCNs = dao_t.fields
        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim filename As String = "VORJOR_EDIT"
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN_EDIT_REQUEST("0000000000000", 252565, "1", "10") 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN_EDIT_REQUEST                                                                        ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 101680

        'Try
        '    lct_ida = Request.QueryString("lct_ida")
        'Catch ex As Exception

        'End Try

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง

        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, "0000000000000") 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_5"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", 252565) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, "0000000000000") 'ที่เก็บ
        If cls_xml.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        'If txt_bsn.Text <> "" Then
        '    ws2.insert_taxno(txt_bsn.Text)
        'End If



        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY("1710500118665") 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim MAIN_LCN_IDA As Integer = 61332
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(61332)
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        If MAIN_LCN_IDA <> 0 Then
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(61332)

            Try
                'lcnno_format = 
                cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
            Catch ex As Exception

            End Try

        End If


        Dim bao_cpn As New BAO.ClsDBSqlcommand

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        cls_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2("0000000000000")
        cls_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"

        cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2("1710500118665")
        cls_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"

        Dim bao_master As New BAO_MASTER
        cls_xml.DT_SHOW.DT10 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(2427)

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(61332)
        ' End If
        cls_xml.BSN_IDENTIFY = "1710500118665"
        cls_xml.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RCVNO_FORMAT = "1/2563"
        Try
            'If dao.fields.BSN_NATIONALITY_CD = 1 Then
            'cls_xml.dalcns.NATION = "ไทย"
            'End If
        Catch ex As Exception

        End Try

        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim filename As String = "VORJOR_SUB"
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN_NCT_SUB("0000000000000", 252565, "1", "10") 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN_NCT_SUBSTITUTE                                                                       ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 101680

        'Try
        '    lct_ida = Request.QueryString("lct_ida")
        'Catch ex As Exception

        'End Try

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง

        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, "0000000000000") 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_5"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY("0000000000000", 252565) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, "0000000000000") 'ที่เก็บ
        If cls_xml.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        'If txt_bsn.Text <> "" Then
        '    ws2.insert_taxno(txt_bsn.Text)
        'End If



        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY("1710500118665") 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim MAIN_LCN_IDA As Integer = 61332
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(61332)
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        If MAIN_LCN_IDA <> 0 Then
            Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
            dao_main2.GetDataby_IDA(61332)

            Try
                'lcnno_format = 
                cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
            Catch ex As Exception

            End Try

        End If


        Dim bao_cpn As New BAO.ClsDBSqlcommand

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        cls_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2("0000000000000")
        cls_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"

        cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2("1710500118665")
        cls_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"

        Dim bao_master As New BAO_MASTER
        cls_xml.DT_SHOW.DT10 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(2427)

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(61332)
        ' End If
        cls_xml.BSN_IDENTIFY = "1710500118665"
        cls_xml.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RCVNO_FORMAT = "1/2563"
        Try
            'If dao.fields.BSN_NATIONALITY_CD = 1 Then
            'cls_xml.dalcns.NATION = "ไทย"
            'End If
        Catch ex As Exception

        End Try

        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub

    Protected Sub NYM3_Click(sender As Object, e As EventArgs) Handles NYM3.Click     '''' เอาข้อมูลมาโชวววววววนะ โดยการ get ออกมา 
        Dim filename As String = "NORYORMOR3"
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.NYM3_IMPORT_SUB() 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_NYM_3_SM                                                                     ' ประกาศตัวแปรจาก CLASS_DALCN 
        Dim dao_nym3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        dao_nym3.getdata_ida(47)
        cls_xml.NYM_3s = dao_nym3.fields
        ' cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 101680
        Try
            'If dao.fields.BSN_NATIONALITY_CD = 1 Then
            'cls_xml.dalcns.NATION = "ไทย"
            'End If
        Catch ex As Exception

        End Try

        Dim bao_app As New BAO.AppSettings
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub
End Class