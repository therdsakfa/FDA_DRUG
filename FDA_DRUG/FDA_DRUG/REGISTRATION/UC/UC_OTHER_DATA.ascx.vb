Public Class UC_OTHER_DATA
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            'ddl_drug_type.DropDownSelectData(dao.fields.kindcd)

            Dim dao_k As New DAO_DRUG.TB_DRUG_REGISTRATION_KEEP_DRUG
            dao_k.GetDataby_FK_IDA(Request.QueryString("IDA"))
            txt_keep.Text = dao_k.fields.KEEP_DETAIL
            Try
                txt_AGE_DAY.Text = dao_k.fields.AGE_DAY
            Catch ex As Exception

            End Try
            Try
                txt_AGE_HOUR.Text = dao_k.fields.AGE_HOUR
            Catch ex As Exception

            End Try
            Try
                txt_AGE_MONTH.Text = dao_k.fields.AGE_MONTH
            Catch ex As Exception

            End Try
            Try
                txt_TEMPERATE1.Text = dao_k.fields.TEMPERATE1
            Catch ex As Exception

            End Try
            Try
                txt_TEMPERATE2.Text = dao_k.fields.TEMPERATE2
            Catch ex As Exception

            End Try

            If Request.QueryString("tt") <> "" Then
                btn_insert.Visible = False
            End If
        End If
    End Sub
    Sub bind_ddl()
        'Dim dt As New DataTable
        'Dim bao As New BAO_MASTER
        'dt = bao.SP_drkdofdrg()

        'ddl_drug_type.DataSource = dt
        'ddl_drug_type.DataTextField = "thakindnm"
        'ddl_drug_type.DataValueField = "kindcd"
        'ddl_drug_type.DataBind()

        'Dim item As New ListItem
        'item.Text = "--กรุณาเลือก--"
        'item.Value = "0"
        'ddl_drug_type.Items.Insert(0, item)
    End Sub
    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        'Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        'dao.GetDataby_IDA(Request.QueryString("IDA"))
        'dao.fields.kindcd = ddl_drug_type.SelectedValue
        'dao.update()

        Dim dao_c As New DAO_DRUG.TB_DRUG_REGISTRATION_KEEP_DRUG
        Dim amount As Integer = 0
        amount = dao_c.count_id(Request.QueryString("IDA"))
        If amount = 0 Then
            Dim dao_k As New DAO_DRUG.TB_DRUG_REGISTRATION_KEEP_DRUG
            dao_k.fields.KEEP_DETAIL = txt_keep.Text
            dao_k.fields.FK_IDA = Request.QueryString("IDA")
            Try
                dao_k.fields.AGE_DAY = txt_AGE_DAY.Text
            Catch ex As Exception
                dao_k.fields.AGE_DAY = 0
            End Try
            Try
                dao_k.fields.AGE_HOUR = txt_AGE_HOUR.Text
            Catch ex As Exception
                dao_k.fields.AGE_HOUR = 0
            End Try
            Try
                dao_k.fields.AGE_MONTH = txt_AGE_MONTH.Text
            Catch ex As Exception
                dao_k.fields.AGE_MONTH = 0
            End Try
            Try
                dao_k.fields.TEMPERATE1 = txt_TEMPERATE1.Text
            Catch ex As Exception
                dao_k.fields.TEMPERATE1 = 0
            End Try
            Try
                dao_k.fields.TEMPERATE2 = txt_TEMPERATE2.Text
            Catch ex As Exception
                dao_k.fields.TEMPERATE2 = 0
            End Try

            dao_k.insert()
        Else
            Dim dao_k As New DAO_DRUG.TB_DRUG_REGISTRATION_KEEP_DRUG
            dao_k.GetDataby_FK_IDA(Request.QueryString("IDA"))
            dao_k.fields.KEEP_DETAIL = txt_keep.Text
            Try
                dao_k.fields.AGE_DAY = txt_AGE_DAY.Text
            Catch ex As Exception
                dao_k.fields.AGE_DAY = 0
            End Try
            Try
                dao_k.fields.AGE_HOUR = txt_AGE_HOUR.Text
            Catch ex As Exception
                dao_k.fields.AGE_HOUR = 0
            End Try
            Try
                dao_k.fields.AGE_MONTH = txt_AGE_MONTH.Text
            Catch ex As Exception
                dao_k.fields.AGE_MONTH = 0
            End Try
            Try
                dao_k.fields.TEMPERATE1 = txt_TEMPERATE1.Text
            Catch ex As Exception
                dao_k.fields.TEMPERATE1 = 0
            End Try
            Try
                dao_k.fields.TEMPERATE2 = txt_TEMPERATE2.Text
            Catch ex As Exception
                dao_k.fields.TEMPERATE2 = 0
            End Try
            dao_k.update()
        End If
        alert("บันทึกเรียบร้อย")
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class