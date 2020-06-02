Public Class POPUP_LCN_SELL_TYPE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_select_cb()
        End If
        If Request.QueryString("ida") <> "" Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("ida"))
            If dao.fields.STATUS_ID > 1 Then
                btn_save.Style.Add("display", "none")
            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim i As Integer = 0
        For Each item As ListItem In cb_sell.Items
            If item.Selected Then
                i += 1
            End If
        Next
        If i > 0 Then
            Dim dao As New DAO_DRUG.TB_DALCN_SELL_TYPE
            dao.GetDataby_FK_IDA(Request.QueryString("ida"))
            For Each dao.fields In dao.datas
                dao.delete()
            Next
        End If

        For Each item As ListItem In cb_sell.Items
            If item.Selected Then
                Dim dao As New DAO_DRUG.TB_DALCN_SELL_TYPE
                dao.fields.FK_IDA = Request.QueryString("ida")
                dao.fields.SELL_TYPE = item.Value
                dao.insert()
            End If

        Next
        If i > 0 Then
            alert("บันทึกเรียบร้อย")
        Else
            alert("กรุณาเลือกประเภทขายส่ง")
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub bind_select_cb()
        Dim dao As New DAO_DRUG.TB_DALCN_SELL_TYPE
        dao.GetDataby_FK_IDA(Request.QueryString("ida"))
        For Each dao.fields In dao.datas
            For Each item As ListItem In cb_sell.Items
                If item.Value = dao.fields.SELL_TYPE Then
                    item.Selected = True
                End If
            Next
        Next

        'For Each item As ListItem In cb_sell.Items
        '    If item.Selected Then

        '        dao.fields.FK_IDA = Request.QueryString("ida")
        '        dao.fields.SELL_TYPE = item.Value
        '        dao.insert()
        '    End If
        'Next
    End Sub
End Class