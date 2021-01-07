Imports Telerik.Web.UI

Public Class FRM_CHANGE_NAME_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_HL()
    End Sub
    Private Sub load_HL()
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_process)
        Try
            'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then
            '    hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE_DEMO/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
            '    If Request.QueryString("staff") = 1 Then
            '        hl_pay.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            '    End If
            'Else

            If Request.QueryString("staff") = 1 Then
                hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug"
                hl_pay.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            Else
                hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
            End If
            'End If
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../CHANGE_NAME_RQT/FRM_CHANGE_NAME_POPUP.aspx?process=" & _process & "&identify=" & _CLS.CITIZEN_ID_AUTHORIZE & "');", True)
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_GET_CHANGE_NAME_REQUEST_DATA_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)
        RadGrid1.DataSource = dt
    End Sub

    Private Sub RadGrid1_InsertCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.InsertCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "cancel" Then
                Dim dao As New DAO_DRUG.TB_CHANGE_NAME_REQUEST
                dao.GetDataby_IDA(IDA)
                dao.fields.STATUS_ID = 77
                dao.update()
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_cancel As LinkButton = DirectCast(item("btn_cancel").Controls(0), LinkButton)

            Dim dao As New DAO_DRUG.TB_CHANGE_NAME_REQUEST

            Try
                dao.GetDataby_IDA(IDA)
                If dao.fields.STATUS_ID >= 3 Then
                    btn_cancel.Style.Add("display", "block")
                Else
                    btn_cancel.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class