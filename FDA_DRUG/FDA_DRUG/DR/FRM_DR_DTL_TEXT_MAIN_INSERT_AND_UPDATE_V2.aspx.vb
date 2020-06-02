Public Class FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE_V2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            If Request.QueryString("IDA") <> "" Then
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                txt_dtl.Text = dao.fields.dtl
                txt_pcksize.Text = dao.fields.pcksize


                Dim bao As New BAO.ClsDBSqlcommand
                Dim dt As New DataTable
                Try
                    dt = bao.Get_U1_Data_BY_U1(dao.fields.U1_CODE)
                Catch ex As Exception

                End Try

                For Each dr As DataRow In dt.Rows
                    Try
                        lbl_engdrgtpnm.Text = dr("engdrgtpnm")
                    Catch ex As Exception

                    End Try
                    Try
                        lbl_lcnno_display.Text = dr("lcnno_display")
                    Catch ex As Exception

                    End Try
                    Try
                        lbl_product_name.Text = dr("product_name")
                    Catch ex As Exception

                    End Try
                    Try
                        lbl_rgttpcd.Text = dr("rgttpcd")
                    Catch ex As Exception

                    End Try
                Next
            End If

        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            dao.fields.dtl = txt_dtl.Text
            dao.fields.pcksize = txt_pcksize.Text
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย'); parent.$('#ContentPlaceHolder1_btn_reload').click();", True)
        End If
    End Sub
End Class