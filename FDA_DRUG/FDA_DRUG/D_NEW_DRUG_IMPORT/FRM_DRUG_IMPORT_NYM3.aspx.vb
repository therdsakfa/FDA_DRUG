﻿Imports Telerik.Web.UI

Public Class FRM_DRUG_IMPORT_NYM3
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _type As String
    Private _process As String = ""
    Private _DL As String = ""
    Private _IDA As String = ""
    Private _TR_ID As String = ""

    Sub RunSession()

        Try
            _process = Request.QueryString("process")
        Catch ex As Exception

        End Try
        Try
            _DL = Request.QueryString("DL")
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            'เรียก Process ที่เราเรียก

            '_IDA = Request.QueryString("IDA")
            '_TR_ID = Request.QueryString("TR_ID")
            '_lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
        Try
            _type = Request("type").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_HL()
    End Sub
    Private Sub load_HL()
        Dim urls As String = "https://platba.fda.moph.go.th/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN
        If Request.QueryString("staff") <> "" Then
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=staffdrug"
        Else
            urls &= "&staff=1&identify=" & Request.QueryString("identify") & "&system=drug"
        End If

        hl_pay.NavigateUrl = urls


        'hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & _lct_ida
        'If Request.QueryString("staff") <> "" Then
        '    hl_pay.NavigateUrl &= "&staff=1&identify=" & Request.QueryString("identify")
        'End If
    End Sub
    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        ''Dim DL As String
        ''DL = rcb_search.SelectedValue
        ''If rcb_search.SelectedValue <> "0" Then
        'Dim url As String = ""
        'Dim NYM As String = ""
        'If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
        '    Select Case _process
        '        Case "1027"
        '            NYM = "2"
        '        Case "1028"
        '            NYM = "3"
        '        Case "1029"
        '            NYM = "4"
        '        Case "1030"
        '            NYM = "5"
        '    End Select
        '    url = "http://164.115.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & _DL & "&NYM=" & NYM & "&process=" & _process
        '    Response.Redirect(url)
        'End If
        ''End If
        Dim url As String = ""
        Dim NYM As String = ""
        'If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
        Select Case _process
            Case "1027"
                NYM = "2"
            Case "1028"
                NYM = "3"
            Case "1029"
                NYM = "4"
            Case "1030"
                NYM = "5"
        End Select
        'url = "http://164.115.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & _DL & "&NYM=" & 2 & "&process=" & "1027" ' & " & NYM2_ida" & _IDA
        'Response.Redirect(url)
        'End If
        url = "../D_NEW_DRUG_IMPORT/POPUP_NYM_REDIRECT2.aspx?TOKEN=" & _CLS.TOKEN & "&DL=" & _DL & "&NYM=" & 2 & "&process=" & "1028" & "&CHK_SAVE=1&IDA=0" ' & " & NYM2_ida" & _IDA
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)



    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand    'กดปุ่มใน grid ให้ทำอะไร จากหหน้
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim url As String = ""
            Dim NYM As String = "3"
            Dim NYM3_ida As String = item("NYM3_IDA").Text
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3


            If e.CommandName = "sel" Then
                'dao.GetDataby_IDA(NYM3_ida)
                'Dim tr_id As Integer = 0
                'Try
                '    tr_id = dao.fields.TR_ID
                'Catch ex As Exception
                'End Try
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../D_NEW_DRUG_IMPORT/POPUP_NYM_SUBMIT_REQUEST.aspx?IDA=" & NYM3_ida & "&Process=" & _process & "&DL=" & _DL & "&TR_ID=" & item("TR_ID").Text & "');", True)
            ElseIf e.CommandName = "_edit" Then
                dao.GetDataby_IDA_STATUS(NYM3_ida)
                'Dim DL As Integer = 0
                'Try
                '    DL = dao.fields.DL
                'Catch ex As Exception
                'End Try
                'url = "http://164.115.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & _DL & "&NYM=" & NYM & "&process=" & _process & "&IDA=" & NYM3_ida
                'Response.Redirect(url)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../D_NEW_DRUG_IMPORT/POPUP_NYM_EDIT_REQUEST.aspx?IDA=" & NYM3_ida & "&TR_ID=" & item("TR_ID").Text & "&Process=" & _process & "&DL=" & _DL & "');", True)
            ElseIf e.CommandName = "upload" Then
                'หา Code ที่ทำให้อัพโหลดขึ้นเซิฟ                   น่าจะต้องเอามาจาก LCN_UPLOAD
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../D_NEW_DRUG_IMPORT/POPUP_NYM_UPLOAD_PDF_PROOF.aspx?IDA=" & NYM3_ida & "&Process=" & _process & "&DL=" & _DL & "');", True)


            End If
        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound   'ในแต่ละแถวให้ทำอะไร ซ่อนปุ่ม โชว์ปุ่ม ปิดปุ่ม
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim DL As String = item("DL").Text
            Dim NYM3_ida As String = item("NYM3_IDA").Text
            Dim btn_upload As LinkButton = DirectCast(item("btn_upload").Controls(0), LinkButton)       'เพิ่มเอกสารเมื่อดำเนินการเสร็จ
            Dim btn_Select As LinkButton = DirectCast(item("btn_Select").Controls(0), LinkButton)
            Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
            dao.getdata_dl(DL)
            btn_upload.Style.Add("display", "none")
            btn_edit.Style.Add("display", "none")
            Try
                dao.GetDataby_IDA(NYM3_ida)
                If dao.fields.STATUS_ID = 5 Then
                    btn_edit.Style.Add("display", "block")
                ElseIf dao.fields.STATUS_ID = 8 Then                        'ถ้า อนุมัติแล้ว ให้โชว์ปปุ่มอัปโหลด เพื่ออัปโหลดเอกสารยืนยัน
                    btn_upload.Style.Add("display", "block")
                Else
                    btn_edit.Style.Add("display", "none")
                End If
            Catch ex As Exception
            End Try


            ' Try
            'If dao.fields.STATUS_ID = 6 Then
            'btn_upload.Style.Add("display", "block")
            'End If
            '   Catch ex As Exception
            '  End Try
            'DL = 96703&NYM=2&process=1027
            ' Dim url As String = "../D_NEW_DRUG_IMPORT/POPUP_NYM_SUBMIT_REQUEST.aspx?DL=" & _DL & "&NYM=" & NYM & "&process=" & _process & ""     'แก้ไขบรรทัดนี้
            ' Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            'btn_Select.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")                                                           'แก้ไขบรรทัดนี้
        End If
    End Sub

    Protected Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource  'หาข้อมูลมาใส่ 
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'SP_STAFF_DALCN_BY_PVNCD
        'If _pvncd = 10 Then
        '    dt = bao.SP_STAFF_DALCN()
        'Else
        '    dt = bao.SP_STAFF_DALCN_BY_PVNCD(_pvncd)
        'End If
        'If _process = 1027 Then
        '    dt = bao.SP_DATA_NYM2_USER()
        'ElseIf _process = 1028 Then
        '    dt = bao.SP_DATA_NYM3_USER()
        'ElseIf _process = 1029 Then
        '    dt = bao.SP_DATA_NYM4_USER()
        'ElseIf _process = 1030 Then
        '    dt = bao.SP_DATA_NYM5_USER()
        'ElseIf _process = 1031 Then
        '    dt = bao.SP_DATA_NYM6_USER()
        'End If
        dt = bao.SP_DATA_NYM3_USER(_DL)      '_DL          'BAO แถวที่ 5000
        RadGrid1.DataSource = dt

    End Sub
    Protected Sub btn_reload_Click(sender As Object, e As EventArgs) Handles btn_reload.Click
        RadGrid1.Rebind()
    End Sub

End Class