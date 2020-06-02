Public Class FRM_STAFF_LCN_PHR_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(Request.QueryString("phr"))
            UC_PHR_ADD1.bind_ddl_prefix()
            UC_PHR_ADD1.bind_ddl_job()
            UC_PHR_ADD1.bind_ddl_work_type()
            UC_PHR_ADD1.bind_lcn_type()
            UC_PHR_ADD1.get_data(dao)
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(Request.QueryString("phr"))
        UC_PHR_ADD1.get_PHR_NAME()
        KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขผู้ปฏิบัติการจาก " & dao.fields.PHR_NAME & " เป็น " & UC_PHR_ADD1.PHR_NAME, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
        'Dim dao_hs As New DAO_DRUG.TB_DALCN_PHR_HISTORY
        'UC_PHR_ADD1.set_data_his(dao_hs, dao)
        UC_PHR_ADD1.set_data(dao)

        dao.update()
        'dao_hs.insert()
        Try
            Dim ws_update As New WS_DRUG.WS_DRUG
            ws_update.DRUG_UPDATE_LICEN(dao.fields.FK_IDA, _CLS.CITIZEN_ID)
        Catch ex As Exception

        End Try


        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');parent.close_modal();", True)
    End Sub
End Class