Imports FDA_DRUG.Graph3DMultiple
Imports System.Web.Script.Serialization
Public Class FRM_E_TRACKING_WORK_ALL_PERSON
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl()
            bind_grid_new()
            Try
                Dim dao_d As New DAO_DRUG.TB_E_TRACKING_BASE
                dao_d.get_max_update()
                lb_update_date.Text = CDate(dao_d.fields.update_date).ToShortDateString()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub bind_ddl()
        Dim dao As New DAO_DRUG.TB_syswrkunt
        dao.GetDataALL()
        DropDownList1.DataSource = dao.datas
        DropDownList1.DataBind()
    End Sub
    Sub bind_grid_new()
        Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        dt = bao.SP_E_TRACKING_PERSON_WORK_BY_GROUP2(DropDownList1.SelectedValue)
        dt.Columns.Add("total", GetType(Integer))

        Dim bao_list As New BAO.ClsDBSqlcommand
        Dim dt_list As New DataTable
        dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL2()
        'dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP(Request.QueryString("g"))
        dt_list.Columns.Add("date_last", GetType(Date))
        dt_list.Columns.Add("day_cal", GetType(Integer))



        'For Each dr As DataRow In dt_list.Rows
        '    Dim ws As New WS_GETDATE_WORKING.Service1
        '    Dim date_result As Date
        '    ws.GETDATE_WORKING(CDate(dr("rcvdate")), True, dr("WORK_DAYS"), True, date_result, True)
        '    'date_result = date_result.ToLongDateString()
        '    dr("date_last") = date_result
        '    Dim days As Double = 0

        '    Try
        '        days = DateDiff(DateInterval.Day, date_result, CDate(dr("appdate")))
        '    Catch ex As Exception
        '        days = DateDiff(DateInterval.Day, date_result, Date.Now)
        '    End Try

        '    dr("day_cal") = days
        'Next
        For Each dr As DataRow In dt_list.Rows

            Dim days As Double = 0
            Dim date_t As Date
            Try
                If Year(CDate(dr("date_real_cp"))) > 3000 Then
                    date_t = CDate(dr("date_real_cp")).AddYears(-543)
                Else
                    date_t = CDate(dr("date_real_cp"))
                End If
            Catch ex As Exception

            End Try
            Try
                days = DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
            Catch ex As Exception
                days = DateDiff(DateInterval.Day, date_t, Date.Now)
            End Try

            dr("day_cal") = days
        Next

        Dim bao2 As New BAO.ClsDBSqlcommand
        Dim dt2 As New DataTable
        Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_GAP
        dao.GetDataAll()
        Try
            dt2 = bao2.TBL_E_TRACKING_GAP(dao.fields.GAP_SET)
        Catch ex As Exception
            dt2 = bao2.TBL_E_TRACKING_GAP(120)
        End Try
        Dim gid As String = ""
        gid = Request.QueryString("gid")
        Dim col4 As String = Request.QueryString("col4")
        Dim col5 As String = Request.QueryString("col5")

        For Each dr As DataRow In dt.Rows
            'dt_list.Select("day_cal > '" & dt(0)("max_gap") & "'")
            dr("less120") = dt_list.Compute("count(IDA)", "day_cal > '" & dt2(0)("max_gap") & "' and ctzid='" & dr("ctzid") & "' and wrkuntcd='" & DropDownList1.SelectedValue & "'")
            dr("less60_to_120") = dt_list.Compute("count(IDA)", "day_cal > '" & dt2(1)("gap") & "' and day_cal <= '" & dt2(1)("max_gap") & "' and ctzid='" & dr("ctzid") & "' and wrkuntcd='" & DropDownList1.SelectedValue & "'")
            dr("less0_to_60") = dt_list.Compute("count(IDA)", "day_cal >= '" & dt2(2)("gap") & "' and day_cal < '" & dt2(2)("max_gap") & "' and ctzid='" & dr("ctzid") & "' and wrkuntcd='" & DropDownList1.SelectedValue & "'")
            dr("more0_to_60") = dt_list.Compute("count(IDA)", "day_cal >= '" & dt2(3)("max_gap") & "' and day_cal < '" & dt2(3)("gap") & "' and ctzid='" & dr("ctzid") & "' and wrkuntcd='" & DropDownList1.SelectedValue & "'")
            dr("more60_to_120") = dt_list.Compute("count(IDA)", "day_cal < '" & dt2(4)("gap") & "' and day_cal >= '" & dt2(4)("max_gap") & "' and ctzid='" & dr("ctzid") & "' and wrkuntcd='" & DropDownList1.SelectedValue & "'")
            dr("more120") = dt_list.Compute("count(IDA)", "day_cal < '" & dt2(5)("max_gap") & "' and ctzid='" & dr("ctzid") & "' and wrkuntcd='" & DropDownList1.SelectedValue & "'")

            Try
                dr("total") = dr("more0_to_60") + dr("more60_to_120") + dr("more120")
            Catch ex As Exception

            End Try


        Next



        Dim dv As DataView = dt.DefaultView
        dv.Sort = "more0_to_60 desc, more60_to_120 desc,more120 desc"

        dt = dv.ToTable()
        RadGrid1.DataSource = dt 'dt.AsEnumerable().Take(5)
        RadGrid1.Rebind()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bind_grid_new()
    End Sub
End Class