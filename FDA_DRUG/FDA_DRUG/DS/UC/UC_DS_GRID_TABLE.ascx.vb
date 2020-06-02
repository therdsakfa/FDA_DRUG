Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI

Public Class UC_DS_GRID_TABLE
    Inherits System.Web.UI.UserControl
    Private _process As String
    Private _lct_ida As String = ""
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lcn_ida As String

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

    Sub runparameter()
        Try
            _process = Request("process").ToString()
        Catch ex As Exception

        End Try
        Try
            _lcn_ida = Request("lcn_ida").ToString()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RunSession()
        runparameter()
        _CLS.LCNNO = _lcn_ida

        set_lbl_header()
        If _process = "1026" Then
            If Not IsPostBack Then
                hide2.Attributes.Add("style", "display:none")
                GV_lcnno.Visible = False
            End If
        Else
            If Not IsPostBack Then
                nym1.Visible = False
                hide.Visible = False
                GV_lcnno_DataBinding()
                hidetop.Visible = False
                hide.Visible = False
                hide2.Visible = True
                tebaen(_lcn_ida)
                load_HL()
            End If
        End If
    End Sub

    Private Sub load_HL()
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_process)
        'If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then
        '    hl_pay.NavigateUrl = "https://platba.fda.moph.go.th/FDA_FEE_DEMO/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
        '    If Request.QueryString("staff") <> "" Then
        '        hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        '    End If
        'Else
        hl_pay.NavigateUrl = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
            If Request.QueryString("staff") <> "" Then
                hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
            End If
        'End If
    End Sub

    Sub set_lbl_header()
        lbl_name_2.Text = "คำขออนุญาตนำหรือสั่งยาเข้ามาในราชอาณาจักรเพื่อ"
        If _process = "1027" Then
            lbl_name.Text = "การวิเคราะห์ (นยม2)"
        ElseIf _process = "1028" Then
            lbl_name.Text = "การจัดนิทรรศการ (นยม3)"
            bt_proof.Text = "ส่งหนังสือแสดงการนำหรือส่งกลับคืนให้กระทรวงฯ"
        ElseIf _process = "1029" Then
            lbl_name.Text = "บริจาคเพื่อการกุศล (นยม4)"
            bt_proof.Text = "ส่งหลักฐานการรับบริจาคยา"
        ElseIf _process = "1026" Then
            lbl_name.Text = "การวิจัย (นยม1)"
        ElseIf _process = "1030" Then
            lbl_name.Text = "การสำรองยาต้านไวรัสในกรณีเกิดการระบาดของไข้หวัดใหญ่ (นยม5)"
        End If

    End Sub

    Private Sub GV_lcnno_DataBinding()

        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt = bao.SP_GET_TR_UPLOAD_BY_PROCESS_ID(_process, _CLS.CITIZEN_ID_AUTHORIZE) 'ใบนยม
        GV_lcnno.DataSource = dt                     'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                       'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub

    Private Sub nym1_DataBinding()

        Dim chk_tr As Integer = 0
        Dim chk_pj As Integer = 0

        If TextBox1.Text <> "" Then
            chk_tr = 1
        End If
        If TextBox2.Text <> "" Then
            chk_pj = 1
        End If

        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt = bao.SP_DRUG_PROJECT_SUMMARY(_CLS.CITIZEN_ID_AUTHORIZE, TextBox1.Text, TextBox2.Text, chk_tr, chk_pj) 'ใบนยม
        PJSUM.DataSource = dt
    End Sub

    Private Sub PJSUM_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles PJSUM.NeedDataSource
        Dim chk_tr As Integer = 0
        Dim chk_pj As Integer = 0

        If TextBox1.Text <> "" Then
            chk_tr = 1
        End If
        If TextBox2.Text <> "" Then
            chk_pj = 1
        End If

        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt = bao.SP_DRUG_PROJECT_SUMMARY(_CLS.CITIZEN_ID_AUTHORIZE, TextBox1.Text, TextBox2.Text, chk_tr, chk_pj)
        PJSUM.DataSource = dt
    End Sub

    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        GV_lcnno_DataBinding()
    End Sub

    ''' <summary>
    ''' ดาวน์โหลดตำขอ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click

        If _process = "1027" Then
            Bind_PDF() 'นยม2 Response.Redirect("FRM_NORYORMOR_2.aspx")
        ElseIf _process = "1028" Then
            Bind_PDF() 'นยม3 Response.Redirect("FRM_NORYORMOR_3.aspx")
        ElseIf _process = "1029" Then
            Bind_PDF() 'นยม4  Response.Redirect("FRM_NORYORMOR_4.aspx")
        ElseIf _process = "1026" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "download();", True)
        ElseIf _process = "1030" Then
            Bind_PDF() 'นยม5'
        End If
    End Sub

    Private Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Response.Redirect("~\DS\POPUP_NYM_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "")

        End If
    End Sub

    Private Sub nym1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles nym1.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = nym1.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Response.Redirect("~\DS\POPUP_NYM_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process)

        End If
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Response.Redirect("~\DS\POPUP_DS_UPLOAD_NORYORMOR.aspx?process=" & _process & "")
    End Sub

    Protected Sub bt_proof_Click(sender As Object, e As EventArgs) Handles bt_proof.Click
        Response.Redirect("~\DRUG_IMPORT\UC_NYM_PROOF_UPLOAD.aspx?process=" & _process & "")
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
        _CLS.PDFNAME2 = dao_down.fields.ID

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)


        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)
        If _process = "1030" Then
            convert_Database_To_XML(file_xml)
        ElseIf _process = "1026" Then
            convert_Database_To_XML2(file_xml)
        Else
            convert_Database_To_XML1(file_xml)
        End If

        convert_XML_To_PDF(file_PDF, file_xml, file_template)

        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub

    Private Sub convert_Database_To_XML(ByVal path As String)
        Dim cls_xml As New CLASS_NORYORMOR5
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub
    Private Sub convert_Database_To_XML1(ByVal path As String)
        Dim cls_xml As New CLASS_NYM24
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)
        Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_addr.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(_lcn_ida)
        cls_xml.drsamp.LCNNO_SHOWS = dao.fields.LCNNO_DISPLAY
        cls_xml.drsamp.IN_NAME_DETAIL3 = dao_addr.fields.thanameplace
        cls_xml.drsamp.addr = dao_addr.fields.thaaddr
        cls_xml.drsamp.moo = dao_addr.fields.thamu
        cls_xml.drsamp.soi = dao_addr.fields.thasoi
        cls_xml.drsamp.road = dao_addr.fields.tharoad
        cls_xml.drsamp.thmblnm = dao_addr.fields.thathmblnm
        cls_xml.drsamp.amphrnm = dao_addr.fields.thaamphrnm
        cls_xml.drsamp.chngwtnm = dao_addr.fields.thachngwtnm
        cls_xml.drsamp.tel = dao_addr.fields.tel
        cls_xml.drsamp.PREFIX = dao_bsn.fields.BSN_PREFIXENGCD
        cls_xml.drsamp.NAME = dao_bsn.fields.BSN_THAIFULLNAME

        Try
            Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_regis.GetDataby_IDA(ddl_tabaen.SelectedValue)
            cls_xml.drsamp.DRUG_THAINAME = dao_regis.fields.DRUG_NAME_THAI
            cls_xml.drsamp.DRUG_ENGNAME = dao_regis.fields.DRUG_NAME_OTHER

        Catch ex As Exception
        End Try
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(ddl_tabaen.SelectedValue)
            cls_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(ddl_tabaen.SelectedValue)
            '  cls_xml.contain_detail = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(ddl_tabaen.SelectedValue)
        Catch ex As Exception

        End Try
        If Right(dao.fields.lcntpcd, 1) = "บ" Then
            cls_xml.drsamp.CHK_PERMISSION_REQUEST = Right(dao.fields.lcntpcd, 2)
        Else
            cls_xml.drsamp.CHK_PERMISSION_REQUEST = Right(dao.fields.lcntpcd, 1)
        End If


        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub
    Private Sub convert_Database_To_XML2(ByVal path As String)
        Dim cls_xml As New CLASS_PROJECT_NYM1
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

    Private Sub PJSUM_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles PJSUM.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim TR_ID As String = ""
            Try
                TR_ID = item("TR_ID").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA(IDA)

                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_RESEARCH_SUM.aspx?IDA=" & IDA & "&lcn_ida=" & _CLS.LCNNO & "&command=" & e.CommandName & "');", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_RESEARCH_SUM_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "');", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_RESEARCH_SUM_CONFIRM.aspx?IDA=" & IDA & "&FK_IDA=" & IDA & "&TR_ID=" & dao.fields.TR_ID & "&ProcessID=" & _process & "');", True)
            ElseIf e.CommandName = "chnge" Then
                '    dao.GetDataby_IDA(IDA)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_RESEARCH_ROLE.aspx?IDA=" & IDA & "&FK_IDA=" & IDA & "&TR_ID=" & dao.fields.TR_ID & "&ProcessID=" & _process & "');", True)
            ElseIf e.CommandName = "add" Then
                Response.Redirect("~\DRUG_CUSTOMER_NORYORMOR1\FRM_NORYORMOR1_MAIN.aspx?process=" & _process & "&proj_ida=" & IDA & "&lct_ida=" & _lct_ida & "&lcn_ida=" & _CLS.LCNNO & "&TR_ID=" & TR_ID)
            End If

        End If
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        nym1_DataBinding()
        PJSUM.DataBind()
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        Response.Write("ALERT")
    End Sub

    Protected Sub GV_lcnno_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Sub tebaen(ByVal lcn_ida As Integer)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_FK_IDA2(lcn_ida)
        Dim item As New ListItem("---เลือกทะเบียน---", "0")
        Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As DataTable = dao.datas
        ddl_tabaen.DataSource = dao.Details
        ddl_tabaen.DataTextField = "RCVNO_DISPLAY"
        ddl_tabaen.DataValueField = "IDA"
        ddl_tabaen.DataBind()

        ddl_tabaen.Items.Insert(0, item)
    End Sub

    Protected Sub ddl_tabaen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_tabaen.SelectedIndexChanged

    End Sub

    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Bind_PDF() 'นยม1'
    'End Sub
End Class