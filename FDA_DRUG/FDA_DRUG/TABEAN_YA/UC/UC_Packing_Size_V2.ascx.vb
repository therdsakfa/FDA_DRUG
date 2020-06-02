Imports System.Xml
Imports System.Xml.Serialization
Imports FDA_DRUG
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Imports System.IO

Public Class UC_Packing_Size_V2
    Inherits System.Web.UI.UserControl

    Private _CLS As CLS_SESSION
    Public _process As String
    Private _main_ida As String
    Private main_ida As Integer
    Private _sunit_ida As Integer
    Private _lcn_ida As String
    Private _write_at As String
    Private _phesaj As String
    Private _forother As String
    Private _req As String
    Dim STATUS_ID As Integer = 0

    Sub RunQuery()

        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If

        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        RunQuery()
        Dim dao_u As New DAO_DRUG.TB_DRUG_UNIT
        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                dao_u.GetDataby_sunitcd(dao.fields.UNIT_NORMAL)
                lbl_small_unit.Text = dao_u.fields.unit_name
            Catch ex As Exception

            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                dao_u.GetDataby_sunitcd(dao.fields.UNIT_NORMAL)
                lbl_small_unit.Text = dao_u.fields.unit_name
            Catch ex As Exception

            End Try
        End If


        If Not IsPostBack Then
            lbl_sunit_ida.Text = ""
            bind_ddl_unit()
            set_label()

            If _req <> "" Then
                btn_back.Style.Add("display", "none")
                lbl_head.Text = "ขนาดบรรจุ"
            Else
                lbl_head.Text = "เพิ่ม/ลบขนาดบรรจุสำหรับยาตัวอย่าง"
            End If

            If Request.QueryString("tt") <> "" Then
                btn_add.Enabled = False
                btn_eddt.Enabled = False
                btn_edre.Enabled = False
            End If
            'If STATUS_ID = 8 Then
            '    btn_add.Enabled = False
            '    btn_eddt.Enabled = False
            '    btn_edre.Enabled = False
            'End If
        End If
    End Sub

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _req = Request.QueryString("req")
                Try
                    _main_ida = Request.QueryString("IDA") 'Request("main_ida").ToString()
                    main_ida = CInt(_main_ida)
                Catch ex As Exception
                End Try
                Try
                    _process = Request("process").ToString()
                Catch ex As Exception
                End Try
                Try
                    _sunit_ida = Request("sunit_ida").ToString()
                Catch ex As Exception
                End Try
                Try
                    _lcn_ida = Request("lcn_ida").ToString()
                Catch ex As Exception

                End Try
                Try
                    _write_at = Request("write_at").ToString()
                Catch ex As Exception

                End Try
                Try
                    _phesaj = Request("phesaj").ToString()
                Catch ex As Exception
                End Try
                Try
                    _forother = Request("forother").ToString()
                Catch ex As Exception
                End Try

            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim cls_session As New CLS_SESSION
        cls_session.IDA = main_ida
        cls_session.PVCODE = "6"
        Session.Add("product_id", cls_session)
        If lbl_sunit_ida.Text = "" Then
            btn_eddt.Visible = False
            btn_edre.Visible = False
            btn_add.Visible = True
        Else
            btn_eddt.Visible = True
            btn_edre.Visible = True
            btn_add.Visible = False
        End If
    End Sub
    Public Sub set_label() 'ดึงข้อมูลแสดง
        RunQuery()
        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(Request.QueryString("IDA"))

            Dim dao_rq As New DAO_DRUG.ClsDBdrrgt
            dao_rq.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao_package As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_package.GetDataby_FKIDA(dao_rq.fields.IDA)
            Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
            Try
                dao_unit.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
                lbl_sunit.Text = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
            Catch ex As Exception
            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao_package As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
            dao_package.GetDataby_FKIDA(dao.fields.IDA)
            Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
            Try
                dao_unit.GetDataby_sunitcd(dao_package.fields.SMALL_UNIT)
                lbl_sunit.Text = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
            Catch ex As Exception
            End Try
        End If

    End Sub
    Protected Sub ddl_munit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_munit.SelectedIndexChanged
        lbl_munit.Text = ddl_munit.SelectedItem.Text
    End Sub

    Private Sub RadGrid80_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid80.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        RunQuery()

        If STATUS_ID = 8 Then
            dt = bao.SP_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(main_ida)
        Else
            dt = bao.SP_DRRQT_PACKAGE_DETAIL_BY_FK_IDA(main_ida)
        End If

        RadGrid80.DataSource = dt
    End Sub
    Public Sub bind_ddl_unit() 'เลือกหน่วยขนาดบรรจุ
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'dt = bao.SP_MAS_UNIT_CONTAIN

        Dim item As New ListItem("-", "0")

        'ddl_munit.DataSource = dt
        'ddl_munit.DataTextField = "unitnm"
        'ddl_munit.DataValueField = "IDA"
        'ddl_munit.DataBind()

        'ddl_bunit.DataSource = dt
        'ddl_bunit.DataTextField = "unitnm"
        'ddl_bunit.DataValueField = "IDA"
        'ddl_bunit.DataBind()


        dt = bao.SP_MASTER_drsunit()
        ddl_bunit.DataSource = dt
        ddl_bunit.DataTextField = "sunitengnm"
        ddl_bunit.DataValueField = "sunitcd"
        ddl_bunit.DataBind()
        'ddl_munit.Items.Insert(0, item)
        ' ddl_bunit.Items.Insert(0, item)

        dt = bao.SP_MASTER_drsunit()
        ddl_munit.DataSource = dt
        ddl_munit.DataTextField = "sunitengnm"
        ddl_munit.DataValueField = "sunitcd"
        ddl_munit.DataBind()
        ' ddl_munit.Items.Insert(0, item)

    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click 'ปุ่มเพิ่มขนาดบรรจุ
        If main_ida = 0 Then
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
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกGTIN');", True)
            'ElseIf ddl_snunit.SelectedValue = 0 Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกหน่วยนับตามรูปแบบยา');", True)
        Else
            RunQuery()
            If STATUS_ID = 8 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(main_ida)
                Dim dao As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
                'Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                'Try
                '    dao_drugname.GetDataby_IDA(dao.fields.FK_IDA)
                'Catch ex As Exception

                'End Try

                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.SMALL_UNIT = dao_rg.fields.UNIT_NORMAL '_sunit_ida            'เลือกขนาดของหน่วยเล็ก
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue 'lbl_small_unit.Text  'เลือกขนาดของหน่วยกลาง
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ

                    dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
                Catch ex As Exception
                End Try


                'End Try
                Try
                    dao.fields.FK_IDA = Request.QueryString("IDA") 'dao_drugname.fields.IDA
                Catch ex As Exception

                End Try

                dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
                dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
                Try
                    dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
                Catch ex As Exception
                    dao.fields.MEDIUM_AMOUNT = 1
                End Try

                dao.fields.BIG_AMOUNT = 1
                dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
                dao.fields.DATE_ADD = Date.Now
                dao.insert()

                'Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                'dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))

                Dim dao_dr As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                dao_dr.GetDataby_FKIDA(Request.QueryString("IDA"))
                Dim max_no As Integer = 0
                Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
                dao_edt.GET_MAX_NO("DRRGT_PACKAGE_DETAIL", dao_dr.fields.IDA)
                Try
                    max_no = dao_edt.fields.COUNT_EDIT
                Catch ex As Exception

                End Try
                'Dim filename As String = ""
                'filename = "DRRGT_PACKAGE_DETAIL_" & dao_rg.fields.TR_ID & "_" & max_no + 1 & ".xml"
                'Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
                'bao_app.RunAppSettings()
                'Dim path As String = bao_app._PATH_EDIT & filename
                'Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
                'Dim x As New XmlSerializer(dao_dr.fields.GetType)                                                     'ประกาศ
                'x.Serialize(objStreamWriter, dao_dr.fields)
                'objStreamWriter.Close()

                'Dim dao_index As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
                'With dao_index.fields
                '    .COUNT_EDIT = max_no + 1
                '    .CREATE_DATE = Date.Now
                '    .FILE_NAME = filename
                '    .FK_DRRGT_IDA = Request.QueryString("IDA")
                '    .FK_IDA = dao_dr.fields.IDA
                '    .TABLE_NAME = "DRRGT_PACKAGE_DETAIL"
                '    .TR_ID = dao_rg.fields.TR_ID
                'End With
                'dao_index.insert()

                KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "เพิ่มขนาดบรรจุ", _CLS.CITIZEN_ID)
                Dim dao_re As New DAO_DRUG.ClsDBdrrgt
                dao_re.GetDataby_IDA(Request.QueryString("IDA"))
                'Dim ws_drug As New WS_DRUG.WS_DRUG
                'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)
                If STATUS_ID = 8 Then
                    Dim old_data As String = ""
                    Dim new_data As String = "เพิ่มขนาดบรรจุ IDA :" & dao.fields.IDA

                    Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                    dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))

                    Dim result As String = ""
                    Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                    result = ""
                    If Request.QueryString("e") <> "" Then
                        result = "EDIT RQT"
                    End If
                    Try
                        If Request.QueryString("e") = "" Then
                            ws_drug.Timeout = 8000
                            'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)

                            Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                            dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                            Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                            Dim cls_xml_DR As New LGT_IOW_E
                            cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                            Dim str_xml As String = ""
                            Try
                                Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                                dao1.GetDataby_IDA(Request.QueryString("IDA"))
                                SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao1.fields.IDENTIFY)

                                ws_drug.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                            Catch ex As Exception

                            End Try

                        End If

                    Catch ex As Exception
                        result = "FAIL"
                    End Try
                    Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                    KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                        dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                End If
            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
                'Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                'dao_drugname.GetDataby_IDA(main_ida)
                Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                dao_rg.GetDataby_IDA(main_ida)
                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.SMALL_UNIT = dao_rg.fields.UNIT_NORMAL '_sunit_ida            'เลือกขนาดของหน่วยเล็ก
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue 'lbl_small_unit.Text  'เลือกขนาดของหน่วยกลาง
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ

                    dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
                Catch ex As Exception
                End Try


                'End Try
                Try
                    dao.fields.FK_IDA = Request.QueryString("IDA") 'dao_drugname.fields.IDA
                Catch ex As Exception

                End Try

                dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
                dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
                Try
                    dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
                Catch ex As Exception
                    dao.fields.MEDIUM_AMOUNT = 1
                End Try

                dao.fields.BIG_AMOUNT = 1
                dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
                dao.fields.DATE_ADD = Date.Now
                dao.insert()
            End If


            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เพิ่มข้อมูลขนาดบรรจุเรียบร้อย');", True)
            RadGrid80.Rebind()
        End If
    End Sub

    Protected Sub btn_eddt_Click(sender As Object, e As EventArgs) Handles btn_eddt.Click 'ปุ่มเพิ่มขนาดบรรจุ
        If main_ida = 0 Then
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
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกGTIN');", True)
            'ElseIf ddl_snunit.SelectedValue = 0 Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกหน่วยนับตามรูปแบบยา');", True)
        Else
            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
                dao.GetDataby_IDA(lbl_sunit_ida.Text)
                'Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                'dao_drugname.GetDataby_IDA(main_ida)
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(main_ida)
                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.SMALL_UNIT = dao_rg.fields.UNIT_NORMAL '_sunit_ida            'เลือกขนาดของหน่วยเล็ก
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue 'lbl_small_unit.Text  'เลือกขนาดของหน่วยกลาง
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ

                    dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
                Catch ex As Exception
                End Try
                lbl_munit.Text = dao.fields.MEDIUM_UNIT

                'End Try
                Try
                    dao.fields.FK_IDA = dao_rg.fields.IDA
                Catch ex As Exception

                End Try

                dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
                dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
                Try
                    dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
                Catch ex As Exception
                    dao.fields.MEDIUM_AMOUNT = 1
                End Try

                dao.fields.BIG_AMOUNT = 1
                dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
                dao.fields.DATE_ADD = Date.Now
                dao.update()
            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
                dao.GetDataby_IDA(lbl_sunit_ida.Text)
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(main_ida)
                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.SMALL_UNIT = dao_rg.fields.UNIT_NORMAL '_sunit_ida            'เลือกขนาดของหน่วยเล็ก
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ
                    dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue 'lbl_small_unit.Text  'เลือกขนาดของหน่วยกลาง
                Catch ex As Exception
                End Try
                Try 'ปุ่มเพิ่มขนาดบรรจุ

                    dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
                Catch ex As Exception
                End Try
                lbl_munit.Text = dao.fields.MEDIUM_UNIT

                'End Try
                Try
                    dao.fields.FK_IDA = dao_rg.fields.IDA
                Catch ex As Exception

                End Try

                dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
                dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
                Try
                    dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
                Catch ex As Exception
                    dao.fields.MEDIUM_AMOUNT = 1
                End Try

                dao.fields.BIG_AMOUNT = 1
                dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
                dao.fields.DATE_ADD = Date.Now
                dao.update()
            End If


            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลขนาดบรรจุเรียบร้อย');", True)
            lbl_sunit_ida.Text = ""
            lbl_munit.Text = ""
            txt_barcode.Text = ""
            txt_mamount.Text = ""
            txt_sunit.Text = ""
            txt_packagename.Text = ""
            RunSession()
            bind_ddl_unit()
            set_label()
            RadGrid80.Rebind()

        End If
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url As String = ""
        If _process = "1701" Then
            url = "../DS/FRM_DS_PORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj & "&forother=" & _forother
        ElseIf _process = "1702" Then
            url = "../DS/FRM_DS_NORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        ElseIf _process = "1703" Then
            url = "../DS/FRM_DS_PORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        ElseIf _process = "1704" Then
            url = "../DS/FRM_DS_NORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        ElseIf _process = "1705" Then
            url = "../DS/FRM_DS_PORYOR8(YAVEJAI).aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        End If
        Response.Redirect(url)

    End Sub
    Private Sub RadGrid80_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid80.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else
                    If STATUS_ID = 8 Then
                        Dim dao As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                        dao.GetDataby_IDA(item("IDA").Text)
                        'dao.GetDataAll()
                        dao.delete()

                        If STATUS_ID = 8 Then
                            Dim old_data As String = "ลบขนาดบรรจุ : " & item("PACKAGE_NAME").Text
                            Dim new_data As String = ""

                            Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                            dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))

                            Dim result As String = ""
                            Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                            result = ""
                            If Request.QueryString("e") <> "" Then
                                result = "EDIT RQT"
                            End If
                            Try
                                If Request.QueryString("e") = "" Then
                                    ws_drug.Timeout = 8000
                                    'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)

                                    Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                                    dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                                    Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                                    Dim cls_xml_DR As New LGT_IOW_E
                                    cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                                    Dim str_xml As String = ""
                                    Try
                                        Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                                        dao1.GetDataby_IDA(Request.QueryString("IDA"))
                                        SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao1.fields.IDENTIFY)

                                        ws_drug.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                                    Catch ex As Exception

                                    End Try
                                End If

                            Catch ex As Exception
                                result = "FAIL"
                            End Try
                            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                            KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                                dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                        End If
                    Else
                        Dim dao As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
                        dao.GetDataby_IDA(item("IDA").Text)
                        'dao.GetDataAll()
                        dao.delete()
                    End If
                    'ลบข้อมูลในตารางขนาดบรรจุ
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                    RadGrid80.Rebind()
                End If

            ElseIf e.CommandName = "eddt" Then
                If STATUS_ID = 8 Then
                    Dim dao As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                    dao.GetDataby_IDA(item("IDA").Text)
                    txt_packagename.Text = dao.fields.PACKAGE_NAME
                    txt_sunit.Text = dao.fields.SMALL_AMOUNT
                    ddl_munit.SelectedValue = dao.fields.MEDIUM_UNIT
                    lbl_munit.Text = ddl_munit.SelectedItem.Text
                    Try
                        txt_mamount.Text = dao.fields.MEDIUM_AMOUNT
                    Catch ex As Exception
                        txt_mamount.Text = 1
                    End Try
                    Try
                        ddl_bunit.SelectedValue = dao.fields.BIG_UNIT
                    Catch ex As Exception
                    End Try
                    txt_barcode.Text = dao.fields.BARCODE
                Else
                    Dim dao As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
                    dao.GetDataby_IDA(item("IDA").Text)
                    txt_packagename.Text = dao.fields.PACKAGE_NAME
                    txt_sunit.Text = dao.fields.SMALL_AMOUNT
                    ddl_munit.SelectedValue = dao.fields.MEDIUM_UNIT
                    lbl_munit.Text = ddl_munit.SelectedItem.Text
                    Try
                        txt_mamount.Text = dao.fields.MEDIUM_AMOUNT
                    Catch ex As Exception
                        txt_mamount.Text = 1
                    End Try
                    Try
                        ddl_bunit.SelectedValue = dao.fields.BIG_UNIT
                    Catch ex As Exception
                    End Try
                    txt_barcode.Text = dao.fields.BARCODE
                End If

                lbl_sunit_ida.Text = item("IDA").Text
                RunSession()
            End If
        End If
    End Sub

    Protected Sub btn_edre_Click(sender As Object, e As EventArgs) Handles btn_edre.Click
        lbl_sunit_ida.Text = ""
        RunSession()
        bind_ddl_unit()
        set_label()

    End Sub
End Class