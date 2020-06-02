Public Class FRM_REPLACEMENT_BOOKING_DOCUMENT_2
    Inherits System.Web.UI.Page
      Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private Sub RunSession()
        _IDA = Request.QueryString("SCHEDULE_ID")
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

            BindData_PDF()

        End If
    End Sub
    Private Sub BindData_PDF()
        Try
            Dim dao As New DAO_BOOKING.TB_DRUG_SCHEDULE
            dao.GetDataby_SCHEDULE_ID(_IDA)
            Dim PDF_XML_LOCATION As New PDF_XML.DRUG_BOOKING
            Dim path_PDF As String = ""
            With PDF_XML_LOCATION
                .XML_PREVIEW = HiddenField2.Value
                .XML_MAIN_IDA = _IDA
                .XML_TR_ID = 1 'test
                .XML_YEAR = con_year_2()
                .chk_status = 1
                .XML_PROCESS_ID = 10002
                .STATUS_ID = 8
                .chk_status = 1
                .chk_reload = 1
                .BindData_PDF()

                path_PDF = .XML_PATH_PDF
            End With
            HiddenField1.Value = path_PDF
            lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & path_PDF & "' ></iframe>"
            hl_reader.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & path_PDF ' Link เปิดไฟล์ตัวใหญ่
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        Try
            load_pdf(HiddenField1.Value)
        Catch ex As Exception

        End Try

    End Sub


    Sub load_pdf(ByVal filename As String)
        Try

            Dim clsds As New ClassDataset
            Response.Clear()
            Response.ContentType = "Application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename & ".pdf")

            Response.BinaryWrite(clsds.UpLoadImageByte(filename)) '"C:\path\PDF_XML_CLASS\"

        Catch ex As Exception

        Finally

            Response.Flush()
            Response.Close()
            Response.End()
        End Try

    End Sub
End Class