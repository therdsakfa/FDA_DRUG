Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UT_NAME_DRUG_EXPORT
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            If Request.QueryString("tt") <> "" Then
                btn_save.Enabled = False
            End If
        End If
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Public Sub bind_country()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_MASTER_sysisocnt()

        DropDownList1.DataSource = dt
        DropDownList1.DataTextField = "engcntnm"
        DropDownList1.DataValueField = "alpha3"
        DropDownList1.DataBind()

        Dim item As New ListItem
        item.Text = "--All Contries--"
        item.Value = "0"
        DropDownList1.Items.Insert(0, item)
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "_del" Then
                If Request.QueryString("tt") <> "" Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถลบข้อมูลได้');", True)
                Else
                    If STATUS_ID = 8 Then
                        Dim dao As New DAO_DRUG.TB_DRRGT_NAME_DRUG_EXPORT
                        dao.GetDataby_IDA(IDA)
                        dao.delete()
                    Else
                        Dim dao As New DAO_DRUG.TB_DRRQT_NAME_DRUG_EXPORT
                        dao.GetDataby_IDA(IDA)
                        dao.delete()
                    End If

                    RadGrid2.Rebind()
                End If
            End If
        End If
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        If STATUS_ID = 8 Then
            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            dao1.GetDataby_FK_DRRQT(_IDA)
            dt = bao.SP_DRRGT_NAME_DRUG_EXPORT_BY_FK_IDA(_IDA)
        Else
            dt = bao.SP_DRRQT_NAME_DRUG_EXPORT_BY_FK_IDA(_IDA)
        End If
        RadGrid2.DataSource = dt
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If STATUS_ID = 8 Then
            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            dao1.GetDataby_FK_DRRQT(_IDA)

            Dim dao_max As New DAO_DRUG.TB_DRRGT_NAME_DRUG_EXPORT
            dao_max.GetDataMAX(_IDA)
            Dim max_id As Integer = 0
            Try
                max_id = dao_max.fields.SEQ
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_DRRGT_NAME_DRUG_EXPORT
            dao.fields.DRUG_NAME = TextBox1.Text
            dao.fields.ALPHA3 = DropDownList1.SelectedValue
            dao.fields.FK_IDA = _IDA
            dao.fields.SEQ = max_id + 1
            dao.insert()

            Dim dao_dr As New DAO_DRUG.TB_DRRGT_NAME_DRUG_EXPORT
            dao_dr.GetDataby_FKIDA(Request.QueryString("IDA"))
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_NAME_DRUG_EXPORT", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try
            'Dim filename As String = ""
            'filename = "DRRGT_NAME_DRUG_EXPORT_" & max_no + 1 & ".xml"
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
            '    .TABLE_NAME = "DRRGT_NAME_DRUG_EXPORT"
            'End With
            'dao_index.insert()
        Else
            Dim dao_max As New DAO_DRUG.TB_DRRQT_NAME_DRUG_EXPORT
            dao_max.GetDataMAX(_IDA)
            Dim max_id As Integer = 0
            Try
                max_id = dao_max.fields.SEQ
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.TB_DRRQT_NAME_DRUG_EXPORT
            dao.fields.DRUG_NAME = TextBox1.Text
            dao.fields.ALPHA3 = DropDownList1.SelectedValue
            dao.fields.FK_IDA = _IDA
            dao.fields.SEQ = max_id + 1
            dao.insert()
        End If
        RadGrid2.Rebind()
        alert("บันทึกเรียบร้อยแล้ว")
    End Sub
End Class