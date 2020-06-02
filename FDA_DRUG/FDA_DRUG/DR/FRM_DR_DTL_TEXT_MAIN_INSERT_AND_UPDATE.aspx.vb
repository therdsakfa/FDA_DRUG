Imports Telerik.Web.UI

Public Class FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            If Request.QueryString("IDA") <> "" Then
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                txt_dtl.Text = dao.fields.dtl
                txt_pcksize.Text = dao.fields.pcksize
            End If

        End If
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.Get_U1_Data(txt_name_product.Text, txt_lcnno.Text)
        Catch ex As Exception

        End Try
        If txt_lcnno.Text <> "" Or txt_name_product.Text <> "" Then
            RadGrid1.DataSource = dt
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim i As Integer = 0
        Dim j As Integer = 0
        For Each item As GridDataItem In RadGrid1.SelectedItems
            i += 1
        Next
        If i = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลิอกทะเบียนผลิตภัณฑ์'); ", True)
        Else

            For Each item As GridDataItem In RadGrid1.SelectedItems
                Dim dao_c As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                j = dao_c.count_repeat(item("Newcode").Text)
                If j > 0 Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกซ้ำ'); ", True)
                Else
                    Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                    With dao.fields
                        .U1_CODE = item("Newcode").Text
                        .dtl = txt_dtl.Text
                        .pcksize = txt_pcksize.Text
                        .drgtpcd = item("drgtpcd").Text
                        .pvncd = item("pvncd").Text
                        .rgtno = item("rgtno").Text
                        .rgttpcd = item("rgttpcd").Text
                        .engdrgtpnm = IIf(item("engdrgtpnm").Text.Contains("&nbsp;"), Nothing, item("engdrgtpnm").Text)
                    End With
                    dao.insert()

                End If

            Next
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย'); parent.$('#ContentPlaceHolder1_btn_reload').click();", True)
        End If
        
        
    End Sub

    Private Sub RadGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGrid1.SelectedIndexChanged
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim item As GridDataItem = RadGrid1.SelectedItems(0)
        Try
            dt = bao.Get_U1_Data_BY_U1(item("Newcode").Text)
        Catch ex As Exception

        End Try

        For Each dr As DataRow In dt.Rows
            Try
                lbl_engdrgtpnm.Text = dr("engdrgtpnm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcnno_display.Text = dr("lcnno_display")
            Catch ex As Exception

            End Try
            Try
                lbl_product_name.Text = dr("product_name")
            Catch ex As Exception

            End Try
            Try
                lbl_rgttpcd.Text = dr("rgttpcd")
            Catch ex As Exception

            End Try
        Next
        
    End Sub
End Class