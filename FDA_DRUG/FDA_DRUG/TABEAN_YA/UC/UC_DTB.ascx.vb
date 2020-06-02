Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UC_DTB
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
            If Request.QueryString("tt") <> "" Then
                btn_select.Enabled = False
            End If
            'If STATUS_ID = "8" Then
            '    btn_select.Enabled = False
            'End If
        End If
    End Sub

    Protected Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub
    Sub Search_FN()
        'Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_DALCN_STAFF_SEARCH()
        Dim lcntpcd As String = ""

        Dim sql As String = ""
        sql = "select * from dbo.VW_DALCN_STAFF_SEARCH where lcntpcd in ('ขย1','ขย4','ขยบ') and STATUS_NAME ='อนุมัติ' "
        'Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        'Try
        '    dao_regis.GetDataby_IDA(Request.QueryString("IDA"))
        '    Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        '    dao_dal.GetDataby_IDA(dao_regis.fields.FK_IDA)
        '    lcntpcd = dao_dal.fields.lcntpcd
        'Catch ex As Exception

        'End Try

        Dim bao As New BAO.ClsDBSqlcommand


        Dim dt As New DataTable

        'Dim r_result As DataRow()
        'Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_NUM.Text <> "" Then
            'If sql <> "" Then
            '    str_where &= " and lcnno_no like '%" & txt_NUM.Text & "%'"
            'Else
            sql &= "and lcnno_no like '%" & txt_NUM.Text & "%'"
            'End If

            'If lcntpcd <> "" Then
            '    If lcntpcd.Contains("ผย") Then
            '        sql &= " and lcntpcd like '%ผย%'"
            '    ElseIf lcntpcd.Contains("นย") Then
            '        sql &= " and lcntpcd like '%นย%'"
            '    End If

            'End If

            dt = bao.Queryds(sql)
        End If

        'r_result = dt.Select(str_where)

        'dt2 = dt.Clone

        'For Each dr As DataRow In r_result
        '    dt2.Rows.Add(dr.ItemArray)
        'Next

        RadGrid1.DataSource = dt
    End Sub

    Protected Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
       
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_IDA)
            dao_rg.fields.lmdfdate = Date.Now
            dao_rg.update()
            For Each item As GridDataItem In RadGrid1.SelectedItems
                Dim old_data As String = ""
                Dim new_data As String = ""

                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                Try
                    dao_da.GetDataby_IDA(item("IDA").Text)
                Catch ex As Exception

                End Try
                new_data = "เพิ่มผู้แทนจำหน่าย IDA :" & item("IDA").Text

                Dim dao As New DAO_DRUG.TB_DRRGT_DTB
                dao.fields.FK_LCN_IDA = item("IDA").Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.insert()

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
                            'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
                            ws_drug.Timeout = 8000
                            'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
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

            Dim dao_dr As New DAO_DRUG.TB_DRRGT_DTB
            dao_dr.GetDataby_FKIDA(_IDA)
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_DTB", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try

            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno)

            'Dim filename As String = ""
            'filename = "DRRGT_DTB_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "DRRGT_DTB"
            'End With
            'dao_index.insert()
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(_IDA)
            dao_rg.fields.lmdfdate = Date.Now
            dao_rg.update()
            For Each item As GridDataItem In RadGrid1.SelectedItems
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                Try
                    dao_da.GetDataby_IDA(item("IDA").Text)
                Catch ex As Exception

                End Try

                Dim dao As New DAO_DRUG.TB_DRRQT_DTB
                dao.fields.FK_LCN_IDA = item("IDA").Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.insert()
            Next
        End If
        KEEP_LOGS_TABEAN_EDIT(_IDA, "แก้ไขผู้แทนจำหน่าย", _CLS.CITIZEN_ID)
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_infor As New BAO.information

        If e.CommandName = "_del" Then
            Dim item As GridDataItem
            item = e.Item
            If Request.QueryString("tt") <> "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                'ElseIf STATUS_ID = "8" Then
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
            Else
                If STATUS_ID = 8 Then
                    Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                    dao_rg.GetDataby_IDA(_IDA)
                    dao_rg.fields.lmdfdate = Date.Now
                    dao_rg.update()
                    Dim dao As New DAO_DRUG.TB_DRRGT_DTB
                    dao.GetDataby_IDA(item("IDA").Text)
                    dao.delete()

                    If Request.QueryString("e") = "" Then
                        Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                        ws_drug.Timeout = 8000
                        'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
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

                    alert("ลบเรียบร้อยแล้ว")
                Else
                    Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                    dao_rg.GetDataby_IDA(_IDA)
                    dao_rg.fields.lmdfdate = Date.Now
                    dao_rg.update()
                    Dim dao As New DAO_DRUG.TB_DRRQT_DTB
                    dao.GetDataby_IDA(item("IDA").Text)
                    dao.delete()
                    alert("ลบเรียบร้อยแล้ว")
                End If

                RadGrid2.Rebind()
            End If
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If STATUS_ID = 8 Then
            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            dao1.GetDataby_FK_DRRQT(_IDA)
            dt = bao.SP_DRRGT_DTB_BY_FK_IDA(_IDA)
        Else
            dt = bao.SP_DRRQT_DTB_BY_FK_IDA(_IDA)
        End If

        RadGrid2.DataSource = dt
    End Sub
End Class