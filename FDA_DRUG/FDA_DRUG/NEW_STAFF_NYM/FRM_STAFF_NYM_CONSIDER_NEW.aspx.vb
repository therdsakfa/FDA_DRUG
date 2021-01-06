Public Class FRM_STAFF_NYM_CONSIDER_NEW
    Inherits System.Web.UI.Page

    Private _TR_ID As Integer

    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    Private _DL As String
    Private _edit As Integer
    Public Property _process As Integer
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            '_TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _process = Request.QueryString("process")
            _CLS = Session("CLS")
            _DL = Request.QueryString("DL")
            _edit = Request.QueryString("edit")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            TextBox1.Text = Date.Now.ToShortDateString()
            txt_app_date.Text = Date.Now.ToShortDateString()
            Bind_ddl_staff_offer()
        End If
    End Sub

    Public Sub Bind_ddl_staff_offer()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_STAFF_OFFER_DDL()

        'ddl_staff_offer.DataSource = bao.dt
        'ddl_staff_offer.DataBind()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD          ' ให้พี่ X ทำ เพราะเกี่ยวกับการ จ่ายเงิน
            Dim bao As New BAO.GenNumber
            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME

            If lbl_consider_name.Text = "" Then
                Response.Write("<script type='text/javascript'>alert('กรุณากรอกเลขบัตรผู้ลงนาม');</script> ")
            Else
                If _process = 1026 Then                                 'ถ้าเป็น NYM 1 
                    Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
                    dao.GetDataby_IDA(_IDA)
                    'If Len(_TR_ID) >= 9 Then
                    '    dao_up.GetDataby_TR_ID_Process(_TR_ID, _process)
                    'Else
                    '    dao_up.GetDataby_IDA(_TR_ID)
                    'End If
                    AddLogStatus(9, _process, _CLS.CITIZEN_ID, _IDA)
                    'AddLogStatus(6, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

                    'Dim PROCESS_ID As Integer = dao.fields.PROCESS_ID
                    Dim PROCESS_ID As Integer = _process

                    dao_p.GetDataby_Process_ID(_process)
                    Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

                    Dim CONSIDER_DATE As Date = CDate(TextBox1.Text)
                    dao.fields.REMARK = Txt_Remark.Text
                    dao.fields.STATUS_ID = 9
                    dao.fields.CONSIDER_DATE = CONSIDER_DATE

                    'dao.fields.FK_STAFF_OFFER_IDA = ddl_staff_offer.SelectedValue
                    'dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                    'dao.fields.STAFF_NAME = lbl_consider_name.Text
                    Try
                        dao.fields.appdate = CDate(txt_app_date.Text)
                    Catch ex As Exception

                    End Try
                    dao.update()


                    alert("บันทึกข้อมูลเรียบร้อย")
                Else                                                    'ถ้าเป็น NYM อื่น
                    'Dim dao As New DAO_DRUG.ClsDBdrsamp                     'ใช้ base drsamp คืออะไร งง มาก

                    If _process = 1027 Then
                        If _edit = 1 Then
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้

                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)
                            'TextBox2.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox3.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox4.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox5.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox6.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'Txt_Remark.Text = dao.fields.REMARK
                            'ddl_staff_offer.Text = dao.fields.NYM2_IDENTIFY_STAFF
                            'TextBox1.Text = dao.fields.CONSIDER_DATE
                            'txt_app_date.Text = dao.fields.ESTIMATE_CONSIDER_DATE

                            'dao.fields.REMARK = Txt_Remark.Text
                            'dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            'dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            'dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            'dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            'dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            'dao.fields.STATUS_ID = 9
                            'dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.Text
                            'dao.fields.CONSIDER_DATE = TextBox1.Text
                            'dao.fields.ESTIMATE_CONSIDER_DATE = txt_app_date.Text
                            'Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
                            'dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้
                            ' AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)        'เปลี่ยน function สีเหลืองให้อยู่ใน drug import 
                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE
                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE

                            'dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()
                            alert("บันทึกข้อมูลเรียบร้อย")
                        Else
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้
                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)        'เปลี่ยน function สีเหลืองให้อยู่ใน drug import 
                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE
                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE
                            Try

                            Catch ex As Exception

                            End Try

                            'dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()

                            alert("บันทึกข้อมูลเรียบร้อย")
                        End If
                    ElseIf _process = 1028 Then
                        If _edit = 1 Then
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้

                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)
                            'TextBox2.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox3.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox4.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox5.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox6.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'Txt_Remark.Text = dao.fields.REMARK
                            'ddl_staff_offer.Text = dao.fields.NYM2_IDENTIFY_STAFF
                            'TextBox1.Text = dao.fields.CONSIDER_DATE
                            'txt_app_date.Text = dao.fields.ESTIMATE_CONSIDER_DATE


                            'dao.fields.REMARK = Txt_Remark.Text
                            'dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            'dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            'dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            'dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            'dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            'dao.fields.STATUS_ID = 9
                            'dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.Text
                            'dao.fields.CONSIDER_DATE = TextBox1.Text
                            'dao.fields.ESTIMATE_CONSIDER_DATE = txt_app_date.Text
                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE
                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE

                            'dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()
                            alert("บันทึกข้อมูลเรียบร้อย")
                        Else
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้

                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)        'เปลี่ยน function สีเหลืองให้อยู่ใน drug import 

                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE


                            'dao_p.GetDataby_Process_ID(PROCESS_ID)                          'ไปเอาชื่อกระบวนการมา จาก base PROCESS_NAME ไม่น่าต้องแก้ไข
                            'Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE

                            'dao.fields.NYM3_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()


                            alert("บันทึกข้อมูลเรียบร้อย")
                        End If
                    ElseIf _process = 1029 Then
                        If _edit = 1 Then
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้

                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)
                            'TextBox2.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox3.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox4.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox5.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox6.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'Txt_Remark.Text = dao.fields.REMARK
                            'ddl_staff_offer.Text = dao.fields.NYM2_IDENTIFY_STAFF
                            'TextBox1.Text = dao.fields.CONSIDER_DATE
                            'txt_app_date.Text = dao.fields.ESTIMATE_CONSIDER_DATE


                            'dao.fields.REMARK = Txt_Remark.Text
                            'dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            'dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            'dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            'dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            'dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            'dao.fields.STATUS_ID = 9
                            'dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.Text
                            'dao.fields.CONSIDER_DATE = TextBox1.Text
                            'dao.fields.ESTIMATE_CONSIDER_DATE = txt_app_date.Text
                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE
                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE

                            ' dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()
                            alert("บันทึกข้อมูลเรียบร้อย")
                        Else
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้

                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)        'เปลี่ยน function สีเหลืองให้อยู่ใน drug import 

                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE


                            'dao_p.GetDataby_Process_ID(PROCESS_ID)                          'ไปเอาชื่อกระบวนการมา จาก base PROCESS_NAME ไม่น่าต้องแก้ไข
                            'Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE

                            ''dao.fields.NYM4_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()


                            alert("บันทึกข้อมูลเรียบร้อย")
                        End If
                    ElseIf _process = 1031 Then
                        If _edit = 1 Then
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้

                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)
                            'TextBox2.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox3.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox4.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox5.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'TextBox6.Text = dao.fields.POSITION_CONSIDER_LINE1
                            'Txt_Remark.Text = dao.fields.REMARK
                            'ddl_staff_offer.Text = dao.fields.NYM2_IDENTIFY_STAFF
                            'TextBox1.Text = dao.fields.CONSIDER_DATE
                            'txt_app_date.Text = dao.fields.ESTIMATE_CONSIDER_DATE


                            'dao.fields.REMARK = Txt_Remark.Text
                            'dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            'dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            'dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            'dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            'dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            'dao.fields.STATUS_ID = 9
                            'dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.Text
                            'dao.fields.CONSIDER_DATE = TextBox1.Text
                            'dao.fields.ESTIMATE_CONSIDER_DATE = txt_app_date.Text
                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE
                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE

                            ' dao.fields.NYM2_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()
                            alert("บันทึกข้อมูลเรียบร้อย")
                        Else
                            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
                            dao.GetDataby_IDA(_IDA)                                         'ดึงข้อมูลโดยใช้ IDA
                            'dao_up.GetDataby_IDA(dao.fields.TR_ID)                        'ดึง หลักฐานการจ่ายเงินมั้ง รอพี่ X แก้

                            AddLogStatustodrugimport(9, _process, _CLS.CITIZEN_ID, _IDA)        'เปลี่ยน function สีเหลืองให้อยู่ใน drug import 

                            Dim PROCESS_ID As Integer = dao.fields.NYM_TYPE


                            'dao_p.GetDataby_Process_ID(PROCESS_ID)                          'ไปเอาชื่อกระบวนการมา จาก base PROCESS_NAME ไม่น่าต้องแก้ไข
                            'Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

                            Dim CONSIDER_DATE As Date = Date.Now
                            dao.fields.REMARK = Txt_Remark.Text
                            dao.fields.POSITION_CONSIDER_LINE1 = TextBox2.Text
                            dao.fields.POSITION_CONSIDER_LINE2 = TextBox3.Text
                            dao.fields.POSITION_CONSIDER_LINE3 = TextBox4.Text
                            dao.fields.POSITION_CONSIDER_LINE4 = TextBox5.Text
                            dao.fields.POSITION_CONSIDER_LINE5 = TextBox6.Text
                            dao.fields.STATUS_ID = 9
                            dao.fields.CONSIDER_DATE = CONSIDER_DATE

                            ''dao.fields.NYM4_IDENTIFY_STAFF = ddl_staff_offer.SelectedValue
                            dao.fields.CONSIDER_IDENTIFY = txt_consider_iden.Text
                            dao.fields.STAFF_NAME = lbl_consider_name.Text
                            Try
                                dao.fields.ESTIMATE_CONSIDER_DATE = CDate(txt_app_date.Text)
                            Catch ex As Exception

                            End Try
                            dao.update()


                            alert("บันทึกข้อมูลเรียบร้อย")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_STAFFNYM_CONFIRM.aspx?IDA=" & _IDA & "&process=" & _process)

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_STAFFNYM_CONFIRM.aspx?IDA=" & _IDA & "&process=" & _process & "&DL=" & _DL)
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If Len(txt_consider_iden.Text) = 0 Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกเลขบัตรประชาชน');</script> ")
        Else
            Dim bao As New BAO_SHOW
            Dim dt As New DataTable
            dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(txt_consider_iden.Text, "0")
            For Each dr As DataRow In dt.Rows
                lbl_consider_name.Text = dr("thanm")
            Next
        End If
    End Sub
End Class