Imports Telerik.Web.UI
Public Class FRM_DS_SELECT_LCN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub rg_name_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_name.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim bao As New BAO.ClsDBSqlcommand
            bao.SP_DRUG_PRODUCT_ID_BY_LCN_IDA(item("IDA").Text)
            RadGrid1.DataSource = bao.dt   'เรียกใช้เพื่อดึงข้อมูลสถานที่ตั้ง
            RadGrid1.Rebind()
        End If
    End Sub

    Private Sub rg_name_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_name.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim process As String = ""
        Try
            process = Request.QueryString("process")
        Catch ex As Exception

        End Try
        dt = bao.SP_CUSTOMER_LCN_BY_CITIZEN_ID_AUTHORIZE(_CLS.CITIZEN_ID_AUTHORIZE)
        If process = "1701" Then
            rg_name.DataSource = dt.Select("lcntpcd='ผย1'", "IDA desc")
        ElseIf process = "1702" Then
            rg_name.DataSource = dt.Select("lcntpcd='นย1'", "IDA desc")
        ElseIf process = "1703" Then
            rg_name.DataSource = dt.Select("lcntpcd='นยบ' or lcntpcd='ผยบ'", "IDA desc")
        End If

        'rg_name.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = ""
            Dim LCN_IDA As String = ""
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Try
                LCN_IDA = item("LCN_IDA").Text
            Catch ex As Exception

            End Try
            Dim btn_sel As LinkButton = DirectCast(item("btn_sel").Controls(0), LinkButton)
            'btn_sel.PostBackUrl = "FRM_REPLACEMENT_LICENSE_LOCATION_MENU.aspx?lct_ida=" & IDA
            btn_sel.PostBackUrl = "../DS/FRM_DS_MAIN.aspx?pid=" & IDA & "&process=" & Request.QueryString("process") & "&lcn_ida=" & LCN_IDA
        End If
    End Sub
End Class