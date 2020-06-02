Imports Telerik.Web.UI

Public Class POPUP_EDIT_COUNT_LIST
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "del" Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim EDIT_TYPE As String = ""
            Try
                EDIT_TYPE = item("EDIT_TYPE").Text
            Catch ex As Exception

            End Try
            If EDIT_TYPE <> "5" And EDIT_TYPE <> "" Then
                Dim dao As New DAO_DRUG.TB_EDT_HISTORY
                dao.GetDataby_IDA(IDA)
                dao.delete()
            Else
                Dim dao As New DAO_DRUG.TB_DALCN_PHR_HISTORY
                dao.GetDataby_IDA(IDA)
                dao.delete()
            End If
           
            Response.Write("<script type='text/javascript'>alert('ลบเรียบร้อยแล้ว');</script> ")
            RadGrid1.Rebind()
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_EDIT_HISTORY_BY_FK_IDA(Request.QueryString("ida"))

        RadGrid1.DataSource = dt
    End Sub
End Class