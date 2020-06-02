Imports Telerik.Web.UI

Public Class FRM_E_TRACKING_MANAGE
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim dao_d As New DAO_DRUG.TB_E_TRACKING_BASE
                dao_d.get_max_update()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "stat" Then

            ElseIf e.CommandName = "report" Then


            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("IDA").Text
            Dim rcvno As String = item("rcvno").Text
            Dim ctzid As String = item("ctzid").Text
            Dim rgttpcd As String = item("rgttpcd").Text
            Dim btn_stat As LinkButton = DirectCast(item("stat").Controls(0), LinkButton)
            Dim btn_print As LinkButton = DirectCast(item("report").Controls(0), LinkButton)
            ' btn_sel.Attributes.Add("OnClick", "Popups2('FRM_E_TRACKING_TIME_CAL_POPUP.aspx?ida=" & id & "'); return false;")

            Dim url1 As String = "../CHANGE_STATUS/FRM_DRRGT_STATUS_POPUPV2.aspx?rcvno=" & rcvno & "&ctzid=" & ctzid & "&ntype=" & rgttpcd
            Dim url2 As String = "../TIME_CALCULATE/FRM_E_TRACKING_TIME_CAL_POPUP2.aspx?rcvno=" & rcvno & "&ctzid=" & ctzid & "&ntype=" & rgttpcd
            btn_print.Attributes.Add("OnClick", "Popups3('" & url2 & "'); return false;")
            btn_stat.Attributes.Add("OnClick", "Popups2('" & url1 & "'); return false;")
        End If
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../CHANGE_STATUS/FRM_DRRGT_STATUS_POPUP.aspx'); return false;", True)
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_E_TRACKING_PERSON_WORK_ALL()

        RadGrid1.DataSource = dt
    End Sub

    Private Sub export_excel2()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'dt = bao.SP_E_TRACKING_PERSON_WORK(Request.QueryString("gid"), Request.QueryString("col4"), "(" & Request.QueryString("col5") & ")", Request.QueryString("iden"), Request.QueryString("t"))
        dt = bao.SP_E_TRACKING_PERSON_WORK_BY_IDEN_AND_COL5(Request.QueryString("iden"), Request.QueryString("col5"))
        Dim dt2 As New DataTable
        dt2.Columns.Add("เลขที่รับ")
        dt2.Columns.Add("วันที่รับคำขอ")
        dt2.Columns.Add("กลุ่มงาน")

        dt2.Columns.Add("ชื่อ-นามสกุลเจ้าหน้าที")
        dt2.Columns.Add("ประเภท")

        dt2.Columns.Add("ชื่อยา")
        dt2.Columns.Add("ผู้รับอนุญาต")

        dt2.Columns.Add("การรับคำขอ")
        For Each dr As DataRow In dt.Rows
            Dim dr2 As DataRow = dt2.NewRow()
            dr2("เลขที่รับ") = dr("rcvno_display")
            Try
                dr2("วันที่รับคำขอ") = CDate(dr("rcvdate")).ToShortDateString()
            Catch ex As Exception

            End Try

            dr2("กลุ่มงาน") = dr("wrkuntnm")

            dr2("ชื่อ-นามสกุลเจ้าหน้าที") = dr("stfthanm")
            dr2("ประเภท") = dr("WORK_NAME2")

            dr2("ชื่อยา") = dr("drgnm")
            dr2("ผู้รับอนุญาต") = dr("thanm")

            dr2("การรับคำขอ") = dr("rqt_type")
            dt2.Rows.Add(dr2)
        Next

        'For ii As Integer = 0 To dt2.Columns.Count - 1
        '    If ii > 1 Then
        '        dt2.Columns.RemoveAt(ii)
        '    End If

        'Next

        Dim filename As String = ""
        filename = "Export_" & Date.Now.ToString("ddMMyyyy")

        Dim attachment As String = "attachment; filename=" & filename & ".xls"
        Response.ClearContent()
        Response.Charset = "windows-874"
        Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim tab As String = ""
        For Each dc As DataColumn In dt2.Columns
            Response.Write(tab + dc.ColumnName)
            tab = vbTab
        Next
        Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dt2.Rows
            tab = ""
            For i = 0 To dt2.Columns.Count - 1
                Response.Write(tab & dr(i).ToString())
                tab = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()

    End Sub
    Public Function ObjecttoCSV(table As DataTable) As String
        Dim result = New StringBuilder()
        For i As Integer = 0 To table.Columns.Count - 1
            result.Append(table.Columns(i).ColumnName)
            result.Append(If(i = table.Columns.Count - 1, vbLf, ","))
        Next

        For Each row As DataRow In table.Rows
            For i As Integer = 0 To table.Columns.Count - 1
                result.Append(row(i).ToString())
                result.Append(If(i = table.Columns.Count - 1, vbLf, ","))
            Next
        Next

        Return result.ToString()
    End Function

    'Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
    '    export_excel2()
    'End Sub


End Class