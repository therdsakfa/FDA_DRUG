Public Class FRM_PROFESSIONAL_IMPORT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _CLS = Session("CLS")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            If Request.QueryString("type") <> "" Then
                txt_citizen_id_search.Text = _CLS.AUTHORIZ_IDENTIFY
                txt_name.Text = _CLS.AUTHORIZE_NAME
            Else

            End If
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao1 As New DAO_DRUG.TB_MAS_EXPERT_NAME
        dao1.GetDataby_ctzno(txt_citizen_id_search.Text)
        If dao1.fields.IDA = 0 Then
            Dim dao As New DAO_DRUG.TB_MAS_EXPERT_NAME
            dao.fields.IDENTIFY = txt_citizen_id_search.Text
            'dao.fields.NAME = txt_name.Text
            'dao.fields.SURNAME = txt_SURNAME.Text
            dao.fields.FULLNAME = txt_name.Text 'txt_name.Text & " " & txt_SURNAME.Text
            dao.fields.PREFIXCD = 0
            dao.insert()
        Else
            dao1.fields.IDENTIFY = txt_citizen_id_search.Text
            'dao1.fields.NAME = txt_name.Text
            'dao1.fields.SURNAME = txt_SURNAME.Text
            dao1.fields.FULLNAME = txt_name.Text  'txt_name.Text & " " & txt_SURNAME.Text
            dao1.update()
        End If
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Protected Sub btn_check_Click(sender As Object, e As EventArgs) Handles btn_check.Click
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_SEARCH_PERSON.aspx');", True)
        Response.Redirect("FRM_SEARCH_PERSON.aspx")
    End Sub
End Class