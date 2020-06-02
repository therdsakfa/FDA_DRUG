Public Class FRM_HERB_PRODUCT_MAIN
    Inherits System.Web.UI.Page
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

    End Sub

    Private Sub btn_drug_Click(sender As Object, e As EventArgs) Handles btn_drug.Click
        'If _CLS.ID_MENU = "8734002" Then
        'Dim ws As New WS_AUTHENTICATION.Authentication
        'ws.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734002")
        Dim _TOKEN As String = _CLS.TOKEN

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Dim xml As String = ""
        ''Dim aa As String = ""

        Try
            ws_118.Timeout = 10000
            'xml = ws_118.Authen_Login(_TOKEN)
            xml = ws_118.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734002")
            If xml = "" Then
                ws_66.Timeout = 10000
                'xml = ws_66.Authen_Login(_TOKEN)
                xml = ws_66.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734002")
                If xml = "" Then
                    ws_104.Timeout = 10000
                    'xml = ws_104.Authen_Login(_TOKEN)
                    xml = ws_104.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734002")
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                    End If
                End If
            End If
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                xml = ws_66.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734002")
                If xml = "" Then
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734002")
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                End If
            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734002")
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try

        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)
        Dim _description As String = clsxml.Get_Value_XML("Description")
        Dim i As Integer = 0
        Dim bao_a As New BAO.ClsDBSqlcommand
        i = bao_a.Count_Permission_Menu(_CLS.SYSTEM_ID, _CLS.GROUPS, "8734002", _CLS.CITIZEN_ID_AUTHORIZE)
        'If i > 0 Then

        '    Session("CLS") = _CLS
        'End If
        If i > 0 Then '_description = "ALLOW" Then
            _CLS.ID_MENU = 8734002
            Session("CLS") = _CLS
            Response.Redirect("../MAIN/FRM_MAIN_PAGE_PRODUCT.aspx")
            'Response.Redirect("https://medicina.fda.moph.go.th/FDA_DRUG/MAIN/FRM_MAIN_PAGE_PRODUCT.aspx")
            '
        Else
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ไม่มีสทธิการเข้าใช้ระบบ " & _CLS.GROUPS & "," & _CLS.ID_MENU & "," & _CLS.SYSTEM_ID & "," & _CLS.CITIZEN_ID_AUTHORIZE & "');", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ไม่มีสิทธิการเข้าใช้ระบบ');", True)
        End If

        'Else

        'End If

    End Sub

    Private Sub btn_food_Click(sender As Object, e As EventArgs) Handles btn_food.Click
        ' If _CLS.ID_MENU = "8734001" Then
        'If _CLS.ID_MENU = "8734001" Then
        'Dim ws As New WS_AUTHENTICATION.Authentication
        'ws.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734001")

        Dim _TOKEN As String = _CLS.TOKEN

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Dim xml As String = ""
        Try
            ws_118.Timeout = 10000
            'xml = ws_118.Authen_Login(_TOKEN)
            xml = ws_118.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734001")
            If xml = "" Then
                ws_66.Timeout = 10000
                'xml = ws_66.Authen_Login(_TOKEN)
                xml = ws_66.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734001")
                If xml = "" Then
                    ws_104.Timeout = 10000
                    'xml = ws_104.Authen_Login(_TOKEN)
                    xml = ws_104.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734001")
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                    End If
                End If
            End If
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                xml = ws_66.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734001")
                If xml = "" Then
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734001")
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                End If
            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login_MENU(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "8734001")
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)
        Dim _description As String = clsxml.Get_Value_XML("Description")
        If _description = "ALLOW" Then
            _CLS.ID_MENU = "8734001"
            Session("CLS") = _CLS
            Response.Redirect("http://alimentum.fda.moph.go.th/FDA_FOOD_HERB?token=" & _CLS.TOKEN)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ไม่มีสิทธิการเข้าใช้ระบบ');", True)
        End If



        'Else

        'End If

        'Else
        'Response.Redirect("https://privus.fda.moph.go.th/")
        'End If

    End Sub
End Class