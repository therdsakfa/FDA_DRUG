Imports Telerik.Web.UI

Public Class FRM_REPLACEMENT_BOOKING_EDIT
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
            'RadDatePicker1.SelectedDate = Date.Now()
            'load_ddlChannel()
            'load_gv_all()
        End If
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

    'Private Sub load_ddlChannel()

    '    Dim bao As New BAO.CLS_SQL_COMMAND
    '    bao.SP_CHANNEL_BY_DEPARTMENT_TYPE_ID(_DEPARTMENT_TYPE_ID)

    '    Ddl_Channel.DataTextField = "CHANNEL_NAME"
    '    Ddl_Channel.DataValueField = "CHANNEL_ID"
    '    Ddl_Channel.DataSource = bao.dt

    '    Ddl_Channel.DataBind()
    '    Ddl_Channel.Items.Insert(0, New ListItem("ทั้งหมด", "all"))

    'End Sub


    'Public Sub load_gv_all()
    '    Dim bao As New BAO.CLS_SQL_COMMAND
    '    bao.SP_DRUG_SCHEDULE_STAFF_2()

    '    Gv_booking.DataSource = bao.dt
    '    Gv_booking.DataBind()
    'End Sub



    'Public Sub load_gv()
    '    Dim bao As New BAO.CLS_SQL_COMMAND
    '    'bao.SP_SCHEDULE(_DEPARTMENT_TYPE_ID)
    '    If Ddl_Channel.SelectedValue = "all" And IsNothing(RadDatePicker1.SelectedDate()) = True Then
    '        alert("เมื่อเลือกกระบวนการทั้งหมด ต้องระบุวันที่ต้องการ")
    '    ElseIf Ddl_Channel.SelectedValue = "all" Then
    '        bao.SP_SCHEDULE_BY_SCHEDULE_DATE_STAFF(_DEPARTMENT_TYPE_ID, RadDatePicker1.SelectedDate())
    '    Else
    '        If IsNothing(RadDatePicker1.SelectedDate()) = True Then
    '            alert("กรุณาระบุวันที่ต้องการ")
    '        Else
    '            bao.SP_SCHEDULE_BY_SCHEDULE_DATE_AND_CHANNEL_ID_STAFF(_DEPARTMENT_TYPE_ID, RadDatePicker1.SelectedDate(), Ddl_Channel.SelectedValue)
    '        End If
    '    End If
    '    Gv_booking.DataSource = bao.dt
    '    Gv_booking.DataBind()
    'End Sub


    'Protected Sub Ddl_Channel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ddl_Channel.SelectedIndexChanged
    '    load_gv_all()
    'End Sub


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
                If e.CommandName = "edit_CONSIDER_DATE" Then
                    lbl_modal.Text = "แก้ไขวันที่ส่งเอกสาร"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_BOOKING_EDIT_DATE.aspx?SCHEDULE_ID=" & IDA & "&TYPE_EDIT=1" & "');", True)

                ElseIf e.CommandName = "edit_ALLOW_DATE" Then
                    lbl_modal.Text = "แก้ไขวันที่ฟังผลการตรวจรับ"
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_BOOKING_EDIT_DATE.aspx?SCHEDULE_ID=" & IDA & "&TYPE_EDIT=2" & "');", True)

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


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
        Try
            rg_MAIN.Rebind()
        Catch ex As Exception

        End Try

    End Sub
End Class