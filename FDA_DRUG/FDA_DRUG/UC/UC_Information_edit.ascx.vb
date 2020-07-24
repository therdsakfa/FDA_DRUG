Public Class UC_Information_edit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Shows(ByVal IDA As Integer)

        Dim Tb As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS                               ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim TbNO As New DAO_DRUG.ClsDBdalcn                                     ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            TbNO.GetDataby_IDA(IDA)
            'การ where 
            Tb.GetDataby_IDA(TbNO.fields.FK_IDA)
        Catch ex As Exception

        End Try
        'การ where 
        Try
            tb_location.Getdata_by_fk_id2(TbNO.fields.IDA)
        Catch ex As Exception

        End Try
        'การ where
        Try
            lbl_lcnno.Text = TbNO.fields.LCNNO_DISPLAY
        Catch ex As Exception
            lbl_lcnno.Text = "-"
        End Try

        'lbl_rcvno.Text = TbNO.fields.RCVNO_DISPLAY                                     ' เอาข้อมูลมาโชว์ที่  label
        ' เอาข้อมูล แล้วเปลี่ยนตัดค่า เวลาออก
        Try
            lbl_thanameplace.Text = Tb.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            ' เอาข้อมูลมาโชว์ที่  label
            lbl_nameOperator.Text = tb_location.fields.BSN_THAIFULLNAME 'tb_location.fields.BSN_THAIFULLNAME             ' เอาข้อมูลมาโชว์ที่  label
        Catch ex As Exception

        End Try
        
        'Try
        '    lbl_rcvdate.Text = CDate(TbNO.fields.rcvdate).ToLongDateString()
        'Catch ex As Exception

        'End Try


    End Sub
End Class