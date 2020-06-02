Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class UC_NYM_PROOF_UPLOAD
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    Private _process As String

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            _process = Request.QueryString("process")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RunSession()
        set_label()

    End Sub

    Public Sub set_label()
        If _process = 1028 Then
            lbl_attach_type.Text = "หนังสือแสดงการนำหรือส่ง (น.ย.ม.3)"
        ElseIf _process = 1029 Then
            lbl_attach_type.Text = "หลักฐานการรับบริจาคยา (น.ย.ม.4)"
        End If
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        Dim dao As New DAO_DRUG.ClsDBdrsamp
        Dim dao_prf As New DAO_DRUG.ClsDB_nym_proof

        If FileUpload1.HasFile Then
            If TextBox1.Text = "" Then
                alert("กรุณากรอกรหัสดำเนินการ")
            Else
                Try
                    dao.GetDataby_TR_ID(TextBox1.Text)
                Catch ex As Exception
                    alert("รหัสดำเนินการไม่ถูกต้อง")
                End Try
                If dao.fields.TR_ID Is Nothing Then
                    alert("ไม่พบรหัสดำเนินการนี้")
                Else
                    If dao.fields.STATUS_ID = 8 Then
                        dao_prf.GetDataby_FK(dao.fields.IDA)
                        If dao_prf.fields.RCV_PROOF Is Nothing Then
                            insert_file(dao.fields.TR_ID, FileUpload1, dao.fields.IDA)
                            alert("ทำการอัพโหลดเรียบร้อย")
                        Else
                            alert("เลขดำเนินการนี้ได้ทำการอัพโหลดไปแล้ว")
                        End If
                    Else
                        alert("เลขดำเนินการนี้ยังไม่ได้รับอนุมัติ")
                    End If
                End If
            End If
        Else
            alert("กรุณาเลือกไฟล์ที่จะอัพโหลด")
        End If

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<script type langue =javascript>")
        Response.Write("window.location.href = '../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & _process & "';")
        Response.Write("</script type >")
    End Sub

    Private Sub insert_file(ByVal TR_ID As Integer, ByVal fileupload As FileUpload, ByVal fk As Integer)
        If fileupload.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TYPE As String = "P"

            Dim extensionname As String = GetExtension(fileupload.FileName).ToLower()
            fileupload.SaveAs(bao._PATH_DEFAULT & "/upload/" & "DA-" & _process & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname)
            Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH

            dao_file.fields.NAME_FAKE = "DA-" & _process & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
            dao_file.fields.NAME_REAL = fileupload.FileName
            dao_file.fields.TYPE = TYPE
            dao_file.fields.TRANSACTION_ID = TR_ID
            dao_file.fields.PROCESS_ID = _process
            dao_file.insert()

            Dim dao_prf As New DAO_DRUG.ClsDB_nym_proof
            dao_prf.GetDataby_FK(fk)
            dao_prf.fields.RCV_PROOF = 1
            dao_prf.fields.RCV_PROOF_DATE = Date.Now
            dao_prf.fields.FAKE_NAME = "DA-" & _process & "-" & con_year(Date.Now().Year()) & "-" & TR_ID & "-" & TYPE & "." & extensionname
            dao_prf.fields.REAL_NAME = fileupload.FileName
            dao_prf.update()

        End If

    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim dao As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao.GetDataby_IDA(TextBox1.Text)

        If dao.fields.CITIEZEN_ID_AUTHORIZE <> _CLS.CITIZEN_ID_AUTHORIZE Then
            alert("ไม่พบรหัสดำเนินการนี้")
        Else
            Dim dao_drsamp As New DAO_DRUG.ClsDBdrsamp
            Try
                dao_drsamp.GetDataby_TR_ID(TextBox1.Text)
                Label1.Text = "ชื่อยา (Th/Eng) : " + dao_drsamp.fields.thadrgnm + "/" + dao_drsamp.fields.engdrgnm
            Catch ex As Exception

            End Try
        End If

    End Sub
End Class