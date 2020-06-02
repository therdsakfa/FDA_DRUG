Public Class UC_DRUG_COLOR
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            load_data()
            If Request.QueryString("tt") <> "" Then
                btn_save.Visible = False
            End If
        End If
    End Sub

    Private Sub rdl_color_row1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_color_row1.SelectedIndexChanged
        Set_lbl(rdl_color_row1.SelectedValue, 1)
    End Sub
    Sub load_data()
        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

        Try
            txt_DRUG_COLOR.Text = dao_rg.fields.DRUG_COLOR
        Catch ex As Exception

        End Try

        Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
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
        Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
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

        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

        Try
            dao_rg.fields.DRUG_COLOR = txt_DRUG_COLOR.Text
        Catch ex As Exception

        End Try
        dao_rg.update()
        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
    End Sub
End Class