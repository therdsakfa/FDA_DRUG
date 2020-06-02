Public Class FRM_STAFF_LCN_BSN_EDIT_ADDR
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
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
            bind_ddl_prefix()
            If Request.QueryString("IDA") <> "" Then
                Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_bsn.GetDataby_IDA(Request.QueryString("ida"))
                get_data_bsn(dao_bsn)

            Else
                load_ddl_chwt()
                load_ddl_amp()
                load_ddl_thambol()
            End If
        End If
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub
    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()

        ddl_Province.DataSource = dt
        ddl_Province.DataBind()
    End Sub
    Public Sub load_ddl_amp()

        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(ddl_Province.SelectedValue)
        ddl_amphor.DataSource = dt
        ddl_amphor.DataBind()
    End Sub
    Public Sub load_ddl_thambol()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ddl_Province.SelectedValue, ddl_amphor.SelectedValue)
        ddl_tambol.DataSource = dt
        ddl_tambol.DataBind()
    End Sub
    Public Sub get_data_bsn(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_BSN)
        'tha
        txt_BSN_HOUSENO.Text = dao.fields.BSN_HOUSENO
        txt_BSN_ENGADDR.Text = dao.fields.BSN_ADDR
        txt_BSN_MOO.Text = dao.fields.BSN_MOO
        txt_BSN_SOI.Text = dao.fields.BSN_SOI
        txt_BSN_ROAD.Text = dao.fields.BSN_ROAD
        Try
            txt_BSN_MOBILE.Text = dao.fields.BSN_Mobile
        Catch ex As Exception

        End Try
        load_ddl_chwt()
        Try
            ddl_Province.DropDownSelectData(dao.fields.CHANGWAT_ID)
        Catch ex As Exception

        End Try
        load_ddl_amp()
        Try
            ddl_amphor.DropDownSelectData(dao.fields.AMPHR_ID)
        Catch ex As Exception

        End Try
        load_ddl_thambol()
        Try
            ddl_tambol.DropDownSelectData(dao.fields.TUMBON_ID)
        Catch ex As Exception

        End Try
        Try
            ddl_prefix.DropDownSelectData(dao.fields.BSN_PREFIXTHAICD)
        Catch ex As Exception

        End Try
        txt_BSN_TELEPHONE.Text = dao.fields.BSN_TELEPHONE
        txt_BSN_FAX.Text = dao.fields.BSN_FAX
        txt_bsn_citizen.Text = dao.fields.BSN_IDENTIFY
        txt_bsn_name.Text = dao.fields.BSN_THAINAME
        txt_bsn_lastname.Text = dao.fields.BSN_THAILASTNAME
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_BSN)
        'tha
        dao.fields.BSN_IDENTIFY = txt_bsn_citizen.Text
        dao.fields.BSN_HOUSENO = txt_BSN_HOUSENO.Text
        dao.fields.BSN_ADDR = txt_BSN_ENGADDR.Text
        dao.fields.BSN_MOO = txt_BSN_MOO.Text
        dao.fields.BSN_SOI = txt_BSN_SOI.Text
        dao.fields.BSN_ROAD = txt_BSN_ROAD.Text
        dao.fields.BSN_CHWNGNAME = ddl_Province.SelectedItem.Text
        dao.fields.CHANGWAT_ID = ddl_Province.SelectedValue
        dao.fields.AMPHR_ID = ddl_amphor.SelectedValue
        dao.fields.BSN_AMPHR_NAME = ddl_amphor.SelectedItem.Text
        dao.fields.BSN_THMBL_NAME = ddl_tambol.SelectedItem.Text
        dao.fields.TUMBON_ID = ddl_tambol.SelectedValue
        dao.fields.BSN_TELEPHONE = txt_BSN_TELEPHONE.Text
        dao.fields.BSN_FAX = txt_BSN_FAX.Text
        dao.fields.BSN_Mobile = txt_BSN_MOBILE.Text
        Try
            dao.fields.BSN_PREFIXTHAICD = ddl_prefix.SelectedValue
        Catch ex As Exception

        End Try
        dao.fields.BSN_THAINAME = txt_bsn_name.Text
        dao.fields.BSN_THAILASTNAME = txt_bsn_lastname.Text
        Try
            dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & " " & txt_bsn_name.Text & " " & txt_bsn_lastname.Text
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.GetDataby_IDA(Request.QueryString("ida"))
            set_data(dao_bsn)
            dao_bsn.update()
            Dim ws_update As New WS_DRUG.WS_DRUG
            ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');parent.close_modal();", True)
        End If
    End Sub

    Private Sub ddl_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Province.SelectedIndexChanged
        load_ddl_amp()
        load_ddl_thambol()
    End Sub

    Private Sub ddl_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphor.SelectedIndexChanged
        load_ddl_thambol()
    End Sub
End Class