Public Class POPUP_STAFF_EXTEND_TIME_LOCATION_CONSIDER
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
            TextBox1.Text = Date.Now.ToShortDateString()
            txt_app_date.Text = Date.Now.ToShortDateString()
            'default_Remark()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.TB_LCN_EXTEND
            Dim bao As New BAO.GenNumber

            dao.GetDataby_IDA(_IDA)

            Dim PROCESS_ID As String = "0"
            Try
                PROCESS_ID = Request.QueryString("process")
            Catch ex As Exception

            End Try

            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_PROCESS_ID(PROCESS_ID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

            Dim CONSIDER_DATE As Date = CDate(TextBox1.Text)
            dao.fields.remark = Txt_Remark.Text
            dao.fields.STATUS_ID = 6
            dao.fields.CONSIDER_DATE = CONSIDER_DATE

            Try
                dao.fields.app_date = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            dao.update()
            alert("บันทึกข้อมูลเรียบร้อย")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub


    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    'End Sub
End Class