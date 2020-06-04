Imports System.IO
Imports System.Xml.Serialization

Public Class POPUP_DR_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA As String
    Private _lcn_ida As String = ""
    Sub runQuery()
        _lcn_ida = Request.QueryString("lcn_ida")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
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
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
        If Not IsPostBack Then
            txt_citizenid.Text = _CLS.CITIZEN_ID_AUTHORIZE
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
            bind_yor8()
            
        End If
        If Request.QueryString("tt") = "2" Then
            Label1.Style.Add("display", "block")
            ddl_yor8.Style.Add("display", "block")
            cb_herbal.Style.Add("display", "block")
        ElseIf Request.QueryString("tt") = "1" Then
            lbl_niti.Visible = False
            txt_citizenid.Visible = False
        End If
    End Sub
    Sub bind_yor8()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_GET_DRSAMP_DLL(_CLS.CITIZEN_ID_AUTHORIZE)

        ddl_yor8.DataSource = dt
        ddl_yor8.DataTextField = "drug_name"
        ddl_yor8.DataValueField = "IDA"
        ddl_yor8.DataBind()

        'Dim bao_master As New BAO_MASTER
        'Dim dt As New DataTable
        'dt = bao_master.SP_drkdofdrg()
        'ddl_drkdofdrg.DataSource = dt
        'ddl_drkdofdrg.DataTextField = "thakindnm"
        'ddl_drkdofdrg.DataValueField = "kindcd"
        'ddl_drkdofdrg.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_yor8.Items.Insert(0, item)
    End Sub
    Public Sub set_txt_label()
        'ขย.1
        uc_upload_1.get_label("รูปภาพยา")
        uc_upload_2.get_label("ฉลากและเอกสารกำกับผลิตภัณฑ์ ทุกภาชนะบรรจุ")
        'uc_upload_3.get_label("ฉลากขวด")
        'uc_upload_4.get_label("ฉลากกล่อง")
        uc_upload_5.get_label("ผลการวิเคราะห์คุณภาพยาสำเร็จรูป")
        uc_upload_6.get_label("คำรับรองเงื่อนไขต่างๆที่เกี่ยวข้อง")
        'uc_upload_6.get_label("คำรับรองเงื่อนไขเรียกเก็บยาคืน")
        'uc_upload_7.get_label("คำรับรองรายงานอาการไม่พึงประสงค์")
        'uc_upload_8.get_label("คำรับรองตนเอง")
        uc_upload_8.get_label("กรรมวิธีการผลิต")
    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)

        'ขย.1
        uc_upload_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
        uc_upload_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
        'uc_upload_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
        'uc_upload_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
        uc_upload_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
        uc_upload_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
        'uc_upload_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
        uc_upload_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        'If FileUpload1.HasFile Then
        '    Dim bao As New BAO.AppSettings
        '    bao.RunAppSettings()

        '    Dim cls_tr As New BAO_TRANSECTION
        '    Dim tr_id As Integer = 0

        '    cls_tr.CITIZEN_ID = _CLS.CITIZEN_ID
        '    cls_tr.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        '    tr_id = cls_tr.insert_transection(12)

        '    FileUpload1.SaveAs(bao._PATH_PDF_TRADER & "DA-12-" & con_year(Date.Now.Year) & "-" & tr_id & ".pdf") '"C:\path\PDF_TRADER\"
        '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "DA-12-" & con_year(Date.Now.Year) & "-" & tr_id & ".pdf", tr_id) '"C:\path\PDF_TRADER\"
        '    insrt_to_database(bao._PATH_XML_TRADER & "DA-12-" & con_year(Date.Now.Year) & "-" & tr_id & ".xml", tr_id) '"C:\path\XML_TRADER\"

        '    alert("รหัสการดำเนินการ คือ DA-12-" & con_year(Date.Now.Year) & "-" & tr_id)
        'End If

        If Request.QueryString("tt") <> "" Then
            If Request.QueryString("tt") = "2" Then
                If cb_herbal.Checked = True Then
                    If ddl_yor8.SelectedValue <> "0" Then
                        If CHK_ATTACH_PDF() = 0 Then
                            upload_a()
                        Else
                            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาแนบไฟล์ในรูปแบบ PDF');</script> ")
                        End If

                    Else
                        Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกเลขดำเนินการ ยบ.8/ชื่อผลิตภัณฑ์');</script> ")
                    End If

                Else
                    Response.Write("<script type='text/javascript'>window.parent.alert('ท่านยังไม่ได้คลิกยืนยันเงื่อนไข');</script> ")
                End If
            ElseIf Request.QueryString("tt") = "1" Then
                If CHK_ATTACH_PDF() = 0 Then
                    upload_a()
                Else
                    Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาแนบไฟล์ในรูปแบบ PDF');</script> ")
                End If
            End If
        Else
            If CHK_ATTACH_PDF() = 0 Then
                upload_a()
            Else
                Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาแนบไฟล์ในรูปแบบ PDF');</script> ")
            End If
        End If

    End Sub
    Function CHK_ATTACH_PDF() As Integer
        Dim i As Integer = 0
        i += uc_upload_1.CHK_Extension()
        i += uc_upload_2.CHK_Extension()
        i += uc_upload_5.CHK_Extension()
        i += uc_upload_6.CHK_Extension()
        i += uc_upload_8.CHK_Extension()
        Return i
    End Function
    Sub upload_a()
        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



            'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
            '    Exit Sub
            'End If
            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)

            'Dim PDF_TRADER As String = bao._PATH_PDF_TRADER & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"

            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            'Dim XML_TRADER As String = bao._PATH_XML_TRADER & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)

            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
            Dim check As Boolean = True
            Try
                check = insrt_to_database_new(XML_TRADER, TR_ID)
                If check = True Then
                    SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
                    'Dim ws As New AUTHEN_LOG.Authentication
                    'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ ย.1", _ProcessID)
                    Dim ws_118 As New WS_AUTHENTICATION.Authentication
                    Dim ws_66 As New Authentication_66.Authentication
                    Dim ws_104 As New AUTHENTICATION_104.Authentication
                    Try
                        ws_118.Timeout = 10000
                        ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ ย.1", _ProcessID)
                    Catch ex As Exception
                        Try
                            ws_66.Timeout = 10000
                            ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ ย.1", _ProcessID)

                        Catch ex2 As Exception
                            Try
                                ws_104.Timeout = 10000
                                ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอ ย.1", _ProcessID)

                            Catch ex3 As Exception
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                            End Try
                        End Try
                    End Try

                    alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                Else

                End If
            Catch ex As Exception

                alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End Try
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True

        Try
            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DR
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_lcn_ida)
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_rg.GetDataby_IDA(_IDA)

            dao.fields = p2.drrgts

            Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_pro.GetDataby_Process_ID(_ProcessID)
            Try
                dao.fields.rgttpcd = dao_pro.fields.PROCESS_DESCRIPTION
            Catch ex As Exception

            End Try
            Try
                dao.fields.PROCESS_ID = _ProcessID
            Catch ex As Exception

            End Try
            Try

            Catch ex As Exception

            End Try
            Try
                dao.fields.ctgcd = dao_rg.fields.ctgcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.kindcd = dao_rg.fields.kindcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.dsgcd = dao_rg.fields.FK_DOSAGE_FORM
            Catch ex As Exception

            End Try
            Try
                dao.fields.classcd = dao_rg.fields.GROUP_TYPE
            Catch ex As Exception

            End Try
            Try
                dao.fields.FK_DOSAGE_FORM = p2.drrgts.FK_DOSAGE_FORM
            Catch ex As Exception

            End Try
            Try
                If dao_rg.fields.DRUG_EQ_TO IsNot Nothing Then
                    dao.fields.rcptpayst = dao_rg.fields.DRUG_EQ_TO

                    Dim dao_tm As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                    dao_tm.GetDataby_TAMRAP_ID(dao_rg.fields.DRUG_EQ_TO)
                    If dao_tm.fields.IS_AUTO = 1 Then
                        dao.fields.TYPE_REQUEST_ID = 1419
                    End If
                End If
            Catch ex As Exception

            End Try

            'Try
            '    dao.fields.kindcd = p2.drrgts.kindcd
            'Catch ex As Exception

            'End Try
            'Try
            '    dao.fields.ctgcd = p2.drrgts.ctgcd
            'Catch ex As Exception

            'End Try
            Try
                'If Trim(p2.TRANSFER) <> "" Then
                dao.fields.FK_TRANSFER = p2.TRANSFER
                'End If
            Catch ex As Exception

            End Try

            Try
                If Trim(p2.TRANSFER) <> "" Then
                    dao.fields.TRANSFER_TYPE = "1"

                End If

            Catch ex As Exception

            End Try
            dao.fields.STATUS_ID = 1
            dao.fields.FK_IDA = _IDA
            dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            dao.fields.pvncd = _CLS.PVCODE
            dao.fields.FK_LCN_IDA = _lcn_ida
            Try
                dao.fields.CHK_LCN_SUBTYPE1 = p2.drrgts.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                dao.fields.CHK_LCN_SUBTYPE2 = p2.drrgts.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                dao.fields.CHK_LCN_SUBTYPE3 = p2.drrgts.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try
            Try
                dao.fields.TABEAN_TYPE1 = p2.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                dao.fields.TABEAN_TYPE2 = p2.TABEAN_TYPE2
            Catch ex As Exception

            End Try
            Try
                dao.fields.thadrgnm = dao_rg.fields.DRUG_NAME_THAI
            Catch ex As Exception

            End Try
            Try
                dao.fields.engdrgnm = dao_rg.fields.DRUG_NAME_OTHER
            Catch ex As Exception

            End Try
            Try
                dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.UNIT_NORMAL = dao_rg.fields.UNIT_NORMAL
            Catch ex As Exception

            End Try
            Try
                dao.fields.PACKAGE_DETAIL = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception

            End Try
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(dao.fields.pvncd)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try
            Try
                dao.fields.classcd = dao_rg.fields.GROUP_TYPE 'ประเภทของยา
            Catch ex As Exception

            End Try
            dao.fields.pvnabbr = chw
            'dao.fields.rcvdate = Date.Now
            '  dao.fields.xmlnm = "FA-8-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
            dao.fields.TR_ID = TR_ID
            dao.fields.cnccd = Nothing
            dao.fields.cnccscd = Nothing
            dao.insert()


            Try
                If Trim(p2.TRANSFER) <> "" Then

                    insert_tabean(dao.fields.IDA, p2.TRANSFER)

                End If

            Catch ex As Exception

            End Try
            'Dim dao_drfrgn As New DAO_DRUG.ClsDBdrfrgn
            'For Each dao_drfrgn.fields In p2.drfrgns
            '    dao_drfrgn.fields.TR_ID = TR_ID
            '    dao_drfrgn.fields.FK_IDA = _IDA
            '    dao_drfrgn.insert()
            '    dao_drfrgn = New DAO_DRUG.ClsDBdrfrgn
            'Next

            'Dim dao_dramldrg As New DAO_DRUG.ClsDBdramldrg
            'For Each dao_dramldrg.fields In p2.dramldrgs
            '    dao_dramldrg.fields.TR_ID = TR_ID
            '    dao_dramldrg.fields.FK_IDA = _IDA
            '    dao_dramldrg.insert()
            '    dao_dramldrg = New DAO_DRUG.ClsDBdramldrg
            'Next

            'Dim dao_dramluse As New DAO_DRUG.ClsDBdramluse
            'For Each dao_dramluse.fields In p2.dramluses
            '    dao_dramluse.fields.TR_ID = TR_ID
            '    dao_dramluse.fields.FK_IDA = _IDA
            '    dao_dramluse.insert()
            '    dao_dramluse = New DAO_DRUG.ClsDBdramluse
            'Next

            'Dim dao_drdrgchr As New DAO_DRUG.ClsDBdrdrgchr
            'For Each dao_drdrgchr.fields In p2.drdrgchrs
            '    dao_drdrgchr.fields.TR_ID = TR_ID
            '    dao_drdrgchr.fields.FK_IDA = _IDA
            '    dao_drdrgchr.insert()
            '    dao_drdrgchr = New DAO_DRUG.ClsDBdrdrgchr
            'Next

            'Dim dao_drrgtnewdg As New DAO_DRUG.ClsDBdrrgtnewdg
            'For Each dao_drrgtnewdg.fields In p2.drrgtnewdgs
            '    dao_drrgtnewdg.fields.TR_ID = TR_ID
            '    dao_drrgtnewdg.fields.FK_IDA = _IDA
            '    dao_drrgtnewdg.insert()
            '    dao_drrgtnewdg = New DAO_DRUG.ClsDBdrrgtnewdg
            'Next

            'Dim dao_drspec As New DAO_DRUG.ClsDBdrspec
            'For Each dao_drspec.fields In p2.drspecs
            '    dao_drspec.fields.TR_ID = TR_ID
            '    dao_drspec.fields.FK_IDA = _IDA
            '    dao_drspec.insert()
            '    dao_drspec = New DAO_DRUG.ClsDBdrspec
            'Next

            'Dim dao_dreqto As New DAO_DRUG.ClsDBdreqto
            'For Each dao_dreqto.fields In p2.dreqtos
            '    dao_dreqto.fields.TR_ID = TR_ID
            '    dao_dreqto.fields.FK_IDA = _IDA
            '    dao_dreqto.insert()
            '    dao_dreqto = New DAO_DRUG.ClsDBdreqto
            'Next

            'Dim dao_drfmlno As New DAO_DRUG.ClsDBdrfmlno
            'For Each dao_drfmlno.fields In p2.drfmlnos
            '    dao_drfmlno.fields.TR_ID = TR_ID
            '    dao_drfmlno.fields.FK_IDA = _IDA
            '    dao_drfmlno.insert()
            '    dao_drfmlno = New DAO_DRUG.ClsDBdrfmlno
            'Next

            'Dim dao_drfml As New DAO_DRUG.ClsDBdrfml
            'For Each dao_drfml.fields In p2.drfmls
            '    dao_drfml.fields.TR_ID = TR_ID
            '    dao_drfml.fields.FK_IDA = _IDA
            '    dao_drfml.insert()
            '    dao_drfml = New DAO_DRUG.ClsDBdrfml
            'Next
            Dim dao_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
            For Each dao_atc.fields In p2.DRRQT_ATC_DETAIL
                Dim dao_atc2 As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                dao_atc2.fields.FK_IDA = _IDA
                dao_atc2.fields.ATC_CODE = Trim(dao_atc.fields.ATC_CODE)
                Try
                    dao_atc2.fields.ATC_IDA = dao_atc.fields.ATC_IDA
                Catch ex As Exception

                End Try
                dao_atc2.insert()
            Next

            Dim bao_show As New BAO_SHOW
            Dim dt_DRUG_REGISTRATION_PACKAGE As New DataTable
            Dim dt_DRUG_REGISTRATION_ATC_DETAIL As New DataTable
            Dim dt_DRUG_REGISTRATION_DETAIL_CAS As New DataTable
            Dim dt_DRUG_REGISTRATION_DETAIL_CAS_I As New DataTable
            Dim dt_DRUG_REGISTRATION_PROPERTIES As New DataTable
            Dim dt_DRUG_REGISTRATION_PRODUCER As New DataTable

            dt_DRUG_REGISTRATION_DETAIL_CAS = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA(_IDA)
            dt_DRUG_REGISTRATION_PACKAGE = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_IDA)
            dt_DRUG_REGISTRATION_ATC_DETAIL = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_IDA)

            dt_DRUG_REGISTRATION_PROPERTIES = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_IDA)
            dt_DRUG_REGISTRATION_PRODUCER = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(_IDA)

            Dim main_ida As Integer = 0
            Try
                main_ida = dao.fields.IDA
            Catch ex As Exception

            End Try

            'Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            Dim iii As Integer = 1
            For Each dr As DataRow In dt_DRUG_REGISTRATION_DETAIL_CAS.Rows
                Dim dao_cas2 As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                dao_cas2.fields.FK_IDA = main_ida
                Try
                    dao_cas2.fields.BASE_FORM = dr("BASE_FORM")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.FK_SET = dr("FK_SET")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.EQTO_IOWA = dr("EQTO_IOWA")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.EQTO_SUNITCD = dr("EQTO_SUNITCD")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.IOWA = dr("IOWA")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.QTY = dr("QTY")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.SUNITCD = dr("SUNITCD")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.REF = dr("REF")
                Catch ex As Exception

                End Try
                Try
                    dao_cas2.fields.REMARK = dr("REMARK")
                Catch ex As Exception

                End Try
                dao_cas2.fields.ROWS = iii
                dao_cas2.insert()
                iii += 1
            Next

            For Each dr As DataRow In dt_DRUG_REGISTRATION_PACKAGE.Rows
                Dim dao_pa2 As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                dao_pa2.fields.FK_IDA = main_ida
                Try
                    dao_pa2.fields.BARCODE = dr("BARCODE")
                Catch ex As Exception

                End Try
                Try
                    dao_pa2.fields.BIG_UNIT = dr("BIG_UNIT")
                Catch ex As Exception

                End Try
                Try
                    dao_pa2.fields.MEDIUM_AMOUNT = dr("MEDIUM_AMOUNT")
                Catch ex As Exception

                End Try
                Try
                    dao_pa2.fields.MEDIUM_UNIT = dr("MEDIUM_UNIT")
                Catch ex As Exception

                End Try
                Try
                    dao_pa2.fields.SMALL_AMOUNT = dr("SMALL_AMOUNT")
                Catch ex As Exception

                End Try
                Try
                    dao_pa2.fields.SMALL_UNIT = dr("SMALL_UNIT")
                Catch ex As Exception

                End Try
                dao_pa2.insert()
            Next

            For Each dr As DataRow In dt_DRUG_REGISTRATION_PRODUCER.Rows
                Dim dao_pro2 As New DAO_DRUG.TB_DRRGT_PRODUCER
                dao_pro2.fields.FK_IDA = main_ida
                Try
                    dao_pro2.fields.addr_ida = dr("addr_ida")
                Catch ex As Exception

                End Try
                Try
                    dao_pro2.fields.FK_PRODUCER = dr("FK_PRODUCER")
                Catch ex As Exception

                End Try
                Try
                    dao_pro2.fields.PRODUCER_WORK_TYPE = dr("PRODUCER_WORK_TYPE")
                Catch ex As Exception

                End Try
                Try
                    dao_pro2.fields.REFERENCE_GMP = dr("REFERENCE_GMP")
                Catch ex As Exception

                End Try

                dao_pro2.insert()
            Next

            Dim dao_po As New DAO_DRUG.TB_DRRGT_PRODUCER_OTHER
            For Each dao_po.fields In p2.DRRGT_PRODUCER_OTHER
                Dim dao_po2 As New DAO_DRUG.TB_DRRGT_PRODUCER_OTHER
                dao_po2.fields.FK_IDA = main_ida
                Try
                    dao_po2.fields.addr_ida = Trim(dao_po.fields.addr_ida)
                Catch ex As Exception

                End Try
                Try
                    dao_po2.fields.FK_PRODUCER = Trim(dao_po.fields.FK_PRODUCER)
                Catch ex As Exception

                End Try
                Try
                    dao_po2.fields.PRODUCER_WORK_TYPE = Trim(dao_po.fields.PRODUCER_WORK_TYPE)
                Catch ex As Exception

                End Try
                Try
                    dao_po2.fields.REFERENCE_GMP = Trim(dao_po.fields.REFERENCE_GMP)
                Catch ex As Exception

                End Try

                dao_po2.insert()
            Next

            ' Dim dao_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
            For Each dr As DataRow In dt_DRUG_REGISTRATION_PROPERTIES.Rows
                Dim dao_prop2 As New DAO_DRUG.TB_DRRGT_PROPERTIES
                dao_prop2.fields.FK_IDA = main_ida
                Try
                    dao_prop2.fields.CHK_DRUG_PROPERTIES = dr("CHK_DRUG_PROPERTIES")
                Catch ex As Exception

                End Try
                Try
                    dao_prop2.fields.CHK_DRUG_PROPERTIES_OTHER = dr("CHK_DRUG_PROPERTIES_OTHER")
                Catch ex As Exception

                End Try
                Try
                    dao_prop2.fields.DRUG_PROPERTIES = dr("DRUG_PROPERTIES")
                Catch ex As Exception

                End Try
                Try
                    dao_prop2.fields.DRUG_PROPERTIES_OTHER = dr("DRUG_PROPERTIES_OTHER")
                Catch ex As Exception

                End Try

                dao_prop2.insert()
            Next

            For Each dr As DataRow In dt_DRUG_REGISTRATION_ATC_DETAIL.Rows
                Dim dao_r_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                dao_r_atc.fields.FK_IDA = main_ida
                Try
                    dao_r_atc.fields.ATC_CODE = dr("ATC_CODE")
                Catch ex As Exception

                End Try

                dao_r_atc.insert()
            Next

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = dao.fields.IDA
            dao_up.update()
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

    Private Function insrt_to_database_new(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try
            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DR
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA(_lcn_ida)
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_rg.GetDataby_IDA(_IDA)
            If Trim(p2.TRANSFER) = "" Then
                dao.fields = p2.drrqts
                Try
                    dao.fields.IDENTIFY = dao_lcn.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception

                End Try
                Try
                    If dao_rg.fields.DRUG_EQ_TO IsNot Nothing Then
                        dao.fields.feepayst = dao_rg.fields.DRUG_EQ_TO

                        Dim dao_tm As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                        dao_tm.GetDataby_TAMRAP_ID(dao_rg.fields.DRUG_EQ_TO)
                        If dao_tm.fields.IS_AUTO = 1 Then
                            dao.fields.TYPE_REQUEST_ID = 5149
                        End If
                    End If
                Catch ex As Exception

                End Try
                Try
                    dao.fields.dvcd = Request.QueryString("tt")
                Catch ex As Exception

                End Try
                If Request.QueryString("tt") = "2" Then
                    If cb_herbal.Checked = True Then
                        dao.fields.feetpcd = 1
                    End If

                ElseIf Request.QueryString("tt") = "1" Then 'แบบ 1 วัน
                    dao.fields.feetpcd = "99"
                End If
                Try
                    If dao_rg.fields.LCNSID IsNot Nothing Then
                        dao.fields.lcnsid = dao_rg.fields.LCNSID
                    Else
                        dao.fields.lcnsid = 0
                    End If

                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_STRENGTH = dao_rg.fields.DRUG_STR
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ctgcd = dao_rg.fields.DRUG_GROUP
                Catch ex As Exception

                End Try
                Try
                    If Request.QueryString("tt") = "2" Then
                        dao.fields.YOR8_FK_IDA = ddl_yor8.SelectedValue
                    End If
                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_STYLE = dao_rg.fields.DRUG_STYLE
                Catch ex As Exception

                End Try
                Try
                    dao.fields.UNIT_BIO = dao_rg.fields.UNIT_BIO
                Catch ex As Exception

                End Try
                Try
                    dao.fields.UNIT_NORMAL = dao_rg.fields.UNIT_NORMAL
                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_PACKING = dao_rg.fields.DRUG_PACKING
                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
                Catch ex As Exception

                End Try
                Try
                    'Dim val As String = ""
                    'If p2.drrgts.CHK_LCN_SUBTYPE1.Contains("ผลิต") Then
                    '    val = "1"
                    'ElseIf p2.drrgts.CHK_LCN_SUBTYPE1.Contains("แบ่งบรรจุ") Then
                    '    val = "2"

                    'ElseIf p2.drrgts.CHK_LCN_SUBTYPE1.Contains("นำหรือสั่ง") Then
                    '    val = "3"
                    'Else
                    '    val = ""
                    'End If
                    dao.fields.CHK_LCN_SUBTYPE1 = p2.drrgts.CHK_LCN_SUBTYPE1
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CHK_LCN_SUBTYPE2 = p2.drrgts.CHK_LCN_SUBTYPE2
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CHK_LCN_SUBTYPE3 = p2.drrgts.CHK_LCN_SUBTYPE3
                Catch ex As Exception

                End Try
                Try
                    'If Trim(p2.drrgts.TABEAN_TYPE1) <> "" Then
                    '    dao.fields.TABEAN_TYPE1 = Trim(p2.drrgts.TABEAN_TYPE1)
                    'ElseIf Trim(p2.drrqts.TABEAN_TYPE1) <> "" Then
                    '    dao.fields.TABEAN_TYPE1 = Trim(p2.drrgts.TABEAN_TYPE1)
                    'Else
                    dao.fields.TABEAN_TYPE1 = p2.TABEAN_TYPE1
                    'End If


                Catch ex As Exception
                    'dao.fields.TABEAN_TYPE1 = "99"
                End Try
                Try
                    'If Trim(p2.drrgts.TABEAN_TYPE2) <> "" Then
                    '    dao.fields.TABEAN_TYPE2 = Trim(p2.drrgts.TABEAN_TYPE2)
                    'ElseIf Trim(p2.drrqts.TABEAN_TYPE1) <> "" Then
                    '    dao.fields.TABEAN_TYPE2 = Trim(p2.drrgts.TABEAN_TYPE2)
                    'Else
                    dao.fields.TABEAN_TYPE2 = p2.TABEAN_TYPE2
                    'End If
                Catch ex As Exception
                    'dao.fields.TABEAN_TYPE1 = "99"
                End Try
                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_ID(_ProcessID)
                Try
                    dao.fields.rgttpcd = dao_pro.fields.PROCESS_DESCRIPTION
                Catch ex As Exception

                End Try

                Try
                    dao.fields.PROCESS_ID = _ProcessID
                Catch ex As Exception

                End Try
                'Try
                '    dao.fields.ctgcd = dao_rg.fields.ctgcd
                'Catch ex As Exception

                'End Try
                Try
                    dao.fields.kindcd = dao_rg.fields.kindcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.dsgcd = dao_rg.fields.FK_DOSAGE_FORM
                Catch ex As Exception

                End Try
                Try
                    dao.fields.classcd = dao_rg.fields.GROUP_TYPE
                Catch ex As Exception

                End Try
                Try
                    dao.fields.FK_DOSAGE_FORM = p2.drrqts.FK_DOSAGE_FORM
                Catch ex As Exception

                End Try
                Try
                    dao.fields.kindcd = p2.drrqts.kindcd
                Catch ex As Exception

                End Try
                'Try
                '    dao.fields.ctgcd = p2.drrqts.ctgcd
                'Catch ex As Exception

                'End Try
                dao.fields.STATUS_ID = 1
                dao.fields.FK_IDA = _IDA
                dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
                Try
                    dao.fields.pvncd = _CLS.PVCODE
                Catch ex As Exception

                End Try

                dao.fields.FK_LCN_IDA = _lcn_ida
                Try
                    dao.fields.thadrgnm = dao_rg.fields.DRUG_NAME_THAI
                Catch ex As Exception

                End Try
                Try
                    dao.fields.engdrgnm = dao_rg.fields.DRUG_NAME_OTHER
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lcntpcd = dao_lcn.fields.lcntpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lcnno = dao_lcn.fields.lcnno
                Catch ex As Exception

                End Try
                Dim chw As String = ""
                Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
                Try
                    dao_cpn.GetData_by_chngwtcd(dao_lcn.fields.pvncd)
                    chw = dao_cpn.fields.thacwabbr
                Catch ex As Exception

                End Try
                Try
                    dao.fields.classcd = dao_rg.fields.GROUP_TYPE 'ประเภทของยา
                Catch ex As Exception

                End Try
                Try
                    dao.fields.PACKAGE_DETAIL = dao_rg.fields.PACKAGE_DETAIL
                Catch ex As Exception

                End Try
                dao.fields.pvnabbr = chw
                'dao.fields.rcvdate = Date.Now
                '  dao.fields.xmlnm = "FA-8-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
                dao.fields.TR_ID = TR_ID
                dao.fields.cscd = Nothing
                Try
                    'If Trim(p2.TRANSFER) <> "" Then
                    dao.fields.FK_TRANSFER = p2.TRANSFER
                    'End If
                Catch ex As Exception

                End Try
                Try
                    If Trim(p2.TRANSFER) <> "" Then
                        dao.fields.TRANSFER_TYPE = "1"

                    End If

                Catch ex As Exception

                End Try

                dao.insert()
            Else
                '----------------------------------------------------------------------------------------------------
                Dim dao_rgt As New DAO_DRUG.ClsDBdrrgt

                Try
                    dao_rgt.GetDataby_IDA(Trim(p2.TRANSFER))
                Catch ex As Exception

                End Try
                'Try
                '    dao.fields.
                'Catch ex As Exception

                'End Try
                Try
                    dao.fields.IDENTIFY = txt_citizenid.Text ' _CLS.CITIZEN_ID_AUTHORIZE 'dao_rgt.fields.IDENTIFY
                Catch ex As Exception

                End Try
                Try
                    dao.fields.accttp = dao_rgt.fields.accttp
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CHK_LCN_SUBTYPE1 = dao_rgt.fields.CHK_LCN_SUBTYPE1
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CHK_LCN_SUBTYPE2 = dao_rgt.fields.CHK_LCN_SUBTYPE2
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CHK_LCN_SUBTYPE3 = dao_rgt.fields.CHK_LCN_SUBTYPE3
                Catch ex As Exception

                End Try
                Try
                    dao.fields.classcd = dao_rgt.fields.classcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ctgcd = dao_rgt.fields.ctgcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.CTZNO = _CLS.CITIZEN_ID
                Catch ex As Exception

                End Try
                Try
                    dao.fields.drgbiost = dao_rgt.fields.drgbiost
                Catch ex As Exception

                End Try
                Try
                    dao.fields.drgexpst = dao_rgt.fields.drgexpst
                Catch ex As Exception

                End Try
                Try
                    dao.fields.drgnewst = dao_rgt.fields.drgnewst
                Catch ex As Exception

                End Try
                Try
                    dao.fields.drgtpcd = dao_rgt.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_COLOR = dao_rgt.fields.DRUG_COLOR
                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_PACKING = dao_rgt.fields.DRUG_PACKING
                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_STRENGTH = dao_rgt.fields.DRUG_STRENGTH
                Catch ex As Exception

                End Try
                Try
                    dao.fields.DRUG_STYLE = dao_rgt.fields.DRUG_STYLE
                Catch ex As Exception

                End Try
                Try
                    dao.fields.dsgcd = dao_rgt.fields.dsgcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.engdrgnm = dao_rgt.fields.engdrgnm
                Catch ex As Exception

                End Try
                Try
                    dao.fields.FK_DOSAGE_FORM = dao_rgt.fields.FK_DOSAGE_FORM
                Catch ex As Exception

                End Try
                Try
                    dao.fields.FK_IDA = dao_rg.fields.IDA
                Catch ex As Exception

                End Try
                Try
                    dao.fields.FK_LCN_IDA = _lcn_ida
                Catch ex As Exception

                End Try
                Try
                    dao.fields.FK_REGIS = dao_rg.fields.IDA
                Catch ex As Exception

                End Try
                Try
                    dao.fields.FK_TRANSFER = p2.TRANSFER
                Catch ex As Exception

                End Try
                'Try
                '    dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
                'Catch ex As Exception

                'End Try
                Try
                    dao.fields.kindcd = dao_rgt.fields.kindcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lcnabbr = dao_rgt.fields.lcnabbr
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lcnno = dao_rg.fields.LCNNO
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lcnsid = dao_rgt.fields.lcnsid
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lcntpcd = dao_rg.fields.LCNTPCD
                Catch ex As Exception

                End Try
                Try
                    dao.fields.lpvncd = dao_lcn.fields.pvncd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.PACKAGE_DETAIL = dao_rgt.fields.PACKAGE_DETAIL
                Catch ex As Exception

                End Try
                Try
                    dao.fields.packcd = dao_rgt.fields.packcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.potency = dao_rgt.fields.potency
                Catch ex As Exception

                End Try
                Try
                    dao.fields.PROCESS_ID = _ProcessID
                Catch ex As Exception

                End Try
                Try
                    dao.fields.pvnabbr = dao_lcn.fields.pvnabbr
                Catch ex As Exception

                End Try
                Try
                    dao.fields.pvncd = _CLS.PVCODE
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgttpcd = dao_rgt.fields.rgttpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.STATUS_ID = 1
                Catch ex As Exception

                End Try
                Try
                    dao.fields.TABEAN_TYPE = dao_rgt.fields.TABEAN_TYPE
                Catch ex As Exception

                End Try
                Try
                    dao.fields.TABEAN_TYPE1 = dao_rgt.fields.TABEAN_TYPE1
                Catch ex As Exception

                End Try
                Try
                    dao.fields.TABEAN_TYPE2 = dao_rgt.fields.TABEAN_TYPE2
                Catch ex As Exception

                End Try
                Try
                    dao.fields.thadrgnm = dao_rgt.fields.thadrgnm
                Catch ex As Exception

                End Try
                Try
                    dao.fields.TR_ID = TR_ID
                Catch ex As Exception

                End Try
                Try
                    dao.fields.TRANSFER_TYPE = 1
                Catch ex As Exception

                End Try
                Try
                    dao.fields.UNIT_BIO = dao_rgt.fields.UNIT_BIO
                Catch ex As Exception

                End Try
                Try
                    dao.fields.UNIT_NORMAL = dao_rgt.fields.UNIT_NORMAL
                Catch ex As Exception

                End Try
                dao.insert()
            End If

            If Trim(p2.TRANSFER) = "" Then
                Dim dao_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                For Each dao_atc.fields In p2.DRRQT_ATC_DETAIL
                    Dim dao_atc2 As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                    dao_atc2.fields.FK_IDA = _IDA
                    dao_atc2.fields.ATC_CODE = Trim(dao_atc.fields.ATC_CODE)
                    dao_atc2.insert()
                Next



                Dim bao_show As New BAO_SHOW
                Dim dt_DRUG_REGISTRATION_PACKAGE As New DataTable
                Dim dt_DRUG_REGISTRATION_ATC_DETAIL As New DataTable
                Dim dt_DRUG_REGISTRATION_DETAIL_CAS As New DataTable
                Dim dt_DRUG_REGISTRATION_DETAIL_CAS_I As New DataTable
                Dim dt_DRUG_REGISTRATION_PROPERTIES As New DataTable
                Dim dt_DRUG_REGISTRATION_PRODUCER As New DataTable
                Dim dt_DRUG_REGISTRATION_PRODUCER_IN As New DataTable
                'Dim dt_DRUG_REGISTRATION_EQTO As New DataTable

                dt_DRUG_REGISTRATION_DETAIL_CAS = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_BY_FK_IDA(_IDA)
                dt_DRUG_REGISTRATION_PACKAGE = bao_show.SP_DRUG_REGISTRATION_PACKAGE_BY_IDA(_IDA)
                dt_DRUG_REGISTRATION_ATC_DETAIL = bao_show.SP_DRUG_REGISTRATION_ATC_DETAIL_BY_FK_IDA(_IDA)

                dt_DRUG_REGISTRATION_PROPERTIES = bao_show.SP_DRUG_REGISTRATION_PROPERTIES_BY_FK_IDA(_IDA)
                dt_DRUG_REGISTRATION_PRODUCER = bao_show.SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA(_IDA)

                dt_DRUG_REGISTRATION_PRODUCER_IN = bao_show.SP_DRUG_REGISTRATION_PRODUCER_IN_BY_FK_IDA(_IDA)

                Dim main_ida As Integer = 0
                Try
                    main_ida = dao.fields.IDA
                Catch ex As Exception

                End Try

                'Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
                Dim iii As Integer = 1
                For Each dr As DataRow In dt_DRUG_REGISTRATION_DETAIL_CAS.Rows
                    Dim dao_cas2 As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                    dao_cas2.fields.FK_IDA = main_ida
                    Try
                        dao_cas2.fields.BASE_FORM = dr("BASE_FORM")
                    Catch ex As Exception

                    End Try

                    Try
                        dao_cas2.fields.EQTO_IOWA = dr("EQTO_IOWA")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.EQTO_SUNITCD = dr("EQTO_SUNITCD")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.IOWA = dr("IOWA")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.QTY = dr("QTY")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.SUNITCD = dr("SUNITCD")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.AORI = dr("AORI")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.REMARK = dr("REMARK")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.REF = dr("REF")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_cas2.fields.FK_SET = dr("FK_SET")
                    Catch ex As Exception

                    End Try
                    dao_cas2.fields.ROWS = dr("ROWS")
                    dao_cas2.insert()

                    Dim dao_eq As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                    dao_eq.GetDataby_FK_IDA(dr("IDA"))
                    'Dim i_eq As Integer = 0
                    For Each dao_eq.fields In dao_eq.datas
                        'i_eq += 1
                        Dim dao_rq_eq As New DAO_DRUG.TB_DRRQT_EQTO
                        With dao_rq_eq.fields
                            .FK_IDA = dao_cas2.fields.IDA
                            Try
                                .IOWA = dao_eq.fields.IOWA
                            Catch ex As Exception

                            End Try
                            Try
                                .MULTIPLY = dao_eq.fields.MULTIPLY
                            Catch ex As Exception

                            End Try
                            Try
                                .QTY = dao_eq.fields.QTY
                            Catch ex As Exception

                            End Try
                            Try
                                .ROWS = dao_eq.fields.ROWS
                            Catch ex As Exception

                            End Try

                            Try
                                .STR_VALUE = dao_eq.fields.STR_VALUE
                            Catch ex As Exception

                            End Try
                            Try
                                .SUNITCD = dao_eq.fields.SUNITCD
                            Catch ex As Exception

                            End Try
                            Try
                                .aori = dao_eq.fields.aori
                            Catch ex As Exception

                            End Try
                            Try
                                .FK_SET = dao_eq.fields.FK_SET
                            Catch ex As Exception

                            End Try
                            Try
                                .FK_DRRQT_IDA = main_ida
                            Catch ex As Exception

                            End Try
                            Try
                                .CONDITION = dao_eq.fields.CONDITION
                            Catch ex As Exception

                            End Try
                        End With
                        dao_rq_eq.insert()
                    Next

                    iii += 1
                Next

                Dim dao_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                dao_pack.GetDataby_FK_IDA(_IDA)
                For Each dao_pack.fields In dao_pack.datas
                    Dim dao_pa2 As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
                    dao_pa2.fields.FK_IDA = main_ida
                    Try
                        dao_pa2.fields.BARCODE = dao_pack.fields.BARCODE
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.BIG_UNIT = dao_pack.fields.BIG_UNIT
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.SMALL_UNIT = dao_pack.fields.SMALL_UNIT
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.BIG_AMOUNT = dao_pack.fields.BIG_AMOUNT
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.DATE_ADD = Date.Now
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.IM_DETAIL = dao_pack.fields.IM_DETAIL
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.IM_QTY = dao_pack.fields.IM_QTY
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.PACKAGE_NAME = dao_pack.fields.PACKAGE_NAME
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pa2.fields.SUM = dao_pack.fields.SUM
                    Catch ex As Exception

                    End Try
                    dao_pa2.insert()
                Next

                For Each dr As DataRow In dt_DRUG_REGISTRATION_PRODUCER.Rows
                    Dim dao_pro2 As New DAO_DRUG.TB_DRRQT_PRODUCER
                    dao_pro2.fields.FK_IDA = main_ida
                    Try
                        dao_pro2.fields.addr_ida = dr("addr_ida")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pro2.fields.FK_PRODUCER = dr("FK_PRODUCER")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pro2.fields.PRODUCER_WORK_TYPE = dr("PRODUCER_WORK_TYPE")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_pro2.fields.REFERENCE_GMP = dr("REFERENCE_GMP")
                    Catch ex As Exception

                    End Try

                    dao_pro2.insert()
                Next

                Dim dao_po As New DAO_DRUG.TB_DRRQT_PRODUCER_OTHER
                For Each dao_po.fields In p2.DRRQT_PRODUCER_OTHER
                    Dim dao_po2 As New DAO_DRUG.TB_DRRQT_PRODUCER_OTHER
                    dao_po2.fields.FK_IDA = main_ida
                    Try
                        dao_po2.fields.addr_ida = Trim(dao_po.fields.addr_ida)
                    Catch ex As Exception

                    End Try

                    Try
                        dao_po2.fields.FK_PRODUCER = Trim(dao_po.fields.FK_PRODUCER)
                    Catch ex As Exception

                    End Try
                    Try
                        dao_po2.fields.PRODUCER_WORK_TYPE = Trim(dao_po.fields.PRODUCER_WORK_TYPE)
                    Catch ex As Exception

                    End Try
                    Try
                        dao_po2.fields.REFERENCE_GMP = Trim(dao_po.fields.REFERENCE_GMP)
                    Catch ex As Exception

                    End Try

                    dao_po2.insert()
                Next

                ' Dim dao_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
                For Each dr As DataRow In dt_DRUG_REGISTRATION_PROPERTIES.Rows
                    Dim dao_prop2 As New DAO_DRUG.TB_DRRQT_PROPERTIES
                    dao_prop2.fields.FK_IDA = main_ida
                    Try
                        dao_prop2.fields.CHK_DRUG_PROPERTIES = dr("CHK_DRUG_PROPERTIES")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_prop2.fields.CHK_DRUG_PROPERTIES_OTHER = dr("CHK_DRUG_PROPERTIES_OTHER")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_prop2.fields.DRUG_PROPERTIES = dr("DRUG_PROPERTIES")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_prop2.fields.DRUG_PROPERTIES_OTHER = dr("DRUG_PROPERTIES_OTHER")
                    Catch ex As Exception

                    End Try

                    dao_prop2.insert()
                Next

                For Each dr As DataRow In dt_DRUG_REGISTRATION_ATC_DETAIL.Rows
                    Dim dao_r_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                    dao_r_atc.fields.FK_IDA = main_ida
                    Try
                        dao_r_atc.fields.ATC_CODE = dr("ATC_CODE")
                    Catch ex As Exception

                    End Try

                    dao_r_atc.insert()
                Next

                Dim dao_pro_rgtin As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                dao_pro_rgtin.GetDataby_FK_IDA(_IDA)
                For Each dao_pro_rgtin.fields In dao_pro_rgtin.datas
                    Dim dao_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
                    dao_pro_in.fields.FK_IDA = main_ida
                    dao_pro_in.fields.FK_LCN_IDA = dao_pro_rgtin.fields.FK_PRODUCER
                    Try
                        dao_pro_in.fields.funccd = dao_pro_rgtin.fields.PRODUCER_WORK_TYPE
                    Catch ex As Exception

                    End Try

                    dao_pro_in.insert()
                Next


                Dim dao_pro_color As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
                dao_pro_color.GetDataby_FK_IDA(_IDA)
                For Each dao_pro_color.fields In dao_pro_color.datas
                    Dim dao_color As New DAO_DRUG.TB_DRRQT_COLOR
                    dao_color.fields.FK_IDA = main_ida
                    dao_color.fields.COLOR_NAME1 = dao_pro_color.fields.COLOR_NAME1
                    dao_color.fields.COLOR_NAME2 = dao_pro_color.fields.COLOR_NAME2
                    dao_color.fields.COLOR_NAME3 = dao_pro_color.fields.COLOR_NAME3
                    dao_color.fields.COLOR_NAME4 = dao_pro_color.fields.COLOR_NAME4
                    dao_color.fields.COLOR1 = dao_pro_color.fields.COLOR1
                    dao_color.fields.COLOR2 = dao_pro_color.fields.COLOR2
                    dao_color.fields.COLOR3 = dao_pro_color.fields.COLOR3
                    dao_color.fields.COLOR4 = dao_pro_color.fields.COLOR4
                    dao_color.insert()
                Next


                Dim dao_each As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
                dao_each.GetDataby_FK_IDA(_IDA)
                For Each dao_each.fields In dao_each.datas
                    Dim dao_dr_each As New DAO_DRUG.TB_DRRQT_EACH
                    dao_dr_each.fields.FK_IDA = main_ida
                    dao_dr_each.fields.EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
                    Try
                        dao_dr_each.fields.sunitcd = dao_each.fields.sunitcd
                    Catch ex As Exception

                    End Try
                    Try
                        dao_dr_each.fields.FK_SET = dao_each.fields.FK_SET
                    Catch ex As Exception

                    End Try
                    dao_dr_each.insert()
                Next

                Dim dao_KEEP_DRUG As New DAO_DRUG.TB_DRUG_REGISTRATION_KEEP_DRUG
                dao_KEEP_DRUG.GetDataby_FK_IDA(_IDA)
                For Each dao_KEEP_DRUG.fields In dao_KEEP_DRUG.datas
                    Dim dao_DRRGT_KEEP As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
                    With dao_DRRGT_KEEP.fields
                        .FK_IDA = main_ida
                        .AGE_DAY = dao_KEEP_DRUG.fields.AGE_DAY
                        .AGE_HOUR = dao_KEEP_DRUG.fields.AGE_HOUR
                        .AGE_MONTH = dao_KEEP_DRUG.fields.AGE_MONTH
                        '.DRUG_DETAIL = dao_KEEP_DRUG.fields.KEEP_DETAIL
                        .KEEP_DESCRIPTION = dao_KEEP_DRUG.fields.KEEP_DETAIL
                        .TEMPERATE1 = dao_KEEP_DRUG.fields.TEMPERATE1
                        .TEMPERATE2 = dao_KEEP_DRUG.fields.TEMPERATE2
                    End With
                    dao_DRRGT_KEEP.insert()
                Next

                Dim dao_rq_DRUG_USE As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
                dao_rq_DRUG_USE.GetDataby_FK_IDA(_IDA)
                For Each dao_rq_DRUG_USE.fields In dao_rq_DRUG_USE.datas
                    Dim dao_DRRGT_DTL As New DAO_DRUG.TB_DRRQT_DTL_TEXT
                    With dao_DRRGT_DTL.fields
                        .FK_IDA = main_ida
                        .dtl = dao_rq_DRUG_USE.fields.DRUG_USE
                    End With
                    dao_DRRGT_DTL.insert()
                Next


                Dim dao_rq_ANI As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL
                dao_rq_ANI.GetData_by_FK_IDA(_IDA)
                For Each dao_rq_ANI.fields In dao_rq_ANI.datas


                    Dim dao_ani As New DAO_DRUG.ClsDBdrramldrg
                    With dao_ani.fields
                        .FK_IDA = main_ida
                        .amlsubcd = dao_rq_ANI.fields.amlsubcd
                        .amltpcd = dao_rq_ANI.fields.amltpcd
                        .drgtpcd = dao_rq_ANI.fields.drgtpcd
                        .pvncd = dao_rq_ANI.fields.pvncd
                        .rgtno = dao_rq_ANI.fields.rgtno
                        .rgttpcd = dao_rq_ANI.fields.rgttpcd
                        .usetpcd = dao_rq_ANI.fields.usetpcd
                    End With
                    dao_ani.insert()

                    Dim dao_rq_anisub As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL_SUB
                    dao_rq_anisub.GetDataby_FK_IDA(dao_rq_ANI.fields.IDA)
                    For Each dao_rq_anisub.fields In dao_rq_anisub.datas
                        Dim dao_ani_sub As New DAO_DRUG.ClsDBdrramluse
                        With dao_ani_sub.fields
                            .FK_IDA = dao_ani.fields.IDA
                            .amlsubcd = dao_rq_anisub.fields.amlsubcd
                            .amltpcd = dao_rq_anisub.fields.amltpcd
                            .ampartcd = dao_rq_anisub.fields.ampartcd
                            .drgtpcd = dao_rq_anisub.fields.drgtpcd
                            .nouse = dao_rq_anisub.fields.nouse
                            .packuse = dao_rq_anisub.fields.packuse
                            .pvncd = dao_rq_anisub.fields.pvncd
                            .rgtno = dao_rq_anisub.fields.rgtno
                            .rgttpcd = dao_rq_anisub.fields.rgttpcd
                            .STOP_UNIT1 = dao_rq_anisub.fields.STOP_UNIT1
                            .STOP_UNIT2 = dao_rq_anisub.fields.STOP_UNIT2
                            .STOP_VALUE1 = dao_rq_anisub.fields.STOP_VALUE1
                            .STOP_VALUE2 = dao_rq_anisub.fields.STOP_VALUE2
                            .stpdrg = dao_rq_anisub.fields.stpdrg
                            .stpdrgcd = dao_rq_anisub.fields.stpdrgcd
                            .usetpcd = dao_rq_anisub.fields.usetpcd
                        End With
                        dao_ani_sub.insert()
                    Next

                Next
                Try
                    If Request.QueryString("tt") <> "" Then
                        Dim dao_rqq As New DAO_DRUG.ClsDBdrrqt
                        dao_rqq.GetDataby_IDA(main_ida)
                        Dim dao_con As New DAO_DRUG.TB_15_TAMRAP_CONDITION
                        dao_con.Getdata_by_TAMRAP_ID(dao_rqq.fields.feepayst)
                        For Each dao_con.fields In dao_con.datas
                            Dim dao_con_rq As New DAO_DRUG.TB_DRRQT_CONDITION
                            With dao_con_rq.fields
                                .CONDITION1 = dao_con.fields.CONDITION1
                                .CONDITION2 = dao_con.fields.CONDITION2
                                .FK_IDA = main_ida
                            End With
                            dao_con_rq.insert()
                        Next
                    End If
                Catch ex As Exception

                End Try

                Dim dao_prop_det As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
                dao_prop_det.fields.FK_IDA = main_ida
                Try
                    dao_prop_det.fields.DRUG_PROPERTIES_AND_DETAIL = dao_rg.fields.DRUG_COLOR
                    dao_prop_det.fields.ROWS = 1
                Catch ex As Exception

                End Try

                dao_prop_det.insert()


                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
                dao_up.fields.REF_NO = dao.fields.IDA
                dao_up.update()

            Else
                insert_tabean(dao.fields.IDA, p2.TRANSFER)
            End If

        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

    Sub insert_tabean(ByVal FK_IDA As Integer, ByVal fk_transfer As Integer)
        Dim dao_copy As New DAO_DRUG.ClsDBdrrgt
        dao_copy.GetDataby_IDA(fk_transfer)
        'Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        'With dao_drrgt.fields
        '    .accttp = dao_copy.fields.accttp
        '    .appdate = dao_copy.fields.appdate
        '    .CHK_LCN_SUBTYPE1 = dao_copy.fields.CHK_LCN_SUBTYPE1
        '    .CHK_LCN_SUBTYPE2 = dao_copy.fields.CHK_LCN_SUBTYPE2
        '    .CHK_LCN_SUBTYPE3 = dao_copy.fields.CHK_LCN_SUBTYPE3
        '    .classcd = dao_copy.fields.classcd
        '    .CONSIDER_DATE = dao_copy.fields.CONSIDER_DATE
        '    .ctgcd = dao_copy.fields.ctgcd
        '    .CTZNO = dao_copy.fields.CTZNO
        '    .drgbiost = dao_copy.fields.drgbiost
        '    .drgexpst = dao_copy.fields.drgexpst
        '    .drgnewst = dao_copy.fields.drgnewst
        '    'Try
        '    '    .drgtpcd = ddl_tabean_group.SelectedValue 'dao_copy.fields.drgtpcd
        '    'Catch ex As Exception

        '    'End Try

        '    .DRUG_STRENGTH = dao_copy.fields.DRUG_STRENGTH
        '    .dsgcd = dao_copy.fields.dsgcd
        '    .engdrgnm = dao_copy.fields.engdrgnm
        '    .EXTEND_DATE = dao_copy.fields.EXTEND_DATE
        '    .FIRST_APP_DATE = dao_copy.fields.FIRST_APP_DATE
        '    .FK_DOSAGE_FORM = dao_copy.fields.FK_DOSAGE_FORM
        '    .FK_DRRQT = FK_IDA
        '    .FK_IDA = dao_copy.fields.FK_IDA
        '    .FK_LCN_IDA = dao_copy.fields.FK_LCN_IDA
        '    .FK_STAFF_OFFER_IDA = dao_copy.fields.FK_STAFF_OFFER_IDA
        '    .frtappdate = dao_copy.fields.FIRST_APP_DATE
        '    .IDENTIFY = dao_copy.fields.IDENTIFY
        '    .kindcd = dao_copy.fields.kindcd
        '    .lcnabbr = dao_copy.fields.lcnabbr
        '    .UNIT_NORMAL = dao_copy.fields.UNIT_NORMAL
        '    .DRUG_PACKING = dao_copy.fields.DRUG_PACKING
        '    .UNIT_BIO = dao_copy.fields.UNIT_BIO
        '    .DRUG_STYLE = dao_copy.fields.DRUG_STYLE
        '    .DRUG_STRENGTH = dao_copy.fields.DRUG_STRENGTH
        '    Try
        '        .lcnno = dao_copy.fields.lcnno
        '    Catch ex As Exception

        '    End Try

        '    .lcnscd = dao_copy.fields.lcnscd
        '    .lcnsid = dao_copy.fields.lcnsid
        '    .lcntpcd = dao_copy.fields.lcntpcd
        '    .lctcd = dao_copy.fields.lctcd
        '    .lctnmcd = dao_copy.fields.lctnmcd
        '    Try
        '        .lmdfdate = dao_copy.fields.lmdfdate
        '    Catch ex As Exception

        '    End Try

        '    .lpvncd = dao_copy.fields.lpvncd
        '    .lstfcd = dao_copy.fields.lstfcd
        '    .ndrgtp = dao_copy.fields.ndrgtp
        '    .packcd = dao_copy.fields.packcd
        '    .potency = dao_copy.fields.potency
        '    .PROCESS_ID = dao_copy.fields.PROCESS_ID
        '    .pvnabbr = dao_copy.fields.pvnabbr
        '    .pvncd = dao_copy.fields.pvncd
        '    Try
        '        .rcvdate = dao_copy.fields.rcvdate
        '    Catch ex As Exception

        '    End Try

        '    .rcvno = dao_copy.fields.rcvno
        '    .REGIST_TYPE = dao_copy.fields.REGIST_TYPE
        '    .REMARK = dao_copy.fields.REMARK
        '    .rgtno = dao_copy.fields.rgtno
        '    Try
        '        .rgttpcd = dao_copy.fields.rgttpcd
        '        '.rgttpcd = ddl_rgttpcd.SelectedValue
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        .drgtpcd = dao_copy.fields.drgtpcd
        '    Catch ex As Exception

        '    End Try
        '    .STAFF_APP_IDENTIFY = dao_copy.fields.STAFF_APP_IDENTIFY
        '    .STATUS_ID = dao_copy.fields.STATUS_ID
        '    .TABEAN_TYPE = dao_copy.fields.TABEAN_TYPE
        '    .thadrgnm = dao_copy.fields.thadrgnm
        '    .TR_ID = dao_copy.fields.TR_ID
        '    Try
        '        .UNIT_BIO = dao_copy.fields.UNIT_BIO
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        .UNIT_NORMAL = dao_copy.fields.UNIT_NORMAL
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        .DRUG_PACKING = dao_copy.fields.DRUG_PACKING
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        .TYPE_REQUEST_ID = dao_copy.fields.TYPE_REQUEST_ID
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        .DRUG_STRENGTH = dao_copy.fields.DRUG_STRENGTH
        '    Catch ex As Exception

        '    End Try
        'End With
        'dao_drrgt.insert()
        Dim IDA_rgt As Integer = FK_IDA 'dao_drrgt.fields.IDA

        Dim dao_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
        dao_atc.GetDataby_FKIDA(fk_transfer)
        For Each dao_atc.fields In dao_atc.datas
            Dim dao_rgt_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
            With dao_rgt_atc.fields
                .ATC_CODE = dao_atc.fields.ATC_CODE
                .ATC_IDA = dao_atc.fields.ATC_IDA
                .FK_IDA = IDA_rgt
            End With
            dao_rgt_atc.insert()
        Next


        Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
        dao_cas.GetDataby_FKIDA(fk_transfer)
        For Each dao_cas.fields In dao_cas.datas
            Dim dao_rgt_cas As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
            With dao_rgt_cas.fields
                .AORI = dao_cas.fields.AORI
                .BASE_FORM = dao_cas.fields.BASE_FORM
                .EQTO_IOWA = dao_cas.fields.EQTO_IOWA
                .EQTO_QTY = dao_cas.fields.EQTO_QTY
                .EQTO_SUNITCD = dao_cas.fields.EQTO_SUNITCD
                .FK_IDA = IDA_rgt
                .FK_SET = dao_cas.fields.FK_SET
                .IOWA = dao_cas.fields.IOWA
                .QTY = dao_cas.fields.QTY
                .ROWS = dao_cas.fields.ROWS
                .SUNITCD = dao_cas.fields.SUNITCD
                .REMARK = dao_cas.fields.REMARK
            End With
            dao_rgt_cas.insert()

            Dim dao_eq As New DAO_DRUG.TB_DRRGT_EQTO
            dao_eq.GetDataby_FK_IDA(dao_cas.fields.IDA)
            For Each dao_eq.fields In dao_eq.datas
                Dim dao_eq_rgt As New DAO_DRUG.TB_DRRQT_EQTO
                With dao_eq_rgt.fields
                    .FK_IDA = dao_rgt_cas.fields.IDA
                    .IOWA = dao_eq.fields.IOWA
                    .MULTIPLY = dao_eq.fields.MULTIPLY
                    .QTY = dao_eq.fields.QTY
                    .ROWS = dao_eq.fields.ROWS
                    .STR_VALUE = dao_eq.fields.STR_VALUE
                    .SUNITCD = dao_eq.fields.SUNITCD
                    .FK_SET = dao_eq.fields.FK_SET
                    .FK_DRRQT_IDA = IDA_rgt
                    .REMARK = dao_eq.fields.REMARK
                End With
                dao_eq_rgt.insert()
            Next
        Next


        Dim dao_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
        dao_pack.GetDataby_FKIDA(fk_transfer)
        For Each dao_pack.fields In dao_pack.datas
            Dim dao_rgt_pack As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
            With dao_rgt_pack.fields
                .BARCODE = dao_pack.fields.BARCODE
                .BIG_UNIT = dao_pack.fields.BIG_UNIT
                .CHECK_PACKAGE = dao_pack.fields.CHECK_PACKAGE
                .FK_IDA = IDA_rgt
                .MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
                .MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
                .SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
                .SMALL_UNIT = dao_pack.fields.SMALL_UNIT
            End With
            dao_rgt_pack.insert()
        Next


        Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
        dao_pro.GetDataby_FK_IDA(fk_transfer)
        For Each dao_pro.fields In dao_pro.datas
            Dim dao_rgt_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
            With dao_rgt_pro.fields
                .addr_ida = dao_pro.fields.addr_ida
                .drgtpcd = dao_pro.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .FK_PRODUCER = dao_pro.fields.FK_PRODUCER
                .frgncd = dao_pro.fields.frgncd
                .frgnlctcd = dao_pro.fields.frgnlctcd
                .funccd = dao_pro.fields.funccd
                .lcnno = dao_pro.fields.lcnno
                .lcntpcd = dao_pro.fields.lcntpcd
                .PRODUCER_WORK_TYPE = dao_pro.fields.PRODUCER_WORK_TYPE
                .pvncd = dao_pro.fields.pvncd
                .rcvno = dao_pro.fields.rcvno
                .REFERENCE_GMP = dao_pro.fields.REFERENCE_GMP
                .rgtno = dao_pro.fields.rgtno
                .rgttpcd = dao_pro.fields.rgttpcd
                .TR_ID = dao_pro.fields.TR_ID
            End With
            dao_rgt_pro.insert()
        Next


        Dim dao_pro_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
        dao_pro_in.GetDataby_FK_IDA(fk_transfer)
        For Each dao_pro_in.fields In dao_pro_in.datas
            Dim dao_rgt_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
            With dao_rgt_pro_in.fields
                .drgtpcd = dao_pro_in.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .funccd = dao_pro_in.fields.funccd
                .lcnno = dao_pro_in.fields.lcnno
                .lcntpcd = dao_pro_in.fields.lcntpcd
                .rgtno = dao_pro_in.fields.rgtno
                .rgttpcd = dao_pro_in.fields.rgttpcd
                .FK_LCN_IDA = dao_pro_in.fields.FK_LCN_IDA
                .rgtno = dao_pro_in.fields.rgtno
                .rgttpcd = dao_pro_in.fields.rgttpcd
                .lctcd = dao_pro_in.fields.lctcd
                .lcnsid = dao_pro_in.fields.lcnsid
            End With
            dao_rgt_pro_in.insert()
        Next


        Dim dao_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
        dao_prop.GetDataby_FK_IDA(fk_transfer)
        For Each dao_prop.fields In dao_prop.datas
            Dim dao_rgt_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES
            With dao_rgt_prop.fields
                .CHK_DRUG_PROPERTIES = dao_prop.fields.CHK_DRUG_PROPERTIES
                .CHK_DRUG_PROPERTIES_OTHER = dao_prop.fields.CHK_DRUG_PROPERTIES_OTHER
                .DRUG_PROPERTIES = dao_prop.fields.DRUG_PROPERTIES
                .DRUG_PROPERTIES_OTHER = dao_prop.fields.DRUG_PROPERTIES_OTHER
                .FK_IDA = IDA_rgt
            End With
            dao_rgt_prop.insert()
        Next


        Dim dao_prop_det As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
        dao_prop_det.GetDataby_FK_IDA(fk_transfer)
        For Each dao_prop_det.fields In dao_prop_det.datas
            Dim dao_rgt_pd As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            With dao_rgt_pd.fields
                .DRUG_PROPERTIES_AND_DETAIL = dao_prop_det.fields.DRUG_PROPERTIES_AND_DETAIL
                .FK_IDA = IDA_rgt
                .OTHER = dao_prop_det.fields.OTHER
                .ROWS = dao_prop_det.fields.ROWS
            End With
            dao_rgt_pd.insert()
        Next

        Dim dao_each As New DAO_DRUG.TB_DRRGT_EACH
        dao_each.GetDataby_FK_IDA(fk_transfer)
        For Each dao_each.fields In dao_each.datas
            Dim dao_each_rgt As New DAO_DRUG.TB_DRRQT_EACH
            With dao_each_rgt.fields
                .EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
                .FK_IDA = IDA_rgt
                .sunitcd = dao_each.fields.sunitcd
                .EACH_TXT = dao_each.fields.EACH_TXT
                .FK_SET = dao_each.fields.FK_SET
            End With
            dao_each_rgt.insert()
        Next
        '
        Dim dao_keep As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
        dao_keep.GetDataby_FKIDA(fk_transfer)
        For Each dao_keep.fields In dao_keep.datas
            Dim dao_keep_rgt As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
            With dao_keep_rgt.fields
                .AGE_DAY = dao_keep.fields.AGE_DAY
                .FK_IDA = IDA_rgt
                .AGE_HOUR = dao_keep.fields.AGE_HOUR
                .AGE_MONTH = dao_keep.fields.AGE_MONTH
                .DRUG_DETAIL = dao_keep.fields.DRUG_DETAIL
                .KEEP_DESCRIPTION = dao_keep.fields.KEEP_DESCRIPTION
                .TEMPERATE1 = dao_keep.fields.TEMPERATE1
                .TEMPERATE2 = dao_keep.fields.TEMPERATE2
            End With
            dao_keep_rgt.insert()
        Next

        'DRRGT_DTL_TEXT
        Dim dao_dtl As New DAO_DRUG.TB_DRRGT_DTL_TEXT
        dao_dtl.GetDataby_FKIDA(fk_transfer)
        For Each dao_dtl.fields In dao_dtl.datas
            Dim dao_dtl_rqt As New DAO_DRUG.TB_DRRQT_DTL_TEXT
            With dao_dtl_rqt.fields
                .drgtpcd = dao_dtl.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .dtl = dao_dtl.fields.dtl
                .engdrgtpnm = dao_dtl.fields.engdrgtpnm
                .keepdesc = dao_dtl.fields.keepdesc
                .pcksize = dao_dtl.fields.pcksize
                .pvncd = dao_dtl.fields.pvncd
                .rgtno = dao_dtl.fields.rgtno
                .rgttpcd = dao_dtl.fields.rgttpcd
                .tphigh = dao_dtl.fields.tphigh
                .tplow = dao_dtl.fields.tplow
                .U1_CODE = dao_dtl.fields.U1_CODE
                .useage = dao_dtl.fields.useage
            End With
            dao_dtl_rqt.insert()
        Next


        Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
        dao_color.GetDataby_FK_IDA(fk_transfer)
        For Each dao_color.fields In dao_color.datas
            Dim dao_color_rqt As New DAO_DRUG.TB_DRRQT_COLOR
            With dao_color_rqt.fields
                .COLOR_NAME1 = dao_color.fields.COLOR_NAME1
                .FK_IDA = IDA_rgt
                .COLOR_NAME2 = dao_color.fields.COLOR_NAME2
                .COLOR_NAME3 = dao_color.fields.COLOR_NAME3
                .COLOR_NAME4 = dao_color.fields.COLOR_NAME4
                .COLOR1 = dao_color.fields.COLOR1
                .COLOR2 = dao_color.fields.COLOR2
                .COLOR3 = dao_color.fields.COLOR3
                .COLOR4 = dao_color.fields.COLOR4
            End With
            dao_color_rqt.insert()
        Next

        Dim dao_dtb As New DAO_DRUG.TB_DRRGT_DTB
        dao_dtb.GetDataby_FKIDA(fk_transfer)
        For Each dao_dtl.fields In dao_dtl.datas
            Dim dao_dtb_rqt As New DAO_DRUG.TB_DRRGT_DTB
            With dao_dtb_rqt.fields
                .FK_IDA = IDA_rgt
                .FK_LCN_IDA = dao_dtb.fields.FK_LCN_IDA
            End With
            dao_dtb_rqt.insert()
        Next

        Dim dao_ani_rq As New DAO_DRUG.ClsDBdramldrg
        dao_ani_rq.GetData_by_FK_IDA(fk_transfer)
        For Each dao_ani_rq.fields In dao_ani_rq.datas
            Dim dao_ani_rg As New DAO_DRUG.ClsDBdramldrg
            With dao_ani_rg.fields
                .amlsubcd = dao_ani_rq.fields.amlsubcd
                .amltpcd = dao_ani_rq.fields.amltpcd
                .drgtpcd = dao_ani_rq.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .pvncd = dao_ani_rq.fields.pvncd
                .rgtno = dao_ani_rq.fields.rgtno
                .rgttpcd = dao_ani_rq.fields.rgttpcd
                .usetpcd = dao_ani_rq.fields.usetpcd
            End With
            dao_ani_rg.insert()
        Next

        Dim dao_aniuse_rq As New DAO_DRUG.ClsDBdramluse
        dao_aniuse_rq.GetDataby_FK_IDA(fk_transfer)
        For Each dao_aniuse_rq.fields In dao_aniuse_rq.datas
            Dim dao_aniuse_rg As New DAO_DRUG.ClsDBdramluse
            With dao_aniuse_rg.fields
                .amlsubcd = dao_aniuse_rg.fields.amlsubcd
                .amltpcd = dao_aniuse_rg.fields.amltpcd
                .drgtpcd = dao_aniuse_rg.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .pvncd = dao_aniuse_rg.fields.pvncd
                .rgtno = dao_aniuse_rg.fields.rgtno
                .rgttpcd = dao_aniuse_rg.fields.rgttpcd
                .usetpcd = dao_aniuse_rg.fields.usetpcd
                .nouse = dao_aniuse_rg.fields.nouse
                .packuse = dao_aniuse_rg.fields.packuse
                .pvncd = dao_aniuse_rg.fields.pvncd
                .STOP_UNIT1 = dao_aniuse_rg.fields.STOP_UNIT1
                .STOP_UNIT2 = dao_aniuse_rg.fields.STOP_UNIT2
                .STOP_VALUE1 = dao_aniuse_rg.fields.STOP_VALUE1
                .STOP_VALUE2 = dao_aniuse_rg.fields.STOP_VALUE2
                .stpdrg = dao_aniuse_rg.fields.stpdrg
                .stpdrgcd = dao_aniuse_rg.fields.stpdrgcd
                .usetpcd = dao_aniuse_rg.fields.usetpcd
            End With
            dao_aniuse_rg.insert()
        Next

    End Sub
    Sub insert_tabean2(ByVal FK_IDA As Integer, ByVal fk_transfer As Integer)
        Dim dao_copy As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB

        Dim newcode As String = ""
        Try
            dao_copy.GetDataby_IDA_drrgt(fk_transfer)
            newcode = dao_copy.fields.Newcode_U
        Catch ex As Exception

        End Try
        Dim IDA_rgt As Integer = FK_IDA 'dao_drrgt.fields.IDA
        If newcode <> "" Then
            Try
                Dim dao_atc As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_RECIPE_GROUP
                dao_atc.GetDataby_Newcode(newcode)
                For Each dao_atc.fields In dao_atc.datas
                    Dim dao_rgt_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                    With dao_rgt_atc.fields
                        .ATC_CODE = dao_atc.fields.atccd
                        Try
                            Dim dao_atcm As New DAO_DRUG.TB_ATC_DRUG
                            dao_atcm.GetDataby_ATCCD(dao_atc.fields.atccd)
                            .ATC_IDA = dao_atcm.fields.IDA
                        Catch ex As Exception

                        End Try
                        .FK_IDA = IDA_rgt
                    End With
                    dao_rgt_atc.insert()
                Next
            Catch ex As Exception

            End Try

            Try
                Dim dao_cas As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_IOW
                dao_cas.GetDataby_Newcode_U(newcode)
                For Each dao_cas.fields In dao_cas.datas
                    Dim dao_rgt_cas As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
                    With dao_rgt_cas.fields
                        .AORI = dao_cas.fields.aori
                        .BASE_FORM = dao_cas.fields.qtytxt_all
                        '.FK_IDA = 0
                        .FK_SET = dao_cas.fields.flineno
                        .IOWA = dao_cas.fields.iowacd
                        .QTY = dao_cas.fields.qty
                        .ROWS = dao_cas.fields.rid
                        .FK_IDA = IDA_rgt
                        Try
                            .REMARK = dao_cas.fields.remark
                        Catch ex As Exception

                        End Try
                        Try
                            Dim dao_u As New DAO_DRUG.TB_drsunit
                            dao_u.GetDataby_sunitengnm(dao_cas.fields.sunitengnm)
                            .SUNITCD = dao_u.fields.sunitcd
                        Catch ex As Exception

                        End Try

                    End With
                    dao_rgt_cas.insert()

                    Dim dao_eq As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_IOW_EQ
                    dao_eq.GetDataby_Newcode_rid_flineno(dao_cas.fields.Newcode_rid, dao_cas.fields.flineno)
                    For Each dao_eq.fields In dao_eq.datas
                        Dim dao_eq_rgt As New DAO_DRUG.TB_DRRQT_EQTO
                        With dao_eq_rgt.fields
                            .FK_IDA = dao_rgt_cas.fields.IDA
                            .IOWA = dao_eq.fields.iowacd
                            .QTY = dao_eq.fields.qty
                            .ROWS = dao_eq.fields.rid
                            .REMARK = dao_eq.fields.remark
                            .FK_SET = dao_eq.fields.flineno
                            .FK_DRRQT_IDA = IDA_rgt
                        End With
                        dao_eq_rgt.insert()
                    Next
                Next
            Catch ex As Exception

            End Try


            Try
                Dim dao_XML_DRUG_FRGN As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_FRGN
                dao_XML_DRUG_FRGN.GetDataby_u1(newcode)
                If dao_XML_DRUG_FRGN.fields.engcntnm = "ไทย" Then
                    For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
                        Dim dao_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
                        With dao_in.fields
                            .FK_IDA = IDA_rgt
                            Try
                                Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                                'dao_dal.GetDataby_pvncd_lcnno_lcntpcd(dao_XML_DRUG_FRGN.fields.pvncd, dao_XML_DRUG_FRGN.fields.lcnno, dao_XML_DRUG_FRGN.fields.lcntpcd)
                                dao_dal.GetDataby_citi_lcnno(dao_XML_DRUG_FRGN.fields.CITIZEN_AUTHORIZE, dao_XML_DRUG_FRGN.fields.lcnno)
                                .FK_LCN_IDA = dao_dal.fields.IDA
                            Catch ex As Exception

                            End Try
                            .funccd = dao_XML_DRUG_FRGN.fields.funccd
                            dao_in.insert()
                        End With
                    Next
                Else
                    For Each dao_XML_DRUG_FRGN.fields In dao_XML_DRUG_FRGN.datas
                        Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
                        With dao_pro.fields
                            .FK_IDA = IDA_rgt
                            .PRODUCER_WORK_TYPE = dao_XML_DRUG_FRGN.fields.funccd
                            .funccd = dao_XML_DRUG_FRGN.fields.funccd
                            Dim frgncd As Integer = 0
                            Dim FK_PRODUCER As Integer = 0
                            Dim addr_ida As Integer = 0
                            Dim frgnlctcd As Integer = 0
                            Dim dao_frgn_name As New DAO_DRUG.ClsDBsyspdcfrgn
                            dao_frgn_name.GetData_by_engfrgnnm(dao_XML_DRUG_FRGN.fields.engfrgnnm)
                            For Each dao_frgn_name.fields In dao_frgn_name.datas
                                Dim icc As Integer = 0
                                Dim bao_iso As New BAO.ClsDBSqlcommand
                                Dim dt_iso As New DataTable
                                dt_iso = bao_iso.SP_sysisocnt_SAI_by_engcntnm(dao_XML_DRUG_FRGN.fields.engcntnm) '
                                Dim alpha3 As String = ""
                                Try
                                    alpha3 = dt_iso(0)("alpha3")
                                Catch ex As Exception

                                End Try
                                Dim dao_frgn_addr As New DAO_DRUG.ClsDBdrfrgnaddr
                                'dao_frgn_addr.GetDataAll_v2(dao_XML_DRUG_FRGN.fields.addr, alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.fax, dao_XML_DRUG_FRGN.fields.mu, _
                                'dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.road, dao_XML_DRUG_FRGN.fields.soi, dao_XML_DRUG_FRGN.fields.subdiv, dao_XML_DRUG_FRGN.fields.tel, _
                                'dao_XML_DRUG_FRGN.fields.zipcode, dao_frgn_name.fields.frgncd)
                                dao_frgn_addr.GetDataAll_v3(dao_XML_DRUG_FRGN.fields.addr, alpha3, dao_XML_DRUG_FRGN.fields.district, dao_XML_DRUG_FRGN.fields.Province, dao_XML_DRUG_FRGN.fields.subdiv, dao_frgn_name.fields.frgncd)

                                For Each dao_frgn_addr.fields In dao_frgn_addr.datas
                                    addr_ida = dao_frgn_addr.fields.IDA
                                    frgnlctcd = dao_frgn_addr.fields.frgnlctcd
                                    frgncd = dao_frgn_addr.fields.frgnlctcd

                                Next
                                FK_PRODUCER = dao_frgn_name.fields.IDA
                            Next

                            .frgncd = dao_frgn_name.fields.frgncd
                            .addr_ida = addr_ida
                            .FK_PRODUCER = FK_PRODUCER
                            .frgnlctcd = frgnlctcd
                        End With
                        ' dao_pro.insert()
                    Next


                End If

            Catch ex As Exception

            End Try



            'Dim dao_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            'dao_pack.GetDataby_FKIDA(fk_transfer)
            'For Each dao_pack.fields In dao_pack.datas
            '    Dim dao_rgt_pack As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
            '    With dao_rgt_pack.fields
            '        .BARCODE = dao_pack.fields.BARCODE
            '        .BIG_UNIT = dao_pack.fields.BIG_UNIT
            '        .CHECK_PACKAGE = dao_pack.fields.CHECK_PACKAGE
            '        .FK_IDA = IDA_rgt
            '        .MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
            '        .MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
            '        .SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
            '        .SMALL_UNIT = dao_pack.fields.SMALL_UNIT
            '    End With
            '    dao_rgt_pack.insert()
            'Next


            'Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
            'dao_pro.GetDataby_FK_IDA(fk_transfer)
            'For Each dao_pro.fields In dao_pro.datas
            '    Dim dao_rgt_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
            '    With dao_rgt_pro.fields
            '        .addr_ida = dao_pro.fields.addr_ida
            '        .drgtpcd = dao_pro.fields.drgtpcd
            '        .FK_IDA = IDA_rgt
            '        .FK_PRODUCER = dao_pro.fields.FK_PRODUCER
            '        .frgncd = dao_pro.fields.frgncd
            '        .frgnlctcd = dao_pro.fields.frgnlctcd
            '        .funccd = dao_pro.fields.funccd
            '        .lcnno = dao_pro.fields.lcnno
            '        .lcntpcd = dao_pro.fields.lcntpcd
            '        .PRODUCER_WORK_TYPE = dao_pro.fields.PRODUCER_WORK_TYPE
            '        .pvncd = dao_pro.fields.pvncd
            '        .rcvno = dao_pro.fields.rcvno
            '        .REFERENCE_GMP = dao_pro.fields.REFERENCE_GMP
            '        .rgtno = dao_pro.fields.rgtno
            '        .rgttpcd = dao_pro.fields.rgttpcd
            '        .TR_ID = dao_pro.fields.TR_ID
            '    End With
            '    dao_rgt_pro.insert()
            'Next


            'Dim dao_pro_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
            'dao_pro_in.GetDataby_FK_IDA(fk_transfer)
            'For Each dao_pro_in.fields In dao_pro_in.datas
            '    Dim dao_rgt_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
            '    With dao_rgt_pro_in.fields
            '        .drgtpcd = dao_pro_in.fields.drgtpcd
            '        .FK_IDA = IDA_rgt
            '        .funccd = dao_pro_in.fields.funccd
            '        .lcnno = dao_pro_in.fields.lcnno
            '        .lcntpcd = dao_pro_in.fields.lcntpcd
            '        .rgtno = dao_pro_in.fields.rgtno
            '        .rgttpcd = dao_pro_in.fields.rgttpcd
            '        .FK_LCN_IDA = dao_pro_in.fields.FK_LCN_IDA
            '        .rgtno = dao_pro_in.fields.rgtno
            '        .rgttpcd = dao_pro_in.fields.rgttpcd
            '        .lctcd = dao_pro_in.fields.lctcd
            '        .lcnsid = dao_pro_in.fields.lcnsid
            '    End With
            '    dao_rgt_pro_in.insert()
            'Next


            'Dim dao_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
            'dao_prop.GetDataby_FK_IDA(fk_transfer)
            'For Each dao_prop.fields In dao_prop.datas
            '    Dim dao_rgt_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES
            '    With dao_rgt_prop.fields
            '        .CHK_DRUG_PROPERTIES = dao_prop.fields.CHK_DRUG_PROPERTIES
            '        .CHK_DRUG_PROPERTIES_OTHER = dao_prop.fields.CHK_DRUG_PROPERTIES_OTHER
            '        .DRUG_PROPERTIES = dao_prop.fields.DRUG_PROPERTIES
            '        .DRUG_PROPERTIES_OTHER = dao_prop.fields.DRUG_PROPERTIES_OTHER
            '        .FK_IDA = IDA_rgt
            '    End With
            '    dao_rgt_prop.insert()
            'Next

            Try
                Dim dao_prop_det As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR
                dao_prop_det.GetDataby_Newcode(newcode)
                For Each dao_prop_det.fields In dao_prop_det.datas
                    Dim dao_rgt_pd As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
                    With dao_rgt_pd.fields
                        .DRUG_PROPERTIES_AND_DETAIL = dao_prop_det.fields.drgchrtha
                        .FK_IDA = IDA_rgt
                        .OTHER = dao_prop_det.fields.drgchreng
                        .ROWS = dao_prop_det.fields.rid
                    End With
                    dao_rgt_pd.insert()
                Next
            Catch ex As Exception

            End Try

            Try
                Dim bao_each As New BAO.ClsDBSqlcommand
                Dim dt_each As New DataTable
                dt_each = bao_each.SP_GET_EACH_FROM_SAI(newcode)

                For Each dr As DataRow In dt_each.Rows
                    Dim dao_each_rgt As New DAO_DRUG.TB_DRRQT_EACH
                    With dao_each_rgt.fields
                        '.EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
                        .FK_IDA = IDA_rgt
                        '.sunitcd = dao_each.fields.sunitcd
                        .EACH_TXT = dr("drgperunit")
                        .FK_SET = dr("flineno")
                    End With
                    dao_each_rgt.insert()
                Next
            Catch ex As Exception

            End Try

            ''
            Try
                Dim dao_keep As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_STOWAGR
                dao_keep.GetDataby_Newcode(newcode)
                For Each dao_keep.fields In dao_keep.datas
                    Dim dao_keep_rgt As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
                    With dao_keep_rgt.fields
                        '.AGE_DAY = dao_keep.fields.AGE_DAY
                        .FK_IDA = IDA_rgt
                        '.AGE_HOUR = dao_keep.fields.AGE_HOUR
                        .AGE_MONTH = dao_keep.fields.useage
                        .DRUG_DETAIL = dao_keep.fields.drgchrtha
                        .KEEP_DESCRIPTION = dao_keep.fields.keepdesc
                        .TEMPERATE1 = dao_keep.fields.tplow
                        .TEMPERATE2 = dao_keep.fields.tphigh
                    End With
                    dao_keep_rgt.insert()
                Next
            Catch ex As Exception

            End Try

            Try

            Catch ex As Exception

            End Try
            ''DRRGT_DTL_TEXT
            Dim dao_dtl As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
            dao_dtl.GetDataby_u1_frn_no(newcode)
            For Each dao_dtl.fields In dao_dtl.datas
                Dim dao_dtl_rqt As New DAO_DRUG.TB_DRRQT_DTL_TEXT
                With dao_dtl_rqt.fields
                    .drgtpcd = dao_dtl.fields.drgtpcd
                    .FK_IDA = IDA_rgt
                    .dtl = dao_dtl.fields.indication
                    .engdrgtpnm = dao_dtl.fields.engdrgtpnm
                    '.keepdesc = dao_dtl.fields.keepdesc
                    Try
                        Dim dao_contain As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_CONTAIN
                        dao_contain.GetDataby_Newcode(newcode)
                        .pcksize = dao_contain.fields.SUBTITLE_SIZE_DRUG
                    Catch ex As Exception

                    End Try

                    .pvncd = dao_dtl.fields.pvncd
                    .rgtno = dao_dtl.fields.rgtno
                    .rgttpcd = dao_dtl.fields.rgttpcd
                    '.tphigh = dao_dtl.fields.tphigh
                    '.tplow = dao_dtl.fields.tplow
                    .U1_CODE = dao_dtl.fields.Newcode
                    '.useage = dao_dtl.fields.useage
                End With
                dao_dtl_rqt.insert()
            Next
        End If



        'Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
        'dao_color.GetDataby_FK_IDA(fk_transfer)
        'For Each dao_color.fields In dao_color.datas
        '    Dim dao_color_rqt As New DAO_DRUG.TB_DRRQT_COLOR
        '    With dao_color_rqt.fields
        '        .COLOR_NAME1 = dao_color.fields.COLOR_NAME1
        '        .FK_IDA = IDA_rgt
        '        .COLOR_NAME2 = dao_color.fields.COLOR_NAME2
        '        .COLOR_NAME3 = dao_color.fields.COLOR_NAME3
        '        .COLOR_NAME4 = dao_color.fields.COLOR_NAME4
        '        .COLOR1 = dao_color.fields.COLOR1
        '        .COLOR2 = dao_color.fields.COLOR2
        '        .COLOR3 = dao_color.fields.COLOR3
        '        .COLOR4 = dao_color.fields.COLOR4
        '    End With
        '    dao_color_rqt.insert()
        'Next

        'Dim dao_dtb As New DAO_DRUG.TB_DRRGT_DTB
        'dao_dtb.GetDataby_FKIDA(fk_transfer)
        'For Each dao_dtl.fields In dao_dtl.datas
        '    Dim dao_dtb_rqt As New DAO_DRUG.TB_DRRGT_DTB
        '    With dao_dtb_rqt.fields
        '        .FK_IDA = IDA_rgt
        '        .FK_LCN_IDA = dao_dtb.fields.FK_LCN_IDA
        '    End With
        '    dao_dtb_rqt.insert()
        'Next
        Dim dao_ani_rq As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_ANIMAL
        dao_ani_rq.GetDataby_Newcode(newcode)
        For Each dao_ani_rq.fields In dao_ani_rq.datas
            Dim dao_anih_ins As New DAO_DRUG.ClsDBdramldrg
            With dao_anih_ins.fields
                Try
                    Dim dao_amlsub As New DAO_DRUG.TB_dramlsubtp
                    dao_amlsub.GetDataby_amlsubnm(dao_ani_rq.fields.amlsubnm)
                    .amlsubcd = dao_amlsub.fields.amlsubcd
                Catch ex As Exception

                End Try

                Try
                    Dim dao_amlt As New DAO_DRUG.TB_dramltype
                    dao_amlt.GetDataby_amltpnm(dao_ani_rq.fields.amltpnm)
                    .amltpcd = dao_amlt.fields.amltpcd
                Catch ex As Exception

                End Try
                Try
                    .drgtpcd = dao_copy.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    .pvncd = dao_copy.fields.pvncd
                Catch ex As Exception

                End Try
                Try
                    .rgtno = dao_copy.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    .rgttpcd = dao_copy.fields.rgttpcd
                Catch ex As Exception

                End Try
                Try
                    Dim dao_uset As New DAO_DRUG.TB_dramlusetp
                    dao_uset.GetDataby_usetpnm(dao_ani_rq.fields.usetpnm)
                    .usetpcd = dao_uset.fields.usetpcd
                Catch ex As Exception

                End Try
                .FK_IDA = IDA_rgt
            End With
            dao_anih_ins.insert()
            Dim IDA_anih As Integer = dao_anih_ins.fields.IDA


        Next

        Dim dao_aniuse_rq As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_ANIMAL_CONSUME
        dao_aniuse_rq.GetDataby_Newcode(newcode)
        For Each dao_aniuse_rq.fields In dao_aniuse_rq.datas
            Dim dao_ani_ins As New DAO_DRUG.ClsDBdramluse
            With dao_ani_ins.fields
                Try
                    Dim dao_amlsub As New DAO_DRUG.TB_dramlsubtp
                    dao_amlsub.GetDataby_amlsubnm(dao_aniuse_rq.fields.amlsubnm)
                    .amlsubcd = dao_amlsub.fields.amlsubcd
                Catch ex As Exception

                End Try
                Try
                    Dim dao_amlt As New DAO_DRUG.TB_dramltype
                    dao_amlt.GetDataby_amltpnm(dao_aniuse_rq.fields.amltpnm)
                    .amltpcd = ""
                Catch ex As Exception

                End Try
                Try
                    Dim dao_amlpt As New DAO_DRUG.TB_dramlpart
                    dao_amlpt.GetDataby_ampartnm(dao_aniuse_rq.fields.ampartnm)
                    .ampartcd = dao_amlpt.fields.ampartcd
                Catch ex As Exception

                End Try
                Try
                    .drgtpcd = dao_copy.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    .FK_IDA = IDA_rgt
                Catch ex As Exception

                End Try
                Try
                    .nouse = dao_aniuse_rq.fields.nouse
                Catch ex As Exception

                End Try
                Try
                    .packuse = dao_aniuse_rq.fields.packuse
                Catch ex As Exception

                End Try
                Try
                    .pvncd = dao_aniuse_rq.fields.pvncd
                Catch ex As Exception

                End Try
                Try
                    .rgtno = dao_aniuse_rq.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    .rgttpcd = dao_aniuse_rq.fields.rgttpcd
                Catch ex As Exception

                End Try
                Try
                    .stpdrg = dao_aniuse_rq.fields.stpdrg
                Catch ex As Exception

                End Try
                Try
                    Dim dao_amluse As New DAO_DRUG.TB_dramlusetp
                    dao_amluse.GetDataby_usetpnm(dao_aniuse_rq.fields.usetpnm)
                    .usetpcd = dao_amluse.fields.usetpcd
                Catch ex As Exception

                End Try
            End With
            dao_ani_ins.insert()
        Next
    End Sub
End Class