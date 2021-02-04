Imports Telerik.Web.UI
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.DAO_DRUG
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf


Public Class UC_DS_MAIN
    Inherits System.Web.UI.UserControl
    Private _process As String
    Private _lcn_ida As String
    Private _main_ida As String
    Private str_ID As String
    Private tr_id As String
    Private _process_for As String
    Private _staff As String
    Private _CLS As New CLS_SESSION 'ประกาศชื่อตัวแปรของ   CLS_SESSION

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

    Sub Runparameter()
        Try
            _lcn_ida = Request("lcn_ida").ToString()
            If _lcn_ida <> "" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(_lcn_ida)
                'If dao.fields.lcntpcd.Contains("ผย") Then
                '    _process = "1701"
                'ElseIf dao.fields.lcntpcd.Contains("นย") Then
                '    _process = "1702"
                'ElseIf dao.fields.lcntpcd.Contains("ยบ") Then
                '    _process = "1703"
                'End If
                '_process = Request("process").ToString()

                If dao.fields.lcntpcd.Contains("ผย") Then
                    _process = "1701"
                    If dao.fields.lcntpcd.Contains("ผยบ") Then
                        _process = "1703"

                        If Request.QueryString("tt") <> "" Then
                            _process = "1706"
                        End If
                    End If

                ElseIf dao.fields.lcntpcd.Contains("นย") Then
                    _process = "1702"
                    If dao.fields.lcntpcd.Contains("นยบ") Then
                        _process = "1704"

                        If Request.QueryString("tt") <> "" Then
                            _process = "1707"
                        End If
                    End If
                End If
            End If


            'str_ID = Request("str_ID").ToString()
            ' _IDA = Request("IDA").ToString()
        Catch ex As Exception

        End Try
        Try
            _staff = Request("staff").ToString()
        Catch ex As Exception
        End Try
        Try
            _main_ida = Request("main_ida").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RunSession()
        Runparameter()
        If Not IsPostBack Then
            GV_lcnno_DataBinding()
            set_lbl_header()
            load_HL()
            If Request.QueryString("tt") <> "" Then
                btn_download.Text = "เพิ่มคำขอ ยบ.8"
                hl_pay.Visible = False

            End If
        End If
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

        If Request.QueryString("tt") <> "" Then

        End If
    End Sub

    Private Sub load_HL()
        Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
        dao_p.GetDataby_Process_ID(_process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ชำระเงินยาตัวอย่าง", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ชำระเงินยาตัวอย่าง", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ชำระเงินยาตัวอย่าง", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
        Try
            '    If dao_p.fields.PROCESS_DESCRIPTION.Contains("DEMO") Then
            '        hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE_DEMO/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
            '        If Request.QueryString("staff") = 1 Then
            '            hl_pay.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            '        End If
            '    Else
            hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug"
            If Request.QueryString("staff") = 1 Then
                hl_pay.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            End If
            'End If
        Catch ex As Exception

        End Try


    End Sub

    Sub set_lbl_header()
        lbl_name_2.Text = "คำขออนุญาต"
        If _process = "1701" Then
            lbl_name.Text = "ผลิตยาตัวอย่างเพื่อขอขึ้นทะเบียนตำรับยา (ผย8)"
        ElseIf _process = "1702" Then
            lbl_name.Text = "นำหรือสั่งยาตัวอย่างเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียนตำรับยา (นย8)"
        ElseIf _process = "1703" Then
            lbl_name.Text = "ผลิตยาเพื่อขอขึ้นทะเบียนตำรับ ยบ8(ผยบ)"
        ElseIf _process = "1704" Then
            lbl_name.Text = "นำหรือสั่งยาเพื่อขอขึ้นทะเบียนตำรับ ยบ8(นยบ)"
        ElseIf _process = "1705" Then
            lbl_name.Text = " ยาวิจัย (ผย8)"
        ElseIf _process = "1706" Then
            lbl_name.Text = "การขอผลิต/นำเข้า ผลิตภัณฑ์สมุนไพรตัวอย่าง" '"ผลิตยาเพื่อขอขึ้นทะเบียนตำรับ ยบ8(ผยบ)"
        ElseIf _process = "1707" Then
            lbl_name.Text = "การขอผลิต/นำเข้า ผลิตภัณฑ์สมุนไพรตัวอย่าง"
        End If

    End Sub
    Public Sub GV_lcnno_DataBinding()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt = bao.SP_GET_TR_UPLOAD_BY_PROCESS_ID_AND_IDA(_process, _CLS.CITIZEN_ID_AUTHORIZE, _main_ida)

        '    RadGrid1.DataSource = dt
        GV_lcnno.DataSource = dt                'นำข้อมูลมโชในจาก SP มาไว้ที่ DataTable 
        GV_lcnno.DataBind()                       'นำข้อมูลมโชใน Gridview ชื่อ Gridview ว่า GV_lcnno   เพื่อให้ข้อมูลวิ่ง

        ''GV_lcnno.fin = Visible
    End Sub


    Protected Sub GV_lcnno_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_lcnno.PageIndexChanging
        GV_lcnno.PageIndex = e.NewPageIndex
        GV_lcnno_DataBinding()
    End Sub

    Protected Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        Dim url As String = ""

        Dim dao As New ClsDBDALCN_PHR
        dao.GetDataby_FK_IDA(_lcn_ida)

        If Request.QueryString("staff") <> 1 Then

            For Each dao.fields In dao.datas

                If dao.fields.PHR_CTZNO = _CLS.CITIZEN_ID Then
                    If _process = "1701" Then
                        url = "../DS/FRM_DS_PORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process
                    ElseIf _process = "1702" Then
                        url = "../DS/FRM_DS_NORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process
                    ElseIf _process = "1703" Then
                        url = "../DS/FRM_DS_PORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process
                    ElseIf _process = "1704" Then
                        url = "../DS/FRM_DS_NORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process
                    ElseIf _process = "1705" Then
                        url = "../DS/FRM_DS_PORYOR8(YAVEJAI).aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process
                    ElseIf _process = "1706" Then
                        url = "../DS/FRM_DS_PORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&tt=" & Request.QueryString("tt") & "&process_id=" & _process
                    ElseIf _process = "1707" Then
                        url = "../DS/FRM_DS_NORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&tt=" & Request.QueryString("tt") & "&process_id=" & _process
                    End If
                End If

            Next
        Else
            If _process = "1701" Then
                url = "../DS/FRM_DS_PORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process & "&staff=" & Request.QueryString("staff")
            ElseIf _process = "1702" Then
                url = "../DS/FRM_DS_NORYOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process & "&staff=" & Request.QueryString("staff")
            ElseIf _process = "1703" Then
                url = "../DS/FRM_DS_PORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process & "&staff=" & Request.QueryString("staff")
            ElseIf _process = "1704" Then
                url = "../DS/FRM_DS_NORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process & "&staff=" & Request.QueryString("staff")
            ElseIf _process = "1705" Then
                url = "../DS/FRM_DS_PORYOR8(YAVEJAI).aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&process_id=" & _process & "&staff=" & Request.QueryString("staff")
            ElseIf _process = "1706" Then
                url = "../DS/FRM_DS_PORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&tt=" & Request.QueryString("tt") & "&process_id=" & _process & "&staff=" & Request.QueryString("staff")
            ElseIf _process = "1707" Then
                url = "../DS/FRM_DS_NORYORBOR8.aspx?lcn_ida=" & _lcn_ida & "&main_ida=" & _main_ida & "&tt=" & Request.QueryString("tt") & "&process_id=" & _process & "&staff=" & Request.QueryString("staff")
            End If
        End If

        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มคำขอยาตัวอย่าง", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มคำขอยาตัวอย่าง", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มคำขอยาตัวอย่าง", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "เพิ่มคำขอยาตัวอย่าง", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                    'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://10.111.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=';", True)
                End Try
            End Try
        End Try


        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../DS/POPUP_DS_UPLOAD2.aspx?process=" & _process & "&lcn_ida=" & _lcn_ida & "&staff=" & _staff & "&tt=" & Request.QueryString("tt") & "&main_ida=" & _main_ida & "');", True)
        'Dim url As String = ""
        'url = "http://10.111.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN="
        ''url = "https://privus.fda.moph.go.th"
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
        'Response.Redirect("~\DS\POPUP_DS_UPLOAD2.aspx?process=" & _process & "&lcn_ida=" & _lcn_ida & "")
        'Response.Redirect("~\DS\POPUP_DS_UPLOAD2.aspx?lcn_ida=" & _lcn_ida & "")
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอยาตัวอย่าง", _process)
        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอยาตัวอย่าง", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอยาตัวอย่าง", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอยาตัวอย่าง", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try
    End Sub

    Private Sub GV_lcnno_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_lcnno.RowCommand

        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_lcnno.DataKeys.Item(int_index)("IDA").ToString()


        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(str_ID)

        If e.CommandName = "sel" Then
            Dim tr_id As String = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try
        ElseIf e.CommandName = "choose" Then

        End If


        'Response.Redirect("~\DS\POPUP_DS_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "")
        'Dim ws As New AUTHEN_LOG.Authentication
        'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", dao.fields.TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลยาตัวอย่าง", _process)

        Dim ws_118 As New WS_AUTHENTICATION.Authentication
        Dim ws_66 As New Authentication_66.Authentication
        Dim ws_104 As New AUTHENTICATION_104.Authentication
        Try
            ws_118.Timeout = 10000
            ws_118.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลยาตัวอย่าง", _process)
        Catch ex As Exception
            Try
                ws_66.Timeout = 10000
                ws_66.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลยาตัวอย่าง", _process)

            Catch ex2 As Exception
                Try
                    ws_104.Timeout = 10000
                    ws_104.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", 0, HttpContext.Current.Request.Url.AbsoluteUri, "ดูข้อมูลยาตัวอย่าง", _process)

                Catch ex3 As Exception
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('เกิดข้อผิดพลาดการเชื่อมต่อ');window.location.href = 'http://privus.fda.moph.go.th';", True)
                End Try
            End Try
        End Try

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../DS/POPUP_DS_CONFIRM.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "&process=" & _process & "&lcn_ida=" & _lcn_ida & "');", True)

    End Sub

    Private Sub GV_lcnno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_lcnno.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_select As Button = DirectCast(e.Row.FindControl("btn_Select"), Button)
            Dim btn_Edit As Button = DirectCast(e.Row.FindControl("btn_Edit"), Button)
            'Dim ida As String = GV_lcnno.DataKeys.Item(e.Row.RowIndex).Value.ToString()
            Try
                Dim dao As New DAO_DRUG.ClsDBdrsamp
                dao.GetDataby_PRODUCT_ID_IDA(_main_ida)
                If dao.fields.STATUS_ID >= 2 Then
                    btn_select.Style.Add("display", "none")
                End If
                If dao.fields.STATUS_ID <> 5 Then
                    btn_Edit.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub

End Class