Imports System.IO
Imports System.Xml.Serialization

Public Class POPUP_DH_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _IDA As String
    Private _FK_IDA As String
    Sub runQuery()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _FK_IDA = Request.QueryString("fk_ida")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            ' _ProcessID = Request.QueryString("type")
            '  dsd
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        runQuery()
        set_txt_label()
        If _ProcessID = "15" Then
            Panel101.Style.Add("display", "block")
        End If
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        If PROCESS_ID = "15" Then
            'ภค ข้อ 2
            uc102_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc102_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc102_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc102_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            uc102_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc102_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
        End If
    End Sub
    Public Sub set_txt_label()
        uc102_1.get_label("1.สำเนา ผ.ย. ๘ ที่ได้รับอนุมัติแล้ว พร้อมหนังสือสั่งซื้อจากผู้รับอนุญาตผลิตยา")
        uc102_2.get_label("2.สำเนาใบอนุญาตผลิตในต่างประเทศ และรับรองสำเนาโดยผู้รับอนุญาตที่ขอจดแจ้งเภสัชเคมีภัณฑ์")
        uc102_3.get_label("3.สำเนาใบสำคัญการขึ้นทะเบียนตำรับยา และสำเนา ท.ย.๑ หน้า๑ และหน้า๒/แบบ ย.๑ หน้า ๓")
        uc102_4.get_label("4.สำเนารายงานผลการตรวจวิเคราะห์คุณภาพ (Certification of Analysis) ซึ่งระบุข้อกำหนดมาตราฐาน (Specifications)")
        uc102_5.get_label("5.สำเนาหนังสือรับรองมาตราฐานหลักเกณฑ์วิธีการที่ดีในการผลิตเภสัชเคมีภัณฑ์(Good Manufacturing Practice) ตามมาตราฐานองค์การอนามัยโลกหรือเทียบเท่า (กรณีนำเข้า)")
        uc102_6.get_label("6.อื่นๆ")
    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            Try

                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



                'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
                '    Exit Sub
                'End If

                Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
                dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
                'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
                'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
                Dim _path_temp As String = ""
                _path_temp = bao._PATH_DEFAULT & "XML_TRADER_TEMP\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
                If chk_chem(TR_ID, bao._PATH_DEFAULT) = False Then
                    alert("Error Code 111 \nกรุณาแนบไฟล์คำขอที่มีปัญหาส่งทาง E-Mail : Drug-SmartHelp@fda.moph.go.th")
                    'เกิดข้อผิดพลาด กรุณาตรวจสอบไฟล์ที่อัพโหลด
                Else
                    If _ProcessID <> "16" And _ProcessID <> "17" Then
                        If chk_cert_exp(_path_temp) = True Then
                            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
                            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
                            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)
                            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
                            Dim check As Boolean = True
                            ' Try
                            check = insrt_to_database(XML_TRADER, TR_ID)
                            If check = True Then
                                SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
                                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                            Else
                                alert("Error Code 222 \nกรุณาแนบไฟล์คำขอที่มีปัญหาส่งทาง E-Mail : Drug-SmartHelp@fda.moph.go.th")
                                'alert("เกิดข้อผิดพลาด กรุณาตรวจสอบไฟล์ที่อัพโหลด")
                            End If
                        Else
                            alert("Error Code 333 \nไม่สามารถอัพโหลดไฟล์ได้ เนื่องจาก Cert ที่เลือกหมดอายุ")
                        End If
                    Else
                        FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
                        'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
                        convert_PDF_To_XML(PDF_TRADER, XML_TRADER)
                        '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
                        Dim check As Boolean = True
                        ' Try
                        check = insrt_to_database(XML_TRADER, TR_ID)
                        If check = True Then
                            SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
                            alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                        Else
                            alert("Error Code 222 \nกรุณาแนบไฟล์คำขอที่มีปัญหาส่งทาง E-Mail : Drug-SmartHelp@fda.moph.go.th")
                            'alert("เกิดข้อผิดพลาด กรุณาตรวจสอบไฟล์ที่อัพโหลด")
                        End If
                    End If

                    'Dim ws As New AUTHEN_LOG.Authentication
                    'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอเภสัชเคมีภัณฑ์", _ProcessID)

                    Dim ws_118 As New WS_AUTHENTICATION.Authentication
                    Dim ws_66 As New Authentication_66.Authentication
                    Dim ws_104 As New AUTHENTICATION_104.Authentication
                    Try
                        ws_118.Timeout = 10000
                        ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอเภสัชเคมีภัณฑ์", _ProcessID)
                    Catch ex As Exception
                        Try
                            ws_66.Timeout = 10000
                            ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอเภสัชเคมีภัณฑ์", _ProcessID)

                        Catch ex2 As Exception
                            Try
                                ws_104.Timeout = 10000
                                ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอเภสัชเคมีภัณฑ์", _ProcessID)

                            Catch ex3 As Exception
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                            End Try
                        End Try
                    End Try
                End If
               

            Catch ex As Exception
                alert("Error Code 222 \nกรุณาแนบไฟล์คำขอที่มีปัญหาส่งทาง E-Mail : Drug-SmartHelp@fda.moph.go.th")
                'alert("เกิดข้อผิดพลาด กรุณาตรวจสอบไฟล์ที่อัพโหลด")
            End Try



            '333 Cert หมดอายุ
            ' Catch ex As Exception

            'alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            '  End Try


        End If
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Function chk_chem(ByVal TR_ID As String, ByVal _path As String) As Boolean

        Dim PDF_TRADER As String = _path & "PDF_TRADER_TEMP\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
        'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
        Dim XML_TRADER As String = _path & "XML_TRADER_TEMP\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)

        Dim bool As Boolean = False
        FileUpload1.SaveAs(PDF_TRADER)
        convert_PDF_To_XML(PDF_TRADER, XML_TRADER)
        Try
            Dim objStreamReader As New StreamReader(XML_TRADER)
            Dim p2 As New CLASS_DH
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao_DH15_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
            For Each dao_DH15_DETAIL_CASCHEMICAL.fields In p2.DH15_DETAIL_CASCHEMICALs
                Dim CAS_ID As String = "0"
                Try
                    CAS_ID = Trim(dao_DH15_DETAIL_CASCHEMICAL.fields.CAS_ID)
                Catch ex As Exception

                End Try

                Dim result As String = ""
                Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL
                dao.GetDataby_IDA(CAS_ID)
                If _ProcessID = "14" Then
                    If dao.fields.aori = "A" And dao.fields.REGIS_STATUS = "R" Then
                        bool = True
                    Else
                        Return False
                    End If
                ElseIf _ProcessID = "15" Then
                    If dao.fields.aori = "A" And dao.fields.REGIS_STATUS = "N" Then
                        bool = True
                    Else
                        Return False
                    End If
                ElseIf _ProcessID = "16" Then
                    If dao.fields.aori = "I" And dao.fields.REGIS_STATUS = "R" Then
                        bool = True
                    Else
                        Return False
                    End If
                ElseIf _ProcessID = "17" Then
                    If dao.fields.aori = "I" And dao.fields.REGIS_STATUS = "N" Then
                        bool = True
                    Else
                        Return False
                    End If
                End If

            Next
            Dim trade_name As String = ""
            Dim product_for As String = ""
            Dim pro_county As String = ""
            Try
                trade_name = RTrim(LTrim(p2.dh15rqts.TRADING_NAME))
            Catch ex As Exception

            End Try
            Try
                product_for = RTrim(LTrim(p2.dh15rqts.FOREIGN_PRODUCT))
            Catch ex As Exception

            End Try
            Try
                pro_county = RTrim(LTrim(p2.dh15rqts.FOREIGN_COUNTRY_CD))
            Catch ex As Exception

            End Try

            If trade_name <> "" Then
                bool = True
            Else
                Return False
            End If
            If _ProcessID = "16" And _ProcessID = "17" Then
                If product_for <> "" Then
                    bool = True
                Else
                    Return False
                End If
                If pro_county <> "" Then
                    bool = True
                Else
                    Return False
                End If
            End If
            
        Catch ex As Exception

        End Try


        Return bool
    End Function
    Function chk_cert_exp(ByVal _path As String) As Boolean
        Dim bool As Boolean = False
        Try
            Dim objStreamReader As New StreamReader(_path)
            Dim p2 As New CLASS_DH
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()


            Dim dao_cer As New DAO_DRUG.TB_DH15_DETAIL_CER
            For Each dao_cer.fields In p2.DH15_DETAIL_CERs
                Dim CER_IDA As String = "0"
                Try
                    CER_IDA = Trim(dao_cer.fields.CER_DETAIL_CHEMICAL_IDA)
                    Dim date_now As Date = CDate(Date.Now)
                    Dim dao_cer_head As New DAO_DRUG.TB_CER
                    dao_cer_head.GetDataby_IDA2(CER_IDA)
                    Dim date_exp As Date = CDate(dao_cer_head.fields.EXP_DOCUMENT_DATE).AddDays(180)
                    If date_now <= date_exp Then
                        bool = True
                    Else
                        bool = False
                    End If
                    Try
                        If dao_cer_head.fields.CER_TYPE = 34 Then
                            bool = True
                        End If
                    Catch ex As Exception

                    End Try

                Catch ex As Exception

                End Try

            Next
         
        Catch ex As Exception

        End Try


        Return bool
    End Function
    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True

        Try

            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DH
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.ClsDBdh15rqt

            ' Dim bao As New BAO.GenNumber

            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(_CLS.PVCODE)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try
            dao.fields = p2.dh15rqts
            'dao.fields.cnsdcd = 1
            'dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            dao.fields.rcvdate = Date.Now
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.STATUS_ID = 1
            Try
                dao.fields.FOREIGN_COUNTRY_CD = p2.dh15rqts.FOREIGN_COUNTRY_CD
            Catch ex As Exception

            End Try
            '  dao.fields.xmlnm = "FA-8-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
            dao.fields.TR_ID = TR_ID
            Try
                dao.fields.pvncd = _CLS.PVCODE
            Catch ex As Exception

            End Try
            Try
                dao.fields.lpvncd = _CLS.PVCODE
            Catch ex As Exception

            End Try
            Try
                dao.fields.pvnabbr = chw
            Catch ex As Exception

            End Try

            dao.fields.FK_IDA = _FK_IDA
            dao.fields.IDENTIFY = _CLS.CITIZEN_ID
            dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
            Try
                dao.fields.MOBILE = txt_Mobile.Text
            Catch ex As Exception

            End Try

            dao.insert()
            Dim main_ida As Integer = dao.fields.IDA

            Dim dao_dh15frgn As New DAO_DRUG.ClsDBdh15frgn
            For Each dao_dh15frgn.fields In p2.dh15frgns
                dao_dh15frgn.fields.TR_ID = TR_ID
                dao_dh15frgn.fields.FK_IDA = main_ida
                dao_dh15frgn.insert()
                dao_dh15frgn = New DAO_DRUG.ClsDBdh15frgn
            Next

            Dim dao_dh15rqtdt As New DAO_DRUG.ClsDBdh15rqtdt
            For Each dao_dh15rqtdt.fields In p2.dh15rqtdts
                dao_dh15rqtdt.fields.TR_ID = TR_ID
                dao_dh15rqtdt.fields.FK_IDA = main_ida
                dao_dh15rqtdt.insert()
                dao_dh15rqtdt = New DAO_DRUG.ClsDBdh15rqtdt
            Next

            Dim dao_dh15tdgt As New DAO_DRUG.ClsDBdh15tdgt
            For Each dao_dh15tdgt.fields In p2.dh15tdgts
                dao_dh15tdgt.fields.TR_ID = TR_ID
                dao_dh15tdgt.fields.FK_IDA = main_ida
                dao_dh15tdgt.insert()
                dao_dh15tdgt = New DAO_DRUG.ClsDBdh15tdgt
            Next

            Dim dao_dh15tpdcfrgn As New DAO_DRUG.ClsDBdh15tpdcfrgn
            For Each dao_dh15tpdcfrgn.fields In p2.dh15tpdcfrgns
                dao_dh15tpdcfrgn.fields.TR_ID = TR_ID
                dao_dh15tpdcfrgn.fields.FK_IDA = main_ida
                dao_dh15tpdcfrgn.insert()
                dao_dh15tpdcfrgn = New DAO_DRUG.ClsDBdh15tpdcfrgn
            Next

            Dim dao_DH15_DETAIL_CER As New DAO_DRUG.TB_DH15_DETAIL_CER
            For Each dao_DH15_DETAIL_CER.fields In p2.DH15_DETAIL_CERs

                If dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA <> 0 Then

                    '--------------------DH15_DETAIL_CER----------------------
                    Dim dao_CER_GETDATA As New DAO_DRUG.TB_CER
                    dao_CER_GETDATA.GetDataby_IDA2(dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA)



                    '--------------------DH15_DETAIL_MANUFACTURE----------------------
                    Dim dao_DH15_DETAIL_MANUFACTURE_CER As New DAO_DRUG.TB_DH15_DETAIL_MANUFACTURE
                    Dim dao_CER_DETAIL_MANUFACTURE As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                    dao_CER_DETAIL_MANUFACTURE.GetDataby_FK_IDA(dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA)

                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.TR_ID = TR_ID
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.FK_IDA = main_ida
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.ADDRESS_CITY = dao_CER_DETAIL_MANUFACTURE.fields.ADDRESS_CITY
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.ADDRESS_NUMBER = dao_CER_DETAIL_MANUFACTURE.fields.ADDRESS_NUMBER
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.CER_DATE = dao_CER_DETAIL_MANUFACTURE.fields.CER_DATE
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.COMPANY_NAME = dao_CER_DETAIL_MANUFACTURE.fields.COMPANY_NAME
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.COUNTRY = dao_CER_DETAIL_MANUFACTURE.fields.COUNTRY
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.COUNTRY_GMP = dao_CER_DETAIL_MANUFACTURE.fields.COUNTRY_GMP
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.COUNTRY_ID = dao_CER_DETAIL_MANUFACTURE.fields.COUNTRY_ID
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.GLN = dao_CER_DETAIL_MANUFACTURE.fields.GLN
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.LOCATION_STANDARD = dao_CER_DETAIL_MANUFACTURE.fields.LOCATION_STANDARD
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.NAME_ADDRESS = dao_CER_DETAIL_MANUFACTURE.fields.NAME_ADDRESS
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.SALE_DATE = dao_CER_DETAIL_MANUFACTURE.fields.SALE_DATE
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.STANDARD_ID = dao_CER_DETAIL_MANUFACTURE.fields.STANDARD_ID
                    dao_DH15_DETAIL_MANUFACTURE_CER.fields.ZIPCODE = dao_CER_DETAIL_MANUFACTURE.fields.ZIPCODE


                    dao_DH15_DETAIL_MANUFACTURE_CER.insert()
                    dao_DH15_DETAIL_MANUFACTURE_CER = New DAO_DRUG.TB_DH15_DETAIL_MANUFACTURE
                End If




                dao_DH15_DETAIL_CER.fields.TR_ID = TR_ID
                dao_DH15_DETAIL_CER.fields.FK_IDA = main_ida
                dao_DH15_DETAIL_CER.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE

                If dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA IsNot Nothing Then
                    Dim dao_CER As New DAO_DRUG.TB_CER
                    dao_CER.GetDataby_IDA2(dao_DH15_DETAIL_CER.fields.CER_DETAIL_CHEMICAL_IDA)
                    If dao_CER.fields.IDA <> 0 Or dao_CER.fields.DOCUMENT_DATE.ToString <> Nothing Or IsDBNull(dao_CER.fields.DOCUMENT_DATE) = False Then
                        dao_DH15_DETAIL_CER.fields.DOCUMENT_DATE = dao_CER.fields.DOCUMENT_DATE
                        dao_DH15_DETAIL_CER.fields.EXP_DOCUMENT_DATE = dao_CER.fields.EXP_DOCUMENT_DATE
                    End If
                End If
                Try
                    Dim dao_iso1 As New DAO_DRUG.clsDBsysisocnt
                    dao_iso1.GetDataby_IDA(dao_DH15_DETAIL_CER.fields.COUNTRY_IDA)
                    dao_DH15_DETAIL_CER.fields.COUNTRY_NAME = dao_iso1.fields.engcntnm
                Catch ex As Exception

                End Try
                '
                dao_DH15_DETAIL_CER.insert()
                dao_DH15_DETAIL_CER = New DAO_DRUG.TB_DH15_DETAIL_CER
            Next

            Dim ROW_DETAIL_CASCHEMICAL As Integer = 0
            Dim dao_DH15_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
            For Each dao_DH15_DETAIL_CASCHEMICAL.fields In p2.DH15_DETAIL_CASCHEMICALs
                Dim dao_CER_DETAIL_CASCHEMICAL As New DAO_DRUG.TB_CER_DETAIL_CASCHEMICAL
                Dim CAS_ID As String = ""
                Try
                    CAS_ID = Trim(dao_DH15_DETAIL_CASCHEMICAL.fields.CAS_ID)
                Catch ex As Exception

                End Try
                If CAS_ID <> "" Then

                    Dim dao_MAS_CHEMICAL As New DAO_DRUG.TB_MAS_CHEMICAL
                    dao_MAS_CHEMICAL.GetDataby_IDA(Trim(dao_DH15_DETAIL_CASCHEMICAL.fields.CAS_ID))

                    dao_CER_DETAIL_CASCHEMICAL.GetDataby_IDA(Trim(CAS_ID))


                    dao_DH15_DETAIL_CASCHEMICAL.fields.TR_ID = TR_ID
                    dao_DH15_DETAIL_CASCHEMICAL.fields.FK_IDA = main_ida
                    'dao_DH15_DETAIL_CASCHEMICAL.fields.CAS_NAME = dao_CER_DETAIL_CASCHEMICAL.fields.CAS_NAME
                    dao_DH15_DETAIL_CASCHEMICAL.fields.CAS_NAME = dao_MAS_CHEMICAL.fields.iowanm
                    'dao_DH15_DETAIL_CASCHEMICAL.fields.CAS_ID = dao_CER_DETAIL_CASCHEMICAL.fields.CAS_ID
                    'dao_DH15_DETAIL_CASCHEMICAL.fields.CAS_NO = dao_CER_DETAIL_CASCHEMICAL.fields.CAS_NO
                    ' dao_DH15_DETAIL_CASCHEMICAL.fields.frgnappno = dao_CER_DETAIL_CASCHEMICAL.fields.frgnappno
                    ' dao_DH15_DETAIL_CASCHEMICAL.fields.iowacd = dao_CER_DETAIL_CASCHEMICAL.fields.CAS_NO
                    ' dao_DH15_DETAIL_CASCHEMICAL.fields.phm15dgt = dao_CER_DETAIL_CASCHEMICAL.fields.phm15dgt
                    dao_DH15_DETAIL_CASCHEMICAL.fields.ROW_ID = ROW_DETAIL_CASCHEMICAL
                    dao_DH15_DETAIL_CASCHEMICAL.insert()
                    dao_DH15_DETAIL_CASCHEMICAL = New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
                End If

                ROW_DETAIL_CASCHEMICAL += 1
            Next

            'Dim dao_DH15_DETAIL_MANUFACTURE As New DAO_DRUG.TB_DH15_DETAIL_MANUFACTURE
            'For Each dao_DH15_DETAIL_MANUFACTURE.fields In p2.DH15_DETAIL_MANUFACTUREs

            '    dao_DH15_DETAIL_MANUFACTURE.fields.TR_ID = TR_ID
            '    dao_DH15_DETAIL_MANUFACTURE.fields.FK_IDA = main_ida
            '    dao_DH15_DETAIL_MANUFACTURE.insert()
            '    dao_DH15_DETAIL_MANUFACTURE = New DAO_DRUG.TB_DH15_DETAIL_MANUFACTURE
            'Next

            If _ProcessID <> "16" And _ProcessID <> "17" Then
                Dim dao_dh_cer As New DAO_DRUG.TB_DH15_DETAIL_CER
                dao_dh_cer.GetDataby_FK_IDA(main_ida)

                Dim dao_cer_manu As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
                dao_cer_manu.GetDataby_FK_IDA(dao_dh_cer.fields.CER_DETAIL_CHEMICAL_IDA)

                Dim dao_dh15 As New DAO_DRUG.ClsDBdh15rqt
                dao_dh15.GetDataby_IDA(main_ida)
                dao_dh15.fields.FOREIGN_COUNTRY_CD = dao_cer_manu.fields.COUNTRY_ID
                dao_dh15.fields.FOREIGN_PRODUCT = dao_cer_manu.fields.NAME_ADDRESS
                dao_dh15.update()
            End If

            'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            'dao_up.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
            'dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            'dao_up.fields.DOWNLOAD_ID = p2.DOWNLOAD_ID
            'dao_up.fields.PROCESS_ID = _ProcessID
            'dao_up.fields.UPLOAD_DATE = Date.Now
            'dao_up.fields.YEAR = Date.Now.Year
            'dao_up.fields.REF_NO = dao.fields.IDA
            'dao_up.insert()
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

End Class