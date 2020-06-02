Public Class POPUP_STAFF_EDIT_PRODUCTION_CONFIRM
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            load_ddl()
            Dim dao As New DAO_DRUG.TB_lcnrequest
            If Request.QueryString("ida") <> "" Then
                dao.GetDataby_IDA(_IDA)
                get_data(dao)
            End If
        End If
    End Sub
    Private Sub load_ddl()
        Dim dao_req As New DAO_DRUG.TB_lcnrequest
        dao_req.GetDataby_IDA(_IDA)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_FK_IDA_and_PROCESS_ID_4(dao_req.fields.LOCATION_ADDRESS_IDA, 101, 102, 103, 104)
        ddl_lcnno.DataSource = dao.datas
        ddl_lcnno.DataTextField = "LCNNO_DISPLAY"
        ddl_lcnno.DataValueField = "IDA"
        ddl_lcnno.DataBind()
        Dim item As New ListItem
        item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        item.Value = "0"
        ddl_lcnno.Items.Insert(0, item)
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_MAS_STATUS_STAFF()
        Dim int_group_ddl As Integer = 3
        Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        dao_la.GetDataby_IDA(_IDA)
        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim statusID As Integer = ddl_cnsdcd.SelectedItem.Value

        If statusID = "8" Then
            Response.Redirect("POPUP_STAFF_EDIT_LOCATION_RECEIVE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & 42)

        Else
            Response.Redirect("POPUP_STAFF_EDIT_LOCATION_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & 42)

        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_lcnrequest)
        txt_REMARK.Text = dao.fields.REMARK
        txt_WRITE_AT.Text = dao.fields.WRITE_AT
        Try
            txt_WRITE_DATE.Text = CDate(dao.fields.WRITE_DATE)
        Catch ex As Exception

        End Try
        Try
            ddl_lcnno.DropDownSelectData(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
    End Sub
End Class