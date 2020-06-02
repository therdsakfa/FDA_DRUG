Public Class UC_LCN_BSN_ADDRESS
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'tha
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

        ''eng
        dao.fields.BSN_ENGADDR = lbl_BSN_ENGADDR.Text
        dao.fields.BSN_FLOOR = lbl_BSN_ENGADDR.Text
        dao.fields.BSN_ENGMU = lbl_BSN_ENGMU.Text
        dao.fields.BSN_ENGSOI = txt_BSN_ENGSOI.Text
        dao.fields.BSN_ENGROAD = txt_BSN_ENGROAD.Text
        dao.fields.BSN_CHWNG_ENGNAME = lbl_BSN_CHWNG_ENGNAME.Text
        dao.fields.BSN_AMPHR_ENGNAME = lbl_BSN_AMPHR_ENGNAME.Text
        dao.fields.BSN_THMBL_ENGNAME = lbl_BSN_THMBL_ENGNAME.Text

    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'tha
        txt_BSN_HOUSENO.Text = dao.fields.BSN_HOUSENO
        txt_BSN_ENGADDR.Text = dao.fields.BSN_ADDR
        txt_BSN_MOO.Text = dao.fields.BSN_MOO
        txt_BSN_SOI.Text = dao.fields.BSN_SOI
        txt_BSN_ROAD.Text = dao.fields.BSN_ROAD
        Try
            ddl_Province.DropDownSelectData(dao.fields.CHANGWAT_ID)
        Catch ex As Exception

        End Try
        Try
            ddl_amphor.DropDownSelectData(dao.fields.AMPHR_ID)
        Catch ex As Exception

        End Try
        Try
            ddl_tambol.DropDownSelectData(dao.fields.TUMBON_ID)
        Catch ex As Exception

        End Try

        txt_BSN_TELEPHONE.Text = dao.fields.BSN_TELEPHONE
        txt_BSN_FAX.Text = dao.fields.BSN_FAX

        ''eng
        lbl_BSN_ENGADDR.Text = dao.fields.BSN_ENGADDR
        lbl_BSN_ENGMU.Text = dao.fields.BSN_ENGMU
        txt_BSN_ENGSOI.Text = dao.fields.BSN_ENGSOI
        txt_BSN_ENGROAD.Text = dao.fields.BSN_ENGROAD
        lbl_BSN_CHWNG_ENGNAME.Text = dao.fields.BSN_CHWNG_ENGNAME
        lbl_BSN_AMPHR_ENGNAME.Text = dao.fields.BSN_AMPHR_ENGNAME
        lbl_BSN_THMBL_ENGNAME.Text = dao.fields.BSN_THMBL_ENGNAME
    End Sub

    Private Sub ddl_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Province.SelectedIndexChanged
        load_ddl_amp()
        load_ddl_thambol()
        call_lbl_set()
    End Sub

    Private Sub ddl_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphor.SelectedIndexChanged
        load_ddl_thambol()
        call_lbl_set()
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

    Public Sub call_lbl_set()
        set_lbl_province()
        set_lbl_amphr()
        set_lbl_thmbl()
    End Sub
    Private Sub set_lbl_province()
        Dim dao As New DAO_CPN.clsDBsyschngwt
        dao.GetData_by_chngwtcd(ddl_Province.SelectedValue)
        lbl_BSN_CHWNG_ENGNAME.Text = dao.fields.engchngwtnm
    End Sub
    Private Sub set_lbl_amphr()
        Dim dao As New DAO_CPN.clsDBsysamphr
        dao.GetData_by_chngwtcd_amphrcd(ddl_Province.SelectedValue, ddl_amphor.SelectedValue)
        lbl_BSN_AMPHR_ENGNAME.Text = dao.fields.engamphrnm
    End Sub
    Private Sub set_lbl_thmbl()
        Dim dao As New DAO_CPN.clsDBsysthmbl

        dao.GetData_by_chngwtcd_amphrcd_thmblcd(ddl_Province.SelectedValue, ddl_amphor.SelectedValue, ddl_tambol.SelectedValue)
        lbl_BSN_THMBL_ENGNAME.Text = dao.fields.engthmblnm
    End Sub

    Private Sub ddl_tambol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_tambol.SelectedIndexChanged
        call_lbl_set()
    End Sub

    Private Sub txt_BSN_ENGADDR_TextChanged(sender As Object, e As EventArgs) Handles txt_BSN_ENGADDR.TextChanged
        bind_lbl()
    End Sub

    Private Sub txt_BSN_MOO_TextChanged(sender As Object, e As EventArgs) Handles txt_BSN_MOO.TextChanged
        bind_lbl()
    End Sub

    Private Sub txt_BSN_ZIPCODE_TextChanged(sender As Object, e As EventArgs) Handles txt_BSN_ZIPCODE.TextChanged
        bind_lbl()
    End Sub

    Private Sub txt_BSN_TELEPHONE_TextChanged(sender As Object, e As EventArgs) Handles txt_BSN_TELEPHONE.TextChanged
        bind_lbl()
    End Sub

    Private Sub txt_BSN_FAX_TextChanged(sender As Object, e As EventArgs) Handles txt_BSN_FAX.TextChanged
        bind_lbl()
    End Sub
    Public Sub bind_lbl()
        lbl_BSN_ENGADDR.Text = txt_BSN_ENGADDR.Text
        lbl_BSN_ENGMU.Text = txt_BSN_MOO.Text
        lbl_BSN_ZIPCODE.Text = txt_BSN_ZIPCODE.Text
        lbl_BSN_TELEPHONE.Text = txt_BSN_TELEPHONE.Text
        lbl_BSN_FAX.Text = txt_BSN_FAX.Text
    End Sub
End Class