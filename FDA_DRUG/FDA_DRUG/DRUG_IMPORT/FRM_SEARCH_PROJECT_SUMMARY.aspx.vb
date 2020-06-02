Imports Telerik.Web.UI

Public Class FRM_SEARCH_PROJECT_SUMMARY
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        RadGrid1.Visible = True
        RadGrid1.Rebind()

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid1.DataSource = bao.SP_DRUG_SEARCH_PROJECT_SUMMARY(TextBox1.Text)
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim TR_ID As String = ""
            Try
                TR_ID = item("TR_ID").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA(IDA)

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_SEARCH_VIEWDATA.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "');", True)
            ElseIf e.CommandName = "chnge" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_RESEARCH_ROLE.aspx?IDA=" & IDA & "&FK_IDA=" & IDA & "&TR_ID=" & dao.fields.TR_ID & "&ProcessID=" & 10261 & "');", True)
            End If

        End If
    End Sub
End Class