Imports Telerik.Web.UI

Public Class FRM_LCN_STAFF_LCN_INFORMATION
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub Run_Service(ByVal IDA As Integer)
        'Try
        '    Dim ws_update As New WS_DRUG.WS_DRUG
        '    ws_update.DRUG_UPDATE_LICEN(IDA, _CLS.CITIZEN_ID)
        'Catch ex As Exception

        'End Try


        Try
            Dim ws_update126 As New WS_DRUG_126.WS_DRUG
            ws_update126.DRUG_UPDATE_LICEN_126(IDA, _CLS.CITIZEN_ID)
        Catch ex As Exception

        End Try



    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        Try
            Shows(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If Not IsPostBack Then
            rdp_cncdate.SelectedDate = Date.Now

            Dim dao As New DAO_DRUG.ClsDBdalcn
            Dim lcntpcd As String = ""
            Dim process_id As String = ""
            Dim ccc As String = ""
            Try
                dao.GetDataby_IDA(Request.QueryString("IDA"))
            Catch ex As Exception

            End Try
            Try
                lbl_first_appdate.Text = CDate(dao.fields.frtappdate).ToShortDateString
            Catch ex As Exception

            End Try
            Try
                If dao.fields.PROCESS_ID = "101" Then
                    For Each item As ListItem In cbl_chk_sell_type_ky1.Items
                        If Trim(dao.fields.CHK_SELL_TYPE) = "1" Then
                            If item.Value = "1" Then
                                item.Selected = True
                            End If
                        End If
                        If Trim(dao.fields.CHK_SELL_TYPE1) = "1" Then
                            If item.Value = "2" Then
                                item.Selected = True
                            End If
                        End If
                        If Trim(dao.fields.CHK_SELL_TYPE2) = "1" Then
                            If item.Value = "3" Then
                                item.Selected = True
                            End If
                        End If
                    Next

                    Dim daoc As New DAO_DRUG.TB_DALCN_SELL_TYPE
                    daoc.GetDataby_FK_IDA(Request.QueryString("ida"))
                    For Each daoc.fields In daoc.datas
                        For Each item As ListItem In cbl_chk_sell_type_ky1_2.Items
                            If item.Value = daoc.fields.SELL_TYPE Then
                                item.Selected = True
                            End If
                        Next
                    Next


                End If
            Catch ex As Exception

            End Try
            bind_selltype()

            Try
                If dao.fields.PROCESS_ID = "104" Then
                    For Each item As ListItem In cbl_chk_sell_type_ky4.Items
                        If Trim(dao.fields.CHK_SELL_TYPE) = "13" Then
                            If item.Value = "13" Then
                                item.Selected = True
                            End If
                        End If
                        If Trim(dao.fields.CHK_SELL_TYPE1) = "12" Then
                            If item.Value = "12" Then
                                item.Selected = True
                            End If
                        End If

                    Next
                End If
            Catch ex As Exception

            End Try


            Try
                lcntpcd = dao.fields.lcntpcd
            Catch ex As Exception

            End Try
            Try
                process_id = dao.fields.PROCESS_ID
            Catch ex As Exception

            End Try
            Try
                ddl_template.DropDownSelectData(dao.fields.TEMPLATE_ID)
            Catch ex As Exception

            End Try
            Try
                lbl_date_cancel.Text = CDate(dao.fields.cncdate)
            Catch ex As Exception

            End Try
            Try
                txt_CATEGORY_DRUG.Text = dao.fields.CATEGORY_DRUG
            Catch ex As Exception

            End Try
            If process_id = "109" Or process_id = "110" Or process_id = "122" Or process_id = "127" Or process_id = "128" Then
                Panel1.Style.Add("display", "block")
            End If
            If process_id = "101" Then
                Panel2.Style.Add("display", "block")
            End If
            If process_id = "104" Then
                Panel3.Style.Add("display", "block")
            End If


            Try
                ccc = dao.fields.cnccscd
                'dao.fields.cnccscd = Nothing
                'lbl_statname.Text = dao.fields.
            Catch ex As Exception
                ccc = ""
            End Try
            Try
                txt_time.Text = dao.fields.opentime
            Catch ex As Exception

            End Try
            If ccc = "" Then
                lbl_statname.Text = "คงอยู่"
            Else
                Try
                    Dim dao_cnc As New DAO_DRUG.ClsDBdacscd
                    dao_cnc.GetData_by_cd(ccc)
                    lbl_statname.Text = dao_cnc.fields.csnm
                Catch ex As Exception

                End Try

            End If
            Try
                txt_appdate.Text = CDate(dao.fields.appdate).ToShortDateString()
            Catch ex As Exception

            End Try
            Dim expyear As Integer = 0
            Try
                expyear = dao.fields.expyear
            Catch ex As Exception

            End Try
            If expyear <> 0 Then
                If expyear < 2500 Then
                    expyear = expyear + 543
                    txt_expyear.Text = expyear
                Else
                    expyear = expyear
                    txt_expyear.Text = expyear
                End If
            End If
            bind_ddl_stat()

            Try
                ddl_stat.DropDownSelectData(dao.fields.cnccscd)
            Catch ex As Exception

            End Try


        End If
    End Sub
    Sub bind_ddl_stat()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
        Catch ex As Exception

        End Try
        Try
            Dim dao_stat As New DAO_DRUG.ClsDBdacscd
            dao_stat.GetDataAll()
            ddl_stat.DataSource = dao_stat.datas
            ddl_stat.DataTextField = "csnm"
            ddl_stat.DataValueField = "cscd"
            ddl_stat.DataBind()

            Dim item As New ListItem
            item.Text = "คงอยู่"
            item.Value = "0"
            ddl_stat.Items.Insert(0, item)
        Catch ex As Exception

        End Try
    End Sub
    Sub set_hide_show()
        If hd_location.Value = "0" Then
            btn_location.Style.Add("display", "block")
        Else
            btn_location.Style.Add("display", "none")
        End If

        If hdkeep.Value = "0" Then
            btn_add_keep.Style.Add("display", "block")
        Else
            btn_add_keep.Style.Add("display", "none")
        End If

    End Sub
    Public Sub Shows(ByVal IDA As Integer)
        Dim Tb As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS                               ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim TbNO As New DAO_DRUG.ClsDBdalcn                                     ' ประกาศตัวแปรเพื่อเรียกใช้
        Dim tb_location As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            TbNO.GetDataby_IDA(IDA)
            'การ where 
            Tb.GetDataby_IDA(TbNO.fields.FK_IDA)
        Catch ex As Exception

        End Try
        'การ where 
        Try
            tb_location.GetDataby_LCN_IDA(IDA)
        Catch ex As Exception

        End Try
        Dim lcnno As String = ""
        Dim rcvno As String = ""
        Try
            lcnno = TbNO.fields.lcntpcd & " " & CInt(Right(TbNO.fields.lcnno, 5)) & "/" & Left(TbNO.fields.lcnno, 2)
        Catch ex As Exception

        End Try

        Try
            If Right(Left(TbNO.fields.lcnno, 3), 1) = "5" Then
                lcnno = TbNO.fields.lcntpcd & " จ " & CInt(Right(TbNO.fields.lcnno, 4)) & "/" & Left(TbNO.fields.lcnno, 2)
            End If
        Catch ex As Exception

        End Try

        Try
            rcvno = CInt(Right(TbNO.fields.rcvno, 5)) & "/" & Left(TbNO.fields.rcvno, 2)
        Catch ex As Exception

        End Try
        Try
            If TbNO.fields.lcnno IsNot Nothing Then
                Dim raw_lcn As String = TbNO.fields.lcnno
                lbl_lcnno.Text = lcnno 'CStr(CInt((Right(raw_lcn, 5))) & "/25" & Left(raw_lcn, 2))
            End If
        Catch ex As Exception

        End Try
        'Try
        '    lbl_lcnno.Text = TbNO.fields.LCNNO_DISPLAY
        'Catch ex As Exception
        '    lbl_lcnno.Text = "-"
        'End Try

        Try
            lbl_citizenid.Text = TbNO.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try

        Try
            lbl_thanameplace.Text = Tb.fields.thanameplace
        Catch ex As Exception

        End Try
        Try
            lbl_nameOperator.Text = tb_location.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

    End Sub


    Private Sub rglocation_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rglocation.ItemCommand
        '
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            'Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            'dao.GetDataby_IDA(item("I").Text)

            'Dim dao_his As New DAO_DRUG.TB_DALCN_PHR_HISTORY
            If e.CommandName = "_edit" Then
                lbl_title.Text = "แก้ไขสถานที่ตั้ง"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_LOCATION_INSERT_AND_UPDATE.aspx?IDA=" & item("IDA").Text & "&t=1');", True)
            End If

        End If
    End Sub

    Private Sub rglocation_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles rglocation.ItemDataBound
        '
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As String = item("IDA").Text
            Dim btn_edit As LinkButton = DirectCast(item("_edit").Controls(0), LinkButton)
            Try
                If _CLS.PVCODE = 10 Then
                    btn_edit.Style.Add("display", "block")
                Else
                    btn_edit.Style.Add("display", "none")
                End If
            Catch ex As Exception

            End Try

            
        End If
    End Sub

    Private Sub rglocation_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rglocation.NeedDataSource
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        Try
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            If dao.fields.FK_IDA <> 0 Then
                dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao.fields.FK_IDA)
            End If

        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            rglocation.DataSource = dt
        End If

    End Sub

    Private Sub rgkeep_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rgkeep.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            'Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            'dao.GetDataby_IDA(item("I").Text)

            'Dim dao_his As New DAO_DRUG.TB_DALCN_PHR_HISTORY
            If e.CommandName = "edt" Then
                lbl_title.Text = "แก้ไขสถานที่เก็บ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_LOCATION_INSERT_AND_UPDATE.aspx?IDA=" & item("IDA").Text & "&t=2');", True)
            ElseIf e.CommandName = "del" Then
                Dim dao As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                Dim bao_addr As New BAO.ClsDBSqlcommand
                Dim dt As New DataTable
                bao_addr.SP_CUSTOMER_LCN_BY_IDA(item("IDA").Text)
                dt = bao_addr.dt
                Dim old_addr As String = ""
                Try
                    old_addr = dt(0)("fulladdr")
                Catch ex As Exception

                End Try
                KEEP_LOGS_EDIT(item("IDA").Text, "ลบสถานที่เก็บ - " & old_addr, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
                Try
                    dao.GetDataby_IDA(item("IDA").Text)
                    dao.delete()
                Catch ex As Exception

                End Try
                rgkeep.Rebind()
            End If

        End If
    End Sub

    Private Sub rgkeep_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgkeep.NeedDataSource
        Dim bao_mas As New BAO_MASTER
        Dim dt As New DataTable
        Try
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(Request.QueryString("IDA"))
            dt = bao_mas.SP_MASTER_DALCN_DETAIL_LOCATION_KEEP_BY_IDA(Request.QueryString("IDA"))
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            rgkeep.DataSource = dt
        End If

    End Sub

    Private Sub rg_bsn_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rg_bsn.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "_edit" Then
                If Len(item("BSN_IDENTIFY").Text) >= 13 Then
                    Dim bao_show11 As New BAO_SHOW
                    Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(item("BSN_IDENTIFY").Text)
                    Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
                    dao_bsn.GetDataby_LCN_IDA(Request.QueryString("IDA"))
                    For Each dr As DataRow In dt_bsn.Rows
                        KEEP_LOGS_EDIT(Request.QueryString("IDA"), "อัพเดตข้อมูลผู้ดำเนินกิจการจาก " & dao_bsn.fields.BSN_THAIFULLNAME & " เป็น " & dr("BSN_THAIFULLNAME"), _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
                        Try
                            dao_bsn.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ADDR = dr("BSN_ADDR")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_SOI = dr("BSN_SOI")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ROAD = dr("BSN_ROAD")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_MOO = dr("BSN_MOO")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_FAX = dr("BSN_FAX")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_THAINAME = dr("BSN_THAINAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.AMPHR_ID = dr("AMPHR_ID")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.TUMBON_ID = dr("TUMBON_ID")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_FLOOR = dr("BSN_FLOOR")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_BUILDING = dr("BSN_BUILDING")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.CREATE_DATE = dr("CREATE_DATE")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.DOWN_ID = dr("DOWN_ID")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.CITIZEN_ID = dr("CITIZEN_ID")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.XMLNAME = dr("XMLNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.NATIONALITY = dr("NATIONALITY")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ENGMU = dr("BSN_ENGMU")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
                        Catch ex As Exception

                        End Try
                        Try
                            dao_bsn.fields.AGE = dr("AGE")
                        Catch ex As Exception

                        End Try

                        dao_bsn.update()


                        Try
                            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
                            dao_dalcn.GetDataby_IDA(Request.QueryString("ida"))
                            set_data_dalcn(dao_dalcn, item("BSN_IDENTIFY").Text)
                            dao_dalcn.update()
                        Catch ex As Exception

                        End Try
                        'Dim ws_update As New WS_DRUG.WS_DRUG
                        'ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)

                        Dim ws_update126 As New WS_DRUG_126.WS_DRUG
                        ws_update126.DRUG_UPDATE_LICEN_126(Request.QueryString("ida"), _CLS.CITIZEN_ID)

                        rg_bsn.Rebind()
                        Try
                            Shows(Request.QueryString("IDA"))
                        Catch ex As Exception

                        End Try
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพเดทข้อมูลเรียบร้อยแล้ว');", True)
                    Next


                Else
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถอัพเดทข้อมูลได้เนื่องจากเลขบัตรประชาชนไม่ถูกต้อง');", True)
                End If
            ElseIf e.CommandName = "_edit2" Then
                '
                lbl_title.Text = "แก้ไขที่อยู่ผู้ดำเนินกิจการ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_BSN_EDIT_ADDR.aspx?ida=" & item("IDA").Text & "');", True)
            End If
        End If
    End Sub

    Private Sub rg_bsn_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_bsn.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_LOCATION_BSN_BY_LCN_IDA(Request.QueryString("IDA")) 'ผู้ดำเนิน
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            rg_bsn.DataSource = dt
        End If

        ' BAO_SHOW.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
    End Sub

    Private Sub rglcnname_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles rglcnname.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            If e.CommandName = "_edit" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                    If dao.fields.CITIZEN_ID_AUTHORIZE <> "" Then
                        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
                    Dim a As String = ""
                    Try
                        a = ws2.insert_taxno_authorize(dao.fields.CITIZEN_ID_AUTHORIZE)
                    Catch ex As Exception

                    End Try
                    Try
                        a = ws2.insert_taxno(dao.fields.CITIZEN_ID_AUTHORIZE)
                    Catch ex As Exception

                    End Try
                    Try
                        Dim ws1 As New WS_FDA_CITIZEN.WS_FDA_CITIZEN
                        ws1.FDA_CITIZEN(dao.fields.CITIZEN_ID_AUTHORIZE, "1102001745831", "fusion", "P@ssw0rdfusion440")
                    Catch ex As Exception

                    End Try
                    Try
                        Dim ws3 As New WS_TRADERS.WS_TRADER
                        ws3.CallWS_TRADER("fusion", "P@ssw0rdfusion440", dao.fields.CITIZEN_ID_AUTHORIZE)
                    Catch ex As Exception

                    End Try

                End If


                KEEP_LOGS_EDIT(Request.QueryString("IDA"), "อัพเดตข้อมูลผู้รับอนุญาต - " & dao.fields.CITIZEN_ID_AUTHORIZE, _CLS.CITIZEN_ID, url:=HttpContext.Current.Request.Url.AbsoluteUri)
                'Dim ws_update As New WS_DRUG.WS_DRUG
                'ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)

                Dim ws_update126 As New WS_DRUG_126.WS_DRUG
                ws_update126.DRUG_UPDATE_LICEN_126(Request.QueryString("ida"), _CLS.CITIZEN_ID)
                rglcnname.Rebind()
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('อัพเดทข้อมูลเรียบร้อยแล้ว');", True)
            End If
        End If
    End Sub

    Private Sub rglcnname_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rglcnname.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            dt = bao.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao.fields.CITIZEN_ID_AUTHORIZE, dao.fields.lcnsid)
        Catch ex As Exception

        End Try
        If dt.Rows.Count > 0 Then
            rglcnname.DataSource = dt
        End If

    End Sub

    Private Sub rgphr_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgphr.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim dao_his As New DAO_DRUG.TB_DALCN_PHR_HISTORY
            If e.CommandName = "edt" Then
                lbl_title.Text = "แก้ไขข้อมูลผู้มีหน้าที่ปฏิบัติการ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_PHR_EDIT.aspx?phr=" & item("PHR_IDA").Text & "');", True)
            ElseIf e.CommandName = "r_del" Then
                Dim name_del As String
                Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
                dao.GetDataby_IDA(item("PHR_IDA").Text)
                name_del = dao.fields.PHR_NAME
                dao.delete()

                'Dim ws_update As New WS_DRUG.WS_DRUG
                'ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)

                Dim ws_update126 As New WS_DRUG_126.WS_DRUG
                ws_update126.DRUG_UPDATE_LICEN_126(Request.QueryString("ida"), _CLS.CITIZEN_ID)
                KEEP_LOGS_EDIT(Request.QueryString("ida"), "ลบผู้มีหน้าที่ปฏิบัติการ " & name_del, _CLS.CITIZEN_ID)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ลบเรียบร้อยแล้ว');", True)

            ElseIf e.CommandName = "job" Then
                lbl_title.Text = "เพิ่ม/แก้ไขผู้มีหน้าที่ปฏิบัติการ"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_PHR_JOB.aspx?ida=" & Request.QueryString("ida") & "&ida_c=" & Request.QueryString("ida_c") & "&phr=" & item("PHR_IDA").Text & "');", True)
            End If
            rgphr.Rebind()
        End If
    End Sub

    Private Sub rgphr_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgphr.NeedDataSource
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        Try
            dt = bao.SP_DALCN_PHR_BY_FK_IDA_2(Request.QueryString("IDA"))
        Catch ex As Exception
            'FRM_STAFF_LCN_PHR_EDIT.aspx
        End Try
        If dt.Rows.Count > 0 Then
            rgphr.DataSource = dt
        End If

    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        rg_bsn.Rebind()
        rgkeep.Rebind()
        rglcnname.Rebind()
        rglocation.Rebind()
        rgphr.Rebind()
    End Sub

    Private Sub btn_location_Click(sender As Object, e As EventArgs) Handles btn_location.Click
        lbl_title.Text = "เพิ่มสถานที่ตั้ง"
        Dim IDA As String = ""
        Try
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(Request.QueryString("IDA"))
            'IDA = dao.fields.FK_IDA
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_LOCATION_INSERT_AND_UPDATE.aspx?lcn_ida=" & IDA & "&t=1');", True)
    End Sub

    Private Sub btn_add_keep_Click(sender As Object, e As EventArgs) Handles btn_add_keep.Click
        lbl_title.Text = "เพิ่มสถานที่ตั้ง"
        Dim IDA As String = ""
        Try
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(Request.QueryString("IDA"))
            'IDA = dao.fields.FK_IDA
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_LOCATION_INSERT_AND_UPDATE.aspx?lcn_ida=" & IDA & "&t=2');", True)
    End Sub

    Private Sub FRM_LCN_STAFF_LCN_INFORMATION_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        hd_location.Value = rglocation.Items.Count.ToString()
        hdkeep.Value = rgkeep.Items.Count.ToString()
        set_hide_show()

        Dim dao_ya As New DAO_DRUG.ClsDBdalcn
        dao_ya.GetDataby_IDA(Request.QueryString("IDA"))
        Try
            RadBinaryImage1.DataValue = Convert.FromBase64String(dao_ya.fields.IMAGE_BSN)
            RadBinaryImage1.ResizeMode = BinaryImageResizeMode.Fit
            RadBinaryImage2.DataValue = Convert.FromBase64String(dao_ya.fields.IMAGE_KEEP)
            RadBinaryImage2.ResizeMode = BinaryImageResizeMode.Fit
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_c_stat_Click(sender As Object, e As EventArgs) Handles btn_c_stat.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        Try
            If ddl_stat.SelectedValue = "0" Then
                dao.fields.cnccscd = Nothing
                dao.fields.cnccd = Nothing
                dao.update()
            Else
                dao.fields.cnccscd = ddl_stat.SelectedValue
                dao.fields.cnccd = 2
                dao.update()
            End If
        Catch ex As Exception

        End Try
        Run_Service(Request.QueryString("IDA"))
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อยแล้ว');", True)

        KEEP_LOGS_EDIT(Request.QueryString("IDA"), "แก้ไขสถานะใบอนุญาต", _CLS.CITIZEN_ID)
    End Sub

    Private Sub btn_add_keep_select_Click(sender As Object, e As EventArgs) Handles btn_add_keep_select.Click
        lbl_title.Text = "เพิ่มสถานที่เก็บ"
        Dim IDA As String = ""
        Try
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(Request.QueryString("IDA"))
            'IDA = dao.fields.FK_IDA
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_ADD_LOCATION_KEEP.aspx?ida=" & IDA & "&t=2');", True)
    End Sub

    Private Sub btn_location_select_Click(sender As Object, e As EventArgs) Handles btn_location_select.Click
        lbl_title.Text = "เลือกสถานที่ตั้งใหม่"
        Dim IDA As String = ""
        Try
            'Dim dao As New DAO_DRUG.ClsDBdalcn
            'dao.GetDataby_IDA(Request.QueryString("IDA"))
            'IDA = dao.fields.FK_IDA
            IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_ADD_LOCATION.aspx?ida=" & IDA & "&t=1');", True)
    End Sub

    Private Sub btn_lcnname_Click(sender As Object, e As EventArgs) Handles btn_lcnname.Click
        lbl_title.Text = "เปลี่ยนผู้รับอนุญาต"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_CHANGE_LCNSNM.aspx?ida=" & Request.QueryString("IDA") & "');", True)
    End Sub

    Private Sub btn_bsn_Click(sender As Object, e As EventArgs) Handles btn_bsn.Click
        lbl_title.Text = "เปลี่ยนผู้ดำเนินกิจการ"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_CHANGE_BSN.aspx?ida=" & Request.QueryString("IDA") & "');", True)
    End Sub

    Private Sub btn_phr_add_Click(sender As Object, e As EventArgs) Handles btn_phr_add.Click
        lbl_title.Text = "บันทึกข้อมูลผู้ปฏิบัติงาน"
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('FRM_STAFF_LCN_PHR_INSERT.aspx?ida=" & Request.QueryString("IDA") & "');", True)
    End Sub
    Public Sub set_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn, ByVal bsn_iden As String)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.Getdata_by_iden(bsn_iden)
        For Each dao_bsn.fields In dao_bsn.datas
            dao.fields.BSN_IDENTIFY = bsn_iden
            dao.fields.BSN_PREFIXTHAICD = dao_bsn.fields.BSN_PREFIXTHAICD
            dao.fields.BSN_THAINAME = dao_bsn.fields.BSN_THAINAME
            dao.fields.BSN_THAILASTNAME = dao_bsn.fields.BSN_THAILASTNAME
            dao.fields.BSN_ENGNAME = dao_bsn.fields.BSN_ENGNAME
            dao.fields.BSN_ENGLASTNAME = dao_bsn.fields.BSN_ENGLASTNAME
            dao.fields.BSN_ENGFULLNAME = dao_bsn.fields.BSN_ENGFULLNAME
            dao.fields.BSN_THAIFULLNAME = dao_bsn.fields.BSN_THAIFULLNAME
            Try
                dao.fields.bsnid = dao_bsn.fields.BSNID
            Catch ex As Exception

            End Try

            Dim CITIZEN_ID_AUTHORIZE As String = ""
            Try
                CITIZEN_ID_AUTHORIZE = bsn_iden
            Catch ex As Exception

            End Try

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
            Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)

            Try
                dao.fields.bsnid = dao_syslcnsid.fields.lcnsid
            Catch ex As Exception

            End Try

            'tha
            dao.fields.BSN_HOUSENO = dao_bsn.fields.BSN_HOUSENO
            dao.fields.BSN_ADDR = dao_bsn.fields.BSN_ENGADDR
            dao.fields.BSN_MOO = dao_bsn.fields.BSN_MOO
            dao.fields.BSN_SOI = dao_bsn.fields.BSN_SOI
            dao.fields.BSN_ROAD = dao_bsn.fields.BSN_ROAD
            dao.fields.BSN_CHWNGNAME = dao_bsn.fields.BSN_CHWNGNAME
            dao.fields.CHANGWAT_ID = dao_bsn.fields.CHANGWAT_ID
            dao.fields.AMPHR_ID = dao_bsn.fields.AMPHR_ID
            dao.fields.BSN_AMPHR_NAME = dao_bsn.fields.BSN_AMPHR_NAME
            dao.fields.BSN_THMBL_NAME = dao_bsn.fields.BSN_THMBL_NAME
            dao.fields.TUMBON_ID = dao_bsn.fields.TUMBON_ID
            dao.fields.BSN_TELEPHONE = dao_bsn.fields.BSN_TELEPHONE
            dao.fields.BSN_FAX = dao_bsn.fields.BSN_FAX

            ''eng
            dao.fields.BSN_ENGADDR = dao_bsn.fields.BSN_ENGADDR
            dao.fields.BSN_FLOOR = dao_bsn.fields.BSN_FLOOR
            dao.fields.BSN_ENGMU = dao_bsn.fields.BSN_ENGMU
            dao.fields.BSN_ENGSOI = dao_bsn.fields.BSN_ENGSOI
            dao.fields.BSN_ENGROAD = dao_bsn.fields.BSN_ENGROAD
            dao.fields.BSN_CHWNG_ENGNAME = dao_bsn.fields.BSN_CHWNG_ENGNAME
            dao.fields.BSN_AMPHR_ENGNAME = dao_bsn.fields.BSN_AMPHR_ENGNAME
            dao.fields.BSN_THMBL_ENGNAME = dao_bsn.fields.BSN_THMBL_ENGNAME
        Next
    End Sub

    Private Sub btn_time_Click(sender As Object, e As EventArgs) Handles btn_time.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim ccc As String = ""
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
            dao.fields.opentime = txt_time.Text
            dao.update()
            Run_Service(Request.QueryString("IDA"))
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');", True)
        Catch ex As Exception

        End Try
        KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขเวลาทำการ", _CLS.CITIZEN_ID)

    End Sub

    Private Sub btn_appdate_Click(sender As Object, e As EventArgs) Handles btn_appdate.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
            dao.fields.appdate = CDate(txt_appdate.Text)
            dao.update()

            Run_Service(Request.QueryString("IDA"))
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');", True)
        Catch ex As Exception

        End Try
        KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขวันที่ให้ไว้ ณ", _CLS.CITIZEN_ID)
    End Sub

    Private Sub btn_expyear_Click(sender As Object, e As EventArgs) Handles btn_expyear.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim expyear As Integer = 0
        Try
            expyear = Trim(txt_expyear.Text)
        Catch ex As Exception

        End Try
        Try
            If expyear <> 0 Then
                dao.GetDataby_IDA(Request.QueryString("ida"))
                If expyear < 2500 Then
                    dao.fields.expyear = expyear + 543
                Else
                    dao.fields.expyear = expyear
                End If
                dao.update()
                Run_Service(Request.QueryString("IDA"))
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูล');", True)
            End If

        Catch ex As Exception

        End Try

        KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขปีหมดอายุ", _CLS.CITIZEN_ID)
    End Sub

    Protected Sub btn_template_Click(sender As Object, e As EventArgs) Handles btn_template.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Dim ccc As String = ""
        Try
            dao.GetDataby_IDA(Request.QueryString("ida"))
            dao.fields.TEMPLATE_ID = ddl_template.SelectedValue
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('แก้ไขเรียบร้อย');", True)
        Catch ex As Exception

        End Try
        KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไข Template เลขที่บ้านใน pdf", _CLS.CITIZEN_ID)
    End Sub

    Protected Sub btn_CATEGORY_DRUG_Click(sender As Object, e As EventArgs) Handles btn_CATEGORY_DRUG.Click
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            dao.fields.CATEGORY_DRUG = txt_CATEGORY_DRUG.Text
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_upload_img_Click(sender As Object, e As EventArgs) Handles btn_upload_img.Click
        If FileUpload1.HasFile Then
            Dim file_ex As String = ""
            file_ex = file_extension_nm(FileUpload1.FileName)
            If file_ex = "jpg" Or file_ex = "png" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                dao.fields.IMAGE_BSN = Convert.ToBase64String(FileUpload1.FileBytes)
                dao.update()
                RadBinaryImage1.DataBind()

                KEEP_LOGS_EDIT(Request.QueryString("ida"), "อัพโหลดรูป", _CLS.CITIZEN_ID)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไฟล์ไม่ถูกต้อง ควรใช้ไฟล์นามสกุล .jpg หรือ .png');", True)
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
        End If
    End Sub

    Private Sub btn_save_ky1_Click(sender As Object, e As EventArgs) Handles btn_save_ky1.Click
        Dim i As Integer = 0
        For Each item As ListItem In cbl_chk_sell_type_ky1.Items
            If item.Selected Then
                i += 1
            End If
        Next

        If i > 0 Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            dao.fields.CHK_SELL_TYPE = ""
            dao.fields.CHK_SELL_TYPE1 = ""
            dao.fields.CHK_SELL_TYPE2 = ""
            dao.update()

            For Each item As ListItem In cbl_chk_sell_type_ky1.Items
                If item.Selected Then
                    Dim dao2 As New DAO_DRUG.ClsDBdalcn
                    dao2.GetDataby_IDA(Request.QueryString("IDA"))
                    If item.Text = "ขายปลีก" Then
                        dao2.fields.CHK_SELL_TYPE = "1"
                    ElseIf item.Text = "ขายส่ง" Then
                        dao2.fields.CHK_SELL_TYPE1 = "1"
                    ElseIf item.Text = "ปรุงยาสำหรับผู้ป่วยเฉพาะราย" Then
                        dao2.fields.CHK_SELL_TYPE2 = "1"
                    End If

                    KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขประเภทการขาย " & item.Text, _CLS.CITIZEN_ID)

                    dao2.update()
                End If

            Next


            Dim ii As Integer = 0
            For Each item As ListItem In cbl_chk_sell_type_ky1.Items
                If item.Value = "2" Then
                    ii += 1
                End If
            Next
            If ii > 0 Then
                Dim dao22 As New DAO_DRUG.TB_DALCN_SELL_TYPE
                dao22.GetDataby_FK_IDA(Request.QueryString("IDA"))
                For Each dao22.fields In dao22.datas
                    dao22.delete()
                Next

                For Each item As ListItem In cbl_chk_sell_type_ky1_2.Items
                    If item.Selected Then
                        Dim dao3 As New DAO_DRUG.TB_DALCN_SELL_TYPE
                        dao3.fields.FK_IDA = Request.QueryString("IDA")
                        dao3.fields.SELL_TYPE = item.Value
                        dao3.insert()
                    End If

                Next
            End If

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกประเภทขายส่ง');", True)

        End If
    End Sub

    Private Sub btn_save_ky4_Click(sender As Object, e As EventArgs) Handles btn_save_ky4.Click
        Dim i As Integer = 0
        For Each item As ListItem In cbl_chk_sell_type_ky4.Items
            If item.Selected Then
                i += 1
            End If
        Next

        If i > 0 Then
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            dao.fields.CHK_SELL_TYPE = ""
            dao.fields.CHK_SELL_TYPE1 = ""
            dao.fields.CHK_SELL_TYPE2 = ""
            dao.update()
            For Each item As ListItem In cbl_chk_sell_type_ky4.Items
                If item.Selected Then
                    Dim dao2 As New DAO_DRUG.ClsDBdalcn
                    dao2.GetDataby_IDA(Request.QueryString("IDA"))
                    If item.Text = "ขายส่งยาสำเร็จรูป" Then
                        dao2.fields.CHK_SELL_TYPE = "13"
                    ElseIf item.Text = "ขายส่งเภสัชเคมีภัณฑ์" Then
                        dao2.fields.CHK_SELL_TYPE1 = "12"
                    End If
                    KEEP_LOGS_EDIT(Request.QueryString("ida"), "แก้ไขประเภทการขายส่ง " & item.Text, _CLS.CITIZEN_ID)
                    dao2.update()
                End If

            Next
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกประเภทขายส่ง');", True)

        End If
    End Sub

    Private Sub cbl_chk_sell_type_ky1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbl_chk_sell_type_ky1.SelectedIndexChanged
        bind_selltype()
    End Sub
    Sub bind_selltype()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        If dao.fields.PROCESS_ID = "101" And cbl_chk_sell_type_ky1.SelectedValue = "2" Then
            cbl_chk_sell_type_ky1_2.Style.Add("display", "block")
        Else
            cbl_chk_sell_type_ky1_2.Style.Add("display", "none")
        End If

    End Sub

    Protected Sub btn_upload_img2_Click(sender As Object, e As EventArgs) Handles btn_upload_img2.Click
        If FileUpload2.HasFile Then
            Dim file_ex As String = ""
            file_ex = file_extension_nm(FileUpload2.FileName)
            If file_ex = "jpg" Or file_ex = "png" Then
                Dim dao As New DAO_DRUG.ClsDBdalcn
                dao.GetDataby_IDA(Request.QueryString("IDA"))
                dao.fields.IMAGE_KEEP = Convert.ToBase64String(FileUpload2.FileBytes)
                dao.update()
                RadBinaryImage2.DataBind()

                KEEP_LOGS_EDIT(Request.QueryString("ida"), "อัพโหลดรูป", _CLS.CITIZEN_ID)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไฟล์ไม่ถูกต้อง ควรใช้ไฟล์นามสกุล .jpg หรือ .png');", True)
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
        End If
    End Sub
End Class