Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_DS_UPLOAD_NORYORMOR
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _process As String
    Private _lcnno As String

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            _ProcessID = Request.QueryString("process")
            _lcnno = _CLS.LCNNO

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        set_attachment_label()

    End Sub

    Sub set_attachment_label()
        lbl_attach1.Text = "1. ฉลากทุกขนาดบรรจุ"
        lbl_attach3.Text = "2. เอกสารกำกำกับยา"
        If _ProcessID = "1027" Then
            lbl_attach4.Text = "3. วิธีวิเคราะห์"
            FileUpload5.Visible = False
            lbl_email.Visible = False
            lbl_email_submit.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            txt_citizen_submit.Visible = False
            txt_citizen_rcv.Visible = False
            tbox0.Style.Add("display", "")
        ElseIf _ProcessID = "1028" Then
            lbl_attach4.Text = "3. หนังสือระบุหน่วยงาน สถานที่ และเวลาที่จะจัดนิทรรศการ"
            lbl_attach5.Text = "4. Certificate of Free Sale"
            lbl_email.Text = "อีเมลผู้จัดนิทรรศการ"
            lbl_email_submit.Text = "อีเมลผู้ยื่นคำขอ"
            lbl_citizen_submit.Text = "เลขประจำตัวผู้ยื่นคำขอ"
            lbl_citizen_rcv.Text = "เลขประจำตัวผู้จัดนิทรรศการ"
            tbox0.Style.Add("display", "")
            tbox1.Style.Add("display", "")
            tbox2.Style.Add("display", "")
            tbox3.Style.Add("display", "")
            tbox4.Style.Add("display", "")
            nym3.Style.Add("display", "")
        ElseIf _ProcessID = "1029" Then
            lbl_attach4.Text = "3. Certificate of Free Sale"
            FileUpload5.Visible = False
            lbl_email.Text = "อีเมลผู้รับบริจาคยา"
            lbl_email_submit.Text = "อีเมลผู้ยื่นคำขอ"
            lbl_citizen_submit.Text = "เลขประจำตัวผู้ยื่นคำขอ"
            lbl_citizen_rcv.Text = "เลขประจำตัวผู้รับบริจาคยา"
            tbox0.Style.Add("display", "")
            tbox1.Style.Add("display", "")
            tbox2.Style.Add("display", "")
            tbox3.Style.Add("display", "")
            tbox4.Style.Add("display", "")
        ElseIf _ProcessID = "1026" Then
            lbl_attach6.Visible = True
            lbl_attach7.Visible = True
            lbl_attach8.Visible = True
            lbl_attach9.Visible = True
            FileUpload6.Visible = True
            FileUpload7.Visible = True
            FileUpload8.Visible = True
            FileUpload9.Visible = True
            lbl_email.Visible = False
            lbl_email_submit.Visible = False
            lbl_citizen_submit.Visible = False
            lbl_citizen_rcv.Visible = False
            TextBox1.Visible = False
            TextBox2.Visible = False
            txt_citizen_submit.Visible = False
            txt_citizen_rcv.Visible = False

            lbl_attach3.Text = "2. เอกสารกำกับยา (สำหรับยาที่ขึ้นทะเบียนตำรับยาแล้ว)"
            lbl_attach4.Text = "3. เอกสารคู่มือผู้วิจัย (Investigator Brochure) (สำหรับยาที่ยังไม่ได้ขึ้นทะเบียน)"
            lbl_attach5.Text = "4. เอกสารแนะนำอาสาสมัคร (Patient Information Sheet) (ภาษาไทย)"
            lbl_attach6.Text = "5. สรุปย่อโครงการวิจัย (ภาษาไทย)"
            lbl_attach7.Text = "6. รายละเอียดโครงการวิจัย ฉบับสมบูรณ์ (ภาษาไทย หรือ ภาษาอังกฤษ)"
            lbl_attach8.Text = "7. เอกสารควบคุมคุณภาพและการผลิตยา"
            lbl_attach9.Text = "8. เอกสารอนุมัติให้ทำการวิจัยจากคณะกรรมการพิจารณาจริยธรรมการวิจัยในคน (Institutional Review Board: IRB หรือ Independent Ethics Committee: IEC) ที่สำนักงานคณะกรรมการอาหารและยา ยอมรับ"

        End If

    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        If _ProcessID = "1028" Then
            If TextBox1.Text = "" Then
                alert("กรุณากรอกอีเมลให้ครบทุกช่อง")
            ElseIf TextBox2.Text = "" Then
                alert("กรุณากรอกอีเมลให้ครบทุกช่อง")
            Else
                If txt_citizen_submit.Text = "" Then
                    alert("กรุณากรอกเลขประจำตัวผู้ยื่น")
                Else
                    Dim bao As New BAO.ClsDBSqlcommand
                    bao.GetDataby_check_identify(txt_citizen_submit.Text)

                    If bao.dt.Rows.Count = 0 Then
                        alert("เลขประจำตัวผู้ยื่น ไม่ถูกต้อง โปรดตรวจสอบอีกครั้ง")
                    Else
                        If txt_citizen_rcv.Text = "" Then
                            alert("กรุณากรอก" & lbl_citizen_rcv.Text)
                        Else
                            Dim bao2 As New BAO.ClsDBSqlcommand
                            bao2.GetDataby_check_identify(txt_citizen_rcv.Text)

                            If bao2.dt.Rows.Count = 0 Then
                                'alert popup ยืนยัน ค้างไว้ก่อน
                                upload()
                            Else
                                upload()
                            End If
                        End If

                    End If

                End If
            End If
        ElseIf _ProcessID = "1029" Then
            If TextBox1.Text = "" Then
                alert("กรุณากรอกอีเมลให้ครบทุกช่อง")
            ElseIf TextBox2.Text = "" Then
                alert("กรุณากรอกอีเมลให้ครบทุกช่อง")
            Else
                If txt_citizen_submit.Text = "" Then
                    alert("กรุณากรอกเลขประจำตัวผู้ยื่น")
                Else
                    Dim bao As New BAO.ClsDBSqlcommand
                    bao.GetDataby_check_identify(txt_citizen_submit.Text)

                    If bao.dt.Rows.Count = 0 Then
                        alert("เลขประจำตัวผู้ยื่น ไม่ถูกต้อง โปรดตรวจสอบอีกครั้ง")
                    Else
                        If txt_citizen_rcv.Text = "" Then
                            alert("กรุณากรอก" & lbl_citizen_rcv.Text)
                        Else
                            Dim bao2 As New BAO.ClsDBSqlcommand
                            bao2.GetDataby_check_identify(txt_citizen_rcv.Text)

                            If bao2.dt.Rows.Count = 0 Then
                                'alert popup ยืนยัน ค้างไว้ก่อน
                                upload()
                            Else
                                upload()
                            End If
                            Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
                        End If

                    End If

                End If
            End If
        Else
            upload()
        End If

    End Sub

    Function chk_attach()
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)
        Dim chk As Boolean = False

        'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then 'เดโม่ไม่ต้องตรวจสอบไฟล์แนบ
        chk = True
        'Else
        'If _ProcessID = 1027 Or _ProcessID = 1029 Then
        '        If FileUpload2.HasFile And FileUpload3.HasFile And FileUpload4.HasFile Then
        '            chk = True
        '        End If
        '    ElseIf _ProcessID = 1028 Then
        '        If FileUpload2.HasFile And FileUpload3.HasFile And FileUpload4.HasFile And FileUpload5.HasFile Then
        '            chk = True
        '        End If
        '        'ElseIf _ProcessID = 1029 Then
        '        '    If FileUpload2.HasFile And FileUpload3.HasFile And FileUpload4.HasFile Then
        '        '        chk = True
        '        '    End If
        '    End If
        'End If

        Return chk
    End Function

    Sub upload()
        If FileUpload1.HasFile Then

            If chk_attach() = False Then
                alert("กรุณาแนบไฟล์แนบ")
                Exit Sub
            End If

            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION

            'ตรวจสอบไฟล์แนบ
            insert_file(TR_ID, FileUpload2)
            insert_file(TR_ID, FileUpload3)
            insert_file(TR_ID, FileUpload4)
            insert_file(TR_ID, FileUpload5)
            insert_file(TR_ID, FileUpload6)
            insert_file(TR_ID, FileUpload7)
            insert_file(TR_ID, FileUpload8)
            insert_file(TR_ID, FileUpload9)


            'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
            '    Exit Sub
            'End If

            Dim paths As String = bao._PATH_DEFAULT

            Dim PDF_TRADER As String = paths & "PDF_TRADER_UPLOAD\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'Dim PDF_TRADER As String = bao._PATH_PDF_TRADER & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"

            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            Dim XML_TRADER As String = paths & "XML_TRADER_UPLOAD\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
            Dim check As Boolean = True
            Try
                If _ProcessID = "1026" Then
                    check = insrt_to_database2(XML_TRADER, TR_ID)
                Else
                    check = insrt_to_database3(XML_TRADER, TR_ID)
                End If
                If check = True Then
                    Dim dao_xml As New DAO_DRUG.clsDBXML_NAME
                    dao_xml.fields.TR_ID = TR_ID
                    dao_xml.fields.PATH = paths & "XML_TRADER_UPLOAD\"
                    dao_xml.fields.PROCESS_ID = _ProcessID
                    dao_xml.fields.XML_NAME = NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
                    dao_xml.insert()
                    alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                    Response.Write("<script type langue =javascript>")
                    Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcnno & "';")
                    Response.Write("</script type >")
                Else
                    alert("เกิดข้อผิดพลาดไม่สามารถอัพโหลดใบคำขอได้ กรุณาดาวน์โหลดใบคำขออีกครั้งแล้วทำการอัพโหลดใหม่ หากยังไม่ได้ให้ติดต่อเจ้าหน้าที่")
                End If
            Catch ex As Exception

                alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End Try
        Else
            alert("กรุณาเลือกไฟล์ที่จะอัพโหลดคำขอ")
        End If
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try


            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DRSAMP
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(p2.drsamp.IDA)
            'dao.fields = p2.drsamp
            dao.fields.rcvdate = Date.Now
            dao.fields.TR_ID = TR_ID
            dao.fields.STATUS_ID = 0
            If _ProcessID = "1028" Then
                dao.fields.event_start = txt_start_date.Text
                dao.fields.event_end = txt_end_date.Text
            End If

            dao.update()

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = dao.fields.IDA
            dao_up.update()

            If _ProcessID = "1026" Then

            Else
                Try
                    dao.fields.CITIZEN_SUBMIT = txt_citizen_submit.Text
                    dao.fields.CITIZEN_RCV = txt_citizen_rcv.Text
                Catch ex As Exception

                End Try
            End If

            If _ProcessID = "1028" Then
                Dim dao2 As New DAO_DRUG.ClsDB_nym_proof

                dao2.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
                dao2.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao2.fields.EMAIL_SUBMIT = TextBox1.Text
                dao2.fields.EMAIL2 = TextBox2.Text
                dao2.fields.FK_DRSAMP = dao.fields.IDA
                dao2.fields.PROCESS_ID = _ProcessID
                dao2.insert()

            ElseIf _ProcessID = "1029" Then
                Dim dao2 As New DAO_DRUG.ClsDB_nym_proof

                dao2.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
                dao2.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao2.fields.EMAIL_SUBMIT = TextBox1.Text
                dao2.fields.EMAIL2 = TextBox2.Text
                dao2.fields.FK_DRSAMP = dao.fields.IDA
                dao2.fields.PROCESS_ID = _ProcessID
                dao2.insert()
            End If

            Dim dao_pack_copy As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
            dao_pack_copy.GetData_chk_by_FK_drsamp(p2.drsamp.IDA)
            If IsNothing(dao_pack_copy.fields.DRSAMP_IDA) Then
                Dim dao_pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                dao_pack_copy = New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                dao_pack.GetData_chk_by_FK_IDA(p2.drsamp.PRODUCT_ID_IDA)
                For Each dao_pack.fields In dao_pack.datas
                    dao_pack_copy.fields = dao_pack.fields
                    dao_pack_copy.fields.DRSAMP_IDA = p2.drsamp.IDA
                    dao_pack_copy.insert()
                    dao_pack = New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                Next
            End If

        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB ของ นยม1
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database2(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try


            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_PROJECT_SUM
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.ClsDBdrsamp

            dao.fields = p2.drsamp
            dao.fields.rcvdate = Date.Now
            dao.fields.TR_ID = TR_ID
            dao.fields.STATUS_ID = 0
            dao.fields.PJSUM_IDA = p2.DRUG_PROJECT_SUMMARY.IDA
            dao.fields.lcntpcd = "นยม1"
            dao.insert()

            Dim dao_pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
            For Each dao_pack.fields In p2.DRSAMP_PACKAGE_DETAILS
                dao_pack.fields.CHECK_PACKAGE = 1
                dao_pack.insert()
                dao_pack = New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
            Next

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = dao.fields.IDA
            dao_up.update()

        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function
    Private Function insrt_to_database3(ByVal filename As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try
            If _ProcessID = "1030" Then
                Dim objStreamReader As New StreamReader(filename)
                Dim p2 As New CLASS_NORYORMOR5
                Dim x As New XmlSerializer(p2.GetType)
                p2 = x.Deserialize(objStreamReader)
                objStreamReader.Close()
                Dim dao As New DAO_DRUG.ClsDBdrsamp

                dao.fields.rcvdate = Date.Now
                dao.fields.TR_ID = TR_ID
                dao.fields.STATUS_ID = 0
                dao.fields.lcntpcd = "นยม5"
                dao.insert()


                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
                dao_up.fields.REF_NO = dao.fields.IDA
                dao_up.update()
            ElseIf _ProcessID = "1026" Then
                Dim objStreamReader As New StreamReader(filename)
                Dim p2 As New CLASS_PROJECT_SUM
                Dim x As New XmlSerializer(p2.GetType)
                p2 = x.Deserialize(objStreamReader)
                objStreamReader.Close()
                Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM

                dao.fields.CREATE_DATE = Date.Now
                dao.fields.TR_ID = TR_ID
                dao.fields.STATUS_ID = 0
                dao.insert()


                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
                dao_up.fields.REF_NO = dao.fields.IDA
                dao_up.update()

            Else
                Dim objStreamReader As New StreamReader(filename)
                Dim p2 As New CLASS_NYM24
                Dim x As New XmlSerializer(p2.GetType)
                p2 = x.Deserialize(objStreamReader)
                objStreamReader.Close()

                Dim dao As New DAO_DRUG.ClsDBdrsamp

                dao.fields.rcvdate = Date.Now
                dao.fields.TR_ID = TR_ID
                dao.fields.STATUS_ID = 0
                If _ProcessID = "1027" Then
                    dao.fields.lcntpcd = "นยม2"
                ElseIf _ProcessID = "1028" Then
                    dao.fields.lcntpcd = "นยม3"
                Else
                    dao.fields.lcntpcd = "นยม4"
                End If
                Dim dao_pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
                Dim dt_pack As New DataTable
                Dim dt_copy As New DataTable
                Dim count As Integer = 0
                For Each a In p2.PAKAGE
                    For Each b In a.contain_detail
                        Try

                            Dim dao_re_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                            dao_re_pack.GetDataby_IDA(b.data)
                            For Each dao_pack.datas In dao_re_pack.datas
                                dao_pack.fields.CHECK_PACKAGE = 1
                                dao_pack.insert()
                                dao_pack = New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL

                            Next
                            Dim bao As New BAO.ClsDBSqlcommand
                            If count = 0 Then
                                dt_pack = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_IDA(b.data)
                            Else
                                dt_copy = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_IDA(b.data)

                                dt_pack.Merge(dt_copy)


                            End If

                            count += 1
                        Catch ex As Exception

                        End Try

                    Next
                Next
                p2.DT_SHOW.DT5 = dt_pack
                Try
                    Dim objStreamWriter As New StreamWriter(filename)
                    Dim x2 As New XmlSerializer(p2.GetType)
                    x2.Serialize(objStreamWriter, p2)
                    objStreamWriter.Close()
                Catch ex As Exception

                End Try
                dao.insert()
                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
                dao_up.fields.REF_NO = dao.fields.IDA
                dao_up.update()
            End If
        Catch ex As Exception
            check = False
        End Try
        Return check
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _ProcessID = "1027" Or _ProcessID = "1028" Or _ProcessID = "1029" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & _ProcessID & "';")
            Response.Write("</script type >")
        Else
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcnno & "';")
            Response.Write("</script type >")
        End If
    End Sub

    Private Sub insert_file(ByVal TR_ID As Integer, ByVal fileupload As FileUpload)
        If fileupload.HasFile Then
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
        End If

    End Sub

End Class