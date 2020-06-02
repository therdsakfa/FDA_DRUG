Public Class FRM_ADD_NEW_BSN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
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
        If Not IsPostBack Then
            UC_BSN_ADD_NEW1.load_ddl_chwt()
            UC_BSN_ADD_NEW1.load_ddl_amp()
            UC_BSN_ADD_NEW1.load_ddl_thambol()
            UC_BSN_ADD_NEW1.call_lbl_set()
            UC_BSN_ADD_NEW1.bind_ddl_prefix()

        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_CPN.TB_LOCATION_BSN
        UC_BSN_ADD_NEW1.set_data(dao)
        dao.insert()
        Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
   
End Class