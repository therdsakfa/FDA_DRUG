Imports Telerik.Web.UI

Public Class FRM_REPLACEMENT_BOOKING_INSERT
    Inherits System.Web.UI.Page
    Private _DEPARTMENT_TYPE_ID As String
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Sub RunAppSettings()
        _DEPARTMENT_TYPE_ID = "1" 'System.Configuration.ConfigurationManager.AppSettings("DEPARTMENT_TYPE_ID")
    End Sub
    Private Sub RunSession()
        _IDA = Request.QueryString("SCHEDULE_ID")
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
        RunSession()
        If Not IsPostBack Then

            bind_ddl_SERVICE()

            'bind_rcb_num()
        End If
    End Sub

    Protected Sub Btn_back_Click(sender As Object, e As EventArgs) Handles Btn_back.Click
        Response.Redirect("FRM_REPLACEMENT_BOOKING.aspx")
    End Sub

    'Private Sub bind_rcb_num()
    '    Dim dao_SYSTEMS_PAYMENT_DETAIL As New DAO.TB_SYSTEMS_PAYMENT_DETAIL
    '    dao_SYSTEMS_PAYMENT_DETAIL.GetDataby_SYSTEMS_ID_ALL("1")

    '    rcb_num.DataTextField = "REF_NO"
    '    rcb_num.DataValueField = "REF_NO"
    '    rcb_num.DataSource = dao_SYSTEMS_PAYMENT_DETAIL.datas
    '    rcb_num.DataBind()
    '    ' rcb_num.Items.Insert(0, New RadComboBoxItem("กรุณาเลือกเลขอ้างอิง", "0"))

    '    '     rcb_doc.Items(3).IsSeparator = "True"
    'End Sub
    Private Sub bind_ddl_SERVICE()
        Try


            Dim dao As New DAO_BOOKING.TB_MAS_WORK_GROUP
            dao.GetDataby_DEPARTMENT_TYPE_ID("1")

            ddl_SERVICE.DataTextField = "WORK_GROUP_NAME"
            ddl_SERVICE.DataValueField = "WORK_GROUP_ID"
            ddl_SERVICE.DataSource = dao.datas
            ddl_SERVICE.DataBind()
            ddl_SERVICE.Items.Insert(0, New ListItem("กรุณาเลือกกลุ่มงาน", "0"))
        Catch ex As Exception

        End Try
        '     rcb_doc.Items(3).IsSeparator = "True"
    End Sub
    'Private Sub load_ddlChannel()

    '    Dim bao As New BAO.CLS_SQL_COMMAND
    '    bao.SP_CHANNEL_BY_DEPARTMENT_TYPE_ID(1)

    '    ddl_SERVICE.DataTextField = "CHANNEL_NAME"
    '    ddl_SERVICE.DataValueField = "CHANNEL_ID"
    '    ddl_SERVICE.DataSource = bao.dt

    '    ddl_SERVICE.DataBind()
    '    ddl_SERVICE.Items.Insert(0, New ListItem("ทั้งหมด", "0"))


    'End Sub

    Protected Sub Btn_confirm_Click(sender As Object, e As EventArgs) Handles Btn_confirm.Click
        Try


            Dim ws_chk As New SV_UPDATE_PAYMENT.SV_UPDATE_PAYMENT

            Dim dao As New DAO_BOOKING.TB_DRUG_SCHEDULE
            Dim WS_INSERT_R_NO As New BAO.WS_REQUEST_NO_BOOKING
            Dim WS_INSERT_C_NO As New BAO.WS_REQUEST_NO_BOOKING
            Dim r_no As String = String.Empty
            Dim c_no As String = String.Empty
            Dim bao_gen As New BAO.GenNumber
            Dim RCVNO As Integer

            Dim SYSTEM_ID As String = String.Empty
            Dim PROCESS_ID As String = String.Empty

            SYSTEM_ID = "1"
            PROCESS_ID = ddl_doc.SelectedItem.Value

            Dim dao_SYSTEMS_PAYMENT_DETAIL As New DAO_SPECIAL_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
            'dao_SYSTEMS_PAYMENT_DETAIL.GetDataby_REF_NO_STATUS_8_9(txt_num.Text, "1")
            dao_SYSTEMS_PAYMENT_DETAIL.GetDataby_REF_NO(txt_num.Text)

            Dim dao_chk As New DAO_BOOKING.TB_DRUG_SCHEDULE
            dao_chk.GetDataby_PRODUCT_ID_and_Order_By_SCHEDULE_DATE(txt_num.Text)

            If dao_SYSTEMS_PAYMENT_DETAIL.fields.IDA = 0 Then
                alert("ไม่มีเลขอ้างอิงนี้อยู่ในระบบ กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")
                '    'test
            ElseIf dao_SYSTEMS_PAYMENT_DETAIL.fields.STAMP_STATUS <> 0 Then
                alert("เลขอ้างอิงนี้ถูกใช้ไปแล้ว กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")
            ElseIf dao_chk.fields.SCHEDULE_ID <> 0 Then
                alert("เลขอ้างอิงนี้ถูกใช้ไปแล้ว กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")
                'ElseIf dao_SYSTEMS_PAYMENT_DETAIL.fields.STATUS_ID <> 8 Or dao_SYSTEMS_PAYMENT_DETAIL.fields.STATUS_ID <> 9 Then
                '    alert("เลขอ้างอิงนี้ยังไม่ชำระเงิน กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")
            ElseIf ddl_doc.SelectedItem.Value = 0 Then
                alert("กรุณาเลือกกระบวนงานตามที่ต้องชำระเงินก่อน")
            ElseIf ddl_process.SelectedItem.Value = 0 Then
                alert("กรุณาเลือกกระบวนงานตามคำขอก่อน")
            ElseIf String.IsNullOrEmpty(lbl_name.Text) = True Then
                alert("กรุณาเลือกชื่อผู้ประกอบการ ")
            Else

                '---------------------------- 
                r_no = WS_INSERT_R_NO.WS_INSERT_R_NO(ddl_process.SelectedItem.Value, dao_SYSTEMS_PAYMENT_DETAIL.fields.IDENTIFY_AUTHERIZED, dao_SYSTEMS_PAYMENT_DETAIL.fields.CITIZEN_REQUEST, dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_NAME, dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_ADDRESS, _CLS.PVCODE, txt_num.Text)
                c_no = WS_INSERT_C_NO.WS_INSERT_C_NO(r_no, txt_num.Text)

                If r_no = "Not Found" Then
                    alert("เลขอ้างอิงนี้ยังไม่ชำระเงินหรือถูกใช้ไปแล้ว กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")
                Else

                    ' dao.GetDataby_Order_By_SCHEDULE_DATE_TEST() 'หาใบที่ วันใกล้เคียงและstatus=0  และ ตรงกับกระบวนการ และ service
                    '  dao.GetDataby_SCHEDULE_ID(8348) 'test
                    dao.fields.REF_DRUG_NAME_1 = lbl_product_name.Text
                    dao.fields.REF_NUMBER_1 = r_no
                    dao.fields.REF_R_NUMBER_1 = r_no
                    dao.fields.REF_C_NUMBER_1 = c_no
                    dao.fields.REF_NUMBER_DATE_1 = Date.Now
                    dao.fields.REF_NUMBER_DATE_DISPLAY_1 = Date.Now.ToLongDateString
                    dao.fields.REF_NUMBER_IDA_1 = 0
                    dao.fields.REF_PRODUCT_ID_IDA_1 = 0
                    dao.fields.REF_PRODUCT_ID_1 = txt_product_ID.Text
                    dao.fields.REF_LCN_NUMBER_1 = txt_LCN_NUMBER.Text
                    'dao.fields.REF_DRUG_NAME_2 = "ee"
                    'dao.fields.REF_NUMBER_2 = "22"
                    'dao.fields.REF_NUMBER_DATE_2 = Date.Now
                    'dao.fields.REF_NUMBER_DATE_DISPLAY_2 = Date.Now.ToLongDateString
                    'dao.fields.REF_NUMBER_IDA_2 = "2"
                    'dao.fields.REF_PRODUCT_ID_IDA_2 = "2"
                    'dao.fields.REF_PRODUCT_ID_2 = "D-2"

                    'dao.fields.REF_DRUG_NAME_3 = "rr"
                    'dao.fields.REF_NUMBER_3 = "33"
                    'dao.fields.REF_NUMBER_DATE_3 = Date.Now
                    'dao.fields.REF_NUMBER_DATE_DISPLAY_3 = Date.Now.ToLongDateString
                    'dao.fields.REF_NUMBER_IDA_3 = "3"
                    'dao.fields.REF_PRODUCT_ID_IDA_3 = "3"
                    'dao.fields.REF_PRODUCT_ID_3 = "D-3"

                    'dao.fields.THAINAMEPLACE = "ร้านยา"
                    'dao.fields.ADMIN_GROUP_NAME = "งานใบอนุญาต"
                    'dao.fields.BOOKING_FULL_NAME = "บริษัท เทสโอนลี่ จำกัด"
                    'dao.fields.SERVICE_NAME = "ใบอนุญาต"
                    'dao.fields.SERVICE_ID = "1"
                    'dao.fields.CHANNEL_NAME = "ใบอนุญาต"
                    'dao.fields.CHANNEL_ID = ""
                    'dao.fields.DOCUMENT_TYPE_ID = ""
                    'dao.fields.DOCUMENT_TYPE_NAME = "ใบอนุญาต"
                    'dao.fields.BOOKING_IDENTIFICATION_NAME = "นาย วัชระ จำปาเงิน"
                    'dao.fields.BOOKING_SUBSTITUTE_NAME = "บริษัท เทสโอนลี่ จำกัด"
                    'dao.fields.BOOKING_IDENTIFICATION_CARD_NO = "00"
                    'dao.fields.BOOKING_SUBSTITUTE_NO = "00"



                    dao.fields.BOOKING_FULL_NAME = dao_SYSTEMS_PAYMENT_DETAIL.fields.COMPANY_NAME
                    dao.fields.SCHEDULE_DATE = Date.Now() 'CDate(txt_date.Text) '
                    dao.fields.BOOKING_DATE = Date.Now()
                    dao.fields.PROCESS_ID = ddl_process.SelectedItem.Value 'dao_SYSTEMS_PAYMENT_DETAIL.fields.REQUSET_ID
                    dao.fields.PROCESS_NAME = ddl_process.SelectedItem.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.REQUEST_SHOW
                    dao.fields.DOCUMENT_TYPE_NAME = ddl_doc.SelectedItem.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.REQUEST_SHOW
                    dao.fields.DOCUMENT_TYPE_ID = ddl_doc.SelectedItem.Value
                    dao.fields.STATUS_ID = 1
                    dao.fields.SCHEDULE_STAFF_FULL_NAME = dao_SYSTEMS_PAYMENT_DETAIL.fields.NAME_STAFF
                    dao.fields.SCHEDULE_STAFF_ID = dao_SYSTEMS_PAYMENT_DETAIL.fields.CITIZEN_STAFF
                    dao.fields.BOOKING_IDENTIFICATION_NAME = dao_SYSTEMS_PAYMENT_DETAIL.fields.NAME_REQUEST
                    dao.fields.BOOKING_IDENTIFICATION_CARD_NO = dao_SYSTEMS_PAYMENT_DETAIL.fields.CITIZEN_REQUEST
                    dao.fields.BOOKING_SUBSTITUTE_NAME = dao_SYSTEMS_PAYMENT_DETAIL.fields.COMPANY_NAME
                    dao.fields.BOOKING_SUBSTITUTE_NO = dao_SYSTEMS_PAYMENT_DETAIL.fields.IDENTIFY_AUTHERIZED
                    dao.fields.PRODUCT_ID = txt_num.Text
                    dao.fields.PRODUCT_ID_IDA = dao_SYSTEMS_PAYMENT_DETAIL.fields.IDA
                    dao.fields.SCHEDULE_REMARK = txt_remark.Text
                    dao.fields.THAINAMEPLACE = dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_NAME
                    dao.fields.LOCATION_ADDRESS_FULL_ADDR = dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_ADDRESS
                    dao.fields.LOCATION_ADDRESS_IDA = dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_IDA

                    dao.fields.WORK_GROUP_IDA = ddl_SERVICE.SelectedItem.Value
                    dao.fields.WORK_GROUP_NAME = ddl_SERVICE.SelectedItem.Text
                    dao.fields.VISITOR_IDENTIFICATION_CARD_NO = txt_no_visitor.Text
                    dao.fields.VISITOR_IDENTIFICATION_NAME = lbl_name_visitor.Text
                    dao.fields.STAFF_IDENTIFICATION_CARD_NO = _CLS.CITIZEN_ID
                    dao.fields.STAFF_IDENTIFICATION_NAME = _CLS.THANM
                    dao.fields.TEL = txt_tel.Text
                    dao.fields.EMAIL = txt_email.Text

                    Dim bao_CAL_DATE As New BAO.CAL_DATE
                    Dim CONSIDER_DAY As Integer = 0
                    Dim CONSIDER_DATE As Date
                    ' CONSIDER_DAY = CDec(bao_CAL_DATE.TOTAL_DAY_DRUG(bao_CAL_DATE.TOTAL_LAG_DRUG(Date.Now, rcb_process.SelectedItem.Value, "1"), rcb_process.SelectedItem.Value, "1"))
                    CONSIDER_DATE = bao_CAL_DATE.TOTAL_DATE_DRUG(bao_CAL_DATE.TOTAL_LAG_DRUG(Date.Now, ddl_process.SelectedItem.Value, "1"), ddl_process.SelectedItem.Value, "1", CONSIDER_DAY)

                    dao.fields.CONSIDER_DAY = CONSIDER_DAY
                    dao.fields.CONSIDER_DATE = CONSIDER_DATE
                    dao.fields.CONSIDER_DATE_DISPLAY = CONSIDER_DATE.ToLongDateString



                    Dim bao_CAL_DATE_ALLOW As New BAO.CAL_DATE
                    Dim ALLOW_DAY As Integer = 0
                    Dim ALLOW_DATE As Date
                    ALLOW_DATE = bao_CAL_DATE_ALLOW.TOTAL_ALLOW_DATE_DRUG(Date.Now, ddl_process.SelectedItem.Value, "1", ALLOW_DAY)
                    dao.fields.ALLOW_DAY = bao_CAL_DATE_ALLOW.day
                    dao.fields.ALLOW_DATE = ALLOW_DATE
                    dao.fields.ALLOW_DATE_DISPLAY = ALLOW_DATE.ToLongDateString



                    dao.insert() 'dao.update()'test

                    '---------------------------------------------
                    Try


                        Dim dao_update As New DAO_BOOKING.TB_DRUG_SCHEDULE
                        dao_update.GetDataby_SCHEDULE_ID(dao.fields.SCHEDULE_ID)
                        dao_update.fields.HEAD_SCHEDULE_ID = dao.fields.SCHEDULE_ID
                        RCVNO = bao_gen.GEN_DRUG_RCVNO_NO(con_year_2(), _CLS.PVCODE, dao.fields.PROCESS_ID, dao.fields.SCHEDULE_ID)
                        dao_update.fields.RCVNO = bao_gen.FORMAT_NUMBER_FULL(con_year_2(), RCVNO)
                        dao_update.fields.RCVNO_DISPLAY = bao_gen.FORMAT_NUMBER_BOOKING("DRUG", "D", con_year_2(), RCVNO)

                        dao_update.update()
                    Catch ex As Exception

                    End Try
                    '--------------------update กอง ที่ fee-----------------------------
                    Try


                        Dim bao_fee As New BAO.ClsDBSqlcommand
                        Dim dt_fee As New DataTable
                        Dim IDA_fee As Integer = 0
                        Dim dao_fee As New DAO_FEE.TB_fee
                        Dim dao_feedtl As New DAO_FEE.TB_feedtl

                        bao_fee.SP_BOOKING_PAYMENT_IDA_FK_IDA_and_process_id(dao_SYSTEMS_PAYMENT_DETAIL.fields.IDA, dao_SYSTEMS_PAYMENT_DETAIL.fields.PROCESS_ID)
                        dt_fee = bao_fee.dt
                        For Each dr_fee As DataRow In dt_fee.Rows
                            IDA_fee = dr_fee("IDA")
                        Next

                        dao_fee.GetDataby_IDA(IDA_fee)
                        dao_fee.fields.dvcd = _DEPARTMENT_TYPE_ID
                        dao_fee.update()

                        dao_feedtl.GetDataby_IDA(IDA_fee)
                        dao_feedtl.fields.dvcd = 1
                        dao_feedtl.update()
                    Catch ex As Exception

                    End Try
                    '---------------------------------------------------------------------------
                    '-------------ws_UPDATE_PAYMENT-----------------
                    Try


                        Dim STAMP_STATUS_PAYMENT As String = String.Empty
                        Dim ws_UPDATE_PAYMENT As New SV_UPDATE_PAYMENT.SV_UPDATE_PAYMENT
                        STAMP_STATUS_PAYMENT = ws_UPDATE_PAYMENT.STAMP_STATUS_PAYMENT(_CLS.CITIZEN_ID, txt_num.Text, 1)
                    Catch ex As Exception

                    End Try
                    '---------------------------อัพเดทสถานะเลขอ้างอิง---------------------------
                    Try
                        Dim dao_SYSTEMS_PAYMENT_DETAIL2 As New DAO_SPECIAL_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
                        dao_SYSTEMS_PAYMENT_DETAIL2.GetDataby_REF_NO(txt_num.Text)
                        If dao_SYSTEMS_PAYMENT_DETAIL2.fields.STAMP_STATUS = 0 Then
                            dao_SYSTEMS_PAYMENT_DETAIL2.fields.STAMP_STATUS = 1
                            dao_SYSTEMS_PAYMENT_DETAIL2.update()
                        End If


                    Catch ex As Exception

                    End Try

                    '------------------------------------------------------------
                    '--------------------update email ที่ sysmail-----------------------------
                    Try


                        If txt_email.Text.Trim() <> "" Then
                            Dim dao_email As New DAO_CPN.TB_sysemail
                            dao_email.GetDataby_CITIZEN_ID(txt_no_visitor.Text.Trim())
                            If dao_email.fields.IDA = 0 Then
                                dao_email.fields.CITIZEN_ID = txt_no_visitor.Text.Trim()
                                dao_email.fields.EMAIL_EGA = txt_email.Text.Trim()
                                dao_email.fields.EMAIL_FDA = txt_email.Text.Trim()
                                dao_email.fields.NAME = lbl_name_visitor.Text
                                dao_email.fields.MOBILE = txt_tel.Text.Trim
                                dao_email.fields.CREATEDATE = Date.Now
                                dao_email.fields.UPDATEDATE = Date.Now
                                dao_email.insert()

                            End If
                        End If
                    Catch ex As Exception

                    End Try

                    '---------------------------------------------------------------

                    alert_window_open_self("ลงนัดหมายเรียบร้อยแล้ว เลขR คือ " & r_no & "และเลข C คือ " & c_no, "FRM_REPLACEMENT_BOOKING.aspx")
                End If
            End If
        Catch ex As Exception
            alert("ดำเนินการผิดพลาด กรุณาลองใหม่อีกครั้ง")
        End Try
    End Sub

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")

    End Sub

    Private Sub alert_window_open_self(ByVal text As String, ByVal URL As String)
        Response.Write("<script type='text/javascript'>alert('" & text & "');window.open('" & URL & "','_self');</script> ")

    End Sub

    Protected Sub btn_data_Click(sender As Object, e As EventArgs) Handles btn_data.Click
        Try


            Dim ws_chk As New SV_UPDATE_PAYMENT.SV_UPDATE_PAYMENT

            Dim dao_SYSTEMS_PAYMENT_DETAIL As New DAO_SPECIAL_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
            '   dao_SYSTEMS_PAYMENT_DETAIL.GetDataby_REF_NO_SYSTEMS_ID(txt_num.Text, "2")
            dao_SYSTEMS_PAYMENT_DETAIL.GetDataby_REF_NO(txt_num.Text)

            If dao_SYSTEMS_PAYMENT_DETAIL.fields.IDA = 0 Then
                alert("ไม่มีเลขอ้างอิงนี้อยู่ในระบบ กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")
                '    'test
            ElseIf dao_SYSTEMS_PAYMENT_DETAIL.fields.STAMP_STATUS <> 0 Then
                alert("เลขอ้างอิงนี้ถูกใช้ไปแล้ว กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")
                'ElseIf dao_SYSTEMS_PAYMENT_DETAIL.fields.STATUS_ID <> 8 Or dao_SYSTEMS_PAYMENT_DETAIL.fields.STATUS_ID <> 9 Then
                '    alert("เลขอ้างอิงนี้ยังไม่ชำระเงิน กรุณาตรวจสอบความถูกต้องของเลขอ้างอิง")

            Else

                lbl_name.Text = dao_SYSTEMS_PAYMENT_DETAIL.fields.COMPANY_NAME
                'lbl_doc.Text = dao_SYSTEMS_PAYMENT_DETAIL.fields.REQUEST_SHOW
                lbl_location_name.Text = dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_NAME
                lbl_location_address.Text = dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_ADDRESS

                txt_no_visitor.Text = dao_SYSTEMS_PAYMENT_DETAIL.fields.CITIZEN_REQUEST
                lbl_name_visitor.Text = dao_SYSTEMS_PAYMENT_DETAIL.fields.NAME_REQUEST


                pn_data.Visible = True

                hf_PRICE.Value = dao_SYSTEMS_PAYMENT_DETAIL.fields.PRICE
                hf_SYSTEM_ID.Value = "1"

                bind_rcb_doc_by_system("1", hf_PRICE.Value)
                bind_process_by_system_and_WORK_GROUP_ID("1", ddl_SERVICE.SelectedItem.Value)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_data_txt_no_Click(sender As Object, e As EventArgs) Handles btn_data_txt_no.Click
        Try
            Dim dao As New DAO_CPN.TB_syslcnsnm
            Dim taxno As String = String.Empty
            Dim fullname As String

            taxno = txt_no_visitor.Text
            If String.IsNullOrEmpty(taxno) = True Then
                alert("กรุณากรอกเลขบัตรประชาชน")
            ElseIf taxno.Length <> 13 Then
                alert("กรุณากรอกเลขบัตรประชาชนให้ครบ 13 หลัก")
            Else
                dao.GetDataby_identify(taxno)
                If dao.fields.ID = 0 Then
                    alert("ไม่พบเลขบัตรประชาชนนี้ กรุณาตรวจสอบเลขบัตรประชาชน")
                Else
                    If String.IsNullOrEmpty(dao.fields.thalnm) = True Or dao.fields.thalnm = Nothing Then
                        fullname = dao.fields.thanm
                    Else
                        fullname = dao.fields.thanm & " " & dao.fields.thalnm
                    End If

                    If String.IsNullOrEmpty(dao.fields.prefixnm) = True Or dao.fields.prefixnm = Nothing Then
                        fullname = dao.fields.prefixnm2 & " " & fullname
                    Else
                        fullname = dao.fields.prefixnm & " " & fullname
                    End If

                    lbl_name_visitor.Text = fullname
                End If

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub bind_rcb_doc_by_system(ByVal SYSTEM_ID As String, ByVal PRICE As String)
        Try


            Dim dao As New DAO_SPECIAL_PAYMENT.TB_REQUEST_TEMPLATE
            dao.GetDataby_SYSTEMS_ID_and_PRICE(CDec(SYSTEM_ID), CDec(PRICE))

            ddl_doc.DataTextField = "REQUEST_SHOW"
            ddl_doc.DataValueField = "REQUEST_ID"
            ddl_doc.DataSource = dao.datas
            ddl_doc.DataBind()
            ddl_doc.Items.Insert(0, New ListItem("กรุณาเลือกกระบวนการ", "0"))
        Catch ex As Exception

        End Try
        '     rcb_doc.Items(3).IsSeparator = "True"
    End Sub

    Private Sub bind_process_by_system_and_WORK_GROUP_ID(ByVal SYSTEM_ID As String, ByVal WORK_GROUP_ID As String)
        Try


            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_MAS_PROCESS_by_SYSTEM_ID_and_WORK_GROUP_ID(SYSTEM_ID, WORK_GROUP_ID)

            ddl_process.DataTextField = "PROCESS_SHOW"
            ddl_process.DataValueField = "PROCESS_ID"
            ddl_process.DataSource = dt
            ddl_process.DataBind()
            ddl_process.Items.Insert(0, New ListItem("กรุณาเลือกกระบานการ", "0"))
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub bind_process_by_system(ByVal SYSTEM_ID As String)
    '    Dim dao As New DAO.TB_MAS_PROCESS
    '    dao.GetDataby_SYSTEM_ID(CDec(SYSTEM_ID))

    '    rcb_process.DataTextField = "PROCESS_NAME"
    '    rcb_process.DataValueField = "PROCESS_ID"
    '    rcb_process.DataSource = dao.datas
    '    rcb_process.DataBind()
    '    rcb_process.Items.Insert(0, New RadComboBoxItem("กรุณาเลือกชื่อคำขอ", "0"))

    '    '     rcb_doc.Items(3).IsSeparator = "True"
    'End Sub

    Protected Sub ddl_SERVICE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_SERVICE.SelectedIndexChanged
        bind_process_by_system_and_WORK_GROUP_ID("1", ddl_SERVICE.SelectedItem.Value)
    End Sub

    Protected Sub btn_data_product_id_Click(sender As Object, e As EventArgs) Handles btn_data_product_id.Click
        Try
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            If String.IsNullOrEmpty(txt_product_ID.Text) = True Then
                alert("กรุณาตรวจสอบ Product ID")
            Else
                dt = bao.SP_DRUG_PRODUCT_ID_by_PRODUCT_ID(CDec(txt_product_ID.Text))
                If dt.Rows.Count = 0 Then
                    alert("ไม่พบข้อมูล กรุณาตรวจสอบ Product ID")
                Else
                    For Each dr As DataRow In dt.Rows
                        lbl_product_name.Text = dr("TRADE_NAME")
                        'txt_LCN_NUMBER.Text = dr("")
                    Next
                End If
            End If
        Catch ex As Exception
            alert("กรุณากรอกข้อมูลให้ถูกต้อง")
        End Try
    End Sub

    Protected Sub txt_num_TextChanged(sender As Object, e As EventArgs) Handles txt_num.TextChanged
        btn_data.Focus()
    End Sub

    Protected Sub btn_data_product_id_2_Click(sender As Object, e As EventArgs) Handles btn_data_product_id_2.Click
        Try
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_DRUG_PRODUCT_ID_by_register(txt_LCN_NUMBER.Text)
            If dt.Rows.Count = 0 Then
                alert("ไม่พบข้อมูล กรุณาตรวจสอบ เลขทะเบียน")
            Else
                For Each dr As DataRow In dt.Rows
                    lbl_product_name.Text = dr("TRADE_NAME")
                Next
            End If
        Catch ex As Exception
            alert("กรุณากรอกข้อมูลให้ถูกต้อง")
        End Try

    End Sub
End Class