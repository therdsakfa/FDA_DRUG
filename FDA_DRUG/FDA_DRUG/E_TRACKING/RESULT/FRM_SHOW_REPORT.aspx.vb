Public Class FRM_SHOW_REPORT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim dao_pro As New DAO_DRUG.TB_MAS_DRUG_PRODUCT_NAME
            'dao_pro.GetDataAll()
            'rdl_product.DataSource = dao_pro.datas
            'rdl_product.DataTextField = "PRODUCT_NAME"
            'rdl_product.DataValueField = "IDA"
            'rdl_product.DataBind()
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim big_type As String = ""
        Dim small_type As String = ""
        big_type = rdl_big_type.SelectedValue
        small_type = rdl_small_type.SelectedValue
        If big_type <> "" And small_type <> "" Then
            If big_type = "1" Then
                
            ElseIf big_type = "2" Then
                If small_type = "1" Then
                    dt = bao.SP_GET_REPORT_DATA_E_TRACKING_WORK_DAY_RESULT_BY_LCNSID(3447)
                    dt.Columns.Add("all_days", GetType(Double))
                    dt.Columns.Add("stop_days", GetType(Double))
                    dt.Columns.Add("extend_days", GetType(Double))
                    dt.Columns.Add("days_result", GetType(Double))

                    For Each dr As DataRow In dt.Rows
                        Dim all_days As Double = 0
                        Dim extend_days As Double = 0
                        Dim ws As New WS_GETDATE_WORKING.Service1

                        Try
                            ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, CDate(dr("appdate")), True, all_days, True) 'DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
                        Catch ex As Exception
                            ws.GETDATE_COUNT_DAY(CDate(dr("rcvdate")), True, Date.Now, True, all_days, True)
                        End Try
                        dr("all_days") = all_days
                        Dim bao2 As New BAO.ClsDBSqlcommand
                        Dim stop_days As Double = 0
                        Try
                            stop_days = bao2.SP_GET_DAY_EXTEND_BY_RCVNO_RGTTPCD(dr("rcvno"), dr("rgttpcd"))
                        Catch ex As Exception

                        End Try
                        dr("stop_days") = stop_days

                        Dim days_result As Double = 0
                        Try
                            days_result = dr("stdno") + 1 + extend_days - all_days - stop_days '(all_days + 1) - stop_days  'Math.Abs((dr("stdno") + stop_days) - all_days)
                        Catch ex As Exception

                        End Try
                        dr("days_result") = days_result
                        dr("extend_days") = 0
                    Next
                End If
    
            End If
        End If
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub btn_export0_Click(sender As Object, e As EventArgs) Handles btn_export0.Click
        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub
End Class