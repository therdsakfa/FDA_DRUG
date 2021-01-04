Public Class FRM_STAFF_SEARCH_NYM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION         'public class
    Private _process As String
    Private _type As String
    Private _pvncd As Integer

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        '_process = Request("process").ToString()
        Try
            _type = Request("type").ToString()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            load_ddl()
            'load_GV_lcnno()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Private Sub load_ddl()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        dt = bao.SP_NYMSTAFF_ALLPROCESS

        ddl_search.DataSource = dt 'dao.datas
        ddl_search.DataTextField = "PROCESS_NAME"
        ddl_search.DataValueField = "PROCESS_ID"
        ddl_search.DataBind()
        Dim item As New ListItem
        item.Text = "กรุณาเลือกประเภท"
        item.Value = "0"
        ddl_search.Items.Insert(0, item)
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim process_id As String
        Dim url As String = ""
        Dim NYM As String = ""
        process_id = ddl_search.SelectedValue
        If ddl_search.SelectedValue <> "0" Then
            If process_id = "1026" Or process_id = "1027" Or process_id = "1028" Or process_id = "1029" Or process_id = "1030" Or process_id = "1031" Then
                Select Case process_id
                    Case "1027"
                        NYM = "2"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM2.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM

                    Case "1028"
                        NYM = "3"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM3.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM

                    Case "1029"
                        NYM = "4"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM4.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM

                    Case "1030"
                        NYM = "5"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM5.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM
                    Case "1031"
                        NYM = "7"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM4_2.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM
                End Select
                Response.Redirect(url)
            End If
        Else
            alert("กรุณาเลือกเลขบัญชีรายการยา")
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
End Class