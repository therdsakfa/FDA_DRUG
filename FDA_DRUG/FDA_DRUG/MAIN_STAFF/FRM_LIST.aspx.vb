Public Class WebForm33
    Inherits System.Web.UI.Page
    Private _template As String
    'Private _ID As String
    'Private _System_ID As String
    'Private _pvcode As String
    Private _CLS As New CLS_SESSION
    Private Sub RunQuery()
        _template = Request("template").ToString()
        _CLS = Session("CLS")
    End Sub
   
    'Private Sub RunSession()
    '    Try
    '        _System_ID = Session("System_ID").ToString()
    '        _pvcode = Session("pvcode").ToString()
    '    Catch ex As Exception
    '        Response.Redirect("http://privus.fda.moph.go.th/")
    '    End Try
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            load_GV()
        End If
    End Sub
    Sub load_GV()
        Dim bao As New BAO.ClsDBSqlCommand
        If _template = "1" Then
            bao.GetData_dalcn_by_pvncd(Integer.Parse(_CLS.PVCODE))
        ElseIf _template = "2" Then
            bao.GetData_dalcn_by_pvncd(Integer.Parse(_CLS.PVCODE))
        ElseIf _template = "3" Then
            bao.GetData_dalcn_by_pvncd(Integer.Parse(_CLS.PVCODE))
        ElseIf _template = "4" Then
            bao.GetData_dalcn_by_pvncd(Integer.Parse(_CLS.PVCODE))
        End If
        gv.DataSource = bao.dt
        gv.DataBind()


    End Sub
End Class