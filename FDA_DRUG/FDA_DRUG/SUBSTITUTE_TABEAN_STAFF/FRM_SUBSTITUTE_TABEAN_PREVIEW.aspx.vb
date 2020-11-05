Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf

Public Class FRM_SUBSTITUTE_TABEAN_PREVIEW
    Inherits System.Web.UI.Page
    Private _IDA As Integer
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _YEARS As String
    Private _IDA_sub As Integer
    Sub RunSession()
        Try
            _IDA = Request.QueryString("rgt_ida")
        Catch ex As Exception

        End Try
        Try
            _IDA_sub = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _process = Request.QueryString("Process")
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Bind_ddl()
            'If ddl_template.SelectedValue <> "0" Then

            'End If
            Try

                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(_IDA)

                Dim dao_sun As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
                dao_sun.GetDatabyIDA(_IDA_sub)
                ddl_template.DropDownSelectData(dao_sun.fields.TEMPLATE_ID)
            Catch ex As Exception

            End Try
            BindData_PDF_SAI(Request.QueryString("newcode"))
        End If
    End Sub
    Public Sub Bind_ddl()
        Dim dao As New DAO_DRUG.TB_MAS_SUBSTITUTE_TEMPLATE
        dao.GetDataAll()
        ddl_template.DataSource = dao.datas
        ddl_template.DataBind()

        Dim item As New ListItem
        item.Text = "---เลือกแบบ pdf---"
        item.Value = "0"
        ddl_template.Items.Insert(0, item)
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
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

    'Private Sub BindData_PDF()
    '    Dim bao As New BAO.AppSettings
    '    bao.RunAppSettings()

    '    Dim lcnno_format As String = ""
    '    Dim lcnno_auto As String = ""
    '    Dim lcn_long_type As String = ""

    '    Dim rgtno_format As String = ""
    '    Dim rgtno_auto As String = ""
    '    Dim rgttpcd As String = ""
    '    Dim drug_name As String = ""
    '    Dim drug_name_th As String = ""
    '    Dim drug_name_eng As String = ""
    '    Dim pvncd As String = ""
    '    Dim rcvno_format As String = ""
    '    Dim rcvno_auto As String = ""
    '    Dim PACK_SIZE As String = ""
    '    Dim DRUG_STRENGTH As String = ""
    '    Dim lcnsid As String = ""
    '    Dim regis_ida As Integer = 0
    '    Dim lcntpcd As String = ""
    '    Dim rcvno As String = ""
    '    Dim lcnno As String = ""
    '    Dim rgtno As String = ""
    '    Dim pvnabbr As String = ""
    '    Dim thadrgnm As String = ""
    '    Dim engdrgnm As String = ""
    '    Dim appdate As Date
    '    Dim STATUS_ID As Integer = 0
    '    Dim dsgcd As String = ""
    '    Dim FK_LCN_IDA As Integer = 0
    '    Dim CHK_LCN_SUBTYPE1 As String = ""
    '    Dim CHK_LCN_SUBTYPE2 As String = ""
    '    Dim CHK_LCN_SUBTYPE3 As String = ""
    '    Dim TABEAN_TYPE1 As String = ""
    '    Dim TABEAN_TYPE2 As String = ""
    '    Dim LCNTPCD_GROUP As String = ""
    '    Dim Chanid_ya As String = ""
    '    Dim class_xml As New CLASS_DR
    '    Dim dao As New DAO_DRUG.ClsDBdrrgt
    '    dao.GetDataby_IDA(_IDA)
    '    lcnsid = dao.fields.lcnsid
    '    Dim dao2 As New DAO_DRUG.ClsDBdrrqt
    '    Try
    '        dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        dsgcd = dao.fields.dsgcd

    '    Catch ex As Exception

    '    End Try
    '    Try
    '        If dao.fields.lcntpcd.Contains("ผย") Then
    '            LCNTPCD_GROUP = "2"
    '        Else
    '            LCNTPCD_GROUP = "1"
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Dim dao_dose As New DAO_DRUG.TB_drdosage
    '        dao_dose.GetDataby_cd(dao.fields.dsgcd)
    '        If dao_dose.fields.thadsgnm <> "-" Then
    '            If dao_dose.fields.engdsgnm <> "-" Then
    '                Chanid_ya = dao_dose.fields.thadsgnm & "/" & dao_dose.fields.engdsgnm
    '            Else
    '                Chanid_ya = dao_dose.fields.thadsgnm
    '            End If
    '        ElseIf dao_dose.fields.engdsgnm <> "-" Then
    '            Chanid_ya = dao_dose.fields.engdsgnm
    '        End If
    '        'Chanid_ya = dao_dose.fields.engdsgnm
    '    Catch ex As Exception

    '    End Try

    '    class_xml.CHANID_YA = Chanid_ya
    '    Try
    '        'dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
    '        regis_ida = dao.fields.FK_IDA
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        pvncd = dao.fields.pvncd
    '    Catch ex As Exception
    '        pvncd = ""
    '    End Try
    '    DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
    '    Try
    '        rgttpcd = dao.fields.rgttpcd
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        rcvno = dao2.fields.rcvno
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        lcnno = dao.fields.lcnno
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        rgtno = dao.fields.rgtno
    '    Catch ex As Exception

    '    End Try

    '    Try
    '        thadrgnm = dao.fields.thadrgnm
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        engdrgnm = dao.fields.engdrgnm
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        appdate = dao.fields.appdate
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        STATUS_ID = dao.fields.STATUS_ID
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        FK_LCN_IDA = dao.fields.FK_LCN_IDA
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        TABEAN_TYPE1 = dao.fields.TABEAN_TYPE1
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        TABEAN_TYPE2 = dao.fields.TABEAN_TYPE2
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        drug_name_th = dao.fields.thadrgnm
    '        'drug_name
    '    Catch ex As Exception
    '        drug_name_th = "-"
    '    End Try
    '    Try
    '        drug_name_eng = dao.fields.engdrgnm
    '    Catch ex As Exception
    '        drug_name_eng = "-"
    '    End Try


    '    Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
    '    Try
    '        dao_re.GetDataby_IDA(regis_ida)
    '    Catch ex As Exception

    '    End Try
    '    Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
    '    Try
    '        dao_lcn.GetDataby_IDA(FK_LCN_IDA)
    '        lcntpcd = dao_lcn.fields.lcntpcd
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        pvnabbr = dao_lcn.fields.pvnabbr
    '    Catch ex As Exception

    '    End Try
    '    Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
    '    Try
    '        class_xml.DRUG_STRENGTH = DRUG_STRENGTH
    '    Catch ex As Exception

    '    End Try
    '    'class_xml = cls.gen_xml()
    '    Dim head_type As String = ""
    '    Try
    '        head_type = ""
    '        If lcntpcd.Contains("บ") Then
    '            head_type = "โบราณ"
    '        Else
    '            head_type = "ปัจจุบัน"
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Dim dao_dos As New DAO_DRUG.TB_drdosage
    '    Try
    '        dao_dos.GetDataby_cd(dsgcd)
    '        If head_type = "โบราณ" Then
    '            If dao_dos.fields.thadsgnm <> "-" Then
    '                class_xml.Dossage_form = dao_dos.fields.thadsgnm
    '            Else
    '                class_xml.Dossage_form = dao_dos.fields.engdsgnm
    '            End If

    '        ElseIf head_type = "ปัจจุบัน" Then
    '            If Trim(dao_dos.fields.engdsgnm) = "-" Then
    '                class_xml.Dossage_form = dao_dos.fields.thadsgnm
    '            Else
    '                class_xml.Dossage_form = dao_dos.fields.engdsgnm
    '            End If

    '        End If

    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
    '        dao_color.GetDataby_FK_IDA(_IDA)
    '        class_xml.DRRGT_COLORs = dao_color.fields
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
    '        dao_cas.GetDataby_FKIDA(_IDA)
    '        class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
    '        dao_packk.GetDataby_FKIDA(_IDA)
    '        class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Try
    '            Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
    '            dao_type.GetDataby_rgttpcd(rgttpcd)
    '            lcn_long_type = dao_type.fields.thargttpnm_short
    '        Catch ex As Exception
    '            lcn_long_type = ""
    '        End Try
    '    Catch ex As Exception

    '    End Try


    '    Try
    '        rcvno_auto = rcvno
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        lcnno_auto = lcnno
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        rgtno_auto = rgtno
    '    Catch ex As Exception

    '    End Try
    '    Try

    '        'If Len(lcnno_auto) > 0 Then
    '        '    If pvnabbr <> "กท" Then
    '        '        If Right(Left(lcnno_auto, 3), 1) = "5" Then
    '        '            lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
    '        '        Else
    '        '            lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '        '        End If
    '        '    Else
    '        '        lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '        '    End If

    '        'End If
    '        If Len(lcnno_auto) > 0 Then
    '            'If pvnabbr <> "กท" Then
    '            '    If Right(Left(lcnno_auto, 3), 1) = "5" Then
    '            '        lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
    '            '    Else
    '            '        lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '            '    End If
    '            'Else

    '            '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '            'End If
    '            Dim dao4 As New DAO_DRUG.ClsDBdrrgt
    '            dao4.GetDataby_IDA(_IDA)
    '            'If dao4.fields.USE_PVNABBR2 IsNot Nothing Then
    '            '    'If dao4.fields.USE_PVNABBR2 = "1" Then
    '            '    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '            '    'End If
    '            'Else
    '            '    lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '            'End If
    '            If dao4.fields.USE_PVNABBR2 IsNot Nothing Then

    '                'lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '                If Right(Left(lcnno_auto, 3), 1) = "5" Then
    '                    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
    '                Else
    '                    lcnno_format = dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '                End If
    '            Else
    '                lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    'Try
    '    '    If Len(lcnno_auto) > 0 Then
    '    '        If pvnabbr <> "กท" Then
    '    '            lcnno_format = pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '    '        Else
    '    '            lcnno_format = CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
    '    '        End If

    '    '    End If
    '    'Catch ex As Exception

    '    'End Try
    '    Dim aa As String = ""
    '    Dim aa2 As String = ""

    '    'If Request.QueryString("status") = "8" Then
    '    Dim dao3 As New DAO_DRUG.ClsDBdrrgt
    '    dao3.GetDataby_IDA(_IDA)
    '    Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
    '    daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

    '    Try
    '        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
    '        dao_rq.GetDataby_IDA(dao3.fields.FK_DRRQT)
    '        Dim daodrgtype2 As New DAO_DRUG.ClsDBdrdrgtype
    '        daodrgtype2.GetDataby_drgtpcd(dao_rq.fields.drgtpcd)

    '        aa2 = daodrgtype2.fields.engdrgtpnm
    '    Catch ex As Exception

    '    End Try

    '    Try
    '        aa = daodrgtype.fields.engdrgtpnm
    '    Catch ex As Exception

    '    End Try
    '    'Else
    '    '    Dim dao3 As New DAO_DRUG.ClsDBdrrqt
    '    '    dao3.GetDataby_IDA(_IDA)
    '    '    Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
    '    '    daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

    '    '    Try
    '    '        aa = daodrgtype.fields.engdrgtpnm
    '    '    Catch ex As Exception

    '    '    End Try
    '    'End If
    '    Try

    '        If Len(rgtno_auto) > 0 Then
    '            rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
    '            'pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2) & " " & aa
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Try
    '        If Len(rcvno_auto) > 0 Then
    '            If aa2 = "(NG)" Then
    '                rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2)
    '            Else
    '                rcvno_format = rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try
    '    If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
    '        drug_name = drug_name_eng
    '    ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
    '        'drug_name = drug_name_th

    '        'drug_name = drug_name_th & " / " & drug_name_eng
    '        drug_name = drug_name_th
    '    Else
    '        drug_name = drug_name_th & " / " & drug_name_eng
    '    End If

    '    If Trim(drug_name) = "/" Then
    '        drug_name = ""
    '    End If
    '    If IsNothing(appdate) = False Then
    '        ''Dim appdate As Date
    '        If Date.TryParse(appdate, appdate) = True Then
    '            class_xml.SHOW_LCNDATE_DAY = appdate.Day
    '            class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
    '            class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

    '            class_xml.RCVDAY = appdate.Day
    '            class_xml.RCVMONTH = appdate.ToString("MMMM")
    '            class_xml.RCVYEAR = con_year(appdate.Year)
    '        End If
    '    End If

    '    'Try
    '    '    If Len(rgtno_auto) > 0 Then
    '    '        rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
    '    '    End If
    '    'Catch ex As Exception

    '    'End Try


    '    class_xml.LCNNO_FORMAT = lcnno_format
    '    class_xml.RCVNO_FORMAT = rcvno_format

    '    'Try
    '    '    Dim appvdate As Date = class_xml.dalcns.appvdate
    '    '    appvdate = DateAdd(DateInterval.Year, 543, appvdate)
    '    '    class_xml.fregntf.appvdate = appvdate
    '    'Catch ex As Exception

    '    'End Try
    '    Dim DRUG_PROPERTIES_AND_DETAIL As String = ""

    '    class_xml.TABEAN_TYPE = "ใบสำคัญการขึ้นทะเบียนตำรับยาแผน" & head_type 'แผนโบราณ แผนปัจจุบัน
    '    class_xml.LCN_TYPE = lcn_long_type 'ยานี้
    '    class_xml.TABEAN_FORMAT = rgtno_format
    '    class_xml.DRUG_NAME = drug_name
    '    class_xml.COUNTRY = "ไทย"
    '    class_xml.CHK_LCN_SUBTYPE1 = CHK_LCN_SUBTYPE1
    '    class_xml.CHK_LCN_SUBTYPE2 = CHK_LCN_SUBTYPE2
    '    class_xml.CHK_LCN_SUBTYPE3 = CHK_LCN_SUBTYPE3
    '    Try
    '        If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
    '            class_xml.TABEAN_TYPE1 = "2"
    '            'cls_xml.TABEAN_TYPE2 = "2"
    '        Else
    '            class_xml.TABEAN_TYPE1 = "1"
    '            'cls_xml.TABEAN_TYPE2 = "0"
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    class_xml.TABEAN_TYPE2 = TABEAN_TYPE2


    '    Dim bao_show As New BAO_SHOW
    '    class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
    '    Try
    '        'class_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
    '    Catch ex As Exception

    '    End Try




    '    Dim dao_det_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
    '    dao_det_prop.GetDataby_FK_IDA(_IDA)
    '    Try
    '        class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.DRUG_PROPERTIES_AND_DETAIL
    '    Catch ex As Exception

    '    End Try
    '    Dim dt_pack As New DataTable
    '    Dim bao_pack As New BAO_SHOW
    '    dt_pack = bao_pack.SP_GET_PACKAGE_TEXT_DRRGT_PACKAGE_DETAIL_BY_FK_IDA(_IDA)
    '    Try
    '        PACK_SIZE = dt_pack(0)("contain_detail")
    '        class_xml.PACK_SIZE = PACK_SIZE
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Dim dao_dpn As New DAO_DRUG.TB_DRRGT_DRUG_PER_UNIT
    '        dao_dpn.GetDataby_FKIDA(_IDA)
    '        class_xml.DRUG_PER_UNIT = dao_dpn.fields.drugperunit
    '    Catch ex As Exception

    '    End Try
    '    class_xml.DT_SHOW.DT8 = bao_show.SP_DRRGT_PACKAGE_DETAIL_BY_IDA(_IDA) 'ขนาดบรรจุ
    '    class_xml.DT_SHOW.DT8.TableName = "SP_DRUG_REGISTRATION_PACKAGE_BY_IDA"
    '    class_xml.DT_SHOW.DT9 = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(_IDA) 'ATC
    '    class_xml.DT_SHOW.DT9.TableName = "SP_DRRGT_ATC_DETAIL_BY_FK_IDA"
    '    class_xml.DT_SHOW.DT20 = bao_show.SP_DRRGT_DETAIL_CAS_BY_FK_IDA_NEW(_IDA) 'สารสำคัญ/ส่วนประกอบ(รวม)
    '    class_xml.DT_SHOW.DT20.TableName = "SP_DRRGT_DETAIL_CAS_BY_FK_IDA"
    '    class_xml.DT_SHOW.DT11 = bao_show.SP_DRRGT_PROPERTIES_BY_FK_IDA(_IDA) 'สรรพคุณ
    '    class_xml.DT_SHOW.DT12 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่
    '    'class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_OTHER_BY_FK_IDA(_IDA) 'ผู้ผลิต ผู้เกี่ยวข้อง หน้าที่อื่นๆ


    '    'class_xml.DT_SHOW.DT14 = bao_show.SP_DRUG_REGISTRATION_MASTER(dao.fields.FK_IDA)
    '    class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_DATA(_IDA)

    '    class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 1)
    '    class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
    '    class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 2)
    '    class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
    '    class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_V2(_IDA, 3)
    '    class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"

    '    class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)
    '    class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
    '    class_xml.DT_SHOW.DT21 = bao_show.SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
    '    class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
    '    class_xml.DT_SHOW.DT23 = bao_show.SP_DRRQT_CAS_EQTO(_IDA)
    '    class_xml.DT_SHOW.DT23.TableName = "SP_regis"

    '    Dim statusId As Integer = STATUS_ID
    '    Dim lcntype As String = "" 'dao.fields.lcntpcd
    '    'Try
    '    '    Dim rcvdate As Date = dao.fields.rcvdate
    '    '    dao.fields.rcvdate = DateAdd(DateInterval.Year, 543, rcvdate)
    '    '    class_xml.drrgts = dao.fields



    '    'Catch ex As Exception

    '    'End Try
    '    Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
    '    dao_sub.GetDatabyIDA(_IDA_sub)
    '    Dim subs_appdate As Date
    '    Try
    '        subs_appdate = dao_sub.fields.appdate
    '    Catch ex As Exception

    '    End Try
    '    Dim template_id As Integer = 0
    '    Try
    '        template_id = dao_sub.fields.TEMPLATE_ID
    '    Catch ex As Exception
    '        template_id = 0
    '    End Try
    '    Dim E_VALUE As String = ""
    '    Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
    '    Try
    '        dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
    '        E_VALUE = dao_drgtpcd.fields.engdrgtpnm

    '    Catch ex As Exception

    '    End Try

    '    If IsNothing(subs_appdate) = False Then
    '        ''Dim appdate As Date
    '        If Date.TryParse(subs_appdate, subs_appdate) = True Then
    '            class_xml.SUBS_APP_DAY = subs_appdate.Day
    '            class_xml.SUBS_APP_MONTH = subs_appdate.ToString("MMMM")
    '            class_xml.SUBS_APP_YEAR = con_year(subs_appdate.Year)
    '            class_xml.FULL_SUBS_APPDATER = subs_appdate.Day & " " & subs_appdate.ToString("MMMM") & " " & con_year(subs_appdate.Year)

    '        End If
    '    End If
    '    Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
    '    Try
    '        dao_st.GetDataby_IDA(dao_sub.fields.STAFF_SIGN_IDA)
    '        class_xml.STAFF_NAME2 = dao_st.fields.STAFF_OFFER_NAME
    '        Try
    '            Dim dt_staffname As New DataTable
    '            'dt_staffname = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
    '            class_xml.STAFF_NAME1 = set_name_company(dao_st.fields.INSERT_CITIZEN)
    '            'class_xml.STAFF_NAME1 = 
    '        Catch ex As Exception

    '        End Try

    '    Catch ex As Exception

    '    End Try
    '    Try
    '        class_xml.POSITION_NAME1 = dao_sub.fields.POSITION_NAME1
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Dim dao_position As New DAO_DRUG.TB_MAS_STAFF_POSITION
    '        dao_position.GetDatabyIDA(dao_sub.fields.POSITION_NAME2)
    '        class_xml.POSITION_NAME2 = dao_position.fields.POSITION_NAME
    '    Catch ex As Exception

    '    End Try
    '    Try

    '    Catch ex As Exception

    '    End Try
    '    Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
    '    dao_pro.GetDataby_Process_ID(_process)
    '    Try
    '        lcntype = dao_pro.fields.PROCESS_DESCRIPTION
    '    Catch ex As Exception

    '    End Try

    '    p_dr = class_xml

    '    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
    '    '
    '    '------------------------(E)------------------------
    '    'Dim E_VALUE As String = ""
    '    'Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
    '    'Try
    '    '    If Request.QueryString("status") = "8" Then
    '    '        Dim dao As New DAO_DRUG.ClsDBdrrgt
    '    '        dao.GetDataby_IDA(_IDA)
    '    '        dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
    '    '        E_VALUE = dao_drgtpcd.fields.engdrgtpnm
    '    '    Else
    '    '        Dim dao As New DAO_DRUG.ClsDBdrrqt
    '    '        dao.GetDataby_IDA(_IDA)
    '    '        dao_drgtpcd.GetDataby_drgtpcd(dao.fields.drgtpcd)
    '    '        E_VALUE = dao_drgtpcd.fields.engdrgtpnm
    '    '    End If
    '    'Catch ex As Exception

    '    'End Try
    '    Dim NAME_TEMPLATE As String = ""
    '    'If E_VALUE <> "(E)" Then
    '    '    NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
    '    'Else
    '    '    If Request.QueryString("status") = "8" Then
    '    '        NAME_TEMPLATE = "DA_YOR_2_E_READONLY.pdf"
    '    '    Else

    '    '    End If
    '    'End If

    '    'If template_id <> 0 Then
    '    '    dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, template_id, _group:=1)
    '    '    NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
    '    'Else
    '    Try
    '        If ddl_template.SelectedValue = "0" Then
    '            If E_VALUE <> "(E)" Then
    '                'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, ddl_template.SelectedValue, _group:=1)
    '                'NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
    '                NAME_TEMPLATE = "DATAN_YOR_2_NCIENT_READONLY.pdf"
    '            Else
    '                'If Request.QueryString("status") = "8" Or Request.QueryString("status") = "14" Then
    '                NAME_TEMPLATE = "DATAN_YOR_2_NCIENT_READONLY_E.pdf"
    '                'Else
    '                '    NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
    '                'End If
    '            End If

    '            'dao_pdftemplate.GetDataby_TEMPLAETE_TABEAN(_process, statusId, 0)
    '        Else
    '            dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, ddl_template.SelectedValue, _group:=1)
    '            NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
    '        End If

    '    Catch ex As Exception

    '    End Try


    '    'End If



    '    '-----------------------------------------------------
    '    Dim paths As String = bao._PATH_DEFAULT
    '    Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE
    '    Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID)
    '    Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID)
    '    LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename, SUBSTITUTE:="1") 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


    '    lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
    '    hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
    '    HiddenField1.Value = filename
    '    _CLS.FILENAME_PDF = NAME_PDF("DA", _process, _YEARS, _TR_ID)
    '    _CLS.PDFNAME = filename
    '    '    show_btn() 'ตรวจสอบปุ่ม
    'End Sub
    Private Sub BindData_PDF_SAI(ByVal newcode As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim lcnno_format As String = ""
        Dim lcnno_auto As String = ""
        Dim lcn_long_type As String = ""
        Dim lcnno As String = ""

        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim drgtpcd As String = ""
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim pvncd As String = ""
        Dim rcvno_format As String = ""
        Dim rcvno_auto As String = ""
        Dim PACK_SIZE As String = ""
        Dim DRUG_STRENGTH As String = ""
        Dim tr_id As String = 0
        Dim IDA_regist As Integer = 0
        Dim lcnsid As Integer = 0
        Dim lcntpcd As String = ""
        Dim appdate As Date
        Dim expdate As Date
        Dim pvnabbr As String = ""
        Dim dsgcd As String = ""
        Dim STATUS_ID As Integer = 0
        Dim CHK_LCN_SUBTYPE1 As String = ""
        Dim CHK_LCN_SUBTYPE2 As String = ""
        Dim CHK_LCN_SUBTYPE3 As String = ""
        Dim TABEAN_TYPE1 As String = ""
        Dim TABEAN_TYPE2 As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim FK_LCN_IDA As Integer = 0
        Dim wong_lep As String = ""
        Try
            STATUS_ID = 8 'Request.QueryString("STATUS_ID") 'Get_drrqt_Status(_IDA)
        Catch ex As Exception

        End Try
        Dim tamrap_id As Integer = 0
        Dim class_xml As New CLASS_DR

        Dim dao_e As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        dao_e.GetDataby_u1_frn_no(newcode)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        'dao.GetDataby_IDA(_IDA)
        dao.GetDataby_4key(dao_e.fields.rgtno, dao_e.fields.rgttpcd, dao_e.fields.drgtpcd, dao_e.fields.pvncd)
        Dim dao2 As New DAO_DRUG.ClsDBdrrqt
        Try
            class_xml.drrgts = dao.fields
        Catch ex As Exception

        End Try
        Try
            dao2.GetDataby_IDA(dao.fields.FK_DRRQT)
            'regis_ida = dao.fields.FK_IDA
            tamrap_id = dao2.fields.feepayst
        Catch ex As Exception

        End Try
        Try
            Dim dao_color As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR
            dao_color.GetDataby_Newcode(newcode)
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_color.fields.drgchrtha
        Catch ex As Exception

        End Try
        Try
            'Dim dao_class As New DAO_DRUG.TB_drkdofdrg
            'dao_class.GetData_by_kindcd(dao.fields.kindcd)
            class_xml.DRUG_CLASS_NAME = dao_e.fields.thakindnm
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
        lcnno = dao_e.fields.lcnno
        Try
            If dao_e.fields.lcntpcd.Contains("ผยบ") Or dao_e.fields.lcntpcd.Contains("นยบ") Then
                TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
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
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
        Try
            dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
        Catch ex As Exception

        End Try

        Try
            IDA_regist = dao_rq.fields.FK_IDA
        Catch ex As Exception

        End Try
        Try
            FK_LCN_IDA = dao.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao.fields.lcnsid
        Catch ex As Exception

        End Try

        DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
        pvncd = dao_e.fields.pvncd
        rgttpcd = dao_e.fields.rgttpcd
        dsgcd = dao_e.fields.dsgcd
        Try
            STATUS_ID = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try

        Try
            rcvno_auto = dao_e.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno_auto = dao_e.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = dao_e.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            drgtpcd = dao_e.fields.drgtpcd
        Catch ex As Exception

        End Try
        Try
            appdate = dao_e.fields.appdate
        Catch ex As Exception

        End Try
        Try
            expdate = dao_e.fields.expdate
        Catch ex As Exception

        End Try
        pvnabbr = dao_e.fields.pvnabbr
        Try
            drug_name_th = dao_e.fields.thadrgnm
            'drug_name
        Catch ex As Exception
            drug_name_th = "-"
        End Try
        Try
            drug_name_eng = dao_e.fields.engdrgnm
        Catch ex As Exception
            drug_name_eng = "-"
        End Try

        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Try
            dao_re.GetDataby_IDA(IDA_regist)
        Catch ex As Exception

        End Try

        Dim dao_lcn As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_DRUG_LCN_ESUB
        Try
            dao_lcn.GetDataby_u1(dao_e.fields.Newcode_not)
            lcntpcd = dao_lcn.fields.lcntpcd
            pvnabbr = dao_lcn.fields.pvnabbr
        Catch ex As Exception

        End Try
        Dim cls As New CLASS_GEN_XML.DR(_CLS.CITIZEN_ID, lcnsid, dao_lcn.fields.lcnno, pvncd, dao_lcn.fields.IDA)
        ' Dim _process As String = 0
        Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            If Len(_TR_ID) >= 9 Then
                dao_tr.GetDataby_TR_ID_Process(_TR_ID, "1400001")
            Else
                dao_tr.GetDataby_IDA(_TR_ID)
            End If
            '_process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try


        Try
            class_xml.DRUG_STRENGTH = dao_e.fields.potency
        Catch ex As Exception

        End Try
        Try
            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)
            'Dim dao_cas As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_IOW
            'dao_cas.GetDataby_Newcode_U(newcode)
            class_xml.DRRGT_DETAIL_Cs = dao_cas.fields
            'class_xml.DRRGT_DETAIL_Cs.AORI = dao_cas.fields.aori
        Catch ex As Exception

        End Try
        Try
            Dim dao_packk As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_packk.GetDataby_FKIDA(_IDA)
            class_xml.DRRGT_PACKAGE_DETAILs = dao_packk.fields
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

            'dao_dos.GetDataby_cd(dsgcd)
            If head_type = "โบราณ" Then
                If dao_e.fields.thadsgnm <> "-" Then
                    class_xml.Dossage_form = dao_e.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_e.fields.engdsgnm
                End If

            ElseIf head_type = "ปัจจุบัน" Then
                If Trim(dao_dos.fields.engdsgnm) = "-" Then
                    class_xml.Dossage_form = dao_e.fields.thadsgnm
                Else
                    class_xml.Dossage_form = dao_e.fields.engdsgnm
                End If

            End If

        Catch ex As Exception

        End Try

        Try
            pvncd = pvncd
        Catch ex As Exception
            pvncd = ""
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



        If IsNothing(appdate) = False Then
            Dim appdate2 As Date
            If Date.TryParse(appdate, appdate2) = True Then
                class_xml.SHOW_LCNDATE_DAY = appdate.Day
                class_xml.SHOW_LCNDATE_MONTH = appdate.ToString("MMMM")
                class_xml.SHOW_LCNDATE_YEAR = con_year(appdate.Year)

                If class_xml.SHOW_LCNDATE_YEAR = 544 Then
                    class_xml.SHOW_LCNDATE_DAY = ""
                    class_xml.SHOW_LCNDATE_MONTH = ""
                    class_xml.SHOW_LCNDATE_YEAR = ""
                End If

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

        Dim aa As String = ""
        Dim aa2 As String = ""

        'Try
        '    If Len(rgtno_auto) > 0 Then
        'rgtno_format = dao_e.fields.register 'rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
        '    End If
        'Catch ex As Exception

        'End Try
        Dim pvnabbr2 As String = ""
        Try
            pvnabbr2 = dao_e.fields.pvnabbr2
        Catch ex As Exception

        End Try
        Try

            'If dao_e.fields.lcntpcd.Contains("ผย1") Then
            '    If dao_e.fields.pvnabbr = "กท" Then
            '        lcnno_format = CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            '    Else
            '        lcnno_format = dao_e.fields.pvnabbr2 & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2)
            '    End If

            'Else
            lcnno_format = pvnabbr2 & " " & CStr(CInt(Right(dao_e.fields.lcnno, 4))) & "/25" & Left(dao_e.fields.lcnno, 2) 'dao_e.fields.lcnno_no
            'End If


        Catch ex As Exception

        End Try
        'dao4.fields.pvnabbr2 & " " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)

        'Try
        rcvno_format = dao_e.fields.register_rcvno 'rgttpcd & " " & CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) & " " & aa2
            'Catch ex As Exception

            'End Try

            If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If


        'Try
        rgtno_format = dao_e.fields.register
            'Catch ex As Exception

            'End Try


            class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RCVNO_FORMAT = rcvno_format
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

        Dim bao_show As New BAO_SHOW
        class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.IDA_dalcn) 'ข้อมูลสถานที่จำลอง

        Try
            Dim dt_thanm As DataTable = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_e.fields.Identify, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
            For Each dr As DataRow In dt_thanm.Rows
                dr("thanm") = dao_e.fields.licen_loca
            Next
            'Dim dt_thanm2 As DataTable
            'dt_thanm2 = dt_thanm.Clone
            'Dim dr_nm As DataRow = dt_thanm2.NewRow()
            'dr_nm("thanm") = dao_e.fields.licen_loca
            'dt_thanm2.Rows.Add(dr_nm)
            class_xml.DT_SHOW.DT17 = dt_thanm
        Catch ex As Exception

        End Try

        Dim dao_det_prop As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_DRUG_COLOR
        dao_det_prop.GetDataby_Newcode(newcode)
        Try
            class_xml.DRUG_PROPERTIES_AND_DETAIL = dao_det_prop.fields.drgchrtha
        Catch ex As Exception

        End Try

        class_xml.DT_SHOW.DT13 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 1)
        class_xml.DT_SHOW.DT13.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_2NO"
        class_xml.DT_SHOW.DT14 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 2)
        class_xml.DT_SHOW.DT14.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3NO"
        class_xml.DT_SHOW.DT16 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 10)
        class_xml.DT_SHOW.DT16.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_3_2NO"

        class_xml.DT_SHOW.DT15 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_ANDTYPE_NEWCODE(newcode, 3)
        class_xml.DT_SHOW.DT15.TableName = "SP_DRUG_REGISTRATION_PRODUCER_BY_FK_IDA_AND_TYPE_4NO"



        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        dao_dal.GetDataby_IDA(dao_lcn.fields.IDA)
        class_xml.DT_SHOW.DT18 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_NEWCODE_SAI(newcode)
        class_xml.DT_SHOW.DT18.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA_FULLADDR"
        class_xml.DT_SHOW.DT23 = bao_show.SP_drrgt_cas(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"
        class_xml.DT_SHOW.DT21 = bao_show.SP_DRRGT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER(_IDA, 9, LCNTPCD_GROUP)
        class_xml.DT_SHOW.DT21.TableName = "SP_DRRQT_PRODUCER_BY_FK_IDA_AND_TYPE_AND_LCN_TYPE_OTHER"
        class_xml.DT_SHOW.DT23 = bao_show.SP_DRRGT_CAS_EQTO(_IDA)
        class_xml.DT_SHOW.DT23.TableName = "SP_regis"


        Dim lcntype As String = "0" 'dao.fields.lcntpcd

        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID("1400001")
        Try
            lcntype = dao_pro.fields.PROCESS_DESCRIPTION
        Catch ex As Exception

        End Try
        Try
            Dim dt_temp As New DataTable
            dt_temp = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao_lcn.fields.IDA) 'ผู้ดำเนิน

            class_xml.BSN_THAIFULLNAME = dt_temp(0)("BSN_THAIFULLNAME")
        Catch ex As Exception

        End Try

        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao_sub.GetDatabyIDA(_IDA_sub)
        Dim subs_appdate As Date
        Try
            subs_appdate = dao_sub.fields.appdate
        Catch ex As Exception

        End Try
        Dim template_id As Integer = 0
        Try
            template_id = dao_sub.fields.TEMPLATE_ID
        Catch ex As Exception
            template_id = 0
        End Try
        Dim E_VALUE As String = ""
        Dim dao_drgtpcd As New DAO_DRUG.ClsDBdrdrgtype
        Try
            dao_drgtpcd.GetDataby_drgtpcd(dao_e.fields.drgtpcd)
            E_VALUE = dao_drgtpcd.fields.engdrgtpnm

        Catch ex As Exception

        End Try

        Dim NAME_TEMPLATE As String = ""

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP("1400001", 8, HiddenField2.Value, 0)

        'Try
        If ddl_template.SelectedValue = "0" Then
                If E_VALUE <> "(E)" Then
                    'dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, ddl_template.SelectedValue, _group:=1)
                    'NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
                    NAME_TEMPLATE = "DATAN_YOR_2_NCIENT_READONLY.pdf"
                Else
                    'If Request.QueryString("status") = "8" Or Request.QueryString("status") = "14" Then
                    NAME_TEMPLATE = "DATAN_YOR_2_NCIENT_READONLY_E.pdf"
                    'Else
                    '    NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
                    'End If
                End If

                'dao_pdftemplate.GetDataby_TEMPLAETE_TABEAN(_process, statusId, 0)
            Else
                dao_pdftemplate.GetDataby_TEMPLAETE_BY_GROUPV2("1400001", "1400001", 8, ddl_template.SelectedValue, _group:=1)
                NAME_TEMPLATE = dao_pdftemplate.fields.PDF_TEMPLATE
            End If

        'Catch ex As Exception

        'End Try


        'End If

        p_dr = class_xml

        '-----------------------------------------------------
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & NAME_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, _YEARS, _TR_ID)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, "1400001", filename, SUBSTITUTE:="1") 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", "1400001", _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม

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
    Private Sub ddl_template_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_template.SelectedIndexChanged
        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao_sub.GetDatabyIDA(Request.QueryString("IDA"))
        dao_sub.fields.TEMPLATE_ID = ddl_template.SelectedValue
        dao_sub.update()
        BindData_PDF_SAI(Request.QueryString("newcode"))
    End Sub

    Private Sub FRM_SUBSTITUTE_TABEAN_PREVIEW_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'BindData_PDF()
    End Sub
End Class
