Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf

Public Class CLS_MAIN_XML


    Public Function XML_DALCN(ByVal lcnsid As Integer, ByVal lcntpcd As Integer, ByVal tracns_down As String) As String
        'Dim cls_lcn As New CLASS_GEN_XML.lcn(txt_lcnsid.Text)
        Dim cls_xml As New XML_CENTER.CLASS_DALCN


        Dim cls_gen As New CLASS_GEN_XML.Center
        cls_xml.dalcns = cls_gen.AddValue(cls_xml.dalcns)
        cls_xml.dalcns.lcntpcd = lcntpcd



        'Dim dt As New DataTable
        'dt.TableName = "A"

        'dt.Columns.Add("AAA")
        'dt.Columns.Add("BBBB")

        'Dim dr As DataRow = dt.NewRow()
        'dr("AAA") = "TEST"
        'dr("BBBB") = "TEST2"

        'dt.Rows.Add(dr)

        'cls_xml.MAIN_DATA.DT1 = dt

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim filename As String = tracns_down
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        Return filename
    End Function


    Public Function XML_DALCN_EX(ByVal lcnsid As Integer, ByVal lcntpcd As Integer) As String
        'Dim cls_lcn As New CLASS_GEN_XML.lcn(txt_lcnsid.Text)
        Dim cls_xml As New XML_CENTER.CLASS_DALCN

        Dim cls_gen As New CLASS_GEN_XML.Center
        cls_xml.dalcns = cls_gen.AddValue(cls_xml.dalcns)
        cls_xml.dalcns.lcntpcd = lcntpcd


        cls_xml.darqts = cls_gen.AddValue(cls_xml.darqts)


        Dim dt As New DataTable
        dt.TableName = "A"

        dt.Columns.Add("AAA")
        dt.Columns.Add("BBBB")

        Dim dr As DataRow = dt.NewRow()
        dr("AAA") = "TEST"
        dr("BBBB") = "TEST2"

        dt.Rows.Add(dr)

        '   cls_xml.MAIN_DATA.DT1 = dt

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim filename As String = "da_lcn"
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        Return filename
    End Function

    Public Function XML_DALCN_NEW(ByVal lcnsid_customer As Integer, ByVal lcntpcd As Integer) As String
        'Dim cls_lcn As New CLASS_GEN_XML.lcn(txt_lcnsid.Text)
        Dim cls_xml As New XML_CENTER.CLASS_DALCN

        Dim cls_gen As New CLASS_GEN_XML.Center
        cls_xml.dalcns = cls_gen.AddValue(cls_xml.dalcns)
        cls_xml.dalcns.lcntpcd = lcntpcd


        cls_xml.darqts = cls_gen.AddValue(cls_xml.darqts)

      

        For i As Integer = 0 To 1
            Dim DALCN_KEP As New DALCN_KEP
            DALCN_KEP = cls_gen.AddValue(DALCN_KEP)
            cls_xml.DALCN_KEPs.Add(DALCN_KEP)
        Next
        For i As Integer = 0 To 1
            Dim DALCN_PHR As New DALCN_PHR
            DALCN_PHR = cls_gen.AddValue(DALCN_PHR)
            cls_xml.DALCN_PHRs.Add(DALCN_PHR)
        Next
        For i As Integer = 0 To 6
            Dim DALCN_WORKTIME As New DALCN_WORKTIME
            DALCN_WORKTIME = cls_gen.AddValue(DALCN_WORKTIME)
            cls_xml.DALCN_WORKTIMEs.Add(DALCN_WORKTIME)
        Next



        '_____SHOW_______________________

        Dim bao3 As New BAO.ClsDBSqlcommand
        bao3.SP_FULLADDR_LCNSNM(lcnsid_customer, 1)
        bao3.dt.TableName = "FULLADDR_LCNSNM"
        cls_xml.DT_SHOW.DT1 = bao3.dt



        Dim bao4 As New BAO_SHOW

        cls_xml.DT_SHOW.DT2 = bao4.SP_MAINPERSON_CTZNO("1729900157224")

        Dim bao5 As New BAO_SHOW

        cls_xml.DT_SHOW.DT3 = bao5.SP_MAINCOMPANY_LCNSID(909)


        'Dim dt As New DataTable
        'dt.TableName = "A"

        'dt.Columns.Add("AAA")
        'dt.Columns.Add("BBBB")

        'Dim dr As DataRow = dt.NewRow()
        'dr("AAA") = "TEST"
        'dr("BBBB") = "TEST2"

        'dt.Rows.Add(dr)

        'cls_xml.MAIN_DATA.DT1 = dt

        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()
        Dim filename As String = "da_lcn"
        Dim path As String = bao_app._PATH_XML_CLASS '"C:\path\XML_CLASS\"
        path = path & filename.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()

        Return filename
    End Function
End Class


