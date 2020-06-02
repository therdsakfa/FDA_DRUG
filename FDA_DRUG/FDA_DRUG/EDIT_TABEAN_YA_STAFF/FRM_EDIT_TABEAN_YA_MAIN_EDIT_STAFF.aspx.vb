Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_EDIT_TABEAN_YA_MAIN_EDIT_STAFF
    Inherits System.Web.UI.Page

    Private _CLS As New CLS_SESSION
    Private _PROCESS As String = ""
    Private _IDA As String = ""
    Private _fk_ida As String = ""
    Private _EDIT_TYPE As String = ""
    Private _AUTO_TYPE As String = ""
    Sub runQuery()
        _PROCESS = Request.QueryString("PROCESS")
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("fk_ida")
        _EDIT_TYPE = Request.QueryString("EDIT_TYPE")
        _AUTO_TYPE = Request.QueryString("AUTO_TYPE")
    End Sub
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        load_lcnno()
        runQuery()
        If Not IsPostBack Then
            load_GV_data()
            load_AUTO_TYPE()
            load_EDIT_TYPE()
        End If
    End Sub
    Sub load_lcnno()
        lbl_lcnno.Text = _CLS.LCNNO
    End Sub
    Private Sub load_EDIT_TYPE()
        If _EDIT_TYPE = "0" Then
            lbl_EDIT_TYPE.Text = "> ฉลาก"
        ElseIf _EDIT_TYPE = "1" Then
            lbl_EDIT_TYPE.Text = "> เอกสารกำกับยา"
        ElseIf _EDIT_TYPE = "2" Then
            lbl_EDIT_TYPE.Text = "> ขนาดบรรจุ"
        ElseIf _EDIT_TYPE = "3" Then
            lbl_EDIT_TYPE.Text = "> ชื่อยา"
        ElseIf _EDIT_TYPE = "4" Then
            lbl_EDIT_TYPE.Text = "> ลักษณะยา"
        ElseIf _EDIT_TYPE = "5" Then
            lbl_EDIT_TYPE.Text = "> สูตรยา"
        ElseIf _EDIT_TYPE = "6" Then
            lbl_EDIT_TYPE.Text = "> วิธีวิเคราะห์และข้อกำหนดมาตรฐาน"
        ElseIf _EDIT_TYPE = "7" Then
            lbl_EDIT_TYPE.Text = "> เกี่ยวกับผลิตภัณฑ์ยา"
        Else
            lbl_EDIT_TYPE.Text = " "
        End If
    End Sub
    Private Sub load_AUTO_TYPE()
        If _AUTO_TYPE = "AUTO" Then
            lbl_AUTO_TYPE.Text = "รายการขอแก้ไข 1 รายการ"
        ElseIf _AUTO_TYPE = "MANUAL" Then
            lbl_AUTO_TYPE.Text = "รายการขอแก้ไขมากกว่า 1 รายการ"
        End If
    End Sub
    Sub load_GV_data()
        Dim bao As New BAO.ClsDBSqlcommand
        'CER
        'เห็นข้อมูลทั้งหมดที่รับผิดชอบ
        bao.SP_EDIT_REQUEST_BY_STATUS(3)
        GV_data.DataSource = bao.dt
        GV_data.DataBind()
    End Sub

    Private Sub convert_Database_To_XML(ByVal filename As String, ByVal AUTO_ID As String)

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.GetDataby_IDA(_IDA)

        Dim cls_CER As New CLASS_GEN_XML.EDIT_REQUEST(_CLS.CITIZEN_ID, _CLS.LCNSID_CUSTOMER, dao.fields.lctcd, dao.fields.IDA, AUTO_ID)
        Dim cls_xml As New CLASS_EDIT_REQUEST
        cls_xml = cls_CER.gen_xml_EDIT_REQUEST()

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()


    End Sub

    Private Sub GV_data_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_data.RowCommand
        Dim int_index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim str_ID As String = GV_data.DataKeys.Item(int_index)("IDA").ToString()
        Dim dao As New DAO_DRUG.ClsDBEDIT_REQUEST

        If e.CommandName = "sel" Then
            dao.GetDataby_IDA(str_ID)
            Dim tr_id As Integer = 0
            Try
                tr_id = dao.fields.TR_ID
            Catch ex As Exception

            End Try

            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & "FRM_EDIT_TABEAN_YA_CONFIRM_EDIT_STAFF.aspx?IDA=" & str_ID & "&TR_ID=" & tr_id & "');", True)

        End If
    End Sub
    
End Class