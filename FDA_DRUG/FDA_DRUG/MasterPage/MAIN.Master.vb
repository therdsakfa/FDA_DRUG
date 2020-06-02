Public Class MAIN
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            Dim i As Integer = 0
            Dim bao_a As New BAO.ClsDBSqlcommand
            i = bao_a.Count_Permission_Menu(_CLS.SYSTEM_ID, _CLS.GROUPS, "8734002", _CLS.CITIZEN_ID_AUTHORIZE)
            If i > 0 Then
                _CLS.ID_MENU = 8734002
                'Session("CLS") = _CLS
            End If


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
            If _CLS.SYSTEM_ID = "8738" Or _CLS.SYSTEM_ID = "8734" Then
                Label1.Text = "ระบบผลิตภัณฑ์สมุนไพร"
            End If
            Try
                hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM

            Catch ex As Exception

            End Try
            Try
                hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER
            Catch ex As Exception

            End Try

        End If
        'Dim ws As New WS_AUTHENTICATION.Authentication
        'ws.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU)
    End Sub
End Class