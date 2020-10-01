Imports Telerik.Web.UI
Public Class FRM_RGT_EDIT_SEARCH
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

            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            Dim stat As String = ""
            Try
                dao_rg.GetDataby_IDA(dao.fields.FK_IDA)
                stat = dao_rg.fields.STATUS_ID

            Catch ex As Exception

            End Try

            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                Dim _process_id As Integer = 0

                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                Try
                    dao_tr.GetDataby_IDA(tr_id)
                    _process_id = dao_tr.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../RGT_EDIT_STAFF/FRM_RGT_EDIT_CONFIRM_STAFF.aspx?IDA=" & IDA & "&TR_ID=" & item("TR_ID").Text & "&Process=" & _process_id & "');", True)
            ElseIf e.CommandName = "edt" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_EDIT.aspx?IDA=" & R_IDA & "&TR_ID=" & dao_rg.fields.TR_ID & "&STATUS_ID=" & stat & "&ida_e=" & IDA & "&e=1'); ", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & R_IDA & "&tr_id=" & tr_id & "&STATUS_ID=" & stat & "&ida_e=" & IDA & "'); ", True)

            ElseIf e.CommandName = "_trid" Then
                'Dim TR_ID As String = ""
                Dim _ProcessID As String = ""
                Dim bao_tran As New BAO_TRANSECTION

                'Try
                '    dao.GetDataby_IDA(item("IDA").Text)
                'Catch ex As Exception

                'End Try
                Try
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                Catch ex As Exception
                    bao_tran.CITIZEN_ID = ""
                End Try
                Try
                    bao_tran.CITIZEN_ID_AUTHORIZE = dao.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception
                    bao_tran.CITIZEN_ID_AUTHORIZE = ""
                End Try
                Try
                    _ProcessID = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                TR_ID = bao_tran.insert_transection_new(_ProcessID)
                dao.fields.TR_ID = TR_ID
                dao.update()
                RadGrid1.Rebind()
            End If
        End If
    End Sub

    'Vw_DRRGT_EDIT_REQUEST_SEARCH

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub
    Sub Search_FN()
        Dim pvncd As Integer = 0
        Try
            pvncd = _CLS.PVCODE

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select * from dbo.Vw_DRRGT_EDIT_REQUEST_SEARCH "
        Dim str_where As String = ""
        Dim dt2 As New DataTable

        If txt_CITIZEN_AUTHORIZE.Text = "" And txt_rcv_no.Text = "" And txt_drugname.Text = "" Then
            command &= str_where
        Else
            If txt_CITIZEN_AUTHORIZE.Text <> "" Then
                str_where = "where CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
                If txt_rcv_no.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and RCVNO_MANUAL like '%" & txt_rcv_no.Text & "%'"
                    Else
                        str_where &= " RCVNO_MANUAL like '%" & txt_rcv_no.Text & "%'"
                    End If

                End If
                If txt_drugname.Text <> "" Then
                    If str_where <> "" Then
                        str_where &= " and DRG_NAME like '%" & txt_drugname.Text & "%'"
                    Else
                        str_where &= " DRG_NAME like '%" & txt_drugname.Text & "%'"
                    End If
                End If

                command &= str_where
            Else
                If str_where = "" Then

                    If txt_rcv_no.Text <> "" Then
                        str_where &= " where RCVNO_MANUAL like '%" & txt_rcv_no.Text & "%'"
                    End If

                    If txt_drugname.Text <> "" Then
                        If str_where <> "" Then
                            str_where &= " and DRG_NAME like '%" & txt_drugname.Text & "%'"
                        Else
                            str_where &= " where DRG_NAME like '%" & txt_drugname.Text & "%'"
                        End If

                    End If

                    command &= str_where
                Else
                    If txt_rcv_no.Text <> "" Then
                        str_where = "and RCVNO_MANUAL like '%" & txt_rcv_no.Text & "%'"

                    End If
                    If txt_drugname.Text <> "" Then
                        If str_where <> "" Then
                            str_where &= " and DRG_NAME like '%" & txt_drugname.Text & "%'"
                        End If
                    End If

                    command &= str_where
                End If

            End If

        End If

        dt = bao_aa.Queryds(command)
        RadGrid1.DataSource = dt

    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_trid As LinkButton = DirectCast(item("btn_trid").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            dao.GetDatabyIDA(IDA)
            btn_trid.Style.Add("display", "none")
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If tr_id = 0 Then
                btn_trid.Style.Add("display", "block")
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        If txt_CITIZEN_AUTHORIZE.Text <> "" Or txt_rcv_no.Text <> "" Or txt_drugname.Text <> "" Then
            Search_FN()
        End If
    End Sub
End Class