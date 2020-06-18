Imports Telerik.Web.UI
Public Class FRM_ETRACKING_STATUS_HEAD_MAIN_RQ_CENTER
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
        RunSession()
        If Not IsPostBack Then
            bind_head_status()
            UC_INFORMATION_HEAD1.set_labelV2(2)
        End If
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        '_date
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As String = item("IDA").Text
            Dim HEAD_STATUS_ID As String = item("HEAD_STATUS_ID").Text
            If e.CommandName = "_date" Then

                'Dim rgttpcd As String = item("rgttpcd").Text
                'Dim lcnsid As String = item("lcnsid").Text
                Dim url2 As String = ""
                If Request.QueryString("r") <> "" Then
                    url2 = "../NEW/FRM_HEAD_ETRACKING_DATE_POPUP.aspx?IDA=" & IDA & "&id_r=" & Request.QueryString("id_r")

                Else
                    url2 = "../NEW/FRM_HEAD_ETRACKING_DATE_POPUP.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & IDA & "&drgtpcd=" & Request.QueryString("drgtpcd")
                End If
                Response.Redirect(url2)
            ElseIf e.CommandName = "sel" Then
                'Dim IDA As String = item("IDA").Text
                Dim url2 As String = "../FRM_DRRGT_STATUS_POPUPV2.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & IDA & "&head=" & HEAD_STATUS_ID & "&drgtpcd=" & Request.QueryString("drgtpcd")
                If Request.QueryString("FK_IDA") <> "" Then
                    url2 &= "&FK_IDA=" & Request.QueryString("FK_IDA")
                End If
                Response.Redirect(url2)
            End If

        End If
        '
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim head_id As String = ""

            Try
                head_id = item("HEAD_STATUS_ID").Text
            Catch ex As Exception

            End Try
            Dim btn_expert As LinkButton = DirectCast(item("btn_expert").Controls(0), LinkButton)
            btn_expert.Style.Add("display", "none")
            If head_id = 4 Then
                btn_expert.Style.Add("display", "block")
            End If
            Dim url As String = "../FRM_EXPERT_ASSIGN_V4.aspx?ida=" & ida & "&id_r=" & Request.QueryString("id_r")
            btn_expert.PostBackUrl = url

            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('FRM_EXPERT_ASSIGN_V2.aspx?ida=" & ida & "&rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "'); ", True)
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_GET_E_TRACKING_HEAD_CURRENT_STATUS_BY_IDA(Request.QueryString("id_r"))

        RadGrid1.DataSource = dt
    End Sub
    Sub bind_head_status()
        Dim dao As New DAO_DRUG.TB_MAS_HEAD_STATUS_E_TRACKING
        dao.Get_non_Extra()
        ddl_head_status.DataSource = dao.datas
        ddl_head_status.DataTextField = "FDA_STATUS"
        ddl_head_status.DataValueField = "STATUS_ROW"
        ddl_head_status.DataBind()
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If ddl_head_status.SelectedValue = 10 Then
            Dim i As Integer = 0
            Dim dao_c As New DAO_DRUG.TB_E_TRACKING_STOP_TIME
            i = dao_c.CountDataby_IDA(Request.QueryString("id_r"))
            If i = 0 Then
                save()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ท่านบันทึกวันที่ในหน้าหยุดเวลาไม่ครบ อาจมีผลต่อการคำนวณคำขอ');", True)
            End If
        Else
            save()
        End If
        
    End Sub
    Sub save()
        Dim dao As New DAO_DRUG.TB_E_TRACKING_HEAD_CURRENT_STATUS
        dao.fields.HEAD_STATUS_ID = ddl_head_status.SelectedValue
        dao.fields.FK_IDA = Request.QueryString("id_r")
        dao.fields.IS_EXTRA_STAGE = 0
        dao.fields.STATUS_INDEX = ddl_head_status.SelectedValue
        dao.fields.PRODUCT_TYPE = 99
        dao.fields.CREATE_DATE = Date.Now
        Try
            dao.fields.STAFF_CITIZEN = _CLS.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try

        dao.insert()

        Try
            Dim dao_h As New DAO_DRUG.TB_E_TRACKING_HEAD_CURRENT_STATUS
            dao_h.Get_HEAD_STATUS_by_FK_IDA_MAX(Request.QueryString("id_r"))

            Dim dao_d As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            dao_d.GetDataby_IDA(Request.QueryString("id_r"))
            dao_d.fields.LASTEST_STATUS = dao_h.fields.HEAD_STATUS_ID
            dao_d.update()
        Catch ex As Exception

        End Try

        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มช่วงสถานะ ->" & ddl_head_status.SelectedItem.Text, "")
        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มช่วงสถานะ ->" & ddl_head_status.SelectedItem.Text, "")
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มช่วงสถานะ ->" & ddl_head_status.SelectedItem.Text, "")

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มช่วงสถานะ ->" & ddl_head_status.SelectedItem.Text, "")

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'https://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        AddLogStatusEtracking(ddl_head_status.SelectedValue, 2, _CLS.CITIZEN_ID, "เพิ่มช่วงสถานะ ->" & ddl_head_status.SelectedItem.Text, "เพิ่มช่วงสถานะ", Request.QueryString("id_r"), dao.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        RadGrid1.Rebind()
    End Sub

End Class