Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_REGISTRATION_CONFIRM_STAFF
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            UC_GRID_ATTACH.load_gv(_IDA)
            BindData_PDF()
            txt_app_date.Text = Date.Now.ToShortDateString()
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_MAS_STATUS_STAFF()
        Dim int_group_ddl As Integer = 3
        Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        dao_la.GetDataby_IDA(_IDA)

        'If dao_la.fields.STATUS_ID <= 2 Then
        '    int_group_ddl = 1
        'ElseIf dao_la.fields.STATUS_ID > 2 And dao_la.fields.STATUS_ID < 6 Then
        '    int_group_ddl = 2
        'ElseIf dao_la.fields.STATUS_ID >= 6 Then
        '    int_group_ddl = 3
        'End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub

    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("RCVNO", "DRUG_REGISTRATION")

        Try
            rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1
        Catch ex As Exception

        End Try


        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim statusID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim bao As New BAO.GenNumber
        Dim rcvno As String = bao.GEN_NO_06(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _CLS.LCNNO, "", "", _IDA, "")
        Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 5 'บัญชีทะเบียนยาคนและสัตว์
        dao_date.fields.STATUS_ID = statusID
        dao_date.fields.DATE_NOW = Date.Now
        'dao_date.fields.PROCESS_ID = _Process
        dao_date.insert()

        If statusID = "7" Then
            dao.fields.STATUS_ID = statusID
            Try
                dao.fields.rcvdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "8" Then
            dao.fields.STATUS_ID = statusID
            Try
                dao.fields.rcvdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.rcvno = rcvno
            dao.update()
            alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว คุณได้เลขรับที่ " & rcvno)
        End If


        'Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim rcvno As Integer = run_rcvno()
        'dao.GetDataby_IDA(Integer.Parse(_IDA))
        'dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        'dao.fields.rcvno = rcvno
        'dao.update()
        'alert("เลขรับ คือ " + rcvno.ToString())
    End Sub
 Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
       Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Dim dao_TR As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao_TR.GetDataby_IDA(dao.fields.TR_ID)

        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
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
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
    End Sub

    
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn

        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)

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
        class_xml = cls_regis.gen_xml()

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)

        Catch ex As Exception

        End Try
        Dim dao_color As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
        dao_color.GetDataby_FK_IDA(_IDA)
        class_xml.DRUG_REGISTRATION_COLORs = dao_color.fields
        Try
            class_xml.DRUG_REGISTRATIONs = dao.fields
        Catch ex As Exception

        End Try
        Dim lcnno As String = ""
        Try
            'lcnno_raw = dao_lcn.fields.LCNNO_DISPLAY
            'If lcnno_raw <> "" Then
            lcnno = dao_lcn.fields.lcntpcd & " " & CInt(Right(dao_lcn.fields.lcnno, 5)) & "/25" & Left(dao_lcn.fields.lcnno, 2)
            'End If
        Catch ex As Exception

        End Try
        class_xml.SHOW_LCNNO = lcnno
        p_REGISTRATION = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
End Class