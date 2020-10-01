Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI
Public Class FRM_RGT_EDIT_MAIN_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _rgt_ida As String = ""
    Private _type As String
    Private _process_for As String
    Private _pvncd As Integer
    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()
        Try
            _rgt_ida = Request.QueryString("rgt_ida")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
            _type = Request.QueryString("type")
            _process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    
    
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings 'ทำการดาวห์โหลดลงเครื่อง
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Dim R_IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            dao.GetDatabyIDA(IDA)
            Try
                R_IDA = dao.fields.FK_IDA
            Catch ex As Exception

            End Try
            Dim iden As String = ""
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            Dim stat As String = ""
            Try
                dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
                stat = dao_rg.fields.STATUS_ID
                iden = dao_rg.fields.IDENTIFY
            Catch ex As Exception

            End Try

            Dim tr_id As String = 0
            Dim tr_id_rg As String = 0
            Try
                tr_id_rg = dao_rg.fields.TR_ID
            Catch ex As Exception

            End Try
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                Dim _process_id As Integer = 0

                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                Try
                    If Len(tr_id) >= 9 Then
                        dao_tr.GetDataby_TR_ID_Process(tr_id, _process)
                        _process_id = _process
                    Else
                        dao_tr.GetDataby_IDA(tr_id)
                        _process_id = dao_tr.fields.PROCESS_ID
                    End If

                Catch ex As Exception

                End Try

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../RGT_EDIT_STAFF/FRM_RGT_EDIT_CONFIRM_STAFF.aspx?IDA=" & IDA & "&TR_ID=" & item("TR_ID").Text & "&Process=" & dao.fields.PROCESS_ID & "&Newcode=" & item("Newcode").Text & "&citizen_authen=" & iden & "');", True)
            ElseIf e.CommandName = "edt" Then
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_EDIT.aspx?IDA=" & R_IDA & "&TR_ID=" & dao_rg.fields.TR_ID & "&STATUS_ID=" & stat & "&e=1'); ", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_EDIT.aspx?IDA=" & R_IDA & "&TR_ID=" & dao_rg.fields.TR_ID & "&STATUS_ID=" & 8 & "&ida_e=" & IDA & "&e=1'); ", True)

                '
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_EDIT_V2.aspx?IDA=" & R_IDA & "&TR_ID=" & tr_id_rg & "&STATUS_ID=" & 8 & "&ida_e=" & IDA & "&Newcode=" & item("Newcode").Text & "&e=1'); ", True)


                'ElseIf e.CommandName = "add" Then
                '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & IDA & "&tr_id=" & tr_id & "&status=" & item("STATUS_ID").Text & "'); ", True)
            ElseIf e.CommandName = "_report" Then
                Dim url As String = ""
                url = "../TABEAN_YA_STAFF/FRM_APPOINTMENT2.aspx?IDA=" & IDA & "&STATUS_ID=" & item("STATUS_ID").Text & "&status=" & item("STATUS_ID").Text
                'RunSession()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "'); ", True)

            ElseIf e.CommandName = "report" Then
                Dim id_r As String = item("IDA").Text
                Dim url2 As String = "../E_TRACKING/FRM_RQT_ALL_STOPTIME.aspx?id_r=" & id_r & "&type=2"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url2 & "');", True)
            ElseIf e.CommandName = "_trid" Then
                Dim TR_ID1 As String = ""
                Dim _ProcessID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                Dim dao_rge As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                Try
                    dao_rge.GetDatabyIDA(item("IDA").Text)
                Catch ex As Exception

                End Try
                Try
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                Catch ex As Exception
                    bao_tran.CITIZEN_ID = ""
                End Try
                Try
                    bao_tran.CITIZEN_ID_AUTHORIZE = dao_rge.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception
                    bao_tran.CITIZEN_ID_AUTHORIZE = ""
                End Try
                Try
                    _ProcessID = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                TR_ID1 = bao_tran.insert_transection_new("130099")
                dao_rge.fields.TR_ID = TR_ID1
                dao_rge.update()

                'Try
                '    Dim dao_rq As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                '    Try
                '        dao_rq.GetDatabyIDA(IDA)
                '        dao_rq.fields.TR_ID = TR_ID1
                '        dao_rq.update()
                '    Catch ex As Exception

                '    End Try
                'Catch ex As Exception

                'End Try

                RadGrid1.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim _process_id As Integer = 0
            Dim IDA As String = item("IDA").Text

            Dim btn_report As LinkButton = DirectCast(item("btn_report2").Controls(0), LinkButton)
            Dim btn_trid As LinkButton = DirectCast(item("btn_trid").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            Dim tr_id As String= 0
            dao.GetDatabyIDA(IDA)

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
            If tr_id = 0 Then
                btn_trid.Style.Add("display", "block")
            Else
                btn_trid.Style.Add("display", "none")
            End If
            Try
                If dao.fields.STATUS_ID >= 3 Then
                    btn_report.Style.Add("display", "block")
                Else
                    btn_report.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
           
            'lbl_titlename.Text = "แก้ไขการเสนอลงนาม"
            ''        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_TABEAN_YA_STAFF_CONSIDER_UPDATE.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)
            'Dim url As String = "../TABEAN_YA_STAFF/POPUP_TABEAN_YA_STAFF_CONSIDER_UPDATE.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & _process_id '"../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            'btn_edit.Attributes.Add("OnClick", "Popups2('" & url & "'); return false;")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_DRRGT_EDIT_REQUEST_STAFF()
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt
    End Sub
End Class