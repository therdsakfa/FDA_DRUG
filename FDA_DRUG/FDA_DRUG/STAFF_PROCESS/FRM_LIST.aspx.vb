Public Class WebForm6
    Inherits System.Web.UI.Page

    Private _template As String
    Private _ID As String
    'Private _System_ID As String
    'Private _pvcode As String
    'Private _STAFF_TYPE As String
    Private _CLS As New CLS_SESSION


    Private Sub RunQuery()
        If Session("CLS") Is Nothing Then
        Else
            _CLS = Session("CLS")

        End If
        _template = Request("template").ToString()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()

        If Not IsPostBack Then
            load_GV()
        End If
        If _CLS.STAFFTYPE = 1 Then
            Label1.Text = " เจ้าหน้าที่"
        ElseIf _CLS.STAFFTYPE = 2 Then
            Label1.Text = " นักวิชาการ"
        ElseIf _CLS.STAFFTYPE = 3 Then
            Label1.Text = "หัวหน้ากลุ่ม pre"
        ElseIf _CLS.STAFFTYPE = 4 Then
            Label1.Text = "หัวหน้ากลุ่มงานผลิตภัณฑ์"
        End If
    End Sub
    Sub load_GV()
        Dim bao As New BAO.ClsDBSqlCommand
        If _template = "1" Then
            Dim type As Integer = _CLS.STAFFTYPE

            If type = 3 Then
                ' bao.SP_FOOD_STAFF_ALL_BOSS(Integer.Parse(_CLS.PVCODE), 0, 0, _CLS.CITIZEN_ID)'test
            ElseIf type = 4 Then
                '  bao.SP_FOOD_STAFF_ALL_BOSS(Integer.Parse(_CLS.PVCODE), 0, 0, _CLS.CITIZEN_ID)'test

            Else
                ' Dim dao_jobc As New DAO_JOB.TB_S_SCHEDULE'test
                ' dao_jobc.GetDataby_rcvdate(_CLS.STAFFTYPE) 'test


                '  Dim person As Integer = dao_jobc.Details.Count 'test
                '  Dim dao_job As New DAO_JOB.TB_S_SCHEDULE 'test


                'dao_job.GetDataby_CITIZEN_ID_POSITION(_CLS.CITIZEN_ID, _CLS.STAFFTYPE) 'test
                ' If dao_job.fields.IDA <> 0 Then 'test
                If type = 1 Then ' 1 คือธุรการ
                    ' bao.SP_FOOD_STAFF_ALL(Integer.Parse(_CLS.PVCODE), person, dao_job.fields.Seq - 1, _CLS.CITIZEN_ID)'test

                    '  @staffmax as integer,@staffseq as integer,@CTZNO as nvarchar(255)
                ElseIf type = 2 Then ' 2 คือนักวิชาการ
                    ' bao.SP_FOOD_STAFF_ALL_ADMIN(Integer.Parse(_CLS.PVCODE), person, dao_job.fields.Seq - 1, _CLS.CITIZEN_ID)'test
                ElseIf type = 3 Then

                End If
                ' Else 'test
                If type = 1 Then ' 1 คือธุรการ
                    'bao.SP_FOOD_STAFF_ALL2(Integer.Parse(_CLS.PVCODE), 0, 0, _CLS.CITIZEN_ID)'test
                Else
                    'bao.SP_FOOD_STAFF_ALL_ADMIN2(Integer.Parse(_CLS.PVCODE), 0, 0, _CLS.CITIZEN_ID)'test
                End If

            End If
        End If





        'ElseIf _template = "2" Then'test
        '  bao.SP_FOOD_STAFF_FALCN(Integer.Parse(_CLS.PVCODE))
        ' ElseIf _template = "3" Then 'test
        '   bao.SP_FOOD_STAFF_FREG(Integer.Parse(_CLS.PVCODE))
        ' ElseIf _template = "4" Then 'test
        '    bao.SP_FOOD_STAFF_CER(Integer.Parse(_CLS.PVCODE))
        ' End If 'test
        '   bao.dt = Filter_Job(bao.dt)
        bao.dt = Filter_cnsdcd(bao.dt)
        gv.DataSource = bao.dt
        gv.DataBind()


    End Sub

    'Private Function Filter_Job(ByVal dt As DataTable) As DataTable
    '    ' 1 ทำการตรวจสอบจำนวนงานทั้งหมด
    '    Dim dao_jobc As New DAO_JOB.TB_S_SCHEDULE
    '    dao_jobc.GetDataby_rcvdate(_CLS.STAFFTYPE)
    '    Dim person As Integer = dao_jobc.Details.Count

    '    Dim dao_job As New DAO_JOB.TB_S_SCHEDULE
    '    dao_job.GetDataby_CITIZEN_ID_POSITION(_CLS.CITIZEN_ID, _CLS.STAFFTYPE)
    '    If dao_job.fields.IDA = 0 Then

    '    Else
    '        Dim clsds As New ClassDataset
    '        dt = clsds.DatatableWhere(dt, "number1 % " & person & " = " & dao_job.fields.Seq - 1)

    '    End If
    '    Return dt
    'End Function


    Private Function Filter_cnsdcd(ByVal dt As DataTable) As DataTable
        Dim clsds As New ClassDataset
        If _CLS.STAFFTYPE = 1 Then
            ' dt = clsds.DatatableWhere(dt, "cnsdcd in (3)")
        ElseIf _CLS.STAFFTYPE = 2 Then
            'dt = clsds.DatatableWhere(dt, "cnsdcd in (3,4,5)")'test
        End If
        Return dt
    End Function

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV()
    End Sub


    Protected Sub gv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        load_GV()
    End Sub

    Private Sub gv_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)

        Dim str_ID As String = gv.Rows(int_index).Cells(7).Text
        Dim TR_ID As String = gv.Rows(int_index).Cells(4).Text
        Dim PROCESS_NAME As String = gv.Rows(int_index).Cells(5).Text
        If e.CommandName = "lcn" Then
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", "Popups('" & str_ID & "','" & TR_ID & "','" & PROCESS_NAME & "');", True)
        End If
    End Sub
End Class