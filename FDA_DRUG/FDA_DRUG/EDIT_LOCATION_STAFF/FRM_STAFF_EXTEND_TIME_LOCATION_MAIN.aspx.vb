Imports Telerik.Web.UI

Public Class FRM_STAFF_EXTEND_TIME_LOCATION_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
    End Sub
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
        runQuery()
        If Not IsPostBack Then
            load_GV_lcnno()

        End If
    End Sub

    'Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.TB_LCN_EXTEND
    '    Dim process As Integer = 0
    '    'Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
    '    If e.CommandName = "sel" Then
    '        'dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            ' tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try
    '        Dim dao_tran As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '        dao_tran.GetDataby_IDA(tr_id)
    '        Try
    '            Process = dao_tran.fields.PROCESS_ID
    '        Catch ex As Exception

    '        End Try
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_EXTEND_TIME_LOCATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & process & "');", True)
    '    ElseIf e.CommandName = "view" Then

    '        dao.GetDataby_IDA(str_ID)
    '        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
    '        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)

    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao_lcn.fields.TR_ID
    '        Catch ex As Exception

    '        End Try
    '        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '        dao_up.GetDataby_IDA(tr_id)
    '        Try
    '            process = dao_up.fields.PROCESS_ID
    '        Catch ex As Exception

    '        End Try
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../LCN/FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & dao.fields.FK_IDA & "&TR_ID=" & tr_id & "&process=" & process & "');", True)

    '    End If
    'End Sub
    Sub load_GV_lcnno()
        'Dim bao_DB As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        'dt = bao_DB.SP_LCN_EXTEND_REQUEST_STAFF()
        'GV_data.DataSource = dt
        'GV_data.DataBind()
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
        RadGrid1.Rebind()
    End Sub

    'Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
    '        Dim btn_view As Button = DirectCast(e.Row.FindControl("btn_view"), Button)
    '        Dim ida As String = GV_data.DataKeys.Item(e.Row.RowIndex).Value.ToString()
    '        btn_Select.Attributes.Add("onclick", "Popups2('../EDIT_LOCATION/FRM_EXTEND_TIME_INSERT_AND_UPDATE.aspx?IDA=" & ida & "'); return false;")
    '        btn_view.Style.Add("display", "none")

    '        Dim stat As Integer = 0
    '        Dim dao As New DAO_DRUG.TB_LCN_EXTEND
    '        Try
    '            dao.GetDataby_IDA(ida)
    '            stat = dao.fields.STATUS_ID
    '        Catch ex As Exception

    '        End Try
    '        If stat = 8 Then
    '            btn_view.Style.Add("display", "block")
    '        End If
    '    End If
    'End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND
            Dim process As Integer = 0
            'Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION

            If e.CommandName = "sel" Then
                Dim tr_id As String= 0
                Try
                    ' tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                Dim dao_tran As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tran.GetDataby_IDA(tr_id)
                Try
                    process = dao_tran.fields.PROCESS_ID
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_EXTEND_TIME_LOCATION_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & process & "');", True)

            ElseIf e.CommandName = "view" Then
                dao.GetDataby_IDA(IDA)
                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)

                Dim tr_id As String= 0
                Try
                    tr_id = dao_lcn.fields.TR_ID
                Catch ex As Exception

                End Try
                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.GetDataby_IDA(tr_id)
                Try
                    process = dao_up.fields.PROCESS_ID
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../LCN/FRM_LCN_CONFIRM_DRUG.aspx?IDA=" & dao.fields.FK_IDA & "&TR_ID=" & tr_id & "&process=" & process & "');", True)

            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_Select As LinkButton = DirectCast(item("btn_Select").Controls(0), LinkButton)
            Dim btn_view As LinkButton = DirectCast(item("btn_view").Controls(0), LinkButton)

            'btn_Select.Attributes.Add("onclick", "Popups2('../EDIT_LOCATION/FRM_EXTEND_TIME_INSERT_AND_UPDATE.aspx?IDA=" & ida & "'); return false;")
            btn_view.Style.Add("display", "none")

            Dim stat As Integer = 0
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND
            Try
                dao.GetDataby_IDA(ida)
                stat = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            If stat = 8 Then
                btn_view.Style.Add("display", "block")
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_DB.SP_LCN_EXTEND_REQUEST_STAFF()

        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        If IDGroup = 21020 Then
            RadGrid1.DataSource = dt
        ElseIf IDGroup = 63346 Then
            RadGrid1.DataSource = dt.Select("STATUS_ID = 2")
        ElseIf IDGroup = 63347 Then
            RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6")
        ElseIf IDGroup = 63348 Then
            RadGrid1.DataSource = dt.Select("STATUS_ID > 6")
        End If

    End Sub
End Class