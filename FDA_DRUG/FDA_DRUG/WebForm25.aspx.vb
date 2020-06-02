Imports Telerik.Web.UI
Public Class WebForm25
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'UC_DS_PORYOR8.set_label(30591)
        'If Not IsPostBack Then
        '    'UC_DS_CHECAL_DETAIL.bind_ddl_chemecal()
        '    'UC_DS_CHECAL_DETAIL.bind_ddl_chemecal2()
        '    'UC_DS_CHECAL_DETAIL.bind_ddl_unit()
        '    'UC_DS_CHECAL_DETAIL.bind_ddl_unit2()
        'End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim P_ID As String = ""
            Dim S_ID As String = ""
            Try
                P_ID = item("P_ID").Text
            Catch ex As Exception
                P_ID = ""
            End Try
            Try
                S_ID = item("S_ID").Text
            Catch ex As Exception
                S_ID = ""
            End Try
            Dim rad_name As RadComboBox = DirectCast(item("name").FindControl("rcb_name"), RadComboBox)
            Dim rad_skill As RadComboBox = DirectCast(item("skill").FindControl("rcb_skill"), RadComboBox)
            Dim lbl_name As Label = DirectCast(item("name").FindControl("lbl_name"), Label)
            Dim lbl_skill As Label = DirectCast(item("skill").FindControl("lbl_skill"), Label)

            Dim dt As New DataTable
            dt.Columns.Add("IDA")
            dt.Columns.Add("name")
            For i As Integer = 1 To 3
                Dim dr As DataRow = dt.NewRow
                dr("IDA") = i
                dr("name") = "นาย " & i
                dt.Rows.Add(dr)
            Next
            rad_name.DataSource = dt
            rad_name.DataTextField = "name"
            rad_name.DataValueField = "IDA"
            rad_name.DataBind()

            If P_ID <> "" Then
                rad_name.SelectedValue = P_ID
                lbl_name.Text = rad_name.SelectedItem.Text
                lbl_name.Style.Add("display", "block")
                rad_name.Style.Add("display", "none")

            End If

            Dim dt2 As New DataTable
            dt2.Columns.Add("IDA")
            dt2.Columns.Add("skill")
            For i As Integer = 1 To 3
                Dim dr As DataRow = dt2.NewRow
                dr("IDA") = i
                dr("skill") = "ด้านที่ " & i
                dt2.Rows.Add(dr)
            Next
            rad_skill.DataSource = dt2
            rad_skill.DataTextField = "skill"
            rad_skill.DataValueField = "IDA"
            rad_skill.DataBind()

            If S_ID <> "" Then
                rad_skill.SelectedValue = S_ID
                lbl_skill.Text = rad_skill.SelectedItem.Text
                lbl_skill.Style.Add("display", "block")
                rad_skill.Style.Add("display", "none")
            End If

            Dim cb_chk As CheckBox = DirectCast(item("chk").FindControl("cb_chk"), CheckBox)
            Try
                cb_chk.Checked = CBool(item("P_ID").Text)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        dt.Columns.Add("IDA")
        dt.Columns.Add("P_ID")
        dt.Columns.Add("S_ID")
        dt.Columns.Add("chk", GetType(Boolean))
        For i As Integer = 1 To 3
            Dim dr As DataRow = dt.NewRow
            dr("IDA") = i
            dr("P_ID") = i
            dr("S_ID") = i
            dr("chk") = True
            dt.Rows.Add(dr)
        Next

        RadGrid1.DataSource = dt
    End Sub

    Function Count_Null() As Integer
        Dim null_no As Integer = 0
        If Len(TextBox1.Text) = 0 Then
            null_no += 1
        End If
        If Len(TextBox2.Text) = 0 Then
            null_no += 1
        End If
        Return null_no
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim aa As Integer = 0

        aa = Count_Null()
    End Sub
    Private Sub cbl_change_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbl_change.SelectedIndexChanged
        For Each item As ListItem In cbl_change.Items
            If item.Value = "1" Then
                Panel1.Style.Add("display", "block")
                'Else
                '    Panel1.Style.Add("display", "none")
            End If
            If item.Value = "2" Then
                Panel2.Style.Add("display", "block")
                'Else
                '    Panel2.Style.Add("display", "none")
            End If
            If item.Value = "3" Then
                Panel3.Style.Add("display", "block")
                'Else
                '    Panel3.Style.Add("display", "none")
            End If
        Next
        For i As Integer = 0 To cbl_change.Items.Count - 1
            If cbl_change.Items(i).Selected = False Then
                If cbl_change.Items(i).Value = "1" Then
                    Panel1.Style.Add("display", "none")
                ElseIf cbl_change.Items(i).Value = "2" Then
                    Panel2.Style.Add("display", "none")
                ElseIf cbl_change.Items(i).Value = "3" Then
                    Panel3.Style.Add("display", "none")
                End If
            End If

        Next
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Text = set_name_company(TextBox3.Text)
    End Sub

    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Bind_ddl_Status_staff()
    End Sub

    Public Sub Bind_ddl_Status_staff()
        Dim STATUS_ID As String = TextBox6.Text
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl1 As Integer = 0
        Dim int_group_ddl2 As Integer = 0
        If STATUS_ID = 4 Then
            int_group_ddl1 = 1
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 5 Then
            int_group_ddl1 = 2
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 6 Then
            int_group_ddl1 = 3
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 9 Then
            int_group_ddl1 = 4
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 10 Then
            int_group_ddl1 = 5
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 11 Then
            int_group_ddl1 = 6
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 12 Then
            int_group_ddl1 = 8
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 13 Then
            int_group_ddl1 = 9
            int_group_ddl2 = 77
        ElseIf STATUS_ID = 14 Then 'รับขึ้นทะเบียน
            int_group_ddl1 = 10
            int_group_ddl2 = 7
        End If

        dt = Get_DDL_DATA(8, int_group_ddl1, int_group_ddl2)

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME_STAFF"
        ddl_cnsdcd.DataBind()

    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        Dim dt As New DataTable
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.Queryds(sql)
        Return dt
    End Function

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dt As New DataTable
        dt = DATA_EDIT()
        For Each dr2 As DataRow In dt.Rows
            Dim bao_show11 As New BAO_SHOW
            Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(dr2("BSN_IDENTIFY"))
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.GetDataby_LCN_IDA(dr2("IDA"))
            For Each dr As DataRow In dt_bsn.Rows

                Try
                    dao_bsn.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ADDR = dr("BSN_ADDR")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_SOI = dr("BSN_SOI")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ROAD = dr("BSN_ROAD")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_MOO = dr("BSN_MOO")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_FAX = dr("BSN_FAX")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_THAINAME = dr("BSN_THAINAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.AMPHR_ID = dr("AMPHR_ID")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.TUMBON_ID = dr("TUMBON_ID")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_FLOOR = dr("BSN_FLOOR")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_BUILDING = dr("BSN_BUILDING")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.CREATE_DATE = dr("CREATE_DATE")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.DOWN_ID = dr("DOWN_ID")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.CITIZEN_ID = dr("CITIZEN_ID")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.XMLNAME = dr("XMLNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.NATIONALITY = dr("NATIONALITY")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ENGMU = dr("BSN_ENGMU")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
                Catch ex As Exception

                End Try
                Try
                    dao_bsn.fields.AGE = dr("AGE")
                Catch ex As Exception

                End Try
                dao_bsn.update()
            Next
        Next
    End Sub

    Public Function DATA_EDIT() As DataTable
        Dim sql As String = ""
        sql = " select h.BSN_IDENTIFY, d.IDA"
        sql &= " from [dbo].[EDT_HISTORY] h"
        sql &= " join [dbo].[EDT_COUNT] e on h.FK_IDA = e.IDA"
        sql &= " join [fda].[dalcn] d on e.FK_IDA = d.IDA"
        sql &= " where lcnsid <> 252565 And edit_type = 1"
        sql &= " group by h.BSN_IDENTIFY , d.IDA"
        Dim dta As New DataTable
        'Dim bao As New BAO_SHOW
        'dta = bao.Queryds(sql)

        Return dta
    End Function

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify("3100602816380") 'getProfile_byidentify("3100602816380")

        Dim aa As String = ""
        aa = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
    End Sub

    Protected Sub btn_run_R_Click(sender As Object, e As EventArgs) Handles btn_run_R.Click
        Dim ws_c As New WS_UPDATE_C.Service1
        'Dim ws_c As New WS_UPDATE_C_DEMO.Service1
        Dim result_c As String = ""
        Try
            result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(txt_rc_no.Text)
            'result_c = ws_c.UPDATE_STATUS_BOOKING_DRUG(txt_r_no.Text)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Label2.Text = TextBox7.Text.Replace(",", "")
    End Sub
End Class