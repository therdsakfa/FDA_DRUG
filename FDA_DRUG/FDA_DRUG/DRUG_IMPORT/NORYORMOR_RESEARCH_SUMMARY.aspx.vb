Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI
Public Class NORYORMOR_RESEARCH_SUMMARY
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Sub runQuery()
        _process = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        RunSession()
        If Not IsPostBack Then
            load_GV_data()

        End If
    End Sub

    Sub load_GV_data()

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

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            If e.CommandName = "sel" Then
                dao.GetDataby_IDA(IDA)

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_RESEARCH_SUM_CONFIRM.aspx?IDA=" & IDA & "&FK_IDA=" & IDA & "&TR_ID=" & dao.fields.TR_ID & "&ProcessID=" & _process & "');", True)
            ElseIf e.CommandName = "chnge" Then
                dao.GetDataby_IDA(IDA)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_RESEARCH_ROLE.aspx?IDA=" & IDA & "&FK_IDA=" & IDA & "&TR_ID=" & dao.fields.TR_ID & "&ProcessID=" & _process & "');", True)

            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_authorize(_CLS.CITIZEN_ID_AUTHORIZE)
        RadGrid1.DataSource = dao.datas

    End Sub

    'Public Sub set_color_rg()
    '    'If RadGrid1.Items.Count > 0 Then
    '    '    For Each item As GridDataItem In RadGrid1.Items
    '    '        Try
    '    '            If item("EXP_DATE_EXTEND").Text.Contains("&nbsp;") = False Then
    '    '                Dim date_exp As Date = CDate(item("EXP_DATE_EXTEND").Text)
    '    '                Dim date_now As Date = CDate(Date.Now)
    '    '                If date_now > date_exp Then
    '    '                    item.ForeColor = Drawing.Color.Crimson
    '    '                    item("STATUS_NAME").Text = "Cert หมดอายุ"
    '    '                End If
    '    '            End If

    '    '        Catch ex As Exception

    '    '        End Try

    '    '    Next
    '    'End If
    'End Sub

    'Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
    '    'set_color_rg()
    'End Sub

End Class