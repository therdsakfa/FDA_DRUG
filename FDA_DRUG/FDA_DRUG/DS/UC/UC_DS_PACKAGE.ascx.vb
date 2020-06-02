Public Class UC_DS_PACKAGE
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub bind_ddl_contain_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_UNIT_CONTAIN()

        ddl_contain_unit.DataSource = dt
        ddl_contain_unit.DataTextField = "unitnm"
        ddl_contain_unit.DataValueField = "unitcd2"
        ddl_contain_unit.Items.Insert(0, New ListItem("0", "กรุณาเลือก"))
        ddl_contain_unit.DataBind()

    End Sub
    Public Sub bind_ddl_contain_unit2()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_UNIT_CONTAIN()

        ddl_contain_unit2.DataSource = dt
        ddl_contain_unit2.DataTextField = "unitnm"
        ddl_contain_unit2.DataValueField = "unitcd2"
        ddl_contain_unit2.Items.Insert(0, New ListItem("0", "กรุณาเลือก"))
        ddl_contain_unit2.DataBind()

    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim ida As Integer = 0
        Try
            ida = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        dt = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA(ida)
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        With dao.fields
            .BIG_UNIT = ddl_contain_unit2.SelectedValue
            .FK_IDA = Request.QueryString("IDA")
            .MEDIUM_AMOUNT = Txt_DOSAGE2.Text
            .MEDIUM_UNIT = ddl_contain_unit.SelectedValue
            .SMALL_AMOUNT = Txt_DOSAGE.Text

            Try
                Dim dao_h As New DAO_DRUG.ClsDBdrsamp
                dao_h.GetDataby_IDA(Request.QueryString("IDA"))
                .SMALL_UNIT = dao_h.fields.SMALL_UNIT
            Catch ex As Exception

            End Try
            '
        End With


    End Sub

    Protected Sub ddl_contain_unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_contain_unit.SelectedIndexChanged

    End Sub
End Class