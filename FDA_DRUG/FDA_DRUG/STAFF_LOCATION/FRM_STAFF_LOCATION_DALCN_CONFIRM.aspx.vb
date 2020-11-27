Public Class FRM_STAFF_LOCATION_DALCN_CONFIRM
    Inherits System.Web.UI.Page

    Private _TR_ID As String
    Private _IDA As Integer
    Private _Process As Integer
    Private _CLS As New CLS_SESSION

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _Process = Request.QueryString("process")
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        UC_GRID_ATTACH.load_gv_V2(_TR_ID, _Process)
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            Bind_GRID()
            txt_app_date.Text = Date.Now.ToShortDateString()
            loadData_by_Identify()
        End If
    End Sub
    Private Sub Bind_GRID()
        UC_GRID_ATTACH.load_gv_V2(_TR_ID, _Process)
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
        Try
            ddl_chngwt.DropDownSelectData(dao_loca_addr.fields.chngwtcd)
            amphrcd()
            ddl_amphr.DropDownSelectData(dao_loca_addr.fields.amphrcd)
            thmblcd()
            ddl_thumbol.DropDownSelectData(dao_loca_addr.fields.thmblcd)
        Catch ex As Exception

        End Try

        Try
            rdl_place_type.SelectedValue = dao_loca_addr.fields.LOCATION_TYPE_ID
        Catch ex As Exception

        End Try
        Try
            txt_latitude.Text = dao_loca_addr.fields.latitude
            txt_longitude.Text = dao_loca_addr.fields.longitude
        Catch ex As Exception

        End Try



    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_MAS_STATUS_STAFF()
        Dim int_group_ddl As Integer = 3
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_status.DataSource = dt
        ddl_status.DataValueField = "STATUS_ID"
        ddl_status.DataTextField = "STATUS_NAME"
        ddl_status.DataBind()
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim statusID As Integer = ddl_status.SelectedItem.Value
        Dim bao As New BAO.GenNumber
        Dim rcvno As String = ""
        Dim rcv_format As String = ""
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao.GetDataby_IDA(_IDA)

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 1 'สถานที่จำลอง
        dao_date.fields.STATUS_ID = ddl_status.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        'dao_date.fields.PROCESS_ID = _Process
        dao_date.insert()

        If statusID = "7" Then
            Response.Redirect("FRM_STAFF_LOCATION_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _Process)
            'dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            'Try
            '    dao.fields.rcvdate = CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try
            'dao.update()
            'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "3" Then
            bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, "99", _IDA)
            bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            Try
                dao.fields.rcvdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.rcvno = rcvno
            dao.update()
            alert("ทำการบันทึกข้อมูลเรียบร้อยแล้ว คุณได้เลขรับที่ " & rcvno)
        ElseIf statusID = "8" Then
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            dao.update()
            alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว")
        End If




    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
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
End Class