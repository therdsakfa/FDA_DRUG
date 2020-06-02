Public Class FRM_ADD_STAFF
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
        RunSession()
        If Not IsPostBack Then
            Dim dao_con As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            dao_con.GetDataby_IDA(Request.QueryString("ida"))
            Try
                txt_staff_iden.Text = dao_con.fields.STAFF_IDENTIFY
                lbl_staff.Text = set_name_company(txt_staff_iden.Text)
            Catch ex As Exception

            End Try


        End If
    End Sub

    Private Sub btn_staff_Click(sender As Object, e As EventArgs) Handles btn_staff.Click
        lbl_staff.Text = set_name_company(txt_staff_iden.Text)
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
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_con As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
        dao_con.GetDataby_IDA(Request.QueryString("ida"))
        dao_con.fields.STAFF_IDENTIFY = txt_staff_iden.Text

        AddLogStatusEtracking(status_id:=0, STATUS_TYPE:=1, iden:=_CLS.CITIZEN_ID, description:="เพิ่มเจ้าหน้าที่ผู้รับผิดชอบคำขอ --> " & txt_staff_iden.Text, PROCESS_NAME:="เพิ่มเจ้าหน้าที่ผู้รับผิดชอบคำขอ", FK_IDA:=Request.QueryString("id_r"), SUB_IDA:=0, SUB_STATUS:=0, url:=HttpContext.Current.Request.Url.AbsoluteUri)
        'AddLogStatusEtracking(0, 1, _CLS.CITIZEN_ID, "", "เพิ่มเจ้าหน้าที่ผู้รับผิดชอบคำขอ", Request.QueryString("IDA"), 0, 0)
        dao_con.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub
End Class