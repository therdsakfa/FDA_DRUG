Public Class UC_SEARCH_thanameplace
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = ""

        Dim thanameplace As String = ""
        thanameplace = txt_thanameplace.Text

        If thanameplace <> "" Then
            strMsg &= "([thanameplace] LIKE '%" & thanameplace & "%')"
        End If


        Return strMsg
    End Function
End Class