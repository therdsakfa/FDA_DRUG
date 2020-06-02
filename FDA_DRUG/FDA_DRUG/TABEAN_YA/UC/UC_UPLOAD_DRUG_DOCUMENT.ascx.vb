Public Class UC_UPLOAD_DRUG_DOCUMENT
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim dao_file1 As New DAO_DRUG.TB_REGIST_FILE_ATTACH
                dao_file1.GetDataby_TR_ID_type(Request.QueryString("TR_ID"), 1)
                If dao_file1.fields.IDA <> 0 Then
                    ImageButton1.Style.Add("display", "block")
                    hp_file_name.Style.Add("display", "block")
                End If
                Dim bao As New BAO.AppSettings
                Dim url_load As String = ""
                Try
                    url_load = dao_file1.fields.NAME_FAKE
                    hp_file_name.Text = dao_file1.fields.NAME_REAL
                    Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & dao_file1.fields.NAME_FAKE
                    hp_file_name.NavigateUrl = "../../PDF/FRM_ATTACH_PREVIEW_ALL.aspx?FileName=" & saveLocation

                Catch ex As Exception

                End Try


                Dim dao_file2 As New DAO_DRUG.TB_REGIST_FILE_ATTACH
                dao_file2.GetDataby_TR_ID_type(Request.QueryString("TR_ID"), 2)
                If dao_file2.fields.IDA <> 0 Then
                    ImageButton2.Style.Add("display", "block")
                    hp_file_name2.Style.Add("display", "block")
                End If
                Dim url_load2 As String = ""
                Try
                    url_load2 = dao_file2.fields.NAME_FAKE
                    hp_file_name2.Text = dao_file2.fields.NAME_REAL
                    Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & dao_file2.fields.NAME_FAKE
                    hp_file_name2.NavigateUrl = "../../PDF/FRM_ATTACH_PREVIEW_ALL.aspx?FileName=" & saveLocation

                Catch ex As Exception

                End Try

                Dim dao_file3 As New DAO_DRUG.TB_REGIST_FILE_ATTACH
                dao_file3.GetDataby_TR_ID_type(Request.QueryString("TR_ID"), 3)
                If dao_file3.fields.IDA <> 0 Then
                    ImageButton3.Style.Add("display", "block")
                    hp_file_name3.Style.Add("display", "block")
                End If
                Dim url_load3 As String = ""
                Try
                    url_load3 = dao_file3.fields.NAME_FAKE
                    hp_file_name3.Text = dao_file3.fields.NAME_REAL
                    Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & dao_file3.fields.NAME_FAKE
                    hp_file_name3.NavigateUrl = "../../PDF/FRM_ATTACH_PREVIEW_ALL.aspx?FileName=" & saveLocation
                Catch ex As Exception

                End Try

                If url_load = "" Then
                    ImageButton1.Style.Add("display", "none")
                    hp_file_name.Style.Add("display", "none")
                End If

                If url_load2 = "" Then
                    ImageButton2.Style.Add("display", "none")
                    hp_file_name2.Style.Add("display", "none")
                End If

                If url_load3 = "" Then
                    ImageButton3.Style.Add("display", "none")
                    hp_file_name3.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
            
        End If
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year))
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย'); window.location='" & Uri & "';", True)
    End Sub
    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao_file As New DAO_DRUG.TB_REGIST_FILE_ATTACH
            dao_file.GetDataby_TR_ID_type(Request.QueryString("TR_ID"), 1)
            dao_file.delete()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
    End Sub
    Function ATTACH(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String) As Boolean 'ปรับ เพิ่มtype
        Dim bool As Boolean = False
        If FileUpload1.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว

            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload1.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & 1 & "." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload1.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่


            Dim dao As New DAO_DRUG.TB_REGIST_FILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            dao.fields.TYPE = 1 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()
        End If

        If FileUpload2.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว

            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload2.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & 2 & "." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload2.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่


            Dim dao As New DAO_DRUG.TB_REGIST_FILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            dao.fields.TYPE = 2 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()
        End If
        If FileUpload3.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว

            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload3.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & 3 & "." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload3.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่


            Dim dao As New DAO_DRUG.TB_REGIST_FILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            dao.fields.TYPE = 3 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()
        End If
        Return bool

    End Function

    Private Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao_file As New DAO_DRUG.TB_REGIST_FILE_ATTACH
            dao_file.GetDataby_TR_ID_type(Request.QueryString("TR_ID"), 2)
            dao_file.delete()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
    End Sub

    Private Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao_file As New DAO_DRUG.TB_REGIST_FILE_ATTACH
            dao_file.GetDataby_TR_ID_type(Request.QueryString("TR_ID"), 3)
            dao_file.delete()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
    End Sub
End Class