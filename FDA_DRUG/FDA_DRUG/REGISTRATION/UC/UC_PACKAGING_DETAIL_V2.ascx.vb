Imports System.Xml
Imports System.Xml.Serialization
Imports FDA_DRUG
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class UC_PACKAGING_DETAIL_V2
    Inherits System.Web.UI.UserControl

    Private _CLS As CLS_SESSION
    Public _process As String
    Private _main_ida As String
    Private main_ida As Integer
    Private _sunit_ida As Integer
    Private _lcn_ida As String
    Private _write_at As String
    Private _phesaj As String
    Private _forother As String
    Private _req As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Dim dao_u As New DAO_DRUG.TB_DRUG_UNIT
        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_rg.GetDataby_IDA(Request.QueryString("IDA"))
        Try
            dao_u.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
            lbl_small_unit.Text = dao_u.fields.unit_name
        Catch ex As Exception

        End Try
        If Not IsPostBack Then
            lbl_sunit_ida.Text = ""
            bind_ddl_unit()
            set_label()
            bind_ddl_txt1()
            If _req <> "" Then
                btn_back.Style.Add("display", "none")
                lbl_head.Text = "ขนาดบรรจุ"
            Else
                lbl_head.Text = "เพิ่ม/ลบขนาดบรรจุสำหรับยาตัวอย่าง"
            End If

            If Request.QueryString("tt") <> "" Then
                btn_add.Visible = False
                btn_eddt.Visible = False
            End If

        End If
    End Sub

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _req = Request.QueryString("req")
                Try
                    _main_ida = Request.QueryString("IDA") 'Request("main_ida").ToString()
                    main_ida = CInt(_main_ida)
                Catch ex As Exception
                End Try
                Try
                    _process = Request("process").ToString()
                Catch ex As Exception
                End Try
                Try
                    _sunit_ida = Request("sunit_ida").ToString()
                Catch ex As Exception
                End Try
                Try
                    _lcn_ida = Request("lcn_ida").ToString()
                Catch ex As Exception

                End Try
                Try
                    _write_at = Request("write_at").ToString()
                Catch ex As Exception

                End Try
                Try
                    _phesaj = Request("phesaj").ToString()
                Catch ex As Exception
                End Try
                Try
                    _forother = Request("forother").ToString()
                Catch ex As Exception
                End Try

            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim cls_session As New CLS_SESSION
        cls_session.IDA = main_ida
        cls_session.PVCODE = "6"
        Session.Add("product_id", cls_session)
        If lbl_sunit_ida.Text = "" Then
            btn_eddt.Visible = False
            btn_edre.Visible = False
            btn_add.Visible = True
        Else
            btn_eddt.Visible = True
            btn_edre.Visible = True
            btn_add.Visible = False
        End If
    End Sub
    Public Sub set_label() 'ดึงข้อมูลแสดง
        Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_drugname.GetDataby_IDA(main_ida)
        Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_package.GetDataby_FK_IDA(dao_drugname.fields.IDA)
        Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT 'ตารางเก็บหน่วยขนาดบรรจุ
        Try
            dao_unit.GetDataby_sunitcd(dao_drugname.fields.UNIT_NORMAL)
            lbl_sunit.Text = dao_unit.fields.unit_name 'หน่วยของขนาดบรรจุ
        Catch ex As Exception
        End Try
    End Sub
    Sub bind_ddl_txt1()
        lbl_munit.Text = ddl_munit.SelectedItem.Text
    End Sub
    Protected Sub ddl_munit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_munit.SelectedIndexChanged
        'lbl_munit.Text = ddl_munit.SelectedItem.Text
        bind_ddl_txt1()
    End Sub

    Private Sub RadGrid80_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid80.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim btn_eddt As LinkButton = CType(item("eddt").Controls(0), LinkButton)
            Dim btn_del As LinkButton = CType(item("del").Controls(0), LinkButton)

           
            If Request.QueryString("tt") <> "" Then
                btn_eddt.Visible = False
                btn_del.Visible = False

            End If


        End If
    End Sub

    Private Sub RadGrid80_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid80.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA_add(main_ida)
        RadGrid80.DataSource = dt

    End Sub
    Public Sub bind_ddl_unit() 'เลือกหน่วยขนาดบรรจุ
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'dt = bao.SP_MAS_UNIT_CONTAIN

        Dim item As New ListItem("-", "0")

        'ddl_munit.DataSource = dt
        'ddl_munit.DataTextField = "unitnm"
        'ddl_munit.DataValueField = "IDA"
        'ddl_munit.DataBind()

        'ddl_bunit.DataSource = dt
        'ddl_bunit.DataTextField = "unitnm"
        'ddl_bunit.DataValueField = "IDA"
        'ddl_bunit.DataBind()


        dt = bao.SP_MASTER_drsunit()
        ddl_bunit.DataSource = dt
        ddl_bunit.DataTextField = "sunitengnm"
        ddl_bunit.DataValueField = "sunitcd"
        ddl_bunit.DataBind()
        'ddl_munit.Items.Insert(0, item)
        ' ddl_bunit.Items.Insert(0, item)

        dt = bao.SP_MASTER_drsunit()
        ddl_munit.DataSource = dt
        ddl_munit.DataTextField = "sunitengnm"
        ddl_munit.DataValueField = "sunitcd"
        ddl_munit.DataBind()
        ' ddl_munit.Items.Insert(0, item)

    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click 'ปุ่มเพิ่มขนาดบรรจุ
        If main_ida = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
        ElseIf txt_packagename.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกชื่อขนาดบรรจุ');", True)
        ElseIf txt_sunit.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_munit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_mamount.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_bunit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_barcode.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกGTIN');", True)
            'ElseIf ddl_snunit.SelectedValue = 0 Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกหน่วยนับตามรูปแบบยา');", True)
        Else
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
            Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_drugname.GetDataby_IDA(main_ida)
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.SMALL_UNIT = dao_drugname.fields.UNIT_NORMAL '_sunit_ida            'เลือกขนาดของหน่วยเล็ก
            Catch ex As Exception
            End Try
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue 'lbl_small_unit.Text  'เลือกขนาดของหน่วยกลาง
            Catch ex As Exception
            End Try
            Try 'ปุ่มเพิ่มขนาดบรรจุ

                dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
            Catch ex As Exception
            End Try


            'End Try
            dao.fields.FK_IDA = dao_drugname.fields.IDA
            dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
            dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
            Try
                dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
            Catch ex As Exception
                dao.fields.MEDIUM_AMOUNT = 1
            End Try

            dao.fields.BIG_AMOUNT = 1
            dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
            dao.fields.DATE_ADD = Date.Now
            Try
                Dim dao_mas_unit1 As New DAO_DRUG.TB_drsunit
                dao_mas_unit1.GetDataby_sunitcd(dao_drugname.fields.UNIT_NORMAL)
                Dim dao_mas_unit As New DAO_DRUG.TB_drsunit
                dao_mas_unit.GetDataby_sunitcd(ddl_munit.SelectedValue)
                Dim dao_mas_unit2 As New DAO_DRUG.TB_drsunit
                dao_mas_unit2.GetDataby_sunitcd(ddl_bunit.SelectedValue)
                Dim sum As Integer = CInt(txt_sunit.Text) * CInt(dao.fields.MEDIUM_AMOUNT)
                sum = sum * CInt(txt_sunit.Text)

                dao.fields.IM_DETAIL = txt_sunit.Text & " " & dao_mas_unit1.fields.sunitthanm & " x " & dao.fields.MEDIUM_AMOUNT & " " & dao_mas_unit.fields.sunitthanm & _
                    " x " & dao.fields.BIG_AMOUNT & " " & dao_mas_unit2.fields.sunitthanm & " จำนวน " & txt_sunit.Text & " " & dao_mas_unit.fields.sunitengnm & " (" & sum & " " & dao_mas_unit1.fields.sunitengnm & ")"
            Catch ex As Exception

            End Try


            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เพิ่มข้อมูลขนาดบรรจุเรียบร้อย');", True)
            RadGrid80.Rebind()
        End If
    End Sub

    Protected Sub btn_eddt_Click(sender As Object, e As EventArgs) Handles btn_eddt.Click 'ปุ่มเพิ่มขนาดบรรจุ
        If main_ida = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกเลขบัญชีรายการยา');", True)
        ElseIf txt_packagename.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกชื่อขนาดบรรจุ');", True)
        ElseIf txt_sunit.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_munit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_mamount.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกจำนวนขนาดบรรจุ');", True)
        ElseIf ddl_bunit.SelectedValue = False Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกขนาดบรรจุ');", True)
        ElseIf txt_barcode.Text = "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกGTIN');", True)
            'ElseIf ddl_snunit.SelectedValue = 0 Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกหน่วยนับตามรูปแบบยา');", True)
        Else
            Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL 'ตารางเก็บขนาดบรรจุ
            dao.GetDataby_IDA(lbl_sunit_ida.Text)
            Dim dao_drugname As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_drugname.GetDataby_IDA(main_ida)
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.SMALL_UNIT = dao_drugname.fields.UNIT_NORMAL '_sunit_ida            'เลือกขนาดของหน่วยเล็ก
            Catch ex As Exception
            End Try
            Try 'ปุ่มเพิ่มขนาดบรรจุ
                dao.fields.MEDIUM_UNIT = ddl_munit.SelectedValue 'lbl_small_unit.Text  'เลือกขนาดของหน่วยกลาง
            Catch ex As Exception
            End Try
            Try 'ปุ่มเพิ่มขนาดบรรจุ

                dao.fields.BIG_UNIT = ddl_bunit.SelectedValue     'เลือกขนาดของหน่วยใหญ่
            Catch ex As Exception
            End Try
            lbl_munit.Text = dao.fields.MEDIUM_UNIT

            'End Try
            dao.fields.FK_IDA = dao_drugname.fields.IDA
            dao.fields.PACKAGE_NAME = txt_packagename.Text 'ชื่อขนาดบรรจุ
            dao.fields.SMALL_AMOUNT = txt_sunit.Text         'จำนวนขนาดบรรจุเล็ก
            Try
                dao.fields.MEDIUM_AMOUNT = txt_mamount.Text        'จำนวนขนาดบรรจุกลาง
            Catch ex As Exception
                dao.fields.MEDIUM_AMOUNT = 1
            End Try

            dao.fields.BIG_AMOUNT = 1
            dao.fields.BARCODE = txt_barcode.Text            'บาร์โค้ดขนาดบรรจุ
            dao.fields.DATE_ADD = Date.Now

            Try
                Dim dao_mas_unit1 As New DAO_DRUG.TB_drsunit
                dao_mas_unit1.GetDataby_sunitcd(dao_drugname.fields.UNIT_NORMAL)
                Dim dao_mas_unit As New DAO_DRUG.TB_drsunit
                dao_mas_unit.GetDataby_sunitcd(ddl_munit.SelectedValue)
                Dim dao_mas_unit2 As New DAO_DRUG.TB_drsunit
                dao_mas_unit2.GetDataby_sunitcd(ddl_bunit.SelectedValue)
                Dim sum As Integer = CInt(txt_sunit.Text) * CInt(dao.fields.MEDIUM_AMOUNT)
                sum = sum * CInt(txt_sunit.Text)

                dao.fields.IM_DETAIL = txt_sunit.Text & " " & dao_mas_unit1.fields.sunitthanm & " x " & dao.fields.MEDIUM_AMOUNT & " " & dao_mas_unit.fields.sunitthanm & _
                    " x " & dao.fields.BIG_AMOUNT & " " & dao_mas_unit2.fields.sunitthanm & " จำนวน " & txt_sunit.Text & " " & dao_mas_unit.fields.sunitengnm & " (" & sum & " " & dao_mas_unit1.fields.sunitengnm & ")"
            Catch ex As Exception

            End Try
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลขนาดบรรจุเรียบร้อย');", True)
            lbl_sunit_ida.Text = ""
            lbl_munit.Text = ""
            txt_barcode.Text = ""
            txt_mamount.Text = ""
            txt_sunit.Text = ""
            txt_packagename.Text = ""
            RunSession()
            bind_ddl_unit()
            set_label()
            RadGrid80.Rebind()

        End If
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url As String = ""
        If _process = "1701" Then
            url = "../DS/FRM_DS_PORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj & "&forother=" & _forother
        ElseIf _process = "1702" Then
            url = "../DS/FRM_DS_NORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        ElseIf _process = "1703" Then
            url = "../DS/FRM_DS_PORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        ElseIf _process = "1704" Then
            url = "../DS/FRM_DS_NORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        ElseIf _process = "1705" Then
            url = "../DS/FRM_DS_PORYOR8(YAVEJAI).aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&write_at=" & _write_at & "&phesaj=" & _phesaj
        End If
        Response.Redirect(url)

    End Sub
    Private Sub RadGrid80_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid80.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                'dao.GetDataAll()
                dao.delete()      'ลบข้อมูลในตารางขนาดบรรจุ
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid80.Rebind()
            ElseIf e.CommandName = "eddt" Then
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao.GetDataby_IDA(item("IDA").Text)
                txt_packagename.Text = dao.fields.PACKAGE_NAME
                txt_sunit.Text = dao.fields.SMALL_AMOUNT
                ddl_munit.SelectedValue = dao.fields.MEDIUM_UNIT
                lbl_munit.Text = ddl_munit.SelectedItem.Text
                Try
                    txt_mamount.Text = dao.fields.MEDIUM_AMOUNT
                Catch ex As Exception
                    txt_mamount.Text = 1
                End Try
                Try
                    ddl_bunit.SelectedValue = dao.fields.BIG_UNIT
                Catch ex As Exception
                End Try
                txt_barcode.Text = dao.fields.BARCODE
                lbl_sunit_ida.Text = item("IDA").Text
                RunSession()
            End If
        End If
    End Sub

    Protected Sub btn_edre_Click(sender As Object, e As EventArgs) Handles btn_edre.Click
        lbl_sunit_ida.Text = ""
        RunSession()
        bind_ddl_unit()
        set_label()

    End Sub
End Class