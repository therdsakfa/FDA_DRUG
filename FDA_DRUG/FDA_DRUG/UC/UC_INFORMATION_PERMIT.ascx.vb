Public Class UC_INFORMATION_PERMIT
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Sho(ByVal IDA As Integer)

        Dim Tb As New DAO_CPN.TB_LOCATION_ADDRESS                               ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim TbNO As New DAO_DRUG.ClsDBdalcn                                     ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim tb_location As New DAO_CPN.TB_LOCATION_BSN
        TbNO.GetDataby_IDA(IDA) 'การ where 
        lbl_lcnno.Text = TbNO.fields.LCNNO_DISPLAY

        lbl_rcvno.Text = TbNO.fields.RCVNO_DISPLAY                                      ' เอาข้อมูลมาโชว์ที่  label

    End Sub
End Class