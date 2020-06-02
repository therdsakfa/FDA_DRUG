Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports Telerik.Web.UI

Public Class UC_DS_DOWNLOAD
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            set_label()
        End If

    End Sub

    Sub xml()
        Dim get_session As CLS_SESSION = Session("product_id")

        Dim cls_xml As New CLASS_DRSAMP


        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_product(get_session.IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.LCN_IDA)
        Dim bao_show As New BAO_SHOW
        Dim bao As New BAO.ClsDBSqlcommand

        Dim path_XML As String = "C:\path\DRUG\XML_TRADER_DOWNLOAD\Product_ID_" + dao.fields.LCNNO_DISPLAY + ".xml"
        Dim file_PDF As String = "C:\path\DRUG\PDF_TRADER_DOWNLOAD\Product_ID_" + dao.fields.LCNNO_DISPLAY + ".pdf"
        Dim file_template As String = ""
        Dim process As String = ""
        If get_session.PVCODE = "2" Then
            file_template = "C:\path\DRUG\PDF_TEMPLATE\PDF_DRUG_NORYORMOR2.pdf"
            process = "1027"
        ElseIf get_session.PVCODE = "3" Then
            file_template = "C:\path\DRUG\PDF_TEMPLATE\PDF_DRUG_NORYORMOR3.pdf"
            process = "1028"
        ElseIf get_session.PVCODE = "4" Then
            file_template = "C:\path\DRUG\PDF_TEMPLATE\PDF_DRUG_NORYORMOR4.pdf"
            process = "1029"
        End If

        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao.fields.IDA)


        cls_xml = GEN_XML()

        cls_xml.drsamp = dao_drsamp.fields  'ใบนยม
        cls_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(dao.fields.IDA) 'ดึงบัญชีรายการยา
        cls_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(dao.fields.LCN_IDA)    'ข้อมูลที่อยู่สถาณที่
        cls_xml.DT_SHOW.DT3 = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(dao.fields.IDA) 'ดึงตัวยาสำคัญ
        cls_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(dao.fields.FK_IDA)    'ขนาดบรรจุ
        cls_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(dao.fields.IDA) 'ใบนยม
        cls_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM2(dao.fields.IDA) 'เก็บตกหล่น
        Try
            cls_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA) 'ผู้ดำเนิน
        Catch ex As Exception

        End Try



        Dim objStreamWriter As New StreamWriter(path_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        convert_XML_To_PDF(file_PDF, path_XML, file_template)

        Dim pdf_name As String = process + "-" + get_session.IDA

        _CLS.FILENAME_PDF = file_PDF                                                                                                ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", pdf_name)


        Session("CLS") = _CLS

        LoadPdf()

    End Sub

    Public Function GEN_XML() As CLASS_DRSAMP
        Dim class_xml As New CLASS_DRSAMP

        Return class_xml

    End Function

    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('Download เสร็จสิ้น');", True)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    ''' <summary>
    ''' ใส่ค่าในฟิลที่ null
    ''' </summary>
    ''' <param name="ob"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Function AddValue(ByVal ob As Object) As Object
        Dim props As System.Reflection.PropertyInfo
        For Each props In ob.GetType.GetProperties()

            '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
            Dim p_type As String = props.PropertyType.ToString()
            If props.CanWrite = True Then
                If p_type.ToUpper = "System.String".ToUpper Then
                    props.SetValue(ob, " ", Nothing)
                ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.Double".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.float".ToUpper Then
                    props.SetValue(ob, 0, Nothing)
                ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                    props.SetValue(ob, Date.Now, Nothing)
                Else
                    Try
                        props.SetValue(ob, 0, Nothing)
                    Catch ex As Exception
                        props.SetValue(ob, Nothing, Nothing)
                    End Try


                End If
            End If

            'prop.SetValue(cls1, "")
            'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
        Next props

        Return ob
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button3.Click
        xml()
    End Sub

    Protected Sub Button2_Click1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim get_session As CLS_SESSION = Session("product_id")

        If get_session.PVCODE = "2" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1027 & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "3" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1028 & "';")
            Response.Write("</script type >")
        ElseIf get_session.PVCODE = "4" Then
            Response.Write("<script type langue =javascript>")
            Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & 1029 & "';")
            Response.Write("</script type >")
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(lcnno As Integer)
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        Try
            dt = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(lcnno)
        Catch ex As Exception

        End Try

        RadGrid1.DataSource = dt

        RadGrid1.Rebind()
    End Sub


    Public Sub set_label()

        Dim get_session As CLS_SESSION = Session("product_id")

        Dim dao_drugname As New DAO_DRUG.TB_DRUG_PRODUCT_ID 'ชื่อยา
        dao_drugname.GetDataby_product(get_session.IDA)
        lbl_drugthanm.Text = dao_drugname.fields.TRADE_NAME '+ " " + dao_drugname.fields.TRADE_NAME_ENG 'ชื่อยาอังกฤษ + ชื่อยาไทย
        lbl_drugengnm.Text = dao_drugname.fields.TRADE_NAME_ENG
        lbl_nature.Text = dao_drugname.fields.DRUG_NATURE
        lbl_DOSAGE.Text = dao_drugname.fields.STRENGTH_DRUG

        Dim unit_physic As New DAO_DRUG.TB_DRUG_UNIT
        unit_physic.GetDataby_IDA(dao_drugname.fields.PHYSIC_UNIT)
        lbl_unitnm.Text = unit_physic.fields.unit_name
        lbl_unite_ida.Text = dao_drugname.fields.PHYSIC_UNIT    'สร้าง hidden field ไว้เก็บ ida หน่วยยาสำคัญ
        lbl_unit.Text = unit_physic.fields.unit_name

        '-------------------------------------drsamp------------------------------------------
        Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
        dao_drsamp.GetDataby_PRODUCT_ID_IDA(dao_drugname.fields.IDA)

        lbl_date.Text = dao_drsamp.fields.WRITE_DATE
        Try
            lbl_inname.Text = dao_drsamp.fields.IN_NAME.ToString.Substring(1)
        Catch ex As Exception
            lbl_inname.Text = "-"
        End Try
        lbl_rank.Text = dao_drsamp.fields.RANK
        lbl_product_id.Text = get_session.IDA
        lbl_write_at.Text = dao_drsamp.fields.WRITE_AT
        '--------------------------------------------------------------------------------------

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao_drugname.fields.LCN_IDA)

        lbl_lcnno.Text = dao_lcn.fields.lcntpcd + " " + dao_lcn.fields.LCNNO_DISPLAY

        lbl_number.Text = dao_lcn.fields.BSN_ADDR            'ที่อยู่
        lbl_place_name.Text = dao_lcn.fields.LOCATION_ADDRESS_thanameplace   'สถานที่ผลิต / นำสั่ง
        lbl_lane.Text = dao_lcn.fields.BSN_SOI               'ซอย
        lbl_road.Text = dao_lcn.fields.BSN_ROAD              'ถนน
        lbl_village_no.Text = dao_lcn.fields.BSN_MOO       'หมู่
        lbl_sub_district.Text = dao_lcn.fields.BSN_THMBL_NAME   'ตำบล
        lbl_district.Text = dao_lcn.fields.BSN_AMPHR_NAME       'อำเภอ
        lbl_province.Text = dao_lcn.fields.BSN_CHWNGNAME      'จังหวัด
        lbl_tel.Text = dao_lcn.fields.BSN_TELEPHONE            'เบอร์โทร

        Dim dao_prefix As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
        dao_prefix.Getdata_byid(dao_lcn.fields.syslcnsnm_prefixcd)
        lbl_lcnsnm.Text = dao_prefix.fields.thanm & dao_lcn.fields.syslcnsnm_thanm & " " & dao_lcn.fields.syslcnsnm_thalnm 'ชื่อผู้รับอนุญาต
        Dim dao_prefix2 As New DAO_CPN.TB_sysprefix 'คำนำหน้าชื่อ
        dao_prefix2.Getdata_byid(dao_lcn.fields.syslcnsnm_lcnscd)
        lbl_bsn_name.Text = dao_prefix2.fields.thaabbr & dao_lcn.fields.BSN_THAIFULLNAME 'ชื่อดำเนินกิจการ

        'ดึงตัวยาสำคัญ
        'fix ค่า 0 เพราะยังไม่มีตัวยาสำคัญหมวด นยม ในเบส
        RadGrid1_NeedDataSource(dao_drugname.fields.IDA)
        'ขนาดบรรจุ
        Size_Radgrid(dao_drugname.fields.FK_IDA)

    End Sub

    Public Sub Size_Radgrid(ByVal ida As Integer)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As DataTable = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(ida)

        RadGrid2.DataSource = dt
        RadGrid2.Rebind()
    End Sub



End Class

