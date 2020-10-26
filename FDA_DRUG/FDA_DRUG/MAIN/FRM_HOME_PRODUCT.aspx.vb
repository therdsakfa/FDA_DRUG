Public Class FRM_HOME_PRODUCT
    Inherits System.Web.UI.Page
    Dim clsDBSqlCommand As New BAO.ClsDBSqlcommand
    Dim clsDBSyslcnsid As New DAO_CPN.clsDBsyslcnsid
    Dim clsDBSyslcnsnm As New DAO_CPN.clsDBsyslcnsnm

    Private _CLS As New CLS_SESSION
    Private _TOKEN As String

    Private Sub RunQuery()
        '_TOKEN = Request("Token").ToString()
        _TOKEN = "uMQbsgMwpMN5rnZZJDaAvAUU" 'test                อย่าลืมแก้กลับ
        '_TOKEN = "K1JtRwgdZD5oslzpr5dLKgUU" 'AOF
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            session_clear() 'ล้างค่า Session
            RunQuery()
            token()
        End If
    End Sub
    Sub session_clear()
        'Session("CLS") = Nothing
    End Sub

    Sub token()
        Dim token As String = _TOKEN

        'Dim ws As New WS_AUTHENTICATION.Authentication
        'Dim xml As String = ""


        If token = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
            Response.Redirect("http://privus.fda.moph.go.th")
        End If
        'xml = ws.Authen_Login(token)

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
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
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
        _CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        _CLS.TOKEN = _TOKEN
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
        '_CLS.ID_MENU = 1200

        Dim bao As New BAO.information
        _CLS = bao.load_lcnsid_customer(_CLS)
        _CLS = bao.load_name(_CLS)


        Dim bao_a As New BAO.ClsDBSqlcommand
        Dim i As Integer = 0
        Try
            i = bao_a.Count_Permission_Menu(clsxml.Get_Value_XML("System_ID"), clsxml.Get_Value_XML("Groups"), "8734002", clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE"))
        Catch ex As Exception

        End Try

        If i > 0 Then
            _CLS.ID_MENU = 8734002
            'Session("CLS") = _CLS
        End If

        Session("CLS") = _CLS
        Dim description As String = ""

        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then
            'Response.Redirect("../LCN/FRM_LCN_DRUG.aspx")
            'Response.Redirect("../LOCATION/FRM_LCN_LCT.aspx")
            

            If _CLS.SYSTEM_ID = "8738" Or _CLS.SYSTEM_ID = "8734" Then
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('" & _CLS.SYSTEM_ID & "');", True)
                Response.Redirect("../MAIN/FRM_HERB_PRODUCT_MAIN.aspx")
            Else
                _CLS.ID_MENU = 1200
                Session("CLS") = _CLS
                Response.Redirect("../MAIN/FRM_MAIN_PAGE_PRODUCT.aspx")
            End If

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