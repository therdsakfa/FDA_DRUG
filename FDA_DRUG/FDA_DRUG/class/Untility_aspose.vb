'Imports Aspose.Words
'Imports System.Text.RegularExpressions
'Imports Aspose.Words.Tables
'Imports Aspose.Words.Lists
'Namespace Untility

'    Public Class CLS_ASPOSE_WORD
'#Region "ตัวแแปรในคลาส"

'        Private _Pid As Integer
'        Public Property Pid() As Integer
'            Get
'                Return _Pid
'            End Get
'            Set(ByVal value As Integer)
'                _Pid = value
'            End Set
'        End Property



'        Private _doc As New Document()
'        Private _textreplace As String()
'        Private _textmsg As String
'        Private _table As DataTable


'        Private _numberstyle As Aspose.Words.NumberStyle


'        ''' <summary>
'        ''' ทำเพื่อเปลี่ยนค่า Number
'        ''' </summary>
'        Public Sub setStyleNumber(ByVal numberstyle As Aspose.Words.NumberStyle)
'            _numberstyle = numberstyle
'        End Sub




'        Public Sub New()
'            _numberstyle = Aspose.Words.NumberStyle.Arabic
'        End Sub

'#End Region


'        ''' <summary>
'        ''' เปิดใช้ Aspose License
'        ''' </summary>
'        Public Sub setLicense(ByVal Path As String)
'            Dim lic As New License
'            lic.SetLicense(Path)
'        End Sub


'        ''' <summary>
'        ''' เปิดการเชื่อมต่อเอกสาร
'        ''' </summary>
'        Public Sub docConnect(ByVal path As String)
'            _doc = New Document(path)
'        End Sub

'        ''' <summary>
'        ''' เปิดเอกสารใน Browser
'        ''' </summary>
'        Public Sub docSaveOpen(ByVal filename As String)
'            _doc.Save(filename, SaveFormat.Docx, SaveType.OpenInBrowser, HttpContext.Current.Response)
'        End Sub

'        ''' <summary>
'        ''' Save Word
'        ''' </summary>
'        Public Sub docSave(ByVal path As String)
'            _doc.Save(path)
'        End Sub

'        ''' <summary>
'        ''' เป็นคำสั่งเพื่อส่ง Text ไปแทนที่ใน Text
'        ''' </summary>
'        ''' <remarks></remarks>
'        Public Overloads Sub rePlaceData(ByVal textfind As String, ByVal textreplace As String)
'            Dim txtcheck() As String = textreplace.Split(vbNewLine)
'            If txtcheck.Length > 1 Then
'                _textreplace = textreplace.Split(vbNewLine)
'                _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithText), False)
'            Else
'                _doc.Range.Replace(textfind, textreplace.Replace(vbNewLine, " "), True, False)
'            End If

'        End Sub


'        ' ''' <summary>
'        ' ''' เป็นคำสั่งเพื่อส่ง Text ไปแทนที่ใน Text
'        ' ''' </summary>
'        ' ''' <remarks></remarks>
'        'Public Overloads Sub rePlaceDataArray(ByVal textfind As String, ByVal textreplace As String)

'        '    '   _doc.Range.Replace(textfind, textreplace.Replace(vbNewLine, " "), True, False)
'        '    _textreplace = textreplace.Split(vbNewLine)
'        '    _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithText), False)

'        'End Sub


'        ''' <summary>
'        ''' เป็นคำสั่งเพื่อส่งค่า array ไปทำ Bullet
'        ''' </summary>
'        ''' <remarks></remarks>
'        Public Overloads Sub rePlaceData(ByVal textfind As String, ByVal textreplace As String())
'            _textreplace = textreplace
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithBullet), False)
'        End Sub


'        ''' <summary>
'        ''' เป็นคำสั่งเพื่อส่งค่า DataTable ไปทำ Table
'        ''' </summary>
'        ''' <remarks></remarks>
'        Public Overloads Sub rePlaceData(ByVal textfind As String, ByVal table As DataTable)
'            _table = table
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithTable), False)
'        End Sub





'        ''' <summary>
'        ''' เป็นการแทรก Text ใน Word
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithText(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)
'            'b.ListFormat.ApplyNumberDefault()
'            'b.ListFormat.ListLevelNumber = 0
'            'b.ListFormat.ListLevel.NumberStyle = _numberstyle
'            For Each s As String In _textreplace
'                b.Write(s)
'            Next

'            'b.ListFormat.RemoveNumbers()
'            '  e.Replacement = ""
'            Return ReplaceAction.Replace
'        End Function


'        ''' <summary>
'        ''' เป็นการแทรก Bullet ใน Word
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithBullet(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)
'            If _textreplace.Count = 1 Then
'                For Each s As String In _textreplace
'                    b.Writeln(s)
'                Next
'            Else
'                b.ListFormat.ApplyNumberDefault()
'                b.ListFormat.ListLevelNumber = 0
'                b.ListFormat.ListLevel.NumberStyle = _numberstyle
'                For Each s As String In _textreplace
'                    b.Writeln(s)
'                Next
'            End If


