Public Class UC_CONFIRM
    Inherits System.Web.UI.UserControl
    Private _DEPARTMENT_TYPE_ID As String
    Sub RunAppSettings()
        _DEPARTMENT_TYPE_ID = System.Configuration.ConfigurationManager.AppSettings("DEPARTMENT_TYPE_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunAppSettings()
        If Not Page.IsPostBack Then

        End If
    End Sub

    Public Sub loaddata(ByRef dao As DAO_BOOKING.CLS_SCHEDULE)
        'lbl_channel.Text = dao.fields.
        Dim dao_service As New DAO_BOOKING.CLS_CHANNEL
        dao_service.GetDataby_CHANNEL_ID(dao.fields.CHANNEL_ID)
        Dim dao_DOCUMENT_TYPE As New DAO_BOOKING.CLS_DOCUMENT_TYPE
        dao_DOCUMENT_TYPE.GetDataby_DOCUMENT_TYPE_ID(dao.fields.DOCUMENT_TYPE_ID)

        lbl_SERVICE.Text = dao_service.fields.CHANNEL_NAME
        lbl_date.Text = dao.fields.SCHEDULE_DATE.Value.Day.ToString() & "/" & dao.fields.SCHEDULE_DATE.Value.Month.ToString() & "/" & dao.fields.SCHEDULE_DATE.Value.Year.ToString()
        lbl_DOCUMENT_TYPE_NAME.Text = dao_DOCUMENT_TYPE.fields.DOCUMENT_TYPE_NAME
        'lbl_time.Text = dao.fields.SCHEDULE_TIME_START + " - " + dao.fields.SCHEDULE_TIME_END

    End Sub
End Class