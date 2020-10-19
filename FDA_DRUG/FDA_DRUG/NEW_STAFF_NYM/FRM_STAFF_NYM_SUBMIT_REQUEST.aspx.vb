Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER

Public Class FRM_STAFF_NYM_SUBMIT_REQUEST
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _YEARS = con_year(Year(Date.Now))
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BindData_PDF()
            Try
                Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao.GetDataby_IDA(_IDA)
                'If dao.fields.STATUS_ID = 1 Then
                '    If Trim(dao.fields.DRUG_EQ_TO) = "" Then
                '        ' reload_pdf(_CLS.PATH_XML, _CLS.PATH_PDF_TEMPLATE, _CLS.PDFNAME)
                '        dao.fields.DRUG_EQ_TO = _CLS.FILENAME_XML
                '        dao.update()
                '    End If

                'End If
            Catch ex As Exception

            End Try
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv(_IDA)
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub
    Sub reload_pdf(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, PATH_PDF_OUTPUT As String)
        Dim cls_xml As New CLASS_GEN_XML.Center
        cls_xml.GEN_XML_REGISTRATION(PATH_XML, p_REGISTRATION)
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                End Using
            End Using
        End Using
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        'Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        'dao.GetDataby_IDA(Integer.Parse(_IDA))
        'dao.fields.STATUS_ID = 2
        'dao.update()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Dim statusID As Integer = 8 'ddl_cnsdcd.SelectedItem.Value
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = statusID

        If statusID = "7" Then
            dao.fields.STATUS_ID = statusID
            Try
                dao.fields.RCVDATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "8" Then

            If Request.QueryString("tt") <> "" Then
                Dim i As Integer = 0
                Dim dao_tt As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                i = dao_tt.Count_IOWA_NULL_Databy_FK_IDA(_IDA)

                If i > 0 Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ เนื่องจากบันทึกข้อมูลไม่ครบถ้วน');</script> ")
                Else
                    Dim bao As New BAO.GenNumber
                    Dim rcvno As String = bao.GEN_NO_06(con_year(Date.Now.Year()), _CLS.PVCODE, "130001", _CLS.LCNNO, "", "", _IDA, "")
                    Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

                    Try
                        dao.fields.RCVDATE = Date.Now 'CDate(txt_app_date.Text)
                    Catch ex As Exception

                    End Try
                    dao.fields.RCVNO = rcvno
                    dao.fields.RCVNO_DISPLAY = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                    dao.fields.REGIS_NO = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                    dao.update()
                    alert("ยืนยันข้อมูลแล้ว คุณได้เลขรับที่ " & "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5))
                End If


            Else
                Dim bao As New BAO.GenNumber
                Dim rcvno As String = bao.GEN_NO_06(con_year(Date.Now.Year()), _CLS.PVCODE, "130001", _CLS.LCNNO, "", "", _IDA, "")
                Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

                Try
                    dao.fields.RCVDATE = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                dao.fields.RCVNO = rcvno
                dao.fields.RCVNO_DISPLAY = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                dao.fields.REGIS_NO = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                dao.update()
                alert("ยืนยันข้อมูลแล้ว คุณได้เลขรับที่ " & "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5))
            End If
        End If
        'alert("ยืนยันข้อมูลแล้ว")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 9
        dao.update()

        alert("ยกเลิกข้อมุลเรียบร้อยแล้ว")
    End Sub

    'Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
    '    Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
    '    Dim dao_TR As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    dao.GetDataby_IDA(Integer.Parse(_IDA))
    '    dao_TR.GetDataby_IDA(dao.fields.TR_ID)

    '    load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    'End Sub
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub
    ''' <summary>
    ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    ''' <summary>
    ''' รวม XML เข้าไปที่ PDFจดแจ้งรายละเอียด
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF2(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
    End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()


        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim lcn_ida As Integer = 0
        Dim lct_ida As Integer = 0
        Try
            dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
            lcn_ida = dao.fields.FK_IDA
            lct_ida = dao_lcn.fields.FK_IDA
        Catch ex As Exception

        End Try


        Dim cls_regis As New CLASS_GEN_XML.DRUG_REGISTRATION(_CLS.CITIZEN_ID, dao.fields.LCNSID, _ProcessID, dao.fields.PVNCD)

        Dim class_xml As New CLASS_REGISTRATION

        Try
            Dim dao_color As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)
            class_xml.DRUG_REGISTRATION_COLORs = dao_color.fields
        Catch ex As Exception

        End Try


        Try
            Dim rcvdate As Date = dao.fields.RCVDATE
            dao.fields.RCVDATE = DateAdd(DateInterval.Year, 543, rcvdate)

        Catch ex As Exception

        End Try
        Try
            class_xml.DRUG_REGISTRATIONs = dao.fields
        Catch ex As Exception

        End Try
        p_REGISTRATION = class_xml


        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(lct_ida) 'ผู้ดำเนิน
        'class_xml.DT_SHOW.DT12 = bao_show.SP_DATA_SHOW_PRODUCT_ID_BY_IDA(_product_id) 'ข้อมูลที่ดึงมาจาก Product ID
        class_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_IDA)
        class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_IDA)
        class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        class_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V3(_IDA)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_IDA)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"
        class_xml.DT_SHOW.DT17 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(_IDA)
        class_xml.DT_SHOW.DT17.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA"

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        class_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(0) 'CER
        class_xml.DT_MASTER.DT15.TableName = "SP_MASTER_CER_PK_BY_FK_IDA"
        class_xml.DT_MASTER.DT16 = bao_master_2.SP_dactg 'หมวดยา
        class_xml.DT_MASTER.DT16.TableName = "SP_dactg"
        class_xml.DT_MASTER.DT17 = bao_master.SP_drkdofdrg() 'ชนิดยา
        class_xml.DT_MASTER.DT17.TableName = "SP_drkdofdrg"
        class_xml.DT_MASTER.DT18 = bao_master.SP_CER_FOREIGN_BY_IDA() 'GMP สถานที่ผลิตต่างประเทศ
        class_xml.DT_MASTER.DT18.TableName = "SP_CER_FOREIGN_BY_IDA"
        class_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI() 'สาร
        class_xml.DT_MASTER.DT19.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        class_xml.DT_MASTER.DT20 = bao_master_2.SP_ATC_DRUG_ALL() 'กลุ่มตำรับ
        class_xml.DT_MASTER.DT20.TableName = "SP_ATC_DRUG_ALL"
        class_xml.DT_MASTER.DT21 = bao_master_2.SP_dosage_form() 'รูปแบบยา
        class_xml.DT_MASTER.DT21.TableName = "SP_dosage_form"
        class_xml.DT_MASTER.DT22 = bao_master_2.SP_DRUG_UNIT_PHYSIC() 'หน่วยเล็กสุด
        class_xml.DT_MASTER.DT22.TableName = "SP_DRUG_UNIT_PHYSIC"
        class_xml.DT_MASTER.DT23 = bao_master_2.SP_MASTER_drsunit() 'หน่วย
        class_xml.DT_MASTER.DT23.TableName = "SP_MASTER_drsunit"
        class_xml.DT_MASTER.DT24 = bao_master_2.SP_FOREIGN_ADDR_ALL()
        class_xml.DT_MASTER.DT24.TableName = "SP_FOREIGN_ADDR_ALL"

        Dim lcnno As String = ""
        Try
            'lcnno_raw = dao_lcn.fields.LCNNO_DISPLAY
            'If lcnno_raw <> "" Then
            lcnno = dao_lcn.fields.lcntpcd & " " & CInt(Right(dao_lcn.fields.lcnno, 5)) & "/25" & Left(dao_lcn.fields.lcnno, 2)
            'End If
        Catch ex As Exception

        End Try
        class_xml.SHOW_LCNNO = lcnno


        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd
        class_xml = cls_regis.gen_xml()

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO
        _CLS.PDFNAME = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.FILENAME_XML = NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class