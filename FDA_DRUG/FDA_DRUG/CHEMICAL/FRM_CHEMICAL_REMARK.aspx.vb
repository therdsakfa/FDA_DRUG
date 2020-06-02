Public Class FRM_CHEMICAL_REMARK
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            TextBox1.Text = dao.fields.REMARK
        End If
    End Sub

End Class