Public Class UC_BSN_NAME
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_BSN)
        dao.fields.BSN_IDENTIFY = txt_BSN_IDENTIFY.Text
        dao.fields.BSN_PREFIXTHAICD = ddl_prefix.SelectedValue
        dao.fields.BSN_THAINAME = txt_BSN_THAINAME.Text
        dao.fields.BSN_THAILASTNAME = txt_BSN_THAILASTNAME.Text
        dao.fields.BSN_ENGNAME = txt_BSN_ENGNAME.Text
        dao.fields.BSN_ENGLASTNAME = txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_ENGFULLNAME = lbl_engprefixnm.Text & txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text
    End Sub

    Public Sub set_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)
        dao.fields.BSN_IDENTIFY = txt_BSN_IDENTIFY.Text
        dao.fields.BSN_PREFIXTHAICD = ddl_prefix.SelectedValue
        dao.fields.BSN_THAINAME = txt_BSN_THAINAME.Text
        dao.fields.BSN_THAILASTNAME = txt_BSN_THAILASTNAME.Text
        dao.fields.BSN_ENGNAME = txt_BSN_ENGNAME.Text
        dao.fields.BSN_ENGLASTNAME = txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_ENGFULLNAME = lbl_engprefixnm.Text & txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text


        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_BSN_IDENTIFY.Text
        Catch ex As Exception

        End Try

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

        Try
            dao.fields.bsnid = dao_syslcnsid.fields.lcnsid
        Catch ex As Exception

        End Try
    End Sub
    Public Sub get_data(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_BSN)
        lb_BSN_IDENTIFY.Text = dao.fields.BSN_IDENTIFY
        Dim dao_pre As New DAO_CPN.TB_sysprefix
        Try
            dao_pre.Getdata_byid(dao.fields.BSN_PREFIXTHAICD)
            lb_prefix.Text = dao_pre.fields.thanm
        Catch ex As Exception
            lb_prefix.Text = "-"
        End Try
        lb_BSN_THAINAME.Text = dao.fields.BSN_THAINAME
        lb_BSN_THAILASTNAME.Text = dao.fields.BSN_THAILASTNAME
        lb_BSN_ENGNAME.Text = dao.fields.BSN_ENGNAME
        lb_BSN_ENGLASTNAME.Text = dao.fields.BSN_ENGLASTNAME
        'dao.fields.BSN_ENGFULLNAME = lbl_engprefixnm.Text & txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        'dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text
    End Sub
    Public Sub set_data_bsn(ByRef dao As DAO_DRUG.TB_DALCN_LOCATION_BSN)
        dao.fields.BSN_IDENTIFY = txt_BSN_IDENTIFY.Text
        dao.fields.BSN_PREFIXTHAICD = ddl_prefix.SelectedValue

        dao.fields.BSN_THAINAME = txt_BSN_THAINAME.Text
        dao.fields.BSN_THAILASTNAME = txt_BSN_THAILASTNAME.Text
        dao.fields.BSN_ENGNAME = txt_BSN_ENGNAME.Text
        dao.fields.BSN_ENGLASTNAME = txt_BSN_ENGLASTNAME.Text
        '
        Try
            dao.fields.BSN_ENGFULLNAME = txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        Catch ex As Exception

        End Try
        Try
            dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text
        Catch ex As Exception

        End Try
    End Sub
    Public Sub get_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)
        lb_BSN_IDENTIFY.Text = dao.fields.BSN_IDENTIFY
        Dim dao_pre As New DAO_CPN.TB_sysprefix
        Try
            dao_pre.Getdata_byid(dao.fields.syslcnsnm_prefixcd)
            lb_prefix.Text = dao_pre.fields.thanm
        Catch ex As Exception
            lb_prefix.Text = "-"
        End Try

        '-------------------------------------------------
        lb_BSN_THAINAME.Text = dao.fields.BSN_THAINAME
        lb_BSN_THAILASTNAME.Text = dao.fields.BSN_THAILASTNAME
        lb_BSN_ENGNAME.Text = dao.fields.BSN_ENGNAME
        lb_BSN_ENGLASTNAME.Text = dao.fields.BSN_ENGLASTNAME

        txt_BSN_IDENTIFY.Text = dao.fields.BSN_IDENTIFY
   
        txt_BSN_THAINAME.Text = dao.fields.BSN_THAINAME
        txt_BSN_THAILASTNAME.Text = dao.fields.BSN_THAILASTNAME
        txt_BSN_ENGNAME.Text = dao.fields.BSN_ENGNAME
        txt_BSN_ENGLASTNAME.Text = dao.fields.BSN_ENGLASTNAME
        'dao.fields.BSN_ENGFULLNAME = lbl_engprefixnm.Text & txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        'dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text
    End Sub
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        dao.fields.BSN_IDENTIFY_OLD = dao2.fields.BSN_IDENTIFY
        dao.fields.BSN_PREFIXTHAICD_OLD = dao2.fields.BSN_PREFIXTHAICD
        dao.fields.BSN_THAINAME_OLD = dao2.fields.BSN_THAINAME
        dao.fields.BSN_THAILASTNAME_OLD = dao2.fields.BSN_THAILASTNAME
        dao.fields.BSN_ENGNAME_OLD = dao2.fields.BSN_ENGNAME
        dao.fields.BSN_ENGLASTNAME_OLD = dao2.fields.BSN_ENGLASTNAME
        dao.fields.BSN_ENGFULLNAME_OLD = dao2.fields.BSN_ENGFULLNAME
        dao.fields.BSN_THAIFULLNAME_OLD = dao2.fields.BSN_THAIFULLNAME

        dao.fields.BSN_IDENTIFY = txt_BSN_IDENTIFY.Text
        dao.fields.BSN_PREFIXTHAICD = ddl_prefix.SelectedValue
        dao.fields.BSN_THAINAME = txt_BSN_THAINAME.Text
        dao.fields.BSN_THAILASTNAME = txt_BSN_THAILASTNAME.Text
        dao.fields.BSN_ENGNAME = txt_BSN_ENGNAME.Text
        dao.fields.BSN_ENGLASTNAME = txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_ENGFULLNAME = lbl_engprefixnm.Text & txt_BSN_ENGNAME.Text & " " & txt_BSN_ENGLASTNAME.Text
        dao.fields.BSN_THAIFULLNAME = ddl_prefix.SelectedItem.Text & txt_BSN_THAINAME.Text & " " & txt_BSN_THAILASTNAME.Text

        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_BSN_IDENTIFY.Text
        Catch ex As Exception

        End Try

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

        Try
            dao.fields.bsnid_new = dao_syslcnsid.fields.lcnsid
        Catch ex As Exception

        End Try
        Try
            dao.fields.bsnid_old = dao2.fields.lcnsid
        Catch ex As Exception

        End Try



    End Sub


    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub
    Private Sub ddl_prefix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_prefix.SelectedIndexChanged
        bind_lbl()
    End Sub
    Public Sub bind_lbl()
        Dim dao As New DAO_CPN.TB_sysprefix
        Try
            dao.Getdata_byid(ddl_prefix.SelectedValue)
            lbl_engprefixnm.Text = dao.fields.engnm
        Catch ex As Exception
            lbl_engprefixnm.Text = ""
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim ws_taxno As New WS_Taxno_TaxnoAuthorize.WebService1
        
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_BSN_IDENTIFY.Text
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
                txt_BSN_THAINAME.Text = ws_taxno.SYSLCNSNMs.thanm
                txt_BSN_THAILASTNAME.Text = ws_taxno.SYSLCNSNMs.thalnm
                txt_BSN_ENGNAME.Text = ws_taxno.SYSLCNSNMs.engnm
                txt_BSN_ENGLASTNAME.Text = ws_taxno.SYSLCNSNMs.englnm
            Catch ex As Exception

            End Try

        End If

        'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
        'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

        'Dim LCNSID_CUSTOMER As String = dao_syslcnsid.fields.lcnsid



        'Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

        'Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        'Dim fullname As String = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        'Dim THANM_CUSTOMER As String = fullname
    End Sub
End Class