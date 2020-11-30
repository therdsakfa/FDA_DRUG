Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Namespace BAO

    Public Class ClsDBSqlcommand


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
                    dr(c.ColumnName) = "-"
                ElseIf c.DataType.Name.ToString() = "Int32" Then
                    dr(c.ColumnName) = 0
                ElseIf c.DataType.Name.ToString() = "DateTime" Then
                    dr(c.ColumnName) = Date.Now 'Nothing 
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

        Public dt As New DataTable
        Dim rdr As SqlDataReader

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString)
        Dim conndrugimport As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FDA_DRUG_IMPORTConnectionString").ConnectionString)
        Public condrugimport As String = System.Configuration.ConfigurationManager.ConnectionStrings("FDA_DRUG_IMPORTConnectionString").ConnectionString
        Public con_str As String = System.Configuration.ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString
        Dim conn_CPN As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString1").ConnectionString)
        Dim con_124 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_DRUGConnectionString1").ConnectionString)
        Dim con_m44 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FDA_SPECIAL_PAYMENTConnectionString").ConnectionString)
        Dim con_fee As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FDA_FEEConnectionString").ConnectionString)
        Dim con_book As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FDA_BOOKINGConnectionString").ConnectionString)
        Dim conn_PERMISSION As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGT_PERMISSIONConnectionString").ConnectionString)
        Dim conn_NCT As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGT_NCTConnectionString").ConnectionString)
        Dim con_124_2 As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_DRUG_ESUBConnectionString").ConnectionString)

        Dim SqlCmd As SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim objds As New DataSet
        Dim strSQL As String = String.Empty
        '
        ''
        Public Function GET_IOWA_NULL() As DataTable
            Dim sql As String = "select * from [dbo].[driowa_temp] where  NO_ITEM is null"
            Dim dta As New DataTable
            dta = Queryds(sql)

            Return dta
        End Function
        '
        Public Function SP_GET_GROUP_IOWA(ByVal iowacd As String) As DataTable

            Dim sql As String = "exec SP_GET_GROUP_IOWA @iowacd= '" & iowacd & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function UPDATE_IOWA(ByVal iowacd As String, ByVal product As Object, ByVal import As Object, ByVal boths As Object, Optional NO_ITEM As Integer = 0) As DataTable
            Dim sql As String = "update [dbo].[driowa_temp] set Procuct=" & product & " , Import=" & import & " , Both=" & boths & " , NO_ITEM=" & NO_ITEM & " where iowacd ='" & iowacd & "'"

            Dim dta As New DataTable
            dta = Queryds(sql)

            Return dta
        End Function

        Public Function SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDENTITY(ByVal LOCATION_TYPE_ID As Integer, ByVal IDENTITY As String) As DataTable

            Dim sql As String = "exec SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDENTITY @LOCATION_TYPE_ID=" & LOCATION_TYPE_ID & ",@IDENTITY= '" & IDENTITY & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function XML_SEARCH_PRODUCT_GROUP(ByVal IDENTITY As String) As DataTable

            Dim sql As String = "exec dbo.XML_SEARCH_PRODUCT_GROUP @identify= '" & IDENTITY & "'"
            Dim dta As New DataTable
            dta = Queryd_124_2(sql)
            Return dta
        End Function
        '
        Public Function SELECT_TEMP_DH() As DataTable
            Dim sql As String = "select * from [dbo].[TEMP_DH]"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_LCN_EXTEND_RECEIPT_LIST(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_LCN_EXTEND_RECEIPT_LIST @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_GPP_BY_YEAR_EXT(ByVal _year As Integer) As DataTable
            Dim sql As String = "exec SP_GPP_BY_YEAR_EXT @year=" & _year
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_CUSTOMER_LCN_BY_IDENTIFY(ByVal IDENTITY As String) As DataTable

            Dim sql As String = "exec SP_CUSTOMER_LCN_BY_IDENTIFY @iden= '" & IDENTITY & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_CUSTOMER_LCN_DH_BY_IDENTIFY(ByVal IDENTITY As String) As DataTable

            Dim sql As String = "exec SP_CUSTOMER_LCN_DH_BY_IDENTIFY @iden= '" & IDENTITY & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_CUSTOMER_LCN_DR_BY_IDENTIFY(ByVal IDENTITY As String) As DataTable

            Dim sql As String = "exec SP_CUSTOMER_LCN_DR_BY_IDENTIFY @iden= '" & IDENTITY & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '      'SELECT TOP 1000 [IDpimary]
        '    ,[IDgroup]
        '    ,[IDnamesys]
        '    ,[IDmenu]
        '    ,[IDchngwtcd]
        '    ,[thachngwtnm]
        '    ,[IDA]
        '    ,[explair_date]
        '    ,[taxno_authorize]
        'FROM [LGT_PERMISSION].[dbo].[groupbysystembymenu] where [IDnamesys] = 8734 and [IDgroup]= 260532 and [IDmenu] = ''
        'and [taxno_authorize] = ''
        Public Function Count_Permission_Menu(ByVal IDnamesys As Integer, ByVal IDgroup As Integer, ByVal idMenu As String, ByVal identify As String) As Integer
            Dim i As Integer = 0
            Dim sql As String = "SELECT * from [dbo].[groupbysystembymenu] where [IDnamesys] =" & IDnamesys & " and [IDgroup]= " & IDgroup & "  and [IDmenu] = " & idMenu & " and [taxno_authorize] = '" & identify & "'"
            Dim dta As New DataTable
            dta = Queryds_PERMISSION(sql)
            For Each dr As DataRow In dta.Rows
                i += 1
            Next
            Return i
        End Function


        Public Sub insert_tabean_sub(ByVal FK_IDA As Integer)
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(FK_IDA)

            Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
            With dao_drrgt.fields
                .accttp = dao.fields.accttp
                .appdate = dao.fields.appdate
                .CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
                .CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
                .CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
                .classcd = dao.fields.classcd
                .CONSIDER_DATE = dao.fields.CONSIDER_DATE
                .ctgcd = dao.fields.ctgcd
                .CTZNO = dao.fields.CTZNO
                .drgbiost = dao.fields.drgbiost
                .drgexpst = dao.fields.drgexpst
                .drgnewst = dao.fields.drgnewst
                .PACKAGE_DETAIL = dao.fields.PACKAGE_DETAIL
                Try
                    .rcptpayst = dao.fields.dvcd
                Catch ex As Exception

                End Try
                'Try
                '    .drgtpcd = ddl_tabean_group.SelectedValue 'dao.fields.drgtpcd
                'Catch ex As Exception

                'End Try
                Try
                    If dao.fields.rgttpcd <> "G" And dao.fields.rgttpcd <> "H" And dao.fields.rgttpcd <> "K" Then
                        If CDate(dao.fields.appdate).ToString("yyyy/MM/dd") >= "2562/01/01" And CDate(dao.fields.appdate).ToString("yyyy/MM/dd") <= "2562/10/12" Then
                            .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 9, CDate(dao.fields.appdate)))
                        ElseIf CDate(dao.fields.appdate).ToString("yyyy/MM/dd") > "2562/10/12" Then
                            .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 7, CDate(dao.fields.appdate)))
                        End If

                    Else
                        If CDate(dao.fields.appdate) >= "2562/01/01" And CDate(dao.fields.appdate).ToString("yyyy/MM/dd") <= "2562/06/28" Then
                            .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 9, CDate(dao.fields.appdate)))
                        ElseIf CDate(dao.fields.appdate).ToString("yyyy/MM/dd") > "2562/06/28" Then
                            .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 5, CDate(dao.fields.appdate)))
                        End If
                    End If

                Catch ex As Exception

                End Try

                Try
                    .FK_TRANSFER = dao.fields.FK_TRANSFER
                Catch ex As Exception

                End Try
                Try
                    .TRANSFER_TYPE = dao.fields.TRANSFER_TYPE
                Catch ex As Exception

                End Try
                Try

                Catch ex As Exception

                End Try
                .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
                .dsgcd = dao.fields.dsgcd
                .engdrgnm = dao.fields.engdrgnm
                .EXTEND_DATE = dao.fields.EXTEND_DATE
                .FIRST_APP_DATE = dao.fields.FIRST_APP_DATE
                .FK_DOSAGE_FORM = dao.fields.FK_DOSAGE_FORM
                .FK_DRRQT = FK_IDA
                .FK_IDA = dao.fields.FK_IDA
                .FK_LCN_IDA = dao.fields.FK_LCN_IDA
                .FK_STAFF_OFFER_IDA = dao.fields.FK_STAFF_OFFER_IDA
                .frtappdate = dao.fields.FIRST_APP_DATE
                .IDENTIFY = dao.fields.IDENTIFY
                .kindcd = dao.fields.kindcd
                .lcnabbr = dao.fields.lcnabbr
                .UNIT_NORMAL = dao.fields.UNIT_NORMAL
                .DRUG_PACKING = dao.fields.DRUG_PACKING
                .UNIT_BIO = dao.fields.UNIT_BIO
                .DRUG_STYLE = dao.fields.DRUG_STYLE
                .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
                Try
                    .lcnno = dao.fields.lcnno
                Catch ex As Exception

                End Try

                .lcnscd = dao.fields.lcnscd
                .lcnsid = dao.fields.lcnsid
                .lcntpcd = dao.fields.lcntpcd
                .lctcd = dao.fields.lctcd
                .lctnmcd = dao.fields.lctnmcd
                Try
                    .lmdfdate = dao.fields.lmdfdate
                Catch ex As Exception

                End Try

                .lpvncd = dao.fields.lpvncd
                .lstfcd = dao.fields.lstfcd
                .ndrgtp = dao.fields.ndrgtp
                .packcd = dao.fields.packcd
                .potency = dao.fields.potency
                .PROCESS_ID = dao.fields.PROCESS_ID
                .pvnabbr = dao.fields.pvnabbr
                .pvncd = dao.fields.pvncd
                .pvnabbr2 = dao.fields.pvnabbr2
                .USE_PVNABBR2 = dao.fields.USE_PVNABBR2
                Try
                    .rcvdate = dao.fields.rcvdate
                Catch ex As Exception

                End Try

                .rcvno = dao.fields.rcvno
                .REGIST_TYPE = dao.fields.REGIST_TYPE
                .REMARK = dao.fields.REMARK
                .rgtno = dao.fields.rgtno
                Try
                    .rgttpcd = dao.fields.rgttpcd
                    '.rgttpcd = ddl_rgttpcd.SelectedValue
                Catch ex As Exception

                End Try
                Try
                    .drgtpcd = dao.fields.drgtpcd
                Catch ex As Exception

                End Try
                .STAFF_APP_IDENTIFY = dao.fields.STAFF_APP_IDENTIFY
                .STATUS_ID = dao.fields.STATUS_ID
                .TABEAN_TYPE = dao.fields.TABEAN_TYPE
                .thadrgnm = dao.fields.thadrgnm
                .TR_ID = dao.fields.TR_ID
                Try
                    .UNIT_BIO = dao.fields.UNIT_BIO
                Catch ex As Exception

                End Try
                Try
                    .UNIT_NORMAL = dao.fields.UNIT_NORMAL
                Catch ex As Exception

                End Try
                Try
                    .DRUG_PACKING = dao.fields.DRUG_PACKING
                Catch ex As Exception

                End Try
                Try
                    .TYPE_REQUEST_ID = dao.fields.TYPE_REQUEST_ID
                Catch ex As Exception

                End Try
                Try
                    .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
                Catch ex As Exception

                End Try
            End With
            dao_drrgt.insert()
            Dim IDA_rgt As Integer = dao_drrgt.fields.IDA



            Dim bao_insert_addr As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Try
                dt = bao_insert_addr.SP_DRRGT_ADDR_INSERT(IDA_rgt)
            Catch ex As Exception

            End Try

            Dim dao_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
            dao_atc.GetDataby_FK_IDA(FK_IDA)
            For Each dao_atc.fields In dao_atc.datas
                Dim dao_rgt_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                With dao_rgt_atc.fields
                    .ATC_CODE = dao_atc.fields.ATC_CODE
                    .ATC_IDA = dao_atc.fields.ATC_IDA
                    .FK_IDA = IDA_rgt
                End With
                dao_rgt_atc.insert()
            Next


            Dim dao_cas As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
            dao_cas.GetDataby_FK_IDA(FK_IDA)
            For Each dao_cas.fields In dao_cas.datas
                Dim dao_rgt_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                With dao_rgt_cas.fields
                    .AORI = dao_cas.fields.AORI
                    .BASE_FORM = dao_cas.fields.BASE_FORM
                    .EQTO_IOWA = dao_cas.fields.EQTO_IOWA
                    .EQTO_QTY = dao_cas.fields.EQTO_QTY
                    .EQTO_SUNITCD = dao_cas.fields.EQTO_SUNITCD
                    .FK_IDA = IDA_rgt
                    .FK_SET = dao_cas.fields.FK_SET
                    .IOWA = dao_cas.fields.IOWA
                    .QTY = dao_cas.fields.QTY
                    .ROWS = dao_cas.fields.ROWS
                    .SUNITCD = dao_cas.fields.SUNITCD
                    .REMARK = dao_cas.fields.REMARK
                    .REF = dao_cas.fields.REF
                    .CAS_TYPE = dao_cas.fields.CAS_TYPE
                    .CONDITION = dao_cas.fields.CONDITION
                    .ebioqty = dao_cas.fields.ebioqty
                    .ebiosqno = dao_cas.fields.ebiosqno
                    .ebiounitcd = dao_cas.fields.ebiounitcd
                    .mltplr = dao_cas.fields.mltplr
                    .QTY2 = dao_cas.fields.QTY2
                    .sbioqty = dao_cas.fields.sbioqty
                    .sbiosqno = dao_cas.fields.sbiosqno
                    .sbiounitcd = dao_cas.fields.sbiounitcd
                End With
                dao_rgt_cas.insert()

                Dim dao_eq As New DAO_DRUG.TB_DRRQT_EQTO
                dao_eq.GetDataby_FK_IDA(dao_cas.fields.IDA)
                For Each dao_eq.fields In dao_eq.datas
                    Dim dao_eq_rgt As New DAO_DRUG.TB_DRRGT_EQTO
                    With dao_eq_rgt.fields
                        .FK_IDA = dao_rgt_cas.fields.IDA
                        .IOWA = dao_eq.fields.IOWA
                        .MULTIPLY = dao_eq.fields.MULTIPLY
                        .QTY = dao_eq.fields.QTY
                        .ROWS = dao_eq.fields.ROWS
                        .STR_VALUE = dao_eq.fields.STR_VALUE
                        .SUNITCD = dao_eq.fields.SUNITCD
                        .FK_SET = dao_eq.fields.FK_SET
                        .FK_DRRQT_IDA = IDA_rgt
                        .REMARK = dao_eq.fields.REMARK
                        .REF = dao_eq.fields.REF
                        .aori = dao_eq.fields.aori
                        .CONDITION = dao_eq.fields.CONDITION
                        '.ebioqty = dao_eq.fields.ebioqty
                        '.ebiosqno = dao_eq.fields.ebiosqno
                        '.ebiounitcd = dao_eq.fields.ebiounitcd
                        '.mltplr = dao_eq.fields.mltplr
                        '.QTY2 = dao_eq.fields.QTY2
                        '.sbioqty = dao_eq.fields.sbioqty
                        '.sbiosqno = dao_eq.fields.sbiosqno
                        '.sbiounitcd = dao_eq.fields.sbiounitcd
                    End With
                    dao_eq_rgt.insert()
                Next
            Next


            Dim dao_pack As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
            dao_pack.GetDataby_FKIDA(FK_IDA)
            For Each dao_pack.fields In dao_pack.datas
                Dim dao_rgt_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                With dao_rgt_pack.fields
                    .BARCODE = dao_pack.fields.BARCODE
                    .BIG_UNIT = dao_pack.fields.BIG_UNIT
                    .CHECK_PACKAGE = dao_pack.fields.CHECK_PACKAGE
                    .FK_IDA = IDA_rgt
                    .MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
                    .MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
                    .SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
                    .SMALL_UNIT = dao_pack.fields.SMALL_UNIT
                End With
                dao_rgt_pack.insert()
            Next


            Dim dao_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
            dao_pro.GetDataby_FK_IDA(FK_IDA)
            For Each dao_pro.fields In dao_pro.datas
                Dim dao_rgt_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
                With dao_rgt_pro.fields
                    .addr_ida = dao_pro.fields.addr_ida
                    .drgtpcd = dao_pro.fields.drgtpcd
                    .FK_IDA = IDA_rgt
                    .FK_PRODUCER = dao_pro.fields.FK_PRODUCER
                    .frgncd = dao_pro.fields.frgncd
                    .frgnlctcd = dao_pro.fields.frgnlctcd
                    .funccd = dao_pro.fields.funccd
                    .lcnno = dao_pro.fields.lcnno
                    .lcntpcd = dao_pro.fields.lcntpcd
                    .PRODUCER_WORK_TYPE = dao_pro.fields.PRODUCER_WORK_TYPE
                    .pvncd = dao_pro.fields.pvncd
                    .rcvno = dao_pro.fields.rcvno
                    .REFERENCE_GMP = dao_pro.fields.REFERENCE_GMP
                    .rgtno = dao_pro.fields.rgtno
                    .rgttpcd = dao_pro.fields.rgttpcd
                    .TR_ID = dao_pro.fields.TR_ID
                End With
                dao_rgt_pro.insert()
            Next

            Dim dao_conq As New DAO_DRUG.TB_DRRQT_CONDITION
            dao_conq.GetDataby_FK_IDA(FK_IDA)
            For Each dao_conq.fields In dao_conq.datas
                Dim dao_cong As New DAO_DRUG.TB_DRRGT_CONDITION
                With dao_cong.fields
                    .CONDITION1 = dao_conq.fields.CONDITION1
                    .CONDITION2 = dao_conq.fields.CONDITION2
                    .FK_IDA = IDA_rgt

                End With
                dao_cong.insert()
            Next


            Dim dao_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
            dao_pro_in.GetDataby_FK_IDA(FK_IDA)
            For Each dao_pro_in.fields In dao_pro_in.datas
                Dim dao_rgt_pro_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                With dao_rgt_pro_in.fields
                    .drgtpcd = dao_pro_in.fields.drgtpcd
                    .FK_IDA = IDA_rgt
                    .funccd = dao_pro_in.fields.funccd
                    .lcnno = dao_pro_in.fields.lcnno
                    .lcntpcd = dao_pro_in.fields.lcntpcd
                    .rgtno = dao_pro_in.fields.rgtno
                    .rgttpcd = dao_pro_in.fields.rgttpcd
                    .FK_LCN_IDA = dao_pro_in.fields.FK_LCN_IDA
                    .rgtno = dao_pro_in.fields.rgtno
                    .rgttpcd = dao_pro_in.fields.rgttpcd
                    .lctcd = dao_pro_in.fields.lctcd
                    .lcnsid = dao_pro_in.fields.lcnsid
                End With
                dao_rgt_pro_in.insert()
            Next


            Dim dao_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES
            dao_prop.GetDataby_FKIDA(FK_IDA)
            For Each dao_prop.fields In dao_prop.datas
                Dim dao_rgt_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
                With dao_rgt_prop.fields
                    .CHK_DRUG_PROPERTIES = dao_prop.fields.CHK_DRUG_PROPERTIES
                    .CHK_DRUG_PROPERTIES_OTHER = dao_prop.fields.CHK_DRUG_PROPERTIES_OTHER
                    .DRUG_PROPERTIES = dao_prop.fields.DRUG_PROPERTIES
                    .DRUG_PROPERTIES_OTHER = dao_prop.fields.DRUG_PROPERTIES_OTHER
                    .FK_IDA = IDA_rgt
                End With
                dao_rgt_prop.insert()
            Next


            Dim dao_prop_det As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            dao_prop_det.GetDataby_FKIDA(FK_IDA)
            For Each dao_prop_det.fields In dao_prop_det.datas
                Dim dao_rgt_pd As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
                With dao_rgt_pd.fields
                    .DRUG_PROPERTIES_AND_DETAIL = dao_prop_det.fields.DRUG_PROPERTIES_AND_DETAIL
                    .FK_IDA = IDA_rgt
                    .OTHER = dao_prop_det.fields.OTHER
                    .ROWS = dao_prop_det.fields.ROWS
                End With
                dao_rgt_pd.insert()
            Next

            Dim dao_each As New DAO_DRUG.TB_DRRQT_EACH
            dao_each.GetDataby_FK_IDA(FK_IDA)
            For Each dao_each.fields In dao_each.datas
                Dim dao_each_rgt As New DAO_DRUG.TB_DRRGT_EACH
                With dao_each_rgt.fields
                    .EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
                    .FK_IDA = IDA_rgt
                    .sunitcd = dao_each.fields.sunitcd
                End With
                dao_each_rgt.insert()
            Next

            Dim dao_keep As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
            dao_keep.GetDataby_FKIDA(FK_IDA)
            For Each dao_keep.fields In dao_keep.datas
                Dim dao_keep_rgt As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
                With dao_keep_rgt.fields
                    .AGE_DAY = dao_keep.fields.AGE_DAY
                    .FK_IDA = IDA_rgt
                    .AGE_HOUR = dao_keep.fields.AGE_HOUR
                    .AGE_MONTH = dao_keep.fields.AGE_MONTH
                    .DRUG_DETAIL = dao_keep.fields.DRUG_DETAIL
                    .KEEP_DESCRIPTION = dao_keep.fields.KEEP_DESCRIPTION
                    .TEMPERATE1 = dao_keep.fields.TEMPERATE1
                    .TEMPERATE2 = dao_keep.fields.TEMPERATE2
                End With
                dao_keep_rgt.insert()
            Next

            Dim dao_dtb As New DAO_DRUG.TB_DRRQT_DTB
            dao_dtb.GetDataby_FKIDA(FK_IDA)
            For Each dao_dtb.fields In dao_dtb.datas
                Dim dao_dtb_rgt As New DAO_DRUG.TB_DRRGT_DTB
                With dao_dtb_rgt.fields
                    .FK_IDA = IDA_rgt
                    .FK_LCN_IDA = dao_dtb.fields.FK_LCN_IDA
                End With
                dao_dtb_rgt.insert()
            Next

            'DRRGT_DTL_TEXT
            Dim dao_dtl As New DAO_DRUG.TB_DRRQT_DTL_TEXT
            dao_dtl.GetDataby_FKIDA(FK_IDA)
            For Each dao_dtl.fields In dao_dtl.datas
                Dim dao_dtl_rqt As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                With dao_dtl_rqt.fields
                    .drgtpcd = dao_dtl.fields.drgtpcd
                    .FK_IDA = IDA_rgt
                    .dtl = dao_dtl.fields.dtl
                    .engdrgtpnm = dao_dtl.fields.engdrgtpnm
                    .keepdesc = dao_dtl.fields.keepdesc
                    .pcksize = dao_dtl.fields.pcksize
                    .pvncd = dao_dtl.fields.pvncd
                    .rgtno = dao_dtl.fields.rgtno
                    .rgttpcd = dao_dtl.fields.rgttpcd
                    .tphigh = dao_dtl.fields.tphigh
                    .tplow = dao_dtl.fields.tplow
                    .U1_CODE = dao_dtl.fields.U1_CODE
                    .useage = dao_dtl.fields.useage
                End With
                dao_dtl_rqt.insert()
            Next


            Dim dao_color As New DAO_DRUG.TB_DRRQT_COLOR
            dao_color.GetDataby_FK_IDA(FK_IDA)
            For Each dao_color.fields In dao_color.datas
                Dim dao_color_rqt As New DAO_DRUG.TB_DRRGT_COLOR
                With dao_color_rqt.fields
                    .COLOR_NAME1 = dao_color.fields.COLOR_NAME1
                    .FK_IDA = IDA_rgt
                    .COLOR_NAME2 = dao_color.fields.COLOR_NAME2
                    .COLOR_NAME3 = dao_color.fields.COLOR_NAME3
                    .COLOR_NAME4 = dao_color.fields.COLOR_NAME4
                    .COLOR1 = dao_color.fields.COLOR1
                    .COLOR2 = dao_color.fields.COLOR2
                    .COLOR3 = dao_color.fields.COLOR3
                    .COLOR4 = dao_color.fields.COLOR4
                End With
                dao_color_rqt.insert()
            Next


            Dim bao_addr As New BAO_SHOW
            Dim dt22 As New DataTable
            dt22 = bao_addr.SP_DRRGT_ADDR_INSERT_V2(IDA_rgt)


            Dim dao_ani_rq As New DAO_DRUG.ClsDBdrramldrg
            dao_ani_rq.GetData_by_FK_IDA(FK_IDA)
            For Each dao_ani_rq.fields In dao_ani_rq.datas
                Dim dao_ani_rg As New DAO_DRUG.ClsDBdrramldrg
                With dao_ani_rg.fields
                    .amlsubcd = dao_ani_rq.fields.amlsubcd
                    .amltpcd = dao_ani_rq.fields.amltpcd
                    .drgtpcd = dao_ani_rq.fields.drgtpcd
                    .FK_IDA = IDA_rgt
                    .pvncd = dao_ani_rq.fields.pvncd
                    .rgtno = dao_ani_rq.fields.rgtno
                    .rgttpcd = dao_ani_rq.fields.rgttpcd
                    .usetpcd = dao_ani_rq.fields.usetpcd
                End With
                dao_ani_rg.insert()
            Next

            Dim dao_aniuse_rq As New DAO_DRUG.ClsDBdrramluse
            dao_aniuse_rq.GetDatabyFKIDA(FK_IDA)
            For Each dao_aniuse_rq.fields In dao_aniuse_rq.datas
                Dim dao_aniuse_rg As New DAO_DRUG.ClsDBdrramluse
                With dao_aniuse_rg.fields
                    .amlsubcd = dao_aniuse_rg.fields.amlsubcd
                    .amltpcd = dao_aniuse_rg.fields.amltpcd
                    .drgtpcd = dao_aniuse_rg.fields.drgtpcd
                    .FK_IDA = IDA_rgt
                    .pvncd = dao_aniuse_rg.fields.pvncd
                    .rgtno = dao_aniuse_rg.fields.rgtno
                    .rgttpcd = dao_aniuse_rg.fields.rgttpcd
                    .usetpcd = dao_aniuse_rg.fields.usetpcd
                    .rcvno = dao_aniuse_rg.fields.rcvno
                    .nouse = dao_aniuse_rg.fields.nouse
                    .packuse = dao_aniuse_rg.fields.packuse
                    .pvncd = dao_aniuse_rg.fields.pvncd
                    .STOP_UNIT1 = dao_aniuse_rg.fields.STOP_UNIT1
                    .STOP_UNIT2 = dao_aniuse_rg.fields.STOP_UNIT2
                    .STOP_VALUE1 = dao_aniuse_rg.fields.STOP_VALUE1
                    .STOP_VALUE2 = dao_aniuse_rg.fields.STOP_VALUE2
                    .stpdrg = dao_aniuse_rg.fields.stpdrg
                    .stpdrgcd = dao_aniuse_rg.fields.stpdrgcd
                    .usetpcd = dao_aniuse_rg.fields.usetpcd
                End With
                dao_aniuse_rg.insert()
            Next
            Dim dao_nou As New DAO_DRUG.TB_DRRQT_NO_USE
            dao_nou.GetDataby_FK_IDA(FK_IDA)
            For Each dao_nou.fields In dao_nou.datas
                Dim dao_no As New DAO_DRUG.TB_DRRGT_NO_USE
                With dao_no.fields
                    .FK_IDA = IDA_rgt
                    .NO_USE_DESCRIPTION = dao_nou.fields.NO_USE_DESCRIPTION
                End With
                dao_no.insert()
            Next

            Dim dao_per As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
            dao_per.GetDataby_FKIDA(FK_IDA)
            For Each dao_per.fields In dao_per.datas
                Dim dao_no As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
                With dao_no.fields
                    .FK_IDA = IDA_rgt
                    .drugperunit = dao_per.fields.drugperunit
                    .QTY = dao_per.fields.QTY
                    .SUNITCD = dao_per.fields.SUNITCD
                End With
                dao_no.insert()
            Next
        End Sub
        Public Function SP_TEMP_CASE1441() As DataTable

            Dim sql As String = "exec SP_TEMP_CASE1441"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_MAX_RCVNO_EDIT_REQUEST(ByVal str_max_rcvno As String) As DataTable
            Dim sql As String = "exec SP_GET_MAX_RCVNO_EDIT_REQUEST @str_rcvno= " & str_max_rcvno
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_GET_DATA_15_TAMRAP_TEMPLATE_BY_ID(ByVal tamrap As Integer) As DataTable
            Dim sql As String = "exec SP_GET_DATA_15_TAMRAP_TEMPLATE_BY_ID @TAMRAP_ID= " & tamrap
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_SEARCH_LCN_BY_IDEN(ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_SEARCH_LCN_BY_IDEN @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_TEMP_NCT_DALCN_ALL() As DataTable
            Dim sql As String = "exec SP_TEMP_NCT_DALCN_ALL"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_GET_DATA_15_TAMRAP_PACK_DETAIL_BY_ID(ByVal tamrap As Integer) As DataTable
            Dim sql As String = "exec SP_GET_DATA_15_TAMRAP_PACK_DETAIL_BY_ID @TAMRAP_ID= " & tamrap
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_UPDATE_TEMP_CASE1441(ByVal ida As String) As DataTable

            Dim sql As String = "update [dbo].[case1411$] set [STATUS_UPDATE]='1' where IDA ='" & ida & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_DRRGT_FOR_SEARCH_IDA_NEW(ByVal IDA As Integer) As DataTable

            Dim sql As String = "exec SP_DRRGT_FOR_SEARCH_IDA_NEW @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_DRRGT_TRANSFER_BY_IDA(ByVal IDA As Integer) As DataTable

            Dim sql As String = "exec SP_DRRGT_TRANSFER_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_DRRGT_ADDR_SAI_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable

            Dim sql As String = "exec SP_DRRGT_ADDR_SAI_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_LCN_LOCAION_SAI_BY_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_LCN_LOCAION_SAI_BY_IDA @IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_DRRGT_STATUS_SAI_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_DRRGT_STATUS_SAI_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_DRRGT_PRODUCER_SAI_BY_FK_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_PRODUCER_SAI_BY_FK_IDA @FK_IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_XML_DRUG_STOWAGR_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_XML_DRUG_STOWAGR_BY_IDA @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_XML_DRUG_RECIPE_GROUP_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_XML_DRUG_RECIPE_GROUP_BY_IDA @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_XML_DRUG_ANIMAL_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_XML_DRUG_ANIMAL_BY_IDA @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_XML_DRUG_ANIMAL_CONSUME_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_XML_DRUG_ANIMAL_CONSUME_BY_IDA @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_IOW_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_IOW_BY_IDA @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_IOW_BY_IDA_FK_SET(ByVal IDA As Integer, ByVal fk_set As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_IOW_BY_IDA_FK_SET @ida=" & IDA & ", @fk_set=" & fk_set
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_IOW_EQ_BY_FK_IDA_FK_SET(ByVal IDA As Integer, ByVal fk_set As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_IOW_EQ_BY_FK_IDA_FK_SET @ida=" & IDA & ", @fk_set=" & fk_set
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_FRGN_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_FRGN_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_EXPORT_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_EXPORT_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_COLOR_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_COLOR_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_AGENT_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_AGENT_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_DRUG_STORY_EDIT_HISTORY_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_STORY_EDIT_HISTORY_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_CONDITION_TABEAN_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_CONDITION_TABEAN_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_XML_DRUG_CONTAIN_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_XML_DRUG_CONTAIN_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_COUNT_DRUG_SCHEDULE_BY_SYSTEM_ID_and_CONSIDER_DATE_and_GROUP_ID(ByVal SYSTEM_ID As Integer, ByVal CONSIDER_DATE As Date, ByVal GROUP_ID As String) As DataTable

            strSQL = "SP_COUNT_DRUG_SCHEDULE_BY_SYSTEM_ID_and_CONSIDER_DATE_and_GROUP_ID"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            con_book.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@SYSTEM_ID", SqlDbType.Int).Value = SYSTEM_ID
            SqlCmd.Parameters.Add("@CONSIDER_DATE", SqlDbType.Date).Value = CONSIDER_DATE
            SqlCmd.Parameters.Add("@GROUP_ID", SqlDbType.NVarChar).Value = GROUP_ID
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()

            Return dt
        End Function
        Public Function SP_COUNT_CENTER_SCHEDULE_BY_SYSTEM_ID_and_ALLOW_DATE_and_GROUP_ID(ByVal SYSTEM_ID As Integer, ByVal ALLOW_DATE As Date, ByVal GROUP_ID As String) As DataTable

            strSQL = "SP_COUNT_CENTER_SCHEDULE_BY_SYSTEM_ID_and_ALLOW_DATE_and_GROUP_ID"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@SYSTEM_ID", SqlDbType.Int).Value = SYSTEM_ID
            SqlCmd.Parameters.Add("@ALLOW_DATE", SqlDbType.Date).Value = ALLOW_DATE
            SqlCmd.Parameters.Add("@GROUP_ID", SqlDbType.NVarChar).Value = GROUP_ID
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()

            Return dt
        End Function

        Public Function SP_DRUG_SCHEDULE_STAFF_2() As DataTable

            strSQL = "SP_DRUG_SCHEDULE_STAFF_2"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            con_book.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()

            Return dt
        End Function
        Public Function SP_RCA_by_REF_NO(ByVal REF_NO As String) As DataTable

            strSQL = "SP_RCA_by_REF_NO"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@REF_NO", SqlDbType.NVarChar).Value = REF_NO
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()

            Return dt
        End Function
        ''' <summary>
        ''' ข้อมูลนัดหมายของยา
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_DRUG_SCHEDULE_STAFF_by_SCHEDULE_ID_2(ByVal SCHEDULE_ID As Integer) As DataTable

            strSQL = "SP_DRUG_SCHEDULE_STAFF_by_SCHEDULE_ID_2"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            con_book.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@SCHEDULE_ID", SqlDbType.Int).Value = SCHEDULE_ID
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()

            Return dt
        End Function
        Public Sub SP_BOOKING_PAYMENT_IDA_FK_IDA_and_process_id(ByVal FK_IDA As Integer, ByVal process_id As String)
            strSQL = "SP_BOOKING_PAYMENT_IDA_FK_IDA_and_process_id"
            SqlCmd = New SqlCommand(strSQL, con_fee)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            con_book.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            SqlCmd.Parameters.Add("@process_id", SqlDbType.NVarChar).Value = process_id
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()
        End Sub
        Public Function SP_MAS_PROCESS_by_SYSTEM_ID_and_WORK_GROUP_ID(ByVal SYSTEM_ID As String, ByVal WORK_GROUP_ID As String) As DataTable
            Dim dt As New DataTable
            strSQL = "SP_MAS_PROCESS_by_SYSTEM_ID_and_WORK_GROUP_ID"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            con_book.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@SYSTEM_ID", SqlDbType.NVarChar).Value = SYSTEM_ID
            SqlCmd.Parameters.Add("@WORK_GROUP_ID", SqlDbType.NVarChar).Value = WORK_GROUP_ID

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()
            Return dt
        End Function
        Public Function SP_DRUG_PRODUCT_ID_by_PRODUCT_ID(ByVal PRODUCT_ID As Integer) As DataTable
            Dim dt As New DataTable
            strSQL = "SP_DRUG_PRODUCT_ID_by_PRODUCT_ID"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            con_book.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@PRODUCT_ID", SqlDbType.Int).Value = PRODUCT_ID

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()
            Return dt
        End Function
        Public Function SP_DRUG_PRODUCT_ID_by_register(ByVal register As String) As DataTable
            Dim dt As New DataTable
            strSQL = "SP_DRUG_PRODUCT_ID_by_register"
            SqlCmd = New SqlCommand(strSQL, con_book)
            If (con_book.State = ConnectionState.Open) Then
                con_book.Close()
            End If
            con_book.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@register", SqlDbType.NVarChar).Value = register

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            con_book.Close()
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
        Public Function Queryds_PERMISSION(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_PERMISSIONConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_Book(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_BOOKINGConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryd_CPN(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGTCPNConnectionString1").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryd_124(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_XML_DRUGConnectionString1").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryd_124_2(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_XML_DRUG_ESUBConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryd_m44(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_SPECIAL_PAYMENTConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function SP_SPM_SYSTEM_DETAIL_SHOW_SEARCH(ByVal search As String, ByVal result As Integer, ByVal systems As Integer, ByVal type_pay As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_SPM_SYSTEM_DETAIL_SHOW_SEARCH @search='" & search & "',@result=" & result & ",@systems='" & systems & "',@payment_type=" & type_pay & ""
            Dim dta As New DataTable
            dta = Queryd_m44(sql)
            Return dta
        End Function
        Public Function get_etack() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "select isnull([TR_ID],0) as TR_ID"
            sql &= ",[RCVNO]"
            sql &= " ,[CITIZEN_ID]"
            sql &= ",[CITIZEN_ID_AUTHORIZE]"
            sql &= " ,[APPROVE_DATE]"
            sql &= ",[START_DATE]"
            sql &= ",[FINISH_DATE]"
            sql &= ",[STATUS_NAME]"
            sql &= ",[STATUS_ID]"
            sql &= ",[PRODUCT_NAME_TH]"
            sql &= ",[PRODUCT_NAME_EN]"
            sql &= ",[SYSTEM_ID]"
            sql &= ",[PROCESS_ID]"
            sql &= ",[PROCESS_NAME]"
            sql &= ",[TYPENAME]"
            sql &= ",[STAFF_NAME]"
            sql &= ",[PVCODE]"
            sql &= ",[OBJECT_TYPE]"
            sql &= ",[LCNTYPE]"
            sql &= " ,[DAY_JOB]"
            sql &= ",isnull([DAY_WORK],0) as DAY_WORK"
            sql &= ",[LCNTYPE_NAME]"
            sql &= ",[SUB_SYSTEM_TYPE]"
            sql &= ",[YEAR_DATA]"
            sql &= ",[STAFF_CTZNO]"
            sql &= ",[NAMEPLACE]"
            sql &= ",[CREATE_DATE]"
            sql &= ",[PRODUCT_TYPE]  from FDA_E_TRACKING.dbo.DRUG_TEMP_ESUB where [START_DATE] between '2019-02-01' and '2019-02-28'"
            Dim dta As New DataTable
            dta = Queryd_CPN(sql)
            Return dta
        End Function
        Public Function SP_MAS_PRE4_TEMPLATE() As DataTable
            Dim sql As String = "exec SP_MAS_PRE4_TEMPLATE "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_MAS_PRE4_TEMPLATE"
            Return dta
        End Function
        '
        Public Function SP_drug_general(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_drug_general @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_general"
            Return dta
        End Function
        '
        Public Function SP_drug_general_sai(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_drug_general_sai @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_general_sai"
            Return dta
        End Function
        '
        Public Function SP_drug_general_sai_by_newcode(ByVal newcode As String) As DataTable
            Dim sql As String = "exec SP_drug_general_sai_by_newcode @newcode='" & newcode & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_general_sai_by_newcode"
            Return dta
        End Function

        Public Function SP_REGIS_NO() As DataTable
            Dim sql As String = "exec SP_REGIS_NO"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_REGIS_NO"
            Return dta

        End Function
        '
        Public Function SP_DRRGT_NAME_DRUG_EXPORT_BY_NEWCODE(ByVal newcode As String) As DataTable
            Dim sql As String = "exec SP_DRRGT_NAME_DRUG_EXPORT_BY_NEWCODE @newcode='" & newcode & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_NAME_DRUG_EXPORT_BY_NEWCODE"
            Return dta
        End Function
        Public Function SP_GET_REGIST_PRODUCCER_IN(ByVal IDA As Integer, ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_REGIST_PRODUCCER_IN @IDA=" & IDA & ", @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_REGIST_PRODUCCER_IN"
            Return dta
        End Function

        'SP_drug_general_rq
        Public Function SP_drug_general_rq(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_drug_general_rq @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_general_rq"
            Return dta
        End Function
        '
        Public Function SP_GET_DATA_DALCN_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_DATA_DALCN_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_DATA_DALCN_BY_IDA"
            Return dta
        End Function
        Public Function SP_drug_general_REGIST(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_drug_general_REGIST @ida=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_general_REGIST"
            Return dta
        End Function
        Public Function GET_TEMP_EQTO() As DataTable
            Dim sql As String = "select * from TEMP_EQTO where STAT is null"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Sub UPDATE_TEMP_EQTO(ByVal ida As Integer)

            Dim sql As String = "update [dbo].[TEMP_EQTO] set  STAT='1' where FK_DRRQT_IDA =" & ida
            Dim dta As New DataTable
            Try
                dta = Queryds(sql)
            Catch ex As Exception

            End Try
        End Sub
        Public Function SP_GET_MAX_RGTNO_BY_RGTTPCD(ByVal rgttpcd As String, ByVal year_data As Integer) As DataTable
            Dim sql As String = "exec SP_GET_MAX_RGTNO_BY_RGTTPCD @rgttpcd='" & rgttpcd & "' ,@year=" & year_data
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_MAX_RGTNO_BY_RGTTPCD"
            Return dta
        End Function
        '
        Public Function SP_DRRQT_GET_MAX_RCVNO_BY_RGTTPCD_DRGTPCD(ByVal rgttpcd As String, ByVal year_data As Integer, ByVal drgtpcd As String) As DataTable
            Dim sql As String = "exec SP_DRRQT_GET_MAX_RCVNO_BY_RGTTPCD_DRGTPCD @rgttpcd='" & rgttpcd & "' ,@drgtpcd='" & drgtpcd & "' ,@year=" & year_data
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRQT_GET_MAX_RCVNO_BY_RGTTPCD_DRGTPCD"
            Return dta
        End Function
        Public Function SP_drdrgtype_ALL() As DataTable
            Dim sql As String = "exec SP_drdrgtype_ALL "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drdrgtype_ALL"
            Return dta
        End Function
        Public Function SP_drug_formula_rq(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_drug_formula_rq @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_formula_rq"
            Return dta
        End Function
        '
        Public Function SP_drug_formula_REGIST(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_drug_formula_REGIST @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_formula_REGIST"
            Return dta
        End Function
        Public Function SP_drug_formula_rg(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_drug_formula_rg @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_formula_rg"
            Return dta
        End Function
        '
        Public Function SP_GET_EACH_FROM_SAI(ByVal newcode As String) As DataTable
            Dim sql As String = "exec SP_GET_EACH_FROM_SAI @newcode='" & newcode & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_EACH_FROM_SAI"
            Return dta
        End Function
        '
        Public Function SP_sysisocnt_SAI_by_engcntnm(ByVal engcntnm As String) As DataTable
            Dim sql As String = "exec SP_sysisocnt_SAI_by_engcntnm @engcntnm='" & engcntnm & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_sysisocnt_SAI_by_engcntnm"
            Return dta
        End Function

        Public Function Query_get_data_lcn_no_sai() As DataTable
            Dim sql As String
            sql = "select IDA from [fda].[dalcn] where lcnno >= 6300065 and lcntpcd = N'ขย1' and pvncd = 10 and IDA not in ("
            sql &= "61109,	61112,	61285,	61286,	63996,	62662,	62682,	62567,	62633,	62764,	62770,	62887,	62888,	61132,	61133,	61291,	61304,	62782,	62785,	62893,	62910,	62726,	62730,	61134,	61160,	62735,	62736,	62815,	62852,	62929,	62979,	61185,	62876,	62878,	63987,	63988,	62755,	63990)"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_drug_formula_rg_by_Newcode(ByVal newcode As String) As DataTable
            Dim sql As String = "exec SP_drug_formula_rg_by_Newcode @newcode='" & newcode & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_formula_rg_by_Newcode"
            Return dta
        End Function
        Public Function GET_PACCKING() As DataTable
            Dim sql As String = "select g.IDA from [dbo].[drrgt] g join [dbo].[DRRGT_PACKAGE_DETAIL] d on g.IDA = d.FK_IDA  where d.order_id is null order by d.FK_IDA "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_drug_general"
            Return dta
        End Function
        '
        Public Function SP_DRRGT_FOR_SEARCH_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_FOR_SEARCH_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_FOR_SEARCH_BY_IDA"
            Return dta
        End Function
        '
        Public Function SP_DRRQT_FOR_SEARCH_IDA_NEW(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRRQT_FOR_SEARCH_IDA_NEW @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRQT_FOR_SEARCH_IDA_NEW"
            Return dta
        End Function
        Public Function SP_DRRGT_ADDR_INSERT(ByVal ida_new As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_ADDR_INSERT @ida_new=" & ida_new
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_ADDR_INSERT"
            Return dta
        End Function
        '
        Public Function SP_TYPE_REQUESTS_TABEAN() As DataTable
            Dim sql As String = "exec SP_TYPE_REQUESTS_TABEAN "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_TYPE_REQUESTS_TABEAN"
            Return dta
        End Function
        '
        Public Function SP_TYPE_REQUESTS_EDIT() As DataTable
            Dim sql As String = "exec SP_TYPE_REQUESTS_EDIT "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_TYPE_REQUESTS_EDIT"
            Return dta
        End Function
        Public Function SP_DRRGT_EDIT_REQUEST_BY_IDN(ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_BY_IDN @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_EDIT_REQUEST_BY_IDN"
            Return dta
        End Function
        'LGT_DRUG_DEMO
        Public Function SP_DRRGT_EDIT_REQUEST_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_EDIT_REQUEST_BY_FK_IDA"
            Return dta
        End Function
        '
        Public Function SP_DRRGT_EDIT_REQUEST_BY_NEWCODE(ByVal newcode As String) As DataTable
            Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_BY_NEWCODE @newcode='" & newcode & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_EDIT_REQUEST_BY_NEWCODE"
            Return dta
        End Function
        Public Function SP_DRRGT_SUBSTITUTE_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_SUBSTITUTE_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_SUBSTITUTE_BY_FK_IDA"
            Return dta
        End Function
        '
        Public Function SP_DALCN_NCT_SUBSTITUTE_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DALCN_NCT_SUBSTITUTE_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DALCN_NCT_SUBSTITUTE_BY_FK_IDA"
            Return dta
        End Function
        '
        Public Function SP_DALCN_NCT_SUBSTITUTE_BY_IDENTIFY(ByVal identify As String) As DataTable
            Dim sql As String = "exec SP_DALCN_NCT_SUBSTITUTE_BY_IDENTIFY @identify='" & identify & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DALCN_NCT_SUBSTITUTE_BY_IDENTIFY"
            Return dta
        End Function
        Public Function SP_DALCN_NCT_SUBSTITUTE_BY_IDENTIFY_PROCESS(ByVal identify As String, ByVal _process As String) As DataTable
            Dim sql As String = "exec SP_DALCN_NCT_SUBSTITUTE_BY_IDENTIFY_PROCESS @identify='" & identify & "' ,@process='" & _process & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DALCN_NCT_SUBSTITUTE_BY_IDENTIFY_PROCESS"
            Return dta
        End Function
        Public Function SP_DRRGT_SUBSTITUTE_STAFF() As DataTable
            Dim sql As String = "exec SP_DRRGT_SUBSTITUTE_STAFF "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_SUBSTITUTE_STAFF"
            Return dta
        End Function
        '
        Public Function SP_DALCN_NCT_SUBSTITUTE_STAFF() As DataTable
            Dim sql As String = "exec SP_DALCN_NCT_SUBSTITUTE_STAFF "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DALCN_NCT_SUBSTITUTE_STAFF"
            Return dta
        End Function
        Public Function SP_GET_DDL_PHR_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_DDL_PHR_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_DDL_PHR_BY_FK_IDA"
            Return dta
        End Function
        Public Function SP_DRRGT_EDIT_REQUEST_STAFF() As DataTable
            Dim sql As String = "exec SP_DRRGT_EDIT_REQUEST_STAFF "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_EDIT_REQUEST_STAFF"
            Return dta
        End Function
        Public Function SP_GET_FULL_ADDR_DALCN_LOCATION_ADDRESS_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_FULL_ADDR_DALCN_LOCATION_ADDRESS_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_FULL_ADDR_DALCN_LOCATION_ADDRESS_BY_IDA"
            Return dta
        End Function
        '
        Public Function SP_FEE_UPDATE_STATUS_PAY_COMPLETE(ByVal IDA As Integer, ByVal dvcd As Integer, ByVal process As Integer) As DataTable
            Dim sql As String = "exec SP_FEE_UPDATE_STATUS_PAY_COMPLETE @IDA=" & IDA & " ,@dvcd=" & dvcd & " ,@process=" & process
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_FEE_UPDATE_STATUS_PAY_COMPLETE"
            Return dta
        End Function

        Public Function SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA"
            Return dta
        End Function
        Public Function SP_DALCN_PHR_CANCEL_FK_IDA(ByVal PHR_CTZNO As String) As DataTable
            Dim sql As String = "exec SP_DALCN_PHR_CANCEL_FK_IDA @@PHR_CTZO='" & PHR_CTZNO & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DALCN_PHR_CANCEL_FK_IDA"
            Return dta
        End Function
        '
        Public Function SP_DRRGT_PRODUCER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_PRODUCER_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA"
            Return dta
        End Function
        Public Function SP_DRRQT_PRODUCER_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRRQT_PRODUCER_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA"
            Return dta
        End Function
        Public Function SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"
            Return dta
        End Function
        Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA"
            Return dta
        End Function
        Public Function SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
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
        Public Function SP_MAS_NYMSTAFF_PROCESS() As DataTable
            Dim sql As String = "exec SP_MAS_NYMSTAFF_PROCESS "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_MAS_NYMSTAFF_PROCESS"
            Return dta
        End Function
        Public Function SP_FOREIGN_ADDR_ALL() As DataTable
            Dim sql As String = "exec SP_FOREIGN_ADDR_ALL "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_FOREIGN_ADDR_ALL"
            Return dta
        End Function
        Public Function SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA"
            Return dta
        End Function
        '
        Public Function SP_PRE4_ALLOW_ALL(ByVal startdate As Date, ByVal enddate As Date, ByVal sub_stat As Integer, ByVal group_id As Integer) As DataTable
            Dim dayBegin As Integer = convertDateToInteger(startdate)
            Dim dayEnd As Integer = convertDateToInteger(enddate)
            Dim sql As String = "exec SP_PRE4_ALLOW_ALL @startdate=" & dayBegin & " ,@enddate=" & dayEnd & " , @sub_stat=" & sub_stat & " ,@group_id=" & group_id
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_MAS_PRE4_TEMPLATE"
            Return dta
        End Function
        '
        Public Function SP_PRE4_WAIT_ALLOW_ALL(ByVal startdate As Date, ByVal enddate As Date, ByVal group_id As Integer) As DataTable
            Dim dayBegin As Integer = convertDateToInteger(startdate)
            Dim dayEnd As Integer = convertDateToInteger(enddate)
            Dim sql As String = "exec SP_PRE4_WAIT_ALLOW_ALL @startdate=" & dayBegin & " ,@enddate=" & dayEnd & " ,@group_id=" & group_id
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_PRE4_WAIT_ALLOW_ALL"
            Return dta
        End Function
        Public Function SP_SEARCH_PERSON(ByVal search As String) As DataTable
            Dim sql As String = "exec SP_SEARCH_PERSON @search='" & search & "'"
            Dim dta As New DataTable
            dta = Queryd_m44(sql)
            dta.TableName = "SP_SEARCH_PERSON"
            Return dta
        End Function
        Public Function SP_LOCATION_ADDRESS_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryd_CPN(sql)
            dta.TableName = "SP_LOCATION_ADDRESS_BY_IDA"
            Return dta
        End Function
        '
        Public Function SP_DATA_RCA_E_TRACKING_BY_DATE(ByVal date_time As Date, ByVal date_end As Date) As DataTable
            'Dim date_select As Integer = 0
            Dim date_select As Integer = convertDateToInteger(date_time)
            Dim date_ends As Integer = convertDateToInteger(date_end)
            Dim sql As String = "exec SP_DATA_RCA_E_TRACKING_BY_DATE @dateselect=" & date_select & " , @dateend=" & date_ends
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DATA_RCA_E_TRACKING_BY_DATE"
            Return dta
        End Function
        '
        Public Function SP_GET_ALL_PROFESSIONAL() As DataTable

            Dim sql As String = "exec SP_GET_ALL_PROFESSIONAL "
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_ALL_PROFESSIONAL"
            Return dta
        End Function
        '
        Public Function SP_GET_LCN_EXTEND_BY_CITI_LCNCODE_LCNNO(ByVal citi As String, ByVal lcnno As String, ByVal lcntpcd As String) As DataTable

            Dim sql As String = "exec SP_GET_LCN_EXTEND_BY_CITI_LCNCODE_LCNNO @citi='" & citi & "' ,@lcntpcd='" & lcntpcd & "' ,@lcnno='" & lcnno & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_LCN_EXTEND_BY_CITI_LCNCODE_LCNNO "
            Return dta
        End Function
        Public Function SP_GET_LCN_EXTEND_BY_IDA(ByVal fk_ida As Integer) As DataTable

            Dim sql As String = "exec SP_GET_LCN_EXTEND_BY_IDA @IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_LCN_EXTEND_BY_IDA "
            Return dta
        End Function
        '
        Public Function SP_DDL_LCN_DI(ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_DI @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_DI"
            Return dta
        End Function
        '
        Public Function SP_DDL_LCN_DI_by_PROCESS_ID(ByVal process As String, ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_DI_by_PROCESS_ID @PROCESS_ID='" & process & "' ,@iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_DI_by_PROCESS_ID"
            Return dta
        End Function
        Public Function SP_DDL_LCN_DI_by_type(ByVal iden As String, ByVal _type As Integer) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_DI_by_type @iden='" & iden & "' ,@type=" & _type
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_DI_by_type"
            Return dta
        End Function
        '
        Public Function SP_DDL_LCN_NCT(ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_NCT @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_NCT"
            Return dta
        End Function
        Public Function SP_DRRGT_FOR_SEARCH_NEW(ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_DRRGT_FOR_SEARCH_NEW @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_FOR_SEARCH_NEW"
            Return dta
        End Function
        '
        Public Function SP_DRRGT_RGTNO_DISPLAY_BY_IDA(ByVal ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_RGTNO_DISPLAY_BY_IDA @ida=" & ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_RGTNO_DISPLAY_BY_IDA"
            Return dta
        End Function
        '
        Public Function SP_DRRQT_RGTNO_DISPLAY_BY_IDA(ByVal ida As Integer) As DataTable
            Dim sql As String = "exec SP_DRRQT_RGTNO_DISPLAY_BY_IDA @ida=" & ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRQT_RGTNO_DISPLAY_BY_IDA"
            Return dta
        End Function
        Public Function SP_DRRGT_FOR_SEARCH_NEW_ByY_TYPE(ByVal iden As String, ByVal _type As Integer) As DataTable
            Dim sql As String = "exec SP_DRRGT_FOR_SEARCH_NEW_ByY_TYPE @iden='" & iden & "' ,@type=" & _type
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_FOR_SEARCH_NEW_ByY_TYPE"
            Return dta
        End Function
        Public Function SP_DRRGT_BY_IDA(ByVal fk_ida As Integer) As DataTable

            Dim sql As String = "exec SP_DRRGT_BY_IDA @IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRGT_BY_IDA "
            Return dta
        End Function
        '
        Public Function SP_DRRQT_BY_IDA(ByVal fk_ida As Integer) As DataTable

            Dim sql As String = "exec SP_DRRQT_BY_IDA @IDA=" & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRRQT_BY_IDA "
            Return dta
        End Function
        Public Function SP_DDL_DRSAMP_DS(ByVal iden As String, ByVal process As Integer) As DataTable
            Dim sql As String = "exec SP_DDL_DRSAMP_DS @iden='" & iden & "' ,@process='" & process & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_DRSAMP_DS"
            Return dta
        End Function
        Public Function SP_DDL_LCN_EXTEND_TIME(ByVal iden As String, ByVal process As Integer) As DataTable
            Dim sql As String = "SP_DDL_LCN_EXTEND_TIME @iden='" & iden & "' ,@process='" & process & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_EXTEND_TIME"
            Return dta
        End Function
        Public Function SP_DDL_LCN_EXTEND_TIME1(ByVal iden As String) As DataTable
            Dim sql As String = "SP_DDL_LCN_EXTEND_TIME1 @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_EXTEND_TIME1"
            Return dta
        End Function
        Public Function SP_DDL_LCN_EXTEND_TIME2(ByVal iden As String, ByVal pvcode As Integer) As DataTable
            Dim sql As String = "SP_DDL_LCN_EXTEND_TIME2 @iden='" & iden & "'" & ",@pvcode=" & pvcode
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_EXTEND_TIME2"
            Return dta
        End Function
        Public Function SP_DDL_LCN_EXTEND_TIME_STAFF(ByVal iden As String) As DataTable
            Dim sql As String = "SP_DDL_LCN_EXTEND_TIME_STAFF @iden='" & iden
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_EXTEND_TIME_STAFF"
            Return dta
        End Function
        Public Function SP_DDL_LCN_EXTEND_TIME_STAFF1(ByVal iden As String, ByVal lcncd As String) As DataTable
            Dim sql As String = "SP_DDL_LCN_EXTEND_TIME_STAFF1 @iden='" & iden & "' ,@lcncd='" & lcncd & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_EXTEND_TIME_STAFF1"
            Return dta
        End Function
        Public Function SP_DDL_LCN_EXTEND_TIME_LITE() As DataTable
            Dim sql As String = "SP_DDL_LCN_EXTEND_TIME_LITE"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_EXTEND_TIME_LITE"
            Return dta
        End Function
        '
        Public Function SP_CER_EXTEND_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_CER_EXTEND_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_KORYOR1"
            Return dta
        End Function
        '
        Public Function SP_CER_EXTEND_STAFF() As DataTable
            Dim sql As String = "exec SP_CER_EXTEND_STAFF"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_CER_EXTEND_STAFF"
            Return dta
        End Function
        Public Function SP_DDL_LCN_KORYOR1(ByVal FK_IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_KORYOR1 @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_KORYOR1"
            Return dta
        End Function
        Public Function SP_GET_ADDR(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_ADDR @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_ADDR"
            Return dta
        End Function
        '
        Public Function SP_DDL_LCN_BY_FK_AND_PROCESS(ByVal FK_IDA As Integer, ByVal process As String) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_BY_FK_AND_PROCESS @FK_IDA=" & FK_IDA & " ,@PROCESS_ID='" & process & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_BY_FK_AND_PROCESS"
            Return dta
        End Function
        '
        Public Function SP_DDL_LCN_BY_FK_AND_PROCESS_IF(ByVal FK_IDA As Integer, ByVal process As String) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_BY_FK_AND_PROCESS_IF @FK_IDA=" & FK_IDA & " ,@PROCESS_ID='" & process & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_BY_FK_AND_PROCESS_IF"
            Return dta
        End Function
        '
        Public Function SP_DDL_LCN_BY_FK_AND_PROCESS_IF_IDEN(ByVal process As String, ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_DDL_LCN_BY_FK_AND_PROCESS_IF_IDEN @PROCESS_ID='" & process & "' ,@iden ='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DDL_LCN_BY_FK_AND_PROCESS_IF_IDEN"
            Return dta
        End Function
        Public Function SP_BSN_LOCATION_ADDRESS_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_BSN_LOCATION_ADDRESS_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryd_CPN(sql)
            dta.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDA"
            Return dta
        End Function
        '
        Public Function SP_STAFF_DS() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_DS"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_SEARCH_COMPANY(ByVal name As String) As DataTable
            Dim sql As String = "exec SP_SEARCH_COMPANY @name=" & name
            Dim dta As New DataTable
            dta = Queryd_CPN(sql)
            dta.TableName = "SP_SEARCH_COMPANY"
            Return dta
        End Function
        Public Function SP_BSN_LOCATION_ADDRESS_BY_IDA_V2(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_BSN_LOCATION_ADDRESS_BY_IDA_V2 @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDA_V2"
            Return dta
        End Function
        '
        Public Function SP_BSN_LOCATION_ADDRESS_BY_IDEN(ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_BSN_LOCATION_ADDRESS_BY_IDEN @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryd_CPN(sql)
            dta.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN"
            Return dta
        End Function
        '
        Public Function SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(ByVal iden As String) As DataTable
            Dim sql As String = "exec SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2 @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryd_CPN(sql)
            dta.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN"
            Return dta
        End Function
        Public Function SP_DRSAMP_BY_PRODUCT_ID(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRSAMP_BY_PRODUCT_ID @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRSAMP_BY_PRODUCT_ID"
            Return dta
        End Function
        '
        Public Function SP_GET_DRSAMP_DLL(ByVal citizen_authirize As String) As DataTable
            Dim sql As String = "exec SP_GET_DRSAMP_DLL @auth='" & citizen_authirize & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_DRSAMP_DLL"
            Return dta
        End Function
        Public Function SP_GET_TR_UPLOAD_BY_PROCESS_ID(ByVal process As Integer, ByVal auth As String) As DataTable
            Dim sql As String = "exec SP_GET_TR_UPLOAD_BY_PROCESS_ID @process_id=" & process & ",@auth='" & auth & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_TR_UPLOAD_BY_PROCESS_ID"
            Return dta
        End Function
        Public Function SP_GET_TR_UPLOAD_BY_PROCESS_ID2(ByVal regis As Integer) As DataTable
            Dim sql As String = "exec SP_GET_TR_UPLOAD_BY_PROCESS_ID2 @regis=" & regis
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_TR_UPLOAD_BY_PROCESS_ID2"
            Return dta
        End Function
        Public Function SP_GRIDVIEW_NYM1(ByVal ciup As String) As DataTable
            Dim sql As String = "exec SP_GRIDVIEW_NYM1 @citizen_upload=" & "'" & ciup & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GRIDVIEW_NYM1"
            Return dta
        End Function
        Public Function SP_DRUG_PROJECT_SUMMARY(ByVal iden As String, ByVal tr As String, ByVal pj_code As String, ByVal chk_tr As Integer, ByVal chk_pj As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_PROJECT_SUMMARY @iden=" & "'" & iden & "'" & ",@TR='" & tr & "',@PJ_CODE='" & pj_code & "',@chk_tr='" & chk_tr & "',@chk_pj='" & chk_pj & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_PROJECT_SUMMARY"
            Return dta
        End Function
        Public Function SP_STAFF_DRUG_PROJECT_SUMMARY() As DataTable
            Dim sql As String = "exec SP_STAFF_DRUG_PROJECT_SUMMARY"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_STAFF_DRUG_PROJECT_SUMMARY"
            Return dta
        End Function
        Public Function SP_DRUG_SEARCH_PROJECT_SUMMARY(ByVal search As String) As DataTable
            Dim sql As String = "exec SP_DRUG_SEARCH_PROJECT_SUMMARY @search='" & search & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_SEARCH_PROJECT_SUMMARY"
            Return dta
        End Function
        Public Function SP_GET_DRUGDETAIL_BY_PJSUM(ByVal ciup As Integer) As DataTable
            Dim sql As String = "exec SP_GET_DRUGDETAIL_BY_PJSUM @PJ_IDA=" & ciup
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_DRUGDETAIL_BY_PJSUM"
            Return dta
        End Function
        Public Function SP_GET_DRSAMP() As DataTable
            Dim sql As String = "exec SP_GET_DRSAMP"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_GET_DRSAMP"
            Return dta
        End Function
        Public Function SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM"
            If dta.Rows.Count() = 0 Then
                dta = AddDatatable(dt)
            End If
            Return dta
        End Function
        Public Function SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM2(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM2 @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM2"
            If dta.Rows.Count() = 0 Then
                dta = AddDatatable(dt)
            End If
            Return dta
        End Function
        Public Function SP_STAFF_NYM_PROOF() As DataTable
            Dim sql As String = "exec SP_STAFF_NYM_PROOF"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_STAFF_NYM_PROOF"
            If dta.Rows.Count() = 0 Then
                dta = AddDatatable(dt)
            End If
            Return dta
        End Function
        Public Function SP_DRSAMP_RCV(ByVal tr_id As Integer) As DataTable
            Dim sql As String = "exec SP_DRSAMP_RCV @tr_id=" & tr_id
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRSAMP_RCV"
            'If dta.Rows.Count() = 0 Then
            '    dta = AddDatatable(dt)
            'End If
            Return dta
        End Function
        Public Function SP_DRSAMP_BY_LCNNO(ByVal LCNNO As Integer) As DataTable
            Dim sql As String = "exec SP_DRSAMP_BY_LCNNO @lcnno=" & LCNNO
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRSAMP_BY_LCNNO"
            Return dta
        End Function
        Public Function SP_DRUG_PROJECT_DRUG_LIST_SEARCH(ByVal drcode As String, ByVal citizen_au As String) As DataTable
            Dim sql As String = "exec SP_DRUG_PROJECT_DRUG_LIST_SEARCH @input='" & drcode & "',@ciau='" & citizen_au & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            dta.TableName = "SP_DRUG_PROJECT_DRUG_LIST_SEARCH"
            Return dta
        End Function
        'SP_PHR_JOB
        Public Function SP_PHR_JOB() As DataTable
            Dim sql As String = "exec SP_PHR_JOB "
            Dim dta As New DataTable
            dta = Queryds(sql)

            Return dta
        End Function
        Public Function SP_GET_E_TRACKING_HEAD_CURRENT_STATUS(ByVal rcvno As String, ByVal rgttpcd As String, ByVal product_type As Integer, ByVal sub_type As Integer, ByVal extra As Integer) As DataTable
            Dim sql As String = "exec SP_GET_E_TRACKING_HEAD_CURRENT_STATUS @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "', @PRODUCT_TYPE=" & product_type & " ,@subtype=" & sub_type & ",@extra=" & extra
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_E_TRACKING_HEAD_CURRENT_STATUS_V2(ByVal rcvno As String, ByVal rgttpcd As String, ByVal product_type As Integer, ByVal sub_type As Integer, ByVal extra As Integer, ByVal drgtpcd As String) As DataTable
            Dim sql As String = "exec SP_GET_E_TRACKING_HEAD_CURRENT_STATUS_V2 @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "', @PRODUCT_TYPE=" & product_type & " ,@subtype=" & sub_type & ",@extra=" & extra & ", @drgtpcd='" & drgtpcd & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_GET_E_TRACKING_HEAD_CURRENT_STATUS_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_GET_E_TRACKING_HEAD_CURRENT_STATUS_BY_IDA @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_DRUG_REQUEST_CENTER_REPORT(ByVal IDA As Integer) As DataTable
            Dim sql As String = "exec SP_DRUG_REQUEST_CENTER_REPORT @IDA=" & IDA
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY(ByVal THANM As String, ByVal IDENTIFY As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY @THANM= N'" & THANM & "' ,@IDENTIFY = N'" & IDENTIFY & "' "
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn_CPN.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_SYSISOCNT() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_SYSISOCNT"
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn_CPN.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_SYSCHNGWT() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_SYSCHNGWT"
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn_CPN.ConnectionString).Tables(0)
            Return dta
        End Function
        'Public Function SP_SYSCHNGWT() As DataTable
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_SYSCHNGWT"
        '    Dim dta As New DataTable
        '    dta = clsds.dsQueryselect(sql, conn_CPN.ConnectionString).Tables(0)
        '    Return dta
        'End Function
        Public Function SP_DATA_NYM2_ALL_DATA(ByVal dl As String) As DataTable   'ดึงข้อมูล นยม 2 มาทั้งหมดที่จำเป็น 
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM2_ALL_DATA @DL= '" & dl & "' "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
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
        Public Function SP_DATA_NYM2_USER(ByVal dl As String) As DataTable   'ดึงข้อมูล นยม 2 มาทั้งหมดที่จำเป็น 
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM2_USER @DL= '" & dl & "' "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Return dt
        End Function

        Public Function SP_MEMBER_THANM_THANM_by_IDENTIFY(ByVal IDENTIFY As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MEMBER_THANM_THANM_by_IDENTIFY @IDENTIFY = '" & IDENTIFY & "' "
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn_CPN.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID2(ByVal LOCATION_TYPE_CD As Integer, ByVal LCNSID As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID2 @LCNSID=" & LCNSID & " ,@LOCATION_TYPE_CD=" & LOCATION_TYPE_CD
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN(ByVal LOCATION_TYPE_CD As Integer, ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN @iden='" & iden & "' ,@LOCATION_TYPE_CD=" & LOCATION_TYPE_CD
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_STAFF_DALCN_BY_IDENTIFY(ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_DALCN_BY_IDENTIFY @iden='" & iden & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_DRRGT_PRODUCER_IN_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRRGT_PRODUCER_IN_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_DRRQT_PRODUCER_IN_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRRQT_PRODUCER_IN_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN_V2(ByVal LOCATION_TYPE_CD As Integer, ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN_V2 @iden='" & iden & "' ,@LOCATION_TYPE_CD=" & LOCATION_TYPE_CD
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Sub Run_Dummy_dt()
            '-----------test-----------
            'Dim dt As New DataTable
            dt.Columns.Add("IDA", GetType(Integer))
            dt.Columns.Add("lcnsid")
            dt.Columns.Add("lcnno")
            dt.Columns.Add("fulladdr")
            dt.Columns.Add("cnsdcd")
            dt.Columns.Add("ID")
            dt.Columns.Add("rcvno")
            dt.Columns.Add("rcvdate", GetType(DateTime))
            dt.Columns.Add("trans_code")
            For i As Integer = 1 To 5
                Dim dr As DataRow = dt.NewRow()
                dr("IDA") = i
                dr("lcnsid") = 50000 + i
                dr("lcnno") = 10000 + i
                dr("fulladdr") = ""
                dr("cnsdcd") = 50000 + i
                dr("ID") = 10000 + i
                dr("rcvno") = ""
                dr("rcvdate") = Date.Now
                dr("trans_code") = ""
                dt.Rows.Add(dr)
            Next
            '---------------------------
        End Sub
        Public Sub GetData_dalcn_by_lcnsid(ByVal lcnsid As Integer)

            strSQL = "SP_DALCN"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_check_identify(ByVal identify As String)

            strSQL = "SP_CHECK_IDENTIFY"
            SqlCmd = New SqlCommand(strSQL, conn_CPN)
            If (conn_CPN.State = ConnectionState.Open) Then
                conn_CPN.Close()
            End If
            conn_CPN.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@identify", SqlDbType.VarChar).Value = identify

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn_CPN.Close()

        End Sub

        Public Sub SP_DALCN_By_lcntpcd(ByVal lcnsid As Integer, ByVal lcntpcd As String)

            strSQL = "SP_DALCN_By_lcntpcd"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid
            SqlCmd.Parameters.Add("@lcntpcd", SqlDbType.NVarChar).Value = lcntpcd

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_CUSTOMER_LCN_BY_FK_IDA(ByVal FK_IDA As Integer, ByVal _type As String, ByVal iden As String)

            strSQL = "SP_CUSTOMER_LCN_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.VarChar).Value = FK_IDA
            SqlCmd.Parameters.Add("@lcntpcd", SqlDbType.VarChar).Value = _type
            SqlCmd.Parameters.Add("@iden", SqlDbType.VarChar).Value = iden

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Function SP_CUSTOMER_LCN_BY_CITIZEN_ID_AUTHORIZE(ByVal iden As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_CUSTOMER_LCN_BY_CITIZEN_ID_AUTHORIZE] @iden='" & iden & "'"
            dt = Queryds(command)

            Return dt
        End Function
        'Public Sub SP_CUSTOMER_LCN_BY_CITIZEN_ID_AUTHORIZE(ByVal iden As String)

        '    strSQL = "SP_CUSTOMER_LCN_BY_CITIZEN_ID_AUTHORIZE"
        '    SqlCmd = New SqlCommand(strSQL, conn)
        '    If (conn.State = ConnectionState.Open) Then
        '        conn.Close()
        '    End If
        '    conn.Open()
        '    SqlCmd.CommandType = CommandType.StoredProcedure
        '    SqlCmd.Parameters.Add("@iden", SqlDbType.Text).Value = iden

        '    dtAdapter = New SqlDataAdapter(SqlCmd)
        '    dtAdapter.Fill(dt)
        '    conn.Close()

        'End Sub
        'SP_CUSTOMER_LCN_BY_FK_IDA_AND_PVNCD
        Public Sub SP_CUSTOMER_LCN_BY_FK_IDA_AND_PVNCD(ByVal FK_IDA As Integer, ByVal _type As String, ByVal iden As String, ByVal pvncd As Integer)

            strSQL = "SP_CUSTOMER_LCN_BY_FK_IDA_AND_PVNCD"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.VarChar).Value = FK_IDA
            SqlCmd.Parameters.Add("@lcntpcd", SqlDbType.VarChar).Value = _type
            SqlCmd.Parameters.Add("@iden", SqlDbType.VarChar).Value = iden
            SqlCmd.Parameters.Add("@pvncd", SqlDbType.VarChar).Value = pvncd
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRUG_PRODUCT_ID_BY_FK_IDA(ByVal FK_IDA As Integer)

            strSQL = "SP_DRUG_PRODUCT_ID_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.VarChar).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_PRODUCT_ID_BY_FK_IDA2(ByVal FK_IDA As String)

            strSQL = "SP_DRUG_PRODUCT_ID_BY_FK_IDA2"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.VarChar).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_PRODUCT_ID_BY_IDEN_SELECT(ByVal FK_IDA As String)

            strSQL = "SP_DRUG_PRODUCT_ID_BY_IDEN_SELECT"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@iden", SqlDbType.VarChar).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_PRODUCT_ID_BY_IDEN_SELECT2(ByVal FK_IDA As String, ByVal process As Integer)

            strSQL = "SP_DRUG_PRODUCT_ID_BY_IDEN_SELECT2"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.VarChar).Value = FK_IDA
            SqlCmd.Parameters.Add("@PROCESS_ID", SqlDbType.Int).Value = process
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRUG_PRODUCT_ID_BY_FK_IDA3(ByVal citizen As String)

            strSQL = "SP_DRUG_PRODUCT_ID_BY_FK_IDA3"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@CITIZEN_ID_AUTHORIZE", SqlDbType.Text).Value = citizen
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_PRODUCT_ID_BY_LCN_IDA(ByVal LCN_IDA As Integer)

            strSQL = "SP_DRUG_PRODUCT_ID_BY_LCN_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@LCN_IDA", SqlDbType.Int).Value = LCN_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        ''' <summary>
        ''' ข้อมูลใบอนุญาตเพื่อทำใบย่อย
        ''' </summary>
        ''' <param name="IDA"></param>
        ''' <remarks></remarks>
        Public Sub SP_CUSTOMER_LCN_BY_IDA(ByVal IDA As Integer)

            strSQL = "SP_CUSTOMER_LCN_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@IDA", SqlDbType.VarChar).Value = IDA

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub


        Public Sub SP_LCN_STAFF_EDIT(ByVal FK_IDA As Integer)

            strSQL = "SP_LCN_STAFF_EDIT"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.VarChar).Value = FK_IDA

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_LCN_DRUG_TYPE_MENU(ByVal lcnsid As Integer, ByVal lcn_drug As String)

            strSQL = "SP_LCN_DRUG_TYPE_MENU"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid
            SqlCmd.Parameters.Add("@lcn_type", SqlDbType.NVarChar).Value = lcn_drug

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub GetData_dalcn_by_pvncd(ByVal pvncd As Integer)

            strSQL = "SP_DALCN_PVNCD"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@pvncd", SqlDbType.Int).Value = pvncd

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        'select [dbo].[SC_CHECK_PAY](35109)
        Public Function SC_CHECK_PAY(ByVal IDA As Integer) As Integer
            Dim clsds As New ClassDataset
            Dim count_num As Integer = 0
            Dim sql As String = "select [dbo].[SC_CHECK_PAY](" & IDA & ") as count_num"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            If dt.Rows.Count > 0 Then
                Try
                    count_num = dt(0)("count_num")
                Catch ex As Exception

                End Try
            End If

            Return count_num
        End Function
        Public Sub GetData_master_dacnc()

            strSQL = "SP_MASTER_DACNC"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub


        Public Sub GetData_master_dacnccs()

            strSQL = "SP_MASTER_DACNCCS"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetData_master_daphrcd()

            strSQL = "SP_MASTER_DAPHRCD"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetData_master_daphrfunctcd()

            strSQL = "SP_MASTER_DAPHRFUNCTCD"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetData_master_daweek()

            strSQL = "SP_MASTER_DAWEEK"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_FULLADDR_LCNSNM(ByVal lcnsid As Integer, ByVal lctcd As Integer)

            strSQL = "SP_FULLADDR_LCNSNM"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.Int).Value = lcnsid
            SqlCmd.Parameters.Add("@lctcd", SqlDbType.Int).Value = lctcd



            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DH15RQT_BY_IDA(ByVal IDA As Integer, ByVal _process As Integer)

            strSQL = "SP_DH15RQT_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            SqlCmd.Parameters.Add("@process", SqlDbType.Int).Value = _process
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DRIMPFOR_BY_IDA(ByVal IDA As Integer, ByVal _type As Integer)

            strSQL = "SP_DRIMPFOR_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            SqlCmd.Parameters.Add("@type", SqlDbType.Int).Value = _type
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DRIMPFOR_BY_STATUS(ByVal stat As Integer, ByVal _type As Integer)

            strSQL = "SP_DRIMPFOR_BY_STATUS"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat_id", SqlDbType.Int).Value = stat
            SqlCmd.Parameters.Add("@type", SqlDbType.Int).Value = _type
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRIMPFOR_STAFF()

            strSQL = "SP_DRIMPFOR_STAFF"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRUG_PROJECT_BY_IDA(ByVal IDA As Integer)

            strSQL = "SP_DRUG_PROJECT_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@ida", SqlDbType.Int).Value = IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DRUG_PROJECT_BY_STATUS(ByVal stat As Integer)

            strSQL = "SP_DRUG_PROJECT_BY_STATUS"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat", SqlDbType.Int).Value = stat
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_LGT_IMPCER_BY_IDA(ByVal IDA As Integer)

            strSQL = "SP_LGT_IMPCER_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Function SP_LGT_IMPCER_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LGT_IMPCER_STAFF "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_DRUG_PRODUCT_ID_BY_FK_IDA_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRUG_PRODUCT_ID_BY_FK_IDA_STAFF "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_DRUG_PRODUCT_ID_STAFF_CHECK() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRUG_PRODUCT_ID_STAFF_CHECK "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Sub SP_LGT_IMPCER_BY_STATUS(ByVal _status As Integer)

            strSQL = "SP_LGT_IMPCER_BY_STATUS"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat", SqlDbType.Int).Value = _status
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRPCB_BY_IDA(ByVal IDA As Integer)

            strSQL = "SP_DRPCB_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DRRDT_BY_IDA(ByVal IDA As Integer)

            strSQL = "SP_DRRDT_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DRSAMP_BY_IDA(ByVal IDA As Integer)

            strSQL = "SP_DRSAMP_BY_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRSAMP_STAFF()

            strSQL = "SP_DRSAMP_STAFF"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub


        Public Sub FAGenID(ByVal colum As String, ByVal table As String)

            strSQL = "SELECT  MAX([" + colum + "]) FROM [fda].[" + table + "] "
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If

            conn.Open()
            'SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = strName
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            If String.IsNullOrEmpty(dt.Rows(0)(0).ToString()) Then
                dt.Rows(0)(0) = "0"
            End If
        End Sub
        Public Sub FAGenID_cpn(ByVal colum As String, ByVal table As String)

            strSQL = "SELECT  MAX([" + colum + "]) FROM [fda].[" + table + "] "
            SqlCmd = New SqlCommand(strSQL, conn_CPN)
            If (conn_CPN.State = ConnectionState.Open) Then
                conn_CPN.Close()
            End If

            conn_CPN.Open()
            'SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = strName
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            If String.IsNullOrEmpty(dt.Rows(0)(0).ToString()) Then
                dt.Rows(0)(0) = "0"
            End If
        End Sub

        Public Sub SP_REGIST_BY_GROUP_TYPE(ByVal IDA As Integer, ByVal g_type As Integer)

            strSQL = "SP_REGIST_BY_GROUP_TYPE "
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@fk_ida", SqlDbType.Int).Value = IDA
            SqlCmd.Parameters.Add("@group_type", SqlDbType.Int).Value = g_type
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DRSAMP_TABEAN_BY_FK_IDA(ByVal IDA As Integer)

            strSQL = "SP_DRSAMP_TABEAN_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_RQ_TABEAN_BY_FK_IDA(ByVal IDA As Integer)

            strSQL = "SP_RQ_TABEAN_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@IDA", SqlDbType.Int).Value = IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRRGT_TABEAN_STAFF()

            strSQL = "SP_DRRGT_TABEAN_STAFF"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRRGT_BY_FK_IDA(ByVal FK_IDA As Integer)

            strSQL = "SP_DRRGT_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_DALCN_PHR_BY_FK_IDA(ByVal FK_IDA As Integer)

            strSQL = "SP_DALCN_PHR_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_FILE_ATTACH(ByVal tr_id As Integer)

            strSQL = "SP_FILE_ATTACH"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@tr_id", SqlDbType.Int).Value = tr_id
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Function SP_FILE_REMARK_ATTACH(ByVal tr_id As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_FILE_REMARK_ATTACH @tr_id='" & tr_id & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Sub SP_DALCN_PHR_BY_PHR_CTZNO(ByVal PHR_CTZNO As String)

            strSQL = "SP_DALCN_PHR_BY_PHR_CTZNO"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@PHR_CTZNO", SqlDbType.NVarChar).Value = PHR_CTZNO
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Function SP_DALCN_BY_IDA_FOR_NYM(ByVal IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DALCN_BY_IDA_FOR_NYM " & IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
                If dt.Rows.Count() = 0 Then
                    dt = AddDatatable(dt)
                End If
            Catch ex As Exception

            End Try

            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If

            dt.TableName = "SP_DALCN_BY_IDA_FOR_NYM"

            Return dt
        End Function
        Public Function SP_MASTER_DALCN_by_IDA(ByVal IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MASTER_DALCN_by_IDA " & IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try

            dt.TableName = "SP_MASTER_DALCN_by_IDA"

            Return dt
        End Function
        'Public Sub SP_E_TRACKING(ByVal taxno As String)

        '    strSQL = "SP_E_TRACKING"
        '    SqlCmd = New SqlCommand(strSQL, conn)
        '    If (conn.State = ConnectionState.Open) Then
        '        conn.Close()
        '    End If
        '    conn.Open()
        '    SqlCmd.CommandType = CommandType.StoredProcedure
        '    SqlCmd.Parameters.Add("@taxno", SqlDbType.NVarChar).Value = "444" 'taxno
        '    dtAdapter = New SqlDataAdapter(SqlCmd)
        '    dtAdapter.Fill(dt)
        '    conn.Close()
        'End Sub
        Public Function SP_E_TRACKING(ByVal taxno As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING @taxno='" & taxno & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_LCN_EDIT_REQUEST_BY_FK_IDA(ByVal fk_ida As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EDIT_REQUEST_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EDIT_REQUEST_CANCEL_BY_FK_IDA(ByVal fk_ida As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EDIT_REQUEST_CANCEL_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EDIT_REQUEST_CANCEL_BY_FK_IDA_AND_TYPE(ByVal fk_ida As String, ByVal _type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EDIT_REQUEST_CANCEL_BY_FK_IDA_AND_TYPE @FK_IDA=" & fk_ida & " ,@rqt_type=" & _type
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EDIT_REQUEST_CANCEL_BY_FK_IDA_AND_TYPEV2(ByVal fk_ida As String, ByVal _type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EDIT_REQUEST_CANCEL_BY_FK_IDA_AND_TYPEV2 @FK_IDA=" & fk_ida & " ,@rqt_type=" & _type
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EXTEND_REQUEST_BY_FK_IDA(ByVal fk_ida As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EXTEND_REQUEST_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function

        Public Function SP_LCN_EXTEND_REQUEST_BY_FK_IDA2(ByVal IDA As String, ByVal Process As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EXTEND_REQUEST_BY_FK_IDA2 @IDA=" & IDA & " ,@Process=" & Process
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_LCN_EXTEND_REQUEST_BY_FK_IDA3(ByVal IDA As String, ByVal Process As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EXTEND_REQUEST_BY_FK_IDA3 @IDA=" & IDA & " ,@Process=" & Process
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EXTEND_REQUEST_BY_IDENTIFY(ByVal identify As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EXTEND_REQUEST_BY_IDENTIFY @identify='" & identify & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EXTEND_REQUEST_BY_IDENTIFY_YEAR(ByVal identify As String, ByVal _year As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EXTEND_REQUEST_BY_IDENTIFY_YEAR @identify='" & identify & "' ,@extend_year=" & _year
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        'Public Sub SP_LCN_EXTEND_REQUEST_BY_FK_IDA2(ByVal IDA As Integer, ByVal _type As String, ByVal iden As String)

        '    strSQL = "SP_LCN_EXTEND_REQUEST_BY_FK_IDA2"
        '    SqlCmd = New SqlCommand(strSQL, conn)
        '    If (conn.State = ConnectionState.Open) Then
        '        conn.Close()
        '    End If
        '    conn.Open()
        '    SqlCmd.CommandType = CommandType.StoredProcedure

        '    SqlCmd.Parameters.Add("@IDA", SqlDbType.VarChar).Value = IDA
        '    'SqlCmd.Parameters.Add("@lcntpcd", SqlDbType.VarChar).Value = _type
        '    'SqlCmd.Parameters.Add("@iden", SqlDbType.VarChar).Value = iden

        '    dtAdapter = New SqlDataAdapter(SqlCmd)
        '    dtAdapter.Fill(dt)
        '    conn.Close()

        'End Sub
        Public Function SP_LCN_EDIT_REQUEST_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EDIT_REQUEST_STAFF "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EDIT_REQUEST_STAFF_BY_LCN_TYPE(ByVal _type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EDIT_REQUEST_STAFF_BY_LCN_TYPE @lcn_type=" & _type
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_LCN_EXTEND_REQUEST_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LCN_EXTEND_REQUEST_STAFF "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_E_TRACKING_STAFF_CITIZEN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_STAFF_CITIZEN "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_MASTER_drsunit() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MASTER_drsunit "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_MAS_UNIT_CONTAIN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MAS_UNIT_CONTAIN "
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try
            dt.TableName = "SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA"
            Return dt
        End Function
        Public Function SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA_add(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA_add @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try
            dt.TableName = "SP_DRSAMP_PACKAGE_DETAIL_BY_FK_IDA_add"
            Return dt
        End Function
        '
        Public Function DRUG_REGISTRATION_BY_IDA_NORYORMOR(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec DRUG_REGISTRATION_BY_IDA_NORYORMOR @IDA=" & ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try
            dt.TableName = "DRUG_REGISTRATION_BY_IDA_NORYORMOR"
            Return dt
        End Function
        Public Function SP_DRRQT_PACKAGE_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRRQT_PACKAGE_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try
            dt.TableName = "SP_DRRQT_PACKAGE_DETAIL_BY_FK_IDA"
            Return dt
        End Function
        Public Function SP_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRRGT_PACKAGE_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try
            dt.TableName = "SP_DRRGT_PACKAGE_DETAIL_BY_FK_IDA"
            Return dt
        End Function
        Public Function SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
                If dt.Rows.Count() = 0 Then
                    dt = AddDatatable(dt)
                End If
            Catch ex As Exception

            End Try

            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If

            dt.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA"
            Return dt
        End Function
        Public Function SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_IDA @IDA=" & IDA
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
                If dt.Rows.Count() = 0 Then
                    dt = AddDatatable(dt)
                End If
            Catch ex As Exception

            End Try

            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If

            dt.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_IDA"
            Return dt
        End Function

        Public Function SP_regis(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_regis @IDA=" & ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
                If dt.Rows.Count() = 0 Then
                    dt = AddDatatable(dt)
                End If
            Catch ex As Exception

            End Try

            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If

            dt.TableName = "SP_regis"
            Return dt
        End Function

        Public Function SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(ByVal fk_ida As Integer, ByVal mode As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM @PJ_SUM_IDA=" & fk_ida & ",@mode=" & mode
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
                If dt.Rows.Count() = 0 Then
                    dt = AddDatatable(dt)
                End If
            Catch ex As Exception

            End Try

            If dt.Rows.Count() = 0 Then
                dt = AddDatatable(dt)
            End If

            dt.TableName = "SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM"
            Return dt
        End Function

        '
        Public Function SP_DRUG_PRODUCT_ID(ByVal IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRUG_PRODUCT_ID @IDA=" & IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
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
        Public Function SP_DRUG_REGISTRATION(ByVal IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRUG_REGISTRATION @IDA=" & IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
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
        Public Function SP_PRODUCT_ID_CHEMICAL_FK_IDA(ByVal IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_PRODUCT_ID_CHEMICAL_FK_IDA @FK_IDA=" & IDA
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
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
        Public Function SP_DRUG_REGISTRATION_PACKAGE_DETAIL_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRUG_REGISTRATION_PACKAGE_DETAIL_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try

            Return dt
        End Function
        Public Function SP_DRUG_UNIT_PHYSIC() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRUG_UNIT_PHYSIC "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_TERM_TO_USE() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_TERM_TO_USE "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_BY_CITIZEN_ID(ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_WORK_BY_CITIZEN_ID @CITIZEN_ID= '" & iden & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function

        Public Function SP_E_TRACKING_WORK_OVERALL() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_WORK_OVERALL"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function

        Public Function TBL_E_TRACKING_GAP(ByVal _max As Double) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "select * from dbo.TBL_E_TRACKING_GAP(" & _max & ") "
            dt = Queryds(command)

            Return dt
        End Function

        Public Function SP_EDIT_HISTORY_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_EDIT_HISTORY_BY_FK_IDA @FK_IDA=" & FK_IDA
            dt = Queryds(command)

            Return dt
        End Function

        ' 
        Public Function SP_E_TRACKING_WORK_GROUP() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_E_TRACKING_WORK_GROUP "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_WORK_GROUP_BY_GROUP(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_E_TRACKING_WORK_GROUP_BY_GROUP @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_WORK_GROUP_BY_GROUP2(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_E_TRACKING_WORK_GROUP_BY_GROUP2 @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_XML_SEARCH_DRUG_LCN_by_U1(ByVal u1 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_XML_SEARCH_DRUG_LCN_by_U1 @u1='" & u1 & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_GROUP_BY_GROUP3(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_E_TRACKING_WORK_GROUP_BY_GROUP3 @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_GROUP_ALL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_GROUP_ALL] "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_WORK_LIST_ALL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL] "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_WORK_LIST_ALL2() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL2] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP] @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP3(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP3] @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP_NEW(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP_NEW] @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_WORK_LIST_ALL_BY_CTZID(ByVal _group As Integer, ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL_BY_CTZID] @group=" & _group & " , @ctzid='" & ctzid & "'"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_WORK_LIST_ALL_BY_CTZID_V2(ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL_BY_CTZID_V2]  @ctzid='" & ctzid & "'"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_LIST_ALL_BY_WORK_GROUP(ByVal wrkuntcd As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_WORK_LIST_ALL_BY_WORK_GROUP] @wrkuntcd=" & wrkuntcd
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_BASE_DATE_REAL_NULL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " select * from dbo.TBL_E_TRACKING_DRRQT2() where date_real_cp is null"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Sub SP_UPDATE_E_TRACKING_REAL_DATE(ByVal IDA As Integer, ByVal _date As String)
            Dim dt As New DataTable
            Dim command As String = " "
            Dim _year As String = ""
            Dim _month As String = ""
            Dim _day As String = ""
            Dim full As String = ""
            Try
                _year = IIf(Year(CDate(_date)) < 2500, Year(CDate(_date)) + 543, Year(CDate(_date)))
                _month = Month(CDate(_date))
                _day = Day(CDate(_date))
                full = _year & "-" & _month & "-" & _day
            Catch ex As Exception

            End Try
            command = "exec dbo.SP_UPDATE_E_TRACKING_REAL_DATE @IDA=" & IDA & " , @date= '" & full & "'"
            dt = Queryds(command)

            'Return dt
        End Sub
        '
        Public Sub SP_DRUG_CONSIDER_REQUESTS_STOP_DAY(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_DRUG_CONSIDER_REQUESTS_STOP_DAY @IDA=" & IDA
            dt = Queryds(command)

            'Return dt
        End Sub
        Public Sub SP_DRUG_CONSIDER_REQUESTS_MAX_STOP_DAY(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_DRUG_CONSIDER_REQUESTS_MAX_STOP_DAY @IDA=" & IDA
            dt = Queryds(command)

            'Return dt
        End Sub
        Public Sub SP_DRUG_CONSIDER_REQUESTS_FINISH_DATE(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_DRUG_CONSIDER_REQUESTS_FINISH_DATE @IDA=" & IDA
            dt = Queryds(command)

            'Return dt
        End Sub
        Public Function SELECT_LCN_EXTEND_LITE_UPDATE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "select * from dbo.LCN_EXTEND_LITE_UPDATE where STATUS_ID is null"
            dt = Queryds(command)

            Return dt
        End Function

        Public Function SELECT_TEMP_UPDATE_dalcn_UPDATE() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "select * from dbo.TEMP_UPDATE_dalcn"
            dt = Queryds(command)

            Return dt
        End Function
        Public Sub SP_UPDATE_LCN_EXTEND_LITE_UPDATE(ByVal FK_IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_UPDATE_LCN_EXTEND_LITE_UPDATE @FK_IDA=" & FK_IDA
            dt = Queryds(command)
        End Sub
        Public Function SP_E_TRACKING_SUB_WORK_BY_GROUP(ByVal wrkuntcd As Integer, ByVal _type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_SUB_WORK_BY_GROUP] @wrkuntcd=" & wrkuntcd & " ,@type=" & _type
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_SUB_WORK_BY_GROUP_NEW() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_SUB_WORK_BY_GROUP_NEW] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_SUB_WORK_BY_GROUP_NEW2(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_SUB_WORK_BY_GROUP_NEW2] @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_SUB_WORK_BY_ctzid(ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_SUB_WORK_BY_ctzid] @ctzid=" & ctzid
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_SUB_WORK_BY_ctzid_GROUP(ByVal ctzid As String, ByVal wrk As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_SUB_WORK_BY_ctzid_GROUP] @ctzid=" & ctzid & ", @wrkuntcd=" & wrk
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_PERSON_WORK_BY_GROUP(ByVal wrkuntcd As Integer, ByVal col4 As String, ByVal col5 As String, ByVal _type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_BY_GROUP] @wrkuntcd=" & wrkuntcd & ",@col4='" & col4 & "', @col5='" & col5 & "' ,@type=" & _type
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_PERSON_WORK_BY_GROUP_NEW() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_BY_GROUP_NEW] "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_PERSON_WORK_BY_GROUP2(ByVal _group As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_BY_GROUP2] @group=" & _group
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_PERSON_WORK_BY_CTZID(ByVal ctzid As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_BY_CTZID] @ctzid=" & ctzid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_PERSON_WORK(ByVal wrkuntcd As Integer, ByVal col4 As String, ByVal col5 As String, ByVal iden As String, ByVal _type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK] @wrkuntcd=" & wrkuntcd & ",@col4='" & col4 & "', @col5='" & col5 & "' ,@iden='" & iden & "' ,@type=" & _type
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_PERSON_WORK_BY_IDEN(ByVal iden As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_BY_IDEN] @iden='" & Trim(iden) & "' "
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_PERSON_WORK_BY_IDEN_AND_COL45(ByVal iden As String, ByVal wrk As Int16) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_BY_IDEN_AND_COL45] @iden='" & Trim(iden) & "' ,@wrk=" & wrk
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_PERSON_WORK_BY_IDEN_AND_COL5(ByVal iden As String, ByVal col5 As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_BY_IDEN_AND_COL5] @iden='" & Trim(iden) & "' ,@col='" & col5 & "'" ' ,@col4='" & col4 & "'"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_RESULT_BY_LCNSID(ByVal lcnsid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_RESULT_BY_LCNSID] @lcnsid=" & lcnsid
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_RESULT_ALL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_RESULT_ALL]"
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_GET_REPORT_DATA_EDIT_DR_E_TRACKING_WORK_DAY_RESULT_BY_LCNSID(ByVal lcnsid As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_REPORT_DATA_EDIT_DR_E_TRACKING_WORK_DAY_RESULT_BY_LCNSID] @lcnsid=" & lcnsid
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_GET_DAY_EXTEND_BY_RCVNO_RGTTPCD(ByVal rcvno As String, ByVal rgttpcd As String) As Double
            Dim dt As New DataTable
            Dim val As Double = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_DAY_EXTEND_BY_RCVNO_RGTTPCD] @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "'"
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                val = dr("sum_extend")
            Next
            Return val
        End Function
        Public Function SP_GET_DAY_EXTEND_NEW(ByVal rcvno As String, ByVal rgttpcd As String, ByVal lcnsid As Integer) As Double
            Dim dt As New DataTable
            Dim val As Double = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_DAY_EXTEND_NEW] @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' ,@lcnsid=" & lcnsid
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                val = dr("sum_extend")
            Next
            Return val
        End Function
        'SP_GET_DAY_EXTEND_NEW_DATA_V2
        Public Function SP_GET_DAY_EXTEND_NEW_DATA_V2(ByVal rcvno As String, ByVal rgttpcd As String, ByVal lcnsid As Integer, ByVal b_type As Integer, ByVal s_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_DAY_EXTEND_NEW_DATA_V2] @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' ,@lcnsid=" & lcnsid & " , @b_type=" & b_type & " ,@s_type=" & s_type
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_DAY_EXTEND_NEW_DATA_V3(ByVal rcvno As String, ByVal rgttpcd As String, ByVal lcnsid As Integer, ByVal b_type As Integer, ByVal s_type As Integer, ByVal drg As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_DAY_EXTEND_NEW_DATA_V3] @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' ,@lcnsid=" & lcnsid & " , @b_type=" & b_type & " ,@s_type=" & s_type & ",@drgtpcd='" & drg & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_DAY_EXTEND_NEW_DATA_V5(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_DAY_EXTEND_NEW_DATA_V5] @FK_IDA=" & FK_IDA
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_E_TRACKING_HEAD_CURRENT_STATUS_ALL_PERIOD_TIME(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal s_type As Integer, ByVal drg As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_HEAD_CURRENT_STATUS_ALL_PERIOD_TIME] @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' , @b_type=" & b_type & " ,@s_type=" & s_type & ",@drgtpcd='" & drg & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_HEAD_CURRENT_STATUS_MAX_DATE(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal s_type As Integer, ByVal drg As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_HEAD_CURRENT_STATUS_MAX_DATE] @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' , @b_type=" & b_type & " ,@s_type=" & s_type & ",@drgtpcd='" & drg & "'"
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_E_TRACKING_HEAD_CURRENT_STATUS_MAX_DATE_R(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_HEAD_CURRENT_STATUS_MAX_DATE_R] @FK_IDA=" & FK_IDA
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_GET_DAY_EXTEND_NEW_DATA_V2_2(ByVal rcvno As String, ByVal rgttpcd As String, ByVal lcnsid As Integer, ByVal b_type As Integer, ByVal s_type As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_DAY_EXTEND_NEW_DATA_V2_2] @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' ,@lcnsid=" & lcnsid & " , @b_type=" & b_type & " ,@s_type=" & s_type
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_GET_DAY_EXTEND_NEW_DATA_V2_3(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_DAY_EXTEND_NEW_DATA_V2_3] @FK_IDA=" & FK_IDA
            dt = Queryds(command)
            Return dt
        End Function
        Public Function SP_CUSTOMER_EXTEND_CER_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_CUSTOMER_EXTEND_CER_BY_FK_IDA] @FK_IDA=" & FK_IDA
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_CUSTOMER_EXTEND_DETAIL_CER_BY_FK_HEAD(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_CUSTOMER_EXTEND_DETAIL_CER_BY_FK_HEAD] @FK_HEAD=" & FK_IDA
            dt = Queryds(command)
            Return dt
        End Function
        '
        Public Function SP_CUSTOMER_EXTEND_CAS_BY_FK_HEAD(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_CUSTOMER_EXTEND_CAS_BY_FK_HEAD] @FK_HEAD=" & FK_IDA
            dt = Queryds(command)
            Return dt
        End Function
        'Public Function SP_SEARCH_DRUG_EXTEND_TIME_LOCATIONv2(ByVal citi As String, ByVal lcnt As String) As DataTable
        '    Dim dt As New DataTable
        '    Dim command As String = " "
        '    command = " select Newcode_not,lcntpcd,lcnno_no,thanm,thanm_addr,grannm_lo,thachngwtnm,"
        '    command &= " [dbo].[SC_DALCN_EXP](lcnno,pvncd,lcntpcd) As expyear "
        '    command &= " from [LINK124].[FDA_XML_DRUG].[dbo].[XML_SEARCH_DRUG_LCN] As xm "
        '    command &= " where cncnm = 'คงอยู่'"

        '    'command = command & " and lcnno_no =" & "and citi ="


        '    If IsNothing(citi) = True Or citi = "" Then

        '    Else
        '        command &= " and CITIZEN_AUTHORIZE =" & "'" & citi & "'"
        '    End If

        '    If IsNothing(lcnt) = True Or lcnt = "" Then

        '    Else
        '        command &= " and lcnno_no =" & "'" & lcnt & "'"
        '        'command &= "and lcnno_no like '%" & lcnt & "%'"

        '    End If


        '    'If IsNothing(lcnt) = True Or lcnt = "" Then

        '    'Else
        '    '    command &= "and lcnno_no like '%" & lcnt & "%'"

        '    'End If
        '    dt = Queryds(command)
        '    Return dt
        'End Function
        Public Function SP_E_TRACKING_PERSON_WORK_ALL() As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_E_TRACKING_PERSON_WORK_ALL] "
            dt = Queryds(command)

            Return dt
        End Function
        Public Function SP_E_TRACKING_WORK_TOP5() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_WORK_TOP5"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_E_TRACKING_COUNT_WORK_LESS_THAN_OTHER(ByVal process As Integer) As String
            Dim iden As String = ""
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_COUNT_WORK_LESS_THAN_OTHER @process=" & process
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Try
                iden = dt(0)("CITIZEN_ID")
            Catch ex As Exception

            End Try
            Return iden
        End Function
        Public Sub SP_STATUS_BY_GROUP(ByVal _group As Integer)

            strSQL = "SP_STATUS_BY_GROUP"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_MAS_STATUS_STAFF_BY_GROUP(ByVal _group As Integer)

            strSQL = "SP_MAS_STATUS_STAFF_BY_GROUP"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat_g", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_MAS_STATUS_STAFF()

            strSQL = "SP_MAS_STATUS_STAFF"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_MAS_STATUS_STAFF_BY_GROUP_DDL(ByVal _stat_group As Integer, ByVal _group As Integer)

            strSQL = "SP_MAS_STATUS_STAFF_BY_GROUP_DDL"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat_group", SqlDbType.Int).Value = _stat_group
            SqlCmd.Parameters.Add("@group", SqlDbType.Int).Value = _group

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_MAS_STATUS_STAFF_BY_GROUP_DDL1(ByVal _stat_group As Integer, ByVal _group As Integer, ByVal _status_id As Integer)

            strSQL = "SP_MAS_STATUS_STAFF_BY_GROUP_DDL1"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat_group", SqlDbType.Int).Value = _stat_group
            SqlCmd.Parameters.Add("@group", SqlDbType.Int).Value = _group
            SqlCmd.Parameters.Add("@sid", SqlDbType.Int).Value = _status_id
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_MAS_STATUS_STAFF_BY_GROUP_DDL8(ByVal _stat_group As Integer, ByVal _group As Integer)

            strSQL = "SP_MAS_STATUS_STAFF_BY_GROUP_DDL8"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat_group", SqlDbType.Int).Value = _stat_group
            SqlCmd.Parameters.Add("@group", SqlDbType.Int).Value = _group

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_MAS_IOWA()
            strSQL = "SP_MAS_IOWA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_MAS_SALT()
            strSQL = "SP_MAS_SALT"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_MAS_SYN()
            strSQL = "SP_MAS_SYN"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_MAS_STATUS_STAFF_CER()

            strSQL = "SP_MAS_STATUS_STAFF_CER"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_MAS_STATUS_STAFF_RGT_EDIT()

            strSQL = "SP_MAS_STATUS_STAFF_RGT_EDIT"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        '
        Public Sub SP_STAFF_OFFER_DDL()

            strSQL = "SP_STAFF_OFFER_DDL"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_STAFF_OFFER_DDL_BY_PVNCD(ByVal pvncd As Integer)

            strSQL = "SP_STAFF_OFFER_DDL_BY_PVNCD"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@pvncd", SqlDbType.Int).Value = pvncd

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_STAFF_OFFER_DDL_ex()

            strSQL = "SP_STAFF_OFFER_DDL_ex"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_STAFF_POSITION_NAME()

            strSQL = "SP_STAFF_POSITION_NAME"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_STAFF_OFFER()

            strSQL = "SP_STAFF_OFFER"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        ''' <summary>
        ''' ใบนัด
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SP_REQUESTS_MAIN_STAFF()

            strSQL = "SP_REQUESTS_MAIN_STAFF"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_REQUEST_CENTER_MAIN_STAFF()

            strSQL = "SP_DRUG_REQUEST_CENTER_MAIN_STAFF"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO()

            strSQL = "SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO_ALL()

            strSQL = "SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO_ALL"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Function SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO_CUSTOMER(ByVal iden As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO_CUSTOMER @iden='" & iden & "'"
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO_STAFF(ByVal iden As String) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_DRUG_REQUEST_CENTER_MAIN_STAFF_A_NO_STAFF @iden='" & iden & "'"
            dt = Queryds(command)

            Return dt
        End Function

        Public Function SP_DL_DATA_NOW_TO_START(ByVal cid As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DL_DATA_NOW_TO_START @"
            Dim dt As New DataTable
            Try
                dt = Queryds(sql)
            Catch ex As Exception

            End Try


            Return dt
        End Function

        '
        Public Function SP_drrqt_Etracking(ByVal tr_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_drrqt_Etracking @TR_ID=" & tr_id
            dt = Queryds(command)

            Return dt
        End Function
        '
        Public Function SP_DRRGT_EDIT_REQUEST_Etracking(ByVal tr_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim command As String = " "
            command = "exec dbo.SP_DRRGT_EDIT_REQUEST_Etracking @TR_ID=" & tr_id
            dt = Queryds(command)

            Return dt
        End Function
        Public Sub SP_SEARCH_DRUG_EXTEND_TIME_LOCATION()

            strSQL = "SP_SEARCH_DRUG_EXTEND_TIME_LOCATION"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_SEARCH_DRUG_EXTEND_TIME_LOCATION_STAFF()

            strSQL = "SP_SEARCH_DRUG_EXTEND_TIME_LOCATION_STAFF"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DALCN_SEARCH_EDIT()

            strSQL = "SP_DALCN_SEARCH_EDIT"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DALCN_STAFF_SEARCH()

            strSQL = "SP_DALCN_STAFF_SEARCH"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@STATUS_GROUP", SqlDbType.Int).Value = _group
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRRGT_FOR_SEARCH(ByVal txt As String)

            strSQL = "SP_DRRGT_FOR_SEARCH"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@txt", SqlDbType.NVarChar).Value = txt
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRRGT_FOR_SEARCH_FROM_SAI(ByVal txt As String)

            strSQL = "SP_DRRGT_FOR_SEARCH_FROM_SAI"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@txt", SqlDbType.NVarChar).Value = txt
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRRGT_FOR_SEARCH_RGTNO(ByVal txt As String)

            strSQL = "SP_DRRGT_FOR_SEARCH_RGTNO"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@txt", SqlDbType.NVarChar).Value = txt
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub SP_DRUG_REQUEST_CENTER_MAIN_STAFF_BY_CTZNO_AUT(ByVal ctz As String)

            strSQL = "SP_DRUG_REQUEST_CENTER_MAIN_STAFF_BY_CTZNO_AUT"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@CITIZEN_AUTHIRIZE", SqlDbType.NVarChar).Value = ctz
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        ''' <summary>
        ''' ใบนัดตามกลุ่ม
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SP_REQUESTS_MAIN_STAFF_by_WORK_GROUP_ID(ByVal WORK_GROUP_ID As String)

            strSQL = "SP_REQUESTS_MAIN_STAFF_by_WORK_GROUP"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@WORK_GROUP_ID", SqlDbType.Int).Value = WORK_GROUP_ID
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        ''' <summary>
        ''' คำขอแก้ไข
        ''' </summary>
        ''' <param name="_group"></param>
        ''' <remarks></remarks>
        Public Sub SP_EDIT_REQUEST_BY_FK_IDA(ByVal FK_IDA As Integer)

            strSQL = "SP_EDIT_REQUEST_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        ''' <summary>
        ''' คำขอแก้ไข staff
        ''' </summary>
        ''' <param name="_stat"></param>
        ''' <remarks></remarks>
        Public Sub SP_EDIT_REQUEST_BY_STATUS(ByVal _stat As Integer)

            strSQL = "SP_EDIT_REQUEST_BY_STATUS"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@stat", SqlDbType.Int).Value = _stat
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="FK_IDA"></param>
        ''' <remarks></remarks>
        Public Sub SP_DRUG_REGISTRATION_BY_FK_IDA(ByVal FK_IDA As Integer)

            strSQL = "SP_DRUG_REGISTRATION_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_DRUG_REGISTRATION_BY_FK_IDA_V2(ByVal FK_IDA As Integer)

            strSQL = "SP_DRUG_REGISTRATION_BY_FK_IDA_V2"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        'SP_DRUG_REGISTRATION_STAFF
        Public Sub SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID(ByVal FK_IDA As Integer, ByVal process As Integer)

            strSQL = "SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID "
            SqlCmd = New SqlCommand(strSQL, conn)
            Try
                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                End If
                conn.Open()
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
                SqlCmd.Parameters.Add("@PROCESS_ID", SqlDbType.Int).Value = process
                dtAdapter = New SqlDataAdapter(SqlCmd)
                dtAdapter.Fill(dt)
                conn.Close()
            Catch ex As Exception

            End Try


        End Sub
        '
        Public Sub SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_AUTO(ByVal FK_IDA As Integer, ByVal process As Integer)

            strSQL = "SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_AUTO "
            SqlCmd = New SqlCommand(strSQL, conn)
            Try
                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                End If
                conn.Open()
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
                SqlCmd.Parameters.Add("@PROCESS_ID", SqlDbType.Int).Value = process
                dtAdapter = New SqlDataAdapter(SqlCmd)
                dtAdapter.Fill(dt)
                conn.Close()
            Catch ex As Exception

            End Try


        End Sub
        '
        Public Sub SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_AUTO_SUBTYPE(ByVal FK_IDA As Integer, ByVal process As Integer, ByVal st As Integer)

            strSQL = "SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_AUTO_SUBTYPE "
            SqlCmd = New SqlCommand(strSQL, conn)
            Try
                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                End If
                conn.Open()
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
                SqlCmd.Parameters.Add("@PROCESS_ID", SqlDbType.Int).Value = process
                SqlCmd.Parameters.Add("@st", SqlDbType.Int).Value = st
                dtAdapter = New SqlDataAdapter(SqlCmd)
                dtAdapter.Fill(dt)
                conn.Close()
            Catch ex As Exception

            End Try


        End Sub
        Public Sub SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_ONE_DAY(ByVal FK_IDA As Integer, ByVal process As Integer)

            strSQL = "SP_DRUG_REGISTRATION_BY_FK_IDA_PROCESS_ID_ONE_DAY "
            SqlCmd = New SqlCommand(strSQL, conn)
            Try
                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                End If
                conn.Open()
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
                SqlCmd.Parameters.Add("@PROCESS_ID", SqlDbType.Int).Value = process
                dtAdapter = New SqlDataAdapter(SqlCmd)
                dtAdapter.Fill(dt)
                conn.Close()
            Catch ex As Exception

            End Try


        End Sub
        Public Sub SP_DRUG_REGISTRATION_STAFF()

            strSQL = "SP_DRUG_REGISTRATION_STAFF "
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            'SqlCmd.Parameters.Add("@PROCESS_ID", SqlDbType.Int).Value = process
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        ''' <summary>
        ''' SP เรียกชื่อบริษัทผลิต ที่ใกล้เคียง
        ''' </summary>
        ''' <param name="COMPANY_NAME"></param>
        ''' <param name="CITY"></param>
        ''' <param name="COUNTRY"></param>
        ''' <remarks></remarks>
        Public Function SP_GRID_DETAIL_MANUFACTURE_by_COMPANY_NAME_and_CITY_and_COUNTRY(ByVal COMPANY_NAME As String, ByVal CITY As String, ByVal COUNTRY As String) As DataTable
            Dim dataT As New DataTable
            strSQL = "SP_GRID_DETAIL_MANUFACTURE_by_COMPANY_NAME_and_CITY_and_COUNTRY"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@COMPANY_NAME", SqlDbType.NVarChar).Value = COMPANY_NAME
            SqlCmd.Parameters.Add("@CITY", SqlDbType.NVarChar).Value = CITY
            SqlCmd.Parameters.Add("@COUNTRY", SqlDbType.NVarChar).Value = COUNTRY
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dataT)
            conn.Close()

            Return dataT
        End Function


        ''' <summary>
        ''' SP สำหรับผู้ประกอบหาร
        ''' </summary>
        ''' <param name="FK_IDA"></param>
        ''' <remarks></remarks>
        Public Sub SP_CUSTOMER_CER_BY_FK_IDA(ByVal FK_IDA As Integer)

            strSQL = "SP_CUSTOMER_CER_BY_FK_IDA"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub


        ''' <summary>
        ''' SP สำหรับผู้ประกอบหาร
        ''' </summary>
        ''' <param name="FK_IDA"></param>
        ''' <remarks></remarks>
        Public Sub SP_CUSTOMER_CER_BY_FK_IDA_and_CER_TYPE(ByVal FK_IDA As Integer, ByVal CER_TYPE As Integer)

            strSQL = "SP_CUSTOMER_CER_BY_FK_IDA_and_CER_TYPE"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            SqlCmd.Parameters.Add("@CER_TYPE", SqlDbType.Int).Value = CER_TYPE
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        '
        Public Sub SP_CUSTOMER_CER_BY_FK_IDA_and_CER_TYPE_and_iden(ByVal FK_IDA As Integer, ByVal CER_TYPE As Integer, ByVal iden As String)

            strSQL = "SP_CUSTOMER_CER_BY_FK_IDA_and_CER_TYPE_and_iden"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            SqlCmd.Parameters.Add("@CER_TYPE", SqlDbType.Int).Value = CER_TYPE
            SqlCmd.Parameters.Add("@iden", SqlDbType.NVarChar).Value = iden
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_CUSTOMER_CER_FOREIGN_BY_FK_IDA_and_CER_TYPE(ByVal FK_IDA As Integer, ByVal CER_TYPE As Integer)

            strSQL = "SP_CUSTOMER_CER_FOREIGN_BY_FK_IDA_and_CER_TYPE"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            SqlCmd.Parameters.Add("@CER_TYPE", SqlDbType.Int).Value = CER_TYPE
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_CUSTOMER_CER_FOREIGN_BY_FK_IDA_and_CER_TYPE_and_iden(ByVal FK_IDA As Integer, ByVal CER_TYPE As Integer, ByVal iden As String)

            strSQL = "SP_CUSTOMER_CER_FOREIGN_BY_FK_IDA_and_CER_TYPE_and_iden"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@FK_IDA", SqlDbType.Int).Value = FK_IDA
            SqlCmd.Parameters.Add("@CER_TYPE", SqlDbType.Int).Value = CER_TYPE
            SqlCmd.Parameters.Add("@iden", SqlDbType.NVarChar).Value = iden
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        ''' <summary>
        ''' SP สำหรับเจ้าหน้าที่
        ''' </summary>
        ''' <param name="FK_IDA"></param>
        ''' <remarks></remarks>
        Public Sub SP_STAFF_CER()

            strSQL = "SP_STAFF_CER"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub SP_STAFF_CER_FOREIGN()

            strSQL = "SP_STAFF_CER_FOREIGN"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub


        ''' <summary>
        ''' ค้นหาสารจากชื่อสาร
        ''' </summary>
        ''' <param name="IOWANM"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_MAS_CHEMICAL_by_IOWANM(ByVal IOWANM As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MAS_CHEMICAL_by_IOWANM @IOWANM='" & IOWANM & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_driowa_by_IOWANM(ByVal IOWANM As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_driowa_by_IOWANM @IOWANM='" & IOWANM & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_MAS_CHEMICAL_by_IOWANM_AND_AORI(ByVal IOWANM As String, ByVal aori As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MAS_CHEMICAL_by_IOWANM_AND_AORI @IOWANM='" & IOWANM & "' ,@aori='" & aori & "'"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_CER_SEARCH() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CER_SEARCH"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        ''' <summary>
        ''' จนท ใบอนุญาต
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_STAFF_DALCN() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_DALCN "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_DALCN_EDIT_REQUEST_BY_FK_IDA(ByVal fk_ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DALCN_EDIT_REQUEST_BY_FK_IDA @FK_IDA=" & fk_ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        'ผู้ดำเนิน
        Public Function SP_GET_IDENTYFY_AND_NAME_BY_CTZNO(ByVal identify As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_IDENTYFY_AND_NAME_BY_CTZNO @identify='" & identify & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_GET_IDENTYFY_AND_NAME_BY_CTZNO_Phesaj(ByVal identify As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_IDENTYFY_AND_NAME_BY_CTZNO_Phesaj @identify='" & identify & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_DALCN_EDIT_REQUEST_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DALCN_EDIT_REQUEST_STAFF "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_STAFF_DALCN_BY_PVNCD(ByVal pvncd As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_DALCN_BY_PVNCD @pvncd=" & pvncd
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_STAFF_NYM() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_NYM"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function

        Public Function SP_DATA_NYM2_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM2_STAFF"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_DATA_NYM3_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM3_STAFF"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_DATA_NYM4_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM4_STAFF"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_DATA_NYM5_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM5_STAFF"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_DATA_NYM2_with_status_from_massstatus(ByVal DL As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM2_with_status_from_massstatus @DL" & DL
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        'Function SP_DATA_NYM2_USER(ByVal DL As String) As DataTable
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_DATA_NYM2_USER @DL" & DL
        '    Dim dt As New DataTable
        '    Try
        '        dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
        '    Catch ex As Exception

        '    End Try


        '    Return dt
        'End Function
        'Public Function SP_DATA_NYM3_USER() As DataTable                            ' อย่า ลืมเปลี่ยน 
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = "exec SP_DATA_NYM3_USER"
        '    Dim dt As New DataTable
        '    Try
        '        dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
        '    Catch ex As Exception

        '    End Try


        '    Return dt
        'End Function
        Public Function SP_DATA_NYM3_USER(ByVal dl As String) As DataTable   'ดึงข้อมูล นยม 2 มาทั้งหมดที่จำเป็น 
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM3_USER @DL= '" & dl & "' "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Return dt
        End Function

        Public Function SP_DATA_NYM4_USER(ByVal dl As String) As DataTable   'ดึงข้อมูล นยม 2 มาทั้งหมดที่จำเป็น 
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM4_USER @DL= '" & dl & "' "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Return dt
        End Function
        Public Function SP_DATA_NYM5_USER(ByVal dl As String) As DataTable   'ดึงข้อมูล นยม 2 มาทั้งหมดที่จำเป็น 
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM5_USER @DL= '" & dl & "' "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Return dt
        End Function
        Public Function SP_DATA_NYM6_USER() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_NYM6_USER"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        'Public Sub SP_STATUS_IMPORT_STAFF_BY_GROUP_DDL(ByVal _stat_group As Integer, ByVal _group As Integer)

        '    strSQL = "SP_STATUS_IMPORT_STAFF_BY_GROUP_DDL"
        '    SqlCmd = New SqlCommand(strSQL, conndrugimport)
        '    If (conn.State = ConnectionState.Open) Then
        '        conn.Close()
        '    End If
        '    conn.Open()
        '    SqlCmd.CommandType = CommandType.StoredProcedure
        '    SqlCmd.Parameters.Add("@stat_group", SqlDbType.Int).Value = _stat_group
        '    SqlCmd.Parameters.Add("@group", SqlDbType.Int).Value = _group

        '    dtAdapter = New SqlDataAdapter(SqlCmd)
        '    dtAdapter.Fill(dt)
        '    conn.Close()

        'End Sub
        Public Function SP_STATUS_IMPORT_STAFF_BY_GROUP_DDL(ByVal _stat_group As Integer, ByVal _group As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STATUS_IMPORT_STAFF_BY_GROUP_DDL @stat_group = " & _stat_group & ",@group=" & _group
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)

            Return dt
        End Function
        Public Function SP_NYMSTAFF_ALLPROCESS() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_NYMSTAFF_ALLPROCESS "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, condrugimport).Tables(0)
            Catch ex As Exception
            End Try
            Return dt
        End Function

        Public Function SP_STAFF_LCNREQUEST() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_LCNREQUEST "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_STAFF_LCN_EXTEND_LITE2() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_LCN_EXTEND_LITE2 "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_STAFF_DALCN_REPORT() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_DALCN_REPORT "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        ''' <summary>
        ''' จนท เภสัชเคมีภัณฑ์
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_STAFF_DH15RQT() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_DH15RQT "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_STAFF_DH15RQT_V2() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_DH15RQT_V2 "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function
        ''' <summary>
        ''' จนท เพิ่มสาร
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_STAFF_CHEMICAL_REQUEST() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_STAFF_CHEMICAL_REQUEST "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function

        ''' <summary>
        ''' ผปก เพิ่มสาร
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_CUSTOMER_CHEMICAL_REQUEST_by_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_CHEMICAL_REQUEST_by_FK_IDA @FK_IDA = " & FK_IDA
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        'SP ตัวใหม่
        Public Function SP_CHEMICAL_REQUEST_CUSTOMER(ByVal FK_IDA As Integer, ByVal mt As Integer, ByVal st As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CHEMICAL_REQUEST_CUSTOMER @FK_IDA = " & FK_IDA & ", @mt=" & mt & " , @st=" & st
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_CHEMICAL_REQUEST_CUSTOMER_CHEM_TYPE(ByVal iden As String, ByVal mt As Integer, ByVal st As Integer, ByVal aori As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CHEMICAL_REQUEST_CUSTOMER_CHEM_TYPE @iden = '" & iden & "', @mt=" & mt & " , @st=" & st & ",@aori='" & aori & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function
        '
        Public Function SP_CHEMICAL_REQUEST_CUSTOMERV_BIO(ByVal iden As String, ByVal mt As Integer, ByVal b As String, ByVal st As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CHEMICAL_REQUEST_CUSTOMERV_BIO @iden = '" & iden & "', @mt=" & mt & " , @b='" & b & "' ,@st=" & st
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function
        Public Function SP_CHEMICAL_REQUEST_CUSTOMER_HERB(ByVal iden As String, ByVal mt As Integer, ByVal g As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CHEMICAL_REQUEST_CUSTOMER_HERB @iden = '" & iden & "', @mt=" & mt & " , @g=" & g
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try

            Return dt
        End Function
        '
        Public Function SP_CHEMICAL_REQUEST_CUSTOMER_V2(ByVal FK_IDA As Integer, ByVal mt As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CHEMICAL_REQUEST_CUSTOMER_V2 @FK_IDA = " & FK_IDA & ", @mt=" & mt
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_MAS_CHEMICAL_ALL() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_MAS_CHEMICAL_ALL"
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_CHEMICAL_REQUEST_DETAIL_TABLE(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_CHEMICAL_REQUEST_DETAIL_TABLE @FK_IDA=" & ida
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_CHEMICAL_REQUEST_CHEM16_BY_FK_IDA(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_CHEMICAL_REQUEST_CHEM16_BY_FK_IDA @FK_IDA=" & ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_CDRUG_PRODUCT_IOWA(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_CDRUG_PRODUCT_IOWA @FK_IDA=" & ida
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_DRSAMP_DETAIL_CAS_DETAIL(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_DRSAMP_DETAIL_CAS_DETAIL @FK_IDA=" & ida
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_DRUG_PRODUCT_DR_GROUP_BY_FK_IDA(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_DRUG_PRODUCT_DR_GROUP_BY_FK_IDA @FK_IDA=" & ida
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_DRUG_PRODUCT_ATC(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_DRUG_PRODUCT_ATC @FK_IDA=" & ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_DRUG_PRODUCT_ID_UNIT_DETAIL(ByVal ida As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_DRUG_PRODUCT_ID_UNIT_DETAIL @FK_IDA=" & ida
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_dactg() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_dactg "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_dosage_form() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_dosage_form "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_MAS_DRUG_SHAPE() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_MAS_DRUG_SHAPE "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_dosage_form_old() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_dosage_form_old "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        '
        Public Function SP_drclass() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec dbo.SP_drclass "
            Dim dt As New DataTable
            dt = clsds.dsQueryselect(sql, con_str).Tables(0)

            Return dt
        End Function
        Public Function SP_ATC_DRUG_ALL() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_ATC_DRUG_ALL "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_ATC_DRUG_SEARCH(ByVal atc As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_ATC_DRUG_SEARCH  @nm='" & atc & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        '
        Public Function SP_ATC_DRUG_SEARCH_V2(ByVal atc As String, ByVal atc_name As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_ATC_DRUG_SEARCH_V2  @nm='" & atc & "' ,@atc_name='" & atc_name & "'"
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_MAS_CHEMICAL_SEARCH_RESULT(ByVal nm As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MAS_CHEMICAL_SEARCH_RESULT @nm = '" & nm & "'"
            Dim dt As New DataTable

            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function
        '
        Public Function SP_DRIOWA_SEARCH_RESULT(ByVal nm As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRIOWA_SEARCH_RESULT @nm = '" & nm & "'"
            Dim dt As New DataTable

            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try
            Return dt
        End Function
        Public Function SP_MAS_CHEMICAL_SEARCH_RESULT_STAFF() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_MAS_CHEMICAL_SEARCH_RESULT_STAFF "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        Public Function SP_GET_DRRGT_DTL_TEXT_ALL() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_DRRGT_DTL_TEXT_ALL "
            Dim dt As New DataTable
            Try
                dt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try


            Return dt
        End Function
        'Public Function Get_U1_Data(ByVal product As String, ByVal lcnno As String) As DataTable
        '    Dim clsds As New ClassDataset
        '    Dim sql As String = " "
        '    sql &= " select * from ("
        '    sql &= " select IDA , case when thadrgnm <> '-' then thadrgnm else engdrgnm end as product_name"
        '    sql &= " ,cast(cast(right(lcnno,5) as int) as nvarchar(max)) + '/' + left(lcnno,2) as lcnno_display"
        '    sql &= " ,rgttpcd,engdrgtpnm,Newcode"
        '    sql &= " from [DRUG124].[FDA_XML_DRUG].[dbo].[XML_DRUG_DR]"
        '    sql &= " ) t"
        '    sql &= " where product_name like '%" & product & "%' and lcnno_display like '%" & lcnno & "%'"
        '    Dim dtt As New DataTable
        '    Try
        '        dtt = clsds.dsQueryselect(sql, con_str).Tables(0)
        '    Catch ex As Exception

        '    End Try

        '    Return dtt
        'End Function
        Public Function Get_U1_Data(ByVal product As String, ByVal lcnno As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = " "
            sql &= " select * from ("
            sql &= " select pvncd ,drgtpcd,rgttpcd,rgtno,engdrgtpnm, case when isnull(thadrgnm,'-') <> '-' then thadrgnm else engdrgnm end as product_name"
            sql &= " ,thadrgnm,engdrgnm,case when thadrgnm = '-' then '' else thadrgnm end "
            sql &= " + case when engdrgnm = '-' then '' else engdrgnm end  as product_name2 ,register as lcnno_display,Newcode"
            sql &= " from [DRUG124].[FDA_XML_DRUG].[dbo].[XML_SEARCH_DRUG_DR] "
            sql &= " where frn_no = 1"
            sql &= " ) t"
            sql &= " where product_name2 like '%" & product & "%' and lcnno_display like '%" & lcnno & "%'"
            Dim dtt As New DataTable
            Try
                dtt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try

            Return dtt
        End Function
        '
        Public Function Get_U1_Data_BY_U1(ByVal Newcode As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = " "
            sql &= " select * from ("
            sql &= " select IDA , case when thadrgnm <> '-' then thadrgnm else engdrgnm end as product_name"
            'sql &= " ,cast(cast(right(lcnno,5) as int) as nvarchar(max)) + '/' + left(lcnno,2) as lcnno_display"
            sql &= " ,thadrgnm,engdrgnm,thadrgnm+engdrgnm as product_name2 ,register as lcnno_display"
            sql &= " ,rgttpcd,engdrgtpnm,Newcode"
            sql &= " from [DRUG124].[FDA_XML_DRUG].[dbo].[XML_SEARCH_PRODUCT_GROUP]"
            sql &= " ) t"
            sql &= " where Newcode ='" & Newcode & "'"
            Dim dtt As New DataTable
            Try
                dtt = clsds.dsQueryselect(sql, con_str).Tables(0)
            Catch ex As Exception

            End Try

            Return dtt
        End Function
        ''' <summary>
        ''' ข้อมูลตารางสถานที่ สำหรับผู้ประกอบการ
        ''' </summary>
        ''' <param name="LOCATION_TYPE_CD"></param>
        ''' <param name="LCNSID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(ByVal LOCATION_TYPE_CD As Integer, ByVal LCNSID As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID @LCNSID=" & LCNSID & " ,@LOCATION_TYPE_CD=" & LOCATION_TYPE_CD
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_CUSTOMER_DALCN_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(ByVal LOCATION_TYPE_CD As Integer, ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_DALCN_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID @iden='" & iden & "' ,@LOCATION_TYPE_CD=" & LOCATION_TYPE_CD
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_DRRGT124_ALL() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DRRGT124_ALL "
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_E_TRACKING_REPORT_PROCESS_ALL() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_REPORT_PROCESS_ALL "
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_GET_EXPERT_SELECTED(ByVal newcode As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_EXPERT_SELECTED @newcode='" & newcode & "'"
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_GET_EXPERT_SELECTED_V2(ByVal rcvno As String, ByVal ctzid As String, ByVal rgttpcd As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_EXPERT_SELECTED_V2 @rcvno='" & rcvno & "' ,@ctzid='" & ctzid & "' ,@rgttpcd='" & rgttpcd & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_GET_EXPERT_SELECTED_V3(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal s_type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_EXPERT_SELECTED_V3 @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' ,@b_type=" & b_type & " ,@s_type=" & s_type
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_GET_EXPERT_SELECTED_V4(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal s_type As Integer, ByVal drgtpcd As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_EXPERT_SELECTED_V4 @rcvno='" & rcvno & "' ,@rgttpcd='" & rgttpcd & "' ,@b_type=" & b_type & " ,@s_type=" & s_type & ",@drgtpcd='" & drgtpcd & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function SP_GET_EXPERT_SELECTED_BY_FK_IDA(ByVal FK_IDA As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_EXPERT_SELECTED_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDENTIFY(ByVal LOCATION_TYPE_CD As Integer, ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDENTIFY @iden='" & iden & "' ,@LOCATION_TYPE_CD=" & LOCATION_TYPE_CD
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_LOCATION_ADDRESS_BY_IDENTIFY(ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_LOCATION_ADDRESS_BY_IDENTIFY @IDENTIFY='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryd_CPN(sql)
            Return dta
        End Function
        '
        Public Function SP_DALCN_LOCATION_ADDRESS_BY_IDENTIFY(ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DALCN_LOCATION_ADDRESS_BY_IDENTIFY @IDENTIFY='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_CUSTOMER_LCN_BY_IDEN(ByVal iden As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LCN_BY_IDEN @iden='" & iden & "'"
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        '
        Public Function SP_EDT_COUNT_BY_FK_IDA_AND_PROCESS_ID(ByVal FK_IDA As Integer, ByVal PROCESS_ID As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_EDT_COUNT_BY_FK_IDA_AND_PROCESS_ID @FK_IDA=" & FK_IDA & ",@PROCESS_ID='" & PROCESS_ID & "'"
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_EDT_HISTORY_COUNT_BY_FK_IDA(ByVal FK_IDA As Integer, ByVal EDIT_COUNT As Integer, ByVal EDIT_TYPE As Integer) As Integer
            Dim c_rows As Integer = 0
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_EDT_HISTORY_COUNT_BY_FK_IDA @FK_IDA=" & FK_IDA & ",@EDIT_COUNT=" & EDIT_COUNT & ", @EDIT_TYPE=" & EDIT_TYPE
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            If dta.Rows.Count > 0 Then
                Try
                    c_rows = dta(0)("c_rows")
                Catch ex As Exception

                End Try

            End If
            Return c_rows
        End Function
        Public Function DALCN_PHR_HISTORY_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec DALCN_PHR_HISTORY_BY_FK_IDA @FK_PHR_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_EDIT_HISTORY_REPORT_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_EDIT_HISTORY_REPORT_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_REPORT_BY_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_REPORT_BY_IDA @IDA=" & FK_IDA
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        ''' <summary>
        ''' ดึงเลขนิติบุคคลจาก LCNSID
        ''' </summary>
        ''' <param name="LCNSID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_IDENTIFY_by_LCNSID(ByVal LCNSID As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_IDENTIFY_by_LCNSID @LCNSID=" & LCNSID
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn_CPN.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_CUSTOMER_LCN_BY_FK_IDA_FOR_PHR(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LCN_BY_FK_IDA_FOR_PHR @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn_CPN.ConnectionString).Tables(0)
            Return dta
        End Function

        ''' <summary>
        ''' ใบอนุญาตสถานที่จำลองของเจ้าหน้าที่
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SP_CUSTOMER_LOCATION_ADDRESS_LCT(ByVal lcn_type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_LOCATION_ADDRESS_LCT @lct_type=" & lcn_type
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_CUSTOMER_DALCN_LOCATION_ADDRESS_LCT(ByVal lcn_type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CUSTOMER_DALCN_LOCATION_ADDRESS_LCT @lct_type=" & lcn_type
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_CONSIDER_REQ_PRINT_HISTORY() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_CONSIDER_REQ_PRINT_HISTORY "
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        Public Function SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT(ByVal start_date As Date, ByVal enddate As Date, ByVal group_id As Integer) As DataTable
            Dim dayBegin As Integer = convertDateToInteger(start_date)
            Dim dayEnd As Integer = convertDateToInteger(enddate)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT @date_begin=" & dayBegin & " ,@date_end=" & dayEnd & ",@group_id=" & group_id
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_NEW(ByVal start_date As Date, ByVal enddate As Date, ByVal group_id As Integer, ByVal _type As Integer) As DataTable
            Dim dayBegin As Integer = convertDateToInteger(start_date)
            Dim dayEnd As Integer = convertDateToInteger(enddate)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_NEW @date_begin=" & dayBegin & " ,@date_end=" & dayEnd & ",@group_id=" & group_id & " ,@type=" & _type
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function

        Public Function SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP(ByVal start_date As Date, ByVal enddate As Date, ByVal group_id As Integer) As DataTable
            Dim dayBegin As Integer = convertDateToInteger(start_date)
            Dim dayEnd As Integer = convertDateToInteger(enddate)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP @date_begin=" & dayBegin & " ,@date_end=" & dayEnd & ", @group_id=" & group_id
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP_NEW(ByVal start_date As Date, ByVal enddate As Date, ByVal group_id As Integer, ByVal _type As Integer) As DataTable
            Dim dayBegin As Integer = convertDateToInteger(start_date)
            Dim dayEnd As Integer = convertDateToInteger(enddate)
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP_NEW @date_begin=" & dayBegin & " ,@date_end=" & dayEnd & ", @group_id=" & group_id & " ,@type=" & _type
            Dim dta As New DataTable
            dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Return dta
        End Function
        '
        Public Function SP_GET_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA(ByVal FK_IDA As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_E_TRACKING_WORK_DAY_REPORT_DETAIL_BY_FK_IDA @FK_IDA=" & FK_IDA
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_GET_E_TRACKING_STOP_DAY(ByVal rcvno As Integer, ByVal rgttpcd As String, ByVal PRODUCT_TYPE As Integer, ByVal SMALL_TYPE As Integer, ByVal lcnsid As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_E_TRACKING_STOP_DAY @rcvno=" & rcvno & ", @rgttpcd='" & rgttpcd & "' ,@PRODUCT_TYPE=" & PRODUCT_TYPE & " ,@SMALL_TYPE=" & SMALL_TYPE & ", @lcnsid=" & lcnsid
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_GET_E_TRACKING_STOP_DAY_V2(ByVal fk_ida As Integer, ByVal _type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_E_TRACKING_STOP_DAY_V2 @FK_IDA=" & fk_ida & ", @TYPE_P=" & _type
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_GET_E_TRACKING_STOP_DAY_V3(ByVal fk_ida As Integer, ByVal _type As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_E_TRACKING_STOP_DAY_V3 @FK_IDA=" & fk_ida & ", @TYPE_P=" & _type
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID(ByVal rcvno As String, ByVal ctzid As String, ByVal ntype As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID @rcvno='" & rcvno & "' ,@ctzid='" & ctzid & "' ,@ntype='" & ntype & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW_V2(ByVal rcvno As String, ByVal ntype As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW_V2 @rcvno='" & rcvno & "' ,@ntype='" & ntype & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function

        Public Function SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW_V3(ByVal rcvno As String, ByVal ntype As String, ByVal ntype2 As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW_V3 @rcvno='" & rcvno & "' ,@ntype='" & ntype & "' ,@drgtpcd='" & ntype2 & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW(ByVal rcvno As String, ByVal ctzid As String, ByVal ntype As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW @rcvno='" & rcvno & "' ,@ctzid='" & ctzid & "' ,@ntype='" & ntype & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function SP_TYPE_REQUESTS() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_TYPE_REQUESTS"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_TYPE_REQUESTS_BY_GROUP(ByVal _group As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_TYPE_REQUESTS_BY_GROUP @g=" & _group
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        '
        Public Function SP_TYPE_REQUESTS_CUSTOMER() As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_TYPE_REQUESTS_CUSTOMER "
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function
        Public Function convertDateToInteger(ByVal dateSelect As Date)
            Dim dayfirst As Date = Date.Now
            dayfirst = CDate(dayfirst.ToShortDateString())
            Dim dateResult As Integer = DateDiff(DateInterval.Day, dayfirst, dateSelect)

            Return dateResult
        End Function
        Public Function SP_E_TRACKING_STATUS_DATE_NAME_BY_HEAD_STATUS(ByVal head_stat As Integer) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_E_TRACKING_STATUS_DATE_NAME_BY_HEAD_STATUS @head_stat=" & head_stat
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function

        Public Function SP_GET_LCN_EXTEND_BY_IDA_lc_IDA(IDA As String, lc_IDA As String) As DataTable
            Dim clsds As New ClassDataset
            Dim sql As String = "exec SP_GET_LCN_EXTEND_BY_IDA_lc_IDA @IDA='" & IDA & "' ,@lc_IDA='" & lc_IDA & "'"
            Dim dta As New DataTable
            Try
                dta = clsds.dsQueryselect(sql, conn.ConnectionString).Tables(0)
            Catch ex As Exception

            End Try

            Return dta
        End Function

    End Class

    Public Class AppSettings
        Public _PATH_PDF_TEMPLATE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")    'ที่อยู่ Path
        Public _PATH_XML_CLASS As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")          'ที่อยู่ Path
        Public _PATH_PDF_XML_CLASS As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")  'ที่อยู่ Path
        Public _PATH_PDF_TRADER As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")        'ที่อยู่ Path
        Public _PATH_XML_TRADER As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")        'ที่อยู่ Path
        Public _PATH_DEFAULT As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT")              'ที่อยู่ Path
        Public _PATH_EDIT As String = System.Configuration.ConfigurationManager.AppSettings("PATH_EDIT")              'ที่อยู่ Path
        Public _PATH_SUBS As String = System.Configuration.ConfigurationManager.AppSettings("PATH_EDIT")
        Public _RDLC As String = System.Configuration.ConfigurationManager.AppSettings("RDLC")
        Public _PATH_XML_IMPORT As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_IMPORT")        'มินทำต้องทำต่อ 5555555555555555555
        Public _PATH_PDF_IMPORT As String = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_IMPORT")
        Sub RunAppSettings()
            _PATH_PDF_TEMPLATE = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")                 'ที่อยู่ Path
            _PATH_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")                       'ที่อยู่ Path
            _PATH_PDF_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")               'ที่อยู่ Path
            _PATH_PDF_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")                     'ที่อยู่ Path
            _PATH_XML_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")                     'ที่อยู่ Path
            _PATH_EDIT = System.Configuration.ConfigurationManager.AppSettings("PATH_EDIT")              'ที่อยู่ Path
            _RDLC = System.Configuration.ConfigurationManager.AppSettings("RDLC")
            _PATH_XML_IMPORT = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_IMPORT")
            _PATH_PDF_IMPORT = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_IMPORT")
        End Sub
    End Class

    Public Class convert_num
        Function con_lcnno(ByVal IDA As String)
            Dim str_lcnno As String
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_IDA(IDA)
            str_lcnno = dao_dalcn.fields.lcnno.ToString()
            'str_lcnno = dao_dalcn.fields.pvncd.ToString() & "-" & dao_dalcn.fields.lcntpcd.ToString() & "-" & dao_dalcn.fields.lcnno.ToString().Substring(4, 3) & dao_dalcn.fields.lcnno.ToString().Substring(0, 2)

            Return str_lcnno
        End Function
        Function con_lcntype(ByVal IDA As String)
            Dim str_lcntype As String
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            Dim dao_dalcntype As New DAO_DRUG.ClsDBdalcntype
            'dao_dalcn.GetDataby_IDA(IDA)
            dao_dalcntype.GetDataby_lcntpcd(dao_dalcn.fields.lcntpcd)
            str_lcntype = dao_dalcntype.fields.lcntpnm
            Return str_lcntype

        End Function

    End Class


    Public Class information
        Public Function load_name(ByVal _CLS As CLS_SESSION) As CLS_SESSION
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm

            dao_syslcnsid.GetDataby_identify(_CLS.CITIZEN_ID)
            dao_syslcnsnm.GetDataby_identify(_CLS.CITIZEN_ID)
            Try

            Catch ex As Exception
                _CLS.LCNSID = dao_syslcnsid.fields.lcnsid
            End Try


            If String.IsNullOrEmpty(dao_syslcnsnm.fields.thalnm) = True Or dao_syslcnsnm.fields.thalnm = Nothing Then
                _CLS.THANM = dao_syslcnsnm.fields.thanm
            Else
                _CLS.THANM = dao_syslcnsnm.fields.thanm + " " + dao_syslcnsnm.fields.thalnm
            End If
            Return _CLS
            '     Session("CLS") = _CLS
        End Function



        Public Function load_lcnsid_customer(ByVal _CLS As CLS_SESSION) As CLS_SESSION
            Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE

            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            Try
                dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

                _CLS.LCNSID_CUSTOMER = dao_syslcnsid.fields.lcnsid
            Catch ex As Exception

            End Try

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
            Try
                Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

                Dim fullname As String = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
                _CLS.THANM_CUSTOMER = fullname
            Catch ex As Exception

            End Try


            Return _CLS
        End Function
    End Class


    Public Class GenNumber
        'CODE แปลงเลข ให้รองรับแบบ NCT-N-2560-1
        Public Function FORMAT_NUMBER_BOOKING(ByVal SYSTEM As String, ByVal TYPE As String, ByVal YEAR As String, ByVal int_no As Integer) As String
            Dim str_no As String = SYSTEM & "-" & TYPE & "-" & YEAR & "-" & int_no
            Return str_no
        End Function
        'ควรแบ่ง CODE ออกเป็น 2 ส่วน Code ที่ 1 เป็น CODE ดึงเลข
        Public Function GEN_DRUG_RCVNO_NO(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer) As Integer
            Dim int_no As Integer
            Dim dao As New DAO_BOOKING.TB_DRUG_GENNO
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If
            int_no = int_no + 1
            dao = New DAO_BOOKING.TB_DRUG_GENNO
            dao.fields.YEAR = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GENNO = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Return int_no
        End Function
        ''' <summary>
        ''' Function Genrcvno ในตาราง dalcn
        ''' </summary>
        Public Function GenRcvno_Falcn(ByVal Year As String, ByVal dalcn_id As Integer) As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_01
            dao.GetDataby_YEAR(Year)

            Dim rcvno As Integer = 1
            For Each dao.fields In dao.datas
                rcvno = dao.fields.GENNO + 1
            Next

            dao = New DAO_DRUG.clsDBGEN_NO_01
            dao.fields.GENNO = rcvno
            dao.fields.REF_IDA = dalcn_id
            dao.fields.YEAR = Year
            dao.insert()

            Return rcvno
        End Function

        ''' <summary>
        ''' Function Genrcvno ในตาราง falcn
        ''' </summary>
        Public Function GenRcvno_CHEMICAL(ByVal Year As String, ByVal IDA As Integer) As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_02
            dao.GetDataby_YEAR(Year)

            Dim rcvno As Integer = 1
            For Each dao.fields In dao.datas
                rcvno = dao.fields.GENNO + 1
            Next

            dao = New DAO_DRUG.clsDBGEN_NO_02
            dao.fields.GENNO = rcvno
            dao.fields.REF_IDA = IDA
            dao.fields.YEAR = Year
            dao.insert()

            Return rcvno
        End Function


        ''' <summary>
        ''' แปลงเลข yyxxxxx เป็น xxxxx/25yy
        ''' </summary>
        ''' <param name="str_no"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function Convert_no(ByVal str_no As String)
            If String.IsNullOrEmpty(str_no) = False Then
                Dim str_year As String = str_no.Trim().Substring(0, 2)
                Dim str_num As String = str_no.Trim().Substring(2, 5)
                Dim int_num As Integer = Integer.Parse(str_num)
                'str_num = String.Format("{0:00000}", int_num.ToString("00000"))
                str_num = int_num.ToString()
                str_no = str_num + "/25" + str_year
            End If

            Return str_no
        End Function
        ''' <summary>
        '''  GENNO_CER
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GEN_CER_NO(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer

            Dim dao As New DAO_DRUG.clsDBGEN_NO_02
            dao.GetDataby_GEN2(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)


            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1

            dao = New DAO_DRUG.clsDBGEN_NO_02

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()
            Return str_no
        End Function
        Function GEN_CER_NO_V2(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer

            Dim dao As New DAO_DRUG.clsDBGEN_NO_02
            dao.GetDataby_GEN2(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)

            Dim cer_seq As String = ""
            Dim cer_short As String = ""
            cer_seq = get_cer_seq(TYPE)
            cer_short = get_cer_short(TYPE)

            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1

            dao = New DAO_DRUG.clsDBGEN_NO_02

            Dim str_no As String = "" ' int_no.ToString()
            'str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = cer_seq & "-" & cer_short & YEAR.Substring(2, 2) & "-" & int_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()
            Return str_no
        End Function
        Function get_cer_seq(ByVal cer_type As Integer) As String
            Dim cer_seq As String = ""
            If cer_type = "31" Then
                cer_seq = "01"
            ElseIf cer_type = "32" Then
                cer_seq = "02"
            ElseIf cer_type = "33" Then
                cer_seq = "03"
            ElseIf cer_type = "34" Then
                cer_seq = "04"
            ElseIf cer_type = "35" Then
                cer_seq = "05"
            ElseIf cer_type = "36" Then
                cer_seq = "06"
            End If
            Return cer_seq
        End Function
        Function get_cer_short(ByVal cer_type As Integer) As String
            Dim cer_short As String = ""
            If cer_type = "31" Then
                cer_short = "GMP"
            ElseIf cer_type = "32" Then
                cer_short = "ISO"
            ElseIf cer_type = "33" Then
                cer_short = "HAC"
            ElseIf cer_type = "34" Then
                cer_short = "PO"
            ElseIf cer_type = "35" Then
                cer_short = "COA"
            ElseIf cer_type = "36" Then
                cer_short = "XX"
            End If

            Return cer_short
        End Function
        Function GEN_CER_FOREIGN_NO(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String, ByVal TYPE_CER As Integer) As String
            Dim int_no As Integer

            Dim dao As New DAO_DRUG.clsDBGEN_NO_02
            dao.GetDataby_GEN2(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)

            Dim cer_seq As String = ""
            cer_seq = get_cerf_short(TYPE_CER)

            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1

            dao = New DAO_DRUG.clsDBGEN_NO_02

            Dim str_no As String = "" ' int_no.ToString()
            Dim r_no As String = int_no.ToString()
            r_no = String.Format("{0:0000}", int_no.ToString("0000"))
            str_no = cer_seq & "-" & YEAR.Substring(2, 2) & "-" & r_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()
            Return str_no
        End Function
        Function get_cerf_short(ByVal cer_type As Integer) As String
            Dim cer_seq As String = ""
            If cer_type = 1 Then
                cer_seq = "PS"
            ElseIf cer_type = 2 Then
                cer_seq = "CP"
            ElseIf cer_type = 3 Then
                cer_seq = "NP"
            ElseIf cer_type = 4 Then
                cer_seq = "TH"
            ElseIf cer_type = 5 Then
                cer_seq = "TH"
            End If
            Return cer_seq
        End Function
        Function GEN_CER_RCVNO(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer

            Dim dao As New DAO_DRUG.clsDBGEN_NO_03
            dao.GetDataby_GEN2(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)


            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1

            dao = New DAO_DRUG.clsDBGEN_NO_03

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()
            Return str_no
        End Function
        ''' <summary>
        ''' ออกเลขรับ โดยใช้แค่ ปี กับ จังหวัด
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GEN_LCNNO_RCVNO(ByVal REF_IDA As Integer, ByVal PVCODE As String, ByVal GROUP_ID As Integer) As String
            Dim Years As String = con_year(Date.Now.Year)
            Dim dao_gen As New DAO_DRUG.clsDBGEN_NO_03
            dao_gen.GetDataby_GEN_YEAR_PVCODE(Years, PVCODE, GROUP_ID)

            Dim running As Integer = 0
            Try
                running = dao_gen.fields.GENNO
            Catch ex As Exception

            End Try

            running = running + 1

            dao_gen = New DAO_DRUG.clsDBGEN_NO_03
            dao_gen.fields.REF_IDA = REF_IDA
            dao_gen.fields.DESCRIPTION = "เลขรับ สถานที่"
            dao_gen.fields.FORMAT = "1"
            dao_gen.fields.GENNO = running
            dao_gen.fields.GROUP_NO = GROUP_ID
            dao_gen.fields.LCNNO = ""
            dao_gen.fields.PVCODE = PVCODE
            dao_gen.fields.TYPE = "1"
            dao_gen.fields.YEAR = Years
            dao_gen.insert()

            Dim rcvno As String = "0"
            Dim str_no As String = running.ToString()
            str_no = String.Format("{0:00000}", running.ToString("00000"))
            str_no = Years.Substring(2, 2) & str_no
            Return str_no

        End Function

        ''' <summary>
        '''  GENNO_NO_01
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GEN_NO_01(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_01
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no

            Dim dao2 As New DAO_DRUG.clsDBGEN_NO_01
            dao2.fields.YEAR = YEAR
            dao2.fields.PVCODE = PVCODE
            dao2.fields.TYPE = TYPE
            dao2.fields.LCNNO = LCNNO
            dao2.fields.FORMAT = FORMAT
            dao2.fields.GROUP_NO = GROUP_NO
            dao2.fields.REF_IDA = REF_IDA
            dao2.fields.DESCRIPTION = str_no
            dao2.fields.GENNO = int_no
            dao2.insert()

            Return str_no
        End Function

        ''' <summary>
        '''  GENNO_NO_02
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GEN_NO_02(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_02
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            dao = New DAO_DRUG.clsDBGEN_NO_02
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function

        Function GEN_NO_04(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_04
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no

            dao = New DAO_DRUG.clsDBGEN_NO_04
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function
        Function GEN_NO_05(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_05
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_DRUG.clsDBGEN_NO_05
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function
        Function GEN_NO_06(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                       ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_06
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            dao = New DAO_DRUG.clsDBGEN_NO_06
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function
        Function GEN_NO_07(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                       ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_07
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            dao = New DAO_DRUG.clsDBGEN_NO_07
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function
        'ลงทะเบียนโปรดัค
        Function GEN_NO_16(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                       ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_16
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            dao = New DAO_DRUG.clsDBGEN_NO_16
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function
        Function GEN_NO_17(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_17
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            dao = New DAO_DRUG.clsDBGEN_NO_17
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            ' str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = PVCODE & "-" & GROUP_NO & "-" & YEAR.Substring(2, 2) & "-" & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function

        Function GEN_NO_18(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_18
            dao.GetDataby_GEN(YEAR, PVCODE, TYPE, LCNNO, FORMAT, GROUP_NO, REF_IDA, DESCRIPTION)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            dao = New DAO_DRUG.clsDBGEN_NO_18
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            ' str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = PVCODE & "-" & GROUP_NO & "-" & YEAR.Substring(2, 2) & "-" & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function
        ''' <summary>
        '''  GEN เลขใบรับนัด
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GEN_NO_02_2(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.clsDBGEN_NO_02
            dao.GetDataby_GEN3(YEAR, PVCODE, GROUP_NO, REF_IDA)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If

            dao = New DAO_DRUG.clsDBGEN_NO_02
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            ' str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = PVCODE & "-" & GROUP_NO & "-" & YEAR.Substring(2, 2) & "-" & str_no
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVCODE
            dao.fields.TYPE = TYPE
            dao.fields.LCNNO = LCNNO
            dao.fields.FORMAT = FORMAT
            dao.fields.GROUP_NO = GROUP_NO
            dao.fields.REF_IDA = REF_IDA
            dao.fields.DESCRIPTION = str_no
            dao.fields.GENNO = int_no
            dao.insert()


            Return str_no
        End Function


        ' gen rcvno ชื่อสาร
        Public Function GEN_RCVNO_NO(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.ClsDBGEN_RCVNO                                      '
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID)            'สร้างเลขล่าสุด
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If
            int_no = int_no + 1

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_DRUG.ClsDBGEN_RCVNO
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_RCV = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Return str_no
        End Function

        Public Function GEN_RCVNO_NO_50k(ByVal YEAR As String, ByVal PVNCD As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.ClsDBGEN_RCVNO
            dao.GetDataby_Year_PVNCD_PROCESS_ID_MAX(PVNCD, YEAR, PROCESS_ID)
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If
            int_no = int_no + 1

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:50000}", int_no.ToString("50000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_DRUG.ClsDBGEN_RCVNO
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_RCV = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
            Return str_no
        End Function
        Public Function GEN_RGTNO50K(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer, ByVal process_id As String) As String
            Dim int_no As Integer

            Dim dao As New DAO_DRUG.clsDBGEN_NO_01  '
            dao.GetDataby_RGTNO_50KMAX(YEAR, PVNCD, RGTTPCD, FK_IDA, process_id)
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If
            int_no = int_no + 1

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:50000}", int_no.ToString("50000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_DRUG.clsDBGEN_NO_01
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVNCD
            dao.fields.GENNO = int_no
            dao.fields.TYPE = process_id 'RGTTPCD
            dao.fields.GROUP_NO = RGTTPCD
            dao.fields.IDA = FK_IDA
            dao.fields.LCNNO = str_no
            dao.fields.DESCRIPTION = str_no
            dao.insert()
            Return str_no
        End Function
        Public Function GEN_RGTNO(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer) As String
            Dim int_no As Integer

            Dim dao As New DAO_DRUG.clsDBGEN_NO_01
            '
            If RGTTPCD = "1" Or RGTTPCD = "6" Then
                dao.GetDataby_RGTNO_MAX_N_NC(YEAR, PVNCD, FK_IDA)
            ElseIf RGTTPCD = "7" Or RGTTPCD = "B" Then
                dao.GetDataby_RGTNO_MAX_NB_NBC(YEAR, PVNCD, FK_IDA)
            Else
                dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
            End If
            If IsNothing(dao.fields.GENNO) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GENNO
            End If
            int_no = int_no + 1

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_DRUG.clsDBGEN_NO_01
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVNCD
            dao.fields.GENNO = int_no
            dao.fields.TYPE = RGTTPCD
            dao.fields.IDA = FK_IDA
            dao.fields.LCNNO = str_no
            dao.fields.DESCRIPTION = str_no
            dao.insert()
            Return str_no
        End Function
        Public Function GEN_RCVNO_RGT(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer) As String
            Dim int_no As Integer

            Dim dao As New DAO_DRUG.ClsDBGEN_RCVNO
            '
            If RGTTPCD = "1" Or RGTTPCD = "6" Then
                dao.GetDataby_RGTNO_MAX_N_NC(YEAR, PVNCD, FK_IDA)
            ElseIf RGTTPCD = "7" Or RGTTPCD = "B" Then
                dao.GetDataby_RGTNO_MAX_NB_NBC(YEAR, PVNCD, FK_IDA)
            Else
                dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
            End If
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If
            int_no = int_no + 1

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            dao = New DAO_DRUG.ClsDBGEN_RCVNO
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVNCD
            dao.fields.GEN_RCV = int_no
            dao.fields.GEN_TYPE = RGTTPCD
            dao.fields.IDA = FK_IDA
            dao.insert()
            Return str_no
        End Function
        Public Function GEN_DH15TDGT_NO(ByVal YEAR As String, ByVal aroi As String, ByVal PROCESS_ID As String, ByVal FK_IDA As Integer, ByVal DETAIL_ID As Integer _
                                        , ByVal type_cas As String) As String
            Dim int_no As Integer = 0
            Dim dao As New DAO_DRUG.clsDBGEN_DH15TDGT_NO
            dao.GetDataby_GEN_MAX2(YEAR, type_cas)
            If IsNothing(dao.fields.RUNNING_NUMBER) = True Then
                int_no = 0
            Else
                int_no = dao.fields.RUNNING_NUMBER
            End If
            int_no = int_no + 1

            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:0000000}", int_no.ToString("0000000"))
            str_no = "DRM-" & aroi & "-" & type_cas & "-" & YEAR.Substring(2, 2) & "-" & str_no


            dao = New DAO_DRUG.clsDBGEN_DH15TDGT_NO
            dao.fields.FK_DETAIL_IDA = DETAIL_ID
            dao.fields.FULL_NUMBER_15DIGIT = str_no
            dao.fields.TYPE_CAS = type_cas
            dao.fields.YEARS = YEAR
            dao.fields.RUNNING_NUMBER = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = FK_IDA
            dao.fields.aroi = aroi
            dao.insert()
            Return str_no
        End Function
        Function GEN_RCVNO_REQUEST(ByVal YEAR As String, ByVal PVCODE As String, ByVal GEN_TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal PROCESS_ID As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String) As String
            Dim int_no As Integer
            Dim dao As New DAO_DRUG.TB_GEN_RCVNO_REQUEST
            dao.GetDataby_GEN4(YEAR, PVCODE, PROCESS_ID, GEN_TYPE)
            If IsNothing(dao.fields.GEN_RCV) = True Then
                int_no = 0
            Else
                int_no = dao.fields.GEN_RCV
            End If

            dao = New DAO_DRUG.TB_GEN_RCVNO_REQUEST
            int_no = int_no + 1
            Dim str_no As String = int_no.ToString()
            ' str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = PVCODE & "-" & PROCESS_ID & "-" & YEAR.Substring(2, 2) & "-" & str_no
            dao.fields.YEARS = YEAR
            dao.fields.PVNCD = PVCODE
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.FK_IDA = REF_IDA
            dao.fields.GEN_RCV = int_no
            dao.fields.GEN_TYPE = GEN_TYPE
            dao.insert()

            Return str_no
        End Function
        '-----------------------------------------------

        'CODE แปลงเลข 5900001
        Public Function FORMAT_NUMBER_FULL(ByVal YEAR As String, ByVal int_no As Integer) As String
            Dim str_no As String = int_no.ToString()
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no = YEAR.Substring(2, 2) & str_no
            Return str_no
        End Function

        'CODE แปลงเลข ให้รองรับแบบ 1/59
        Public Function FORMAT_NUMBER_MINI(ByVal YEAR As String, ByVal int_no As String) As String
            Dim no_split As Integer = 0

            Try
                no_split = CInt(int_no.Substring(2, 5))
            Catch ex As Exception

            End Try

            Dim str_no As String = ""
            str_no = no_split & "/" & YEAR.Substring(2, 2)
            Return str_no
        End Function

        Public Function FORMAT_NUMBER_YEAR_FULL(ByVal YEAR As String, ByVal int_no As String) As String
            Dim no_split As Integer = 0

            Try
                no_split = CInt(int_no.Substring(2, 5))
            Catch ex As Exception

            End Try

            Dim str_no As String = ""
            str_no = no_split & "/" & YEAR
            Return str_no
        End Function

    End Class


    ''' <summary>
    ''' ใช้สำหรับ บันทึกเลข TRANSECTION
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TRANSECTION

        Private _CITIZEN_ID As String
        Public Property CITIZEN_ID() As String
            Get
                Return _CITIZEN_ID
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID = value
            End Set
        End Property

        Private _CITIZEN_ID_AUTHORIZE As String
        Public Property CITIZEN_ID_AUTHORIZE() As String
            Get
                Return _CITIZEN_ID_AUTHORIZE
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID_AUTHORIZE = value
            End Set
        End Property



        Public Function insert_transection(ByVal processid As Integer) As Integer

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.fields.CITIEZEN_ID = _CITIZEN_ID
            dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CITIZEN_ID_AUTHORIZE
            dao_up.fields.PROCESS_ID = processid
            dao_up.fields.STATUS = 1
            dao_up.fields.UPLOAD_DATE = Date.Now()
            dao_up.fields.YEAR = con_year(Date.Now.Year)
            dao_up.insert() 'ปรับเป็น update
            Return dao_up.fields.ID

        End Function
    End Class


    ''' <summary>
    ''' ใช้สำหรับ บันทึกเลข DOWNLOAD_TRANSECTION
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DOWNLOAD_TRANSECTION

        Private _CITIZEN_ID As String
        Public Property CITIZEN_ID() As String
            Get
                Return _CITIZEN_ID
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID = value
            End Set
        End Property

        Private _CITIZEN_ID_AUTHORIZE As String
        Public Property CITIZEN_ID_AUTHORIZE() As String
            Get
                Return _CITIZEN_ID_AUTHORIZE
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID_AUTHORIZE = value
            End Set
        End Property



        Public Function insert_transection(ByVal processid As Integer) As Integer

            Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
            dao_down.fields.PROCESS_ID = processid
            dao_down.fields.CITIEZEN_ID = _CITIZEN_ID
            dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CITIZEN_ID_AUTHORIZE
            dao_down.fields.STATUS = 0
            dao_down.fields.DOWNLOAD_DATE = Date.Now()
            dao_down.insert()

            Return dao_down.fields.ID
        End Function
    End Class
    Public Class CAL_DATE
        Private _t_date As Date
        Public Property t_date() As Date
            Get
                Return _t_date
            End Get
            Set(ByVal value As Date)
                _t_date = value
            End Set
        End Property

        Private _day As Integer
        Public Property day() As Integer
            Get
                Return _day
            End Get
            Set(ByVal value As Integer)
                _day = value
            End Set
        End Property

        Public Function chk_num(ByVal process_id As String, ByVal SYSTEM_ID As String, ByVal t_date As Date) As Integer
            Dim bao_count As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Dim num As Integer = 0
            Dim group_id As String = String.Empty
            Dim dao_process As New DAO_BOOKING.TB_MAS_PROCESS

            dao_process.GetDataby_PROCESS_ID_and_SYSTEM_ID(process_id, SYSTEM_ID)
            group_id = dao_process.fields.PLACE_CONTACT_ID


            dt = bao_count.SP_COUNT_CENTER_SCHEDULE_BY_SYSTEM_ID_and_ALLOW_DATE_and_GROUP_ID(CDec(SYSTEM_ID), t_date, group_id)

            If group_id = 1 And t_date < CDate("23/8/2560") Then
                num = dao_process.fields.LIMIT_MONDAY
            ElseIf group_id = 2 And t_date < CDate("28/8/2560") Then
                num = dao_process.fields.LIMIT_MONDAY
            ElseIf group_id = 4 And t_date < CDate("17/8/2560") Then
                num = dao_process.fields.LIMIT_MONDAY
            ElseIf group_id = 5 And t_date < CDate("21/8/2560") Then
                num = dao_process.fields.LIMIT_MONDAY
            Else
                If dt.Rows.Count = 0 Then
                    num = 0
                Else
                    For Each dr As DataRow In dt.Rows
                        num = dr("num")
                    Next
                End If

            End If



            Return num
        End Function

        Public Function chk_num_DRUG(ByVal process_id As String, ByVal SYSTEM_ID As String, ByVal t_date As Date) As Integer
            Dim bao_count As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            Dim num As Integer = 0
            Dim group_id As String = String.Empty
            Dim dao_process As New DAO_BOOKING.TB_MAS_PROCESS

            dao_process.GetDataby_PROCESS_ID_and_SYSTEM_ID(process_id, SYSTEM_ID)
            group_id = dao_process.fields.GROUP_ID

            dt = bao_count.SP_COUNT_DRUG_SCHEDULE_BY_SYSTEM_ID_and_CONSIDER_DATE_and_GROUP_ID(CDec(SYSTEM_ID), t_date, group_id)
            If dt.Rows.Count = 0 Then
                num = 0
            Else
                For Each dr As DataRow In dt.Rows
                    num = dr("num")
                Next
            End If

            Return num
        End Function

        Public Function chk_limit(ByVal process_id As String, ByVal SYSTEM_ID As String, ByVal t_date As Date, ByVal num As Integer) As Boolean
            Dim dao_PROCESS As New DAO_BOOKING.TB_MAS_PROCESS
            Dim chk As Boolean = True
            dao_PROCESS.GetDataby_PROCESS_ID_and_SYSTEM_ID(process_id, SYSTEM_ID) 'test      
            If t_date.DayOfWeek = DayOfWeek.Sunday Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Saturday Then
                chk = False
                'วันหยุด

            ElseIf DateDiff(DateInterval.Day, t_date, CDate("14/8/2560")).ToString() = "0" Then
                chk = False

            ElseIf DateDiff(DateInterval.Day, t_date, CDate("13/10/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("23/10/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("26/10/2560")).ToString() = "0" Then
                chk = False

            ElseIf DateDiff(DateInterval.Day, t_date, CDate("5/12/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("10/12/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("11/12/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("31/12/2560")).ToString() = "0" Then
                chk = False

            ElseIf t_date.DayOfWeek = DayOfWeek.Monday And num >= dao_PROCESS.fields.LIMIT_MONDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Tuesday And num >= dao_PROCESS.fields.LIMIT_TUESDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Wednesday And num >= dao_PROCESS.fields.LIMIT_WEDNESDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Thursday And num >= dao_PROCESS.fields.LIMIT_THURSDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Friday And num >= dao_PROCESS.fields.LIMIT_FRIDAY Then
                chk = False



            End If
            Return chk
        End Function

        Public Function chk_limit_DRUG(ByVal process_id As String, ByVal SYSTEM_ID As String, ByVal t_date As Date, ByVal num As Integer) As Boolean
            Dim dao_PROCESS As New DAO_BOOKING.TB_MAS_PROCESS
            Dim chk As Boolean = True
            dao_PROCESS.GetDataby_PROCESS_ID_and_SYSTEM_ID(process_id, SYSTEM_ID) 'test

            'Dim ws_date As New WS_GETDATE_WORKING.Service1

            'ws_date.GETDATE_WORKING(t_date, True, 0, True,

            If t_date.DayOfWeek = DayOfWeek.Sunday Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Saturday Then
                chk = False
                'วันหยุด

            ElseIf DateDiff(DateInterval.Day, t_date, CDate("14/8/2560")).ToString() = "0" Then
                chk = False

            ElseIf DateDiff(DateInterval.Day, t_date, CDate("13/10/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("23/10/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("26/10/2560")).ToString() = "0" Then
                chk = False

            ElseIf DateDiff(DateInterval.Day, t_date, CDate("5/12/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("10/12/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("11/12/2560")).ToString() = "0" Then
                chk = False
            ElseIf DateDiff(DateInterval.Day, t_date, CDate("31/12/2560")).ToString() = "0" Then
                chk = False


            ElseIf t_date.DayOfWeek = DayOfWeek.Monday And num >= dao_PROCESS.fields.LIMIT_MONDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Tuesday And num >= dao_PROCESS.fields.LIMIT_TUESDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Wednesday And num >= dao_PROCESS.fields.LIMIT_WEDNESDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Thursday And num >= dao_PROCESS.fields.LIMIT_THURSDAY Then
                chk = False
            ElseIf t_date.DayOfWeek = DayOfWeek.Friday And num >= dao_PROCESS.fields.LIMIT_FRIDAY Then
                chk = False

            End If
            Return chk
        End Function


        Public Function TOTAL_DAY(ByRef s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String) As String


            Dim diff As String = String.Empty
            Dim num As Integer = 0
            Dim LAG_TIME As Integer = 0


            num = chk_num(process_id, SYSTEM_ID, s_date)
            If chk_limit(process_id, SYSTEM_ID, s_date, num) = False Then
                s_date = s_date.AddDays(1)
                s_date = TOTAL_DAY(s_date, process_id, SYSTEM_ID)

            End If

            t_date = s_date
            Return s_date

            diff = DateDiff(DateInterval.Day, s_date, t_date).ToString()

            Return diff
        End Function

        Public Function TOTAL_DATE(ByRef s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String, ByRef i As Integer) As Date

            Dim num As Integer = 0
            Dim LAG_TIME As Integer = 0


            num = chk_num(process_id, SYSTEM_ID, s_date)
            If chk_limit(process_id, SYSTEM_ID, s_date, num) = False Then

                s_date = s_date.AddDays(1)
                i += 1
                s_date = TOTAL_DATE(s_date, process_id, SYSTEM_ID, i)

            End If

            t_date = s_date
            day = i

            Return s_date
        End Function


        Public Function TOTAL_DAY_DRUG(ByRef s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String) As String


            Dim diff As String = String.Empty
            Dim num As Integer = 0
            Dim LAG_TIME As Integer = 0


            num = chk_num_DRUG(process_id, SYSTEM_ID, s_date)
            If chk_limit_DRUG(process_id, SYSTEM_ID, s_date, num) = False Then
                s_date = s_date.AddDays(1)
                s_date = TOTAL_DAY_DRUG(s_date, process_id, SYSTEM_ID)

            End If

            t_date = s_date
            Return s_date

            diff = DateDiff(DateInterval.Day, s_date, t_date).ToString()

            Return diff
        End Function




        Public Function TOTAL_ALLOW_DATE_DRUG(ByRef s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String, ByRef i As Integer) As Date
            Dim num As Integer = 0
            Dim LAG_TIME As Integer = 0

            Dim dao As New DAO_BOOKING.TB_MAS_PROCESS
            dao.GetDataby_PROCESS_ID(process_id)

            num = dao.fields.ALLOW_DAY
            'If chk_limit_DRUG(process_id, SYSTEM_ID, s_date, num) = False Then

            s_date = s_date.AddDays(num)
            '    i += 1
            '    s_date = TOTAL_DATE_DRUG(s_date, process_id, SYSTEM_ID, i)

            'End If

            t_date = s_date
            day = num

            Return s_date
        End Function




        Public Function TOTAL_DATE_DRUG(ByRef s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String, ByRef i As Integer) As Date
            Dim num As Integer = 0
            Dim LAG_TIME As Integer = 0


            num = chk_num_DRUG(process_id, SYSTEM_ID, s_date)
            If chk_limit_DRUG(process_id, SYSTEM_ID, s_date, num) = False Then

                s_date = s_date.AddDays(1)
                i += 1
                s_date = TOTAL_DATE_DRUG(s_date, process_id, SYSTEM_ID, i)

            End If

            t_date = s_date
            day = i

            Return s_date
        End Function


        Public Function TOTAL_LAG_DRUG(ByVal s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String) As Date
            Dim t_date As Date
            Dim LAG_TIME As Integer = 0
            Dim dao_process As New DAO_BOOKING.TB_MAS_PROCESS
            Dim ws_date As New WS_GETDATE_WORKING.Service1
            dao_process.GetDataby_PROCESS_ID_and_SYSTEM_ID(process_id, SYSTEM_ID)
            LAG_TIME = CDec(dao_process.fields.LAG_TIME)

            ws_date.GETDATE_WORKING(s_date, True, CDec(LAG_TIME), True, t_date, True)
            If s_date.Hour >= 12 Then
                t_date.AddDays(1)
            End If

            Return t_date
        End Function

        Public Function TOTAL_LAG_FOOD(ByVal s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String) As Date
            Dim t_date As Date
            Dim LAG_TIME As Integer = 0
            Dim dao_process As New DAO_BOOKING.TB_MAS_PROCESS
            Dim ws_date As New WS_GETDATE_WORKING.Service1


            dao_process.GetDataby_PROCESS_ID_and_SYSTEM_ID(process_id, SYSTEM_ID)
            LAG_TIME = CDec(dao_process.fields.LAG_TIME)


            ws_date.GETDATE_WORKING(s_date, True, CDec(LAG_TIME), True, t_date, True)

            If s_date.Hour >= 15 Then
                If s_date.Minute >= 30 Then
                    t_date.AddDays(1)
                End If
            End If

            Return t_date
        End Function

        Public Function SUM_WORK_DAY(ByVal s_date As Date, ByVal e_date As Date) As Integer

            Dim num As Integer = 0
            Dim date_diff As Integer = 0
            Dim t_date As Date
            date_diff = DateDiff(DateInterval.Day, s_date, e_date)
            For i = 0 To date_diff - 1
                t_date = t_date.AddDays(1)

                'วันหยุด
                If DateDiff(DateInterval.Day, t_date, CDate("14/8/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("13/10/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("23/10/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("26/10/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("5/12/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("10/12/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("11/12/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("31/12/2560")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("01/01/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("01/03/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("06/04/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("13/04/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("14/04/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("15/04/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("16/04/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("17/04/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("01/06/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("29/06/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("01/06/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("27/06/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("28/06/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("12/08/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("13/08/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("13/10/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("23/10/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("05/12/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("10/12/2561")).ToString() = "0" Then
                    num += 0
                ElseIf DateDiff(DateInterval.Day, t_date, CDate("31/12/2561")).ToString() = "0" Then
                    num += 0

                Else



                    If t_date.DayOfWeek = DayOfWeek.Monday Then
                        num += 0
                    ElseIf t_date.DayOfWeek = DayOfWeek.Tuesday Then
                        num += 0
                    Else
                        num += 1

                    End If
                End If
            Next



            Return num
        End Function




        'Public Sub TOTAL_DATE_FOOD(ByRef s_date As Date, ByVal process_id As String, ByVal SYSTEM_ID As String) 'As Date

        '    Dim t_date As Date
        '    Dim num As Integer = 0
        '    Dim LAG_TIME As Integer = 0
        '    Dim diff As String = String.Empty

        '    t_date = s_date
        '    num = chk_num(process_id, SYSTEM_ID, s_date)
        '    If chk_limit(process_id, SYSTEM_ID, s_date, num) = False Then
        '        t_date = s_date.AddDays(1)
        '        TOTAL_DATE_FOOD(t_date, process_id, SYSTEM_ID)

        '    End If
        'End Sub


    End Class


    Public Class WS_REQUEST_NO_BOOKING
        Private PROCESS_ID As String = "1007001"


        Public Function WS_INSERT_A_NO(ByVal r_no As String, ByVal ref_no As String, ByVal _appdate As Date) As String

            Dim no_return As String = ""
            If r_no = "" Then
                no_return = "Empty Data"
            Else
                Dim count_c As Integer = 0
                Dim dao_count_c As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                count_c = dao_count_c.Count_R(r_no)

                Dim count_r_c As Integer = 0
                Dim dao_count_r_c As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                count_r_c = dao_count_r_c.GetDataby_R_and_C(r_no)

                If count_c <= 1 Then
                    If count_r_c <= 1 Then
                        'Dim result As String = ""
                        'Dim ws2 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT
                        'result = ws2.CHECK_PAYMENT(txt_ref_no.Text, txt_company.Text, 1)
                        'If result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Or result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then

                        Dim dao_rc As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                        dao_rc.get_data_by_rno(r_no)
                        Dim i As Integer = 0
                        For Each dao_rc.fields In dao_rc.datas
                            i += 1
                        Next

                        Dim dao_req As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                        Try

                            dao_req.GetDataby_type(dao_rc.fields.TYPE_REQUEST)

                        Catch ex As Exception

                        End Try

                        Dim ws As New WS_GETDATE_WORKING.Service1
                        Dim DAO As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                        Dim bao As New BAO.GenNumber
                        Dim date_result As Date

                        Dim dao_WORK_GROUP As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
                        dao_WORK_GROUP.GetDataby_IDA(dao_req.fields.NEW_WORK_GROUP)

                        Dim dao_days As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                        dao_days.GetDataby_type(dao_rc.fields.TYPE_REQUEST)

                        Dim days As Integer = 0
                        Try
                            days = dao_days.fields.DAY_WORK
                        Catch ex As Exception

                        End Try
                        Try
                            ws.GETDATE_WORKING(CDate(_appdate), True, days, True, date_result, True)

                        Catch ex As Exception

                        End Try

                        '---------------------------------------------------
                        'If String.IsNullOrEmpty(_appdate) = False _
                        ' And String.IsNullOrEmpty(lbl_number_day.Text) = False And String.IsNullOrEmpty(txt_company.Text) = False _
                        ' And String.IsNullOrEmpty(lbl_company.Text) = False Then  'ใช้ฟังก์ชั่น เช๊คค่าว่างของ text ตัวนั้น


                        DAO.fields.STAFF_IDENTIFY = ""
                        DAO.fields.TYPE_REQUESTS = dao_rc.fields.TYPE_REQUEST
                        DAO.fields.TYPE_REQUESTS_NAME = dao_days.fields.TYPE_REQUESTS_NAME
                        DAO.fields.REQUESTS_DATE = CDate(_appdate)
                        DAO.fields.ALLOW_NAME = set_name_company(dao_rc.fields.CITIZEN_AUTHIRIZE)
                        DAO.fields.REQUESTS_AUTHORITIES = "" 'ชื่อจนท.ที่ออกเลข dao_WORK_GROUP.fields.WORK_GROUP
                        DAO.fields.RESPONSIBLE_AUTHORITIES = dao_WORK_GROUP.fields.WORK_GROUP
                        DAO.fields.CONREQ_CREATION_DATE = Date.Now
                        DAO.fields.CONREQ_LAST_UPDATE = date_result
                        DAO.fields.CONREQ_PDF_NAME = PROCESS_ID
                        DAO.fields.CONREQ_APPOINTMENT_DATE = date_result
                        DAO.fields.CONREQ_NUMBER_DAY = days

                        DAO.fields.REQUESTS_DATE_DISPLAY = CDate(_appdate).ToLongDateString()

                        DAO.fields.CITIZEN_ID_AUTHORIZE = dao_rc.fields.CITIZEN_AUTHIRIZE
                        Try
                            DAO.fields.CITIZEN_ID_REQUESTS = dao_rc.fields.CITIZEN_ID
                        Catch ex As Exception

                        End Try

                        DAO.fields.WORK_GROUP_NAME = dao_WORK_GROUP.fields.WORK_GROUP
                        DAO.fields.WORK_GROUP_ID = dao_WORK_GROUP.fields.IDA


                        DAO.fields.TXT_LCNNO = dao_rc.fields.LCNNO_DISPLAY
                        DAO.fields.SUB_TYPE_REQUESTS = ""

                        DAO.fields.DRUG_NAME_ENG = dao_rc.fields.TRADENAME_ENG
                        DAO.fields.DRUG_NAME_THAI = dao_rc.fields.TRADENAME
                        Try
                            DAO.fields.PVNCD = dao_rc.fields.PVNCD
                        Catch ex As Exception

                        End Try

                        DAO.fields.REF_NO = ""

                        DAO.fields.ACTIVE = "1"
                        DAO.insert()
                        Dim _ida As Integer = DAO.fields.IDA

                        DAO = New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                        DAO.GetDataby_IDA(_ida)
                        Dim RCVNO As String = ""
                        RCVNO = bao.GEN_NO_02_2(con_year(Date.Now.Year), dao_rc.fields.PVNCD, PROCESS_ID, "", "1", dao_rc.fields.TYPE_REQUEST, _ida, "")
                        DAO.fields.RCVNO = RCVNO
                        DAO.fields.RCVNO_DISPLAY = RCVNO & "-A"
                        Try
                            DAO.fields.REQUEST_CENTER_NO = r_no
                        Catch ex As Exception

                        End Try
                        Try
                            DAO.fields.FK_REQUEST_CENTER = dao_rc.fields.IDA
                        Catch ex As Exception

                        End Try
                        If r_no <> "" Then
                            Dim dao_r As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                            dao_r.get_data_by_rno(r_no)
                            DAO.fields.CITIZEN_AUTHIRIZE = dao_r.fields.CITIZEN_AUTHIRIZE
                            DAO.fields.CITIZEN_ID = dao_r.fields.CITIZEN_ID
                            DAO.fields.FK_LOCATION_IDA = dao_r.fields.FK_LOCATION_IDA
                        End If

                        DAO.update()

                        Dim result_c As String = ""
                        Dim ws_c As New WS_UPDATE_C.Service1
                        'Dim ws_c As New WS_UPDATE_C_DEMO.Service1
                        Try
                            result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(r_no)
                            'result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(txt_r_no.Text)
                        Catch ex As Exception

                        End Try


                        no_return = "Success"


                        'Else
                        '    alertERROR("ไม่สามารถบันทึกข้อมูล กรุณาตรวจสอบข้อมูล")
                        'End If
                        '---------------------------------
                        'Else
                        '    alertERROR(result)
                        'End If


                    Else
                        no_return = "Duplicate"
                    End If

                Else
                    no_return = "R Duplicate"
                End If

            End If
            Return no_return
        End Function

        Public Function WS_INSERT_C_NO(ByVal r_no As String, ByVal ref_no As String) As String
            Dim bool As Boolean = chk_r_exist(r_no)
            Dim no_return As String = ""
            If bool = True Then
                Dim dao_fk As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                dao_fk.get_data_by_rno(r_no)
                Dim FK_IDA As Integer = 0
                Try
                    FK_IDA = dao_fk.fields.IDA
                Catch ex As Exception

                End Try

                Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                dao.GetDataby_IDA(FK_IDA)
                Dim dao_in As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                dao_in.fields.CITIZEN_AUTHIRIZE = dao.fields.CITIZEN_AUTHIRIZE
                dao_in.fields.CITIZEN_ID = dao.fields.CITIZEN_ID
                Try
                    dao_in.fields.CITIZEN_UPLOAD = dao.fields.CITIZEN_UPLOAD
                Catch ex As Exception

                End Try

                Try
                    dao_in.fields.FK_LOCATION_IDA = dao.fields.FK_LOCATION_IDA
                Catch ex As Exception
                    dao_in.fields.FK_LOCATION_IDA = 0
                End Try
                Try
                    dao_in.fields.FK_PRODUCT_IDA = dao.fields.FK_PRODUCT_IDA
                Catch ex As Exception

                End Try
                Try
                    dao_in.fields.LCN_IDA = dao.fields.LCN_IDA
                Catch ex As Exception

                End Try

                Try
                    dao_in.fields.PLACENAME = dao.fields.PLACENAME
                Catch ex As Exception

                End Try
                Try
                    dao_in.fields.PVNCD = dao.fields.PVNCD
                Catch ex As Exception

                End Try
                Try
                    dao_in.fields.REQUEST_DATE = Date.Now
                Catch ex As Exception

                End Try
                Try
                    dao_in.fields.fulladdr = dao.fields.fulladdr
                Catch ex As Exception

                End Try
                dao_in.fields.TRADENAME = dao.fields.TRADENAME
                dao_in.fields.TRADENAME_ENG = dao.fields.TRADENAME_ENG
                dao_in.fields.TYPE_REQUEST = dao.fields.TYPE_REQUEST
                dao_in.fields.TYPE_REQUEST_NAME = dao.fields.TYPE_REQUEST_NAME
                dao_in.fields.WORK_GROUP = dao.fields.WORK_GROUP
                dao_in.fields.ALLOW_NAME = dao.fields.ALLOW_NAME
                dao_in.fields.LCNNO_DISPLAY = dao.fields.LCNNO_DISPLAY
                dao_in.fields.PRODUCT_ID = dao.fields.PRODUCT_ID

                dao_in.fields.OTHER_DETAIL = dao.fields.OTHER_DETAIL
                dao_in.fields.TABEAN_DISPLAY = dao.fields.TABEAN_DISPLAY
                dao_in.fields.ACTIVE = "1"
                dao_in.fields.REF_NO = ref_no
                dao_in.insert()
                Dim ida As Integer = 0
                Try
                    ida = dao_in.fields.IDA
                Catch ex As Exception

                End Try

                dao = New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                dao.GetDataby_IDA(ida)
                Dim bao As New BAO.GenNumber
                Dim rcvno As String = ""
                Dim rcvno_display As String = ""
                Dim pvncd As Integer = 0
                Try
                    pvncd = dao_fk.fields.PVNCD
                Catch ex As Exception

                End Try
                rcvno = bao.GEN_RCVNO_REQUEST(con_year(Date.Now.Year), pvncd, "2", dao_fk.fields.LCNNO_DISPLAY, "", dao_fk.fields.TYPE_REQUEST, ida, dao_fk.fields.TYPE_REQUEST_NAME)

                dao.fields.RCVNO = rcvno
                dao.fields.RCVNO_DISPLAY = rcvno & "-C"
                dao.fields.REQUEST_CENTER_TYPE = 2
                no_return = rcvno & "-C"
                Try
                    dao.fields.HEAD_IDA = FK_IDA
                Catch ex As Exception

                End Try
                dao.update()

            Else
                no_return = "Not Found"
            End If
            Return no_return
        End Function
        Public Function WS_INSERT_R_NO(ByVal process_no As String, ByVal CITIZEN_AUTHIRIZE As String, ByVal CITIZEN_ID As String, ByVal nameplace As String,
                        ByVal addr As String, ByVal pvncd As Integer, ByVal ref_no As String) As String
            'Dim bool As Boolean = chk_r_exist(r_no)
            Dim no_return As String = ""
            If process_no = "" Then
                no_return = "Not Found"
            Else
                Dim dao_re1 As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                dao_re1.GetDataby_CD(process_no)

                Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                set_data(dao, CITIZEN_AUTHIRIZE, CITIZEN_ID, nameplace, addr, pvncd)
                dao.fields.TYPE_REQUEST = process_no
                dao.fields.REF_NO = ref_no
                dao.fields.ACTIVE = "1"
                dao.fields.WORK_GROUP = dao_re1.fields.NEW_WORK_GROUP
                dao.insert()
                Dim ida As Integer = 0
                Try
                    ida = dao.fields.IDA
                Catch ex As Exception

                End Try

                dao = New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                dao.GetDataby_IDA(ida)
                Dim bao As New BAO.GenNumber
                Dim rcvno As String = ""
                Dim rcvno_display As String = ""
                Dim dao_re As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                dao_re.GetDataby_CD(process_no)
                Dim type_req As String = ""
                Try
                    type_req = dao_re.fields.TYPE_REQUESTS_NAME
                Catch ex As Exception

                End Try
                rcvno = bao.GEN_RCVNO_REQUEST(con_year(Date.Now.Year), pvncd, "1", "", "", process_no, ida, type_req)
                dao.fields.RCVNO = rcvno
                dao.fields.RCVNO_DISPLAY = rcvno & "-R"
                dao.fields.REQUEST_CENTER_TYPE = 1
                no_return = rcvno & "-R"
                dao.update()
            End If
            Return no_return
        End Function
        Public Function WS_UPDATE_STAFF(ByVal rc_no As String, ByVal identify As String) As String
            Dim result As String = ""
            Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            If dao.fields.IDA <> 0 Then
                If identify = "" Then
                    result = "Not Found"
                Else
                    dao.get_data_by_rno(rc_no)

                    dao.fields.STAFF_IDENTIFY = identify
                    dao.update()
                    result = "Success"
                End If

            Else
                result = "Not Found"
            End If
            Return result
        End Function
        Public Sub set_data(ByRef dao As DAO_DRUG.TB_DRUG_REQUEST_CENTER, ByVal CITIZEN_AUTHIRIZE As String, ByVal CITIZEN_ID As String, ByVal nameplace As String,
                            ByVal addr As String, ByVal pvncd As Integer)
            dao.fields.CITIZEN_AUTHIRIZE = CITIZEN_AUTHIRIZE
            dao.fields.CITIZEN_ID = CITIZEN_ID
            dao.fields.CITIZEN_UPLOAD = CITIZEN_ID
            dao.fields.FK_LOCATION_IDA = 0
            dao.fields.FK_PRODUCT_IDA = 0
            dao.fields.LCN_IDA = 0
            dao.fields.PVNCD = pvncd
            dao.fields.PLACENAME = nameplace

            dao.fields.fulladdr = addr
            Try
                dao.fields.REQUEST_DATE = Date.Now
            Catch ex As Exception

            End Try
        End Sub

        Private Sub set_data(ByVal FK_IDA As Integer)
            Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao.GetDataby_IDA(FK_IDA)
            Dim dao_in As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao_in.fields.CITIZEN_AUTHIRIZE = dao.fields.CITIZEN_AUTHIRIZE
            dao_in.fields.CITIZEN_ID = dao.fields.CITIZEN_ID
            Try
                dao_in.fields.CITIZEN_UPLOAD = dao.fields.CITIZEN_UPLOAD
            Catch ex As Exception

            End Try

            Try
                dao_in.fields.FK_LOCATION_IDA = dao.fields.FK_LOCATION_IDA
            Catch ex As Exception
                dao_in.fields.FK_LOCATION_IDA = 0
            End Try
            Try
                dao_in.fields.FK_PRODUCT_IDA = dao.fields.FK_PRODUCT_IDA
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.LCN_IDA = dao.fields.LCN_IDA
            Catch ex As Exception

            End Try

            Try
                dao_in.fields.PLACENAME = dao.fields.PLACENAME
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.PVNCD = dao.fields.PVNCD
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.REQUEST_DATE = Date.Now
            Catch ex As Exception

            End Try

            dao_in.fields.TRADENAME = dao.fields.TRADENAME
            dao_in.fields.TRADENAME_ENG = dao.fields.TRADENAME_ENG
            dao_in.fields.TYPE_REQUEST = dao.fields.TYPE_REQUEST
            dao_in.fields.TYPE_REQUEST_NAME = dao.fields.TYPE_REQUEST_NAME
            dao_in.fields.WORK_GROUP = dao.fields.WORK_GROUP
            dao_in.fields.ALLOW_NAME = dao.fields.ALLOW_NAME
            dao_in.fields.LCNNO_DISPLAY = dao.fields.LCNNO_DISPLAY
            dao_in.fields.PRODUCT_ID = dao.fields.PRODUCT_ID

            dao_in.fields.OTHER_DETAIL = dao.fields.OTHER_DETAIL
            dao_in.fields.TABEAN_DISPLAY = dao.fields.TABEAN_DISPLAY
        End Sub
        Private Function chk_r_exist(ByVal r_no As String) As Boolean
            Dim bool As Boolean = False
            Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao.get_data_by_rno(r_no)
            Dim i As Integer = 0
            For Each dao.fields In dao.datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Private Function set_name_company(ByVal identify As String) As String
            Dim fullname As String = String.Empty
            Try
                'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
                'dao_syslcnsid.GetDataby_identify(identify)

                'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
                'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

                Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

                Dim ws_taxno = ws2.getProfile_byidentify(identify)

                fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


            Catch ex As Exception
                fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
            End Try

            Return fullname
        End Function

        ''Queryds

    End Class
    'Public Function SP_DL_DATA_NOW_TO_START() As DataTable
    '    Dim clsds As New ClassDataset
    '    Dim sql As String = "exec SP_DL_DATA_NOW_TO_START"
    '    Dim dt As New DataTable
    '    dt = clsds.dsQueryselect(sql, conn)
    '    Return dt
    'End Function

End Namespace