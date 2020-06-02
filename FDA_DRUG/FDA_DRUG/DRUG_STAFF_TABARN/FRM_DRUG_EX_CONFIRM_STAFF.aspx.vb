Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Public Class FRM_DRUG_EX_CONFIRM_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private Sub RunQuery()
        _CLS = Session("CLS")
        _IDA = Request.QueryString("IDA")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            Try

                lr_preview.Text = "<iframe id='iframe1'  style='height:500px;width:100%;' src='../PDF/FRM_PDF.aspx?ID=" & _IDA & "&ID_transection=0&PROCESS_ID=41&STATUS=0' ></iframe>"

            Catch ex As Exception

            End Try
            Bind_ddl_Status()
            load_fdpdtno()

            UC_GRID_ATTACH1.load_gv(_IDA)
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
    Public Sub Bind_ddl_Status()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_STATUS_BY_GROUP(1)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataBind()
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.FAGenID("fdpdtno", "fregntf")
        Dim fdpdtno As String = String.Empty
        Dim num As Integer
        Dim str_num As String = String.Empty

        str_num = String.Format("{0:0000}", num.ToString("0000"))
        fdpdtno = str_num 'get_fdpdtno() & str_num
        '-------------------------
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(_IDA)
        dao.fields.lcnno = fdpdtno
        dao.fields.cnccscd = Integer.Parse(ddl_cnsdcd.SelectedValue())
        dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao.fields.cnccd = 1
        dao.update()

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        'dao_date.fields.DATE_CONNECT
        dao_date.fields.STATUS_DATE = Date.Now
        dao_date.fields.STATUS_GROUP = 1
        dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue

        dao_date.insert()
        alert("ยืนยันเรียบร้อยแล้ว")

    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")

    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>self.close(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click

    End Sub

    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF(ByVal filename As String)
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()
    '    Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & "PDFfregntfjod.pdf") 'C:\path\PDF_TEMPLATE\
    '        Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset

    '    Response.Clear()
    '    Response.ContentType = "Application/pdf"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
    '    Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

    '    Response.Flush()
    '    Response.Close()
    '    Response.End()
    'End Sub

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
    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF(ByVal filename As String)
    '    Dim path As String = "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader("C:\path\PDF_TEMPLATE\PDFfregntfjod.pdf")
    '        Using outputStream = New FileStream("C:\path\PDF_XML_CLASS\" & filename & ".pdf", FileMode.Create, FileAccess.Write)
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset

    '    Response.Clear()
    '    Response.ContentType = "Application/pdf"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=PDFfregntfjod.pdf")
    '    Response.BinaryWrite(clsds.UpLoadImageByte("C:\path\PDF_XML_CLASS\" & filename & ".pdf"))

    '    Response.Flush()
    '    Response.Close()
    '    Response.End()
    'End Sub

    ' ''' <summary>
    ' ''' รวม XML เข้าไปที่ PDFจดแจ้งรายละเอียด
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub fusion_XML_To_PDF2(ByVal filename As String)
    '    Dim path As String = "C:\path\XML_TRADER\"
    '    path = path & filename & ".xml"
    '    Using pdfReader__1 = New PdfReader("C:\path\PDF_TEMPLATE\PDFfregntfjang.pdf")
    '        Using outputStream = New FileStream("C:\path\PDF_XML_CLASS\" & filename & ".pdf", FileMode.Create, FileAccess.Write)
    '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
    '                stamper.AcroFields.Xfa.FillXfaForm(path)
    '            End Using
    '        End Using
    '    End Using

    '    Dim clsds As New ClassDataset

    '    Response.Clear()
    '    Response.ContentType = "Application/pdf"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=PDFfregntfjang.pdf")
    '    Response.BinaryWrite(clsds.UpLoadImageByte("C:\path\PDF_XML_CLASS\" & filename & ".pdf"))

    '    Response.Flush()
    '    Response.Close()
    '    Response.End()

    'End Sub

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
    Protected Sub ddl_cnsdcd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_cnsdcd.SelectedIndexChanged

    End Sub

    ''' <summary>
    ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF_Output(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_TRADER & filename & "-output.pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

    End Sub

End Class