Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_EDIT_LCN_STAFF_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _process = Request.QueryString("process")
        Catch ex As Exception

        End Try
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

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
                dao.GetDataby_IDA(IDA)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try


                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EDIT_LCN_STAFF_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao.fields.PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        'If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        '    Dim item As GridDataItem
        '    item = e.Item
        '    Dim IDA As String = item("IDA").Text
        '    Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
        '    Dim dao As New DAO_DRUG.ClsDBdalcn
        '    dao.GetDataby_IDA(IDA)
        '    btn_edit.Style.Add("display", "none")
        '    Try
        '        If dao.fields.STATUS_ID = 6 Then
        '            btn_edit.Style.Add("display", "block")
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
        '    btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
        'End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'SP_STAFF_DALCN_BY_PVNCD
        'If _pvncd = 10 Then
        dt = bao.SP_DALCN_EDIT_REQUEST_STAFF()
        'Else
        '    dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
        'End If
        'Dim IDGroup As Integer = 0
        'Try
        '    IDGroup = _CLS.GROUPS
        'Catch ex As Exception

        'End Try
        ''If IDGroup = 21020 Then
        RadGrid1.DataSource = dt

    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class