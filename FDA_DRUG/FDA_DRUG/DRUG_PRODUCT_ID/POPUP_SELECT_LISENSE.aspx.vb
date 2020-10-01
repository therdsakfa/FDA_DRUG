﻿Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Public Class POPUP_SELECT_LISENSE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
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
            'load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
            load_HL()
        End If
        'UC_INFMT1.Shows(_lct_ida)
    End Sub

    Private Sub load_ddl()
        Dim ws As New WS_PVNCD.WebService1


        Dim dt As New DataTable
        dt = ws.getNewcode_Lcnno_by_identify_and_taxnoauthorize(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE)

        Dim dao As New DAO_DRUG.ClsDBdalcn

        dao.GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)

        ddl_search.DataSource = dao.datas
        ddl_search.DataTextField = "LCNNO_MANUAL"
        ddl_search.DataValueField = "IDA"
        ddl_search.DataBind()
        Dim item As New ListItem
        item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        item.Value = "0"
        ddl_search.Items.Insert(0, item)
    End Sub
    Private Sub load_HL()
        hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
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
            dao_p.GetDataby_IDA(ddl_search.SelectedValue)
            Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
            dao_tr.GetDataby_IDA(dao_p.fields.TR_ID)
            process = dao_tr.fields.PROCESS_ID
        Catch ex As Exception

        End Try

        Dim bao As New BAO.ClsDBSqlcommand          'ประกาศชื่อตัวแปร BAO.ClsDBSqlcommand
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU       'ประกาศชื่อตัวแปร DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_Process(process)             'ดึง dao.GetDataby_Process เพื่อมาโชว์ที่ Gridview ที่เป็นค่า String

        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(ddl_search.SelectedValue)
        Dim dao_pro As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_pro.GetDataby_Process_ID(dao_lcn.fields.PROCESS_ID)
        bao.SP_CUSTOMER_LCN_BY_IDA(CDec(ddl_search.SelectedValue))
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
        Dim fk_ida As Integer = 0
        If e.CommandName = "sel" Then

            Try
                Dim dao_p As New DAO_DRUG.ClsDBdalcn
                dao_p.GetDataby_IDA(ddl_search.SelectedValue)
                Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_tr.GetDataby_IDA(dao_p.fields.TR_ID)
                'If _process > 30 And _process <= 36 Then
                '    Response.Redirect("../DI/FRM_DI_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process"))
                'ElseIf _process >= 14 And _process <= 18 Then
                '    Response.Redirect("../DH/FRM_DH_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process"))
                '    'FRM_SEARCH_LCN

                'ElseIf _process = 9 Or _process = 19 Then
                '    Response.Redirect("../REGISTRATION/FEM_REGISTRATION_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process"))
                'ElseIf _process >= 20 And _process <= 23 Then
                '    Response.Redirect("../CHEMICAL/FRM_CHEMICAL_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process") & "&mt=" & Request.QueryString("mt") & "&st=" & Request.QueryString("st"))
                'ElseIf _process = 12 Then
                '    Response.Redirect("../DRUG_PROJECT/FRM_DRUG_PROJECT_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process"))
                'ElseIf _process >= 27 And _process <= 30 Then
                '    Response.Redirect("../DRUG_CUSTOMER_NORYORMOR_2_to_5/FRM_NORYORMOR_2_to_5_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process"))
                'ElseIf _process = 8 Then
                '    Response.Redirect("../DP/FRM_DP_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process"))
                'ElseIf _process = 40 Then
                '    Response.Redirect("../DRUG_PRODUCT_ID/FRM_DRUG_PRODUCT_ID_MAIN.aspx?lcn_ida=" & str_ID & "&lct_ida=" & dao.fields.FK_IDA & "&process=" & Request.QueryString("process"))
                'End If
                Try
                    fk_ida = dao.fields.FK_IDA
                Catch ex As Exception

                End Try

                Response.Redirect("../DRUG_PRODUCT_ID/FRM_DRUG_PRODUCT_ID_MAIN2.aspx?lcn_ida=" & str_ID & "&lct_ida=" & fk_ida)
            Catch ex As Exception

            End Try
        ElseIf e.CommandName = "leaves" Then
            'dao.GetDataby_IDA(str_ID)
            Dim tr_id As String= 0
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
        If ddl_search.SelectedIndex <> 0 Then
            load_GV_lcnno()         'ให้รันฟังก์ชั่นลำดับที่ 3
        Else
            alert("กรุณาเลือกเลขที่ใบอนุญาต")
        End If


    End Sub
End Class