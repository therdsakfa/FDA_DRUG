Public Class UC_NCT_INFORMATION
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub get_information(ByVal dt As DataTable)

        For Each dr As DataRow In dt.Rows

            Try
                lbl_DATE.Text = CDate(dr("BOOKING_DATE")).ToLongDateString()
            Catch ex As Exception

            End Try

            Try
                lbl_DOCUMENT_TYPE_NAME.Text = dr("PROCESS_NAME")
            Catch ex As Exception

            End Try

            Try
                lbl_LOCATION_NAME.Text = dr("THAINAMEPLACE")
            Catch ex As Exception

            End Try

            Try
                lbl_NAME.Text = dr("BOOKING_FULL_NAME")
            Catch ex As Exception

            End Try

            Try
                lbl_STATUS_NAME.Text = dr("STATUS_NAME1")
            Catch ex As Exception

            End Try

            Try
                lbl_WORK_GROUP_NAME.Text = dr("WORK_GROUP_NAME")
            Catch ex As Exception

            End Try

        Next



    End Sub
End Class