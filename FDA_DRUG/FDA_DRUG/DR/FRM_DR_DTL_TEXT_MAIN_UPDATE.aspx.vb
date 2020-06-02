Public Class FRM_DR_DTL_TEXT_MAIN_UPDATE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
                dao.GetDataby_IDA(Request.QueryString("ida"))
                getdata(dao)
            End If
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("ida") <> "" Then
            Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            dao.GetDataby_IDA(Request.QueryString("ida"))
            setdata(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย'); parent.$('#ContentPlaceHolder1_btn_reload').click();", True)
        End If
    End Sub
    Public Sub getdata(ByRef dao As DAO_DRUG.TB_DRRGT_DTL_TEXT)
        txt_dtl.Text = dao.fields.dtl
        txt_keepdesc.Text = dao.fields.keepdesc
        txt_pcksize.Text = dao.fields.pcksize
        txt_tphigh.Text = dao.fields.tphigh
        txt_useage.Text = dao.fields.useage
    End Sub
    Public Sub setdata(ByRef dao As DAO_DRUG.TB_DRRGT_DTL_TEXT)
        dao.fields.dtl = txt_dtl.Text
        dao.fields.keepdesc = txt_keepdesc.Text
        dao.fields.pcksize = txt_pcksize.Text
        dao.fields.tphigh = txt_tphigh.Text
        dao.fields.useage = txt_useage.Text
    End Sub
End Class