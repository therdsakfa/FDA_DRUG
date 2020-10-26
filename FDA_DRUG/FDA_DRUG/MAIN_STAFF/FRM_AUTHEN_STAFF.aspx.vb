Public Class FRM_AUTHEN_STAFF
    Inherits System.Web.UI.Page

    Dim clsDBSqlCommand As New BAO.ClsDBSqlcommand
    Dim clsDBSyslcnsid As New DAO_CPN.clsDBsyslcnsid
    Dim clsDBSyslcnsnm As New DAO_CPN.clsDBsyslcnsnm

    Private _CLS As New CLS_SESSION


    Private _TOKEN As String
    Private Sub RunQuery()
        '_TOKEN = Request("Token").ToString()
        _TOKEN = "WhYGDF5yZcMBL1lLozyX5wUU" '--------
        '_TOKEN = "N/J1pNwqJ2fJvZ/1jRPoRwUU"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            session_clear()
            RunQuery()
            token()
        End If
    End Sub
    Sub session_clear()
        'Session.Abandon()
        Session.Clear()
    End Sub

    Sub token()
        Dim token As String = _TOKEN
        Dim urls As String = ""
        'Try
        '    urls = Request.UrlReferrer.AbsoluteUri 'ตรวจสอบว่าเป็นการส่งมาจาก privus หรือไม่
        '    If urls.Contains("privus.fda.moph.go.th") Then
        '    Else 'กรณีต้นทางไม่ใช่มาจาก privus ให้ย้อนกลับไปที่ privus
        '        Response.Redirect("https://privus.fda.moph.go.th")
        '    End If
        'Catch ex As Exception 'กรณีตรวจสอบไม่เจอ url ต้นทางให้ย้อนกลับไปที่ privus
        '    Response.Redirect("https://privus.fda.moph.go.th")
        'End Try

        Dim ws As New WS_AUTHENTICATION.Authentication
        ' Dim xml As String = ""
        If token = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'https://privus.fda.moph.go.th';", True)
            Response.Redirect("https://privus.fda.moph.go.th")
        End If
        ' xml = ws.Authen_Login(token)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Dim xml As String = ""
        Try
            ws_118.Timeout = 10000
            xml = ws_118.Authen_Login(_TOKEN)

            If xml = "" Then
                ws_66.Timeout = 10000
                xml = ws_66.Authen_Login(_TOKEN)
                If xml = "" Then
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login(_TOKEN)
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                    End If
                End If
            End If
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                xml = ws_66.Authen_Login(_TOKEN)
                If xml = "" Then
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login(_TOKEN)
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End If
                End If
            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login(_TOKEN)
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

        For Each cc In clsxml.Get_ListValue_XML("")

        Next

        _CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        _CLS.TOKEN = token
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
        _CLS.ID_MENU = "510000"

        Dim bao As New BAO.information
        '_CLS = bao.load_lcnsid_customer(_CLS)
        _CLS = bao.load_name(_CLS)

        Session("CLS") = _CLS


        ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")


        ' ws.Authen_Login(token)
        ' Dim cls_xml As New Cls_XML
        Dim code As String = clsxml.Get_Value_XML("CODE")

        'Dim CITIEZEN_ID_AUTHORIZE As String = ""
        Dim description As String = ""

        If code = "900" Then
            Try
                Response.Redirect("FRM_PROCESS.aspx")
            Catch ex As Exception
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาด');window.location.href = 'http://privus.fda.moph.go.th';", True)
            End Try

            'Response.Redirect("FRM_CLOSE.aspx")
        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "102" Then
            description = clsxml.Get_Value_XML("Description")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('!เกิดข้อผิดพลาด!\nชื่อผู้ใช้นี้ มีการเข้าใช้ระบบนี้อยู่แล้ว\n" & description & "');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If
    End Sub
End Class