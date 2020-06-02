Imports System.Globalization

Public Class UC_officer_refer
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
    Private _register As String
    Dim ThaiCulture As New CultureInfo("th-TH") 'วันที่แบบไทย
    Dim UsaCulture As New CultureInfo("en-US") 'วันที่แบบสากล
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub show_data(ByVal Newcode As String)

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
        dt = bao.SP_SEARCH_DRUG_REFER(_Newcode)


        For Each dr As DataRow In dt.Rows                   'ให้ dr เป็นแถวของ dt วนทีละ1 แถวของ dt ฉันจะวนในตารางนี้ทีละแถว
            lb_regis_type.Text = dr("refstnm").ToString                                'ประเภททะเบียน
            lb_askwhere.Text = dr("refer_askwhere")                               ' ขอที่
            lb_regis.Text = dr("register_refrgtno")                               'เลขทะเบียน
            lb_thadrgnm.Text = dr("refer_thadrgnm")                               ' ชื่อการค้าไทย
            lb_engdrgnm.Text = dr("refer_engdrgnm")                               'ชื่อการค้าอังกฤษ

        Next
    End Sub
End Class