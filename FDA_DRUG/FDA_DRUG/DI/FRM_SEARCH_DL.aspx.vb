Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_SEARCH_DL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String = ""                'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _IDA As String
    Private _process_for As String

    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()

        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            _IDA = Request.QueryString("IDA")
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            _lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2

            'load_ddl()                  พี่Xทำ ใช้อันนี้ถ้าเจ๊ง
            'load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
            load_HL()
            load_DLONLY()
        End If
        'UC_INFMT1.Shows(_lct_ida)
    End Sub
    'Private Sub load_ddl()
    '    Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
    '    dao.GetDataby_CTZNO(_CLS.CITIZEN_ID_AUTHORIZE)
    '    '    -------------------------                                      ไม่เกี่ยวทำเพิ่มเอง โดยมิน
    '    Dim item As New ListItem("---กรุณาเลือก---", "0")               ไม่เกี่ยวทำเพิ่มเอง โดยมิน
    '    Dim dao As New BAO.ClsDBSqlcommand                             ไม่เกี่ยวทำเพิ่มเอง โดยมิน
    'Dim dt As New DataTable                                        ไม่เกี่ยวทำเพิ่มเอง โดยมิน
    '      dao.SP_REGIS_NO()                                              ไม่เกี่ยวทำเพิ่มเอง โดยมิน
    '    rcb_search.DataSource = dao.datas 'dao.datas
    '    rcb_search.DataTextField = "REGIS_NO"    'น่าจะแก้ไขตรงนี้ได้
    '    rcb_search.DataValueField = "IDA"        'น่าจะแก้ไขตรงนี้ได้
    '    rcb_search.DataBind()
    '    Dim item As New RadComboBoxItem
    '    item.Text = "---กรุณาเลือก---"
    '    item.Value = "0"
    '    rcb_search.Items.Insert(0, item)
    'End Sub
    Private Sub load_DLONLY()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_DLONLY(_CLS.CITIZEN_ID_AUTHORIZE)
        '-------------------------
        ' Dim item As New ListItem("---กรุณาเลือก---", "0")
        'Dim dao As New BAO.ClsDBSqlcommand
        'Dim dt As New DataTable
        ' dao.SP_REGIS_NO()
        rcb_search.DataSource = dao.datas 'dao.datas
        rcb_search.DataTextField = "REGIS_NO"    'น่าจะแก้ไขตรงนี้ได้
        rcb_search.DataValueField = "IDA"        'น่าจะแก้ไขตรงนี้ได้
        rcb_search.DataBind()
        Dim item As New RadComboBoxItem
        item.Text = "---กรุณาเลือก---"
        item.Value = "0"
        rcb_search.Items.Insert(0, item)

    End Sub
    'Private Sub load_DLONLY()
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    bao.SP_DL_DATA_NOW_TO_START(_CLS.CITIZEN_ID_AUTHORIZE)
    '    '-------------------------
    '    ' Dim item As New ListItem("---กรุณาเลือก---", "0")
    '    'Dim dao As New BAO.ClsDBSqlcommand
    '    'Dim dt As New DataTable
    '    ' dao.SP_REGIS_NO()
    '    rcb_search.DataSource = bao.SP_DL_DATA_NOW_TO_START(_CLS.CITIZEN_ID_AUTHORIZE) 'dao.datas
    '    rcb_search.DataTextField = "REGIS_NO"    'น่าจะแก้ไขตรงนี้ได้
    '    rcb_search.DataValueField = "IDA"        'น่าจะแก้ไขตรงนี้ได้
    '    rcb_search.DataBind()
    '    Dim item As New RadComboBoxItem
    '    item.Text = "---กรุณาเลือก---"
    '    item.Value = "0"
    '    rcb_search.Items.Insert(0, item)
    'End Sub
    Private Sub load_HL()
        'hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & 0
    End Sub


    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub



#Region "GRIDVIEW"



#End Region



    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub
    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim DL As String
        DL = rcb_search.SelectedValue
        If rcb_search.SelectedValue <> "0" Then
            Dim url As String = ""
            Dim NYM As String = ""
            If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
                Select Case _process
                    Case "1027"
                        NYM = "2"
                        url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM2.aspx?DL=" & rcb_search.SelectedValue & "&IDA=" & _IDA & "&NYM=" & NYM & "&process=" & _process

                    Case "1028"
                        NYM = "3"
                        url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM3.aspx?DL=" & rcb_search.SelectedValue & "&IDA=" & _IDA & "&NYM=" & NYM & "&process=" & _process

                    Case "1029"
                        NYM = "4"
                        url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM4.aspx?DL=" & rcb_search.SelectedValue & "&IDA=" & _IDA & "&NYM=" & NYM & "&process=" & _process

                    Case "1030"
                        NYM = "5"
                        url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_NYM5.aspx?DL=" & rcb_search.SelectedValue & "&IDA=" & _IDA & "&NYM=" & NYM & "&process=" & _process

                End Select
                'url = "../D_NEW_DRUG_IMPORT/FRM_DRUG_IMPORT_MAIN.aspx?DL=" & rcb_search.SelectedValue & "&NYM=" & NYM & "&process=" & _process
                Response.Redirect(url)
            End If
        Else
            alert("กรุณาเลือกเลขบัญชีรายการยา")
        End If

    End Sub

    Protected Sub rcb_search_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles rcb_search.SelectedIndexChanged

    End Sub
    'Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
    '    If rcb_search.SelectedValue <> "0" Then
    '        Dim url As String = ""
    '        Dim NYM As String = ""
    '        If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
    '            Select Case _process
    '                Case "1027"
    '                    NYM = "2"
    '                Case "1028"
    '                    NYM = "3"
    '                Case "1029"
    '                    NYM = "4"
    '                Case "1030"
    '                    NYM = "5"
    '            End Select
    '            url = "http://164.115.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & rcb_search.SelectedValue & "&NYM=" & NYM
    '            Response.Redirect(url)
    '        End If
    '    Else
    '        alert("กรุณาเลือกเลขบัญชีรายการยา")
    '    End If

    'End Sub
End Class