Public Class FRM_FRGN_NAME_INSERT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim max_id As Integer = 0
        Dim DAO_MAX As New DAO_DRUG.ClsDBsyspdcfrgn
        Try
            DAO_MAX.GetMAX()
            max_id = DAO_MAX.fields.frgncd
        Catch ex As Exception

        End Try
        Dim dao As New DAO_DRUG.ClsDBsyspdcfrgn
        dao.fields.engfrgnnm = txt_engfrgnnm.Text
        dao.fields.frgncd = max_id + 1
        dao.fields.lmdfdate = Date.Now
        dao.fields.thafrgnnm = txt_thafrgnnm.Text
        dao.insert()
        alert("บันทึกเรียบร้อย")

    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class