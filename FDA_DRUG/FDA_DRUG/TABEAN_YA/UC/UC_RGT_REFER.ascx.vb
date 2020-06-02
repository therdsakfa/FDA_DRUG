Imports Telerik.Web.UI

Public Class UC_RGT_REFER
    Inherits System.Web.UI.UserControl
    Dim _IDA As Integer
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub
    Sub bind_data()
        If STATUS_ID = 8 Then
            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            dao1.GetDataby_FK_DRRQT(_IDA)
            Dim dao As New DAO_DRUG.TB_DRRGT_REFER
            dao.GetDataby_FKIDA(dao1.fields.IDA)
            Try
                rdl_ref_type.SelectedValue = dao.fields.REF_TYPE
            Catch ex As Exception

            End Try
            Try
                txt_request_at.Text = dao.fields.REQUEST_AT
            Catch ex As Exception

            End Try
            Try
                lbl_drugname_th.Text = dao1.fields.thadrgnm
            Catch ex As Exception

            End Try
            Try
                lbl_drugname_eng.Text = dao1.fields.engdrgnm
            Catch ex As Exception

            End Try
        Else
            Dim dao1 As New DAO_DRUG.ClsDBdrrqt
            dao1.GetDataby_IDA(_IDA)
            Dim dao As New DAO_DRUG.TB_DRRGT_REFER
            dao.GetDataby_FKIDA(_IDA)
            Try
                rdl_ref_type.SelectedValue = dao.fields.REF_TYPE
            Catch ex As Exception

            End Try
            Try
                txt_request_at.Text = dao.fields.REQUEST_AT
            Catch ex As Exception

            End Try
            Try
                lbl_drugname_th.Text = dao1.fields.thadrgnm
            Catch ex As Exception

            End Try
            Try
                lbl_drugname_eng.Text = dao1.fields.engdrgnm
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub Search_FN()
        Dim sql As String = ""
        sql = "select * from dbo.Vw_RGT_FOR_SEARCH where "
        Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        If txt_search.Text <> "" Then
            sql &= "full_rgtno like '%" & txt_search.Text & "%'"
            dt = bao.Queryds(sql)
        End If
        rg_search.DataSource = dt
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If rdl_ref_type.SelectedValue <> "" Then
            Dim i As Integer = 0
            If STATUS_ID = 8 Then
                For Each item As GridDataItem In rg_search.SelectedItems
                    Dim c_dao As New DAO_DRUG.TB_DRRGT_REFER
                    i = c_dao.CountDataby_FKIDA(_IDA)
                    If i = 0 Then
                        Dim dao As New DAO_DRUG.TB_DRRGT_REFER
                        dao.fields.FK_RGT_IDA = item("IDA").Text
                        dao.fields.FK_IDA = _IDA
                        dao.fields.REF_TYPE = rdl_ref_type.SelectedValue
                        dao.fields.REQUEST_AT = txt_request_at.Text
                        dao.insert()
                    Else
                        Dim dao As New DAO_DRUG.TB_DRRGT_REFER
                        dao.GetDataby_FKIDA(_IDA)
                        dao.fields.FK_RGT_IDA = item("IDA").Text
                        dao.fields.FK_IDA = _IDA
                        dao.fields.REF_TYPE = rdl_ref_type.SelectedValue
                        dao.fields.REQUEST_AT = txt_request_at.Text
                        dao.update()
                    End If
                Next
            Else
                For Each item As GridDataItem In rg_search.SelectedItems
                    Dim c_dao As New DAO_DRUG.TB_DRRQT_REFER
                    i = c_dao.CountDataby_FKIDA(_IDA)
                    If i = 0 Then
                        Dim dao As New DAO_DRUG.TB_DRRQT_REFER
                        dao.fields.FK_RGT_IDA = item("IDA").Text
                        dao.fields.FK_IDA = _IDA
                        dao.fields.REF_TYPE = rdl_ref_type.SelectedValue
                        dao.fields.REQUEST_AT = txt_request_at.Text
                        dao.insert()
                    Else
                        Dim dao As New DAO_DRUG.TB_DRRQT_REFER
                        dao.GetDataby_FKIDA(_IDA)
                        dao.fields.FK_RGT_IDA = item("IDA").Text
                        dao.fields.FK_IDA = _IDA
                        dao.fields.REF_TYPE = rdl_ref_type.SelectedValue
                        dao.fields.REQUEST_AT = txt_request_at.Text
                        dao.update()
                    End If
                Next
            End If
            bind_data()
            alert("บันทึกเรียบร้อย")
        Else
            alert("กรุณากรอกข้อมูลให้ครบ")
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_DRRGT_TRANSFER_BY_IDA(_IDA)
        RadGrid1.DataSource = dt
    End Sub
End Class