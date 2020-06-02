Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_GET_REGIST
    Inherits System.Web.Services.WebService
    ''' <summary>
    ''' ข้อมูลทะเบียน
    ''' </summary>
    ''' <param name="rcvno"></param>
    ''' <param name="tr_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_REGIST_BY_TR_ID_AND_RCVNO(ByVal rcvno As String, ByVal tr_id As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_GET_WS_DRRGT_STATUS_BY_TR_ID_AND_RCVNO(tr_id, rcvno)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function
    ''' <summary>
    ''' ข้อมูลบัญชีรายการยา
    ''' </summary>
    ''' <param name="tr_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_DATA_REGISTRATION_BY_DRNO(ByVal tr_id As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_DRUG_REGISTRATION_DATA_BY_TR_ID(tr_id)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function
    ''' <summary>
    ''' ดึงข้อมูลทะเบียนภายใต้บัญชีรายการยา
    ''' </summary>
    ''' <param name="tr_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_DATA_DRRGT_BY_TR_ID_REGIS(ByVal tr_id As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_GET_DRRGT_BY_TR_ID_REGIS(tr_id)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function

    ''' <summary>
    ''' ดึงข้อมูลทะเบียนภายใต้บัญชีรายการยา
    ''' </summary>
    ''' <param name="Regis_no"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_DATA_DRRGT_BY_REGIS_NO(ByVal Regis_no As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_GET_DRRGT_BY_REGIS_NO(Regis_no)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function
    '
    ''' <summary>
    ''' ข้อมูลบัญชีรายการยา
    ''' </summary>
    ''' <param name="Regis_no"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_DATA_REGISTRATION_DATA_BY_REGIS_NO(ByVal Regis_no As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO(Regis_no)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function
    ''' <summary>
    ''' ข้อมูลบัญชีรายการยา
    ''' </summary>
    ''' <param name="Regis_no">DL-YY-NNNNN</param>
    ''' <param name="identify"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_DATA_REGISTRATION_DATA_BY_REGIS_NO_AND_CITIZEN_AUTH(ByVal Regis_no As String, ByVal identify As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO_AND_CITIZEN_AUTH(Regis_no, identify)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function
    '
    ''' <summary>
    ''' ข้อมูลการขอขึ้นทะเบียนยาโดยผูกกับบัญชีรายการยารายการเอาแต่ที่ชำระเงินแล้ว
    ''' </summary>
    ''' <param name="Regis_no"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_DATA_DRRGT_BY_REGIS_NO_AND_PAY_ALREADY(ByVal Regis_no As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_GET_DRRGT_BY_REGIS_NO_AND_PAY_ALREADY(Regis_no)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function

    ''' <summary>
    ''' ข้อมูลการขอขึ้นทะเบียนยาโดยผูกกับบัญชีรายการยารายการเอาแต่ที่ชำระเงินแล้ว
    ''' </summary>
    ''' <param name="Regis_no"></param>
    ''' <param name="tr_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function WS_GET_DATA_DRRGT_BY_REGIS_NO_AND_TR_ID_PAY_ALREADY(ByVal Regis_no As String, ByVal tr_id As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_GET_DRRGT_BY_REGIS_NO_AND_TR_ID_PAY_ALREADY(Regis_no, tr_id)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function
    <WebMethod()> _
    Public Function WS_GET_DATA_DRRGT_EDIT_BY_REGIS_NO_AND_TR_ID(ByVal Regis_no As String, ByVal tr_id As String) As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_GET_DRRGT_EDIT_BY_REGIS_NO_AND_TR_ID(Regis_no, tr_id)
        Catch ex As Exception

        End Try
        ds.Tables.Add(dt)
        Return ds
    End Function

    <WebMethod()> _
    Public Function WS_GET_ALL_DRRGT_EDIT_REQUEST() As String
        Dim aa As String = ""
        Dim bao As New BAO_SHOW
        Try
            aa = bao.SP_GET_ALL_DRRGT_EDIT_REQUEST()
        Catch ex As Exception

        End Try

        Return aa
    End Function
    '
    Public Function WS_GET_DRRQT_ALL_ACCEPT() As String
        Dim aa As String = ""
        Dim bao As New BAO_SHOW
        Try
            aa = bao.SP_GET_DRRQT_ALL_ACCEPT_XML()
        Catch ex As Exception

        End Try

        Return aa
    End Function
End Class