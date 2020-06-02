Public Class POPUP_STAFF_EDIT_LOCATION_RECEIVE
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
            txt_rcvdate.Text = Date.Now.ToShortDateString()
            'default_Remark()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim bao As New BAO.GenNumber
            Dim rcvno As String = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _Process, _IDA)
            Dim rcv_format As String = bao.FORMAT_NUMBER_FULL(con_year(Date.Now.Year()), rcvno)

            Dim dao As New DAO_DRUG.TB_lcnrequest
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 3
            dao.fields.rcvno = rcvno
            dao.fields.rcvdate = CDate(txt_rcvdate.Text)

            dao.fields.RCVNO_DISPLAY = Txt_RCVNO.Text
            dao.fields.RCV_MEETING = Txt_RCV_MEETING.Text
            dao.update()
            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        Catch ex As Exception

        End Try
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class