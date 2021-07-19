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

    <WebMethod()>
    Public Function GET_DATA_LCN_EDIT_HISTORY(ByVal newcode As String) As DataTable
        Dim dao_b As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
        Dim IDA_DALCN As Integer = 0
        Try
            dao_b.GetDataby_u1(newcode)
            IDA_DALCN = dao_b.fields.IDA_dalcn
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        Dim bao_atc As New BAO.ClsDBSqlcommand
        Try
            dt = bao_atc.SP_EDIT_HISTORY_REPORT_BY_FK_IDA(IDA_DALCN)
        Catch ex As Exception

        End Try
        dt.TableName = "SP_EDIT_HISTORY_REPORT_BY_FK_IDA"
        Return dt
    End Function
    <WebMethod()>
    Public Function GET_DATA_LCN_EXTENDING(ByVal newcode As String) As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim str_query As String = "select * from dbo.Vw_Extend where Newcode_not = '" & newcode & "' order by extend_year"
        dt = bao.Queryds(str_query)
        dt.TableName = "SP_GET_DATA_LCN_EXTENDING"
        Return dt
    End Function



End Class