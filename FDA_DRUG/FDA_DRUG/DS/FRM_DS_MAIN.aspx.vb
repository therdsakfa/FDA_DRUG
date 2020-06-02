Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf

Public Class FRM_DS_MAIN
    Inherits System.Web.UI.Page
    'Private _process As String
    'Private _lcn_ida As String
    'Private str_ID As String
    'Private tr_id As String
    'Private _process_for As String

    'Sub Runparameter()
    '    Try
    '        _process = Request("process").ToString()
    '        _lcn_ida = Request("lcn_ida").ToString()
    '        'str_ID = Request("str_ID").ToString()
    '        ' _IDA = Request("IDA").ToString()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '    Runparameter()
        '    If Not IsPostBack Then

        '        GV_lcnno_DataBinding()
        '        set_lbl_header()
        '    End If
    End Sub

    'Private Sub load_lbl_name()

    '    Dim dao_menu As New DAO_DRUG.ClsDBMAS_MENU
    '    dao_menu.GetDataby_Process2(_process)

    '    Dim dao_menu2 As New DAO_DRUG.ClsDBMAS_MENU
    '    dao_menu2.GetDataby_Process2(_process_for)
    '    If String.IsNullOrEmpty(_process_for) = False Then
    '        lbl_name_2.Text = " (" & dao_menu2.fields.NAME & ") > "
    '    End If

    '    lbl_name.Text = " (" & dao_menu.fields.NAME & ")" 'ดึงชื่อเมนูมาแสดง

    'End Sub

    'Sub set_lbl_header()
    '    lbl_name_2.Text = "คำขออนุญาต"
    '    If _process = "1701" Then
    '        lbl_name.Text = "ผลิตยาตัวอย่างเพื่อขอขึ้นทะเบียนตำรับยา (ผย8)"
    '    ElseIf _process = "1702" Then
    '        lbl_name.Text = "นำหรือสั่งยาตัวอย่างเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียนตำรับยา (นย8)"
    '    ElseIf _process = "1703" Then
    '        lbl_name.Text = "ผลิตยาเพื่อขอขึ้นทะเบียนตำรับ ผย8(ผยบ)"
    '    ElseIf _process = "1704" Then
    '        lbl_name.Text = "นำหรือสั่งยาเพื่อขอขึ้นทะเบียนตำรับ นย8(นยบ)"
    '    ElseIf _process = "1705" Then
    '        lbl_name.Text = " ยาวิจัย (ผย8)"
    '    End If

    'End Sub
    'Private Sub GV_lcnno_DataBinding()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt = bao.SP_GET_TR_UPLOAD_BY_PROCESS_ID(_process)

    '    '    RadGrid1.DataSource = dt
    '    GV_lcnno.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
    '    GV_lcnno.DataBind()                       'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง
    'End Sub

    'Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
    '    GV_lcnno.PageIndex = e.NewPageIndex
    '    GV_lcnno_DataBinding()
    'End Sub

    'Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
    '    If _process = "1701" Then
    '        Response.Redirect("FRM_DS_PORYOR8.aspx?lcn_ida=" & _lcn_ida)
    '    ElseIf _process = "1702" Then
    '        Response.Redirect("FRM_DS_NORYOR8.aspx?lcn_ida=" & _lcn_ida)
    '    ElseIf _process = "1703" Then
    '        Response.Redirect("FRM_DS_PORYOR8(PORYORBOR).aspx?lcn_ida=" & _lcn_ida)
    '    ElseIf _process = "1704" Then
    '        Response.Redirect("FRM_DS_NORYOR8(NORYORBOR).aspx?lcn_ida=" & _lcn_ida)
    '    ElseIf _process = "1705" Then
    '        Response.Redirect("FRM_DS_PORYOR8(YAVEJAI).aspx?lcn_ida=" & _lcn_ida)
    '    End If

    '    ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx?process=" & _process & "&lct_ida=" & Request.QueryString("lct_ida") & "&lcn_ida=" & Request.QueryString("lcn_ida") & "');", True)
    'End Sub

    'Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
    '    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('DS\POPUP_DS_UPLOAD.aspx');", True)
    '    Response.Redirect("~\DS\POPUP_DS_UPLOAD2.aspx?process=" & _process & "&lcn_ida=" & _lcn_ida & "")
    '    'Response.Redirect("~\DS\POPUP_DS_UPLOAD2.aspx?lcn_ida=" & _lcn_ida & "")
    'End Sub

    'Private Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand
    '    Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
    '    Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()
    '    Dim dao As New DAO_DRUG.ClsDBdrsamp

    '    If e.CommandName = "sel" Then
    '        dao.GetDataby_IDA(str_ID)
    '        Dim tr_id As Integer = 0
    '        Try
    '            tr_id = dao.fields.TR_ID
    '        Catch ex As Exception

    '        End Try

    '        Response.Redirect("~\DS\POPUP_DS_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "")

    '        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups('" & "../POPUP_DS_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "');", True)

    '    End If
    'End Sub
End Class