Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf

Public Class FRM_DS_EDIT_REQUEST
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
        _lcn_ida = Request("lcn_ida").ToString()
        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            UC_GRID_ATTACH.load_gv_V4(_TR_ID, 99, _ProcessID)
            set_label()
            'Try
            '    If msg = "success" Then
            '        lbl_attach1.Text = "Upload Flie แนบสำเร็จ"
            '    End If
            'Catch ex As Exception

            'End Try
        End If

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert1(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Public Sub set_label() 'ดึงข้อมูลแสดง
        Dim dao_edit As New DAO_DRUG.ClsDBDRSAMP_EDIT_REQUEST
        dao_edit.Getdataby_FK_IDA(_IDA)
        Try
            If dao_edit.fields.DESCRIPTION IsNot Nothing Then
                lbl_EDIT.Text = dao_edit.fields.DESCRIPTION
            End If
        Catch ex As Exception

        End Try
        Try
            Dim WRITEDATE As Date = dao_edit.fields.CREATE_DATE
            WRITEDATE = dao_edit.fields.CREATE_DATE
            WRITEDATE = DateAdd(DateInterval.Year, 543, WRITEDATE)
            lbl_DATE.Text = CDate(WRITEDATE).ToLongDateString
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button_DL_Click(sender As Object, e As EventArgs) Handles Button_DL.Click

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Response.Redirect("../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & dao.fields.PRODUCT_ID_IDA & "&process=" & _ProcessID)

        'Dim url As String = "../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & dao.fields.PRODUCT_ID_IDA & "&process=" & _ProcessID
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)

    End Sub

    Function btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click

        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_ProcessID)
        Try
            If FileUpload1.HasFile Or FileUpload2.HasFile Then
                upload()
            Else
                alert("กรุณาแนบไฟล์")
            End If

        Catch ex As Exception
            msg = "FAIL"
        End Try
        msg = "success"
        alert1("ดำเนินการ UPLOAD FILE เรียบร้อยแล้ว")

        Return msg
    End Function

    Protected Sub Button_confirm_Click(sender As Object, e As EventArgs) Handles Button_confirm.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_TR_ID_AND_PROCESS_ID(_TR_ID, _ProcessID)
        Try
            dao.fields.STATUS_ID = 6
            dao.fields.lmdfdate = Date.Now

        Catch ex As Exception

        End Try
        dao.update()

        alert("ส่งเรื่องคืนเจ้าหน้าที่เรียบร้อย")
    End Sub

    Sub upload()
        Try

            Dim TR_ID As String = _TR_ID

            If FileUpload1.HasFile Then
                insert_file(TR_ID, FileUpload1, 1)
                lbl_attach1.Text = "อัพโหลดไฟล์แนบสำเร็จ"
            End If
            If FileUpload2.HasFile Then
                insert_file(TR_ID, FileUpload2, 2)
                lbl_attach2.Text = "อัพโหลดไฟล์แนบสำเร็จ"
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
End Class