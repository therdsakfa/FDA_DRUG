Public Class WebForm24
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        UC_TABLE_DRUG_GROUP_CHANGE.bind_table()
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'UC_TABLE_DRUG_GROUP_CHANGE.bind_table()
        UC_TABLE_DRUG_GROUP_CHANGE.save_data()
        'UC_TABLE_DRUG_GROUP_CHANGE.bind_table()
        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
    End Sub
End Class