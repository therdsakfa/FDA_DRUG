Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Imports System.Globalization

Public Class POPUP_NYM_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private _lcnno As String

    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        _lcnno = _CLS.LCNNO
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If _ProcessID = "1026" Then
                BindData_PDFNYM1()
            Else
                binddata_NYM()
            End If
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)

        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 0 Then   '0 = บันทึกรอส่งเรื่อง , 1 = ส่งเรื่องรอการชำระเงิน
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
        End If
        'Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        'dao_p.GetDataby_Process_ID(_ProcessID)
        'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then
        '    If dao.fields.STATUS_ID <> 0 Then
        '        btn_confirm.Enabled = False
        '        btn_confirm.CssClass = "btn-danger btn-lg"
        '    End If

        'Else
        '    If dao.fields.STATUS_ID <> 0 Then
        '        btn_confirm.Enabled = False
        '        btn_cancel.Enabled = False
        '        btn_confirm.CssClass = "btn-danger btn-lg"
        '        btn_cancel.CssClass = "btn-danger btn-lg"
        '    End If
        'End If
        If dao.fields.STATUS_ID > 1 Then
            btn_cancel.Enabled = False
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)
        Dim ws2 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT

        'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then       'การทำงานของ DEMO
        dao.fields.STATUS_ID = 1
            'dao.fields.Ref_no = txt_ref_no.Text
            dao.update()
            alert("ยืนยันข้อมูลเรียบร้อย")
            dao_up.fields.STATUS = 1
            dao_up.update()
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcnno & "';")
            Response.Write("</script type >")
        'Else
        '    'Dim result_pay As String = ""
        '    'result_pay = ws2.CHECK_PRICE(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE)

        '    'If result_pay = "1000" Then
        '    '    Dim result As String = ""
        '    '    result = ws2.CHECK_PAYMENT(txt_ref_no.Text, dao_up.fields.CITIEZEN_ID_AUTHORIZE, 1)
        '    '    If result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then

        '    '        dao.fields.STATUS_ID = 1
        '    '        dao.fields.Ref_no = txt_ref_no.Text
        '    '        dao.update()
        '    '        alert("ยืนยันข้อมูลเรียบร้อย")
        '    '        Response.Write("<script type langue =javascript>")
        '    '        Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & _ProcessID & "&lcn_ida=" & _lcnno & "';")
        '    '        Response.Write("</script type >")
        '    '    Else
        '    '        alert(result)
        '    '    End If
        '    'Else
        '    '    alert(result_pay)
        '    'End If
        'End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        dao.update()

        alert("ยกเลิกข้อมุลเรียบร้อยแล้ว")
        Response.Write("<script type langue =javascript>")
        Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & _ProcessID & "';")
        Response.Write("</script type >")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        'Dim clsds As New ClassDataset

        'Response.Clear()
        'Response.ContentType = "Application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        'Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

        'Response.Flush()
        'Response.Close()
        'Response.End()


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
        Dim p2 As New CLASS_DS
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()

    End Sub

    Private Sub binddata_NYM()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim dao_xml As New DAO_DRUG.clsDBXML_NAME
        dao_xml.GetDataby_TR_PROCESS(_TR_ID, _ProcessID)
        path_XML = dao_xml.fields.PATH + dao_xml.fields.XML_NAME
        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

        Dim paths As String = BAO._PATH_DEFAULT

        Dim PDF_TEMPLATE As String = ""
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)

        'If _ProcessID = "1027" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1028" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1029" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1030" Then
        PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'End If
        LOAD_XML_PDF1(path_XML, PDF_TEMPLATE, _ProcessID, filename)
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()


        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim dao_pid As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_pid.GetDataby_IDA(dao.fields.PRODUCT_ID_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.lcnno)

        Dim dao_staff_con As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Try
            dao_staff_con.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
        Catch ex As Exception

        End Try

        Dim rcvr_id As String
        Try
            rcvr_id = dao.fields.rcvr_id
        Catch ex As Exception
            rcvr_id = ""
        End Try
        Dim FK_STAFF_OFFER_IDA As Integer
        Try
            FK_STAFF_OFFER_IDA = dao.fields.FK_STAFF_OFFER_IDA
        Catch ex As Exception
            FK_STAFF_OFFER_IDA = 0
        End Try

        'Dim cls_regis As New CLASS_GEN_XML.drsamp(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_pid.fields.FK_IDA, dao_pid.fields.FK_IDA, dao.fields.TR_ID, dao.fields.CITIZEN_SUBMIT)
        Dim cls_regis As New CLASS_GEN_XML.drsamp(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_pid.fields.FK_IDA, dao_pid.fields.FK_IDA, dao.fields.TR_ID, dao.fields.CITIZEN_SUBMIT, rcvr_id, FK_STAFF_OFFER_IDA)

        Dim class_xml As New CLASS_DRSAMP
        class_xml = cls_regis.gen_xml()
        class_xml.APP_STAFF = dao_staff_con.fields.STAFF_OFFER_NAME

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            Dim write_date As Date = dao.fields.WRITE_DATE
            Dim app_date As Date = dao.fields.appdate
            dao.fields.WRITE_DATE = DateAdd(DateInterval.Year, 543, write_date)
            dao.fields.appdate = DateAdd(DateInterval.Year, 543, app_date)
            class_xml.drsamp = dao.fields
        Catch ex As Exception

        End Try

        '-----------------จำนวนกับรายละเอียดขนาดบรรจุ---------------------
        'Dim dao_pac As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        Dim dao_pac As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_pac.GetDataby_FK_IDA(dao_pid.fields.IDA)
        Dim sum As String = ""

        For Each dao_pac.fields In dao_pac.datas
            If dao_pac.fields.CHECK_PACKAGE = True Then
                If sum <> "" Then
                    sum = sum & ", "
                    sum = sum & dao_pac.fields.IM_DETAIL
                Else
                    sum = dao_pac.fields.IM_DETAIL
                End If
            End If
        Next

        'Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        'dao_package.GetDataby_FK_IDA(dao_pid.fields.IDA)

        Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
        unit_physic.GetDataby_IDA(CInt(dao_pac.fields.SMALL_UNIT))

        class_xml.IMPORT_AMOUNTS = dao.fields.QUANTITY & " " & unit_physic.fields.unit_name
        '-------------------------------------------------------------



        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT

        Dim PDF_TEMPLATE As String = ""

        If _ProcessID = "1027" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1028" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1029" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf _ProcessID = "1030" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        End If


        'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(_ProcessID, lcntype, statusId, 0)

        'Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        'Dim filename As String = paths & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)

        Try
            Dim url As String = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
            Dim ws As New WS_QR_CODE.WS_QR_CODE
            class_xml.QR_CODE = ws.GetQRImgByte(url)
        Catch ex As Exception

        End Try

        p_drsamp = class_xml

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Private Sub BindData_PDFNYM1()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()


        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Dim cls_regis As New CLASS_GEN_XML.NYM1(_IDA, _CLS.LCNNO, dao.fields.PJSUM_IDA, _CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE)
        Dim class_xml As New CLASS_PROJECT_SUM
        class_xml = cls_regis.gen_xml_NYM1()
        p_nym1 = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd

        Dim paths As String = bao._PATH_DEFAULT
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(_ProcessID, lcntype, statusId, 0)

        Dim filetemplate As String = bao._PATH_PDF_TEMPLATE & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)

        LOAD_XML_PDF(Path_XML, filetemplate, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    ''' <summary>
    ''' ใส่ค่าในฟิลที่ null
    ''' </summary>
    ''' <param name="ob"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Function AddValue(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()

            '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, " ", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.Double".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.float".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else
                    Try
                        props.SetValue(ob, 0, Nothing)
                    Catch ex As Exception
                        props.SetValue(ob, Nothing, Nothing)
                    End Try


                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
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
End Class