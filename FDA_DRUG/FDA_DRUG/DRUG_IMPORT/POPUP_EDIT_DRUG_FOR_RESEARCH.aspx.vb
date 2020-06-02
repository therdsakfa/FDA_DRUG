Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_EDIT_DRUG_FOR_RESEARCH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Private _IDA As String

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        _IDA = Request.QueryString("IDA")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        RunSession()
        If Not IsPostBack Then
            binddata()
        End If
    End Sub

    Sub binddata()

        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao.GetDataby_IDA(_IDA)

        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_UNIT_CONTAIN()

        Dim dao_u As New DAO_DRUG.TB_DRUG_UNIT
        dao_u.GetDataALL()

        Dim item As New ListItem("", "0")

        ddl_sunit.DataSource = dao_u.datas
        ddl_sunit.DataTextField = "unit_name"
        ddl_sunit.DataValueField = "IDA"
        ddl_sunit.DataBind()

        ddl_munit.DataSource = dt
        ddl_munit.DataTextField = "unitnm"
        ddl_munit.DataValueField = "unitcd2"
        ddl_munit.DataBind()

        ddl_bunit.DataSource = dt
        ddl_bunit.DataTextField = "unitnm"
        ddl_bunit.DataValueField = "unitcd2"
        ddl_bunit.DataBind()

        ddl_sunit.Items.Insert(0, item)
        ddl_munit.Items.Insert(0, item)
        ddl_bunit.Items.Insert(0, item)
        ddl_sunit.SelectedValue = dao.fields.sunitcd
        ddl_munit.SelectedValue = dao.fields.munitcd
        ddl_bunit.SelectedValue = dao.fields.bunitcd

        TextBox1.Text = dao.fields.tradenm
        TextBox2.Text = dao.fields.commonnm
        TextBox3.Text = dao.fields.drug_code
        TextBox4.Text = dao.fields.drug_format
        TextBox5.Text = dao.fields.strengh
        TextBox6.Text = dao.fields.Washout_Period
        TextBox7.Text = dao.fields.othernm
        If dao.fields.typecd = 1 Then
            rb_drtype1.Checked = True
        ElseIf dao.fields.typecd = 2 Then
            rb_drtype2.Checked = True
        ElseIf dao.fields.typecd = 3 Then
            rb_drtype3.Checked = True
        ElseIf dao.fields.typecd = 4 Then
            rb_drtype4.Checked = True
        ElseIf dao.fields.typecd = 5 Then
            rb_drtype5.Checked = True
            TextBox9.Text = dao.fields.type_descript
        End If
        txt_size1.Text = dao.fields.sunit
        txt_size3.Text = dao.fields.munit
        txt_package_name.Text = dao.fields.packnm
        txt_barcode.Text = dao.fields.pack_barcode
        TextBox8.Text = dao.fields.imp_amount
        lbl_bunit.Text = dao.fields.bunitnm

        Dim dao_active As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_ACTIVE_INGREDIENTS
        dao_active.GetDataby_DRUG(_IDA)

        For Each dao_active.fields In dao_active.datas
            If lbl_activelist.Text = "" Then
                lbl_activelist.Text = "<h3>รายชื่อตัวยาสำคัญ</h3>" & dao_active.fields.IOWANM & " ขนาด " & dao_active.fields.DOSAGE & Space(1) & dao_active.fields.UNIT_NM
            Else
                lbl_activelist.Text = lbl_activelist.Text & "<br>" & dao_active.fields.IOWANM & " ขนาด " & dao_active.fields.DOSAGE & Space(1) & dao_active.fields.UNIT_NM
            End If
        Next

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    Protected Sub ddl_munit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_munit.SelectedIndexChanged
        lbl_size_m.Text = ddl_munit.SelectedItem.Text
    End Sub

    Protected Sub ddl_bunit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bunit.SelectedIndexChanged
        lbl_bunit.Text = ddl_bunit.SelectedItem.Text
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'ใส่ validation
        save()
        alert("ทำการเพิ่มเรียบร้อย")
    End Sub

    Sub save()
        Dim dao2 As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao2.GetDataby_IDA(_IDA)
        Dim n As Integer = 0
        Try
            n = dao2.fields.modified_times + 1
        Catch ex As Exception
            n = 1
        End Try

        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao.fields.tradenm = TextBox1.Text
        dao.fields.commonnm = TextBox2.Text
        dao.fields.othernm = TextBox7.Text
        dao.fields.drug_code = TextBox3.Text
        dao.fields.drug_format = TextBox4.Text
        dao.fields.strengh = TextBox5.Text
        dao.fields.Washout_Period = TextBox6.Text
        If rb_drtype1.Checked = True Then
            dao.fields.typecd = 1
        ElseIf rb_drtype2.Checked = True Then
            dao.fields.typecd = 2
        ElseIf rb_drtype3.Checked = True Then
            dao.fields.typecd = 3
        ElseIf rb_drtype4.Checked = True Then
            dao.fields.typecd = 4
        ElseIf rb_drtype5.Checked = True Then
            dao.fields.typecd = 5
            dao.fields.type_descript = TextBox9.Text
        End If
        dao.fields.sunit = txt_size1.Text
        dao.fields.sunitnm = ddl_sunit.SelectedItem.Text
        dao.fields.sunitcd = ddl_sunit.SelectedValue
        dao.fields.munit = txt_size1.Text
        dao.fields.munitnm = ddl_munit.SelectedItem.Text
        dao.fields.munitcd = ddl_munit.SelectedValue
        dao.fields.bunit = txt_size1.Text
        dao.fields.bunitnm = ddl_bunit.SelectedItem.Text
        dao.fields.bunitcd = ddl_bunit.SelectedValue
        dao.fields.packnm = txt_package_name.Text
        dao.fields.pack_barcode = txt_barcode.Text
        dao.fields.imp_amount = TextBox8.Text
        dao.fields.is_lastest = 1
        dao.fields.modified_from = dao2.fields.IDA
        dao.fields.modified_times = n
        dao.fields.ciziten_submit = _CLS.CITIZEN_ID
        dao.fields.citizen_autho = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.create_date = Date.Now
        dao.insert()

        dao2.fields.is_lastest = 0
        dao2.update()
    End Sub
End Class