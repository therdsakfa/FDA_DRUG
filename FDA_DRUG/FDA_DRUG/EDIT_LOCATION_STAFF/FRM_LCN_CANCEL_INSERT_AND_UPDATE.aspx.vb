Public Class FRM_LCN_CANCEL_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page
    ' Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS         'เรียก Process ที่เราเรียก
            _lcn_ida = Request.QueryString("lcn_ida")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Dim dao_l As New DAO_DRUG.ClsDBdalcn
            dao_l.GetDataby_IDA(Request.QueryString("lcn_ida"))
            Try
                lbl_lcnno.Text = dao_l.fields.LCNNO_DISPLAY
            Catch ex As Exception

            End Try

            bind_c_type()
            bind_purpose()

            load_ddl()
            txt_WRITE_DATE.Text = Date.Now.ToShortDateString()
            txt_app_date.Text = Date.Now.ToShortDateString()
            Dim dao As New DAO_DRUG.TB_lcnrequest
            If Request.QueryString("ida") <> "" Then
                btn_save.Text = "แก้ไข"
                dao.GetDataby_IDA(Request.QueryString("ida"))
                get_data(dao)

                Dim dao_l2 As New DAO_DRUG.ClsDBdalcn
                dao_l2.GetDataby_IDA(dao.fields.FK_IDA)
                Try
                    lbl_lcnno.Text = dao_l2.fields.LCNNO_DISPLAY
                Catch ex As Exception

                End Try

                Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
                dao_file.GetDataby_TR_ID_And_Process_And_Type(Request.QueryString("ida"), dao.fields.PROCESS_ID, "1")
                Dim bao As New BAO.AppSettings
                Dim url_load As String = ""
                Dim url_load2 As String = ""
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
                dao_file = New DAO_DRUG.ClsDBFILE_ATTACH
                dao_file.GetDataby_TR_ID_And_Process_And_Type(Request.QueryString("ida"), dao.fields.PROCESS_ID, "2")

                Try
                    If dao.fields.IDA <> 0 Then
                        'url_load = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao_file.fields.NAME_FAKE
                        '' url_load = "~/upload/" & dao_file.fields.NAME_FAKE
                        url_load2 = dao_file.fields.NAME_FAKE
                        hp_file_name2.Text = dao_file.fields.NAME_REAL
                        'hp_file_name.PostBackUrl = url_load


                        Dim saveLocation2 As String = _PATH_DEFALUT & "/upload/" & dao_file.fields.NAME_FAKE
                        hp_file_name2.NavigateUrl = "../PDF/FRM_ATTACH_PREVIEW_ALL.aspx?FileName=" & saveLocation2
                    End If

                Catch ex As Exception

                End Try

                ImageButton1.Style.Add("display", "block")
                hp_file_name.Style.Add("display", "block")
                ImageButton2.Style.Add("display", "block")
                hp_file_name2.Style.Add("display", "block")
            Else
                btn_save.Text = "บันทึก"
                ImageButton1.Style.Add("display", "none")
                hp_file_name.Style.Add("display", "none")
                ImageButton2.Style.Add("display", "none")
                hp_file_name2.Style.Add("display", "none")
            End If
        End If
    End Sub
    Private Sub load_ddl()
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataEditby_IDEN(Request.QueryString("iden"))
        'ddl_lcnno.DataSource = dao.datas
        'ddl_lcnno.DataTextField = "LCNNO_DISPLAY"
        'ddl_lcnno.DataValueField = "IDA"
        'ddl_lcnno.DataBind()
        'Dim item As New ListItem
        'item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        'item.Value = "0"
        'ddl_lcnno.Items.Insert(0, item)
    End Sub
    Sub bind_c_type()
        Dim dao As New DAO_DRUG.ClsDBdacnc
        dao.GetDataAll()
        ddl_cancel_type.DataSource = dao.datas
        ddl_cancel_type.DataValueField = "cnccd"
        ddl_cancel_type.DataTextField = "cncnm"
        ddl_cancel_type.DataBind()
    End Sub
    Sub bind_purpose()
        Dim dao As New DAO_DRUG.Cls_dacnccs
        dao.GetDataAll()
        ddl_purpose.DataSource = dao.datas
        ddl_purpose.DataValueField = "cnccscd"
        ddl_purpose.DataTextField = "cnccsnm"
        ddl_purpose.DataBind()
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_lcnrequest)
        txt_WRITE_AT.Text = dao.fields.WRITE_AT
        Try
            txt_WRITE_DATE.Text = CDate(dao.fields.WRITE_DATE)
        Catch ex As Exception

        End Try
        Try
            txt_app_date.Text = CDate(dao.fields.app_date)
        Catch ex As Exception

        End Try
        'Try
        '    ddl_lcnno.DropDownSelectData(dao.fields.FK_IDA)
        'Catch ex As Exception

        'End Try

        Try
            ddl_cancel_type.DropDownSelectData(dao.fields.cnccd)
        Catch ex As Exception

        End Try
        Try
            ddl_purpose.DropDownSelectData(dao.fields.cnccscd)
        Catch ex As Exception

        End Try
    End Sub
    Sub set_data(ByRef dao As DAO_DRUG.TB_lcnrequest)
        dao.fields.WRITE_AT = txt_WRITE_AT.Text
        Try
            dao.fields.WRITE_DATE = CDate(txt_WRITE_DATE.Text)
        Catch ex As Exception

        End Try

        Try
            dao.fields.cnccd = ddl_cancel_type.SelectedValue
        Catch ex As Exception

        End Try
        Try
            dao.fields.cnccscd = ddl_purpose.SelectedValue
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_lcnrequest
        'If ddl_lcnno.SelectedValue <> "0" Then
        If Request.QueryString("ida") <> "" Then
            dao.GetDataby_IDA(Request.QueryString("ida"))
            set_data(dao)

            'dao.fields.PROCESS_ID = "1001021"
            dao.update()

            ATTACH1(dao.fields.IDA, "1001021", con_year(Date.Now.Year), "1")
            ATTACH2(dao.fields.IDA, "1001021", con_year(Date.Now.Year), "2")
            alert("แก้ไขข้อมูลเรียบร้อยแล้ว")
        Else
            set_data(dao)
            'dao.fields.LOCATION_ADDRESS_IDA = _lct_ida
            Try
                dao.fields.app_date = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = Request.QueryString("lcn_ida")
            dao.fields.PROCESS_ID = "1001021"
            dao.fields.FK_IDA = _lcn_ida
            dao.fields.STATUS_ID = 8
            dao.fields.LCN_TYPE = 2
            dao.fields.REQUEST_TYPE = 2
            dao.insert()

            ATTACH1(dao.fields.IDA, "1001021", con_year(Date.Now.Year), "1")
            ATTACH2(dao.fields.IDA, "1001021", con_year(Date.Now.Year), "2")
            alert("บันทึกข้อมูลเรียบร้อยแล้ว")
        End If
        'Else
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกใบอนุญาต');", True)

        'End If
    End Sub
    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_lcnrequest
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
            dao_file.GetDataby_TR_ID_And_Process_And_Type(Request.QueryString("IDA"), dao.fields.PROCESS_ID, "1")
            dao_file.delete()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
    End Sub
    Private Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_lcnrequest
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
            dao_file.GetDataby_TR_ID_And_Process_And_Type(Request.QueryString("IDA"), dao.fields.PROCESS_ID, "2")
            dao_file.delete()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Function ATTACH1(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String) As Boolean 'ปรับ เพิ่มtype
        '1001021

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
    Function ATTACH2(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String) As Boolean 'ปรับ เพิ่มtype
        '1001021

        Dim bool As Boolean = False
        If FileUpload2.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว

            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload2.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & type & "." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload2.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่


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
End Class