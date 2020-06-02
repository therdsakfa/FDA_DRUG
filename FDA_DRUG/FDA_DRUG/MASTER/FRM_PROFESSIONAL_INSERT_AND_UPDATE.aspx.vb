Public Class FRM_PROFESSIONAL_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_ddl_prefix()
            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_DRUG.TB_MAS_EXPERT_NAME
                dao.GetDataby_IDA(Request.QueryString("ida"))
                Try
                    ddl_prefix.DropDownSelectData(dao.fields.PREFIXCD)
                Catch ex As Exception

                End Try
                txt_CITIZEN_ID.Text = dao.fields.IDENTIFY
                txt_name.Text = dao.fields.FULLNAME
                'txt_SURNAME.Text = dao.fields.SURNAME
            End If
        End If
    End Sub
    Public Sub bind_ddl_prefix()
        Dim bao As New BAO_SHOW
        Dim dt As DataTable = bao.SP_SYSPREFIX_DDL

        ddl_prefix.DataSource = dt
        ddl_prefix.DataBind()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_MAS_EXPERT_NAME
        If Request.QueryString("ida") <> "" Then
            dao.GetDataby_IDA(Request.QueryString("ida"))
            dao.fields.IDENTIFY = txt_CITIZEN_ID.Text
            dao.fields.NAME = txt_name.Text
            'dao.fields.SURNAME = txt_SURNAME.Text
            dao.fields.PREFIXCD = ddl_prefix.SelectedValue
            Try
                dao.fields.FULLNAME = txt_name.Text 'ddl_prefix.SelectedItem.Text & " " & txt_name.Text & " " & txt_SURNAME.Text
            Catch ex As Exception

            End Try
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');parent.close_modal();", True)
        Else
            Dim dao_chk As New DAO_DRUG.TB_MAS_EXPERT_NAME
            dao_chk.GetDataby_ctzno(txt_CITIZEN_ID.Text)
            If dao_chk.fields.IDA = 0 Then
                dao.fields.IDENTIFY = txt_CITIZEN_ID.Text
                dao.fields.NAME = txt_name.Text
                'dao.fields.SURNAME = txt_SURNAME.Text
                dao.fields.PREFIXCD = ddl_prefix.SelectedValue
                Try
                    dao.fields.FULLNAME = txt_name.Text 'ddl_prefix.SelectedItem.Text & " " & txt_name.Text & " " & txt_SURNAME.Text
                Catch ex As Exception

                End Try
                dao.insert()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถบันทึกซ้ำได้');", True)
            End If
           
        End If

      
    End Sub
End Class