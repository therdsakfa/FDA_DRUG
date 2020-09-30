Public Class POPUP_LCN_NCT_TEMP_INSERT
    Inherits System.Web.UI.Page
    Dim _pvncd As Integer = 0
    Private _CLS As New CLS_SESSION
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
            set_lbl()
            bind_ddl()
        End If
    End Sub
    Sub bind_ddl()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        Dim group_id As Integer = 0
        Dim lcntpcd As String = ""
        lcntpcd = dao.fields.lcntpcd

        If lcntpcd.Contains("ขย") Then
            group_id = 1
        ElseIf lcntpcd.Contains("ผย") Then
            group_id = 2
        ElseIf lcntpcd.Contains("นย") Then
            group_id = 3
        End If

        Dim dao_dd As New DAO_DRUG.TB_DDL_VORJOR
        dao_dd.Getdata_by_group(group_id)
        ddl_lcntpcd.DataSource = dao_dd.datas
        ddl_lcntpcd.DataValueField = "IDA"
        ddl_lcntpcd.DataTextField = "PROCESS_DESCRIPTION"
        ddl_lcntpcd.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_lcntpcd.Items.Insert(0, item)
    End Sub

    Sub set_lbl()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(Request.QueryString("IDA"))
        Try
            Dim lcnno_auto As String = dao.fields.lcnno
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lbl_main_lcnno.Text = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lbl_main_lcnno.Text = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If ddl_lcntpcd.SelectedValue <> "0" Then
            If txt_LCNNO_FORMAT.Text <> "" Then
                If chk_lcnno_repeat() = True Then
                    insert_data()
                    alert("บันทึกเรียบร้อย")
                Else
                    Response.Write("<script type='text/javascript'>window.parent.alert('เลขใบอนุญาตซ้ำ');</script> ")
                End If
            Else
                Response.Write("<script type='text/javascript'>window.parent.alert('กรุณากรอกประเภทใบอนุญาต');</script> ")
            End If
        Else
            Response.Write("<script type='text/javascript'>window.parent.alert('กรุณาเลือกประเภทใบอนุญาต');</script> ")
        End If

    End Sub
    Function chk_lcnno_repeat()
        Dim chk As Boolean = False
        Dim pvncd As Integer = 0
        Dim lcnno As String = ""
        Dim lcntpcd As String = ""

        Try
            Dim dao_dd As New DAO_DRUG.TB_DDL_VORJOR
            dao_dd.Getdata_by_ID(ddl_lcntpcd.SelectedValue)
            lcntpcd = dao_dd.fields.PROCESS_NAME
        Catch ex As Exception

        End Try
        Try
            lcnno = get_lcnno()
        Catch ex As Exception

        End Try
        Try
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try

                'chw = dao_cpn.fields.thacwabbr
                chw = Left(Trim(txt_LCNNO_FORMAT.Text), 2)
                dao_cpn.GetData_by_thacwabbr(chw)
                pvncd = dao_cpn.fields.chngwtcd
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
        Dim i As Integer = 0
        Try
            Dim dao_vj As New DAO_DRUG.TB_TEMP_NCT_DALCN
            i = dao_vj.Getdata_by_LCNNO_LCNTPCD_pvncd(lcnno, lcntpcd, pvncd)
            If i = 0 Then
                chk = True
            End If
        Catch ex As Exception

        End Try

        Return chk
    End Function
    Sub insert_data()
        Dim TR_ID As String = ""
        Dim bao_tran As New BAO_TRANSECTION
        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE



        Dim dao_t As New DAO_DRUG.TB_TEMP_NCT_DALCN
        With dao_t.fields
            .APPROVE_NAME = txt_APPROVE_NAME.Text
            .APPROVE_POSITION = txt_APPROVE_POSITION.Text
            .BSN_IDENTIFY = txt_BSN_IDENTIFY.Text
            .BSN_NAME = txt_BSN_NAME.Text
            .CONDITION = txt_CONDITION.Text
            .DATE_DAY = txt_DATE_DAY.Text
            .DATE_END = txt_DATE_END.Text
            .DATE_MONTH = txt_DATE_MONTH.Text
            .DATE_START = txt_DATE_START.Text
            .DATE_YEAR = txt_DATE_YEAR.Text
            .IDENTIFY = txt_IDENTIFY.Text
            .KEEP_TEL = txt_KEEP_TEL.Text
            .LCNNO_FORMAT = txt_LCNNO_FORMAT.Text
            Dim dao As New DAO_DRUG.ClsDBdalcn
            dao.GetDataby_IDA(Request.QueryString("IDA"))
            Try
                Dim dao_dd As New DAO_DRUG.TB_DDL_VORJOR
                dao_dd.Getdata_by_ID(ddl_lcntpcd.SelectedValue)
                .PROCESS_ID = dao_dd.fields.PROCESS_ID
                .LCNTPCD = dao_dd.fields.PROCESS_NAME
                TR_ID = bao_tran.insert_transection_new(dao_dd.fields.PROCESS_ID)
                .TR_ID = TR_ID
            Catch ex As Exception

            End Try
            Try

            Catch ex As Exception

            End Try
            .DRUG_GROUP = txt_DRUG_GROUP.Text
            .LICEN_NAME = txt_LICEN_NAME.Text
            .LOCATION_ADDR = txt_LOCATION_ADDR.Text
            .LOCATION_KEEP_NAME = txt_LOCATION_KEEP_NAME.Text
            .LOCATION_KRRP_ADDR = txt_LOCATION_KRRP_ADDR.Text
            .LOCATION_NAME = txt_LOCATION_NAME.Text
            .MAIN_IDA = Request.QueryString("IDA")
            .LCNNO = get_lcnno()
            .MAIN_LCNNO_FORMAT = lbl_main_lcnno.Text
            .PHR_NAME1 = txt_PHR_NAME1.Text
            .PHR_NAME2 = txt_PHR_NAME2.Text
            .PHR_NAME3 = txt_PHR_NAME3.Text
            .PHR_NUMBER1 = txt_PHR_NUMBER1.Text
            .PHR_NUMBER2 = txt_PHR_NUMBER2.Text
            .PHR_NUMBER3 = txt_PHR_NUMBER3.Text
            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try

                'chw = dao_cpn.fields.thacwabbr
                chw = Left(txt_LCNNO_FORMAT.Text, 2)
                dao_cpn.GetData_by_thacwabbr(chw)
                .PVNCD = dao_cpn.fields.chngwtcd
            Catch ex As Exception

            End Try
            .PVNABBR = chw

            .STATUS_ID = 1
            .TEL = txt_TEL.Text
            .KEEP_TEL = txt_KEEP_TEL.Text
        End With
        dao_t.insert()
    End Sub
    Function get_lcnno() As String
        'Dim aaaa As String = ""
        'Dim nonono As String = "กท 2/2550"
        'Dim sp_1st As String() = nonono.Split(" ")
        'Dim sp_2st As String() = sp_1st(1).Split("/")
        'aaaa = sp_2st(0)



        Dim lcnno As String = ""
        Dim arr_feeno1 As String() = Nothing
        Dim arr_feeno2 As String() = Nothing
        Try
            arr_feeno1 = txt_LCNNO_FORMAT.Text.Split(" ")
            arr_feeno2 = arr_feeno1(1).Split("/")

            If Len(arr_feeno2(0)) < 5 Then
                Try
                    arr_feeno2(0) = String.Format("{0:00000}", CInt(arr_feeno2(0)))
                Catch ex As Exception

                End Try

            End If

            lcnno = Right(Trim(txt_LCNNO_FORMAT.Text), 2) & arr_feeno2(0)
        Catch ex As Exception

        End Try
        Return lcnno
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.Groups)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
End Class