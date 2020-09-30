Imports System.IO
Imports System.Xml.Serialization
Public Class FRM_SUBSTITUTE_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _IDA As String
    Private _rgt_ida As String
    Sub runQuery()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _rgt_ida = Request.QueryString("rgt_ida")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            ' _ProcessID = Request.QueryString("type")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        runQuery()
        set_txt_label()
        If _ProcessID = "15" Then
            Panel101.Style.Add("display", "block")
        End If
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)

        uc102_1.ATTACH1(TR_ID, PROCESS_ID, YEAR, "1")
        uc102_2.ATTACH1(TR_ID, PROCESS_ID, YEAR, "2")
        uc102_3.ATTACH1(TR_ID, PROCESS_ID, YEAR, "3")
      
    End Sub
    Public Sub set_txt_label()
        uc102_1.get_label("1.สำเนาใบรับแจ้งความ")
        uc102_2.get_label("2.ใบสำคัญการขึ้นทะเบียนตำรับยาที่ถูกทำลาย")
        uc102_3.get_label("3.สำเนาใบอนุญาตผลิต หรือนำหรือสั่งยาเข้ามาในราชอาณาจักร")
      
    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)

            Dim check As Boolean = True
            Try
                check = insrt_to_database(XML_TRADER, TR_ID)
                If check = True Then
                    SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
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
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try

            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DRRGT_SUB
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
            dao_rg.GetDataby_IDA(_rgt_ida)
            ' Dim bao As New BAO.GenNumber

            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(_CLS.PVCODE)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try

            dao.fields = p2.DRRGT_SUBSTITUTEs
            'dao.fields.EDIT_DESCRIPTION = p2.DRRGT_EDIT_REQUESTs.EDIT_DESCRIPTION
            'dao.fields.CREATE_DATE = Date.Now
            dao.fields.STATUS_ID = 1
            dao.fields.TR_ID = TR_ID
            Try
                dao.fields.lcntpcd = dao_rg.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.pvncd = dao_rg.fields.pvncd
            Catch ex As Exception

            End Try
            Try
                dao.fields.TABEAN_TYPE = p2.TABEAN_TYPE1
            Catch ex As Exception

            End Try
            Try
                dao.fields.CHK_LCN_SUBTYPE = p2.CHK_LCN_SUBTYPE
            Catch ex As Exception

            End Try
            Try
                dao.fields.lcnno = dao_rg.fields.lcnno
            Catch ex As Exception

            End Try
            Try
                dao.fields.pvnabbr = dao_rg.fields.pvnabbr
            Catch ex As Exception

            End Try
            Try
                dao.fields.drgtpcd = dao_rg.fields.drgtpcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.rgttpcd = dao_rg.fields.rgttpcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.rgtno = dao_rg.fields.rgtno
            Catch ex As Exception

            End Try
            Try
                dao.fields.FK_LCN_IDA = dao_rg.fields.FK_LCN_IDA 'Request.QueryString("lcn_ida")
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = _rgt_ida
            dao.fields.PROCESS_ID = _ProcessID
            dao.fields.IDENTIFY = dao_rg.fields.IDENTIFY '_CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CTZNO = _CLS.CITIZEN_ID

            dao.insert()
           
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function
End Class