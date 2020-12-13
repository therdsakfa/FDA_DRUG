Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class FEM_REGISTRATION_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String = ""
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _r_process As String = ""
    Sub runQuery()
        _r_process = Request.QueryString("r_process")
        _process = "1400001" 'Request.QueryString("process")
        '_IDA = Request.QueryString("IDA")
        '_fk_ida = Request.QueryString("fk_ida")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
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
        RunSession()
        runQuery()
        set_lbl_header(lbl_Header_txt, _r_process)
        If Request.QueryString("staff") <> "" Then
            If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                ' AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("staff"), 0, HttpContext.Current.Request.Url.AbsoluteUri)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ระบบตรวจพบว่าท่านเปิดการใช้งานหลายหน้าจอ จะทำการออกจากระบบโดยอัตโนมัติ');window.location.href = 'https://privus.fda.moph.go.th';", True)
            End If
        End If

        If Not IsPostBack() Then
            bind_ddl_product()
            bind_ddl()
            'load_GV_data()
            If Request.QueryString("tt") <> "" Then
                lbl_sel_tamrab.Style.Add("display", "block")
                ddl_tamrab.Style.Add("display", "block")

                'btn_download.Visible = False
                'btn_upload.Visible = False
            Else
                lbl_sel_tamrab.Style.Add("display", "none")
                ddl_tamrab.Style.Add("display", "none")
            End If
            Try
                UC_Information.Shows(_lcn_ida)
            Catch ex As Exception

            End Try

        End If

    End Sub
    Sub bind_ddl()

        Try
            Dim dao As New DAO_DRUG.TB_MAS_TAMRAP_NAME
            Dim _group As Integer = 0
            If Request.QueryString("tt") = 1 Then
                _group = 0
                dao.GetDataByGROUP(_group)
            ElseIf Request.QueryString("tt") = 2 Then
                _group = 1
                Try
                    dao.GetDataByGROUPAuto(_group, Request.QueryString("st"))
                Catch ex As Exception

                End Try

            End If


            ddl_tamrab.DataSource = dao.datas
            ddl_tamrab.DataTextField = "TAMRAP_NAME"
            ddl_tamrab.DataValueField = "TAMRAP_ID"
            ddl_tamrab.DataBind()

            Dim item As New ListItem
            item.Text = "กรุณาเลือก"
            item.Value = "0"
            ddl_tamrab.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_ddl_product()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            bao.SP_DRUG_PRODUCT_ID_BY_LCN_IDA(_lcn_ida)
        Catch ex As Exception

        End Try
        Try
            dt = bao.dt
            ddl_product_id.DataSource = dt
            ddl_product_id.DataTextField = "LCNNO_DISPLAY"
            ddl_product_id.DataValueField = "IDA"
            ddl_product_id.DataBind()
        Catch ex As Exception

        End Try


    End Sub
    Sub load_GV_data()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        'If _fk_ida <> "" Then
        bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID(_lcn_ida, _r_process)
        'Else
        '    bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA(_IDA)
        'End If

        'GV_data.DataSource = bao_DB.dt
        'GV_data.DataBind()
    End Sub

    'Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
    '    If Request.QueryString("tt") = "" Then
    '        Bind_PDF()
    '    Else
    '        If ddl_tamrab.SelectedValue <> "0" Then
    '            Bind_PDF()
    '        Else
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกชื่อตำรับยา');", True)
    '        End If
    '    End If

    '    'If _process = 9 Then
    '    '    Bind_PDF("PDF_REGISTRATION.pdf")
    '    'ElseIf _process = 19 Then
    '    '    Bind_PDF("PDF_REGISTRATION_ANIMAL.pdf")
    '    'End If
    'End Sub


    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _r_process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_r_process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub

    Private Sub convert_Database_To_XML(ByVal path As String)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(Integer.Parse(_lcn_ida))
        Dim dao_cer As New DAO_DRUG.TB_CER
        dao_cer.GetDataby_FK_IDA(_lcn_ida)
        Dim _product_id As Integer = 0
        Try
            _product_id = ddl_product_id.SelectedValue
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DRUG_REGISTRATION(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao_lcn.fields.lcnno, _r_process, dao_lcn.fields.IDA)
        Dim cls_xml As New CLASS_REGISTRATION



        cls_xml = cls.gen_xml()
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        'Try
        '    cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน
        'Catch ex As Exception

        'End Try

        cls_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(_product_id) 'ข้อมูลที่ดึงมาจาก Product ID


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
        If Request.QueryString("tt") <> "" Then
            Dim dao As New DAO_DRUG.TB_MAS_TAMRAP_NAME
            dao.GetDataby_TAMRAP_ID(ddl_tamrab.SelectedValue)
            cls_xml.DRUG_REGISTRATIONs.DRUG_NAME_THAI = dao.fields.TAMRAP_NAME
        End If
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

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    'Protected Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_REGISTRATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _r_process & "');", True)
    '    ElseIf e.CommandName = "add2" Then
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('" & "FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & str_ID & "');", True)
    '    ElseIf e.CommandName = "choose" Then
    '        Dim url As String = "../TABEAN_YA/TABEAN_YA_MAIN.aspx?main_ida=" & str_ID & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "&lct_ida=" & _lct_ida
    '        If Request.QueryString("staff") <> "" Then
    '            url &= "&staff=1"
    '        End If
    '        Response.Redirect(url)
    '    End If
    'End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        'load_GV_data()
        Rg_regist.Rebind()
    End Sub

    'Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
    '        'Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
    '        Dim btn_Choose As Button = DirectCast(e.Row.FindControl("btn_Choose"), Button)
    '        btn_Choose.Style.Add("display", "none")
    '        btn_Select.Style.Add("display", "none")
    '        'btn_edit.Style.Add("display", "none")
    '        Dim ida As String = GV_data.DataKeys.Item(e.Row.RowIndex).Value.ToString()
    '        'btn_Select.Attributes.Add("onclick", "Popups2('../CHEMICAL/FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE.aspx?IDA=" & ida & "'); return false;")
    '        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
    '        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
    '        Dim lcntpcd As String = ""
    '        Try
    '            dao.GetDataby_IDA(ida)
    '            dao_dal.GetDataby_IDA(dao.fields.FK_IDA)
    '            lcntpcd = dao_dal.fields.lcntpcd
    '        Catch ex As Exception

    '        End Try
    '        Dim count_chem As Integer = 0
    '        Dim count_pro As Integer = 0
    '        Dim dao_chem As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
    '        count_chem = dao_chem.CountDataby_IDA(ida)

    '        If lcntpcd.Contains("ผย") Then
    '            Dim dao_pro As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
    '            count_pro = dao_pro.CountDataby_FK_IDA(ida)
    '        ElseIf lcntpcd.Contains("นย") Then
    '            Dim dao_pro As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
    '            count_pro = dao_pro.CountDataby_FK_IDA(ida)
    '        End If

    '        If count_chem > 0 And count_pro > 0 Then
    '            btn_Select.Style.Add("display", "block")
    '        End If


    '        Try
    '            dao.GetDataby_IDA(ida)
    '            If dao.fields.STATUS_ID = 8 Then
    '                btn_Choose.Style.Add("display", "block")
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        'Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
    '        'dao.GetDataby_IDA(ida)
    '    End If
    'End Sub

    Private Sub Rg_regist_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles Rg_regist.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item

            Dim str_ID As String = item("H_IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao.GetDataby_IDA(str_ID)

            If e.CommandName = "_sel" Then
                dao.GetDataby_IDA(str_ID)
                Dim tr_id As String = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                lbl_head1.Text = "ข้อมูลตำรับ"
                If Request.QueryString("tt") <> "" Then
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('POPUP_REGISTRATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _r_process & "&tt=1');", True)

                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPORT_REGIST.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&staff=1" & "&process=" & _r_process & "&tt=1');", True)
                ElseIf Request.QueryString("staff") = 1 Then
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('POPUP_REGISTRATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _r_process & "');", True)
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPORT_REGIST.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&staff=1" & "&process=" & _r_process & "');", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPORT_REGIST.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _r_process & "');", True)
                End If

            ElseIf e.CommandName = "_add2" Then

                Dim tamrab As String = ""
                Try
                    tamrab = dao.fields.DRUG_EQ_TO
                Catch ex As Exception

                End Try
                lbl_head1.Text = "เพิ่มข้อมูลส่วนที่ 2"
                Try
                    If dao.fields.PROCESS_ID = "130002" Or dao.fields.PROCESS_ID = "130004" Then
                        If Request.QueryString("tt") <> "" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('FRM_REGISTRATION_ANIMAL_DETAIL_OTHER.aspx?IDA=" & str_ID & "&req=1" & "&process=" & _r_process & "&a=1&tt=" & tamrab & "');", True)
                        Else
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('FRM_REGISTRATION_ANIMAL_DETAIL_OTHER.aspx?IDA=" & str_ID & "&req=1" & "&process=" & _r_process & "&a=1');", True)
                        End If
                    Else
                        '
                        If Request.QueryString("tt") <> "" Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & str_ID & "&req=1" & "&process=" & _r_process & "&tt=" & tamrab & "');", True)
                        ElseIf Request.QueryString("staff") = 1 Then
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & str_ID & "&req=1" & "&staff=1" & "&process=" & _r_process & "');", True)
                        Else
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & str_ID & "&req=1" & "&process=" & _r_process & "');", True)
                        End If
                    End If

                Catch ex As Exception

                End Try


            ElseIf e.CommandName = "choose" Then
                Dim url As String = "../TABEAN_YA/TABEAN_YA_MAIN.aspx?main_ida=" & str_ID & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "&lct_ida=" & _lct_ida & "&r_process=" & Request.QueryString("process")
                If Request.QueryString("staff") <> "" Then
                    url &= "&staff=1&identify=" & Request.QueryString("identify")
                End If
                If Request.QueryString("tt") <> "" Then
                    url &= "&tt=" & Request.QueryString("tt")
                End If
                Response.Redirect(url)
            End If
        End If
    End Sub

    Private Sub Rg_regist_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles Rg_regist.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("H_IDA").Text
            Dim btn_Select As LinkButton = DirectCast(item("_sel").Controls(0), LinkButton)
            Dim btn_Choose As LinkButton = DirectCast(item("choose").Controls(0), LinkButton)
            Dim btn_add2 As LinkButton = DirectCast(item("_add2").Controls(0), LinkButton)

            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            Dim dao_ds As New DAO_DRUG.ClsDBdrsamp
            Dim lcntpcd As String = ""
            Try
                dao.GetDataby_IDA(IDA)
                dao_dal.GetDataby_IDA(dao.fields.FK_IDA)
                dao_ds.GetDataby_PRODUCT_ID_IDA(IDA)
                lcntpcd = dao_dal.fields.lcntpcd
                If dao.fields.RCVNO_DISPLAY <> "" Or dao_ds.fields.STATUS_ID = 5 Then
                    btn_add2.Style.Add("display", "none")
                Else
                    btn_add2.Style.Add("display", "block")
                End If

                If dao.fields.STATUS_ID = 8 Then
                    btn_Choose.Style.Add("display", "block")
                Else
                    btn_Choose.Style.Add("display", "none")
                End If


            Catch ex As Exception

            End Try
            Dim count_chem As Integer = 0
            Dim count_pro As Integer = 0
            Dim dao_chem As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
            count_chem = dao_chem.CountDataby_IDA(IDA)

            If lcntpcd.Contains("ผย") Then
                Dim dao_pro As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                count_pro = dao_pro.CountDataby_FK_IDA(IDA)
            ElseIf lcntpcd.Contains("นย") Then
                Dim dao_pro As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
                count_pro = dao_pro.CountDataby_FK_IDA(IDA)
            End If


            If count_chem > 0 And count_pro > 0 Then
                btn_Select.Style.Add("display", "block")

            End If

            If Request.QueryString("tt") <> "" Then
                btn_Select.Text = "ดูข้อมูล/สร้างตำรับ"


                If Request.QueryString("st") = "1" Then
                    btn_add2.Style.Add("display", "none")
                    btn_Choose.Text = "ยบ.8/สร้าง ย.1"
                ElseIf Request.QueryString("st") = "2" Then
                    btn_Choose.Text = "ยบ.8/สร้าง ย.1"
                End If
            End If
            Try
                'dao.GetDataby_IDA(IDA)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Rg_regist_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Rg_regist.NeedDataSource
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        'If _fk_ida <> "" Then
        If Request.QueryString("tt") <> "" Then
            If Request.QueryString("tt") = "2" Then
                'bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_AUTO(_lcn_ida, _r_process)
                Try
                    bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_AUTO_SUBTYPE(_lcn_ida, _r_process, Request.QueryString("st"))
                Catch ex As Exception

                End Try

            Else
                bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_ONE_DAY(_lcn_ida, _r_process)
            End If

        Else
            bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID(_lcn_ida, _r_process)
        End If
        Try
            Rg_regist.DataSource = bao_DB.dt
        Catch ex As Exception

        End Try

    End Sub

End Class