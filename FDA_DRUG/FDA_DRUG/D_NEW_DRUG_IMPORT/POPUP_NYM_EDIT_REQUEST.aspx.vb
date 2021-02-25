Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Public Class POPUP_NYM_EDIT_REQUEST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private _lcn_ida As String
    Private msg As String
    Private msg1 As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try
        '_lcn_ida = Request("lcn_ida").ToString()
        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("Process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            UC_GRID_ATTACH.load_gv_V4(_TR_ID, 99, _ProcessID)
            set_label()
            Try
                If msg = "success" Then
                    lbl_attach1.Text = "Upload Flie แนบสำเร็จ"
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert1(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Public Sub set_label() 'ดึงข้อมูลแสดง
        Dim dao_edit As New DAO_DRUG_IMPORT.TB_DRUG_IMPORT_SEND_EDIT
        dao_edit.GetDataby_FK_IDA_Process(_IDA, _ProcessID)
        Try
            If dao_edit.fields.DESCRIPTION IsNot Nothing Then
                Txt_EDIT.Text = dao_edit.fields.DESCRIPTION
            End If
        Catch ex As Exception

        End Try
        Try
            lbl_DATE.Text = dao_edit.fields.CREATE_DATE
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button_DL_Click(sender As Object, e As EventArgs) Handles Button_DL.Click
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        dao2.GetDataby_IDA(_IDA)
        dao3.GetDataby_IDA(_IDA)
        dao4.GetDataby_IDA(_IDA)
        dao4_2.GetDataby_IDA(_IDA)
        Dim DL As Integer = 0
        If _ProcessID = 1027 Then
            Try
                DL = dao2.fields.DL
            Catch ex As Exception

            End Try
        ElseIf _ProcessID = 1028 Then
            Try
                DL = dao3.fields.DL
            Catch ex As Exception

            End Try
        ElseIf _ProcessID = 1029 Then
            Try
                DL = dao4.fields.DL
            Catch ex As Exception

            End Try
        ElseIf _ProcessID = 1031 Then
            Try
                DL = dao4_2.fields.DL
            Catch ex As Exception

            End Try
        End If
        Response.Redirect("../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & DL & "&process=" & _ProcessID)

        'Dim url As String = "../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & dao.fields.PRODUCT_ID_IDA & "&process=" & _ProcessID
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)

    End Sub

    Function btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)
        Try
            If FileUpload1.HasFile Then
                upload()
            Else
                alert("กรุณาแนบไฟล์คำขอ")
            End If

        Catch ex As Exception
            msg = "FAIL"
        End Try
        msg = "success"
        alert1("ดำเนินการ UPLOAD FILE แก้ไขคำขอเรียบร้อยแล้ว")

        Return msg
    End Function

    Protected Sub Button_confirm_Click(sender As Object, e As EventArgs) Handles Button_confirm.Click
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        Dim bao As New BAO.ClsDBSqlcommand
        Dim TR_ID As String = ""
        If _ProcessID = 1027 Then                                   'เช็ค Status เป็น nym อะไร และการกดปุ่มในแต่ละอันจะอัพเดท ststus_id ใน base TB_FDA_DRUG_IMPORT_NYM_ ของ NYM นั้นๆ
            dao2.GetDataby_IDA(Integer.Parse(_IDA))

            dao2.fields.STATUS_ID = 6                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 

            dao2.update()
        ElseIf _ProcessID = 1028 Then
            dao3.GetDataby_IDA(Integer.Parse(_IDA))

            dao3.fields.STATUS_ID = 6                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 

            dao3.update()
        ElseIf _ProcessID = 1029 Then
            dao4.GetDataby_IDA(Integer.Parse(_IDA))
            dao4.fields.STATUS_ID = 6                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 

            dao4.update()
        ElseIf _ProcessID = 1031 Then
            dao4_2.GetDataby_IDA(Integer.Parse(_IDA))

            dao4_2.fields.STATUS_ID = 6                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 

            dao4_2.update()
        End If
        Dim years As String = ""

        AddLogStatusnymimport(6, _ProcessID, _CLS.CITIZEN_ID, _IDA)            'LOG STATUS เก็บการ log ไว้ แล้วอัพเข้า base นี้ 



        alert("ยื่นเรื่องเรียบร้อยแล้วรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)

        alert("ส่งเรื่องคืนเจ้าหน้าที่เรียบร้อย")
    End Sub

    Sub upload()
        Try
            If FileUpload1.HasFile Or FileUpload2.HasFile Then
                'Dim bao As New BAO.AppSettings
                'bao.RunAppSettings()
                Dim TR_ID As String = _TR_ID

                If FileUpload1.HasFile Then
                    insert_file(TR_ID, FileUpload1, 1)
                    lbl_attach1.Text = "อัพโหลดไฟล์แนบสำเร็จ"
                ElseIf FileUpload2.HasFile Then
                    insert_file(TR_ID, FileUpload2, 2)
                    lbl_attach2.Text = "อัพโหลดไฟล์แนบสำเร็จ"
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub insert_file(ByVal TR_ID As Integer, ByVal fileupload As FileUpload, ByVal TYPE_NEW As Integer)
        If fileupload.HasFile Then

            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TYPE As String = fileupload.ID.ToString.Substring(10, 1) - 1

            Dim extensionname As String = GetExtension(fileupload.FileName).ToLower()
            fileupload.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "-" & TYPE_NEW & "." & extensionname)
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

            dao_file.fields.NAME_FAKE = "DA-" & _ProcessID & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = fileupload.FileName
            dao_file.fields.TYPE = TYPE
            dao_file.fields.TRANSACTION_ID = TR_ID
            dao_file.fields.PROCESS_ID = _ProcessID
            dao_file.insert()

        End If
    End Sub

    Protected Sub btn_nym_edit_Click(sender As Object, e As EventArgs) Handles btn_nym_edit.Click
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        Dim url As String = ""
        If _ProcessID = 1027 Then                                   'เช็ค Status เป็น nym อะไร และการกดปุ่มในแต่ละอันจะอัพเดท ststus_id ใน base TB_FDA_DRUG_IMPORT_NYM_ ของ NYM นั้นๆ
            dao2.GetDataby_IDA(Integer.Parse(_IDA))
            url = "https://medicina.fda.moph.go.th/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & dao2.fields.DL & "&NYM=" & 2 & "&process=" & _ProcessID & "&IDA=" & _IDA & "&CHK_SAVE=2"
            Response.Redirect(url)
        ElseIf _ProcessID = 1028 Then
            dao3.GetDataby_IDA(Integer.Parse(_IDA))
            url = "https://medicina.fda.moph.go.th/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & dao3.fields.DL & "&NYM=" & 3 & "&process=" & _ProcessID & "&IDA=" & _IDA & "&CHK_SAVE=2"
            Response.Redirect(url)
        ElseIf _ProcessID = 1029 Then
            dao3.GetDataby_IDA(Integer.Parse(_IDA))
            url = "https://medicina.fda.moph.go.th/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & dao4.fields.DL & "&NYM=" & 4 & "&process=" & _ProcessID & "&IDA=" & _IDA & "&CHK_SAVE=2"
            Response.Redirect(url)
        ElseIf _ProcessID = 1031 Then
            dao3.GetDataby_IDA(Integer.Parse(_IDA))
            url = "https://medicina.fda.moph.go.th/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & dao4_2.fields.DL & "&NYM=" & 7 & "&process=" & _ProcessID & "&IDA=" & _IDA & "&CHK_SAVE=2"
            Response.Redirect(url)
        End If


    End Sub
End Class