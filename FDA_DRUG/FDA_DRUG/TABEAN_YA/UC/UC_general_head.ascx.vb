Imports System.Globalization
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml

Public Class UC_general_head
    Inherits System.Web.UI.UserControl
    Private _lcnno As String
    Private _lcntpcd As String
    Private _pvncd As String
    Private _lcnsid As String
    Private _thadrgnm As String
    Private _engdrgnm As String
    Private _rgttpcd As String
    Private _rgtno As String
    Private _drgtpcd As String
    Public _Newcode As String
    Public _register As String
    Dim ThaiCulture As New CultureInfo("th-TH") 'วันที่แบบไทย
    Dim UsaCulture As New CultureInfo("en-US") 'วันที่แบบสากล
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        show_data()
    End Sub

    Sub show_data()
        'Dim path As String = ""
        'path = "C:\path\XMLALL\XML\XML_DRUG_PRODUCT_GROUP_TEST_T\" & _Newcode & ".xml"

        'Dim objStreamReader As New StreamReader(path)                                    'คือการแปลง xml กลับมาเป็น class 
        'Dim p2 As New LGT_DRUG_PRODUCT_GROUP_TEST
        'Dim x As New XmlSerializer(p2.GetType)
        'p2 = x.Deserialize(objStreamReader)
        'objStreamReader.Close()
        'Lb_cou.Text = p2.LGT_DRUG_PRODUCT_GROUP_TEST_TO.register                               'เลขที่ใบอนุญาต
        'lb_appdate.Text = p2.LGT_DRUG_PRODUCT_GROUP_TEST_TO.thadrgnm                                    'วันที่อนุมัติ
        'lb_kind_pop.Text = p2.LGT_DRUG_PRODUCT_GROUP_TEST_TO.licen_loca                           'ชื่อการค้าไทย
        _lcnno = Request.QueryString("lcnno")
        _lcntpcd = Request.QueryString("lcntpcd")
        _pvncd = Request.QueryString("pvncd")
        _lcnsid = Request.QueryString("lcnsid")
        _thadrgnm = Request.QueryString("thadrgnm")
        _rgtno = Request.QueryString("rgtno")
        _drgtpcd = Request.QueryString("drgtpcd")
        _rgttpcd = Request.QueryString("rgttpcd")
        _Newcode = Request.QueryString("Newcode")
        _register = Request.QueryString("register")

        Dim bao As New BAO_LO.BAO_LO
        Dim dt As New DataTable
        'dt = bao.SP_SEARCH_PRO_POPUP(_lcnno, _lcnsid, _thadrgnm, _rgttpcd, _rgtno, _drgtpcd)
        dt = bao.SP_SEARCH_DRUG_PRO_PAGE(_Newcode)


        For Each dr As DataRow In dt.Rows                   'ให้ dr เป็นแถวของ dt วนทีละ1 แถวของ dt ฉันจะวนในตารางนี้ทีละแถว
            Lb_cou.Text = dr("register").ToString                                'ชื่อทางการค้าไทย
            lb_appdate.Text = dr("product_nameall")                               ' ชื่อทางการค้าอังกฤษ
            lb_kind_pop.Text = dr("licen_loca")                               'ประเภทของยา

        Next
    End Sub
   
End Class