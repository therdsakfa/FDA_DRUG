Imports Telerik.Web.UI

Public Class FRM_REPLACEMENT_DRUG_BOOKING_VISITOR
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As Integer

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _ProcessID = 99 ' ProcessID สถานที่ตั้ง

            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
        End If
    End Sub
    Protected Sub btn_SEARCH_Click(sender As Object, e As EventArgs) Handles btn_SEARCH.Click

        Try
            If String.IsNullOrEmpty(txt_SEARCH.Text) = True And String.IsNullOrEmpty(txt_NUM.Text) = True Then
                alert("กรุณากรอกข้อมูล")
            Else
                Dim dao As New DAO_CPN.TB_syslcnsnm
                dao.GetDataby_thanm(txt_SEARCH.Text)
                Dim bao As New BAO.ClsDBSqlcommand
                rg_name.DataSource = bao.SP_MEMBER_THANM_THANM_by_thanm_and_IDENTIFY(txt_SEARCH.Text, txt_NUM.Text)
                rg_name.Rebind()
            End If

        Catch ex As Exception
        End Try

    End Sub

#Region "javascript"
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub alert_close_popup(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal_visitor();</script> ")
    End Sub
    Private Sub close_popup()
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
    Private Sub alert_window_open_self(ByVal text As String, ByVal URL As String)
        Response.Write("<script type='text/javascript'>alert('" & text & "');window.open('" & URL & "','_self');</script> ")
    End Sub
    Private Sub alert_window_open_self_reload(ByVal text As String, ByVal URL As String)
        Response.Write("<script type='text/javascript'>parent.reload();alert('" & text & "');window.open('" & URL & "','_self');</script> ")
    End Sub
    Private Sub window_open_self(ByVal URL As String)
        Response.Write("<script type='text/javascript'>window.open('" & URL & "','_self');</script> ")
    End Sub
    Private Sub window_open_self_reload(ByVal URL As String)
        Response.Write("<script type='text/javascript'>parent.reload();window.open('" & URL & "','_self');</script> ")
    End Sub

#End Region

    Private Sub rg_name_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_name.ItemCommand
        Try
            If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
                Dim item As GridDataItem
                item = e.Item
                Dim fullname As String = item("fullname2").Text
                Dim IDENTIFY As String = item("IDENTIFY").Text

                If e.CommandName = "sel" Then

                    _CLS.NAME_VISITOR = fullname
                    _CLS.IDENTIFY_VISITOR = IDENTIFY
                    Session("CLS") = _CLS
                    alert_close_popup("เลือกข้อมูลเรียบร้อยแล้ว")
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


End Class