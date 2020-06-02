Imports FDA_DRUG

Public Class WebForm21
    Inherits System.Web.UI.Page
    Dim clsDBSqlCommand As New BAO.ClsDBSqlcommand
    Dim clsDBSyslcnsid As New DAO_CPN.clsDBsyslcnsid
    Dim clsDBSyslcnsnm As New DAO_CPN.clsDBsyslcnsnm

    Private _CLS As New CLS_SESSION
    Private _TOKEN As String

    Public Property CLS As CLS_SESSION
        Get
            Return _CLS
        End Get
        Set(value As CLS_SESSION)
            _CLS = value
        End Set
    End Property

    Private Sub RunQuery()
        _TOKEN = Request("Token").ToString()
        ' _TOKEN = "AAhAsMytGugdCZVDqrjyRQUU" 'test
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'session_clear() 'ล้างค่า Session
            RunQuery()
            token()

        End If
    End Sub
    Sub token()
        Dim token As String = _TOKEN
        Dim urls As String = ""
        Try
            urls = Request.UrlReferrer.AbsoluteUri 'ตรวจสอบว่าเป็นการส่งมาจาก privus หรือไม่
            If urls.Contains("privus.fda.moph.go.th") Then
            Else 'กรณีต้นทางไม่ใช่มาจาก privus ให้ย้อนกลับไปที่ privus
                Response.Redirect("https://privus.fda.moph.go.th")
            End If
        Catch ex As Exception 'กรณีตรวจสอบไม่เจอ url ต้นทางให้ย้อนกลับไปที่ privus
            Response.Redirect("https://privus.fda.moph.go.th")
        End Try

        ' Dim ws As New WS_AUTHENTICATION.Authentication
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
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                    End If
                End If
            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    xml = ws_104.Authen_Login(_TOKEN)
                    If xml = "" Then
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                    End If
                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try




        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)
        CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        CLS.TOKEN = _TOKEN
        CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
        CLS.ID_MENU = 3020

        Dim bao As New BAO.information
        CLS = bao.load_lcnsid_customer(CLS)
        CLS = bao.load_name(CLS)


        Session("CLS") = CLS


        Dim description As String = ""
        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then
            'Response.Redirect("../LCN/FRM_LCN_DRUG.aspx")
            'Response.Redirect("../LOCATION/FRM_LCN_LCT.aspx")
            Response.Redirect("../MAIN/MAIN_PRODUCTS.aspx")
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