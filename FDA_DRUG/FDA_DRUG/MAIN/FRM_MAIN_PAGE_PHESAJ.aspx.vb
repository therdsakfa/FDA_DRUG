Public Class FRM_MAIN_PAGE_PHESAJ
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
        UC_NEWS.Set_text(2)
        If Not IsPostBack Then
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('สำหรับเภสัชเคมีภัณฑ์ที่มีส่วนประกอบของสารออกฤทธิ์เท่านั้น');", True)
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('1. คำขอที่ยื่นช่วงวันที่ 7-11 สิงหาคม จะไม่สามารถชำระเงินได้ โปรดยื่นคำขอใหม่ (หากชำระเงินแล้ว โปรดติดต่อสำนักยาเพื่อขอคืนเงินต่อไป)\n" & _
            '                                                  "2. ต้องใช้ใบสั่งที่ออกจากระบบนี้เท่านั้น ห้ามใช้ใบสั่งชำระที่กดจากจุดสั่งชำระของอย.\n" & _
            '                                                    "3. โปรดอนุญาตการใช้ Popup และหากประสงค์รวมรายการชำระขอให้ออกใบสั่งให้ครบทุกรายการก่อน แล้วจึงเลือกรายการที่ทำใบสั่งไว้ เพื่อสั่งชำระต่อไป\n" & _
            '                                                    "4. ในการออกใบสั่งชำระต้องเลือกเฉพาะรายการที่เป็นเภสัชเคมีภัณฑ์เท่านั้น หากทำรายการไม่ถูกต้อง (เลือกรายการชำระประเภทอื่น) จะทำถือว่าท่านประสงค์ทำรายการดังกล่าวโดยสมัครใจและไม่สามารถขอคืนเงินได้');", True)
        End If
    End Sub
End Class