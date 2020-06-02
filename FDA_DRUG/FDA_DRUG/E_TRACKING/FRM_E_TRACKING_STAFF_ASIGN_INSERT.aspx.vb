Public Class FRM_E_TRACKING_STAFF_ASIGN_INSERT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBE_TRACKING_STAFF
        dao.fields.IDENTIFY = Txt_CITIZENID.Text
        dao.fields.PROCESS_ID = ddl_process.SelectedValue
        dao.fields.IS_USE = True
        dao.insert()

        alert("บันทึกข้อมูลเรียบร้อย")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class