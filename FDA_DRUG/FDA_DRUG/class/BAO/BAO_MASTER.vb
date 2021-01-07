Public Class BAO_MASTER

    Public conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString

    ''' <summary>
    ''' ใส่ค่าว่างใน DT
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AddDatatable(ByVal dt As DataTable) As DataTable
        Dim dr As DataRow = dt.NewRow
        For Each c As DataColumn In dt.Columns
            If c.DataType.Name.ToString() = "String" Then
                dr(c.ColumnName) = ""
            ElseIf c.DataType.Name.ToString() = "Int32" Then
                dr(c.ColumnName) = 0
            ElseIf c.DataType.Name.ToString() = "DateTime" Then
                dr(c.ColumnName) = Date.Now 'DBNull.Value ' 
            Else
                Try
                    dr(c.ColumnName) = Nothing
                Catch ex As Exception
                    dr(c.ColumnName) = 0
                End Try


            End If

        Next

        dt.Rows.Add(dr)
        Return dt
    End Function
   
    Public Function SP_MASTER_drclass() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drclass"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drclass"
        Return dt
    End Function

    Public Function SP_MASTER_dactg() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dactg"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dactg"
        Return dt
    End Function

    Public Function SP_MASTER_drkdofdrg() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drkdofdrg"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drkdofdrg"
        Return dt
    End Function
 
    Public Function SP_MASTER_drdosage() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drdosage"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drdosage"
        Return dt
    End Function

    Public Function SP_MASTER_dacnc() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dacnc"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dacnc"
        Return dt
    End Function

    Public Function SP_MASTER_drdrgtype() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drdrgtype"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drdrgtype"
        Return dt
    End Function

    Public Function SP_MASTER_dacnccs() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dacnccs"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dacnccs"
        Return dt
    End Function

    Public Function SP_MASTER_dramlusetp() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dramlusetp"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dramlusetp"
        Return dt
    End Function

    Public Function SP_MASTER_dramltype() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dramltype"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dramltype"
        Return dt
    End Function

    Public Function SP_MASTER_dramlpart() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dramlpart"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dramlpart"
        Return dt
    End Function

    Public Function SP_MASTER_drsunit() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drsunit"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drsunit"
        Return dt
    End Function

    Public Function SP_MASTER_driowa() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_driowa"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_driowa"
        Return dt
    End Function

    Public Function SP_MASTER_drstng() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drstng"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drstng"
        Return dt
    End Function

    Public Function SP_MASTER_drstdtest() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drstdtest"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drstdtest"
        Return dt
    End Function

    Public Function SP_MASTER_sysisocnt() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_sysisocnt"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_sysisocnt"
        Return dt
    End Function

    Public Function SP_MASTER_lgt_impcertp() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_lgt_impcertp"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_lgt_impcertp"
        Return dt
    End Function

    Public Function SP_MASTER_CON_LCNNO(ByVal IDA As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_CON_LCNNO @IDA = " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_CON_LCNNO"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    Public Function SP_MASTER_dalcntype_by_IDA(ByVal IDA As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dalcntype_by_IDA @IDA = " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dalcntype_by_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    '
    Public Function SP_CUSTOMER_LCT_BY_LCT_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_CUSTOMER_LCT_BY_LCT_IDA @IDA = " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_CUSTOMER_LCT_BY_LCT_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try

        Return dt
    End Function
    Public Function SP_DALCNADDR_BY_FK_IDA(ByVal FK_IDA As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DALCNADDR_BY_FK_IDA @FK_IDA = " & FK_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
        Catch ex As Exception

        End Try

        dt.TableName = "SP_DALCNADDR_BY_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    Public Function SP_MASTER_drrgt_BY_IDA(ByVal IDA As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drrgt_BY_IDA @IDA = " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drrgt_BY_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    ''' <summary>
    ''' สารเคมี
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_MAS_CHEMICAL() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_CHEMICAL "
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_CHEMICAL"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' cer ของสถานที่นั้นๆ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_LGT_IMPCER_by_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LGT_IMPCER_by_FK_IDA @FK_IDA =  " & FK_IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_LGT_IMPCER_by_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' สารเคมีของ CER นั้นๆ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_CER_DETAIL_CASCHEMICAL_by_TR_ID @FK_IDA =  " & FK_IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_CER_DETAIL_CASCHEMICAL_by_TR_ID"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    ''' <summary>
    '''ใบอนุญาตไว้ใส่ดรอปดาว
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_dalcn_by_LCNSID(ByVal LCNSID As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_dalcn_by_LCNSID @LCNSID =  " & LCNSID
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_dalcn_by_LCNSID"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' ทะเบียนยาไว้ใส่ดรอปดาว
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_drrgt_by_LCNSID(ByVal LCNSID As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_drrgt_by_LCNSID @LCNSID =  " & LCNSID
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_drrgt_by_LCNSID"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_MAS_GMP_STANDARN() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_GMP_STANDARN"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_GMP_STANDARN"
        Return dt
    End Function



    ''' <summary>
    ''' ข้อมูลเภสัชกรในแต่ละใบอนุญาต
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_PHR_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_PHR_BY_FK_IDA @FK_IDA =  " & FK_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
        Catch ex As Exception

        End Try

        dt.TableName = "SP_PHR_BY_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_MAS_CHEMICAL_CONVERT(ByVal lcnsid As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_CHEMICAL_CONVERT @lcnsid =  " & lcnsid
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    '
    Public Function SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    '
    Public Function SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI_V2(ByVal aori As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_CHEMICAL_CONVERT_by_AORI_V2 @aori='" & aori & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    Public Function SP_PICS_NATIONAL() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_PICS_NATIONAL"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
        Catch ex As Exception

        End Try

        dt.TableName = "SP_PICS_NATIONAL"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    Public Function SP_MASTER_MAS_CHEMICAL_CONVERT2(ByVal lcnsid As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_CHEMICAL_CONVERT2 @lcnsid =  " & lcnsid
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    Public Function SP_MASTER_MAS_CHEMICAL_ALL() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_CHEMICAL_ALL"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_CER_PK_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_CER_PK_BY_FK_IDA @FK_IDA =  " & FK_IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_CER_PK_BY_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
    Public Function SP_drkdofdrg() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_drkdofdrg"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_drkdofdrg"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
       
        Return dt
    End Function
    '
    Public Function SP_CER_FOREIGN_BY_IDA() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_CER_FOREIGN_BY_IDA"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_CER_FOREIGN_BY_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try

        Return dt
    End Function
    ''' <summary>
    ''' สารที่เลือกใน ภค
    ''' </summary>
    ''' <param name="FK_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA @FK_IDA =  " & FK_IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FK_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_MAS_CHEMICAL_CONVERT @lcnsid =  " & FK_IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_MAS_CHEMICAL_CONVERT"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    ''' <summary>
    ''' โชว์ UC ที่อยู่
    ''' </summary>
    ''' <param name="ida"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_ADDR_BY_IDA(ByVal ida As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_ADDR_BY_IDA @ida = " & ida
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_ADDR_BY_IDA"
        Return dt
    End Function

    ''' <summary>
    ''' ทะเบียนยา
    ''' </summary>
    ''' <param name="IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_DRUG_REGISTRATION_BY_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DRUG_REGISTRATION_BY_IDA @IDA =  " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_DRUG_REGISTRATION_BY_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function


    ''' <summary>
    ''' สถานที่เก็บ
    ''' </summary>
    ''' <param name="FK_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA @FK_IDA = " & FK_IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                ' dt = AddDatatable(dt)
                dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            '  dt = AddDatatable(dt)
            dt.Clear()
        End If

        Return dt
    End Function
    '
    Public Function SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_DUMMY() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_DUMMY"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA"
        Return dt
    End Function

    ''' <summary>
    ''' ข้อมูลเภสัชกรในแต่ละใบอนุญาต ที่มีมากกว่า1คน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_PHR_NOT_ROW_1_BY_FK_IDA(ByVal FK_IDA As Integer, ByVal PHR_MEDICAL_TYPE As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_PHR_NOT_ROW_1_BY_FK_IDA @FK_IDA =  " & FK_IDA & ",@PHR_MEDICAL_TYPE =" & PHR_MEDICAL_TYPE
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_PHR_NOT_ROW_1_BY_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() > 1 Then
                '  dt = AddDatatable(dt)
                dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() > 1 Then
            'dt = AddDatatable(dt)
            dt.Clear()
        End If
        Return dt
    End Function


    ''' <summary>
    ''' ข้อมูลเภสัชกรในแต่ละใบอนุญาต แยกตามประเภทของเภสัช
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(ByVal FK_IDA As Integer, ByVal PHR_MEDICAL_TYPE As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE @FK_IDA =  " & FK_IDA & ",@PHR_MEDICAL_TYPE =" & PHR_MEDICAL_TYPE
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If

        Return dt
    End Function

    ''' <summary>
    ''' ข้อมูลเภสัชกรในแต่ละใบอนุญาต ที่มีมากกว่า1คน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(ByVal FK_IDA As Integer, ByVal PHR_MEDICAL_TYPE As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE @FK_IDA =  " & FK_IDA & ",@PHR_MEDICAL_TYPE =" & PHR_MEDICAL_TYPE
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() > 1 Then
                'dt = AddDatatable(dt)
                dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() > 1 Then
            'dt = AddDatatable(dt)
            dt.Clear()
        End If
        Return dt
    End Function

    ''' <summary>
    ''' ข้อมูลใบอนุญาตหลักเอาไปใส่ย่อย
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_DALCN_by_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DALCN_by_IDA @IDA =  " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_DALCN_by_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function

    ''' <summary>
    ''' ข้อมูลใบอนุญาต เลขรับ วันที่รับ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_DALCN_LCNREQUEST_by_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DALCN_LCNREQUEST_by_IDA @IDA =  " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_DALCN_LCNREQUEST_by_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function


    ''' <summary>
    ''' ข้อมูลใบอนุญาตหลักเอาไปใส่ย่อย
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_DALCN_PHR_BY_FK_IDA_2(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DALCN_PHR_BY_FK_IDA_2 @IDA =  " & IDA
        Dim dt As New DataTable
        dt.TableName = "SP_DALCN_PHR_BY_FK_IDA_2"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function


    ''' <summary>
    ''' ข้อมูลCerใส่ ภค
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_DH15_DETAIL_CER_by_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DH15_DETAIL_CER_by_FK_IDA @FK_IDA =  " & FK_IDA
        Dim dt As New DataTable
        dt.TableName = "SP_MASTER_DH15_DETAIL_CER_by_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function


    ''' <summary>
    ''' ข้อมูลสารใส่ ภคoutput
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_DH15_DETAIL_CASCHEMICAL_by_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DH15_DETAIL_CASCHEMICAL_by_FK_IDA @FK_IDA =  " & FK_IDA
        Dim dt As New DataTable
        dt.TableName = "SP_MASTER_DH15_DETAIL_CASCHEMICAL_by_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function


    ''' <summary>
    ''' เก็บข้อมูลขนาดบรรจุ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_DRSAMP_by_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_DRSAMP_by_IDA @IDA =  " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_DRSAMP_by_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 'ผู้มีหน้าที่ปฏิบัติการ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_DALCN_PHR_BY_FK_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DALCN_PHR_BY_FK_IDA @FK_IDA =  " & IDA
        Dim dt As New DataTable
        dt.TableName = "SP_DALCN_PHR_BY_FK_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function
    Public Function SP_DALCN_PHR_BY_FK_IDA_AND_PHR_CTZNO(ByVal PHR_CTZNO As String, ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DALCN_PHR_BY_FK_IDA_AND_PHR_CTZNO @PHR_CTZNO='" & PHR_CTZNO & "',@FK_IDA =" & IDA
        Dim dt As New DataTable
        dt.TableName = "SP_DALCN_PHR_BY_FK_IDA_AND_PHR_CTZNO"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function
    '
    Public Function SP_DALCN_PHR_BY_FK_IDA_V2(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DALCN_PHR_BY_FK_IDA_V2 @FK_IDA =  " & IDA
        Dim dt As New DataTable
        dt.TableName = "SP_DALCN_PHR_BY_FK_IDA_V2"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function
    ''' <summary>
    ''' 'ผู้มีหน้าที่ปฏิบัติการ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_DALCN_PHR_BY_FK_IDA_CTZNO_NOTNULL(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DALCN_PHR_BY_FK_IDA_CTZNO_NOTNULL @FK_IDA =  " & IDA
        Dim dt As New DataTable
        dt.TableName = "SP_DALCN_PHR_BY_FK_IDA_CTZNO_NOTNULL"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function
    ''' <summary>
    ''' ข้อมูลขนาดบรรจุ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MASTER_UNIT_CONTAIN_by_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MASTER_UNIT_CONTAIN_by_IDA @IDA =  " & IDA
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MASTER_UNIT_CONTAIN_by_IDA_by_IDA"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
                'dt.Clear()
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
            'dt.Clear()
        End If
        Return dt
    End Function
    Public Function SP_DRUG_PRODUCT_ID_BY_PJSUM(ByVal iden As String, ByVal mode As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DRUG_PRODUCT_ID_BY_PJSUM @PJ_IDA =  " & "'" & iden & "'," & "@mode=" & mode
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_DRUG_PRODUCT_ID_BY_PJSUM"
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        Return dt
    End Function
End Class
