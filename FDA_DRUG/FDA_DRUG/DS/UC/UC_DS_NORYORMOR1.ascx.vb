Imports FDA_DRUG.DAO_DRUG
Imports Telerik.Web.UI

Public Class UC_DS_NORYORMOR1
    Inherits System.Web.UI.UserControl

    Private _CLS As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'bind_ddl_unit()
            bind_ddl_size()
            txt_WRITE_DATE.Text = Date.Now.ToShortDateString
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

    'Public Sub bind_ddl_unit()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao.SP_DRUG_UNIT_PHYSIC()

    '    Dim item As New ListItem("", "0")
    '    ddl_unit.DataSource = dt
    '    ddl_unit.DataTextField = "unit_name"
    '    ddl_unit.DataValueField = "IDA"
    '    ddl_unit.DataBind()
    '    ddl_unit.Items.Insert(0, item)

    'End Sub

    Public Sub bind_ddl_size()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_UNIT_CONTAIN()

        Dim item As New ListItem("", "0")

        ddl_size6.DataSource = dt
        ddl_size6.DataTextField = "unitnm"
        ddl_size6.DataValueField = "unitcd2"
        ddl_size6.DataBind()

        ddl_size4.DataSource = dt
        ddl_size4.DataTextField = "unitnm"
        ddl_size4.DataValueField = "unitcd2"
        ddl_size4.DataBind()

        ddl_size4.Items.Insert(0, item)
        ddl_size6.Items.Insert(0, item)

    End Sub

    Public Sub set_label(ByVal lcnno_display As String)

        Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
        dao_drugname.GetDataby_product(lcnno_display)
        lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
        lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
        lbl_nature.Text = dao_drugname.fields.DRUG_NATURE
        lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG

        Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
        unit_physic.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
        lbl_unitnm.Text = unit_physic.fields.unit_name
        lbl_unite_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
        lbl_unit.Text = unit_physic.fields.unit_name
        lbl_size_5.Text = unit_physic.fields.unit_name

        '--------------------------------------------------------------------------------------

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)

        lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

        'lbl_number.Text = dao_lcn.fields.thaaddr            'ที่อยู่
        'lbl_place_name.Text = dao_lcn.fields.thanameplace   'สถานที่ผลิต / นำสั่ง
        'lbl_lane.Text = dao_lcn.fields.thasoi               'ซอย
        'lbl_road.Text = dao_lcn.fields.tharoad              'ถนน
        'lbl_village_no.Text = dao_lcn.fields.chngwtcd       'หมู่
        'lbl_sub_district.Text = dao_lcn.fields.thathmblnm   'ตำบล
        'lbl_district.Text = dao_lcn.fields.thaamphrnm       'อำเภอ
        'lbl_province.Text = dao_lcn.fields.thachngwtnm      'จังหวัด
        'lbl_tel.Text = dao_lcn.fields.tel                   'เบอร์โทร

        lbl_number.Text = dao_lcn.fields.BSN_ADDR            'ที่อยู่
        lbl_place_name.Text = dao_lcn.fields.thanm   'สถานที่ผลิต / นำสั่ง
        lbl_lane.Text = dao_lcn.fields.BSN_SOI               'ซอย
        lbl_road.Text = dao_lcn.fields.BSN_ROAD              'ถนน
        lbl_village_no.Text = dao_lcn.fields.BSN_MOO       'หมู่
        lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
        lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
        lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME      'จังหวัด
        lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE            'เบอร์โทร

        Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
        dao_prefix.Getdata_byid(dao_lcn.fields.BSN_PREFIXENGCD) 'ชื่อผู้รับอนุญาต
        lbl_lcnsnm.Text = dao_prefix.fields.thaabbr & dao_lcn.fields.BSN_THAINAME & " " & dao_lcn.fields.BSN_THAILASTNAME 'คำนำหน้าชื่อ + ชื่อ + นามสกุล
        dao_prefix.Getdata_byid(dao_lcn.fields.BSN_PREFIXENGCD) 'ชื่อผู้ดำเนินกิจการ
        lbl_bsn_name.Text = dao_prefix.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'คำนำหน้าชื่อ + ชื่อ-นามสกุล

        'ดึงตัวยาสำคัญ
        'fix ค่า 0 เพราะยังไม่มีตัวยาสำคัญหมวด นยม ในเบส
        RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
        'ขนาดบรรจุ
        Size_Radgrid(dao_drugname.fields.FK_IDA)

    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao_drungname As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                dao_drungname.GetDataby_IDA(item("IDA").Text)

                Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)

                Size_Radgrid(dao_drungname.fields.FK_IDA)
            End If
        End If
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Try
            Dim lcn_no As String = txt_secrch.Text
            set_label(lcn_no)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Size_Radgrid(ByVal ida As Integer)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA(ida)

        RadGrid2.DataSource = dt
        RadGrid2.Rebind()
    End Sub

    Protected Sub ddl_size6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_size6.SelectedIndexChanged
        lbl_size_m.Text = ddl_size6.SelectedItem.Text
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        txt_krathrwng.Visible = True
        txt_thabuang.Visible = False
        txt_kom.Visible = False
        'txt_phoothane.Visible = False
        'txt_samakom.Visible = False
        'txt_moolniti.Visible = False
    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        txt_thabuang.Visible = True
        txt_krathrwng.Visible = False
        txt_kom.Visible = False
        'txt_phoothane.Visible = False
        'txt_samakom.Visible = False
        'txt_moolniti.Visible = False
    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        txt_kom.Visible = True
        txt_thabuang.Visible = False
        txt_krathrwng.Visible = False
        'txt_phoothane.Visible = False
        'txt_samakom.Visible = False
        'txt_moolniti.Visible = False
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim save As New DAO_DRUG.ClsDBdrsamp

        chk_package() 'อัพเดท checkbox ใน radgrid

        save.fields.WRITE_AT = txt_WRITE_AT.Text
        save.fields.WRITE_DATE = Date.Now

        Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
        dao_drugname.GetDataby_product(txt_secrch.Text)
        save.fields.lcnno = dao_drugname.fields.LCN_IDA

        'ในนามของ
        If CheckBox1.Checked = True Then
            save.fields.IN_NAME = CheckBox1.Text + txt_krathrwng.Text
        ElseIf CheckBox2.Checked = True Then
            save.fields.IN_NAME = CheckBox2.Text + txt_thabuang.Text
        ElseIf CheckBox3.Checked = True Then
            save.fields.IN_NAME = CheckBox3.Text + txt_kom.Text
        ElseIf CheckBox4.Checked = True Then
            save.fields.IN_NAME = CheckBox4.Text
        ElseIf CheckBox5.Checked = True Then
            save.fields.IN_NAME = CheckBox5.Text
            'ElseIf CheckBox6.Checked = True Then
            '    save.fields.IN_NAME = CheckBox6.Text + txt_phoothane.Text
            'ElseIf CheckBox7.Checked = True Then
            '    save.fields.IN_NAME = CheckBox7.Text + txt_samakom.Text
            'ElseIf CheckBox8.Checked = True Then
            '    save.fields.IN_NAME = CheckBox8.Text + txt_moolniti.Text
        End If

        'รายละเอียดโครงการวิจัย
        If pjengnm.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกชื่อโครงการวิจัย');", True)
        Else
            save.fields.pjengnm = pjengnm.Text
        End If

        Try
            save.fields.pjthanm = pjthanm.Text
        Catch ex As Exception
        End Try

        Try
            save.fields.pj_number = pj_number.Text
        Catch ex As Exception

        End Try

        If pj_lo.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกสถาณที่ศึกษาวิจัย');", True)
        Else
            save.fields.pj_lo = pj_lo.Text
        End If

        save.fields.lcntpcd = "นยม1"

        save.fields.thadrgnm = lbl_drugthanm.Text
        save.fields.engdrgnm = lbl_drugengnm.Text

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

    'เพิ่มขนาดบรรจุ
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_secrch.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาดึงข้อมูลจาก Product ID');", True)
        ElseIf txt_barcode.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกหมายเลขบาร์โค้ด');", True)
        Else

            Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
            Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
            dao_drugname.GetDataby_product(txt_secrch.Text)
            Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
            'dao_unit.GetDataby_IDA()

            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.SMALL_UNIT = lbl_unite_ida.Text   'เลือกขนาดของหน่วยเล็ก
                dao.fields.MEDIUM_UNIT = ddl_size6.SelectedValue  'เลือกขนาดของหน่วยกลาง
                dao.fields.BIG_UNIT = ddl_size4.SelectedValue     'เลือกขนาดของหน่วยใหญ่
            Catch ex As Exception

            End Try
            'dao.fields.FK_IDA = Convert.ToInt32(txt_secrch.Text.ToString.Substring(1, 7))
            dao.fields.FK_IDA = dao_drugname.fields.FK_IDA
            dao.fields.SMALL_AMOUNT = txt_size1.Text         'จำนวนขนาดบรรจุเล็ก
            dao.fields.MEDIUM_AMOUNT = txt_size3.Text        'จำนวนขนาดบรรจุกลาง
            dao.fields.BARCODE = txt_barcode.Text
            dao.insert()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)

            'dao_drugname.GetDataby_product(Convert.ToInt32(txt_secrch.Text.ToString.Substring(1, 7)))
            Size_Radgrid(dao_drugname.fields.FK_IDA)

        End If

    End Sub

    'Protected Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
    '    txt_kom.Visible = False
    '    txt_thabuang.Visible = False
    '    txt_krathrwng.Visible = False
    'End Sub

    'Protected Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
    '    txt_kom.Visible = False
    '    txt_thabuang.Visible = False
    '    txt_krathrwng.Visible = False
    '    txt_phoothane.Visible = False
    '    txt_samakom.Visible = True
    '    txt_moolniti.Visible = False
    'End Sub

    'Protected Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
    '    txt_kom.Visible = False
    '    txt_thabuang.Visible = False
    '    txt_krathrwng.Visible = False
    '    txt_phoothane.Visible = False
    '    txt_samakom.Visible = False
    '    txt_moolniti.Visible = True
    'End Sub

    Protected Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        txt_kom.Visible = False
        txt_thabuang.Visible = False
        txt_krathrwng.Visible = False
        'txt_phoothane.Visible = False
        'txt_samakom.Visible = False
        'txt_moolniti.Visible = False
    End Sub

    Protected Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        txt_kom.Visible = False
        txt_thabuang.Visible = False
        txt_krathrwng.Visible = False
        'txt_phoothane.Visible = False
        'txt_samakom.Visible = False
        'txt_moolniti.Visible = False
    End Sub
End Class