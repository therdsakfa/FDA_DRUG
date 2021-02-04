Public Class FRM_DS_EDIT_REQUEST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)
        End If

    End Sub

    Protected Sub Button_DL_Click(sender As Object, e As EventArgs) Handles Button_DL.Click

    End Sub
End Class