Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_STAFF_LOCATION_CONFIRM
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _Process As Integer
    Private _CLS As New CLS_SESSION

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _Process = Request.QueryString("process")
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        UC_GRID_ATTACH.load_gv(_TR_ID)
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            BindData_PDF()
            Bind_GRID()
            txt_app_date.Text = Date.Now.ToShortDateString()
        End If
    End Sub
    Private Sub Bind_GRID()
        UC_GRID_ATTACH.load_gv(_TR_ID)
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_MAS_STATUS_STAFF()
        Dim int_group_ddl As Integer = 3
        Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        dao_la.GetDataby_IDA(_IDA)

        'If dao_la.fields.STATUS_ID <= 2 Then
        '    int_group_ddl = 1
        'ElseIf dao_la.fields.STATUS_ID > 2 And dao_la.fields.STATUS_ID < 6 Then
        '    int_group_ddl = 2
        'ElseIf dao_la.fields.STATUS_ID >= 6 Then
        '    int_group_ddl = 3
        'End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_status.DataSource = dt
        ddl_status.DataValueField = "STATUS_ID"
        ddl_status.DataTextField = "STATUS_NAME"
        ddl_status.DataBind()
    End Sub
    Private Sub BindData_PDF()

        Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        dao_la.GetDataby_IDA(_IDA)

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao_la.fields.TR_ID)
        '-----------------------------------------------------------

        Dim CITIZEN_ID_AUTHORIZE As String = dao_la.fields.IDENTIFY

        Dim PDF_XML_NCT As New XML_PDF_NCT_LCT
        '--------------------------------------------------------------------
        PDF_XML_NCT.MAIN_IDA = _IDA
        PDF_XML_NCT.XML_CITIZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE
        ' PDF_XML_NCT.XML_TYPE = _type

        '  PDF_XML_NCT.BindData_PDF(_IDA)
        HiddenField1.Value = PDF_XML_NCT.XML_PATH_PDF
        '----------------------------------------------------------------------------

        Dim statusID As Integer = 0
        Dim ProcessID As Integer = 0

        Dim grouptype As String = "00"



        'Dim IDA As Integer = dao_la.fields.IDA
        Dim TR_ID As Integer = dao_la.fields.TR_ID
        Dim LCNSID As String = dao_la.fields.lcnsid
        ' Dim CITIZEN_ID_AUTHORIZE As String = _XML_CITIZEN_ID_AUTHORIZE
        Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID
        Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
        statusID = dao_la.fields.STATUS_ID
        ProcessID = dao_up.fields.PROCESS_ID



        Dim cls_NCONVERTRQT As New Gen_XML.GEN_XML_NCT_LCT_ADDR

        cls_NCONVERTRQT.CITIZEN_ID = dao_la.fields.CITIZEN_ID
        cls_NCONVERTRQT.CITIZEN_AUTHORIZE = CITIZEN_ID_AUTHORIZE
        cls_NCONVERTRQT.IDA = _IDA


        Dim class_xml As New CLS_LOCATION
        class_xml = cls_NCONVERTRQT.gen_xml_nct_lctaddr()
        class_xml.NCT_LCTADDRs = dao_la.fields


        Dim cls_LOCATION_BSN As New DAO_CPN.TB_LOCATION_BSN
        cls_LOCATION_BSN.Getdata_by_fk_id(_IDA)
        class_xml.LOCATION_BSNs = cls_LOCATION_BSN.Details
        '_______________SHOW___________________

        Dim bao_show As New BAO_SHOW
        Try
            class_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(CITIZEN_ID) 'ชื่อผู้ ทำ PDF
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT5 = bao_show.SP_SP_SYSTHMBL() 'ตำบล ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT6 = bao_show.SP_SP_SYSAMPHR() 'อำเภอ ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT7 = bao_show.SP_SP_SYSCHNGWT() 'จังหวัด ไว้ใส่ ดรอปดาว

        class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX() 'คำนำหน้า ไว้ใส่ ดรอปดาว
        class_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID) 'bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, LCNSID) 'สถานที่หลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID) 'ชื่อและข้อมูลผู้ประกอบการ



        class_xml.SHOW_THAI_birthdate = " "

        XML_LOCATIONs = class_xml

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(ProcessID, 0, statusID, grouptype, 0)

        Dim paths As String = _PATH_DEFALUT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DRUG", ProcessID, con_year(Date.Now.Year), TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DRUG", ProcessID, con_year(Date.Now.Year), TR_ID)

        Dim objStreamWriter As New StreamWriter(Path_XML)
        Dim x As New XmlSerializer(class_xml.GetType)
        x.Serialize(objStreamWriter, class_xml)
        objStreamWriter.Close()






        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, ProcessID, Path_PDF) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO



        '_XML_PATH_PDF = Path_PDF



        '----------------------------------------------------------------------------

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & Path_PDF & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & Path_PDF ' Link เปิดไฟล์ตัวใหญ่


        'show_btn() 'ตรวจสอบปุ่ม




    End Sub


    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim statusID As Integer = ddl_status.SelectedItem.Value
        Dim bao As New BAO.GenNumber
        Dim rcvno As String = ""
        Dim rcv_format As String = ""
        Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
        dao.GetDataby_IDA(_IDA)

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 1 'สถานที่จำลอง
        dao_date.fields.STATUS_ID = ddl_status.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        'dao_date.fields.PROCESS_ID = _Process
        dao_date.insert()

        If statusID = "7" Then
            Response.Redirect("FRM_STAFF_LOCATION_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _Process)
            'dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            'Try
            '    dao.fields.rcvdate = CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try
            'dao.update()
            'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "3" Then
            bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, "99", _IDA)
            bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            Try
                dao.fields.rcvdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.rcvno = rcvno
            dao.update()
            alert("ทำการบันทึกข้อมูลเรียบร้อยแล้ว คุณได้เลขรับที่ " & rcvno)
        ElseIf statusID = "8" Then
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            dao.update()
            alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว")
        End If


        

    End Sub

    Sub load_pdf(ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")

            Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

        Catch ex As Exception

        Finally

            Response.Flush()
            Response.Close()
            Response.End()
        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim filename As String = HiddenField1.Value
        Try
            load_pdf(filename) ' เปิดPDF
        Catch ex As Exception

        End Try
    End Sub
End Class