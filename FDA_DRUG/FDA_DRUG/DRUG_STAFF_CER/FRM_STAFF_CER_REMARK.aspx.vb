Public Class FRM_STAFF_CER_REMARK
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer
    ' Private _type As String

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
            Dim dao As New DAO_DRUG.TB_CER
            dao.GetDataby_IDA2(_IDA)
            dao.fields.STATUS_ID = 7
            dao.fields.REMARK = Txt_Remark.Text
            Try
                dao.fields.rcvdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_up.GetDataby_IDA(_TR_ID)
            Try
                Dim ws As New AUTHEN_LOG.Authentication
                ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "จนท.คืนคำขอ Cert", dao_up.fields.PROCESS_ID)
                AddLogStatus(7, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
            Catch ex As Exception

            End Try


            alert("ดำเนินการคืนคำขอเรียบร้อยแล้ว")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_STAFF_CER_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class