Imports System.IO
Imports System.Xml.Serialization
Public Class POPUP_LCN_LCT_KEEP_UPLOAD
    Inherits System.Web.UI.Page
    Property _CLS As CLS_SESSION

    Private _YEAR As Integer
    Private _type As String
    Property _Process_ID As Integer

    Private Sub runQuery()
        _type = Request.QueryString("type")
        If Session("CLS") Is Nothing Then
        Else
            _CLS = Session("CLS")
        End If
        _YEAR = con_year(Year(Date.Now))

        '------------------แก้เองนะ------------
        'Dim bao As New BAO.PROCESS
        _Process_ID = 98 'bao.GET_PROCESS_ID(_type, "00")
        '------------------------------------
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()

        'Dim dao As New DAO_DRUG.TB_TEMPLATE_ATTACH
        'dao.GetDataby_LCTNPCD(_type, "01")

        Dim dao As New DAO_DRUG.TB_TEMPLATE_ATTACH
        dao.GetDataby_LCTNPCD(_type, "01")
        For Each dao.fields In dao.Details
            Dim uc As New UC_ATTACH
            Dim CC As UserControl = Page.LoadControl("../UC/UC_ATTACH.ascx")
            uc = CC
            uc.ID = dao.fields.IDA
            uc.BindData(dao.fields.ATTACH_NAME, dao.fields.ATTACH_PIORITY, dao.fields.ATTACH_FILE_EXTENSION, dao.fields.LCNTPCD, dao.fields.TYPE)
            PlaceHolder1.Controls.Add(uc)
        Next
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        Dim tr_id As String= 0
        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        TR_ID = bao_tran.insert_transection_new(_Process_ID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID

        '  If Upload_Attach(TR_ID) Then 'เช็คไฟล์แนบ
        Dim bao As New BAO.AppSettings
        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_Process_ID, 1, 0)
        'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
        Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _Process_ID, Date.Now.Year, TR_ID)
        'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
        Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _Process_ID, Date.Now.Year, TR_ID)

        FileUpload1.SaveAs(PDF_TRADER) 'ทำการ Save File ลงไป
        convert_PDF_To_XML(PDF_TRADER, XML_TRADER) 'ทำการ แยกไฟล์ XML ออกจาก PDF แล้วทำการ Save ลงตามจุดที่กำหนด
        If insrt_to_database(XML_TRADER, TR_ID) = True Then 'ทำการส่ง XML เข้าไปเพื่อทำการ Insert เข้า DATABASE และ ส่ง TR_ID เข้าไปเพื่อเชื่อมโยง
            alert("คุณได้รับรหัสดำเนินการ " & NAME_TRANCESTION("NCT", _Process_ID, _YEAR, TR_ID))
        Else
            alert("คุณกรอกข้อมูลไม่ถูกต้อง")
        End If


        ' Else
        'alert("กรุณาเลือกไฟล์แนบ")
        'alert("เกิดข้อผิดพลาดกรุณาแจ้งรหัสดำเนินการ " & NAME_TRANCESTION("NCT", _Process_ID, _YEAR, TR_ID))
        ' End If
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal XML_FILE As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True

        Try
            Dim objStreamReader As New StreamReader(XML_FILE)
            Dim p2 As New CLS_LOCATION
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
            Dim dao_lct_thmbl As New DAO_CPN.clsDBsysthmbl
            Dim dao_lct_amphr As New DAO_CPN.clsDBsysamphr
            Dim dao_lct_chngwt As New DAO_CPN.clsDBsyschngwt

            dao.fields = p2.NCT_LCTADDRs
            dao.fields.lmdfdate = Date.Now
            dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            dao.fields.CITIZEN_ID = p2.CITIZEN_ID
            dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
            dao.fields.TR_ID = TR_ID
            dao.fields.XMLNAME = NAME_TRANCESTION("DRUG", _Process_ID, con_year(Year(Date.Now)), TR_ID)
            dao.fields.DOWN_ID = p2.DOWNLOAD_ID
            dao.fields.STATUS_ID = 1
            dao.fields.SYSTEM_NAME = "DRUG"
            dao.fields.LOCATION_TYPE_ID = 2
            dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE

            dao_lct_thmbl.GetData_by_chngwtcd_amphrcd_thmblcd(dao.fields.chngwtcd, dao.fields.amphrcd, dao.fields.thmblcd)
            dao_lct_amphr.GetData_by_chngwtcd_amphrcd(dao.fields.chngwtcd, dao.fields.amphrcd)
            dao_lct_chngwt.GetData_by_chngwtcd(dao.fields.chngwtcd)


            dao.fields.thathmblnm = dao_lct_thmbl.fields.thathmblnm
            dao.fields.engthmblnm = dao_lct_thmbl.fields.engthmblnm
            dao.fields.thaamphrnm = dao_lct_amphr.fields.thaamphrnm
            dao.fields.engamphrnm = dao_lct_amphr.fields.engamphrnm
            dao.fields.thachngwtnm = dao_lct_chngwt.fields.thachngwtnm
            dao.fields.engchngwtnm = dao_lct_chngwt.fields.engchngwtnm

            dao.insert()


            Dim dao_NCT_LCT_BSN As New DAO_CPN.TB_LOCATION_BSN
            ' Dim daos As New DAO_CPN.
            For Each dao_NCT_LCT_BSN.fields In p2.LOCATION_BSNs
                dao_NCT_LCT_BSN.fields.TR_ID = TR_ID
                dao_NCT_LCT_BSN.fields.FK_IDA = dao.fields.IDA
                dao_NCT_LCT_BSN.insert()
            Next

            Dim IDA As Integer = dao.fields.IDA

            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = IDA
            dao_up.fields.PROCESS_ID = 98
            dao_up.update()

            'End If
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub


    ''' <summary>
    ''' ทำการ UPLOAD FILE แนบ
    ''' </summary>
    ''' <param name="TR_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Upload_Attach(ByVal TR_ID As Integer)
        Dim check As Boolean = True
        For Each c As Control In PlaceHolder1.Controls
            If c.ID <> "" Then
                Dim ida As String = c.ID
                Dim uc As New UC_ATTACH
                uc = PlaceHolder1.FindControl(c.ID)
                check = uc.insert(TR_ID)
                If check = False Then
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
                    Exit For
                End If
            End If
        Next
        Return check
    End Function

    Protected Sub btn_Upload0_Click(sender As Object, e As EventArgs) Handles btn_Upload0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class