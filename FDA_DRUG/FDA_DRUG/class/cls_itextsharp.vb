Imports System
Imports System.IO
Imports System.Web.UI
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.BaseColor

Namespace cls_itextsharp
    Public Class MyFontFactoryImpl
        Inherits FontFactoryImp
        Public defaultFont As Font
        Public Sub New()

            Dim tahoma As BaseFont = BaseFont.CreateFont("C:\WINDOWS\Fonts\tahoma.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)
            defaultFont = New Font(tahoma, 12)
        End Sub
        Public Overrides Function GetFont(ByVal fontname As String, ByVal encoding As String, ByVal embedded As [Boolean], ByVal size As Single, ByVal style As Integer, ByVal color As BaseColor, _
         ByVal cached As [Boolean]) As Font
            Return defaultFont
        End Function
    End Class

    Public Class HtmlToPdf
        Private _html As String
        Public Sub New(ByVal html As String)
            If Not (TypeOf FontFactory.FontImp Is MyFontFactoryImpl) Then
                FontFactory.FontImp = New MyFontFactoryImpl()
            End If
            _html = html
        End Sub

        Private _Pdf_doc As Byte
        Public Property Pdf_doc() As Byte
            Get
                Return _Pdf_doc
            End Get
            Set(ByVal value As Byte)
                _Pdf_doc = value
            End Set
        End Property


        Public Sub HTML_TO_PDF(ByVal response As HttpResponse)
            response.ContentType = "application/pdf"
            response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf")
            response.Cache.SetCacheability(HttpCacheability.NoCache)
            Dim ss As String = _html
            Dim sr As New StringReader(ss)
            Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
            Dim htmlparser As New HTMLWorker(pdfDoc)
            PdfWriter.GetInstance(pdfDoc, response.OutputStream)
            pdfDoc.Open()
            htmlparser.Parse(sr)
            pdfDoc.Close()

            response.Write(pdfDoc)
            'response.[End]()
        End Sub


        Public Sub Render(ByVal stream As Stream)
            Dim sr As New StringReader(_html)
            Dim pdfDoc As New Document()
            PdfWriter.GetInstance(pdfDoc, stream)
            Dim htmlparser As New HTMLWorker(pdfDoc)

            pdfDoc.Open()
            htmlparser.Parse(sr)
            pdfDoc.Close()

        End Sub

        Public Sub Render(ByVal response As HttpResponse, ByVal fileName As String)
            response.Clear()
            response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", fileName))
            response.ContentType = "application/pdf"

            Render(response.OutputStream)

            response.[End]()
        End Sub
    End Class

    Public Class TableToPdf
        'Private _html As String
        'Public Sub New(ByVal html As String)
        '    If Not (TypeOf FontFactory.FontImp Is MyFontFactoryImpl) Then
        '        FontFactory.FontImp = New MyFontFactoryImpl()
        '    End If
        '    _html = html
        'End Sub
        Private Function getmaxcolumn(ByVal t As Table) As Integer
            Dim TempCell As Integer = 0
            For Each TC As TableCell In t.Rows(0).Cells
                If TC.ColumnSpan = 0 Then
                    TempCell += 1
                Else 'if Merge cell
                    TempCell += TC.ColumnSpan
                End If
            Next
            Return TempCell
        End Function
        Private Function getmaxrow(ByVal t As Table) As Integer
            Dim temprow As Integer = 0
            For Each tr As TableRow In t.Rows
                If tr.Cells(0).RowSpan = 0 Then
                    temprow += 1
                Else
                    temprow += tr.Cells(0).RowSpan
                End If
            Next
            Return temprow
        End Function

        Private Function getall_by_width_column(ByVal t As Table) As Single()
            Dim tr As New TableRow
            Dim tc As New TableCell
            Dim maxcolumn As Integer = getmaxcolumn(t)
            For i = 0 To maxcolumn - 1
                tc = New TableCell
                tr.Controls.Add(tc)
            Next
            t.Controls.Add(tr)

            Dim arraycolumn As Single()
            ReDim arraycolumn(maxcolumn - 1)

            Dim maxrow As Integer = getmaxrow(t)
            For i = 0 To maxcolumn - 1
                arraycolumn(i) = CSng(t.Rows(maxrow - 1).Cells(i).Width.Value)

            Next
            Return arraycolumn
        End Function

#Region "โค้ดเกี่ยวกับ convert table to pdf"
        ' ''' <summary>
        ' ''' Function create pdf from table set path and add watermark
        ' ''' </summary>
        ' ''' <param name="response"></param>
        ' ''' <param name="t"></param>
        ' ''' <param name="fileName"></param>
        ' ''' <param name="text_watermark"></param>
        ' ''' <param name="columnwidth"></param>
        ' ''' <remarks></remarks>
        'Public Overloads Sub TableToPdf(ByVal response As HttpResponse, ByVal t As Table, ByVal fileName As String, ByVal text_watermark As String)

        '    Dim pdfDoc As New Document()

        '    Dim M As New MemoryStream

        '    PdfWriter.GetInstance(pdfDoc, M)

        '    Dim table As New PdfPTable(getmaxcolumn(t))
        '    table.SetWidthPercentage(getall_by_width_column(t), iTextSharp.text.PageSize.A4)
        '    pdfDoc.Open()
        '    For Each tr As TableRow In t.Rows
        '        For Each tc As TableCell In tr.Cells
        '            Dim d As New MyFontFactoryImpl
        '            Dim cell As New PdfPCell(New Phrase(tc.Text, d.defaultFont))

        '            cell.Colspan = tc.ColumnSpan
        '            If tc.RowSpan <> 0 Then
        '                cell.Rowspan = tc.RowSpan
        '            End If

        '            cell.HorizontalAlignment = tc.HorizontalAlign - 1
        '            cell.VerticalAlignment = tc.VerticalAlign - 1
        '            cell.BorderWidth = tc.BorderWidth.Value


        '            If tc.BackColor.Name <> "0" Then
        '                Dim CC As New iTextSharp.text.BaseColor(tc.BackColor)
        '                cell.BackgroundColor = CC
        '            End If
        '            table.AddCell(cell)
        '        Next
        '    Next
        '    pdfDoc.Add(table)

        '    pdfDoc.Close()

        '    Dim file_full_name As String = "C:\" & fileName & "_" & Date.Now.ToShortDateString.Replace("/", "_")


        '    'Dim L As Long = response.OutputStream.Length
        '    'Dim Dd As Byte()
        '    'response.OutputStream.Read(Dd, 1, response.OutputStream.Length)
        '    'Dim b As New BinaryReader()
        '    'Dd = b.BaseStream
        '    Dim addwatermark As New AddWaterMark()
        '    addwatermark.AddWatermarkText(response, M.ToArray, text_watermark)

        '    'response.[End]()
        'End Sub

        ' ''' <summary>
        ' ''' Function create pdf from table set path and not add watermark
        ' ''' </summary>
        ' ''' <param name="response"></param>
        ' ''' <param name="t"></param>
        ' ''' <param name="fileName"></param>
        ' ''' <param name="columnwidth"></param>
        ' ''' <remarks></remarks>
        'Public Overloads Sub TableToPdf(ByVal response As HttpResponse, ByVal t As Table, ByVal fileName As String, ByVal columnwidth As Single())

        '    response.Clear()
        '    response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", fileName))
        '    response.ContentType = "application/pdf"
        '    Dim pdfDoc As New Document()
        '    PdfWriter.GetInstance(pdfDoc, response.OutputStream)

        '    Dim table As New PdfPTable(getmaxcolumn(t))

        '    'Dim C() As Single = {100, 300, 100}
        '    'table.TotalWidth = 500
        '    table.SetWidthPercentage(columnwidth, itextsharp.text.PageSize.A4)
        '    'table.SetWidthPercentage(getall_by_width_column(t), iTextSharp.text.PageSize.A4)
        '    'table.SetWidthPercentage()
        '    pdfDoc.Open()
        '    For Each tr As TableRow In t.Rows
        '        For Each tc As TableCell In tr.Cells
        '            Dim d As New MyFontFactoryImpl
        '            Dim cell As New PdfPCell(New Phrase(tc.Text, d.defaultFont))

        '            cell.Colspan = tc.ColumnSpan
        '            If tc.RowSpan <> 0 Then
        '                cell.Rowspan = tc.RowSpan
        '            End If

        '            cell.HorizontalAlignment = tc.HorizontalAlign - 1
        '            cell.VerticalAlignment = tc.VerticalAlign - 1
        '            cell.BorderWidth = tc.BorderWidth.Value


        '            If tc.BackColor.Name <> "0" Then
        '                Dim CC As New itextsharp.text.BaseColor(tc.BackColor)
        '                cell.BackgroundColor = CC
        '            End If
        '            table.AddCell(cell)
        '        Next
        '    Next
        '    pdfDoc.Add(table)

        '    pdfDoc.Close()
        '    response.[End]()
        'End Sub

        ' ''' <summary>
        ' ''' Function create pdf from table not set path to save(default save in directory C:\) and not add watermark
        ' ''' </summary>
        ' ''' <param name="t"></param>
        ' ''' <param name="fileName"></param>
        ' ''' <param name="columnwidth"></param>
        ' ''' <remarks></remarks>
        'Public Overloads Sub TableToPdf(ByVal t As Table, ByVal fileName As String, ByVal columnwidth As Single())
        '    Dim file_full_name As String = "C:\" & fileName & "_" & Date.Now.ToShortDateString.Replace("/", "_")
        '    'response.Clear()
        '    'response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file_full_name))
        '    'response.ContentType = "application/pdf"
        '    Dim pdfDoc As New Document()
        '    'PdfWriter.GetInstance(pdfDoc, response.OutputStream)

        '    PdfWriter.GetInstance(pdfDoc, New System.IO.FileStream(file_full_name & ".pdf", System.IO.FileMode.Create))

        '    Dim table As New PdfPTable(getmaxcolumn(t))

        '    'Dim C() As Single = {100, 300, 100}
        '    'table.TotalWidth = 500
        '    'table.SetWidthPercentage(iTextSharp.text.PageSize.A4)
        '    'table.SetWidthPercentage(getall_by_width_column(t), iTextSharp.text.PageSize.A4)
        '    'table.SetWidthPercentage()
        '    pdfDoc.Open()
        '    For Each tr As TableRow In t.Rows
        '        For Each tc As TableCell In tr.Cells
        '            Dim d As New MyFontFactoryImpl
        '            Dim cell As New PdfPCell(New Phrase(tc.Text, d.defaultFont))
        '            'Dim dd As Single = 100
        '            'cell.Width = dd
        '            cell.Colspan = tc.ColumnSpan
        '            If tc.RowSpan <> 0 Then
        '                cell.Rowspan = tc.RowSpan
        '            End If

        '            cell.HorizontalAlignment = tc.HorizontalAlign - 1
        '            cell.VerticalAlignment = tc.VerticalAlign - 1
        '            cell.BorderWidth = tc.BorderWidth.Value


        '            If tc.BackColor.Name <> "0" Then
        '                Dim CC As New itextsharp.text.BaseColor(tc.BackColor)
        '                cell.BackgroundColor = CC
        '            End If
        '            table.AddCell(cell)
        '        Next
        '    Next
        '    pdfDoc.Add(table)

        '    pdfDoc.Close()

        '    'Dim addwatermark As New AddWaterMark()
        '    'addwatermark.AddWatermarkText(file_full_name)

        '    'response.[End]()

        'End Sub


   


        Public Sub TableToPdf(ByVal t As Table, ByVal fileName As String)
            Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
            bao_app.RunAppSettings()

            Dim file_full_name As String = bao_app._PATH_DEFAULT & fileName & "_" & Date.Now.ToShortDateString.Replace("/", "_")
            'response.Clear()
            'response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file_full_name))
            'response.ContentType = "application/pdf"
            Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
            'Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
            'PdfWriter.GetInstance(pdfDoc, response.OutputStream)

            PdfWriter.GetInstance(pdfDoc, New System.IO.FileStream(file_full_name & ".pdf", System.IO.FileMode.Create))

            Dim table As New PdfPTable(getmaxcolumn(t))

            'Dim C() As Single = {100, 300, 100}
            'table.TotalWidth = 500
            'table.SetWidthPercentage(iTextSharp.text.PageSize.A4)
            'table.SetWidthPercentage(getall_by_width_column(t), iTextSharp.text.PageSize.A4)
            'table.SetWidthPercentage()
            pdfDoc.Open()
            For Each tr As TableRow In t.Rows
                'For i As Integer = 0 To tr.Cells.Count - 1
                '    If i <> 8 And i <> 9 Then
                '        'Dim tc As New TableCell
                '        Dim d As New MyFontFactoryImpl
                '        Dim cell As New PdfPCell(New Phrase(tr.Cells(i).Text, d.defaultFont))
                '        cell.Colspan = tr.Cells(i).ColumnSpan
                '        If tr.Cells(i).RowSpan <> 0 Then
                '            cell.Rowspan = tr.Cells(i).RowSpan
                '        End If

                '        cell.HorizontalAlignment = tr.Cells(i).HorizontalAlign - 1
                '        cell.VerticalAlignment = tr.Cells(i).VerticalAlign - 1
                '        cell.BorderWidth = tr.Cells(i).BorderWidth.Value


                '        If tr.Cells(i).BackColor.Name <> "0" Then
                '            Dim CC As New iTextSharp.text.BaseColor(tr.Cells(i).BackColor)
                '            cell.BackgroundColor = CC
                '        End If
                '        table.AddCell(cell)
                '    End If
                'Next

                For Each tc As TableCell In tr.Cells

                    Dim d As New MyFontFactoryImpl
                    Dim cell As New PdfPCell(New Phrase(tc.Text, d.defaultFont))
                    cell.Colspan = tc.ColumnSpan
                    If tc.RowSpan <> 0 Then
                        cell.Rowspan = tc.RowSpan
                    End If

                    cell.HorizontalAlignment = tc.HorizontalAlign - 1
                    cell.VerticalAlignment = tc.VerticalAlign - 1
                    cell.BorderWidth = tc.BorderWidth.Value


                    If tc.BackColor.Name <> "0" Then
                        Dim CC As New iTextSharp.text.BaseColor(tc.BackColor)
                        cell.BackgroundColor = CC
                    End If
                    table.AddCell(cell)
                Next
            Next
            pdfDoc.Add(table)

            pdfDoc.Close()
        End Sub
