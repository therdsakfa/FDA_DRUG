Public Class MAIN_LCT
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
        If Not IsPostBack Then

            Try
                hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM 'รับค่า ชื่อผู้ใช้
                hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER 'รับค่า ชื่อผู้ได้รับอนุญาต
            Catch ex As Exception

            End Try

        End If
    End Sub

End Class