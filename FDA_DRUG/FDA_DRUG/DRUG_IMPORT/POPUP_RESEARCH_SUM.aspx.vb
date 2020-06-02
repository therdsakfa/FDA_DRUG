Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI

Public Class POPUP_RESEARCH_SUM
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _Process As String
    Private _IDA As Integer
    Private _command As String
    Private _lcn_ida As String

    Sub runQuery()
        _Process = "10261"
        _IDA = Request("IDA").ToString()
        '_command = Request("command").ToString()
        '_lcn_ida = Request("lcn_ida").ToString()
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
        Page.MaintainScrollPositionOnPostBack = True
        runQuery()
        RunSession()
        load_data()
    End Sub

    Sub load_data()
        Dim dao As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
        dao.GetDataby_IDA(_IDA)

        If dao.fields.givedata_times = 1 Then
            Label1.Text = "นับเป็นครั้งแรกที่ให้ข้อมูลโครงการวิจัยที่ระบุ ณ วันที่" & Space(1) & dao.fields.givedata_date
        ElseIf dao.fields.givedata_times = 2 Then
            Label1.Text = "นับเป็นการปรับปรุงข้อมูลโครงการวิจัยที่ระบุ ณ วันที่" & Space(1) & dao.fields.givedata_date
        End If
        Label2.Text = dao.fields.pj_thname
        Label3.Text = dao.fields.pj_enname
        Label4.Text = dao.fields.pj_code
        If dao.fields.pj_othernmcd = 1 Then
            Label5.Text = dao.fields.pj_othernm
        ElseIf dao.fields.pj_othernmcd = 2 Then
            Label5.Text = "-"
        End If
        If dao.fields.ind_numbercd = 1 Then
            Label6.Text = dao.fields.ind_number
        ElseIf dao.fields.ind_numbercd = 2 Then
            Label6.Text = "-"
        End If
        Label7.Text = dao.fields.CTR
        If dao.fields.pj_1sttime = 1 Then
            Label8.Text = "ระยะที่: 1"
        ElseIf dao.fields.pj_1sttime = 2 Then
            Label8.Text = "ระยะที่: 2"
        ElseIf dao.fields.pj_1sttime = 3 Then
            Label8.Text = "ระยะที่: 3"
        ElseIf dao.fields.pj_1sttime = 4 Then
            Label8.Text = "ระยะที่: 4"
        ElseIf dao.fields.pj_1sttime = 5 Then
            Label8.Text = "ชีวสมมูล"
        End If
        If dao.fields.pj_typecd = 1 Then
            Label9.Text = "ทำวิจัยครั้งแรกในคน"
        End If
        If dao.fields.supporttypr = 1 Then
            Label10.Text = "โครงการวิจัยที่ริเริ่มโดยบริษัทยา " & dao.fields.company_nm
        ElseIf dao.fields.supporttypr = 2 Then
            Label10.Text = "โครงการวิจัยที่ริเริ่มโดยผู้วิจัยเอง"
        End If
        If dao.fields.country = 1 Then
            Label11.Text = "เฉพาะในประเทศไทย"
        ElseIf dao.fields.country = 2 Then
            Label11.Text = "วิจัยในหลายประเทศ"
        End If
        If dao.fields.inter_intitute = "" Then
            Label12.Text = "-"
        Else
            Label12.Text = dao.fields.inter_intitute & " แห่ง"
        End If
        If dao.fields.inter_volunteer = "" Then
            Label13.Text = "-"
        Else
            Label13.Text = dao.fields.inter_volunteer & " คน"

        End If
        If dao.fields.th_intitute = "" Then
            Label14.Text = "-"
        Else
            Label14.Text = dao.fields.th_intitute & " แห่ง"
        End If
        Label16.Text = dao.fields.th_spon_group
        Label17.Text = dao.fields.for_spon_group
        Label18.Text = dao.fields.monitor_group
        Label19.Text = dao.fields.PM_group
        Label20.Text = dao.fields.DM_group
        Label23.Text = CDate(dao.fields.pj_start_inth).ToString("MMMM yyyy")
        Label24.Text = CDate(dao.fields.pj_end_inth).ToString("MMMM yyyy")
        If dao.fields.volunteer = 1 Then
            Label25.Text = "ติดประกาศโฆษณา"
        ElseIf dao.fields.volunteer = 2 Then
            Label25.Text = "เชิญชวนด้วยวาจา"
        ElseIf dao.fields.volunteer = 3 Then
            Label25.Text = dao.fields.volunteer_descript
        End If
        If dao.fields.Financing_and_Insurance = 1 Then
            Label26.Text = "โครงร่างการวิจัย " & dao.fields.Financing_and_Insurance_Descript
        ElseIf dao.fields.Financing_and_Insurance = 2 Then
            Label26.Text = "เอกสารข้อมูลสำหรับอาสาสมัคร " & dao.fields.Financing_and_Insurance_Descript
        ElseIf dao.fields.Financing_and_Insurance = 3 Then
            Label26.Text = dao.fields.Financing_and_Insurance_Descript
        ElseIf dao.fields.Financing_and_Insurance = 4 Then
            Label26.Text = "กรณีไม่ได้ระบุไว้ในเอกสารที่คณะกรรมการพิจารณาจริยธรรมอนุมัติหรือรับรอง"
        End If

        If IsNothing(dao.fields.fk_attach) Then
        Else
            HyperLink1.Visible = True
            Dim dao_attach As New DAO_DRUG.ClsDBFILE_ATTACH
            dao_attach.GetDataby_IDA(dao.fields.fk_attach)
            HyperLink1.NavigateUrl = "~\PDF\FRM_ATTACH_PREVIEW.aspx\" & dao_attach.fields.NAME_FAKE 'ระบุ URL ของ HyperLink ในแต่ละ row โดยส่งชื่อไฟล์เพื่อเพื่อหาไฟล์PDFที่ต้องการแสดง
            HyperLink1.Text = dao_attach.fields.NAME_REAL
        End If

        Dim dao_fac As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
        dao_fac.GetDataby_PROJECT(_IDA)
        For Each dao_fac.fields In dao_fac.datas
            If Label15.Text = "" Then
                Label15.Text = dao_fac.fields.placenm
            Else
                Label15.Text = Label15.Text & " , " & dao_fac.fields.placenm
            End If
        Next

        Dim dao_lab As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
        dao_lab.GetDataby_PROJECT(_IDA)
        If dao.fields.clinical_laboratorycd = 1 Then
            Label21.Text = "ใช้ห้องปฏิบัติการคลินิกของแต่ละสถานที่วิจัย"
        ElseIf dao.fields.clinical_laboratorycd = 2 Then
            For Each dao_lab.fields In dao_lab.datas
                If Label21.Text = "" Then
                    Label21.Text = dao_lab.fields.labnm & " - " & dao_lab.fields.groupnm
                Else
                    Label21.Text = Label21.Text & " , " & dao_lab.fields.labnm & " - " & dao_lab.fields.groupnm
                End If
            Next
        End If

        Dim dao_dl As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
        dao_dl.GetDataby_PROJECT(_IDA)
        Dim n As Integer = 0
        For Each dao_dl.fields In dao_dl.datas
            n = n + 1
            If Label27.Text = "" Then
                Label27.Text = n & ".) " & dao_dl.fields.tradenm & " / " & dao_dl.fields.commonnm & " โควต้านำเข้า " & dao_dl.fields.imp_amount & Space(1) & dao_dl.fields.bunitnm
            Else
                Label27.Text = Label27.Text & " , " & n & ".) " & dao_dl.fields.tradenm & " / " & dao_dl.fields.commonnm & " โควต้านำเข้า " & dao_dl.fields.imp_amount & Space(1) & dao_dl.fields.bunitnm
            End If
        Next

    End Sub

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Response.Redirect("POPUP_NYM1.aspx?IDA=" & _IDA & "&lcn_ida=" & _lcn_ida)
    End Sub
End Class