Imports Telerik.Web.UI

Public Class FRM_CER_STAFF_SEARCH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    'Sub runQuery()
    '    _lct_ida = Request.QueryString("lct_ida")
    '    _lcn_ida = Request.QueryString("lcn_ida")
    '    _process = Request.QueryString("process")
    'End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim str_ID As String = ""
            str_ID = item("IDA").Text
            Dim dao As New DAO_DRUG.TB_CER
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA2(str_ID)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tr.GetDataby_TR_ID_Process(dao.fields.TR_ID, dao.fields.PROCESS_ID)

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../DI/POPUP_DI_CONFIRM.aspx?IDA=" & str_ID & "&FK_IDA=" & str_ID & "&TR_ID=" & tr_id & "&ProcessID=" & dao.fields.PROCESS_ID & "&s=1');", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_COMFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & " &process=" & dao_tr.fields.PROCESS_ID & "');", True)
            ElseIf e.CommandName = "remark" Then
                dao.GetDataby_IDA2(str_ID)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_CER_SHOW_REMARK.aspx?IDA=" & str_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_remark As LinkButton = DirectCast(item("btn_remark").Controls(0), LinkButton)
            btn_remark.Style.Add("display", "none")
            Dim dao As New DAO_DRUG.TB_CER
            Dim str_remark As String = ""
            Try
                dao.GetDataby_IDA2(IDA)
                str_remark = dao.fields.REMARK
                If str_remark <> "" Then
                    btn_remark.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try

            'Try
            '    If dao.fields.STATUS_ID = 78 Then
            '        btn_remark.Text = "เหตุผลที่ยกเลิกคำขอ"
            '    End If
            'Catch ex As Exception

            'End Try
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_CER_SEARCH()

        RadGrid1.DataSource = dt
    End Sub
    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Dim strMsg As String = ""
        strMsg = "([CER_FORMAT] LIKE '%" & txt_CER_NUMBER.Text & "%')" & _
            " and ([FOREIGN_LOCATION_NAME] LIKE '%" & txt_FOREIGN_LOCATION_NAME.Text & "%')" & _
        " and ([TR_ID] LIKE '%" & txt_TR_ID.Text & "%')"

        RadGrid1.EnableLinqExpressions = False
        RadGrid1.MasterTableView.FilterExpression = strMsg
        RadGrid1.MasterTableView.Rebind()
    End Sub
End Class