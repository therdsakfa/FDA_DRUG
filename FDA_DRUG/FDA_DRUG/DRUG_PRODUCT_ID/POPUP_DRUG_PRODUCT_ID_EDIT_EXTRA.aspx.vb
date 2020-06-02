Imports Telerik.Web.UI
Public Class POPUP_DRUG_PRODUCT_ID_EDIT_EXTRA
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
        If Not IsPostBack Then
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                get_data(dao)
                
            End If
        End If
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ID)
        lbl_TRADE_NAME.Text = dao.fields.TRADE_NAME
        lbl_TRADE_NAME_ENG.Text = dao.fields.TRADE_NAME_ENG
        lbl_Product_ID.Text = dao.fields.LCNNO_DISPLAY
        Txt_Drug_Nature.Text = dao.fields.DRUG_NATURE
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ID)
        dao.fields.DRUG_NATURE = Txt_Drug_Nature.Text
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            set_data(dao)
            dao.update()

            Response.Write("<script type='text/javascript'>alert('บันทึกข้อมูลเรียบร้อย');parent.close_modal();</script> ")
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & Uri & "';", True)
        End If
    End Sub
End Class