Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml
Imports Telerik.Web.UI
Public Class officer_in_country
    Inherits System.Web.UI.UserControl

    'Private _IDA As String
    Private _lcnno As String
    Private _lcntpcd As String
    Private _pvncd As String
    Private _lcnsid As String
    Private _thadrgnm As String
    Private _rgttpcd As String
    Private _rgtno As String
    Private _drgtpcd As String
    Public _Newcode As String
    Dim ThaiCulture As New CultureInfo("th-TH") 'วันที่แบบไทย
    Dim UsaCulture As New CultureInfo("en-US") 'วันที่แบบสากล
    'Private _dsgcd As String
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
    Sub show_data_frgn(ByVal _ida As String)
        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_FK_DRRQT(_ida)

            Try
                Dim bao As New BAO_SHOW
                Dim dt2 As New DataTable
                Try

                    dt2 = bao.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(dao.fields.IDA, 2)

                    Lb_in_frgn.Text = dt2(0)("engfrgnnm")
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_ida)
            Try
                Dim bao As New BAO_SHOW
                Dim dt2 As New DataTable
                Try

                    dt2 = bao.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_ida, 2)

                    Lb_in_frgn.Text = dt2(0)("engfrgnnm")
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        End If
        
    End Sub
    Sub show_data_frgn_rqt(ByVal _ida As String)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_ida)
        Try
            Dim bao As New BAO_SHOW
            Dim dt2 As New DataTable
            Try

                dt2 = bao.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_ida, 2)

                Lb_in_frgn.Text = dt2(0)("engfrgnnm")
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Sub show_data_in_frgn(ByVal _ida As String)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_ida)
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                Dim bao As New BAO_SHOW
                Dim dao_p As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                dao_p.GetDataby_FK_IDA(_ida)

                Dim dao_reg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao_reg.GetDataby_IDA(dao.fields.FK_IDA)
                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                dao_lcn.GetDataby_IDA(dao_reg.fields.FK_IDA)
                Dim dt2 As New DataTable
                Try
                    dt2 = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    Lb_in_frgn.Text = dt2(0)("thanameplace")
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub show_data_in_frgn_rqt(ByVal _ida As String)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_ida)
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                Dim bao As New BAO_SHOW
                Dim dao_p As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
                dao_p.GetDataby_FK_IDA(_ida)

                Dim dao_reg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao_reg.GetDataby_IDA(dao.fields.FK_IDA)
                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                dao_lcn.GetDataby_IDA(dao_reg.fields.FK_IDA)
                Dim dt2 As New DataTable
                Try
                    dt2 = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
                    Lb_in_frgn.Text = dt2(0)("thanameplace")
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub show_data_licen(ByVal _ida As String)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_ida)
        Try
                Dim bao As New BAO_SHOW
            Dim dao_reg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_reg.GetDataby_IDA(dao.fields.FK_IDA)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_reg.fields.FK_IDA)
                Dim dt2 As New DataTable
                Try
                    dt2 = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid)
                    lb_licen.Text = dt2(0)("thanm")
                Catch ex As Exception

                End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub show_data_licen_rqt(ByVal _ida As String)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_ida)
        Try
            Dim bao As New BAO_SHOW
            Dim dao_reg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_reg.GetDataby_IDA(dao.fields.FK_IDA)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(dao_reg.fields.FK_IDA)
            Dim dt2 As New DataTable
            Try
                dt2 = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid)
                lb_licen.Text = dt2(0)("thanm")
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub
    Sub Search_FN()
        Dim lcntpcd As String = ""

        Dim sql As String = ""
        sql = "select * from dbo.VW_DALCN_STAFF_SEARCH where STATUS_NAME = 'อนุมัติ' and "

        Try
            If STATUS_ID = 8 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(_IDA)
                'Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                'dao_regis.GetDataby_IDA(Request.QueryString("IDA"))
                'Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                'dao_dal.GetDataby_IDA(dao_regis.fields.FK_IDA)
                lcntpcd = dao_rg.fields.lcntpcd
            Else
                Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                dao_rg.GetDataby_IDA(_IDA)
                'Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                'dao_regis.GetDataby_IDA(Request.QueryString("IDA"))
                'Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                'dao_dal.GetDataby_IDA(dao_regis.fields.FK_IDA)
                lcntpcd = dao_rg.fields.lcntpcd
            End If

        Catch ex As Exception

        End Try

        Dim bao As New BAO.ClsDBSqlcommand


        Dim dt As New DataTable

        Dim dt2 As New DataTable

        If txt_NUM.Text <> "" Then
            sql &= "lcnno_no like '%" & txt_NUM.Text & "%'"
            If lcntpcd <> "" Then
                If lcntpcd.Contains("ผย") Then
                    sql &= " and lcntpcd like '%ผย%'"
                ElseIf lcntpcd.Contains("นย") Then
                    sql &= " and lcntpcd like '%นย%'"
                End If

            End If

            dt = bao.Queryds(sql)
        End If
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click

        If STATUS_ID = 8 Then
            For Each item As GridDataItem In RadGrid1.SelectedItems
                Dim old_data As String = ""
                Dim new_data As String = ""
                Dim lcntpcd As String = ""
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                Try
                    dao_da.GetDataby_IDA(item("IDA").Text)
                    lcntpcd = dao_da.fields.lcntpcd
                Catch ex As Exception

                End Try

                Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                dao.fields.FK_LCN_IDA = item("IDA").Text
                new_data = "เพิ่มผู้ผลิตในประเทศ: IDA= " & item("IDA").Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                'dao.fields.funccd = ddl_work_type.SelectedValue
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
                            'ws_drug.Timeout = 8000
                            'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)
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
            For Each item As GridDataItem In RadGrid1.SelectedItems
                Dim lcntpcd As String = ""
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                Try
                    dao_da.GetDataby_IDA(item("IDA").Text)
                    lcntpcd = dao_da.fields.lcntpcd
                Catch ex As Exception

                End Try

                Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
                dao.fields.FK_LCN_IDA = item("IDA").Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                'dao.fields.funccd = ddl_work_type.SelectedValue
                dao.insert()
            Next
        End If


        KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "เพิ่มผู้ผลิตในประเทศ", _CLS.CITIZEN_ID)
        RadGrid2.Rebind()
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_infor As New BAO.information

        If e.CommandName = "_del" Then
            Dim item As GridDataItem
            item = e.Item
            Dim old_data As String = ""
            Dim new_data As String = ""
            If Request.QueryString("tt") <> "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                'ElseIf STATUS_ID = 8 Then
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
            Else
                Try
                    If STATUS_ID = 8 Then
                        Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                        dao.GetDataby_IDA(item("IDA").Text)

                        If STATUS_ID = 8 Then
                            Try
                                old_data = "ลบผู้ผลิตต่างประเทศ: IDA = " & item("IDA").Text
                            Catch ex As Exception

                            End Try
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


                        dao.delete()
                        alert("ลบเรียบร้อยแล้ว")
                    Else
                        Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
                        dao.GetDataby_IDA(item("IDA").Text)
                        dao.delete()
                        alert("ลบเรียบร้อยแล้ว")
                    End If
                Catch ex As Exception

                End Try

                KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "ลบผู้ผลิตในประเทศ", _CLS.CITIZEN_ID)
                RadGrid2.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim lbl_comment As Label = DirectCast(item("work_type").FindControl("lbl_work_type"), Label)
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)

            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                dao.GetDataby_IDA(item("IDA").Text)
                Try
                    rcb_work_type.SelectedValue = dao.fields.funccd

                    'If dao.fields.PRODUCER_WORK_TYPE IsNot Nothing Then
                    '    rcb_work_type.Style.Add("display", "none")
                    '    lbl_comment.Style.Add("display", "block")
                    'Else
                    '    rcb_work_type.Style.Add("display", "block")
                    '    lbl_comment.Style.Add("display", "none")
                    'End If
                Catch ex As Exception

                End Try
                Try

                    If dao.fields.funccd = 1 Then
                        lbl_comment.Text = "ผลิตยาสำเร็จรูป"
                    ElseIf dao.fields.funccd = 2 Then
                        lbl_comment.Text = "แบ่งบรรจุ"
                    ElseIf dao.fields.funccd = 3 Then
                        lbl_comment.Text = "ตรวจปล่อยหรือผ่านเพื่อจำหน่าย"
                    ElseIf dao.fields.funccd = 9 Then
                        lbl_comment.Text = "อื่นๆ"
                    End If
                Catch ex As Exception

                End Try
            Else

                Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
                dao.GetDataby_IDA(item("IDA").Text)
                Try
                    rcb_work_type.SelectedValue = dao.fields.funccd

                    'If dao.fields.PRODUCER_WORK_TYPE IsNot Nothing Then
                    '    rcb_work_type.Style.Add("display", "none")
                    '    lbl_comment.Style.Add("display", "block")
                    'Else
                    '    rcb_work_type.Style.Add("display", "block")
                    '    lbl_comment.Style.Add("display", "none")
                    'End If
                Catch ex As Exception

                End Try
                Try

                    If dao.fields.funccd = 1 Then
                        lbl_comment.Text = "ผลิตยาสำเร็จรูป"
                    ElseIf dao.fields.funccd = 2 Then
                        lbl_comment.Text = "แบ่งบรรจุ"
                    ElseIf dao.fields.funccd = 3 Then
                        lbl_comment.Text = "ตรวจปล่อยหรือผ่านเพื่อจำหน่าย"
                    ElseIf dao.fields.funccd = 9 Then
                        lbl_comment.Text = "อื่นๆ"
                    End If
                Catch ex As Exception

                End Try
            End If
            
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        If STATUS_ID = 8 Then
            dt = bao.SP_DRRGT_PRODUCER_IN_BY_FK_IDA(Request.QueryString("IDA"))
        Else
            dt = bao.SP_DRRQT_PRODUCER_IN_BY_FK_IDA(Request.QueryString("IDA"))
        End If
        RadGrid2.DataSource = dt
    End Sub

    Private Sub RadGrid1_ExcelMLWorkBookCreated(sender As Object, e As GridExcelBuilder.GridExcelMLWorkBookCreatedEventArgs) Handles RadGrid1.ExcelMLWorkBookCreated
        Search_FN()
    End Sub
    Protected Sub btn_save_work_type_Click(sender As Object, e As EventArgs) Handles btn_save_work_type.Click
        RunQuery()
        For Each item As GridDataItem In RadGrid2.Items
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)
            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                dao.GetDataby_IDA(item("IDA").Text)
                dao.fields.funccd = rcb_work_type.SelectedValue
                dao.update()
                Dim old_data As String = ""
                Dim new_data As String = ""
                Dim dao_re As New DAO_DRUG.ClsDBdrrgt
                dao_re.GetDataby_IDA(Request.QueryString("IDA"))
                'Dim ws_drug As New WS_DRUG.WS_DRUG
                'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)

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
                Dim dao As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
                dao.GetDataby_IDA(item("IDA").Text)
                dao.fields.funccd = rcb_work_type.SelectedValue
                dao.update()
            End If
            'Try
            '    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
            '    dao.GetDataby_IDA(item("IDA").Text)
            '    dao.fields.PRODUCER_WORK_TYPE = rcb_work_type.SelectedValue
            '    dao.update()
            'Catch ex As Exception

            'End Try
        Next
        KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขหน้าที่ผู้ผลิตในประเทศ", _CLS.CITIZEN_ID)
        Dim dao_dr As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
        dao_dr.GetDataby_FK_IDA(Request.QueryString("IDA"))
        Dim max_no As Integer = 0
        Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
        dao_edt.GET_MAX_NO("DRRGT_PRODUCER_IN", dao_dr.fields.IDA)
        Try
            max_no = dao_edt.fields.COUNT_EDIT
        Catch ex As Exception

        End Try
        'Dim filename As String = ""
        'filename = "DRRGT_PRODUCER_IN_" & max_no + 1 & ".xml"
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
        '    .TABLE_NAME = "DRRGT_PRODUCER_IN"
        'End With
        'dao_index.insert()

        RadGrid2.Rebind()
    End Sub
End Class