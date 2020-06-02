Imports System.IO
Imports System.Xml.Serialization

Public Class UC_No_Use
    Inherits System.Web.UI.UserControl
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
            If STATUS_ID = 8 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_NO_USE
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                txt_no_use.Text = dao.fields.NO_USE_DESCRIPTION
            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_NO_USE
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                txt_no_use.Text = dao.fields.NO_USE_DESCRIPTION
            End If
            If Request.QueryString("tt") <> "" Then
                btn_save.Enabled = False
            End If
            'If STATUS_ID = "8" Then
            '    btn_save.Enabled = False
            'End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If STATUS_ID = 8 Then
            Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            dao_re.fields.lmdfdate = Date.Now
            dao_re.update()
            Dim old_data As String = ""
            Dim new_data As String = ""

            Dim i As Integer = 0
            Dim dao_c As New DAO_DRUG.TB_DRRGT_NO_USE
            i = dao_c.CountDataby_FK_IDA(Request.QueryString("IDA"))
            If i = 0 Then
                Dim dao As New DAO_DRUG.TB_DRRGT_NO_USE
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.fields.NO_USE_DESCRIPTION = txt_no_use.Text
                new_data = "เพิ่มข้อห้ามใช้ :" & txt_no_use.Text
                dao.insert()


            Else
                Dim dao As New DAO_DRUG.TB_DRRGT_NO_USE
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                old_data = dao.fields.NO_USE_DESCRIPTION
                new_data = txt_no_use.Text
                dao.fields.NO_USE_DESCRIPTION = txt_no_use.Text
                dao.update()
            End If

            Dim dao_dr As New DAO_DRUG.TB_DRRGT_NO_USE
            dao_dr.GetDataby_FK_IDA(Request.QueryString("IDA"))
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_NO_USE", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try
            'Dim filename As String = ""
            'filename = "DRRGT_NO_USE_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "DRRGT_NO_USE"
            'End With
            'dao_index.insert()

            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)
            If STATUS_ID = 8 Then
               

                Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
                dao_rg2.GetDataby_IDA(Request.QueryString("IDA"))

                Dim result As String = ""
                Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                result = ""
                If Request.QueryString("e") <> "" Then
                    result = "EDIT RQT"
                End If
                Try
                    If Request.QueryString("e") = "" Then
                        ws_drug.Timeout = 8000
                        'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)
                        Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                        dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                        Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                        Dim cls_xml_DR As New LGT_IOW_E
                        cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                        Dim str_xml As String = ""
                        Try
                            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                            dao1.GetDataby_IDA(Request.QueryString("IDA"))
                            SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao1.fields.IDENTIFY)

                            ws_drug.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                        Catch ex As Exception

                        End Try

                    End If

                Catch ex As Exception
                    result = "FAIL"
                End Try
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                                    dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

            End If
        Else
            Dim dao_re As New DAO_DRUG.ClsDBdrrqt
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            dao_re.fields.lmdfdate = Date.Now
            dao_re.update()
            Dim i As Integer = 0
            Dim dao_c As New DAO_DRUG.TB_DRRQT_NO_USE
            i = dao_c.CountDataby_FK_IDA(Request.QueryString("IDA"))
            If i = 0 Then
                Dim dao As New DAO_DRUG.TB_DRRQT_NO_USE
                dao.fields.FK_IDA = Request.QueryString("IDA")
                dao.fields.NO_USE_DESCRIPTION = txt_no_use.Text
                dao.insert()
            Else
                Dim dao As New DAO_DRUG.TB_DRRQT_NO_USE
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                dao.fields.NO_USE_DESCRIPTION = txt_no_use.Text
                dao.update()
            End If
        End If
        KEEP_LOGS_TABEAN_EDIT(Request.QueryString("IDA"), "แก้ไขข้อห้ามใช้", _CLS.CITIZEN_ID)
        alert("บันทึกเรียบร้อยแล้ว")

    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class