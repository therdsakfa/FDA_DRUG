Imports Telerik.Web.UI

Public Class FRM_STAFF_PD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then

        End If
    End Sub
    Sub get_pvncd()
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            Dim PROCESS_ID As Integer = 0
            Try
                PROCESS_ID = item("PROCESS_ID").Text
            Catch ex As Exception

            End Try

            Dim STATUS As Integer = 0
            Try
                STATUS = item("STATUS").Text
            Catch ex As Exception

            End Try
            Dim tr_id As String= 0
            Try
                tr_id = item("TR_ID").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then


                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_STAFF_PD_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(IDA)
            btn_edit.Style.Add("display", "none")
            Try
                If dao.fields.STATUS_ID = 6 Then
                    btn_edit.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        dt = bao.SP_STAFF_DRUG_PROJECT_SUMMARY()
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        If IDGroup = 21020 Then
            RadGrid1.DataSource = dt
        ElseIf IDGroup = 63346 Then
            RadGrid1.DataSource = dt.Select("STATUS ='" & 2 & "'")
        ElseIf IDGroup = 63347 Then
            RadGrid1.DataSource = dt.Select("STATUS >='" & 2 & "' and STATUS <= '" & 6 & "'")
        ElseIf IDGroup = 63348 Then
            RadGrid1.DataSource = dt.Select("STATUS > '" & 6 & "'")
        End If

    End Sub

End Class