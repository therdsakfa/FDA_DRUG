Public Class FRM_STAFF_REPLACEMENT_LICENSE_PANEL_CHOOSE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        Response.Redirect("FRM_STAFF_REPLACEMENT_LICENSE_MAIN.aspx?MENU_GROUP=1&ttt=1")
    End Sub

    Private Sub btn_other_Click(sender As Object, e As EventArgs) Handles btn_other.Click
        Response.Redirect("FRM_STAFF_REPLACEMENT_LICENSE_MAIN_V2.aspx?MENU_GROUP=1&ttt=2")
    End Sub
End Class