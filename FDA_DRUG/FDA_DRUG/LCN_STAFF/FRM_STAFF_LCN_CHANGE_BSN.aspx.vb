Public Class FRM_STAFF_LCN_CHANGE_BSN
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunQuery()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            bind_old_name()
            set_bsn_location_old()
        End If
    End Sub
    Public Sub bind_old_name()
        Dim dao As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            dao.GetDataby_LCN_IDA(Request.QueryString("ida"))
            lbl_old_bsn.Text = dao.fields.BSN_THAIFULLNAME
        Catch ex As Exception

        End Try

    End Sub
    Sub set_bsn_location_old()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("ida"))
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        Try
            'dao_bsn.Getdata_by_fk_id2(dao.fields.FK_IDA)
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_BSN_LOCATION_ADDRESS_BY_IDA_V2(Request.QueryString("ida"))

            For Each dr As DataRow In dt.Rows
                lbl_old_addr.Text = dr("fulladdr")
            Next
        Catch ex As Exception

        End Try

        'Try
        '    dao_bsn.Getdata_by_iden()
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim CITIZEN_ID_AUTHORIZE As String = ""
        Try
            CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
        Catch ex As Exception

        End Try

        Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1
        Dim ws_taxno = ws2.getProfile_byidentify(CITIZEN_ID_AUTHORIZE)

        Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        dao_syslcnsid.GetDataby_identify(CITIZEN_ID_AUTHORIZE)
        If dao_syslcnsid.fields.IDA = 0 Then
            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        Else
            Try
                lbl_new_bsn.Text = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm
            Catch ex As Exception

            End Try

            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("ida"))
            Dim dao_bsn As New DAO_CPN.TB_LOCATION_BSN
            Try
                'dao_bsn.Getdata_by_fk_id2(dao.fields.FK_IDA)
                Dim bao As New BAO.ClsDBSqlcommand
                Dim dt As New DataTable
                dt = bao.SP_BSN_LOCATION_ADDRESS_BY_IDEN_V2(CITIZEN_ID_AUTHORIZE)

                For Each dr As DataRow In dt.Rows
                    lbl_new_addr.Text = dr("fulladdr")
                Next
            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Sub set_data_dalcn(ByRef dao As DAO_DRUG.ClsDBdalcn)
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            dao_bsn.Getdata_by_iden(txt_ctzid.Text)
            For Each dao_bsn.fields In dao_bsn.datas
                dao.fields.BSN_IDENTIFY = txt_ctzid.Text
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
                    CITIZEN_ID_AUTHORIZE = txt_ctzid.Text
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

    Sub update_bsn(ByVal bsn_iden As String, ByVal lcn_ida As Integer)
        Dim bao_show11 As New BAO_SHOW
        Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(bsn_iden)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        dao_bsn.GetDataby_LCN_IDA(lcn_ida)
        For Each dr As DataRow In dt_bsn.Rows

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
                dao_bsn.fields.BSN_CHWNGNAME = dr("thachngwtnm")
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
        Next
    End Sub
    Sub insert_bsn(ByVal bsn_iden As String, ByVal lcn_ida As Integer)
        Dim bao_show11 As New BAO_SHOW
        Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(bsn_iden)
        Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
        'dao_bsn.GetDataby_LCN_IDA(lcn_ida)
        For Each dr As DataRow In dt_bsn.Rows

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
                dao_bsn.fields.BSN_CHWNGNAME = dr("thachngwtnm")
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
            dao_bsn.fields.LCN_IDA = Request.QueryString("IDA")
            dao_bsn.insert()
        Next
    End Sub
    Protected Sub btn_c_bsn_Click(sender As Object, e As EventArgs) Handles btn_c_bsn.Click
        'Dim ws1 As New WS_Taxno_TaxnoAuthorize.WebService1
        'Dim a As String = ""
        'Try
        '    a = ws1.insert_taxno(txt_ctzid.Text)
        'Catch ex As Exception

        'End Try
        'Try
        '    a = ws1.insert_taxno_authorize(txt_ctzid.Text)
        'Catch ex As Exception

        'End Try

        'Try
        '    Dim ws2 As New WS_FDA_CITIZEN.WS_FDA_CITIZEN
        '    ws2.FDA_CITIZEN(txt_ctzid.Text, "1102001745831", "fusion", "P@ssw0rdfusion440")
        'Catch ex As Exception

        'End Try

        'Dim ws3 As New WS_TRADERS.WS_TRADER
        'ws3.CallWS_TRADER("fusion", "P@ssw0rdfusion440", txt_ctzid.Text)



        Dim bao_show11 As New BAO_SHOW
        Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(txt_ctzid.Text)
        If dt_bsn.Rows.Count > 0 Then

            'insert_bsn
            Dim i As Integer = 0
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN

            Try
                i = dao_bsn.COUNT_LCN_IDA(Request.QueryString("ida"))
            Catch ex As Exception

            End Try
            Try
                If i = 0 Then
                    insert_bsn(txt_ctzid.Text, Request.QueryString("ida"))
                Else
                    update_bsn(txt_ctzid.Text, Request.QueryString("ida"))
                End If
            Catch ex As Exception

            End Try


            'update_bsn(txt_ctzid.Text, Request.QueryString("ida"))
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_IDA(Request.QueryString("ida"))
            set_data_dalcn(dao_dalcn)
            dao_dalcn.update()
            KEEP_LOGS_EDIT(Request.QueryString("ida"), "เปลี่ยนผู้ดำเนินกิจการ", _CLS.CITIZEN_ID)
            Dim ws_update As New WS_DRUG.WS_DRUG
            ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เปลี่ยนผู้ดำเนินกิจการเรียบร้อยแล้ว');parent.close_modal();", True)
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่สามารถเปลี่ยนข้อมูลได้ เนื่องจากไม่พบข้อมูลผู้ดำเนินคนใหม่');parent.close_modal();", True)
        End If
    End Sub
End Class