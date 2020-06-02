Imports Telerik.Web.UI

Public Class FRM_EDIT_COUNT
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
        If Not IsPostBack Then
            txt_count_date.Text = Date.Now.ToShortDateString
            UC_Information_edit1.Shows(Request.QueryString("ida"))
        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_EDT_COUNT
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อยแล้ว');", True)
                RadGrid2.Rebind()
            ElseIf e.CommandName = "sel" Then
                Dim IDA As Integer = item("IDA").Text
                Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_LOCATION_EDIT_PAGE_MAIN.aspx?ida=" & Request.QueryString("ida") & "&process=" & Request.QueryString("process") & "&ida_c=" & IDA & "&iden=" & Request.QueryString("iden"))
            End If

        End If
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim btn_preview As LinkButton = DirectCast(item("preview").Controls(0), LinkButton)
            Dim btn_behind As LinkButton = DirectCast(item("behind").Controls(0), LinkButton)


            btn_preview.Attributes.Add("onclick", "Popups2('" & "POPUP_EDIT_COUNT_LIST.aspx?ida=" & IDA & "');return false;") 'ใส่ URL ปุ่่ม ดูข้อมมูล
            btn_behind.Attributes.Add("onclick", "Popups3('" & "FRM_REPORT_BEHIND.aspx?ida=" & IDA & "');return false;")
            '
        End If
    End Sub


    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable = bao.SP_EDT_COUNT_BY_FK_IDA_AND_PROCESS_ID(Request.QueryString("ida"), Request.QueryString("process"))

        RadGrid2.DataSource = dt
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_EDT_COUNT
        dao.fields.EDIT_COUNT = rnt_count.Value
        Try
            dao.fields.COUNT_DATE = CDate(txt_count_date.Text)
        Catch ex As Exception

        End Try
        dao.fields.RCVNO_T = txt_rcvno_t.Text
        dao.fields.FK_IDA = Request.QueryString("ida")
        dao.fields.PROCESS_ID = Request.QueryString("process")
        dao.fields.IDEN_INSERT = _CLS.CITIZEN_ID
        dao.insert()
        Response.Write("<script type='text/javascript'>alert('บันทึกข้อมูลเรียบร้อย');</script> ")
        RadGrid2.Rebind()
    End Sub
End Class