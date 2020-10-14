Public Class FRM_STAFFNYM_RCV_MANUAL
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    Public Property _process As String
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _process = Request.QueryString("process")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            txt_rcvdate.Text = Date.Now.ToShortDateString()
            bind_ddl_receiver()
            Try
                Dim dao As New DAO_DRUG.ClsDBdalcn
                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao.GetDataby_IDA(_IDA)
                dao_up.GetDataby_IDA(dao.fields.TR_ID)
                'If dao_up.fields.PROCESS_ID = "104" Or dao_up.fields.PROCESS_ID = "105" Then
                Label1.Style.Add("display", "block")
                ddl_template.Style.Add("display", "block")
                'End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub bind_ddl_receiver()
        Dim dao As New DAO_DRUG.TB_MAS_DOCUMENT_RECEIVER  'dropdown ชื่อ ผู้รับคำขอ'
        dao.GetDataALL()
        ddl_receiver.DataSource = dao.datas
        ddl_receiver.DataTextField = "THANM"
        ddl_receiver.DataValueField = "IDA"

        ddl_receiver.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.GenNumber

            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)

            AddLogStatus(3, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

            Dim PROCESS_ID As Integer = dao.fields.process_id

            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_Process_ID(PROCESS_ID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

            dao.fields.RCVNO_MANUAL = Txt_rcvno.Text
            Try
                dao.fields.rcvdate = CDate(txt_rcvdate.Text)
            Catch ex As Exception

            End Try

            dao.fields.TEMPORARY_RCVNO = Txt_rcvno_temp.Text
            Try

            Catch ex As Exception

            End Try
            'If dao_up.fields.PROCESS_ID = "104" and  Then
            Try
                dao.fields.TEMPLATE_ID = ddl_template.SelectedValue
            Catch ex As Exception

            End Try

            'End If
            Try
                dao.fields.rcvr_id = _CLS.CITIZEN_ID
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
        Response.Redirect("FRM_STAFFNYM_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _process)

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)
        dao.fields.STATUS_ID = 2
        dao.update()

        Response.Redirect("FRM_STAFFNYM_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _process)
    End Sub
End Class