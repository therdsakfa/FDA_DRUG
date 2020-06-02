Public Class FRM_REPLACEMENT_BOOKING_EDIT_DATE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TYPE_EDIT As String
    Private Sub RunSession()
        _IDA = Request.QueryString("SCHEDULE_ID")
        _TYPE_EDIT = Request.QueryString("TYPE_EDIT")
        '_IDA = 5568 'test
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
        If Not IsPostBack Then
          
        End If
    End Sub

    Protected Sub Btn_confirm_Click(sender As Object, e As EventArgs) Handles Btn_confirm.Click

        Dim dao As New DAO_BOOKING.TB_DRUG_SCHEDULE
        Dim bao_date As New BAO.CAL_DATE
        Dim text As String = String.Empty
        Dim day As Integer = 0
        Dim new_date As Date = Date.Now
        Dim date_start As Date = Date.Now
        Try
            dao.GetDataby_SCHEDULE_ID(_IDA)
            date_start = dao.fields.SCHEDULE_DATE
            new_date = rdp_date.SelectedDate.Value

            If _TYPE_EDIT = "1" Then
                day = bao_date.SUM_WORK_DAY(date_start, new_date)
                dao.fields.CONSIDER_DATE = rdp_date.SelectedDate.Value
                dao.fields.CONSIDER_DATE_DISPLAY = rdp_date.SelectedDate.Value.ToLongDateString
                dao.fields.CONSIDER_DAY = day
                text = "แก้ไขวันที่ส่งเอกสารเรียบร้อยแล้ว"
            ElseIf _TYPE_EDIT = "2" Then
                day = bao_date.SUM_WORK_DAY(date_start, new_date)
                dao.fields.ALLOW_DATE = rdp_date.SelectedDate.Value
                dao.fields.ALLOW_DATE_DISPLAY = rdp_date.SelectedDate.Value.ToLongDateString
                dao.fields.ALLOW_DAY = day
                text = "แก้ไขวันที่ฟังผลการตรวจรับเรียบร้อยแล้ว"
            End If

            dao.update()

            alert(text)
        Catch ex As Exception
            text = "ไม่สามารถแก้ไขวันที่ได้ กรุณาตรวจสอบข้อมูล"
            alert(text)
        End Try
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

End Class