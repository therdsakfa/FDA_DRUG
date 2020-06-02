Public Class UC_LCN_OPENTIME
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        dao.fields.opentime = txt_OPEN_TIME.Text
      
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        txt_OPEN_TIME.Text = dao.fields.opentime
        lb_OPEN_TIME.Text = dao.fields.opentime
    End Sub
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        'tha
        dao.fields.OPEN_TIME_NEW = txt_OPEN_TIME.Text

        '---------------------------------------------------------------------------
        'tha

        dao.fields.OPEN_TIME_OLD = dao2.fields.opentime
    End Sub
End Class