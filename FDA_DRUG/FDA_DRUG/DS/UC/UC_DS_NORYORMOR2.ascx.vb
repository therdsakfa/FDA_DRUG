Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI

Public Class UC_DS_NORYORMOR2
    Inherits System.Web.UI.UserControl
    Private _CLS As CLS_SESSION
    Public _process As String = "1027"
    Private _lct_ida As Integer
    Private _lcnno As String

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                Try
                    _lcnno = Request("lcnno").ToString()
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim cls_session As New CLS_SESSION
        cls_session.IDA = txt_secrch.Text
        cls_session.GROUPS = "NORYORMOR"
        cls_session.PVCODE = "2"
        Session.Add("product_id", cls_session)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        RunSession()
        If Not IsPostBack Then
            'bind_ddl_unit()
            bind_ddl_size()
            txt_WRITE_DATE.Text = Date.Now.ToShortDateString
            If Not _lcnno Is Nothing Then
                txt_secrch.Text = _lcnno
                set_label(_lcnno)
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(lcnno As Integer)
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        Try
            dt = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(lcnno)
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt

        RadGrid1.Rebind()
    End Sub

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

        Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
        dao_drugname.GetDataby_product(lcnno_display)
        If IsNothing(dao_drugname.fields.RCVNO_DISPLAY) Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบเลขบัญชีรายการยา');", True)
        Else
            lbl_drugthanm.Text = dao_drugname.fields.DRUG_NAME_THAI '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
            lbl_drugengnm.Text = dao_drugname.fields.DRUG_NAME_OTHER
            lbl_nature.Text = dao_drugname.fields.DRUG_COLOR

            Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            dao_package.GetDataby_FK_IDA(dao_drugname.fields.IDA)

            Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
            unit_physic.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
            lbl_unitnm.Text = unit_physic.fields.unit_name
            lbl_unite_ida.Text = dao_package.fields.SMALL_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
            lbl_size_5.Text = unit_physic.fields.unit_name

            '--------------------------------------------------------------------------------------

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_drugname.fields.FK_IDA)

            lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

            lbl_number.Text = dao_lcn.fields.LOCATION_ADDRESS_thaaddr            'ที่อยู่
            lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
            lbl_lane.Text = dao_lcn.fields.LOCATION_ADDRESS_thasoi               'ซอย
            lbl_road.Text = dao_lcn.fields.LOCATION_ADDRESS_tharoad              'ถนน
            lbl_village_no.Text = dao_lcn.fields.LOCATION_ADDRESS_thamu       'หมู่
            lbl_sub_district.Text = dao_lcn.fields.LOCATION_ADDRESS_thathmblnm   'ตำบล
            lbl_district.Text = dao_lcn.fields.LOCATION_ADDRESS_thaamphrnm       'อำเภอ
            lbl_province.Text = dao_lcn.fields.LOCATION_ADDRESS_thachngwtnm      'จังหวัด
            lbl_tel.Text = dao_lcn.fields.tel            'เบอร์โทร

            Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
            Try
                dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd)
                lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
            Catch ex As Exception

            End Try

            Dim dao_lo_bsn As New DAO_CPN.TB_LOCATION_BSN
            Try
                dao_lo_bsn.Getdata_by_bsnid(dao_lcn.fields.bsnid)
                Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
                dao_prefix2.Getdata_byid(dao_lo_bsn.fields.BSN_PREFIXTHAICD)
                lbl_bsn_prefixed.Text = dao_prefix2.fields.thaabbr
            Catch ex As Exception

            End Try

            lbl_bsn_name.Text = dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ
            If IsNothing(dao_lcn.fields.BSN_THAIFULLNAME) Then
                lbl_bsn_name.Text = dao_lo_bsn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ
            End If

            Dim baophr As New BAO.ClsDBSqlcommand
            ddl_snunit.DataSource = baophr.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(dao_drugname.fields.IDA)
            ddl_snunit.DataTextField = "unit_name"
            ddl_snunit.DataValueField = "SMALL_UNIT"
            ddl_snunit.DataBind()
            Dim item2 As New ListItem
            item2.Text = "เลือกหน่วยนับตามรูปแบบยา"
            item2.Value = "0"
            ddl_snunit.Items.Insert(0, item2)

            'ดึงตัวยาสำคัญ
            RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
            'ขนาดบรรจุ
            'chk_active_package(lcnno_display)
            RadGrid2_NeedDataSource(dao_drugname.fields.IDA)
            Size_Radgrid(dao_drugname.fields.IDA)
            package(dao_drugname.fields.IDA)
            imp_detail(dao_drugname.fields.IDA)
            txt_main_ida.Text = dao_drugname.fields.IDA
        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        'If TypeOf e.Item Is GridDataItem Then
        '    Dim item As GridDataItem = e.Item
        '    If e.CommandName = "del" Then
        '        Dim dao_drungname As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        '        dao_drungname.GetDataby_IDA(item("IDA").Text)

        '        Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        '        dao.GetDataby_IDA(item("IDA").Text)
        '        dao.delete()
        '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
        '        imp_detail(dao_drungname.fields.FK_IDA)
        '        Size_Radgrid(dao_drungname.fields.IDA)
        '    End If
        'End If
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                'dao.GetDataAll()
                dao.fields.CHECK_PACKAGE = Nothing
                dao.fields.IM_DETAIL = Nothing
                dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid2_NeedDataSource(txt_main_ida.Text)
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
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As DataTable = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA(ida)

        'RadGrid2.DataSource = dt
        RadGrid2.Rebind()
    End Sub

    Protected Sub ddl_size6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_size6.SelectedIndexChanged
        lbl_size_m.Text = ddl_size6.SelectedItem.Text
        sum()
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txt_secrch.Text = "" And _lcnno Is Nothing Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาดึงข้อมูลเลขบัญชีรายการยา');", True)
        Else
            If txt_WRITE_AT.Text = "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเขียนที่');", True)
            Else
                If txt_rank.Text = "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกตำแหน่งชื่อผู้รับอนุญาต');", True)
                Else
                    If CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกในนาม');", True)
                    Else
                        If txt_imp.Text = "" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาบันทึกผลิตภัณฑ์ที่ต้องการนำเข้า');", True)
                        Else
                            save()
                            Dim get_session As CLS_SESSION = Session("product_id")

                            If get_session.PVCODE = "2" Then
                                Response.Write("<script type langue =javascript>")
                                Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1027 & "';")
                                Response.Write("</script type >")
                            ElseIf get_session.PVCODE = "3" Then
                                Response.Write("<script type langue =javascript>")
                                Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1028 & "';")
                                Response.Write("</script type >")
                            ElseIf get_session.PVCODE = "4" Then
                                Response.Write("<script type langue =javascript>")
                                Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1029 & "';")
                                Response.Write("</script type >")
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' เลือกขนาดบรรจุ
    ''' </summary>
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
    Private Sub RadGrid2_NeedDataSource(fk_ida As Integer)
        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL

        dao_package.GetDataby_FK_IDA2(fk_ida)
        'For Each dao_package.fields In dao_package.datas
        'Next
        RadGrid2.DataSource = dao_package.datas
        RadGrid2.Rebind()
    End Sub
    'เพิ่มขนาดบรรจุ
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If txt_barcode.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกหมายเลขบาร์โค้ด');", True)
        ElseIf txt_package_name.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกชื่อขนาดบรรจุ');", True)
            'ElseIf ddl_snunit.SelectedValue = 0 Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกหน่วยนับตามรูปแบบยา');", True)
        Else

            Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
            Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
            dao_drugname.GetDataby_product(txt_secrch.Text)
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.SMALL_UNIT = lbl_unite_ida.Text   'เลือกขนาดของหน่วยเล็ก
            Catch ex As Exception

            End Try
            Try
                dao.fields.MEDIUM_UNIT = ddl_size6.SelectedValue  'เลือกขนาดของหน่วยกลาง
            Catch ex As Exception

            End Try
            Try
                If ddl_size4.SelectedValue <> 0 Then
                    dao.fields.BIG_UNIT = ddl_size4.SelectedValue     'เลือกขนาดของหน่วยใหญ่
                Else
                    dao.fields.BIG_UNIT = ddl_size6.SelectedValue     'เลือกขนาดของหน่วยใหญ่
                End If
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = dao_drugname.fields.IDA
            dao.fields.SMALL_AMOUNT = txt_size1.Text         'จำนวนขนาดบรรจุเล็ก

            Try
                dao.fields.MEDIUM_AMOUNT = txt_size3.Text        'จำนวนขนาดบรรจุกลาง
            Catch ex As Exception
                dao.fields.MEDIUM_AMOUNT = 1
            End Try

            dao.fields.BARCODE = txt_barcode.Text
            dao.fields.PACKAGE_NAME = txt_package_name.Text    'ชื่อขนาดบรรจุ
            dao.insert()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)

            Size_Radgrid(dao_drugname.fields.IDA)
            package(dao_drugname.fields.IDA)

        End If

    End Sub

    ''' <summary>
    ''' gen xml หลังกดบันทึก
    ''' </summary>
    Sub save()

        Dim save As New DAO_DRUG.ClsDBdrsamp

        'chk_package()

        save.fields.WRITE_AT = txt_WRITE_AT.Text
        save.fields.WRITE_DATE = Date.Now

        Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
        dao_drugname.GetDataby_product(txt_secrch.Text)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao_drugname.fields.FK_IDA)

        save.fields.lcnno = dao_lcn.fields.IDA
        save.fields.lcn = dao_lcn.fields.lcnno
        save.fields.lcnsid = dao_lcn.fields.lcnsid
        save.fields.pvncd = dao_lcn.fields.pvncd
        save.fields.PRODUCT_ID_IDA = dao_drugname.fields.IDA

        save.fields.RANK = txt_rank.Text

        Dim check As String = ""

        If chk_for1.Checked = True Then

            check = chk_for1.ID.ToString.Substring(7, 1)
            save.fields.CHK_PERMISSION_REQUEST = check

        ElseIf chk_for2.Checked = True Then

            check = chk_for2.ID.ToString.Substring(7, 1)
            save.fields.CHK_PERMISSION_REQUEST = check

        End If


        If CheckBox1.Checked = True Then
            save.fields.IN_NAME = "1"
            save.fields.krasuang = department.Text
        ElseIf CheckBox2.Checked = True Then
            save.fields.IN_NAME = "2"
            save.fields.tabuang = txt_thabuang.Text
        ElseIf CheckBox3.Checked = True Then
            save.fields.IN_NAME = "3"
            save.fields.kom = kom.Text
        ElseIf CheckBox4.Checked = True Then
            save.fields.IN_NAME = "4"
        ElseIf CheckBox5.Checked = True Then
            save.fields.IN_NAME = "5"
        ElseIf CheckBox6.Checked = True Then
            save.fields.IN_NAME = "6"
        ElseIf CheckBox7.Checked = True Then
            save.fields.IN_NAME = "7"
        End If

        save.fields.lcntpcd = "นยม2"

        save.fields.thadrgnm = lbl_drugthanm.Text
        save.fields.engdrgnm = lbl_drugengnm.Text

        Dim dao_pac As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_pac.GetDataby_FK_IDA(dao_drugname.fields.IDA)
        Dim qty As Integer = 0

        For Each dao_pac.fields In dao_pac.datas
            If dao_pac.fields.CHECK_PACKAGE = True Then
                If qty = 0 Then
                    qty = dao_pac.fields.SUM
                Else
                    qty = qty + dao_pac.fields.SUM
                End If
            End If
        Next

        save.fields.QUANTITY = qty
        save.fields.QUANTITY_UNIT = CInt(lbl_unite_ida.Text)
        save.fields.CITIZEN_SUBMIT = _CLS.CITIZEN_ID

        save.insert()

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)

        xml(save.fields.IDA)

        'Response.Redirect("DOWNLOAD_PDF.aspx")

        'Response.Write("window.location.href = 'DOWNLOAD_PDF.aspx';")

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

    Sub xml(ByVal drsamp_ida As Integer)
        Dim bao2 As New BAO.AppSettings
        bao2.RunAppSettings()

        Dim get_session As CLS_SESSION = Session("product_id")

        Dim cls_xml As New CLASS_DRSAMP

        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_product(txt_secrch.Text)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand

        Dim paths As String = bao2._PATH_DEFAULT

        Dim file_template As String = ""
        Dim process As String = ""

        If get_session.PVCODE = "2" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORMOR2.pdf"
            process = "1027"
        ElseIf get_session.PVCODE = "3" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORMOR3.pdf"
            process = "1028"
        ElseIf get_session.PVCODE = "4" Then
            file_template = paths & "PDF_TEMPLATE\PDF_DRUG_NORYORMOR4.pdf"
            process = "1029"
        End If
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process                                       ' ชื่อ Process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID                               ' รับค่าจากเทเบิ้ล บัตรประชาชน
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE           ' รับ ชื่อประกอบการ
        dao_down.fields.STATUS = STATUS                                             ' รับเก็บค่า STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE                               ' เวลา
        dao_down.insert()                                                           ' insert ค่าข้างบน
        down_ID = dao_down.fields.ID

        'Dim path_XML As String = paths & "XML_TRADER_DOWNLOAD\ " & process & " Product_ID_" + dao.fields.RCVNO_DISPLAY + ".xml"
        'Dim file_PDF As String = paths & "PDF_TRADER_DOWNLOAD\ " & process & " Product_ID_" + dao.fields.RCVNO_DISPLA + ".pdf"

        Dim path_XML As String = paths & "XML_TRADER_DOWNLOAD\" & "DA-" & process & "-" & down_ID & ".xml"
        Dim file_PDF As String = paths & "PDF_TRADER_DOWNLOAD\ " & "DA-" & process & "-" & down_ID & ".pdf"

        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_IDA(Convert.ToInt32(drsamp_ida))


        cls_xml = GEN_XML()
        Dim write_date As Date = dao_drsamp.fields.WRITE_DATE
        dao_drsamp.fields.WRITE_DATE = DateAdd(DateInterval.Year, 543, write_date)
        cls_xml.drsamp = dao_drsamp.fields  'ใบนยม
        cls_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(dao.fields.IDA) 'ดึงบัญชีรายการยา
        cls_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(dao.fields.FK_IDA)    'ข้อมูลที่อยู่สถาณที่
        cls_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(dao.fields.IDA) 'ดึงตัวยาสำคัญ
        cls_xml.DT_SHOW.DT3.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
        cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.IDA)    'ขนาดบรรจุ
        'cls_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(dao.fields.IDA) 'ใบนยม
        'cls_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM2(dao.fields.IDA) 'เก็บตกหล่น
        cls_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(dao.fields.IDA) 'ดึงตัวยาสำคัญ
        cls_xml.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
        cls_xml.DT_SHOW.DT8 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.IDA)    'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        Catch ex As Exception

        End Try

        Dim dao_pac As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_pac.GetDataby_FK_IDA(dao.fields.IDA)
        Dim sum As String = ""

        For Each dao_pac.fields In dao_pac.datas
            If dao_pac.fields.CHECK_PACKAGE = True Then
                If sum <> "" Then
                    sum = sum & ", "
                    sum = sum & dao_pac.fields.IM_DETAIL
                Else
                    sum = dao_pac.fields.IM_DETAIL
                End If
            End If
        Next

        Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
        unit_physic.GetDataby_sunitcd(CInt(lbl_unite_ida.Text))

        cls_xml.IMPORT_AMOUNTS = dao_drsamp.fields.QUANTITY & " " & unit_physic.fields.unit_name

        Dim objStreamWriter As New StreamWriter(path_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        convert_XML_To_PDF(file_PDF, path_XML, file_template)

        Dim pdf_name As String = process + "-" + down_ID
        'Dim pdf_name As String = process + "-" + get_session.IDA

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", pdf_name)

        Session("CLS") = _CLS

        LoadPdf()

    End Sub

    Public Function GEN_XML() As CLASS_DRSAMP
        Dim class_xml As New CLASS_DRSAMP

        Return class_xml

    End Function

    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
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
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('Download เสร็จสิ้น');", True)
    End Sub

    Protected Sub Button2_Click1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim get_session As CLS_SESSION = Session("product_id")

        If get_session.PVCODE = "2" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1027 & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "3" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1028 & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "4" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1029 & "';")
            Response.Write("</script type >")
        End If
    End Sub

    Private Sub txt_qty_TextChanged(sender As Object, e As EventArgs) Handles txt_qty.TextChanged
        sum()
    End Sub

    Sub sum()
        Try
            Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)

            Dim sum As Integer = 0
            sum = CInt(dao_package.fields.SMALL_AMOUNT) * CInt(dao_package.fields.MEDIUM_AMOUNT)
            sum = sum * CInt(txt_qty.Text)

            lbl_import_sum.Text = "( " & sum & " " & lbl_unitnm.Text & ")"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_package_Click(sender As Object, e As EventArgs) Handles btn_package.Click

        'If Label2.Text = "on" Then
        '    Label2.Text = "off"
        '    package2.Style.Add("display", "in-line")
        '    package3.Style.Add("display", "in-line")
        'Else
        '    Label2.Text = "on"
        '    package2.Style.Add("display", "none")
        '    package3.Style.Add("display", "none")
        '    Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION 'ชื่อยา
        '    dao_drugname.GetDataby_product(txt_secrch.Text)
        '    Size_Radgrid(dao_drugname.fields.IDA)
        'End If

        Response.Redirect("../DS/FRM_DS_DRUG8_ADD.aspx?main_ida=" & txt_main_ida.Text & "&process=" & _process & "&write_at=" & txt_WRITE_AT.Text & "&lcnno=" & txt_secrch.Text)
    End Sub

    Sub package(ByVal fk_ida As Integer)
        'Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        'Dim item As New ListItem("---เลือกขนาดบรรจุ---", "0")
        'dao_package.GetDataby_FK_IDA(fk_ida)
        'ddl_package_unit.DataSource = dao_package.datas
        'ddl_package_unit.DataTextField = "PACKAGE_NAME"
        'ddl_package_unit.DataValueField = "IDA"
        'ddl_package_unit.DataBind()
        'ddl_package_unit.Items.Insert(0, item)
        Dim item As New ListItem("---เลือกขนาดบรรจุ---", "0")
        Dim bao As New BAO.ClsDBSqlcommand
        ddl_package_unit.DataSource = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA_add(fk_ida)
        ddl_package_unit.DataTextField = "small_sum"
        ddl_package_unit.DataValueField = "IDA"
        ddl_package_unit.DataBind()
        ddl_package_unit.Items.Insert(0, item)
    End Sub

    Protected Sub ddl_package_unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_package_unit.SelectedIndexChanged
        'Try
        '    Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        '    dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
        '    Dim dao_mas_unit As New DAO_DRUG.TB_MAS_UNIT_CONTAIN
        '    dao_mas_unit.GetDataby_IDA(dao_package.fields.BIG_UNIT)
        '    imp_unit.Text = dao_mas_unit.fields.unitnm
        'Catch ex As Exception
        '    imp_unit.Text = ""
        'End Try
        Try
            Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
            Dim dao_mas_unit As New DAO_DRUG.TB_drsunit
            dao_mas_unit.GetDataby_sunitcd(dao_package.fields.BIG_UNIT)
            imp_unit.Text = dao_mas_unit.fields.sunitengnm
        Catch ex As Exception
        End Try
        sum()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
        Dim dao_mas_unit As New DAO_DRUG.TB_drsunit
        dao_mas_unit.GetDataby_sunitcd(dao_package.fields.MEDIUM_UNIT)
        Dim dao_mas_unit1 As New DAO_DRUG.TB_drsunit
        dao_mas_unit1.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
        Dim dao_mas_unit2 As New DAO_DRUG.TB_drsunit
        dao_mas_unit2.GetDataby_sunitcd(dao_package.fields.BIG_UNIT)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(txt_main_ida.Text)
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_package.fields.FK_IDA)
        '   dao_package.fields.FK_IDA = dao_drsamp.fields.IDA
        If dao_package.fields.CHECK_PACKAGE = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ขนาดบรรจุนี้ มีปริมาณที่จะผลิต/นำสั่งแล้ว');", True)
        Else
            dao_package.fields.IM_QTY = CInt(txt_qty.Text)
            Dim sum As Integer = CInt(dao_package.fields.SMALL_AMOUNT) * CInt(dao_package.fields.MEDIUM_AMOUNT)
            sum = sum * CInt(txt_qty.Text)
            dao_package.fields.SUM = sum
            dao_package.fields.IM_DETAIL = dao_package.fields.SMALL_AMOUNT & " " & dao_mas_unit1.fields.sunitthanm & " x " & dao_package.fields.MEDIUM_AMOUNT & " " & dao_mas_unit.fields.sunitthanm & " x " & dao_package.fields.BIG_AMOUNT & " " & dao_mas_unit2.fields.sunitthanm & " จำนวน " & txt_qty.Text & " " & dao_mas_unit.fields.sunitengnm & " (" & sum & " " & lbl_unitnm.Text & ")"
            dao_package.fields.CHECK_PACKAGE = 1
            dao_package.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
            RadGrid2_NeedDataSource(dao_package.fields.FK_IDA)
        End If
        'Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        'dao_package.GetDataby_IDA(ddl_package_unit.SelectedValue)
        'Dim dao_mas_unit As New DAO_DRUG.TB_MAS_UNIT_CONTAIN
        'dao_mas_unit.GetDataby_IDA(dao_package.fields.BIG_UNIT)
        'Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        'dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_package.fields.FK_IDA)
        'dao_package.fields.DRSAMP_IDA = dao_drsamp.fields.IDA
        'If dao_package.fields.CHECK_PACKAGE = True Then
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ขนาดบรรจุนี้ มีปริมาณที่จะผลิต/นำสั่งแล้ว');", True)
        'Else
        '    dao_package.fields.IM_QTY = CInt(txt_qty.Text)
        '    Dim sum As Integer = CInt(dao_package.fields.SMALL_AMOUNT) * CInt(dao_package.fields.MEDIUM_AMOUNT)
        '    sum = sum * CInt(txt_qty.Text)
        '    dao_package.fields.SUM = sum
        '    dao_package.fields.IM_DETAIL = ddl_package_unit.SelectedItem.Text & " นำเข้า " & txt_qty.Text & " " & dao_mas_unit.fields.unitnm & " (" & sum & " " & lbl_unitnm.Text & ")"
        '    dao_package.fields.CHECK_PACKAGE = 1
        '    dao_package.update()
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        '    imp_detail(dao_package.fields.FK_IDA)
        'End If
        'RadGrid2.Rebind()
    End Sub

    Sub imp_detail(ByVal fk_ida As Integer)
        'Dim dao_package As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        'dao_package.GetDataby_FK_IDA(fk_ida)
        'txt_imp.Text = ""
        'For Each dao_package.fields In dao_package.datas
        '    If dao_package.fields.CHECK_PACKAGE = True Then
        '        If txt_imp.Text = "" Then
        '            txt_imp.Text = dao_package.fields.IM_DETAIL
        '        Else
        '            txt_imp.Text = txt_imp.Text & "<br/>" & dao_package.fields.IM_DETAIL
        '        End If
        '    Else

        '    End If
        'Next
        Dim dao_package As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_package.GetDataby_IDA(fk_ida)
        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
        Try
            dao_unit.GetDataby_sunitcd(dao_package.fields.UNIT_NORMAL)
            txt_imp.Text = dao_unit.fields.short_unit
        Catch ex As Exception
        End Try
    End Sub

    Sub chk_active_package(ByVal lcn_dis As String)
        Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
        dao_drugname.GetDataby_product(lcn_dis)
        'Dim pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        Dim pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        pack.GetData_chk_by_FK_IDA(dao_drugname.fields.IDA)

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

    Protected Sub ddl_snunit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_snunit.SelectedIndexChanged
        lbl_unite_ida.Text = ddl_snunit.SelectedValue    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
        lbl_unitnm.Text = ddl_snunit.SelectedItem.Text 'หน่วยนับตามรูปแบบยา
        lbl_size_5.Text = ddl_snunit.SelectedItem.Text 'หน่วยของขนาดบรรจุ
    End Sub
End Class