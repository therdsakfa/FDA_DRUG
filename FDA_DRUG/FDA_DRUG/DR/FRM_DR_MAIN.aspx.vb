Public Class FRM_DR_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _NYM As String = ""
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Sub runQuery()
        _NYM = Request.QueryString("type")
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
    End Sub
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
        load_lcnno()
        runQuery()
        If Not IsPostBack Then
            load_GV_data()
        End If
    End Sub
    Sub load_lcnno()
        lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF("PDF_DR.pdf")
    End Sub
    Sub load_GV_data()
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable    
        bao_DB.SP_DRSAMP_TABEAN_BY_FK_IDA(_IDA)
        GV_data.DataSource = bao_DB.dt
        GV_data.DataBind()
    End Sub

    Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer



        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = 11
        dao_down.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_down.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_down.fields.STATUS = STATUS
        dao_down.fields.DOWNLOAD_DATE = DOWNLOAD_DATE
        dao_down.insert()
        down_ID = dao_down.fields.ID
        dao_up.fields.DOWNLOAD_ID = down_ID
        dao_up.insert()

        'Dim dao As New DAO.clsDBfafdtype
        'dao.Getdata_by_fdtypecd(_CLS.FDTYPECD)

        '    _CLS.FATYPE = FATYPE

        Dim file_xml As String = bao_app._PATH_XML_TRADER & NAME_DOWNLOAD_XML("DA", down_ID)



        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
        Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID) 'test
        ' Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & "DA-3227.xml" 'test


        convert_XML_To_PDF(file_PDF, file_xml, file_template)

        _CLS.FILENAME_PDF = file_PDF
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.FILENAME_PDF & ".pdf")
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrsamp

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DI_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

        End If
    End Sub

    Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_status As Label = DirectCast(e.Row.FindControl("lbl_status"), Label)
            'Dim lbl_lcnno As Label = DirectCast(e.Row.FindControl("lbl_transession"), Label)

            '     Dim lbl_lcntype As Label = DirectCast(e.Row.FindControl("lbl_lcntype"), Label)
            ' Dim btn_Select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim index As Integer = e.Row.RowIndex
            Dim str_ID As String = GV_data.DataKeys.Item(index).Value.ToString()
            Dim stat As String = e.Row.Cells(0).Text 'GV_data.Rows(index).Cells(0).Text
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            If stat = "" Then
                lbl_status.Text = "บันทึกคำขอ"
            ElseIf stat = 1 Then
                ' lbl_status.Text = "รอพิจารณา"
                lbl_status.Text = "ยื่นคำขอ"
                ' btn_Select.Visible = False
            ElseIf stat = 8 Then
                lbl_status.Text = "อนุมัติ"
                ' btn_Select.Visible = False
            ElseIf stat = 9 Then
                lbl_status.Text = "ยกเลิกคำขอ"

            End If

            'เลขใบอนุญาต
            '   Dim bao_convert_num As New BAO.convert_num
            '         lbl_lcnno.Text = bao_convert_num.con_lcnno(str_ID)

            'เลขประเภทใบอนุญาต
            '   lbl_lcntype.Text = bao_convert_num.con_lcntype(str_ID)

        End If
    End Sub
End Class