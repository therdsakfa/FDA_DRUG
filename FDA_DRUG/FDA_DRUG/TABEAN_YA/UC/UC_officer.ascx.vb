Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UC_officer
    Inherits System.Web.UI.UserControl
    Dim STATUS_ID As String = ""
    Private _CLS As New CLS_SESSION
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
        RunQuery()
        If Not IsPostBack Then
            bind_nat()
            If Request.QueryString("tt") <> "" Then
                btn_save_work_type.Enabled = False
                btn_select.Enabled = False
            End If
            'If STATUS_ID = "8" Then
            '    btn_save_work_type.Enabled = False
            '    btn_select.Enabled = False
            'End If
        End If
    End Sub
    Sub bind_nat()
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao.SP_MASTER_sysisocnt()
        rcb_national.DataSource = dt
        rcb_national.DataTextField = "engcntnm"
        rcb_national.DataValueField = "alpha3"
        rcb_national.DataBind()

    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        rg_search_fore.Rebind()
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    'Sub Search_FN()
    '    Dim dt As New DataTable
    '    Dim command As String = " "
    '    Dim bao_aa As New BAO.ClsDBSqlcommand
    '    command = "select * from dbo.Vw_FOREIGN_ADDR "
    '    Dim str_where As String = ""
    '    Dim dt2 As New DataTable

    '    If txt_search.Text = "" Then
    '        alert("กรุณากรอกข้อมูลที่ต้องการค้นหา")
    '    Else
    '        If txt_search.Text <> "" Then
    '            str_where = "where engfrgnnm like '%" & txt_search.Text & "%'"
    '            command &= str_where
    '        Else
    '            alert("กรุณากรอกข้อมูลที่ต้องการค้นหา")
    '        End If
    '    End If

    '    dt = bao_aa.Queryds(command)
    '    rg_search_fore.DataSource = dt

    'End Sub
    Sub Search_FN()
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_FOREIGN_ADDR "
        Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_search.Text = "" Then
            alert("กรุณากรอกข้อมูลที่ต้องการค้นหา")
        Else
            If txt_search.Text <> "" Then
                str_where = "where engfrgnnm like '%" & txt_search.Text & "%' and alpha3='" & rcb_national.SelectedValue & "'"
                command &= str_where
            Else
                alert("กรุณากรอกข้อมูลที่ต้องการค้นหา")
            End If
        End If

        dt = bao_aa.Queryds(command)
        rg_search_fore.DataSource = dt

    End Sub
    Private Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        RunQuery()
        If STATUS_ID = 8 Then
            Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            dao_re.fields.lmdfdate = Date.Now
            dao_re.update()
            For Each item As GridDataItem In rg_search_fore.SelectedItems
                Dim old_data As String = ""
                Dim new_data As String = ""
                Dim dao_frg As New DAO_DRUG.ClsDBsyspdcfrgn
                dao_frg.GetData_by_IDA(item("IDA").Text)
                Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER
                dao.fields.FK_PRODUCER = item("IDA").Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.fields.frgncd = item("frgncd").Text
                'dao.fields.PRODUCER_WORK_TYPE = ddl_work_type.SelectedValue
                dao.fields.addr_ida = item("addr_ida").Text
                dao.fields.frgnlctcd = item("frgnlctcd").Text
                new_data = "เพิ่มผู้ผลิตต่างประเทศ: frgncd= " & item("frgncd").Text & " ,addr_ida= " & item("addr_ida").Text
                dao.insert()


                If STATUS_ID = 8 Then
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

                    End Try
                    Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                    KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                        dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                End If
            Next
        Else
            Dim dao_re As New DAO_DRUG.ClsDBdrrqt
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            dao_re.fields.lmdfdate = Date.Now
            dao_re.update()
            For Each item As GridDataItem In rg_search_fore.SelectedItems
                Dim dao_frg As New DAO_DRUG.ClsDBsyspdcfrgn
                dao_frg.GetData_by_IDA(item("IDA").Text)
                Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER
                dao.fields.FK_PRODUCER = item("IDA").Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.fields.frgncd = item("frgncd").Text
                'dao.fields.PRODUCER_WORK_TYPE = ddl_work_type.SelectedValue
                dao.fields.addr_ida = item("addr_ida").Text
                dao.fields.frgnlctcd = item("frgnlctcd").Text
                dao.insert()
            Next
        End If
        KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "เพิ่มผู้ผลิตต่างประเทศ", _CLS.CITIZEN_ID)
        rg_produccer.Rebind()
    End Sub

    Private Sub rg_produccer_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_produccer.ItemCommand
        '
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("P_IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                Dim old_data As String = ""
                Dim new_data As String = ""

                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else
                    If STATUS_ID = 8 Then
                        Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER
                        dao.GetDataby_IDA(IDA)
                        Try
                            old_data = "ลบผู้ผลิตต่างประเทศ: frgncd= " & dao.fields.frgncd & " ,addr_ida= " & dao.fields.addr_ida
                        Catch ex As Exception

                        End Try
                        If STATUS_ID = 8 Then
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

                            End Try
                            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                            KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                                dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                        End If
                        dao.delete()
                    Else
                        Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER
                        dao.GetDataby_IDA(IDA)
                        dao.delete()
                    End If
                    KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "ลบผู้ผลิตต่างประเทศ " & IDA, _CLS.CITIZEN_ID)



                    alert("ลบเรียบร้อยแล้ว")
                    rg_produccer.Rebind()

                End If
            End If
        End If
    End Sub

    Private Sub rg_produccer_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_produccer.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("P_IDA").Text
            Dim lbl_comment As Label = DirectCast(item("work_type").FindControl("lbl_work_type"), Label)
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)

            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER
                dao.GetDataby_IDA(item("P_IDA").Text)
                Try
                    rcb_work_type.SelectedValue = dao.fields.PRODUCER_WORK_TYPE

                Catch ex As Exception

                End Try
                Try

                    If dao.fields.PRODUCER_WORK_TYPE = 1 Then
                        lbl_comment.Text = "ผลิตยาสำเร็จรูป"
                    ElseIf dao.fields.PRODUCER_WORK_TYPE = 2 Then
                        lbl_comment.Text = "แบ่งบรรจุ"
                    ElseIf dao.fields.PRODUCER_WORK_TYPE = 3 Then
                        lbl_comment.Text = "ตรวจปล่อยหรือผ่านเพื่อจำหน่าย"
                    ElseIf dao.fields.PRODUCER_WORK_TYPE = 9 Then
                        lbl_comment.Text = "อื่นๆ"
                    End If
                Catch ex As Exception

                End Try
            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER
                dao.GetDataby_IDA(item("P_IDA").Text)
                Try
                    rcb_work_type.SelectedValue = dao.fields.PRODUCER_WORK_TYPE

                Catch ex As Exception

                End Try
                Try

                    If dao.fields.PRODUCER_WORK_TYPE = 1 Then
                        lbl_comment.Text = "ผลิตยาสำเร็จรูป"
                    ElseIf dao.fields.PRODUCER_WORK_TYPE = 2 Then
                        lbl_comment.Text = "แบ่งบรรจุ"
                    ElseIf dao.fields.PRODUCER_WORK_TYPE = 3 Then
                        lbl_comment.Text = "ตรวจปล่อยหรือผ่านเพื่อจำหน่าย"
                    ElseIf dao.fields.PRODUCER_WORK_TYPE = 9 Then
                        lbl_comment.Text = "อื่นๆ"
                    End If
                Catch ex As Exception

                End Try
            End If

        End If
    End Sub

    Private Sub rg_produccer_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_produccer.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'fulladdr2
        If STATUS_ID = 8 Then
            dt = bao.SP_DRRGT_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))
        Else
            dt = bao.SP_DRRQT_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))
        End If


        rg_produccer.DataSource = dt
    End Sub


    Protected Sub btn_save_work_type_Click(sender As Object, e As EventArgs) Handles btn_save_work_type.Click
        RunQuery()
        If STATUS_ID = 8 Then
            For Each item As GridDataItem In rg_produccer.Items
                Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)
                Try
                    Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER
                    dao.GetDataby_IDA(item("P_IDA").Text)
                    dao.fields.PRODUCER_WORK_TYPE = rcb_work_type.SelectedValue
                    dao.fields.funccd = rcb_work_type.SelectedValue
                    Dim old_data As String = ""
                    Dim new_data As String = ""

                    If STATUS_ID = 8 Then
                        Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                        dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))
                        old_data = "funccd = " & dao.fields.funccd
                        new_data = "funccd = " & rcb_work_type.SelectedValue
                        Dim result As String = ""
                        Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                        result = ""
                        If Request.QueryString("e") <> "" Then
                            result = "EDIT RQT"
                        End If
                        Try
                            If Request.QueryString("e") = "" Then
                                ws_drug.Timeout = 8000
                                ' result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)

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

                    dao.update()
                Catch ex As Exception

                End Try
            Next
            Dim dao_dr As New DAO_DRUG.TB_DRRGT_PRODUCER
            dao_dr.GetDataby_FK_IDA(Request.QueryString("IDA"))
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_PRODUCER", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try


            'Dim filename As String = ""
            'filename = "DRRGT_PRODUCER_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "DRRGT_PRODUCER"
            'End With
            'dao_index.insert()
            KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขหน้าที่ผู้ผลิตต่างประเทศ", _CLS.CITIZEN_ID)

            'Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            'dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)
        Else
            For Each item As GridDataItem In rg_produccer.Items
                Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)
                Try
                    Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER
                    dao.GetDataby_IDA(item("P_IDA").Text)
                    dao.fields.PRODUCER_WORK_TYPE = rcb_work_type.SelectedValue
                    dao.fields.funccd = rcb_work_type.SelectedValue
                    dao.update()
                Catch ex As Exception

                End Try
            Next
        End If

        rg_produccer.Rebind()
    End Sub
End Class