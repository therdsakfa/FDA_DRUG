Imports Telerik.Web.UI

Public Class POPUP_E_TRACKING_STOP_TIME
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
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
        If Not IsPostBack Then
            'txt_end_date_det.Text = Date.Now.ToShortDateString
            'txt_start_date_det.Text = Date.Now.ToShortDateString
            bind_ddl_period_name()
            bind_ddl_expert_type()
        End If
    End Sub
    Sub bind_ddl_period_name()
        Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_PERIOD_NAME
        dao.GetDataALL()
        ddl_period.DataSource = dao.datas
        ddl_period.DataTextField = "PERIOD_NAME"
        ddl_period.DataValueField = "IDA"
        ddl_period.DataBind()
    End Sub
    Sub bind_ddl_expert_type()
        Dim dao As New DAO_DRUG.TB_MAS_EXPERT_SKILL
        dao.GetDataALL()

        ddl_expert_type.DataSource = dao.datas
        ddl_expert_type.DataTextField = "EXPERT_SKILL"
        ddl_expert_type.DataValueField = "IDA"
        ddl_expert_type.DataBind()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_E_TRACKING_STOP_TIME
                dao.GetDataby_IDA(item("IDA").Text)

                Dim dao_pe As New DAO_DRUG.TB_MAS_E_TRACKING_PERIOD_NAME
                Try
                    dao_pe.GetDataby_IDA(dao.fields.TYPE_PERIOD)
                Catch ex As Exception

                End Try

                'AddLogStatusEtracking(0, 1, _CLS.CITIZEN_ID, "ลบ" & dao_pe.fields.PERIOD_NAME & " ครั้งที่ " & dao.fields.PERIOD_COUNT, dao.fields.IDA, 0)
                AddLogStatusEtracking(0, 1, _CLS.CITIZEN_ID, "ลบ" & dao_pe.fields.PERIOD_NAME & " ครั้งที่ " & dao.fields.PERIOD_COUNT, "TIME STOP", Request.QueryString("id_r"), dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
                dao.delete()

                Dim bao_update As New BAO.ClsDBSqlcommand
                Try
                    bao_update.SP_DRUG_CONSIDER_REQUESTS_STOP_DAY(dao.fields.FK_IDA)
                Catch ex As Exception

                End Try
                Try
                    bao_update.SP_DRUG_CONSIDER_REQUESTS_MAX_STOP_DAY(dao.fields.FK_IDA)
                Catch ex As Exception

                End Try
                Try
                    bao_update.SP_DRUG_CONSIDER_REQUESTS_FINISH_DATE(dao.fields.FK_IDA)
                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            ElseIf e.CommandName = "_date" Then
                Dim url As String = "POPUP_E_TRACKING_STOP_TIME_DATE.aspx?id_r=" & Request.QueryString("id_r") & "&ida=" & item("IDA").Text

                Response.Redirect(url)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        'If Request.QueryString("ida") <> "" Then
        Dim bao As New BAO.ClsDBSqlcommand

        If Request.QueryString("id_r") = "" Then
            dt = bao.SP_GET_E_TRACKING_STOP_DAY(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), Request.QueryString("lcnsid"))

            'ElseIf Request.QueryString("rcvno") <> "" Then
            '    Dim dao As New DAO_DRUG.TB_E_TRACKING_WORK_DAY_REPORT
            '    dao.GetDataby_rcvno_ctzid(Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype"))
            '    Dim bao As New BAO.ClsDBSqlcommand
            '    dt = bao.SP_GET_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA(dao.fields.IDA)
            'End If


            For Each dr As DataRow In dt.Rows
                Dim ws2 As New WS_GETDATE_WORKING.Service1
                'Dim start_date2 As Date
                'Dim end_date2 As Date
                Dim holiday2 As Integer = 0
                Dim day_all2 As Integer = 0
                'Try
                '    start_date2 = CDate(dr("START_DATE"))
                'Catch ex As Exception

                'End Try
                'Try
                '    end_date2 = 
                'Catch ex As Exception

                'End Try
                Dim yes_start As Integer = 0
                Dim START_DATE As Date
                'Dim END_DATE As Date
                Try
                    START_DATE = CDate(dr("START_DATE"))
                    yes_start += 1
                Catch ex As Exception

                End Try

                Try
                    day_all2 = DateDiff(DateInterval.Day, CDate(dr("START_DATE")), CDate(dr("END_DATE")))
                Catch ex As Exception
                    If yes_start > 0 Then
                        day_all2 = DateDiff(DateInterval.Day, CDate(dr("START_DATE")), Date.Now)
                    End If

                End Try
                Try
                    ws2.GETDATE_COUNT_DAY(CDate(dr("START_DATE")), True, CDate(dr("END_DATE")), True, holiday2, True)
                Catch ex As Exception
                    If yes_start > 0 Then
                        ws2.GETDATE_COUNT_DAY(CDate(dr("START_DATE")), True, Date.Now, True, holiday2, True)
                    End If

                End Try


                dr("count_day") = day_all2 - holiday2

            Next
        Else
            '
            dt = bao.SP_GET_E_TRACKING_STOP_DAY_V2(Request.QueryString("id_r"), 2)


            '    For Each dr As DataRow In dt.Rows
            '        Dim ws2 As New WS_GETDATE_WORKING.Service1
            '        'Dim start_date2 As Date
            '        'Dim end_date2 As Date
            '        Dim holiday2 As Integer = 0
            '        Dim day_all2 As Integer = 0
            '        'Try
            '        '    start_date2 = CDate(dr("START_DATE"))
            '        'Catch ex As Exception

            '        'End Try
            '        'Try
            '        '    end_date2 = CDate(dr("END_DATE"))
            '        'Catch ex As Exception

            '        'End Try
            '        Dim yes_start As Integer = 0
            '        Dim START_DATE As Date
            '        'Dim END_DATE As Date
            '        Try
            '            START_DATE = CDate(dr("START_DATE"))
            '            yes_start += 1
            '        Catch ex As Exception

            '        End Try

            '        Try
            '            day_all2 = DateDiff(DateInterval.Day, CDate(dr("START_DATE")), CDate(dr("END_DATE")))
            '        Catch ex As Exception
            '            If yes_start > 0 Then
            '                day_all2 = DateDiff(DateInterval.Day, CDate(dr("START_DATE")), Date.Now)
            '            End If

            '        End Try
            '        Try
            '            ws2.GETDATE_COUNT_DAY(CDate(dr("START_DATE")), True, CDate(dr("END_DATE")), True, holiday2, True)
            '        Catch ex As Exception
            '            If yes_start > 0 Then
            '                ws2.GETDATE_COUNT_DAY(CDate(dr("START_DATE")), True, Date.Now, True, holiday2, True)
            '            End If

            '        End Try


            '        dr("count_day") = day_all2 - holiday2

            '    Next
        End If

        RadGrid1.DataSource = dt
    End Sub

    Private Sub ddl_period_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_period.SelectedIndexChanged
        If ddl_period.SelectedValue = 2 Then
            Panel2.Style.Add("display", "block")
        Else
            Panel2.Style.Add("display", "none")
        End If
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_E_TRACKING_STOP_TIME
        Dim head_id As Integer = 0
  
        With dao.fields
            'Try
            '    .END_DATE = CDate(txt_end_date_det.Text)
            'Catch ex As Exception

            'End Try

            If ddl_period.SelectedValue = 2 Then
                .EXPERT_TYPE_ID = ddl_expert_type.SelectedValue
                .EXPERT_COUNT = ddl_expert_count.SelectedValue
            End If
            .PERIOD_COUNT = ddl_period_count.SelectedValue
            'Try
            '    .START_DATE = CDate(txt_start_date_det.Text)
            'Catch ex As Exception

            'End Try
            .TYPE_PERIOD = ddl_period.SelectedValue
            'Request.QueryString("rcvno"), Request.QueryString("ctzid"), Request.QueryString("ntype")
            Try
                .CTZID = Request.QueryString("ctzid")
                .rcvno = Request.QueryString("rcvno")
                .rgttpcd = Request.QueryString("ntype")
                .PRODUCT_TYPE = Request.QueryString("b_type")
                .SMALL_TYPE = Request.QueryString("s_type")
                .lcnsid = Request.QueryString("lcnsid")
            Catch ex As Exception

            End Try
            If Request.QueryString("id_r") <> "" Then
                .TYPE_P = 2
                .FK_IDA = Request.QueryString("id_r")


            End If
        End With
        dao.fields.CREATE_DATE = Date.Now
        dao.insert()

        AddLogStatusEtracking(0, 1, _CLS.CITIZEN_ID, "เพิ่ม" & ddl_period.SelectedItem.Text & " ครั้งที่ " & ddl_period_count.SelectedItem.Text, dao.fields.IDA, 0)

        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่ม" & ddl_period.SelectedItem.Text & " ครั้งที่ " & ddl_period_count.SelectedItem.Text, "")
        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่ม" & ddl_period.SelectedItem.Text & " ครั้งที่ " & ddl_period_count.SelectedItem.Text, "")
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่ม" & ddl_period.SelectedItem.Text & " ครั้งที่ " & ddl_period_count.SelectedItem.Text, "")

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่ม" & ddl_period.SelectedItem.Text & " ครั้งที่ " & ddl_period_count.SelectedItem.Text, "")

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)

        RadGrid1.Rebind()
    End Sub
End Class