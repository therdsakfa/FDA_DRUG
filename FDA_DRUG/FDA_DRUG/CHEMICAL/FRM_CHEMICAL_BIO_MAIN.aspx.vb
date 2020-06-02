Imports System.IO
Imports System.Xml.Serialization
Public Class FRM_CHEMICAL_BIO_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Private _mt As String = ""
    Private _st As String
    Private _b As String = ""
    Sub runQuery()
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _mt = Request.QueryString("mt")
        _st = Request.QueryString("st")
        _process = Request.QueryString("process")
        _b = Request.QueryString("b")
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
        RunSession()
        runQuery()
        If Not IsPostBack Then
            load_GV_data()
            'UC_Information1.Shows(_lcn_ida)
        End If

        set_page_name()
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF()
    End Sub
    Sub load_GV_data()                                                          ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand                                      'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        ' GV_data.DataSource = bao.SP_CHEMICAL_REQUEST_CUSTOMER(_lcn_ida, _mt, _st)   'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable
        'GV_data.DataSource = bao.SP_CHEMICAL_REQUEST_CUSTOMER_V2(_lcn_ida, _mt)
        GV_data.DataSource = bao.SP_CHEMICAL_REQUEST_CUSTOMERV_BIO(_CLS.CITIZEN_ID_AUTHORIZE, _mt, _b, _st)
        GV_data.DataBind()                                                      'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_data   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Public Sub set_page_name()
        Dim dao As New DAO_DRUG.TB_MAS_MENU_CHEMI_LABEL
        If Request.QueryString("process") <> "" Then
            If Request.QueryString("process") = "20" Then
                dao.GetDataby_ID_AND_AORI(Request.QueryString("st"), Request.QueryString("t"))
                lbl_name_page.Text = dao.fields.LABEL_TEXT
            ElseIf Request.QueryString("process") = "21" Then
                dao.GetData_Trade_by_ID(Request.QueryString("g"))
                lbl_name_page.Text = dao.fields.LABEL_TEXT
            ElseIf Request.QueryString("process") = "22" Then
                dao.GetData_Bio_by_ID(Request.QueryString("b"))
                lbl_name_page.Text = dao.fields.LABEL_TEXT
            End If
        End If

        'Dim dao As New DAO_DRUG.ClsDBMAS_MENU
        'lbl_name_page.Text = "เพิ่มสาร "
        'Try
        '    dao.GetDataby_Process2(Request.QueryString("process"))
        '    lbl_name_page.Text &= dao.fields.NAME
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings 'บอกที่อยู่ของไฟล์

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim down_ID As Integer



        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _process                                   ' ชื่อ Proces
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID                           ' รับค่าจากเทเบิ้ล บัตรประชาชน
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE       ' รับ ชื่อประกอบการ
        dao_down.fields.STATUS = STATUS                                         ' รับเก็บค่า STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE                           'เวลา
        dao_down.insert()                                                       ' insert ค่าข้างบน
        down_ID = dao_down.fields.ID



        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)

        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML(file_xml)                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)   'จาวา .Gif
    End Sub
    Private Sub convert_Database_To_XML(ByVal path As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Integer.Parse(_lcn_ida))

        Dim cls_gen As New CLASS_GEN_XML.CHEMICAL_REQUEST()
        Dim cls_xml As New CLASS_CHEMICAL_REQUEST
        cls_xml = cls_gen.gen_xml()

        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)         'เรียกใช้ SP_MAINPERSON_CTZNO
        cls_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_CLS.LCNSID_CUSTOMER)  'เรียกใช้ SP_MAINCOMPANY_LCNSID
        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER

        '______________________________________


        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
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
        If e.CommandName = "del" Then
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(str_ID)
            dao.delete()
            Response.Write("<script type='text/javascript'>alert('ลบข้อมูลเรียบร้อย');</script> ")
            load_GV_data()
        ElseIf e.CommandName = "accept" Then
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(str_ID)
            dao.fields.STATUS_ID = 2
            dao.update()
            'Response.Write("<script type='text/javascript'>alert('ยืนยันข้อมูลเรียบร้อย');</script> ")
            load_GV_data()
        End If
    End Sub

    Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../CHEMICAL/FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE.aspx?IDA=" & str_ID & "'); return false;", True)
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
            'Dim btn_del As Button = DirectCast(e.Row.FindControl("btn_del"), Button)
            Dim btn_accept As Button = DirectCast(e.Row.FindControl("btn_accept"), Button)
            Dim ida As String = GV_data.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            Dim url As String = ""
            url = "../CHEMICAL/POPUP_BIO_INSERT_AND_UPDATE.aspx?ida=" & ida & "&st=" & Request.QueryString("st") & "&b=" & Request.QueryString("b") & _
                "&mt=" & Request.QueryString("mt") & "&process=" & Request.QueryString("process")
            btn_edit.Attributes.Add("onclick", "Popups2('" & url & "'); return false;")

            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(ida)

            'If dao.fields.SUB_TYPE = 1 Then
            '    btn_edit.Style.Add("display", "none")
            'End If
            Try
                If dao.fields.STATUS_ID <> 1 Then
                    btn_accept.Style.Add("display", "none")
                End If
                'If dao.fields.REGIS_STATUS = "R" AndAlso dao.fields.REGIS_STATUS = "NR" Then
                '    btn_edit.Style.Add("display", "none")
                '    btn_del.Style.Add("display", "none")
                'End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        GV_data.DataBind()
    End Sub
End Class