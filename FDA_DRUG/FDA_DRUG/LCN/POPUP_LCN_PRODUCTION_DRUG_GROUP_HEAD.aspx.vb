Public Class POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP_HEAD
                dao.GetDataby_FK_IDA(Request.QueryString("ida"))
                Dim i As Integer = 0
                For Each dao.fields In dao.datas
                    i += 1
                    Dim selected_type As String = ""
                    Try
                        selected_type = dao.fields.TYPE_SELECTED
                    Catch ex As Exception

                    End Try
                    Try
                        If dao.fields.FK_TYPE = 1 Then
                            rdl_type1.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 2 Then
                            rdl_type2.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 3 Then
                            rdl_type3.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 4 Then
                            rdl_type4.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 5 Then
                            rdl_type5.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 6 Then
                            rdl_type6.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 7 Then
                            rdl_type7.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 8 Then
                            rdl_type8.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 9 Then
                            rdl_type9.SelectedValue = selected_type
                        End If
                        If dao.fields.FK_TYPE = 10 Then
                            rdl_type10.SelectedValue = selected_type
                        End If
                    Catch ex As Exception

                    End Try
                Next
                If i > 0 Then
                    btn_next.Style.Add("display", "block")
                Else
                    btn_next.Style.Add("display", "none")
                End If
            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_del As New DAO_DRUG.TB_MAS_DRUG_GROUP_HEAD
        dao_del.GetDataby_IDA(Request.QueryString("ida"))
        For Each dao_del.fields In dao_del.datas
            dao_del.delete()
        Next
        If rdl_type1.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 1, rdl_type1.SelectedValue)
        End If
        If rdl_type2.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 2, rdl_type2.SelectedValue)
        End If
        If rdl_type3.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 3, rdl_type3.SelectedValue)
        End If
        If rdl_type4.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 4, rdl_type4.SelectedValue)
        End If
        If rdl_type5.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 5, rdl_type5.SelectedValue)
        End If
        If rdl_type6.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 6, rdl_type6.SelectedValue)
        End If
        If rdl_type7.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 7, rdl_type7.SelectedValue)
        End If
        If rdl_type8.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 8, rdl_type8.SelectedValue)
        End If
        If rdl_type9.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 9, rdl_type9.SelectedValue)
        End If
        If rdl_type10.SelectedValue <> "" Then
            insert_data(Request.QueryString("ida"), 10, rdl_type10.SelectedValue)
        End If
        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri ' & "&IDA=" & dao.fields.IDA
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)

    End Sub
    Sub insert_data(ByVal fk_ida As String, ByVal fk_type As Integer, ByVal type_select As Integer)
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP_HEAD
        dao.fields.FK_IDA = fk_ida
        dao.fields.FK_TYPE = fk_type
        dao.fields.TYPE_SELECTED = type_select
        dao.insert()
    End Sub

    Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        Response.Redirect("POPUP_LCN_PRODUCTION_DRUG_GROUP2.aspx?ida=" & Request.QueryString("ida") & "&h=1")
    End Sub
End Class