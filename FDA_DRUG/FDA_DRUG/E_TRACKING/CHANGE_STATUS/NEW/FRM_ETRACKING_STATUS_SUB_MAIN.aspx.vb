Imports Telerik.Web.UI

Public Class FRM_ETRACKING_STATUS_SUB_MAIN
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
            If e.CommandName = "_date" Then
                Dim IDA As String = item("IDA").Text
                'Dim ctzid As String = item("ctzid").Text
                'Dim rgttpcd As String = item("rgttpcd").Text
                'Dim lcnsid As String = item("lcnsid").Text
                Dim url2 As String = "../NEW/FRM_HEAD_ETRACKING_DATE_POPUP.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & IDA & "&extra=1" & "&drgtpcd=" & Request.QueryString("drgtpcd")

                Response.Redirect(url2)
            ElseIf e.CommandName = "sel" Then
                Dim IDA As String = item("IDA").Text
                Dim url2 As String = "../FRM_DRRGT_STATUS_POPUPV2.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & IDA & "&head=" & item("HEAD_STATUS_ID").Text & "&extra=1" & "&drgtpcd=" & Request.QueryString("drgtpcd")

                Response.Redirect(url2)
            End If

        End If
        '
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_GET_E_TRACKING_HEAD_CURRENT_STATUS_V2(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), 1, Request.QueryString("drgtpcd"))

        RadGrid1.DataSource = dt
    End Sub
    Sub bind_head_status()
        Dim dao As New DAO_DRUG.TB_MAS_HEAD_STATUS_E_TRACKING
        dao.Get_Extra()
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
        dao.fields.rcvno = Request.QueryString("rcvno")
        dao.fields.rgttpcd = Request.QueryString("ntype")
        dao.fields.STATUS_INDEX = ddl_head_status.SelectedValue
        dao.fields.IS_EXTRA_STAGE = 1
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url As String = ""
        Dim url2 As String = ""
        'If Request.QueryString("extra") = "" Then
        url2 = "../FRM_DRRGT_STATUS_POPUPV2.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&head=" & Request.QueryString("head") & "&drgtpcd=" & Request.QueryString("drgtpcd")
        'Else
        '    url2 = "../FRM_DRRGT_STATUS_POPUPV2.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&extra=1" & "&head=" & Request.QueryString("head")
        'End If

        Response.Redirect(url2)
    End Sub
End Class