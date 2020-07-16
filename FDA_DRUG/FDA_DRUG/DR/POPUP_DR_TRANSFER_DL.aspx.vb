Imports Telerik.Web.UI
Imports System.Xml.Serialization
Imports System.IO

Public Class POPUP_DR_TRANSFER_DL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer
    Private _main_ida As String = ""
    Sub RunSession()
        Try
            _CLS = Session("CLS")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Try
            _process = Request.QueryString("process")
            _main_ida = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
    End Sub
    Sub Search_FN()
        If txt_lcnno_no.Text <> "" Then
            Dim bao As New BAO.ClsDBSqlcommand
            bao.SP_DRRGT_FOR_SEARCH(txt_lcnno_no.Text)
            Dim dt As New DataTable
            Try
                dt = bao.dt
            Catch ex As Exception

            End Try
            Dim r_result As DataRow()
            Dim str_where As String = ""
            Dim dt2 As New DataTable
            'str_where = "CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
            If txt_lcnno_no.Text <> "" Then
                str_where &= "rgtno_display like '%" & txt_lcnno_no.Text & "%'"
            End If
            r_result = dt.Select(str_where)

            dt2 = dt.Clone

            For Each dr As DataRow In r_result
                dt2.Rows.Add(dr.ItemArray)
            Next
            RadGrid1.DataSource = dt2
            RadGrid1.Rebind()

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกเลขทะเบียนตำรับ');", True)
        End If

    End Sub

    'Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
    '    Search_FN()
    'End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            If e.CommandName = "dow" Then
                Try
                    If RadioButtonList1.SelectedValue <> "" Then
                        Dim dao As New DAO_DRUG.ClsDBdrrgt
                        dao.GetDataby_IDA(IDA)
                        Bind_PDF(_main_ida, _process, IDA, dao.fields.FK_LCN_IDA)
                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกประเภท');", True)
                    End If

                Catch ex As Exception

                End Try

            End If
        End If
    End Sub

    Private Sub Bind_PDF(ByVal main_ida As Integer, ByVal process As Integer, ByVal ida_transfer As Integer, ByVal lcn_ida As Integer)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_TABEAN(process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml, process, ida_transfer, lcn_ida)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()

        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML(ByVal path As String, ByVal Process_id As Integer, ByVal ida_transfer As Integer, ByVal _lcn_ida As Integer)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                TABEAN_TYPE1 = "0"
                TABEAN_TYPE2 = "1"
            Else
                TABEAN_TYPE1 = "1"
                TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try
        Dim dao_re As New DAO_DRUG.ClsDBdrrgt
        dao_re.GetDataby_IDA(ida_transfer)


        Try
            drug_name = dao_re.fields.thadrgnm & " / " & dao_re.fields.engdrgnm
        Catch ex As Exception

        End Try

        'If Process_id = 11 Then
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, Process_id, LCN_IDA:=_lcn_ida)
        Dim cls_xml As New CLASS_DR
        cls_xml = cls.gen_xml()
        Try
            Dim dao_dos As New DAO_DRUG.TB_drdosage
            dao_dos.GetDataby_cd(dao_re.fields.FK_DOSAGE_FORM)
            cls_xml.Dossage_form = dao_dos.fields.thadsgnm
        Catch ex As Exception
            cls_xml.Dossage_form = ""
        End Try
        If cls_xml.Dossage_form = "" Then
            Try
                Dim dao_dos As New DAO_DRUG.TB_drdosage
                dao_dos.GetDataby_cd(dao_re.fields.dsgcd)
                cls_xml.Dossage_form = dao_dos.fields.thadsgnm
            Catch ex As Exception
                cls_xml.Dossage_form = ""
            End Try
        End If
        Dim dt_pack As New DataTable
        Try
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_DRRGT_PACKAGE_DETAIL_BY_IDA_V2(ida_transfer)
            cls_xml.PACK_SIZE = dt_pack(0)("full_unit")
        Catch ex As Exception

        End Try
        Try
            cls_xml.DRUG_PROPERTIES_AND_DETAIL = dao_re.fields.DRUG_COLOR
        Catch ex As Exception

        End Try


        cls_xml.LCN_TYPE = LCN_TYPE
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.DRUG_NAME = drug_name
        cls_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        cls_xml.TABEAN_TYPE2 = TABEAN_TYPE2
        cls_xml.DRUG_STRENGTH = dao_re.fields.DRUG_STRENGTH
        Try
            cls_xml.TRANSFER = ida_transfer
        Catch ex As Exception

        End Try
        Try
            cls_xml.drrqts.TRANSFER_TYPE = RadioButtonList1.SelectedValue
        Catch ex As Exception

        End Try
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        Dim bao_ori As New BAO.ClsDBSqlcommand
        cls_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(ida_transfer)
        cls_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        cls_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(ida_transfer)
        cls_xml.DT_SHOW.DT9.TableName = "SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA"
        cls_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA__AORI(ida_transfer, "A")
        cls_xml.DT_SHOW.DT10.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_A"
        cls_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA__AORI(ida_transfer, "I")
        cls_xml.DT_SHOW.DT11.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_I"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(ida_transfer)
        cls_xml.DT_SHOW.DT12.TableName = "SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA"

        Dim dt13 As New DataTable
        Dim dt14 As New DataTable
        Dim dt15 As New DataTable
        dt13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_transfer, 1, LCNTPCD_GROUP)
        dt14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_transfer, 2, LCNTPCD_GROUP)
        dt15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_transfer, 3, LCNTPCD_GROUP)
        If dt13.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT13 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_transfer, 1, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        End If
        If dt14.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_transfer, 2, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        End If
        If dt15.Rows.Count > 0 Then
            cls_xml.DT_SHOW.DT15 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_transfer, 3, LCNTPCD_GROUP)
            cls_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
        End If
        cls_xml.DT_SHOW.DT16 = bao_show.SP_DRUG_REGISTRATION_MASTER(_main_ida)
        cls_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_MASTER"

        cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท

        cls_xml.DT_SHOW.DT18 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(ida_transfer)
        cls_xml.DT_SHOW.DT18.TableName = "SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA_ALL"

        cls_xml.DT_SHOW.DT20 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(ida_transfer) 'สารสำคัญ/ส่วนประกอบ(รวม)
        cls_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"

        cls_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE(ida_transfer, 9, LCNTPCD_GROUP)
        cls_xml.DT_SHOW.DT21.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_OTHER"

        cls_xml.DT_SHOW.DT22 = bao_show.SP_DRRGT_PACKAGE_DETAIL_CHK_BY_FK_IDA(ida_transfer)
        cls_xml.DT_SHOW.DT22.TableName = "SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA"

        cls_xml.DT_SHOW.DT23 = bao_ori.SP_regis(_main_ida)
        cls_xml.DT_SHOW.DT23.TableName = "SP_regis"
        cls_xml.DT_SHOW.DT7 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(1) 'ผู้ดำเนิน

        

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        Dim bao_master_2 As New BAO.ClsDBSqlcommand


        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub
End Class