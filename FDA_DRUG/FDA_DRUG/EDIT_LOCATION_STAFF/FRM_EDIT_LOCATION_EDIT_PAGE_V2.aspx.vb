Public Class FRM_EDIT_LOCATION_EDIT_PAGE_V2
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
        set_hide_show()
        RunSession()
        If Not IsPostBack Then
            UC_Information_edit1.Shows(Request.QueryString("ida"))
            txt_select_date_edit.Text = Date.Now.ToShortDateString()
            UC_LCN_LOCATION_ADDRESS_DETAIL.load_ddl_chwt()
            UC_LCN_LOCATION_ADDRESS_DETAIL.load_ddl_amp()
            UC_LCN_LOCATION_ADDRESS_DETAIL.load_ddl_thambol()
            UC_LCN_LOCATION_ADDRESS_DETAIL.call_lbl_set()

            UC_BSN_ADDRESS.load_ddl_chwt()
            UC_BSN_ADDRESS.load_ddl_amp()
            UC_BSN_ADDRESS.load_ddl_thambol()
            UC_BSN_ADDRESS.call_lbl_set()

            UC_BSN_NAME2.bind_ddl_prefix()
            UC_LCNS_NAME.bind_ddl_prefix()
            UC_BSN_SUSTAIN1.bind_old_name()

            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(Request.QueryString("ida"))
                UC_BSN_NAME2.get_data_dalcn(dao)
                UC_BSN_ADDRESS.get_data_dalcn(dao)
                UC_LCN_LOCATION_ADDRESS_DETAIL.get_data(dao)
                UC_LCN_NAME_LOCATION1.get_data(dao)
                UC_LCNS_NAME.get_data_dalcn(dao)
                UC_LOCATION_ADDRESS_TEL.get_data(dao)
                UC_LCN_OPENTIME.get_data(dao)
            End If
            UC_LCN_LOCATION_ADDRESS_DETAIL.bind_lbl()
            UC_BSN_NAME2.bind_lbl()
        End If
    End Sub
    Public Sub set_hide_show()
        If Request.QueryString("edt") <> "" Then
            Dim edt As String = Request.QueryString("edt")
            Select Case edt
                Case "1"
                    Panel1.Style.Add("display", "block")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                    Panel5.Style.Add("display", "none")
                    Panel6.Style.Add("display", "none")
                    Panel7.Style.Add("display", "none")
                    Panel8.Style.Add("display", "none")
                Case "2"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "block")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                    Panel5.Style.Add("display", "none")
                    Panel6.Style.Add("display", "none")
                    Panel7.Style.Add("display", "none")
                    Panel8.Style.Add("display", "none")
                Case "3"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "block")
                    Panel4.Style.Add("display", "none")
                    Panel5.Style.Add("display", "none")
                    Panel6.Style.Add("display", "none")
                    Panel7.Style.Add("display", "none")
                    Panel8.Style.Add("display", "none")
                Case "4"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "block")
                    Panel5.Style.Add("display", "none")
                    Panel6.Style.Add("display", "none")
                    Panel7.Style.Add("display", "none")
                    Panel8.Style.Add("display", "none")
                Case "6"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                    Panel5.Style.Add("display", "block")
                    Panel6.Style.Add("display", "none")
                    Panel7.Style.Add("display", "none")
                    Panel8.Style.Add("display", "none")
                Case "7"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                    Panel5.Style.Add("display", "none")
                    Panel6.Style.Add("display", "block")
                    Panel7.Style.Add("display", "none")
                    Panel8.Style.Add("display", "none")
                Case "8"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                    Panel5.Style.Add("display", "none")
                    Panel6.Style.Add("display", "none")
                    Panel7.Style.Add("display", "block")
                    Panel8.Style.Add("display", "none")
                Case "11"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                    Panel5.Style.Add("display", "none")
                    Panel6.Style.Add("display", "none")
                    Panel7.Style.Add("display", "none")
                    Panel8.Style.Add("display", "block")
            End Select

        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("ida") <> "" Then
            Dim ida As Integer = Request.QueryString("ida")
            Dim edt As String = Request.QueryString("edt")
            Dim ida_c As Integer = Request.QueryString("ida_c")
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(ida)
            'Dim dao_lo As New DAO_CPN.TB_LOCATION_ADDRESS
            'dao_lo.GetDataby_IDA(ida)
            'Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
            'dao_bsn.Getdata_by_fk_id2(ida)

            If edt = "1" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_BSN_NAME2.set_data_his(dao_h, dao)
                UC_BSN_NAME2.set_data_dalcn(dao)


                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()

                '---------------update ของจริง
                Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_bsn.GetDataby_LCN_IDA(ida)
                Try
                    UC_BSN_NAME2.set_data_bsn(dao_bsn)
                    dao_bsn.update()
                Catch ex As Exception

                End Try
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "2" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_BSN_ADDRESS.set_data_his(dao_h, dao)
                UC_BSN_ADDRESS.set_data_dalcn(dao)

                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()

                '---------------update ของจริง
                Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_bsn.GetDataby_LCN_IDA(ida)
                Try
                    UC_BSN_ADDRESS.set_data(dao_bsn)
                    dao_bsn.update()
                Catch ex As Exception

                End Try

                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "3" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_LCN_NAME_LOCATION1.set_data_his(dao_h, dao)
                UC_LCN_NAME_LOCATION1.set_data(dao)

                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()

                '---------------update ของจริง
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                dao_da.GetDataby_IDA(ida)
                
                Try
                    Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                    dao_addr.GetDataby_IDA(dao_da.fields.FK_IDA)
                    UC_LCN_NAME_LOCATION1.set_data_addr(dao_addr)
                    dao_addr.update()
                Catch ex As Exception

                End Try

                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "4" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_LCN_LOCATION_ADDRESS_DETAIL.set_data_his(dao_h, dao)
                UC_LCN_LOCATION_ADDRESS_DETAIL.set_data(dao)

                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()

                '---------------update ของจริง
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                dao_da.GetDataby_IDA(ida)

                Try
                    Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                    dao_addr.GetDataby_IDA(dao_da.fields.FK_IDA)
                    UC_LCN_LOCATION_ADDRESS_DETAIL.set_data_addr(dao_addr)
                    dao_addr.update()
                Catch ex As Exception

                End Try

                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
                'ElseIf edt = "5" Then
                '    Dim dao_h As New DAO_DRUG.ClsDBDALCN_PHR
                '    UC_PHR_ADD.set_data(dao_h)
            ElseIf edt = "6" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_LCNS_NAME.set_data_his(dao_h, dao)
                UC_LCNS_NAME.set_data_dalcn(dao)


                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "7" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_LOCATION_ADDRESS_TEL.set_data_his(dao_h, dao)
                UC_LOCATION_ADDRESS_TEL.set_data(dao)


                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()

                '---------------update ของจริง
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                dao_da.GetDataby_IDA(ida)

                Try
                    Dim dao_addr As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                    dao_addr.GetDataby_IDA(dao_da.fields.FK_IDA)
                    UC_LOCATION_ADDRESS_TEL.set_data_addr(dao_addr)
                    dao_addr.update()
                Catch ex As Exception

                End Try
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "8" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_LCN_OPENTIME.set_data_his(dao_h, dao)
                UC_LCN_OPENTIME.set_data(dao)


                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "11" Then
                Dim dao_h As New DAO_DRUG.TB_EDT_HISTORY
                UC_BSN_SUSTAIN1.set_data_his(dao_h, dao)
                UC_BSN_SUSTAIN1.set_data_dalcn(dao)


                dao_h.fields.FK_IDA = ida_c
                dao_h.fields.EDIT_TYPE = edt
                dao_h.fields.INSERT_DATE = Date.Now
                dao_h.fields.IDEN_EDITOR = _CLS.CITIZEN_ID
                Try
                    dao_h.fields.SELECT_EDIT_DATE = CDate(txt_select_date_edit.Text)
                Catch ex As Exception

                End Try
                dao_h.insert()
                dao.update()
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            End If

            Run_Service_LCN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
            Response.Redirect(Request.Url.AbsoluteUri)
        End If
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("../EDIT_LOCATION_STAFF/FRM_EDIT_COUNT.aspx?ida=" & Request.QueryString("ida") & "&iden=" & Request.QueryString("iden") & "&process=" & Request.QueryString("process"))
    End Sub
End Class