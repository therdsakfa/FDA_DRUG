Public Class FRM_STAFF_EDIT_PRODUCTION_MAIN
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

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim process As Integer = 0
        'Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        If e.CommandName = "sel" Then
            'dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                ' tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Dim dao_tran As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tran.GetDataby_IDA(tr_id)
            Try
                Process = dao_tran.fields.PROCESS_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_STAFF_EDIT_LOCATION_CONFIRM_V2.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & process & "');", True)


        End If
    End Sub
    Sub load_GV_lcnno()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_DB.SP_LCN_EDIT_REQUEST_STAFF_BY_LCN_TYPE(2)
        GV_data.DataSource = dt
        GV_data.DataBind()
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
    End Sub
End Class