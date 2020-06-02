Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization

Public Class RM_LCN_LCT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _type As String
    Private _ProcessID As Integer
    Private _ProcessID_KEEP As Integer
    Private _lcn_ida As String

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _type = Request.QueryString("type")
                _lcn_ida = Request.QueryString("lcn_ida")
                'Dim bao As New BAO.PROCESS
                '_ProcessID = bao.GET_PROCESS_ID(_type, "00") ' ProcessID สถานที่ตั้ง
                _ProcessID = 99
                _ProcessID_KEEP = 98 'ProcessID สถานที่เก็บ 
            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'Dim UC As UC_NODE_NEW = Page.Master.FindControl("UC_NODE_NEW1")
            'UC.BindNode("00", 1, 0)

        End If
    End Sub

    ''' <summary>
    ''' ฟังชั่นเปิดหน้า Popup
    ''' </summary>
    ''' <param name="url"></param>
    ''' <remarks></remarks>
    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub

    ''' <summary>
    ''' เมื่อกดปุ่ม upload จะเปิดหน้าให้ อัพโหลด
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('POPUP_LCN_LCT_UPLOAD.aspx?type=" & _type & "');", True) 'เปิดหน้า uplaod
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid1.DataSource = bao.SP_CUSTOMER_DALCN_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(1, _CLS.CITIZEN_ID_AUTHORIZE) 'เรียกใช้เพื่อดึงข้อมูลสถานที่ตั้ง
    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        RadGrid2.DataSource = bao.SP_CUSTOMER_DALCN_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(2, _CLS.CITIZEN_ID_AUTHORIZE) 'เรียกใช้เพื่อดึงข้อมูลสถานที่เก็บ
    End Sub


#Region "เก็บ ดาว อัพ ไว้ก่อน"
    ' ''' <summary>
    ' ''' กดปุ่ม ดาวโหลด
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('POPUP_LCN_LCT_INSERT.aspx?iden=" & _CLS.CITIZEN_ID_AUTHORIZE & "');", True)
        'BindPDF() 'สร้าง PDF
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True) 'สั่งให้ขึ้น หน้าต่างแจ้งเตือนและซ่อนรูป สปินเนอร์
    End Sub


    ' ''' <summary>
    ' ''' สร้างPDF ที่ตั้ง
    ' ''' </summary>
    ' ''' <remarks></remarks>
    Private Sub BindPDF()
        Dim bao As New BAO.DOWNLOAD_TRANSECTION
        bao.CITIZEN_ID = _CLS.CITIZEN_ID
        bao.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        Dim down_ID As Integer = bao.insert_transection(_ProcessID) ' สร้างเลข DOWNLOAD_TRANSECTION

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE(_ProcessID, 0, 0, 0) 'หา  PDF TEMPLAETE


        Dim paths As String = _PATH_DEFALUT

        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE 'ระบุ PDF TEMPLAETE
        Dim PATH_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_DOWNLOAD("DA", _ProcessID, con_year(Date.Now.Year), down_ID) 'สร้างชื่อ PDF 
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_DOWNLOAD("DA", _ProcessID, con_year(Date.Now.Year), down_ID) 'สร้างชื่อ XML

        CREATE_XML(Path_XML, down_ID) 'ทำการสร้าง XML 
        convert_XML_To_PDF(PATH_PDF, Path_XML, PDF_TEMPLATE) 'ทำการนำ XML เข้าไปใส่ที่ PDF
        _CLS.FILENAME_PDF = PATH_PDF 'ที่อยู่ไฟล์ PDF เพื่อดาวโหลด
        _CLS.FILENAME_PDF_DOWNLOAD = NAME_DOWNLOAD_PDF("DA", down_ID) 'ชื่อที่ตั้งให้ PDF
        Session("CLS") = _CLS 'เก็บใน Session

    End Sub
    ' ''' <summary>
    ' ''' สร้างPDF ที่เก็บ
    ' ''' </summary>
    ' ''' <remarks></remarks>
    Private Sub BindPDF_KEEP()
        Dim bao As New BAO.DOWNLOAD_TRANSECTION
        bao.CITIZEN_ID = _CLS.CITIZEN_ID
        bao.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        Dim down_ID As Integer = bao.insert_transection(_ProcessID) ' สร้างเลข DOWNLOAD_TRANSECTION

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_GROUP(_ProcessID_KEEP, 0, 0, 0, 0) 'หา  PDF TEMPLAETE

        Dim paths As String = _PATH_DEFALUT

        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE 'ระบุ PDF TEMPLAETE
        Dim PATH_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_DOWNLOAD("DA", _ProcessID, con_year(Date.Now().Year()), down_ID) 'สร้างชื่อ PDF 
        Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_DOWNLOAD("DA", _ProcessID, con_year(Date.Now().Year()), down_ID) 'สร้างชื่อ XML

        CREATE_XML(Path_XML, down_ID) 'ทำการสร้าง XML 
        convert_XML_To_PDF(PATH_PDF, Path_XML, PDF_TEMPLATE) 'ทำการนำ XML เข้าไปใส่ที่ PDF
        _CLS.FILENAME_PDF = PATH_PDF 'ที่อยู่ไฟล์ PDF เพื่อดาวโหลด
        _CLS.FILENAME_PDF_DOWNLOAD = NAME_DOWNLOAD_PDF("DA", down_ID) 'ชื่อที่ตั้งให้ PDF
        Session("CLS") = _CLS 'เก็บใน Session

    End Sub

    ' ''' <summary>
    ' ''' สร้าง ไฟล์ XML
    ' ''' </summary>
    ' ''' <param name="PATH_XML"></param>
    ' ''' <remarks></remarks>
    Private Sub CREATE_XML(ByVal PATH_XML As String, ByVal DownID As Integer)
        Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
        Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE

        Dim Cls_NCT_LCT As New Gen_XML.GEN_XML_NCT_LCT_ADDR
        Cls_NCT_LCT.IDA = 0
        Cls_NCT_LCT.LCNSID = _CLS.LCNSID_CUSTOMER
        Cls_NCT_LCT.lcntpcd = _type
        Cls_NCT_LCT.CITIZEN_ID = _CLS.CITIZEN_ID
        Cls_NCT_LCT.CITIZEN_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        Cls_NCT_LCT.PVNCD = _CLS.PVCODE

        Dim cls_xml As New CLS_LOCATION
        cls_xml = Cls_NCT_LCT.gen_xml_nct_lctaddr()
        cls_xml.CITIZEN_ID = _CLS.CITIZEN_ID
        cls_xml.DOWNLOAD_ID = DownID
        cls_xml.lcntpcd = _type


        '_______________SHOW___________________

        Dim bao_show As New BAO_SHOW
        Try

            cls_xml.DT_SHOW.DT1 = bao_show.SP_MAINPERSON_CTZNO(_CLS.CITIZEN_ID) 'ชื่อผู้ ทำ PDF
        Catch ex As Exception

        End Try

        cls_xml.DT_SHOW.DT5 = bao_show.SP_SP_SYSTHMBL() 'ตำบล ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT6 = bao_show.SP_SP_SYSAMPHR() 'อำเภอ ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT7 = bao_show.SP_SP_SYSCHNGWT() 'จังหวัด ไว้ใส่ ดรอปดาว

        cls_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX() 'คำนำหน้า ไว้ใส่ ดรอปดาว
        cls_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(LCNSID) 'bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, LCNSID) 'สถานที่หลัก
        cls_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(CITIZEN_ID_AUTHORIZE, LCNSID) 'ชื่อและข้อมูลผู้ประกอบการ
        cls_xml.SHOW_THAI_birthdate = " "

        Dim objStreamWriter As New StreamWriter(PATH_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.FILENAME_PDF_DOWNLOAD)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub


    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        Dim bao As New BAO.ClsDBSqlcommand
        ' RadGrid1.DataSource = bao.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(1, _CLS.LCNSID_CUSTOMER)
        RadGrid1.DataSource = bao.SP_CUSTOMER_DALCN_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(1, _CLS.CITIZEN_ID_AUTHORIZE)
        RadGrid1.DataBind()

        RadGrid2.DataSource = bao.SP_CUSTOMER_DALCN_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(2, _CLS.CITIZEN_ID_AUTHORIZE)
        'RadGrid2.DataSource = bao.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_LCNSID(2, _CLS.LCNSID_CUSTOMER)
        RadGrid2.DataBind()
    End Sub

    Protected Sub btn_download_2_Click(sender As Object, e As EventArgs) Handles btn_download_2.Click
        BindPDF_KEEP()
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub

    Protected Sub btn_upload_2_Click(sender As Object, e As EventArgs) Handles btn_upload_2.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('POPUP_LCN_LCT_KEEP_UPLOAD.aspx?type=" & _type & "');", True)
    End Sub
