Imports Telerik.Web.UI

Public Class FRM_CER_EXP_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Sub runQuery()
        '_lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _process = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
        If Not IsPostBack Then
            If Request.QueryString("IDA") = "" Then
                Dim year_curr As Integer = 0
                year_curr = Year(Date.Now)
                If year_curr < 2500 Then
                    year_curr += 543
                End If
                txt_Year_extend.Text = year_curr
                txt_cer_DATE.Text = Date.Now.ToShortDateString
                txt_cer_exp_date.Text = Date.Now.ToShortDateString
            Else
                Dim dao As New DAO_DRUG.TB_CER_EXTEND
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                Try
                    txt_cer_DATE.Text = CDate(dao.fields.DOCUMENT_DATE).ToShortDateString()
                Catch ex As Exception

                End Try
                Try
                    txt_cer_exp_date.Text = CDate(dao.fields.EXP_DOCUMENT_DATE).ToShortDateString()
                Catch ex As Exception

                End Try

                txt_Cernumber.Text = dao.fields.CERTIFICATION_NUMBER_ALL
                txt_Year_extend.Text = dao.fields.YEAR_EXTEND

                Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
                dao_file.GetDataby_TR_ID_And_Process(dao.fields.TR_ID, dao.fields.PROCESS_ID)
                Dim bao As New BAO.AppSettings
                Dim url_load As String = ""
                Try
                    If dao.fields.IDA <> 0 Then
                        'url_load = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao_file.fields.NAME_FAKE
                        '' url_load = "~/upload/" & dao_file.fields.NAME_FAKE
                        url_load = dao_file.fields.NAME_FAKE
                        hp_file_name.Text = dao_file.fields.NAME_REAL
                        'hp_file_name.PostBackUrl = url_load


                        Dim saveLocation As String = _PATH_DEFALUT & "/upload/" & dao_file.fields.NAME_FAKE
                        hp_file_name.NavigateUrl = "../PDF/FRM_ATTACH_PREVIEW_ALL.aspx?FileName=" & saveLocation
                    End If

                Catch ex As Exception

                End Try
            End If

            If Request.QueryString("IDA") <> "" Then
                btn_save.Style.Add("display", "none")
                btn_edit.Style.Add("display", "block")
                Panel1.Style.Add("display", "block")
                'Panel5.Style.Add("display", "block")
                ImageButton1.Style.Add("display", "block")
                hp_file_name.Style.Add("display", "block")
                Dim dao As New DAO_DRUG.TB_CER_EXTEND
                dao.GetDataby_IDA(Request.QueryString("ida"))
                Try
                    If dao.fields.STATUS_ID >= 2 Then
                        btn_edit.Style.Add("display", "none")
                        FileUpload1.Style.Add("display", "none")
                    End If
                Catch ex As Exception

                End Try
            Else
                btn_save.Style.Add("display", "block")
                btn_edit.Style.Add("display", "none")
                Panel1.Style.Add("display", "none")

                hp_file_name.Style.Add("display", "none")
                ImageButton1.Style.Add("display", "none")
                'Panel5.Style.Add("display", "none")
            End If
        End If

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_CUSTOMER_EXTEND_CER_BY_FK_IDA(_lcn_ida)
        Catch ex As Exception

        End Try


        'Try
        '    dt = bao.dt
        'Catch ex As Exception

        'End Try

        RadGrid1.DataSource = dt
    End Sub

    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim dao As New DAO_DRUG.TB_CER_EXTEND_DETAIL
            dao.GetDataby_IDA(item("IDA").Text)
            If e.CommandName = "del" Then
                'dao.fields.IS_ACTIVE = False
                dao.delete()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อย');", True)
            End If
            RadGrid1.Rebind()
            RadGrid2.Rebind()
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_CUSTOMER_EXTEND_DETAIL_CER_BY_FK_HEAD(Request.QueryString("ida"))
        Catch ex As Exception

        End Try


        'Try
        '    dt = bao.dt
        'Catch ex As Exception

        'End Try

        RadGrid2.DataSource = dt
    End Sub

    Private Sub btn_right_Click(sender As Object, e As EventArgs) Handles btn_right.Click
        Dim i As Integer = 0
        For Each item As GridDataItem In RadGrid1.SelectedItems
            i += 1
        Next
        If i = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกรายการ');", True)
        Else
            For Each item As GridDataItem In RadGrid1.SelectedItems
                Dim dao_det As New DAO_DRUG.TB_CER_EXTEND_DETAIL
                Dim dao As New DAO_DRUG.TB_CER
                dao.GetDataby_IDA2(item("IDA").Text)
                With dao.fields
                    dao_det.fields.ADDRESS_DETAIL = .ADDRESS_DETAIL
                    dao_det.fields.ANALYZE_IDA = .ANALYZE_IDA
                    dao_det.fields.BUYER_COUNTRY = .BUYER_COUNTRY
                    dao_det.fields.BUYER_NAME = .BUYER_NAME
                    dao_det.fields.BUYER_STANDARD = .BUYER_STANDARD
                    dao_det.fields.CER_DATE = .CER_DATE
                    dao_det.fields.CER_FORMAT = .CER_FORMAT
                    dao_det.fields.CER_NUMBER = .CER_NUMBER
                    dao_det.fields.CER_SCOPE = .CER_SCOPE
                    dao_det.fields.CER_TYPE = .CER_TYPE
                    dao_det.fields.CERTIFICATION_NUMBER_ALL = .CERTIFICATION_NUMBER_ALL
                    dao_det.fields.CERTIFICATION_NUMBER_ALL_FOR_ANALYZE = .CERTIFICATION_NUMBER_ALL_FOR_ANALYZE
                    dao_det.fields.CITY_NAME = .CITY_NAME
                    dao_det.fields.COUNTRY_IDA = .COUNTRY_IDA
                    dao_det.fields.COUNTRY_OF_DEPARTMENT_IDA = .COUNTRY_IDA
                    dao_det.fields.CREATE_DATE = .CREATE_DATE
                    dao_det.fields.DEPARTMENT_REGIST_CER_NAME = .DEPARTMENT_REGIST_CER_NAME
                    dao_det.fields.DEPARTMENT_REGIST_CER_TYPE = .DEPARTMENT_REGIST_CER_TYPE
                    dao_det.fields.DOCUMENT_DATE = .DOCUMENT_DATE
                    dao_det.fields.ESTABLISHMENT_CONFORMS = .ESTABLISHMENT_CONFORMS
                    dao_det.fields.EXP_DOCUMENT_DATE = .EXP_DOCUMENT_DATE
                    dao_det.fields.OLD_FK_IDA = .FK_IDA
                    dao_det.fields.FK_MANUFACTURE_LOCATION_ADDRESS_ID = .FK_MANUFACTURE_LOCATION_ADDRESS_ID
                    dao_det.fields.FOREIGN_LOCATION_NAME = .FOREIGN_LOCATION_NAME
                    dao_det.fields.GLN = .GLN
                    dao_det.fields.GMP_STANDARD = .GMP_STANDARD
                    dao_det.fields.IDENTIFY = .IDENTIFY
                    dao_det.fields.IMAGE_QR_INPUT = .IMAGE_QR_INPUT
                    dao_det.fields.IMAGE_QR_OUTPUT = .IMAGE_QR_OUTPUT
                    dao_det.fields.LAB_ADDR = .LAB_ADDR
                    dao_det.fields.LAB_CITY = .LAB_CITY
                    dao_det.fields.LAB_COUNTRY_DEPARTMENT_REGIST_CB_IDA = .LAB_COUNTRY_DEPARTMENT_REGIST_CB_IDA
                    dao_det.fields.LAB_COUNTRY_IDA = .LAB_COUNTRY_IDA
                    dao_det.fields.LAB_DEPARTMENT_REGIST_CB = .LAB_DEPARTMENT_REGIST_CB
                    dao_det.fields.LAB_GLN = .LAB_GLN
                    dao_det.fields.LAB_ISO_DATE = .LAB_ISO_DATE
                    dao_det.fields.LAB_ISO_EXP_DATE = .LAB_ISO_EXP_DATE
                    dao_det.fields.LAB_ORGANIZATION_CODE = .LAB_ORGANIZATION_CODE
                    dao_det.fields.LAB_STANDARD = .LAB_STANDARD
                    dao_det.fields.LAB_ZIPCODE = .LAB_ZIPCODE
                    dao_det.fields.LCNSID = .LCNSID
                    dao_det.fields.lmdfdate = .lmdfdate
                    dao_det.fields.LOCATION_STANDARD = .LOCATION_STANDARD
                    dao_det.fields.MANUFACTURER_CONFORMS_TO = .MANUFACTURER_CONFORMS_TO
                    dao_det.fields.MANUFACTURER_LICENCE_NUMBER = .MANUFACTURER_LICENCE_NUMBER
                    dao_det.fields.MOBILE = .MOBILE
                    'dao_det.fields.NEW_DOCUMENT_DATE = 
                    dao_det.fields.OLD_IDA = .IDA
                    dao_det.fields.OLD_TR_ID = .TR_ID
                    dao_det.fields.ORGANIZATION_CODE = .ORGANIZATION_CODE
                    dao_det.fields.PICS_NAT_ALPHA3 = .PICS_NAT_ALPHA3
                    dao_det.fields.PO_OTHER = .PO_OTHER
                    dao_det.fields.RCVDATE = .RCVDATE
                    dao_det.fields.RCVNO = .RCVNO
                    dao_det.fields.REMARK = .REMARK
                    dao_det.fields.REQUEST_DATE = .REQUEST_DATE
                    dao_det.fields.STATUS_ID = .STATUS_ID
                    dao_det.fields.XML_NAME = .XML_NAME
                    dao_det.fields.ZIPCODE = .ZIPCODE
                    dao_det.fields.YEAR_EXTEND = txt_Year_extend.Text
                    dao_det.fields.FK_HEAD = Request.QueryString("ida")
                    dao_det.fields.IS_ACTIVE = 1
                End With
                dao_det.insert()

                Dim dao_cas As New DAO_DRUG.TB_CER_DETAIL_CASCHEMICAL
                dao_cas.GetDataby_FK_IDA(item("IDA").Text)
                For Each dao_cas.fields In dao_cas.datas
                    Dim dao_cas_rqt As New DAO_DRUG.TB_CER_EXTEND_CASCHEMICAL_RQT
                    With dao_cas_rqt.fields
                        .CAS_ID = dao_cas.fields.CAS_ID
                        .CAS_NAME = dao_cas.fields.CAS_NAME
                        .CAS_NO = dao_cas.fields.CAS_NO
                        .FK_IDA = dao_det.fields.IDA
                        .INN_NAME = dao_cas.fields.INN_NAME
                        '.IS_USE = 1
                        .OLD_IDA = dao_cas.fields.FK_IDA
                        .ROW_ID = dao_cas.fields.ROW_ID
                    End With
                    dao_cas_rqt.insert()
                Next

                Dim dao_manu As New DAO_DRUG.TB_CER_EXTEND_MANUFACTURE
                dao_manu.Getdata_by_FK_IDA(item("IDA").Text)
                For Each dao_manu.fields In dao_manu.datas
                    Dim dao_manu_rqt As New DAO_DRUG.TB_CER_EXTEND_MANUFACTURE_RQT
                    With dao_manu_rqt.fields
                        .ADDRESS_CITY = dao_manu.fields.ADDRESS_CITY
                        .ADDRESS_NUMBER = dao_manu.fields.ADDRESS_NUMBER
                        .CER_DATE = dao_manu.fields.CER_DATE
                        .COMPANY_NAME = dao_manu.fields.COMPANY_NAME
                        .COUNTRY = dao_manu.fields.COUNTRY
                        .COUNTRY_GMP = dao_manu.fields.COUNTRY_GMP
                        .COUNTRY_ID = dao_manu.fields.COUNTRY_ID
                        .FK_IDA = dao_det.fields.IDA
                        .GLN = dao_manu.fields.GLN
                        .LOCATION_STANDARD = dao_manu.fields.LOCATION_STANDARD
                        .NAME_ADDRESS = dao_manu.fields.NAME_ADDRESS
                        .OLD_IDA = dao_manu.fields.FK_IDA
                        .SALE_DATE = dao_manu.fields.SALE_DATE
                        .STANDARD_ID = dao_manu.fields.STANDARD_ID
                        .ZIPCODE = dao_manu.fields.ZIPCODE
                    End With
                    dao_manu_rqt.insert()
                Next

            Next
        End If
        RadGrid1.Rebind()
        RadGrid2.Rebind()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

        TR_ID = bao_tran.insert_transection_new(_process) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION

        Dim dao As New DAO_DRUG.TB_CER_EXTEND
        dao.fields.CERTIFICATION_NUMBER_ALL = txt_Cernumber.Text
        dao.fields.CTZO_UPLOAD = _CLS.CITIZEN_ID
        Try
            dao.fields.DOCUMENT_DATE = CDate(txt_cer_DATE.Text)
        Catch ex As Exception

        End Try
        Try
            dao.fields.EXP_DOCUMENT_DATE = CDate(txt_cer_exp_date.Text)
        Catch ex As Exception

        End Try
        dao.fields.TR_ID = TR_ID
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.REQUEST_DATE = Date.Now
        dao.fields.STATUS_ID = 1
        dao.fields.PROCESS_ID = Request.QueryString("process")
        dao.fields.YEAR_EXTEND = txt_Year_extend.Text
        dao.fields.FK_IDA = Request.QueryString("lcn_ida")
        dao.insert()
        ATTACH(TR_ID, _process, con_year(Date.Now.Year), "1")

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri & "&IDA=" & dao.fields.IDA
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim dao As New DAO_DRUG.TB_CER_EXTEND
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        dao.fields.CERTIFICATION_NUMBER_ALL = txt_Cernumber.Text
        Try
            dao.fields.DOCUMENT_DATE = CDate(txt_cer_DATE.Text)
        Catch ex As Exception

        End Try
        Try
            dao.fields.EXP_DOCUMENT_DATE = CDate(txt_cer_exp_date.Text)
        Catch ex As Exception

        End Try
        ATTACH(dao.fields.TR_ID, dao.fields.PROCESS_ID, con_year(Date.Now.Year), "1")
        dao.update()

        Dim uri As String = ""
        uri = Request.Url.AbsoluteUri
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
    End Sub

    Protected Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Function ATTACH(ByVal transection As String, ByVal PROCESS_ID As String, ByVal year As String, ByVal type As String) As Boolean 'ปรับ เพิ่มtype
        Dim bool As Boolean = False
        If FileUpload1.HasFile Then 'เช็คว่ามีการเบราไฟล์แล้ว

            Dim bao As New BAO.AppSettings
            Dim NAME_FAKE As String 'ตัวแปรเก็บชื่อไฟล์ที่เบรา
            Dim NAME_REAL As String 'ตัวแปรเก็บชื่อไฟล์ที่แปลงเพื่อให้สัมพันธ์กับระบบ
            NAME_REAL = FileUpload1.FileName 'NAME_REALเก็บชื่อไฟล์ที่เบรา
            Dim Array_NAME_REAL() As String = Split(NAME_REAL, ".")
            Dim Last_Length As Integer = Array_NAME_REAL.Length - 1 'ดึงนามสกุลไฟล์ที่เบรามาใช้กับ NAME_FAKE 
            NAME_FAKE = "DA-" & PROCESS_ID & "-" & year & "-" & transection & "-" & type & "." & Array_NAME_REAL(Last_Length).ToString() 'สร้างชื่อไฟล์ใหม่โดยใช้นามสกุลไฟล์เดิม
            FileUpload1.SaveAs(bao._PATH_DEFAULT & "upload\" & NAME_FAKE) 'บันทึกไฟล์ลงserverโดยใช้ชื่อที่สรางขึ้นใหม่


            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            dao.fields.NAME_FAKE = NAME_FAKE 'เก็บชื่อไฟล์ที่สร้างขึ้นใหม่เพื่อเรียกใช้
            dao.fields.NAME_REAL = NAME_REAL 'เก็บชื่อไฟล์ที่เบราไว้เก็บเผื่อไว้เฉยๆ
            dao.fields.TYPE = type 'ลำดับไฟล์เก็บไว้เรียกข้อมูล
            dao.fields.TRANSACTION_ID = transection 'เลขอ้างอิงPDFเก็บไว้เรียกข้อมูล
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.insert()
        End If


        Return bool

    End Function

    Private Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        If Request.QueryString("IDA") <> "" Then
            Dim dao As New DAO_DRUG.TB_CER_EXTEND
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH
            dao_file.GetDataby_TR_ID_And_Process(dao.fields.TR_ID, dao.fields.PROCESS_ID)
            dao_file.delete()

            Dim uri As String = ""
            uri = Request.Url.AbsoluteUri '& "&IDA=" & Request.QueryString("IDA")
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบข้อมูลเรียบร้อย'); window.location='" & uri & "';", True)
        End If
    End Sub

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_CUSTOMER_EXTEND_CAS_BY_FK_HEAD(Request.QueryString("ida"))
        Catch ex As Exception

        End Try


        RadGrid3.DataSource = dt
    End Sub

    Protected Sub btn_save_case_Click(sender As Object, e As EventArgs) Handles btn_save_case.Click
        For Each item As GridDataItem In RadGrid1.SelectedItems
            Dim dao_cas As New DAO_DRUG.TB_CER_EXTEND_CASCHEMICAL_RQT
            dao_cas.Getdata_by_ID(item("IDA").Text)
            dao_cas.fields.IS_USE = 1
            dao_cas.fields.IS_USE_STAFF = 1
            dao_cas.update()
        Next
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย'); parent.$('#ContentPlaceHolder1_btn_reload').click();", True)

        RadGrid3.Rebind()
    End Sub
End Class