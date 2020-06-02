Public Class UC_INFMT
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Shows(ByVal IDA As Integer)
        Try

            Dim bao As New BAO_MASTER
            Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            Dim dt As New DataTable
            dt = bao.SP_ADDR_BY_IDA(IDA)
            Dim addr As String = ""
            If dt.Rows.Count > 0 Then
                addr = dt(0)("fulladdr")
            End If
            dao.GetDataby_IDA(IDA)
            Try
                txt_addr.Text = addr
            Catch ex As Exception

            End Try
            Try
                txt_addrnm.Text = dao.fields.thanameplace
            Catch ex As Exception

            End Try
            Try
                txt_date.Text = dao.fields.rcvdate.Value.ToLongDateString()
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

    End Sub


End Class