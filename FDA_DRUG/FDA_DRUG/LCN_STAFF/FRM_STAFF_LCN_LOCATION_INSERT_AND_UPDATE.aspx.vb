Public Class FRM_STAFF_LCN_LOCATION_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _iden As String
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            'If Session("CLS") Is Nothing Then
            '    Response.Redirect("http://privus.fda.moph.go.th/")
            'Else
            _CLS = Session("CLS")
            _IDA = Request.QueryString("IDA")
            _iden = Request.QueryString("iden")
            'End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            chngwtcd()
            If Request.QueryString("t") Then
                If Request.QueryString("t") = "1" Then
                    lbl_place_type.Text = "ที่ตั้ง"
                ElseIf Request.QueryString("t") = "2" Then
                    lbl_place_type.Text = "สถานที่เก็บ"
                End If

            End If

            If _IDA <> "" Then
                'btn_send.Style.Add("display", "block")
                'bnt_submit.Style.Add("display", "none")
                If Request.QueryString("t") = "2" Then
                    loadData_by_Identify_keep()
                Else
                    loadData_by_Identify()
                End If

                Dim dao_loca_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                dao_loca_addr.GetDataby_IDA(_IDA)
                'If dao_loca_addr.fields.STATUS_ID > 1 Then
                '    'btn_send.Style.Add("display", "none")
                '    bnt_submit.Style.Add("display", "none")
                'End If
            Else
                'btn_send.Style.Add("display", "none")
                'bnt_submit.Style.Add("display", "block")
            End If
        End If
    End Sub
    Public Sub loadData_by_Identify()
        Dim dao_loca_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_loca_addr.GetDataby_IDA(_IDA)
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
        Try
            If dao_loca_addr.fields.LOCATION_TYPE_ID = "1" Then
                lbl_place_type.Text = "ที่ตั้ง"
            ElseIf dao_loca_addr.fields.LOCATION_TYPE_ID = "2" Then
                lbl_place_type.Text = "สถานที่เก็บ"
            End If
        Catch ex As Exception

        End Try


        Try
            txt_latitude.Text = dao_loca_addr.fields.latitude
            txt_longitude.Text = dao_loca_addr.fields.longitude
        Catch ex As Exception

        End Try
    End Sub
    Public Sub loadData_by_Identify_keep()
        Dim dao_loca_addr As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_loca_addr.GetDataby_IDA(_IDA)
        chngwtcd()
        txt_thabuilding_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_thabuilding
        txt_thafloor_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_thafloor
        txt_tharoom_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_tharoom
        txt_thanameplace_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_thanameplace
        txt_engnameplace_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_engnameplace
        txt_thacode_id_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_HOUSENO
        txt_thaaddr_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_thaaddr
        txt_thamu_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_thamu
        txt_thasoi_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_thasoi
        txt_tharoad_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_tharoad
        txt_zipcode_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_zipcode
        txt_tel_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_tel
        txt_mobile_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_Mobile
        txt_fax_lo.Text = dao_loca_addr.fields.LOCATION_ADDRESS_fax
        Try
            ddl_chngwt.DropDownSelectData(dao_loca_addr.fields.LOCATION_ADDRESS_chngwtcd)
        Catch ex As Exception

        End Try
        Try
            amphrcd()
            ddl_amphr.DropDownSelectData(dao_loca_addr.fields.LOCATION_ADDRESS_amphrcd)
        Catch ex As Exception

        End Try
        Try
            thmblcd()
            ddl_thumbol.DropDownSelectData(dao_loca_addr.fields.LOCATION_ADDRESS_thmblcd)
        Catch ex As Exception

        End Try
        'Try
        '    rdl_place_type.SelectedValue = dao_loca_addr.fields.LOCATION_TYPE_ID
        'Catch ex As Exception

        'End Try
        Try
            If Request.QueryString("t") = "1" Then
                lbl_place_type.Text = "ที่ตั้ง"
            ElseIf Request.QueryString("t") = "2" Then
                lbl_place_type.Text = "สถานที่เก็บ"
            End If
        Catch ex As Exception

        End Try
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
        dao_lcn.GetDataby_IDA(Request.QueryString("lcn_ida"))
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

        If Request.QueryString("lcn_ida") <> "" And Request.QueryString("t") <> "2" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("lcn_ida"))
            dao.fields.FK_IDA = dao_location_addr.fields.IDA
            dao.update()
        End If
        If Request.QueryString("t") = "2" Then
            KEEP_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มสถานที่เก็บ", _CLS.CITIZEN_ID)
        ElseIf Request.QueryString("t") = "1" Then
            KEEP_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มสถานที่ตั้ง", _CLS.CITIZEN_ID)
        End If

        KEEP_LOGS_EDIT(Request.QueryString("IDA"), "เพิ่มสถานที่ตั้ง/ที่เก็บใหม่", _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)

        Response.Write("<script type='text/javascript'>alert('บันทึกข้อมูลเรียบร้อยแล้ว'); parent.close_modal();</script> ")
        Response.Write("</script type >")
    End Sub
    Public Sub save_keep()
        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        Dim dao_syschngwt As New DAO_CPN.clsDBsyschngwt
        Dim dao_sysamphr As New DAO_CPN.clsDBsysamphr
        Dim dao_systhmbl As New DAO_CPN.clsDBsysthmbl

        Dim chngwtcd As Integer = ddl_chngwt.SelectedValue
        Dim amphrcd As Integer = ddl_amphr.SelectedValue
        Dim thmblcd As Integer = ddl_thumbol.SelectedValue


        dao_location_addr.fields.LOCATION_ADDRESS_thanameplace = txt_thanameplace_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_engnameplace = txt_engnameplace_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_HOUSENO = txt_thacode_id_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thabuilding = txt_thabuilding_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thafloor = txt_thafloor_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_tharoom = txt_tharoom_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thaaddr = txt_thaaddr_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thamu = txt_thamu_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thasoi = txt_thasoi_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_tharoad = txt_tharoad_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_zipcode = txt_zipcode_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_tel = txt_tel_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_Mobile = txt_mobile_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_fax = txt_fax_lo.Text

        dao_location_addr.fields.LOCATION_ADDRESS_chngwtcd = chngwtcd
        dao_location_addr.fields.LOCATION_ADDRESS_amphrcd = amphrcd
        dao_location_addr.fields.LOCATION_ADDRESS_thmblcd = thmblcd
        dao_location_addr.fields.LOCATION_ADDRESS_thachngwtnm = ddl_chngwt.SelectedItem.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thaamphrnm = ddl_amphr.SelectedItem.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thathmblnm = ddl_thumbol.SelectedItem.Text
        dao_syschngwt.GetData_by_chngwtcd(chngwtcd)
        dao_sysamphr.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
        dao_systhmbl.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

        dao_location_addr.fields.LOCATION_ADDRESS_engchngwtnm = dao_syschngwt.fields.engchngwtnm
        dao_location_addr.fields.LOCATION_ADDRESS_engamphrnm = dao_sysamphr.fields.engamphrnm
        dao_location_addr.fields.LOCATION_ADDRESS_engthmblnm = dao_systhmbl.fields.engthmblnm
        dao_location_addr.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE '_iden
        dao_location_addr.fields.LOCATION_ADDRESS_SYSTEM_NAME = "DRUG"
        'dao_location_addr.fields.CREATE_DATE = Date.Now
        dao_location_addr.insert()

        'If Request.QueryString("lcn_ida") <> "" Then
        '    Dim dao As New DAO_DRUG.ClsDBdalcn
        '    dao.GetDataby_IDA(Request.QueryString("lcn_ida"))
        '    dao.fields.FK_IDA = dao_location_addr.fields.IDA
        '    dao.update()
        'End If
        If Request.QueryString("lcn_ida") <> "" And Request.QueryString("t") <> "1" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("lcn_ida"))
            dao.fields.FK_IDA = dao_location_addr.fields.IDA
            dao.update()
        End If
        If Request.QueryString("t") = "2" Then
            KEEP_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มสถานที่เก็บ", _CLS.CITIZEN_ID)
        ElseIf Request.QueryString("t") = "1" Then
            KEEP_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มสถานที่ตั้ง", _CLS.CITIZEN_ID)
        End If

        Response.Write("<script type='text/javascript'>alert('บันทึกข้อมูลเรียบร้อยแล้ว'); parent.close_modal();</script> ")
        Response.Write("</script type >")
    End Sub
    Public Sub edit()

        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_location_addr.GetDataby_IDA(_IDA)
        Dim dao_syschngwt As New DAO_CPN.clsDBsyschngwt
        Dim dao_sysamphr As New DAO_CPN.clsDBsysamphr
        Dim dao_systhmbl As New DAO_CPN.clsDBsysthmbl

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

        dao_syschngwt.GetData_by_chngwtcd(chngwtcd)
        dao_sysamphr.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
        dao_systhmbl.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

        dao_location_addr.fields.engchngwtnm = dao_syschngwt.fields.engchngwtnm
        dao_location_addr.fields.engamphrnm = dao_sysamphr.fields.engamphrnm
        dao_location_addr.fields.engthmblnm = dao_systhmbl.fields.engthmblnm

        'dao_location_addr.fields.LOCATION_TYPE_ID = Request.QueryString("")
        Try
            dao_location_addr.fields.latitude = txt_latitude.Text
            dao_location_addr.fields.longitude = txt_longitude.Text
        Catch ex As Exception

        End Try
        dao_location_addr.fields.lmdfdate = Date.Now
        Dim bao_addr As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_addr.SP_GET_FULL_ADDR_DALCN_LOCATION_ADDRESS_BY_IDA(_IDA)
        Dim old_addr As String = ""
        Try
            old_addr = dt(0)("full_addr")
        Catch ex As Exception

        End Try
        If Request.QueryString("t") = "2" Then
            'KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขสถานที่เก็บ", _CLS.CITIZEN_ID)
            KEEP_LOGS_EDIT(Request.QueryString("IDA"), "แก้ไขสถานที่เก็บจาก " & old_addr, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
        ElseIf Request.QueryString("t") = "1" Then
            'KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขสถานที่ตั้ง", _CLS.CITIZEN_ID)
            KEEP_LOGS_EDIT(Request.QueryString("IDA"), "แก้ไขที่ตั้งจาก " & old_addr, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
        End If

       


        dao_location_addr.update()
        Response.Write("<script type='text/javascript'>alert('แก้ไขข้อมูลเรียบร้อยแล้ว'); parent.close_modal();</script> ")
        Response.Write("</script type >")
    End Sub
    Public Sub edit_keep()

        Dim dao_location_addr As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_location_addr.GetData_by_LCN_IDA(_IDA)
        Dim dao_syschngwt As New DAO_CPN.clsDBsyschngwt
        Dim dao_sysamphr As New DAO_CPN.clsDBsysamphr
        Dim dao_systhmbl As New DAO_CPN.clsDBsysthmbl

        Dim chngwtcd As Integer = ddl_chngwt.SelectedValue
        Dim amphrcd As Integer = ddl_amphr.SelectedValue
        Dim thmblcd As Integer = ddl_thumbol.SelectedValue

        dao_location_addr.fields.LOCATION_ADDRESS_thanameplace = txt_thanameplace_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_engnameplace = txt_engnameplace_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_HOUSENO = txt_thacode_id_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thabuilding = txt_thabuilding_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thafloor = txt_thafloor_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_tharoom = txt_tharoom_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thaaddr = txt_thaaddr_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thamu = txt_thamu_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thasoi = txt_thasoi_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_tharoad = txt_tharoad_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_zipcode = txt_zipcode_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_tel = txt_tel_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_Mobile = txt_mobile_lo.Text
        dao_location_addr.fields.LOCATION_ADDRESS_fax = txt_fax_lo.Text

        dao_location_addr.fields.LOCATION_ADDRESS_chngwtcd = chngwtcd
        dao_location_addr.fields.LOCATION_ADDRESS_amphrcd = amphrcd
        dao_location_addr.fields.LOCATION_ADDRESS_thmblcd = thmblcd
        dao_location_addr.fields.LOCATION_ADDRESS_thachngwtnm = ddl_chngwt.SelectedItem.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thaamphrnm = ddl_amphr.SelectedItem.Text
        dao_location_addr.fields.LOCATION_ADDRESS_thathmblnm = ddl_thumbol.SelectedItem.Text

        dao_syschngwt.GetData_by_chngwtcd(chngwtcd)
        dao_sysamphr.GetData_by_chngwtcd_amphrcd(chngwtcd, amphrcd)
        dao_systhmbl.GetData_by_chngwtcd_amphrcd_thmblcd(chngwtcd, amphrcd, thmblcd)

        dao_location_addr.fields.LOCATION_ADDRESS_engchngwtnm = dao_syschngwt.fields.engchngwtnm
        dao_location_addr.fields.LOCATION_ADDRESS_engamphrnm = dao_sysamphr.fields.engamphrnm
        dao_location_addr.fields.LOCATION_ADDRESS_engthmblnm = dao_systhmbl.fields.engthmblnm

        'dao_location_addr.fields.LOCATION_TYPE_ID = Request.QueryString("")
        'If Request.QueryString("t") = "2" Then
        '    KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขสถานที่เก็บ", _CLS.CITIZEN_ID)
        'ElseIf Request.QueryString("t") = "1" Then
        '    KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขสถานที่ตั้ง", _CLS.CITIZEN_ID)
        'End If
        Dim bao_addr As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao_addr.SP_CUSTOMER_LCN_BY_IDA(_IDA)
        dt = bao_addr.dt
        Dim old_addr As String = ""
        Try
            old_addr = dt(0)("fulladdr")
        Catch ex As Exception

        End Try
        If Request.QueryString("t") = "2" Then
            'KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขสถานที่เก็บ", _CLS.CITIZEN_ID)
            KEEP_LOGS_EDIT(Request.QueryString("IDA"), "แก้ไขสถานที่เก็บจาก " & old_addr, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
        ElseIf Request.QueryString("t") = "1" Then
            'KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขสถานที่ตั้ง", _CLS.CITIZEN_ID)
            KEEP_LOGS_EDIT(Request.QueryString("IDA"), "แก้ไขที่ตั้งจาก " & old_addr, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
        End If
        dao_location_addr.update()
        Response.Write("<script type='text/javascript'>alert('แก้ไขข้อมูลเรียบร้อยแล้ว'); parent.close_modal();</script> ")
        Response.Write("</script type >")
    End Sub
    Protected Sub bnt_submit_Click(sender As Object, e As EventArgs) Handles bnt_submit.Click
        If _IDA <> "" Then
            edit()
        Else
            save()

        End If
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
    End Sub

    Protected Sub btn_hno_Click(sender As Object, e As EventArgs) Handles btn_hno.Click
        Dim houseno As String = ""
        houseno = txt_thacode_id_lo.Text

        If houseno = "" Then
            'alert_normal("กรุณาระบุรหัสประจำบ้าน")
            Response.Write("<script type='text/javascript'>alert('กรุณาระบุรหัสประจำบ้าน');</script> ")
            Response.Write("</script type >")
        Else
            Try
                Dim ws As New WS_Taxno_TaxnoAuthorize.WebService1
                Dim obj As New WS_Taxno_TaxnoAuthorize.HOUSENO
                obj = ws.getDetail_Houseno_by_addressID(houseno)

                'txt_houseno.Text = obj.AddressID
                txt_thaaddr_lo.Text = obj.Address_No
                'txt_thabuild.Text = ""
                'txt_thafloor.Text = ""
                txt_thamu_lo.Text = obj.Address_Moo
                txt_thasoi_lo.Text = obj.Address_Soi
                txt_tharoad_lo.Text = obj.Address_Road
                txt_zipcode_lo.Text = obj.PostCode
                Lb_tel_lo.Text = obj.Tel01
                txt_fax_lo.Text = ""

                ddl_chngwt.DropDownSelectText(obj.Address_Province)
                amphrcd()
                ddl_amphr.DropDownSelectText(obj.Address_Amphur)
                thmblcd()
                ddl_thumbol.DropDownSelectText(obj.Address_Tumbol)
            Catch ex As Exception
                Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
                Response.Write("</script type >")
            End Try
            
            'lb_ampr_ws.Text = obj.Address_Amphur
            'lb_thmbl_ws.Text = obj.Address_Tumbol
            'lb_chngwt_ws.Text = obj.Address_Province
        End If
    End Sub
End Class