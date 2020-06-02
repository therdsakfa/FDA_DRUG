Public Class FRM_LCN_FILE_ATTACH_PREVIEW_STAFF
    Inherits System.Web.UI.Page
    Private _TR_ID As String

    Public Sub runQuery()
        ' _TR_ID = Request.QueryString("TR_ID") 'test
        _TR_ID = "2000" 'test
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            gv_data()
        End If
    End Sub
    Public Sub gv_data()
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_FILE_ATTACH(_TR_ID)
        gv.DataSource = bao.dt
        gv.DataBind()
    End Sub

    Private Sub gv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_Select As HyperLink = DirectCast(e.Row.FindControl("btn_Select"), HyperLink)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = gv.DataKeys.Item(index).Value.ToString()
            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            Dim bao As New BAO.AppSettings
            dao.GetDataby_IDA(str_ID)
            btn_Select.NavigateUrl = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao.fields.NAME_FAKE

        End If
    End Sub
End Class