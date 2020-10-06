Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class FRM_DH_MAIN_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Private _type As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
        _type = Request.QueryString("type")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            runQuery()

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_lcnno()
        If Not IsPostBack Then
            Bind_ddl_Status()
            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอเภสัชเคมีภัณฑ์", "")
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอเภสัชเคมีภัณฑ์", Request.QueryString("process"))
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอเภสัชเคมีภัณฑ์", Request.QueryString("process"))

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอเภสัชเคมีภัณฑ์", Request.QueryString("process"))

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try


            'load_GV_data()
        End If
    End Sub
    Sub load_lcnno()
        'lbl_lcnno.Text = _CLS.LCNNO
    End Sub

    'Sub load_GV_data()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    GV_data.DataSource = bao.SP_STAFF_DH15RQT()
    '    GV_data.DataBind()
    'End Sub

    'Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBdh15rqt

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try

    '        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '        dao_tr.GetDataby_IDA(tr_id)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_COMFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & " &process=" & dao_tr.fields.PROCESS_ID & "');", True)

    '    End If
    'End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        'load_GV_data()
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdh15rqt
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA(IDA)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tr.GetDataby_IDA(tr_id)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_COMFIRM_STAFF.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & " &process=" & dao.fields.PROCESS_ID & "');", True)

            End If

        End If
    End Sub
    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_data.PageIndexChanging
    '    GV_data.PageIndex = e.NewPageIndex
    '    load_GV_data()
    'End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_STAFF_DH15RQT()
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        If IDGroup = 21020 Or IDGroup = 220577 Then
            RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6")
            'ElseIf IDGroup = 63346 Then
            '    RadGrid1.DataSource = dt.Select("STATUS_ID = 2")
            'ElseIf IDGroup = 63347 Then
            '    RadGrid1.DataSource = dt.Select("STATUS_ID > 2 and STATUS_ID <= 6")
            'ElseIf IDGroup = 63348 Then
            '    RadGrid1.DataSource = dt.Select("STATUS_ID > 6")
        End If
    End Sub

    Protected Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Dim strMsg As String = ""
        strMsg = "([STATUS_NAME] LIKE '%" & ddl_status.SelectedItem.Text & "%')" & _
            " and ([TR_ID] LIKE '%" & txt_number.Text & "%') " & _
            " and ([TRADING_NAME] LIKE '%" & txt_name.Text & "%') "
        'strMsg = "([rcvno] LIKE '%" & txt_number.Text & "%') " & _
        '   " and ([TRADING_NAME] LIKE '%" & txt_name.Text & "%') "

        RadGrid1.EnableLinqExpressions = False
        RadGrid1.MasterTableView.FilterExpression = strMsg
        RadGrid1.MasterTableView.Rebind()
    End Sub
    Public Sub Bind_ddl_Status()
        Dim dao As New DAO_DRUG.ClsDBMAS_STATUS
        dao.GetDataAll_BYGROUP()

        ddl_status.DataSource = dao.datas
        ddl_status.DataValueField = "STATUS_ID"
        ddl_status.DataTextField = "STATUS_NAME"
        ddl_status.DataBind()
    End Sub
End Class