Imports Microsoft.Reporting.WebForms
Public Class FRM_REPORT_REGIST
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("process")
        Catch ex As Exception

        End Try
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _YEARS = con_year(Year(Date.Now))
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'RunReport()
            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_REPORT_RDLC.aspx?IDA=" & _IDA & "&rpt=1' ></iframe>"
            Try
                Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
                dao.GetDataby_IDA(_IDA)
                'If dao.fields.STATUS_ID = 1 Then
                '    If Trim(dao.fields.DRUG_EQ_TO) = "" Then
                '        ' reload_pdf(_CLS.PATH_XML, _CLS.PATH_PDF_TEMPLATE, _CLS.PDFNAME)
                '        dao.fields.DRUG_EQ_TO = _CLS.FILENAME_XML
                '        dao.update()
                '    End If

                'End If
            Catch ex As Exception

            End Try
            show_btn(_IDA)
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal IDA As String)
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(IDA)
        If dao.fields.STATUS_ID <> 1 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Dim statusID As Integer = 8 'ddl_cnsdcd.SelectedItem.Value
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = statusID

        Dim dao_pc As New DAO_DRUG.TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        dao_pc.GetDataby_FK_IDA(_IDA)


        If statusID = "7" Then
            dao.fields.STATUS_ID = statusID
            Try
                dao.fields.RCVDATE = Date.Now 'CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        ElseIf statusID = "8" Then

            If Request.QueryString("tt") <> "" Then
                Dim i As Integer = 0
                Dim dao_tt As New DAO_DRUG.TB_DRUG_REGISTRATION_DETAIL_CA
                i = dao_tt.Count_IOWA_NULL_Databy_FK_IDA(_IDA)


                If i > 0 Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ เนื่องจากบันทึกข้อมูลไม่ครบถ้วน');</script> ")
                Else
                    Dim bao As New BAO.GenNumber
                    Dim rcvno As String = bao.GEN_NO_06(con_year(Date.Now.Year()), _CLS.PVCODE, "130001", _CLS.LCNNO, "", "", _IDA, "")
                    Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

                    Try
                        dao.fields.RCVDATE = Date.Now 'CDate(txt_app_date.Text)
                    Catch ex As Exception

                    End Try
                    dao.fields.RCVNO = rcvno
                    dao.fields.RCVNO_DISPLAY = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                    dao.fields.REGIS_NO = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                    dao.update()
                    alert("ยืนยันข้อมูลแล้ว คุณได้เลขรับที่ " & "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5))
                End If


            Else
                Dim bao As New BAO.GenNumber
                Dim rcvno As String = bao.GEN_NO_06(con_year(Date.Now.Year()), _CLS.PVCODE, "130001", _CLS.LCNNO, "", "", _IDA, "")
                Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

                'If dao_pc.fields.FK_IDA Is Nothing Then
                '    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณากรอกขนาดบรรจุ');</script> ")
                If dao.fields.UNIT_NORMAL = "" Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณาเลือกหน่วยนับตามรูปของแบบยา');</script> ")
                ElseIf dao.fields.DRUG_GROUP = "" Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณาเลือกหมวดยา');</script> ")
                ElseIf dao.fields.GROUP_TYPE = 0 Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณาเลือกประเภทของยา');</script> ")
                ElseIf dao.fields.FK_DOSAGE_FORM = "" Then
                    Response.Write("<script type='text/javascript'>window.parent.alert('ไม่สามารถยื่นคำขอได้ กรุณาเลือกรูปแบบของยา');</script> ")
                Else
                    Try
                        dao.fields.RCVDATE = Date.Now 'CDate(txt_app_date.Text)
                    Catch ex As Exception

                    End Try
                    dao.fields.RCVNO = rcvno
                    dao.fields.RCVNO_DISPLAY = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                    dao.fields.REGIS_NO = "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5)
                    dao.update()
                    alert("ยืนยันข้อมูลแล้ว คุณได้เลขรับที่ " & "DL-" & Left(rcvno, 2) & "-" & Right(rcvno, 5))
                End If
            End If
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(Integer.Parse(_IDA))
        dao.fields.STATUS_ID = 7
        dao.update()

        alert("ยกเลิกข้อมุลเรียบร้อยแล้ว")
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

    '    dt_drug_general = bao_master_2.SP_drug_general_REGIST(Request.QueryString("IDA"))
    '    dt_formula = bao_master_2.SP_drug_formula_REGIST(Request.QueryString("IDA"))
    '    dt_frgn = bao_show.SP_REGIST_PRODUCER_BY_FK_IDA(Request.QueryString("IDA"))
    '    dt_drug_recipe = bao_show.SP_REGIST_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
    '    dt_animal = bao_show.SP_REGIST_ANIMAL_BY_FK_IDA(Request.QueryString("IDA"))
    '    dt_tp_stock = bao_show.SP_REGIST_KEEP_DRUG_BY_FK_IDA(Request.QueryString("IDA"))

    '    'SP_DRRGT_ATC_DETAIL_BY_FK_IDA
    '    Dim util As New cls_utility.Report_Utility
    '    util.report = ReportViewer1
    '    util.configWidthHeight(width:=1000)


    '    'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "rp_drug_general", dt_drug_general)
    '    'util.ShowReport(ReportViewer1, util.root & "D:/rp_drug.rdlc", "'rp_drug", dt_drug_general)
    '    ReportViewer1.LocalReport.ReportPath = util.root & "TABEAN_YA_STAFF\REPORT\rp_drug_regist.rdlc"
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
    '    '

    '    ReportViewer1.LocalReport.DataSources.Add(rds)
    '    ReportViewer1.LocalReport.DataSources.Add(rds2)
    '    ReportViewer1.LocalReport.DataSources.Add(rds3)
    '    ReportViewer1.LocalReport.DataSources.Add(rds4)
    '    ReportViewer1.LocalReport.DataSources.Add(rds5)
    '    ReportViewer1.LocalReport.DataSources.Add(rds6)
    '    ReportViewer1.LocalReport.DataSources.Add(rds7)
    '    ReportViewer1.LocalReport.Refresh()
    '    ReportViewer1.DataBind()
    'End Sub
End Class