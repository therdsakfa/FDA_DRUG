Namespace CLS_COMMOND

    Public Class CLS_COMMOND

    End Class

    Class all_fa
        ''' <summary>
        ''' เช็ค ค.ศ. เปลี่ยนเป็น พ.ศ.
        ''' </summary>
        ''' <param name="year"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function con_year(year) As String
            Dim int_year As Integer = Integer.Parse(year)
            If int_year <= 2500 Then
                int_year += 543
            End If
            Return int_year.ToString()
        End Function
        ''' <summary>
        ''' แปลงวันที่เป็นภาษาไทย
        ''' </summary>
        ''' <param name="str_date"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function con_date(ByVal str_date As String)

            Dim day_now As String = str_date.Split("/")(0) 'เอาเฉพาะวันที่
            Dim month_now As String = str_date.Split("/")(1) 'เอาเฉพาะเดือนที่
            Dim year_now As String = str_date.Split("/")(2) 'เอาเฉพาะปี
            year_now = year_now.Split(" ")(0) 'ตัดเวลาออก

            If year_now < 2500 Then 'ถ้าเป็น คศ
                year_now = (Integer.Parse(year_now) + 543).ToString() 'ปรับเป็น พศ
            End If

            If String.IsNullOrEmpty(month_now) = False Then 'ถ้าเดือนไม่เป็นค่าว่าง
                'แปลงเป็นชื่อเดือน
                If (month_now = "1") Then
                    month_now = "มกราคม"
                ElseIf (month_now = "2") Then
                    month_now = "กุมภาพันธ์"
                ElseIf (month_now = "3") Then
                    month_now = "มีนาคม"
                ElseIf (month_now = "4") Then
                    month_now = "เมษายน"
                ElseIf (month_now = "5") Then
                    month_now = "พฤษภาคม"
                ElseIf (month_now = "6") Then
                    month_now = "มิถุนายน"
                ElseIf (month_now = "7") Then
                    month_now = "กรกฎาคม"
                ElseIf (month_now = "8") Then
                    month_now = "สิงหาคม"
                ElseIf (month_now = "9") Then
                    month_now = "กันยายน"
                ElseIf (month_now = "10") Then
                    month_now = "ตุลาคม"
                ElseIf (month_now = "11") Then
                    month_now = "พฤศจิกายน"
                ElseIf (month_now = "12") Then
                    month_now = "ธันวาคม"
                End If
            End If

            Dim str_date2 As String = day_now & " " & month_now & " พ.ศ. " & year_now

            Return str_date2
        End Function
        ''' <summary>
        ''' แปลงเลข xxxx เป็น 00000xxxx
        ''' </summary>
        ''' <param name="str_no"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Convert_no(ByVal str_no As String)
            If String.IsNullOrEmpty(str_no) = False Then
                Dim int_num As Integer = Integer.Parse(str_no)
                str_no = String.Format("{0:000000000}", int_num.ToString("000000000"))
            End If

            Return str_no
        End Function
        ''' <summary>
        ''' แปลงเลขปี 25xx เป็น xx และ แปลงจาก xx เป็น 000xx
        ''' </summary>
        ''' <param name="year"></param>
        ''' <param name="genno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Convert_format_no(ByVal year As String, ByVal genno As String)
            Dim dt As Integer
            If String.IsNullOrEmpty(genno) = False Then
                Dim int_num As Integer = Integer.Parse(genno)
                genno = String.Format("{0:00000}", int_num.ToString("00000"))
            End If
            dt = year.Substring(2, 2) & genno
            Return dt
        End Function
        ''' <summary>
        ''' แปลงเลข gen ให้อยู่ในรูปแบบของ regnos (1015800001)
        ''' </summary>
        ''' <param name="PVCODE"></param>
        ''' <param name="TYPE"></param>
        ''' <param name="year"></param>
        ''' <param name="GENNO"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Convert_format_regnos(ByVal PVCODE As String, ByVal TYPE As String, ByVal year As String, ByVal GENNO As String)
            Dim dt As Integer
            If String.IsNullOrEmpty(GENNO) = False Then
                Dim int_num As Integer = Integer.Parse(GENNO)
                GENNO = String.Format("{0:00000}", int_num.ToString("00000"))
            End If
            dt = PVCODE & TYPE & year.Substring(2, 2) & GENNO
            Return dt
        End Function
    End Class

    Class search
        ''' <summary>
        ''' DatatableWhere
        ''' </summary>
        ''' <param name="dsTmpAllData"></param>
        ''' <param name="Where"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DatatableWhere(ByVal dsTmpAllData As DataTable, ByVal Where As String) As DataTable
            Try
                dsTmpAllData.DefaultView.RowFilter = Where
                Dim dtTemp As New DataTable
                dtTemp = dsTmpAllData.DefaultView.ToTable()

                Return dtTemp
            Catch ex As Exception
                Return dsTmpAllData
            End Try
        End Function
        'Public Function DatatableWhere(ByVal dsTmpAllData As DataTable, ByVal Where As String) As DataTable
        '    Try
        '        dsTmpAllData.DefaultView.RowFilter = Where
        '        Dim dsTemp As New DataSet
        '        Dim dtTemp As New DataTable
        '        dtTemp = dsTmpAllData.DefaultView.ToTable()
        '        dsTemp.Tables.Add(dtTemp)
        '        Return dtTemp
        '    Catch ex As Exception
        '        Return dsTmpAllData
        '    End Try
        'End Function
        ''' <summary>
        ''' search ในรูป like
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="fname"></param>
        ''' <param name="where"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function search_like(ByVal dt As DataTable, ByVal fname As String, ByVal where As String)
            Dim Datatable_Where As New search
            dt = DatatableWhere(dt, fname & " like '%" & where & "%'")
            Return dt
        End Function
        ''' <summary>
        ''' search ในรูป Integer
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="fname"></param>
        ''' <param name="where"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function search_Integer(ByVal dt As DataTable, ByVal fname As String, ByVal where As Integer)
            Dim Datatable_Where As New search
            dt = DatatableWhere(dt, fname & " = " & where)
            Return dt
        End Function
        ''' <summary>
        ''' search ในรูป String
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="fname"></param>
        ''' <param name="where"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function search_String(ByVal dt As DataTable, ByVal fname As String, ByVal where As String)
            Dim Datatable_Where As New search
            dt = DatatableWhere(dt, fname & " = " & "'" & where & "'")
            Return dt
        End Function
        ''' <summary>
        ''' search ในรูป วัน/เดือน/ปี
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="fname"></param>
        ''' <param name="where"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function search_date(ByVal dt As DataTable, ByVal fname As String, ByVal where As String)
            Dim Datatable_Where As New search
            dt = DatatableWhere(dt, fname & " >= '" & where & "'")
            dt = DatatableWhere(dt, fname & " >= '" & where & "'")
            Return dt
        End Function
    End Class

    Class CITIZEN
        ''' <summary>
        ''' แปลง CITIZEN_ID และ CITIZEN_AUTHORIZE เป็น lcnsid
        ''' </summary>
        ''' <param name="CITIZEN_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function get_lcnsid(ByVal CITIZEN_ID As String) As String
            Dim dao_syslcnsid As New dao_cpn.tb_lcnsid
            dao_syslcnsid.GetData_ByIdentify(CITIZEN_ID)
            Return dao_syslcnsid.fields.lcnsid
        End Function
   
    End Class

    Class filename
        
        ''' <summary>
        ''' ตั้งชื่อไฟล์ UPLOAD PDF
        ''' </summary>
        ''' <param name="SYS"></param>
        ''' <param name="PROSESS_ID"></param>
        ''' <param name="YEAR"></param>
        ''' <param name="ID_TRANSECTION_UPLOAD"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NAME_UPLOAD_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
            Dim conyear As New all_fa
            Dim filename As String = SYS & "-" & PROSESS_ID & "-" & conyear.con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD & ".pdf"
            Return filename
        End Function
        ''' <summary>
        ''' ตั้งชื่อไฟล์ UPLOAD XML
        ''' </summary>
        ''' <param name="SYS"></param>
        ''' <param name="PROSESS_ID"></param>
        ''' <param name="YEAR"></param>
        ''' <param name="ID_TRANSECTION_UPLOAD"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NAME_UPLOAD_XML(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
            Dim filename As String = SYS & "-" & PROSESS_ID & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & ".xml"
            Return filename
        End Function
        ''' <summary>
        ''' ตั้งชื่อไฟล์ DOWNLOAD PDF
        ''' </summary>
        ''' <param name="SYS"></param>
        ''' <param name="ID_TRANSECTION_UPLOAD"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NAME_DOWNLOAD_PDF(ByVal SYS As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
            Dim filename As String = SYS & "-" & ID_TRANSECTION_UPLOAD & ".pdf"
            Return filename
        End Function
        ''' <summary>
        ''' ตั้งชื่อไฟล์ DOWNLOAD XML
        ''' </summary>
        ''' <param name="SYS"></param>
        ''' <param name="ID_TRANSECTION_UPLOAD"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NAME_DOWNLOAD_XML(ByVal SYS As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
            Dim filename As String = SYS & "-" & ID_TRANSECTION_UPLOAD & ".xml"
            Return filename
        End Function

        Public Function NAME_OLD_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal ID As String) As String
            Dim filename As String = SYS & "-old-" & PROSESS_ID & "-" & ID & ".pdf"
            Return filename
        End Function

        Public Function NAME_OUTPUT_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
            Dim filename As String = SYS & "-" & PROSESS_ID & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & "-output.pdf"
            Return filename
        End Function

        Public Function NAME_ATT_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String, ByVal TYPE_FILE As String) As String
            Dim filename As String = SYS & "-" & PROSESS_ID & "-" & YEAR & "-" & ID_TRANSECTION_UPLOAD & "-" & TYPE_FILE & ".pdf"
            Return filename
        End Function
    End Class

#Region "นอกโลก"
    'ใช้เคลียร์ Run auto ของ DB
    'DBCC CHECKIDENT ('[LGT_CMTRQT_BANWD_DTL]', RESEED, 0) GO
#End Region

End Namespace
