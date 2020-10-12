﻿Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports System.Globalization

Public Class FRM_NYM_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try

        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'txt_app_date.Text = Date.Now.ToShortDateString()
            HiddenField2.Value = 0
            If _ProcessID = "1026" Then
                BindData_PDF2()
            Else    'If _ProcessID = "1030" Then
                Binddata_NYM()
                'Else
                '    BindData_PDF()
            End If
            Bind_ddl_Status_staff()
            load_fdpdtno()
            'UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv(_TR_ID)
            set_hide(_IDA)

            'Try
            '    Dim dao As New DAO_DRUG.ClsDBdrsamp
            '    dao.GetDataby_IDA(_IDA)
            '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            '    dao_up.GetDataby_IDA(dao.fields.TR_ID)
            '    If dao_up.fields.PROCESS_ID = "1027" Or dao_up.fields.PROCESS_ID = "1028" Or dao_up.fields.PROCESS_ID = "1029" Then
            '        btn_drug_group.Style.Add("display", "block")
            '    End If
            'Catch ex As Exception

            'End Try


        End If
        set_lbl()
        show_btn(_IDA)
    End Sub

    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(ID)

        If dao.fields.STATUS_ID <> 6 Then
            btn_preview.Enabled = False
            ' btn_cancel.Enabled = False
            btn_preview.CssClass = "btn-danger btn-lg"
            'btn_preview.CssClass = "btn-danger btn-lg"

        End If


    End Sub
    ''' <summary>
    ''' เปิด/ปิด เมนูด้านข้าง
    ''' </summary>
    ''' <param name="IDA"></param>
    Public Sub set_hide(ByVal IDA As String)
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 6 Then
                remark_box.Style.Add("display", "block")
            End If
        Else
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(IDA)
            If dao.fields.STATUS_ID = 8 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                ddl_cnsdcd.Style.Add("display", "none")
            ElseIf dao.fields.STATUS_ID = 6 Then
                remark_box.Style.Add("display", "block")
            End If
        End If




        'Try
        '    Dim dao_u As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        '    dao_u.GetDataby_IDA(_TR_ID)
        '    If dao_u.fields.PROCESS_ID = "104" Then
        '        ddl_template.Style.Add("display", "block")
        '    End If
        'Catch ex As Exception

        'End Try



    End Sub
    ''' <summary>
    ''' นำข้อมูลมาใส่ใน label
    ''' </summary>
    Sub set_lbl()

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(_IDA)

            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            Try    'ชื่อผู้ลงนาม
                dao_s.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
                lbl_staff_consider.Text = dao_s.fields.STAFF_OFFER_NAME
            Catch ex As Exception
                lbl_staff_consider.Text = "-"
            End Try

            Try
                lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
            Catch ex As Exception
                lbl_app_date.Text = "-"
            End Try

            Try    ' วันที่เสนอลงนาม
                lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_consider_date.Text = "-"
            End Try

            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 5)
                lbl_Status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception

            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)

            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            Try    'ชื่อผู้ลงนาม
                dao_s.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
                lbl_staff_consider.Text = dao_s.fields.STAFF_OFFER_NAME
            Catch ex As Exception
                lbl_staff_consider.Text = "-"
            End Try

            Try
                lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
            Catch ex As Exception
                lbl_app_date.Text = "-"
            End Try

            Try    ' วันที่เสนอลงนาม
                lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
            Catch ex As Exception
                lbl_consider_date.Text = "-"
            End Try

            Try
                dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 5)
                lbl_Status.Text = dao_stat.fields.STATUS_NAME
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub load_fdpdtno()
        Dim bao As New BAO.ClsDBSqlcommand
        'lbl_fdpdtno.Text = get_fdpdtno().Substring(0, 2) & "-" & get_fdpdtno().Substring(2, 1) & "-" & get_fdpdtno().Substring(3, 5) & "-" & get_fdpdtno().Substring(8, 1) & "-"
        'lbl_fdpdtno2.Text = _CLS.IDA    'ปรับให้runno

    End Sub
    Function get_fdpdtno() As String
        Dim fdpdtno As String = String.Empty
        Dim pvncd As String = String.Empty
        Dim lcntypecd As String = String.Empty
        Dim lcnno_num As String = String.Empty
        Dim tpye As String = String.Empty
        Dim REF_NO As String = String.Empty
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim bao As New BAO.ClsDBSqlcommand
        dao_up.GetDataby_IDA(_CLS.IDA)
        REF_NO = dao_up.fields.REF_NO
        dao.GetDataby_IDA(_CLS.IDA)
        pvncd = dao.fields.pvncd.ToString()
        lcntypecd = dao.fields.lcntpcd.ToString()
        lcnno_num = dao.fields.lcnno.ToString().Trim().Substring(2, 5)
        If _CLS.PVCODE = 10 Then
            If lcntypecd = "1" Then
                tpye = "1"
            ElseIf lcntypecd = "2" Then
                tpye = "3"
            End If
        Else
            If lcntypecd = "1" Then
                tpye = "2"
            ElseIf lcntypecd = "2" Then
                tpye = "4"
            End If
        End If
        fdpdtno = pvncd & lcntypecd & lcnno_num & tpye
        Return fdpdtno
    End Function

    ''' <summary>
    ''' กดยืนยัน
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click


        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim bao As New BAO.GenNumber
        Dim dao_prf As New DAO_DRUG.ClsDB_nym_proof
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As Integer


        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            dao_prf.GetDataby_FK(dao.fields.IDA)
            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

            dao_date.fields.FK_IDA = _IDA
            Try
                dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
            dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            dao_date.fields.DATE_NOW = Date.Now
            dao_date.fields.PROCESS_ID = 0
            dao_date.insert()


            If STATUS_ID = 3 Then
                dao.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
                ' dao.fields.rcvr_id = _CLS.CITIZEN_ID

                dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao.fields.DATE_RCV = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
                dao.fields.DATE_RCV = Date.Now.ToShortDateString()
                dao.update()

                dao_prf.fields.RCV_NO = RCVNO
                dao_prf.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                '--------------------------------
                alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
            ElseIf STATUS_ID = 6 Then
                Response.Redirect("FRM_STAFF_NYM_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)
            ElseIf STATUS_ID = 8 Then

                dao.fields.STATUS_ID = STATUS_ID
                dao.fields.appdate = Date.Now.ToShortDateString()
                dao.fields.REMARK = txt_REMARK.Text
                dao_prf.fields.RCV_DATE = Date.Now
                If _ProcessID = "1028" Then
                    dao_prf.fields.SENT_DATE = dao.fields.CONSIDER_DATE
                    'Else
                    '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
                End If
                dao_prf.update()

                package()

                dao.update()
                alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")

            ElseIf STATUS_ID = 7 Then
                Response.Redirect("FRM_STAFF_NYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                '_TR_ID = Request.QueryString("TR_ID")
                '_IDA = Request.QueryString("IDA")
                'dao.update()
                'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            End If
        Else
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            dao_prf.GetDataby_FK(dao.fields.IDA)

            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
            dao_date.fields.FK_IDA = _IDA
            Try
                dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
            dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            dao_date.fields.DATE_NOW = Date.Now
            dao_date.fields.PROCESS_ID = 0
            dao_date.insert()


            If STATUS_ID = 3 Then
                dao.fields.STATUS_ID = STATUS_ID
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
                dao.fields.rcvr_id = _CLS.CITIZEN_ID

                dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
                Try
                    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try
                dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
                dao.update()

                dao_prf.fields.RCV_NO = RCVNO
                dao_prf.update()
                '-----------------ลิ้งไปหน้าคีย์มือ----------
                'Response.Redirect("FRM_STAFF_NYM_RCV_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                '--------------------------------
                alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
            ElseIf STATUS_ID = 6 Then
                Response.Redirect("FRM_STAFF_NYM_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
            ElseIf STATUS_ID = 8 Then

                dao.fields.STATUS_ID = STATUS_ID
                dao.fields.appdate = Date.Now.ToShortDateString()
                dao.fields.REMARK = txt_REMARK.Text
                dao_prf.fields.RCV_DATE = Date.Now
                If _ProcessID = "1028" Then
                    dao_prf.fields.SENT_DATE = dao.fields.event_end
                    'Else
                    '    dao_prf.fields.SENT_DATE = Date.Now 'นยม4ต้องรับวันที่นำเข้ามาจาก LPI
                End If
                dao_prf.update()

                package()

                dao.update()
                alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")

            ElseIf STATUS_ID = 7 Then
                Response.Redirect("FRM_STAFF_NYM_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&precess=" & _ProcessID)
                AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
                '_TR_ID = Request.QueryString("TR_ID")
                '_IDA = Request.QueryString("IDA")
                'dao.update()
                'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            End If
        End If




    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")

        Dim dao_n As New DAO_DRUG.ClsDBdalcn
        dao_n.GetDataby_IDA(_IDA)
        Try
            If dao_n.fields.SEND_POST = 1 Then
                '  Label2.Text = "รับด้วยตัวเอง"
            ElseIf dao_n.fields.SEND_POST = 2 Then
                '   Label2.Text = "ส่งไปรษณีย์"
            Else
                '   Label2.Text = "รับด้วยตัวเอง"
            End If
        Catch ex As Exception

        End Try

        Bind_ddl_Status_staff()
        BindData_PDF()
    End Sub

    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        If _ProcessID = 1026 Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            If dao.fields.STATUS_ID <= 2 Then
                int_group_ddl = 1
            ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
                int_group_ddl = 2
            ElseIf dao.fields.STATUS_ID >= 6 Then
                int_group_ddl = 3
            End If
        Else
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)
            If dao.fields.STATUS_ID <= 2 Then
                int_group_ddl = 1
            ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
                int_group_ddl = 2
            ElseIf dao.fields.STATUS_ID >= 6 Then
                int_group_ddl = 3
            End If
        End If
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(5, int_group_ddl)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_pdf(HiddenField1.Value, HiddenField3.Value)
    End Sub

    Sub load_pdf(ByVal path As String, ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename)

            Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Catch ex As Exception

        Finally

            Response.Flush()
            Response.Close()
            Response.End()
        End Try

    End Sub
    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
    End Sub
    Private Sub Binddata_NYM()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim dao_xml As New DAO_DRUG.clsDBXML_NAME
        dao_xml.GetDataby_TR_PROCESS(_TR_ID, _ProcessID)
        path_XML = dao_xml.fields.PATH + dao_xml.fields.XML_NAME
        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        Dim _YEARS As String = dao_tr.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, lcntype, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT

        Dim PDF_TEMPLATE As String = ""
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)

        'If _ProcessID = "1027" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1028" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1029" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1030" Then
        PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'End If
        LOAD_XML_PDF1(path_XML, PDF_TEMPLATE, _ProcessID, filename)
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
    End Sub
    Private Sub BindData_PDF(Optional _group As Integer = 0)

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        Dim dao_pid As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_pid.GetDataby_IDA(dao.fields.PRODUCT_ID_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.lcnno)
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_tr.GetDataby_IDA(dao.fields.TR_ID)

        Dim con_iden As String = ""
        Dim dao_staff_con As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Try
            dao_staff_con.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
        Catch ex As Exception

        End Try

        Dim rcvr_id As String
        Try
            rcvr_id = dao.fields.rcvr_id
        Catch ex As Exception
            rcvr_id = ""
        End Try
        Dim FK_STAFF_OFFER_IDA As Integer
        Try
            FK_STAFF_OFFER_IDA = dao.fields.FK_STAFF_OFFER_IDA
        Catch ex As Exception
            FK_STAFF_OFFER_IDA = 0
        End Try


        Dim _YEARS As String = dao_tr.fields.YEAR

        Dim cls_regis As New CLASS_GEN_XML.drsamp(_CLS.CITIZEN_ID, dao_lcn.fields.lcnsid, dao_lcn.fields.lcnno, dao_lcn.fields.lcntpcd, dao_lcn.fields.pvncd, dao_lcn.fields.IDA, dao_pid.fields.IDA, dao_pid.fields.FK_IDA, dao_pid.fields.FK_IDA, dao.fields.TR_ID, dao.fields.CITIZEN_SUBMIT, rcvr_id, FK_STAFF_OFFER_IDA)
        Dim class_xml As New CLASS_DRSAMP
        class_xml = cls_regis.gen_xml()
        class_xml.APP_STAFF = dao_staff_con.fields.STAFF_OFFER_NAME
        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            Dim write_date As Date = dao.fields.WRITE_DATE
            Dim app_date As Date = dao.fields.appdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            dao.fields.WRITE_DATE = DateAdd(DateInterval.Year, 543, write_date)
            dao.fields.appdate = DateAdd(DateInterval.Year, 543, app_date)
            class_xml.drsamp = dao.fields
        Catch ex As Exception

        End Try


        '-----------------จำนวนกับรายละเอียดขนาดบรรจุ---------------------
        Dim dao_pac As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        'Dim dao_pac As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
        dao_pac.GetDataby_FK_IDA(dao_pid.fields.IDA)
        Dim sum As String = ""

        For Each dao_pac.fields In dao_pac.datas
            If dao_pac.fields.CHECK_PACKAGE = True Then
                If sum <> "" Then
                    sum = sum & ", "
                    sum = sum & dao_pac.fields.IM_DETAIL
                Else
                    sum = dao_pac.fields.IM_DETAIL
                End If
            End If
        Next

        'Dim dao_package As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        'dao_package.GetDataby_FK_IDA(dao_pid.fields.IDA)

        Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
        unit_physic.GetDataby_sunitcd(CInt(dao_pac.fields.SMALL_UNIT))

        class_xml.IMPORT_AMOUNTS = dao.fields.QUANTITY & " " & unit_physic.fields.unit_name
        '-------------------------------------------------------------

        p_drsamp = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE(dao_tr.fields.PROCESS_ID, dao_tr.fields.PROCESS_ID, statusId, 0)
        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(dao_tr.fields.PROCESS_ID, lcntype, statusId, HiddenField2.Value, _group:=0)

        Dim paths As String = bao._PATH_DEFAULT

        Dim PDF_TEMPLATE As String = ""

        'If dao_tr.fields.PROCESS_ID = "1027" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE & "PDF_NORYORMOR2.pdf"
        'ElseIf dao_tr.fields.PROCESS_ID = "1028" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE & "PDF_NORYORMOR3.pdf"
        'ElseIf dao_tr.fields.PROCESS_ID = "1029" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE & "PDF_NORYORMOR4.pdf"
        'End If
        If dao_tr.fields.PROCESS_ID = "1027" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf dao_tr.fields.PROCESS_ID = "1028" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ElseIf dao_tr.fields.PROCESS_ID = "1029" Then
            PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        End If

        'Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        'Dim filename As String = paths & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, dao_tr.fields.PROCESS_ID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        HiddenField3.Value = NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub

    Private Sub BindData_PDF2(Optional _group As Integer = 0)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_IDA(_IDA)
        Dim dao_xml As New DAO_DRUG.clsDBXML_NAME
        dao_xml.GetDataby_TR_PROCESS(_TR_ID, _ProcessID)
        path_XML = dao_xml.fields.PATH + dao_xml.fields.XML_NAME
        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        Dim _YEARS As String = dao_tr.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, 0, statusId, 0)

        Dim paths As String = bao._PATH_DEFAULT

        Dim PDF_TEMPLATE As String = ""
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)

        'If _ProcessID = "1027" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1028" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1029" Then
        '    PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'ElseIf _ProcessID = "1030" Then
        PDF_TEMPLATE = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        'End If
        LOAD_XML_PDF1(path_XML, PDF_TEMPLATE, _ProcessID, filename)
        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        'Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()

        ''Dim dao As New DAO_DRUG.ClsDBdrsamp
        'Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        'dao.GetDataby_IDA(_IDA)
        'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_tr.GetDataby_IDA(dao.fields.TR_ID)

        'Dim _YEARS As String = dao_tr.fields.YEAR

        ''Dim cls_regis As New CLASS_GEN_XML.NYM1(_IDA, dao.fields.lcnno, dao.fields.PJSUM_IDA, dao_tr.fields.CITIEZEN_ID, dao_tr.fields.CITIEZEN_ID_AUTHORIZE)
        'Dim cls_regis As New CLASS_GEN_XML.NYM1(_IDA, 0, dao.fields.IDA, dao_tr.fields.CITIEZEN_ID, dao_tr.fields.CITIEZEN_ID_AUTHORIZE)
        'Dim class_xml As New CLASS_PROJECT_SUM
        'class_xml = cls_regis.gen_xml_NYM1()
        'p_nym1 = class_xml

        'Dim statusId As Integer = dao.fields.STATUS_ID
        ''Dim lcntype As String = dao.fields.lcntpcd
        'Dim lcntype As String = 0
        'Dim paths As String = bao._PATH_DEFAULT
        'Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(_ProcessID, lcntype, statusId, 0)

        'Dim filetemplate As String = bao._PATH_PDF_TEMPLATE & dao_pdftemplate.fields.PDF_TEMPLATE
        'Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)        'code เปิดใช้ตอนอัพ
        'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)

        'LOAD_XML_PDF1(Path_XML, filetemplate, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

        'lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        'hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        'HiddenField1.Value = filename
        'HiddenField3.Value = NAME_PDF("DA", dao_tr.fields.PROCESS_ID, _YEARS, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim _group As Integer = 0
        If HiddenField2.Value = 0 Then
            HiddenField2.Value = 1
            _group = 1
        ElseIf HiddenField2.Value = 1 Then
            HiddenField2.Value = 0
            _group = 0
        End If
        'Dim template_id As Integer = 0
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_IDA(_IDA)
        'Dim _group As Integer = 0
        'Try
        '    template_id = dao.fields.TEMPLATE_ID
        'Catch ex As Exception

        'End Try
        'If template_id = 2 Then
        '    _group = 9
        'End If

        '_group:=_group
        BindData_PDF(_group:=_group)

    End Sub

    'Private Sub btn_drug_group_Click(sender As Object, e As EventArgs) Handles btn_drug_group.Click
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('../LCN/POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx?ida=" & Request.QueryString("ida") & "'); ", True)
    'End Sub

    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email


        mm.SendMail(mcontent)

    End Sub

    Sub package()
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        If _ProcessID = "1026" Then
            Dim pack As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
            pack.GetDataby_PROJECT(_IDA)

            Dim date_add = Date.Now
            Dim order_id As Integer = 0

            For Each pack.fields In pack.datas
                order_id = order_id + 1
                pack.fields.DATE_ADD = date_add
                pack.fields.order_id = order_id
                pack.fields.is_used = 1

                Dim sum As Integer = CInt(pack.fields.sunit) * CInt(pack.fields.munit)
                sum = sum * CInt(pack.fields.imp_amount)
                pack.fields.SUM = sum
                pack.fields.IM_DETAIL = pack.fields.packnm & " นำเข้า " & pack.fields.imp_amount & " " & pack.fields.bunitnm & " (" & sum & " " & pack.fields.sunitnm & ")"

                pack.update()
            Next

            Dim dao_pj As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao_pj.GetDataby_IDA(_IDA)
            dao_pj.fields.STATUS_ID = 8
            dao_pj.update()

        Else
            Dim pack As New DAO_DRUG.TB_DRSAMP_PACKAGE_DETAIL
            pack.GetData_chk_by_FK_drsamp(_IDA)

            Dim date_add = Date.Now
            Dim order_id As Integer = 0

            For Each pack.fields In pack.datas
                order_id = order_id + 1
                pack.fields.DATE_ADD = date_add
                pack.fields.order_id = order_id
                pack.update()
            Next
        End If

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txt_REMARK.Visible = True
        Else
            txt_REMARK.Visible = False
        End If
    End Sub

End Class