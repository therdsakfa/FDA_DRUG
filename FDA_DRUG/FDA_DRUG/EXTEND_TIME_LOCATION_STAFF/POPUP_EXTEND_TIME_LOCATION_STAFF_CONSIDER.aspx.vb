Public Class POPUP_STAFF_EXTEND_TIME_LOCATION_CONSIDER2
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            TextBox1.Text = Date.Now.ToShortDateString()
            'txt_app_date.Text = Date.Now.ToShortDateString()
            default_Remark()
            Bind_ddl_staff_offer()
        End If
    End Sub

    Private Sub default_Remark()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim dao_extend As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao_extend.GetDataby_IDA(_IDA)
        dao.GetDataby_IDA(dao_extend.fields.FK_IDA)
        dao_up.GetDataby_IDA(dao_extend.fields.TR_ID)

        Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
        Dim GROUP_TYPE As String = dao.fields.GROUP_TYPE
        If PROCESS_ID = 14200053 And GROUP_TYPE = "2" Then
            Txt_Remark.Text = ""
        End If



    End Sub
    Public Sub Bind_ddl_staff_offer()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_STAFF_OFFER_DDL_ex()

        ddl_staff_offer.DataSource = bao.dt
        ddl_staff_offer.DataBind()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.GenNumber

            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(_TR_ID)

            AddLogStatus(9, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

            Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID

            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_Process_ID(PROCESS_ID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

            Dim CONSIDER_DATE As Date = CDate(TextBox1.Text)
            dao.fields.remark = Txt_Remark.Text
            dao.fields.STATUS_ID = 9
            dao.fields.CONSIDER_DATE = CONSIDER_DATE
            dao.fields.OFF_CITIZEN = _CLS.CITIZEN_ID
            dao.fields.OFFICER_NAME = set_name_company(_CLS.CITIZEN_ID)
            dao.fields.FK_STAFF_OFFER_IDA = ddl_staff_offer.SelectedValue
            dao.fields.ALLOW_NAME = ddl_staff_offer.SelectedValue

            Dim dao_officer As New DAO_DRUG.TB_MAS_STAFF_OFFER
            dao_officer.GetDataby_IDA(dao.fields.FK_STAFF_OFFER_IDA)
            dao.fields.ALLOW_NAME = dao_officer.fields.STAFF_OFFER_NAME
            Try
                dao.fields.ALLOW_CITIZEN = dao_officer.fields.INSERT_CITIZEN
            Catch ex As Exception

            End Try

            'Try
            'dao.fields.app_date = CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try
            dao.update()


            alert("บันทึกข้อมูลเรียบร้อย")
            'Try
            '    Dim ws As New AUTHEN_LOG.Authentication
            '    Dim dao_process As New DAO_DRUG.ClsDBPROCESS_NAME

            '    dao_process.GetDataby_Process_ID(_process)
            '    AddLogStatusEtracking(9, 0, _CLS.CITIZEN_ID, "ยื่นเสนอลงนามคำขอระบบต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao.fields.FK_IDA, dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)

            '    ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ยื่นเสนอลงนามคำขอระบบต่ออายุ", _process)

            'Catch ex As Exception

            'End Try
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "-"
        End Try

        Return fullname
    End Function
End Class