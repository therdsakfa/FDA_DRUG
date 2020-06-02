Public Class POPUP_PHR_HISTORY
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.DALCN_PHR_HISTORY_BY_FK_IDA(Request.QueryString("ida"))

        RadGrid2.DataSource = dt
    End Sub
End Class