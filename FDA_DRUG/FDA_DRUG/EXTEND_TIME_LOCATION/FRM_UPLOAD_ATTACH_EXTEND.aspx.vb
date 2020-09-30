Public Class FRM_UPLOAD_ATTACH_EXTEND
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
        Dim _type As Integer = 0
        Try
            dao.GetMAXby_TR_ID_And_Process(Request.QueryString("TR_ID"), Request.QueryString("process"))
            _type = dao.fields.TYPE
        Catch ex As Exception

        End Try
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload1, Label1.Text)
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload2, Label2.Text)
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload3, Label3.Text)
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload4, Label4.Text)
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload6, Label6.Text)
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload7, Label7.Text)
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload8, Label8.Text)
        _type = _type + 1
        ATTACH(Request.QueryString("TR_ID"), Request.QueryString("process"), con_year(Date.Now.Year), _type, FileUpload9, Label9.Text)
        alert("อัพโหลดไฟล์เรียบร้อยแล้ว")
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub ATTACH(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String, ByRef file_upload As FileUpload, ByVal _des As String) 'ปรับ เพิ่มtype

        If file_upload.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว
            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload1.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & type & "." & System.IO.Path.GetExtension(FileUpload1.FileName) 'Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload1.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่

            If _des = "อื่นๆ" Then
                _des = TextBox1.Text
            End If

            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            dao.fields.TYPE = type 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.DESCRIPTION = _des
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()
        End If

    End Sub
End Class