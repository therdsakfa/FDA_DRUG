Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf

Public Class FRM_DS_EDIT_REQUEST
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _ProcessID As String
    Private _YEARS As String
    Private _TR_ID As String
    Private _lcn_ida As String
    Private Sub RunQuery()
        '_ProcessID = 101
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th")
        End Try
        _lcn_ida = Request("lcn_ida").ToString()
        _IDA = Request.QueryString("IDA")
        _ProcessID = Request.QueryString("process")
        _TR_ID = Request.QueryString("TR_ID")
        '_YEARS = con_year(Date.Now.Year)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            UC_GRID_ATTACH.load_gv_V2(_TR_ID, _ProcessID)
            set_label()
        End If

    End Sub

    Public Sub set_label() 'ดึงข้อมูลแสดง
        Dim dao_edit As New DAO_DRUG.ClsDBDRSAMP_EDIT_REQUEST
        dao_edit.Getdataby_FK_IDA(_IDA)
        Try
            lbl_EDIT.Text = dao_edit.fields.DESCRIPTION
            lbl_DATE.Text = dao_edit.fields.CREATE_DATE
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button_DL_Click(sender As Object, e As EventArgs) Handles Button_DL.Click

        Dim dao As New DAO_DRUG.ClsDBdrsamp
        dao.GetDataby_IDA(_IDA)

        Response.Redirect("../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & dao.fields.PRODUCT_ID_IDA & "&process=" & _ProcessID)

        'Dim url As String = "../REGISTRATION/FRM_REGISTRATION_DETAIL_OTHER.aspx?IDA=" & dao.fields.PRODUCT_ID_IDA & "&process=" & _ProcessID
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)

    End Sub
End Class