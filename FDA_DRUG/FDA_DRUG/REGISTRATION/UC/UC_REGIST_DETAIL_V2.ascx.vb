Imports Telerik.Web.UI
Public Class UC_REGIST_DETAIL_V2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_dactg()
            bind_drclass()
            bind_dosage_form()
            bind_DRUG_SHAPE()
            bind_ddl_packaging()
            bind_ddl_bio_unit()
            bind_ddl_small_unit()
            bind_drug_type()

            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao.GetDataby_IDA(Request.QueryString("IDA"))

            'รูปแบบยา
            Try
                'ddl_drdosage.DropDownSelectData(dao.fields.FK_DOSAGE_FORM)
                rcb_drclass.SelectedValue = dao.fields.FK_DOSAGE_FORM
            Catch ex As Exception

            End Try
            'หมวดยา
            Try
                'ddl_dactg.DropDownSelectData(dao.fields.DRUG_GROUP)
                rcb_dactg.SelectedValue = dao.fields.DRUG_GROUP
            Catch ex As Exception

            End Try
            'ประเภทของยา
            Try
                'ddl_drclass.DropDownSelectData(dao.fields.GROUP_TYPE)
                rcb_drclass.SelectedValue = dao.fields.GROUP_TYPE
            Catch ex As Exception

            End Try
            'หน่วยนับชีวะภาพ
            Try
                'ddl_bio_pack.DropDownSelectData(dao.fields.UNIT_BIO)
                rcb_bio_pack.SelectedValue = dao.fields.UNIT_BIO
            Catch ex As Exception

            End Try
            'หน่วยนับตามรูปของแบบยา
            Try
                'ddl_small_unit.DropDownSelectData(dao.fields.UNIT_NORMAL)
                rcb_small_unit.SelectedValue = dao.fields.UNIT_NORMAL
            Catch ex As Exception

            End Try
            'หน่วยนับตามบรรจุภัณฑ์
            Try
                'ddl_packaging.DropDownSelectData(dao.fields.DRUG_PACKING)
                rcb_packaging.SelectedValue = dao.fields.DRUG_PACKING
            Catch ex As Exception

            End Try
            Try
                'ddl_shape.DropDownSelectData(dao.fields.DRUG_STYLE)
                rcb_shape.SelectedValue = dao.fields.DRUG_STYLE
            Catch ex As Exception

            End Try
            Try
                rcb_drdosage.SelectedValue = dao.fields.FK_DOSAGE_FORM
            Catch ex As Exception

            End Try
            'ชนิดยา
            Try
                rcb_drug_type.SelectedValue = dao.fields.kindcd
            Catch ex As Exception

            End Try
            Try
                txt_drug_str.Text = dao.fields.DRUG_STR
            Catch ex As Exception

            End Try

        End If
    End Sub
    Sub Set_lbl()

    End Sub
    Sub bind_drug_type()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_drkdofdrg()

        rcb_drug_type.DataSource = dt
        rcb_drug_type.DataTextField = "thakindnm"
        rcb_drug_type.DataValueField = "kindcd"
        rcb_drug_type.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_drug_type.Items.Insert(0, item)
    End Sub
    ''' <summary>
    ''' หมวดยา
    ''' </summary>
    ''' <remarks></remarks>
    Sub bind_dactg()
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_master_2.SP_dactg
        'ddl_dactg.DataSource = dt
        'ddl_dactg.DataTextField = "ctgthanm"
        'ddl_dactg.DataValueField = "ctgcd"
        'ddl_dactg.DataBind()
        rcb_dactg.DataSource = dt
        rcb_dactg.DataTextField = "ctgthanm"
        rcb_dactg.DataValueField = "ctgcd"
        rcb_dactg.DataBind()
    End Sub
    ''' <summary>
    ''' ประเภทของยา
    ''' </summary>
    ''' <remarks></remarks>
    Sub bind_drclass()
        Dim bao_master_2 As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao_master_2.SP_MASTER_drclass()
        'ddl_drclass.DataSource = dt
        'ddl_drclass.DataTextField = "thaclassnm"
        'ddl_drclass.DataValueField = "classcd"
        'ddl_drclass.DataBind()

        rcb_drclass.DataSource = dt
        rcb_drclass.DataTextField = "thaclassnm"
        rcb_drclass.DataValueField = "classcd"
        rcb_drclass.DataBind()
    End Sub
    ''' <summary>
    ''' รูปของแบบยา
    ''' </summary>
    ''' <remarks></remarks>
    Sub bind_dosage_form()
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_master_2.SP_dosage_form()
        'ddl_drdosage.DataSource = dt
        'ddl_drdosage.DataTextField = "thadsgnm"
        'ddl_drdosage.DataValueField = "dsgcd"
        'ddl_drdosage.DataBind()

        rcb_drdosage.DataSource = dt
        rcb_drdosage.DataTextField = "thadsgnm"
        rcb_drdosage.DataValueField = "dsgcd"
        rcb_drdosage.DataBind()
    End Sub
    ''' <summary>
    ''' รูปทรง
    ''' </summary>
    ''' <remarks></remarks>
    Sub bind_DRUG_SHAPE()
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao_master_2.SP_MAS_DRUG_SHAPE()
        'ddl_shape.DataSource = dt
        'ddl_shape.DataTextField = "SHAPE_NAME"
        'ddl_shape.DataValueField = "SHAPE_IDA"
        'ddl_shape.DataBind()
        rcb_shape.DataSource = dt
        rcb_shape.DataTextField = "SHAPE_NAME"
        rcb_shape.DataValueField = "SHAPE_IDA"
        rcb_shape.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-"
        item.Value = "0"
        rcb_shape.Items.Insert(0, item)

    End Sub
    ''' <summary>
    ''' หน่วยนับตามบรรจุภัณฑ์
    ''' </summary>
    ''' <remarks></remarks>
    Sub bind_ddl_packaging()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_PACKAGING
        dao.GetDataAll()
        'ddl_packaging.DataSource = dao.datas
        'ddl_packaging.DataTextField = "PACKAGING_NAME"
        'ddl_packaging.DataValueField = "UOP_CODE"
        'ddl_packaging.DataBind()

        rcb_packaging.DataSource = dao.datas
        rcb_packaging.DataTextField = "PACKAGING_NAME"
        rcb_packaging.DataValueField = "UOP_CODE"
        rcb_packaging.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-"
        item.Value = "0"
        rcb_packaging.Items.Insert(0, item)
    End Sub
    ''' <summary>
    ''' หน่วยนับทางชีวภาพ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub bind_ddl_bio_unit()
        Dim dao As New DAO_DRUG.TB_MAS_BIO_UNIT
        dao.GetDataALL()
        'ddl_bio_pack.DataSource = dao.datas
        'ddl_bio_pack.DataTextField = "BIO_UNIT"
        'ddl_bio_pack.DataValueField = "IDA"
        'ddl_bio_pack.DataBind()

        rcb_bio_pack.DataSource = dao.datas
        rcb_bio_pack.DataTextField = "BIO_UNIT"
        rcb_bio_pack.DataValueField = "IDA"
        rcb_bio_pack.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-"
        item.Value = "0"
        rcb_bio_pack.Items.Insert(0, item)
    End Sub
    ''' <summary>
    ''' หน่วยนับตามรูปของแบบยา
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub bind_ddl_small_unit()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_DRUG_UNIT_PHYSIC()
        'ddl_small_unit.DataSource = dt
        'ddl_small_unit.DataTextField = "unit_name"
        'ddl_small_unit.DataValueField = "sunitcd"
        'ddl_small_unit.DataBind()

        rcb_small_unit.DataSource = dt
        rcb_small_unit.DataTextField = "unit_name"
        rcb_small_unit.DataValueField = "sunitcd"
        rcb_small_unit.DataBind()

        Dim item As New RadComboBoxItem
        item.Text = "-"
        item.Value = "0"
        rcb_small_unit.Items.Insert(0, item)
    End Sub
    'Sub bind_dosage_form()
    '    Dim bao_master_2 As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    dt = bao_master_2.SP_dosage_form()
    '    ddl_drdosage.DataSource = dt
    '    ddl_drdosage.DataTextField = "thadsgnm"
    '    ddl_drdosage.DataValueField = "dsgcd"
    '    ddl_drdosage.DataBind()
    'End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        Try
            dao.fields.kindcd = rcb_drug_type.SelectedValue
        Catch ex As Exception

        End Try
        'รูปแบบยา
        Try
            dao.fields.FK_DOSAGE_FORM = rcb_drdosage.SelectedValue
        Catch ex As Exception

        End Try
        'หมวดยา
        Try
            dao.fields.DRUG_GROUP = rcb_dactg.SelectedValue
        Catch ex As Exception

        End Try
        'ประเภทของยา
        Try
            dao.fields.GROUP_TYPE = rcb_drclass.SelectedValue
        Catch ex As Exception

        End Try
        'หน่วยนับชีวะภาพ
        Try
            dao.fields.UNIT_BIO = rcb_bio_pack.SelectedValue
        Catch ex As Exception

        End Try
        'หน่วยนับตามรูปของแบบยา
        Try
            dao.fields.UNIT_NORMAL = rcb_small_unit.SelectedValue
        Catch ex As Exception

        End Try
        'หน่วยนับตามบรรจุภัณฑ์
        Try
            dao.fields.DRUG_PACKING = rcb_packaging.SelectedValue
        Catch ex As Exception

        End Try
        'รูปทรง
        Try
            dao.fields.DRUG_STYLE = rcb_shape.SelectedValue
        Catch ex As Exception

        End Try
        'ความแรง
        Try
            dao.fields.DRUG_STR = txt_drug_str.Text
        Catch ex As Exception

        End Try


        dao.update()
        Response.Write("<script type='text/javascript'>alert('บันทึกแล้วเรียบร้อย');</script> ")

    End Sub
End Class