Imports Telerik.Web.UI
Public Class FRM_CHEMICAL_STAFF_COMFIRM_TEXT_HERB
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _Process As Integer
    Private _CLS As New CLS_SESSION

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _Process = Request.QueryString("process")
        End If

    End Sub
    Sub bind_ddl_chem16()
        Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL_LIST16
        dao.GetDataALL()
        ddl_chem16.DataSource = dao.datas
        ddl_chem16.DataValueField = "IDA"
        ddl_chem16.DataTextField = "CHEM_NAME"
        ddl_chem16.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            bind_ddl_chem16()
            Bind_ddl_Status_staff()
            'bind_ddl_iowa()
            'bind_ddl_salt()
            'bind_ddl_syn()
            txt_app_date.Text = Date.Now.ToShortDateString()

            UC_HERB_CHEM1.set_lbl_herb_type(Request.QueryString("g"))
            UC_HERB_CHEM1.bind_rdl_herb_or_animal()
            UC_HERB_CHEM1.bind_ddl_nat()
            If Request.QueryString("IDA") <> "" Then

                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
                dao.GetDataby_IDA(_IDA)
                Try
                    txt_iowanm.Text = dao.fields.iowanm
                Catch ex As Exception

                End Try
                UC_HERB_CHEM1.get_data(dao)
            End If
            set_runno()
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        If txt_search.Text <> "" Then
            dt = bao.SP_MAS_CHEMICAL_SEARCH_RESULT(txt_search.Text)
        End If

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        RadGrid1.Rebind()
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
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
    Public Sub set_runno()
        Dim dao As New DAO_DRUG.TB_MAS_CHEMICAL
        Try
            dao.Get_RUNNO_MAX()
            txt_runno.Text = dao.fields.runno
        Catch ex As Exception

        End Try
    End Sub
    'Public Sub bind_ddl_iowa()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_MAS_IOWA()
    '    dt = bao.dt
    '    ddl_iowa.DataSource = dt
    '    ddl_iowa.DataBind()
    'End Sub
    'Public Sub bind_ddl_salt()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_MAS_SALT()
    '    dt = bao.dt
    '    ddl_salt.DataSource = dt
    '    ddl_salt.DataBind()
    'End Sub
    'Public Sub bind_ddl_syn()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_MAS_SYN()
    '    dt = bao.dt
    '    ddl_syn.DataSource = dt
    '    ddl_syn.DataBind()
    'End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim statusID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim bao As New BAO.GenNumber

        Dim rcvno As String = bao.GEN_NO_05(con_year(Date.Now.Year()), _CLS.PVCODE, _Process, _CLS.LCNNO, "", 0, _IDA, "")
        Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
        dao.GetDataby_IDA(_IDA)

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 4 'ชื่อสาร
        dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.insert()

        If statusID = "7" Then
            dao.fields.STATUS_ID = ddl_cnsdcd.SelectedItem.Value
            Try
                dao.fields.RCV_DATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.REGIS_STATUS = "NR"
            dao.update()
            alert("ไม่อนุมัติคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "8" Then
            dao.fields.STATUS_ID = ddl_cnsdcd.SelectedItem.Value
            Try
                dao.fields.RCV_DATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.fields.iowacd = txt_iowacd.Text
            dao.fields.RCVNO = rcvno
            dao.fields.runno = txt_runno.Text
            dao.fields.salt = txt_salt.Text
            dao.fields.syn = txt_syn.Text
            dao.fields.aori = ddl_aori.SelectedValue
            'dao.fields.cas_number = txt_cas_number.Text

            dao.fields.cas_type = Nothing
            dao.fields.iowa = txt_iowanm.Text
            dao.fields.iowanm = txt_iowanm.Text
            dao.fields.look_type = ddl_Look.SelectedValue
            dao.fields.REGIS_STATUS = ddl_Regis.SelectedValue
            dao.fields.MODERN_TRADITION = ddl_Modern_drug.SelectedValue
            Try
                dao.fields.iowa = txt_iowacd.Text & txt_runno.Text & txt_salt.Text & txt_syn.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.IS_ATC = cb_IS_ATC.Checked
            Catch ex As Exception

            End Try
            Try
                If cb_IS_ATC.Checked Then
                    dao.fields.ATC_NAME = txt_ATC.Text
                End If
            Catch ex As Exception

            End Try
            dao.fields.INN = txt_INN.Text
            dao.update()

            insert_to_mas_chemical(_IDA)

            alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว เลขที่รับคือ " & rcvno)
        End If

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Public Sub insert_to_mas_chemical(ByVal ida As Integer)
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
        dao.GetDataby_IDA(ida)

        Dim dao_cm As New DAO_DRUG.TB_MAS_CHEMICAL
        dao_cm.fields.aori = dao.fields.aori
        dao_cm.fields.iowacd = dao.fields.iowacd
        dao_cm.fields.runno = dao.fields.runno
        dao_cm.fields.salt = dao.fields.salt
        dao_cm.fields.syn = dao.fields.syn
        dao_cm.fields.cas_number = dao.fields.cas_number
        dao_cm.fields.cas_type = dao.fields.cas_type
        dao_cm.fields.iowa = Nothing
        dao_cm.fields.iowanm = dao.fields.iowanm
        dao_cm.fields.look_type = dao.fields.look_type
        dao_cm.fields.MIX_TYPE = dao.fields.MIX_TYPE
        dao_cm.fields.REGIS_STATUS = dao.fields.REGIS_STATUS
        Try
            dao_cm.fields.iowa = dao.fields.iowacd & dao.fields.runno & dao.fields.salt & dao.fields.syn
        Catch ex As Exception

        End Try
        dao_cm.fields.ATC = dao.fields.ATC_NAME
        dao_cm.fields.INN = dao.fields.INN
        dao_cm.fields.MODERN_TRADITION = dao.fields.MODERN_TRADITION
        dao_cm.insert()
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_CHEMICAL_REQUEST_DETAIL_TABLE(Request.QueryString("IDA"))
        RadGrid2.DataSource = dt
    End Sub
    Private Sub btn_add_statndard_Click(sender As Object, e As EventArgs) Handles btn_add_statndard.Click
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST_STANDARD_IOWA
        dao.fields.FK_IDA = _IDA
        dao.fields.STANDARD_IOWA = ddl_chem16.SelectedValue
        dao.insert()
        Response.Write("<script type='text/javascript'>window.parent.alert('เพิ่มข้อมูลเรียบร้อย');</script> ")
    End Sub

    Private Sub RadGrid3_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid3.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST_STANDARD_IOWA
                dao.GetDataby_IDA(item("IDA").Text)
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย');", True)
                RadGrid3.Rebind()
            End If
        End If
    End Sub

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_CHEMICAL_REQUEST_CHEM16_BY_FK_IDA(Request.QueryString("IDA"))
        RadGrid3.DataSource = dt
    End Sub
End Class