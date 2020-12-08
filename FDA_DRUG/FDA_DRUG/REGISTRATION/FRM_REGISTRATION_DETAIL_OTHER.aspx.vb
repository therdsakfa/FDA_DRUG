Imports Telerik.Web.UI
Public Class FRM_REGISTRATION_DETAIL_OTHER
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UC_CHEM.bind_unit()
            UC_CHEM.bind_unit_head()
            UC_CHEM.bind_unit_each()
            UC_DRUG_ATC1.bind_ddl_atc()
            UC_OTHER_DATA.bind_ddl()
            ' UC_REGIST_DETAIL.bind_drug_type()

            UC_PRODUCCER1.bind_nat()
            'UC_ANIMAL1.bind_ddl_dramlsubtp()
            'UC_ANIMAL1.bind_ddl_dramltype()
            'UC_ANIMAL1.bind_ddl_dramlusetp()
            'UC_ANIMAL1.bind_ddl_dramltype()

            Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_re.GetDataby_IDA(Request.QueryString("IDA"))
            Dim lcntpcd As String = ""
            Try
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                dao_da.GetDataby_IDA(dao_re.fields.FK_IDA)
                lcntpcd = dao_da.fields.lcntpcd
            Catch ex As Exception

            End Try

            Try
                txt_package.Text = dao_re.fields.PACKAGE_DETAIL
            Catch ex As Exception

            End Try
            'RadTabStrip1
            If Request.QueryString("process") = "130002" Then

            Else

            End If
            If Request.QueryString("tab") <> "" Then
                For Each rt As RadTab In RadTabStrip1.Tabs
                    If rt.Value = Request.QueryString("tab") Then
                        rt.Selected = True
                        If Request.QueryString("tab") = "5" Then
                            RadPageView4.Selected = True
                            'ElseIf Request.QueryString("tab") = "11" Then
                            '    RadPageView10.Selected = True
                        End If

                    End If
                Next
                'If lcntpcd.Contains("ผย") Then
                '    Panel1.Style.Add("display", "none")
                '    Panel2.Style.Add("display", "block")
                'ElseIf lcntpcd.Contains("นย") Then
                '    Panel1.Style.Add("display", "block")
                '    Panel2.Style.Add("display", "none")
                'End If
            End If
            'For Each rt As RadTab In RadTabStrip1.Tabs
            '    If Request.QueryString("process") = "130002" Or Request.QueryString("process") = "130004" Then
            '        If rt.Value = "11" Then
            '            rt.Style.Add("display", "block")
            '            RadPageView10.Style.Add("display", "block")
            '        End If
            '    Else
            '        If rt.Value = "11" Then
            '            rt.Style.Add("display", "none")
            '        End If
            '    End If
            'Next


            'If Request.QueryString("process") = "130002" Or Request.QueryString("process") = "130004" Then
            '    RadTabStrip1.Tabs(9).Visible = True   '.Style.Add("Visible", "True")

            '    'RadPageView10.Style.Add("display", "block")
            'Else

            'End If

            If Request.QueryString("tt") <> "" Then
                'btn_save_pack.Enabled = False
                btn_save_pack.Visible = False

            End If

            If Request.QueryString("staff") = 1 Then
                RadTabStrip1.FindTabByText("2.ขนาดบรรจุ").ForeColor = Drawing.Color.Black
                RadTabStrip1.FindTabByText("3.สูตรสาร").ForeColor = Drawing.Color.Black
                RadTabStrip1.FindTabByText("4.1 ผู้ผลิตต่างประเทศ").ForeColor = Drawing.Color.Black
                RadTabStrip1.FindTabByText("4.2 ผู้ผลิตในประเทศ").ForeColor = Drawing.Color.Black
            End If

            'RadTabStrip1.SelectedTab.Value = Request.QueryString("tab")
        End If
    End Sub

    Private Sub FRM_REGISTRATION_DETAIL_OTHER_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        UC_PACKAGING_DETAIL1.bind_lbl_unit()
    End Sub

    Protected Sub btn_save_pack_Click(sender As Object, e As EventArgs) Handles btn_save_pack.Click
        Dim dao_re As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao_re.GetDataby_IDA(Request.QueryString("IDA"))
        dao_re.fields.PACKAGE_DETAIL = txt_package.Text
        dao_re.update()

        Response.Write("<script type='text/javascript'>window.alert('บันทึกเรียบร้อย');</script> ")
    End Sub

End Class