#End Region
    End Class

    Public Class AddWaterMark

        Private Function GetHypotenuseAngleInDegreesFrom(ByVal height As Double, ByVal width As Double) As Double
            Dim radians As Double = Math.Atan2(height, width)
            Dim angle As Double = radians * (180 / Math.PI)
            Return angle
        End Function
        ''' <summary>
        ''' function add water mark(path_of_sourcefile,text_watermark)
        ''' </summary>
        ''' <param name="sourceFile"></param>
        ''' <param name="text_watermark"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub AddWatermarkText(ByVal sourceFile As String, ByVal text_watermark As String)
            '//Dim pdfDoc As New Document()

            Dim reader As New PdfReader(sourceFile & ".pdf")
            Dim filename_addwatermark = sourceFile & "(complete)" & ".pdf"

            If text_watermark <> "" Then
                text_watermark = text_watermark
            Else 'if text_watermark not add
                text_watermark = Date.Now.ToShortDateString
            End If

            Dim stamper As New PdfStamper(reader, New System.IO.FileStream(filename_addwatermark, System.IO.FileMode.Create))
            For i = 1 To reader.NumberOfPages
                Dim pagesize As Rectangle = reader.GetPageSizeWithRotation(1)
                Dim pdfPageContents As PdfContentByte = stamper.GetUnderContent(i)
                pdfPageContents.BeginText()
                Dim basefont As BaseFont = basefont.CreateFont("C:\WINDOWS\Fonts\tahoma.ttf", basefont.IDENTITY_H, basefont.NOT_EMBEDDED)
                pdfPageContents.SetFontAndSize(basefont, 24)
                pdfPageContents.SetRGBColorFill(205, 200, 100)
                Dim textAngle As Double
                Dim angle As New AddWaterMark
                textAngle = angle.GetHypotenuseAngleInDegreesFrom(pagesize.Height, pagesize.Width)
                pdfPageContents.ShowTextAligned(PdfContentByte.ALIGN_CENTER, text_watermark, pagesize.Width / 2, pagesize.Height / 2, textAngle)
            Next

            Dim fFile1 As New FileInfo(sourceFile)
            If fFile1.Exists Then
                System.IO.File.Delete(sourceFile)
            End If

            stamper.FormFlattening = True
            stamper.Close()
            reader.Close()

        End Sub
        ''' <summary>
        ''' function add watermark(HttpResponse,binary,text_watermark)
        ''' </summary>
        ''' <param name="Res"></param>
        ''' <param name="File"></param>
        ''' <param name="text_watermark"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub AddWatermarkText(ByRef Res As HttpResponse, ByVal File As Byte(), ByVal text_watermark As String)
            '//Dim pdfDoc As New Document()

            Res.Clear()
            Res.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Date.Now.ToShortDateString.Replace("/", "_") & ".pdf"))
            Res.ContentType = "application/pdf"

            Dim reader As New PdfReader(File)
            'Dim filename_addwatermark = sourceFile & "(complete)" & ".pdf"

            If text_watermark <> "" Then
                text_watermark = text_watermark
            Else 'if text_watermark not add
                text_watermark = Date.Now.ToShortDateString
            End If
            Dim stamper As New PdfStamper(reader, Res.OutputStream)
            For i = 1 To reader.NumberOfPages
                Dim pagesize As Rectangle = reader.GetPageSizeWithRotation(1)
                Dim pdfPageContents As PdfContentByte = stamper.GetUnderContent(i)
                pdfPageContents.BeginText()

                Dim basefont As BaseFont = basefont.CreateFont("C:\WINDOWS\Fonts\tahoma.ttf", basefont.IDENTITY_H, basefont.NOT_EMBEDDED)
                pdfPageContents.SetFontAndSize(basefont, 24)
                pdfPageContents.SetRGBColorFill(205, 200, 100)
                Dim textAngle As Double
                Dim angle As New AddWaterMark
                textAngle = angle.GetHypotenuseAngleInDegreesFrom(pagesize.Height, pagesize.Width)

                pdfPageContents.ShowTextAligned(PdfContentByte.ALIGN_CENTER, text_watermark, pagesize.Width / 2, pagesize.Height / 2, textAngle)
            Next

            'Dim fFile1 As New FileInfo(sourceFile)
            'If fFile1.Exists Then
            '    System.IO.File.Delete(sourceFile)
            'End If

            stamper.FormFlattening = True
            stamper.Close()
            reader.Close()


            Res.End()

        End Sub
    End Class
End Namespace
