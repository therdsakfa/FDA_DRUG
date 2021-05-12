Public Class FRM_DS_STAFF_REMARK
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
            _ProcessID = Request.QueryString("process")
            ' _type = "1"
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            txt_app_date.Text = Date.Now.ToShortDateString()
            'default_Remark()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 7
            dao.fields.REMARK = Txt_Remark.Text
            Try
                dao.fields.appdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()

            AddLogStatusDS(7, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
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
