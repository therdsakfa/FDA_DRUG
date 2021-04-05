Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI
Imports System.Xml
Imports System.Reflection

Public Class FRM_RGT_EDIT_CONFIRM_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _TR_ID As String
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Sub runQuery()
        _YEARS = con_year(Date.Now.Year)
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _ProcessID = Request.QueryString("Process")
        Catch ex As Exception

        End Try

        ' _ProcessID = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            ''     TR_ID=" & dao_up.fields.ID & "&IDA=" & str_ID
            '_TR_ID = Request.QueryString("TR_ID")
            '_IDA = Request.QueryString("IDA")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:500px;width:100%;' src='../PDF/PDF_PERVIEW.aspx?ID=" & _CLS.IDA & "&ID_transection=" & _CLS.TR_ID & "&PROCESS_ID=5" & "&STATUS=" & load_STATUS() & "' ></iframe>"
            Bind_ddl_Status_staff()
            BindData_PDF()
            'bind_lbl()
            set_hide(_IDA)
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt


            dao.GetDatabyIDA(_IDA)

            Try
                If dao.fields.RQT_TYPE = "1" Then
                    lbl_rqt_type.Text = "ยื่นผ่านระบบ eReview"
                ElseIf dao.fields.RQT_TYPE = "2" Then
                    lbl_rqt_type.Text = "ยื่นผ่านระบบ Skynet Smart Dropbox"
                ElseIf dao.fields.RQT_TYPE = "3" Then
                    lbl_rqt_type.Text = "ยื่นผ่านระบบ PDF ผ่านระบบนี้"
                End If
            Catch ex As Exception

            End Try
            Try
                lbl_rqt_identify.Text = dao.fields.RQT_IDENTIFY
            Catch ex As Exception

            End Try
            Try
                dao_drrgt.GetDataby_IDA(dao.fields.FK_IDA)
            Catch ex As Exception

            End Try
            Try
                dao_lcn.GetDataby_IDA(dao_drrgt.fields.FK_LCN_IDA)
            Catch ex As Exception

            End Try
            Try
                Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 8)
                lbl_current_stat.Text = dao_stat.fields.STATUS_NAME_STAFF
            Catch ex As Exception

            End Try
            'Try
            '    If dao.fields.STATUS_ID = 14 Or dao.fields.STATUS_ID = 15 Then
            '        If dao.fields.cncdate IsNot Nothing Then
            '            btn_send_edit.Style.Add("display", "block")
            '        Else
            '            btn_send_edit.Style.Add("display", "none")
            '        End If

            '    Else
            '        btn_send_edit.Style.Add("display", "none")
            '    End If
            'Catch ex As Exception

            'End Try

            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            If Len(_TR_ID) >= 9 Then
                dao_tr.GetDataby_TR_ID_Process(_TR_ID, _ProcessID)
            Else
                dao_tr.GetDataby_IDA(_TR_ID)
            End If

            Dim bao As New BAO.AppSettings
                bao.RunAppSettings()
                Dim paths As String = bao._PATH_DEFAULT
            Dim Path_XML As String = paths & "XML_TRADER_UPLOAD" & "\" & NAME_XML("DA", _ProcessID, dao_tr.fields.YEAR, _TR_ID)
            Dim cls_xml As New CLASS_GEN_XML.EDIT_DRRGT
                ', p_rgt_edt

                'COMPARE_OBJECT(GEN_XML_EDT_DRRGT_R(Path_XML), GET_OLD_DATA(dao.fields.FK_IDA), _IDA)
                set_lbl()
            End If
    End Sub
    Sub set_lbl()
        
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(_IDA)

            Try
            lbl_appdate.Text = CDate(dao.fields.cncdate).ToShortDateString()
            Catch ex As Exception
                lbl_appdate.Text = "-"
            End Try
            Try
                lbl_rcvdate.Text = CDate(dao.fields.rcvdate).ToShortDateString()
            Catch ex As Exception
                lbl_rcvdate.Text = "-"
            End Try

    End Sub
    Public Function GEN_XML_EDT_DRRGT_R(ByVal PATH As String) As CLASS_EDIT_DRRGT
        Dim p2 As New CLASS_EDIT_DRRGT
        Dim objStreamReader As New StreamReader(PATH) '"C:\path\XML_TRADER\"
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Return p2
    End Function
    'Public Sub Bind_ddl_Status_staff()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_MAS_STATUS_STAFF_RGT_EDIT()
    '    dt = bao.dt

    '    ddl_status.DataSource = dt
    '    ddl_status.DataValueField = "STATUS_ID"
    '    ddl_status.DataTextField = "STATUS_NAME"
    '    ddl_status.DataBind()
    'End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl1 As Integer = 0
        Dim int_group_ddl2 As Integer = 0
        Dim status_id1 As Integer = 0

        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        Try
            dao.GetDatabyIDA(_IDA)
            status_id1 = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try

       
        'If status_id1 = 3 Then
        '    int_group_ddl1 = 97
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 4 Then
        '    int_group_ddl1 = 1
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 5 Then
        '    int_group_ddl1 = 2
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 6 Then
        '    int_group_ddl1 = 3
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 9 Then
        '    int_group_ddl1 = 4
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 10 Then 'จ่ายเงินแล้ว
        '    int_group_ddl1 = 5
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 11 Then
        '    int_group_ddl1 = 6
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 12 Then
        '    int_group_ddl1 = 8
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 13 Then
        '    int_group_ddl1 = 9
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 14 Then
        '    int_group_ddl1 = 10
        '    int_group_ddl2 = 77
        'ElseIf status_id1 = 15 Then
        '    int_group_ddl1 = 11
        '    int_group_ddl2 = 77
        '    'ElseIf status_id1 = 15 Then
        '    '    int_group_ddl1 = 10
        '    '    int_group_ddl2 = 77
        'End If
        If status_id1 >= 2 And status_id1 <> 8 And status_id1 < 6 Then
            int_group_ddl1 = 1
        ElseIf status_id1 >= 6 And status_id1 <> 8 And status_id1 < 14 Then
            int_group_ddl1 = 2
        ElseIf status_id1 >= 14 And status_id1 <> 8 Then
            int_group_ddl1 = 3
        End If

        '= 6 หา group 2
        '=14 หา group 3
        If int_group_ddl1 = 3 Then
            dt = Get_DDL_DATA(8, int_group_ddl1, int_group_ddl2)
            Dim dt2 As New DataTable
            dt2 = dt.Clone
            For Each dr As DataRow In dt.Select("STATUS_ID <> 8")
                Dim dr2 As DataRow = dt2.NewRow()
                dr2("STATUS_ID") = dr("STATUS_ID")
                dr2("STATUS_NAME_STAFF") = dr("STATUS_NAME_STAFF")
                dr2("STATUS_NAME") = dr("STATUS_NAME")
                dr2("seq") = dr("seq")
                dt2.Rows.Add(dr2)
            Next
            'Dim dv As DataView = dt2
            dt2.DefaultView.Sort = "seq ASC"
            Dim dtResult As DataTable = dt2.DefaultView.ToTable()
            ddl_status.DataSource = dtResult 'dt.Select("STATUS_ID <> 8")
            ddl_status.DataValueField = "STATUS_ID"
            ddl_status.DataTextField = "STATUS_NAME_STAFF"
            ddl_status.DataBind()
            ddl_status.Items.Insert(0, New ListItem("อนุมัติโดยไม่แก้ไข", 8))
        Else
            dt = Get_DDL_DATA(8, int_group_ddl1, int_group_ddl2)
            ddl_status.DataSource = dt
            ddl_status.DataValueField = "STATUS_ID"
            ddl_status.DataTextField = "STATUS_NAME_STAFF"
            ddl_status.DataBind()
        End If




    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        'Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V3 @stat_group=" & stat_g & ", @group1=" & group1
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function
    Public Sub set_hide(ByVal IDA As String)
        Try
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            dao.GetDatabyIDA(IDA)
            If (dao.fields.STATUS_ID = 7 Or dao.fields.STATUS_ID = 8) Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_status.Style.Add("display", "none")
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB 'DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        Dim dao_drrgt As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB 'DAO_DRUG.ClsDBdrrgt



        dao.GetDatabyIDA(_IDA)
        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
        Dim drgtpcd_edt As String = ""

        Try
            drgtpcd_edt = dao.fields.drgtpcd
        Catch ex As Exception

        End Try

        Try
            'dao_drrgt.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
            dao_drrgt.GetDataby_4Key(dao_rg.fields.rgtno, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.pvncd)
        Catch ex As Exception

        End Try

        Try
            dao_lcn.GetDataby_u1(dao_drrgt.fields.Newcode_not)
        Catch ex As Exception

        End Try
        Dim cls_regis As New CLASS_GEN_XML.EDIT_DRRGT(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao.fields.FK_IDA)

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
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_drrgt.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_drrgt.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_drrgt.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_drrgt.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_drrgt.fields.thadrgnm & " / " & dao_drrgt.fields.engdrgnm
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then

                Dim aa3 As String = ""
                'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                'dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
                Dim dao_drgtype As New DAO_DRUG.ClsDBdrdrgtype

                dao_drgtype.GetDataby_drgtpcd(Trim(drgtpcd_edt))

                Try
                    aa3 = dao_drgtype.fields.engdrgtpnm
                Catch ex As Exception

                End Try

                rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa3
            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try
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
            If IsNothing(dao.fields.rcvdate) = False Then
                Dim rcvdate As Date
                If Date.TryParse(dao.fields.rcvdate, rcvdate) = True Then
                    class_xml.rcvdate = rcvdate.Day & "/" & rcvdate.Month & "/" & con_year(rcvdate.Year)
                End If

                If Date.TryParse(dao.fields.rcvdate, rcvdate) = True Then
                    class_xml.RCV_DATE_FORMAT = rcvdate.Day & " " & rcvdate.ToString("MMMM") & " " & con_year(rcvdate.Year)
                End If
            End If
        Catch ex As Exception

        End Try

        Try
            If IsNothing(dao.fields.rcvdate) = False Then
                Dim write_date As Date
                If Date.TryParse(dao.fields.WRITE_DATE, write_date) = True Then
                    class_xml.WRITE_DATE_FORMAT = write_date.Day & " " & write_date.ToString("MMMM") & " " & con_year(write_date.Year)
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
            rgtno_format = dt_rgtno(0)("rgtno_display")
        Catch ex As Exception

        End Try
        class_xml.LCN_TYPE = LCN_TYPE
        class_xml.LCNTPCD_GROUP = LCNTPCD_GROUP
        class_xml.LCNNO_FORMAT = LCNNO_FORMAT
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RGTNO_FORMAT = rgtno_format
        class_xml.OLD_NAME_TH = dao_drrgt.fields.thadrgnm
        class_xml.OLD_NAME_EN = dao_drrgt.fields.engdrgnm
        Try
            class_xml.WRITE_AT = dao.fields.WRITE_AT
        Catch ex As Exception

        End Try

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
        class_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, lcnsid) 'ข้อมูลบริษัท
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA_dalcn) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try
        Try
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.GetDataby_IDA(dao_lcn.fields.IDA_dalcn)
            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dal.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        Catch ex As Exception

        End Try
        p_rgt_edt = class_xml



        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)
        'class_xml = cls_regis.gen_xml()
        'CLASS_TO_XMLTYPE(class_xml)

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
    Private Function Get_New_data() As CLASS_EDIT_DRRGT
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt


        dao.GetDatabyIDA(_IDA)
        dao_lcn.GetDataby_IDA(dao.fields.LCN_IDA)
        dao_drrgt.GetDataby_IDA(dao.fields.FK_IDA)
        Dim cls_regis As New CLASS_GEN_XML.EDIT_DRRGT(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao.fields.FK_IDA)

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
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_drrgt.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_drrgt.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_drrgt.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_drrgt.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_drrgt.fields.thadrgnm & " / " & dao_drrgt.fields.engdrgnm
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
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
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        class_xml.LCN_TYPE = LCN_TYPE
        class_xml.LCNTPCD_GROUP = LCNTPCD_GROUP
        class_xml.LCNNO_FORMAT = LCNNO_FORMAT
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.RGTNO_FORMAT = rgtno_format
        class_xml.OLD_NAME_TH = dao_drrgt.fields.thadrgnm
        class_xml.OLD_NAME_EN = dao_drrgt.fields.engdrgnm

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
        class_xml.DT_SHOW.DT1 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, lcnsid) 'ข้อมูลบริษัท
        p_rgt_edt = class_xml

        class_xml = cls_regis.gen_xml()
        'CLASS_TO_XMLTYPE(class_xml)
        Return class_xml
    End Function

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click

        'If ddl_status.SelectedValue = 3 Then

        '    Response.Redirect("FRM_RGT_EDIT_STAFF_RECEIVE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

        'Else
        If ddl_status.SelectedValue = 6 Then
            Dim ii As Integer = 0
            Dim dao_rcv As New DAO_DRUG.TB_MAS_RECEIVER_EDIT_RQT
            dao_rcv.Getdata_by_IDEN(_CLS.CITIZEN_ID)
            For Each dao_rcv.fields In dao_rcv.datas
                ii += 1
            Next
            If _CLS.SYSTEM_ID = 6648 And ii > 0 Then
                Response.Redirect("FRM_RGT_EDIT_CHECK_RQT_SSP.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            Else
                Response.Redirect("FRM_RGT_EDIT_CHECK_RQT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            End If

            'FRM_RGT_EDIT_CHECK_RQT_SSP
        ElseIf ddl_status.SelectedValue = 8 Then

            If ddl_status.SelectedItem.Text = "อนุมัติโดยไม่แก้ไข" Then
                If IsDate(CDate(txt_appdate.Text)) Then
                    Dim bao As New BAO.GenNumber 'test
                    Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                    dao.GetDatabyIDA(_IDA)

                    Dim STATUS_ID As Integer = ddl_status.SelectedItem.Value
                    ' Dim RCVNO As Integer

                    dao.fields.STATUS_ID = STATUS_ID
                    dao.fields.cnccd = 1
                    Try
                        dao.fields.cncdate = CDate(txt_appdate.Text)
                    Catch ex As Exception

                    End Try

                    Dim years As String = ""
                    Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                    dao_tr.GetDataby_IDA(dao.fields.TR_ID)
                    Try
                        years = dao_tr.fields.YEAR

                    Catch ex As Exception

                    End Try
                    Dim tr_id As String = ""
                    tr_id = "DA-" & _ProcessID & "-" & years & "-" & _TR_ID

                    dao.update()
                    Dim result As String = ""
                    'Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                    'result = "APPROVE"
                    'ws_drug.Timeout = 8000
                    Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                    Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                    dao_rg2.GetDataby_IDA(dao.fields.FK_IDA)
                    'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)

                    'KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA,
                    '                                    dao_rg2.fields.IDENTIFY, "", "", "", result, url, _CLS.CITIZEN_ID)

                    Dim cls_sop As New CLS_SOP
                    cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", _ProcessID, _CLS.PVCODE, 8, "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "SOP-DRUG-10-" & _ProcessID & "-13", "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "STAFF", tr_id, SOP_STATUS:="อนุญาตให้แก้ไขเปลี่ยนแปลงฯ")



                    AddLogStatus(8, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                    'update_rgt()
                    alert("อนุมัติคำขอเรียบร้อยแล้ว")
                Else
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถอนุมัติได้ เนื่องจากยังไม่ได้กรอกวันที่อนุมัติ');</script> ")
                End If

            Else
                Dim dao_dem As New DAO_DRUG_DEMO.TB_XML_NAME_TEST
                dao_dem.GetDataby_TR_ID(_TR_ID)
                If dao_dem.fields.IDA <> 0 Then
                    Dim bao As New BAO.GenNumber 'test
                    Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                    dao.GetDatabyIDA(_IDA)

                    Dim STATUS_ID As Integer = ddl_status.SelectedItem.Value
                    ' Dim RCVNO As Integer

                    dao.fields.STATUS_ID = STATUS_ID
                    dao.fields.cnccd = 1
                    Try
                        dao.fields.cncdate = CDate(txt_appdate.Text)
                    Catch ex As Exception

                    End Try

                    Dim years As String = ""
                    Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                    dao_tr.GetDataby_IDA(dao.fields.TR_ID)
                    Try
                        years = dao_tr.fields.YEAR

                    Catch ex As Exception

                    End Try
                    Dim tr_id As String = ""
                    tr_id = "DA-" & _ProcessID & "-" & years & "-" & _TR_ID

                    dao.update()
                    Dim result As String = ""
                    'Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                    'result = "APPROVE"
                    'ws_drug.Timeout = 8000
                    Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                    Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                    dao_rg2.GetDataby_IDA(dao.fields.FK_IDA)
                    'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)

                    'KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA,
                    '                                    dao_rg2.fields.IDENTIFY, "", "", "", result, url, _CLS.CITIZEN_ID)

                    Dim cls_sop As New CLS_SOP
                    cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", _ProcessID, _CLS.PVCODE, 8, "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "SOP-DRUG-10-" & _ProcessID & "-13", "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "อนุญาตให้แก้ไขเปลี่ยนแปลงฯ", "STAFF", tr_id, SOP_STATUS:="อนุญาตให้แก้ไขเปลี่ยนแปลงฯ")



                    AddLogStatus(8, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                    'update_rgt()
                    alert("อนุมัติคำขอเรียบร้อยแล้ว")

                Else
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถอนุมัติได้ ท่านยังไม่ได้ปิดคำขอในระบบปรับปรุงข้อมูล');</script> ")
                End If
            End If


        ElseIf ddl_status.SelectedValue = 15 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                dao.GetDatabyIDA(_IDA)
                'If txt_appdate.Text = "" Then
                '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกวันที่อนุมัติ')</script> ")
                'Else
                dao.fields.STATUS_ID = ddl_status.SelectedValue
                Try
                    dao.fields.cncdate = CDate(txt_appdate.Text)
                Catch ex As Exception

                End Try
                dao.update()
                alert("บันทึกสถานะและวันที่มีผลอนุมัติเรียบร้อยแล้ว")
                'End If

            ElseIf ddl_status.SelectedValue = 14 Then
                'Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                'dao.GetDatabyIDA(_IDA)
                'If txt_appdate.Text = "" Then
                '    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกวันที่อนุมัติ')</script> ")
                'Else
                '    dao.fields.STATUS_ID = ddl_status.SelectedValue
                '    Try
                '        dao.fields.cncdate = CDate(txt_appdate.Text)
                '    Catch ex As Exception

                '    End Try
                '    dao.update()
                '    alert("บันทึกสถานะและวันที่มีผลอนุมัติเรียบร้อยแล้ว")
                'End If
                Response.Redirect("FRM_RGT_EDIT_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)

            ElseIf ddl_status.SelectedValue = 7 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                dao.GetDatabyIDA(_IDA)
                Dim STATUS_ID As Integer = ddl_status.SelectedItem.Value
                dao.fields.STATUS_ID = STATUS_ID
                dao.fields.cnccd = 2
                dao.fields.cncdate = Date.Now
                Try
                    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                dao.update()
                AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                'Response.Redirect("FRM_STAFF_CER_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

                'ElseIf ddl_status.SelectedValue = 4 Then 'คำสั่งอื่น
                '    Response.Redirect("FRM_RGT_EDIT_STAFF_OTHER_ORDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

            Else
                Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            dao.GetDatabyIDA(_IDA)
            Dim STATUS_ID As Integer = ddl_status.SelectedItem.Value
            dao.fields.STATUS_ID = STATUS_ID
            dao.update()

            alert("บันทึกสถานะเรียบร้อยแล้ว")
        End If

    End Sub

    Public Sub update_rgt()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt


        dao.GetDatabyIDA(_IDA)
        dao_lcn.GetDataby_IDA(dao.fields.LCN_IDA)
        dao_drrgt.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        If Len(dao.fields.TR_ID) >= 9 Then
            dao_tr.GetDataby_TR_ID_Process(dao.fields.TR_ID, _ProcessID)
        Else
            dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        End If

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim paths As String = bao._PATH_DEFAULT
        Dim Path_XML As String = paths & "XML_TRADER_UPLOAD" & "\" & NAME_XML("DA", dao_tr.fields.PROCESS_ID, dao_tr.fields.YEAR, dao.fields.TR_ID)


        Dim objStreamReader As New StreamReader(Path_XML)
        Dim p2 As New CLASS_EDIT_DRRGT
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()


        Dim val1 As String = ""
        Dim val2 As String = ""
        Dim val3 As String = ""
        Dim val4 As String = ""
        Dim old_description As String = ""
        Dim new_description As String = ""

        Try 'ขนาดบรรจุ
            val1 = Trim(dao.fields.CHK_TYPE3)
        Catch ex As Exception

        End Try
        Try 'ชื่อยา
            val2 = Trim(dao.fields.CHK_TYPE4)
        Catch ex As Exception

        End Try
        Try 'ลักษณะยา
            val3 = Trim(dao.fields.CHK_TYPE5)
        Catch ex As Exception

        End Try
        Try 'สูตรยา
            val4 = Trim(dao.fields.CHK_TYPE6)
        Catch ex As Exception

        End Try

        Dim a As Object = GEN_XML_EDT_DRRGT_R(Path_XML)
        If val1 <> "" Then
            Dim dao_col As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            Try
                For Each dao_col.fields In p2.DRRGT_PACKAGE_DETAILs
                    new_description &= "ขนาดบรรจุ " & dao_col.fields.PACKAGE_NAME & " " & dao_col.fields.SMALL_AMOUNT & " " & GET_UNIT(dao_col.fields.SMALL_UNIT) & " " & dao_col.fields.MEDIUM_AMOUNT & " " & GET_UNIT(dao_col.fields.MEDIUM_UNIT)
                    Dim i As Integer = 1
                    Dim dao_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                    With dao_pack.fields
                        .BARCODE = dao_col.fields.BARCODE
                        .BIG_AMOUNT = dao_col.fields.BIG_AMOUNT
                        .BIG_UNIT = dao_col.fields.BIG_UNIT
                        .CHECK_PACKAGE = dao_col.fields.CHECK_PACKAGE
                        .DATE_ADD = Date.Now
                        .FK_IDA = dao.fields.FK_IDA
                        .IM_DETAIL = dao_col.fields.IM_DETAIL
                        .IM_QTY = dao_col.fields.IM_QTY
                        .MEDIUM_AMOUNT = dao_col.fields.MEDIUM_AMOUNT
                        .MEDIUM_UNIT = dao_col.fields.MEDIUM_UNIT
                        .order_id = i
                        .PACKAGE_NAME = dao_col.fields.PACKAGE_NAME
                        .SMALL_AMOUNT = dao_col.fields.SMALL_AMOUNT
                        .SMALL_UNIT = dao_col.fields.SMALL_UNIT
                        .SUM = dao_col.fields.SUM

                    End With
                    dao_pack.insert()
                    i += 1

                Next
            Catch ex As Exception

            End Try
            Try
                Dim dao_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                dao_pack.GetDataby_FKIDA(dao.fields.FK_IDA)
                For Each dao_pack.fields In dao_pack.datas
                    old_description &= "ขนาดบรรจุ " & dao_pack.fields.PACKAGE_NAME & " " & dao_pack.fields.SMALL_AMOUNT & " " & GET_UNIT(dao_pack.fields.SMALL_UNIT) & " " & dao_pack.fields.MEDIUM_AMOUNT & " " & GET_UNIT(dao_pack.fields.MEDIUM_UNIT)
                Next
            Catch ex As Exception

            End Try
        End If
        If val2 <> "" Then
            old_description &= " ชื่อยา " & dao_drrgt.fields.thadrgnm & "/" & dao_drrgt.fields.engdrgnm
            new_description &= " ชื่อยา " & dao.fields.DRUG_NAME_TH & "/" & dao.fields.DRUG_NAME_EN
        End If
        If val3 <> "" Then
            new_description &= " ลักษณะของยา " & dao.fields.DRUG_DESCRIPTION
            dao_drrgt.fields.DRUG_COLOR = dao.fields.DRUG_DESCRIPTION
            Dim dao_co As New DAO_DRUG.TB_DRRGT_COLOR
            Try
                For Each dao_co.fields In p2.DRRGT_COLORs
                    new_description &= " สีของยา " & dao_co.fields.COLOR_NAME1 & " " & dao_co.fields.COLOR_NAME2 & " " & dao_co.fields.COLOR_NAME3 & " " & dao_co.fields.COLOR_NAME4
                    Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
                    With dao_color.fields
                        .COLOR_NAME1 = dao_co.fields.COLOR_NAME1
                        .COLOR_NAME2 = dao_co.fields.COLOR_NAME2
                        .COLOR_NAME3 = dao_co.fields.COLOR_NAME3
                        .COLOR_NAME4 = dao_co.fields.COLOR_NAME4
                        .COLOR1 = dao_co.fields.COLOR1
                        .COLOR2 = dao_co.fields.COLOR2
                        .COLOR3 = dao_co.fields.COLOR3
                        .COLOR4 = dao_co.fields.COLOR4
                        .FK_IDA = dao_drrgt.fields.IDA
                    End With
                    dao_color.insert()
                Next
            Catch ex As Exception

            End Try
            Try
                Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
                dao_color.GetDataby_FK_IDA(dao.fields.FK_IDA)
                old_description &= " สีของยา " & dao_color.fields.COLOR_NAME1 & " " & dao_color.fields.COLOR_NAME2 & " " & dao_color.fields.COLOR_NAME3 & " " & dao_color.fields.COLOR_NAME4
            Catch ex As Exception

            End Try
        End If
        If val4 <> "" Then

            Try
                Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                'For Each dao_cas.fields In p2.DRRGT_DETAIL_CASes
                '    new_description &= " สูตรยา " & GET_IOWANM(dao_cas.fields.IOWA) & " " & dao_cas.fields.QTY & " " & GET_UNIT(dao_cas.fields.SUNITCD) & " ชนิดสาร " & dao_cas.fields.AORI & " "

                '    Dim i As Integer = 1
                '    Dim dao_cas2 As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                '    With dao_cas2.fields
                '        .AORI = dao_cas.fields.AORI
                '        .BASE_FORM = dao_cas.fields.BASE_FORM
                '        .CAS_TYPE = dao_cas.fields.CAS_TYPE
                '        .ebioqty = dao_cas.fields.ebioqty
                '        .ebiosqno = dao_cas.fields.ebiosqno
                '        .ebiounitcd = dao_cas.fields.ebiounitcd
                '        .EQTO_IOWA = dao_cas.fields.EQTO_IOWA
                '        .EQTO_QTY = dao_cas.fields.EQTO_QTY
                '        .EQTO_SUNITCD = dao_cas.fields.EQTO_SUNITCD
                '        .FK_IDA = dao_drrgt.fields.IDA
                '        .IOWA = dao_cas.fields.IOWA
                '        .IOWANM = GET_IOWANM(dao_cas.fields.IOWA)
                '        .mltplr = dao_cas.fields.mltplr
                '        .QTY = dao_cas.fields.QTY
                '        .REF = dao_cas.fields.REF
                '        .REMARK = dao_cas.fields.REMARK
                '        .ROWS = i
                '        .sbioqty = dao_cas.fields.sbioqty
                '        .sbiosqno = dao_cas.fields.sbiosqno
                '        .sbiounitcd = dao_cas.fields.sbiounitcd
                '        .SUNITCD = dao_cas.fields.SUNITCD
                '    End With
                '    dao_cas2.insert()
                '    i += 1
                'Next
            Catch ex As Exception

            End Try
            Try
                'Dim dao_cas2 As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                'dao_cas2.GetDataby_FKIDA(dao.fields.FK_IDA)
                'For Each dao_cas2.fields In p2.DRRGT_DETAIL_CASes
                '    old_description &= " สูตรยา " & GET_IOWANM(dao_cas2.fields.IOWA) & " " & dao_cas2.fields.QTY & " " & GET_UNIT(dao_cas2.fields.SUNITCD) & " ชนิดสาร " & dao_cas2.fields.AORI & " "

                'Next
            Catch ex As Exception

            End Try

        End If

        If val2 <> "" Then
            dao_drrgt.fields.engdrgnm = dao.fields.DRUG_NAME_EN
            dao_drrgt.fields.thadrgnm = dao.fields.DRUG_NAME_TH
        End If

        dao_drrgt.update()


        dao.fields.EDIT_OLD_DESCRIPTION = old_description
        dao.fields.EDIT_NEW_DESCRIPTION = new_description
        dao.update()


    End Sub
    Function GET_UNIT(ByVal unit_cd As Integer) As String
        Dim unit_name As String = ""
        Dim dao As New DAO_DRUG.TB_drsunit
        dao.GetDataby_IDA(unit_cd)
        Try
            unit_name = dao.fields.sunitengnm
        Catch ex As Exception

        End Try

        Return unit_name
    End Function
    Function GET_IOWANM(ByVal iowa_cd As String) As String
        Dim iowa_name As String = ""
        Dim dao As New DAO_DRUG.TB_driowa
        dao.GetDataby_iowa(iowa_cd)
        Try
            iowa_name = dao.fields.iowanm
        Catch ex As Exception

        End Try

        Return iowa_name
    End Function
    Function ConvertXML_TO_CLASS(Of T As Class)(ByVal xml As XElement)
        Dim c As T = Nothing
        Try
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            Dim reader = xml.CreateReader
            c = TryCast(serializer.Deserialize(reader), T)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return c
    End Function
    Public Function CLASS_TO_XMLTYPE(ByVal cls_xml As Object)
        Dim mem As New MemoryStream()
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim x As New XmlSerializer(cls_xml.GetType())
        Dim abc As String = ""
        Using writer As XmlWriter = XmlWriter.Create(mem, settings)
            x.Serialize(writer, cls_xml)
            writer.Flush()
            writer.Close()
        End Using
        mem.Position = 0
        Dim sr As New StreamReader(mem)
        Dim xml As String = sr.ReadToEnd
        '----- insert  xml file to parth
        'Dim XML_TRADER As String = ""
        'XML_TRADER = _PATH_FILE & "XML_LOCATION\" & NAME_XML("MDC_MC_XML", 30001, chk_type, con_year, DAO.fields.IDA)   'ทำการกำหนดไฟล์ XML ว่าจะทำการบันทึกลงที่ไหน
        'Dim path As String = XML_TRADER
        'Dim objStreamWriter As New StreamWriter(path)
        'Dim xx As New XmlSerializer(cls_xml.GetType)
        'xx.Serialize(objStreamWriter, cls_xml)
        'objStreamWriter.Close()
        '-------
        Return XElement.Parse(xml)
    End Function

    Public Sub COMPARE_OBJECT(ByVal ob_input As Object, ByVal ob_output As Object, ByVal IDA As Integer,
                                   Optional row As Integer = 0, Optional type_fml As Integer = 0, Optional name_xml As String = "")
        Dim prop_out As System.Reflection.PropertyInfo
        Dim prop_input As System.Reflection.PropertyInfo
        Dim values As String = ""
        'Dim dao_compare As New DAO.TB_CONFIG_COMPARE
        Dim table_name As String = ""
        Dim str_old As String = ""
        Dim str_new As String = ""
        Dim add_analysis As Boolean = False
        Dim analysis_string As String = ""
        Dim edit_product As Boolean = False
        Dim product_string As String = ""
        Dim product_string_old As String = ""
        Dim name_string As String = ""
        Dim name_string_old As String = ""
        Dim purpose_sale As String = ""
        Dim purpose_sale_OLD As String = ""
        Dim cnt_name As String = ""
        Dim cnt_name_old As String = ""
        Dim str_cer As String = ""
        Dim str_cer_Old As String = ""
        Dim edit_cf As Boolean = False
        Try
            table_name = ob_input.GetType.Name
        Catch ex As Exception

        End Try

        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(_IDA)
        Dim val1 As String = ""
        Dim val2 As String = ""
        Dim val3 As String = ""
        Dim val4 As String = ""

        Try 'ขนาดบรรจุ
            val1 = Trim(dao.fields.CHK_TYPE3)
        Catch ex As Exception

        End Try
        Try 'ชื่อยา
            val2 = Trim(dao.fields.CHK_TYPE4)
        Catch ex As Exception

        End Try
        Try 'ลักษณะยา
            val3 = Trim(dao.fields.CHK_TYPE5)
        Catch ex As Exception

        End Try
        Try 'สูตรยา
            val4 = Trim(dao.fields.CHK_TYPE6)
        Catch ex As Exception

        End Try
        For Each prop_out In ob_output.GetType.GetProperties()
            Dim name_out As String = prop_out.Name
            For Each prop_input In ob_input.GetType.GetProperties()

                Dim name_in As String = prop_input.Name

                If name_in = name_out Then
                    Dim values_input As Object = prop_input.GetValue(ob_input)
                    Dim values_output As Object = prop_out.GetValue(ob_output)
                    If val1 <> "" Then
                        If name_in.Contains("DRRGT_PACKAGE_DETAIL") Then
                            'If Trim(values_input) <> "" Then
                            'If values_input.GetType. <> "" Then
                            '    product_string &= "ขนาดบรรจุ " & " " & values_input.GetType.Name("PACKAGE_NAME").ToString
                            'End If
     
                            For Each val_in In values_input

                                'If val_in.GetIndexParameters().Length = 0 Then
                                'Console.WriteLine("   {0} ({1}): {2}", val_in.Name, val_in.PropertyType.Name, val_in.GetValue(values_input))
                                'Else
                                '    Console.WriteLine("   {0} ({1}): <Indexed>", val_in.Name, val_in.PropertyType.Name)
                                'End If
                            Next




                            'If Trim(values_output) <> "" Then
                            '    product_string_old &= "ขนาดบรรจุ " & " " & values_output
                            'End If
                        End If
                    ElseIf val2 <> "" Then
                        If name_in.Contains("drrgts") Then
                            If Trim(values_input) <> "" Then
                                product_string &= "ชื่อยา " & " " & values_input
                            End If
                            If Trim(values_output) <> "" Then
                                product_string_old &= "ชื่อยา " & " " & values_output
                            End If
                        End If
                    End If
                    '            dao_compare.GetDataby_T_NAME(table_name)
                    '            For Each dao_compare.fields In dao_compare.datas
                    '                If dao_compare.fields.field_name = name_in Then
                    '                    Try
                    '                        Dim values_input As Object = prop_input.GetValue(ob_input)
                    '                        Dim values_output As Object = prop_out.GetValue(ob_output)
                    '                        'ปริมาณผลิตภัณฑ์ XX กรัม | ปริมาณของเหลว  XX มิลลิตร | ทำละลายในของเหลวได้แก่ xxx | โดยมีค่าความถ่วงจำเพาะเท่ากับ
                    '                        If dao_compare.fields.OBJECT_CD = 11 Then 'เก็บปริมาณของเหลว
                    '                            If dao_compare.fields.SUB_OBJECT_CD = 1 Then
                    '                                If values_input <> "" Then
                    '                                    product_string &= " " & dao_compare.fields.DESCRIPTION & " " & values_input & " กรัม"
                    '                                End If
                    '                                If values_output <> "" Then
                    '                                    product_string_old &= " " & dao_compare.fields.DESCRIPTION & " " & values_output & " กรัม"
                    '                                End If
                    '                            ElseIf dao_compare.fields.SUB_OBJECT_CD = 2 Then
                    '                                If values_input <> "" Then
                    '                                    product_string &= " " & dao_compare.fields.DESCRIPTION & " " & values_input & " มิลลิลิตร"
                    '                                End If
                    '                                If values_output <> "" Then
                    '                                    product_string_old &= " " & dao_compare.fields.DESCRIPTION & " " & values_output & " มิลลิลิตร"
                    '                                End If
                    '                            ElseIf dao_compare.fields.SUB_OBJECT_CD = 3 Then
                    '                                If values_input <> "" Then
                    '                                    product_string &= " ทำละลายในของเหลวได้แก่" & values_input
                    '                                End If
                    '                                If values_output <> "" Then
                    '                                    product_string_old &= " ทำละลายในของเหลวได้แก่" & values_output
                    '                                End If
                    '                            ElseIf dao_compare.fields.SUB_OBJECT_CD = 4 Then
                    '                                If values_input <> "" Then
                    '                                    product_string &= " โดยมีค่าความถ่วงจำเพาะเท่ากับ" & values_input
                    '                                End If
                    '                                If values_output <> "" Then
                    '                                    product_string_old &= " โดยมีค่าความถ่วงจำเพาะเท่ากับ" & values_output
                    '                                End If
                    '                            End If
                    '                        ElseIf dao_compare.fields.OBJECT_CD = 1 Then 'เก็บชื่อ
                    '                            If values_input <> "" Then
                    '                                name_string &= "/" & values_input
                    '                            End If
                    '                            If values_output <> "" Then
                    '                                name_string_old &= "/" & values_output
                    '                            End If
                    '                        ElseIf dao_compare.fields.OBJECT_CD = 5 Then 'เก็บชื่อ
                    '                            If values_input <> 0 Then
                    '                                purpose_sale &= "," & dao_compare.fields.DESCRIPTION
                    '                            End If
                    '                            If values_output <> 0 Then
                    '                                purpose_sale_OLD &= "," & dao_compare.fields.DESCRIPTION
                    '                            End If
                    '                        ElseIf dao_compare.fields.OBJECT_CD = 4 Then
                    '                            If values_input <> "" Then
                    '                                cnt_name &= "/" & values_input
                    '                            End If
                    '                            If values_output <> "" Then
                    '                                cnt_name_old &= "/" & values_output
                    '                            End If
                    '                        ElseIf dao_compare.fields.OBJECT_CD = 3 And dao_compare.fields.SUB_OBJECT_CD = 2 Then
                    '                            If values_input <> "" Then
                    '                                str_cer &= " " & values_input
                    '                            End If
                    '                            If values_output <> "" Then
                    '                                str_cer_Old &= " " & values_output
                    '                            End If
                    '                        Else
                    '                            If values_input <> values_output Then
                    '                                If dao_compare.fields.OBJECT_CD = 9 Then 'แก้รายงานผลวิเคราะห์
                    '                                    If dao_compare.fields.SUB_OBJECT_CD = 1 Then
                    '                                        analysis_string &= values_input
                    '                                        add_analysis = True
                    '                                    ElseIf dao_compare.fields.SUB_OBJECT_CD = 2 Then
                    '                                        analysis_string &= "    " & dao_compare.fields.DESCRIPTION & " " & values_input
                    '                                        add_analysis = True
                    '                                    ElseIf dao_compare.fields.SUB_OBJECT_CD = 3 Then
                    '                                        Dim d As Date = CDate(values_input)
                    '                                        Dim bao_date As New BAO.Function_Date
                    '                                        Try
                    '                                            analysis_string &= "    " & dao_compare.fields.DESCRIPTION & " " & d.Day & " " & bao_date.convert_month_thai(d.Month) & " " & bao_date.Convert_Year(d.Year)
                    '                                        Catch ex As Exception
                    '                                        End Try
                    '                                        add_analysis = True
                    '                                    End If
                    '                                ElseIf dao_compare.fields.OBJECT_CD = 7 Then 'แก้ ข้อมูลcf
                    '                                    edit_cf = True
                    '                                Else
                    '                                    Dim dao_edit As New DAO.TB_FREGNTF_EDIT_DETAILS
                    '                                    If values_output = "" Then
                    '                                        values = "เพิ่ม"
                    '                                        dao_edit.fields.EDIT_REMARK = "ขอ" & values & dao_compare.fields.DESCRIPTION & " เป็น " & values_input
                    '                                    ElseIf values_input = "" Then
                    '                                        values = "ยกเลิก"
                    '                                        dao_edit.fields.EDIT_REMARK = "ขอ" & values & dao_compare.fields.DESCRIPTION & " " & values_output
                    '                                    Else
                    '                                        values = "แก้ไข"
                    '                                        dao_edit.fields.EDIT_REMARK = "ขอ" & values & dao_compare.fields.DESCRIPTION & " จากเดิมเป็น " & values_input
                    '                                    End If
                    '                                    With dao_edit.fields
                    '                                        .FK_IDA = IDA
                    '                                        .DES_OLD = values_output
                    '                                        .DES_NEW = values_input
                    '                                        .EDIT_DESCRIPTION = values & dao_compare.fields.DESCRIPTION
                    '                                        .ACTIVE = 1
                    '                                        .OBJ_CD = dao_compare.fields.OBJECT_CD
                    '                                    End With
                    '                                    dao_edit.insert()
                    '                                End If
                    '                            End If
                    '                        End If
                    '                        Exit For
                    '                    Catch ex As Exception
                    '                        Exit For
                    '                    End Try
                    '                End If
                    '            Next
                End If
            Next
        Next
        'If name_string <> name_string_old Then
        '    INSERT_EDIT_DETAIL(IDA, name_string_old.Substring(1), name_string.Substring(1), "แก้ไขชื่ออาหาร", "ขอแก้ไขชื่ออาหาร จากเดิมเป็น " & name_string.Substring(1), 1)
        'End If 'ชื่ออาหารที่รวมแล้ว
        'If add_analysis = True Then
        '    Dim str As String = ""
        '    If row = 1 Then
        '        str = "รายงานผลการตรวจวิเคราะห์อาหาร"
        '    ElseIf row = 2 Then
        '        str = "รายงานผลการตรวจวิเคราะห์สารอาหาร"
        '    ElseIf row = 3 Then
        '        str = "รายงานผลการตรวจวิเคราะห์ภาชนะบรรจุ"
        '    End If
        '    INSERT_EDIT_DETAIL(IDA, "", analysis_string, "เพิ่ม" & str, "ขอเพิ่ม" & str & analysis_string, 9, row)
        'End If
        'If product_string <> product_string_old = True Then
        '    INSERT_EDIT_DETAIL(IDA, product_string_old.Substring(1), product_string.Substring(1),
        '                       "แก้ไขวิธีการเตรียมผลิตภัณฑ์", "ขอแก้ไขวิธีการเตรียมผลิตภัณฑ์ จากเดิมเป็น " & product_string.Substring(1), 11)
        'End If
        'If edit_cf = True Then
        '    Dim dao_edit As New DAO.TB_FREGNTF_EDIT_DETAILS
        '    dao_edit.GetDataby_FK_IDA_OBJ_TYPE(IDA, 7) 'เช็คว่า insert รึยัง
        '    If dao_edit.fields.IDA = 0 Then
        '    Else
        '        INSERT_EDIT_DETAIL(IDA, "", "", "แก้ไขแบบฟอร์มการประเมิณวัตถุเจือปนอาหารฯ", "ขอแก้ไขแบบฟอร์มการประเมิณวัตถุเจือปนอาหารฯ", 7)
        '    End If
        'End If
        'If purpose_sale <> purpose_sale_OLD Then
        '    INSERT_EDIT_DETAIL(IDA, purpose_sale_OLD.Substring(1), purpose_sale.Substring(1), "แก้ไขจุดประสงค์การจำหน่าย", "แก้ไขจุดประสงค์การจำหน่ายจากเดิมเป็น " & purpose_sale.Substring(1), 5)
        'End If
        'If cnt_name <> cnt_name_old Then
        '    INSERT_EDIT_DETAIL(IDA, cnt_name_old.Substring(1), cnt_name.Substring(1), "แก้ไขประเทศส่งออก", "ขอแก้ไขประเทศส่งออก จากเดิมเป็น " & cnt_name.Substring(1), 4)
        'End If
        'If str_cer <> str_cer_Old Then
        '    INSERT_EDIT_DETAIL(IDA, str_cer_Old.Substring(1), str_cer.Substring(1), "แก้ไขที่ตั้งผู้ผลิตอาหาร", "ขอแก้ไขที่ตั้งผู้ผลิตอาหาร จากเดิมเป็น" & str_cer.Substring(1), 3)
        'End If
    End Sub

    Private Function GET_OLD_DATA(ByVal ida As Integer) As CLASS_DR
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim lcnno As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim tr_id As String= 0
        Dim IDA_regist As Integer = 0
        Dim lcnsid As Integer = 0
        Dim lcntpcd As String = ""
        Dim appdate As Date
        Dim pvnabbr As String = ""
        Dim dsgcd As String = ""
        Dim STATUS_ID As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""

        Try
            STATUS_ID = Request.QueryString("status") 'Get_drrqt_Status(_IDA)
        Catch ex As Exception

        End Try

        Dim class_xml As New CLASS_DR

        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(ida)
        Try
            class_xml.drrgts = dao.fields
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        lcnno = dao.fields.lcnno
        Try
            TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
        Catch ex As Exception

        End Try
        Try
            TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
        Catch ex As Exception

        End Try
        Try
            CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
        Catch ex As Exception

        End Try
        Try
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
        Try
            dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
        Catch ex As Exception

        End Try

        Try
            IDA_regist = dao_rq.fields.FK_IDA
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao.fields.lcnsid
        Catch ex As Exception

        End Try

        DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
        pvncd = dao.fields.pvncd
        rgttpcd = dao.fields.rgttpcd
        dsgcd = dao.fields.dsgcd
        Try
            STATUS_ID = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try

        Try
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = dao.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            appdate = dao.fields.appdate
        Catch ex As Exception

        End Try
        pvnabbr = dao.fields.pvnabbr
        Try
            drug_name_th = dao.fields.thadrgnm
            'drug_name
        Catch ex As Exception
            drug_name_th = "-"
        End Try
        Try
            drug_name_eng = dao.fields.engdrgnm
        Catch ex As Exception
            drug_name_eng = "-"
        End Try


        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(IDA_regist)
        Catch ex As Exception

        End Try

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(dao_re.fields.FK_IDA)
            lcntpcd = dao_lcn.fields.lcntpcd
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        Dim _process As Integer = 0
        Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            If Len(_TR_ID) >= 9 Then
                dao_tr.GetDataby_TR_ID_Process(_TR_ID, _ProcessID)
            Else
                dao_tr.GetDataby_IDA(_TR_ID)
            End If
            _process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try


        Try
            class_xml.DRUG_STRENGTH = DRUG_STRENGTH
        Catch ex As Exception

        End Try
        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            dao_dos.GetDataby_cd(dsgcd)

        Catch ex As Exception

        End Try
        Try
            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(ida)
            class_xml.DRRGT_COLORs = dao_color.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(ida)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(ida)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try

        class_xml.Dossage_form = dao_dos.fields.thadsgnm
        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try
        Try
            pvncd = pvncd
        Catch ex As Exception
            pvncd = ""
        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try



        If IsNothing(appdate) = False Then
            Dim appdate2 As Date
            If Date.TryParse(appdate, appdate2) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        If pvncd <> "" Then
            If pvncd <> "10" Then
                rgtno_format &= " " & "(" & pvncd & ")"
            End If
        End If
        'Try
        '    If Len(rgtno_auto) > 0 Then
        '        rgtno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try
        Try
            If Len(lcnno_auto) > 0 Then
                lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        If drug_name_th = "-" Then
            drug_name = drug_name_eng
        Else
            drug_name = drug_name_th
            If drug_name_eng <> "-" Then
                drug_name = drug_name_th & " / " & drug_name_eng

            End If
        End If

        'drug_name = drug_name_th & "/" & drug_name_eng
        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ประเทศไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2

        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_lcn.fields.CITIZEN_ID_AUTHORIZE, dao_lcn.fields.lcnsid) 'ข้อมูลบริษัท
        'Try
        '    Dim dt_temp As New DataTable
        '    dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao.fields.FK_LCN_IDA) 'ผู้ดำเนิน

        '    class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
        '    'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        'Catch ex As Exception

        'End Try


        Dim dao_det_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
        dao_det_prop.GetDataby_FK_IDA(ida)
        Try
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
        Catch ex As Exception

        End Try

        Dim dt_pack As New DataTable
        Dim bao_pack As New BAO_SHOW
        dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(ida)
        Try
            PACK_SIZE = dt_pack(0)("contain_detail")
            class_xml.PACK_SIZE = PACK_SIZE
        Catch ex As Exception

        End Try
        Try
            Dim dao_dpn As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
            dao_dpn.GetDataby_FKIDA(ida)
            class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
        Catch ex As Exception

        End Try
        'class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(ida) 'ขนาดบรรจุ
        '    class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
        'class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(ida) 'ATC
        'class_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(ida) 'สารสำคัญ/ส่วนประกอบ(รวม)
        '    class_xml.DT_SHOW.DT10.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
        'class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(ida) 'สรรพคุณ
        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(ida) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        '    'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_DATA(ida)

        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(ida, 1)
        '    class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(ida, 2)
        '    class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(ida, 3)
        '    class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

        '    class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
        '    class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        'class_xml.DT_SHOW.DT23 = bao_show.SP_drrgt_cas(ida)
        '    class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        'class_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(ida, 9, LCNTPCD_GROUP)
        '    class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
        'class_xml.DT_SHOW.DT23 = bao_show.SP_DRRGT_CAS_EQTO(ida)
        '    class_xml.DT_SHOW.DT23.TableName = "SP_regis"

        Dim lcntype As String = "0" 'dao.fields.lcntpcd


        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_process)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        p_dr = class_xml

        Return class_xml
    End Function

    'Sub GEN_TR_ID(ByVal ida As Integer, ByVal CITIZEN_ID_AUTHORIZE As String)
    '    Dim TR_ID As String = ""
    '    Dim _ProcessID As String = ""
    '    Dim bao_tran As New BAO_TRANSECTION
    '    Dim dao As New DAO_DRUG.ClsDBdrrgt
    '    Try
    '        dao.GetDataby_IDA(ida)
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
    '    Catch ex As Exception
    '        bao_tran.CITIZEN_ID = ""
    '    End Try
    '    Try
    '        bao_tran.CITIZEN_ID_AUTHORIZE = CITIZEN_ID_AUTHORIZE
    '    Catch ex As Exception
    '        bao_tran.CITIZEN_ID_AUTHORIZE = ""
    '    End Try
    '    Try
    '        _ProcessID = dao.fields.PROCESS_ID
    '    Catch ex As Exception

    '    End Try

    '    TR_ID = bao_tran.insert_transection_new(_ProcessID)
    '    dao.fields.TR_ID = TR_ID
    '    dao.update()
    'End Sub

    Private Sub btn_send_edit_Click(sender As Object, e As EventArgs) Handles btn_send_edit.Click
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(Request.QueryString("IDA"))
        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        Try

            dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Try
            ' Response.Redirect("https://medicina.fda.moph.go.th/FDA_DRUG_AN/AUTHEN/AUTHEN_GATEWAY?Token=" & _CLS.TOKEN & "&trid=" & dao.fields.TR_ID & "&Newcode=" & Request.QueryString("Newcode") & "&citizen_authen=" & dao_rg.fields.IDENTIFY)

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('https://medicina.fda.moph.go.th/FDA_DRUG_AN/AUTHEN/AUTHEN_GATEWAY?Token=" & _CLS.TOKEN & "&trid=" & dao.fields.TR_ID & "&Newcode=" & Request.QueryString("Newcode") & "&citizen_authen=" & dao_rg.fields.IDENTIFY & "'); ", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao_lcn As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB 'DAO_DRUG.ClsDBdalcn
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        Dim dao_drrgt As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB 'DAO_DRUG.ClsDBdrrgt

        dao.GetDatabyIDA(_IDA)

        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
        Dim tr_id_rg As Integer = 0
        Dim r_IDA As Integer = 0
        Try
            r_IDA = dao_rg.fields.IDA

        Catch ex As Exception

        End Try
        Try
            tr_id_rg = dao_rg.fields.TR_ID
        Catch ex As Exception

        End Try

        'Dim drgtpcd_edt As String = ""

        'Try
        '    drgtpcd_edt = dao.fields.drgtpcd
        'Catch ex As Exception

        'End Try

        'Try
        '    'dao_drrgt.GetDataby_IDA_drrgt(dao.fields.FK_IDA)
        '    dao_drrgt.GetDataby_4Key(dao_rg.fields.rgtno, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.pvncd)
        'Catch ex As Exception

        'End Try

        'Try
        '    dao_lcn.GetDataby_u1(dao_drrgt.fields.Newcode_not)
        'Catch ex As Exception

        'End Try



        Response.Redirect("../TABEAN_YA/FRM_RQT_EDIT_V2.aspx?IDA=" & r_IDA & "&TR_ID=" & tr_id_rg & "&STATUS_ID=8&ida_e=" & Request.QueryString("IDA") & "&Newcode=" & Request.QueryString("Newcode") & "&e=1")
    End Sub
End Class