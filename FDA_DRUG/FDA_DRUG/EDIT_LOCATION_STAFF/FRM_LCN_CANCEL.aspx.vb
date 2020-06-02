Imports System.IO
Imports System.Xml.Serialization
Public Class FRM_LCN_CANCEL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    'Private _fk_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Sub runQuery()
        '_lct_ida = Request.QueryString("lct_ida")
        '_fk_ida = Request.QueryString("fk_ida")
        _process = Request.QueryString("process")
        _lcn_ida = Request.QueryString("ida")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            runQuery()

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
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
        Dim dao As New DAO_DRUG.TB_lcnrequest
        If e.CommandName = "send" Then
            dao.GetDataby_IDA(str_ID)
            dao.fields.STATUS_ID = 2
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยืนยันเรียบร้อยแล้ว'); ');", True)
            load_GV_lcnno()
        End If
    End Sub

    Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim ida As String = GV_data.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            ' btn_Select.Attributes.Add("onclick", "Popups2('../EDIT_LOCATION/POPUP_EDIT_LOCATION_CONFIRM.aspx?IDA=" & ida & "'); return false;")
            btn_Select.Attributes.Add("onclick", "Popups2('../EDIT_LOCATION_STAFF/FRM_LCN_CANCEL_INSERT_AND_UPDATE.aspx?IDA=" & ida & "'); return false;")
            'Dim btn_send As Button = DirectCast(e.Row.FindControl("btn_send"), Button)

            Dim stat As Integer = 0
            Dim dao As New DAO_DRUG.TB_lcnrequest
            Try
                dao.GetDataby_IDA(ida)
                stat = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            'If stat > 1 Then
            '    btn_send.Style.Add("display", "none")
            'End If

        End If
    End Sub
    Sub load_GV_lcnno()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_DB.SP_LCN_EDIT_REQUEST_CANCEL_BY_FK_IDA_AND_TYPEV2(_lcn_ida, 2)
        GV_data.DataSource = dt
        GV_data.DataBind()

    End Sub

    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_LCN_CANCEL_INSERT_AND_UPDATE.aspx?process=" & _process & "&lcn_ida=" & _lcn_ida & "&iden=" & Request.QueryString("iden") & "');", True)
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
    End Sub
End Class