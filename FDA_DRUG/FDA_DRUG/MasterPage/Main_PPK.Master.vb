Public Class Main_PPK
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            '_CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Request.QueryString("staff") <> "" Then
            HyperLink1.Style.Add("display", "block")
        End If
        If Not IsPostBack Then
 Try
                'lbl_name_user.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM 'รับค่า ชื่อผู้ใช้
                'lbl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER 'รับค่า ชื่อผู้ได้รับอนุญาต
            Catch ex As Exception

            End Try
        End If

        
        Dim txt As String = ""
        
        UC_NODE_AUTO.group = 1
        'Literal1.Text = gen_menu()
    End Sub
    Function gen_menu() As String
        Dim txt As String = ""
        Dim all_txt As String = ""
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_HEAD_ID(0, 1)
        'txt &= "<a Class='tab-content-item active' href='../MODULE01/MAIN_PAGE.aspx?dept=" & Request.QueryString("dept") & "'><i class='h-icon icon-active fas fa-bookmark'></i><i class='h-icon icon-off far fa-bookmark'></i>Dashboard</a>"
        'txt &= "<a class='tab-content-item'><i class='h-icon icon-active fas fa-bookmark'></i><i class='h-icon icon-off far fa-bookmark'></i>รายงาน</a>"

        For Each dao.fields In dao.datas
            txt = " <div Class='wrap-tab-content-item-list'>"
            txt &= " <a Class='tab-content-item' href='" & Replace(dao.fields.URL, "~", "..") & "'><i Class='h-icon icon-active fas fa-bookmark'></i><i Class='h-icon icon-off far fa-bookmark'></i>" & dao.fields.NAME & "</a>"
            txt &= "    <div Class='tab-content-item-list'>"

            'txt &= "        <div data-target='p1' Class='tcil-item'>"
            'txt &= "            <a href ='../MODULE01/POPUP_CREATE_IDT1.aspx'> Template ตัวชี้วัด : หน่วยวัด ร้อยละ</a>"
            'txt &= "        </div>"
            'txt &= "        <div data-target='p2' Class='tcil-item'>"
            'txt &= "            <a href ='../MODULE01/POPUP_CREATE_IDT2.aspx'> Template ตัวชี้วัด : หน่วยวัดหมวดและระดับ</a>"
            'txt &= "        </div>"
            txt &= gen_child_node(dao.fields.IDA)
            txt &= " <div class='clearfix'></div>"
            txt &= "    </div>"
            txt &= " </div>"
            all_txt &= txt
        Next

        Return all_txt
    End Function

    Public Function gen_child_node(Optional ByVal ParentID As Integer = 0) As String
        Dim dao As New DAO_DRUG.ClsDBMAS_MENU
        dao.GetDataby_HEAD_ID(ParentID, 1)
        Dim txt As String = ""
        Dim all_txt As String = ""
        Dim i As Integer = 1
        For Each dao.fields In dao.datas
            'txt &= "        <div data-target='p" & i & "' Class='tcil-item'>"
            txt &= "            <a Class='tcil-item' href ='" & Replace(dao.fields.URL, "~", "..") & "'>" & dao.fields.NAME & "</a>"
            'txt &= "        </div>"
            i += 1
            all_txt &= txt
        Next
        Return all_txt
    End Function
End Class