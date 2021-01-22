Public Class FRM_TABEAN_YA_CHANGE_STATUS
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
    End Sub

    Protected Sub btn_sent_Click(sender As Object, e As EventArgs) Handles btn_sent.Click
        Dim i As Integer = 0
        If rdl_type.SelectedValue = "1" Then
            Dim dao_q As New DAO_DRUG.ClsDBdrrqt

            If Trim(txt_no_1.Text) <> "" Then
                dao_q.GetDataby_TR_ID_PROCESS_ID(Trim(txt_no_1.Text), "1400001")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "1400001", 3)
                End If
            End If
            If Trim(txt_no_2.Text) <> "" Then
                dao_q.GetDataby_TR_ID_PROCESS_ID(Trim(txt_no_2.Text), "1400001")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "1400001", 3)
                End If
            End If
            If Trim(txt_no_3.Text) <> "" Then
                dao_q.GetDataby_TR_ID_PROCESS_ID(Trim(txt_no_3.Text), "1400001")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "1400001", 3)
                End If
            End If
            If Trim(txt_no_4.Text) <> "" Then
                dao_q.GetDataby_TR_ID_PROCESS_ID(Trim(txt_no_4.Text), "1400001")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "1400001", 3)
                End If
            End If
            If Trim(txt_no_5.Text) <> "" Then
                dao_q.GetDataby_TR_ID_PROCESS_ID(Trim(txt_no_5.Text), "1400001")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "1400001", 3)
                End If
            End If
        ElseIf rdl_type.SelectedValue = "2" Then
            '130099
            Dim dao_q As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST

            If Trim(txt_no_1.Text) <> "" Then
                dao_q.GetDatabyTRID_PROCESS(Trim(txt_no_1.Text), "130099")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "130099", 3)
                End If
            End If
            If Trim(txt_no_2.Text) <> "" Then
                dao_q.GetDatabyTRID_PROCESS(Trim(txt_no_2.Text), "130099")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "130099", 3)
                End If
            End If
            If Trim(txt_no_3.Text) <> "" Then
                dao_q.GetDatabyTRID_PROCESS(Trim(txt_no_3.Text), "130099")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "130099", 3)
                End If
            End If
            If Trim(txt_no_4.Text) <> "" Then
                dao_q.GetDatabyTRID_PROCESS(Trim(txt_no_4.Text), "130099")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "130099", 3)
                End If
            End If
            If Trim(txt_no_5.Text) <> "" Then
                dao_q.GetDatabyTRID_PROCESS(Trim(txt_no_5.Text), "130099")
                If dao_q.fields.STATUS_ID = "2" Then
                    dao_q.fields.STATUS_ID = 3
                    dao_q.update()
                    i += 1
                    INSERT_LOG(dao_q.fields.IDA, "130099", 3)
                End If
            End If

        End If
        If i > 0 Then
            alert("ข้ามสถานะเรียบร้อยแล้ว")
        End If
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub
    Sub INSERT_LOG(ByVal IDA As Integer, ByVal process_id As String, ByVal STATUS_ID As Integer)
        Dim dao As New DAO_DRUG.TB_LOG_CHANGE_STATUS_MN
        dao.fields.FK_IDA = IDA
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID
        dao.fields.PROCESS_ID = process_id
        dao.fields.STATUS_DATE = Date.Now
        dao.fields.STATUS_ID = STATUS_ID
        dao.insert()
    End Sub
End Class