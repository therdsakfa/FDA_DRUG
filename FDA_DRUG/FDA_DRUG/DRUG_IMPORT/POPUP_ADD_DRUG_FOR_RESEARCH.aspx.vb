Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_ADD_DRUG_FOR_RESEARCH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Private table As DataTable
    Sub runQuery()
        _Process = "10261"
    End Sub
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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        runQuery()
        RunSession()
        If Not IsPostBack Then
            bind_ddl()
        End If
    End Sub

    Sub bind_ddl()

        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MAS_UNIT_CONTAIN()

        Dim dao As New DAO_DRUG.TB_DRUG_UNIT
        dao.GetDataALL()

        Dim item As New ListItem("", "0")

        ddl_sunit.DataSource = dao.datas
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

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
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
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Then
            alert("กรุณากรอกข้อมูลให้ครบ")
        Else
            If rb_drtype1.Checked = False And rb_drtype2.Checked = False And rb_drtype3.Checked = False And rb_drtype4.Checked = False And rb_drtype5.Checked = False Then
                alert("กรุณาประเภทยาวิจัย")
            Else
                If lbl_activelist.Text = "" Then
                    alert("กรุณาเพิ่มตัวยาสำคัญ")
                Else
                    save()
                    alert("ทำการเพิ่มเรียบร้อย")
                End If
            End If
        End If
    End Sub

    Sub save()
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
            dao.fields.typenm = rb_drtype1.Text
        ElseIf rb_drtype2.Checked = True Then
            dao.fields.typecd = 2
            dao.fields.typenm = rb_drtype2.Text
        ElseIf rb_drtype3.Checked = True Then
            dao.fields.typecd = 3
            dao.fields.typenm = rb_drtype3.Text
        ElseIf rb_drtype4.Checked = True Then
            dao.fields.typecd = 4
            dao.fields.typenm = rb_drtype4.Text
        ElseIf rb_drtype5.Checked = True Then
            dao.fields.typecd = 5
            dao.fields.typenm = rb_drtype5.Text
            dao.fields.type_descript = TextBox9.Text
        End If
        dao.fields.sunit = txt_size1.Text
        dao.fields.sunitnm = ddl_sunit.SelectedItem.Text
        dao.fields.sunitcd = ddl_sunit.SelectedValue
        dao.fields.munit = txt_size3.Text
        dao.fields.munitnm = ddl_munit.SelectedItem.Text
        dao.fields.munitcd = ddl_munit.SelectedValue
        dao.fields.bunit = "1"
        dao.fields.bunitnm = ddl_bunit.SelectedItem.Text
        dao.fields.bunitcd = ddl_bunit.SelectedValue
        dao.fields.packnm = txt_package_name.Text
        dao.fields.pack_barcode = txt_barcode.Text
        dao.fields.imp_amount = TextBox8.Text
        dao.fields.is_lastest = 1
        dao.fields.ciziten_submit = _CLS.CITIZEN_ID
        dao.fields.citizen_autho = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.create_date = Date.Now
        Dim bao As New BAO.GenNumber
        Dim rcvno As String = bao.GEN_NO_06(con_year(Date.Now.Year()), _CLS.PVCODE, _Process, _CLS.LCNNO, "", "", "", "")
        Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

        Try
            dao.fields.RCVDATE = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try
        dao.fields.RCVNO = rcvno
        dao.fields.RCVNO_DISPLAY = "IMP-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
        alert("ยืนยันข้อมูลแล้ว คุณได้เลขรับที่ " & "IMP-" & Left(rcvno, 2) & "-" & Right(rcvno, 5))
        dao.insert()

        Dim activenm As Array
        Dim activecd As Array
        Dim activelist As Array
        Dim dosage As Array
        Dim unitcd As Array
        Dim unitnm As Array
        Dim i As Integer
        activenm = lbl_activenm.Text.Split(",")
        activecd = lbl_activecd.Text.Split(",")
        activelist = lbl_activelist.Text.Split(",")
        dosage = lbl_dosage.Text.Split(",")
        unitcd = lbl_unitcd.Text.Split(",")
        unitnm = lbl_unitnm.Text.Split(",")

        Dim dao_active As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_ACTIVE_INGREDIENTS
        For i = 0 To activenm.Length - 1

            dao_active.fields.FK_IDA = dao.fields.IDA
            dao_active.fields.IOWACD = activecd(i)
            dao_active.fields.IOWANM = activenm(i)
            dao_active.fields.DOSAGE = dosage(i)
            dao_active.fields.UNIT_ID = CInt(unitcd(i))
            dao_active.fields.UNIT_NM = unitnm(i)
            dao_active.insert()
            dao_active = New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_ACTIVE_INGREDIENTS

        Next

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bao As New BAO.ClsDBSqlcommand
        If String.IsNullOrEmpty(txt_casname.Text) = False Then
            '  GV_data.DataSource = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)
            Dim dt As New DataTable
            If Request.QueryString("aori") <> "" Then
                dt = bao.SP_MAS_CHEMICAL_by_IOWANM_AND_AORI(txt_casname.Text, Request.QueryString("aori"))
            Else
                dt = bao.SP_MAS_CHEMICAL_by_IOWANM(txt_casname.Text)
            End If
            Dim item As New ListItem("", "0")
            ddl_active.DataSource = dt
            ddl_active.DataTextField = "iowanm"
            ddl_active.DataValueField = "IDA"
            ddl_active.DataBind()
            ddl_active.Items.Insert(0, item)

            Dim dao As New DAO_DRUG.TB_drsunit

            dao.GetDataAll()
            ddl_unit.DataSource = dao.datas
            ddl_unit.DataTextField = "sunitengnm"
            ddl_unit.DataValueField = "sunitcd"
            ddl_unit.DataBind()
            ddl_unit.Items.Insert(0, item)
        Else
            alert("กรุณากรอกชื่อสาร")
        End If

    End Sub

    Protected Sub btn_save_active_Click(sender As Object, e As EventArgs) Handles btn_save_active.Click

        If lbl_activecd.Text = "" Then
            lbl_activecd.Text = ddl_active.SelectedValue
            lbl_activelist.Text = "<h3>รายชื่อตัวยาสำคัญ</h3>" & ddl_active.SelectedItem.Text & " ขนาด " & txt_dosage.Text & Space(1) & ddl_unit.SelectedItem.Text
        Else
            lbl_activecd.Text = lbl_activecd.Text & "," & ddl_active.SelectedValue
            lbl_activelist.Text = lbl_activelist.Text & "<br>" & ddl_active.SelectedItem.Text & " ขนาด " & txt_dosage.Text & Space(1) & ddl_unit.SelectedItem.Text
        End If

        If lbl_activenm.Text = "" Then
            lbl_activenm.Text = ddl_active.SelectedItem.Text
        Else
            lbl_activenm.Text = lbl_activenm.Text & "," & ddl_active.SelectedItem.Text
        End If

        If lbl_unitcd.Text = "" Then
            lbl_unitcd.Text = ddl_unit.SelectedValue
        Else
            lbl_unitcd.Text = lbl_unitcd.Text & "," & ddl_unit.SelectedValue
        End If

        If lbl_unitnm.Text = "" Then
            lbl_unitnm.Text = ddl_unit.SelectedItem.Text
        Else
            lbl_unitnm.Text = lbl_unitnm.Text & "," & ddl_unit.SelectedItem.Text
        End If

        If lbl_dosage.Text = "" Then
            lbl_dosage.Text = txt_dosage.Text
        Else
            lbl_dosage.Text = lbl_dosage.Text & "," & txt_dosage.Text
        End If
    End Sub
End Class