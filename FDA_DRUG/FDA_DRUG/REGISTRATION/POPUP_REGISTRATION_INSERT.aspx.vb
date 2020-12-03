Public Class POPUP_REGISTRATION_INSERT
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _IDA As Integer
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _R_ProcessID As String = ""
    Sub runQuery()
        _ProcessID = Request.QueryString("process")
        _R_ProcessID = Request.QueryString("r_process")
        '_IDA = Request.QueryString("IDA")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
    End Sub
    Sub RunSession()

        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            '_ProcessID = Request.QueryString("type")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
        If Request.QueryString("tt") <> "" Then
            If Request.QueryString("val") = "0" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ท่านยังไม่ได้เลือกตำรับ');parent.close_modal();", True)
            End If
        End If

        If Not IsPostBack Then
            If Request.QueryString("staff") <> "" Then
                If Request.QueryString("staff") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("staff"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If

            Dim dao_d As New DAO_DRUG.TB_MAS_TAMRAP_NAME
            Try
                dao_d.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                txt_DRUG_NAME_THAI.Text = dao_d.fields.TAMRAP_NAME
            Catch ex As Exception

            End Try

            'If Request.QueryString("tt") <> "" Then
            If Request.QueryString("tt") = "2" Then
                txt_DRUG_NAME_THAI.Enabled = False
                txt_DRUG_NAME_OTHER.Enabled = False
            End If

            'End If
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim i As Integer = Len(txt_DRUG_COLOR.Text)


        If i >= 9 Or Request.QueryString("tt") = "" Then
            If txt_DRUG_NAME_OTHER.Text = "" And txt_DRUG_NAME_THAI.Text = "" Then
                Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณากรอกชื่อการค้าภาษาไทยหรือภาษาอังกฤษ');</script> ")
            ElseIf txt_DRUG_COLOR.Text = "" And Len(txt_DRUG_COLOR.Text) > 3 Then
                Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณากรอกคำบรรยายลักษณะของยา');</script> ")
            Else
                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()


                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION
                Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                dao_dal.GetDataby_IDA(_lcn_ida)


                Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao.fields.TR_ID = TR_ID
                dao.fields.DRUG_NAME_OTHER = txt_DRUG_NAME_OTHER.Text
                dao.fields.DRUG_NAME_THAI = txt_DRUG_NAME_THAI.Text
                dao.fields.DRUG_COLOR = txt_DRUG_COLOR.Text
                dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao.fields.FK_IDA = _lcn_ida
                dao.fields.DRUG_NEW = RadioButtonList1.SelectedValue
                dao.fields.STATUS_ID = 1
                Try
                    dao.fields.PVNCD = _CLS.PVCODE
                Catch ex As Exception

                End Try
                Try
                    dao.fields.LCNTPCD = dao_dal.fields.lcntpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.LCNNO = dao_dal.fields.lcnno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.RCVDATE = Date.Now
                Catch ex As Exception

                End Try

                Try
                    dao.fields.PROCESS_ID = _ProcessID
                Catch ex As Exception

                End Try

                Try
                    dao.fields.DRUG_EQ_TO = Request.QueryString("val")
                Catch ex As Exception

                End Try
                If Request.QueryString("tt") <> "" Then

                    If Request.QueryString("val") <> "" Then

                        Dim dao_15_g As New DAO_DRUG.TB_15_TAMRAP_GENERAL

                        Try
                            dao_15_g.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.GROUP_TYPE = dao_15_g.fields.classcd
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.FK_DOSAGE_FORM = dao_15_g.fields.dsgcd
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.UNIT_NORMAL = dao_15_g.fields.NORMAL_UNIT
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.DRUG_GROUP = dao_15_g.fields.ctgcd
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.kindcd = dao_15_g.fields.kindcd
                        Catch ex As Exception

                        End Try

                        Dim dao_15_pcksize As New DAO_DRUG.TB_15_TAMRAP_PACKSIZE
                        dao_15_pcksize.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        dao.fields.PACKAGE_DETAIL = dao_15_pcksize.fields.pcksize
                    End If
                End If
                dao.insert()
                Dim ida_main As Integer = dao.fields.IDA

                If Request.QueryString("tt") <> "" Then
                    If Request.QueryString("val") <> "" Then

                        Dim dao_15_t As New DAO_DRUG.TB_15_TAMRAP_TEMPLATE
                        Try
                            dao_15_t.GetDataby_TAMRAP_ID(Request.QueryString("val"))

                        Catch ex As Exception

                        End Try
                        For Each dao_15_t.fields In dao_15_t.datas
                            Dim dao_cas As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                            With dao_cas.fields
                                .AORI = dao_15_t.fields.AORI
                                Try
                                    .BASE_FORM = dao_15_t.fields.BASE_FORM
                                Catch ex As Exception

                                End Try
                                .FK_IDA = ida_main
                                .IOWA = dao_15_t.fields.IOWA
                                .IOWACD = dao_15_t.fields.IOWA
                                Try
                                    .QTY = dao_15_t.fields.QTY
                                Catch ex As Exception

                                End Try
                                .ROWS = dao_15_t.fields.ROWS
                                .SUNITCD = dao_15_t.fields.SUNITCD
                                .FK_SET = dao_15_t.fields.FK_SET
                            End With
                            dao_cas.insert()

                            Dim dao_eq As New DAO_DRUG.TB_15_TAMRAP_EQTO
                            dao_eq.GetDataby_FK_IDA(dao_15_t.fields.IDA, 1)
                            For Each dao_eq.fields In dao_eq.datas
                                Dim dao_eq_rgt As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                                With dao_eq_rgt.fields
                                    .FK_IDA = dao_cas.fields.IDA
                                    .IOWA = dao_eq.fields.IOWA
                                    .MULTIPLY = dao_eq.fields.MULTIPLY
                                    .QTY = dao_eq.fields.QTY
                                    .ROWS = dao_eq.fields.ROWS
                                    .STR_VALUE = dao_eq.fields.STR_VALUE
                                    .SUNITCD = dao_eq.fields.SUNITCD
                                    .FK_SET = dao_eq.fields.FK_SET
                                    .FK_REGIST = ida_main
                                    .mltplr = dao_eq.fields.mltplr
                                    .CONDITION = dao_eq.fields.CONDITION
                                End With
                                dao_eq_rgt.insert()
                            Next
                        Next


                        Dim dao_15_e As New DAO_DRUG.TB_15_TAMRAP_EACH
                        dao_15_e.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_e.fields In dao_15_e.datas
                            Dim dao_ea As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
                            With dao_ea.fields
                                .EACH_AMOUNT = dao_15_e.fields.EACH_AMOUNT
                                .FK_IDA = ida_main
                                .sunitcd = dao_15_e.fields.sunitcd
                                .FK_SET = 1
                            End With
                            dao_ea.insert()
                        Next

                        Dim dao_15_pack_det As New DAO_DRUG.TB_15_TAMRAP_PACK_DETAIL
                        dao_15_pack_det.Getdata_by_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_pack_det.fields In dao_15_pack_det.datas
                            Dim dao_pack_det2 As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                            With dao_pack_det2.fields
                                .BARCODE = dao_15_pack_det.fields.BARCODE
                                .FK_IDA = ida_main
                                .BIG_AMOUNT = dao_15_pack_det.fields.BIG_AMOUNT
                                .BIG_UNIT = dao_15_pack_det.fields.BIG_UNIT
                                .CHECK_PACKAGE = dao_15_pack_det.fields.CHECK_PACKAGE
                                '.DATE_ADD
                                .IM_DETAIL = dao_15_pack_det.fields.IM_DETAIL
                                .IM_QTY = dao_15_pack_det.fields.IM_QTY
                                .MEDIUM_AMOUNT = dao_15_pack_det.fields.MEDIUM_AMOUNT
                                .MEDIUM_UNIT = dao_15_pack_det.fields.MEDIUM_UNIT
                                .order_id = dao_15_pack_det.fields.order_id
                                .PACKAGE_NAME = dao_15_pack_det.fields.PACKAGE_NAME
                                .SMALL_AMOUNT = dao_15_pack_det.fields.SMALL_AMOUNT
                                .SMALL_UNIT = dao_15_pack_det.fields.SMALL_UNIT
                                .SUM = dao_15_pack_det.fields.SUM
                            End With
                            dao_pack_det2.insert()
                        Next

                        Dim dao_15_dtl As New DAO_DRUG.TB_15_TAMRAP_DTL
                        dao_15_dtl.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_dtl.fields In dao_15_dtl.datas
                            Dim dao_dtl As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
                            With dao_dtl.fields
                                .DRUG_USE = dao_15_dtl.fields.dtl
                                .FK_IDA = ida_main
                            End With
                            dao_dtl.insert()
                        Next

                        Dim dao_15_atc As New DAO_DRUG.TB_15_TAMRAP_ATC
                        dao_15_atc.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_atc.fields In dao_15_atc.datas
                            Dim dao_atc As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
                            With dao_atc.fields
                                .ATC_CODE = dao_15_atc.fields.atccd
                                .ATC_IDA = dao_15_atc.fields.atcd_IDA
                                .FK_IDA = ida_main
                            End With
                            dao_atc.insert()
                        Next

                        Try
                            If dao_dal.fields.lcntpcd.Contains("ผย") Then
                                Dim dtt As New DataTable
                                Dim bao_pro As New BAO.ClsDBSqlcommand
                                dtt = bao_pro.SP_GET_REGIST_PRODUCCER_IN(dao_dal.fields.IDA, ida_main)

                                For Each drr As DataRow In dtt.Rows
                                    Dim dao_proo As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                                    With dao_proo.fields
                                        .addr_ida = drr("FK_IDA")
                                        .FK_PRODUCER = drr("IDA")
                                        .PRODUCER_WORK_TYPE = drr("funccd")
                                        .FK_IDA = ida_main
                                    End With
                                    dao_proo.insert()
                                Next
                            End If
                        Catch ex As Exception

                        End Try


                    End If
                End If
                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End If
        ElseIf Request.QueryString("tt") <> "" Then
            If txt_DRUG_NAME_OTHER.Text = "" And txt_DRUG_NAME_THAI.Text = "" Then
                Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณากรอกชื่อการค้าภาษาไทยหรือภาษาอังกฤษ');</script> ")
            ElseIf txt_DRUG_COLOR.Text = "" Then
                Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณากรอกคำบรรยายลักษณะของยา');</script> ")
            Else
                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()


                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION
                Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                dao_dal.GetDataby_IDA(_lcn_ida)


                Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao.fields.TR_ID = TR_ID
                dao.fields.DRUG_NAME_OTHER = txt_DRUG_NAME_OTHER.Text
                dao.fields.DRUG_NAME_THAI = txt_DRUG_NAME_THAI.Text
                dao.fields.DRUG_COLOR = txt_DRUG_COLOR.Text
                dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao.fields.FK_IDA = _lcn_ida
                dao.fields.DRUG_NEW = RadioButtonList1.SelectedValue
                dao.fields.STATUS_ID = 1
                Try
                    dao.fields.PVNCD = _CLS.PVCODE
                Catch ex As Exception

                End Try
                Try
                    dao.fields.LCNTPCD = dao_dal.fields.lcntpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.LCNNO = dao_dal.fields.lcnno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.RCVDATE = Date.Now
                Catch ex As Exception

                End Try

                Try
                    dao.fields.PROCESS_ID = _ProcessID
                Catch ex As Exception

                End Try

                Try
                    dao.fields.DRUG_EQ_TO = Request.QueryString("val")
                Catch ex As Exception

                End Try
                If Request.QueryString("tt") <> "" Then

                    If Request.QueryString("val") <> "" Then

                        Dim dao_15_g As New DAO_DRUG.TB_15_TAMRAP_GENERAL

                        Try
                            dao_15_g.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.GROUP_TYPE = dao_15_g.fields.classcd
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.FK_DOSAGE_FORM = dao_15_g.fields.dsgcd
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.UNIT_NORMAL = dao_15_g.fields.NORMAL_UNIT
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.DRUG_GROUP = dao_15_g.fields.ctgcd
                        Catch ex As Exception

                        End Try
                        Try
                            dao.fields.kindcd = dao_15_g.fields.kindcd
                        Catch ex As Exception

                        End Try

                        Dim dao_15_pcksize As New DAO_DRUG.TB_15_TAMRAP_PACKSIZE
                        dao_15_pcksize.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        dao.fields.PACKAGE_DETAIL = dao_15_pcksize.fields.pcksize
                    End If
                End If
                dao.insert()
                Dim ida_main As Integer = dao.fields.IDA

                If Request.QueryString("tt") <> "" Then
                    If Request.QueryString("val") <> "" Then

                        Dim dao_15_t As New DAO_DRUG.TB_15_TAMRAP_TEMPLATE
                        Try
                            dao_15_t.GetDataby_TAMRAP_ID(Request.QueryString("val"))

                        Catch ex As Exception

                        End Try
                        For Each dao_15_t.fields In dao_15_t.datas
                            Dim dao_cas As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                            With dao_cas.fields
                                .AORI = dao_15_t.fields.AORI
                                Try
                                    .BASE_FORM = dao_15_t.fields.BASE_FORM
                                Catch ex As Exception

                                End Try
                                .FK_IDA = ida_main
                                .IOWA = dao_15_t.fields.IOWA
                                .IOWACD = dao_15_t.fields.IOWA
                                Try
                                    .QTY = dao_15_t.fields.QTY
                                Catch ex As Exception

                                End Try
                                .ROWS = dao_15_t.fields.ROWS
                                .SUNITCD = dao_15_t.fields.SUNITCD
                                .FK_SET = dao_15_t.fields.FK_SET
                            End With
                            dao_cas.insert()

                            Dim dao_eq As New DAO_DRUG.TB_15_TAMRAP_EQTO
                            dao_eq.GetDataby_FK_IDA(dao_15_t.fields.IDA, 1)
                            For Each dao_eq.fields In dao_eq.datas
                                Dim dao_eq_rgt As New DAO_DRUG.TB_DRUG_REGISTRATION_EQTO
                                With dao_eq_rgt.fields
                                    .FK_IDA = dao_cas.fields.IDA
                                    .IOWA = dao_eq.fields.IOWA
                                    .MULTIPLY = dao_eq.fields.MULTIPLY
                                    .QTY = dao_eq.fields.QTY
                                    .ROWS = dao_eq.fields.ROWS
                                    .STR_VALUE = dao_eq.fields.STR_VALUE
                                    .SUNITCD = dao_eq.fields.SUNITCD
                                    .FK_SET = dao_eq.fields.FK_SET
                                    .FK_REGIST = ida_main
                                    .mltplr = dao_eq.fields.mltplr
                                    .CONDITION = dao_eq.fields.CONDITION
                                End With
                                dao_eq_rgt.insert()
                            Next
                        Next


                        Dim dao_15_e As New DAO_DRUG.TB_15_TAMRAP_EACH
                        dao_15_e.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_e.fields In dao_15_e.datas
                            Dim dao_ea As New DAO_DRUG.TB_DRUG_REGISTRATION_EACH
                            With dao_ea.fields
                                .EACH_AMOUNT = dao_15_e.fields.EACH_AMOUNT
                                .FK_IDA = ida_main
                                .sunitcd = dao_15_e.fields.sunitcd
                                .FK_SET = 1
                            End With
                            dao_ea.insert()
                        Next

                        Dim dao_15_pack_det As New DAO_DRUG.TB_15_TAMRAP_PACK_DETAIL
                        dao_15_pack_det.Getdata_by_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_pack_det.fields In dao_15_pack_det.datas
                            Dim dao_pack_det2 As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
                            With dao_pack_det2.fields
                                .BARCODE = dao_15_pack_det.fields.BARCODE
                                .FK_IDA = ida_main
                                .BIG_AMOUNT = dao_15_pack_det.fields.BIG_AMOUNT
                                .BIG_UNIT = dao_15_pack_det.fields.BIG_UNIT
                                .CHECK_PACKAGE = dao_15_pack_det.fields.CHECK_PACKAGE
                                '.DATE_ADD
                                .IM_DETAIL = dao_15_pack_det.fields.IM_DETAIL
                                .IM_QTY = dao_15_pack_det.fields.IM_QTY
                                .MEDIUM_AMOUNT = dao_15_pack_det.fields.MEDIUM_AMOUNT
                                .MEDIUM_UNIT = dao_15_pack_det.fields.MEDIUM_UNIT
                                .order_id = dao_15_pack_det.fields.order_id
                                .PACKAGE_NAME = dao_15_pack_det.fields.PACKAGE_NAME
                                .SMALL_AMOUNT = dao_15_pack_det.fields.SMALL_AMOUNT
                                .SMALL_UNIT = dao_15_pack_det.fields.SMALL_UNIT
                                .SUM = dao_15_pack_det.fields.SUM
                            End With
                            dao_pack_det2.insert()
                        Next

                        Dim dao_15_dtl As New DAO_DRUG.TB_15_TAMRAP_DTL
                        dao_15_dtl.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_dtl.fields In dao_15_dtl.datas
                            Dim dao_dtl As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
                            With dao_dtl.fields
                                .DRUG_USE = dao_15_dtl.fields.dtl
                                .FK_IDA = ida_main
                            End With
                            dao_dtl.insert()
                        Next

                        Dim dao_15_atc As New DAO_DRUG.TB_15_TAMRAP_ATC
                        dao_15_atc.GetDataby_TAMRAP_ID(Request.QueryString("val"))
                        For Each dao_15_atc.fields In dao_15_atc.datas
                            Dim dao_atc As New DAO_DRUG.TB_DRUG_REGISTRATION_ATC_DETAIL
                            With dao_atc.fields
                                .ATC_CODE = dao_15_atc.fields.atccd
                                .ATC_IDA = dao_15_atc.fields.atcd_IDA
                                .FK_IDA = ida_main
                            End With
                            dao_atc.insert()
                        Next

                        Try
                            If dao_dal.fields.lcntpcd.Contains("ผย") Then
                                Dim dtt As New DataTable
                                Dim bao_pro As New BAO.ClsDBSqlcommand
                                dtt = bao_pro.SP_GET_REGIST_PRODUCCER_IN(dao_dal.fields.IDA, ida_main)

                                For Each drr As DataRow In dtt.Rows
                                    Dim dao_proo As New DAO_DRUG.TB_DRUG_REGISTRATION_PRODUCER_IN
                                    With dao_proo.fields
                                        .addr_ida = drr("FK_IDA")
                                        .FK_PRODUCER = drr("IDA")
                                        .PRODUCER_WORK_TYPE = drr("funccd")
                                        .FK_IDA = ida_main
                                    End With
                                    dao_proo.insert()
                                Next
                            End If
                        Catch ex As Exception

                        End Try


                    End If
                End If
                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End If
        Else
            Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถบันทึกได้ กรุณากรอกคำบรรยายลักษณะของยา');</script> ")
        End If

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub

End Class