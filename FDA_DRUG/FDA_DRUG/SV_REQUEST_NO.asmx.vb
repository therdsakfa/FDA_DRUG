Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class SV_REQUEST_NO
    Inherits System.Web.Services.WebService
    Private PROCESS_ID As String = "1007001"

    <WebMethod()> _
    Public Function WS_INSERT_A_NO(ByVal r_no As String, ByVal ref_no As String, ByVal _appdate As Date) As String

        Dim no_return As String = ""
        If r_no = "" Then
            no_return = "Empty Data"
        Else
            Dim count_c As Integer = 0
            Dim dao_count_c As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            count_c = dao_count_c.Count_R(r_no)

            Dim count_r_c As Integer = 0
            Dim dao_count_r_c As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            count_r_c = dao_count_r_c.GetDataby_R_and_C(r_no)

            If count_c <= 1 Then
                If count_r_c <= 1 Then
                    'Dim result As String = ""
                    'Dim ws2 As New SV_CHK_PAYMENT.SV_CHECK_PAYMENT
                    'result = ws2.CHECK_PAYMENT(txt_ref_no.Text, txt_company.Text, 1)
                    'If result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Or result = "บันทึกข้อมูลการชำระเงินเรียบร้อย" Then

                    Dim dao_rc As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                    dao_rc.get_data_by_rno(r_no)
                    Dim i As Integer = 0
                    For Each dao_rc.fields In dao_rc.datas
                        i += 1
                    Next

                    Dim dao_req As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                    Try

                        dao_req.GetDataby_type(dao_rc.fields.TYPE_REQUEST)

                    Catch ex As Exception

                    End Try

                    Dim ws As New WS_GETDATE_WORKING.Service1
                    Dim DAO As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                    Dim bao As New BAO.GenNumber
                    Dim date_result As Date

                    Dim dao_WORK_GROUP As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
                    dao_WORK_GROUP.GetDataby_IDA(dao_req.fields.NEW_WORK_GROUP)

                    Dim dao_days As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                    dao_days.GetDataby_type(dao_rc.fields.TYPE_REQUEST)

                    Dim days As Integer = 0
                    Try
                        days = dao_days.fields.DAY_WORK
                    Catch ex As Exception

                    End Try
                    Try
                        ws.GETDATE_WORKING(CDate(_appdate), True, days, True, date_result, True)

                    Catch ex As Exception

                    End Try

                    '---------------------------------------------------
                    'If String.IsNullOrEmpty(_appdate) = False _
                    ' And String.IsNullOrEmpty(lbl_number_day.Text) = False And String.IsNullOrEmpty(txt_company.Text) = False _
                    ' And String.IsNullOrEmpty(lbl_company.Text) = False Then  'ใช้ฟังก์ชั่น เช๊คค่าว่างของ text ตัวนั้น


                    DAO.fields.STAFF_IDENTIFY = ""
                    DAO.fields.TYPE_REQUESTS = dao_rc.fields.TYPE_REQUEST
                    DAO.fields.TYPE_REQUESTS_NAME = dao_days.fields.TYPE_REQUESTS_NAME
                    DAO.fields.REQUESTS_DATE = CDate(_appdate)
                    DAO.fields.ALLOW_NAME = set_name_company(dao_rc.fields.CITIZEN_AUTHIRIZE)
                    DAO.fields.REQUESTS_AUTHORITIES = "" 'ชื่อจนท.ที่ออกเลข dao_WORK_GROUP.fields.WORK_GROUP
                    DAO.fields.RESPONSIBLE_AUTHORITIES = dao_WORK_GROUP.fields.WORK_GROUP
                    DAO.fields.CONREQ_CREATION_DATE = Date.Now
                    DAO.fields.CONREQ_LAST_UPDATE = date_result
                    DAO.fields.CONREQ_PDF_NAME = PROCESS_ID
                    DAO.fields.CONREQ_APPOINTMENT_DATE = date_result
                    DAO.fields.CONREQ_NUMBER_DAY = days

                    DAO.fields.REQUESTS_DATE_DISPLAY = CDate(_appdate).ToLongDateString()

                    DAO.fields.CITIZEN_ID_AUTHORIZE = dao_rc.fields.CITIZEN_AUTHIRIZE
                    Try
                        DAO.fields.CITIZEN_ID_REQUESTS = dao_rc.fields.CITIZEN_ID
                    Catch ex As Exception

                    End Try

                    DAO.fields.WORK_GROUP_NAME = dao_WORK_GROUP.fields.WORK_GROUP
                    DAO.fields.WORK_GROUP_ID = dao_WORK_GROUP.fields.IDA


                    DAO.fields.TXT_LCNNO = dao_rc.fields.LCNNO_DISPLAY
                    DAO.fields.SUB_TYPE_REQUESTS = ""

                    DAO.fields.DRUG_NAME_ENG = dao_rc.fields.TRADENAME_ENG
                    DAO.fields.DRUG_NAME_THAI = dao_rc.fields.TRADENAME
                    Try
                        DAO.fields.PVNCD = dao_rc.fields.PVNCD
                    Catch ex As Exception

                    End Try

                    DAO.fields.REF_NO = ""

                    DAO.fields.ACTIVE = "1"
                    DAO.insert()
                    Dim _ida As Integer = DAO.fields.IDA

                    DAO = New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
                    DAO.GetDataby_IDA(_ida)
                    Dim RCVNO As String = ""
                    RCVNO = bao.GEN_NO_02_2(con_year(Date.Now.Year), dao_rc.fields.PVNCD, PROCESS_ID, "", "1", dao_rc.fields.TYPE_REQUEST, _ida, "")
                    DAO.fields.RCVNO = RCVNO
                    DAO.fields.RCVNO_DISPLAY = RCVNO & "-A"
                    Try
                        DAO.fields.REQUEST_CENTER_NO = r_no
                    Catch ex As Exception

                    End Try
                    Try
                        DAO.fields.FK_REQUEST_CENTER = dao_rc.fields.IDA
                    Catch ex As Exception

                    End Try
                    If r_no <> "" Then
                        Dim dao_r As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                        dao_r.get_data_by_rno(r_no)
                        DAO.fields.CITIZEN_AUTHIRIZE = dao_r.fields.CITIZEN_AUTHIRIZE
                        DAO.fields.CITIZEN_ID = dao_r.fields.CITIZEN_ID
                        DAO.fields.FK_LOCATION_IDA = dao_r.fields.FK_LOCATION_IDA
                    End If

                    DAO.update()

                    Dim result_c As String = ""
                    Dim ws_c As New WS_UPDATE_C.Service1
                    'Dim ws_c As New WS_UPDATE_C_DEMO.Service1
                    Try
                        result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(r_no)
                        'result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(txt_r_no.Text)
                    Catch ex As Exception

                    End Try


                    no_return = "Success"


                    'Else
                    '    alertERROR("ไม่สามารถบันทึกข้อมูล กรุณาตรวจสอบข้อมูล")
                    'End If
                    '---------------------------------
                    'Else
                    '    alertERROR(result)
                    'End If


                Else
                    no_return = "Duplicate"
                End If

            Else
                no_return = "R Duplicate"
            End If

        End If
        Return no_return
    End Function
    <WebMethod()> _
    Public Function WS_INSERT_C_NO(ByVal r_no As String, ByVal ref_no As String) As String
        Dim bool As Boolean = chk_r_exist(r_no)
        Dim no_return As String = ""
        If bool = True Then
            Dim dao_fk As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao_fk.get_data_by_rno(r_no)
            Dim FK_IDA As Integer = 0
            Try
                FK_IDA = dao_fk.fields.IDA
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao.GetDataby_IDA(FK_IDA)
            Dim dao_in As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao_in.fields.CITIZEN_AUTHIRIZE = dao.fields.CITIZEN_AUTHIRIZE
            dao_in.fields.CITIZEN_ID = dao.fields.CITIZEN_ID
            Try
                dao_in.fields.CITIZEN_UPLOAD = dao.fields.CITIZEN_UPLOAD
            Catch ex As Exception

            End Try

            Try
                dao_in.fields.FK_LOCATION_IDA = dao.fields.FK_LOCATION_IDA
            Catch ex As Exception
                dao_in.fields.FK_LOCATION_IDA = 0
            End Try
            Try
                dao_in.fields.FK_PRODUCT_IDA = dao.fields.FK_PRODUCT_IDA
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.LCN_IDA = dao.fields.LCN_IDA
            Catch ex As Exception

            End Try

            Try
                dao_in.fields.PLACENAME = dao.fields.PLACENAME
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.PVNCD = dao.fields.PVNCD
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.REQUEST_DATE = Date.Now
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.fulladdr = dao.fields.fulladdr
            Catch ex As Exception

            End Try
            dao_in.fields.TRADENAME = dao.fields.TRADENAME
            dao_in.fields.TRADENAME_ENG = dao.fields.TRADENAME_ENG
            dao_in.fields.TYPE_REQUEST = dao.fields.TYPE_REQUEST
            dao_in.fields.TYPE_REQUEST_NAME = dao.fields.TYPE_REQUEST_NAME
            dao_in.fields.WORK_GROUP = dao.fields.WORK_GROUP
            dao_in.fields.ALLOW_NAME = dao.fields.ALLOW_NAME
            dao_in.fields.LCNNO_DISPLAY = dao.fields.LCNNO_DISPLAY
            dao_in.fields.PRODUCT_ID = dao.fields.PRODUCT_ID

            dao_in.fields.OTHER_DETAIL = dao.fields.OTHER_DETAIL
            dao_in.fields.TABEAN_DISPLAY = dao.fields.TABEAN_DISPLAY
            dao_in.fields.ACTIVE = "1"
            dao_in.fields.REF_NO = ref_no
            dao_in.insert()
            Dim ida As Integer = 0
            Try
                ida = dao_in.fields.IDA
            Catch ex As Exception

            End Try

            dao = New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao.GetDataby_IDA(ida)
            Dim bao As New BAO.GenNumber
            Dim rcvno As String = ""
            Dim rcvno_display As String = ""
            Dim pvncd As Integer = 0
            Try
                pvncd = dao_fk.fields.PVNCD
            Catch ex As Exception

            End Try
            rcvno = bao.GEN_RCVNO_REQUEST(con_year(Date.Now.Year), pvncd, "2", dao_fk.fields.LCNNO_DISPLAY, "", dao_fk.fields.TYPE_REQUEST, ida, dao_fk.fields.TYPE_REQUEST_NAME)

            dao.fields.RCVNO = rcvno
            dao.fields.RCVNO_DISPLAY = rcvno & "-C"
            dao.fields.REQUEST_CENTER_TYPE = 2
            no_return = rcvno & "-C"
            Try
                dao.fields.HEAD_IDA = FK_IDA
            Catch ex As Exception

            End Try
            dao.update()

        Else
            no_return = "Not Found"
        End If
        Return no_return
    End Function

    <WebMethod()> _
    Public Function WS_INSERT_R_NO(ByVal process_no As String, ByVal CITIZEN_AUTHIRIZE As String, ByVal CITIZEN_ID As String, ByVal nameplace As String, _
                        ByVal addr As String, ByVal pvncd As Integer, ByVal ref_no As String) As String
        'Dim bool As Boolean = chk_r_exist(r_no)
        Dim no_return As String = ""
        If process_no = "" Then
            no_return = "Not Found"
        Else
            Dim dao_re1 As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
            dao_re1.GetDataby_CD(process_no)

            Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            set_data(dao, CITIZEN_AUTHIRIZE, CITIZEN_ID, nameplace, addr, pvncd)
            dao.fields.TYPE_REQUEST = process_no
            dao.fields.REF_NO = ref_no
            dao.fields.ACTIVE = "1"
            dao.fields.WORK_GROUP = dao_re1.fields.NEW_WORK_GROUP
            dao.insert()
            Dim ida As Integer = 0
            Try
                ida = dao.fields.IDA
            Catch ex As Exception

            End Try

            dao = New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            dao.GetDataby_IDA(ida)
            Dim bao As New BAO.GenNumber
            Dim rcvno As String = ""
            Dim rcvno_display As String = ""
            Dim dao_re As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
            dao_re.GetDataby_CD(process_no)
            Dim type_req As String = ""
            Try
                type_req = dao_re.fields.TYPE_REQUESTS_NAME
            Catch ex As Exception

            End Try
            rcvno = bao.GEN_RCVNO_REQUEST(con_year(Date.Now.Year), pvncd, "1", "", "", process_no, ida, type_req)
            dao.fields.RCVNO = rcvno
            dao.fields.RCVNO_DISPLAY = rcvno & "-R"
            dao.fields.REQUEST_CENTER_TYPE = 1
            no_return = rcvno & "-R"
            dao.update()
        End If
        Return no_return
    End Function

    <WebMethod()> _
    Public Function WS_UPDATE_STAFF(ByVal rc_no As String, ByVal identify As String) As String
        Dim result As String = ""
        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        If dao.fields.IDA <> 0 Then
            If identify = "" Then
                result = "Not Found"
            Else
                dao.get_data_by_rno(rc_no)

                dao.fields.STAFF_IDENTIFY = identify
                dao.update()
                result = "Success"
            End If

        Else
            result = "Not Found"
        End If
        Return result
    End Function
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DRUG_REQUEST_CENTER, ByVal CITIZEN_AUTHIRIZE As String, ByVal CITIZEN_ID As String, ByVal nameplace As String, _
                        ByVal addr As String, ByVal pvncd As Integer)
        dao.fields.CITIZEN_AUTHIRIZE = CITIZEN_AUTHIRIZE
        dao.fields.CITIZEN_ID = CITIZEN_ID
        dao.fields.CITIZEN_UPLOAD = CITIZEN_ID
        dao.fields.FK_LOCATION_IDA = 0
        dao.fields.FK_PRODUCT_IDA = 0
        dao.fields.LCN_IDA = 0
        dao.fields.PVNCD = pvncd
        dao.fields.PLACENAME = nameplace

        dao.fields.fulladdr = addr
        Try
            dao.fields.REQUEST_DATE = Date.Now
        Catch ex As Exception

        End Try
    End Sub

    Private Sub set_data(ByVal FK_IDA As Integer)
        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        dao.GetDataby_IDA(FK_IDA)
        Dim dao_in As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        dao_in.fields.CITIZEN_AUTHIRIZE = dao.fields.CITIZEN_AUTHIRIZE
        dao_in.fields.CITIZEN_ID = dao.fields.CITIZEN_ID
        Try
            dao_in.fields.CITIZEN_UPLOAD = dao.fields.CITIZEN_UPLOAD
        Catch ex As Exception

        End Try

        Try
            dao_in.fields.FK_LOCATION_IDA = dao.fields.FK_LOCATION_IDA
        Catch ex As Exception
            dao_in.fields.FK_LOCATION_IDA = 0
        End Try
        Try
            dao_in.fields.FK_PRODUCT_IDA = dao.fields.FK_PRODUCT_IDA
        Catch ex As Exception

        End Try
        Try
            dao_in.fields.LCN_IDA = dao.fields.LCN_IDA
        Catch ex As Exception

        End Try

        Try
            dao_in.fields.PLACENAME = dao.fields.PLACENAME
        Catch ex As Exception

        End Try
        Try
            dao_in.fields.PVNCD = dao.fields.PVNCD
        Catch ex As Exception

        End Try
        Try
            dao_in.fields.REQUEST_DATE = Date.Now
        Catch ex As Exception

        End Try

        dao_in.fields.TRADENAME = dao.fields.TRADENAME
        dao_in.fields.TRADENAME_ENG = dao.fields.TRADENAME_ENG
        dao_in.fields.TYPE_REQUEST = dao.fields.TYPE_REQUEST
        dao_in.fields.TYPE_REQUEST_NAME = dao.fields.TYPE_REQUEST_NAME
        dao_in.fields.WORK_GROUP = dao.fields.WORK_GROUP
        dao_in.fields.ALLOW_NAME = dao.fields.ALLOW_NAME
        dao_in.fields.LCNNO_DISPLAY = dao.fields.LCNNO_DISPLAY
        dao_in.fields.PRODUCT_ID = dao.fields.PRODUCT_ID

        dao_in.fields.OTHER_DETAIL = dao.fields.OTHER_DETAIL
        dao_in.fields.TABEAN_DISPLAY = dao.fields.TABEAN_DISPLAY
    End Sub
    Private Function chk_r_exist(ByVal r_no As String) As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        dao.get_data_by_rno(r_no)
        Dim i As Integer = 0
        For Each dao.fields In dao.datas
            i += 1
        Next
        If i > 0 Then
            bool = True
        End If
        Return bool
    End Function
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
End Class