Public Class POPUP_LCN_LCT_HOSPITAL
    Inherits System.Web.UI.Page
    Private _IDA As String
    Private _TR_ID As String
    Private _type As String
    Private _CLS As New CLS_SESSION


    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            _IDA = Request.QueryString("IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _type = Request.QueryString("type")

        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            rbn_TREATMENT.Checked = True 'ตั้งให้ตอนเเรก ติ๊กที่เป็นสถานบำบัด
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'Dim dao_something

      
        Dim bed As Integer
        If Integer.TryParse(txt_bed.Text, bed) = True Then
            Dim bao As New BAO.GenNumber
            Dim year As String = con_year(Date.Now.Year)
            Dim pvncd As String = _CLS.PVCODE
            Dim rcvno As String = bao.GEN_RCVNO_NO(year, pvncd, "99", _IDA)
  
            Dim TREATMENT_TYPE_CD As String = String.Empty
            Dim dao As New DAO_CPN.TB_LOCATION_ADDRESS
            dao.GetDataby_IDA(_IDA)
            dao.fields.STATUS_ID = 3
            dao.fields.rcvdate = Date.Now
            dao.fields.rcvno = rcvno
            dao.update()

            Dim dao_detail As New DAO_CPN.TB_LOCATION_DETAIL
            dao_detail.fields.BED_NUM = bed
            dao_detail.fields.FK_IDA = dao.fields.IDA
            If rbn_TREATMENT.Checked = True Then
                TREATMENT_TYPE_CD = "YES"
            Else
                TREATMENT_TYPE_CD = "NO"
            End If
            dao_detail.fields.TREATMENT_TYPE_CD = TREATMENT_TYPE_CD
            dao_detail.insert()
            alert("เลขรับ คือ " & dao.fields.rcvno)
        Else
            Response.Write("<script type='text/javascript'>window.parent.alert('" + "กรุณากรอกตัวเลข" + "');</script> ")
        End If


    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Response.Redirect("POPUP_LCN_LCT_CONFIRM.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&type=" & _type)
    End Sub
End Class