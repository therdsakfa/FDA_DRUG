Public Class UC_INFORMATION_HEAD_V2
    Inherits System.Web.UI.UserControl
    Private _Product_type As Integer
    Public Property Product_type() As Integer
        Get
            Return _Product_type
        End Get
        Set(ByVal value As Integer)
            _Product_type = value
        End Set
    End Property
    Private _sub_type As Integer
    Public Property sub_type() As Integer
        Get
            Return _sub_type
        End Get
        Set(ByVal value As Integer)
            _sub_type = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("extra") <> "" Then
            HyperLink1.Style.Add("display", "none")
        End If
    End Sub
    Sub set_label()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW_V3(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("drgtpcd"))

        For Each dr As DataRow In dt.Rows
            lbl_product_name.Text = dr("drgnm")
            lbl_lcnno_display.Text = dr("rcvno_display")
            'lbl_lcnsnm.Text = dr("thanm")
        Next

        Dim dao_max As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
        dao_max.GetDataby_GEN3(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"))
        Dim max_num As Integer = 0
        Try
            max_num = dao_max.fields.STATUS_INDEX
        Catch ex As Exception

        End Try

        Dim dao_cur As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
        dao_cur.GetDataCurrent(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), max_num)

        Dim stat_id As Integer = 0
        Try
            stat_id = dao_cur.fields.STATUS_ID
        Catch ex As Exception

        End Try
        Dim dao_stat As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS_NAME
        dao_stat.GetDataby_IDA(stat_id)
        Try
            If stat_id = 0 Then
                lbl_stat.Text = "-"
                Label1.Style.Add("display", "none")
                HyperLink1.Style.Add("display", "none")
            Else
                lbl_stat.Text = dao_stat.fields.STAFF_STATUS & " (" & dao_stat.fields.STAGE_NAME & ")"
            End If
        Catch ex As Exception
            lbl_stat.Text = "-"
        End Try
        Try
            lbl_date.Text = CDate(dao_cur.fields.STATUS_DATE).ToShortDateString()
        Catch ex As Exception

        End Try
       
        Dim url As String = "../FRM_ETRACKING_STATUS_SUB_MAIN.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & Request.QueryString("IDA") & "&head=" & Request.QueryString("head") & "&extra=1"
        HyperLink1.NavigateUrl = url
    End Sub
End Class