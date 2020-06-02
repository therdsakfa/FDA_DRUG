Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI

Public Class US_DS_YORBOR5
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'set_label(73405)
        If Not IsPostBack Then
            txt_WRITE_DATE.Text = Date.Now.ToShortDateString 'แสดงวันที่
            bind_ddl_unit()
        End If
        set_bio()
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
    Sub set_bio() 'เลือก checkbox
        If chk_unit.Checked Then
            txt_packagename.Enabled = True
            txt_sunit.Enabled = True
            txt_mamount.Enabled = True
            ddl_munit.Enabled = True
            ddl_bunit.Enabled = True
            txt_barcode.Enabled = True
            btn_add.Enabled = True
        Else
            txt_packagename.Enabled = False
            txt_sunit.Enabled = False
            txt_mamount.Enabled = False
            ddl_munit.Enabled = False
            ddl_bunit.Enabled = False
            txt_barcode.Enabled = False
            btn_add.Enabled = False
        End If
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.ClsDBdrsamp)
        dao.fields.WRITE_AT = txt_WRITE_AT.Text     'เขียนที่
        dao.fields.WRITE_DATE = txt_WRITE_DATE.Text 'วันที่เขียน
        Try
            dao.fields.WRITE_DATE = CDate(txt_WRITE_DATE.Text) 'ดึงข้อมูลเขียนที่
        Catch ex As Exception

        End Try
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ID)
        chk_unit.Checked = dao.fields.IS_BIO
    End Sub
    Public Sub set_label(ByVal lcnno_display As String) 'ดึงข้อมูลแสดง
        Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao_drugname.GetDataby_product(lcnno_display)
        lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
        lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
        lbl_unit.Text = dao_drugname.fields.PHYSIC_UNIT     'หน่วยนับตามรูปแบบยา
        lbl_sunit_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
        lbl_nature.Text = dao_drugname.fields.DRUG_NATURE   'ปริมาณที่จะผลิต/นำสั่ง
        lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG 'ปริมาณที่จะผลิต/นำสั่ง

        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
        dao_unit.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
        lbl_unit.Text = dao_unit.fields.unit_name 'หน่วยนับตามรูปแบบยา
        lbl_unit2.Text = dao_unit.fields.unit_name 'หน่วยของปริมาณที่จะผลิต/นำสั่ง
        lbl_sunit.Text = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
        '--------------------------------------------------------------------------------------

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn 'ตาราางเก็บที่อยู่
        dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)
        dao_lcn.GetDataEditby_IDEN(dao_drugname.fields.CITIZEN_ID_AUTHORIZE)
        txt_WRITE_AT.Text = dao_lcn.fields.WRITE_AT             'เขียนที่
        lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY  'เลขที่ใบอนุญาต
        lbl_number.Text = dao_lcn.fields.BSN_ADDR               'ที่อยู่
        lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace              'สถานที่ผลิต / นำสั่ง
        lbl_lane.Text = dao_lcn.fields.BSN_SOI                  'ซอย
        lbl_road.Text = dao_lcn.fields.BSN_ROAD                 'ถนน
        lbl_village_no.Text = dao_lcn.fields.BSN_MOO            'หมู่
        lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
        lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
        lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME        'จังหวัด
        lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE             'เบอร์โทร

        Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
        dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd) 'ชื่อผู้รับอนุญาต
        lbl_lcnsnm.Text = dao_prefix.fields.thaabbr & dao_lcn.fields.thanm '& " " & dao_lcn.fields.thanm 'คำนำหน้าชื่อ + ชื่อ + นามสกุล
        dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_lcnscd) 'ชื่อผู้ดำเนินกิจการ
        lbl_bsn_name.Text = dao_prefix.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'คำนำหน้าชื่อ + ชื่อ-นามสกุล

        'ดึงตัวยาสำคัญ
        RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
        Unit_Radgrid(dao_drugname.fields.FK_IDA) 'ดึงขนาดบรรจุ
    End Sub
    Private Sub RadGrid1_NeedDataSource(lcnno As Integer) 'ตัวยาสำคัญ
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(lcnno)

        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
        RadGrid1.Rebind()
    End Sub
    Protected Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs)
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim drsamp As Integer = 5503748
        dt = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA(drsamp) 'ตารางแสดงขนาดบรรจุ

        RadGrid2.DataSource = dt
        RadGrid2.Rebind()
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                'dao.GetDataAll()
                dao.delete()
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
        Dim lcn_no As String = txt_secrch.Text 'ปุ่มดึงข้อมูล
        set_label(lcn_no)

        Dim check_lcntpcd As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        check_lcntpcd.GetDataby_product(lcn_no)

        Dim check As New DAO_DRUG.ClsDBdalcn
        check.GetDataby_IDA(check_lcntpcd.fields.LCN_IDA)
        'check.GetDataby_IDA(47)

        If check.fields.lcntpcd = "นย1" Then
            rdb_sample_drug.Checked = True
            rdb_manufacture.Checked = True
            rdb_samples_drug.Checked = True
            rdb_drug_produce.Checked = True
        ElseIf check.fields.lcntpcd = "นย1" Then
            rdb_direct_register.Checked = True
            rdb_direct_license.Checked = True
            rdb_direct_registers.Checked = True
            rdb_direct.Checked = True
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เลขที่นี้ไม่มี ยบ5 ในระบบ');", True)
        End If
    End Sub
    'Private Sub set_data(dao As TB_DRUG_PRODUCT_ID)
    '    set_bio()
    'End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click 'ปุ่มเพิ่มขนาดบรรจุ
        If txt_secrch.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาดึงข้อมูลจาก Product ID');", True)
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
            Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao_drugname.GetDataby_product(txt_secrch.Text)
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
        Dim save As New DAO_DRUG.ClsDBdrsamp
        chk_package()
        chk_package()
        save.fields.WRITE_AT = txt_WRITE_AT.Text 'เก็บเขียนที่
        save.fields.WRITE_DATE = Date.Now 'เก็บวันที่

        Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
        dao_drugname.GetDataby_product(txt_secrch.Text)
        save.fields.lcnno = dao_drugname.fields.LCN_IDA 'เก็บเลขที่ใบอนุญาต
        If rdb_sample_drug.Checked = True Then
            save.fields.CHK_PERMISSION_REQUEST = rdb_sample_drug.Text 'ผลิตยาตัวอย่าง
            save.fields.CHK_PERMISSION_GET = rdb_manufacture.Text 'ผลิตยาแผนโบราณ
            save.fields.CHK_PERMISSION_ASK = rdb_samples_drug.Text 'ผลิตยาตัวอย่าง
            save.fields.CHK_PERMISSION_DESCRIPTION = rdb_drug_produce.Text 'ยาที่ผลิต
        ElseIf rdb_direct_register.Checked = True Then
            save.fields.CHK_PERMISSION_REQUEST = rdb_direct_register.Text 'นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร
            save.fields.CHK_PERMISSION_GET = rdb_direct_license.Text 'นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรตามใบอนุญาต
            save.fields.CHK_PERMISSION_ASK = rdb_direct_registers.Text 'นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน
            save.fields.CHK_PERMISSION_DESCRIPTION = rdb_direct.Text 'ยาที่นำนำหรือสั่งเข้ามาในราชอาณาจักร
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกคำขออนุญาติ');", True)
        End If
        'เก็บข้อมูลในตาราง drsamp
        save.fields.lcntpcd = "ยบ5" 'เก็บประเภทของใบอนุญาต
        save.fields.thadrgnm = lbl_drugthanm.Text 'เก็บชื่อยาภาษาไทย
        save.fields.engdrgnm = lbl_drugengnm.Text 'เก็บชื่อยาภาษาอังกฤษ
        save.fields.PRODUCT_ID_IDA = dao_drugname.fields.IDA 'เก็บค่า IDA

        save.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
    End Sub
    Sub chk_package()
        Dim package_detail As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL

        For Each item As GridDataItem In RadGrid2.Items

            Dim cb_chk As CheckBox = DirectCast(item("TemplateColumn").FindControl("checkColumn"), CheckBox)
            If cb_chk.Checked = True Then

                package_detail.GetDataby_IDA(item("IDA").Text)
                package_detail.fields.CHECK_PACKAGE = 1
                package_detail.update()

            End If
        Next
    End Sub

    Protected Sub rdb_manufacture_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_manufacture.CheckedChanged
        rdb_sample_drug.Checked = rdb_manufacture.Checked
        rdb_drug_produce.Checked = rdb_manufacture.Checked
        rdb_manufacture.Checked = rdb_drug_produce.Checked
        rdb_manufacture.Checked = rdb_drug_produce.Checked
    End Sub

    Protected Sub rdb_direct_license_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_direct_license.CheckedChanged
        rdb_direct_register.Checked = rdb_direct_license.Checked
        rdb_direct.Checked = rdb_direct_license.Checked
        rdb_direct_license.Checked = rdb_direct_register.Checked
        rdb_direct_license.Checked = rdb_direct.Checked
    End Sub

    Protected Sub rdb_sample_drug_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_sample_drug.CheckedChanged
        rdb_manufacture.Checked = True
        rdb_samples_drug.Checked = True
        rdb_drug_produce.Checked = True
        rdb_direct_license.Checked = False
        rdb_direct_registers.Checked = False
        rdb_direct.Checked = False
    End Sub

    Protected Sub rdb_direct_register_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_direct_register.CheckedChanged
        rdb_direct_license.Checked = True
        rdb_direct_registers.Checked = True
        rdb_direct.Checked = True
        rdb_manufacture.Checked = False
        rdb_samples_drug.Checked = False
        rdb_drug_produce.Checked = False
    End Sub

    Protected Sub btn_gen_Click(sender As Object, e As EventArgs) Handles btn_gen.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_show As New BAO_SHOW
        Dim bao_master As New BAO_MASTER
        Dim cls_xml As New CLASS_DRSAMP
        cls_xml = GEN_XML()
        Dim dao_id As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao_id.GetDataby_product(txt_secrch.Text)

        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_IDA(dao_id.fields.IDA)

        Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
        dao_dalcn.GetDataby_IDA(dao_id.fields.LCN_IDA)

        Dim dao_drsamp_pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_drsamp_pack.GetDataby_IDA(dao_id.fields.IDA)

        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_FK_IDA(dao_id.fields.IDA)



        cls_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(dao_id.fields.IDA) 'บัญชีรายการยา
        cls_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(dao_id.fields.LCN_IDA) 'เลขที่ใบอนุญาต
        cls_xml.DT_SHOW.DT3 = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(dao_id.fields.IDA) 'ตัวยาสำคัญ
        cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(dao_id.fields.IDA) 'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao_id.fields.FK_IDA) 'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_dalcn.fields.LOCATION_ADDRESS_IDA) 'ผู้ดำเนิน
        cls_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(dao_phr.fields.FK_IDA) 'ผู้มีหน้าที่ปฏิบัติการ

        Dim path_XML As String = "D:\test_xml\YORBOR5.xml"

        Dim objStreamWriter As New StreamWriter(path_XML) 'แปลงเป็น XML
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub

    Private Function GEN_XML() As CLASS_DRSAMP
        Dim class_xml As New CLASS_DRSAMP

        Return class_xml
    End Function

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
End Class