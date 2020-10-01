Imports Telerik.Web.UI

Public Class FRM_STAFF_EDIT_LOCATION_MAIN
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
            'load_GV_lcnno()
        End If
    End Sub

    'Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
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
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_EDIT_LOCATION_CONFIRM_V2.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & process & "');", True)


    '    End If
    'End Sub
    'Sub load_GV_lcnno()
    '    Dim bao_DB As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao_DB.SP_LCN_EDIT_REQUEST_STAFF_BY_LCN_TYPE(1)
    '    GV_data.DataSource = dt
    '    GV_data.DataBind()
    'End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        'load_GV_lcnno()
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

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(IDA)
                Dim process As Integer = 0
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                Dim dao_tran As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tran.GetDataby_IDA(tr_id)
                Try
                    process = dao_tran.fields.PROCESS_ID
                Catch ex As Exception

                End Try
                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_EDIT_LOCATION_CONFIRM_V2.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & process & "');", True)

            End If
            
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_DB.SP_LCN_EDIT_REQUEST_STAFF_BY_LCN_TYPE(1)

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