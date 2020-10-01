Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_DP_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
   Private _IDA As String = ""
    Private _FK_IDA As String = ""
    Private _ProcessID As String = "" 'ประกาศชื่อตัวแปร _process
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _FK_IDA = Request.QueryString("FK_IDA")
        _ProcessID = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                runQuery()
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        load_lcnno()
        If Not IsPostBack Then
            load_GV_data()
        End If

    End Sub
    Sub load_lcnno()
        lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Sub load_GV_data()                              ' Gridview นำมาโชว์
        Dim bao_DB As New BAO.ClsDBSqlcommand       'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao_DB.SP_DRPCB_BY_IDA(_IDA)                'เรียกใช้ SP  bao.SP_DRPCB_BY_IDA
        GV_data.DataSource = bao_DB.dt              'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_data.DataBind()                          'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF("PDF_DRUG_DP.pdf")
    End Sub


    Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer



        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = 7
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        'Dim dao As New DAO.clsDBfafdtype
        'dao.Getdata_by_fdtypecd(_CLS.FDTYPECD)

        '    _CLS.FATYPE = FATYPE

        Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)                             'เพื่อเก็บไฟล์ TEMPLATE PATH XML


        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE                                         'ค้นหาที่เก็บของไฟล์ _PATH_PDF_TEMPLATE
        Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID)                         'เพื่อเก็บไฟล์ TEMPLATE PATH PDF

        convert_Database_To_XML("DA-" & down_ID.ToString())                                                             ' Gen XML
        convert_XML_To_PDF(file_PDF, file_xml, file_template)                                                           ' XML PDF รวมกัน 

        _CLS.FILENAME_PDF = file_PDF                                                                                    ' โหลดไฟล์ PDF ลงไฟล์
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)  'จาวา .Gif
    End Sub
    Private Sub convert_Database_To_XML(ByVal filename As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Integer.Parse(_FK_IDA))

        Dim cls As New CLASS_GEN_XML.DP(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, "1", dao.fields.pvncd, dao.fields.IDA) 'ประกาศตัวแปร cls จาก CLASS_GEN_XML.DALCN
        Dim cls_xml As New CLASS_DP                                                                                     ' ประกาศตัวแปรจาก CLASS_DALCN 
        cls_xml = cls.gen_xml()                                                                                         'cls_xml ให้เท่ากับ Class ของ cls.gen_xml

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)                                                                   'ประกาศตัวแปร
        Dim x As New XmlSerializer(cls_xml.GetType)                                                                     'ประกาศ
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings                          'ทำการดาวห์โหลดลงเครื่อง
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

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrpcb

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DI_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_data()
    End Sub
End Class