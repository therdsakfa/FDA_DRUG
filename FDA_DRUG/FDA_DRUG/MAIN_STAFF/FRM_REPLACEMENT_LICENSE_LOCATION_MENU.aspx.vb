Imports Telerik.Web.UI
Public Class FRM_REPLACEMENT_LICENSE_LOCATION_MENU
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _lctida As String = ""
    Private _MENU_GROUP As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            BindMenu(CDec(_MENU_GROUP))
        End If
    End Sub



    Public Sub BindMenu(ByVal NodeGroup As Integer)
        Dim TreeView1 As New RadTreeView
        TreeView1 = DirectCast(rcb_Process.Items(0).FindControl("rtv_Process"), RadTreeView)
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU_AUTO
        dao.GetDataby_HEAD_ID(0, _MENU_GROUP)
        For Each dao.fields In dao.datas
            Dim t_node As New RadTreeNode
            t_node.Value = dao.fields.IDA
            t_node.Text = dao.fields.NAME
            Try
                t_node.ToolTip = dao.fields.NAME
            Catch ex As Exception

            End Try
            If dao.fields.URL = "#" Or dao.fields.URL = "" Then
                t_node.NavigateUrl = HttpContext.Current.Request.Url.AbsoluteUri & "#"
            Else
                If Request.QueryString("lct_ida") <> "" Then
                    t_node.NavigateUrl = dao.fields.URL & "&lct_ida=" & Request.QueryString("lct_ida")
                    If Request.QueryString("lcn_ida") <> "" Then
                        t_node.NavigateUrl = t_node.NavigateUrl & "&lcn_ida=" & Request.QueryString("lcn_ida")
                    End If
                Else
                    t_node.NavigateUrl = dao.fields.URL
                End If
            End If

            Try
                t_node.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            Catch ex As Exception

            End Try

            TreeView1.Nodes.Add(t_node)

            gen_child_node(t_node.Nodes, dao.fields.IDA, NodeGroup) '4292


        Next

    End Sub

    Private Function set_System_ID() As Integer
        Dim System_ID As Integer
        If _CLS.Groups = "19871" Or _CLS.Groups = "19872" Or _CLS.Groups = "38031" Then
            System_ID = 4292
        Else
            System_ID = 5323
        End If

        Return System_ID
    End Function
    Public Sub gen_child_node(ByVal t_node As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0, Optional NodeGroup As Integer = 1, Optional group_per As Integer = 0)
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU_AUTO
        dao.GetDataby_HEAD_ID(ParentID, _MENU_GROUP)
        For Each dao.fields In dao.datas
            Dim t_node2 As New RadTreeNode
            t_node2.Value = dao.fields.IDA
            t_node2.Text = dao.fields.NAME
            Try
                t_node2.ToolTip = dao.fields.NAME
            Catch ex As Exception

            End Try
            If dao.fields.URL <> "#" Then
                If Request.QueryString("lct_ida") <> "" Then
                    t_node2.NavigateUrl = dao.fields.URL & "&lct_ida=" & _lctida
                    If Request.QueryString("lcn_ida") <> "" Then
                        t_node2.NavigateUrl = t_node2.NavigateUrl & "&lcn_ida=" & Request.QueryString("lcn_ida")
                    End If
                Else
                    t_node2.NavigateUrl = dao.fields.URL
                End If
            Else
                If Request.QueryString("lct_ida") <> "" Then
                    t_node2.NavigateUrl = dao.fields.URL & "&lct_ida=" & _lctida
                    If Request.QueryString("lcn_ida") <> "" Then
                        t_node2.NavigateUrl = t_node2.NavigateUrl & "&lcn_ida=" & Request.QueryString("lcn_ida")
                    End If
                Else
                    t_node2.NavigateUrl = dao.fields.URL
                End If
            End If

            Try
                t_node2.NavigateUrl &= "&staff=1&identify=" & _CLS.CITIZEN_ID_AUTHORIZE
            Catch ex As Exception

            End Try
            t_node.Add(t_node2)
            gen_child_node(t_node2.Nodes, dao.fields.IDA, NodeGroup, group_per)
        Next
    End Sub


    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
                _lctida = Request.QueryString("lct_ida")
                _MENU_GROUP = Request.QueryString("MENU_GROUP")


            End If

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub

End Class