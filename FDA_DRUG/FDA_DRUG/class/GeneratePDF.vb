
Imports System.Collections.Generic
Imports System.Text
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports System.Collections
Imports iTextSharp.text.html
Imports System.Text.RegularExpressions

Namespace HTMLtoPDF
    Class GeneratePDF

#Region "HtmlToPdfBuilder Class"

        Public Class HtmlToPdfBuilder

#Region "Constants"

            Private Const STYLE_DEFAULT_TYPE As String = "style"
            Private Const DOCUMENT_HTML_START As String = "<html><head></head><body>"
            Private Const DOCUMENT_HTML_END As String = "</body></html>"
            Private Const REGEX_GROUP_SELECTOR As String = "selector"
            Private Const REGEX_GROUP_STYLE As String = "style"

            'amazing regular expression magic
            Private Const REGEX_GET_STYLES As String = "(?<selector>[^\{\s]+\w+(\s\[^\{\s]+)?)\s?\{(?<style>[^\}]*)\}"

#End Region

#Region "Constructors"

            ''' <summary>
            ''' Creates a new PDF document template. Use PageSizes.{DocumentSize}
            ''' </summary>
            Public Sub New(size As Rectangle)
                Me.PageSize = size
                Me._Pages = New List(Of HtmlPdfPage)()
                Me._Styles = New StyleSheet()
            End Sub

#End Region

#Region "Delegates"

            ''' <summary>
            ''' Method to override to have additional control over the document
            ''' </summary>
            Public Event BeforeRender As RenderEvent

            ''' <summary>
            ''' Method to override to have additional control over the document
            ''' </summary>
            Public Event AfterRender As RenderEvent

#End Region

#Region "Properties"

            ''' <summary>
            ''' The page size to make this document
            ''' </summary>
            Public Property PageSize() As Rectangle
                Get
                    Return m_PageSize
                End Get
                Set(value As Rectangle)
                    m_PageSize = Value
                End Set
            End Property
            Private m_PageSize As Rectangle

            ''' <summary>
            ''' Returns the page at the specified index
            ''' </summary>
            Default Public ReadOnly Property Item(index As Integer) As HtmlPdfPage
                Get
                    Return Me._Pages(index)
                End Get
            End Property

            ''' <summary>
            ''' Returns a list of the pages available
            ''' </summary>
            Public ReadOnly Property Pages() As HtmlPdfPage()
                Get
                    'http://aspnettutorialonline.blogspot.com/
                    Return Me._Pages.ToArray()
                End Get
            End Property

#End Region

#Region "Members"

            Private _Pages As List(Of HtmlPdfPage)
            Private _Styles As StyleSheet

#End Region

#Region "Working With The Document"

            ''' <summary>
            ''' Appends and returns a new page for this document http://aspnettutorialonline.blogspot.com/
            ''' </summary>
            Public Function AddPage() As HtmlPdfPage
                Dim page As New HtmlPdfPage()
                Me._Pages.Add(page)
                Return page
            End Function

            ''' <summary>
            ''' Removes the page from the document http://aspnettutorialonline.blogspot.com/
            ''' </summary>
            Public Sub RemovePage(page As HtmlPdfPage)
                Me._Pages.Remove(page)
            End Sub

            ''' <summary>
            ''' Appends a style for this sheet http://aspnettutorialonline.blogspot.com/
            ''' </summary>
            Public Sub AddStyle(selector As String, styles As String)
                Me._Styles.LoadTagStyle(selector, HtmlToPdfBuilder.STYLE_DEFAULT_TYPE, styles)
            End Sub

            ''' <summary>
            ''' Imports a stylesheet into the document
            ''' </summary>
            Public Sub ImportStylesheet(path As String)

                'load the file
                Dim content As String = File.ReadAllText(path)

                'use a little regular expression magic
                For Each match As Match In Regex.Matches(content, HtmlToPdfBuilder.REGEX_GET_STYLES)
                    Dim selector As String = match.Groups(HtmlToPdfBuilder.REGEX_GROUP_SELECTOR).Value
                    Dim style As String = match.Groups(HtmlToPdfBuilder.REGEX_GROUP_STYLE).Value
                    Me.AddStyle(selector, style)
                Next

            End Sub


