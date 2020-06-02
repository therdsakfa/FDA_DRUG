Public Class FRM_REQUESTS_ADD_STAFF2
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

    Private Sub bind_ddl_category()
        'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
        'dao.GetDataby_WORK_GROUP_TYPE(ddl_WORK_GROUP.SelectedItem.Value)
        'ddl_category_requests.DataSource = dao.datas
        'ddl_category_requests.DataTextField = "TYPE_REQUESTS_SHOW"
        'ddl_category_requests.DataValueField = "TYPE_REQUESTS_ID"
        'ddl_category_requests.DataBind()

        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_TYPE_REQUESTS_BY_GROUP(ddl_WORK_GROUP.SelectedValue)
        ddl_category_requests.DataSource = dt
        ddl_category_requests.DataTextField = "TYPE_REQUESTS_NAME"
        ddl_category_requests.DataValueField = "TYPE_REQUESTS_ID"
        ddl_category_requests.DataBind()
    End Sub

    Private Sub bind_ddl_WORK_GROUP()
        Dim dao As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
        dao.GetDataAll()
        ddl_WORK_GROUP.DataSource = dao.datas
        ddl_WORK_GROUP.DataTextField = "WORK_GROUP"
        ddl_WORK_GROUP.DataValueField = "IDA"
        ddl_WORK_GROUP.DataBind()
    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            Insert_Requests()

            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "INSERT A", "1007001")
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "INSERT A", "1007001")
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "INSERT A", "1007001")

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "INSERT A", "1007001")

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try

    End Sub

    Private Sub Insert_Requests()
        'If CHK_REF_NO_AND_C_NO(txt_ref_no.Text, txt_r_no.Text) = True Then
        If txt_r_no.Text = "" Then
            alertERROR("กรุณากรอกเลขรับคำร้อง/ตรวจคำขอ")
        Else
            Dim count_c As Integer = 0
            Dim dao_count_c As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            count_c = dao_count_c.Count_R(txt_r_no.Text)

            Dim count_r_c As Integer = 0
            Dim dao_count_r_c As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            count_r_c = dao_count_r_c.GetDataby_R_and_C(txt_r_no.Text)

            If count_c <= 1 Then
                If count_r_c = 0 Then
                    Dim bool As Boolean = Chk_ref_no(txt_ref_no.Text)

                    If bool = True Then
                        '----------------------------------------------------
                        Dim result1 As String = ""
                        Dim result As String = ""
                        Dim ws2 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT
                        result1 = ws2.CHECK_PRICE(txt_ref_no.Text, txt_company.Text)

                        Dim _price As Double = 0
                        'เช็คจำนวนเงิน
                        If Double.TryParse(result1, _price) Then
                            Dim ws3 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT
                            result = CHECK_PAYMENT(txt_ref_no.Text, txt_company.Text, 1)
                            If result = "0" Then
                                Dim ws As New WS_GETDATE_WORKING.Service1
                                Dim DAO As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                                Dim bao As New BAO.GenNumber
                                Dim date_result As Date

                                Dim dao_WORK_GROUP As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
                                dao_WORK_GROUP.GetDataby_IDA(ddl_WORK_GROUP.SelectedItem.Value)

                                ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
                                '---------------------------------------------------
                                If String.IsNullOrEmpty(txt_date.Text) = False _
                                 And String.IsNullOrEmpty(lbl_number_day.Text) = False And String.IsNullOrEmpty(txt_company.Text) = False _
                                 And String.IsNullOrEmpty(lbl_company.Text) = False Then  'ใช้ฟังก์ชั่น เช๊คค่าว่างของ text ตัวนั้น


                                    DAO.fields.STAFF_IDENTIFY = txt_staff_iden.Text
                                    DAO.fields.TYPE_REQUESTS = ddl_category_requests.SelectedValue
                                    DAO.fields.TYPE_REQUESTS_NAME = ddl_category_requests.SelectedItem.Text
                                    DAO.fields.REQUESTS_DATE = CDate(txt_date.Text)
                                    'DAO.fields.REQUESTS_DATE = DateTime.Now.ToString(txt_date.Text)
                                    'DAO.fields.REQUESTS_DATE = CDate(txt_date.Text).ToShortDateString
                                    DAO.fields.ALLOW_NAME = lbl_company.Text
                                    DAO.fields.REQUESTS_AUTHORITIES = lbl_authorities_responsible.Text
                                    DAO.fields.RESPONSIBLE_AUTHORITIES = dao_WORK_GROUP.fields.WORK_GROUP
                                    DAO.fields.CONREQ_CREATION_DATE = Date.Now
                                    DAO.fields.CONREQ_LAST_UPDATE = date_result
                                    Try
                                        DAO.fields.CONREQ_LAST_UPDATE_DATE = date_result
                                    Catch ex As Exception

                                    End Try
                                    DAO.fields.CONREQ_PDF_NAME = PROCESS_ID
                                    DAO.fields.CONREQ_APPOINTMENT_DATE = lbl_number_day.Text
                                    DAO.fields.CONREQ_NUMBER_DAY = Integer.Parse(txt_number.Text)

                                    DAO.fields.REQUESTS_DATE_DISPLAY = CDate(txt_date.Text).ToLongDateString()

                                    DAO.fields.CITIZEN_ID_AUTHORIZE = txt_company.Text
                                    DAO.fields.CITIZEN_ID_REQUESTS = _CLS.CITIZEN_ID
                                    DAO.fields.WORK_GROUP_NAME = ddl_WORK_GROUP.SelectedItem.Text
                                    DAO.fields.WORK_GROUP_ID = ddl_WORK_GROUP.SelectedValue


                                    DAO.fields.TXT_LCNNO = txt_lcnno.Text
                                    DAO.fields.SUB_TYPE_REQUESTS = txt_SUB_TYPE_REQUESTS.Text

                                    DAO.fields.DRUG_NAME_ENG = txt_DRUG_NAME_ENG.Text
                                    DAO.fields.DRUG_NAME_THAI = txt_DRUG_NAME_THAI.Text
                                    Try
                                        DAO.fields.PVNCD = _CLS.PVCODE
                                    Catch ex As Exception

                                    End Try

                                    DAO.fields.REF_NO = txt_ref_no.Text

                                    DAO.fields.ACTIVE = "1"
                                    DAO.insert()
                                    Dim _ida As Integer = DAO.fields.IDA

                                    DAO = New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                                    DAO.GetDataby_IDA(_ida)
                                    Dim RCVNO As String = ""
                                    RCVNO = bao.GEN_NO_02_2(con_year(Date.Now.Year), _CLS.PVCODE, PROCESS_ID, "", "1", ddl_category_requests.SelectedValue, _ida, "")
                                    DAO.fields.RCVNO = RCVNO
                                    DAO.fields.RCVNO_DISPLAY = RCVNO & "-A"
                                    Try
                                        DAO.fields.REQUEST_CENTER_NO = txt_r_no.Text
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        DAO.fields.FK_REQUEST_CENTER = HiddenField1.Value
                                    Catch ex As Exception

                                    End Try
                                    If txt_r_no.Text <> "" Then
                                        Dim dao_r As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                                        dao_r.get_data_by_rno(txt_r_no.Text)
                                        DAO.fields.CITIZEN_AUTHIRIZE = dao_r.fields.CITIZEN_AUTHIRIZE
                                        DAO.fields.CITIZEN_ID = dao_r.fields.CITIZEN_ID
                                        DAO.fields.FK_LOCATION_IDA = dao_r.fields.FK_LOCATION_IDA
                                    End If

                                    DAO.update()

                                    Dim result_c As String = ""
                                    Dim ws_c As New WS_UPDATE_C.Service1
                                    'Dim ws_c As New WS_UPDATE_C_DEMO.Service1
                                    Try
                                        result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(txt_r_no.Text)
                                        'result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(txt_r_no.Text)
                                    Catch ex As Exception
                                        Dim dao_log As New DAO_DRUG.TB_LOG_A_ERRORS
                                        With dao_log.fields
                                            .CREATE_DATE = Date.Now
                                            .EX_MESSAGE = ex.Message
                                            .FK_IDA = _ida
                                            .R_C_NO = txt_r_no.Text
                                        End With
                                        dao_log.insert()
                                    End Try

                                    Try
                                        result = ws2.CHECK_PAYMENT(txt_ref_no.Text, txt_company.Text, 1)
                                    Catch ex As Exception

                                    End Try

                                    alert("บันทึกข้อมูลเรียบร้อยแล้ว")
                                Else
                                    alertERROR("ไม่สามารถบันทึกข้อมูล กรุณาตรวจสอบข้อมูล")
                                End If
                                '---------------------------------
                            Else
                                alertERROR(result)
                            End If

                        Else
                            alertERROR(result1)
                        End If
                        '--------------------------------------------
                    Else
                        'กรณีเลขนี้ใช้ไปแล้ว
                        Dim result As String = ""
                        Dim ws3 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT
                        result = ws3.CHECK_PAYMENT(txt_ref_no.Text, txt_company.Text, 1)

                        alertERROR("เลขอ้างอิง " & txt_ref_no.Text & " ถูกใช้งานแล้ว")
                    End If
                Else
                    alertERROR("ไม่สามารถใช้เลขรับคำร้อง/ตรวจคำขอซ้ำได้")
                End If

            Else
                alertERROR("ไม่สามารถใช้เลขรับคำร้องซ้ำได้")
            End If

        End If
        'Else
        'alertERROR("ไม่สามารถบันทึกได้เนื่องจากเลขรับตรวจคำขอ(C) ไม่ตรงกับเลขอ้างอิงเงิน")
        'End If

        'Try

        ' Date_Number_day()



        'Catch ex As Exception
        '    alertERROR("เกิดข้อผิดพลาดในการป้อนข้อมูล ไม่สามารถบันทึกข้อมูล โปรดตรวจสอบ /วัน/เดือน/ปี , หรือข้อมูลของท่าน")
        'End Try

    End Sub
    Function CHK_REF_NO_AND_C_NO(ByVal refno As String, ByVal C_NO As String) As Boolean
        Dim bool As Boolean = True
        Dim i As Integer = 0
        Dim dao_ref As New DAO_SP_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
        i = dao_ref.count_REFNO_C_NO(refno, C_NO)
        If i = 0 Then
            bool = False
        End If
        Return bool
    End Function
    Public Function CHECK_PAYMENT(ByVal refno As String, ByVal identify As String, ByVal system As Integer) As String
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim CHK_STATUS As String
        Dim dao_ref As New DAO_SP_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
        Try
            dao_ref.GetDataby_REFNO(refno.Trim)
            dt = bao.SP_SPM_SYSTEM_DETAIL_SHOW_SEARCH(refno.Trim, "5", dao_ref.fields.SYSTEMS_ID, dao_ref.fields.PAYMENT_TYPE)
            If dt.Rows(0).Item("IDENTIFY_AUTHERIZED").ToString.Trim = identify.Trim Then

                If dt.Rows(0).Item("STATUS_ID").ToString = "8" And dt.Rows(0).Item("STAMP_STATUS").ToString <> 0 And dt.Rows(0).Item("STAMP_STATUS").ToString <> system Then
                    CHK_STATUS = "เลขอ้างอิงนี้ถูกใช้แล้วโดยกองอื่น"
                ElseIf dt.Rows(0).Item("STATUS_ID").ToString = "8" And dt.Rows(0).Item("STAMP_SYSTEMS").ToString = "0" And (dt.Rows(0).Item("STAMP_STATUS").ToString = "0" Or dt.Rows(0).Item("STAMP_STATUS").ToString = system) Then
                    CHK_STATUS = 0
                ElseIf dt.Rows(0).Item("STATUS_ID").ToString = "8" And dt.Rows(0).Item("STAMP_SYSTEMS").ToString <> "0" Then
                    CHK_STATUS = "เลขอ้างอิงนี้ถูกใช้งานแล้ว"
                ElseIf dt.Rows(0).Item("STATUS_ID").ToString = "9" And dt.Rows(0).Item("STAMP_SYSTEMS").ToString <> "0" Then
                    CHK_STATUS = "เลขอ้างอิงนี้ถูกใช้งานแล้ว"
                ElseIf dt.Rows(0).Item("STATUS_ID").ToString = "9" And dt.Rows(0).Item("STAMP_SYSTEMS").ToString = "0" Then
                    CHK_STATUS = 0
                    Dim dao As New DAO_SP_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
                    dao.GetDataby_IDA(dt.Rows(0).Item("IDA").ToString)
                    dao.fields.STAMP_SYSTEMS = system
                    dao.update()
                ElseIf dt.Rows(0).Item("STATUS_ID").ToString = "2" Then
                    CHK_STATUS = "เลขอ้างอิงนี้ยังไม่ถูกชำระเงิน หรือ ชำระเป็นเช็คที่ยังไม่ครบกำหนดจ่าย"
                Else
                    CHK_STATUS = "ไม่พบข้อมูล"
                End If
            Else
                CHK_STATUS = "เลขนิติบุคคล/เลขบัตรประชาชนไม่สอดคล้องกัน กรุณาตรวจสอบใหม่"
            End If
        Catch ex As Exception
            CHK_STATUS = "มีข้อผิดพลาด"
        End Try
        Return CHK_STATUS
    End Function
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
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function

    Sub Bind_Day()
        Try
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
            dao.GetDataby_type(ddl_category_requests.SelectedValue)
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
    Function Chk_ref_no(ByVal ref_no As String) As Boolean
        Dim bool As Boolean = True
        Dim i As Integer = 0
        Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
        i = dao.Count_Ref_no(ref_no)
        If i > 0 Then
            bool = False
        End If
        If ref_no = "" Then
            bool = False
        End If
        Return bool
    End Function

    Protected Sub btn_day_Click(sender As Object, e As EventArgs) Handles btn_day.Click
        Bind_Date()
    End Sub

    Protected Sub ddl_WORK_GROUP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_WORK_GROUP.SelectedIndexChanged
        bind_ddl_category()
        Bind_Day()
        Bind_Date()
    End Sub

    Protected Sub btn_chk_r_no_Click(sender As Object, e As EventArgs) Handles btn_chk_r_no.Click
        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        dao.get_data_by_rno(txt_r_no.Text)
        Dim i As Integer = 0
        For Each dao.fields In dao.datas
            i += 1
        Next
        If i > 0 Then
            bind_ddl_WORK_GROUP()
            Try
                'If dao.fields.WORK_GROUP = 0 Then
                Dim dao_req As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                dao_req.GetDataby_type(dao.fields.TYPE_REQUEST)
                ddl_WORK_GROUP.DropDownSelectData(dao_req.fields.NEW_WORK_GROUP)
                'Else
                '    ddl_WORK_GROUP.DropDownSelectData(dao.fields.WORK_GROUP)
                'End If

            Catch ex As Exception

            End Try
            bind_ddl_category()
            Try
                ddl_category_requests.DropDownSelectData(dao.fields.TYPE_REQUEST)
            Catch ex As Exception

            End Try
            txt_company.Text = dao.fields.CITIZEN_AUTHIRIZE
            txt_DRUG_NAME_THAI.Text = dao.fields.TRADENAME
            txt_DRUG_NAME_ENG.Text = dao.fields.TRADENAME_ENG
            lbl_company.Text = dao.fields.ALLOW_NAME
            txt_lcnno.Text = dao.fields.LCNNO_DISPLAY
            HiddenField1.Value = dao.fields.IDA
            Try
                txt_staff_iden.Text = dao.fields.STAFF_IDENTIFY
            Catch ex As Exception

            End Try


            If lbl_company.Text = "" Then
                lbl_company.Text = set_name_company(txt_company.Text)
            End If
            Try
                lbl_staff.Text = set_name_company(txt_staff_iden.Text)
            Catch ex As Exception

            End Try

            Bind_Day()
            Bind_Date()
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If
    End Sub

    Private Sub ddl_category_requests_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_category_requests.SelectedIndexChanged
        Bind_Day()
        Bind_Date()
    End Sub

    Protected Sub btn_staff_Click(sender As Object, e As EventArgs) Handles btn_staff.Click
        lbl_staff.Text = set_name_company(txt_staff_iden.Text)
    End Sub
End Class