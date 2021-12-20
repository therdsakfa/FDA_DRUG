Public Class FRM_SUBSTITUTE_TABEAN_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        _YEARS = con_year(Date.Now.Year)
        Try
            _ProcessID = Request.QueryString("Process")

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
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            txt_appdate.Text = Date.Now.ToShortDateString()
            BindData_PDF()
            'bind_ddl_rqt()
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)

            Dim dao_a As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            dao_a.GetDatabyIDA(_IDA)
            If dao_a.fields.STATUS_ID <> 8 Then
                Bind_ddl_Status_staff()
            Else
                ddl_cnsdcd.Enabled = False
            End If
            Try
                If dao_a.fields.STATUS_ID = 8 Then
                    Panel1.Style.Add("display", "block")
                Else
                    Panel1.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
            Try
                txt_sending_date.Text = CDate(dao_a.fields.SENDING_DATE).ToShortDateString()
            Catch ex As Exception

            End Try
            Try
                If dao_a.fields.SENDING_STATUS = 1 Then
                    cb_sending.Checked = True
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
    Sub show_btn(ByVal ID As String)

        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)
        If dao.fields.STATUS_ID = 8 Or dao.fields.STATUS_ID = 7 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl1 As Integer = 0
        Dim int_group_ddl2 As Integer = 0
        Dim status_id1 As Integer = 0
        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        Try
            dao_sub.GetDatabyIDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        Try
            status_id1 = dao_sub.fields.STATUS_ID
        Catch ex As Exception

        End Try

        If status_id1 = 2 Then
            int_group_ddl1 = 1
            int_group_ddl2 = 0
        ElseIf status_id1 = 3 Then
            int_group_ddl1 = 2
            int_group_ddl2 = 0
        ElseIf status_id1 = 5 Then
            int_group_ddl1 = 3
            int_group_ddl2 = 0
        End If

        dt = Get_DDL_DATA(12, int_group_ddl1, int_group_ddl2)

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME_STAFF"
        ddl_cnsdcd.DataBind()
    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function
    Private Sub BindData_PDF()
        RunQuery()
        Dim bao_show As New BAO_SHOW
        Dim bao_mas As New BAO_MASTER
        Dim cls As New CLASS_GEN_XML.DRRGT_SUB(_CLS.CITIZEN_ID, _CLS.LCNSID, "1", _CLS.PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRGT_SUB                                                                 ' ประกาศตัวแปรจาก CLASS_DALCN 
        'cls_xml = cls.gen_xml()



        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        Try
            dao_sub.GetDatabyIDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        dao_drrgt.GetDataby_IDA(dao_sub.fields.FK_IDA)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(dao_sub.fields.FK_LCN_IDA)
        Catch ex As Exception

        End Try
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
        Dim lcnno As String = ""
        Dim lcnsid As String = ""
        Try
            rcvno_auto = dao_sub.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_drrgt.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao_sub.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_drrgt.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao_drrgt.fields.lcnsid
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
            If dao_drrgt.fields.lcntpcd.Contains("ผยบ") Or dao_drrgt.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao_drrgt.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                If rcvno_auto <> "0" Then
                    rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) 'rgttpcd & " " &
                End If

            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/25" & Left(dao.fields.lcnno, 2)
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
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                cls_xml.TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                cls_xml.TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_dg As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
            dao_dg.GetDataby_rgttpcd(dao_drrgt.fields.rgttpcd)
            cls_xml.CHK_LCN_SUBTYPE = dao_dg.fields.subtpcd
        Catch ex As Exception

        End Try
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.RCVNO_FORMAT = rcvno_format
        cls_xml.RGTNO_FORMAT = rgtno_format



        cls_xml.DRUG_NAME = drug_name        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml

        '------------------SHOW
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        If Request.QueryString("identify") <> "" Then
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(Request.QueryString("identify"), _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        Else
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_sub.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        End If
        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao.fields.IDA) 'ผู้ดำเนิน
        Catch ex As Exception

        End Try
        cls_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
        cls_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        cls_xml.DRRGT_SUBSTITUTEs = dao_sub.fields
        p_DRRGT_SUBSTITUTE = cls_xml

        Dim statusId As Integer = dao_sub.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)
        dao_pdftemplate.GetDataby_TEMPLAETE_TABEAN(_ProcessID, statusId, 0)
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

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer = 0
        Dim PROCESS_ID As Integer
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            PROCESS_ID = dao_up.fields.PROCESS_ID

            Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
            dao_date.fields.FK_IDA = _IDA
            Try
                dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
            dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            dao_date.fields.DATE_NOW = Date.Now
            dao_date.fields.PROCESS_ID = PROCESS_ID
        dao_date.insert()

        If STATUS_ID = 3 Then
            'dao.fields.STATUS_ID = STATUS_ID
            'Dim bao2 As New BAO.GenNumber
            'RCVNO = bao2.GEN_NO_07(con_year(Date.Now.Year), _CLS.PVCODE, IIf(IsDBNull(dao.fields.lcnno), "", dao.fields.lcnno), PROCESS_ID, 0, 0, _IDA, "")
            'dao.fields.rcvno = RCVNO
            'Try
            '    dao.fields.rcvdate = txt_appdate.Text
            'Catch ex As Exception

            'End Try
            dao.fields.STATUS_ID = STATUS_ID
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)

            Try
                dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.STATUS_ID = STATUS_ID
            dao.update()
            AddLogStatus(3, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        ElseIf STATUS_ID = 5 Then
            Response.Redirect("FRM_SUBSTITUTE_TABEAN_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & PROCESS_ID)

        ElseIf STATUS_ID = 8 Then
            dao.fields.appdate = CDate(txt_appdate.Text)
            dao.fields.STATUS_ID = STATUS_ID
            dao.update()
            AddLogStatus(8, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            alert("ดำเนินการอนุมัติแล้ว")
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "'); parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_save_sending_Click(sender As Object, e As EventArgs) Handles btn_save_sending.Click
        Dim dao_a As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao_a.GetDatabyIDA(_IDA)
        Try
            dao_a.fields.SENDING_DATE = CDate(txt_sending_date.Text)
        Catch ex As Exception

        End Try
        Try
            If cb_sending.Checked = True Then
                dao_a.fields.SENDING_STATUS = 1
            Else
                dao_a.fields.SENDING_STATUS = 0
            End If
        Catch ex As Exception

        End Try

        AddLogStatus(88, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        dao_a.update()
        Response.Write("<script type='text/javascript'>alert('บันทึกการจ่ายใบสำคัญแล้ว');</script> ")
    End Sub
End Class