Public Class FRM_LCN_DRUG_CHOOSE_TYPE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind_rdl()
        End If
    End Sub
    Sub Bind_rdl()
        Dim dao As New DAO_DRUG.TB_MAS_ORG_NAME_NYM
        dao.GetDataAll()

        rdl_org.DataSource = dao.datas
        rdl_org.DataBind()
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click

    End Sub
End Class