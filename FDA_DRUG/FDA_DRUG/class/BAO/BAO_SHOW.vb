Imports System.Data.SqlClient
Imports System.Xml.Serialization
Imports System.IO

Public Class BAO_SHOW

    Public conn As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString
    Public conn_DRUG As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString
    Public conn_book As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_BOOKINGConnectionString").ConnectionString

    ''' <summary>
    ''' ทำตรงนี้เพิ่มไปโดยมินเอง
    ''' </summary>
    Public conn_DRUG_IMPORT As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_DRUG_IMPORTConnectionString").ConnectionString
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
                dr(c.ColumnName) = Date.Now 'Nothing 'Date.Now
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
    Public Function Queryds(ByVal Commands As String) As DataTable
        Dim dt As New DataTable
        Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString)
        Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
        mySqlDataAdapter.Fill(dt)
        MyConnection.Close()
        Return dt
    End Function


    ''' <summary>
    ''' ดึงข้อมูล จังหวัด
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSCHNGWT() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSCHNGWT"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSCHNGWT"
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
    ''' ดึงข้อมูล อำเภอ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSAMPHR() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSAMPHR"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSAMPHR"
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
    Public Function SP_GET_PHR_LOCATION_BY_PHR_CTZNO(ByVal PHR_CTZNO As String) As DataTable
        Dim sql As String = "exec SP_GET_PHR_LOCATION_BY_PHR_CTZNO @PHR_CTZNO='" & PHR_CTZNO & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_PHR_LOCATION_BY_PHR_CTZNO"
        Return dta
    End Function
    Public Function SP_DRUG_GROUP_BY_LCN_IDA(ByVal lcn_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_GROUP_BY_LCN_IDA @LCN_IDA=" & lcn_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_GROUP_BY_LCN_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_EDIT_REQUEST_PACKAGE_DETAIL_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_PACKAGE_DETAIL_BY_FK_IDA @FK_IDA= " & FK_IDA
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_EDIT_REQUEST_PACKAGE_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_NORMAL(ByVal FK_IDA As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_NORMAL @FK_IDA= " & FK_IDA
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_NORMAL"
        Return dta
    End Function

    '
    Public Function SP_DRRGT_ADDR_INSERT_V2(ByVal FK_IDA As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_ADDR_INSERT_V2 @FK_IDA= " & FK_IDA
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_ADDR_INSERT_V2"
        Return dta
    End Function
    Public Function SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_BIO(ByVal FK_IDA As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_BIO @FK_IDA= " & FK_IDA
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_BIO"
        Return dta
    End Function
    Public Function SP_TYPE_REQUESTS_ID_BY_TYPE(ByVal TYPE_REQUESTS_ID As String) As DataTable
        Dim sql As String = "exec SP_TYPE_REQUESTS_ID_BY_TYPE @TYPE_REQUESTS_ID='" & TYPE_REQUESTS_ID & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_TYPE_REQUESTS_ID_BY_TYPE"
        Return dta
    End Function
    Public Function SP_DALCN_PHR_by_PHR_CTZNO_TOP_ONE(ByVal PHR_CTZNO As String) As DataTable
        Dim sql As String = "exec SP_DALCN_PHR_by_PHR_CTZNO_TOP_ONE @PHR_CTZNO='" & PHR_CTZNO & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DALCN_PHR_by_PHR_CTZNO_TOP_ONE"
        Return dta
    End Function
    Public Function SP_GET_WS_DRRGT_STATUS_BY_TR_ID_AND_RCVNO(ByVal tr_id As String, ByVal rcvno As String) As DataTable
        Dim sql As String = "exec SP_GET_WS_DRRGT_STATUS_BY_TR_ID_AND_RCVNO @TR_ID='" & tr_id & "' ,@rcvno='" & rcvno & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_WS_DRRGT_STATUS_BY_TR_ID_AND_RCVNO"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_DATA_BY_TR_ID(ByVal tr_id As String) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DATA_BY_TR_ID @TR_ID='" & tr_id & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DATA_BY_TR_ID"
        Return dta
    End Function
    '
    Public Function SP_GET_DRRGT_BY_TR_ID_REGIS(ByVal tr_id As String) As DataTable
        Dim sql As String = "exec SP_GET_DRRGT_BY_TR_ID_REGIS @TR_ID='" & tr_id & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_DRRGT_BY_TR_ID_REGIS"
        Return dta
    End Function
    '
    Public Function SP_GET_DRRGT_BY_REGIS_NO(ByVal Regis_no As String) As DataTable
        Dim sql As String = "exec SP_GET_DRRGT_BY_REGIS_NO @REGIS_NO='" & Regis_no & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_DRRGT_BY_REGIS_NO"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO(ByVal Regis_no As String) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO @REGIS_NO='" & Regis_no & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO"
        Return dta
    End Function
    '
    '
    Public Function SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim sql As String = "exec SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA @FK_IDA=" & FK_IDA
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_GET_PACKAGE_TEXT_DRRQT_PACKAGE_DETAIL_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
        Dim sql As String = "exec SP_GET_PACKAGE_TEXT_DRRQT_PACKAGE_DETAIL_BY_FK_IDA @FK_IDA=" & FK_IDA
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_PACKAGE_TEXT_DRRQT_PACKAGE_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO_AND_CITIZEN_AUTH(ByVal Regis_no As String, ByVal identify As String) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO_AND_CITIZEN_AUTH @REGIS_NO='" & Regis_no & "' ,@citizen='" & identify & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DATA_BY_REGIS_NO_AND_CITIZEN_AUTH"
        Return dta
    End Function
    '
    Public Function SP_GET_ALL_DRRGT_EDIT_REQUEST() As String
        Dim sql As String = "exec SP_GET_ALL_DRRGT_EDIT_REQUEST"
        Dim str_xml As String = ""
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_ALL_DRRGT_EDIT_REQUEST"

        str_xml = SerializeObject(dta, "DRRGT_EDIT_REQUEST")
        Return str_xml
    End Function
    '
    Public Function SP_GET_DRRQT_ALL_ACCEPT_XML() As String
        Dim sql As String = "exec SP_GET_DRRQT_ALL_ACCEPT"
        Dim str_xml As String = ""
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_DRRQT_ALL_ACCEPT"

        str_xml = SerializeObject(dta, "DRRQT_ALL_ACCEPT")
        Return str_xml
    End Function
    Public Function SP_GET_DRRQT_ALL_ACCEPT_dt() As DataTable
        Dim sql As String = "exec SP_GET_DRRQT_ALL_ACCEPT"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "DRRQT_ALL_ACCEPT"
        Return dta
    End Function
    Public Function SP_GET_ALL_DRRGT_EDIT_REQUEST_dt() As DataTable
        Dim sql As String = "exec SP_GET_ALL_DRRGT_EDIT_REQUEST"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_ALL_DRRGT_EDIT_REQUEST"
        Return dta
    End Function
    Private Function SerializeObject(ByVal dt As DataTable, ByVal dt_name As String) As String
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        ds.Tables(0).TableName = dt_name
        Dim xmlSerializer As New XmlSerializer(ds.GetType)
        Dim str_xml As String = ""
        Using textWriter As New StringWriter()
            xmlSerializer.Serialize(textWriter, ds)
            str_xml = textWriter.ToString()
            Return str_xml
        End Using
    End Function
    Public Function SP_GET_DRRGT_BY_REGIS_NO_AND_PAY_ALREADY(ByVal Regis_no As String) As DataTable
        Dim sql As String = "exec SP_GET_DRRGT_BY_REGIS_NO_AND_PAY_ALREADY @REGIS_NO='" & Regis_no & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_DRRGT_BY_REGIS_NO_AND_PAY_ALREADY"
        Return dta
    End Function
    '
    Public Function SP_GET_DRRGT_BY_REGIS_NO_AND_TR_ID_PAY_ALREADY(ByVal Regis_no As String, ByVal tr_id As String) As DataTable
        Dim sql As String = "exec SP_GET_DRRGT_BY_REGIS_NO_AND_TR_ID_PAY_ALREADY @REGIS_NO='" & Regis_no & "',@tr_id='" & tr_id & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_DRRGT_BY_REGIS_NO_AND_TR_ID_PAY_ALREADY"
        Return dta
    End Function
    '
    Public Function SP_GET_DRRGT_EDIT_BY_REGIS_NO_AND_TR_ID(ByVal Regis_no As String, ByVal tr_id As String) As DataTable
        Dim sql As String = "exec SP_GET_DRRGT_EDIT_BY_REGIS_NO_AND_TR_ID @REGIS_NO='" & Regis_no & "',@tr_id='" & tr_id & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_GET_DRRGT_EDIT_BY_REGIS_NO_AND_TR_ID"
        Return dta
    End Function
    Public Function SP_DRRGT_DETAIL_CAS_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_DETAIL_CAS_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_DETAIL_CAS_BY_FK_IDAV2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_DETAIL_CAS_BY_FK_IDAV2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDAV2"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_DETAIL_CAS_BY_FK_IDAV3(ByVal fk_ida As Integer, ByVal _set As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_DETAIL_CAS_BY_FK_IDAV3 @FK_IDA=" & fk_ida & " ,@set=" & _set
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDAV3"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_NEW @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_DTB_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_DTB_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DTB_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_DTB_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_DTB_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_DTB_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_dramldrg_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_dramldrg_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_dramldrg_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_dramldrg_BY_newcode(ByVal newcode As String) As DataTable
        Dim sql As String = "exec SP_dramldrg_BY_newcode @newcode='" & newcode & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_dramldrg_BY_newcode"
        Return dta
    End Function
    Public Function SP_dramldrg_GRID_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_dramldrg_GRID_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_dramldrg_GRID_BY_FK_IDA"
        Return dta
    End Function

    Public Function SP_drramldrg_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_drramldrg_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_drramldrg_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_REGIST_ANIMAL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_REGIST_ANIMAL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_REGIST_ANIMAL_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_drramldrg_GRID_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_drramldrg_GRID_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_drramldrg_GRID_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_ANIMAL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_ANIMAL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_ANIMAL_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_dramluse_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_dramluse_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_dramluse_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_dramluse_BY_FK_IDA_V2(ByVal fk_ida As Integer, ByVal amltpcd As Integer, ByVal amlsubcd As Integer, ByVal usetpcd As Integer) As DataTable
        Dim sql As String = "exec SP_dramluse_BY_FK_IDA_V2 @FK_IDA=" & fk_ida & " ,@amltpcd=" & amltpcd & " ,@amlsubcd=" & amlsubcd & ", @usetpcd=" & usetpcd
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_dramluse_BY_FK_IDA_V2"
        Return dta
    End Function
    Public Function SP_drramluse_BY_FK_IDA_V2(ByVal fk_ida As Integer, ByVal amltpcd As Integer, ByVal amlsubcd As Integer, ByVal usetpcd As Integer) As DataTable
        Dim sql As String = "exec SP_drramluse_BY_FK_IDA_V2 @FK_IDA=" & fk_ida & " ,@amltpcd=" & amltpcd & " ,@amlsubcd=" & amlsubcd & ", @usetpcd=" & usetpcd
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_drramluse_BY_FK_IDA_V2"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_ANIMAL_SUB_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_ANIMAL_SUB_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_ANIMAL_SUB_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_drramluse_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_drramluse_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_drramluse_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_KEEP_DRUG_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_KEEP_DRUG_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_KEEP_DRUG_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_KEEP_DRUG_BY_newcode(ByVal newcode As String) As DataTable
        Dim sql As String = "exec SP_DRRGT_KEEP_DRUG_BY_newcode @newcode='" & newcode & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_KEEP_DRUG_BY_newcode"
        Return dta
    End Function
    Public Function SP_DRRGT_EDIT_REQUEST_HISTORY(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_HISTORY @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_EDIT_REQUEST_HISTORY"
        Return dta
    End Function
    Public Function SP_DRRGT_SPC_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_SPC_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_SPC_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PIL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PIL_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_KEEP_DRUG_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_KEEP_DRUG_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_KEEP_DRUG_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_REGIST_KEEP_DRUG_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_REGIST_KEEP_DRUG_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_REGIST_KEEP_DRUG_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_PI_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PI_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PI_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_EQTO_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_EQTO_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_EQTO_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_EQTO_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_EQTO_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_EQTO_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_NAME_DRUG_EXPORT_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_NAME_DRUG_EXPORT_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_NAME_DRUG_EXPORT_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_NAME_DRUG_EXPORT_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_NAME_DRUG_EXPORT_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_NAME_DRUG_EXPORT_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_DETAIL_CAS_BY_FK_IDA_NEW(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_DETAIL_CAS_BY_FK_IDA_NEW @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_DETAIL_CAS_BY_FK_IDA_NEW"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_DETAIL_CAS_BY_FK_IDAV2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_DETAIL_CAS_BY_FK_IDAV2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_DETAIL_CAS_BY_FK_IDAV2"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_DETAIL_CAS_BY_FK_IDAV3(ByVal fk_ida As Integer, ByVal _set As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_DETAIL_CAS_BY_FK_IDAV3 @FK_IDA=" & fk_ida & " ,@set= " & _set
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_DETAIL_CAS_BY_FK_IDAV3"
        Return dta
    End Function
    Public Function SP_DRRGT_PROPERTIES_AND_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PROPERTIES_AND_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PROPERTIES_AND_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PROPERTIES_AND_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PROPERTIES_AND_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_PROPERTIES_AND_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_PACKAGE_DETAIL_BY_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PACKAGE_DETAIL_BY_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PACKAGE_DETAIL_BY_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PACKAGE_DETAIL_BY_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PACKAGE_DETAIL_BY_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PACKAGE_DETAIL_BY_IDA"
        Return dta
    End Function
    'conn_DRUG
    Public Function SP_ATC_ALL(ByVal atccd As String) As DataTable
        Dim sql As String = "select * from dbo.ATC_DRUG where atccd like '" & atccd & "%' and atccd <> '" & atccd & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PACKAGE_DETAIL_BY_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_ATC_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_ATC_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_ATC_DETAIL_BY_Newcode(ByVal newcode As String) As DataTable
        Dim sql As String = "exec SP_DRRGT_ATC_DETAIL_BY_Newcode @newcode='" & newcode & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_EACH_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_EACH_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_EACH_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_EACH_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_EACH_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_EACH_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_ATC_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_ATC_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_ATC_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_REGIST_ATC_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_REGIST_ATC_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_REGIST_ATC_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_PROPERTIES_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PROPERTIES_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PROPERTIES_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PROPERTIES_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PROPERTIES_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PROPERTIES_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_PRODUCER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PRODUCER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PRODUCER_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(ByVal fk_ida As Integer, ByVal _type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE @FK_IDA=" & fk_ida & " ,@type=" & _type
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(ByVal fk_ida As Integer, ByVal _type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2 @FK_IDA=" & fk_ida & " ,@type=" & _type
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(ByVal newcode As String, ByVal _type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE @newcode='" & newcode & "' ,@type=" & _type
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2"
        Return dta
    End Function
    Public Function SP_DRRGT_PRODUCER_BY_FK_IDA_V2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA_V2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_V2"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PRODUCER_ALL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_ALL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_ALL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PRODUCER_ALL_BY_NEWCODE(ByVal newcode As String) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_ALL_BY_NEWCODE @newcode='" & newcode & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_ALL_BY_NEWCODE"
        Return dta
    End Function
    Public Function SP_DRRQT_PRODUCER_BY_FK_IDA_V2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PRODUCER_BY_FK_IDA_V2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_V2"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PRODUCER_ALL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PRODUCER_ALL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_PRODUCER_ALL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_REGIST_PRODUCER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_REGIST_PRODUCER_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_REGIST_PRODUCER_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(ByVal fk_ida As Integer, ByVal _type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE @FK_IDA=" & fk_ida & " ,@type=" & _type
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE"
        Return dta
    End Function
    Public Function SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PRODUCER_OTHER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PRODUCER_OTHER_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_PACKAGE_BY_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_PACKAGE_BY_IDA_v2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_PACKAGE_BY_IDA_v2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA_v2"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PACKAGE_DETAIL_BY_IDA_V2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PACKAGE_DETAIL_BY_IDA_V2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_PACKAGE_DETAIL_BY_IDA_V2"
        Return dta
    End Function
    Public Function SP_DRUG_DRRQT_PACKAGE_BY_IDA_v2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_DRRQT_PACKAGE_BY_IDA_v2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_DRRQT_PACKAGE_BY_IDA_v2"
        Return dta
    End Function
    Public Function SP_DRUG_DRRGT_PACKAGE_BY_IDA_v2(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_DRRGT_PACKAGE_BY_IDA_v2 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_DRRGT_PACKAGE_BY_IDA_v2"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V3(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V3 @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V3"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_EQTO_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_EQTO_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_EQTO_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2(ByVal fk_ida As Integer, ByVal aori As String) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2 @FK_IDA=" & fk_ida & " ,@aori='" & aori & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_V2"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_DETAIL_CAS_BY_FK_IDA__AORI(ByVal fk_ida As Integer, ByVal aori As String) As DataTable
        Dim sql As String = "exec SP_DRRGT_DETAIL_CAS_BY_FK_IDA__AORI @FK_IDA=" & fk_ida & " ,@aori='" & aori & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA__AORI"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA @FK_IDA=" & fk_ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE(ByVal fk_ida As Integer, ByVal _type As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE @FK_IDA=" & fk_ida & " ,@type=" & _type
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE"
        Return dta
    End Function
    '
    Public Function SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ByVal fk_ida As Integer, ByVal _type As Integer, ByVal lcn_type As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE @FK_IDA=" & fk_ida & " ,@type=" & _type & ",@lcn_type=" & lcn_type
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ByVal fk_ida As Integer, ByVal _type As Integer, ByVal lcn_type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE @FK_IDA=" & fk_ida & " ,@type=" & _type & ",@lcn_type=" & lcn_type
        Dim dta As New DataTable
        dta = Queryds(sql)
        'dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(ByVal fk_ida As Integer, ByVal _type As Integer, ByVal lcn_type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER @FK_IDA=" & fk_ida & " ,@type=" & _type & ",@lcn_type=" & lcn_type
        Dim dta As New DataTable
        dta = Queryds(sql)
        'dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(ByVal fk_ida As Integer, ByVal _type As Integer, ByVal lcn_type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER @FK_IDA=" & fk_ida & " ,@type=" & _type & ",@lcn_type=" & lcn_type
        Dim dta As New DataTable
        dta = Queryds(sql)
        'dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE"
        Return dta
    End Function
    Public Function SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ByVal fk_ida As Integer, ByVal _type As Integer, ByVal lcn_type As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE @FK_IDA=" & fk_ida & " ,@type=" & _type & ",@lcn_type=" & lcn_type
        Dim dta As New DataTable
        dta = Queryds(sql)
        'dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_CAS_EQTO(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_CAS_EQTO @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        'dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE"
        Return dta
    End Function
    Public Function SP_DRRQT_CAS_EQTO(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_CAS_EQTO @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        'dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION"
        Return dta
    End Function

    Public Function SP_DALCN_BY_IDA_FOR_NYM(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DALCN_BY_IDA_FOR_NYM @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DALCN_BY_IDA_FOR_NYM"
        Return dta
    End Function

    Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA @FK_IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA"
        Return dta
    End Function

    Public Function SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM"
        Return dta
    End Function
    '
    Public Function SP_syspdcfrgn_SEARCH(ByVal engfrgnnm As String) As DataTable
        Dim sql As String = "exec SP_syspdcfrgn_SEARCH @engfrgnnm='" & engfrgnnm & "'"
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_syspdcfrgn_SEARCH"
        Return dta
    End Function
    '
    Public Function SP_drfrgnaddr_BY_frgncd(ByVal frgncd As Integer) As DataTable
        Dim sql As String = "exec SP_drfrgnaddr_BY_frgncd @frgncd=" & frgncd
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_drfrgnaddr_BY_frgncd"
        Return dta
    End Function
    Public Function SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA @FK_IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_PACKAGE_DETAIL_CHK_BY_FK_IDA(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_PACKAGE_DETAIL_CHK_BY_FK_IDA @FK_IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA"
        Return dta
    End Function
    Public Function SP_DRUG_REGISTRATION_MASTER(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRUG_REGISTRATION_MASTER @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRUG_REGISTRATION_MASTER"
        Return dta
    End Function
    '
    Public Function SP_DRRGT_DATA(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRGT_DATA @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DATA"
        Return dta
    End Function
    '
    Public Function SP_DRRQT_DATA(ByVal ida As Integer) As DataTable
        Dim sql As String = "exec SP_DRRQT_DATA @IDA=" & ida
        Dim dta As New DataTable
        dta = Queryds(sql)
        dta.TableName = "SP_DRRGT_DATA"
        Return dta
    End Function
    ''' <summary>
    ''' ดึงข้อมูล ตำบล
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SP_SYSTHMBL() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSTHMBL"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSTHMBL"
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
    ''' ดึงข้อมูลจากเลขบัตรประชาชน
    ''' </summary>
    ''' <param name="CTZNO"></param>
    ''' <returns></returns>]\
    ''' <remarks></remarks>
    Public Function SP_MAINPERSON_CTZNO(ByVal CTZNO As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAINPERSON_CTZNO @ctzno = '" & CTZNO & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_MAINPERSON_CTZNO"
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
    Public Function SP_SYSAMPHR_BY_CHNGWTCD(ByVal chngwt As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSAMPHR_BY_CHNGWTCD @chngwt=" & chngwt
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)

        Return dt
    End Function

    Public Function SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD(ByVal chngwt As Integer, ByVal amp As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSTHMBL_BY_CHNGWTCD_AND_AMPHRCD @chngwtcd=" & chngwt & " ,@amphrcd=" & amp
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)

        Return dt
    End Function
    ''' <summary>
    ''' ดึงข้อมูลบริษัท
    ''' </summary>
    ''' <param name="LCNSID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_MAINCOMPANY_LCNSID(ByVal LCNSID As Integer) As DataTable

        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_MAINCOMPANY_LCNSID @LCNSID = " & LCNSID & ",@lctcd = 1"
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
        dt.TableName = "SP_MAINCOMPANY"
        Return dt
    End Function



    ''' <summary>
    ''' ดึงข้อมูลประเทศ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SYSISOCNT() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSISOCNT"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn).Tables(0)
        dt.TableName = "SP_SYSISOCNT"
        Return dt
    End Function


    ''' <summary>
    ''' คำนำหน้าชื่อของคน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>type 1 ,8 </remarks>
    Public Function SP_SYSPREFIX() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSPREFIX"
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
        dt.TableName = "SP_SYSPREFIX"
        Return dt
    End Function
    '
    Public Function SP_SYSPREFIX_DDL() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSPREFIX_DDL"
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
        dt.TableName = "SP_SYSPREFIX_DDL"
        Return dt
    End Function
    ''' <summary>
    ''' คำลงท้ายชื่อ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SYSSUFFIX() As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSSUFFIX"
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
        dt.TableName = "SP_SYSSUFFIX"
        Return dt
    End Function



    ''' <summary>
    ''' สถานที่จำลองตามtype
    ''' </summary>
    ''' <param name="LOCATION_TYPE_CD"></param>
    ''' <param name="LCNSID"></param>
    ''' <returns></returns>
    ''' <remarks>0 หลัก,1ที่อยู่,2เก็บ,3อื่นๆ</remarks>
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(ByVal LOCATION_TYPE_CD As Integer, ByVal LCNSID As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID @LOCATION_TYPE_CD= " & LOCATION_TYPE_CD & " ,@LCNSID= '" & LCNSID & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        Return dt
    End Function
    '
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(ByVal LOCATION_TYPE_CD As Integer, ByVal iden As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2 @LOCATION_TYPE_CD= " & LOCATION_TYPE_CD & " ,@iden= '" & iden & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        Return dt
    End Function
    '
    Public Function SP_DRUG_GROUP_LCN(ByVal lcn_ida As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DRUG_GROUP_LCN @lcn_ida= " & lcn_ida
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_DRUG_GROUP_LCN"
        Return dt
    End Function
    '
    Public Function SP_DRUG_GROUP_LCN_HERB(ByVal lcn_ida As Integer, ByVal type_lcn As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DRUG_GROUP_LCN_HERB @lcn_ida= " & lcn_ida & " ,@type_lcn=" & type_lcn
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_DRUG_GROUP_LCN_HERB"
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2_1(ByVal LOCATION_TYPE_CD As Integer, ByVal iden As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2_1 @LOCATION_TYPE_CD= " & LOCATION_TYPE_CD & " ,@iden= '" & iden & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2_1"
        Return dt
    End Function
    ''' <summary>
    ''' ข้อมูลบริษัท
    ''' </summary>
    ''' <param name="identify"></param>
    ''' <param name="LCNSID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(ByVal identify As String, ByVal LCNSID As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid='" & LCNSID & "' ,@identify= '" & identify & "'"
        ' Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid=" & "0" & " ,@identify=" & "0"
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
        dt.TableName = "SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY"
        Return dt
    End Function
    Public Function SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(ByVal identify As String, ByVal LCNSID As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2 @lcnsid='" & LCNSID & "' ,@identify= '" & identify & "'"
        ' Dim sql As String = "exec SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY @lcnsid=" & "0" & " ,@identify=" & "0"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn).Tables(0)
        Catch ex As Exception

        End Try

        dt.TableName = "SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY"
        Return dt
    End Function
    '
    ''' <summary>
    ''' สถานที่จำลอง
    ''' </summary>
    ''' <param name="LOCATION_ADDRESS_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(ByVal LOCATION_ADDRESS_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA @LOCATION_ADDRESS_IDA = " & LOCATION_ADDRESS_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA"
        Return dt
    End Function
    '
    Public Function SP_DRRGT_ADDR_BY_IDA(ByVal LOCATION_ADDRESS_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DRRGT_ADDR_BY_IDA @LOCATION_ADDRESS_IDA = " & LOCATION_ADDRESS_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_DRRGT_ADDR_BY_IDA"
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION(ByVal LOCATION_ADDRESS_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_MUTI_LOCATION @LOCATION_ADDRESS_IDA = " & LOCATION_ADDRESS_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA"
        Return dt
    End Function
    '
    Public Function SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_NEWCODE_SAI(ByVal newcode As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_NEWCODE_SAI @newcode = '" & newcode & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA"
        Return dt
    End Function
    Public Function SP_drrqt_cas(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_drrqt_cas @IDA = " & IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_drrqt_cas"
        Return dt
    End Function
    Public Function SP_drrgt_cas(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_drrgt_cas @IDA = " & IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_drrgt_cas"
        Return dt
    End Function
    Public Function SP_GETDATA_EXTENDPDF_by_IDA(ByVal IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_GETDATA_EXTENDPDF_by_IDA @IDA = " & IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_GETDATA_EXTENDPDF_by_IDA"
        Return dt
    End Function
    '
    Public Function SP_DATA_SHOW_PRODUCT_ID_BY_IDA(ByVal product_ida As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DATA_SHOW_PRODUCT_ID_BY_IDA @product_ida = " & product_ida
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_DATA_SHOW_PRODUCT_ID_BY_IDA"
        Return dt
    End Function

    ''' <summary>
    ''' ผู้ดำเนินกิจการ
    ''' </summary>
    ''' <param name="LOCATION_ADDRESS_IDA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(ByVal LOCATION_ADDRESS_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA @LOCATION_ADDRESS_IDA = " & LOCATION_ADDRESS_IDA
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
        dt.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Return dt
    End Function
    Public Function SP_DOWNDATA_EXTENDPDF_by_IDA(ByVal LCN_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DOWNDATA_EXTENDPDF_by_IDA @IDA = " & LCN_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_DOWNDATA_EXTENDPDF_by_IDA"
        Return dt
    End Function
    '
    Public Function SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(ByVal LOCATION_ADDRESS_IDA As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA @LOCATION_ADDRESS_IDA = " & LOCATION_ADDRESS_IDA
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Return dt
    End Function
    '
    Public Function SP_LOCATION_BSN_BY_IDENTIFY(ByVal iden As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_BSN_BY_IDENTIFY @iden = '" & iden & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Return dt
    End Function
    '
    Public Function SP_LOCATION_BSN_BY_LCN_IDA(ByVal lcnida As Integer) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_BSN_BY_LCN_IDA @LCN_IDA=" & lcnida
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
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

    Public Function SP_DRUG_SCHEDULE_by_REF_C_NUMBER(ByVal c_no As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DRUG_SCHEDULE_by_REF_C_NUMBER @REF_C_NUMBER ='" & c_no & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_book).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_DRUG_SCHEDULE_by_REF_C_NUMBER"
        Return dt
    End Function
    '
    Public Function SP_DRUG_SCHEDULE_by_REF_C_NUMBER_V2(ByVal c_no As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_DRUG_SCHEDULE_by_REF_C_NUMBER_V2 @REF_C_NUMBER ='" & c_no & "'"
        Dim dt As New DataTable
        Try
            dt = clsds.dsQueryselect(sql, conn_book).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        If dt.Rows.Count() = 0 Then
            dt = AddDatatable(dt)
        End If
        dt.TableName = "SP_DRUG_SCHEDULE_by_REF_C_NUMBER"
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM3(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM3 @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM3"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count() = 1 Then
                dt.Clear()
            Else
                dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            End If
        Catch ex As Exception

        End Try
        '   If dt.Rows.Count() = 0 Then
        '  dt = AddDatatable(dt)
        ' End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM3_TOPROW(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM3_TOPROW @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM3_TOPROW"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        ' If dt.Rows.Count() = 0 Then
        'dt = AddDatatable(dt)
        'End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM3_ONLY1(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM3_ONLY1 @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM3_ONLY1"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count > 1 Then
                ' dt = AddDatatable(dt)
                dt = SP_LOCATION_ADDRESS_BY_IDA_NYM3_TOPROW(ida)
                Exit Try
            Else
                ' dt = SP_LOCATION_ADDRESS_BY_IDA_NYM2_TOPROW(ida)
                'dt = AddDatatable(dt)
                Exit Try
            End If
        Catch ex As Exception

        End Try
        ' If dt.Rows.Count() = 0 Then
        'dt = AddDatatable(dt)
        'End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM2(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM2 @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM2"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count() = 1 Then
                dt.Clear()
            Else
                ' dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            End If
        Catch ex As Exception

        End Try
        '   If dt.Rows.Count() = 0 Then
        '  dt = AddDatatable(dt)
        ' End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM2_TOPROW(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM2_TOPROW @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM2_TOPROW"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count() = 0 Then
                ' dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        ' If dt.Rows.Count() = 0 Then
        'dt = AddDatatable(dt)
        'End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM2_ONLY1(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM2_ONLY1 @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM2_ONLY1"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count > 1 Then
                ' dt = AddDatatable(dt)
                dt = SP_LOCATION_ADDRESS_BY_IDA_NYM2_TOPROW(ida)
                Exit Try
            Else
                ' dt = SP_LOCATION_ADDRESS_BY_IDA_NYM2_TOPROW(ida)
                'dt = AddDatatable(dt)
                Exit Try
            End If
        Catch ex As Exception

        End Try
        ' If dt.Rows.Count() = 0 Then
        'dt = AddDatatable(dt)
        'End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM4(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM4 @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM4"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count() = 1 Then
                dt.Clear()
            Else
                dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            End If
        Catch ex As Exception

        End Try
        '   If dt.Rows.Count() = 0 Then
        '  dt = AddDatatable(dt)
        ' End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM4_TOPROW(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM4_TOPROW @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM4_TOPROW"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If
        Catch ex As Exception

        End Try
        ' If dt.Rows.Count() = 0 Then
        'dt = AddDatatable(dt)
        'End If
        Return dt
    End Function
    Public Function SP_LOCATION_ADDRESS_BY_IDA_NYM4_ONLY1(ByVal ida As String) As DataTable
        Dim clsds As New ClassDataset
        Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA_NYM4_ONLY1 @IDA='" & ida & "'"
        Dim dt As New DataTable
        dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
        dt.TableName = "SP_LOCATION_ADDRESS_BY_IDA_NYM4_ONLY1"
        Try
            dt = clsds.dsQueryselect(sql, conn_DRUG_IMPORT).Tables(0)
            If dt.Rows.Count > 1 Then
                ' dt = AddDatatable(dt)
                dt = SP_LOCATION_ADDRESS_BY_IDA_NYM4_TOPROW(ida)
                Exit Try
            Else
                ' dt = SP_LOCATION_ADDRESS_BY_IDA_NYM2_TOPROW(ida)
                'dt = AddDatatable(dt)
                Exit Try
            End If
        Catch ex As Exception

        End Try
        ' If dt.Rows.Count() = 0 Then
        'dt = AddDatatable(dt)
        'End If
        Return dt
    End Function

End Class
