Imports Telerik.Web.UI

Public Class FRM_CHANGE_NAME_POPUP
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION

    Private _ProcessID As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _ProcessID = Request.QueryString("process")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("https://privus.fda.moph.go.th")
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()

        If Not IsPostBack Then
            Dim dt As New DataTable
            Dim bao As New BAO_SHOW
            Try

                dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(Request.QueryString("identify"), 0)
                For Each dr As DataRow In dt.Rows
                    lbl_oldname.Text = dr("thanm")
                Next
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.GET_LIST_LCN_BY_IDENTIFY(Request.QueryString("identify"))
        RadGrid1.DataSource = dt

    End Sub

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        '
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.GET_LIST_DR_BY_IDENTIFY(Request.QueryString("identify"))
        RadGrid1.DataSource = dt
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        dt = bao.GET_LIST_LCN_BY_IDENTIFY(Request.QueryString("identify"))
        dt2 = bao.GET_LIST_DR_BY_IDENTIFY(Request.QueryString("identify"))
        Dim count_lcn As Integer = 0
        Dim count_dr As Integer = 0
        count_lcn = dt.Rows.Count
        count_dr = dt2.Rows.Count
        Dim amount1 As Double = 0
        Dim amount2 As Double = 0
        amount1 = count_lcn * 100
        amount2 = count_dr * 300

        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

        TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION


        Dim dao As New DAO_DRUG.TB_CHANGE_NAME_REQUEST
        dao.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        dao.fields.AMOUNT_SUM = amount1 + amount2
        dao.fields.COUNT_ALL_ITEM = count_lcn + count_dr
        dao.fields.CREATE_DATE = Date.Now
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.OLD_NAME = lbl_oldname.Text
        dao.fields.PROCESS_ID = "300100"
        dao.fields.REQUEST_DATE = Date.Now
        dao.fields.STATUS_ID = 2
        dao.fields.TR_ID = TR_ID
        dao.insert()

        For Each dr As DataRow In dt.Rows
            Dim dao_det As New DAO_DRUG.TB_CHANGE_NAME_REQUEST_DETAIL
            With dao_det.fields
                .AMOUNT = 100
                .FK_IDA = dao.fields.IDA
                .IDA_PRODUCT = dr("IDA")
                .NEWCODE = dr("Newcode_not")
                .PRODUCT_NO_FULL = dr("lcnno_no")
                .PRODUCT_TYPE = 1
            End With
            dao_det.insert()
        Next

        For Each dr As DataRow In dt2.Rows
            Dim dao_det As New DAO_DRUG.TB_CHANGE_NAME_REQUEST_DETAIL
            With dao_det.fields
                .AMOUNT = 300
                .FK_IDA = dao.fields.IDA
                .IDA_PRODUCT = dr("IDA_drrgt")
                .NEWCODE = dr("Newcode_U")
                .PRODUCT_NO_FULL = dr("register")
                .PRODUCT_TYPE = 2
            End With
            dao_det.insert()
        Next
        alert("ยื่นคำขอเรียบร้อย")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub
End Class