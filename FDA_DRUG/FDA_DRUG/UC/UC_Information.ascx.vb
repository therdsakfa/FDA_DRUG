Public Class UC_Information
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub Shows(ByVal IDA As Integer)
        Try
            Dim Tb As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS                               ' ประกาศตัวแปรเพื่อเรียกใช้
            Dim TbNO As New DAO_DRUG.ClsDBdalcn                                     ' ประกาศตัวแปรเพื่อเรียกใช้
            Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN

            TbNO.GetDataby_IDA(IDA)                                                 'การ where 
            Tb.GetDataby_IDA(TbNO.fields.FK_IDA)                                    'การ where 

            Try
                tb_location.GetDataby_LCN_IDA(IDA)
            Catch ex As Exception

            End Try
            'การ where
            Try

            Catch ex As Exception

            End Try
            'lbl_lcnno.Text = TbNO.fields.LCNNO_DISPLAY
            Dim lcnno As String = ""
            Dim rcvno As String = ""
            Try
                lcnno = TbNO.fields.lcntpcd & " " & CInt(Right(TbNO.fields.lcnno, 5)) & "/" & Left(TbNO.fields.lcnno, 2)
            Catch ex As Exception

            End Try
            Try
                rcvno = CInt(Right(TbNO.fields.rcvno, 5)) & "/" & Left(TbNO.fields.rcvno, 2)
            Catch ex As Exception

            End Try
            Try
                If TbNO.fields.lcnno IsNot Nothing Then
                    Dim raw_lcn As String = TbNO.fields.lcnno
                    lbl_lcnno.Text = lcnno 'CStr(CInt((Right(raw_lcn, 5))) & "/25" & Left(raw_lcn, 2))
                End If
            Catch ex As Exception

            End Try

            lbl_rcvno.Text = rcvno                                    ' เอาข้อมูลมาโชว์ที่  label
            Try
                lbl_rcvdate.Text = CDate(TbNO.fields.rcvdate).ToLongDateString()       ' เอาข้อมูล แล้วเปลี่ยนตัดค่า เวลาออก
            Catch ex As Exception

            End Try

            lbl_thanameplace.Text = Tb.fields.thanameplace                          ' เอาข้อมูลมาโชว์ที่  label
            lbl_nameOperator.Text = TbNO.fields.BSN_THAIFULLNAME             ' เอาข้อมูลมาโชว์ที่  label

            If lbl_nameOperator.Text = "" Then
                Try
                    Dim dao_lcns As New DAO_CPN.clsDBsyslcnsnm
                    dao_lcns.GetDataby_lcnsid(TbNO.fields.bsnid)
                    lbl_nameOperator.Text = dao_lcns.fields.prefixnm & dao_lcns.fields.thanm & " " & dao_lcns.fields.thalnm
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
        

    End Sub
End Class