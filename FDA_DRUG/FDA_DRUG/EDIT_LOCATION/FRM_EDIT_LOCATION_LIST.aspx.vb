Public Class FRM_EDIT_LOCATION_LIST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Sub RunSession()
        _lct_ida = Request.QueryString("lct_ida")
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2
            load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
        End If
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        bao.SP_CUSTOMER_LCN_BY_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
        GV_lcnno.DataSource = bao.dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        If e.CommandName = "edt" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Response.Redirect("FRM_EDIT_LOCATION_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida)
            'ElseIf e.CommandName = "lcn" Then
            '    'Dim dao As New DAO_DRUG.ClsDBdalcn
            '    dao.GetDataby_IDA(Integer.Parse(str_ID))
            '    _CLS.LCNNO = dao.fields.lcnno.ToString()
            '    _CLS.LCNSID_CUSTOMER = dao.fields.lcnsid.ToString()
            '    _CLS.PVCODE = dao.fields.pvncd.ToString()
            '    _CLS.IDA = str_ID
            '    Session("CLS") = _CLS

            '    ' Response.Redirect("../MAIN/FRM_NODE.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString())
            '    Response.Redirect("../MAIN/FRM_NEWS.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida)

        End If
    End Sub


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub
End Class