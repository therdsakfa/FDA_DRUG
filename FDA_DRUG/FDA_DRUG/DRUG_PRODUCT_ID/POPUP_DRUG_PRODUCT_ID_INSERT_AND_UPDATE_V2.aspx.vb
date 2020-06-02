Imports Telerik.Web.UI
Public Class POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2
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
            If Request.QueryString("IDA") <> "" Or Request.QueryString("c") <> "" Then
                bind_ddl_product()
            End If

            bind_ddl_chemecal()
            bind_SP_dactg()
            bind_ddl_unit()
            bind_ddl_atc()
            bind_ddl_small_unit()
            bind_ddl_bio_pack()
            bind_ddl_bio_unit()
            Panel4.Style.Add("display", "none")
            If Request.QueryString("IDA") <> "" Or Request.QueryString("c") <> "" Then

                btn_save.Style.Add("display", "none")
                btn_edit.Style.Add("display", "block")
                Panel1.Style.Add("display", "block")
                Panel2.Style.Add("display", "block")
                Panel3.Style.Add("display", "block")
                'Panel5.Style.Add("display", "block")
            Else
                btn_save.Style.Add("display", "block")
                btn_edit.Style.Add("display", "none")
                Panel1.Style.Add("display", "none")
                Panel2.Style.Add("display", "none")
                Panel3.Style.Add("display", "none")
                'Panel5.Style.Add("display", "none")
            End If

            If Request.QueryString("c") <> "" Then
                Panel4.Style.Add("display", "block")
                bind_all()
            End If

            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                get_data(dao)
                If Request.QueryString("c") <> "" Then
                    If dao.fields.HEAD_PRODUCT_IDA IsNot Nothing Then
                        btn_search.Enabled = False
                        ddl_gr_group.Enabled = False
                        btn_add.Enabled = False
                        btn_add2.Enabled = False
                        'btn_unit_add.Enabled = False
                    End If
                    btn_add.Enabled = False
                End If
                'Txt_TRADE_NAME.Text = dao.fields.TRADE_NAME
                'Txt_TRADE_NAME_ENG.Text = dao.fields.TRADE_NAME_ENG
                If dao.fields.STATUS_ID = 8 Then
                    btn_save.Style.Add("display", "none")
                    btn_edit.Style.Add("display", "none")
                    btn_add.Style.Add("display", "none")
                    btn_add2.Style.Add("display", "none")
                End If
            End If
            set_bio()
        End If
    End Sub
    Sub set_bio()
        If cb_other_unit.Checked Then
            ddl_bio_pack.Enabled = True
            ddl_bio_unit.Enabled = True
        Else
            ddl_bio_pack.Enabled = False
            ddl_bio_unit.Enabled = False
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
        dao.fields.REMARK = txt_REMARK.Text
        If RadioButtonList1.SelectedValue = "True" Then
            dao.fields.IS_BE = True
        Else
            dao.fields.IS_BE = False
        End If
        Try
            'dao.fields.ctgcd = ddl_gr_group.SelectedValue
            dao.fields.ctgcd = rcb_gr_group.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.IS_BIO = cb_other_unit.Checked
        Catch ex As Exception

        End Try
        'dao.fields.IOWACD = ddl_chemecal.SelectedValue
        dao.fields.STRENGTH_DRUG = Txt_DRUG_STR.Text
        dao.fields.TERM_TO_USE = Txt_TERM_TO_USE.Text
        dao.fields.DRUG_NAME_OR_CODE = Txt_DRUG_NAME_OR_CODE.Text
        dao.fields.DRUG_NATURE = Txt_Drug_Nature.Text
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DRUG_PRODUCT_ID)
        Txt_Drug_Nature.Text = dao.fields.DRUG_NATURE
        Txt_TRADE_NAME.Text = dao.fields.TRADE_NAME
        Txt_TRADE_NAME_ENG.Text = dao.fields.TRADE_NAME_ENG
        Try
            If dao.fields.IS_BE = True Then
                RadioButtonList1.SelectedValue = "True"
            ElseIf dao.fields.IS_BE = False Then
                RadioButtonList1.SelectedValue = "False"
            End If
        Catch ex As Exception

        End Try

        Try
            ddl_gr_group.DropDownSelectData(dao.fields.ctgcd)
        Catch ex As Exception

        End Try
        Txt_DRUG_NAME_OR_CODE.Text = dao.fields.DRUG_NAME_OR_CODE
        'dao.fields.IOWACD = ddl_chemecal.SelectedValue
        Txt_DRUG_STR.Text = dao.fields.STRENGTH_DRUG
        Txt_TERM_TO_USE.Text = dao.fields.TERM_TO_USE
        Txt_DRUG_NAME_OR_CODE.Text = dao.fields.DRUG_NAME_OR_CODE
        Try
            ddl_product.DropDownSelectData(dao.fields.HEAD_PRODUCT_IDA)
        Catch ex As Exception

        End Try
        Try
            rcb_gr_group.SelectedValue = dao.fields.ctgcd
        Catch ex As Exception

        End Try
        Try
            cb_other_unit.Checked = dao.fields.IS_BIO
        Catch ex As Exception

        End Try
        Try
            ddl_bio_pack.DropDownSelectData(dao.fields.BIO_PACK)
        Catch ex As Exception

        End Try
        Try
            ddl_bio_unit.DropDownSelectData(dao.fields.BIO_UNIT)
        Catch ex As Exception

        End Try
        txt_REMARK.Text = dao.fields.REMARK
        Try
            rcb_small_unit.SelectedValue = dao.fields.PHYSIC_UNIT
        Catch ex As Exception

        End Try

        Try
            rdl_national.SelectedValue = dao.fields.NATIONAL_TYPE
        Catch ex As Exception

        End Try
    End Sub
    Function Chk_Input_Section1() As String
        Dim str As String = ""
        Dim i As Integer = 0
        If Txt_TRADE_NAME.Text = "" Then
            i += 1
        End If
        If Txt_TRADE_NAME_ENG.Text = "" Then
            i += 1
        End If

        If i = 2 Then
            str = " - ชื่อการค้า"
        End If

        If rcb_gr_group.SelectedValue = "" Then
            'str = " - รูปแบบยา"
            If str <> "" Then
                str &= "\n - รูปแบบยา"
            Else
                str &= " - รูปแบบยา"
            End If
        End If

        If rcb_small_unit.SelectedValue = "" Then
            If str <> "" Then
                str &= "\n - หน่วยนับตามรูปแบบยา"
            Else
                str &= " - หน่วยนับตามรูปแบบยา"
            End If

        End If

        If Txt_Drug_Nature.Text = "" Then
            If str <> "" Then
                str &= "\n - ลักษณะและสีของยา"
            Else
                str &= " - ลักษณะและสีของยา"
            End If
        End If
        Return str
    End Function
    Function Chk_Input_Section2() As String
        Dim str As String = ""
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
        Dim dao2 As New DAO_DRUG.TB_DRUG_PRODUCT_ATC
        Dim bool1 As Boolean = False
        Dim bool2 As Boolean = False
        bool1 = dao.Count_input(Request.QueryString("IDA"))
        bool2 = dao2.Count_input(Request.QueryString("IDA"))
        If bool1 = False Then
            str = " - ตัวยาสำคัญ (INN or Generic Name of Substance)"
        End If
        If bool2 = False Then
            If str <> "" Then
                str &= "\n - กลุ่มตำรับ (ATC)"
            Else
                str &= " - กลุ่มตำรับ (ATC)"
            End If
        End If
        Return str
    End Function
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Chk_Input_Section1() <> "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอก \n" & Chk_Input_Section1() & "');", True)
        Else
            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            set_data(dao)
            Try
                dao.fields.FK_IDA = Request.QueryString("lct_ida")
            Catch ex As Exception

            End Try
            Try
                dao.fields.LCN_IDA = Request.QueryString("lcn_ida")
            Catch ex As Exception

            End Try
            dao.fields.STATUS_ID = 1
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.IDENTIFY = _CLS.CITIZEN_ID
            dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
            dao.fields.PVNCD = _CLS.PVCODE
            dao.fields.ACTIVE = 1
            If RadioButtonList1.SelectedValue = "True" Then
                dao.fields.IS_BE = True
            Else
                dao.fields.IS_BE = False
            End If

            'dao.fields.NATIONAL_TYPE = cb_national.Checked
            Try
                dao.fields.NATIONAL_TYPE = rdl_national.SelectedValue
            Catch ex As Exception

            End Try
            Try
                dao.fields.PHYSIC_UNIT = rcb_small_unit.SelectedValue
            Catch ex As Exception

            End Try

            Try
                If cb_other_unit.Checked Then
                    dao.fields.IS_BIO = True
                    dao.fields.BIO_PACK = ddl_bio_pack.SelectedValue
                    dao.fields.BIO_UNIT = ddl_bio_unit.SelectedValue
                End If
            Catch ex As Exception

            End Try

            If Request.QueryString("c") <> "" Then
                dao.fields.HEAD_PRODUCT_IDA = ddl_product.SelectedValue
            End If

            dao.insert()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri & "&IDA=" & dao.fields.IDA
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
        
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        set_data(dao)
        If RadioButtonList1.SelectedValue = "True" Then
            dao.fields.IS_BE = True
        Else
            dao.fields.IS_BE = False
        End If

        'dao.fields.NATIONAL_TYPE = cb_national.Checked
        Try
            dao.fields.NATIONAL_TYPE = rdl_national.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.PHYSIC_UNIT = rcb_small_unit.SelectedValue
        Catch ex As Exception

        End Try
        Try
            If cb_other_unit.Checked Then
                dao.fields.IS_BIO = True
                dao.fields.BIO_PACK = ddl_bio_pack.SelectedValue
                dao.fields.BIO_UNIT = ddl_bio_unit.SelectedValue
            End If
        Catch ex As Exception

        End Try
        dao.update()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย');", True)
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
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
    Public Sub bind_ddl_chemecal()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_MAS_CHEMICAL_ALL()

        rcb_chemecal.DataSource = dt
        rcb_chemecal.DataBind()

        'ddl_chemecal.DataSource = dt
        'ddl_chemecal.DataBind()
    End Sub
    Public Sub bind_SP_dactg()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_dactg
        dt = bao.SP_dosage_form()

        rcb_gr_group.DataSource = dt
        rcb_gr_group.DataBind()
        ddl_gr_group.DataSource = dt
        ddl_gr_group.DataBind()
    End Sub
    Public Sub bind_ddl_atc()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_ATC_DRUG_ALL
        rcb_atc.DataSource = dt
        rcb_atc.DataBind()
        ddl_atc.DataSource = dt
        ddl_atc.DataBind()
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
        Try
            'dao.fields.IOWACD = ddl_chemecal.SelectedValue
            dao.fields.IOWACD = rcb_chemecal.SelectedValue
        Catch ex As Exception

        End Try

        dao.fields.FK_IDA = Request.QueryString("IDA")
        dao.fields.DOSAGE = Txt_DOSAGE.Text
        'dao.fields.IOWACD = txt_volume.Text
        dao.fields.UNIT_ID = ddl_unit.SelectedValue

        'dao.fields.STRENGTH_DRUG = Txt_STRENGTH_DRUG.Text
        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub
    Public Sub bind_ddl_product()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            bao.SP_DRUG_PRODUCT_ID_BY_FK_IDA2(Request.QueryString("lct_ida"))
        Catch ex As Exception

        End Try

        dt = bao.dt
        ddl_product.DataSource = dt
        ddl_product.DataTextField = "LCNNO_DISPLAY"
        ddl_product.DataValueField = "IDA"
        ddl_product.DataBind()

    End Sub
    Public Sub bind_ddl_small_unit()
        'Dim dao As New DAO_DRUG.TB_DRUG_UNIT
        'dao.GetDataALL()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()

        rcb_small_unit.DataSource = dt
        'rcb_small_unit.DataTextField = "unit_name"
        'rcb_small_unit.DataValueField = "IDA"
        rcb_small_unit.DataBind()
    End Sub

    Public Sub bind_ddl_bio_pack()
        Dim dao As New DAO_DRUG.TB_MAS_BIO_PACK
        dao.GetDataALL()

        ddl_bio_pack.DataSource = dao.datas
        ddl_bio_pack.DataTextField = "BIO_PACK"
        ddl_bio_pack.DataValueField = "IDA"
        ddl_bio_pack.DataBind()
    End Sub
    Public Sub bind_ddl_bio_unit()
        Dim dao As New DAO_DRUG.TB_MAS_BIO_UNIT
        dao.GetDataALL()
        ddl_bio_unit.DataSource = dao.datas
        ddl_bio_unit.DataTextField = "BIO_UNIT"
        ddl_bio_unit.DataValueField = "IDA"
        ddl_bio_unit.DataBind()
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("IDA").Text
            Dim btn_del As LinkButton = DirectCast(item("del").Controls(0), LinkButton)
            If Request.QueryString("c") <> "" Then
                Try
                    btn_del.Style.Add("display", "none")
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub
   
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        If Request.QueryString("c") <> "" Then
            Try
                dt = bao.SP_CDRUG_PRODUCT_IOWA(ddl_product.SelectedValue)
            Catch ex As Exception

            End Try

        Else
            dt = bao.SP_CDRUG_PRODUCT_IOWA(IDA)
        End If
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Private Sub btn_add2_Click(sender As Object, e As EventArgs) Handles btn_add2.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ATC
        Try
            'dao.fields.ATC_IDA = ddl_atc.SelectedValue
            dao.fields.ATC_CODE = rcb_atc.SelectedValue
        Catch ex As Exception

        End Try

        dao.fields.FK_IDA = Request.QueryString("IDA")

        dao.insert()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ATC
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid2.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim id As Integer = item("IDA").Text
            'Dim btn_del As LinkButton = DirectCast(item("del").Controls(0), LinkButton)
            'If Request.QueryString("c") <> "" Then
            '    Try
            '        btn_del.Style.Add("display", "none")
            '    Catch ex As Exception

            '    End Try

            'End If

        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        If Request.QueryString("c") <> "" Then
            dt = bao.SP_DRUG_PRODUCT_ATC(ddl_product.SelectedValue)
        Else
            dt = bao.SP_DRUG_PRODUCT_ATC(IDA)
        End If

        RadGrid2.DataSource = dt
    End Sub

    Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        If Chk_Input_Section2() <> "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอก \n" & Chk_Input_Section2() & "');", True)
        Else
            Dim url As String = "../DRUG_PRODUCT_ID/POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2_NEXT.aspx?IDA=" & Request.QueryString("IDA") & "&lct_ida=" & Request.QueryString("lct_ida")
            If Request.QueryString("c") <> "" Then
                url &= "&c=1" '&id_head=" & ddl_product.SelectedValue
            End If
            Response.Redirect(url)
        End If

       
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        set_data(dao)
        dao.fields.FK_IDA = Request.QueryString("lct_ida")
        dao.fields.STATUS_ID = 1
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.PVNCD = _CLS.PVCODE
        dao.fields.ACTIVE = 1
        'dao.fields.NATIONAL_TYPE = cb_national.Checked

        Try
            dao.fields.NATIONAL_TYPE = rdl_national.SelectedValue
        Catch ex As Exception

        End Try
        If Request.QueryString("c") <> "" Then
            dao.fields.HEAD_PRODUCT_IDA = ddl_product.SelectedValue

            Dim dao_head As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao_head.GetDataby_IDA(ddl_product.SelectedValue)
            'dao.fields.PHYSIC_UNIT = dao_head.fields.PHYSIC_UNIT
            'dao.fields.BIO_PACK = dao_head.fields.BIO_PACK
            'dao.fields.BIO_UNIT = dao_head.fields.BIO_UNIT
            dao.fields.LCN_IDA = dao_head.fields.LCN_IDA
        End If

        dao.insert()

        Dim dao_d1 As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
        dao_d1.GetDataby_FK_IDA(ddl_product.SelectedValue)
        For Each dao_d1.fields In dao_d1.datas
            Dim dao_i As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
            dao_i.fields.FK_IDA = dao.fields.IDA
            dao_i.fields.IOWACD = dao_d1.fields.IOWACD
            dao_i.fields.DOSAGE = dao_d1.fields.DOSAGE
            dao_i.fields.UNIT_ID = dao_d1.fields.UNIT_ID
            dao_i.insert()
        Next

        Dim dao_d2 As New DAO_DRUG.TB_DRUG_PRODUCT_ATC
        dao_d2.GetDataby_FK_IDA(ddl_product.SelectedValue)
        For Each dao_d2.fields In dao_d2.datas
            Dim dao_i As New DAO_DRUG.TB_DRUG_PRODUCT_ATC
            dao_i.fields.ATC_IDA = dao_d2.fields.ATC_IDA
            dao_i.fields.FK_IDA = dao.fields.IDA
            dao_i.insert()
        Next

        Dim dao_d3 As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
        dao_d3.GetDataby_FK_IDA(ddl_product.SelectedValue)
        For Each dao_d3.fields In dao_d3.datas
            Dim dao_i As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
            With dao_i.fields
                .amphrcd1 = dao_d3.fields.amphrcd1
                .amphrcd2 = dao_d3.fields.amphrcd2
                .amphrcd3 = dao_d3.fields.amphrcd3
                .chngwtcd1 = dao_d3.fields.chngwtcd1
                .chngwtcd2 = dao_d3.fields.chngwtcd2
                .chngwtcd3 = dao_d3.fields.chngwtcd3
                .thmblcd1 = dao_d3.fields.thmblcd1
                .thmblcd2 = dao_d3.fields.thmblcd2
                .thmblcd3 = dao_d3.fields.thmblcd3
                .tel1 = dao_d3.fields.tel1
                .tel2 = dao_d3.fields.tel2
                .tel3 = dao_d3.fields.tel3
                .thaaddr1 = dao_d3.fields.thaaddr1
                .thaaddr2 = dao_d3.fields.thaaddr2
                .thaaddr3 = dao_d3.fields.thaaddr3
                '-----------------------
                .thaamphrnm1 = dao_d3.fields.thaamphrnm1
                .thaamphrnm2 = dao_d3.fields.thaamphrnm2
                .thaamphrnm3 = dao_d3.fields.thaamphrnm3
                .thachngwtnm1 = dao_d3.fields.thachngwtnm1
                .thachngwtnm2 = dao_d3.fields.thachngwtnm2
                .thachngwtnm3 = dao_d3.fields.thachngwtnm3
                .thathmblnm1 = dao_d3.fields.thathmblnm1
                .thathmblnm2 = dao_d3.fields.thathmblnm2
                .thathmblnm3 = dao_d3.fields.thathmblnm3
                '-------------------------
                .thamu1 = dao_d3.fields.thamu1
                .thamu2 = dao_d3.fields.thamu2
                .thamu3 = dao_d3.fields.thamu3
                .thanameplace1 = dao_d3.fields.thanameplace1
                .thanameplace2 = dao_d3.fields.thanameplace2
                .thanameplace3 = dao_d3.fields.thanameplace3
                .zipcode1 = dao_d3.fields.zipcode1
                .zipcode2 = dao_d3.fields.zipcode2
                .zipcode3 = dao_d3.fields.zipcode3
                .thasoi1 = dao_d3.fields.thasoi1
                .thasoi2 = dao_d3.fields.thasoi2
                .thasoi3 = dao_d3.fields.thasoi3
                .tharoad1 = dao_d3.fields.tharoad1
                .tharoad2 = dao_d3.fields.tharoad2
                .tharoad3 = dao_d3.fields.tharoad3
                .FK_IDA = dao.fields.IDA

                .FRGN_CITY_NAME = dao_d3.fields.FRGN_CITY_NAME
                .FRGN_FULLADDR = dao_d3.fields.FRGN_FULLADDR
                .FRGN_NAME = dao_d3.fields.FRGN_NAME
                .FRGN_ZIPCODE = dao_d3.fields.FRGN_ZIPCODE
                Try
                    .NATIONAL_CD = dao_d3.fields.NATIONAL_CD
                Catch ex As Exception

                End Try

            End With

            dao_i.insert()
        Next


    End Sub

    Private Sub ddl_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_product.SelectedIndexChanged
        bind_all()
    End Sub
    Sub bind_all()
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        Try
            dao.GetDataby_IDA(ddl_product.SelectedValue)
        Catch ex As Exception

        End Try

        get_data(dao)
        RadGrid1.Rebind()
        RadGrid2.Rebind()
        'RadGrid3.Rebind()
    End Sub

    'Private Sub RadGrid3_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid3.ItemCommand
    '    If TypeOf e.Item Is GridDataItem Then
    '        Dim item As GridDataItem = e.Item
    '        If e.CommandName = "del" Then
    '            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID_UNIT_DETAIL
    '            dao.GetDataby_IDA(item("IDA").Text)
    '            dao.delete()
    '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
    '            RadGrid3.Rebind()
    '        End If
    '    End If
    'End Sub

    
    'Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    'dt  =bao.SP_DRUG_PRODUCT_ID_UNIT_DETAIL(Request.QueryString("IDA")


    '    Dim IDA As Integer = 0
    '    Try
    '        IDA = Request.QueryString("IDA")
    '    Catch ex As Exception

    '    End Try
    '    If Request.QueryString("c") <> "" Then
    '        Try
    '            dt = bao.SP_DRUG_PRODUCT_ID_UNIT_DETAIL(ddl_product.SelectedValue)
    '        Catch ex As Exception

    '        End Try

    '    Else
    '        dt = bao.SP_DRUG_PRODUCT_ID_UNIT_DETAIL(IDA)
    '    End If
    'End Sub

    'Private Sub btn_unit_add_Click(sender As Object, e As EventArgs) Handles btn_unit_add.Click
    '    Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID_UNIT_DETAIL
    '    dao.fields.AMOUNT = txt_amount.Text
    '    Try
    '        'dao.fields.FIRST_UNIT = ddl_first_unit.SelectedValue
    '        dao.fields.FIRST_UNIT = rcb_first_unit.SelectedValue
    '    Catch ex As Exception

    '    End Try

    '    Try
    '        dao.fields.FK_IDA = Request.QueryString("IDA")
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        'dao.fields.SMALL_UNIT = ddl_small_unit.SelectedValue
    '        dao.fields.SMALL_UNIT = rcb_small_unit.SelectedValue
    '    Catch ex As Exception

    '    End Try

    '    dao.insert()

    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
    '    RadGrid3.Rebind()
    'End Sub

    Private Sub cb_other_unit_CheckedChanged(sender As Object, e As EventArgs) Handles cb_other_unit.CheckedChanged
        set_bio()
    End Sub
End Class