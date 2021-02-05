Public Class FRM_STAFF_LCN_ADD_LOCATION_KEEP
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
            set_ddl_place()
            set_data()
        End If
    End Sub
    Private Sub ddl_placename_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_placename.SelectedIndexChanged
        set_data()
    End Sub
    Sub set_data()
        hf_place.Value = ddl_placename.SelectedValue
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        Try
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(ddl_placename.SelectedValue)
        Catch ex As Exception

        End Try
        Try
            For Each dr As DataRow In dt.Rows
                lbl_location_new.Text = dr("fulladdr")
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub set_ddl_place()
        Dim iden As String = ""
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("ida"))
        Try
            iden = dao.fields.CITIZEN_ID_AUTHORIZE
        Catch ex As Exception

        End Try
        Dim dt As New DataTable
        Dim bao As New BAO_SHOW
        If Request.QueryString("t") = "2" Then
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2(2, iden)
        ElseIf Request.QueryString("t") = "1" Then
            dt = bao.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSIDV2_1(1, iden)
        End If

        ddl_placename.DataSource = dt
        ddl_placename.DataValueField = "IDA"
        ddl_placename.DataTextField = "thanameplace"
        ddl_placename.DataBind()

        Dim item As New ListItem("", "")
        ddl_placename.Items.Insert(0, item)
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("t") = "2" Then
            Try
                'Dim dao_keep As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                'dao_keep.GetData_by_LCN_IDA(Request.QueryString("ida"))
                'If dao_keep.fields.IDA <> 0 Then
                '    dao_keep.delete()
                'End If
                Dim _IDA_lo As String = ""
                Try
                    _IDA_lo = ddl_placename.SelectedValue
                Catch ex As Exception

                End Try
                If _IDA_lo = "0" Then
                    _IDA_lo = "89791"
                ElseIf _IDA_lo = "" Then
                    _IDA_lo = "0"
                End If
                If ddl_placename.Items.Count > 0 Then
                    Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                    Dim dao_LOCATION_ADDRESS_2 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                    dao_LOCATION_ADDRESS_2.GetDataby_IDA(_IDA_lo)
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = _CLS.CITIZEN_ID

                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.TR_ID = 0
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.FK_IDA = Request.QueryString("ida")
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LCN_IDA = Request.QueryString("ida")
                    Catch ex As Exception

                    End Try

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thanameplace
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                    If _IDA_lo = "0" Or _IDA_lo = "" Then
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = "ไม่มีสถานที่เก็บ"
                    Else
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = dao_LOCATION_ADDRESS_2.fields.thanameplace
                    End If

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lcnsid = dao_LOCATION_ADDRESS_2.fields.lcnsid
                    Catch ex As Exception

                    End Try

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engaddr = dao_LOCATION_ADDRESS_2.fields.engaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = dao_LOCATION_ADDRESS_2.fields.tharoom
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = dao_LOCATION_ADDRESS_2.fields.thabuilding
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engsoi = dao_LOCATION_ADDRESS_2.fields.engsoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engroad = dao_LOCATION_ADDRESS_2.fields.engroad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = dao_LOCATION_ADDRESS_2.fields.zipcode
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lstfcd = dao_LOCATION_ADDRESS_2.fields.lstfcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lmdfdate = dao_LOCATION_ADDRESS_2.fields.lmdfdate
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDA = dao_LOCATION_ADDRESS_2.fields.IDA
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_FK_IDA = dao_LOCATION_ADDRESS_2.fields.FK_IDA
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_TR_ID = dao_LOCATION_ADDRESS_2.fields.TR_ID
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_DOWN_ID = dao_LOCATION_ADDRESS_2.fields.DOWN_ID
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID_UPLOAD
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_XMLNAME = dao_LOCATION_ADDRESS_2.fields.XMLNAME
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engmu = dao_LOCATION_ADDRESS_2.fields.engmu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engfloor = dao_LOCATION_ADDRESS_2.fields.engfloor
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engbuilding = dao_LOCATION_ADDRESS_2.fields.engbuilding
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvno = dao_LOCATION_ADDRESS_2.fields.rcvno
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvdate = dao_LOCATION_ADDRESS_2.fields.rcvdate
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lctcd = dao_LOCATION_ADDRESS_2.fields.lctcd
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_STATUS_ID = dao_LOCATION_ADDRESS_2.fields.STATUS_ID
                    Catch ex As Exception

                    End Try


                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engnameplace = dao_LOCATION_ADDRESS_2.fields.engnameplace

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_HOUSENO = dao_LOCATION_ADDRESS_2.fields.HOUSENO
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_NORMAL
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_OTHER
                    Catch ex As Exception

                    End Try

                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thmblcd = dao_LOCATION_ADDRESS_2.fields.thmblcd
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_LOCATION_ADDRESS_2.fields.SYSTEM_NAME
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engthmblnm = dao_LOCATION_ADDRESS_2.fields.engthmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engamphrnm = dao_LOCATION_ADDRESS_2.fields.engamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engchngwtnm = dao_LOCATION_ADDRESS_2.fields.engchngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDENTIFY = dao_LOCATION_ADDRESS_2.fields.IDENTIFY
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_REMARK = dao_LOCATION_ADDRESS_2.fields.REMARK
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = dao_LOCATION_ADDRESS_2.fields.Mobile
                    dao_DALCN_DETAIL_LOCATION_KEEP.insert()

                    KEEP_LOGS_EDIT(Request.QueryString("ida"), "เพิ่มสถานที่เก็บใหม่", _CLS.CITIZEN_ID)
                    Dim ws_update As New WS_DRUG.WS_DRUG
                    ws_update.DRUG_UPDATE_LICEN(Request.QueryString("ida"), _CLS.CITIZEN_ID)
                    Dim ws_update126 As New WS_DRUG_126.WS_DRUG
                    ws_update126.DRUG_UPDATE_LICEN_126(Request.QueryString("ida"), _CLS.CITIZEN_ID)


                    Response.Write("<script type='text/javascript'>window.parent.alert('บันทึกข้อมูลเรียบร้อยแล้ว');parent.close_modal();</script> ")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class