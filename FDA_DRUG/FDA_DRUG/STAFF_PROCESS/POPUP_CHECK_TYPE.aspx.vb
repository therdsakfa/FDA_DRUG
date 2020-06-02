Public Class WebForm5
    Inherits System.Web.UI.Page

    Private _process_type As String
    Private _TR_ID As String
    Private _IDA As String
    Private Sub RunQuery()
        _process_type = Request("process_type").ToString()
        _TR_ID = Request.QueryString("TR_ID").ToString()
        _IDA = Request.QueryString("IDA").ToString()
        '_ID = "710710"
        '_process_tpye = "5"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        check_type()
    End Sub
    Sub check_type()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        ' Dim dao_flabel As New DAO_DRUG.clsDBflabel
        'Dim dao_fregntf As New DAO_DRUG.clsDBfregntf
        ' Dim dao_freg As New DAO_DRUG.clsDBfreg
        Dim dao_lgt_impcer As New DAO_DRUG.TB_CER
        If _process_type = "1" Then ' คือสถานที่ผลิต
            dao_lcn.GetDataby_IDA(_IDA)
            If dao_lcn.fields.STATUS_ID >= 4 Then
                Response.Redirect("../LCN/FRM_LCN_CONFIRM.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA) 'server
            Else
                Response.Redirect("../LCN/FRM_LCN_CONFIRM_ADMIN.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA)
            End If

        ElseIf _process_type = "2" Then

            'ElseIf _process_type = "3" Then ' คือ สบ 3


            '    dao_flabel.GetDataby_ID(_IDA)

            '    If dao_flabel.fields.cnsdcd >= 4 Then
            '        Response.Redirect("../SORBOR3/FRM_SORBOR3_CONFIRM.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA) 'server
            '    Else
            '        Response.Redirect("../SORBOR3/FRM_SORBOR3_CONFIRM_ADMIN.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA)
            '    End If

        ElseIf _process_type = "4" Then

            'dao_freg.GetDataby_ID(_IDA)

            'If dao_freg.fields.cnsdcd >= 4 Then
            '    Response.Redirect("../RECIPE/FRM_RECIPE_CONFIRM.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA) 'server
            'Else
            '    Response.Redirect("../RECIPE/FRM_RECIPE_CONFIRM_ADMIN.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA)
            'End If

            'ElseIf _process_type = "5" Then ' คือ สบ 5

            '    dao_fregntf.GetDataby_ID(_IDA)

            '    ' If dao_fregntf.fields.cnsdcd >= 4 Then
            '    Response.Redirect("../STAFF_SORBOR5/FRM_STAFF_SORBOR5_CONFIRM.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA) 'server
            'Else
            '    Response.Redirect("../SORBOR5/FRM_SORBOR5_CONFIRM_ADMIN.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA)
            'End If

            'ElseIf _process_type = "6" Then ' คือ สบ 5-1

            '    dao_fregntf.GetDataby_ID(_IDA)

            '    If dao_fregntf.fields.cnsdcd >= 4 Then
            '        Response.Redirect("../SORBOR51/FRM_SORBOR51_CONFIRM.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA) 'server
            '    Else
            '        Response.Redirect("../SORBOR51/FRM_SORBOR51_CONFIRM_ADMIN.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA)
            '    End If

            'ElseIf _process_type = "7" Then ' คือ ตำรับ

            '    dao_freg.GetDataby_ID(_IDA)

            '    If dao_freg.fields.cnsdcd >= 4 Then
            '        Response.Redirect("../RECIPE/FRM_RECIPE_CONFIRM.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA) 'server
            '    Else
            '        Response.Redirect("../RECIPE/FRM_RECIPE_CONFIRM_ADMIN.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA)
            '    End If
        ElseIf _process_type = "8" Then ' คือ Cer

            dao_lgt_impcer.GetDataby_IDA2(_IDA)

            If dao_lgt_impcer.fields.STATUS_ID >= 4 Then
                Response.Redirect("../CER/FRM_CER_CONFIRM.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA) 'server
            Else
                Response.Redirect("../CER/FRM_CER_CONFIRM_ADMIN.aspx?TR_ID=" & _TR_ID & "&IDA=" & _IDA)
            End If
        End If

    End Sub
End Class