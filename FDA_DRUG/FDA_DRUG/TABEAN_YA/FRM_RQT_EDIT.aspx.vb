Imports Telerik.Web.UI
Public Class FRM_RQT_EDIT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Dim _IDA As String
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()
        _IDA = Request.QueryString("IDA") '70631 '
        Try
            STATUS_ID = Request.QueryString("STATUS_ID")
        Catch ex As Exception

        End Try
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
            End If
            Run_section1()
            If Request.QueryString("STATUS_ID") = "8" Then
                Dim dao_rt As New DAO_DRUG.ClsDBdrrgt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                txt_package.Text = dao_rt.fields.PACKAGE_DETAIL

            Else
                Dim dao_rt As New DAO_DRUG.ClsDBdrrqt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                txt_package.Text = dao_rt.fields.PACKAGE_DETAIL
            End If

            UC_DRUG_ANIMAL1.bind_ddl_dramlsubtp()
            UC_DRUG_ANIMAL1.bind_ddl_dramltype()
            UC_DRUG_ANIMAL1.bind_ddl_dramlusetp()
            UC_DRUG_ANIMAL1.bind_ddl_dramltype()

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
            UC_COLOR1.load_data()

            'UC_recipe.bind_ddl_atc()
            UC_officer_che.bind_unit_head()
            UC_officer_che.bind_unit()
            'UC_officer_in_country1.show_data_frgn_rqt(_IDA)
            'UC_officer_in_country1.show_data_in_frgn_rqt(_IDA)
            'UC_officer_in_country1.show_data_licen_rqt(_IDA)


            If Request.QueryString("ida_e") <> "" Then
                Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                dao.GetDatabyIDA(Request.QueryString("ida_e"))
                txt_edit_description.Text = dao.fields.EDIT_DESCRIPTION

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
                lbl_rgtno.Text = full_rgtno
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
                dt2 = bao.SP_DRRGT_ADDR_BY_IDA(_IDA) 'bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
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
                lbl_rgtno.Text = full_rgtno
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

                dao.GetDataby_IDA(dao_re.fields.FK_IDA)
                dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
            Catch ex As Exception

            End Try
            If dt.Rows.Count > 0 Then
                lbl_lcnsnm.Text = dt(0)("thanm")
            End If

            Dim dt2 As New DataTable
            Try
                dt2 = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
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
        Dim STATUS_ID As Integer = 0
        Try
            STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("TR_ID"))
        Catch ex As Exception

        End Try

        If Request.QueryString("STATUS_ID") <> "" Then
            STATUS_ID = Request.QueryString("STATUS_ID")
        End If
        If STATUS_ID <> 8 Then
            UC_general.update_data_rqt(_IDA)
        Else
            UC_general.update_data(_IDA)
        End If

        alert("แก้ไขเรียบร้อยแล้ว")
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Protected Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Dim tr_id As String= 0
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
            TR_ID = bao_tran.insert_transection_new(_ProcessID)
            dao.fields.TR_ID = TR_ID
            dao.fields.PROCESS_ID = _ProcessID
            dao.update()
        End If

    End Sub

    Protected Sub btn_preview2_Click(sender As Object, e As EventArgs) Handles btn_preview2.Click
        OpenReport(1, "~/word/test.doc")
    End Sub
    Public Sub OpenReport(ByVal idreport As Integer, ByVal pathdoc As String)
        
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

    Protected Sub btn_save_edit_des_Click(sender As Object, e As EventArgs) Handles btn_save_edit_des.Click
        If Request.QueryString("ida_e") <> "" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            dao.GetDatabyIDA(Request.QueryString("ida_e"))
            dao.fields.EDIT_DESCRIPTION = txt_edit_description.Text
            dao.update()
            alert("บันทึกรียบร้อยแล้ว")
        End If
    End Sub

    Protected Sub btn_save_pack_Click(sender As Object, e As EventArgs) Handles btn_save_pack.Click
        Try
            If Request.QueryString("STATUS_ID") = "8" Then
                Dim dao_rt As New DAO_DRUG.ClsDBdrrgt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                dao_rt.fields.PACKAGE_DETAIL = txt_package.Text
                dao_rt.update()
            Else
                Dim dao_rt As New DAO_DRUG.ClsDBdrrqt
                dao_rt.GetDataby_IDA(Request.QueryString("IDA"))
                dao_rt.fields.PACKAGE_DETAIL = txt_package.Text
                dao_rt.update()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class