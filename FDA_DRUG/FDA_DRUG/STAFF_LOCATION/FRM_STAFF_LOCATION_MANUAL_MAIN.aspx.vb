Imports Telerik.Web.UI
Public Class FRM_STAFF_LOCATION_MANUAL_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _type As String
    Private subtype As String
    Private _ProcessID As Integer
    Private _MENU_GROUP As String = ""
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                Dim IDA As Integer = _CLS.IDA = 99
                _CLS = Session("CLS")
                ' _type = Request.QueryString("type")
                _type = Request.QueryString("process")
                'Dim bao As New BAO.PROCESS
                _ProcessID = 99 ' ProcessID สถานที่ตั้ง
                _MENU_GROUP = Request.QueryString("MENU_GROUP")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click
        btn_add.Style.Add("display", "none")
            If String.IsNullOrEmpty(txt_SEARCH.Text) = True And String.IsNullOrEmpty(txt_NUM.Text) = True Then
                alert("กรุณากรอกข้อมูล")
            Else
            If txt_NUM.Text <> "" Then
                Dim a As String = ""
                Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
                Try
                    a = ws2.insert_taxno_authorize(txt_NUM.Text)
                Catch ex As Exception

                End Try
                Try
                    a = ws2.insert_taxno(txt_NUM.Text)
                Catch ex As Exception

                End Try

                Try
                    Dim ws1 As New WS_FDA_CITIZEN.WS_FDA_CITIZEN
                    ws1.FDA_CITIZEN(txt_NUM.Text, "1102001745831", "fusion", "P@ssw0rdfusion440")
                Catch ex As Exception

                End Try
                Try
                    Dim ws3 As New WS_TRADERS.WS_TRADER
                    ws3.CallWS_TRADER("fusion", "P@ssw0rdfusion440", txt_NUM.Text)
                Catch ex As Exception

                End Try
            End If

                Dim dao As New DAO_CPN.clsDBsyslcnsnm
                dao.GetDataby_thanm(txt_SEARCH.Text)
                Dim bao As New BAO.ClsDBSqlcommand
                Dim dt As New DataTable
                dt = bao.SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY(txt_SEARCH.Text, txt_NUM.Text)
                'If dt.Rows.Count > 0 Then
                '    btn_add.Style.Add("display", "none")
                'End If
                rg_name.DataSource = dt
                rg_name.Rebind()
            End If
    End Sub

    ''' <summary>
    ''' ใส่ URL ที่ ดูข้อมูล สถานที่ตั้ง
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID As String = item("TR_ID").Text
            'Dim DAO As New DAO_CPN.clsDBsyslcnsnm

            'Dim sql As String
            'sql = "select URL from tb_User where IDA = '&MAS_MENU=" & 

            'Dim H As HyperLink = e.Item.FindControl("HL_SELECT")
            'H.NavigateUrl = "FRM_REPLACEMENT_LICENSE_LOCATION_MENU.aspx?lct_ida=" & IDA & "&TR_ID=" & TR_ID & "&MENU_GROUP=" & _MENU_GROUP  'URL หน้า ยืนยัน
            'H.Style.Add("display", "none")
            Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
            Try
                _CLS.CITIZEN_ID_AUTHORIZE = item("IDENTIFY").Text
            Catch ex As Exception

            End Try
            Session("CLS") = _CLS
            Try
                dao.GetDataby_IDA(IDA)

                If dao.fields.STATUS_ID = 8 Then
                    'H.Style.Add("display", "block")

                End If
            Catch ex As Exception

            End Try

        End If
    End Sub



    Private Sub rg_name_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_name.ItemCommand
        Dim bao As New BAO.ClsDBSqlcommand
        Dim bao_infor As New BAO.information

        If e.CommandName = "sel" Then
            Dim item As GridDataItem
            item = e.Item
            _CLS.CITIZEN_ID_AUTHORIZE = item("IDENTIFY").Text
            _CLS = bao_infor.load_lcnsid_customer(_CLS)
            _CLS = bao_infor.load_name(_CLS)
            Session("CLS") = _CLS
            Dim dt As New DataTable
            dt = bao.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN(1, _CLS.CITIZEN_ID_AUTHORIZE)
            'RadGrid1.DataSource = BAO.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN(1, _CLS.LCNSID_CUSTOMER) 'เรียกใช้เพื่อดึงข้อมูลสถานที่ตั้ง
            'If dt.Rows.Count > 0 Then

            'End If

            btn_add.Style.Add("display", "block")

            RadGrid1.DataSource = dt

            RadGrid1.Rebind()

            Dim dt2 As New DataTable
            dt2 = bao.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDEN_V2(2, _CLS.CITIZEN_ID_AUTHORIZE)
            RadGrid2.DataSource = dt

            RadGrid2.Rebind()

        End If
    End Sub



    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim url As String = "../STAFF_LOCATION/FRM_STAFF_LOCATION_MANUAL_INSERT.aspx?iden=" & _CLS.CITIZEN_ID_AUTHORIZE
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
    End Sub

    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
        RadGrid2.Rebind()
    End Sub
End Class