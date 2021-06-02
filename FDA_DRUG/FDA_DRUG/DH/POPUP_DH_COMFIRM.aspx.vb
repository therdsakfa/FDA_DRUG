Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_DH_COMFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _YEARS As String

    Sub RunSession()
        _IDA = Request.QueryString("IDA")
        _process = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        _YEARS = con_year(Date.Now.Year)
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BindData_PDF()
            Try
                Dim dao_dh As New DAO_DRUG.ClsDBdh15rqt
                dao_dh.GetDataby_IDA(_IDA)
                If dao_dh.fields.STATUS_ID = 1 Then
                    If dao_dh.fields.IMAGE_QR_INPUT = "" Then
                        reload_pdf(_CLS.PATH_XML, _CLS.PATH_PDF_TEMPLATE, _CLS.PDFNAME)
                        dao_dh.fields.IMAGE_QR_INPUT = _CLS.FILENAME_XML
                        dao_dh.update()
                    End If

                End If
            Catch ex As Exception

            End Try

            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _process)
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID <> 1 Then

            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dh15rqt")

        Try
            rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1
        Catch ex As Exception

        End Try


        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอเภสัชเคมีภัณฑ์", _process)
        Dim lcn_ida As Integer = 0
        Dim type_rqt As Integer = 0
        Dim country As Integer = 0

        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        dao.GetDataby_IDA(_IDA)
        Try
            lcn_ida = dao.fields.FK_IDA
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd = "ผย1" Then
                type_rqt = 1
            End If
        Catch ex As Exception

        End Try
        Try
            country = Trim(dao.fields.FOREIGN_COUNTRY_CD)
        Catch ex As Exception

        End Try
        'If _process <> 15 Then
        If type_rqt = 1 And country <> 233 Then
            Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถจดแจ้งสถานที่ผลิตต่างประเทศภายใต้ใบอนุญาตผลิตยาได้');</script> ")
        Else
            If _process = 16 Or _process = 17 Or _process = 18 Then
                dao.fields.STATUS_ID = 8

                Dim RCVNO As String = ""
                Dim run_number As String = ""
                Dim dao2 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
                dao2.GetDataby_FK_IDA(_IDA)
                Dim bao2 As New BAO.GenNumber
                RCVNO = bao2.GEN_NO_04(con_year(Date.Now.Year()), _CLS.PVCODE, _process, "", "", 0, _IDA, "")
                dao.fields.rcvno = RCVNO
                dao.fields.RCVNO_DISPLAY = bao2.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                dao.fields.rcvdate = Date.Now
                dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
                dao.fields.REQUEST_DATE = Date.Now

                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                dao_lcn.GetDataby_IDA(lcn_ida)
                Try
                    dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.pvnabbr = dao_lcn.fields.pvnabbr
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lcnsid = dao_lcn.fields.lcnsid
                Catch ex As Exception

                End Try
                'For Each dao2.fields In dao2.datas
                Dim CAS_ID As Integer = 0
                Dim dao_cas As New DAO_DRUG.TB_MAS_CHEMICAL
                Try
                    CAS_ID = RTrim(LTrim(dao2.fields.CAS_ID))
                Catch ex As Exception

                End Try
                dao_cas.GetDataby_IDA(CAS_ID)


                Dim bao As New BAO.GenNumber 'test

                run_number = bao.GEN_DH15TDGT_NO(_YEARS, dao_cas.fields.aori, _process, _IDA, dao2.fields.IDA, dao.fields.QUOTA_TYPE)

                Dim dao3 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
                dao3.GetDataby_IDA(dao2.fields.IDA)
                If Len(dao3.fields.phm15dgt) = 0 Then
                    dao3.fields.phm15dgt = run_number
                    dao3.update()
                End If
                dao.update()

                Dim ws_update As New WS_DRUG_126.WS_DRUG
                ws_update.DRUG_INSERT_DH15_126(_IDA, _CLS.CITIZEN_ID_AUTHORIZE)

                AddLogStatus(8, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ยื่นคำขอเรียบร้อยแล้ว เลขจดแจ้ง 15 หลักคือ คือ " & run_number)
            Else
                If _process = 14 Then
                    dao.fields.STATUS_ID = 10

                    Dim RCVNO As String = ""
                    Dim run_number As String = ""
                    Dim bao2 As New BAO.GenNumber
                    RCVNO = bao2.GEN_NO_04(con_year(Date.Now.Year()), _CLS.PVCODE, _process, "", "", 0, _IDA, "")
                    dao.fields.rcvno = RCVNO
                    dao.fields.RCVNO_DISPLAY = bao2.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                    dao.fields.rcvdate = Date.Now
                    dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
                    dao.fields.REQUEST_DATE = Date.Now

                    Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                    dao_lcn.GetDataby_IDA(lcn_ida)
                    Try
                        dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.pvnabbr = dao_lcn.fields.pvnabbr
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.lcnsid = dao_lcn.fields.lcnsid
                    Catch ex As Exception

                    End Try
                    dao.update()
                ElseIf _process = 15 Then
                    AddLogStatus(2, _process, _CLS.CITIZEN_ID, _IDA)
                    dao.fields.STATUS_ID = 2
                    dao.fields.REQUEST_DATE = Date.Now
                    dao.update()
                    alert("ยื่นคำขอเรียบร้อยแล้ว")
                End If

            End If
        End If


        'End If

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    End Sub

    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)

        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DH
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        Dim dao_DH15_DETAIL_CER As New DAO_DRUG.TB_DH15_DETAIL_CER
        Dim dao_DH15_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL


        dao.GetDataby_IDA(_IDA)
        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
        dao_DH15_DETAIL_CER.GetDataby_FK_IDA(dao.fields.IDA)
        dao_DH15_DETAIL_CASCHEMICAL.GetDataby_FK_IDA(dao.fields.IDA)


        Dim cls_regis As New CLASS_GEN_XML.DH(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao.fields.FK_IDA)

        Dim class_xml As New CLASS_DH
        ' class_xml = cls_regis.gen_xml()

        '_______________SHOW_________________
        Dim bao_show As New BAO_SHOW

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao_lcn.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao_lcn.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        ' class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน
        class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        '_______________MASTER_________________
        Dim bao_master As New BAO_MASTER


        class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt() 'ประเทศ
        class_xml.DT_MASTER.DT18 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_TR_ID(dao.fields.TR_ID) 'สารที่เลือก
        class_xml.DT_MASTER.DT19 = bao_master.SP_MASTER_CER_PK_BY_FK_IDA(dao.fields.FK_IDA) 'CER



        Dim CER_DETAIL_CHEMICAL_IDA As Integer = 0
        Try
            CER_DETAIL_CHEMICAL_IDA = dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA
        Catch ex As Exception



        End Try


        '-------------------------ใส่ข้อมูลย่อยลงxml---------------------------
        For Each dao_DH15_DETAIL_CER.fields In dao_DH15_DETAIL_CER.datas
            Dim cls_DH15_DETAIL_CER As New DH15_DETAIL_CER
            cls_DH15_DETAIL_CER = dao_DH15_DETAIL_CER.fields
            class_xml.DH15_DETAIL_CERs.Add(cls_DH15_DETAIL_CER)
        Next


        For Each dao_DH15_DETAIL_CASCHEMICAL.fields In dao_DH15_DETAIL_CASCHEMICAL.datas
            Dim cls_DH15_DETAIL_CASCHEMICAL As New DH15_DETAIL_CASCHEMICAL
            cls_DH15_DETAIL_CASCHEMICAL = dao_DH15_DETAIL_CASCHEMICAL.fields
            class_xml.DH15_DETAIL_CASCHEMICALs.Add(cls_DH15_DETAIL_CASCHEMICAL)
        Next

        Try
            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
            dao_iso.GetDataby_IDA(dao.fields.AGENT_COUNTRY_ID)
            class_xml.AGENT_COUNTRY_NAME = dao_iso.fields.engcntnm
        Catch ex As Exception

        End Try
        Try
            '
            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
            dao_iso.GetDataby_IDA(dao.fields.FOREIGN_COUNTRY_CD)
            class_xml.FOREIGN_COUNTRY_NAME = dao_iso.fields.engcntnm
        Catch ex As Exception

        End Try

        '------------------------------------------



        class_xml.DT_MASTER.DT21 = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(CER_DETAIL_CHEMICAL_IDA) 'สาร
        class_xml.DT_MASTER.DT22 = bao_master.SP_CER_DETAIL_MANUFACTURE_by_FK_IDA(CER_DETAIL_CHEMICAL_IDA) 'สถานที่ผลิต


        class_xml.DT_MASTER.DT32 = bao_master.SP_MASTER_DH15_DETAIL_CER_by_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT33 = bao_master.SP_MASTER_DH15_DETAIL_CASCHEMICAL_by_FK_IDA(dao.fields.IDA) 'สารที่เลือกใน ภค
        Try
            'Dim rcvdate As Date = dao.fields.rcvdate
            'dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.dh15rqts = dao.fields

        Catch ex As Exception

        End Try

        p_dh = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_process, _process, statusId, 0)
        'class_xml = cls_regis.gen_xml()
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID)
        _CLS.PATH_PDF_TEMPLATE = PDF_TEMPLATE
        _CLS.PATH_XML = Path_XML

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _process, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        _CLS.FILENAME_XML = NAME_XML("DA", _process, _YEARS, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
    Sub reload_pdf(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, PATH_PDF_OUTPUT As String)
        Dim cls_xml As New CLASS_GEN_XML.Center
        cls_xml.GEN_XML_DH(PATH_XML, p_dh)
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                End Using
            End Using
        End Using
    End Sub
    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        reload_pdf(_CLS.PATH_XML, _CLS.PATH_PDF_TEMPLATE, _CLS.PDFNAME)

    End Sub
End Class