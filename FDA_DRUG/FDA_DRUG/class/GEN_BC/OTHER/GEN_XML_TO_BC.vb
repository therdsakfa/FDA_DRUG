Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization

Namespace GEN_XML_TO_BC
    Public MustInherit Class GEN_XML_TO_BC
        Protected Friend Function AddValue(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then

                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else
                        Try
                            props.SetValue(ob, 0, Nothing)
                        Catch ex As Exception
                            props.SetValue(ob, Nothing, Nothing)
                        End Try


                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function
        Public Class GEN_XML_XML_DRUG_PRO
            Inherits GEN_XML_TO_BC


            Private _XML_DRUG_IOW_TO1 As New XML_DRUG_IOW_TO
            Public Property XML_DRUG_IOW_TO1() As XML_DRUG_IOW_TO
                Get
                    Return _XML_DRUG_IOW_TO1
                End Get
                Set(ByVal value As XML_DRUG_IOW_TO)
                    _XML_DRUG_IOW_TO1 = value
                End Set
            End Property

            Private _XML_DRUG_IOW_TYPE1 As New XML_DRUG_IOW_TYPE
            Public Property XML_DRUG_IOW_TYPE1() As XML_DRUG_IOW_TYPE
                Get
                    Return _XML_DRUG_IOW_TYPE1
                End Get
                Set(ByVal value As XML_DRUG_IOW_TYPE)
                    _XML_DRUG_IOW_TYPE1 = value
                End Set
            End Property
            Public Function gen_xml_XML_DR_FORMULA_E_SUB_TXT(ByVal Newcode_dr As String) As LGT_IOW_E

                Dim class_xml As New LGT_IOW_E
                'class_xml.XML_SEARCH_DRUG_DR = fields
                Dim dao_dr As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                dao_dr.GetDataby_u1(Newcode_dr)
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(dao_dr.fields.IDA_drrgt)
                Dim Newcode As String = dao_dr.fields.Newcode
                '#Region "DR_HEAD"
                If IsNothing(dao_dr.fields.IDA) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.IDA = dao_dr.fields.IDA
                Else
                    class_xml.XML_SEARCH_DRUG_DR.IDA = 0
                End If

                If IsNothing(dao_rg.fields.pvncd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.pvncd = dao_rg.fields.pvncd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.pvncd = ""
                End If

                If IsNothing(dao_rg.fields.drgtpcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.drgtpcd = dao_rg.fields.drgtpcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.drgtpcd = ""
                End If

                If IsNothing(dao_rg.fields.rgttpcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rgttpcd = dao_rg.fields.rgttpcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rgttpcd = ""
                End If

                If IsNothing(dao_rg.fields.rgtno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rgtno = dao_rg.fields.rgtno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rgtno = ""
                End If

                Dim dao_drgroup As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_drgroup.GetDataby_rgttpcd(dao_rg.fields.rgttpcd)
                Try

                    If IsNothing(dao_drgroup.fields.thargttpnm) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thargttpnm = dao_drgroup.fields.thargttpnm
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thargttpnm = ""
                    End If
                Catch ex As Exception
                    class_xml.XML_SEARCH_DRUG_DR.thargttpnm = ""
                End Try
                Try
                    If IsNothing(dao_drgroup.fields.engrgttpnm) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = dao_drgroup.fields.engrgttpnm
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = ""
                    End If
                Catch ex As Exception
                    class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = ""
                End Try


                Try
                    Dim dao_cl As New DAO_DRUG.TB_drclass
                    dao_cl.GetDataBycd(dao_rg.fields.classcd)
                    If IsNothing(dao_cl.fields.thaclassnm) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thaclassnm = dao_cl.fields.thaclassnm
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thaclassnm = ""
                    End If
                Catch ex As Exception

                End Try


                Try
                    Dim dao_drdrgtype As New DAO_DRUG.ClsDBdrdrgtype
                    dao_drdrgtype.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                    If IsNothing(dao_drdrgtype.fields.engdrgtpnm) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.engdrgtpnm = dao_drdrgtype.fields.engdrgtpnm
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.engdrgtpnm = ""
                    End If
                Catch ex As Exception

                End Try
                Try
                    Dim dao_kind As New DAO_DRUG.TB_drkdofdrg
                    dao_kind.GetData_by_kindcd(dao_rg.fields.kindcd)
                    If IsNothing(dao_kind.fields.thakindnm) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thakindnm = dao_kind.fields.thakindnm
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thakindnm = ""
                    End If
                Catch ex As Exception
                    class_xml.XML_SEARCH_DRUG_DR.thakindnm = ""
                End Try

                If IsNothing(dao_dr.fields.register) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register = dao_dr.fields.register
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register = ""
                End If

                If IsNothing(dao_dr.fields.rcvno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rcvno = dao_dr.fields.rcvno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rcvno = ""
                End If

                If IsNothing(dao_dr.fields.register_rcvno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register_rcvno = dao_dr.fields.register_rcvno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register_rcvno = ""
                End If

                Try
                    If IsNothing(dao_rg.fields.lcnsid) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.lcnsid = dao_rg.fields.lcnsid
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.lcnsid = ""
                    End If
                Catch ex As Exception

                End Try

                If IsNothing(dao_rg.fields.pvnabbr) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.pvnabbr = dao_rg.fields.pvnabbr
                Else
                    class_xml.XML_SEARCH_DRUG_DR.pvnabbr = ""
                End If

                If IsNothing(dao_rg.fields.lpvncd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lpvncd = dao_rg.fields.lpvncd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lpvncd = ""
                End If


                If IsNothing(dao_rg.fields.lcntpcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lcntpcd = dao_rg.fields.lcntpcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lcntpcd = ""
                End If

                If IsNothing(dao_rg.fields.lcnno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lcnno = dao_rg.fields.lcnno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lcnno = ""
                End If

                Dim lcnno_auto As String = dao_rg.fields.lcnno
                Dim lcnno_format As String = ""
                Try
                    If Len(lcnno_auto) > 0 Then

                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao_rg.fields.lcntpcd & " " & "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao_rg.fields.lcntpcd & " " & dao_rg.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                        'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                Catch ex As Exception

                End Try

                If IsNothing(lcnno_format) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lcnno_no = lcnno_format
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lcnno_no = ""
                End If

                'If IsNothing(dao_rg.fields.prefix_thanm) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.prefix_thanm = dao_rg.fields.prefix_thanm
                'Else
                '    class_xml.XML_SEARCH_DRUG_DR.prefix_thanm = ""
                'End If
                Dim dt As New DataTable
                Dim bao_show As New BAO_SHOW
                Try
                    dt = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao_rg.fields.IDENTIFY, dao_rg.fields.lcnsid)
                Catch ex As Exception

                End Try

                For Each dr As DataRow In dt.Rows
                    If IsNothing(dr("thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thanm = dr("thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thanm = ""
                    End If

                    If IsNothing(dr("thanm_locaion")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = ""
                    End If

                    If IsNothing(dr("prefix_licen")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.prefix_licen = dr("prefix_licen")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.prefix_licen = ""
                    End If

                    If IsNothing(dr("licen_loca")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.licen_loca = dr("licen_loca")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.licen_loca = ""
                    End If

                    If IsNothing(dr("thathmblnm_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thathmblnm_thanm = dr("thathmblnm_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thathmblnm_thanm = ""
                    End If

                    If IsNothing(dr("thaamphrnm_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = dr("thaamphrnm_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = ""
                    End If

                    If IsNothing(dr("thachngwtnm_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thachngwtnm_thanm = dr("thachngwtnm_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thachngwtnm_thanm = ""
                    End If
                Next

                Dim dt_addr As New DataTable
                Dim bao_addr As New BAO.ClsDBSqlcommand
                Try
                    dt_addr = bao_addr.SP_DRRGT_ADDR_SAI_BY_FK_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                For Each dr As DataRow In dt_addr.Rows
                    If IsNothing(dr("fulladdr")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.fulladdr = dr("fulladdr")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.fulladdr = ""
                    End If
                    If IsNothing(dr("thaaddr_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thaaddr_thanm = dr("thaaddr_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thaaddr_thanm = ""
                    End If
                Next

                Dim dt_lcn_addr As New DataTable
                Dim bao_lcn_addr As New BAO.ClsDBSqlcommand
                Try
                    dt_lcn_addr = bao_lcn_addr.SP_GET_LCN_LOCAION_SAI_BY_IDA(dao_rg.fields.FK_LCN_IDA)
                Catch ex As Exception

                End Try

                For Each dr As DataRow In dt_lcn_addr.Rows
                    If IsNothing(dr("tharoom_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.tharoom_thanm = dr("tharoom_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.tharoom_thanm = ""
                    End If


                    If IsNothing(dr("thafloor_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thafloor_thanm = dr("thafloor_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thafloor_thanm = ""
                    End If


                    If IsNothing(dr("thabuilding_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thabuilding_thanm = dr("thabuilding_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thabuilding_thanm = ""
                    End If

                    If IsNothing(dr("thasoi_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thasoi_thanm = dr("thasoi_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thasoi_thanm = ""
                    End If

                    If IsNothing(dr("tharoad_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.tharoad_thanm = dr("tharoad_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.tharoad_thanm = ""
                    End If


                    If IsNothing(dr("thamu_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.thamu_thanm = dr("thamu_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.thamu_thanm = ""
                    End If



                    If IsNothing(dr("zipcode_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.zipcode_thanm = dr("zipcode_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.zipcode_thanm = ""
                    End If

                    If IsNothing(dr("tel_thanm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.tel_thanm = dr("tel_thanm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.tel_thanm = ""
                    End If
                Next


                If IsNothing(dao_rg.fields.thadrgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thadrgnm = dao_rg.fields.thadrgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thadrgnm = ""
                End If


                If IsNothing(dao_rg.fields.engdrgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engdrgnm = dao_rg.fields.engdrgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engdrgnm = ""
                End If


                'If IsNothing(dao_rg.fields.GROUPNAME) = False Then
                class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = "DR"
                'Else
                'class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = ""
                'End If


                'If IsNothing(dao_rg.fields.phm15dgt) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.phm15dgt = dao_rg.fields.phm15dgt
                'Else
                class_xml.XML_SEARCH_DRUG_DR.phm15dgt = "-"
                ' End If

                If IsNothing(dao_rg.fields.IDENTIFY) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = dao_rg.fields.IDENTIFY
                Else
                    class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = ""
                End If

                If IsNothing(dao_rg.fields.IDENTIFY) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Identify = dao_rg.fields.IDENTIFY
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Identify = ""
                End If

                Dim dt_each As New DataTable
                Dim bao_each As New BAO_SHOW
                Try
                    dt_each = bao_each.SP_DRRGT_EACH_BY_FK_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                For Each dr As DataRow In dt_each.Rows
                    If IsNothing(dr("EACH")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.drgperunit = dr("EACH")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.drgperunit = ""
                    End If
                Next


                Dim dao_pro_iso As New DAO_DRUG.TB_DRRGT_PRODUCER
                Try
                    dao_pro_iso.GetDataby_FK_IDA(dao_rg.fields.IDA)
                    If dao_pro_iso.fields.IDA <> 0 Then
                        Dim dao_ff As New DAO_DRUG.ClsDBdrfrgnaddr
                        dao_ff.GetDataByIDA(dao_pro_iso.fields.addr_ida)
                        If IsNothing(dao_ff.fields.cntcd) = False Then
                            class_xml.XML_SEARCH_DRUG_DR.cntcd = dao_ff.fields.cntcd
                        Else
                            class_xml.XML_SEARCH_DRUG_DR.cntcd = ""
                        End If
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.cntcd = "THA"
                    End If
                Catch ex As Exception

                End Try
                Dim dao_dsg As New DAO_DRUG.TB_drdosage
                Try
                    dao_dsg.GetDataby_cd(dao_rg.fields.dsgcd)
                Catch ex As Exception

                End Try
                If IsNothing(dao_dsg.fields.thadsgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thadsgnm = dao_dsg.fields.thadsgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thadsgnm = ""
                End If



                If IsNothing(dao_dsg.fields.engdsgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engdsgnm = dao_dsg.fields.engdsgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engdsgnm = ""
                End If

                Dim dao_dac As New DAO_DRUG.ClsDBdactg
                Try
                    dao_dac.GetData_by_cd(dao_rg.fields.ctgcd)
                Catch ex As Exception

                End Try
                If IsNothing(dao_dac.fields.ctgthanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.ctgthanm = dao_dac.fields.ctgthanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.ctgthanm = ""
                End If

                If IsNothing(dao_rg.fields.potency) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.potency = dao_rg.fields.potency
                Else
                    class_xml.XML_SEARCH_DRUG_DR.potency = ""
                End If

                If IsNothing(dao_rg.fields.dsgcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.dsgcd = dao_rg.fields.dsgcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.dsgcd = ""
                End If


                If IsNothing(dao_rg.fields.ctgcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.ctgcd = dao_rg.fields.ctgcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.ctgcd = ""
                End If


                If IsNothing(dao_rg.fields.cnccd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cnccd = dao_rg.fields.cnccd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cnccd = ""
                End If

                Dim dt_cnccnm As New DataTable
                Dim bao_cnc As New BAO.ClsDBSqlcommand
                Try
                    dt_cnccnm = bao_cnc.SP_GET_DRRGT_STATUS_SAI_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                For Each dr As DataRow In dt_cnccnm.Rows
                    If IsNothing(dr("cncnm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.cncnm = dr("cncnm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.cncnm = ""
                    End If

                    If IsNothing(dr("cnccsnm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.cnccsnm = dr("cnccsnm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.cnccsnm = ""
                    End If
                    If IsNothing(dr("rcvdate")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.rcvdate = dr("rcvdate")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.rcvdate = Date.Now
                    End If

                    If IsNothing(dr("rcvdate_T")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = dr("rcvdate_T")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = ""
                    End If

                    If IsNothing(dr("appdate_T")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.appdate_T = dr("appdate_T")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.appdate_T = ""
                    End If
                    If IsNothing(dr("appdate_th")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.appdate_th = ""
                    End If
                    If IsNothing(dr("cncdate_th")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.cncdate_th = dr("cncdate_th")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.cncdate_th = ""
                    End If

                    If IsNothing(dr("cnsdnm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.cnsdnm = dr("cnsdnm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.cnsdnm = ""
                    End If
                Next

                If IsNothing(dao_rg.fields.appdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.appdate = dao_rg.fields.appdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.appdate = Date.Now
                End If
                If IsNothing(dao_rg.fields.cncdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cncdate = dao_rg.fields.cncdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cncdate = Date.Now
                End If

                'Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                'Try
                '    dao_rq.GetData_pvncd_rgtno_drgtpcd_rgttpcd(dao_rg.fields.pvncd, dao_rg.fields.rgtno, dao_rg.fields.drgtpcd, dao_rg.fields.rgttpcd)
                'Catch ex As Exception

                'End Try



                If IsNothing(dao_rg.fields.expdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.expdate = dao_rg.fields.expdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.expdate = Date.Now
                End If



                If IsNothing(dao_rg.fields.expdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.ExpiryDate = dao_rg.fields.expdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.ExpiryDate = Date.Now
                End If


                'If IsNothing(dao_rg.fields.story_edit) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.story_edit = dao_rg.fields.story_edit
                'Else
                class_xml.XML_SEARCH_DRUG_DR.story_edit = ""
                ' End If

                Dim dt_frgn_nm As New DataTable
                Dim bao_frgnnm As New BAO.ClsDBSqlcommand
                Try
                    dt_frgn_nm = bao_frgnnm.SP_DRRGT_PRODUCER_SAI_BY_FK_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                For Each dr As DataRow In dt_frgn_nm.Rows
                    If IsNothing(dr("engfrgnnm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.engfrgnnm = dr("engfrgnnm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.engfrgnnm = ""
                    End If

                    If IsNothing(dr("engfrgnnm_addr")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.engfrgnnm_addr = dr("engfrgnnm_addr")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.engfrgnnm_addr = ""
                    End If

                    If IsNothing(dr("engcntnm")) = False Then
                        class_xml.XML_SEARCH_DRUG_DR.engcntnm = dr("engcntnm")
                    Else
                        class_xml.XML_SEARCH_DRUG_DR.engcntnm = ""
                    End If
                Next




                'If IsNothing(dao_rg.fields.rid) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.rid = dao_rg.fields.rid
                'Else
                class_xml.XML_SEARCH_DRUG_DR.rid = "-"
                ' End If


                'If IsNothing(dao_rg.fields.cncdcd) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.cncdcd = dao_rg.fields.cncdcd
                'Else
                class_xml.XML_SEARCH_DRUG_DR.cncdcd = "-"
                'End If



                If IsNothing(dao_rg.fields.expdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.expdate = dao_rg.fields.expdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.expdate = Date.Now
                End If

                'If IsNothing(dao_rg.fields.frn_no) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.frn_no = dao_rg.fields.frn_no
                'Else
                class_xml.XML_SEARCH_DRUG_DR.frn_no = "1"
                'End If

                'If IsNothing(dao_rg.fields.itemno) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.itemno = dao_rg.fields.itemno
                'Else
                class_xml.XML_SEARCH_DRUG_DR.itemno = "1"
                'End If


                'If IsNothing(dao_rg.fields.Ranking) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.Ranking = dao_rg.fields.Ranking
                'Else
                class_xml.XML_SEARCH_DRUG_DR.Ranking = "0"
                'End If

                'If IsNothing(dao_rg.fields.typerqt) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.typerqt = dao_rg.fields.typerqt
                'Else
                class_xml.XML_SEARCH_DRUG_DR.typerqt = "คำขอขึ้นทะเบียนตำรับยา"
                'End If


                'If IsNothing(dao_rg.fields.Buyers_through) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.Buyers_through = dao_rg.fields.Buyers_through
                'Else
                class_xml.XML_SEARCH_DRUG_DR.Buyers_through = "-"
                'End If


                'If IsNothing(dao_rg.fields.Buyers_through_cntcd) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.Buyers_through_cntcd = dao_rg.fields.Buyers_through_cntcd
                'Else
                class_xml.XML_SEARCH_DRUG_DR.Buyers_through_cntcd = "-"
                'End If

                If IsNothing(dao_dr.fields.Newcode) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode = dao_dr.fields.Newcode
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode = ""
                End If

                If IsNothing(dao_dr.fields.Newcode_U) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_U = dao_dr.fields.Newcode_U
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_U = ""
                End If

                If IsNothing(dao_dr.fields.Newcode_R) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_R = dao_dr.fields.Newcode_R
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_R = ""
                End If

                If IsNothing(dao_dr.fields.Newcode_not) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_not = dao_dr.fields.Newcode_not
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_not = ""
                End If

                If IsNothing(dao_dr.fields.register_search) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register_search = dao_dr.fields.register_search
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register_search = ""
                End If

                If IsNothing(dao_rg.fields.lmdfdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lmdfdate = dao_rg.fields.lmdfdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lmdfdate = Date.Now
                End If



                If IsNothing(dao_dr.fields.register_search2) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register_search2 = dao_dr.fields.register_search2
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register_search2 = ""
                End If

                Dim dao_dtl As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                Try
                    dao_dtl.GetDataby_FKIDA_MAX(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                If IsNothing(dao_dtl.fields.dtl) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.indication = dao_dtl.fields.dtl
                Else
                    class_xml.XML_SEARCH_DRUG_DR.indication = ""
                End If

                If IsNothing(dao_rg.fields.cncnote) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cncnote = dao_rg.fields.cncnote
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cncnote = ""
                End If


                'If IsNothing(dao_rg.fields.CER_FORMAT) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.CER_FORMAT = dao_rg.fields.CER_FORMAT
                'Else
                class_xml.XML_SEARCH_DRUG_DR.CER_FORMAT = "-"
                'End If




                'If IsNothing(dao_rg.fields.IDA_dh15rqt) = False Then
                '    class_xml.XML_SEARCH_DRUG_DR.IDA_dh15rqt = dao_rg.fields.IDA_dh15rqt
                'Else
                class_xml.XML_SEARCH_DRUG_DR.IDA_dh15rqt = 0
                'End If
                '#End Region---------------------------------------------------------------------------------------------------------------------------------------


                '#Region "สภาวะการเก็บรักษา"
                '-----------------------สภาวะการเก็บรักษา
                Dim bao_stow As New BAO.ClsDBSqlcommand
                Dim dt_stowagr As New DataTable
                Try
                    dt_stowagr = bao_stow.SP_GET_XML_DRUG_STOWAGR_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_stowagr As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_STOWAGR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                'dao_stowagr.GetDataby_Newcode(dao_dr.fields.Newcode_U)

                'For Each dao_stowagr.fields In dao_stowagr.datas
                For Each dr As DataRow In dt_stowagr.Rows

                    Dim lgt_stowagr As New LGT_XML_STOWAGR_TO

                    If IsNothing(dr("IDA")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.IDA = dr("IDA")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.IDA = 0
                    End If


                    If IsNothing(dr("pvncd")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.pvncd = dr("pvncd")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.pvncd = ""
                    End If

                    If IsNothing(dr("lcnno")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnno = dr("lcnno")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnno = ""
                    End If

                    If IsNothing(dr("lcnsid")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnsid = dr("lcnsid")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnsid = ""
                    End If


                    If IsNothing(dr("rgtno")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.rgtno = dr("rgtno")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.rgtno = ""
                    End If
                    If IsNothing(dr("rid")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.rid = dr("rid")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.rid = ""
                    End If

                    If IsNothing(dr("thadrgnm")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.thadrgnm = dr("thadrgnm")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.thadrgnm = ""
                    End If

                    If IsNothing(dr("engdrgnm")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.engdrgnm = dr("engdrgnm")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.engdrgnm = ""
                    End If

                    If IsNothing(dr("keepdesc")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.keepdesc = dr("keepdesc")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.keepdesc = ""
                    End If


                    If IsNothing(dr("drgchrtha")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.drgchrtha = dr("drgchrtha")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.drgchrtha = ""
                    End If

                    If IsNothing(dr("useage")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.useage = dr("useage")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.useage = ""
                    End If
                    If IsNothing(dr("tplow")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.tplow = dr("tplow")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.tplow = ""
                    End If
                    If IsNothing(dr("tphigh")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.tphigh = dr("tphigh")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.tphigh = ""
                    End If
                    If IsNothing(dr("drug_age_days")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_days = dr("drug_age_days")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_days = ""
                    End If
                    If IsNothing(dr("drug_age_month")) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_month = dr("drug_age_month")
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_month = ""
                    End If

                    If IsNothing(dao_dr.fields.Newcode) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.Newcode = dao_dr.fields.Newcode
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.Newcode = ""
                    End If


                    class_xml.LGT_XML_STOWAGR_TO.Add(lgt_stowagr)
                Next
                '#End Region
                '#Region "กลุ่มตำรับยา"
                '-----------------------กลุ่มตำรับยา
                'Dim dao_RECIPE_GROUP As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_RECIPE_GROUP  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                'dao_RECIPE_GROUP.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                Dim dt_atc As DataTable
                Dim bao_atc As BAO.ClsDBSqlcommand
                Try
                    dt_atc = bao_atc.SP_GET_XML_DRUG_RECIPE_GROUP_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'For Each dao_RECIPE_GROUP.fields In dao_RECIPE_GROUP.datas
                For Each dr As DataRow In dt_atc.Rows
                    Dim lgt_recipe As New LGT_RECIPE_GROUP_TO


                    If IsNothing(dr("IDA")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.IDA = dr("IDA")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.IDA = 0
                    End If


                    If IsNothing(dr("pvncd")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.pvncd = dr("pvncd")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.pvncd = ""
                    End If



                    If IsNothing(dr("lcnno")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnno = dr("lcnno")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnno = ""
                    End If



                    If IsNothing(dr("lcnsid")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnsid = dr("lcnsid")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnsid = ""
                    End If

                    If IsNothing(dr("rgtno")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rgtno = dr("rgtno")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rgtno = ""
                    End If

                    If IsNothing(dr("version")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.version = dr("version")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.version = ""
                    End If

                    If IsNothing(dr("register")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.register = dr("register")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.register = ""
                    End If
                    If IsNothing(dr("rid")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rid = dr("rid")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rid = ""
                    End If

                    If IsNothing(dr("thadrgnm")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.thadrgnm = dr("thadrgnm")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.thadrgnm = ""
                    End If

                    If IsNothing(dr("engdrgnm")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.engdrgnm = dr("engdrgnm")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.engdrgnm = ""
                    End If

                    If IsNothing(dr("atccd")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atccd = dr("atccd")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atccd = ""
                    End If

                    If IsNothing(dr("atcnm")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atcnm = dr("atcnm")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atcnm = ""
                    End If

                    'If IsNothing(dr("iowanm) = False Then
                    '    lgt_recipe.XML_RECIPE_GROUPT.iowanm = dr("iowanm
                    'Else
                    '    lgt_recipe.XML_RECIPE_GROUPT.iowanm = ""
                    'End If


                    'If IsNothing(dr("qty_all) = False Then
                    '    lgt_recipe.XML_RECIPE_GROUPT.qty_all = dr("qty_all
                    'Else
                    '    lgt_recipe.XML_RECIPE_GROUPT.qty_all = ""
                    'End If

                    'If IsNothing(dr("drgperunit) = False Then
                    '    lgt_recipe.XML_RECIPE_GROUPT.drgperunit = dr("drgperunit
                    'Else
                    '    lgt_recipe.XML_RECIPE_GROUPT.drgperunit = ""
                    'End If

                    If IsNothing(dr("Newcode")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Newcode = dr("Newcode")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Newcode = ""
                    End If


                    If IsNothing(dr("ATCCDL1")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL1 = dr("ATCCDL1")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL1 = ""
                    End If

                    If IsNothing(dr("ATCCDL2")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL2 = dr("ATCCDL2")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL2 = ""
                    End If


                    If IsNothing(dr("ATCCDL3")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL3 = dr("ATCCDL3")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL3 = ""
                    End If

                    If IsNothing(dr("ATCCDL4")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL4 = dr("ATCCDL4")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL4 = ""
                    End If

                    If IsNothing(dr("ATCCDL5")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL5 = dr("ATCCDL5")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL5 = ""
                    End If

                    If IsNothing(dr("ATCCDL6")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL6 = dr("ATCCDL6")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL6 = ""
                    End If

                    If IsNothing(dr("ATCNML1")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML1 = dr("ATCNML1")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML1 = ""
                    End If

                    If IsNothing(dr("ATCNML2")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML2 = dr("ATCNML2")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML2 = ""
                    End If


                    If IsNothing(dr("ATCNML3")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML3 = dr("ATCNML3")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML3 = ""
                    End If

                    If IsNothing(dr("ATCNML4")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML4 = dr("ATCNML4")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML4 = ""
                    End If
                    If IsNothing(dr("ATCNML5")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML5 = dr("ATCNML5")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML5 = ""
                    End If


                    If IsNothing(dr("ATCNML6")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML6 = dr("ATCNML6")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML6 = ""
                    End If

                    If IsNothing(dr("WHODDDAmount")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDAmount = dr("WHODDDAmount")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDAmount = ""
                    End If


                    If IsNothing(dr("WHODDDUnit")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDUnit = dr("WHODDDUnit")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDUnit = ""
                    End If

                    If IsNothing(dr("DDD")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.DDD = dr("DDD")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.DDD = ""
                    End If

                    If IsNothing(dr("UNIT_CD")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.UNIT_CD = dr("UNIT_CD")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.UNIT_CD = ""
                    End If


                    If IsNothing(dr("Adm_R")) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Adm_R = dr("Adm_R")
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Adm_R = ""
                    End If

                    class_xml.LGT_RECIPE_GROUP_TO.Add(lgt_recipe)
                Next
                '#End Region
                '#Region "ยาสัตว์มีส่วนบริโภคและไม่มีส่วนบริโภค"
                '-----------------------ยาสัตว์มีส่วนบริโภคและไม่มีส่วนบริโภค
                Dim dt_animal As New DataTable
                Dim bao_animal As New BAO.ClsDBSqlcommand
                Try
                    dt_animal = bao_animal.SP_GET_XML_DRUG_ANIMAL_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_ANIMAL_DRUG As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_ANIMAL  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                'dao_ANIMAL_DRUG.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                'For Each dao_ANIMAL_DRUG.fields In dao_ANIMAL_DRUG.datas
                For Each dr As DataRow In dt_animal.Rows
                    Dim lgt_animal As New LGT_ANIMAL_DRUGS_TO

                    If IsNothing(dr("IDA")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.IDA = dr("IDA")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.IDA = 0
                    End If


                    If IsNothing(dr("pvncd")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.pvncd = dr("pvncd")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.pvncd = ""
                    End If


                    If IsNothing(dr("lcnno")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.lcnno = dr("lcnno")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.lcnno = ""
                    End If


                    If IsNothing(dr("lcnsid")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.lcnsid = dr("lcnsid")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.lcnsid = ""
                    End If


                    If IsNothing(dr("rgttpcd")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.rgttpcd = dr("rgttpcd")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.rgttpcd = ""
                    End If

                    If IsNothing(dr("rgtno")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.rgtno = dr("rgtno")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.rgtno = ""
                    End If

                    If IsNothing(dr("thadrgnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.thadrgnm = dr("thadrgnm")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.thadrgnm = ""
                    End If

                    If IsNothing(dr("engdrgnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.engdrgnm = dr("engdrgnm")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.engdrgnm = ""
                    End If

                    If IsNothing(dr("ampartnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.ampartnm = dr("ampartnm")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.ampartnm = ""
                    End If

                    If IsNothing(dr("amlsubnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.amlsubnm = dr("amlsubnm")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.amlsubnm = ""
                    End If

                    If IsNothing(dr("amltpnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.amltpnm = dr("amltpnm")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.amltpnm = ""
                    End If


                    If IsNothing(dr("usetpnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.usetpnm = dr("usetpnm")

                    Else
                        lgt_animal.XML_DRUG_ANIMAL.usetpnm = ""
                    End If

                    If IsNothing(dr("stpdrg")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = dr("stpdrg")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = ""
                    End If

                    If IsNothing(dr("rid")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.rid = dr("rid")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.rid = ""
                    End If

                    If IsNothing(dr("Newcode")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.Newcode = dr("Newcode")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.Newcode = ""
                    End If


                    If IsNothing(dr("Newcode")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.register = dr("register")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.Newcode = ""
                    End If


                    If IsNothing(dr("licen_loca")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.licen_loca = dr("licen_loca")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.licen_loca = ""
                    End If

                    If IsNothing(dr("thaclassnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.thaclassnm = dr("thaclassnm")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.thaclassnm = ""
                    End If

                    If IsNothing(dr("cncnm")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.cncnm = dr("cncnm")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.cncnm = ""
                    End If

                    If IsNothing(dr("stpdrg")) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = dr("stpdrg")
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = ""
                    End If

                    class_xml.LGT_ANIMAL_DRUGS_TO.Add(lgt_animal)




                    Dim animal_ampartnm As String
                    Dim animal_amlsubnm As String
                    Dim animal_amltpnm As String
                    Dim animal_usetpnm As String
                    Dim Newcode_animal_consume As String


                    Dim dt_animal_consume As New DataTable
                    animal_ampartnm = dr("ampartnm") ' dao_ANIMAL_DRUG.fields.ampartnm
                    animal_amlsubnm = dr("amlsubnm") 'dao_ANIMAL_DRUG.fields.amlsubnm
                    animal_amltpnm = dr("amltpnm") ' dao_ANIMAL_DRUG.fields.amltpnm
                    animal_usetpnm = dr("usetpnm") 'dao_ANIMAL_DRUG.fields.usetpnm
                    Newcode_animal_consume = dr("Newcode") ' dao_ANIMAL_DRUG.fields.Newcode

                    Dim dt_ani_con As New DataTable
                    Dim bao_ani_con As BAO.ClsDBSqlcommand
                    'Dim dao_ANIMAL_COS_DRUG As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_ANIMAL_CONSUME  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                    'dao_ANIMAL_COS_DRUG.GetDataby_animal_consume(animal_ampartnm, animal_amlsubnm, animal_amltpnm, animal_usetpnm, Newcode_animal_consume)

                    'For Each dao_ANIMAL_COS_DRUG.fields In dao_ANIMAL_COS_DRUG.datas
                    For Each dr2 As DataRow In dt_animal_consume.Rows
                        Dim lgt_animal_consume As New LGT_ANIMAL_CONSUME_DRUGS_TO

                        If IsNothing(dr2("pvncd")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.pvncd = dr2("pvncd")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.pvncd = ""
                        End If


                        If IsNothing(dr2("lcnno")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnno = dr2("lcnno")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnno = ""
                        End If

                        If IsNothing(dr2("lcnsid")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnsid = dr2("lcnsid")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnsid = ""
                        End If

                        If IsNothing(dr2("rgttpcd")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgttpcd = dr2("rgttpcd")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgttpcd = ""
                        End If




                        If IsNothing(dr2("rgtno")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgtno = dr2("rgtno")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgtno = ""
                        End If

                        If IsNothing(dr2("thadrgnm")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.thadrgnm = dr2("thadrgnm")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.thadrgnm = ""
                        End If



                        If IsNothing(dr2("engdrgnm")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.engdrgnm = dr2("engdrgnm")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.engdrgnm = ""
                        End If


                        If IsNothing(dr2("ampartnm")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.ampartnm = dr2("ampartnm")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.ampartnm = ""
                        End If


                        If IsNothing(dr2("amlsubnm")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amlsubnm = dr2("amlsubnm")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amlsubnm = ""
                        End If

                        If IsNothing(dr2("amltpnm")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amltpnm = dr2("amltpnm")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amltpnm = ""
                        End If



                        If IsNothing(dr2("usetpnm")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.usetpnm = dr2("usetpnm")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.usetpnm = ""
                        End If


                        If IsNothing(dr2("stpdrg")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.stpdrg = dr2("stpdrg")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.stpdrg = ""
                        End If
                        If IsNothing(dr2("rid")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rid = dr2("rid")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rid = ""
                        End If

                        If IsNothing(dr2("Newcode")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.Newcode = dr2("Newcode")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.Newcode = ""
                        End If

                        If IsNothing(dr2("packuse")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.packuse = dr2("packuse")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.packuse = ""
                        End If

                        If IsNothing(dr2("nouse")) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.nouse = dr2("nouse")
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.nouse = ""
                        End If

                        lgt_animal.LGT_ANIMAL_CONSUME_DRUGS_TO.Add(lgt_animal_consume)
                    Next

                Next
                '#End Region
                '#Region "สาร"
                'SP_XML_DRUG_IOW_BY_IDA
                '-------------เริ่มต้นสาร-----------------------------------------------------------------------------------------------------
                '-----------------------สารสำคัญ + สาร EQ.TO
                Dim dt_iow As New DataTable
                Dim bao_iow As New BAO.ClsDBSqlcommand
                Try
                    dt_iow = bao_iow.SP_XML_DRUG_IOW_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_iow As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                'Dim dao_iow_gp As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW
                'dao_iow_gp.GetDataby_Newcode_U_GROUP(dao_dr.fields.Newcode_U)
                Dim dt_iow_set As New DataTable
                Dim bao_iow_set As New BAO.ClsDBSqlcommand

                For Each dr As DataRow In dt_iow.Rows ' dao_iow_gp.datas
                    ' dao_iow.GetDataby_Newcode_U(dao_dr.fields.Newcode_U, dr.ToString.Substring(12).Replace("}", "")) ' Substring=12 เพ
                    Try
                        dt_iow_set = bao_iow_set.SP_XML_DRUG_IOW_BY_IDA_FK_SET(dao_rg.fields.IDA, dr("flineno"))
                    Catch ex As Exception

                    End Try
                    For Each dr_set As DataRow In dt_iow_set.Rows 'dao_iow.datas
                        Dim lgt_iow As New XML_DRUG_IOW_TO

                        If IsNothing(dr_set("IDA")) = False Then
                            lgt_iow.XML_DRUG_IOW.IDA = dr_set("IDA")
                        Else
                            lgt_iow.XML_DRUG_IOW.IDA = 0
                        End If

                        If IsNothing(dr_set("pvncd")) = False Then
                            lgt_iow.XML_DRUG_IOW.pvncd = dr_set("pvncd")
                        Else
                            lgt_iow.XML_DRUG_IOW.pvncd = ""
                        End If

                        If IsNothing(dr_set("rgttpcd")) = False Then
                            lgt_iow.XML_DRUG_IOW.rgttpcd = dr_set("rgttpcd")
                        Else
                            lgt_iow.XML_DRUG_IOW.rgttpcd = ""
                        End If

                        If IsNothing(dr_set("rgtno")) = False Then
                            lgt_iow.XML_DRUG_IOW.rgtno = dr_set("rgtno")
                        Else
                            lgt_iow.XML_DRUG_IOW.rgtno = ""
                        End If

                        If IsNothing(dr_set("lcnno")) = False Then
                            lgt_iow.XML_DRUG_IOW.lcnno = dr_set("lcnno")
                        Else
                            lgt_iow.XML_DRUG_IOW.lcnno = ""
                        End If
                        If IsNothing(dr_set("register")) = False Then
                            lgt_iow.XML_DRUG_IOW.register = dr_set("register")
                        Else
                            lgt_iow.XML_DRUG_IOW.register = ""
                        End If

                        If IsNothing(dr_set("lcnsid")) = False Then
                            lgt_iow.XML_DRUG_IOW.lcnsid = dr_set("lcnsid")
                        Else
                            lgt_iow.XML_DRUG_IOW.lcnsid = ""
                        End If


                        If IsNothing(dr_set("CITIZEN_AUTHORIZE")) = False Then
                            lgt_iow.XML_DRUG_IOW.CITIZEN_AUTHORIZE = dr_set("CITIZEN_AUTHORIZE")
                        Else
                            lgt_iow.XML_DRUG_IOW.CITIZEN_AUTHORIZE = ""
                        End If

                        If IsNothing(dr_set("flineno")) = False Then
                            lgt_iow.XML_DRUG_IOW.flineno = dr_set("flineno")
                        Else
                            lgt_iow.XML_DRUG_IOW.flineno = ""
                        End If

                        If IsNothing(dr_set("drgqty")) = False Then
                            lgt_iow.XML_DRUG_IOW.drgqty = dr_set("drgqty")
                        Else
                            lgt_iow.XML_DRUG_IOW.drgqty = ""
                        End If

                        If IsNothing(dr_set("drgperunit")) = False Then
                            lgt_iow.XML_DRUG_IOW.drgperunit = dr_set("drgperunit")
                        Else
                            lgt_iow.XML_DRUG_IOW.drgperunit = ""
                        End If

                        If IsNothing(dr_set("drgcdt")) = False Then
                            lgt_iow.XML_DRUG_IOW.drgcdt = dr_set("drgcdt")
                        Else
                            lgt_iow.XML_DRUG_IOW.drgcdt = ""
                        End If

                        If IsNothing(dr_set("thadsgnm")) = False Then
                            lgt_iow.XML_DRUG_IOW.thadsgnm = dr_set("thadsgnm")
                        Else
                            lgt_iow.XML_DRUG_IOW.thadsgnm = ""
                        End If


                        If IsNothing(dr_set("rid")) = False Then
                            lgt_iow.XML_DRUG_IOW.rid = dr_set("rid")
                        Else
                            lgt_iow.XML_DRUG_IOW.rid = ""
                        End If


                        If IsNothing(dr_set("iowacd")) = False Then
                            lgt_iow.XML_DRUG_IOW.iowacd = dr_set("iowacd")
                        Else
                            lgt_iow.XML_DRUG_IOW.iowacd = ""
                        End If


                        If IsNothing(dr_set("iowanm")) = False Then
                            lgt_iow.XML_DRUG_IOW.iowanm = dr_set("iowanm")
                        Else
                            lgt_iow.XML_DRUG_IOW.iowanm = ""
                        End If
                        If IsNothing(dr_set("SinggleContent")) = False Then
                            lgt_iow.XML_DRUG_IOW.SinggleContent = dr_set("SinggleContent")
                        Else
                            lgt_iow.XML_DRUG_IOW.SinggleContent = ""
                        End If

                        If IsNothing(dr_set("UnitForSinggleContent")) = False Then
                            lgt_iow.XML_DRUG_IOW.UnitForSinggleContent = dr_set("UnitForSinggleContent")
                        Else
                            lgt_iow.XML_DRUG_IOW.UnitForSinggleContent = ""
                        End If

                        If IsNothing(dr_set("qtytxt_all")) = False Then
                            lgt_iow.XML_DRUG_IOW.qtytxt_all = dr_set("qtytxt_all")
                        Else
                            lgt_iow.XML_DRUG_IOW.qtytxt_all = ""
                        End If

                        If IsNothing(dr_set("qtytxt")) = False Then
                            lgt_iow.XML_DRUG_IOW.qtytxt = dr_set("qtytxt")
                        Else
                            lgt_iow.XML_DRUG_IOW.qtytxt = ""
                        End If

                        If IsNothing(dr_set("qty")) = False Then
                            lgt_iow.XML_DRUG_IOW.qty = dr_set("qty")
                        Else
                            lgt_iow.XML_DRUG_IOW.qty = ""
                        End If


                        If IsNothing(dr_set("qty_y")) = False Then
                            lgt_iow.XML_DRUG_IOW.qty_y = dr_set("qty_y")
                        Else
                            lgt_iow.XML_DRUG_IOW.qty_y = ""
                        End If



                        If IsNothing(dr_set("qty_y")) = False Then
                            lgt_iow.XML_DRUG_IOW.qty_y = dr_set("qty_y")
                        Else
                            lgt_iow.XML_DRUG_IOW.qty_y = ""
                        End If



                        If IsNothing(dr_set("sunitengnm")) = False Then
                            lgt_iow.XML_DRUG_IOW.sunitengnm = dr_set("sunitengnm")
                        Else
                            lgt_iow.XML_DRUG_IOW.sunitengnm = ""
                        End If


                        If IsNothing(dr_set("thadrgnm")) = False Then
                            lgt_iow.XML_DRUG_IOW.thadrgnm = dr_set("thadrgnm")
                        Else
                            lgt_iow.XML_DRUG_IOW.thadrgnm = ""
                        End If

                        If IsNothing(dr_set("engdrgnm")) = False Then
                            lgt_iow.XML_DRUG_IOW.engdrgnm = dr_set("engdrgnm")
                        Else
                            lgt_iow.XML_DRUG_IOW.engdrgnm = ""
                        End If


                        If IsNothing(dr_set("aori")) = False Then
                            lgt_iow.XML_DRUG_IOW.aori = dr_set("aori")
                        Else
                            lgt_iow.XML_DRUG_IOW.aori = ""
                        End If


                        If IsNothing(dr_set("aori_description")) = False Then
                            lgt_iow.XML_DRUG_IOW.aori_description = dr_set("aori_description")
                        Else
                            lgt_iow.XML_DRUG_IOW.aori_description = ""
                        End If

                        If IsNothing(dr_set("remark")) = False Then
                            lgt_iow.XML_DRUG_IOW.remark = dr_set("remark")
                        Else
                            lgt_iow.XML_DRUG_IOW.remark = ""
                        End If


                        If IsNothing(dr_set("cncnm")) = False Then
                            lgt_iow.XML_DRUG_IOW.cncnm = dr_set("cncnm")
                        Else
                            lgt_iow.XML_DRUG_IOW.cncnm = ""
                        End If



                        If IsNothing(dr_set("licen_loca")) = False Then
                            lgt_iow.XML_DRUG_IOW.licen_loca = dr_set("licen_loca")
                        Else
                            lgt_iow.XML_DRUG_IOW.licen_loca = ""
                        End If

                        If IsNothing(dr_set("Newcode_U")) = False Then
                            lgt_iow.XML_DRUG_IOW.Newcode_U = dr_set("Newcode_U")
                        Else
                            lgt_iow.XML_DRUG_IOW.Newcode_U = ""
                        End If


                        If IsNothing(dr_set("Newcode_rid")) = False Then
                            lgt_iow.XML_DRUG_IOW.Newcode_rid = dr_set("Newcode_rid")
                        Else
                            lgt_iow.XML_DRUG_IOW.Newcode_rid = ""
                        End If

                        If IsNothing(dr_set("Newcode_R")) = False Then
                            lgt_iow.XML_DRUG_IOW.Newcode_R = dr_set("Newcode_R")
                        Else
                            lgt_iow.XML_DRUG_IOW.Newcode_R = ""
                        End If



                        If IsNothing(dr_set("RoleinFomular")) = False Then
                            lgt_iow.XML_DRUG_IOW.RoleinFomular = dr_set("RoleinFomular")
                        Else
                            lgt_iow.XML_DRUG_IOW.RoleinFomular = ""
                        End If

                        If IsNothing(dr_set("ConditionContent")) = False Then
                            lgt_iow.XML_DRUG_IOW.ConditionContent = dr_set("ConditionContent")
                        Else
                            lgt_iow.XML_DRUG_IOW.ConditionContent = ""
                        End If


                        If IsNothing(dr_set("MultiplyNumberStart")) = False Then
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberStart = dr_set("MultiplyNumberStart")
                        Else
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberStart = ""
                        End If


                        If IsNothing(dr_set("BaseNumberStart")) = False Then
                            lgt_iow.XML_DRUG_IOW.BaseNumberStart = dr_set("BaseNumberStart")
                        Else
                            lgt_iow.XML_DRUG_IOW.BaseNumberStart = ""
                        End If



                        If IsNothing(dr_set("PowerNumberStart")) = False Then
                            lgt_iow.XML_DRUG_IOW.PowerNumberStart = dr_set("PowerNumberStart")
                        Else
                            lgt_iow.XML_DRUG_IOW.PowerNumberStart = ""
                        End If




                        If IsNothing(dr_set("MultiplyNumberEND")) = False Then
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberEND = dr_set("MultiplyNumberEND")
                        Else
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberEND = ""
                        End If

                        If IsNothing(dr_set("BaseNumberEND")) = False Then
                            lgt_iow.XML_DRUG_IOW.BaseNumberEND = dr_set("BaseNumberEND")
                        Else
                            lgt_iow.XML_DRUG_IOW.BaseNumberEND = ""
                        End If


                        If IsNothing(dr_set("PowerNumberEND")) = False Then
                            lgt_iow.XML_DRUG_IOW.PowerNumberEND = dr_set("PowerNumberEND")
                        Else
                            lgt_iow.XML_DRUG_IOW.PowerNumberEND = ""
                        End If


                        If IsNothing(dr_set("UnitForRangeContent")) = False Then
                            lgt_iow.XML_DRUG_IOW.UnitForRangeContent = dr_set("UnitForRangeContent")
                        Else
                            lgt_iow.XML_DRUG_IOW.UnitForRangeContent = ""
                        End If
                        If IsNothing(dr_set("IDA_DRRGT_DETAIL_CAS")) = False Then
                            lgt_iow.XML_DRUG_IOW.IDA_DRRGT_DETAIL_CAS = dr_set("IDA_DRRGT_DETAIL_CAS")
                        Else
                            lgt_iow.XML_DRUG_IOW.IDA_DRRGT_DETAIL_CAS = 0
                        End If

                        Dim dt_eq As New DataTable
                        Dim bao_eq As New BAO.ClsDBSqlcommand
                        Try
                            dt_eq = bao_eq.SP_XML_DRUG_IOW_EQ_BY_FK_IDA_FK_SET(dr_set("IDA"), dr_set("flineno"))
                        Catch ex As Exception

                        End Try


                        'Dim dao_iow_eq As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW_EQ  ' ถ้าเป็น List of2 ต้องใช้อันนี้ และ การที่นำเข้ามาไว้ใน next คือ List ซ้อน List  ชื่อสารที่อยู่ในแต่ละผลิตภัณฑ์ย่อย
                        'dao_iow_eq.GetDataby_Newcode_RID(dao_iow.fields.Newcode_rid)

                        For Each dr_eq As DataRow In dt_eq.Rows
                            Dim lgt_eq As New LGT_IOW_EQ_TO                            ' XML_CMT_TYPE2 คือตารางชื่อสาร  

                            lgt_eq.XML_DRUG_IOW_EQ.IDA = dr_eq("IDA")
                            If IsNothing(dr_eq("IDA")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.IDA = dr_eq("IDA")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.IDA = 0
                            End If



                            If IsNothing(dr_eq("pvncd")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.pvncd = dr_eq("pvncd")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.pvncd = ""
                            End If


                            If IsNothing(dr_eq("drgtpcd")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgtpcd = dr_eq("drgtpcd")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgtpcd = ""
                            End If

                            If IsNothing(dr_eq("rgttpcd")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.rgttpcd = dr_eq("rgttpcd")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.rgttpcd = ""
                            End If

                            If IsNothing(dr_eq("rgtno")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.rgtno = dr_eq("rgtno")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.rgtno = ""
                            End If

                            If IsNothing(dr_eq("lcnno")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.lcnno = dr_eq("lcnno")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.lcnno = ""
                            End If

                            If IsNothing(dr_eq("register")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.register = dr_eq("register")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.register = ""
                            End If

                            If IsNothing(dr_eq("CITIZEN_AUTHORIZE")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.CITIZEN_AUTHORIZE = dr_eq("CITIZEN_AUTHORIZE")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.CITIZEN_AUTHORIZE = ""
                            End If

                            If IsNothing(dr_eq("thadrgnm")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.thadrgnm = dr_eq("thadrgnm")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.thadrgnm = ""
                            End If


                            If IsNothing(dr_eq("engdrgnm")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.engdrgnm = dr_eq("engdrgnm")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.engdrgnm = ""
                            End If

                            If IsNothing(dr_eq("flineno")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.flineno = dr_eq("flineno")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.flineno = ""
                            End If

                            If IsNothing(dr_eq("drgqty")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgqty = dr_eq("drgqty")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgqty = ""
                            End If


                            If IsNothing(dr_eq("drgperunit")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgperunit = dr_eq("drgperunit")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgperunit = ""
                            End If

                            If IsNothing(dr_eq("drgcdt")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt = dr_eq("drgcdt")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt = ""
                            End If

                            If IsNothing(dr_eq("drgcdt_condition")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt_condition = dr_eq("drgcdt_condition")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt_condition = ""
                            End If


                            If IsNothing(dr_eq("rid")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.rid = dr_eq("rid")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.rid = ""
                            End If

                            If IsNothing(dr_eq("elineno")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.elineno = dr_eq("elineno")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.elineno = ""
                            End If

                            If IsNothing(dr_eq("iowacd")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.iowacd = dr_eq("iowacd")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.iowacd = ""
                            End If


                            If IsNothing(dr_eq("iowanm")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.iowanm = dr_eq("iowanm")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.iowanm = ""
                            End If

                            If IsNothing(dr_eq("SinggleContent")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.SinggleContent = dr_eq("SinggleContent")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.SinggleContent = ""
                            End If

                            If IsNothing(dr_eq("UnitForSinggleContent")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForSinggleContent = dr_eq("UnitForSinggleContent")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForSinggleContent = ""
                            End If


                            If IsNothing(dr_eq("qty")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.qty = dr_eq("qty")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.qty = ""
                            End If

                            If IsNothing(dr_eq("ConditionContent")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.ConditionContent = dr_eq("ConditionContent")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.ConditionContent = ""
                            End If

                            If IsNothing(dr_eq("MultiplyNumberStart")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberStart = dr_eq("MultiplyNumberStart")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberStart = ""
                            End If


                            If IsNothing(dr_eq("BaseNumberStart")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberStart = dr_eq("BaseNumberStart")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberStart = ""
                            End If

                            If IsNothing(dr_eq("PowerNumberStart")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberStart = dr_eq("PowerNumberStart")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberStart = ""
                            End If

                            If IsNothing(dr_eq("MultiplyNumberEND")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberEND = dr_eq("MultiplyNumberEND")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberEND = ""
                            End If


                            If IsNothing(dr_eq("BaseNumberEND")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberEND = dr_eq("BaseNumberEND")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberEND = ""
                            End If

                            If IsNothing(dr_eq("PowerNumberEND")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberEND = dr_eq("PowerNumberEND")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberEND = ""
                            End If

                            If IsNothing(dr_eq("UnitForRangeContent")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForRangeContent = dr_eq("UnitForRangeContent")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForRangeContent = ""
                            End If


                            If IsNothing(dr_eq("aori")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.aori = dr_eq("aori")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.aori = ""
                            End If

                            If IsNothing(dr_eq("Newcode")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode = dr_eq("Newcode")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode = ""
                            End If

                            If IsNothing(dr_eq("Newcode_rid")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_rid = dr_eq("Newcode_rid")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_rid = ""
                            End If


                            If IsNothing(dr_eq("Newcode_R")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_R = dr_eq("Newcode_R")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_R = ""
                            End If

                            If IsNothing(dr_eq("licen_loca")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.licen_loca = dr_eq("licen_loca")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.licen_loca = ""
                            End If

                            If IsNothing(dr_eq("thaclassnm")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.thaclassnm = dr_eq("thaclassnm")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.thaclassnm = ""
                            End If


                            If IsNothing(dr_eq("cncnm")) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.cncnm = dr_eq("cncnm")
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.cncnm = ""
                            End If
                            XML_DRUG_IOW_TO1.LGT_IOW_EQ_TO.Add(lgt_eq)
                            'lgt_iow.LGT_IOW_EQ_TO.Add(lgt_eq)

                        Next
                        XML_DRUG_IOW_TO1.XML_DRUG_IOW = lgt_iow.XML_DRUG_IOW

                        XML_DRUG_IOW_TYPE1.XML_DRUG_IOW_TO.Add(XML_DRUG_IOW_TO1)
                        'class_xml.LGT_IOW_EQ.Add(lgt_iow)

                        XML_DRUG_IOW_TO1 = New XML_DRUG_IOW_TO
                    Next


                    class_xml.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Add(XML_DRUG_IOW_TYPE1)
                    XML_DRUG_IOW_TYPE1 = New XML_DRUG_IOW_TYPE
                Next
                '#End Region
                '#Region "ชื่อผู้ผลิตต่างประเทศ"
                '-----------------------ชื่อผู้ผลิตต่างประเทศ
                Dim dt_frgn As New DataTable
                Dim bao_frgn As New BAO.ClsDBSqlcommand
                Try
                    dt_frgn = bao_frgn.SP_XML_DRUG_FRGN_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_FRGN As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_FRGN  'คือตารางผู้ผลิตต่างประเทศและในประเทศรวมกัน
                'dao_FRGN.GetDataby_Newcode(dao_dr.fields.Newcode_U)

                For Each dr_frgn As DataRow In dt_frgn.Rows
                    Dim lgt_frgn As New LGT_XML_FRGN_ALL_TO
                    lgt_frgn.XML_DRUG_FRGN.IDA = dr_frgn("IDA")


                    If IsNothing(dr_frgn("pvncd")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.pvncd = dr_frgn("pvncd")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.pvncd = ""
                    End If
                    If IsNothing(dr_frgn("drgtpcd")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.drgtpcd = dr_frgn("drgtpcd")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.drgtpcd = ""
                    End If

                    If IsNothing(dr_frgn("rgttpcd")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.rgttpcd = dr_frgn("rgttpcd")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.rgttpcd = ""
                    End If
                    If IsNothing(dr_frgn("rgtno")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.rgtno = dr_frgn("rgtno")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.rgtno = ""
                    End If



                    If IsNothing(dr_frgn("thadrgnm")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.thadrgnm = dr_frgn("thadrgnm")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.thadrgnm = ""
                    End If

                    If IsNothing(dr_frgn("engdrgnm")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engdrgnm = dr_frgn("engdrgnm")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engdrgnm = ""
                    End If
                    If IsNothing(dr_frgn("lcnsid")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lcnsid = dr_frgn("lcnsid")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lcnsid = ""
                    End If
                    If IsNothing(dr_frgn("CITIZEN_AUTHORIZE")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.CITIZEN_AUTHORIZE = dr_frgn("CITIZEN_AUTHORIZE")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.CITIZEN_AUTHORIZE = ""
                    End If

                    If IsNothing(dr_frgn("lcnno")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lcnno = dr_frgn("lcnno")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lcnno = ""
                    End If


                    If IsNothing(dr_frgn("thanm")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.thanm = dr_frgn("thanm")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.thanm = ""
                    End If


                    If IsNothing(dr_frgn("fulladdr")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.fulladdr = dr_frgn("fulladdr")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.fulladdr = ""
                    End If


                    If IsNothing(dr_frgn("engfrgnnm")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm = dr_frgn("engfrgnnm")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm = ""
                    End If

                    If IsNothing(dr_frgn("engfrgnnm_all")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm_all = dr_frgn("engfrgnnm_all")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm_all = ""
                    End If


                    If IsNothing(dr_frgn("offengnm")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.offengnm = dr_frgn("offengnm")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.offengnm = ""
                    End If

                    If IsNothing(dr_frgn("engcntnm")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engcntnm = dr_frgn("engcntnm")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engcntnm = ""
                    End If

                    If IsNothing(dr_frgn("funccd")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.funccd = dr_frgn("funccd")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.funccd = ""
                    End If

                    If IsNothing(dr_frgn("funcnm")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.funcnm = dr_frgn("funcnm")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.funcnm = ""
                    End If

                    If IsNothing(dr_frgn("addr")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.addr = dr_frgn("addr")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.addr = ""
                    End If

                    If IsNothing(dr_frgn("room")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.room = dr_frgn("room")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.room = ""
                    End If


                    If IsNothing(dr_frgn("floor")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.floor = dr_frgn("floor")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.floor = ""
                    End If


                    If IsNothing(dr_frgn("building")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.building = dr_frgn("building")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.building = ""
                    End If

                    If IsNothing(dr_frgn("soi")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.soi = dr_frgn("soi")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.soi = ""
                    End If

                    If IsNothing(dr_frgn("road")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.road = dr_frgn("road")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.road = ""
                    End If

                    If IsNothing(dr_frgn("mu")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.mu = dr_frgn("mu")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.mu = ""
                    End If

                    If IsNothing(dr_frgn("district")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.district = dr_frgn("district")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.district = ""
                    End If

                    If IsNothing(dr_frgn("subdiv")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.subdiv = dr_frgn("subdiv")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.subdiv = ""
                    End If


                    If IsNothing(dr_frgn("Province")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.Province = dr_frgn("Province")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.Province = ""
                    End If

                    If IsNothing(dr_frgn("zipcode")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.zipcode = dr_frgn("zipcode")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.zipcode = ""
                    End If

                    If IsNothing(dr_frgn("tel")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.tel = dr_frgn("tel")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.tel = ""
                    End If

                    If IsNothing(dr_frgn("fax")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.fax = dr_frgn("fax")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.fax = ""
                    End If


                    If IsNothing(dr_frgn("Newcode")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.Newcode = dr_frgn("Newcode")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.Newcode = ""
                    End If

                    If IsNothing(dr_frgn("Newcode_U")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.Newcode_U = dr_frgn("Newcode_U")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.Newcode_U = ""
                    End If


                    If IsNothing(dr_frgn("lcnsid_drpdcin")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lcnsid_drpdcin = dr_frgn("lcnsid_drpdcin")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lcnsid_drpdcin = ""
                    End If


                    If IsNothing(dr_frgn("lctnmcd_drpdcin")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lctnmcd_drpdcin = dr_frgn("lctnmcd_drpdcin")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lctnmcd_drpdcin = ""
                    End If


                    If IsNothing(dr_frgn("lctcd_drpdcin")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lctcd_drpdcin = dr_frgn("lctcd_drpdcin")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lctcd_drpdcin = ""
                    End If
                    If IsNothing(dr_frgn("rid")) = False Then
                        lgt_frgn.XML_DRUG_FRGN.rid = dr_frgn("rid")
                    Else
                        lgt_frgn.XML_DRUG_FRGN.rid = ""
                    End If

                    class_xml.LGT_XML_FRGN_ALL_TO.Add(lgt_frgn)
                Next
                '#End Region
                '#Region "ชื่อยาเพื่อการส่งออก"
                '-----------------------ชื่อยาเพื่อการส่งออก
                Dim dt_ex As New DataTable
                Dim bao_ex As New BAO.ClsDBSqlcommand
                Try
                    dt_ex = bao_ex.SP_XML_DRUG_EXPORT_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_export As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_EXPORT  'คือตารางผู้ผลิตต่างประเทศและในประเทศรวมกัน
                'dao_export.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dt_ex.Rows.Count <> 0 Then

                    For Each dr_ex As DataRow In dt_ex.Rows
                        Dim lgt_export As New LGT_XML_DRUG_EXPORT

                        If IsNothing(dr_ex("IDA")) = False Then
                            lgt_export.XML_DRUG_EXPORT.IDA = dr_ex("IDA")
                        Else
                            lgt_export.XML_DRUG_EXPORT.IDA = 0
                        End If


                        If IsNothing(dr_ex("pvncd")) = False Then
                            lgt_export.XML_DRUG_EXPORT.pvncd = dr_ex("pvncd")
                        Else
                            lgt_export.XML_DRUG_EXPORT.pvncd = ""
                        End If

                        If IsNothing(dr_ex("drgtpcd")) = False Then
                            lgt_export.XML_DRUG_EXPORT.drgtpcd = dr_ex("drgtpcd")
                        Else
                            lgt_export.XML_DRUG_EXPORT.drgtpcd = ""
                        End If
                        If IsNothing(dr_ex("rgttpcd")) = False Then
                            lgt_export.XML_DRUG_EXPORT.rgttpcd = dr_ex("rgttpcd")
                        Else
                            lgt_export.XML_DRUG_EXPORT.rgttpcd = ""
                        End If

                        If IsNothing(dr_ex("rgtno")) = False Then
                            lgt_export.XML_DRUG_EXPORT.rgtno = dr_ex("rgtno")
                        Else
                            lgt_export.XML_DRUG_EXPORT.rgtno = ""
                        End If
                        If IsNothing(dr_ex("lcnno")) = False Then
                            lgt_export.XML_DRUG_EXPORT.lcnno = dr_ex("lcnno")
                        Else
                            lgt_export.XML_DRUG_EXPORT.lcnno = ""
                        End If

                        If IsNothing(dr_ex("rcvno")) = False Then
                            lgt_export.XML_DRUG_EXPORT.rcvno = dr_ex("rcvno")
                        Else
                            lgt_export.XML_DRUG_EXPORT.rcvno = ""
                        End If

                        If IsNothing(dr_ex("rid")) = False Then
                            lgt_export.XML_DRUG_EXPORT.rid = dr_ex("rid")
                        Else
                            lgt_export.XML_DRUG_EXPORT.rid = ""
                        End If

                        If IsNothing(dr_ex("drgexp")) = False Then
                            lgt_export.XML_DRUG_EXPORT.drgexp = dr_ex("drgexp")
                        Else
                            lgt_export.XML_DRUG_EXPORT.drgexp = ""
                        End If

                        If IsNothing(dr_ex("engcntnm")) = False Then
                            lgt_export.XML_DRUG_EXPORT.engcntnm = dr_ex("engcntnm")
                        Else
                            lgt_export.XML_DRUG_EXPORT.engcntnm = ""
                        End If


                        If IsNothing(dr_ex("cntcd")) = False Then
                            lgt_export.XML_DRUG_EXPORT.cntcd = dr_ex("cntcd")
                        Else
                            lgt_export.XML_DRUG_EXPORT.cntcd = ""
                        End If

                        If IsNothing(dr_ex("Newcode")) = False Then
                            lgt_export.XML_DRUG_EXPORT.Newcode = dr_ex("Newcode")
                        Else
                            lgt_export.XML_DRUG_EXPORT.Newcode = ""
                        End If
                        class_xml.LGT_XML_DRUG_EXPORT.Add(lgt_export)
                    Next
                Else


                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_export1 As New LGT_XML_DRUG_EXPORT

                    lgt_export1.XML_DRUG_EXPORT.IDA = 0
                    lgt_export1.XML_DRUG_EXPORT.drgtpcd = ""
                    lgt_export1.XML_DRUG_EXPORT.rgttpcd = ""
                    lgt_export1.XML_DRUG_EXPORT.rgtno = ""
                    lgt_export1.XML_DRUG_EXPORT.rcvno = ""
                    lgt_export1.XML_DRUG_EXPORT.rid = ""
                    lgt_export1.XML_DRUG_EXPORT.drgexp = ""
                    lgt_export1.XML_DRUG_EXPORT.cntcd = ""
                    lgt_export1.XML_DRUG_EXPORT.Newcode = ""
                    class_xml.LGT_XML_DRUG_EXPORT.Add(lgt_export1)
                    'Next


                End If
                '#End Region
                '#Region "สียา"
                '-----------------------สียา
                Dim dt_color As New DataTable
                Dim bao_color As New BAO.ClsDBSqlcommand
                'Dim dao_color As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_COLOR
                'dao_color.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                Try
                    dt_color = bao_color.SP_XML_DRUG_COLOR_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                If dt_color.Rows.Count <> 0 Then

                    For Each drcolor As DataRow In dt_color.Rows
                        Dim lgt_color As New LGT_XML_DRUG_COLOR

                        If IsNothing(drcolor("IDA")) = False Then
                            lgt_color.XML_DRUG_COLOR.IDA = drcolor("IDA")
                        Else
                            lgt_color.XML_DRUG_COLOR.IDA = 0
                        End If

                        If IsNothing(drcolor("pvncd")) = False Then
                            lgt_color.XML_DRUG_COLOR.pvncd = drcolor("pvncd")
                        Else
                            lgt_color.XML_DRUG_COLOR.pvncd = ""
                        End If


                        If IsNothing(drcolor("drgtpcd")) = False Then
                            lgt_color.XML_DRUG_COLOR.drgtpcd = drcolor("drgtpcd")
                        Else
                            lgt_color.XML_DRUG_COLOR.drgtpcd = ""
                        End If

                        If IsNothing(drcolor("rgttpcd")) = False Then
                            lgt_color.XML_DRUG_COLOR.rgttpcd = drcolor("rgttpcd")
                        Else
                            lgt_color.XML_DRUG_COLOR.rgttpcd = ""
                        End If

                        If IsNothing(drcolor("rgtno")) = False Then
                            lgt_color.XML_DRUG_COLOR.rgtno = drcolor("rgtno")
                        Else
                            lgt_color.XML_DRUG_COLOR.rgtno = ""
                        End If
                        If IsNothing(drcolor("lcnno")) = False Then
                            lgt_color.XML_DRUG_COLOR.lcnno = drcolor("lcnno")
                        Else
                            lgt_color.XML_DRUG_COLOR.lcnno = ""
                        End If

                        If IsNothing(drcolor("rid")) = False Then
                            lgt_color.XML_DRUG_COLOR.rid = drcolor("rid")
                        Else
                            lgt_color.XML_DRUG_COLOR.rid = ""
                        End If
                        If IsNothing(drcolor("seqno")) = False Then
                            lgt_color.XML_DRUG_COLOR.seqno = drcolor("seqno")
                        Else
                            lgt_color.XML_DRUG_COLOR.seqno = ""
                        End If

                        If IsNothing(drcolor("drgchrtha")) = False Then
                            lgt_color.XML_DRUG_COLOR.drgchrtha = drcolor("drgchrtha")
                        Else
                            lgt_color.XML_DRUG_COLOR.drgchrtha = ""
                        End If

                        If IsNothing(drcolor("drgchreng")) = False Then
                            lgt_color.XML_DRUG_COLOR.drgchreng = drcolor("drgchreng")
                        Else
                            lgt_color.XML_DRUG_COLOR.drgchreng = ""
                        End If

                        If IsNothing(drcolor("Newcode")) = False Then
                            lgt_color.XML_DRUG_COLOR.Newcode = drcolor("Newcode")
                        Else
                            lgt_color.XML_DRUG_COLOR.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_COLOR.Add(lgt_color)
                    Next
                Else


                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_color1 As New LGT_XML_DRUG_COLOR

                    lgt_color1.XML_DRUG_COLOR.IDA = 0
                    lgt_color1.XML_DRUG_COLOR.pvncd = ""
                    lgt_color1.XML_DRUG_COLOR.drgtpcd = ""
                    lgt_color1.XML_DRUG_COLOR.rgttpcd = ""
                    lgt_color1.XML_DRUG_COLOR.rgtno = ""
                    lgt_color1.XML_DRUG_COLOR.seqno = ""
                    lgt_color1.XML_DRUG_COLOR.drgchrtha = ""
                    lgt_color1.XML_DRUG_COLOR.drgchreng = ""
                    lgt_color1.XML_DRUG_COLOR.Newcode = ""
                    lgt_color1.XML_DRUG_COLOR.rid = ""

                    class_xml.LGT_XML_DRUG_COLOR.Add(lgt_color1)
                    'Next


                End If
                '#End Region
                '#Region "ผู้แทนจำหน่าย"
                '------------------------ผู้แทนจำหน่าย
                Dim dt_dtb As New DataTable
                Dim bao_dtb As New BAO.ClsDBSqlcommand

                Try
                    dt_dtb = bao_dtb.SP_XML_DRUG_AGENT_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_agent As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_AGENT
                'dao_agent.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dt_dtb.Rows.Count <> 0 Then

                    For Each dr_dtb As DataRow In dt_dtb.Rows
                        Dim lgt_agent As New LGT_XML_DRUG_AGENT

                        If IsNothing(dr_dtb("IDA")) = False Then
                            lgt_agent.XML_DRUG_AGENT.IDA = dr_dtb("IDA")
                        Else
                            lgt_agent.XML_DRUG_AGENT.IDA = 0
                        End If

                        If IsNothing(dr_dtb("drgtpcd")) = False Then
                            lgt_agent.XML_DRUG_AGENT.drgtpcd = dr_dtb("drgtpcd")
                        Else
                            lgt_agent.XML_DRUG_AGENT.drgtpcd = ""
                        End If

                        If IsNothing(dr_dtb("rgttpcd")) = False Then
                            lgt_agent.XML_DRUG_AGENT.rgttpcd = dr_dtb("rgttpcd")
                        Else
                            lgt_agent.XML_DRUG_AGENT.rgttpcd = ""
                        End If

                        If IsNothing(dr_dtb("rgtno")) = False Then
                            lgt_agent.XML_DRUG_AGENT.rgtno = dr_dtb("rgtno")
                        Else
                            lgt_agent.XML_DRUG_AGENT.rgtno = ""
                        End If

                        If IsNothing(dr_dtb("rcvno")) = False Then
                            lgt_agent.XML_DRUG_AGENT.rcvno = dr_dtb("rcvno")
                        Else
                            lgt_agent.XML_DRUG_AGENT.rcvno = ""
                        End If

                        If IsNothing(dr_dtb("lcnno")) = False Then
                            lgt_agent.XML_DRUG_AGENT.lcnno = dr_dtb("lcnno")
                        Else
                            lgt_agent.XML_DRUG_AGENT.lcnno = ""
                        End If

                        If IsNothing(dr_dtb("lcnno_no")) = False Then
                            lgt_agent.XML_DRUG_AGENT.lcnno_no = dr_dtb("lcnno_no")
                        Else
                            lgt_agent.XML_DRUG_AGENT.lcnno_no = ""
                        End If

                        If IsNothing(dr_dtb("identify")) = False Then
                            lgt_agent.XML_DRUG_AGENT.identify = dr_dtb("identify")
                        Else
                            lgt_agent.XML_DRUG_AGENT.identify = ""
                        End If
                        If IsNothing(dr_dtb("rid")) = False Then
                            lgt_agent.XML_DRUG_AGENT.rid = dr_dtb("rid")
                        Else
                            lgt_agent.XML_DRUG_AGENT.rid = ""
                        End If

                        If IsNothing(dr_dtb("agent")) = False Then
                            lgt_agent.XML_DRUG_AGENT.agent = dr_dtb("agent")
                        Else
                            lgt_agent.XML_DRUG_AGENT.agent = ""
                        End If

                        If IsNothing(dr_dtb("addr")) = False Then
                            lgt_agent.XML_DRUG_AGENT.addr = dr_dtb("addr")
                        Else
                            lgt_agent.XML_DRUG_AGENT.addr = ""
                        End If

                        If IsNothing(dr_dtb("tel")) = False Then
                            lgt_agent.XML_DRUG_AGENT.tel = dr_dtb("tel")
                        Else
                            lgt_agent.XML_DRUG_AGENT.tel = ""
                        End If

                        If IsNothing(dr_dtb("province")) = False Then
                            lgt_agent.XML_DRUG_AGENT.province = dr_dtb("province")
                        Else
                            lgt_agent.XML_DRUG_AGENT.province = ""
                        End If

                        If IsNothing(dr_dtb("Newcode")) = False Then
                            lgt_agent.XML_DRUG_AGENT.Newcode = dr_dtb("Newcode")
                        Else
                            lgt_agent.XML_DRUG_AGENT.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_AGENT.Add(lgt_agent)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_agent1 As New LGT_XML_DRUG_AGENT

                    lgt_agent1.XML_DRUG_AGENT.IDA = 0
                    lgt_agent1.XML_DRUG_AGENT.pvncd = ""
                    lgt_agent1.XML_DRUG_AGENT.drgtpcd = ""
                    lgt_agent1.XML_DRUG_AGENT.rgttpcd = ""
                    lgt_agent1.XML_DRUG_AGENT.rgtno = ""
                    lgt_agent1.XML_DRUG_AGENT.rcvno = ""
                    lgt_agent1.XML_DRUG_AGENT.lcnno = ""
                    lgt_agent1.XML_DRUG_AGENT.lcnno_no = ""
                    lgt_agent1.XML_DRUG_AGENT.identify = ""
                    lgt_agent1.XML_DRUG_AGENT.rid = ""
                    lgt_agent1.XML_DRUG_AGENT.agent = ""
                    lgt_agent1.XML_DRUG_AGENT.addr = ""
                    lgt_agent1.XML_DRUG_AGENT.tel = ""
                    lgt_agent1.XML_DRUG_AGENT.province = ""
                    lgt_agent1.XML_DRUG_AGENT.Newcode = ""


                    class_xml.LGT_XML_DRUG_AGENT.Add(lgt_agent1)
                    'Next
                End If
                '#End Region
                '#Region "แก้ไขประวัติ"
                '---------------------------แก้ไขประวัติ
                Dim dt_edt As New DataTable
                Dim bao_edt As BAO.ClsDBSqlcommand
                Try
                    dt_edt = bao_edt.SP_DRUG_STORY_EDIT_HISTORY_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_his As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_STORY_EDIT_HISTORY
                'dao_his.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dt_edt.Rows.Count <> 0 Then

                    For Each dr_edt As DataRow In dt_edt.Rows
                        Dim lgt_his As New LGT_XML_DRUG_STORY_EDIT_HISTORY

                        If IsNothing(dr_edt("IDA")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.IDA = dr_edt("IDA")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.IDA = 0
                        End If

                        If IsNothing(dr_edt("pvncd")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.pvncd = dr_edt("pvncd")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.pvncd = ""
                        End If

                        If IsNothing(dr_edt("drgtpcd")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.drgtpcd = dr_edt("drgtpcd")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.drgtpcd = ""
                        End If

                        If IsNothing(dr_edt("rgttpcd")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgttpcd = dr_edt("rgttpcd")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgttpcd = ""
                        End If

                        If IsNothing(dr_edt("rgtno")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgtno = dr_edt("rgtno")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgtno = ""
                        End If

                        If IsNothing(dr_edt("lcnno")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.lcnno = dr_edt("lcnno")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.lcnno = ""
                        End If
                        If IsNothing(dr_edt("rcvno")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rcvno = dr_edt("rcvno")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rcvno = ""
                        End If


                        If IsNothing(dr_edt("rid")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rid = dr_edt("rid")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rid = ""
                        End If

                        If IsNothing(dr_edt("story_edit_Title")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_Title = dr_edt("story_edit_Title")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_Title = ""
                        End If

                        If IsNothing(dr_edt("story_edit_date")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_date = dr_edt("story_edit_date")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_date = Date.Now
                        End If

                        If IsNothing(dr_edt("story_edit_appdate")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_appdate = dr_edt("story_edit_appdate")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_appdate = Date.Now
                        End If

                        If IsNothing(dr_edt("story_edit_status")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_status = dr_edt("story_edit_status")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_status = ""
                        End If

                        If IsNothing(dr_edt("story_edit_desc")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_desc = dr_edt("story_edit_desc")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_desc = ""
                        End If

                        If IsNothing(dr_edt("edtcd1")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd1 = dr_edt("edtcd1")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd1 = ""
                        End If

                        If IsNothing(dr_edt("edtcd2")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd2 = dr_edt("edtcd2")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd2 = ""
                        End If

                        If IsNothing(dr_edt("edtcd3")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd3 = dr_edt("edtcd3")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd3 = ""
                        End If

                        If IsNothing(dr_edt("edtcd4")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd4 = dr_edt("edtcd4")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd4 = ""
                        End If

                        If IsNothing(dr_edt("edtcd5")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd5 = dr_edt("edtcd5")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd5 = ""
                        End If

                        If IsNothing(dr_edt("edtcd6")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd6 = dr_edt("edtcd6")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd6 = ""
                        End If
                        If IsNothing(dr_edt("edtcd7")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd7 = dr_edt("edtcd7")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd7 = ""
                        End If

                        If IsNothing(dr_edt("edtcd8")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd8 = dr_edt("edtcd8")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd8 = ""
                        End If

                        If IsNothing(dr_edt("edtcd9")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd9 = dr_edt("edtcd9")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd9 = ""
                        End If

                        If IsNothing(dr_edt("edtcd10")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd10 = dr_edt("edtcd10")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd10 = ""
                        End If

                        If IsNothing(dr_edt("edtcd11")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd11 = dr_edt("edtcd11")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd11 = ""
                        End If


                        If IsNothing(dr_edt("edtcd12")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd12 = dr_edt("edtcd12")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd12 = ""
                        End If

                        If IsNothing(dr_edt("edtcd13")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd13 = dr_edt("edtcd13")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd13 = ""
                        End If

                        If IsNothing(dr_edt("edtcd14")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = dr_edt("edtcd14")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = ""
                        End If

                        If IsNothing(dr_edt("edtcd15")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd15 = dr_edt("edtcd15")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd15 = ""
                        End If

                        If IsNothing(dr_edt("edtcd16")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd16 = dr_edt("edtcd16")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd16 = ""
                        End If

                        If IsNothing(dr_edt("edtcd17")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd17 = dr_edt("edtcd17")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd17 = ""
                        End If

                        If IsNothing(dr_edt("csnm")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.csnm = dr_edt("csnm")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.csnm = ""
                        End If
                        If IsNothing(dr_edt("dtl")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.dtl = dr_edt("dtl")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.dtl = ""
                        End If

                        If IsNothing(dr_edt("Newcode")) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.Newcode = dr_edt("Newcode")
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.Newcode = ""
                        End If

                        class_xml.LGT_XML_DRUG_STORY_EDIT_HISTORY.Add(lgt_his)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_hit1 As New LGT_XML_DRUG_STORY_EDIT_HISTORY

                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.IDA = 0
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.pvncd = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.drgtpcd = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rgttpcd = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rgtno = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rcvno = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rid = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_Title = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_date = Date.Now
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_appdate = Date.Now
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_status = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd1 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd2 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd3 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd4 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd5 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd6 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd7 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd8 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd9 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd10 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd11 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd12 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd13 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd15 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd16 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd17 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.csnm = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.dtl = ""

                    class_xml.LGT_XML_DRUG_STORY_EDIT_HISTORY.Add(lgt_hit1)
                    'Next
                End If
                '#End Region
                '#Region "เงื่อนไขการขึ้นทะเบียน"
                '----------------------------เงื่อนไขการขึ้นทะเบียน
                Dim dt_con As New DataTable
                Dim bao_con As New BAO.ClsDBSqlcommand
                Try
                    dt_con = bao_con.SP_XML_DRUG_CONDITION_TABEAN_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                'Dim dao_con_tatean As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CONDITION_TABEAN
                'dao_con_tatean.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dt_con.Rows.Count <> 0 Then

                    For Each dr_con As DataRow In dt_con.Rows
                        Dim lgt_con_tatean As New LGT_XML_DRUG_CONDITION_TABEAN

                        If IsNothing(dr_con("IDA")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.IDA = dr_con("IDA")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.IDA = 0
                        End If

                        If IsNothing(dr_con("drgtpcd")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.drgtpcd = dr_con("drgtpcd")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.drgtpcd = ""
                        End If

                        If IsNothing(dr_con("rgttpcd")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgttpcd = dr_con("rgttpcd")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgttpcd = ""
                        End If

                        If IsNothing(dr_con("rgtno")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgtno = dr_con("rgtno")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgtno = ""
                        End If
                        If IsNothing(dr_con("rid")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rid = dr_con("rid")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rid = ""
                        End If
                        If IsNothing(dr_con("CONDITION_PUBLIC")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_PUBLIC = dr_con("CONDITION_PUBLIC")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_PUBLIC = ""
                        End If

                        If IsNothing(dr_con("CONDITION_SERVANT")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_SERVANT = dr_con("CONDITION_SERVANT")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_SERVANT = ""
                        End If

                        If IsNothing(dr_con("Newcode")) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.Newcode = dr_con("Newcode")
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.Newcode = ""
                        End If

                        class_xml.LGT_XML_DRUG_CONDITION_TABEAN.Add(lgt_con_tatean)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_con_tatean1 As New LGT_XML_DRUG_CONDITION_TABEAN

                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.IDA = 0
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.pvncd = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.drgtpcd = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.rgttpcd = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.rgtno = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.rid = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.CONDITION_PUBLIC = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.CONDITION_SERVANT = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.Newcode = ""

                    class_xml.LGT_XML_DRUG_CONDITION_TABEAN.Add(lgt_con_tatean1)
                    'Next
                End If
                '#End Region
                '#Region "เอกสาร pdf"
                '-----------------------------เอกสาร pdf
                'Dim dao_doc_pdf As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_DOC_PDF
                'dao_doc_pdf.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                'If dao_doc_pdf.Details.Count <> 0 Then

                '    For Each dao_doc_pdf.fields In dao_doc_pdf.datas
                '        Dim lgt_doc_pdf As New LGT_XML_DRUG_DOC_PDF

                '        If IsNothing(dao_doc_pdf.fields.IDA) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.IDA = dao_doc_pdf.fields.IDA
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.IDA = ""
                '        End If
                '        If IsNothing(dao_doc_pdf.fields.pvncd) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.pvncd = dao_doc_pdf.fields.pvncd
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.pvncd = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.drgtpcd) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.drgtpcd = dao_doc_pdf.fields.drgtpcd
                '        Else

                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.drgtpcd = ""
                '        End If
                '        If IsNothing(dao_doc_pdf.fields.rgttpcd) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgttpcd = dao_doc_pdf.fields.rgttpcd
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgttpcd = ""
                '        End If
                '        If IsNothing(dao_doc_pdf.fields.rgtno) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgtno = dao_doc_pdf.fields.rgtno
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgtno = ""
                '        End If
                '        If IsNothing(dao_doc_pdf.fields.rid) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.rid = dao_doc_pdf.fields.rid
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.rid = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.PDF_DR_Reg) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_DR_Reg = dao_doc_pdf.fields.PDF_DR_Reg
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_DR_Reg = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.PDF_MA_Application) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_MA_Application = dao_doc_pdf.fields.PDF_MA_Application
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_MA_Application = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.PDF_Production_Process) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Production_Process = dao_doc_pdf.fields.PDF_Production_Process
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Production_Process = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.PDF_Product_information) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Product_information = dao_doc_pdf.fields.PDF_Product_information
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Product_information = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.PDF_Label) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Label = dao_doc_pdf.fields.PDF_Label
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Label = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.PDF_Amendment) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Amendment = dao_doc_pdf.fields.PDF_Amendment
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Amendment = ""
                '        End If
                '        If IsNothing(dao_doc_pdf.fields.PDF_Carnofile) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Carnofile = dao_doc_pdf.fields.PDF_Carnofile
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Carnofile = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.PDF_Drug_Imange) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Drug_Imange = dao_doc_pdf.fields.PDF_Drug_Imange
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Drug_Imange = ""
                '        End If

                '        If IsNothing(dao_doc_pdf.fields.Newcode) = False Then
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.Newcode = dao_doc_pdf.fields.Newcode
                '        Else
                '            lgt_doc_pdf.XML_DRUG_DOC_PDF.Newcode = ""
                '        End If


                '        class_xml.LGT_XML_DRUG_DOC_PDF.Add(lgt_doc_pdf)
                '    Next
                'Else

                'For Each dao_export.fields In dao_export.Details
                Dim lgt_doc_pdf1 As New LGT_XML_DRUG_DOC_PDF


                lgt_doc_pdf1.XML_DRUG_DOC_PDF.IDA = 0
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.pvncd = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.drgtpcd = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.rgttpcd = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.rgtno = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.rid = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_DR_Reg = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_MA_Application = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Production_Process = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Product_information = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Label = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Amendment = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Carnofile = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Drug_Imange = ""
                lgt_doc_pdf1.XML_DRUG_DOC_PDF.Newcode = ""
                class_xml.LGT_XML_DRUG_DOC_PDF.Add(lgt_doc_pdf1)
                'Next
                'End If
                '#End Region
                '#Region "SPC"

                '-----------------------------SPC
                Dim dao_spc As New DAO_DRUG.TB_DRRGT_SPC
                dao_spc.GetDataby_FKIDA(dao_dr.fields.Newcode_U)
                If dao_spc.fields.IDA <> 0 Then

                    For Each dao_spc.fields In dao_spc.datas
                        Dim lgt_spc As New LGT_XML_DRUG_SPC

                        If IsNothing(dao_spc.fields.IDA) = False Then
                            lgt_spc.XML_DRUG_SPC.IDA = dao_spc.fields.IDA
                        Else
                            lgt_spc.XML_DRUG_SPC.IDA = 0
                        End If
                        If IsNothing(dao_spc.fields.pvncd) = False Then
                            lgt_spc.XML_DRUG_SPC.pvncd = dao_spc.fields.pvncd
                        Else
                            lgt_spc.XML_DRUG_SPC.pvncd = ""
                        End If
                        If IsNothing(dao_spc.fields.drgtpcd) = False Then
                            lgt_spc.XML_DRUG_SPC.drgtpcd = dao_spc.fields.drgtpcd
                        Else
                            lgt_spc.XML_DRUG_SPC.drgtpcd = ""
                        End If
                        If IsNothing(dao_spc.fields.rgttpcd) = False Then
                            lgt_spc.XML_DRUG_SPC.rgttpcd = dao_spc.fields.rgttpcd
                        Else
                            lgt_spc.XML_DRUG_SPC.rgttpcd = ""
                        End If

                        If IsNothing(dao_spc.fields.rgtno) = False Then
                            lgt_spc.XML_DRUG_SPC.rgtno = dao_spc.fields.rgtno
                        Else
                            lgt_spc.XML_DRUG_SPC.rgtno = ""
                        End If

                        'If IsNothing(dao_spc.fields.rid) = False Then
                        '    lgt_spc.XML_DRUG_SPC.rid = dao_spc.fields.rid
                        'Else
                        lgt_spc.XML_DRUG_SPC.rid = ""
                        ' End If

                        If IsNothing(dao_spc.fields.SPC_Th_Name_Medicinal_Product) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = dao_spc.fields.SPC_Th_Name_Medicinal_Product
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Name_Medicinal_Product) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = dao_spc.fields.SPC_Th_Name_Medicinal_Product
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Qualitative_Quantitative_Comp) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Qualitative_Quantitative_Comp = dao_spc.fields.SPC_Th_Qualitative_Quantitative_Comp
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Qualitative_Quantitative_Comp = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Pharm_Form) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharm_Form = dao_spc.fields.SPC_Th_Pharm_Form
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharm_Form = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Clinical_Particular) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Clinical_Particular = dao_spc.fields.SPC_Th_Clinical_Particular
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Clinical_Particular = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Therapeutic_Indication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Therapeutic_Indication = dao_spc.fields.SPC_Th_Therapeutic_Indication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Therapeutic_Indication = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Th_Posology_Administration) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Posology_Administration = dao_spc.fields.SPC_Th_Posology_Administration
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Posology_Administration = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Contraindication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Contraindication = dao_spc.fields.SPC_Th_Contraindication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Contraindication = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Special_Warning) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Warning = dao_spc.fields.SPC_Th_Special_Warning
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Warning = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Interaction) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Interaction = dao_spc.fields.SPC_Th_Interaction
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Interaction = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Pregnancy_Lactation) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pregnancy_Lactation = dao_spc.fields.SPC_Th_Pregnancy_Lactation
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pregnancy_Lactation = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Ability_Drive_Machine) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Ability_Drive_Machine = dao_spc.fields.SPC_Th_Ability_Drive_Machine
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Ability_Drive_Machine = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Undesirable_Effect) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Undesirable_Effect = dao_spc.fields.SPC_Th_Undesirable_Effect
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Undesirable_Effect = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Overdose) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Overdose = dao_spc.fields.SPC_Th_Overdose
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Overdose = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Pharmaco_Properties) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaco_Properties = dao_spc.fields.SPC_Th_Pharmaco_Properties
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaco_Properties = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Th_Pharmdynamic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmdynamic = dao_spc.fields.SPC_Th_Pharmdynamic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmdynamic = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Pharmacokinetic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmacokinetic = dao_spc.fields.SPC_Th_Pharmacokinetic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmacokinetic = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Preclinical_Safety_Data) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Preclinical_Safety_Data = dao_spc.fields.SPC_Th_Preclinical_Safety_Data
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Preclinical_Safety_Data = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Pharmaceutical_Particulars) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaceutical_Particulars = dao_spc.fields.SPC_Th_Pharmaceutical_Particulars
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaceutical_Particulars = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Excipients) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Excipients = dao_spc.fields.SPC_Th_Excipients
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Excipients = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Incompatability) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Incompatability = dao_spc.fields.SPC_Th_Incompatability
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Incompatability = ""
                        End If
                        If IsNothing(dao_spc.fields.SPC_Th_Shelf_Life) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Shelf_Life = dao_spc.fields.SPC_Th_Shelf_Life
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Shelf_Life = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Special_Storage) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Storage = dao_spc.fields.SPC_Th_Special_Storage
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Storage = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Container) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Container = dao_spc.fields.SPC_Th_Container
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Container = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_MA_Holder) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Holder = dao_spc.fields.SPC_Th_MA_Holder
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Holder = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_MA_Number) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Number = dao_spc.fields.SPC_Th_MA_Number
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Number = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Date_Approve) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Approve = dao_spc.fields.SPC_Th_Date_Approve
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Approve = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Date_Revision) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Revision = dao_spc.fields.SPC_Th_Date_Revision
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Revision = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Name_Medicinal_Product) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Name_Medicinal_Product = dao_spc.fields.SPC_Eng_Name_Medicinal_Product
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Qualitative_Quantitative_Comp) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Qualitative_Quantitative_Comp = dao_spc.fields.SPC_Eng_Qualitative_Quantitative_Comp
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Qualitative_Quantitative_Comp = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Pharm_Form) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharm_Form = dao_spc.fields.SPC_Eng_Pharm_Form
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharm_Form = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Clinical_Particular) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Clinical_Particular = dao_spc.fields.SPC_Eng_Clinical_Particular
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Clinical_Particular = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Therapeutic_Indication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Therapeutic_Indication = dao_spc.fields.SPC_Eng_Therapeutic_Indication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Therapeutic_Indication = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Posology_Administration) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Posology_Administration = dao_spc.fields.SPC_Eng_Posology_Administration
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Posology_Administration = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Contraindication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Contraindication = dao_spc.fields.SPC_Eng_Contraindication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Contraindication = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Special_Warning) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Warning = dao_spc.fields.SPC_Eng_Special_Warning
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Warning = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Interaction) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = dao_spc.fields.SPC_Eng_Interaction
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = ""
                        End If
                        If IsNothing(dao_spc.fields.SPC_Eng_Interaction) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = dao_spc.fields.SPC_Eng_Interaction
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Pregnancy_Lactation) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pregnancy_Lactation = dao_spc.fields.SPC_Eng_Pregnancy_Lactation
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pregnancy_Lactation = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Ability_Drive_Machine) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Ability_Drive_Machine = dao_spc.fields.SPC_Eng_Ability_Drive_Machine
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Ability_Drive_Machine = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Undesirable_Effect) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Undesirable_Effect = dao_spc.fields.SPC_Eng_Undesirable_Effect
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Undesirable_Effect = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Overdose) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Overdose = dao_spc.fields.SPC_Eng_Overdose
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Overdose = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmaco_Properties) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaco_Properties = dao_spc.fields.SPC_Eng_Pharmaco_Properties
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaco_Properties = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmdynamic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmdynamic = dao_spc.fields.SPC_Eng_Pharmdynamic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmdynamic = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmacokinetic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmacokinetic = dao_spc.fields.SPC_Eng_Pharmacokinetic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmacokinetic = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Preclinical_Safety_Data) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Preclinical_Safety_Data = dao_spc.fields.SPC_Eng_Preclinical_Safety_Data
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Preclinical_Safety_Data = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmaceutical_Particulars) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaceutical_Particulars = dao_spc.fields.SPC_Eng_Pharmaceutical_Particulars
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaceutical_Particulars = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Excipients) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Excipients = dao_spc.fields.SPC_Eng_Excipients
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Excipients = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Incompatability) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Incompatability = dao_spc.fields.SPC_Eng_Incompatability
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Incompatability = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Shelf_Life) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Shelf_Life = dao_spc.fields.SPC_Eng_Shelf_Life
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Shelf_Life = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Special_Storage) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Storage = dao_spc.fields.SPC_Eng_Special_Storage
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Storage = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Container) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Container = dao_spc.fields.SPC_Eng_Container
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Container = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_MA_Holder) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Holder = dao_spc.fields.SPC_Eng_MA_Holder
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Holder = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Eng_MA_Number) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Number = dao_spc.fields.SPC_Eng_MA_Number
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Number = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Date_Approve) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Approve = dao_spc.fields.SPC_Eng_Date_Approve
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Approve = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Eng_Date_Revision) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Revision = dao_spc.fields.SPC_Eng_Date_Revision
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Revision = ""
                        End If


                        If IsNothing(dao_dr.fields.Newcode) = False Then
                            lgt_spc.XML_DRUG_SPC.Newcode = dao_dr.fields.Newcode
                        Else
                            lgt_spc.XML_DRUG_SPC.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_SPC.Add(lgt_spc)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_spc1 As New LGT_XML_DRUG_SPC


                    lgt_spc1.XML_DRUG_SPC.IDA = 0
                    lgt_spc1.XML_DRUG_SPC.pvncd = ""
                    lgt_spc1.XML_DRUG_SPC.drgtpcd = ""
                    lgt_spc1.XML_DRUG_SPC.rgttpcd = ""
                    lgt_spc1.XML_DRUG_SPC.rgtno = ""
                    lgt_spc1.XML_DRUG_SPC.rid = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Qualitative_Quantitative_Comp = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharm_Form = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Clinical_Particular = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Therapeutic_Indication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Posology_Administration = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Contraindication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Special_Warning = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Interaction = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pregnancy_Lactation = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Ability_Drive_Machine = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Undesirable_Effect = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Overdose = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmaco_Properties = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmdynamic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmacokinetic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Preclinical_Safety_Data = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmaceutical_Particulars = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Excipients = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Incompatability = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Shelf_Life = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Special_Storage = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Container = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_MA_Holder = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_MA_Number = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Date_Approve = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Date_Revision = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Name_Medicinal_Product = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Qualitative_Quantitative_Comp = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharm_Form = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Clinical_Particular = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Therapeutic_Indication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Posology_Administration = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Contraindication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Special_Warning = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Interaction = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pregnancy_Lactation = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Ability_Drive_Machine = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Undesirable_Effect = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Overdose = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmaco_Properties = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmdynamic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmacokinetic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Preclinical_Safety_Data = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmaceutical_Particulars = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Excipients = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Incompatability = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Shelf_Life = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Special_Storage = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Container = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_MA_Holder = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_MA_Number = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Date_Approve = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Date_Revision = ""
                    lgt_spc1.XML_DRUG_SPC.Newcode = ""


                    class_xml.LGT_XML_DRUG_SPC.Add(lgt_spc1)
                    'Next
                End If
                '#End Region
                '#Region "PI"
                '-----------------------------PI
                Dim dao_pi As New DAO_DRUG.TB_DRRGT_PI
                dao_pi.GetDataby_FKIDA(dao_rg.fields.IDA)
                If dao_pi.fields.IDA <> 0 Then

                    For Each dao_pi.fields In dao_pi.datas
                        Dim lgt_pi As New LGT_XML_DRUG_DOC_PI

                        If IsNothing(dao_pi.fields.IDA) = False Then
                            lgt_pi.XML_DRUG_PI.IDA = dao_spc.fields.IDA
                        Else
                            lgt_pi.XML_DRUG_PI.IDA = 0
                        End If
                        If IsNothing(dao_pi.fields.pvncd) = False Then
                            lgt_pi.XML_DRUG_PI.pvncd = dao_pi.fields.pvncd
                        Else
                            lgt_pi.XML_DRUG_PI.pvncd = ""
                        End If
                        If IsNothing(dao_pi.fields.drgtpcd) = False Then
                            lgt_pi.XML_DRUG_PI.drgtpcd = dao_pi.fields.drgtpcd
                        Else
                            lgt_pi.XML_DRUG_PI.drgtpcd = ""
                        End If
                        If IsNothing(dao_pi.fields.rgttpcd) = False Then
                            lgt_pi.XML_DRUG_PI.rgttpcd = dao_pi.fields.rgttpcd
                        Else
                            lgt_pi.XML_DRUG_PI.rgttpcd = ""
                        End If
                        If IsNothing(dao_pi.fields.rgtno) = False Then
                            lgt_pi.XML_DRUG_PI.rgtno = dao_pi.fields.rgtno
                        Else
                            lgt_pi.XML_DRUG_PI.rgtno = ""
                        End If
                        'If IsNothing(dao_pi.fields.rid) = False Then
                        '    lgt_pi.XML_DRUG_PI.rid = dao_pi.fields.rid
                        'Else
                        lgt_pi.XML_DRUG_PI.rid = ""
                        'End If
                        If IsNothing(dao_pi.fields.PI_Th_Name_Medicinal_Product) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Name_Medicinal_Product = dao_pi.fields.PI_Th_Name_Medicinal_Product
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Name_Medicinal_Product = ""
                        End If


                        If IsNothing(dao_pi.fields.PI_Th_Active_Ingradient_Strenght) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Active_Ingradient_Strenght = dao_pi.fields.PI_Th_Active_Ingradient_Strenght
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Product_Desc) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Product_Desc = dao_pi.fields.PI_Th_Product_Desc
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Product_Desc = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Administration) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Administration = dao_pi.fields.PI_Th_Administration
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Administration = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Contraindication) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Contraindication = dao_pi.fields.PI_Th_Contraindication
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Contraindication = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Warning_Precaution) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Warning_Precaution = dao_pi.fields.PI_Th_Warning_Precaution
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Warning_Precaution = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Interaction) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Interaction = dao_pi.fields.PI_Th_Interaction
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Interaction = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Pregnancy_Lactation) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Pregnancy_Lactation = dao_pi.fields.PI_Th_Pregnancy_Lactation
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Pregnancy_Lactation = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Undesirable_Effect) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Undesirable_Effect = dao_pi.fields.PI_Th_Undesirable_Effect
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Undesirable_Effect = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Overdose) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Overdose = dao_pi.fields.PI_Th_Overdose
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Overdose = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Storage_Condition) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Storage_Condition = dao_pi.fields.PI_Th_Storage_Condition
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Storage_Condition = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Dose_From_Packaging) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Dose_From_Packaging = dao_pi.fields.PI_Th_Dose_From_Packaging
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Dose_From_Packaging = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_MA_Holder) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Holder = dao_pi.fields.PI_Th_MA_Holder
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Holder = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_MA_Number) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Number = dao_pi.fields.PI_Th_MA_Number
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Number = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Date_Approve) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Approve = dao_pi.fields.PI_Th_Date_Approve
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Approve = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Date_Revision) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Revision = dao_pi.fields.PI_Th_Date_Revision
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Revision = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Name_Medicinal_Product) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Name_Medicinal_Product = dao_pi.fields.PI_Eng_Name_Medicinal_Product
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Active_Ingradient_Strenght) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Active_Ingradient_Strenght = dao_pi.fields.PI_Eng_Active_Ingradient_Strenght
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Product_Desc) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Product_Desc = dao_pi.fields.PI_Eng_Product_Desc
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Product_Desc = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pharmacody_Pharmacoki) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacody_Pharmacoki = dao_pi.fields.PI_Eng_Pharmacody_Pharmacoki
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacody_Pharmacoki = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pharmdynamic) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmdynamic = dao_pi.fields.PI_Eng_Pharmdynamic
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmdynamic = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pharmacokinetic) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacokinetic = dao_pi.fields.PI_Eng_Pharmacokinetic
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacokinetic = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Indication) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Indication = dao_pi.fields.PI_Eng_Indication
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Indication = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Recommend_Dose) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Recommend_Dose = dao_pi.fields.PI_Eng_Recommend_Dose
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Recommend_Dose = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Administration) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Administration = dao_pi.fields.PI_Eng_Administration
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Administration = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Contraindication) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Contraindication = dao_pi.fields.PI_Eng_Contraindication
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Contraindication = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Warning_Precaution) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Warning_Precaution = dao_pi.fields.PI_Eng_Warning_Precaution
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Warning_Precaution = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Interaction) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Interaction = dao_pi.fields.PI_Eng_Interaction
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Interaction = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pregnancy_Lactation) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pregnancy_Lactation = dao_pi.fields.PI_Eng_Pregnancy_Lactation
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pregnancy_Lactation = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Undesirable_Effect) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Undesirable_Effect = dao_pi.fields.PI_Eng_Undesirable_Effect
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Undesirable_Effect = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Overdose) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Overdose = dao_pi.fields.PI_Eng_Overdose
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Overdose = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Storage_Condition) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = dao_pi.fields.PI_Eng_Storage_Condition
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Storage_Condition) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = dao_pi.fields.PI_Eng_Storage_Condition
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Dose_From_Packaging) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Dose_From_Packaging = dao_pi.fields.PI_Eng_Dose_From_Packaging
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Dose_From_Packaging = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_MA_Holder) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Holder = dao_pi.fields.PI_Eng_MA_Holder
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Holder = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_MA_Number) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Number = dao_pi.fields.PI_Eng_MA_Number
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Number = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Date_Approve) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Approve = dao_pi.fields.PI_Eng_Date_Approve
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Approve = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Date_Revision) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Revision = dao_pi.fields.PI_Eng_Date_Revision
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Revision = ""
                        End If

                        If IsNothing(dao_dr.fields.Newcode) = False Then
                            lgt_pi.XML_DRUG_PI.Newcode = dao_dr.fields.Newcode
                        Else
                            lgt_pi.XML_DRUG_PI.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_DOC_PI.Add(lgt_pi)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_pi1 As New LGT_XML_DRUG_DOC_PI
                    lgt_pi1.XML_DRUG_PI.IDA = 0
                    lgt_pi1.XML_DRUG_PI.pvncd = ""
                    lgt_pi1.XML_DRUG_PI.drgtpcd = ""
                    lgt_pi1.XML_DRUG_PI.rgttpcd = ""
                    lgt_pi1.XML_DRUG_PI.rgtno = ""
                    lgt_pi1.XML_DRUG_PI.rid = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Name_Medicinal_Product = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Active_Ingradient_Strenght = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Product_Desc = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pharmacody_Pharmacoki = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pharmdynamic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pharmacokinetic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Indication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Recommend_Dose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Administration = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Contraindication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Warning_Precaution = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Interaction = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pregnancy_Lactation = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Undesirable_Effect = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Overdose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Storage_Condition = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Dose_From_Packaging = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_MA_Holder = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_MA_Number = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Date_Approve = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Date_Revision = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Name_Medicinal_Product = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Active_Ingradient_Strenght = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Product_Desc = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pharmacody_Pharmacoki = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pharmdynamic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pharmacokinetic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Indication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Recommend_Dose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Administration = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Contraindication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Warning_Precaution = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Interaction = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pregnancy_Lactation = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Undesirable_Effect = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Overdose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Storage_Condition = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Dose_From_Packaging = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_MA_Holder = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_MA_Number = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Date_Approve = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Date_Revision = ""
                    lgt_pi1.XML_DRUG_PI.Newcode = ""
                    class_xml.LGT_XML_DRUG_DOC_PI.Add(lgt_pi1)
                    'Next
                End If
                '#End Region
                '#Region "PIL"
                '-----------------------------PIL
                Dim dao_pil As New DAO_DRUG.TB_DRRGT_PIL
                dao_pil.GetDataby_FKIDA(dao_rg.fields.IDA)
                If dao_pil.fields.IDA <> 0 Then

                    For Each dao_pil.fields In dao_pil.datas
                        Dim lgt_pil As New LGT_XML_DRUG_DOC_PIL

                        If IsNothing(dao_pil.fields.IDA) = False Then
                            lgt_pil.XML_DRUG_PIL.IDA = dao_pil.fields.IDA
                        Else
                            lgt_pil.XML_DRUG_PIL.IDA = 0
                        End If
                        If IsNothing(dao_pil.fields.pvncd) = False Then
                            lgt_pil.XML_DRUG_PIL.pvncd = dao_pil.fields.pvncd
                        Else
                            lgt_pil.XML_DRUG_PIL.pvncd = ""
                        End If

                        If IsNothing(dao_pil.fields.drgtpcd) = False Then
                            lgt_pil.XML_DRUG_PIL.drgtpcd = dao_pil.fields.drgtpcd
                        Else
                            lgt_pil.XML_DRUG_PIL.drgtpcd = ""
                        End If

                        If IsNothing(dao_pil.fields.rgttpcd) = False Then
                            lgt_pil.XML_DRUG_PIL.rgttpcd = dao_pil.fields.rgttpcd
                        Else
                            lgt_pil.XML_DRUG_PIL.rgttpcd = ""
                        End If

                        If IsNothing(dao_pil.fields.rgtno) = False Then
                            lgt_pil.XML_DRUG_PIL.rgtno = dao_pil.fields.rgtno
                        Else
                            lgt_pil.XML_DRUG_PIL.rgtno = ""
                        End If
                        'If IsNothing(dao_pil.fields.rid) = False Then
                        '    lgt_pil.XML_DRUG_PIL.rid = dao_pil.fields.rid
                        'Else
                        lgt_pil.XML_DRUG_PIL.rid = ""
                        'End If

                        If IsNothing(dao_pil.fields.PIL_Th_Name_Medicinal_Product) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Name_Medicinal_Product = dao_pil.fields.PIL_Th_Name_Medicinal_Product
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Product_Desc) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Product_Desc = dao_pil.fields.PIL_Th_Product_Desc
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Product_Desc = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Active_Ingradient_Strenght) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Active_Ingradient_Strenght = dao_pil.fields.PIL_Th_Active_Ingradient_Strenght
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Generic_Name) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Generic_Name = dao_pil.fields.PIL_Th_Generic_Name
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Generic_Name = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Used_For) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Used_For = dao_pil.fields.PIL_Th_Used_For
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Used_For = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Not_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Not_Take = dao_pil.fields.PIL_Th_When_Not_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Not_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Avoid_For_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Avoid_For_Take = dao_pil.fields.PIL_Th_Avoid_For_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Avoid_For_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_How_to_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Take = dao_pil.fields.PIL_Th_How_to_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Miss_Dose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Miss_Dose = dao_pil.fields.PIL_Th_When_Miss_Dose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Miss_Dose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Overdose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Overdose = dao_pil.fields.PIL_Th_Overdose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Overdose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_During_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_During_Take = dao_pil.fields.PIL_Th_During_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_During_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Meet_Doctor_Urgent) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor_Urgent = dao_pil.fields.PIL_Th_When_Meet_Doctor_Urgent
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor_Urgent = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Meet_Doctor) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor = dao_pil.fields.PIL_Th_When_Meet_Doctor
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_How_to_Storage) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Storage = dao_pil.fields.PIL_Th_How_to_Storage
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Storage = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_MA_Holder) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Holder = dao_pil.fields.PIL_Th_MA_Holder
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Holder = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_MA_Number) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Number = dao_pil.fields.PIL_Th_MA_Number
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Number = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Date_Approve) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Approve = dao_pil.fields.PIL_Th_Date_Approve
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Approve = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Date_Revision) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Revision = dao_pil.fields.PIL_Th_Date_Revision
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Revision = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Name_Medicinal_Product) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Name_Medicinal_Product = dao_pil.fields.PIL_Eng_Name_Medicinal_Product
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Name_Medicinal_Product = ""
                        End If


                        If IsNothing(dao_pil.fields.PIL_Eng_Product_Desc) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Product_Desc = dao_pil.fields.PIL_Eng_Product_Desc
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Product_Desc = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Active_Ingradient_Strenght) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Active_Ingradient_Strenght = dao_pil.fields.PIL_Eng_Active_Ingradient_Strenght
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Generic_Name) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Generic_Name = dao_pil.fields.PIL_Eng_Generic_Name
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Generic_Name = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Used_For) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Used_For = dao_pil.fields.PIL_Eng_Used_For
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Used_For = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Not_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Not_Take = dao_pil.fields.PIL_Eng_When_Not_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Not_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Avoid_For_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Avoid_For_Take = dao_pil.fields.PIL_Eng_Avoid_For_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Avoid_For_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_How_to_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Take = dao_pil.fields.PIL_Eng_How_to_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Miss_Dose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Miss_Dose = dao_pil.fields.PIL_Eng_When_Miss_Dose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Miss_Dose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Overdose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Overdose = dao_pil.fields.PIL_Eng_Overdose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Overdose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_During_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_During_Take = dao_pil.fields.PIL_Eng_During_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_During_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Meet_Doctor_Urgent) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor_Urgent = dao_pil.fields.PIL_Eng_When_Meet_Doctor_Urgent
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor_Urgent = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Meet_Doctor) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor = dao_pil.fields.PIL_Eng_When_Meet_Doctor
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_How_to_Storage) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Storage = dao_pil.fields.PIL_Eng_How_to_Storage
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Storage = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_MA_Holder) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Holder = dao_pil.fields.PIL_Eng_MA_Holder
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Holder = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_MA_Number) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Number = dao_pil.fields.PIL_Eng_MA_Number
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Number = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Date_Approve) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Approve = dao_pil.fields.PIL_Eng_Date_Approve
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Approve = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Date_Revision) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Revision = dao_pil.fields.PIL_Eng_Date_Revision
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Revision = ""
                        End If

                        If IsNothing(dao_dr.fields.Newcode) = False Then
                            lgt_pil.XML_DRUG_PIL.Newcode = dao_dr.fields.Newcode
                        Else
                            lgt_pil.XML_DRUG_PIL.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_DOC_PIL.Add(lgt_pil)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_pil1 As New LGT_XML_DRUG_DOC_PIL

                    lgt_pil1.XML_DRUG_PIL.IDA = 0
                    lgt_pil1.XML_DRUG_PIL.pvncd = ""
                    lgt_pil1.XML_DRUG_PIL.drgtpcd = ""
                    lgt_pil1.XML_DRUG_PIL.rgttpcd = ""
                    lgt_pil1.XML_DRUG_PIL.rgtno = ""
                    lgt_pil1.XML_DRUG_PIL.rid = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Name_Medicinal_Product = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Product_Desc = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Active_Ingradient_Strenght = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Generic_Name = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Used_For = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Not_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Avoid_For_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_How_to_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Miss_Dose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Overdose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_During_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor_Urgent = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_How_to_Storage = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_MA_Holder = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_MA_Number = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Date_Approve = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Date_Revision = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Name_Medicinal_Product = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Product_Desc = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Active_Ingradient_Strenght = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Generic_Name = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Used_For = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Not_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Avoid_For_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_How_to_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Miss_Dose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Overdose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_During_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor_Urgent = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_How_to_Storage = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_MA_Holder = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_MA_Number = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Date_Approve = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Date_Revision = ""
                    lgt_pil1.XML_DRUG_PIL.Newcode = ""


                    class_xml.LGT_XML_DRUG_DOC_PIL.Add(lgt_pil1)
                    'Next
                End If
                '#End Region
                '#Region "SOURCE_OF_RM"
                '-----------------------------SOURCE_OF_RM
                'Dim dao_sour_rm As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_SOURCE_OF_RM
                'dao_sour_rm.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                'If dao_sour_rm.Details.Count <> 0 Then

                '    For Each dao_sour_rm.fields In dao_sour_rm.datas
                '        Dim lgt_sour_rm As New LGT_XML_DRUG_SOURCE_OF_RM

                '        If IsNothing(dao_sour_rm.fields.IDA) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.IDA = dao_sour_rm.fields.IDA
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.IDA = 0
                '        End If
                '        If IsNothing(dao_sour_rm.fields.pvncd) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.pvncd = dao_sour_rm.fields.pvncd
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.pvncd = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.drgtpcd) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.drgtpcd = dao_sour_rm.fields.drgtpcd
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.drgtpcd = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.rgttpcd) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgttpcd = dao_sour_rm.fields.rgttpcd
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgttpcd = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.rgtno) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgtno = dao_sour_rm.fields.rgtno
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgtno = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.rid) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rid = dao_sour_rm.fields.rid
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rid = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.iowacd) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowacd = dao_sour_rm.fields.iowacd
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowacd = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.iowanm) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowanm = dao_sour_rm.fields.iowanm
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowanm = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.phm15dgt) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.phm15dgt = dao_sour_rm.fields.phm15dgt
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.phm15dgt = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.engdrgnm) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engdrgnm = dao_sour_rm.fields.engdrgnm
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engdrgnm = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.engfrgnnm) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm = dao_sour_rm.fields.engfrgnnm
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.engfrgnnm_addr) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm_addr = dao_sour_rm.fields.engfrgnnm_addr
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm_addr = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.engcntnm) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engcntnm = dao_sour_rm.fields.engcntnm
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engcntnm = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.LICEN_PHM15DGT) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.LICEN_PHM15DGT = dao_sour_rm.fields.LICEN_PHM15DGT
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.LICEN_PHM15DGT = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.STANDARD_PLACE_STAPLE) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.STANDARD_PLACE_STAPLE = dao_sour_rm.fields.STANDARD_PLACE_STAPLE
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.STANDARD_PLACE_STAPLE = ""
                '        End If
                '        If IsNothing(dao_sour_rm.fields.Newcode) = False Then
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.Newcode = dao_sour_rm.fields.Newcode
                '        Else
                '            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.Newcode = ""
                '        End If

                '        class_xml.LGT_XML_DRUG_SOURCE_OF_RM.Add(lgt_sour_rm)
                '    Next
                'Else

                'For Each dao_export.fields In dao_export.Details
                Dim lgt_sour_rm1 As New LGT_XML_DRUG_SOURCE_OF_RM


                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.IDA = 0
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.pvncd = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.drgtpcd = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.rgttpcd = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.rgtno = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.rid = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.iowacd = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.iowanm = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.phm15dgt = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engdrgnm = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engfrgnnm = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engfrgnnm_addr = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engcntnm = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.LICEN_PHM15DGT = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.STANDARD_PLACE_STAPLE = ""
                lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.Newcode = ""
                class_xml.LGT_XML_DRUG_SOURCE_OF_RM.Add(lgt_sour_rm1)
                'Next
                'End If
                '#End Region
                '#Region "รหัสยา"
                '-----------------------------รหัสยา
                'Dim dao_code As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CODE
                'dao_code.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                'If dao_code.Details.Count <> 0 Then

                '    For Each dao_code.fields In dao_code.datas
                '        Dim lgt_code As New LGT_XML_DRUG_CODE

                '        If IsNothing(dao_code.fields.IDA) = False Then
                '            lgt_code.XML_DRUG_CODE.IDA = dao_code.fields.IDA
                '        Else
                '            lgt_code.XML_DRUG_CODE.IDA = 0
                '        End If
                '        If IsNothing(dao_code.fields.pvncd) = False Then
                '            lgt_code.XML_DRUG_CODE.pvncd = dao_code.fields.pvncd
                '        Else
                '            lgt_code.XML_DRUG_CODE.pvncd = ""
                '        End If
                '        If IsNothing(dao_code.fields.drgtpcd) = False Then
                '            lgt_code.XML_DRUG_CODE.drgtpcd = dao_code.fields.drgtpcd
                '        Else
                '            lgt_code.XML_DRUG_CODE.drgtpcd = ""
                '        End If
                '        If IsNothing(dao_code.fields.rgttpcd) = False Then
                '            lgt_code.XML_DRUG_CODE.rgttpcd = dao_code.fields.rgttpcd
                '        Else
                '            lgt_code.XML_DRUG_CODE.rgttpcd = ""
                '        End If
                '        If IsNothing(dao_code.fields.rgtno) = False Then
                '            lgt_code.XML_DRUG_CODE.rgtno = dao_code.fields.rgtno
                '        Else
                '            lgt_code.XML_DRUG_CODE.rgtno = ""
                '        End If
                '        If IsNothing(dao_code.fields.rid) = False Then
                '            lgt_code.XML_DRUG_CODE.rid = dao_code.fields.rid
                '        Else
                '            lgt_code.XML_DRUG_CODE.rid = ""
                '        End If
                '        If IsNothing(dao_code.fields.CODE_DL) = False Then
                '            lgt_code.XML_DRUG_CODE.CODE_DL = dao_code.fields.CODE_DL
                '        Else
                '            lgt_code.XML_DRUG_CODE.CODE_DL = ""
                '        End If
                '        If IsNothing(dao_code.fields.CODE_ECTD_IDENIFIER) = False Then
                '            lgt_code.XML_DRUG_CODE.CODE_ECTD_IDENIFIER = dao_code.fields.CODE_ECTD_IDENIFIER
                '        Else
                '            lgt_code.XML_DRUG_CODE.CODE_ECTD_IDENIFIER = ""
                '        End If
                '        If IsNothing(dao_code.fields.TMT_VTM) = False Then
                '            lgt_code.XML_DRUG_CODE.TMT_VTM = dao_code.fields.TMT_VTM
                '        Else
                '            lgt_code.XML_DRUG_CODE.TMT_VTM = ""
                '        End If
                '        If IsNothing(dao_code.fields.TMT_GP) = False Then
                '            lgt_code.XML_DRUG_CODE.TMT_GP = dao_code.fields.TMT_GP
                '        Else
                '            lgt_code.XML_DRUG_CODE.TMT_GP = ""
                '        End If
                '        If IsNothing(dao_code.fields.TMT_GPU) = False Then
                '            lgt_code.XML_DRUG_CODE.TMT_GPU = dao_code.fields.TMT_GPU
                '        Else
                '            lgt_code.XML_DRUG_CODE.TMT_GPU = ""
                '        End If
                '        If IsNothing(dao_code.fields.TMT_TPU) = False Then
                '            lgt_code.XML_DRUG_CODE.TMT_TPU = dao_code.fields.TMT_TPU
                '        Else
                '            lgt_code.XML_DRUG_CODE.TMT_TPU = ""
                '        End If
                '        If IsNothing(dao_code.fields.GTIN) = False Then
                '            lgt_code.XML_DRUG_CODE.GTIN = dao_code.fields.GTIN
                '        Else
                '            lgt_code.XML_DRUG_CODE.GTIN = ""
                '        End If
                '        If IsNothing(dao_code.fields.UNII) = False Then
                '            lgt_code.XML_DRUG_CODE.UNII = dao_code.fields.UNII
                '        Else
                '            lgt_code.XML_DRUG_CODE.UNII = ""
                '        End If
                '        If IsNothing(dao_code.fields.DC24) = False Then
                '            lgt_code.XML_DRUG_CODE.DC24 = dao_code.fields.DC24
                '        Else
                '            lgt_code.XML_DRUG_CODE.DC24 = ""
                '        End If
                '        If IsNothing(dao_code.fields.Newcode) = False Then
                '            lgt_code.XML_DRUG_CODE.Newcode = dao_code.fields.Newcode
                '        Else
                '            lgt_code.XML_DRUG_CODE.Newcode = ""
                '        End If

                '        class_xml.LGT_XML_DRUG_CODE.Add(lgt_code)
                '    Next
                'Else

                'For Each dao_export.fields In dao_export.Details
                Dim lgt_code1 As New LGT_XML_DRUG_CODE


                lgt_code1.XML_DRUG_CODE.IDA = 0
                lgt_code1.XML_DRUG_CODE.pvncd = ""
                lgt_code1.XML_DRUG_CODE.drgtpcd = ""
                lgt_code1.XML_DRUG_CODE.rgttpcd = ""
                lgt_code1.XML_DRUG_CODE.rgtno = ""
                lgt_code1.XML_DRUG_CODE.rid = ""
                lgt_code1.XML_DRUG_CODE.CODE_DL = ""
                lgt_code1.XML_DRUG_CODE.CODE_ECTD_IDENIFIER = ""
                lgt_code1.XML_DRUG_CODE.TMT_VTM = ""
                lgt_code1.XML_DRUG_CODE.TMT_GP = ""
                lgt_code1.XML_DRUG_CODE.TMT_GPU = ""
                lgt_code1.XML_DRUG_CODE.TMT_TPU = ""
                lgt_code1.XML_DRUG_CODE.GTIN = ""
                lgt_code1.XML_DRUG_CODE.UNII = ""
                lgt_code1.XML_DRUG_CODE.DC24 = ""
                lgt_code1.XML_DRUG_CODE.Newcode = ""
                class_xml.LGT_XML_DRUG_CODE.Add(lgt_code1)
                'Next
                'End If

                '#End Region
                '#Region "ขนาดบรรจุ"
                '----------------------------ขนาดบรรจุ
                'Dim dao_contain As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CONTAIN
                'dao_contain.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                Dim dt_contain As New DataTable
                Dim bao_contain As New BAO.ClsDBSqlcommand
                Try
                    dt_contain = bao_contain.SP_XML_DRUG_CONTAIN_BY_IDA(dao_rg.fields.IDA)
                Catch ex As Exception

                End Try
                If dt_contain.Rows.Count <> 0 Then

                    For Each dr_ct As DataRow In dt_contain.Rows
                        Dim lgt_contain As New LGT_XML_DRUG_CONTAIN

                        If IsNothing(dr_ct("IDA")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.IDA = dr_ct("IDA")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.IDA = 0
                        End If
                        If IsNothing(dr_ct("pvncd")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.pvncd = dr_ct("pvncd")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.pvncd = ""
                        End If
                        If IsNothing(dr_ct("drgtpcd")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.drgtpcd = dr_ct("drgtpcd")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.drgtpcd = ""
                        End If
                        If IsNothing(dr_ct("rgttpcd")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.rgttpcd = dr_ct("rgttpcd")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.rgttpcd = ""
                        End If
                        If IsNothing(dr_ct("rgtno")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.rgtno = dr_ct("rgtno")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.rgtno = ""
                        End If
                        If IsNothing(dr_ct("lcnno")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.lcnno = dr_ct("lcnno")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.lcnno = ""
                        End If
                        If IsNothing(dr_ct("rid")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.rid = dr_ct("rid")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.rid = ""
                        End If
                        If IsNothing(dr_ct("SUBTITLE_SIZE_DRUG")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = dr_ct("SUBTITLE_SIZE_DRUG")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
                        End If
                        If IsNothing(dr_ct("SMALL_AMOUNT")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = dr_ct("SMALL_AMOUNT")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = 0.0
                        End If
                        If IsNothing(dr_ct("SMALL_UNIT")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = dr_ct("SMALL_UNIT")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = ""
                        End If
                        If IsNothing(dr_ct("BIG_UNIT")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = dr_ct("BIG_UNIT")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = ""
                        End If
                        If IsNothing(dr_ct("BIG_AMOUNT")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = dr_ct("BIG_AMOUNT")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = 0.0
                        End If
                        If IsNothing(dr_ct("MEDIUM_AMOUNT")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = dr_ct("MEDIUM_AMOUNT")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = 0.0
                        End If
                        If IsNothing(dr_ct("MEDIUM_UNIT")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = dr_ct("MEDIUM_UNIT")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
                        End If
                        If IsNothing(dr_ct("BARCODE")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.BARCODE = dr_ct("BARCODE")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.BARCODE = ""
                        End If
                        If IsNothing(dr_ct("SUM")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SUM = dr_ct("SUM")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SUM = ""
                        End If

                        If IsNothing(dr_ct("CONRAIN")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.CONRAIN = dr_ct("CONRAIN")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.CONRAIN = ""
                        End If
                        If IsNothing(dr_ct("STATUS_CONRAIN")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = dr_ct("STATUS_CONRAIN")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
                        End If
                        If IsNothing(dr_ct("updateDate")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.updateDate = dr_ct("updateDate")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.updateDate = Date.Now
                        End If
                        If IsNothing(dr_ct("cncdate")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.cncdate = dr_ct("cncdate")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.cncdate = Date.Now
                        End If
                        If IsNothing(dr_ct("Newcode")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.Newcode = dr_ct("Newcode")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.Newcode = ""
                        End If
                        If IsNothing(dr_ct("IDA_DRRGT_PACKAGE_DETAIL")) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = dr_ct("IDA_DRRGT_PACKAGE_DETAIL")
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = ""
                        End If
                        class_xml.LGT_XML_DRUG_CONTAIN.Add(lgt_contain)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_contain1 As New LGT_XML_DRUG_CONTAIN
                    lgt_contain1.XML_DRUG_CONTAIN.IDA = 0
                    lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.drgtpcd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.rgttpcd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.rgtno = ""
                    lgt_contain1.XML_DRUG_CONTAIN.rid = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SMALL_AMOUNT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SMALL_UNIT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.BIG_UNIT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.BIG_AMOUNT = 0
                    lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.BARCODE = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SUM = ""
                    lgt_contain1.XML_DRUG_CONTAIN.CONRAIN = ""
                    lgt_contain1.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
                    lgt_contain1.XML_DRUG_CONTAIN.updateDate = Date.Now
                    lgt_contain1.XML_DRUG_CONTAIN.cncdate = Date.Now
                    lgt_contain1.XML_DRUG_CONTAIN.Newcode = ""
                    lgt_contain1.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = 0
                    class_xml.LGT_XML_DRUG_CONTAIN.Add(lgt_contain1)
                    'Next
                End If

                '#End Region
                '#Region "วิธีวิเคราะห์ควบคุมคุณภาพ"
                '----------------------------วิธีวิเคราะห์ควบคุมคุณภาพ
                'Dim dao_control_ana As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CONTROL_ANALYZE
                'dao_control_ana.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                'If dao_control_ana.Details.Count <> 0 Then

                '    For Each dao_control_ana.fields In dao_control_ana.datas
                '        Dim lgt_control_ana As New LGT_XML_DRUG_CONTROL_ANALYZE

                '        If IsNothing(dao_control_ana.fields.IDA) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.IDA = dao_control_ana.fields.IDA
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.IDA = 0
                '        End If
                '        If IsNothing(dao_control_ana.fields.pvncd) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.pvncd = dao_control_ana.fields.pvncd
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.pvncd = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.drgtpcd) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.drgtpcd = dao_control_ana.fields.drgtpcd
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.drgtpcd = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.rgttpcd) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgttpcd = dao_control_ana.fields.rgttpcd
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgttpcd = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.rgtno) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgtno = dao_control_ana.fields.rgtno
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgtno = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.lcnno) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.lcnno = dao_control_ana.fields.lcnno
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.lcnno = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.rid) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rid = dao_control_ana.fields.rid
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rid = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.TOPIC_ANALYZE) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.TOPIC_ANALYZE = dao_control_ana.fields.TOPIC_ANALYZE
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.TOPIC_ANALYZE = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.METHOD_ANALYZE) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.METHOD_ANALYZE = dao_control_ana.fields.METHOD_ANALYZE
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.METHOD_ANALYZE = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.SET_STANDARDS) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.SET_STANDARDS = dao_control_ana.fields.SET_STANDARDS
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.SET_STANDARDS = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.REF_STANDARDS) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.REF_STANDARDS = dao_control_ana.fields.REF_STANDARDS
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.REF_STANDARDS = ""
                '        End If
                '        If IsNothing(dao_control_ana.fields.Newcode) = False Then
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.Newcode = dao_control_ana.fields.Newcode
                '        Else
                '            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.Newcode = ""
                '        End If
                '        class_xml.LGT_XML_DRUG_CONTROL_ANALYZE.Add(lgt_control_ana)
                '    Next
                'Else

                'For Each dao_export.fields In dao_export.Details
                Dim lgt_control_ana1 As New LGT_XML_DRUG_CONTROL_ANALYZE
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.IDA = 0
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.pvncd = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.drgtpcd = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.rgttpcd = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.rgtno = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.rid = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.TOPIC_ANALYZE = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.METHOD_ANALYZE = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.SET_STANDARDS = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.REF_STANDARDS = ""
                lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.Newcode = ""

                class_xml.LGT_XML_DRUG_CONTROL_ANALYZE.Add(lgt_control_ana1)
                'Next
                'End If

                '#End Region
                Return class_xml
            End Function
            Public Function CLASSTOXMLSTR(ByVal cls_rev As Object) 'เอา class มารับ class ที่ส่งเข้ามา
                Dim x2 As New XmlSerializer(cls_rev.GetType())
                Dim settings As New XmlWriterSettings()
                settings.Encoding = Encoding.UTF8
                settings.Indent = True
                Dim mem2 As New MemoryStream()
                Using writer As XmlWriter = XmlWriter.Create(mem2, settings)
                    x2.Serialize(writer, cls_rev)
                    writer.Flush()
                    writer.Close()
                End Using
                Dim B64 As String = ""
                B64 = Convert.ToBase64String(mem2.GetBuffer())
                Return B64
            End Function
        End Class

    End Class
End Namespace