Imports Telerik.Web.UI

Public Class FRM_DH_SEARCH
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Private _type As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
        _type = Request.QueryString("type")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            runQuery()

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_lcnno()
    End Sub
    Sub load_lcnno()
        'lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim str_ID As String = ""
            str_ID = item("IDA").Text
            Dim dao As New DAO_DRUG.ClsDBdh15rqt
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA(str_ID)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tr.GetDataby_IDA(tr_id)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_COMFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & " &process=" & dao_tr.fields.PROCESS_ID & "');", True)

            ElseIf e.CommandName = "remark" Then
                dao.GetDataby_IDA(str_ID)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_DH_SHOW_REMARK.aspx?IDA=" & str_ID & "');", True)
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
            Dim dao As New DAO_DRUG.ClsDBdh15rqt
            Dim str_remark As String = ""
            Try
                dao.GetDataby_IDA(IDA)
                str_remark = dao.fields.REMARK
                If str_remark <> "" Then
                    btn_remark.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid1.DataSource = bao.SP_STAFF_DH15RQT_V2()
        'GV_data.DataBind()
    End Sub

    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Dim strMsg As String = ""
        If ddl_status.SelectedItem.Text = "ทั้งหมด" Then
            strMsg = "([TR_ID] LIKE '%" & txt_number.Text & "%') " &
            " and ([phm15dgt] LIKE '%" & txt_drm.Text & "%') " &
            " and ([CAS_NAME] LIKE '%" & txt_chem.Text & "%') "
        Else
            strMsg = "([STATUS_NAME] LIKE '%" & ddl_status.SelectedItem.Text & "%')" &
             " and ([TR_ID] LIKE '%" & txt_number.Text & "%') " &
             " and ([phm15dgt] LIKE '%" & txt_drm.Text & "%') " &
             " and ([CAS_NAME] LIKE '%" & txt_chem.Text & "%') "
        End If


        RadGrid1.EnableLinqExpressions = False
        RadGrid1.MasterTableView.FilterExpression = strMsg
        RadGrid1.MasterTableView.Rebind()
    End Sub
End Class