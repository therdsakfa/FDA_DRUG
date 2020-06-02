Public Class MAIN_PRODUCT_ID
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("staff") <> "" Then
            HyperLink1.Style.Add("display", "block")
        End If
        Try
            If Request.QueryString("FK_IDA") <> "" Then
                'HyperLink1.NavigateUrl = "../MAIN/FRM_LCN_NEWS.aspx?FK_IDA=" & Request.QueryString("FK_IDA")
            Else
                'HyperLink1.NavigateUrl = "../MAIN/FRM_LCN_NEWS.aspx"
            End If
        Catch ex As Exception

        End Try
        RunSession()

        If Not IsPostBack Then

            hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM
            hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER
            Dim lt_str As String = ""
            If _CLS.SYSTEM_ID = "8738" Or _CLS.SYSTEM_ID = "8734" Then
                '              <div class="nav-catagory"  style="background: #ffed33">
                '	<div class="inner">
                '		<h3></h3>
                '	</div>
                '</div>
                lt_str = "<div class='nav-catagory'  style='background: #DF7401'>"
                lt_str &= " <div class='inner'> <h3></h3></div> </div>"
                lt_nav_catagory.Text = lt_str
            Else
                lt_str = "<div class='nav-catagory'  style='background: #ffed33'>"
                lt_str &= " <div class='inner'> <h3></h3></div> </div>"
                lt_nav_catagory.Text = lt_str
            End If
        End If
        If _CLS.SYSTEM_ID = "8738" Or _CLS.SYSTEM_ID = "8734" Then

            UC_NODE_AUTO2.group = 5
        Else
            UC_NODE_AUTO2.group = 3
        End If

    End Sub
End Class