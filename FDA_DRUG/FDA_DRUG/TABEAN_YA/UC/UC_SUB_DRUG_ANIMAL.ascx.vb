Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UC_SUB_DRUG_ANIMAL
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Dim r_id As String
    Dim STATUS_ID As Integer = 0
    Private _CLS As New CLS_SESSION
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        r_id = Request.QueryString("r_id")
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
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                '_req = Request.QueryString("req")
                'Try
                '    _main_ida = Request.QueryString("IDA") 'Request("main_ida").ToString()
                '    main_ida = CInt(_main_ida)
                'Catch ex As Exception
                'End Try
                'Try
                '    _process = Request("process").ToString()
                'Catch ex As Exception
                'End Try
                'Try
                '    _sunit_ida = Request("sunit_ida").ToString()
                'Catch ex As Exception
                'End Try
                'Try
                '    _lcn_ida = Request("lcn_ida").ToString()
                'Catch ex As Exception

                'End Try
                'Try
                '    _write_at = Request("write_at").ToString()
                'Catch ex As Exception

                'End Try
                'Try
                '    _phesaj = Request("phesaj").ToString()
                'Catch ex As Exception
                'End Try
                'Try
                '    _forother = Request("forother").ToString()
                'Catch ex As Exception
                'End Try

            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim cls_session As New CLS_SESSION
        If lbl_sunit_ida.Text = "" Then
            btn_edit.Visible = False
            btn_cancel.Visible = False
            btn_save.Visible = True
        Else
            btn_edit.Visible = True
            btn_cancel.Visible = True
            btn_save.Visible = False
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        RunSession()
        If Not IsPostBack Then
            bind_ddl_dramltype()
        End If
    End Sub
    Public Sub bind_ddl_dramltype()
        Dim dao As New DAO_DRUG.TB_dramlpart
        dao.GetDataAll()
        ddl_dramlpart.DataSource = dao.datas
        ddl_dramlpart.DataTextField = "ampartnm"
        ddl_dramlpart.DataValueField = "ampartcd"
        ddl_dramlpart.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_dramlpart.Items.Insert(0, item)
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim str As String = ""

        'If txt_STOP_VALUE2.Text <> "" Then
        '    str = txt_STOP_VALUE1.Text & " " & ddl_STOP_UNIT1.SelectedItem.Text & " ถึง " & txt_STOP_VALUE2.Text & " " & ddl_STOP_UNIT2.SelectedItem.Text
        'Else
        str = txt_STOP_VALUE1.Text & " " & ddl_STOP_UNIT1.SelectedItem.Text
        'End If
        If STATUS_ID = 8 Then
            Dim dao_m As New DAO_DRUG.ClsDBdramldrg
            dao_m.GetData_by_IDA(_IDA)
            Dim dao_r As New DAO_DRUG.ClsDBdrrgt
            Try
                dao_r.GetDataby_IDA(r_id)
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.ClsDBdramluse
            dao.fields.ampartcd = ddl_dramlpart.SelectedValue
            dao.fields.amlsubcd = dao_m.fields.amlsubcd
            dao.fields.amltpcd = dao_m.fields.amltpcd
            dao.fields.FK_IDA = r_id '_IDA
            'dao.fields.nouse = txt_nouse.Text
            dao.fields.packuse = txt_packuse.Text
            dao.fields.drgtpcd = dao_r.fields.drgtpcd
            dao.fields.pvncd = dao_r.fields.pvncd
            dao.fields.rgtno = dao_r.fields.rgtno
            dao.fields.rgttpcd = dao_r.fields.rgttpcd
            dao.fields.usetpcd = dao_m.fields.usetpcd
            dao.fields.STOP_UNIT1 = ddl_STOP_UNIT1.SelectedValue
            dao.fields.STOP_VALUE1 = txt_STOP_VALUE1.Text
            'dao.fields.STOP_UNIT2 = ddl_STOP_UNIT2.SelectedValue
            'dao.fields.STOP_VALUE2 = txt_STOP_VALUE2.Text
            dao.fields.stpdrg = str
            dao.insert()

            Dim dao_dr As New DAO_DRUG.ClsDBdramluse
            dao_dr.GetDataby_FK_IDA(Request.QueryString("IDA"))
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("dramluse", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try
            'Dim filename As String = ""
            'filename = "dramluse_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "dramluse"
            'End With
            'dao_index.insert()
            If Request.QueryString("e") = "" Then

                Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                Dim cls_xml_DR As New LGT_IOW_E
                cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                Dim str_xml As String = ""
                Try
                    Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                    Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                    dao1.GetDataby_IDA(Request.QueryString("IDA"))
                    SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao1.fields.IDENTIFY)

                    WS_DRUG.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                Catch ex As Exception

                End Try
            End If
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_r.fields.pvncd, dao_r.fields.rgttpcd, dao_r.fields.drgtpcd, dao_r.fields.rgtno, "เพิ่มส่วนบริโภค : " & ddl_dramlpart.SelectedItem.Text, _CLS.CITIZEN_ID, "DRUG")
            alert("บันทึกข้อมูลเรียบร้อย")
        Else
            Dim dao_m As New DAO_DRUG.ClsDBdrramldrg
            dao_m.GetData_by_IDA(_IDA)
            Dim dao_r As New DAO_DRUG.ClsDBdrrqt
            Try
                dao_r.GetDataby_IDA(_IDA)
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdrramluse
            dao.fields.ampartcd = ddl_dramlpart.SelectedValue
            dao.fields.amlsubcd = dao_m.fields.amlsubcd
            dao.fields.amltpcd = dao_m.fields.amltpcd
            dao.fields.FK_IDA = r_id 'IDA
            'dao.fields.nouse = txt_nouse.Text
            dao.fields.packuse = txt_packuse.Text
            dao.fields.drgtpcd = dao_r.fields.drgtpcd
            dao.fields.pvncd = dao_r.fields.pvncd
            dao.fields.rgtno = dao_r.fields.rgtno
            dao.fields.rgttpcd = dao_r.fields.rgttpcd
            dao.fields.usetpcd = dao_m.fields.usetpcd
            dao.fields.STOP_UNIT1 = ddl_STOP_UNIT1.SelectedValue
            dao.fields.STOP_VALUE1 = txt_STOP_VALUE1.Text
            'dao.fields.STOP_UNIT2 = ddl_STOP_UNIT2.SelectedValue
            'dao.fields.STOP_VALUE2 = txt_STOP_VALUE2.Text
            dao.fields.stpdrg = str
            dao.insert()

            alert("บันทึกข้อมูลเรียบร้อย")
        End If
        KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "เพิ่มส่วนบริโภค", _CLS.CITIZEN_ID)
        rgAnimals.Rebind()
    End Sub

    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub rgAnimals_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgAnimals.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                If STATUS_ID = 8 Then
                    Dim old_data As String = "ลบส่วนบริโภค : " & item("ampartnm").Text
                    Dim dao As New DAO_DRUG.ClsDBdramluse
                    dao.GetDatabyIDA(IDA)
                    dao.delete()
                    alert("ลบข้อมูลเรียบร้อย")
                    'Else
                    '    Dim dao As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                    '    dao.GetDataby_IDA(IDA)
                    '    dao.delete()

                    If STATUS_ID = 8 Then

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

                    KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "ลบส่วนบริโภค", _CLS.CITIZEN_ID)
                Else
                    Dim dao As New DAO_DRUG.ClsDBdrramluse
                    dao.GetDatabyIDA(IDA)
                    dao.delete()
                    alert("ลบข้อมูลเรียบร้อย")
                End If

                rgAnimals.Rebind()
            ElseIf e.CommandName = "_sel" Then

            ElseIf e.CommandName = "edt" Then
                Dim str As String = ""
                str = txt_STOP_VALUE1.Text & " " & ddl_STOP_UNIT1.SelectedItem.Text
                If STATUS_ID = 8 Then
                    Dim dao_m As New DAO_DRUG.ClsDBdramldrg
                    dao_m.GetData_by_IDA(IDA)
                    Dim dao_r As New DAO_DRUG.ClsDBdrrgt
                    Try
                        dao_r.GetDataby_IDA(_IDA)
                    Catch ex As Exception

                    End Try

                    Dim dao As New DAO_DRUG.ClsDBdramluse
                    Try
                        ddl_dramlpart.DropDownSelectData(dao.fields.ampartcd)
                    Catch ex As Exception

                    End Try
                    txt_packuse.Text = dao.fields.packuse
                    Try
                        ddl_STOP_UNIT1.DropDownSelectData(dao.fields.STOP_UNIT1)
                    Catch ex As Exception

                    End Try
                    Try
                        txt_STOP_VALUE1.Text = dao.fields.STOP_VALUE1
                    Catch ex As Exception

                    End Try

                Else
                    Dim dao_m As New DAO_DRUG.ClsDBdrramldrg
                    dao_m.GetData_by_IDA(IDA)
                    'Dim dao_r As New DAO_DRUG.ClsDBdrrqt
                    'Try
                    '    dao_r.GetDataby_IDA(_IDA)
                    'Catch ex As Exception

                    'End Try

                    Dim dao As New DAO_DRUG.ClsDBdrramluse
                    Try
                        ddl_dramlpart.DropDownSelectData(dao.fields.ampartcd)
                    Catch ex As Exception

                    End Try
                    txt_packuse.Text = dao.fields.packuse
                    Try
                        ddl_STOP_UNIT1.DropDownSelectData(dao.fields.STOP_UNIT1)
                    Catch ex As Exception

                    End Try
                    Try
                        txt_STOP_VALUE1.Text = dao.fields.STOP_VALUE1
                    Catch ex As Exception

                    End Try
                End If
                lbl_sunit_ida.Text = item("IDA").Text
                RunSession()
            End If

        End If
    End Sub

    Private Sub rgAnimals_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAnimals.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        If STATUS_ID = 8 Then
            Dim dao_aml As New DAO_DRUG.ClsDBdramldrg
            dao_aml.GetData_by_IDA(_IDA)
            Try
                dt = bao.SP_dramluse_BY_FK_IDA_V2(r_id, dao_aml.fields.amltpcd, dao_aml.fields.amlsubcd, dao_aml.fields.usetpcd)
            Catch ex As Exception

            End Try
        Else
            Try
                Dim dao_aml As New DAO_DRUG.ClsDBdrramldrg
                dao_aml.GetData_by_IDA(_IDA)
                dt = bao.SP_drramluse_BY_FK_IDA_V2(r_id, dao_aml.fields.amltpcd, dao_aml.fields.amlsubcd, dao_aml.fields.usetpcd)
            Catch ex As Exception

            End Try
        End If


        rgAnimals.DataSource = dt
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & r_id & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&tab=10")
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        ' RunSession()
        Dim str As String = ""

        'If txt_STOP_VALUE2.Text <> "" Then
        '    str = txt_STOP_VALUE1.Text & " " & ddl_STOP_UNIT1.SelectedItem.Text & " ถึง " & txt_STOP_VALUE2.Text & " " & ddl_STOP_UNIT2.SelectedItem.Text
        'Else
        str = txt_STOP_VALUE1.Text & " " & ddl_STOP_UNIT1.SelectedItem.Text
        'End If
        If STATUS_ID = 8 Then
            Dim dao_m As New DAO_DRUG.ClsDBdramldrg
            dao_m.GetData_by_IDA(_IDA)
            Dim dao_r As New DAO_DRUG.ClsDBdrrgt
            Try
                dao_r.GetDataby_IDA(_IDA)
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.ClsDBdramluse
            dao.GetDatabyIDA(lbl_sunit_ida.Text)
            dao.fields.ampartcd = ddl_dramlpart.SelectedValue
            dao.fields.packuse = txt_packuse.Text
            dao.fields.STOP_UNIT1 = ddl_STOP_UNIT1.SelectedValue
            dao.fields.STOP_VALUE1 = txt_STOP_VALUE1.Text
            dao.fields.stpdrg = str
            dao.update()
            Dim ws_drug As New WS_DRUG.WS_DRUG
            ws_drug.DRUG_UPDATE_DR(dao_r.fields.pvncd, dao_r.fields.rgttpcd, dao_r.fields.drgtpcd, dao_r.fields.rgtno, "แก้ไขส่วนบริโภค", _CLS.CITIZEN_ID, "DRUG")
            alert("แก้ไขข้อมูลเรียบร้อย")
            KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขส่วนบริโภค", _CLS.CITIZEN_ID)
        Else
            Dim dao_m As New DAO_DRUG.ClsDBdrramldrg
            dao_m.GetData_by_IDA(_IDA)
            Dim dao_r As New DAO_DRUG.ClsDBdrrqt
            Try
                dao_r.GetDataby_IDA(_IDA)
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.ClsDBdramluse
            dao.GetDatabyIDA(lbl_sunit_ida.Text)
            dao.fields.ampartcd = ddl_dramlpart.SelectedValue
            dao.fields.packuse = txt_packuse.Text
            dao.fields.STOP_UNIT1 = ddl_STOP_UNIT1.SelectedValue
            dao.fields.STOP_VALUE1 = txt_STOP_VALUE1.Text
            dao.fields.stpdrg = str
            dao.update()
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_r.fields.pvncd, dao_r.fields.rgttpcd, dao_r.fields.drgtpcd, dao_r.fields.rgtno)
            alert("แก้ไขข้อมูลเรียบร้อย")
        End If

        rgAnimals.Rebind()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        lbl_sunit_ida.Text = ""
        RunSession()
    End Sub
End Class