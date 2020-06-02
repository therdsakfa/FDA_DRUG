Public Class E_TRACKING_HOME
    Inherits System.Web.UI.Page
    Dim clsDBSqlCommand As New BAO.ClsDBSqlcommand
    Dim clsDBSyslcnsid As New DAO_CPN.clsDBsyslcnsid
    Dim clsDBSyslcnsnm As New DAO_CPN.clsDBsyslcnsnm

    Private _CLS As New CLS_SESSION
    Private _TOKEN As String
    Private Sub RunQuery()
        _TOKEN = Request("Token").ToString()
        '_TOKEN = "s8HtwrpCOTPzmvZu/eVvJgUU"
        '_TOKEN = "5ZQ1hqUUJImVwwfrHf/b4QUU" 'test
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            session_clear() 'ล้างค่า Session
            RunQuery()
            token()
            ' token()
            '66 จนท
            '67 ผปก
            'If Session("System_ID") = "66" Then
            '  load_home()
            'End If
            'load_home()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("FRM_E_TRACKING_MAIN.aspx?Per=" & Txt_taxno.Text)
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
        _CLS.CITIZEN_ID_AUTHORIZE = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE") '"3101300593826"'test
        _CLS.TOKEN = _TOKEN
        _CLS.GROUPS = clsxml.Get_Value_XML("Groups")
        _CLS.SYSTEM_ID = clsxml.Get_Value_XML("System_ID")
        _CLS.PVCODE = clsxml.Get_Value_XML("pvcode")
        Dim GROUPS As Integer = 0
        Try
            GROUPS = clsxml.Get_Value_XML("Groups")
        Catch ex As Exception

        End Try

        Dim bao As New BAO.information
        ' _CLS = bao.load_lcnsid_customer(_CLS)
        _CLS = bao.load_name(_CLS)


        Session("CLS") = _CLS

        '   ws.Authen_Login_MENU(token, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, "70001")

        Dim code As String = clsxml.Get_Value_XML("CODE")
        If code = "900" Then
            If GROUPS <> "21020" Then
                Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_GROUP
                dao.GetDataby_ID_GROUP(GROUPS)
                Try
                    If dao.fields.TYPE_PERSON = 1 Then
                        Response.Redirect("../E_TRACKING/NEW/FRM_E_TRACKING_GROUP_HEAD.aspx?g=" & dao.fields.GROUP_WORK)
                    ElseIf dao.fields.TYPE_PERSON = 2 Then
                        Response.Redirect("../E_TRACKING/NEW/FRM_E_TRACKING_PERSON_GRAPH2.aspx?gid=" & dao.fields.GROUP_WORK & "&ctzid=" & clsxml.Get_Value_XML("Citizen_ID") & "&p=1")
                    End If
                Catch ex As Exception

                End Try
            Else
                Response.Redirect("../E_TRACKING/NEW/FRM_E_TRACKING_PANEL_NEW.aspx")
            End If

            'Response.Redirect("../E_TRACKING/NEW/FRM_E_TRACKING_PANEL_NEW.aspx?Per=" & clsxml.Get_Value_XML("Citizen_ID"))
        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If

    End Sub
End Class