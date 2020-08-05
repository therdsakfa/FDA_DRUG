Public Class MAIN_STAFF
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Try
            If Request.QueryString("FK_IDA") <> "" Then

            Else

            End If
        Catch ex As Exception

        End Try
        If Not IsPostBack Then
            run_nav_new()
            Try
                lb_login.Text = _CLS.THANM
            Catch ex As Exception

            End Try
            run_header_nav()
        End If
        Dim ws As New WS_AUTHENTICATION.Authentication
        ws.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU)
    End Sub
    Public Sub run_nav_new()
        Dim dao_h As New DAO_DRUG.TB_MAS_ADMIN_GROUP_BUTTON
        Dim gg As String = ""
        Try
            gg = _CLS.GROUPS
        Catch ex As Exception

        End Try
        If gg <> "" Then
            Try
                dao_h.GetData_By_Group_Order_By_Seq(gg)
            Catch ex As Exception

            End Try

            Dim str_all As String = ""
            For Each dao_h.fields In dao_h.datas
                If str_all = "" Then
                    str_all = "<h4 class='text-center'><strong>" & dao_h.fields.GROUP_NAME & "</strong></h4>"
                    Dim p_name As String = ""
                    Try
                        p_name = get_page_name()
                    Catch ex As Exception

                    End Try
                    Dim aa As Integer = 0

                    Try
                        aa = _CLS.GROUPS
                    Catch ex As Exception

                    End Try
                    Dim _group As Integer = 0
                    If aa = 21020 Then
                        _group = 1
                    Else
                        _group = 2
                    End If
                    '_group = 2
                    Dim dao_g As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                    dao_g.GetDataby_Btn_Group_and_IdGroup(dao_h.fields.GROUP_ID, aa)

                    str_all &= "<ul class='nav nav-pills nav-stacked'>"
                    For Each dao_g.fields In dao_g.datas
                        Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                        Dim i As Integer = 0
                        If p_name <> "" Then
                            'i = dao_u.Check_Page(p_name, _CLS.Groups)
                            Try
                                If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
                                    i += 1
                                End If
                            Catch ex As Exception

                            End Try

                        End If
                        If i = 0 Then
                            str_all &= "<li>"
                        Else
                            str_all &= "<li class='active'>"
                        End If
                        If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
                            str_all &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
                        Else
                            str_all &= "<a href='" & dao_g.fields.BTN_URL & "' target='" & dao_g.fields.TARGET & "'>" & dao_g.fields.BTN_NAME & "</a>"
                        End If

                        str_all &= "</li>"
                        'i += 1
                    Next
                    str_all &= "</ul><br/>"

                Else
                    str_all &= "<h4 class='text-center'><strong>" & dao_h.fields.GROUP_NAME & "</strong></h4>"
                    Dim p_name As String = ""
                    Try
                        p_name = get_page_name()
                    Catch ex As Exception

                    End Try
                    Dim aa As Integer = 0

                    Try
                        aa = _CLS.GROUPS
                    Catch ex As Exception

                    End Try
                    Dim _group As Integer = 0
                    If aa = 21020 Then
                        _group = 1
                    Else
                        _group = 2
                    End If
                    '_group = 2
                    Dim dao_g As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                    dao_g.GetDataby_Btn_Group_and_IdGroup(dao_h.fields.GROUP_ID, aa)

                    str_all &= "<ul class='nav nav-pills nav-stacked'>"
                    For Each dao_g.fields In dao_g.datas
                        Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                        Dim i As Integer = 0
                        If p_name <> "" Then
                            'i = dao_u.Check_Page(p_name, _CLS.Groups)
                            Try
                                If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
                                    i += 1
                                End If
                            Catch ex As Exception

                            End Try

                        End If
                        If i = 0 Then
                            str_all &= "<li>"
                        Else
                            str_all &= "<li class='active'>"
                        End If
                        If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
                            str_all &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
                        Else
                            str_all &= "<a href='" & dao_g.fields.BTN_URL & "' target='" & dao_g.fields.TARGET & "'>" & dao_g.fields.BTN_NAME & "</a>"
                        End If

                        str_all &= "</li>"
                        'i += 1
                    Next
                    str_all &= "</ul><br/>"
                End If
                Literal1.Text = str_all
            Next
        End If



    End Sub
    'Public Sub run_nav()
    '    Dim p_name As String = ""
    '    Try
    '        p_name = get_page_name()
    '    Catch ex As Exception

    '    End Try
    '    Dim aa As Integer = 0

    '    Try
    '        aa = _CLS.GROUPS
    '    Catch ex As Exception

    '    End Try
    '    Dim _group As Integer = 0
    '    If aa = 21020 Then
    '        _group = 1
    '    Else
    '        _group = 2
    '    End If
    '    '_group = 2
    '    Dim dao_g As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '    dao_g.GetDataby_Btn_Group_and_IdGroup(1, aa)

    '    Dim str_table As String = ""
    '    str_table = "<ul class='nav nav-pills nav-stacked'>"
    '    For Each dao_g.fields In dao_g.datas
    '        Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '        Dim i As Integer = 0
    '        If p_name <> "" Then
    '            'i = dao_u.Check_Page(p_name, _CLS.Groups)
    '            Try
    '                If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
    '                    i += 1
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        End If
    '        If i = 0 Then
    '            str_table &= "<li>"
    '        Else
    '            str_table &= "<li class='active'>"
    '        End If
    '        If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
    '            str_table &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
    '        Else
    '            str_table &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"
    '        End If

    '        str_table &= "</li>"
    '        'i += 1
    '    Next
    '    str_table &= "</ul>"

    '    ltr_nav1.Text = str_table

    '    _group = 1
    '    dao_g = New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '    dao_g.GetDataby_Btn_Group_and_IdGroup(2, aa)
    '    Dim str_table2 As String = ""
    '    str_table2 = "<ul class='nav nav-pills nav-stacked'>"
    '    For Each dao_g.fields In dao_g.datas
    '        Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '        Dim i As Integer = 0
    '        If p_name <> "" Then
    '            'i = dao_u.Check_Page(p_name, _CLS.Groups)
    '            Try
    '                If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
    '                    i += 1
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        End If
    '        If i = 0 Then
    '            str_table2 &= "<li>"
    '        Else
    '            str_table2 &= "<li class='active'>"
    '        End If
    '        If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
    '            str_table2 &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
    '        Else
    '            str_table2 &= "<a href='" & dao_g.fields.BTN_URL & "'>" & dao_g.fields.BTN_NAME & "</a>"
    '        End If
    '        'str_table2 &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"

    '        str_table2 &= "</li>"
    '        i += 1
    '    Next
    '    str_table2 &= "</ul>"

    '    ltr_nav2.Text = str_table2


    '    dao_g = New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '    dao_g.GetDataby_Btn_Group_and_IdGroup(3, aa)
    '    Dim str_table3 As String = ""
    '    str_table3 = "<ul class='nav nav-pills nav-stacked'>"
    '    For Each dao_g.fields In dao_g.datas
    '        Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '        Dim i As Integer = 0
    '        If p_name <> "" Then
    '            'i = dao_u.Check_Page(p_name, _CLS.Groups)
    '            Try
    '                If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
    '                    i += 1
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        End If
    '        If i = 0 Then
    '            str_table3 &= "<li>"
    '        Else
    '            str_table3 &= "<li class='active'>"
    '        End If
    '        If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
    '            str_table3 &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
    '        Else
    '            str_table3 &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"
    '        End If
    '        'str_table3 &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"
    '        str_table3 &= "</li>"
    '        i += 1
    '    Next
    '    str_table3 &= "</ul>"

    '    ltr_nav3.Text = str_table3



    '    dao_g = New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '    dao_g.GetDataby_Btn_Group_and_IdGroup(0, aa)
    '    Dim str_table0 As String = ""
    '    str_table0 = "<ul class='nav nav-pills nav-stacked'>"
    '    For Each dao_g.fields In dao_g.datas
    '        Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
    '        Dim i As Integer = 0
    '        If p_name <> "" Then
    '            'i = dao_u.Check_Page(p_name, _CLS.Groups)
    '            Try
    '                If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
    '                    i += 1
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        End If
    '        If i = 0 Then
    '            str_table0 &= "<li>"
    '        Else
    '            str_table0 &= "<li class='active'>"
    '        End If
    '        If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
    '            str_table0 &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
    '        Else
    '            str_table0 &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"
    '        End If
    '        'str_table3 &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"
    '        str_table0 &= "</li>"
    '        i += 1
    '    Next
    '    str_table0 &= "</ul>"

    '    ltr_nav_top.Text = str_table0

    'End Sub
    Function get_page_name()
        Dim p_name As String = ""
        p_name = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
        Return p_name
    End Function
    Public Sub run_header_nav()
        Dim p_name As String = ""
        Dim _group As String = ""
        Try
            _group = _CLS.GROUPS
        Catch ex As Exception
            _group = 9999999
        End Try
        Try
            p_name = get_page_name()
        Catch ex As Exception

        End Try

        Dim dao_per As New DAO_PERMISSION.TB_taxnogrouppermission
        Try

        Catch ex As Exception

        End Try
        dao_per.GetDataby_IDgroup(_group)
        Dim dao_g As New DAO_DRUG.TB_MAS_ADMIN_HEADER_LINK
        dao_g.GetDataby_IDgroup(_group)
        Dim type_menu As Integer = 0
        Try
            type_menu = dao_per.fields.type
        Catch ex As Exception

        End Try

        Dim str_table As String = ""
        str_table = "<ul class='nav navbar-nav'>"
        For Each dao_g.fields In dao_g.datas
            Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
            Dim i As Integer = 0
            Dim dao_d As New DAO_DRUG.TB_MAS_NAV_ACTIVE_DETAIL

            Try
                dao_d.GetDataby_URL_AND_IDGROUP(p_name, _group)
                If dao_d.fields.SEQ = dao_g.fields.SEQ Then
                    str_table &= "<li class='active'>"
                Else
                    str_table &= "<li>"
                End If
            Catch ex As Exception

            End Try


            str_table &= "<a href='" & dao_g.fields.URL & "' >" & dao_g.fields.LINK_NAME & "</a>"
            str_table &= "</li>"
        Next
        str_table &= "</ul>"

        ltr_header_nav.Text = str_table
    End Sub
End Class