'            b.ListFormat.RemoveNumbers()
'            e.Replacement = ""
'            Return ReplaceAction.Replace
'        End Function


'        ''' <summary>
'        ''' เป็นการแทรก Table ใน Word
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithTable(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)

'            _generateTable(b)
'            'Let the replace continue.
'            e.Replacement = ""
'            Return ReplaceAction.Replace

'        End Function

'        ''' <summary>
'        ''' ใช้สำหรับแปลงค่า
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub _generateTable(ByRef b As Aspose.Words.DocumentBuilder)
'            b.StartTable()

'            'b.CellFormat.Borders.LineStyle = LineStyle.Single
'            For Each dc As DataColumn In _table.Columns
'                'b.CellFormat.ClearFormatting()
'                b.InsertCell()
'                b.CellFormat.Width = 200.0
'                b.Font.Size = 16
'                b.Font.Name = "TH SarabunIT๙"
'                b.Font.Bold = True
'                b.CellFormat.Borders.Color = System.Drawing.Color.Black
'                b.CellFormat.Borders.LineStyle = LineStyle.Single
'                b.CellFormat.Borders.LineWidth = 1
'                If DBNull.Value.Equals(dc.ColumnName) Then
'                    b.Write(" ")
'                Else
'                    b.Write(dc.ColumnName)
'                End If
'            Next
'            b.EndRow()

'            For Each dr As DataRow In _table.Rows
'                For Each dc As DataColumn In _table.Columns
'                    'b.CellFormat.ClearFormatting()
'                    b.InsertCell()
'                    b.CellFormat.Width = 200.0
'                    b.Font.Size = 16
'                    b.Font.Name = "TH SarabunIT๙"
'                    b.CellFormat.Borders.Color = System.Drawing.Color.Black
'                    b.CellFormat.Borders.LineStyle = LineStyle.Single
'                    b.CellFormat.Borders.LineWidth = 1
'                    b.Write(dr(dc.ColumnName.ToString()))
'                Next
'                b.EndRow()
'            Next
'            b.EndTable()

'        End Sub



'#Region "CODE ออกรายงานเฉพาะ"

'        ''' <summary>
'        ''' จะต้องมี Column ทั้งหมด 7 Column บังคับ ประกอบด้วย 
'        ''' ลำดับ,รายการ,ราคาต่อหน่วย.จำนวน,บาท,สต.,หมายเหตุ
'        ''' </summary>
'        ''' <param name="textfind"></param>
'        ''' <param name="table"></param>
'        ''' <remarks></remarks>
'        Public Sub rePlaceData_Quataion(ByVal textfind As String, ByVal table As DataTable)
'            _table = table
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithTable_Quatition), False)
'        End Sub

'        ''' <summary>
'        ''' เป็นการแทรก Table ใน Word สำหรับทำใบสั่งซื้อ
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithTable_Quatition(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)

'            _generateTable_Quatition(b)
'            'Let the replace continue.
'            e.Replacement = ""
'            Return ReplaceAction.Replace

'        End Function

'        ''' <summary>
'        ''' ใช้สำหรับแปลงค่าตาราง ใบสั่งซื้อ
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub _generateTable_Quatition(ByRef b As Aspose.Words.DocumentBuilder)

'            b.CellFormat.Borders.Color = System.Drawing.Color.Black
'            b.CellFormat.Borders.LineStyle = LineStyle.Single
'            b.CellFormat.Borders.LineWidth = 1
'            b.Font.Size = 16
'            b.Font.Name = "TH SarabunIT๙"
'            b.Font.Bold = True


'            b.StartTable()

'            Dim p As Integer = Pid

'            '50,180,100,70,50,50,50
'            Dim a_width() As Integer = {40, 260, 60, 50, 70, 30, 50}

'            'สร้างหัวแรก
'            b.ParagraphFormat.Alignment = ParagraphAlignment.Center
'            With b
'                .InsertCell()

'                .CellFormat.VerticalMerge = CellMerge.First
'                .CellFormat.Width = a_width(0)
'                .Write("ลำดับ")

'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.First
'                .CellFormat.Width = a_width(1)
'                .Write("รายการ")

'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.First
'                .CellFormat.Width = a_width(2)
'                .Write("ราคาต่อหน่วย")

'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.First

'                .CellFormat.Width = a_width(3)
'                .Write("จำนวนสิ่งของ")


'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.None
'                '.CellFormat.HorizontalMerge = CellMerge.First

'                .CellFormat.Width = a_width(4)
'                .Write("จำนวนเงิน")

'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.None
'                '.CellFormat.HorizontalMerge = CellMerge.Previous
'                .CellFormat.Width = a_width(5)
'                .Write("")

