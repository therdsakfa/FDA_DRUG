Public Class FRM_PHR_CHANGE
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
            UC_PHR_ADD1.bind_ddl_prefix()
            Try
                Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
                dao.GetDataby_IDA(Request.QueryString("ida"))
                lb_old_phr.Text = dao.fields.PHR_SURNAME
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        UC_PHR_ADD1.set_data(dao)
        dao.fields.FK_IDA = Request.QueryString("ida")
        dao.insert()

        Dim dao_old As New DAO_DRUG.ClsDBDALCN_PHR
        dao_old.GetDataby_IDA(Request.QueryString("ida"))

        Dim dao_hs As New DAO_DRUG.TB_DALCN_PHR_HISTORY
        With dao_hs.fields
            .ACTIVE_DATE = Date.Now
            .FK_PHR_IDA = dao.fields.PHR_IDA 'Request.QueryString("ida")
            .OLD_PHR_NAME = dao.fields.PHR_NAME
            .TYPE_INSERT = 5
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
            .EDIT_TYPE = 9
            .IDA_CHANGE = Request.QueryString("ida")

            Dim dao_new As New DAO_DRUG.ClsDBDALCN_PHR
            dao_new.GetDataby_IDA(Request.QueryString("old"))

            .NEW_PHR_CITIZEN_ID = dao_new.fields.PHR_CTZNO
            .NEW_PHR_CTZNO = dao_new.fields.PHR_CTZNO
            .NEW_PHR_LEVEL = dao_new.fields.PHR_LEVEL
            .NEW_PHR_NAME = dao_new.fields.PHR_NAME
            .NEW_PHR_PREFIX_ID = dao_new.fields.PHR_PREFIX_ID
            .NEW_PHR_PREFIX_NAME = dao_new.fields.PHR_PREFIX_NAME
            .NEW_PHR_TEXT_NUM = dao_new.fields.PHR_TEXT_NUM
            .NEW_PHR_TEXT_WORK_TIME = dao_new.fields.PHR_TEXT_WORK_TIME
            .NEW_POSITION_IDA = dao_new.fields.POSITION_IDA
            .NEW_POSITION_NAME = dao_new.fields.POSITION_NAME


        End With
        dao_hs.insert()

        Run_Service_LCN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.close_modal();", True)
    End Sub
End Class