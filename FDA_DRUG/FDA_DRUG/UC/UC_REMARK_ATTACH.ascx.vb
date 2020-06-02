Public Class UC_REMARK_ATTACH
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub BindUC(ByVal dr As DataRow)
        Dim ProcessID As Integer = 10261

        'Dim dao_pdftemplate As New DAO.TB_MAS_TEMPLATE_PROCESS
        'dao_pdftemplate.GetDataby_TEMPLAETE(ProcessID, 0, "2", 0, 0)

        'Dim paths As String = _PATH_FILE


        lbl_ID.Text = ID
        lbl_descript.Text = dr("DESCRIPTION")
        'Dim dao As New DAO.TB_USER_REGISTER


        ' hl_pdf.NavigateUrl = "../PDF/FRM_PDF.aspx?FileName=" & paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & dr("XML_NAME").ToString() & ".pdf"  '"~\PDF\FDA_PDF.aspx\" & dr("XML_NAME").ToString() & ".pdf"
        'hl_pdf.Attributes.Add("onclick", "Popups2('" & "FRM_ADMIN_REGISTER_INTERNET_CONFIRM.aspx?IDA=" & dr("IDA") & "&TR_ID=" & dr("TR_ID") & "');return false;")
        Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
        dao.GetDataby_IDA(dr("IDA")) 'ดึงข้อมูลโดยการ where IDA ที่ใช้เป็น DataKeys ของแต่ละ row 
        hl_pdf.NavigateUrl = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao.fields.NAME_FAKE 'ระบุ URL ของ HyperLink ในแต่ละ row โดยส่งชื่อไฟล์เพื่อเพื่อหาไฟล์PDFที่ต้องการแสดง
    End Sub

End Class