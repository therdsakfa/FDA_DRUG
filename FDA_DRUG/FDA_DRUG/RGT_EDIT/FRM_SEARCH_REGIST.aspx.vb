Imports Telerik.Web.UI
Public Class FRM_SEARCH_REGIST
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String = ""                'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _process_for As String

    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()

        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            '_lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2
            load_ddl()
            load_HL()
        End If
    End Sub

    Private Sub load_ddl()
        'Dim ws As New WS_PVNCD.WebService1


        'Dim dt As New DataTable
        'dt = ws.getNewcode_Lcnno_by_identify_and_taxnoauthorize(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE)

        'Dim dao As New DAO_DRUG.ClsDBdalcn

        'dao.GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
        Dim _type As Integer = 0
        If Request.QueryString("process") = "130003" Or Request.QueryString("process") = "130004" Then
            _type = 2
        Else
            _type = 1
        End If
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_DRRGT_FOR_SEARCH_NEW_ByY_TYPE(_CLS.CITIZEN_ID_AUTHORIZE, _type)
        dt = bao.SP_DRRGT_FOR_SEARCH_NEW(_CLS.CITIZEN_ID_AUTHORIZE)
        rcb_search.DataSource = dt 'dao.datas
        rcb_search.DataTextField = "rgtno_display"
        rcb_search.DataValueField = "IDA"
        rcb_search.DataBind()
        Dim item As New RadComboBoxItem
        item.Text = "กรุณาเลือกเลขทะเบียน"
        item.Value = "0"
        rcb_search.Items.Insert(0, item)

    End Sub
    Private Sub load_HL()
        hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & 0
    End Sub

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        dt = bao.SP_DRRGT_FOR_SEARCH_BY_IDA(rcb_search.SelectedValue)
        GV_lcnno.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                         'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    End Sub


#Region "GRIDVIEW"

    Protected Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then


            'Dim btn_leaves As Button = DirectCast(e.Row.FindControl("btn_leaves"), Button)
            Dim id As String = GV_lcnno.DataKeys.Item(e.Row.RowIndex).Value.ToString()

            'btn_leaves.Style.Add("display", "block")

            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(id)



        End If

    End Sub

    Protected Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        dao.GetDataby_IDA(str_ID)
        If e.CommandName = "sel" Then

            Try

                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(rcb_search.SelectedValue)
                Dim dao_da As New DAO_DRUG.ClsDBdalcn
                dao_da.GetDataby_IDA(dao_rg.fields.FK_LCN_IDA)
                'Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                'dao_tr.GetDataby_IDA(dao_p.fields.TR_ID)
                Dim url As String = ""
                If _process = "130099" Then
                    url = "../RGT_EDIT/FRM_RGT_EDIT_MAIN.aspx?rgt_ida=" & str_ID & "&lcn_ida=" & dao_rg.fields.FK_LCN_IDA & "&lct_ida=" & dao_da.fields.FK_IDA & "&process=" & Request.QueryString("process")

                ElseIf _process = "130098" Then
                    url = "../SUBSTITUTE_TABEAN/FRM_SUBSTITUTE_MAIN.aspx?rgt_ida=" & str_ID & "&lcn_ida=" & dao_rg.fields.FK_LCN_IDA & "&lct_ida=" & dao_da.fields.FK_IDA & "&process=" & Request.QueryString("process")
                End If
                If Request.QueryString("staff") <> "" Then
                    url &= "&staff=1&identify=" & Request.QueryString("identify")
                End If
                Response.Redirect(url)
            Catch ex As Exception

            End Try
        ElseIf e.CommandName = "leaves" Then
            'dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
            Response.Redirect("FRM_LCN_NCT.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida & "&process=" & Request.QueryString("process"))
            'Response.Redirect("../EDIT_LOCATION/FRM_EDIT_LOCATION_MAIN.aspx?lcnno=" & dao.fields.lcnno.ToString() & "&lcnsid=" & dao.fields.lcnsid.ToString() & "&lcn_ida=" & str_ID & "&lct_ida=" & _lct_ida & "&process=" & process & "&process2=" & process2)

        ElseIf e.CommandName = "lcn" Then

        End If
    End Sub


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        load_GV_lcnno()
    End Sub
#End Region

    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        load_GV_lcnno()                             'เรียกฟังก์ชั่น  load_GV_lcnno   มาใช้งาน
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub
    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If rcb_search.SelectedIndex <> 0 Then
            load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
        Else
            alert("กรุณาเลือกทะเบียน")
        End If


    End Sub
End Class