Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_RESEARCH_SUM_UL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Private RESULT_ALERT As String = "กรุณาแนบไฟล์ ดั้งนี้ \n"

    Sub runQuery()
        _Process = "1026"
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
        Dim dao As New DAO_DRUG.TB_TEMPLATE_ATTACH
        dao.GetDataby_LCTNPCD(_Process, "00")
        For Each dao.fields In dao.datas
            Dim uc As New UC_ATTACH
            Dim CC As UserControl = Page.LoadControl("../UC/UC_ATTACH.ascx")
            uc = CC
            uc.ID = dao.fields.IDA
            uc.BindData(dao.fields.ATTACH_NAME, dao.fields.ATTACH_PIORITY, dao.fields.ATTACH_FILE_EXTENSION, dao.fields.LCNTPCD, dao.fields.TYPE)
            PlaceHolder1.Controls.Add(uc)
        Next
        If Not IsPostBack Then
            set_file()
        End If
    End Sub

    Sub set_file()
        If IsNothing(_CLS.TRANSECTION_UP_ID) Then

        Else
            file_upload.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        If IsNothing(_CLS.TRANSECTION_UP_ID) Then
            If FileUpload1.HasFile Then

                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()


                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection_new(_Process) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION

                If Upload_Attach(TR_ID) Then
                    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
                    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_Process, 1, 1)
                    'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                    Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _Process, Date.Now.Year, TR_ID)
                    'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                    Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _Process, Date.Now.Year, TR_ID)


                    FileUpload1.SaveAs(XML_TRADER) '"C:\path\PDF_TRADER\"

                    'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                    Dim paths As String = bao._PATH_DEFAULT
                    convert_XML_To_PDF(PDF_TRADER, XML_TRADER, dao_pdftemplate.fields.PDF_TEMPLATE)
                    Dim check As Boolean = True
                    ' Try
                    check = insrt_to_database(XML_TRADER, TR_ID)
                    If check = True Then
                        Dim dao_xml As New DAO_DRUG.clsDBXML_NAME
                        dao_xml.fields.TR_ID = TR_ID
                        dao_xml.fields.PATH = paths & "XML_TRADER_UPLOAD\"
                        dao_xml.fields.PROCESS_ID = _Process
                        dao_xml.fields.XML_NAME = NAME_UPLOAD_XML("DA", _Process, Date.Now.Year, TR_ID)
                        dao_xml.insert()
                        alert("รหัสการดำเนินการ คือ DA-" & _Process & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)

                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เกิดข้อผิดพลาดกรุณาตรวจสอบข้อมูลในไฟล์');", True)
                    End If
                    ' Catch ex As Exception

                    'alert("เกิดข้อผิดพลาด")

                    'End Try
                Else
                    alert(RESULT_ALERT)
                End If

            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกไฟล์สรุปย่อโครงการวิจัย');", True)
            End If
        Else
            If Upload_Attach(_CLS.TRANSECTION_UP_ID) Then

                alert("รหัสการดำเนินการ คือ DA-" & _Process & "-" & con_year(Date.Now.Date().Year()) & "-" + _CLS.TRANSECTION_UP_ID)

            Else
                alert(RESULT_ALERT)
            End If
        End If

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        'Dim check As Boolean = False
        'Try
        '    Dim objStreamReader As New StreamReader(FileName)
        '    Dim p2 As New CLASS_PROJECT_SUM
        '    Dim x As New XmlSerializer(p2.GetType)
        '    p2 = x.Deserialize(objStreamReader)
        '    objStreamReader.Close()

        '    Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        '    dao.GetDataby_IDA(p2.DRUG_PROJECT_SUMMARY.IDA)

        '    With p2.DRUG_PROJECT_SUMMARY
        '        dao.fields.givedata_times = .givedata_times
        '        dao.fields.givedata_date = .givedata_date
        '        dao.fields.pj_thname = .pj_thname
        '        dao.fields.pj_enname = .pj_enname
        '        dao.fields.pj_code = .pj_code
        '        dao.fields.pj_othernmcd = .pj_othernmcd
        '        dao.fields.pj_othernm = .pj_othernm
        '        dao.fields.ind_numbercd = .ind_numbercd
        '        dao.fields.ind_number = .ind_number
        '        dao.fields.CTR = .CTR
        '        dao.fields.pj_typecd = .pj_typecd
        '        dao.fields.pj_1sttime = .pj_1sttime
        '        dao.fields.supporttypr = .supporttypr
        '        dao.fields.country = .country
        '        dao.fields.inter_intitute = .inter_intitute
        '        dao.fields.inter_volunteer = .inter_volunteer
        '        dao.fields.th_intitute = .th_intitute
        '        dao.fields.th_spon_group = .th_spon_group
        '        dao.fields.th_spon_addr = .th_spon_addr
        '        dao.fields.th_spon_tel = .th_spon_tel
        '        dao.fields.th_spon_email_website = .th_spon_email_website
        '        dao.fields.for_spon_group = .for_spon_group
        '        dao.fields.for_spon_addr = .for_spon_addr
        '        dao.fields.for_spon_tel = .for_spon_tel
        '        dao.fields.for_spon_email_website = .for_spon_email_website
        '        dao.fields.monitor_type = .monitor_type
        '        dao.fields.monitor_group = .monitor_group
        '        dao.fields.monitor_addr = .monitor_addr
        '        dao.fields.monitor_tel = .monitor_tel
        '        dao.fields.monitor_email_website = .monitor_email_website
        '        dao.fields.PM_type = .PM_type
        '        dao.fields.PM_group = .PM_group
        '        dao.fields.PM_addr = .PM_addr
        '        dao.fields.PM_tel = .PM_tel
        '        dao.fields.PM_email_website = .PM_email_website
        '        dao.fields.DM_type = .DM_type
        '        dao.fields.DM_group = .DM_group
        '        dao.fields.DM_addr = .DM_addr
        '        dao.fields.DM_tel = .DM_tel
        '        dao.fields.DM_email_website = .DM_email_website
        '        dao.fields.clinical_laboratorycd = .clinical_laboratorycd
        '        dao.fields.placebo_cd = .placebo_cd
        '        dao.fields.pj_start_inth = .pj_start_inth
        '        dao.fields.pj_end_inth = .pj_end_inth
        '        dao.fields.volunteer = .volunteer
        '        dao.fields.volunteer_descript = .volunteer_descript
        '        dao.fields.Financing_and_Insurance = .Financing_and_Insurance  
        '    End With

        '    dao.fields.citizen_submit = _CLS.CITIZEN_ID
        '    dao.fields.TR_ID = TR_ID
        '    dao.fields.STATUS_ID = 1
        '    dao.fields.CREATE_DATE = Date.Now
        '    dao.update()

        '    'Dim dao_research_fac As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY

        '    'For Each dao_research_fac.fields In p2.DRUG_PROJECT_RESEARCH_FACILITYS
        '    '    dao_research_fac.fields.PJ_IDA = dao.fields.IDA
        '    '    dao_research_fac.insert()
        '    '    dao_research_fac = New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
        '    'Next

        '    'Dim dao_clinic As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
        '    'For Each dao_clinic.fields In p2.DRUG_PROJECT_CLINICAL_LABORATORYS
        '    '    dao_clinic.fields.PJ_IDA = dao.fields.IDA
        '    '    dao_clinic.insert()
        '    '    dao_clinic = New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
        '    'Next

        '    'Dim dao_pid As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        '    'For Each dao_pid.fields In p2.DRUG_PROJECT_DRUG_LISTS
        '    '    dao_pid.fields.PJ_IDA = dao.fields.IDA
        '    '    dao_pid.insert()
        '    '    dao_pid = New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        '    'Next

        '    check = True
        Dim check As Boolean = True
        Try
            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_PROJECT_NYM1
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM

            dao.fields.CREATE_DATE = Date.Now
            dao.fields.TR_ID = TR_ID
            dao.fields.STATUS_ID = 0
            dao.fields.CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.pj_code = p2.DRUG_PROJECT_SUMMARY.pj_code
            dao.fields.pj_enname = p2.DRUG_PROJECT_SUMMARY.pj_enname
            dao.fields.pj_thname = p2.DRUG_PROJECT_SUMMARY.pj_thname
            dao.insert()


            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = dao.fields.IDA
            dao_up.update()
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    ''' ทำการ UPLOAD FILE แนบ
    ''' </summary>
    ''' <param name="TR_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Upload_Attach(ByVal TR_ID As Integer)
        Dim check As Boolean = True

        For Each c As Control In PlaceHolder1.Controls
            If c.ID <> "" Then
                Dim ida As String = c.ID
                Dim uc As New UC_ATTACH
                uc = PlaceHolder1.FindControl(c.ID)
                check = uc.insert(TR_ID)
                RESULT_ALERT = RESULT_ALERT + uc.NAME + "\n"
                If check = False Then
                    'alert(RESULT_ALERT)
                    Exit For
                End If
            End If
        Next
        Return check
    End Function

End Class