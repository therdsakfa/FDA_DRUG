Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class FRM_DH_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _fk_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Sub runQuery()
        _lct_ida = Request.QueryString("lct_ida")
        _fk_ida = Request.QueryString("fk_ida")
        _process = Request.QueryString("process")
        _lcn_ida = Request.QueryString("lcn_ida")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            runQuery()

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_lbl_Header_txt()
        load_lcnno()
        load_HL()
        'set_lbl_header(lbl_Header_txt, _process)
        If Not IsPostBack Then
            load_GV_data()
            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบเภสัชเคมีภัณฑ์", _process)
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบเภสัชเคมีภัณฑ์", _process)
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบเภสัชเคมีภัณฑ์", _process)

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้ระบบเภสัชเคมีภัณฑ์", _process)

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
        End If
        ' load_lbl_Header_txt()
    End Sub
    Sub load_lcnno()
        lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & _lct_ida
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify")
        End If

        hl_pay.NavigateUrl = urls
        'If Request.QueryString("staff") <> "" Then
        '    hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        'End If
    End Sub
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Dim dao As New DAO_DRUG.TB_CER
        If (_process = 14) Or (_process = 15) Then
            dao.GetDataby_FK_IDA(_lcn_ida)
            If (dao.fields.IDA) = 0 Then
                alert("กรุณาลงทะเบียน GMP สถานที่ผลิตก่อนดาวน์โหลดคำขอ")
            Else
                Bind_PDF()

            End If
        Else
            Bind_PDF()
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    Private Sub load_lbl_Header_txt()
        If _process = "14" Then
            lbl_Header_txt.Text = " (เป็นสารออกฤทธิ์ตามทะเบียนตำรับยา)"
        ElseIf _process = "15" Then
            lbl_Header_txt.Text = " (เป็นสารออกฤทธิ์ที่ไม่มีในทะเบียนตำรับยา)"
        ElseIf _process = "16" Then
            lbl_Header_txt.Text = " (ไม่เป็นสารออกฤทธิ์ตามทะเบียนตำรับยา)"
        ElseIf _process = "17" Then
            lbl_Header_txt.Text = " (ไม่เป็นสารออกฤทธิ์ที่ไม่มีในทะเบียนตำรับยา)"
        ElseIf _process = "18" Then
            lbl_Header_txt.Text = " (วัตถุดิบสมุนไพรสำหรับยาแผนโบราณ)"
        End If
    End Sub
    Sub load_GV_data()                      ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand  'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        'CER
        bao.SP_DH15RQT_BY_IDA(_lcn_ida, _process)
        GV_data.DataSource = bao.dt         'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable
        GV_data.DataBind()                  'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_data   เพื่อให้ข้อมูลวิ่ง
    End Sub

    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process                                       ' ชื่อ Proces
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID                               ' รับค่าจากเทเบิ้ล บัตรประชาชน
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE           ' รับ ชื่อประกอบการ
        dao_down.fields.STATUS = STATUS                                             ' รับเก็บค่า STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE                               'เวลา
        dao_down.insert()                                                           ' insert ค่าข้างบน
        down_ID = dao_down.fields.ID

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml)                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                       ' XML PDF รวมกัน


        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", down_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ดาวน์โหลดคำขอเภสัชเคมีภัณฑ์", _process)

        _CLS.FILENAME_PDF = file_PDF                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)  'จาวา .Gif
    End Sub
    Private Sub convert_Database_To_XML(ByVal path As String)

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(Integer.Parse(_lcn_ida))
        Dim dao_cer As New DAO_DRUG.TB_CER
        If _process <> "16" And _process <> "17" Then
            dao_cer.GetDataby_FK_IDA(_lcn_ida)
        End If



        Dim cls_gen As New CLASS_GEN_XML.DH(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, dao_lcn.fields.lcnno, "1", dao_lcn.fields.pvncd, _lcn_ida)
        Dim cls_xml As New CLASS_DH
        cls_xml = cls_gen.gen_xml()


        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, _CLS.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID"
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, _CLS.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDAV2(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER
        cls_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt() 'ประเทศ
        If _process <> "16" And _process <> "17" Then
            cls_xml.DT_MASTER.DT18 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(dao_cer.fields.FK_IDA) 'สารที่เลือก
            cls_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao_cer.fields.FK_IDA) 'CER
        End If


        'สาร
        If _process = 16 Or _process = 17 Then
            cls_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL_CONVERT(_CLS.LCNSID_CUSTOMER)  'สาร แปลงเลข ID
            Dim host As String = HttpContext.Current.Request.Url.Host
            'cls_xml.URL_CHEMICAL_SEARCH = "http://10.111.28.101/FDA_DRUG/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + _lcn_ida + "&lcnsid=" + _CLS.LCNSID_CUSTOMER.ToString()
            cls_xml.URL_CHEMICAL_SEARCH = host & "/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx?lcn_ida=" + _lcn_ida + "&lcnsid=" + _CLS.LCNSID_CUSTOMER.ToString()

        End If

        Try
            cls_xml.dh15rqts.LCNNO_DISPLAY = dao_lcn.fields.LCNNO_DISPLAY
            cls_xml.dh15rqts.lcnno = dao_lcn.fields.lcnno
            If dao_lcn.fields.lcntpcd = "ผย1" Then
                cls_xml.dh15rqts.CHK_TYPE_LCN = 1
            ElseIf dao_lcn.fields.lcntpcd = "นย1" Then
                cls_xml.dh15rqts.CHK_TYPE_LCN = 2
            End If

            If _process = 14 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "00"
            ElseIf _process = 15 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "01"
            ElseIf _process = 16 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "00"
            ElseIf _process = 17 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "01"
            ElseIf _process = 18 Then
                cls_xml.dh15rqts.QUOTA_TYPE = "00"
            End If
        Catch ex As Exception

        End Try

        Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                     'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings 'ทำการดาวห์โหลดลงเครื่อง
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
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_data()
    End Sub


    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        Dim dao_da As New DAO_DRUG.ClsDBdalcn

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_COMFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
        ElseIf e.CommandName = "cancel" Then
            dao.GetDataby_IDA(str_ID)
            dao.fields.IS_CANCEL = True
            dao.fields.CANCEL_DATE = Date.Now
            dao.update()

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');", True)
            load_GV_data()
        ElseIf e.CommandName = "_print" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_PRINT.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

        ElseIf e.CommandName = "_pay" Then
            dao.GetDataby_IDA(str_ID)
            Dim ida_loca As Integer = 0
            Try
                dao_da.GetDataby_IDA(dao.fields.FK_IDA)
                ida_loca = dao_da.fields.FK_IDA
            Catch ex As Exception

            End Try
            Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & ida_loca

            'btn_pay.PostBackUrl = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
            If Request.QueryString("staff") <> "" Then
                urls &= "&staff=1&identify=" & Request.QueryString("identify")
            End If
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
        End If
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click

    End Sub

    Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_cancel As Button = DirectCast(e.Row.FindControl("btn_cancel"), Button)
            Dim btn_print As Button = DirectCast(e.Row.FindControl("btn_print"), Button)
            Dim btn_pay As LinkButton = DirectCast(e.Row.FindControl("btn_pay"), LinkButton)
            Dim id As String = GV_data.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            btn_cancel.Style.Add("display", "none")
            btn_print.Style.Add("display", "none")
            btn_pay.Style.Add("display", "none")
            Dim dao As New DAO_DRUG.ClsDBdh15rqt
            dao.GetDataby_IDA(id)

            'ไม่ให้แสดงคำว่า เลือกข้อมูล ถ้าสถานะไม่ใช่อนุมัติ
            If dao.fields.STATUS_ID = 8 Then
                btn_cancel.Style.Add("display", "block")
                btn_print.Style.Add("display", "block")
            End If
            Try
                If dao.fields.STATUS_ID = 10 Then
                    Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                    dao_tr.GetDataby_IDA(dao.fields.TR_ID)
                    If dao_tr.fields.PROCESS_ID = 14 Or dao_tr.fields.PROCESS_ID = 15 Then
                        btn_pay.Style.Add("display", "block")


                    End If
                End If
            Catch ex As Exception

            End Try

            Try
                If dao.fields.IS_CANCEL = True Then
                    btn_cancel.Style.Add("display", "none")
                    btn_print.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_data.PageIndexChanging
        GV_data.PageIndex = e.NewPageIndex
        load_GV_data()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim str_ID As String = item("IDA").Text
            Dim dao As New DAO_DRUG.ClsDBdh15rqt
            Dim dao_da As New DAO_DRUG.ClsDBdalcn
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA(str_ID)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_COMFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
            ElseIf e.CommandName = "cancel" Then
                dao.GetDataby_IDA(str_ID)
                dao.fields.IS_CANCEL = True
                dao.fields.CANCEL_DATE = Date.Now
                dao.fields.REMARK = "ยกเลิกโดยผู้ประกอบการ"
                dao.update()

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อย');", True)
                load_GV_data()
            ElseIf e.CommandName = "_print" Then
                dao.GetDataby_IDA(str_ID)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DH_PRINT.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

            ElseIf e.CommandName = "_pay" Then
                dao.GetDataby_IDA(str_ID)
                Dim ida_loca As Integer = 0
                Try
                    dao_da.GetDataby_IDA(dao.fields.FK_IDA)
                    ida_loca = dao_da.fields.FK_IDA
                Catch ex As Exception

                End Try
                Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & ida_loca

                'btn_pay.PostBackUrl = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
                If Request.QueryString("staff") <> "" Then
                    urls &= "&staff=1&identify=" & Request.QueryString("identify")
                End If
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand  'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        'CER
        bao.SP_DH15RQT_BY_IDA(_lcn_ida, _process)

        RadGrid1.DataSource = bao.dt
    End Sub
End Class