Imports Telerik.Web.UI

Public Class FRM_STAFF_LCN_SEARCH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

    End Sub
    Sub Search_FN()
        Dim pvncd As Integer = 0
        Try
            pvncd = _CLS.PVCODE
            'pvncd = 10
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        'Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_DALCN_SEARCH_EDIT()

        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_SP_DALCN_SEARCH_EDIT "

        'Dim dt As New DataTable
        'Try
        '    dt = bao.dt
        'Catch ex As Exception

        'End Try

        'Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_CITIZEN_AUTHORIZE.Text = "" And txt_lcnno_no.Text = "" Then
            'If pvncd = 10 Then
            '    RadGrid1.DataSource = dt
            'Else
            '    RadGrid1.DataSource = dt.Select("pvncd = '" & pvncd & "'")
            'End If
            command &= str_where
        Else
            If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                str_where = "where CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
                If txt_lcnno_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                    Else
                        str_where &= "lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                    End If

                End If
                'r_result = dt.Select(str_where)
                command &= str_where
            Else
                If str_where = "" Then
                    If str_where <> "" Then
                        If txt_lcnno_no.Text <> "" Then
                            str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                        End If
                    Else
                        If txt_lcnno_no.Text <> "" Then
                            str_where = "where lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                        End If
                    End If
                    'r_result = dt.Select(str_where)
                    command &= str_where
                Else
                    If txt_lcnno_no.Text <> "" Then
                        str_where = "where lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                    End If
                    'r_result = dt.Select(str_where)
                    command &= str_where
                End If
                'r_result = dt.Select(str_where)
                'command &= str_where
            End If
            'dt2 = dt.Clone

            'For Each dr As DataRow In r_result
            '    dt2.Rows.Add(dr.ItemArray)
            'Next


            

            '----new
            
        End If
        'pvncd = 12
        If rdl_stat.SelectedValue = 0 Then
            If pvncd = 10 Then
                'RadGrid1.DataSource = dt2

                'command &= str_where
            Else
                'RadGrid1.DataSource = dt2.Select("pvncd = '" & pvncd & "'")
                If command.Contains("where") Then
                    command &= " and pvncd = '" & pvncd & "' and lcntpcd <> 'ผย1' "
                Else
                    command &= "where pvncd = '" & pvncd & "' and lcntpcd <> 'ผย1'"
                End If

            End If

        ElseIf rdl_stat.SelectedValue = 1 Then
            If pvncd = 10 Then
                'RadGrid1.DataSource = dt2.Select("lcn_stat=0")
                If command.Contains("where") Then
                    command &= " and lcn_stat=0"
                Else
                    If command.Contains("pvncd") Then
                        command &= " and lcn_stat=0 and lcntpcd <> 'ผย1' "
                    Else
                        command &= "where lcn_stat=0 and lcntpcd <> 'ผย1' "
                    End If
                End If

            Else
                'RadGrid1.DataSource = dt2.Select("lcn_stat=0 and pvncd = '" & pvncd & "'")
                If command.Contains("where") Then
                    command &= " and lcn_stat=0 and pvncd = '" & pvncd & "'"
                Else
                    command &= "where lcn_stat=0 and pvncd = '" & pvncd & "'"
                End If

            End If

        ElseIf rdl_stat.SelectedValue = 2 Then
            If pvncd = 10 Then
                If command.Contains("where") Then
                    command &= " and lcn_stat=0"
                Else
                    If command.Contains("pvncd") Then
                        command &= " and lcn_stat=0  and lcntpcd <> 'ผย1' "
                    Else
                        command &= "where lcn_stat=0  and lcntpcd <> 'ผย1' "
                    End If
                End If
            Else
                'RadGrid1.DataSource = dt2.Select("lcn_stat=1 and pvncd = '" & pvncd & "'")
                If command.Contains("where") Then
                    command &= " and lcn_stat=1 and pvncd = '" & pvncd & "'"
                Else
                    command &= "where lcn_stat=1 and pvncd = '" & pvncd & "'"
                End If
            End If

        End If
        dt = bao_aa.Queryds(command)
        RadGrid1.DataSource = dt

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then
                Response.Redirect("FRM_LCN_STAFF_LCN_INFORMATION.aspx?IDA=" & item("IDA").Text)
            ElseIf e.CommandName = "_trid" Then
                Dim TR_ID As String = ""
                Dim _ProcessID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                Dim dao As New DAO_DRUG.ClsDBdalcn
                Try
                    dao.GetDataby_IDA(item("IDA").Text)
                Catch ex As Exception

                End Try
                Try
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                Catch ex As Exception
                    bao_tran.CITIZEN_ID = ""
                End Try
                Try
                    bao_tran.CITIZEN_ID_AUTHORIZE = dao.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception
                    bao_tran.CITIZEN_ID_AUTHORIZE = ""
                End Try
                Try
                    _ProcessID = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                TR_ID = bao_tran.insert_transection_new(_ProcessID)
                dao.fields.TR_ID = TR_ID
                dao.update()
                RadGrid1.Rebind()
            ElseIf e.CommandName = "drug_group" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                Try
                    dao.GetDataby_IDA(item("IDA").Text)
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD.aspx?ida=" & item("IDA").Text & "&TR_ID=" & dao.fields.TR_ID & "&process=" & dao.fields.PROCESS_ID & "&edit=1&n=1" & "');", True)

            End If
        End If

    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_SP_DALCN_SEARCH_EDIT "
        Dim pvncd As Integer = 0
        Try
            pvncd = _CLS.PVCODE
        Catch ex As Exception

        End Try
        'Dim dt As New DataTable
        'Try
        '    dt = bao.dt
        'Catch ex As Exception

        'End Try

        'Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_CITIZEN_AUTHORIZE.Text = "" And txt_lcnno_no.Text = "" Then
            'If pvncd = 10 Then
            '    RadGrid1.DataSource = dt
            'Else
            '    RadGrid1.DataSource = dt.Select("pvncd = '" & pvncd & "'")
            'End If
            command &= str_where
        Else
            If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                str_where = "where CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
                If txt_lcnno_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                    Else
                        str_where &= "lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                    End If

                End If
                'r_result = dt.Select(str_where)
                command &= str_where
            Else
                If str_where = "" Then
                    If str_where <> "" Then
                        If txt_lcnno_no.Text <> "" Then
                            str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%'"
                        End If
                    Else
                        If txt_lcnno_no.Text <> "" Then
                            str_where = "where lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                        End If
                    End If
                    'r_result = dt.Select(str_where)
                    command &= str_where
                Else
                    If txt_lcnno_no.Text <> "" Then
                        str_where = "where lcnno_no like '%" & txt_lcnno_no.Text & "%'"

                    End If
                    'r_result = dt.Select(str_where)
                    command &= str_where
                End If
                'r_result = dt.Select(str_where)
                'command &= str_where
            End If
            'dt2 = dt.Clone

            'For Each dr As DataRow In r_result
            '    dt2.Rows.Add(dr.ItemArray)
            'Next




            '----new

        End If
        'pvncd = 12
        If rdl_stat.SelectedValue = 0 Then
            If pvncd = 10 Then
                'RadGrid1.DataSource = dt2

                'command &= str_where
            Else
                'RadGrid1.DataSource = dt2.Select("pvncd = '" & pvncd & "'")
                If command.Contains("where") Then
                    command &= " and pvncd = '" & pvncd & "' and lcntpcd <> 'ผย1' "
                Else
                    command &= "where pvncd = '" & pvncd & "' and lcntpcd <> 'ผย1'"
                End If

            End If

        ElseIf rdl_stat.SelectedValue = 1 Then
            If pvncd = 10 Then
                'RadGrid1.DataSource = dt2.Select("lcn_stat=0")
                If command.Contains("where") Then
                    command &= " and lcn_stat=0"
                Else
                    If command.Contains("pvncd") Then
                        command &= " and lcn_stat=0 and lcntpcd <> 'ผย1' "
                    Else
                        command &= "where lcn_stat=0 and lcntpcd <> 'ผย1' "
                    End If
                End If

            Else
                'RadGrid1.DataSource = dt2.Select("lcn_stat=0 and pvncd = '" & pvncd & "'")
                If command.Contains("where") Then
                    command &= " and lcn_stat=0 and pvncd = '" & pvncd & "'"
                Else
                    command &= "where lcn_stat=0 and pvncd = '" & pvncd & "'"
                End If

            End If

        ElseIf rdl_stat.SelectedValue = 2 Then
            If pvncd = 10 Then
                If command.Contains("where") Then
                    command &= " and lcn_stat=0"
                Else
                    If command.Contains("pvncd") Then
                        command &= " and lcn_stat=0  and lcntpcd <> 'ผย1' "
                    Else
                        command &= "where lcn_stat=0  and lcntpcd <> 'ผย1' "
                    End If
                End If
            Else
                'RadGrid1.DataSource = dt2.Select("lcn_stat=1 and pvncd = '" & pvncd & "'")
                If command.Contains("where") Then
                    command &= " and lcn_stat=1 and pvncd = '" & pvncd & "'"
                Else
                    command &= "where lcn_stat=1 and pvncd = '" & pvncd & "'"
                End If
            End If

        End If
        dt = bao_aa.Queryds(command)

        export_excel(dt)


    End Sub
    Private Sub export_excel(ByVal dt As DataTable)
        Dim dt2 As New DataTable
        dt2.Columns.Add("ประเภทคำขอ")
        dt2.Columns.Add("เลขที่ใบอนุญาต")
        dt2.Columns.Add("ชื่อสถานที่")

        dt2.Columns.Add("ที่อยู่")
        dt2.Columns.Add("ชื่อผู้ดำเนินกิจการ")

        dt2.Columns.Add("จังหวัด")
        dt2.Columns.Add("เลขดำเนินการ")
        For Each dr As DataRow In dt.Rows
            Dim dr2 As DataRow = dt2.NewRow()
            dr2("ประเภทคำขอ") = dr("lcntpcd")
            dr2("เลขที่ใบอนุญาต") = dr("lcnno_no")
            dr2("ชื่อสถานที่") = dr("thanm")
            dr2("ที่อยู่") = dr("thanm_addr")
            dr2("ชื่อผู้ดำเนินกิจการ") = dr("grannm_lo")
            dr2("จังหวัด") = dr("thachngwtnm")
            dr2("เลขดำเนินการ") = dr("TR_ID")
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

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_trid As LinkButton = DirectCast(item("btn_trid").Controls(0), LinkButton)
            Dim btn_drug_group As LinkButton = DirectCast(item("btn_drug_group").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(IDA)
            btn_trid.Style.Add("display", "none")
            btn_drug_group.Style.Add("display", "none")
            Try
                If dao.fields.lcntpcd = "ผย1" Then
                    btn_drug_group.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If tr_id = 0 Then
                btn_trid.Style.Add("display", "block")
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        If txt_CITIZEN_AUTHORIZE.Text <> "" Or txt_lcnno_no.Text <> "" Then
            Search_FN()
        End If
    End Sub

    Protected Sub btn_export_phr_Click(sender As Object, e As EventArgs) Handles btn_export_phr.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.GET_Vw_dalcn_phr()

        Dim str_where As String = ""
        Dim r_result As DataRow()
        Dim dt2 As New DataTable
        If _CLS.PVCODE <> 10 Then
            str_where = "chngwtcd = '" & _CLS.PVCODE & "'"
            If rdl_stat.SelectedValue <> "0" Then
                str_where &= " and cncnm = '" & rdl_stat.SelectedItem.Text & "'"
            End If
            If txt_lcnno_no.Text <> "" Then
                str_where &= " and LCNNO_MANUAL like '%" & txt_lcnno_no.Text & "%'"
            End If

            If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                str_where &= " and CITIZEN_ID_AUTHORIZE = '" & txt_CITIZEN_AUTHORIZE.Text & "'"
            End If
            r_result = dt.Select(str_where)
            dt2 = dt.Clone

            For Each dr As DataRow In r_result
                dt2.Rows.Add(dr.ItemArray)
            Next
        Else
            If str_where = "" Then
                If txt_lcnno_no.Text <> "" Then
                    str_where &= "LCNNO_MANUAL like '%" & txt_lcnno_no.Text & "%'"
                End If
            Else
                If txt_lcnno_no.Text <> "" Then
                    str_where &= " and LCNNO_MANUAL like '%" & txt_lcnno_no.Text & "%'"
                End If
            End If

            If str_where = "" Then
                If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                    str_where &= "CITIZEN_ID_AUTHORIZE = '" & txt_CITIZEN_AUTHORIZE.Text & "'"
                End If
            Else
                If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                    str_where &= " and CITIZEN_ID_AUTHORIZE = '" & txt_CITIZEN_AUTHORIZE.Text & "'"
                End If
            End If


            r_result = dt.Select(str_where)
            dt2 = dt.Clone

            For Each dr As DataRow In r_result
                dt2.Rows.Add(dr.ItemArray)
            Next
        End If


        export_excel2(dt2)
    End Sub
    Private Sub export_excel2(ByVal dt As DataTable)
        Dim dt2 As New DataTable
        dt2.Columns.Add("ชื่อ")
        dt2.Columns.Add("นามสกุล")
        dt2.Columns.Add("เวลาทำการ")

        dt2.Columns.Add("เลขภ.")
        dt2.Columns.Add("เลขใบอนุญาต")
        dt2.Columns.Add("จังหวัด")
        dt2.Columns.Add("สถานะ")

        For Each dr As DataRow In dt.Rows
            Dim dr2 As DataRow = dt2.NewRow()
            dr2("ชื่อ") = dr("phrnm")
            dr2("นามสกุล") = dr("thalnm")
            dr2("เวลาทำการ") = dr("PHR_TEXT_WORK_TIME")
            dr2("เลขภ.") = dr("PHR_TEXT_NUM")
            dr2("เลขใบอนุญาต") = dr("LCNNO_MANUAL")
            dr2("จังหวัด") = dr("thachngwtnm")
            dr2("สถานะ") = dr("cncnm")
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

    Protected Sub btn_template_Click(sender As Object, e As EventArgs) Handles btn_template.Click
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Dim path As String = bao._PATH_DEFAULT '"C:\path\XML_CLASS\"
        'path = path & filename.ToString() & ".xml"
        path = path & "PDF_TEMPLATE\" & "lcn_template.xlsx"

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & "LCN_TEMPLATE.xlsx")
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()
    End Sub
End Class