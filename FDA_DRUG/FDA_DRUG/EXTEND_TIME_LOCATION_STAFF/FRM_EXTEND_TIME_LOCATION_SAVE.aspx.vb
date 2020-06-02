Public Class FRM_EXTEND_TIME_LOCATION_SAVE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private u1 As String
    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()

        Try
            _CLS = Session("CLS")
            'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")
            u1 = Request.QueryString("u1")  'เรียก Process ที่เราเรียก
            If u1 <> "" Then
                u1 = u1.DecodeBase64()
            End If
            '_lcn_ida = Request.QueryString("lcn_ida")
            'str_ID = Request.QueryString("str_ID")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        set_label(u1)
        Bind_ddl_Status_staff()
        If Not IsPostBack Then
            lbl_date.Text = Date.Now.ToShortDateString 'แสดงวันที่รับ
            lbl_app_date.Text = Date.Now.ToShortDateString 'แสดงวันที่รับ

            Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
            dao.GetDataby_u1_code(u1)
            lbl_staff.Text = dao.fields.staff 'ผู้รับ
            If dao.fields.STATUS_ID Is Nothing Then
                lbl_status_pay.Text = "รอชำระเงิน"
                dao.fields.status_pay = "รอชำระเงิน"
                dao.fields.STATUS_ID = 2
            ElseIf dao.fields.STATUS_ID = 3 Then
                lbl_status_pay.Text = "รับคำขอ"
                dao.fields.status_pay = "รับคำขอ"
            ElseIf dao.fields.STATUS_ID = 8 Then
                lbl_status_pay.Text = "อนุมัติ"
                dao.fields.status_pay = "อนุมัติ"
            End If
            dao.update()
            If dao.fields.STATUS_ID = 8 Then
                ddl_cnsdcd.Visible = False
                btn_confirm.Visible = False
            End If
        End If
    End Sub
    Public Sub set_label(ByVal u1 As String) 'ดึงข้อมูลแสดง
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_u1_code(u1)
        lbl_lcntpcd.Text = dao.fields.lcntpcd
        lbl_lcnno_display_full.Text = dao.fields.lcnno_display_full
        lbl_thanm.Text = dao.fields.thanm
        lbl_thanm_address.Text = dao.fields.thanm_address
        lbl_grannm_lo.Text = dao.fields.grannm_lo
        lbl_thachngwtnm.Text = dao.fields.thachngwtnm
        lbl_expyear.Text = dao.fields.extend_year
        lbl_status_pay.Text = dao.fields.status_pay
        'ddl_cnsdcd.SelectedValue = dao.fields.STATUS_ID
    End Sub

    Public Sub Bind_ddl_Status_staff() 'สถานะ
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_u1_code(u1)

        If dao.fields.STATUS_ID <= 2 Then
            int_group_ddl = 1
            'ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
        ElseIf dao.fields.STATUS_ID = 3 Then
            int_group_ddl = 3
            'ElseIf dao.fields.STATUS_ID >= 6 Then
            '    int_group_ddl = 3
        ElseIf dao.fields.STATUS_ID Is Nothing Then
            int_group_ddl = 1
        End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt
        'dao.update()
        'bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(5, int_group_ddl)
        dt = bao.dt
        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub

    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao.GetDataby_u1_code(u1)
        If IsNothing(dao.fields.U1_CODE) Then

        Else
            dao.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
            ddl_cnsdcd.SelectedItem.Text = lbl_status_pay.Text
            dao.fields.rcvdate = lbl_date.Text
            dao.fields.appdate = lbl_app_date.Text
            dao.fields.staff = _CLS.THANM
            dao.update()
        End If
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub

    'Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
    '    Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    'End Sub

    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub
End Class