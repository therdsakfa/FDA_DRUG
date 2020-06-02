Imports Telerik.Web.UI
Public Class DRUG_REQUEST_BY_CUSTOMER_MAIN
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
        Dim ctz As String = ""
        Try
            ctz = _CLS.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('DRUG_REQUEST_CENTER_INSERT_CUSTOMER.aspx?ctz=" & ctz & "');", True) 'เปิดหน้า 
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        '_pay
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            'Dim btn_pay As LinkButton = DirectCast(item("_pay").Controls(0), LinkButton)
            Dim hp1 As New HyperLink
            hp1 = DirectCast(item("_pay").FindControl("hp1"), HyperLink)
            'btn_pay.Style.Add("display", "none")
            Dim rq_number As String = item("RCVNO_DISPLAY").Text
            rq_number = rq_number.Replace("-", "z")

            hp1.NavigateUrl = "http://164.115.28.133/SPECIAL_PAYMENT_DRUG_BSN_DEMO/MAIN/FRM_CHECK_TOKEN.aspx?Token=" & _CLS.TOKEN & "&RQ_ID=" & rq_number
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim ctz As String = ""
        Try
            ctz = _CLS.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DRUG_REQUEST_CENTER_MAIN_STAFF_BY_CTZNO_AUT(ctz)
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
                'ElseIf e.CommandName = "_pay" Then
                '    Dim rq_number As String = item("RCVNO_DISPLAY").Text
                '    rq_number = rq_number.Replace("-", "z")
                '    Dim hp_temp As New HyperLink
                '    hp_temp.NavigateUrl = "http://164.115.28.133/SPECIAL_PAYMENT_DRUG_BSN/MAIN/FRM_CHECK_TOKEN.aspx?Token=" & _CLS.TOKEN & "&RQ_ID=" & rq_number
            End If
        End If
    End Sub

End Class