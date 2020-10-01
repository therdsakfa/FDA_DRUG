Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class FRM_STAFF_CER_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

    Sub runQuery()

    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        If Not IsPostBack Then
            'load_GV_data()
            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอ Cert สำหรับเจ้าหน้าที่", "")

            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอ Cert สำหรับเจ้าหน้าที่", Request.QueryString("process"))
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอ Cert สำหรับเจ้าหน้าที่", Request.QueryString("process"))

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้หน้าพิจารณาคำขอ Cert สำหรับเจ้าหน้าที่", Request.QueryString("process"))

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
        End If
    End Sub
    Sub load_lcnno()

    End Sub

    'Sub load_GV_data()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    'CER
    '    bao.SP_STAFF_CER()
    '    GV_data.DataSource = bao.dt
    '    GV_data.DataBind()
    'End Sub

    'Private Sub GV_data_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_data.PageIndexChanging
    '    GV_data.PageIndex = e.NewPageIndex
    '    load_GV_data()
    'End Sub

    'Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.TB_CER

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA2(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try

    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_STAFF_CER_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

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
            Dim dao As New DAO_DRUG.TB_CER
            Dim process_id As String
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA2(IDA)
                Dim tr_id As String = 0
                Try
                    process_id = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_STAFF_CER_CONFIRM2.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & process_id & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_STAFF_CER()
        Dim dt As New DataTable
        Try
            dt = bao.dt
        Catch ex As Exception

        End Try
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
        Catch ex As Exception

        End Try
        'If IDGroup = 21020 Then
        RadGrid1.DataSource = dt
        'ElseIf IDGroup = 63346 Then
        '    RadGrid1.DataSource = dt.Select("STATUS_ID = 2")
        'ElseIf IDGroup = 63347 Then
        '    RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6")
        'ElseIf IDGroup = 63348 Then
        '    RadGrid1.DataSource = dt.Select("STATUS_ID > 6")
        'End If
    End Sub
End Class