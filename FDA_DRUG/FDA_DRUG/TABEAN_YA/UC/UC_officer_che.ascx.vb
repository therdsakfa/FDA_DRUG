Imports System.IO
Imports System.Xml.Serialization
Imports System.Globalization
Imports System.Xml
Imports Telerik.Web.UI
Public Class UC_officer_che
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Dim STATUS_ID As String = "0"
    Private _CLS As New CLS_SESSION
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
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
        RunQuery()
        If Not IsPostBack Then
            set_hide()
            If Request.QueryString("tt") <> "" Then
                btn_rows_save.Enabled = False
                btn_select.Enabled = False
                btn_save.Enabled = False

            End If

            'If STATUS_ID = 8 Then
            '    btn_rows_save.Enabled = False
            '    btn_select.Enabled = False
            '    btn_save.Enabled = False

            'End If
        End If
    End Sub
    
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Sub get_data_drgperunit()
        RunQuery()
        If STATUS_ID = 8 Then
            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            dao1.GetDataby_FK_DRRQT(_IDA)
            Dim dao As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
            dao.GetDataby_FKIDA(dao1.fields.IDA)
            'Try
            '    txt_drg_perunit.Text = dao.fields.QTY
            'Catch ex As Exception

            'End Try

            'Try
            '    ddl_unit1.DropDownSelectData(dao.fields.SUNITCD)
            'Catch ex As Exception

            'End Try


            'Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            'dao_cas.GetDataby_IDA(_IDA)
            'txt_ref.Text = dao_cas.fields.REF
            'txt_remark.Text = dao_cas.fields.REMARK
        Else
            'Dim dao_cas As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
            'dao_cas.GetDataby_IDA(_IDA)
            'txt_ref.Text = dao_cas.fields.REF
            'txt_remark.Text = dao_cas.fields.REMARK
            'Dim dao As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
            'dao.GetDataby_FKIDA(_IDA)
            'Try
            '    txt_drg_perunit.Text = dao.fields.QTY
            'Catch ex As Exception

            'End Try

            'Try
            '    ddl_unit1.DropDownSelectData(dao.fields.SUNITCD)
            'Catch ex As Exception

            'End Try
        End If
    End Sub

    Private Sub rg_chem_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_chem.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                    'ElseIf STATUS_ID = 8 Then
                    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else
                    If STATUS_ID = 8 Then
                        Dim old_data As String = ""
                        Dim new_data As String = ""
                        Dim FK_SET As Integer = 0
                        Dim dao As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                        dao.GetDataby_IDA(IDA)
                        FK_SET = dao.fields.FK_SET
                        old_data = "ลบสาร : " & dao.fields.IOWA
                        
                        dao.delete()
                        If STATUS_ID = 8 Then
                            Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                            dao_rg2.GetDataby_IDA(Request.QueryString("idr"))

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

                            End Try
                            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                            KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                                dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                        End If
                        dao = New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                        dao.GetDataby_FK_IDA_ORDER(_IDA, FK_SET)
                        Dim i As Integer = 1
                        For Each dao.fields In dao.datas
                            Dim dao_up As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                            dao_up.GetDataby_IDA(dao.fields.IDA)
                            dao_up.fields.ROWS = i
                            dao_up.update()
                            i += 1
                        Next

                    Else
                        Dim FK_SET As Integer = 0
                        Dim dao As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                        dao.GetDataby_IDA(IDA)
                        FK_SET = dao.fields.FK_SET
                        dao.delete()

                        dao = New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                        dao.GetDataby_FK_IDA_ORDER(_IDA, FK_SET)
                        Dim i As Integer = 1
                        For Each dao.fields In dao.datas
                            Dim dao_up As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                            dao_up.GetDataby_IDA(dao.fields.IDA)
                            dao_up.fields.ROWS = i
                            dao_up.update()
                            i += 1
                        Next
                    End If

                    rg_chem.Rebind()
                End If
            ElseIf e.CommandName = "_eqto" Then
                Dim url As String = "../TABEAN_YA/FRM_EQTO.aspx?IDA=" & IDA & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&idr=" & _IDA & "&STATUS_ID=" & STATUS_ID & "&fk_set=" & item("FK_SET").Text
                If Request.QueryString("e") <> "" Then
                    url &= "&e=1"
                End If
                Response.Redirect(url)
            End If

            End If
    End Sub

    Private Sub rg_chem_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_chem.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim lbl_rows As Label = DirectCast(item("ROWS").FindControl("lbl_rows"), Label)
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)

            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                dao.GetDataby_IDA(item("IDA").Text)
                Try
                    txt_rows.Text = dao.fields.ROWS

                Catch ex As Exception

                End Try
                Try
                    lbl_rows.Text = dao.fields.ROWS

                Catch ex As Exception

                End Try
            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                dao.GetDataby_IDA(item("IDA").Text)
                Try
                    txt_rows.Text = dao.fields.ROWS

                Catch ex As Exception

                End Try
                Try

                     lbl_rows.Text = dao.fields.ROWS
                Catch ex As Exception

                End Try
            End If

        End If
    End Sub
    

    Private Sub rg_chem_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_chem.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        RunQuery()
        If STATUS_ID = 8 Then
            'Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            'dao1.GetDataby_FK_DRRQT(_IDA)
            'dt = bao.SP_DRRGT_DETAIL_CAS_BY_FK_IDAV2(_IDA)
            dt = bao.SP_DRRGT_DETAIL_CAS_BY_FK_IDAV3(_IDA, ddl_set.SelectedValue)
        Else
            'dt = bao.SP_DRRQT_DETAIL_CAS_BY_FK_IDAV2(_IDA)
            dt = bao.SP_DRRQT_DETAIL_CAS_BY_FK_IDAV3(_IDA, ddl_set.SelectedValue)
        End If

        rg_chem.DataSource = dt
    End Sub
    Public Sub get_data_head()
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA)
        Try
            'txt_quantity.Text = dao.fields.
        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_unit1()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit1.DataSource = dt
        'ddl_unit1.DataTextField = "sunitnmsht"
        'ddl_unit1.DataValueField = "sunitcd"
        'ddl_unit1.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit2()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit2.DataSource = dt
        ddl_unit2.DataTextField = "sunitnmsht"
        ddl_unit2.DataValueField = "sunitcd"
        ddl_unit2.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit2.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit3()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit3.DataSource = dt
        ddl_unit3.DataTextField = "sunitnmsht"
        ddl_unit3.DataValueField = "sunitcd"
        ddl_unit3.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit3.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit4()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit4.DataSource = dt
        ddl_unit4.DataTextField = "sunitnmsht"
        ddl_unit4.DataValueField = "sunitcd"
        ddl_unit4.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit4.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit.DataSource = dt
        ddl_unit.DataTextField = "sunitnmsht"
        ddl_unit.DataValueField = "sunitcd"
        ddl_unit.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit_head()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit_head.DataSource = dt
        'ddl_unit_head.DataTextField = "sunitnmsht"
        'ddl_unit_head.DataValueField = "sunitcd"
        'ddl_unit_head.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit_head.Items.Insert(0, item)
    End Sub
    Private Sub rg_search_iowa_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_search_iowa.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        If txt_search.Text <> "" Then
            dt = bao.SP_DRIOWA_SEARCH_RESULT(txt_search.Text)
        End If

        rg_search_iowa.DataSource = dt
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        rg_search_iowa.Rebind()
    End Sub

    Protected Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        'If ddl_unit.SelectedValue <> 0 And txt_QTY.Text <> "" Then
        If STATUS_ID = 8 Then
            For Each item As GridDataItem In rg_search_iowa.SelectedItems
                Dim old_data As String = ""
                Dim new_data As String = ""
                Dim dao As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                dao.fields.IOWA = item("iowacd").Text
                Try
                    dao.fields.IOWANM = item("iowanm").Text
                Catch ex As Exception

                End Try
                If Trim(txt_QTY.Text) = "" Then
                    dao.fields.QTY = "0"
                Else
                    dao.fields.QTY = txt_QTY.Text
                End If

                dao.fields.AORI = ddl_aori.SelectedItem.Text
                dao.fields.FK_IDA = _IDA
                Try
                    dao.fields.ebioqty = txt_ebioqty.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.FK_SET = ddl_set.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.SUNITCD = ddl_unit.SelectedValue
                Catch ex As Exception

                End Try

                Try
                    dao.fields.ebiosqno = txt_ebiosqno.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ebiounitcd = ddl_unit3.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CAS_TYPE = ddl_CAS_TYPE.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CONDITION = ddl_remark1.SelectedItem.Text
                Catch ex As Exception

                End Try

                Try
                    dao.fields.sbioqty = txt_sbioqty.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbiosqno = txt_sbiosqno.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbiounitcd = ddl_unit2.SelectedValue
                Catch ex As Exception

                End Try
                Dim dao_max As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                dao_max.GET_MAX_ROWS_ID_SET(_IDA, ddl_set.SelectedValue)
                Dim id_max As Integer = 0
                Try
                    id_max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                Try
                    dao.fields.REF = txt_ref.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.REMARK = txt_remark.Text
                Catch ex As Exception

                End Try
                dao.fields.ROWS = txt_ROWS.Text 'id_max + 1
                new_data = "เพิ่มสาร : " & item("iowacd").Text

                dao.insert()

                If STATUS_ID = 8 Then
                    Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                    dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))

                    Dim result As String = ""
                    Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                    result = ""
                    Try
                        ws_drug.Timeout = 8000
                        result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)
                    Catch ex As Exception

                    End Try
                    Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                    KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                        dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                End If

            Next

            Dim dao_dr As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_dr.GetDataby_FKIDA(Request.QueryString("IDA"))
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_DETAIL_CAS", dao_dr.fields.IDA)

            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try
            'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            'dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim filename As String = ""
            'filename = "DRRGT_DETAIL_CAS_" & dao_rg.fields.TR_ID & "_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "DRRGT_DETAIL_CAS"
            '    .TR_ID = dao_rg.fields.TR_ID
            'End With
            'dao_index.insert()

            'Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            'dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)
        Else
            For Each item As GridDataItem In rg_search_iowa.SelectedItems
                Dim dao As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                dao.fields.IOWA = item("iowacd").Text
                Try
                    dao.fields.IOWANM = item("iowanm").Text
                Catch ex As Exception

                End Try
                If Trim(txt_QTY.Text) = "" Then
                    dao.fields.QTY = "0"
                Else
                    Try
                        dao.fields.QTY = txt_QTY.Text.Replace(",", "")
                    Catch ex As Exception
                        dao.fields.QTY = txt_QTY.Text
                    End Try

                End If
                If Trim(txt_QTY2.Text) = "" Then
                    dao.fields.QTY2 = "0"
                Else
                    Try
                        dao.fields.QTY2 = txt_QTY2.Text.Replace(",", "")
                    Catch ex As Exception
                        dao.fields.QTY2 = txt_QTY2.Text
                    End Try

                End If
                dao.fields.AORI = ddl_aori.SelectedItem.Text
                dao.fields.FK_IDA = _IDA
                Try
                    dao.fields.FK_SET = ddl_set.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ebioqty = txt_ebioqty.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ebiosqno = txt_ebiosqno.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ebiounitcd = ddl_unit3.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CAS_TYPE = ddl_CAS_TYPE.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CONDITION = ddl_remark1.SelectedItem.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.SUNITCD = ddl_unit.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.SUNITCD2 = ddl_unit4.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbioqty = txt_sbioqty.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbiosqno = txt_sbiosqno.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbiounitcd = ddl_unit2.SelectedValue
                Catch ex As Exception

                End Try
                Dim dao_max As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                dao_max.GET_MAX_ROWS_ID_SET(_IDA, ddl_set.SelectedValue)
                Dim id_max As Integer = 0
                Try
                    id_max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                Try
                    dao.fields.REF = txt_ref.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.REMARK = txt_remark.Text
                Catch ex As Exception

                End Try
                dao.fields.ROWS = txt_ROWS.Text 'id_max + 1
                dao.insert()
            Next
        End If

        rg_chem.Rebind()
        'Else
        '    alert("กรุณากรอกข้อมูลให้ครบ")
        'End If

    End Sub

    'Protected Sub btn_drg_per_unit_Click(sender As Object, e As EventArgs) Handles btn_drg_per_unit.Click
    '    If Request.QueryString("type") = "rg" And STATUS_ID = 8 Then
    '        Dim i As Integer = 0
    '        Dim dao_c As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
    '        i = dao_c.COUNT_ROW(_IDA)
    '        If i = 0 Then
    '            Dim dao As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
    '            dao.fields.FK_IDA = _IDA
    '            Try
    '                dao.fields.QTY = txt_drg_perunit.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.fields.SUNITCD = ddl_unit1.SelectedValue
    '            Try
    '                dao.fields.drugperunit = txt_drg_perunit.Text & " " & ddl_unit1.SelectedItem.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.insert()
    '        Else
    '            Dim dao As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
    '            dao.GetDataby_FKIDA(_IDA)
    '            dao.fields.FK_IDA = _IDA
    '            Try
    '                dao.fields.QTY = txt_drg_perunit.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.fields.SUNITCD = ddl_unit1.SelectedValue
    '            Try
    '                dao.fields.drugperunit = txt_drg_perunit.Text & " " & ddl_unit1.SelectedItem.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.update()
    '        End If
    '    Else
    '        Dim i As Integer = 0
    '        Dim dao_c As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
    '        i = dao_c.COUNT_ROW(_IDA)
    '        If i = 0 Then
    '            Dim dao As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
    '            dao.fields.FK_IDA = _IDA
    '            Try
    '                dao.fields.QTY = txt_drg_perunit.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.fields.SUNITCD = ddl_unit1.SelectedValue
    '            Try
    '                dao.fields.drugperunit = txt_drg_perunit.Text & " " & ddl_unit1.SelectedItem.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.insert()
    '        Else
    '            Dim dao As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
    '            dao.GetDataby_FKIDA(_IDA)
    '            dao.fields.FK_IDA = _IDA
    '            Try
    '                dao.fields.QTY = txt_drg_perunit.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.fields.SUNITCD = ddl_unit1.SelectedValue
    '            Try
    '                dao.fields.drugperunit = txt_drg_perunit.Text & " " & ddl_unit1.SelectedItem.Text
    '            Catch ex As Exception

    '            End Try
    '            dao.update()
    '        End If
    '    End If
    'End Sub

    Private Sub ddl_CAS_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CAS_TYPE.SelectedIndexChanged
        set_hide()
    End Sub

    Sub set_hide()
        Dim cas_type As Integer = ddl_CAS_TYPE.SelectedValue
        If cas_type = 1 Then
            txt_QTY.Enabled = True
            ddl_unit.Enabled = True
            ddl_remark1.Enabled = True

            txt_sbioqty.Enabled = False
            ddl_unit2.Enabled = False
            txt_sbiosqno.Enabled = False
            txt_ebioqty.Enabled = False
            ddl_unit3.Enabled = False
            txt_ebiosqno.Enabled = False
        Else
            txt_QTY.Enabled = False
            ddl_unit.Enabled = False
            ddl_remark1.Enabled = False

            txt_sbioqty.Enabled = True
            ddl_unit2.Enabled = True
            txt_sbiosqno.Enabled = True
            txt_ebioqty.Enabled = True
            ddl_unit3.Enabled = True
            txt_ebiosqno.Enabled = True
        End If
    End Sub


    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If STATUS_ID = 8 Then
            Dim old_data As String = ""
            Dim new_data As String = ""
            Dim dao_count As New DAO_DRUG.TB_DRRGT_EACH
            Dim i As Integer = 0
            i = dao_count.CountDataby_FK_IDA(Request.QueryString("IDA"))
            If i = 0 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_EACH
                dao.fields.EACH_AMOUNT = txt_each.Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.fields.sunitcd = ddl_unit_each.SelectedValue
                dao.fields.FK_SET = ddl_set_each.SelectedValue
                new_data = "เพิ่มปริมาณยาต่อ 1 หน่วย : " & txt_each.Text & " " & ddl_unit_each.SelectedItem.Text & "(สูตรที่ " & ddl_set_each.SelectedValue & ")"
                dao.insert()
            Else
                Dim dao As New DAO_DRUG.TB_DRRGT_EACH
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                Try
                    old_data = "ปริมาณยาต่อ 1 หน่วย : " & dao.fields.EACH_AMOUNT & " " & dao.fields.sunitcd & "(สูตรที่ " & dao.fields.FK_SET & ")"
                Catch ex As Exception

                End Try

                dao.fields.EACH_AMOUNT = txt_each.Text
                dao.fields.sunitcd = ddl_unit_each.SelectedValue
                dao.fields.FK_SET = ddl_set_each.SelectedValue
                new_data = "แก้ไขปริมาณยาต่อ 1 หน่วย : " & txt_each.Text & " " & ddl_unit_each.SelectedItem.Text & "(สูตรที่ " & ddl_set_each.SelectedValue & ")"
                dao.update()
            End If

            'Dim dao_dr As New DAO_DRUG.TB_DRRGT_EACH
            'dao_dr.GetDataby_FK_IDA(Request.QueryString("IDA"))
            'Dim max_no As Integer = 0
            'Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            'dao_edt.GET_MAX_NO("DRRGT_EACH", dao_dr.fields.IDA)
            'Try
            '    max_no = dao_edt.fields.COUNT_EDIT
            'Catch ex As Exception

            'End Try
            'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            'dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim filename As String = ""
            'filename = "DRRGT_EACH_" & dao_rg.fields.TR_ID & "_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "DRRGT_EACH"
            '    .TR_ID = dao_rg.fields.TR_ID
            'End With
            'dao_index.insert()
            'Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            'dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)

            If STATUS_ID = 8 Then
                Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))

                Dim result As String = ""
                Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
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

                End Try
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                    dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

            End If

        Else
            Dim dao_count As New DAO_DRUG.TB_DRRQT_EACH
            Dim i As Integer = 0
            i = dao_count.CountDataby_FK_IDA(Request.QueryString("IDA"))
            If i = 0 Then
                Dim dao As New DAO_DRUG.TB_DRRQT_EACH
                dao.fields.EACH_AMOUNT = txt_each.Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.fields.sunitcd = ddl_unit_each.SelectedValue
                dao.fields.FK_SET = ddl_set_each.SelectedValue
                dao.fields.EACH_TXT = txt_each_txt.Text
                dao.insert()

            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_EACH
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                dao.fields.EACH_AMOUNT = txt_each.Text
                dao.fields.sunitcd = ddl_unit_each.SelectedValue
                dao.fields.FK_SET = ddl_set_each.SelectedValue
                dao.fields.EACH_TXT = txt_each_txt.Text
                dao.update()
            End If
        End If

        alert("บันทึกเรียบร้อย")
        bind_lbl()
    End Sub
    Sub bind_lbl()
        RunQuery()
        Try
            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_EACH
                dao.GetDataby_FK_IDA_AND_SET(Request.QueryString("IDA"), ddl_set_each.SelectedValue)
                Dim dao_u As New DAO_DRUG.TB_drsunit
                dao_u.GetDataby_sunitcd(dao.fields.sunitcd)
                Try
                    lbl_each.Text = "Each " & dao.fields.EACH_AMOUNT & " " & dao_u.fields.sunitengnm & " Contains;"


                Catch ex As Exception

                End Try
                Try
                    If Len(Trim(lbl_each.Text)) = 0 Then
                        lbl_each.Text = dao.fields.EACH_TXT
                    End If
                Catch ex As Exception

                End Try
            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_EACH
                dao.GetDataby_FK_IDA_AND_SET(Request.QueryString("IDA"), ddl_set_each.SelectedValue)
                Dim dao_u As New DAO_DRUG.TB_drsunit
                Try
                    dao_u.GetDataby_sunitcd(dao.fields.sunitcd)
                    lbl_each.Text = "Each " & dao.fields.EACH_AMOUNT & " " & dao_u.fields.sunitengnm & " Contains;"
                Catch ex As Exception

                End Try
                Try
                    If Len(Trim(lbl_each.Text)) = 0 Then
                        lbl_each.Text = dao.fields.EACH_TXT
                    End If
                Catch ex As Exception

                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_unit_each()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit.DataSource = dt
        'ddl_unit.DataTextField = "sunitnmsht"
        'ddl_unit.DataValueField = "sunitcd"
        'ddl_unit.DataBind()


        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        ddl_unit_each.DataSource = dt
        ddl_unit_each.DataTextField = "unit_name"
        ddl_unit_each.DataValueField = "sunitcd"
        ddl_unit_each.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit.Items.Insert(0, item)
    End Sub

    Private Sub ddl_set_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_set.SelectedIndexChanged
        rg_chem.Rebind()
    End Sub

    Private Sub btn_up_Click(sender As Object, e As EventArgs) Handles btn_up.Click
        If STATUS_ID = 8 Then
            For Each item As GridDataItem In rg_chem.SelectedItems
                Dim dao_curr As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim dao_max As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim dao_min As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim dao_rowup As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim _max As Integer = 0
                Dim _min As Integer = 0
                Dim row_up As Integer = 0
                Dim row_current As Integer = 0
                Try
                    dao_max.GET_MAX_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                Try
                    dao_min.GET_MIN_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _min = dao_min.fields.ROWS
                Catch ex As Exception

                End Try

                dao_curr.GetDataby_IDA(item("IDA").Text)
                row_current = dao_curr.fields.ROWS
                If row_current > _min Then
                    Try
                        'update แถวบนก่อน
                        dao_rowup.GetDataby_ROWs_AND_FK_SET(row_current - 1, item("FK_SET").Text)
                        dao_rowup.fields.ROWS = row_current
                        dao_rowup.update()

                        'update แถวล่างให้ค่า +1
                        dao_curr.fields.ROWS = row_current - 1
                        dao_curr.update()

                    Catch ex As Exception

                    End Try

                End If
            Next

           
        Else
            For Each item As GridDataItem In rg_chem.SelectedItems
                Dim dao_curr As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim dao_max As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim dao_min As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim dao_rowup As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim _max As Integer = 0
                Dim _min As Integer = 0
                Dim row_up As Integer = 0
                Dim row_current As Integer = 0
                Try
                    dao_max.GET_MAX_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                Try
                    dao_min.GET_MIN_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _min = dao_min.fields.ROWS
                Catch ex As Exception

                End Try

                dao_curr.GetDataby_IDA(item("IDA").Text)
                row_current = dao_curr.fields.ROWS
                If row_current > _min Then
                    Try
                        'update แถวบนก่อน
                        dao_rowup.GetDataby_ROWs_AND_FK_SET(row_current - 1, item("FK_SET").Text)
                        dao_rowup.fields.ROWS = row_current
                        dao_rowup.update()

                        'update แถวล่างให้ค่า +1
                        dao_curr.fields.ROWS = row_current - 1
                        dao_curr.update()

                    Catch ex As Exception

                    End Try

                End If

            Next
        End If

        rg_chem.Rebind()
    End Sub

    Private Sub btn_down_Click(sender As Object, e As EventArgs) Handles btn_down.Click
        If STATUS_ID = 8 Then
            For Each item As GridDataItem In rg_chem.SelectedItems
                Dim dao_curr As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim dao_max As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim dao_min As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim dao_rowup As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim _max As Integer = 0
                Dim _min As Integer = 0
                Dim row_up As Integer = 0
                Dim row_current As Integer = 0
                Try
                    dao_max.GET_MAX_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                Try
                    dao_min.GET_MIN_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _min = dao_min.fields.ROWS
                Catch ex As Exception

                End Try

                dao_curr.GetDataby_IDA(item("IDA").Text)
                row_current = dao_curr.fields.ROWS
                If row_current < _max Then
                    Try
                        'update แถวบนก่อน
                        dao_rowup.GetDataby_ROWs_AND_FK_SET(row_current + 1, item("FK_SET").Text)
                        dao_rowup.fields.ROWS = row_current
                        dao_rowup.update()

                        'update แถวล่างให้ค่า +1
                        dao_curr.fields.ROWS = row_current + 1
                        dao_curr.update()

                    Catch ex As Exception

                    End Try

                End If
            Next
        Else
            For Each item As GridDataItem In rg_chem.SelectedItems
                Dim dao_curr As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim dao_max As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim dao_min As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim dao_rowup As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                Dim _max As Integer = 0
                Dim _min As Integer = 0
                Dim row_up As Integer = 0
                Dim row_current As Integer = 0
                Try
                    dao_max.GET_MAX_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                Try
                    dao_min.GET_MIN_ROWS_ID_SET(_IDA, item("FK_SET").Text)
                    _min = dao_min.fields.ROWS
                Catch ex As Exception

                End Try

                dao_curr.GetDataby_IDA(item("IDA").Text)
                row_current = dao_curr.fields.ROWS
                If row_current < _max Then
                    Try
                        'update แถวบนก่อน
                        dao_rowup.GetDataby_ROWs_AND_FK_SET(row_current + 1, item("FK_SET").Text)
                        dao_rowup.fields.ROWS = row_current
                        dao_rowup.update()

                        'update แถวล่างให้ค่า +1
                        dao_curr.fields.ROWS = row_current + 1
                        dao_curr.update()

                    Catch ex As Exception

                    End Try

                End If

            Next
        End If

        rg_chem.Rebind()
    End Sub

    Protected Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        If STATUS_ID = 8 Then
            Dim i As Integer = 1
            Dim dao As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao.GetDataby_FK_IDA_ORDER(_IDA, ddl_set.SelectedValue)
            For Each dao.fields In dao.datas
                dao.fields.ROWS = i
                dao.update()
                i += 1
            Next
        Else
            Dim i As Integer = 1
            Dim dao As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
            dao.GetDataby_FK_IDA_ORDER(_IDA, ddl_set.SelectedValue)
            For Each dao.fields In dao.datas
                dao.fields.ROWS = i
                dao.update()
                i += 1
            Next
        End If
        
    End Sub

    Private Sub btn_rows_save_Click(sender As Object, e As EventArgs) Handles btn_rows_save.Click
        If STATUS_ID = 8 Then
            For Each item As GridDataItem In rg_chem.Items
                Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
                Try
                    Dim dao As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                    dao.GetDataby_IDA(item("IDA").Text)
                    dao.fields.ROWS = Trim(txt_rows.Text)
                    dao.update()
                Catch ex As Exception

                End Try
            Next
  
            KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขลำดับสาร", _CLS.CITIZEN_ID)

            Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)
            If STATUS_ID = 8 Then
                Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))
                Dim old_data As String = ""
                Dim new_data As String = "บันทึกลำดับสาร"

                Dim result As String = ""
                Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                result = ""
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

                End Try
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                    dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

            End If
        Else
            For Each item As GridDataItem In rg_chem.Items
                Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
                Try
                    Dim dao As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                   dao.GetDataby_IDA(item("IDA").Text)
                    dao.fields.ROWS = Trim(txt_rows.Text)
                    dao.update()
                Catch ex As Exception

                End Try
            Next
        End If

        rg_chem.Rebind()
    End Sub
End Class