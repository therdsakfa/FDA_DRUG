Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_DRUG_IMPORT_MAIN
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _type As String
    Private _process As String = ""
    Private _DL As String = ""

    Sub RunSession()

        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _DL = Request.QueryString("DL")
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

    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        'Dim DL As String
        'DL = rcb_search.SelectedValue
        'If rcb_search.SelectedValue <> "0" Then
        Dim url As String = ""
        Dim NYM As String = ""
        If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
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
            url = "http://164.115.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & _DL & "&NYM=" & NYM
            Response.Redirect(url)
        End If
        'End If
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand    'กดปุ่มใน grid ให้ทำอะไร จากหหน้
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'drsamp IDA
            Dim IDA As Integer = 0
            Try
                IDA = item("IDA").Text
            Catch ex As Exception

            End Try

            Dim PROCESS_ID As Integer = 0
            Try
                PROCESS_ID = item("PROCESS_ID").Text
            Catch ex As Exception

            End Try

            If e.CommandName = "sel" Then
                Dim dao As New DAO_DRUG.ClsDBdrsamp
                dao.GetDataby_IDA(IDA)
                Dim tr_id As Integer = 0
                Try
                    tr_id = dao.fields.TR_ID
                Catch ex As Exception

                End Try


                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "POPUP_NYM_SUBMIT_REQUEST.aspx?IDA=" & IDA & "&TR_ID=" & tr_id & "&process=" & PROCESS_ID & "');", True)
            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound   'ในแต่ละแถวให้ทำอะไร ซ่อนปุ่ม โชว์ปุ่ม ปิดปุ่ม
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(IDA)
            btn_edit.Style.Add("display", "none")
            Try
                If dao.fields.STATUS_ID = 6 Then
                    btn_edit.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            'Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            'btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
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

        dt = bao.SP_DATA_NYM2_USER()
        '  Dim IDGroup As Integer = 0   เอาคืนนน
        ' Try                           เอาคืนนน
        'IDGroup = _CLS.GROUPS          เอาคืนนน
        'If _process = "" Then          เอาคืนนน
        '
        'End If                         เอาคืนนน
        'Catch ex As Exception          เอาคืนนน

        'End Try                        
        'If IDGroup = 21020 Then
        '    If _type = "" Then
        '        RadGrid1.DataSource = dt.Select("PROCESS_ID = " & _process)
        '    Else
        '        RadGrid1.DataSource = dt.Select("PROCESS_ID = " & _process & " and donate_type = " & _type)
        '    End If
        'ElseIf IDGroup = 63346 Then
        '    If _type = "" Then
        '        RadGrid1.DataSource = dt.Select("STATUS_ID = 2 and PROCESS_ID = " & _process)
        '    Else
        '        RadGrid1.DataSource = dt.Select("STATUS_ID = 2 and PROCESS_ID = " & _process & " and donate_type = " & _type)
        '    End If
        'ElseIf IDGroup = 63347 Then
        '    If _type = "" Then
        '        RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6 and PROCESS_ID = " & _process)
        '    Else
        '        RadGrid1.DataSource = dt.Select("STATUS_ID >= 2 and STATUS_ID <= 6 and PROCESS_ID = " & _process & " and donate_type = " & _type)
        '    End If
        'ElseIf IDGroup = 63348 Then
        '    If _type = "" Then
        '        RadGrid1.DataSource = dt.Select("STATUS_ID > 6  and PROCESS_ID = " & _process)
        '    Else
        '        RadGrid1.DataSource = dt.Select("STATUS_ID > 6  and PROCESS_ID = " & _process & " and donate_type = " & _type)
        '    End If
        'End If
    End Sub

End Class