﻿Public Class FRM_STAFFNYM_REMARK
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    Private _status As Integer
    Private _process As Integer

    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            '_TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _process = Request.QueryString("process")
            _status = Request.QueryString("status")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    '    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
    '        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    '    End Sub

    '    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
    '        Dim filename As String = HiddenField1.Value
    '        Try
    '            load_pdf(filename)
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Protected Sub btn_load1_Click(sender As Object, e As EventArgs) Handles btn_load1.Click
    '        Dim preview As Integer = HiddenField2.Value
    '        If preview = 0 Then
    '            HiddenField2.Value = "1"
    '        ElseIf preview = 1 Then
    '            HiddenField2.Value = "0"
    '        End If
    '        BIND_ALL()
    '    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _status = 5 Then
            If _process = 1027 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
                dao.GetDataby_IDA(_IDA)

                dao.fields.REMARK_EDIT = TextBox1.Text

                dao.fields.STATUS_ID = 5

                dao.update()
                AddLogStatustodrugimport(5, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            ElseIf _process = 1028 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
                dao.GetDataby_IDA(_IDA)
                dao.fields.REMARK_EDIT = TextBox1.Text

                dao.fields.STATUS_ID = 5

                dao.update()
                AddLogStatustodrugimport(5, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")

            ElseIf _process = 1029 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
                dao.GetDataby_IDA(_IDA)
                dao.fields.REMARK_EDIT = TextBox1.Text

                dao.fields.STATUS_ID = 5

                dao.update()
                AddLogStatustodrugimport(5, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            ElseIf _process = 1031 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
                dao.GetDataby_IDA(_IDA)
                dao.fields.REMARK_EDIT = TextBox1.Text

                dao.fields.STATUS_ID = 5

                dao.update()
                AddLogStatustodrugimport(5, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            End If

        ElseIf _status = 7 Then

            If _process = 1027 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
                dao.GetDataby_IDA(_IDA)

                dao.fields.REMARK = TextBox1.Text

                dao.fields.STATUS_ID = 7

                dao.update()
                AddLogStatustodrugimport(7, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            ElseIf _process = 1028 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
                dao.GetDataby_IDA(_IDA)
                dao.fields.REMARK = TextBox1.Text

                dao.fields.STATUS_ID = 7

                dao.update()
                AddLogStatustodrugimport(7, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")

            ElseIf _process = 1029 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
                dao.GetDataby_IDA(_IDA)
                dao.fields.REMARK = TextBox1.Text

                dao.fields.STATUS_ID = 7

                dao.update()
                AddLogStatustodrugimport(7, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")

            ElseIf _process = 1031 Then
                Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
                dao.GetDataby_IDA(_IDA)
                dao.fields.REMARK = TextBox1.Text

                dao.fields.STATUS_ID = 7

                dao.update()
                AddLogStatustodrugimport(7, _process, _CLS.CITIZEN_ID, _IDA)
                alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
            End If
        End If

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_STAFFNYM_CONFIRM.aspx?IDA=" & _IDA & "&process=" & _process)
    End Sub
End Class