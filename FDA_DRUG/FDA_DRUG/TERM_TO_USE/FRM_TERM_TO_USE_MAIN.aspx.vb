Imports Telerik.Web.UI

Public Class FRM_TERM_TO_USE_MAIN
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
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_DRUG_TERM_TO_USE
        With dao.fields
            .FK_IDA = 0
            .IDEN_INSERT = _CLS.CITIZEN_ID
            .INSERT_DATE = Date.Now
            .RGTNO = txt_rgtno.Text
            .TERM_TO_USE = txt_term.Text
        End With
        dao.insert()
        txt_rgtno.Text = ""
        txt_term.Text = ""
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_TERM_TO_USE
                dao.GetDataby_IDA(item("IDA").Text)
                dao.insert()
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_TERM_TO_USE()

        RadGrid1.DataSource = dt

    End Sub
End Class