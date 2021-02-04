Public Class FRM_DS_STAFF_EDIT
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String
    Private _ProcessID As String
    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            '_ProcessID = Request.QueryString("process")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            'txt_lmdfdate.Text = Date.Now.ToShortDateString()
            'default_Remark()
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)

            Try
                dao.fields.STATUS_ID = 5
            Catch ex As Exception

            End Try
            dao.update()

            Dim dao_edit As New DAO_DRUG.ClsDBDRSAMP_EDIT_REQUEST
            With dao_edit.fields
                .FK_IDA = dao.fields.IDA
                .FK_REGISTRATION = dao.fields.PRODUCT_ID_IDA
                .lcntpcd = dao.fields.lcntpcd
                .CITIZEN_AUTHORIZE = dao.fields.CUSTOMER_CITIZEN_AUTHORIZE
                .CITIZEN_STAFF = _CLS.CITIZEN_ID
                .DESCRIPTION = Txt_EDIT.Text
                .CREATE_DATE = rdp_cncdate.SelectedDate 'Date.Now
                .PROCESS_ID = dao.fields.process_id
            End With
            dao_edit.insert()

            ''AddLogStatusDS(5, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            alert("ดำเนินการคืนให้แก้ไขคำขอเรียบร้อยแล้ว")
        Catch ex As Exception
            '' Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_DS_STAFF_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)

        If FileUpload1.HasFile Then
            upload()
        Else
            alert("กรุณาแนบไฟล์คำขอ")
        End If

    End Sub

    Sub upload()
        Try
            If FileUpload1.HasFile Or FileUpload2.HasFile Then
                Dim bao As New BAO.AppSettings
                bao.RunAppSettings()


                Dim TR_ID As String = ""
                Dim bao_tran As New BAO_TRANSECTION
                bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION
                'If Upload_Attach(TR_ID) Then

                'ตรวจสอบไฟล์แนบ
                If FileUpload1.HasFile Then
                    insert_file(TR_ID, FileUpload1)
                Else
                    insert_file(TR_ID, FileUpload2)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub insert_file(ByVal TR_ID As Integer, ByVal fileupload As FileUpload)
        If fileupload.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TYPE As String = fileupload.ID.ToString.Substring(10, 1) - 1

            Dim extensionname As String = GetExtension(fileupload.FileName).ToLower()
            fileupload.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname)
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

            dao_file.fields.NAME_FAKE = "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = fileupload.FileName
            dao_file.fields.TYPE = TYPE
            dao_file.fields.TRANSACTION_ID = TR_ID
            dao_file.fields.PROCESS_ID = _ProcessID
            dao_file.insert()
        End If

    End Sub
End Class