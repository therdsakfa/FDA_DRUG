Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_EDIT_LCN_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _process = Request.QueryString("process")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            'load_GV_lcnno()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Private Sub Bind_PDF(ByVal process As Integer)
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
        Dim PDF_TEMPLATE As String = ""
        'Try
        '    If Request.QueryString("tt") <> "" Then
        '        PDF_TEMPLATE = "DA_YOR_1_AUTO.pdf"
        '    Else
        '        PDF_TEMPLATE = dao_TEMPLATE.fields.PDF_TEMPLATE
        '    End If
        'Catch ex As Exception

        'End Try 
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                             'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml, process)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML(ByVal path As String, ByVal Process_id As Integer)
        Dim bao_show As New BAO_SHOW
        Dim cls As New CLASS_GEN_XML.DALCN_EDIT_REQUEST(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID, "1", "10") 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN_EDIT_REQUEST                                                                        ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim lct_ida As Integer = 0 '101680
        'Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        'dao.GetDataby_IDA(Request.QueryString("IDA"))
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Try
            dao_main.GetDataby_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try

        Try
            lct_ida = dao_main.fields.FK_IDA
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง

        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_main.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_5"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_main.fields.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao_main.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        If cls_xml.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        'If txt_bsn.Text <> "" Then
        '    ws2.insert_taxno(txt_bsn.Text)
        'End If




        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        'Dim MAIN_LCN_IDA As Integer = 61332

        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            If dao_main.fields.lcntpcd.Contains("4") And dao_main.fields.lcntpcd.Contains("ขย4") = False Then
                cls_xml.LCN_TYPE = "1"
            ElseIf dao_main.fields.lcntpcd.Contains("3") And dao_main.fields.lcntpcd.Contains("ขย3") = False Then
                cls_xml.LCN_TYPE = "2"
            End If

        Catch ex As Exception

        End Try

        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        'If MAIN_LCN_IDA <> 0 Then
        '    Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
        '    dao_main2.GetDataby_IDA(61332)

        '    Try
        '        'lcnno_format = 
        '        cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
        '    Catch ex As Exception

        '    End Try

        'End If
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_bsn.GetDataby_LCN_IDA(dao_main.fields.IDA)
        Catch ex As Exception

        End Try

        Dim bao_cpn As New BAO.ClsDBSqlcommand
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(dao_bsn.fields.BSN_IDENTIFY) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        cls_xml.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_main.fields.CITIZEN_ID_AUTHORIZE)
        cls_xml.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"

        cls_xml.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_main.fields.CITIZEN_ID_AUTHORIZE)
        cls_xml.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"

        Dim bao_master As New BAO_MASTER
        cls_xml.DT_SHOW.DT10 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao_main.fields.IDA)

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        cls_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(dao_main.fields.IDA)
        ' End If

        Try
            cls_xml.BSN_IDENTIFY = dao_bsn.fields.BSN_IDENTIFY
        Catch ex As Exception

        End Try

        cls_xml.RCVDATE_DISPLAY = "" 'Date.Now.ToShortDateString()
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RCVNO_FORMAT = ""
        Try

            If dao_main.fields.PROCESS_ID = "114" Then
                cls_xml.CHK_SELL_TYPE = "1"
            ElseIf dao_main.fields.PROCESS_ID = "116" Then
                cls_xml.CHK_SELL_TYPE = "2"
            ElseIf dao_main.fields.PROCESS_ID = "117" Then
                cls_xml.CHK_SELL_TYPE = "3"
            ElseIf dao_main.fields.PROCESS_ID = "115" Then
                cls_xml.CHK_SELL_TYPE = "4"
            ElseIf dao_main.fields.PROCESS_ID = "127" Or dao_main.fields.PROCESS_ID = "123" Or dao_main.fields.PROCESS_ID = "125" Or dao_main.fields.PROCESS_ID = "129" Or dao_main.fields.PROCESS_ID = "131" Or dao_main.fields.PROCESS_ID = "133" Then
                cls_xml.CHK_SELL_TYPE = "1"
            ElseIf dao_main.fields.PROCESS_ID = "128" Or dao_main.fields.PROCESS_ID = "124" Or dao_main.fields.PROCESS_ID = "126" Or dao_main.fields.PROCESS_ID = "130" Or dao_main.fields.PROCESS_ID = "132" Or dao_main.fields.PROCESS_ID = "134" Or dao_main.fields.PROCESS_ID = "135" Or dao_main.fields.PROCESS_ID = "136" Then
                cls_xml.CHK_SELL_TYPE = "2"
            End If
        Catch ex As Exception

        End Try
        Try
            'If dao.fields.BSN_NATIONALITY_CD = 1 Then
            'cls_xml.dalcns.NATION = "ไทย"
            'End If
        Catch ex As Exception

        End Try

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
    End Sub
    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub


#Region "GRIDVIEW"


    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
        'load_GV_lcnno()
    End Sub
#End Region

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
                dao.GetDataby_IDA(IDA)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try


                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_EDIT_LCN_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao.fields.PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        'If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        '    Dim item As GridDataItem
        '    item = e.Item
        '    Dim IDA As String = item("IDA").Text
        '    Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
        '    Dim dao As New DAO_DRUG.ClsDBdalcn
        '    dao.GetDataby_IDA(IDA)
        '    btn_edit.Style.Add("display", "none")
        '    Try
        '        If dao.fields.STATUS_ID = 6 Then
        '            btn_edit.Style.Add("display", "block")
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
        '    btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
        'End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'SP_STAFF_DALCN_BY_PVNCD
        'If _pvncd = 10 Then
        dt = bao.SP_DALCN_EDIT_REQUEST_BY_FK_IDA(Request.QueryString("lcn_ida"))
        'Else
        '    dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
        'End If
        'Dim IDGroup As Integer = 0
        'Try
        '    IDGroup = _CLS.GROUPS
        'Catch ex As Exception

        'End Try
        ''If IDGroup = 21020 Then
        RadGrid1.DataSource = dt

    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF(_process)
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../EDIT_LCN/FRM_EDIT_LCN_UPLOAD.aspx?IDA=" & Request.QueryString("lcn_ida") & "&process=" & _process & "&lcn_ida=" & Request.QueryString("lcn_ida") & "');", True)
    End Sub
End Class