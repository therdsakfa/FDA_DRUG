Public Class WebForm37
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim bao As New BAO.GenNumber 'test
        'Dim run_number As String = ""
        'run_number = bao.GEN_DH15TDGT_NO(2562, "A", "14", 39932, 18930, "00")
        'Dim a As String = HttpContext.Current.Request.Url.AbsoluteUri

        If Not IsPostBack Then
            Dim dt As New DataTable
            dt = Get_DDL_DATA(8, 3, 88)
            Dim dt2 As New DataTable
            dt2 = dt.Clone
            For Each dr As DataRow In dt.Select("STATUS_ID <> 8")
                Dim dr2 As DataRow = dt2.NewRow()
                dr2("STATUS_ID") = dr("STATUS_ID")
                dr2("STATUS_NAME_STAFF") = dr("STATUS_NAME_STAFF")
                dr2("STATUS_NAME") = dr("STATUS_NAME")
                dt2.Rows.Add(dr2)
            Next
            ddl_status.DataSource = dt2 'dt.Select("STATUS_ID <> 8")
            ddl_status.DataValueField = "STATUS_ID"
            ddl_status.DataTextField = "STATUS_NAME_STAFF"
            ddl_status.DataBind()
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
       
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim aa As String = ""
        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        'xml = ws_118.Authen_Login(_TOKEN)
        'aa = ws_118.Authen_Login_MENU("xUKP5wpmeEFu31QOGcHCBAUU", "1710500118665", "8734", "260532", "8734001")
        aa = ws_118.Authen_Login("xUKP5wpmeEFu31QOGcHCBAUU")
    End Sub
    Function Get_DDL_DATA(ByVal stat_g As Integer, ByVal group1 As Integer, ByVal group2 As Integer) As DataTable
        'Dim dt As New DataTable
        'Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V2 @stat_group=" & stat_g & ", @group1=" & group1 & " , @group2=" & group2
        Dim sql As String = "exec SP_MAS_STATUS_STAFF_BY_GROUP_DDL_V3 @stat_group=" & stat_g & ", @group1=" & group1
        Dim dta As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dta = bao.Queryds(sql)
        Return dta
    End Function
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim ws_update As New WS_DRUG.WS_DRUG
        'ws_update.DRUG_INSERT_DR15(TextBox1.Text)
    End Sub

    Protected Sub btn_get_cas_Click(sender As Object, e As EventArgs) Handles btn_get_cas.Click
        Dim dt_new As New DataTable
        dt_new.Columns.Add("TAMRAP_NAME")
        dt_new.Columns.Add("ROWS")
        dt_new.Columns.Add("IOWA")
        dt_new.Columns.Add("iowanm")
        dt_new.Columns.Add("QTY")
        dt_new.Columns.Add("AORI")
        'QTY

        Dim dao_dr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
        dao_dr.GetDataAll_AUTO()
        For Each dao_dr.fields In dao_dr.datas
            Dim dt As New DataTable
            Dim baooo As New BAO.ClsDBSqlcommand
            dt = baooo.SP_GET_DATA_15_TAMRAP_TEMPLATE_BY_ID(dao_dr.fields.TAMRAP_ID)
            For Each dr As DataRow In dt.Rows
                Dim drr As DataRow = dt_new.NewRow()
                drr("TAMRAP_NAME") = dr("TAMRAP_NAME")
                drr("ROWS") = dr("ROWS")
                drr("IOWA") = dr("IOWA")
                drr("iowanm") = dr("iowanm")
                drr("QTY") = dr("QTY")
                drr("AORI") = dr("AORI")
                dt_new.Rows.Add(drr)
            Next
        Next

    End Sub
    '

    Protected Sub btn_get_pcksize_Click(sender As Object, e As EventArgs) Handles btn_get_pcksize.Click
        Dim dt_new As New DataTable
        dt_new.Columns.Add("TAMRAP_NAME")
        dt_new.Columns.Add("contain_detail2")
        'QTY

        Dim dao_dr As New DAO_DRUG.TB_MAS_TAMRAP_NAME
        dao_dr.GetDataAll_AUTO()
        For Each dao_dr.fields In dao_dr.datas
            Dim dt As New DataTable
            Dim baooo As New BAO.ClsDBSqlcommand
            dt = baooo.SP_GET_DATA_15_TAMRAP_PACK_DETAIL_BY_ID(dao_dr.fields.TAMRAP_ID)
            For Each dr As DataRow In dt.Rows
                Dim drr As DataRow = dt_new.NewRow()
                drr("TAMRAP_NAME") = dr("TAMRAP_NAME")
                drr("contain_detail2") = dr("contain_detail2")
              
                dt_new.Rows.Add(drr)
            Next
        Next

    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim dao As New DAO_DRUG.ClsDBdrrqt
        'dao.GetDataby_IDA(95519)
        Dim aa As New WS_ACCEPT_RGT_AUTO
        aa.ACCEPT_AND_RUNNING_RGTNO(95519)
    End Sub
End Class