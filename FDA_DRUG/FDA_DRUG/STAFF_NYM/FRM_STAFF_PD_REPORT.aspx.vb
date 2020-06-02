Public Class FRM_STAFF_PD_REPORT
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    Public Property _process As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _process = Request.QueryString("process")
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        show_data()
    End Sub

    Private Sub show_data()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_FILE_REMARK_ATTACH(_TR_ID)

        Dim ii As Integer = 0
        For Each dr As DataRow In dt.Rows
            ii = ii + 1
            Dim uc As New UC_REMARK_ATTACH
            Dim CC As UserControl = Page.LoadControl("../UC/UC_REMARK_ATTACH.ascx")
            uc = CC
            uc.ID = ii
            uc.BindUC(dr)
            PlaceHolder1.Controls.Add(uc)
        Next
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TYPE As String = 99

            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH
            dao.GetDataby_TR_ID_And_Process_And_Type(_TR_ID, _process, TYPE)

            Dim rid As Integer = 0
            For Each dao.fields In dao.datas
                rid = rid + 1
            Next
            rid = rid + 1

            Dim extensionname As String = GetExtension(FileUpload1.FileName).ToLower()
            FileUpload1.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _process & "-" & con_year(Date.Now().Year()) & "-" & _TR_ID & "-" & TYPE & "_" & rid & "." & extensionname)
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

            dao_file.fields.NAME_FAKE = "DA-" & _process & "-" & con_year(Date.Now().Year()) & "-" & _TR_ID & "-" & TYPE & "_" & rid & "." & extensionname
            dao_file.fields.NAME_REAL = FileUpload1.FileName
            dao_file.fields.TYPE = TYPE
            Try
                dao_file.fields.DESCRIPTION = TextBox1.Text
            Catch ex As Exception

            End Try
            dao_file.fields.TRANSACTION_ID = _TR_ID
            dao_file.fields.PROCESS_ID = _process
            'dao_file.insert()
        Else
            alert("ไม่พบไฟล์ที่จะอัพโหลด")
        End If
    End Sub
End Class