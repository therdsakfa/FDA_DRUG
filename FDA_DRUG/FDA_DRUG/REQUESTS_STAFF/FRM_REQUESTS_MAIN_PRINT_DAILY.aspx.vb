Imports Telerik.Web.UI

Public Class FRM_REQUESTS_MAIN_PRINT_DAILY
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "print" Then
                Dim btn_print As LinkButton = DirectCast(item("print").Controls(0), LinkButton)
               Dim ddl_ad As DropDownList = CType(item.FindControl("ddl_advertise"), DropDownList)
                Dim url_s As String = ""
                Dim dao As New DAO_DRUG.TB_CONSIDER_REQ_PRINT_HISTORY
                dao.GetDataby_IDA(item("IDA").Text)
                If dao.fields.GROUP_NO <> 2 Then
                    url_s = "../REQUESTS_STAFF/FRM_REQUESTS_PRINT_PAGE.aspx?ida=" & item("IDA").Text
                Else
                    url_s = "../REQUESTS_STAFF/FRM_REQUESTS_PRINT_PAGE.aspx?ida=" & item("IDA").Text & "&g=" & dao.fields.SUB_GROUP_NO
                End If
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url_s & "');", True)
                'btn_print.Attributes.Add("OnClick", "Popups2('" & url_s & "'); return false;")
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        '
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim btn_print As LinkButton = DirectCast(item("print").Controls(0), LinkButton)
            'Dim ddl_ad As DropDownList = item.FindControl("advertise").Controls(0)  'DirectCast(item("advertise").Controls(0), DropDownList)
            'Dim ddl_ad As DropDownList = CType(item.FindControl("ddl_advertise"), DropDownList)

            Dim dao As New DAO_DRUG.TB_CONSIDER_REQ_PRINT_HISTORY
            dao.GetDataby_IDA(IDA)
            'If dao.fields.GROUP_NO <> 2 Then
            '    ddl_ad.Style.Add("display", "none")
            'Else
            '    ddl_ad.Style.Add("display", "block")
            'End If

            Try
                
            Catch ex As Exception

            End Try

            
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_CONSIDER_REQ_PRINT_HISTORY()
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
End Class