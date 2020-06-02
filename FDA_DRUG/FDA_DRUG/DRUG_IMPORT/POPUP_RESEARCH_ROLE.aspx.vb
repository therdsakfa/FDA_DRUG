Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_RESEARCH_ROLE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Private _IDA As Integer
    Sub runQuery()
        _Process = "10261"
        _IDA = Request.QueryString("IDA")
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
        Page.MaintainScrollPositionOnPostBack = True
        runQuery()
        RunSession()
        If Not IsPostBack Then
            bindddl()
            load_data()
        End If
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Sub bindddl()

        blind_ddl_chngwt(DropDownList2)
        blind_ddl_chngwt(DropDownList7)
        blind_ddl_chngwt(DropDownList8)
        blind_ddl_chngwt(DropDownList9)

        blind_ddl_country(DropDownList6)
        blind_ddl_country(DropDownList4)
        blind_ddl_country(DropDownList5)
        blind_ddl_country(DropDownList3)

    End Sub

    Sub blind_ddl_chngwt(ByVal ddl As DropDownList)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim item As New ListItem("", "0")

        ddl.DataSource = bao.SP_SYSCHNGWT()
        ddl.DataTextField = "thachngwtnm"
        ddl.DataValueField = "chngwtcd"
        ddl.DataBind()

        ddl.Items.Insert(0, item)
    End Sub

    Sub blind_ddl_country(ByVal ddl As DropDownList)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim item As New ListItem("", "0")

        ddl.DataSource = bao.SP_SYSISOCNT()
        ddl.DataTextField = "thacntnm"
        ddl.DataValueField = "IDA"
        ddl.DataBind()

        ddl.Items.Insert(0, item)
    End Sub

    Sub load_data()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_IDA(_IDA)
        th_spon_group.Text = dao.fields.th_spon_group
        th_spon_addr.Text = dao.fields.th_spon_addr
        th_spon_tel.Text = dao.fields.th_spon_tel
        th_spon_email.Text = dao.fields.th_spon_email_website
        for_spons_groupnm.Text = dao.fields.for_spon_group
        for_spons_addr.Text = dao.fields.for_spon_addr
        for_spons_tel.Text = dao.fields.for_spon_tel
        for_spons_email.Text = dao.fields.for_spon_email_website
        monitor_group.Text = dao.fields.monitor_group
        monitor_addr.Text = dao.fields.monitor_addr
        monitor_tel.Text = dao.fields.monitor_tel
        monitor_email.Text = dao.fields.monitor_email_website
        pm_group.Text = dao.fields.PM_group
        pm_addr.Text = dao.fields.PM_addr
        pm_tel.Text = dao.fields.PM_tel
        pm_email.Text = dao.fields.PM_email_website
        dm_group.Text = dao.fields.DM_group
        dm_addr.Text = dao.fields.DM_addr
        dm_tel.Text = dao.fields.DM_tel
        dm_email.Text = dao.fields.DM_email_website
        If dao.fields.monitor_type = 1 Then
            rb_monitor_type1.Checked = True
        Else
            rb_monitor_type2.Checked = True
        End If
        If dao.fields.PM_type = 1 Then
            rb_pm_type1.Checked = True
        Else
            rb_pm_type2.Checked = True
        End If
        If dao.fields.DM_type = 1 Then
            rb_dm_type1.Checked = True
        Else
            rb_dm_type2.Checked = True
        End If
        thspons_taxno.Text = dao.fields.thspons_taxno
        monitor_taxno.Text = dao.fields.monitor_taxno
        pm_taxno.Text = dao.fields.pm_taxno
        dm_taxno.Text = dao.fields.dm_taxno

        DropDownList2.SelectedValue = dao.fields.th_spon_chngwtcd
        DropDownList3.SelectedValue = dao.fields.for_spon_countrycd
        DropDownList6.SelectedValue = dao.fields.monitor_countrycd
        If DropDownList6.SelectedValue = 171 Then
            chngwt1.Style.Add("display", "inline")
        Else
            chngwt1.Style.Add("display", "none")
        End If
        Try
            DropDownList7.SelectedValue = dao.fields.monitor_chngwtcd
        Catch ex As Exception

        End Try
        DropDownList4.SelectedValue = dao.fields.PM_countrycd
        If DropDownList4.SelectedValue = 171 Then
            chngwt2.Style.Add("display", "inline")
        Else
            chngwt2.Style.Add("display", "none")
        End If
        Try
            DropDownList8.SelectedValue = dao.fields.PM_chngwtcd
        Catch ex As Exception

        End Try
        DropDownList5.SelectedValue = dao.fields.DM_countrycd
        If DropDownList5.SelectedValue = 171 Then
            chngwt3.Style.Add("display", "inline")
        Else
            chngwt3.Style.Add("display", "none")
        End If
        Try
            DropDownList9.SelectedValue = dao.fields.DM_chngwtcd
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_IDA(_IDA)

        Dim dao_log As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM_LOG

        Dim dao_log_last As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM_LOG
        dao_log_last.GetDataby_PJSUM(_IDA)
        Dim times As Integer = 0
        Try
            times = dao_log_last.fields.modified_times + 1
        Catch ex As Exception
            times = times + 1
        End Try

        dao_log.fields.th_spon_group = dao.fields.th_spon_group
        dao_log.fields.th_spon_addr = dao.fields.th_spon_addr
        dao_log.fields.th_spon_tel = dao.fields.th_spon_tel
        dao_log.fields.th_spon_email_website = dao.fields.th_spon_email_website
        dao_log.fields.for_spon_group = dao.fields.for_spon_group
        dao_log.fields.for_spon_addr = dao.fields.for_spon_addr
        dao_log.fields.for_spon_tel = dao.fields.for_spon_tel
        dao_log.fields.for_spon_email_website = dao.fields.for_spon_email_website
        dao_log.fields.monitor_type = dao.fields.monitor_type
        dao_log.fields.monitor_group = dao.fields.monitor_group
        dao_log.fields.monitor_addr = dao.fields.monitor_addr
        dao_log.fields.monitor_tel = dao.fields.monitor_tel
        dao_log.fields.monitor_email_website = dao.fields.monitor_email_website
        dao_log.fields.PM_type = dao.fields.PM_type
        dao_log.fields.PM_group = dao.fields.PM_group
        dao_log.fields.PM_addr = dao.fields.PM_addr
        dao_log.fields.PM_tel = dao.fields.PM_tel
        dao_log.fields.PM_email_website = dao.fields.PM_email_website
        dao_log.fields.DM_type = dao.fields.DM_type
        dao_log.fields.DM_group = dao.fields.DM_group
        dao_log.fields.DM_addr = dao.fields.DM_addr
        dao_log.fields.DM_tel = dao.fields.DM_tel
        dao_log.fields.DM_email_website = dao.fields.DM_email_website
        dao_log.fields.thspons_taxno = dao.fields.thspons_taxno
        dao_log.fields.forspons_taxno = dao.fields.forspons_taxno
        dao_log.fields.monitor_taxno = dao.fields.monitor_taxno
        dao_log.fields.pm_taxno = dao.fields.pm_taxno
        dao_log.fields.dm_taxno = dao.fields.dm_taxno

        dao_log.fields.modified_date = Date.Now
        dao_log.fields.modified_times = times
        dao_log.fields.PJSUM_IDA = _IDA
        dao_log.fields.citizen_modified = _CLS.CITIZEN_ID

        dao_log.insert()

        dao.fields.givedata_times = 2
        dao.fields.givedata_date = Date.Now.ToShortDateString
        dao.fields.th_spon_group = th_spon_group.Text
        dao.fields.th_spon_addr = th_spon_addr.Text
        dao.fields.th_spon_tel = th_spon_tel.Text
        dao.fields.th_spon_email_website = th_spon_email.Text
        dao.fields.thspons_taxno = thspons_taxno.Text
        dao.fields.th_spon_chngwtcd = DropDownList2.SelectedValue
        dao.fields.th_spon_chngwtnm = DropDownList2.SelectedItem.Text
        dao.fields.for_spon_group = for_spons_groupnm.Text
        dao.fields.for_spon_addr = for_spons_addr.Text
        dao.fields.for_spon_tel = for_spons_tel.Text
        dao.fields.for_spon_email_website = for_spons_email.Text
        dao.fields.for_spon_countrycd = DropDownList3.SelectedValue
        dao.fields.for_spon_countrynm = DropDownList3.SelectedItem.Text
        dao.fields.monitor_group = monitor_group.Text
        dao.fields.monitor_addr = monitor_addr.Text
        dao.fields.monitor_tel = monitor_tel.Text
        dao.fields.monitor_email_website = monitor_email.Text
        dao.fields.monitor_taxno = monitor_taxno.Text
        dao.fields.monitor_countrycd = DropDownList6.SelectedValue
        dao.fields.monitor_countrynm = DropDownList6.SelectedItem.Text
        If DropDownList6.SelectedValue = 171 Then 'ประเทศไทย
            dao.fields.monitor_chngwtcd = DropDownList7.SelectedValue
            dao.fields.monitor_chngwtnm = DropDownList7.SelectedItem.Text
        End If
        If rb_monitor_type1.Checked Then
            dao.fields.monitor_type = 1
        ElseIf rb_monitor_type2.Checked Then
            dao.fields.monitor_type = 2
        End If

        dao.fields.PM_group = pm_group.Text
        dao.fields.PM_addr = pm_addr.Text
        dao.fields.PM_tel = pm_tel.Text
        dao.fields.PM_email_website = pm_email.Text
        dao.fields.pm_taxno = pm_taxno.Text
        dao.fields.PM_countrycd = DropDownList4.SelectedValue
        dao.fields.PM_countrynm = DropDownList4.SelectedItem.Text
        If DropDownList4.SelectedValue = 171 Then 'ประเทศไทย
            dao.fields.PM_chngwtcd = DropDownList8.SelectedValue
            dao.fields.PM_chngwtnm = DropDownList8.SelectedItem.Text
        End If
        If rb_pm_type1.Checked Then
            dao.fields.PM_type = 1
        ElseIf rb_pm_type2.Checked Then
            dao.fields.PM_type = 2
        End If

        dao.fields.DM_group = dm_group.Text
        dao.fields.DM_addr = dm_addr.Text
        dao.fields.DM_tel = dm_tel.Text
        dao.fields.DM_email_website = dm_email.Text
        dao.fields.dm_taxno = dm_taxno.Text
        dao.fields.DM_countrycd = DropDownList5.SelectedValue
        dao.fields.DM_countrynm = DropDownList5.SelectedItem.Text
        If DropDownList5.SelectedValue = 171 Then 'ประเทศไทย
            dao.fields.DM_chngwtcd = DropDownList9.SelectedValue
            dao.fields.DM_chngwtnm = DropDownList9.SelectedItem.Text
        End If
        If rb_dm_type1.Checked Then
            dao.fields.DM_type = 1
        ElseIf rb_dm_type2.Checked Then
            dao.fields.DM_type = 2
        End If

        dao.update()

        alert("บันทึกเรียบร้อย")
    End Sub

    Protected Sub DropDownList4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList4.SelectedIndexChanged
        If DropDownList4.SelectedValue = 171 Then
            chngwt2.Style.Add("display", "inline")
        Else
            chngwt2.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub DropDownList5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList5.SelectedIndexChanged
        If DropDownList5.SelectedValue = 171 Then
            chngwt3.Style.Add("display", "inline")
        Else
            chngwt3.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub DropDownList6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList6.SelectedIndexChanged
        If DropDownList6.SelectedValue = 171 Then
            chngwt1.Style.Add("display", "inline")
        Else
            chngwt1.Style.Add("display", "none")
        End If
    End Sub
End Class