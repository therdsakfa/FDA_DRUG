Public Class FRM_E_TRACKING_PANEL
    Inherits System.Web.UI.Page
    Dim clsDBSqlCommand As New BAO.ClsDBSqlcommand
    Dim clsDBSyslcnsid As New DAO_CPN.clsDBsyslcnsid
    Dim clsDBSyslcnsnm As New DAO_CPN.clsDBsyslcnsnm

    Private _CLS As New CLS_SESSION
    Private _TOKEN As String
    Private _CITIZEN As String
    Private Sub RunQuery()
        '_TOKEN = Request("Token").ToString()
        '_TOKEN = "rkVUThrwT1scaO07qfVFgQUU"
        '_TOKEN = "CVYKxMjTprj/oqwz4kfMrgUU" 'test
        _CITIZEN = Request.QueryString("Per")
    End Sub
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        RunSession()
        If Not IsPostBack Then
            session_clear() 'ล้างค่า Session

            'token()

            ' token()
            '66 จนท
            '67 ผปก
            'If Session("System_ID") = "66" Then
            '  load_home()
            'End If
            'load_home()
        End If
    End Sub

    Private Sub btn_e_tracking_Click(sender As Object, e As EventArgs) Handles btn_e_tracking.Click
        'Response.Redirect("FRM_E_TRACKING_MAIN.aspx?Per=1729900157224")
        RunQuery()
        Response.Redirect("FRM_E_TRACKING_MAIN.aspx?Per=" & _CITIZEN)
    End Sub
    Sub session_clear()
        'Session("CLS") = Nothing
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
        _CLS.CITIZEN_ID_AUTHORIZE = "3101300593826" 'clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")'test
        _CLS.TOKEN = _TOKEN
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")

        _CITIZEN = clsxml.Get_Value_XML("Citizen_ID")
        Dim bao As New BAO.information
        _CLS = bao.load_lcnsid_customer(_CLS)
        _CLS = bao.load_name(_CLS)


        Session("CLS") = _CLS

        '   ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")

        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then
            Response.Redirect("../E_TRACKING/FRM_E_TRACKING_MAIN.aspx?Per=" & clsxml.Get_Value_XML("Citizen_ID"))
        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If

    End Sub

    'Private Sub btn_e_citizen_Click(sender As Object, e As EventArgs) Handles btn_e_citizen.Click
    '    Response.Redirect("FRM_E_TRACKING_STAFF_ASIGN.aspx")
    'End Sub

    'Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
    '    Response.Redirect("FRM_E_TRACKING_WORK.aspx")
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Response.Redirect("FRM_E_TRACKING_WORK_OVERALL.aspx")
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Response.Redirect("FRM_E_TRACKING_WORK_TOP5.aspx")
    'End Sub

    'Private Sub btn_report_all_Click(sender As Object, e As EventArgs) Handles btn_report_all.Click
    '    Response.Redirect("FRM_E_TRACKING_GROUP_GRAPH.aspx")
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_E_TRACKING_WORK_TOP5.aspx")
    End Sub

    Private Sub btn_report_chemi_Click(sender As Object, e As EventArgs) Handles btn_report_chemi.Click
        Response.Redirect("FRM_E_TRACKING_GROUP_GRAPH.aspx?g=1")
    End Sub

    Private Sub btn_report_live_Click(sender As Object, e As EventArgs) Handles btn_report_live.Click
        Response.Redirect("FRM_E_TRACKING_GROUP_GRAPH.aspx?g=2")
    End Sub

    Private Sub btn_report_Old_Click(sender As Object, e As EventArgs) Handles btn_report_Old.Click
        Response.Redirect("FRM_E_TRACKING_GROUP_GRAPH.aspx?g=3")

    End Sub

    Private Sub btn_report_main_drug_Click(sender As Object, e As EventArgs) Handles btn_report_main_drug.Click
        Response.Redirect("FRM_E_TRACKING_GROUP_GRAPH.aspx?g=6")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("FRM_E_TRACKING_WORK_ALL_PERSON.aspx")
    End Sub
End Class