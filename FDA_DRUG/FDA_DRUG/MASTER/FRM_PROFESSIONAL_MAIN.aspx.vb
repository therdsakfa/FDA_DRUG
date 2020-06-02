Imports Telerik.Web.UI

Public Class FRM_PROFESSIONAL_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim dao As New DAO_DRUG.TB_MAS_PROFESSIONAL_NAME
            dao.GetDataby_IDA(item("IDA").Text)

            Dim dao_his As New DAO_DRUG.TB_DALCN_PHR_HISTORY
            If e.CommandName = "edt" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PROFESSIONAL_INSERT_AND_UPDATE.aspx?ida=" & item("IDA").Text & "');", True)

            End If
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_GET_ALL_PROFESSIONAL()
        RadGrid2.DataSource = dt
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid2.Rebind()
    End Sub

    Private Sub btn_manual_Click(sender As Object, e As EventArgs) Handles btn_manual.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PROFESSIONAL_INSERT_AND_UPDATE.aspx');", True)

    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PROFESSIONAL_IMPORT.aspx');", True)

    End Sub
End Class