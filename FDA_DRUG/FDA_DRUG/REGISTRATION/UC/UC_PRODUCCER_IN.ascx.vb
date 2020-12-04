Imports Telerik.Web.UI

Public Class UC_PRODUCCER_IN
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _type As String
    Private subtype As String
    Private _ProcessID As Integer
    Private _MENU_GROUP As String = ""
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                Dim IDA As Integer = _CLS.IDA = 99
                _CLS = Session("CLS")
                ' _type = Request.QueryString("type")
                _type = Request.QueryString("process")
                'Dim bao As New BAO.PROCESS
                _ProcessID = 99 ' ProcessID สถานที่ตั้ง
                _MENU_GROUP = Request.QueryString("MENU_GROUP")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Search_FN()
        RadGrid1.Rebind()
        If Not IsPostBack Then
            If Request.QueryString("tt") <> "" Then
                btn_save_work_type.Visible = False
                btn_select.Visible = False
            End If
        End If
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub
    Sub Search_FN()
        'Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_DALCN_STAFF_SEARCH()
        Dim lcntpcd As String = ""

        Dim sql As String = ""
        sql = "select * from dbo.VW_DALCN_STAFF_SEARCH where STATUS_NAME = 'อนุมัติ' and "
        Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_regis.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.GetDataby_IDA(dao_regis.fields.FK_IDA)
            lcntpcd = dao_dal.fields.lcntpcd
        Catch ex As Exception

        End Try

        Dim bao As New BAO.ClsDBSqlcommand


        Dim dt As New DataTable
        
        'Dim r_result As DataRow()
        'Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_NUM.Text <> "" Then
            'If sql <> "" Then
            '    str_where &= " and lcnno_no like '%" & txt_NUM.Text & "%'"
            'Else
            sql &= "lcnno_no like '%" & txt_NUM.Text & "%'"
            'End If

            If lcntpcd <> "" Then
                If lcntpcd.Contains("ผย") Then
                    sql &= " and lcntpcd like '%ผย%'"
                ElseIf lcntpcd.Contains("นย") Then
                    sql &= " and lcntpcd like '%นย%'"
                End If

            End If

            dt = bao.Queryds(sql)
        End If
        
        'r_result = dt.Select(str_where)

        'dt2 = dt.Clone

        'For Each dr As DataRow In r_result
        '    dt2.Rows.Add(dr.ItemArray)
        'Next

        RadGrid1.DataSource = dt
    End Sub
    'Private Sub rg_name_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_name.ItemCommand
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim bao_infor As New BAO.information

    '    If e.CommandName = "sel" Then
    '        Dim item As GridDataItem
    '        item = e.Item
    '        _CLS.CITIZEN_ID_AUTHORIZE = item("IDENTIFY").Text
    '        _CLS = bao_infor.load_lcnsid_customer(_CLS)
    '        _CLS = bao_infor.load_name(_CLS)
    '        Session("CLS") = _CLS

    '        'RadGrid1.DataSource = BAO.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN(1, _CLS.LCNSID_CUSTOMER) 'เรียกใช้เพื่อดึงข้อมูลสถานที่ตั้ง
    '        RadGrid1.DataSource = bao.SP_STAFF_DALCN_BY_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE)

    '        RadGrid1.Rebind()
    '    End If
    'End Sub

    Private Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        For Each item As GridDataItem In RadGrid1.SelectedItems
            Dim lcntpcd As String = ""
            Dim dao_da As New DAO_DRUG.ClsDBdalcn
            Try
                dao_da.GetDataby_IDA(item("IDA").Text)
                lcntpcd = dao_da.fields.lcntpcd
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
            dao.fields.FK_PRODUCER = item("IDA").Text
            dao.fields.FK_IDA = Request.QueryString("IDA")
            'dao.fields.PRODUCER_WORK_TYPE = ddl_work_type.SelectedValue
            Try
                dao.fields.addr_ida = dao_da.fields.FK_IDA
            Catch ex As Exception

            End Try

            dao.insert()
        Next
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_infor As New BAO.information

        If e.CommandName = "_del" Then
            Dim item As GridDataItem
            item = e.Item
            If Request.QueryString("tt") <> "" Then
                alert("ไม่สามารถลบข้อมูลได้")
            Else
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()

                'alert("ลบเรียบร้อยแล้ว")
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อยแล้ว');", True)
                RadGrid2.Rebind()

            End If


        End If
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim lbl_comment As Label = DirectCast(item("work_type").FindControl("lbl_work_type"), Label)
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)


            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
            dao.GetDataby_IDA(item("IDA").Text)
            Try
                rcb_work_type.SelectedValue = dao.fields.PRODUCER_WORK_TYPE

                'If dao.fields.PRODUCER_WORK_TYPE IsNot Nothing Then
                '    rcb_work_type.Style.Add("display", "none")
                '    lbl_comment.Style.Add("display", "block")
                'Else
                '    rcb_work_type.Style.Add("display", "block")
                '    lbl_comment.Style.Add("display", "none")
                'End If
            Catch ex As Exception

            End Try
            Try
                Dim btn_del As LinkButton = CType(item("_del").Controls(0), LinkButton)
                If Request.QueryString("tt") <> "" Then
                    btn_del.Visible = False
                End If
            Catch ex As Exception

            End Try
            Try

                If dao.fields.PRODUCER_WORK_TYPE = 1 Then
                    lbl_comment.Text = "ผลิตยาสำเร็จรูป"
                ElseIf dao.fields.PRODUCER_WORK_TYPE = 2 Then
                    lbl_comment.Text = "แบ่งบรรจุ"
                ElseIf dao.fields.PRODUCER_WORK_TYPE = 3 Then
                    lbl_comment.Text = "ตรวจปล่อยหรือผ่านเพื่อจำหน่าย"
                ElseIf dao.fields.PRODUCER_WORK_TYPE = 9 Then
                    lbl_comment.Text = "อื่นๆ"
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'If Request.QueryString("type") = "rg" Then
        dt = bao.SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA(Request.QueryString("IDA"))
        'Else
        'dt = bao.SP_DRRQT_PRODUCER_IN_BY_FK_IDA(Request.QueryString("IDA"))
        'End If


        RadGrid2.DataSource = dt
    End Sub

    Private Sub RadGrid1_ExcelMLWorkBookCreated(sender As Object, e As GridExcelBuilder.GridExcelMLWorkBookCreatedEventArgs) Handles RadGrid1.ExcelMLWorkBookCreated
        Search_FN()
    End Sub

    Protected Sub btn_save_work_type_Click(sender As Object, e As EventArgs) Handles btn_save_work_type.Click
        For Each item As GridDataItem In RadGrid2.Items
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)
            Try
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                dao.GetDataby_IDA(item("IDA").Text)
                dao.fields.PRODUCER_WORK_TYPE = rcb_work_type.SelectedValue
                dao.update()
            Catch ex As Exception

            End Try
        Next
        RadGrid2.Rebind()
    End Sub
End Class