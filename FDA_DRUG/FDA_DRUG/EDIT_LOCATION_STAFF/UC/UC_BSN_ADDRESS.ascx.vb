Public Class UC_BSN_ADDRESS
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_BSN)
        'tha
        dao.fields.BSN_HOUSENO = txt_BSN_HOUSENO.Text
        dao.fields.BSN_ADDR = txt_BSN_ENGADDR.Text
        dao.fields.BSN_MOO = txt_BSN_MOO.Text
        dao.fields.BSN_SOI = txt_BSN_SOI.Text
        dao.fields.BSN_ROAD = txt_BSN_ROAD.Text
        dao.fields.BSN_CHWNGNAME = ddl_bsn_Province.SelectedItem.Text
        dao.fields.CHANGWAT_ID = ddl_bsn_Province.SelectedValue
        dao.fields.AMPHR_ID = ddl_bsn_amphor.SelectedValue
        dao.fields.BSN_AMPHR_NAME = ddl_bsn_amphor.SelectedItem.Text
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
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        'tha
        dao.fields.BSN_HOUSENO = txt_BSN_HOUSENO.Text
        dao.fields.BSN_ADDR = txt_BSN_ENGADDR.Text
        dao.fields.BSN_MOO = txt_BSN_MOO.Text
        dao.fields.BSN_SOI = txt_BSN_SOI.Text
        dao.fields.BSN_ROAD = txt_BSN_ROAD.Text
        dao.fields.BSN_CHWNGNAME = ddl_bsn_Province.SelectedItem.Text
        dao.fields.CHANGWAT_ID = ddl_bsn_Province.SelectedValue
        dao.fields.AMPHR_ID = ddl_bsn_amphor.SelectedValue
        dao.fields.BSN_AMPHR_NAME = ddl_bsn_amphor.SelectedItem.Text
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
        '---------------------------------------------------------
        'tha
        dao.fields.BSN_HOUSENO_OLD = dao2.fields.BSN_HOUSENO
        dao.fields.BSN_ADDR_OLD = dao2.fields.BSN_ENGADDR
        dao.fields.BSN_MOO_OLD = dao2.fields.BSN_MOO
        dao.fields.BSN_SOI_OLD = dao2.fields.BSN_SOI
        dao.fields.BSN_ROAD_OLD = dao2.fields.BSN_ROAD
        dao.fields.BSN_CHWNGNAME_OLD = dao2.fields.BSN_CHWNGNAME
        dao.fields.CHANGWAT_ID_OLD = dao2.fields.CHANGWAT_ID
        dao.fields.AMPHR_ID_OLD = dao2.fields.AMPHR_ID
        dao.fields.BSN_AMPHR_NAME_OLD = dao2.fields.BSN_AMPHR_NAME
        dao.fields.BSN_THMBL_NAME_OLD = dao2.fields.BSN_THMBL_NAME
        dao.fields.TUMBON_ID_OLD = dao2.fields.TUMBON_ID
        dao.fields.BSN_TELEPHONE_OLD = dao2.fields.BSN_TELEPHONE
        dao.fields.BSN_FAX_OLD = dao2.fields.BSN_FAX

        ''eng
        dao.fields.BSN_ENGADDR_OLD = dao2.fields.BSN_ENGADDR
        dao.fields.BSN_FLOOR_OLD = dao2.fields.BSN_ENGADDR
        dao.fields.BSN_ENGMU_OLD = dao2.fields.BSN_ENGMU
        dao.fields.BSN_ENGSOI_OLD = dao2.fields.BSN_ENGSOI
        dao.fields.BSN_ENGROAD_OLD = dao2.fields.BSN_ENGROAD
        dao.fields.BSN_CHWNG_ENGNAME_OLD = dao2.fields.BSN_CHWNG_ENGNAME
        dao.fields.BSN_AMPHR_ENGNAME_OLD = dao2.fields.BSN_AMPHR_ENGNAME
        dao.fields.BSN_THMBL_ENGNAME_OLD = dao2.fields.BSN_THMBL_ENGNAME
    End Sub
    Public Sub set_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'tha
        dao.fields.BSN_HOUSENO = txt_BSN_HOUSENO.Text
        dao.fields.BSN_ADDR = txt_BSN_ENGADDR.Text
        dao.fields.BSN_MOO = txt_BSN_MOO.Text
        dao.fields.BSN_SOI = txt_BSN_SOI.Text
        dao.fields.BSN_ROAD = txt_BSN_ROAD.Text
        dao.fields.BSN_CHWNGNAME = ddl_bsn_Province.SelectedItem.Text
        dao.fields.CHANGWAT_ID = ddl_bsn_Province.SelectedValue
        dao.fields.AMPHR_ID = ddl_bsn_amphor.SelectedValue
        dao.fields.BSN_AMPHR_NAME = ddl_bsn_amphor.SelectedItem.Text
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
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_BSN)
        'tha
        lb_BSN_HOUSENO.Text = dao.fields.BSN_HOUSENO
        lb_BSN_ENGADDR.Text = dao.fields.BSN_ADDR
        lb_BSN_MOO.Text = dao.fields.BSN_MOO
        lb_BSN_SOI.Text = dao.fields.BSN_SOI
        lb_BSN_ROAD.Text = dao.fields.BSN_ROAD
        'ddl_Province.DropDownSelectData(dao.fields.CHANGWAT_ID)
        Dim dao_cw As New DAO_CPN.clsDBsyschngwt
        Try
            dao_cw.GetData_by_chngwtcd(dao.fields.CHANGWAT_ID)
            lb_Province.Text = dao_cw.fields.thachngwtnm
        Catch ex As Exception
            lb_Province.Text = "-"
        End Try

        Dim dao_amp As New DAO_CPN.clsDBsysamphr
        Try
            dao_amp.GetData_by_chngwtcd_amphrcd(dao.fields.CHANGWAT_ID, dao.fields.AMPHR_ID)
            lb_amphor.Text = dao_amp.fields.thaamphrnm
        Catch ex As Exception
            lb_amphor.Text = "-"
        End Try
        Dim dao_tb As New DAO_CPN.clsDBsysthmbl
        Try
            dao_tb.GetData_by_chngwtcd_amphrcd_thmblcd(dao.fields.CHANGWAT_ID, dao.fields.AMPHR_ID, dao.fields.TUMBON_ID)
            lb_bsn_tambol.Text = dao_tb.fields.thathmblnm
        Catch ex As Exception
            lb_bsn_tambol.Text = "-"
        End Try



        txt_BSN_TELEPHONE.Text = dao.fields.BSN_TELEPHONE
        txt_BSN_FAX.Text = dao.fields.BSN_FAX

        ''eng
        lbl_BSN_ENGADDR.Text = dao.fields.BSN_ENGADDR
        lbl_BSN_ENGMU.Text = dao.fields.BSN_ENGMU

        'txt_BSN_ENGSOI.Text = dao.fields.BSN_ENGSOI
        lb_BSN_ENGSOI.Text = dao.fields.BSN_ENGSOI
        'txt_BSN_ENGROAD.Text = dao.fields.BSN_ENGROAD
        lb_BSN_ENGROAD.Text = dao.fields.BSN_ENGROAD

        lbl_BSN_CHWNG_ENGNAME.Text = dao.fields.BSN_CHWNG_ENGNAME
        lbl_BSN_AMPHR_ENGNAME.Text = dao.fields.BSN_AMPHR_ENGNAME
        lbl_BSN_THMBL_ENGNAME.Text = dao.fields.BSN_THMBL_ENGNAME
    End Sub
    Public Sub get_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'tha
        lb_BSN_HOUSENO.Text = dao.fields.BSN_HOUSENO
        lb_BSN_ENGADDR.Text = dao.fields.BSN_ADDR
        lb_BSN_MOO.Text = dao.fields.BSN_MOO
        lb_BSN_SOI.Text = dao.fields.BSN_SOI
        lb_BSN_ROAD.Text = dao.fields.BSN_ROAD
        'ddl_Province.DropDownSelectData(dao.fields.CHANGWAT_ID)
        Dim dao_cw As New DAO_CPN.clsDBsyschngwt
        Try
            dao_cw.GetData_by_chngwtcd(dao.fields.CHANGWAT_ID)
            lb_Province.Text = dao_cw.fields.thachngwtnm
        Catch ex As Exception
            lb_Province.Text = "-"
        End Try


        Dim dao_amp As New DAO_CPN.clsDBsysamphr
        Try
            dao_amp.GetData_by_chngwtcd_amphrcd(dao.fields.CHANGWAT_ID, dao.fields.AMPHR_ID)
            lb_amphor.Text = dao_amp.fields.thaamphrnm
        Catch ex As Exception
            lb_amphor.Text = "-"
        End Try


        Dim dao_tb As New DAO_CPN.clsDBsysthmbl
        Try
            dao_tb.GetData_by_chngwtcd_amphrcd_thmblcd(dao.fields.CHANGWAT_ID, dao.fields.AMPHR_ID, dao.fields.TUMBON_ID)
            lb_bsn_tambol.Text = dao_tb.fields.thathmblnm
        Catch ex As Exception
            lb_bsn_tambol.Text = "-"
        End Try

        txt_BSN_TELEPHONE.Text = dao.fields.BSN_TELEPHONE
        txt_BSN_FAX.Text = dao.fields.BSN_FAX

        ''eng
        lbl_BSN_ENGADDR.Text = dao.fields.BSN_ENGADDR
        lbl_BSN_ENGMU.Text = dao.fields.BSN_ENGMU

        'txt_BSN_ENGSOI.Text = dao.fields.BSN_ENGSOI
        lb_BSN_ENGSOI.Text = dao.fields.BSN_ENGSOI
        'txt_BSN_ENGROAD.Text = dao.fields.BSN_ENGROAD
        lb_BSN_ENGROAD.Text = dao.fields.BSN_ENGROAD

        lbl_BSN_CHWNG_ENGNAME.Text = dao.fields.BSN_CHWNG_ENGNAME
        lbl_BSN_AMPHR_ENGNAME.Text = dao.fields.BSN_AMPHR_ENGNAME
        lbl_BSN_THMBL_ENGNAME.Text = dao.fields.BSN_THMBL_ENGNAME


        '---------------------------------------------------
        txt_BSN_HOUSENO.Text = dao.fields.BSN_HOUSENO
        txt_BSN_ENGADDR.Text = dao.fields.BSN_ADDR
        txt_BSN_MOO.Text = dao.fields.BSN_MOO
        txt_BSN_SOI.Text = dao.fields.BSN_SOI
        txt_BSN_ROAD.Text = dao.fields.BSN_ROAD

        txt_BSN_TELEPHONE.Text = dao.fields.BSN_TELEPHONE
        txt_BSN_FAX.Text = dao.fields.BSN_FAX

        ''eng
        txt_BSN_ENGADDR.Text = dao.fields.BSN_ENGADDR
        txt_BSN_ENGSOI.Text = dao.fields.BSN_ENGSOI
        txt_BSN_ENGROAD.Text = dao.fields.BSN_ENGROAD
    End Sub
    Private Sub ddl_bsn_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bsn_Province.SelectedIndexChanged
        load_ddl_amp()
        load_ddl_thambol()
        call_lbl_set()
    End Sub

    Private Sub ddl_bsn_amphor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bsn_amphor.SelectedIndexChanged
        load_ddl_thambol()
        call_lbl_set()
    End Sub
    Public Sub load_ddl_chwt()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SP_SYSCHNGWT()

        ddl_bsn_Province.DataSource = dt
        ddl_bsn_Province.DataBind()
    End Sub
    Public Sub load_ddl_amp()

        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSAMPHR_BY_CHNGWTCD(ddl_bsn_Province.SelectedValue)
        ddl_bsn_amphor.DataSource = dt
        ddl_bsn_amphor.DataBind()
    End Sub
    Public Sub load_ddl_thambol()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ddl_bsn_Province.SelectedValue, ddl_bsn_amphor.SelectedValue)
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
        dao.GetData_by_chngwtcd(ddl_bsn_Province.SelectedValue)
        lbl_BSN_CHWNG_ENGNAME.Text = dao.fields.engchngwtnm
    End Sub
    Private Sub set_lbl_amphr()
        Dim dao As New DAO_CPN.clsDBsysamphr
        dao.GetData_by_chngwtcd_amphrcd(ddl_bsn_Province.SelectedValue, ddl_bsn_amphor.SelectedValue)
        lbl_BSN_AMPHR_ENGNAME.Text = dao.fields.engamphrnm
    End Sub
    Private Sub set_lbl_thmbl()
        Dim dao As New DAO_CPN.clsDBsysthmbl

        dao.GetData_by_chngwtcd_amphrcd_thmblcd(ddl_bsn_Province.SelectedValue, ddl_bsn_amphor.SelectedValue, ddl_tambol.SelectedValue)
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