'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.None
'                '   .CellFormat.HorizontalMerge = CellMerge.None
'                .Write("หมายเหตุ")
'                .CellFormat.Width = a_width(6)
'                .EndRow()
'            End With
'            'สร้างหัวสอง
'            b.ParagraphFormat.Alignment = ParagraphAlignment.Center
'            With b
'                'ชึ้นบรรทัดใหม่
'                .InsertCell()
'                ' ช่องว่าง ลำดับ
'                .CellFormat.VerticalMerge = CellMerge.Previous
'                .CellFormat.Width = a_width(0)
'                .InsertCell()
'                ' ช่องว่าง รายการ
'                .CellFormat.VerticalMerge = CellMerge.Previous
'                .CellFormat.Width = a_width(1)
'                .InsertCell()
'                ' ช่องว่าง  ราคาต่อหน่วย
'                .CellFormat.VerticalMerge = CellMerge.Previous
'                .CellFormat.Width = a_width(2)
'                .InsertCell()
'                ' ช่องว่าง  จำนวน
'                .CellFormat.VerticalMerge = CellMerge.Previous
'                .CellFormat.Width = a_width(3)
'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.None
'                .CellFormat.Width = a_width(4)
'                .Write("บาท")

'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.None
'                .CellFormat.Width = a_width(5)
'                .Write("สต.")


'                .InsertCell()
'                .CellFormat.VerticalMerge = CellMerge.None
'                .CellFormat.Width = a_width(6)
'                .Write(" ")

'                .EndRow()
'            End With


'            Dim row_count As Integer = _table.Rows.Count

'            If row_count > 10 Then
'                Dim msg As String = ""

'            End If

'            For Each dr As DataRow In _table.Rows
'                Dim index As Integer = 0
'                Dim check_merge As Boolean = False
'                For Each dc As DataColumn In _table.Columns
'                    'b.CellFormat.ClearFormatting()
'                    b.InsertCell()
'                    b.CellFormat.Width = a_width(index)
'                    b.Font.Bold = False
'                    'b.Font.Size = 16
'                    'b.Font.Name = "TH SarabunIT๙"
'                    'b.CellFormat.Borders.Color = System.Drawing.Color.Black
'                    'b.CellFormat.Borders.LineStyle = LineStyle.Single
'                    'b.CellFormat.Borders.LineWidth = 1
'                    If index = 0 Then
'                        Dim temp As String = ""
'                        Try
'                            temp = dr(dc.ColumnName.ToString())
'                            Dim str As String = ""

'                            If temp = "-1" Then
'                                check_merge = True
'                                str = "ราคารวมสินค้า"
'                            ElseIf temp = "-2" Then
'                                check_merge = True
'                                str = "ไม่รวมภาษีมูลค่าเพิ่ม"
'                            ElseIf temp = "-3" Then
'                                check_merge = True
'                                str = "ภาษีมูลค่าเพิ่ม 7 %"
'                            Else
'                                check_merge = False
'                            End If

'                            If check_merge Then
'                                b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                                b.CellFormat.HorizontalMerge = CellMerge.First
'                                Try
'                                    b.Write(str)
'                                Catch ex As Exception
'                                    b.Write("")
'                                End Try

'                            Else
'                                b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                                Try
'                                    b.Write(dr(dc.ColumnName.ToString()))
'                                Catch ex As Exception
'                                    b.Write("")
'                                End Try
'                            End If
'                        Catch ex As Exception
'                            check_merge = False
'                        End Try

'                    ElseIf index = 1 Then
'                        If check_merge Then
'                            b.CellFormat.HorizontalMerge = CellMerge.Previous
'                        Else
'                            b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                            Try
'                                b.Write(dr(dc.ColumnName.ToString()))
'                            Catch ex As Exception
'                                b.Write("")
'                            End Try
'                        End If
'                    ElseIf index = 2 Then
'                        b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                        If check_merge Then
'                            b.CellFormat.HorizontalMerge = CellMerge.Previous
'                        Else
'                            Dim temp_price As Decimal = 0
'                            Try
'                                temp_price = Convert.ToDecimal(dr(dc.ColumnName.ToString()))
'                                b.Write(String.Format("{0:###,###.##}", temp_price))
'                            Catch ex As Exception
'                                b.Write("")
'                            End Try
'                        End If

'                    ElseIf index = 3 Then
'                        b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                        If check_merge Then
'                            b.CellFormat.HorizontalMerge = CellMerge.Previous
'                        Else
'                            Dim temp_price As Decimal = 0
'                            Try
'                                temp_price = Convert.ToDecimal(dr(dc.ColumnName.ToString()))
'                                b.Write(String.Format("{0:###,###}", temp_price))
'                            Catch ex As Exception
'                                b.Write("")
'                            End Try
'                        End If

'                    ElseIf index = 4 Then
'                        b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                        If check_merge Then
'                            b.CellFormat.HorizontalMerge = CellMerge.None
'                        End If

