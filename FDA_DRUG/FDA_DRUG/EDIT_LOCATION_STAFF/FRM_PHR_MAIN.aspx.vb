Imports Telerik.Web.UI

Public Class FRM_PHR_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UC_Information_edit1.Shows(Request.QueryString("ida"))
        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(item("PHR_IDA").Text)

            Dim dao_his As New DAO_DRUG.TB_DALCN_PHR_HISTORY
            If e.CommandName = "del" Then
                dao.fields.IS_ACTIVE = False
                dao.update()

                dao_his.fields.OLD_PHR_NAME = dao.fields.PHR_NAME
                dao_his.fields.TYPE_INSERT = 2
                dao_his.fields.ACTIVE_DATE = Date.Now
                dao_his.fields.PHR_CITIZEN_ID = dao.fields.PHR_CTZNO
                dao_his.fields.PHR_LEVEL = dao.fields.PHR_LEVEL
                dao_his.fields.FK_PHR_IDA = item("PHR_IDA").Text
                dao_his.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
                dao_his.fields.EDIT_TYPE = 5
                dao_his.insert()

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('นำออกเรียบร้อย');", True)
            ElseIf e.CommandName = "add" Then
                dao.fields.IS_ACTIVE = True
                dao.update()

                dao_his.fields.OLD_PHR_NAME = dao.fields.PHR_NAME
                dao_his.fields.TYPE_INSERT = 1
                dao_his.fields.ACTIVE_DATE = Date.Now
                dao_his.fields.PHR_CITIZEN_ID = dao.fields.PHR_CTZNO
                dao_his.fields.PHR_LEVEL = dao.fields.PHR_LEVEL
                dao_his.fields.FK_PHR_IDA = item("PHR_IDA").Text
                dao_his.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
                dao_his.fields.EDIT_TYPE = 5
                dao_his.insert()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('นำเข้าเรียบร้อย');", True)
            ElseIf e.CommandName = "edt" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PHR_EDIT.aspx?ida=" & Request.QueryString("ida") & "&ida_c=" & Request.QueryString("ida_c") & "&phr=" & item("PHR_IDA").Text & "');", True)
            ElseIf e.CommandName = "r_del" Then
                dao.delete()

                dao_his.fields.OLD_PHR_NAME = dao.fields.PHR_NAME
                dao_his.fields.TYPE_INSERT = 4
                dao_his.fields.ACTIVE_DATE = Date.Now
                dao_his.fields.PHR_CITIZEN_ID = dao.fields.PHR_CTZNO
                dao_his.fields.PHR_LEVEL = dao.fields.PHR_LEVEL
                dao_his.fields.FK_PHR_IDA = item("PHR_IDA").Text
                dao_his.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
                dao_his.fields.EDIT_TYPE = 5
                dao_his.insert()

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อยแล้ว');", True)
            ElseIf e.CommandName = "job" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PHR_JOB.aspx?ida=" & Request.QueryString("ida") & "&ida_c=" & Request.QueryString("ida_c") & "&phr=" & item("PHR_IDA").Text & "');", True)
            End If
            RadGrid2.Rebind()
        End If
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("PHR_IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            dao.GetDataby_IDA(IDA)
            Dim btn_del As LinkButton = DirectCast(item("del").Controls(0), LinkButton)
            'Dim btn_add As LinkButton = DirectCast(item("add").Controls(0), LinkButton)
            Dim btn_his As LinkButton = DirectCast(item("his").Controls(0), LinkButton)
            'If dao.fields.IS_ACTIVE = True Then
            '    'btn_add.Style.Add("display", "none")
            '    btn_del.Style.Add("display", "block")
            'Else
            '    'btn_add.Style.Add("display", "block")
            '    btn_del.Style.Add("display", "none")
            'End If
            Try
                If dao.fields.IS_ACTIVE = False Then
                    'item("PHR_FULLNAME").ForeColor = Drawing.Color.Red
                    e.Item.ForeColor = Drawing.Color.Red
                End If
            Catch ex As Exception

            End Try
            btn_his.Attributes.Add("onclick", "Popups2('" & "POPUP_PHR_HISTORY.aspx?ida=" & IDA & "');return false;") 'ใส่ URL ปุ่่ม ดูข้อมมูล
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("ida"))
        RadGrid2.DataSource = dt
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PHR_ADD.aspx?ida=" & Request.QueryString("ida") & "&ida_c=" & Request.QueryString("ida_c") & "');", True)
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid2.Rebind()
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_COUNT.aspx?ida=" & Request.QueryString("ida") & "&iden=" & Request.QueryString("iden") & "&process=" & Request.QueryString("process"))
    End Sub

    Private Sub btn_change_Click(sender As Object, e As EventArgs) Handles btn_change.Click
        If RadGrid2.SelectedItems.Count = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกผู้ปฏิบัติงาน');", True)
        Else
            Dim ida_phr As Integer = 0

            Try
                For Each item As GridDataItem In RadGrid2.SelectedItems
                    ida_phr = item("PHR_IDA").Text
                Next
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PHR_CHANGE.aspx?ida=" & Request.QueryString("ida") & "&ida_c=" & Request.QueryString("ida_c") & "&old=" & ida_phr & "');", True)

        End If
        
    End Sub
End Class