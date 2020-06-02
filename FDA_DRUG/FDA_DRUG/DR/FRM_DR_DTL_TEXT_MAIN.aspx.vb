Imports Telerik.Web.UI

Public Class FRM_DR_DTL_TEXT_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อยแล้ว'); ", True)
                RadGrid1.Rebind()
            ElseIf e.CommandName = "_edit" Then
                Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                dao.GetDataby_IDA(item("IDA").Text)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE_V2.aspx?IDA=" & item("IDA").Text & "');", True) 'เปิดหน้า uplaod

            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_GET_DRRGT_DTL_TEXT_ALL()

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE.aspx');", True) 'เปิดหน้า uplaod
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class