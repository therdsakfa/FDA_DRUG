Imports Telerik.Web.UI

Public Class POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        'hidden_btn()
        If Not IsPostBack Then
            bind_ddl_chemecal()
            bind_SP_dactg()
            If Request.QueryString("IDA") <> "" Then
                btn_save.Style.Add("display", "none")
                btn_edit.Style.Add("display", "block")
                Panel1.Style.Add("display", "block")
                Panel2.Style.Add("display", "block")
            Else
                btn_save.Style.Add("display", "block")
                btn_edit.Style.Add("display", "none")
                Panel1.Style.Add("display", "none")
                Panel2.Style.Add("display", "none")
            End If

            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                Txt_TRADE_NAME.Text = dao.fields.TRADE_NAME
                Txt_TRADE_NAME_ENG.Text = dao.fields.TRADE_NAME_ENG

                If dao.fields.STATUS_ID = 8 Then
                    btn_save.Style.Add("display", "none")
                    btn_edit.Style.Add("display", "none")
                    btn_add.Style.Add("display", "none")
                    btn_add2.Style.Add("display", "none")
                End If
            End If
        End If
    End Sub
    Sub hidden_btn()
        If Request.QueryString("IDA") <> "" Then
            btn_edit.Style.Add("display", "block")
            btn_save.Style.Add("display", "none")
        Else
            btn_edit.Style.Add("display", "none")
            btn_save.Style.Add("display", "block")
        End If
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ID)
        dao.fields.TRADE_NAME = Txt_TRADE_NAME.Text
        dao.fields.TRADE_NAME_ENG = Txt_TRADE_NAME_ENG.Text
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        set_data(dao)
        dao.fields.FK_IDA = Request.QueryString("lct_ida")
        dao.fields.STATUS_ID = 1
        dao.insert()

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&IDA=" & dao.fields.IDA
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        set_data(dao)
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย');", True)
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
    End Sub
    Public Sub bind_ddl_chemecal()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_MAS_CHEMICAL_ALL()

        ddl_chemecal.DataSource = dt
        ddl_chemecal.DataBind()
    End Sub
    Public Sub bind_SP_dactg()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_dactg

        ddl_gr_group.DataSource = dt
        ddl_gr_group.DataBind()
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
        dao.fields.IOWACD = ddl_chemecal.SelectedValue
        dao.fields.FK_IDA = Request.QueryString("IDA")
        dao.fields.DOSAGE = Txt_DOSAGE.Text
        'dao.fields.STRENGTH_DRUG = Txt_STRENGTH_DRUG.Text
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        dt = bao.SP_CDRUG_PRODUCT_IOWA(IDA)
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Private Sub btn_add2_Click(sender As Object, e As EventArgs) Handles btn_add2.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_DR_GROUP
        dao.fields.ctgcd = ddl_gr_group.SelectedValue
        dao.fields.FK_IDA = Request.QueryString("IDA")

        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        dt = bao.SP_DRUG_PRODUCT_DR_GROUP_BY_FK_IDA(IDA)
        RadGrid2.DataSource = dt
    End Sub

    Protected Sub Txt_DOSAGE_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class