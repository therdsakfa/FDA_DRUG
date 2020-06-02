Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class UC_Packing_Size
    Inherits System.Web.UI.UserControl
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()

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
            bind_ddl_small_unit()
            bind_ddl_medium_unit()
        End If
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If STATUS_ID = 8 Then
            Dim dao1 As New DAO_DRUG.ClsDBdrrgt
            dao1.GetDataby_FK_DRRQT(Request.QueryString("IDA"))
            Dim dao As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao.fields.SMALL_AMOUNT = txt_SMALL_AMOUNT.Text
            dao.fields.SMALL_UNIT = ddl_small_unit.SelectedValue
            dao.fields.MEDIUM_UNIT = ddl_medium_unit.SelectedValue
            dao.fields.BARCODE = txt_BARCODE.Text
            dao.fields.FK_IDA = dao1.fields.IDA
            dao.insert()

            Dim dao_dr As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_dr.GetDataby_FKIDA(Request.QueryString("IDA"))
            Dim max_no As Integer = 0
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            dao_edt.GET_MAX_NO("DRRGT_PACKAGE_DETAIL", dao_dr.fields.IDA)
            Try
                max_no = dao_edt.fields.COUNT_EDIT
            Catch ex As Exception

            End Try
            Dim filename As String = ""
            filename = "DRRGT_PACKAGE_DETAIL_" & max_no + 1 & ".xml"
            Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
            bao_app.RunAppSettings()
            Dim path As String = bao_app._PATH_EDIT & filename
            Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
            Dim x As New XmlSerializer(dao_dr.fields.GetType)                                                     'ประกาศ
            x.Serialize(objStreamWriter, dao_dr.fields)
            objStreamWriter.Close()

            Dim dao_index As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
            With dao_index.fields
                .COUNT_EDIT = max_no + 1
                .CREATE_DATE = Date.Now
                .FILE_NAME = filename
                .FK_DRRGT_IDA = Request.QueryString("IDA")
                .FK_IDA = dao_dr.fields.IDA
                .TABLE_NAME = "DRRGT_PACKAGE_DETAIL"
            End With
            dao_index.insert()

        Else
            Dim dao As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
            dao.fields.SMALL_AMOUNT = txt_SMALL_AMOUNT.Text
            dao.fields.SMALL_UNIT = ddl_small_unit.SelectedValue
            dao.fields.MEDIUM_UNIT = ddl_medium_unit.SelectedValue
            dao.fields.BARCODE = txt_BARCODE.Text
            dao.fields.FK_IDA = Request.QueryString("IDA")
            dao.insert()
        End If


        alert("บันทึกแล้ว")
        RadGrid2.Rebind()
    End Sub

    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "del" Then
                If STATUS_ID = 8 Then
                    Dim dao As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                Else
                    Dim dao As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
                    dao.GetDataby_IDA(IDA)
                    dao.delete()
                End If

                RadGrid2.Rebind()
            End If

        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao_show As New BAO_SHOW
        Dim dt As New DataTable
        Dim ida As String = ""
        Try
            ida = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        If ida <> "" Then
            If STATUS_ID = 8 Then
                Dim dao1 As New DAO_DRUG.ClsDBdrrgt
                dao1.GetDataby_FK_DRRQT(ida)

                dt = bao_show.SP_DRUG_DRRGT_PACKAGE_BY_IDA_v2(dao1.fields.IDA)
            Else
                dt = bao_show.SP_DRUG_DRRQT_PACKAGE_BY_IDA_v2(ida)
            End If

        End If

        If dt.Rows.Count > 0 Then
            RadGrid2.DataSource = dt
        End If
    End Sub

    Public Sub bind_ddl_small_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        ddl_small_unit.DataSource = dt
        ddl_small_unit.DataTextField = "unit_name"
        ddl_small_unit.DataValueField = "sunitcd"
        ddl_small_unit.DataBind()
    End Sub

    Public Sub bind_ddl_medium_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_MASTER_drsunit()
        ddl_medium_unit.DataSource = dt
        ddl_medium_unit.DataTextField = "sunitengnm"
        ddl_medium_unit.DataValueField = "sunitcd"
        ddl_medium_unit.DataBind()
    End Sub
End Class