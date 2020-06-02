Public Class FRM_ATTACH_PREVIEW_ALL
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
        load_pdf(saveLocation, filename)
        ' End If

    End Sub
    Private Sub load_pdf(ByVal FilePath As String, ByVal filename As String)
        'Response.ContentType = "Application/pdf"
        Dim last_nm_file As String = ""
        Dim split_nm As String() = filename.Split(".")
        last_nm_file = split_nm(split_nm.Length - 1)
        Response.ContentType = "Content-Disposition"
        If last_nm_file = "txt" Then
            Response.ContentType = "text/plain"
        ElseIf last_nm_file = "jpg" Then
            Response.ContentType = "image/JPEG"
        ElseIf last_nm_file = "png" Then
            Response.ContentType = "image/png"
        ElseIf last_nm_file = "pdf" Then
            Response.ContentType = "application/pdf"
        ElseIf last_nm_file = "doc" Or last_nm_file = "docx" Then
            Response.ContentType = "application/msword"
        End If

        Response.WriteFile(FilePath)
        Response.End()
    End Sub
End Class