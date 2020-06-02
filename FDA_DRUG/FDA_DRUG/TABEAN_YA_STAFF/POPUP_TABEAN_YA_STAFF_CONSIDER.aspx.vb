Public Class POPUP_TABEAN_YA_STAFF_CONSIDER
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        If Session("CLS") Is Nothing Then
            Response.Redirect("http://privus.fda.moph.go.th/")
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
            bind_ddl_rgttpcd()
            bind_tabean_group()
            TextBox1.Text = Date.Now.ToShortDateString()
            'txt_app_date.Text = Date.Now.ToShortDateString()
            default_Remark()
            'Bind_ddl_staff_offer()

            Try
                Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
                dao_rqt.GetDataby_IDA(_IDA)
                ddl_rgttpcd.DropDownSelectData(dao_rqt.fields.rgttpcd)
                ddl_tabean_group.DropDownSelectData(dao_rqt.fields.drgtpcd)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub default_Remark()
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD

        'dao.GetDataby_IDA(_IDA)
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)

        'Dim PROCESS_ID As Integer = dao_up.fields.PROCESS_ID
        'Dim GROUP_TYPE As String = dao.fields.GROUP_TYPE
        'If PROCESS_ID = 14200053 And GROUP_TYPE = "2" Then
        '    Txt_Remark.Text = ""
        'End If



    End Sub
    'Public Sub Bind_ddl_staff_offer()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    Dim dt As New DataTable
    '    bao.SP_STAFF_OFFER_DDL()

    '    ddl_staff_offer.DataSource = bao.dt
    '    ddl_staff_offer.DataBind()
    'End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If CHK_FORMAT_RCVNO(Txt_rcvno_no.Text) = True Then

                Dim dao As New DAO_DRUG.ClsDBdrrqt
                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                Dim bao As New BAO.GenNumber

                dao.GetDataby_IDA(_IDA)
                dao_up.GetDataby_IDA(dao.fields.TR_ID)


                Dim bao2 As New BAO.GenNumber
                Dim RGTNO As Integer

                RGTNO = GET_FORMAT_RCVNO(Txt_rcvno_no.Text)

                If CHK_REPEAT(RGTNO, ddl_rgttpcd.SelectedValue, ddl_tabean_group.SelectedValue, dao.fields.pvncd) = True Then

                    Dim CONSIDER_DATE As Date = CDate(TextBox1.Text)
                    dao.fields.REMARK = Txt_Remark.Text
                    dao.fields.rgttpcd = ddl_rgttpcd.SelectedValue
                    dao.fields.drgtpcd = ddl_tabean_group.SelectedValue
                    dao.fields.STATUS_ID = 14
                    dao.fields.rgtno = RGTNO
                    dao.fields.CONSIDER_DATE = CONSIDER_DATE
                    AddLogStatus(14, dao_up.fields.PROCESS_ID, _CLS.CITIZEN_ID, _IDA)
                    dao.update()
                    alert("บันทึกข้อมูลเรียบร้อย")


                    Dim cls_sop As New CLS_SOP
                    cls_sop.BLOCK_STAFF(_CLS.CITIZEN_ID, "STAFF", dao_up.fields.PROCESS_ID, _CLS.PVCODE, 14, "เสนอผลการประเมิน", "SOP-DRUG-10-" & dao_up.fields.PROCESS_ID & "-12", "ชำระเงินค่าใบสำคัญฯ", "รอชำระเงินค่าใบสำคัญฯ", "STAFF", _TR_ID, SOP_STATUS:="เสนอผลการประเมิน")

                Else
                    alert_only("เลขทะเบียนซ้ำ")
                End If

            Else
                alert_only("กรอกเลขไม่ถูกต้อง")
            End If


        Catch ex As Exception
            Response.Write("<script type='text/javascript'>alert('ตรวจสอบการใส่วันที่');</script> ")
        End Try

    End Sub

    Function CHK_REPEAT(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal pvncd As String) As Boolean
        Dim bool As Boolean = False
        Try
            Dim i As Integer = 0
            Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
            i = dao_rqt.COUNT_REPEAT_RGTNO_PVNCD(rgtno, rgttpcd, drgtpcd, pvncd)
            'Dim max_rcvno As Integer = dao_rqt.fields.rgtno
            If i > 0 Then
                bool = False

            Else
                bool = True
            End If
        Catch ex As Exception

        End Try

        Return bool
    End Function
    'Function CHK_REPEAT(ByVal rcvno As Integer, ByVal rgttpcd As String, ByVal drgtpcd As String) As Boolean
    '    Dim bool As Boolean = False
    '    Try
    '        Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
    '        dao_rqt.GET_MAX_RGTNO(Left(rcvno, 2), rgttpcd, drgtpcd)
    '        Dim max_rcvno As Integer = dao_rqt.fields.rgtno
    '        If max_rcvno = rcvno Then
    '            bool = False

    '        Else
    '            bool = True
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Return bool
    'End Function
    Sub alert_only(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub alert_reload(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
        Response.Redirect("POPUP_DR_CONFIRM_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)

    End Sub
    Sub bind_tabean_group()
        Dim dao As New DAO_DRUG.ClsDBdrdrgtype
        dao.GetDataAll()
        ddl_tabean_group.DataSource = dao.datas
        ddl_tabean_group.DataTextField = "thadrgtpnm"
        ddl_tabean_group.DataValueField = "drgtpcd"
        ddl_tabean_group.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_tabean_group.Items.Insert(0, item)
    End Sub
    Sub bind_ddl_rgttpcd()
        Dim sql As String = ""
        sql = "select * from dbo.DRRGT_DRUG_GROUP "
        Dim dao_rqt As New DAO_DRUG.ClsDBdrrqt
        dao_rqt.GetDataby_IDA(_IDA)
        Dim grptpcd As Integer = 0
        Dim subtpcd As Integer = 0
        Dim fk_lcn_ida As Integer = 0
        Try
            fk_lcn_ida = dao_rqt.fields.FK_LCN_IDA
        Catch ex As Exception

        End Try
        Dim dao_da As New DAO_DRUG.ClsDBdalcn
        dao_da.GetDataby_IDA(fk_lcn_ida)
        Dim lcntpcd As String = ""
        Try
            lcntpcd = dao_da.fields.lcntpcd
        Catch ex As Exception

        End Try
        If lcntpcd.Contains("บ") Then
            grptpcd = 2
        Else
            grptpcd = 1
        End If
        If lcntpcd.Contains("นย") Then
            subtpcd = 3
        End If
        Dim sql_where As String = ""
        sql_where = " where grptpcd=" & grptpcd
        If subtpcd = 3 Then
            sql_where &= " and subtpcd = 3"
        Else
            sql_where &= " and subtpcd <> 3"
        End If

        sql &= sql_where
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.Queryds(sql)

        ddl_rgttpcd.DataSource = dt
        ddl_rgttpcd.DataTextField = "rgttpcd"
        ddl_rgttpcd.DataValueField = "rgttpcd"
        ddl_rgttpcd.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = ""
        ddl_rgttpcd.Items.Insert(0, item)
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("POPUP_DR_CONFIRM_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub

    Function CHK_FORMAT_RCVNO(ByVal txt As String) As Boolean
        Dim bool As Boolean = True
        Try
            Dim split_text As String() = txt.Split("/")
            Dim len_1 As Integer = 0
            Dim len_2 As Integer = 0
            len_1 = Len(split_text(0))
            len_2 = Len(split_text(1))

            If len_2 < 2 Then
                Return False
            End If
            If len_2 > 2 Then
                Return False
            End If
            If len_1 < 1 Then
                Return False
            End If


        Catch ex As Exception
            bool = False
        End Try


        Return bool
    End Function
    Function GET_FORMAT_RCVNO(ByVal txt As String) As Integer
        Dim rcvno As String = ""
        Dim running As Integer = 0
        Dim year_short As String = ""
        Dim split_text As String() = txt.Split("/")

        Try
            running = CInt(split_text(0))
            year_short = split_text(1)
            rcvno = String.Format("{0:00000}", running.ToString("00000"))
            rcvno = year_short & rcvno
        Catch ex As Exception

        End Try

        Return rcvno
    End Function
End Class