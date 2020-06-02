Public Class FRM_STAFF_REPLACEMENT_LICENSE_PANEL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If _CLS.PVCODE <> 10 Then
                btn_dh.Style.Add("display", "none")
            End If
        End If
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

    Private Sub btn_LCN_Click(sender As Object, e As EventArgs) Handles btn_LCN.Click
        Response.Redirect("FRM_STAFF_REPLACEMENT_LICENSE_MAIN.aspx?MENU_GROUP=1")
    End Sub

    Private Sub btn_dr_Click(sender As Object, e As EventArgs) Handles btn_dr.Click
        Response.Redirect("FRM_STAFF_REPLACEMENT_LICENSE_MAIN.aspx?MENU_GROUP=3")
    End Sub
    Private Sub btn_dh_Click(sender As Object, e As EventArgs) Handles btn_dh.Click
        Response.Redirect("FRM_STAFF_REPLACEMENT_LICENSE_MAIN.aspx?MENU_GROUP=2")
    End Sub
End Class