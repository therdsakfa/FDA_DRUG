Public Class FRM_DRUG_PROJECT_MAIN_STAFF
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Private _ProcessID As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
        _ProcessID = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_lcnno()
        runQuery()
        If Not IsPostBack Then
            load_GV_data()
        End If
    End Sub
    Sub load_lcnno()
        'lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Sub load_GV_data()
        Dim bao As New BAO.ClsDBSqlcommand
        'นยม. 1
        bao.SP_DRUG_PROJECT_BY_STATUS(3)
        GV_data.DataSource = bao.dt
        GV_data.DataBind()
    End Sub

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_DRUG_PROJECT_CONFIRM_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _ProcessID & "');", True)
        ElseIf e.CommandName = "nym" Then
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Integer.Parse(str_ID))
            _CLS.LCNNO = dao.fields.LCNNO.ToString()
            Session("CLS") = _CLS

            ' Response.Redirect("../MAIN/FRM_NODE.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())
            Response.Redirect("../DRUG_CUSTOMER_NORYORMOR1/FRM_NORYORMOR1_MAIN.aspx?IDA=" & str_ID & "&fk_ida=" & str_ID & "&process=" & _ProcessID)

        End If
    End Sub
End Class