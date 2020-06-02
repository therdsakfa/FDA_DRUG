Imports System.Globalization
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml

Public Class UC_officer_history
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
    Sub show_data(ByVal Newcode As String)
        'Dim path As String = ""
        'path = "C:\path\XMLALL\XML\XML_DRUG_FORMULA\" & _Newcode & ".xml"

        'Dim objStreamReader As New StreamReader(path)                                    'คือการแปลง xml กลับมาเป็น class 
        'Dim p2 As New LGT_IOW_E
        'Dim x As New XmlSerializer(p2.GetType)
        'p2 = x.Deserialize(objStreamReader)
        'objStreamReader.Close()
        Try
            Dim path As String = ""
            Dim ws As New WS_DRUG.WS_DRUG
            path = ws.XML_GET_SEARCH_DRUG_DR_IOW(Newcode)
            Dim cls_x As New Cls_XML
            cls_x.ReadData(path)
            Dim xmlreader As XmlReader = New XmlNodeReader(cls_x.doc)
            Dim p2 As New LGT_IOW_E
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(xmlreader)


            Dim index As Integer = 0
            Dim dt As New DataTable

            dt.Columns.Add("typerqt")
            dt.Columns.Add("register_rcvno")
            dt.Columns.Add("rcvdate_T")
            dt.Columns.Add("appdate_T")
            dt.Columns.Add("cnsdnm")
            dt.Columns.Add("story_edit")
            dt.Columns.Add("index")


            For Each item In p2.LGT_DQR_TO
                index += 1
                Dim row As DataRow
                row = dt.NewRow

                row("index") = index
                row("typerqt") = item.XML_SEARCH_DRUG_DQR.typerqt
                row("register_rcvno") = item.XML_SEARCH_DRUG_DQR.register_rcvno
                row("rcvdate_T") = item.XML_SEARCH_DRUG_DQR.rcvdate_T
                row("appdate_T") = item.XML_SEARCH_DRUG_DQR.appdate_T
                row("cnsdnm") = item.XML_SEARCH_DRUG_DQR.cnsdnm
                row("story_edit") = item.XML_SEARCH_DRUG_DQR.story_edit

                dt.Rows.Add(row)
            Next
            RadGrid1.DataSource = dt

        Catch ex As Exception
            alert("อยู่ระหว่างการโอนถ่ายรายละเอียดจากฐานข้อมูล โปรดเข้ามาทำรายการอีกครั้งหนึ่งอาจใช้เวลาประมาณ 3-5 วันทำการ")
        End Try

    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Sub show_data_dr(ByVal Newcode As String)
        'Dim path As String = ""
        'path = "C:\path\XMLALL\XML\XML_DRUG_FORMULA\" & _Newcode & ".xml"

        'Dim objStreamReader As New StreamReader(path)                                    'คือการแปลง xml กลับมาเป็น class 
        'Dim p2 As New LGT_IOW_E
        'Dim x As New XmlSerializer(p2.GetType)
        'p2 = x.Deserialize(objStreamReader)
        'objStreamReader.Close()
        Try
            Dim path As String = ""
            Dim ws As New WS_DRUG.WS_DRUG
            path = ws.XML_GET_SEARCH_DRUG_DR_IOW(Newcode)
            Dim cls_x As New Cls_XML
            cls_x.ReadData(path)
            Dim xmlreader As XmlReader = New XmlNodeReader(cls_x.doc)
            Dim p2 As New LGT_IOW_E
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(xmlreader)


            Dim index As Integer = 0
            Dim dt As New DataTable

            dt.Columns.Add("index")
            dt.Columns.Add("typerqt")
            dt.Columns.Add("register_rcvno")
            dt.Columns.Add("rcvdate_T")
            dt.Columns.Add("appdate_th")
            dt.Columns.Add("cnsdnm")
            dt.Columns.Add("story_edit")
            index += 1
            Dim row As DataRow
            row = dt.NewRow
            row("index") = index
            row("typerqt") = p2.XML_SEARCH_DRUG_DR.typerqt
            row("register_rcvno") = p2.XML_SEARCH_DRUG_DR.register_rcvno
            row("rcvdate_T") = p2.XML_SEARCH_DRUG_DR.rcvdate_T
            row("appdate_th") = p2.XML_SEARCH_DRUG_DR.appdate_th
            row("cnsdnm") = p2.XML_SEARCH_DRUG_DR.cnsdnm
            row("story_edit") = p2.XML_SEARCH_DRUG_DR.story_edit

            dt.Rows.Add(row)
            RadGrid2.DataSource = dt

        Catch ex As Exception
            alert("อยู่ระหว่างการโอนถ่ายรายละเอียดจากฐานข้อมูล โปรดเข้ามาทำรายการอีกครั้งหนึ่งอาจใช้เวลาประมาณ 3-5 วันทำการ")
        End Try


    End Sub
End Class