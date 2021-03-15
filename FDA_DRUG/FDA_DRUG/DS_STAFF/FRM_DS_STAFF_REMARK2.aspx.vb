Public Class FRM_DS_STAFF_REMARK2
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
            _ProcessID = Request.QueryString("PROCESS_ID")
            ' _type = "1"
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            txt_app_date.Text = Date.Now.ToShortDateString()
            If _ProcessID = "1701" Then
                Txt_Remark.Text = "ภายใน 2 ปี นับตั้งแต่วันที่อนุญาต"
            ElseIf _ProcessID = "1702" Then
                Txt_Remark.Text = "ใช้ได้ครั้งเดียวเท่านั้น นับตั้งแต่วันที่อนุญาต"
            End If
            'default_Remark()
            Try
                Dim dao As New DAO_DRUG.ClsDBdrsamp
                dao.GetDataby_IDA(_IDA)
                Txt_Remark.Text = dao.fields.REMARK
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim RCVNO As Integer
        Dim bao As New BAO.GenNumber

        Try
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 8
            dao.fields.REMARK = Txt_Remark.Text
            dao.fields.staff_approved_iden = _CLS.CITIZEN_ID
            dao.fields.appdate = Date.Now
            Try
                dao.fields.rcvdate = CDate(txt_app_date.Text)
                RCVNO = bao.GEN_RCVNO_NO(con_year(Date.Now.Year()), _CLS.PVCODE, _ProcessID, _IDA)
                dao.fields.rcvno = RCVNO
            Catch ex As Exception

            End Try
            dao.update()

            AddLogStatus(8, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            alert("ดำเนินการอนุมัติเรียบร้อยแล้ว")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_DS_STAFF_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID)

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class
