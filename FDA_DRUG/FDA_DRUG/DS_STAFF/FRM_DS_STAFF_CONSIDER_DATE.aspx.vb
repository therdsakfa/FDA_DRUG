Public Class FRM_DS_STAFF_CONSIDER_DATE
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
            'TextBox1.Text = Date.Now.ToShortDateString()
            'txt_app_date.Text = Date.Now.ToShortDateString()
            Bind_ddl_staff_offer()
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            getdata(dao)
        End If
    End Sub
    Public Sub getdata(ByRef dao As DAO_DRUG.ClsDBdalcn)
        'Try
        '    TextBox1.Text = CDate(dao.fields.CONSIDER_DATE)
        'Catch ex As Exception
        '    TextBox1.Text = Date.Now.ToShortDateString()
        'End Try
        'Try
        '    ddl_staff_offer.SelectedValue = dao.fields.FK_STAFF_OFFER_IDA
        'Catch ex As Exception

        'End Try

        'Try
        '    txt_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
        'Catch ex As Exception
        '    txt_app_date.Text = Date.Now.ToShortDateString()
        'End Try
        Txt_Remark.Text = dao.fields.remark
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        dao.fields.remark = Txt_Remark.Text
        'Try
        '    dao.fields.CONSIDER_DATE = CDate(TextBox1.Text)
        'Catch ex As Exception
        '    dao.fields.CONSIDER_DATE = Nothing
        'End Try
        'dao.fields.FK_STAFF_OFFER_IDA = ddl_staff_offer.SelectedValue
        'Try
        '    dao.fields.appdate = CDate(txt_app_date.Text)
        'Catch ex As Exception
        '    dao.fields.appdate = Nothing
        'End Try
    End Sub

    ''' <summary>
    ''' บันทึกข้อมูล
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dao As New DAO_DRUG.ClsDBdrsamp
            Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            Dim bao As New BAO.GenNumber

            dao.GetDataby_IDA(_IDA)
            dao_up.GetDataby_IDA(dao.fields.TR_ID)

            AddLogStatus(6, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

            Dim PROCESS_ID As Integer = dao.fields.PROCESS_ID

            Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_p.GetDataby_Process_ID(PROCESS_ID)
            Dim GROUP_NUMBER As Integer = dao_p.fields.PROCESS_ID

            'Dim CONSIDER_DATE As Date = CDate(TextBox1.Text) 'วันที่เสนอลงนาม
            dao.fields.REMARK = Txt_Remark.Text 'หมายเหตุ
            dao.fields.STATUS_ID = 9    'สถานะเสนอลงนาม
            'dao.fields.CONSIDER_DATE = CONSIDER_DATE 'วันที่คาดว่าจะอนุมัติ

            'dao.fields.FK_STAFF_OFFER_IDA = ddl_staff_offer.SelectedValue 'ชื่อผู้ลงนาม
            'Try
            '    dao.fields.appdate = CDate(txt_app_date.Text)
            'Catch ex As Exception

            'End Try
            dao.update()


            alert("บันทึกข้อมูลเรียบร้อย")
        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Public Sub Bind_ddl_staff_offer()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_STAFF_OFFER_DDL()

        'ddl_staff_offer.DataSource = bao.dt
        'ddl_staff_offer.DataBind()
    End Sub
End Class