Public Class FRM_DRUG_PRODUCT_ID_STAFF_CHECK
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lct_ida As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_GV_lcnno()
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

    Sub load_GV_lcnno()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_PRODUCT_ID_STAFF_CHECK()
        GV_lcnno.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub

    Private Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        'If e.CommandName = "del" Then
        '    Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        '    dao.GetDataby_IDA(str_ID)
        '    dao.delete()
        '    Response.Write("<script type='text/javascript'>alert('ลบข้อมูลเรียบร้อย');</script> ")
        '    load_GV_lcnno()
        'ElseIf e.CommandName = "accept" Then
        '    Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        '    dao.GetDataby_IDA(str_ID)
        '    dao.fields.STATUS_ID = 2
        '    dao.update()
        '    load_GV_lcnno()
        'End If
    End Sub

    Private Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_sel As Button = DirectCast(e.Row.FindControl("btn_sel"), Button)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            btn_sel.Attributes.Add("onclick", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_STAFF_V2.aspx?IDA=" & str_ID & "&chk=1'); return false;")
        End If
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
    End Sub
End Class