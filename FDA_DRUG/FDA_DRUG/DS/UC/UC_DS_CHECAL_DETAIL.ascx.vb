Imports Telerik.Web.UI

Public Class UC_DS_CHECAL_DETAIL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub bind_ddl_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()

        ddl_unit.DataSource = dt
        ddl_unit.DataTextField = "sunitengnm"
        ddl_unit.DataValueField = "sunitcd"
        ddl_unit.Items.Insert(0, New ListItem("0", "กรุณาเลือก"))
        ddl_unit.DataBind()

    End Sub
    Public Sub bind_ddl_unit2()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()

        ddl_unit2.DataSource = dt
        ddl_unit2.DataTextField = "sunitengnm"
        ddl_unit2.DataValueField = "sunitcd"
        ddl_unit2.Items.Insert(0, New ListItem("0", "กรุณาเลือก"))
        ddl_unit2.DataBind()

    End Sub
    
    Public Sub bind_ddl_chemecal()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_MAS_CHEMICAL_ALL()
        ddl_chemecal.DataSource = dt
        ddl_chemecal.Items.Insert(0, New ListItem("0", "กรุณาเลือก"))
        ddl_chemecal.DataBind()
    End Sub
    Public Sub bind_ddl_chemecal2()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_MAS_CHEMICAL_ALL()
        ddl_chemecal2.DataSource = dt
        ddl_chemecal2.Items.Insert(0, New ListItem("0", "กรุณาเลือก"))
        ddl_chemecal2.DataBind()
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_DRSAMP_DETAIL_CAS
        dao.fields.FK_IDA = Request.QueryString("IDA")
        dao.fields.IOWA = ddl_chemecal.SelectedValue
        dao.fields.QTY = Txt_DOSAGE.Text
        dao.fields.ROWS = 0
        dao.fields.SUNITCD = ddl_unit.SelectedValue
        dao.fields.EQTO_IOWA = ddl_chemecal2.SelectedValue
        dao.fields.EQTO_QTY = Txt_DOSAGE2.Text
        dao.fields.EQTO_SUNITCD = ddl_unit2.SelectedValue
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เพิ่มข้อมูลเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRSAMP_DETAIL_CAS
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_DRSAMP_DETAIL_CAS_DETAIL(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
    End Sub
End Class