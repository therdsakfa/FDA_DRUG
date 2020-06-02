Public Class UC_PHR_CANCEL
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click
        Search_FN()
        rg_name.Rebind()
    End Sub
    Sub Search_FN()
        Dim dt As New DataTable
        Dim command As String = " "
        Dim bao_aa As New BAO.ClsDBSqlcommand
        command = "select top(1) * from dbo.Vw_PHR_SEARCH "
        Dim str_where As String = ""
        Dim str_where2 As String = ""
        Dim str_where3 As String = ""
        Dim dt2 As New DataTable
        Dim str_phr_text_num As String = txt_phr_text_num.Text
        Dim str_txt_ctzno As String = txt_ctzno.Text
        Dim str_name As String = txt_SEARCH.Text

        If str_phr_text_num = "" And str_name = "" And str_txt_ctzno = "" Then
            alert("กรุณากรอกข้อมูลที่ต้องการค้นหา")
        Else
            If str_phr_text_num <> "" Then
                str_where = " PHR_TEXT_NUM like '%" & str_phr_text_num & "%'"
                'command &= str_where
               
            End If

            If str_txt_ctzno <> "" Then

                If str_where <> "" Then
                    str_where &= " and PHR_CTZNO like '%" & str_txt_ctzno & "%'"
                Else
                    str_where &= " PHR_CTZNO like '%" & str_txt_ctzno & "%'"
                End If

                'command &= str_where2

            End If

            If str_name <> "" Then
                'str_where = " PHR_NAME like '%" & str_txt_ctzno & "%'"
                If str_where <> "" Then
                    str_where &= " and PHR_NAME like '%" & str_txt_ctzno & "%'"
                Else
                    str_where &= " PHR_NAME like '%" & str_txt_ctzno & "%'"
                End If
            End If

            command &= " where " & str_where
        End If

        dt = bao_aa.Queryds(command)
        rg_name.DataSource = dt

    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class