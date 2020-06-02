Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports FDA_DRUG
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class US_DS_PORYOR8_YAVEJAI_
    Inherits System.Web.UI.UserControl
    Private _CLS As CLS_SESSION
    Public _process As String = "1705"
    Private _lct_ida As Integer
    Private _lcn_ida As String
    Private _main_ida As String

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _lcn_ida = Request("lcn_ida").ToString()
                _main_ida = Request("main_ida").ToString()
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim cls_session As New CLS_SESSION
        cls_session.IDA = ddl_search.SelectedValue
        cls_session.PVCODE = "10"
        Session.Add("product_id", cls_session)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        RunSession()
        If Not IsPostBack Then

            txt_WRITE_DATE.Text = Date.Now.ToShortDateString 'แสดงวันที่
            bind_ddl_unit()
            load_ddl()
        End If
        'set_bio()
    End Sub
    Public Sub load_ddl() 'เลือกเลขที่บัญชีรายการยา
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_DRUG_PRODUCT_ID_BY_IDEN_SELECT2(_lcn_ida, _process)

        dt = bao.dt
        ddl_search.DataSource = dt
        ddl_search.DataTextField = "LCNNO_DISPLAY"
        ddl_search.DataValueField = "IDA"
        ddl_search.DataBind()

        Dim item As New ListItem
        item.Text = "กรุณาเลือกเลขที่บัญชีรายการยา"
        item.Value = "0"
        ddl_search.Items.Insert(0, item)
    End Sub
    Public Sub bind_ddl_unit() 'เลือกหน่วยขนาดบรรจุ
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_UNIT_CONTAIN

        Dim item As New ListItem("-", "0")

        ddl_munit.DataSource = dt
        ddl_munit.DataTextField = "unitnm"
        ddl_munit.DataValueField = "IDA"
        ddl_munit.DataBind()

        ddl_bunit.DataSource = dt
        ddl_bunit.DataTextField = "unitnm"
        ddl_bunit.DataValueField = "IDA"
        ddl_bunit.DataBind()

        ddl_munit.Items.Insert(0, item)
        ddl_bunit.Items.Insert(0, item)
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.ClsDBdrsamp)
        dao.fields.WRITE_AT = txt_WRITE_AT.Text     'เขียนที่
        dao.fields.WRITE_DATE = txt_WRITE_DATE.Text 'วันที่เขียน
        Try
            dao.fields.WRITE_DATE = CDate(txt_WRITE_DATE.Text) 'ดึงข้อมูลเขียนที่
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub chk_forhuman_CheckedChanged(sender As Object, e As EventArgs)
        txt_forother.Visible = False
    End Sub
    Protected Sub chk_forother_CheckedChanged(sender As Object, e As EventArgs) Handles chk_forother.CheckedChanged
        txt_forother.Visible = True 'เลือกกรณีอื่นๆ (ระบุ)
    End Sub
    Public Sub set_label(ByVal lcnno_display As String) 'ดึงข้อมูลแสดง
        Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_drugname.GetDataby_product(lcnno_display)
            lbl_drugthanm.Text = dao_drugname.fields.DRUG_NAME_THAI '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.DRUG_NAME_OTHER
            'lbl_unit.Text = dao_drugname.fields.FK_DOSAGE_FORM    'หน่วยนับตามรูปแบบยา
            'lbl_sunit_ida.Text = dao_drugname.fields.FK_DOSAGE_FORM    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_nature.Text = dao_drugname.fields.DRUG_COLOR
            'lbl_dosage.Text = dao_drugname.fields.STRENGTH_DRUG 'ปริมาณที่จะผลิต/นำสั่ง

        Catch ex As Exception

        End Try

        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_package.GetDataby_FK_IDA(dao_drugname.fields.IDA)
        lbl_sunit_ida.Text = dao_package.fields.SMALL_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ

        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
        Try
            dao_unit.GetDataby_IDA(dao_package.fields.SMALL_UNIT)
            lbl_unit.Text = dao_unit.fields.unit_name 'หน่วยนับตามรูปแบบยา
            'lbl_unit2.Text = dao_unit.fields.unit_name 'หน่วยของปริมาณที่จะผลิต/นำสั่ง
            lbl_sunit.Text = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
        Catch ex As Exception

        End Try
        '--------------------------------------------------------------------------------------

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn 'ตาราางเก็บที่อยู่
        dao_lcn.GetDataby_IDA(dao_drugname.fields.FK_IDA)
        'dao_lcn.GetDataEditby_IDEN(dao_drugname.fields.CITIZEN_ID_AUTHORIZE)
        'txt_WRITE_AT.Text = dao_lcn.fields.WRITE_AT             'เขียนที่
        lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY  'เลขที่ใบอนุญาต
        lbl_number.Text = dao_lcn.fields.LOCATION_ADDRESS_thaaddr               'ที่อยู่
        lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace            'สถานที่ผลิต / นำสั่ง
        lbl_lane.Text = dao_lcn.fields.LOCATION_ADDRESS_thasoi                'ซอย
        lbl_road.Text = dao_lcn.fields.LOCATION_ADDRESS_tharoad              'ถนน
        lbl_village_no.Text = dao_lcn.fields.LOCATION_ADDRESS_thamu         'หมู่
        lbl_sub_district.Text = dao_lcn.fields.LOCATION_ADDRESS_thathmblnm 'ตำบล
        lbl_district.Text = dao_lcn.fields.LOCATION_ADDRESS_thaamphrnm     'อำเภอ
        lbl_province.Text = dao_lcn.fields.LOCATION_ADDRESS_thachngwtnm   'จังหวัด
        lbl_tel.Text = dao_lcn.fields.tel 'เบอร์โทร

        Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
        dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd) 'ชื่อผู้รับอนุญาต
        lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต

        Try
            Dim dao_lo_bsn As New DAO_CPN.TB_LOCATION_BSN
            dao_lo_bsn.Getdata_by_bsnid(dao_lcn.fields.bsnid)

            Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            dao_prefix2.Getdata_byid(dao_lo_bsn.fields.BSN_PREFIXTHAICD)
            lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ
        Catch ex As Exception

        End Try


        'ดึงตัวยาสำคัญ
        RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
        Unit_Radgrid(dao_drugname.fields.FK_IDA) 'ดึงขนาดบรรจุ
        package(dao_drugname.fields.FK_IDA)
        imp_detail(dao_drugname.fields.FK_IDA)
    End Sub
    Private Sub RadGrid1_NeedDataSource(lcnno As Integer) 'ตัวยาสำคัญ
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(lcnno)

        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                'dao.GetDataAll()
                dao.delete()      'ลบข้อมูลในตารางขนาดบรรจุ
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid2.Rebind()
            End If
        End If
    End Sub
    Public Sub Unit_Radgrid(ByVal ida As Integer)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA(ida)

        RadGrid2.DataSource = dt
        RadGrid2.Rebind()
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If ddl_search.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
        Else
            Dim lcn_no As String = ddl_search.SelectedItem.Text 'ปุ่มดึงข้อมูล
            set_label(lcn_no)
            Dim check_lcntpcd As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            check_lcntpcd.GetDataby_product(lcn_no)
        Dim check As New DAO_DRUG.ClsDBdalcn
            check.GetDataby_IDA(check_lcntpcd.fields.FK_IDA)

            If check.fields.lcntpcd = "ผย1" Then
                chk_forhuman.Checked = True
            ElseIf check.fields.lcntpcd = "ผย8" Then
                chk_forother.Checked = False
            End If
        End If
    End Sub
    'Private Sub set_data(dao As TB_DRUG_PRODUCT_ID)
    '    set_bio()
    'End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click 'ปุ่มเพิ่มขนาดบรรจุ
        If ddl_search.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
        ElseIf txt_packagename.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกชื่อขนาดบรรจุ');", True)
        ElseIf txt_sunit.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_munit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_mamount.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_bunit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_barcode.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกหมายเลขบาร์โค้ด');", True)
        Else
            Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
            Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_drugname.GetDataby_product(ddl_search.SelectedItem.Text)
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.SMALL_UNIT = lbl_sunit_ida.Text            'เลือกขนาดของหน่วยเล็ก
                dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue  'เลือกขนาดของหน่วยกลาง
                dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = dao_drugname.fields.FK_IDA
            dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
            dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
            dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
            dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เพิ่มข้อมูลขนาดบรรจุเรียบร้อย');", True)
            Unit_Radgrid(dao_drugname.fields.FK_IDA)
        End If
    End Sub
    Protected Sub ddl_munit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_munit.SelectedIndexChanged
        lbl_munit.Text = ddl_munit.SelectedItem.Text
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If ddl_search.SelectedValue = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
        ElseIf txt_WRITE_AT.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเขียนที่');", True)
        Else
            Dim save As New DAO_DRUG.ClsDBdrsamp 'เก็บข้อมูลในตาราง drsamp
            'chk_package()
            save.fields.WRITE_AT = txt_WRITE_AT.Text 'เก็บเขียนที่
            save.fields.WRITE_DATE = Date.Now 'เก็บวันที่

            Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
            dao_drugname.GetDataby_IDA(ddl_search.SelectedValue)
            save.fields.lcnno = dao_drugname.fields.FK_IDA 'เก็บเลขที่ใบอนุญาต

            If chk_forhuman.Checked = True Then
                save.fields.CHK_PRODUCT_FOR = 1 'เก็บค่า chk การศึกษาวิจัยในมนุษย์
            ElseIf chk_forother.Checked = True Then
                save.fields.CHK_PRODUCT_FOR = 2
                save.fields.CHK_FOR_OTHER = txt_forother.Text
            End If
            'เก็บข้อมูลในตาราง drsamp
            save.fields.lcntpcd = "ผย8" 'เก็บประเภทของใบอนุญาต
            save.fields.thadrgnm = lbl_drugthanm.Text 'เก็บชื่อยาภาษาไทย
            save.fields.engdrgnm = lbl_drugengnm.Text 'เก็บชื่อยาภาษาอังกฤษ
            save.fields.PRODUCT_ID_IDA = ddl_search.SelectedValue 'เก็บค่า IDA
            save.insert()
            Xml(save.fields.IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        End If
    End Sub
    'Sub chk_package()
    '    Dim package_detail As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL

    '    For Each item As GridDataItem In RadGrid2.Items

    '        Dim cb_chk As CheckBox = DirectCast(item("TemplateColumn").FindControl("checkColumn"), CheckBox)
    '        If cb_chk.Checked = True Then

    '            package_detail.GetDataby_IDA(item("IDA").Text)
    '            package_detail.fields.CHECK_PACKAGE = 1
    '            package_detail.update()
    '        End If
    '    Next
    'End Sub
    Sub xml(ByVal drsamp_ida As Integer)
        Dim get_session As CLS_SESSION = Session("product_id")
        Dim cls_xml As New CLASS_DRSAMP
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_master As New BAO_MASTER

        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_product(ddl_search.SelectedItem.Text)
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao.fields.IDA)
        Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
        dao_dalcn.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_drsamp_pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_drsamp_pack.GetDataby_IDA(dao.fields.IDA)
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao.fields.IDA)

        cls_xml = GEN_XML()
        cls_xml.drsamp = dao_drsamp.fields  'ใบ
        cls_xml.DT_SHOW.DT1 = bao.SP_DRUG_REGISTRATION(dao.fields.IDA) 'บัญชีรายการยา
        cls_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(dao.fields.FK_IDA) 'เลขที่ใบอนุญาต
        cls_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(dao.fields.IDA) 'ตัวยาสำคัญ
        cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(dao.fields.IDA) 'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.FK_IDA) 'ขนาดบรรจุ
        Try
            cls_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_RCV(dao_drsamp.fields.IDA) 'เลขที่รับ
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
            cls_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_phr.fields.FK_IDA) 'ผู้มีหน้าที่ปฏิบัติการ
        Catch ex As Exception

        End Try

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

        Dim path_XML As String = paths & "XML_TRADER_DOWNLOAD\" & "DA-" & process & "-" & dao.fields.RCVNO_DISPLAY + ".xml"
        Dim file_PDF As String = paths & "PDF_TRADER_DOWNLOAD\" & "DA-" & process & "-" & dao.fields.RCVNO_DISPLAY + ".pdf"

        Dim objStreamWriter As New StreamWriter(path_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        convert_XML_To_PDF(file_PDF, path_XML, file_template)
        Dim pdf_name As String = process & "-" & dao.fields.RCVNO_DISPLAY

        _CLS.FILENAME_PDF = file_PDF                                                                                                 ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", pdf_name)

        Session("CLS") = _CLS

        LoadPdf()
    End Sub

    'Sub after_save(ByVal a As Integer)
    '    Dim cls_session As New CLS_SESSION
    '    cls_session.IDA = ddl_search.SelectedValue
    '    cls_session.TRANSECTION_UP_ID = a
    '    cls_session.PVCODE = "10"
    '    Session.Add("product_id", cls_session)
    '    Response.Redirect("DS_DOWNLOAD_PDF.aspx?lcn_ida=" & _lcn_ida)
    'End Sub

    Private Function GEN_XML() As CLASS_DRSAMP
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
    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
        'Dim get_session As CLS_SESSION = Session("product_id")
        'If get_session.PVCODE = "6" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1701 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "7" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1702 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "8" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1703 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "9" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1704 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'ElseIf get_session.PVCODE = "10" Then
        '    Response.Write("<script type langue =javascript>")
        '    Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & 1705 & "&lcn_ida=" & _lcn_ida & "';")
        '    Response.Write("</script type >")
        'End If
    End Sub

    Private Sub txt_qty_TextChanged(sender As Object, e As EventArgs) Handles txt_qty.TextChanged
        sum()
    End Sub

    Sub sum()
        Try
            Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
            dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)

            Dim sum As Integer = 0
            sum = CInt(dao_package.fields.SMALL_AMOUNT) * CInt(dao_package.fields.MEDIUM_AMOUNT)
            sum = sum * CInt(txt_qty.Text)

            lbl_import_sum.Text = "( " & sum & " " & lbl_unit.Text & ")"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_package_Click(sender As Object, e As EventArgs) Handles btn_package.Click

        If Label2.Text = "on" Then
            Label2.Text = "off"
            package2.Style.Add("display", "in-line")
            package3.Style.Add("display", "in-line")
        Else
            Label2.Text = "on"
            package2.Style.Add("display", "none")
            package3.Style.Add("display", "none")
        End If

    End Sub

    Sub package(ByVal fk_ida As Integer)
        Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        Dim item As New ListItem("---เลือกขนาดบรรจุ---", "0")
        dao_package.GetDataby_FK_IDA(fk_ida)
        ddl_package_unit.DataSource = dao_package.datas
        ddl_package_unit.DataTextField = "PACKAGE_NAME"
        ddl_package_unit.DataValueField = "IDA"
        ddl_package_unit.DataBind()
        ddl_package_unit.Items.Insert(0, item)
    End Sub

    Protected Sub ddl_package_unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_package_unit.SelectedIndexChanged
        Try
            Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
            dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
            Dim dao_mas_unit As New DAO_DRUG.TB_MAS_UNIT_CONTAIN
            dao_mas_unit.GetDataby_IDA(dao_package.fields.BIG_UNIT)
            imp_unit.Text = dao_mas_unit.fields.unitnm
        Catch ex As Exception

        End Try

        sum()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
        Dim dao_mas_unit As New DAO_DRUG.TB_MAS_UNIT_CONTAIN
        dao_mas_unit.GetDataby_IDA(dao_package.fields.MEDIUM_UNIT)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_main_ida)
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao.fields.IDA)
        dao_package.fields.DRSAMP_IDA = dao_drsamp.fields.IDA
        If dao_package.fields.CHECK_PACKAGE = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ขนาดบรรจุนี้ มีปริมาณที่จะผลิต/นำสั่งแล้ว');", True)
        Else
            dao_package.fields.IM_QTY = CInt(txt_qty.Text)
            Dim sum As Integer = CInt(dao_package.fields.SMALL_AMOUNT) * CInt(dao_package.fields.MEDIUM_AMOUNT)
            sum = sum * CInt(txt_qty.Text)
            dao_package.fields.SUM = sum
            dao_package.fields.IM_DETAIL = ddl_package_unit.SelectedItem.Text & " นำเข้า " & txt_qty.Text & " " & dao_mas_unit.fields.unitnm & " " & sum & " " & lbl_unit.Text
            dao_package.fields.CHECK_PACKAGE = 1
            dao_package.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
            imp_detail(dao_package.fields.FK_IDA)
        End If

    End Sub

    Sub imp_detail(ByVal fk_ida As Integer)
        Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_package.GetDataby_FK_IDA(fk_ida)
        txt_imp.Text = ""
        For Each dao_package.fields In dao_package.datas
            If dao_package.fields.CHECK_PACKAGE = True Then
                If txt_imp.Text = "" Then
                    txt_imp.Text = dao_package.fields.IM_DETAIL
                Else
                    txt_imp.Text = txt_imp.Text & "<br/>" & dao_package.fields.IM_DETAIL
                End If
            Else

            End If
        Next
    End Sub

    Sub chk_active_package(ByVal lcn_dis As String)
        Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
        dao_drugname.GetDataby_product(lcn_dis)
        Dim pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        pack.GetData_chk_by_FK_IDA(dao_drugname.fields.FK_IDA)

        For Each pack.fields In pack.datas
            If IsNothing(pack.fields.DATE_ADD) Then

            Else
                Dim chkdate180 As Date
                chkdate180 = pack.fields.DATE_ADD
                chkdate180 = chkdate180.AddDays(180)

                If chkdate180 < Date.Now Then
                    pack.fields.CHECK_PACKAGE = False
                    pack.update()
                End If
            End If
        Next
    End Sub
End Class