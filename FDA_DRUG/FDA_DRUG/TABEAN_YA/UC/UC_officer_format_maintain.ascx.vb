Imports System.Xml.Serialization
Imports System.IO
Imports System.Globalization
Imports System.Xml

Public Class UC_officer_format_maintain
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
    'Private _dsgcd As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub show_data(ByVal Newcode As String)
        'Dim path As String = ""
        ''path = "C:\path\XMLALL\XML\XML_STOWAGR\" & _Newcode & ".xml"
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

            For Each item In p2.LGT_XML_STOWAGR_TO

                If item.XML_STOWAGR.useage = "0" Then
                    lb_Lifetime.Text = "-"
                Else
                    lb_Lifetime.Text = item.XML_STOWAGR.useage

                End If

                If item.XML_STOWAGR.tplow = "0" Then
                    lb_Month.Text = "-"
                Else
                    lb_Month.Text = item.XML_STOWAGR.tplow

                End If



                If item.XML_STOWAGR.tphigh = "0" Then
                    lb_day.Text = "-"
                Else
                    lb_day.Text = item.XML_STOWAGR.tphigh

                End If






                'lb_Month.Text = item.XML_STOWAGR.tplow
                'lb_day.Text = item.XML_STOWAGR.tphigh
                lb_Storage_conditions.Text = item.XML_STOWAGR.keepdesc
                lb_nature_medicine.Text = item.XML_STOWAGR.drgchrtha
            Next
        Catch ex As Exception
            Alert("อยู่ระหว่างการโอนถ่ายรายละเอียดจากฐานข้อมูล โปรดเข้ามาทำรายการอีกครั้งหนึ่งอาจใช้เวลาประมาณ 3-5 วันทำการ")
        End Try



    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class