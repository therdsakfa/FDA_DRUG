Public Class POPUP_LCN_NCT_TEMP_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private b64 As String
    Sub RunQuery()
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
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'If Session("b64") IsNot Nothing Then
        '    b64 = Session("b64")
        'End If
        If Not IsPostBack Then
            BindData_PDF()
            'show_btn(_IDA)
           
        End If
    End Sub
    Private Sub BindData_PDF()
        Dim dao_vj As New DAO_DRUG.TB_TEMP_NCT_DALCN
        dao_vj.Getdata_by_ID(_IDA)
        Dim bao As New BAO.AppSettings

        Dim cls_dalcn As New CLASS_GEN_XML.T_NCT_DALCN_TEMP(_CLS.CITIZEN_ID)

        Dim class_xml As New CLASS_TEMP_NCT_DALCN
        'class_xml = cls_dalcn.gen_xml()
        class_xml.TEMP_NCT_DALCNs = dao_vj.fields

        Try
            class_xml.TEMP_NCT_DALCNs.BSN_IDENTIFY = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.BSN_IDENTIFY)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.CONDITION = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.CONDITION)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.DATE_DAY = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.DATE_DAY)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.DATE_END = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.DATE_END)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.DATE_MONTH = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.DATE_MONTH)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.DATE_START = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.DATE_START)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.DATE_YEAR = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.DATE_YEAR)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.DRUG_GROUP = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.DRUG_GROUP)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.IDENTIFY = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.IDENTIFY)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.KEEP_TEL = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.KEEP_TEL)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.LCNNO_FORMAT = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.LCNNO_FORMAT)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.LICEN_NAME = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.LICEN_NAME)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.LOCATION_ADDR = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.LOCATION_ADDR)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.LOCATION_KEEP_NAME = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.LOCATION_KEEP_NAME)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.LOCATION_KRRP_ADDR = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.LOCATION_KRRP_ADDR)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.LOCATION_NAME = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.LOCATION_NAME)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.MAIN_LCNNO_FORMAT = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.MAIN_LCNNO_FORMAT)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.PHR_NUMBER1 = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.PHR_NUMBER1)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.PHR_NUMBER2 = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.PHR_NUMBER2)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.PHR_NUMBER3 = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.PHR_NUMBER3)
        Catch ex As Exception

        End Try
        Try
            class_xml.TEMP_NCT_DALCNs.TEL = NumEng2Thai(class_xml.TEMP_NCT_DALCNs.TEL)
        Catch ex As Exception

        End Try
        p_temp_nct = class_xml
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS

        dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2(_ProcessID, dao_vj.fields.LCNTPCD, dao_vj.fields.STATUS_ID, 0, _group:=99)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(_TR_ID)
        Dim PROCESS_ID As String = dao_up.fields.PROCESS_ID
        Dim YEAR As String = dao_up.fields.YEAR

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, Year, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, Year, _TR_ID)
        'load_PDF(filename)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename, temps:="1") 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
       


        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", PROCESS_ID, YEAR, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
End Class