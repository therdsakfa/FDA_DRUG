Imports System.Globalization
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports Telerik.Web.UI
Public Class UC_recipe_V2
    Inherits System.Web.UI.UserControl
    Private _lcnno As String
    Private _lcntpcd As String
    Private _pvncd As String
    Private _lcnsid As String
    Private _thadrgnm As String
    Private _rgttpcd As String
    Private _rgtno As String
    Private _drgtpcd As String
    Public _Newcode As String
    Dim ThaiCulture As New CultureInfo("th-TH") 'วันที่แบบไทย
    Dim UsaCulture As New CultureInfo("en-US") 'วันที่แบบสากล
    'Private _dsgcd As String
    Dim STATUS_ID As Integer = 0
    Private _CLS As New CLS_SESSION
    Sub RunQuery()

        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            If Request.QueryString("tt") <> "" Then
                btn_atc.Enabled = False
            End If
            'If STATUS_ID = 8 Then
            '    btn_atc.Enabled = False
            'End If
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Sub insert_atc_rgt()
        If STATUS_ID = 8 Then
            'Dim dao_dr As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
            'dao_dr.GetDataby_FKIDA(Request.QueryString("IDA"))
            'Dim max_no As Integer = 0
            'Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            'dao_edt.GET_MAX_NO("DRRGT_ATC_DETAIL", dao_dr.fields.IDA)
            'Try
            '    max_no = dao_edt.fields.COUNT_EDIT
            'Catch ex As Exception

            'End Try


            For Each item As GridDataItem In rg_atc_search.SelectedItems
                Dim old_data As String = ""
                Dim new_data As String = ""
                Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                dao1.GetDataby_FK_DRRQT(Request.QueryString("IDA"))
                Dim dao As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                Try
                    dao.fields.ATC_CODE = item("atc_code").Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ATC_IDA = item("IDA").Text
                Catch ex As Exception

                End Try
                dao.fields.FK_IDA = Request.QueryString("IDA")

                If STATUS_ID = 8 Then

                    Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                    dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))

                    new_data = "เพิ่ม atccd = " & item("atc_code").Text & " , ATC_IDA =" & item("IDA").Text
                    Dim result As String = ""
                    Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                    result = ""
                    If Request.QueryString("e") <> "" Then
                        result = "EDIT RQT"
                    End If
                    Try
                        If Request.QueryString("e") = "" Then
                            ws_drug.Timeout = 8000
                            ' result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)

                            Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                            dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                            Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                            Dim cls_xml_DR As New LGT_IOW_E
                            cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                            Dim str_xml As String = ""
                            Try
                                'Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                                'dao1.GetDataby_IDA(Request.QueryString("IDA"))
                                SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao_rg2.fields.IDENTIFY)

                                ws_drug.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                            Catch ex As Exception

                            End Try
                        End If

                    Catch ex As Exception

                    End Try
                    Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                    KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                        dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

                End If


                'dao.fields.FK_IDA = dao1.fields.IDA
                dao.insert()
            Next


            Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)

            

            RadGrid2.Rebind()


            'Dim filename As String = ""
            'filename = "DRRGT_ATC_DETAIL_" & max_no + 1 & ".xml"
            'Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
            'bao_app.RunAppSettings()
            'Dim path As String = bao_app._PATH_EDIT & filename
            'Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
            'Dim x As New XmlSerializer(dao_dr.fields.GetType)                                                     'ประกาศ
            'x.Serialize(objStreamWriter, dao_dr.fields)
            'objStreamWriter.Close()

            'Dim dao_index As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            'With dao_index.fields
            '    .COUNT_EDIT = max_no + 1
            '    .CREATE_DATE = Date.Now
            '    .FILE_NAME = filename
            '    .FK_DRRGT_IDA = Request.QueryString("IDA")
            '    .FK_IDA = dao_dr.fields.IDA
            '    .TABLE_NAME = "DRRGT_ATC_DETAIL"
            'End With
            'dao_index.insert()
        Else
            For Each item As GridDataItem In rg_atc_search.SelectedItems
                Dim dao As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                Try
                    dao.fields.ATC_CODE = item("atc_code").Text
                Catch ex As Exception

                End Try
                Try
                    dao.fields.ATC_IDA = item("IDA").Text
                Catch ex As Exception

                End Try
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.insert()
            Next
            RadGrid2.Rebind()
        End If
        KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "เพิ่ม ATC", _CLS.CITIZEN_ID)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
        RadGrid2.Rebind()
    End Sub
    'Sub insert_atc_rqt()
    '    Dim dao As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
    '    Try
    '        dao.fields.ATC_CODE = rcb_atc.SelectedValue
    '    Catch ex As Exception

    '    End Try

    '    dao.fields.FK_IDA = Request.QueryString("IDA")
    '    dao.insert()
    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');", True)
    '    RadGrid2.Rebind()
    'End Sub

    Protected Sub btn_atc_Click(sender As Object, e As EventArgs) Handles btn_atc.Click
        'If STATUS_ID = 8 Then
        insert_atc_rgt()
        'Else
        '    insert_atc_rqt()
        'End If
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "del" Then
                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                    'ElseIf STATUS_ID = 8 Then
                    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else
                    If STATUS_ID = 8 Then
                        Dim dao As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
                        dao.GetDataby_IDA(IDA)
                        dao.delete()
                    Else
                        Dim dao As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
                        dao.GetDataby_IDA(IDA)
                        dao.delete()
                    End If

                    RadGrid2.Rebind()
                End If
            End If
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If STATUS_ID = 8 Then
            'Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            'dao1.GetDataby_FK_DRRQT(Request.QueryString("IDA"))
            dt = bao.SP_DRRGT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
        Else
            dt = bao.SP_DRRQT_ATC_DETAIL_BY_FK_IDA(Request.QueryString("IDA"))
        End If

        RadGrid2.DataSource = dt
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        ' If txt_search.Text <> "" And txt_atc_name.Text <> "" Then
        dt = bao.SP_ATC_DRUG_SEARCH_V2(txt_search.Text, txt_atc_name.Text)
        'End If
        rg_atc_search.DataSource = dt
        rg_atc_search.Rebind()
    End Sub


End Class