'                        Dim temp_price As Decimal = 0
'                        Try
'                            temp_price = Convert.ToDecimal(dr(dc.ColumnName.ToString()))
'                        Catch ex As Exception

'                        End Try

'                        b.Write(String.Format("{0:###,###}", temp_price))
'                    Else
'                        b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                        Try
'                            b.Write(dr(dc.ColumnName.ToString()))
'                        Catch ex As Exception
'                            b.Write("")
'                        End Try

'                    End If

'                    index += 1
'                Next
'                b.EndRow()
'            Next


'            'ทำ Footer ใบสั่งซื้อ

'            Dim Tempcost As Double = 0
'            For Each dr As DataRow In _table.Rows
'                Try

'                    Dim no As Integer = 0
'                    Try
'                        no = CInt(dr("ลำดับที่"))
'                    Catch ex As Exception
'                        no = 0
'                    End Try

'                    If no > 0 Then
'                        Tempcost += CDbl(dr("บาท")) + CDbl(dr("สต.") / 100)
'                    End If

'                Catch ex As Exception

'                End Try

'            Next

'            If Tempcost = 0 Then
'                For Each dr As DataRow In _table.Rows
'                    Try

'                        Dim no As Integer = 0
'                        Try
'                            no = CInt(dr("ลำดับที่"))
'                        Catch ex As Exception
'                            no = 0
'                        End Try

'                        If no = -1 OrElse no = -3 Then
'                            Tempcost += CDbl(dr("บาท")) + CDbl(dr("สต.") / 100)
'                        End If

'                    Catch ex As Exception

'                    End Try

'                Next
'            End If

'            Dim vat As Double = 0

'            Dim check_vat As String = ""
'            Try
'                check_vat = _table.Rows(0)("ลำดับที่").ToString
'            Catch ex As Exception

'            End Try
'            If check_vat = "" Then

'            Else
'                If _table.Rows(_table.Rows.Count - 1)("รายการพิจารณา").ToString.Contains("ไม่รวมภาษีมูลค่าเพิ่ม") Then

'                Else
'                    vat = Math.Round((Tempcost * 0.07), 2)
'                End If
'            End If

'            Dim tempmoney() As String = CDec((Tempcost + vat)).ToString.Split(".")

'            With b
'                .InsertCell()
'                b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                .CellFormat.HorizontalMerge = CellMerge.First
'                .CellFormat.Width = a_width(0)
'                .Write("รวมเป็นเงินทั้งสิ้น")

'                .InsertCell()
'                .CellFormat.Width = a_width(1)
'                .CellFormat.HorizontalMerge = CellMerge.Previous

'                .InsertCell()
'                .CellFormat.Width = a_width(2)
'                .CellFormat.HorizontalMerge = CellMerge.Previous

'                .InsertCell()
'                .CellFormat.Width = a_width(3)
'                .CellFormat.HorizontalMerge = CellMerge.Previous

'                .InsertCell()
'                .CellFormat.Width = a_width(4)
'                .CellFormat.HorizontalMerge = CellMerge.None
'                b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                .Write(String.Format("{0:###,###}", Convert.ToDecimal(tempmoney(0))))

'                .InsertCell()
'                .CellFormat.Width = a_width(5)
'                .CellFormat.HorizontalMerge = CellMerge.None
'                b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                Try
'                    Dim len As Integer = tempmoney(1).Length
'                    If len = 1 Then
'                        .Write(tempmoney(1) & "0")
'                    Else
'                        .Write(tempmoney(1))
'                    End If

'                Catch ex As Exception
'                    .Write("00")
'                End Try


'                .InsertCell()
'                .CellFormat.Width = a_width(6)
'                .CellFormat.HorizontalMerge = CellMerge.None
'                .Write("")
'            End With
'            b.EndRow()

'            b.EndTable()


'        End Sub

'        ''' <summary>
'        ''' ใช้สำหรับออกรายงาน คณะกรรมการ
'        ''' </summary>
'        ''' <param name="textfind"></param>
'        ''' <param name="table"></param>
'        ''' <remarks></remarks>
'        Public Sub rePlaceData_Board(ByVal textfind As String, ByVal table As DataTable)
'            _table = table
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithTable_Board), False)
'        End Sub

'        ''' <summary>
'        ''' ใช้สำหรับออกรายงาน คณะกรรมการ
'        ''' </summary>
'        ''' <param name="textfind"></param>
'        ''' <param name="table"></param>
'        ''' <remarks></remarks>
'        Public Sub rePlaceData_GroupBoard(ByVal textfind As String, ByVal table As DataTable)
'            _table = table
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithTable_GroupBoard), False)
'        End Sub

'        ''' <summary>
'        ''' เป็นการแทรก Table ใน Word ออกรายงานคณะกรรมการ
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithTable_Board(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)

