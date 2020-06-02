Public Class POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2_NEXT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl_jungwat()
            'bind_ddl_jungwat2()
            bind_ddl_jungwat3()
            bind_ddl_bsn_amper()
            'bind_ddl_bsn_amper2()
            bind_ddl_bsn_amper3()
            bind_ddl_tumbol3()
            bind_ddl_tumbol()
            'bind_ddl_tumbol2()

            bind_ddl_nat()
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                get_data(dao)

                bind_ddl_bsn_amper()
                Try
                    ddl_bsn_amper.DropDownSelectData(dao.fields.amphrcd1)
                Catch ex As Exception

                End Try
                bind_ddl_tumbol()
                Try
                    ddl_bsn_tumbol.DropDownSelectData(dao.fields.thmblcd1)
                Catch ex As Exception

                End Try

                bind_ddl_bsn_amper3()
                Try
                    ddl_bsn_amper3.DropDownSelectData(dao.fields.amphrcd3)
                Catch ex As Exception

                End Try
                bind_ddl_tumbol3()
                Try
                    ddl_bsn_tumbol3.DropDownSelectData(dao.fields.thmblcd3)
                Catch ex As Exception

                End Try
                Dim dao2 As New DAO_DRUG.TB_DRUG_PRODUCT_ID
                dao2.GetDataby_IDA(Request.QueryString("IDA"))
                Try
                    If dao2.fields.STATUS_ID = 8 Then
                        btn_save.Style.Add("display", "none")
                    End If
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
       chk_update_or_insert()
        Dim url As String = ""
        url = "../DRUG_PRODUCT_ID/POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx?IDA=" & Request.QueryString("IDA") & "&lct_ida=" & Request.QueryString("lct_ida")
        If Request.QueryString("c") <> "" Then
            url &= "&c=1"
        End If
        Response.Redirect(url)

    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        chk_update_or_insert()
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Sub chk_update_or_insert()
        Dim bool As Boolean = False

        Dim dao_chk As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
        bool = dao_chk.Chk_repeat(Request.QueryString("IDA"))

        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
        If bool = False Then
            set_data(dao)
            dao.fields.FK_IDA = Request.QueryString("IDA")
            dao.insert()
        Else
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            set_data(dao)
            dao.update()

        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        chk_update_or_insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ADDR)
        With dao.fields
            .amphrcd1 = ddl_bsn_amper.SelectedValue
            '.amphrcd2 = ddl_bsn_amper2.SelectedValue
            .amphrcd3 = ddl_bsn_amper3.SelectedValue
            .chngwtcd1 = ddl_bsn_jungwat.SelectedValue
            '.chngwtcd2 = ddl_bsn_jungwat2.SelectedValue
            .chngwtcd3 = ddl_bsn_jungwat3.SelectedValue
            .thmblcd1 = ddl_bsn_tumbol.SelectedValue
            '.thmblcd2 = ddl_bsn_tumbol2.SelectedValue
            .thmblcd3 = ddl_bsn_tumbol3.SelectedValue
            Try
                .NATIONAL_CD = ddl_nat.SelectedValue
            Catch ex As Exception

            End Try

            .tel1 = txt_tel.Text
            '.tel2 = txt_tel2.Text
            .tel3 = txt_tel3.Text
            .thaaddr1 = txt_addr.Text
            '.thaaddr2 = txt_addr2.Text
            .thaaddr3 = txt_addr3.Text
            '-----------------------
            .thaamphrnm1 = ddl_bsn_amper.SelectedItem.Text
            '.thaamphrnm2 = ddl_bsn_amper2.SelectedItem.Text
            .thaamphrnm3 = ddl_bsn_amper3.SelectedItem.Text
            .thachngwtnm1 = ddl_bsn_jungwat.SelectedItem.Text
            '.thachngwtnm2 = ddl_bsn_jungwat2.SelectedItem.Text
            .thachngwtnm3 = ddl_bsn_jungwat3.SelectedItem.Text
            .thathmblnm1 = ddl_bsn_tumbol.SelectedItem.Text
            '.thathmblnm2 = ddl_bsn_tumbol2.SelectedItem.Text
            .thathmblnm3 = ddl_bsn_tumbol3.SelectedItem.Text
            '-------------------------
            .thamu1 = txt_mu.Text
            '.thamu2 = txt_mu2.Text
            .thamu3 = txt_mu3.Text
            .thanameplace1 = txt_thanameplace.Text
            '.thanameplace2 = txt_thanameplace2.Text
            .thanameplace3 = txt_thanameplace3.Text
            .zipcode1 = txt_zipcode.Text
            '.zipcode2 = txt_zipcode2.Text
            .zipcode3 = txt_zipcode3.Text
            .thasoi1 = txt_soi.Text
            '.thasoi2 = txt_soi2.Text
            .thasoi3 = txt_soi3.Text
            .tharoad1 = txt_road.Text
            '.tharoad2 = txt_road2.Text
            .tharoad3 = txt_road3.Text
            .FRGN_CITY_NAME = txt_FRGN_CITY_NAME.Text
            .FRGN_FULLADDR = txt_FRGN_FULLADDR.Text
            .FRGN_NAME = txt_FRGN_NAME.Text
            .FRGN_ZIPCODE = txt_FRGN_ZIPCODE.Text
            Try
                .NATIONAL_CD = ddl_nat.SelectedValue
            Catch ex As Exception

            End Try
        End With
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ADDR)
        With dao.fields

            Try
                ddl_bsn_jungwat.DropDownSelectData(.chngwtcd1)
            Catch ex As Exception

            End Try
            Try
                ddl_bsn_jungwat3.DropDownSelectData(.chngwtcd3)
            Catch ex As Exception

            End Try
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

            'Try
            '    ddl_bsn_jungwat2.DropDownSelectData(.chngwtcd2)
            'Catch ex As Exception

            'End Try

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
            Try
                ddl_nat.DropDownSelectData(.NATIONAL_CD)
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
        dao.GetData_by_chngwtcd(ddl_bsn_jungwat.SelectedValue)
        ddl_bsn_amper.DataSource = dao.datas
        ddl_bsn_amper.DataTextField = "thaamphrnm"
        ddl_bsn_amper.DataValueField = "amphrcd"
        ddl_bsn_amper.DataBind()
    End Sub
    Private Sub bind_ddl_tumbol()
        Dim dao As New DAO_CPN.clsDBsysthmbl
        dao.GetData_by_chngwtcd_amphrcd(ddl_bsn_jungwat.SelectedValue, ddl_bsn_amper.SelectedValue)
        ddl_bsn_tumbol.DataSource = dao.datas
        ddl_bsn_tumbol.DataTextField = "thathmblnm"
        ddl_bsn_tumbol.DataValueField = "thmblcd"
        ddl_bsn_tumbol.DataBind()
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
        dao.GetData_by_chngwtcd(ddl_bsn_jungwat3.SelectedValue)
        ddl_bsn_amper3.DataSource = dao.datas
        ddl_bsn_amper3.DataTextField = "thaamphrnm"
        ddl_bsn_amper3.DataValueField = "amphrcd"
        ddl_bsn_amper3.DataBind()
    End Sub
    Private Sub bind_ddl_tumbol3()
        Dim dao As New DAO_CPN.clsDBsysthmbl
        dao.GetData_by_chngwtcd_amphrcd(ddl_bsn_jungwat3.SelectedValue, ddl_bsn_amper3.SelectedValue)
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
End Class