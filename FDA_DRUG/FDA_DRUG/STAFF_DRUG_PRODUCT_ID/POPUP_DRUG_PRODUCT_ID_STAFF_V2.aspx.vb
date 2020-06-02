Imports Telerik.Web.UI
Public Class POPUP_DRUG_PRODUCT_ID_STAFF_V2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _CLS = Session("CLS")
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            show_btn(Request.QueryString("IDA"))
            txt_app_date.Text = Date.Now.ToShortDateString()
            Bind_ddl_Status_staff()
            bind_SP_dactg()
            bind_ddl_jungwat()
            'bind_ddl_jungwat2()
            bind_ddl_jungwat3()
            bind_ddl_bsn_amper()
            ' bind_ddl_bsn_amper2()
            bind_ddl_bsn_amper3()
            bind_ddl_tumbol()
            ' bind_ddl_tumbol2()
            bind_ddl_tumbol3()
            bind_ddl_nat()
            bind_ddl_bio_pack()
            bind_ddl_bio_unit()
            bind_ddl_small_unit()
            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            get_data(dao)

            Dim dao2 As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
            dao2.GetDataby_FK_IDA(Request.QueryString("IDA"))
            get_data2(dao2)

            bind_ddl_bsn_amper()
            Try
                ddl_bsn_amper.DropDownSelectData(dao2.fields.amphrcd1)
            Catch ex As Exception

            End Try
            bind_ddl_tumbol()
            Try
                ddl_bsn_tumbol.DropDownSelectData(dao2.fields.thmblcd1)
            Catch ex As Exception

            End Try

            bind_ddl_bsn_amper3()
            Try
                ddl_bsn_amper3.DropDownSelectData(dao2.fields.amphrcd3)
            Catch ex As Exception

            End Try
            bind_ddl_tumbol3()
            Try
                ddl_bsn_tumbol3.DropDownSelectData(dao2.fields.thmblcd3)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_IDA(IDA)
        Dim cancel As String = ""
        Try
            cancel = dao.fields.CANCEL_STATUS
        Catch ex As Exception

        End Try

        If cancel = "1" Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ID)
        Txt_TRADE_NAME.Text = dao.fields.TRADE_NAME
        Txt_TRADE_NAME_ENG.Text = dao.fields.TRADE_NAME_ENG
        Try
            If dao.fields.IS_BE = True Then
                RadioButtonList1.SelectedValue = "True"
            ElseIf dao.fields.IS_BE = False Then
                RadioButtonList1.SelectedValue = "False"
            End If
        Catch ex As Exception

        End Try
        Txt_DRUG_NAME_OR_CODE.Text = dao.fields.DRUG_NAME_OR_CODE
        'dao.fields.IOWACD = ddl_chemecal.SelectedValue
        Txt_DRUG_STR.Text = dao.fields.STRENGTH_DRUG
        Txt_TERM_TO_USE.Text = dao.fields.TERM_TO_USE
        Txt_DRUG_NAME_OR_CODE.Text = dao.fields.DRUG_NAME_OR_CODE
        Try
            rcb_gr_group.SelectedValue = dao.fields.ctgcd
        Catch ex As Exception

        End Try
        Try
            cb_other_unit.Checked = dao.fields.IS_BIO
        Catch ex As Exception

        End Try
        Try
            ddl_bio_pack.DropDownSelectData(dao.fields.BIO_PACK)
        Catch ex As Exception

        End Try
        Try
            ddl_bio_unit.DropDownSelectData(dao.fields.BIO_UNIT)
        Catch ex As Exception

        End Try
        txt_REMARK.Text = dao.fields.REMARK
        Try
            rcb_small_unit.SelectedValue = dao.fields.PHYSIC_UNIT
        Catch ex As Exception

        End Try

        Try
            rdl_national.SelectedValue = dao.fields.NATIONAL_TYPE
        Catch ex As Exception

        End Try
        Try
            Txt_Drug_Nature.Text = dao.fields.DRUG_NATURE
        Catch ex As Exception

        End Try
        txt_reject_remark.Text = dao.fields.REJECT_REMARK
        Try
            txt_app_date.Text = CDate(dao.fields.CANCEL_DATE).ToShortDateString()
        Catch ex As Exception
            txt_app_date.Text = Date.Now.ToShortDateString()
        End Try
    End Sub
    Private Sub bind_ddl_nat()
        Dim dt As New DataTable
        Dim bao_master As New BAO_MASTER
        dt = bao_master.SP_MASTER_sysisocnt()
        ddl_nat.DataSource = dt
        ddl_nat.DataValueField = "IDA"
        ddl_nat.DataTextField = "engcntnm"

        ddl_nat.DataBind()
    End Sub
    Public Sub bind_SP_dactg()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_dactg
        dt = bao.SP_dosage_form
        'ddl_gr_group.DataSource = dt
        'ddl_gr_group.DataBind()
        rcb_gr_group.DataSource = dt
        rcb_gr_group.DataBind()
    End Sub
    Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        Panel_Set1.Style.Add("display", "none")
        Panel_Set2.Style.Add("display", "block")
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Panel_Set2.Style.Add("display", "none")
        Panel_Set1.Style.Add("display", "block")
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Dim statusID As Integer = ddl_status.SelectedItem.Value
        Dim bao As New BAO.GenNumber

        'Dim rcvno As String = bao.GEN_NO_17(con_year(Date.Now.Year()), _CLS.PVCODE, 19, _CLS.LCNNO, "", 0, IDA, "")
        'Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_IDA(IDA)

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = IDA
        Try
            dao_date.fields.STATUS_DATE = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try
        dao_date.fields.STATUS_GROUP = 4 'ชื่อสาร
        dao_date.fields.STATUS_ID = ddl_status.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.insert()

        If statusID = "7" Then
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value

            Try
                dao.fields.RCVDATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            alert("ไม่อนุมัติคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "8" Then
            Dim lcnno As String = bao.GEN_NO_16(con_year(Date.Now.Year()), _CLS.PVCODE, 40, _CLS.LCNNO, "", 0, IDA, "")
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            Try
                dao.fields.APPDATE = CDate(txt_app_date.Text)
                dao.fields.LCNNODATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao.fields.LCNNO = lcnno
            dao.fields.LCNNO_DISPLAY = "D" & lcnno
            dao.update()
            alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว เลขที่รับคือ " & "D" & lcnno)
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 3

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_status.DataSource = dt
        ddl_status.DataValueField = "STATUS_ID"
        ddl_status.DataTextField = "STATUS_NAME"
        ddl_status.DataBind()
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        dt = bao.SP_CDRUG_PRODUCT_IOWA(IDA)
        RadGrid1.DataSource = dt
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        dt = bao.SP_DRUG_PRODUCT_ATC(IDA)
        RadGrid2.DataSource = dt
    End Sub
    Public Sub get_data2(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ADDR)
        With dao.fields
            Try
                ddl_bsn_amper.DropDownSelectData(.amphrcd1)
            Catch ex As Exception

            End Try
            'Try
            '    ddl_bsn_amper2.DropDownSelectData(.amphrcd2)
            'Catch ex As Exception

            'End Try
            Try
                ddl_bsn_amper3.DropDownSelectData(.amphrcd3)
            Catch ex As Exception

            End Try
            Try
                ddl_bsn_jungwat.DropDownSelectData(.chngwtcd1)
            Catch ex As Exception

            End Try
            'Try
            '    ddl_bsn_jungwat2.DropDownSelectData(.chngwtcd2)
            'Catch ex As Exception

            'End Try
            Try
                ddl_bsn_jungwat3.DropDownSelectData(.chngwtcd3)
            Catch ex As Exception

            End Try
            Try
                ddl_bsn_tumbol.DropDownSelectData(.thmblcd1)
            Catch ex As Exception

            End Try
            'Try
            '    ddl_bsn_tumbol2.DropDownSelectData(.thmblcd2)
            'Catch ex As Exception

            'End Try
            Try
                ddl_bsn_tumbol3.DropDownSelectData(.thmblcd3)
            Catch ex As Exception

            End Try


            txt_tel.Text = .tel1
            'txt_tel2.Text = .tel2
            txt_tel3.Text = .tel3
            txt_addr.Text = .thaaddr1
            'txt_addr2.Text = .thaaddr2
            txt_addr3.Text = .thaaddr3

            txt_mu.Text = .thamu1
            'txt_mu2.Text = .thamu2
            txt_mu3.Text = .thamu3
            txt_thanameplace.Text = .thanameplace1
            'txt_thanameplace2.Text = .thanameplace2
            txt_thanameplace3.Text = .thanameplace3
            txt_zipcode.Text = .zipcode1
            'txt_zipcode2.Text = .zipcode2
            txt_zipcode3.Text = .zipcode3
            txt_soi.Text = .thasoi1
            'txt_soi2.Text = .thasoi2
            txt_soi3.Text = .thasoi3
            txt_road.Text = .tharoad1
            'txt_road2.Text = .tharoad2
            txt_road3.Text = .tharoad3
            txt_FRGN_CITY_NAME.Text = .FRGN_CITY_NAME
            txt_FRGN_FULLADDR.Text = .FRGN_FULLADDR
            txt_FRGN_NAME.Text = .FRGN_NAME
            txt_FRGN_ZIPCODE.Text = .FRGN_ZIPCODE
            Try
                ddl_nat.DropDownSelectData(.NATIONAL_CD)
            Catch ex As Exception

            End Try
        End With
    End Sub
    Private Sub bind_ddl_jungwat()
        Dim dao As New DAO_CPN.clsDBsyschngwt
        dao.GetDataAll()
        ddl_bsn_jungwat.DataSource = dao.datas
        ddl_bsn_jungwat.DataTextField = "thachngwtnm"
        ddl_bsn_jungwat.DataValueField = "chngwtcd"
        ddl_bsn_jungwat.DataBind()
    End Sub
    Private Sub bind_ddl_bsn_amper()
        Dim dao As New DAO_CPN.clsDBsysamphr
        dao.GetData_by_chngwtcd(ddl_bsn_jungwat.SelectedItem.Value)
        ddl_bsn_amper.DataSource = dao.datas
        ddl_bsn_amper.DataTextField = "thaamphrnm"
        ddl_bsn_amper.DataValueField = "amphrcd"
        ddl_bsn_amper.DataBind()
    End Sub
    Private Sub bind_ddl_tumbol()
        Dim dao As New DAO_CPN.clsDBsysthmbl
        dao.GetData_by_chngwtcd_amphrcd(ddl_bsn_jungwat.SelectedItem.Value, ddl_bsn_amper.SelectedItem.Value)
        ddl_bsn_tumbol.DataSource = dao.datas
        ddl_bsn_tumbol.DataTextField = "thathmblnm"
        ddl_bsn_tumbol.DataValueField = "thmblcd"
        ddl_bsn_tumbol.DataBind()
    End Sub

    'Private Sub bind_ddl_jungwat2()
    '    Dim dao As New DAO_CPN.clsDBsyschngwt
    '    dao.GetDataAll()
    '    ddl_bsn_jungwat2.DataSource = dao.datas
    '    ddl_bsn_jungwat2.DataTextField = "thachngwtnm"
    '    ddl_bsn_jungwat2.DataValueField = "chngwtcd"
    '    ddl_bsn_jungwat2.DataBind()
    'End Sub
    'Private Sub bind_ddl_bsn_amper2()
    '    Dim dao As New DAO_CPN.clsDBsysamphr
    '    dao.GetData_by_chngwtcd(ddl_bsn_jungwat2.SelectedItem.Value)
    '    ddl_bsn_amper2.DataSource = dao.datas
    '    ddl_bsn_amper2.DataTextField = "thaamphrnm"
    '    ddl_bsn_amper2.DataValueField = "amphrcd"
    '    ddl_bsn_amper2.DataBind()
    'End Sub
    'Private Sub bind_ddl_tumbol2()
    '    Dim dao As New DAO_CPN.clsDBsysthmbl
    '    dao.GetData_by_chngwtcd_amphrcd(ddl_bsn_jungwat2.SelectedItem.Value, ddl_bsn_amper2.SelectedItem.Value)
    '    ddl_bsn_tumbol2.DataSource = dao.datas
    '    ddl_bsn_tumbol2.DataTextField = "thathmblnm"
    '    ddl_bsn_tumbol2.DataValueField = "thmblcd"
    '    ddl_bsn_tumbol2.DataBind()
    'End Sub
    Public Sub bind_ddl_bio_pack()
        Dim dao As New DAO_DRUG.TB_MAS_BIO_PACK
        dao.GetDataALL()

        ddl_bio_pack.DataSource = dao.datas
        ddl_bio_pack.DataTextField = "BIO_PACK"
        ddl_bio_pack.DataValueField = "IDA"
        ddl_bio_pack.DataBind()
    End Sub
    Public Sub bind_ddl_bio_unit()
        Dim dao As New DAO_DRUG.TB_MAS_BIO_UNIT
        dao.GetDataALL()
        ddl_bio_unit.DataSource = dao.datas
        ddl_bio_unit.DataTextField = "BIO_UNIT"
        ddl_bio_unit.DataValueField = "IDA"
        ddl_bio_unit.DataBind()
    End Sub
    Private Sub bind_ddl_jungwat3()
        Dim dao As New DAO_CPN.clsDBsyschngwt
        dao.GetDataAll()
        ddl_bsn_jungwat3.DataSource = dao.datas
        ddl_bsn_jungwat3.DataTextField = "thachngwtnm"
        ddl_bsn_jungwat3.DataValueField = "chngwtcd"
        ddl_bsn_jungwat3.DataBind()
    End Sub
    Private Sub bind_ddl_bsn_amper3()
        Dim dao As New DAO_CPN.clsDBsysamphr
        dao.GetData_by_chngwtcd(ddl_bsn_jungwat3.SelectedItem.Value)
        ddl_bsn_amper3.DataSource = dao.datas
        ddl_bsn_amper3.DataTextField = "thaamphrnm"
        ddl_bsn_amper3.DataValueField = "amphrcd"
        ddl_bsn_amper3.DataBind()
    End Sub
    Private Sub bind_ddl_tumbol3()
        Dim dao As New DAO_CPN.clsDBsysthmbl
        dao.GetData_by_chngwtcd_amphrcd(ddl_bsn_jungwat3.SelectedItem.Value, ddl_bsn_amper3.SelectedItem.Value)
        ddl_bsn_tumbol3.DataSource = dao.datas
        ddl_bsn_tumbol3.DataTextField = "thathmblnm"
        ddl_bsn_tumbol3.DataValueField = "thmblcd"
        ddl_bsn_tumbol3.DataBind()
    End Sub

    Private Sub ddl_bsn_jungwat_TextChanged(sender As Object, e As EventArgs) Handles ddl_bsn_jungwat.TextChanged
        bind_ddl_bsn_amper()
        bind_ddl_tumbol()
    End Sub

    'Private Sub ddl_bsn_jungwat2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bsn_jungwat2.SelectedIndexChanged
    '    bind_ddl_bsn_amper2()
    '    bind_ddl_tumbol2()
    'End Sub

    Private Sub ddl_bsn_jungwat3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bsn_jungwat3.SelectedIndexChanged
        bind_ddl_bsn_amper3()
        bind_ddl_tumbol3()
    End Sub

    Private Sub ddl_bsn_amper_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bsn_amper.SelectedIndexChanged
        bind_ddl_tumbol()
    End Sub

    'Private Sub ddl_bsn_amper2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bsn_amper2.SelectedIndexChanged
    '    bind_ddl_tumbol2()
    'End Sub
    Private Sub ddl_bsn_amper3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bsn_amper3.SelectedIndexChanged
        bind_ddl_tumbol3()
    End Sub
    'Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    'dt  =bao.SP_DRUG_PRODUCT_ID_UNIT_DETAIL(Request.QueryString("IDA")


    '    Dim IDA As Integer = 0
    '    Try
    '        IDA = Request.QueryString("IDA")
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        dt = bao.SP_DRUG_PRODUCT_ID_UNIT_DETAIL(IDA)
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        Try
            dao.fields.CANCEL_DATE = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try
        dao.fields.REJECT_REMARK = txt_reject_remark.Text
        dao.fields.CANCEL_STATUS = 1
        dao.fields.CANCEL_TYPE = 1
        dao.update()
        alert("ยกเลิกเรียบร้อย")
    End Sub
    Public Sub bind_ddl_small_unit()
        'Dim dao As New DAO_DRUG.TB_DRUG_UNIT
        'dao.GetDataALL()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()

        rcb_small_unit.DataSource = dt
        'rcb_small_unit.DataTextField = "unit_name"
        'rcb_small_unit.DataValueField = "IDA"
        rcb_small_unit.DataBind()
    End Sub
End Class