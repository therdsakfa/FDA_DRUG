Public Class WebForm4
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _TOKEN As String
    Private Sub RunQuery()
        _TOKEN = Request("Token").ToString()
        '_TOKEN = "A8yMvvmtdarFYll3ZxjaVQUU" 'test
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            RunQuery()
            token()


        End If
    End Sub

    Protected Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click

        Response.Redirect("FRM_PHARMACIST_MAIN.aspx?CITIZEN_ID=" & txt_CITIZEN_ID.Text)
        Dim bao As New BAO.information

    End Sub
    Sub token()

        Dim token As String = _TOKEN

        Dim ws As New WS_AUTHENTICATION.Authentication
        Dim xml As String = ""


        If token = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Found Token');window.location.href = 'http://privus.fda.moph.go.th';", True)
            Response.Redirect("http://privus.fda.moph.go.th")
        End If
        xml = ws.Authen_Login(token)
        'Dim cls_xml As New Cls_XML
        'cls_xml.ReadData(xml)

        Dim clsxml As New Cls_XML
        clsxml.ReadData(xml)
        _CLS.CITIZEN_ID = clsxml.Get_Value_XML("Citizen_ID")
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE") 'clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE") '"3101300593826"'test
        _CLS.TOKEN = _TOKEN
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")


        Dim bao As New BAO.information
        ' _CLS = bao.load_lcnsid_customer(_CLS)
        _CLS = bao.load_name(_CLS)


        Session("CLS_PHR") = _CLS

        '   ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")

        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then
            Response.Redirect("FRM_PHARMACIST_MAIN.aspx")
        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If

    End Sub

End Class