Public Class FRM_RGT_EDIT_CONSIDER
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("https://privus.fda.moph.go.th/")
        Else
            _TR_ID = Request.QueryString("TR_ID")
            _IDA = Request.QueryString("IDA")
            _CLS = Session("CLS")
            ' _type = "1"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        If Not IsPostBack Then
            TextBox1.Text = Date.Now.ToShortDateString()
            txt_app_date.Text = Date.Now.ToShortDateString()
            default_Remark()
            Bind_ddl_staff_offer()
        End If
    End Sub

    Private Sub default_Remark()
        'Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD

        'dao.GetDatabyIDA(_IDA)
        'If Len(_TR_ID) >= 9 Then
        '    dao_up.GetDataby_TR_ID_Process(_TR_ID, dao.fields.PROCESS_ID)
        'Else
        '    dao_up.GetDataby_IDA(_TR_ID)
        'End If

        'Dim PROCESS_ID As Integer = dao.fields.PROCESS_ID
        'Dim GROUP_TYPE As String = dao.fields.GROUP_TYPE
        'If PROCESS_ID = 14200053 And GROUP_TYPE = "2" Then
        '    Txt_Remark.Text = ""
        'End If



    End Sub
    Public Sub Bind_ddl_staff_offer()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'bao.SP_STAFF_OFFER_DDL()
        bao.SP_STAFF_OFFER_DDL_BY_PVNCD(_CLS.PVCODE)

        'ddl_staff_offer.DataSource = bao.dt
        'ddl_staff_offer.DataBind()

        rcb_staff_offer.DataSource = bao.dt
        rcb_staff_offer.DataBind()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Len(txt_position.Text) = 0 Then
                Response.Write("<script type='text/javascript'>alert('กรุณากรอกตำแหน่ง');</script> ")
            Else
                Dim dao As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                Dim bao As New BAO.GenNumber

                dao.GetDatabyIDA(_IDA)
                If Len(_TR_ID) >= 9 Then
                    dao_up.GetDataby_TR_ID_Process(_TR_ID, dao.fields.PROCESS_ID)
                Else
                    dao_up.GetDataby_IDA(_TR_ID)
                End If

                AddLogStatus(6, dao.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)

                Dim PROCESS_ID As String = dao.fields.PROCESS_ID

                'Dim dao_p As New DAO_DRUG.ClsDBPROCESS_NAME
                'dao_p.GetDataby_PROCESS_ID(PROCESS_ID)
                Dim GROUP_NUMBER As String = dao.fields.PROCESS_ID

                Dim CONSIDER_DATE As Date = CDate(TextBox1.Text)

                '--------------------------------

                dao.fields.REMARK = Txt_Remark.Text
                dao.fields.STATUS_ID = 14
                dao.fields.CONSIDER_DATE = CONSIDER_DATE
                dao.fields.SIGN_POSITION = txt_position.Text
                dao.fields.CHK_ATTACH1 = rcb_staff_offer.SelectedValue
                Try
                    dao.fields.CONSIDER_DATE = CDate(txt_app_date.Text)
                Catch ex As Exception

                End Try

                dao.update()

                'Dim cls_sop As New CLS_SOP
                'cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", PROCESS_ID, _CLS.PVCODE, 6, "เสนอลงนาม", "SOP-DRUG-10-" & PROCESS_ID & "-3", "อนุมัติ", "รอเจ้าหน้าที่อนุมัติคำขอ", "STAFF", _TR_ID, SOP_STATUS:="เสนอลงนาม")
                alert("บันทึกข้อมูลเรียบร้อย")
            End If

        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")

        End Try

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_LCN_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class