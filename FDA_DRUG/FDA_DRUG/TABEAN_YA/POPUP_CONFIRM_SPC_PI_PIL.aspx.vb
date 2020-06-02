Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_CONFIRM_SPC_PI_PIL
    Inherits System.Web.UI.Page
   Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        'Try
        Try
            _ProcessID = Request.QueryString("process")
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
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        'Catch ex As Exception
        '    
        'End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then

            If _ProcessID = "1400091" Then
                BindData_PDF_SPC()
            ElseIf _ProcessID = "1400092" Then
                BindData_PDF_PI()
            ElseIf _ProcessID = "1400093" Then
                BindData_PDF_PIL()
            End If
            show_btn(_IDA, _ProcessID)
        End If
    End Sub
    Sub show_btn(ByVal IDA As String, ByVal process As String)
        Dim STATUS_ID As String = ""
        If process = "1400091" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_SPC
            dao.GetDataby_IDA(IDA)
            STATUS_ID = dao.fields.STATUS_ID
        ElseIf process = "1400092" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_PI
            dao.GetDataby_IDA(IDA)
            STATUS_ID = dao.fields.STATUS_ID
        ElseIf process = "1400093" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_PIL
            dao.GetDataby_IDA(IDA)
            STATUS_ID = dao.fields.STATUS_ID
        End If
        If STATUS_ID <> "1" Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        If _ProcessID = "1400091" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_SPC
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 2
            dao.update()
        ElseIf _ProcessID = "1400092" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_PI
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 2
            dao.update()
        ElseIf _ProcessID = "1400093" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_PIL
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 2
            dao.update()
        End If
        AddLogStatus(2, _ProcessID, _CLS.CITIZEN_ID, _IDA)
        alert("ยื่นคำขอเรียบร้อยแล้ว")

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        If _ProcessID = "1400091" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_SPC
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 7
            dao.update()
        ElseIf _ProcessID = "1400092" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_PI
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 7
            dao.update()
        ElseIf _ProcessID = "1400093" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_PIL
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 7
            dao.update()
        End If
        AddLogStatus(7, _ProcessID, _CLS.CITIZEN_ID, _IDA)
    End Sub
    Private Sub BindData_PDF_SPC()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao As New DAO_DRUG.TB_DRRGT_SPC
        dao.GetDataby_IDA(_IDA)
        Dim cls_regis As New CLASS_GEN_XML.DRRGT_SPC_GEN()

        Dim class_xml As New CLASS_DRRGT_SPC
        class_xml.DRRGT_SPCs = dao.fields


        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim rgtno_auto As String = ""
        Dim rgtno_format As String = ""
        Dim rgttpcd As String = ""
        Dim STATUS_ID As String = ""
        Try
            STATUS_ID = dao.fields.STATUS_ID_RGT
        Catch ex As Exception

        End Try
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(Request.QueryString("rgt_ida"))
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(Request.QueryString("rgt_ida"))
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        End If

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If


        Dim lcnno_auto As String = ""
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Dim lcnno_format As String = ""
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
            End If
        Catch ex As Exception

        End Try

        Dim aa As String = ""
        If STATUS_ID = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(Request.QueryString("rgt_ida"))
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            Dim dao3 As New DAO_DRUG.ClsDBdrrqt
            dao3.GetDataby_IDA(Request.QueryString("rgt_ida"))
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        'class_xml = cls.gen_xml()

        class_xml.DRUG_NAME = drug_name
        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RGTNO_FORMAT = rgtno_format



        p_SPC = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)
        class_xml = cls_regis.gen_xml()
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
    Private Sub BindData_PDF_PI()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao As New DAO_DRUG.TB_DRRGT_PI
        dao.GetDataby_IDA(_IDA)
        Dim cls_regis As New CLASS_GEN_XML.DRRGT_PI_GEN()

        Dim class_xml As New CLASS_DRRGT_PI
        class_xml.DRRGT_PIs = dao.fields


        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim rgtno_auto As String = ""
        Dim rgtno_format As String = ""
        Dim rgttpcd As String = ""
        Dim STATUS_ID As String = ""
        Try
            STATUS_ID = dao.fields.STATUS_ID_RGT
        Catch ex As Exception

        End Try
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(Request.QueryString("rgt_ida"))
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(Request.QueryString("rgt_ida"))
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        End If

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If


        Dim lcnno_auto As String = ""
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Dim lcnno_format As String = ""
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
            End If
        Catch ex As Exception

        End Try

        Dim aa As String = ""
        If STATUS_ID = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(Request.QueryString("rgt_ida"))
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
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
        End If
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        'class_xml = cls.gen_xml()

        class_xml.DRUG_NAME = drug_name
        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RGTNO_FORMAT = rgtno_format



        p_PI = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)
        class_xml = cls_regis.gen_xml()
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
    Private Sub BindData_PDF_PIL()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim dao As New DAO_DRUG.TB_DRRGT_PIL
        dao.GetDataby_IDA(_IDA)
        Dim cls_regis As New CLASS_GEN_XML.DRRGT_PIL_GEN()

        Dim class_xml As New CLASS_DRRGT_PIL
        class_xml.DRRGT_PILs = dao.fields


        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim rgtno_auto As String = ""
        Dim rgtno_format As String = ""
        Dim rgttpcd As String = ""
        Dim STATUS_ID As String = ""
        Try
            STATUS_ID = dao.fields.STATUS_ID_RGT
        Catch ex As Exception

        End Try
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(Request.QueryString("rgt_ida"))
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(Request.QueryString("rgt_ida"))
            dao_main.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            Try
                drug_name_th = dao_rg.fields.thadrgnm
                'drug_name
            Catch ex As Exception
                drug_name_th = "-"
            End Try
            Try
                drug_name_eng = dao_rg.fields.engdrgnm
            Catch ex As Exception
                drug_name_eng = "-"
            End Try
            Try
                rgtno_auto = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
        End If

        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If


        Dim lcnno_auto As String = ""
        Try
            lcnno_auto = dao_main.fields.lcnno
        Catch ex As Exception

        End Try
        Dim lcnno_format As String = ""
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_main.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
            End If
        Catch ex As Exception

        End Try

        Dim aa As String = ""
        If STATUS_ID = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(Request.QueryString("rgt_ida"))
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            Dim dao3 As New DAO_DRUG.ClsDBdrrqt
            dao3.GetDataby_IDA(Request.QueryString("rgt_ida"))
            Dim daodrgtype As New DAO_DRUG.ClsDBdrdrgtype
            daodrgtype.GetDataby_drgtpcd(dao3.fields.drgtpcd)

            Try
                aa = daodrgtype.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If
        Try
            If Len(rgtno_auto) > 0 Then
                rgtno_format = rgttpcd & " " & CStr(CInt(Right(rgtno_auto, 5))) & "/" & Left(rgtno_auto, 2) & " " & aa
            End If
        Catch ex As Exception

        End Try

        'class_xml = cls.gen_xml()

        class_xml.DRUG_NAME = drug_name
        class_xml.LCNNO_FORMAT = lcnno_format
        class_xml.RGTNO_FORMAT = rgtno_format



        p_PIL = class_xml

        Dim statusId As Integer = dao.fields.STATUS_ID
        Dim lcntype As Integer = 0 'dao.fields.lcntpcd


        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, _ProcessID, statusId, 0)
        class_xml = cls_regis.gen_xml()
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
End Class