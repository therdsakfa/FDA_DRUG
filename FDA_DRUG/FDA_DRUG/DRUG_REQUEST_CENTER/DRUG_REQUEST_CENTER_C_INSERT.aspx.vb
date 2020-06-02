Public Class DRUG_REQUEST_CENTER_C_INSERT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private PROCESS_ID As String = "1007002"
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try

        If _CLS Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_ddl_WORK_GROUP()
            ddl_type_req()
            txt_date.Text = Date.Now.ToShortDateString()

        End If
    End Sub

    Private Sub btn_chk_r_no_Click(sender As Object, e As EventArgs) Handles btn_chk_r_no.Click
        Dim bool As Boolean = chk_r_exist(txt_r_no.Text)
        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        dao.get_data_by_rno(txt_r_no.Text)
        If bool = True Then
            Try
                bind_ddl_WORK_GROUP()
                Try
                    ddl_WORK_GROUP.DropDownSelectData(dao.fields.WORK_GROUP)
                Catch ex As Exception

                End Try
                ddl_type_req()
                Try
                    ddl_category_requests.DropDownSelectData(dao.fields.TYPE_REQUEST)
                Catch ex As Exception

                End Try


                'ddl_WORK_GROUP.DropDownSelectData(dao.fields.WORK_GROUP)
                'ddl_type_req()
                'bind_addr()
            Catch ex As Exception

            End Try

            txt_company.Text = dao.fields.CITIZEN_AUTHIRIZE
            txt_citizen_id.Text = dao.fields.CITIZEN_ID
            txt_DRUG_NAME_THAI.Text = dao.fields.TRADENAME
            txt_DRUG_NAME_ENG.Text = dao.fields.TRADENAME_ENG
            lbl_company.Text = dao.fields.ALLOW_NAME
            txt_lcnno.Text = dao.fields.LCNNO_DISPLAY
            txt_product_id.Text = dao.fields.PRODUCT_ID
            HiddenField1.Value = dao.fields.IDA
            txt_Other_detail.Text = dao.fields.OTHER_DETAIL
            txt_TABEAN_NUMBER.Text = dao.fields.TABEAN_DISPLAY
            set_citizen()
            chk_company()
            Try
                ddl_category_requests.DropDownSelectData(dao.fields.TYPE_REQUEST)
            Catch ex As Exception

            End Try
            Try
                ddl_placename.DropDownSelectData(dao.fields.FK_LOCATION_IDA)
            Catch ex As Exception

            End Try
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If
    End Sub
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
        Catch ex As Exception
            fullname = "ไม่พบข้อมูล กรุณาตรวจสอบเลขนิติบุคคล/เลขบัตรประชาชน"
        End Try

        Return fullname
    End Function
    Sub ddl_type_req()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_TYPE_REQUESTS_BY_GROUP(ddl_WORK_GROUP.SelectedItem.Value)
        ddl_category_requests.DataSource = dt
        ddl_category_requests.DataTextField = "TYPE_REQUESTS_NAME"
        ddl_category_requests.DataValueField = "TYPE_REQUESTS_ID"
        ddl_category_requests.DataBind()
    End Sub
    Sub set_ddl_place()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_LOCATION_ADDRESS_BY_IDENTIFY(txt_company.Text)

        ddl_placename.DataSource = dt
        ddl_placename.DataValueField = "IDA"
        ddl_placename.DataTextField = "thanameplace"
        ddl_placename.DataBind()
    End Sub

    Protected Sub btn_chk_citizen_Click(sender As Object, e As EventArgs) Handles btn_chk_citizen.Click
        set_citizen()
    End Sub

    Protected Sub btn_company_Click(sender As Object, e As EventArgs) Handles btn_company.Click
        chk_company()
    End Sub
    Function Count_Null() As Integer
        Dim null_no As Integer = 0
        If txt_nameplace_key.Text = "" Then
            null_no += 1
        End If
        If txt_fulladdr.Text = "" Then
            null_no += 1
        End If
        Return null_no
    End Function
    Public Sub set_data(ByRef dao As DAO_DRUG.TB_DRUG_REQUEST_CENTER)
        dao.fields.CITIZEN_AUTHIRIZE = txt_company.Text
        dao.fields.CITIZEN_ID = txt_citizen_id.Text
        dao.fields.fulladdr = txt_fulladdr.Text
        Try
            dao.fields.CITIZEN_UPLOAD = _CLS.CITIZEN_ID
        Catch ex As Exception

        End Try

        Try
            dao.fields.FK_LOCATION_IDA = ddl_placename.SelectedValue
        Catch ex As Exception
            dao.fields.FK_LOCATION_IDA = 0
        End Try
        dao.fields.FK_PRODUCT_IDA = 0
        dao.fields.LCN_IDA = 0
        Try
            dao.fields.PLACENAME = ddl_placename.SelectedItem.Text
        Catch ex As Exception

        End Try

        dao.fields.PVNCD = _CLS.PVCODE
        Try
            dao.fields.REQUEST_DATE = CDate(txt_date.Text)
        Catch ex As Exception

        End Try
        dao.fields.TRADENAME = txt_DRUG_NAME_THAI.Text
        dao.fields.TRADENAME_ENG = txt_DRUG_NAME_ENG.Text
        dao.fields.TYPE_REQUEST = ddl_category_requests.SelectedValue
        dao.fields.TYPE_REQUEST_NAME = ddl_category_requests.SelectedItem.Text
        dao.fields.WORK_GROUP = ddl_WORK_GROUP.SelectedValue
        dao.fields.ALLOW_NAME = lbl_company.Text
        dao.fields.LCNNO_DISPLAY = txt_lcnno.Text
        dao.fields.PRODUCT_ID = txt_product_id.Text

        dao.fields.OTHER_DETAIL = txt_Other_detail.Text
        dao.fields.TABEAN_DISPLAY = txt_TABEAN_NUMBER.Text
    End Sub
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim bool As Boolean = chk_r_exist(txt_r_no.Text)

        If bool = True Then
            Dim count_c As Integer = 0
            Dim dao_count_c As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
            count_c = dao_count_c.Count_R(txt_r_no.Text)
            If count_c <= 1 Then
                If ddl_placename.Items.Count = 0 Then
                    If Count_Null() = 0 Then
                        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                        set_data(dao)
                        dao.fields.ACTIVE = "1"
                        dao.insert()
                        Dim ida As Integer = 0
                        Try
                            ida = dao.fields.IDA
                        Catch ex As Exception

                        End Try

                        dao = New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                        dao.GetDataby_IDA(ida)
                        Dim bao As New BAO.GenNumber
                        Dim rcvno As String = ""
                        Dim rcvno_display As String = ""
                        rcvno = bao.GEN_RCVNO_REQUEST(con_year(Date.Now.Year), _CLS.PVCODE, "2", txt_lcnno.Text, "", ddl_category_requests.SelectedValue, ida, ddl_category_requests.SelectedItem.Text)
                        'con_year(Date.Now.Year),_CLS.PVCODE, "1", txt_lcnno.Text, "", ddl_category_requests.SelectedValue, ida, ddl_category_requests.SelectedItem.Text)
                        dao.fields.RCVNO = rcvno
                        dao.fields.RCVNO_DISPLAY = rcvno & "-C"
                        dao.fields.REQUEST_CENTER_TYPE = 2
                        Try
                            dao.fields.HEAD_IDA = HiddenField1.Value
                        Catch ex As Exception

                        End Try
                        dao.update()
                        alert("บันทึกข้อมูลเรียบร้อยแล้ว")
                    Else
                        Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเพิ่มชื่อสถานที่และที่อยู่');</script> ")
                    End If
                Else
                    Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                    set_data(dao)
                    dao.fields.ACTIVE = "1"
                    dao.insert()
                    Dim ida As Integer = 0
                    Try
                        ida = dao.fields.IDA
                    Catch ex As Exception

                    End Try

                    dao = New DAO_DRUG.TB_DRUG_REQUEST_CENTER
                    dao.GetDataby_IDA(ida)
                    Dim bao As New BAO.GenNumber
                    Dim rcvno As String = ""
                    Dim rcvno_display As String = ""
                    rcvno = bao.GEN_RCVNO_REQUEST(con_year(Date.Now.Year), _CLS.PVCODE, "2", txt_lcnno.Text, "", ddl_category_requests.SelectedValue, ida, ddl_category_requests.SelectedItem.Text)
                    'con_year(Date.Now.Year),_CLS.PVCODE, "1", txt_lcnno.Text, "", ddl_category_requests.SelectedValue, ida, ddl_category_requests.SelectedItem.Text)
                    dao.fields.RCVNO = rcvno
                    dao.fields.RCVNO_DISPLAY = rcvno & "-C"
                    dao.fields.REQUEST_CENTER_TYPE = 2
                    Try
                        dao.fields.HEAD_IDA = HiddenField1.Value
                    Catch ex As Exception

                    End Try
                    dao.update()
                    alert("บันทึกข้อมูลเรียบร้อยแล้ว")
                End If
                
            Else
                alertERROR("ไม่สามารถใช้เลขรับคำร้องซ้ำได้")
            End If


        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาตรวจสอบเลขรับคำร้อง');", True)
        End If
        
    End Sub
    Sub alertERROR(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent();</script> ")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Private Sub btn_chk_product_id_Click(sender As Object, e As EventArgs) Handles btn_chk_product_id.Click
        chk_product_id()
    End Sub
    Function chk_r_exist(ByVal r_no As String) As Boolean
        Dim bool As Boolean = False
        Dim dao As New DAO_DRUG.TB_DRUG_REQUEST_CENTER
        dao.get_data_by_rno(r_no)
        Dim i As Integer = 0
        For Each dao.fields In dao.datas
            i += 1
        Next
        If i > 0 Then
            bool = True
        End If
        Return bool
    End Function

    Sub chk_product_id()
        Dim dao As New DAO_DRUG.TB_DRUG_PRODUCT_ID
        dao.GetDataby_product(txt_product_id.Text)
        Dim i As Integer = 0
        For Each dao.fields In dao.datas
            i += 1
        Next
        If i > 0 Then
            txt_DRUG_NAME_THAI.Text = dao.fields.TRADE_NAME
            txt_DRUG_NAME_ENG.Text = dao.fields.TRADE_NAME_ENG
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
        End If
    End Sub
    Sub set_citizen()
        Dim txt As String = ""
        txt = set_name_company(txt_citizen_id.Text)
        lbl_request_name.Text = txt
    End Sub
    Sub chk_company()
        Dim txt As String = ""
        txt = set_name_company(txt_company.Text)
        lbl_company.Text = txt
        set_ddl_place()
    End Sub

    Private Sub bind_ddl_WORK_GROUP()
        Dim dao As New DAO_DRUG.TB_MAS_NEW_WORK_GROUP
        dao.GetDataAll()
        ddl_WORK_GROUP.DataSource = dao.datas
        ddl_WORK_GROUP.DataTextField = "WORK_GROUP"
        ddl_WORK_GROUP.DataValueField = "IDA"
        ddl_WORK_GROUP.DataBind()
        'Dim dao As New DAO_DRUG.TB_MAS_WORK_GROUP
        'dao.GetDataAll()
        'ddl_WORK_GROUP.DataSource = dao.datas
        'ddl_WORK_GROUP.DataTextField = "WORK_GROUP_NAME"
        'ddl_WORK_GROUP.DataValueField = "WORK_GROUP_ID"
        'ddl_WORK_GROUP.DataBind()
    End Sub
    Private Sub ddl_WORK_GROUP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_WORK_GROUP.SelectedIndexChanged
        ddl_type_req()
    End Sub
    Sub bind_addr()
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        Try
            dt = bao.SP_CUSTOMER_LCT_BY_LCT_IDA(ddl_placename.SelectedValue)
            For Each dr As DataRow In dt.Rows
                txt_fulladdr.Text = dr("fulladdr")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ddl_placename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_placename.SelectedIndexChanged
        bind_addr()

    End Sub
End Class