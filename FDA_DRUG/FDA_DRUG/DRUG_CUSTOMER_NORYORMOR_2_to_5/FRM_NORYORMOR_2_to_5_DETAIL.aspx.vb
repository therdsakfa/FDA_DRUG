Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_NORYORMOR_2_to_5_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _ProcessID As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("process")
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
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
        set_lbl_header(lb_nym, _ProcessID)
    End Sub

    Sub load_lcnno()
        'lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Sub load_GV_data()
        Dim bao As New BAO.ClsDBSqlcommand
        'นยม. 1
        bao.SP_DRIMPFOR_BY_IDA(_IDA, _ProcessID)
        GV_data.DataSource = bao.dt
        GV_data.DataBind()
    End Sub
    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Bind_PDF("PDF_DRUG_REPORT_NORYORMOR.pdf")
        'Select Case _ProcessID
        '    Case "2"
        '        Bind_PDF("PDF_DRUG_REPORT_NORYORMOR.pdf")
        '    Case "3"
        '        Bind_PDF("PDF_DRUG_REPORT_NORYORMOR.pdf")
        '    Case "4"
        '        Bind_PDF("PDF_DRUG_REPORT_NORYORMOR.pdf")
        '    Case "5"
        '        Bind_PDF("PDF_DRUG_REPORT_NORYORMOR.pdf")
        '    Case ""
        '        Bind_PDF("PDF_DRUG_REPORT_NORYORMOR.pdf")
        'End Select
    End Sub


    Private Sub Bind_PDF(ByVal PDF_TEMPLATE As String)
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_down As New DAO_DRUG.ClsDBTRANSACTION_DOWNLOAD
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        Dim down_ID As Integer



        Dim STATUS As String = 0
        Dim DOWNLOAD_DATE As Date = Date.Now()
        dao_down.fields.PROCESS_ID = _ProcessID
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

        Dim file_xml As String = bao_app._PATH_XML_CLASS & NAME_DOWNLOAD_XML("DA", down_ID)



        Dim file_template As String = bao_app._PATH_PDF_TEMPLATE & PDF_TEMPLATE
        Dim file_PDF As String = bao_app._PATH_PDF_XML_CLASS & NAME_DOWNLOAD_PDF("DA", down_ID)


        convert_Database_To_XML("DA-" & down_ID.ToString())
        convert_XML_To_PDF(file_PDF, file_xml, file_template)

        _CLS.FILENAME_PDF = file_PDF
        _CLS.PDFNAME = NAME_DOWNLOAD_PDF("DA", down_ID)
        Session("CLS") = _CLS
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "closespinner();", True)
    End Sub
    Private Sub convert_Database_To_XML(ByVal filename As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_lcn_ida)

        Dim cls_CER As New CLASS_GEN_XML.DI(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, dao.fields.lcnno, _
                                            IIf(IsDBNull(dao.fields.lctcd), 0, dao.fields.lctcd), dao.fields.pvncd, dao.fields.IDA)
        Dim cls_xml As New CLASS_DI
        cls_xml = cls_CER.gen_xml()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()


        Dim objStreamWriter As New StreamWriter(filename)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrimpfor

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_NORYORMOR_2_to_5_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & " &process=" & _ProcessID & "');", True)
        ElseIf e.CommandName = "lnk_to" Then
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            _CLS.LCNNO = dao.fields.lcnno.ToString()
            _CLS.LCNSID_CUSTOMER = dao.fields.lcnsid.ToString()
            _CLS.PVCODE = dao.fields.pvncd.ToString()
            Session("CLS") = _CLS

            Response.Redirect("../DRUG_REPORT/FRM_REPORT_MAIN.aspx?IDA=" & str_ID & "&fk_ida=" & str_ID & "&process=" & _ProcessID)

        End If
    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_data()
    End Sub
End Class