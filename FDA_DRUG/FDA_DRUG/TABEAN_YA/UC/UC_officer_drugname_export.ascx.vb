Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization

Public Class officer_export
    Inherits System.Web.UI.UserControl
    Private _lcnno As String
    Private _lcntpcd As String
    Private _pvncd As String
    Private _lcnsid As String
    Private _thadrgnm As String
    Private _rgttpcd As String
    Private _rgtno As String
    Private _drgtpcd As String
    Public _Newcode As String
    Dim ThaiCulture As New CultureInfo("th-TH") 'วันที่แบบไทย
    Dim UsaCulture As New CultureInfo("en-US") 'วันที่แบบสากล
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'Sub show_data()
    '    Dim path As String = ""
    '    path = "C:\path\XMLALL\XML\XML_DRUG_PRODUCT_GROUP_TEST_T\" & _Newcode & ".xml"

    '    Dim objStreamReader As New StreamReader(path)                                    'คือการแปลง xml กลับมาเป็น class 
    '    Dim p2 As New LGT_IOW_E
    '    Dim x As New XmlSerializer(p2.GetType)
    '    p2 = x.Deserialize(objStreamReader)
    '    objStreamReader.Close()
    '    lb_drgexp.Text = p2.XML_SEARCH_DRUG_DR.drgexp                              'วันที่อนุมัติ
    '    lb_drgexp_cntcd.Text = p2.XML_SEARCH_DRUG_DR.drgexp_cntcd                     'ชื่อการค้าไทย

    'End Sub
End Class