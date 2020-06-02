Imports Telerik.Web.UI

Public Class FRM_STAFF_OFFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            If e.CommandName = "_del" Then
                Dim IDA As Integer = item("IDA").Text
                Dim dao As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao.GetDataby_IDA(IDA)
                dao.delete()

                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim btn_edit As LinkButton = DirectCast(item("_edit").Controls(0), LinkButton)
            Dim url As String = "../LCN_STAFF/FRM_STAFF_OFFER_INSERT_AND_UPDATE.aspx?IDA=" & item("IDA").Text & "&update=1"
            btn_edit.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
           
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_STAFF_OFFER()

        RadGrid1.DataSource = bao.dt
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click

    End Sub
End Class