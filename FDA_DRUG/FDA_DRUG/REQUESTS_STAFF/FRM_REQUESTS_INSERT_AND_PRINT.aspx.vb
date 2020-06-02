Imports Microsoft.Reporting.WebForms

Public Class FRM_REQUESTS_INSERT_AND_PRINT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            print_max()
            bind_ddl_WORK_GROUP()
            txt_enddate.Text = Date.Now.ToShortDateString
            txt_startdate.Text = Date.Now.ToShortDateString
        End If
    End Sub
    Sub print_max()
        Dim _year As Integer = 0
        _year = Year(Date.Now)
        If _year < 2500 Then
            _year += 543
        End If
        Dim dao_count As New DAO_DRUG.TB_CONSIDER_REQ_PRINT_HISTORY
        dao_count.GetDataby_COUNT_MAX(_year)
        Try
            txt_print_count.Text = dao_count.fields.PRINT_COUNT + 1
        Catch ex As Exception
            txt_print_count.Text = 1
        End Try
    End Sub
    Private Sub bind_ddl_WORK_GROUP()
        Dim dao As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
        dao.GetDataAll()
        ddl_work_group.DataSource = dao.datas
        ddl_work_group.DataTextField = "WORK_GROUP"
        ddl_work_group.DataValueField = "IDA"
        ddl_work_group.DataBind()
        'Dim dao As New DAO_DRUG.TB_MAS_WORK_GROUP
        'dao.GetDataAll()
        'ddl_WORK_GROUP.DataSource = dao.datas
        'ddl_WORK_GROUP.DataTextField = "WORK_GROUP_NAME"
        'ddl_WORK_GROUP.DataValueField = "WORK_GROUP_ID"
        'ddl_WORK_GROUP.DataBind()
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_CONSIDER_REQ_PRINT_HISTORY
        Dim _year As Integer = 0
        _year = Year(Date.Now)
        If _year < 2500 Then
            _year += 543
        End If

        Dim dao_count As New DAO_DRUG.TB_CONSIDER_REQ_PRINT_HISTORY
        dao_count.GetDataby_COUNT_MAX(_year)
        With dao.fields
            Try
                .ENDDATE = CDate(txt_enddate.Text)
            Catch ex As Exception

            End Try
            Try
                .PRINT_COUNT = txt_print_count.Text 'dao_count.fields.PRINT_COUNT + 1
            Catch ex As Exception
                .PRINT_COUNT = 1
            End Try
            .GROUP_NO = ddl_work_group.SelectedValue
            .PRINT_DATE = Date.Now
            .SENT_DOCUMENT_NAME = txt_SENT_DOCUMENT_NAME.Text
            Try
                .STARTDATE = CDate(txt_startdate.Text)
            Catch ex As Exception

            End Try
            If ddl_work_group.SelectedValue = 7 Then
                Try
                    .SUB_GROUP_NO = ddl_advertise.SelectedValue
                Catch ex As Exception

                End Try
            Else
                .SUB_GROUP_NO = 0
            End If
            
            .YEAR_PRINT = _year
            dao.insert()

            Dim dt As New DataTable
            'SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT
           

            Dim dao_his As New DAO_DRUG.TB_CONSIDER_REQ_PRINT_HISTORY
            dao_his.GetDataby_IDA(dao.fields.IDA)
           

            Dim rows_count As Integer = 0
            Dim bsn_count As Integer = 0
            Try
                rows_count = dt.Rows.Count
            Catch ex As Exception

            End Try

            Dim bao As New BAO.ClsDBSqlcommand
            If ddl_work_group.SelectedValue <> 7 Then
                dt = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO)

            Else
                If ddl_advertise.SelectedValue = 1 Then
                    dt = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 402)
                Else
                    dt = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 401)
                End If
            End If
            dt.Columns.Add("rows_count")
            dt.Columns.Add("bsn_count")
            dt.Columns.Add("SENT_DOCUMENT_NAME")
            dt.Columns.Add("PRINT_COUNT")
            dt.Columns.Add("PRINT_DATE")


            Dim bao2 As New BAO.ClsDBSqlcommand
            Dim dt2 As New DataTable
            'dt2 = bao2.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP(CDate(txt_startdate.Text), CDate(txt_enddate.Text), ddl_work_group.SelectedValue)

            If ddl_work_group.SelectedValue <> 7 Then
                dt2 = bao2.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO)

            Else
                If ddl_advertise.SelectedValue = 1 Then
                    dt2 = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 402)
                Else
                    dt2 = bao.SP_DATA_REPORT_SENT_DOCUMENT_BY_DATE_PRINT_GROUP_NEW(CDate(dao_his.fields.STARTDATE), CDate(dao_his.fields.ENDDATE), dao_his.fields.GROUP_NO, 401)
                End If
            End If


            Try
                bsn_count = dt2.Rows.Count
            Catch ex As Exception

            End Try

            For Each dr As DataRow In dt.Rows
                dr("rows_count") = rows_count
                dr("bsn_count") = bsn_count
                dr("SENT_DOCUMENT_NAME") = dao_his.fields.SENT_DOCUMENT_NAME
                Try
                    dr("PRINT_COUNT") = dao_his.fields.PRINT_COUNT & "/" & Right(dao_his.fields.YEAR_PRINT, 2)
                Catch ex As Exception

                End Try
                dr("PRINT_DATE") = dao_his.fields.PRINT_DATE
            Next
            runpdf(dt, "RDLC\report_request.rdlc", "Fields_Report_request")
        End With
    End Sub

    Private Sub runpdf(ByVal dt1 As DataTable, ByVal path As String, ByVal report_datasource As String)
        Dim rsw As New LocalReport
        rsw.ReportPath = path
        Dim reportdatasource As New ReportDataSource

        reportdatasource.Value = dt1
        reportdatasource.Name = report_datasource
        rsw.DataSources.Add(reportdatasource)


        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = rsw.Render(ReportType, Nothing, Nothing, Nothing, FileNameExtension, streams, warnings)

        'ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        Response.AddHeader("Accept-Ranges", "bytes")
        Response.AddHeader("Accept-Header", "2222")
        Response.AddHeader("Cache-Control", "public")
        Response.AddHeader("Cache-Control", "must-revalidate")
        Response.AddHeader("Pragma", "public")



        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline; filename=""" + "Test.pdf" + """")
        Response.AddHeader("expires", "0")


        Response.BinaryWrite(renderedbytes)
        Response.Flush()
    End Sub

    Private Sub ddl_work_group_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_work_group.SelectedIndexChanged
        If ddl_work_group.SelectedValue = 7 Then
            Label1.Style.Add("display", "block")
            ddl_advertise.Style.Add("display", "block")
        Else
            Label1.Style.Add("display", "none")
            ddl_advertise.Style.Add("display", "none")
        End If
    End Sub
End Class