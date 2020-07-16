Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_NORYORMOR_DATA
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Get_Data_Location(ByVal DL_IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim dao_dl As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_dl.GetDataby_IDA(DL_IDA)
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        Try
            dao_dal.GetDataby_IDA(dao_dl.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Dim bao_show As New BAO_SHOW
        Try
            dt = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dal.fields.FK_IDA)
        Catch ex As Exception

        End Try

        Return dt
    End Function
    <WebMethod()>
    Public Function Get_Data_License(ByVal DL_IDA As Integer) As String
        Dim lcnno_format As String = ""
        Dim dao_dl As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_dl.GetDataby_IDA(DL_IDA)
        Dim lcnno_auto As String = ""
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        Try
            dao_dal.GetDataby_IDA(dao_dl.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_dal.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Return lcnno_format
    End Function
    <WebMethod()>
    Public Function Get_Pack_Size(ByVal DL_IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA_add(DL_IDA) 'ขนาดบรรจุ
        Return dt
    End Function
    <WebMethod()>
    Public Function Get_Pack_Size_Long_Txt(ByVal DL_IDA As Integer) As String
        Dim str As String = ""
        Dim dao_dl As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_dl.GetDataby_IDA(DL_IDA)
        Try
            str = dao_dl.fields.PACKAGE_DETAIL
        Catch ex As Exception

        End Try
        Return str
    End Function
    <WebMethod()>
    Public Function Get_Drug_per_Unit(ByVal DL_IDA As Integer) As String
        Dim str As String = ""
        Try
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
            dao.GetDataby_FK_IDA(DL_IDA)
            If IsNothing(dao.fields.EACH_TXT) = False Or dao.fields.EACH_TXT <> "" Then
                str = "Each " & dao.fields.EACH_TXT & " Contains;"
            Else
                Dim dao_u As New DAO_DRUG.TB_DRUG_UNIT
                dao_u.GetDataby_sunitcd(dao.fields.sunitcd)
                str = "Each " & dao.fields.EACH_AMOUNT & " " & dao_u.fields.unit_name & " Contains;"
            End If

        Catch ex As Exception

        End Try
        Return str
    End Function

End Class