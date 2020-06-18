Imports Telerik.Web.UI

Public Class FRM_ETRACKING_STATUS_HEAD_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_head_status()
            UC_INFORMATION_HEAD1.set_label()
        End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        '_date
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As String = item("IDA").Text
            Dim HEAD_STATUS_ID As String = item("HEAD_STATUS_ID").Text
            If e.CommandName = "_date" Then
                
                'Dim rgttpcd As String = item("rgttpcd").Text
                'Dim lcnsid As String = item("lcnsid").Text
                Dim url2 As String = "../NEW/FRM_HEAD_ETRACKING_DATE_POPUP.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & IDA & "&drgtpcd=" & Request.QueryString("drgtpcd")

                Response.Redirect(url2)
            ElseIf e.CommandName = "sel" Then
                'Dim IDA As String = item("IDA").Text
                Dim url2 As String = "../FRM_DRRGT_STATUS_POPUPV2.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & IDA & "&head=" & HEAD_STATUS_ID & "&drgtpcd=" & Request.QueryString("drgtpcd")

                Response.Redirect(url2)
            End If

        End If
        '
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim head_id As String = ""

            Try
                head_id = item("HEAD_STATUS_ID").Text
            Catch ex As Exception

            End Try
            Dim btn_expert As LinkButton = DirectCast(item("btn_expert").Controls(0), LinkButton)
            btn_expert.Style.Add("display", "none")
            If head_id = 4 Then
                btn_expert.Style.Add("display", "block")
            End If
            Dim url As String = "../FRM_EXPERT_ASSIGN_V3.aspx?ida=" & ida & "&rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&drgtpcd=" & Request.QueryString("drgtpcd")
            btn_expert.PostBackUrl = url

            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('FRM_EXPERT_ASSIGN_V2.aspx?ida=" & ida & "&rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "'); ", True)
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_GET_E_TRACKING_HEAD_CURRENT_STATUS_V2(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), 0, Request.QueryString("drgtpcd"))

        RadGrid1.DataSource = dt
    End Sub
    Sub bind_head_status()
        Dim dao As New DAO_DRUG.TB_MAS_HEAD_STATUS_E_TRACKING
        dao.Get_non_Extra()
        ddl_head_status.DataSource = dao.datas
        ddl_head_status.DataTextField = "FDA_STATUS"
        ddl_head_status.DataValueField = "STATUS_ROW"
        ddl_head_status.DataBind()
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_E_TRACKING_HEAD_CURRENT_STATUS
        dao.fields.HEAD_STATUS_ID = ddl_head_status.SelectedValue
        dao.fields.PRODUCT_TYPE = Request.QueryString("b_type")
        dao.fields.SUB_PRODUCT_TYPE = Request.QueryString("s_type")
        dao.fields.IS_EXTRA_STAGE = 0
        dao.fields.rcvno = Request.QueryString("rcvno")
        dao.fields.rgttpcd = Request.QueryString("ntype")
        dao.fields.STATUS_INDEX = ddl_head_status.SelectedValue
        dao.fields.drgtpcd = Request.QueryString("drgtpcd")
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        RadGrid1.Rebind()

    End Sub
End Class