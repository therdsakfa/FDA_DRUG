Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI

Public Class UC_DS_DOWNLOAD_PDF
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _lcn_ida As String
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _lcn_ida = Request("lcn_ida").ToString()
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            set_label()
        End If
    End Sub
    Private Sub xml()
        Dim get_session As CLS_SESSION = Session("product_id")
        Dim cls_xml As New CLASS_DRSAMP
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_master As New BAO_MASTER

        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_IDA(get_session.IDA)
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao.fields.IDA)
        Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
        dao_dalcn.GetDataby_IDA(dao.fields.LCN_IDA)
        Dim dao_drsamp_pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_drsamp_pack.GetDataby_IDA(dao.fields.IDA)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao.fields.IDA)

        cls_xml = GEN_XML()
        cls_xml.drsamp = dao_drsamp.fields  'ใบ
        cls_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(dao.fields.IDA) 'บัญชีรายการยา
        cls_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(dao.fields.LCN_IDA) 'เลขที่ใบอนุญาต
        cls_xml.DT_SHOW.DT3 = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(dao.fields.IDA) 'ตัวยาสำคัญ
        cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(dao.fields.IDA) 'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.FK_IDA) 'ขนาดบรรจุ
        Try
            cls_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_RCV(dao_drsamp.fields.IDA) 'เลขที่รับ
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_dalcn.fields.LOCATION_ADDRESS_IDA) 'ผู้ดำเนิน
        cls_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_phr.fields.FK_IDA) 'ผู้มีหน้าที่ปฏิบัติการ
        Dim bao2 As New BAO.AppSettings
        bao2.RunAppSettings()
        Dim paths As String = bao2._PATH_DEFAULT
        Dim file_template As String = ""
        Dim process As String = "-"
        If get_session.PVCODE = "6" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
            process = "1701"
        ElseIf get_session.PVCODE = "7" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYOR8.pdf"
            process = "1702"
        ElseIf get_session.PVCODE = "8" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYORBOR8.pdf"
            process = "1703"
        ElseIf get_session.PVCODE = "9" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORBOR8.pdf"
            process = "1704"
        ElseIf get_session.PVCODE = "10" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_PORYOR8(VEJAI).pdf" '"C:\path\DRUG\PDF_TEMPLATE\PDF_DRUG_PORYOR8.pdf"
            process = "1705"
        End If

        Dim path_XML As String = paths & "XML_TRADER_DOWNLOAD\" & "DA-" & process & "-" & dao.fields.LCNNO_DISPLAY + ".xml"
        Dim file_PDF As String = paths & "PDF_TRADER_DOWNLOAD\" & "DA-" & process & "-" & dao.fields.LCNNO_DISPLAY + ".pdf"

        Dim objStreamWriter As New StreamWriter(path_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        convert_XML_To_PDF(file_PDF, path_XML, file_template)
        Dim pdf_name As String = process & "-" & dao.fields.LCNNO_DISPLAY

        _CLS.FILENAME_PDF = file_PDF                                                                                                 ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", pdf_name)

        Session("CLS") = _CLS

        LoadPdf()
    End Sub

    Public Function GEN_XML() As CLASS_DRSAMP
        Dim class_xml As New CLASS_DRSAMP

        Return class_xml

    End Function

    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('Download เสร็จสิ้น');", True)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
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
    ''' ใส่ค่าในฟิลที่ null
    ''' </summary>
    ''' <param name="ob"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Function AddValue(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()

            '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, " ", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.Double".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.float".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else
                    Try
                        props.SetValue(ob, 0, Nothing)
                    Catch ex As Exception
                        props.SetValue(ob, Nothing, Nothing)
                    End Try

                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        xml()
    End Sub

    Protected Sub Button2_Click1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim get_session As CLS_SESSION = Session("product_id")
        If get_session.PVCODE = "6" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1701 & "&lcn_ida=" & _lcn_ida & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "7" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1702 & "&lcn_ida=" & _lcn_ida & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "8" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1703 & "&lcn_ida=" & _lcn_ida & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "9" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1704 & "&lcn_ida=" & _lcn_ida & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "10" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1705 & "&lcn_ida=" & _lcn_ida & "';")
            Response.Write("</script type >")
        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(lcnno As Integer)
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        Try
            dt = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(lcnno)
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
        RadGrid1.Rebind()
    End Sub
    Public Sub set_label()

        Dim get_session As CLS_SESSION = Session("product_id")

        If get_session.PVCODE = "6" Then
            Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
            dao_drugname.GetDataby_IDA(get_session.IDA)
            lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
            lbl_nature.Text = dao_drugname.fields.DRUG_NATURE
            lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG

            Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
            unit_physic.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
            lbl_unitnm.Text = unit_physic.fields.unit_name
            lbl_unite_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_unit.Text = unit_physic.fields.unit_name

            Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
            dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_drugname.fields.IDA)
            lbl_write_at.Text = dao_drsamp.fields.WRITE_AT  'เขียนที่
            lbl_date.Text = dao_drsamp.fields.WRITE_DATE    'วันที่
            lbl_product_id.Text = dao_drugname.fields.LCNNO_DISPLAY 'เลขบัญชีรายการยา
            If dao_drsamp.fields.CHK_PRODUCT_FOR = 1 Then
                lbl_for1.Text = "สำหรับ : "
                lbl_for2.Text = "การศึกษาวิจัยในมนุษย์"
            ElseIf dao_drsamp.fields.CHK_PRODUCT_FOR = 2 Then
                lbl_for1.Text = "สำหรับ : "
                lbl_for2.Text = "กรณีอื่นๆ (ระบุ)" + " " + dao_drsamp.fields.CHK_FOR_OTHER
            End If

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)
            lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

            lbl_number.Text = dao_lcn.fields.BSN_ADDR            'ที่อยู่
            lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
            lbl_lane.Text = dao_lcn.fields.BSN_SOI               'ซอย
            lbl_road.Text = dao_lcn.fields.BSN_ROAD              'ถนน
            lbl_village_no.Text = dao_lcn.fields.BSN_MOO       'หมู่
            lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
            lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
            lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME      'จังหวัด
            lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE            'เบอร์โทร

            Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd)
            lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
            Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix2.Getdata_byid(dao_lcn.fields.syslcnsnm_lcnscd)
            lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ

            'ดึงตัวยาสำคัญ
            RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
            'ขนาดบรรจุ
            Size_Radgrid(dao_drugname.fields.FK_IDA)
        ElseIf get_session.PVCODE = "7" Then
            Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
            dao_drugname.GetDataby_IDA(get_session.IDA)
            lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
            lbl_nature.Text = dao_drugname.fields.DRUG_NATURE
            lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG

            Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
            unit_physic.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
            lbl_unitnm.Text = unit_physic.fields.unit_name
            lbl_unite_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_unit.Text = unit_physic.fields.unit_name

            Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
            dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_drugname.fields.IDA)
            lbl_write_at.Text = dao_drsamp.fields.WRITE_AT  'เขียนที่
            lbl_date.Text = dao_drsamp.fields.WRITE_DATE    'วันที่
            lbl_product_id.Text = dao_drugname.fields.LCNNO_DISPLAY 'เลขบัญชีรายการยา

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)
            lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

            lbl_number.Text = dao_lcn.fields.BSN_ADDR            'ที่อยู่
            lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
            lbl_lane.Text = dao_lcn.fields.BSN_SOI               'ซอย
            lbl_road.Text = dao_lcn.fields.BSN_ROAD              'ถนน
            lbl_village_no.Text = dao_lcn.fields.BSN_MOO       'หมู่
            lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
            lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
            lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME      'จังหวัด
            lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE            'เบอร์โทร

            Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd)
            lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
            Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix2.Getdata_byid(dao_lcn.fields.syslcnsnm_lcnscd)
            lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ

            'ดึงตัวยาสำคัญ
            RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
            'ขนาดบรรจุ
            Size_Radgrid(dao_drugname.fields.FK_IDA)
        ElseIf get_session.PVCODE = "8" Then
            Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
            dao_drugname.GetDataby_IDA(get_session.IDA)
            lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
            lbl_nature.Text = dao_drugname.fields.DRUG_NATURE
            lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG

            Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
            unit_physic.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
            lbl_unitnm.Text = unit_physic.fields.unit_name
            lbl_unite_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_unit.Text = unit_physic.fields.unit_name

            Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
            dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_drugname.fields.IDA)
            lbl_write_at.Text = dao_drsamp.fields.WRITE_AT  'เขียนที่
            lbl_date.Text = dao_drsamp.fields.WRITE_DATE    'วันที่
            lbl_product_id.Text = dao_drugname.fields.LCNNO_DISPLAY 'เลขบัญชีรายการยา
            If dao_drsamp.fields.CHK_PERMISSION_REQUEST = 1 Then
                lbl_REQUEST1.Text = "คำขออนุญาต :"
                lbl_REQUEST2.Text = "ผลิตยาตัวอย่าง"
                lbl_GET1.Text = "ได้รับอนุญาตให้ :"
                lbl_GET2.Text = "ผลิตยาแผนโบราณ"
                lbl_ASK1.Text = "ขออนุญาต :"
                lbl_ASK2.Text = "ผลิตยาตัวอย่าง"
                lbl_DESCRIPTION1.Text = "ขออนุญาต :"
                lbl_DESCRIPTION2.Text = "ยาที่ผลิต"
            ElseIf dao_drsamp.fields.CHK_PERMISSION_REQUEST = 2 Then
                lbl_REQUEST1.Text = "คำขออนุญาต :"
                lbl_REQUEST2.Text = "นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร"
                lbl_GET1.Text = "ได้รับอนุญาตให้ :"
                lbl_GET2.Text = "นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรตามใบอนุญาต"
                lbl_ASK1.Text = "ขออนุญาต :"
                lbl_ASK2.Text = "นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน"
                lbl_DESCRIPTION1.Text = "ขออนุญาต :"
                lbl_DESCRIPTION2.Text = "ยาที่นำนำหรือสั่งเข้ามาในราชอาณาจักร"
            End If

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)
            lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

            lbl_number.Text = dao_lcn.fields.BSN_ADDR            'ที่อยู่
            lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
            lbl_lane.Text = dao_lcn.fields.BSN_SOI               'ซอย
            lbl_road.Text = dao_lcn.fields.BSN_ROAD              'ถนน
            lbl_village_no.Text = dao_lcn.fields.BSN_MOO       'หมู่
            lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
            lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
            lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME      'จังหวัด
            lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE            'เบอร์โทร

            Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd)
            lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
            Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix2.Getdata_byid(dao_lcn.fields.syslcnsnm_lcnscd)
            lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ

            'ดึงตัวยาสำคัญ
            RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
            'ขนาดบรรจุ
            Size_Radgrid(dao_drugname.fields.FK_IDA)
        ElseIf get_session.PVCODE = "9" Then
            Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
            dao_drugname.GetDataby_IDA(get_session.IDA)
            lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
            lbl_nature.Text = dao_drugname.fields.DRUG_NATURE
            lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG

            Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
            unit_physic.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
            lbl_unitnm.Text = unit_physic.fields.unit_name
            lbl_unite_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_unit.Text = unit_physic.fields.unit_name

            Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
            dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_drugname.fields.IDA)
            lbl_write_at.Text = dao_drsamp.fields.WRITE_AT  'เขียนที่
            lbl_date.Text = dao_drsamp.fields.WRITE_DATE    'วันที่
            lbl_product_id.Text = dao_drugname.fields.LCNNO_DISPLAY 'เลขบัญชีรายการยา
            If dao_drsamp.fields.CHK_PERMISSION_REQUEST = 1 Then
                lbl_REQUEST1.Text = "คำขออนุญาต :"
                lbl_REQUEST2.Text = "ผลิตยาตัวอย่าง"
                lbl_GET1.Text = "ได้รับอนุญาตให้ :"
                lbl_GET2.Text = "ผลิตยาแผนโบราณ"
                lbl_ASK1.Text = "ขออนุญาต :"
                lbl_ASK2.Text = "ผลิตยาตัวอย่าง"
                lbl_DESCRIPTION1.Text = "ขออนุญาต :"
                lbl_DESCRIPTION2.Text = "ยาที่ผลิต"
            ElseIf dao_drsamp.fields.CHK_PERMISSION_REQUEST = 2 Then
                lbl_REQUEST1.Text = "คำขออนุญาต :"
                lbl_REQUEST2.Text = "นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร"
                lbl_GET1.Text = "ได้รับอนุญาตให้ :"
                lbl_GET2.Text = "นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรตามใบอนุญาต"
                lbl_ASK1.Text = "ขออนุญาต :"
                lbl_ASK2.Text = "นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน"
                lbl_DESCRIPTION1.Text = "ขออนุญาต :"
                lbl_DESCRIPTION2.Text = "ยาที่นำนำหรือสั่งเข้ามาในราชอาณาจักร"
            End If

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)
            lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

            lbl_number.Text = dao_lcn.fields.BSN_ADDR            'ที่อยู่
            lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
            lbl_lane.Text = dao_lcn.fields.BSN_SOI               'ซอย
            lbl_road.Text = dao_lcn.fields.BSN_ROAD              'ถนน
            lbl_village_no.Text = dao_lcn.fields.BSN_MOO       'หมู่
            lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
            lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
            lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME      'จังหวัด
            lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE            'เบอร์โทร

            Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd)
            lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
            Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix2.Getdata_byid(dao_lcn.fields.syslcnsnm_lcnscd)
            lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ

            'ดึงตัวยาสำคัญ
            RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
            'ขนาดบรรจุ
            Size_Radgrid(dao_drugname.fields.FK_IDA)
        ElseIf get_session.PVCODE = "10" Then
            Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
            dao_drugname.GetDataby_IDA(get_session.IDA)
            lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
            lbl_nature.Text = dao_drugname.fields.DRUG_NATURE
            lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG

            Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
            unit_physic.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
            lbl_unitnm.Text = unit_physic.fields.unit_name
            lbl_unite_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_unit.Text = unit_physic.fields.unit_name

            Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
            dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_drugname.fields.IDA)
            lbl_write_at.Text = dao_drsamp.fields.WRITE_AT  'เขียนที่
            lbl_date.Text = dao_drsamp.fields.WRITE_DATE    'วันที่
            lbl_product_id.Text = dao_drugname.fields.LCNNO_DISPLAY 'เลขบัญชีรายการยา
            If dao_drsamp.fields.CHK_PRODUCT_FOR = 1 Then
                lbl_for1.Text = "สำหรับ : "
                lbl_for2.Text = "การศึกษาวิจัยในมนุษย์"
            ElseIf dao_drsamp.fields.CHK_PRODUCT_FOR = 2 Then
                lbl_for1.Text = "สำหรับ : "
                lbl_for2.Text = "กรณีอื่นๆ (ระบุ)" + " " + dao_drsamp.fields.CHK_FOR_OTHER
            End If

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)
            lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

            lbl_number.Text = dao_lcn.fields.BSN_ADDR            'ที่อยู่
            lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
            lbl_lane.Text = dao_lcn.fields.BSN_SOI               'ซอย
            lbl_road.Text = dao_lcn.fields.BSN_ROAD              'ถนน
            lbl_village_no.Text = dao_lcn.fields.BSN_MOO       'หมู่
            lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
            lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
            lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME      'จังหวัด
            lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE            'เบอร์โทร

            Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd)
            lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
            Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix2.Getdata_byid(dao_lcn.fields.syslcnsnm_lcnscd)
            lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ

            'ดึงตัวยาสำคัญ
            RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
            'ขนาดบรรจุ
            Size_Radgrid(dao_drugname.fields.FK_IDA)
        End If
    End Sub
    Public Sub Size_Radgrid(ByVal ida As Integer)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(ida)

        RadGrid2.DataSource = dt
        RadGrid2.Rebind()
    End Sub
End Class