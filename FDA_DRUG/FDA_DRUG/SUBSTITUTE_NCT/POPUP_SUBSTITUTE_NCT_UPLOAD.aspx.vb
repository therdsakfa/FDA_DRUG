Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports System.Xml
Public Class POPUP_SUBSTITUTE_NCT_UPLOAD
    Inherits System.Web.UI.Page

    Private _type_id As String = ""
    Private _IDA As String = ""
    Private _ProcessID As Integer
    Private _pvncd As Integer
    Sub runQuery()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        bao.RunAppSettings()
        _CLS = Session("CLS")
    End Sub
    Private _CLS As New CLS_SESSION
    Dim bao As New BAO.AppSettings

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        get_pvncd()
        set_txt_label()
        show_panel()
        If Not IsPostBack Then
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub


    Public Sub show_panel()
        If _type_id = "101" Then
            Panel101.Style.Add("display", "block")
        Else

        End If
    End Sub
    Public Sub set_txt_label()
        'ขย.1
        uc101_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")

    End Sub

    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        uc101_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")

    End Sub
    Sub upload_pdf_edit()
        If FileUpload1.HasFile Then
            Dim file_ex As String = ""
            file_ex = file_extension_nm(FileUpload1.FileName)

            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim dao_sub As New DAO_DRUG.TB_DALCN_NCT_SUBSTITUTE
            dao_sub.Getdata_by_ID(Request.QueryString("IDA"))

            Try
                TR_ID = dao_sub.fields.TR_ID
            Catch ex As Exception

            End Try
            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)


            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)

            If dao_sub.fields.STATUS_ID = 5 Then
                dao_sub.fields.STATUS_ID = 66
                dao_sub.update()
            End If
            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
            Dim check As Boolean = True
            ' Try
            check = update_to_database(XML_TRADER, TR_ID)
            If check = True Then
                SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))

                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            Else

            End If



            'Catch ex As Exception

            '    alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            'End Try

        End If
    End Sub
    Sub upload_pdf()
        If FileUpload1.HasFile Then
            Dim file_ex As String = ""
            file_ex = file_extension_nm(FileUpload1.FileName)

            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)


            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
            Dim check As Boolean = True
            ' Try
            check = insrt_to_database(XML_TRADER, TR_ID)
            If check = True Then
                SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))

                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            Else

            End If



            'Catch ex As Exception

            '    alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            'End Try

        End If
    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        If Request.QueryString("edit") <> "" Then
            upload_pdf_edit()
        Else
            upload_pdf()
        End If



    End Sub
    ''' <summary>
    ''' ดึง lcntpcd
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function set_lcntpcd() As String
        Dim dao As New DAO_DRUG.ClsDBPROCESS_NAME
        dao.GetDataby_Process_ID(_ProcessID)
        Return dao.fields.PROCESS_NAME
    End Function

    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True

        ' Try
        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_DALCN_NCT_SUBSTITUTE
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()


        Dim cernumber As String = ""

        Dim dao As New DAO_DRUG.TB_DALCN_NCT_SUBSTITUTE
        dao.fields = p2.DALCN_NCT_SUBSTITUTEs

        dao.fields.PROCESS_ID = _ProcessID
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        Try
            dao.fields.WRITE_AT = p2.DALCN_NCT_SUBSTITUTEs.WRITE_AT
        Catch ex As Exception

        End Try
        Try
            dao.fields.WRITE_DATE = p2.DALCN_NCT_SUBSTITUTEs.WRITE_DATE
        Catch ex As Exception

        End Try
        dao.fields.STATUS_ID = 1
        dao.fields.TR_ID = TR_ID
        dao.fields.FK_IDA = _IDA
        dao.fields.CTZNO = _CLS.CITIZEN_ID

        dao.insert()
        Return check
    End Function

    Private Function update_to_database(ByVal FileName As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True

        ' Try
        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_DALCN_NCT_SUBSTITUTE
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()


        Dim cernumber As String = ""

        Dim dao As New DAO_DRUG.TB_DALCN_NCT_SUBSTITUTE
        dao.Getdata_by_ID(Request.QueryString("IDA"))
        dao.fields = p2.DALCN_NCT_SUBSTITUTEs

        dao.fields.PROCESS_ID = _ProcessID
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        Try
            dao.fields.WRITE_AT = p2.DALCN_NCT_SUBSTITUTEs.WRITE_AT
        Catch ex As Exception

        End Try
        Try
            dao.fields.WRITE_DATE = p2.DALCN_NCT_SUBSTITUTEs.WRITE_DATE
        Catch ex As Exception

        End Try

        dao.update()
        Return check
    End Function

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub
End Class