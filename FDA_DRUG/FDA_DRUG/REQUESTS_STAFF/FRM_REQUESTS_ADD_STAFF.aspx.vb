Public Class FRM_REQUESTS_ADD_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private PROCESS_ID As String = "1007001"
    Private Sub RunQuery()
        _CLS = Session("CLS")
        'PROCESS_ID = Session("FileName")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunQuery()
        lbl_authorities_responsible.Text = _CLS.THANM

        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString()
            'txt_number.Text = "15"

            bind_ddl_WORK_GROUP()
            bind_ddl_category()

            Bind_Day()
            Bind_Date()
        End If
    End Sub
    Sub Bind_Day()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
            dao.GetDataby_IDA(ddl_category_requests.SelectedValue)
            txt_number.Text = dao.fields.DAY_WORK
        Catch ex As Exception
            txt_number.Text = "0"
        End Try
    End Sub
    Sub Bind_Date()
        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim date_result As Date
        ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
        lbl_number_day.Text = date_result.ToLongDateString()
    End Sub
    Private Sub bind_ddl_category()
        Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
        dao.GetDataby_WORK_GROUP_TYPE(ddl_WORK_GROUP.SelectedItem.Value)
        ddl_category_requests.DataSource = dao.datas
        ddl_category_requests.DataTextField = "TYPE_REQUESTS_SHOW"
        ddl_category_requests.DataValueField = "TYPE_REQUESTS_ID"
        ddl_category_requests.DataBind()
    End Sub

    Private Sub bind_ddl_WORK_GROUP()
        Dim dao As New DAO_DRUG.TB_MAS_WORK_GROUP
        dao.GetDataAll()
        ddl_WORK_GROUP.DataSource = dao.datas
        ddl_WORK_GROUP.DataTextField = "WORK_GROUP_NAME"
        ddl_WORK_GROUP.DataValueField = "WORK_GROUP_ID"
        ddl_WORK_GROUP.DataBind()
    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Insert_Requests()
    End Sub

    Private Sub Insert_Requests()

        'Try

        ' Date_Number_day()

        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim DAO As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
        Dim bao As New BAO.GenNumber
        Dim date_result As Date

        Dim dao_WORK_GROUP As New DAO_DRUG.TB_MAS_WORK_GROUP
        dao_WORK_GROUP.GetDataby_WORK_GROUP_ID(ddl_WORK_GROUP.SelectedItem.Value)

        ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)

        If String.IsNullOrEmpty(txt_date.Text) = False _
         And String.IsNullOrEmpty(lbl_number_day.Text) = False And String.IsNullOrEmpty(txt_company.Text) = False _
         And String.IsNullOrEmpty(lbl_company.Text) = False Then  'ใช้ฟังก์ชั่น เช๊คค่าว่างของ text ตัวนั้น

            Dim RCVNO As String
            RCVNO = bao.GEN_NO_02_2(con_year(Date.Now.Year), _CLS.PVCODE, PROCESS_ID, "", "1", ddl_category_requests.SelectedValue, DAO.fields.IDA, "")

            DAO.fields.TYPE_REQUESTS = ddl_category_requests.SelectedValue
            DAO.fields.TYPE_REQUESTS_NAME = ddl_category_requests.SelectedItem.Text
            DAO.fields.REQUESTS_DATE = CDate(txt_date.Text)
            'DAO.fields.REQUESTS_DATE = DateTime.Now.ToString(txt_date.Text)
            'DAO.fields.REQUESTS_DATE = CDate(txt_date.Text).ToShortDateString
            DAO.fields.ALLOW_NAME = lbl_company.Text
            DAO.fields.REQUESTS_AUTHORITIES = lbl_authorities_responsible.Text
            DAO.fields.RESPONSIBLE_AUTHORITIES = dao_WORK_GROUP.fields.WORK_GROUP_DISPLAY
            DAO.fields.CONREQ_CREATION_DATE = Date.Now
            DAO.fields.CONREQ_LAST_UPDATE = date_result
            DAO.fields.CONREQ_PDF_NAME = PROCESS_ID
            DAO.fields.CONREQ_APPOINTMENT_DATE = lbl_number_day.Text
            DAO.fields.CONREQ_NUMBER_DAY = Integer.Parse(txt_number.Text)
            DAO.fields.RCVNO = RCVNO
            DAO.fields.RCVNO_DISPLAY = RCVNO & "(T)"
            DAO.fields.REQUESTS_DATE_DISPLAY = CDate(txt_date.Text).ToLongDateString()

            DAO.fields.CITIZEN_ID_AUTHORIZE = txt_company.Text
            DAO.fields.CITIZEN_ID_REQUESTS = _CLS.CITIZEN_ID
            DAO.fields.WORK_GROUP_NAME = ddl_WORK_GROUP.SelectedItem.Text
            DAO.fields.WORK_GROUP_ID = ddl_WORK_GROUP.SelectedItem.Value


            DAO.fields.TXT_LCNNO = txt_lcnno.Text
            DAO.fields.SUB_TYPE_REQUESTS = txt_SUB_TYPE_REQUESTS.Text

            DAO.fields.DRUG_NAME_ENG = txt_DRUG_NAME_ENG.Text
            DAO.fields.DRUG_NAME_THAI = txt_DRUG_NAME_THAI.Text

            DAO.fields.ACTIVE = "1"
            DAO.insert()

            alert("บันทึกข้อมูลเรียบร้อยแล้ว")
        Else
            alertERROR("ไม่สามารถบันทึกข้อมูล กรุณาตรวจสอบข้อมูล")
        End If

        'Catch ex As Exception
        '    alertERROR("เกิดข้อผิดพลาดในการป้อนข้อมูล ไม่สามารถบันทึกข้อมูล โปรดตรวจสอบ /วัน/เดือน/ปี , หรือข้อมูลของท่าน")
        'End Try

    End Sub

    Sub Date_Number_day()
        Dim Number As Integer = txt_number.Text
        lbl_number_day.Text = DateAdd(DateInterval.Day, (Number), CDate(Date.Now)).ToShortDateString()
    End Sub

    Sub alertERROR(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent();</script> ")
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_company_Click(sender As Object, e As EventArgs) Handles btn_company.Click
        lbl_company.Text = set_name_company(txt_company.Text)
    End Sub

    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function



    'Protected Sub txt_number_TextChanged(sender As Object, e As EventArgs) Handles txt_number.TextChanged
    '    Dim ws As New WS_GETDATE_WORKING.Service1
    '    Dim date_result As Date
    '    ws.GETDATE_WORKING(Date.Now, True, txt_number.Text, True, date_result, True)
    '    lbl_number_day.Text = date_result.ToLongDateString()
    'End Sub

    Protected Sub btn_day_Click(sender As Object, e As EventArgs) Handles btn_day.Click
        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim date_result As Date
        ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
        lbl_number_day.Text = date_result.ToLongDateString()
    End Sub

    Protected Sub ddl_WORK_GROUP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_WORK_GROUP.SelectedIndexChanged
        bind_ddl_category()
    End Sub

    Private Sub ddl_category_requests_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_category_requests.SelectedIndexChanged
        Bind_Day()
        Bind_Date()
    End Sub


End Class