Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_DR_CONFIRM
    Inherits System.Web.UI.Page

    Private _IDA As Integer
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _YEARS As String
    Private b64 As String
    Sub RunSession()
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _process = Request.QueryString("process")
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception

        End Try
        Try
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub bind_ddl_rqt()
        'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
        'dao.GetData_TABEAN_Only()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_TYPE_REQUESTS_TABEAN()
        ddl_req_type.DataSource = dt
        ddl_req_type.DataTextField = "TYPE_REQUESTS_NAME"
        ddl_req_type.DataValueField = "TYPE_REQUESTS_ID"
        ddl_req_type.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'BindData_PDF()
            Try
                BindData_PDF()
            Catch ex As Exception
                Response.Redirect("https://privus.fda.moph.go.th/")
            End Try
            bind_ddl_rqt()
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv(_IDA)
            Try

                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)

                ddl_req_type.SelectedValue = dao.fields.TYPE_REQUEST_ID
                lbl_rqt.Style.Add("display", "none")
            Catch ex As Exception
                lbl_rqt.Style.Add("display", "block")
            End Try
            If Request.QueryString("staff") <> "" Then
                If Request.QueryString("staff") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("staff"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
            If Request.QueryString("tt") <> "" Then
                lbl_rqt.Style.Add("display", "none")
                ddl_req_type.Style.Add("display", "none")
            End If
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(IDA)
        If Request.QueryString("status") = "8" Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        Dim tamrap_id As Integer = 0
        Try
            tamrap_id = dao.fields.feepayst
        Catch ex As Exception

        End Try
        If tamrap_id = 0 Then
            If ddl_req_type.SelectedValue <> "" Then
                'Dim ws As New AUTHEN_LOG.Authentication
                'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอย.1", _process)

                Dim ws_118 As New WS_AUTHENTICATION.Authentication
                Dim ws_66 As New Authentication_66.Authentication
                Dim ws_104 As New AUTHENTICATION_104.Authentication
                Try
                    ws_118.Timeout = 10000
                    ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอย.1", _process)
                Catch ex As Exception
                    Try
                        ws_66.Timeout = 10000
                        ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอย.1", _process)

                    Catch ex2 As Exception
                        Try
                            ws_104.Timeout = 10000
                            ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นคำขอย.1", _process)

                        Catch ex3 As Exception
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                        End Try
                    End Try
                End Try




                '
                'If tamrap_id <> 0 Then
                dao.fields.STATUS_ID = 2
                'dao.fields.rgttpcd = "G"
                'dao.fields.drgtpcd = "2"
                'dao.fields.rgtdrgtpcd = "2"
                'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                'dao_up.GetDataby_IDA(dao.fields.TR_ID)
                'Dim RCVNO As Integer
                'Dim rgtno As Integer
                'Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
                'Dim bao As New BAO.GenNumber
                'RCVNO = bao.GEN_RCVNO_NO_50k(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
                'rgtno = bao.GEN_RGTNO50K(con_year(Date.Now.Year()), _CLS.PVCODE, "G", _IDA, PROCESS_ID)
                'dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)
                'dao.fields.rgtno = rgtno
                'Try
                '    dao.fields.rcvdate = CDate(Date.Now)
                'Catch ex As Exception

                'End Try
                'Try
                '    dao.fields.appdate = CDate(Date.Now)
                'Catch ex As Exception

                'End Try

                'Dim bao_insert As New BAO.ClsDBSqlcommand
                'bao_insert.insert_tabean_sub(_IDA)
                'Else
                Try
                    If Request.QueryString("r_process") = "130003" Then
                        dao.fields.STATUS_ID = 3
                        Dim type_id As String = ""
                        Try
                            type_id = type_id = ddl_req_type.SelectedValue 'dao.fields.TYPE_REQUEST_ID
                        Catch ex As Exception

                        End Try
                        'AddLogStatus(3, _process, _CLS.CITIZEN_ID, _IDA)
                        If type_id = "141" Or type_id = "142" Or type_id = "143" Or type_id = "144" Or type_id = "145" Or type_id = "146" Or type_id = "147" Or type_id = "148" _
                            Or type_id = "791" Or type_id = "790" Or type_id = "190" Or type_id = "191" Or type_id = "192" Or type_id = "193" Or type_id = "194" Or type_id = "195" _
                            Or type_id = "196" Or type_id = "197" Or type_id = "198" Or type_id = "199" Then
                            dao.fields.STATUS_ID = 3
                            AddLogStatus(3, _process, _CLS.CITIZEN_ID, _IDA)
                        End If
                    Else
                        Dim type_id As String = ""
                        Try
                            type_id = ddl_req_type.SelectedValue 'dao.fields.TYPE_REQUEST_ID
                            '
                        Catch ex As Exception

                        End Try
                        If type_id = "141" Or type_id = "142" Or type_id = "143" Or type_id = "144" Or type_id = "145" Or type_id = "146" Or type_id = "147" Or type_id = "148" _
                            Or type_id = "791" Or type_id = "790" Or type_id = "190" Or type_id = "191" Or type_id = "192" Or type_id = "193" Or type_id = "194" Or type_id = "195" _
                            Or type_id = "196" Or type_id = "197" Or type_id = "198" Or type_id = "199" Then
                            dao.fields.STATUS_ID = 3
                            AddLogStatus(3, _process, _CLS.CITIZEN_ID, _IDA)
                        Else
                            dao.fields.STATUS_ID = 2
                            AddLogStatus(2, _process, _CLS.CITIZEN_ID, _IDA)
                        End If
                    End If
                Catch ex As Exception

                End Try

                dao.fields.TYPE_REQUEST_ID = ddl_req_type.SelectedValue



                'End If

                dao.update()
                If b64 = Nothing Then
                    b64 = Session("b64")
                End If
                Dim years As String = ""
                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tr.GetDataby_IDA(dao.fields.TR_ID)
                Try
                    years = dao_tr.fields.YEAR

                Catch ex As Exception

                End Try
                Try

                    Dim tr_id As String = ""
                    tr_id = "DA-" & _process & "-" & years & "-" & _TR_ID
                    Dim cls_sop As New CLS_SOP
                    cls_sop.BLOCK_SOP(_CLS.CITIZEN_ID, Request.QueryString("r_process"), "2", "สร้างคำขอ", tr_id, b64)
                    cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "USER", Request.QueryString("r_process"), _CLS.PVCODE, 2, "สร้างคำขอ", "SOP-DRUG-10-" & _process & "-2", "ชำระเงิน", "สร้างคำขอแล้ว รอชำระเงิน", "STAFF", tr_id, SOP_STATUS:="สร้างคำขอ")
                Catch ex As Exception

                End Try
                'Dim dao_staff As New DAO_DRUG.ClsDBE_TRACKING_STAFF_CITIZEN_ID
                'dao_staff.fields.CITIZEN_ID
                Session("b64") = Nothing
                alert("ท่านยืนคำขอแล้ว")
            Else
                'Dim dao As New DAO_DRUG.ClsDBdrrqt
                'dao.GetDataby_IDA(_IDA)
                'Dim tamrap_id As Integer = 0
                Try
                    tamrap_id = dao.fields.feepayst
                Catch ex As Exception

                End Try
                If tamrap_id <> 0 Then
                    'dao.fields.STATUS_ID = 2
                    'dao.update()
                    'AddLogStatus(2, _process, _CLS.CITIZEN_ID, _IDA)
                    'alert("ท่านยืนคำขอแล้ว")
                    Response.Redirect("POPUP_DR_ACCEPT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
                Else

                    Response.Write("<script type='text/javascript'>window.parent.alert('โปรดเลือกกระบวนงานที่ท่านต้องการยื่น');</script> ")
                End If
            End If
        Else
            'dao.fields.STATUS_ID = 2
            'dao.update()
            'AddLogStatus(2, _process, _CLS.CITIZEN_ID, _IDA)
            'alert("ท่านยืนคำขอแล้ว")
            Response.Redirect("POPUP_DR_ACCEPT.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        End If
        
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        'Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 78
        dao.update()

        alert("ยกเลิกข้อมุลเรียบร้อยแล้ว")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    ''' <summary>
    ''' รวม XML เข้าไปที่ PDF จดทะเบียน
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    ''' <summary>
    ''' รวม XML เข้าไปที่ PDFจดแจ้งรายละเอียด
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF2(ByVal filename As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim path As String = bao._PATH_XML_TRADER ' "C:\path\XML_TRADER\"
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(bao._PATH_PDF_TEMPLATE & ".pdf") 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(bao._PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using

        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(bao._PATH_PDF_XML_CLASS & filename & ".pdf")) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DR
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub

    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim lcnsid As String = ""
        Dim regis_ida As Integer = 0
        Dim lcntpcd As String = ""
        Dim rcvno As String = ""
        Dim lcnno As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim thadrgnm As String = ""
        Dim engdrgnm As String = ""
        Dim appdate As Date
        Dim expdate As Date
        Dim STATUS_ID As Integer = 0
        Dim dsgcd As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""

        Dim class_xml As New CLASS_DR
        Dim tamrap_id As Integer = 0
        If Request.QueryString("status") = "8" Then
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(_IDA)
            lcnsid = dao.fields.lcnsid
            Dim dao2 As New DAO_DRUG.ClsDBdrrqt
            Try
                dsgcd = dao.fields.dsgcd
            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try
            Try
                dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
                regis_ida = dao.fields.FK_IDA
                tamrap_id = dao2.fields.feepayst
            Catch ex As Exception

            End Try
            Try
                pvncd = dao.fields.pvncd
            Catch ex As Exception
                pvncd = ""
            End Try
            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Try
                rgttpcd = dao.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                rcvno = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                lcnno = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                pvnabbr = dao.fields.pvnabbr
            Catch ex As Exception

            End Try
            Try
                thadrgnm = dao.fields.thadrgnm
            Catch ex As Exception

            End Try
            Try
                engdrgnm = dao.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
            Catch ex As Exception

            End Try
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)
            Try
                tamrap_id = dao.fields.feepayst
            Catch ex As Exception

            End Try
            Try
                If dao.fields.lcntpcd.Contains("ผย") Then
                    LCNTPCD_GROUP = "2"
                Else
                    LCNTPCD_GROUP = "1"
                End If
            Catch ex As Exception

            End Try
            Try
                dsgcd = dao.fields.dsgcd

            Catch ex As Exception

            End Try
            lcnsid = dao.fields.lcnsid
            regis_ida = dao.fields.FK_IDA
            Try
                pvncd = dao.fields.pvncd
            Catch ex As Exception
                pvncd = ""
            End Try
            DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Try
                rgttpcd = dao.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                rcvno = dao.fields.rcvno
            Catch ex As Exception

            End Try
            Try
                lcnno = dao.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                rgtno = dao.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                pvnabbr = dao.fields.pvnabbr
            Catch ex As Exception

            End Try
            Try
                thadrgnm = dao.fields.thadrgnm
            Catch ex As Exception

            End Try
            Try
                engdrgnm = dao.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                appdate = dao.fields.appdate
            Catch ex As Exception

            End Try
            Try
                expdate = dao.fields.expdate
            Catch ex As Exception

            End Try
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try
                class_xml.drrqts = dao.fields
            Catch ex As Exception

            End Try
            Try
                FK_LCN_IDA = dao.fields.FK_LCN_IDA
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            Catch ex As Exception

            End Try
            Try
                CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
            Catch ex As Exception

            End Try
            Try
                drug_name_th = dao.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                Dim dao_class As New DAO_DRUG.TB_drkdofdrg
                dao_class.GetData_by_kindcd(dao.fields.kindcd)
                class_xml.DRUG_CLASS_NAME = dao_class.fields.thakindnm
            Catch ex As Exception

            End Try
        End If


        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(regis_ida)
        Catch ex As Exception

        End Try
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(FK_LCN_IDA)
            lcntpcd = dao_lcn.fields.lcntpcd
        Catch ex As Exception

        End Try

        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        Try
            class_xml.DRUG_STRENGTH = DRUG_STRENGTH
        Catch ex As Exception

        End Try
        'class_xml = cls.gen_xml()
        Dim head_type As String = ""
        Try
            head_type = ""
            If lcntpcd.Contains("บ") Then
                head_type = "โบราณ"
            Else
                head_type = "ปัจจุบัน"
            End If
        Catch ex As Exception

        End Try

        Dim dao_dos As New DAO_DRUG.TB_drdosage
        Try

            dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_dos.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_dos.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_dos.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try
        Try
            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)
            class_xml.DRRGT_COLORs = dao_color.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
        Catch ex As Exception

        End Try
        Try
            Try
                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
                dao_type.GetDataby_rgttpcd(rgttpcd)
                lcn_long_type = dao_type.fields.thargttpnm_short
            Catch ex As Exception
                lcn_long_type = ""
            End Try
        Catch ex As Exception

        End Try

        
        Try
            rcvno_auto = rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try

        Try
            If STATUS_ID = 8 Then
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                    dao4.GetDataby_IDA(_IDA)
                    'If dao4.fields.USE_PVNABBR2 IsNot Nothing Then
                    '    'If dao4.fields.USE_PVNABBR2 = "1" Then
                    '    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    'End If
                    'Else
                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If

                    End If
                End If
            Else
                If Len(lcnno_auto) > 0 Then
                    'If pvnabbr <> "กท" Then
                    '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                    '    Else
                    '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    End If
                    'Else

                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                    dao4.GetDataby_IDA(_IDA)
                    'If dao4.fields.USE_PVNABBR2 IsNot Nothing Then
                    '    'If dao4.fields.USE_PVNABBR2 = "1" Then
                    '    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    '    'End If
                    'Else
                    '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    'End If
                    If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

                        'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        If Right(Left(lcnno_auto, 3), 1) = "5" Then
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                        Else
                            lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                        End If
                    Else
                        lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
        Dim aa As String = ""
        Dim aa2 As String = ""
        If Request.QueryString("status") = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try

            Try
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
                daodrgtype2.GetDataby_drgtpcd(dao_rq.fields.rgtdrgtpcd)

                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            Dim dao3 As New DAO_DRUG.ClsDBdrrqt
            dao3.GetDataby_IDA(_IDA)
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype2.GetDataby_drgtpcd(dao3.fields.rgtdrgtpcd)
            Try
                aa2 = daodrgtype2.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If
        Try
           
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
                'pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        Try
   
            If Len(rcvno_auto) > 0 Then
                If aa2 = "(NG)" Then
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
                Else
                    rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
                End If
            End If
        Catch ex As Exception

        End Try
        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            'drug_name = drug_name_th

            'drug_name = drug_name_th & " / " & drug_name_eng
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If
        If IsNothing(appdate) = False Then
            ''Dim appdate As Date
            If Date.TryParse(appdate, appdate) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                class_xml.RCVDAY = appdate.Day
                class_xml.RCVMONTH = appdate.ToString("MMMM")
                class_xml.RCVYEAR = con_year(appdate.Year)
            End If
        End If
        If IsNothing(expdate) = False Then
            Dim expdate2 As Date
            If Date.TryParse(expdate, expdate2) = True Then
                class_xml.EXPDAY = expdate.Day
                class_xml.EXPMONTH = expdate.ToString("MMMM")
                class_xml.EXP_YEAR = con_year(expdate.Year)
                Try
                    class_xml.EXPDATESHORT = expdate.Day & "/" & expdate.Month & "/" & con_year(expdate.Year)
                Catch ex As Exception

                End Try
                If class_xml.EXP_YEAR = 544 Then
                    class_xml.EXPDAY = ""
                    class_xml.EXPMONTH = ""
                    class_xml.EXP_YEAR = ""
                    class_xml.EXPDATESHORT = ""
                End If


            End If
        End If
        'Try
        '    If Len(rgtno_auto) > 0 Then
        '        rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
        '    End If
        'Catch ex As Exception

        'End Try


        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format

        'Try
        '    Dim appvdate As Date = class_xml.dalcns.appvdate
        '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
        '    class_xml.fregntf.appvdate = appvdate
        'Catch ex As Exception

        'End Try
        If STATUS_ID = 8 Then
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRGT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        Else
            Dim dt_rgtno As New DataTable
            Dim bao_rgtno As New BAO.ClsDBSqlcommand
            dt_rgtno = bao_rgtno.SP_DRRQT_RGTNO_DISPLAY_BY_IDA(_IDA)
            Try
                rgtno_format = dt_rgtno(0)("rgtno_display")
            Catch ex As Exception

            End Try
        End If
        Dim DRUG_PROPERTIES_AND_DETAIL As String = ""

        class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
        class_xml.LCN_TYPE = lcn_long_type 'ยานี้
        class_xml.TABEAN_FORMAT = rgtno_format
        class_xml.DRUG_NAME = drug_name
        class_xml.COUNTRY = "ไทย"
        class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
        class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
        class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
        class_xml.TABEAN_TYPE1 = TABEAN_TYPE1
        class_xml.TABEAN_TYPE2 = TABEAN_TYPE2
        'drrgts
        'Try
        '    Dim dao_dos As New DAO_DRUG.TB_drdosage
        '    dao_dos.GetDataby_cd(dsgcd)
        '    class_xml.Dossage_form = dao_dos.fields.engdsgnm
        'Catch ex As Exception

        'End Try




        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
        Try
            If STATUS_ID = "8" Then
                Dim dao4 As New DAO_DRUG.ClsDBdrrgt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            Else
                Dim dao4 As New DAO_DRUG.ClsDBdrrqt
                dao4.GetDataby_IDA(_IDA)
                class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao4.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            End If
        Catch ex As Exception

        End Try


        'class_xml.DT_SHOW.DT3 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ผู้ดำเนิน

        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ



        'class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
        'class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
        'class_xml.DT_SHOW.DT10 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
        'class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
        'class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
        'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ
        'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
        'class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
        'class_xml.DT_SHOW.DT15.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_2NO"
        'class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
        'class_xml.DT_SHOW.DT16.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_3NO"
        'class_xml.DT_SHOW.DT17 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 4)
        'class_xml.DT_SHOW.DT17.TableName = "SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_4NO"


        If STATUS_ID <> 8 Then
            Dim dao_det_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FKIDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try
            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRQT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                'PACK_SIZE = dt_pack(0)("contain_detail")
                'class_xml.PACK_SIZE = PACK_SIZE
                PACK_SIZE = dao_re.fields.PACKAGE_DETAIL 'dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try

            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRQT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try
            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRQT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
            class_xml.DT_SHOW.DT20 = bao_show.SP_DRRQT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRQT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


            'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_DATA(_IDA)

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"


            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"

            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        Else
            Dim dao_det_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao_det_prop.GetDataby_FK_IDA(_IDA)
            Try
                class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
            Catch ex As Exception

            End Try
            Dim dt_pack As New DataTable
            Dim bao_pack As New BAO_SHOW
            dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
            Try
                PACK_SIZE = dao_re.fields.PACKAGE_DETAIL 'dt_pack(0)("contain_detail")
                class_xml.PACK_SIZE = PACK_SIZE
            Catch ex As Exception

            End Try
            Try
                Dim dao_dpn As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
                dao_dpn.GetDataby_FKIDA(_IDA)
                class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
            Catch ex As Exception

            End Try
            class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
            class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
            class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
            class_xml.DT_SHOW.DT20 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
            class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
            class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


            'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_DATA(_IDA)

            class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 1)
            class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
            class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 2)
            class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
            class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 3)
            class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"
            class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE(_IDA, 10)
            class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"



            class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
            class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
            class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
            class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
            class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA)
            class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        End If

        Dim statusId As Integer = STATUS_ID
        Dim lcntype As String = "" 'dao.fields.lcntpcd
        'Try
        '    Dim rcvdate As Date = dao.fields.rcvdate
        '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
        '    class_xml.drrgts = dao.fields



        'Catch ex As Exception

        'End Try
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(_process)
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try

        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
            'class_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Catch ex As Exception

        End Try



        Dim p_dr2 As New CLASS_DR
        p_dr2 = p_dr
        ' p_dr2.DT_MASTER = Nothing

        Dim cls_sop1 As New CLS_SOP
        Session("b64") = cls_sop1.CLASS_TO_BASE64(p_dr2)
        b64 = cls_sop1.CLASS_TO_BASE64(p_dr2)
        
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(_process, statusId, 0, 0)
        '------------------------(E)------------------------
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try
            If Request.QueryString("status") = "8" Then
                Dim dao As New DAO_DRUG.ClsDBdrrgt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                E_VALUE = dao_drgtpcd.fields.engdrgtpnm
            Else
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)
                dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
                E_VALUE = dao_drgtpcd.fields.engdrgtpnm
            End If
        Catch ex As Exception

        End Try
        Dim NAME_TEMPLATE As String = ""
        If E_VALUE <> "(E)" Then
            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            If Request.QueryString("STATUS_ID") = "8" Or Request.QueryString("STATUS_ID") = "14" Then
                If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    Try
                        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                        dao_rg.GetDataby_IDA(_IDA)
                        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                        dao_rq.GetDataby_IDA(dao_rg.fields.FK_DRRQT)
                        Dim dao_tr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                        dao_tr.GetDataby_TAMRAP_ID(dao_rq.fields.dvcd)
                        If rgttpcd = "G" And dao_tr.fields.IDA <> 0 Then
                            NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                        Else
                            NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                        End If
                    Catch ex As Exception

                    End Try
                    'Else
                    '    If rgttpcd = "G" Or rgttpcd = "H" Or rgttpcd = "K" Then
                    '        Try
                    '            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                    '            dao_rg.GetDataby_IDA(_IDA)
                    '            Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                    '            dao_rq.GetDataby_IDA(dao_rg.fields.FK_DRRQT)
                    '            Dim dao_tr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
                    '            dao_tr.GetDataby_TAMRAP_ID(dao_rq.fields.dvcd)
                    '            'If rgttpcd = "G" And dao_tr.fields.IS_AUTO = 1 Then
                    '            If rgttpcd = "G" And tamrap_id <> 0 Then
                    '                NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
                    '            Else
                    '                NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    '            End If
                    '        Catch ex As Exception

                    '        End Try
                    '    End If
                End If
                'Else

            End If
        Else
            If Request.QueryString("status") = "8" Or Request.QueryString("status") = "14" Then
                NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"

            Else
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If
        End If

        If tamrap_id <> 0 Then
            If Request.QueryString("status") = "8" Then
                Dim dao3 As New DAO_DRUG.ClsDBdrrgt
                dao3.GetDataby_IDA(_IDA)
                Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                Try
                    dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
                    If dao_rq.fields.feetpcd = "1" Then
                        NAME_TEMPLATE = "DA_YOR_2_1_AUTO.pdf"
                    ElseIf dao_rq.fields.feetpcd = "99" Then
                        NAME_TEMPLATE = "DA_YOR_2_1.pdf"
                    End If
                Catch ex As Exception

                End Try

            Else
                NAME_TEMPLATE = "DA_YOR_1_AUTO_READONLY.pdf"
            End If
        End If


        '-----------------------------------------------------
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID)
        Try
            Dim url As String = ""
            ' If Request.QueryString("status") = 8 Or Request.QueryString("status") = 14 Then
            url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
            'Else
            '    url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF_VIEW.aspx?filename=" & filename
            'End If

            'Dim url As String 
            class_xml.QR_CODE = QR_CODE_IMG(url)
        Catch ex As Exception

        End Try

        p_dr = class_xml

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        '
        If Request.QueryString("status") = 8 Or Request.QueryString("status") = 14 Then
            If tamrap_id <> 0 Then
                lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='https://medicina.fda.moph.go.th/FDA_DRUG_DEMO/PDF/FRM_PDF_VIEW.aspx?FileName=" & filename & "' ></iframe>"
                hl_reader.NavigateUrl = "https://medicina.fda.moph.go.th/FDA_DRUG_DEMO/PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
            Else
                lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "&status=" & Request.QueryString("status") & "' ></iframe>"
                hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename & "&status=" & Request.QueryString("status")  ' Link เปิดไฟล์ตัวใหญ่
            End If

        Else
            If tamrap_id <> 0 Then
                If Request.QueryString("status") = 1 Or Request.QueryString("status") = "2" Then
                    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='https://medicina.fda.moph.go.th/FDA_DRUG_DEMO/PDF/FRM_PDF_VIEW.aspx?FileName=" & filename & "' ></iframe>"
                    hl_reader.NavigateUrl = "https://medicina.fda.moph.go.th/FDA_DRUG_DEMO/PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
                Else
                    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename & "' ></iframe>"
                    hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
                End If
            Else
                lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
                hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
            End If

        End If

        HiddenField1.Value = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
End Class