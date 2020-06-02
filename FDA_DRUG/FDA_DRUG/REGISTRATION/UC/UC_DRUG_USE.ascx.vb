Public Class UC_DRUG_USE
    Inherits System.Web.UI.UserControl
    Private _IDA As Integer = 0
    Private _DTL_IDA As Integer
    Sub RunQuery()
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception
            _IDA = 0
        End Try
        Try
            _DTL_IDA = Request.QueryString("dtl")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'Dim dao_re As New DAO_DRUG.ClsDBdrrgt
        'dao_re.GetDataby_IDA(_IDA)
        If Not IsPostBack Then
            If _IDA <> 0 Then
                Dim dao_dtl As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
                dao_dtl.GetDataby_FK_IDA(_IDA)
                Try
                    txt_dtl.Text = dao_dtl.fields.DRUG_USE
                Catch ex As Exception

                End Try

            End If
            If Request.QueryString("tt") <> "" Then
                btn_insert.Visible = False
            End If
        End If

    End Sub

    Protected Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
        Dim dao_re As New DAO_DRUG.ClsDBdrrgt
        dao_re.GetDataby_IDA(_IDA)

        Try
            Dim c As Integer = 0
            c = dao.count_id(_IDA)
            If c = 0 Then
                Dim dao_dtl As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
                setdata(dao_dtl)
                dao_dtl.fields.FK_IDA = Request.QueryString("IDA")
                dao_dtl.insert()
            Else
                Dim dao_dtl As New DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE
                dao_dtl.GetDataby_FK_IDA(_IDA)
                setdata(dao_dtl)
                dao_dtl.update()
            End If
            alert("บันทึกเรียบร้อยแล้ว")
        Catch ex As Exception

        End Try
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.TB_DRUG_REGISTRATION_DRUG_USE)
        dao.fields.DRUG_USE = txt_dtl.Text
    End Sub

End Class