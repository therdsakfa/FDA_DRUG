Public Class WebForm32
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunQuery()
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
        RunQuery()

    End Sub
    'Protected Sub btn_1_Click(sender As Object, e As EventArgs) Handles btn_1.Click
    '    Response.Redirect("../LCN_STAFF/FRM_LCN_DRUG.aspx")
    'End Sub
    'Protected Sub btn_2_Click(sender As Object, e As EventArgs) Handles btn_2.Click
    '    Response.Redirect("../LCN_STAFF/FRM_LCN_DRUG.aspx")
    'End Sub
    'Protected Sub btn_3_Click(sender As Object, e As EventArgs) Handles btn_3.Click
    '    Response.Redirect("FRM_LIST.aspx?template=3")
    'End Sub
    'Protected Sub btn_4_Click(sender As Object, e As EventArgs) Handles btn_4.Click
    '    Response.Redirect("../DRUG_STAFF_CER/FRM_STAFF_CER_MAIN.aspx")
    'End Sub
    'Protected Sub btn_5_Click(sender As Object, e As EventArgs) Handles btn_5.Click
    '    Response.Redirect("../CHEMICAL_STAFF/FRM_CHEMICAL_STAFF_MAIN.aspx")
    'End Sub
    'Protected Sub btn_6_Click(sender As Object, e As EventArgs) Handles btn_6.Click
    '    Response.Redirect("../DRUG_STAFF_DH/FRM_DH_MAIN_STAFF.aspx")
    'End Sub

    'Protected Sub btn_7_Click(sender As Object, e As EventArgs) Handles btn_7.Click
    '    Response.Redirect("../STAFF_LOCATION/FRM_STAFF_LOCATION.aspx")
    'End Sub

    'Protected Sub btn_8_Click(sender As Object, e As EventArgs) Handles btn_8.Click
    '    Response.Redirect("../STAFF_LOCATION_TO/FRM_LOCATION_STAFF_TO.aspx")
    'End Sub

    'Private Sub btn_9_Click(sender As Object, e As EventArgs) Handles btn_9.Click
    '    Response.Redirect("../LCN_STAFF/FRM_STAFF_OFFER.aspx")
    'End Sub

    'Private Sub btn_10_Click(sender As Object, e As EventArgs) Handles btn_10.Click
    '    Response.Redirect("../REGISTRATION_STAFF/FRM_REGISTRATION_MAIN_STAFF.aspx")
    'End Sub

    'Protected Sub btn_11_Click(sender As Object, e As EventArgs) Handles btn_11.Click
    '    Response.Redirect("../REQUESTS_STAFF/FRM_REQUESTS_MAIN_STAFF.aspx")
    'End Sub
    'Private Sub btn_edit_req_Click(sender As Object, e As EventArgs) Handles btn_edit_req.Click
    '    Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_LOCATION_SEARCH.aspx")
    'End Sub
    ''Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ''    Response.Redirect("../EDIT_LOCATION/FRM_STAFF_EDIT_LOCATION_MAIN.aspx")
    ''End Sub

    'Private Sub btn_product_Click(sender As Object, e As EventArgs) Handles btn_product.Click
    '    Response.Redirect("../STAFF_DRUG_PRODUCT_ID/FRM_DRUG_PRODUCT_ID_STAFF_MAIN.aspx")
    'End Sub

    'Protected Sub btn_receive_edit_Click(sender As Object, e As EventArgs) Handles btn_receive_edit.Click
    '    Response.Redirect("../EDIT_LOCATION_STAFF/FRM_STAFF_EDIT_LOCATION_MAIN.aspx")
    'End Sub

    'Private Sub btn_det_product_Click(sender As Object, e As EventArgs) Handles btn_det_product.Click
    '    Response.Redirect("../DR/FRM_DR_DTL_TEXT_MAIN.aspx")
    'End Sub

    'Private Sub btn_extend_Click(sender As Object, e As EventArgs) Handles btn_extend.Click
    '    Response.Redirect("../EDIT_LOCATION_STAFF/FRM_STAFF_EXTEND_TIME_LOCATION_MAIN.aspx")
    'End Sub
End Class