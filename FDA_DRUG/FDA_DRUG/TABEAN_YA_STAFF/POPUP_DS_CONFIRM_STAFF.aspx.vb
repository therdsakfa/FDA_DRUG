﻿Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_DS_CONFIRM_STAFF
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Sub RunSession()
        Try
            _ProcessID = _ProcessID
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            lr_preview.Text = "<iframe id='iframe10'  style='height:500px;width:100%;' src='../PDF/FRM_PDF.aspx?ID=" & _IDA & "&ID_transection=" & _TR_ID & "&PROCESS_ID=1" & "&STATUS=" & load_STATUS() & "' ></iframe>"

            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)
            Bind_ddl_Status_staff()
        End If
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_MAS_STATUS_STAFF()
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataBind()
    End Sub
    'Public Sub Bind_ddl_Status()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_STATUS_BY_GROUP(1)
    '    dt = bao.dt

    '    ddl_cnsdcd.DataSource = dt
    '    ddl_cnsdcd.DataBind()
    'End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID <> -1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "drsamp")

        Try
            rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1
        Catch ex As Exception

        End Try


        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.FAGenID("rcvno", "fregntf")
        Dim rcvno As Integer = run_rcvno()
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao.fields.RCVNO = rcvno
        'dao.fields.regntfno = regntfno
        dao.update()
        alert("เลขรับ คือ " + rcvno.ToString())
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');self.close();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type langue =javascript>")
        Response.Write("window.location.href = 'FRM_LCN.aspx';")
        Response.Write("</script type >")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

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

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()


        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)



        Dim cls_regis As New CLASS_GEN_XML.DS(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao.fields.lcntpcd, dao.fields.pvncd)

        Dim class_xml As New CLASS_DS
        class_xml = cls_regis.gen_xml()

        Try
            Dim rcvdate As Date = dao.fields.RCVDATE
            dao.fields.RCVDATE = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.drsamps = dao.fields
        Catch ex As Exception

        End Try

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try

        p_ds = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/PDF_PERVIEW2.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
End Class
