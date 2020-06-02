Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI
Public Class UC_DRUG_DOCUMENT_UPLOAD
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _FK_IDA As String = ""
    Private _process As String = ""
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _main_ida As String = ""
    Private _staff As String = ""
    Dim STATUS_ID As String
    Sub runQuery()
        _IDA = Request.QueryString("IDA") 'IDA ของ REGIST
        _process = Request.QueryString("process")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _staff = Request.QueryString("staff")
        _main_ida = Request.QueryString("main_ida")
        Try
            STATUS_ID = Request.QueryString("STATUS_ID")
        Catch ex As Exception

        End Try
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
    End Sub

    Protected Sub btn_download_t_Click(sender As Object, e As EventArgs) Handles btn_download_t.Click
        Bind_PDF_SPC()
    End Sub
    Private Sub Bind_PDF_SPC()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim Process As String = "1400091"
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = Process 'SPC
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE(Process, Process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML_SPC(file_xml, Process)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML_SPC(ByVal path As String, ByVal Process_id As Integer)

        Dim cls As New CLASS_GEN_XML.DRRGT_SPC_GEN()
        Dim cls_xml As New CLASS_DRRGT_SPC

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim rgtno_auto As String = ""
        Dim rgtno_format As String = ""
        Dim rgttpcd As String = ""
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_IDA)
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
            dao_rg.GetDataby_IDA(_IDA)
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
        If Request.QueryString("STATUS_ID") = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(_IDA)
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

        cls_xml = cls.gen_xml()

        cls_xml.DRUG_NAME = drug_name
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RGTNO_FORMAT = rgtno_format

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
      
    End Sub

    Protected Sub btn_upload_t_Click(sender As Object, e As EventArgs) Handles btn_upload_t.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/POPUP_UPLOAD_SPC_PI_PIL.aspx?rgt_ida=" & _IDA & "&process=" & "1400091&status=" & Request.QueryString("STATUS_ID") & "');", True)
    End Sub

    Private Sub rg_spc_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_spc.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim rgt_ida As String = ""
            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.TB_DRRGT_SPC
                dao.GetDataby_IDA(IDA)
                Try
                    rgt_ida = dao.fields.FK_IDA
                Catch ex As Exception

                End Try
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/POPUP_CONFIRM_SPC_PI_PIL.aspx?rgt_ida=" & rgt_ida & "&IDA=" & IDA & "&process=" & "1400091&status=" & Request.QueryString("STATUS_ID") & "&TR_ID=" & tr_id & "');", True)
            End If

        End If
    End Sub

    Private Sub rg_spc_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles rg_spc.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_DRRGT_SPC_BY_FK_IDA(_IDA)

        rg_spc.DataSource = dt
    End Sub

 
    Protected Sub btn_upload_PIL_Click(sender As Object, e As EventArgs) Handles btn_upload_PIL.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/POPUP_UPLOAD_SPC_PI_PIL.aspx?rgt_ida=" & _IDA & "&process=" & "1400093&status=" & Request.QueryString("STATUS_ID") & "');", True)
    End Sub

    Private Sub btn_download_PIL_Click(sender As Object, e As EventArgs) Handles btn_download_PIL.Click
        Bind_PDF_PIL()
    End Sub
    Private Sub Bind_PDF_PIL()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim Process As String = "1400093"
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = Process 'SPC
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE(Process, Process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML_PIL(file_xml, Process)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML_PIL(ByVal path As String, ByVal Process_id As Integer)

        Dim cls As New CLASS_GEN_XML.DRRGT_PIL_GEN()
        Dim cls_xml As New CLASS_DRRGT_PIL

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim rgtno_auto As String = ""
        Dim rgtno_format As String = ""
        Dim rgttpcd As String = ""
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_IDA)
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
            dao_rg.GetDataby_IDA(_IDA)
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
        If Request.QueryString("STATUS_ID") = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(_IDA)
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

        cls_xml = cls.gen_xml()

        cls_xml.DRUG_NAME = drug_name
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RGTNO_FORMAT = rgtno_format

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub

    Private Sub btn_download_PI_Click(sender As Object, e As EventArgs) Handles btn_download_PI.Click
        Bind_PDF_PI()
    End Sub
    Private Sub Bind_PDF_PI()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim Process As String = "1400092"
        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer

        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = Process 'SPC
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID

        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        Dim dao_TEMPLATE As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_TEMPLATE.GetDataby_TEMPLAETE(Process, Process, 0, 0)
        Dim paths As String = _PATH_DEFALUT
        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & dao_TEMPLATE.fields.PDF_TEMPLATE                                 'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_xml As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.XML_PATH & "\" & NAME_DOWNLOAD_XML("DA", down_ID)      'เพื่อเก็บไฟล์ TEMPLATE PATH XML
        Dim file_PDF As String = bao_app._PATH_DEFAULT & dao_TEMPLATE.fields.PDF_OUTPUT & "\" & NAME_DOWNLOAD_PDF("DA", down_ID)    'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML_PI(file_xml, Process)                                                                                           ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                                       ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML_PI(ByVal path As String, ByVal Process_id As Integer)

        Dim cls As New CLASS_GEN_XML.DRRGT_PI_GEN()
        Dim cls_xml As New CLASS_DRRGT_PI

        Dim dao_main As New DAO_DRUG.ClsDBdalcn
        Dim drug_name As String = ""
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim rgtno_auto As String = ""
        Dim rgtno_format As String = ""
        Dim rgttpcd As String = ""
        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_IDA)
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
            dao_rg.GetDataby_IDA(_IDA)
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
        If Request.QueryString("STATUS_ID") = "8" Then
            Dim dao3 As New DAO_DRUG.ClsDBdrrgt
            dao3.GetDataby_IDA(_IDA)
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

        cls_xml = cls.gen_xml()

        cls_xml.DRUG_NAME = drug_name
        cls_xml.LCNNO_FORMAT = lcnno_format
        cls_xml.RGTNO_FORMAT = rgtno_format

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub

    Private Sub btn_upload_PI_Click(sender As Object, e As EventArgs) Handles btn_upload_PI.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/POPUP_UPLOAD_SPC_PI_PIL.aspx?rgt_ida=" & _IDA & "&process=" & "1400092&status=" & Request.QueryString("STATUS_ID") & "');", True)
    End Sub
    Sub re_fresh_rg()
        rg_spc.Rebind()
        RadGrid1.Rebind()
        RadGrid2.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim rgt_ida As String = ""
           
            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.TB_DRRGT_PIL
                dao.GetDataby_IDA(IDA)
                Try
                    rgt_ida = dao.fields.FK_IDA
                Catch ex As Exception

                End Try
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/POPUP_CONFIRM_SPC_PI_PIL.aspx?rgt_ida=" & rgt_ida & "&IDA=" & _IDA & "&process=" & "1400093&status=" & Request.QueryString("STATUS_ID") & "&TR_ID=" & tr_id & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim rgt_ida As String = ""
            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.TB_DRRGT_PI
                dao.GetDataby_IDA(IDA)
                Try
                    rgt_ida = dao.fields.FK_IDA
                Catch ex As Exception

                End Try
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/POPUP_CONFIRM_SPC_PI_PIL.aspx?rgt_ida=" & rgt_ida & "&IDA=" & _IDA & "&process=" & "1400092&status=" & Request.QueryString("STATUS_ID") & "&TR_ID=" & tr_id & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_DRRGT_PIL_BY_FK_IDA(_IDA)

        rg_spc.DataSource = dt
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_DRRGT_PIL_BY_FK_IDA(_IDA)

        rg_spc.DataSource = dt
    End Sub
End Class