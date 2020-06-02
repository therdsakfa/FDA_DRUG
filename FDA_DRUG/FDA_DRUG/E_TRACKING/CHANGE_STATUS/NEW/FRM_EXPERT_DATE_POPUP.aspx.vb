Public Class FRM_EXPERT_DATE_POPUP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                Try
                    Dim dao_stat As New DAO_DRUG.TB_MAS_EXPERT_NAME
                    dao_stat.GetDataby_IDA(dao.fields.FK_EXPERT)
                    lbl_head_status.Text = dao_stat.fields.FULLNAME
                Catch ex As Exception

                End Try


                Try
                    txt_start_date.Text = CDate(dao.fields.TIME_START_DATE).ToShortDateString()
                Catch ex As Exception

                End Try
                Try
                    txt_end_date.Text = CDate(dao.fields.TIME_STOP_DATE).ToShortDateString()
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            'Try
            '    dao.fields.TIME_START_DATE = CDate(txt_start_date.Text)
            'Catch ex As Exception

            'End Try
            Try
                dao.fields.TIME_STOP_DATE = CDate(txt_end_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

        End If
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url2 As String = ""
        
        If Request.QueryString("id_r") <> "" Then
            url2 = "../FRM_EXPERT_ASSIGN_V4.aspx?ida=" & Request.QueryString("id_h") & "&id_r=" & Request.QueryString("id_r")
        Else
            url2 = "CHANGE_STATUS/FRM_EXPERT_ASSIGN_V4.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&drgtpcd=" & Request.QueryString("drgtpcd")

        End If
        Response.Redirect(url2)
    End Sub
End Class