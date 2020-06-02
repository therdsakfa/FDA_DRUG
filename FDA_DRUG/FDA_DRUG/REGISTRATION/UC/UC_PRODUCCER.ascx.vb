Imports Telerik.Web.UI

Public Class UC_PRODUCCER
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_nat()
            If Request.QueryString("tt") <> "" Then
                btn_select.Enabled = False
                btn_save_work_type.Enabled = False
                btn_select.Style.Add("display", "none")
                btn_save_work_type.Style.Add("display", "none")
            End If
        End If
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        rg_search_fore.Rebind()
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Sub bind_nat()
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao.SP_MASTER_sysisocnt()
        rcb_national.DataSource = dt
        rcb_national.DataTextField = "engcntnm"
        rcb_national.DataValueField = "alpha3"
        rcb_national.DataBind()

    End Sub
    Sub Search_FN()
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_FOREIGN_ADDR "
        Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_search.Text = "" Then
            alert("กรุณากรอกข้อมูลที่ต้องการค้นหา")
        Else
            If txt_search.Text <> "" Then
                str_where = "where engfrgnnm like '%" & txt_search.Text & "%' and alpha3='" & rcb_national.SelectedValue & "'"
                command &= str_where
            Else
                alert("กรุณากรอกข้อมูลที่ต้องการค้นหา")
            End If
        End If

        dt = bao_aa.Queryds(command)
        rg_search_fore.DataSource = dt

    End Sub

    Private Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        For Each item As GridDataItem In rg_search_fore.SelectedItems
            Dim dao_frg As New DAO_DRUG.ClsDBsyspdcfrgn
            dao_frg.GetData_by_IDA(item("IDA").Text)
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
            dao.fields.FK_PRODUCER = item("IDA").Text
            dao.fields.FK_IDA = Request.QueryString("IDA")
            dao.fields.frgncd = item("frgncd").Text
            'dao.fields.PRODUCER_WORK_TYPE = ddl_work_type.SelectedValue
            dao.fields.addr_ida = item("addr_ida").Text
            dao.fields.frgnlctcd = item("frgnlctcd").Text
            dao.insert()
        Next
        rg_produccer.Rebind()
    End Sub

    Private Sub rg_produccer_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_produccer.ItemCommand
        '
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("P_IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                If Request.QueryString("tt") <> "" Then
                    alert("ไม่สามารถลบข้อมูลได้")
                Else
                    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                    'alert("ลบเรียบร้อยแล้ว")
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อยแล้ว');", True)
                    rg_produccer.Rebind()

                End If
            End If

            End If
    End Sub

    Private Sub rg_produccer_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_produccer.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("P_IDA").Text
            Dim lbl_comment As Label = DirectCast(item("work_type").FindControl("lbl_work_type"), Label)
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)


            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
            dao.GetDataby_IDA(item("P_IDA").Text)
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

    Private Sub rg_produccer_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_produccer.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))

        rg_produccer.DataSource = dt
    End Sub

    Protected Sub btn_save_work_type_Click(sender As Object, e As EventArgs) Handles btn_save_work_type.Click
        For Each item As GridDataItem In rg_produccer.Items
            Dim rcb_work_type As RadComboBox = DirectCast(item("work_type").FindControl("rcb_work_type"), RadComboBox)
            Try
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
                dao.GetDataby_IDA(item("P_IDA").Text)
                dao.fields.PRODUCER_WORK_TYPE = rcb_work_type.SelectedValue
                dao.update()
            Catch ex As Exception

            End Try
        Next
        rg_produccer.Rebind()
    End Sub
End Class