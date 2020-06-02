Imports Telerik.Web.UI

Public Class FRM_EDIT_LOCATION_SEARCH
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
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

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        bind_grid()  'SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDENTIFY
    End Sub
    Sub bind_grid()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'If ddl_type.SelectedValue = "1" Or ddl_type.SelectedValue = "2" Then
        '    'dt = bao.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDENTIFY(ddl_type.SelectedValue, txt_citizen.Text)

        'End If
        dt = bao.SP_CUSTOMER_LCN_BY_IDEN(txt_citizen.Text)
        If dt.Rows.Count = 0 Then

            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        Else
            'RadGrid2.DataSource = dt
            RadGrid2.Rebind()
        End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "sel" Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            _CLS.IDA = IDA
            Session("CLS") = _CLS
            'FRM_EDIT_COUNT.aspx
            'Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_LOCATION_EDIT_PAGE_MAIN.aspx?ida=" & IDA & "&iden=" & txt_citizen.Text & "&process=" & item("PROCESS_ID").Text)
            Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_COUNT.aspx?ida=" & IDA & "&iden=" & txt_citizen.Text & "&process=" & item("PROCESS_ID").Text)

        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If e.CommandName = "sel" Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            _CLS.IDA = IDA
            Session("CLS") = _CLS
            'FRM_EDIT_COUNT.aspx
            'Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_LOCATION_EDIT_PAGE_MAIN.aspx?ida=" & IDA & "&iden=" & txt_citizen.Text & "&process=" & item("PROCESS_ID").Text)
            Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_COUNT.aspx?ida=" & IDA & "&iden=" & txt_citizen.Text & "&process=" & item("PROCESS_ID").Text)

        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_CUSTOMER_LCN_BY_IDEN(txt_citizen.Text)

        RadGrid2.DataSource = dt
    End Sub
End Class