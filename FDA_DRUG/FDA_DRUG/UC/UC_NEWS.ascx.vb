Public Class UC_NEWS
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Set_text(ByVal _type As Integer)
        Dim dao As New DAO_DRUG.TB_MAS_NEWS
        dao.GetDataby_IDA(_type)
        lbl_news.Text = dao.fields.text_comment
    End Sub

End Class