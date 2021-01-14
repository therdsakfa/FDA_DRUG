Public Class FRM_STAFF_LCN_CONSIDER_UPDATE
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
            Bind_ddl_staff_offer()
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(_IDA)
            getdata(dao)
        End If
    End Sub
    Public Sub getdata(ByRef dao As DAO_DRUG.ClsDBdalcn)
        Try
            TextBox1.Text = CDate(dao.fields.CONSIDER_DATE)
        Catch ex As Exception
            TextBox1.Text = Date.Now.ToShortDateString()
        End Try
        Try
            ddl_staff_offer.SelectedValue = dao.fields.FK_STAFF_OFFER_IDA
        Catch ex As Exception

        End Try

        Try
            txt_app_date.Text = CDate(dao.fields.appdate).ToShortDateString()
        Catch ex As Exception
            txt_app_date.Text = Date.Now.ToShortDateString()
        End Try
        Txt_Remark.Text = dao.fields.remark
    End Sub
    Public Sub set_data(ByRef dao As DAO_DRUG.ClsDBdalcn)
        dao.fields.remark = Txt_Remark.Text
        Try
            dao.fields.CONSIDER_DATE = CDate(TextBox1.Text)
        Catch ex As Exception
            dao.fields.CONSIDER_DATE = Nothing
        End Try
        dao.fields.FK_STAFF_OFFER_IDA = ddl_staff_offer.SelectedValue
        Try
            dao.fields.appdate = CDate(txt_app_date.Text)
            Try
                dao.fields.frtappdate = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            Try
                dao.fields.FIRST_APP_DATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try
            If IsNothing(dao.fields.appdate) = False Then
                Dim appdate As Date = CDate(dao.fields.appdate)
                Dim expyear As Integer = 0
                Try
                    expyear = Year(appdate)
                    If expyear <> 0 Then
                        If expyear < 2500 Then
                            expyear += 543
                        End If
                        dao.fields.expyear = expyear
                    End If
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            dao.fields.appdate = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)
        set_data(dao)
        dao.update()
        alert("บันทึกข้อมูลเรียบร้อย")
    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Public Sub Bind_ddl_staff_offer()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        bao.SP_STAFF_OFFER_DDL()

        ddl_staff_offer.DataSource = bao.dt
        ddl_staff_offer.DataBind()
    End Sub
End Class