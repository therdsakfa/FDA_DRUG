Imports Telerik.Web.UI

Public Class FRM_STAFF_NYM2
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION         'public class
    Private _process As String
    Private _type As String
    Private _pvncd As Integer
    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
        '_process = Request("process").ToString()
        Try
            _type = Request("type").ToString()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        get_pvncd()
        If Not IsPostBack Then
            load_ddl()
            'load_GV_lcnno()
        End If
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Private Sub load_ddl()
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand

        dt = bao.SP_MAS_NYMSTAFF_PROCESS

        ddl_search.DataSource = dt 'dao.datas
        ddl_search.DataTextField = "PROCESS_NAME"
        ddl_search.DataValueField = "PROCESS_ID"
        ddl_search.DataBind()
        Dim item As New ListItem
        item.Text = "กรุณาเลือกประเภท"
        item.Value = "0"
        ddl_search.Items.Insert(0, item)
    End Sub

    Protected Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource  'หาข้อมูลมาใส่ 
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        dt = bao.SP_DATA_NYM2_STAFF()
        RadGrid1.DataSource = dt

    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand    'กดปุ่มใน grid ให้ทำอะไร จากหหน้
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim NYM As String = "2"
            Dim NYM2_ida As String = item("NYM2_IDA").Text
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2


            If e.CommandName = "sel" Then
                '    dao.GetDataby_IDA(NYM2_ida)
                'Dim tr_id As Integer = 0
                'Try
                '    tr_id = dao.fields.TR_ID
                'Catch ex As Exception

                'End Try

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "../STAFF_NYM/FRM_NYM_CONFIRM.aspx?IDA=" & NYM2_ida & "&Process= " & _process & "');", True)
            End If
        End If
    End Sub
    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("NYM2_IDA").Text
            Dim btn_edit As LinkButton = DirectCast(item("btn_edit").Controls(0), LinkButton)
            Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
            dao.GetDataby_IDA(IDA)
            btn_edit.Style.Add("display", "none")
            Try
                If dao.fields.STATUS_ID = 6 Then
                    btn_edit.Style.Add("display", "block")
                End If
            Catch ex As Exception

            End Try
            Dim url As String = "../LCN_STAFF/FRM_STAFF_LCN_CONSIDER_UPDATE.aspx?IDA=" & IDA
            btn_edit.Attributes.Add("OnClick", "Popups3('" & url & "'); return false;")
        End If
    End Sub
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim process_id As String
        Dim url As String = ""
        Dim NYM As String = ""
        Dim dao As New DAO_DRUG.clsDBMAS_NYMSTAFF_PROCESS
        process_id = ddl_search.SelectedValue
        If ddl_search.SelectedValue <> "0" Then
            If process_id = "10260" Or process_id = "10270" Or process_id = "10280" Or process_id = "10291" Or process_id = "10300" Then
                Select Case process_id
                    Case "10270"
                        NYM = "2"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM2.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM

                    Case "10280"
                        NYM = "3"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM3.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM

                    Case "10291"
                        NYM = "4"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM4.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM

                    Case "10300"
                        NYM = "5"
                        url = "../NEW_STAFF_NYM/FRM_STAFF_NYM5.aspx?process=" & ddl_search.SelectedValue & "&NYM=" & NYM

                End Select
                Response.Redirect(url)
            End If
        Else
            alert("กรุณาเลือกเลขบัญชีรายการยา")
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub
End Class