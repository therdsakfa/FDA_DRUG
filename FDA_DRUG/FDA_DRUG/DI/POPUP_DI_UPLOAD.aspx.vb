﻿Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization

Public Class POPUP_DI_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Private _lcn_ida As String
    Private _lct_ida As String
    Sub runQuery()
        _Process = Request.QueryString("process")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
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
        set_txt_label()
    End Sub

    Public Sub set_txt_label()
        UC_ATTACH_DRUG_0.get_label("ใบCER GMP")
        UC_ATTACH_DRUG_1.get_label("อื่นๆ")

    End Sub
    Public Sub _ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        UC_ATTACH_DRUG_0.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        If FileUpload1.HasFile Then
            If UC_ATTACH_DRUG_0.check() = True Then

                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()


                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection_new(_Process) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



                'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
                '    Exit Sub
                'End If

                Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
                dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_Process, 1, 0)
                'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _Process, Date.Now.Year, TR_ID)
                'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _Process, Date.Now.Year, TR_ID)


                FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
                'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
                convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


                Dim check As Boolean = True
                ' Try
                check = insrt_to_database(XML_TRADER, TR_ID)
                If check = True Then
                    SET_ATTACH(TR_ID, _Process, con_year(Date.Now.Year))

                    'Dim ws As New AUTHEN_LOG.Authentication
                    'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ Cert", _Process)
                    Dim ws_118 As New WS_AUTHENTICATION.Authentication
                    Dim ws_66 As New Authentication_66.Authentication
                    Dim ws_104 As New AUTHENTICATION_104.Authentication
                    Try
                        ws_118.Timeout = 10000
                        ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ Cert", _Process)
                    Catch ex As Exception
                        Try
                            ws_66.Timeout = 10000
                            ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ Cert", _Process)

                        Catch ex2 As Exception
                            Try
                                ws_104.Timeout = 10000
                                ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ Cert", _Process)

                            Catch ex3 As Exception
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                            End Try
                        End Try
                    End Try
                    alert("รหัสการดำเนินการ คือ DA-" & _Process & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)

                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เกิดข้อผิดพลาดกรุณาตรวจสอบข้อมูลในไฟล์');", True)
                End If
                ' Catch ex As Exception

                'alert("เกิดข้อผิดพลาด")

                'End Try
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์ใบ CER GMP');", True)

                'alert("กรุณาแนบไฟล์ใบ CER GMP")
            End If
        End If



    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        UC_ATTACH_DRUG_0.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
        UC_ATTACH_DRUG_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = False
        Try
        '  Try
        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_CER
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()
            Dim i As Integer = 0

            Dim dao_cas As New DAO_DRUG.TB_CER_DETAIL_CASCHEMICAL
            For Each dao_cas.fields In p2.CER_DETAIL_CASCHEMICALs
                If Len(Trim(dao_cas.fields.CAS_NAME)) > 0 Then
                    i += 1
                End If
            Next
            Dim chk_addr As Boolean = True
            If _Process = "32" Then
                Dim dao_CER_DETAIL_MANUFACTURE2 As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                For Each dao_CER_DETAIL_MANUFACTURE2.fields In p2.CER_DETAIL_MANUFACTUREs
                    Dim iso1 As String = ""
                    Try
                        iso1 = Trim(dao_CER_DETAIL_MANUFACTURE2.fields.COUNTRY_ID)
                    Catch ex As Exception

                    End Try
                    Try

                        If iso1 = "" Or iso1 = "0" Then
                            Return False
                        End If
                    Catch ex As Exception

                    End Try
                Next
            End If
            If _Process = "31" Then
                Dim dao_CER_DETAIL_MANUFACTURE2 As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                For Each dao_CER_DETAIL_MANUFACTURE2.fields In p2.CER_DETAIL_MANUFACTUREs
                    Dim iso1 As String = ""
                    Dim iso2 As String = ""
                    Try
                        iso1 = Trim(dao_CER_DETAIL_MANUFACTURE2.fields.COUNTRY_ID)
                    Catch ex As Exception

                    End Try
                    Try
                        iso2 = Trim(dao_CER_DETAIL_MANUFACTURE2.fields.COUNTRY_GMP)
                    Catch ex As Exception

                    End Try
                    Try

                        If iso1 = "" Or iso1 = "0" Then
                            Return False
                        End If

                    Catch ex As Exception

                    End Try
                    Try

                        If iso2 = "" Or iso1 = "0" Then
                            Return False
                        End If

                    Catch ex As Exception

                    End Try
                Next
            End If
            If _Process <> "32" Then
                Dim dao_CER_DETAIL_MANUFACTURE2 As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                For Each dao_CER_DETAIL_MANUFACTURE2.fields In p2.CER_DETAIL_MANUFACTUREs
                    Dim addr As String = ""
                    Try
                        addr = Trim(dao_CER_DETAIL_MANUFACTURE2.fields.ADDRESS_NUMBER)
                        If Len(addr) < 5 Then
                            'chk_addr = False
                            Return False
                        End If
                    Catch ex As Exception

                    End Try
                Next
            End If

            If _Process = "32" Then
                Dim dao_CER_DETAIL_MANUFACTURE3 As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                For Each dao_CER_DETAIL_MANUFACTURE3.fields In p2.CER_DETAIL_MANUFACTUREs
                    Dim ISO_STANDARD As String = ""
                    Try
                        ISO_STANDARD = Trim(dao_CER_DETAIL_MANUFACTURE3.fields.LOCATION_STANDARD)
                        If Len(ISO_STANDARD) < 5 Then

                            Return False
                        End If
                    Catch ex As Exception

                    End Try
                Next
            End If


            'If chk_addr = False Then
            '    Return False
            'End If
            If i > 0 Then

                Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
                dao_lcn.GetDataby_IDA(_lcn_ida)
                'If Request.QueryString("staff") = "" Then
                '    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE <> _CLS.CITIZEN_ID_AUTHORIZE Then
                '        Return False
                '    End If
                'End If

                Dim dao As New DAO_DRUG.TB_CER

                dao.fields = p2.CERs
                'dao.fields.pdcid = 0
                'dao.fields.cnsdcd = 1
                dao.fields.LCNSID = _CLS.LCNSID_CUSTOMER
                'dao.fields.rcvdate = Date.Now
                ' dao.fields.xmlnm = "DA-" & _Process & "-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
                dao.fields.TR_ID = TR_ID
                dao.fields.FK_IDA = Integer.Parse(_lcn_ida)
                dao.fields.STATUS_ID = 1
                dao.fields.CREATE_DATE = Date.Now
                dao.fields.PROCESS_ID = _Process
                ' dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
                'dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
                'dao.fields.regntfno = run_regntfno()'ปรับไปรันตอน ยืนยัน
                Try
                    dao.fields.MOBILE = txt_Mobile.Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.OLD_TR_ID = txt_OLD_TR_ID.Text
                Catch ex As Exception

                End Try

                dao.insert()

                Dim dao_cerfdtype As New DAO_DRUG.clsDBCER_DRTYPE

                For Each dao_cerfdtype.fields In p2.CER_FDTYPE
                    dao_cerfdtype.fields.TRANSECTION_ID_UPLOAD = TR_ID
                    dao_cerfdtype.fields.FK_IDA = _CLS.IDA
                    dao_cerfdtype.fields.CER_IDA = dao.fields.IDA
                    dao_cerfdtype.insert()
                    dao_cerfdtype = New DAO_DRUG.clsDBCER_DRTYPE
                Next

                Dim dao_CER_REF As New DAO_DRUG.clsDBCER_REF
                For Each dao_CER_REF.fields In p2.CER_REF
                    dao_CER_REF.fields.TRANSECTION_ID_UPLOAD = TR_ID
                    dao_CER_REF.fields.FK_IDA = _CLS.IDA
                    dao_CER_REF.insert()
                    dao_CER_REF = New DAO_DRUG.clsDBCER_REF
                Next

                Dim dao_CER_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_CER_DETAIL_CASCHEMICAL
                For Each dao_CER_DETAIL_CASCHEMICAL.fields In p2.CER_DETAIL_CASCHEMICALs
                    If Len(Trim(dao_CER_DETAIL_CASCHEMICAL.fields.CAS_NAME)) > 0 Then
                        dao_CER_DETAIL_CASCHEMICAL.fields.TR_ID = TR_ID
                        dao_CER_DETAIL_CASCHEMICAL.fields.FK_IDA = dao.fields.IDA
                        dao_CER_DETAIL_CASCHEMICAL.insert()
                    End If

                    dao_CER_DETAIL_CASCHEMICAL = New DAO_DRUG.TB_CER_DETAIL_CASCHEMICAL
                Next

                Dim dao_CER_DETAIL_MANUFACTURE As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                For Each dao_CER_DETAIL_MANUFACTURE.fields In p2.CER_DETAIL_MANUFACTUREs
                    dao_CER_DETAIL_MANUFACTURE.fields.TR_ID = TR_ID
                    dao_CER_DETAIL_MANUFACTURE.fields.FK_IDA = dao.fields.IDA
                    dao_CER_DETAIL_MANUFACTURE.insert()
                    dao_CER_DETAIL_MANUFACTURE = New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                Next


                'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                'dao_up.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
                'dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'dao_up.fields.DOWNLOAD_ID = p2.DOWNLOAD_ID
                'dao_up.fields.PROCESS_ID = _Process
                'dao_up.fields.UPLOAD_DATE = Date.Now
                'dao_up.fields.YEAR = Date.Now.Year
                'dao_up.fields.REF_NO = dao.fields.IDA
                'dao_up.insert()
                'Catch ex As Exception
                '    check = False
                'End Try

                Return True

            Else
                Return False
            End If

        Catch ex As Exception

        End Try


        'Return check
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class