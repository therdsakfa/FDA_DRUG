Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER
Public Class FRM_SUBSTITUTE_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        _YEARS = con_year(Date.Now.Year)
        Try
            _ProcessID = Request.QueryString("Process")

        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")

        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")

        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            BindData_PDF()
            'bind_ddl_rqt()
            show_btn(_IDA)
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)
        End If
    End Sub

    Function load_STATUS()
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(IDA)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If


    End Sub
    'Sub bind_ddl_rqt()
    '    'Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
    '    'dao.GetData_TABEAN_Only()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    dt = bao.SP_TYPE_REQUESTS_EDIT()
    '    ddl_req_type.DataSource = dt
    '    ddl_req_type.DataTextField = "TYPE_REQUESTS_NAME"
    '    ddl_req_type.DataValueField = "TYPE_REQUESTS_ID"
    '    ddl_req_type.DataBind()
    'End Sub
    Function run_rcvno() As Integer
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        Dim bao As New BAO.ClsDBSqlcommand
        dao.GetDatabyIDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 2
        Try
            'dao.fields.TYPE_REQUESTS_ID = ddl_req_type.SelectedValue
        Catch ex As Exception

        End Try

        dao.update()
        AddLogStatus(2, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        alert("ยื่นคำขอแล้ว")

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        dao.GetDatabyIDA(Integer.Parse(_IDA))
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
        Dim p2 As New CLASS_EDIT_DRRGT
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Sub
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
        RunQuery()
        Dim bao_show As New BAO_SHOW
        Dim bao_mas As New BAO_MASTER
        Dim cls As New CLASS_GEN_XML.DRRGT_SUB(_CLS.CITIZEN_ID, _CLS.LCNSID, "1", _CLS.PVCODE) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DRRGT_SUB                                                                 ' ประกาศตัวแปรจาก CLASS_DALCN 
        'cls_xml = cls.gen_xml()



        Dim dao_sub As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
        Try
            dao_sub.GetDatabyIDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        dao_drrgt.GetDataby_IDA(dao_sub.fields.FK_IDA)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(dao_sub.fields.FK_LCN_IDA)
        Catch ex As Exception

        End Try
        Dim rcvno_format As String = ""
        Dim LCN_TYPE As String = ""
        Dim LCNNO_FORMAT As String = ""
        Dim TABEAN_FORMAT As String = ""
        Dim LCNTPCD_GROUP As String = ""
        Dim drug_name As String = ""
        Dim rgtno_format As String = ""
        Dim rgtno_auto As String = ""
        Dim rgttpcd As String = ""
        Dim rgtno As String = ""
        Dim pvnabbr As String = ""
        Dim rcvno As String = ""
        Dim rcvno_auto As String = ""
        Dim lcnno As String = ""
        Dim lcnsid As String = ""
        Try
            rcvno_auto = dao_sub.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            rgttpcd = dao_drrgt.fields.rgttpcd
        Catch ex As Exception

        End Try
        Try
            rcvno = dao_sub.fields.rcvno
        Catch ex As Exception

        End Try
        Try
            lcnno = dao_drrgt.fields.lcnno
        Catch ex As Exception

        End Try
        Try
            lcnsid = dao_drrgt.fields.lcnsid
        Catch ex As Exception

        End Try
        Try
            rgtno = dao_drrgt.fields.rgtno
        Catch ex As Exception

        End Try
        Try
            rgtno_auto = rgtno
        Catch ex As Exception

        End Try
        Try
            pvnabbr = dao_drrgt.fields.pvnabbr
        Catch ex As Exception

        End Try
        Try
            drug_name = dao_drrgt.fields.thadrgnm & " / " & dao_drrgt.fields.engdrgnm
        Catch ex As Exception

        End Try
        Try
            If dao_drrgt.fields.lcntpcd.Contains("ผยบ") Or dao_drrgt.fields.lcntpcd.Contains("นยบ") Then
                LCN_TYPE = "2"
            Else
                LCN_TYPE = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If dao_drrgt.fields.lcntpcd.Contains("ผย") Then
                LCNTPCD_GROUP = "2"
            Else
                LCNTPCD_GROUP = "1"
            End If
        Catch ex As Exception

        End Try
        Try
            If Len(rcvno_auto) > 0 Then
                If rcvno_auto <> "0" Then
                    rcvno_format = CStr(CInt(Right(rcvno_auto, 5))) & "/" & Left(rcvno_auto, 2) 'rgttpcd & " " &
                End If

            End If
        Catch ex As Exception

        End Try
        Try
            LCNNO_FORMAT = dao.fields.lcntpcd & " " & CStr(CInt(Right(dao.fields.lcnno, 5))) & "/" & Left(dao.fields.lcnno, 2)
        Catch ex As Exception

        End Try
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = pvnabbr & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/25" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Try
            If dao.fields.lcntpcd.Contains("ผยบ") Or dao.fields.lcntpcd.Contains("นยบ") Then
                cls_xml.TABEAN_TYPE1 = "2"
                'cls_xml.TABEAN_TYPE2 = "2"
            Else
                cls_xml.TABEAN_TYPE1 = "1"
                'cls_xml.TABEAN_TYPE2 = "0"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dao_dg As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
            dao_dg.GetDataby_rgttpcd(dao_drrgt.fields.rgttpcd)
            cls_xml.CHK_LCN_SUBTYPE = dao_dg.fields.subtpcd
        Catch ex As Exception

        End Try
        cls_xml.LCNNO_FORMAT = LCNNO_FORMAT
        cls_xml.RCVNO_FORMAT = rcvno_format
        cls_xml.RGTNO_FORMAT = rgtno_format



        cls_xml.DRUG_NAME = drug_name        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml

        '------------------SHOW
        'cls_xml ให้เท่ากับ Class ของ cls.gen_xml
        If Request.QueryString("identify") <> "" Then
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(Request.QueryString("identify"), _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        Else
            cls_xml.DT_SHOW.DT17 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_sub.fields.IDENTIFY, _CLS.LCNSID_CUSTOMER) 'ข้อมูลบริษัท
        End If
        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LCN_IDA(dao.fields.IDA) 'ผู้ดำเนิน
        Catch ex As Exception

        End Try
        cls_xml.DRRGT_SUBSTITUTEs = dao_sub.fields
        p_DRRGT_SUBSTITUTE = cls_xml

        Dim statusId As Integer = dao_sub.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd

        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)
        dao_pdftemplate.GetDataby_TEMPLAETE_TABEAN(_ProcessID, statusId, 0)
        Dim paths As String = bao._PATH_DEFAULT
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim filename As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PATH_PDF_TEMPLATE = PDF_TEMPLATE
        _CLS.PATH_XML = Path_XML

        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _ProcessID, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>"
        hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่
        HiddenField1.Value = filename
        _CLS.FILENAME_PDF = NAME_PDF("DA", _ProcessID, _YEARS, _TR_ID)
        _CLS.PDFNAME = filename
        _CLS.FILENAME_XML = NAME_XML("DA", _ProcessID, _YEARS, _TR_ID)
    End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class