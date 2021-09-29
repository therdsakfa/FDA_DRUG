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

    <WebMethod()>
    Public Function SP_GET_NAME_LCN_Phesaj(ByVal citizen_id As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_GET_NAME_LCN_Phesaj(citizen_id)
        dt.TableName = "SP_GET_NAME_LCN_Phesaj"
        Return dt
    End Function

    <WebMethod()>
    Public Function SP_GET_NAME_LCN_Phesaj_XML_STRING(ByVal citizen_id As String) As String
        Dim str_xml As String = ""
        Try
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim bao As New BAO.ClsDBSqlcommand
            dt = bao.SP_GET_NAME_LCN_Phesaj(citizen_id)
            Dim dtCopy As New DataTable
            dtCopy = dt.Copy()
            dtCopy.TableName = "SP_GET_NAME_LCN_Phesaj"
            ds.Tables.Add(dtCopy)
            str_xml = ds.GetXml
        Catch ex As Exception

        End Try
        Return str_xml
    End Function
End Class