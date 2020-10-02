Public Class FRM_STAFF_LCN_LCNNO_MANUAL
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

        End If
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.GenNumber

            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)

            AddLogStatus(8, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
            Dim PROCESS_ID As Integer = dao.fields.PROCESS_ID

            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_PROCESS_ID(PROCESS_ID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

            dao.fields.LCNNO_MANUAL = Txt_lcnno.Text
            Try

            Catch ex As Exception

            End Try
            dao.update()
            alert("บันทึกข้อมูลเรียบร้อย")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('กรุณาตรวจสอบข้อมูล');</script> ")
        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class