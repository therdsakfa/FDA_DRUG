Imports Telerik.Web.UI

Public Class POPUP_DRUG_PRODUCT_ID_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _CLS = Session("CLS")
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Txt_TRADE_NAME.Text = dao.fields.TRADE_NAME
            Txt_TRADE_NAME_ENG.Text = dao.fields.TRADE_NAME_ENG
        End If
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        dt = bao.SP_CDRUG_PRODUCT_IOWA(IDA)
        RadGrid1.DataSource = dt
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        dt = bao.SP_DRUG_PRODUCT_DR_GROUP_BY_FK_IDA(IDA)
        RadGrid2.DataSource = dt
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 3

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_status.DataSource = dt
        ddl_status.DataValueField = "STATUS_ID"
        ddl_status.DataTextField = "STATUS_NAME"
        ddl_status.DataBind()
    End Sub
    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim IDA As Integer = 0
        Try
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Dim statusID As Integer = ddl_status.SelectedItem.Value
        Dim bao As New BAO.GenNumber

        'Dim rcvno As String = bao.GEN_NO_17(con_year(Date.Now.Year()), _CLS.PVCODE, 19, _CLS.LCNNO, "", 0, IDA, "")
        'Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_IDA(IDA)

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = IDA
        Try
            dao_date.fields.STATUS_DATE = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 4 'ชื่อสาร
        dao_date.fields.STATUS_ID = ddl_status.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.insert()

        If statusID = "7" Then
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value

            Try
                dao.fields.RCVDATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            alert("ไม่อนุมัติคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "8" Then
            Dim lcnno As String = bao.GEN_NO_16(con_year(Date.Now.Year()), _CLS.PVCODE, 40, _CLS.LCNNO, "", 0, IDA, "")
            dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
            Try
                dao.fields.APPDATE = CDate(txt_app_date.Text)
                dao.fields.LCNNODATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao.fields.LCNNO = lcnno
            dao.fields.LCNNO_DISPLAY = "D-" & lcnno
            dao.update()
            alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว เลขที่รับคือ " & "D-" & lcnno)
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class