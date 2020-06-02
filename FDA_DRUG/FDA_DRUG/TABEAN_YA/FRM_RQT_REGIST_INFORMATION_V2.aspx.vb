Imports Telerik.Web.UI
Public Class FRM_RQT_REGIST_INFORMATION_V2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Dim _IDA As Integer
    Sub RunQuery()
        _IDA = Request.QueryString("IDA") '70631 '
    End Sub
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        RunQuery()
        If Not IsPostBack Then
            'If Request.QueryString("STATUS_ID") = "8" Then
            '    Dim dao_rt As New DAO_DRUG.ClsDBdrrgt
            '    dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
            '    Dim Update_tabean As New CLS_BC_TO_DR
            '    Update_tabean.UPDATE_DR(Request.QueryString("NEWCODE"), dao_rt.fields.IDENTIFY)

            '    KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "ดึง BC มาทับ", _CLS.CITIZEN_ID)

            'End If

            Run_section1()
            If Request.QueryString("tt") <> "" Then
                btn_save_pack.Enabled = False
                btn_update_gen.Enabled = False

            End If
            'If Request.QueryString("STATUS_ID") = "8" Then
            '    btn_save_pack.Enabled = False
            '    btn_update_gen.Enabled = False
            'End If
            UC_DRUG_ANIMAL1.bind_ddl_dramlsubtp()
            UC_DRUG_ANIMAL1.bind_ddl_dramltype()
            UC_DRUG_ANIMAL1.bind_ddl_dramlusetp()
            UC_DRUG_ANIMAL1.bind_ddl_dramltype()

            'UC_Packing_Size1.bind_ddl_medium_unit()
            'UC_Packing_Size1.bind_ddl_small_unit()


            UT_NAME_DRUG_EXPORT1.bind_country()
            UC_officer_che.bind_unit1()
            UC_officer_che.bind_unit2()
            UC_officer_che.bind_unit3()
            UC_officer_che.bind_unit4()
            UC_officer_che.get_data_drgperunit()
            UC_officer_che.bind_unit_each()
            UC_officer_che.bind_lbl()
            UC_general.bind_dactg()
            UC_general.bind_dosage_form()
            UC_general.bind_drclass()
            UC_general.bind_drkdofdrg()
            'UC_general.show_data_rqt(_IDA)
            UC_general.bind_ddl_bio_unit()
            UC_general.bind_ddl_packaging()
            UC_general.bind_ddl_small_unit()
            UC_general.bind_DRUG_SHAPE()
            UC_general.show_data(Request.QueryString("IDA"))
            UC_general.bind_label()
            UC_COLOR1.load_data()

            ' UC_recipe.bind_ddl_atc()
            UC_officer_che.bind_unit_head()
            UC_officer_che.bind_unit()
            UC_officer_in_country1.show_data_frgn_rqt(_IDA)
            UC_officer_in_country1.show_data_in_frgn_rqt(_IDA)
            UC_officer_in_country1.show_data_licen_rqt(_IDA)

            If Request.QueryString("STATUS_ID") = "8" Then
                Dim dao_rt As New DAO_DRUG.ClsDBdrrgt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                txt_package.Text = dao_rt.fields.PACKAGE_DETAIL
                Try
                    If Len(Trim(txt_package.Text)) = 0 Then
                        Dim dao_pck As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                        dao_pck.GetDataby_FKIDA(Request.QueryString("IDA"))
                        txt_package.Text = dao_pck.fields.pcksize
                    End If
                Catch ex As Exception

                End Try
            Else
                Dim dao_rt As New DAO_DRUG.ClsDBdrrqt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                txt_package.Text = dao_rt.fields.PACKAGE_DETAIL
                Try
                    If Len(Trim(txt_package.Text)) = 0 Then
                        Dim dao_pck As New DAO_DRUG.TB_DRRQT_DTL_TEXT
                        dao_pck.GetDataby_FKIDA(Request.QueryString("IDA"))
                        txt_package.Text = dao_pck.fields.pcksize
                    End If
                Catch ex As Exception

                End Try
            End If
            If Request.QueryString("tab") <> "" Then
                For Each rt As RadTab In RadTabStrip1.Tabs
                    If rt.Value = Request.QueryString("tab") Then
                        rt.Selected = True
                        If Request.QueryString("tab") = "5" Then
                            RadPageView5.Selected = True
                        ElseIf Request.QueryString("tab") = "10" Then
                            RadPageView10.Selected = True
                        End If

                    End If
                Next
                'RadTabStrip1.SelectedTab.Value = Request.QueryString("tab")
            End If
        End If



    End Sub
    Sub Run_section1()


        Dim STATUS_ID As Integer = 0
        If Request.QueryString("STATUS_ID") <> "" Then
            STATUS_ID = Request.QueryString("STATUS_ID")
        Else
            Try
                STATUS_ID = Get_drrqt_Status(_IDA)
            Catch ex As Exception

            End Try
            If Request.QueryString("type") = "rq" Or STATUS_ID <> 8 Then

            End If
        End If

        If STATUS_ID = 8 Then
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_IDA)
            Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            Try
                dao_re.GetDataby_IDA(dao_rg.fields.FK_IDA)
            Catch ex As Exception

            End Try



            Try
                txt_appdate.Text = CDate(dao_rg.fields.appdate).ToShortDateString()
            Catch ex As Exception
                txt_appdate.Text = ""
            End Try
            Try
                lbl_tabean_type.Text = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                Dim dao_w As New DAO_DRUG.ClsDBdrdrgtype
                dao_w.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                lbl_tabean_other_type.Text = dao_w.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Try
                Dim rgtno As String = ""
                Dim full_rgtno As String = ""
                rgtno = dao_rg.fields.rgtno
                full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rgtno, 5)).ToString() & "/" & Left(rgtno, 2)

                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
                Try
                    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
                Catch ex As Exception

                End Try
                'lbl_rgtno.Text = full_rgtno

                Try
                    Dim bao_rg As New BAO.ClsDBSqlcommand
                    Dim dt9 As New DataTable
                    dt9 = bao_rg.SP_DRRGT_FOR_SEARCH_IDA_NEW(_IDA)
                    lbl_rgtno.Text = dt9(0)("rgtno_display")
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                lbl_engdrgnm.Text = dao_rg.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                lbl_thadrgnm.Text = dao_rg.fields.thadrgnm
            Catch ex As Exception

            End Try

            Dim dt As New DataTable
            Dim bao As New BAO_SHOW
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Try

                dao.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
                dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
            Catch ex As Exception

            End Try
            If dt.Rows.Count > 0 Then
                lbl_lcnsnm.Text = dt(0)("thanm")
            End If

            Dim dt2 As New DataTable
            Try
                dt2 = bao.SP_DRRGT_ADDR_BY_IDA(_IDA)
            Catch ex As Exception

            End Try
            Try
                lbl_thanameplace.Text = dt2(0)("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_addr.Text = dt2(0)("fulladdr")
            Catch ex As Exception

            End Try
            Try
                lbl_lcntpcd.Text = dao.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                Dim lcnno As String = ""
                Dim full_lcnno As String = ""

                lcnno = dao.fields.lcnno
                If Right(Left(lcnno, 3), 1) = "5" Then
                    full_lcnno = "จ. " & Integer.Parse(Right(lcnno, 4)).ToString() & "/25" & Left(lcnno, 2)
                Else
                    full_lcnno = dao.fields.pvnabbr & " " & Integer.Parse(Right(lcnno, 5)).ToString() & "/25" & Left(lcnno, 2)
                End If
                lbl_lcnno.Text = full_lcnno
            Catch ex As Exception

            End Try
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(_IDA)
            'Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            'Try
            '    dao_re.GetDataby_IDA(dao_rg.fields.FK_IDA)
            'Catch ex As Exception

            'End Try



            Try
                txt_appdate.Text = CDate(dao_rg.fields.appdate).ToShortDateString()
            Catch ex As Exception
                txt_appdate.Text = ""
            End Try
            Try
                lbl_tabean_type.Text = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                Dim dao_w As New DAO_DRUG.ClsDBdrdrgtype
                dao_w.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                lbl_tabean_other_type.Text = dao_w.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Try
                Dim rgtno As String = ""
                Dim full_rgtno As String = ""
                rgtno = dao_rg.fields.rgtno
                full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rgtno, 5)).ToString() & "/" & Left(rgtno, 2)

                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
                Try
                    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
                Catch ex As Exception

                End Try
                'lbl_rgtno.Text = full_rgtno
                Try
                    Dim bao_rg As New BAO.ClsDBSqlcommand
                    Dim dt9 As New DataTable
                    dt9 = bao_rg.SP_DRRQT_FOR_SEARCH_IDA_NEW(_IDA)
                    lbl_rgtno.Text = dt9(0)("rgtno_display")
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                lbl_engdrgnm.Text = dao_rg.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                lbl_thadrgnm.Text = dao_rg.fields.thadrgnm
            Catch ex As Exception

            End Try

            Dim dt As New DataTable
            Dim bao As New BAO_SHOW
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Try

                dao.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
                dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
            Catch ex As Exception

            End Try
            If dt.Rows.Count > 0 Then
                lbl_lcnsnm.Text = dt(0)("thanm")
            End If

            Dim dt2 As New DataTable
            Try
                dt2 = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) ' bao.SP_DRRGT_ADDR_BY_IDA(_IDA)
            Catch ex As Exception

            End Try
            Try
                lbl_thanameplace.Text = dt2(0)("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_addr.Text = dt2(0)("fulladdr")
            Catch ex As Exception

            End Try
            Try
                lbl_lcntpcd.Text = dao.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                Dim lcnno As String = ""
                Dim full_lcnno As String = ""

                lcnno = dao.fields.lcnno
                If Right(Left(lcnno, 3), 1) = "5" Then
                    full_lcnno = "จ. " & Integer.Parse(Right(lcnno, 4)).ToString() & "/25" & Left(lcnno, 2)
                Else
                    full_lcnno = dao.fields.pvnabbr & " " & Integer.Parse(Right(lcnno, 5)).ToString() & "/25" & Left(lcnno, 2)
                End If

                lbl_lcnno.Text = full_lcnno
            Catch ex As Exception

            End Try
        End If

        'Try
        '    lbl_appdate.Text = CDate(dao_rg.fields.appdate).ToShortDateString()
        'Catch ex As Exception

        'End Try
        'Try
        '    If dao_rg.fields.cncdate Is Nothing Then
        '        lbl_rgt_stat.Text = "คงอยู่"
        '    Else
        '        Dim dao_stat As New DAO_DRUG.Cls_dacnccs 'dacnccs
        '        dao_stat.GetDataby_cd(dao_rg.fields.cnccscd)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Sub Run_section1_v2()


        Dim STATUS_ID As Integer = 0
        If Request.QueryString("STATUS_ID") <> "" Then
            STATUS_ID = Request.QueryString("STATUS_ID")
        Else
            Try
                STATUS_ID = Get_drrqt_Status(_IDA)
            Catch ex As Exception

            End Try
            If Request.QueryString("type") = "rq" Or STATUS_ID <> 8 Then

            End If
        End If

        If STATUS_ID = 8 Then
            Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN

            Dim xml_iow As New LGT_IOW_E
            Dim xml_str As String

            xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(Request.QueryString("NEWCODE"))
            If xml_str <> "FAIL" Then
                'MODEL.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
                xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)

            Else

            End If


            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_IDA)
            Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            Try
                dao_re.GetDataby_IDA(dao_rg.fields.FK_IDA)
            Catch ex As Exception

            End Try



            Try
                txt_appdate.Text = xml_iow.XML_SEARCH_DRUG_DR.appdate_T 'CDate(dao_rg.fields.appdate).ToShortDateString()
            Catch ex As Exception
                txt_appdate.Text = ""
            End Try
            Try
                lbl_tabean_type.Text = xml_iow.XML_SEARCH_DRUG_DR.rgttpcd 'dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                'Dim dao_w As New DAO_DRUG.ClsDBdrdrgtype
                'dao_w.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                lbl_tabean_other_type.Text = xml_iow.XML_SEARCH_DRUG_DR.engdrgtpnm 'dao_w.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Try
                'Dim rgtno As String = ""
                'Dim full_rgtno As String = ""
                'rgtno = dao_rg.fields.rgtno
                'full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rgtno, 5)).ToString() & "/" & Left(rgtno, 2)

                'Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
                'Try
                '    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                '    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
                'Catch ex As Exception

                'End Try
                ''lbl_rgtno.Text = full_rgtno

                'Try
                '    Dim bao_rg As New BAO.ClsDBSqlcommand
                '    Dim dt9 As New DataTable
                '    dt9 = bao_rg.SP_DRRGT_FOR_SEARCH_IDA_NEW(_IDA)
                lbl_rgtno.Text = xml_iow.XML_SEARCH_DRUG_DR.register 'dt9(0)("rgtno_display")
                'Catch ex As Exception

                'End Try
            Catch ex As Exception

            End Try
            Try
                lbl_engdrgnm.Text = xml_iow.XML_SEARCH_DRUG_DR.engdrgnm
            Catch ex As Exception

            End Try
            Try
                lbl_thadrgnm.Text = xml_iow.XML_SEARCH_DRUG_DR.thadrgnm
            Catch ex As Exception

            End Try

            'Dim dt As New DataTable
            'Dim bao As New BAO_SHOW
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'Try

            '    dao.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
            '    dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
            'Catch ex As Exception

            'End Try
            'If dt.Rows.Count > 0 Then
            lbl_lcnsnm.Text = xml_iow.XML_SEARCH_DRUG_DR.thanm 'dt(0)("thanm")
            'End If

            'Dim dt2 As New DataTable
            'Try
            '    dt2 = BAO.SP_DRRGT_ADDR_BY_IDA(_IDA)
            'Catch ex As Exception

            'End Try
            Try
                lbl_thanameplace.Text = xml_iow.XML_SEARCH_DRUG_DR.thanm_locaion 'dt2(0)("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_addr.Text = xml_iow.XML_SEARCH_DRUG_DR.fulladdr 'dt2(0)("fulladdr")
            Catch ex As Exception

            End Try
            Try
                lbl_lcntpcd.Text = xml_iow.XML_SEARCH_DRUG_DR.lcntpcd 'dao.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                'Dim lcnno As String = ""
                'Dim full_lcnno As String = ""

                'lcnno = dao.fields.lcnno
                'If Right(Left(lcnno, 3), 1) = "5" Then
                '    full_lcnno = "จ. " & Integer.Parse(Right(lcnno, 4)).ToString() & "/25" & Left(lcnno, 2)
                'Else
                '    full_lcnno = dao.fields.pvnabbr & " " & Integer.Parse(Right(lcnno, 5)).ToString() & "/25" & Left(lcnno, 2)
                'End If
                lbl_lcnno.Text = xml_iow.XML_SEARCH_DRUG_DR.lcnno_no 'full_lcnno
            Catch ex As Exception

            End Try
        Else
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(_IDA)
            'Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            'Try
            '    dao_re.GetDataby_IDA(dao_rg.fields.FK_IDA)
            'Catch ex As Exception

            'End Try



            Try
                txt_appdate.Text = CDate(dao_rg.fields.appdate).ToShortDateString()
            Catch ex As Exception
                txt_appdate.Text = ""
            End Try
            Try
                lbl_tabean_type.Text = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                Dim dao_w As New DAO_DRUG.ClsDBdrdrgtype
                dao_w.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                lbl_tabean_other_type.Text = dao_w.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            Try
                Dim rgtno As String = ""
                Dim full_rgtno As String = ""
                rgtno = dao_rg.fields.rgtno
                full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rgtno, 5)).ToString() & "/" & Left(rgtno, 2)

                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
                Try
                    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
                Catch ex As Exception

                End Try
                'lbl_rgtno.Text = full_rgtno
                Try
                    Dim bao_rg As New BAO.ClsDBSqlcommand
                    Dim dt9 As New DataTable
                    dt9 = bao_rg.SP_DRRQT_FOR_SEARCH_IDA_NEW(_IDA)
                    lbl_rgtno.Text = dt9(0)("rgtno_display")
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                lbl_engdrgnm.Text = dao_rg.fields.engdrgnm
            Catch ex As Exception

            End Try
            Try
                lbl_thadrgnm.Text = dao_rg.fields.thadrgnm
            Catch ex As Exception

            End Try

            Dim dt As New DataTable
            Dim bao As New BAO_SHOW
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Try

                dao.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
                dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
            Catch ex As Exception

            End Try
            If dt.Rows.Count > 0 Then
                lbl_lcnsnm.Text = dt(0)("thanm")
            End If

            Dim dt2 As New DataTable
            Try
                dt2 = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) ' bao.SP_DRRGT_ADDR_BY_IDA(_IDA)
            Catch ex As Exception

            End Try
            Try
                lbl_thanameplace.Text = dt2(0)("thanameplace")
            Catch ex As Exception

            End Try
            Try
                lbl_addr.Text = dt2(0)("fulladdr")
            Catch ex As Exception

            End Try
            Try
                lbl_lcntpcd.Text = dao.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                Dim lcnno As String = ""
                Dim full_lcnno As String = ""

                lcnno = dao.fields.lcnno
                If Right(Left(lcnno, 3), 1) = "5" Then
                    full_lcnno = "จ. " & Integer.Parse(Right(lcnno, 4)).ToString() & "/25" & Left(lcnno, 2)
                Else
                    full_lcnno = dao.fields.pvnabbr & " " & Integer.Parse(Right(lcnno, 5)).ToString() & "/25" & Left(lcnno, 2)
                End If

                lbl_lcnno.Text = full_lcnno
            Catch ex As Exception

            End Try
        End If

        'Try
        '    lbl_appdate.Text = CDate(dao_rg.fields.appdate).ToShortDateString()
        'Catch ex As Exception

        'End Try
        'Try
        '    If dao_rg.fields.cncdate Is Nothing Then
        '        lbl_rgt_stat.Text = "คงอยู่"
        '    Else
        '        Dim dao_stat As New DAO_DRUG.Cls_dacnccs 'dacnccs
        '        dao_stat.GetDataby_cd(dao_rg.fields.cnccscd)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Protected Sub btn_update_gen_Click(sender As Object, e As EventArgs) Handles btn_update_gen.Click
        'Dim STATUS_ID As Integer = 0
        'STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("TR_ID"))
        If Request.QueryString("STATUS_ID") <> 8 Then
            UC_general.update_data_rqt(_IDA)
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_IDA)
            dao_rg.fields.lmdfdate = Date.Now
            dao_rg.update()
        Else
            UC_general.update_data(_IDA)
            Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
            dao_rg.GetDataby_IDA(_IDA)
            dao_rg.fields.lmdfdate = Date.Now
            dao_rg.update()

            KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขรายละเอียดทะเบียน", _CLS.CITIZEN_ID)
        End If

        alert("แก้ไขเรียบร้อยแล้ว")
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Dim tr_id As Integer = 0
        Try
            dao.GetDataby_IDA(_IDA)
            tr_id = dao.fields.TR_ID
        Catch ex As Exception

        End Try
        If tr_id = 0 Then
            gen_tr_id()
        End If


        Dim _process_id As Integer = 0
        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Try
            dao_tr.GetDataby_IDA(tr_id)
            _process_id = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        lbl_titlename.Text = "ใบสำคัญ"
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_PROCESS_DESCRIPTION(dao.fields.rgttpcd)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_DR_CONFIRM_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & tr_id & "&process=" & _process_id & "');", True)


    End Sub

    Sub gen_tr_id()
        Dim TR_ID As String = ""
        Dim _ProcessID As String = ""
        Dim bao_tran As New BAO_TRANSECTION

        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Try
            dao.GetDataby_IDA(_IDA)
        Catch ex As Exception

        End Try

        Dim dao_pc As New DAO_DRUG.ClsDBPROCESS_NAME
        Try
            dao_pc.GetDataby_PROCESS_DESCRIPTION(dao.fields.rgttpcd)
        Catch ex As Exception

        End Try

        Try
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        Catch ex As Exception
            bao_tran.CITIZEN_ID = ""
        End Try
        Try
            bao_tran.CITIZEN_ID_AUTHORIZE = dao.fields.IDENTIFY
        Catch ex As Exception
            bao_tran.CITIZEN_ID_AUTHORIZE = ""
        End Try
        Try
            _ProcessID = dao_pc.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        If _ProcessID <> "" Then
            TR_ID = bao_tran.insert_transection(_ProcessID)
            dao.fields.TR_ID = TR_ID
            dao.fields.PROCESS_ID = _ProcessID
            dao.update()
        End If

    End Sub

    Protected Sub btn_preview2_Click(sender As Object, e As EventArgs) Handles btn_preview2.Click
        OpenReport(1, "~/word/test.doc")
    End Sub
    Public Sub OpenReport(ByVal idreport As Integer, ByVal pathdoc As String)
        'Dim cls As New Untility.CLS_ASPOSE_WORD
        'Dim bao As New BAO_SHOW
        'Dim pathlic As String = "../lic/License.lic" 'Server.MapPath("lic") & 
        'cls.setLicense(pathlic)
        'Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        'dao_rg.GetDataby_IDA(_IDA)

        'Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        'dao_re.GetDataby_IDA(76488)
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'Try

        '    dao.GetDataby_IDA(dao_re.fields.FK_IDA)
        'Catch ex As Exception

        'End Try
        'Dim dt2 As New DataTable
        'Try
        '    dt2 = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
        'Catch ex As Exception

        'End Try

        'pathdoc = Server.MapPath(pathdoc)
        'cls.docConnect(pathdoc)

        'Dim dao_tem As New DAO_DRUG.TB_MAS_TABEAN_TEMPLATE
        'dao_tem.GetDataAll()

        'For Each dao_tem.fields In dao_tem.datas
        '    Dim seq As Integer = 0
        '    seq = dao_tem.fields.SEQ
        '    Select Case seq
        '        Case 1
        '            If dao_rg.fields.lcntpcd.Contains("บ") Then
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "โบราณ")
        '            Else
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "ปัจจุบัน")
        '            End If
        '        Case 2
        '            Try
        '                Dim rgtno As String = ""
        '                Dim full_rgtno As String = ""
        '                rgtno = dao_rg.fields.rgtno
        '                full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rgtno, 5)).ToString() & "/" & Left(rgtno, 2)

        '                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        '                Try
        '                    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
        '                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
        '                Catch ex As Exception
        '                    cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '                End Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, full_rgtno)
        '            Catch ex As Exception

        '            End Try
        '        Case 3
        '            Dim drug_name As String = ""
        '            Try
        '                drug_name = dao_rg.fields.thadrgnm & " / " & dao_rg.fields.engdrgnm
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '            cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, drug_name)
        '        Case 4
        '            Try
        '                Dim rcvno As String = ""
        '                Dim full_rgtno As String = ""
        '                rcvno = dao_rg.fields.rcvno
        '                full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rcvno, 5)).ToString() & "/" & Left(rcvno, 2)

        '                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        '                Try
        '                    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
        '                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
        '                Catch ex As Exception
        '                    cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '                End Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, full_rgtno)
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 5
        '            Dim dao_d As New DAO_DRUG.TB_drdosage
        '            Try
        '                dao_d.GetDataby_cd(dao_rg.fields.dsgcd)
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, dao_d.fields.thadsgnm)
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 6
        '            Dim dao_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
        '            dao_prop.GetDataby_FK_IDA(_IDA)
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, dao_prop.fields.DRUG_PROPERTIES_AND_DETAIL)
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 7
        '            Dim lcn_type As String = ""
        '            Try
        '                Dim dao_type As New DAO_DRUG.TB_DRRGT_DRUG_GROUP
        '                dao_type.GetDataby_rgttpcd(dao_rg.fields.rgttpcd)
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, dao_type.fields.thargttpnm_short)
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 8 'โดย
        '            Dim bao_show As New BAO_SHOW
        '            Dim dt_lcnnm As New DataTable
        '            Try
        '                dt_lcnnm = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, dt_lcnnm(0)("thanm"))
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try

        '        Case 9
        '            Try
        '                Dim lcnno As String = ""
        '                Dim full_rgtno As String = ""
        '                lcnno = dao_rg.fields.lcnno
        '                full_rgtno = dao_rg.fields.lcntpcd & " " & Integer.Parse(Right(lcnno, 5)).ToString() & "/" & Left(lcnno, 2)

        '                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, full_rgtno)
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 10
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, dt2(0)("addr_row1") & vbCrLf & dt2(0)("addr_row2") & vbCrLf & dt2(0)("addr_row3"))
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 11
        '            Dim bao_show As New BAO_SHOW
        '            Dim dt_lcnnm As New DataTable
        '            Try
        '                dt_lcnnm = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, dt_lcnnm(0)("thanm"))
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 12
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, Day(CDate(dao_rg.fields.appdate)))
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 13
        '            Dim ut As New cls_utility.Report_Utility
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, ut.get_Long_month_BY_Number(Month(CDate(dao_rg.fields.appdate))))
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 14
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, Year(CDate(dao_rg.fields.appdate)))
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 15
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 16
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "2")
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '        Case 17
        '            Try
        '                Dim rgtno As String = ""
        '                Dim full_rgtno As String = ""
        '                rgtno = dao_rg.fields.rgtno
        '                full_rgtno = dao_rg.fields.rgttpcd & " " & Integer.Parse(Right(rgtno, 5)).ToString() & "/" & Left(rgtno, 2)

        '                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        '                Try
        '                    dao_ty.GetDataby_drgtpcd(dao_rg.fields.drgtpcd)
        '                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
        '                Catch ex As Exception
        '                    cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '                End Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, full_rgtno)
        '            Catch ex As Exception

        '            End Try
        '        Case 18

        '            cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '        Case 19
        '            Try
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, dt2(0)("addr_row1") & vbCrLf & dt2(0)("addr_row2") & vbCrLf & dt2(0)("addr_row3"))
        '            Catch ex As Exception
        '                cls.rePlaceData(dao_tem.fields.REPLACE_TEXT, "")
        '            End Try
        '    End Select




        'Next
        ''cls.rePlaceData("<1>", "ปัจจุบัน")
        ''cls.rePlaceData("<2>", "1A 2/2561 (NC)")
        ''cls.rePlaceData("<3>", "ยาพาราจ้าาา")
        ''cls.rePlaceData("<4>", "1A 2/2561")
        ''cls.rePlaceData("<5>", "ยาเม็ด")
        ''cls.rePlaceData("<6>", "ยาเม็ด กลมๆ ขาวๆ")
        ''cls.rePlaceData("<7>", "ยานี้ดีมากๆ")
        ''cls.rePlaceData("<8>", "นายทดสอบ นะจ๊ะ")
        ''cls.rePlaceData("<9>", "นย1 1/26")
        ''cls.rePlaceData("<10>", "บ้านเลขที่ 5 หมู่ 2 ต.ทดสอบ อ.ทดสอบ จ.ทดสอบ 11111")
        ''cls.rePlaceData("<11>", "บ้านเลขที่ 5 หมู่ 2 ต.ทดสอบ อ.ทดสอบ จ.ทดสอบ 11111")
        ''cls.rePlaceData("<12>", "1")
        ''cls.rePlaceData("<13>", "มกราคม")
        ''cls.rePlaceData("<14>", "2561")
        ''cls.rePlaceData("<15>", "นายทดสอบ นะจ๊ะนะจ๊ะ")
        ''cls.rePlaceData("<16>", "1")
        ''cls.rePlaceData("<17>", "1A 2/2561 (NC)")
        ''cls.rePlaceData("<18>", "")


        'cls.docSaveOpen("Report.doc")
        ''Catch ex As Exception
        ''    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถออกรายงานได้ เนื่องจากยังไม่มีการบันทึกข้อมูล');", True)
        ''End Try
    End Sub

    Protected Sub btn_save_app_Click(sender As Object, e As EventArgs) Handles btn_save_app.Click
        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        dao_rg.GetDataby_IDA(_IDA)

        If dao_rg.fields.STATUS_ID <> 8 Then
            Dim format_no As Integer = 0
            'If txt_tabean_no.Text.Contains("/") Then

            Dim tabean_no As String() = txt_tabean_no.Text.Split("/")
            format_no = tabean_no(0)
            format_no = tabean_no(1) & String.Format("{0:00000}", format_no.ToString("00000"))

            dao_rg.fields.rgtno = format_no
            Try
                dao_rg.fields.appdate = CDate(txt_appdate.Text)
            Catch ex As Exception
                dao_rg.fields.appdate = Nothing
            End Try
            Try
                dao_rg.fields.STATUS_ID = 8
            Catch ex As Exception

            End Try
            dao_rg.update()
            'Else
            '    alert("กรอกเลขทะเบียนไม่ถูกต้อง")
            'End If


        ElseIf dao_rg.fields.STATUS_ID = 8 Then
            Try
                If dao_rg.fields.appdate Is Nothing Then
                    dao_rg.fields.appdate = CDate(txt_appdate.Text)
                    dao_rg.update()
                End If
            Catch ex As Exception

            End Try
        Else
            alert("ทะเบียนได้รับอนุญาตแล้ว")
        End If
    End Sub

    Private Sub btn_pay_Click(sender As Object, e As EventArgs) Handles btn_pay.Click
        Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
        dao_rg.GetDataby_IDA(_IDA)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(dao_rg.fields.FK_IDA)
        Dim urls As String = ""
        Try
            _CLS.CITIZEN_ID_AUTHORIZE = dao.fields.CITIZEN_ID_AUTHORIZE
            urls = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug&identify=" & dao.fields.CITIZEN_ID_AUTHORIZE
            Session("CLS") = _CLS
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)

        Catch ex As Exception
            alert("ไม่พบข้อมูล")
        End Try

    End Sub

    'Private Sub RadTabStrip1_TabClick(sender As Object, e As RadTabStripEventArgs) Handles RadTabStrip1.TabClick
    '    RadPageView10.Selected = True
    'End Sub

    Protected Sub btn_save_pack_Click(sender As Object, e As EventArgs) Handles btn_save_pack.Click
        Try
            If Request.QueryString("STATUS_ID") = "8" Then
                Dim dao_rt As New DAO_DRUG.ClsDBdrrgt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                dao_rt.fields.PACKAGE_DETAIL = txt_package.Text
                dao_rt.update()

                Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                Dim dao_re As New DAO_DRUG.ClsDBdrrgt
                dao_re.GetDataby_IDA(_IDA)
                dao_re.fields.lmdfdate = Date.Now
                Dim IDA_C As Integer = 0
                Try
                    Dim c As Integer = 0
                    c = dao.count_fk_ida(_IDA)
                    If c = 0 Then
                        Dim dao_dtl As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                        setdata(dao_dtl)
                        dao_dtl.fields.drgtpcd = dao_re.fields.drgtpcd
                        dao_dtl.fields.pvncd = dao_re.fields.pvncd
                        dao_dtl.fields.rgtno = dao_re.fields.rgtno
                        dao_dtl.fields.rgttpcd = dao_re.fields.rgttpcd
                        dao_dtl.fields.FK_IDA = _IDA
                        dao_dtl.insert()
                        IDA_C = dao_dtl.fields.IDA
                    Else
                        Dim dao_dtl As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                        dao_dtl.GetDataby_FKIDA(_IDA)
                        setdata(dao_dtl)
                        dao_dtl.update()
                        IDA_C = dao_dtl.fields.IDA
                    End If
                Catch ex As Exception

                End Try
                dao_re.update()
            Else
                Dim dao_rt As New DAO_DRUG.ClsDBdrrqt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                dao_rt.fields.PACKAGE_DETAIL = txt_package.Text
                dao_rt.update()

                Dim dao As New DAO_DRUG.TB_DRRQT_DTL_TEXT
                Dim dao_re As New DAO_DRUG.ClsDBdrrqt
                dao_re.GetDataby_IDA(_IDA)
                dao_re.fields.lmdfdate = Date.Now
                Try
                    Dim c As Integer = 0
                    c = dao.count_fk_ida(_IDA)
                    If c = 0 Then
                        Dim dao_dtl As New DAO_DRUG.TB_DRRQT_DTL_TEXT
                        setdata2(dao_dtl)
                        dao_dtl.fields.drgtpcd = dao_re.fields.drgtpcd
                        dao_dtl.fields.pvncd = dao_re.fields.pvncd
                        dao_dtl.fields.rgtno = dao_re.fields.rgtno
                        dao_dtl.fields.rgttpcd = dao_re.fields.rgttpcd
                        dao_dtl.fields.FK_IDA = _IDA
                        dao_dtl.insert()
                    Else
                        Dim dao_dtl As New DAO_DRUG.TB_DRRQT_DTL_TEXT
                        dao_dtl.GetDataby_FKIDA(_IDA)
                        setdata2(dao_dtl)
                        dao_dtl.update()
                    End If
                    alert("บันทึกเรียบร้อยแล้ว")
                Catch ex As Exception

                End Try
                dao_re.update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.TB_DRRGT_DTL_TEXT)
        dao.fields.pcksize = txt_package.Text
    End Sub
    Sub setdata2(ByRef dao As DAO_DRUG.TB_DRRQT_DTL_TEXT)
        dao.fields.pcksize = txt_package.Text
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()


    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        UC_DRUG_DOCUMENT_UPLOAD1.re_fresh_rg()
    End Sub
End Class