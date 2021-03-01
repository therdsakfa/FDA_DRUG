Imports Telerik.Web.UI
Public Class FRM_STAFF_NYM_EDIT
    Inherits System.Web.UI.Page
    Private _TR_ID As String
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String
    Private _ProcessID As String
    Private msg As String
    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            _ProcessID = Request.QueryString("process")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            rdp_cncdate.SelectedDate = Date.Now
            If msg = "success" Then
                lbl_attach1.Text = "Upload File แนบสำเร็จ"
            End If
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CITIZEN_AUTHORIZE As String = ""

        Try

            Dim dao_prf2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2                       'เอาไว้ทำอะไร ยังไม่รู็ต้องแก้ 
            Dim dao_prf3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
            Dim dao_prf4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
            Dim dao_prf4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
            Dim dao_rgt As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            Dim dao_prf5 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_5
            If _ProcessID = 1027 Then
                dao_prf2.GetDataby_IDA(_IDA)
                Try
                    dao_rgt.GetDataby_IDA(dao_prf2.fields.DL)
                    CITIZEN_AUTHORIZE = dao_rgt.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception

                End Try

                Try
                    dao_prf2.fields.STATUS_ID = 5
                Catch ex As Exception

                End Try
                dao_prf2.update()
            ElseIf _ProcessID = 1028 Then
                dao_prf3.GetDataby_IDA(_IDA)
                Try
                    dao_rgt.GetDataby_IDA(dao_prf3.fields.DL)
                    CITIZEN_AUTHORIZE = dao_rgt.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception

                End Try
                Try
                    dao_prf3.fields.STATUS_ID = 5
                Catch ex As Exception

                End Try
                dao_prf3.update()
            ElseIf _ProcessID = 1029 Then
                dao_prf4.GetDataby_IDA(_IDA)
                Try
                    dao_rgt.GetDataby_IDA(dao_prf4.fields.DL)
                    CITIZEN_AUTHORIZE = dao_rgt.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception

                End Try
                Try
                    dao_prf4.fields.STATUS_ID = 5
                Catch ex As Exception

                End Try
                dao_prf4.update()
            ElseIf _ProcessID = 1030 Then
                dao_prf5.GetDataby_IDA(_IDA)
                Try
                    dao_rgt.GetDataby_IDA(dao_prf5.fields.DL)
                    CITIZEN_AUTHORIZE = dao_rgt.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception

                End Try
                Try
                    dao_prf5.fields.STATUS_ID = 5
                Catch ex As Exception

                End Try
                dao_prf5.update()
            ElseIf _ProcessID = 1031 Then
                dao_prf4_2.GetDataby_IDA(_IDA)
                Try
                    dao_rgt.GetDataby_IDA(dao_prf4_2.fields.DL)
                    CITIZEN_AUTHORIZE = dao_rgt.fields.CITIZEN_ID_AUTHORIZE
                Catch ex As Exception

                End Try
                Try
                    dao_prf4_2.fields.STATUS_ID = 5
                Catch ex As Exception

                End Try
                dao_prf4_2.update()
            End If


            Dim dao_edit As New DAO_DRUG_IMPORT.TB_DRUG_IMPORT_SEND_EDIT
            With dao_edit.fields
                .FK_IDA = _IDA

                .CITIZEN_AUTHORIZE = CITIZEN_AUTHORIZE
                .CITIZEN_STAFF = _CLS.CITIZEN_ID
                .DESCRIPTION = Txt_EDIT.Text
                .CREATE_DATE = rdp_cncdate.SelectedDate 'Date.Now
                .PROCESS_ID = _ProcessID
            End With
            dao_edit.insert()

            ''AddLogStatusDS(5, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            alert("ดำเนินการคืนให้แก้ไขคำขอเรียบร้อยแล้ว")
        Catch ex As Exception
            '' Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try
        AddLogStatusDS(5, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert1(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    'Function btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

    '    Return msg
    'End Function

    Sub upload()
        Try
            If FileUpload1.HasFile Or FileUpload2.HasFile Then
                'Dim bao As New BAO.AppSettings
                'bao.RunAppSettings()
                Dim TR_ID As String = _TR_ID

                If FileUpload1.HasFile Then
                    insert_file(TR_ID, FileUpload1, TXT_DESCIPTION1.Text)
                    lbl_attach1.Text = "อัพโหลดไฟล์แนบสำเร็จ"
                End If

                If FileUpload2.HasFile Then
                    insert_file(TR_ID, FileUpload2, TXT_DESCIPTION2.Text)
                    lbl_attach2.Text = "อัพโหลดไฟล์แนบสำเร็จ"
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub insert_file(ByVal TR_ID As Integer, ByVal fileupload As FileUpload, ByVal DESCRIPTION As String)
        If fileupload.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TYPE As String = 99

            Dim extensionname As String = GetExtension(fileupload.FileName).ToLower()
            fileupload.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname)
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

            dao_file.fields.NAME_FAKE = "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = fileupload.FileName
            dao_file.fields.TYPE = TYPE
            dao_file.fields.TRANSACTION_ID = TR_ID
            dao_file.fields.DESCRIPTION = DESCRIPTION
            dao_file.fields.PROCESS_ID = _ProcessID
            dao_file.insert()
        End If

    End Sub

    Protected Sub btn_Upload1_Click(sender As Object, e As EventArgs) Handles btn_Upload1.Click
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)

        If FileUpload1.HasFile Or FileUpload2.HasFile Then
            upload()
            msg = "success"
            alert1("ดำเนินการ UPLOAD FILE แก้ไขคำขอเรียบร้อยแล้ว")
        Else
            alert("กรุณาแนบไฟล์คำขอ")
        End If


    End Sub
End Class