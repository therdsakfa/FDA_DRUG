Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_DR_CONFIRM_STAFF
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Dim _group As Integer = 0
    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
           
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
        Try
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception

        End Try
        Try
           
            _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            HiddenField2.Value = 0
            txt_appdate.Text = Date.Now.ToShortDateString()
            set_hide(_IDA)
            show_btn(_IDA)

            Dim dao_copy As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB

            Dim newcode As String = ""
            Try
                dao_copy.GetDataby_IDA_drrgt(_IDA)
                newcode = dao_copy.fields.Newcode_U
            Catch ex As Exception

            End Try

            If Request.QueryString("STATUS_ID") = "8" Then
                BindData_PDF_SAI(newcode)
            Else
                BindData_PDF()
            End If


            Bind_ddl_Status_staff()
                set_lbl()

                Try
                    ' If _TR_ID <> "" Then
                    If Request.QueryString("STATUS_ID") = "8" Then
                        Dim dao As New DAO_DRUG.ClsDBdrrgt
                        dao.GetDataby_IDA(_IDA)
                        UC_GRID_ATTACH.load_gv(dao.fields.TR_ID)
                    Else
                        Dim dao As New DAO_DRUG.ClsDBdrrqt
                        dao.GetDataby_IDA(_IDA)
                        UC_GRID_ATTACH.load_gv(dao.fields.TR_ID)
                    End If

                    'End If
                Catch ex As Exception

                End Try
            End If
    End Sub
    Sub set_lbl()
        If Request.QueryString("STATUS_ID") = "8" Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)

            Try
                lbl_appdate.Text = CDate(dao.fields.appdate).ToShortDateString()
            Catch ex As Exception
                lbl_appdate.Text = "-"
            End Try
            Try
                lbl_rcvdate.Text = CDate(dao.fields.rcvdate).ToShortDateString()
            Catch ex As Exception
                lbl_rcvdate.Text = "-"
            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)

            Try
                lbl_appdate.Text = CDate(dao.fields.appdate).ToShortDateString()
            Catch ex As Exception
                lbl_appdate.Text = "-"
            End Try
            Try
                lbl_rcvdate.Text = CDate(dao.fields.rcvdate).ToShortDateString()
            Catch ex As Exception
                lbl_rcvdate.Text = "-"
            End Try
        End If

    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl1 As Integer = 0
        Dim int_group_ddl2 As Integer = 0
        Dim status_id1 As Integer = 0
        'If Request.QueryString("STATUS_ID") <> 8 Then
        '    Dim dao As New DAO_DRUG.ClsDBdrrqt
        '    dao.GetDataby_IDA(_IDA)
        '    status_id1 = dao.fields.STATUS_ID
        'Else
        '    Dim dao As New DAO_DRUG.ClsDBdrrgt
        '    dao.GetDataby_IDA(_IDA)
        '    status_id1 = dao.fields.STATUS_ID
        'End If
        Try
            status_id1 = Request.QueryString("STATUS_ID")
        Catch ex As Exception

        End Try

        'If status_id1 = 3 Then
        '    int_group_ddl1 = 97
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 4 Then
        '    int_group_ddl1 = 1
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 5 Then
        '    int_group_ddl1 = 2
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 6 Then
        '    int_group_ddl1 = 3
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 9 Then
        '    int_group_ddl1 = 4
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 10 Then 'จ่ายเงินแล้ว
        '    int_group_ddl1 = 5
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 11 Then
        '    int_group_ddl1 = 6
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 12 Then
        '    int_group_ddl1 = 8
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 13 Then
        '    int_group_ddl1 = 9
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 14 Then
        '    int_group_ddl1 = 10
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 15 Then
        '    int_group_ddl1 = 11
        '    int_group_ddl2 = 77
        '    'ElseIf status_id1 = 15 Then
        '    '    int_group_ddl1 = 10
        '    '    int_group_ddl2 = 77
        'End If
        If status_id1 >= 2 And status_id1 <> 8 And status_id1 < 6 Then
            int_group_ddl1 = 1
        ElseIf status_id1 >= 6 And status_id1 <> 8 And status_id1 < 14 Then
            int_group_ddl1 = 2
        ElseIf status_id1 >= 14 And status_id1 <> 8 Then
            int_group_ddl1 = 3
        End If

        '= 6 หา group 2
        '=14 หา group 3

        dt = Get_DDL_DATA(8, int_group_ddl1, int_group_ddl2)

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME_STAFF"
        ddl_cnsdcd.DataBind()


        'Dim dt As New DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim int_group_ddl As Integer = 0
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)

        'If dao.fields.STATUS_ID <= 2 Then
        '    int_group_ddl = 1
        '    'ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
        '    '    int_group_ddl = 2
        'ElseIf dao.fields.STATUS_ID >= 3 Then
        '    int_group_ddl = 3
        'End If

        'bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        'dt = bao.dt

        'ddl_cnsdcd.DataSource = dt
        'ddl_cnsdcd.DataValueField = "STATUS_ID"
        'ddl_cnsdcd.DataTextField = "STATUS_NAME"
        'ddl_cnsdcd.DataBind()
    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        'Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V3 @stat_group=" & stat_g & ", @group1=" & group1
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function
    'Public Sub Bind_ddl_Status_staff()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_MAS_STATUS_STAFF()
    '    dt = bao.dt

    '    ddl_cnsdcd.DataSource = dt
    '    ddl_cnsdcd.DataBind()
    'End Sub
    'Public Sub Bind_ddl_Status()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_STATUS_BY_GROUP(1)
    '    dt = bao.dt

    '    ddl_cnsdcd.DataSource = dt
    '    ddl_cnsdcd.DataBind()
    'End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        If Request.QueryString("STATUS_ID") = "8" Then
            '    Dim dao As New DAO_DRUG.ClsDBdrrqt
            '    dao.GetDataby_IDA(_IDA)
            '    If dao.fields.STATUS_ID = 8 Then
            '        btn_confirm.Enabled = False
            '        btn_cancel.Enabled = False
            '        btn_confirm.CssClass = "btn-danger btn-lg"
            '        btn_cancel.CssClass = "btn-danger btn-lg"
            '    End If
            'Else
            'Dim dao As New DAO_DRUG.ClsDBdrrgt
            'dao.GetDataby_IDA(_IDA)
            'If dao.fields.STATUS_ID = 8 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
            'End If
        End If
        If Request.QueryString("STATUS_ID") <> "14" And Request.QueryString("STATUS_ID") <> "15" Then
            btn_preview.Enabled = False
            ' btn_cancel.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
        End If
    End Sub

    Public Sub set_hide(ByVal IDA As String)
        'Dim dao As New DAO_DRUG.ClsDBdrrqt
        'dao.GetDataby_IDA(IDA)
        'If dao.fields.STATUS_ID = 8 Then
        '    btn_confirm.Enabled = False
        '    btn_cancel.Enabled = False
        '    btn_confirm.CssClass = "btn-danger btn-lg"
        '    btn_cancel.CssClass = "btn-danger btn-lg"

        '    ddl_cnsdcd.Style.Add("display", "none")
        'End If

        'Try
        '    Dim dao_u As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        '    dao_u.GetDataby_IDA(_TR_ID)
        '    If dao_u.fields.PROCESS_ID = "104" Then
        '        ddl_template.Style.Add("display", "block")
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer = 0
        Dim PROCESS_ID As Integer
        If Request.QueryString("STATUS_ID") = "8" Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            PROCESS_ID = dao_up.fields.PROCESS_ID
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            PROCESS_ID = dao_up.fields.PROCESS_ID
        End If

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 8 'ใบอนุญาต ขย ต่างๆ
        dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.fields.PROCESS_ID = PROCESS_ID
        dao_date.insert()


        'If STATUS_ID = 9 Then
        '    'dao.fields.STATUS_ID = STATUS_ID
        '    'Dim bao2 As New BAO.GenNumber
        '    'RCVNO = bao2.GEN_NO_07(con_year(Date.Now.Year), _CLS.PVCODE, IIf(IsDBNull(dao.fields.lcnno), "", dao.fields.lcnno), PROCESS_ID, 0, 0, _IDA, "")
        '    'dao.fields.rcvno = RCVNO
        '    'Try
        '    '    dao.fields.rcvdate = txt_appdate.Text
        '    'Catch ex As Exception

        '    'End Try
        '    'dao.update()


        '    Response.Redirect("TABEAN_YA_STAFF_RECEIVE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

        '    'alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        If STATUS_ID = 6 Then
            Response.Redirect("POPUP_DR_STAFF_CHECK_RQT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)


            'dao.fields.STATUS_ID = STATUS_ID
            'dao.update()
            'AddLogStatus(STATUS_ID, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            'alert("ตรวจรับคำขอ")



        ElseIf STATUS_ID = 8 Then
            Response.Redirect("TABEAN_YA_STAFF_APPROVE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)
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
            'insert_tabean(_IDA)
            'alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")



        ElseIf STATUS_ID = 77 Or STATUS_ID = 7 Then
            If Request.QueryString("STATUS_ID") = "8" Then
                Dim dao As New DAO_DRUG.ClsDBdrrgt
                dao.GetDataby_IDA(_IDA)
                dao.fields.STATUS_ID = STATUS_ID
                dao.update()
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            Else
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)
                dao.fields.STATUS_ID = STATUS_ID
                dao.update()
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            End If
            AddLogStatus(STATUS_ID, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
        ElseIf STATUS_ID = 14 Then
            Response.Redirect("POPUP_TABEAN_YA_STAFF_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        Else
            If Request.QueryString("STATUS_ID") = "8" Then
                Dim dao As New DAO_DRUG.ClsDBdrrgt
                dao.GetDataby_IDA(_IDA)
                dao.fields.STATUS_ID = STATUS_ID
                'dao.fields.CONSIDER_DATE = txt_appdate.Text
                dao.update()
                alert("ยืนยันแล้ว")
            Else
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)
                dao.fields.STATUS_ID = STATUS_ID
                'dao.fields.CONSIDER_DATE = txt_appdate.Text
                dao.update()
                alert("ยืนยันแล้ว")
            End If

            Dim cls_sop As New CLS_SOP
            cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao_up.fields.PROCESS_ID, _CLS.PVCODE, 8, "อนุญาตให้ขึ้นทะเบียนฯ", "SOP-DRUG-10-" & dao_up.fields.PROCESS_ID & "-13", "อนุญาตให้ขึ้นทะเบียนฯแล้ว", "อนุญาตให้ขึ้นทะเบียนฯ แล้ว", "STAFF", _TR_ID, SOP_STATUS:="อนุญาตให้ขึ้นทะเบียนฯ")
            AddLogStatus(STATUS_ID, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
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
            year_short = split_text(2)
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

        End Try

        Return bool
    End Function
    Sub insert_tabean(ByVal FK_IDA As Integer)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(FK_IDA)
        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        With dao_drrgt.fields
            .accttp = dao.fields.accttp
            .appdate = dao.fields.appdate
            .CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            .CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            .CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            .classcd = dao.fields.classcd
            .CONSIDER_DATE = dao.fields.CONSIDER_DATE
            .ctgcd = dao.fields.ctgcd
            .CTZNO = dao.fields.CTZNO
            .drgbiost = dao.fields.drgbiost
            .drgexpst = dao.fields.drgexpst
            .drgnewst = dao.fields.drgnewst
            .drgtpcd = dao.fields.drgtpcd
            .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            .dsgcd = dao.fields.dsgcd
            .engdrgnm = dao.fields.engdrgnm
            .EXTEND_DATE = dao.fields.EXTEND_DATE
            .FIRST_APP_DATE = dao.fields.FIRST_APP_DATE
            .FK_DOSAGE_FORM = dao.fields.FK_DOSAGE_FORM
            .FK_DRRQT = FK_IDA
            .FK_IDA = dao.fields.FK_IDA
            .FK_LCN_IDA = dao.fields.FK_LCN_IDA
            .FK_STAFF_OFFER_IDA = dao.fields.FK_STAFF_OFFER_IDA
            .frtappdate = dao.fields.FIRST_APP_DATE
            .IDENTIFY = dao.fields.IDENTIFY
            .kindcd = dao.fields.kindcd
            .lcnabbr = dao.fields.lcnabbr
            .UNIT_NORMAL = dao.fields.UNIT_NORMAL
            .DRUG_PACKING = dao.fields.DRUG_PACKING
            .UNIT_BIO = dao.fields.UNIT_BIO
            .DRUG_STYLE = dao.fields.DRUG_STYLE
            .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Try
                .lcnno = dao.fields.lcnno
            Catch ex As Exception

            End Try

            .lcnscd = dao.fields.lcnscd
            .lcnsid = dao.fields.lcnsid
            .lcntpcd = dao.fields.lcntpcd
            .lctcd = dao.fields.lctcd
            .lctnmcd = dao.fields.lctnmcd
            Try
                .lmdfdate = dao.fields.lmdfdate
            Catch ex As Exception

            End Try

            .lpvncd = dao.fields.lpvncd
            .lstfcd = dao.fields.lstfcd
            .ndrgtp = dao.fields.ndrgtp
            .packcd = dao.fields.packcd
            .potency = dao.fields.potency
            .PROCESS_ID = dao.fields.PROCESS_ID
            .pvnabbr = dao.fields.pvnabbr
            .pvncd = dao.fields.pvncd
            Try
                .rcvdate = dao.fields.rcvdate
            Catch ex As Exception

            End Try

            .rcvno = dao.fields.rcvno
            .REGIST_TYPE = dao.fields.REGIST_TYPE
            .REMARK = dao.fields.REMARK
            .rgtno = dao.fields.rgtno
            .rgttpcd = dao.fields.rgttpcd
            .STAFF_APP_IDENTIFY = dao.fields.STAFF_APP_IDENTIFY
            .STATUS_ID = dao.fields.STATUS_ID
            .TABEAN_TYPE = dao.fields.TABEAN_TYPE
            .thadrgnm = dao.fields.thadrgnm
            .TR_ID = dao.fields.TR_ID
            Try
                .UNIT_BIO = dao.fields.UNIT_BIO
            Catch ex As Exception

            End Try
            Try
                .UNIT_NORMAL = dao.fields.UNIT_NORMAL
            Catch ex As Exception

            End Try
            Try
                .DRUG_PACKING = dao.fields.DRUG_PACKING
            Catch ex As Exception

            End Try
            Try
                .TYPE_REQUEST_ID = dao.fields.TYPE_REQUEST_ID
            Catch ex As Exception

            End Try
            Try
                .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Catch ex As Exception

            End Try
        End With
        dao_drrgt.insert()
        Dim IDA_rgt As Integer = dao_drrgt.fields.IDA

        Dim dao_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
        dao_atc.GetDataby_FK_IDA(FK_IDA)
        For Each dao_atc.fields In dao_atc.datas
            Dim dao_rgt_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
            With dao_rgt_atc.fields
                .ATC_CODE = dao_atc.fields.ATC_CODE
                .ATC_IDA = dao_atc.fields.ATC_IDA
                .FK_IDA = IDA_rgt
            End With
            dao_rgt_atc.insert()
        Next


        Dim dao_cas As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
        dao_cas.GetDataby_FK_IDA(FK_IDA)
        For Each dao_cas.fields In dao_cas.datas
            Dim dao_rgt_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            With dao_rgt_cas.fields
                .AORI = dao_cas.fields.AORI
                .BASE_FORM = dao_cas.fields.BASE_FORM
                .EQTO_IOWA = dao_cas.fields.EQTO_IOWA
                .EQTO_QTY = dao_cas.fields.EQTO_QTY
                .EQTO_SUNITCD = dao_cas.fields.EQTO_SUNITCD
                .FK_IDA = IDA_rgt
                .IOWA = dao_cas.fields.IOWA
                .QTY = dao_cas.fields.QTY
                .ROWS = dao_cas.fields.ROWS
                .SUNITCD = dao_cas.fields.SUNITCD
            End With
            dao_rgt_cas.insert()
        Next


        Dim dao_pack As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
        dao_pack.GetDataby_FKIDA(FK_IDA)
        For Each dao_pack.fields In dao_pack.datas
            Dim dao_rgt_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            With dao_rgt_pack.fields
                .BARCODE = dao_pack.fields.BARCODE
                .BIG_UNIT = dao_pack.fields.BIG_UNIT
                .CHECK_PACKAGE = dao_pack.fields.CHECK_PACKAGE
                .FK_IDA = IDA_rgt
                .MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
                .MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
                .SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
                .SMALL_UNIT = dao_pack.fields.SMALL_UNIT
            End With
            dao_rgt_pack.insert()
        Next


        Dim dao_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
        dao_pro.GetDataby_FK_IDA(FK_IDA)
        For Each dao_pro.fields In dao_pro.datas
            Dim dao_rgt_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
            With dao_rgt_pro.fields
                .addr_ida = dao_pro.fields.addr_ida
                .drgtpcd = dao_pro.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .FK_PRODUCER = dao_pro.fields.FK_PRODUCER
                .frgncd = dao_pro.fields.frgncd
                .frgnlctcd = dao_pro.fields.frgnlctcd
                .funccd = dao_pro.fields.funccd
                .lcnno = dao_pro.fields.lcnno
                .lcntpcd = dao_pro.fields.lcntpcd
                .PRODUCER_WORK_TYPE = dao_pro.fields.PRODUCER_WORK_TYPE
                .pvncd = dao_pro.fields.pvncd
                .rcvno = dao_pro.fields.rcvno
                .REFERENCE_GMP = dao_pro.fields.REFERENCE_GMP
                .rgtno = dao_pro.fields.rgtno
                .rgttpcd = dao_pro.fields.rgttpcd
                .TR_ID = dao_pro.fields.TR_ID
            End With
            dao_rgt_pro.insert()
        Next


        Dim dao_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
        dao_pro_in.GetDataby_FK_IDA(FK_IDA)
        For Each dao_pro_in.fields In dao_pro_in.datas
            Dim dao_rgt_pro_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
            With dao_rgt_pro_in.fields
                .drgtpcd = dao_pro_in.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .funccd = dao_pro_in.fields.funccd
                .lcnno = dao_pro_in.fields.lcnno
                .lcntpcd = dao_pro_in.fields.lcntpcd
                .rgtno = dao_pro_in.fields.rgtno
                .rgttpcd = dao_pro_in.fields.rgttpcd
                .FK_LCN_IDA = dao_pro_in.fields.FK_LCN_IDA
                .rgtno = dao_pro_in.fields.rgtno
                .rgttpcd = dao_pro_in.fields.rgttpcd
                .lctcd = dao_pro_in.fields.lctcd
                .lcnsid = dao_pro_in.fields.lcnsid
            End With
            dao_rgt_pro_in.insert()
        Next


        Dim dao_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES
        dao_prop.GetDataby_FKIDA(FK_IDA)
        For Each dao_prop.fields In dao_prop.datas
            Dim dao_rgt_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
            With dao_rgt_prop.fields
                .CHK_DRUG_PROPERTIES = dao_prop.fields.CHK_DRUG_PROPERTIES
                .CHK_DRUG_PROPERTIES_OTHER = dao_prop.fields.CHK_DRUG_PROPERTIES_OTHER
                .DRUG_PROPERTIES = dao_prop.fields.DRUG_PROPERTIES
                .DRUG_PROPERTIES_OTHER = dao_prop.fields.DRUG_PROPERTIES_OTHER
                .FK_IDA = IDA_rgt
            End With
            dao_rgt_prop.insert()
        Next


        Dim dao_prop_det As New DAO_DRUG.tb_DRRQT_PROPERTIES_AND_DETAIL
        dao_prop_det.GetDataby_FKIDA(FK_IDA)
        For Each dao_prop_det.fields In dao_prop_det.datas
            Dim dao_rgt_pd As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            With dao_rgt_pd.fields
                .DRUG_PROPERTIES_AND_DETAIL = dao_prop_det.fields.DRUG_PROPERTIES_AND_DETAIL
                .FK_IDA = IDA_rgt
                .OTHER = dao_prop_det.fields.OTHER
                .ROWS = dao_prop_det.fields.ROWS
            End With
            dao_rgt_pd.insert()
        Next

        Dim dao_each As New DAO_DRUG.TB_DRRQT_EACH
        dao_each.GetDataby_FK_IDA(FK_IDA)
        For Each dao_each.fields In dao_each.datas
            Dim dao_each_rgt As New DAO_DRUG.TB_DRRGT_EACH
            With dao_each_rgt.fields
                .EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
                .FK_IDA = IDA_rgt
                .sunitcd = dao_each.fields.sunitcd
            End With
            dao_each_rgt.insert()
        Next
        '
        Dim dao_keep As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
        dao_keep.GetDataby_FKIDA(FK_IDA)
        For Each dao_keep.fields In dao_keep.datas
            Dim dao_keep_rgt As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            With dao_keep_rgt.fields
                .AGE_DAY = dao_keep.fields.AGE_DAY
                .FK_IDA = IDA_rgt
                .AGE_HOUR = dao_keep.fields.AGE_HOUR
                .AGE_MONTH = dao_keep.fields.AGE_MONTH
                .DRUG_DETAIL = dao_keep.fields.DRUG_DETAIL
                .KEEP_DESCRIPTION = dao_keep.fields.KEEP_DESCRIPTION
                .TEMPERATE1 = dao_keep.fields.TEMPERATE1
                .TEMPERATE2 = dao_keep.fields.TEMPERATE2
            End With
            dao_keep_rgt.insert()
        Next

        'DRRGT_DTL_TEXT
        Dim dao_dtl As New DAO_DRUG.TB_DRRQT_DTL_TEXT
        dao_dtl.GetDataby_FKIDA(FK_IDA)
        For Each dao_dtl.fields In dao_dtl.datas
            Dim dao_dtl_rqt As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            With dao_dtl_rqt.fields
                .drgtpcd = dao_dtl.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .dtl = dao_dtl.fields.dtl
                .engdrgtpnm = dao_dtl.fields.engdrgtpnm
                .keepdesc = dao_dtl.fields.keepdesc
                .pcksize = dao_dtl.fields.pcksize
                .pvncd = dao_dtl.fields.pvncd
                .rgtno = dao_dtl.fields.rgtno
                .rgttpcd = dao_dtl.fields.rgttpcd
                .tphigh = dao_dtl.fields.tphigh
                .tplow = dao_dtl.fields.tplow
                .U1_CODE = dao_dtl.fields.U1_CODE
                .useage = dao_dtl.fields.useage
            End With
            dao_dtl_rqt.insert()
        Next


        Dim dao_color As New DAO_DRUG.TB_DRRQT_COLOR
        dao_color.GetDataby_FK_IDA(FK_IDA)
        For Each dao_color.fields In dao_color.datas
            Dim dao_color_rqt As New DAO_DRUG.TB_DRRGT_COLOR
            With dao_color_rqt.fields
                .COLOR_NAME1 = dao_color.fields.COLOR_NAME1
                .FK_IDA = IDA_rgt
                .COLOR_NAME2 = dao_color.fields.COLOR_NAME2
                .COLOR_NAME3 = dao_color.fields.COLOR_NAME3
                .COLOR_NAME4 = dao_color.fields.COLOR_NAME4
                .COLOR1 = dao_color.fields.COLOR1
                .COLOR2 = dao_color.fields.COLOR2
                .COLOR3 = dao_color.fields.COLOR3
                .COLOR4 = dao_color.fields.COLOR4
            End With
            dao_color_rqt.insert()
        Next


        Dim dao_eq As New DAO_DRUG.TB_DRRQT_EQTO
        dao_eq.GetDataby_FK_IDA(FK_IDA)
        For Each dao_eq.fields In dao_eq.datas
            Dim dao_eq_rgt As New DAO_DRUG.TB_DRRGT_EQTO
            With dao_eq_rgt.fields
                .FK_IDA = IDA_rgt
                .IOWA = dao_eq.fields.IOWA
                .MULTIPLY = dao_eq.fields.MULTIPLY
                .QTY = dao_eq.fields.QTY
                .ROWS = dao_eq.fields.ROWS
                .STR_VALUE = dao_eq.fields.STR_VALUE
                .SUNITCD = dao_eq.fields.SUNITCD
                .FK_SET = dao_eq.fields.FK_SET
            End With
            dao_eq_rgt.insert()
        Next
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "'); parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type langue =javascript>")
        Response.Write("window.location.href = 'TABEAN_YA_MAIN_STAFF.aspx';")
        Response.Write("</script type >")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.FILENAME_PDF)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.PDFNAME)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub
  
  
    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DR
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim lcnno As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drgtpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim tr_id As Integer = 0
        Dim IDA_regist As Integer = 0
        Dim lcnsid As Integer = 0
        Dim lcntpcd As String = ""
        Dim appdate As Date
        Dim expdate As Date
        Dim pvnabbr As String = ""
        Dim dsgcd As String = ""
        Dim STATUS_ID As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim wong_lep As String = ""
        Try
            STATUS_ID = Request.QueryString("STATUS_ID") 'Get_drrqt_Status(_IDA)
        Catch ex As Exception

        End Try
        Dim tamrap_id As Integer = 0
        Dim class_xml As New CLASS_DR
        If STATUS_ID <> 8 Then
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)
            Try
                tamrap_id = dao.fields.feepayst
            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try

            lcnno = dao.fields.lcnno
            IDA_regist = dao.fields.FK_IDA
            tr_id = dao.fields.TR_ID
            lcnsid = dao.fields.lcnsid
            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            pvncd = dao.fields.pvncd
            rgttpcd = dao.fields.rgttpcd
            dsgcd = dao.fields.dsgcd
            STATUS_ID = dao.fields.STATUS_ID
            'Try
            '    TABEAN_TYPE1 = dao.fields.TABEAN_TYPE
            'Catch ex As Exception

            'End Try
            Try
                TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try

            Try
                rcvno_auto = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                lcnno_auto = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno_auto = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                drgtpcd = dao.fields.drgtpcd
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            pvnabbr = dao.fields.pvnabbr
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try
                class_xml.drrqts = dao.fields
            Catch ex As Exception

            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try

        Else

            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)
            Dim dao2 As New DAO_DRUG.ClsDBdrrqt
            Try
                class_xml.drrgts = dao.fields
            Catch ex As Exception

            End Try
            Try
                dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
                'regis_ida = dao.fields.FK_IDA
                tamrap_id = dao2.fields.feepayst
            Catch ex As Exception

            End Try
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try
            lcnno = dao.fields.lcnno
            Try
                If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                    TABEAN_TYPE1 = "1"
                    'cls_xml.TABEAN_TYPE2 = "2"
                Else
                    TABEAN_TYPE1 = "2"
                    'cls_xml.TABEAN_TYPE2 = "0"
                End If
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
            Try
                dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
            Catch ex As Exception

            End Try

            Try
                IDA_regist = dao_rq.fields.FK_IDA
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                lcnsid = dao.fields.lcnsid
            Catch ex As Exception

            End Try

            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            pvncd = dao.fields.pvncd
            rgttpcd = dao.fields.rgttpcd
            dsgcd = dao.fields.dsgcd
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try

            Try
                rcvno_auto = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                lcnno_auto = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno_auto = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                drgtpcd = dao.fields.drgtpcd
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            pvnabbr = dao.fields.pvnabbr
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
        End If

        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(IDA_regist)
        Catch ex As Exception

        End Try

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(FK_LCN_IDA)
            lcntpcd = dao_lcn.fields.lcntpcd
            pvnabbr = dao_lcn.fields.pvnabbr
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        Dim _process As Integer = 0
        Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tr.GetDataby_IDA(tr_id)
            _process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try

        
        Try
            class_xml.DRUG_STRENGTH = DRUG_STRENGTH
        Catch ex As Exception

        End Try
        
        Try
            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)
            class_xml.DRRGT_COLORs = dao_color.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try




        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_dos.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try

        Try
            pvncd = pvncd
        Catch ex As Exception
            pvncd = ""
        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try

        

        If IsNothing(appdate) = False Then
            Dim appdate2 As Date
            If Date.TryParse(appdate, appdate2) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                If class_xml.SHOW_LCNDATE_YEAR = 544 Then
                    class_xml.SHOW_LCNDATE_DAY = ""
                    class_xml.SHOW_LCNDATE_MONTH = ""
                    class_xml.SHOW_LCNDATE_YEAR = ""
                End If

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If

        If IsNothing(expdate) = False Then
            Dim expdate2 As Date
            If Date.TryParse(expdate, expdate2) = True Then
                class_xml.EXPDAY = expdate.Day
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXP_YEAR = con_year(expdate.Year)
                Try
                    class_xml.EXPDATESHORT = expdate.Day & "/" & expdate.Month & "/" & con_year(expdate.Year)
                Catch ex As Exception

                End Try

                If class_xml.EXP_YEAR = 544 Then
                    class_xml.EXPDAY = ""
                    class_xml.EXPMONTH = ""
                    class_xml.EXP_YEAR = ""
                    class_xml.EXPDATESHORT = ""
                End If


            End If
        End If

        Dim aa As String = ""
        Dim aa2 As String = ""
        If Request.QueryString("status") = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try

            Try
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
                daodrgtype2.GetDataby_drgtpcd(dao_rq.fields.rgtdrgtpcd)

                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            Dim dao3 As New DAO_DRUG.ClsDBdrrqt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype2.GetDataby_drgtpcd(dao3.fields.rgtdrgtpcd)
            Try
                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try
        'If pvncd <> "" Then
        '    If pvncd <> "10" Then
        '        rgtno_format &= " " & "(" & pvncd & ")"
        '    End If
        'End If
        'Try
        '    If Len(rgtno_auto) > 0 Then
        '        rgtno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try


        Try
            If STATUS_ID = 8 Then
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                    dao4.GetDataby_IDA(_IDA)
                    'If dao4.fields.USE_PVNABBR2 IsNot Nothing Then
                    '    'If dao4.fields.USE_PVNABBR2 = "1" Then
                    '    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    'End If
                    'Else
                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    End If
                End If
            Else
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                    dao4.GetDataby_IDA(_IDA)
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
        Try
            If Len(rcvno_auto) > 0 Then
                If aa2 = "(NG)" Then
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
                Else
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
                End If

            End If
        Catch ex As Exception

        End Try

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            'drug_name = drug_name_th

            'drug_name = drug_name_th & " / " & drug_name_eng
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If
        If STATUS_ID = 8 Then
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRGT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        Else
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRQT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        End If
        'drug_name = drug_name_th & "/" & drug_name_eng
        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2
        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try


        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        'class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        Try
            If STATUS_ID = "8" Then
                Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            Else
                Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            End If
        Catch ex As Exception

        End Try
        'class_xml.DT_SHOW.DT3 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน

        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ

        If STATUS_ID <> 8 Then

            Dim dao_det_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FKIDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try

            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRQT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                PACK_SIZE = dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try
            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try
            
            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRQT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
            class_xml.DT_SHOW.DT20 = bao_show.SP_DRRQT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRQT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


            'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_DATA(_IDA)

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"

            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao_lcn.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            class_xml.DT_SHOW.DT23 = bao_show.SP_drrqt_cas(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"

            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"

            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"


        Else
            'Dim dao_rq As New DAO_DRUG.ClsDBdrrgt
            'dao_rq.GetDataby_FK_DRRQT(_IDA)
            '_IDA = dao_rq.fields.IDA

            Dim dao_det_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FK_IDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try

            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                PACK_SIZE = dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try
            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try
            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT10.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_DATA(_IDA)

            'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            'class_xml.DT_SHOW.DT15.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_2NO"
            'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            'class_xml.DT_SHOW.DT16.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_3NO"
            'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 4)
            'class_xml.DT_SHOW.DT17.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_4NO"

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"

            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(dao_lcn.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            class_xml.DT_SHOW.DT23 = bao_show.SP_drrgt_cas(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRGT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        End If

        Dim lcntype As String = "0" 'dao.fields.lcntpcd
        'Try
        '    Dim rcvdate As Date = dao.fields.rcvdate
        '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
        '    class_xml.drrgts = dao.fields



        'Catch ex As Exception

        'End Try
        'Try
        '    lcntype = dao.fields.rgttpcd
        'Catch ex As Exception

        'End Try

        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_ProcessID)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try
        p_dr = class_xml



        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        ''dao_pdftemplate.GetDataby_TEMPLAETE(_process, lcntype, statusId, 0)

        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_ProcessID, STATUS_ID, HiddenField2.Value, 0)
        '------------------------(E)------------------------
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try
            If Request.QueryString("STATUS_ID") = "8" Then 'Or Request.QueryString("STATUS_ID") = "14"
                Dim dao As New DAO_DRUG.ClsDBdrrgt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                E_VALUE = dao_drgtpcd.fields.engdrgtpnm
            Else
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                Try
                    E_VALUE = dao_drgtpcd.fields.engdrgtpnm
                Catch ex As Exception
                    E_VALUE = ""
                End Try

            End If
        Catch ex As Exception

        End Try
        'Dim NAME_TEMPLATE As String = ""
        'If E_VALUE <> "(E)" Then
        '    NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
        'Else
        '    If Request.QueryString("STATUS_ID") = "8" Then
        '        If HiddenField2.Value = 1 Then
        '            NAME_TEMPLATE = "DA_YOR_2_E.pdf"
        '        Else
        '            NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"
        '        End If
        '    Else
        '        NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
        '    End If
        'End If
        Dim NAME_TEMPLATE As String = ""
        If E_VALUE <> "(E)" Then
            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE

            If Request.QueryString("STATUS_ID") = "8" Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    'NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    Try
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                        dao_rg.GetDataby_IDA(_IDA)
                        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                        dao_rq.GetDataby_IDA(dao_rg.fields.FK_DRRQT)
                        Dim dao_tr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                        dao_tr.GetDataby_TAMRAP_ID(dao_rq.fields.dvcd)
                        If rgttpcd = "G" And dao_tr.fields.IS_AUTO = 1 Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        Else
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Else

            End If

            If Request.QueryString("STATUS_ID") = "14" And HiddenField2.Value = 1 Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                End If
            End If
        Else
            If Request.QueryString("STATUS_ID") = "8" Or Request.QueryString("STATUS_ID") = "14" Then
                NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"
            Else
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If
        End If

        '-----------------------------------------------------
        


        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_OUTPUT As String = ""
        Dim XML_PATH As String = ""

        If STATUS_ID = "1" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_UPLOAD"
            XML_PATH = "XML_TRADER_STAFF_UPLOAD"
        ElseIf STATUS_ID = "2" Or STATUS_ID = "3" Or STATUS_ID = "4" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_EMP"
            XML_PATH = "XML_TRADER_STAFF_EMP"
        Else
            PDF_OUTPUT = dao_pdftemplate.fields.PDF_OUTPUT
            XML_PATH = dao_pdftemplate.fields.XML_PATH
        End If

        If tamrap_id <> 0 Then
            If Request.QueryString("status") = "8" Then
                Dim dao3 As New DAO_DRUG.ClsDBdrrgt
                dao3.GetDataby_IDA(_IDA)
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                Try
                    dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                    If dao_rq.fields.feetpcd = "1" Then
                        NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                    ElseIf dao_rq.fields.feetpcd = "99" Then
                        NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    End If
                Catch ex As Exception

                End Try

            ElseIf Request.QueryString("status") = "15" Or Request.QueryString("status") = "14" Then
                If HiddenField2.Value = "1" Then
                    Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                    Try
                        dao_rq.GetDataby_IDA(_IDA)
                        If dao_rq.fields.feetpcd = "1" Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        ElseIf dao_rq.fields.feetpcd = "99" Then
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
                End If

            Else
                NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
            End If
        End If


        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE 'dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID) ' dao_pdftemplate.fields.PDF_OUTPUT
        Dim Path_XML As String = paths & XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID) 'dao_pdftemplate.fields.XML_PATH
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
    'Private Sub BindData_PDF()
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()


    '    Dim dao As New DAO_DRUG.ClsDBdrrgt
    '    dao.GetDataby_IDA(_IDA)



    '    Dim cls_regis As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao.fields.lcntpcd, dao.fields.pvncd)

    '    Dim class_xml As New CLASS_DR
    '    class_xml = cls_regis.gen_xml()

    '    Try
    '        'Dim rcvdate As Date = dao.fields.rcvdate
    '        'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
    '        class_xml.drrgts = dao.fields
    '    Catch ex As Exception

    '    End Try

    '    'Try
    '    '    Dim appvdate As Date = class_xml.dalcns.appvdate
    '    '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
    '    '    class_xml.fregntf.appvdate = appvdate
    '    'Catch ex As Exception

    '    'End Try

    '    ' p_ = class_xml

    '    Dim statusId As Integer = dao.fields.STATUS_ID
    '    Dim lcntype As Integer = 0 'dao.fields.lcntpcd


    '    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '    dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

    '    Dim paths As String = bao._PATH_DEFAULT
    '    Dim PDF_TEMPLATE As String = paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
    '    LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


    '    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
    '    hl_reader.NavigateUrl = "../PDF/PDF_PERVIEW2.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
    '    HiddenField1.Value = filename
    '    _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    _CLS.PDFNAME = filename
    '    '    show_btn() 'ตรวจสอบปุ่ม
    'End Sub

    Private Sub BindData_PDF_SAI(ByVal newcode As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim lcnno As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drgtpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim tr_id As Integer = 0
        Dim IDA_regist As Integer = 0
        Dim lcnsid As Integer = 0
        Dim lcntpcd As String = ""
        Dim appdate As Date
        Dim expdate As Date
        Dim pvnabbr As String = ""
        Dim dsgcd As String = ""
        Dim STATUS_ID As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim wong_lep As String = ""
        Try
            STATUS_ID = Request.QueryString("STATUS_ID") 'Get_drrqt_Status(_IDA)
        Catch ex As Exception

        End Try
        Dim tamrap_id As Integer = 0
        Dim class_xml As New CLASS_DR

        Dim dao_e As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        dao_e.GetDataby_u1_frn_no(newcode)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA)
        Dim dao2 As New DAO_DRUG.ClsDBdrrqt
        Try
            class_xml.drrgts = dao.fields
        Catch ex As Exception

        End Try
        Try
            dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
            'regis_ida = dao.fields.FK_IDA
            tamrap_id = dao2.fields.feepayst
        Catch ex As Exception

        End Try
        Try
            Dim dao_color As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR
            dao_color.GetDataby_Newcode(newcode)
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_color.fields.drgchrtha
        Catch ex As Exception

        End Try
        Try
            'Dim dao_class As New DAO_DRUG.TB_drkdofdrg
            'dao_class.GetData_by_kindcd(dao.fields.kindcd)
            class_xml.DRUG_CLASS_NAME = dao_e.fields.thakindnm
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        lcnno = dao_e.fields.lcnno
        Try
            If dao_e.fields.lcntpcd.Contains("ผยบ") Or dao_e.fields.lcntpcd.Contains("นยบ") Then
                TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
        Catch ex As Exception

        End Try
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
        Try
            dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
        Catch ex As Exception

        End Try

        Try
            IDA_regist = dao_rq.fields.FK_IDA
        Catch ex As Exception

        End Try
        Try
            FK_LCN_IDA = dao.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao.fields.lcnsid
        Catch ex As Exception

        End Try

        DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
        pvncd = dao_e.fields.pvncd
        rgttpcd = dao_e.fields.rgttpcd
        dsgcd = dao_e.fields.dsgcd
        Try
            STATUS_ID = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try

        Try
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao_e.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = dao_e.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            drgtpcd = dao_e.fields.drgtpcd
        Catch ex As Exception

        End Try
        Try
            appdate = dao.fields.appdate
        Catch ex As Exception

        End Try
        Try
            expdate = dao_e.fields.expdate
        Catch ex As Exception

        End Try
        pvnabbr = dao_e.fields.pvnabbr
        Try
            drug_name_th = dao_e.fields.thadrgnm
            'drug_name
        Catch ex As Exception
            drug_name_th = "-"
        End Try
        Try
            drug_name_eng = dao_e.fields.engdrgnm
        Catch ex As Exception
            drug_name_eng = "-"
        End Try

        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(IDA_regist)
        Catch ex As Exception

        End Try

        Dim dao_lcn As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
        Try
            dao_lcn.GetDataby_u1(dao_e.fields.Newcode_not)
            lcntpcd = dao_lcn.fields.lcntpcd
            pvnabbr = dao_lcn.fields.pvnabbr
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        Dim _process As Integer = 0
        Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tr.GetDataby_IDA(tr_id)
            _process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try


        Try
            class_xml.DRUG_STRENGTH = dao_e.fields.potency
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            'Dim dao_cas As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_IOW
            'dao_cas.GetDataby_Newcode_U(newcode)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
            'class_xml.DRRGT_DETAIL_Cs.AORI = dao_cas.fields.aori
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try




        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_dos.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try

        Try
            pvncd = pvncd
        Catch ex As Exception
            pvncd = ""
        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try



        If IsNothing(appdate) = False Then
            Dim appdate2 As Date
            If Date.TryParse(appdate, appdate2) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                If class_xml.SHOW_LCNDATE_YEAR = 544 Then
                    class_xml.SHOW_LCNDATE_DAY = ""
                    class_xml.SHOW_LCNDATE_MONTH = ""
                    class_xml.SHOW_LCNDATE_YEAR = ""
                End If

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If

        If IsNothing(expdate) = False Then
            Dim expdate2 As Date
            If Date.TryParse(expdate, expdate2) = True Then
                class_xml.EXPDAY = expdate.Day
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXP_YEAR = con_year(expdate.Year)
                Try
                    class_xml.EXPDATESHORT = expdate.Day & "/" & expdate.Month & "/" & con_year(expdate.Year)
                Catch ex As Exception

                End Try

                If class_xml.EXP_YEAR = 544 Then
                    class_xml.EXPDAY = ""
                    class_xml.EXPMONTH = ""
                    class_xml.EXP_YEAR = ""
                    class_xml.EXPDATESHORT = ""
                End If


            End If
        End If

        Dim aa As String = ""
        Dim aa2 As String = ""

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = dao_e.fields.register 'rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        Try
            'Dim dao_lcnsai As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
            'dao_lcnsai.GetDataby_u1(dao_e.fields.Newcode_not)
            If dao_e.fields.lcntpcd.Contains("ผย") Then
                If dao_e.fields.pvnabbr = "กท" Then
                    lcnno_format = CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
                Else
                    lcnno_format = dao_e.fields.pvnabbr & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2)
                End If

            Else
                lcnno_format = dao_e.fields.pvnabbr & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            End If

            'If dao_e.fields.pvnabbr <> "กท" Then
            '    lcnno_format = dao_e.fields.pvnabbr & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            'Else
            '    lcnno_format = CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            'End If

        Catch ex As Exception

        End Try
        'dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)

        Try
            rcvno_format = dao_e.fields.register_rcvno 'rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
        Catch ex As Exception

        End Try

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If


        Try
            rgtno_format = dao_e.fields.register
        Catch ex As Exception

        End Try


        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2

        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.IDA_dalcn) 'ข้อมูลสถานที่จำลอง

        Try
            Dim dt_thanm As DataTable = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_e.fields.Identify, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            For Each dr As DataRow In dt_thanm.Rows
                dr("thanm") = dao_e.fields.licen_loca
            Next
            'Dim dt_thanm2 As DataTable
            'dt_thanm2 = dt_thanm.Clone
            'Dim dr_nm As DataRow = dt_thanm2.NewRow()
            'dr_nm("thanm") = dao_e.fields.licen_loca
            'dt_thanm2.Rows.Add(dr_nm)
            class_xml.DT_SHOW.DT17 = dt_thanm
        Catch ex As Exception

        End Try

        Dim dao_det_prop As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR
        dao_det_prop.GetDataby_Newcode(newcode)
        Try
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.drgchrtha
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 1)
        class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 2)
        class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 10)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"

        class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 3)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"



        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        dao_dal.GetDataby_IDA(dao_lcn.fields.IDA)
        class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_NEWCODE_SAI(newcode)
        class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        class_xml.DT_SHOW.DT23 = bao_show.SP_drrgt_cas(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        class_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
        class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
        class_xml.DT_SHOW.DT23 = bao_show.SP_DRRGT_CAS_EQTO(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"


        Dim lcntype As String = "0" 'dao.fields.lcntpcd

        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_ProcessID)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
        Catch ex As Exception

        End Try
        p_dr = class_xml



        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_ProcessID, STATUS_ID, HiddenField2.Value, 0)
        '------------------------(E)------------------------
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try

            dao = New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)
            dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
            E_VALUE = dao_drgtpcd.fields.engdrgtpnm

        Catch ex As Exception

        End Try

        Dim NAME_TEMPLATE As String = ""
        If E_VALUE <> "(E)" Then
            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE

            If Request.QueryString("STATUS_ID") = "8" Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    'NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    Try
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                        dao_rg.GetDataby_IDA(_IDA)
                        dao_rq = New DAO_DRUG.ClsDBdrrqt
                        dao_rq.GetDataby_IDA(dao_rg.fields.FK_DRRQT)
                        Dim dao_tr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                        dao_tr.GetDataby_TAMRAP_ID(dao_rq.fields.dvcd)
                        If rgttpcd = "G" And dao_tr.fields.IS_AUTO = 1 Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        Else
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Else

            End If

            If Request.QueryString("STATUS_ID") = "14" And HiddenField2.Value = 1 Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                End If
            End If
        Else
            If Request.QueryString("STATUS_ID") = "8" Or Request.QueryString("STATUS_ID") = "14" Then
                NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"
            Else
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If
        End If

        '-----------------------------------------------------



        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_OUTPUT As String = ""
        Dim XML_PATH As String = ""

        If STATUS_ID = "1" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_UPLOAD"
            XML_PATH = "XML_TRADER_STAFF_UPLOAD"
        ElseIf STATUS_ID = "2" Or STATUS_ID = "3" Or STATUS_ID = "4" Then
            PDF_OUTPUT = "PDF_TRADER_STAFF_EMP"
            XML_PATH = "XML_TRADER_STAFF_EMP"
        Else
            PDF_OUTPUT = dao_pdftemplate.fields.PDF_OUTPUT
            XML_PATH = dao_pdftemplate.fields.XML_PATH
        End If

        If tamrap_id <> 0 Then
            If Request.QueryString("status") = "8" Then
                Dim dao3 As New DAO_DRUG.ClsDBdrrgt
                dao3.GetDataby_IDA(_IDA)
                dao_rq = New DAO_DRUG.ClsDBdrrqt
                Try
                    dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                    If dao_rq.fields.feetpcd = "1" Then
                        NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                    ElseIf dao_rq.fields.feetpcd = "99" Then
                        NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    End If
                Catch ex As Exception

                End Try

            ElseIf Request.QueryString("status") = "15" Or Request.QueryString("status") = "14" Then
                If HiddenField2.Value = "1" Then
                    dao_rq = New DAO_DRUG.ClsDBdrrqt
                    Try
                        dao_rq.GetDataby_IDA(_IDA)
                        If dao_rq.fields.feetpcd = "1" Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        ElseIf dao_rq.fields.feetpcd = "99" Then
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
                End If

            Else
                NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
            End If
        End If


        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE 'dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID) ' dao_pdftemplate.fields.PDF_OUTPUT
        Dim Path_XML As String = paths & XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID) 'dao_pdftemplate.fields.XML_PATH
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename

    End Sub
    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click

        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 1
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 0
        End If
        BindData_PDF()
    End Sub
End Class