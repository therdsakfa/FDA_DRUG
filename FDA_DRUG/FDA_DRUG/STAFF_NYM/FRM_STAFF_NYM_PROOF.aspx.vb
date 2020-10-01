Imports Telerik.Web.UI

Public Class FRM_STAFF_NYM_PROOF
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
    'Sub load_GV_lcnno()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    'SP_STAFF_DALCN_BY_PVNCD
    '    If _pvncd = 10 Then
    '        dt = bao.SP_STAFF_DALCN()
    '    Else
    '        dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
    '    End If
    '    Dim IDGroup As Integer = 0
    '    Try
    '        IDGroup = _CLS.GROUPS
    '    Catch ex As Exception

    '    End Try
    '    If IDGroup = 21020 Then
    '        GV_lcnno.DataSource = dt
    '    ElseIf IDGroup = 63346 Then
    '        GV_lcnno.DataSource = dt.Select("STATUS_ID <= 2")
    '    ElseIf IDGroup = 63347 Then
    '        GV_lcnno.DataSource = dt.Select("STATUS_ID > 2 and STATUS_ID <= 6")
    '    ElseIf IDGroup = 63348 Then
    '        GV_lcnno.DataSource = dt.Select("STATUS_ID > 6")
    '    End If
    '    GV_lcnno.DataBind()
    'End Sub


#Region "GRIDVIEW"
    'Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
    '        Dim index As Integer = e.Row.RowIndex
    '        'Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
    '        Dim str_ID As String = GV_lcnno.DataKeys.Item(index)("IDA").ToString()
    '        Dim dao As New DAO_DRUG.ClsDBdalcn
    '        dao.GetDataby_IDA(Integer.Parse(str_ID))
    '        btn_edit.Style.Add("display", "none")
    '        Try
    '            If dao.fields.STATUS_ID = 6 Then
    '                btn_edit.Style.Add("display", "block")
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & str_ID
    '        btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")

    '    End If
    'End Sub

    'Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBdalcn

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try

    '        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
    '        dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID & "');", True)

    '    End If

    'End Sub


    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
    '    GV_lcnno.PageIndex = e.NewPageIndex
    '    load_GV_lcnno()
    'End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
        'load_GV_lcnno()
    End Sub
#End Region

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'drsamp IDA
            Dim tr_id As String= 0
            Try
                TR_ID = item("TR_ID").Text
            Catch ex As Exception

            End Try

            Dim PROCESS As Integer = 0
            Try
                PROCESS = item("PROCESS_ID").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
                dao.GetDataby_TR_ID_And_Process_And_Type(TR_ID, PROCESS, "P")
                If IsNothing(dao.fields.NAME_FAKE) Then
                Else
                    Response.Redirect("~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao.fields.NAME_FAKE & "")
                End If
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim TR_ID As String = item("TR_ID").Text
            Dim PROCESS As String = item("PROCESS_ID").Text

            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
            dao.GetDataby_TR_ID_And_Process_And_Type(TR_ID, PROCESS, "P") 'ดึงข้อมูลโดยการ where IDA ที่ใช้เป็น DataKeys ของแต่ละ row 

            item("EXCEED_TIME_LIMIT").ForeColor = System.Drawing.Color.Red

            If IsNothing(dao.fields.NAME_FAKE) Then
            Else
                Dim btn_Select As LinkButton = DirectCast(item("btn_Select").Controls(0), LinkButton)
                Dim url As String = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao.fields.NAME_FAKE
                btn_Select.Attributes.Add("OnClick", url)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_STAFF_NYM_PROOF()
        RadGrid1.DataSource = dt
    End Sub
End Class