Imports Telerik.Web.UI

Public Class FRM_EXTEND_TIME_LOCATION_MAIN_TOTAL
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
            'load_GV_lcnno()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    'Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click

    '    OpenPopupName("POPUP_LCN_DOWNLOAD.aspx")
    'End Sub

    'Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
    '    OpenPopupName("POPUP_LCN_UPLOAD.aspx")
    'End Sub
    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
        'load_GV_lcnno()
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
                Dim dao As New DAO_DRUG.TB_lcnrequest
                dao.GetDataby_IDA(IDA)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_EDIT_LOCATION_CONFIRM2.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    'Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As String = item("IDA").Text
    '        Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
    '        Dim dao As New DAO_DRUG.TB_lcnrequest
    '        dao.GetDataby_IDA(IDA)
    '        btn_edit.Style.Add("display", "none")
    '        Try
    '            If dao.fields.STATUS_ID = 6 Then
    '                btn_edit.Style.Add("display", "block")
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        Dim url As String = "../EDIT_LOCATION_STAFF/POPUP_STAFF_EXTEND_TIME_LOCATION_CONSIDER.aspx?IDA=" & IDA
    '        btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
    '    End If
    'End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        ''SP_STAFF_DALCN_BY_PVNCD
        'If _pvncd = 10 Then
        'dt = bao.SP_STAFF_DALCN()
        'Else
        'dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
        'End If
        dt = bao.SP_STAFF_LCN_EXTEND_LITE2()
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
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
End Class