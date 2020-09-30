Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI

Public Class POPUP_RESEARCH_SUM_DL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Sub runQuery()
        _Process = "10261"
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
            clinic_section.Style.Add("display", "none")
            set_lbl()
        End If
    End Sub

    Sub set_lbl()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao.GetDataby_notuse(_CLS.CITIZEN_ID_AUTHORIZE)
        RadGrid2.DataSource = dao.Details

        blind_ddl_chngwt(DropDownList1)
        blind_ddl_chngwt(DropDownList2)
        blind_ddl_chngwt(DropDownList7)
        blind_ddl_chngwt(DropDownList8)
        blind_ddl_chngwt(DropDownList9)
        blind_ddl_chngwt(DropDownList11)

        blind_ddl_country(DropDownList6)
        blind_ddl_country(DropDownList4)
        blind_ddl_country(DropDownList5)
        blind_ddl_country(DropDownList10)
        blind_ddl_country(DropDownList3)


    End Sub

    Sub blind_ddl_chngwt(ByVal ddl As DropDownList)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim item As New ListItem("", "0")

        ddl.DataSource = bao.SP_SYSCHNGWT()
        ddl.DataTextField = "thachngwtnm"
        ddl.DataValueField = "chngwtcd"
        ddl.DataBind()

        ddl.Items.Insert(0, item)
    End Sub

    Sub blind_ddl_country(ByVal ddl As DropDownList)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim item As New ListItem("", "0")

        ddl.DataSource = bao.SP_SYSISOCNT()
        ddl.DataTextField = "thacntnm"
        ddl.DataValueField = "IDA"
        ddl.DataBind()

        ddl.Items.Insert(0, item)
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "text/xml"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    get_ddl(txt_thspons.Text, ddl_thspons)
    'End Sub

    'Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    get_ddl(txt_forspons.Text, ddl_forspons)
    'End Sub

    'Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    get_ddl(txt_monitor.Text, ddl_monitor)
    'End Sub

    'Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    '    get_ddl(txt_pm.Text, ddl_pm)
    'End Sub

    'Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    '    get_ddl(txt_dm.Text, ddl_dm)
    'End Sub

    'Protected Sub ddl_thspons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_thspons.SelectedIndexChanged
    '    getdata_totext(ddl_thspons, th_spon_group, th_spon_addr, th_spon_tel)
    'End Sub

    'Protected Sub ddl_forspons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_forspons.SelectedIndexChanged
    '    getdata_totext(ddl_forspons, for_spons_groupnm, for_spons_addr, for_spons_tel)
    'End Sub

    'Protected Sub ddl_monitor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_monitor.SelectedIndexChanged
    '    getdata_totext(ddl_monitor, monitor_group, monitor_addr, monitor_tel)
    'End Sub

    'Protected Sub ddl_pm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_pm.SelectedIndexChanged
    '    getdata_totext(ddl_pm, pm_group, pm_addr, pm_tel)
    'End Sub

    'Protected Sub ddl_dm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_dm.SelectedIndexChanged
    '    getdata_totext(ddl_dm, dm_group, dm_addr, dm_tel)
    'End Sub

    ''' <summary>
    ''' เพิ่ม product id ในสรุปย่อโครงการ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    'Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    '    Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
    '    dao.GetDataby_product(txt_drug.Text) 'ไม่พบ product id
    '    If IsNothing(dao.fields.LCNNO_DISPLAY) Then
    '        lbl_error.Visible = True
    '        lbl_error.Text = "ไม่พบบัญชีรายการยา " & txt_drug.Text
    '    Else
    '        lbl_error.Visible = False   'ปิดคำแสดง error
    '        If lbl_drug.Text = "" Then
    '            lbl_drug.Text = dao.fields.LCNNO_DISPLAY & " : " & dao.fields.TRADE_NAME & "/" & dao.fields.TRADE_NAME_ENG
    '        Else
    '            lbl_drug.Text = lbl_drug.Text & "<BR>" & dao.fields.LCNNO_DISPLAY & " : " & dao.fields.TRADE_NAME & "/" & dao.fields.TRADE_NAME_ENG
    '        End If

    '        If lbl_drug_id1.Text = "" Then  'เอาเลข product id มาต่อกันแล้วนำไปสปริทอัพเดทอีกที
    '            lbl_drug_id1.Text = txt_drug.Text
    '        Else
    '            lbl_drug_id1.Text = lbl_drug_id1.Text & "," & txt_drug.Text
    '        End If
    '    End If

    'End Sub

    ''' <summary>
    ''' ดึงข้อมูลค้นหา
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="ddl"></param>
    Sub get_ddl(ByVal name As String, ByVal ddl As DropDownList)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable = bao.SP_SEARCH_COMPANY(name)

        Dim item As New ListItem("", "0")

        ddl.DataSource = dt
        ddl.DataTextField = "thanm"
        ddl.DataValueField = "identify"
        ddl.DataBind()

        ddl.Items.Insert(0, item)
    End Sub

    Sub getdata_totext(ByVal ddl As DropDownList, ByVal tb_groubnm As TextBox,
                       ByVal tb_addr As TextBox, ByVal tb_tel As TextBox)

        Dim dao_nm As New DAO_CPN.clsDBsyslcnsnm
        Dim dao_addr As New DAO_CPN.clsDBsyslctaddr
        dao_nm.GetDataby_identify(ddl.SelectedValue)
        dao_addr.GetDataby_identify(ddl.SelectedValue)

        tb_groubnm.Text = ddl.SelectedItem.Text
        tb_addr.Text = dao_addr.fields.Fulladdr
        tb_tel.Text = dao_addr.fields.tel
    End Sub

    ''' <summary>
    ''' เก็บข้อมูลจากฐานกลางมาที่ตารางสรุปย่อโครงการ
    ''' </summary>
    ''' <param name="ida"></param>
    'Sub insert_form_cpn(ByVal ida As Integer)
    '    Dim dao_pjsum As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
    '    dao_pjsum.GetDataby_IDA(ida)

    '    Dim dao_nm As New DAO_CPN.clsDBsyslcnsnm
    '    Dim dao_addr As New DAO_CPN.clsDBsyslctaddr
    '    dao_nm.GetDataby_identify(ddl_thspons.SelectedValue)
    '    dao_addr.GetDataby_identify(ddl_thspons.SelectedValue)

    '    dao_pjsum.fields.th_spon_group = ddl_thspons.SelectedItem.Text
    '    dao_pjsum.fields.th_spon_addr = dao_addr.fields.Fulladdr
    '    dao_pjsum.fields.th_spon_tel = dao_addr.fields.tel

    '    Dim dao_nm2 As New DAO_CPN.clsDBsyslcnsnm
    '    Dim dao_addr2 As New DAO_CPN.clsDBsyslctaddr
    '    dao_nm2.GetDataby_identify(ddl_forspons.SelectedValue)
    '    dao_addr2.GetDataby_identify(ddl_forspons.SelectedValue)

    '    dao_pjsum.fields.for_spon_group = ddl_forspons.SelectedItem.Text
    '    dao_pjsum.fields.for_spon_addr = dao_addr2.fields.Fulladdr
    '    dao_pjsum.fields.for_spon_tel = dao_addr2.fields.tel

    '    Dim dao_nm3 As New DAO_CPN.clsDBsyslcnsnm
    '    Dim dao_addr3 As New DAO_CPN.clsDBsyslctaddr
    '    dao_nm3.GetDataby_identify(ddl_monitor.SelectedValue)
    '    dao_addr3.GetDataby_identify(ddl_monitor.SelectedValue)

    '    dao_pjsum.fields.monitor_group = ddl_monitor.SelectedItem.Text
    '    dao_pjsum.fields.monitor_addr = dao_addr3.fields.Fulladdr
    '    dao_pjsum.fields.monitor_tel = dao_addr3.fields.tel

    '    Dim dao_nm4 As New DAO_CPN.clsDBsyslcnsnm
    '    Dim dao_addr4 As New DAO_CPN.clsDBsyslctaddr
    '    dao_nm4.GetDataby_identify(ddl_pm.SelectedValue)
    '    dao_addr4.GetDataby_identify(ddl_pm.SelectedValue)

    '    dao_pjsum.fields.PM_group = ddl_pm.SelectedItem.Text
    '    dao_pjsum.fields.PM_addr = dao_addr4.fields.Fulladdr
    '    dao_pjsum.fields.PM_tel = dao_addr4.fields.tel

    '    Dim dao_nm5 As New DAO_CPN.clsDBsyslcnsnm
    '    Dim dao_addr5 As New DAO_CPN.clsDBsyslctaddr
    '    dao_nm5.GetDataby_identify(ddl_dm.SelectedValue)
    '    dao_addr5.GetDataby_identify(ddl_dm.SelectedValue)

    '    dao_pjsum.fields.DM_group = ddl_dm.SelectedItem.Text
    '    dao_pjsum.fields.DM_addr = dao_addr5.fields.Fulladdr
    '    dao_pjsum.fields.DM_tel = dao_addr5.fields.tel

    '    dao_pjsum.update()

    'End Sub

    Sub bindpdf()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer


        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _Process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(10261, 0, 1)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)

        convert_Database_To_XML(file_xml)
        convert_XML_To_PDF(file_PDF, file_xml, file_template)

        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub

    Sub genxml()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer


        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _Process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(10261, 0, 1)

        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)

        convert_Database_To_XML(file_xml)

        _CLS.FILENAME_PDF = file_xml
        _CLS.PDFNAME = NAME_DOWNLOAD_XML("DA", down_ID)
        Session("CLS") = _CLS

        If HiddenField1.Value = "bypassupload" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner2();", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
        End If

    End Sub

    Private Sub convert_Database_To_XML(ByVal path As String)

        Dim cls_xml As New CLASS_PROJECT_SUM

        Dim dao_pjsum As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao_pjsum.GetDataby_IDA(_CLS.IDA)
        cls_xml.DRUG_PROJECT_SUMMARY = dao_pjsum.fields

        Dim dao_research As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
        dao_research.GetDataby_PROJECT(_CLS.IDA)
        For Each dao_research.datas In dao_research.datas
            cls_xml.DRUG_PROJECT_RESEARCH_FACILITYS.Add(dao_research.datas)
        Next

        Dim dao_dr As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao_dr.GetDataby_PROJECT(_CLS.IDA)
        For Each dao_dr.datas In dao_dr.datas
            cls_xml.DRUG_PROJECT_DRUG_LISTS.Add(dao_dr.datas)
        Next

        Dim dao_lab As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
        dao_lab.GetDataby_PROJECT(_CLS.IDA)
        For Each dao_lab.datas In dao_lab.datas
            cls_xml.DRUG_PROJECT_CLINICAL_LABORATORYS.Add(dao_lab.datas)
        Next

        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        cls_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(dao_pjsum.fields.CITIZEN)
        'ชื่อบริษัท
        cls_xml.DT_SHOW.DT11 = bao_show.SP_MAINPERSON_CTZNO(dao_pjsum.fields.CITIZEN_AUTHORIZE)

        ''_______________MASTER_________________
        'Dim bao_master As New BAO_MASTER
        'cls_xml.DT_MASTER.DT1 = bao_master.SP_DRUG_PRODUCT_ID_BY_PJSUM(_CLS.IDA, 2)

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub

    Protected Friend Function AddValue2(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()

            '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, " ", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else

                    props.SetValue(ob, Nothing, Nothing)


                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        insert_to_database()
        'If txt_pjthanm.Text = "" Then
        '    alert("กรุณากรอกชื่อโครงการวิจัยภาษาไทย")
        'Else
        '    If lbl_placnm.Text = "" Then
        '        alert("กรุณากรอกข้อมูลสถาณที่วิจัย")
        '    Else
        '        If rb_lab2.Checked = True And lbl_lab.Text = "" Then
        '            alert("กรุณากรอกข้อมูลห้องปฏิบัติการคลินิก ภายนอกสถานที่วิจัย")
        '        Else
        '            If rb_finace4.Checked = True And FileUpload1.HasFile = False Then
        '                alert("กรุณาเลือกไฟล์แนบการสนับสนุนทางการเงินและการประกัน")
        '            Else
        '                Dim unchk As Boolean = True
        '                For Each item As GridDataItem In RadGrid2.Items
        '                    Dim cb_chk As CheckBox = DirectCast(item("TemplateColumn").FindControl("checkColumn"), CheckBox)
        '                    If cb_chk.Checked = True Then
        '                        unchk = False
        '                        insert_to_database()
        '                        Exit For
        '                    End If
        '                Next
        '                If unchk = True Then
        '                    alert("กรุณาเลือกผลิตภัณฑ์ยาที่ใช้ในโครงการวิจัย")
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    Sub insert_to_database()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM

        dao.fields.givedata_times = 1
        dao.fields.givedata_date = Date.Now.ToShortDateString
        dao.fields.date_submit = Date.Now.ToShortDateString
        dao.fields.citizen_submit = _CLS.CITIZEN_ID
        dao.fields.pj_thname = txt_pjthanm.Text
        dao.fields.pj_enname = txt_pjengnm.Text
        dao.fields.pj_code = txt_pjcode.Text
        dao.fields.CITIZEN = _CLS.CITIZEN_ID
        dao.fields.CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        If rb_shortnm1.Checked = True Then
            dao.fields.pj_othernmcd = 1
        ElseIf rb_shortnm2.Checked Then
            dao.fields.pj_othernmcd = 2
        End If
        dao.fields.pj_othernm = txt_shortnm.Text
        If rb_ind1.Checked = True Then
            dao.fields.ind_numbercd = 1
        ElseIf rb_ind2.Checked Then
            dao.fields.ind_numbercd = 2
        End If
        dao.fields.ind_number = txt_ind.Text
        dao.fields.CTR = txt_ctr.Text
        If pj_1sttimes1.Checked Then
            dao.fields.pj_1sttime = 1
        ElseIf pj_1sttimes2.Checked Then
            dao.fields.pj_1sttime = 2
        ElseIf pj_1sttimes3.Checked Then
            dao.fields.pj_1sttime = 3
        ElseIf pj_1sttimes4.Checked Then
            dao.fields.pj_1sttime = 4
        ElseIf pj_1sttimes5.Checked Then
            dao.fields.pj_1sttime = 5
        End If
        If rb_type1.Checked Then
            dao.fields.pj_typecd = 1
        ElseIf rb_type2.Checked Then
            dao.fields.pj_typecd = 2
        End If
        If rb_support1.Checked Then
            dao.fields.supporttypr = 1
            dao.fields.company_nm = TextBox18.Text
        Else
            dao.fields.supporttypr = 2
        End If
        If rb_country1.Checked Then
            dao.fields.country = 1
        ElseIf rb_country2.Checked Then
            dao.fields.country = 2
        End If
        dao.fields.inter_intitute = txt_ins.Text
        dao.fields.inter_volunteer = txt_global_volun.Text
        dao.fields.th_intitute = th_intitute.Text
        dao.fields.th_spon_group = th_spon_group.Text
        dao.fields.th_spon_addr = th_spon_addr.Text
        dao.fields.th_spon_tel = th_spon_tel.Text
        dao.fields.th_spon_email_website = th_spon_email.Text
        dao.fields.thspons_taxno = thspons_taxno.Text
        dao.fields.th_spon_chngwtcd = DropDownList2.SelectedValue
        dao.fields.th_spon_chngwtnm = DropDownList2.SelectedItem.Text
        dao.fields.for_spon_group = for_spons_groupnm.Text
        dao.fields.for_spon_addr = for_spons_addr.Text
        dao.fields.for_spon_tel = for_spons_tel.Text
        dao.fields.for_spon_email_website = for_spons_email.Text
        'dao.fields.forspons_taxno = ddl_forspons.SelectedValue
        dao.fields.for_spon_countrycd = DropDownList3.SelectedValue
        dao.fields.for_spon_countrynm = DropDownList3.SelectedItem.Text
        dao.fields.monitor_group = monitor_group.Text
        dao.fields.monitor_addr = monitor_addr.Text
        dao.fields.monitor_tel = monitor_tel.Text
        dao.fields.monitor_email_website = monitor_email.Text
        dao.fields.monitor_taxno = monitor_taxno.Text
        dao.fields.monitor_countrycd = DropDownList6.SelectedValue
        dao.fields.monitor_countrynm = DropDownList6.SelectedItem.Text
        If DropDownList6.SelectedValue = 171 Then 'ประเทศไทย
            dao.fields.monitor_chngwtcd = DropDownList7.SelectedValue
            dao.fields.monitor_chngwtnm = DropDownList7.SelectedItem.Text
        End If
        If rb_monitor_type1.Checked Then
            dao.fields.monitor_type = 1
        ElseIf rb_monitor_type2.Checked Then
            dao.fields.monitor_type = 2
        End If

        dao.fields.PM_group = pm_group.Text
        dao.fields.PM_addr = pm_addr.Text
        dao.fields.PM_tel = pm_tel.Text
        dao.fields.PM_email_website = pm_email.Text
        dao.fields.pm_taxno = pm_taxno.Text
        dao.fields.PM_countrycd = DropDownList4.SelectedValue
        dao.fields.PM_countrynm = DropDownList4.SelectedItem.Text
        If DropDownList4.SelectedValue = 171 Then 'ประเทศไทย
            dao.fields.PM_chngwtcd = DropDownList8.SelectedValue
            dao.fields.PM_chngwtnm = DropDownList8.SelectedItem.Text
        End If

        If rb_pm_type1.Checked Then
            dao.fields.PM_type = 1
        ElseIf rb_pm_type2.Checked Then
            dao.fields.PM_type = 2
        End If

        dao.fields.DM_group = dm_group.Text
        dao.fields.DM_addr = dm_addr.Text
        dao.fields.DM_tel = dm_tel.Text
        dao.fields.DM_email_website = dm_email.Text
        dao.fields.dm_taxno = dm_taxno.Text
        dao.fields.DM_countrycd = DropDownList5.SelectedValue
        dao.fields.DM_countrynm = DropDownList5.SelectedItem.Text
        If DropDownList5.SelectedValue = 171 Then 'ประเทศไทย
            dao.fields.DM_chngwtcd = DropDownList9.SelectedValue
            dao.fields.DM_chngwtnm = DropDownList9.SelectedItem.Text
        End If
        If rb_dm_type1.Checked Then
            dao.fields.DM_type = 1
        ElseIf rb_dm_type2.Checked Then
            dao.fields.DM_type = 2
        End If
        If rb_lab1.Checked Then
            dao.fields.clinical_laboratorycd = 1
        ElseIf rb_lab2.Checked Then
            dao.fields.clinical_laboratorycd = 2
        End If
        If rb_findvolun1.Checked Then
            dao.fields.volunteer = 1
        ElseIf rb_findvolun2.Checked Then
            dao.fields.volunteer = 2
        ElseIf rb_findvolun3.Checked Then
            dao.fields.volunteer = 3
            dao.fields.volunteer_descript = txt_volundes.Text
        End If
        If rb_finace1.Checked Then
            dao.fields.Financing_and_Insurance = 1
            dao.fields.Financing_and_Insurance_Descript = TextBox19.Text
        ElseIf rb_finace2.Checked Then
            dao.fields.Financing_and_Insurance = 2
            dao.fields.Financing_and_Insurance_Descript = TextBox20.Text
        ElseIf rb_finace3.Checked Then
            dao.fields.Financing_and_Insurance = 3
            dao.fields.Financing_and_Insurance_Descript = TextBox21.Text
            dao.fields.fk_attach = insert_file(0, FileUpload1)
        ElseIf rb_finace4.Checked Then
            dao.fields.Financing_and_Insurance = 4
            dao.fields.fk_attach = insert_file(0, FileUpload1)
        End If
        'dao.fields.pj_start_inth = CDate(txt_start_date.Text)
        'dao.fields.pj_end_inth = CDate(txt_end_date.Text)
        Try
            dao.fields.pj_start_inth = TextBox22.Text
        Catch ex As Exception

        End Try
        Try
            dao.fields.pj_end_inth = TextBox23.Text
        Catch ex As Exception

        End Try

        If HiddenField1.Value = "bypassupload" Then
            Dim TR_ID As Integer = 0
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection_new(_Process) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION
            dao.fields.STATUS_ID = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.TR_ID = TR_ID
            _CLS.TRANSECTION_UP_ID = TR_ID
        Else
            dao.fields.STATUS_ID = 0
        End If

        dao.insert()

        Dim placnm As Array
        Dim volun As Array
        Dim main_re As Array
        Dim addr As Array
        Dim tel As Array
        Dim email As Array
        Dim taxno As Array
        Dim houseno As Array
        Dim chngwtcd As Array
        Dim chngwtnm As Array
        Dim latitude As Array
        Dim longtitude As Array
        Dim i As Integer
        placnm = lbl_placnm.Text.Split(",")
        volun = lbl_volunteer.Text.Split(",")
        main_re = lbl_main_research.Text.Split(",")
        addr = lbl_addr.Text.Split(",")
        tel = lbl_tel.Text.Split(",")
        email = lbl_email.Text.Split(",")
        taxno = lbl_taxno.Text.Split(",")
        houseno = lbl_houseno.Text.Split(",")
        chngwtcd = lbl_chngwtcd.Text.Split(",")
        chngwtnm = lbl_chngwtnm.Text.Split(",")
        latitude = lbl_latitude.Text.Split(",")
        longtitude = lbl_longtitude.Text.Split(",")

        Dim dao_fac As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
        For i = 0 To placnm.Length - 1

            dao_fac.fields.PJ_IDA = dao.fields.IDA
            dao_fac.fields.placenm = placnm(i)
            dao_fac.fields.volunteer_amount = volun(i)
            dao_fac.fields.main_research = main_re(i)
            dao_fac.fields.addr = addr(i)
            dao_fac.fields.tel = tel(i)
            'ใส่ trycast ในกรณีที่ไม่กรอกแล้ว split error insert ไม่ได้
            Try
                dao_fac.fields.email = email(i)
            Catch ex As Exception
            End Try
            Try
                dao_fac.fields.taxno = taxno(i)
            Catch ex As Exception
            End Try
            Try
                dao_fac.fields.houseno = houseno(i)
            Catch ex As Exception

            End Try
            Try
                dao_fac.fields.chngwtcd = CInt(chngwtcd(i))
            Catch ex As Exception
            End Try
            Try
                dao_fac.fields.chngwtnm = chngwtnm(i)
            Catch ex As Exception
            End Try
            Try
                dao_fac.fields.latitude = System.Convert.ToDecimal(latitude(i))
            Catch ex As Exception

            End Try
            Try
                dao_fac.fields.longtitude = System.Convert.ToDecimal(longtitude(i))
            Catch ex As Exception

            End Try
            dao_fac.insert()
            dao_fac = New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY

        Next

        If lbl_labnm.Text = "" Or lbl_groupnm.Text = "" Or lbl_lab_addr.Text = "" Or lbl_lab_tel.Text = "" Or lbl_lab_email.Text = "" Then
        Else
            Dim labnm As Array
            Dim groupnm As Array
            Dim lab_addr As Array
            Dim lab_tel As Array
            Dim lab_email As Array
            Dim lab_countrycd As Array
            Dim lab_countrynm As Array
            Dim lab_chngwtcd As Array
            Dim lab_chngwtnm As Array
            i = 0
            labnm = lbl_labnm.Text.Split(",")
            groupnm = lbl_groupnm.Text.Split(",")
            lab_addr = lbl_lab_addr.Text.Split(",")
            lab_tel = lbl_lab_tel.Text.Split(",")
            lab_email = lbl_lab_email.Text.Split(",")
            lab_countrycd = lbl_lab_countrycd.Text.Split(",")
            lab_countrynm = lbl_lab_countrynm.Text.Split(",")
            lab_chngwtcd = lbl_lab_chngwtcd.Text.Split(",")
            lab_chngwtnm = lbl_lab_chngwtnm.Text.Split(",")

            Dim dao_lab As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
            For i = 0 To placnm.Length - 1

                dao_lab.fields.PJ_IDA = dao.fields.IDA
                dao_lab.fields.labnm = labnm(i)
                dao_lab.fields.groupnm = groupnm(i)
                dao_lab.fields.addr = lab_addr(i)
                dao_lab.fields.tel = lab_tel(i)
                'ใส่ trycast ในกรณีที่ไม่กรอกแล้ว split error insert ไม่ได้
                Try
                    dao_lab.fields.email_website = lab_email(i)
                Catch ex As Exception

                End Try
                Try
                    dao_lab.fields.countrycd = CInt(lab_countrycd(i))
                Catch ex As Exception

                End Try
                Try
                    dao_lab.fields.countrynm = lab_countrynm(i)
                Catch ex As Exception

                End Try
                Try
                    dao_lab.fields.chngwtcd = CInt(lab_chngwtcd(i))
                Catch ex As Exception

                End Try
                Try
                    dao_lab.fields.chngwtnm = lab_chngwtnm(i)
                Catch ex As Exception

                End Try
                dao_lab.insert()
                dao_lab = New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY

            Next
        End If

        Dim package_detail As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        For Each item As GridDataItem In RadGrid2.Items

            Dim cb_chk As CheckBox = DirectCast(item("TemplateColumn").FindControl("checkColumn"), CheckBox)
            If cb_chk.Checked = True Then

                package_detail.GetDataby_IDA(item("IDA").Text)
                package_detail.fields.is_check = 1
                package_detail.fields.PJ_IDA = dao.fields.IDA
                package_detail.update()

            End If
        Next

        _CLS.IDA = dao.fields.IDA

        HiddenField1.Value = ""     'ล้างค่า

        genxml()
    End Sub

    Private Function insert_file(ByVal TR_ID As Integer, ByVal fileupload As FileUpload)
        Dim ida As New Integer
        ida = 0
        If fileupload.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TYPE As String = fileupload.ID.ToString.Substring(10, 1)

            Dim extensionname As String = GetExtension(fileupload.FileName).ToLower()
            fileupload.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _Process & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname)
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

            dao_file.fields.NAME_FAKE = "DA-" & _Process & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = fileupload.FileName
            dao_file.fields.TYPE = TYPE
            dao_file.fields.TRANSACTION_ID = TR_ID
            dao_file.fields.PROCESS_ID = _Process
            dao_file.insert()

            ida = dao_file.fields.IDA
        End If
        Return ida
    End Function

    Protected Sub btn_save_fac_Click(sender As Object, e As EventArgs) Handles btn_save_fac.Click
        If txt_placenm.Text = "" Or txt_main_research.Text = "" Or txt_fac_addr.Text = "" Or txt_fac_tel.Text = "" Or txt_volunteer_amount.Text = "" Or txt_taxno.Text = "" Then
            alert("กรุณากรอกข้อมูลสถานที่วิจัยให้ครบ")
        Else
            If DropDownList1.SelectedValue = 0 Then
                alert("กรุณาเลือกจังหวัดสถานที่วิจัยให้ครบ")
            Else
                If lbl_placnm.Text = "" Then
                    lbl_placnm.Text = txt_placenm.Text
                    txt_fac.Text = "<h3>รายชื่อสถานที่</h3>" & txt_placenm.Text
                Else
                    lbl_placnm.Text = lbl_placnm.Text & "," & txt_placenm.Text
                    txt_fac.Text = txt_fac.Text & "<br>" & txt_placenm.Text
                End If

                If lbl_volunteer.Text = "" Then
                    lbl_volunteer.Text = txt_volunteer_amount.Text
                Else
                    lbl_volunteer.Text = lbl_volunteer.Text & "," & txt_volunteer_amount.Text
                End If

                If lbl_main_research.Text = "" Then
                    lbl_main_research.Text = txt_main_research.Text
                Else
                    lbl_main_research.Text = lbl_main_research.Text & "," & txt_main_research.Text
                End If

                If lbl_addr.Text = "" Then
                    lbl_addr.Text = txt_fac_addr.Text
                Else
                    lbl_addr.Text = lbl_addr.Text & "," & txt_fac_addr.Text
                End If

                If lbl_tel.Text = "" Then
                    lbl_tel.Text = txt_fac_tel.Text
                Else
                    lbl_tel.Text = lbl_tel.Text & "," & txt_fac_tel.Text
                End If

                If lbl_email.Text = "" Then
                    lbl_email.Text = txt_fac_email.Text
                Else
                    lbl_email.Text = lbl_email.Text & "," & txt_fac_email.Text
                End If

                If lbl_taxno.Text = "" Then
                    lbl_taxno.Text = txt_taxno.Text
                Else
                    lbl_taxno.Text = lbl_taxno.Text & "," & txt_taxno.Text
                End If

                If lbl_houseno.Text = "" Then
                    lbl_houseno.Text = txt_houseno.Text
                Else
                    lbl_houseno.Text = lbl_houseno.Text & "," & txt_houseno.Text
                End If

                If lbl_chngwtcd.Text = "" Then
                    lbl_chngwtcd.Text = DropDownList1.SelectedValue
                Else
                    lbl_chngwtcd.Text = lbl_chngwtcd.Text & "," & DropDownList1.SelectedValue
                End If

                If lbl_chngwtnm.Text = "" Then
                    lbl_chngwtnm.Text = DropDownList1.SelectedItem.Text
                Else
                    lbl_chngwtnm.Text = lbl_chngwtnm.Text & "," & DropDownList1.SelectedItem.Text
                End If

                If lbl_latitude.Text = "" Then
                    lbl_latitude.Text = txt_latitude.Text
                Else
                    lbl_latitude.Text = lbl_latitude.Text & "," & txt_latitude.Text
                End If

                If lbl_longtitude.Text = "" Then
                    lbl_longtitude.Text = txt_longtitude.Text
                Else
                    lbl_longtitude.Text = lbl_longtitude.Text & "," & txt_longtitude.Text
                End If
            End If

        End If
    End Sub

    Protected Sub btn_save_lab_Click(sender As Object, e As EventArgs) Handles btn_save_lab.Click
        If TextBox13.Text = "" Or TextBox14.Text = "" Or TextBox15.Text = "" Or TextBox16.Text = "" Then
            alert("กรุณากรอกข้อมูลห้องปฏิบัติการคลินิกให้ครบ")
        Else
            If DropDownList10.SelectedValue = 0 Then
                alert("กรุณาเลือกประเทศของห้องปฏิบัติการคลินิก")
            Else
                If lbl_labnm.Text = "" Then
                    lbl_labnm.Text = TextBox13.Text
                    lbl_lab.Text = "<h3>รายชื่อห้องปฏิบัติการคลินิก</h3>" & TextBox13.Text & " : " & TextBox14.Text
                Else
                    lbl_labnm.Text = lbl_labnm.Text & "," & TextBox13.Text
                    lbl_lab.Text = lbl_lab.Text & "<br>" & TextBox13.Text & " : " & TextBox14.Text
                End If

                If lbl_groupnm.Text = "" Then
                    lbl_groupnm.Text = TextBox14.Text
                Else
                    lbl_groupnm.Text = lbl_groupnm.Text & "," & TextBox14.Text
                End If

                If lbl_lab_addr.Text = "" Then
                    lbl_lab_addr.Text = TextBox15.Text
                Else
                    lbl_lab_addr.Text = lbl_lab_addr.Text & "," & TextBox15.Text
                End If

                If lbl_lab_countrycd.Text = "" Then
                    lbl_lab_countrycd.Text = DropDownList10.SelectedValue
                Else
                    lbl_lab_countrycd.Text = lbl_lab_countrycd.Text & "," & DropDownList10.SelectedValue
                End If

                If lbl_lab_countrynm.Text = "" Then
                    lbl_lab_countrynm.Text = DropDownList10.SelectedItem.Text
                Else
                    lbl_lab_countrynm.Text = lbl_lab_countrynm.Text & "," & DropDownList10.SelectedItem.Text
                End If

                If lbl_lab_chngwtcd.Text = "" Then
                    lbl_lab_chngwtcd.Text = DropDownList11.SelectedValue
                Else
                    lbl_lab_chngwtcd.Text = lbl_lab_chngwtcd.Text & "," & DropDownList11.SelectedValue
                End If

                If lbl_lab_chngwtnm.Text = "" Then
                    If DropDownList11.SelectedItem.Text = "" Then
                        lbl_lab_chngwtnm.Text = "-"
                    Else
                        lbl_lab_chngwtnm.Text = DropDownList11.SelectedItem.Text
                    End If
                Else
                    lbl_lab_chngwtnm.Text = lbl_lab_chngwtnm.Text & "," & DropDownList11.SelectedItem.Text
                End If

                If lbl_lab_tel.Text = "" Then
                    lbl_lab_tel.Text = TextBox16.Text
                Else
                    lbl_lab_tel.Text = lbl_lab_tel.Text & "," & TextBox16.Text
                End If

                If lbl_lab_email.Text = "" Then
                    lbl_lab_email.Text = TextBox17.Text
                Else
                    lbl_lab_email.Text = lbl_lab_email.Text & "," & TextBox17.Text
                End If
            End If
        End If
    End Sub

    Protected Sub rb_lab1_CheckedChanged(sender As Object, e As EventArgs) Handles rb_lab1.CheckedChanged
        If rb_lab1.Checked = True Then
            clinic_section.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub rb_lab2_CheckedChanged(sender As Object, e As EventArgs) Handles rb_lab2.CheckedChanged
        If rb_lab2.Checked = True Then
            clinic_section.Style.Add("display", "in-line")
        End If
    End Sub

    Protected Sub btn_save2_Click(sender As Object, e As EventArgs) Handles btn_save2.Click
        HiddenField1.Value = "bypassupload"
        If txt_pjthanm.Text = "" Then
            alert("กรุณากรอกชื่อโครงการวิจัยภาษาไทย")
        Else
            If lbl_placnm.Text = "" Then
                alert("กรุณากรอกข้อมูลสถาณที่วิจัย")
            Else
                If rb_lab2.Checked = True And lbl_lab.Text = "" Then
                    alert("กรุณากรอกข้อมูลห้องปฏิบัติการคลินิก ภายนอกสถานที่วิจัย")
                Else
                    Dim unchk As Boolean = True
                    For Each item As GridDataItem In RadGrid2.Items
                        Dim cb_chk As CheckBox = DirectCast(item("TemplateColumn").FindControl("checkColumn"), CheckBox)
                        If cb_chk.Checked = True Then
                            unchk = False
                            insert_to_database()
                            Response.Redirect("POPUP_RESEARCH_SUM_UL.aspx?process=" & _Process)
                            Exit For
                        End If
                    Next
                    If unchk = True Then
                        alert("กรุณาเลือกผลิตภัณฑ์ยาที่ใช้ในโครงการวิจัย")
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub DropDownList10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList10.SelectedIndexChanged
        If DropDownList10.SelectedValue = 171 Then
            chngwt.Style.Add("display", "inline")
        Else
            chngwt.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub DropDownList6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList6.SelectedIndexChanged
        If DropDownList6.SelectedValue = 171 Then
            chngwt1.Style.Add("display", "inline")
        Else
            chngwt1.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub DropDownList4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList4.SelectedIndexChanged
        If DropDownList4.SelectedValue = 171 Then
            chngwt2.Style.Add("display", "inline")
        Else
            chngwt2.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub DropDownList5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList5.SelectedIndexChanged
        If DropDownList5.SelectedValue = 171 Then
            chngwt3.Style.Add("display", "inline")
        Else
            chngwt3.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub btn_dr_search_Click(sender As Object, e As EventArgs) Handles btn_dr_search.Click
        If IsNothing(TextBox24.Text) Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
            dao.GetDataby_notuse(_CLS.CITIZEN_ID_AUTHORIZE)
            RadGrid2.DataSource = dao.datas
        Else
            Dim bao As New BAO.ClsDBSqlcommand
            RadGrid2.DataSource = bao.SP_DRUG_PROJECT_DRUG_LIST_SEARCH(TextBox24.Text, _CLS.CITIZEN_ID_AUTHORIZE)
            RadGrid2.DataBind()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FileUpload2.HasFile Then
            Try
                Dim extensionname As String = GetExtension(FileUpload2.FileName)
                FileUpload2.SaveAs(_PATH_DEFALUT & "/upload/" & FileUpload2.FileName & "." & extensionname)

                Dim objStreamReader As New StreamReader(_PATH_DEFALUT & "/upload/" & FileUpload2.FileName & "." & extensionname)
                Dim p2 As New CLASS_PROJECT_SUM
                Dim x As New XmlSerializer(p2.GetType)
                p2 = x.Deserialize(objStreamReader)
                objStreamReader.Close()

                Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
                dao.GetDataby_IDA(p2.DRUG_PROJECT_SUMMARY.IDA)

                txt_pjthanm.Text = p2.DRUG_PROJECT_SUMMARY.pj_thname
                txt_pjengnm.Text = p2.DRUG_PROJECT_SUMMARY.pj_enname
                txt_pjcode.Text = p2.DRUG_PROJECT_SUMMARY.pj_code
                If p2.DRUG_PROJECT_SUMMARY.pj_othernmcd = 1 Then
                    rb_shortnm1.Checked = True
                    txt_shortnm.Text = p2.DRUG_PROJECT_SUMMARY.pj_othernm
                ElseIf p2.DRUG_PROJECT_SUMMARY.pj_othernmcd = 2 Then
                    rb_shortnm2.Checked = True
                End If
                If p2.DRUG_PROJECT_SUMMARY.ind_numbercd = 1 Then
                    rb_ind1.Checked = True
                    txt_ind.Text = p2.DRUG_PROJECT_SUMMARY.pj_othernm
                ElseIf p2.DRUG_PROJECT_SUMMARY.ind_numbercd = 2 Then
                    rb_ind1.Checked = True
                End If
                txt_ctr.Text = p2.DRUG_PROJECT_SUMMARY.CTR
                If p2.DRUG_PROJECT_SUMMARY.pj_1sttime = 1 Then
                    pj_1sttimes1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.pj_1sttime = 2 Then
                    pj_1sttimes1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.pj_1sttime = 3 Then
                    pj_1sttimes1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.pj_1sttime = 4 Then
                    pj_1sttimes1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.pj_1sttime = 5 Then
                    pj_1sttimes1.Checked = True
                End If
                If p2.DRUG_PROJECT_SUMMARY.pj_typecd = 1 Then
                    rb_type1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.pj_typecd = 2 Then
                    rb_type2.Checked = True
                End If
                If p2.DRUG_PROJECT_SUMMARY.supporttypr = 1 Then
                    rb_support1.Checked = True
                    TextBox18.Text = p2.DRUG_PROJECT_SUMMARY.company_nm
                ElseIf p2.DRUG_PROJECT_SUMMARY.supporttypr = 2 Then
                    rb_support2.Checked = True
                End If
                If p2.DRUG_PROJECT_SUMMARY.country = 1 Then
                    rb_country1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.country = 2 Then
                    rb_country2.Checked = True
                End If
                txt_ins.Text = p2.DRUG_PROJECT_SUMMARY.inter_intitute
                txt_global_volun.Text = p2.DRUG_PROJECT_SUMMARY.inter_volunteer
                th_intitute.Text = p2.DRUG_PROJECT_SUMMARY.th_intitute
                loaddata(1, p2.DRUG_PROJECT_SUMMARY.IDA)
                th_spon_group.Text = p2.DRUG_PROJECT_SUMMARY.th_spon_group
                thspons_taxno.Text = p2.DRUG_PROJECT_SUMMARY.thspons_taxno
                th_spon_addr.Text = p2.DRUG_PROJECT_SUMMARY.th_spon_addr
                DropDownList2.SelectedValue = p2.DRUG_PROJECT_SUMMARY.th_spon_chngwtcd
                th_spon_tel.Text = p2.DRUG_PROJECT_SUMMARY.th_spon_tel
                th_spon_email.Text = p2.DRUG_PROJECT_SUMMARY.th_spon_email_website
                for_spons_groupnm.Text = p2.DRUG_PROJECT_SUMMARY.for_spon_group
                for_spons_addr.Text = p2.DRUG_PROJECT_SUMMARY.for_spon_addr
                DropDownList3.SelectedValue = p2.DRUG_PROJECT_SUMMARY.for_spon_countrycd
                for_spons_tel.Text = p2.DRUG_PROJECT_SUMMARY.for_spon_tel
                for_spons_email.Text = p2.DRUG_PROJECT_SUMMARY.for_spon_email_website
                If p2.DRUG_PROJECT_SUMMARY.monitor_type = 1 Then
                    rb_monitor_type1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.monitor_type = 2 Then
                    rb_monitor_type2.Checked = True
                End If
                monitor_group.Text = p2.DRUG_PROJECT_SUMMARY.monitor_group
                monitor_taxno.Text = p2.DRUG_PROJECT_SUMMARY.monitor_taxno
                monitor_addr.Text = p2.DRUG_PROJECT_SUMMARY.monitor_addr
                DropDownList6.SelectedValue = p2.DRUG_PROJECT_SUMMARY.monitor_countrycd
                If p2.DRUG_PROJECT_SUMMARY.monitor_countrycd = 171 Then
                    chngwt1.Style.Add("display", "inline")
                    DropDownList7.SelectedValue = p2.DRUG_PROJECT_SUMMARY.monitor_chngwtcd
                End If
                monitor_tel.Text = p2.DRUG_PROJECT_SUMMARY.monitor_tel
                monitor_email.Text = p2.DRUG_PROJECT_SUMMARY.monitor_email_website
                If p2.DRUG_PROJECT_SUMMARY.PM_type = 1 Then
                    rb_pm_type1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.PM_type = 2 Then
                    rb_pm_type2.Checked = True
                End If
                pm_group.Text = p2.DRUG_PROJECT_SUMMARY.PM_group
                pm_tel.Text = p2.DRUG_PROJECT_SUMMARY.PM_tel
                pm_taxno.Text = p2.DRUG_PROJECT_SUMMARY.pm_taxno
                pm_addr.Text = p2.DRUG_PROJECT_SUMMARY.PM_addr
                DropDownList4.SelectedValue = p2.DRUG_PROJECT_SUMMARY.PM_countrycd
                If p2.DRUG_PROJECT_SUMMARY.PM_countrycd = 171 Then
                    chngwt2.Style.Add("display", "inline")
                    DropDownList8.SelectedValue = p2.DRUG_PROJECT_SUMMARY.PM_chngwtcd
                End If
                pm_tel.Text = p2.DRUG_PROJECT_SUMMARY.PM_tel
                pm_email.Text = p2.DRUG_PROJECT_SUMMARY.PM_email_website
                If p2.DRUG_PROJECT_SUMMARY.DM_type = 1 Then
                    rb_dm_type1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.DM_type = 2 Then
                    rb_dm_type2.Checked = True
                End If
                dm_group.Text = p2.DRUG_PROJECT_SUMMARY.DM_group
                dm_taxno.Text = p2.DRUG_PROJECT_SUMMARY.dm_taxno
                dm_addr.Text = p2.DRUG_PROJECT_SUMMARY.DM_addr
                DropDownList5.SelectedValue = p2.DRUG_PROJECT_SUMMARY.DM_countrycd
                If p2.DRUG_PROJECT_SUMMARY.DM_countrycd = 171 Then
                    chngwt3.Style.Add("display", "inline")
                    DropDownList9.SelectedValue = p2.DRUG_PROJECT_SUMMARY.DM_chngwtcd
                End If
                dm_tel.Text = p2.DRUG_PROJECT_SUMMARY.DM_tel
                dm_email.Text = p2.DRUG_PROJECT_SUMMARY.DM_email_website
                If p2.DRUG_PROJECT_SUMMARY.clinical_laboratorycd = 1 Then
                    rb_lab1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.clinical_laboratorycd = 2 Then
                    rb_lab2.Checked = True
                    loaddata(2, p2.DRUG_PROJECT_SUMMARY.IDA)
                End If
                Try
                    Dim startpj As Date = p2.DRUG_PROJECT_SUMMARY.pj_start_inth
                    TextBox22.Text = startpj.Month.ToString & "/" & startpj.Year + 543
                Catch ex As Exception

                End Try
                Try
                    Dim endpj As Date = p2.DRUG_PROJECT_SUMMARY.pj_end_inth
                    TextBox23.Text = endpj.Month.ToString & "/" & endpj.Year + 543
                Catch ex As Exception

                End Try
                If p2.DRUG_PROJECT_SUMMARY.volunteer = 1 Then
                    rb_findvolun1.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.volunteer = 2 Then
                    rb_findvolun2.Checked = True
                ElseIf p2.DRUG_PROJECT_SUMMARY.volunteer = 3 Then
                    rb_findvolun3.Checked = True
                    txt_volundes.Text = p2.DRUG_PROJECT_SUMMARY.volunteer_descript
                End If
                If p2.DRUG_PROJECT_SUMMARY.Financing_and_Insurance = 1 Then
                    rb_finace1.Checked = True
                    TextBox19.Text = p2.DRUG_PROJECT_SUMMARY.Financing_and_Insurance_Descript
                ElseIf p2.DRUG_PROJECT_SUMMARY.Financing_and_Insurance = 2 Then
                    rb_finace2.Checked = True
                    TextBox20.Text = p2.DRUG_PROJECT_SUMMARY.Financing_and_Insurance_Descript
                ElseIf p2.DRUG_PROJECT_SUMMARY.Financing_and_Insurance = 3 Then
                    rb_finace3.Checked = True
                    TextBox21.Text = p2.DRUG_PROJECT_SUMMARY.Financing_and_Insurance_Descript
                ElseIf p2.DRUG_PROJECT_SUMMARY.Financing_and_Insurance = 4 Then
                    rb_finace4.Checked = True
                End If
            Catch ex As Exception
                alert("พบปัญหาในการโหลดข้อมูล")
            End Try
        Else
            alert("ไม่พบไฟล์ xml")
        End If
    End Sub
    ''' <summary>
    ''' โหลดข้อมูลจาก xml ไป label
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="PJIDA"></param>
    Sub loaddata(ByVal type As Integer, ByVal PJIDA As Integer)
        If type = 1 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
            dao.GetDataby_PROJECT(PJIDA)
            If IsNothing(dao.fields.PJ_IDA) Then
            Else
                For Each dao.fields In dao.datas
                    If lbl_placnm.Text = "" Then
                        lbl_placnm.Text = dao.fields.placenm
                        txt_fac.Text = "<h3>รายชื่อสถานที่</h3>" & dao.fields.placenm
                    Else
                        lbl_placnm.Text = lbl_placnm.Text & "," & dao.fields.placenm
                        txt_fac.Text = txt_fac.Text & "<br>" & dao.fields.placenm
                    End If

                    If lbl_volunteer.Text = "" Then
                        If dao.fields.volunteer_amount = "" Then
                            lbl_volunteer.Text = "-"
                        Else
                            lbl_volunteer.Text = dao.fields.volunteer_amount
                        End If
                    Else
                        lbl_volunteer.Text = lbl_volunteer.Text & "," & dao.fields.volunteer_amount
                    End If

                    If lbl_main_research.Text = "" Then
                        lbl_main_research.Text = dao.fields.main_research
                    Else
                        lbl_main_research.Text = lbl_main_research.Text & "," & dao.fields.main_research
                    End If

                    If lbl_addr.Text = "" Then
                        lbl_addr.Text = dao.fields.addr
                    Else
                        lbl_addr.Text = lbl_addr.Text & "," & dao.fields.addr
                    End If

                    If lbl_tel.Text = "" Then
                        lbl_tel.Text = dao.fields.tel
                    Else
                        lbl_tel.Text = lbl_tel.Text & "," & dao.fields.tel
                    End If

                    If lbl_email.Text = "" Then
                        If dao.fields.email = "" Then
                            lbl_email.Text = "-"
                        Else
                            lbl_email.Text = dao.fields.email
                        End If
                        lbl_email.Text = dao.fields.email
                    Else
                        lbl_email.Text = lbl_email.Text & "," & dao.fields.email
                    End If

                    If lbl_taxno.Text = "" Then
                        lbl_taxno.Text = dao.fields.taxno
                    Else
                        lbl_taxno.Text = lbl_taxno.Text & "," & dao.fields.taxno
                    End If

                    If lbl_houseno.Text = "" Then
                        If lbl_houseno.Text = "" Then
                            lbl_houseno.Text = "-"
                        Else
                            lbl_houseno.Text = dao.fields.houseno
                        End If
                    Else
                        lbl_houseno.Text = lbl_houseno.Text & "," & dao.fields.houseno
                    End If

                    If lbl_chngwtcd.Text = "" Then
                        lbl_chngwtcd.Text = dao.fields.chngwtcd
                    Else
                        lbl_chngwtcd.Text = lbl_chngwtcd.Text & "," & dao.fields.chngwtcd
                    End If

                    If lbl_chngwtnm.Text = "" Then
                        lbl_chngwtnm.Text = dao.fields.chngwtnm
                    Else
                        lbl_chngwtnm.Text = lbl_chngwtnm.Text & "," & dao.fields.chngwtnm
                    End If

                    If lbl_latitude.Text = "" Then
                        If IsNothing(dao.fields.latitude) Then
                            lbl_latitude.Text = 0
                        Else
                            lbl_latitude.Text = dao.fields.latitude
                        End If
                    Else
                        lbl_latitude.Text = lbl_latitude.Text & "," & dao.fields.latitude
                    End If

                    If lbl_longtitude.Text = "" Then
                        If IsNothing(dao.fields.longtitude) Then
                            lbl_longtitude.Text = 0
                        Else
                            lbl_longtitude.Text = dao.fields.longtitude
                        End If
                    Else
                        lbl_longtitude.Text = lbl_longtitude.Text & "," & dao.fields.longtitude
                    End If
                Next
            End If
        ElseIf type = 2 Then
            clinic_section.Style.Add("display", "in-line")
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
            dao.GetDataby_PROJECT(PJIDA)
            If IsNothing(dao.fields.PJ_IDA) Then
            Else
                For Each dao.fields In dao.datas
                    If lbl_labnm.Text = "" Then
                        lbl_labnm.Text = dao.fields.labnm
                        lbl_lab.Text = "<h3>รายชื่อห้องปฏิบัติการคลินิก</h3>" & dao.fields.labnm & " : " & dao.fields.groupnm
                    Else
                        lbl_labnm.Text = lbl_labnm.Text & "," & dao.fields.labnm
                        lbl_lab.Text = lbl_lab.Text & "<br>" & dao.fields.labnm & " : " & dao.fields.groupnm
                    End If

                    If lbl_groupnm.Text = "" Then
                        lbl_groupnm.Text = dao.fields.groupnm
                    Else
                        lbl_groupnm.Text = lbl_groupnm.Text & "," & dao.fields.groupnm
                    End If

                    If lbl_lab_addr.Text = "" Then
                        lbl_lab_addr.Text = dao.fields.addr
                    Else
                        lbl_lab_addr.Text = lbl_lab_addr.Text & "," & dao.fields.addr
                    End If

                    If lbl_lab_chngwtcd.Text = "" Then
                        If IsNothing(dao.fields.chngwtcd) Then
                            lbl_lab_chngwtcd.Text = 0
                        Else
                            lbl_lab_chngwtcd.Text = dao.fields.chngwtcd
                        End If
                    Else
                        lbl_lab_chngwtcd.Text = lbl_lab_chngwtcd.Text & "," & dao.fields.chngwtcd
                    End If

                    If lbl_lab_chngwtnm.Text = "" Then
                        If dao.fields.chngwtnm = "" Then
                            lbl_lab_chngwtnm.Text = "-"
                        Else
                            lbl_lab_chngwtnm.Text = dao.fields.chngwtnm
                        End If
                    Else
                        lbl_lab_chngwtnm.Text = lbl_lab_chngwtnm.Text & "," & dao.fields.chngwtnm
                    End If

                    If lbl_lab_countrycd.Text = "" Then
                        If IsNothing(dao.fields.chngwtcd) Then
                            lbl_lab_countrycd.Text = 0
                        Else
                            lbl_lab_countrycd.Text = dao.fields.countrycd
                        End If
                    Else
                        lbl_lab_countrycd.Text = lbl_lab_countrycd.Text & "," & dao.fields.countrycd
                    End If

                    If lbl_lab_countrynm.Text = "" Then
                        If dao.fields.countrynm = "" Then
                            lbl_lab_countrynm.Text = "-"
                        Else
                            lbl_lab_countrynm.Text = dao.fields.countrynm
                        End If
                    Else
                        lbl_lab_countrynm.Text = lbl_lab_countrynm.Text & "," & dao.fields.countrynm
                    End If

                    If lbl_lab_tel.Text = "" Then
                        lbl_lab_tel.Text = dao.fields.tel
                    Else
                        lbl_lab_tel.Text = lbl_lab_tel.Text & "," & dao.fields.tel
                    End If

                    If lbl_lab_email.Text = "" Then
                        lbl_lab_email.Text = dao.fields.email_website
                    Else
                        lbl_lab_email.Text = lbl_lab_email.Text & "," & dao.fields.email_website
                    End If
                Next
            End If

        End If
    End Sub
End Class