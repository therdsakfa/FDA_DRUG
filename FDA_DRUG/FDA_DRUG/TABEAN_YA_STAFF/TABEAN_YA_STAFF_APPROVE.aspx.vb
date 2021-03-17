Public Class TABEAN_YA_STAFF_APPROVE
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
           
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Try
            _ProcessID = Request.QueryString("Process")
            
        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")

        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            txt_rcvdate.Text = Date.Now.ToShortDateString()
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Try
                dt = bao.SP_DRRQT_BY_IDA(Request.QueryString("IDA"))
                lbl_rgtno.Text = dt(0)("rgtno_display")
            Catch ex As Exception

            End Try
            'bind_ddl_rgttpcd()
            'bind_tabean_group()
            'Try
            '    lbl_name_staff.Text = set_name_company(_CLS.CITIZEN_ID)
            'Catch ex As Exception
            '    lbl_name_staff.Text = ""
            'End Try
            Try
                'Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
                'dao_rqt.GetDataby_IDA(_IDA)
                'ddl_rgttpcd.DropDownSelectData(dao_rqt.fields.rgttpcd)
                'ddl_tabean_group.DropDownSelectData(dao_rqt.fields.drgtpcd)
            Catch ex As Exception

            End Try
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
            dao_rqt.GET_MAX_RGTNO(Left(rcvno, 2), rgttpcd, drgtpcd)
            Dim max_rcvno As Integer = dao_rqt.fields.rcvno
            If max_rcvno = rcvno Then
                bool = False
            End If
        Catch ex As Exception

        End Try

        Return bool
    End Function
  
    'Sub bind_tabean_group()
    '    Dim dao As New DAO_DRUG.ClsDBdrdrgtype
    '    dao.GetDataAll()
    '    ddl_tabean_group.DataSource = dao.datas
    '    ddl_tabean_group.DataTextField = "thadrgtpnm"
    '    ddl_tabean_group.DataValueField = "drgtpcd"
    '    ddl_tabean_group.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "--กรุณาเลือก--"
    '    item.Value = ""
    '    ddl_tabean_group.Items.Insert(0, item)
    'End Sub
    'Sub bind_ddl_rgttpcd()
    '    Dim sql As String = ""
    '    sql = "select * from dbo.DRRGT_DRUG_GROUP "
    '    Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
    '    dao_rqt.GetDataby_IDA(_IDA)
    '    Dim grptpcd As Integer = 0
    '    Dim subtpcd As Integer = 0
    '    Dim fk_lcn_ida As Integer = 0
    '    Try
    '        fk_lcn_ida = dao_rqt.fields.FK_LCN_IDA
    '    Catch ex As Exception

    '    End Try
    '    Dim dao_da As New DAO_DRUG.ClsDBdalcn
    '    dao_da.GetDataby_IDA(fk_lcn_ida)
    '    Dim lcntpcd As String = ""
    '    Try
    '        lcntpcd = dao_da.fields.lcntpcd
    '    Catch ex As Exception

    '    End Try
    '    If lcntpcd.Contains("บ") Then
    '        grptpcd = 2
    '    Else
    '        grptpcd = 1
    '    End If
    '    If lcntpcd.Contains("นย") Then
    '        subtpcd = 3
    '    End If
    '    Dim sql_where As String = ""
    '    sql_where = " where grptpcd=" & grptpcd
    '    If subtpcd = 3 Then
    '        sql_where &= " and subtpcd = 3"
    '    Else
    '        sql_where &= " and subtpcd <> 3"
    '    End If

    '    sql &= sql_where
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao.Queryds(sql)

    '    ddl_rgttpcd.DataSource = dt
    '    ddl_rgttpcd.DataTextField = "rgttpcd"
    '    ddl_rgttpcd.DataValueField = "rgttpcd"
    '    ddl_rgttpcd.DataBind()

    '    Dim item As New ListItem
    '    item.Text = "--กรุณาเลือก--"
    '    item.Value = ""
    '    ddl_rgttpcd.Items.Insert(0, item)
    'End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'If CHK_FORMAT_RCVNO(Txt_rcvno_no.Text) = True Then

        Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
        dao_rqt.GetDataby_IDA(_IDA)

        dao_rqt.fields.STATUS_ID = 8
        'Dim bao2 As New BAO.GenNumber
        'Dim RGTNO As Integer

        'RGTNO = GET_FORMAT_RCVNO(Txt_rcvno_no.Text)

        'If CHK_REPEAT(RGTNO, ddl_rgttpcd.SelectedValue, ddl_tabean_group.SelectedValue) = True Then
        'dao_rqt.fields.rgtno = RGTNO
        Try
            dao_rqt.fields.appdate = CDate(txt_rcvdate.Text)
            dao_rqt.fields.FIRST_APP_DATE = CDate(txt_rcvdate.Text)

        Catch ex As Exception

        End Try
        Try
            dao_rqt.fields.SIGN_IDENTIFY = txt_iden_staff.Text
        Catch ex As Exception

        End Try
        Try
            dao_rqt.fields.SIGN_NAME = lbl_staff_name.Text
        Catch ex As Exception

        End Try
        dao_rqt.fields.STAFF_APP_IDENTIFY = _CLS.CITIZEN_ID

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

        Dim cls_sop As New CLS_SOP
        cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", _ProcessID, _CLS.PVCODE, 8, "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "SOP-DRUG-10-" & _ProcessID & "-13", "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "STAFF", tr_id, SOP_STATUS:="อนุญาตให้แก้ไขเปลี่ยนแปลงฯ")

        AddLogStatus(8, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
        'alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao_rqt.fields.rcvno)
        Dim bao_insert As New BAO.ClsDBSqlcommand
        bao_insert.insert_tabean_sub(_IDA)


        If dao_rqt.fields.TRANSFER_TYPE IsNot Nothing Then
            If dao_rqt.fields.TRANSFER_TYPE = 2 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(dao_rqt.fields.FK_TRANSFER)
                dao_rg.fields.cnccd = 2
                dao_rg.fields.cncdate = CDate(txt_rcvdate.Text)
                dao_rg.fields.cnccscd = 68
                dao_rg.update()

                'Try
                '    Dim ws_drug1 As New WS_DRUG.WS_DRUG
                '    ws_drug1.DRUG_UPDATE_DR(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, "เจ้าหน้าที่กดอนุมัติทะเบียนทรานสเฟอร์ ต้องทำการยกเลิกทะเบียนเดิม", _CLS.CITIZEN_ID, "DRUG")

                'Catch ex As Exception

                'End Try
                'AddLogStatus(77, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                Try
                    Dim ws_drug126 As New WS_DRUG_126.WS_DRUG
                    ws_drug126.UPDATE_TRANFERS_DR(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, "เจ้าหน้าที่กดอนุมัติทะเบียนทรานสเฟอร์ ต้องทำการยกเลิกทะเบียนเดิม", _CLS.CITIZEN_ID, "DRUG")
                Catch ex As Exception

                End Try
            ElseIf dao_rqt.fields.TRANSFER_TYPE = 4 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(dao_rqt.fields.FK_TRANSFER)
                dao_rg.fields.cnccd = 4
                dao_rg.fields.cncdate = CDate(txt_rcvdate.Text)
                'dao_rg.fields.cnccscd = 68
                dao_rg.update()
                Try
                    Dim ws_drug126 As New WS_DRUG_126.WS_DRUG
                    ws_drug126.UPDATE_SMP_DR_126(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, "เจ้าหน้าที่กดอนุมัติทะเบียนทรานสเฟอร์ ต้องทำการยกเลิกทะเบียนเดิม", _CLS.CITIZEN_ID, "DRUG")
                Catch ex As Exception

                End Try
            End If

        End If

        'Try
        '    Dim ws_drug As New WS_DRUG.WS_DRUG
        '    ws_drug.DRUG_INSERT_DR(dao_rqt.fields.pvncd, dao_rqt.fields.rgttpcd, dao_rqt.fields.drgtpcd, dao_rqt.fields.rgtno, "อนุมัติทะเบียน", _CLS.CITIZEN_ID, "DRUG")
        'Catch ex As Exception

        'End Try

        Try
            Dim ws_drug111 As New WS_DRUG_126.WS_DRUG
            ws_drug111.DRUG_INSERT_DR_126(dao_rqt.fields.pvncd, dao_rqt.fields.rgttpcd, dao_rqt.fields.drgtpcd, dao_rqt.fields.rgtno, "อนุมัติทะเบียน", _CLS.CITIZEN_ID, "DRUG")
        Catch ex As Exception

        End Try

        alert("อนุมัติคำขอเรียบร้อยแล้ว")

        'Else
        'alert_only("เลขทะเบียนซ้ำ")
        'End If

        'Else
        'alert_only("กรอกเลขไม่ถูกต้อง")
        'End If


        'Dim rgttpcd As String = ""
        'Try
        '    rgttpcd = dao.fields.rgttpcd
        'Catch ex As Exception

        'End Try

        'Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        'dao_p.GetDataby_Process_ID(_ProcessID)
        'Dim CONSIDER_DATE As Date = CDate(txt_appdate.Text)

        ''--------------------------------
        'Dim chw As String = ""
        'Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
        'Try
        '    dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
        '    chw = dao_cpn.fields.thacwabbr
        'Catch ex As Exception

        'End Try
        'Dim bao2 As New BAO.GenNumber
        'Dim LCNNO As Integer
        'LCNNO = bao2.GEN_RGTNO(con_year(Date.Now.Year), _CLS.PVCODE, rgttpcd, _IDA)
        'dao.fields.rgtno = LCNNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year), LCNNO)
        ''---------------------------------------
        'dao.fields.STATUS_ID = 8
        'dao.fields.CONSIDER_DATE = CONSIDER_DATE
        'Try
        '    dao.fields.appdate = CDate(txt_appdate.Text)
        'Catch ex As Exception

        'End Try
        'dao.update()
        '
        'alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
    End Sub
    
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_only(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        lbl_staff_name.Text = set_name_company(txt_iden_staff.Text)
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
End Class