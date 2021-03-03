Public Class FRM_STAFF_LCN_APPROVE
    Inherits System.Web.UI.Page

    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            Try
                If dao.fields.TABLET_CAPSULE = "ยังไม่ระบุผู้ลงนาม" Then
                    txt_name.Text = ""
                    Try
                        lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
                    Catch ex As Exception

                    End Try
                    Try
                        txt_position.Text = dao.fields.PHARMACEUTICAL_CHEMICALS
                    Catch ex As Exception

                    End Try
                Else
                    txt_name.Text = dao.fields.TABLET_CAPSULE
                    Try
                        lbl_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
                    Catch ex As Exception

                    End Try
                    Try
                        txt_position.Text = dao.fields.PHARMACEUTICAL_CHEMICALS
                    Catch ex As Exception

                    End Try
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(txt_name.Text) = 0 Or Len(txt_position.Text) = 0 Then
            Response.Write("<script type='text/javascript'>alert('กรุณากรอกข้อมูลให้ครบถ้วน');</script> ")
        Else
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 8
            dao.fields.PHARMACEUTICAL_CHEMICALS = txt_position.Text

            dao.fields.TABLET_CAPSULE = txt_name.Text
            dao.update()

            'Try
            '    Dim ws_update As New WS_DRUG.WS_DRUG
            '    ws_update.DRUG_INSERT_LICEN(Request.QueryString("IDA"), _CLS.CITIZEN_ID)
            'Catch ex As Exception

            'End Try

            Try
                Dim ws_update126 As New WS_DRUG_126.WS_DRUG
                ws_update126.DRUG_INSERT_LICEN_126(Request.QueryString("IDA"), _CLS.CITIZEN_ID)
            Catch ex As Exception

            End Try

            AddLogStatus(8, Request.QueryString("process"), _CLS.CITIZEN_ID, _IDA)
            alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        End If

    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class