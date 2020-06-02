Public Class CHECK_TOKEN_E_TRACKING
    Inherits System.Web.UI.Page

    Dim clsDBSqlCommand As New BAO.ClsDBSqlcommand
    Dim clsDBSyslcnsid As New DAO_CPN.clsDBsyslcnsid
    Dim clsDBSyslcnsnm As New DAO_CPN.clsDBsyslcnsnm

    Private _CLS As New CLS_SESSION


    Private _TOKEN As String
    Private _A_NO As String
    Private Sub RunQuery()
        _TOKEN = Request("Token").ToString()
        _A_NO = Request.QueryString("a_no")
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
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        _CLS.TOKEN = token
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")

        Dim bao As New BAO.information
        '_CLS = bao.load_lcnsid_customer(_CLS)
        _CLS = bao.load_name(_CLS)

        Session("CLS") = _CLS


        ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")
        ' Dim cls_xml As New Cls_XML
        Dim code As String = clsxml.Get_Value_XML("CODE")

        'Dim CITIEZEN_ID_AUTHORIZE As String = ""
        Dim description As String = ""

        If code = "900" Then
            Dim dao_a As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            dao_a.GetDataby_R_and_C_V2(_A_NO)
            Dim IDA As Integer = 0
            IDA = dao_a.fields.IDA
            Dim url2 As String = ""
            If dao_a.fields.IDA <> 0 Then
                url2 = "../E_TRACKING/CHANGE_STATUS/NEW/FRM_ETRACKING_STATUS_HEAD_MAIN_RQ_CENTER.aspx?id_r=" & IDA & "&r=1"
            End If
            Response.Redirect(url2)
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