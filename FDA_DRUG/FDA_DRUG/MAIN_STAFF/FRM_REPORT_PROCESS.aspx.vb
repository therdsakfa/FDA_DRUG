Public Class FRM_REPORT_PROCESS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_2_Click(sender As Object, e As EventArgs) Handles btn_2.Click
        Response.Redirect("../REPORT_LCN/FRM_REPORT_LCN_DRUG.aspx")
    End Sub
End Class