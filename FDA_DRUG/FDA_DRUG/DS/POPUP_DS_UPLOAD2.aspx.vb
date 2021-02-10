Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_DS_UPLOAD2
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _lcn_ida As String
    Private _staff As String
    Private _main_ida As String
    'Private _result As String = "กรุณาแนบไฟล์ดังนี้\n"

    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _lcn_ida = Request.QueryString("lcn_ida")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
            _staff = Request.QueryString("staff")
            _main_ida = Request.QueryString("main_ida")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        If _staff = "" Then
            _staff = 0
        End If
        If Not IsPostBack Then
            set_attachment_label()

        End If
        'Dim dao As New DAO_DRUG.TB_TEMPLATE_ATTACH
        'dao.GetDataby_LCTNPCD(_ProcessID, "00")
        'For Each dao.fields In dao.datas
        '    Dim uc As New UC_ATTACH_CUS
        '    Dim CC As UserControl = Page.LoadControl("../UC/UC_ATTACH_CUS.ascx")
        '    uc = CC
        '    uc.ID = dao.fields.IDA
        '    uc.BindData(dao.fields.ATTACH_NAME, dao.fields.ATTACH_PIORITY, dao.fields.ATTACH_FILE_EXTENSION, dao.fields.LCNTPCD, dao.fields.TYPE)
        '    PlaceHolder1.Controls.Add(uc)
        'Next
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
    End Sub
    Sub set_attachment_label()
        lbl_attach1.Text = "ฉลากและเอกสารกำกับผลิตภัณฑ์ ทุกภาชนะบรรจุ ( ไฟล์ PDF เท่านั้น )"
        lbl_attach2.Text = "อื่นๆ"
        'lbl_attach2.Text = "(2) ฉลากกล่อง/ฉลากซองพลาสติก"
        'lbl_attach3.Text = "(3) เอกสารกำกับผลิตภัณฑ์"
        If _ProcessID = "1701" Then
            'lbl_attach3.Text = "(3) เอกสารอื่นๆ (ให้แนบเอกสารแสดงขั้นตอนการผลิตด้วย)"
            'FileUpload4.Visible = True
        ElseIf _ProcessID = "1702" Then
            'FileUpload4.Visible = False
        ElseIf _ProcessID = "1703" Then
            'FileUpload4.Visible = False
        ElseIf _ProcessID = "1704" Then
            'FileUpload4.Visible = False
        ElseIf _ProcessID = "1705" Then
            'lbl_attach3.Text = "(3) เอกสารอื่นๆ (ให้แนบเอกสารแสดงขั้นตอนการผลิตด้วย)"
            'FileUpload4.Visible = True
        End If

    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)

    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)
        'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then
        '    upload()
        'Else
        If FileUpload1.HasFile Then
            If FileUpload2.HasFile Or _staff = 1 Then
                'If FileUpload3.HasFile Or _staff = 1 Then
                If CHK_Extension() = 0 Then
                    upload()
                Else
                    alert("กรุณาแนบไฟล์ให้ถูกต้อง")
                End If

                'Else
                '    alert("กรุณาแนบ " & lbl_attach2.Text)
                'End If
            Else
                alert("กรุณาแนบ " & lbl_attach1.Text)
            End If
        Else
            alert("กรุณาแนบไฟล์คำขอ")
        End If

    End Sub

    Sub upload()
        If FileUpload1.HasFile Then
            'Dim TD As String = ""
            Dim TR_ID As String = ""
            Dim PDF_TRADER As String
            Dim XML_TRADER As String
            Dim bao As New BAO.AppSettings
            Dim paths As String = bao._PATH_DEFAULT
            bao.RunAppSettings()
            Dim dao_ds As New DAO_DRUG.ClsDBdrsamp
            dao_ds.GetDataby_PRODUCT_ID_IDA(_main_ida)

            Try
                If dao_ds.fields.TR_ID Is Nothing Then

                    Dim bao_tran As New BAO_TRANSECTION
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                    bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                    TR_ID = bao_tran.insert_transection_new(_ProcessID)

                    insert_file(TR_ID, FileUpload2, 1)

                    PDF_TRADER = paths & "PDF_TRADER_UPLOAD\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
                    FileUpload1.SaveAs(PDF_TRADER)
                    XML_TRADER = paths & "XML_TRADER_UPLOAD\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
                    convert_PDF_To_XML(PDF_TRADER, XML_TRADER)

                Else

                    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                    dao_up.GetDataby_TR_ID_Process(dao_ds.fields.TR_ID, dao_ds.fields.process_id)
                    dao_up.fields.UPLOAD_DATE = Date.Now
                    dao_up.update()

                    TR_ID = dao_ds.fields.TR_ID

                    insert_file(TR_ID, FileUpload2, 99)

                    PDF_TRADER = paths & "PDF_TRADER_UPLOAD\" & NAME_UPLOAD_PDF_EDIT("DA", _ProcessID, Date.Now.Year, TR_ID, 99)
                    FileUpload1.SaveAs(PDF_TRADER)
                    XML_TRADER = paths & "XML_TRADER_UPLOAD\" & NAME_UPLOAD_XML_EDIT("DA", _ProcessID, Date.Now.Year, TR_ID, 99)
                    convert_PDF_To_XML(PDF_TRADER, XML_TRADER)

                End If
            Catch ex As Exception

            End Try

            'Dim PDF_TRADER As String = paths & "PDF_TRADER_UPLOAD\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            ''PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            'FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"   
            ''PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            ''Dim XML_TRADER As String = bao._PATH_XML_TRADER & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
            'Dim XML_TRADER As String = paths & "XML_TRADER_UPLOAD\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
            ''ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            'convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


            'convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
            Dim check As Boolean = True
            Dim cause As String = ""
            Dim result_obj As Object
            Try
                'check = insrt_to_database(XML_TRADER, TR_ID)
                result_obj = insrt_to_database(XML_TRADER, TR_ID)
                check = result_obj(0)
                cause = result_obj(1)

                If check = True Then
                    alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)

                    'Response.Redirect("FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "")
                ElseIf check = False Then
                    If cause = "" Then
                        alert("ไม่สามารถอัพโหลดไฟล์ PDF ได้ กรุณาแจ้งมาที่ Drug-SmartHelp@fda.moph.go.th พร้อมแนบไฟล์ PDF")
                    Else
                        alert(cause)
                    End If

                End If
            Catch ex As Exception

                alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End Try
        Else
            alert("กรุณาเลือกไฟล์ที่จะอัพโหลดคำขอ")
        End If
        'Dim check As Boolean = True
        'check = insrt_to_database(XML_TRADER, TR_ID)
        '        If check = True Then
        '            SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
        '            alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
        '            Response.Redirect("FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "")
        '        Else
        '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เกิดข้อผิดพลาดกรุณาตรวจสอบข้อมูลในไฟล์');", True)
        '        End If
        '    Catch ex As Exception

        '    alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
        '    End Try
        'Else
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
        'End If
        '    Else
        '        alert2(_result)
        '    End If
        'Else
        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์คำขอ');", True)
        'End If
    End Sub

    Function CHK_Extension() As Integer 'ปรับ เพิ่มtype
        Dim aa As String = System.IO.Path.GetExtension(FileUpload2.FileName)
        Dim i As Integer = 0
        If Not (aa.Contains("pdf") Or aa = "") Then
            i += 1
        End If
        Return i
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Object
        Dim check As Boolean = True
        Dim cause As String = ""
        Dim dao_process As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_process.GetDataby_Process_ID(_ProcessID)
        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_DRSAMP
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(p2.drsamp.IDA)
        Dim dao_ds As New DAO_DRUG.ClsDBdrsamp
        dao_ds.GetDataby_PRODUCT_ID_IDA(_main_ida)

        Try
            If dao.fields.CUSTOMER_CITIZEN_AUTHORIZE <> _CLS.CITIZEN_ID_AUTHORIZE Then
                cause = "บริษัทของผู้ทำคำขอกับบริษัทของผู้ยื่นคำขอไม่ตรงกัน"
                Throw New System.Exception("")  'บังคับให้ออกจาก try catch
            End If
            Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phr.GetDataby_IDA(dao.fields.phr_fk)
            If Request.QueryString("tt") = "" Then
                If _CLS.CITIZEN_ID <> dao_phr.fields.PHR_CTZNO And _staff <> 1 Then
                    cause = "เลขประจำตัวประชาชนของผู้มีหน้าที่ปฏิบัติการไม่ถูกต้อง"
                    Throw New System.Exception("")  'บังคับให้ออกจาก try catch
                End If
            End If

            If dao_ds.fields.TR_ID Is Nothing Then

                dao.fields.process_id = _ProcessID
                dao.fields.STATUS_ID = 0 'บันทึกและรอส่งเรื่อง
                dao.fields.event_start = Date.Now
                dao.fields.TR_ID = TR_ID
                Try
                    If Request.QueryString("tt") <> "" Then
                        'Dim dao_regist As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                        'dao_regist.GetDataby_IDA(Request.QueryString("main_ida"))
                        dao.fields.cndno = Request.QueryString("tt") 'dao_regist.fields.DRUG_EQ_TO
                    End If

                Catch ex As Exception

                End Try

                dao.update()

                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.GetDataby_TR_ID_Process(dao.fields.TR_ID, dao.fields.process_id)
                dao_up.fields.REF_NO = dao.fields.IDA
                dao_up.update()

                Dim dao_pack_copy As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao_pack_copy.GetDataby_FK_IDA(p2.drsamp.IDA)
                If IsNothing(dao_pack_copy.fields.FK_IDA) Then
                    Dim dao_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                    dao_pack_copy = New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                    dao_pack.GetData_chk_by_FK_IDA(p2.drsamp.PRODUCT_ID_IDA)
                    For Each dao_pack.fields In dao_pack.datas
                        dao_pack_copy.fields = dao_pack.fields
                        dao_pack_copy.fields.FK_IDA = p2.drsamp.IDA
                        dao_pack_copy.insert()
                        dao_pack = New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                    Next
                End If
                AddLogStatusEtracking(0, 0, _CLS.CITIZEN_ID, "อัพโหลดเอกสารยาตัวอย่าง " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.TR_ID, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
            Else
                Dim dao_pack_copy As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao_pack_copy.GetDataby_FK_IDA(p2.drsamp.IDA)
                If dao_pack_copy.fields.FK_IDA.HasValue Then
                    Dim dao_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                    dao_pack_copy = New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                    dao_pack.GetData_chk_by_FK_IDA(p2.drsamp.PRODUCT_ID_IDA)
                    For Each dao_pack.fields In dao_pack.datas
                        dao_pack_copy.fields = dao_pack.fields
                        dao_pack_copy.fields.FK_IDA = p2.drsamp.IDA
                        dao_pack_copy.update()
                        dao_pack = New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                    Next
                End If
                AddLogStatusEtracking(0, 0, _CLS.CITIZEN_ID, "อัพเดตเอกสารยาตัวอย่าง " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.TR_ID, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
            End If
        Catch ex As Exception
            check = False
        End Try

        Return {check, cause}
    End Function
    Private Sub insert_file(ByVal TR_ID As Integer, ByVal fileupload As FileUpload, ByVal TD As String)
        If fileupload.HasFile Then
            If TD = 1 Then
                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()

                Dim TYPE As String = fileupload.ID.ToString.Substring(10, 1) - 1

                Dim extensionname As String = GetExtension(fileupload.FileName).ToLower()
                fileupload.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname)
                Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

                dao_file.fields.NAME_FAKE = "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
                dao_file.fields.NAME_REAL = fileupload.FileName
                dao_file.fields.TYPE = TYPE
                dao_file.fields.TRANSACTION_ID = TR_ID
                dao_file.fields.PROCESS_ID = _ProcessID
                dao_file.insert()

            ElseIf TD = 99 Then
                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()

                Dim TYPE As String = 99

                Dim extensionname As String = GetExtension(fileupload.FileName).ToLower()
                fileupload.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname)
                Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

                dao_file.fields.NAME_FAKE = "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
                dao_file.fields.NAME_REAL = fileupload.FileName
                dao_file.fields.TYPE = TYPE
                dao_file.fields.TRANSACTION_ID = TR_ID
                dao_file.fields.PROCESS_ID = _ProcessID
                dao_file.insert()
            End If
        End If

    End Sub
    '''' <summary>
    '''' ทำการ UPLOAD FILE แนบ
    '''' </summary>
    '''' <param name="TR_ID"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function Upload_Attach(ByVal TR_ID As Integer)
    '    Dim check As Boolean = True
    '    For Each c As Control In PlaceHolder1.Controls
    '        If c.ID <> "" Then
    '            Dim ida As String = c.ID
    '            Dim uc As New UC_ATTACH_CUS
    '            Dim chk As Boolean = True
    '            uc = PlaceHolder1.FindControl(c.ID)
    '            chk = uc.insert(TR_ID)
    '            If chk = False Then
    '                check = False
    '                _result = _result & "-  " & uc.NAME.Replace("<br>", "\n") & "\n"
    '            End If
    '        End If
    '    Next
    '    Return check
    'End Function
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'กลับไปยังหน้าเดิม
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
        'Dim get_session As CLS_SESSION = Session("product_id")
        'Response.Write("<script type langue =javascript>")
        'Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcn_ida & "';")
        'Response.Write("</script type >")
    End Sub
    'Sub alert2(ByVal text As String)
    '    Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    'End Sub
End Class