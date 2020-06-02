Public Class FRM_RGT_EDIT_STAFF_OTHER_ORDER
    Inherits System.Web.UI.Page

    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        dao.GetDatabyIDA(_IDA)
        dao.fields.STATUS_ID = 4
        dao.fields.OTHER_ORDER = TextBox1.Text
        dao.update()
        alert("เพิ่มคำสั่งอื่นเรียบร้อยแล้ว")
    End Sub

    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Response.Redirect("FRM_TABEAN_CONFIRM_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    'End Sub
End Class