Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI

Public Class TABEAN_YA_MAIN_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _NYM As String = ""
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    'Private _process As String = ""
    Sub runQuery()
        _NYM = Request.QueryString("type")
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
        '_process = Request.QueryString("process")
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
        RunSession()
        runQuery()
        load_lcnno()
        set_name()
        If Not IsPostBack Then
            load_GV_Tabean()
            load_GV_Drug_EX()
        End If
        ' btn_upload_t.Attributes.Add("onclick", "return  Popups2('../DR/POPUP_DR_UPLOAD.aspx?IDA=" & _IDA & "&process=" & _process & "');")
        ' btn_upload_ex.Attributes.Add("onclick", "return  Popups2('../DS/POPUP_DS_UPLOAD.aspx?IDA=" & _IDA & "&process=" & _process & "');")
    End Sub
    Sub load_lcnno()
        'lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Private Sub set_name()
        'Dim dao As New DAO_DRUG.ClsDBdrrgt
        'dao.GetDataby_FK_IDA(_IDA)

        'Try
        '    lb_th_name.Text = dao.fields.thadrgnm
        'Catch ex As Exception

        'End Try
        'Try
        '    lb_eng_name.Text = dao.fields.engdrgnm
        'Catch ex As Exception

        'End Try

        'Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        'Try
        '    dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, _process)
        'Catch ex As Exception

        'End Try
        'Try
        '    lb_stat.Text = dao_stat.fields.STATUS_NAME
        'Catch ex As Exception
        '    lb_stat.Text = "-"
        'End Try

    End Sub


    Sub load_GV_Tabean()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao_DB.SP_DRRGT_TABEAN_STAFF()
        Try
            'GV_Tabean.DataSource = bao_DB.dt
        Catch ex As Exception

        End Try

        'GV_Tabean.DataBind()
    End Sub
    Sub load_GV_Drug_EX()
        Dim bao As New BAO.ClsDBSqlcommand
        'ยาตัวอย่าง
        bao.SP_DRSAMP_STAFF()
        GV_Drug_EX.DataSource = bao.dt
        GV_Drug_EX.DataBind()
    End Sub

    'Private Sub GV_Tabean_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_Tabean.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_Tabean.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBdrsamp

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try
    '        lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_DR_CONFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
    '    ElseIf e.CommandName = "_edit" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As String= 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try
    '        lbl_titlename.Text = "แก้ไขการเสนอลงนาม"
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_TABEAN_YA_STAFF_CONSIDER_UPDATE.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
    '    End If
    'End Sub

    'Private Sub GV_Tabean_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_Tabean.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
    '        Dim index As Integer = e.Row.RowIndex
    '        Dim str_ID As String = GV_Tabean.DataKeys.Item(index).Value.ToString()
    '        Dim stat As String = e.Row.Cells(0).Text 'GV_data.Rows(index).Cells(0).Text
    '    End If
    'End Sub
    Private Sub GV_Drug_EX_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_Drug_EX.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_Drug_EX.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_DS_CONFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

        End If
    End Sub

    'Private Sub Bind_PDF_EX(ByVal PDF_TEMPLATE As String)
    '    Dim bao_app As New BAO.AppSettings
    '    bao_app.RunAppSettings()

    '    Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
    '    Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
    '    Dim down_ID As Integer



    '    Dim STATUS As String = 0
    '    Dim DOWNLOAD_DATE As Date = Date.Now()
    '    dao_down.fields.PROCESS_ID = _process
    '    dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
    '    dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
    '    dao_down.fields.STATUS = STATUS
    '    dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
    '    dao_down.insert()
    '    down_ID = dao_down.fields.ID
    '    dao_up.fields.DOWNLOAD_ID = down_ID
    '    dao_up.insert()

    '    'Dim dao As New DAO.clsDBfafdtype
    '    'dao.Getdata_by_fdtypecd(_CLS.FDTYPECD)

    '    '    _CLS.FATYPE = FATYPE

    '    Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)



    '    Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
    '    Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID) 'test
    '    ' Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & "DA-3227.xml" 'test

    '    convert_Database_To_XML_EX("DA-" & down_ID.ToString())
    '    convert_XML_To_PDF(file_PDF, file_xml, file_template)

    '    _CLS.FILENAME_PDF = file_PDF
    '    _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
    '    Session("CLS") = _CLS
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    'End Sub
    'Private Sub convert_Database_To_XML_EX(ByVal filename As String)

    '    Dim dao As New DAO_DRUG.ClsDBdalcn
    '    dao.GetDataby_IDA(_IDA)

    '    Dim cls As New CLASS_GEN_XML.DS(_CLS.CITIZEN_ID, dao.fields.lcnsid, dao.fields.lcnno, "1", dao.fields.pvncd)
    '    Dim cls_xml As New CLASS_DS
    '    cls_xml = cls.gen_xml()

    '    Dim bao_app As New BAO.AppSettings
    '    bao_app.RunAppSettings()

    '    Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
    '    path = path & filename.ToString() & ".xml"
    '    Dim objStreamWriter As New StreamWriter(path)
    '    Dim x As New XmlSerializer(cls_xml.GetType)
    '    x.Serialize(objStreamWriter, cls_xml)
    '    objStreamWriter.Close()

    'End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim _process_id As String = 0
            Dim tr_id As String= 0
            If item("STATUS_ID").Text <> "8" Then
                Dim dao As New DAO_DRUG.ClsDBdrrqt
                dao.GetDataby_IDA(IDA)
                Try
                    tr_id = dao.fields.TR_ID
                    _process_id = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try
            Else
                Dim dao As New DAO_DRUG.ClsDBdrrgt
                dao.GetDataby_IDA(IDA)
                Try
                    tr_id = dao.fields.TR_ID
                    _process_id = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try
            End If



            If e.CommandName = "sel" Then


                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                Try
                    dao_tr.GetDataby_IDA(tr_id)
                    '_process_id = dao_tr.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                'Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                'dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_DR_CONFIRM_STAFF.aspx?IDA=" & IDA & "&TR_ID=" & item("TR_ID").Text & "&process=" & _process_id & "&STATUS_ID=" & item("STATUS_ID").Text & "&status=" & item("STATUS_ID").Text & "');", True)
            ElseIf e.CommandName = "add" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & IDA & "&tr_id=" & tr_id & "&STATUS_ID=" & item("STATUS_ID").Text & "&type=rq'); ", True)
            ElseIf e.CommandName = "report" Then
                lbl_titlename.Text = "แบบฟอร์มทะเบียน"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/FRM_REPORT_TABEAN.aspx?IDA=" & IDA & "&TR_ID=" & item("TR_ID").Text & "&STATUS_ID=" & item("STATUS_ID").Text & "&status=" & item("STATUS_ID").Text & "');", True)
            ElseIf e.CommandName = "_report" Then
                Dim url As String = ""
                url = "../TABEAN_YA_STAFF/FRM_APPOINTMENT.aspx?IDA=" & IDA & "&STATUS_ID=" & item("STATUS_ID").Text & "&status=" & item("STATUS_ID").Text
                'RunSession()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "'); ", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
            ElseIf e.CommandName = "report2" Then
                Dim id_r As String = item("IDA").Text
                Dim url2 As String = "../E_TRACKING/FRM_RQT_ALL_STOPTIME.aspx?id_r=" & id_r & "&type=1"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url2 & "');", True)
            ElseIf e.CommandName = "_assign" Then
                If item("STATUS_ID").Text <> "8" Then
                    Dim dao As New DAO_DRUG.ClsDBdrrqt
                    dao.GetDataby_IDA(IDA)
                    Try
                        tr_id = dao.fields.TR_ID
                        _process_id = dao.fields.PROCESS_ID
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../ASSIGN/POPUP_ASSIGN_STAFF.aspx?IDA=" & IDA & "&process=" & dao.fields.PROCESS_ID & "&group=2" & "');", True)
                    Catch ex As Exception

                    End Try
                End If

            End If
        
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim _process_id As Integer = 0
            Dim IDA As String = item("IDA").Text
            'Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
            Dim btn_add As LinkButton = DirectCast(item("btn_add").Controls(0), LinkButton)
            Dim btn_report As LinkButton = DirectCast(item("btn_report2").Controls(0), LinkButton)
            Dim btn_assign As LinkButton = DirectCast(item("btn_assign").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            Dim tr_id As String= 0
            dao.GetDataby_IDA(IDA)
            btn_assign.Style.Add("display", "none")
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            'btn_edit.Style.Add("display", "none")
            Try
                'If dao.fields.STATUS_ID = 6 Then
                '    btn_edit.Style.Add("display", "block")
                'End If
            Catch ex As Exception

            End Try

            Try
                If dao.fields.STATUS_ID >= 3 Then
                    btn_report.Style.Add("display", "block")
                Else
                    btn_report.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
            Try
                If dao.fields.STATUS_ID = 8 Then
                    btn_add.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
            Try
                Dim dao_as As New DAO_DRUG.TB_STAFF_ASSIGNING_WORK
                dao_as.GetDataby_FK_IDA_Process(IDA, dao.fields.PROCESS_ID)
                If dao_as.fields.IDA <> 0 Then
                    btn_assign.Style.Add("display", "none")
                Else
                    btn_assign.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Try
                dao_tr.GetDataby_IDA(tr_id)
                '_process_id = dao_tr.fields.PROCESS_ID
            Catch ex As Exception

            End Try
            'lbl_titlename.Text = "แก้ไขการเสนอลงนาม"
            ''        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_TABEAN_YA_STAFF_CONSIDER_UPDATE.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
            'Dim url As String = "../TABEAN_YA_STAFF/POPUP_TABEAN_YA_STAFF_CONSIDER_UPDATE.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & _process_id '"../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            'btn_edit.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        Try
            bao_DB.SP_DRRGT_TABEAN_STAFF()
            dt = bao_DB.dt
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            RadGrid1.DataSource = dt
        End If
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_Tabean()
        RadGrid1.Rebind()
    End Sub
End Class