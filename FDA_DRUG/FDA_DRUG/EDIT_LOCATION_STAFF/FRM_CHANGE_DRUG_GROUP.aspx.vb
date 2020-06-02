Public Class FRM_CHANGE_DRUG_GROUP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        UC_TABLE_DRUG_GROUP_CHANGE.bind_table_edit()
        'bind_table()
        'End If
    End Sub
    

    'Private Sub btn_SAVE_Click(sender As Object, e As EventArgs) Handles btn_SAVE.Click
    '    UC_TABLE_DRUG_GROUP_CHANGE.save_date()

    '    UC_TABLE_DRUG_GROUP_CHANGE.bind_table()
    'End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        UC_TABLE_DRUG_GROUP_CHANGE.save_data_edit()
        UC_TABLE_DRUG_GROUP_CHANGE.bind_table_edit()
    End Sub
End Class