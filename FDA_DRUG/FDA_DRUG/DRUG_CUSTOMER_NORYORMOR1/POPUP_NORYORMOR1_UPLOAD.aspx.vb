﻿Imports System.IO
Imports System.Xml.Serialization

Public Class POPUP_NORYORMOR1_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _proj_ida As String = ""
    Sub runQuery()
        _ProcessID = Request.QueryString("process")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _proj_ida = Request.QueryString("proj_ida")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            _ProcessID = Request.QueryString("type")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



            'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
            '    Exit Sub
            'End If

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
            Try
                check = insrt_to_database(XML_TRADER, TR_ID)
                If check = True Then
                    alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                Else

                End If
            Catch ex As Exception

                alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End Try


        End If

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try

            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DI
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.ClsDBdrimpfor

            ' Dim bao As New BAO.GenNumber

            dao.fields = p2.drimpfors
            'dao.fields.cnsdcd = 1
            dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            dao.fields.rcvdate = Date.Now
            dao.fields.objcd = 1
            dao.fields.FK_IDA = _proj_ida
            dao.fields.PROCESS_ID = _ProcessID

            '  dao.fields.xmlnm = "FA-8-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
            dao.fields.TR_ID = TR_ID
            dao.insert()




            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(Integer.Parse(TR_ID))
            dao_up.fields.REF_NO = dao.fields.IDA
            dao_up.update()
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function
End Class