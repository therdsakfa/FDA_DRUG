Public Class WebForm34
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'run_nav_new(41543)
            'Dim ws1 As New WS_Taxno_TaxnoAuthorize.WebService1
            'Dim a As String = ""
            'Try
            '    a = ws1.insert_taxno("0735560006274")
            'Catch ex As Exception

            'End Try
            'Try
            '    a = ws1.insert_taxno_authorize("0735560006274")
            'Catch ex As Exception

            'End Try


            'Dim ws2 As New WS_FDA_CITIZEN.WS_FDA_CITIZEN
            'ws2.FDA_CITIZEN("0735560006274", "1102001745831", "fusion", "P@ssw0rdfusion440")
            'Dim ws3 As New WS_TRADERS.WS_TRADER
            'ws3.CallWS_TRADER("fusion", "P@ssw0rdfusion440", "0735560006274")

            chngwtcd()
            'Dim all_days As Double = 0
            'Dim ws As New WS_GETDATE_WORKING.Service1
            'ws.GETDATE_COUNT_DAY(CDate("09-02-2561"), True, Date.Now, True, all_days, True)

        End If
    End Sub
    Public Sub run_nav_new(ByVal aaaa As Integer)
        Dim dao_h As New DAO_DRUG.TB_MAS_ADMIN_GROUP_BUTTON
        dao_h.GetData_By_Group_Order_By_Seq(aaaa)
        Dim str_all As String = ""
        For Each dao_h.fields In dao_h.datas
            If str_all = "" Then
                str_all = "<h4 class='text-center'><strong>" & dao_h.fields.GROUP_NAME & "</strong></h4>"
                Dim p_name As String = ""
                Try
                    p_name = get_page_name()
                Catch ex As Exception

                End Try
                Dim aa As Integer = 0

                Try
                    aa = aaaa
                Catch ex As Exception

                End Try
                Dim _group As Integer = 0
                If aa = 21020 Then
                    _group = 1
                Else
                    _group = 2
                End If
                '_group = 2
                Dim dao_g As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                dao_g.GetDataby_Btn_Group_and_IdGroup(dao_h.fields.GROUP_ID, aa)

                str_all &= "<ul class='nav nav-pills nav-stacked'>"
                For Each dao_g.fields In dao_g.datas
                    Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                    Dim i As Integer = 0
                    If p_name <> "" Then
                        'i = dao_u.Check_Page(p_name, _CLS.Groups)
                        Try
                            If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
                                i += 1
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                    If i = 0 Then
                        str_all &= "<li>"
                    Else
                        str_all &= "<li class='active'>"
                    End If
                    If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & "6664353" & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
                    Else
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"
                    End If

                    str_all &= "</li>"
                    'i += 1
                Next
                str_all &= "</ul><br/>"

            Else
                str_all &= "<h4 class='text-center'><strong>" & dao_h.fields.GROUP_NAME & "</strong></h4>"
                Dim p_name As String = ""
                Try
                    p_name = get_page_name()
                Catch ex As Exception

                End Try
                Dim aa As Integer = 0

                Try
                    aa = aaaa
                Catch ex As Exception

                End Try
                Dim _group As Integer = 0
                If aa = 21020 Then
                    _group = 1
                Else
                    _group = 2
                End If
                '_group = 2
                Dim dao_g As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                dao_g.GetDataby_Btn_Group_and_IdGroup(dao_h.fields.GROUP_ID, aa)

                str_all &= "<ul class='nav nav-pills nav-stacked'>"
                For Each dao_g.fields In dao_g.datas
                    Dim dao_u As New DAO_DRUG.TB_MAS_ADMIN_BUTTON
                    Dim i As Integer = 0
                    If p_name <> "" Then
                        'i = dao_u.Check_Page(p_name, _CLS.Groups)
                        Try
                            If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
                                i += 1
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                    If i = 0 Then
                        str_all &= "<li>"
                    Else
                        str_all &= "<li class='active'>"
                    End If
                    If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & "6664353" & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
                    Else
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "' >" & dao_g.fields.BTN_NAME & "</a>"
                    End If

                    str_all &= "</li>"
                    'i += 1
                Next
                str_all &= "</ul><br/>"
            End If
            Literal1.Text = str_all
        Next


    End Sub

    Function get_page_name()
        Dim p_name As String = ""
        p_name = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
        Return p_name
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim file_ex As String = ""
        file_ex = file_extension_nm(FileUpload1.FileName)
    End Sub

    Sub chngwtcd()
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim chn As New DAO_CPN.ClsDBsyschngwt
        Dim item As New ListItem("-----รายชื่อจังหวัด-----", "0")
        chn.GetDataAll()
        ddl_chngwt.DataSource = chn.datas
        ddl_chngwt.DataTextField = "thachngwtnm"
        ddl_chngwt.DataValueField = "chngwtcd"
        ddl_chngwt.DataBind()
        ddl_chngwt.Items.Insert(0, item)
    End Sub

    Sub amphrcd()   'เป็นการนำข้อมูลในตารางใส่ DropDown  ข้อมูลอำเภอ
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim amp As New DAO_CPN.ClsDBsysamphr
        amp.GetDataby_chngwtcd(ddl_chngwt.SelectedValue)
        ddl_amphr.DataSource = amp.datas
        ddl_amphr.DataTextField = "thaamphrnm"
        ddl_amphr.DataValueField = "amphrcd"
        ddl_amphr.DataBind()
        ddl_amphr.DropDownInsertDataFirstRow("-----รายชื่ออำเภอ-----", "0")
    End Sub
    Sub thmblcd()      'เป็นการนำข้อมูลในตารางใส่ DropDown  ข้อมูลตำบล
        Dim dao_loca_addr As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim thm As New DAO_CPN.ClsDBsysthmbl
        thm.GetDataby_thmbl(ddl_chngwt.SelectedValue, ddl_amphr.SelectedValue)
        ddl_thumbol.DataSource = thm.datas
        ddl_thumbol.DataTextField = "thathmblnm"
        ddl_thumbol.DataValueField = "thmblcd"
        ddl_thumbol.DataBind()
        ddl_thumbol.DropDownInsertDataFirstRow("-----รายชื่อตำบล-----", "0")
    End Sub
    Protected Sub ddl_chngwt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_chngwt.SelectedIndexChanged

        ddl_amphr.Items.Clear()
        ddl_thumbol.Items.Clear()
        amphrcd()

    End Sub

    Protected Sub ddl_amphr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_amphr.SelectedIndexChanged

        thmblcd()


    End Sub

    Protected Sub btn_hno_Click(sender As Object, e As EventArgs) Handles btn_hno.Click
        Dim houseno As String = ""
        houseno = txt_thacode_id_lo.Text

        If houseno = "" Then
            'alert_normal("กรุณาระบุรหัสประจำบ้าน")
            Response.Write("<script type='text/javascript'>alert('กรุณาระบุรหัสประจำบ้าน');</script> ")
            Response.Write("</script type >")
        Else
            Dim ws As New WS_Taxno_TaxnoAuthorize.WebService1
            Dim obj As New WS_Taxno_TaxnoAuthorize.HOUSENO
            obj = ws.getDetail_Houseno_by_addressID(houseno)

            txt_thaaddr_lo.Text = obj.Address_No
            txt_thamu_lo.Text = obj.Address_Moo
            txt_thasoi_lo.Text = obj.Address_Soi
            txt_tharoad_lo.Text = obj.Address_Road
            txt_zipcode_lo.Text = obj.PostCode
            Lb_tel_lo.Text = obj.Tel01
            txt_fax_lo.Text = ""

            ddl_chngwt.DropDownSelectText(obj.Address_Province)
            amphrcd()
            ddl_amphr.DropDownSelectText(obj.Address_Amphur)
            thmblcd()
            ddl_thumbol.DropDownSelectText(obj.Address_Tumbol)
        End If
    End Sub

    Protected Sub btn_chk_int_Click(sender As Object, e As EventArgs) Handles btn_chk_int.Click
        Dim _price As Double = 0
        Dim result1 As String = txt_chk.Text
        If Double.TryParse(result1, _price) Then
            Dim ss As String = _price
        End If
    End Sub
End Class