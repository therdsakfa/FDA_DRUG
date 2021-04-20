Public Class POPUP_ASSIGN_STAFF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        rcb_name.Items.Clear()
        If Len(txt_consider_iden.Text) = 0 Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกเลขบัตรประชาชน');</script> ")
        Else
            Dim bao As New BAO_SHOW
            Dim dt As New DataTable
            dt = bao.SP_SYSLCNSNM_BY_NAME_SEARCH(txt_consider_iden.Text)

            rcb_name.DataSource = dt
            rcb_name.DataBind()
        End If
    End Sub
End Class