'            _generateTable_Board(b)
'            '_generateTable_GroupBoard(b)
'            'Let the replace continue.
'            e.Replacement = ""
'            Return ReplaceAction.Replace

'        End Function

'        ''' <summary>
'        ''' เป็นการแทรก Table ใน Word ออกรายงานคณะกรรมการ
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithTable_GroupBoard(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)

'            '  _generateTable_Board(b)
'            _generateTable_GroupBoard(b)
'            'Let the replace continue.
'            e.Replacement = ""
'            Return ReplaceAction.Replace

'        End Function

'        ''' <summary>
'        ''' ใช้สำหรับแปลงค่า คณะกรรมการ
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub _generateTable_Board(ByRef b As Aspose.Words.DocumentBuilder)

'            'b.CellFormat.Borders.Color = System.Drawing.Color.Black
'            'b.CellFormat.Borders.LineStyle = LineStyle.Single
'            'b.CellFormat.Borders.LineWidth = 1
'            b.Font.Size = 16
'            b.Font.Name = "TH SarabunIT๙"
'            'b.Font.Bold = True


'            b.StartTable()

'            Dim i As Integer = 1
'            For Each dr As DataRow In _table.Rows
'                'Dim s As String = Space(5) & i & ")" & dr("F_NAME") & Space(5) & dr("L_NAME") & _
'                '    dr("RankBoard")

'                b.InsertCell()
'                b.Write(Space(5) & i & ")" & dr("F_NAME"))
'                b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                b.CellFormat.Width = 200

'                b.InsertCell()
'                b.Write(dr("L_NAME"))
'                b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                b.CellFormat.Width = 200

'                b.InsertCell()
'                b.Write(dr("RankBoard"))
'                b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                b.CellFormat.Width = 100

'                b.EndRow()
'                i += 1
'                'b.Write(s)
'            Next

'            b.EndTable()


'        End Sub

'        ''' <summary>
'        ''' ใช้สำหรับแปลงค่าคณะกรรมการโดยออกมาเป็นกลุ่มคณะกรรมการ
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub _generateTable_GroupBoard(ByRef b As Aspose.Words.DocumentBuilder)
'            b.Font.Size = 16
'            b.Font.Name = "TH SarabunIT๙"
'            'b.Font.Bold = True


'            ' b.StartTable()

'            Dim tempBoardName As String = ""
'            For Each dr As DataRow In _table.Rows
'                Dim bname As String = dr("BoardName")
'                If tempBoardName.Contains(bname) = False Then
'                    If tempBoardName = "" Then
'                        tempBoardName = bname
'                    Else
'                        tempBoardName = tempBoardName & "," & bname
'                    End If
'                End If

'            Next

'            Dim count_board As String() = tempBoardName.Split(",")


'            If count_board.Count = 1 Then

'                Dim i As Integer = 1
'                For Each s As String In tempBoardName.Split(",")

'                    Dim j As Integer = 1
'                    For Each dr As DataRow In _table.Rows
'                        Dim bname As String = dr("BoardName")
'                        If s = bname Then

'                            Dim BoardList As String = ""
'                            BoardList = vbTab & j & "." & Space(1) & dr("F_NAME") & Space(5) & dr("L_NAME") & _
'                            Space(10) & dr("RankBoard")
'                            'b.InsertCell()
'                            'b.Write(Space(5) & j & "." & Space(1) & dr("F_NAME"))
'                            'b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                            'b.CellFormat.Width = 200

'                            'b.InsertCell()
'                            'b.Write(dr("L_NAME"))
'                            'b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                            'b.CellFormat.Width = 200

'                            'b.InsertCell()
'                            'b.Write(dr("RankBoard"))
'                            'b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                            'b.CellFormat.Width = 100
'                            j = j + 1
'                            'b.EndRow()
'                            '    If j = _table.Rows.Count Then
'                            '       b.Write(BoardList)
'                            '  Else
'                            b.Writeln(BoardList)
'                            'End If

'                        End If
'                    Next
'                    i += 1
'                Next

'            Else

'                Dim i As Integer = 1
'                For Each s As String In tempBoardName.Split(",")
'                    b.Write(vbTab & i & ". " & s & " ประกอบด้วย " & vbNewLine)
'                    'b.InsertCell()
'                    'b.Write(Space(2) & i & ". " & s)
'                    'b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                    'b.CellFormat.HorizontalMerge = CellMerge.First
'                    'b.CellFormat.Width = 400

'                    ''b.InsertCell()
'                    ''b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                    ''b.CellFormat.HorizontalMerge = CellMerge.Previous
'                    ''b.CellFormat.Width = 200


'                    ''b.InsertCell()
'                    ''b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                    ''b.CellFormat.HorizontalMerge = CellMerge.Previous
'                    ''b.CellFormat.Width = 100


'                    ''b.InsertCell()
'                    ''b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                    ''b.CellFormat.HorizontalMerge = CellMerge.None
'                    ''b.CellFormat.Width = 1
'                    '  b.EndRow()

