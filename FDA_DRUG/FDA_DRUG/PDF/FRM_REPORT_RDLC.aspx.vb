Imports Microsoft.Reporting.WebForms
Public Class FRM_REPORT_RDLC
    Inherits System.Web.UI.Page
    Private Report_type As String = ""
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            Report_type = Request.QueryString("rpt")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            If Report_type = "1" Then
                runpdf()
            ElseIf Report_type = "2" Then
                Run_Pdf_Tabean()
            End If
        End If
    End Sub

    Sub Run_Pdf_Tabean()
        Dim dt_drug_general As New DataTable
        Dim dt_formula As New DataTable
        Dim dt_frgn As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim bao_show As New BAO_SHOW
        Dim dt_drug_recipe As New DataTable
        Dim dt_animal As New DataTable
        Dim dt_tp_stock As New DataTable
        Dim dt_edit_history As New DataTable
        Dim dt_print As New DataTable
        dt_print.Columns.Add("thanm")
        dt_print.Columns.Add("printdate")
        Dim dr As DataRow = dt_print.NewRow()
        dr("thanm") = set_name_company(_CLS.CITIZEN_ID)
        dr("printdate") = Date.Now
        dt_print.Rows.Add(dr)
        'printdate

        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight(width:=1000)
        Dim tr_id As Integer = 0
        
        If Request.QueryString("STATUS_ID") = "8" Then
            Try
                Dim dao_rgt As New DAO_DRUG.ClsDBdrrgt
                dao_rgt.GetDataby_IDA(Request.QueryString("IDA"))
                tr_id = dao_rgt.fields.TR_ID
            Catch ex As Exception
                Dim dao_rgt As New DAO_DRUG.ClsDBdrrgt
                dao_rgt.GetDataby_IDA(Request.QueryString("IDA"))
                tr_id = dao_rgt.fields.IDA
            End Try
            Dim newcode As String = Request.QueryString("NEWCODE")
            Dim IDA As Integer = 0
            Try
                Dim dao_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                dao_xml.GetDataby_u1(newcode)
                IDA = dao_xml.fields.IDA_drrgt
            Catch ex As Exception

            End Try
            'dt_drug_general = bao_master_2.SP_drug_general(Request.QueryString("IDA")) 'SP_drug_general_sai
            'dt_formula = bao_master_2.SP_drug_formula_rg(Request.QueryString("IDA")) 'SP_drug_formula_rg_by_Newcode
            'dt_frgn = bao_show.SP_DRRGT_PRODUCER_ALL_BY_FK_IDA(Request.QueryString("IDA")) 'SP_DRRGT_PRODUCER_ALL_BY_NEWCODE
            'dt_drug_recipe = bao_show.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA")) 'SP_DRRGT_ATC_DETAIL_BY_Newcode
            'dt_animal = bao_show.SP_dramldrg_BY_FK_IDA(Request.QueryString("IDA")) 'SP_dramldrg_BY_newcode
            'dt_tp_stock = bao_show.SP_DRRGT_KEEP_DRUG_BY_FK_IDA(Request.QueryString("IDA")) 'SP_DRRGT_KEEP_DRUG_BY_newcode
            'dt_edit_history = bao_show.SP_DRRGT_EDIT_REQUEST_HISTORY(Request.QueryString("IDA"))
            dt_drug_general = bao_master_2.SP_drug_general_sai(Request.QueryString("IDA")) '
            dt_formula = bao_master_2.SP_drug_formula_rg_by_Newcode(Request.QueryString("NEWCODE")) '
            dt_frgn = bao_show.SP_DRRGT_PRODUCER_ALL_BY_NEWCODE(Request.QueryString("NEWCODE")) '
            dt_drug_recipe = bao_show.SP_DRRGT_ATC_DETAIL_BY_Newcode(Request.QueryString("NEWCODE")) '
            dt_animal = bao_show.SP_dramldrg_BY_newcode(Request.QueryString("NEWCODE")) '
            dt_tp_stock = bao_show.SP_DRRGT_KEEP_DRUG_BY_newcode(Request.QueryString("NEWCODE")) '
            dt_edit_history = bao_show.SP_DRRGT_EDIT_REQUEST_HISTORY(Request.QueryString("IDA"))
        Else
            Try
                Dim dao_rgt As New DAO_DRUG.ClsDBdrrqt
                dao_rgt.GetDataby_IDA(Request.QueryString("IDA"))
                tr_id = dao_rgt.fields.TR_ID
            Catch ex As Exception
                Dim dao_rgt As New DAO_DRUG.ClsDBdrrqt
                dao_rgt.GetDataby_IDA(Request.QueryString("IDA"))
                tr_id = dao_rgt.fields.IDA
            End Try

            dt_drug_general = bao_master_2.SP_drug_general_rq(Request.QueryString("IDA"))
            dt_formula = bao_master_2.SP_drug_formula_rq(Request.QueryString("IDA"))
            dt_frgn = bao_show.SP_DRRQT_PRODUCER_ALL_BY_FK_IDA(Request.QueryString("IDA"))
            dt_drug_recipe = bao_show.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
            dt_animal = bao_show.SP_drramldrg_BY_FK_IDA(Request.QueryString("IDA"))
            dt_tp_stock = bao_show.SP_DRRQT_KEEP_DRUG_BY_FK_IDA(Request.QueryString("IDA"))
        End If
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        'ReportViewer1.LocalReport.ReportPath = util.root & "TABEAN_YA_STAFF\REPORT\rp_drug.rdlc"
        ReportViewer1.LocalReport.ReportPath = bao_app._RDLC & "\rp_drug.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim rds As New ReportDataSource("rp_drug_general", dt_drug_general)
        Dim rds2 As New ReportDataSource("rp_drug_formula", dt_formula)
        Dim rds3 As New ReportDataSource("rp_drug_recipe_group", dt_drug_recipe)
        Dim rds4 As New ReportDataSource("rp_drug_stowagr", dt_tp_stock)
        Dim rds5 As New ReportDataSource("rp_drug_animal", dt_animal)
        Dim rds6 As New ReportDataSource("rp_drug_frgn", dt_frgn)
        Dim rds7 As New ReportDataSource("rp_drug_edit", dt_edit_history)
        Dim rds8 As New ReportDataSource("rp_print_nm", dt_print)

        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        ReportViewer1.LocalReport.DataSources.Add(rds3)
        ReportViewer1.LocalReport.DataSources.Add(rds4)
        ReportViewer1.LocalReport.DataSources.Add(rds5)
        ReportViewer1.LocalReport.DataSources.Add(rds6)
        ReportViewer1.LocalReport.DataSources.Add(rds7)
        ReportViewer1.LocalReport.DataSources.Add(rds8)
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
            clsds.bynaryToobject2(bao_app._RDLC & tr_id & "_1.pdf", renderedbytes)
            filename = tr_id & "_1.pdf"
        Else
            clsds.bynaryToobject2(bao_app._RDLC & tr_id & "_2.pdf", renderedbytes)
            filename = tr_id & "_2.pdf"
        End If

        Dim saveLocation As String = bao_app._RDLC & "/" & filename

        'Response.Redirect(bao_app._RDLC & tr_id & ".pdf")
        load_pdf(saveLocation, filename)
    End Sub
    Private Sub runpdf()
        Dim dt_drug_general As New DataTable
        Dim dt_formula As New DataTable
        Dim dt_frgn As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim bao_show As New BAO_SHOW
        Dim dt_drug_recipe As New DataTable
        Dim dt_animal As New DataTable
        Dim dt_tp_stock As New DataTable
        Dim dt_edit_history As New DataTable

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()


        dt_drug_general = bao_master_2.SP_drug_general_REGIST(Request.QueryString("IDA"))
        dt_formula = bao_master_2.SP_drug_formula_REGIST(Request.QueryString("IDA"))
        dt_frgn = bao_show.SP_REGIST_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))
        dt_drug_recipe = bao_show.SP_REGIST_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
        dt_animal = bao_show.SP_REGIST_ANIMAL_BY_FK_IDA(Request.QueryString("IDA"))
        dt_tp_stock = bao_show.SP_REGIST_KEEP_DRUG_BY_FK_IDA(Request.QueryString("IDA"))

        'SP_DRRGT_ATC_DETAIL_BY_FK_IDA
        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight(width:=1000)
        Dim tr_id As Integer = 0
        Try
            Dim dao_rgt As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_rgt.GetDataby_IDA(Request.QueryString("IDA"))
            tr_id = dao_rgt.fields.TR_ID
        Catch ex As Exception

        End Try

        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "rp_drug_general", dt_drug_general)
        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "'rp_drug", dt_drug_general)
        ReportViewer1.LocalReport.ReportPath = bao_app._RDLC & "\rp_drug_regist.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
        Dim rds As New ReportDataSource("rp_drug_general", dt_drug_general)
        Dim rds2 As New ReportDataSource("rp_drug_formula", dt_formula)
        Dim rds3 As New ReportDataSource("rp_drug_recipe_group", dt_drug_recipe)
        Dim rds4 As New ReportDataSource("rp_drug_stowagr", dt_tp_stock)
        Dim rds5 As New ReportDataSource("rp_drug_animal", dt_animal)
        Dim rds6 As New ReportDataSource("rp_drug_frgn", dt_frgn)
        Dim rds7 As New ReportDataSource("rp_drug_edit", dt_edit_history)
        '

        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        ReportViewer1.LocalReport.DataSources.Add(rds3)
        ReportViewer1.LocalReport.DataSources.Add(rds4)
        ReportViewer1.LocalReport.DataSources.Add(rds5)
        ReportViewer1.LocalReport.DataSources.Add(rds6)
        ReportViewer1.LocalReport.DataSources.Add(rds7)




        Dim ReportType As String = "PDF"
        Dim FileNameExtension As String = "pdf"

        Dim warnings As Warning() = Nothing
        Dim streams As String() = Nothing
        Dim renderedbytes As Byte() = Nothing
        renderedbytes = ReportViewer1.LocalReport.Render(ReportType, Nothing, Nothing, "UTF-8", FileNameExtension, streams, warnings)

        Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
        renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)
        Dim clsds As New ClassDataset

        clsds.bynaryToobject2(bao_app._RDLC & tr_id & ".pdf", renderedbytes)
        Dim filename As String = tr_id & ".pdf"
        Dim saveLocation As String = bao_app._RDLC & "/" & filename

        'Response.Redirect(bao_app._RDLC & tr_id & ".pdf")
        load_pdf(saveLocation, filename)
        ' Response.Redirect("../PDF/" & tr_id & ".pdf")

        'Response.Redirect("../PDF/" & tr_id & ".pdf")

        ''ต้องให้ Content Type เป็น pdf และกำหนด filename ใน content-disposition ให้มีนามสกุลเป็น pdf เพื่อให้ IE เปิด Pdf Reader ได้ http://forums.asp.net/p/1036628/1436084.aspx
        'Response.AddHeader("Accept-Ranges", "bytes")
        'Response.AddHeader("Accept-Header", "2222")
        'Response.AddHeader("Cache-Control", "public")
        'Response.AddHeader("Cache-Control", "must-revalidate")
        'Response.AddHeader("Pragma", "public")
        ''Response.AddHeader()
        ''Response.AddHeader("Content-Encoding", "UTF-8")

        ''Response.ContentEncoding = System.Text.Encoding.Unicode   'GetEncoding(874)
        ''Response.Charset = "windows-874"
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-disposition", "inline; filename=""" + "Test.pdf" + """")
        'Response.AddHeader("expires", "0")


        'Response.BinaryWrite(renderedbytes)
        'Response.Flush()
    End Sub
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
    Sub RunReport()
        Dim dt_drug_general As New DataTable
        Dim dt_formula As New DataTable
        Dim dt_frgn As New DataTable
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim bao_show As New BAO_SHOW
        Dim dt_drug_recipe As New DataTable
        Dim dt_animal As New DataTable
        Dim dt_tp_stock As New DataTable
        Dim dt_edit_history As New DataTable

        dt_drug_general = bao_master_2.SP_drug_general_REGIST(Request.QueryString("IDA"))
        dt_formula = bao_master_2.SP_drug_formula_REGIST(Request.QueryString("IDA"))
        dt_frgn = bao_show.SP_REGIST_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))
        dt_drug_recipe = bao_show.SP_REGIST_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
        dt_animal = bao_show.SP_REGIST_ANIMAL_BY_FK_IDA(Request.QueryString("IDA"))
        dt_tp_stock = bao_show.SP_REGIST_KEEP_DRUG_BY_FK_IDA(Request.QueryString("IDA"))

        'SP_DRRGT_ATC_DETAIL_BY_FK_IDA
        Dim util As New cls_utility.Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight(width:=1000)


        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "rp_drug_general", dt_drug_general)
        'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "'rp_drug", dt_drug_general)
        ReportViewer1.LocalReport.ReportPath = util.root & "TABEAN_YA_STAFF\REPORT\rp_drug_regist.rdlc"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        'report.LocalReport.DataSources.Add(New Microsoft.Reporting.WebForms.ReportDataSource("Fields_Report_R2_001", getReportData()))
        Dim rds As New ReportDataSource("rp_drug_general", dt_drug_general)
        Dim rds2 As New ReportDataSource("rp_drug_formula", dt_formula)
        Dim rds3 As New ReportDataSource("rp_drug_recipe_group", dt_drug_recipe)
        Dim rds4 As New ReportDataSource("rp_drug_stowagr", dt_tp_stock)
        Dim rds5 As New ReportDataSource("rp_drug_animal", dt_animal)
        Dim rds6 As New ReportDataSource("rp_drug_frgn", dt_frgn)
        Dim rds7 As New ReportDataSource("rp_drug_edit", dt_edit_history)
        '

        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        ReportViewer1.LocalReport.DataSources.Add(rds3)
        ReportViewer1.LocalReport.DataSources.Add(rds4)
        ReportViewer1.LocalReport.DataSources.Add(rds5)
        ReportViewer1.LocalReport.DataSources.Add(rds6)
        ReportViewer1.LocalReport.DataSources.Add(rds7)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.DataBind()
    End Sub
End Class