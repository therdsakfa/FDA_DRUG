Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class FRM_REPORT_LCN_CONFIRM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private Sub RunQuery()
        '_ProcessID = 101
        _CLS = Session("CLS")
        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            BindData_PDF()
            load_fdpdtno()
            UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv(_IDA)
            set_lbl()
        End If
    End Sub
    Sub set_lbl()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        Dim dao_s As New DAO_DRUG.TB_MAS_STAFF_OFFER
        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        Try
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
        Try
            lbl_consider_date.Text = CDate(dao.fields.CONSIDER_DATE).ToShortDateString()
        Catch ex As Exception

        End Try

        Try
            dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, 2)
            lbl_Status.Text = dao_stat.fields.STATUS_NAME
        Catch ex As Exception

        End Try


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

        BindData_PDF()
    End Sub


    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub


    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
       load_pdf(HiddenField1.Value)
    End Sub
    Sub load_pdf(ByVal filename As String)
        Try
            Dim str As String() = filename.Split("\")
   
            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & str(str.Length - 1) & ".pdf")

            Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

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
        'UC_CONFIRM.load_SORBOR5(p2)
    End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        'bao.RunAppSettings()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim dao_PHR As New DAO_DRUG.ClsDBDALCN_PHR
        dao_PHR.GetDataby_FK_IDA(_IDA)
        Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_DALCN_DETAIL_LOCATION_KEEP.GetData_by_LCN_IDA(_IDA)

        Dim ProcessID = dao_up.fields.PROCESS_ID

        Dim cls_dalcn As New CLASS_GEN_XML.DALCN(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao.fields.lcntpcd, dao.fields.pvncd)

        Dim class_xml As New CLASS_DALCN
        Dim bao_show As New BAO_SHOW
        class_xml = cls_dalcn.gen_xml()

        class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, dao.fields.lcnsid) 'ข้อมูลที่ตั้งหลัก
        class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.lcnsid) 'ข้อมูลบริษัท
        class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, dao.fields.lcnsid) 'ที่เก็บ
        class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
        class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        Dim bao_master As New BAO_MASTER

        class_xml.DT_MASTER.DT18 = bao_master.SP_PHR_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT24 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT25 = bao_master.SP_PHR_NOT_ROW_1_BY_FK_IDA(dao.fields.IDA)
        class_xml.DT_MASTER.DT26 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(11, 1)
        class_xml.DT_MASTER.DT27 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE(11, 2)
        class_xml.DT_MASTER.DT27.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2"
        class_xml.DT_MASTER.DT28 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(11, 1)
        class_xml.DT_MASTER.DT29 = bao_master.SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2(11, 2)
        class_xml.DT_MASTER.DT29.TableName = "SP_PHR_BY_FK_IDA_and_PHR_MEDICAL_TYPE_2_1_ROW"

        class_xml.LCNNO_SHOW = dao.fields.LCNNO_DISPLAY
        class_xml.SHOW_LCNNO = dao.fields.LCNNO_DISPLAY
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

        For Each dao_PHR.fields In dao_PHR.datas
            Dim cls_DALCN_PHR As New DALCN_PHR
            cls_DALCN_PHR = dao_PHR.fields
            class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
        Next

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



        p_dalcn = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As String = dao.fields.lcntpcd
       Dim PROCESS_ID As String = _ProcessID
        Dim YEAR As String = dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS

        If statusId = 8 Then
            Dim Group As Integer
            If Integer.TryParse(dao_PHR.fields.PHR_MEDICAL_TYPE, Group) = True Then
                dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(PROCESS_ID, lcntype, statusId, Group, 0)
            Else
                dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)
            End If
        Else
            dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, lcntype, statusId, 0)



        End If



        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename 'NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub

    Private Sub btn_load0_Command(sender As Object, e As CommandEventArgs) Handles btn_load0.Command
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class