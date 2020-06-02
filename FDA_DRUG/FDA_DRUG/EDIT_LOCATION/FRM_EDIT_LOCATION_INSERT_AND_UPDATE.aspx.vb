Public Class FRM_EDIT_LOCATION_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page
    Private _lct_ida As String = ""
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")                               'นำค่า Session ใส่ ในตัวแปร _CLS         'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            load_ddl()
            txt_WRITE_DATE.Text = Date.Now.ToShortDateString()
            Dim dao As New DAO_DRUG.TB_lcnrequest
            If Request.QueryString("ida") <> "" Then
                btn_save.Text = "แก้ไข"
                dao.GetDataby_IDA(Request.QueryString("ida"))
                get_data(dao)
            Else
                btn_save.Text = "บันทึก"
            End If
        End If
    End Sub
    Private Sub load_ddl()
        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataEditby_IDEN(_CLS.CITIZEN_ID_AUTHORIZE)
        ddl_lcnno.DataSource = dao.datas
        ddl_lcnno.DataTextField = "LCNNO_DISPLAY"
        ddl_lcnno.DataValueField = "IDA"
        ddl_lcnno.DataBind()
        Dim item As New ListItem
        item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        item.Value = "0"
        ddl_lcnno.Items.Insert(0, item)
        '    dao.GetDataby_FK_IDA_and_PROCESS_ID_4(_lct_ida, 101, 102, 103, 104)
        'ddl_lcnno.DataSource = dao.datas
        'ddl_lcnno.DataTextField = "LCNNO_DISPLAY"
        'ddl_lcnno.DataValueField = "IDA"
        'ddl_lcnno.DataBind()
        '    Dim item As New ListItem
        '    item.Text = "กรุณาเลือกเลขที่ใบอนุญาต"
        '    item.Value = "0"
        'ddl_lcnno.Items.Insert(0, item)
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_lcnrequest
        If ddl_lcnno.SelectedValue <> "0" Then
            If Request.QueryString("ida") <> "" Then
                dao.GetDataby_IDA(Request.QueryString("ida"))
                set_data(dao)
                dao.fields.PROCESS_ID = 50
                dao.update()
                alert("แก้ไขข้อมูลเรียบร้อยแล้ว")
            Else
                set_data(dao)
                dao.fields.LOCATION_ADDRESS_IDA = _lct_ida
                dao.fields.STATUS_ID = 1
                dao.insert()
                alert("บันทึกข้อมูลเรียบร้อยแล้ว")
            End If
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกใบอนุญาต');", True)

        End If
        
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Sub set_data(ByRef dao As DAO_DRUG.TB_lcnrequest)
        dao.fields.REMARK = txt_REMARK.Text
        dao.fields.WRITE_AT = txt_WRITE_AT.Text
        Try
            dao.fields.WRITE_DATE = CDate(txt_WRITE_DATE.Text)
        Catch ex As Exception

        End Try
        dao.fields.FK_IDA = ddl_lcnno.SelectedValue
        dao.fields.RQT_TYPE = RadioButtonList1.SelectedValue
        dao.fields.LCN_TYPE = 1
        dao.fields.REQUEST_TYPE = 1
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_lcnrequest)
        txt_REMARK.Text = dao.fields.REMARK
        txt_WRITE_AT.Text = dao.fields.WRITE_AT
        Try
            txt_WRITE_DATE.Text = CDate(dao.fields.WRITE_DATE)
        Catch ex As Exception

        End Try
        Try
            ddl_lcnno.DropDownSelectData(dao.fields.FK_IDA)
        Catch ex As Exception

        End Try

        RadioButtonList1.DataBind()
        RadioButtonList1.SelectedValue = dao.fields.RQT_TYPE

    End Sub
End Class