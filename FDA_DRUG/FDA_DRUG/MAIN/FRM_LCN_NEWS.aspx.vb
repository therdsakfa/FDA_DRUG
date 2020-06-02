Public Class WebForm19
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _lct_ida = Request.QueryString("lct_ida")
                _lcn_ida = Request.QueryString("lcn_ida")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        'UC_Information.Shows(_CLS.LCNNO, _lcn_ida)
        UC_INFMT1.Shows(_lct_ida)
    End Sub
End Class