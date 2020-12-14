Imports Telerik.Web.UI
Imports Telerik.Web.UI.Barcode
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml

Public Class WebForm20
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            txt_url.Text = "www.google.com"
            
            ' bind_DRUG_SHAPE()
            'SurroundingSub()
        End If
       
        Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim path As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim host As String = HttpContext.Current.Request.Url.Host
        'Dim bao_list As New BAO.ClsDBSqlcommand
        'Dim dt_list As New DataTable
        'dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL()
        'dt_list.Columns.Add("date_last", GetType(Date))
        'dt_list.Columns.Add("day_cal", GetType(Integer))



        ''For Each dr As DataRow In dt_list.Rows
        'Dim ws As New WS_GETDATE_WORKING.Service1
        'Dim date_should_be As Date
        'ws.GETDATE_WORKING(CDate("2552-10-30"), True, 480, True, date_should_be, True)
        ''date_result = date_result.ToLongDateString()
        'Dim daet_current As Date = CDate("2554-12-13")

        'Dim day As Integer = 0
        'day = DateDiff(DateInterval.Day, daet_current, date_should_be)
        'If day < 0 Then
        '    Dim holiday2 As Integer = 0
        '    ws = New WS_GETDATE_WORKING.Service1
        '    ws.GETDATE_COUNT_DAY(date_should_be, True, daet_current, True, holiday2, True)
        '    day += holiday2
        'End If
        'Dim aa As Integer = 0
        'Try
        '    aa = Get_BUDGET_YEAR()
        'Catch ex As Exception

        'End Try


    End Sub
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

    Private Sub SurroundingSub()
        rcb_shape.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem With {
            .Text = "-",
            .Value = "0"
        })
        rcb_shape.SelectedIndex = 0
    End Sub
    'Public Function ImageToByteArray(imageIn As System.Drawing.Image) As Byte()
    '    Using ms = New MemoryStream()
    '        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
    '        Return ms.ToArray()
    '    End Using
    'End Function
    Protected Sub applySettings(barcode As RadBarcode)
        barcode.QRCodeSettings.ECI = DirectCast([Enum].Parse(GetType(Modes.ECIMode), "NONE", True), Modes.ECIMode)
        barcode.QRCodeSettings.ErrorCorrectionLevel = DirectCast([Enum].Parse(GetType(Modes.ErrorCorrectionLevel), "L", True), Modes.ErrorCorrectionLevel)
        barcode.QRCodeSettings.Mode = DirectCast([Enum].Parse(GetType(Modes.CodeMode), "Byte", True), Modes.CodeMode)
        barcode.QRCodeSettings.Version = Integer.Parse(1)
        barcode.OutputType = DirectCast([Enum].Parse(GetType(BarcodeOutputType), BarcodeOutputType.EmbeddedPNG.ToString(), True), BarcodeOutputType)
        barcode.QRCodeSettings.DotSize = 8

        'barcode.QRCodeSettings.DotSize = -1 'Integer.Parse(1)
        'End If
    End Sub
    Protected Sub RadBarcode1_PreRender(sender As Object, e As EventArgs)

        RadBarcode1.Text = txt_url.Text
        applySettings(RadBarcode1)
        Dim image As System.Drawing.Image = RadBarcode1.GetImage()

        'image.Save("555", System.Drawing.Imaging.ImageFormat.Png)
        Dim data As Byte()
        'Using m As New MemoryStream()
        '    data = New Byte(m.Length - 1) {}
        '    m.Write(data, 0, data.Length)
        'End Using
        data = ImageToByteArray(image)
        'Dim str As String = 
        'RadBinaryImage1.DataValue = data

        Dim base64 As String = Convert.ToBase64String(data)
        'Dim data2 As Byte()
        Dim imgBin() As Byte = Convert.FromBase64String(base64)
        RadBinaryImage1.DataValue = imgBin

    End Sub
    Public Function Get_BUDGET_YEAR() As Integer
        Dim dt As New DataTable
        dt.Columns.Add("byear")
        Dim byearMax As Integer = Year(System.DateTime.Now)
        If byearMax < 2500 Then
            byearMax = byearMax + 543
        End If
        Dim aa As Date = CDate("1/10/" & byearMax)
        Dim date_now As Date = CDate(System.DateTime.Now)
        Dim dd As String = ""
        Dim mm As String = ""
        Dim yy As String = ""
        Try
            dd = Day(date_now)
        Catch ex As Exception

        End Try
        Try
            mm = Month(date_now)
        Catch ex As Exception

        End Try
        Try
            yy = Year(date_now)
            If yy < 2500 Then
                yy += 543
            End If
        Catch ex As Exception

        End Try
        Dim fulldate As String = ""
        Try
            fulldate = dd & "/" & mm & "/" & yy
        Catch ex As Exception
            fulldate = CDate(Date.Now).ToShortDateString
        End Try
        If CDate(fulldate) >= CDate("1/10/" & byearMax) Then
            byearMax = byearMax + 1
        End If

        Return byearMax
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ws As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim CITIZEN_ID_AUTHORIZE As String = "0115539007084"

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

        Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
        dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

        Dim LCNSID_CUSTOMER As String = dao_syslcnsid.fields.lcnsid



        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim fullname As String = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Dim THANM_CUSTOMER As String = fullname


        'Dim obj As Object = ws.getProfile_byidentify("0115539007084")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dt_ex As New DataTable
        dt_ex.Columns.Add("col1")
        dt_ex.Columns.Add("col2")
        For i As Integer = 1 To 17
            Dim dr As DataRow = dt_ex.NewRow
            dr("col1") = "ชื่อ " & i
            dr("col2") = "ที่อยู่ " & i
            dt_ex.Rows.Add(dr)
        Next
        Dim dt As New DataTable
        dt.Columns.Add("col1")
        dt.Columns.Add("col2")
        dt.Columns.Add("col3")
        dt.Columns.Add("col4")
        Dim c As Integer = 1
        Dim dt_ex_c As Decimal = 0
        Try
            dt_ex_c = dt_ex.Rows.Count / 2
            dt_ex_c = Math.Ceiling(dt_ex_c)
        Catch ex As Exception

        End Try
        For i As Integer = 0 To dt_ex.Rows.Count - 1 'dt_ex_c - 1
            Dim dr2 As DataRow = dt.NewRow()

            dr2("col1") = dt_ex(i)("col1")
            dr2("col2") = dt_ex(i)("col2")
            Try
                dr2("col3") = dt_ex(i + 1)("col1")
            Catch ex As Exception

            End Try
            Try
                dr2("col4") = dt_ex(i + 1)("col2")
            Catch ex As Exception

            End Try
            dt.Rows.Add(dr2)
            i += 1
        Next

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ddaa As DateTime = Date.Now 'CDate("2560-02-01")
        Dim ddbb As DateTime
        ddbb = ddaa.AddDays(-181)

    End Sub

    Private Sub QRQQQQ_Click(sender As Object, e As EventArgs) Handles QRQQQQ.Click
        RadBarcode1.DataBind()
        'Dim img1 As Drawing.Image = RadBarcode1.GetImage()

    End Sub
    Public Function ImageToByteArray(imageIn As System.Drawing.Image) As Byte()
        Using ms = New MemoryStream()
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Protected Sub txt_url_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_gen_xml_Click(sender As Object, e As EventArgs) Handles btn_gen_xml.Click
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.get_etack
        'Dim str_xml As String = ""
        'str_xml = gen_xml(dt)





        Dim cls_xml As New CLASS_OTHER_XML
        Dim cls As New CLASS_GEN_XML.OTHER_XML() 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN                                                                ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()
        cls_xml.DT_SHOW.DT1 = dt
        cls_xml.DT_SHOW.DT1.TableName = "DRUG_ETRACKING"
        Dim bao_app As New BAO.AppSettings
        Dim filename As String = "XML_DRUG"
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)                                                         'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                           'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub
    Function gen_xml(ByVal dt As DataTable) As String
        'Dim cls_xml As New CLASS_DALCN
        Dim str As String = ""
        str = SerializeObject(dt, "XML_DRUG")

        Return str
    End Function

    Function SerializeObject(ByVal dt As DataTable, ByVal dt_name As String) As String
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        ds.Tables(0).TableName = dt_name
        Dim xmlSerializer As New XmlSerializer(ds.GetType)
        Using textWriter As New StringWriter()
            xmlSerializer.Serialize(textWriter, ds)
            Return textWriter.ToString()
        End Using
    End Function
    Public Sub GEN_DH_NO(ByVal IDA As Integer)
        Dim dao2 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
        dao2.GetDataby_FK_IDA(IDA)
        Dim chem_dgt As String = ""
        Try
            chem_dgt = dao2.fields.phm15dgt
        Catch ex As Exception

        End Try
        Dim dao As New DAO_DRUG.ClsDBdh15rqt
        dao.GetDataby_IDA(IDA)
        Dim _ProcessID As Integer = 0
        Dim stat As Integer = 0
        Try
            stat = dao.fields.STATUS_ID
        Catch ex As Exception

        End Try
        'If stat <> 8 Then
        'If Len(Trim(chem_dgt)) = 0 Then

        Try
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tr.GetDataby_IDA(dao.fields.TR_ID)
            _ProcessID = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try
        For Each dao2.fields In dao2.datas
            Dim dao_cas As New DAO_DRUG.TB_MAS_CHEMICAL
            dao_cas.GetDataby_IDA(dao2.fields.CAS_ID)


            Dim bao As New BAO.GenNumber 'test
            Dim run_number As String = ""
            run_number = bao.GEN_DH15TDGT_NO(con_year(Date.Now.Year), dao_cas.fields.aori, _ProcessID, IDA, dao2.fields.IDA, dao.fields.QUOTA_TYPE)

            Dim dao3 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
            dao3.GetDataby_IDA(dao2.fields.IDA)
            dao3.fields.phm15dgt = run_number
            dao3.update()

        Next
        dao.fields.STATUS_ID = 8
        dao.update()
        'End If
        'End If
    End Sub

    Private Sub btn_gendh_Click(sender As Object, e As EventArgs) Handles btn_gendh.Click
        GEN_DH_NO(txt_dh_id.Text)
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        If FileUpload1.HasFile Then
            Dim file_ex As String = ""
            file_ex = file_extension_nm(FileUpload1.FileName)
            If file_ex = "jpg" Or file_ex = "png" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(1)
                dao.fields.IMAGE_BSN = Convert.ToBase64String(FileUpload1.FileBytes)
                dao.update()

            End If
        Else

        End If
    End Sub

    Private Sub WebForm20_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Dim dao_ya As New DAO_DRUG.ClsDBdalcn
        'dao_ya.GetDataby_IDA(1)
        ''Dim img As System.Drawing.Image
        ''img =
        'Try
        '    RadBinaryImage2.DataValue = Convert.FromBase64String(dao_ya.fields.IMAGE_BSN)
        '    RadBinaryImage2.ResizeMode = BinaryImageResizeMode.Fit
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub btn_check_date_Click(sender As Object, e As EventArgs) Handles btn_check_date.Click
        'Chk_date(TextBox2.Text)
        CHK_UPDATE()
    End Sub
    Function Chk_date(ByVal str_date As String) As Boolean
        Dim bool As Boolean = True
        Dim Temp_date As Date
        Dim date_split As String()
        Try
            Temp_date = CDate(str_date)

            date_split = str_date.ToString.Split("/")
            If Len(date_split(2)) < 4 Then
                bool = False
            End If
        Catch ex As Exception
            bool = False
        End Try

        Return bool
    End Function

    Function CHK_UPDATE() As Boolean
        Dim bool As Boolean = True
        Dim bool_s As Boolean = Chk_date(TextBox2.Text)
        Dim bool_e As Boolean = Chk_date(TextBox3.Text)

        If bool_s = True And bool_e = True Then
            bool = True
        ElseIf bool_s = True And bool_e = False Then
            bool = True
        ElseIf bool_s = False Then
            bool = False
        ElseIf bool_s = False And bool_e = False Then
            bool = False
        End If

        Return bool
    End Function

    Protected Sub btn_day_Click(sender As Object, e As EventArgs) Handles btn_day.Click
        Bind_Date()
    End Sub
    Sub Bind_Date()
        Dim ws As New WS_GETDATE_WORKING.Service1
        Dim date_result As Date
        ws.GETDATE_WORKING(CDate(txt_date.Text), True, txt_number.Text, True, date_result, True)
        lbl_number_day.Text = date_result.ToLongDateString()
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim url As String = ""
        url = "http://10.111.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN="
        ' Response.Redirect(url)
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "window.location.href ='" & url & "';", True)
    End Sub
End Class
