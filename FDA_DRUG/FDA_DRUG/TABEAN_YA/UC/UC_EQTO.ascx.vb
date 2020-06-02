Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UC_EQTO
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Dim STATUS_ID As Integer = 0
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
            bind_unit()
            bind_unit_end()
        End If
    End Sub

    Protected Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        RunQuery()
        If ddl_unit.SelectedValue <> 0 And txt_QTY.Text <> "" Then
            If STATUS_ID = 8 Then
                Dim old_data As String = ""
                Dim new_data As String = ""

                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(Request.QueryString("idr"))
                dao_rg.fields.lmdfdate = Date.Now
                dao_rg.update()
                For Each item As GridDataItem In rg_search_iowa.SelectedItems
                    Dim dao As New DAO_DRUG.TB_DRRGT_EQTO
                    dao.fields.IOWA = item("iowacd").Text
                    dao.fields.QTY = txt_QTY.Text
                    dao.fields.FK_IDA = _IDA
                    Dim dao_max As New DAO_DRUG.TB_DRRGT_EQTO
                    dao_max.GET_MAX_ROWS_ID_SET(_IDA, Request.QueryString("fk_set"))
                    Dim id_max As Integer = 0
                    Try
                        id_max = dao_max.fields.ROWS
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.MULTIPLY = txt_mulyiply.Text
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.STR_VALUE = txt_str.Text
                    Catch ex As Exception

                    End Try
                    dao.fields.ROWS = id_max + 1
                    dao.fields.aori = ddl_aori.SelectedItem.Text
                    dao.fields.SUNITCD = ddl_unit.SelectedValue
                    dao.fields.FK_DRRQT_IDA = Request.QueryString("idr")
                    dao.fields.FK_SET = Request.QueryString("fk_set")
                    dao.fields.QTY_END = txt_QTY_END.Text
                    dao.fields.SUNITCD_END = ddl_unit_end.SelectedValue
                    dao.fields.REF = txt_ref.Text
                    dao.fields.REMARK = txt_remark.Text
                    new_data = "เพิ่มสาร eqto : " & item("iowacd").Text

                    dao.insert()

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
                                dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("idr"))

                                Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                                Dim cls_xml_DR As New LGT_IOW_E
                                cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                                Dim str_xml As String = ""
                                Try
                                    Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                                    dao1.GetDataby_IDA(Request.QueryString("idr"))
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


                Next
                'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                'dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

                Dim dao_dr As New DAO_DRUG.TB_DRRGT_EQTO
                dao_dr.GetDataby_FK_IDA(_IDA)
                Dim max_no As Integer = 0
                Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
                dao_edt.GET_MAX_NO("DRRGT_EQTO", dao_dr.fields.IDA)
                Try
                    max_no = dao_edt.fields.COUNT_EDIT
                Catch ex As Exception

                End Try
                'Dim filename As String = ""
                'filename = "DRRGT_EQTO_" & max_no + 1 & ".xml"
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
                '    .FK_DRRGT_IDA = 0 'Request.QueryString("IDA")
                '    .FK_IDA = dao_dr.fields.IDA
                '    .TABLE_NAME = "DRRGT_EQTO"
                'End With
                'dao_index.insert()
            Else
                Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                dao_rg.GetDataby_IDA(Request.QueryString("idr"))
                dao_rg.fields.lmdfdate = Date.Now
                dao_rg.update()
                For Each item As GridDataItem In rg_search_iowa.SelectedItems
                    Dim dao As New DAO_DRUG.TB_DRRQT_EQTO
                    dao.fields.IOWA = item("iowacd").Text
                    dao.fields.QTY = txt_QTY.Text
                    dao.fields.FK_IDA = _IDA
                    Dim dao_max As New DAO_DRUG.TB_DRRQT_EQTO
                    dao_max.GET_MAX_ROWS_ID_SET(_IDA, Request.QueryString("fk_set"))
                    Dim id_max As Integer = 0
                    Try
                        id_max = dao_max.fields.ROWS
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.MULTIPLY = txt_mulyiply.Text
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.STR_VALUE = txt_str.Text
                    Catch ex As Exception

                    End Try
                    dao.fields.aori = ddl_aori.SelectedItem.Text
                    dao.fields.SUNITCD = ddl_unit.SelectedValue
                    dao.fields.ROWS = id_max + 1
                    dao.fields.FK_DRRQT_IDA = Request.QueryString("idr")
                    dao.fields.FK_SET = Request.QueryString("fk_set")
                    dao.fields.QTY_END = txt_QTY_END.Text
                    dao.fields.SUNITCD_END = ddl_unit_end.SelectedValue
                    dao.fields.REF = txt_ref.Text
                    dao.fields.REMARK = txt_remark.Text
                    dao.insert()
                Next
            End If
            KEEP_LOGS_TABEAN_EDIT(_IDA, "แก้ไขEQTO", _CLS.CITIZEN_ID)
            rg_chem.Rebind()

        Else
            alert("กรุณากรอกข้อมูลให้ครบ")
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Private Sub rg_chem_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_chem.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                If STATUS_ID = 8 Then
                    Dim old_data As String = ""
                    Dim new_data As String = ""

                    Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                    dao_rg.GetDataby_IDA(Request.QueryString("idr"))
                    dao_rg.fields.lmdfdate = Date.Now
                    dao_rg.update()
                    Dim dao As New DAO_DRUG.TB_DRRGT_EQTO
                    dao.GetDataby_IDA(IDA)
                    old_data = "ลบสาร eqto : " & dao.fields.IOWA
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
                                dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("idr"))

                                Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                                Dim cls_xml_DR As New LGT_IOW_E
                                cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                                Dim str_xml As String = ""
                                Try
                                    Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                                    dao1.GetDataby_IDA(Request.QueryString("idr"))
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
                    Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                    dao_rg.GetDataby_IDA(Request.QueryString("idr"))
                    dao_rg.fields.lmdfdate = Date.Now
                    dao_rg.update()
                    Dim dao As New DAO_DRUG.TB_DRRQT_EQTO
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                End If

                rg_chem.Rebind()
            End If

        End If
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
    Public Sub bind_unit_end()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit_end.DataSource = dt
        ddl_unit_end.DataTextField = "sunitnmsht"
        ddl_unit_end.DataValueField = "sunitcd"
        ddl_unit_end.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit_end.Items.Insert(0, item)
    End Sub

    Private Sub rg_chem_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_chem.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim lbl_rows As Label = DirectCast(item("ROWS").FindControl("lbl_rows"), Label)
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)

            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_EQTO
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
                Dim dao As New DAO_DRUG.TB_DRRQT_EQTO
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
    Private Sub rg_chem_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_chem.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If STATUS_ID = 8 Then
            'Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            'dao1.GetDataby_FK_DRRQT(_IDA)
            'Dim dao2 As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            'dao2.GetDataby_FKIDA(dao1.fields.IDA)

            dt = bao.SP_DRRGT_EQTO_BY_FK_IDA(_IDA)
        Else
            dt = bao.SP_DRRQT_EQTO_BY_FK_IDA(_IDA)
        End If

        rg_chem.DataSource = dt
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

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url As String = ""
        If Request.QueryString("e") <> "" Then
            url = "../TABEAN_YA/FRM_RQT_EDIT.aspx?IDA=" & Request.QueryString("idr") & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&tab=5&e=1&STATUS_ID=" & Request.QueryString("STATUS_ID") & "&ida_e=" & Request.QueryString("ida_e")
        Else
            url = "../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & Request.QueryString("idr") & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&tab=5&STATUS_ID=" & Request.QueryString("STATUS_ID")
        End If
        Response.Redirect(url)
    End Sub

    Private Sub btn_rows_save_Click(sender As Object, e As EventArgs) Handles btn_rows_save.Click
        If STATUS_ID = 8 Then
            For Each item As GridDataItem In rg_chem.Items
                Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
                Try
                    Dim dao As New DAO_DRUG.TB_DRRGT_EQTO
                    dao.GetDataby_IDA(item("IDA").Text)
                    dao.fields.ROWS = Trim(txt_rows.Text)
                    dao.update()
                Catch ex As Exception

                End Try
            Next

            KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขลำดับสาร EQTO", _CLS.CITIZEN_ID)

            Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)
            If STATUS_ID = 8 Then
                Dim old_data As String = ""
                Dim new_data As String = "แก้ไขลำดับสาร"

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
                        dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("idr"))

                        Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                        Dim cls_xml_DR As New LGT_IOW_E
                        cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                        Dim str_xml As String = ""
                        Try
                            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                            dao1.GetDataby_IDA(Request.QueryString("idr"))
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
            For Each item As GridDataItem In rg_chem.Items
                Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
                Try
                    Dim dao As New DAO_DRUG.TB_DRRQT_EQTO
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