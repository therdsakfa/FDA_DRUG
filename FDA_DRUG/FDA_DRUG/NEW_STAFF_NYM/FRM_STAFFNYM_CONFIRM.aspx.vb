Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports System.Globalization

Public Class FRM_STAFFNYM_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _process As String
    Private _YEARS As String
    Private _TR_ID As String
    Private _DL As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _IDA = Request.QueryString("IDA")
        _process = Request.QueryString("process")
        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        _DL = Request.QueryString("DL")
        '_YEARS = con_year(Date.Now.Year)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        Dim type As Integer
        If _ProcessID = 1026 Then
            type = 1
        ElseIf _ProcessID = 1027 Then
            type = 2
        ElseIf _ProcessID = 1028 Then
            type = 3
        ElseIf _ProcessID = 1029 Then
            type = 4
        ElseIf _ProcessID = 1031 Then
            type = 7
        End If


        If Not IsPostBack Then
            Try
                txt_appdate.Text = Date.Now.ToShortDateString()
            Catch ex As Exception

            End Try

            HiddenField2.Value = 0
            'BindData_PDF()
            BindData_PDF_RQT()
            'If _ProcessID = "1026" Then
            '    BindData_PDF2()
            'Else    'If _ProcessID = "1030" Then
            '    Binddata_NYM()
            '    'Else
            '    '    BindData_PDF()
            'End If
            Bind_ddl_Status_staff()
            load_fdpdtno()
            'UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH_IMPORT.loadatteachfromdrugimportupload(_IDA, type)
            ''''''''''''''''''''''''''''''''''''''''''''UC_GRID_ATTACH.loadatteachfromdrugimportupload(_IDA, type)
            set_hide(_IDA)

            'Try
            '    Dim dao As New DAO_DRUG.ClsDBdrsamp
            '    dao.GetDataby_IDA(_IDA)
            '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            '    dao_up.GetDataby_IDA(dao.fields.TR_ID)
            '    If dao_up.fields.PROCESS_ID = "1027" Or dao_up.fields.PROCESS_ID = "1028" Or dao_up.fields.PROCESS_ID = "1029" Then
            '        btn_drug_group.Style.Add("display", "block")
            '    End If
            'Catch ex As Exception

            'End Try


        End If
        set_lbl()
        show_btn(_IDA)
    End Sub

    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(ID)

        If dao.fields.STATUS_ID <> 6 Then
            btn_preview.Enabled = False
            ' btn_cancel.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
            'btn_preview.CssClass = "btn-danger btn-lg"

        End If


    End Sub
    ''' <summary>
    ''' เปิด/ปิด เมนูด้านข้าง
    ''' </summary>
    ''' <param name="IDA"></param>
    Public Sub set_hide(ByVal IDA As String)
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 6 Then
                remark_box.Style.Add("display", "block")
            End If
        ElseIf _ProcessID = 1027 Then                                                                            'ทำให้เป็น else if แยกนาม นยม         ตอนนี้ทำเป็นแค่ else เข้า 2 ทุกกรณีก่อน
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then                                            'status 8 approve disable every bottom 
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 9 Then
                remark_box.Style.Add("display", "block")
            End If
        ElseIf _ProcessID = 1028 Then                                                                            'ทำให้เป็น else if แยกนาม นยม         ตอนนี้ทำเป็นแค่ else เข้า 2 ทุกกรณีก่อน
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then                                            'status 8 approve disable every bottom 
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 9 Then
                remark_box.Style.Add("display", "block")
            End If
        ElseIf _ProcessID = 1029 Then                                                                            'ทำให้เป็น else if แยกนาม นยม         ตอนนี้ทำเป็นแค่ else เข้า 2 ทุกกรณีก่อน
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then                                            'status 8 approve disable every bottom 
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 9 Then
                remark_box.Style.Add("display", "block")
            End If
        ElseIf _ProcessID = 1030 Then                                                                            'ทำให้เป็น else if แยกนาม นยม         ตอนนี้ทำเป็นแค่ else เข้า 2 ทุกกรณีก่อน
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_5
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then                                            'status 8 approve disable every bottom 
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 9 Then
                remark_box.Style.Add("display", "block")
            End If
        ElseIf _ProcessID = 1031 Then                                                                            'ทำให้เป็น else if แยกนาม นยม         ตอนนี้ทำเป็นแค่ else เข้า 2 ทุกกรณีก่อน
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then                                            'status 8 approve disable every bottom 
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 9 Then
                remark_box.Style.Add("display", "block")
            End If
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
    ''' <summary>
    ''' นำข้อมูลมาใส่ใน label
    ''' </summary>
    Sub set_lbl()

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Dim dao_stat As New DAO_DRUG_IMPORT.TB_FDA_DRUG_STATUS_IMPORT_ALL
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(_IDA)

            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            Try    'ชื่อผู้ลงนาม
                dao_s.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
                lbl_staff_consider.Text = dao_s.fields.STAFF_OFFER_NAME
            Catch ex As Exception
                lbl_staff_consider.Text = "-"
            End Try

            Try
                lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
            Catch ex As Exception
                lbl_app_date.Text = "-"
            End Try

            Try    ' วันที่เสนอลงนาม
                lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_consider_date.Text = "-"
            End Try

            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 5)
                lbl_Status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception

            End Try
        ElseIf _ProcessID = 1027 Then
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
            dao.GetDataby_IDA(_IDA)

            Dim dao_app As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            Try    'ชื่อผู้ลงนาม                                                                'หาชื่อผู้ลงนาม
                'dao_s.GetDataby_IDA(dao.fields.NYM2_IDENTIFY_STAFF)
                lbl_staff_consider.Text = dao.fields.STAFF_NAME 'dao_s.fields.STAFF_OFFER_NAME
            Catch ex As Exception
                lbl_staff_consider.Text = "-"
            End Try

            Try
                lbl_app_date.Text = CDate(dao.fields.ESTIMATE_CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_app_date.Text = "-"
            End Try

            Try    ' วันที่เสนอลงนาม
                lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_consider_date.Text = "-"
            End Try

            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 9)
                lbl_Status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception

            End Try
        ElseIf _ProcessID = 1028 Then
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
            dao.GetDataby_IDA(_IDA)

            Dim dao_app As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            Try    'ชื่อผู้ลงนาม                                                                'หาชื่อผู้ลงนาม
                'dao_s.GetDataby_IDA(dao.fields.NYM3_IDENTIFY_STAFF)
                lbl_staff_consider.Text = dao.fields.STAFF_NAME 'dao_s.fields.STAFF_OFFER_NAME
            Catch ex As Exception
                lbl_staff_consider.Text = "-"
            End Try

            Try
                lbl_app_date.Text = CDate(dao.fields.ESTIMATE_CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_app_date.Text = "-"
            End Try

            Try    ' วันที่เสนอลงนาม
                lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_consider_date.Text = "-"
            End Try

            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 9)
                lbl_Status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception

            End Try
        ElseIf _ProcessID = 1029 Then
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
            dao.GetDataby_IDA(_IDA)

            Dim dao_app As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            Try    'ชื่อผู้ลงนาม                                                                'หาชื่อผู้ลงนาม
                'dao_s.GetDataby_IDA(dao.fields.NYM4_IDENTIFY_STAFF)
                lbl_staff_consider.Text = dao.fields.STAFF_NAME 'dao_s.fields.STAFF_OFFER_NAME
            Catch ex As Exception
                lbl_staff_consider.Text = "-"
            End Try

            Try
                lbl_app_date.Text = CDate(dao.fields.ESTIMATE_CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_app_date.Text = "-"
            End Try

            Try    ' วันที่เสนอลงนาม
                lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_consider_date.Text = "-"
            End Try

            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 9)
                lbl_Status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception

            End Try
        ElseIf _ProcessID = 1031 Then
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
            dao.GetDataby_IDA(_IDA)

            Dim dao_app As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            Try    'ชื่อผู้ลงนาม                                                                'หาชื่อผู้ลงนาม
                'dao_s.GetDataby_IDA(dao.fields.NYM4_IDENTIFY_STAFF)
                lbl_staff_consider.Text = dao.fields.STAFF_NAME 'dao_s.fields.STAFF_OFFER_NAME
            Catch ex As Exception
                lbl_staff_consider.Text = "-"
            End Try

            Try
                lbl_app_date.Text = CDate(dao.fields.ESTIMATE_CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_app_date.Text = "-"
            End Try

            Try    ' วันที่เสนอลงนาม
                lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_consider_date.Text = "-"
            End Try

            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 9)
                lbl_Status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception

            End Try
            'ElseIf _ProcessID = 1030 Then
            '    Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_5
            '    dao.GetDataby_IDA(_IDA)

            '    Dim dao_app As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            '    Try    'ชื่อผู้ลงนาม                                                                'หาชื่อผู้ลงนาม
            '        dao_s.GetDataby_IDA(dao.fields.NYM5_IDENTIFY_STAFF)
            '        lbl_staff_consider.Text = dao_s.fields.STAFF_OFFER_NAME
            '    Catch ex As Exception
            '        lbl_staff_consider.Text = "-"
            '    End Try

            '    Try
            '        lbl_app_date.Text = CDate(dao.fields.ESTIMATE_CONSIDER_DATE).ToShortDateString()
            '    Catch ex As Exception
            '        lbl_app_date.Text = "-"
            '    End Try

            '    Try    ' วันที่เสนอลงนาม
            '        lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            '    Catch ex As Exception
            '        lbl_consider_date.Text = "-"
            '    End Try

            '    Try
            '        dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 9)
            '        lbl_Status.Text = dao_stat.fields.STATUS_NAME
            '    Catch ex As Exception

            '    End Try
        End If
    End Sub
    Sub load_fdpdtno()
        Dim bao As New BAO.ClsDBSqlcommand
        'lbl_fdpdtno.Text = get_fdpdtno().Substring(0, 2) & "-" & get_fdpdtno().Substring(2, 1) & "-" & get_fdpdtno().Substring(3, 5) & "-" & get_fdpdtno().Substring(8, 1) & "-"
        'lbl_fdpdtno2.Text = _CLS.IDA    'ปรับให้runno

    End Sub
    Function get_fdpdtno() As String                                        'แก้ที่อยู่ของ PDF ก่อน
        Dim fdpdtno As String = String.Empty
        Dim pvncd As String = String.Empty
        Dim lcntypecd As String = String.Empty
        Dim lcnno_num As String = String.Empty
        Dim tpye As String = String.Empty
        Dim REF_NO As String = String.Empty
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim bao As New BAO.ClsDBSqlcommand
        dao_up.GetDataby_IDA(_CLS.IDA)
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        pvncd = dao.fields.pvncd.ToString()
        lcntypecd = dao.fields.lcntpcd.ToString()
        lcnno_num = dao.fields.lcnno.ToString().Trim().Substring(2, 5)
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

    ''' <summary>
    ''' กดยืนยัน
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    'Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click


    '    'Dim dao_up As New DAO_DRUG_IMPORT.ClsDBDRUG_IMPORT_UPLOAD          'ดึง เปลี่ยน linq 
    '    'Dim bao As New BAO.GenNumber
    '    'Dim dao_prf As New DAO_DRUG.ClsDB_nym_proof                         'เอาไว้ทำอะไร ยังไม่รู็ต้องแก้ 
    '    'Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value            '
    '    'Dim RCVNO As Integer


    '    'Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
    '    'If _ProcessID = 1026 Then
    '    '    Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
    '    '    dao.GetDataby_IDA(_IDA)
    '    '    dao_up.GetDataby_IDA(dao.fields.TR_ID)
    '    '    dao_prf.GetDataby_FK(dao.fields.IDA)
    '    '    Dim PROCESS_ID As Integer = dao_up.fields.FK_DRUG_IMPORT

    '    '    dao_date.fields.FK_IDA = _IDA
    '    '    Try
    '    '        dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
    '    '    Catch ex As Exception

    '    '    End Try

    '    '    dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
    '    '    dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
    '    '    dao_date.fields.DATE_NOW = Date.Now
    '    '    dao_date.fields.PROCESS_ID = 0
    '    '    dao_date.insert()


    '    '    If STATUS_ID = 3 Then
    '    '        dao.fields.STATUS_ID = STATUS_ID
    '    '        RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
    '    '        dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
    '    '        ' dao.fields.rcvr_id = _CLS.CITIZEN_ID

    '    '        dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
    '    '        Try
    '    '            dao.fields.DATE_RCV = Date.Now 'CDate(txt_app_date.Text)
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
    '    '        dao.fields.DATE_RCV = Date.Now.ToShortDateString()
    '    '        dao.update()

    '    '        dao_prf.fields.RCV_NO = RCVNO
    '    '        dao_prf.update()
    '    '        '-----------------ลิ้งไปหน้าคีย์มือ----------
    '    '        'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
    '    '        '--------------------------------
    '    '        alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
    '    '    ElseIf STATUS_ID = 6 Then
    '    '        Response.Redirect("FRM_STAFF_NYM_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
    '    '    ElseIf STATUS_ID = 8 Then

    '    '        dao.fields.STATUS_ID = STATUS_ID
    '    '        dao.fields.appdate = Date.Now.ToShortDateString()
    '    '        dao.fields.REMARK = txt_REMARK.Text
    '    '        dao_prf.fields.RCV_DATE = Date.Now
    '    '        If _ProcessID = "1028" Then
    '    '            dao_prf.fields.SENT_DATE = dao.fields.CONSIDER_DATE
    '    '            'Else
    '    '            '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
    '    '        End If
    '    '        dao_prf.update()

    '    '        package()

    '    '        dao.update()
    '    '        alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")

    '    '    ElseIf STATUS_ID = 7 Then
    '    '        Response.Redirect("FRM_STAFF_NYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
    '    '        AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
    '    '        '_TR_ID = Request.QueryString("TR_ID")
    '    '        '_IDA = Request.QueryString("IDA")
    '    '        'dao.update()
    '    '        'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
    '    '    End If
    '    'Else                                                                                'ถ้ากรณีอื่นๆ มีเยอะ 
    '    '    'Dim dao As New DAO_DRUG.ClsDBdrsamp
    '    '    Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
    '    '    dao.GetDataby_IDA(_IDA)
    '    '    dao_up.GetDataby_IDA(dao.fields.TR_ID)
    '    '    dao_prf.GetDataby_FK(dao.fields.IDA)                                            'เปลี่ยนอันนี้ 

    '    '    Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID                            '
    '    '    dao_date.fields.FK_IDA = _IDA
    '    '    Try
    '    '        dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
    '    '    Catch ex As Exception

    '    '    End Try

    '    '    dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ                               'ต้องปรับ base 
    '    '    dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
    '    '    dao_date.fields.DATE_NOW = Date.Now
    '    '    dao_date.fields.PROCESS_ID = 0
    '    '    dao_date.insert()


    '    '    If STATUS_ID = 3 Then                                                                       'สถานะรอการชำระเงิน       น่าจะต้องเปลี่ยนเป็น 4 ชำระเงินรอการตรวจสอบ          CODE เจน เลขรับ 
    '    '        dao.fields.STATUS_ID = STATUS_ID
    '    '        RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
    '    '        dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)                                              'RCVNO คืออะไร 
    '    '        dao.fields.rcvr_id = _CLS.CITIZEN_ID

    '    '        dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
    '    '        Try
    '    '            dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
    '    '        Catch ex As Exception

    '    '        End Try
    '    '        dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
    '    '        dao.update()

    '    '        dao_prf.fields.RCV_NO = RCVNO
    '    '        dao_prf.update()
    '    '        '-----------------ลิ้งไปหน้าคีย์มือ----------
    '    '        'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
    '    '        '--------------------------------
    '    '        alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
    '    '    ElseIf STATUS_ID = 6 Then                                                                                                       ' ยื่นแก้ไขคำขอ status 6 ของเราคือรอแก้ไข
    '    '        Response.Redirect("FRM_STAFF_NYM_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
    '    '    ElseIf STATUS_ID = 8 Then

    '    '        dao.fields.STATUS_ID = STATUS_ID
    '    '        dao.fields.appdate = Date.Now.ToShortDateString()                                                                           'app date มีไว้ทำไร
    '    '        dao.fields.REMARK = txt_REMARK.Text
    '    '        dao_prf.fields.RCV_DATE = Date.Now
    '    '        If _ProcessID = "1028" Then
    '    '            dao_prf.fields.SENT_DATE = dao.fields.event_end                                                     'น่าจะเก็บ log วันว่าวันไหน 
    '    '            'Else
    '    '            '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
    '    '        End If
    '    '        dao_prf.update()

    '    '        package()

    '    '        dao.update()
    '    '        alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")

    '    '    ElseIf STATUS_ID = 7 Then                                                                                   'คืนคำขอ ถึงต้องมี remark  หน้า remark เด้งขึ้นมา 
    '    '        Response.Redirect("FRM_STAFF_NYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
    '    '        AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
    '    '        '_TR_ID = Request.QueryString("TR_ID")
    '    '        '_IDA = Request.QueryString("IDA")
    '    '        'dao.update()
    '    '        'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
    '    '    End If
    '    'End If




    'End Sub
    'Sub alert_reload(ByVal text As String                                                                                                   'reload page 
    '    Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")

    '    Dim dao_n As New DAO_DRUG.ClsDBdalcn
    '    dao_n.GetDataby_IDA(_IDA)
    '    Try
    '        If dao_n.fields.SEND_POST = 1 Then
    '            '  Label2.Text = "รับด้วยตัวเอง"
    '        ElseIf dao_n.fields.SEND_POST = 2 Then
    '            '   Label2.Text = "ส่งไปรษณีย์"
    '        Else
    '            '   Label2.Text = "รับด้วยตัวเอง"
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Bind_ddl_Status_staff()
    '    BindData_PDF()
    'End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click


        Dim dao_up As New DAO_DRUG_IMPORT.ClsDBDRUG_IMPORT_UPLOAD          'ดึง เปลี่ยน linq 
        Dim bao As New BAO.GenNumber
        Dim dao_prf1 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_1
        Dim dao_prf2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2                       'เอาไว้ทำอะไร ยังไม่รู็ต้องแก้ 
        Dim dao_prf3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao_prf4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao_prf4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        Dim dao_prf5 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_5
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value            '
        Dim RCVNO As Integer
        If STATUS_ID = 8 Then
            txt_REMARK.Style.Add("display", "block")
        Else
            txt_REMARK.Style.Add("display", "none")
        End If

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            ' dao_prf.GetDataby_FK(dao.fields.IDA)
            Dim PROCESS_ID As Integer = dao_up.fields.FK_DRUG_IMPORT

            dao_date.fields.FK_IDA = _IDA
            Try
                dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
            dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            dao_date.fields.DATE_NOW = Date.Now
            dao_date.fields.PROCESS_ID = 0
            dao_date.insert()


            If STATUS_ID = 3 Then
                dao.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
                ' dao.fields.rcvr_id = _CLS.CITIZEN_ID

                dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao.fields.DATE_RCV = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
                dao.fields.DATE_RCV = Date.Now.ToShortDateString()
                dao.update()

                dao_prf1.fields.NYM1_RCVNO = RCVNO
                dao_prf1.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                '--------------------------------
                alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
            ElseIf STATUS_ID = 6 Then
                Response.Redirect("FRM_STAFF_NYM_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            ElseIf STATUS_ID = 5 Then
                Response.Redirect("../NEW_STAFF_NYM/FRM_STAFF_NYM_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            ElseIf STATUS_ID = 8 Then

                dao_prf2.fields.STATUS_ID = STATUS_ID
                dao_prf2.fields.APPROVE_DATE = CDate(txt_appdate.Text)
                dao_prf2.fields.REMARK = txt_REMARK.Text
                dao_prf2.fields.NYM2_RCVNO = Date.Now
                If _ProcessID = "1028" Then
                    'dao_prf.fields.SENT_DATE = dao.fields.CONSIDER_DATE
                    'Else
                    '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
                End If
                dao_prf2.update()

                'package()

                'dao_prf2.update()
                alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")

            ElseIf STATUS_ID = 7 Then
                Response.Redirect("FRM_STAFF_NYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                '_TR_ID = Request.QueryString("TR_ID")
                '_IDA = Request.QueryString("IDA")
                'dao.update()
                'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            End If
        ElseIf _ProcessID = 1027 Then                                                                                  'พรุ่งนี้แก้ไข ตรงนี้ ให้เสร็จ 

            ''Dim dao As New DAO_DRUG.ClsDBdrsamp
            'Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
            ''Dim log As New DAO_DRUG_IMPORT.TB_LOG_STATUS_IMPORT
            'dao.GetDataby_IDA(_IDA)
            'dao_up.GetDataby_IDAandtype(_IDA, _ProcessID)
            dao_prf2.GetDataby_IDA(_IDA)                                 'หาข้อมูลใน base
            '' dao_prf.GetDataby_FK(dao.fields.IDA)                                            'เปลี่ยนอันนี้ 

            'Dim PROCESS_ID As Integer = _ProcessID                    '
            'dao_date.fields.FK_IDA = _IDA
            'Try
            '    dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try

            'dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ                               'เหมือนตัวเก็บ log ต่างๆ
            'dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            'dao_date.fields.DATE_NOW = Date.Now
            'dao_date.fields.PROCESS_ID = _ProcessID
            'dao_date.insert()

            ''AddLogStatustodrugimport(9, _ProcessID, _CLS.CITIZEN_ID, _IDA)


            If STATUS_ID = 4 Then          'ไม่ได้ใช้นะ                                                              'สถานะรอการชำระเงิน       น่าจะต้องเปลี่ยนเป็น 4 ชำระเงินรอการตรวจสอบ          CODE เจน เลขรับ 
                dao_prf2.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
                dao_prf2.fields.NYM2_NO = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)                                              'RCVNO คืออะไร 
                '   dao.fields.TR_ID = _CLS.CITIZEN_ID

                'dao_prf2.fields.NYM2_RCVNO = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao_prf2.fields.STAFF_RECEIVE_IDEN = _CLS.CITIZEN_ID 'Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.FK_IDA = Date.Now.ToShortDateString()
                Try
                    dao_prf2.fields.rcvdate = CDate(txt_appdate.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.NYM2_RCVNO = RCVNO
                dao_prf2.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                '--------------------------------
                alert("บันทึกเรียบร้อย")
            ElseIf STATUS_ID = 7 Then
                'AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                'dao_prf2.GetDataby_IDA(_IDA)
                'dao_prf2.fields.STATUS_ID = STATUS_ID
                'dao_prf2.update()
                Response.Redirect("FRM_STAFFNYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&status=" & STATUS_ID)
                'ElseIf STATUS_ID = 9 Then                                                                                                       ' ยื่นแก้ไขคำขอ status 6 ของเราคือรอแก้ไข
                '    Response.Redirect("FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid

            ElseIf STATUS_ID = 9 Then
                Response.Redirect("../NEW_STAFF_NYM/FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid
            ElseIf STATUS_ID = 5 Then
                Response.Redirect("../NEW_STAFF_NYM/FRM_STAFF_NYM_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            ElseIf STATUS_ID = 8 Then
                'แก้ dao_prf

                If Len(txt_REMARK.Text) > 0 Then

                    dao_prf2.fields.STATUS_ID = STATUS_ID
                    dao_prf2.fields.APPROVE_DATE = CDate(txt_appdate.Text) 'Date.Now.ToShortDateString()                                                                           'app date มีไว้ทำไร
                    dao_prf2.fields.REMARK = txt_REMARK.Text
                    dao_prf2.fields.UPDATE_DATE = Date.Now
                    'If _ProcessID = "1028" Then
                    'dao_prf.fields.NYM2_WRITE_DATE = dao.fields.event_end                                                     'น่าจะเก็บ log วันว่าวันไหน 
                    'Else
                    '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
                    'End If
                    'dao_prf.update() ปิดไว้ก่อน

                    'package()
                    AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                    dao_prf2.update()
                    alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")

                    'ElseIf STATUS_ID = 7 Then                                                                                   'คืนคำขอ ถึงต้องมี remark  หน้า remark เด้งขึ้นมา 
                    '    Response.Redirect("FRM_STAFFNYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&status=" & STATUS_ID)
                    '    'AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                    '_TR_ID = Request.QueryString("TR_ID")
                    '_IDA = Request.QueryString("IDA")
                    'dao.update()
                    'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุณากรอกหมายเหตุ สำหรับการอนุมัติ');</script> ")
                End If
            End If
        ElseIf _ProcessID = 1028 Then                                                                                  'พรุ่งนี้แก้ไข ตรงนี้ ให้เสร็จ 

            dao_prf3.GetDataby_IDA(_IDA)                                 'หาข้อมูลใน base
            '' dao_prf.GetDataby_FK(dao.fields.IDA)                                            'เปลี่ยนอันนี้ 

            'Dim PROCESS_ID As Integer = _ProcessID                    '
            'dao_date.fields.FK_IDA = _IDA
            'Try
            '    dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try

            'dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ                               'เหมือนตัวเก็บ log ต่างๆ
            'dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            'dao_date.fields.DATE_NOW = Date.Now
            'dao_date.fields.PROCESS_ID = _ProcessID
            'dao_date.insert()

            ''AddLogStatustodrugimport(9, _ProcessID, _CLS.CITIZEN_ID, _IDA)


            If STATUS_ID = 4 Then          'ไม่ได้ใช้นะ                                                              'สถานะรอการชำระเงิน       น่าจะต้องเปลี่ยนเป็น 4 ชำระเงินรอการตรวจสอบ          CODE เจน เลขรับ 
                dao_prf3.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
                dao_prf3.fields.NYM3_NO = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)                                              'RCVNO คืออะไร 
                '   dao.fields.TR_ID = _CLS.CITIZEN_ID

                'dao_prf2.fields.NYM2_RCVNO = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao_prf3.fields.STAFF_RECEIVE_IDEN = _CLS.CITIZEN_ID 'Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.FK_IDA = Date.Now.ToShortDateString()
                Try
                    dao_prf3.fields.rcvdate = CDate(txt_appdate.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.NYM2_RCVNO = RCVNO
                dao_prf3.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                '--------------------------------
                alert("บันทึกเรียบร้อย")
            ElseIf STATUS_ID = 5 Then
                Response.Redirect("../NEW_STAFF_NYM/FRM_STAFF_NYM_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            ElseIf STATUS_ID = 7 Then
                'AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                'dao_prf2.GetDataby_IDA(_IDA)
                'dao_prf2.fields.STATUS_ID = STATUS_ID
                'dao_prf2.update()
                Response.Redirect("FRM_STAFFNYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&status=" & STATUS_ID)
                'ElseIf STATUS_ID = 9 Then                                                                                                       ' ยื่นแก้ไขคำขอ status 6 ของเราคือรอแก้ไข
                '    Response.Redirect("FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid

            ElseIf STATUS_ID = 9 Then
                Response.Redirect("FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid
            ElseIf STATUS_ID = 8 Then
                'แก้ dao_prf

                If Len(txt_REMARK.Text) > 0 Then
                    dao_prf3.fields.STATUS_ID = STATUS_ID
                    dao_prf3.fields.APPROVE_DATE = CDate(txt_appdate.Text) 'Date.Now.ToShortDateString()                                                                           'app date มีไว้ทำไร
                    dao_prf3.fields.REMARK = txt_REMARK.Text
                    dao_prf3.fields.UPDATE_DATE = Date.Now
                    'If _ProcessID = "1028" Then
                    'dao_prf.fields.NYM2_WRITE_DATE = dao.fields.event_end                                                     'น่าจะเก็บ log วันว่าวันไหน 
                    'Else
                    '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
                    'End If
                    'dao_prf.update() ปิดไว้ก่อน

                    'package()
                    AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                    dao_prf3.update()
                    alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุณากรอกหมายเหตุ สำหรับการอนุมัติ');</script> ")
                End If

            End If
        ElseIf _ProcessID = 1029 Then                                                                                  'พรุ่งนี้แก้ไข ตรงนี้ ให้เสร็จ 
            dao_prf4.GetDataby_IDA(_IDA)                                 'หาข้อมูลใน base
            '' dao_prf.GetDataby_FK(dao.fields.IDA)                                            'เปลี่ยนอันนี้ 

            'Dim PROCESS_ID As Integer = _ProcessID                    '
            'dao_date.fields.FK_IDA = _IDA
            'Try
            '    dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try

            'dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ                               'เหมือนตัวเก็บ log ต่างๆ
            'dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            'dao_date.fields.DATE_NOW = Date.Now
            'dao_date.fields.PROCESS_ID = _ProcessID
            'dao_date.insert()

            ''AddLogStatustodrugimport(9, _ProcessID, _CLS.CITIZEN_ID, _IDA)


            If STATUS_ID = 4 Then          'ไม่ได้ใช้นะ                                                              'สถานะรอการชำระเงิน       น่าจะต้องเปลี่ยนเป็น 4 ชำระเงินรอการตรวจสอบ          CODE เจน เลขรับ 
                dao_prf4.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
                dao_prf4.fields.NYM4_NO = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)                                              'RCVNO คืออะไร 
                '   dao.fields.TR_ID = _CLS.CITIZEN_ID

                'dao_prf2.fields.NYM2_RCVNO = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao_prf4.fields.STAFF_RECEIVE_IDEN = _CLS.CITIZEN_ID 'Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.FK_IDA = Date.Now.ToShortDateString()
                Try
                    dao_prf4.fields.rcvdate = CDate(txt_appdate.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.NYM2_RCVNO = RCVNO
                dao_prf4.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                '--------------------------------
                alert("บันทึกเรียบร้อย")
            ElseIf STATUS_ID = 7 Then
                'AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                'dao_prf2.GetDataby_IDA(_IDA)
                'dao_prf2.fields.STATUS_ID = STATUS_ID
                'dao_prf2.update()
                Response.Redirect("FRM_STAFFNYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&status=" & STATUS_ID)
                'ElseIf STATUS_ID = 9 Then                                                                                                       ' ยื่นแก้ไขคำขอ status 6 ของเราคือรอแก้ไข
                '    Response.Redirect("FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid
            ElseIf STATUS_ID = 5 Then
                Response.Redirect("../NEW_STAFF_NYM/FRM_STAFF_NYM_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            ElseIf STATUS_ID = 9 Then
                Response.Redirect("FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid
            ElseIf STATUS_ID = 8 Then
                'แก้ dao_prf

                If Len(txt_REMARK.Text) > 0 Then
                    dao_prf4.fields.STATUS_ID = STATUS_ID
                    dao_prf4.fields.APPROVE_DATE = CDate(txt_appdate.Text) 'Date.Now.ToShortDateString()                                                                           'app date มีไว้ทำไร
                    dao_prf4.fields.REMARK = txt_REMARK.Text
                    dao_prf4.fields.UPDATE_DATE = Date.Now
                    'If _ProcessID = "1028" Then
                    'dao_prf.fields.NYM2_WRITE_DATE = dao.fields.event_end                                                     'น่าจะเก็บ log วันว่าวันไหน 
                    'Else
                    '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
                    'End If
                    'dao_prf.update() ปิดไว้ก่อน

                    'package()
                    AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                    dao_prf4.update()
                    alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุณากรอกหมายเหตุ สำหรับการอนุมัติ');</script> ")
                End If


            End If
        ElseIf _ProcessID = 1031 Then                                                                                  'พรุ่งนี้แก้ไข ตรงนี้ ให้เสร็จ 
            dao_prf4_2.GetDataby_IDA(_IDA)                                 'หาข้อมูลใน base
            '' dao_prf.GetDataby_FK(dao.fields.IDA)                                            'เปลี่ยนอันนี้ 

            'Dim PROCESS_ID As Integer = _ProcessID                    '
            'dao_date.fields.FK_IDA = _IDA
            'Try
            '    dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try

            'dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ                               'เหมือนตัวเก็บ log ต่างๆ
            'dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            'dao_date.fields.DATE_NOW = Date.Now
            'dao_date.fields.PROCESS_ID = _ProcessID
            'dao_date.insert()

            ''AddLogStatustodrugimport(9, _ProcessID, _CLS.CITIZEN_ID, _IDA)


            If STATUS_ID = 4 Then          'ไม่ได้ใช้นะ                                                              'สถานะรอการชำระเงิน       น่าจะต้องเปลี่ยนเป็น 4 ชำระเงินรอการตรวจสอบ          CODE เจน เลขรับ 
                dao_prf4_2.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
                dao_prf4_2.fields.NYM4_COMPANY_NO = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)                                              'RCVNO คืออะไร 
                '   dao.fields.TR_ID = _CLS.CITIZEN_ID

                'dao_prf2.fields.NYM2_RCVNO = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao_prf4_2.fields.STAFF_RECEIVE_IDEN = _CLS.CITIZEN_ID 'Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.FK_IDA = Date.Now.ToShortDateString()
                Try
                    dao_prf4_2.fields.rcvdate = CDate(txt_appdate.Text)
                Catch ex As Exception

                End Try
                'dao_prf2.fields.NYM2_RCVNO = RCVNO
                dao_prf4_2.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                '--------------------------------
                alert("บันทึกเรียบร้อย")
            ElseIf STATUS_ID = 7 Then
                'AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                'dao_prf2.GetDataby_IDA(_IDA)
                'dao_prf2.fields.STATUS_ID = STATUS_ID
                'dao_prf2.update()
                Response.Redirect("FRM_STAFFNYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&status=" & STATUS_ID)
                'ElseIf STATUS_ID = 9 Then                                                                                                       ' ยื่นแก้ไขคำขอ status 6 ของเราคือรอแก้ไข
                '    Response.Redirect("FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid
            ElseIf STATUS_ID = 5 Then
                Response.Redirect("../NEW_STAFF_NYM/FRM_STAFF_NYM_EDIT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            ElseIf STATUS_ID = 9 Then
                Response.Redirect("FRM_STAFF_NYM_CONSIDER_NEW.aspx?IDA=" & _IDA & "&DL=" & _DL & "&process=" & _ProcessID) 'น่าจะต้องแก้ trid
            ElseIf STATUS_ID = 8 Then
                'แก้ dao_prf

                If Len(txt_REMARK.Text) > 0 Then
                    dao_prf4_2.fields.STATUS_ID = STATUS_ID
                    dao_prf4_2.fields.APPROVE_DATE = CDate(txt_appdate.Text) 'Date.Now.ToShortDateString()                                                                           'app date มีไว้ทำไร
                    dao_prf4_2.fields.REMARK = txt_REMARK.Text
                    dao_prf4_2.fields.UPDATE_DATE = Date.Now
                    'If _ProcessID = "1028" Then
                    'dao_prf.fields.NYM2_WRITE_DATE = dao.fields.event_end                                                     'น่าจะเก็บ log วันว่าวันไหน 
                    'Else
                    '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
                    'End If
                    'dao_prf.update() ปิดไว้ก่อน

                    'package()
                    AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                    dao_prf4_2.update()
                    alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
                Else
                    Response.Write("<script type='text/javascript'>alert('กรุณากรอกหมายเหตุ สำหรับการอนุมัติ');</script> ")
                End If


            End If
        End If
        AddLogStatustodrugimport(STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")            'กลับไปหน้าตาราง
        'ขาด status 9 และ update log status


    End Sub
    Sub alert_reload(ByVal text As String)                                   'reload page 
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
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim STATUS_ID As Integer = 0
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            If dao.fields.STATUS_ID <= 2 Then
                int_group_ddl = 1
            ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
                int_group_ddl = 2
            ElseIf dao.fields.STATUS_ID >= 6 Then
                int_group_ddl = 3
            End If
        ElseIf _ProcessID = 1027 Then                                                                              'กระบวนการอื่นๆ
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2                                     'เชื่อม base 
            dao.GetDataby_IDA(_IDA)
            ' dao_up.GetDataby_IDA(dao.fields.TR_ID)                                          'เอาข้อมูลจาก IDA
            STATUS_ID = dao.fields.STATUS_ID
            If dao.fields.STATUS_ID <= 3 Then                                                    'ถ้า starus2
                int_group_ddl = 11
                'ElseIf dao.fields.STATUS_ID = 4 Or dao.fields.STATUS_ID = 5 Then                                           'ถ้า starus มากกว่า 6
                '    int_group_ddl = 44
            ElseIf dao.fields.STATUS_ID = 5 Or dao.fields.STATUS_ID = 4 Then               'ถ้า starus2 to 6 
                int_group_ddl = 33
                'ElseIf dao.fields.STATUS_ID >= 6 Then                                      'แก้ตอนของ นยม อื่น 
                '    int_group_ddl = 33
            ElseIf dao.fields.STATUS_ID = 9 Then                                      'แก้ตอนของ นยม อื่น 
                int_group_ddl = 44
            End If
        ElseIf _ProcessID = 1028 Then                                                                              'กระบวนการอื่นๆ
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3                                     'เชื่อม base 
            dao.GetDataby_IDA(_IDA)
            STATUS_ID = dao.fields.STATUS_ID
            ' dao_up.GetDataby_IDA(dao.fields.TR_ID)                                          'เอาข้อมูลจาก IDA
            If dao.fields.STATUS_ID <= 3 Then                                                    'ถ้า starus2
                int_group_ddl = 11
                'ElseIf dao.fields.STATUS_ID = 4 Or dao.fields.STATUS_ID = 5 Then                                           'ถ้า starus มากกว่า 6
                '    int_group_ddl = 44
            ElseIf dao.fields.STATUS_ID = 5 Or dao.fields.STATUS_ID = 4 Then               'ถ้า starus2 to 6 
                int_group_ddl = 33
                'ElseIf dao.fields.STATUS_ID >= 6 Then                                      'แก้ตอนของ นยม อื่น 
                '    int_group_ddl = 33
            ElseIf dao.fields.STATUS_ID = 9 Then                                      'แก้ตอนของ นยม อื่น 
                int_group_ddl = 44
            End If
        ElseIf _ProcessID = 1029 Then                                                                              'กระบวนการอื่นๆ
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4                                     'เชื่อม base 
            dao.GetDataby_IDA(_IDA)
            STATUS_ID = dao.fields.STATUS_ID
            ' dao_up.GetDataby_IDA(dao.fields.TR_ID)                                          'เอาข้อมูลจาก IDA
            If dao.fields.STATUS_ID <= 3 Then                                                    'ถ้า starus2
                int_group_ddl = 11
                'ElseIf dao.fields.STATUS_ID = 4 Or dao.fields.STATUS_ID = 5 Then                                           'ถ้า starus มากกว่า 6
                '    int_group_ddl = 44
            ElseIf dao.fields.STATUS_ID = 5 Or dao.fields.STATUS_ID = 4 Then               'ถ้า starus2 to 6 
                int_group_ddl = 33
                'ElseIf dao.fields.STATUS_ID >= 6 Then                                      'แก้ตอนของ นยม อื่น 
                '    int_group_ddl = 33
            ElseIf dao.fields.STATUS_ID = 9 Then                                      'แก้ตอนของ นยม อื่น 
                int_group_ddl = 44
            End If
        ElseIf _ProcessID = 1030 Then                                                                              'กระบวนการอื่นๆ
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_5                                     'เชื่อม base 
            dao.GetDataby_IDA(_IDA)
            STATUS_ID = dao.fields.STATUS_ID
            ' dao_up.GetDataby_IDA(dao.fields.TR_ID)                                          'เอาข้อมูลจาก IDA
            If dao.fields.STATUS_ID <= 2 Then                                                    'ถ้า starus2
                int_group_ddl = 11
            ElseIf dao.fields.STATUS_ID = 4 Or dao.fields.STATUS_ID = 5 Then                                           'ถ้า starus มากกว่า 6
                int_group_ddl = 33
                'ElseIf dao.fields.STATUS_ID > 5 And dao.fields.STATUS_ID <= 9 Then               'ถ้า starus2 to 6 
                '    int_group_ddl = 33
            ElseIf dao.fields.STATUS_ID = 9 Then                                      'แก้ตอนของ นยม อื่น 
                int_group_ddl = 44
            End If
        ElseIf _ProcessID = 1031 Then                                                                              'กระบวนการอื่นๆ
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY                                 'เชื่อม base 
            dao.GetDataby_IDA(_IDA)
            STATUS_ID = dao.fields.STATUS_ID
            ' dao_up.GetDataby_IDA(dao.fields.TR_ID)                                          'เอาข้อมูลจาก IDA
            If dao.fields.STATUS_ID <= 2 Then                                                    'ถ้า starus2
                int_group_ddl = 11
            ElseIf dao.fields.STATUS_ID = 4 Or dao.fields.STATUS_ID = 5 Then                                           'ถ้า starus มากกว่า 6
                int_group_ddl = 33
                'ElseIf dao.fields.STATUS_ID > 5 And dao.fields.STATUS_ID <= 9 Then               'ถ้า starus2 to 6 
                '    int_group_ddl = 33
            ElseIf dao.fields.STATUS_ID = 9 Then                                      'แก้ตอนของ นยม อื่น 
                int_group_ddl = 44
            End If
        End If

        dt = bao.SP_STATUS_IMPORT_STAFF_BY_GROUP_DDL(99, int_group_ddl)


        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME_STAFF"
        ddl_cnsdcd.DataBind()
        Dim item As New ListItem
        item.Text = "กรุณาเลือกสถานะ"
        item.Value = "0"
        ddl_cnsdcd.Items.Insert(0, item)

        If STATUS_ID = 3 Then
            Dim item2 As New ListItem
            item2.Text = "คืนให้แก้ไขคำขอ"
            item2.Value = "5"
            ddl_cnsdcd.Items.Insert(ddl_cnsdcd.Items.Count - 1, item2)
        End If
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_pdf(HiddenField1.Value, HiddenField3.Value)
    End Sub

    Sub load_pdf(ByVal path As String, ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename)

            Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

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
    End Sub
    'Private Sub Binddata_NYM()
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim dao As New DAO_DRUG.ClsDBdrsamp
    '    dao.GetDataby_IDA(_IDA)
    '    Dim dao_xml As New DAO_DRUG.clsDBXML_NAME
    '    dao_xml.GetDataby_TR_PROCESS(_TR_ID, _ProcessID)
    '    path_XML = dao_xml.fields.PATH + dao_xml.fields.XML_NAME
    '    Dim statusId As Integer = dao.fields.STATUS_ID
    '    Dim lcntype As String = dao.fields.lcntpcd
    '    Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    dao_tr.GetDataby_IDA(dao.fields.TR_ID)
    '    Dim _YEARS As String = dao_tr.fields.YEAR
    '    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '    dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

    '    Dim paths As String = bao._PATH_DEFAULT

    '    Dim PDF_TEMPLATE As String = ""
    '    Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)

    '    'If _ProcessID = "1027" Then
    '    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'ElseIf _ProcessID = "1028" Then
    '    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'ElseIf _ProcessID = "1029" Then
    '    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'ElseIf _ProcessID = "1030" Then
    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'End If
    '    LOAD_XML_PDF1(path_XML, PDF_TEMPLATE, _ProcessID, filename)
    '    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
    '    hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
    '    HiddenField1.Value = filename
    '    _CLS.FILENAME_PDF = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    _CLS.PDFNAME = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    'End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings

        Dim dao_up As New DAO_DRUG_IMPORT.ClsDBDRUG_IMPORT_UPLOAD
        dao_up.GetDataby_IDA(_IDA)                                      ' 
        ' Dim dao As New DAO_DRUG_IMPORT
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4

        dao2.getdata_dl(_IDA)
        dao3.getdata_dl(_IDA)
        dao4.getdata_dl(_IDA)
        Dim class_xml2 As New CLASS_NYM_2
        Dim class_xml3 As New CLASS_NYM_3_SM
        Dim class_xml4 As New CLASS_NYM_4_SM


        ' class_xml = cls_dalcn.gen_xml()
        class_xml2.NYM_2s = dao2.fields
        class_xml3.NYM_3s = dao3.fields
        class_xml4.NYM_4s = dao4.fields


        'Dim p_noryormor2 As New CLASS_NYM_2
        'p_noryormor2 = p_nym2
        'p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_noryormor2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_noryormor2)

        Dim bao_show As New BAO_SHOW
        class_xml2.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2(_IDA)
        class_xml3.DT_SHOW.DT25 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM3(_IDA)
        class_xml4.DT_SHOW.DT27 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4(_IDA)

        p_nym2 = class_xml2
        p_nym3 = class_xml3
        p_nym4 = class_xml4
        Dim dao_nym2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao_nym3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao_nym4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        dao_nym2.getdata_dl(_DL)
        dao_nym3.getdata_dl(_DL)
        dao_nym4.getdata_dl(_DL)
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim paths As String = bao._PATH_DEFAULT                                         ' PART ต้องเป็น defult ก่อน 




        ''''''''' แก้ตรงนี้ PDF ไม่ขึ้นนะเพื่อน เรื่องมันเศร้า ขอข้ามไปทำอย่างอื่นก่อน



        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0) 'DAO บรรทัด 2809 _process เป็นค่า string  แต่ฟังชั่นนี้เป็น integer
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim year As String = Date.Now.Year
        If _ProcessID = 1027 Then
            Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, year, dao_nym2.fields.DL) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, year, dao_nym2.fields.DL)

            LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML  เอง AUTO        DAO COMMON  483 558 602 และ  CLASS GEN XML


            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
            hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


            HiddenField1.Value = filename
            _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, year, dao_nym2.fields.DL)
            _CLS.PDFNAME = filename
        ElseIf _ProcessID = 1028 Then
            Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, year, dao_nym3.fields.DL) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, year, dao_nym3.fields.DL)

            LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML  เอง AUTO        DAO COMMON  483 558 602 และ  CLASS GEN XML


            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
            hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


            HiddenField1.Value = filename
            _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, year, dao_nym3.fields.DL)
            _CLS.PDFNAME = filename
        ElseIf _ProcessID = 1029 Then
            Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, year, dao_nym4.fields.DL) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, year, dao_nym4.fields.DL)

            LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML  เอง AUTO        DAO COMMON  483 558 602 และ  CLASS GEN XML


            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
            hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


            HiddenField1.Value = filename
            _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, year, dao_nym4.fields.DL)
            _CLS.PDFNAME = filename
        ElseIf _ProcessID = 1030 Then
            Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, year, dao_nym4.fields.DL) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, year, dao_nym4.fields.DL)

            LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML  เอง AUTO        DAO COMMON  483 558 602 และ  CLASS GEN XML


            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
            hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


            HiddenField1.Value = filename
            _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, year, dao_nym4.fields.DL)
            _CLS.PDFNAME = filename
        End If

        'load_PDF(filename)

        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub

    Private Sub BindData_PDF_RQT()
        Dim bao As New BAO.AppSettings

        Dim dao_up As New DAO_DRUG_IMPORT.ClsDBDRUG_IMPORT_UPLOAD
        dao_up.GetDataby_IDA(_IDA)                                      ' 
        ' Dim dao As New DAO_DRUG_IMPORT
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY


        Dim NYM_STATUS As Integer = 0
        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_rg.GetDataby_IDA(_DL)
        Catch ex As Exception

        End Try
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim drug_name As String = ""
        Try
            drug_name_th = dao_rg.fields.DRUG_NAME_THAI
        Catch ex As Exception

        End Try
        Try
            drug_name_eng = dao_rg.fields.DRUG_NAME_OTHER
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

        dao2.GetDataby_IDA(_IDA)
        dao3.getdata_ida(_IDA)
        dao4.getdata_ida(_IDA)
        dao4_2.getdata_ida(_IDA)
        Dim class_xml21 As New CLASS_NYM_2
        'Dim class_xml22 As New CLASS_NYM_2
        Dim class_xml3 As New CLASS_NYM_3_SM
        Dim class_xml4 As New CLASS_NYM_4_SM
        Dim class_xml4_2 As New CLASS_NYM_4_COMPANY

        Try
            class_xml21.NYM_2s = dao2.fields
        Catch ex As Exception

        End Try
        Try
            class_xml3.NYM_3s = dao3.fields
        Catch ex As Exception

        End Try
        Try
            class_xml4.NYM_4s = dao4.fields
        Catch ex As Exception

        End Try
        Try
            class_xml4_2.NYM_4_COMPANYs = dao4_2.fields
        Catch ex As Exception

        End Try
        'class_xml21.NYM_2s = dao2.fields
        'class_xml22.NYM_2s = dao2.fields



        'Dim p_noryormor2 As New CLASS_NYM_2
        'p_noryormor2 = p_nym2
        'p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_noryormor2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_noryormor2)

        Dim bao_show As New BAO_SHOW
        'class_xml2.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2(_IDA)



        'แก้ตรงนี้

        Dim bao_n As New BAO.ClsDBSqlcommand
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(dao_rg.fields.FK_IDA)

        Catch ex As Exception

        End Try
        If _process = 1027 Then
            Try
                NYM_STATUS = dao2.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml21.SMALL_UNIT = CStr(dao2.fields.NYM2_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            Try
                class_xml21.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            class_xml21.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2_ONLY1(_IDA)
            class_xml21.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2(_IDA) '76 66
            class_xml21.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml21.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml21.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            Try
                class_xml21.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            class_xml21.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml21.REMARK = dao2.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml21.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml21.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml21.PACK_SIZE = "-"
            End Try
            Try
                class_xml21.LONG_APPDATE = CDate(dao2.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml21.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao2.fields.NYM2_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao2.fields.NYM2_NO, 5))) & "/" & Left(dao2.fields.NYM2_NO, 2)
                        class_xml21.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml21.LONG_RCVDATE = CDate(dao2.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                'Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                'dao_st.GetDataby_IDA(dao2.fields.NYM2_IDENTIFY_STAFF)
                class_xml21.APPROVE_NAME = dao2.fields.STAFF_NAME  'dao_st.fields.STAFF_OFFER_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml21.RECEIVER_NAME = set_name_company(dao2.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try

            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml21.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml21.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml21.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml21.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml21.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml21.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml21.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml21.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml21.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml21.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml21.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try
        ElseIf _process = 1028 Then
            Try
                NYM_STATUS = dao3.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try

                class_xml3.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml3.SMALL_UNIT = CStr(dao3.fields.NYM3_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            class_xml3.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM3_ONLY1(_IDA)
            class_xml3.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM3(_IDA)                        'แก้ตรงนี้ 
            class_xml3.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml3.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml3.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            class_xml3.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml3.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            Try
                class_xml3.REMARK = dao3.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml3.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml3.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml3.PACK_SIZE = "-"
            End Try
            Try
                class_xml3.LONG_APPDATE = CDate(dao3.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml3.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao3.fields.NYM3_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao3.fields.NYM3_NO, 5))) & "/" & Left(dao3.fields.NYM3_NO, 2)
                        class_xml3.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml3.LONG_RCVDATE = CDate(dao3.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao_st.GetDataby_IDA(dao3.fields.NYM3_IDENTIFY_STAFF)
                'class_xml3.APPROVE_NAME = dao_st.fields.STAFF_OFFER_NAME
                class_xml3.APPROVE_NAME = dao3.fields.STAFF_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml3.RECEIVER_NAME = set_name_company(dao3.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try

            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml3.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml3.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml3.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml3.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml3.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml3.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml3.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml3.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml3.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml3.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml3.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try
        ElseIf _process = 1029 Then
            Try
                NYM_STATUS = dao4.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try

                class_xml4.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml4.SMALL_UNIT = CStr(dao4.fields.NYM4_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            class_xml4.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4_ONLY1(_IDA)
            class_xml4.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4(_IDA)
            class_xml4.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml4.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml4.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            class_xml4.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml4.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            Try
                class_xml4.REMARK = dao4.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml4.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml4.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml4.PACK_SIZE = "-"
            End Try
            Try
                class_xml4.LONG_APPDATE = CDate(dao4.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml4.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao4.fields.NYM4_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao4.fields.NYM4_NO, 5))) & "/" & Left(dao4.fields.NYM4_NO, 2)
                        class_xml4.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml4.LONG_RCVDATE = CDate(dao4.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao_st.GetDataby_IDA(dao4.fields.NYM4_IDENTIFY_STAFF)
                'class_xml4.APPROVE_NAME = dao_st.fields.STAFF_OFFER_NAME
                class_xml4.APPROVE_NAME = dao4.fields.STAFF_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml4.RECEIVER_NAME = set_name_company(dao4.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try
            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml4.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml4.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml4.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml4.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml4.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml4.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml4.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try

        ElseIf _process = 1031 Then
            Try
                NYM_STATUS = dao4_2.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try

                class_xml4_2.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml4_2.SMALL_UNIT = CStr(dao4_2.fields.NYM4_COMPANY_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            class_xml4_2.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4_2_ONLY1(_IDA)
            class_xml4_2.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4_2(_IDA)
            class_xml4_2.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml4_2.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml4_2.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            class_xml4_2.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml4_2.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.REMARK = dao4_2.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml4_2.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml4_2.PACK_SIZE = "-"
            End Try
            Try
                class_xml4_2.LONG_APPDATE = CDate(dao4_2.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao4_2.fields.NYM4_COMPANY_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao4.fields.NYM4_NO, 5))) & "/" & Left(dao4_2.fields.NYM4_COMPANY_NO, 2)
                        class_xml4_2.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.LONG_RCVDATE = CDate(dao4_2.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao_st.GetDataby_IDA(dao4_2.fields.NYM4_IDENTIFY_STAFF)
                'class_xml4_2.APPROVE_NAME = dao_st.fields.STAFF_OFFER_NAME
                class_xml4_2.APPROVE_NAME = dao4_2.fields.STAFF_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.RECEIVER_NAME = set_name_company(dao4_2.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try
            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml4_2.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4_2.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4_2.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml4_2.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml4_2.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4_2.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4_2.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml4_2.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml4_2.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml4_2.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml4_2.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try
        End If




        Dim dao_nym2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao_nym3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao_nym4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao_nym4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        If _process = 1027 Then
            dao_nym2.GetDataby_IDA(_IDA)                                                     'ดึงข่้อมูลจาก IDA
        ElseIf _process = 1028 Then
            dao_nym3.GetDataby_IDA(_IDA)                                                     'ดึงข่้อมูลจาก IDA
        ElseIf _process = 1029 Then
            dao_nym4.GetDataby_IDA(_IDA)                                                     'ดึงข่้อมูลจาก IDA
        ElseIf _process = 1031 Then
            dao_nym4_2.GetDataby_IDA(_IDA)
        End If

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim paths As String = bao._PATH_DEFAULT                                         ' PART ต้องเป็น defult ก่อน 

        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, NYM_STATUS, 0)                     'DAO บรรทัด 2809
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim year As String = Date.Now.Year
        'Path_XML มาจาก ข้างบน ถ้าเปลี่ยน ที่อยู่ path มีตัวแปล paths dao_nym3 dao_pdftemplate
        Dim filename As String = ""
        Dim Path_XML As String = ""
        If _process = 1027 Then
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym2.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym2.fields.TR_ID) 'load_PDF(filename)
        ElseIf _process = 1028 Then
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym3.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym3.fields.TR_ID) 'load_PDF(filename)                       BAO_COMMOND 627
        ElseIf _process = 1029 Then
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym4.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym4.fields.TR_ID) 'load_PDF(filename)
        ElseIf _process = 1031 Then
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym4_2.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym4_2.fields.TR_ID) 'load_PDF(filename)
        End If

        Try
            Dim url As String = ""
            url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename

            class_xml21.QR_CODE = QR_CODE_IMG(url)
            class_xml3.QR_CODE = QR_CODE_IMG(url)
            class_xml4.QR_CODE = QR_CODE_IMG(url)
            class_xml4_2.QR_CODE = QR_CODE_IMG(url)
        Catch ex As Exception

        End Try
        p_nym2 = class_xml21
        p_nym3 = class_xml3
        p_nym4 = class_xml4
        p_nym4_2 = class_xml4_2
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML  เอง AUTO        DAO COMMON  483 558 602 และ  CLASS GEN XML


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>" 'แสดงไฟล์บนหน้าเว็บ
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่ ACOBAT


        HiddenField1.Value = filename
        If _process = 1027 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym2.fields.TR_ID)
        ElseIf _process = 1028 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym3.fields.TR_ID)
        ElseIf _process = 1029 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym4.fields.TR_ID)
        ElseIf _process = 1031 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym4_2.fields.TR_ID)
        End If
        _CLS.PDFNAME = filename

    End Sub

    'Private Sub BindData_PDF2(Optional _group As Integer = 0)
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
    '    dao.GetDataby_IDA(_IDA)
    '    Dim dao_xml As New DAO_DRUG.clsDBXML_NAME
    '    dao_xml.GetDataby_TR_PROCESS(_TR_ID, _ProcessID)
    '    path_XML = dao_xml.fields.PATH + dao_xml.fields.XML_NAME
    '    Dim statusId As Integer = dao.fields.STATUS_ID
    '    Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    dao_tr.GetDataby_IDA(dao.fields.TR_ID)
    '    Dim _YEARS As String = dao_tr.fields.YEAR
    '    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '    dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, 0, statusId, 0)

    '    Dim paths As String = bao._PATH_DEFAULT

    '    Dim PDF_TEMPLATE As String = ""
    '    Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)

    '    'If _ProcessID = "1027" Then
    '    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'ElseIf _ProcessID = "1028" Then
    '    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'ElseIf _ProcessID = "1029" Then
    '    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'ElseIf _ProcessID = "1030" Then
    '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'End If
    '    LOAD_XML_PDF1(path_XML, PDF_TEMPLATE, _ProcessID, filename)
    '    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
    '    hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
    '    HiddenField1.Value = filename
    '    _CLS.FILENAME_PDF = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    _CLS.PDFNAME = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    'Dim bao As New BAO.AppSettings
    '    'bao.RunAppSettings()

    '    ''Dim dao As New DAO_DRUG.ClsDBdrsamp
    '    'Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
    '    'dao.GetDataby_IDA(_IDA)
    '    'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    'dao_tr.GetDataby_IDA(dao.fields.TR_ID)

    '    'Dim _YEARS As String = dao_tr.fields.YEAR

    '    ''Dim cls_regis As New CLASS_GEN_XML.NYM1(_IDA, dao.fields.lcnno, dao.fields.PJSUM_IDA, dao_tr.fields.CITIEZEN_ID, dao_tr.fields.CITIEZEN_ID_AUTHORIZE)
    '    'Dim cls_regis As New CLASS_GEN_XML.NYM1(_IDA, 0, dao.fields.IDA, dao_tr.fields.CITIEZEN_ID, dao_tr.fields.CITIEZEN_ID_AUTHORIZE)
    '    'Dim class_xml As New CLASS_PROJECT_SUM
    '    'class_xml = cls_regis.gen_xml_NYM1()
    '    'p_nym1 = class_xml

    '    'Dim statusId As Integer = dao.fields.STATUS_ID
    '    ''Dim lcntype As String = dao.fields.lcntpcd
    '    'Dim lcntype As String = 0
    '    'Dim paths As String = bao._PATH_DEFAULT
    '    'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '    'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(_ProcessID, lcntype, statusId, 0)

    '    'Dim filetemplate As String = bao._PATH_PDF_TEMPLATE & dao_pdftemplate.fields.PDF_TEMPLATE
    '    'Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
    '    'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)

    '    'LOAD_XML_PDF1(Path_XML, filetemplate, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

    '    'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
    '    'hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
    '    'HiddenField1.Value = filename
    '    'HiddenField3.Value = NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)
    '    '    show_btn() 'ตรวจสอบปุ่ม

    'End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
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
        'Dim template_id As Integer = 0
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        'Dim _group As Integer = 0
        'Try
        '    template_id = dao.fields.TEMPLATE_ID
        'Catch ex As Exception

        'End Try
        'If template_id = 2 Then
        '    _group = 9
        'End If

        '_group:=_group
        'BindData_PDF(_group:=_group)

    End Sub

    'Private Sub btn_drug_group_Click(sender As Object, e As EventArgs) Handles btn_drug_group.Click
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx?ida=" & Request.QueryString("ida") & "'); ", True)
    'End Sub

    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email


        mm.SendMail(mcontent)

    End Sub

    Sub package()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        If _ProcessID = "1026" Then
            Dim pack As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
            pack.GetDataby_PROJECT(_IDA)

            Dim date_add = Date.Now
            Dim order_id As Integer = 0

            For Each pack.fields In pack.datas
                order_id = order_id + 1
                pack.fields.DATE_ADD = date_add
                pack.fields.order_id = order_id
                pack.fields.is_used = 1

                Dim sum As Integer = CInt(pack.fields.sunit) * CInt(pack.fields.munit)
                sum = sum * CInt(pack.fields.imp_amount)
                pack.fields.SUM = sum
                pack.fields.IM_DETAIL = pack.fields.packnm & " นำเข้า " & pack.fields.imp_amount & " " & pack.fields.bunitnm & " (" & sum & " " & pack.fields.sunitnm & ")"

                pack.update()
            Next

            Dim dao_pj As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao_pj.GetDataby_IDA(_IDA)
            dao_pj.fields.STATUS_ID = 8
            dao_pj.update()

        Else
            Dim pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
            pack.GetData_chk_by_FK_drsamp(_IDA)

            Dim date_add = Date.Now
            Dim order_id As Integer = 0

            For Each pack.fields In pack.datas
                order_id = order_id + 1
                pack.fields.DATE_ADD = date_add
                pack.fields.order_id = order_id
                pack.update()
            Next
        End If

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txt_REMARK.Visible = True
        Else
            txt_REMARK.Visible = False
        End If
    End Sub

    Protected Sub ddl_cnsdcd_SelectedIndexChanged(sender As Object, e As EventArgs)

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
            fullname = ""
        End Try

        Return fullname
    End Function
End Class