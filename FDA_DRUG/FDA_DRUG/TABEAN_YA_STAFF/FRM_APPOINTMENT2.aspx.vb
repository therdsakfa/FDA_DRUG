Public Class FRM_APPOINTMENT2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

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
        'RunSession()
        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString



            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_APPOINTMENT
            dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
            Dim dao_126 As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB

            Try

                Dim dao_edit As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                dao_edit.GetDatabyIDA(Request.QueryString("IDA"))
                Dim dao_drrqt As New DAO_DRUG.ClsDBdrrgt
                dao_drrqt.GetDataby_IDA(dao_edit.fields.FK_IDA)
                dao_126.GetDataby_IDA_drrgt(dao_edit.fields.FK_IDA)
                Try
                    Dim bao_rg As New BAO.ClsDBSqlcommand
                    Dim dt As New DataTable
                    dt = bao_rg.SP_DRRGT_FOR_SEARCH_IDA_NEW(dao_drrqt.fields.IDA)
                    lbl_rgtno.Text = dt(0)("rgtno_display")
                Catch ex As Exception

                End Try
                Bind_Day()
                With dao.fields
                    Try
                        HiddenField1.Value = .APPOINT_DATE
                    Catch ex As Exception

                    End Try
                    Try
                        txt_number.Text = .APPOINT_DAY
                    Catch ex As Exception

                    End Try


                    Try
                        txt_date.Text = CDate(.REQUEST_DATE).ToShortDateString
                    Catch ex As Exception

                    End Try
                End With
                Try
                    txt_company.Text = dao_126.fields.Identify

                Catch ex As Exception

                End Try

                Bind_Date()
                Dim dao_type As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                Try
                    dao_type.GetDataby_CD(dao_edit.fields.TYPE_REQUESTS_ID)
                Catch ex As Exception

                End Try
                Dim dao_g As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
                Try
                    dao_g.GetDataby_IDA(dao_type.fields.NEW_WORK_GROUP)
                Catch ex As Exception

                End Try
                Try
                    lbl_TR_ID.Text = dao_edit.fields.TR_ID
                Catch ex As Exception

                End Try
                Try
                    lbl_group_name.Text = dao_g.fields.WORK_GROUP

                Catch ex As Exception

                End Try
                Try
                    lbl_name_drug.Text = dao_drrqt.fields.thadrgnm & "/" & dao_drrqt.fields.engdrgnm

                Catch ex As Exception

                End Try
                Try
                    lbl_type_name.Text = dao_type.fields.TYPE_REQUESTS_NAME
                Catch ex As Exception

                End Try
                Try
                    lbl_staff_name.Text = dao.fields.OWN_STAFF_NAME
                Catch ex As Exception

                End Try

                Try
                    lbl_company.Text = dao_126.fields.thanm 'set_name_company(txt_company.Text)
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try

            Catch ex As Exception

            End Try
            If Request.QueryString("p") = "1" Then
                txt_date.Enabled = False
                txt_company.Enabled = False
                txt_number.Enabled = False
                btn_add.Visible = False
                btn_company.Visible = False
                btn_day.Visible = False
                btn_report.Visible = False
                btn_search_name.Visible = False
                ddl_name.Visible = False
                'lbl_staff_name.Style.Add("display", "block")
                txt_namestaff_search.Visible = False
            Else
                'lbl_staff_name.Style.Add("display", "none")
            End If
        End If



    End Sub
    Sub Bind_Day()
        Try
            Dim dao_drrqt As New DAO_DRUG.TB_DRRGT_EDIT_APPOINTMENT
            dao_drrqt.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
            dao.GetDataby_type(dao_drrqt.fields.TYPE_REQUESTS_ID)
            txt_number.Text = dao.fields.DAY_WORK
        Catch ex As Exception
            txt_number.Text = "0"
        End Try
    End Sub
    Sub Bind_Date()
        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim date_result As Date
        ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
        lbl_number_day.Text = date_result.ToLongDateString()
        HiddenField1.Value = date_result.ToShortDateString()
    End Sub

    Protected Sub btn_day_Click(sender As Object, e As EventArgs) Handles btn_day.Click
        Bind_Date()
    End Sub

    Protected Sub btn_company_Click(sender As Object, e As EventArgs) Handles btn_company.Click
        lbl_company.Text = set_name_company(txt_company.Text)
    End Sub

    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim i As Integer = 0
        Dim dao_chk As New DAO_DRUG.TB_DRRGT_EDIT_APPOINTMENT
        i = dao_chk.CountDataby_FK_IDA(Request.QueryString("IDA"))

        Dim dao_edit As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao_edit.GetDatabyIDA(Request.QueryString("IDA"))
        If ddl_name.Items.Count = 0 Then
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาตรวจสอบชื่อเจ้าหน้าที่ผู้รับผิดชอบคำขอ');</script> ")
        Else
            If ddl_name.SelectedValue <> "" Then
                If i = 0 Then
                    Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_APPOINTMENT
                    With dao.fields
                        .APPOINT_DATE = HiddenField1.Value
                        .APPOINT_DAY = txt_number.Text
                        .CITIZEN_AUTHORIZE = txt_company.Text
                        .FK_IDA = Request.QueryString("IDA")
                        Try
                            .OWN_STAFF_IDENTIFY = ddl_name.SelectedValue
                        Catch ex As Exception

                        End Try
                        Try
                            .OWN_STAFF_NAME = ddl_name.SelectedItem.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .REQUEST_DATE = CDate(txt_date.Text)
                        Catch ex As Exception

                        End Try
                        .TYPE_REQUESTS_ID = dao_edit.fields.TYPE_REQUESTS_ID
                    End With
                    dao.insert()
                Else
                    Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_APPOINTMENT
                    dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                    With dao.fields
                        .APPOINT_DATE = HiddenField1.Value
                        .APPOINT_DAY = txt_number.Text
                        .CITIZEN_AUTHORIZE = txt_company.Text
                        .FK_IDA = Request.QueryString("IDA")
                        Try
                            .OWN_STAFF_IDENTIFY = ddl_name.SelectedValue
                        Catch ex As Exception

                        End Try
                        Try
                            .OWN_STAFF_NAME = ddl_name.SelectedItem.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .REQUEST_DATE = CDate(txt_date.Text)
                        Catch ex As Exception

                        End Try
                        .TYPE_REQUESTS_ID = dao_edit.fields.TYPE_REQUESTS_ID
                    End With
                    dao.update()
                End If
                Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกเรียบร้อย');</script> ")
            Else
                Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาตรวจสอบชื่อเจ้าหน้าที่ผู้รับผิดชอบคำขอ');</script> ")
            End If

        End If

        'parent.close_modal();
    End Sub

    Protected Sub btn_search_name_Click(sender As Object, e As EventArgs) Handles btn_search_name.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY(txt_namestaff_search.Text, "")

        ddl_name.DataSource = dt
        ddl_name.DataBind()

    End Sub
End Class