Imports Telerik.Web.UI

Public Class FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE
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
            lbl_date.Text = Date.Now.ToShortDateString()
            bind_ddl_chemecal()
            bind_ddl_chem16()
            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                'If dao.fields.SUB_TYPE = 2 Then
                '    btn_save.Style.Add("display", "none")
                '    btn_edit.Style.Add("display", "block")
                '    Panel1.Style.Add("display", "block")
                'Else
                '    btn_save.Style.Add("display", "none")
                '    btn_edit.Style.Add("display", "block")
                '    Panel1.Style.Add("display", "none")
                'End If


                Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
                dao_file.GetDataby_TR_ID_And_Process(Request.QueryString("IDA"), dao.fields.PROCESS_ID)
                Dim bao As New BAO.AppSettings
                Dim url_load As String = ""
                Try
                    If dao.fields.IDA <> 0 Then
                        'url_load = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao_file.fields.NAME_FAKE
                        '' url_load = "~/upload/" & dao_file.fields.NAME_FAKE
                        url_load = dao_file.fields.NAME_FAKE
                        hp_file_name.Text = dao_file.fields.NAME_REAL
                        'hp_file_name.PostBackUrl = url_load


                        Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & dao_file.fields.NAME_FAKE
                        hp_file_name.NavigateUrl = "../PDF/FRM_ATTACH_PREVIEW_ALL.aspx?FileName=" & saveLocation
                    End If

                Catch ex As Exception

                End Try
         

                If dao.fields.STATUS_ID >= 2 Then
                    btn_save.Style.Add("display", "none")
                    btn_edit.Style.Add("display", "none")
                    If dao.fields.SUB_TYPE = 2 Then
                        Panel1.Style.Add("display", "block")
                        btn_add.Style.Add("display", "none")
                        Panel2.Style.Add("display", "block")

                    Else
                        Panel1.Style.Add("display", "none")
                        Panel2.Style.Add("display", "block")
                    End If
                    btn_add_statndard.Style.Add("display", "none")
                    hp_file_name.Style.Add("display", "block")
                    FileUpload1.Style.Add("display", "none")
                Else
                    btn_save.Style.Add("display", "none")
                    btn_edit.Style.Add("display", "block")
                    If dao.fields.SUB_TYPE = 2 Then
                        Panel1.Style.Add("display", "block")
                        Panel2.Style.Add("display", "block")
                    Else
                        Panel1.Style.Add("display", "none")
                        Panel2.Style.Add("display", "block")
                    End If
                    ImageButton1.Style.Add("display", "block")
                    hp_file_name.Style.Add("display", "block")
                End If

                If url_load = "" Then
                    ImageButton1.Style.Add("display", "none")
                    hp_file_name.Style.Add("display", "none")
                End If

            Else
                btn_save.Style.Add("display", "block")
                btn_edit.Style.Add("display", "none")
                Panel1.Style.Add("display", "none")
                Panel2.Style.Add("display", "none")
                ImageButton1.Style.Add("display", "none")
                hp_file_name.Style.Add("display", "none")
            End If

            If Request.QueryString("IDA") <> "" Then
                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                Txt_Name.Text = dao.fields.iowanm
                txt_cas.Text = dao.fields.cas_number
                txt_description.Text = dao.fields.DESCRIPTION_OTHER
                txt_INN.Text = dao.fields.INN
                txt_INN_TH.Text = dao.fields.INN_TH
                Try
                    txt_EMAIL.Text = dao.fields.EMAIL
                Catch ex As Exception

                End Try
                Try
                    txt_TEL.Text = dao.fields.TEL
                Catch ex As Exception

                End Try

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
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_CHEMICAL_REQUEST)
        dao.fields.iowanm = Txt_Name.Text
        dao.fields.DESCRIPTION_OTHER = txt_description.Text
        dao.fields.cas_number = txt_cas.Text
        dao.fields.INN = txt_INN.Text
        dao.fields.EMAIL = txt_EMAIL.Text
        dao.fields.TEL = txt_TEL.Text
        dao.fields.INN_TH = txt_INN_TH.Text
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
        set_data(dao)
        dao.fields.REQUEST_DATE = Date.Now
        Try
            dao.fields.FK_IDA = Request.QueryString("lcn_ida")
        Catch ex As Exception

        End Try
        Try
            dao.fields.IDENTIFY = _CLS.CITIZEN_ID
        Catch ex As Exception

        End Try
        Try
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        dao.fields.STATUS_ID = 1
        dao.fields.MAIN_TYPE = Request.QueryString("mt")
        dao.fields.SUB_TYPE = Request.QueryString("st")
        dao.fields.aori = Request.QueryString("t")
        Try
            dao.fields.PROCESS_ID = Request.QueryString("process")
        Catch ex As Exception

        End Try
        dao.insert()

        ATTACH(dao.fields.IDA, Request.QueryString("process"), con_year(Date.Now.Year), "1")

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&IDA=" & dao.fields.IDA
        'If Request.QueryString("st") = "2" Then
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        'ElseIf Request.QueryString("st") = "1" Then
        '    alert("บันทึกข้อมูลเรียบร้อย")
        'End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim process As Integer = 0
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        process = dao.fields.PROCESS_ID
        set_data(dao)

        dao.update()
        ATTACH(dao.fields.IDA, process, con_year(Date.Now.Year), "1")
        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
        'If Request.QueryString("st") = "2" Then

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        'ElseIf Request.QueryString("st") = "1" Then
        'alert("แก้ไขข้อมูลเรียบร้อย")
        'End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST_DETAIL
                dao.GetDataby_IDA(item("IDA_MAIN").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid1.Rebind()
            End If
        End If
    End Sub
    Public Sub bind_ddl_chemecal()
        'Dim dt As New DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_MAS_CHEMICAL_ALL()

        'ddl_chemecal.DataSource = dt
        'ddl_chemecal.DataBind()
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        'Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST_DETAIL
        'dao.fields.iowa_fk = ddl_chemecal.SelectedValue
        'dao.fields.FK_IDA = Request.QueryString("IDA")
        'dao.insert()
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        Dim i As Integer = 0
        Dim j As Integer = 0
        For Each item As GridDataItem In RadGrid2.SelectedItems
            i += 1
        Next
        If i = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลิอกสาร'); ", True)
        Else

            For Each item As GridDataItem In RadGrid2.SelectedItems
                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST_DETAIL
                dao.fields.iowa_fk = item("iowa").Text
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.fields.CHEMICAL_FK_IDA = item("IDA").Text
                dao.insert()

            Next
            RadGrid1.Rebind()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)

        End If

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item

            Dim btn As LinkButton = DirectCast(item("del").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            If Request.QueryString("IDA") <> "" Then
                If dao.fields.STATUS_ID >= 2 Then
                 
                    If dao.fields.SUB_TYPE = 2 Then
                        btn.Style.Add("display", "none")
                    End If
               
                End If
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_CHEMICAL_REQUEST_DETAIL_TABLE(Request.QueryString("IDA"))
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        If txt_search.Text <> "" Then
            dt = bao.SP_MAS_CHEMICAL_SEARCH_RESULT(txt_search.Text)
        End If

        RadGrid2.DataSource = dt
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        RadGrid2.Rebind()
    End Sub
    Private Sub RadGrid3_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid3.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST_STANDARD_IOWA
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid3.Rebind()
            End If
        End If
    End Sub

    Sub bind_ddl_chem16()
        Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL_LIST16
        dao.GetDataALL()
        ddl_chem16.DataSource = dao.datas
        ddl_chem16.DataValueField = "IDA"
        ddl_chem16.DataTextField = "CHEM_NAME"
        ddl_chem16.DataBind()

    End Sub
    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_CHEMICAL_REQUEST_CHEM16_BY_FK_IDA(Request.QueryString("IDA"))
        RadGrid3.DataSource = dt
    End Sub
    Private Sub btn_add_statndard_Click(sender As Object, e As EventArgs) Handles btn_add_statndard.Click
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST_STANDARD_IOWA
        dao.fields.FK_IDA = Request.QueryString("IDA")
        dao.fields.STANDARD_IOWA = ddl_chem16.SelectedValue
        dao.insert()
        RadGrid3.Rebind()
        Response.Write("<script type='text/javascript'>window.parent.alert('เพิ่มข้อมูลเรียบร้อย');</script> ")

    End Sub

    Function ATTACH(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String) As Boolean 'ปรับ เพิ่มtype
        Dim bool As Boolean = False
        If FileUpload1.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว

            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload1.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & type & "." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload1.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่


            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            dao.fields.TYPE = type 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()
        End If


        Return bool

    End Function

    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
            dao_file.GetDataby_TR_ID_And_Process(Request.QueryString("IDA"), dao.fields.PROCESS_ID)
            dao_file.delete()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
    End Sub
    Private Sub Check_pdf()
        Dim bao As New BAO.AppSettings
        Dim imageUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim url() As String = imageUrl.Split("/")
        Dim filename As String = url(url.Length - 1)
        Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & filename

        ' If Checkfile(saveLocation) = False Then
        '     save_pdf(filename, saveLocation)
        ' Else
        load_pdf(saveLocation)
        ' End If

    End Sub
    Private Sub load_pdf(ByVal FilePath As String)
        Response.ContentType = "Content-Disposition"
        Response.WriteFile(FilePath)
        Response.End()
    End Sub

    'Private Sub hp_file_name_Click(sender As Object, e As EventArgs) Handles hp_file_name.Click


    '    If Request.QueryString("IDA") <> "" Then
    '        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
    '        dao.GetDataby_IDA(Request.QueryString("IDA"))
    '        Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
    '        dao_file.GetDataby_TR_ID_And_Process(Request.QueryString("IDA"), dao.fields.PROCESS_ID)
    '        Dim bao As New BAO.AppSettings
    '        Dim url_load As String = ""

    '        'Dim imageUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
    '        'Dim url() As String = imageUrl.Split("/")
    '        'Dim filename As String = url(url.Length - 1)
    '        Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & dao_file.fields.NAME_FAKE
    '        hp_file_name.PostBackUrl = "../PDF/FRM_ATTACH_PREVIEW_ALL.aspx?FileName=" & saveLocation
    '        '    Try
    '        '        If dao.fields.IDA <> 0 Then
    '        '            ' url_load = "~/upload/" & dao_file.fields.NAME_FAKE
    '        '            hp_file_name.Text = dao_file.fields.NAME_REAL
    '        '            'hp_file_name.PostBackUrl = saveLocation
    '        '            Dim last_nm_file As String = ""
    '        '            Dim split_nm As String() = dao_file.fields.NAME_FAKE.Split(".")
    '        '            last_nm_file = split_nm(1)
    '        '            If last_nm_file = "txt" Then
    '        '                Response.ContentType = "text/plain"
    '        '            End If
    '        '            Response.ContentType = "Content-Disposition"
    '        '            If last_nm_file = "txt" Then
    '        '                Response.ContentType = "text/plain"
    '        '            ElseIf last_nm_file = "jpg" Then
    '        '                Response.ContentType = "image/JPEG"
    '        '            ElseIf last_nm_file = "pdf" Then
    '        '                Response.ContentType = "application/pdf"
    '        '            End If
    '        '            Response.WriteFile(saveLocation)
    '        '            Response.End()
    '        '        End If

    '        '    Catch ex As Exception

    '        '    End Try
    '    End If
    'End Sub
End Class