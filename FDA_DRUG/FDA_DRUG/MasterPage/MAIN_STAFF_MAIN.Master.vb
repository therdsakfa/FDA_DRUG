Public Class MAIN_STAFF_MAIN
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Private _pvncd As Integer = 0
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")

            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        '  get_pvncd()
        lb_login.Text = _CLS.thanm
        bind_lbl_position()
        If Not IsPostBack Then

        End If
    End Sub
    'Sub get_pvncd()
    '    _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
    'End Sub
    Sub bind_lbl_position()
        'If _pvncd <> 10 Then

        '    '   Dim dao As New DAO_CPN.clsDBsyschngwt
        '    'dao.GetData_by_chngwtcd(_pvncd)
        '    Try
        '        lbl_position.Text = "สสจ." ' & dao.fields.thachngwtnm
        '    Catch ex As Exception
        '        lbl_position.Text = "สสจ."
        '    End Try


        'Else
        lbl_position.Text = "สำนักงานคณะกรรมการอาหารและยา"
        ' End If
    End Sub
End Class