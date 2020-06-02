Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class FRM_DI_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Sub runQuery()
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _process = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        load_lbl_lcnno()

        RunSession()
        'load_lcnno()
        'UC_Information.Shows(_lcn_ida)
        UC_Information.Shows(_lcn_ida)

        If Not IsPostBack Then
            load_GV_data()

            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าระบบ cert GMP", _process)

            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าระบบ cert GMP", _process)
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าระบบ cert GMP", _process)

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าระบบ cert GMP", _process)

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
        End If
        'Shows()
    End Sub
    ''' <summary>
    ''' เพิ่มชื่อสารในxml
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GEN_CHEMICAL()
        Dim cls_CER As New CLASS_GEN_XML.Center
        cls_CER.ADD_CHEMICAL()
    End Sub



#Region "ShowLabel"


#End Region

    Private Sub load_lbl_lcnno()
        If _process = "31" Then
            lbl_lcnno_Name.Text = " (Certificate of GMP)"
        ElseIf _process = "32" Then
            lbl_lcnno_Name.Text = " (ISO)"
        ElseIf _process = "33" Then
            lbl_lcnno_Name.Text = " (HACCP)"
        ElseIf _process = "34" Then
            lbl_lcnno_Name.Text = " (หลักฐานการขายไปยังประเทศที่มีระบบควบคุมคุณภาพการผลิตที่ อย ยอมรับ)"
        ElseIf _process = "35" Then
            lbl_lcnno_Name.Text = " (เอกสารผลการวิเคราะห์วัตถุดิบโดยห้องปฏิบัติที่ อย ให้การยอมรับ)"
        ElseIf _process = "36" Then
            lbl_lcnno_Name.Text = " (เอกสารอื่นๆ ที่ อย เห็นชอบ)"
        End If
    End Sub

    Sub load_GV_data()                                                  ' Gridview นำมาโชว์
        'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_data   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF()
    End Sub

    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer


        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)

        convert_Database_To_XML(file_xml)
        convert_XML_To_PDF(file_PDF, file_xml, file_template)
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", down_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอ Cert", _process)
        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML(ByVal path As String)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        Dim dao_dalcntype As New DAO_DRUG.ClsDBdalcntype
        dao_dalcntype.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)
        Dim cls_CER As New CLASS_GEN_XML.Cer(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, 1, dao_lcn.fields.IDA)
        Dim cls_xml As New CLASS_CER
        cls_xml = cls_CER.gen_xml_CER()
        cls_xml.CERs.CER_TYPE = _process

        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        cls_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
        'ชื่อบริษัท
        cls_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID_CUSTOMER)

        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_lct_ida) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, _CLS.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, _CLS.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(_lct_ida) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER


        'ชื่อประเภทยา
        cls_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_dactg()

        'ประเทศ
        cls_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt()

        'เลขที่ใบอนุญาต
        cls_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_lcn_ida)

        ' bao_master.SP_MASTER_fafdtype.TableName = "ประกาศใบอนุญาต"
        cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_lcn_ida)

        'ประเภท Cer
        cls_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_lgt_impcertp()

        'สาร
        'cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()
        cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT(_CLS.LCNSID_CUSTOMER) 'สาร แปลงเลข ID

        cls_xml.DT_MASTER.DT15 = bao_master.SP_PICS_NATIONAL()

        'cls_xml.URL_CHEMICAL_SEARCH = "http://10.111.28.101/FDA_DRUG/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + _lcn_ida + "&lcnsid=" + _CLS.LCNSID_CUSTOMER.ToString()

        Dim host As String = HttpContext.Current.Request.Url.Host
        cls_xml.URL_CHEMICAL_SEARCH = host & "/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + _lcn_ida + "&lcnsid=" + _CLS.LCNSID_CUSTOMER.ToString()

        cls_xml.LCNNO_SHOW = dao_lcn.fields.LCNNO_DISPLAY
        cls_xml.TYPE_IMPORT = dao_dalcntype.fields.lcntpnm

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

    'Private Sub GV_data_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_data.PageIndexChanging
    '    GV_data.PageIndex = e.NewPageIndex
    '    load_GV_data()
    'End Sub

    'Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.TB_CER

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA2(str_ID)
    '        Dim tr_id As Integer = 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try

    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DI_CONFIRM.aspx?IDA=" & str_ID & "&FK_IDA=" & str_ID & "&TR_ID=" & tr_id & "&ProcessID=" & _process & "');", True)

    '    End If
    'End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        'load_GV_data()
        RadGrid1.Rebind()
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_CER
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA2(IDA)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DI_CONFIRM.aspx?IDA=" & IDA & "&FK_IDA=" & IDA & "&TR_ID=" & tr_id & "&ProcessID=" & _process & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand                              'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        'CER
        If Request.QueryString("identify") <> "" Then
            Try
                bao.SP_CUSTOMER_CER_BY_FK_IDA_and_CER_TYPE_and_iden(_lcn_ida, _process, Request.QueryString("identify"))
            Catch ex As Exception

            End Try
        Else
            Try
                bao.SP_CUSTOMER_CER_BY_FK_IDA_and_CER_TYPE(_lcn_ida, _process)  'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable
            Catch ex As Exception

            End Try
        End If
        Dim dt As New DataTable
        Try
            dt = bao.dt
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub

    Public Sub set_color_rg()
        If RadGrid1.Items.Count > 0 Then
            For Each item As GridDataItem In RadGrid1.Items
                Try
                    If item("EXP_DATE_EXTEND").Text.Contains("&nbsp;") = False Then
                        Dim date_exp As Date = CDate(item("EXP_DATE_EXTEND").Text)
                        Dim date_now As Date = CDate(Date.Now)
                        If date_now > date_exp Then
                            item.ForeColor = Drawing.Color.Crimson
                            item("STATUS_NAME").Text = "Cert หมดอายุ"
                        End If
                    End If

                Catch ex As Exception

                End Try

            Next
        End If
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        set_color_rg()
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs)

    End Sub
End Class