Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UC_DRUG_ANIMAL
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Dim STATUS_ID As String = "0"
    Private _CLS As New CLS_SESSION
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        Try
            STATUS_ID = Request.QueryString("STATUS_ID")
        Catch ex As Exception

        End Try
        'Try
        '    If STATUS_ID = "0" Or STATUS_ID = "" Then
        '        STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
        '    End If

        'Catch ex As Exception

        'End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            HiddenField1.Value = 0
            HiddenField2.Value = 0
            hide_btn()

            If Request.QueryString("tt") <> "" Then
                btn_save.Enabled = False
            End If

            'If STATUS_ID = "8" Then
            '    btn_save.Enabled = False
            'End If
        End If
    End Sub
    Sub hide_btn()
        If HiddenField1.Value = 0 Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
    End Sub
    Public Sub bind_ddl_dramltype()
        Dim dao As New DAO_DRUG.TB_dramltype
        dao.GetDataAll()
        ddl_dramltype.DataSource = dao.datas
        ddl_dramltype.DataTextField = "amltpnm"
        ddl_dramltype.DataValueField = "amltpcd"
        ddl_dramltype.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_dramltype.Items.Insert(0, item)
    End Sub
    Public Sub bind_ddl_dramlsubtp()
        Try
            Dim dao As New DAO_DRUG.TB_dramlsubtp
            dao.GetDataby_amltpcd(ddl_dramltype.SelectedValue)
            ddl_dramlsubtp.DataSource = dao.datas
            ddl_dramlsubtp.DataTextField = "amlsubnm"
            ddl_dramlsubtp.DataValueField = "amlsubcd"
            ddl_dramlsubtp.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_dramlsubtp.Items.Insert(0, item)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub bind_ddl_dramlusetp()
        Dim dao As New DAO_DRUG.TB_dramlusetp
        dao.GetDataAll()
        ddl_dramlusetp.DataSource = dao.datas
        ddl_dramlusetp.DataTextField = "usetpnm"
        ddl_dramlusetp.DataValueField = "usetpcd"
        ddl_dramlusetp.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_dramlusetp.Items.Insert(0, item)
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        RunQuery()
        If HiddenField1.Value = 0 Then
            Dim i As Integer = 0
            If STATUS_ID = 8 Then
                i = CountEmpty()
                Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                dao1.GetDataby_FK_IDA(_IDA)
                dao1.fields.lmdfdate = Date.Now
                If i = 0 Then
                    Dim dao As New DAO_DRUG.ClsDBdramldrg
                   
                    With dao.fields
                        .amlsubcd = ddl_dramlsubtp.SelectedValue
                        .amltpcd = ddl_dramltype.SelectedValue
                        .usetpcd = ddl_dramlusetp.SelectedValue
                        Try
                            .drgtpcd = dao1.fields.drgtpcd
                        Catch ex As Exception

                        End Try

                        .FK_IDA = _IDA
                        Try
                            .pvncd = dao1.fields.pvncd
                        Catch ex As Exception

                        End Try
                        Try
                            .rgttpcd = dao1.fields.rgttpcd
                        Catch ex As Exception

                        End Try

                    End With
                    dao.insert()

                    Dim ws_drug As New WS_DRUG.WS_DRUG
                    'ws_drug.DRUG_UPDATE_DR(dao1.fields.pvncd, dao1.fields.rgttpcd, dao1.fields.drgtpcd, dao1.fields.rgtno, "แก้ไขทะเบียนยาสัตว์", _CLS.CITIZEN_ID, "DRUG")
                    Try
                        If Request.QueryString("e") = "" Then
                            WS_DRUG.Timeout = 8000
                            'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
                            Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                            dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                            Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                            Dim cls_xml_DR As New LGT_IOW_E
                            cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                            Dim str_xml As String = ""
                            Try
                                SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao1.fields.IDENTIFY)

                                ws_drug.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                            Catch ex As Exception

                            End Try
                        End If

                    Catch ex As Exception

                    End Try

                    alert("บันทึกเรียบร้อย")
                Else
                    alert("กรุณากรอกข้อมูลให้ครบถ้วน")
                End If
                Try
                    dao1.fields.lmdfdate = Date.Now
                Catch ex As Exception

                End Try
                dao1.update()
            Else
                i = CountEmpty()
                Dim dao1 As New DAO_DRUG.ClsDBdrrqt
                dao1.GetDataby_FK_IDA(_IDA)
                If i = 0 Then
                    Dim dao As New DAO_DRUG.ClsDBdrramldrg
                   
                    With dao.fields
                        .amlsubcd = ddl_dramlsubtp.SelectedValue
                        .amltpcd = ddl_dramltype.SelectedValue
                        .usetpcd = ddl_dramlusetp.SelectedValue
                        Try
                            .drgtpcd = dao1.fields.drgtpcd
                        Catch ex As Exception

                        End Try

                        .FK_IDA = _IDA
                        Try
                            .pvncd = dao1.fields.pvncd
                        Catch ex As Exception

                        End Try
                        Try
                            .rgttpcd = dao1.fields.rgttpcd
                        Catch ex As Exception

                        End Try
                    End With
                    dao.insert()

                    alert("บันทึกเรียบร้อย")
                Else
                    alert("กรุณากรอกข้อมูลให้ครบถ้วน")
                End If
                dao1.fields.lmdfdate = Date.Now
                dao1.update()
            End If
        Else
            If Request.QueryString("STATUS_ID") = "8" Then
                Dim dao As New DAO_DRUG.ClsDBdramldrg
                dao.GetData_by_IDA(HiddenField1.Value)
                With dao.fields
                    .amlsubcd = ddl_dramlsubtp.SelectedValue
                    .amltpcd = ddl_dramltype.SelectedValue
                    .usetpcd = ddl_dramlusetp.SelectedValue
                End With

                Dim dao_sub As New DAO_DRUG.ClsDBdramluse
                dao_sub.GetDatabyIDA(HiddenField2.Value)  '(_IDA, dao.fields.amltpcd, dao.fields.amlsubcd, dao.fields.usetpcd)
                With dao_sub.fields
                    .amlsubcd = ddl_dramlsubtp.SelectedValue
                    .amltpcd = ddl_dramltype.SelectedValue
                    .usetpcd = ddl_dramlusetp.SelectedValue
                End With
                dao.update()
                dao_sub.update()
            Else
                Dim dao As New DAO_DRUG.ClsDBdrramldrg
                'dao.GetData_by_FK_IDA(_IDA)
                dao.GetData_by_IDA(HiddenField1.Value)
                With dao.fields
                    .amlsubcd = ddl_dramlsubtp.SelectedValue
                    .amltpcd = ddl_dramltype.SelectedValue
                    .usetpcd = ddl_dramlusetp.SelectedValue
                End With


                Dim dao_sub As New DAO_DRUG.ClsDBdrramluse
                dao_sub.GetDatabyIDA(HiddenField2.Value)
                With dao_sub.fields
                    .amlsubcd = ddl_dramlsubtp.SelectedValue
                    .amltpcd = ddl_dramltype.SelectedValue
                    .usetpcd = ddl_dramlusetp.SelectedValue
                End With
                dao.update()
                dao_sub.update()
            End If

            'Dim dao_dr As New DAO_DRUG.ClsDBdramldrg
            'dao_dr.GetData_by_FK_IDA(_IDA)
            'Dim max_no As Integer = 0
            'Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            'dao_edt.GET_MAX_NO("dramldrg", dao_dr.fields.IDA)
            'Try
            '    max_no = dao_edt.fields.COUNT_EDIT
            'Catch ex As Exception

            'End Try
            'Dim filename As String = ""
            'filename = "dramldrg_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "dramldrg"
            'End With
            'dao_index.insert()
            alert("แก้ไขเรียบร้อย")

        End If
        KEEP_LOGS_TABEAN_EDIT(_IDA, "แก้ไขยาสัตว์", _CLS.CITIZEN_ID)
        rgAnimals.Rebind()
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Function CountEmpty() As Integer
        Dim i As Integer = 0
        If ddl_dramltype.SelectedValue = "0" Then
            i += 1
        End If
        If ddl_dramlsubtp.SelectedValue = "0" Then
            i += 1
        End If
        If ddl_dramlusetp.SelectedValue = "0" Then
            i += 1
        End If
        Return i
    End Function

    Private Sub rgAnimals_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgAnimals.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("H_IDA").Text
            Catch ex As Exception

            End Try
            If e.CommandName = "_del" Then
                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                    'ElseIf STATUS_ID = 8 Then
                    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else
                    If STATUS_ID = 8 Then
                        Dim dao As New DAO_DRUG.ClsDBdramldrg
                        dao.GetData_by_IDA(IDA)
                        dao.delete()

                        Try
                            If Request.QueryString("e") = "" Then
                                Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                                WS_DRUG.Timeout = 8000
                                'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
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
                                Catch ex As Exception

                                End Try
                            End If

                        Catch ex As Exception

                        End Try


                        alert("ลบข้อมูลเรียบร้อย")
                    Else
                        Dim dao As New DAO_DRUG.ClsDBdrramldrg
                        dao.GetData_by_IDA(IDA)
                        dao.delete()
                        alert("ลบข้อมูลเรียบร้อย")
                    End If
                End If
                rgAnimals.Rebind()
            ElseIf e.CommandName = "_sel" Then
                Response.Redirect("../TABEAN_YA/FRM_SUB_DRUG_ANIMAL.aspx?IDA=" & IDA & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&r_id=" & _IDA & "&STATUS_ID=" & STATUS_ID)
            ElseIf e.CommandName = "_edt" Then
                If STATUS_ID = 8 Then
                    Dim dao As New DAO_DRUG.ClsDBdramldrg
                    dao.GetData_by_IDA(IDA)
                    With dao.fields
                        Try
                            ddl_dramltype.DropDownSelectData(.amltpcd)
                        Catch ex As Exception

                        End Try
                        bind_ddl_dramlsubtp()
                        Try
                            ddl_dramlsubtp.DropDownSelectData(.amlsubcd)
                        Catch ex As Exception

                        End Try
                        bind_ddl_dramlusetp()
                        Try
                            ddl_dramlusetp.DropDownSelectData(.usetpcd)
                        Catch ex As Exception

                        End Try
                    End With

                Else
                    Dim dao As New DAO_DRUG.ClsDBdrramldrg
                    dao.GetData_by_IDA(IDA)
                    With dao.fields
                        Try
                            ddl_dramltype.DropDownSelectData(.amltpcd)
                        Catch ex As Exception

                        End Try
                        bind_ddl_dramlsubtp()
                        Try
                            ddl_dramlsubtp.DropDownSelectData(.amlsubcd)
                        Catch ex As Exception

                        End Try
                        bind_ddl_dramlusetp()
                        Try
                            ddl_dramlusetp.DropDownSelectData(.usetpcd)
                        Catch ex As Exception

                        End Try
                    End With
                End If

                HiddenField1.Value = IDA
                HiddenField2.Value = item("SUB_IDA").Text
                hide_btn()
            End If

            End If
    End Sub

    Private Sub rgAnimals_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAnimals.NeedDataSource
        RunQuery()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        'Dim STATUS_ID As Integer = 0
        'Try
        '    STATUS_ID = Get_drrqt_Status(_IDA)
        'Catch ex As Exception

        'End Try
        'RunQuery()
        Try
            If STATUS_ID <> 8 Then
                dt = bao.SP_drramldrg_GRID_BY_FK_IDA(_IDA)
            Else

                dt = bao.SP_dramldrg_GRID_BY_FK_IDA(_IDA)
            End If
        Catch ex As Exception

        End Try


        rgAnimals.DataSource = dt
    End Sub

    Private Sub ddl_dramltype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_dramltype.SelectedIndexChanged
        bind_ddl_dramlsubtp()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HiddenField1.Value = 0
        hide_btn()
    End Sub
End Class