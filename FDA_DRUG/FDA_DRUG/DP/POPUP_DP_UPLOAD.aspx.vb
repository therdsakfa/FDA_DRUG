Imports System.IO
Imports System.Xml.Serialization

Public Class POPUP_DP_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _fk_ida As String = ""
    Sub runQuery()
        _ProcessID = "14" 'Request.QueryString("type")
        '_IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
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
        'If FileUpload1.HasFile Then
        '    Dim bao As New BAO.AppSettings
        '    bao.RunAppSettings()

        '    Dim cls_tr As New BAO_TRANSECTION
        '    Dim tr_id As Integer = 0

        '    cls_tr.CITIZEN_ID = _CLS.CITIZEN_ID
        '    cls_tr.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        '    tr_id = cls_tr.insert_transection(8)

        '    FileUpload1.SaveAs(bao._PATH_PDF_TRADER & "DA-8-" & con_year(Date.Now.Year) & "-" & tr_id & ".pdf") '"C:\path\PDF_TRADER\"
        '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "DA-8-" & con_year(Date.Now.Year) & "-" & tr_id & ".pdf", tr_id) '"C:\path\PDF_TRADER\"
        '    insrt_to_database(bao._PATH_XML_TRADER & "DA-8-" & con_year(Date.Now.Year) & "-" & tr_id & ".xml", tr_id) '"C:\path\XML_TRADER\"

        '    alert("รหัสการดำเนินการ คือ DA-8-" & con_year(Date.Now.Year) & "-" & tr_id)
        'End If

        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



            'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
            '    Exit Sub
            'End If

            Dim PDF_TRADER As String = bao._PATH_PDF_TRADER & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"

            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            Dim XML_TRADER As String = bao._PATH_XML_TRADER & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
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
            Dim p2 As New CLASS_DP
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.ClsDBdrpcb

            ' Dim bao As New BAO.GenNumber

            dao.fields = p2.drpcbs
            dao.fields.cnsdcd = 1
            dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
            dao.fields.rcvdate = Date.Now


            '  dao.fields.xmlnm = "FA-8-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
            dao.fields.TR_ID = TR_ID
            dao.fields.FK_IDA = _fk_ida
            dao.insert()

            Dim dao_drpcbdrg As New DAO_DRUG.ClsDBdrpcbdrg
            For Each dao_drpcbdrg.fields In p2.drpcbdrgs
                dao_drpcbdrg.fields.TR_ID = _CLS.TRANSECTION_UP_ID
                dao_drpcbdrg.fields.FK_IDA = _CLS.IDA
                dao_drpcbdrg.insert()
                dao_drpcbdrg = New DAO_DRUG.ClsDBdrpcbdrg
            Next

            Dim dao_drfrgn As New DAO_DRUG.ClsDBdrfrgn
            For Each dao_drfrgn.fields In p2.drfrgns
                dao_drfrgn.fields.TR_ID = _CLS.TRANSECTION_UP_ID
                dao_drfrgn.fields.FK_IDA = _CLS.IDA
                dao_drfrgn.insert()
                dao_drfrgn = New DAO_DRUG.ClsDBdrfrgn
            Next

            Dim dao_drfrgnaddr As New DAO_DRUG.ClsDBdrfrgnaddr
            For Each dao_drfrgnaddr.fields In p2.drfrgnaddrs
                dao_drfrgnaddr.fields.TR_ID = _CLS.TRANSECTION_UP_ID
                dao_drfrgnaddr.fields.FK_IDA = _CLS.IDA
                dao_drfrgnaddr.insert()
                dao_drfrgnaddr = New DAO_DRUG.ClsDBdrfrgnaddr
            Next

            Dim dao_syspdcfrgn As New DAO_DRUG.ClsDBsyspdcfrgn
            For Each dao_syspdcfrgn.fields In p2.syspdcfrgns
                dao_syspdcfrgn.fields.TR_ID = _CLS.TRANSECTION_UP_ID
                dao_syspdcfrgn.fields.FK_IDA = _CLS.IDA
                dao_syspdcfrgn.insert()
                dao_syspdcfrgn = New DAO_DRUG.ClsDBsyspdcfrgn
            Next


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