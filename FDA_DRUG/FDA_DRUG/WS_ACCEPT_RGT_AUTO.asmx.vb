Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_ACCEPT_RGT_AUTO
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ACCEPT_AND_RUNNING_RGTNO(ByVal FK_DRRQT As Integer) As String
        Dim result As String = ""
        Dim RGTNO As Integer


        Dim dao As New DAO_DRUG.ClsDBdrrqt
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD

        dao.GetDataby_IDA(FK_DRRQT)
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim rgttpcd As String = ""
        If dao.fields.lcntpcd.Contains("ผย") Or dao.fields.lcntpcd.Contains("ผส") Then
            rgttpcd = "G"
        ElseIf dao.fields.lcntpcd.Contains("นย") Or dao.fields.lcntpcd.Contains("นส") Then
            rgttpcd = "K"
        End If
        RGTNO = GEN_RGTNO(rgttpcd)

        Dim bools As Boolean
        bools = CHK_MAX_NO_INSERT(RGTNO)

        If bools = True Then
            If dao.fields.STATUS_ID <> 8 Then
                Dim rcvno As Integer = 0
                RGTNO = GEN_RGTNO(rgttpcd)
                rcvno = GEN_RCVNO(rgttpcd)
                dao.fields.rcvno = rcvno
                dao.fields.rgttpcd = rgttpcd
                dao.fields.rgtno = RGTNO
                dao.fields.drgtpcd = "2"
                dao.fields.rgttpcd = rgttpcd
                dao.fields.STATUS_ID = 8
                dao.fields.rcvdate = CDate(Date.Now)
                dao.fields.appdate = CDate(Date.Now)
                dao.update()
                'insert_tabean_auto(FK_DRRQT)
                Dim bao_insert As New BAO.ClsDBSqlcommand
                bao_insert.insert_tabean_sub(FK_DRRQT)
            End If
           
        Else
            If dao.fields.STATUS_ID <> 8 Then
                RGTNO = GEN_RGTNO(rgttpcd)
                Dim rcvno As Integer = 0
                rcvno = GEN_RCVNO(rgttpcd)
                dao.fields.rcvno = rcvno
                dao.fields.rgtno = RGTNO
                dao.fields.rgttpcd = rgttpcd
                dao.fields.drgtpcd = "2"
                dao.fields.STATUS_ID = 8
                dao.fields.rcvdate = CDate(Date.Now)
                dao.fields.appdate = CDate(Date.Now)
                dao.update()
                ' insert_tabean_auto(FK_DRRQT)
                Dim bao_insert As New BAO.ClsDBSqlcommand
                bao_insert.insert_tabean_sub(FK_DRRQT)
            End If
        End If
        Return result
    End Function
    Private Function GEN_RGTNO(ByVal rgttpcd As String) As Integer
        Dim max_no As Integer = 0

        Dim dt As New DataTable
        Dim bao_max As New BAO.ClsDBSqlcommand()
        Dim _YEAR As String
        _YEAR = con_year(Date.Now.Year)
        dt = bao_max.SP_GET_MAX_RGTNO_BY_RGTTPCD(rgttpcd, _YEAR.Substring(2, 2))
        Try
            max_no = dt(0)("MAX_ID")
            max_no += 1
        Catch ex As Exception

        End Try

        Dim str_no As String = max_no.ToString()
        str_no = String.Format("{0:50000}", max_no.ToString("50000"))
        str_no = _YEAR.Substring(2, 2) & str_no


        Return str_no
    End Function
    '
    Private Function GEN_RCVNO(ByVal rgttpcd As String) As Integer
        Dim max_no As Integer = 0

        Dim dt As New DataTable
        Dim bao_max As New BAO.ClsDBSqlcommand()
        Dim _YEAR As String
        _YEAR = con_year(Date.Now.Year)
        dt = bao_max.SP_DRRQT_GET_MAX_RCVNO_BY_RGTTPCD_DRGTPCD(rgttpcd, _YEAR.Substring(2, 2), "2")
        Try
            max_no = dt(0)("MAX_ID")
            max_no += 1
        Catch ex As Exception

        End Try

        Dim str_no As String = max_no.ToString()
        str_no = String.Format("{0:50000}", max_no.ToString("50000"))
        str_no = _YEAR.Substring(2, 2) & str_no


        Return str_no
    End Function
    Private Function CHK_MAX_NO_INSERT(ByVal max_no As String) As Boolean
        Dim bool As Boolean = False
        Try
            Dim dao As New DAO_DRUG.TB_genno_temp
            dao.fields.create_date = Date.Now
            dao.fields.GENNO = max_no
            dao.insert()

            bool = True
        Catch ex As Exception
            bool = False
        End Try

        Return bool
    End Function
   
End Class