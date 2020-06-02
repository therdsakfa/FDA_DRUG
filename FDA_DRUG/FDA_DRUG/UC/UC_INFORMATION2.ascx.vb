Public Class UC_INFORMATION2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Shows(ByVal IDA As Integer)

        Dim bao As New BAO_SHOW
        Dim Tb As New DAO_CPN.TB_LOCATION_ADDRESS                               ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
        Dim dt As New DataTable
        dt = bao.SP_ADDR_BY_IDA(IDA)
        dao.GetDataby_IDA(IDA)
        txt_date.Text = dao.fields.rcvdate.Value.ToLongDateString()
        txt_addrnm.Text = Tb.fields.thanameplace
        Dim addr As String = ""
        If dt.Rows.Count > 0 Then
            addr = dt(0)("fulladdr")
        End If

        txt_addr.Text = addr



    End Sub
End Class