Public Class Main_E_Tracking_Menu
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
        RunSession()

        Try
            If Request.QueryString("FK_IDA") <> "" Then
                'HyperLink1.NavigateUrl = "../LOCATION/FRM_LCN_LCT.aspx?FK_IDA=" & Request.QueryString("FK_IDA")
            Else
                'HyperLink1.NavigateUrl = "../LOCATION/FRM_LCN_LCT.aspx"
            End If
        Catch ex As Exception

        End Try

        If Not IsPostBack Then

            Try
                hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM 'รับค่า ชื่อผู้ใช้
                'hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER 'รับค่า ชื่อผู้ได้รับอนุญาต
            Catch ex As Exception

            End Try

        End If
        UC_NODE_AUTO.group = 7
        UC_NODE_AUTO.TOKEN = _CLS.TOKEN
    End Sub

End Class