Public Class FRM_TABEAN_YA_CHANGE_STATUS
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
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
    End Sub

    Protected Sub btn_sent_Click(sender As Object, e As EventArgs) Handles btn_sent.Click
        If rdl_type.SelectedValue = "1" Then
            Dim dao As New DAO_DRUG.ClsDBdrrqt
            Try
                If Trim(txt_no_1.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_1.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "1400001", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_2.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_2.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "1400001", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_3.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_3.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "1400001", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_4.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_4.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "1400001", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_5.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_5.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "1400001", 3)
                    End If

                End If

            Catch ex As Exception

            End Try

        ElseIf rdl_type.SelectedValue = "2" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            Try
                If Trim(txt_no_1.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_1.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "130099", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_2.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_2.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "130099", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_3.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_3.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "130099", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_4.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_4.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "130099", 3)
                    End If
                End If

            Catch ex As Exception

            End Try

            Try
                If Trim(txt_no_5.Text) <> "" Then
                    dao.GetDataby_TR_ID_AND_PROCESS_ID(Trim(txt_no_5.Text))
                    If dao.fields.STATUS_ID = 2 Then
                        dao.fields.STATUS_ID = 3
                        dao.update()

                        Insert_Log(dao.fields.IDA, "130099", 3)
                    End If

                End If

            Catch ex As Exception

            End Try
        End If

        alert("ข้ามสถานะแล้ว")
        Clear_txt()

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub Insert_Log(ByVal FK_IDA As Integer, ByVal process_id As String, ByVal STATUS_ID As Integer)
        Dim dao As New DAO_DRUG.TB_LOG_CHANGE_STATUS_MN
        dao.fields.FK_IDA = FK_IDA
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID
        dao.fields.PROCESS_ID = process_id
        dao.fields.STATUS_ID = STATUS_ID
        dao.fields.STATUS_DATE = Date.Now
        dao.insert()
    End Sub
    Sub Clear_txt()
        txt_no_1.Text = ""
        txt_no_2.Text = ""
        txt_no_3.Text = ""
        txt_no_4.Text = ""
        txt_no_5.Text = ""
    End Sub
End Class