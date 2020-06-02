Imports iTextSharp.text.pdf
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_LCN_UPLOAD_DRUG
    Inherits System.Web.UI.Page
    'Private _lcnsid As Integer
    'Private _thanm As String
    'Private _comno As String
    'Private _lcnsid_customer As String
    'Private _lcnno As String
    'Private _CITIEZEN_ID As String
    'Private _CITIEZEN_ID_AUTHORIZE As String
    'Private _transection As String
    'Private _pvcode As String
    Private _CLS As New CLS_SESSION
    Dim bao As New BAO.AppSettings
    Sub RunSession()
        Try
            '_CITIEZEN_ID = Session("CITIEZEN_ID").ToString()
            '_CITIEZEN_ID_AUTHORIZE = Session("CITIEZEN_ID_AUTHORIZE").ToString()

            '_lcnsid = Integer.Parse(Session("lcnsid").ToString())
            '_lcnsid_customer = Integer.Parse(Session("lcnsid_customer").ToString())
            '_thanm = Session("thanm").ToString()
            ''_lcnno = Session("lcnno").ToString()
            '' _pvcode = Session("pvcode").ToString()
            '_transection = Session("transection").ToString()

            ' _lcnno = Session("lcnno").ToString()
            bao.RunAppSettings()
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Sub load_lable_upload()
        UC_ATTACH_DRUG1.get_label("เอกสารอื่นๆ")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        chk_type()
    End Sub
    Sub chk_type()

        Panel1.Visible = True
        UC_ATTACH_DRUG1.get_label("รูปผู้ดำเนินกิจการ")

    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        If FileUpload1.HasFile Then
            insert_transection()
            'RunSession()


            FileUpload1.SaveAs(bao._PATH_PDF_TRADER & "DA-10-" & con_year(Date.Now.Year) & "-" & _CLS.TRANSECTION_UP_ID & ".pdf") '"C:\path\PDF_TRADER\"
            convert_PDF_To_XML(bao._PATH_PDF_TRADER & "DA-10-" & con_year(Date.Now.Year) & "-" & _CLS.TRANSECTION_UP_ID & ".pdf") '"C:\path\PDF_TRADER\"
            insrt_to_database(bao._PATH_XML_TRADER & "DA-10-" & con_year(Date.Now.Year) & "-" & _CLS.TRANSECTION_UP_ID & ".xml") '"C:\path\XML_TRADER\"

            UC_ATTACH_DRUG1.ATTACH(_CLS.TRANSECTION_UP_ID, "10", con_year(Date.Now.Year), "1")
            alert("รหัสการดำเนินการ คือ DA-10-" & con_year(Date.Now.Year) & "-" + _CLS.TRANSECTION_UP_ID)
        End If
    End Sub
    Sub insert_transection()

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.GetDataby_DOWNLOAD_ID() 'ปรับดึงจากxml 

        dao_up.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao_up.fields.PROCESS_ID = 41
        dao_up.fields.REF_NO = run_rcvno()
        dao_up.fields.STATUS = 1
        dao_up.fields.UPLOAD_DATE = Date.Now()
        dao_up.insert() 'ปรับเป็น update
        _CLS.TRANSECTION_UP_ID = dao_up.fields.ID.ToString()
        Session("CLS") = _CLS

    End Sub
    Private Sub convert_PDF_To_XML(ByVal FileName As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(FileName)
        Dim doc As New XmlDocument

        Dim ob As String

        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml
        doc.LoadXml(ob)
        doc.Save(bao._PATH_XML_TRADER & "DA-10-" & con_year(Date.Now.Year) & "-" + _CLS.TRANSECTION_UP_ID + ".xml") '"C:\path\XML_TRADER\"



    End Sub


    ''' <summary>
    ''' ดึงค่า PDF เข้าไปที่ XML_TRADER
    ''' </summary>
    ''' <remarks></remarks>
    Private Overloads Function convert_PDF_TRADER_To_XML_TRADER(ByVal bytepdf As Byte()) As String
        Dim ob As String
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(bytepdf)
        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml
        Return ob

    End Function


    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub insrt_to_database(ByVal FileName As String)

        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        'Dim bao As New BAO.ClsDBSqlCommand
        ' bao.FAGencomno()
        Dim dao As New DAO_DRUG.ClsDBdalcn

        'dao.fields = p2.falcn
        dao.fields.pvncd = _CLS.PVCODE
        dao.fields.lcnsid = _CLS.LCNSID_CUSTOMER
        dao.fields.lcnno = 0
        dao.fields.CTZNO = _CLS.CITIZEN_ID
        dao.fields.rcvdate = Date.Now
        dao.fields.TRANSECTION_ID_UPLOAD = _CLS.TRANSECTION_UP_ID

        dao.insert()


    End Sub
    Function run_rcvno() As Integer
        Dim regntfno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        regntfno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return regntfno
    End Function

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');self.close();</script> ")
    End Sub
End Class