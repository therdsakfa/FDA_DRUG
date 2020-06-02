Imports Telerik.Web.UI

Public Class FRM_EXTEND_TIME_LOCATION_MAIN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String                  'ประกาศชื่อตัวแปร _process
    Private u1 As String
    Private lcntpcd As String = ""
    Private lcnno As String = ""
    Private CITIZEN_AUTHORIZE As String = ""
    Private lcntpcd_old As String = ""
    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()

        Try
            _CLS = Session("CLS")
            'นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")
            u1 = Request.QueryString("u1")  'เรียก Process ที่เราเรียก
            lcntpcd = Request.QueryString("lcncode")
            lcnno = Request.QueryString("lcn")
            CITIZEN_AUTHORIZE = Request.QueryString("c")
            lcntpcd_old = Request.QueryString("lcncode_o")

            If u1 <> "" Then
                'u1 = u1.DecodeBase64()
            End If
            If lcntpcd <> "" Then
                'lcntpcd = lcntpcd.DecodeBase64
            End If
            If lcnno <> "" Then
                'lcnno = lcnno.DecodeBase64
            End If
            If CITIZEN_AUTHORIZE <> "" Then
                'CITIZEN_AUTHORIZE = CITIZEN_AUTHORIZE.DecodeBase64
            End If
            If lcntpcd_old <> "" Then
                lcntpcd_old = lcntpcd_old.DecodeBase64
            End If
            '_lcn_ida = Request.QueryString("lcn_ida")
            'str_ID = Request.QueryString("str_ID")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            'Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2
            'load_ddl()
            Dim dao_u1 As New DAO_XML_DRUG_LCN.TB_XML_SEARCH_DRUG_LCN
            dao_u1.GetDataby_u1(u1)
            '
            If Request.QueryString("type") = "2" Then
                Try
                    Dim dao_dal As New DAO_DRUG.ClsDBdalcn
                    dao_dal.GetDataby_citi_lcnno_lcntpcd(CITIZEN_AUTHORIZE, lcnno, lcntpcd)
                    lbl_lcnno.Text = CStr(CInt(Right(dao_dal.fields.lcnno, 5))) & "/" & CStr(Left(dao_dal.fields.lcnno, 2))
                Catch ex As Exception
                    lbl_lcnno.Text = "-"
                End Try

            Else
                lbl_lcnno.Text = dao_u1.fields.lcnno_no
            End If

            gen_type_and_money(u1)

        End If
    End Sub
    'Private Sub load_ddl()
    '    Dim dao As New DAO_DRUG.TB_MAS_LCN_EXTEND_TYPE
    '    dao.GetDataAll2()

    '    ddl_search.DataSource = dao.datas
    '    ddl_search.DataTextField = "description44"
    '    ddl_search.DataValueField = "IDA"
    '    ddl_search.DataBind()
    '    Dim item As New ListItem
    '    item.Text = "กรุณาเลือกประเภทใบอนุญาต"
    '    item.Value = "0"
    '    ddl_search.Items.Insert(0, item)
    'End Sub
    Public Function Check(ByVal _year As Integer)
        Dim check_u1 As Boolean = True
        Dim u1_check As New DAO_XML_DRUG_LCN.TB_XML_SEARCH_DRUG_LCN
        u1_check.GetDataby_u1(u1)
        Dim u1_checkcode As New DAO_DRUG.TB_LCN_EXTEND_LITE
        u1_checkcode.GetDataby_u1_year(u1, _year)
        If Request.QueryString("type") = "2" Then
            check_u1 = True
        Else
            If u1_check.fields.Newcode_not = u1_checkcode.fields.U1_CODE Then
                check_u1 = False
            Else
                check_u1 = True
            End If
        End If

        Return check_u1
    End Function

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'Dim dt1 As New DataTable
        Dim dao_u1 As New DAO_XML_DRUG_LCN.TB_XML_SEARCH_DRUG_LCN
        dao_u1.GetDataby_u1(u1)
        Dim dao As New DAO_DRUG.TB_LCN_EXTEND_LITE
        'dao.GetDataby_u1_code(u1)

        Dim dao2 As New DAO_DRUG.ClsDBdalcn
        dao2.GetDataby_citi_lcnno_lcntpcd(CITIZEN_AUTHORIZE, lcnno, lcntpcd)

        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_GET_LCN_EXTEND_BY_CITI_LCNCODE_LCNNO(CITIZEN_AUTHORIZE, lcnno, lcntpcd)

        Dim result As Boolean = Check(con_year(Date.Now.Year) + 1)
        If result = True Then
            Dim dao_t As New DAO_DRUG.TB_MAS_LCN_EXTEND_TYPE
            If Request.QueryString("type") = "2" Then
                dao_t.GetDataby_lcntpcd(dao2.fields.lcntpcd)
            Else
                dao_t.GetDataby_lcntpcd(dao_u1.fields.lcntpcd)

            End If

            dao.fields.PROCESS_ID = dao_t.fields.process
            dao.fields.process_l44 = dao_t.fields.process_l44
            Try
                If dao_t.fields.process_l44 = "102730" Then
                    'dao.fields.process_l44_2 = "102780"
                Else
                    dao_t.fields.process_l44 = ""
                End If
            Catch ex As Exception

            End Try

            dao.fields.STATUS_ID = 1
            If Request.QueryString("type") = "2" Then
                For Each dr As DataRow In dt.Rows
                    dao.fields.lcnno = dr("lcnno")
                    dao.fields.pvncd = dr("pvncd")
                    dao.fields.lcntpcd = dr("lcntpcd")
                    dao.fields.lcnsid = dr("lcnsid")
                    dao.fields.CITIZEN_AUTHORIZE = dr("CITIZEN_ID")
                    dao.fields.thanm = dr("thanm")
                    dao.fields.thanm_address = dr("thanm_address")
                    Try
                        dao.fields.lcnno_display_full = dr("lcnno_no")
                    Catch ex As Exception

                    End Try
                    dao.fields.lcnno_pvnabbr = "" 'dao2.fields.lcnno_not_pvnabbr
                    dao.fields.U1_CODE = dr("Newcode_not")
                    dao.fields.licen = dr("licen")
                    dao.fields.licen_address = ""
                    dao.fields.licen_time = dr("opentime")
                    dao.fields.grannm_lo = dr("BSN_THAIFULLNAME")
                    dao.fields.grannm_address = "" 'dao2.fields.grannm_address
                    dao.fields.thaamphrnm = dr("LOCATION_ADDRESS_thaamphrnm")
                    dao.fields.thachngwtnm = dr("LOCATION_ADDRESS_thachngwtnm")
                    dao.fields.typee = dr("lcntpcd")
                    dao.fields.GROUPNAME = "LCN"
                    'dao.fields.cncnm = Nothing
                    dao.fields.IS_NEW = 1
                Next
            Else
                dao.fields.lcnno = dao_u1.fields.lcnno
                dao.fields.pvncd = dao_u1.fields.pvncd
                dao.fields.lcntpcd = dao_u1.fields.lcntpcd
                dao.fields.lcnsid = dao_u1.fields.lcnsid
                dao.fields.CITIZEN_AUTHORIZE = dao_u1.fields.CITIZEN_AUTHORIZE
                dao.fields.thanm = dao_u1.fields.thanm
                dao.fields.thanm_address = dao_u1.fields.thanm_address


                dao.fields.lcnno_display_full = dao_u1.fields.lcnno_no
                dao.fields.lcnno_pvnabbr = dao_u1.fields.lcnno_not_pvnabbr
                dao.fields.U1_CODE = dao_u1.fields.Newcode_not
                dao.fields.licen = dao_u1.fields.licen
                dao.fields.licen_address = dao_u1.fields.licen_address
                dao.fields.licen_time = dao_u1.fields.licen_time
                dao.fields.grannm_lo = dao_u1.fields.grannm_lo
                dao.fields.grannm_address = dao_u1.fields.grannm_address
                dao.fields.thaamphrnm = dao_u1.fields.thaamphrnm
                dao.fields.thachngwtnm = dao_u1.fields.thachngwtnm
                dao.fields.typee = dao_u1.fields.typee
                dao.fields.GROUPNAME = dao_u1.fields.GROUPNAME
                dao.fields.cncnm = dao_u1.fields.cncnm
            End If
            
            dao.fields.app_date = Date.Now.ToShortDateString
            dao.fields.PAY_L44_STAMP = lbl_price.Text
            dao.fields.extend_year = con_year(Date.Now.Year) + 1 'Date.Now.Year + 1

            dao.insert()
            Response.Redirect("FRM_EXTEND_TIME_LOCATION_SEARCH.aspx")
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('มีข้อมูลแล้ว');", True)
        End If
        'RadGrid1.DataSource = dt1
    End Sub

    'Protected Sub ddl_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_search.SelectedIndexChanged
    '    If ddl_search.SelectedValue = 1 Then
    '        lbl_price.Text = "500" 
    '    ElseIf ddl_search.SelectedValue = 2 Then
    '        lbl_price.Text = "500"
    '    ElseIf ddl_search.SelectedValue = 3 Then
    '        lbl_price.Text = "500"
    '    ElseIf ddl_search.SelectedValue = 4 Then
    '        lbl_price.Text = "500"
    '    End If
    'End Sub

    'Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
    '    If TypeOf e.Item Is GridDataItem Then
    '        Dim item As GridDataItem = e.Item
    '        If e.CommandName = "sel" Then
    '            Response.Redirect("../FRM_EXTEND_TIME_LOCATION_MAIN.aspx")
    '            'Dim id_r As String = item("IDA").Text
    '            'Dim url2 As String = "../FRM_EXTEND_TIME_LOCATION_MAIN.aspx?id_r=" & id_r
    '            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url2 & "');", True)
    '            'ElseIf e.CommandName = "stat" Then
    '            '    Dim IDA As String = item("IDA").Text
    '            '    Dim url2 As String = "../CHANGE_STATUS/NEW/FRM_ETRACKING_STATUS_HEAD_MAIN_RQ_CENTER.aspx?id_r=" & IDA & "&r=1"
    '            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups3('" & url2 & "');", True)
    '        End If
    '    End If
    'End Sub

    'Private Sub ddl_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_search.SelectedIndexChanged
    'If ddl_search.SelectedValue <> 0 Then
    '    Dim dao As New DAO_DRUG.TB_MAS_LCN_EXTEND_TYPE
    '    dao.GetDataby_IDA(ddl_search.SelectedValue)
    '    Try
    '        lbl_price.Text = String.Format("{0:###,###.##}", dao.fields.pay_amount)
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        lbl_price44.Text = String.Format("{0:###,###.##}", dao.fields.pay_amount44)
    '        If ddl_search.SelectedValue <> 1 Then
    '            lbl_price44_2.Style.Add("display", "none")
    '        Else

    '            lbl_price44_2.Style.Add("display", "block")
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End If
    'End Sub
    Sub gen_type_and_money(ByVal u1_code As String)

        Dim u1_check As New DAO_XML_DRUG_LCN.TB_XML_SEARCH_DRUG_LCN
        u1_check.GetDataby_u1(u1_code)

        Dim u1_check2 As New DAO_DRUG.ClsDBdalcn
        u1_check2.GetDataby_citi_lcnno_lcntpcd(CITIZEN_AUTHORIZE, lcnno, lcntpcd)


        Dim dao As New DAO_DRUG.TB_MAS_LCN_EXTEND_TYPE
        Try
            If Request.QueryString("type") = "2" Then
                'dao.GetDataby_lcntpcd(u1_check2.fields.lcntpcd)
                dao.GetDataby_process(u1_check2.fields.PROCESS_ID)
            Else
                dao.GetDataby_lcntpcd(u1_check.fields.lcntpcd)
            End If

        Catch ex As Exception

        End Try

        Try
            lbl_pay_type.Text = dao.fields.description44
        Catch ex As Exception

        End Try
        '
        Try
            lbl_price.Text = String.Format("{0:###,###.##}", dao.fields.pay_amount)
        Catch ex As Exception

        End Try
        Try
            lbl_price44.Text = String.Format("{0:###,###.##}", dao.fields.pay_amount44)
            If dao.fields.type_lcn <> "ขย1" Then
                lbl_price44_2.Style.Add("display", "none")
            Else

                lbl_price44_2.Style.Add("display", "block")
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class