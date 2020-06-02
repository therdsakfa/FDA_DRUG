Public Class FRM_PHR_JOB
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
            bind_ddl_job()
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(Request.QueryString("phr"))
            Try
                ddl_job.DropDownSelectData(dao.fields.PHR_JOB_TYPE)
            Catch ex As Exception

            End Try

            Try
                Dim dao_f As New DAO_DRUG.TB_daphrfunctcd
                dao_f.GetDataby_functcd(dao.fields.PHR_JOB_TYPE)
                lbl_old_job.Text = dao_f.fields.functnm
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub bind_ddl_job()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_PHR_JOB()
        Catch ex As Exception

        End Try
        ddl_job.DataSource = dt
        ddl_job.DataValueField = "functcd"
        ddl_job.DataTextField = "functnm"
        ddl_job.DataBind()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_IDA(Request.QueryString("phr"))
        dao.fields.PHR_JOB_TYPE = ddl_job.SelectedValue


        Dim dao_his As New DAO_DRUG.TB_DALCN_PHR_HISTORY
        dao_his.fields.OLD_PHR_NAME = dao.fields.PHR_NAME
        dao_his.fields.TYPE_INSERT = 5
        dao_his.fields.ACTIVE_DATE = Date.Now
        dao_his.fields.PHR_CITIZEN_ID = dao.fields.PHR_CTZNO
        dao_his.fields.PHR_LEVEL = dao.fields.PHR_LEVEL
        dao_his.fields.FK_PHR_IDA = Request.QueryString("phr")
        dao_his.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
        dao_his.fields.EDIT_TYPE = 7 'แก้หน้าที่
        dao_his.fields.JOB_TYPE = ddl_job.SelectedValue
        dao_his.fields.NEW_JOB_TYPE = dao.fields.PHR_JOB_TYPE
        dao_his.insert()

        dao.update()
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class