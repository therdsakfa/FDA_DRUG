Public Class FRM_PHR_ADD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            UC_PHR_ADD1.bind_ddl_prefix()
            UC_PHR_ADD1.bind_ddl_job()
            UC_PHR_ADD1.bind_ddl_work_type()
            UC_PHR_ADD1.bind_ddl_job()
            UC_PHR_ADD1.set_data_sakha()
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        UC_PHR_ADD1.set_data(dao)
        dao.fields.FK_IDA = Request.QueryString("ida")
        dao.insert()

        Dim dao_hs As New DAO_DRUG.TB_DALCN_PHR_HISTORY
        With dao_hs.fields
            .ACTIVE_DATE = Date.Now
            .FK_PHR_IDA = Request.QueryString("ida")
            .OLD_PHR_NAME = dao.fields.PHR_NAME
            .TYPE_INSERT = 3
            .PHR_CITIZEN_ID = dao.fields.PHR_CTZNO
            .PHR_CTZNO = dao.fields.PHR_CTZNO
            .PHR_LEVEL = dao.fields.PHR_LEVEL
            Try
                .PHR_PREFIX_ID = dao.fields.PHR_PREFIX_ID
            Catch ex As Exception

            End Try
            Try
                .PHR_PREFIX_NAME = dao.fields.PHR_PREFIX_NAME
            Catch ex As Exception

            End Try
            .PHR_TEXT_NUM = dao.fields.PHR_TEXT_NUM
            .PHR_TEXT_WORK_TIME = dao.fields.PHR_TEXT_WORK_TIME
            .FK_EDIT_COUNT = Request.QueryString("ida_c")
            .EDIT_TYPE = 5
        End With
        dao_hs.insert()

        Run_Service(Request.QueryString("ida"))
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub

    Sub Run_Service(ByVal IDA As Integer)
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_UPDATE_LICEN(IDA, _CLS.CITIZEN_ID)
    End Sub
End Class