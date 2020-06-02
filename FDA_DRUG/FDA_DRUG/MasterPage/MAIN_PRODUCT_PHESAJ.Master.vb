Public Class MAIN_PRODUCT_PHESAJ
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("staff") <> "" Then
            HyperLink1.Style.Add("display", "block")
        End If
        Try
            If Request.QueryString("FK_IDA") <> "" Then
                'HyperLink1.NavigateUrl = "../MAIN/FRM_LCN_NEWS.aspx?FK_IDA=" & Request.QueryString("FK_IDA")
            Else
                'HyperLink1.NavigateUrl = "../MAIN/FRM_LCN_NEWS.aspx"
            End If
        Catch ex As Exception

        End Try
        RunSession()
        If Not IsPostBack Then

            hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM

            hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER
            'Dim dao As New DAO_PERMISSION.TB_taxnogrouppermission
            'dao.GetDataby_IDgroup_and_Iden(_CLS.GROUPS, _CLS.CITIZEN_ID)
            'hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & dao.fields.grouppermission
        End If
        UC_NODE_AUTO2.group = 2
    End Sub
End Class