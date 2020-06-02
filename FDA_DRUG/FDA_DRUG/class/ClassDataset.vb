Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System
Imports System.Web.UI

Imports System.IO.File
Imports System.Text.RegularExpressions
'Imports Telerik.QuickStart
'Imports Telerik.WebControls
Imports Telerik.Web.UI

Imports System.Configuration
Imports System.Collections

Imports System.Data.SerializationFormat
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Imports System.Guid
Imports System.Xml.Serialization


Imports System.Security.Cryptography
<System.Serializable()> Public Class ClassDataset
    'Public Conn As String = "Data Source=.;Initial Catalog=Permission;Persist Security Info=True;User ID=sa;Password=fusion"
    Private _SqlString As String
    Public Property SqlString() As String
        Get
            Return _SqlString
        End Get
        Set(ByVal value As String)
            _SqlString = value
        End Set
    End Property
    Public Function MergeDataset(ByVal ds As DataSet, ByVal ds2 As DataSet) As DataSet
        ds.Merge(ds2, True, MissingSchemaAction.Add)
        Dim errRows() As DataRow = ds.Tables(0).GetErrors()
        Dim errRow As DataRow
        For Each errRow In errRows
            errRow.RejectChanges()
            errRow.RowError = Nothing
        Next
        ds.AcceptChanges()
        Return ds
    End Function
    Public Function dsQueryselect(ByVal queryString As String, ByVal connectionString As String) As DataSet
        Dim myDataSet As DataSet = New DataSet
        Try
            Dim MyConnection As SqlConnection = New SqlConnection(connectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(queryString, MyConnection)
            mySqlDataAdapter.Fill(myDataSet)
            Return myDataSet
        Catch ex As Exception
            Return myDataSet
        End Try
    End Function

    Public Function SqlCommandExecuteNonQuery(ByVal SqlCommand As String, ByVal ConnectionString As String) As Boolean
        Dim MyConnection As SqlConnection = New SqlConnection(ConnectionString)
        MyConnection.Open()
        Dim cmdSql As SqlCommand = New SqlCommand(SqlCommand, MyConnection)
        cmdSql.ExecuteNonQuery()
        MyConnection.Close()
        Return True
    End Function

    Public Function DatasetConvertDataTable(ByVal ds As DataSet) As DataTable
        Dim dt As New DataTable
        Try
            dt = ds.Tables(0).DefaultView.ToTable
            Return dt
        Catch ex As Exception
            Return dt
        End Try
    End Function

    Public Function DatatableConvertDataset(ByVal Table As DataTable, Optional ByVal Where As String = "", Optional ByVal sort As String = "") As DataSet
        Dim dstemp As New DataSet
        dstemp.Tables.Add(Table)
        If Where <> "" Then
            dstemp = DatasetWhere(dstemp, Where)
        End If
        If sort <> "" Then
            Try
                dstemp.Tables(0).DefaultView.Sort = sort
            Catch ex As Exception

            End Try
        End If
        Return dstemp
    End Function
    Public Function DatasetWhere(ByVal dsTmpAllData As DataSet, ByVal Where As String) As DataSet
        Try
            dsTmpAllData.Tables(0).DefaultView.RowFilter = Where
            Dim dsTemp As New DataSet
            Dim dtTemp As New DataTable
            dtTemp = dsTmpAllData.Tables(0).DefaultView.ToTable()
            dsTemp.Tables.Add(dtTemp)
            Return dsTemp
        Catch ex As Exception
            Return dsTmpAllData
        End Try
    End Function


    Public Function ForMatDateTime(ByVal day As Date, Optional ByVal WantTime As Boolean = False, Optional ByVal DefaulTimeHour As String = "00", _
                Optional ByVal DefaultMinute As String = "00", Optional ByVal defaultSeconds As String = "00") As String
        Dim a As String
        Dim b() As String

        a = day.ToString
        b = a.Split(" ")
        Dim DateandTime As String = b(0)
        If WantTime = True Then
            DateandTime = b(0) & Space(1) & DefaulTimeHour & ":" & DefaultMinute & ":" & defaultSeconds
        End If
        Return DateandTime
    End Function

    Public Function SqlInsertTime(ByVal dateandtime As Date, Optional ByVal TimeZero As Boolean = False) As String
        Dim numberDay As Integer = DateDiff(DateInterval.Second, dateandtime, Date.Now)
        Dim sql As String = " dateadd(day," & numberDay & ",getdate())"
        Return sql
    End Function

    Public Function SqlCheckTime(ByVal dateandtime As Date, Optional ByVal TimeZero As Boolean = False) As String
        Dim numberDay As Integer = DateDiff(DateInterval.Second, dateandtime, Date.Now)
        Dim sql As String = "select dateadd(s," & numberDay & ",getdate())"
        Return sql
    End Function


    Public Function ShowFormatDatetime() As String
        Dim d As Date
        Dim checkd As String = d.ToString
        Dim c() As String
        c = checkd.Split(" ")
        Dim cc() As String
        Dim temp As String = ""
        For i = 0 To c.Length - 1
            cc = c(i).Split("/")
            If cc.Length = 3 Then
                For ii = 0 To cc.Length - 1
                    If cc(ii).Length = 4 Then
                        If CInt(cc(ii)) > 2500 Then
                            cc(ii) = "2443"
                        Else
                            cc(ii) = "1900"
                        End If
                    End If
                    If ii = cc.Length - 1 Then
                        temp = temp & cc(ii)
                    Else
                        temp = temp & cc(ii) & "/"
                    End If
                Next
            End If
            If cc.Length = 1 Then
                temp = temp & " " & cc(0)
            End If
        Next
        Dim tempday As Date
        tempday = CDate(temp)
        tempday = DateAdd(DateInterval.Month, 10, tempday)
        Dim tempstring() As String
        tempstring = tempday.ToString.Split(" ")
        Dim tempcheckformat() As String
        tempcheckformat = tempstring(0).Split("/")
        Dim formatDate As String = ""
        For i = 0 To tempcheckformat.Length - 1
            If tempcheckformat(i).Length > 2 Then
                If formatDate = "" Then
                    formatDate = "ปี"
                Else
                    formatDate = formatDate & "/" & "ปี"
                End If
            End If
            If tempcheckformat(i) = "11" Then
                If formatDate = "" Then
                    formatDate = "เดือน"
                Else
                    formatDate = formatDate & "/" & "เดือน"
                End If
            End If
            If tempcheckformat(i) = "1" Then
                If formatDate = "" Then
                    formatDate = "วัน"
                Else
                    formatDate = formatDate & "/" & "วัน"
                End If
            End If


        Next
        Return formatDate
    End Function


    Public Function AddRowDataset(ByVal dataset1 As DataTable, ByVal a() As String, Optional ByVal spilitby As String = "=") As DataTable
        Dim newCustomersRow As DataRow = dataset1.NewRow
        Dim name As String = dataset1.Columns.ToString
        'For i = 0 To a.Length - 1
        '    newCustomersRow("CustomerID") = "ALFKI"
        'Next
        Dim tempcheck() As String

        For Each col In dataset1.Columns

            For i = 0 To a.Length - 1
                If a(i) <> Nothing Then
                    tempcheck = a(i).Split("=")
                    If tempcheck(0) = col.ColumnName Then
                        If tempcheck.Length > 1 Then
                            newCustomersRow(col) = Trim(tempcheck(1))

                        Else
                            newCustomersRow(col) = ""
                        End If

                    End If
                End If
            Next

        Next
        dataset1.Rows.Add(newCustomersRow)
        Return dataset1
    End Function
    Public Function addcolumnDataset(ByVal ds As DataTable, ByVal column() As String, Optional ByVal splitby As String = "=") As DataTable
        Dim temp() As String

        Dim dt1 As DataTable = ds
        For i = 0 To column.Length - 1
            If column(i) <> "" Then
                temp = column(i).Split(splitby)
                Dim dc As New DataColumn(temp(0))
                dt1.Columns.Add(dc)
            End If

        Next

        Return dt1
    End Function

    Public Sub insertDatasetToDatabase(ByVal dt As DataTable, ByVal conn As String, ByVal Table As String)
        Dim bulkcopy As New SqlBulkCopy(conn)
        bulkcopy.DestinationTableName = Table
        bulkcopy.WriteToServer(dt)
    End Sub
    Public Function UpLoadImageFile(ByVal info As String) As String
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        imgBin = reader.ReadBytes(stream.Length)
        Dim base64 As String = Convert.ToBase64String(imgBin)
        stream.Close()
        stream.Dispose()
        stream = Nothing
        reader.Close()
        reader = Nothing
        Return base64
    End Function

    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        imgBin = reader.ReadBytes(stream.Length)
        stream.Close()
        stream.Dispose()
        stream = Nothing
        Return imgBin
    End Function

    Public Function GenerateUniqueKey() As String

        Dim U As New UnicodeEncoding()


        'Create an MD5 object
        Dim Md5 As New MD5CryptoServiceProvider()

        'Calculate a hash value from the Time
        Dim MyUniqueKey() As Byte = Md5.ComputeHash(U.GetBytes(System.DateTime.Now().ToString()))

        'And convert it to String format to return
        Return Convert.ToBase64String(MyUniqueKey)

    End Function

    Public Function StremeFile(ByVal Str64 As String, ByVal Filename As String, ByVal Destination As String, ByVal serverpath As String) As String
        Dim Url As String = ""
        Dim basic As String = Str64
        Dim image As Byte() = Convert.FromBase64String(basic)
        Dim oFileStrem As System.IO.FileStream
        oFileStrem = New System.IO.FileStream(serverpath + "/" + Destination + "/" & Filename, System.IO.FileMode.Create)
        oFileStrem.Write(image, 0, image.Length)
        oFileStrem.Close()
        oFileStrem.Dispose()
        Url = "/" + Destination + "/" & Filename

        Return Url
    End Function

    Public Function RandomName() As String
        Dim r As New Random

        Return r.Next.ToString()
    End Function


#Region "ทำให้ไบน่ารี่เแปลงเป็นข้อมูลต่าง"
    Public Overloads Sub bynaryToobject(ByVal path As String, ByVal Document As String)
        Dim image As Byte() = Convert.FromBase64String(Document)
        Dim oFileStrem As System.IO.FileStream
        oFileStrem = New System.IO.FileStream(path, System.IO.FileMode.Create)
        oFileStrem.Write(image, 0, image.Length)
        oFileStrem.Close()
        oFileStrem.Dispose()
    End Sub
    Public Overloads Sub bynaryToobject(ByVal path As String, ByVal Image() As Byte)

        Dim oFileStrem As System.IO.FileStream
        oFileStrem = New System.IO.FileStream(path, System.IO.FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
        oFileStrem.Write(Image, 0, Image.Length)
        oFileStrem = Nothing
        oFileStrem.Close()
        oFileStrem.Dispose()


    End Sub
    Public Overloads Sub bynaryToobject2(ByVal path As String, ByVal Image() As Byte)

        Dim oFileStrem As System.IO.FileStream
        oFileStrem = New System.IO.FileStream(path, System.IO.FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
        oFileStrem.Write(Image, 0, Image.Length)
        '  oFileStrem = Nothing
        'oFileStrem.Close()
        oFileStrem.Dispose()


    End Sub
    Public Sub ImageToObject(ByVal path As String, ByVal Image() As Byte)
        Dim stream As New MemoryStream
        stream.Write(Image, 0, Image.Length)
        Dim bit As New System.Drawing.Bitmap(stream)
        bit.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg)
        stream.Dispose()
        stream.Close()
    End Sub
#End Region
End Class
