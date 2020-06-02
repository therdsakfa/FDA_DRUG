Imports iTextSharp.text.pdf
Imports System.IO

Module Cls_untility

    Private _PATH_PDF_TEMPLATE As String
    Public Property PATH_PDF_TEMPLATE() As String
        Get
            Return _PATH_PDF_TEMPLATE
        End Get
        Set(ByVal value As String)
            _PATH_PDF_TEMPLATE = value
        End Set
    End Property

    Private _PATH_PDF_XML_CLASS As String
    Public Property PATH_PDF_XML_CLASS() As String
        Get
            Return _PATH_PDF_XML_CLASS
        End Get
        Set(ByVal value As String)
            _PATH_PDF_XML_CLASS = value
        End Set
    End Property

    Private _path_XML As String
    Public Property path_XML() As String
        Get
            Return _path_XML
        End Get
        Set(ByVal value As String)
            _path_XML = value
        End Set
    End Property



    ''' <summary>
    ''' เป็นคลาสสำหรับส่ง xmlไปใส่ pdf และทำการ savefile ลงไป
    ''' </summary>
    ''' <param name="filexml"></param>
    ''' <param name="pdfname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PDF_CENTER(ByVal filexml As String, ByVal pdfname As String) As String
        'Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim path As String = path_XML
        path = path & filexml & ".xml"
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE & pdfname & ".pdf") '"C:\path\PDF_TEMPLATE\"
            Using outputStream = New FileStream(PATH_PDF_XML_CLASS & filexml & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using
        Return filexml

    End Function

    Function CONVERT_GEN_NO(ByVal YEAR As String, ByVal PVCODE As String, _
                    ByVal TYPE As String, ByVal LCNNO As String, _
                    ByVal GENNO As String, ByVal FORMAT As String, _
                    ByVal GROUP_NO As String, ByVal REF_IDA As String) As String

        Dim DESCRIPTION As String = String.Empty
        If FORMAT = "1" Then
            DESCRIPTION = LCNNO & "/" & YEAR
        ElseIf FORMAT = "2" Then
            DESCRIPTION = PVCODE & "-" & TYPE & "-" & YEAR.Substring(0, 2) & LCNNO.Substring(2, 3)
        End If
        Return DESCRIPTION
    End Function


    ''' <summary>
    ''' เช็ค ค.ศ. เปลี่ยนเป็น พ.ศ.
    ''' </summary>
    ''' <param name="year"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function con_year(year) As String
        Dim int_year As Integer = Integer.Parse(year)
        If int_year <= 2500 Then
            int_year += 543
        End If
        Return int_year.ToString()
    End Function
    Function con_year_2() As String
        Dim int_year As Integer = Integer.Parse(Date.Now.Year)
        If int_year <= 2500 Then
            int_year += 543
        End If
        Return int_year.ToString()
    End Function
    ''' <summary>
    ''' เปลี่ยนหัวข้อหน้า
    ''' </summary>
    ''' <param name="lbl"></param>
    ''' <param name="_type"></param>
    ''' <remarks></remarks>
    Public Sub set_lbl_header(ByRef lbl As Label, ByVal _type As String)
        Dim dao As New DAO_DRUG.ClsDBPROCESS_NAME
        dao.GetDataby_Process_ID(_type)

        Try
            lbl.Text = dao.fields.PROCESS_NAME
        Catch ex As Exception

        End Try
       
    End Sub

End Module




