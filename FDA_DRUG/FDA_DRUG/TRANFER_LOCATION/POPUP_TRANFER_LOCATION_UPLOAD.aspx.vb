Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports System.Xml

Public Class POPUP_TRANFER_LOCATION_UPLOAD
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _ProcessID As Integer
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")


        bao.RunAppSettings()
        _CLS = Session("CLS")

    End Sub
    Private _CLS As New CLS_SESSION
    Dim bao As New BAO.AppSettings

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        set_txt_label()
        show_panel()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx")
    End Sub
    Public Sub show_panel()
        If _type_id = "101" Then
            Panel101.Style.Add("display", "block")
        ElseIf _type_id = "102" Then
            Panel102.Style.Add("display", "block")
        ElseIf _type_id = "103" Then
            Panel103.Style.Add("display", "block")
        ElseIf _type_id = "104" Then
            Panel104.Style.Add("display", "block")
        ElseIf _type_id = "105" Then
            Panel105.Style.Add("display", "block")
        ElseIf _type_id = "106" Then
            Panel106.Style.Add("display", "block")
        ElseIf _type_id = "107" Then
            Panel107.Style.Add("display", "block")
        ElseIf _type_id = "108" Then
            Panel108.Style.Add("display", "block")
        ElseIf _type_id = "109" Then
            Panel109.Style.Add("display", "block")
        Else

        End If
    End Sub
    Public Sub set_txt_label()
        'ขย.1
        uc101_1.get_label("รูปผู้ดำเนินกิจการ")
        uc101_2.get_label("ใบรับรองแพทย์")
        uc101_3.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc101_4.get_label("เอกสารแสดงหลักทรัพย์")

        'ขย.2
        uc102_1.get_label("รูปผู้ดำเนินกิจการ")
        uc102_2.get_label("หนังสือให้ความยินยอมในการสืบสิทธิ์")
        uc102_3.get_label("ใบรับรองแพทย์ ")
        uc102_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc102_5.get_label("เอกสารแสดงหลักทรัพย์")

        'ขย.3
        uc103_1.get_label("รูปผู้ดำเนินกิจการ")
        uc103_2.get_label("ใบรับรองแพทย์")
        uc103_3.get_label("เอกสารกรรมสิทธ์")
        uc103_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc103_5.get_label("เอกสารแสดงหลักทรัพย์")

        'ขย.4
        uc104_1.get_label("รูปผู้ดำเนินกิจการ")
        uc104_2.get_label("ใบรับรองแพทย์")
        uc104_3.get_label("เอกสารกรรมสิทธ์")
        uc104_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc104_5.get_label("เอกสารแสดงหลักทรัพย์")

        'นย.1
        uc105_1.get_label("รูปผู้ดำเนินกิจการ")
        uc105_2.get_label("ใบรับรองแพทย์")
        uc105_3.get_label("เอกสารกรรมสิทธ์")
        uc105_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc105_5.get_label("เอกสารแสดงหลักทรัพย์")

        'ผย.1
        uc106_1.get_label("รูปผู้ดำเนินกิจการ")
        uc106_2.get_label("ใบรับรองแพทย์")
        uc106_3.get_label("เอกสารกรรมสิทธ์")
        uc106_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc106_5.get_label("เอกสารแสดงหลักทรัพย์")
        uc106_6.get_label("แบบแปลนสถานที่ผลิตยาแผนปัจจุบันที่ได้รับอนุมัติ จาก อย.")

        'ขยบ.
        uc107_1.get_label("รูปผู้ดำเนินกิจการ")
        uc107_2.get_label("ใบรับรองแพทย์")
        uc107_3.get_label("เอกสารกรรมสิทธ์")
        uc107_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc107_5.get_label("เอกสารแสดงหลักทรัพย์")
        uc107_6.get_label("แบบแปลนสถานที่ผลิตยาแผนปัจจุบันที่ได้รับอนุมัติ จาก อย.")

        'นยบ.
        uc108_1.get_label("รูปผู้ดำเนินกิจการ")
        uc108_2.get_label("ใบรับรองแพทย์")
        uc108_3.get_label("เอกสารกรรมสิทธ์")
        uc108_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc108_5.get_label("เอกสารแสดงหลักทรัพย์")
        uc108_6.get_label("แบบแปลนสถานที่ผลิตยาแผนปัจจุบันที่ได้รับอนุมัติ จาก อย.")

        'ผยบ.
        uc109_1.get_label("รูปผู้ดำเนินกิจการ")
        uc109_2.get_label("ใบรับรองแพทย์")
        uc109_3.get_label("เอกสารกรรมสิทธ์")
        uc109_4.get_label("เอกสารการได้สิทธิ์ในสถานที่/พื้นที่ที่ขออนุญาต")
        uc109_5.get_label("เอกสารแสดงหลักทรัพย์")
        uc109_6.get_label("แบบแปลนสถานที่ผลิตยาแผนปัจจุบันที่ได้รับอนุมัติ จาก อย.")

    End Sub

    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        If _type_id = "101" Then
            'ขย.1
            uc101_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc101_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc101_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc101_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
        ElseIf _type_id = "102" Then
            'ขย.2
            uc102_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc102_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc102_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc102_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc102_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

        ElseIf _type_id = "103" Then
            'ขย.3
            uc103_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc103_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc103_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc103_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc103_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
        ElseIf _type_id = "104" Then
            'ขย.4
            uc104_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc104_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc104_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc104_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc104_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
        ElseIf _type_id = "105" Then
            'นย.1
            uc105_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc105_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc105_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc105_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc105_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

        ElseIf _type_id = "106" Then
            'ผย.1
            uc106_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc106_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc106_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc106_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc106_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc106_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")

        ElseIf _type_id = "107" Then
            'ขยบ.
            uc107_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc107_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc107_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc107_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc107_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc107_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
        ElseIf _type_id = "108" Then
            'นยบ.
            uc108_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc108_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc108_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc108_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc108_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc108_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")

        ElseIf _type_id = "109" Then

            'ผยบ.
            uc109_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc109_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc109_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc109_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc109_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc109_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")

        End If

    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        ' ทำการ Upload File Pdf  เพื่อทำการ Save PDF ลงไปในระบบ และทำการดึง XML ออกมาจาก PDF เพื่อเก็บไว้
        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



            'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
            '    Exit Sub
            'End If

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)


            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
            Dim check As Boolean = True
            Try
                check = insrt_to_database(XML_TRADER, TR_ID)
                If check = True Then
                    alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                Else

                End If
            Catch ex As Exception

                alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End Try


        End If

    End Sub


    ''' <summary>
    ''' ดึงค่า PDF เข้าไปที่ XML_TRADER
    ''' </summary>
    ''' <remarks></remarks>
    Private Overloads Function convert_PDF_TRADER_To_XML_TRADER(ByVal bytepdf As Byte()) As String
        Dim ob As String
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(bytepdf)
        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml
        Return ob

    End Function

    ''' <summary>
    ''' ดึง lcntpcd
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function set_lcntpcd() As String
        Dim dao As New DAO_DRUG.ClsDBPROCESS_NAME
        dao.GetDataby_Process_ID(_ProcessID)
        Return dao.fields.PROCESS_NAME
    End Function


    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True

        Try
            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DALCN
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()


            Dim cernumber As String = ""

            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.fields = p2.dalcns


            dao.fields.lcnsid = dao.fields.lcnsid


            dao.fields.rcvdate = Date.Now
            dao.fields.lmdfdate = Date.Now
            dao.fields.STATUS_ID = 1
            dao.fields.TR_ID = TR_ID
            ' dao.fields.FK_IDA = _IDA
            dao.fields.CTZNO = _CLS.CITIZEN_ID
            dao.fields.lcntpcd = set_lcntpcd() 'test
            'dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID

            ' dao.fields.xmlnm = "DA-" & _ProcessID & "-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
            'dao.fields.regntfno = run_regntfno()'ปรับไปรันตอน ยืนยัน
            dao.insert()

            'เภสัชกร
            Dim dao_DALCN_PHR As New DAO_DRUG.ClsDBDALCN_PHR
            For Each dao_DALCN_PHR.fields In p2.DALCN_PHRs
                dao_DALCN_PHR.fields.TR_ID = TR_ID
                dao_DALCN_PHR.fields.FK_IDA = dao.fields.IDA
                dao_DALCN_PHR.fields.PHR_STATUS_UPLOAD = 1
                dao_DALCN_PHR.insert()
                dao_DALCN_PHR = New DAO_DRUG.ClsDBDALCN_PHR
            Next

            Dim dao_dakeplctnm As New DAO_DRUG.ClsDBdakeplctnm
            For Each dao_dakeplctnm.fields In p2.dakeplctnms
                dao_dakeplctnm.fields.TR_ID = TR_ID
                dao_dakeplctnm.fields.FK_IDA = dao.fields.IDA
                dao_dakeplctnm.insert()
                dao_dakeplctnm = New DAO_DRUG.ClsDBdakeplctnm
            Next

            Dim dao_dalcnctg As New DAO_DRUG.ClsDBdalcnctg
            For Each dao_dalcnctg.fields In p2.dalcnctgs
                dao_dalcnctg.fields.TR_ID = TR_ID
                dao_dalcnctg.fields.FK_IDA = dao.fields.IDA
                dao_dalcnctg.insert()
                dao_dalcnctg = New DAO_DRUG.ClsDBdalcnctg
            Next

            Dim dao_dacnphdtl As New DAO_DRUG.ClsDBdacnphdtl
            For Each dao_dacnphdtl.fields In p2.dacnphdtls
                dao_dacnphdtl.fields.TR_ID = TR_ID
                dao_dacnphdtl.fields.FK_IDA = dao.fields.IDA
                dao_dacnphdtl.insert()
                dao_dacnphdtl = New DAO_DRUG.ClsDBdacnphdtl
            Next

            Dim dao_dacncphr As New DAO_DRUG.ClsDBdacncphr
            For Each dao_dacncphr.fields In p2.dacncphrs
                dao_dacncphr.fields.TR_ID = TR_ID
                dao_dacncphr.fields.FK_IDA = dao.fields.IDA
                dao_dacncphr.insert()
                dao_dacncphr = New DAO_DRUG.ClsDBdacncphr
            Next

            Dim dao_dalcnkep As New DAO_DRUG.ClsDBdalcnkep
            For Each dao_dalcnkep.fields In p2.dalcnkeps
                dao_dalcnkep.fields.TR_ID = TR_ID
                dao_dalcnkep.fields.FK_IDA = dao.fields.IDA
                dao_dalcnkep.insert()
                dao_dalcnkep = New DAO_DRUG.ClsDBdalcnkep
            Next

            Dim dao_DALCN_WORKTIME As New DAO_DRUG.ClsDBDALCN_WORKTIME
            For Each dao_DALCN_WORKTIME.fields In p2.DALCN_WORKTIMEs
                dao_DALCN_WORKTIME.fields.TR_ID = TR_ID
                dao_DALCN_WORKTIME.fields.FR_IDA = dao.fields.IDA
                dao_DALCN_WORKTIME.insert()
                dao_DALCN_WORKTIME = New DAO_DRUG.ClsDBDALCN_WORKTIME
            Next

            Dim dao_DALCN_KEP As New DAO_DRUG.ClsDBDALCN_KEP
            For Each dao_DALCN_KEP.fields In p2.DALCN_KEPs
                dao_DALCN_KEP.fields.TR_ID = TR_ID
                dao_DALCN_KEP.fields.FK_IDA = dao.fields.IDA
                dao_DALCN_KEP.insert()
                dao_DALCN_KEP = New DAO_DRUG.ClsDBDALCN_KEP
            Next

            Dim dao_sysplace As New DAO_DRUG.ClsDBsysplace
            For Each dao_sysplace.fields In p2.sysplaces
                dao_sysplace.fields.TR_ID = TR_ID
                dao_sysplace.fields.FK_IDA = dao.fields.IDA
                dao_sysplace.insert()
                dao_sysplace = New DAO_DRUG.ClsDBsysplace
            Next

            Dim dao_dalcnaddr As New DAO_DRUG.ClsDBdalcnaddr
            For Each dao_dalcnaddr.fields In p2.dalcnaddrs
                dao_dalcnaddr.fields.TR_ID = TR_ID
                dao_dalcnaddr.fields.FK_IDA = dao.fields.IDA
                dao_dalcnaddr.insert()
                dao_dalcnaddr = New DAO_DRUG.ClsDBdalcnaddr
            Next
            'If dao.fields.lcntypecd = 12 Then 'จะบันทึกเพราะนำเข้าเท่านั้น
            '    Dim dao_fregntffrgn As New DAO.clsDBfregntffrgn
            '    For Each dao_fregntffrgn.fields In p2.fregntffrgn
            '        dao_fregntffrgn.fields.FR_IDA = dao.fields.ID
            '        dao_fregntffrgn.fields.TR_ID = TR_ID
            '        dao_fregntffrgn.insert()
            '        dao_fregntffrgn = New DAO.clsDBfregntffrgn
            '    Next
            'End If

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
            dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao_up.fields.DOWNLOAD_ID = p2.DOWNLOAD_ID
            dao_up.fields.PROCESS_ID = _ProcessID
            dao_up.fields.UPLOAD_DATE = Date.Now
            dao_up.fields.YEAR = Date.Now.Year
            dao_up.fields.REF_NO = dao.fields.IDA
            dao_up.insert()
            'End If
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function




    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class