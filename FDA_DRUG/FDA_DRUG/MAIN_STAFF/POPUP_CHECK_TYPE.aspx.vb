Public Class WebForm15
    Inherits System.Web.UI.Page
    Private _ID As String
    Private _process_tpye As String
    Private _CLS As New CLS_SESSION


    Sub RunQuery()
        Try
            _ID = Request.QueryString("ID")
            _process_tpye = Request.QueryString("process_tpye")
            _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Runquery()
        check_type()
    End Sub
    Sub check_type()
        _CLS.IDA = _ID
        Session("CLS") = _CLS
        If _process_tpye = "1" Then

            ' Response.Redirect("/SORBOR5/FRM_SORBOR5_CONFIRM.aspx") 'test
            Response.Redirect("../LCN_STAFF/FRM_LCN_CONFIRM.aspx") 'server
        ElseIf _process_tpye = "2" Then

        ElseIf _process_tpye = "3" Then

        ElseIf _process_tpye = "4" Then

        ElseIf _process_tpye = "41" Then

        End If
    End Sub
End Class