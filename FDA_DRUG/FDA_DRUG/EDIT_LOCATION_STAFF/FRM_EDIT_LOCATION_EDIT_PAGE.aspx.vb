Public Class FRM_EDIT_LOCATION_EDIT_PAGE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        set_hide_show()
        If Not IsPostBack Then
            UC_LOCATION_ADDRESS_DETAIL1.load_ddl_chwt()
            UC_LOCATION_ADDRESS_DETAIL1.load_ddl_amp()
            UC_LOCATION_ADDRESS_DETAIL1.load_ddl_thambol()
            UC_LOCATION_ADDRESS_DETAIL1.call_lbl_set()

            UC_BSN_ADDRESS1.load_ddl_chwt()
            UC_BSN_ADDRESS1.load_ddl_amp()
            UC_BSN_ADDRESS1.load_ddl_thambol()
            UC_BSN_ADDRESS1.call_lbl_set()

            UC_BSN_NAME1.bind_ddl_prefix()

            If Request.QueryString("ida") <> "" Then
                Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                dao_lo.GetDataby_IDA(Request.QueryString("ida"))
                UC_NAME_LOCATION1.get_data(dao_lo)
                UC_LOCATION_ADDRESS_DETAIL1.get_data(dao_lo)

                Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                dao_bsn.Getdata_by_fk_id2(Request.QueryString("ida"))
                UC_BSN_NAME1.get_data(dao_bsn)
                UC_BSN_ADDRESS1.get_data(dao_bsn)

            End If
            UC_LOCATION_ADDRESS_DETAIL1.bind_lbl()
            UC_BSN_ADDRESS1.bind_lbl()
            UC_BSN_NAME1.bind_lbl()
        End If
    End Sub
    Public Sub set_hide_show()
        If Request.QueryString("edt") <> "" Then
            Dim edt As String = Request.QueryString("edt")
            Select Case edt
                Case "1"
                    Panel1.Style.Add("display", "block")
                    Panel2.Style.Add("display", "block")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                Case "2"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "block")
                    Panel3.Style.Add("display", "none")
                    Panel4.Style.Add("display", "none")
                Case "3"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "block")
                    Panel4.Style.Add("display", "block")
                Case "4"
                    Panel1.Style.Add("display", "none")
                    Panel2.Style.Add("display", "none")
                    Panel3.Style.Add("display", "block")
                    Panel4.Style.Add("display", "none")
            End Select
           
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("ida") <> "" Then
            Dim ida As Integer = Request.QueryString("ida")
            Dim edt As String = Request.QueryString("edt")

            Dim dao_lo As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
            dao_lo.GetDataby_IDA(ida)
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.Getdata_by_fk_id2(ida)

            If edt = "1" Or edt = "2" Then
                UC_NAME_LOCATION1.set_data(dao_lo)
                UC_LOCATION_ADDRESS_DETAIL1.set_data(dao_lo)
                dao_lo.update()
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "3" Then
                UC_BSN_NAME1.set_data(dao_bsn)
                UC_BSN_ADDRESS1.set_data(dao_bsn)
                dao_bsn.update()
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            ElseIf edt = "4" Then
                UC_BSN_NAME1.set_data(dao_bsn)
                dao_bsn.update()
                Response.Write("<script type='text/javascript'>alert('แก้ไขเรียบร้อย');</script> ")
            End If

        End If
    End Sub
End Class