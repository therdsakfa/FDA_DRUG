Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_STAFF_EDIT_LOCATION_CONFIRM_PREVIEW
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _process As String
    Private _YEARS As String
    Private _TR_ID As String
    Private x As Integer
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _IDA = Request.QueryString("IDA")
        _process = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'show_panel()


        If Not IsPostBack Then
            'txt_app_date.Text = Date.Now.ToShortDateString()
            HiddenField2.Value = 0
            BindData_PDF()
            Bind_ddl_Status_staff()
            load_fdpdtno()
            'UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _process)
            set_hide(_IDA)
            set_lbl()
            show_btn(_IDA)
            Dim check As New DAO_DRUG.TB_LCN_EXTEND_LITE
            check.GetDataby_IDA(_IDA)
            txt_appdate.Text = Date.Now.ToShortDateString()
            Try
                txt_appdate.Text = CDate(check.fields.app_date).ToString()
            Catch ex As Exception

            End Try
            'Me.chk1.Enabled = False
            'Me.chk2.Enabled = False
            'Me.chk3.Enabled = False
            'Me.chk4.Enabled = False
            'Me.chk5.Enabled = False
            'If check.fields.lcntpcd = "ขย1" Then 'ขายปลีก
            '    chk1.Checked = True
            '    Try
            '        If check.fields.SALE_MEDICIAN2 = "2" Then
            '            chk2.Checked = True
            '        Else
            '            chk2.Checked = False
            '        End If
            '        If check.fields.SALE_MEDICIAN3 = "3" Then
            '            chk3.Checked = True
            '        Else
            '            chk3.Checked = False
            '        End If

            '    Catch ex As Exception

            '    End Try

            'ElseIf check.fields.lcntpcd = "ขย4" Then
            '    Try
            '        If check.fields.SALE_MEDICIAN1 = "1" Then
            '            chk4.Checked = True
            '        Else
            '            chk4.Checked = False
            '        End If
            '        If check.fields.SALE_MEDICIAN2 = "2" Then
            '            chk5.Checked = True
            '        Else
            '            chk5.Checked = False
            '        End If

            '        'ElseIf check.fields.SALE_MEDICIAN3 = "3" Then
            '        '    chk3.Checked = True
            '    Catch ex As Exception

            '    End Try
            'End If


            'Try
            '    Dim dao As New DAO_DRUG.TB_lcnrequest
            '    dao.GetDataby_IDA(_IDA)
            '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            '    dao_up.GetDataby_IDA(dao.fields.TR_ID)
            '    If dao_up.fields.PROCESS_ID = "100741" Then
            '        btn_drug_group.Style.Add("display", "block")
            '    End If
            'Catch ex As Exception

            'End Try
            If check.fields.STATUS_ID > 4 Then
                Try
                    lbl_Status3.Text = set_name_company(check.fields.RCV_CITIZEN)
                Catch ex As Exception
                    lbl_Status3.Text = ""
                End Try
            End If

            If check.fields.STATUS_ID = 9 Or check.fields.STATUS_ID = 10 Then
                Try
                    lbl_Status0.Text = set_name_company(check.fields.OFF_CITIZEN)
                Catch ex As Exception
                    lbl_Status0.Text = ""
                End Try
            End If
            If check.fields.STATUS_ID = 8 Then
                Try
                    lbl_Status0.Text = set_name_company(check.fields.OFF_CITIZEN)
                    lbl_Status1.Text = set_name_company(check.fields.ALLOW_CITIZEN)
                Catch ex As Exception
                    lbl_Status1.Text = ""
                End Try
            End If
            If check.fields.STATUS_ID = 7 Then
                Try
                    lbl_Status2.Text = set_name_company(check.fields.RESPON_CITIZEN)
                Catch ex As Exception
                    lbl_Status2.Text = ""
                End Try
            End If

        End If


    End Sub
    'Public Sub show_panel()
    '    Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
    '    dao.GetDataby_IDA(_IDA)
    '    If dao.fields.lcntpcd = "ขย1" Then
    '        Panel1.Style.Add("display", "block")
    '    ElseIf dao.fields.lcntpcd = "ขย4" Then
    '        Panel2.Style.Add("display", "block")
    '    Else

    '    End If
    'End Sub

    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID = 9 Then
            Me.Label1.Visible = True
            Me.ddl_permiss.Visible = True

            '    ' btn_cancel.Enabled = False
            '    btn_preview.CssClass = "btn-danger btn-lg"
            '    'btn_preview.CssClass = "btn-danger btn-lg"
            ' End If
            'If dao.fields.STATUS_ID <> 8 Then
            '    btn_preview.Enabled = False
            'End If
        ElseIf dao.fields.STATUS_ID = 8 Then
            Me.lbl_permiss.Visible = True
        End If


    End Sub
    Public Sub set_hide(ByVal IDA As String)
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 5 Or dao.fields.STATUS_ID < 4 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"

            ddl_cnsdcd.Style.Add("display", "none")
        End If

        'Try
        '    Dim dao_u As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        '    dao_u.GetDataby_IDA(_TR_ID)
        '    If dao_u.fields.PROCESS_ID = "104" Then
        '        ddl_template.Style.Add("display", "block")
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    Sub set_lbl()
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(_IDA)

        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        Try
            dao_s.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
            '    lbl_staff_consider.Text = dao_s.fields.STAFF_OFFER_NAME
            'Catch ex As Exception
            '    lbl_staff_consider.Text = "-"
            'End Try
            'Try
            '    lbl_app_date.Text = CDate(dao.fields.app_date).ToShortDateString()
            'Catch ex As Exception
            '    lbl_app_date.Text = "-"
            'End Try
            'Try
            '    lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
        Catch ex As Exception

        End Try

        Try
            dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 9)
            lbl_Status.Text = dao_stat.fields.STATUS_NAME
        Catch ex As Exception

        End Try
        lbl_permiss.Text = dao.fields.EXTEND
    End Sub
    Sub load_fdpdtno()
        Dim bao As New BAO.ClsDBSqlcommand
        'lbl_fdpdtno.Text = get_fdpdtno().Substring(0, 2) & "-" & get_fdpdtno().Substring(2, 1) & "-" & get_fdpdtno().Substring(3, 5) & "-" & get_fdpdtno().Substring(8, 1) & "-"
        'lbl_fdpdtno2.Text = _CLS.IDA    'ปรับให้runno

    End Sub
    Function get_fdpdtno() As String
        Dim fdpdtno As String = String.Empty
        Dim pvncd As String = String.Empty
        Dim lcntypecd As String = String.Empty
        Dim lcnno_num As String = String.Empty
        Dim tpye As String = String.Empty
        Dim REF_NO As String = String.Empty
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        Dim bao As New BAO.ClsDBSqlcommand
        If Len(_TR_ID) >= 9 Then
            dao_up.GetDataby_TR_ID_Process(_TR_ID, _process)
        Else
            dao_up.GetDataby_IDA(_TR_ID)
        End If
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        'pvncd = dao.fields.pvncd.ToString()
        lcntypecd = dao.fields.lcntpcd.ToString()
        lcnno_num = dao.fields.lcnno.ToString().Trim().Substring(7, 5)
        If _CLS.PVCODE = 10 Then
            If lcntypecd = "1" Then
                tpye = "1"
            ElseIf lcntypecd = "2" Then
                tpye = "3"
            End If
        Else
            If lcntypecd = "1" Then
                tpye = "2"
            ElseIf lcntypecd = "2" Then
                tpye = "4"
            End If
        End If
        fdpdtno = pvncd & lcntypecd & lcnno_num & tpye
        Return fdpdtno
    End Function

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim fdpdtno As String = String.Empty
        'Dim num As Integer = 0
        'Dim str_num As String = String.Empty

        'Dim bao_gen As New BAO.GenNumber
        'Dim rcvno As String = ""

        'rcvno = bao_gen.GEN_LCNNO_RCVNO(_IDA, _CLS.PVCODE, 0)
        ''str_num = String.Format("{0:0000}", num.ToString("0000"))
        ''fdpdtno = str_num
        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(_TR_ID)
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        'dao.fields.lcnno = rcvno 'fdpdtno
        'dao.fields.STATUS_ID = Integer.Parse(ddl_cnsdcd.SelectedItem.Value())
        'dao.fields.cnccd = 1
        'dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        'dao.update()
        'Dim xmlname As String = NAME_OUTPUT_PDF("DA", _ProcessID, dao_up.fields.YEAR, dao_up.fields.ID)
        'BindData_PDF()
        'alert("ยืนยันเรียบร้อยแล้ว")
        Dim ws As New AUTHEN_LOG.Authentication

        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(_TR_ID)
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)

        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        Dim dao_location As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_process As New DAO_DRUG.ClsDBPROCESS_NAME
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer

        dao.GetDataby_IDA(_IDA)
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)
        If Len(_TR_ID) >= 9 Then
            dao_up.GetDataby_TR_ID_Process(_TR_ID, _process)
        Else
            dao_up.GetDataby_IDA(_TR_ID)
        End If
        dao_process.GetDataby_Process_ID(_process)
        Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = dao.fields.FK_IDA
        Try
            dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 9 'ใบอนุญาต ขย ต่างๆ
        dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.fields.PROCESS_ID = dao.fields.PROCESS_ID
        dao_date.insert()


        If STATUS_ID = 8 Then
            If ddl_permiss.Text = "" Then
                alert_reload("กรุณาเลือกครั้งที่ต่ออายุ")
            Else

                dao.fields.STATUS_ID = STATUS_ID
                dao_dal.GetDataby_IDA(dao.fields.FK_IDA)
                Try
                    dao_location.GetDataby_FK_IDA(dao_dal.fields.IDA)
                    If dao.fields.MAP_X IsNot Nothing And dao.fields.MAP_X <> "" Then
                        dao_location.fields.latitude = dao.fields.MAP_X
                    End If
                    If dao.fields.MAP_Y IsNot Nothing And dao.fields.MAP_Y <> "" Then
                        dao_location.fields.longitude = dao.fields.MAP_Y
                    End If
                    dao_location.update()
                Catch ex As Exception

                End Try
                dao_dal.fields.expyear = dao.fields.extend_year
                dao_dal.fields.cnccd = Nothing
                dao_dal.fields.cnccscd = Nothing

                dao_dal.update()

                Try
                    Dim ws_update As New WS_DRUG.WS_DRUG
                    ws_update.DRUG_UPDATE_LICEN(dao_dal.fields.IDA, _CLS.CITIZEN_ID)
                Catch ex As Exception

                End Try
                Try
                    dao.fields.app_date = CDate(txt_appdate.Text)
                Catch ex As Exception

                End Try
                Try
                    send_mail_mini2(dao.fields.MOBILE, "FDATH", "คำขอ เลขดำเนินการที่ " & dao.fields.TR_ID & " ได้รับการอนุมัติคำขอแล้ว")
                Catch ex As Exception

                End Try

                '  dao.fields.ALLOW_CITIZEN = _CLS.CITIZEN_ID
                dao.update()



                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("POPUP_EXTEND_TIME_LOCATION_STAFF_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                '--------------------------------
                alert("อนุมัติคำขอเรียบร้อยแล้ว")
                AddLogStatusEtracking(8, 0, _CLS.CITIZEN_ID, "อนุมัติคำขอระบบต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
                'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "อนุมัติคำขอระบบต่ออายุ", _process)
            End If
        ElseIf STATUS_ID = 9 Then
            Response.Redirect("POPUP_EXTEND_TIME_LOCATION_STAFF_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_Process_ID(PROCESS_ID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID
            Dim bao2 As New BAO.GenNumber
            Dim LCNNO As Integer
            'Dim sao As New DAO_DRUG.TB_LCN_EXTEND_LITE
            'sao.GetDataby_IDA(_IDA)

            LCNNO = bao2.GEN_NO_01(con_year(Date.Now.Year), _CLS.PVCODE, GROUP_NUMBER, PROCESS_ID, 0, 0, _IDA, "")
            'dao.fields.lcnno = LCNNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year), LCNNO)
            dao.fields.STATUS_ID = STATUS_ID
            Dim dao_citi As New DAO_CPN.clsDBsyslcnsnm
            dao_citi.GetDataby_identify(_CLS.CITIZEN_ID)
            dao.fields.OFF_CITIZEN = _CLS.CITIZEN_ID
            dao.fields.OFFICER_NAME = set_name_company(_CLS.CITIZEN_ID)
            dao.update()
            alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
            AddLogStatusEtracking(9, 0, _CLS.CITIZEN_ID, "ยื่นเสนอลงนามคำขอระบบต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)

            ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นเสนอลงนามคำขอระบบต่ออายุ", _process)
            'Dim chw As String = ""
            'Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            'Try
            '    dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
            '    chw = dao_cpn.fields.thacwabbr
            'Catch ex As Exception

            'End Try
            'If chw <> "" Then
            '    dao.fields.LCNNO_DISPLAY = chw & " " & bao.FORMAT_NUMBER_YEAR_FULL(con_year(Date.Now.Year), LCNNO) ' & " (ขย." & GROUP_NUMBER & ")"
            'Else
            '    dao.fields.LCNNO_DISPLAY = bao.FORMAT_NUMBER_YEAR_FULL(con_year(Date.Now.Year), LCNNO) ' & " (ขย." & GROUP_NUMBER & ")"
            'End If

            '-----------------ลิ้งไปหน้าคีย์มือ----------
            'Response.Redirect("FRM_STAFF_LCN_LCNNO_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            '--------------------------------

            'alert_reload("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        ElseIf STATUS_ID = 7 Then
            Response.Redirect("POPUP_EXTEND_TIME_LOCATION_STAFF_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
            AddLogStatusEtracking(7, 0, _CLS.CITIZEN_ID, "ยกเลิกคำขอระบบต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
            ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยกเลิกคำขอระบบต่ออายุ", _process)
            'dao.fields.RESPON_CITIZEN = _CLS.CITIZEN_ID
            ''_TR_ID = Request.QueryString("TR_ID")
            ''_IDA = Request.QueryString("IDA")
            'dao.update()
            'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        ElseIf STATUS_ID = 5 Then
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 5
            dao.update()
            AddLogStatusEtracking(5, 0, _CLS.CITIZEN_ID, "คืนให้แก้ไขคำขอระบบต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
            ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "คืนให้แก้ไขคำขอระบบต่ออายุ", _process)
            Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
        ElseIf STATUS_ID = 10 Then
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 10
            dao.fields.RCV_CITIZEN = _CLS.CITIZEN_ID
            dao.fields.RCV_NAME = set_name_company(_CLS.CITIZEN_ID)
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            dao.fields.rcvno = RCVNO
            bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)


            dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
            Try
                send_mail_mini2(dao.fields.MOBILE, "FDATH", "เจ้าหน้าที่รับคำขอ เลขดำเนินการที่ " & dao.fields.TR_ID & " แล้ว")
            Catch ex As Exception

            End Try
            dao.update()
            alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.RCVNO_DISPLAY)
            AddLogStatusEtracking(5, 0, _CLS.CITIZEN_ID, "รับคำขอแล้วรอการตรวจสอบ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
            ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "รับคำขอแล้วรอการตรวจสอบ", _process)
            Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
        End If



    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")

        Dim dao_n As New DAO_DRUG.ClsDBdalcn
        dao_n.GetDataby_IDA(_IDA)
        Try
            If dao_n.fields.SEND_POST = 1 Then
                '  Label2.Text = "รับด้วยตัวเอง"
            ElseIf dao_n.fields.SEND_POST = 2 Then
                '   Label2.Text = "ส่งไปรษณีย์"
            Else
                '   Label2.Text = "รับด้วยตัวเอง"
            End If
        Catch ex As Exception

        End Try

        Bind_ddl_Status_staff()
        BindData_PDF()
    End Sub

    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(_IDA)

        'If dao.fields.STATUS_ID <= 2 Then
        '    int_group_ddl = 11
        If dao.fields.STATUS_ID = 4 Then
            int_group_ddl = 55

        ElseIf dao.fields.STATUS_ID = 6 Or dao.fields.STATUS_ID >= 9 Then
            int_group_ddl = 33



        End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL1(9, int_group_ddl, dao.fields.STATUS_ID)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดPDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดPDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดPDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดPDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        load_pdf(HiddenField1.Value)
        Dim clsds As New ClassDataset

        'Response.Clear()
        'Response.ContentType = "Application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        'Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

        'Response.Flush()
        'Response.Close()
        'Response.End()
    End Sub

    Sub load_pdf(ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")

            Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

        Catch ex As Exception

        Finally

            Response.Flush()
            Response.Close()
            Response.End()
        End Try

    End Sub
    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        'UC_CONFIRM.load_SORBOR5(p2)
    End Sub
    '''' <summary>
    '''' รวม XML เข้าไปที่ PDF จดทะเบียน
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF_Output(ByVal filename As String)
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & "PDFdalcn_output_5.pdf") 'C:\path\PDF_TEMPLATE\
    '        Using outputStream = New FileStream(bao._PATH_PDF_TRADER & filename & "-output.pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset


    'End Sub

    Private Sub BindData_PDF(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao_lcnre As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao_lcnre.GetDataby_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao_lcnre.fields.FK_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(dao_lcnre.fields.TR_ID)
        If Len(_TR_ID) >= 9 Then
            dao_up.GetDataby_TR_ID_Process(_TR_ID, _process)
        Else
            dao_up.GetDataby_IDA(_TR_ID)
        End If
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim pvncd As String = ""
        Try
            lcnno_text = dao_lcn.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao_lcn.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim ProcessID = dao_up.fields.PROCESS_ID
        Try
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        'Try
        '    pvncd = dao.fields.pvncd
        'Catch ex As Exception

        'End Try
        Dim cls_dalcn As New CLASS_GEN_XML.EXTEND(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid, dao_lcnre.fields.lcnno, dao_lcnre.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcnre.fields.FK_IDA, dao_lcn.fields.FK_IDA, _IDA)

        Dim class_xml As New CLASS_EXTEND
        class_xml = cls_dalcn.gen_xml()
        class_xml.LCN_EXTEND_LITEs = dao_lcnre.fields
        extend = class_xml
        'p_lcnre = class_xml

        Dim bao_show As New BAO_SHOW
        class_xml.EXP_NEWYEAR = dao_lcnre.fields.extend_year
        class_xml.DT_SHOW.DT9 = bao_show.SP_GETDATA_EXTENDPDF_by_IDA(_IDA)

        class_xml.DT_SHOW.DT10 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao_lcn.fields.FK_IDA) 'bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
        class_xml.DT_SHOW.DT24 = bao_show.SP_DRUG_GROUP_BY_LCN_IDA(dao_lcn.fields.FK_IDA)

        class_xml.EXP_NEWYEAR = dao_lcnre.fields.extend_year 'ต่ออายุใบอนุญาติ
        class_xml.DT_SHOW.DT9 = bao_show.SP_GETDATA_EXTENDPDF_by_IDA(_IDA)

        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_lcn.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก

        class_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        Try
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao_lcn.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        Dim DT13 As New DataTable
        Try
            'DT13 = class_xml.DT_SHOW.DT13
            'For Each drr As DataRow In class_xml.DT_SHOW.DT13.Rows
            '    Try
            '        drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("fulladdr") = NumEng2Thai(drr("fulladdr"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("tharoom") = NumEng2Thai(drr("tharoom"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("thamu") = NumEng2Thai(drr("thamu"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("thafloor") = NumEng2Thai(drr("thafloor"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("thasoi") = NumEng2Thai(drr("thasoi"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("tharoad") = NumEng2Thai(drr("tharoad"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("zipcode") = NumEng2Thai(drr("zipcode"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("tel") = NumEng2Thai(drr("tel"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("fax") = NumEng2Thai(drr("fax"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("Mobile") = NumEng2Thai(drr("Mobile"))
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
            '    Catch ex As Exception

            '    End Try
            'Next
        Catch ex As Exception

        End Try
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"


        Dim MAIN_LCN_IDA As Integer = 0

        Try
            MAIN_LCN_IDA = dao_lcn.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        Dim BSN_IDENTIFY As String = ""
        Dim BSN_IDENTIFY_yoi As String = ""
        'Try

        '    BSN_IDENTIFY = NumEng2Thai(dao_lcn.fields.BSN_IDENTIFY)
        'Catch ex As Exception

        'End Try

        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน
        Dim dt14 As New DataTable
        Try

            'For Each drr As DataRow In class_xml.DT_SHOW.DT14.Rows
            '    drr("BSN_IDENTIFY") = NumEng2Thai(drr("BSN_IDENTIFY"))
            '    Try
            '        drr("BSN_HOUSENO") = NumEng2Thai(drr("BSN_HOUSENO"))
            '    Catch ex As Exception

            '    End Try
            'Next
        Catch ex As Exception

        End Try

        'End If
        Dim bao_cpn As New BAO.ClsDBSqlcommand
        Try
            class_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
            class_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"
        Catch ex As Exception

        End Try

        Try
            class_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_lcn.fields.CITIZEN_ID_AUTHORIZE)
            'For Each dr As DataRow In class_xml.DT_SHOW.DT16.Rows
            '    dr("tel") = NumEng2Thai(dr("tel"))
            'Next
            class_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"
        Catch ex As Exception

        End Try




        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao_lcn.fields.IDA)

        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao_lcn.fields.IDA)

        'Dim DT24 As New DataTable
        'Try
        '    DT24 = class_xml.DT_MASTER.DT24
        '    For Each drr As DataRow In DT24.Rows
        '        Try
        '            drr("thanameplace2") = NumEng2Thai(drr("thanameplace2"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("thaaddr") = NumEng2Thai(drr("thaaddr"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("tharoom") = NumEng2Thai(drr("tharoom"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("thamu") = NumEng2Thai(drr("thamu"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("thafloor") = NumEng2Thai(drr("thafloor"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("thasoi") = NumEng2Thai(drr("thasoi"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("thabuilding") = NumEng2Thai(drr("thabuilding"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("tharoad") = NumEng2Thai(drr("tharoad"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("zipcode") = NumEng2Thai(drr("zipcode"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("tel") = NumEng2Thai(drr("tel"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("fax") = NumEng2Thai(drr("fax"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("Mobile") = NumEng2Thai(drr("Mobile"))
        '        Catch ex As Exception

        '        End Try
        '        Try
        '            drr("thachngwtnm") = NumEng2Thai(drr("thachngwtnm"))
        '        Catch ex As Exception

        '        End Try
        '    Next

        '    class_xml.DT_MASTER.DT24 = DT24
        'Catch ex As Exception

        'End Try


        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao_lcn.fields.IDA)

        'Dim DT25 As New DataTable
        'Try
        '    DT25 = class_xml.DT_MASTER.DT25
        '    For Each drr As DataRow In DT25.Rows
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '        '
        '    Next
        'Catch ex As Exception

        'End Try

        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao_lcn.fields.IDA, 1)
        'Dim DT26 As New DataTable
        'Try
        '    DT26 = class_xml.DT_MASTER.DT26
        '    For Each drr As DataRow In DT26.Rows
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Next
        'Catch ex As Exception

        'End Try

        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao_lcn.fields.IDA, 2)
        'Dim DT27 As New DataTable
        'Try
        '    DT27 = class_xml.DT_MASTER.DT27
        '    For Each drr As DataRow In DT27.Rows
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Next
        'Catch ex As Exception

        'End Try
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao_lcn.fields.IDA, 1)
        'Dim DT28 As New DataTable
        'Try
        '    DT28 = class_xml.DT_MASTER.DT28
        '    For Each drr As DataRow In DT28.Rows
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Next
        'Catch ex As Exception

        'End Try

        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao_lcn.fields.IDA, 2)
        'Dim DT29 As New DataTable
        'Try
        '    DT29 = class_xml.DT_MASTER.DT29
        '    For Each drr As DataRow In DT29.Rows
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Next
        'Catch ex As Exception

        'End Try
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao_lcn.fields.IDA)

        Dim DT31 As New DataTable

        DT31 = class_xml.DT_MASTER.DT31
        'For Each drr As DataRow In DT31.Rows
        '    Try
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '    Catch ex As Exception

        '    End Try

        'Next

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao_lcn.fields.IDA, 3)
        Dim DT34 As New DataTable
        'Try
        '    DT34 = class_xml.DT_MASTER.DT34
        '    For Each drr As DataRow In DT34.Rows
        '        drr("PHR_CTZNO") = NumEng2Thai(drr("PHR_CTZNO"))
        '        drr("PHR_TEXT_NUM") = NumEng2Thai(drr("PHR_TEXT_NUM"))
        '        drr("PHR_TEXT_WORK_TIME") = NumEng2Thai(drr("PHR_TEXT_WORK_TIME"))
        '        drr("PHR_CERTIFICATE_TRAINING1") = NumEng2Thai(drr("PHR_CERTIFICATE_TRAINING1"))
        '    Next
        'Catch ex As Exception

        'End Try
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"

        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try

        'ขย15
        If dao_lcn.fields.lcntpcd = "ขย1" Then
            class_xml.CHK_TYPE = 1
            class_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย2" Then
            class_xml.CHK_TYPE = 3
            class_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย3" Then
            class_xml.CHK_TYPE = 4
            class_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย4" Then
            class_xml.CHK_TYPE = 2
            class_xml.CHK_NAME = "ขายส่งยาแผนปัจจุบันฯ"

            'ยบ13
        ElseIf dao_lcn.fields.lcntpcd = "ผยบ" Then
            class_xml.CHK_TYPE = 1
        ElseIf dao_lcn.fields.lcntpcd = "นยบ" Then
            class_xml.CHK_TYPE = 3
        ElseIf dao_lcn.fields.lcntpcd = "ขยบ" Then
            class_xml.CHK_TYPE = 2

            'สมพ
        ElseIf dao_lcn.fields.lcntpcd = "ผสม" Then
            class_xml.CHK_TYPE = 1
        ElseIf dao_lcn.fields.lcntpcd = "นสม" Then
            class_xml.CHK_TYPE = 3
        ElseIf dao_lcn.fields.lcntpcd = "ขสม" Then
            class_xml.CHK_TYPE = 2
        End If

        Dim statusId As Integer = dao_lcnre.fields.STATUS_ID
        Dim lcntype As String = dao_lcnre.fields.lcntpcd

        If statusId < 5 Then
            statusId = 5
        End If
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE2(_process, statusId, 0)

        'Try
        '    Dim rcvdate As Date = dao.fields.rcvdate
        '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
        '    class_xml.dalcns = dao.fields


        'Catch ex As Exception

        'End Try

        'p_dalcn = class_xml

        'Dim statusId As Integer = dao.fields.STATUS_ID
        'Dim lcntype As String = dao.fields.lcntpcd

        If statusId = 0 Or statusId = 1 Then
            statusId = 5
        End If
        If _process = "114" Then
            class_xml.CHK_SELL_TYPE = "1"
        ElseIf _process = "116" Then
            class_xml.dalcns.CHK_SELL_TYPE = "2"
        ElseIf _process = "117" Then
            class_xml.dalcns.CHK_SELL_TYPE = "3"
        ElseIf _process = "115" Then
            class_xml.dalcns.CHK_SELL_TYPE = "4"
        ElseIf _process = "127" Or _process = "123" Or _process = "125" Or _process = "129" Or _process = "131" Or _process = "133" Then
            class_xml.dalcns.CHK_SELL_TYPE = "1"
        ElseIf _process = "128" Or _process = "124" Or _process = "126" Or _process = "130" Or _process = "132" Or _process = "134" Then
            class_xml.dalcns.CHK_SELL_TYPE = "2"
        End If
        extend = class_xml



        Dim YEAR As String = dao_up.fields.YEAR
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub
    Private Sub BindData_PDF2(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao_ex As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao_ex.GetDataby_IDA(_IDA)
        Dim LCN_IDA As Integer = dao_ex.fields.FK_IDA
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(LCN_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)
        If Len(_TR_ID) >= 9 Then
            dao_up.GetDataby_TR_ID_Process(_TR_ID, _process)
        Else
            dao_up.GetDataby_IDA(_TR_ID)
        End If
        Dim PROCESS_ID As String = ""
        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim pvncd As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(LCN_IDA)
        '------------------------------------
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(LCN_IDA)

        Dim ProcessID As String = ""
        Try
            PROCESS_ID = dao.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If PROCESS_ID = "" Then
            PROCESS_ID = dao_up.fields.PROCESS_ID
        End If
        Try
            pvncd = dao.fields.pvncd
        Catch ex As Exception

        End Try
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntpcd = lcntpcd.Change_lcntpcd()
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, dao.fields.lcnsid, lcnno:=lcnno_auto, lcntpcd:=lcntpcd, pvncd:=pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT9 = bao_show.SP_GETDATA_EXTENDPDF_by_IDA(LCN_IDA)
        Dim BSN_IDENTIFY As String = ""
        Try
            BSN_IDENTIFY = dao.fields.BSN_IDENTIFY
        Catch ex As Exception

        End Try
        Dim MAIN_LCN_IDA As Integer = 0
        'If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        '    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        '        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        '    End If
        'End If
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(BSN_IDENTIFY) 'ผู้ดำเนิน
        'If MAIN_LCN_IDA <> 0 Then
        '    'ใบย่อย
        '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(MAIN_LCN_IDA) 'ผู้ดำเนิน

        '    'Dim dao_mn As New DAO_DRUG.ClsDBdalcn
        '    'dao_mn.GetDataby_IDA(MAIN_LCN_IDA)
        '    'lcnno_auto = dao_mn.fields.lcnno
        'Else

        Try
            If Len(lcnno_auto) > 0 Then
                lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try


        'class_xml.LCNNO_SHOW = lcnno_format
        'class_xml.SHOW_LCNNO = lcnno_text
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        ' If MAIN_LCN_IDA = 0 Then
        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.SHOW_LCNNO = lcnno_text
        'Else

        '    class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
        '    class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        'End If
        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)
                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(appdate.Year)
                End If
                class_xml.EXP_YEAR = expyear
            End If
        Else
            If IsNothing(dao.fields.expyear) = False Then
                Dim expyear As Integer = 0
                Try
                    expyear = dao.fields.expyear
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                class_xml.EXP_YEAR = expyear
            End If
        End If

        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHRi
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        For Each dao_PHR.fields In dao_PHR.Details
            class_xml.DALCN_PHRs.Add(dao_PHR.fields)
        Next
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)



        Catch ex As Exception

        End Try
        class_xml.dalcns = dao.fields
        p_dalcn = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = ""
        Try
            lcntype = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        lcntype = lcntype.Change_lcntpcd()
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim template_id As Integer = 0
        'If statusId = 8 Then
        'Dim Group As Integer
        'If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
        '    Try
        '        template_id = dao.fields.TEMPLATE_ID
        '    Catch ex As Exception
        '        template_id = 0
        '    End Try
        '    If template_id = 2 Then
        '        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        '    Else
        '        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 0)
        '    End If
        'Else

        Try
            template_id = dao.fields.TEMPLATE_ID
        Catch ex As Exception
            template_id = 0
        End Try
        If template_id = 2 Then
            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        Else
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, HiddenField2.Value, 0)
        End If

        'End If
        'Else

        '    Try
        '        template_id = dao.fields.TEMPLATE_ID
        '    Catch ex As Exception
        '        template_id = 0
        '    End Try
        '    'If template_id = 2 Then
        '    '    If statusId > 6 Then
        '    '        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        '    '    Else
        '    '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '    '    End If
        '    'Else
        '    If _group = 1 Then
        '        If template_id = 2 Then
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=9)
        '        Else
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
        '            'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '        End If

        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
        '        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, HiddenField2.Value)
        '    End If

        '    'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)
        '    'End If

        'End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, dao.fields.TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, dao.fields.TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub
    Private Sub BindData_PDF_3(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        Dim dao_ex As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao_ex.GetDataby_IDA(_IDA)
        Dim LCN_IDA As Integer = dao_ex.fields.FK_IDA
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(LCN_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(_TR_ID)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_PHR2 As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP

        dao.GetDataby_IDA(LCN_IDA)
        Dim FK_IDA As Integer = 0
        Try
            FK_IDA = dao.fields.FK_IDA
        Catch ex As Exception

        End Try
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(LCN_IDA)
        '------------------------------------
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(LCN_IDA)

        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim CHK_SELL_TYPE As String = ""
        Try
            CHK_SELL_TYPE = dao.fields.CHK_SELL_TYPE
        Catch ex As Exception

        End Try
        Dim lcntpcd_da As String = ""
        Try
            lcntpcd_da = dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        Dim lcnsid_da As Integer = 0
        Try
            lcnsid_da = dao.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim pvncd_da As Integer = 0
        Try
            pvncd_da = dao.fields.pvncd
        Catch ex As Exception

        End Try

        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, lcnsid_da, lcntpcd_da, pvncd_da, CHK_SELL_TYPE:=CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        ' class_xml = cls_dalcn.gen_xml()
        class_xml.dalcns = dao.fields
        'p_lcn = class_xml
        Try
            class_xml.dalcns.IMAGE_BSN = dao.fields.IMAGE_BSN
        Catch ex As Exception

        End Try


        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        Try
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        Catch ex As Exception

        End Try

        'class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน


        Dim MAIN_LCN_IDA As Integer = 0
        'If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        '    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        '        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        '    End If
        'End If
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        Dim BSN_IDENTIFY As String = ""
        Dim BSN_IDENTIFY_yoi As String = ""
        Try
            'If MAIN_LCN_IDA <> 0 Then
            '    Dim dao_lcn2 As New DAO_DRUG.ClsDBdalcn
            '    dao_lcn2.GetDataby_IDA(MAIN_LCN_IDA)
            'End If
            BSN_IDENTIFY = dao.fields.BSN_IDENTIFY
        Catch ex As Exception

        End Try
        'If MAIN_LCN_IDA <> 0 Then
        '    'ใบย่อย
        '    class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(MAIN_LCN_IDA) 'ผู้ดำเนิน
        'Else
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(LCN_IDA) 'ผู้ดำเนิน
        'End If

        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(LCN_IDA)

        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.DT_MASTER.DT31 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(dao.fields.IDA)

        class_xml.DT_MASTER.DT34 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 3)
        class_xml.DT_MASTER.DT34.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_3_1_ROW"

        class_xml.ALLOW_NAME = dao_ex.fields.ALLOW_NAME
        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        If MAIN_LCN_IDA <> 0 Then
            Try
                'lcnno_format = 
            Catch ex As Exception

            End Try

        End If
        'If MAIN_LCN_IDA = 0 Then
        class_xml.LCNNO_SHOW = lcnno_format
        class_xml.SHOW_LCNNO = lcnno_text
        Try

            class_xml.COUNT_PHESAJ1 = dao_PHR2.CountDataby_FK_IDA_and_Type(LCN_IDA, 1)
        Catch ex As Exception

        End Try

        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ2 = dao_PHR2.CountDataby_FK_IDA_and_Type(LCN_IDA, 2)
        Catch ex As Exception

        End Try
        Try
            dao_PHR2 = New DAO_DRUG.ClsDBDALCN_PHR
            class_xml.COUNT_PHESAJ3 = dao_PHR2.CountDataby_FK_IDA_and_Type(LCN_IDA, 3)
        Catch ex As Exception

        End Try
        'Else

        '    class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
        '    class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        'End If

        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                Try
                    class_xml.First_Appdate = appdate.Day & " " & appdate.ToString("MMMM") & " " & con_year(appdate.Year)
                Catch ex As Exception

                End Try


                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                'Try
                '    class_xml.EXP_YEAR = dao.fields.expyear 'con_year(appdate.Year)
                'Catch ex As Exception
                '    class_xml.EXP_YEAR = con_year(appdate.Year)
                'End Try
                Dim expyear As Integer = 0
                Try
                    expyear = dao_ex.fields.extend_year
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                    End If
                Catch ex As Exception

                End Try
                If expyear = 0 Then
                    expyear = con_year(appdate.Year)
                End If
                class_xml.EXP_YEAR = expyear

            End If
        End If
        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHR
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        Try
            For Each dao_PHR.fields In dao_PHR.Details
                class_xml.DALCN_PHRs.Add(dao_PHR.fields)
            Next
        Catch ex As Exception

        End Try
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.dalcns = dao.fields



        Catch ex As Exception

        End Try

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try



        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd
        Dim PROCESS_ID As String = dao_up.fields.PROCESS_ID
        Dim YEAR As String = dao_up.fields.YEAR

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'If statusId = 8 Then
        '    Dim bao_count As New BAO.ClsDBSqlcommand
        '    Dim count_num As Integer = 0
        '    count_num = bao_count.SC_CHECK_PAY(_IDA)
        '    Dim Group As Integer
        '    If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
        '        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(PROCESS_ID, lcntype, statusId, Group, 0)
        '    ElseIf count_num = 0 Then
        '        statusId = 6
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    End If

        'Else
        Dim template_id As Integer = 0
        'If statusId = 8 Then
        '    If PROCESS_ID = "104" Then
        '        Try
        '            template_id = dao.fields.TEMPLATE_ID
        '        Catch ex As Exception
        '            template_id = 0
        '        End Try
        '        If template_id <> 0 Then
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
        '        Else
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=0)
        '        End If

        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    End If
        'Else
        '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        'End If

        Try
            template_id = ddl_template.SelectedValue
        Catch ex As Exception

        End Try
        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then

                'If PROCESS_ID = "104" Then
                'Try
                '    template_id = dao.fields.TEMPLATE_ID
                'Catch ex As Exception
                '    template_id = 0
                'End Try

                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(dao.fields.PROCESS_ID, lcntype, statusId, 0, _group:=9)
                ElseIf template_id = 3 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(dao.fields.PROCESS_ID, lcntype, statusId, 11, _group:=0)
                Else
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(dao.fields.PROCESS_ID, statusId, 0, 0)
                End If
                'Else
                '    dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(PROCESS_ID, lcntype, statusId, Group, 0)
                'End If
            Else

                'If PROCESS_ID = "104" Then
                'Try
                '    template_id = dao.fields.TEMPLATE_ID
                'Catch ex As Exception
                '    template_id = 0
                'End Try
                If template_id = 2 Then
                    If statusId = 6 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(dao.fields.PROCESS_ID, lcntype, statusId, 0, _group:=9)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(dao.fields.PROCESS_ID, lcntype, statusId, 0, _group:=9)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                    End If
                ElseIf template_id = 3 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(dao.fields.PROCESS_ID, lcntype, statusId, 11, _group:=0)
                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(dao.fields.PROCESS_ID, lcntype, statusId, 0, _group:=0)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                End If

                '    Else
                '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                'End If

            End If
        Else

            'If PROCESS_ID = "104" Then
            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try
            If template_id = 2 Then
                'If statusId = 6 Then
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(dao.fields.PROCESS_ID, lcntype, statusId, 0, _group:=0)
                'Else
                'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                'End If
            ElseIf template_id = 3 Then
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(dao.fields.PROCESS_ID, lcntype, statusId, 11, _group:=0)
            Else
                dao_pdftemplate.GetDataby_TEMPLAETE(dao.fields.PROCESS_ID, lcntype, statusId, 0)
            End If
            '    Else
            '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
            'End If
        End If



        'End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE 'dao_pdftemplate.fields.PDF_OUTPUT

        Dim filename As String = paths & "PDF_EXTEND_TEMP\" & NAME_PDF("DA", dao.fields.PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & "XML_EXTEND_TEMP\" & NAME_XML("DA", dao.fields.PROCESS_ID, YEAR, _TR_ID)
        'load_PDF(filename)


        Try
            Dim url As String = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
            'Dim ws As New WS_QR_CODE.WS_QR_CODE
            'class_xml.QR_CODE = ws.GetQRImgByte(url)
            class_xml.QR_CODE = QR_CODE_IMG(url)
        Catch ex As Exception

        End Try

        Try
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try

                dao_cpn.GetData_by_chngwtcd(dao.fields.chngwtcd)
                chw = dao_cpn.fields.thachngwtnm

            Catch ex As Exception

            End Try
            If dao.fields.chngwtcd <> 10 Then
                class_xml.Position_name = "โดยสำนักงานสาธารณสุขจังหวัด" & chw
            Else
                class_xml.Position_name = "โดยสำนักงานคณะกรรมการอาหารและยา"
            End If

        Catch ex As Exception

        End Try
        p_dalcn = class_xml


        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, dao.fields.PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", dao.fields.PROCESS_ID, YEAR, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)
        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ปิดmodalข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim _group As Integer = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 1
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 0
        End If
        ''Dim template_id As Integer = 0
        ''Dim dao As New DAO_DRUG.ClsDBdalcn
        ''dao.GetDataby_IDA(_IDA)
        ''Try
        ''    template_id = dao.fields.TEMPLATE_ID
        ''Catch ex As Exception

        ''End Try
        ''If template_id = 2 Then
        ''    _group = 9
        ''End If

        '_group:=_group
        'BindData_PDF2(_group:=_group)
        If _group = 0 Then
            BindData_PDF()
        Else
            BindData_PDF_3(_group:=_group)
        End If

        Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "PREVIEW PDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "PREVIEW PDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "PREVIEW PDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "PREVIEW PDFข้อมูลต่ออายุใบอนุญาตหน้าเจ้าหน้าที่", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try

    End Sub


    Private Sub btn_drug_group_Click(sender As Object, e As EventArgs) Handles btn_drug_group.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx?ida=" & Request.QueryString("ida") & "'); ", True)
    End Sub

    Protected Sub ddl_permiss_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_permiss.SelectedIndexChanged
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_IDA(_IDA)

        dao.fields.EXTEND = ddl_permiss.Text
        dao.update()

    End Sub
    Private Function chk_pha() As Boolean
        Dim chk As Boolean = True
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_FK_IDA(_IDA)
        For Each row In dao.datas
            If row.PHR_STATUS_UPLOAD = "1" Then
                chk = False
            End If
        Next
        Return chk
    End Function
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "-"
        End Try

        Return fullname
    End Function
End Class