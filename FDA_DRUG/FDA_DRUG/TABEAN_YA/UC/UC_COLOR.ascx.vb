Imports System.IO
Imports System.Xml.Serialization

Public Class UC_COLOR
    Inherits System.Web.UI.UserControl
    Dim STATUS_ID As Integer = 0
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
            load_data()
            If Request.QueryString("tt") <> "" Then
                btn_save.Enabled = False
                Panel1.Visible = False
            End If
            'If STATUS_ID = 8 Then
            '    btn_save.Enabled = False
            'End If
        End If
    End Sub
    Private Sub rdl_color_row1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_color_row1.SelectedIndexChanged
        Set_lbl(rdl_color_row1.SelectedValue, 1)
    End Sub
    Sub load_data()
        RunQuery()
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

            Try
                txt_DRUG_COLOR.Text = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.TB_DRRGT_COLOR
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            Dim color1 As Integer = 0
            Try
                rdl_color_row1.SelectedValue = IIf(Len(dao.fields.COLOR1) = 1, "0" & dao.fields.COLOR1, dao.fields.COLOR1)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR1, 1)
            Catch ex As Exception

            End Try

            Try
                rdl_color_row2.SelectedValue = IIf(Len(dao.fields.COLOR2) = 1, "0" & dao.fields.COLOR2, dao.fields.COLOR2)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR2, 2)
            Catch ex As Exception

            End Try

            Try
                rdl_color_row3.SelectedValue = IIf(Len(dao.fields.COLOR3) = 1, "0" & dao.fields.COLOR3, dao.fields.COLOR3)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR3, 3)
            Catch ex As Exception

            End Try
            Try
                rdl_color_row4.SelectedValue = IIf(Len(dao.fields.COLOR4) = 1, "0" & dao.fields.COLOR4, dao.fields.COLOR4)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR4, 4)
            Catch ex As Exception

            End Try
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

            Try
                txt_DRUG_COLOR.Text = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.TB_DRRQT_COLOR
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            Dim color1 As Integer = 0
            Try
                rdl_color_row1.SelectedValue = IIf(Len(dao.fields.COLOR1) = 1, "0" & dao.fields.COLOR1, dao.fields.COLOR1)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR1, 1)
            Catch ex As Exception

            End Try

            Try
                rdl_color_row2.SelectedValue = IIf(Len(dao.fields.COLOR2) = 1, "0" & dao.fields.COLOR2, dao.fields.COLOR2)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR2, 2)
            Catch ex As Exception

            End Try

            Try
                rdl_color_row3.SelectedValue = IIf(Len(dao.fields.COLOR3) = 1, "0" & dao.fields.COLOR3, dao.fields.COLOR3)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR3, 3)
            Catch ex As Exception

            End Try
            Try
                rdl_color_row4.SelectedValue = IIf(Len(dao.fields.COLOR4) = 1, "0" & dao.fields.COLOR4, dao.fields.COLOR4)

            Catch ex As Exception

            End Try
            Try
                Set_lbl(dao.fields.COLOR4, 4)
            Catch ex As Exception

            End Try
        End If

    End Sub
    Sub Set_lbl(ByVal color_val As String, ByVal row_id As Integer)
        If row_id = 1 Then
            lbl_color1.Text = Get_color(color_val)
        ElseIf row_id = 2 Then
            lbl_color2.Text = Get_color(color_val)
        ElseIf row_id = 3 Then
            lbl_color3.Text = Get_color(color_val)
        ElseIf row_id = 4 Then
            lbl_color4.Text = Get_color(color_val)
        End If
    End Sub
    Function Get_color(ByVal color_val As String) As String
        Dim str_color As String = ""
        Dim int_col As Integer = 0
        Try
            int_col = Int(color_val)
        Catch ex As Exception

        End Try
        If int_col <> 0 Then
            Select Case int_col
                Case 1
                    str_color = "ขาว"
                Case 2
                    str_color = "แดง"
                Case 3
                    str_color = "ส้ม"
                Case 4
                    str_color = "เหลือง"
                Case 5
                    str_color = "เขียว"
                Case 6
                    str_color = "ฟ้า"
                Case 7
                    str_color = "น้ำเงิน"
                Case 8
                    str_color = "ชมพู"
                Case 9
                    str_color = "ม่วง"
                Case 10
                    str_color = "น้ำตาล"
                Case 11
                    str_color = "เทา"
                Case 12
                    str_color = "ดำ"
                Case 13
                    str_color = "ไม่ระบุ"
            End Select
        Else
            str_color = "ไม่ระบุ"
        End If

        Return str_color
    End Function

    Private Sub rdl_color_row2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_color_row2.SelectedIndexChanged
        Set_lbl(rdl_color_row2.SelectedValue, 2)
    End Sub

    Private Sub rdl_color_row3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_color_row3.SelectedIndexChanged
        Set_lbl(rdl_color_row3.SelectedValue, 3)
    End Sub

    Private Sub rdl_color_row4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_color_row4.SelectedIndexChanged
        Set_lbl(rdl_color_row4.SelectedValue, 4)
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        RunQuery()
        Dim old_data As String = ""
        Dim old_data2 As String = ""
        Dim new_data As String = ""
        Dim new_data2 As String = ""
        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.TB_DRRGT_COLOR
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            old_data = "สียา " & lbl_color1.Text & "," & lbl_color2.Text & "," & lbl_color3.Text & "," & lbl_color4.Text


            dao.fields.COLOR1 = rdl_color_row1.SelectedValue
            dao.fields.COLOR_NAME1 = lbl_color1.Text
            dao.fields.COLOR2 = rdl_color_row2.SelectedValue
            dao.fields.COLOR_NAME2 = lbl_color2.Text
            dao.fields.COLOR3 = rdl_color_row3.SelectedValue
            dao.fields.COLOR_NAME3 = lbl_color3.Text
            dao.fields.COLOR4 = rdl_color_row4.SelectedValue
            dao.fields.COLOR_NAME4 = lbl_color4.Text
            dao.update()
            new_data = "สียา " & lbl_color1.Text & "," & lbl_color2.Text & "," & lbl_color3.Text & "," & lbl_color4.Text



            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
            old_data2 = dao_rg.fields.DRUG_COLOR
            Try
                dao_rg.fields.DRUG_COLOR = txt_DRUG_COLOR.Text
                new_data2 = txt_DRUG_COLOR.Text
            Catch ex As Exception

            End Try
            Try
                dao_rg.fields.lmdfdate = Date.Now
            Catch ex As Exception

            End Try
            dao_rg.update()


            'dao = New DAO_DRUG.TB_DRRGT_COLOR
            'dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            'Dim max_no As Integer = 0
            'Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            'dao_edt.GET_MAX_NO("DRRGT_COLOR", dao.fields.IDA)
            'Try
            '    max_no = dao_edt.fields.COUNT_EDIT
            'Catch ex As Exception

            'End Try
            Dim i As Integer = 0
            Dim dao_c As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            i = dao_c.CountDataby_FK_IDA(Request.QueryString("IDA"))
            If i = 0 Then
                'Dim dao_max As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
                'dao_max.GET_MAX_ROWS_ID(Request.QueryString("IDA"))
                'Dim id_max As Integer = 0
                'id_max = dao_max.fields.ROWS
                'id_max += 1

                Dim dao_pro As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
                dao_pro.fields.FK_IDA = Request.QueryString("IDA")
                dao_pro.fields.DRUG_PROPERTIES_AND_DETAIL = txt_DRUG_COLOR.Text
                dao_pro.fields.ROWS = 1
                dao_pro.insert()
            Else
                Dim dao_pro As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
                dao_pro.GetDataby_FK_IDA(Request.QueryString("IDA"))
                dao_pro.fields.DRUG_PROPERTIES_AND_DETAIL = txt_DRUG_COLOR.Text
                dao_pro.update()
            End If
           

            'Dim filename As String = ""
            'filename = "DRRGT_COLOR_" & dao_rg.fields.TR_ID & "_" & max_no + 1 & ".xml"
            'Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
            'bao_app.RunAppSettings()
            'Dim path As String = bao_app._PATH_EDIT & filename
            'Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
            'Dim x As New XmlSerializer(dao.fields.GetType)                                                     'ประกาศ
            'x.Serialize(objStreamWriter, dao.fields)
            'objStreamWriter.Close()

            'Dim dao_index As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            'With dao_index.fields
            '    .COUNT_EDIT = max_no + 1
            '    .CREATE_DATE = Date.Now
            '    .FILE_NAME = filename
            '    .FK_DRRGT_IDA = Request.QueryString("IDA")
            '    .FK_IDA = dao.fields.IDA
            '    .TABLE_NAME = "DRRGT_COLOR"
            '    .TR_ID = dao_rg.fields.TR_ID
            'End With
            'dao_index.insert()
        Else
            Dim dao As New DAO_DRUG.TB_DRRQT_COLOR
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            dao.fields.COLOR1 = rdl_color_row1.SelectedValue
            dao.fields.COLOR_NAME1 = lbl_color1.Text
            dao.fields.COLOR2 = rdl_color_row2.SelectedValue
            dao.fields.COLOR_NAME2 = lbl_color2.Text
            dao.fields.COLOR3 = rdl_color_row3.SelectedValue
            dao.fields.COLOR_NAME3 = lbl_color3.Text
            dao.fields.COLOR4 = rdl_color_row4.SelectedValue
            dao.fields.COLOR_NAME4 = lbl_color4.Text
            dao.update()

            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

            Try
                dao_rg.fields.DRUG_COLOR = txt_DRUG_COLOR.Text
            Catch ex As Exception

            End Try
            Try
                dao_rg.fields.lmdfdate = Date.Now
            Catch ex As Exception

            End Try
            dao_rg.update()


            Dim i As Integer = 0
            Dim dao_c As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            i = dao_c.CountDataby_FK_IDA(Request.QueryString("IDA"))
            If i = 0 Then
                'Dim dao_max As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
                'dao_max.GET_MAX_ROWS_ID(Request.QueryString("IDA"))
                'Dim id_max As Integer = 0
                'id_max = dao_max.fields.ROWS
                'id_max += 1
                Dim dao_pro As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
                dao_pro.fields.FK_IDA = Request.QueryString("IDA")
                dao_pro.fields.DRUG_PROPERTIES_AND_DETAIL = txt_DRUG_COLOR.Text
                dao_pro.fields.ROWS = 1
                dao_pro.insert()
            Else
                Dim dao_pro As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
                dao_pro.GetDataby_FKIDA(Request.QueryString("IDA"))
                dao_pro.fields.DRUG_PROPERTIES_AND_DETAIL = txt_DRUG_COLOR.Text
                dao_pro.update()
            End If
        End If
        KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขสียา " & lbl_color1.Text & "," & lbl_color2.Text & "," & lbl_color3.Text & "," & lbl_color4.Text, _CLS.CITIZEN_ID)


        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

            Dim result As String = ""
            Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
            result = ""
            'Try
            '    If Request.QueryString("e") = "" Then
            '        ws_drug.Timeout = 8000
            '        result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
            '    End If

            'Catch ex As Exception

            'End Try
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
            If Request.QueryString("e") <> "" Then
                result = "EDIT RQT"
            End If
            KEEP_LOGS_TABEAN_BC(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, dao_rg.fields.IDA, _
                                dao_rg.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)


            Try
                If Request.QueryString("e") = "" Then
                    ws_drug.Timeout = 8000
                    'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
                    Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                    dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                    Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                    Dim cls_xml_DR As New LGT_IOW_E
                    cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                    Dim str_xml As String = ""
                    Try
                        SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao_rg.fields.IDENTIFY)

                        ws_drug.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                    Catch ex As Exception

                    End Try

                End If
            Catch ex As Exception

            End Try

            KEEP_LOGS_TABEAN_BC(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, dao_rg.fields.IDA, _
                               dao_rg.fields.IDENTIFY, new_data2, "", old_data2, result, url, _CLS.CITIZEN_ID)
        End If
        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
    End Sub
End Class