Public Class POPUP_DR_ACCEPT
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As Integer
    Private _TR_ID As Integer
    Sub RunSession()
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _TR_ID = Request.QueryString("TR_ID")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 3
            dao.fields.ndrgtp = "1"
            dao.update()

            AddLogStatus(2, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
            alert("ท่านยืนคำขอแล้ว")
        Else
            alert_noclose("ไม่สามารถบันทึกได้ ท่านต้องยอมรับเงื่อนไข")
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_noclose(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class