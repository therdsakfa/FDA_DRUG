Public Class WebForm13
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UC_TABLE_DRUG_GROUP_CHANGE1.bind_table()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim ws_update As New WS_DRUG.WS_DRUG
        'ws_update.DRUG_UPDATE_LICEN(16251)
    End Sub
End Class