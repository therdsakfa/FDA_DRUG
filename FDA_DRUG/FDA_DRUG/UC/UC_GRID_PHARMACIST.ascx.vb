Public Class UC_GRID_PHARMACIST
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub load_gv(ByVal FK_ID As Integer)
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DALCN_PHR_BY_FK_IDA(FK_ID)

        gv.DataSource = bao.dt
        gv.DataBind()
    End Sub

  
    Private Sub gv_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = gv.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        'If e.CommandName = "sel" Then
        '    dao.GetDataby_IDA(str_ID)
        '    Dim tr_id As Integer = 0
        '    Try
        '        tr_id = dao.fields.TRANSECTION_ID_UPLOAD
        '    Catch ex As Exception

        '    End Try

        '    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_FILE_ATTACH_PREVIEW.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

        'End If
    End Sub

    Private Sub gv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_Select As HyperLink = DirectCast(e.Row.FindControl("btn_Select"), HyperLink)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = gv.DataKeys.Item(index).Value.ToString()
            Dim dao2 As New DAO_DRUG.ClsDBDALCN_PHR
            dao2.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao2.fields.TRANSECTION_ID_UPLOAD
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            Dim bao As New BAO.AppSettings
            dao.GetDataby_IDA(str_ID)
            btn_Select.NavigateUrl = "~\LCN_STAFF\FRM_LCN_FILE_ATTACH_PREVIEW.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id

        End If
    End Sub
End Class