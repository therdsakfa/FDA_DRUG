Imports Telerik.Web.UI

Public Class FRM_EXTEND_TIME_LOCATION_SEARCH_PAY
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub
    
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dao As New DAO_XML_DRUG_LCN.TB_XML_SEARCH_DRUG_LCN
        Dim urls As String = ""


        If txt_CITIZEN_AUTHORIZE.Text <> "" Then
            Try
                dao.GetDataby_identify(txt_CITIZEN_AUTHORIZE.Text)
                If dao.fields.IDA <> 0 Then
                    _CLS.CITIZEN_ID_AUTHORIZE = txt_CITIZEN_AUTHORIZE.Text
                    urls = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug&identify=" & txt_CITIZEN_AUTHORIZE.Text
                    Session("CLS") = _CLS
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
                Else
                    Dim dao2 As New DAO_DRUG.ClsDBdalcn
                    dao2.GetDataby_IDEN(txt_CITIZEN_AUTHORIZE.Text)
                    If dao2.fields.IDA <> 0 Then
                        _CLS.CITIZEN_ID_AUTHORIZE = txt_CITIZEN_AUTHORIZE.Text
                        urls = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug&identify=" & txt_CITIZEN_AUTHORIZE.Text
                        Session("CLS") = _CLS
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
                    End If
                End If
            Catch ex As Exception
                alert("ไม่พบข้อมูล")
            End Try

        ElseIf txt_lcnsid.Text <> "" Then
            Try
                dao.GetDataby_lcnsid(txt_lcnsid.Text)
                If dao.fields.IDA <> 0 Then
                    _CLS.CITIZEN_ID_AUTHORIZE = dao.fields.identify
                    Session("CLS") = _CLS
                    urls = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug&identify=" & dao.fields.Identify
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
                Else
                    Dim dao2 As New DAO_DRUG.ClsDBdalcn
                    dao2.GetDataby_lcnsid(txt_lcnsid.Text)
                    If dao2.fields.IDA <> 0 Then
                        _CLS.CITIZEN_ID_AUTHORIZE = dao.fields.Identify
                        Session("CLS") = _CLS
                        urls = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=staffdrug&identify=" & dao.fields.Identify
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
                    End If

                End If
            Catch ex As Exception
                alert("ไม่พบข้อมูล")
            End Try
        End If



        'If txt_CITIZEN_AUTHORIZE.Text <> "" Then
        '    Try
        '        dao.GetDataby_identify(txt_CITIZEN_AUTHORIZE.Text)
        '        If dao.fields.IDA <> 0 Then
        '            _CLS.CITIZEN_ID_AUTHORIZE = txt_CITIZEN_AUTHORIZE.Text
        '            urls = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&identify=" & txt_CITIZEN_AUTHORIZE.Text
        '            Session("CLS") = _CLS
        '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
        '        End If
        '    Catch ex As Exception
        '        alert("ไม่พบข้อมูล")
        '    End Try

        'ElseIf txt_lcnsid.Text <> "" Then
        '    Try
        '        dao.GetDataby_lcnsid(txt_lcnsid.Text)
        '        If dao.fields.IDA <> 0 Then
        '            _CLS.CITIZEN_ID_AUTHORIZE = dao.fields.identify
        '            Session("CLS") = _CLS
        '            urls = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&identify=" & dao.fields.identify
        '            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & urls & "'); ", True)
        '        End If
        '    Catch ex As Exception
        '        alert("ไม่พบข้อมูล")
        '    End Try
        'End If
    End Sub
End Class