Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class FRM_RGT_EDIT_CONFIRM
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private b64 As String
    Sub RunQuery()
        _YEARS = con_year(Date.Now.Year)
        Try
            _ProcessID = Request.QueryString("process")

        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")
            
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")

        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            Try
                BindData_PDF()
            Catch ex As Exception
                Response.Redirect("https://privus.fda.moph.go.th/")
            End Try

            bind_ddl_rqt()
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)
            If Request.QueryString("staff") <> "" Then
                If Request.QueryString("staff") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("staff"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(_IDA)
        Return dao.fields.cnccscd.ToString()
    End Function
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(IDA)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Sub bind_ddl_rqt()
        'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
        'dao.GetData_TABEAN_Only()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_TYPE_REQUESTS_EDIT()
        ddl_req_type.DataSource = dt
        ddl_req_type.DataTextField = "TYPE_REQUESTS_NAME"
        ddl_req_type.DataValueField = "TYPE_REQUESTS_ID"
        ddl_req_type.DataBind()
    End Sub
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        Dim bao As New BAO.ClsDBSqlcommand
        dao.GetDatabyIDA(Integer.Parse(_IDA))
        'dao.fields.STATUS_ID = 2
        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
        Try
            If dao_rg.fields.rgttpcd = "G" Or dao_rg.fields.rgttpcd = "H" Or dao_rg.fields.rgttpcd = "K" Or ddl_req_type.SelectedValue = "599" Then
                dao.fields.STATUS_ID = 3
            Else
                dao.fields.STATUS_ID = 2
            End If
        Catch ex As Exception

        End Try
        Try
            dao.fields.TYPE_REQUESTS_ID = ddl_req_type.SelectedValue
        Catch ex As Exception

        End Try

        dao.update()
        If b64 = Nothing Then
            b64 = Session("b64")
        End If
        Dim years As String = ""
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        If Len(_TR_ID) >= 9 Then
            dao_tr.GetDataby_TR_ID_Process(_TR_ID, _ProcessID)
        Else
            dao_tr.GetDataby_IDA(_TR_ID)
        End If
        Try
            years = dao_tr.fields.YEAR

        Catch ex As Exception

        End Try
        Dim tr_id As String = ""
        tr_id = "DA-" & _ProcessID & "-" & years & "-" & _TR_ID
        Try
         
          
            Dim cls_sop As New CLS_SOP
            cls_sop.BLOCK_SOP(_CLS.CITIZEN_ID, Request.QueryString("r_process"), "2", "สร้างคำขอ", tr_id, b64)
            cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "USER", Request.QueryString("r_process"), _CLS.PVCODE, 2, "สร้างคำขอ", "SOP-DRUG-10-" & Request.QueryString("r_process") & "-2", "ชำระเงิน", "สร้างคำขอแล้ว รอชำระเงิน", "STAFF", tr_id, SOP_STATUS:="สร้างคำขอ")
        Catch ex As Exception

        End Try
       
        AddLogStatus(2, _ProcessID, _CLS.CITIZEN_ID, _IDA)

        Session("b64") = Nothing
        alert("ยื่นคำขอแล้ว")

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        dao.update()
        AddLogStatus(7, _ProcessID, _CLS.CITIZEN_ID, _IDA)
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_EDIT_DRRGT
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
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


    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        'Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt


        dao.GetDatabyIDA(_IDA)


        'dao_lcn.GetDataby_IDA(dao.fields.LCN_IDA)
        'dao_drrgt.GetDataby_IDA(dao.fields.FK_IDA)

        Dim dao_sc As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        ' dao_sc.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
        dao_sc.GetDataby_NEWCODE(Request.QueryString("newcode"))
        Dim dao_lcn_e As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
        Try
            dao_lcn_e.GetDataby_u1(dao_sc.fields.Newcode_not)
        Catch ex As Exception

        End Try


        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'Try
        '    dao.GetDataby_IDA(dao_drrgt.fields.FK_LCN_IDA)
        'Catch ex As Exception

        'End Try




        Dim cls_regis As New CLASS_GEN_XML.EDIT_DRRGT(_CLS.CITIZEN_ID, dao_lcn_e.fields.lcnsid, dao.fields.lcnno, dao_lcn_e.fields.lcntpcd, dao_lcn_e.fields.pvncd, dao.fields.FK_IDA)

        Dim class_xml As New CLASS_EDIT_DRRGT
        ' class_xml = cls_regis.gen_xml()
        class_xml.DRRGT_EDIT_REQUESTs = dao.fields
        Dim lcnno As String = ""
        Dim rcvno_format As String = ""
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim TABEAN_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim rcvno As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnsid As String = ""
        Try
            rcvno_auto = dao_sc.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_sc.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_sc.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_sc.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_sc.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_sc.fields.thadrgnm & " / " & dao_sc.fields.engdrgnm
        Catch ex As Exception

        End Try
        Try
            If dao_lcn_e.fields.lcntpcd.Contains("ผยบ") Or dao_lcn_e.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao_lcn_e.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao_lcn_e.fields.lcntpcd & " " & CStr(CInt(Right(dao_lcn_e.fields.lcnno, 5))) & "/" & Left(dao_lcn_e.fields.lcnno, 2)
        Catch ex As Exception

        End Try
        'Try
        '    If Len(rgtno_auto) > 0 Then
        '        rgtno_format = pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try
        Dim aa As String = ""
        Dim aa2 As String = ""
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
        dao3.GetDataby_IDA(dao.fields.FK_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try

            Try
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
                daodrgtype2.GetDataby_drgtpcd(dao_rq.fields.drgtpcd)

                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try
        Try
            If IsNothing(dao_sc.fields.rcvdate) = False Then
                Dim appdate As Date
                If Date.TryParse(dao_sc.fields.appdate, appdate) = True Then
                    class_xml.SHOW_LCNDATE_DAY = appdate.Day
                    class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                    class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)


                    class_xml.RCVDAY = appdate.Day
                    class_xml.RCVMONTH = appdate.ToString("MMMM")
                    class_xml.RCVYEAR = con_year(appdate.Year)

                End If
            End If
        Catch ex As Exception

        End Try

        Try
            If IsNothing(dao.fields.rcvdate) = False Then
                Dim rcvdate As Date
                If Date.TryParse(dao.fields.rcvdate, rcvdate) = True Then
                    class_xml.rcvdate = rcvdate.Day & "/" & rcvdate.Month & "/" & con_year(rcvdate.Year)
                End If

                If Date.TryParse(dao.fields.rcvdate, rcvdate) = True Then
                    class_xml.RCV_DATE_FORMAT = CStr(rcvdate.Day) & " " & rcvdate.ToString("MMMM") & " " & con_year(rcvdate.Year)
                End If
            End If
        Catch ex As Exception

        End Try

        Try
            If IsNothing(dao.fields.rcvdate) = False Then
                Dim write_date As Date
                If Date.TryParse(dao.fields.WRITE_DATE, write_date) = True Then
                    class_xml.WRITE_DATE_FORMAT = CStr(write_date.Day) & " " & write_date.ToString("MMMM") & " " & con_year(write_date.Year)
                End If
            End If
        Catch ex As Exception

        End Try

        Try
            class_xml.STAFF_IDEN_RECEIVE = set_name_company(dao.fields.STAFF_IDEN_RECEIVE)
        Catch ex As Exception

        End Try
        Dim dt_rgtno As New DataTable
        Dim bao_rgtno As New BAO.ClsDBSqlcommand
        dt_rgtno = bao_rgtno.SP_DRRGT_RGTNO_DISPLAY_BY_IDA(dao.fields.FK_IDA)
        Try
            'rgtno_format = dt_rgtno(0)("rgtno_display")
            rgtno_format = dao_sc.fields.register
        Catch ex As Exception

        End Try
        class_xml.LCN_TYPE = LCN_TYPE
        class_xml.LCNTPCD_GROUP = LCNTPCD_GROUP
        class_xml.LCNNO_FORMAT = LCNNO_FORMAT
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RGTNO_FORMAT = rgtno_format
        class_xml.OLD_NAME_TH = dao_sc.fields.thadrgnm
        class_xml.OLD_NAME_EN = dao_sc.fields.engdrgnm

        Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
        dao_color.GetDataby_FK_IDA(dao.fields.FK_IDA)
        class_xml.DRRGT_COLOR = dao_color.fields


        Dim dao_edt_color As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_COLOR
        dao_edt_color.GetDataby_FK_IDA(_IDA)
        class_xml.DRRGT_EDIT_REQUEST_COLOR = dao_edt_color.fields
        Try
            If dao.fields.STATUS_ID = "8" Then
                class_xml.APP_TYPE1 = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.STATUS_ID = "7" Then
                class_xml.APP_TYPE2 = "1"
            End If

            class_xml.APP_TYPE2_PURPOSE = ""
        Catch ex As Exception

        End Try
        Try
            If dao.fields.STATUS_ID = "4" Then
                class_xml.APP_TYPE3 = "1"

            End If

            class_xml.APP_TYPE3_PURPOSE = dao.fields.OTHER_ORDER
        Catch ex As Exception

        End Try
        
        class_xml.DRUG_NAME = drug_name
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        Dim bao_show As New BAO_SHOW
        Dim bao_cls As New BAO.ClsDBSqlcommand
        class_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, lcnsid) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT2 = bao_show.SP_DRRGT_EDIT_REQUEST_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
        class_xml.DT_SHOW.DT3 = bao_show.SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_NORMAL(_IDA)
        class_xml.DT_SHOW.DT4 = bao_show.SP_DRRGT_EDIT_REQUEST_CAS_BY_FK_IDA_BIO(_IDA)
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn_e.fields.IDA_dalcn) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try
        Try
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.GetDataby_IDA(dao_lcn_e.fields.IDA_dalcn)
            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dal.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        Catch ex As Exception

        End Try
        p_rgt_edt = class_xml

        Dim p_dr2 As New CLASS_EDIT_DRRGT
        p_dr2 = p_rgt_edt
        'p_dr2.DT_MASTER = Nothing

        Dim cls_sop1 As New CLS_SOP
        Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dr2)
        b64 = cls_sop1.CLASS_TO_BASE64(p_dr2)

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)
        class_xml = cls_regis.gen_xml()
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PATH_PDF_TEMPLATE = PDF_TEMPLATE
        _CLS.PATH_XML = Path_XML

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        _CLS.FILENAME_XML = NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = ""
        End Try

        Return fullname
    End Function
End Class