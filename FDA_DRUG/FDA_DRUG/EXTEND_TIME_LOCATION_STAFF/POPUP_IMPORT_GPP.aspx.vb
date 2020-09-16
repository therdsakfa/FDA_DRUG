Imports ClosedXML.Excel

Public Class POPUP_IMPORT_GPP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub ImportExcel()
        'Open the Excel file using ClosedXML.
        Using workBook As New XLWorkbook(FileUpload3.PostedFile.InputStream)
            'Read the first Sheet from Excel file.
            Dim workSheet As IXLWorksheet = workBook.Worksheet(1)

            'Create a new DataTable.
            Dim dt As New DataTable()

            'Loop through the Worksheet rows.
            Dim firstRow As Boolean = True
            For Each row As IXLRow In workSheet.Rows()
                'Use the first row to add columns to DataTable.
                If row.Cell(1).Value.ToString <> "" And row.Cell(2).Value.ToString <> "" Then
                    If firstRow Then
                        For Each cell As IXLCell In row.Cells()
                            If Len(cell.Value.ToString()) > 0 Then
                                dt.Columns.Add(cell.Value.ToString())
                            End If

                        Next
                        firstRow = False
                    Else
                        'Add rows to DataTable.
                        dt.Rows.Add()
                        Dim i As Integer = 0
                        For Each cell As IXLCell In row.Cells()
                            If Len(cell.Value.ToString()) > 0 Then
                                dt.Rows(dt.Rows.Count - 1)(i) = cell.Value.ToString()
                                i += 1
                            End If

                        Next
                    End If
                End If


                RadGrid1.DataSource = dt
                RadGrid1.DataBind()
            Next
        End Using
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class