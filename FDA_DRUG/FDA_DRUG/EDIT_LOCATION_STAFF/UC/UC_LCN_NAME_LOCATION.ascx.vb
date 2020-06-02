Public Class UC_LCN_NAME_LOCATION
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        dao.fields.LOCATION_ADDRESS_thanameplace = txt_tha_nameplace.Text
        dao.fields.LOCATION_ADDRESS_engnameplace = txt_eng_nameplace.Text
    End Sub
    Public Sub set_data_addr(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_ADDRESS)
        dao.fields.thanameplace = txt_tha_nameplace.Text
        dao.fields.engnameplace = txt_eng_nameplace.Text
    End Sub
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        dao.fields.LOCATION_ADDRESS_thanameplace = txt_tha_nameplace.Text
        dao.fields.LOCATION_ADDRESS_engnameplace = txt_eng_nameplace.Text

        dao.fields.LOCATION_ADDRESS_thanameplace_OLD = dao2.fields.LOCATION_ADDRESS_thanameplace
        dao.fields.LOCATION_ADDRESS_engnameplace_OLD = dao2.fields.LOCATION_ADDRESS_engnameplace
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        lb_tha_nameplace.Text = dao.fields.LOCATION_ADDRESS_thanameplace
        lb_eng_nameplace.Text = dao.fields.LOCATION_ADDRESS_engnameplace

        txt_tha_nameplace.Text = dao.fields.LOCATION_ADDRESS_thanameplace
        txt_eng_nameplace.Text = dao.fields.LOCATION_ADDRESS_engnameplace
    End Sub
End Class