Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI

Public Class POPUP_STAFF_CER_EXP_CONFIRM
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _YEARS As String

    Sub RunSession()
        Try
            _process = Request.QueryString("process")
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        If Not IsPostBack Then
            txt_app_date.Text = Date.Now.ToShortDateString()
            show_btn(_IDA)
            UC_GRID_ATTACH1.load_gv_V2(_TR_ID, _process)
            Bind_ddl_Status_staff()
            Dim dao As New DAO_DRUG.TB_CER_EXTEND
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                txt_cer_DATE.Text = CDate(dao.fields.DOCUMENT_DATE).ToShortDateString()
            Catch ex As Exception

            End Try
            Try
                txt_cer_exp_date.Text = CDate(dao.fields.EXP_DOCUMENT_DATE).ToShortDateString()
            Catch ex As Exception

            End Try

            txt_Cernumber.Text = dao.fields.CERTIFICATION_NUMBER_ALL
            txt_Year_extend.Text = dao.fields.YEAR_EXTEND

        End If
    End Sub
    Public Sub Bind_ddl_Status_staff()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        bao.SP_MAS_STATUS_STAFF_CER()
        dt = bao.dt

        ddl_cnsdcd.DataSource = dt
        ddl_cnsdcd.DataValueField = "STATUS_ID"
        ddl_cnsdcd.DataTextField = "STATUS_NAME"
        ddl_cnsdcd.DataBind()
    End Sub
    Function load_STATUS()
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
        dao.GetDataby_IDA(_IDA)
        Return dao.fields.STATUS_ID.ToString()
    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
        dao.GetDataby_IDA(_IDA)
        If dao.fields.STATUS_ID <> 1 Then

            btn_confirm.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        If ddl_cnsdcd.SelectedValue = 8 Then
            Dim dao As New DAO_DRUG.TB_CER_EXTEND
            Dim bao As New BAO.ClsDBSqlcommand
            dao.GetDataby_IDA(Integer.Parse(_IDA))
            dao.fields.STATUS_ID = Integer.Parse(ddl_cnsdcd.SelectedValue())
            Try
                dao.fields.RCVDATE = CDate(txt_app_date.Text)
            Catch ex As Exception

            End Try

            dao.update()

            If ddl_cnsdcd.SelectedValue = 8 Then
                Dim dao_det As New DAO_DRUG.TB_CER_EXTEND_DETAIL
                dao_det.GetDataby_FK_HEAD(_IDA)
                For Each dao_det.fields In dao_det.datas
                    update_exp(dao_det.fields.OLD_IDA, _IDA)
                Next
            End If
            alert("บันทึกเรียบร้อยแล้ว")
        ElseIf ddl_cnsdcd.SelectedValue = 7 Then
            Response.Redirect("FRM_STAFF_CER_EXP_REMARK.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
        End If
    End Sub
    Sub update_exp(ByVal ida_cer As Integer, ByVal ida_ext As Integer)
        Dim dao_ex As New DAO_DRUG.TB_CER_EXTEND
        dao_ex.GetDataby_IDA(ida_ext)

        Dim dao As New DAO_DRUG.TB_CER
        Try
            dao.GetDataby_IDA2(ida_cer)
            dao.fields.EXP_DOCUMENT_DATE = dao_ex.fields.EXP_DOCUMENT_DATE
            dao.fields.DOCUMENT_DATE = dao_ex.fields.DOCUMENT_DATE
            dao.update()
        Catch ex As Exception

        End Try
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Sub RadGrid2_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim dao As New DAO_DRUG.TB_CER_EXTEND_DETAIL
            dao.GetDataby_IDA(item("IDA").Text)
            If e.CommandName = "del" Then
                dao.fields.IS_ACTIVE = 0
                dao.update()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อย');", True)
            End If
            RadGrid2.Rebind()
        End If
    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Try
            dt = bao.SP_CUSTOMER_EXTEND_DETAIL_CER_BY_FK_HEAD(Request.QueryString("ida"))
        Catch ex As Exception

        End Try


        'Try
        '    dt = bao.dt
        'Catch ex As Exception

        'End Try

        RadGrid2.DataSource = dt
    End Sub
End Class