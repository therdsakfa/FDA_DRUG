Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class FRM_EDIT_LCN_CONFIRM
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private b64 As String
    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'If Session("b64") IsNot Nothing Then
        '    b64 = Session("b64")
        'End If
        If Not IsPostBack Then
            BindData_PDF()
            show_btn(_IDA)
            UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv(_TR_ID)
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub

    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
            'ElseIf chk_pha() = True Then 'true คือเภสัชไม่ยืนยัน ,False คือเภสัชยืนยัน
            '    btn_confirm.Enabled = False
            '    btn_cancel.Enabled = False
            '    btn_confirm.CssClass = "btn-danger btn-lg"
            '    btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        Dim bao As New BAO.ClsDBSqlcommand
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 2

        dao.update()

        'If b64 = Nothing Then
        '    b64 = Session("b64")
        'End If
        Dim years As String = ""
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        'Try
        '    years = dao_tr.fields.YEAR

        'Catch ex As Exception

        'End Try
        'Dim tr_id As String = ""
        'tr_id = "DA-" & _ProcessID & "-" & years & "-" & _TR_ID

        'Dim cls_sop As New CLS_SOP
        'cls_sop.BLOCK_SOP(_CLS.CITIZEN_ID, _ProcessID, "2", "ยื่นคำขอ", tr_id, b64)
        'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "USER", _ProcessID, _CLS.PVCODE, 2, "ส่งเรื่องและรอพิจารณา", "SOP-DRUG-10-" & _ProcessID & "-1", "รับคำขอ", "รอเจ้าหน้าที่รับคำขอ", "STAFF", tr_id, SOP_STATUS:="ยื่นคำขอ")

        'AddLogStatus(2, _ProcessID, _CLS.CITIZEN_ID, _IDA)

        'Session("b64") = Nothing
        alert("ยื่นเรื่องเรียบร้อยแล้ว")

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        dao.update()
        AddLogStatus(7, _ProcessID, _CLS.CITIZEN_ID, _IDA)
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    End Sub

    ''' <summary>
    '''  ดึงค่า XML มาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG.ClsDBdalcn
    End Sub
    Function get_p2(ByVal FileName As String) As CLASS_DALCN_EDIT_REQUEST
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_DALCN_EDIT_REQUEST
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Function
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub


    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings

        Dim dao As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
        dao.GetDataby_IDA(_IDA)
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.GetDataby_IDA(dao.fields.TR_ID)
        Dim cls_dalcn_edt As New CLASS_GEN_XML.DALCN_EDIT_REQUEST(_CLS.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID, "1", "10")
        Dim lct_ida As Integer = 0 '101680

        Dim Cls_XML As New CLASS_DALCN_EDIT_REQUEST
        ' class_xml = cls_dalcn.gen_xml()
        Cls_XML.DALCN_EDIT_REQUESTs = dao.fields


        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Try
            dao_main.GetDataby_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Dim bao_show As New BAO_SHOW

        Try
            lct_ida = dao_main.fields.FK_IDA
        Catch ex As Exception

        End Try

        Dim dt_lo As New DataTable
        Dim dt_keep As New DataTable

        Try
            dt_lo = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.NEW_LO_IDA)
        Catch ex As Exception

        End Try
        Try
            dt_keep = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.NEW_KEEP_IDA)
        Catch ex As Exception

        End Try

        For Each dr As DataRow In dt_lo.Rows
            Try
                Cls_XML.LO_ADDR = dr("fulladdr3")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.LO_NAME = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.LO_TEL = dr("tel")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.LO_HOUSENO = dr("HOUSENO")
            Catch ex As Exception

            End Try
        Next
        For Each dr As DataRow In dt_keep.Rows
            Try
                Cls_XML.KEEP_ADDR = dr("fulladdr3")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.KEEP_NAME = dr("thanameplace")
            Catch ex As Exception

            End Try
            Try
                Cls_XML.KEEP_TEL = dr("tel")
            Catch ex As Exception

            End Try
        Next


        Cls_XML.DT_SHOW.DT9 = BAO_SHOW.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(lct_ida) 'ข้อมูลสถานที่จำลอง

        Cls_XML.DT_SHOW.DT11 = BAO_SHOW.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(1, dao.fields.CITIZEN_ID_AUTHORIZE) 'ข้อมูลที่ตั้งหลัก
        Cls_XML.DT_SHOW.DT11.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_5"
        Cls_XML.DT_SHOW.DT12 = BAO_SHOW.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, _CLS.LCNSID) 'ข้อมูลบริษัท
        Cls_XML.DT_SHOW.DT13 = BAO_SHOW.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, dao.fields.CITIZEN_ID_AUTHORIZE) 'ที่เก็บ
        If Cls_XML.DT_SHOW.DT13.Rows.Count = 0 Then

        End If
        Cls_XML.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        'If txt_bsn.Text <> "" Then
        '    ws2.insert_taxno(txt_bsn.Text)
        'End If




        Dim lcnno_auto As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnno_format As String = ""
        Dim rcvno_format As String = ""
        'Dim MAIN_LCN_IDA As Integer = 61332

        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            rcvno_auto = dao.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            If dao_main.fields.lcntpcd.Contains("4") And dao_main.fields.lcntpcd.Contains("ขย4") = False Then
                Cls_XML.LCN_TYPE = "1"
            ElseIf dao_main.fields.lcntpcd.Contains("3") And dao_main.fields.lcntpcd.Contains("ขย3") = False Then
                Cls_XML.LCN_TYPE = "2"
            End If

        Catch ex As Exception

        End Try

        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                lcnno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/25" & Left(rcvno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        'If MAIN_LCN_IDA <> 0 Then
        '    Dim dao_main2 As New DAO_DRUG.ClsDBdalcn
        '    dao_main2.GetDataby_IDA(61332)

        '    Try
        '        'lcnno_format = 
        '        cls_xml.HEAD_LCNNO = CStr(CInt(Right(dao_main2.fields.lcnno, 5))) & "/25" & Left(dao_main2.fields.lcnno, 2)
        '    Catch ex As Exception

        '    End Try

        'End If
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao_bsn.GetDataby_LCN_IDA(dao_main.fields.IDA)
        Catch ex As Exception

        End Try

        Dim bao_cpn As New BAO.ClsDBSqlcommand
        Cls_XML.DT_SHOW.DT14 = BAO_SHOW.SP_LOCATION_BSN_BY_IDENTIFY(dao_bsn.fields.BSN_IDENTIFY) 'ผู้ดำเนิน
        Cls_XML.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"

        'cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_IDENTIFY(txt_bsn.Text) 'ผู้ดำเนิน
        'cls_xml.DT_SHOW.DT14.TableName = "SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA"
        Cls_XML.DT_SHOW.DT15 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_main.fields.CITIZEN_ID_AUTHORIZE)
        Cls_XML.DT_SHOW.DT15.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2"

        Cls_XML.DT_SHOW.DT16 = bao_cpn.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(dao_main.fields.CITIZEN_ID_AUTHORIZE)
        Cls_XML.DT_SHOW.DT16.TableName = "SP_BSN_LOCATION_ADDRESS_BY_IDEN_BSN_ADDR"

        Dim bao_master As New BAO_MASTER
        Cls_XML.DT_SHOW.DT10 = bao_master.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(dao_main.fields.IDA)

        Dim _lcn_ida As Integer
        ' If Integer.TryParse(_lcn_ida) = True Then
        Cls_XML.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(dao_main.fields.IDA)
        ' End If

        Try
            Cls_XML.BSN_IDENTIFY = dao_bsn.fields.BSN_IDENTIFY
        Catch ex As Exception

        End Try
        Try
            Cls_XML.RCVDATE_DISPLAY = CDate(dao.fields.rcvdate).ToShortDateString()
        Catch ex As Exception

        End Try

        Cls_XML.LCNNO_FORMAT = lcnno_format
        Cls_XML.RCVNO_FORMAT = rcvno_format
        Try
            'If dao.fields.BSN_NATIONALITY_CD = 1 Then
            'cls_xml.dalcns.NATION = "ไทย"
            'End If
        Catch ex As Exception

        End Try
        p_dalcn_rqt = Cls_XML


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_TABEAN(_ProcessID, 0, 0)
        Dim YEAR As String = dao_up.fields.YEAR

        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, Year, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, Year, _TR_ID)
        'load_PDF(filename)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, Year, _TR_ID)
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม
    End Sub
    Private Sub load_pdf(ByVal FilePath As String)


        '  Response.ContentType = "Application/pdf"

        Dim clsds As New ClassDataset

        Dim bb As Byte() = clsds.UpLoadImageByte(FilePath)

        Dim ws_F As New WS_FLATTEN.WS_FLATTEN

        Dim b_o As Byte() = ws_F.FlattenPDF_DIGITAL(bb)

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", b_o.Length.ToString())
        Response.BinaryWrite(b_o)



        'Response.Clear()
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment;filename=abc.pdf")

        'Response.BinaryWrite(clsds.UpLoadImageByte(FilePath))

        'Response.Flush()

        Response.End()
    End Sub


    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function
    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class