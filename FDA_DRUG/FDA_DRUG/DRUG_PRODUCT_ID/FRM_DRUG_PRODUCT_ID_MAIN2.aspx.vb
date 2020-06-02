Public Class FRM_DRUG_PRODUCT_ID_MAIN2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private _lct_ida As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_GV_lcnno()
        End If
    End Sub
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx?process=" & _process & "&lct_ida=" & Request.QueryString("lct_ida") & "&lcn_ida=" & Request.QueryString("lcn_ida") & "');", True)
    End Sub
    Private Sub btn_add2_Click(sender As Object, e As EventArgs) Handles btn_add2.Click

        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        Dim bool As Boolean = False
        Try
            bool = dao.count_stat8(_CLS.CITIZEN_ID_AUTHORIZE)
        Catch ex As Exception

        End Try
        If bool = True Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_LINK_SELECT.aspx?process=" & _process & "&lct_ida=" & Request.QueryString("lct_ida") & "&lcn_ida=" & Request.QueryString("lcn_ida") & "&c=1');", True)
            '
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx?process=" & _process & "&c=1');", True)

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถเพิ่มข้อมูลได้ คุณต้องมีผลิตภัณฑ์ที่ได้รับอนุญาตอย่างน้อย 1 รายการ');", True)

        End If



        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_LINK_SELECT.aspx?process=" & _process & "&lct_ida=" & Request.QueryString("lct_ida") & "&lcn_ida=" & Request.QueryString("lcn_ida") & "&c=1');", True)

        ''System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx?process=" & _process & "&c=1');", True)
    End Sub
    Sub load_GV_lcnno()
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_DRUG_PRODUCT_ID_BY_FK_IDA3(_CLS.CITIZEN_ID_AUTHORIZE)
        Try
            GV_lcnno.DataSource = bao.dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
            GV_lcnno.DataBind()
        Catch ex As Exception

        End Try
        'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub

    Private Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        If e.CommandName = "del" Then
            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao.GetDataby_IDA(str_ID)
            dao.delete()
            Response.Write("<script type='text/javascript'>alert('ลบข้อมูลเรียบร้อย');</script> ")
            load_GV_lcnno()
        ElseIf e.CommandName = "_cancel" Then
            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao.GetDataby_IDA(str_ID)
            dao.fields.CANCEL_DATE = Date.Now
            dao.fields.CANCEL_STATUS = 1
            dao.fields.CANCEL_TYPE = 2
            dao.update()
            load_GV_lcnno()
        ElseIf e.CommandName = "accept" Then
            Dim IDA As Integer = 0
            Try
                IDA = Request.QueryString("IDA")
            Catch ex As Exception

            End Try
            Dim statusID As Integer = 8
            Dim bao As New BAO.GenNumber

            'Dim rcvno As String = bao.GEN_NO_17(con_year(Date.Now.Year()), _CLS.PVCODE, 19, _CLS.LCNNO, "", 0, IDA, "")
            'Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao.GetDataby_IDA(str_ID)

            Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
            dao_date.fields.FK_IDA = str_ID
            Try
                dao_date.fields.STATUS_DATE = Date.Now
            Catch ex As Exception

            End Try

            dao_date.fields.STATUS_GROUP = 4 'ชื่อสาร
            dao_date.fields.STATUS_ID = 8
            dao_date.fields.DATE_NOW = Date.Now
            dao_date.insert()


            Dim lcnno As String = bao.GEN_NO_16(con_year(Date.Now.Year()), _CLS.PVCODE, 40, _CLS.LCNNO, "", 0, str_ID, "")
            dao.fields.STATUS_ID = 8
            Try
                dao.fields.APPDATE = CDate(Date.Now)
                dao.fields.LCNNODATE = CDate(Date.Now)
            Catch ex As Exception

            End Try

            dao.fields.LCNNO = lcnno
            dao.fields.LCNNO_DISPLAY = "D" & lcnno
            dao.update()
            alert("ทำการอนุมัติข้อมูลเรียบร้อยแล้ว เลขผลิตภันฑ์คือ " & "D" & lcnno)

            load_GV_lcnno()
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()
    End Sub

    Private Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim btn_accept As Button = DirectCast(e.Row.FindControl("btn_accept"), Button)
            Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
            '

            Dim btn_cancel As Button = DirectCast(e.Row.FindControl("btn_cancel"), Button)
            Dim id As String = GV_lcnno.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            btn_Select.Attributes.Add("onclick", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx?IDA=" & id & "&lct_ida=" & _lct_ida & "'); return false;")

            btn_edit.Attributes.Add("onclick", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_EDIT_EXTRA.aspx?IDA=" & id & "&lct_ida=" & _lct_ida & "'); return false;")

            btn_edit.Style.Add("display", "none")
            btn_cancel.Style.Add("display", "none")
            Dim stat As Integer = 0
            Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            Try
                dao.GetDataby_IDA(id)
                stat = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try

            If stat > 1 Then
                btn_accept.Style.Add("display", "none")
            End If
            If stat = 8 Then
                btn_edit.Style.Add("display", "block")
                btn_cancel.Style.Add("display", "block")
            End If


            'Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            'Dim btn_accept As Button = DirectCast(e.Row.FindControl("btn_accept"), Button)
            ''
            'Dim id As String = GV_lcnno.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            'btn_Select.Attributes.Add("onclick", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx?IDA=" & id & "&lct_ida=" & _lct_ida & "'); return false;")

            'Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            'Try
            '    dao.GetDataby_IDA(id)
            '    If dao.fields.STATUS_ID > 1 Then
            '        btn_accept.Style.Add("display", "none")
            '    End If
            'Catch ex As Exception

            'End Try

        End If
    End Sub
End Class