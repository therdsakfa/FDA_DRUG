Imports Telerik.Web.UI

Public Class FRM_CHEMICAL_STAFF_SEARCH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Private _type As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
        _type = Request.QueryString("type")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            runQuery()

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        '
        If TypeOf e.Item Is GridDataItem Then

            Dim item As GridDataItem = e.Item
            Dim iowa As String = ""
        
            iowa = item("iowacd").Text & item("runno").Text & item("salt").Text & item("syn").Text
            If e.CommandName = "_edit" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_CHEMICAL_STAFF_EDIT.aspx?iowa=" & iowa & "&IDA=" & item("IDA").Text & "');", True)
            End If

        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_CHEMICAL_SEARCH_RESULT_STAFF()
        RadGrid1.DataSource = dt
    End Sub
    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Dim strMsg As String = ""
        strMsg = "([iowanm] LIKE '%" & txt_iowanm.Text & "%')" & _
            " and ([iowa] LIKE '%" & txt_iowa.Text & "%')"

        RadGrid1.EnableLinqExpressions = False
        RadGrid1.MasterTableView.FilterExpression = strMsg
        RadGrid1.MasterTableView.Rebind()
    End Sub
End Class