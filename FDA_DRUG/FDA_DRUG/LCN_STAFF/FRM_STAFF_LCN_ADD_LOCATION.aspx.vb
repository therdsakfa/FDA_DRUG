Public Class FRM_STAFF_LCN_ADD_LOCATION
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

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
            set_ddl_place()
            set_ddl_place_sel()
            set_data()
            set_panel()
        End If
        If Request.QueryString("t") = "1" Then
            lbl_head.Text = "เลือกที่ตั้ง"
            lbl_name.Text = "ชื่อที่ตั้ง"
        Else
            lbl_head.Text = "เลือกสถานที่เก็บ"
            lbl_name.Text = "ชื่อสถานที่เก็บ"
        End If
    End Sub
    Private Sub ddl_placename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_placename.SelectedIndexChanged
        set_data()
    End Sub
    Sub set_data()
        hf_place.Value = ddl_placename.SelectedValue
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(ddl_placename.SelectedValue)
        Catch ex As Exception

        End Try
        Try
            For Each dr As DataRow In dt.Rows
                lbl_location_new.Text = dr("fulladdr4")
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub set_ddl_place()
        Dim iden As String = ""
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("ida"))
        Try
            iden = dao.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        'dt = bao.SP_LOCATION_ADDRESS_BY_IDENTIFY(iden)
        If Request.QueryString("t") = "2" Then
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, iden)
        ElseIf Request.QueryString("t") = "1" Then
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2_1(1, iden)
        End If

        ddl_placename.DataSource = dt
        ddl_placename.DataValueField = "IDA"
        ddl_placename.DataTextField = "thanameplace"
        ddl_placename.DataBind()

        Dim item As New ListItem("", "0")
        ddl_placename.Items.Insert(0, item)
    End Sub
    Sub set_ddl_place_sel()
        Dim iden As String = ""
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("ida"))
        Try
            iden = dao.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        'dt = bao.SP_LOCATION_ADDRESS_BY_IDENTIFY(iden)
        If Request.QueryString("t") = "2" Then
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, iden)
        ElseIf Request.QueryString("t") = "1" Then
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2_1(1, iden)
        End If

        ddl_placename_sel.DataSource = dt
        ddl_placename_sel.DataValueField = "IDA"
        ddl_placename_sel.DataTextField = "thanameplace"
        ddl_placename_sel.DataBind()

        Dim item As New ListItem("", "0")
        ddl_placename_sel.Items.Insert(0, item)
    End Sub
    Sub chngwtcd()
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim chn As New DAO_CPN.ClsDBsyschngwt
        Dim item As New ListItem("-----รายชื่อจังหวัด-----", "0")
        chn.GetDataAll()
        ddl_chngwt.DataSource = chn.datas
        ddl_chngwt.DataTextField = "thachngwtnm"
        ddl_chngwt.DataValueField = "chngwtcd"
        ddl_chngwt.DataBind()
        ddl_chngwt.Items.Insert(0, item)
    End Sub

    Sub amphrcd()   'เป็นการนำข้อมูลในตารางใส่ DropDown  ข้อมูลอำเภอ
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim amp As New DAO_CPN.ClsDBsysamphr
        amp.GetDataby_chngwtcd(ddl_chngwt.SelectedValue)
        ddl_amphr.DataSource = amp.datas
        ddl_amphr.DataTextField = "thaamphrnm"
        ddl_amphr.DataValueField = "amphrcd"
        ddl_amphr.DataBind()
        ddl_amphr.DropDownInsertDataFirstRow("-----รายชื่ออำเภอ-----", "0")
    End Sub
    Sub thmblcd()      'เป็นการนำข้อมูลในตารางใส่ DropDown  ข้อมูลตำบล
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim thm As New DAO_CPN.ClsDBsysthmbl
        thm.GetDataby_thmbl(ddl_chngwt.SelectedValue, ddl_amphr.SelectedValue)
        ddl_thumbol.DataSource = thm.datas
        ddl_thumbol.DataTextField = "thathmblnm"
        ddl_thumbol.DataValueField = "thmblcd"
        ddl_thumbol.DataBind()
        ddl_thumbol.DropDownInsertDataFirstRow("-----รายชื่อตำบล-----", "0")
    End Sub
    Protected Sub ddl_chngwt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_chngwt.SelectedIndexChanged

        ddl_amphr.Items.Clear()
        ddl_thumbol.Items.Clear()
        amphrcd()

    End Sub

    Protected Sub ddl_amphr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphr.SelectedIndexChanged

        thmblcd()


    End Sub
    Public Sub loadData_by_Identify()
        Dim dao_loca_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_loca_addr.GetDataby_IDA(ddl_placename_sel.SelectedValue)
        chngwtcd()
        txt_thabuilding_lo.Text = dao_loca_addr.fields.thabuilding
        txt_thafloor_lo.Text = dao_loca_addr.fields.thafloor
        txt_tharoom_lo.Text = dao_loca_addr.fields.tharoom
        txt_thanameplace_lo.Text = dao_loca_addr.fields.thanameplace
        txt_engnameplace_lo.Text = dao_loca_addr.fields.engnameplace
        txt_thacode_id_lo.Text = dao_loca_addr.fields.HOUSENO
        txt_thaaddr_lo.Text = dao_loca_addr.fields.thaaddr
        txt_thamu_lo.Text = dao_loca_addr.fields.thamu
        txt_thasoi_lo.Text = dao_loca_addr.fields.thasoi
        txt_tharoad_lo.Text = dao_loca_addr.fields.tharoad
        txt_zipcode_lo.Text = dao_loca_addr.fields.zipcode
        txt_tel_lo.Text = dao_loca_addr.fields.tel
        txt_mobile_lo.Text = dao_loca_addr.fields.Mobile
        txt_fax_lo.Text = dao_loca_addr.fields.fax
        'Try
        '    ddl_chngwt.DropDownSelectData(dao_loca_addr.fields.chngwtcd)
        '    amphrcd()
        '    ddl_amphr.DropDownSelectData(dao_loca_addr.fields.amphrcd)
        '    thmblcd()
        '    ddl_thumbol.DropDownSelectData(dao_loca_addr.fields.thmblcd)
        'Catch ex As Exception

        'End Try

        Try
            ddl_chngwt.DropDownSelectData(dao_loca_addr.fields.chngwtcd)
        Catch ex As Exception

        End Try
        Try
            amphrcd()
            ddl_amphr.DropDownSelectData(dao_loca_addr.fields.amphrcd)
        Catch ex As Exception

        End Try
        Try
            thmblcd()
            ddl_thumbol.DropDownSelectData(dao_loca_addr.fields.thmblcd)
        Catch ex As Exception

        End Try



        'Try
        '    rdl_place_type.SelectedValue = dao_loca_addr.fields.LOCATION_TYPE_ID
        'Catch ex As Exception

        'End Try
        'Try
        '    If dao_loca_addr.fields.LOCATION_TYPE_ID = "1" Then
        '        lbl_place_type.Text = "ที่ตั้ง"
        '    ElseIf dao_loca_addr.fields.LOCATION_TYPE_ID = "2" Then
        '        lbl_place_type.Text = "สถานที่เก็บ"
        '    End If
        'Catch ex As Exception

        'End Try


        Try
            txt_latitude.Text = dao_loca_addr.fields.latitude
            txt_longitude.Text = dao_loca_addr.fields.longitude
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("t") = "2" Then
            Try
                Dim dao_keep As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                dao_keep.GetData_by_LCN_IDA(Request.QueryString("ida"))
                If dao_keep.fields.IDA <> 0 Then
                    dao_keep.delete()
                End If

                If ddl_placename.Items.Count > 0 Then
                    Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                    Dim dao_LOCATION_ADDRESS_2 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                    dao_LOCATION_ADDRESS_2.GetDataby_IDA(ddl_placename.SelectedValue)
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = _CLS.CITIZEN_ID

                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.TR_ID = 0
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.FK_IDA = Request.QueryString("ida")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LCN_IDA = Request.QueryString("ida")
                    Catch ex As Exception

                    End Try

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thanameplace
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = dao_LOCATION_ADDRESS_2.fields.thanameplace
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lcnsid = dao_LOCATION_ADDRESS_2.fields.lcnsid
                    Catch ex As Exception

                    End Try

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engaddr = dao_LOCATION_ADDRESS_2.fields.engaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = dao_LOCATION_ADDRESS_2.fields.tharoom
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = dao_LOCATION_ADDRESS_2.fields.thabuilding
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engsoi = dao_LOCATION_ADDRESS_2.fields.engsoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engroad = dao_LOCATION_ADDRESS_2.fields.engroad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = dao_LOCATION_ADDRESS_2.fields.zipcode
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lstfcd = dao_LOCATION_ADDRESS_2.fields.lstfcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lmdfdate = dao_LOCATION_ADDRESS_2.fields.lmdfdate
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDA = dao_LOCATION_ADDRESS_2.fields.IDA
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_FK_IDA = dao_LOCATION_ADDRESS_2.fields.FK_IDA
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_TR_ID = dao_LOCATION_ADDRESS_2.fields.TR_ID
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_DOWN_ID = dao_LOCATION_ADDRESS_2.fields.DOWN_ID
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID_UPLOAD
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_XMLNAME = dao_LOCATION_ADDRESS_2.fields.XMLNAME
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engmu = dao_LOCATION_ADDRESS_2.fields.engmu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engfloor = dao_LOCATION_ADDRESS_2.fields.engfloor
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engbuilding = dao_LOCATION_ADDRESS_2.fields.engbuilding
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvno = dao_LOCATION_ADDRESS_2.fields.rcvno
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvdate = dao_LOCATION_ADDRESS_2.fields.rcvdate
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lctcd = dao_LOCATION_ADDRESS_2.fields.lctcd
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_STATUS_ID = dao_LOCATION_ADDRESS_2.fields.STATUS_ID
                    Catch ex As Exception

                    End Try


                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engnameplace = dao_LOCATION_ADDRESS_2.fields.engnameplace

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_HOUSENO = dao_LOCATION_ADDRESS_2.fields.HOUSENO
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_NORMAL
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_OTHER
                    Catch ex As Exception

                    End Try

                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thmblcd = dao_LOCATION_ADDRESS_2.fields.thmblcd
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_LOCATION_ADDRESS_2.fields.SYSTEM_NAME
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engthmblnm = dao_LOCATION_ADDRESS_2.fields.engthmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engamphrnm = dao_LOCATION_ADDRESS_2.fields.engamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engchngwtnm = dao_LOCATION_ADDRESS_2.fields.engchngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDENTIFY = dao_LOCATION_ADDRESS_2.fields.IDENTIFY
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_REMARK = dao_LOCATION_ADDRESS_2.fields.REMARK
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = dao_LOCATION_ADDRESS_2.fields.Mobile
                    dao_DALCN_DETAIL_LOCATION_KEEP.insert()

                    KEEP_LOGS_EDIT(Request.QueryString("ida"), "เลือกสถานที่เก็บใหม่", _CLS.CITIZEN_ID)

                    Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกข้อมูลเรียบร้อยแล้ว');parent.close_modal();</script> ")
                End If
            Catch ex As Exception

            End Try
        ElseIf Request.QueryString("t") = "1" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("ida"))
            dao.fields.FK_IDA = ddl_placename.SelectedValue
            dao.update()
            KEEP_LOGS_EDIT(Request.QueryString("ida"), "เลือกสถานที่ตั้งใหม่", _CLS.CITIZEN_ID)
            Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกข้อมูลเรียบร้อยแล้ว');parent.close_modal();</script> ")
        End If
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
    End Sub

    Private Sub ddl_placename_sel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_placename_sel.SelectedIndexChanged
        loadData_by_Identify()
    End Sub
    Public Sub save()
        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_syschngwt As New DAO_CPN.ClsDBsyschngwt
        Dim dao_sysamphr As New DAO_CPN.ClsDBsysamphr
        Dim dao_systhmbl As New DAO_CPN.ClsDBsysthmbl

        Dim chngwtcd As Integer = ddl_chngwt.SelectedValue
        Dim amphrcd As Integer = ddl_amphr.SelectedValue
        Dim thmblcd As Integer = ddl_thumbol.SelectedValue


        dao_location_addr.fields.thanameplace = txt_thanameplace_lo.Text
        dao_location_addr.fields.engnameplace = txt_engnameplace_lo.Text
        dao_location_addr.fields.HOUSENO = txt_thacode_id_lo.Text
        dao_location_addr.fields.thabuilding = txt_thabuilding_lo.Text
        dao_location_addr.fields.thafloor = txt_thafloor_lo.Text
        dao_location_addr.fields.tharoom = txt_tharoom_lo.Text
        dao_location_addr.fields.thaaddr = txt_thaaddr_lo.Text
        dao_location_addr.fields.thamu = txt_thamu_lo.Text
        dao_location_addr.fields.thasoi = txt_thasoi_lo.Text
        dao_location_addr.fields.tharoad = txt_tharoad_lo.Text
        dao_location_addr.fields.zipcode = txt_zipcode_lo.Text
        dao_location_addr.fields.tel = txt_tel_lo.Text
        dao_location_addr.fields.Mobile = txt_mobile_lo.Text
        dao_location_addr.fields.fax = txt_fax_lo.Text

        dao_location_addr.fields.chngwtcd = chngwtcd
        dao_location_addr.fields.amphrcd = amphrcd
        dao_location_addr.fields.thmblcd = thmblcd
        dao_location_addr.fields.thachngwtnm = ddl_chngwt.SelectedItem.Text
        dao_location_addr.fields.thaamphrnm = ddl_amphr.SelectedItem.Text
        dao_location_addr.fields.thathmblnm = ddl_thumbol.SelectedItem.Text
        dao_location_addr.fields.STATUS_ID = 8
        dao_syschngwt.GetData_by_chngwtcd(chngwtcd)
        dao_sysamphr.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
        dao_systhmbl.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

        dao_location_addr.fields.engchngwtnm = dao_syschngwt.fields.engchngwtnm
        dao_location_addr.fields.engamphrnm = dao_sysamphr.fields.engamphrnm
        dao_location_addr.fields.engthmblnm = dao_systhmbl.fields.engthmblnm

        dao_location_addr.fields.LOCATION_TYPE_ID = Request.QueryString("t")

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(Request.QueryString("ida"))
        Try
            dao_location_addr.fields.IDENTIFY = dao_lcn.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try

        dao_location_addr.fields.SYSTEM_NAME = "DRUG"
        Try
            dao_location_addr.fields.pvncd = _CLS.PVCODE
        Catch ex As Exception

        End Try
        Try
            dao_location_addr.fields.latitude = txt_latitude.Text
            dao_location_addr.fields.longitude = txt_longitude.Text
        Catch ex As Exception

        End Try
        dao_location_addr.fields.CREATE_DATE = Date.Now

        dao_location_addr.insert()

        If Request.QueryString("ida") <> "" And Request.QueryString("t") <> "2" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("ida"))
            dao.fields.FK_IDA = dao_location_addr.fields.IDA
            dao.update()
        End If


        'If Request.QueryString("t") = "2" Then
        '    KEEP_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มสถานที่เก็บ", _CLS.CITIZEN_ID)
        'ElseIf Request.QueryString("t") = "1" Then
        '    KEEP_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มสถานที่ตั้ง", _CLS.CITIZEN_ID)
        'End If

        KEEP_LOGS_EDIT(Request.QueryString("IDA"), "เพิ่มสถานที่ตั้ง/ที่เก็บใหม่", _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)

        Response.Write("<script type='text/javascript'>alert('บันทึกข้อมูลเรียบร้อยแล้ว'); parent.close_modal();</script> ")
        Response.Write("</script type >")
    End Sub

    Private Sub btn_save_sel_Click(sender As Object, e As EventArgs) Handles btn_save_sel.Click
        save()
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
    End Sub

    Private Sub rdl_choose_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_choose.SelectedIndexChanged
        set_panel()
    End Sub
    Sub set_panel()
        If rdl_choose.SelectedValue = "1" Then
            Panel1.Style.Add("display", "block")
            Panel2.Style.Add("display", "none")
        Else
            Panel1.Style.Add("display", "none")
            Panel2.Style.Add("display", "block")
        End If
    End Sub

End Class