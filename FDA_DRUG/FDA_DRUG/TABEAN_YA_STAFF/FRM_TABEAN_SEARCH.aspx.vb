Imports Telerik.Web.UI

Public Class FRM_TABEAN_SEARCH
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SP_DRRGT_FOR_SEARCH
        RunSession()

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim STATUS_ID As String = ""
            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(IDA)
            Try
                STATUS_ID = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If e.CommandName = "sel" Then



                Dim _process_id As String = ""
                Try
                    _process_id = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try


                lbl_titlename.Text = "พิจารณาคำขอขึ้นทะเบียนตำรับ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/POPUP_DR_CONFIRM_STAFF.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & _process_id & "&STATUS_ID=" & STATUS_ID & "&status=" & STATUS_ID & "&newcode=" & item("Newcode_U").Text & "');", True)

            ElseIf e.CommandName = "add" Then
                lbl_titlename.Text = "แก้ไขข้อมูลส่วนที่ 2"
                If Request.QueryString("e") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & IDA & "&STATUS_ID=" & STATUS_ID & "&NEWCODE=" & item("Newcode_U").Text & "&e=1" & "&type=rg'); ", True)
                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../TABEAN_YA/FRM_RQT_REGIST_INFORMATION.aspx?IDA=" & IDA & "&STATUS_ID=" & STATUS_ID & "&NEWCODE=" & item("Newcode_U").Text & "&type=rg'); ", True)
                End If

            ElseIf e.CommandName = "report" Then
                lbl_titlename.Text = "แบบฟอร์มทะเบียน"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../TABEAN_YA_STAFF/FRM_REPORT_TABEAN.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&STATUS_ID=" & STATUS_ID & "&NEWCODE=" & item("Newcode_U").Text & "&status=" & STATUS_ID & "');", True)

            ElseIf e.CommandName = "_trid" Then
                Dim TR_ID1 As String = ""
                Dim _ProcessID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                Try
                    dao_rg.GetDataby_IDA(item("IDA").Text)
                Catch ex As Exception

                End Try
                Try
                    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                Catch ex As Exception
                    bao_tran.CITIZEN_ID = ""
                End Try
                Try
                    bao_tran.CITIZEN_ID_AUTHORIZE = dao_rg.fields.IDENTIFY
                Catch ex As Exception
                    bao_tran.CITIZEN_ID_AUTHORIZE = ""
                End Try
                Try
                    _ProcessID = dao.fields.PROCESS_ID
                Catch ex As Exception

                End Try

                TR_ID1 = bao_tran.insert_transection_new("1400001")
                dao_rg.fields.TR_ID = TR_ID1
                dao_rg.update()

                Try
                    Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                    Try
                        dao_rq.GetDataby_IDA(dao.fields.FK_DRRQT)
                        dao_rq.fields.TR_ID = TR_ID1
                        dao_rq.update()
                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try

                RadGrid1.Rebind()
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_trid As LinkButton = DirectCast(item("btn_trid").Controls(0), LinkButton)
            Dim btn_add As LinkButton = DirectCast(item("btn_add").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBdrrgt
            dao.GetDataby_IDA(IDA)
            btn_trid.Style.Add("display", "none")
            btn_add.Style.Add("display", "none")
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            If tr_id = 0 Then
                btn_trid.Style.Add("display", "block")
            End If

            If Request.QueryString("e") <> "" Then
                btn_add.Style.Add("display", "block")
            End If
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'bao.SP_DRRGT_FOR_SEARCH(txt_lcnno_no.Text)
        If txt_lcnno_no.Text <> "" Then
            bao.SP_DRRGT_FOR_SEARCH_FROM_SAI(txt_lcnno_no.Text)
            dt = bao.dt
        End If


        RadGrid1.DataSource = dt
    End Sub

    Sub Search_FN()
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DRRGT_FOR_SEARCH(txt_lcnno_no.Text)
        'bao.SP_DRRGT_FOR_SEARCH_FROM_SAI(txt_lcnno_no.Text)
        Dim dt As New DataTable
        Try
            dt = bao.dt
        Catch ex As Exception

        End Try
        Dim r_result As DataRow()
        Dim str_where As String = ""
        Dim dt2 As New DataTable
        'str_where = "CITIZEN_ID_AUTHORIZE='" & txt_CITIZEN_AUTHORIZE.Text & "'"
        If txt_lcnno_no.Text <> "" Then
            str_where &= "rcvno_display like '%" & txt_lcnno_no.Text & "%'"
        End If
        r_result = dt.Select(str_where)

        dt2 = dt.Clone

        For Each dr As DataRow In r_result
            dt2.Rows.Add(dr.ItemArray)
        Next
        RadGrid1.DataSource = dt2
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'Search_FN()
        RadGrid1.Rebind()
    End Sub
End Class