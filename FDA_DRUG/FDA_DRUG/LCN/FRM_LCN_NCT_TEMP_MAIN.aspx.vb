Imports Telerik.Web.UI

Public Class FRM_LCN_NCT_TEMP_MAIN
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String
    Private b64 As String
    Sub RunQuery()
        Try
          
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub

    Sub FN_search()

    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'FN_search()
        rgsearch.Rebind()
    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.TB_TEMP_NCT_DALCN
                dao.Getdata_by_ID(IDA)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                'Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                'dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_NCT_TEMP_CONFIRM.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao.fields.PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_TEMP_NCT_DALCN_ALL()

        RadGrid1.DataSource = dt
    End Sub

    Private Sub rgsearch_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgsearch.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(IDA)
                Dim tr_id As String= 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
                dao_pro.GetDataby_Process_Name(dao.fields.lcntpcd)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_LCN_NCT_TEMP_INSERT.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & dao_pro.fields.PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub rgsearch_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgsearch.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_SEARCH_LCN_BY_IDEN(txt_identify.Text)
        rgsearch.DataSource = dt
    End Sub
End Class