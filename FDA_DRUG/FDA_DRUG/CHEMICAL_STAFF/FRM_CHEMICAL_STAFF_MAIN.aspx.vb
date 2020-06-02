Imports Telerik.Web.UI

Public Class FRM_CHEMICAL_STAFF_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_GV_lcnno()
        End If
    End Sub

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()
        'Dim bao As New BAO.ClsDBSqlcommand
        'GV_data.DataSource = bao.SP_STAFF_CHEMICAL_REQUEST()
        'GV_data.DataBind()
    End Sub


#Region "GRIDVIEW"
    'Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim btn_sel As Button = DirectCast(e.Row.FindControl("btn_sel"), Button)
    '        Dim index As Integer = e.Row.RowIndex
    '        Dim str_ID As String = GV_data.DataKeys.Item(index).Value.ToString()
    '        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
    '        dao.GetDataby_IDA(Integer.Parse(str_ID))
    '        Dim url As String = ""
    '        If dao.fields.MAIN_TYPE = "1" Then
    '            url = "FRM_CHEMICAL_STAFF_COMFIRM_TEXT.aspx?IDA=" & str_ID
    '        ElseIf dao.fields.MAIN_TYPE = "2" Then
    '            url = "FRM_CHEMICAL_STAFF_COMFIRM_TEXT_HERB.aspx?IDA=" & str_ID & "&g=" & dao.fields.G_TYPE
    '        ElseIf dao.fields.MAIN_TYPE = "3" Then
    '            url = "FRM_CHEMICAL_STAFF_COMFIRM_TEXT_BIO.aspx?IDA=" & str_ID & "&b=" & dao.fields.BIO_TYPE
    '        End If

    '        Try
    '            url &= "&process=" & dao.fields.PROCESS_ID
    '        Catch ex As Exception

    '        End Try

    '        btn_sel.Attributes.Add("onclick", "Popups2('" & url & "'); return false;")
    '    End If

    'End Sub

    'Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBdalcn

    '    'If e.CommandName = "sel" Then
    '    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_CHEMICAL_STAFF_COMFIRM_TEXT.aspx?IDA=" & str_ID & "');", True)

    '    'End If
    'End Sub


    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_data.PageIndexChanging
    '    GV_data.PageIndex = e.NewPageIndex
    '    load_GV_lcnno()
    'End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        'load_GV_lcnno()
        RadGrid1.Rebind()
    End Sub
#End Region

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then

            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_CHEMICAL_STAFF_COMFIRM_TEXT.aspx?IDA=" & IDA & "');", True)

            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_Select As LinkButton = DirectCast(item("btn_Select").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(IDA)
            Dim url As String = ""
            If dao.fields.MAIN_TYPE = "1" Then
                url = "FRM_CHEMICAL_STAFF_COMFIRM_TEXT.aspx?IDA=" & IDA
            ElseIf dao.fields.MAIN_TYPE = "2" Then
                url = "FRM_CHEMICAL_STAFF_COMFIRM_TEXT_HERB.aspx?IDA=" & IDA & "&g=" & dao.fields.G_TYPE
            ElseIf dao.fields.MAIN_TYPE = "3" Then
                url = "FRM_CHEMICAL_STAFF_COMFIRM_TEXT_BIO.aspx?IDA=" & IDA & "&b=" & dao.fields.BIO_TYPE
            End If

            Try
                url &= "&process=" & dao.fields.PROCESS_ID
            Catch ex As Exception

            End Try

            btn_Select.Attributes.Add("onclick", "Popups2('" & url & "'); return false;")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_STAFF_CHEMICAL_REQUEST

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