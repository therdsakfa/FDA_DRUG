Public Class POPUP_EXTEND_TIME_LOCATION_STAFF_REMARK
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _Process As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _Process = Request.QueryString("process")
            ' _type = "1"
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            txt_app_date.Text = Date.Now.ToShortDateString()
            'default_Remark()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 7
            AddLogStatus(7, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            dao.fields.RESPON_CITIZEN = _CLS.CITIZEN_ID
            dao.fields.REMARK = Txt_Remark.Text
            dao.update()
            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        Catch ex As Exception

        End Try

    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_STAFF_LOCATION_CONFIRM_PREVIEW.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _Process)

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class