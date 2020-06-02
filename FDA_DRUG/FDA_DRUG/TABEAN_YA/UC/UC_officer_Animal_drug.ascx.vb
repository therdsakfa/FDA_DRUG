Imports System.Globalization
Imports System.IO
Imports System.Xml.Serialization
Imports Telerik.Web.UI
Imports System.Xml

Public Class officer_Animal_drug
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
        'If Not IsPostBack Then
        '    show_data()

        'End If
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

            Dim dt As New DataTable

            dt.Columns.Add("amltpnm")
            dt.Columns.Add("amlsubnm")
            dt.Columns.Add("usetpnm")
            dt.Columns.Add("Newcode")
            dt.Columns.Add("IDA")

            For Each item In p2.LGT_ANIMAL_DRUGS_TO
                Dim row As DataRow
                row = dt.NewRow

                row("amltpnm") = item.XML_ANIMAL_DRUG.amltpnm            'ประเภทสัตว์
                row("amlsubnm") = item.XML_ANIMAL_DRUG.amlsubnm          ' ชนิดสัตว์
                row("usetpnm") = item.XML_ANIMAL_DRUG.usetpnm            'การใช้
                row("Newcode") = item.XML_ANIMAL_DRUG.Newcode
                row("IDA") = item.XML_ANIMAL_DRUG.IDA


                dt.Rows.Add(row)
                'lb_amltpnm.Text = item.XML_ANIMAL_DRUG.amlsubnm
                'lb_ampartnm.Text = item.XML_ANIMAL_DRUG.ampartnm              'ชนิดสัตว์
                'lb_usetpnm.Text = item.XML_ANIMAL_DRUG.usetpnm
                'lb_consumer.Text = item.XML_ANIMAL_DRUG.amltpnm
            Next

            RadGrid1.DataSource = dt
        Catch ex As Exception
            Alert("อยู่ระหว่างการโอนถ่ายรายละเอียดจากฐานข้อมูล โปรดเข้ามาทำรายการอีกครั้งหนึ่งอาจใช้เวลาประมาณ 3-5 วันทำการ")
        End Try

    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Private Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand


        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            'Dim IDA As String = item("IDA").Text
            'Dim register As String = item("register").Text

            If e.CommandName = "att" Then
                Dim index As Integer = e.Item.ItemIndex
                Dim url As String = ""
                Dim lcnno As String = item("lcnno").Text             ' เป็นการส่งค่า QueryStringจากหน้า SEARCH_CMT ให้หน้า          Product_DRUG  คือชื่อฟิลด์ในsto 
                Dim lcnsid As String = item("lcnsid").Text
                Dim thadrgnm As String = item("thadrgnm").Text
                Dim IDA As String = item("IDA").Text
                Dim rgtno As String = item("rgtno").Text
                Dim rgttpcd As String = item("rgttpcd").Text
                Dim Newcode As String = item("Newcode").Text

                Dim dsgcd As String = item("dsgcd").Text
                'url = "pop-up_drug.aspx?lcnno=" & lcnno & "&IDA=" & IDA & ""

                url = "../SEARCH_DRUG/pop-up_officer_Animal_drug.aspx?lcnno=" & lcnno & "&lcnsid=" & lcnsid & _
 "&thadrgnm=" & thadrgnm & "&IDA=" & IDA & "&rgtno=" & rgtno & "&rgttpcd=" & rgttpcd & "&Newcode=" & Newcode & " "

                'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "Popups2('" & url & "');", True)
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url & "');", True)

            End If
        End If
    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        show_data(_Newcode)
    End Sub
End Class