Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_LCN_EXTEND
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Get_Name_Authorize(ByVal citizen_id As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_GET_IDENTYFY_AND_NAME_BY_CTZNO(citizen_id)
        Return dt
    End Function

    '
    <WebMethod()>
    Public Function Get_Name_Authorize_Phesaj(ByVal citizen_id As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_GET_IDENTYFY_AND_NAME_BY_CTZNO_Phesaj(citizen_id)
        Return dt
    End Function
End Class