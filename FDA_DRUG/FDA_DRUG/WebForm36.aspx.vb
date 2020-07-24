Imports System.IO
Imports System.Xml.Serialization
Imports Microsoft.Reporting.WebForms
Imports System
Imports System.Collections
Imports System.Globalization
Public Class WebForm36
    Inherits System.Web.UI.Page
    Dim aa As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_lcnno()

        Dim aaa As String = "กกกกกกกก4ฟฟฟฟฟฟ55ฟฟหก"
        aaa = NumEng2Thai(aaa)
        Dim asas As String = ""
        asas = CDate("2020-03-23").ToLongDateString()




        If Not IsPostBack Then
            'UC_general_BC1.bind_dactg()
            'UC_general_BC1.bind_ddl_bio_unit()
            'UC_general_BC1.bind_ddl_packaging()
            'UC_general_BC1.bind_ddl_small_unit()
            'UC_general_BC1.bind_dosage_form()
            'UC_general_BC1.bind_drclass()
            'UC_general_BC1.bind_drkdofdrg()
            'UC_general_BC1.bind_DRUG_SHAPE()
            'UC_general_BC1.bind_label()
            'UC_general_BC1.show_data("U1DR1C1012460009711C")
            'Run_section1_v2()
            'aa = "ff"
            'Session("aa") = aa
            '    get_atc()
            Dim dt As New DataTable
            dt = Get_DDL_DATA(8, 3, 0)
            Dim dt2 As New DataTable
            dt2 = dt.Clone
            For Each dr As DataRow In dt.Select("STATUS_ID <> 8")
                Dim dr2 As DataRow = dt2.NewRow()
                dr2("STATUS_ID") = dr("STATUS_ID")
                dr2("STATUS_NAME_STAFF") = dr("STATUS_NAME_STAFF")
                dr2("STATUS_NAME") = dr("STATUS_NAME")
                dr2("seq") = dr("seq")
                dt2.Rows.Add(dr2)
            Next
            'Dim dv As DataView = dt2
            dt2.DefaultView.Sort = "seq ASC"
            Dim dtResult As DataTable = dt2.DefaultView.ToTable()
            ddl_status.DataSource = dtResult 'dt.Select("STATUS_ID <> 8")
            ddl_status.DataValueField = "STATUS_ID"
            ddl_status.DataTextField = "STATUS_NAME_STAFF"
            ddl_status.DataBind()

        End If
        'Dim DS As String = ""
        'DS = Format(Date.Now(), "MM/dd/yyyy")
        'Dim int_no As Integer = 123
        'Dim str_no As String = int_no.ToString()
        'str_no = String.Format("{0:50000}", int_no.ToString("50000"))
        'Dim rcvdate As Date = Date.Now
        'Dim awa As String
        'awa = rcvdate.ToString("MMM")
        'Dim zzz As String = ""
        'zzz = GET_FORMAT_RCVNO2("15555/63")
        Set_rcvno_txt()
        product_q()
    End Sub
    Sub product_q()
        Dim newcode As String = "U1DR1C1052630003611C"
        Dim dao_XML_DRUG_FRGN As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_FRGN
        dao_XML_DRUG_FRGN.GetDataby_u1(newcode)
        For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
            Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
            With dao_pro.fields
                .FK_IDA = 0
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
                    Dim bao_iso As New BAO.ClsDBSqlcommand
                    Dim dt_iso As New DataTable
                    dt_iso = bao_iso.SP_sysisocnt_SAI_by_engcntnm(dao_XML_DRUG_FRGN.fields.engcntnm) '
                    Dim alpha3 As String = ""
                    Try
                        alpha3 = dt_iso(0)("alpha3")
                    Catch ex As Exception

                    End Try
                    Dim dao_frgn_addr As New DAO_DRUG.ClsDBdrfrgnaddr
                    'dao_frgn_addr.GetDataAll_v2(dao_XML_DRUG_FRGN.fields.addr, alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.fax, dao_XML_DRUG_FRGN.fields.mu, _
                    'dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.road, dao_XML_DRUG_FRGN.fields.soi, dao_XML_DRUG_FRGN.fields.subdiv, dao_XML_DRUG_FRGN.fields.tel, _
                    'dao_XML_DRUG_FRGN.fields.zipcode, dao_frgn_name.fields.frgncd)
                    dao_frgn_addr.GetDataAll_v3(dao_XML_DRUG_FRGN.fields.addr, alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.subdiv, dao_frgn_name.fields.frgncd)

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
            'dao_pro.insert()
        Next

    End Sub

    Function CHK_Extension(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String) As Integer 'ปรับ เพิ่มtype
        Dim aa As String = System.IO.Path.GetExtension(FileUpload1.FileName)
        Dim i As Integer = 0
        If Not aa.Contains("pdf") Then
            i += 1
        End If
        Return i
    End Function
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        'Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V3 @stat_group=" & stat_g & ", @group1=" & group1
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function
    Public Sub Set_rcvno_txt()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim _year2 As String = Right(con_year(Date.Now.Year()), 2)
        dt = bao.SP_GET_MAX_RCVNO_EDIT_REQUEST(_year2 & "15")
        Dim running As Integer = 0
        If dt.Rows.Count > 0 Then
            running = CInt(Right(dt(0)("rcvno"), 3))
        End If
        running += 1
        Dim rcvno_format As String
        'Try
        '    rcvno = String.Format("{0:0000}", running.ToString("0000"))
        '    rcvno = year_short & rcvno
        'Catch ex As Exception

        'End Try
        rcvno_format = CStr(running) & "/" & _year2
    End Sub
    Function GET_FORMAT_RCVNO2(ByVal txt As String) As Integer
        Dim rcvno As String = ""
        Dim running As Integer = 0
        Dim year_short As String = ""
        Dim split_text As String() = txt.Split("/")

        Try
            running = CInt(split_text(0))
            year_short = split_text(1)
            rcvno = String.Format("{0:00000}", running.ToString("00000"))
            rcvno = year_short & rcvno
        Catch ex As Exception

        End Try

        Return rcvno
    End Function
    Function get_lcnno() As String
        'Dim aaaa As String = ""
        Dim nonono As String = "กท 2/2550"
        'Dim sp_1st As String() = nonono.Split(" ")
        'Dim sp_2st As String() = sp_1st(1).Split("/")
        'aaaa = sp_2st(0)



        Dim lcnno As String = ""
        Dim arr_feeno1 As String() = Nothing
        Dim arr_feeno2 As String() = Nothing
        Try
            arr_feeno1 = nonono.Split(" ")
            arr_feeno2 = arr_feeno1(1).Split("/")

            If Len(arr_feeno2(0)) < 5 Then
                Try
                    arr_feeno2(0) = String.Format("{0:00000}", CInt(arr_feeno2(0)))
                Catch ex As Exception

                End Try

            End If

            lcnno = Right(Trim(nonono), 2) & arr_feeno2(0)
        Catch ex As Exception

        End Try
        Return lcnno
    End Function
    Sub get_atc()
        Dim newcode As String = "U1DR1D1022400000311C"
        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN

        Dim xml_iow As New LGT_IOW_E
        Dim xml_str As String

        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2("U1DR1D1022400000311C")
        If xml_str <> "FAIL" Then
            'MODEL.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
        Else

        End If
        Dim dao_dr_esub As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        dao_dr_esub.GetDataby_u1(newcode)
        Dim IDA_drrgt As Integer = dao_dr_esub.fields.IDA_drrgt
        Dim amlsubnm As String
        Dim amltpnm As String

        'For i As Integer = 0 To xml_iow.LGT_ANIMAL_DRUGS_TO.Count - 1
        '    For ii As Integer = 0 To xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Count - 1
        '        amlsubnm = xml_iow.LGT_ANIMAL_DRUGS_TO.Item(i).LGT_ANIMAL_CONSUME_DRUGS_TO.Item(ii).XML_DRUG_ANIMAL_CONSUME.amlsubnm

        '    Next
        'Next

        For Each U_ANIMAL_DRUGS_TO As LGT_ANIMAL_DRUGS_TO In xml_iow.LGT_ANIMAL_DRUGS_TO
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
                    Dim dao_uset As New DAO_DRUG.TB_dramlusetp
                    dao_uset.GetDataby_usetpnm(U_ANIMAL_DRUGS_TO.XML_DRUG_ANIMAL.usetpnm)
                    .usetpcd = dao_uset.fields.usetpcd
                Catch ex As Exception

                End Try
                .FK_IDA = IDA_drrgt
            End With
        Next
        'Dim clsxml As New Cls_XML
        'clsxml.ReadData(xml_str)

        'Dim aa As New LGT_RECIPE_GROUP_TO 'LGT_RECIPE_GROUP_TO
        'Dim dt As New DataTable
        'dt.Columns.Add("atccd")
        'dt.Columns.Add("atcnm")
        'Dim i As Integer = 0
        'For Each aa In xml_iow.LGT_RECIPE_GROUP_TO
        '    Dim dr As DataRow = dt.NewRow
        '    dr("atccd") = aa.XML_DRUG_RECIPE_GROUP.atccd  'aa.XML_STOWAGR.keepdesc
        '    dr("atcnm") = aa.XML_DRUG_RECIPE_GROUP.atcnm
        '    'dr("IDA") = aa.XML_DRUG_STOWAGR.IDA
        '    'dr("Newcode") = aa.XML_DRUG_STOWAGR.Newcode
        '    'dr("tphigh") = aa.XML_DRUG_STOWAGR.tphigh
        '    'dr("tplow") = aa.XML_DRUG_STOWAGR.tplow
        '    'dr("useage") = aa.XML_DRUG_STOWAGR.useage

        '    dt.Rows.Add(dr)
        'Next

        'Dim dao_product As New DAO_DRUG.TB_DRRGT_PRODUCER
        'dao_product.GetDataby_FK_IDA(IDA_drrgt)
        'For Each dao_product.fields In dao_product.datas
        '    dao_product.delete()
        'Next
        'Dim dao_XML_DRUG_FRGN As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_FRGN
        'dao_XML_DRUG_FRGN.GetDataby_u1(newcode)
        'For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
        '    Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
        '    With dao_pro.fields
        '        .FK_IDA = IDA_drrgt
        '        .PRODUCER_WORK_TYPE = dao_XML_DRUG_FRGN.fields.funccd
        '        .funccd = dao_XML_DRUG_FRGN.fields.funccd
        '        Dim frgncd As Integer = 0
        '        Dim FK_PRODUCER As Integer = 0
        '        Dim addr_ida As Integer = 0
        '        Dim frgnlctcd As Integer = 0
        '        Dim dao_frgn_name As New DAO_DRUG.ClsDBsyspdcfrgn
        '        dao_frgn_name.GetData_by_engfrgnnm(dao_XML_DRUG_FRGN.fields.engfrgnnm)
        '        For Each dao_frgn_name.fields In dao_frgn_name.datas
        '            Dim icc As Integer = 0
        '            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
        '            dao_iso.GetData_engcntnm(dao_XML_DRUG_FRGN.fields.engcntnm)
        '            Dim dao_frgn_addr As New DAO_DRUG.ClsDBdrfrgnaddr
        '            dao_frgn_addr.GetDataAll_v2(dao_XML_DRUG_FRGN.fields.addr, dao_iso.fields.alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.fax, dao_XML_DRUG_FRGN.fields.mu, _
        '                                        dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.road, dao_XML_DRUG_FRGN.fields.soi, dao_XML_DRUG_FRGN.fields.subdiv, dao_XML_DRUG_FRGN.fields.tel, _
        '                                        dao_XML_DRUG_FRGN.fields.zipcode, dao_frgn_name.fields.frgncd)
        '            For Each dao_frgn_addr.fields In dao_frgn_addr.datas
        '                addr_ida = dao_frgn_addr.fields.IDA
        '                frgnlctcd = dao_frgn_addr.fields.frgnlctcd
        '                frgncd = dao_frgn_addr.fields.frgnlctcd

        '            Next
        '            FK_PRODUCER = dao_frgn_name.fields.IDA
        '        Next

        '        .frgncd = dao_frgn_name.fields.frgncd
        '        .addr_ida = addr_ida
        '        .FK_PRODUCER = FK_PRODUCER
        '        .frgnlctcd = frgnlctcd
        '    End With
        '    'dao_pro.insert()
        'Next





        'Dim aa As New LGT_XML_STOWAGR_TO 'LGT_RECIPE_GROUP_TO
        'Dim dt As New DataTable
        'dt.Columns.Add("keepdesc")
        'dt.Columns.Add("drgchrtha")
        'dt.Columns.Add("IDA")
        'dt.Columns.Add("Newcode")
        'dt.Columns.Add("tphigh")
        'dt.Columns.Add("tplow")
        'dt.Columns.Add("useage")
        'Dim i As Integer = 0
        'For Each aa In xml_iow.LGT_XML_STOWAGR_TO
        '    Dim dr As DataRow = dt.NewRow
        '    dr("keepdesc") = aa.XML_DRUG_STOWAGR.keepdesc  'aa.XML_STOWAGR.keepdesc
        '    dr("drgchrtha") = aa.XML_DRUG_STOWAGR.drgchrtha
        '    dr("IDA") = aa.XML_DRUG_STOWAGR.IDA
        '    dr("Newcode") = aa.XML_DRUG_STOWAGR.Newcode
        '    dr("tphigh") = aa.XML_DRUG_STOWAGR.tphigh
        '    dr("tplow") = aa.XML_DRUG_STOWAGR.tplow
        '    dr("useage") = aa.XML_DRUG_STOWAGR.useage

        '    dt.Rows.Add(dr)
        'Next


        'Dim dt As New DataTable
        'dt.Columns.Add("aori")
        'dt.Columns.Add("iowacd")
        'dt.Columns.Add("flineno")
        'dt.Columns.Add("qtytxt")
        'dt.Columns.Add("iowanm")
        'dt.Columns.Add("rid")
        'dt.Columns.Add("iowacd_head")

        'Dim dt2 As New DataTable
        'dt2.Columns.Add("aori")
        'dt2.Columns.Add("iowacd")
        'dt2.Columns.Add("flineno")
        'dt2.Columns.Add("qtytxt")
        'dt2.Columns.Add("iowanm")
        'dt2.Columns.Add("rid")
        'dt2.Columns.Add("elineno")
        'dt2.Columns.Add("iowacd_head")
        'For i As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Count - 1
        '    For ii As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Count - 1
        '        Dim dr As DataRow = dt.NewRow
        '        dr("aori") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.aori
        '        dr("iowacd") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.iowacd
        '        dr("flineno") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.flineno
        '        dr("qtytxt") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.qtytxt
        '        dr("iowanm") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.iowanm
        '        dr("rid") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.rid
        '        dt.Rows.Add(dr)

        '        'For ii2 As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Count - 1  '.Item(ii2).LGT_IOW_EQ_TO.Count - 1

        '        For ii3 As Integer = 0 To xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Count - 1
        '            dr = dt.NewRow
        '            dr("iowacd") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.iowacd
        '            dr("aori") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.aori

        '            dr("flineno") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.flineno
        '            dr("qtytxt") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.qty
        '            dr("iowanm") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.iowanm
        '            dr("rid") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.rid & "." & xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.rid
        '            dr("iowacd_head") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii).XML_DRUG_IOW.iowacd
        '            'dr2("Newcode_rid_eq") = xml_iow.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Item(i).XML_DRUG_IOW_TO.Item(ii2).LGT_IOW_EQ_TO.Item(ii3).XML_DRUG_IOW_EQ.Newcode_rid_eq
        '            dt.Rows.Add(dr)
        '        Next

        '        'Next

        '    Next

        'Next


    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenReport(1, "~/word/test.doc")
    End Sub
    Public Sub OpenReport(ByVal idreport As Integer, ByVal pathdoc As String)
        'Dim cls As New Untility.CLS_ASPOSE_WORD

        'Dim pathlic As String = Server.MapPath("lic") & "/License.lic"
        'cls.setLicense(pathlic)

        'pathdoc = Server.MapPath(pathdoc)
        'cls.docConnect(pathdoc)

        'cls.rePlaceData("<1>", "ปัจจุบัน")
        'cls.rePlaceData("<2>", "1A 2/2561 (NC)")
        'cls.rePlaceData("<3>", "ยาพาราจ้าาา")
        'cls.rePlaceData("<4>", "1A 2/2561")
        'cls.rePlaceData("<5>", "ยาเม็ด")
        'cls.rePlaceData("<6>", "ยาเม็ด กลมๆ ขาวๆ")
        'cls.rePlaceData("<7>", "ยานี้ดีมากๆ")
        'cls.rePlaceData("<8>", "นายทดสอบ นะจ๊ะ")
        'cls.rePlaceData("<9>", "นย1 1/26")
        'cls.rePlaceData("<10>", "บ้านเลขที่ 5 หมู่ 2 ต.ทดสอบ อ.ทดสอบ จ.ทดสอบ 11111")
        'cls.rePlaceData("<11>", "บ้านเลขที่ 5 หมู่ 2 ต.ทดสอบ อ.ทดสอบ จ.ทดสอบ 11111")
        'cls.rePlaceData("<12>", "1")
        'cls.rePlaceData("<13>", "มกราคม")
        'cls.rePlaceData("<14>", "2561")
        'cls.rePlaceData("<15>", "นายทดสอบ นะจ๊ะนะจ๊ะ")
        'cls.rePlaceData("<16>", "1")
        'cls.rePlaceData("<17>", "1A 2/2561 (NC)")
        'cls.rePlaceData("<18>", "")


        'cls.docSaveOpen("Report.doc")
        ''Catch ex As Exception
        ''    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถออกรายงานได้ เนื่องจากยังไม่มีการบันทึกข้อมูล');", True)
        ''End Try
    End Sub
    Sub Run_section1_v2()

        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN

        Dim xml_iow As New LGT_IOW_E
        Dim xml_str As String

        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2("U1DR1C1012460009711C")
        If xml_str <> "FAIL" Then
            'MODEL.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)

        Else

        End If


        'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        'dao_rg.GetDataby_IDA(_IDA)
        'Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        'Try
        '    dao_re.GetDataby_IDA(dao_rg.fields.FK_IDA)
        'Catch ex As Exception

        'End Try



        Try
            txt_appdate.Text = xml_iow.XML_SEARCH_DRUG_DR.appdate_T 'CDate(dao_rg.fields.appdate).ToShortDateString()
        Catch ex As Exception
            txt_appdate.Text = ""
        End Try
        Try
            lbl_tabean_type.Text = xml_iow.XML_SEARCH_DRUG_DR.rgttpcd 'dao_rg.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            'Dim dao_w As New DAO_DRUG.ClsDBdrdrgtype
            'dao_w.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
            lbl_tabean_other_type.Text = xml_iow.XML_SEARCH_DRUG_DR.engdrgtpnm 'dao_w.fields.engdrgtpnm
        Catch ex As Exception

        End Try
        Try
            'Dim rgtno As String = ""
            'Dim full_rgtno As String = ""
            'rgtno = dao_rg.fields.rgtno
            'full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rgtno, 5)).ToString() & "/" & Left(rgtno, 2)

            'Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
            'Try
            '    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
            '    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
            'Catch ex As Exception

            'End Try
            ''lbl_rgtno.Text = full_rgtno

            'Try
            '    Dim bao_rg As New BAO.ClsDBSqlcommand
            '    Dim dt9 As New DataTable
            '    dt9 = bao_rg.SP_DRRGT_FOR_SEARCH_IDA_NEW(_IDA)
            lbl_rgtno.Text = xml_iow.XML_SEARCH_DRUG_DR.register 'dt9(0)("rgtno_display")
            'Catch ex As Exception

            'End Try
        Catch ex As Exception

        End Try
        Try
            lbl_engdrgnm.Text = xml_iow.XML_SEARCH_DRUG_DR.engdrgnm
        Catch ex As Exception

        End Try
        Try
            lbl_thadrgnm.Text = xml_iow.XML_SEARCH_DRUG_DR.thadrgnm
        Catch ex As Exception

        End Try

        'Dim dt As New DataTable
        'Dim bao As New BAO_SHOW
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'Try

        '    dao.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
        '    dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        'Catch ex As Exception

        'End Try
        'If dt.Rows.Count > 0 Then
        lbl_lcnsnm.Text = xml_iow.XML_SEARCH_DRUG_DR.thanm 'dt(0)("thanm")
        'End If

        'Dim dt2 As New DataTable
        'Try
        '    dt2 = BAO.SP_DRRGT_ADDR_BY_IDA(_IDA)
        'Catch ex As Exception

        'End Try
        Try
            lbl_thanameplace.Text = xml_iow.XML_SEARCH_DRUG_DR.thanm_locaion 'dt2(0)("thanameplace")
        Catch ex As Exception

        End Try
        Try
            lbl_addr.Text = xml_iow.XML_SEARCH_DRUG_DR.fulladdr 'dt2(0)("fulladdr")
        Catch ex As Exception

        End Try
        Try
            lbl_lcntpcd.Text = xml_iow.XML_SEARCH_DRUG_DR.lcntpcd 'dao.fields.lcntpcd
        Catch ex As Exception

        End Try
        Try
            'Dim lcnno As String = ""
            'Dim full_lcnno As String = ""

            'lcnno = dao.fields.lcnno
            'If Right(Left(lcnno, 3), 1) = "5" Then
            '    full_lcnno = "จ. " & Integer.Parse(Right(lcnno, 4)).ToString() & "/25" & Left(lcnno, 2)
            'Else
            '    full_lcnno = dao.fields.pvnabbr & " " & Integer.Parse(Right(lcnno, 5)).ToString() & "/25" & Left(lcnno, 2)
            'End If
            lbl_lcnno.Text = xml_iow.XML_SEARCH_DRUG_DR.lcnno_no 'full_lcnno
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_run_atc_Click(sender As Object, e As EventArgs) Handles btn_run_atc.Click
        Dim dao As New DAO_DRUG.TB_ATC_DRUG
        dao.GetDataALL()

        For Each dao.fields In dao.datas
            Dim dt As New DataTable
            Dim bao As New BAO_SHOW
            dt = bao.SP_ATC_ALL(dao.fields.atccd)
            For Each dr As DataRow In dt.Rows
                Dim dao_u As New DAO_DRUG.TB_ATC_DRUG
                dao_u.GetDataby_IDA(dr("IDA"))
                dao_u.fields.MAIN_REF = dao.fields.atccd
                dao_u.update()
            Next
        Next
    End Sub

    Protected Sub btn_a_Click(sender As Object, e As EventArgs) Handles btn_a.Click
        Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
        dao.GetDataAll_A()
        For Each dao.fields In dao.datas
            Dim dao_get As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            dao_get.GetDataby_IDA(dao.fields.IDA)
            Dim date_result As Date
            Dim ws As New WS_GETDATE_WORKING.Service1
            ws.GETDATE_WORKING(CDate(dao.fields.REQUESTS_DATE), True, dao.fields.CONREQ_NUMBER_DAY, True, date_result, True)
            dao_get.fields.CONREQ_LAST_UPDATE_DATE = date_result
            dao_get.update()
        Next
    End Sub

    Protected Sub btn_run_xml_Click(sender As Object, e As EventArgs) Handles btn_run_xml.Click
        Dim dao As New DAO_DRUG.TB_DRRGT_COLOR
        dao.GetDataby_FK_IDA(87434)

        Dim path As String = "C:\path\DRUG\XML_DRRGT_EDIT\TEST.XML"
        Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
        Dim x As New XmlSerializer(dao.fields.GetType)                                                     'ประกาศ
        x.Serialize(objStreamWriter, dao.fields)
        objStreamWriter.Close()
    End Sub

    Protected Sub btn_run_cert_finist_date_Click(sender As Object, e As EventArgs) Handles btn_run_cert_finist_date.Click
        Dim dao As New DAO_DRUG.TB_CER
        dao.Get_data_all()
        For Each dao.fields In dao.datas
            Dim dao2 As New DAO_DRUG.TB_CER
            Try
                dao2.fields.lmdfdate = Bind_Date(CDate(dao.fields.REQUEST_DATE))
            Catch ex As Exception
                dao2.fields.lmdfdate = Bind_Date(CDate(dao.fields.CREATE_DATE))
            End Try
            dao2.update()

        Next
    End Sub

    Function Bind_Date(ByVal _date As Date) As Date
        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim date_result As Date
        ws.GETDATE_WORKING(_date, True, 5, True, date_result, True)
        Return date_result
    End Function

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dt_drug_general As New DataTable
        Dim dt_formula As New DataTable
        Dim dt_frgn As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim bao_show As New BAO_SHOW
        Dim dt_drug_recipe As New DataTable
        Dim dt_animal As New DataTable
        Dim dt_tp_stock As New DataTable
        Dim dt_edit_history As New DataTable
        'Dim dt_each
        dt_drug_general = bao_master_2.SP_drug_general_rq(92049)
        dt_formula = bao_master_2.SP_drug_formula_rq(92049)
        dt_frgn = bao_show.SP_DRRQT_PRODUCER_ALL_BY_FK_IDA(92049)
        dt_drug_recipe = bao_show.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(92049)
        dt_animal = bao_show.SP_drramldrg_BY_FK_IDA(92049)
        dt_tp_stock = bao_show.SP_DRRQT_KEEP_DRUG_BY_FK_IDA(92049)
        Dim dt_print As New DataTable
        dt_print.Columns.Add("thanm")
        dt_print.Columns.Add("printdate")
        Dim dr As DataRow = dt_print.NewRow()
        dr("thanm") = "" 'set_name_company(_CLS.CITIZEN_ID)
        dr("printdate") = Date.Now
        dt_print.Rows.Add(dr)
        'SP_DRRGT_ATC_DETAIL_BY_FK_IDA
        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()


        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "rp_drug_general", dt_drug_general)
        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "'rp_drug", dt_drug_general)
        ReportViewer1.LocalReport.ReportPath = "D:\Code\FDA_DRUG\customer\FDA_DRUG\FDA_DRUG\FDA_DRUG\TABEAN_YA_STAFF\REPORT\rp_drug.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
        Dim rds As New ReportDataSource("rp_drug_general", dt_drug_general)
        Dim rds2 As New ReportDataSource("rp_drug_formula", dt_formula)
        Dim rds3 As New ReportDataSource("rp_drug_recipe_group", dt_drug_recipe)
        Dim rds4 As New ReportDataSource("rp_drug_stowagr", dt_tp_stock)
        Dim rds5 As New ReportDataSource("rp_drug_animal", dt_animal)
        Dim rds6 As New ReportDataSource("rp_drug_frgn", dt_frgn)
        Dim rds7 As New ReportDataSource("rp_drug_edit", dt_edit_history)
        Dim rds8 As New ReportDataSource("rp_print_nm", dt_print)

        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        ReportViewer1.LocalReport.DataSources.Add(rds3)
        ReportViewer1.LocalReport.DataSources.Add(rds4)
        ReportViewer1.LocalReport.DataSources.Add(rds5)
        ReportViewer1.LocalReport.DataSources.Add(rds6)
        ReportViewer1.LocalReport.DataSources.Add(rds7)
        ReportViewer1.LocalReport.DataSources.Add(rds8)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.DataBind()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'GET_PACCKING
        'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        'dao_rg.GetDataAll()
        'For Each dao_rg.fields In dao_rg.datas

        'Next
        Dim dt As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        dt = bao_master_2.GET_PACCKING()

        For Each dr As DataRow In dt.Rows
            Dim i As Integer = 1
            Dim dao_pk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_pk.GetDataby_FKIDA(dr("IDA"))
            For Each dao_pk.fields In dao_pk.datas
                dao_pk.fields.order_id = i
                dao_pk.update()
                i += 1
            Next
            dao_pk.db.Connection.Close()
        Next

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ws_update As New WS_DRUG.WS_DRUG
        'ws_update.DRUG_UPDATE_DH15(TextBox1.Text)
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim bao As New BAO.ClsDBSqlcommand
        bao.insert_tabean_sub(97068)
        ' insert_tabean(TextBox1.Text)
    End Sub
    Sub insert_tabean(ByVal FK_IDA As Integer)
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


        Dim dao_prop_det As New DAO_DRUG.tb_DRRQT_PROPERTIES_AND_DETAIL
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
        '
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
    End Sub
    'Sub insert_tabean(ByVal FK_IDA As Integer)
    '    Dim dao As New DAO_DRUG.ClsDBdrrqt
    '    dao.GetDataby_IDA(FK_IDA)
    '    Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
    '    With dao_drrgt.fields
    '        .accttp = dao.fields.accttp
    '        .appdate = dao.fields.appdate
    '        .CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
    '        .CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
    '        .CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
    '        .classcd = dao.fields.classcd
    '        .CONSIDER_DATE = dao.fields.CONSIDER_DATE
    '        .ctgcd = dao.fields.ctgcd
    '        .CTZNO = dao.fields.CTZNO
    '        .drgbiost = dao.fields.drgbiost
    '        .drgexpst = dao.fields.drgexpst
    '        .drgnewst = dao.fields.drgnewst
    '        'Try
    '        '    .drgtpcd = ddl_tabean_group.SelectedValue 'dao.fields.drgtpcd
    '        'Catch ex As Exception

    '        'End Try

    '        .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
    '        .dsgcd = dao.fields.dsgcd
    '        .engdrgnm = dao.fields.engdrgnm
    '        .EXTEND_DATE = dao.fields.EXTEND_DATE
    '        .FIRST_APP_DATE = dao.fields.FIRST_APP_DATE
    '        .FK_DOSAGE_FORM = dao.fields.FK_DOSAGE_FORM
    '        .FK_DRRQT = FK_IDA
    '        .FK_IDA = dao.fields.FK_IDA
    '        .FK_LCN_IDA = dao.fields.FK_LCN_IDA
    '        .FK_STAFF_OFFER_IDA = dao.fields.FK_STAFF_OFFER_IDA
    '        .frtappdate = dao.fields.FIRST_APP_DATE
    '        .IDENTIFY = dao.fields.IDENTIFY
    '        .kindcd = dao.fields.kindcd
    '        .lcnabbr = dao.fields.lcnabbr
    '        .UNIT_NORMAL = dao.fields.UNIT_NORMAL
    '        .DRUG_PACKING = dao.fields.DRUG_PACKING
    '        .UNIT_BIO = dao.fields.UNIT_BIO
    '        .DRUG_STYLE = dao.fields.DRUG_STYLE
    '        .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
    '        Try
    '            .lcnno = dao.fields.lcnno
    '        Catch ex As Exception

    '        End Try

    '        .lcnscd = dao.fields.lcnscd
    '        .lcnsid = dao.fields.lcnsid
    '        .lcntpcd = dao.fields.lcntpcd
    '        .lctcd = dao.fields.lctcd
    '        .lctnmcd = dao.fields.lctnmcd
    '        Try
    '            .lmdfdate = dao.fields.lmdfdate
    '        Catch ex As Exception

    '        End Try

    '        .lpvncd = dao.fields.lpvncd
    '        .lstfcd = dao.fields.lstfcd
    '        .ndrgtp = dao.fields.ndrgtp
    '        .packcd = dao.fields.packcd
    '        .potency = dao.fields.potency
    '        .PROCESS_ID = dao.fields.PROCESS_ID
    '        .pvnabbr = dao.fields.pvnabbr
    '        .pvncd = dao.fields.pvncd
    '        Try
    '            .rcvdate = dao.fields.rcvdate
    '        Catch ex As Exception

    '        End Try

    '        .rcvno = dao.fields.rcvno
    '        .REGIST_TYPE = dao.fields.REGIST_TYPE
    '        .REMARK = dao.fields.REMARK
    '        .rgtno = dao.fields.rgtno
    '        Try
    '            .rgttpcd = dao.fields.rgttpcd
    '            '.rgttpcd = ddl_rgttpcd.SelectedValue
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .drgtpcd = dao.fields.rgtdrgtpcd
    '        Catch ex As Exception

    '        End Try
    '        .STAFF_APP_IDENTIFY = dao.fields.STAFF_APP_IDENTIFY
    '        .STATUS_ID = dao.fields.STATUS_ID
    '        .TABEAN_TYPE = dao.fields.TABEAN_TYPE
    '        .thadrgnm = dao.fields.thadrgnm
    '        .TR_ID = dao.fields.TR_ID
    '        Try
    '            .UNIT_BIO = dao.fields.UNIT_BIO
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .UNIT_NORMAL = dao.fields.UNIT_NORMAL
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .DRUG_PACKING = dao.fields.DRUG_PACKING
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .TYPE_REQUEST_ID = dao.fields.TYPE_REQUEST_ID
    '        Catch ex As Exception

    '        End Try
    '        Try
    '            .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
    '        Catch ex As Exception

    '        End Try
    '    End With
    '    dao_drrgt.insert()
    '    Dim IDA_rgt As Integer = dao_drrgt.fields.IDA

    '    Dim dao_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
    '    dao_atc.GetDataby_FK_IDA(FK_IDA)
    '    For Each dao_atc.fields In dao_atc.datas
    '        Dim dao_rgt_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
    '        With dao_rgt_atc.fields
    '            .ATC_CODE = dao_atc.fields.ATC_CODE
    '            .ATC_IDA = dao_atc.fields.ATC_IDA
    '            .FK_IDA = IDA_rgt
    '        End With
    '        dao_rgt_atc.insert()
    '    Next


    '    Dim dao_cas As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
    '    dao_cas.GetDataby_FK_IDA(FK_IDA)
    '    For Each dao_cas.fields In dao_cas.datas
    '        Dim dao_rgt_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
    '        With dao_rgt_cas.fields
    '            .AORI = dao_cas.fields.AORI
    '            .BASE_FORM = dao_cas.fields.BASE_FORM
    '            .EQTO_IOWA = dao_cas.fields.EQTO_IOWA
    '            .EQTO_QTY = dao_cas.fields.EQTO_QTY
    '            .EQTO_SUNITCD = dao_cas.fields.EQTO_SUNITCD
    '            .FK_IDA = IDA_rgt
    '            .FK_SET = dao_cas.fields.FK_SET
    '            .IOWA = dao_cas.fields.IOWA
    '            .QTY = dao_cas.fields.QTY
    '            .ROWS = dao_cas.fields.ROWS
    '            .SUNITCD = dao_cas.fields.SUNITCD
    '        End With
    '        dao_rgt_cas.insert()
    '    Next


    '    Dim dao_pack As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
    '    dao_pack.GetDataby_FKIDA(FK_IDA)
    '    For Each dao_pack.fields In dao_pack.datas
    '        Dim dao_rgt_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
    '        With dao_rgt_pack.fields
    '            .BARCODE = dao_pack.fields.BARCODE
    '            .BIG_UNIT = dao_pack.fields.BIG_UNIT
    '            .CHECK_PACKAGE = dao_pack.fields.CHECK_PACKAGE
    '            .FK_IDA = IDA_rgt
    '            .MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
    '            .MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
    '            .SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
    '            .SMALL_UNIT = dao_pack.fields.SMALL_UNIT
    '        End With
    '        dao_rgt_pack.insert()
    '    Next


    '    Dim dao_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
    '    dao_pro.GetDataby_FK_IDA(FK_IDA)
    '    For Each dao_pro.fields In dao_pro.datas
    '        Dim dao_rgt_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
    '        With dao_rgt_pro.fields
    '            .addr_ida = dao_pro.fields.addr_ida
    '            .drgtpcd = dao_pro.fields.drgtpcd
    '            .FK_IDA = IDA_rgt
    '            .FK_PRODUCER = dao_pro.fields.FK_PRODUCER
    '            .frgncd = dao_pro.fields.frgncd
    '            .frgnlctcd = dao_pro.fields.frgnlctcd
    '            .funccd = dao_pro.fields.funccd
    '            .lcnno = dao_pro.fields.lcnno
    '            .lcntpcd = dao_pro.fields.lcntpcd
    '            .PRODUCER_WORK_TYPE = dao_pro.fields.PRODUCER_WORK_TYPE
    '            .pvncd = dao_pro.fields.pvncd
    '            .rcvno = dao_pro.fields.rcvno
    '            .REFERENCE_GMP = dao_pro.fields.REFERENCE_GMP
    '            .rgtno = dao_pro.fields.rgtno
    '            .rgttpcd = dao_pro.fields.rgttpcd
    '            .TR_ID = dao_pro.fields.TR_ID
    '        End With
    '        dao_rgt_pro.insert()
    '    Next


    '    Dim dao_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
    '    dao_pro_in.GetDataby_FK_IDA(FK_IDA)
    '    For Each dao_pro_in.fields In dao_pro_in.datas
    '        Dim dao_rgt_pro_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
    '        With dao_rgt_pro_in.fields
    '            .drgtpcd = dao_pro_in.fields.drgtpcd
    '            .FK_IDA = IDA_rgt
    '            .funccd = dao_pro_in.fields.funccd
    '            .lcnno = dao_pro_in.fields.lcnno
    '            .lcntpcd = dao_pro_in.fields.lcntpcd
    '            .rgtno = dao_pro_in.fields.rgtno
    '            .rgttpcd = dao_pro_in.fields.rgttpcd
    '            .FK_LCN_IDA = dao_pro_in.fields.FK_LCN_IDA
    '            .rgtno = dao_pro_in.fields.rgtno
    '            .rgttpcd = dao_pro_in.fields.rgttpcd
    '            .lctcd = dao_pro_in.fields.lctcd
    '            .lcnsid = dao_pro_in.fields.lcnsid
    '        End With
    '        dao_rgt_pro_in.insert()
    '    Next


    '    Dim dao_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES
    '    dao_prop.GetDataby_FKIDA(FK_IDA)
    '    For Each dao_prop.fields In dao_prop.datas
    '        Dim dao_rgt_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
    '        With dao_rgt_prop.fields
    '            .CHK_DRUG_PROPERTIES = dao_prop.fields.CHK_DRUG_PROPERTIES
    '            .CHK_DRUG_PROPERTIES_OTHER = dao_prop.fields.CHK_DRUG_PROPERTIES_OTHER
    '            .DRUG_PROPERTIES = dao_prop.fields.DRUG_PROPERTIES
    '            .DRUG_PROPERTIES_OTHER = dao_prop.fields.DRUG_PROPERTIES_OTHER
    '            .FK_IDA = IDA_rgt
    '        End With
    '        dao_rgt_prop.insert()
    '    Next


    '    Dim dao_prop_det As New DAO_DRUG.tb_DRRQT_PROPERTIES_AND_DETAIL
    '    dao_prop_det.GetDataby_FKIDA(FK_IDA)
    '    For Each dao_prop_det.fields In dao_prop_det.datas
    '        Dim dao_rgt_pd As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
    '        With dao_rgt_pd.fields
    '            .DRUG_PROPERTIES_AND_DETAIL = dao_prop_det.fields.DRUG_PROPERTIES_AND_DETAIL
    '            .FK_IDA = IDA_rgt
    '            .OTHER = dao_prop_det.fields.OTHER
    '            .ROWS = dao_prop_det.fields.ROWS
    '        End With
    '        dao_rgt_pd.insert()
    '    Next

    '    Dim dao_each As New DAO_DRUG.TB_DRRQT_EACH
    '    dao_each.GetDataby_FK_IDA(FK_IDA)
    '    For Each dao_each.fields In dao_each.datas
    '        Dim dao_each_rgt As New DAO_DRUG.TB_DRRGT_EACH
    '        With dao_each_rgt.fields
    '            .EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
    '            .FK_IDA = IDA_rgt
    '            .sunitcd = dao_each.fields.sunitcd
    '            .FK_SET = dao_each.fields.FK_SET
    '        End With
    '        dao_each_rgt.insert()
    '    Next
    '    '
    '    Dim dao_keep As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
    '    dao_keep.GetDataby_FKIDA(FK_IDA)
    '    For Each dao_keep.fields In dao_keep.datas
    '        Dim dao_keep_rgt As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
    '        With dao_keep_rgt.fields
    '            .AGE_DAY = dao_keep.fields.AGE_DAY
    '            .FK_IDA = IDA_rgt
    '            .AGE_HOUR = dao_keep.fields.AGE_HOUR
    '            .AGE_MONTH = dao_keep.fields.AGE_MONTH
    '            .DRUG_DETAIL = dao_keep.fields.DRUG_DETAIL
    '            .KEEP_DESCRIPTION = dao_keep.fields.KEEP_DESCRIPTION
    '            .TEMPERATE1 = dao_keep.fields.TEMPERATE1
    '            .TEMPERATE2 = dao_keep.fields.TEMPERATE2
    '        End With
    '        dao_keep_rgt.insert()
    '    Next

    '    'DRRGT_DTL_TEXT
    '    Dim dao_dtl As New DAO_DRUG.TB_DRRQT_DTL_TEXT
    '    dao_dtl.GetDataby_FKIDA(FK_IDA)
    '    For Each dao_dtl.fields In dao_dtl.datas
    '        Dim dao_dtl_rqt As New DAO_DRUG.TB_DRRGT_DTL_TEXT
    '        With dao_dtl_rqt.fields
    '            .drgtpcd = dao_dtl.fields.drgtpcd
    '            .FK_IDA = IDA_rgt
    '            .dtl = dao_dtl.fields.dtl
    '            .engdrgtpnm = dao_dtl.fields.engdrgtpnm
    '            .keepdesc = dao_dtl.fields.keepdesc
    '            .pcksize = dao_dtl.fields.pcksize
    '            .pvncd = dao_dtl.fields.pvncd
    '            .rgtno = dao_dtl.fields.rgtno
    '            .rgttpcd = dao_dtl.fields.rgttpcd
    '            .tphigh = dao_dtl.fields.tphigh
    '            .tplow = dao_dtl.fields.tplow
    '            .U1_CODE = dao_dtl.fields.U1_CODE
    '            .useage = dao_dtl.fields.useage
    '        End With
    '        dao_dtl_rqt.insert()
    '    Next


    '    Dim dao_color As New DAO_DRUG.TB_DRRQT_COLOR
    '    dao_color.GetDataby_FK_IDA(FK_IDA)
    '    For Each dao_color.fields In dao_color.datas
    '        Dim dao_color_rqt As New DAO_DRUG.TB_DRRGT_COLOR
    '        With dao_color_rqt.fields
    '            .COLOR_NAME1 = dao_color.fields.COLOR_NAME1
    '            .FK_IDA = IDA_rgt
    '            .COLOR_NAME2 = dao_color.fields.COLOR_NAME2
    '            .COLOR_NAME3 = dao_color.fields.COLOR_NAME3
    '            .COLOR_NAME4 = dao_color.fields.COLOR_NAME4
    '            .COLOR1 = dao_color.fields.COLOR1
    '            .COLOR2 = dao_color.fields.COLOR2
    '            .COLOR3 = dao_color.fields.COLOR3
    '            .COLOR4 = dao_color.fields.COLOR4
    '        End With
    '        dao_color_rqt.insert()
    '    Next


    '    Dim dao_eq As New DAO_DRUG.TB_DRRQT_EQTO
    '    dao_eq.GetDataby_FK_IDA(FK_IDA)
    '    For Each dao_eq.fields In dao_eq.datas
    '        Dim dao_eq_rgt As New DAO_DRUG.TB_DRRGT_EQTO
    '        With dao_eq_rgt.fields
    '            .FK_IDA = IDA_rgt
    '            .IOWA = dao_eq.fields.IOWA
    '            .MULTIPLY = dao_eq.fields.MULTIPLY
    '            .QTY = dao_eq.fields.QTY
    '            .ROWS = dao_eq.fields.ROWS
    '            .STR_VALUE = dao_eq.fields.STR_VALUE
    '            .SUNITCD = dao_eq.fields.SUNITCD
    '        End With
    '        dao_eq_rgt.insert()
    '    Next
    'End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_TEMP_CASE1441()
        Dim ws_drug As New WS_DRUG.WS_DRUG
        'ws_drug.DRUG_UPDATE_DR("10", "2C", "3", "6100003")
        'For Each dr As DataRow In dt.Rows
        '    ws_drug.DRUG_UPDATE_DR(dr("pvncd"), dr("rgttpcd"), dr("drgtpcd"), dr("rgtno"))

        '    Dim bao_update As New BAO.ClsDBSqlcommand
        '    Dim dt2 As New DataTable
        '    dt2 = bao_update.SP_UPDATE_TEMP_CASE1441(dr("IDA"))
        '    'Dim dao As New DAO_DRUG.TB_case1411
        '    'dao.GetDataby_IDA(dr("IDA"))
        '    'dao.fields.STATUS_UPDATE = 1
        '    'dao.update()
        'Next


        'ws_drug.DRUG_INSERT_DR(TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
        'ws_drug.
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim dao_rqt As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        'dao_rqt.GetDatabyIDA(91455)
        Dim bao As New BAO.GenNumber 'test
        'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUEST_AMOUNT
        'Try
        '    dao.GetDataby_TYPE_REQUESTS_ID(dao_rqt.fields.TYPE_REQUEST_ID)
        'Catch ex As Exception

        'End Try
        Dim RCVNO As Integer

        RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), 10, "130099", 91455)
        'RCVNO = GET_FORMAT_RCVNO(Txt_rcvno_no.Text)
        dao_rqt.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

        dao_rqt.update()
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim rcvno_auto As Integer = 0
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        Dim rcvno_format As String = ""

        dao.GetDatabyIDA(91314)
        rcvno_auto = dao.fields.rcvno
        If Len(rcvno_auto) > 0 Then

            Dim aa3 As String = ""
            'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            'dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
            Dim dao_drgtype As New DAO_DRUG.ClsDBdrdrgtype
            dao_drgtype.GetDataby_drgtpcd(dao.fields.drgtpcd)

            Try
                aa3 = dao_drgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try

            rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa3
        End If
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'Dim aa As String = System.IO.Path.GetExtension(FileUpload1.FileName)
        Dim date_time As Date = Date.Now

        Dim hours As Integer = date_time.Hour
        Dim minutes As Integer = date_time.Minute

        If CDate(Date.Now).ToShortDateString = "30/09/2019" Then
            Dim aa As String = "55"
        End If
    End Sub

    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim ss As String = ""
        If aa = Nothing Then
            aa = Session("aa")
        End If
    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify("0105506000480")

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try
    End Sub

    Protected Sub btn_repeat_Click(sender As Object, e As EventArgs) Handles btn_repeat.Click
        Dim aa As Boolean = False
        Dim bb As Boolean = False
        bb = CHK_FORMAT_RCVNO(Txt_rcvno_no.Text)
        Dim RGTNO As Integer

        RGTNO = GET_FORMAT_RCVNO(Txt_rcvno_no.Text)
        aa = CHK_REPEAT(RGTNO, TextBox8.Text, TextBox7.Text)
    End Sub

    Function CHK_REPEAT(ByVal rcvno As String, ByVal rgttpcd As String, ByVal drgtpcd As String) As Boolean
        Dim bool As Boolean = False
        Try
            Dim i As Integer = 0
            Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
            i = dao_rqt.COUNT_REPEAT_RGTNO(rcvno, rgttpcd, drgtpcd)
            'Dim max_rcvno As Integer = dao_rqt.fields.rgtno
            If i > 0 Then
                bool = False

            Else
                bool = True
            End If
        Catch ex As Exception

        End Try

        Return bool
    End Function

    Function CHK_FORMAT_RCVNO(ByVal txt As String) As Boolean
        Dim bool As Boolean = True
        Try
            Dim split_text As String() = txt.Split("/")
            Dim len_1 As Integer = 0
            Dim len_2 As Integer = 0
            len_1 = Len(split_text(0))
            len_2 = Len(split_text(1))

            If len_2 < 2 Then
                Return False
            End If
            If len_2 > 2 Then
                Return False
            End If
            If len_1 < 1 Then
                Return False
            End If


        Catch ex As Exception
            bool = False
        End Try


        Return bool
    End Function
    Function GET_FORMAT_RCVNO(ByVal txt As String) As Integer
        Dim rcvno As String = ""
        Dim running As Integer = 0
        Dim year_short As String = ""
        Dim split_text As String() = txt.Split("/")

        Try
            running = CInt(split_text(0))
            year_short = split_text(1)
            rcvno = String.Format("{0:00000}", running.ToString("00000"))
            rcvno = year_short & rcvno
        Catch ex As Exception

        End Try

        Return rcvno
    End Function

    Protected Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim aa As String = WS_GET_ALL_DRRGT_EDIT_REQUEST()
    End Sub

    Public Function WS_GET_ALL_DRRGT_EDIT_REQUEST() As String
        Dim aa As String = ""
        Dim bao As New BAO_SHOW
        Try
            aa = bao.SP_GET_ALL_DRRGT_EDIT_REQUEST()
        Catch ex As Exception

        End Try

        Return aa
    End Function

    Protected Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim aa As String = ""
        Dim result As String = ""
        aa = "23698aaas2"
        result = NumEng2Thai(aa)

        'result = NumEng2Thai(con_year(2563))
    End Sub
    'Function NumEng2Thai(strEng As String) As String
    '    Dim strThai As String = ""
    '    Dim strTemp As Byte
    '    Dim i As Byte
    '    'strEng = "258963147"
    '    For i = 1 To Len(strEng)
    '        strTemp = Asc(Mid$(strEng, i, 1)) + 192
    '        strThai = strThai & Chr(strTemp)
    '    Next
    '    NumEng2Thai = strThai
    'End Function

    Protected Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(40667)
        Dim aa As Date
        If CDate(dao.fields.appdate).ToString("yyyy/MM/dd") >= "2562/01/10" Then

            Dim bb As String = "2"
        End If


    End Sub


    Private Sub insrt_to_database_new(ByVal _IDA_REGIST As Integer)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_rg.GetDataby_IDA(_IDA_REGIST)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao_rg.fields.FK_IDA)
        Try


            Try
                dao.fields.IDENTIFY = dao_lcn.fields.CITIZEN_ID_AUTHORIZE
            Catch ex As Exception

            End Try
            Try
                dao.fields.DRUG_STRENGTH = dao_rg.fields.DRUG_STR
            Catch ex As Exception

            End Try
            Try
                dao.fields.ctgcd = dao_rg.fields.DRUG_GROUP
            Catch ex As Exception

            End Try
            Try
                dao.fields.DRUG_STYLE = dao_rg.fields.DRUG_STYLE
            Catch ex As Exception

            End Try
            Try
                dao.fields.UNIT_BIO = dao_rg.fields.UNIT_BIO
            Catch ex As Exception

            End Try
            Try
                dao.fields.UNIT_NORMAL = dao_rg.fields.UNIT_NORMAL
            Catch ex As Exception

            End Try
            Try
                dao.fields.DRUG_PACKING = dao_rg.fields.DRUG_PACKING
            Catch ex As Exception

            End Try
            Try
                dao.fields.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try
                dao.fields.lpvncd = dao_lcn.fields.pvncd
            Catch ex As Exception

            End Try

        Catch ex As Exception
            'dao.fields.TABEAN_TYPE1 = "99"
        End Try

        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID("1400001")
        Try
            dao.fields.rgttpcd = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            dao.fields.PROCESS_ID = "1400001"
        Catch ex As Exception

        End Try
        Try
            dao.fields.ctgcd = dao_rg.fields.ctgcd
        Catch ex As Exception

        End Try
        Try
            dao.fields.kindcd = dao_rg.fields.kindcd
        Catch ex As Exception

        End Try
        Try
            dao.fields.dsgcd = dao_rg.fields.FK_DOSAGE_FORM
        Catch ex As Exception

        End Try
        Try
            dao.fields.classcd = dao_rg.fields.GROUP_TYPE
        Catch ex As Exception

        End Try
        Try
            dao.fields.FK_DOSAGE_FORM = dao_rg.fields.FK_DOSAGE_FORM
        Catch ex As Exception

        End Try
        Try
            dao.fields.kindcd = dao_rg.fields.kindcd
        Catch ex As Exception

        End Try

        dao.fields.STATUS_ID = 8
        dao.fields.FK_IDA = _IDA_REGIST
        dao.fields.lcnsid = dao_lcn.fields.lcnsid
        Try
            dao.fields.pvncd = "10"
        Catch ex As Exception

        End Try

        dao.fields.FK_LCN_IDA = dao_rg.fields.FK_IDA
        Try
            dao.fields.thadrgnm = dao_rg.fields.DRUG_NAME_THAI
        Catch ex As Exception

        End Try
        Try
            dao.fields.engdrgnm = dao_rg.fields.DRUG_NAME_OTHER
        Catch ex As Exception

        End Try
        Try
            dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
        Catch ex As Exception

        End Try
        Try
            dao.fields.lcnno = dao_lcn.fields.lcnno
        Catch ex As Exception

        End Try
        
        Try
            dao.fields.classcd = dao_rg.fields.GROUP_TYPE 'ประเภทของยา
        Catch ex As Exception

        End Try
        Try
            dao.fields.PACKAGE_DETAIL = dao_rg.fields.PACKAGE_DETAIL
        Catch ex As Exception

        End Try
        dao.fields.pvnabbr = dao_lcn.fields.pvnabbr
        'dao.fields.rcvdate = Date.Now
        '  dao.fields.xmlnm = "FA-8-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
        dao.fields.TR_ID = 0
        dao.fields.cscd = Nothing
        dao.fields.rgtno = dao_rg.fields.rgtno
        dao.fields.rgttpcd = dao_rg.fields.rgttpcd
        dao.fields.drgtpcd = dao_rg.fields.drgtpcd
        dao.fields.FK_IDA = dao_rg.fields.IDA
        dao.fields.FK_REGIS = dao_rg.fields.IDA
        dao.fields.rcvno = dao_rg.fields.RCVNO
        dao.fields.rcvdate = dao_rg.fields.RCVDATE
        dao.fields.rqttpcd = dao_rg.fields.rgttpcd
        dao.fields.rgtdrgtpcd = dao_rg.fields.drgtpcd
        'dao.fields.appdate = dao_rg.fields.
        dao.insert()

        Dim dao_rg_atc As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
        dao_rg_atc.GetDataby_FK_IDA(_IDA_REGIST)
        For Each dao_rg_atc.fields In dao_rg_atc.datas
            Try
                Dim dao_atc2 As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                dao_atc2.fields.FK_IDA = dao.fields.IDA
                dao_atc2.fields.ATC_IDA = dao_rg_atc.fields.ATC_IDA
                dao_atc2.fields.ATC_CODE = Trim(dao_rg_atc.fields.ATC_CODE)
                dao_atc2.insert()
            Catch ex As Exception

            End Try

        Next



        Dim bao_show As New BAO_SHOW
        Dim dt_DRUG_REGISTRATION_PACKAGE As New DataTable
        Dim dt_DRUG_REGISTRATION_ATC_DETAIL As New DataTable
        Dim dt_DRUG_REGISTRATION_DETAIL_CAS As New DataTable
        Dim dt_DRUG_REGISTRATION_DETAIL_CAS_I As New DataTable
        Dim dt_DRUG_REGISTRATION_PROPERTIES As New DataTable
        Dim dt_DRUG_REGISTRATION_PRODUCER As New DataTable
        Dim dt_DRUG_REGISTRATION_PRODUCER_IN As New DataTable
        'Dim dt_DRUG_REGISTRATION_EQTO As New DataTable

        dt_DRUG_REGISTRATION_DETAIL_CAS = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA(_IDA_REGIST)
        dt_DRUG_REGISTRATION_PACKAGE = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_IDA_REGIST)
        dt_DRUG_REGISTRATION_ATC_DETAIL = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_IDA_REGIST)

        dt_DRUG_REGISTRATION_PROPERTIES = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_IDA_REGIST)
        dt_DRUG_REGISTRATION_PRODUCER = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(_IDA_REGIST)

        dt_DRUG_REGISTRATION_PRODUCER_IN = bao_show.SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA(_IDA_REGIST)

        Dim main_ida As Integer = 0
        Try
            main_ida = dao.fields.IDA
        Catch ex As Exception

        End Try

        'Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
        Dim iii As Integer = 1
        For Each dr As DataRow In dt_DRUG_REGISTRATION_DETAIL_CAS.Rows
            Dim dao_cas2 As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
            dao_cas2.fields.FK_IDA = main_ida
            Try
                dao_cas2.fields.BASE_FORM = dr("BASE_FORM")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.EQTO_IOWA = dr("EQTO_IOWA")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.EQTO_SUNITCD = dr("EQTO_SUNITCD")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.IOWA = dr("IOWA")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.QTY = dr("QTY")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.SUNITCD = dr("SUNITCD")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.AORI = dr("AORI")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.REMARK = dr("REMARK")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.REF = dr("REF")
            Catch ex As Exception

            End Try
            Try
                dao_cas2.fields.FK_SET = dr("FK_SET")
            Catch ex As Exception

            End Try
            dao_cas2.fields.ROWS = dr("ROWS")
            dao_cas2.insert()

            Dim dao_eq As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
            dao_eq.GetDataby_FK_IDA(dr("IDA"))
            'Dim i_eq As Integer = 0
            For Each dao_eq.fields In dao_eq.datas
                'i_eq += 1
                Dim dao_rq_eq As New DAO_DRUG.TB_DRRQT_EQTO
                With dao_rq_eq.fields
                    .FK_IDA = dao_cas2.fields.IDA
                    Try
                        .IOWA = dao_eq.fields.IOWA
                    Catch ex As Exception

                    End Try
                    Try
                        .MULTIPLY = dao_eq.fields.MULTIPLY
                    Catch ex As Exception

                    End Try
                    Try
                        .QTY = dao_eq.fields.QTY
                    Catch ex As Exception

                    End Try
                    Try
                        .ROWS = dao_eq.fields.ROWS
                    Catch ex As Exception

                    End Try

                    Try
                        .STR_VALUE = dao_eq.fields.STR_VALUE
                    Catch ex As Exception

                    End Try
                    Try
                        .SUNITCD = dao_eq.fields.SUNITCD
                    Catch ex As Exception

                    End Try
                    Try
                        .aori = dao_eq.fields.aori
                    Catch ex As Exception

                    End Try
                    Try
                        .FK_SET = dao_eq.fields.FK_SET
                    Catch ex As Exception

                    End Try
                    Try
                        .FK_DRRQT_IDA = main_ida
                    Catch ex As Exception

                    End Try
                End With
                dao_rq_eq.insert()
            Next

            iii += 1
        Next

        Dim dao_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_pack.GetDataby_FK_IDA(_IDA_REGIST)
        For Each dao_pack.fields In dao_pack.datas
            Dim dao_pa2 As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
            dao_pa2.fields.FK_IDA = main_ida
            Try
                dao_pa2.fields.BARCODE = dao_pack.fields.BARCODE
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.BIG_UNIT = dao_pack.fields.BIG_UNIT
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.SMALL_UNIT = dao_pack.fields.SMALL_UNIT
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.BIG_AMOUNT = dao_pack.fields.BIG_AMOUNT
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.DATE_ADD = Date.Now
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.IM_DETAIL = dao_pack.fields.IM_DETAIL
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.IM_QTY = dao_pack.fields.IM_QTY
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.PACKAGE_NAME = dao_pack.fields.PACKAGE_NAME
            Catch ex As Exception

            End Try
            Try
                dao_pa2.fields.SUM = dao_pack.fields.SUM
            Catch ex As Exception

            End Try
            dao_pa2.insert()
        Next

        For Each dr As DataRow In dt_DRUG_REGISTRATION_PRODUCER.Rows
            Dim dao_pro2 As New DAO_DRUG.TB_DRRQT_PRODUCER
            dao_pro2.fields.FK_IDA = main_ida
            Try
                dao_pro2.fields.addr_ida = dr("addr_ida")
            Catch ex As Exception

            End Try
            Try
                dao_pro2.fields.FK_PRODUCER = dr("FK_PRODUCER")
            Catch ex As Exception

            End Try
            Try
                dao_pro2.fields.PRODUCER_WORK_TYPE = dr("PRODUCER_WORK_TYPE")
            Catch ex As Exception

            End Try
            Try
                dao_pro2.fields.REFERENCE_GMP = dr("REFERENCE_GMP")
            Catch ex As Exception

            End Try

            dao_pro2.insert()
        Next

        For Each dr As DataRow In dt_DRUG_REGISTRATION_PROPERTIES.Rows
            Dim dao_prop2 As New DAO_DRUG.TB_DRRQT_PROPERTIES
            dao_prop2.fields.FK_IDA = main_ida
            Try
                dao_prop2.fields.CHK_DRUG_PROPERTIES = dr("CHK_DRUG_PROPERTIES")
            Catch ex As Exception

            End Try
            Try
                dao_prop2.fields.CHK_DRUG_PROPERTIES_OTHER = dr("CHK_DRUG_PROPERTIES_OTHER")
            Catch ex As Exception

            End Try
            Try
                dao_prop2.fields.DRUG_PROPERTIES = dr("DRUG_PROPERTIES")
            Catch ex As Exception

            End Try
            Try
                dao_prop2.fields.DRUG_PROPERTIES_OTHER = dr("DRUG_PROPERTIES_OTHER")
            Catch ex As Exception

            End Try

            dao_prop2.insert()
        Next

        For Each dr As DataRow In dt_DRUG_REGISTRATION_ATC_DETAIL.Rows
            Dim dao_r_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
            dao_r_atc.fields.FK_IDA = main_ida
            Try
                dao_r_atc.fields.ATC_CODE = dr("ATC_CODE")
            Catch ex As Exception

            End Try

            dao_r_atc.insert()
        Next

        Dim dao_pro_rgtin As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
        dao_pro_rgtin.GetDataby_FK_IDA(_IDA_REGIST)
        For Each dao_pro_rgtin.fields In dao_pro_rgtin.datas
            Dim dao_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
            dao_pro_in.fields.FK_IDA = main_ida
            dao_pro_in.fields.FK_LCN_IDA = dao_pro_rgtin.fields.FK_PRODUCER
            Try
                dao_pro_in.fields.funccd = dao_pro_rgtin.fields.PRODUCER_WORK_TYPE
            Catch ex As Exception

            End Try

            dao_pro_in.insert()
        Next


        Dim dao_pro_color As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
        dao_pro_color.GetDataby_FK_IDA(_IDA_REGIST)
        For Each dao_pro_color.fields In dao_pro_color.datas
            Dim dao_color As New DAO_DRUG.TB_DRRQT_COLOR
            dao_color.fields.FK_IDA = main_ida
            dao_color.fields.COLOR_NAME1 = dao_pro_color.fields.COLOR_NAME1
            dao_color.fields.COLOR_NAME2 = dao_pro_color.fields.COLOR_NAME2
            dao_color.fields.COLOR_NAME3 = dao_pro_color.fields.COLOR_NAME3
            dao_color.fields.COLOR_NAME4 = dao_pro_color.fields.COLOR_NAME4
            dao_color.fields.COLOR1 = dao_pro_color.fields.COLOR1
            dao_color.fields.COLOR2 = dao_pro_color.fields.COLOR2
            dao_color.fields.COLOR3 = dao_pro_color.fields.COLOR3
            dao_color.fields.COLOR4 = dao_pro_color.fields.COLOR4
            dao_color.insert()
        Next


        Dim dao_each As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
        dao_each.GetDataby_FK_IDA(_IDA_REGIST)
        For Each dao_each.fields In dao_each.datas
            Dim dao_dr_each As New DAO_DRUG.TB_DRRQT_EACH
            dao_dr_each.fields.FK_IDA = main_ida
            dao_dr_each.fields.EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
            Try
                dao_dr_each.fields.sunitcd = dao_each.fields.sunitcd
            Catch ex As Exception

            End Try
            Try
                dao_dr_each.fields.FK_SET = dao_each.fields.FK_SET
            Catch ex As Exception

            End Try
            dao_dr_each.insert()
        Next

        Dim dao_KEEP_DRUG As New DAO_DRUG.TB_DRUG_REGISTRATION_KEEP_DRUG
        dao_KEEP_DRUG.GetDataby_FK_IDA(_IDA_REGIST)
        For Each dao_KEEP_DRUG.fields In dao_KEEP_DRUG.datas
            Dim dao_DRRGT_KEEP As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
            With dao_DRRGT_KEEP.fields
                .FK_IDA = main_ida
                .AGE_DAY = dao_KEEP_DRUG.fields.AGE_DAY
                .AGE_HOUR = dao_KEEP_DRUG.fields.AGE_HOUR
                .AGE_MONTH = dao_KEEP_DRUG.fields.AGE_MONTH
                '.DRUG_DETAIL = dao_KEEP_DRUG.fields.KEEP_DETAIL
                .KEEP_DESCRIPTION = dao_KEEP_DRUG.fields.KEEP_DETAIL
                .TEMPERATE1 = dao_KEEP_DRUG.fields.TEMPERATE1
                .TEMPERATE2 = dao_KEEP_DRUG.fields.TEMPERATE2
            End With
            dao_DRRGT_KEEP.insert()
        Next

        Dim dao_rq_DRUG_USE As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
        dao_rq_DRUG_USE.GetDataby_FK_IDA(_IDA_REGIST)
        For Each dao_rq_DRUG_USE.fields In dao_rq_DRUG_USE.datas
            Dim dao_DRRGT_DTL As New DAO_DRUG.TB_DRRQT_DTL_TEXT
            With dao_DRRGT_DTL.fields
                .FK_IDA = main_ida
                .dtl = dao_rq_DRUG_USE.fields.DRUG_USE
            End With
            dao_DRRGT_DTL.insert()
        Next


        Dim dao_rq_ANI As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL
        dao_rq_ANI.GetData_by_FK_IDA(_IDA_REGIST)
        For Each dao_rq_ANI.fields In dao_rq_ANI.datas


            Dim dao_ani As New DAO_DRUG.ClsDBdrramldrg
            With dao_ani.fields
                .FK_IDA = main_ida
                .amlsubcd = dao_rq_ANI.fields.amlsubcd
                .amltpcd = dao_rq_ANI.fields.amltpcd
                .drgtpcd = dao_rq_ANI.fields.drgtpcd
                .pvncd = dao_rq_ANI.fields.pvncd
                .rgtno = dao_rq_ANI.fields.rgtno
                .rgttpcd = dao_rq_ANI.fields.rgttpcd
                .usetpcd = dao_rq_ANI.fields.usetpcd
            End With
            dao_ani.insert()

            Dim dao_rq_anisub As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL_SUB
            dao_rq_anisub.GetDataby_FK_IDA(dao_rq_ANI.fields.IDA)
            For Each dao_rq_anisub.fields In dao_rq_anisub.datas
                Dim dao_ani_sub As New DAO_DRUG.ClsDBdrramluse
                With dao_ani_sub.fields
                    .FK_IDA = dao_ani.fields.IDA
                    .amlsubcd = dao_rq_anisub.fields.amlsubcd
                    .amltpcd = dao_rq_anisub.fields.amltpcd
                    .ampartcd = dao_rq_anisub.fields.ampartcd
                    .drgtpcd = dao_rq_anisub.fields.drgtpcd
                    .nouse = dao_rq_anisub.fields.nouse
                    .packuse = dao_rq_anisub.fields.packuse
                    .pvncd = dao_rq_anisub.fields.pvncd
                    .rgtno = dao_rq_anisub.fields.rgtno
                    .rgttpcd = dao_rq_anisub.fields.rgttpcd
                    .STOP_UNIT1 = dao_rq_anisub.fields.STOP_UNIT1
                    .STOP_UNIT2 = dao_rq_anisub.fields.STOP_UNIT2
                    .STOP_VALUE1 = dao_rq_anisub.fields.STOP_VALUE1
                    .STOP_VALUE2 = dao_rq_anisub.fields.STOP_VALUE2
                    .stpdrg = dao_rq_anisub.fields.stpdrg
                    .stpdrgcd = dao_rq_anisub.fields.stpdrgcd
                    .usetpcd = dao_rq_anisub.fields.usetpcd
                End With
                dao_ani_sub.insert()
            Next

        Next


        'Dim dao_prop_det As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
        'dao_prop_det.fields.FK_IDA = main_ida
        'Try
        '    dao_prop_det.fields.DRUG_PROPERTIES_AND_DETAIL = dao_rg.fields.DRUG_COLOR
        '    dao_prop_det.fields.ROWS = 1
        'Catch ex As Exception

        'End Try

        'dao_prop_det.insert()

    End Sub

    Protected Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        insrt_to_database_new(txt_regis_id.Text)
    End Sub

    Protected Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'Dim aa As DateTime = Date.Now
        'Dim bb As Integer = aa.Hour

        'Dim StartTime As Date = #11:00:00 PM#
        'Dim EndTime As Date = #11:59:59 PM#
        'Dim CurrentTime As Date = #12:01:00 AM#

        'If EndTime.Ticks < StartTime.Ticks Then
        '    If (CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks >= EndTime.Ticks) Or _
        '        (CurrentTime.Ticks <= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks) Then
        '        Console.WriteLine("Time is within range.")
        '    Else
        '        Console.WriteLine("Time is outside of range.")
        '    End If
        'Else
        '    If CurrentTime.Ticks >= StartTime.Ticks And CurrentTime.Ticks <= EndTime.Ticks Then
        '        Console.WriteLine("Time is within range.")
        '    Else
        '        Console.WriteLine("Time is outside of range.")
        '    End If
        'End If


        'Dim curr As Date = Date.Now
        'Dim startTime As New Date(curr.Year, curr.Month, curr.Day, 6, 0, 0)
        'Dim endTime As New Date(curr.Year, curr.Month, curr.Day, 11, 0, 0)
        'If (curr >= startTime) And (curr <= endTime) Then
        '    ' Do something
        'End If

        Dim t1 As Date = "11:00:00 PM"

        Dim t2 As Date = "11:59:59 PM"

        Dim CurrentTime As DateTime = Convert.ToDateTime(DateTime.Now)

        'If CurrentTime.Ticks >= t1.Ticks And CurrentTime.Ticks <= t2.Ticks Then
        If CurrentTime.Hour = 23 Then
            Dim aa As String = ""

        Else
            Dim bb As String = ""

        End If
    End Sub

    Protected Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.CITIZEN_ID = "1710500118665"
        bao_tran.CITIZEN_ID_AUTHORIZE = "0105519002915"
        TR_ID = bao_tran.insert_transection("1400001") 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION
    End Sub

    Protected Sub btn_update_stat_Click(sender As Object, e As EventArgs) Handles btn_update_stat.Click
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SELECT_LCN_EXTEND_LITE_UPDATE()
        Dim ws_update As New WS_DRUG.WS_DRUG
        ''For Each dr As DataRow In dt.Rows
        ''    ws_update.DRUG_UPDATE_LICEN(dr("FK_IDA"), _cls)
        ''    bao.SP_UPDATE_LCN_EXTEND_LITE_UPDATE(dr("FK_IDA"))
        ''Next
        'SP_UPDATE_LCN_EXTEND_LITE_UPDATE
    End Sub

    Protected Sub btn_geneqto_Click(sender As Object, e As EventArgs) Handles btn_geneqto.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.GET_TEMP_EQTO()

        For Each dr As DataRow In dt.Rows
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(dr("FK_DRRQT_IDA"))
            For Each dao_cas.fields In dao_cas.datas
                Dim i As Integer = 1
                Dim dao_eqto As New DAO_DRUG.TB_DRRGT_EQTO
                dao_eqto.GetDataby_FK_IDA(dao_cas.fields.IDA)
                For Each dao_eqto.fields In dao_eqto.datas
                    Dim dao_eqto_u As New DAO_DRUG.TB_DRRGT_EQTO
                    dao_eqto_u.GetDataby_IDA(dao_eqto.fields.IDA)
                    dao_eqto_u.fields.ROWS = i
                    dao_eqto_u.update()
                    i += 1
                Next
                Dim bao2 As New BAO.ClsDBSqlcommand
                bao2.UPDATE_TEMP_EQTO(dr("FK_DRRQT_IDA"))
            Next
        Next


    End Sub

    Protected Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim wss As New WS_ACCEPT_RGT_AUTO
        wss.ACCEPT_AND_RUNNING_RGTNO(TextBox1.Text)
    End Sub

    Protected Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        
        Dim a As String = QR_CODE_IMG("https://medicina.fda.moph.go.th/FDA_DRUG/PDF/FRM_PDF.aspx?filename=D%3A%5Cpath%5CDRUG%5CPDF_TRADER_APPROVE%5CDA-1400001-2563-177262.pdf&fbclid=IwAR3FtzKM__HCxflcobFmXypHYLsw_zRLXZyoid3oayNKg1XRDeCm7_32VGg")
        RadBinaryImage1.DataValue = ConvertBase64ToByteArray(a)
    End Sub
    Public Function ConvertBase64ToByteArray(base64 As String) As Byte()
        Return Convert.FromBase64String(base64) 'Convert the base64 back to byte array.
    End Function

    Protected Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim ws_drug1 As New WS_DRUG.WS_DRUG
        ws_drug1.Timeout = 50000
        ws_drug1.DRUG_INSERT_DR(txt_pvncd.Text, txt_rgttpcd.Text, txt_drgtpcd.Text, txt_rgtno.Text, "อนุมัติทะเบียน", "1710500118665", "DRUG")
    End Sub

    Protected Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim dao As New DAO_DRUG.TB_A_TEST
        dao.GetDataby_All()
        For Each dao.fields In dao.datas
            dao.delete()
        Next
    End Sub

    Protected Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim ws_gen As New WS_GEN_DH_NO
        'ws_gen.WS_INSERT_R_NO("4", "0105519000157", "3669900194895", "ที่อยู่ตามทะเบียนบ้าน", "บ้านเลขที่ 14 ซอย ซอยงามวงศ์วาน 8 ถนน งามวงศ์วาน ตำบล บางเขน อำเภอ เมืองนนทบุรี จังหวัด นนทบุรี 11000", "10", "63012100205020008767")
        'ws_gen.GEN_DH_NO(48968)


        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_INSERT_DR15(txt_dh_ida.Text, "1710500118665")
    End Sub

    Protected Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        '
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SELECT_TEMP_UPDATE_dalcn_UPDATE()
        'For Each dr As DataRow In dt.Rows
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.Timeout = 180000
        'ws_update.DRUG_UPDATE_LICEN(dr("IDA_dalcn"), "1710500118665")
        ws_update.DRUG_UPDATE_LICEN(TextBox10.Text, "1710500118665")
        ' Next

    End Sub

    Protected Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim ws_update As New WS_DRUG.WS_DRUG
        'ws_update.DRUG_UPDATE_LICEN(dr("IDA_dalcn"), "1710500118665")
        Dim bao_iso As New BAO.ClsDBSqlcommand
        Dim dt_iso As New DataTable
        dt_iso = bao_iso.Query_get_data_lcn_no_sai()
        For Each dr As DataRow In dt_iso.Rows
            ws_update.DRUG_INSERT_LICEN(dr("IDA"), "1710500118665")
        Next

    End Sub

    Protected Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_INSERT_DR15(52482, "1710500118665")
    End Sub

    Protected Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Dim aa As String = System.IO.Path.GetExtension(FileUpload2.FileName)
        Dim i As Integer = 0
        If Not (aa.Contains("pdf") Or aa = "") Then
            i += 1
        End If
    End Sub

    Protected Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click

        Try
            Dim dao_XML_DRUG_FRGN As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_FRGN
            dao_XML_DRUG_FRGN.GetDataby_u1("U1DR1F1042540000711C")
            If dao_XML_DRUG_FRGN.fields.engcntnm = "ไทย" Then
                For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
                    Dim dao_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                    With dao_in.fields
                        .FK_IDA = 0
                        Try
                            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                            'dao_dal.GetDataby_pvncd_lcnno_lcntpcd(dao_XML_DRUG_FRGN.fields.pvncd, dao_XML_DRUG_FRGN.fields.lcnno, dao_XML_DRUG_FRGN.fields.lcntpcd)
                            dao_dal.GetDataby_citi_lcnno(dao_XML_DRUG_FRGN.fields.CITIZEN_AUTHORIZE, dao_XML_DRUG_FRGN.fields.lcnno)
                            .FK_LCN_IDA = dao_dal.fields.IDA
                        Catch ex As Exception

                        End Try
                        .funccd = dao_XML_DRUG_FRGN.fields.funccd
                        'dao_in.insert()
                    End With
                Next
            Else
                For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
                    Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
                    With dao_pro.fields
                        .FK_IDA = 0
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
                            Dim bao_iso As New BAO.ClsDBSqlcommand
                            Dim dt_iso As New DataTable
                            dt_iso = bao_iso.SP_sysisocnt_SAI_by_engcntnm(dao_XML_DRUG_FRGN.fields.engcntnm) '
                            Dim alpha3 As String = ""
                            Try
                                alpha3 = dt_iso(0)("alpha3")
                            Catch ex As Exception

                            End Try
                            Dim dao_frgn_addr As New DAO_DRUG.ClsDBdrfrgnaddr
                            'dao_frgn_addr.GetDataAll_v2(dao_XML_DRUG_FRGN.fields.addr, alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.fax, dao_XML_DRUG_FRGN.fields.mu, _
                            'dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.road, dao_XML_DRUG_FRGN.fields.soi, dao_XML_DRUG_FRGN.fields.subdiv, dao_XML_DRUG_FRGN.fields.tel, _
                            'dao_XML_DRUG_FRGN.fields.zipcode, dao_frgn_name.fields.frgncd)
                            dao_frgn_addr.GetDataAll_v3(dao_XML_DRUG_FRGN.fields.addr, alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.subdiv, dao_frgn_name.fields.frgncd)

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
                    ' dao_pro.insert()
                Next


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_gen_dh_Click(sender As Object, e As EventArgs) Handles btn_gen_dh.Click
        Dim ws_gen As New WS_GEN_DH_NO
        ws_gen.GEN_DH_NO(TextBox11.Text)
    End Sub

    Protected Sub btn_t_auto_Click(sender As Object, e As EventArgs) Handles btn_t_auto.Click
        Dim ws As New WS_ACCEPT_RGT_AUTO
        ws.ACCEPT_AND_RUNNING_RGTNO(97039)
    End Sub
    Private Sub runpdf_lcn()
        Dim dt_drug_general As New DataTable
        Dim dt_phr As New DataTable
        Dim dt_frgn As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim bao_show As New BAO_SHOW
        Dim BAO_MAS As New BAO_MASTER
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()


        dt_drug_general = bao_master_2.SP_GET_DATA_DALCN_BY_IDA(57440)
        dt_phr = BAO_MAS.SP_DALCN_PHR_BY_FK_IDA_2(57440)
        'dt_frgn = bao_show.SP_REGIST_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))

        'SP_DRRGT_ATC_DETAIL_BY_FK_IDA
        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight(width:=1000)


        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "rp_drug_general", dt_drug_general)
        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "'rp_drug", dt_drug_general)
        ReportViewer1.LocalReport.ReportPath = bao_app._RDLC & "\lcn_data.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
        Dim rds As New ReportDataSource("rp_main_data", dt_drug_general)
        Dim rds2 As New ReportDataSource("rp_phr", dt_phr)
        'Dim rds3 As New ReportDataSource("rp_drug_recipe_group", dt_drug_recipe)


        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        'ReportViewer1.LocalReport.DataSources.Add(rds3)
        'ReportViewer1.LocalReport.DataSources.Add(rds4)
        'ReportViewer1.LocalReport.DataSources.Add(rds5)
        'ReportViewer1.LocalReport.DataSources.Add(rds6)
        'ReportViewer1.LocalReport.DataSources.Add(rds7)




        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = ReportViewer1.LocalReport.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)
        Dim clsds As New ClassDataset

        clsds.bynaryToobject2(bao_app._RDLC & 57440 & ".pdf", renderedbytes)
        Dim filename As String = 57440 & ".pdf"
        Dim saveLocation As String = bao_app._RDLC & "/" & filename

        'Response.Redirect(bao_app._RDLC & tr_id & ".pdf")
        load_pdf(saveLocation, filename)
        ' Response.Redirect("../PDF/" & tr_id & ".pdf")

        'Response.Redirect("../PDF/" & tr_id & ".pdf")

        ''ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        'Response.AddHeader("Accept-Ranges", "bytes")
        'Response.AddHeader("Accept-Header", "2222")
        'Response.AddHeader("Cache-Control", "public")
        'Response.AddHeader("Cache-Control", "must-revalidate")
        'Response.AddHeader("Pragma", "public")
        ''Response.AddHeader()
        ''Response.AddHeader("Content-Encoding", "UTF-8")

        ''Response.ContentEncoding = System.Text.Encoding.Unicode   'GetEncoding(874)
        ''Response.Charset = "windows-874"
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-disposition", "inline; filename=""" + "Test.pdf" + """")
        'Response.AddHeader("expires", "0")


        'Response.BinaryWrite(renderedbytes)
        'Response.Flush()
    End Sub

    Protected Sub btn_rp_lcn_Click(sender As Object, e As EventArgs) Handles btn_rp_lcn.Click
        runpdf_lcn()
    End Sub
    Private Sub load_pdf(ByVal FilePath As String, ByVal filename As String)
        'Response.ContentType = "Application/pdf"
        Dim last_nm_file As String = ""
        Dim split_nm As String() = filename.Split(".")
        last_nm_file = split_nm(split_nm.Length - 1)
        Response.ContentType = "Content-Disposition"
        If last_nm_file = "txt" Then
            Response.ContentType = "text/plain"
        ElseIf last_nm_file = "jpg" Then
            Response.ContentType = "image/JPEG"
        ElseIf last_nm_file = "png" Then
            Response.ContentType = "image/png"
        ElseIf last_nm_file = "pdf" Then
            Response.ContentType = "application/pdf"
        ElseIf last_nm_file = "doc" Or last_nm_file = "docx" Then
            Response.ContentType = "application/msword"
        End If

        Response.WriteFile(FilePath)
        Response.End()
    End Sub
End Class