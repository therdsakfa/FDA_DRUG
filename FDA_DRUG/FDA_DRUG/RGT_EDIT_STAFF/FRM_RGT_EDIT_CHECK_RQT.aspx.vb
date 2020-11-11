Public Class FRM_RGT_EDIT_CHECK_RQT
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Dim STATUS_ID As Integer = 0

    Sub RunQuery()
        Try
            STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            rtb_decrease.Text = 0
            txt_rcvdate.Text = Date.Now.ToShortDateString()
            bind_ddl_rqt()
            bind_tabean_group()
            Try
                Dim dao_rg As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                dao_rg.GetDatabyIDA(_IDA)
                'Dim dao_t As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                'dao_t.GetDataby_CD(dao_rg.fields.TYPE_REQUEST_ID)
                ddl_req_type.SelectedValue = dao_rg.fields.TYPE_REQUESTS_ID

            Catch ex As Exception

            End Try
            Load_data()


            Try
                bine_text_sum()
            Catch ex As Exception

            End Try

        End If
    End Sub
    Sub bind_tabean_group()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_drdrgtype_ALL()
        ddl_tabean_group.DataSource = dt
        ddl_tabean_group.DataTextField = "thadrgtpnm"
        ddl_tabean_group.DataValueField = "drgtpcd"
        ddl_tabean_group.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_tabean_group.Items.Insert(0, item)
    End Sub
    Sub Load_data()

        RunQuery()

        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(Request.QueryString("IDA"))
        Try
            Dim dao_rqt As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
            dao_rqt.GetDataby_CD(dao.fields.TYPE_REQUESTS_ID)
            'lbl_type_request.Text = dao_rqt.fields.TYPE_REQUESTS_NAME

            'bind_ddl_money(dao.fields.TYPE_REQUESTS_ID)
            bind_ddl_money(dao.fields.TYPE_REQUESTS_ID)
        Catch ex As Exception

        End Try

        'Try
        '    lbl_name_staff.Text = _CLS.THANM
        'Catch ex As Exception

        'End Try
    End Sub

    Sub bind_ddl_money(ByVal type_req As Integer)
        'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUEST_AMOUNT
        'dao.GetDataby_TYPE_REQUESTS_ID(type_req)
        Dim bao_show As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao_show.SP_TYPE_REQUESTS_ID_BY_TYPE(type_req)
        ddl_amount.DataSource = dt
        ddl_amount.DataTextField = "AMOUNT"
        ddl_amount.DataValueField = "AMOUNT"
        ddl_amount.DataBind()
    End Sub
    Sub bine_text_sum()
        Dim raw_amount As Double = 0
        Dim persent As Double = 0
        Dim decrease_amount As Decimal = 0
        Dim summary_amount As Decimal = 0

        raw_amount = ddl_amount.SelectedValue
        persent = rtb_decrease.Text

        decrease_amount = (raw_amount * persent) / 100
        summary_amount = raw_amount - decrease_amount

        rtb_summary.Text = summary_amount

    End Sub

    Private Sub rtb_decrease_TextChanged(sender As Object, e As EventArgs) Handles rtb_decrease.TextChanged
        bine_text_sum()
    End Sub
    Sub alert_no_close(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'If CHK_FORMAT_RCVNO(Txt_rcvno_no.Text) = True Then
        Dim dao_rqt As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao_rqt.GetDatabyIDA(_IDA)
        Dim bao As New BAO.GenNumber 'test
        'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUEST_AMOUNT
        'Try
        '    dao.GetDataby_TYPE_REQUESTS_ID(dao_rqt.fields.TYPE_REQUEST_ID)
        'Catch ex As Exception

        'End Try
        Dim RCVNO As Integer

        RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
        'RCVNO = GET_FORMAT_RCVNO(Txt_rcvno_no.Text)
        dao_rqt.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

        dao_rqt.fields.STATUS_ID = 9
        Try
            dao_rqt.fields.rcvdate = CDate(txt_rcvdate.Text)
        Catch ex As Exception

        End Try
        Try
            dao_rqt.fields.A_NO = Txt_rcvno_temp.Text
        Catch ex As Exception

        End Try
        Try
            dao_rqt.fields.STAFF_IDEN_RECEIVE = txt_iden_staff.Text
        Catch ex As Exception

        End Try
        Try
            dao_rqt.fields.AMOUNT = ddl_amount.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao_rqt.fields.AMOUNT_CAL = rtb_summary.Text
        Catch ex As Exception

        End Try
        Try
            dao_rqt.fields.TYPE_REQUESTS_ID = ddl_req_type.SelectedValue
        Catch ex As Exception

        End Try
        Dim years As String = ""
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_tr.GetDataby_IDA(dao_rqt.fields.TR_ID)
        Try
            years = dao_tr.fields.YEAR

        Catch ex As Exception

        End Try
        Dim tr_id As String = ""
        tr_id = "DA-" & _ProcessID & "-" & years & "-" & _TR_ID

        dao_rqt.update()


        'Dim cls_sop As New CLS_SOP
        'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", _ProcessID, _CLS.PVCODE, 2, "ตรวจรับคำขอ", "SOP-DRUG-10-" & _ProcessID & "-5", "ชำระเงินค่าประเมินคำขอ", "รอชำระเงินค่าประเมินคำขอ", "STAFF", tr_id, SOP_STATUS:="ตรวจรับคำขอ")


        AddLogStatus(6, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
        alert("ตรวจรับคำขอแล้ว")
        'Else
        'alert_no_close("กรอกเลขรับไม่ถูกต้อง")
        'End If
    End Sub
    Function GET_FORMAT_RCVNO(ByVal txt As String) As Integer
        Dim rcvno As String = ""
        Dim running As Integer = 0
        Dim year_short As String = ""
        Dim split_text As String() = txt.Split("/")

        Try
            running = CInt(split_text(0))
            year_short = split_text(1)
            rcvno = String.Format("{0:00000}", running.ToString("00000"))
            rcvno = year_short & rcvno
        Catch ex As Exception

        End Try

        Return rcvno
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Function CHK_FORMAT_RCVNO(ByVal txt As String) As Boolean
        Dim bool As Boolean = True
        Try
            Dim split_text As String() = txt.Split("/")
            Dim len_1 As Integer = 0
            Dim len_2 As Integer = 0
            len_1 = Len(split_text(0))
            len_2 = Len(split_text(1))

            If len_2 < 2 Then
                Return False
            End If
            If len_2 > 2 Then
                Return False
            End If
            If len_1 < 1 Then
                Return False
            End If


        Catch ex As Exception
            bool = False
        End Try


        Return bool
    End Function
    Sub bind_ddl_rqt()
        'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
        'dao.GetData_TABEAN_Only()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_TYPE_REQUESTS_EDIT()
        ddl_req_type.DataSource = dt
        ddl_req_type.DataTextField = "TYPE_REQUESTS_NAME"
        ddl_req_type.DataValueField = "TYPE_REQUESTS_ID"
        ddl_req_type.DataBind()
    End Sub

    Private Sub ddl_amount_TextChanged(sender As Object, e As EventArgs) Handles ddl_amount.TextChanged
        bine_text_sum()
    End Sub

    Protected Sub btn_search_C_Click(sender As Object, e As EventArgs) Handles btn_search_C.Click
        Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
        dao.GetDataby_A(Txt_rcvno_temp.Text)
        Dim i As Integer = 0
        For Each dao.fields In dao.datas
            i += 1
        Next
        If i > 0 Then

            Try
                Dim dao_req As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                dao_req.GetDataby_type(dao.fields.TYPE_REQUESTS)
                ' ddl_WORK_GROUP.DropDownSelectData(dao_req.fields.NEW_WORK_GROUP)

            Catch ex As Exception

            End Try
            HiddenField1.Value = dao.fields.IDA
            Try
                txt_iden_staff.Text = dao.fields.STAFF_IDENTIFY
            Catch ex As Exception

            End Try
            Try
                lbl_staff_name.Text = set_name_company(txt_iden_staff.Text)
            Catch ex As Exception

            End Try
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If
    End Sub
    Private Sub ddl_req_type_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddl_req_type.SelectedIndexChanged
        bine_text_sum()
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "-"
        End Try

        Return fullname
    End Function

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        lbl_staff_name.Text = set_name_company(txt_iden_staff.Text)
    End Sub
End Class