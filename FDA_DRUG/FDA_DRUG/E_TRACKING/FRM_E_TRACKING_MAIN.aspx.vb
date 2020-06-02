Public Class FRM_E_TRACKING_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As Integer
    Private _Per As String
    Public Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _Per = Request.QueryString("Per")
    End Sub
    Sub RunSession()
        Try
            _CLS = Session("CLS")
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

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_DB.SP_E_TRACKING(_Per)
        GV_data.DataSource = dt
        GV_data.DataBind()

    End Sub


#Region "GRIDVIEW"
    Protected Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_data.DataKeys.Item(index).Value.ToString()
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 3)
            Catch ex As Exception

            End Try
            Try
                lbl_status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception
                lbl_status.Text = ""
            End Try


          
        End If




    End Sub

    Protected Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrrgt

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_E_TRACKING_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)
        End If
    End Sub


    Protected Sub GV_data_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_data.PageIndexChanging
        GV_data.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub
#End Region
End Class