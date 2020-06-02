Public Class FRM_APPOINTMENT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    'Private PROCESS_ID As String = "1007001"
    Private Sub RunQuery()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        'PROCESS_ID = Session("FileName")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString
            If Request.QueryString("STATUS_ID") <> "8" Then
                Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
                dao_drrqt.GetDataby_IDA(Request.QueryString("IDA"))

                Dim dao As New DAO_DRUG.TB_DRRQT_APPOINTMENT
                dao.GetDataByFK_IDA(Request.QueryString("IDA"))
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
                        txt_company.Text = .CITIZEN_AUTHORIZE
                    Catch ex As Exception

                    End Try

                    Try
                        txt_date.Text = CDate(.REQUEST_DATE).ToShortDateString
                    Catch ex As Exception

                    End Try
                End With


                Bind_Date()
                Dim dao_type As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                Try
                    dao_type.GetDataby_CD(dao_drrqt.fields.TYPE_REQUEST_ID)
                Catch ex As Exception

                End Try
                Dim dao_g As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
                Try
                    dao_g.GetDataby_IDA(dao_type.fields.NEW_WORK_GROUP)
                Catch ex As Exception

                End Try
                Try
                    lbl_TR_ID.Text = dao_drrqt.fields.TR_ID
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
                'Try
                '    If dao_drrqt.fields.STATUS_ID >= 3 Then
                '        btn_add.Style.Add("display", "none")
                '    End If
                'Catch ex As Exception

                'End Try
            Else
                Dim dao_drrqt As New DAO_DRUG.ClsDBdrrgt
                dao_drrqt.GetDataby_IDA(Request.QueryString("IDA"))

                Dim dao As New DAO_DRUG.TB_DRRGT_APPOINTMENT
                dao.GetDataByFK_IDA(Request.QueryString("IDA"))
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
                        txt_company.Text = .CITIZEN_AUTHORIZE
                    Catch ex As Exception

                    End Try

                    Try
                        txt_date.Text = CDate(.REQUEST_DATE).ToShortDateString
                    Catch ex As Exception

                    End Try
                End With


                Bind_Date()
                Dim dao_type As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
                Try
                    dao_type.GetDataby_CD(dao_drrqt.fields.TYPE_REQUEST_ID)
                Catch ex As Exception

                End Try
                Dim dao_g As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
                Try
                    dao_g.GetDataby_IDA(dao_type.fields.NEW_WORK_GROUP)
                Catch ex As Exception

                End Try
                Try
                    lbl_TR_ID.Text = dao_drrqt.fields.TR_ID
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
                'Try
                '    If dao_drrqt.fields.STATUS_ID >= 5 Then
                '        btn_add.Style.Add("display", "none")
                '    End If
                'Catch ex As Exception

                'End Try
            End If
            
            set_name_company(txt_company.Text)
        End If

    End Sub
    Sub Bind_Day()
        Try
            Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
            dao_drrqt.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao As New DAO_DRUG.TB_MAS_TYPE_REQUESTS
            dao.GetDataby_type(dao_drrqt.fields.TYPE_REQUEST_ID)
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
        Dim dao_chk As New DAO_DRUG.TB_DRRGT_APPOINTMENT
        i = dao_chk.CountDataby_FK_IDA(Request.QueryString("IDA"))

        Dim dao_drrqt As New DAO_DRUG.ClsDBdrrqt
        dao_drrqt.GetDataby_IDA(Request.QueryString("IDA"))
        If i = 0 Then
            Dim dao As New DAO_DRUG.TB_DRRGT_APPOINTMENT
            With dao.fields
                .APPOINT_DATE = HiddenField1.Value
                .APPOINT_DAY = txt_number.Text
                .CITIZEN_AUTHORIZE = txt_company.Text
                .FK_IDA = Request.QueryString("IDA")
                Try
                    .REQUEST_DATE = CDate(txt_date.Text)
                Catch ex As Exception

                End Try
                .TYPE_REQUESTS_ID = dao_drrqt.fields.TYPE_REQUEST_ID
            End With
            dao.insert()
        Else
            Dim dao As New DAO_DRUG.TB_DRRGT_APPOINTMENT
            dao.GetDataByFK_IDA(Request.QueryString("IDA"))
            With dao.fields
                .APPOINT_DATE = HiddenField1.Value
                .APPOINT_DAY = txt_number.Text
                .CITIZEN_AUTHORIZE = txt_company.Text
                .FK_IDA = Request.QueryString("IDA")
                Try
                    .REQUEST_DATE = CDate(txt_date.Text)
                Catch ex As Exception

                End Try
                .TYPE_REQUESTS_ID = dao_drrqt.fields.TYPE_REQUEST_ID
            End With
            dao.update()
        End If
        Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกเรียบร้อย');</script> ")
        'parent.close_modal();
    End Sub
End Class