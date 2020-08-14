Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Public Class FRM_EXTEND_TIME_LOCATION_MAIN_USER
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    Private WithEvents timer As New System.Timers.Timer
    Private _staff As String
    Private _identify As String

    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()
        Try
            _staff = Request.QueryString("staff")
        Catch ex As Exception

        End Try
        Try
            _process = Request.QueryString("process")
            If _process = "101" Or _process = "102" Or _process = "103" Or _process = "104" Then
                _process = "100741"
            ElseIf _process = "106" Then
                _process = "100742"
            ElseIf _process = "105" Then
                _process = "100743"
            ElseIf _process = "107" Or _process = "108" Or _process = "109" Then
                _process = "100744"
            ElseIf _process = "111" Then
                _process = "100745"
            ElseIf _process = "113" Then
                _process = "100746"
            ElseIf _process = "110" Then
                _process = "100747"
            ElseIf _process = "119" Then
                _process = "100748"
            ElseIf _process = "114" Or _process = "115" Or _process = "116" Or _process = "117" Then
                _process = "100749"
            ElseIf _process = "112" Then
                _process = "100750"
            ElseIf _process = "120" Then
                _process = "100751" 'ขสม
            ElseIf _process = "121" Then
                _process = "100751" 'นสม
            ElseIf _process = "122" Then
                _process = "100751" 'ผสม
            End If
        Catch ex As Exception

        End Try
        Try
            _identify = Request.QueryString("identify")
        Catch ex As Exception

        End Try
        Try
            _lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception

        End Try
        Try
            _lcn_ida = Request.QueryString("lcn_ida")
        Catch ex As Exception

        End Try
        Try
            _type = Request.QueryString("type")
        Catch ex As Exception

        End Try
        Try

        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            'เรียก Process ที่เราเรียก
            '_process_for = Request.QueryString("process_for")



            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ต่ออายุ", _process)
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ต่ออายุ", _process)
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ต่ออายุ", _process)

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ต่ออายุ", _process)

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        get_pvncd()
        If Not IsPostBack Then
            'ให้รันฟังก์ชั่นลำดับที่ 2
            load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
            'load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
            load_HL()
            set_lbl_header()
            Open_or_Close()
        End If
        UC_INFMT.Shows(_lct_ida)
    End Sub
    Sub Open_or_Close()
        If Request.QueryString("staff") = "" Then
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE_OPEN
            Dim i As Integer = 0
            i = dao.Sum_val()
            If i = 1 Then
                btn_upload.Enabled = False
            End If
        End If
    End Sub

    Private Sub load_HL()
        'Dim ws As New AUTHEN_LOG.Authentication
        ''ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ชำระเงินต่ออายุใบอนุญาต", _process)
        'Dim ws_118 As New WS_AUTHENTICATION.Authentication
        'Dim ws_66 As New Authentication_66.Authentication
        'Dim ws_104 As New AUTHENTICATION_104.Authentication
        'Try
        '    ws_118.Timeout = 10000
        '    ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ชำระเงินต่ออายุใบอนุญาต", _process)
        'Catch ex As Exception
        '    Try
        '        ws_66.Timeout = 10000
        '        ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ชำระเงินต่ออายุใบอนุญาต", _process)

        '    Catch ex2 As Exception
        '        Try
        '            ws_104.Timeout = 10000
        '            ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ชำระเงินต่ออายุใบอนุญาต", _process)

        '        Catch ex3 As Exception
        '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
        '        End Try
        '    End Try
        'End Try

        hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
        If Request.QueryString("staff") = "1" Then
            hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug&identify=" & _identify
            'hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        End If
    End Sub
    'Private Sub load_lbl_name()

    '    Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
    '    dao_menu.GetDataby_Process2(_process)

    '    Dim dao_menu2 As New DAO_DRUG.ClsDBMAS_MENU
    '    dao_menu2.GetDataby_Process2(_process_for)
    '    If String.IsNullOrEmpty(_process_for) = False Then
    '        lbl_name_2.Text = " (" & dao_menu2.fields.NAME & ") > "
    '    End If

    '    lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง

    'End Sub
    Sub set_lbl_header()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        lbl_name_2.Text = "คำขอต่ออายุใบอนุญาต"
        If _process = "100741" Then
            If dao_lcn.fields.lcntpcd = "ขย1" Then
                lbl_name.Text = "ขายยาแผนปัจจุบัน (ขย15)"
            End If
            If dao_lcn.fields.lcntpcd = "ขย2" Then
                lbl_name.Text = "ขายยาแผนปัจจุบันเฉพาะยาบรรจุเสร็จที่ไม่ใช่ยาอันตรายหรือยาควบคุมพิเศษ (ขย15)"
            End If
            If dao_lcn.fields.lcntpcd = "ขย3" Then
                lbl_name.Text = "ขายยาแผนปัจจุบันเฉพาะยาบรรจุเสร็จสำหรับสัตว์ (ขย15)"
            End If
            If dao_lcn.fields.lcntpcd = "ขย4" Then
                lbl_name.Text = "ขายส่งยาแผนปัจจุบัน (ขย15)"
            End If
        ElseIf _process = "100742" Then
            lbl_name.Text = "ผลิตยาแผนปัจจุบัน (ผย9)"
        ElseIf _process = "100743" Then
            lbl_name.Text = "นำหรือสั่งยาแผนปัจจุบันเข้ามาในราชอาณาจักร (นย9)"
        ElseIf _process = "100744" Then
            If dao_lcn.fields.lcntpcd = "ผยบ" Then
                lbl_name.Text = "ผลิตยาแผนโบราณ (ยบ13)"
            End If
            If dao_lcn.fields.lcntpcd = "นยบ" Then
                lbl_name.Text = "นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร (ยบ13)"
            End If
            If dao_lcn.fields.lcntpcd = "ขยบ" Then
                lbl_name.Text = "ขายยาแผนโบราณ (ยบ13)"
            End If
        ElseIf _process = "100745" Then
            lbl_name.Text = "ขายวัตถุออกฤทธิ์ในประเภท 3 หรือประเภท 4 (ขจ3)"
        ElseIf _process = "100746" Then
            lbl_name.Text = "นำเข้าซึ่งวัตถุออกฤทธิ์ประเภท 3 หรือประเภท 4 (นจ3)"
        ElseIf _process = "100747" Then
            lbl_name.Text = "ผลิตซึ่งวัตถุออกฤทธิ์ในประเภท 3 หรือประเภท 4 (ผจ3)"
        ElseIf _process = "100748" Then
            lbl_name.Text = "ส่งออกซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท 4 (สจ4)"
        ElseIf _process = "100749" Then
            lbl_name.Text = "ผลิต จำหน่าย นำเข้า หรือส่งออกซึ่งยาเสพติดให้โทษในประเภท 3 (ยส19)"
        ElseIf _process = "100750" Then
            lbl_name.Text = "ขายวัตถุออกฤทธิ์โดยการขายส่งตรง (ขนจ1)"
        ElseIf _process = "100751" Then
            If dao_lcn.fields.lcntpcd = "ผสม" Then
                lbl_name.Text = "ผลิตยาสมุนไพร (สมพ(สมุนไพร))"
            End If
            If dao_lcn.fields.lcntpcd = "นสม" Then
                lbl_name.Text = "ขายยาสมุนไพร (สมพ(สมุนไพร))"
            End If
            If dao_lcn.fields.lcntpcd = "ขสม" Then
                lbl_name.Text = "นำหรือสั่งยาสมุนไพร (สมพ(สมุนไพร))"
            End If
            'ElseIf _process = "100752" Then
            '    lbl_name.Text = "ผลิตซึ่งวัตถุออกฤทธิ์ในประเภท 3 (ผจ3)"
            'ElseIf _process = "100753" Then
            '    lbl_name.Text = "ผลิตซึ่งวัตถุออกฤทธิ์ในประเภท 4 (ผจ4)"
            'ElseIf _process = "100754" Then
            '    lbl_name.Text = "ขายวัตถุออกฤทธิ์ในประเภท 3 (ขจ3)"
            'ElseIf _process = "100755" Then
            '    lbl_name.Text = "ขายวัตถุออกฤทธิ์ในประเภท 4 (ขจ4)"
            'ElseIf _process = "100756" Then
            '    lbl_name.Text = "ขายวัตถุออกฤทธิ์โดยการขายส่งตรงในประเภท 3 (ขนจ3)"
            'ElseIf _process = "100757" Then
            '    lbl_name.Text = "ขายวัตถุออกฤทธิ์โดยการขายส่งตรงในประเภท 4 (ขนจ4)"
        End If
        If _process = "100745" Or _process = "100747" Or _process = "100750" Then
            RadioButtonList1.Style.Add("display", "block")
        End If

    End Sub

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU       'ประกาศชื่อตัวแปร DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_Process(_process)             'ดึง dao.GetDataby_Process เพื่อมาโชว์ที่ Gridview ที่เป็นค่า String

        'bao.SP_LCN_DRUG_TYPE_MENU(_CLS.LCNSID, dao.fields.NAME)
        'bao.SP_DALCN_By_lcntpcd(_CLS.LCNSID_CUSTOMER, dao.fields.NAME) 'เรียกใช้ SP  bao.SP_DALCN_By_lcntpcd
        'Dim process As String = _process
        'If _process = "101" Or _process = "102" Or _process = "103" Or _process = "104" Then
        '    process = "100741"  'ขย15
        'ElseIf _process = "106" Then
        '    process = "100742"  'ผย9
        'ElseIf _process = "105" Then
        '    process = "100743"  'นย9
        'ElseIf _process = "107" Or _process = "108" Or _process = "109" Then
        '    process = "100744"  'ยบ13
        'ElseIf _process = "111" Then
        '    process = "100745"  'ขจ3
        'ElseIf _process = "113" Then
        '    process = "100746"  'นจ3
        'ElseIf _process = "110" Then
        '    process = "100747"  'ผจ3
        'ElseIf _process = "100748" Then
        '    process = "100748"  'สจ4
        'ElseIf _process = "100749" Then
        '    process = "100749"  'ยส19
        'End If

        'Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        'dao_pro.GetDataby_Process_ID(process)
        'bao.SP_CUSTOMER_LCN_BY_FK_IDA(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, _CLS.CITIZEN_ID_AUTHORIZE)


        Dim dt As New DataTable
        'dt = bao.SP_LCN_EXTEND_REQUEST_BY_FK_IDA3(Request.QueryString("lcn_ida"), _process)
        If ddl_year.SelectedValue = "2" Then
            dt = bao.SP_LCN_EXTEND_REQUEST_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
        Else
            Dim _year As Integer = 0
            _year = Year(Date.Now)
            If _year < 2500 Then
                _year += 544
            End If
            dt = bao.SP_LCN_EXTEND_REQUEST_BY_IDENTIFY_YEAR(_CLS.CITIZEN_ID_AUTHORIZE, _year)
        End If


        'bao.SP_LCN_EXTEND_REQUEST_BY_FK_IDA2(Request.QueryString("lcn_ida"))
        'If Request.QueryString("identify") <> "" Then
        '    bao.SP_CUSTOMER_LCN_BY_FK_IDA_AND_PVNCD(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, Request.QueryString("identify"), _pvncd)
        'Else
        '    bao.SP_CUSTOMER_LCN_BY_FK_IDA_AND_PVNCD(Request.QueryString("lct_ida"), dao_pro.fields.PROCESS_NAME, _CLS.CITIZEN_ID_AUTHORIZE, _pvncd)
        'End If

        GV_lcnno.DataSource = dt                    'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub

#Region "GRIDVIEW"

    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim btn_drug_group As Button = DirectCast(e.Row.FindControl("btn_drug_group"), Button)
            Dim btn_lcn As Button = DirectCast(e.Row.FindControl("btn_lcn"), Button)
            Dim btn_leaves As Button = DirectCast(e.Row.FindControl("btn_leaves"), Button)
            Dim btn_sell As Button = DirectCast(e.Row.FindControl("btn_sell"), Button)
            Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
            Dim id As Integer = CInt(GV_lcnno.DataKeys.Item(e.Row.RowIndex).Value.ToString())
            Dim btn_pay As Button = DirectCast(e.Row.FindControl("btn_pay"), Button)
            Dim btn_attach As Button = DirectCast(e.Row.FindControl("btn_attach"), Button)
            'btn_Select.Style.Add("display", "none")
            'btn_lcn.Style.Add("display", "none")
            btn_leaves.Style.Add("display", "none")
            btn_attach.Style.Add("display", "none")
            btn_drug_group.Style.Add("display", "none")
            btn_sell.Style.Add("display", "none")
            btn_edit.Style.Add("display", "none")
            btn_pay.Style.Add("display", "none")
            If _process = "100741" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100742" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100743" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100744" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100745" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100746" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100747" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100748" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100749" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100750" Then
                btn_Select.Style.Add("display", "block")
            ElseIf _process = "100751" Then
                btn_Select.Style.Add("display", "block")
            End If

            Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
            dao.GetDataby_IDA(id)

            'ไม่ให้แสดงคำว่า เลือกข้อมูล ถ้าสถานะไม่ใช่อนุมัติ
            'If dao.fields.STATUS_ID = 6 Then
            '    btn_lcn.Style.Add("display", "block")
            'End If
            If dao.fields.STATUS_ID = 5 Then
                btn_edit.Style.Add("display", "block")
            End If
            If dao.fields.STATUS_ID >= 4 And dao.fields.STATUS_ID <> 7 Then
                btn_attach.Style.Add("display", "block")
                btn_pay.Style.Add("display", "none")
            End If
            If dao.fields.STATUS_ID > 0 And dao.fields.STATUS_ID < 4 Then
                btn_pay.Style.Add("display", "block")
            End If

        End If

    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        'dao.GetDataby_IDA(str_ID)
        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If Request.QueryString("staff") = "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EXTEND_TIME_LOCATION_CONFIRM.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & tr_id & " & lct_ida = " & _lct_ida & " &lcn_ida=" & _lcn_ida & "&process=" & dao.fields.PROCESS_ID & "');", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EXTEND_TIME_LOCATION_CONFIRM.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & tr_id & " & lct_ida = " & _lct_ida & " &lcn_ida=" & _lcn_ida & "&process=" & dao.fields.PROCESS_ID & "&staff=" & Request.QueryString("staff") & "');", True)
            End If
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EXTEND_TIME_LOCATION_CONFIRM.aspx?IDA=" & dao.fields.IDA & "&TR_ID=" & tr_id & " & lct_ida = " & _lct_ida & " &lcn_ida=" & _lcn_ida & "&process=" & _process & "');", True)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2("~\EDIT_LOCATION_STAFF\POPUP_STAFF_EDIT_LOCATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & " ")
        ElseIf e.CommandName = "leaves" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Response.Redirect("FRM_LCN_NCT.aspx?lcnno= " & dao.fields.lcnno.ToString() & " & lcnsid = " & dao.fields.lcnsid.ToString() & " & lcn_ida = " & str_ID & " & lct_ida = " & _lct_ida & " & Process = " & _process)
            'Response.Redirect("../ EDIT_LOCATION / FRM_EDIT_LOCATION_MAIN.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida & "&process=" & process & "&process2=" & process2)

            'ElseIf e.CommandName = "lcn" Then
            '    'Dim dao As New DAO_DRUG.ClsDBdalcn
            '    dao.GetDataby_IDA(Integer.Parse(str_ID))
            '    _CLS.LCNNO = dao.fields.lcnno.ToString()
            '    _CLS.LCNSID_CUSTOMER = dao.fields.lcnsid.ToString()
            '    '_CLS.PVCODE = dao.fields.pvncd.ToString()
            '    _CLS.IDA = str_ID
            '    Session("CLS") = _CLS

            '    ' Response.Redirect("../MAIN/FRM_NODE.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())
            '    Response.Redirect("../MAIN/FRM_NEWS.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida)

        ElseIf e.CommandName = "_attach" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            Response.Write("<script>window.open ('../EXTEND_TIME_LOCATION/FRM_EXTEND_LCN_ATTACH_PAGE.aspx?TR_ID=" & tr_id & "&process=" & dao.fields.PROCESS_ID & "','_blank');</script>")
        ElseIf e.CommandName = "drug_group" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('" & "POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD.aspx?ida=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
        ElseIf e.CommandName = "sell" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups4('" & "POPUP_LCN_SELL_TYPE.aspx?ida=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
        ElseIf e.CommandName = "_edit" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If _staff = 1 Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EXTEND_TIME_LOCATION_UPLOAD.aspx?type_id=" & _process & "&TR_ID=" & tr_id & "&process=" & _process & "&IDA=" & _lct_ida & "&lcn_ida=" & _lcn_ida & "&staff=" & _staff & "&identify=" & _identify & "');", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EXTEND_TIME_LOCATION_UPLOAD.aspx?type_id=" & _process & "&TR_ID=" & tr_id & "&process=" & _process & "&IDA=" & _lct_ida & "&lcn_ida=" & _lcn_ida & "');", True)
            End If
        ElseIf e.CommandName = "_pay" Then

            If _staff = 1 Then
                Response.Write("<script>window.open ('https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug&identify=" & _identify & "','_blank');</script>")
            Else
                Response.Write("<script>window.open ('https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&System=drug" & "','_blank');</script>")
            End If
        End If

    End Sub


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub
#End Region

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()                             'เรียกฟังก์ชั่น  load_GV_lcnno   มาใช้งาน
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        If String.IsNullOrEmpty(_process) = False Then  'ถ้าให้ค่า _process เป็นค่าว่าง จะไม่เป็นความจริง
            If _process = "100745" Or _process = "100747" Or _process = "100750" Then
                If RadioButtonList1.SelectedValue Is Nothing Then

                End If
            End If
            Bind_PDF()                                  'เรียกฟังก์ชั่น  Bind_PDF มาใช้งาน
            Dim ws As New AUTHEN_LOG.Authentication
            ' ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอต่ออายุ", _process)
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอต่ออายุ", _process)
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอต่ออายุ", _process)

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอต่ออายุ", _process)

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try

        Else
            alert("กรุณาเลือกประเภทใบอนุญาตก่อนทำการดาวน์โหลด")  'ถ้าค่าว่างจะ ERROR
        End If

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
        bao_app.RunAppSettings()                                                    'บอกที่อยู่ของไฟล์

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process                                       ' ชื่อ Process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID                               ' รับค่าจากเทเบิ้ล บัตรประชาชน
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE           ' รับ ชื่อประกอบการ
        dao_down.fields.STATUS = STATUS                                             ' รับเก็บค่า STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE                               ' เวลา
        dao_down.insert()                                                           ' insert ค่าข้างบน
        down_ID = dao_down.fields.ID


        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)                   'จาวา .Gif
    End Sub
    ''' <summary>
    ''' แปลงค่าจากDatabase เป็น XML
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub convert_Database_To_XML(ByVal path As String)
        Dim bao_show As New BAO_SHOW
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        'Dim newyear As Integer = 0
        'Dim year_present As Integer = 0
        'Dim montn_present As Integer = 0
        'year_present = Year(Date.Now)
        'montn_present = Month(Date.Now)
        'If montn_present = 1 Then
        '    newyear = year_present
        'Else
        '    newyear = year_present + 1
        'End If
        'dao_lcn.fields.expyear = newyear
        'dao_lcn.update()


        Dim cls As New CLASS_GEN_XML.EXTEND(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao_lcn.fields.lcnno, "1", dao_lcn.fields.pvncd) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_EXTEND                                                                     ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 0

        Try
            lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception

        End Try
        Dim newyear As Integer = 0
        Dim year_present As Integer = 0
        Dim montn_present As Integer = 0
        year_present = Year(Date.Now)
        montn_present = Month(Date.Now)
        If montn_present = 1 Then
            newyear = year_present
        Else
            newyear = year_present + 1
        End If
        cls_xml.EXP_NEWYEAR = newyear 'ต่ออายุใบอนุญาติ
        cls_xml.dalcns_new = dao_lcn.fields
        'cls_xml.DT_SHOW.DT8 = bao_show.SP_GETDATA_EXTENDPDF_by_IDA(_lcn_ida)
        cls_xml.DT_SHOW.DT9 = bao_show.SP_DOWNDATA_EXTENDPDF_by_IDA(_lcn_ida) 'ข้อมูลสถานที่จำลอง
        'cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _CLS.LCNSID_CUSTOMER) 'ข้อมูลที่ตั้งหลัก
        'cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        'cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _CLS.LCNSID_CUSTOMER) 'ที่เก็บ
        ''cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim bao_master As New BAO_MASTER
        cls_xml.DT_SHOW.DT7 = bao_master.SP_DALCN_PHR_BY_FK_IDA_2(_lcn_ida)

        'Dim bao_master As New BAO_MASTER
        ''Dim _lcn_ida As Integer
        ''If Integer.TryParse(_lcn_ida) = True Then

        'Try
        '    'cls_xml.DT_MASTER.DT29 = bao_master.SP_MASTER_DALCN_LCNREQUEST_by_IDA(_lcn_ida) ''ใบอนุญาตต่ออายุสถานที่ เลขรับ วันที่รับ
        'Catch ex As Exception

        'End Try

        'cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CON_LCNNO(_lcn_ida)
        'End If
        'ขย15
        If dao_lcn.fields.lcntpcd = "ขย1" Then
            cls_xml.CHK_TYPE = 1
            cls_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย2" Then
            cls_xml.CHK_TYPE = 3
            cls_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย3" Then
            cls_xml.CHK_TYPE = 4
            cls_xml.CHK_NAME = "ขายยาแผนปัจจุบันฯ"
        ElseIf dao_lcn.fields.lcntpcd = "ขย4" Then
            cls_xml.CHK_TYPE = 2
            cls_xml.CHK_NAME = "ขายส่งยาแผนปัจจุบันฯ"

            'ยบ13
        ElseIf dao_lcn.fields.lcntpcd = "ผยบ" Then
            cls_xml.CHK_TYPE = 1
        ElseIf dao_lcn.fields.lcntpcd = "นยบ" Then
            cls_xml.CHK_TYPE = 3
        ElseIf dao_lcn.fields.lcntpcd = "ขยบ" Then
            cls_xml.CHK_TYPE = 2


            'สมพ
        ElseIf dao_lcn.fields.lcntpcd = "ผสม" Then
            cls_xml.CHK_TYPE = 1
        ElseIf dao_lcn.fields.lcntpcd = "นสม" Then
            cls_xml.CHK_TYPE = 3
        ElseIf dao_lcn.fields.lcntpcd = "ขสม" Then
            cls_xml.CHK_TYPE = 2
        End If
        If _process = "100747" Or _process = "100745" Or _process = "100750" Then
            cls_xml.CHK_TYPE = RadioButtonList1.SelectedValue
        End If


        Dim dao As New DAO_CPN.TB_LOCATION_BSN
        dao.Getdata_by_fk_id2(_lct_ida)

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub


    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        If _staff = 1 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EXTEND_TIME_LOCATION_UPLOAD.aspx?type_id=" & _process & "&process=" & _process & "&IDA=" & _lct_ida & "&lcn_ida=" & _lcn_ida & "&staff=" & _staff & "&identify=" & _identify & "');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EXTEND_TIME_LOCATION_UPLOAD.aspx?type_id=" & _process & "&process=" & _process & "&IDA=" & _lct_ida & "&lcn_ida=" & _lcn_ida & "');", True)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub

    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    Protected Sub btn_extend_Click(sender As Object, e As EventArgs) Handles btn_extend.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('https://medicina.fda.moph.go.th/FDA_DRUG_EXT/AUTHEN/AUTHEN_GATEWAY?Token=" & _CLS.TOKEN & "&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "'); ", True)
    End Sub

    Private Sub ddl_year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_year.SelectedIndexChanged
        load_GV_lcnno()
    End Sub

    Protected Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri)
    End Sub
End Class