#End Region

#Region "Document Navigation"

            ''' <summary>
            ''' Moves a page before another
            ''' </summary>
            Public Sub InsertBefore(page As HtmlPdfPage, before As HtmlPdfPage)
                Me._Pages.Remove(page)
                Me._Pages.Insert(Math.Max(Me._Pages.IndexOf(before), 0), page)
            End Sub

            ''' <summary>
            ''' Moves a page after another
            ''' </summary>
            Public Sub InsertAfter(page As HtmlPdfPage, after As HtmlPdfPage)
                Me._Pages.Remove(page)
                Me._Pages.Insert(Math.Min(Me._Pages.IndexOf(after) + 1, Me._Pages.Count), page)
            End Sub


#End Region

#Region "Rendering The Document"

            ''' <summary>
            ''' Renders the PDF to an array of bytes
            ''' </summary>
            Public Function RenderPdf() As Byte()

                'Document is inbuilt class, available in iTextSharp
                Dim file As New MemoryStream()
                Dim document As New Document(Me.PageSize)
                Dim writer As PdfWriter = PdfWriter.GetInstance(document, file)

                'allow modifications of the document
                If TypeOf Me.BeforeRender Is RenderEvent Then
                    Me.BeforeRender(writer, document)
                End If

                'header
                document.Add(New Header(Markup.HTML_ATTR_STYLESHEET, String.Empty))
                document.Open()

                'render each page that has been added
                For Each page As HtmlPdfPage In Me._Pages
                    document.NewPage()

                    'generate this page of text
                    Dim output As New MemoryStream()
                    Dim html As New StreamWriter(output, Encoding.UTF8)

                    'get the page output
                    html.Write(String.Concat(HtmlToPdfBuilder.DOCUMENT_HTML_START, page._Html.ToString(), HtmlToPdfBuilder.DOCUMENT_HTML_END))
                    html.Close()
                    html.Dispose()

                    'read the created stream
                    Dim generate As New MemoryStream(output.ToArray())
                    Dim reader As New StreamReader(generate)
                    For Each item As Object In HTMLWorker.ParseToList(reader, Me._Styles)
                        document.Add(DirectCast(item, IElement))
                    Next

                    'cleanup these streams
                    html.Dispose()
                    reader.Dispose()
                    output.Dispose()

                    generate.Dispose()
                Next

                'after rendering
                If TypeOf Me.AfterRender Is RenderEvent Then
                    Me.AfterRender(writer, document)
                End If

                'return the rendered PDF
                document.Close()
                Return file.ToArray()

            End Function

#End Region

        End Class

#End Region

#Region "HtmlPdfPage Class"

        ''' <summary>
        ''' A page to insert into a HtmlToPdfBuilder Class
        ''' </summary>
        Public Class HtmlPdfPage

#Region "Constructors"

            ''' <summary>
            ''' The default information for this page
            ''' </summary>
            Public Sub New()
                Me._Html = New StringBuilder()
            End Sub

#End Region

#Region "Fields"

            'parts for generating the page
            Friend _Html As StringBuilder

#End Region

#Region "Working With The Html"

            ''' <summary>
            ''' Appends the formatted HTML onto a page
            ''' </summary>
            Public Overridable Sub AppendHtml(content As String, ParamArray values As Object())
                Me._Html.AppendFormat(content, values)
            End Sub

#End Region

        End Class

#End Region

#Region "Rendering Delegate"

        ''' <summary>
        ''' Delegate for rendering events
        ''' </summary>
        Public Delegate Sub RenderEvent(writer As PdfWriter, document As Document)

#End Region
    End Class
End Namespace

