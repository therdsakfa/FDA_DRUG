Imports System.IO
Imports System.Xml.Serialization
Public Class FRM_STAFF_NORYORMOR1_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

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
        load_lcnno()
        If Not IsPostBack Then
            load_GV_data()
        End If
    End Sub
    Sub load_lcnno()
        'lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Sub load_GV_data()
        Dim bao As New BAO.ClsDBSqlcommand
        'นยม. 1
        bao.SP_DRIMPFOR_STAFF()
        GV_data.DataSource = bao.dt
        GV_data.DataBind()
    End Sub

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrimpfor
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD


        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Dim process As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            Try
                dao_up.GetDataby_IDA(tr_id)
                process = dao_up.fields.PROCESS_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_NORYORMOR1_CONFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & process & "');", True)

        End If
    End Sub
End Class