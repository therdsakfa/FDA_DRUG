Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_RESEARCH_SUM_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _FK_IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunSession()
        Try
            '_ProcessID = Request.QueryString("ProcessID")
            _ProcessID = "10261"
            _IDA = Request.QueryString("IDA")
            _FK_IDA = Request.QueryString("FK_IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        UC_GRID_ATTACH.load_gv(_TR_ID)
        show_btn()
        If Not IsPostBack Then
            lr_preview.Text = "<iframe id='iframe1'  style='height:500px;width:100%;' src='../DRUG_IMPORT/POPUP_RESEARCH_SUM.aspx?IDA=" & _IDA & "' ></iframe>"

            'btn_bill_pay.Enabled = False

        End If
    End Sub
    Private Sub show_btn()

        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_IDA(_IDA)
        'If dao.fields.STATUS_ID <> 1 Then
        '    btn_confirm.Enabled = False
        '    btn_cancel.Enabled = False
        '    btn_confirm.CssClass = "btn-lg btn-danger"
        '    btn_cancel.CssClass = "btn-lg btn-danger"
        '    '  btn_cancel.Enabled = False
        'End If
        If dao.fields.STATUS_ID = 1 Then
            btn_bill_pay.Text = "พิมพ์ใบสั่งชำระค่ายื่นคำขอ"
        ElseIf dao.fields.STATUS_ID = 2 Then
            payment_status.Text = "รอการชำระค่ายื่นคำขอ"
        ElseIf dao.fields.STATUS_ID = 3 Then
            payment_status.Visible = True
            payment_status.Text = "ชำระค่ายื่นคำขอแล้ว"
            btn_bill_pay.CssClass = "btn-lg btn-danger"
            btn_bill_pay.Attributes.Add("disabled", "disabled")
            btn_bill_pay.Text = "พิมพ์ใบสั่งชำระค่าพิจารณา"
            'ElseIf dao.fields.STATUS_ID = 4 Then

        ElseIf dao.fields.STATUS_ID = 4 Then
            payment_status.Visible = True
            payment_status.Text = "ชำระค่าพิจารณาแล้ว"
            btn_bill_pay.CssClass = "btn-lg btn-danger"
            btn_bill_pay.Attributes.Add("disabled", "disabled")
        Else
            btn_bill_pay.CssClass = "btn-lg btn-danger"
            btn_bill_pay.Attributes.Add("disabled", "disabled")
        End If

    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function


    'Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click

    '    Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
    '    dao.GetDataby_IDA(Integer.Parse(_IDA))
    '    dao.fields.STATUS_ID = 3
    '    AddLogStatus(3, Request.QueryString("ProcessID"), _CLS.CITIZEN_ID)
    '    dao.update()

    '    alert("ยื่นคำขอเรียบร้อยแล้ว")

    'End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        'Dim bao As New BAO.GenNumber
        'Dim cernumber As String = bao.GEN_CER_NO(con_year(Date.Now.Year.ToString()), _CLS.PVCODE(), _ProcessID, _CLS.LCNNO, "1", "1", _IDA, "")
        'Dim rcvno As String = bao.GEN_CER_NO(con_year(Date.Now.Year.ToString()), _CLS.PVCODE(), _ProcessID, _CLS.LCNNO, "1", "2", _IDA, "")

        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        AddLogStatus(7, Request.QueryString("ProcessID"), _CLS.CITIZEN_ID, _IDA)
        dao.update()
        Response.Write("<script type='text/javascript'>close_modal();</script> ")
    End Sub

    'Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
    '    Dim dao As New DAO_DRUG.TB_CER_FOREIGN
    '    dao.GetDataby_IDA(Integer.Parse(_IDA))
    '    Dim dao_TR As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    dao_TR.GetDataby_IDA(Integer.Parse(dao.fields.TR_ID))
    '    'If dao.fields.lcnscd = 11 Then
    '    '    fusion_XML_To_PDF("DA-41-2558-" & _IDA.ToString())
    '    'Else
    '    ' fusion_XML_To_PDF("DA-" & dao_TR.fields.PROCESS_ID & "-" & dao_TR.fields.YEAR & "-" & _IDA.ToString())
    '    load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    '    'End If
    'End Sub
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal filename As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename)
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
        Dim p2 As New CLASS_CER_FOREIGN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    'Private Sub BindData_PDF()
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()

    '    Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
    '    dao.GetDataby_IDA(_IDA)

    '    Dim class_xml As New CLASS_PROJECT_SUM
    '    class_xml.DRUG_PROJECT_SUMMARY = dao.fields

    '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    dao_up.GetDataby_IDA(dao.fields.TR_ID)

    '    '_______________SHOW___________________
    '    Dim bao_show As New BAO_SHOW
    '    'ชื่อผู้ใช้ระบบ
    '    class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
    '    'ชื่อบริษัท
    '    class_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID_CUSTOMER)

    '    Dim dao_research As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
    '    dao_research.GetDataby_PROJECT(_IDA)
    '    For Each dao_research.datas In dao_research.datas
    '        class_xml.DRUG_PROJECT_RESEARCH_FACILITYS.Add(dao_research.datas)
    '    Next

    '    Dim dao_dr As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
    '    dao_dr.GetDataby_PROJECT(_IDA)
    '    For Each dao_dr.datas In dao_dr.datas
    '        class_xml.DRUG_PROJECT_DRUG_LISTS.Add(dao_dr.datas)
    '    Next

    '    Dim dao_lab As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
    '    dao_lab.GetDataby_PROJECT(_IDA)
    '    For Each dao_lab.datas In dao_lab.datas
    '        class_xml.DRUG_PROJECT_CLINICAL_LABORATORYS.Add(dao_lab.datas)
    '    Next

    '    '_______________MASTER_________________
    '    Dim bao_master As New BAO_MASTER

    '    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(10261, 1, 1)

    '    Dim paths As String = bao._PATH_DEFAULT
    '    Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
    '    Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID) 'paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID) 'paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
    '    Dim bao_app As New BAO.AppSettings
    '    bao_app.RunAppSettings()

    '    Dim objStreamWriter As New StreamWriter(Path_XML)
    '    Dim x As New XmlSerializer(class_xml.GetType)
    '    x.Serialize(objStreamWriter, class_xml)
    '    objStreamWriter.Close()
    '    LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


    '    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
    '    hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
    '    _CLS.PDFNAME = filename
    '    _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    '    '    show_btn() 'ตรวจสอบปุ่ม
    'End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click

    End Sub

    Protected Sub btn_bill_pay_Click(sender As Object, e As EventArgs) Handles btn_bill_pay.Click
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_IDA(_IDA)

        If dao.fields.STATUS_ID = 1 Then
            dao.fields.STATUS_ID = 2
            'ElseIf dao.fields.STATUS_ID = 4 Then
            '    dao.fields.STATUS_ID = 5
        End If
        dao.update()
    End Sub
End Class