#End Region

#Region "RUN CONTROL"
    Protected Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            If e.CommandName = "sel" Then
                Dim item As GridDataItem
                item = e.Item
                Dim IDA As Integer = item("IDA").Text
                Dim TR_ID As String = item("TR_ID").Text
                _CLS.IDA = IDA
                Session("CLS") = _CLS
                Response.Redirect("../MAIN/FRM_LCN_NEWS.aspx?lct_ida=" & IDA)

            End If
        End If
    End Sub

    ''' <summary>
    ''' ใส่ URL ที่ ดูข้อมูล สถานที่ตั้ง
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID As String = item("TR_ID").Text


            Dim l_btn_view As LinkButton = DirectCast(item("view").Controls(0), LinkButton)
            Dim btn As LinkButton = DirectCast(item("sel").Controls(0), LinkButton)

            'H.Attributes.Add("onclick", "Popups2('" & "POPUP_LCN_LCT_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&type=" & _type & "');") 'URL หน้า ยืนยัน
            'l_btn_view.Attributes.Add("onclick", "Popups2('" & "POPUP_LCN_LCT_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&type=" & _type & "'); return false;")
            l_btn_view.Attributes.Add("onclick", "Popups2('" & "POPUP_LCN_LCT_INSERT.aspx?IDA=" & IDA & "'); return false;")
            btn.Style.Add("display", "none")
            Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            Try
                dao.GetDataby_IDA(IDA)

                If dao.fields.STATUS_ID = 8 Then
                    btn.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub

    ''' <summary>
    ''' ใส่ URL ที่ ดูข้อมูล สถานที่เก็บ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub RadGrid2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text
            Dim TR_ID As String = item("TR_ID").Text
            'Dim H As LinkButton = e.Item.FindControl("view1")
            Dim btn As LinkButton = DirectCast(item("view1").Controls(0), LinkButton)

            'btn.Attributes.Add("onclick", "Popups2('" & "POPUP_LCN_LCT_KEEP_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & TR_ID & "&type=98');return false;") 'ใส่ URL ปุ่่ม ดูข้อมมูล
            btn.Attributes.Add("onclick", "Popups2('" & "POPUP_LCN_LCT_INSERT.aspx?IDA=" & IDA & "'); return false;")


        End If
    End Sub
#End Region
End Class