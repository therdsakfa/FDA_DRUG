Imports Telerik.Web.UI
Public Class FRM_STAFF_EXTEND_TIME_LOCATION_MAIN2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer

    Sub RunSession()
        Try
            _CLS = Session("CLS")
            Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "หน้าเจ้าหน้าที่ระบบต่ออายุใบอนุญาต", _process)
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "หน้าเจ้าหน้าที่ระบบต่ออายุใบอนุญาต", _process)
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "หน้าเจ้าหน้าที่ระบบต่ออายุใบอนุญาต", _process)

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "หน้าเจ้าหน้าที่ระบบต่ออายุใบอนุญาต", _process)

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            'Dim Dao_set As New DAO_DRUG.TB_lcnrequest
            'Dao_set.GetDataALL()
            'NAME_LIST.DataSource = Dao_set.datas
            'NAME_LIST.DataTextField = "TR_ID"
            'NAME_LIST.DataValueField = "TR_ID"
            'NAME_LIST.DataBind()
            'load_GV_lcnno()

        End If
    End Sub
    Sub Search_FN()
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_SEARCH_DRUG_EXTEND_TIME_LOCATIONv2(citi, lcnt)
        Dim dt As New DataTable
        'dt = bao.SP_STAFF_LCNREQUEST()

        'dt = bao.SP_GET_LCN_EXTEND_BY_IDA(_lcn_ida)

        Dim str_query As String = "select * from dbo.Vw_Extend where "

        Dim r_result As DataRow()
        Dim str_where As String = ""
        'Dim dt2 As New DataTable

        If txt_CITIZEN_ID.Text = "" And txt_lcnno_no.Text = "" And txt_lcnsid.Text = "" Then
            dt = bao.Queryds("select * from dbo.Vw_Extend order by TRANSACTION_UPLOAD desc ")
            RadGrid1.DataSource = dt.Select("STATUS_ID =1 or STATUS_ID >=4 and STATUS_ID <>7")
        Else
            If txt_CITIZEN_ID.Text <> "" Then
                str_where = " CITIZEN_AUTHORIZE='" & txt_CITIZEN_ID.Text & "' order by TRANSACTION_UPLOAD desc"
                If txt_lcnno_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%' order by TRANSACTION_UPLOAD desc"
                    Else
                        str_where &= " lcnno_no like '%" & txt_lcnno_no.Text & "%' order by TRANSACTION_UPLOAD desc"
                    End If

                End If
                'r_result = dt.Select(str_where)
            Else
                If str_where = "" Then
                    If str_where <> "" Then
                        If txt_lcnno_no.Text <> "" Then
                            str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%' order by TRANSACTION_UPLOAD desc"
                        End If
                    Else
                        If txt_lcnno_no.Text <> "" Then
                            str_where = " lcnno_no like '%" & txt_lcnno_no.Text & "%' order by TRANSACTION_UPLOAD desc"

                        End If
                    End If
                    'r_result = dt.Select(str_where)
                Else
                    If txt_lcnno_no.Text <> "" Then
                        str_where = " lcnno_no like '%" & txt_lcnno_no.Text & "%' order by TRANSACTION_UPLOAD desc"

                    End If
                    'r_result = dt.Select(str_where)

                End If
                If txt_lcnsid.Text <> "" Then
                    str_where = " house_no='" & txt_lcnsid.Text & "'"

                End If
                'r_result = dt.Select(str_where)
            End If


            str_query &= str_where

            dt = bao.Queryds(str_query)
            'dt2 = dt.Clone

            'For Each dr As DataRow In r_result
            '    dt2.Rows.Add(dr.ItemArray)
            'Next
            RadGrid1.DataSource = dt.Select("STATUS_ID =1 or (STATUS_ID >=4 and STATUS_ID <>7)")
        End If


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
    'Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click

    '    OpenPopupName("POPUP_LCN_DOWNLOAD.aspx")
    'End Sub

    'Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
    '    OpenPopupName("POPUP_LCN_UPLOAD.aspx")
    'End Sub
    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub

#Region "GRIDVIEW"
    'Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
    '        Dim index As Integer = e.Row.RowIndex
    '        'Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
    '        Dim str_ID As String = GV_lcnno.DataKeys.Item(index)("IDA").ToString()
    '        Dim dao As New DAO_DRUG.ClsDBdalcn
    '        dao.GetDataby_IDA(Integer.Parse(str_ID))
    '        btn_edit.Style.Add("display", "none")
    '        Try
    '            If dao.fields.STATUS_ID = 6 Then
    '                btn_edit.Style.Add("display", "block")
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & str_ID
    '        btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")

    '    End If
    'End Sub

    'Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBdalcn

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try

    '        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
    '        dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID & "');", True)

    '    End If

    'End Sub


    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
    '    GV_lcnno.PageIndex = e.NewPageIndex
    '    load_GV_lcnno()
    'End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
        'load_GV_lcnno()
    End Sub
