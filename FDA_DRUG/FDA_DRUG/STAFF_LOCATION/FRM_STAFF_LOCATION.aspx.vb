Imports Telerik.Web.UI
Public Class FRM_STAFF_LOCATION
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_CUSTOMER_DALCN_LOCATION_ADDRESS_LCT(1)
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        Try
            If _CLS.PVCODE <> "10" Then
                Try
                    RadGrid1.DataSource = dt.Select("pvncd=" & _CLS.PVCODE)
                Catch ex As Exception

                End Try
            Else
                RadGrid1.DataSource = dt
            End If
        Catch ex As Exception

        End Try




        'If IDGroup = 21020 Then
        '    RadGrid1.DataSource = dt
        'ElseIf IDGroup = 63346 Then
        '    RadGrid1.DataSource = dt.Select("STATUS_ID = 2")
        'ElseIf IDGroup = 63347 Then
        '    RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6")
        'ElseIf IDGroup = 63348 Then
        '    RadGrid1.DataSource = dt.Select("STATUS_ID > 6")
        'End If


    End Sub


    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim TR_ID As String = item("TR_ID").Text


            Dim H As HyperLink = e.Item.FindControl("HyperLink1")


            ' H.Attributes.Add("onclick", "Popups2('" & "FRM_STAFF_LOCATION_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "');")
            '
            H.Attributes.Add("onclick", "Popups2('" & "FRM_STAFF_LOCATION_DALCN_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "');")
        End If
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
    '    dao.GetDataby_IDA()
    'End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        Dim bao As New BAO.ClsDBSqlcommand
        'RadGrid1.DataSource = bao.SP_CUSTOMER_DALCN_LOCATION_ADDRESS_LCT(1) ' bao.SP_CUSTOMER_DALCN_LOCATION_ADDRESS_LCT(1)
        'RadGrid1.DataBind()
        RadGrid1.Rebind()
    End Sub
End Class