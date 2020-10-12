Imports Telerik.Web.UI

Public Class FRM_STAFF_NYM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _type As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        '_process = Request("process").ToString()
        Try
            _type = Request("type").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            load_ddl()
            'load_GV_lcnno()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Private Sub load_ddl()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        dt = bao.SP_MAS_NYMSTAFF_PROCESS

        ddl_search.DataSource = dt 'dao.datas
        ddl_search.DataTextField = "PROCESS_NAME"
        ddl_search.DataValueField = "PROCESS_ID"
        ddl_search.DataBind()
        Dim item As New ListItem
        item.Text = "กรุณาเลือกประเภท"
        item.Value = "0"
        ddl_search.Items.Insert(0, item)
    End Sub
    'Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click

    '    OpenPopupName("POPUP_LCN_DOWNLOAD.aspx")
    'End Sub

    'Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
    '    OpenPopupName("POPUP_LCN_UPLOAD.aspx")
    'End Sub
    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    'Sub load_GV_lcnno()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    'SP_STAFF_DALCN_BY_PVNCD
    '    If _pvncd = 10 Then
    '        dt = bao.SP_STAFF_DALCN()
    '    Else
    '        dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
    '    End If
    '    Dim IDGroup As Integer = 0
    '    Try
    '        IDGroup = _CLS.GROUPS
    '    Catch ex As Exception

    '    End Try
    '    If IDGroup = 21020 Then
    '        GV_lcnno.DataSource = dt
    '    ElseIf IDGroup = 63346 Then
    '        GV_lcnno.DataSource = dt.Select("STATUS_ID <= 2")
    '    ElseIf IDGroup = 63347 Then
    '        GV_lcnno.DataSource = dt.Select("STATUS_ID > 2 and STATUS_ID <= 6")
    '    ElseIf IDGroup = 63348 Then
    '        GV_lcnno.DataSource = dt.Select("STATUS_ID > 6")
    '    End If
    '    GV_lcnno.DataBind()
    'End Sub


#Region "GRIDVIEW"
    'Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
    '        Dim index As Integer = e.Row.RowIndex
    '        'Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
    '        Dim str_ID As String = GV_lcnno.DataKeys.Item(index)("IDA").ToString()
    '        Dim dao As New DAO_DRUG.ClsDBdalcn
    '        dao.GetDataby_IDA(Integer.Parse(str_ID))
    '        btn_edit.Style.Add("display", "none")
    '        Try
    '            If dao.fields.STATUS_ID = 6 Then
    '                btn_edit.Style.Add("display", "block")
    '            End If
    '        Catch ex As Exception

    '        End Try
    '        Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & str_ID
    '        btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")

    '    End If
    'End Sub

    'Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBdalcn

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As Integer = 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try

    '        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
    '        dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
    '        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_LCN_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID & "');", True)

    '    End If

    'End Sub


    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
    '    GV_lcnno.PageIndex = e.NewPageIndex
    '    load_GV_lcnno()
    'End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
        'load_GV_lcnno()
    End Sub
#End Region

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'drsamp IDA
            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            Dim PROCESS_ID As Integer = 0
            Try
                PROCESS_ID = item("PROCESS_ID").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.ClsDBdrsamp
                dao.GetDataby_IDA(IDA)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try


                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_NYM_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(IDA)
            btn_edit.Style.Add("display", "none")
            Try
                If dao.fields.STATUS_ID = 6 Then
                    btn_edit.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'SP_STAFF_DALCN_BY_PVNCD
        'If _pvncd = 10 Then
        '    dt = bao.SP_STAFF_DALCN()
        'Else
        '    dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
        'End If

        dt = bao.SP_STAFF_NYM()
        Dim IDGroup As Integer = 0
        Try
            IDGroup = _CLS.GROUPS
            If _process = "" Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        If IDGroup = 21020 Then
            If _type = "" Then
                RadGrid1.DataSource = dt.Select("PROCESS_ID = " & _process)
            Else
                RadGrid1.DataSource = dt.Select("PROCESS_ID = " & _process & " and donate_type = " & _type)
            End If
        ElseIf IDGroup = 63346 Then
            If _type = "" Then
                RadGrid1.DataSource = dt.Select("STATUS_ID = 2 and PROCESS_ID = " & _process)
            Else
                RadGrid1.DataSource = dt.Select("STATUS_ID = 2 and PROCESS_ID = " & _process & " and donate_type = " & _type)
            End If
        ElseIf IDGroup = 63347 Then
            If _type = "" Then
                RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6 and PROCESS_ID = " & _process)
            Else
                RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6 and PROCESS_ID = " & _process & " and donate_type = " & _type)
            End If
        ElseIf IDGroup = 63348 Then
            If _type = "" Then
                RadGrid1.DataSource = dt.Select("STATUS_ID > 6  and PROCESS_ID = " & _process)
            Else
                RadGrid1.DataSource = dt.Select("STATUS_ID > 6  and PROCESS_ID = " & _process & " and donate_type = " & _type)
            End If
        End If
    End Sub

    Protected Sub btn_proof_Click(sender As Object, e As EventArgs) Handles btn_proof.Click
        Response.Redirect("FRM_STAFF_NYM_PROOF.aspx")
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If ddl_search.SelectedIndex <> 0 Then
            Dim dt As New DataTable
            Dim bao As New BAO.ClsDBSqlcommand

            dt = bao.SP_MAS_NYMSTAFF_PROCESS
            _process = Left(ddl_search.SelectedValue, 4)
            btn_proof.Visible = True
            If ddl_search.SelectedValue = 10291 Then
                _type = Right(ddl_search.SelectedValue, 1) 'นยม4 ภาครัฐ
            ElseIf ddl_search.SelectedValue = 10292 Then
                _type = Right(ddl_search.SelectedValue, 1) 'นยม4 ภาคเอกชน
            End If

            RadGrid1.Rebind() 'ให้รันฟังก์ชั่นลำดับที่ 3
        Else
            alert("กรุณาเลือกประเภท")
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
End Class