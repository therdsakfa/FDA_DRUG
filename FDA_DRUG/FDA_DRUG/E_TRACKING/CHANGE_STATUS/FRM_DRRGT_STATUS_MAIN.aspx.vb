Imports Telerik.Web.UI

Public Class FRM_DRRGT_STATUS_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then

                Dim ida As Integer = item("IDA").Text
                Dim newcode As String = item("Newcode").Text

                Dim url_s As String = ""

                Try
                    url_s = "FRM_DRRGT_STATUS_POPUP.aspx?ida=" & ida & "&newcode=" & newcode
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url_s & "');", True) 'เปิดหน้า uplaod
                'btn_sel.Attributes.Add("OnClick", "Popups2('" & url_s & "'); return false;")
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim ida As Integer = item("IDA").Text
            Dim newcode As String = item("Newcode").Text
            'Dim btn_sel As LinkButton = DirectCast(item("sel").Controls(0), LinkButton)
            Dim hp1 As HyperLink = item("hp_sel").FindControl("HyperLink1") 'DirectCast(item("hp_sel").Controls(0), HyperLink)
            Dim url_s As String = ""

            Try
                url_s = "FRM_DRRGT_STATUS_POPUP.aspx?ida=" & ida & "&newcode=" & newcode
            Catch ex As Exception

            End Try
            hp1.NavigateUrl = url_s
            'btn_sel.Attributes.Add("OnClick", "Popups2('" & url_s & "'); return false;")

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRRGT124_ALL()
        dt.Columns.Add("stat")
        For Each dr As DataRow In dt.Rows
            Try
                Dim dao As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
                dao.GetDataby_U1(dr("Newcode"))
                Dim dao_s As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS
                dao_s.GetDataby_STATUS_ID(dao.fields.STATUS_ID)
                dr("stat") = dao_s.fields.STAFF_STATUS
            Catch ex As Exception

            End Try
        Next
        RadGrid1.DataSource = dt
    End Sub

    'Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('.aspx');", True) 'เปิดหน้า uplaod

    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim url_s As String = ""

        Try
            url_s = "FRM_DRRGT_STATUS_POPUP.aspx?ida=" & 5 & "&newcode=" & 2423432423423432
        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PHR_ADD.aspx?ida=" & Request.QueryString("ida") & "&ida_c=" & Request.QueryString("ida_c") & "'); ", True)
    End Sub
End Class