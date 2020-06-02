Public Class POPUP_DRUG_PRODUCT_ID_LINK_SELECT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _process As String
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            bind_ddl_product()
            hide_and_show_lbl()
            'lbl_linktype.Style.Add("display", "none")
            'lbl_linktype2.Style.Add("display", "none")
            'txt_center_link.Style.Add("display", "none")
            'txt_center_link2.Style.Add("display", "none")
        End If
    End Sub
    Sub hide_and_show_lbl()
        Try
            If RadioButtonList1.SelectedValue = "1" Then
                lbl_linktype.Style.Add("display", "block")
                txt_center_link.Style.Add("display", "block")
                lbl_linktype2.Style.Add("display", "none")
                RadNumericTextBox1.Visible = False
                txt_center_link.TextMode = TextBoxMode.SingleLine
                lbl_linktype.Text = RadioButtonList1.SelectedItem.Text
                lbl_linktype.Text = "เปลี่ยนชื่อการค้า"
            ElseIf RadioButtonList1.SelectedValue = "2" Then
                lbl_linktype.Style.Add("display", "none")
                txt_center_link.Style.Add("display", "none")
                lbl_linktype2.Style.Add("display", "block")
                RadNumericTextBox1.Visible = True
                'txt_center_link.TextMode = TextBoxMode.Number
                lbl_linktype2.Text = "ระบุความแรง สัดส่วนตัวคูณของสูตร"
                lbl_linktype.Text = RadioButtonList1.SelectedItem.Text
            ElseIf RadioButtonList1.SelectedValue = "3" Then
                lbl_linktype.Style.Add("display", "block")
                txt_center_link.Style.Add("display", "block")
                lbl_linktype2.Style.Add("display", "block")
                RadNumericTextBox1.Visible = True

                lbl_linktype.Text = "เปลี่ยนชื่อการค้า"
                lbl_linktype2.Text = "ระบุความแรง สัดส่วนตัวคูณของสูตร"
                txt_center_link.TextMode = TextBoxMode.SingleLine
                'txt_center_link2.TextMode = TextBoxMode.Number
            Else
                lbl_linktype.Style.Add("display", "none")
                txt_center_link.Style.Add("display", "none")
                lbl_linktype2.Style.Add("display", "none")
                RadNumericTextBox1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub bind_ddl_product()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'bao.SP_DRUG_PRODUCT_ID_BY_FK_IDA2(Request.QueryString("lct_ida"))
        Try
            bao.SP_DRUG_PRODUCT_ID_BY_IDEN_SELECT(_CLS.CITIZEN_ID_AUTHORIZE)
        Catch ex As Exception

        End Try

        dt = bao.dt
        ddl_product.DataSource = dt
        ddl_product.DataTextField = "LCNNO_DISPLAY"
        ddl_product.DataValueField = "IDA"
        ddl_product.DataBind()

    End Sub
    Function chk_value() As Boolean
        Dim bool As Boolean = True
        Dim results As Integer = 0
        Try
            If RadioButtonList1.SelectedValue <> "1" Or RadioButtonList1.SelectedValue <> "" Then
                If Int32.TryParse(RadNumericTextBox1.Text, results) Then
                    results = True
                Else
                    results = False
                End If
            End If
        Catch ex As Exception
            results = False
        End Try
        Return bool
    End Function
    Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        Dim _dbl_test As Double = 0
        Try
            _dbl_test = RadNumericTextBox1.Value
        Catch ex As Exception

        End Try
        Dim link_type As String = ""
        Try
            link_type = RadioButtonList1.SelectedValue
        Catch ex As Exception

        End Try
        If link_type = "1" Then
            insert_link_data()
        Else
            If _dbl_test <> 0 Then
                insert_link_data()
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ข้อมูลที่กรอกควรเป็นตัวเลขเท่านั้น');", True)
            End If
        End If

        
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Try
            hide_and_show_lbl()
        Catch ex As Exception

        End Try

        'Try
        '    lbl_linktype.Text = RadioButtonList1.SelectedItem.Text
        'Catch ex As Exception

        'End Try

    End Sub
    Sub insert_link_data()
        Dim link_type As String = ""
        Try
            link_type = RadioButtonList1.SelectedValue
        Catch ex As Exception

        End Try
        If link_type <> "" Then

            Dim dao1 As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            dao1.GetDataby_IDA(ddl_product.SelectedValue)

            Dim dao_in As New DAO_DRUG.TB_DRUG_PRODUCT_ID
            If link_type = "1" Then
                dao_in.fields.TRADE_NAME = txt_center_link.Text
            Else
                dao_in.fields.TRADE_NAME = dao1.fields.TRADE_NAME
            End If

            dao_in.fields.TRADE_NAME_ENG = dao1.fields.TRADE_NAME
            Try
                dao_in.fields.IS_BE = dao1.fields.IS_BE
            Catch ex As Exception

            End Try
            Try
                dao_in.fields.ctgcd = dao1.fields.ctgcd
            Catch ex As Exception

            End Try
            dao_in.fields.DRUG_NAME_OR_CODE = dao1.fields.DRUG_NAME_OR_CODE

            If link_type = "2" Then
                dao_in.fields.STRENGTH_DRUG = RadNumericTextBox1.Value
            Else
                dao_in.fields.STRENGTH_DRUG = dao1.fields.STRENGTH_DRUG
            End If

            If link_type = "3" Then
                dao_in.fields.TRADE_NAME = txt_center_link.Text
                dao_in.fields.STRENGTH_DRUG = RadNumericTextBox1.Text
            End If

            dao_in.fields.TERM_TO_USE = dao1.fields.TERM_TO_USE
            dao_in.fields.FK_IDA = dao1.fields.FK_IDA
            dao_in.fields.STATUS_ID = 1
            dao_in.fields.CITIZEN_ID_AUTHORIZE = dao1.fields.CITIZEN_ID_AUTHORIZE
            dao_in.fields.IDENTIFY = dao1.fields.CITIZEN_ID_AUTHORIZE
            dao_in.fields.PVNCD = dao1.fields.PVNCD
            dao_in.fields.PHYSIC_UNIT = dao1.fields.PHYSIC_UNIT
            dao_in.fields.IS_BIO = dao1.fields.IS_BIO
            dao_in.fields.BIO_PACK = dao1.fields.BIO_PACK
            dao_in.fields.BIO_UNIT = dao1.fields.BIO_UNIT
            dao_in.fields.DRUG_NATURE = dao1.fields.DRUG_NATURE
            dao_in.fields.REMARK = dao1.fields.REMARK
            dao_in.fields.LCN_IDA = dao1.fields.LCN_IDA
            Try
                dao_in.fields.NATIONAL_TYPE = dao1.fields.NATIONAL_TYPE
            Catch ex As Exception

            End Try
            If Request.QueryString("c") <> "" Then
                dao_in.fields.HEAD_PRODUCT_IDA = ddl_product.SelectedValue
            End If
            dao_in.insert()
            Dim id_head As Integer = 0
            Try
                id_head = dao_in.fields.IDA
            Catch ex As Exception

            End Try


            Dim dao_d1 As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
            dao_d1.GetDataby_FK_IDA(ddl_product.SelectedValue)
            For Each dao_d1.fields In dao_d1.datas
                Dim dao_i As New DAO_DRUG.TB_DRUG_PRODUCT_IOWA
                dao_i.fields.FK_IDA = id_head
                dao_i.fields.IOWACD = dao_d1.fields.IOWACD
                If link_type = "3" Or link_type = "2" Then
                    dao_i.fields.DOSAGE = dao_d1.fields.DOSAGE * RadNumericTextBox1.Value
                Else
                    dao_i.fields.DOSAGE = dao_d1.fields.DOSAGE
                End If

                dao_i.fields.UNIT_ID = dao_d1.fields.UNIT_ID
                dao_i.insert()
            Next

            Dim dao_d2 As New DAO_DRUG.TB_DRUG_PRODUCT_ATC
            dao_d2.GetDataby_FK_IDA(ddl_product.SelectedValue)
            For Each dao_d2.fields In dao_d2.datas
                Dim dao_i As New DAO_DRUG.TB_DRUG_PRODUCT_ATC
                dao_i.fields.ATC_IDA = dao_d2.fields.ATC_IDA
                dao_i.fields.FK_IDA = id_head
                dao_i.fields.ATC_CODE = dao_d2.fields.ATC_CODE
                dao_i.fields.ATC_IDA = dao_d2.fields.ATC_IDA
                dao_i.insert()
            Next

            Dim dao_d3 As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
            dao_d3.GetDataby_FK_IDA(ddl_product.SelectedValue)
            For Each dao_d3.fields In dao_d3.datas
                Dim dao_i As New DAO_DRUG.TB_DRUG_PRODUCT_ADDR
                With dao_i.fields
                    .amphrcd1 = dao_d3.fields.amphrcd1
                    .amphrcd2 = dao_d3.fields.amphrcd2
                    .amphrcd3 = dao_d3.fields.amphrcd3
                    .chngwtcd1 = dao_d3.fields.chngwtcd1
                    .chngwtcd2 = dao_d3.fields.chngwtcd2
                    .chngwtcd3 = dao_d3.fields.chngwtcd3
                    .thmblcd1 = dao_d3.fields.thmblcd1
                    .thmblcd2 = dao_d3.fields.thmblcd2
                    .thmblcd3 = dao_d3.fields.thmblcd3
                    .tel1 = dao_d3.fields.tel1
                    .tel2 = dao_d3.fields.tel2
                    .tel3 = dao_d3.fields.tel3
                    .thaaddr1 = dao_d3.fields.thaaddr1
                    .thaaddr2 = dao_d3.fields.thaaddr2
                    .thaaddr3 = dao_d3.fields.thaaddr3
                    '-----------------------
                    .thaamphrnm1 = dao_d3.fields.thaamphrnm1
                    .thaamphrnm2 = dao_d3.fields.thaamphrnm2
                    .thaamphrnm3 = dao_d3.fields.thaamphrnm3
                    .thachngwtnm1 = dao_d3.fields.thachngwtnm1
                    .thachngwtnm2 = dao_d3.fields.thachngwtnm2
                    .thachngwtnm3 = dao_d3.fields.thachngwtnm3
                    .thathmblnm1 = dao_d3.fields.thathmblnm1
                    .thathmblnm2 = dao_d3.fields.thathmblnm2
                    .thathmblnm3 = dao_d3.fields.thathmblnm3
                    '-------------------------
                    .thamu1 = dao_d3.fields.thamu1
                    .thamu2 = dao_d3.fields.thamu2
                    .thamu3 = dao_d3.fields.thamu3
                    .thanameplace1 = dao_d3.fields.thanameplace1
                    .thanameplace2 = dao_d3.fields.thanameplace2
                    .thanameplace3 = dao_d3.fields.thanameplace3
                    .zipcode1 = dao_d3.fields.zipcode1
                    .zipcode2 = dao_d3.fields.zipcode2
                    .zipcode3 = dao_d3.fields.zipcode3
                    .thasoi1 = dao_d3.fields.thasoi1
                    .thasoi2 = dao_d3.fields.thasoi2
                    .thasoi3 = dao_d3.fields.thasoi3
                    .tharoad1 = dao_d3.fields.tharoad1
                    .tharoad2 = dao_d3.fields.tharoad2
                    .tharoad3 = dao_d3.fields.tharoad3
                    .FK_IDA = id_head

                    .FRGN_CITY_NAME = dao_d3.fields.FRGN_CITY_NAME
                    .FRGN_FULLADDR = dao_d3.fields.FRGN_FULLADDR
                    .FRGN_NAME = dao_d3.fields.FRGN_NAME
                    .FRGN_ZIPCODE = dao_d3.fields.FRGN_ZIPCODE
                    Try
                        .NATIONAL_CD = dao_d3.fields.NATIONAL_CD
                    Catch ex As Exception

                    End Try

                End With

                dao_i.insert()
                alert("บันทึกข้อมูลเรียบร้อย")
            Next
        Else

        End If
    End Sub
End Class