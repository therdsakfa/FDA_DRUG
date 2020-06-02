Public Class UC_LOCATION_ADDRESS_TEL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        'tha
        dao.fields.LOCATION_ADDRESS_tel = txt_tel.Text.Trim

        '---------------------------------------------------------------------------
        'tha

        dao.fields.LOCATION_ADDRESS_tel_OLD = dao2.fields.LOCATION_ADDRESS_tel
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'tha
        dao.fields.LOCATION_ADDRESS_tel = txt_tel.Text.Trim
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        lb_tel.Text = dao.fields.LOCATION_ADDRESS_tel
        txt_tel.Text = dao.fields.LOCATION_ADDRESS_tel
    End Sub
    Public Sub set_data_addr(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_ADDRESS)
        'tha
        dao.fields.tel = txt_tel.Text.Trim
    End Sub
End Class