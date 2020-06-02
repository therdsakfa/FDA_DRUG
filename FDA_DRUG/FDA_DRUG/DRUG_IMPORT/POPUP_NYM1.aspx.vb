Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_NYM1
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Private _lcn_ida As String
    Private _lct_ida As String
    Private _IDA As String

    Sub runQuery()
        _Process = "1026"
        _IDA = Request("IDA").ToString()
        _lcn_ida = Request("lcn_ida").ToString()
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        runQuery()
        RunSession()
        If Not IsPostBack Then
            get_data()
        End If
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    If DropDownList1.SelectedIndex = 0 Then
    '        alert("กรุณาเลือกโครงการวิจัย")
    '    Else
    '        Dim bao_app As New BAO.AppSettings
    '        bao_app.RunAppSettings()

    '        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
    '        Dim down_ID As Integer


    '        Dim STATUS As String = 0
    '        Dim DOWNLOAD_DATE As Date = Date.Now()
    '        dao_down.fields.PROCESS_ID = _Process
    '        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
    '        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '        dao_down.fields.STATUS = STATUS
    '        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
    '        dao_down.insert()
    '        down_ID = dao_down.fields.ID

    '        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_Process, 0, 0)


    '        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE
    '        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)
    '        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)

    '        convert_Database_To_XML(file_xml)
    '        convert_XML_To_PDF(file_PDF, file_xml, file_template)

    '        _CLS.FILENAME_PDF = file_PDF
    '        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)

    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    '    End If

    'End Sub

    Private Sub convert_Database_To_XML(ByVal path As String)

        Dim bao As New BAO.ClsDBSqlcommand

        Dim class_xml As New CLASS_PROJECT_SUM

        Dim dao2 As New DAO_DRUG.ClsDBdalcn
        dao2.GetDataby_IDA(_CLS.LCNNO)
        Dim dao_pjsum As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao_pjsum.GetDataby_IDA(DropDownList1.SelectedItem.Value)
        class_xml.DRUG_PROJECT_SUMMARY = dao_pjsum.fields

        Dim dao_fac As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
        dao_fac.GetDataby_PROJECT(DropDownList1.SelectedItem.Value)
        For Each dao_fac.datas In dao_fac.datas
            class_xml.DRUG_PROJECT_RESEARCH_FACILITYS.Add(dao_fac.datas)
        Next

        Dim dao_lab As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
        dao_lab.GetDataby_PROJECT(DropDownList1.SelectedItem.Value)
        For Each dao_lab.datas In dao_lab.datas
            class_xml.DRUG_PROJECT_CLINICAL_LABORATORYS.Add(dao_lab.datas)
        Next

        Dim dao_dl As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao_dl.GetDataby_PROJECT(DropDownList1.SelectedItem.Value)
        For Each dao_dl.datas In dao_dl.datas
            class_xml.DRUG_PROJECT_DRUG_LISTS.Add(dao_dl.datas)
        Next

        Dim bao_master As New BAO_MASTER
        class_xml.drsamp.pvncd = dao2.fields.pvncd
        class_xml.drsamp.lcntpcd = "นยม1"
        class_xml.drsamp.lcn = dao2.fields.lcnno
        class_xml.drsamp.lcnno = dao2.fields.IDA
        class_xml.drsamp.lcnsid = dao2.fields.lcnsid
        class_xml.drsamp.lcnscd = dao2.fields.lcnscd
        class_xml.drsamp.lctnmcd = dao2.fields.lctnmcd
        class_xml.drsamp.lctcd = dao2.fields.lctcd
        class_xml.dalcns = dao2.fields
        class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(DropDownList1.SelectedItem.Value, 3)
        class_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(DropDownList1.SelectedItem.Value, 4)

        'class_xml.drsamp.IN_NAME = 3
        'class_xml.drsamp.RANK = "ทดลอง"
        'class_xml.drsamp.CHK_PERMISSION_REQUEST = 1
        'class_xml.drsamp.krasuang = "krasuang"
        'class_xml.drsamp.tabuang = "tabuang"
        'class_xml.drsamp.kom = "kom"
        'class_xml.drsamp.pootane = "pootane"
        'class_xml.drsamp.samakom = "samakom"
        'class_xml.drsamp.moolniti = "moolniti"

        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(dao_pjsum.fields.CITIZEN)
        'ชื่อบริษัท
        class_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(dao_pjsum.fields.CITIZEN_AUTHORIZE)

        class_xml.LCNNO_SHOWS = dao2.fields.LCNNO_DISPLAY

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(class_xml.GetType)
        x.Serialize(objStreamWriter, class_xml)
        objStreamWriter.Close()

    End Sub

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim clsds As New ClassDataset
    '    Response.Clear()
    '    Response.ContentType = "Application/pdf"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
    '    Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
    '    Response.Flush()
    '    Response.Close()
    '    Response.End()
    'End Sub

    Sub get_data()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao.GetDataby_PROJECT(_IDA)

        Dim item As New ListItem("รายการยา", "0")

        DropDownList1.DataSource = dao.datas
        DropDownList1.DataTextField = "tradenm"
        DropDownList1.DataValueField = "IDA"
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, item)

        Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
        dao_dalcn.GetDataby_IDA(_lcn_ida)

        lbl_lcnno2.Text = dao_dalcn.fields.LCNNO_DISPLAY
        lbl_place_name.Text = dao_dalcn.fields.thanameplace
        lbl_bsn_prefixed.Text = dao_dalcn.fields.BSN_THAIFULLNAME
        lbl_number.Text = dao_dalcn.fields.LOCATION_ADDRESS_thaaddr
        lbl_place_name.Text = dao_dalcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
        lbl_lane.Text = dao_dalcn.fields.LOCATION_ADDRESS_thasoi               'ซอย
        lbl_road.Text = dao_dalcn.fields.LOCATION_ADDRESS_tharoad              'ถนน
        lbl_village_no.Text = dao_dalcn.fields.LOCATION_ADDRESS_thamu       'หมู่
        lbl_sub_district.Text = dao_dalcn.fields.LOCATION_ADDRESS_thathmblnm   'ตำบล
        lbl_district.Text = dao_dalcn.fields.LOCATION_ADDRESS_thaamphrnm       'อำเภอ
        lbl_province.Text = dao_dalcn.fields.LOCATION_ADDRESS_thachngwtnm      'จังหวัด
        lbl_tel.Text = dao_dalcn.fields.tel            'เบอร์โทร

        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid1.DataSource = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(_IDA, 5)
        RadGrid1.DataBind()

        Dim dao_nym1 As New DAO_DRUG.ClsDBDRUG_NORYORMOR1_IMPORT
        dao_nym1.GetDataby_PJSUM(_IDA)
        Dim times As Integer = 0
        Dim times2 As Integer = 0
        For Each dao_nym1.fields In dao_nym1.datas
            If dao_nym1.fields.TIMES > times Then
                times = dao_nym1.fields.TIMES
            End If
        Next

        times = times + 1

        hidden_times.Text = times

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        TextBox1.Text = ""
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao.GetDataby_IDA(DropDownList1.SelectedValue)

        Label1.Text = dao.fields.bunitnm
        'If IsNothing(dao.fields.nym1_imp) Or dao.fields.nym1_imp = 0 Then

        'Else
        '    TextBox1.Text = dao.fields.nym1_imp
        'End If
        calculate()
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        calculate()

    End Sub

    Sub calculate()
        Dim dao_quota As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao_quota.GetDataby_IDA(DropDownList1.SelectedValue)

        Try
            If DropDownList1.SelectedValue = 0 Then
                cal_q.Text = ""
            Else
                If TextBox1.Text = "0" Or TextBox1.Text = "" Then
                    cal_q.Text = ""
                Else
                    Dim cut_quota As Integer = 0
                    If CInt(TextBox1.Text) >= dao_quota.fields.imp_amount Then
                        cut_quota = 0
                        cal_q.Text = "ยา " & DropDownList1.SelectedItem.Text & " นำเข้าได้จำนวน " & dao_quota.fields.imp_amount & Space(1) & dao_quota.fields.bunitnm & "<br>เหลือโควต้านำเข้า " & cut_quota & Space(1) & dao_quota.fields.bunitnm & " จากโควต้านำเข้า " & dao_quota.fields.imp_amount & Space(1) & dao_quota.fields.bunitnm
                    Else
                        cut_quota = dao_quota.fields.imp_amount - CInt(TextBox1.Text)
                        cal_q.Text = "ยา " & DropDownList1.SelectedItem.Text & " นำเข้าจำนวน " & TextBox1.Text & Space(1) & dao_quota.fields.bunitnm & "<br>เหลือโควต้านำเข้า " & cut_quota & Space(1) & dao_quota.fields.bunitnm & " จากโควต้านำเข้า " & dao_quota.fields.imp_amount & Space(1) & dao_quota.fields.bunitnm
                    End If
                End If
            End If

        Catch ex As Exception
            cal_q.Text = "เกิดการคำนวนผิดผลาด ไม่สามารถคำนวนได้ กรุณาตรวจสอบสำนวนนำเข้า"
        End Try


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim dao2 As New DAO_DRUG.ClsDBdalcn
        dao2.GetDataby_IDA(_lcn_ida)
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        dao.fields.pvncd = dao2.fields.pvncd
        dao.fields.lcntpcd = "นยม1"
        dao.fields.lcn = dao2.fields.lcnno
        dao.fields.lcnno = dao2.fields.IDA
        dao.fields.lcnsid = dao2.fields.lcnsid
        dao.fields.lcnscd = dao2.fields.lcnscd
        dao.fields.lctnmcd = dao2.fields.lctnmcd
        dao.fields.lctcd = dao2.fields.lctcd
        dao.fields.rcvdate = Date.Now
        dao.fields.STATUS_ID = 1
        dao.fields.PJSUM_IDA = _IDA

        dao.insert()

        Dim dao_n As New DAO_DRUG.ClsDBDRUG_NORYORMOR1_IMPORT
        dao_n.GetDataby_TIMES(_IDA, CInt(hidden_times.Text))
        For Each dao_n.fields In dao_n.datas
            dao_n.fields.FK_IDA = dao.fields.IDA
            dao_n.update()
        Next

        'ตัดโควต้า
        'Dim dao_quota As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        'dao_quota.GetDataby_PROJECT(_IDA)
        'For Each dao_quota.fields In dao_quota.datas
        '    Dim cut_quota As Integer = 0
        '    If dao_quota.fields.nym1_imp >= dao_quota.fields.imp_amount Then
        '        cut_quota = 0
        '    Else
        '        cut_quota = dao_quota.fields.imp_amount - dao_quota.fields.nym1_imp
        '    End If
        '    dao_quota.fields.quota_left = cut_quota
        '    dao_quota.update()
        'Next

        alert("ยื่นคำขอ นยม1 เรียบร้อย")

        'show_message()

        Button2.Visible = False
        cal_q.Text = ""
        imp.Style.Add("display", "none")
        Label2.Text = "<h2>ยื่นคำขอ นยม1 เรียบร้อย</h2>"

    End Sub

    Sub show_message()
        Dim dao_quota As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao_quota.GetDataby_PROJECT(_IDA)
        Dim dao_n As New DAO_DRUG.ClsDBDRUG_NORYORMOR1_IMPORT
        dao_n.GetDataby_TIMES(_IDA, CInt(hidden_times.Text))


        For Each dao_quota.fields In dao_quota.datas
            If Label2.Text = "" Then
                Label2.Text = "ยา " & dao_quota.fields.tradenm & " นำเข้าจำนวน " & dao_n.fields.IMP_AMOUNT & Space(1) & dao_quota.fields.bunitnm & "<br>เหลือโควต้านำเข้า " & dao_quota.fields.quota_left & Space(1) & dao_quota.fields.bunitnm
            Else
                Label2.Text = Label2.Text & "<br><br>ยา " & dao_quota.fields.tradenm & " นำเข้าจำนวน " & dao_n.fields.IMP_AMOUNT & Space(1) & dao_quota.fields.bunitnm & "<br>เหลือโควต้านำเข้า " & dao_quota.fields.quota_left & Space(1) & dao_quota.fields.bunitnm
            End If
        Next

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(TextBox1.Text) Or TextBox1.Text = 0 Then
            alert("กรุณากรอกจำนวนนำเข้า")
        Else
            Dim dao_nym As New DAO_DRUG.ClsDBDRUG_NORYORMOR1_IMPORT
            dao_nym.GetDataby_NAME(_IDA, CInt(hidden_times.Text), DropDownList1.SelectedItem.Text)
            If IsNothing(dao_nym.fields.DRUG_NAME) Then

                Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
                dao.GetDataby_IDA(DropDownList1.SelectedValue)

                dao_nym = New DAO_DRUG.ClsDBDRUG_NORYORMOR1_IMPORT

                If CInt(TextBox1.Text) >= dao.fields.IMP_AMOUNT Then 'ถ้าจำนวนที่กรอกมากกว่าจำนวนโควต้า
                    dao_nym.fields.IMP_AMOUNT = dao.fields.IMP_AMOUNT
                Else
                    dao_nym.fields.IMP_AMOUNT = CInt(TextBox1.Text)
                End If
                dao_nym.fields.PJ_SUM = _IDA
                dao_nym.fields.TIMES = CInt(hidden_times.Text)
                dao_nym.fields.DRUG_NAME = DropDownList1.SelectedItem.Text
                dao_nym.insert()
                alert("บันทึกเรียบร้อย")
            Else
                alert("ยานี้ได้ระบุจำนวนนำเข้าไปแล้ว")
            End If
        End If
    End Sub

    'Sub ddl_pack()
    '    Dim bao As New BAO_MASTER

    '    Dim item As New ListItem("เลือกบัญชีรายการยาเพื่อทำขนาดบรรจุ", "0")

    '    DropDownList2.DataSource = bao.SP_DRUG_PRODUCT_ID_BY_PJSUM(DropDownList1.SelectedValue, 1)
    '    DropDownList2.DataTextField = "productnm"
    '    DropDownList2.DataValueField = "PID_IDA"
    '    DropDownList2.DataBind()
    '    DropDownList2.Items.Insert(0, item)
    'End Sub

    'Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
    '    ddl_pack()
    'End Sub

    'Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
    '    txt_size1.Text = ""
    '    txt_size3.Text = ""
    '    txt_package_name.Text = ""
    '    txt_barcode.Text = ""
    '    lbl_size_5.Text = ""
    '    lbl_size_m.Text = ""

    '    getdata()
    'End Sub

    'Sub getdata()
    '    Dim dao_pid As New DAO_DRUG.TB_DRUG_PRODUCT_ID
    '    dao_pid.GetDataby_IDA(DropDownList2.SelectedValue)
    '    lbl_pidfkida.Text = dao_pid.fields.FK_IDA 'เก็บค่า fk_ida ของ product_id

    '    Dim dao_u As New DAO_DRUG.TB_DRUG_UNIT
    '    dao_u.GetDataby_IDA(dao_pid.fields.PHYSIC_UNIT)
    '    lbl_unite_ida.Text = dao_u.fields.IDA 'เก็บค่า ida ของขนาดเล็กสุด
    '    lbl_size_5.Text = dao_u.fields.unit_name

    '    Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
    '    dao.GetDataby_FK_IDA_AND_PROCESS(DropDownList2.SelectedValue)
    '    If IsNothing(dao.fields.create_from_process) Then 'ยังไม่มีขนาดบรรจุ
    '        get_unit()
    '        btn_add.Visible = True

    '    Else 'ถ้ามีขนาดบรรจุแล้วให้ดึงค่ามาโชว์
    '        txt_size1.Text = dao.fields.SMALL_AMOUNT
    '        txt_size3.Text = dao.fields.MEDIUM_AMOUNT
    '        txt_package_name.Text = dao.fields.PACKAGE_NAME
    '        txt_barcode.Text = dao.fields.BARCODE
    '        Dim dao_um As New DAO_DRUG.TB_MAS_UNIT_CONTAIN
    '        dao_um.GetDataby_IDA(dao.fields.MEDIUM_UNIT)
    '        lbl_size_m.Text = dao_um.fields.unitnm
    '        get_unit()

    '        ddl_size4.SelectedValue = dao.fields.BIG_UNIT
    '        ddl_size6.SelectedValue = dao.fields.MEDIUM_UNIT
    '        btn_add.Visible = False

    '    End If

    'End Sub

    'Sub get_unit()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao.SP_MAS_UNIT_CONTAIN()

    '    Dim item As New ListItem("", "0")

    '    ddl_size6.DataSource = dt
    '    ddl_size6.DataTextField = "unitnm"
    '    ddl_size6.DataValueField = "unitcd2"
    '    ddl_size6.DataBind()

    '    ddl_size4.DataSource = dt
    '    ddl_size4.DataTextField = "unitnm"
    '    ddl_size4.DataValueField = "unitcd2"
    '    ddl_size4.DataBind()

    '    ddl_size4.Items.Insert(0, item)
    '    ddl_size6.Items.Insert(0, item)
    'End Sub

    'Protected Sub ddl_size6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_size6.SelectedIndexChanged
    '    lbl_size_m.Text = ddl_size6.SelectedItem.Text
    'End Sub

    'Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
    '    If txt_barcode.Text = "" Then
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกหมายเลขบาร์โค้ด');", True)
    '    ElseIf txt_package_name.Text = "" Then
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกชื่อขนาดบรรจุ');", True)
    '    Else

    '        Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
    '        Try 'ปุ่มเพิ่มขนาดบรรจุ
    '            dao.fields.SMALL_UNIT = lbl_unite_ida.Text   'เลือกขนาดของหน่วยเล็ก
    '            dao.fields.MEDIUM_UNIT = ddl_size6.SelectedValue  'เลือกขนาดของหน่วยกลาง
    '            If ddl_size4.SelectedValue <> 0 Then
    '                dao.fields.BIG_UNIT = ddl_size4.SelectedValue     'เลือกขนาดของหน่วยใหญ่
    '            Else
    '                dao.fields.BIG_UNIT = ddl_size6.SelectedValue     'เลือกขนาดของหน่วยใหญ่
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        dao.fields.FK_IDA = DropDownList2.SelectedValue
    '        dao.fields.SMALL_AMOUNT = txt_size1.Text         'จำนวนขนาดบรรจุเล็ก

    '        Try
    '            dao.fields.MEDIUM_AMOUNT = txt_size3.Text        'จำนวนขนาดบรรจุกลาง
    '        Catch ex As Exception
    '            dao.fields.MEDIUM_AMOUNT = 1
    '        End Try

    '        dao.fields.BARCODE = txt_barcode.Text
    '        dao.fields.PACKAGE_NAME = txt_package_name.Text    'ชื่อขนาดบรรจุ
    '        dao.fields.create_from_process = 1026   'นยม1
    '        dao.fields.PJ_SUM_IDA = DropDownList1.SelectedValue
    '        dao.insert()

    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)

    '    End If
    'End Sub
End Class