Public Class FRM_STAFF_LCN_PAY_NOTE
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
        If Len(TextBox1.Text) >= 10 Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 11
            dao.fields.comment = TextBox1.Text
            dao.update()

            Dim cls_sop As New CLS_SOP
            cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao.fields.PROCESS_ID, _CLS.PVCODE, 8, "บันทึกการชำระเงินค่าคำขอ", "SOP-DRUG-10-" & dao.fields.PROCESS_ID & "-11", "บันทึกการชำระเงินค่าคำขอ", "เจ้าหน้าที่บันทึกการชำระเงินค่าคำขอ", "STAFF", _TR_ID, SOP_STATUS:="บันทึกการชำระเงินค่าคำขอ")

            alert("บันทึกข้อมูบเรียบร้อยแล้ว")
        Else
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกข้อมูล');</script> ")
        End If

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_TABEAN_CONFIRM_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class