Imports Telerik.Web.UI

Public Class FRM_REGISTRATION_SEARCH
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

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            Dim iden As String = ""
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA(item("IDA").Text)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                Try
                    iden = dao.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception

                End Try
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_REGISTRATION_CONFIRM_STAFF.aspx?IDA=" & item("IDA").Text & "&TR_ID=" & tr_id & "&process=" & dao.fields.PROCESS_ID & "');", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../REGISTRATION/POPUP_REGISTRATION_CONFIRM.aspx?IDA=" & item("IDA").Text & "&TR_ID=" & tr_id & "&process=" & dao.fields.PROCESS_ID & "');", True)
            ElseIf e.CommandName = "_trid" Then
                Dim TR_ID As String = ""
                Dim _ProcessID As String = ""
                Dim bao_tran As New BAO_TRANSECTION

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
            ElseIf e.CommandName = "_add2" Then
                dao.GetDataby_IDA(item("IDA").Text)
                Try
                    If dao.fields.PROCESS_ID = "130002" Or dao.fields.PROCESS_ID = "130004" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('../REGISTRATION/FRM_REGISTRATION_ANIMAL_DETAIL_OTHER.aspx?IDA=" & item("IDA").Text & "&req=1" & "&process=" & dao.fields.PROCESS_ID & "&identify=" & iden & "&staff=1&a=1');", True)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & item("IDA").Text & "&req=1" & "&process=" & dao.fields.PROCESS_ID & "&identify=" & iden & "&staff=1');", True)
                    End If
                Catch ex As Exception

                End Try
            ElseIf e.CommandName = "choose" Then
                dao.GetDataby_IDA(item("IDA").Text)
                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                Try
                    dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
                Catch ex As Exception

                End Try
                Dim url As String = "../TABEAN_YA/TABEAN_YA_MAIN.aspx?main_ida=" & item("IDA").Text & "&process=1400001" & "&lcn_ida=" & dao.fields.FK_IDA & "&lct_ida=" & dao_lcn.fields.FK_IDA
                    If Request.QueryString("staff") <> "" Then
                        url &= "&staff=1&identify=" & Request.QueryString("identify")
                    End If
                    Response.Redirect(url)
            End If
        End If
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub
    Sub Search_FN()
        Dim pvncd As Integer = 0
        Try
            pvncd = _CLS.PVCODE

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_DRUG_REGISTRATION_ALL "
        Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_CITIZEN_AUTHORIZE.Text = "" And txt_rcv_no.Text = "" And txt_drugname.Text = "" Then
            command &= str_where
        Else
            If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                str_where = "where CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
                If txt_rcv_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and RCVNO_SEARCH like '%" & txt_rcv_no.Text & "%'"
                    Else
                        str_where &= " RCVNO_SEARCH like '%" & txt_rcv_no.Text & "%'"
                    End If

                End If
                If txt_drugname.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and DRG_NAME like '%" & txt_drugname.Text & "%'"
                    Else
                        str_where &= " DRG_NAME like '%" & txt_drugname.Text & "%'"
                    End If
                End If
                'r_result = dt.Select(str_where)
                command &= str_where
            Else
                If str_where = "" Then
                    'If str_where <> "" Then
                    If txt_rcv_no.Text <> "" Then
                        str_where &= " where RCVNO_SEARCH like '%" & txt_rcv_no.Text & "%'"
                    End If

                    If txt_drugname.Text <> "" Then
                        If str_where <> "" Then
                            str_where &= " and DRG_NAME like '%" & txt_drugname.Text & "%'"
                        Else
                            str_where &= " where DRG_NAME like '%" & txt_drugname.Text & "%'"
                        End If

                    End If
                    'Else
                    '    If txt_rcv_no.Text <> "" Then
                    '        str_where = "where RCVNO_SEARCH like '%" & txt_rcv_no.Text & "%'"

                    '    End If
                    '    If txt_drugname.Text <> "" Then
                    '        If str_where <> "" Then
                    '            str_where &= " and DRG_NAME like '%" & txt_rcv_no.Text & "%'"
                    '        Else
                    '            str_where &= " where DRG_NAME like '%" & txt_rcv_no.Text & "%'"
                    '        End If
                    '    End If
                    'End If

                    command &= str_where
                Else
                    If txt_rcv_no.Text <> "" Then
                        str_where = "and RCVNO_SEARCH like '%" & txt_rcv_no.Text & "%'"

                    End If
                    If txt_drugname.Text <> "" Then
                        If str_where <> "" Then
                            str_where &= " and DRG_NAME like '%" & txt_drugname.Text & "%'"
                            'Else
                            '    str_where &= " where DRG_NAME like '%" & txt_rcv_no.Text & "%'"
                        End If
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
        ''pvncd = 12
        'If rdl_stat.SelectedValue = 0 Then
        '    If pvncd = 10 Then
        '        'RadGrid1.DataSource = dt2

        '        'command &= str_where
        '    Else
        '        'RadGrid1.DataSource = dt2.Select("pvncd = '" & pvncd & "'")
        '        If command.Contains("where") Then
        '            command &= " and pvncd = '" & pvncd & "'"
        '        Else
        '            command &= "where pvncd = '" & pvncd & "'"
        '        End If

        '    End If

        'ElseIf rdl_stat.SelectedValue = 1 Then
        '    If pvncd = 10 Then
        '        'RadGrid1.DataSource = dt2.Select("lcn_stat=0")
        '        If command.Contains("where") Then
        '            command &= " and lcn_stat=0"
        '        Else
        '            If command.Contains("pvncd") Then
        '                command &= " and lcn_stat=0"
        '            Else
        '                command &= "where lcn_stat=0"
        '            End If
        '        End If

        '    Else
        '        'RadGrid1.DataSource = dt2.Select("lcn_stat=0 and pvncd = '" & pvncd & "'")
        '        If command.Contains("where") Then
        '            command &= " and lcn_stat=0 and pvncd = '" & pvncd & "'"
        '        Else
        '            command &= "where lcn_stat=0 and pvncd = '" & pvncd & "'"
        '        End If

        '    End If

        'ElseIf rdl_stat.SelectedValue = 2 Then
        '    If pvncd = 10 Then
        '        If command.Contains("where") Then
        '            command &= " and lcn_stat=0"
        '        Else
        '            If command.Contains("pvncd") Then
        '                command &= " and lcn_stat=0"
        '            Else
        '                command &= "where lcn_stat=0"
        '            End If
        '        End If
        '    Else
        '        'RadGrid1.DataSource = dt2.Select("lcn_stat=1 and pvncd = '" & pvncd & "'")
        '        If command.Contains("where") Then
        '            command &= " and lcn_stat=1 and pvncd = '" & pvncd & "'"
        '        Else
        '            command &= "where lcn_stat=1 and pvncd = '" & pvncd & "'"
        '        End If
        '    End If

        'End If
        dt = bao_aa.Queryds(command)
        RadGrid1.DataSource = dt

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_trid As LinkButton = DirectCast(item("btn_trid").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao.GetDataby_IDA(IDA)
            btn_trid.Style.Add("display", "none")
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
        If txt_CITIZEN_AUTHORIZE.Text <> "" Or txt_rcv_no.Text <> "" Or txt_drugname.Text <> "" Then
            Search_FN()
        End If
    End Sub
End Class