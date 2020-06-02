Public Class FRM_STAFF_CHANGE_BSN_PREVIEW
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Bind_ddl_Status_staff()
            load_ddl()
            Dim dao As New DAO_DRUG.TB_lcnrequest
            If Request.QueryString("ida") <> "" Then
                dao.GetDataby_IDA(_IDA)
                get_data(dao)
            End If
        End If
    End Sub
    Private Sub load_ddl()
        Dim dao_req As New DAO_DRUG.TB_lcnrequest
        dao_req.GetDataby_IDA(_IDA)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(dao_req.fields.FK_IDA)
        'Try
        '    lbl_lcnno.Text = dao.fields.LCNNO_DISPLAY
        'Catch ex As Exception

        'End Try
        'Dim dao As New DAO_DRUG.ClsDBdalcn
        'dao.GetDataby_FK_IDA_and_PROCESS_ID_4(dao_req.fields.LOCATION_ADDRESS_IDA, 101, 102, 103, 104)
        'ddl_lcnno.DataSource = dao.datas
        'ddl_lcnno.DataTextField = "LCNNO_DISPLAY"
        'ddl_lcnno.DataValueField = "IDA"
        'ddl_lcnno.DataBind()
        'Dim item As New ListItem
        'item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        'item.Value = "0"
        'ddl_lcnno.Items.Insert(0, item)
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim int_group_ddl As Integer = 0
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        If dao.fields.STATUS_ID <= 2 Then
            int_group_ddl = 1
        ElseIf dao.fields.STATUS_ID > 2 And dao.fields.STATUS_ID < 6 Then
            int_group_ddl = 2
        ElseIf dao.fields.STATUS_ID >= 6 Then
            int_group_ddl = 3
        End If

        bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()




        'Dim dt As New DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        ''bao.SP_MAS_STATUS_STAFF()
        'Dim int_group_ddl As Integer = 3
        'Dim dao_la As New DAO_CPN.TB_LOCATION_ADDRESS
        'dao_la.GetDataby_IDA(_IDA)
        'bao.SP_MAS_STATUS_STAFF_BY_GROUP_DDL(2, int_group_ddl)
        'dt = bao.dt

        'ddl_cnsdcd.DataSource = dt
        'ddl_cnsdcd.DataValueField = "STATUS_ID"
        'ddl_cnsdcd.DataTextField = "STATUS_NAME"
        'ddl_cnsdcd.DataBind()
    End Sub

    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim statusID As Integer = ddl_cnsdcd.SelectedItem.Value

        Dim dao As New DAO_DRUG.TB_lcnrequest
        Dim bao As New BAO.GenNumber
        Dim STATUS_ID As Integer = ddl_cnsdcd.SelectedItem.Value
        Dim RCVNO As String = "0"

        dao.GetDataby_IDA(_IDA)

        Dim PROCESS_ID As Integer = 31
        'Try
        '    PROCESS_ID = dao.fields.PROCESS_ID
        'Catch ex As Exception

        'End Try

        Dim dao_date As New DAO_DRUG.ClsDBSTATUS_DATE
        dao_date.fields.FK_IDA = _IDA
        Try
            dao_date.fields.STATUS_DATE = Date.Now 'CDate(txt_app_date.Text)
        Catch ex As Exception

        End Try

        dao_date.fields.STATUS_GROUP = 2 'ใบอนุญาต ขย ต่างๆ
        dao_date.fields.STATUS_ID = ddl_cnsdcd.SelectedValue
        dao_date.fields.DATE_NOW = Date.Now
        dao_date.fields.PROCESS_ID = "1001022"
        dao_date.insert()


        If STATUS_ID = 3 Then
            'dao.fields.STATUS_ID = STATUS_ID
            'RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            'dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), RCVNO)


            'dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_MINI(con_year(Date.Now.Year()), RCVNO)
            'Try
            '    dao.fields.rcvdate = Date.Now 'CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try
            'dao.fields.RCVDATE_DISPLAY = Date.Now.ToShortDateString()
            'dao.update()
            '("POPUP_STAFF_EDIT_LOCATION_RECEIVE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & 31)
            '-----------------ลิ้งไปหน้าคีย์มือ----------
            Response.Redirect("POPUP_STAFF_EDIT_LOCATION_RECEIVE.aspx?IDA=" & _IDA & "&process=" & PROCESS_ID)
            '--------------------------------
            'alert("ดำเนินการรับคำขอเรียบร้อยแล้ว เลขรับ คือ " & dao.fields.rcvno)
        ElseIf STATUS_ID = 6 Then
            Response.Redirect("POPUP_STAFF_EDIT_LOCATION_CONSIDER.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        ElseIf STATUS_ID = 8 Then
            RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, PROCESS_ID, _IDA)
            Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

            dao.fields.rcvno = RCVNO 'bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year), LCNNO)
            dao.fields.STATUS_ID = STATUS_ID
            Dim chw As String = ""

            dao.fields.RCVNO_DISPLAY = bao.FORMAT_NUMBER_YEAR_FULL(con_year(Date.Now.Year), RCVNO) ' & " (ขย." & GROUP_NUMBER & ")"
            dao.update()
            alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        End If
        'dao.update()
        ''-----------------ลิ้งไปหน้าคีย์มือ----------
        'Response.Redirect("FRM_STAFF_LCN_LCNNO_MANUAL.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        ''--------------------------------
        'alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        ''alert_reload("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        'ElseIf STATUS_ID = 7 Then
        '    Response.Redirect("FRM_STAFF_LCN_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        '    '_TR_ID = Request.QueryString("TR_ID")
        '    '_IDA = Request.QueryString("IDA")
        '    'dao.update()
        '    'alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        'End If



    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")

        Dim dao_n As New DAO_DRUG.ClsDBdalcn
        dao_n.GetDataby_IDA(_IDA)
        Try
            If dao_n.fields.SEND_POST = 1 Then
                '  Label2.Text = "รับด้วยตัวเอง"
            ElseIf dao_n.fields.SEND_POST = 2 Then
                '   Label2.Text = "ส่งไปรษณีย์"
            Else
                '   Label2.Text = "รับด้วยตัวเอง"
            End If
        Catch ex As Exception

        End Try

        Bind_ddl_Status_staff()

        'If statusID = "8" Then
        '    Response.Redirect("POPUP_STAFF_EDIT_LOCATION_RECEIVE.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & 31)

        'Else
        '    Response.Redirect("POPUP_STAFF_EDIT_LOCATION_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & 31)

        'End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_lcnrequest)
        txt_REMARK.Text = dao.fields.REMARK
        txt_WRITE_AT.Text = dao.fields.WRITE_AT
        Try
            txt_WRITE_DATE.Text = CDate(dao.fields.WRITE_DATE)
        Catch ex As Exception

        End Try
        'Try
        '    ddl_lcnno.DropDownSelectData(dao.fields.FK_IDA)
        'Catch ex As Exception

        'End Try


    End Sub
End Class