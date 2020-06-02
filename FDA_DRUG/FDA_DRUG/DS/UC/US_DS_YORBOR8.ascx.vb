Public Class US_DS_YORBOR8
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_WRITE_DATE.Text = Date.Now.ToShortDateString
    End Sub
    Public Sub bind_dd1_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()

        'ddl_unit.DataSource = dt
        'ddl_unit.DataTextField = "sunitengnm"
        'ddl_unit.DataValueField = "IDA"
        'ddl_unit.DataBind()
    End Sub
    Public Sub bind_QUANTITY_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()

        'ddl_QUANTITY_unit.DataSource = dt
        'ddl_QUANTITY_unit.DataTextField = "sunitengnm"
        'ddl_QUANTITY_unit.DataValueField = "IDA"
        'ddl_QUANTITY_unit.DataBind()

    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.ClsDBdrsamp)
        dao.fields.WRITE_AT = txt_WRITE_AT.Text
        dao.fields.WRITE_DATE = txt_WRITE_DATE.Text
        'dao.fields.QUANTITY = txt_QUANTITY.Text
        'dao.fields.QUANTITY_UNIT = ddl_QUANTITY_unit.SelectedValue
        Try
            dao.fields.WRITE_DATE = CDate(txt_WRITE_DATE.Text)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub set_label(ByVal lcn_ida As Integer)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(lcn_ida)
        Dim a As String = ""
        Dim b As String = ""
        Try ' SubString
            a = dao_lcn.fields.pvnabbr
            b = dao_lcn.fields.lcnno.ToString.Substring(4, 3)
            lbl_lcnno.Text = a + b + "/25" + dao_lcn.fields.lcnno.ToString.Substring(0, 2)

            'lbl_lcnno2.Text = dao_lcn.fields.lcnno
            '@QueryString("", "/", "")
        Catch ex As Exception

        End Try
        Try

        Catch ex As Exception

        End Try
        Dim lct_ida As Integer = 73405

        Try
            'lct_ida = dao_lcn.fields.FK_IDA
        Catch ex As Exception

        End Try
        Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
        dao.GetDataby_IDA(lct_ida)
        lbl_number.Text = dao.fields.thaaddr
        lbl_name.Text = dao.fields.thanameplace
        lbl_lane.Text = dao.fields.thasoi
        lbl_road.Text = dao.fields.tharoad
        lbl_village_no.Text = dao.fields.chngwtcd
        lbl_sub_district.Text = dao.fields.thathmblnm
        lbl_district.Text = dao.fields.thaamphrnm
        lbl_province.Text = dao.fields.thachngwtnm
        lbl_tel.Text = dao.fields.tel




        Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
        Try
            dao_bsn.Getdata_by_fk_id2(lct_ida)
            lbl_bsn_name.Text = dao_bsn.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

        Try
            Dim dao2 As New DAO_CPN.clsDBsyslcnsnm
            dao2.GetDataby_identify(dao.fields.IDENTIFY)
            lbl_lcnsnm.Text = dao2.fields.thanm & " " & dao2.fields.thalnm
        Catch ex As Exception

        End Try


    End Sub
End Class