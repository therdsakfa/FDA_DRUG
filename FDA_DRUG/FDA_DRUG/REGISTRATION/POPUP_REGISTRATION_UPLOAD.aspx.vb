Imports System.Xml.Serialization
Imports System.IO

Public Class POPUP_REGISTRATION_UPLOAD
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA As Integer
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _R_ProcessID As String = ""
    Sub runQuery()
        _ProcessID = Request.QueryString("process")
        _R_ProcessID = Request.QueryString("r_process")
        '_IDA = Request.QueryString("IDA")
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
            '_ProcessID = Request.QueryString("type")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        runQuery()
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
        If Not IsPostBack Then
            If Request.QueryString("staff") <> "" Then
                If Request.QueryString("staff") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("staff"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        'If FileUpload1.HasFile Then
        '    Dim bao As New BAO.AppSettings
        '    bao.RunAppSettings()

        '    Dim cls_tr As New BAO_TRANSECTION
        '    Dim tr_id As Integer = 0

        '    cls_tr.CITIZEN_ID = _CLS.CITIZEN_ID
        '    cls_tr.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        '    tr_id = cls_tr.insert_transection(11)

        '    FileUpload1.SaveAs(bao._PATH_PDF_TRADER & "DA-11-" & con_year(Date.Now.Year) & "-" & tr_id & ".pdf") '"C:\path\PDF_TRADER\"
        '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "DA-11-" & con_year(Date.Now.Year) & "-" & tr_id & ".pdf", tr_id) '"C:\path\PDF_TRADER\"
        '    insrt_to_database(bao._PATH_XML_TRADER & "DA-11-" & con_year(Date.Now.Year) & "-" & tr_id & ".xml", tr_id) '"C:\path\XML_TRADER\"

        '    alert("รหัสการดำเนินการ คือ DA-11-" & con_year(Date.Now.Year) & "-" & tr_id)
        'End If

        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION
            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)

            FileUpload1.SaveAs(PDF_TRADER) 'ทำการ Save File ลงไป
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER) 'ทำการ แยกไฟล์ XML ออกจาก PDF แล้วทำการ Save ลงตามจุดที่กำหนด
            If insrt_to_database(XML_TRADER, TR_ID) Then 'ทำการส่ง XML เข้าไปเพื่อทำการ Insert เข้า DATABASE และ ส่ง TR_ID เข้าไปเพื่อเชื่อมโยง
                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            Else
                alert("เกิดข้อผิดพลาด")
            End If





            'Dim PDF_TRADER As String = bao._PATH_PDF_TRADER & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            ''PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            'FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"

            ''PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            'Dim XML_TRADER As String = bao._PATH_XML_TRADER & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
            ''ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            'convert_PDF_To_XML(PDF_TRADER, XML_TRADER)

            'Dim check As Boolean = True
            'Try
            '    check = insrt_to_database(XML_TRADER, TR_ID)
            '    If check = True Then
            '        alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            '    Else

            '    End If
            'Catch ex As Exception

            '    alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            'End Try


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
            Dim p2 As New CLASS_REGISTRATION
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION

            ' Dim bao As New BAO.GenNumber

            Try
                dao.fields = p2.DRUG_REGISTRATIONs
            Catch ex As Exception

            End Try

            'dao.fields.cnsdcd = 1
            'dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            Try
                dao.fields.RCVDATE = Date.Now
            Catch ex As Exception

            End Try

            Try
                dao.fields.PROCESS_ID = _ProcessID
            Catch ex As Exception

            End Try
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            dao_dal.GetDataby_IDA(_lcn_ida)

            dao.fields.TR_ID = TR_ID
            dao.fields.STATUS_ID = 1
            Try
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE 'dao_dal.fields.CITIZEN_ID_AUTHORIZE
            Catch ex As Exception

            End Try
            Try
                dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
            Catch ex As Exception

            End Try
            Try
                dao.fields.LCNTPCD = dao_dal.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.LCNNO = dao_dal.fields.lcnno
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = _lcn_ida
            Try
                dao.fields.DRUG_EQ_TO = Request.QueryString("val")
            Catch ex As Exception

            End Try
            Try
                dao.fields.kindcd = p2.DRUG_REGISTRATIONs.kindcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.ctgcd = p2.DRUG_REGISTRATIONs.ctgcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.FK_DOSAGE_FORM = p2.DRUG_REGISTRATIONs.FK_DOSAGE_FORM
            Catch ex As Exception

            End Try
           

            Try
                dao.fields.PVNCD = _CLS.PVCODE
            Catch ex As Exception

            End Try
            If Request.QueryString("tt") <> "" Then

                If Request.QueryString("val") <> "" Then

                    Dim dao_15_g As New DAO_DRUG.TB_15_TAMRAP_GENERAL

                    Try
                        dao_15_g.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.GROUP_TYPE = dao_15_g.fields.classcd
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.FK_DOSAGE_FORM = dao_15_g.fields.dsgcd
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.UNIT_NORMAL = 775
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.kindcd = dao_15_g.fields.kindcd
                    Catch ex As Exception

                    End Try

                    Dim dao_15_pcksize As New DAO_DRUG.TB_15_TAMRAP_PACKSIZE
                    dao_15_pcksize.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                    dao.fields.PACKAGE_DETAIL = dao_15_pcksize.fields.pcksize
                End If
            End If

            dao.insert()
            Dim ida_main As Integer = dao.fields.IDA

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = dao.fields.IDA
            dao_up.update()
            If Request.QueryString("tt") <> "" Then
                If Request.QueryString("val") <> "" Then

                    Dim dao_15_t As New DAO_DRUG.TB_15_TAMRAP_TEMPLATE
                    Try
                        dao_15_t.GetDataby_TAMRAP_ID(Request.QueryString("val"))

                    Catch ex As Exception

                    End Try
                    For Each dao_15_t.fields In dao_15_t.datas
                        Dim dao_cas As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                        With dao_cas.fields
                            .AORI = dao_15_t.fields.AORI
                            Try
                                .BASE_FORM = dao_15_t.fields.BASE_FORM
                            Catch ex As Exception

                            End Try
                            .FK_IDA = ida_main
                            .IOWA = dao_15_t.fields.IOWA
                            .IOWACD = dao_15_t.fields.IOWA
                            Try
                                .QTY = dao_15_t.fields.QTY
                            Catch ex As Exception

                            End Try
                            .ROWS = dao_15_t.fields.ROWS
                            .SUNITCD = dao_15_t.fields.SUNITCD
                            .FK_SET = dao_15_t.fields.FK_SET
                        End With
                        dao_cas.insert()

                        Dim dao_eq As New DAO_DRUG.TB_15_TAMRAP_EQTO
                        dao_eq.GetDataby_FK_IDA(dao_15_t.fields.IDA, 1)
                        For Each dao_eq.fields In dao_eq.datas
                            Dim dao_eq_rgt As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                            With dao_eq_rgt.fields
                                .FK_IDA = dao_cas.fields.IDA
                                .IOWA = dao_eq.fields.IOWA
                                .MULTIPLY = dao_eq.fields.MULTIPLY
                                .QTY = dao_eq.fields.QTY
                                .ROWS = dao_eq.fields.ROWS
                                .STR_VALUE = dao_eq.fields.STR_VALUE
                                .SUNITCD = dao_eq.fields.SUNITCD
                                .FK_SET = dao_eq.fields.FK_SET
                                .FK_REGIST = ida_main
                                .mltplr = dao_eq.fields.mltplr
                                .CONDITION = dao_eq.fields.CONDITION
                            End With
                            dao_eq_rgt.insert()
                        Next
                    Next


                    Dim dao_15_e As New DAO_DRUG.TB_15_TAMRAP_EACH
                    dao_15_e.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                    For Each dao_15_e.fields In dao_15_e.datas
                        Dim dao_ea As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
                        With dao_ea.fields
                            .EACH_AMOUNT = dao_15_e.fields.EACH_AMOUNT
                            .FK_IDA = ida_main
                            .sunitcd = dao_15_e.fields.sunitcd
                            .FK_SET = 1
                        End With
                        dao_ea.insert()
                    Next

                    Dim dao_15_dtl As New DAO_DRUG.TB_15_TAMRAP_DTL
                    dao_15_dtl.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                    For Each dao_15_dtl.fields In dao_15_dtl.datas
                        Dim dao_dtl As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
                        With dao_dtl.fields
                            .DRUG_USE = dao_15_dtl.fields.dtl
                            .FK_IDA = ida_main
                        End With
                        dao_dtl.insert()
                    Next

                    Dim dao_15_atc As New DAO_DRUG.TB_15_TAMRAP_ATC
                    dao_15_atc.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                    For Each dao_15_atc.fields In dao_15_atc.datas
                        Dim dao_atc As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
                        With dao_atc.fields
                            .ATC_CODE = dao_15_atc.fields.atccd
                            .ATC_IDA = dao_15_atc.fields.atcd_IDA
                            .FK_IDA = ida_main
                        End With
                        dao_atc.insert()
                    Next

                    Try
                        If dao_dal.fields.lcntpcd.Contains("ผย") Then
                            Dim dtt As New DataTable
                            Dim bao_pro As New BAO.ClsDBSqlcommand
                            dtt = bao_pro.SP_GET_REGIST_PRODUCCER_IN(dao_dal.fields.IDA, ida_main)

                            For Each drr As DataRow In dtt.Rows
                                Dim dao_proo As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                                With dao_proo.fields
                                    .addr_ida = drr("addr_ida")
                                    .FK_PRODUCER = drr("IDA")
                                    .PRODUCER_WORK_TYPE = drr("funccd")
                                    .FK_IDA = ida_main
                                End With
                                dao_proo.insert()
                            Next
                        End If
                    Catch ex As Exception

                    End Try


                End If
            End If

            '----ลบ
            'Dim dao_pack As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            'For Each dao_pack.fields In p2.DRUG_REGISTRATION_PACKAGE_DETAILs
            '    Dim dao_pack2 As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            '    dao_pack2.fields.FK_IDA = ida_main
            '    Try
            '        dao_pack2.fields.SMALL_UNIT = Trim(dao_pack.fields.SMALL_UNIT)
            '    Catch ex As Exception
            '        dao_pack2.fields.SMALL_UNIT = 0
            '    End Try
            '    Try
            '        dao_pack2.fields.MEDIUM_UNIT = Trim(dao_pack.fields.MEDIUM_UNIT)
            '    Catch ex As Exception
            '        dao_pack2.fields.MEDIUM_UNIT = 0
            '    End Try
            '    Try
            '        dao_pack2.fields.BARCODE = Trim(dao_pack.fields.BARCODE)
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_pack2.fields.MEDIUM_AMOUNT = Trim(dao_pack.fields.MEDIUM_AMOUNT)
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_pack2.fields.SMALL_AMOUNT = Trim(dao_pack.fields.SMALL_AMOUNT)
            '    Catch ex As Exception

            '    End Try

            '    dao_pack2.insert()
            '    'dao_pack = New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
            'Next
            '---------------------ลบ
            'Dim dao_ATC As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
            'For Each dao_ATC.fields In p2.DRUG_REGISTRATION_ATC_DETAILs
            '    Dim dao_ATC2 As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
            '    dao_ATC2.fields.FK_IDA = ida_main
            '    Try
            '        dao_ATC2.fields.ATC_CODE = Trim(dao_ATC.fields.ATC_CODE)
            '    Catch ex As Exception

            '    End Try

            '    dao_ATC2.insert()
            '    'dao_ATC = New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
            'Next
            '
            Try
                Dim dao_PROP As New DAO_DRUG.TB_DRUG_REGISTRATION_PROPERTIES
                For Each dao_PROP.fields In p2.DRUG_REGISTRATION_PROPERTy
                    Dim dao_PROP2 As New DAO_DRUG.TB_DRUG_REGISTRATION_PROPERTIES
                    dao_PROP2.fields.FK_IDA = ida_main
                    Try
                        dao_PROP2.fields.DRUG_PROPERTIES = Trim(dao_PROP.fields.DRUG_PROPERTIES)
                    Catch ex As Exception

                    End Try
                    Try
                        dao_PROP2.fields.DRUG_PROPERTIES_OTHER = Trim(dao_PROP.fields.CHK_DRUG_PROPERTIES_OTHER)
                    Catch ex As Exception

                    End Try

                    dao_PROP2.insert()
                    'dao_PROP2 = New DAO_DRUG.TB_DRUG_REGISTRATION_PROPERTIES
                Next
            Catch ex As Exception

            End Try


            '--------ลบสาร
            'Dim dao_CAS As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
            'For Each dao_CAS.fields In p2.DRUG_REGISTRATION_DETAIL_CA
            '    Dim IOWA As Integer = 0
            '    Try
            '        IOWA = Trim(dao_CAS.fields.IOWA)
            '    Catch ex As Exception

            '    End Try
            '    Dim dao_CAS2 As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
            '    dao_CAS2.fields.FK_IDA = ida_main
            '    Try
            '        dao_CAS2.fields.IOWA = IOWA
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_CAS2.fields.BASE_FORM = dao_CAS.fields.BASE_FORM
            '    Catch ex As Exception

            '    End Try

            '    Try
            '        dao_CAS2.fields.EQTO_IOWA = Trim(dao_CAS.fields.EQTO_IOWA)
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_CAS2.fields.EQTO_QTY = Trim(dao_CAS.fields.EQTO_QTY)
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_CAS2.fields.EQTO_SUNITCD = Trim(dao_CAS.fields.EQTO_SUNITCD)
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_CAS2.fields.QTY = Trim(dao_CAS.fields.QTY)
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_CAS2.fields.SUNITCD = Trim(dao_CAS.fields.SUNITCD)
            '    Catch ex As Exception

            '    End Try

            '    dao_CAS2.insert()
            '    'dao_PROP2 = New DAO_DRUG.TB_DRUG_REGISTRATION_PROPERTIES
            'Next
            '--------ลบ
            'ลบบบบบบบบบบบบบบบบ
            'Dim dao_pro As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
            'For Each dao_pro.fields In p2.DRUG_REGISTRATION_PRODUCER
            '    Dim dao_pro2 As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER
            '    Try
            '        dao_pro2.fields.addr_ida = dao_pro.fields.addr_ida
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_pro2.fields.amphrcd = dao_pro.fields.amphrcd
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_pro2.fields.chngwtcd = dao_pro.fields.chngwtcd
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_pro2.fields.cntcd = dao_pro.fields.cntcd
            '    Catch ex As Exception

            '    End Try
            '    dao_pro2.fields.district = dao_pro.fields.district
            '    dao_pro2.fields.fax = dao_pro.fields.fax
            '    dao_pro2.fields.FK_IDA = ida_main
            '    Try
            '        dao_pro2.fields.FK_PRODUCER = dao_pro.fields.FK_PRODUCER
            '    Catch ex As Exception

            '    End Try

            '    dao_pro2.fields.NAMEPLACE = dao_pro.fields.NAMEPLACE
            '    dao_pro2.fields.NATIONAL_CODE = dao_pro.fields.NATIONAL_CODE
            '    Try
            '        dao_pro2.fields.NATIONAL_IDA = dao_pro.fields.NATIONAL_IDA
            '    Catch ex As Exception
            '        dao_pro2.fields.NATIONAL_IDA = 0
            '    End Try
            '    Try
            '        dao_pro2.fields.PRODUCER_WORK_TYPE = dao_pro.fields.PRODUCER_WORK_TYPE
            '    Catch ex As Exception

            '    End Try

            '    dao_pro2.fields.province = dao_pro.fields.province
            '    dao_pro2.fields.REFERENCE_GMP = dao_pro.fields.REFERENCE_GMP
            '    dao_pro2.fields.subdiv = dao_pro.fields.subdiv
            '    dao_pro2.fields.tel = dao_pro.fields.tel
            '    dao_pro2.fields.thaaddr = dao_pro.fields.thaaddr
            '    dao_pro2.fields.thaamphrnm = dao_pro.fields.thachngwtnm
            '    dao_pro2.fields.thamu = dao_pro.fields.thamu
            '    dao_pro2.fields.thanameplace = dao_pro.fields.thanameplace
            '    dao_pro2.fields.tharoad = dao_pro.fields.tharoad
            '    dao_pro2.fields.thasoi = dao_pro.fields.thasoi
            '    dao_pro2.fields.thathmblnm = dao_pro.fields.thathmblnm
            '    Try
            '        dao_pro2.fields.thmblcd = dao_pro.fields.thmblcd
            '    Catch ex As Exception

            '    End Try

            '    Try
            '        dao_pro2.fields.TYPE_PRODUCER = dao_pro.fields.TYPE_PRODUCER
            '    Catch ex As Exception

            '    End Try

            '    dao_pro2.fields.ZIPCODE = dao_pro.fields.ZIPCODE
            '    dao_pro2.insert()
            'Next
            '----------------------------ลบ
            Try
                Dim dao_col As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
                For Each dao_col.fields In p2.DRUG_REGISTRATION_COLOR
                    Dim dao_col2 As New DAO_DRUG.TB_DRUG_REGISTRATION_COLOR
                    With dao_col2.fields
                        Try
                            .COLOR_NAME1 = dao_col.fields.COLOR_NAME1
                        Catch ex As Exception

                        End Try
                        Try
                            .COLOR_NAME2 = dao_col.fields.COLOR_NAME2
                        Catch ex As Exception

                        End Try
                        Try
                            .COLOR_NAME3 = dao_col.fields.COLOR_NAME3
                        Catch ex As Exception

                        End Try
                        Try
                            .COLOR_NAME4 = dao_col.fields.COLOR_NAME4
                        Catch ex As Exception

                        End Try

                        Try
                            .COLOR1 = CInt(Trim(dao_col.fields.COLOR1))
                        Catch ex As Exception

                        End Try
                        Try
                            .COLOR2 = CInt(Trim(dao_col.fields.COLOR2))
                        Catch ex As Exception

                        End Try
                        Try
                            .COLOR3 = CInt(Trim(dao_col.fields.COLOR3))
                        Catch ex As Exception

                        End Try
                        Try
                            .COLOR4 = CInt(Trim(dao_col.fields.COLOR4))
                        Catch ex As Exception

                        End Try
                    End With
                    dao_col2.fields.FK_IDA = ida_main
                    dao_col2.insert()
                Next
            Catch ex As Exception

            End Try

        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function


End Class