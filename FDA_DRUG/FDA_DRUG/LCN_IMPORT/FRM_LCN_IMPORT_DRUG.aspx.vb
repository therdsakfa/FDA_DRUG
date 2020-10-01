Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class FRM_LCN_IMPORT_DRUG
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process

    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2
            load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
            load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
        End If
    End Sub
    Private Sub load_lbl_name()
        If _process = "101" Then        'Process จะมาหน้า ขย1
            lbl_name.Text = " (ขย1)"
        ElseIf _process = "102" Then    'Process จะมาหน้า ขย2
            lbl_name.Text = " (ขย2)"
        ElseIf _process = "103" Then    'Process จะมาหน้า ขย3
            lbl_name.Text = " (ขย3)"
        ElseIf _process = "104" Then    'Process จะมาหน้า ขย4
            lbl_name.Text = " (ขย4)"
        ElseIf _process = "105" Then    'Process จะมาหน้า นย1
            lbl_name.Text = " (นย1)"
        ElseIf _process = "106" Then    'Process จะมาหน้า ผย1
            lbl_name.Text = " (ผย1)"
        ElseIf _process = "107" Then    'Process จะมาหน้า ขยบ
            lbl_name.Text = " (ขยบ)"
        ElseIf _process = "108" Then    'Process จะมาหน้า นยบ
            lbl_name.Text = " (นยบ)"
        ElseIf _process = "109" Then    'Process จะมาหน้า ผยบ
            lbl_name.Text = " (ผยบ)"
        End If
    End Sub

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU       'ประกาศชื่อตัวแปร DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_Process(_process)             'ดึง dao.GetDataby_Process เพื่อมาโชว์ที่ Gridview ที่เป็นค่า String
        'bao.SP_LCN_DRUG_TYPE_MENU(_CLS.LCNSID, dao.fields.NAME)
        bao.SP_DALCN_By_lcntpcd(_CLS.LCNSID_CUSTOMER, dao.fields.NAME) 'เรียกใช้ SP  bao.SP_DALCN_By_lcntpcd
        GV_lcnno.DataSource = bao.dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub


#Region "GRIDVIEW"

    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim btn_lcn As Button = DirectCast(e.Row.FindControl("btn_lcn"), Button)
            Dim id As String = GV_lcnno.DataKeys.Item(e.Row.RowIndex).Value.ToString()

            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(id)

            'ไม่ให้แสดงคำว่า เลือกข้อมูล ถ้าสถานะไม่ใช่อนุมัติ
            If dao.fields.STATUS_ID <> 8 Then
                btn_lcn.Visible = False
            End If

        End If

    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_IMPORT_CONFIRM_DRUG.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

        ElseIf e.CommandName = "pdf" Then

        ElseIf e.CommandName = "lcn" Then
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            _CLS.LCNNO = dao.fields.lcnno.ToString()
            _CLS.LCNSID_CUSTOMER = dao.fields.lcnsid.ToString()
            _CLS.PVCODE = dao.fields.pvncd.ToString()
            _CLS.IDA = str_ID
            Session("CLS") = _CLS

            ' Response.Redirect("../MAIN/FRM_NODE.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())
            Response.Redirect("../MAIN/FRM_NEWS.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&IDA=" & str_ID & "&fk_ida=" & str_ID)

        End If
    End Sub


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub
#End Region

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()                             'เรียกฟังก์ชั่น  load_GV_lcnno   มาใช้งาน
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        If String.IsNullOrEmpty(_process) = False Then  'ถ้าให้ค่า _process เป็นค่าว่าง จะไม่เป็นความจริง
            Bind_PDF()                                  'เรียกฟังก์ชั่น  Bind_PDF มาใช้งาน
        Else
            alert("กรุณาเลือกประเภทใบอนุญาตก่อนทำการดาวน์โหลด")  'ถ้าค่าว่างจะ ERROR
        End If

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
        bao_app.RunAppSettings()                                                    'บอกที่อยู่ของไฟล์

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process                                       ' ชื่อ Process
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID                               ' รับค่าจากเทเบิ้ล บัตรประชาชน
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE           ' รับ ชื่อประกอบการ
        dao_down.fields.STATUS = STATUS                                             ' รับเก็บค่า STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE                               'เวลา
        dao_down.insert()                                                           ' insert ค่าข้างบน
        down_ID = dao_down.fields.ID


        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("LCN_IMPORT", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("LCN_IMPORT", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("LCN_IMPORT", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)                   'จาวา .Gif
    End Sub
    ''' <summary>
    ''' แปลงค่าจากDatabase เป็น XML
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub convert_Database_To_XML(ByVal path As String)

        Dim cls As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, "1", _CLS.PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DALCN                                                                        ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                               'cls_xml ให้เท่ากับ Class ของ cls.gen_xml

        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub


    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_IMPORT_UPLOAD_ATTACH.aspx?type_id=" & _process & "&process=" & _process & "');", True)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub
    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
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
End Class