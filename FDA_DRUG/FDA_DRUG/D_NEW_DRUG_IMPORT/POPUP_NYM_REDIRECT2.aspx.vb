Public Class POPUP_NYM_REDIRECT2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _type As String
    Private _process As String = ""
    Private _DL As String = ""
    Private _IDA As String = ""
    Private _TR_ID As String = ""
    Sub RunSession()
        Try
            _process = Request.QueryString("process")
        Catch ex As Exception

        End Try
        Try
            _DL = Request.QueryString("DL")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            'เรียก Process ที่เราเรียก

            '_IDA = Request.QueryString("IDA")
            '_TR_ID = Request.QueryString("TR_ID")
            '_lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
        Try
            _type = Request("type").ToString()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Redirect_obj()
    End Sub
    Sub Redirect_obj()
        Dim NYM As String = ""
        Dim url As String = ""
        'If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
        Select Case _process
            Case "1027"
                NYM = "2"
            Case "1028"
                NYM = "3"
            Case "1029"
                NYM = "4"
            Case "1030"
                NYM = "5"
        End Select
        'url = "http://10.111.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & _DL & "&NYM=" & NYM & "&process=" & _process ' & " & NYM2_ida" & _IDA
        'Response.Clear()
        Response.Redirect("http://10.111.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & _DL & "&NYM=" & NYM & "&process=" & _process)
        'Response.End()
        ' Response.Redirect("http://privus.fda.moph.go.th/")
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "window.location.href ='" & url & "';", True)
        'End If
    End Sub
End Class