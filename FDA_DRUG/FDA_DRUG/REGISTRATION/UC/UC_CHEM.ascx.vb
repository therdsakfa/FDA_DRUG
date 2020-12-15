Imports System.IO
Imports System.Xml.Serialization
Imports System.Globalization
Imports System.Xml
Imports Telerik.Web.UI
Public Class UC_CHEM
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()

        If Not IsPostBack Then
            bind_lbl()
            set_hide()
            If Request.QueryString("tt") <> "" Then
                btn_save.Visible = False
                btn_select.Visible = False

                btn_save_qty.Visible = False

                Try
                    Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                    dao_rg.GetDataby_IDA(_IDA)
                    ddl_unit.DropDownSelectData(dao_rg.fields.UNIT_NORMAL)
                    rcb_unit.SelectedValue = dao_rg.fields.UNIT_NORMAL
                Catch ex As Exception

                End Try
            End If

            Try
                Dim i As Integer = 0
                Dim dao_tt As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                i = dao_tt.Count_IOWA_NULL_Databy_FK_IDA(_IDA)
                If i > 0 Then
                    btn_save_cas.Style.Add("display", "block")
                Else
                    btn_save_cas.Style.Add("display", "none")
                End If



            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub rg_chem_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_chem.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                If Request.QueryString("tt") <> "" Then
                    alert("ไม่สามารถลบข้อมูลได้")
                Else
                    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                    rg_chem.Rebind()
                End If
            ElseIf e.CommandName = "_eqto" Then
                Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao_regis.GetDataby_IDA(_IDA)
                If Request.QueryString("tt") <> "" Then
                    Response.Redirect("../REGISTRATION/FRM_REGISTRATION_EQTO.aspx?IDA=" & IDA & "&req=1" & "&main_id=" & _IDA & "&tt=" & dao_regis.fields.DRUG_EQ_TO)
                Else
                    Response.Redirect("../REGISTRATION/FRM_REGISTRATION_EQTO.aspx?IDA=" & IDA & "&req=1" & "&main_id=" & _IDA)
                End If

                '& "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id"))
            End If

        End If
    End Sub

    Private Sub rg_chem_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rg_chem.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim lbl_iowanm As Label = DirectCast(item("iowanm").FindControl("lbl_iowanm"), Label)
            Dim rcb_iowanm As RadComboBox = DirectCast(item("iowanm").FindControl("rcb_iowanm"), RadComboBox)
            Dim lbl_rows As Label = DirectCast(item("ROWS").FindControl("lbl_rows"), Label)
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)

            ' Dim btn_del As RadComboBox = DirectCast(item("_del").FindControl("rcb_iowanm"), RadComboBox)
            Dim btn_del As LinkButton = CType(item("_del").Controls(0), LinkButton)
            Dim btn_eqto As LinkButton = CType(item("_eqto").Controls(0), LinkButton)
            Dim txt_QTY2 As TextBox = DirectCast(item("QTY").FindControl("txt_QTY2"), TextBox)
            Try
                If Request.QueryString("tt") <> "" Then
                    btn_del.Visible = False

                End If
            Catch ex As Exception

            End Try
            Try
                If Request.QueryString("tt") <> "" Then
                    txt_QTY2.Enabled = False
                End If
            Catch ex As Exception

            End Try
            Dim lbl_qty As Label = DirectCast(item("QTY").FindControl("lbl_QTY"), Label)
            Dim txt_qtys As TextBox = DirectCast(item("QTY").FindControl("txt_QTY2"), TextBox)

            Dim ida_ As String = item("IDA").Text
            Dim dao_tt As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
            dao_tt.GetDataby_IDA(ida_)
            
            Try
                lbl_iowanm.Text = item("iowanm").Text
            Catch ex As Exception

            End Try
            'If dao_tt.fields.IOWA = "" Then
            '    rcb_iowanm.Style.Add("display", "block")
            '    lbl_iowanm.Style.Add("display", "none")
            'Else
            '    rcb_iowanm.Style.Add("display", "none")
            '    lbl_iowanm.Style.Add("display", "block")
            'End If


            If Request.QueryString("tt") <> "" Then
                Try
                    Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                    dao_regis.GetDataby_IDA(_IDA)
                    Dim dao2 As New DAO_DRUG.TB_15_TAMRAP_IOWA_DDL
                    dao2.Getdata_by_TAMRAP_ID(dao_regis.fields.DRUG_EQ_TO)
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

                Try
                    Dim dao_eqto As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                    dao_eqto.GetDataby_FK_IDA(ida_)
                    If dao_eqto.fields.IOWA <> "" Then
                        btn_eqto.Style.Add("display", "none")
                    End If


                Catch ex As Exception

                End Try
                Try
                    Dim dao_eqto As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                    dao_eqto.GetDataby_FK_IDA(ida_)
                    If dao_eqto.fields.IDA = 0 Then
                        btn_eqto.Style.Add("display", "none")
                    End If


                Catch ex As Exception

                End Try
                Try
                    If dao_tt.fields.IOWA = "" Then
                        btn_eqto.Style.Add("display", "none")
                    End If
                Catch ex As Exception

                End Try
            End If
            Try
                txt_rows.Text = dao_tt.fields.ROWS

            Catch ex As Exception

            End Try
            Try
                lbl_qty.Text = dao_tt.fields.QTY
            Catch ex As Exception

            End Try
            Try
                txt_qtys.Text = dao_tt.fields.QTY
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub rg_chem_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_chem.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V3(_IDA)
        rg_chem.DataSource = dt
    End Sub
    Public Sub get_data_head()
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA)
        Try
            'txt_quantity.Text = dao.fields.
        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_unit_each()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit.DataSource = dt
        'ddl_unit.DataTextField = "sunitnmsht"
        'ddl_unit.DataValueField = "sunitcd"
        'ddl_unit.DataBind()


        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        ddl_unit.DataSource = dt
        ddl_unit.DataTextField = "unit_name"
        ddl_unit.DataValueField = "sunitcd"
        ddl_unit.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit.DataSource = dt
        'ddl_unit.DataTextField = "sunitnmsht"
        'ddl_unit.DataValueField = "sunitcd"
        'ddl_unit.DataBind()


        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        rcb_unit.DataSource = dt
        rcb_unit.DataTextField = "unit_name"
        rcb_unit.DataValueField = "sunitcd"
        rcb_unit.DataBind()

        Dim r3 As New RadComboBoxItem
        r3.Text = "กรุณาเลือก"
        r3.Value = 0
        rcb_unit.Items.Insert(0, r3)
        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit2()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit.DataSource = dt
        'ddl_unit.DataTextField = "sunitnmsht"
        'ddl_unit.DataValueField = "sunitcd"
        'ddl_unit.DataBind()


        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        rcb_unit2.DataSource = dt
        rcb_unit2.DataTextField = "unit_name"
        rcb_unit2.DataValueField = "sunitcd"
        rcb_unit2.DataBind()

        Dim r3 As New RadComboBoxItem
        r3.Text = "กรุณาเลือก"
        r3.Value = 0
        rcb_unit2.Items.Insert(0, r3)
        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit3()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit2.DataSource = dt
        ddl_unit2.DataTextField = "sunitnmsht"
        ddl_unit2.DataValueField = "sunitcd"
        ddl_unit2.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit2.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit4()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_drsunit()

        ddl_unit3.DataSource = dt
        ddl_unit3.DataTextField = "sunitnmsht"
        ddl_unit3.DataValueField = "sunitcd"
        ddl_unit3.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_unit3.Items.Insert(0, item)
    End Sub
    Public Sub bind_unit_head()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_MASTER_drsunit()

        'ddl_unit_head.DataSource = dt
        'ddl_unit_head.DataTextField = "sunitnmsht"
        'ddl_unit_head.DataValueField = "sunitcd"
        'ddl_unit_head.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_unit_head.Items.Insert(0, item)
    End Sub
    Private Sub ddl_CAS_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CAS_TYPE.SelectedIndexChanged
        set_hide()
    End Sub

    Sub set_hide()
        Dim cas_type As Integer = ddl_CAS_TYPE.SelectedValue
        If cas_type = 1 Then
            txt_QTY.Enabled = True
            ddl_unit.Enabled = True
            ddl_remark1.Enabled = True

            txt_sbioqty.Enabled = False
            ddl_unit2.Enabled = False
            txt_sbiosqno.Enabled = False
            txt_ebioqty.Enabled = False
            ddl_unit3.Enabled = False
            txt_ebiosqno.Enabled = False
        Else
            txt_QTY.Enabled = False
            ddl_unit.Enabled = False
            ddl_remark1.Enabled = False

            txt_sbioqty.Enabled = True
            ddl_unit2.Enabled = True
            txt_sbiosqno.Enabled = True
            txt_ebioqty.Enabled = True
            ddl_unit3.Enabled = True
            txt_ebiosqno.Enabled = True
        End If
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

    Protected Sub btn_select_Click(sender As Object, e As EventArgs) Handles btn_select.Click
        If rcb_unit.SelectedValue <> "" And txt_QTY.Text <> "" Then
            For Each item As GridDataItem In rg_search_iowa.SelectedItems
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                dao.fields.ROWS = txt_ROWS.Text
                dao.fields.IOWACD = item("iowacd").Text
                dao.fields.IOWA = item("iowacd").Text
                dao.fields.QTY = txt_QTY.Text
                dao.fields.QTY2 = txt_QTY2.Text
                dao.fields.AORI = ddl_aori.SelectedItem.Text
                dao.fields.FK_SET = ddl_set.SelectedValue
                Try
                    dao.fields.SUNITCD = rcb_unit.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.SUNITCD2 = rcb_unit2.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbioqty = txt_sbioqty.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbiosqno = txt_sbiosqno.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.sbiounitcd = ddl_unit2.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ebioqty = txt_ebioqty.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ebiosqno = txt_ebiosqno.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ebiounitcd = ddl_unit3.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    dao.fields.REF = txt_ref.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.REMARK = txt_remark.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CONDITION = ddl_remark1.SelectedItem.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CAS_TYPE = ddl_CAS_TYPE.SelectedValue
                Catch ex As Exception

                End Try

                dao.fields.FK_IDA = _IDA
                Dim dao_max As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                dao_max.GET_MAX_ROWS_ID(_IDA)
                Dim id_max As Integer = 0
                Try
                    id_max = dao_max.fields.ROWS
                Catch ex As Exception

                End Try
                dao.fields.ROWS = id_max + 1
                dao.insert()
            Next
            rg_chem.Rebind()
        Else
            alert("กรุณากรอกข้อมูลให้ครบ")
        End If

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_count As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
        Dim i As Integer = 0
        i = dao_count.CountDataby_FK_IDA(Request.QueryString("IDA"))
        If i = 0 Then
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
            dao.fields.EACH_AMOUNT = txt_each.Text
            dao.fields.FK_IDA = Request.QueryString("IDA")
            dao.fields.sunitcd = ddl_unit.SelectedValue
            dao.fields.FK_SET = ddl_set_each.SelectedValue
            dao.fields.EACH_TXT = txt_each_txt.Text
            dao.insert()

        Else
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            dao.fields.EACH_AMOUNT = txt_each.Text
            dao.fields.sunitcd = ddl_unit.SelectedValue
            dao.fields.FK_SET = ddl_set_each.SelectedValue
            dao.fields.EACH_TXT = txt_each_txt.Text
            dao.update()
        End If
        alert("บันทึกเรียบร้อย")
        bind_lbl()
    End Sub
    Sub bind_lbl()
        Try
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            If IsNothing(dao.fields.EACH_TXT) = False Or dao.fields.EACH_TXT <> "" Then
                lbl_each.Text = "Each " & dao.fields.EACH_TXT & " Contains;"
            Else
                Dim dao_u As New DAO_DRUG.TB_DRUG_UNIT
                dao_u.GetDataby_sunitcd(dao.fields.sunitcd)
                lbl_each.Text = "Each " & dao.fields.EACH_AMOUNT & " " & dao_u.fields.unit_name & " Contains;"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_save_cas_Click(sender As Object, e As EventArgs) Handles btn_save_cas.Click
        For Each item As GridDataItem In rg_chem.Items
            Dim ida_ As String = item("IDA").Text
            Dim dao_tt As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
            dao_tt.GetDataby_IDA(ida_)
            If dao_tt.fields.IOWA = "" Then
                Dim lbl_iowanm As Label = DirectCast(item("iowanm2").FindControl("lbl_iowanm"), Label)
                Dim rcb_iowanm As RadComboBox = DirectCast(item("iowanm2").FindControl("rcb_iowanm"), RadComboBox)

                If rcb_iowanm.SelectedValue <> 0 Then
                    dao_tt.fields.IOWA = rcb_iowanm.SelectedValue
                    Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                    dao_regis.GetDataby_IDA(_IDA)

                    Dim dao_eqto As New DAO_DRUG.TB_15_TAMRAP_EQTO_DDL
                    dao_eqto.Getdata_by_iowa_tamrab_id(rcb_iowanm.SelectedValue, dao_regis.fields.DRUG_EQ_TO)

                    dao_tt.update()
                    Dim dao_eqto_ins As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                    dao_eqto_ins.fields.FK_IDA = ida_
                    dao_eqto_ins.fields.FK_SET = dao_tt.fields.FK_SET
                    dao_eqto_ins.fields.FK_REGIST = _IDA
                    dao_eqto_ins.fields.IOWA = dao_eqto.fields.IOWA
                    dao_eqto_ins.fields.QTY = dao_eqto.fields.QTY
                    dao_eqto_ins.fields.ROWS = dao_eqto.fields.ROWS
                    dao_eqto_ins.fields.SUNITCD = dao_eqto.fields.SUNITCD
                    dao_eqto_ins.insert()

                End If
            End If

        Next
        rg_chem.Rebind()
    End Sub

    Private Sub btn_save_qty_Click(sender As Object, e As EventArgs) Handles btn_save_qty.Click
        For Each item As GridDataItem In rg_chem.Items
            Dim txt_rows As TextBox = DirectCast(item("ROWS").FindControl("txt_rows"), TextBox)
            Try
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                dao.GetDataby_IDA(item("IDA").Text)
                Try
                    dao.fields.ROWS = Trim(txt_rows.Text)
                Catch ex As Exception

                End Try

                dao.update()
            Catch ex As Exception

            End Try
        Next
    End Sub
End Class