Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_ATC_DRUG
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GET_DATA_ATC() As DataTable
        Dim dt As New DataTable
        Dim bao_atc As New BAO.ClsDBSqlcommand
        dt = bao_atc.SP_ATC_DRUG_ROOT5_ALL()
        Return dt
    End Function
    '

    <WebMethod()>
    Public Function GET_DATA_EDIT_HISTORY(ByVal newcode As String) As DataTable
        Dim dt As New DataTable
        Dim bao_atc As New BAO_SHOW
        dt = bao_atc.SP_DRRGT_EDIT_HISTORY_BY_NEWCODE(newcode)
        Return dt
    End Function
End Class