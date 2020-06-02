Imports System.IO
Imports System.Xml.Serialization
Public Class FRM_CHEMICAL_MAINV2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _lct_ida As String = ""
    Private _lcn_ida As String = ""
    Private _process As String = "" 'ประกาศชื่อตัวแปร _process
    Private _mt As String = ""
    Private _st As String
    Sub runQuery()
        _lct_ida = Request.QueryString("lct_ida")
        _lcn_ida = Request.QueryString("lcn_ida")
        _mt = Request.QueryString("mt")
        _st = Request.QueryString("st")
        _process = Request.QueryString("process")
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
        If Not IsPostBack Then
            load_GV_data()
            'UC_Information1.Shows(_lcn_ida)
        End If

        set_page_name()
    End Sub

    Sub load_GV_data()                                                          ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand                                      'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        GV_data.DataSource = bao.SP_CHEMICAL_REQUEST_CUSTOMER(_lcn_ida, _mt, _st)   'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable
        'GV_data.DataSource = bao.SP_CHEMICAL_REQUEST_CUSTOMER_V2(_lcn_ida, _mt)
        GV_data.DataBind()                                                      'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_data   เพื่อให้ข้อมูลวิ่ง
    End Sub
    Public Sub set_page_name()
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU
        lbl_name_page.Text = "เพิ่มสาร "
        Try
            dao.GetDataby_Process2(Request.QueryString("process"))
            lbl_name_page.Text &= dao.fields.NAME
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_data()
    End Sub


    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        If e.CommandName = "del" Then
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(str_ID)
            dao.delete()
            Response.Write("<script type='text/javascript'>alert('ลบข้อมูลเรียบร้อย');</script> ")
            load_GV_data()
        ElseIf e.CommandName = "accept" Then
            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(str_ID)
            dao.fields.STATUS_ID = 2
            dao.update()
            'Response.Write("<script type='text/javascript'>alert('ยืนยันข้อมูลเรียบร้อย');</script> ")
            load_GV_data()
        End If
    End Sub

    Private Sub GV_data_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_data.RowDataBound
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('../CHEMICAL/FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE.aspx?IDA=" & str_ID & "'); return false;", True)
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim btn_edit As Button = DirectCast(e.Row.FindControl("btn_edit"), Button)
            'Dim btn_del As Button = DirectCast(e.Row.FindControl("btn_del"), Button)
            Dim btn_accept As Button = DirectCast(e.Row.FindControl("btn_accept"), Button)
            Dim ida As String = GV_data.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            btn_edit.Attributes.Add("onclick", "Popups2('../CHEMICAL/FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE.aspx?IDA=" & ida & "'); return false;")

            Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
            dao.GetDataby_IDA(ida)

            'If dao.fields.SUB_TYPE = 1 Then
            '    btn_edit.Style.Add("display", "none")
            'End If
            Try
                If dao.fields.STATUS_ID <> 1 Then
                    btn_accept.Style.Add("display", "none")
                End If
                'If dao.fields.REGIS_STATUS = "R" AndAlso dao.fields.REGIS_STATUS = "NR" Then
                '    btn_edit.Style.Add("display", "none")
                '    btn_del.Style.Add("display", "none")
                'End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        GV_data.DataBind()
    End Sub
End Class