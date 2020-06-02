Public Class FRM_REPLACEMENT_DRUG_BOOKING_STATUS
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private Sub RunSession()
        _IDA = Request.QueryString("SCHEDULE_ID")
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
            set_status()
            get_information()
            get_data()
        End If
    End Sub

    ''' <summary>
    ''' ดึงข้อมูลเบื้องต้นมาแสดง
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub get_information()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_DRUG_SCHEDULE_STAFF_by_SCHEDULE_ID_2(CDec(_IDA))
        UC_NCT_INFORMATION.get_information(dt)
    End Sub

    ''' <summary>
    ''' ดึงข้อมูล
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub get_data()
        Dim dao As New DAO_BOOKING.TB_DRUG_SCHEDULE
        dao.GetDataby_SCHEDULE_ID(_IDA)

        txt_remark.Text = dao.fields.STATUS_REMARK
        If String.IsNullOrEmpty(dao.fields.STATUS_DATE.ToString) = True Then
            rdp_date.SelectedDate = Date.Now.Date
        Else
            rdp_date.SelectedDate = dao.fields.STATUS_DATE.Value.Date

        End If


    End Sub

    Private Sub set_status()
        'Dim dao As New DAO.TB_DRUG_SCHEDULE
        'Dim dao_status As New DAO.TB_MAS_STATUS
        'Dim status_id As String = String.Empty

        'dao.GetDataby_SCHEDULE_ID(_IDA)
        'status_id = dao.fields.STATUS_ID
        'If dao.fields.PROCESS_ID = "21101" Or dao.fields.PROCESS_ID = "22101" Or dao.fields.PROCESS_ID = "23101" Or dao.fields.PROCESS_ID = "24101" Or dao.fields.PROCESS_ID = "25101" Then
        '    dao_status.GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID("1", "1")

        'Else



        '    If status_id = "3" Then
        '        dao_status.GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID("1", "1")
        '    ElseIf status_id = "4" Then
        '        dao_status.GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID("1", "1")
        '    ElseIf status_id = "6" Then
        '        dao_status.GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID("1", "1")
        '    ElseIf status_id = "10" Then
        '        dao_status.GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID("1", "1")
        '    ElseIf status_id = "11" Then
        '        dao_status.GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID("1", "1")
        '    ElseIf status_id = "12" Then
        '        dao_status.GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID("1", "1")

        '    End If
        'End If

        'ddl_status.DataSource = dao_status.datas
        'ddl_status.DataTextField = "STATUS_NAME"
        'ddl_status.DataValueField = "STATUS_ID"
        'ddl_status.DataBind()


        Dim dao As New DAO_BOOKING.TB_MAS_STATUS
        dao.GetData_by_DEPARTMENT_TYPE_ID_ORDER_SEQ_ACTIVE("1")
        ddl_status.DataTextField = "STATUS_NAME"
        ddl_status.DataValueField = "STATUS_ID"
        ddl_status.DataSource = dao.datas
        ddl_status.DataBind()

    End Sub
    Private Sub update_data()
        Dim dao As New DAO_BOOKING.TB_DRUG_SCHEDULE
        dao.GetDataby_SCHEDULE_ID(_IDA)
        dao.fields.STATUS_ID = ddl_status.SelectedValue
        dao.fields.STATUS_DATE = rdp_date.SelectedDate 'Date.Now()
        dao.fields.STATUS_LAST_MODIFY_DATE = Date.Now()
        dao.fields.STATUS_REMARK = txt_remark.Text

        dao.update()

        ' -------------------log การเปลี่ยนสถานะ------------------------
        Dim dao_LOG_UPDATE_STATUS As New DAO_BOOKING.TB_LOG_UPDATE_STATUS
        dao_LOG_UPDATE_STATUS.fields.FK_IDA = dao.fields.SCHEDULE_ID
        dao_LOG_UPDATE_STATUS.fields.SYSTEM_ID = 1
        dao_LOG_UPDATE_STATUS.fields.STATUS_ID = ddl_status.SelectedValue
        dao_LOG_UPDATE_STATUS.fields.STATUS_UPDATE_STAFF_IDENTIFY = _CLS.CITIZEN_ID
        dao_LOG_UPDATE_STATUS.fields.STATUS_UPDATE_DATE = Date.Now()
        dao_LOG_UPDATE_STATUS.insert()
        '--------------------------------------------

        'ไฟล์แนบ
        Dim dao_ATTACH As New DAO_BOOKING.TB_FILE_ATTACH
        Dim FK_IDA As String = String.Empty
        FK_IDA = dao.fields.SCHEDULE_ID.ToString()
        If FileUpload1.HasFile = True Then

            Dim H_TYPE As String = "1"
            Dim extensionname As String = GetExtension(FileUpload1.FileName).ToLower()
            FileUpload1.SaveAs(_PATH_FILE_DRUG & "/upload/" & FK_IDA & "_" & H_TYPE & "." & extensionname)

            Dim dao_file As New DAO_BOOKING.TB_FILE_ATTACH
            dao_file.fields.NAME_FAKE = FK_IDA & "_" & H_TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = FileUpload1.FileName
            dao_file.fields.CREATE_DATE = Date.Now
            dao_file.fields.Description = TextBox1.Text
            dao_file.fields.EXTENSION = extensionname
            dao_file.fields.PATH = "upload"
            dao_file.fields.UPDATE_DATE = Date.Now
            dao_file.fields.TYPE = H_TYPE
            dao_file.fields.FK_IDA = FK_IDA
            dao_file.insert()
        End If
        If FileUpload2.HasFile = True Then
            Dim H_TYPE As String = "2"
            Dim extensionname As String = GetExtension(FileUpload1.FileName).ToLower()
            FileUpload1.SaveAs("D:/path/booking" & "/upload/" & FK_IDA & "_" & H_TYPE & "." & extensionname)

            Dim dao_file As New DAO_BOOKING.TB_FILE_ATTACH
            dao_file.fields.NAME_FAKE = FK_IDA & "_" & H_TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = FileUpload1.FileName
            dao_file.fields.CREATE_DATE = Date.Now
            dao_file.fields.Description = TextBox2.Text
            dao_file.fields.EXTENSION = extensionname
            dao_file.fields.PATH = "upload"
            dao_file.fields.UPDATE_DATE = Date.Now
            dao_file.fields.TYPE = H_TYPE
            dao_file.fields.FK_IDA = FK_IDA
            dao_file.insert()
        End If
        If FileUpload3.HasFile = True Then
            Dim H_TYPE As String = "3"
            Dim extensionname As String = GetExtension(FileUpload1.FileName).ToLower()
            FileUpload1.SaveAs("D:/path/booking" & "/upload/" & FK_IDA & "_" & H_TYPE & "." & extensionname)

            Dim dao_file As New DAO_BOOKING.TB_FILE_ATTACH
            dao_file.fields.NAME_FAKE = FK_IDA & "_" & H_TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = FileUpload1.FileName
            dao_file.fields.CREATE_DATE = Date.Now
            dao_file.fields.Description = TextBox3.Text
            dao_file.fields.EXTENSION = extensionname
            dao_file.fields.PATH = "upload"
            dao_file.fields.UPDATE_DATE = Date.Now
            dao_file.fields.TYPE = H_TYPE
            dao_file.fields.FK_IDA = FK_IDA
            dao_file.insert()
        End If

        alert_close_popup("ลงสถานะเรียบร้อยแล้ว")
        'Response.Redirect("FRM_STAFF_VIEW_BOOKING.aspx")
    End Sub
    Protected Sub Btn_confirm_Click(sender As Object, e As EventArgs) Handles Btn_confirm.Click
        'Dim dao As New DAO.TB_DRUG_SCHEDULE
        'dao.GetDataby_SCHEDULE_ID(_IDA)

        'If dao.fields.STATUS_ID = 3 And ddl_status.SelectedItem.Value = 6 Then
        '    dao.fields.STATUS_ID = 11
        'ElseIf dao.fields.STATUS_ID = 10 And ddl_status.SelectedItem.Value = 6 Then
        '    dao.fields.STATUS_ID = 11
        'ElseIf ddl_status.SelectedItem.Value = 6 Then
        '    dao.fields.STATUS_ID = 11
        'Else
        '    dao.fields.STATUS_ID = ddl_status.SelectedItem.Value
        'End If

        'dao.fields.STATUS_REMARK = txt_remark.Text
        'dao.update()

        'If ddl_status.SelectedItem.Value = "4" Then

        '    Dim dao_insert As New DAO.TB_DRUG_SCHEDULE
        '    dao_insert.fields = dao.fields
        '    dao_insert.fields.STATUS_ID = "10"
        '    dao_insert.fields.BOOKING_DATE = Date.Now
        '    dao_insert.insert()



        'End If
        update_data()
        alert_close_popup("ลงสถานะเรียบร้อยแล้ว")
    End Sub

#Region "javascript"
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub alert_close_popup(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub close_popup()
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert_window_open_self(ByVal text As String, ByVal URL As String)
        Response.Write("<script type='text/javascript'>alert('" & text & "');window.open('" & URL & "','_self');</script> ")
    End Sub
    Private Sub window_open_self(ByVal URL As String)
        Response.Write("<script type='text/javascript'>window.open('" & URL & "','_self');</script> ")
    End Sub

#End Region



End Class