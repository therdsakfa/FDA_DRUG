Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class XML_DRUG_RGT
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function XML_SEARCH_PRODUCT_GROUP(ByVal identify As String) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.XML_SEARCH_PRODUCT_GROUP(identify)

        Return dt
    End Function

End Class