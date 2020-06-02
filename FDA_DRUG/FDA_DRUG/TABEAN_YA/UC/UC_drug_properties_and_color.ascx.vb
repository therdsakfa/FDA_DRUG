Imports Telerik.Web.UI

Public Class UC_drug_properties_and_color
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
    End Sub

    Private Sub rg_color_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_color.ItemCommand
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

                    Dim dao As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
                    dao.GetDataby_IDA(IDA)
                    old_data = "ลบข้อมูล : " & dao.fields.DRUG_PROPERTIES_AND_DETAIL
                    dao.delete()


                    If STATUS_ID = 8 Then
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

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

                        KEEP_LOGS_TABEAN_BC(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, dao_rg.fields.IDA, _
                                            dao_rg.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                    End If

                Else
                    Dim dao As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                End If

                rg_color.Rebind()
            End If

        End If
    End Sub

    Private Sub rg_color_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_color.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_FK_DRRQT(_IDA)
        If STATUS_ID = 8 Then

            dt = bao.SP_DRRGT_PROPERTIES_AND_DETAIL_BY_FK_IDA(dao.fields.IDA)
        Else
            dt = bao.SP_DRRQT_PROPERTIES_AND_DETAIL_BY_FK_IDA(_IDA)
        End If

        rg_color.DataSource = dt
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If STATUS_ID = 8 Then
            Dim old_data As String = ""
            Dim new_data As String = ""
            Dim dao_rq As New DAO_DRUG.ClsDBdrrgt
            dao_rq.GetDataby_IDA(_IDA)
            dao_rq.fields.lmdfdate = Date.Now
            dao_rq.update()
            Dim dao_max As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao_max.GET_MAX_ROWS_ID(_IDA)
            Dim id_max As Integer = 0
            id_max = dao_max.fields.ROWS
            id_max += 1

            new_data = "เพิ่มลักษณะและสีของยา :" & txt_detail.Text
            Dim dao As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao.fields.FK_IDA = _IDA
            dao.fields.DRUG_PROPERTIES_AND_DETAIL = txt_detail.Text
            dao.fields.ROWS = id_max
            dao.insert()

            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_rq.fields.pvncd, dao_rq.fields.rgttpcd, dao_rq.fields.drgtpcd, dao_rq.fields.rgtno)
            If STATUS_ID = 8 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

                Dim result As String = ""
                Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                If Request.QueryString("e") <> "" Then
                    result = "EDIT RQT"
                End If
                Try
                    If Request.QueryString("e") = "" Then
                        ' ws_drug.Timeout = 8000
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

                KEEP_LOGS_TABEAN_BC(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, dao_rg.fields.IDA, _
                                    dao_rg.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

            End If




        Else
            Dim dao_max As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            dao_max.GET_MAX_ROWS_ID(_IDA)
            Dim id_max As Integer = 0
            id_max = dao_max.fields.ROWS
            id_max += 1

            Dim dao As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            dao.fields.FK_IDA = _IDA
            dao.fields.DRUG_PROPERTIES_AND_DETAIL = txt_detail.Text
            dao.fields.ROWS = id_max
            dao.insert()
        End If
        
        rg_color.Rebind()
        alert("บันทึกข้อมูลเรียบร้อยแล้ว")
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class