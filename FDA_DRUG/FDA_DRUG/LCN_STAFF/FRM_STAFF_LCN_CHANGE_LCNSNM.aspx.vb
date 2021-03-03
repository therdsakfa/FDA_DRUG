Public Class FRM_STAFF_LCN_CHANGE_LCNSNM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            bind_lcns()
        End If
    End Sub
    Sub bind_lcns()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
            Dim dao_lc As New DAO_CPN.clsDBsyslcnsnm
            dao_lc.GetDataby_lcnsid(dao.fields.lcnsid)
            Try
                lbl_lcnsnm_old.Text = dao_lc.fields.thanm & " " & dao_lc.fields.thalnm
            Catch ex As Exception

            End Try
            Try
                hf_lcn.Value = dao_lc.fields.lcnsid
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_search_lcn_Click(sender As Object, e As EventArgs) Handles btn_search_lcn.Click
        Dim dao_lcn As New DAO_CPN.clsDBsyslcnsnm
        dao_lcn.GetDataby_identify(txt_ctzid_lcn.Text)

        Dim dao_lcnsid As New DAO_CPN.tb_lcnsid
        dao_lcnsid.GetData_ByIdentify(txt_ctzid_lcn.Text)
        Dim name As String = "0"
        Try
            name = dao_lcn.fields.ID
        Catch ex As Exception

        End Try
        If name = "0" Then
            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script>")
        Else
            Try
                lbl_lcnname_new.Text = dao_lcn.fields.thanm & " " & dao_lcn.fields.thalnm
            Catch ex As Exception

            End Try
            Try
                hf_lcn.Value = dao_lcnsid.fields.lcnsid
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btn_lcn_Click(sender As Object, e As EventArgs) Handles btn_lcn.Click
        If hf_lcn.Value <> "" Then
            Try
                Dim dao_lcn As New DAO_CPN.clsDBsyslcnsnm
                dao_lcn.GetDataby_identify(txt_ctzid_lcn.Text)
                If dao_lcn.fields.ID <> 0 Then
                    Dim dao As New DAO_DRUG.ClsDBdalcn
                    dao.GetDataby_IDA(Request.QueryString("ida"))
                    dao.fields.lcnsid = hf_lcn.Value
                    dao.fields.CITIZEN_ID_AUTHORIZE = txt_ctzid_lcn.Text
                    dao.update()
                    'Dim ws_update As New WS_DRUG.WS_DRUG
                    'ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)

                    Dim ws_update126 As New WS_DRUG_126.WS_DRUG
                    ws_update126.DRUG_UPDATE_LICEN_126(Request.QueryString("ida"), _CLS.CITIZEN_ID)

                    KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขผู้รับอนุญาต", _CLS.CITIZEN_ID)
                Else
                    Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script>")
                End If
            Catch ex As Exception

            End Try
        Else
            Response.Write("<script type='text/javascript'>alert('ต้องค้นหาข้อมูลผู้รับอนุญาตก่อน');</script>")
        End If



    End Sub
End Class