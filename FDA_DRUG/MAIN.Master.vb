Public Class MAIN
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hyperthanm.Text = Session("strthanm")
        'hyperthanm.NavigateUrl = "FRM_SEARCH_LCNSID.aspx"
    End Sub

End Class