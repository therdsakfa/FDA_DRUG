Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_SEARCH_LCN
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
            If _process = "130099" Then
                lbl_search.Text = "เลขทะเบียน"

            Else
                load_ddl()
                'load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
                load_HL()
            End If

        End If
        'UC_INFMT1.Shows(_lct_ida)
    End Sub

    Private Sub load_ddl()
        'Dim ws As New WS_PVNCD.WebService1


        'Dim dt As New DataTable
        'dt = ws.getNewcode_Lcnno_by_identify_and_taxnoauthorize(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE)

        'Dim dao As New DAO_DRUG.ClsDBdalcn

        'dao.GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        If Request.QueryString("process") = "130001" Or Request.QueryString("process") = "130002" Or Request.QueryString("process") = "130003" Or Request.QueryString("process") = "130004" Then
            If Request.QueryString("process") = "130001" Or Request.QueryString("process") = "130002" Then
                dt = bao.SP_DDL_LCN_DI_by_type(_CLS.CITIZEN_ID_AUTHORIZE, 1)
            Else
                dt = bao.SP_DDL_LCN_DI_by_type(_CLS.CITIZEN_ID_AUTHORIZE, 2)
            End If
        Else
            dt = bao.SP_DDL_LCN_DI(_CLS.CITIZEN_ID_AUTHORIZE)
        End If

        rcb_search.DataSource = dt 'dao.datas
        rcb_search.DataTextField = "LCNNO_MANUAL"
        rcb_search.DataValueField = "IDA"
        rcb_search.DataBind()
        Dim item As New RadComboBoxItem
        item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        item.Value = "0"
        rcb_search.Items.Insert(0, item)
    End Sub
    Private Sub load_HL()
        hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & 0
    End Sub
    Private Sub load_lbl_name()

        Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu.GetDataby_Process2(_process)

        Dim dao_menu2 As New DAO_DRUG.ClsDBMAS_MENU
        dao_menu2.GetDataby_Process2(_process_for)
        If String.IsNullOrEmpty(_process_for) = False Then
            lbl_name_2.Text = " (" & dao_menu2.fields.NAME & ") > "
        End If

        lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง

    End Sub

    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub
    Sub load_GV_lcnno()                             ' Gridview นำมาโชว์
        Dim process As String = "" '_process"
        Try
            Dim dao_p As New DAO_DRUG.ClsDBdalcn
            dao_p.GetDataby_IDA(rcb_search.SelectedValue)
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tr.GetDataby_IDA(dao_p.fields.TR_ID)
            process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try

        Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU       'ประกาศชื่อตัวแปร DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_Process(process)             'ดึง dao.GetDataby_Process เพื่อมาโชว์ที่ Gridview ที่เป็นค่า String

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(rcb_search.SelectedValue)
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(dao_lcn.fields.PROCESS_ID)
        bao.SP_CUSTOMER_LCN_BY_IDA(CDec(rcb_search.SelectedValue))
        GV_lcnno.DataSource = bao.dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
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
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(str_ID)
        If e.CommandName = "sel" Then

            Try
                Dim dao_p As New DAO_DRUG.ClsDBdalcn
                dao_p.GetDataby_IDA(rcb_search.SelectedValue)
                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tr.GetDataby_IDA(dao_p.fields.TR_ID)
                Dim url As String = ""
                If _process > 30 And _process <= 36 Then
                    url = "../DI/FRM_DI_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                ElseIf _process >= 14 And _process <= 18 Then
                    url = "../DH/FRM_DH_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                    'FRM_SEARCH_LCN

                    'ElseIf _process = "130001" Or _process = "130002" Then
                    '    url = "../REGISTRATION/FEM_REGISTRATION_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                ElseIf _process = "1200001" Or _process = "1200002" Or _process = "1200003" Or _process = "1200004" Or _process = "1200005" Or _process = "1200006" Or _process = "1200007" _
                Or _process = "1200008" Or _process = "1200009" Or _process = "1200010" Or _process = "1200101" Or _process = "1200012" Or _process = "1200013" Or _process = "1200014" Or _process = "1200015" _
                Or _process = "1200016" Or _process = "1200017" Or _process = "1200018" Then
                    url = "../REGISTRATION/FEM_REGISTRATION_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process") & "&r_process=130001"
                ElseIf _process = "130001" Or _process = "130002" Or _process = "130003" Or _process = "130004" Then
                    url = "../REGISTRATION/FEM_REGISTRATION_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process") & "&r_process=" & _process
                    If Request.QueryString("tt") <> "" Then
                        url &= "&tt=" & Request.QueryString("tt")
                    End If
                    If Request.QueryString("st") <> "" Then
                        url &= "&st=" & Request.QueryString("st")
                    End If
                ElseIf _process >= 20 And _process <= 23 Then
                    url = "../CHEMICAL/FRM_CHEMICAL_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process") & "&mt=" & Request.QueryString("mt") & "&st=" & Request.QueryString("st")
                ElseIf _process = 12 Then
                    url = "../DRUG_PROJECT/FRM_DRUG_PROJECT_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                ElseIf _process >= 1026 And _process <= 1030 Then
                    url = "../DRUG_IMPORT/DRUG_NORYORMOR.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                ElseIf _process = 8 Then
                    url = "../DP/FRM_DP_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                ElseIf _process = 40 Then
                    url = "../DRUG_PRODUCT_ID/FRM_DRUG_PRODUCT_ID_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                ElseIf _process = "1001022" Then
                    url = "../CER_EXTEND/FRM_CER_EXTEXND_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process")
                ElseIf _process = "10061" Then
                    url = "../CER_FOREIGN/CER_FOREIGN_MAIN.aspx?lct_ida=" & dao.fields.FK_IDA & "&lcn_ida=" & str_ID & "&process=" & Request.QueryString("process")
                    'ElseIf _process = "1026" Then
                    '    url = "../DRUG_IMPORT/DRUG_NORYORMOR.aspx?process=" & Request.QueryString("process") & "&lcn_ida=" & str_ID
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
            alert("กรุณาเลือกเลขที่ใบอนุญาต")
        End If


    End Sub
End Class