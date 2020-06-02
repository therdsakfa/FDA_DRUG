Public Class UC_NODE_AUTO2
    Inherits System.Web.UI.UserControl

    Private _lcnsid As Integer
    Public Property lcnsid() As Integer
        Get
            Return _lcnsid
        End Get
        Set(ByVal value As Integer)
            _lcnsid = value
        End Set
    End Property

    ''' <summary>
    ''' ขย
    ''' </summary>
    ''' <remarks></remarks>
    Private _lcn_type As String
    Public Property lcn_type() As String
        Get
            Return _lcn_type
        End Get
        Set(ByVal value As String)
            _lcn_type = value
        End Set
    End Property
    Private _group As String
    Public Property group() As String
        Get
            Return _group
        End Get
        Set(ByVal value As String)
            _group = value
        End Set
    End Property

    Private dt As New DataTable
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        gen_treeview()
        '
    End Sub

    Public Sub gen_treeview()
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU_AUTO
        dao.GetDataby_HEAD_ID(0, group)
        TreeView1.Nodes.Clear()

        For Each dao.fields In dao.datas
            Dim t_node As New TreeNode
            t_node.Value = dao.fields.NAME
            t_node.Text = dao.fields.NAME
            t_node.Expanded = True
            If dao.fields.URL = "#" Then
                t_node.NavigateUrl = HttpContext.Current.Request.Url.AbsolutePath & "#"
            Else
                If Request.QueryString("lct_ida") <> "" Then
                    If dao.fields.URL.Contains("TOKEN") Or dao.fields.URL.Contains("AUTHEN") Then
                        t_node.NavigateUrl = dao.fields.URL & "?Token=" & _CLS.TOKEN
                    Else
                        t_node.NavigateUrl = dao.fields.URL & "&lct_ida=" & Request.QueryString("lct_ida")
                    End If

                    If Request.QueryString("lcn_ida") <> "" Then
                        t_node.NavigateUrl = t_node.NavigateUrl & "&lcn_ida=" & Request.QueryString("lcn_ida")
                    End If
                    If Request.QueryString("staff") <> "" Then
                        t_node.NavigateUrl = t_node.NavigateUrl & "&staff=1" & "&identify=" & Request.QueryString("identify")
                    End If

                Else
                    Dim count_num As Integer = 0
                    Dim c_rows As Integer = 0
                    Try
                        Dim dao_c As New DAO_DRUG.TB_EDT_COUNT
                        dao_c.GetDataby_IDA(Request.QueryString("ida_c"))
                        count_num = dao_c.fields.EDIT_COUNT

                        Dim bao As New BAO.ClsDBSqlcommand

                        Try
                            c_rows = bao.SP_EDT_HISTORY_COUNT_BY_FK_IDA(Request.QueryString("ida"), count_num, dao.fields.SEQ)
                        Catch ex As Exception

                        End Try
                    Catch ex As Exception

                    End Try
                    If c_rows > 0 Then
                        t_node.ImageUrl = "../Images/ok.png"
                    End If
                    If Request.QueryString("iden") <> "" Then
                        Dim url As String = ""
                        If dao.fields.URL.Contains("TOKEN") Or dao.fields.URL.Contains("AUTHEN") Then
                            url = dao.fields.URL & "?Token=" & _CLS.TOKEN
                        Else
                            url = dao.fields.URL & "&iden=" & Request.QueryString("iden") & "&ida=" & Request.QueryString("ida")
                            If Request.QueryString("ida_c") <> "" Then
                                url += "&ida_c=" & Request.QueryString("ida_c")
                            End If
                            If Request.QueryString("process") <> "" Then
                                url += "&process=" & Request.QueryString("process")
                            End If
                        End If

                        If Request.QueryString("staff") <> "" Then
                            url = url & "&staff=1" & "&identify=" & Request.QueryString("identify")
                        End If
                        t_node.NavigateUrl = url

                    ElseIf Request.QueryString("ida") <> "" Then
                        Dim url As String = ""

                        If dao.fields.URL.Contains("TOKEN") Or dao.fields.URL.Contains("AUTHEN") Then
                            url = dao.fields.URL & "?Token=" & _CLS.TOKEN

                            t_node.NavigateUrl = url
                        Else
                            url = "&ida=" & Request.QueryString("ida")
                            If Request.QueryString("ida_c") <> "" Then
                                url += "&ida_c=" & Request.QueryString("ida_c")
                            End If
                            If Request.QueryString("process") <> "" Then
                                url += "&process=" & Request.QueryString("process")
                            End If

                            If Request.QueryString("staff") <> "" Then
                                url = url & "&staff=1" & "&identify=" & Request.QueryString("identify")
                            End If
                            t_node.NavigateUrl = dao.fields.URL & url
                        End If



                    Else
                        If dao.fields.URL.Contains("TOKEN") Or dao.fields.URL.Contains("AUTHEN") Then
                            t_node.NavigateUrl = dao.fields.URL & "?Token=" & _CLS.TOKEN
                        Else
                            If Request.QueryString("staff") <> "" Then
                                t_node.NavigateUrl = dao.fields.URL & "&staff=1" & "&identify=" & Request.QueryString("identify")
                            Else
                                t_node.NavigateUrl = dao.fields.URL
                            End If

                        End If

                    End If
                End If

                'If Request.QueryString("FK_IDA") <> "" Then
                '    t_node.NavigateUrl = dao.fields.URL & "?FK_IDA=" & Request.QueryString("FK_IDA")
                'Else
                '    t_node.NavigateUrl = dao.fields.URL
                'End If
            End If

            TreeView1.Nodes.Add(t_node)
            gen_child_node(t_node.ChildNodes, dao.fields.IDA)
        Next


    End Sub
    Public Sub gen_child_node(ByVal t_node As TreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU_AUTO
        dao.GetDataby_HEAD_ID(ParentID, group)
        For Each dao.fields In dao.datas
            Dim t_node2 As New TreeNode
            t_node2.Value = dao.fields.NAME
            t_node2.Text = dao.fields.NAME
            t_node2.Expanded = dao.fields.IS_EXPAND
            Try
                t_node2.Expanded = dao.fields.IS_EXPAND
            Catch ex As Exception
                t_node2.Expanded = False
            End Try

            't_node2.NavigateUrl = dao.fields.URL
            If dao.fields.URL = "#" Then
                t_node2.NavigateUrl = HttpContext.Current.Request.Url.AbsolutePath & "#"
            Else
                If Request.QueryString("lct_ida") <> "" Then
                    If dao.fields.URL.Contains("TOKEN") Or dao.fields.URL.Contains("AUTHEN") Then
                        t_node2.NavigateUrl = dao.fields.URL & "?Token=" & _CLS.TOKEN
                    Else
                        t_node2.NavigateUrl = dao.fields.URL & "&lct_ida=" & Request.QueryString("lct_ida") '& "&lcn_ida=" & Request.QueryString("lcn_ida")

                        If Request.QueryString("lcn_ida") <> "" Then
                            t_node2.NavigateUrl = t_node2.NavigateUrl & "&lcn_ida=" & Request.QueryString("lcn_ida")
                        End If
                        If Request.QueryString("staff") <> "" Then
                            t_node2.NavigateUrl = t_node2.NavigateUrl & "&staff=1" & "&identify=" & Request.QueryString("identify")
                        End If
                    End If

                Else
                    Dim count_num As Integer = 0
                    Dim c_rows As Integer = 0
                    Try
                        Dim dao_c As New DAO_DRUG.TB_EDT_COUNT
                        dao_c.GetDataby_IDA(Request.QueryString("ida_c"))
                        count_num = dao_c.fields.EDIT_COUNT

                        Dim bao As New BAO.ClsDBSqlcommand

                        Try
                            c_rows = bao.SP_EDT_HISTORY_COUNT_BY_FK_IDA(Request.QueryString("ida"), count_num, dao.fields.SEQ)
                        Catch ex As Exception

                        End Try
                    Catch ex As Exception

                    End Try
                    If c_rows > 0 Then
                        t_node2.ImageUrl = "../Images/ok.png"
                    End If
                    If Request.QueryString("iden") <> "" Then
                        Dim url As String = ""
                        If dao.fields.URL.Contains("TOKEN") Or dao.fields.URL.Contains("AUTHEN") Then
                            url = dao.fields.URL & "?Token=" & _CLS.TOKEN
                        Else
                            url = dao.fields.URL & "&iden=" & Request.QueryString("iden") & "&ida=" & Request.QueryString("ida")
                            If Request.QueryString("ida_c") <> "" Then
                                url += "&ida_c=" & Request.QueryString("ida_c")
                            End If
                            If Request.QueryString("process") <> "" Then
                                url += "&process=" & Request.QueryString("process")
                            End If
                        End If
                        If Request.QueryString("staff") <> "" Then
                            url = url & "&staff=1" & "&identify=" & Request.QueryString("identify")
                        End If
                        t_node2.NavigateUrl = url
                    ElseIf Request.QueryString("ida") <> "" Then
                        Dim url As String = ""
                        url = "&ida=" & Request.QueryString("ida")
                        If Request.QueryString("ida_c") <> "" Then
                            url += "&ida_c=" & Request.QueryString("ida_c")
                        End If
                        If Request.QueryString("process") <> "" Then
                            url += "&process=" & Request.QueryString("process")
                        End If
                        If Request.QueryString("staff") <> "" Then
                            url = url & "&staff=1" & "&identify=" & Request.QueryString("identify")
                        End If
                        t_node2.NavigateUrl = dao.fields.URL & url
                    Else
                        If dao.fields.URL.Contains("TOKEN") Or dao.fields.URL.Contains("AUTHEN") Then
                            t_node2.NavigateUrl = dao.fields.URL & "?Token=" & _CLS.TOKEN
                        Else
                            If Request.QueryString("staff") <> "" Then
                                t_node2.NavigateUrl = dao.fields.URL & "&staff=1" & "&identify=" & Request.QueryString("identify")
                            Else
                                t_node2.NavigateUrl = dao.fields.URL
                            End If
                        End If
                    End If
                End If
            End If
            t_node.Add(t_node2)
            gen_child_node(t_node2.ChildNodes, dao.fields.IDA)
        Next
    End Sub
End Class
