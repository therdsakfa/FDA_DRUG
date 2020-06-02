Public Class DRUG_REQUEST_CENTER_PREVIEW
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                get_data(dao)
                Dim dao2 As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                Try
                    dao2.GetDataby_IDA(dao.fields.HEAD_IDA)
                    txt_r_no.Text = dao2.fields.RCVNO_DISPLAY
                Catch ex As Exception
                    txt_r_no.Text = "-"
                End Try

            End If
        End If
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_DRUG_REQUEST_CENTER)
        lbl_request_type.Text = dao.fields.TYPE_REQUEST_NAME
        txt_lcnno.Text = dao.fields.LCNNO_DISPLAY
        Try
            txt_date.Text = CDate(dao.fields.REQUEST_DATE).ToShortDateString
        Catch ex As Exception

        End Try
        txt_citizen_id.Text = dao.fields.CITIZEN_ID
        Try
            lbl_request_name.Text = set_name_company(dao.fields.CITIZEN_ID)
        Catch ex As Exception

        End Try
        txt_company.Text = dao.fields.CITIZEN_AUTHIRIZE
        lbl_company.Text = dao.fields.ALLOW_NAME
        txt_DRUG_NAME_ENG.Text = dao.fields.TRADENAME_ENG
        txt_DRUG_NAME_THAI.Text = dao.fields.TRADENAME
        lbl_placename.Text = dao.fields.PLACENAME
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function
End Class