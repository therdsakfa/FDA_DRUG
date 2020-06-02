Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UC_DRUG_KEEP
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
            If STATUS_ID = 8 Then
              
                Dim dao_k As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
                dao_k.GetDataby_FKIDA(Request.QueryString("IDA"))
                txt_KEEP_DESCRIPTION.Text = dao_k.fields.KEEP_DESCRIPTION
                Try
                    txt_AGE_DAY.Text = dao_k.fields.AGE_DAY
                Catch ex As Exception

                End Try
                Try
                    txt_AGE_HOUR.Text = dao_k.fields.AGE_HOUR
                Catch ex As Exception

                End Try
                Try
                    txt_AGE_MONTH.Text = dao_k.fields.AGE_MONTH
                Catch ex As Exception

                End Try
                Try
                    txt_TEMPERATE1.Text = dao_k.fields.TEMPERATE1
                Catch ex As Exception

                End Try
                Try
                    txt_TEMPERATE2.Text = dao_k.fields.TEMPERATE2
                Catch ex As Exception

                End Try
                Try
                    txt_DRUG_DETAIL.Text = dao_k.fields.DRUG_DETAIL
                Catch ex As Exception

                End Try

            Else
                
                Dim dao_k As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
                dao_k.GetDataby_FKIDA(Request.QueryString("IDA"))
                txt_KEEP_DESCRIPTION.Text = dao_k.fields.KEEP_DESCRIPTION
                Try
                    txt_AGE_DAY.Text = dao_k.fields.AGE_DAY
                Catch ex As Exception

                End Try
                Try
                    txt_AGE_HOUR.Text = dao_k.fields.AGE_HOUR
                Catch ex As Exception

                End Try
                Try
                    txt_AGE_MONTH.Text = dao_k.fields.AGE_MONTH
                Catch ex As Exception

                End Try
                Try
                    txt_TEMPERATE1.Text = dao_k.fields.TEMPERATE1
                Catch ex As Exception

                End Try
                Try
                    txt_TEMPERATE2.Text = dao_k.fields.TEMPERATE2
                Catch ex As Exception

                End Try
                Try
                    txt_DRUG_DETAIL.Text = dao_k.fields.DRUG_DETAIL
                Catch ex As Exception

                End Try
            End If

            If Request.QueryString("tt") <> "" Then
                btn_save.Enabled = False

            End If
            'If STATUS_ID = 8 Then
            '    btn_save.Enabled = False
            'End If
        End If
    End Sub

    Private Sub rg_keep_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_keep.ItemCommand
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

                    'ElseIf STATUS_ID = "8" Then
                    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else
                    If STATUS_ID = 8 Then
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
                        dao_rg.fields.lmdfdate = Date.Now
                        dao_rg.update()
                        Dim dao As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
                        dao.GetDataby_IDA(IDA)
                        Dim old_data As String = ""
                        Dim new_data As String = ""
                        new_data = "ลบข้อมูล IDA_DRRGT_KEEP_DRUG=" & dao.fields.IDA & ", อายุการใช้งาน : " & dao.fields.AGE_MONTH & " เดือน " & dao.fields.AGE_DAY & " วัน " & dao.fields.AGE_HOUR & " ชั่วโมง " & _
                        ",ช่วงอุณหภูมิการเก็บรักษา : ระหว่าง " & dao.fields.TEMPERATE1 & " องศาเซลเซียส  ถึง " & dao.fields.TEMPERATE2 & " องศาเซลเซียส ,สภาวะการเก็บรักษา : " & dao.fields.KEEP_DESCRIPTION & _
                        " ,ลักษณะยา :" & dao.fields.DRUG_DETAIL
                        If STATUS_ID = 8 Then
                            'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                            'dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

                            Dim result As String = ""
                            Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                            If Request.QueryString("e") <> "" Then
                                result = "EDIT RQT"
                            End If
                            Try
                                If Request.QueryString("e") = "" Then
                                    'Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
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




                        dao.delete()
                    Else
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
                        dao_rg.fields.lmdfdate = Date.Now
                        dao_rg.update()
                        Dim dao As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
                        dao.GetDataby_IDA(IDA)
                        dao.delete()
                    End If
                    rg_keep.Rebind()
                End If
            End If
        End If
    End Sub

    Private Sub rg_keep_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_keep.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If STATUS_ID = 8 Then
            dt = bao.SP_DRRGT_KEEP_DRUG_BY_FK_IDA(_IDA)
        Else
            dt = bao.SP_DRRQT_KEEP_DRUG_BY_FK_IDA(_IDA)
        End If
        rg_keep.DataSource = dt
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim old_data As String = ""
        Dim new_data As String = ""
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
            dao_rg.fields.lmdfdate = Date.Now
            dao_rg.update()
            Dim dao As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            Try
                dao.fields.AGE_DAY = txt_AGE_DAY.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.AGE_HOUR = txt_AGE_HOUR.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.AGE_MONTH = txt_AGE_MONTH.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.TEMPERATE1 = txt_TEMPERATE1.Text
            Catch ex As Exception

            End Try
            dao.fields.DRUG_DETAIL = txt_DRUG_DETAIL.Text
            dao.fields.FK_IDA = _IDA
            Try
                dao.fields.KEEP_DESCRIPTION = txt_KEEP_DESCRIPTION.Text
            Catch ex As Exception

            End Try

            Try
                dao.fields.TEMPERATE2 = txt_TEMPERATE2.Text
            Catch ex As Exception

            End Try
            new_data = "บันทึก อายุการใช้งาน : " & txt_AGE_MONTH.Text & " เดือน " & txt_AGE_DAY.Text & " วัน " & txt_AGE_HOUR.Text & " ชั่วโมง " & _
                ",ช่วงอุณหภูมิการเก็บรักษา : ระหว่าง " & txt_TEMPERATE1.Text & " องศาเซลเซียส  ถึง " & txt_TEMPERATE2.Text & " องศาเซลเซียส ,สภาวะการเก็บรักษา : " & txt_KEEP_DESCRIPTION.Text & _
                " ,ลักษณะยา :" & txt_DRUG_DETAIL.Text
            If STATUS_ID = 8 Then
                'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                'dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

                Dim result As String = ""
                Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                If Request.QueryString("e") <> "" Then
                    result = "EDIT RQT"
                End If
                Try
                    If Request.QueryString("e") = "" Then
                        ws_drug.Timeout = 8000
                        ' = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)

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
                        Catch ex As Exception

                        End Try
                    End If

                Catch ex As Exception

                End Try
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                KEEP_LOGS_TABEAN_BC(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, dao_rg.fields.IDA, _
                                    dao_rg.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

            End If



            dao.insert()

            Dim dao_dr As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            dao_dr.GetDataby_FKIDA(_IDA)
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_KEEP_DRUG", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try
            'Dim filename As String = ""
            'filename = "DRRGT_KEEP_DRUG_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "DRRGT_KEEP_DRUG"
            'End With
            'dao_index.insert()

            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno)
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
            dao_rg.fields.lmdfdate = Date.Now
            dao_rg.update()
            Dim dao As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
            Try
                dao.fields.AGE_DAY = txt_AGE_DAY.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.AGE_HOUR = txt_AGE_HOUR.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.AGE_MONTH = txt_AGE_MONTH.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.TEMPERATE1 = txt_TEMPERATE1.Text
            Catch ex As Exception

            End Try
            dao.fields.DRUG_DETAIL = txt_DRUG_DETAIL.Text
            dao.fields.FK_IDA = _IDA
            dao.fields.KEEP_DESCRIPTION = txt_KEEP_DESCRIPTION.Text
            Try
                dao.fields.TEMPERATE2 = txt_TEMPERATE2.Text
            Catch ex As Exception

            End Try
            dao.insert()
        End If
        KEEP_LOGS_TABEAN_EDIT(_IDA, "แก้ไขการเก็บรักษายา", _CLS.CITIZEN_ID)
        rg_keep.Rebind()
        alert("บันทึกข้อมูลเรียบร้อย")
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class