'                    Dim j As Integer = 1
'                    For Each dr As DataRow In _table.Rows
'                        Dim bname As String = dr("BoardName")
'                        If s = bname Then
'                            Dim BoardList As String = ""
'                            BoardList = vbTab & Space(5) & i & "." & j & Space(1) & dr("F_NAME") & Space(5) & dr("L_NAME") & _
'                            Space(10) & dr("RankBoard")
'                            'b.InsertCell()
'                            'b.Write(Space(5) & i & "." & j & ")" & Space(1) & dr("F_NAME"))
'                            'b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                            'b.CellFormat.Width = 200

'                            'b.InsertCell()
'                            'b.Write(dr("L_NAME"))
'                            'b.ParagraphFormat.Alignment = ParagraphAlignment.Left
'                            'b.CellFormat.Width = 200

'                            'b.InsertCell()
'                            'b.Write(dr("RankBoard"))
'                            'b.ParagraphFormat.Alignment = ParagraphAlignment.Right
'                            'b.CellFormat.Width = 100
'                            j = j + 1
'                            'b.EndRow()
'                            '    If j = _table.Rows.Count Then
'                            '  b.Write(BoardList)
'                            '     Else
'                            b.Writeln(BoardList)
'                            '     End If

'                        End If
'                    Next
'                    i += 1
'                Next


'            End If

'            'b.EndTable()
'        End Sub


'        ''' <summary>
'        ''' ใช้สำหรับแทนค่ารายงาน ลายเซ็นคณะกรรมการ
'        ''' </summary>
'        ''' <param name="textfind"></param>
'        ''' <param name="table"></param>
'        ''' <remarks></remarks>
'        Public Sub rePlaceData_BoardSign(ByVal textfind As String, ByVal table As DataTable)
'            _table = table
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithTable_BoardSign), False)
'        End Sub

'        ''' <summary>
'        ''' เป็นการแทรก Table ใน Word ออกรายงานคณะกรรมการเป็นลายเซ็น
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithTable_BoardSign(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)
'            _generateTable_GroupBoardSign(b)
'            'Let the replace continue.
'            e.Replacement = ""
'            Return ReplaceAction.Replace

'        End Function


'        ''' <summary>
'        ''' ใช้สำหรับแปลงค่าคณะกรรมการโดยออกมาเป็นกลุ่มคณะกรรมการ
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub _generateTable_GroupBoardSign(ByRef b As Aspose.Words.DocumentBuilder)
'            b.Font.Size = 16
'            b.Font.Name = "TH SarabunIT๙"
'            'b.Font.Bold = True


'            b.StartTable()

'            Dim tempBoardName As String = ""
'            For Each dr As DataRow In _table.Rows
'                Dim bname As String = dr("BoardName")
'                If tempBoardName.Contains(bname) = False Then
'                    If tempBoardName = "" Then
'                        tempBoardName = bname
'                    Else
'                        tempBoardName = tempBoardName & "," & bname
'                    End If
'                End If
'            Next

'            '        		(ลงชื่อ)………...………..…………..……… ประธานกรรมการ	
'            '     (นางภาวนา  คุ้มตระกูล)	
'            'ผู้อำนวยการสำนักบริหาร()
'            For Each dr As DataRow In _table.Rows
'                Dim bname As String = dr("BoardName")
'                Dim fname As String = dr("F_NAME")
'                Dim lname As String = dr("L_NAME")
'                Dim RankBoard As String = dr("RankBoard")
'                If RankBoard = "ประธานกรรมการ" Then
'                    With b
'                        .InsertCell()
'                        .Write("(ลงชื่อ)………...………..…………..……… " & RankBoard)
'                        .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                        .CellFormat.HorizontalMerge = CellMerge.First
'                        .CellFormat.Width = 460
'                        .EndRow()
'                        .InsertCell()
'                        .Write("(" & fname & ")")
'                        .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                        .CellFormat.HorizontalMerge = CellMerge.First
'                        .CellFormat.Width = 460
'                        .EndRow()
'                        .InsertCell()
'                        .Write(lname)
'                        .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                        .CellFormat.HorizontalMerge = CellMerge.First
'                        .CellFormat.Width = 460
'                        .EndRow()
'                    End With

'                End If
'                'Next
'            Next

'            Dim tempfname As New ArrayList
'            Dim tempRankBoard As New ArrayList
'            Dim templname As New ArrayList
'            Dim row As Integer = _table.Rows.Count
'            Dim i As Integer = 0
'            For Each dr As DataRow In _table.Rows
'                Dim bname As String = dr("BoardName")
'                Dim fname As String = dr("F_NAME")
'                Dim lname As String = dr("L_NAME")
'                Dim RankBoard As String = dr("RankBoard")


