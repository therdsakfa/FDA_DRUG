Imports Telerik.Web.UI

Public Class FRM_REPLACEMENT_DRUG_BOOKING_INSERT_ALL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunSession()

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
            rdp_date.SelectedDate = Date.Now.ToShortDateString
            bind_all()
        End If


    End Sub

    Private Sub bind_all()
        ' bind_rcb_doc()
        Try
            bind_ddl_SERVICE()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Btn_back_Click(sender As Object, e As EventArgs) Handles Btn_back.Click
        Try
            Response.Redirect("FRM_REPLACEMENT_BOOKING.aspx")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub bind_rcb_doc()
        Try
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_MAS_PROCESS_by_SYSTEM_ID_and_WORK_GROUP_ID("1", ddl_SERVICE.SelectedItem.Value)

            ddl_process.DataTextField = "PROCESS_SHOW"
            ddl_process.DataValueField = "PROCESS_ID"
            ddl_process.DataSource = dt
            ddl_process.DataBind()
            ddl_process.Items.Insert(0, New ListItem("กรุณาเลือกกระบวนการ", "0"))
        Catch ex As Exception

        End Try


    End Sub

    Private Sub bind_ddl_SERVICE()
        Try
            Dim dao As New DAO_BOOKING.TB_MAS_WORK_GROUP
            dao.GetDataby_DEPARTMENT_TYPE_ID("1")

            ddl_SERVICE.DataTextField = "WORK_GROUP_NAME"
            ddl_SERVICE.DataValueField = "WORK_GROUP_ID"
            ddl_SERVICE.DataSource = dao.datas
            ddl_SERVICE.DataBind()
            ddl_SERVICE.Items.Insert(0, New ListItem("กรุณาเลือกกลุ่มงาน", "0"))

            '     rcb_doc.Items(3).IsSeparator = "True"
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub Btn_confirm_Click(sender As Object, e As EventArgs) Handles Btn_confirm.Click

        Dim dao As New DAO_BOOKING.TB_DRUG_SCHEDULE
        Dim bao_gen As New BAO.GenNumber
        Dim WS_INSERT_R_NO As New BAO.WS_REQUEST_NO_BOOKING
        Dim WS_INSERT_C_NO As New BAO.WS_REQUEST_NO_BOOKING
        Dim r_no As String = String.Empty
        Dim c_no As String = String.Empty
        Dim RCVNO As Integer

        Dim SYSTEM_ID As String = String.Empty
        Dim PROCESS_ID As String = String.Empty

        SYSTEM_ID = "1"
        PROCESS_ID = ddl_process.SelectedItem.Value

        Try
            If ddl_process.SelectedItem.Value = "0" Then
                alert("กรุณาเลือกกระบวนงานตามที่ต้องชำระเงินก่อน")
            ElseIf String.IsNullOrEmpty(txt_name.Text) = True Then
                alert("กรุณาเลือกชื่อผู้ประกอบการ ")
            Else
                r_no = WS_INSERT_R_NO.WS_INSERT_R_NO(ddl_process.SelectedItem.Value, txt_identify.Text, txt_no_visitor.Text, txt_location_name.Text, txt_location_address.Text, _CLS.PVCODE, "")
                c_no = WS_INSERT_C_NO.WS_INSERT_C_NO(r_no, "")


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

                dao.fields.BOOKING_FULL_NAME = txt_name.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.COMPANY_NAME
                dao.fields.SCHEDULE_DATE = CDate(rdp_date.SelectedDate) 'Date.Now()
                dao.fields.BOOKING_DATE = Date.Now()
                dao.fields.PROCESS_ID = ddl_process.SelectedItem.Value 'dao_SYSTEMS_PAYMENT_DETAIL.fields.REQUSET_ID
                dao.fields.PROCESS_NAME = ddl_process.SelectedItem.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.REQUEST_SHOW
                dao.fields.DOCUMENT_TYPE_NAME = ddl_process.SelectedItem.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.REQUEST_SHOW

                'dao.fields.SCHEDULE_STAFF_FULL_NAME = dao_SYSTEMS_PAYMENT_DETAIL.fields.NAME_STAFF
                'dao.fields.SCHEDULE_STAFF_ID = dao_SYSTEMS_PAYMENT_DETAIL.fields.CITIZEN_STAFF
                'dao.fields.BOOKING_IDENTIFICATION_NAME = dao_SYSTEMS_PAYMENT_DETAIL.fields.NAME_REQUEST
                'dao.fields.BOOKING_IDENTIFICATION_CARD_NO = dao_SYSTEMS_PAYMENT_DETAIL.fields.CITIZEN_REQUEST
                dao.fields.BOOKING_SUBSTITUTE_NAME = txt_name.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.COMPANY_NAME
                dao.fields.BOOKING_SUBSTITUTE_NO = txt_identify.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.IDENTIFY_AUTHERIZED
                'dao.fields.PRODUCT_ID = txt_num.Text
                'dao.fields.PRODUCT_ID_IDA = dao_SYSTEMS_PAYMENT_DETAIL.fields.IDA
                dao.fields.SCHEDULE_REMARK = txt_remark.Text
                dao.fields.THAINAMEPLACE = txt_location_name.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_NAME
                dao.fields.LOCATION_ADDRESS_FULL_ADDR = txt_location_address.Text 'dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_ADDRESS
                'dao.fields.LOCATION_ADDRESS_IDA = dao_SYSTEMS_PAYMENT_DETAIL.fields.LOCATION_IDA
                dao.fields.WORK_GROUP_IDA = ddl_SERVICE.SelectedItem.Value
                dao.fields.WORK_GROUP_NAME = ddl_SERVICE.SelectedItem.Text
                dao.fields.VISITOR_IDENTIFICATION_CARD_NO = txt_no_visitor.Text
                dao.fields.VISITOR_IDENTIFICATION_NAME = txt_name_visitor.Text
                dao.fields.STAFF_IDENTIFICATION_CARD_NO = _CLS.CITIZEN_ID
                dao.fields.STAFF_IDENTIFICATION_NAME = _CLS.THANM
                dao.fields.SYSTEM_ID = "1"

                Dim bao_CAL_DATE As New BAO.CAL_DATE
                Dim CONSIDER_DAY As Integer = 0
                Dim CONSIDER_DATE As Date
                CONSIDER_DATE = bao_CAL_DATE.TOTAL_DATE_DRUG(bao_CAL_DATE.TOTAL_LAG_DRUG(Date.Now, ddl_process.SelectedItem.Value, "1"), ddl_process.SelectedItem.Value, "1", CONSIDER_DAY)
                dao.fields.CONSIDER_DAY = CONSIDER_DAY
                dao.fields.CONSIDER_DATE = CONSIDER_DATE
                dao.fields.CONSIDER_DATE_DISPLAY = CONSIDER_DATE.ToLongDateString

                Try
                    dao.fields.SCHEDULE_TIME_START = rtp_time_start.SelectedDate.Value.ToShortTimeString
                    dao.fields.SCHEDULE_TIME_END = rtp_time_end.SelectedDate.Value.ToShortTimeString
                Catch ex As Exception

                End Try



                If ddl_process.SelectedItem.Value = "21101" Or ddl_process.SelectedItem.Value = "22101" Or ddl_process.SelectedItem.Value = "23101" Or ddl_process.SelectedItem.Value = "24101" Or ddl_process.SelectedItem.Value = "25101" Then
                    dao.fields.STATUS_ID = 6
                    dao.fields.CONSIDER_DAY = 0
                    dao.fields.CONSIDER_DATE = CDate(rdp_date.SelectedDate)
                    dao.fields.CONSIDER_DATE_DISPLAY = CDate(rdp_date.SelectedDate).ToLongDateString
                Else
                    dao.fields.STATUS_ID = 1
                End If



                'dao.fields.RCVNO_DISPLAY = "NCT-" & "N" & "-2560-1"
                'dao.fields.RCVNO = "6000001"


                'Dim CONSIDER_DAY As Integer = 2
                'dao.fields.CONSIDER_DAY = CONSIDER_DAY
                'dao.fields.CONSIDER_DATE = Date.Now.AddDays(CONSIDER_DAY)
                'dao.fields.CONSIDER_DATE_DISPLAY = Date.Now.AddDays(CONSIDER_DAY).ToLongDateString

                'Dim ALLOW_DAY As Integer = 2
                'dao.fields.ALLOW_DAY = ALLOW_DAY
                'dao.fields.ALLOW_DATE = Date.Now.AddDays(ALLOW_DAY)
                'dao.fields.ALLOW_DATE_DISPLAY = Date.Now.AddDays(ALLOW_DAY).ToLongDateString

                dao.insert()

                '---------------------------------------------
                Dim dao_update As New DAO_BOOKING.TB_DRUG_SCHEDULE
                dao_update.GetDataby_SCHEDULE_ID(dao.fields.SCHEDULE_ID)
                dao_update.fields.HEAD_SCHEDULE_ID = dao.fields.SCHEDULE_ID

                RCVNO = bao_gen.GEN_DRUG_RCVNO_NO(con_year_2(), _CLS.PVCODE, dao.fields.PROCESS_ID, dao.fields.SCHEDULE_ID)
                dao_update.fields.RCVNO = bao_gen.FORMAT_NUMBER_FULL(con_year_2(), RCVNO)
                dao_update.fields.RCVNO_DISPLAY = bao_gen.FORMAT_NUMBER_BOOKING("DRUG", dao.fields.PROCESS_ID, con_year_2(), RCVNO)

                dao_update.update()
                '-------------------------------------------------

                alert_window_open_self("ลงนัดหมายเรียบร้อยแล้ว เลขR คือ " & r_no & "และเลข C คือ " & c_no, "FRM_REPLACEMENT_BOOKING.aspx")
            End If
        Catch ex As Exception
            alert("กรุณากรอกข้อมูลให้ถูกต้อง")
        End Try
    End Sub


    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")

    End Sub

    Private Sub alert_window_open_self(ByVal text As String, ByVal URL As String)
        Response.Write("<script type='text/javascript'>alert('" & text & "');window.open('" & URL & "','_self');</script> ")

    End Sub


    Protected Sub btn_data_txt_no_Click(sender As Object, e As EventArgs) Handles btn_data_txt_no.Click
        Try
            lbl_modal.Text = "เลือกข้อมูลผู้มาติดต่อ"
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_DRUG_BOOKING_VISITOR.aspx');", True)

        Catch ex As Exception

        End Try

        'Dim dao As New DAO.TB_syslcnsnm
        'Dim taxno As String = String.Empty
        'Dim fullname As String

        'taxno = txt_no_visitor.Text
        'If String.IsNullOrEmpty(taxno) = True Then
        '    alert("กรุณากรอกเลขบัตรประชาชน")
        'ElseIf taxno.Length <> 13 Then
        '    alert("กรุณากรอกเลขบัตรประชาชนให้ครบ 13 หลัก")
        'Else
        '    dao.GetDataby_identify(taxno)
        '    If dao.fields.ID = 0 Then
        '        alert("ไม่พบเลขบัตรประชาชนนี้ กรุณาตรวจสอบเลขบัตรประชาชน")
        '    Else
        '        If String.IsNullOrEmpty(dao.fields.thalnm) = True Or dao.fields.thalnm = Nothing Then
        '            fullname = dao.fields.thanm
        '        Else
        '            fullname = dao.fields.thanm & " " & dao.fields.thalnm
        '        End If

        '        If String.IsNullOrEmpty(dao.fields.prefixnm) = True Or dao.fields.prefixnm = Nothing Then
        '            fullname = dao.fields.prefixnm2 & " " & fullname
        '        Else
        '            fullname = dao.fields.prefixnm & " " & fullname
        '        End If
        '        txt_name_visitor.Text = fullname
        '    End If

        'End If

    End Sub

    Protected Sub btn_customer_Click(sender As Object, e As EventArgs) Handles btn_customer.Click
        Try
            lbl_modal.Text = "เลือกข้อมูลผู้ประกอบการ"
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_DRUG_BOOKING_CUSTOMER.aspx');", True)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_address_Click(sender As Object, e As EventArgs) Handles btn_address.Click
        Try
            Dim IDENTIFY As String = String.Empty
            IDENTIFY = txt_identify.Text

            If IDENTIFY = "" Then
                alert("กรุณาเลือกผู้ประกอบการก่อน")
            Else
                lbl_modal.Text = "เลือกข้อมูลสถานที่"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_DRUG_BOOKING_ADDRESS.aspx?IDENTIFY=" & IDENTIFY & "');", True)

            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_address_reload_Click(sender As Object, e As EventArgs) Handles btn_address_reload.Click
        Try
            txt_location_name.Text = _CLS.LOCATION_NAME
            txt_location_address.Text = _CLS.LOCATION_ADDRESS
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btn_customer_reload_Click(sender As Object, e As EventArgs) Handles btn_customer_reload.Click
        Try
            txt_identify.Text = _CLS.IDENTIFY
            txt_name.Text = _CLS.NAME

            txt_location_name.Text = ""
            txt_location_address.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_reload_visitor_Click(sender As Object, e As EventArgs) Handles btn_reload_visitor.Click
        Try
            txt_no_visitor.Text = _CLS.IDENTIFY_VISITOR
            txt_name_visitor.Text = _CLS.NAME_VISITOR
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub ddl_SERVICE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_SERVICE.SelectedIndexChanged
        Try
            bind_rcb_doc()
        Catch ex As Exception

        End Try

    End Sub




    Protected Sub rcb_doc_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If ddl_process.SelectedItem.Value = "21101" Or ddl_process.SelectedItem.Value = "22101" Or ddl_process.SelectedItem.Value = "23101" Or ddl_process.SelectedItem.Value = "24101" Or ddl_process.SelectedItem.Value = "25101" Then
                pn_date.Visible = True
            Else
                pn_date.Visible = False
            End If
        Catch ex As Exception

        End Try


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