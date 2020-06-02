Imports Telerik.Web.UI

Public Class FRM_REPLACEMENT_DRUG_BOOKING_ADDRESS
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _type As String
    Private _ProcessID As Integer
    Private _IDENTIFY As String
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _ProcessID = 99 ' ProcessID สถานที่ตั้ง
                _IDENTIFY = Request.QueryString("IDENTIFY")
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

#Region "javascript"
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Private Sub alert_close_popup(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal_address();</script> ")
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

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        Try
            If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
                Dim item As GridDataItem
                item = e.Item

                Dim fulladdr As String = item("fulladdr").Text
                Dim thanameplace As String = item("thanameplace").Text

                If e.CommandName = "sel" Then

                    _CLS.LOCATION_NAME = thanameplace
                    _CLS.LOCATION_ADDRESS = fulladdr
                    Session("CLS") = _CLS
                    alert_close_popup("เลือกข้อมูลเรียบร้อยแล้ว")
                    ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_REPLACEMENT_NCT_BOOKING_STATUS.aspx?SCHEDULE_ID=" & str_SCHEDULE_ID & "');", True)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub




    Protected Sub btn_thanameplace_Click(sender As Object, e As EventArgs) Handles btn_thanameplace.Click
        Try
            Dim str As String = ""
            str = UC_SEARCH_thanameplace1.getSearchMsg()
            If str = "" Then
                RadGrid1.Rebind()
            Else

                RadGrid1.EnableLinqExpressions = False
                RadGrid1.MasterTableView.FilterExpression = str
                RadGrid1.MasterTableView.Rebind()

            End If
        Catch ex As Exception

        End Try

    End Sub


    Sub radgrid_databind()
        Try
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt_data_ALL As New DataTable

            dt_data_ALL = bao.SP_CUSTOMER_LOCATION_ADDRESS_by_LOCATION_TYPE_ID_and_IDENTITY(1, _IDENTIFY) 'เรียกใช้เพื่อดึงข้อมูลสถานที่ตั้ง
            RadGrid1.DataSource = dt_data_ALL
            ' RadGrid1.Rebind()
        Catch ex As Exception

        End Try

    End Sub


    ''' <summary>
    ''' เช็ค จังหวัดซ้ำ 
    ''' </summary>
    ''' <param name="province_id"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks>True คือ  ไม่ซ้ำ ,False คือ ซ้ำ</remarks>
    Private Function chk_province(ByVal province_id As Integer, ByVal dt As DataTable) As Boolean

        Dim chk As Boolean = True
        Try
            For Each dr As DataRow In dt.Rows
                If IsDBNull(dr("chngwtcd")) = False Then
                    If province_id = dr("chngwtcd") Then
                        chk = False
                    End If
                End If

            Next
        Catch ex As Exception

        End Try


        Return chk
    End Function

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Try
            radgrid_databind()

        Catch ex As Exception

        End Try


    End Sub
End Class