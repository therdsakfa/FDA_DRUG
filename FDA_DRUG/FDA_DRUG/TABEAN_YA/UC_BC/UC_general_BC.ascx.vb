Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml
Imports Telerik.Web.UI
Public Class UC_general_BC
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
    Dim STATUS_ID As Integer = 0
    Private _CLS As New CLS_SESSION
    Sub RunQuery()
        'Try
        '    _CLS = Session("CLS")
        'Catch ex As Exception
        '    Response.Redirect("http://privus.fda.moph.go.th/")
        'End Try
        'Try
        '    If Request.QueryString("STATUS_ID") <> "" Then
        '        STATUS_ID = Request.QueryString("STATUS_ID")
        '    Else
        '        STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            'show_data(Request.QueryString("IDA"))
            'show_data_rqt(Request.QueryString("IDA"))
            'bind_label()
        End If
    End Sub
    Sub show_data(ByVal newcode As String)
        RunQuery()
        'If STATUS_ID = 8 Then
        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN

        Dim xml_iow As New LGT_IOW_E
        Dim xml_str As String

        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2(newcode)
        If xml_str <> "FAIL" Then
            'MODEL.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)

        Else

        End If

        'Dim dao As New DAO_DRUG.ClsDBdrrgt
        'dao.GetDataby_IDA(IDA)

        Try
            'ddl_dactg.DropDownSelectData(dao.fields.ctgcd)
            rcb_dactg.SelectedValue = xml_iow.XML_SEARCH_DRUG_DR.ctgcd 'dao.fields.ctgcd
            'Dim xml_iow2 As New LGT_IOW_E
            'xml_iow2.XML_SEARCH_DRUG_DR.
            Dim AAA As New LGT_XML_FRGN_ALL_TO
            AAA.XML_DRUG_FRGN.district = "A"
            AAA.XML_DRUG_FRGN.engcntnm = "BB"

            Dim bb As New List(Of LGT_XML_FRGN_ALL_TO)
            bb.Add(AAA)

        Catch ex As Exception

        End Try

        Try
            'ddl_dosage_form.DropDownSelectData(dao.fields.dsgcd)
            rcb_drdosage.SelectedValue = xml_iow.XML_SEARCH_DRUG_DR.dsgcd
        Catch ex As Exception

        End Try
        Try
            ' rcb_drclass.DropDownSelectData(dao.fields.classcd)
            rcb_drclass.SelectedValue = xml_iow.XML_SEARCH_DRUG_DR.thaclassnm & "/" & xml_iow.XML_SEARCH_DRUG_DR.engclassnm
        Catch ex As Exception

        End Try

        'ชนิดยา
        Try
            rcb_drug_type.SelectedItem.Text = xml_iow.XML_SEARCH_DRUG_DR.thakindnm & "/" & xml_iow.XML_SEARCH_DRUG_DR.engkindnm
        Catch ex As Exception

        End Try
        ''Try
        ''    'ddl_shape.DropDownSelectData(dao.fields.DRUG_STYLE)
        ''    rcb_shape.SelectedValue = dao.fields.DRUG_STYLE
        ''Catch ex As Exception

        ''End Try
        ''หน่วยนับชีวะภาพ
        'Try
        '    'ddl_bio_pack.DropDownSelectData(dao.fields.UNIT_BIO)
        '    rcb_bio_pack.SelectedValue = dao.fields.UNIT_BIO
        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามรูปของแบบยา
        'Try
        '    'ddl_small_unit.DropDownSelectData(dao.fields.UNIT_NORMAL)
        '    rcb_small_unit.SelectedValue = dao.fields.UNIT_NORMAL
        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามบรรจุภัณฑ์
        'Try
        '    'ddl_packaging.DropDownSelectData(dao.fields.DRUG_PACKING)
        '    rcb_packaging.SelectedValue = dao.fields.DRUG_PACKING
        'Catch ex As Exception

        'End Try
        'Else
        '    'Dim dao As New DAO_DRUG.ClsDBdrrqt
        '    'dao.GetDataby_IDA(IDA)

        '    'Try
        '    '    'ddl_dactg.DropDownSelectData(dao.fields.DRUG_GROUP)
        '    '    rcb_dactg.SelectedValue = dao.fields.ctgcd
        '    'Catch ex As Exception

        '    'End Try
        '    'Try
        '    '    'ddl_dosage_form.DropDownSelectData(dao.fields.dsgcd)
        '    '    rcb_drdosage.SelectedValue = dao.fields.dsgcd
        '    'Catch ex As Exception

        '    'End Try
        '    'Try
        '    '    ' rcb_drclass.DropDownSelectData(dao.fields.classcd)
        '    '    rcb_drclass.SelectedValue = dao.fields.classcd
        '    'Catch ex As Exception

        '    'End Try
        '    ''ชนิดยา
        '    'Try
        '    '    rcb_drug_type.SelectedValue = dao.fields.kindcd
        '    'Catch ex As Exception

        '    'End Try

        '    'Try
        '    '    'ddl_shape.DropDownSelectData(dao.fields.DRUG_STYLE)
        '    '    rcb_shape.SelectedValue = dao.fields.DRUG_STYLE
        '    'Catch ex As Exception

        '    'End Try
        '    ''หน่วยนับชีวะภาพ
        '    'Try
        '    '    'ddl_bio_pack.DropDownSelectData(dao.fields.UNIT_BIO)
        '    '    rcb_bio_pack.SelectedValue = dao.fields.UNIT_BIO
        '    'Catch ex As Exception

        '    'End Try
        '    ''หน่วยนับตามรูปของแบบยา
        '    'Try
        '    '    'ddl_small_unit.DropDownSelectData(dao.fields.UNIT_NORMAL)
        '    '    rcb_small_unit.SelectedValue = dao.fields.UNIT_NORMAL
        '    'Catch ex As Exception

        '    'End Try
        '    ''หน่วยนับตามบรรจุภัณฑ์
        '    'Try
        '    '    'ddl_packaging.DropDownSelectData(dao.fields.DRUG_PACKING)
        '    '    rcb_packaging.SelectedValue = dao.fields.DRUG_PACKING
        '    'Catch ex As Exception

        '    'End Try
        'End If

    End Sub
    Sub show_data_rqt(ByVal IDA As Integer)
        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(IDA)
            Try
                'ddl_dactg.DropDownSelectData(dao.fields.ctgcd)
                rcb_dactg.SelectedValue = dao.fields.ctgcd
            Catch ex As Exception

            End Try

            Try
                'ddl_dosage_form.DropDownSelectData(dao.fields.dsgcd)
                rcb_drdosage.SelectedValue = dao.fields.dsgcd
            Catch ex As Exception

            End Try
            Try
                ' rcb_drclass.DropDownSelectData(dao.fields.classcd)
                rcb_drclass.SelectedValue = dao.fields.classcd
            Catch ex As Exception

            End Try
         
            'ชนิดยา
            Try
                rcb_drug_type.SelectedValue = dao.fields.kindcd
            Catch ex As Exception

            End Try
            'Try
            '    txt_drug_str.Text = dao.fields.DRUG_STRENGTH
            'Catch ex As Exception

            'End Try
            'Try
            '    'ddl_shape.DropDownSelectData(dao.fields.DRUG_STYLE)
            '    rcb_shape.SelectedValue = dao.fields.DRUG_STYLE
            'Catch ex As Exception

            'End Try
            ''หน่วยนับชีวะภาพ
            'Try
            '    'ddl_bio_pack.DropDownSelectData(dao.fields.UNIT_BIO)
            '    rcb_bio_pack.SelectedValue = dao.fields.UNIT_BIO
            'Catch ex As Exception

            'End Try
            ''หน่วยนับตามรูปของแบบยา
            'Try
            '    'ddl_small_unit.DropDownSelectData(dao.fields.UNIT_NORMAL)
            '    rcb_small_unit.SelectedValue = dao.fields.UNIT_NORMAL
            'Catch ex As Exception

            'End Try
            ''หน่วยนับตามบรรจุภัณฑ์
            'Try
            '    'ddl_packaging.DropDownSelectData(dao.fields.DRUG_PACKING)
            '    rcb_packaging.SelectedValue = dao.fields.DRUG_PACKING
            'Catch ex As Exception

            'End Try
        Else
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(IDA)

            Try
                'ddl_dactg.DropDownSelectData(dao.fields.ctgcd)
                rcb_dactg.SelectedValue = dao.fields.ctgcd
            Catch ex As Exception

            End Try

            Try
                'ddl_dosage_form.DropDownSelectData(dao.fields.dsgcd)
                rcb_drdosage.SelectedValue = dao.fields.dsgcd
            Catch ex As Exception

            End Try
            'Try
            '    ' rcb_drclass.DropDownSelectData(dao.fields.classcd)
            '    rcb_drclass.SelectedValue = dao.fields.classcd
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_engname.Text = dao.fields.engdrgnm
            'Catch ex As Exception

            'End Try
            'Try
            '    txt_thaname.Text = dao.fields.thadrgnm
            'Catch ex As Exception

            'End Try
            'ชนิดยา
            Try
                rcb_drug_type.SelectedValue = dao.fields.kindcd
            Catch ex As Exception

            End Try
            'Try
            '    txt_drug_str.Text = dao.fields.DRUG_STRENGTH
            'Catch ex As Exception

            'End Try
            'Try
            '    'ddl_shape.DropDownSelectData(dao.fields.DRUG_STYLE)
            '    rcb_shape.SelectedValue = dao.fields.DRUG_STYLE
            'Catch ex As Exception

            'End Try
            ''หน่วยนับชีวะภาพ
            'Try
            '    'ddl_bio_pack.DropDownSelectData(dao.fields.UNIT_BIO)
            '    rcb_bio_pack.SelectedValue = dao.fields.UNIT_BIO
            'Catch ex As Exception

            'End Try
            ''หน่วยนับตามรูปของแบบยา
            'Try
            '    'ddl_small_unit.DropDownSelectData(dao.fields.UNIT_NORMAL)
            '    rcb_small_unit.SelectedValue = dao.fields.UNIT_NORMAL
            'Catch ex As Exception

            'End Try
            ''หน่วยนับตามบรรจุภัณฑ์
            'Try
            '    'ddl_packaging.DropDownSelectData(dao.fields.DRUG_PACKING)
            '    rcb_packaging.SelectedValue = dao.fields.DRUG_PACKING
            'Catch ex As Exception

            'End Try
        End If

    End Sub
    Public Sub bind_label()
        'If Request.QueryString("STATUS_ID") = "8" Then
        Dim ws_box As New WS_BLOCKCHAIN.WS_BLOCKCHAIN

        Dim xml_iow As New LGT_IOW_E
        Dim xml_str As String

        xml_str = ws_box.WS_BLOCK_CHAIN_GET_DATA_V2("U1DR1C1012460009711C")
        If xml_str <> "FAIL" Then
            'MODEL.LGT_IOW_E = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)
            xml_iow = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str)

        Else

        End If
        Try
            lbl_drgname.Text = xml_iow.XML_SEARCH_DRUG_DR.thadrgnm
        Catch ex As Exception

        End Try
        Try
            lbl_drgname_eng.Text = xml_iow.XML_SEARCH_DRUG_DR.engdrgnm
        Catch ex As Exception

        End Try
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        'หมวดยา
        Try
            'Dim dao_dactg As New DAO_DRUG.ClsDBdactg
            'dao_dactg.GetData_by_cd(dao.fields.ctgcd)
            lbl_dactg.Text = xml_iow.XML_SEARCH_DRUG_DR.ctgthanm & "/" & xml_iow.XML_SEARCH_DRUG_DR.ctgengnm
        Catch ex As Exception

        End Try
        'ประเภทของยา
        Try
            'Dim dao_drclass As New DAO_DRUG.TB_drclass
            'dao_drclass.GetDataBycd(dao.fields.classcd)
            lbl_drclass.Text = xml_iow.XML_SEARCH_DRUG_DR.thaclassnm & "/" & xml_iow.XML_SEARCH_DRUG_DR.engclassnm 'dao_drclass.fields.thaclassnm & "/" & dao_drclass.fields.engclassnm
        Catch ex As Exception

        End Try
        ''หน่วยนับชีวะภาพ
        'Try
        '    Dim dao_bio As New DAO_DRUG.TB_MAS_BIO_UNIT
        '    dao_bio.GetDataby_IDA(dao.fields.UNIT_BIO)
        '    lbl_bio_pack.Text = dao_bio.fields.BIO_UNIT
        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามรูปของแบบยา
        'Try
        '    Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
        '    dao_unit.GetDataby_sunitcd(dao.fields.UNIT_NORMAL)
        '    lbl_small_unit.Text = dao_unit.fields.unit_name
        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามบรรจุภัณฑ์
        'Try
        '    Dim dao_pack As New DAO_DRUG.TB_MAS_DRUG_PACKAGING
        '    dao_pack.GetDataby_UOP_CODE(dao.fields.DRUG_PACKING)
        '    'rcb_packaging.SelectedValue = dao.fields.DRUG_PACKING
        '    lbl_packaging.Text = dao_pack.fields.PACKAGING_NAME
        'Catch ex As Exception

        'End Try
        'Try
        '    Dim dao_shape As New DAO_DRUG.TB_MAS_DRUG_SHAPE
        '    dao_shape.GetDataByIDA(dao.fields.DRUG_STYLE)
        '    lbl_shape.Text = dao_shape.fields.SHAPE_NAME
        'Catch ex As Exception

        'End Try
        Try
            'rcb_drdosage.SelectedValue = dao.fields.FK_DOSAGE_FORM

            'Dim dao_dose As New DAO_DRUG.TB_drdosage
            'dao_dose.GetDataby_cd(dao.fields.dsgcd)
            lbl_drdosage.Text = xml_iow.XML_SEARCH_DRUG_DR.thadsgnm & "/" & xml_iow.XML_SEARCH_DRUG_DR.engdsgnm  'dao_dose.fields.thadsgnm & " / " & dao_dose.fields.engdsgnm
        Catch ex As Exception

        End Try

        'ชนิดยา
        Try

            'Dim dao_drkdofdrg As New DAO_DRUG.TB_drkdofdrg
            'dao_drkdofdrg.GetData_by_kindcd(dao.fields.kindcd)
            ''rcb_drug_type.SelectedValue = dao.fields.kindcd
            lbl_drug_type.Text = xml_iow.XML_SEARCH_DRUG_DR.thakindnm & "/" & xml_iow.XML_SEARCH_DRUG_DR.engkindnm 'dao_drkdofdrg.fields.thakindnm & "/" & dao_drkdofdrg.fields.engkindnm
        Catch ex As Exception

        End Try
        'Else
        '    Dim dao As New DAO_DRUG.ClsDBdrrqt
        '    dao.GetDataby_IDA(Request.QueryString("IDA"))
        '    'หมวดยา
        '    Try
        '        Dim dao_dactg As New DAO_DRUG.ClsDBdactg
        '        dao_dactg.GetData_by_cd(dao.fields.ctgcd)
        '        lbl_dactg.Text = dao_dactg.fields.ctgthanm & "/" & dao_dactg.fields.ctgengnm
        '    Catch ex As Exception

        '    End Try
        '    ''ประเภทของยา
        '    'Try
        '    '    Dim dao_drclass As New DAO_DRUG.TB_drclass
        '    '    dao_drclass.GetDataBycd(dao.fields.classcd)
        '    '    lbl_drclass.Text = dao_drclass.fields.thaclassnm
        '    'Catch ex As Exception

        '    'End Try
        '    ''หน่วยนับชีวะภาพ
        '    'Try
        '    '    Dim dao_bio As New DAO_DRUG.TB_MAS_BIO_UNIT
        '    '    dao_bio.GetDataby_IDA(dao.fields.UNIT_BIO)
        '    '    lbl_bio_pack.Text = dao_bio.fields.BIO_UNIT
        '    'Catch ex As Exception

        '    'End Try
        '    ''หน่วยนับตามรูปของแบบยา
        '    'Try
        '    '    Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
        '    '    dao_unit.GetDataby_sunitcd(dao.fields.UNIT_NORMAL)
        '    '    lbl_small_unit.Text = dao_unit.fields.unit_name
        '    'Catch ex As Exception

        '    'End Try
        '    ''หน่วยนับตามบรรจุภัณฑ์
        '    'Try
        '    '    Dim dao_pack As New DAO_DRUG.TB_MAS_DRUG_PACKAGING
        '    '    dao_pack.GetDataby_UOP_CODE(dao.fields.DRUG_PACKING)
        '    '    'rcb_packaging.SelectedValue = dao.fields.DRUG_PACKING
        '    '    lbl_packaging.Text = dao_pack.fields.PACKAGING_NAME
        '    'Catch ex As Exception

        '    'End Try
        '    'Try
        '    '    Dim dao_shape As New DAO_DRUG.TB_MAS_DRUG_SHAPE
        '    '    dao_shape.GetDataByIDA(dao.fields.DRUG_STYLE)
        '    '    lbl_shape.Text = dao_shape.fields.SHAPE_NAME
        '    'Catch ex As Exception

        '    'End Try
        '    'Try
        '    '    'rcb_drdosage.SelectedValue = dao.fields.FK_DOSAGE_FORM

        '    '    Dim dao_dose As New DAO_DRUG.TB_drdosage
        '    '    dao_dose.GetDataby_cd(dao.fields.dsgcd)
        '    '    lbl_drdosage.Text = dao_dose.fields.thadsgnm
        '    'Catch ex As Exception

        '    'End Try

        '    'ชนิดยา
        '    Try

        '        Dim dao_drkdofdrg As New DAO_DRUG.TB_drkdofdrg
        '        dao_drkdofdrg.GetData_by_kindcd(dao.fields.kindcd)
        '        'rcb_drug_type.SelectedValue = dao.fields.kindcd
        '        lbl_drug_type.Text = dao_drkdofdrg.fields.thakindnm & "/" & dao_drkdofdrg.fields.engkindnm
        '    Catch ex As Exception

        '    End Try
        'End If

    End Sub
    Sub bind_dactg()
        Try
            Dim bao_master_2 As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao_master_2.SP_dactg

            rcb_dactg.DataSource = dt
            rcb_dactg.DataTextField = "ctgthanm"
            rcb_dactg.DataValueField = "ctgcd"
            rcb_dactg.DataBind()
            'Dim dt As New DataTable
            'Dim bao As New BAO.ClsDBSqlcommand
            'dt = bao.SP_dactg()
            'ddl_dactg.DataSource = dt
            'ddl_dactg.DataTextField = "ctgthanm"
            'ddl_dactg.DataValueField = "ctgcd"
            'ddl_dactg.DataBind()

            'Dim item As New ListItem
            'item.Text = "--กรุณาเลือก--"
            'item.Value = "0"
            'ddl_dactg.Items.Insert(0, item)
        Catch ex As Exception

        End Try

    End Sub
    Sub bind_dosage_form() 'รูปแบบยา
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

        'Dim dt As New DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_dosage_form_old()
        'ddl_dosage_form.DataSource = dt
        'ddl_dosage_form.DataTextField = "thadsgnm"
        'ddl_dosage_form.DataValueField = "dsgcd"
        'ddl_dosage_form.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_dosage_form.Items.Insert(0, item)
    End Sub
    Sub bind_drclass() 'ประเภทของยา
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

        'Dim dt As New DataTable
        'Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_drclass()
        'ddl_drclass.DataSource = dt
        'ddl_drclass.DataTextField = "thaclassnm"
        'ddl_drclass.DataValueField = "classcd"
        'ddl_drclass.DataBind()

    End Sub
    Sub bind_drkdofdrg()
        Dim dt As New DataTable
        Dim bao As New BAO_MASTER
        dt = bao.SP_drkdofdrg()

        rcb_drug_type.DataSource = dt
        rcb_drug_type.DataTextField = "thakindnm"
        rcb_drug_type.DataValueField = "kindcd"
        rcb_drug_type.DataBind()

        'Dim bao_master As New BAO_MASTER
        'Dim dt As New DataTable
        'dt = bao_master.SP_drkdofdrg()
        'ddl_drkdofdrg.DataSource = dt
        'ddl_drkdofdrg.DataTextField = "thakindnm"
        'ddl_drkdofdrg.DataValueField = "kindcd"
        'ddl_drkdofdrg.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_dosage_form.Items.Insert(0, item)
    End Sub
    ''' <summary>
    ''' รูปทรง
    ''' </summary>
    ''' <remarks></remarks>
    Sub bind_DRUG_SHAPE()
        Dim bao_master_2 As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        'dt = bao_master_2.SP_MAS_DRUG_SHAPE()
        ''ddl_shape.DataSource = dt
        ''ddl_shape.DataTextField = "SHAPE_NAME"
        ''ddl_shape.DataValueField = "SHAPE_IDA"
        ''ddl_shape.DataBind()
        'rcb_shape.DataSource = dt
        'rcb_shape.DataTextField = "SHAPE_NAME"
        'rcb_shape.DataValueField = "SHAPE_IDA"
        'rcb_shape.DataBind()

        'Dim item As New RadComboBoxItem
        'item.Text = "-"
        'item.Value = "0"
        'rcb_shape.Items.Insert(0, item)

    End Sub
    ''' <summary>
    ''' หน่วยนับตามบรรจุภัณฑ์
    ''' </summary>
    ''' <remarks></remarks>
    Sub bind_ddl_packaging()
        'Dim dao As New DAO_DRUG.TB_MAS_DRUG_PACKAGING
        'dao.GetDataAll()
        ''ddl_packaging.DataSource = dao.datas
        ''ddl_packaging.DataTextField = "PACKAGING_NAME"
        ''ddl_packaging.DataValueField = "UOP_CODE"
        ''ddl_packaging.DataBind()

        'rcb_packaging.DataSource = dao.datas
        'rcb_packaging.DataTextField = "PACKAGING_NAME"
        'rcb_packaging.DataValueField = "UOP_CODE"
        'rcb_packaging.DataBind()

        'Dim item As New RadComboBoxItem
        'item.Text = "-"
        'item.Value = "0"
        'rcb_packaging.Items.Insert(0, item)
    End Sub
    ''' <summary>
    ''' หน่วยนับทางชีวภาพ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub bind_ddl_bio_unit()
        'Dim dao As New DAO_DRUG.TB_MAS_BIO_UNIT
        'dao.GetDataALL()
        ''ddl_bio_pack.DataSource = dao.datas
        ''ddl_bio_pack.DataTextField = "BIO_UNIT"
        ''ddl_bio_pack.DataValueField = "IDA"
        ''ddl_bio_pack.DataBind()

        'rcb_bio_pack.DataSource = dao.datas
        'rcb_bio_pack.DataTextField = "BIO_UNIT"
        'rcb_bio_pack.DataValueField = "BIO_ID"
        'rcb_bio_pack.DataBind()

        'Dim item As New RadComboBoxItem
        'item.Text = "-"
        'item.Value = "0"
        'rcb_bio_pack.Items.Insert(0, item)
    End Sub
    ''' <summary>
    ''' หน่วยนับตามรูปของแบบยา
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub bind_ddl_small_unit()
        'Dim bao As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        'dt = bao.SP_DRUG_UNIT_PHYSIC()
        ''ddl_small_unit.DataSource = dt
        ''ddl_small_unit.DataTextField = "unit_name"
        ''ddl_small_unit.DataValueField = "sunitcd"
        ''ddl_small_unit.DataBind()

        'rcb_small_unit.DataSource = dt
        'rcb_small_unit.DataTextField = "unit_name"
        'rcb_small_unit.DataValueField = "sunitcd"
        'rcb_small_unit.DataBind()

        'Dim item As New RadComboBoxItem
        'item.Text = "-"
        'item.Value = "0"
        'rcb_small_unit.Items.Insert(0, item)
    End Sub
    Sub update_data(ByVal IDA As Integer)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(IDA)

        Dim old_data As String = ""
        Dim new_data As String = ""
        old_data = "ประเภทของยา :" & dao.fields.classcd & ", หมวดยา : " & dao.fields.ctgcd & ", รูปแบบยา : " & dao.fields.dsgcd & ", ชื่อการค้า (ภาษาไทย) : " & dao.fields.thadrgnm & ", ชื่อการค้า (ภาษาอังกฤษ) : " & _
            dao.fields.engdrgnm & " ,ชนิดยา : " & dao.fields.kindcd & ", รูปทรง : " & dao.fields.DRUG_STYLE & ", หน่วยนับตามรูปของแบบยา : " & dao.fields.UNIT_NORMAL & _
            " ,ความแรง : " & dao.fields.DRUG_STRENGTH & " , หน่วยนับทางชีวภาพ : " & dao.fields.UNIT_BIO & " ,หน่วยนับตามบรรจุภัณฑ์ : " & dao.fields.DRUG_PACKING
        new_data = "ประเภทของยา :" & rcb_drclass.SelectedValue & ", หมวดยา : " & rcb_dactg.SelectedValue & ", รูปแบบยา : " & rcb_drdosage.SelectedValue & " ,ชนิดยา : " & rcb_drug_type.SelectedValue & ", รูปทรง : " & dao.fields.DRUG_STYLE '& ", หน่วยนับตามรูปของแบบยา : " & rcb_small_unit.SelectedValue '& _
        '" , หน่วยนับทางชีวภาพ : " & rcb_bio_pack.SelectedValue & " ,หน่วยนับตามบรรจุภัณฑ์ : " & rcb_packaging.SelectedValue
        If rcb_drclass.SelectedValue <> "0" Then
            dao.fields.classcd = rcb_drclass.SelectedValue
        End If
        If rcb_dactg.SelectedValue <> "0" Then
            dao.fields.ctgcd = rcb_dactg.SelectedValue
        End If
        If rcb_drdosage.SelectedValue <> "0" Then
            dao.fields.dsgcd = rcb_drdosage.SelectedValue
        End If
        Try
            If rcb_drug_type.SelectedValue <> "0" Then
                dao.fields.kindcd = rcb_drug_type.SelectedValue
            End If

        Catch ex As Exception

        End Try
        ''หน่วยนับชีวะภาพ
        'Try
        '    If rcb_bio_pack.SelectedValue <> "0" Then
        '        dao.fields.UNIT_BIO = rcb_bio_pack.SelectedValue
        '    End If

        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามรูปของแบบยา
        'Try
        '    If rcb_small_unit.SelectedValue <> "0" Then
        '        dao.fields.UNIT_NORMAL = rcb_small_unit.SelectedValue
        '    End If
        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามบรรจุภัณฑ์
        'Try
        '    If rcb_packaging.SelectedValue <> "0" Then
        '        dao.fields.DRUG_PACKING = rcb_packaging.SelectedValue
        '    End If
        'Catch ex As Exception

        'End Try
        ''รูปทรง
        'Try
        '    If rcb_shape.SelectedValue <> "0" Then
        '        dao.fields.DRUG_STYLE = rcb_shape.SelectedValue
        '    End If

        'Catch ex As Exception

        'End Try


        Dim dao_rg2 As New DAO_DRUG.ClsDBdrrgt
        dao_rg2.GetDataby_IDA(IDA)
        Dim result As String = ""
        Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
        result = ""
        If Request.QueryString("e") <> "" Then
            result = "EDIT RQT"
        End If
        Try
            If Request.QueryString("e") = "" Then
                ws_drug.Timeout = 8000
                result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, _CLS.CITIZEN_ID)
            End If

        Catch ex As Exception

        End Try
        Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

        KEEP_LOGS_TABEAN_BC(dao_rg2.fields.pvncd, dao_rg2.fields.rgttpcd, dao_rg2.fields.drgtpcd, dao_rg2.fields.rgtno, dao_rg2.fields.IDA, _
                            dao_rg2.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)



        dao.update()


    End Sub
    Sub update_data_rqt(ByVal IDA As Integer)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(IDA)
        If rcb_drclass.SelectedValue <> "0" Then
            dao.fields.classcd = rcb_drclass.SelectedValue
        End If
        If rcb_dactg.SelectedValue <> "0" Then
            dao.fields.ctgcd = rcb_dactg.SelectedValue
        End If
        If rcb_drdosage.SelectedValue <> "0" Then
            dao.fields.dsgcd = rcb_drdosage.SelectedValue
        End If

        'dao.fields.thadrgnm = txt_thaname.Text
        'dao.fields.engdrgnm = txt_engname.Text
        Try
            If rcb_drug_type.SelectedValue <> "0" Then
                dao.fields.kindcd = rcb_drug_type.SelectedValue
            End If

        Catch ex As Exception

        End Try
        'Try
        '    dao.fields.DRUG_STRENGTH = txt_drug_str.Text
        'Catch ex As Exception

        'End Try
        'หน่วยนับชีวะภาพ
        'Try
        '    If rcb_bio_pack.SelectedValue <> "0" Then
        '        dao.fields.UNIT_BIO = rcb_bio_pack.SelectedValue
        '    End If

        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามรูปของแบบยา
        'Try
        '    If rcb_small_unit.SelectedValue <> "0" Then
        '        dao.fields.UNIT_NORMAL = rcb_small_unit.SelectedValue
        '    End If
        'Catch ex As Exception

        'End Try
        ''หน่วยนับตามบรรจุภัณฑ์
        'Try
        '    If rcb_packaging.SelectedValue <> "0" Then
        '        dao.fields.DRUG_PACKING = rcb_packaging.SelectedValue
        '    End If
        'Catch ex As Exception

        'End Try
        ''รูปทรง
        'Try
        '    If rcb_shape.SelectedValue <> "0" Then
        '        dao.fields.DRUG_STYLE = rcb_shape.SelectedValue
        '    End If

        'Catch ex As Exception

        'End Try
        dao.update()


    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class