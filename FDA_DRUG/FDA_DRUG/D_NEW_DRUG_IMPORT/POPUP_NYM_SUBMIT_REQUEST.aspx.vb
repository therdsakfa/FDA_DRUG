Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_NYM_SUBMIT_REQUEST
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _DL As String
    Private _YEARS As String
    Private b64 As String
    Sub RunQuery()
        Try
            _process = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _DL = Request.QueryString("DL")
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
            ' UC_GRID_PHARMACIST.load_gv(_IDA)
            'UC_GRID_ATTACH.load_gv(_TR_ID)
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        dao.GetDataby_IDA(ID)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Private Function chk_pha() As Boolean
        Dim chk As Boolean = True
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_FK_IDA(_IDA)
        For Each row In dao.datas
            If row.PHR_STATUS_UPLOAD = "1" Then
                chk = False
            End If
        Next
        Return chk
    End Function
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click        ' ปรับสภาณะ
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim bao As New BAO.ClsDBSqlcommand
        If _process = "1027" Then                                   'เช็ค Status เป็น nym อะไร และการกดปุ่มในแต่ละอันจะอัพเดท ststus_id ใน base TB_FDA_DRUG_IMPORT_NYM_ ของ NYM นั้นๆ
            dao2.GetDataby_IDA(Integer.Parse(_IDA))
            If Request.QueryString("staff") <> "" Then
                dao2.fields.STATUS_ID = 2                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 
            Else
                dao2.fields.STATUS_ID = 0                        'ถ้าเป็นอันนี้คือผู้ประกอบการยื่นเอง
            End If
            dao2.update()
        ElseIf _process = "1028" Then
            dao3.GetDataby_IDA(Integer.Parse(_IDA))
            If Request.QueryString("staff") <> "" Then
                dao3.fields.STATUS_ID = 2                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 
            Else
                dao3.fields.STATUS_ID = 0                        'ถ้าเป็นอันนี้คือผู้ประกอบการยื่นเอง
            End If
            dao3.update()
        ElseIf _process = "1029" Then
            dao4.GetDataby_IDA(Integer.Parse(_IDA))
            If Request.QueryString("staff") <> "" Then
                dao4.fields.STATUS_ID = 2                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 
            Else
                dao4.fields.STATUS_ID = 0                        'ถ้าเป็นอันนี้คือผู้ประกอบการยื่นเอง
            End If
            dao4.update()
        End If

        'If b64 = Nothing Then                                   'b64 มีไว้ทำไร
        '    b64 = Session("b64")
        'End If
        Dim years As String = ""
        ' Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_tr.GetDataby_IDA(dao.fields.TR_ID)
        'Try
        'years = dao_tr.fields.YEAR
        'Catch ex As Exception
        'End Try

        '  Dim tr_id As String = ""
        ' tr_id = "DA-" & _Process & "-" & years & "-" & _TR_ID

        ' Dim cls_sop As New CLS_SOP
        ' cls_sop.BLOCK_SOP(_CLS.CITIZEN_ID, _Process, "2", "ยื่นคำขอ", tr_id, b64)
        'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "USER", _Process, _CLS.PVCODE, 2, "ส่งเรื่องและรอพิจารณา", "SOP-DRUG-10-" & _Process & "+1", "รับคำขอ", "รอเจ้าหน้าที่รับคำขอ", "STAFF", tr_id, SOP_STATUS:="ยื่นคำขอ")

        AddLogStatus(2, _Process, _CLS.CITIZEN_ID, _IDA)            'LOG STATUS เก็บการ log ไว้ แล้วอัพเข้า base นี้ 

        'Session("b64") = Nothing
        alert("ยื่นเรื่องเรียบร้อยแล้ว")

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        dao.update()
        AddLogStatus(7, _Process, _CLS.CITIZEN_ID, _IDA)
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    End Sub

    '    ''' <summary>
    '    '''  ดึงค่า XML มาแสดง
    '    ''' </summary>
    '    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_NYM_2
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
    End Sub
    Function get_p2(ByVal FileName As String) As CLASS_NYM_2
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_IMPORT & FileName & ".xml") '"C:\path\XML_IMPORT\"
        Dim p2 As New CLASS_NYM_2
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

        Dim dao_up As New DAO_DRUG_IMPORT.ClsDBDRUG_IMPORT_UPLOAD
        dao_up.GetDataby_IDA(_IDA)
        ' Dim dao As New DAO_DRUG_IMPORT
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4

        dao2.getdata_dl(_IDA)
        dao3.getdata_dl(_IDA)
        dao4.getdata_dl(_IDA)
        Dim class_xml2 As New CLASS_NYM_2
        Dim class_xml3 As New CLASS_NYM_3_SM
        Dim class_xml4 As New CLASS_NYM_4_SM


        ' class_xml = cls_dalcn.gen_xml()
        class_xml2.NYM_2s = dao2.fields
        class_xml3.NYM_3s = dao3.fields
        class_xml4.NYM_4s = dao4.fields

        p_nym2 = class_xml2
        Dim p_noryormor2 As New CLASS_NYM_2
        p_noryormor2 = p_nym2
        'p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_noryormor2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_noryormor2)

        Dim bao_show As New BAO_SHOW
        class_xml2.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2(_IDA)
        class_xml3.DT_SHOW.DT25 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM3(_IDA)
        class_xml4.DT_SHOW.DT27 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4(_IDA)
        Dim dao_nym As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        dao_nym.getdata_dl(_DL)
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim paths As String = bao._PATH_XML_TRADER
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, 1, 0)
        Dim year As String = Date.Now.Year
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym.fields.TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _Process, year, dao_nym.fields.TR_ID)
        'load_PDF(filename)
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่


        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym.fields.TR_ID)
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