'                If RankBoard <> "ประธานกรรมการ" Then
'                    If row Mod 2 = 0 Then
'                        If i > 1 Then
'                            i = 1
'                            tempfname.Clear()
'                            tempRankBoard.Clear()
'                            templname.Clear()
'                        End If
'                    Else
'                        If i > 1 Then
'                            i = 0
'                            tempfname.Clear()
'                            tempRankBoard.Clear()
'                            templname.Clear()
'                        End If
'                    End If


'                    tempfname.Add(fname)
'                    tempRankBoard.Add(RankBoard)
'                    templname.Add(lname)

'                    i = i + 1

'                    If i = 2 Then
'                        '   For ii As Integer = 0 To 2 - 1
'                        Dim name1 As String = ""
'                        Dim name2 As String = ""
'                        Dim rank1 As String = ""
'                        Dim rank2 As String = ""
'                        Dim lname1 As String = ""
'                        Dim lname2 As String = ""
'                        Try
'                            name1 = tempfname(0)

'                        Catch ex As Exception

'                        End Try

'                        Try
'                            name2 = tempfname(1)
'                        Catch ex As Exception

'                        End Try

'                        Try
'                            rank1 = tempRankBoard(0)

'                        Catch ex As Exception

'                        End Try

'                        Try
'                            rank2 = tempRankBoard(1)
'                        Catch ex As Exception

'                        End Try

'                        Try
'                            lname1 = templname(0)

'                        Catch ex As Exception

'                        End Try

'                        Try
'                            lname2 = templname(1)
'                        Catch ex As Exception

'                        End Try

'                        With b
'                            .InsertCell()
'                            .Write("(ลงชื่อ)………...………..………… " & rank1)
'                            .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                            .CellFormat.Width = 230

'                            If rank2 <> "" Then
'                                .InsertCell()
'                                .Write("(ลงชื่อ)………...………..………… " & rank2)
'                                .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                                .CellFormat.Width = 230
'                            End If


'                            .EndRow()

'                            .InsertCell()
'                            .Write("(" & name1 & ")")
'                            .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                            .CellFormat.Width = 230

'                            If name2 <> "" Then
'                                .InsertCell()
'                                .Write("(" & name2 & ")")
'                                .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                                .CellFormat.Width = 230
'                            End If

'                            .EndRow()

'                            .InsertCell()
'                            .Write(lname1)
'                            .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                            .CellFormat.Width = 230

'                            If lname2 <> "" Then
'                                .InsertCell()
'                                .Write(lname2)
'                                .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                                .CellFormat.Width = 230
'                            End If

'                            .EndRow()
'                        End With
'                    End If
'                End If
'            Next
'            b.EndTable()


'        End Sub

'        ''' <summary>
'        ''' ใช้สำหรับแทนค่ารายงาน ลายเซ็นคณะกรรมการแนวตั้ง
'        ''' </summary>
'        ''' <param name="textfind"></param>
'        ''' <param name="table"></param>
'        ''' <remarks></remarks>
'        Public Sub rePlaceData_VerticalBoardSign_Rank(ByVal textfind As String, ByVal table As DataTable)
'            _table = table
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithTable_VerticalBoardSign_Rank), False)
'        End Sub

'        ''' <summary>
'        ''' เป็นการแทรก Table ใน Word ออกรายงานคณะกรรมการเป็นลายเซ็น
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithTable_VerticalBoardSign_Rank(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)
'            _generateTable_VerticalBoardSign_Rank(b)
'            'Let the replace continue.
'            e.Replacement = ""
'            Return ReplaceAction.Replace

'        End Function

'        ''' <summary>
'        ''' ใช้สำหรับแปลงค่าคณะกรรมการโดยออกมาเป็นลายเซ็นแนวตั้ง
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub _generateTable_VerticalBoardSign_Rank(ByRef b As Aspose.Words.DocumentBuilder)
'            b.Font.Size = 16
'            b.Font.Name = "TH SarabunIT๙"
'            'b.Font.Bold = True


'            'b.StartTable()


'            '        		(ลงชื่อ)………...………..…………..……… ประธานกรรมการ	
'            '     (นางภาวนา  คุ้มตระกูล)	
'            'ผู้อำนวยการสำนักบริหาร()
'            For Each dr As DataRow In _table.Rows
'                Dim bname As String = dr("BoardName")
'                Dim fname As String = dr("F_NAME")
'                Dim lname As String = dr("L_NAME")
'                Dim RankBoard As String = dr("RankBoard")
'                b.Writeln(vbTab & "(ลงชื่อ)………....…………..……… " & RankBoard)
'                b.Writeln(vbTab & Space(10) & "(" & fname & ")")
'                b.Writeln(vbTab & Space(10) & RankBoard)
'                b.Writeln()

'                'With b
'                '    .InsertCell()
'                '    .CellFormat.Width = 230

