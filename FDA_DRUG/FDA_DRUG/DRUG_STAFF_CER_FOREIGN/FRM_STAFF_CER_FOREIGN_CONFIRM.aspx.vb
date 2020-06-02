Imports Telerik.Web.UI

Public Class FRM_STAFF_CER_FOREIGN_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _TR_ID As Integer
    Private _IDA As Integer

    Sub runQuery()
        _TR_ID = Request.QueryString("TR_ID")
        _IDA = Request.QueryString("IDA")
        ' _ProcessID = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            '     TR_ID=" & dao_up.fields.ID & "&IDA=" & str_ID
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub bind_lbl()
        Dim dao As New DAO_DRUG.TB_CER_FOREIGN
        Try
            dao.GetDataby_IDA(_IDA)
        Catch ex As Exception

        End Try
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Try
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Catch ex As Exception

        End Try
        Try
            lbl_mobile.Text = dao.fields.MOBILE
        Catch ex As Exception
            lbl_mobile.Text = "-"
        End Try
        Dim uti As New cls_utility.Report_Utility
        Try
            lbl_person.Text = uti.get_name_person_or_office_name(2, dao_up.fields.CITIEZEN_ID)
        Catch ex As Exception

        End Try
        Try
            lbl_office.Text = uti.get_name_person_or_office_name(1, dao_up.fields.CITIEZEN_ID_AUTHORIZE)
        Catch ex As Exception

        End Try
        Try
            lbl_old_tr_id.Text = dao.fields.OLD_TR_ID
        Catch ex As Exception
            lbl_old_tr_id.Text = "-"
        End Try
    End Sub

    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_MAS_STATUS_STAFF_CER()
        dt = bao.dt

        ddl_status.DataSource = dt
        ddl_status.DataValueField = "STATUS_ID"
        ddl_status.DataTextField = "STATUS_NAME"
        ddl_status.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        UC_GRID_ATTACH1.load_gv(_TR_ID)
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:500px;width:100%;' src='../PDF/PDF_PERVIEW.aspx?ID=" & _CLS.IDA & "&ID_transection=" & _CLS.TR_ID & "&PROCESS_ID=5" & "&STATUS=" & load_STATUS() & "' ></iframe>"
            Bind_ddl_Status_staff()
            BindData_PDF()
            bind_lbl()
            show_btn()
        End If
    End Sub

    Private Sub show_btn()

        Dim dao As New DAO_DRUG.TB_CER_FOREIGN
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID = 8 Then
            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-lg btn-danger"
            ddl_status.Enabled = False
        End If

    End Sub

    Private Sub BindData_PDF()

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_cer As New DAO_DRUG.TB_CER_FOREIGN
        dao_cer.GetDataby_IDA(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao_cer.fields.FK_IDA)
        Dim dao_dalcntype As New DAO_DRUG.ClsDBdalcntype
        dao_dalcntype.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)

        Dim LCNSID As Integer = dao_cer.fields.LCNSID
        Dim lcn_IDA As Integer
        Dim STATUS As Integer
        For Each dao_cer.fields In dao_cer.datas
            lcn_IDA = dao_cer.fields.FK_IDA
            LCNSID = dao_cer.fields.LCNSID
            STATUS = dao_cer.fields.STATUS_ID
        Next

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao_cer.fields.TR_ID)

        Dim PROCESS_ID As String = dao_up.fields.PROCESS_ID.ToString()
        Dim Year As String = dao_up.fields.YEAR.ToString()
        Dim TR_ID As String = dao_up.fields.ID.ToString()
        Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID

        Dim dao_CER_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_CER_DETAIL_CASCHEMICAL
        dao_CER_DETAIL_CASCHEMICAL.GetDataby_FK_IDA(dao_cer.fields.FK_IDA)
        'Dim dao_fregtype As New DAO.clsDBfafdtype
        'dao_fregtype.Getdata_by_fdtypecd(dao_fregntf.fields.fdtypecd)

        Dim cls_cer As New CLASS_GEN_XML.Cerf(CITIZEN_ID, LCNSID, lcn_IDA)

        Dim class_xml As New CLASS_CER_FOREIGN
        class_xml = cls_cer.gen_xml_CER()
        class_xml.CER_FOREIGNs = dao_cer.fields
        class_xml.CER_DETAIL_CASCHEMICALs = dao_CER_DETAIL_CASCHEMICAL.Details()

        Dim dao_CER_DETAIL_MANUFACTURE As New DAO_DRUG.TB_CER_FOREIGN_MANUFACTURE
        dao_CER_DETAIL_MANUFACTURE.GetDataby_FK_IDA(dao_cer.fields.IDA)
        class_xml.CER_FOREIGN_MANUFACTUREs = dao_CER_DETAIL_MANUFACTURE.fields

        p_cerf = class_xml

        '_______________SHOW___________________
        Dim bao_show As New BAO_SHOW
        'ชื่อผู้ใช้ระบบ
        class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID)
        'ชื่อบริษัท
        class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID)


        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _CLS.LCNSID_CUSTOMER) 'ข้อมูลที่ตั้งหลัก
        'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao_cer.fields.LCNSID) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _CLS.LCNSID_CUSTOMER) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER

        'ชื่อประเภทยา
        'class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_dactg()

        'ประเทศ
        class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt()

        'เลขที่ใบอนุญาต
        class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(lcn_IDA)

        ' bao_master.SP_MASTER_fafdtype.TableName = "ประกาศใบอนุญาต"
        class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(lcn_IDA)

        'ประเภท Cer
        class_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_lgt_impcertp()

        ''สาร
        'class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL()

        'class_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(dao_cer.fields.IDA)
        'class_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(dao_cer.fields.IDA)

        ''-------------------------ใส่ข้อมูลย่อยลง xml---------------------------
        'For Each dao_CER_DETAIL_MANUFACTURE.fields In dao_CER_DETAIL_MANUFACTURE.datas
        '    Dim cls_CER_DETAIL_MANUFACTURE As New CER_FOREIGN_MANUFACTURE
        '    cls_CER_DETAIL_MANUFACTURE = dao_CER_DETAIL_MANUFACTURE.fields
        '    class_xml.CER_FOREIGN_MANUFACTURE.Add(cls_CER_DETAIL_MANUFACTURE)
        'Next

        'class_xml.URL_CHEMICAL_SEARCH = "http://164.115.28.101/FDA_DRUG/CHEMICAL/FRM_CHEMICAL_SEARCH.aspx"
        class_xml.LCNNO_SHOW = dao_lcn.fields.LCNNO_DISPLAY
        class_xml.TYPE_IMPORT = dao_dalcntype.fields.lcntpnm

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, 0, STATUS, 0)

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "\PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, Year, dao_cer.fields.TR_ID) 'paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, Year, dao_cer.fields.TR_ID) 'paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:500px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


        _CLS.PDFNAME = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, Year, dao_cer.fields.TR_ID)
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click

        If ddl_status.SelectedValue = 8 Then
            Dim bao As New BAO.GenNumber 'test
            Dim dao As New DAO_DRUG.TB_CER_FOREIGN
            dao.GetDataby_IDA(_IDA)
            Dim dao_manuf As New DAO_DRUG.TB_CER_FOREIGN_MANUFACTURE
            dao_manuf.GetDataby_FK_IDA(dao.fields.IDA)
            Dim cernumber As String = bao.GEN_CER_FOREIGN_NO(con_year(Date.Now.Year.ToString()), _CLS.PVCODE(), dao.fields.CER_TYPE, _CLS.LCNNO, "1", "1", _IDA, "", dao_manuf.fields.STANDARD_ID)
            Dim rcvno As String = bao.GEN_CER_RCVNO(con_year(Date.Now.Year.ToString()), _CLS.PVCODE(), dao.fields.CER_TYPE, _CLS.LCNNO, "1", "2", _IDA, "")

            dao.fields.CER_NUMBER = cernumber
            dao.fields.CER_DATE = Date.Now
            dao.fields.RCVNO = rcvno
            dao.fields.RCVDATE = Date.Now
            dao.fields.STATUS_ID = ddl_status.SelectedValue
            dao.fields.CER_FORMAT = cernumber
            dao.update()
            AddLogStatus(8, Request.QueryString("ProcessID"), _CLS.CITIZEN_ID)
            alert("เลขรับ คือ " & rcvno.ToString() & " REF CER คือ " & cernumber) 'test
        ElseIf ddl_status.SelectedValue = 7 Then
            Response.Redirect("FRM_STAFF_CER_FOREIGN_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        End If


        'If ddl_status.SelectedValue = 8 Then
        '    alert("เลขรับ คือ " & rcvno.ToString() & " REF CER คือ " & cernumber) 'test
        'Else
        '    alert("ยืนยันการพิจารณาเรียบร้อยแล้ว")
        'End If
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        'Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        'Dim dao_cer As New DAO_DRUG.TB_CER
        'dao_cer.GetDataby_IDA2(_IDA)

        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(dao_cer.fields.TR_ID)

        'Dim PROCESS_ID As String = dao_up.fields.PROCESS_ID.ToString()
        'Dim Year As String = dao_up.fields.YEAR.ToString()
        'Dim TR_ID As String = dao_up.fields.ID.ToString()

        'Dim filename As String = ""
        'If dao_cer.fields.STATUS_ID = 6 Then
        '    filename = bao._PATH_PDF_TRADER & NAME_OUTPUT_PDF("DA", PROCESS_ID, Year, TR_ID)
        'Else
        '    filename = bao._PATH_PDF_TRADER & NAME_UPLOAD_PDF("DA", PROCESS_ID, Year, TR_ID)
        'End If

        load_pdf(_CLS.PDFNAME, _CLS.FILENAME_PDF)


    End Sub
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_pdf(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        alert("กลับสู่หน้าหลัก")
    End Sub

End Class