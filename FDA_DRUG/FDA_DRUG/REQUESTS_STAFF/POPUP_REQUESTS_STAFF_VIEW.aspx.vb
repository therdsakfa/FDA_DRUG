Public Class POPUP_REQUESTS_STAFF_VIEW
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _YEARS As String
    Private _TR_ID As String
    Private Sub RunQuery()
        _CLS = Session("CLS")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then

            BindData_PDF()

        End If
    End Sub
    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
        dao.GetDataby_IDA(_IDA)
        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim cls As New CLASS_GEN_XML.DRUG_CONSIDER_REQUEST()

        Dim class_xml As New XML_CONSIDER_REQUESTS
        Dim bao_show As New BAO_SHOW
        class_xml = cls.gen_xml()

      
        Dim bao_master As New BAO_MASTER

        If IsNothing(dao.fields.REQUESTS_DATE) = False Then
            Dim appdate As Date
            If Date.TryParse(dao.fields.REQUESTS_DATE, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
                class_xml.EXP_YEAR = con_year(appdate.Year)

            End If
        End If
        Try
            class_xml.DT_SHOW.DT1 = bao_show.SP_DRUG_SCHEDULE_by_REF_C_NUMBER_V2(dao.fields.REQUEST_CENTER_NO)
            class_xml.DT_SHOW.DT1.TableName = "SP_DRUG_SCHEDULE_by_REF_C_NUMBER"
        Catch ex As Exception

        End Try

        p_DRUG_CONSIDER_REQUESTS = class_xml
        class_xml.DRUG_CONSIDER_REQUESTs = dao.fields
        class_xml.DRUG_CONSIDER_REQUESTs.REQUESTS_DATE = dao.fields.REQUESTS_DATE.Value.ToLongDateString()
        class_xml.DRUG_CONSIDER_REQUESTs.ALLOW_NAME = dao.fields.ALLOW_NAME & " (" & dao.fields.CITIZEN_ID_AUTHORIZE & ")"

        class_xml.SHOW_CONREQ_APPOINTMENT_DATE = "(วันที่ " & dao.fields.CONREQ_APPOINTMENT_DATE & " )"

        If dao.fields.SUB_TYPE_REQUESTS Is Nothing Or IsNothing(dao.fields.SUB_TYPE_REQUESTS) = True Or String.IsNullOrEmpty(dao.fields.SUB_TYPE_REQUESTS) = True Then
            class_xml.DRUG_CONSIDER_REQUESTs.TYPE_REQUESTS_NAME = dao.fields.TYPE_REQUESTS_NAME
        Else
            class_xml.DRUG_CONSIDER_REQUESTs.TYPE_REQUESTS_NAME = dao.fields.TYPE_REQUESTS_NAME & "(" & dao.fields.SUB_TYPE_REQUESTS & ")"
        End If

        Dim statusId As Integer = 0
        Dim lcntype As String = 0
        Dim PROCESS_ID As String = 1007001 'dao_up.fields.PROCESS_ID
        Dim dat As Date
        dao.fields.REQUESTS_DATE = Date.Parse(dat)
        Dim YEAR As String = dao.fields.REQUESTS_DATE.Value.Year 'dao_up.fields.YEAR
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(PROCESS_ID, 0, 0, 0)


        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        ' Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _IDA)
        'Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, Year, _IDA)
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", PROCESS_ID, YEAR, _IDA)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", PROCESS_ID, YEAR, _IDA)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, PROCESS_ID, filename, filename:=NAME_PDF("DA", PROCESS_ID, YEAR, _IDA)) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_pdf(HiddenField1.Value)
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
End Class