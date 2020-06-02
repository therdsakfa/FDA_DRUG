Public Class UC_PHR_ADD
    Inherits System.Web.UI.UserControl
    Public PHR_NAME As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'set_data_sakha()
        End If
    End Sub
    Sub bind_lcn_type()
        Dim dao As New DAO_DRUG.ClsDBdaphrcd
        Try
            dao.GetData_by_phrcd(ddl_worker_type.SelectedValue)
            'lbl_lcn_type.Text = dao.fields.lcndtlnm
        Catch ex As Exception

        End Try

    End Sub
    Sub get_PHR_NAME()
        PHR_NAME = txt_PHR_NAME.Text
    End Sub
    Sub bind_ddl_work_type()
        Try
            Dim dao As New DAO_DRUG.ClsDBdaphrcd
            dao.GetDataAll()
            ddl_worker_type.DataSource = dao.datas
            ddl_worker_type.DataValueField = "phrcd"
            ddl_worker_type.DataTextField = "phrnm"
            ddl_worker_type.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_worker_type.Items.Insert(0, item)
        Catch ex As Exception

        End Try


    End Sub
    Sub bind_ddl_job()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao.SP_PHR_JOB()
        Catch ex As Exception

        End Try
        ddl_job.DataSource = dt
        ddl_job.DataValueField = "functcd"
        ddl_job.DataTextField = "functnm"
        ddl_job.DataBind()
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL()

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub
    Public Function Get_Name_In() As String
        Dim phrname As String = ""

        Return phrname = txt_PHR_NAME.Text
    End Function
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)
        With dao.fields
            .PHR_NAME = txt_PHR_NAME.Text
            .PHR_LEVEL = txt_PHR_LEVEL.Text
            .PHR_PREFIX_ID = ddl_prefix.SelectedValue
            .PHR_PREFIX_NAME = ddl_prefix.SelectedItem.Text
            .PHR_CTZNO = txt_PHR_CTZNO.Text
            .PHR_TEXT_NUM = txt_PHR_TEXT_NUM.Text
            .PHR_TEXT_WORK_TIME = txt_PHR_TEXT_WORK_TIME.Text
            .PHR_VETERINARY_FIELD = txt_PHR_VETERINARY_FIELD.Text
            Try
                .PHR_LAW_SECTION = ddl_law.SelectedValue
            Catch ex As Exception

            End Try

            Try
                .PHR_JOB_TYPE = ddl_job.SelectedValue
            Catch ex As Exception

            End Try
            Try
                .PERSONAL_TYPE = ddl_worker_type.SelectedValue 'rdl_per_type.SelectedValue
            Catch ex As Exception

            End Try
            Try
                If ddl_worker_type.SelectedValue = "12" Or ddl_worker_type.SelectedValue = "15" Then
                    .PHR_MEDICAL_TYPE = 3
                End If
            Catch ex As Exception

            End Try
            Try
                .PHR_TEXT_JOB = txt_PHR_TEXT_JOB.Text
            Catch ex As Exception

            End Try
            Try
                .PHR_MEDICAL_TYPE = ddl_PHR_MEDICAL_TYPE.SelectedValue
            Catch ex As Exception

            End Try
        End With
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.ClsDBDALCN_PHR)
        With dao.fields
            txt_PHR_NAME.Text = .PHR_NAME
            txt_PHR_LEVEL.Text = .PHR_LEVEL
            Try
                ddl_prefix.DropDownSelectData(.PHR_PREFIX_ID)
            Catch ex As Exception

            End Try
            Try
                ddl_job.DropDownSelectData(.PHR_JOB_TYPE)
            Catch ex As Exception

            End Try
            Try
                ddl_law.DropDownSelectData(.PHR_LAW_SECTION)
            Catch ex As Exception

            End Try
            txt_PHR_VETERINARY_FIELD.Text = .PHR_VETERINARY_FIELD
            txt_PHR_CTZNO.Text = .PHR_CTZNO
            txt_PHR_TEXT_NUM.Text = .PHR_TEXT_NUM
            txt_PHR_TEXT_WORK_TIME.Text = .PHR_TEXT_WORK_TIME
            Try
                'rdl_per_type.SelectedValue = .PERSONAL_TYPE
                ddl_worker_type.DropDownSelectData(.PERSONAL_TYPE)
            Catch ex As Exception
                'rdl_per_type.SelectedValue = 1
            End Try
            Try
                txt_PHR_TEXT_JOB.Text = .PHR_TEXT_JOB
            Catch ex As Exception

            End Try
            Try
                ddl_PHR_MEDICAL_TYPE.DropDownSelectData(.PHR_MEDICAL_TYPE)
            Catch ex As Exception

            End Try
        End With
    End Sub
    Public Sub set_data_his(ByRef dao_hs As DAO_DRUG.TB_DALCN_PHR_HISTORY, dao As DAO_DRUG.ClsDBDALCN_PHR)
        With dao_hs.fields
            .ACTIVE_DATE = Date.Now
            .FK_PHR_IDA = Request.QueryString("ida")
            .OLD_PHR_NAME = dao.fields.PHR_NAME
            .NEW_PHR_NAME = txt_PHR_NAME.Text
            .TYPE_INSERT = 6
            .PHR_CITIZEN_ID = dao.fields.PHR_CTZNO
            .PHR_CTZNO = dao.fields.PHR_CTZNO
            .PHR_LEVEL = dao.fields.PHR_LEVEL
            Try
                .PHR_PREFIX_ID = dao.fields.PHR_PREFIX_ID
            Catch ex As Exception

            End Try
            Try
                .PHR_PREFIX_NAME = dao.fields.PHR_PREFIX_NAME
            Catch ex As Exception

            End Try
            .PHR_TEXT_NUM = txt_PHR_TEXT_NUM.Text
            .NEW_PHR_TEXT_NUM = dao.fields.PHR_TEXT_NUM

            .PHR_TEXT_WORK_TIME = dao.fields.PHR_TEXT_WORK_TIME
            .NEW_PHR_TEXT_WORK_TIME = txt_PHR_TEXT_WORK_TIME.Text
            .FK_EDIT_COUNT = Request.QueryString("ida_c")
            .EDIT_TYPE = 12
            Try
                .NEW_JOB_TYPE = dao.fields.PHR_JOB_TYPE
            Catch ex As Exception

            End Try

        End With
    End Sub

    Private Sub ddl_worker_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_worker_type.SelectedIndexChanged
        'bind_lcn_type()
        set_data_sakha()
    End Sub
    Sub set_data_sakha()
        Try
            txt_PHR_VETERINARY_FIELD.Text = ddl_worker_type.SelectedItem.Text
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_PHR_CTZNO.Text
        Catch ex As Exception

        End Try

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
        If dao_syslcnsid.fields.IDA = 0 Then
            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        Else
            Try
                txt_PHR_NAME.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            Catch ex As Exception

            End Try
            Try
                ddl_prefix.DropDownSelectData(ws_taxno.SYSLCNSNMs.prefixcd)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class