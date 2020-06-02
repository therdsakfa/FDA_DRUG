Imports Telerik.Web.UI

Public Class FRM_E_TRACKING_TIME_CAL_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("IDA").Text
            Dim btn_sel As LinkButton = DirectCast(item("sel").Controls(0), LinkButton)
            Dim btn_print As LinkButton = DirectCast(item("print").Controls(0), LinkButton)
            btn_sel.Attributes.Add("OnClick", "Popups2('FRM_E_TRACKING_TIME_CAL_POPUP.aspx?ida=" & id & "'); return false;")

            Dim url As String = "../TIME_CALCULATE/Report/FRM_REPORT.aspx?ida=" & id
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "', '_blank');", True)
            btn_print.Attributes.Add("OnClick", "window.open('" & url & "', '_blank'); return false;")

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        Try
            dt = bao.SP_E_TRACKING_REPORT_PROCESS_ALL()
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
    'SP_E_TRACKING_WORK_DAY_REPORT
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim url_s As String = ""

        Try
            url_s = "FRM_DRRGT_STATUS_POPUP.aspx?ida=" & 5 & "&newcode=" & 2423432423423432
        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_E_TRACKING_TIME_CAL_POPUP.aspx'); ", True)
    End Sub
End Class