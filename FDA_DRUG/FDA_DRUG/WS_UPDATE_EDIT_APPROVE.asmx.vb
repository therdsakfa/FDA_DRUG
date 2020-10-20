Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_UPDATE_EDIT_APPROVE
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Sub Update_STATUS_EDIT(ByVal TR_ID As Integer, ByVal appdate As Date)
        Dim Result As String = ""
        Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST

        dao_edt.GetDatabyTRID(TR_ID)
        dao_edt.fields.STATUS_ID = 8
        dao_edt.fields.cnccd = 1
        Try

        Catch ex As Exception

        End Try
        dao_edt.fields.cncdate = appdate
        dao_edt.update()
        'Dim dao_log As New DAO_DRUG.TB_LOG_STATUS
        'dao_log.fields.FK_IDA

    End Sub

End Class