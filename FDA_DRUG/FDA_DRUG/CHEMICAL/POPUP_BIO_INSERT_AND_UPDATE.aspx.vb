Public Class POPUP_BIO_INSERT_AND_UPDATE
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            UC_BIO_CHEM1.set_lbl_bio_type(Request.QueryString("b"))
            If Request.QueryString("ida") <> "" Then
                Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
                dao.GetDataby_IDA(Request.QueryString("ida"))
                UC_BIO_CHEM1.get_data(dao)
            End If
        End If
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then 'นำค่า Session ใส่ ในตัวแปร _CLS
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/") 'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao As New DAO_DRUG.TB_CHEMICAL_REQUEST
        If Request.QueryString("ida") = "" Then
            UC_BIO_CHEM1.set_data(dao)
            dao.fields.aori = Request.QueryString("t")
            'dao.fields.G_TYPE = Request.QueryString("g")
            dao.fields.MAIN_TYPE = Request.QueryString("mt")
            dao.fields.SUB_TYPE = Request.QueryString("st")
            dao.fields.PROCESS_ID = Request.QueryString("process")
            dao.fields.BIO_TYPE = Request.QueryString("b")
            dao.fields.STATUS_ID = 1

            Try
                dao.fields.IDENTIFY = _CLS.CITIZEN_ID
            Catch ex As Exception

            End Try
            Try
                dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            Catch ex As Exception

            End Try
            dao.insert()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');parent.close_modal();", True)
        Else
            dao.GetDataby_IDA(Request.QueryString("ida"))
            UC_BIO_CHEM1.set_data(dao)
            dao.update()
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกข้อมูลเรียบร้อย');parent.close_modal();", True)

        End If

        'Dim ida As Integer = 0
        'Try
        '    UC_BIO_CHEM1.insert_det(ida)
        'Catch ex As Exception
        'End Try
    End Sub
End Class