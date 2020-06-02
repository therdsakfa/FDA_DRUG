Public Class UC_DS_NORYOR8_DETAIL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub bind_ddl_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()

        ddl_unit.DataSource = dt
        ddl_unit.DataTextField = "sunitengnm"
        ddl_unit.DataValueField = "IDA"
        ddl_unit.DataBind()

    End Sub
    Public Sub bind_QUANTITY_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()

        ddl_QUANTITY_unit.DataSource = dt
        ddl_QUANTITY_unit.DataTextField = "sunitengnm"
        ddl_QUANTITY_unit.DataValueField = "IDA"
        ddl_QUANTITY_unit.DataBind()

    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.ClsDBdrsamp)
        dao.fields.WRITE_AT = txt_WRITE_AT.Text
        dao.fields.WRITE_DATE = txt_WRITE_DATE.Text
        dao.fields.thadrgnm = txt_thadrgnm.Text
        dao.fields.engdrgnm = txt_engdrgnm.Text
        dao.fields.QUANTITY = txt_QUANTITY.Text
        dao.fields.QUANTITY_UNIT = ddl_QUANTITY_unit.SelectedValue
        'dao.fields.uni()
    End Sub

    Protected Sub ddl_QUANTITY_unit_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class