'                '    .InsertCell()
'                '    .Write("(ลงชื่อ)………....…………..……… " & RankBoard)
'                '    .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                '    '.CellFormat.HorizontalMerge = CellMerge.First
'                '    .CellFormat.Width = 300
'                '    .EndRow()


'                '    .InsertCell()
'                '    .CellFormat.Width = 230

'                '    .InsertCell()
'                '    .Write("(" & fname & ")")
'                '    .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                '    '  .CellFormat.HorizontalMerge = CellMerge.First
'                '    .CellFormat.Width = 300
'                '    .EndRow()

'                '    '.InsertCell()
'                '    '.CellFormat.Width = 230

'                '    '.InsertCell()
'                '    '.Write(lname)
'                '    '.ParagraphFormat.Alignment = ParagraphAlignment.Center
'                '    '' .CellFormat.HorizontalMerge = CellMerge.First
'                '    '.CellFormat.Width = 300
'                '    '.EndRow()

'                '    .InsertCell()
'                '    .CellFormat.Width = 230

'                '    .InsertCell()
'                '    .CellFormat.Width = 300
'                '    .EndRow()

'                'End With
'            Next


'        End Sub


'        ''' <summary>
'        ''' ใช้สำหรับแทนค่ารายงาน ลายเซ็นคณะกรรมการแนวตั้ง
'        ''' </summary>
'        ''' <param name="textfind"></param>
'        ''' <param name="table"></param>
'        ''' <remarks></remarks>
'        Public Sub rePlaceData_VerticalBoardSign(ByVal textfind As String, ByVal table As DataTable)
'            _table = table
'            _doc.Range.Replace(New Regex(textfind), New ReplaceEvaluator(AddressOf HandleReplaceWithTable_VerticalBoardSign), False)
'        End Sub

'        ''' <summary>
'        ''' เป็นการแทรก Table ใน Word ออกรายงานคณะกรรมการเป็นลายเซ็น
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Function HandleReplaceWithTable_VerticalBoardSign(ByVal sender As Object, ByVal e As ReplaceEvaluatorArgs) As ReplaceAction
'            Dim run As Run = DirectCast(e.MatchNode, Run)
'            Dim para As Paragraph = run.ParentParagraph
'            Dim b As New Aspose.Words.DocumentBuilder(para.Document)
'            b.MoveTo(e.MatchNode)
'            _generateTable_VerticalBoardSign(b)
'            'Let the replace continue.
'            e.Replacement = ""
'            Return ReplaceAction.Replace

'        End Function

'        ''' <summary>
'        ''' ใช้สำหรับแปลงค่าคณะกรรมการโดยออกมาเป็นลายเซ็นแนวตั้ง
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub _generateTable_VerticalBoardSign(ByRef b As Aspose.Words.DocumentBuilder)
'            b.Font.Size = 16
'            b.Font.Name = "TH SarabunIT๙"
'            'b.Font.Bold = True


'            'b.StartTable()


'            '        		(ลงชื่อ)………...………..…………..……… ประธานกรรมการ	
'            '     (นางภาวนา  คุ้มตระกูล)	
'            'ผู้อำนวยการสำนักบริหาร()
'            For Each dr As DataRow In _table.Rows
'                Dim bname As String = dr("BoardName")
'                Dim fname As String = dr("F_NAME")
'                Dim lname As String = dr("L_NAME")
'                Dim RankBoard As String = dr("RankBoard")
'                b.Writeln(vbTab & "(ลงชื่อ)………....…………..……… " & RankBoard)
'                b.Writeln(vbTab & Space(10) & "(" & fname & ")")
'                b.Writeln()

'                'With b
'                '    .InsertCell()
'                '    .CellFormat.Width = 230

'                '    .InsertCell()
'                '    .Write("(ลงชื่อ)………....…………..……… " & RankBoard)
'                '    .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                '    '.CellFormat.HorizontalMerge = CellMerge.First
'                '    .CellFormat.Width = 300
'                '    .EndRow()


'                '    .InsertCell()
'                '    .CellFormat.Width = 230

'                '    .InsertCell()
'                '    .Write("(" & fname & ")")
'                '    .ParagraphFormat.Alignment = ParagraphAlignment.Center
'                '    '  .CellFormat.HorizontalMerge = CellMerge.First
'                '    .CellFormat.Width = 300
'                '    .EndRow()

'                '    '.InsertCell()
'                '    '.CellFormat.Width = 230

'                '    '.InsertCell()
'                '    '.Write(lname)
'                '    '.ParagraphFormat.Alignment = ParagraphAlignment.Center
'                '    '' .CellFormat.HorizontalMerge = CellMerge.First
'                '    '.CellFormat.Width = 300
'                '    '.EndRow()

'                '    .InsertCell()
'                '    .CellFormat.Width = 230

'                '    .InsertCell()
'                '    .CellFormat.Width = 300
'                '    .EndRow()

'                'End With
'            Next


'        End Sub
'#End Region
'    End Class


'End Namespace
