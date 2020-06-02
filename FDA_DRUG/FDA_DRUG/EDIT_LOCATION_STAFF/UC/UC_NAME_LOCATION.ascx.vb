Public Class UC_NAME_LOCATION
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_ADDRESS)
        dao.fields.thanameplace = txt_tha_nameplace.Text
        dao.fields.engnameplace = txt_eng_nameplace.Text
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_ADDRESS)
        lb_tha_nameplace.Text = dao.fields.thanameplace
        lb_eng_nameplace.Text = dao.fields.engnameplace
    End Sub
End Class