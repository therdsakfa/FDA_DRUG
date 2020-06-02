Imports Telerik.Web.UI

Public Class FRM_REPLACEMENT_BOOKING
    Inherits System.Web.UI.Page
    Private _DEPARTMENT_TYPE_ID As String
    Private _CLS As New CLS_SESSION

    Sub RunAppSettings()
        _DEPARTMENT_TYPE_ID = System.Configuration.ConfigurationManager.AppSettings("DEPARTMENT_TYPE_ID")
    End Sub
    Private Sub RunSession()

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
        RunAppSettings()
        RunSession()
        If Not Page.IsPostBack Then
            'load_Ddl_date()
            'load_Txt_schedule_date()
            ' RadDatePicker1.SelectedDate = Date.Now()
            'load_ddlChannel()

        End If
    End Sub

    Protected Sub Btn_save_Click(sender As Object, e As EventArgs) Handles Btn_save.Click
        ' Session("SCHEDULE_DATE") = RadDatePicker1.SelectedDate()
        ' Session("CHANNEL") = Ddl_Channel.SelectedValue.ToString()
        ' OpenPopupName("POPUP_SCHEDULE_ADD.aspx")
        Response.Redirect("FRM_REPLACEMENT_DRUG_BOOKING_INSERT_WAY.aspx")
    End Sub
    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'Ratting', 'width=800,height=600,left=20,top=50,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub

    'Protected Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
    '    Dim bao As New BAO.CLS_SQL_COMMAND
    '    'bao.SP_SCHEDULE(_DEPARTMENT_TYPE_ID)
    '    bao.SP_SCHEDULE_BY_SCHEDULE_DATE_AND_CHANNEL_ID(_DEPARTMENT_TYPE_ID, Date.Parse(Ddl_date.SelectedValue), Ddl_Channel.SelectedValue)
    '    Gv_booking.DataSource = bao.dt
    '    Gv_booking.DataBind()
    'End Sub


    'Private Sub load_Txt_schedule_date()
    '    Txt_schedule_date.Text = Date.Now().ToString("dd/MM/yyyy")
    'End Sub




    'Public Sub load_Ddl_date()

    '    Dim dt As DataTable = New DataTable

    '    dt.Columns.Add("date", Type.GetType("System.String"))
    '    For i As Integer = 0 To 60
    '        dt.Rows.Add(Date.Now.AddDays(i).ToString("dd/MM/yyyy"))
    '        'dt.Rows.Add(Date.Now.AddDays(i).Day.ToString() + "/" + Date.Now.AddDays(i).Month.ToString + "/" + Date.Now.AddDays(i).Year.ToString())
    '    Next
    '    Ddl_date.DataSource = dt
    '    Ddl_date.DataTextField = "date"
    '    Ddl_date.DataValueField = "date"
    '    Ddl_date.DataBind()
    'End Sub

    'Protected Sub Ddl_date_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ddl_date.SelectedIndexChanged
    '    load_gv()
    'End Sub



   
    Protected Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        Try


            Dim str As String = ""
            str = UC_DRUG_SEARCH.getSearchMsg()


            rg_MAIN.EnableLinqExpressions = False
            rg_MAIN.MasterTableView.FilterExpression = str
            rg_MAIN.MasterTableView.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        rg_MAIN.Rebind()
    End Sub

    Private Sub rg_MAIN_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_MAIN.NeedDataSource
        Try


            Dim bao As New BAO.ClsDBSqlcommand
            bao.SP_DRUG_SCHEDULE_STAFF_2()

            rg_MAIN.DataSource = bao.dt
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rg_MAIN_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_MAIN.ItemCommand
        Try


            If TypeOf e.Item Is GridDataItem Then
                Dim item As GridDataItem
                item = e.Item
                Dim IDA As Integer = item("SCHEDULE_ID").Text
                If e.CommandName = "status" Then
                    lbl_modal.Text = "ปรับสถานะ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_DRUG_BOOKING_STATUS.aspx?SCHEDULE_ID=" & IDA & "');", True)

                ElseIf e.CommandName = "doc" Then
                    ' Session("SCHEDULE_DATE") = RadDatePicker1.SelectedDate()
                    'Session("CHANNEL") = Ddl_Channel.SelectedValue.ToString()
                    ' OpenPopupName("FRM_REPLACEMENT_BOOKING_DOCUMENT.aspx?SCHEDULE_ID=" & str_SCHEDULE_ID)
                    lbl_modal.Text = "ใบนัดส่งเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_BOOKING_DOCUMENT.aspx?SCHEDULE_ID=" & IDA & "');", True)
                ElseIf e.CommandName = "doc2" Then
                    'OpenPopupName("FRM_REPLACEMENT_BOOKING_DOCUMENT_2.aspx?SCHEDULE_ID=" & str_SCHEDULE_ID)
                    lbl_modal.Text = "ใบนัดฟังผลการตรวจรับ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_BOOKING_DOCUMENT_2.aspx?SCHEDULE_ID=" & IDA & "');", True)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class