Public Class UC_BSN_SUSTAIN
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try

        If _CLS Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RunSession()
        If Not IsPostBack Then
            bind_label()
            txt_PASS_AWAY_DATE.Text = Date.Now.ToShortDateString()
            set_ddl_place()
            bind_location_old()
            bind_lcns()
            set_bsn_location_old()
        End If
    End Sub
    Sub bind_lcns()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
            Dim dao_lc As New DAO_CPN.clsDBsyslcnsnm
            dao_lc.GetDataby_lcnsid(dao.fields.lcnsid)
            Try
                lbl_lcnsnm_old.Text = dao_lc.fields.thanm & " " & dao_lc.fields.thalnm
            Catch ex As Exception

            End Try
            Try
                hf_lcn.Value = dao_lc.fields.lcnsid
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

      
    End Sub
    Sub bind_location_old()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
        Catch ex As Exception

        End Try
        Try
            ' dt = bao.SP_BSN_LOCATION_ADDRESS_BY_IDA(dao.fields.FK_IDA)
            dt = bao.SP_LOCATION_ADDRESS_BY_IDA(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try
        Try
            For Each dr As DataRow In dt.Rows
                lbl_location_old.Text = dr("fulladdr")
                lbl_thanameplace_old.Text = dr("nameplace")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub set_bsn_location_old()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("ida"))
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            'dao_bsn.Getdata_by_fk_id2(dao.fields.FK_IDA)
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_BSN_LOCATION_ADDRESS_BY_IDA_V2(Request.QueryString("ida"))

            For Each dr As DataRow In dt.Rows
                lbl_old_addr.Text = dr("fulladdr")
            Next
        Catch ex As Exception

        End Try

        'Try
        '    dao_bsn.Getdata_by_iden()
        'Catch ex As Exception

        'End Try
    End Sub
    Sub set_ddl_place()
        Dim iden As String = ""
        Try
            iden = Request.QueryString("iden")
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_LOCATION_ADDRESS_BY_IDENTIFY(iden)
        dt = bao.SP_DALCN_LOCATION_ADDRESS_BY_IDENTIFY(iden)
        ddl_placename.DataSource = dt
        ddl_placename.DataValueField = "IDA"
        ddl_placename.DataTextField = "thanameplace"
        ddl_placename.DataBind()

        Dim item As New ListItem("", "0")
        ddl_placename.Items.Insert(0, item)
    End Sub
    Sub bind_label()
        Dim dao_dal As New DAO_DRUG.ClsDBdalcn
        Try
            dao_dal.GetDataby_IDA(Request.QueryString("ida"))
        Catch ex As Exception

        End Try
        Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        Try
            dao_la.GetDataby_IDA(dao_dal.fields.FK_IDA)
            lbl_thanameplace_old.Text = dao_la.fields.thanameplace
        Catch ex As Exception

        End Try

    End Sub
    Public Sub set_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)
        For i As Integer = 0 To rdl_change.Items.Count - 1
            If rdl_change.Items(i).Selected = True Then
                If rdl_change.Items(i).Value = "1" Then
                    Try
                        dao.fields.lcnsid = hf_lcn.Value
                    Catch ex As Exception

                    End Try
                ElseIf rdl_change.Items(i).Value = "2" Then
                    Try
                        dao.fields.FK_IDA = hf_place.Value
                    Catch ex As Exception

                    End Try
                ElseIf rdl_change.Items(i).Value = "3" Then
                    Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                    dao_bsn.Getdata_by_iden(txt_ctzid.Text)
                    For Each dao_bsn.fields In dao_bsn.datas
                        dao.fields.BSN_IDENTIFY = txt_ctzid.Text
                        dao.fields.BSN_PREFIXTHAICD = dao_bsn.fields.BSN_PREFIXTHAICD
                        dao.fields.BSN_THAINAME = dao_bsn.fields.BSN_THAINAME
                        dao.fields.BSN_THAILASTNAME = dao_bsn.fields.BSN_THAILASTNAME
                        dao.fields.BSN_ENGNAME = dao_bsn.fields.BSN_ENGNAME
                        dao.fields.BSN_ENGLASTNAME = dao_bsn.fields.BSN_ENGLASTNAME
                        dao.fields.BSN_ENGFULLNAME = dao_bsn.fields.BSN_ENGFULLNAME
                        dao.fields.BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
                        Try
                            dao.fields.bsnid = dao_bsn.fields.BSNID
                        Catch ex As Exception

                        End Try

                        Dim CITIZEN_ID_AUTHORIZE As String = ""
                        Try
                            CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
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

                        'tha
                        dao.fields.BSN_HOUSENO = dao_bsn.fields.BSN_HOUSENO
                        dao.fields.BSN_ADDR = dao_bsn.fields.BSN_ENGADDR
                        dao.fields.BSN_MOO = dao_bsn.fields.BSN_MOO
                        dao.fields.BSN_SOI = dao_bsn.fields.BSN_SOI
                        dao.fields.BSN_ROAD = dao_bsn.fields.BSN_ROAD
                        dao.fields.BSN_CHWNGNAME = dao_bsn.fields.BSN_CHWNGNAME
                        dao.fields.CHANGWAT_ID = dao_bsn.fields.CHANGWAT_ID
                        dao.fields.AMPHR_ID = dao_bsn.fields.AMPHR_ID
                        dao.fields.BSN_AMPHR_NAME = dao_bsn.fields.BSN_AMPHR_NAME
                        dao.fields.BSN_THMBL_NAME = dao_bsn.fields.BSN_THMBL_NAME
                        dao.fields.TUMBON_ID = dao_bsn.fields.TUMBON_ID
                        dao.fields.BSN_TELEPHONE = dao_bsn.fields.BSN_TELEPHONE
                        dao.fields.BSN_FAX = dao_bsn.fields.BSN_FAX

                        ''eng
                        dao.fields.BSN_ENGADDR = dao_bsn.fields.BSN_ENGADDR
                        dao.fields.BSN_FLOOR = dao_bsn.fields.BSN_FLOOR
                        dao.fields.BSN_ENGMU = dao_bsn.fields.BSN_ENGMU
                        dao.fields.BSN_ENGSOI = dao_bsn.fields.BSN_ENGSOI
                        dao.fields.BSN_ENGROAD = dao_bsn.fields.BSN_ENGROAD
                        dao.fields.BSN_CHWNG_ENGNAME = dao_bsn.fields.BSN_CHWNG_ENGNAME
                        dao.fields.BSN_AMPHR_ENGNAME = dao_bsn.fields.BSN_AMPHR_ENGNAME
                        dao.fields.BSN_THMBL_ENGNAME = dao_bsn.fields.BSN_THMBL_ENGNAME

                    Next
                End If
            End If
        Next

        


    End Sub
    Public Sub set_data_his(ByRef dao As DAO_DRUG.TB_EDT_HISTORY, ByRef dao2 As DAO_DRUG.ClsDBdalcn)
        dao.fields.SUSTAIN_TYPE = rdl_type.SelectedValue
        For i As Integer = 0 To rdl_change.Items.Count - 1
            If rdl_change.Items(i).Selected = True Then
                If rdl_change.Items(i).Value = "1" Then
                    dao.fields.CHK_SUSTAIN1 = True
                    dao.fields.lcnsid_old = dao2.fields.lcnsid
                    dao.fields.lcnsid_new = hf_lcn.Value

                    Dim dao_lcn As New DAO_CPN.clsDBsyslcnsnm
                    dao_lcn.GetDataby_lcnsid(dao2.fields.lcnsid)

                    Dim dao_pre As New DAO_CPN.TB_sysprefix

                    Dim prefix1 As String = ""
                    Dim prefix2 As String = ""
                    Try
                        dao_pre.Getdata_byid(dao_lcn.fields.prefixcd)
                        prefix1 = dao_pre.fields.thanm
                    Catch ex As Exception

                    End Try

                    Try
                        dao.fields.BSN_THAIFULLNAME_OLD = prefix1 & dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
                    Catch ex As Exception

                    End Try

                    dao_lcn = New DAO_CPN.clsDBsyslcnsnm
                    dao_lcn.GetDataby_lcnsid(hf_lcn.Value)

                    dao_pre = New DAO_CPN.TB_sysprefix
                    Try
                        dao_pre.Getdata_byid(dao_lcn.fields.prefixcd)
                        prefix2 = dao_pre.fields.thanm
                    Catch ex As Exception

                    End Try

                    Try
                        dao.fields.BSN_THAIFULLNAME = prefix2 & dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
                    Catch ex As Exception

                    End Try

                ElseIf rdl_change.Items(i).Value = "2" Then
                    dao.fields.CHK_SUSTAIN2 = True
                    dao.fields.LCT_IDA_OLD = dao2.fields.FK_IDA
                    Try
                        dao.fields.LCT_IDA_NEW = hf_place.Value
                    Catch ex As Exception

                    End Try


                    dao.fields.ADDR_OLD = lbl_location_old.Text
                    dao.fields.ADDR_NEW = lbl_location_new.Text
                    dao.fields.thanameplace_OLD = lbl_thanameplace_old.Text
                    dao.fields.thanameplace = ddl_placename.SelectedItem.Text
                ElseIf rdl_change.Items(i).Value = "3" Then
                    Try
                        dao.fields.PASS_AWAY_DATE = CDate(txt_PASS_AWAY_DATE.Text)
                    Catch ex As Exception

                    End Try

                    dao.fields.CHK_SUSTAIN3 = True
                    dao.fields.BSN_IDENTIFY_OLD = dao2.fields.BSN_IDENTIFY
                    dao.fields.BSN_PREFIXTHAICD_OLD = dao2.fields.BSN_PREFIXTHAICD
                    dao.fields.BSN_THAINAME_OLD = dao2.fields.BSN_THAINAME
                    dao.fields.BSN_THAILASTNAME_OLD = dao2.fields.BSN_THAILASTNAME
                    dao.fields.BSN_ENGNAME_OLD = dao2.fields.BSN_ENGNAME
                    dao.fields.BSN_ENGLASTNAME_OLD = dao2.fields.BSN_ENGLASTNAME
                    dao.fields.BSN_ENGFULLNAME_OLD = dao2.fields.BSN_ENGFULLNAME
                    dao.fields.BSN_THAIFULLNAME_OLD = dao2.fields.BSN_THAIFULLNAME
                    dao.fields.BSN_HOUSENO_OLD = dao2.fields.BSN_HOUSENO
                    dao.fields.BSN_ADDR_OLD = dao2.fields.BSN_ENGADDR
                    dao.fields.BSN_MOO_OLD = dao2.fields.BSN_MOO
                    dao.fields.BSN_SOI_OLD = dao2.fields.BSN_SOI
                    dao.fields.BSN_ROAD_OLD = dao2.fields.BSN_ROAD
                    dao.fields.BSN_CHWNGNAME_OLD = dao2.fields.BSN_CHWNGNAME
                    dao.fields.CHANGWAT_ID_OLD = dao2.fields.CHANGWAT_ID
                    dao.fields.AMPHR_ID_OLD = dao2.fields.AMPHR_ID
                    dao.fields.BSN_AMPHR_NAME_OLD = dao2.fields.BSN_AMPHR_NAME
                    dao.fields.BSN_THMBL_NAME_OLD = dao2.fields.BSN_THMBL_NAME
                    dao.fields.TUMBON_ID_OLD = dao2.fields.TUMBON_ID
                    dao.fields.BSN_TELEPHONE_OLD = dao2.fields.BSN_TELEPHONE
                    dao.fields.BSN_FAX_OLD = dao2.fields.BSN_FAX

                    ''eng
                    dao.fields.BSN_ENGADDR_OLD = dao2.fields.BSN_ENGADDR
                    dao.fields.BSN_FLOOR_OLD = dao2.fields.BSN_ENGADDR
                    dao.fields.BSN_ENGMU_OLD = dao2.fields.BSN_ENGMU
                    dao.fields.BSN_ENGSOI_OLD = dao2.fields.BSN_ENGSOI
                    dao.fields.BSN_ENGROAD_OLD = dao2.fields.BSN_ENGROAD
                    dao.fields.BSN_CHWNG_ENGNAME_OLD = dao2.fields.BSN_CHWNG_ENGNAME
                    dao.fields.BSN_AMPHR_ENGNAME_OLD = dao2.fields.BSN_AMPHR_ENGNAME
                    dao.fields.BSN_THMBL_ENGNAME_OLD = dao2.fields.BSN_THMBL_ENGNAME


                    Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
                    dao_bsn.Getdata_by_iden(txt_ctzid.Text)
                    For Each dao_bsn.fields In dao_bsn.datas
                        'dao.fields.BSN_IDENTIFY = txt_ctzid.Text
                        'dao.fields.BSN_PREFIXTHAICD = dao_bsn.fields.BSN_PREFIXTHAICD
                        'dao.fields.BSN_THAINAME = dao_bsn.fields.BSN_THAINAME
                        'dao.fields.BSN_THAILASTNAME = dao_bsn.fields.BSN_THAILASTNAME
                        'dao.fields.BSN_ENGNAME = dao_bsn.fields.BSN_ENGNAME
                        'dao.fields.BSN_ENGLASTNAME = dao_bsn.fields.BSN_ENGLASTNAME
                        'dao.fields.BSN_ENGFULLNAME = dao_bsn.fields.BSN_ENGFULLNAME
                        'dao.fields.BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
                        Dim CITIZEN_ID_AUTHORIZE As String = ""
                        Try
                            CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
                        Catch ex As Exception

                        End Try

                        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
                        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

                        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
                        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

                        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
                        dao_syslcnsnm.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
                        'tha
                        dao.fields.BSN_IDENTIFY = CITIZEN_ID_AUTHORIZE
                        Try
                            dao.fields.BSN_PREFIXTHAICD = dao_syslcnsnm.fields.prefixcd
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.BSN_THAINAME = dao_syslcnsnm.fields.thanm
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.BSN_THAILASTNAME = dao_syslcnsnm.fields.thalnm
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.BSN_ENGNAME = dao_syslcnsnm.fields.engnm
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.BSN_ENGLASTNAME = dao_syslcnsnm.fields.englnm
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.BSN_ENGFULLNAME = dao_syslcnsnm.fields.engnm & " " & dao_syslcnsnm.fields.englnm
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.BSN_THAIFULLNAME = dao_syslcnsnm.fields.thanm & " " & dao_syslcnsnm.fields.thalnm
                        Catch ex As Exception

                        End Try


                        dao.fields.BSN_HOUSENO = dao_bsn.fields.BSN_HOUSENO
                        dao.fields.BSN_ADDR = dao_bsn.fields.BSN_ENGADDR
                        dao.fields.BSN_MOO = dao_bsn.fields.BSN_MOO
                        dao.fields.BSN_SOI = dao_bsn.fields.BSN_SOI
                        dao.fields.BSN_ROAD = dao_bsn.fields.BSN_ROAD
                        dao.fields.BSN_CHWNGNAME = dao_bsn.fields.BSN_CHWNGNAME
                        dao.fields.CHANGWAT_ID = dao_bsn.fields.CHANGWAT_ID
                        dao.fields.AMPHR_ID = dao_bsn.fields.AMPHR_ID
                        dao.fields.BSN_AMPHR_NAME = dao_bsn.fields.BSN_AMPHR_NAME
                        dao.fields.BSN_THMBL_NAME = dao_bsn.fields.BSN_THMBL_NAME
                        dao.fields.TUMBON_ID = dao_bsn.fields.TUMBON_ID
                        dao.fields.BSN_TELEPHONE = dao_bsn.fields.BSN_TELEPHONE
                        dao.fields.BSN_FAX = dao_bsn.fields.BSN_FAX

                        ''eng
                        dao.fields.BSN_ENGADDR = dao_bsn.fields.BSN_ENGADDR
                        dao.fields.BSN_FLOOR = dao_bsn.fields.BSN_FLOOR
                        dao.fields.BSN_ENGMU = dao_bsn.fields.BSN_ENGMU
                        dao.fields.BSN_ENGSOI = dao_bsn.fields.BSN_ENGSOI
                        dao.fields.BSN_ENGROAD = dao_bsn.fields.BSN_ENGROAD
                        dao.fields.BSN_CHWNG_ENGNAME = dao_bsn.fields.BSN_CHWNG_ENGNAME
                        dao.fields.BSN_AMPHR_ENGNAME = dao_bsn.fields.BSN_AMPHR_ENGNAME
                        dao.fields.BSN_THMBL_ENGNAME = dao_bsn.fields.BSN_THMBL_ENGNAME
                    Next
                End If
            End If

        Next

        'Try
        '    dao.fields.CHK_SUSTAIN1 = cbl_change.SelectedValue
        'Catch ex As Exception

        'End Try
        'Try
        '    dao.fields.CHK_SUSTAIN2 = cbl_change.SelectedValue
        'Catch ex As Exception

        'End Try
        

        'dao.fields.thaname
        ''tha
        'dao.fields.BSN_HOUSENO = dao2.fields.BSN_HOUSENO
        'dao.fields.BSN_ADDR = dao2.fields.BSN_ENGADDR
        'dao.fields.BSN_MOO = dao2.fields.BSN_MOO
        'dao.fields.BSN_SOI = dao2.fields.BSN_SOI
        'dao.fields.BSN_ROAD = dao2.fields.BSN_ROAD
        'dao.fields.BSN_CHWNGNAME = dao2.fields.BSN_CHWNGNAME
        'dao.fields.CHANGWAT_ID = dao2.fields.CHANGWAT_ID
        'dao.fields.AMPHR_ID = dao2.fields.AMPHR_ID
        'dao.fields.BSN_AMPHR_NAME = dao2.fields.BSN_AMPHR_NAME
        'dao.fields.BSN_THMBL_NAME = dao2.fields.BSN_THMBL_NAME
        'dao.fields.TUMBON_ID = dao2.fields.TUMBON_ID
        'dao.fields.BSN_TELEPHONE = dao2.fields.BSN_TELEPHONE
        'dao.fields.BSN_FAX = dao2.fields.BSN_FAX

        ' ''eng
        'dao.fields.BSN_ENGADDR = dao2.fields.BSN_ENGADDR
        'dao.fields.BSN_FLOOR = dao2.fields.BSN_ENGADDR
        'dao.fields.BSN_ENGMU = dao2.fields.BSN_ENGMU
        'dao.fields.BSN_ENGSOI = dao2.fields.BSN_ENGSOI
        'dao.fields.BSN_ENGROAD = dao2.fields.BSN_ENGROAD
        'dao.fields.BSN_CHWNG_ENGNAME = dao2.fields.BSN_CHWNG_ENGNAME
        'dao.fields.BSN_AMPHR_ENGNAME = dao2.fields.BSN_AMPHR_ENGNAME
        'dao.fields.BSN_THMBL_ENGNAME = dao2.fields.BSN_THMBL_ENGNAME
        '---------------------------------------------------------
        'tha

    End Sub
    Public Sub bind_old_name()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
            lbl_old_bsn.Text = dao.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
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
                lbl_new_bsn.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("ida"))
            Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
            Try
                'dao_bsn.Getdata_by_fk_id2(dao.fields.FK_IDA)
                Dim bao As New BAO.ClsDBSqlcommand
                Dim dt As New DataTable
                dt = bao.SP_BSN_LOCATION_ADDRESS_BY_IDEN(CITIZEN_ID_AUTHORIZE)

                For Each dr As DataRow In dt.Rows
                    lbl_new_addr.Text = dr("fulladdr")
                Next
            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub btn_search_lcn_Click(sender As Object, e As EventArgs) Handles btn_search_lcn.Click
        Dim dao_lcn As New DAO_CPN.clsDBsyslcnsnm
        dao_lcn.GetDataby_identify(txt_ctzid_lcn.Text)

        Dim dao_lcnsid As New DAO_CPN.tb_lcnsid
        dao_lcnsid.GetData_ByIdentify(txt_ctzid_lcn.Text)
        Dim name As String = "0"
        Try
            name = dao_lcn.fields.ID
        Catch ex As Exception

        End Try
        If name = "0" Then
            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script>")
        Else
            Try
                lbl_lcnname_new.Text = dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
            Catch ex As Exception

            End Try
            Try
                hf_lcn.Value = dao_lcnsid.fields.lcnsid
            Catch ex As Exception

            End Try
        End If

    End Sub

    'Private Sub cbl_change_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbl_change.SelectedIndexChanged
    '    For Each item As ListItem In cbl_change.Items
    '        If item.Value = "1" Then
    '            Panel1.Style.Add("display", "block")
    '        End If
    '        If item.Value = "2" Then
    '            Panel2.Style.Add("display", "block")
    '        End If
    '        If item.Value = "3" Then
    '            Panel3.Style.Add("display", "block")
    '        End If
    '    Next
    '    For i As Integer = 0 To cbl_change.Items.Count - 1
    '        If cbl_change.Items(i).Selected = False Then
    '            If cbl_change.Items(i).Value = "1" Then
    '                Panel1.Style.Add("display", "none")
    '            ElseIf cbl_change.Items(i).Value = "2" Then
    '                Panel2.Style.Add("display", "none")
    '            ElseIf cbl_change.Items(i).Value = "3" Then
    '                Panel3.Style.Add("display", "none")
    '            End If
    '        End If

    '    Next
    'End Sub

    Private Sub ddl_placename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_placename.SelectedIndexChanged
        hf_place.Value = ddl_placename.SelectedValue
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_LOCATION_ADDRESS_BY_IDA(ddl_placename.SelectedValue)
        Catch ex As Exception

        End Try
        Try
            For Each dr As DataRow In dt.Rows
                lbl_location_new.Text = dr("fulladdr")
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdl_change_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_change.SelectedIndexChanged
        For Each item As ListItem In rdl_change.Items
            If item.Value = "1" Then
                Panel1.Style.Add("display", "block")
            End If
            If item.Value = "2" Then
                Panel2.Style.Add("display", "block")
            End If
            If item.Value = "3" Then
                Panel3.Style.Add("display", "block")
            End If
        Next
        For i As Integer = 0 To rdl_change.Items.Count - 1
            If rdl_change.Items(i).Selected = False Then
                If rdl_change.Items(i).Value = "1" Then
                    Panel1.Style.Add("display", "none")
                ElseIf rdl_change.Items(i).Value = "2" Then
                    Panel2.Style.Add("display", "none")
                ElseIf rdl_change.Items(i).Value = "3" Then
                    Panel3.Style.Add("display", "none")
                End If
            End If

        Next
    End Sub
End Class