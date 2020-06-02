Imports Microsoft.Reporting.WebForms

Public Class FRM_REPORT_TABEAN
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
            'RunReport()
            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_REPORT_RDLC.aspx?IDA=" & Request.QueryString("IDA") & "&rpt=2&NEWCODE=" & Request.QueryString("NEWCODE") & "&STATUS_ID=" & Request.QueryString("STATUS_ID") & "' ></iframe>"
        End If
    End Sub
    'Sub RunReport()
    '    Dim dt_drug_general As New DataTable
    '    Dim dt_formula As New DataTable
    '    Dim dt_frgn As New DataTable
    '    Dim bao_master_2 As New BAO.ClsDBSqlcommand
    '    Dim bao_show As New BAO_SHOW
    '    Dim dt_drug_recipe As New DataTable
    '    Dim dt_animal As New DataTable
    '    Dim dt_tp_stock As New DataTable
    '    Dim dt_edit_history As New DataTable
    '    Dim dt_print As New DataTable
    '    dt_print.Columns.Add("thanm")
    '    dt_print.Columns.Add("printdate")
    '    Dim dr As DataRow = dt_print.NewRow()
    '    dr("thanm") = set_name_company(_CLS.CITIZEN_ID)
    '    dr("printdate") = Date.Now
    '    dt_print.Rows.Add(dr)
    '    'printdate
    '    If Request.QueryString("STATUS_ID") = "8" Then
    '        Dim newcode As String = Request.QueryString("NEWCODE")
    '        Dim IDA As Integer = 0
    '        Try
    '            Dim dao_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
    '            dao_xml.GetDataby_u1(newcode)
    '            IDA = dao_xml.fields.IDA_drrgt
    '        Catch ex As Exception

    '        End Try
    '        'dt_drug_general = bao_master_2.SP_drug_general(Request.QueryString("IDA")) 'SP_drug_general_sai
    '        'dt_formula = bao_master_2.SP_drug_formula_rg(Request.QueryString("IDA")) 'SP_drug_formula_rg_by_Newcode
    '        'dt_frgn = bao_show.SP_DRRGT_PRODUCER_ALL_BY_FK_IDA(Request.QueryString("IDA")) 'SP_DRRGT_PRODUCER_ALL_BY_NEWCODE
    '        'dt_drug_recipe = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA")) 'SP_DRRGT_ATC_DETAIL_BY_Newcode
    '        'dt_animal = bao_show.SP_dramldrg_BY_FK_IDA(Request.QueryString("IDA")) 'SP_dramldrg_BY_newcode
    '        'dt_tp_stock = bao_show.SP_DRRGT_KEEP_DRUG_BY_FK_IDA(Request.QueryString("IDA")) 'SP_DRRGT_KEEP_DRUG_BY_newcode
    '        'dt_edit_history = bao_show.SP_DRRGT_EDIT_REQUEST_HISTORY(Request.QueryString("IDA"))
    '        dt_drug_general = bao_master_2.SP_drug_general_sai(Request.QueryString("IDA")) '
    '        dt_formula = bao_master_2.SP_drug_formula_rg_by_Newcode(Request.QueryString("NEWCODE")) '
    '        dt_frgn = bao_show.SP_DRRGT_PRODUCER_ALL_BY_NEWCODE(Request.QueryString("NEWCODE")) '
    '        dt_drug_recipe = bao_show.SP_DRRGT_ATC_DETAIL_BY_Newcode(Request.QueryString("NEWCODE")) '
    '        dt_animal = bao_show.SP_dramldrg_BY_newcode(Request.QueryString("NEWCODE")) '
    '        dt_tp_stock = bao_show.SP_DRRGT_KEEP_DRUG_BY_newcode(Request.QueryString("NEWCODE")) '
    '        dt_edit_history = bao_show.SP_DRRGT_EDIT_REQUEST_HISTORY(Request.QueryString("IDA"))
    '    Else
    '        dt_drug_general = bao_master_2.SP_drug_general_rq(Request.QueryString("IDA"))
    '        dt_formula = bao_master_2.SP_drug_formula_rq(Request.QueryString("IDA"))
    '        dt_frgn = bao_show.SP_DRRQT_PRODUCER_ALL_BY_FK_IDA(Request.QueryString("IDA"))
    '        dt_drug_recipe = bao_show.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
    '        dt_animal = bao_show.SP_drramldrg_BY_FK_IDA(Request.QueryString("IDA"))
    '        dt_tp_stock = bao_show.SP_DRRQT_KEEP_DRUG_BY_FK_IDA(Request.QueryString("IDA"))
    '    End If

    '    'SP_DRRGT_ATC_DETAIL_BY_FK_IDA
    '    Dim util As New cls_utility.Report_Utility
    '    util.report = ReportViewer1
    '    util.configWidthHeight()


    '    'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "rp_drug_general", dt_drug_general)
    '    'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "'rp_drug", dt_drug_general)
    '    ReportViewer1.LocalReport.ReportPath = util.root & "TABEAN_YA_STAFF\REPORT\rp_drug.rdlc"
    '    ReportViewer1.LocalReport.EnableExternalImages = True
    '    ReportViewer1.LocalReport.DataSources.Clear()
    '    'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
    '    Dim rds As New ReportDataSource("rp_drug_general", dt_drug_general)
    '    Dim rds2 As New ReportDataSource("rp_drug_formula", dt_formula)
    '    Dim rds3 As New ReportDataSource("rp_drug_recipe_group", dt_drug_recipe)
    '    Dim rds4 As New ReportDataSource("rp_drug_stowagr", dt_tp_stock)
    '    Dim rds5 As New ReportDataSource("rp_drug_animal", dt_animal)
    '    Dim rds6 As New ReportDataSource("rp_drug_frgn", dt_frgn)
    '    Dim rds7 As New ReportDataSource("rp_drug_edit", dt_edit_history)
    '    Dim rds8 As New ReportDataSource("rp_print_nm", dt_print)

    '    ReportViewer1.LocalReport.DataSources.Add(rds)
    '    ReportViewer1.LocalReport.DataSources.Add(rds2)
    '    ReportViewer1.LocalReport.DataSources.Add(rds3)
    '    ReportViewer1.LocalReport.DataSources.Add(rds4)
    '    ReportViewer1.LocalReport.DataSources.Add(rds5)
    '    ReportViewer1.LocalReport.DataSources.Add(rds6)
    '    ReportViewer1.LocalReport.DataSources.Add(rds7)
    '    ReportViewer1.LocalReport.DataSources.Add(rds8)
    '    ReportViewer1.LocalReport.Refresh()
    '    ReportViewer1.DataBind()
    'End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            'dao_syslcnsid.GetDataby_identify(identify)

            'Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            'dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = "-"
        End Try

        Return fullname
    End Function
End Class