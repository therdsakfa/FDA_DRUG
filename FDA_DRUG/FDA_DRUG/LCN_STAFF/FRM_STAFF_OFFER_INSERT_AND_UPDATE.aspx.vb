Public Class FRM_STAFF_OFFER_INSERT_AND_UPDATE
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
        hidden_btn()
        RunSession()
        If Not IsPostBack Then
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                Txt_Name.Text = dao.fields.STAFF_OFFER_NAME
            End If
        End If

    End Sub
    Sub hidden_btn()
        If Request.QueryString("IDA") <> "" Then
            btn_edit.Style.Add("display", "block")
            btn_save.Style.Add("display", "none")
        Else
            btn_edit.Style.Add("display", "none")
            btn_save.Style.Add("display", "block")
        End If
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_MAS_STAFF_OFFER)
        dao.fields.STAFF_OFFER_NAME = Txt_Name.Text
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_MAS_STAFF_OFFER
        set_data(dao)
        dao.fields.INSERT_CITIZEN = _CLS.CITIZEN_ID
        dao.fields.INSERT_DATE = Date.Now
        dao.fields.IS_USE = True
        dao.insert()
        alert("บันทึกข้อมูลเรียบร้อย")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_DRUG.TB_MAS_STAFF_OFFER
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        set_data(dao)
        dao.fields.UPDATE_CITIZEN = _CLS.CITIZEN_ID
        dao.fields.UPDATE_DATE = Date.Now
        dao.update()
        alert("แก้ไขข้อมูลเรียบร้อย")
    End Sub
End Class