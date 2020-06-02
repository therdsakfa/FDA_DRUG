Imports Telerik.Web.UI

Public Class FRM_EXTEND_TIME_LOCATION_SEARCH1
    Inherits System.Web.UI.Page
    Private citi As String
    Private lcnt As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'load_RG_lcnno()

        End If
    End Sub
    Sub Search_FN()
        'Dim citi As String = txt_CITIZEN_AUTHORIZE.Text
        'Dim lcnt As String = txt_lcnno_no.Text
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_SEARCH_DRUG_EXTEND_TIME_LOCATIONv2(citi, lcnt)
        bao.SP_SEARCH_DRUG_EXTEND_TIME_LOCATION()
        Dim dt As New DataTable
        Try
            dt = bao.dt
        Catch ex As Exception

        End Try
        'dt.Columns.Add("all_days", GetType(Double))
        'dt.Columns.Add("stop_days", GetType(Double))
        'dt.Columns.Add("extend_days", GetType(Double))
        'dt.Columns.Add("days_result", GetType(Double))
        Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_CITIZEN_AUTHORIZE.Text = "" And txt_lcnno_no.Text = "" And txt_lcnsid.Text = "" Then
            RadGrid1.DataSource = dt
        Else
            If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                str_where = "CITIZEN_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
                If txt_lcnno_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                    Else
                        str_where &= "lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                    End If

                End If
                r_result = dt.Select(str_where)
            Else
                If str_where = "" Then
                    If str_where <> "" Then
                        If txt_lcnno_no.Text <> "" Then
                            str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                        End If
                    Else
                        If txt_lcnno_no.Text <> "" Then
                            str_where = "lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                        End If
                    End If
                    r_result = dt.Select(str_where)
                Else
                    If txt_lcnno_no.Text <> "" Then
                        str_where = "lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                    End If
                    r_result = dt.Select(str_where)

                End If
                If txt_lcnsid.Text <> "" Then
                    str_where = "lcnsid='" & txt_lcnsid.Text & "'"

                End If
                r_result = dt.Select(str_where)
            End If
        dt2 = dt.Clone

            For Each dr As DataRow In r_result
                dt2.Rows.Add(dr.ItemArray)
            Next
            RadGrid1.DataSource = dt2
        End If


    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim u1 As String
            Dim lcntpcd As String = ""
            Dim lcntpcd_old As String = ""
            Dim lcnno As String = ""
            Dim CITIZEN_AUTHORIZE As String = ""
            lcntpcd = item("lcntpcd2").Text
            lcntpcd_old = item("lcntpcd").Text
            lcnno = item("lcnno").Text
            u1 = item("Newcode_not").Text
            CITIZEN_AUTHORIZE = item("CITIZEN_AUTHORIZE").Text
            If e.CommandName = "sel" Then
                
                u1 = u1.EncodeBase64
                lcntpcd = lcntpcd.EncodeBase64
                lcnno = lcnno.EncodeBase64
                CITIZEN_AUTHORIZE = CITIZEN_AUTHORIZE.EncodeBase64
                lcntpcd_old = lcntpcd_old.EncodeBase64
                Response.Redirect("FRM_EXTEND_TIME_LOCATION_MAIN.aspx?u1=" & u1 & "&lcncode=" & lcntpcd & "&lcn=" & lcnno & "&type=" & item("type_table").Text & "&c=" & CITIZEN_AUTHORIZE & "&lcncode_o=" & lcntpcd_old)
                'Dim id_r As String = item("IDA").Text
                'Dim url2 As String = "../FRM_EXTEND_TIME_LOCATION_MAIN.aspx?id_r=" & id_r
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url2 & "');", True)
                'ElseIf e.CommandName = "stat" Then
                '    Dim IDA As String = item("IDA").Text
                '    Dim url2 As String = "../CHANGE_STATUS/NEW/FRM_ETRACKING_STATUS_HEAD_MAIN_RQ_CENTER.aspx?id_r=" & IDA & "&r=1"
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('" & url2 & "');", True)
            ElseIf e.CommandName = "save" Then
                'Dim u1 As String
                u1 = item("Newcode_not").Text
                u1 = u1.EncodeBase64
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_EXTEND_TIME_LOCATION_SAVE.aspx?u1=" & u1 & "'); ", True)
                'Response.Redirect("FRM_REPORT_ADDRESS.aspx?u1=" & u1)
            ElseIf e.CommandName = "print" Then
                u1 = item("Newcode_not").Text
                u1 = u1.EncodeBase64
                lcntpcd = lcntpcd.EncodeBase64
                lcnno = lcnno.EncodeBase64
                CITIZEN_AUTHORIZE = CITIZEN_AUTHORIZE.EncodeBase64
                lcntpcd_old = lcntpcd_old.EncodeBase64
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('FRM_REPORT_ADDRESS.aspx?u1=" & u1 & "&lcncode=" & lcntpcd & "&lcn=" & lcnno & "&type=" & item("type_table").Text & "&c=" & CITIZEN_AUTHORIZE & "&lcncode_o=" & lcntpcd_old & "'); ", True)
                'Response.Redirect("FRM_REPORT_ADDRESS.aspx?u1=" & u1)
            End If
        End If
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.MasterTableView.ExportToExcel()
        RadGrid1.ExportSettings.IgnorePaging = True
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

    'Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
    '    Search_FN()
    'End Sub
End Class