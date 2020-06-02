Public Class TABEAN_YA_STAFF_RECEIVE
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
            txt_rcvdate.Text = Date.Now.ToShortDateString()
            bind_ddl_rgttpcd()
            bind_tabean_group()
            Try
                Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                dao_rg.GetDataby_IDA(_IDA)
                Dim dao_t As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                dao_t.GetDataby_CD(dao_rg.fields.TYPE_REQUEST_ID)
                lbl_request_name.Text = dao_t.fields.TYPE_REQUESTS_NAME
                'Try
                '    txt_rcvdate.Text = CDate(dao_rg.fields.rcvdate).ToShortDateString()
                'Catch ex As Exception

                'End Try

            Catch ex As Exception

            End Try
            'Try
            '    lbl_name_staff.Text = set_name_company(_CLS.CITIZEN_ID)
            'Catch ex As Exception
            '    lbl_name_staff.Text = ""
            'End Try
        End If
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
    Function CHK_REPEAT(ByVal rcvno As Integer, ByVal rgttpcd As String, ByVal drgtpcd As String) As Boolean
        Dim bool As Boolean = True
        Try
            Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
            dao_rqt.GET_MAX_RCVNO(Left(rcvno, 2), rgttpcd, drgtpcd)
            Dim max_rcvno As Integer = dao_rqt.fields.rcvno
            If max_rcvno = rcvno Then
                bool = False
            End If
        Catch ex As Exception
            bool = False
        End Try

        Return bool
    End Function
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
    Sub bind_tabean_group()
        'Dim dao As New DAO_DRUG.ClsDBdrdrgtype
        'dao.GetDataAll()
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
    Sub bind_ddl_rgttpcd()
        Dim sql As String = ""
        sql = "select * from dbo.DRRGT_DRUG_GROUP "
        Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
        dao_rqt.GetDataby_IDA(_IDA)
        Dim grptpcd As Integer = 0
        Dim subtpcd As Integer = 0
        Dim fk_lcn_ida As Integer = 0
        Try
            fk_lcn_ida = dao_rqt.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Dim dao_da As New DAO_DRUG.ClsDBdalcn
        dao_da.GetDataby_IDA(fk_lcn_ida)
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao_da.fields.lcntpcd
        Catch ex As Exception

        End Try
        If lcntpcd.Contains("บ") Then
            grptpcd = 2
        Else
            grptpcd = 1
        End If
        If lcntpcd.Contains("นย") Then
            subtpcd = 3
        End If
        Dim sql_where As String = ""
        sql_where = " where grptpcd=" & grptpcd
        If subtpcd = 3 Then
            sql_where &= " and subtpcd = 3"
        Else
            sql_where &= " and subtpcd <> 3"
        End If

        sql &= sql_where
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.Queryds(sql)

        ddl_rgttpcd.DataSource = dt
        ddl_rgttpcd.DataTextField = "rgttpcd"
        ddl_rgttpcd.DataValueField = "rgttpcd"
        ddl_rgttpcd.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_rgttpcd.Items.Insert(0, item)
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If CHK_FORMAT_RCVNO(Txt_rcvno_no.Text) = True Then
            If Chk_ddl() = 2 Then
                Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
                dao_rqt.GetDataby_IDA(_IDA)

                dao_rqt.fields.STATUS_ID = 5
                Dim bao2 As New BAO.GenNumber
                Dim RCVNO As Integer
                'RCVNO = bao2.GEN_NO_07(con_year(Date.Now.Year), _CLS.PVCODE, IIf(IsDBNull(dao_rqt.fields.lcnno), "", dao_rqt.fields.lcnno), dao_rqt.fields.PROCESS_ID, 0, 0, _IDA, "")
                'RCVNO = bao2.GEN_RCVNO_RGT(con_year(Date.Now.Year), _CLS.PVCODE, ddl_rgttpcd.SelectedValue, _IDA)

                RCVNO = GET_FORMAT_RCVNO(Txt_rcvno_no.Text)

                If CHK_REPEAT(RCVNO, ddl_rgttpcd.SelectedValue, ddl_tabean_group.SelectedValue) = True Then
                    dao_rqt.fields.rcvno = RCVNO
                    Try
                        dao_rqt.fields.rcvdate = CDate(txt_rcvdate.Text)
                    Catch ex As Exception

                    End Try
                    dao_rqt.fields.STAFF_RCV_IDENTIFY = txt_iden_staff.Text
                    dao_rqt.fields.drgtpcd = ddl_tabean_group.SelectedValue
                    dao_rqt.fields.rgtdrgtpcd = ddl_tabean_group.SelectedValue
                    dao_rqt.fields.rgttpcd = ddl_rgttpcd.SelectedValue
                    dao_rqt.update()
                    AddLogStatus(5, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                    'alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao_rqt.fields.rcvno)
                    alert("ดำเนินการรับคำขอเรียบร้อยแล้ว")

                Else
                    alert_only("เลขรับซ้ำ")
                End If
            Else
                alert_only("กรุณากรอกข้อมูลให้ครบถ้วน")
            End If


        Else
            alert_only("กรอกเลขรับไม่ถูกต้อง")
        End If

    End Sub
    Function Chk_ddl() As Integer
        Dim i As Integer = 0
        If ddl_rgttpcd.SelectedValue <> "" Then
            i += 1
        End If
        If ddl_tabean_group.SelectedValue <> "" Then
            i += 1
        End If
        Return i
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_only(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    'Protected Sub btn_search_C_Click(sender As Object, e As EventArgs) Handles btn_search_C.Click
    '    Dim bool As Boolean = chk_r_exist(Txt_rcvno_temp.Text)
    '    Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
    '    dao.get_data_by_rno(Txt_rcvno_temp.Text)
    '    If bool = True Then
    '        Try
    '            bind_ddl_WORK_GROUP()
    '            Try
    '                ddl_WORK_GROUP.DropDownSelectData(dao.fields.WORK_GROUP)
    '            Catch ex As Exception

    '            End Try
    '            ddl_type_req()
    '            Try
    '                ddl_category_requests.DropDownSelectData(dao.fields.TYPE_REQUEST)
    '            Catch ex As Exception

    '            End Try


    '            'ddl_WORK_GROUP.DropDownSelectData(dao.fields.WORK_GROUP)
    '            'ddl_type_req()
    '            'bind_addr()
    '        Catch ex As Exception

    '        End Try

    '        txt_company.Text = dao.fields.CITIZEN_AUTHIRIZE
    '        txt_citizen_id.Text = dao.fields.CITIZEN_ID
    '        txt_DRUG_NAME_THAI.Text = dao.fields.TRADENAME
    '        txt_DRUG_NAME_ENG.Text = dao.fields.TRADENAME_ENG
    '        lbl_company.Text = dao.fields.ALLOW_NAME
    '        txt_lcnno.Text = dao.fields.LCNNO_DISPLAY
    '        txt_product_id.Text = dao.fields.PRODUCT_ID
    '        HiddenField1.Value = dao.fields.IDA
    '        txt_Other_detail.Text = dao.fields.OTHER_DETAIL
    '        txt_TABEAN_NUMBER.Text = dao.fields.TABEAN_DISPLAY
    '        set_citizen()
    '        chk_company()
    '        Try
    '            ddl_category_requests.DropDownSelectData(dao.fields.TYPE_REQUEST)
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            ddl_placename.DropDownSelectData(dao.fields.FK_LOCATION_IDA)
    '        Catch ex As Exception

    '        End Try
    '    Else
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
    '    End If
    'End Sub

    Function chk_r_exist(ByVal r_no As String) As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        dao.get_data_by_rno(r_no)
        Dim i As Integer = 0
        For Each dao.fields In dao.datas
            i += 1
        Next
        If i > 0 Then
            bool = True
        End If
        Return bool
    End Function

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        lbl_staff_name.Text = set_name_company(txt_iden_staff.Text)
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
End Class