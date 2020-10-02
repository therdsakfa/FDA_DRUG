Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class FRM_LCN_STAFF_IMPORT_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private Sub RunQuery()
        _ProcessID = 101
        _CLS = Session("CLS")
        _IDA = Request.QueryString("IDA")
        '_ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            BindData_PDF()

            Bind_ddl_Status_staff()
            load_fdpdtno()
            UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv(_IDA)
        End If

    End Sub
    Sub load_fdpdtno()
        Dim bao As New BAO.ClsDBSqlcommand
        'lbl_fdpdtno.Text = get_fdpdtno().Substring(0, 2) & "-" & get_fdpdtno().Substring(2, 1) & "-" & get_fdpdtno().Substring(3, 5) & "-" & get_fdpdtno().Substring(8, 1) & "-"
        'lbl_fdpdtno2.Text = _CLS.IDA    'ปรับให้runno

    End Sub
    Function get_fdpdtno() As String
        Dim fdpdtno As String = String.Empty
        Dim pvncd As String = String.Empty
        Dim lcntypecd As String = String.Empty
        Dim lcnno_num As String = String.Empty
        Dim tpye As String = String.Empty
        Dim REF_NO As String = String.Empty
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim bao As New BAO.ClsDBSqlcommand
        dao_up.GetDataby_IDA(_CLS.IDA)
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        pvncd = dao.fields.pvncd.ToString()
        lcntypecd = dao.fields.lcntpcd.ToString()
        lcnno_num = dao.fields.lcnno.ToString().Trim().Substring(2, 5)
        If _CLS.PVCODE = 10 Then
            If lcntypecd = "1" Then
                tpye = "1"
            ElseIf lcntypecd = "2" Then
                tpye = "3"
            End If
        Else
            If lcntypecd = "1" Then
                tpye = "2"
            ElseIf lcntypecd = "2" Then
                tpye = "4"
            End If
        End If
        fdpdtno = pvncd & lcntypecd & lcnno_num & tpye
        Return fdpdtno
    End Function

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim fdpdtno As String = String.Empty
        Dim num As Integer = 0
        Dim str_num As String = String.Empty

        Dim bao_gen As New BAO.GenNumber
        Dim rcvno As String = ""

        rcvno = bao_gen.GEN_LCNNO_RCVNO(_IDA, _CLS.PVCODE, 0)
        'str_num = String.Format("{0:0000}", num.ToString("0000"))
        'fdpdtno = str_num
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(_TR_ID)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        dao.fields.lcnno = rcvno 'fdpdtno
        dao.fields.STATUS_ID = Integer.Parse(ddl_cnsdcd.SelectedItem.Value())
        dao.fields.cnccd = 1
        dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao.update()
        Dim xmlname As String = NAME_OUTPUT_PDF("DA", _ProcessID, dao_up.fields.YEAR, dao_up.fields.ID)
        BindData_PDF()
        alert("ยืนยันเรียบร้อยแล้ว")

    End Sub

    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_MAS_STATUS_STAFF_BY_GROUP(2)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
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
        'UC_CONFIRM.load_SORBOR5(p2)
    End Sub


    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF_Output(ByVal filename As String)
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & "PDFdalcn_output_5.pdf") 'C:\path\PDF_TEMPLATE\
    '        Using outputStream = New FileStream(bao._PATH_PDF_TRADER & filename & "-output.pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset


    'End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)




        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao.fields.lcntpcd, dao.fields.pvncd)

        Dim class_xml As New CLASS_DALCN
        class_xml = cls_dalcn.gen_xml()

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.dalcns = dao.fields
        Catch ex As Exception

        End Try



        p_dalcn = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd
       Dim PROCESS_ID As String = _ProcessID
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub



End Class