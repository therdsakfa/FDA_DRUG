Imports Telerik.Web.UI
Public Class FRM_SEARCH_ATTACH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            'load_GV_lcnno()
        End If
    End Sub
    Sub Search_FN()
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DALCN_STAFF_SEARCH()
        Dim _pvncd_per As Integer = 0
        Try
            _pvncd_per = _CLS.PVCODE
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        Try
            dt = bao.dt
        Catch ex As Exception

        End Try
        Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable
        'str_where = "CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
        If txt_lcnno_no.Text <> "" Then
            'If str_where <> "" Then
            '    str_where &= " and lcnno_no like '%" & txt_lcnno_no.Text & "%'"
            'Else
            str_where &= "CITIZEN_ID_AUTHORIZE='" & txt_lcnno_no.Text & "'"
            'End If

        End If

        If str_where <> "" Then
            If _pvncd_per <> 0 Then
                If _pvncd_per <> 10 Then
                    str_where &= " AND pvncd='" & _pvncd_per & "'"
                End If
            End If
        End If
        r_result = dt.Select(str_where)

        dt2 = dt.Clone

        For Each dr As DataRow In r_result
            dt2.Rows.Add(dr.ItemArray)
        Next
        RadGrid1.DataSource = dt2
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(IDA)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception
                    tr_id = 0
                End Try

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_ATTACH_PAGE.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID & "');", True)

                Response.Redirect("FRM_ATTACH_PAGE.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID)
            End If

        End If
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_FN()
        RadGrid1.Rebind()
    End Sub

    Public Sub set_color_rg()
        If RadGrid1.Items.Count > 0 Then
            Dim i As Integer = 0
            For Each item As GridDataItem In RadGrid1.Items
                Dim days_result As Double = 0

                Try
                    days_result = item("days_result").Text
                Catch ex As Exception

                End Try

                If days_result < 0 Then
                    item.ForeColor = Drawing.Color.Crimson

                End If
                'i = i + 1
            Next
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
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        'If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
        '    Dim item As GridDataItem
        '    item = e.Item
        '    Dim IDA As String = item("IDA").Text
        '    Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
        '    Dim dao As New DAO_DRUG.ClsDBdalcn
        '    dao.GetDataby_IDA(IDA)
        '    btn_edit.Style.Add("display", "none")
        '    Try
        '        If dao.fields.STATUS_ID = 6 Then
        '            btn_edit.Style.Add("display", "block")
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
        '    btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
        'End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        If txt_lcnno_no.Text <> "" Then
            Search_FN()
        End If
    End Sub
End Class