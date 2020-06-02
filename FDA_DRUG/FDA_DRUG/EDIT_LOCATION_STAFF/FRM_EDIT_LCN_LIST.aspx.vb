Imports Telerik.Web.UI

Public Class FRM_EDIT_LCN_LIST
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim btn_edit As LinkButton = DirectCast(item("_edit").Controls(0), LinkButton)

            Dim url As String = ""

            url = "../EDIT_LOCATION_STAFF/FRM_EDIT_LCN_PAGE.aspx?IDA=" & IDA & "&edt=" & Request.QueryString("edt")

            btn_edit.Attributes.Add("onclick", "Popups2('" & url & "'); return false;")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        'SP_LCN_STAFF_EDIT
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_LCN_STAFF_EDIT(Request.QueryString("ida"))
        Try
            dt = bao.dt
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
End Class