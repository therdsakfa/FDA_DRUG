Public Class FRM_TABEAN_MAIN_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _NYM As String = ""
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Private _process As String = ""
    Sub runQuery()
        _NYM = Request.QueryString("type")
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
        _process = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_lcnno()
        runQuery()
        set_name()
        If Not IsPostBack Then
            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้งานหน้าพิจารณาคำขอ ย.1 สำหรับเจ้าหน้าที่", "")
            Dim ws_118 As New WS_AUTHENTICATION.Authentication
            Dim ws_66 As New Authentication_66.Authentication
            Dim ws_104 As New AUTHENTICATION_104.Authentication
            Try
                ws_118.Timeout = 10000
                ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้งานหน้าพิจารณาคำขอ ย.1 สำหรับเจ้าหน้าที่", _process)
            Catch ex As Exception
                Try
                    ws_66.Timeout = 10000
                    ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้งานหน้าพิจารณาคำขอ ย.1 สำหรับเจ้าหน้าที่", _process)

                Catch ex2 As Exception
                    Try
                        ws_104.Timeout = 10000
                        ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เข้าใช้งานหน้าพิจารณาคำขอ ย.1 สำหรับเจ้าหน้าที่", _process)

                    Catch ex3 As Exception
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    End Try
                End Try
            End Try
            load_GV_Tabean()
            load_GV_Drug_EX()
        End If
    End Sub
    Sub load_lcnno()
        lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Private Sub set_name()
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_FK_IDA(_IDA)

        Try
            lb_th_name.Text = dao.fields.thadrgnm
        Catch ex As Exception

        End Try
        Try
            lb_eng_name.Text = dao.fields.engdrgnm
        Catch ex As Exception

        End Try

        Dim dao_stat As New DAO_DRUG.ClsDBMAS_STATUS
        Try
            dao_stat.GetDataby_IDA_Group(dao.fields.STATUS_ID, _process)
        Catch ex As Exception

        End Try
        Try
            lb_stat.Text = dao_stat.fields.STATUS_NAME
        Catch ex As Exception
            lb_stat.Text = "-"
        End Try

    End Sub

    Sub load_GV_Tabean()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao_DB.SP_DRSAMP_TABEAN_BY_FK_IDA(_IDA)
        GV_Tabean.DataSource = bao_DB.dt
        GV_Tabean.DataBind()
    End Sub
    Sub load_GV_Drug_EX()
        Dim bao As New BAO.ClsDBSqlcommand
        'ยาตัวอย่าง
        bao.SP_DRSAMP_BY_IDA(_IDA)
        GV_Drug_EX.DataSource = bao.dt
        GV_Drug_EX.DataBind()
    End Sub

    Private Sub GV_Tabean_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_Tabean.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_Tabean.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_TABEAN_CONFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

        End If
    End Sub

    Private Sub GV_Tabean_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_Tabean.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_Tabean.DataKeys.Item(index).Value.ToString()
            Dim stat As String = e.Row.Cells(0).Text 'GV_data.Rows(index).Cells(0).Text
        End If
    End Sub
    Private Sub GV_Drug_EX_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_Drug_EX.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_Drug_EX.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_DRUG_EX_CONFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)
        ElseIf e.CommandName = "sel" Then

        End If
    End Sub

End Class