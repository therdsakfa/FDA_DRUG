Public Class FRM_RCA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub btn_rca_Click(sender As Object, e As EventArgs) Handles btn_rca.Click
        Try


            Dim ref_no As String = txt_ref.Text
            Dim r As String = String.Empty
            Dim c As String = String.Empty
            Dim a As String = String.Empty
            Dim dt As New DataTable
            Dim bao As New BAO.ClsDBSqlcommand

            dt = bao.SP_RCA_by_REF_NO(ref_no)

            If dt.Rows.Count = 0 Then

                r = "ไม่พบข้อมูล"
                c = "ไม่พบข้อมูล"
                a = "ไม่พบข้อมูล"

            Else

                For Each dr As DataRow In dt.Rows
                    Try
                        r = dr("r")
                    Catch ex As Exception
                        r = "ไม่พบข้อมูล"
                    End Try
                    Try
                        c = dr("c")
                    Catch ex As Exception
                        c = "ไม่พบข้อมูล"
                    End Try
                    Try
                        a = dr("a")
                    Catch ex As Exception
                        a = "ไม่พบข้อมูล"
                    End Try

                Next

            End If
            lbl_ref.Text = ref_no
            lbl_r.Text = r
            lbl_c.Text = c
            lbl_a.Text = a
        Catch ex As Exception

        End Try
    End Sub
End Class