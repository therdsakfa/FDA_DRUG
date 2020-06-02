Imports Telerik.Web.UI

Public Class FRM_DRUG_PRODUCT_ID_STAFF_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lct_ida As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'load_GV_lcnno()
        End If
    End Sub
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub

    'Sub load_GV_lcnno()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao.SP_DRUG_PRODUCT_ID_BY_FK_IDA_STAFF()
    '    GV_lcnno.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
    '    GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    'End Sub
    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
    '    GV_lcnno.PageIndex = e.NewPageIndex
    '    load_GV_lcnno()
    'End Sub

    'Private Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
    '    'If e.CommandName = "del" Then
    '    '    Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
    '    '    dao.GetDataby_IDA(str_ID)
    '    '    dao.delete()
    '    '    Response.Write("<script type='text/javascript'>alert('ลบข้อมูลเรียบร้อย');</script> ")
    '    '    load_GV_lcnno()
    '    'ElseIf e.CommandName = "accept" Then
    '    '    Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
    '    '    dao.GetDataby_IDA(str_ID)
    '    '    dao.fields.STATUS_ID = 2
    '    '    dao.update()
    '    '    load_GV_lcnno()
    '    'End If
    'End Sub

    'Private Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim btn_sel As Button = DirectCast(e.Row.FindControl("btn_sel"), Button)
    '        Dim index As Integer = e.Row.RowIndex
    '        Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
    '        Dim dao As New DAO_DRUG.ClsDBdalcn
    '        dao.GetDataby_IDA(Integer.Parse(str_ID))
    '        btn_sel.Attributes.Add("onclick", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_STAFF_V2.aspx?IDA=" & str_ID & "'); return false;")
    '    End If
    'End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            'If e.CommandName = "del" Then
            '    Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
            '    dao.GetDataby_IDA(item("IDA").Text)
            '    dao.delete()
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
            '    RadGrid1.Rebind()
            'End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim str_ID As Integer = item("IDA").Text
            Dim btn_sel As LinkButton = DirectCast(item("btn_sel").Controls(0), LinkButton)
            btn_sel.Attributes.Add("onclick", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_STAFF_V2.aspx?IDA=" & str_ID & "'); return false;")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_PRODUCT_ID_BY_FK_IDA_STAFF()

        RadGrid1.DataSource = dt
    End Sub

    Protected Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Dim strMsg As String = ""
        strMsg = "([LCNNO_DISPLAY] LIKE '%" & txt_product_number.Text & "%')" & _
            " and ([TRADE_NAME] LIKE '%" & txt_tradnm.Text & "%')" & _
            " and ([TRADE_NAME_ENG] LIKE '%" & txt_tradnm_eng.Text & "%')"

        RadGrid1.EnableLinqExpressions = False
        RadGrid1.MasterTableView.FilterExpression = strMsg
        RadGrid1.MasterTableView.Rebind()
    End Sub
    Private Sub export_excel2()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt2 As New DataTable
        dt2.Columns.Add("เลขที่ผลิตภัณฑ์")
        dt2.Columns.Add("สถานะ")
        dt2.Columns.Add("ชื่อผลิตภัณฑ์")
        dt2.Columns.Add("ชื่อผลิตภัณฑ์ภาษาอังกฤษ")
        Dim bao_list As New BAO.ClsDBSqlcommand
        Dim dt_list As New DataTable
        dt_list = bao.SP_DRUG_PRODUCT_ID_BY_FK_IDA_STAFF()
        For Each dr As DataRow In dt_list.Select("LCNNO_DISPLAY LIKE '%" & txt_product_number.Text & _
                                                 "%' and TRADE_NAME LIKE '%" & txt_tradnm.Text & "%' and  TRADE_NAME_ENG LIKE '%" & txt_tradnm_eng.Text & "%'")
            Dim dr2 As DataRow = dt2.NewRow()
            dr2("เลขที่ผลิตภัณฑ์") = dr("LCNNO_DISPLAY")
            dr2("สถานะ") = dr("STATUS_NAME")
            dr2("ชื่อผลิตภัณฑ์") = dr("TRADE_NAME")
            dr2("ชื่อผลิตภัณฑ์ภาษาอังกฤษ") = dr("TRADE_NAME_ENG")


            dt2.Rows.Add(dr2)
        Next

        'For ii As Integer = 0 To dt2.Columns.Count - 1
        '    If ii > 1 Then
        '        dt2.Columns.RemoveAt(ii)
        '    End If

        'Next

        Dim filename As String = ""
        filename = "Export_" & Date.Now.ToString("ddMMyyyy")

        Dim attachment As String = "attachment; filename=" & filename & ".xls"
        Response.ClearContent()
        Response.Charset = "windows-874"
        Response.ContentEncoding = System.Text.Encoding.GetEncoding(874)
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/vnd.ms-excel"
        Dim tab As String = ""
        For Each dc As DataColumn In dt2.Columns
            Response.Write(tab + dc.ColumnName)
            tab = vbTab
        Next
        Response.Write(vbLf)
        Dim i As Integer
        For Each dr As DataRow In dt2.Rows
            tab = ""
            For i = 0 To dt2.Columns.Count - 1
                Response.Write(tab & dr(i).ToString())
                tab = vbTab
            Next
            Response.Write(vbLf)
        Next
        Response.[End]()

    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        export_excel2()
    End Sub
End Class