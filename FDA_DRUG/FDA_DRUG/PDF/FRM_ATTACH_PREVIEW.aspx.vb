Public Class WebForm16
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Check_pdf()
    End Sub
    Private Sub Check_pdf()
        Dim bao As New BAO.AppSettings
        Dim imageUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim url() As String = imageUrl.Split("/")
        Dim filename As String = url(url.Length - 1)
        Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & filename

        ' If Checkfile(saveLocation) = False Then
        '     save_pdf(filename, saveLocation)
        ' Else
        load_pdf(saveLocation)
        ' End If

    End Sub
    Private Sub load_pdf(ByVal FilePath As String)
        Response.ContentType = "Application/pdf"
        Response.WriteFile(FilePath)
        Response.End()
    End Sub
End Class