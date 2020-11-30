﻿Imports Telerik.Web.UI

Public Class FRM_SEARCH_LCN_TO_DL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String = ""                'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _process_for As String

    Sub RunSession()

        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            '_lcn_ida = Request.QueryString("lcn_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim bao_DB As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        Try
            bao_DB.SP_DRUG_REGISTRATION_BY_FK_IDA(rcb_search.SelectedValue)
            RadGrid1.DataSource = bao_DB.dt
            RadGrid1.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim bao_infor As New BAO.information
            Dim item As GridDataItem = e.Item

            Dim str_ID As String = item("H_IDA").Text
            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao.GetDataby_IDA(str_ID)

            If e.CommandName = "_sel" Then
                dao.GetDataby_IDA(str_ID)
                Dim tr_id As String = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try

                Dim url As String = ""
                Dim NYM As String = ""
                If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
                    Select Case _process
                        Case "1027"
                            NYM = "2"
                            url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM2.aspx?DL=" & str_ID & "&IDA=" & str_ID & "&NYM=" & NYM & "&process=" & _process & "&lcnida=" & dao.fields.FK_IDA

                        Case "1028"
                            NYM = "3"
                            url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM3.aspx?DL=" & str_ID & "&IDA=" & str_ID & "&NYM=" & NYM & "&process=" & _process & "&lcnida=" & dao.fields.FK_IDA

                        Case "1029"
                            NYM = "4"
                            url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM4.aspx?DL=" & str_ID & "&IDA=" & str_ID & "&NYM=" & NYM & "&process=" & _process & "&lcnida=" & dao.fields.FK_IDA

                        Case "1030"
                            NYM = "5"
                            url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM5.aspx?DL=" & str_ID & "&IDA=" & str_ID & "&NYM=" & NYM & "&process=" & _process & "&lcnida=" & dao.fields.FK_IDA

                    End Select
                    'url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_MAIN.aspx?DL=" & rcb_search.SelectedValue & "&NYM=" & NYM & "&process=" & _process
                    Response.Redirect(url)
                End If



                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('POPUP_REGISTRATION_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _r_process & "');", True)
                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPORT_REGIST.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

            End If
        End If
    End Sub
End Class