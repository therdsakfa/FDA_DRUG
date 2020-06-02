Public Class POPUP_DR_STAFF_RECEIVE_PAPER
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
            _ProcessID = Request.QueryString("Process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            txt_rcvdate.Text = Date.Now.ToShortDateString()
            bind_ddl_rgttpcd()
            bind_tabean_group()
            Try
                lbl_name_staff.Text = set_name_company(_CLS.CITIZEN_ID)
            Catch ex As Exception
                lbl_name_staff.Text = ""
            End Try
        End If
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "-"
        End Try

        Return fullname
    End Function
    Sub bind_tabean_group()
        Dim sql As String = ""
        sql = "select * from dbo.DRRGT_DRUG_GROUP "
        Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
        dao_rqt.GetDataby_IDA(_IDA)
        Dim grptpcd As Integer = 0
        Dim subtpcd As Integer = 0
        Dim fk_lcn_ida As Integer = 0
        Try
            fk_lcn_ida = dao_rqt.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Dim dao_da As New DAO_DRUG.ClsDBdalcn
        dao_da.GetDataby_IDA(fk_lcn_ida)
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao_da.fields.lcntpcd
        Catch ex As Exception

        End Try
        If lcntpcd.Contains("บ") Then
            grptpcd = 2
        Else
            grptpcd = 1
        End If
        If lcntpcd.Contains("นย") Then
            subtpcd = 3
        End If
        Dim sql_where As String = ""
        sql_where = " where grptpcd=" & grptpcd
        If subtpcd = 3 Then
            sql_where &= " and subtpcd = 3"
        Else
            sql_where &= " and subtpcd <> 3"
        End If

        sql &= sql_where
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.Queryds(sql)

        ddl_tabean_group.DataSource = dt
        ddl_tabean_group.DataTextField = "rgttpcd"
        ddl_tabean_group.DataValueField = "rgttpcd"
        ddl_tabean_group.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_tabean_group.Items.Insert(0, item)







    End Sub
    Sub bind_ddl_rgttpcd()

        Dim dao As New DAO_DRUG.ClsDBdrdrgtype 'วงเล็บ
        dao.GetDataAll()
        ddl_rgttpcd.DataSource = dao.datas
        ddl_rgttpcd.DataTextField = "thadrgtpnm"
        ddl_rgttpcd.DataValueField = "drgtpcd"
        ddl_rgttpcd.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_rgttpcd.Items.Insert(0, item)
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
        dao_rqt.GetDataby_IDA(_IDA)
        dao_rqt.fields.STATUS_ID = 10
        Dim bao2 As New BAO.GenNumber
        Dim RCVNO As Integer
        RCVNO = bao2.GEN_NO_07(con_year(Date.Now.Year), _CLS.PVCODE, IIf(IsDBNull(dao_rqt.fields.lcnno), "", dao_rqt.fields.lcnno), dao_rqt.fields.PROCESS_ID, 0, 0, _IDA, "")
        dao_rqt.fields.rcvno = RCVNO
        Try
            dao_rqt.fields.rcvdate = txt_rcvdate.Text
        Catch ex As Exception

        End Try
        Dim rca_no As String = ""
        Try
            rca_no = Txt_rcvno_temp.Text
        Catch ex As Exception

        End Try
        If rca_no.Contains("C") Then
            dao_rqt.fields.C_NO = rca_no
        End If
        If rca_no.Contains("R") Then
            dao_rqt.fields.R_NO = rca_no
        End If
        If rca_no.Contains("A") Then
            dao_rqt.fields.A_NO = rca_no
        End If
        dao_rqt.fields.drgtpcd = ddl_rgttpcd.SelectedValue
        dao_rqt.fields.rgttpcd = ddl_tabean_group.SelectedValue
        dao_rqt.update()

        AddLogStatus(5, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
        alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao_rqt.fields.rcvno)
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class