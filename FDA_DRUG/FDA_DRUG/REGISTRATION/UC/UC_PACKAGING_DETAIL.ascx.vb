Imports Telerik.Web.UI

Public Class UC_PACKAGING_DETAIL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl_small_unit()
            bind_ddl_medium_unit()
        End If
    End Sub
    Public Sub bind_lbl_unit()
        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

        Dim dao_u As New DAO_DRUG.TB_DRUG_UNIT
        Try
            dao_u.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
            lbl_small_unit.Text = dao_u.fields.unit_name
        Catch ex As Exception
            lbl_small_unit.Text = "-"
        End Try
    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
        Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao.fields.SMALL_AMOUNT = txt_SMALL_AMOUNT.Text
        Try
            dao.fields.SMALL_UNIT = dao_rg.fields.UNIT_NORMAL
        Catch ex As Exception

        End Try

        dao.fields.MEDIUM_UNIT = ddl_medium_unit.SelectedValue
        dao.fields.BARCODE = txt_BARCODE.Text
        dao.fields.FK_IDA = Request.QueryString("IDA")
        dao.insert()

        alert("บันทึกแล้ว")
        RadGrid2.Rebind()
    End Sub

    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao.GetDataby_IDA(IDA)
                dao.delete()
                RadGrid2.Rebind()
            End If

        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao_show As New BAO_SHOW
        Dim dt As New DataTable
        Dim ida As String = ""
        Try
            ida = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        If ida <> "" Then
            dt = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA_v2(ida)
        End If

        If dt.Rows.Count > 0 Then
            RadGrid2.DataSource = dt
        End If
    End Sub

    Public Sub bind_ddl_small_unit()
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        'dt = bao.SP_DRUG_UNIT_PHYSIC()
        'ddl_small_unit.DataSource = dt
        'ddl_small_unit.DataTextField = "unit_name"
        'ddl_small_unit.DataValueField = "sunitcd"
        'ddl_small_unit.DataBind()
    End Sub

    Public Sub bind_ddl_medium_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()
        ddl_medium_unit.DataSource = dt
        ddl_medium_unit.DataTextField = "sunitengnm"
        ddl_medium_unit.DataValueField = "sunitcd"
        ddl_medium_unit.DataBind()
    End Sub
End Class