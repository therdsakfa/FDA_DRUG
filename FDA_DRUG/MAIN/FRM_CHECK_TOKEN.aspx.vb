Imports FDA_DRUG.WS_AUTHENTICATION

Public Class FRM_CHECK_TOKEN
    Inherits System.Web.UI.Page

    Private _CITIZEN_ID As String
    Private _CITIEZEN_ID_AUTHORIZE As String

    Private Sub RunSession()

        _CITIZEN_ID = Session("CITIEZEN_ID")
        _CITIEZEN_ID_AUTHORIZE = Session("CITIEZEN_ID_AUTHORIZE")

    End Sub

    Sub load_name()
        Dim WS_CENTER_CITIZ_NO As WS_CENTER.CLC_CITIZ_NO
        Dim WS_CENTER_CLC_CUSTNAME As WS_CENTER.CLC_CUSTNAME
        Dim WS_CENTER As New WS_CENTER.WS_CENTER
        WS_CENTER_CITIZ_NO = WS_CENTER.GET_LCNSID(_CITIZEN_ID)
        WS_CENTER_CLC_CUSTNAME = WS_CENTER.GET_CUSTNAME_BY_LCNSID(WS_CENTER_CITIZ_NO.lcnsid)
        Session("strlcnsid") = WS_CENTER_CITIZ_NO.lcnsid
        Session("strthanm") = WS_CENTER_CLC_CUSTNAME.thanm + " " + WS_CENTER_CLC_CUSTNAME.thalnm
    End Sub
    '139365
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RunSession_TOKEN()
        Dim token As String = Request.QueryString("TOKEN")
        'Dim token As String = _TOKEN
        ' Dim token As String = "bNEvXTxvOEELXIuKqwFCagUU"
        Dim ws As New Authentication
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
        Session("CITIEZEN_ID") = clsxml.Get_Value_XML("Citizen_ID")
        Session("CITIEZEN_ID_AUTHORIZE") = clsxml.Get_Value_XML("CITIEZEN_ID_AUTHORIZE")
        Session("TOKEN") = token
        Session("Groups") = clsxml.Get_Value_XML("Groups")
        Session("System_ID") = clsxml.Get_Value_XML("System_ID")
        ws.Authen_Login_MENU(token, _CITIZEN_ID, Session("System_ID"), Session("Groups"), "70001")
        ' Dim cls_xml As New Cls_XML
        Dim code As String = clsxml.Get_Value_XML("CODE")
        'Dim CITIEZEN_ID_AUTHORIZE As String = ""


        If code = "900" Then


        ElseIf code = "100" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        ElseIf code = "101" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('TOKEN Expire');window.location.href = 'http://privus.fda.moph.go.th';", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('Not Permission');window.location.href = 'http://privus.fda.moph.go.th';", True)
        End If

        RunSession()
        load_name()
        ' load_lcnsnm()

    End Sub
    'Sub load_lcnsnm()
    '    Dim sql As String = " "
    '    sql += " select * from OPENQUERY(LGTFOOD,' "
    '    sql += " select * from  syslcnsnm "
    '    sql += " where lcnsst = 1"
    '    sql += " and lcnsid = " + _CITIEZEN_ID_AUTHORIZE
    '    sql += "  ;')"


    '    Dim dt As New DataTable

    '    Dim clsds As New ClassDataset

    '    dt = clsds.dsQueryselect(sql, "Data Source=164.115.28.103;Initial Catalog=LGT_DRUG;Persist Security Info=True;User ID=fusion;Password=P@ssw0rd").Tables(0)

    '    lbl_lcnsnm.Text = dt.Rows(0)("thanm").ToString()
    'End Sub
End Class