#End Region

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'Dim u1 As String
            Dim lcntpcd As String = ""
            Dim lcntpcd_old As String = ""
            Dim lcnno As String = ""
            Dim CITIZEN_ID As String = ""
            Dim lc_IDA As String = ""
            lcntpcd = item("lcntpcd2").Text
            lcntpcd_old = item("lcntpcd").Text
            'lcnno = item("lcnno").Text
            lc_IDA = item("lc_IDA").Text
            'u1 = item("Newcode_not").Text
            CITIZEN_ID = item("CITIZEN_ID").Text 'AUTHORIZE
            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim ws As New AUTHEN_LOG.Authentication



            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
                dao.GetDataby_IDA(IDA)
                Dim tr_id As String = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)

                'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลใบอนุญาตที่ต่ออายุ", _process)
                Dim ws_118 As New WS_AUTHENTICATION.Authentication
                Dim ws_66 As New Authentication_66.Authentication
                Dim ws_104 As New AUTHENTICATION_104.Authentication
                Try
                    ws_118.Timeout = 10000
                    ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลใบอนุญาตที่ต่ออายุ", _process)
                Catch ex As Exception
                    Try
                        ws_66.Timeout = 10000
                        ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลใบอนุญาตที่ต่ออายุ", _process)

                    Catch ex2 As Exception
                        Try
                            ws_104.Timeout = 10000
                            ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลใบอนุญาตที่ต่ออายุ", _process)

                        Catch ex3 As Exception
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                        End Try
                    End Try
                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_EDIT_LOCATION_STAFF_CONFIRM_PREVIEW.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao.fields.PROCESS_ID & "');", True)
            ElseIf e.CommandName = "sel1" Then

                ''IDA = IDA.ToString.EncodeBase64
                'lcntpcd = lcntpcd.EncodeBase64
                ''lcntpcd = sao.fields.lcntpcd
                'lcnno = lcnno.EncodeBase64
                ''lcnno = sao.fields.lcnno
                ''CITIZEN_ID = CITIZEN_ID.EncodeBase64
                'CITIZEN_ID = sao.fields.CITIZEN_ID
                'lcntpcd_old = lcntpcd_old.EncodeBase64
                ' Response.Redirect("FRM_EXTEND_TIME_LOCATION_MAIN_STAFF.aspx?IDA=" & IDA & "&lc_IDA=" & lc_IDA)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('FRM_EXTEND_TIME_LOCATION_MAIN_STAFF.aspx?IDA=" & IDA & "&lc_IDA=" & lc_IDA & "');", True)

                'ElseIf e.CommandName = "save" Then
                '    'Dim u1 As String
                '    u1 = item("Newcode_not").Text
                '    u1 = u1.EncodeBase64
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_EXTEND_TIME_LOCATION_SAVE.aspx?u1=" & u1 & "'); ", True)
                '    'Response.Redirect("FRM_REPORT_ADDRESS.aspx?u1=" & u1)
            ElseIf e.CommandName = "print" Then
                Dim cao As New DAO_DRUG.TB_LCN_EXTEND_LITE
                cao.GetDataby_IDA(IDA)
                ' ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", cao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "พิมพิ์ที่อยู่ใบอนุญาตต่ออายุ", _process)
                Dim ws_118 As New WS_AUTHENTICATION.Authentication
                Dim ws_66 As New Authentication_66.Authentication
                Dim ws_104 As New AUTHENTICATION_104.Authentication
                Try
                    ws_118.Timeout = 10000
                    ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "พิมพิ์ที่อยู่ใบอนุญาตต่ออายุ", _process)
                Catch ex As Exception
                    Try
                        ws_66.Timeout = 10000
                        ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "พิมพิ์ที่อยู่ใบอนุญาตต่ออายุ", _process)

                    Catch ex2 As Exception
                        Try
                            ws_104.Timeout = 10000
                            ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "พิมพิ์ที่อยู่ใบอนุญาตต่ออายุ", _process)

                        Catch ex3 As Exception
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                        End Try
                    End Try
                End Try



                'lcntpcd = sao.fields.lcntpcd
                ''lcnno = lcnno.EncodeBase64
                'lcnno = sao.fields.lcnno
                'CITIZEN_ID = CITIZEN_ID.EncodeBase64
                ''CITIZEN_ID = sao.fields.CITIZEN_ID
                'lcntpcd_old = lcntpcd_old.EncodeBase64
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('FRM_REPORT_ADDRESS.aspx?IDA=" & IDA & "&lcncode=" & lcntpcd & "&lcn=" & lcnno & "&c=" & _CLS.CITIZEN_ID & "&lcncode_o=" & lcntpcd_old & "&FK_IDA=" & item("FK_IDA").Text & "'); ", True)  '& "&type=" & item("type_table").Text
                'Response.Redirect("FRM_REPORT_ADDRESS.aspx?u1=" & u1)
            ElseIf e.CommandName = "_assign" Then
                Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
                dao.GetDataby_IDA(IDA)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../ASSIGN/POPUP_ASSIGN_STAFF.aspx?IDA=" & IDA & "&process=" & dao.fields.PROCESS_ID & "&group=1" & "');", True)
            End If

        End If
        'RadGrid1.Rebind()
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        RadGrid1.Rebind()
        Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ค้นหาข้อมูลหน้าเจ้าหน้าที่ระบบต่อายุใบอนุญาต", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ค้นหาข้อมูลหน้าเจ้าหน้าที่ระบบต่อายุใบอนุญาต", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ค้นหาข้อมูลหน้าเจ้าหน้าที่ระบบต่อายุใบอนุญาต", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ค้นหาข้อมูลหน้าเจ้าหน้าที่ระบบต่อายุใบอนุญาต", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
    End Sub
    Public Sub set_color_rg()
        If RadGrid1.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In RadGrid1.Items
                Dim days_result As Double = 0

                Try
                    days_result = item("days_result").Text
                Catch ex As Exception

                End Try

                If days_result < 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                'i = i + 1
            Next
        End If
    End Sub

    Private Sub FRM_SHOW_REPORT_V2_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        set_color_rg()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim lc_IDA As String = ""
            lc_IDA = item("lc_IDA").Text
            'Dim btn_Select1 As LinkButton = DirectCast(item("btn_Select1").Controls(0), LinkButton)
            Dim btn_assign As LinkButton = DirectCast(item("btn_assign").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
            dao.GetDataby_IDA(IDA)
            btn_assign.Style.Add("display", "none")
            'btn_Select1.Style.Add("display", "none")
            '    Try
            '    If dao.fields.lcntpcd = "ขย1" Then
            '        btn_Select1.Style.Add("display", "block")
            '    End If
            '    Catch ex As Exception

            '    End Try
            Try
                Dim dao_as As New DAO_DRUG.TB_STAFF_ASSIGNING_WORK
                dao_as.GetDataby_FK_IDA_Process(IDA, dao.fields.PROCESS_ID)
                If dao_as.fields.IDA <> 0 Then
                    btn_assign.Style.Add("display", "none")
                Else
                    btn_assign.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            'btn_Select1.Attributes.Add("OnClick", "window.open('" & "FRM_EXTEND_TIME_LOCATION_MAIN_STAFF.aspx?IDA=" & IDA & "&lc_IDA=" & lc_IDA & "'); return true;")
        End If
    End Sub
    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.MasterTableView.ExportToExcel()
        RadGrid1.ExportSettings.IgnorePaging = True
    End Sub

    'Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
    '    If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        Dim IDA As String = item("IDA").Text
    '        Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
    '        Dim dao As New DAO_DRUG.TB_lcnrequest
    '        dao.GetDataby_IDA(IDA)
    '        btn_edit.Style.Add("display", "none")
    '        Try
    '            If dao.fields.STATUS_ID = 6 Then
    '                btn_edit.Style.Add("display", "block")
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        Dim url As String = "../EXTEND_TIME_LOCATION_STAFF/POPUP_EXTEND_TIME_LOCATION_STAFF_CONSIDER.aspx?IDA=" & IDA
    '        btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
    '    End If
    'End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim str_query As String = "select * from dbo.Vw_Extend order by TRANSACTION_UPLOAD desc"
        ''SP_STAFF_DALCN_BY_PVNCD
        'If _pvncd = 10 Then
        'dt = bao.SP_STAFF_DALCN()
        'Else
        'dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
        'End If
        dt = bao.Queryds(str_query)
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        If IDGroup = 21020 Then
            RadGrid1.DataSource = dt.Select("STATUS_ID >=4 and STATUS_ID <>7")
            'ElseIf IDGroup = 63346 Then
            '    RadGrid1.DataSource = dt.Select("STATUS_ID <= 2")
            'ElseIf IDGroup = 63347 Then
            '    RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 8")
            'ElseIf IDGroup = 63348 Then
            '    RadGrid1.DataSource = dt.Select("STATUS_ID >= 9")
        Else
            RadGrid1.DataSource = dt.Select("STATUS_ID >=4 and STATUS_ID <>7 and pvncd=" & _pvncd)
        End If
    End Sub

    '    Protected Sub TEST_Click(sender As Object, e As EventArgs) Handles TEST.Click
    '        Dim sao As New DAO_DRUG.TB_lcnrequest
    '        Dim x = ""
    '        x = NAME_LIST.SelectedItem.Text
    '        If x = "" Then
    '            x = 0
    '        End If
    '        sao.GetDataby_TR_ID(x)

    '        sao.fields.STATUS_ID = 4
    '        sao.update()
    '        RadGrid1.Rebind()
    '    End Sub

End Class