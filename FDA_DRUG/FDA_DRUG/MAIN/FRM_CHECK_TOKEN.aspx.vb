
Public Class FRM_CHECK_TOKEN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

    Private Sub RunSession()
        _CLS = Session("CLS")

    End Sub

    'Sub load_name()
    '    Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
    '    Dim dao_sysnmperson As New DAO_CPN.clsDBsysnmperson

    '    dao_syslcnsid.GetDataby_taxno(_CLS.CITIZEN_ID)
    '    dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)
    '    _CLS.LCNSID = dao_syslcnsid.fields.lcnsid

    '    If String.IsNullOrEmpty(dao_sysnmperson.fields.thalnm) = True Or dao_sysnmperson.fields.thalnm = Nothing Then
    '        _CLS.THANM = dao_sysnmperson.fields.thanm
    '    Else
    '        _CLS.THANM = dao_sysnmperson.fields.thanm + " " + dao_sysnmperson.fields.thalnm
    '    End If
    '    Session("CLS") = _CLS
    'End Sub
    'Sub load_lcnsid_customer()
    '    Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE

    '    Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
    '    dao_syslcnsid.GetDataby_taxno(CITIZEN_ID_AUTHORIZE)

    '    Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
    '    dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

    '    _CLS.LCNSID_CUSTOMER = dao_syslcnsid.fields.lcnsid

    '    If String.IsNullOrEmpty(dao_sysnmperson.fields.thalnm) = True Or dao_sysnmperson.fields.thalnm = Nothing Then
    '        '    Session("thanm_customer") = dao_sysnmperson.fields.thanm
    '        _CLS.THANM_CUSTOMER = dao_sysnmperson.fields.thanm
    '    Else
    '        '     Session("thanm_customer") = dao_sysnmperson.fields.thanm + " " + dao_sysnmperson.fields.thalnm
    '        _CLS.THANM_CUSTOMER = dao_sysnmperson.fields.thanm + " " + dao_sysnmperson.fields.thalnm
    '    End If
    '    Session("CLS") = _CLS
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        'load_name()
        'load_lcnsid_customer()
        Response.Redirect("../LCN/FRM_LCN_DRUG.aspx")

    End Sub
End Class