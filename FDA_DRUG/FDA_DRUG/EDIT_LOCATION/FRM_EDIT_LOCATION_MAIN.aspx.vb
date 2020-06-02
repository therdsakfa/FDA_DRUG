Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_EDIT_LOCATION_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    'Private _fk_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Sub runQuery()
        _lct_ida = Request.QueryString("lct_ida")
        '_fk_ida = Request.QueryString("fk_ida")
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
        runQuery()
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF()
    End Sub
  Private Sub Bind_PDF()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
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
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        ' convert_Database_To_XML(file_xml)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub

    Private Sub convert_Database_To_XML(ByVal path As String)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(Integer.Parse(_lcn_ida))
        Dim dao_cer As New DAO_DRUG.TB_CER
        dao_cer.GetDataby_FK_IDA(_lcn_ida)

        Dim cls As New CLASS_GEN_XML.DRUG_REGISTRATION(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER, dao_lcn.fields.lcnno, _process, dao_lcn.fields.IDA)
        Dim cls_xml As New CLASS_REGISTRATION

        cls_xml = cls.gen_xml()
        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW
        cls_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        cls_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _CLS.LCNSID_CUSTOMER) 'ข้อมูลที่ตั้งหลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        cls_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _CLS.LCNSID_CUSTOMER) 'ที่เก็บ
        cls_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER

        cls_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao_lcn.fields.IDA) 'CER

        cls_xml.SHOW_LCNNO = dao_lcn.fields.LCNNO_DISPLAY
        cls_xml.DRUG_REGISTRATIONs.LCNNO = dao_lcn.fields.lcnno
        If dao_lcn.fields.lcntpcd = "ผย1" Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 1
        ElseIf dao_lcn.fields.lcntpcd = "นย1" Then
            cls_xml.DRUG_REGISTRATIONs.DALCNTYPE_CD = 2
        End If


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
    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click

    End Sub

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION

        'If e.CommandName = "sel" Then
        '    dao.GetDataby_IDA(str_ID)
        '    Dim tr_id As Integer = 0
        '    Try
        '        tr_id = dao.fields.TR_ID
        '    Catch ex As Exception

        '    End Try

        '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_REGISTRATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

        'ElseIf e.CommandName = "choose" Then
        '    Response.Redirect("../EDIT_LOCATION/FRM_EDIT_LOCATION_MAIN.aspx?IDA=" & str_ID & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "&lct_ida=" & _lct_ida)
        'End If
    End Sub

    Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim ida As String = GV_data.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            btn_Select.Attributes.Add("onclick", "Popups2('../EDIT_LOCATION/POPUP_EDIT_LOCATION_CONFIRM.aspx?IDA=" & ida & "'); return false;")
        End If
    End Sub
    Sub load_GV_lcnno()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_DB.SP_LCN_EDIT_REQUEST_BY_FK_IDA(_lct_ida)
        GV_data.DataSource = dt
        GV_data.DataBind()

    End Sub
End Class