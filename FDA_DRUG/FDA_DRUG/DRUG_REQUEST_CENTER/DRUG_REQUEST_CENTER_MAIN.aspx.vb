Imports Telerik.Web.UI

Public Class DRUG_REQUEST_CENTER_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private Sub RunQuery()
        If IsNothing(Session("CLS")) Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _CLS = Session("CLS")
            _process = Request.QueryString("IDA")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('DRUG_REQUEST_CENTER_INSERT.aspx" & "');", True) 'เปิดหน้า 
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DRUG_REQUEST_CENTER_MAIN_STAFF()
        Try
            RadGrid1.DataSource = bao.dt
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub RadGrid1_RowCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem
            item = e.Item

            If e.CommandName = "sel" Then

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "DRUG_REQUEST_CENTER_PREVIEW.aspx?IDA=" & item("IDA").Text & "');", True)

            ElseIf e.CommandName = "_del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                Dim IDA As String = item("IDA").Text

                dao.GetDataby_IDA(CDec(IDA))
                dao.fields.ACTIVE = 0
                dao.update()
                RadGrid1.Rebind()
            ElseIf e.CommandName = "_report" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../DRUG_REQUEST_CENTER/Report/FRM_REPORT_REQUEST.aspx?IDA=" & item("IDA").Text & "');", True)
            End If
        End If
    End Sub

    Private Sub btn_add2_Click(sender As Object, e As EventArgs) Handles btn_add2.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPORT_REQUEST.aspx" & "');", True) 'เปิดหน้า 
    End Sub
End Class