Imports Telerik.Web.UI

Public Class FRM_CHEMICAL_STAFF_COMFIRM_TEXT_V2
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            'bind_ddl_iowa()
            'bind_ddl_salt()
            'bind_ddl_syn()
            txt_app_date.Text = Date.Now.ToShortDateString()
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(_IDA)
            Try
                If dao.fields.SUB_TYPE <> 2 Then
                    Panel3.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try
            Try
                lbl_iowanm.Text = dao.fields.iowanm
            Catch ex As Exception

            End Try
            Try
                txt_iowanm.Text = dao.fields.iowanm
            Catch ex As Exception

            End Try

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
            txt_runno.Text = dao.fields.runno + 1
        Catch ex As Exception

        End Try
    End Sub
    
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim statusID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim bao As New BAO.GenNumber
        Dim all_iowa As String = txt_iowacd.Text & txt_runno.Text & txt_salt.Text & txt_syn.Text
        Dim i As Integer = 0
        Dim dao_chem As New DAO_DRUG.TB_MAS_CHEMICAL
        i = dao_chem.Count_data_by_iowa(all_iowa)

        Dim dao_iowa As New DAO_DRUG.TB_driowa
        i += dao_iowa.CountDataby_iowa(all_iowa)

        If i = 0 Then
            Dim rcvno As String = bao.GEN_NO_05(con_year(Date.Now.Year()), _CLS.PVCODE, 19, _CLS.LCNNO, "", 0, _IDA, "")
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
                'dao.fields.aori = ddl_aori.SelectedValue
                dao.fields.cas_number = txt_cas_number.Text

                dao.fields.cas_type = Nothing
                dao.fields.iowa = txt_iowanm.Text
                dao.fields.iowanm = txt_iowanm.Text
                dao.fields.look_type = ddl_Look.SelectedValue
                dao.fields.REGIS_STATUS = "R"
                dao.fields.MODERN_TRADITION = txt_MODERN_TRADITION.Text
                Try
                    dao.fields.iowa = txt_iowacd.Text & txt_runno.Text & txt_salt.Text & txt_syn.Text
                Catch ex As Exception

                End Try
                dao.update()

                insert_to_mas_chemical(_IDA)

                alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว เลขที่รับคือ " & rcvno)
            End If
        Else
            alertnoclose("มีรหัสสารนี้แล้ว")
        End If
        

    End Sub

    Sub alertnoclose(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
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
        dao_cm.fields.iowa = dao.fields.iowacd & dao.fields.runno & dao.fields.salt & dao.fields.syn
        dao_cm.fields.MODERN_TRADITION = dao.fields.MODERN_TRADITION
        dao_cm.insert()
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_CHEMICAL_REQUEST_DETAIL_TABLE(Request.QueryString("IDA"))
        RadGrid2.DataSource = dt
    End Sub
End Class