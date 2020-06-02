Imports Telerik.Web.UI

Public Class FRM_SEARCH_PERSON
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _chk_identify As String
    Private _type As Integer
    Private Sub RunQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _CLS = Session("CLS")
            _type = Request.QueryString("type")
            _chk_identify = Request.QueryString("chk_identify")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "btn_back" Then
                Dim tha As String = item("tha_fullnm").Text
                Dim identify As String = item("identify").Text
                'If _chk_identify = 1 Then
                _CLS.AUTHORIZ_IDENTIFY = identify
                _CLS.AUTHORIZE_NAME = tha
                'ElseIf _chk_identify = 2 Then
                '    _CLS.BSN_IDENTIFY = identify
                '    _CLS.BSN_NAME = tha
                'End If
                Session("CLS") = _CLS
                Response.Redirect("FRM_PROFESSIONAL_IMPORT.aspx?type=2")
            End If
        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid1.DataSource = bao.SP_SEARCH_PERSON(99999999999)
    End Sub

    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        'Try
        '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        '        Dim item As GridDataItem
        '        item = e.Item
        '        Dim ID As Integer = item("ID").Text
        '        Dim tha As String = item("tha_fullnm").Text
        '        Dim identify As String = item("identify").Text
        '        Dim urls As String = "FRM_SYSTEMS_INSERT_PAYMENT.aspx?IDA=" & ID & "&tha=" & tha & "&identify=" & identify
        '        Dim H As HyperLink = e.Item.FindControl("HyperLink1")
        '        H.NavigateUrl = "../STAFF_SYSTEMS_NCT/FRM_SYSTEMS_INSERT_PAYMENT.aspx?IDA=" & ID & "&tha=" & tha & "&identify=" & identify & "&chk_identify=" & Request.QueryString("chk_identify")
        '        'End If
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid1.DataSource = bao.SP_SEARCH_PERSON(txt_chk_person.Text)
        RadGrid1.DataBind()
    End Sub

    Protected Sub btn_chk_bsn_Click(sender As Object, e As EventArgs) Handles btn_chk_bsn.Click
        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid1.DataSource = bao.SP_SEARCH_PERSON(txt_chk_person.Text)
        RadGrid1.DataBind()
    End Sub
End Class