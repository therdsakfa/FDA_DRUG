Public Class FRM_MAIN_PAGE_PRODUCT
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
        UC_NEWS.Set_text(1)
        If Not IsPostBack Then
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('สำหรับเภสัชเคมีภัณฑ์ที่มีส่วนประกอบของสารออกฤทธิ์เท่านั้น');", True)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ปิดระบบ INN ชั่วคราว\n" & _
            '                                                  "เพื่อปรับปรุงและพัฒนาระบบ โปรดเข้ามาติดตามอีกครั้ง ในวันที่ 22 กพ. 2561');", True)
            Dim str_notice As String = ""
            Try
                Dim dao As New DAO_DRUG.TB_MAS_NOTICE
                dao.GetDataby_SYSTEM_ID(3)
                str_notice = dao.fields.NOTICE
                ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('" & str_notice & "');", True)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class