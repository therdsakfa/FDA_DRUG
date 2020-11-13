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
    Public Function Get_Data_License(ByVal DL_IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.DRUG_REGISTRATION_BY_IDA_NORYORMOR(DL_IDA)
        'dt.Columns.Add("lcnno_format")
        'dt.Columns.Add("type_license")

        'Dim lcnno_format As String = ""
        'Dim type_license As String = ""
        'Dim dao_dl As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        'Try
        '    dao_dl.GetDataby_IDA(DL_IDA)
        'Catch ex As Exception

        'End Try

        'Dim lcnno_auto As String = ""
        'Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        'Try
        '    dao_dal.GetDataby_IDA_ID(dao_dl.fields.FK_IDA)
        '    lcnno_auto = dao_dal.fields.lcnno
        'Catch ex As Exception

        'End Try
        'Try
        '    If Len(lcnno_auto) > 0 Then

        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
        '        Else
        '            lcnno_format = dao_dal.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '        End If
        '        'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try
        'Try
        '    If dao_dal.fields.lcntpcd.Contains("บ") Then
        '        type_license = "2"
        '    Else
        '        type_license = "1"
        '    End If
        'Catch ex As Exception

        'End Try
        'Dim dr As DataRow = dt.NewRow()
        'Try
        '    dr("lcnno_format") = lcnno_format

        'Catch ex As Exception

        'End Try
        'Try
        '    dr("type_license") = type_license
        'Catch ex As Exception

        'End Try
        'dt.Rows.Add(dr)

        Return dt
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


    <WebMethod()>
    Public Function Get_Dosage_Form() As DataTable
        Dim dt As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        dt = bao_master_2.SP_dosage_form()
        Return dt
    End Function

    ''' <summary>
    ''' สถานที่เก็บ
    ''' </summary>
    ''' <param name="DL_IDA"></param>
    ''' <returns></returns>
    <WebMethod()>
    Public Function Get_Data_Keep(ByVal DL_IDA As Integer) As DataTable
        Dim dt As New DataTable
        Dim dao_dl As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_dl.GetDataby_IDA(DL_IDA)
        'Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        'Try
        '    dao_dal.GetDataby_IDA(dao_dl.fields.FK_IDA)
        'Catch ex As Exception

        'End Try
        Dim bao_show As New BAO_MASTER
        Try
            dt = bao_show.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao_dl.fields.FK_IDA)
        Catch ex As Exception

        End Try

        Return dt
    End Function

    <WebMethod()>
    Public Function Get_Country() As DataTable
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao.SP_MASTER_sysisocnt()
        Return dt
    End Function

    <WebMethod()>
    Public Function Get_Unit() As DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        'ddl_unit_each.DataSource = dt
        'ddl_unit_each.DataTextField = "unit_name"
        'ddl_unit_each.DataValueField = "sunitcd"

        Return dt
    End Function

    <WebMethod()>
    Public Function Get_Login_Name(ByVal Citizen_id As String) As String

        Dim str_name As String = ""
        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
        dao_syslcnsnm.GetDataby_identify(Citizen_id)
        Dim dao_pre As New DAO_CPN.TB_sysprefix

        If String.IsNullOrEmpty(dao_syslcnsnm.fields.thalnm) = True Or dao_syslcnsnm.fields.thalnm = Nothing Then
            Try
                dao_pre.Getdata_byid(dao_syslcnsnm.fields.prefixcd)
                str_name = dao_pre.fields.thanm & " " & dao_syslcnsnm.fields.thanm
            Catch ex As Exception
                str_name = dao_syslcnsnm.fields.thanm
            End Try


        Else
            Try
                dao_pre.Getdata_byid(dao_syslcnsnm.fields.prefixcd)
                str_name = dao_pre.fields.thanm & " " & dao_syslcnsnm.fields.thanm + " " + dao_syslcnsnm.fields.thalnm
            Catch ex As Exception
                str_name = dao_syslcnsnm.fields.thanm + " " + dao_syslcnsnm.fields.thalnm
            End Try

        End If



        Return str_name
    End Function

    <WebMethod()>
    Public Function Gen_TR_ID(ByVal Prcess_id As String, ByVal CITIZEN_ID As String, ByVal CITIZEN_ID_AUTHORIZE As String) As String
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.CITIZEN_ID = CITIZEN_ID
        bao_tran.CITIZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE
        TR_ID = bao_tran.insert_transection_new(Prcess_id)
        Return TR_ID
    End Function
End Class