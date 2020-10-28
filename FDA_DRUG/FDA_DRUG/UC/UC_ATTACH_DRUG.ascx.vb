Public Class UC_ATTACH_DRUG
    Inherits System.Web.UI.UserControl
    Private _staff As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _staff = Request.QueryString("staff")
    End Sub
    Sub get_label(ByVal text As String)
        Label1.Text = text ' ชื่อของ  label
    End Sub
    ''' <summary>
    ''' ฟังชั่นเก็บข้อมูลไฟล์แนบ
    ''' </summary>
    ''' <param name="transection">เลขอ้างอิงPDF</param>
    ''' <param name="PROCESS_ID">รหัสกระบวนการ</param>
    ''' <param name="year">ปี</param>
    ''' <param name="type">ลำดับ</param>
    ''' <remarks></remarks> 
    Sub ATTACH(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String) 'ปรับ เพิ่มtype
        If FileUpload1.HasFile Or type = 3 Or type = 33 Or _staff = 1 Then 'เช็คว่ามีการเบราไฟล์แล้ว
            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload1.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & type & System.IO.Path.GetExtension(FileUpload1.FileName) '"." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload1.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่              'FileUpload    


            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            Try
                dao.fields.DESCRIPTION = Label1.Text
            Catch ex As Exception

            End Try
            dao.fields.TYPE = type 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()
        Else
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
            'Exit Sub
        End If
    End Sub
    Function CHK_Extension() As Integer
        Dim aa As String = System.IO.Path.GetExtension(FileUpload1.FileName)
        Dim i As Integer = 0
        If Not (aa.Contains("pdf") Or aa = "") Then
            i += 1
        End If
        Return i
    End Function
    Sub ATTACH1(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String) 'ปรับ เพิ่มtype
        If FileUpload1.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว
            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload1.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & type & System.IO.Path.GetExtension(FileUpload1.FileName) '"." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload1.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่


            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            dao.fields.TYPE = type 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()

        End If




    End Sub


    Public Function check() As String
        Dim _check As String
        _check = FileUpload1.HasFile
        If _check = True Then

        End If
        Return _check
    End Function
    Public Function check2() As String
        Dim _check As Integer = 0

        If FileUpload1.HasFile Then
            _check += 1
        End If
        Return _check
    End Function
    Public Function chk(ByVal count As Integer) As String
        Dim _check As String
        _check = FileUpload1.HasFile
        If _check = True Then
            count += 1
        End If
        Return count
    End Function
End Class