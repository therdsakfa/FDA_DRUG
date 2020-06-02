Imports Telerik.Web.UI

Public Class FRM_FRGN_ADD_MAIN
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'bind_nat()
        End If
    End Sub
    'Sub bind_nat()

    '    dt = bao.SP_MASTER_sysisocnt()
    '    rcb_national.DataSource = dt
    '    rcb_national.DataTextField = "engcntnm"
    '    rcb_national.DataValueField = "alpha3"
    '    rcb_national.DataBind()

    'End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Search_frgn()
        RadGrid1.Rebind()
    End Sub
    Sub Search_frgn()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_syspdcfrgn_SEARCH(txt_search.Text)

        RadGrid1.DataSource = dt
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Dim frgncd As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Try
                frgncd = item("frgncd").Text
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then
                Dim dt As New DataTable
                Dim bao As New BAO_SHOW
                dt = bao.SP_drfrgnaddr_BY_frgncd(frgncd)
                HiddenField1.Value = frgncd
                RadGrid2.DataSource = dt

                RadGrid2.Rebind()
                'Dim _process_id As Integer = 0
                'lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_DR_CONFIRM_STAFF.aspx?IDA=" & IDA & "&TR_ID=" & item("TR_ID").Text & "&process=" & _process_id & "&STATUS_ID=" & item("STATUS_ID").Text & "&status=" & item("STATUS_ID").Text & "');", True)

                btn_add.Style.Add("display", "block")
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        If txt_search.Text <> "" Then
            Search_frgn()
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim url As String = "../TABEAN_YA_STAFF/FRM_FRGN_ADD_INSERT_EDIT.aspx?frgncd=" & HiddenField1.Value & "&act=insert"
        lbl_titlename.Text = "เพิ่มที่อยู่ผู้ผลิตต่างประเทศ"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
    End Sub

    Protected Sub btn_add_frgn_Click(sender As Object, e As EventArgs) Handles btn_add_frgn.Click
        Dim url As String = "../TABEAN_YA_STAFF/FRM_FRGN_NAME_INSERT.aspx"
        lbl_titlename.Text = "เพิ่มชื่อผู้ผลิตต่างประเทศ"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Dim frgncd As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Try
                frgncd = item("frgncd").Text
            Catch ex As Exception

            End Try
            If e.CommandName = "_edit" Then
                Dim _process_id As Integer = 0
                lbl_titlename.Text = "แก้ไขที่อยู่ผู้ผลิตต่างประเทศ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/FRM_FRGN_ADD_INSERT_EDIT.aspx?IDA=" & IDA & "&act=edit" & "');", True)

            End If

        End If
    End Sub
    'FRM_FRGN_NAME_INSERT
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        'Dim bao As New BAO_SHOW
        'Dim dt As New DataTable
        'dt = bao.SP_drfrgnaddr_BY_frgncd(HiddenField1.Value)
        'RadGrid2.DataSource = dt
    End Sub
End Class