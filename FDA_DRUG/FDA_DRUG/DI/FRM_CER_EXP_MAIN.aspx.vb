Imports Telerik.Web.UI

Public Class FRM_CER_EXP_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Sub runQuery()
        'process = 1001022
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _process = Request.QueryString("process")
    End Sub
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
        runQuery()
        RunSession()
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_CER_EXP_INSERT_AND_UPDATE.aspx?lcn_ida=" & Request.QueryString("lcn_ida") & "&process=" & _process & "');", True)
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "sel" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_CER_EXP_INSERT_AND_UPDATE.aspx?ida=" & item("IDA").Text & "&lcn_ida=" & Request.QueryString("lcn_ida") & "');", True)
            ElseIf e.CommandName = "accept" Then
                Dim dao_count As New DAO_DRUG.TB_CER_EXTEND_DETAIL
                Dim i As Integer = 0
                i = dao_count.count_det(item("IDA").Text)
                If i > 0 Then
                    Dim dao As New DAO_DRUG.TB_CER_EXTEND
                    dao.GetDataby_IDA(item("IDA").Text)
                    dao.fields.STATUS_ID = 2
                    dao.update()
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยืนยันข้อมูลแล้ว');", True)
                    RadGrid1.Rebind()
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถยืนยันได้ กรุณาเพิ่ม Cert อย่างน้อย 1 รายการ');", True)
                End If

            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim btn_accept As LinkButton = DirectCast(item("btn_accept").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.TB_CER_EXTEND
            dao.GetDataby_IDA(item("IDA").Text)
            Try
                If dao.fields.STATUS_ID >= 2 Then
                    btn_accept.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_CER_EXTEND_FK_IDA(Request.QueryString("lcn_ida"))
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub
End Class