Public Class FRM_PRODUCT_ID_CHECK_TOKEN
    Inherits System.Web.UI.Page
    Private system_name As String = ""
    Private staff As String = ""
    Private identify As String = ""
    Private Sub get_querystring()

        Try
            system_name = Request.QueryString("system")
        Catch ex As Exception

        End Try

        Try
            staff = Request.QueryString("staff")
        Catch ex As Exception

        End Try

        Try
            identify = Request.QueryString("identify")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim token As String = Request.QueryString("TOKEN") 'ใช้จริง

        'get_querystring()

        'Dim token As String = _TOKEN
        'Dim token As String = "fIJU7TSK2yk2jMCIaykGVgUU"
        Dim ws As New WS_AUTHENTICATION.Authentication
        Dim xml As String = ""

        If token = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
            Response.Redirect("http://privus.fda.moph.go.th")
        End If
        xml = ws.Authen_Login(token)
        Dim CITIEZEN_ID_AUTHORIZE As String = ""
        Dim citizen_id As String = ""
        Dim system_id As String = ""
        Dim group As String = ""
        Dim pvcode As String = ""
        Dim menu As String = "53"
        'Dim menu As String = "999"

        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)

        CITIEZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        citizen_id = clsxml.Get_Value_XML("Citizen_ID")
        system_id = clsxml.Get_Value_XML("System_ID")
        group = clsxml.Get_Value_XML("Groups")
        pvcode = clsxml.Get_Value_XML("pvcode")
        'menu = clsxml.Get_Value_XML("Menu")

        Session("CITIEZEN_ID") = citizen_id
        Session("CITIEZEN_ID_AUTHORIZE") = CITIEZEN_ID_AUTHORIZE
        Session("TOKEN") = token
        Session("Groups") = group
        Session("System_ID") = system_id
        Session("pvcode") = pvcode
        Dim code As String = clsxml.Get_Value_XML("CODE")
        Dim description As String = ""


        If code = "900" Or code = "901" Then
            Dim CITIZEN_AUTHORIZE_lcnsid As String = ""
            Dim get_data As New CLS_COMMOND.CITIZEN

            Dim cls As New CLS_SESSION

            If identify = "" Then
                CITIZEN_AUTHORIZE_lcnsid = get_data.get_lcnsid(CITIEZEN_ID_AUTHORIZE)
                cls.CITIZEN_ID_AUTHORIZE = CITIEZEN_ID_AUTHORIZE
            Else
                CITIZEN_AUTHORIZE_lcnsid = get_data.get_lcnsid(identify)
                cls.CITIZEN_ID_AUTHORIZE = identify
            End If

            cls.CITIZEN_ID = citizen_id

            cls.LCNSID = CITIZEN_AUTHORIZE_lcnsid
            cls.TOKEN = token
            cls.GROUPS = group
            cls.SYSTEM_ID = system_id
            cls.PVCODE = pvcode
            Session("CLS") = cls
            'Response.Redirect("../DRUG_PRODUCT_ID/FRM_DRUG_PRODUCT_ID_MAIN2.aspx")
            Response.Redirect("../DRUG_PRODUCT_ID/POPUP_SELECT_LISENSE.aspx")
        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('!เกิดข้อผิดพลาด!\nชื่อผู้ใช้นี้ ไม่มีสิทธิใช้งาน');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "102" Then
            description = clsxml.Get_Value_XML("Description")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('!เกิดข้อผิดพลาด!\nชื่อผู้ใช้นี้ มีการเข้าใช้ระบบนี้อยู่แล้ว\n" & description & "');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If

    End Sub

End Class