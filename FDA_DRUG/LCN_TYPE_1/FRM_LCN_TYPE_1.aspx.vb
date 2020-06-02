Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports System.Xml
Public Class WebForm1
    Inherits System.Web.UI.Page
    Private _lcnsid As Integer
    Private _thanm As String
    Private _CITIEZEN_ID As String
    Private _CITIEZEN_ID_AUTHORIZE As String

    Private _PATH_PDF_TEMPLATE As String
    Private _PATH_XML_CLASS As String
    Private _PATH_PDF_XML_CLASS As String
    Private _PATH_PDF_TRADER As String
    Private _PATH_XML_TRADER As String
    Sub RunAppSettings()
        _PATH_PDF_TEMPLATE = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TEMPLATE")
        _PATH_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_CLASS")
        _PATH_PDF_XML_CLASS = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_XML_CLASS")
        _PATH_PDF_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_PDF_TRADER")
        _PATH_XML_TRADER = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_TRADER")
    End Sub

    Sub RunSession()

        _CITIEZEN_ID = Session("CITIEZEN_ID").ToString()
        _lcnsid = Integer.Parse(Session("strlcnsid").ToString())
        _thanm = Session("strthanm").ToString()
        _CITIEZEN_ID_AUTHORIZE = Session("CITIEZEN_ID_AUTHORIZE")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            RunSession()
            RunAppSettings()
            load_GV_lcnno()
            'load_ddl()
        End If

    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        OpenPopupName("POPUP_LCN_TYPE_1.aspx")
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        ' Runcomno()
        Dim pdf As New PDF_System
        pdf.insert_TRANSESSION_DOWNLOAD(2)
        convert_Database_To_XML()
        'Dim PDF_System As PDF_System
        'PDF_System.insert_Transession(1)
        fusion_XML_To_PDF(_PATH_XML_CLASS, "PDFdalcn")

    End Sub
   
    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()
        Dim bao As New BAO.ClsDBSqlCommand
        'bao.SP_MEMBER_LCNSID_FULLADDR(_lcnsid)
        'ใส่ SP
        bao.GetDataby_lcnsid_dalcn(_lcnsid)
        GV_lcnno.DataSource = bao.dt
        GV_lcnno.DataBind()
    End Sub
   
    ''' <summary>
    ''' แปลงค่าจากDatabase เป็น XML
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub convert_Database_To_XML()


        Dim cls As New CLASS_DALCN
        Dim WS_CENTER_CLC_NAMES As New WS_CENTER.CLC_NAMES
        'Dim WS_CENTER As New WS_CENTER.WS_CENTER

        Dim WS_CENTER_systhmbl As New WS_CENTER.CLC_THMBLCD
        Dim WS_CENTER_sysamphr As New WS_CENTER.CLC_AMPHRCD
        Dim WS_CENTER_syschngwt As New WS_CENTER.CLC_CHAWTCD
        Dim WS_CENTER As New WS_CENTER.WS_CENTER
        Dim WS_LGTDRUG As New WS_LGTDRUG.WS_LGTDRUG
        ' Dim WS_LGTFOOD2 As New WS_LGTFOOD2.WS_LGTFOOD
        'ที่อยู่ติดต่อได้
        Dim WS_CENTER_SYSADDR_CONTACT As New WS_CENTER.CLC_SYSADDR_CONTACT
        WS_CENTER_SYSADDR_CONTACT = WS_CENTER.GET_ADDR_CONTACT(_CITIEZEN_ID) 'test
        WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.thumbolcd))
        WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd))
        WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd))
        cls.name = WS_CENTER_SYSADDR_CONTACT.name
        cls.citiz_no = WS_CENTER_SYSADDR_CONTACT.citiz_no
        cls.room = WS_CENTER_SYSADDR_CONTACT.room
        cls.floor = WS_CENTER_SYSADDR_CONTACT.floor
        cls.building = WS_CENTER_SYSADDR_CONTACT.building
        cls.number_addr = WS_CENTER_SYSADDR_CONTACT.number_addr
        cls.moo = WS_CENTER_SYSADDR_CONTACT.moo
        cls.soi = WS_CENTER_SYSADDR_CONTACT.soi
        cls.road = WS_CENTER_SYSADDR_CONTACT.road
        cls.thmbolcd = WS_CENTER_systhmbl.thathmblnm
        cls.districtcd = WS_CENTER_sysamphr.thaamphrnm
        cls.provincecd = WS_CENTER_syschngwt.thachngwtnm
        cls.zipcode = WS_CENTER_SYSADDR_CONTACT.zipcode
        cls.tel_home = WS_CENTER_SYSADDR_CONTACT.tel_home
        cls.tel_telephone = WS_CENTER_SYSADDR_CONTACT.tel_telephone
        cls.email = WS_CENTER_SYSADDR_CONTACT.email
        cls.nation = WS_CENTER_SYSADDR_CONTACT.nation

        'ผปก
        Dim cls_MainCompany As New MainCompany
        'Dim dao_dalcn As New DAO.DBdalcn
        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
        Dim dao_syslctnm As New DAO_CPN.clsDBsyslctnm
        Dim dao_syslctaddr As New DAO_CPN.clsDBsyslctaddr
        dao_syslcnsid.GetDataby_taxno(_CITIEZEN_ID_AUTHORIZE)
        'dao_dalcn.GetDataby_lcnsid_lcnno(dao_syslcnsid.fields.lcnsid, 5200077)
        ' dao_syslcnsid.GetDataby_lcnsid(Integer.Parse(901))
        dao_syslcnsnm.GetDataby_lcnsid(Integer.Parse(dao_syslcnsid.fields.lcnsid))
        dao_syslctaddr.GetDataby_lcnsid_lctcd(Integer.Parse(dao_syslcnsid.fields.lcnsid), 1)
        WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd), Integer.Parse(dao_syslctaddr.fields.thmblcd))
        WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd))
        WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd))

        cls_MainCompany.name = dao_syslcnsnm.fields.thanm + "  " + dao_syslcnsnm.fields.thalnm
        cls_MainCompany.citiz_no = dao_syslcnsid.fields.ctzno
        cls_MainCompany.room = dao_syslctaddr.fields.room
        cls_MainCompany.floor = dao_syslctaddr.fields.floor
        cls_MainCompany.building = dao_syslctaddr.fields.building
        cls_MainCompany.number_addr = dao_syslctaddr.fields.thaaddr
        cls_MainCompany.moo = dao_syslctaddr.fields.mu
        cls_MainCompany.soi = dao_syslctaddr.fields.thasoi
        cls_MainCompany.road = dao_syslctaddr.fields.tharoad
        cls_MainCompany.thmbolcd = WS_CENTER_systhmbl.thathmblnm
        cls_MainCompany.districtcd = WS_CENTER_sysamphr.thaamphrnm
        cls_MainCompany.provincecd = WS_CENTER_syschngwt.thachngwtnm
        cls_MainCompany.zipcode = dao_syslctaddr.fields.zipcode
        cls_MainCompany.tel_home = dao_syslctaddr.fields.tel
        cls_MainCompany.tel_telephone = ""
        cls_MainCompany.email = ""
        cls_MainCompany.nation = ""

        'cls_MainCompany.name = ""
        'cls_MainCompany.citiz_no = ""
        'cls_MainCompany.room = ""
        'cls_MainCompany.floor = ""
        'cls_MainCompany.building = ""
        'cls_MainCompany.number_addr = ""
        'cls_MainCompany.moo = ""
        'cls_MainCompany.soi = ""
        'cls_MainCompany.road = ""
        'cls_MainCompany.thmbolcd = ""
        'cls_MainCompany.districtcd = ""
        'cls_MainCompany.provincecd = ""
        'cls_MainCompany.zipcode = ""
        'cls_MainCompany.tel_home = ""
        'cls_MainCompany.tel_telephone = ""
        'cls_MainCompany.email = ""
        'cls_MainCompany.nation = ""
        'cls.MainCompany.Add(cls_MainCompany)

        'ใบอนุญาตสถานที่
        cls.dalcn.lcnno = 0
        cls.dalcn.lcnsid = 0
        cls.dalcn.amphrcd = 0
        cls.dalcn.appdate = Date.Now()
        cls.dalcn.bsnage = 0
        cls.dalcn.bsncd = 0
        cls.dalcn.bsnid = 0
        cls.dalcn.bsnlctcd = 0
        cls.dalcn.chngwtcd = 0
        cls.dalcn.cnccd = 0
        cls.dalcn.cnccscd = 0
        cls.dalcn.cncdate = Date.Now()
        cls.dalcn.expyear = 0
        cls.dalcn.fdano = ""
        cls.dalcn.frtappdate = Date.Now()
        cls.dalcn.lcnpayst = 0
        cls.dalcn.lcntpcd = ""
        cls.dalcn.lctcd = 0
        cls.dalcn.lctnmcd = 0
        cls.dalcn.lmdfdate = Date.Now()
        cls.dalcn.lstfcd = 0
        cls.dalcn.opentime = ""
        cls.dalcn.phrflg = ""
        cls.dalcn.pvnabbr = ""
        cls.dalcn.pvncd = 0
        cls.dalcn.rcptpayst = 0
        cls.dalcn.remark = ""
        cls.dalcn.Co_name = ""
        cls.dalcn.rcvno = 0
        cls.dalcn.rcvdate = Date.Now()

        cls.sysplace.nameplace = ""
        cls.sysplace.number_addr = ""
        cls.sysplace.room = ""
        cls.sysplace.moo = ""
        cls.sysplace.floor = ""
        cls.sysplace.soi = ""
        cls.sysplace.building = ""
        cls.sysplace.road = ""
        cls.sysplace.thmblcd = 0
        cls.sysplace.amphrcd = 0
        cls.sysplace.chngwtcd = 0
        cls.sysplace.tel_home = ""
        cls.sysplace.tel_telephone = ""
        cls.sysplace.type_process = 0
        cls.sysplace.rcvno = 0

        For i As Integer = 0 To 1
            Dim cls_dacncc As New dacncc
            cls_dacncc.cnccscd = 1
            cls_dacncc.cnccsnm = 10
            cls_dacncc.cnccsst = 1
            cls.dacnccs.Add(cls_dacncc)
        Next
        For i As Integer = 0 To 1
            Dim cls_dacnc As New dacnc
            cls_dacnc.cnccd = 1
            cls_dacnc.cncnm = 111
            cls.dacnc.Add(cls_dacnc)
        Next
        For i As Integer = 0 To 1
            Dim cls_dalcntype As New dalcntype
            cls_dalcntype.grplcncd = 10
            cls_dalcntype.lcntpcd = 1
            cls_dalcntype.lcntpnm = 0
            cls_dalcntype.lcntpnmeng = 0
            cls_dalcntype.useinpvn = 0
            cls.dalcntype.Add(cls_dalcntype)
        Next
        For i As Integer = 0 To 1
            Dim cls_dalcnphr As New dalcnphr
            cls_dalcnphr.pvncd = 10
            cls_dalcnphr.lcnno = 1
            cls_dalcnphr.functcd = 0
            cls_dalcnphr.lcntpcd = 0
            cls_dalcnphr.opentime = 0
            cls_dalcnphr.orderno = 0
            cls_dalcnphr.phrcd = 0
            cls_dalcnphr.phrcncst = 0
            cls_dalcnphr.phrid = 0
            cls_dalcnphr.phrno = 0
            cls_dalcnphr.pvncd = 0

            cls.dalcnphr.Add(cls_dalcnphr)
        Next
        For i As Integer = 0 To 1
            Dim cls_dalcnkep As New dalcnkep
            cls_dalcnkep.keplctnmcd = 10
            cls_dalcnkep.lcnno = 1
            cls_dalcnkep.lcnsid = 0
            cls_dalcnkep.lcntpcd = 0
            cls_dalcnkep.lctcd = 0
            cls_dalcnkep.orderno = 0
            cls_dalcnkep.pvncd = 0

            cls.dalcnkep.Add(cls_dalcnkep)
        Next


        Dim cls_syschngwt As New WS_CENTER.syschngwt
        For Each s_cls_syschngwt In WS_CENTER.GetData_Changwat()
            cls.syschngwt.Add(s_cls_syschngwt)
            cls_syschngwt = New WS_CENTER.syschngwt
        Next
        Dim cls_sysamphr As New WS_CENTER.sysamphr
        For Each s_cls_sysamphr In WS_CENTER.GetData_Amphur()
            cls.sysamphr.Add(s_cls_sysamphr)
            cls_sysamphr = New WS_CENTER.sysamphr
        Next
        Dim cls_systhmbl As New WS_CENTER.systhmbl
        For Each s_cls_systhmbl In WS_CENTER.GetData_Thumbol()
            cls.systhmbl.Add(s_cls_systhmbl)
            cls_systhmbl = New WS_CENTER.systhmbl
        Next


        Dim cls_daphrfunctcd As New WS_LGTDRUG.daphrfunctcd
        For Each s_cls_daphrfunctcd In WS_LGTDRUG.daphrfunctcd()
            cls.daphrfunctcd.Add(s_cls_daphrfunctcd)
            cls_daphrfunctcd = New WS_LGTDRUG.daphrfunctcd
        Next

        'Dim CLASS_CENTER As New CLASS_CENTER
        ''Dim CLASS_DARQTPHR As New CLASS_DARQTPHR
        'Dim WS_CENTER_CLC_NAMES As New WS_CENTER.CLC_NAMES
        'Dim WS_CENTER As New WS_CENTER.WS_CENTER

        'Dim WS_CENTER_systhmbl As New WS_CENTER.CLC_THMBLCD
        'Dim WS_CENTER_sysamphr As New WS_CENTER.CLC_AMPHRCD
        'Dim WS_CENTER_syschngwt As New WS_CENTER.CLC_CHAWTCD

        'Dim WS_LGTDRUG_CLC_DARQT As New WS_LGTDRUG.CLC_DARQT

        'Dim WS_LGTDRUG As New WS_LGTDRUG.WS_LGTDRUG


        'WS_LGTDRUG_CLC_DARQT = WS_LGTDRUG.GET_DARQT(_lcnsid)
        ''WS_LGTFOOD_CLC_LCTCD = WS_LGTFOOD.GET_LCTCD(Integer.Parse(ddl_lcnno.SelectedValue), Integer.Parse(_lcnsid))
        'WS_CENTER_CLC_NAMES = WS_CENTER.GET_FULL_ADDR(_lcnsid, WS_LGTDRUG_CLC_DARQT.lctcd())


        'WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(WS_CENTER_CLC_NAMES.chngwtcd), Integer.Parse(WS_CENTER_CLC_NAMES.amphrcd), Integer.Parse(WS_CENTER_CLC_NAMES.thmblcd))
        'WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(WS_CENTER_CLC_NAMES.chngwtcd), Integer.Parse(WS_CENTER_CLC_NAMES.amphrcd))
        'WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(WS_CENTER_CLC_NAMES.chngwtcd))


        'CLASS_DARQT.lcnsid = _lcnsid
        'CLASS_DARQT.rcvdate = Date.Now()
        ''CLASS_DARQT.bsnage = 0
        ''CLASS_DARQT.bsnid = 0
        ''CLASS_DARQT.lctcd = 0
        ''CLASS_DARQT.lctnmcd = 0



        'CLASS_DARQT.thanm = WS_CENTER_CLC_NAMES.THAADDR
        'CLASS_DARQT.thasoi = WS_CENTER_CLC_NAMES.THASOI
        'CLASS_DARQT.tharoad = WS_CENTER_CLC_NAMES.THAROAD
        'CLASS_DARQT.mu = WS_CENTER_CLC_NAMES.MUU
        'CLASS_DARQT.tel = WS_CENTER_CLC_NAMES.TEL


        ''CLASS_CENTER.amphrcd = WS_CENTER_CLC_NAMES.amphrcd
        ''CLASS_CENTER.chngwtcd = WS_CENTER_CLC_NAMES.chngwtcd
        ''CLASS_CENTER.thmbl = WS_CENTER_CLC_NAMES.thmblcd


        'CLASS_DARQT.thathmblnm = WS_CENTER_systhmbl.thathmblnm
        'CLASS_DARQT.thaamphrnm = WS_CENTER_sysamphr.thaamphrnm
        'CLASS_DARQT.thachngwtnm = WS_CENTER_syschngwt.thachngwtnm


        ''WS_CENTER_CLC_NAMES = WS_CENTER.GET_LOCATION(Integer.Parse(_lcnsid), Integer.Parse(WS_LGTFOOD_CLC_LCTCD.lctcd()))

        ''CLASS_DARQT.lctnm = WS_CENTER_CLC_NAMES.lctnm
        RunAppSettings()
        Dim path As String = _PATH_XML_CLASS
        path = path & "PDFdalcn.xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls.GetType)
        ' Dim y As New XmlSerializer(CLASS_DARQTPHR.GetType)
        ' y.Serialize(objStreamWriter, CLASS_DARQTPHR)
        x.Serialize(objStreamWriter, cls)
        objStreamWriter.Close()

    End Sub
    'Sub Runcomno()
    '    Dim bao As New BAO.ClsDBSqlCommand
    '    bao.FAGenID("ID", "dalcn")
    '    Dim intcomno As Integer
    '    intcomno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1
    '    Session("comno") = intcomno.ToString()

    'End Sub
    ''' <summary>
    ''' รวม XML เข้าไปที่ PDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub fusion_XML_To_PDF(ByVal path_XML As String, ByVal filename As String)
        RunAppSettings()
        Dim path As String = path_XML
        path = path & filename & ".xml"
        Using pdfReader__1 = New PdfReader(_PATH_PDF_TEMPLATE & "PDFdalcn.pdf")
            Using outputStream = New FileStream(_PATH_PDF_XML_CLASS & filename & ".pdf", FileMode.Create, FileAccess.Write)
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(path)
                End Using
            End Using
        End Using


        Dim clsds As New ClassDataset



        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename= " & filename & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(_PATH_PDF_XML_CLASS & filename & ".pdf"))

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub


    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)

        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("ID").ToString()
        If e.CommandName = "sel" Then
            Dim dao As New DAO.DBdalcn
            dao.GetDataby_ID(Integer.Parse(str_ID))
            dao.fields.cnccd = 0
            dao.update()
            load_GV_lcnno()
        ElseIf e.CommandName = "pdf" Then
            Dim dao As New DAO.DBdalcn
            dao.GetDataby_ID(Integer.Parse(str_ID))
            ' If dao.fields.lcntypecd = 11 Then
            Dim dao_TRANSESSION_UPLOAD As New DAO_CPN.clsDBTRANSESSION_UPLOAD
            dao_TRANSESSION_UPLOAD.GetDataby_REF_NO(dao.fields.rcvno)
            fusion_XML_To_PDF(_PATH_XML_TRADER, "DA-02-" & dao_TRANSESSION_UPLOAD.fields.ID)
        End If

    End Sub

    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
            Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_lcnno.DataKeys.Item(index).Value.ToString()
            Dim dao As New DAO.DBdalcn

            dao.GetDataby_ID(Integer.Parse(str_ID))
            If dao.fields.cnccd = -1 Or String.IsNullOrEmpty(dao.fields.cnccd.ToString()) Then
                lbl_status.Text = "รอยืนยัน"
                btn_Select.Visible = True
            ElseIf dao.fields.cnccd = 0 Then
                lbl_status.Text = "รอพิจารณา"
                btn_Select.Visible = False
            ElseIf dao.fields.cnccd = 1 Then
                lbl_status.Text = "อนุญาต"
                btn_Select.Visible = False
            ElseIf dao.fields.cnccd = 2 Then
                lbl_status.Text = "ไม่อนุญาต"
                btn_Select.Visible = False
            ElseIf dao.fields.cnccd = 3 Then
                lbl_status.Text = "ยกเลิกคำขอ"
                btn_Select.Visible = False
            ElseIf dao.fields.cnccd = 4 Then
                lbl_status.Text = "เสนอผลการพิจารณา"
                btn_Select.Visible = False
            ElseIf dao.fields.cnccd = 5 Then
             
            End If

        End If
    End Sub
End Class

