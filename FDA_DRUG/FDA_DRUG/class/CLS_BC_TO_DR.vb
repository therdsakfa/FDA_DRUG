Public Class CLS_BC_TO_DR
    Public Sub UPDATE_DR(ByVal NEWCODE As String, ByVal citizen_authorize As String)

        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN

        Dim xml_iow As New LGT_IOW_E
        Dim xml_str As String

        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(NEWCODE)
        If xml_str <> "FAIL" Then
            'MODEL.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            Try
                xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            Catch ex As Exception
                Dim ws_xml As New WS_CREATE_XML.WS_INSERT_XML_DRUG
                ws_xml.XML_DRUG_FORMULA(NEWCODE, citizen_authorize)
                xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(NEWCODE)
                xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            End Try

        Else
            Dim ws_xml As New WS_CREATE_XML.WS_INSERT_XML_DRUG
            ws_xml.XML_DRUG_FORMULA(NEWCODE, citizen_authorize)
            xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(NEWCODE)
            xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
        End If

        Dim dao_dr_esub As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        dao_dr_esub.GetDataby_u1(NEWCODE)
        Dim IDA_drrgt As Integer = Trim(dao_dr_esub.fields.IDA_drrgt)
        If IDA_drrgt <> 0 Then
            '------------ข้อมูลทั่วไป
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(IDA_drrgt)
            'Dim xml_iow As New LGT_IOW_E
            With dao_rg.fields
                Try
                    .lmdfdate = Date.Now
                Catch ex As Exception

                End Try
                Try
                    .appdate = xml_iow.XML_SEARCH_DRUG_DR.appdate
                Catch ex As Exception

                End Try
                Try
                    Dim engclassnm As String = ""
                    Dim thaclassnm As String = ""
                    engclassnm = xml_iow.XML_SEARCH_DRUG_DR.engclassnm
                    thaclassnm = xml_iow.XML_SEARCH_DRUG_DR.thaclassnm
                    Dim dao_class As New DAO_DRUG.TB_drclass
                    dao_class.GetDataBytha(thaclassnm)
                    Dim dao_class2 As New DAO_DRUG.TB_drclass
                    dao_class2.GetDataByeng(engclassnm)
                    If engclassnm = "-" And thaclassnm = "-" Then
                        .classcd = dao_class.fields.classcd
                    End If
                    If Len(dao_class.fields.thaclassnm) > 1 Then
                        .classcd = dao_class.fields.classcd
                    End If
                    If Len(dao_class2.fields.thaclassnm) > 1 Then
                        .classcd = dao_class2.fields.classcd
                    End If
                Catch ex As Exception

                End Try

                Try
                    Dim dao_drk As New DAO_DRUG.TB_drkdofdrg
                    dao_drk.GetData_by_thakindnm(xml_iow.XML_SEARCH_DRUG_DR.thakindnm)
                    .kindcd = dao_drk.fields.kindcd
                Catch ex As Exception

                End Try

                Try
                    .pvnabbr = xml_iow.XML_SEARCH_DRUG_DR.pvnabbr
                Catch ex As Exception

                End Try
                Try
                    .pvncd = xml_iow.XML_SEARCH_DRUG_DR.pvncd
                Catch ex As Exception

                End Try
                Try
                    .lpvncd = xml_iow.XML_SEARCH_DRUG_DR.lpvncd
                Catch ex As Exception

                End Try
                Try
                    .lcnno = xml_iow.XML_SEARCH_DRUG_DR.lcnno
                Catch ex As Exception

                End Try
                Try
                    .lcntpcd = xml_iow.XML_SEARCH_DRUG_DR.lcntpcd
                Catch ex As Exception

                End Try
                Try
                    .lcnsid = xml_iow.XML_SEARCH_DRUG_DR.lcnsid
                Catch ex As Exception

                End Try
                Try
                    .IDENTIFY = xml_iow.XML_SEARCH_DRUG_DR.Identify
                Catch ex As Exception

                End Try
                Try
                    .dsgcd = xml_iow.XML_SEARCH_DRUG_DR.dsgcd
                Catch ex As Exception

                End Try
                Try
                    .ctgcd = xml_iow.XML_SEARCH_DRUG_DR.ctgcd
                Catch ex As Exception

                End Try
                Try
                    .expdate = CDate(xml_iow.XML_SEARCH_DRUG_DR.expdate)
                Catch ex As Exception

                End Try
                Try
                    If Len(Trim(xml_iow.XML_SEARCH_DRUG_DR.cnccd)) > 0 Then
                        .cnccd = xml_iow.XML_SEARCH_DRUG_DR.cnccd
                        .cnccscd = xml_iow.XML_SEARCH_DRUG_DR.cncdcd
                        .cncdate = xml_iow.XML_SEARCH_DRUG_DR.cncdate
                    End If
                Catch ex As Exception

                End Try
                Try
                    .rcvdate = CDate(xml_iow.XML_SEARCH_DRUG_DR.rcvdate)
                Catch ex As Exception

                End Try
                Try
                    .rcvno = xml_iow.XML_SEARCH_DRUG_DR.rcvno
                Catch ex As Exception

                End Try

            End With
            dao_rg.update()

            Dim dao_addr As New DAO_DRUG.TB_DRRGT_ADDR
            Try
                dao_addr.Getdata_by_FK_IDA(IDA_drrgt)
            Catch ex As Exception

            End Try

            Try
                If dao_addr.fields.IDA <> 0 Then
                    With dao_addr.fields
                        Try
                            .amphrnm = xml_iow.XML_SEARCH_DRUG_DR.thaamphrnm_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .chngwtnm = xml_iow.XML_SEARCH_DRUG_DR.thachngwtnm_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .thmblnm = xml_iow.XML_SEARCH_DRUG_DR.thathmblnm_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .thaaddr = xml_iow.XML_SEARCH_DRUG_DR.thaaddr_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .room = xml_iow.XML_SEARCH_DRUG_DR.tharoom_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .thanm = xml_iow.XML_SEARCH_DRUG_DR.thanm_locaion
                        Catch ex As Exception

                        End Try
                        Try
                            .Fulladdr = xml_iow.XML_SEARCH_DRUG_DR.fulladdr
                        Catch ex As Exception

                        End Try
                        Try
                            .identify = xml_iow.XML_SEARCH_DRUG_DR.Identify
                        Catch ex As Exception

                        End Try
                        Try
                            .zipcode = xml_iow.XML_SEARCH_DRUG_DR.zipcode_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .mu = xml_iow.XML_SEARCH_DRUG_DR.thamu_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .tharoad = xml_iow.XML_SEARCH_DRUG_DR.tharoad_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .thasoi = xml_iow.XML_SEARCH_DRUG_DR.thasoi_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .tel = xml_iow.XML_SEARCH_DRUG_DR.tel_thanm
                        Catch ex As Exception

                        End Try
                        Try
                            .building = xml_iow.XML_SEARCH_DRUG_DR.thabuilding_thanm
                        Catch ex As Exception

                        End Try

                    End With
                    dao_addr.update()
                Else
                    dao_addr = New DAO_DRUG.TB_DRRGT_ADDR
                    With dao_addr.fields
                            Try
                                .amphrnm = xml_iow.XML_SEARCH_DRUG_DR.thaamphrnm_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .chngwtnm = xml_iow.XML_SEARCH_DRUG_DR.thachngwtnm_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .thmblnm = xml_iow.XML_SEARCH_DRUG_DR.thathmblnm_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .thaaddr = xml_iow.XML_SEARCH_DRUG_DR.thaaddr_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .room = xml_iow.XML_SEARCH_DRUG_DR.tharoom_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .thanm = xml_iow.XML_SEARCH_DRUG_DR.thanm_locaion
                            Catch ex As Exception

                            End Try
                            Try
                                .Fulladdr = xml_iow.XML_SEARCH_DRUG_DR.fulladdr
                            Catch ex As Exception

                            End Try
                            Try
                                .identify = xml_iow.XML_SEARCH_DRUG_DR.Identify
                            Catch ex As Exception

                            End Try
                            Try
                                .zipcode = xml_iow.XML_SEARCH_DRUG_DR.zipcode_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .mu = xml_iow.XML_SEARCH_DRUG_DR.thamu_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .tharoad = xml_iow.XML_SEARCH_DRUG_DR.tharoad_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .thasoi = xml_iow.XML_SEARCH_DRUG_DR.thasoi_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .tel = xml_iow.XML_SEARCH_DRUG_DR.tel_thanm
                            Catch ex As Exception

                            End Try
                            Try
                                .building = xml_iow.XML_SEARCH_DRUG_DR.thabuilding_thanm
                            Catch ex As Exception

                            End Try


                            .FK_IDA = IDA_drrgt
                        End With
                        dao_addr.insert()
                End If
            Catch ex As Exception

            End Try

            '---------------frgn
            Try
                Dim dao_XML_DRUG_FRGN As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_FRGN
                dao_XML_DRUG_FRGN.GetDataby_u1(NEWCODE)
                If dao_XML_DRUG_FRGN.fields.engcntnm = "ไทย" Then
                    Dim dao_product_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                    dao_product_in.GetDataby_FK_IDA(IDA_drrgt)
                    For Each dao_product_in.fields In dao_product_in.datas
                        dao_product_in.delete()
                    Next
                    For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
                        Dim dao_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                        With dao_in.fields
                            .FK_IDA = IDA_drrgt
                            Try
                                Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                                dao_dal.GetDataby_pvncd_lcnno_lcntpcd(dao_XML_DRUG_FRGN.fields.pvncd, dao_XML_DRUG_FRGN.fields.lcnno, xml_iow.XML_SEARCH_DRUG_DR.lcntpcd)
                                .FK_LCN_IDA = dao_dal.fields.IDA
                            Catch ex As Exception

                            End Try
                            .funccd = dao_XML_DRUG_FRGN.fields.funccd
                            dao_in.insert()
                        End With
                    Next
                Else
                    Dim dao_product As New DAO_DRUG.TB_DRRGT_PRODUCER
                    dao_product.GetDataby_FK_IDA(IDA_drrgt)
                    For Each dao_product.fields In dao_product.datas
                        dao_product.delete()
                    Next
                    For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
                        Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
                        With dao_pro.fields
                            .FK_IDA = IDA_drrgt
                            .PRODUCER_WORK_TYPE = dao_XML_DRUG_FRGN.fields.funccd
                            .funccd = dao_XML_DRUG_FRGN.fields.funccd
                            Dim frgncd As Integer = 0
                            Dim FK_PRODUCER As Integer = 0
                            Dim addr_ida As Integer = 0
                            Dim frgnlctcd As Integer = 0
                            Dim dao_frgn_name As New DAO_DRUG.ClsDBsyspdcfrgn
                            dao_frgn_name.GetData_by_engfrgnnm(dao_XML_DRUG_FRGN.fields.engfrgnnm)
                            For Each dao_frgn_name.fields In dao_frgn_name.datas
                                Dim icc As Integer = 0
                                Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
                                dao_iso.GetData_engcntnm(dao_XML_DRUG_FRGN.fields.engcntnm)
                                Dim dao_frgn_addr As New DAO_DRUG.ClsDBdrfrgnaddr
                                dao_frgn_addr.GetDataAll_v2(dao_XML_DRUG_FRGN.fields.addr, dao_iso.fields.alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.fax, dao_XML_DRUG_FRGN.fields.mu, _
                                                            dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.road, dao_XML_DRUG_FRGN.fields.soi, dao_XML_DRUG_FRGN.fields.subdiv, dao_XML_DRUG_FRGN.fields.tel, _
                                                            dao_XML_DRUG_FRGN.fields.zipcode, dao_frgn_name.fields.frgncd)
                                For Each dao_frgn_addr.fields In dao_frgn_addr.datas
                                    addr_ida = dao_frgn_addr.fields.IDA
                                    frgnlctcd = dao_frgn_addr.fields.frgnlctcd
                                    frgncd = dao_frgn_addr.fields.frgnlctcd

                                Next
                                FK_PRODUCER = dao_frgn_name.fields.IDA
                            Next

                            .frgncd = dao_frgn_name.fields.frgncd
                            .addr_ida = addr_ida
                            .FK_PRODUCER = FK_PRODUCER
                            .frgnlctcd = frgnlctcd
                        End With
                        dao_pro.insert()
                    Next


                End If

            Catch ex As Exception

            End Try

            Dim rgttpcd As String = ""
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
            '-------------ยาสัตว์
            If rgttpcd = "1D" Or rgttpcd = "1E" Or rgttpcd = "1F" Or rgttpcd = "2D" Or rgttpcd = "2E" Or rgttpcd = "2F" _
                Or rgttpcd = "L" Or rgttpcd = "M" Or rgttpcd = "N" Then

                Dim U_ANIMAL_DRUGS_TO As New LGT_ANIMAL_DRUGS_TO 'LGT_RECIPE_GROUP_TO
                Dim c_anih As Integer = 0
                Dim dao_anih As New DAO_DRUG.ClsDBdramldrg
                c_anih = dao_anih.CountData_by_FK_IDA(IDA_drrgt)
                Dim dao_anih2 As New DAO_DRUG.ClsDBdramldrg
                dao_anih2.GetData_by_FK_IDA(IDA_drrgt)
                For Each U_ANIMAL_DRUGS_TO In xml_iow.LGT_ANIMAL_DRUGS_TO
                    c_anih += 1
                Next
                If c_anih <> 0 Then
                    Dim dao_anih_del As New DAO_DRUG.ClsDBdramldrg
                    dao_anih_del.GetData_by_FK_IDA(IDA_drrgt)
                    For Each dao_anih_del.fields In dao_anih_del.datas
                        dao_anih_del.delete()
                    Next
                    For Each U_ANIMAL_DRUGS_TO In xml_iow.LGT_ANIMAL_DRUGS_TO
                        Dim dao_anih_ins As New DAO_DRUG.ClsDBdramldrg
                        With dao_anih_ins.fields
                            Try
                                Dim dao_amlsub As New DAO_DRUG.TB_dramlsubtp
                                dao_amlsub.GetDataby_amlsubnm(U_ANIMAL_DRUGS_TO.XML_DRUG_ANIMAL.amlsubnm)
                                .amlsubcd = dao_amlsub.fields.amlsubcd
                            Catch ex As Exception

                            End Try

                            Try
                                Dim dao_amlt As New DAO_DRUG.TB_dramltype
                                dao_amlt.GetDataby_amltpnm(U_ANIMAL_DRUGS_TO.XML_DRUG_ANIMAL.amltpnm)
                                .amltpcd = dao_amlt.fields.amltpcd
                            Catch ex As Exception

                            End Try
                            Try
                                .drgtpcd = dao_rg.fields.drgtpcd
                            Catch ex As Exception

                            End Try
                            Try
                                .pvncd = dao_rg.fields.pvncd
                            Catch ex As Exception

                            End Try
                            Try
                                .rgtno = dao_rg.fields.rgtno
                            Catch ex As Exception

                            End Try
                            Try
                                .rgttpcd = dao_rg.fields.rgttpcd
                            Catch ex As Exception

                            End Try
                            Try
                                Dim dao_uset As New DAO_DRUG.TB_dramlusetp
                                dao_uset.GetDataby_usetpnm(U_ANIMAL_DRUGS_TO.XML_DRUG_ANIMAL.usetpnm)
                                .usetpcd = dao_uset.fields.usetpcd
                            Catch ex As Exception

                            End Try
                            .FK_IDA = IDA_drrgt
                        End With
                        dao_anih_ins.insert()
                        Dim IDA_anih As Integer = dao_anih_ins.fields.IDA


                    Next
                End If


            End If

            Dim U_ANIMAL_CONSUME As New LGT_ANIMAL_CONSUME_DRUGS_TO
            Dim c_ani_s As Integer = 0
            Dim dao_ani_s As New DAO_DRUG.ClsDBdramluse
            c_ani_s = dao_ani_s.CountDataby_FK_IDA(IDA_drrgt)
            If c_ani_s <> 0 Then
                dao_ani_s = New DAO_DRUG.ClsDBdramluse
                For Each dao_ani_s.fields In dao_ani_s.datas
                    dao_ani_s.delete()
                Next

                For i As Integer = 0 To xml_iow.LGT_ANIMAL_DRUGS_TO.Count - 1
                    For ii As Integer = 0 To xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Count - 1
                        Dim dao_ani_ins As New DAO_DRUG.ClsDBdramluse
                        With dao_ani_ins.fields
                            Try
                                Dim dao_amlsub As New DAO_DRUG.TB_dramlsubtp
                                dao_amlsub.GetDataby_amlsubnm(xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.amlsubnm)
                                .amlsubcd = dao_amlsub.fields.amlsubcd
                            Catch ex As Exception

                            End Try
                            Try
                                Dim dao_amlt As New DAO_DRUG.TB_dramltype
                                dao_amlt.GetDataby_amltpnm(xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.amltpnm)
                                .amltpcd = ""
                            Catch ex As Exception

                            End Try
                            Try
                                Dim dao_amlpt As New DAO_DRUG.TB_dramlpart
                                dao_amlpt.GetDataby_ampartnm(xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.ampartnm)
                                .ampartcd = dao_amlpt.fields.ampartcd
                            Catch ex As Exception

                            End Try
                            Try
                                .drgtpcd = dao_rg.fields.drgtpcd
                            Catch ex As Exception

                            End Try
                            Try
                                .FK_IDA = IDA_drrgt
                            Catch ex As Exception

                            End Try
                            Try
                                .nouse = xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.nouse
                            Catch ex As Exception

                            End Try
                            Try
                                .packuse = xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.packuse
                            Catch ex As Exception

                            End Try
                            Try
                                .pvncd = xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.pvncd
                            Catch ex As Exception

                            End Try
                            Try
                                .rgtno = xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.rgtno
                            Catch ex As Exception

                            End Try
                            Try
                                .rgttpcd = xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.rgttpcd
                            Catch ex As Exception

                            End Try
                            Try
                                .stpdrg = xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.stpdrg
                            Catch ex As Exception

                            End Try
                            Try
                                Dim dao_amluse As New DAO_DRUG.TB_dramlusetp
                                dao_amluse.GetDataby_usetpnm(xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.usetpnm)
                                .usetpcd = dao_amluse.fields.usetpcd
                            Catch ex As Exception

                            End Try
                        End With
                        dao_ani_ins.insert()
                    Next
                Next
            End If

            '---------จบยาสัตว์
            '------------จบ ข้อมูลทั่วไป
            '------------------------------------------เก็บยา
            Dim U_LGT_XML_STOWAGR_TO As New LGT_XML_STOWAGR_TO 'LGT_RECIPE_GROUP_TO
            Dim c_keep As Integer = 0
            Dim c_keep_bc As Integer = 0
            Dim dao_keep As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            c_keep = dao_keep.COUNTDataby_FKIDA(IDA_drrgt)
            Dim dao_keep2 As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            dao_keep2.GetDataby_FKIDA(IDA_drrgt)
            For Each U_LGT_XML_STOWAGR_TO In xml_iow.LGT_XML_STOWAGR_TO
                c_keep_bc += 1
            Next
            'If c_keep = 0 Then
            '    For Each U_LGT_XML_STOWAGR_TO In xml_iow.LGT_XML_STOWAGR_TO
            '        Dim dao_keep_ins As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            '        With dao_keep_ins.fields
            '            .AGE_DAY = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.drug_age_days  'aa.XML_STOWAGR.keepdesc
            '            '.AGE_HOUR = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.
            '            .AGE_MONTH = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.drug_age_month
            '            .DRUG_DETAIL = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.drgchrtha
            '            .KEEP_DESCRIPTION = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.keepdesc
            '            .ROWS = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.rid
            '            .TEMPERATE1 = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.tplow
            '            .TEMPERATE2 = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.tphigh
            '            .FK_IDA = IDA_drrgt
            '        End With
            '        dao_keep_ins.insert()
            '    Next
            'ElseIf c_keep = c_keep_bc Then
            If c_keep_bc <> 0 Then
                Dim dao_keep_del As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
                dao_keep_del.GetDataby_FKIDA(IDA_drrgt)
                For Each dao_keep_del.fields In dao_keep_del.datas
                    Dim dao_keep_del1 As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
                    dao_keep_del1.GetDataby_IDA(dao_keep_del.fields.IDA)
                    dao_keep_del1.delete()
                Next
                For Each U_LGT_XML_STOWAGR_TO In xml_iow.LGT_XML_STOWAGR_TO
                    Dim dao_keep_up As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
                    With dao_keep_up.fields
                        Try
                            .AGE_DAY = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.drug_age_days  'aa.XML_STOWAGR.keepdesc
                        Catch ex As Exception

                        End Try
                        Try
                            .AGE_MONTH = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.drug_age_month
                        Catch ex As Exception

                        End Try
                        '.AGE_HOUR = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.
                        Try
                            .DRUG_DETAIL = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.drgchrtha
                        Catch ex As Exception

                        End Try
                        Try
                            .KEEP_DESCRIPTION = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.keepdesc
                        Catch ex As Exception

                        End Try
                        Try
                            .ROWS = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.rid
                        Catch ex As Exception

                        End Try
                        Try
                            .TEMPERATE1 = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.tplow
                        Catch ex As Exception

                        End Try
                        Try
                            .TEMPERATE2 = U_LGT_XML_STOWAGR_TO.XML_DRUG_STOWAGR.tphigh
                        Catch ex As Exception

                        End Try

                        .FK_IDA = IDA_drrgt
                    End With
                    dao_keep_up.insert()
                Next
            End If
            ' End If
            '------------------------------------------จบ เก็บยา



            '--------------------------สาร
            Dim U_LGT_IOW_EQ As New LGT_IOW_EQ 'LGT_RECIPE_GROUP_TO
            Dim c_iowa As Integer = 0
            Dim c_iowa_bc As Integer = 0
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            c_iowa = dao_cas.COUNTDataby_FKIDA(IDA_drrgt)
            Dim dao_cas2 As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas2.GetDataby_FKIDA(IDA_drrgt)
            For ios As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Count - 1
                For ii As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(ios).XML_DRUG_IOW_TO.Count - 1
                    c_iowa_bc += 1
                Next
            Next
            If c_iowa_bc > 0 Then
                Dim dao_cas_del As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                dao_cas_del.GetDataby_FKIDA(IDA_drrgt)
                For Each dao_cas_del.fields In dao_cas_del.datas
                    Dim dao_cas_del2 As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                    dao_cas_del2.GetDataby_IDA(dao_cas_del.fields.IDA)
                    dao_cas_del2.delete()
                Next

                Dim dao_eq_del As New DAO_DRUG.TB_DRRGT_EQTO
                dao_eq_del.GetDataby_FK_DRRQT_IDA(IDA_drrgt)
                For Each dao_eq_del.fields In dao_eq_del.datas
                    Dim dao_eq_del2 As New DAO_DRUG.TB_DRRGT_EQTO
                    dao_eq_del2.GetDataby_IDA(dao_eq_del.fields.IDA)
                    dao_eq_del2.delete()
                Next

                'If c_keep = 0 Then
                For i As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Count - 1
                    For ii As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Count - 1
                        Dim dao_cas_ins As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                        With dao_cas_ins.fields
                            .AORI = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.aori
                            .BASE_FORM = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.qtytxt
                            .CONDITION = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.ConditionContent
                            .FK_IDA = IDA_drrgt
                            .FK_SET = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.flineno
                            .IOWA = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.iowacd
                            .IOWANM = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.iowanm
                            .mltplr = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.MultiplyNumberStart
                            .QTY = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.qty
                            .QTY_txt = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.qtytxt_all
                            .REMARK = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.remark
                            .ROWS = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.rid
                            Try
                                Dim dao_unit As New DAO_DRUG.TB_drsunit
                                dao_unit.GetDataby_sunitengnm(xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.sunitengnm)
                                .SUNITCD = dao_unit.fields.sunitcd
                            Catch ex As Exception

                            End Try
                        End With
                        dao_cas_ins.insert()
                        For ii3 As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Count - 1
                            Dim dao_eqto As New DAO_DRUG.TB_DRRGT_EQTO
                            With dao_eqto.fields
                                .aori = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.aori
                                .CONDITION = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.ConditionContent
                                .FK_DRRQT_IDA = IDA_drrgt
                                .FK_IDA = dao_cas_ins.fields.IDA
                                .FK_SET = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.flineno
                                .IOWA = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.iowacd
                                .MULTIPLY = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.MultiplyNumberStart
                                .QTY = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.qty
                                .ROWS = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.rid
                                'Try
                                '    Dim dao_unit As New DAO_DRUG.TB_drsunit
                                '    dao_unit.GetDataby_sunitengnm(xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.)
                                '    .SUNITCD = dao_unit.fields.sunitcd
                                'Catch ex As Exception

                                'End Try
                            End With
                            dao_eqto.insert()
                        Next


                    Next

                Next
            End If

            'Else

            'End If

            '--------------------------จบสาร
            '--------------------------ATC เริ่ม
            Dim BC_LGT_RECIPE_GROUP_TO As New LGT_RECIPE_GROUP_TO
            Dim C_LGT_RECIPE_GROUP_TO As Integer = 0
            Dim atc_cd As String = ""
            For Each BC_LGT_RECIPE_GROUP_TO In xml_iow.LGT_RECIPE_GROUP_TO
                C_LGT_RECIPE_GROUP_TO += 1
                atc_cd = BC_LGT_RECIPE_GROUP_TO.XML_DRUG_RECIPE_GROUP.atccd
            Next
            If C_LGT_RECIPE_GROUP_TO > 0 Then
                If Len(atc_cd) > 1 Then
                    Dim dao_rg_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                    dao_rg_atc.GetDataby_FKIDA(IDA_drrgt)
                    For Each dao_rg_atc.fields In dao_rg_atc.datas
                        Dim dao_rg_atc2 As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                        dao_rg_atc2.GetDataby_IDA(dao_rg_atc.fields.IDA)
                        dao_rg_atc2.delete()
                    Next

                    For Each BC_LGT_RECIPE_GROUP_TO In xml_iow.LGT_RECIPE_GROUP_TO
                        Dim dao_rg_atc_ins As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                        With dao_rg_atc_ins.fields
                            .ATC_CODE = BC_LGT_RECIPE_GROUP_TO.XML_DRUG_RECIPE_GROUP.atccd
                            .FK_IDA = IDA_drrgt
                            Try
                                Dim dao_mas_atc As New DAO_DRUG.TB_ATC_DRUG
                                dao_mas_atc.GetDataby_ATCCD(Trim(BC_LGT_RECIPE_GROUP_TO.XML_DRUG_RECIPE_GROUP.atccd))
                                .ATC_IDA = dao_mas_atc.fields.IDA
                            Catch ex As Exception

                            End Try

                        End With
                        dao_rg_atc_ins.insert()
                    Next
                End If

            End If

            '--------------------------ATC จบ
            '-----------------------ผู้แทนจำหน่าย
            Dim BC_LGT_XML_DRUG_AGENT As New LGT_XML_DRUG_AGENT
            Dim C_LGT_XML_DRUG_AGENT As Integer = 0
            Dim AGENT_IDA As Integer = 0
            For Each BC_LGT_XML_DRUG_AGENT In xml_iow.LGT_XML_DRUG_AGENT
                C_LGT_XML_DRUG_AGENT += 1
                AGENT_IDA = BC_LGT_XML_DRUG_AGENT.XML_DRUG_AGENT.IDA
            Next
            If AGENT_IDA <> 0 Then
                Dim dao_dtb_del As New DAO_DRUG.TB_DRRGT_DTB
                dao_dtb_del.GetDataby_FKIDA(IDA_drrgt)
                For Each dao_dtb_del.fields In dao_dtb_del.datas
                    dao_dtb_del.delete()
                Next
                For Each BC_LGT_XML_DRUG_AGENT In xml_iow.LGT_XML_DRUG_AGENT
                    Dim dao_dtb_ins As New DAO_DRUG.TB_DRRGT_DTB
                    With dao_dtb_ins.fields
                        .FK_IDA = IDA_drrgt
                        Try
                            Dim dao_XML_SEARCH_DRUG_LCN_ESUB As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
                            dao_XML_SEARCH_DRUG_LCN_ESUB.GetDataby_lcnno_no(BC_LGT_XML_DRUG_AGENT.XML_DRUG_AGENT.lcnno_no)
                            .FK_LCN_IDA = dao_XML_SEARCH_DRUG_LCN_ESUB.fields.IDA_dalcn
                        Catch ex As Exception

                        End Try

                    End With
                    dao_dtb_ins.insert()
                Next
            End If
            '-----------------------ผู้แทนจำหน่าย จบ
            '-----------------ลักษณะและสีของยา เริ่ม
            Dim BC_COLOR As New LGT_XML_DRUG_COLOR
            Dim C_COLOR As Integer = 0
            For Each BC_COLOR In xml_iow.LGT_XML_DRUG_COLOR
                C_COLOR += 1
            Next
            If C_COLOR > 0 Then
                Dim dao_color As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
                dao_color.GetDataby_FK_IDA(IDA_drrgt)
                For Each dao_color.fields In dao_color.datas
                    dao_color.delete()
                Next
                For Each BC_COLOR In xml_iow.LGT_XML_DRUG_COLOR
                    Dim dao_clor2 As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
                    With dao_clor2.fields
                        .DRUG_PROPERTIES_AND_DETAIL = BC_COLOR.XML_DRUG_COLOR.drgchrtha
                        .FK_IDA = IDA_drrgt
                        .OTHER = BC_COLOR.XML_DRUG_COLOR.drgchreng
                        .ROWS = BC_COLOR.XML_DRUG_COLOR.rid
                    End With
                    dao_clor2.insert()
                Next
            End If
            '-----------------ลักษณะและสีของยา จบ

            '----------เงื่อนไข เริ่ม
            Dim BC_CONDITION_TABEAN As New LGT_XML_DRUG_CONDITION_TABEAN
            Dim C_CONDITION_TABEAN As Integer = 0
            For Each BC_CONDITION_TABEAN In xml_iow.LGT_XML_DRUG_CONDITION_TABEAN
                If BC_CONDITION_TABEAN.XML_DRUG_CONDITION_TABEAN.IDA <> 0 Then
                    C_CONDITION_TABEAN += 1
                End If

            Next

            If C_CONDITION_TABEAN > 0 Then
                Dim dao_con As New DAO_DRUG.TB_DRRGT_CONDITION
                dao_con.GetDataby_FK_IDA(IDA_drrgt)
                For Each dao_con.fields In dao_con.datas
                    dao_con.delete()
                Next
                For Each BC_CONDITION_TABEAN In xml_iow.LGT_XML_DRUG_CONDITION_TABEAN
                    Dim dao_con_ins As New DAO_DRUG.TB_DRRGT_CONDITION
                    With dao_con_ins.fields
                        .CONDITION1 = BC_CONDITION_TABEAN.XML_DRUG_CONDITION_TABEAN.CONDITION_PUBLIC
                        .CONDITION2 = BC_CONDITION_TABEAN.XML_DRUG_CONDITION_TABEAN.CONDITION_SERVANT
                        .FK_IDA = IDA_drrgt
                    End With
                    dao_con_ins.insert()
                Next
            End If
            '----------เงื่อนไข จบ
            '----------เริ่มขนาดบรรจุ
            Dim BC_DRUG_CONTAIN As New LGT_XML_DRUG_CONTAIN
            Dim C_DRUG_CONTAIN As Integer = 0
            For Each BC_DRUG_CONTAIN In xml_iow.LGT_XML_DRUG_CONTAIN
                If BC_DRUG_CONTAIN.XML_DRUG_CONTAIN.IDA <> 0 Then
                    C_DRUG_CONTAIN += 1
                End If
            Next

            Dim dao_pack As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            dao_pack.GetDataby_FKIDA(IDA_drrgt)
            Dim c_pack As Integer = 0
            For Each dao_pack.fields In dao_pack.datas
                c_pack += 1
            Next
            If C_DRUG_CONTAIN > 0 Then
                If c_pack > 0 Then
                    For Each BC_DRUG_CONTAIN In xml_iow.LGT_XML_DRUG_CONTAIN
                        Dim dao_pack2 As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                        dao_pack2.GetDataby_FKIDA(IDA_drrgt)
                        dao_pack2.fields.pcksize = BC_DRUG_CONTAIN.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG
                        dao_pack2.update()

                        dao_rg.fields.PACKAGE_DETAIL = BC_DRUG_CONTAIN.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG
                    Next

                End If
            End If
            '----------จบขนาดบรรจุ
            ' XML_DRUG_CONTROL_ANALYZE ยังไม่ได้ทำ
            '-------------เริ่มชื่อยาส่งออก
            Dim BC_DRUG_EXPORT As New LGT_XML_DRUG_EXPORT
            Dim C_DRUG_EXPORT As Integer = 0
            For Each BC_DRUG_EXPORT In xml_iow.LGT_XML_DRUG_EXPORT
                If BC_DRUG_EXPORT.XML_DRUG_EXPORT.IDA <> 0 Then
                    C_DRUG_EXPORT += 1
                End If
            Next

            If C_DRUG_EXPORT > 0 Then
                Dim dao_export As New DAO_DRUG.TB_DRRGT_NAME_DRUG_EXPORT
                dao_export.GetDataby_FKIDA(IDA_drrgt)
                For Each dao_export.fields In dao_export.datas
                    dao_export.delete()
                Next
                For Each BC_DRUG_EXPORT In xml_iow.LGT_XML_DRUG_EXPORT
                    Dim dao_export2 As New DAO_DRUG.TB_DRRGT_NAME_DRUG_EXPORT
                    With dao_export2.fields
                        .ALPHA3 = BC_DRUG_EXPORT.XML_DRUG_EXPORT.cntcd
                        .DRUG_NAME = BC_DRUG_EXPORT.XML_DRUG_EXPORT.drgexp
                        .FK_IDA = IDA_drrgt
                        Try
                            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
                            dao_iso.GetData_alpha3(BC_DRUG_EXPORT.XML_DRUG_EXPORT.cntcd)
                            .NATIONAL_IDA = dao_iso.fields.IDA
                        Catch ex As Exception

                        End Try
                        .SEQ = BC_DRUG_EXPORT.XML_DRUG_EXPORT.rid
                    End With
                    dao_export2.insert()
                Next
            End If
            '-------------จบชื่อยาส่งออก
            '-----PI เริ่ม
            'Dim BC_DRUG_DOC_PI As New LGT_XML_DRUG_DOC_PI
            'Dim C_DRUG_DOC_PI As Integer = 0
            'For Each BC_DRUG_DOC_PI In xml_iow.LGT_XML_DRUG_DOC_PI
            '    If BC_DRUG_DOC_PI.XML_DRUG_PI.IDA <> 0 Then
            '        C_DRUG_DOC_PI += 1
            '    End If
            'Next


        End If


    End Sub
End Class
