Public Class FRM_RGT_EDIT_STAFF_RECEIVE
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
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
            bind_ddl_rqt()
            txt_rcvdate.Text = Date.Now.ToShortDateString()
            'bind_ddl_rgttpcd()
            'bind_tabean_group()
            Try
                Dim dao_rg As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                dao_rg.GetDatabyIDA(_IDA)
                'Dim dao_t As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                'dao_t.GetDataby_CD(dao_rg.fields.TYPE_REQUEST_ID)
                ddl_req_type.SelectedValue = dao_rg.fields.TYPE_REQUESTS_ID

            Catch ex As Exception

            End Try

        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim bao As New BAO.GenNumber 'test
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(_IDA)

        'Dim STATUS_ID As Integer = ddl_status.SelectedItem.Value
        Dim RCVNO As Integer

        dao.fields.STATUS_ID = 5
        RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
        dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)


        'dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
        Try
            dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try
        Try
            dao.fields.STAFF_IDEN_RECEIVE = txt_iden_staff.Text
        Catch ex As Exception

        End Try
        Try
            dao.fields.TYPE_REQUESTS_ID = ddl_req_type.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.A_NO = Txt_rcvno_temp.Text
        Catch ex As Exception

        End Try
        'dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
        dao.update()
        AddLogStatus(5, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
        '-----------------ลิ้งไปหน้าคีย์มือ----------
        'Response.Redirect("FRM_STAFF_LCN_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)



        'Try
        '    Dim dao_rgt As New DAO_DRUG.ClsDBdrrgt
        '    dao_rgt.GetDataby_IDA(dao.fields.FK_IDA)
        '    If dao_rgt.fields.TR_ID Is Nothing Then
        '        GEN_TR_ID(dao_rgt.fields.IDA, dao_rgt.fields.IDENTIFY)
        '    End If
        'Catch ex As Exception

        'End Try

        'update_rgt()

        ''--------------------------------
        'alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO))


        'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_tr.GetDataby_IDA(_TR_ID)
        'AddLogStatus(8, dao_tr.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
        'alert("เลขรับ คือ " & bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)) 'test
        alert("ดำเนินการรับคำขอเรียบร้อยแล้ว")
    End Sub

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
            Try
                ddl_req_type.SelectedValue = dao.fields.TYPE_REQUESTS
            Catch ex As Exception

            End Try
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If
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
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        lbl_staff_name.Text = set_name_company(txt_iden_staff.Text)
    End Sub

   
End Class