Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_DI_STAFF_SELECT_COMPANY
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunSession()
        Try
            _ProcessID = 6
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
        ' UC_GRID_ATTACH1.load_gv(_TR_ID)
        If Not IsPostBack Then
            BindData_PDF()
            show_btn()
        End If
    End Sub
    Private Sub show_btn()

        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)
        'If dao.fields.cnsdcd <> 1 Then
        '    btn_confirm.Enabled = False
        '    btn_cancel.Enabled = False
        '    btn_confirm.CssClass = "btn-lg btn-danger"
        '    btn_cancel.CssClass = "btn-lg btn-danger"
        '    '  btn_cancel.Enabled = False
        'End If


    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)
        'If dao.fields.STATUS_ID <> -1 Then

        '    btn_confirm.Enabled = False
        '    btn_cancel.Enabled = False
        '    btn_confirm.CssClass = "btn-danger btn-lg"
        '    btn_cancel.CssClass = "btn-danger btn-lg"
        'End If


    End Sub
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "lgt_impcer")

        Try
            rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1
        Catch ex As Exception

        End Try


        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(Integer.Parse(_IDA))
        'dao.fields.Somefield
        dao.update()
        alert("บันทึกเรียบร้อย")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(Integer.Parse(_IDA))
        Dim dao_TR As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_TR.GetDataby_IDA(Integer.Parse(_IDA))
        'If dao.fields.lcnscd = 11 Then
        '    fusion_XML_To_PDF("DA-41-2558-" & _IDA.ToString())
        'Else
        load_pdf(_CLS.PDFNAME, _CLS.FILENAME_PDF)
        'End If
    End Sub

    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_pdf(ByVal path As String, ByVal fileName As String)
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
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_CER
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()


        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)



        Dim cls_regis As New CLASS_GEN_XML.Cer(_CLS.CITIZEN_ID, dao.fields.LCNSID, 1, dao.fields.FK_IDA)

        Dim class_xml As New CLASS_CER
        class_xml = cls_regis.gen_xml_CER()

        Try
            'Dim rcvdate As Date = dao.fields.rcvdate
            'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.CERs = dao.fields
        Catch ex As Exception

        End Try

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try

        ' p_ = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = bao._PATH_PDF_TEMPLATE 'paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = bao._PATH_PDF_TRADER & NAME_PDF("DA", _ProcessID, _YEARS, dao.fields.TR_ID) 'paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = bao._PATH_XML_TRADER & NAME_XML("DA", _ProcessID, _YEARS, dao.fields.TR_ID) 'paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.PDFNAME = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, dao.fields.TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
End Class