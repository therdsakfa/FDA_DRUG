Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class FRM_DS_CONFIRM
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            BindData_PDF()
            show_btn(_IDA)
            'UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv(_TR_ID)
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.cnccscd.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
            'ElseIf chk_pha() = True Then 'true คือเภสัชไม่ยืนยัน ,False คือเภสัชยืนยัน
            '    btn_confirm.Enabled = False
            '    btn_cancel.Enabled = False
            '    btn_confirm.CssClass = "btn-danger btn-lg"
            '    btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Private Function chk_pha() As Boolean
        Dim chk As Boolean = True
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_FK_IDA(_IDA)
        For Each row In dao.datas
            If row.PHR_STATUS_UPLOAD = "1" Then
                chk = False
            End If
        Next
        Return chk
    End Function
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        Dim bao As New BAO.ClsDBSqlcommand
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 2

        dao.update()
        AddLogStatus(2, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        alert("ยื่นเรื่องเรียบร้อยแล้ว")
        Response.Write("<script type langue =javascript>")
        Response.Write("window.location.href = '../DS/FRM_DS_MAIN.aspx?process=" & _ProcessID & "';")
        Response.Write("</script type >")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Integer.Parse(_IDA))
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
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
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
        Dim bao2 As New BAO.ClsDBSqlcommand
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(_TR_ID)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP

        dao.GetDataby_IDA(_IDA)
        '-------------------เก่า------------------
        ' dao_PHR.GetDataby_FK_IDA(_IDA)
        '-------------------เก่า------------------
        dao_PHR.GetDataby_FK_IDA_AddDetails(_IDA)
        '------------------------------------
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim lcnno_text As String = ""
        Dim lcnno_auto As String = ""
        Dim lcnno_format As String = ""
        Try
            lcnno_text = dao.fields.LCNNO_MANUAL
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao.fields.lcnno
        Catch ex As Exception

        End Try
        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao.fields.lcntpcd, dao.fields.pvncd, CHK_SELL_TYPE:=dao.fields.CHK_SELL_TYPE)

        Dim class_xml As New CLASS_DALCN
        ' class_xml = cls_dalcn.gen_xml()
        class_xml.dalcns = dao.fields
        'p_lcn = class_xml

        Dim bao_show As New BAO_SHOW
        'class_xml = cls_dalcn.gen_xml()

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        Try
            'class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน

        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(dao.fields.IDA, 2)
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 1)
        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(dao.fields.IDA, 2)
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"
        Dim MAIN_LCN_IDA As Integer = 0
        'If IsNothing(dao.fields.MAIN_LCN_IDA) = False Then
        '    If (Integer.TryParse(dao.fields.MAIN_LCN_IDA, MAIN_LCN_IDA) = True) Then        'เปลี่ยน ร
        '        class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        '    End If
        'End If
        Try
            MAIN_LCN_IDA = dao.fields.MAIN_LCN_IDA
        Catch ex As Exception

        End Try
        Try
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(MAIN_LCN_IDA)
        Catch ex As Exception

        End Try
        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        dao_main.GetDataby_IDA(MAIN_LCN_IDA)
        Try
            If Len(lcnno_auto) > 0 Then
                lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        If MAIN_LCN_IDA = 0 Then
            class_xml.LCNNO_SHOW = lcnno_format
            class_xml.SHOW_LCNNO = lcnno_text
        Else

            class_xml.LCNNO_SHOW = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(dao_main.fields.lcnno, 5))) & "/25" & Left(dao_main.fields.lcnno, 2)
            class_xml.SHOW_LCNNO = dao_main.fields.LCNNO_MANUAL
        End If

        class_xml.CHK_VALUE = dao_PHR.fields.PHR_MEDICAL_TYPE

        If IsNothing(dao.fields.appdate) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)


                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                class_xml.EXP_YEAR = con_year(appdate.Year)

            End If
        End If
        '-------------------เก่า------------------
        'For Each dao_PHR.fields In dao_PHR.datas
        '    Dim cls_DALCN_PHR As New DALCN_PHR
        '    cls_DALCN_PHR = dao_PHR.fields
        '    class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        'Next
        '-------------------ใหม่------------------
        Try
            For Each dao_PHR.fields In dao_PHR.Details
                class_xml.DALCN_PHRs.Add(dao_PHR.fields)
            Next
        Catch ex As Exception

        End Try
        '-------------------------------------


        For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In dao_DALCN_DETAIL_LOCATION_KEEP.datas
            Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
            cls_DALCN_DETAIL_LOCATION_KEEP = dao_DALCN_DETAIL_LOCATION_KEEP.fields
            class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
        Next

        Try
            Dim rcvdate As Date = dao.fields.rcvdate
            dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
            class_xml.dalcns = dao.fields



        Catch ex As Exception

        End Try

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try

        p_dalcn = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd
       Dim PROCESS_ID As String = _ProcessID
        Dim YEAR As String = dao_up.fields.YEAR

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'If statusId = 8 Then
        '    Dim bao_count As New BAO.ClsDBSqlcommand
        '    Dim count_num As Integer = 0
        '    count_num = bao_count.SC_CHECK_PAY(_IDA)
        '    Dim Group As Integer
        '    If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
        '        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(PROCESS_ID, lcntype, statusId, Group, 0)
        '    ElseIf count_num = 0 Then
        '        statusId = 6
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    End If

        'Else
        Dim template_id As Integer = 0
        'If statusId = 8 Then
        '    If PROCESS_ID = "104" Then
        '        Try
        '            template_id = dao.fields.TEMPLATE_ID
        '        Catch ex As Exception
        '            template_id = 0
        '        End Try
        '        If template_id <> 0 Then
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
        '        Else
        '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=0)
        '        End If

        '    Else
        '        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        '    End If
        'Else
        '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
        'End If

        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then

                'If PROCESS_ID = "104" Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try

                If template_id = 2 Then
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                Else
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(PROCESS_ID, statusId, 0, 0)
                End If
                'Else
                '    dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(PROCESS_ID, lcntype, statusId, Group, 0)
                'End If
            Else

                'If PROCESS_ID = "104" Then
                Try
                    template_id = dao.fields.TEMPLATE_ID
                Catch ex As Exception
                    template_id = 0
                End Try
                If template_id = 2 Then
                    If statusId = 6 Then
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                    Else
                        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=9)
                        'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                    End If

                Else
                    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUP(PROCESS_ID, lcntype, statusId, 0, _group:=0)
                    'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                End If

                '    Else
                '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                'End If

            End If
        Else

            'If PROCESS_ID = "104" Then
            Try
                template_id = dao.fields.TEMPLATE_ID
            Catch ex As Exception
                template_id = 0
            End Try
            If template_id = 2 Then
                'If statusId = 6 Then
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(PROCESS_ID, lcntype, statusId, 0, _group:=0)
                'Else
                'dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
                'End If

            Else
                dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
            End If
            '    Else
            '    dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
            'End If
        End If



        'End If

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class