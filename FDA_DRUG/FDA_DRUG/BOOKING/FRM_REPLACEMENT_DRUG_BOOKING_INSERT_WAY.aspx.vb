Public Class FRM_REPLACEMENT_DRUG_BOOKING_INSERT_WAY
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunSession()

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
    End Sub

    Protected Sub Btn_insert_Click(sender As Object, e As EventArgs) Handles Btn_insert.Click
        Try
            window_open_self("FRM_REPLACEMENT_BOOKING_INSERT.aspx")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Btn_insert_all_Click(sender As Object, e As EventArgs) Handles Btn_insert_all.Click
        Try
            window_open_self("FRM_REPLACEMENT_DRUG_BOOKING_INSERT_ALL.aspx")
        Catch ex As Exception

        End Try

    End Sub

#Region "javascript"
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub alert_close_popup(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub close_popup()
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert_window_open_self(ByVal text As String, ByVal URL As String)
        Response.Write("<script type='text/javascript'>alert('" & text & "');window.open('" & URL & "','_self');</script> ")
    End Sub
    Private Sub alert_window_open_self_reload(ByVal text As String, ByVal URL As String)
        Response.Write("<script type='text/javascript'>parent.reload();alert('" & text & "');window.open('" & URL & "','_self');</script> ")
    End Sub
    Private Sub window_open_self(ByVal URL As String)
        Response.Write("<script type='text/javascript'>window.open('" & URL & "','_self');</script> ")
    End Sub
    Private Sub window_open_self_reload(ByVal URL As String)
        Response.Write("<script type='text/javascript'>parent.reload();window.open('" & URL & "','_self');</script> ")
    End Sub

#End Region
End Class