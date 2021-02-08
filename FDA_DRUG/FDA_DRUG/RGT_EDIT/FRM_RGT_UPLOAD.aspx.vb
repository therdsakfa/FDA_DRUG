Imports System.IO
Imports System.Xml.Serialization
Public Class FRM_RGT_UPLOAD
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
        If Not IsPostBack Then
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
            If RadioButtonList1.SelectedValue = "3" Then
                Panel101.Style.Add("display", "block")
            Else
                Panel101.Style.Add("display", "none")
            End If
        End If
        ' UC_ATTACH1.SETTING_INFORMATION("เอกสาร CER", 1)
    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)

        'uc102_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
        'uc102_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
        uc102_3.ATTACH1(TR_ID, PROCESS_ID, YEAR, "1")
        uc102_4.ATTACH1(TR_ID, PROCESS_ID, YEAR, "2")
        uc102_5.ATTACH1(TR_ID, PROCESS_ID, YEAR, "3")
        uc102_6.ATTACH1(TR_ID, PROCESS_ID, YEAR, "4")
        uc102_7.ATTACH1(TR_ID, PROCESS_ID, YEAR, "5")
        uc102_8.ATTACH1(TR_ID, PROCESS_ID, YEAR, "6")

    End Sub
    Public Sub set_txt_label()
        'uc102_1.get_label("1.สำเนาใบสำคัญการขึ้นทะเบียนตำรับยาหรือใบแทน")
        'uc102_2.get_label("2.สำเนาใบอนุญาต")
        uc102_3.get_label("1.เอกสารตาม AVG")
        uc102_4.get_label("2.กรณีที่นอกเหนือ AVG")
        uc102_5.get_label("3.ฉลาก/เอกสารกำกับยา")
        uc102_6.get_label("4.รายละเอียดการแก้ไขเปลี่ยนแปลงสูตรตำรับยา")
        uc102_7.get_label("5.รายละเอียดการแก้ไขเปลี่ยนแปลงวิธีวิเคราะห์และข้อกำหนดมาตรฐาน")
        uc102_8.get_label("6.อื่นๆ")
    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        If FileUpload1.HasFile Then
            If RadioButtonList1.SelectedValue = "" Then
                Response.Write("<script type='text/javascript'>window.parent.alert('โปรดระบุวิธียื่นเอกสารประกอบคำขอ');</script> ")
            Else
                If RadioButtonList1.SelectedValue = "2" Or RadioButtonList1.SelectedValue = "1" Then
                    If TextBox1.Text = "" Then
                        Response.Write("<script type='text/javascript'>window.parent.alert('โปรดระบุเลข identifier');</script> ")
                    Else
                        upload_file()
                    End If
                Else
                    upload_file()
                End If
                
            End If
 
        End If
    End Sub
    Sub upload_file()
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()

        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        If Request.QueryString("identify") <> "" Then
            bao_tran.CITIZEN_ID_AUTHORIZE = Request.QueryString("identify")
        Else
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        End If
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
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try

            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_EDIT_DRRGT
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
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

            dao.fields = p2.DRRGT_EDIT_REQUESTs
            'dao.fields.EDIT_DESCRIPTION = p2.DRRGT_EDIT_REQUESTs.EDIT_DESCRIPTION
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.STATUS_ID = 1
            dao.fields.TR_ID = TR_ID
            Try
                dao.fields.RQT_TYPE = RadioButtonList1.SelectedValue
            Catch ex As Exception

            End Try
            Try
                dao.fields.RQT_IDENTIFY = TextBox1.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.PHR_IDENTIFY = p2.PHR_IDENTIFY
            Catch ex As Exception

            End Try
            Try
                dao.fields.PHR_NAME = p2.PHR_NAME
            Catch ex As Exception

            End Try
            Try
                dao.fields.lcntpcd = dao_rg.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                dao.fields.pvncd = dao_rg.fields.pvncd
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
                dao.fields.LCN_IDA = Request.QueryString("lcn_ida")
            Catch ex As Exception

            End Try
            dao.fields.FK_IDA = _rgt_ida
            dao.fields.PROCESS_ID = _ProcessID
            If Request.QueryString("identify") <> "" Then
                dao.fields.CITIZEN_ID_AUTHORIZE = Request.QueryString("identify")
            Else
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            End If

            dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID

            dao.insert()
            Dim main_ida As Integer = dao.fields.IDA
            Dim orders As Integer = 1
            Dim dao_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            For Each dao_pack.fields In p2.DRRGT_PACKAGE_DETAILs
                Dim dao_pack2 As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_PACKAGE_DETAIL
                With dao_pack2.fields
                    Try
                        .BARCODE = dao_pack.fields.BARCODE
                    Catch ex As Exception

                    End Try
                    Try
                        .BIG_AMOUNT = dao_pack.fields.BIG_AMOUNT
                    Catch ex As Exception

                    End Try
                    Try
                        .BIG_UNIT = dao_pack.fields.BIG_UNIT
                    Catch ex As Exception

                    End Try
                    Try
                        .CHECK_PACKAGE = dao_pack.fields.CHECK_PACKAGE
                    Catch ex As Exception

                    End Try

                    .DATE_ADD = Date.Now
                    .FK_IDA = main_ida
                    Try
                        .IM_DETAIL = dao_pack.fields.IM_DETAIL
                    Catch ex As Exception

                    End Try
                    Try
                        .IM_QTY = dao_pack.fields.IM_QTY
                    Catch ex As Exception

                    End Try
                    Try
                        .MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
                    Catch ex As Exception

                    End Try
                    Try
                        .MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
                    Catch ex As Exception

                    End Try
                    Try
                        .order_id = orders
                    Catch ex As Exception

                    End Try
                    Try
                        .PACKAGE_NAME = dao_pack.fields.PACKAGE_NAME
                    Catch ex As Exception

                    End Try
                    Try
                        .SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
                    Catch ex As Exception

                    End Try
                    Try
                        .SMALL_UNIT = dao_rg.fields.UNIT_NORMAL 'dao_pack.fields.SMALL_UNIT
                    Catch ex As Exception

                    End Try
                    Try
                        .SUM = dao_pack.fields.SUM
                    Catch ex As Exception

                    End Try


                End With
                dao_pack2.insert()
                orders += 1

            Next
            'Dim dao_col As New DAO_DRUG.TB_DRRGT_COLOR
            'For Each dao_col.fields In p2.DRRGT_COLORs
            Dim dao_col2 As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_COLOR
            With dao_col2.fields
                Try
                    .COLOR_NAME1 = p2.DRRGT_COLOR.COLOR_NAME1
                Catch ex As Exception

                End Try
                Try
                    .COLOR_NAME2 = p2.DRRGT_COLOR.COLOR_NAME2
                Catch ex As Exception

                End Try
                Try
                    .COLOR_NAME3 = p2.DRRGT_COLOR.COLOR_NAME3
                Catch ex As Exception

                End Try
                Try
                    .COLOR_NAME4 = p2.DRRGT_COLOR.COLOR_NAME4
                Catch ex As Exception

                End Try

                Try
                    .COLOR1 = p2.DRRGT_COLOR.COLOR1
                Catch ex As Exception

                End Try
                Try
                    .COLOR2 = p2.DRRGT_COLOR.COLOR2
                Catch ex As Exception

                End Try
                Try
                    .COLOR3 = p2.DRRGT_COLOR.COLOR3
                Catch ex As Exception

                End Try
                Try
                    .COLOR4 = p2.DRRGT_COLOR.COLOR4
                Catch ex As Exception

                End Try
            End With
            dao_col2.fields.FK_IDA = main_ida
            dao_col2.insert()
            'Next

            'Dim dao_col As New DAO_DRUG.TB_DRRGT_COLOR
            'For Each dao_col.fields In p2.DRRGT_COLORs
            '    Dim dao_col2 As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_COLOR
            '    With dao_col2.fields
            '        Try
            '            .COLOR_NAME1 = dao_col.fields.COLOR_NAME1
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .COLOR_NAME2 = dao_col.fields.COLOR_NAME2
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .COLOR_NAME3 = dao_col.fields.COLOR_NAME3
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .COLOR_NAME4 = dao_col.fields.COLOR_NAME4
            '        Catch ex As Exception

            '        End Try

            '        Try
            '            .COLOR1 = dao_col.fields.COLOR1
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .COLOR2 = dao_col.fields.COLOR2
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .COLOR3 = dao_col.fields.COLOR3
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .COLOR4 = dao_col.fields.COLOR4
            '        Catch ex As Exception

            '        End Try
            '    End With
            '    dao_col2.fields.FK_IDA = main_ida
            '    dao_col2.insert()
            'Next


            '-------------------------------------------------------------
            'Dim dao_ca1 As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            'Dim ii As Integer = 1
            'For Each dao_ca1.fields In p2.DRRGT_DETAIL_CASes
            '    Dim dao_ca2 As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_CA
            '    With dao_ca2.fields
            '        Try
            '            .AORI = dao_ca1.fields.AORI
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .BASE_FORM = dao_ca1.fields.BASE_FORM
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .CAS_TYPE = 1
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .ebioqty = dao_ca1.fields.ebioqty
            '        Catch ex As Exception

            '        End Try

            '        Try
            '            .ebiosqno = dao_ca1.fields.ebiosqno
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .ebiounitcd = dao_ca1.fields.ebiounitcd
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .EQTO_IOWA = dao_ca1.fields.EQTO_IOWA
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .EQTO_QTY = dao_ca1.fields.EQTO_QTY
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .EQTO_SUNITCD = dao_ca1.fields.EQTO_SUNITCD
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            Dim dao_iowa As New DAO_DRUG.TB_driowa
            '            dao_iowa.GetDataby_IDA(Trim(dao_ca1.fields.IOWA))
            '            .IOWA = dao_iowa.fields.iowacd
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .IOWA_IDA = Trim(dao_ca1.fields.IOWA)
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .IOWANM = dao_ca1.fields.IOWANM
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .mltplr = dao_ca1.fields.mltplr
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .QTY = dao_ca1.fields.QTY
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .REF = dao_ca1.fields.REF
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .REMARK = dao_ca1.fields.REMARK
            '        Catch ex As Exception

            '        End Try
            '        .ROWS = ii
            '        Try
            '            .sbioqty = dao_ca1.fields.sbioqty
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .sbiosqno = dao_ca1.fields.sbiosqno
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .sbiounitcd = dao_ca1.fields.sbiounitcd
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .SUNITCD = dao_ca1.fields.SUNITCD
            '        Catch ex As Exception

            '        End Try
            '    End With
            '    dao_ca2.fields.FK_IDA = main_ida
            '    dao_ca2.insert()
            '    ii += 1
            'Next

            'Dim dao_max As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_CA
            'dao_max.GET_MAX_ROW(main_ida)

            'Dim dao_ca As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_CA
            'Dim i As Integer = 0
            'Try
            '    i = dao_max.fields.ROWS + 1
            'Catch ex As Exception

            'End Try
            'For Each dao_ca.fields In p2.DRRGT_EDIT_REQUEST_CASes

            '    Dim dao_ca2 As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST_CA
            '    With dao_ca2.fields
            '        Try
            '            .AORI = dao_ca.fields.AORI
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .BASE_FORM = dao_ca.fields.BASE_FORM
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .CAS_TYPE = 2
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .ebioqty = dao_ca.fields.ebioqty
            '        Catch ex As Exception

            '        End Try

            '        Try
            '            .ebiosqno = dao_ca.fields.ebiosqno
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .ebiounitcd = dao_ca.fields.ebiounitcd
            '        Catch ex As Exception

            '        End Try
            '        'Try
            '        '    .EQTO_IOWA = dao_ca.fields.EQTO_IOWA
            '        'Catch ex As Exception

            '        'End Try

            '        Try
            '            Dim dao_iowa As New DAO_DRUG.TB_driowa
            '            dao_iowa.GetDataby_IDA(Trim(dao_ca1.fields.IOWA))
            '            .EQTO_IOWA = dao_iowa.fields.iowacd
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .IOWA_IDA = Trim(dao_ca1.fields.EQTO_IOWA)
            '        Catch ex As Exception

            '        End Try


            '        Try
            '            .EQTO_QTY = dao_ca.fields.EQTO_QTY
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .EQTO_SUNITCD = dao_ca.fields.EQTO_SUNITCD
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .IOWA = dao_ca.fields.IOWA
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .IOWANM = dao_ca.fields.IOWANM
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .mltplr = dao_ca.fields.mltplr
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .QTY = dao_ca.fields.QTY
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .REF = dao_ca.fields.REF
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .REMARK = dao_ca.fields.REMARK
            '        Catch ex As Exception

            '        End Try
            '        .ROWS = i
            '        Try
            '            .sbioqty = dao_ca.fields.sbioqty
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .sbiosqno = dao_ca.fields.sbiosqno
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .sbiounitcd = dao_ca.fields.sbiounitcd
            '        Catch ex As Exception

            '        End Try
            '        Try
            '            .SUNITCD = dao_ca.fields.SUNITCD
            '        Catch ex As Exception

            '        End Try
            '    End With
            '    dao_ca2.fields.FK_IDA = main_ida
            '    dao_ca2.insert()
            '    i += 1
            'Next

            '-------------------------------------------------------------
            'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            'dao_up.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
            'dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            'dao_up.fields.DOWNLOAD_ID = p2.DOWNLOAD_ID
            'dao_up.fields.PROCESS_ID = _ProcessID
            'dao_up.fields.UPLOAD_DATE = Date.Now
            'dao_up.fields.YEAR = Date.Now.Year
            'dao_up.fields.REF_NO = main_ida
            'dao_up.insert()
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

    Private Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = "3" Then
            Panel101.Style.Add("display", "block")
        Else
            Panel101.Style.Add("display", "none")
        End If
    End Sub
End Class