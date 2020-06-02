Public Class Main_E_Tracking
    Inherits System.Web.UI.MasterPage
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
        Try
            If Request.QueryString("FK_IDA") <> "" Then
                'HyperLink1.NavigateUrl = "../LOCATION/FRM_LCN_LCT.aspx?FK_IDA=" & Request.QueryString("FK_IDA")
            Else
                'HyperLink1.NavigateUrl = "../LOCATION/FRM_LCN_LCT.aspx"
            End If
        Catch ex As Exception

        End Try

        Dim GROUPS As Integer = 0
        Try
            GROUPS = _CLS.GROUPS
        Catch ex As Exception

        End Try

        'If _CLS.GROUPS = "21020" Then
        '    HyperLink1.NavigateUrl = "../E_TRACKING/FRM_E_TRACKING_PANEL.aspx"
        'End If
        If GROUPS <> "21020" Then
            Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_GROUP
            dao.GetDataby_ID_GROUP(GROUPS)
            Try
                If dao.fields.TYPE_PERSON = 1 Then
                    HyperLink1.NavigateUrl = "../E_TRACKING/NEW/FRM_E_TRACKING_GROUP_HEAD.aspx?g=" & dao.fields.GROUP_WORK
                ElseIf dao.fields.TYPE_PERSON = 2 Then
                    HyperLink1.NavigateUrl = "../E_TRACKING/NEW/FRM_E_TRACKING_PERSON_GRAPH2.aspx?gid=" & dao.fields.GROUP_WORK & "&ctzid=" & _CLS.CITIZEN_ID & "&p=1"
                End If
            Catch ex As Exception

            End Try
        Else
            HyperLink1.NavigateUrl = "../E_TRACKING/NEW/FRM_E_TRACKING_PANEL_NEW.aspx"
        End If

        HyperLink2.NavigateUrl = "../E_TRACKING/CHANGE_STATUS/FRM_DRRGT_STATUS_MAIN.aspx"
        HyperLink3.NavigateUrl = "../E_TRACKING/TIME_CALCULATE/FRM_E_TRACKING_TIME_CAL_MAIN.aspx"
        HyperLink4.NavigateUrl = "../E_TRACKING/CHANGE_STATUS/FRM_E_TRACKING_MANAGE.aspx"
        If Not IsPostBack Then

            Try
                hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM
                'hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER
            Catch ex As Exception

            End Try

        End If
    End Sub
End Class