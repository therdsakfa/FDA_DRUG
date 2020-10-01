Public Class FRM_LCN_STAFF_CONFIRM

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
    Sub load_GV_lcnno()
        Dim bao As New BAO.ClsDBSqlcommand
        GV_lcnno.DataSource = bao.SP_STAFF_DALCN()
        GV_lcnno.DataBind()
    End Sub


#Region "GRIDVIEW"
    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            ' Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Integer.Parse(str_ID))


            'เลขใบอนุญาต
            '   Dim bao_convert_num As New BAO.convert_num
            '         lbl_lcnno.Text = bao_convert_num.con_lcnno(str_ID)

            'เลขประเภทใบอนุญาต
            '   lbl_lcntype.Text = bao_convert_num.con_lcntype(str_ID)

        End If




    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_IMPORT_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

        End If

    End Sub


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
    End Sub
#End Region
End Class