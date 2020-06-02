Imports Telerik.Web.UI

Public Class FRM_REQUESTS_MAIN_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private Sub RunQuery()
        _CLS = Session("CLS")
        _process = Request.QueryString("IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบออกเลขรับประเมินคำขอ (A)", "1007001")

            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบออกเลขรับประเมินคำขอ (A)", "1007001")
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบออกเลขรับประเมินคำขอ (A)", "1007001")
                   
                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบออกเลขรับประเมินคำขอ (A)", "1007001")
                        
                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try

            bind_ddl_WORK_GROUP()
        End If
    End Sub
    Private Sub bind_ddl_WORK_GROUP()
        'Dim dao As New DAO_DRUG.TB_MAS_WORK_GROUP

        'dao.GetDataAll()


        'ddl_WORK_GROUP.DataSource = dao.datas
        'ddl_WORK_GROUP.DataTextField = "WORK_GROUP_NAME"
        'ddl_WORK_GROUP.DataValueField = "WORK_GROUP_ID"
        'ddl_WORK_GROUP.DataBind()
        Dim dao As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
        dao.GetDataAll()
        ddl_WORK_GROUP.DataSource = dao.datas
        ddl_WORK_GROUP.DataTextField = "WORK_GROUP"
        ddl_WORK_GROUP.DataValueField = "IDA"
        ddl_WORK_GROUP.DataBind()
        ddl_WORK_GROUP.Items.Insert(0, New ListItem("ทั้งหมด", "0"))
    End Sub
    'Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click

    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REQUESTS_ADD_STAFF.aspx" & "');", True) 'เปิดหน้า 

    'End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click

        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_REQUESTS_MAIN_STAFF()

        RadGrid1.DataSource = bao.dt
        RadGrid1.Rebind()
    End Sub


    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_REQUESTS_MAIN_STAFF()

        RadGrid1.DataSource = bao.dt
    End Sub


    Protected Sub RadGrid1_RowCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem
            item = e.Item

            If e.CommandName = "sel" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_REQUESTS_STAFF_VIEW.aspx?IDA=" & item("IDA").Text & "');", True)
            ElseIf e.CommandName = "_del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                Dim IDA As String = item("IDA").Text

                dao.GetDataby_IDA(CDec(IDA))
                dao.fields.ACTIVE = 0
                dao.update()
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        Response.Redirect("FRM_REQUESTS_MAIN_PRINT_DAILY.aspx")
    End Sub

    Protected Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click

        RadGrid1.EnableLinqExpressions = False
        RadGrid1.MasterTableView.FilterExpression = filter()
        RadGrid1.MasterTableView.Rebind()


    End Sub
    Private Function filter()
        Dim WORK_GROUP_ID As String
        If ddl_WORK_GROUP.SelectedItem.Value <> 0 Then
            WORK_GROUP_ID = "(WORK_GROUP_ID='" & ddl_WORK_GROUP.SelectedItem.Value & "')"
        Else
            WORK_GROUP_ID = "(WORK_GROUP_ID like '%%')"
        End If


        Return WORK_GROUP_ID
    End Function
End Class