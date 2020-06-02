Public Class FRM_CHANGE_STAFF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            Try
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                txt_staff.Text = dao.fields.STAFF_IDENTIFY
                lbl_name_chk.Text = set_name_company(txt_staff.Text)
            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub btn_chk_Click(sender As Object, e As EventArgs) Handles btn_chk.Click
        lbl_name_chk.Text = set_name_company(txt_staff.Text)
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขบัตรประชาชน"
        End Try

        Return fullname
    End Function

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            dao.fields.STAFF_IDENTIFY = txt_staff.Text

            dao.update()

            ' Dim dao_log As New DAO_DRUG.
        End If
    End Sub
End Class