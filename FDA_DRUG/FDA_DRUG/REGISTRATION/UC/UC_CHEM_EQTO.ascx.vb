Imports Telerik.Web.UI
Public Class UC_CHEM_EQTO
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Dim _main_ida As String
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        _main_ida = Request.QueryString("main_id")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            bind_unit()

            If Request.QueryString("IDA") <> "" Then
                lbl_cas.Text = ""
            End If
            HiddenField1.Value = 0
            hide_show_button()
            If Request.QueryString("tt") <> "" Then
                btn_save_qty.Style.Add("display", "none")
                btn_save_cas.Style.Add("display", "block")
                btn_select.Visible = False
                ddl_remark1.SelectedValue = "3"
                Try
                    Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                    dao_rg.GetDataby_IDA(_main_ida)
                    rcb_unit.SelectedValue = dao_rg.fields.UNIT_NORMAL
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub

    Protected Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        If rcb_unit.SelectedValue <> 0 And txt_QTY.Text <> "" Then

            For Each item As GridDataItem In rg_search_iowa.SelectedItems
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                dao.fields.IOWA = item("iowacd").Text
                dao.fields.QTY = txt_QTY.Text
                dao.fields.SUNITCD = rcb_unit.SelectedValue
                dao.fields.aori = ddl_aori.SelectedValue
                dao.fields.FK_IDA = _IDA
                Try
                    dao.fields.CONDITION = ddl_remark1.SelectedValue
                Catch ex As Exception

                End Try

                Dim dao_max As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                dao_max.GET_MAX_ROWS_ID(_IDA)
                Dim id_max As Integer = 0
                Try
                    id_max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                'Try
                '    dao.fields.MULTIPLY = txt_mulyiply.Text
                'Catch ex As Exception

                'End Try
                'Try
                '    dao.fields.STR_VALUE = txt_str.Text
                'Catch ex As Exception

                'End Try
                dao.fields.ROWS = id_max + 1
                dao.insert()
            Next

        rg_chem.Rebind()
        Else
        alert("กรุณากรอกข้อมูลให้ครบ")
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Private Sub rg_chem_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rg_chem.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
              
                rg_chem.Rebind()
            ElseIf e.CommandName = "_edit" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                dao.GetDataby_IDA(IDA)
                Try
                    ddl_remark1.DropDownSelectData(dao.fields.CONDITION)
                Catch ex As Exception

                End Try
                Try
                    txt_QTY.Text = dao.fields.QTY
                Catch ex As Exception

                End Try
                Try
                    ddl_aori.DropDownSelectData(dao.fields.aori)
                Catch ex As Exception

                End Try
                Try
                    rcb_unit.SelectedValue = dao.fields.SUNITCD
                Catch ex As Exception

                End Try
                HiddenField1.Value = item("IDA").Text
                hide_show_button()
            End If

        End If
    End Sub
    Sub hide_show_button()
        If HiddenField1.Value = "0" Then
            btn_edit.Visible = False
            btn_close_edit.Visible = False
            btn_select.Visible = True
        Else
            btn_edit.Visible = True
            btn_close_edit.Visible = True
            btn_select.Visible = False
        End If
    End Sub

    Public Sub bind_unit()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        rcb_unit.DataSource = dt
        rcb_unit.DataTextField = "sunitnmsht"
        rcb_unit.DataValueField = "sunitcd"
        rcb_unit.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        rcb_unit.Items.Insert(0, item)
    End Sub

    Private Sub rg_chem_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_chem.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
           
            Dim btn_del As LinkButton = CType(item("_del").Controls(0), LinkButton)
            Dim lbl_iowanm As Label = DirectCast(item("iowanm2").FindControl("lbl_iowanm"), Label)
            Dim rcb_iowanm As RadComboBox = DirectCast(item("iowanm2").FindControl("rcb_iowanm"), RadComboBox)
            Dim txt_QTY2 As TextBox = DirectCast(item("QTY").FindControl("txt_QTY2"), TextBox)

            Dim ida_ As String = item("IDA").Text
            Dim dao_tt As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
            dao_tt.GetDataby_IDA(ida_)

            Try
                lbl_iowanm.Text = item("iowanm").Text
            Catch ex As Exception

            End Try
            Try
                If Request.QueryString("tt") <> "" Then
                    txt_QTY2.Enabled = False
                End If
            Catch ex As Exception

            End Try
            If dao_tt.fields.IOWA = "" Then
                rcb_iowanm.Style.Add("display", "block")
                lbl_iowanm.Style.Add("display", "none")
            Else
                rcb_iowanm.Style.Add("display", "none")
                lbl_iowanm.Style.Add("display", "block")
            End If

            Try
                If Request.QueryString("tt") <> "" Then
                    btn_del.Visible = False
                End If
            Catch ex As Exception

            End Try
            Dim lbl_qty As Label = DirectCast(item("QTY").FindControl("lbl_QTY"), Label)
            Dim txt_qtyw As TextBox = DirectCast(item("QTY").FindControl("txt_QTY2"), TextBox)

            If Request.QueryString("tt") <> "" Then
                Try
                    Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                    dao_regis.GetDataby_IDA(dao_tt.fields.FK_REGIST)

                    Dim dao_iowa As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                    dao_iowa.GetDataby_IDA(dao_tt.fields.FK_IDA)
                    Dim dao2 As New DAO_DRUG.TB_15_TAMRAP_EQTO_DDL
                    dao2.Getdata_by_iowa_tamrab_id(dao_iowa.fields.IOWA, dao_regis.fields.DRUG_EQ_TO)
                    rcb_iowanm.DataSource = dao2.datas
                    rcb_iowanm.DataTextField = "IOWANM"
                    rcb_iowanm.DataValueField = "IOWA"
                    rcb_iowanm.DataBind()
                    Dim r3 As New RadComboBoxItem
                    r3.Text = "กรุณาเลือก"
                    r3.Value = 0
                    rcb_iowanm.Items.Insert(0, r3)
                Catch ex As Exception

                End Try

            End If
           
            
            Try
                lbl_qty.Text = dao_tt.fields.QTY
            Catch ex As Exception

            End Try
            Try
                txt_qtyw.Text = dao_tt.fields.QTY
            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Sub rg_chem_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_chem.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable

        dt = bao.SP_DRUG_REGISTRATION_EQTO_BY_FK_IDA(_IDA)
        rg_chem.DataSource = dt
    End Sub
    Private Sub rg_search_iowa_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_search_iowa.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        If txt_search.Text <> "" Then
            dt = bao.SP_DRIOWA_SEARCH_RESULT(txt_search.Text)
        End If

        rg_search_iowa.DataSource = dt
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        rg_search_iowa.Rebind()
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & _main_ida & "&tab=5&tt=" & Request.QueryString("tt"))
    End Sub

    Private Sub btn_close_edit_Click(sender As Object, e As EventArgs) Handles btn_close_edit.Click
        'btn_edit.Style.Add("display", "none")
        'btn_close_edit.Style.Add("display", "none")
        HiddenField1.Value = 0
        hide_show_button()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        If HiddenField1.Value <> 0 Then
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
            dao.GetDataby_IDA(HiddenField1.Value)
            Dim dao_ta As New DAO_DRUG.TB_15_TAMRAP_EQTO
            Try
                Dim dao_rggg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao_rggg.GetDataby_IDA(_IDA)
                dao_ta.GetDataby_TAMRAP_ID_IOWA(dao_rggg.fields.DRUG_EQ_TO, dao.fields.IOWA)
            Catch ex As Exception

            End Try
            If Request.QueryString("tt") <> "" Then
                'Try
                '    ddl_remark1.DropDownSelectData(dao.fields.CONDITION)
                'Catch ex As Exception

                'End Try
                Try
                    dao.fields.QTY = txt_QTY.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.aori = ddl_aori.SelectedValue
                Catch ex As Exception

                End Try
                'Try
                '    dao.fields.SUNITCD = rcb_unit.SelectedValue
                'Catch ex As Exception

                'End Try
                Dim i As Integer = 0
                If dao_ta.fields.val <> 0 Then
                    If dao_ta.fields.CONDITION = 4 Then
                        If txt_QTY.Text < dao_ta.fields.val Then
                            i += 1
                        End If
                    ElseIf dao_ta.fields.CONDITION = 1 Then
                        If txt_QTY.Text > dao_ta.fields.val Then
                            i += 1
                        End If
                    ElseIf dao_ta.fields.CONDITION = 2 Then
                        If txt_QTY.Text > dao_ta.fields.val Then
                            i += 1
                        End If
                    ElseIf dao_ta.fields.CONDITION = 3 Then
                        If txt_QTY.Text > dao_ta.fields.val Or txt_QTY.Text < dao_ta.fields.val Then
                            i += 1
                        End If
                    ElseIf dao_ta.fields.CONDITION = 5 Then
                        If txt_QTY.Text < dao_ta.fields.val Then
                            i += 1
                        End If
                    End If

                End If
                If i = 0 Then
                    dao.update()
                    alert("แก้ไขเรียบร้อยแล้ว")
                    rg_chem.Rebind()
                Else
                    alert("กรอกเงื่อนไขไม่ถูกต้อง")
                End If
            Else
                'Try
                '    ddl_remark1.DropDownSelectData(dao.fields.CONDITION)
                'Catch ex As Exception

                'End Try
                Try
                    txt_QTY.Text = dao.fields.QTY
                Catch ex As Exception

                End Try
                Try
                    ddl_aori.DropDownSelectData(dao.fields.aori)
                Catch ex As Exception

                End Try
                Try
                    rcb_unit.SelectedValue = dao.fields.SUNITCD
                Catch ex As Exception

                End Try
                dao.update()
                alert("แก้ไขเรียบร้อยแล้ว")
                rg_chem.Rebind()
            End If

        End If

    End Sub

    Protected Sub btn_save_qty_Click(sender As Object, e As EventArgs) Handles btn_save_qty.Click
        Dim i As Integer = 0
        For Each item As GridDataItem In rg_chem.Items
            Dim txt_qty2 As TextBox = DirectCast(item("QTY").FindControl("txt_QTY2"), TextBox)
            'Try
            '    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
            '    dao.GetDataby_IDA(item("IDA").Text)
            '    Try
            '        dao.fields.QTY = Trim(txt_qty.Text)
            '    Catch ex As Exception

            '    End Try

            '    dao.update()
            'Catch ex As Exception

            'End Try

            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
            dao.GetDataby_IDA(item("IDA").Text)
            Dim dao_ta As New DAO_DRUG.TB_15_TAMRAP_EQTO
            Try
                Dim dao_rggg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao_rggg.GetDataby_IDA(_main_ida)
                dao_ta.GetDataby_TAMRAP_ID_IOWA(dao_rggg.fields.DRUG_EQ_TO, dao.fields.IOWA)
            Catch ex As Exception

            End Try
            If Request.QueryString("tt") <> "" Then
                'Try
                '    ddl_remark1.DropDownSelectData(dao.fields.CONDITION)
                'Catch ex As Exception

                'End Try
                Try
                    dao.fields.QTY = txt_qty2.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.aori = ddl_aori.SelectedValue
                Catch ex As Exception

                End Try

                'If dao_ta.fields.val <> 0 Then
                '    If dao_ta.fields.CONDITION = 4 Then
                '        If txt_qty2.Text < dao_ta.fields.val Then
                '            i += 1
                '        End If
                '    ElseIf dao_ta.fields.CONDITION = 1 Then
                '        If txt_qty2.Text > dao_ta.fields.val Then
                '            i += 1
                '        End If
                '    ElseIf dao_ta.fields.CONDITION = 2 Then
                '        If txt_qty2.Text > dao_ta.fields.val Then
                '            i += 1
                '        End If
                '    ElseIf dao_ta.fields.CONDITION = 3 Then
                '        If txt_qty2.Text > dao_ta.fields.val Or txt_QTY.Text < dao_ta.fields.val Then
                '            i += 1
                '        End If
                '    ElseIf dao_ta.fields.CONDITION = 5 Then
                '        If txt_qty2.Text < dao_ta.fields.val Then
                '            i += 1
                '        End If
                '    End If

                'End If
                If i = 0 Then
                    dao.update()
                    'alert("แก้ไขเรียบร้อยแล้ว")
                    'rg_chem.Rebind()
                    'Else
                    '    alert("กรอกเงื่อนไขไม่ถูกต้อง")
                End If
            Else
                'Try
                '    ddl_remark1.DropDownSelectData(dao.fields.CONDITION)
                'Catch ex As Exception

                'End Try
                Try
                    dao.fields.QTY = txt_qty2.Text
                Catch ex As Exception

                End Try
                Try
                    ' ddl_aori.DropDownSelectData(dao.fields.aori)
                Catch ex As Exception

                End Try
                'Try
                '    dao.fields.SUNITCD = rcb_unit.SelectedValue
                'Catch ex As Exception

                'End Try
                dao.update()
                'alert("แก้ไขเรียบร้อยแล้ว")
                'rg_chem.Rebind()
            End If
        Next

        If i = 0 Then

            alert("แก้ไขเรียบร้อยแล้ว")
            rg_chem.Rebind()
        Else
            alert("กรอกเงื่อนไขไม่ถูกต้อง")
        End If
    End Sub

    Private Sub btn_save_cas_Click(sender As Object, e As EventArgs) Handles btn_save_cas.Click
        For Each item As GridDataItem In rg_chem.Items
            Dim ida_ As String = item("IDA").Text
            Dim dao_tt As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
            dao_tt.GetDataby_IDA(ida_)
            If dao_tt.fields.IOWA = "" Then
                Dim lbl_iowanm As Label = DirectCast(item("iowanm2").FindControl("lbl_iowanm"), Label)
                Dim rcb_iowanm As RadComboBox = DirectCast(item("iowanm2").FindControl("rcb_iowanm"), RadComboBox)

                If rcb_iowanm.SelectedValue <> 0 Then
                    dao_tt.fields.IOWA = rcb_iowanm.SelectedValue
                    Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                    dao_regis.GetDataby_IDA(_IDA)

                    Dim dao_head As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                    dao_head.GetDataby_IDA(dao_tt.fields.FK_IDA)

                    Dim dao_eqto As New DAO_DRUG.TB_15_TAMRAP_EQTO_DDL
                    dao_eqto.Getdata_by_iowa_tamrab_id(rcb_iowanm.SelectedValue, dao_regis.fields.DRUG_EQ_TO)

                    'dao_tt.update()
                    'Dim dao_eqto_ins As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                    'dao_eqto_ins.GetDataby_IDA(ida_)
                    dao_tt.fields.FK_IDA = _IDA
                    'dao_eqto_ins.fields.FK_SET = dao_tt.fields.FK_SET
                    dao_tt.fields.FK_REGIST = Request.QueryString("main_id")
                    'dao_tt.fields.IOWA = rcb_iowanm.SelectedValue
                    'dao_tt.fields.QTY = dao_eqto.fields.QTY
                    'dao_tt.fields.ROWS = dao_eqto.fields.ROWS
                    dao_tt.fields.SUNITCD = dao_eqto.fields.SUNITCD
                    dao_tt.update()

                End If
            End If

        Next

        Response.Redirect("../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & _main_ida & "&tab=5&tt=" & Request.QueryString("tt"))
        rg_chem.Rebind()
    End Sub
End Class