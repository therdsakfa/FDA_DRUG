Imports Microsoft.Reporting.WebForms

Public Class POPUP_SHOW_RDLC
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            If Request.QueryString("type") = "1" Then
                runreport()
            ElseIf Request.QueryString("type") = "2" Then
                run_report_chklist()
            End If


        End If
    End Sub
    Sub runreport()

        Dim dt_drug_general As New DataTable
        Dim dt_phr As New DataTable
        Dim dt_frgn As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim bao_show As New BAO_SHOW
        Dim BAO_MAS As New BAO_MASTER
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()


        dt_drug_general = bao_master_2.SP_GET_DATA_DALCN_BY_IDA(Request.QueryString("IDA"))
        dt_phr = BAO_MAS.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("IDA"))
        'dt_frgn = bao_show.SP_REGIST_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))

        'SP_DRRGT_ATC_DETAIL_BY_FK_IDA
        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight(width:=1000)


        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "rp_drug_general", dt_drug_general)
        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "'rp_drug", dt_drug_general)
        ReportViewer1.LocalReport.ReportPath = bao_app._RDLC & "\lcn_data.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
        Dim rds As New ReportDataSource("rp_main_data", dt_drug_general)
        Dim rds2 As New ReportDataSource("rp_phr", dt_phr)
        'Dim rds3 As New ReportDataSource("rp_drug_recipe_group", dt_drug_recipe)


        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)



        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        'ReportViewer1.LocalReport.DataSources.Add(rds9)
        'ReportViewer1.LocalReport.Refresh()
        'ReportViewer1.DataBind()
        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = ReportViewer1.LocalReport.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)
        Dim clsds As New ClassDataset


        Dim filename As String = ""
        If Request.QueryString("STATUS_ID") = "8" Then
            clsds.bynaryToobject2(bao_app._RDLC & Request.QueryString("IDA") & "_1.pdf", renderedbytes)
            filename = Request.QueryString("IDA") & "_1.pdf"
        Else
            clsds.bynaryToobject2(bao_app._RDLC & Request.QueryString("IDA") & "_2.pdf", renderedbytes)
            filename = Request.QueryString("IDA") & "_2.pdf"
        End If

        Dim saveLocation As String = bao_app._RDLC & "/" & filename

        'Response.Redirect(bao_app._RDLC & tr_id & ".pdf")
        load_pdf(saveLocation, filename)

    End Sub
    Sub run_report_chklist()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()

        Dim dt As New DataTable
        dt.Columns.Add("Row")
        dt.Columns.Add("edit_text")
        dt.Columns.Add("count_edit")
        dt.Columns.Add("lcnno_display")
        dt.Columns.Add("RCVNO_T")
        Dim dr As DataRow = dt.NewRow()

        dr("row") = "1"
        dt.Rows.Add(dr)
        ReportViewer1.LocalReport.ReportPath = bao_app._RDLC & "\lcn_extend_list_doc.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim rds As New ReportDataSource("Fields_Report_EDIT", dt)

        ReportViewer1.LocalReport.DataSources.Add(rds)
        'ReportViewer1.LocalReport.Refresh()
        'ReportViewer1.DataBind()

        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = ReportViewer1.LocalReport.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)
        Dim clsds As New ClassDataset


        Dim filename As String = ""
        clsds.bynaryToobject2(bao_app._RDLC & Request.QueryString("IDA") & "_chk.pdf", renderedbytes)
        filename = Request.QueryString("IDA") & "_chk.pdf"

        Dim saveLocation As String = bao_app._RDLC & "/" & filename

        'Response.Redirect(bao_app._RDLC & tr_id & ".pdf")
        load_pdf(saveLocation, filename)
    End Sub
    Private Sub load_pdf(ByVal FilePath As String, ByVal filename As String)
        'Response.ContentType = "Application/pdf"
        Dim last_nm_file As String = ""
        Dim split_nm As String() = filename.Split(".")
        last_nm_file = split_nm(split_nm.Length - 1)
        Response.ContentType = "Content-Disposition"
        If last_nm_file = "txt" Then
            Response.ContentType = "text/plain"
        ElseIf last_nm_file = "jpg" Then
            Response.ContentType = "image/JPEG"
        ElseIf last_nm_file = "png" Then
            Response.ContentType = "image/png"
        ElseIf last_nm_file = "pdf" Then
            Response.ContentType = "application/pdf"
        ElseIf last_nm_file = "doc" Or last_nm_file = "docx" Then
            Response.ContentType = "application/msword"
        End If

        Response.WriteFile(FilePath)
        Response.End()
    End Sub
End Class