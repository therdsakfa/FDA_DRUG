Public Class UC_LCN_LOCATION_ADDRESS_DETAIL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        'tha
        dao.fields.LOCATION_ADDRESS_HOUSENO = txt_HOUSENO.Text.Trim
        dao.fields.LOCATION_ADDRESS_thaaddr = txt_thaaddr.Text.Trim
        dao.fields.LOCATION_ADDRESS_thamu = txt_thamu.Text.Trim
        dao.fields.LOCATION_ADDRESS_thasoi = txt_thasoi.Text.Trim
        dao.fields.LOCATION_ADDRESS_tharoad = txt_tharoad.Text.Trim
        dao.fields.LOCATION_ADDRESS_thachngwtnm = ddl_Province.SelectedItem.Text.Trim
        dao.fields.LOCATION_ADDRESS_chngwtcd = ddl_Province.SelectedValue
        dao.fields.LOCATION_ADDRESS_amphrcd = ddl_amphor.SelectedValue
        dao.fields.LOCATION_ADDRESS_thaamphrnm = ddl_amphor.SelectedItem.Text
        dao.fields.LOCATION_ADDRESS_thathmblnm = ddl_tambol.SelectedItem.Text
        dao.fields.LOCATION_ADDRESS_thmblcd = ddl_tambol.SelectedValue
        ' dao.fields.LOCATION_ADDRESS_tel = txt_tel.Text.Trim
        dao.fields.LOCATION_ADDRESS_fax = txt_fax.Text.Trim

        ''eng
        dao.fields.LOCATION_ADDRESS_engaddr = txt_thaaddr.Text.Trim
        dao.fields.LOCATION_ADDRESS_engmu = txt_thamu.Text.Trim
        dao.fields.LOCATION_ADDRESS_engsoi = txt_engsoi.Text.Trim
        dao.fields.LOCATION_ADDRESS_engroad = txt_engroad.Text.Trim
        dao.fields.LOCATION_ADDRESS_engchngwtnm = lbl_engchngwtnm.Text.Trim
        dao.fields.LOCATION_ADDRESS_engamphrnm = lbl_engamphrnm.Text.Trim
        dao.fields.LOCATION_ADDRESS_engthmblnm = lbl_engthmblnm.Text.Trim
        '---------------------------------------------------------------------------
        'tha
        dao.fields.LOCATION_ADDRESS_HOUSENO_OLD = dao2.fields.LOCATION_ADDRESS_HOUSENO
        dao.fields.LOCATION_ADDRESS_thaaddr_OLD = dao2.fields.LOCATION_ADDRESS_thaaddr
        dao.fields.LOCATION_ADDRESS_thamu_OLD = dao2.fields.LOCATION_ADDRESS_thamu
        dao.fields.LOCATION_ADDRESS_thasoi_OLD = dao2.fields.LOCATION_ADDRESS_thasoi
        dao.fields.LOCATION_ADDRESS_tharoad_OLD = dao2.fields.LOCATION_ADDRESS_tharoad
        dao.fields.LOCATION_ADDRESS_thachngwtnm_OLD = dao2.fields.LOCATION_ADDRESS_thachngwtnm
        dao.fields.LOCATION_ADDRESS_chngwtcd_OLD = dao2.fields.LOCATION_ADDRESS_chngwtcd
        dao.fields.LOCATION_ADDRESS_amphrcd_OLD = dao2.fields.LOCATION_ADDRESS_amphrcd
        dao.fields.LOCATION_ADDRESS_thaamphrnm_OLD = dao2.fields.LOCATION_ADDRESS_thasoi
        dao.fields.LOCATION_ADDRESS_thathmblnm_OLD = dao2.fields.LOCATION_ADDRESS_thathmblnm
        dao.fields.LOCATION_ADDRESS_thmblcd_OLD = dao2.fields.LOCATION_ADDRESS_thmblcd
        dao.fields.LOCATION_ADDRESS_tel_OLD = dao2.fields.LOCATION_ADDRESS_tel
        dao.fields.LOCATION_ADDRESS_fax_OLD = dao2.fields.LOCATION_ADDRESS_fax

        ''eng
        dao.fields.LOCATION_ADDRESS_engaddr_OLD = dao2.fields.LOCATION_ADDRESS_engaddr
        dao.fields.LOCATION_ADDRESS_engmu_OLD = dao2.fields.LOCATION_ADDRESS_engmu
        dao.fields.LOCATION_ADDRESS_engsoi_OLD = dao2.fields.LOCATION_ADDRESS_engsoi
        dao.fields.LOCATION_ADDRESS_engroad_OLD = dao2.fields.LOCATION_ADDRESS_engroad
        dao.fields.LOCATION_ADDRESS_engchngwtnm_OLD = dao2.fields.LOCATION_ADDRESS_engchngwtnm
        dao.fields.LOCATION_ADDRESS_engamphrnm_OLD = dao2.fields.LOCATION_ADDRESS_engamphrnm
        dao.fields.LOCATION_ADDRESS_engthmblnm_OLD = dao2.fields.LOCATION_ADDRESS_engthmblnm
    End Sub
    Public Sub set_data_addr(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_ADDRESS)
        'tha
        dao.fields.HOUSENO = txt_HOUSENO.Text.Trim
        dao.fields.thaaddr = txt_thaaddr.Text.Trim
        dao.fields.thamu = txt_thamu.Text.Trim
        dao.fields.thasoi = txt_thasoi.Text.Trim
        dao.fields.tharoad = txt_tharoad.Text.Trim
        dao.fields.thachngwtnm = ddl_Province.SelectedItem.Text.Trim
        dao.fields.chngwtcd = ddl_Province.SelectedValue
        dao.fields.amphrcd = ddl_amphor.SelectedValue
        dao.fields.thaamphrnm = ddl_amphor.SelectedItem.Text
        dao.fields.thathmblnm = ddl_tambol.SelectedItem.Text
        dao.fields.thmblcd = ddl_tambol.SelectedValue
        'dao.fields.tel = txt_tel.Text.Trim
        dao.fields.fax = txt_fax.Text.Trim

        ''eng
        dao.fields.engaddr = txt_thaaddr.Text.Trim
        dao.fields.engmu = txt_thamu.Text.Trim
        dao.fields.engsoi = txt_engsoi.Text.Trim
        dao.fields.engroad = txt_engroad.Text.Trim
        dao.fields.engchngwtnm = lbl_engchngwtnm.Text.Trim
        dao.fields.engamphrnm = lbl_engamphrnm.Text.Trim
        dao.fields.engthmblnm = lbl_engthmblnm.Text.Trim
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'tha
        dao.fields.LOCATION_ADDRESS_HOUSENO = txt_HOUSENO.Text.Trim
        dao.fields.LOCATION_ADDRESS_thaaddr = txt_thaaddr.Text.Trim
        dao.fields.LOCATION_ADDRESS_thamu = txt_thamu.Text.Trim
        dao.fields.LOCATION_ADDRESS_thasoi = txt_thasoi.Text.Trim
        dao.fields.LOCATION_ADDRESS_tharoad = txt_tharoad.Text.Trim
        dao.fields.LOCATION_ADDRESS_thachngwtnm = ddl_Province.SelectedItem.Text.Trim
        dao.fields.LOCATION_ADDRESS_chngwtcd = ddl_Province.SelectedValue
        dao.fields.LOCATION_ADDRESS_amphrcd = ddl_amphor.SelectedValue
        dao.fields.LOCATION_ADDRESS_thaamphrnm = ddl_amphor.SelectedItem.Text
        dao.fields.LOCATION_ADDRESS_thathmblnm = ddl_tambol.SelectedItem.Text
        dao.fields.LOCATION_ADDRESS_thmblcd = ddl_tambol.SelectedValue
        'dao.fields.LOCATION_ADDRESS_tel = txt_tel.Text.Trim
        dao.fields.LOCATION_ADDRESS_fax = txt_fax.Text.Trim

        ''eng
        dao.fields.LOCATION_ADDRESS_engaddr = txt_thaaddr.Text.Trim
        dao.fields.LOCATION_ADDRESS_engmu = txt_thamu.Text.Trim
        dao.fields.LOCATION_ADDRESS_engsoi = txt_engsoi.Text.Trim
        dao.fields.LOCATION_ADDRESS_engroad = txt_engroad.Text.Trim
        dao.fields.LOCATION_ADDRESS_engchngwtnm = lbl_engchngwtnm.Text.Trim
        dao.fields.LOCATION_ADDRESS_engamphrnm = lbl_engamphrnm.Text.Trim
        dao.fields.LOCATION_ADDRESS_engthmblnm = lbl_engthmblnm.Text.Trim
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'tha
        lb_HOUSENO.Text = dao.fields.LOCATION_ADDRESS_HOUSENO
        lb_thaaddr.Text = dao.fields.LOCATION_ADDRESS_thaaddr
        lb_thamu.Text = dao.fields.LOCATION_ADDRESS_thamu
        lb_thasoi.Text = dao.fields.LOCATION_ADDRESS_thasoi
        lb_tharoad.Text = dao.fields.LOCATION_ADDRESS_tharoad
        Dim dao_cw As New DAO_CPN.clsDBsyschngwt
       
        Try
            dao_cw.GetData_by_chngwtcd(dao.fields.CHANGWAT_ID)

        Catch ex As Exception
            lb_Province.Text = "-"
        End Try
        Dim dao_amp As New DAO_CPN.clsDBsysamphr

        Try
            dao_amp.GetData_by_chngwtcd_amphrcd(dao.fields.CHANGWAT_ID, dao.fields.AMPHR_ID)

        Catch ex As Exception
            lb_amphor.Text = "-"
        End Try
        Dim dao_tb As New DAO_CPN.clsDBsysthmbl
        Try
            dao_tb.GetData_by_chngwtcd_amphrcd_thmblcd(dao.fields.CHANGWAT_ID, dao.fields.AMPHR_ID, dao.fields.TUMBON_ID)
            lb_tambol.Text = dao_tb.fields.thathmblnm
        Catch ex As Exception
            lb_tambol.Text = "-"
        End Try
        'Try
        '    ddl_Province.DropDownSelectData(dao.fields.LOCATION_ADDRESS_chngwtcd)
        'Catch ex As Exception

        'End Try
        'Try
        '    ddl_amphor.DropDownSelectData(dao.fields.LOCATION_ADDRESS_amphrcd)
        'Catch ex As Exception

        'End Try
        'Try
        '    ddl_tambol.DropDownSelectData(dao.fields.LOCATION_ADDRESS_thmblcd)
        'Catch ex As Exception

        'End Try
        'lb_tel.Text = dao.fields.LOCATION_ADDRESS_tel
        lb_fax.Text = dao.fields.LOCATION_ADDRESS_fax

        ''eng
        txt_thaaddr.Text = dao.fields.LOCATION_ADDRESS_engaddr
        txt_thamu.Text = dao.fields.LOCATION_ADDRESS_engmu
        'txt_engsoi.Text = dao.fields.LOCATION_ADDRESS_engsoi
        'txt_engroad.Text = dao.fields.LOCATION_ADDRESS_engroad
        lb_engsoi.Text = dao.fields.LOCATION_ADDRESS_engsoi
        lb_engroad.Text = dao.fields.LOCATION_ADDRESS_engroad
        lbl_engchngwtnm.Text = dao.fields.LOCATION_ADDRESS_engchngwtnm
        lbl_engamphrnm.Text = dao.fields.LOCATION_ADDRESS_engamphrnm
        lbl_engthmblnm.Text = dao.fields.LOCATION_ADDRESS_engthmblnm

        '-------------------------------------------
        txt_HOUSENO.Text = dao.fields.LOCATION_ADDRESS_HOUSENO
        txt_thaaddr.Text = dao.fields.LOCATION_ADDRESS_thaaddr
        txt_thamu.Text = dao.fields.LOCATION_ADDRESS_thamu
        txt_thasoi.Text = dao.fields.LOCATION_ADDRESS_thasoi
        txt_tharoad.Text = dao.fields.LOCATION_ADDRESS_tharoad
 

        txt_fax.Text = dao.fields.LOCATION_ADDRESS_fax

        ''eng
        txt_engsoi.Text = dao.fields.LOCATION_ADDRESS_engsoi
        txt_engroad.Text = dao.fields.LOCATION_ADDRESS_engroad
       
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
        lbl_engamphrnm.Text = dao.fields.engchngwtnm
    End Sub
    Private Sub set_lbl_amphr()
        Dim dao As New DAO_CPN.clsDBsysamphr
        dao.GetData_by_chngwtcd_amphrcd(ddl_Province.SelectedValue, ddl_amphor.SelectedValue)
        lbl_engamphrnm.Text = dao.fields.engamphrnm
    End Sub
    Private Sub set_lbl_thmbl()
        Dim dao As New DAO_CPN.clsDBsysthmbl

        dao.GetData_by_chngwtcd_amphrcd_thmblcd(ddl_Province.SelectedValue, ddl_amphor.SelectedValue, ddl_tambol.SelectedValue)
        lbl_engthmblnm.Text = dao.fields.engthmblnm
    End Sub

    Private Sub ddl_tambol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_tambol.SelectedIndexChanged
        call_lbl_set()
    End Sub

    Private Sub txt_thaaddr_TextChanged(sender As Object, e As EventArgs) Handles txt_thaaddr.TextChanged
        bind_lbl()
    End Sub

    Private Sub txt_thamu_TextChanged(sender As Object, e As EventArgs) Handles txt_thamu.TextChanged
        bind_lbl()
    End Sub

    Private Sub txt_zipcode_TextChanged(sender As Object, e As EventArgs) Handles txt_zipcode.TextChanged
        bind_lbl()
    End Sub

    'Private Sub txt_tel_TextChanged(sender As Object, e As EventArgs) Handles txt_tel.TextChanged
    '    bind_lbl()
    'End Sub

    Private Sub txt_fax_TextChanged(sender As Object, e As EventArgs) Handles txt_fax.TextChanged
        bind_lbl()
    End Sub
    Public Sub bind_lbl()
        lbl_thaaddr.Text = txt_thaaddr.Text
        lbl_thamu.Text = txt_thamu.Text
        lbl_zipcode.Text = txt_zipcode.Text
        'lbl_tel.Text = txt_tel.Text
        lbl_fax.Text = txt_fax.Text
    End Sub
End Class