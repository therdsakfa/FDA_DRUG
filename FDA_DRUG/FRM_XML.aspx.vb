Imports System.IO
Imports System.Xml.Serialization

Public Class FRM_XML
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub convert_Database_To_XML_dalcn()
        Dim cls As New CLASS_DALCN

        Dim WS_CENTER_CLC_NAMES As New WS_CENTER.CLC_NAMES
        'Dim WS_CENTER As New WS_CENTER.WS_CENTER

        Dim WS_CENTER_systhmbl As New WS_CENTER.CLC_THMBLCD
        Dim WS_CENTER_sysamphr As New WS_CENTER.CLC_AMPHRCD
        Dim WS_CENTER_syschngwt As New WS_CENTER.CLC_CHAWTCD
        Dim WS_CENTER As New WS_CENTER.WS_CENTER
        Dim WS_LGTDRUG As New WS_LGTDRUG.WS_LGTDRUG
        ' Dim WS_LGTFOOD2 As New WS_LGTFOOD2.WS_LGTFOOD
        'ที่อยู่ติดต่อได้
        Dim WS_CENTER_SYSADDR_CONTACT As New WS_CENTER.CLC_SYSADDR_CONTACT
        WS_CENTER_SYSADDR_CONTACT = WS_CENTER.GET_ADDR_CONTACT("3709800064166") 'test
        WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.thumbolcd))
        WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd), Integer.Parse(WS_CENTER_SYSADDR_CONTACT.districtcd))
        WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(WS_CENTER_SYSADDR_CONTACT.provincecd))
        cls.name = WS_CENTER_SYSADDR_CONTACT.name
        cls.citiz_no = WS_CENTER_SYSADDR_CONTACT.citiz_no
        cls.room = WS_CENTER_SYSADDR_CONTACT.room
        cls.floor = WS_CENTER_SYSADDR_CONTACT.floor
        cls.building = WS_CENTER_SYSADDR_CONTACT.building
        cls.number_addr = WS_CENTER_SYSADDR_CONTACT.number_addr
        cls.moo = WS_CENTER_SYSADDR_CONTACT.moo
        cls.soi = WS_CENTER_SYSADDR_CONTACT.soi
        cls.road = WS_CENTER_SYSADDR_CONTACT.road
        cls.thmbolcd = WS_CENTER_systhmbl.thathmblnm
        cls.districtcd = WS_CENTER_sysamphr.thaamphrnm
        cls.provincecd = WS_CENTER_syschngwt.thachngwtnm
        cls.zipcode = WS_CENTER_SYSADDR_CONTACT.zipcode
        cls.tel_home = WS_CENTER_SYSADDR_CONTACT.tel_home
        cls.tel_telephone = WS_CENTER_SYSADDR_CONTACT.tel_telephone
        cls.email = WS_CENTER_SYSADDR_CONTACT.email
        cls.nation = WS_CENTER_SYSADDR_CONTACT.nation

        'ผปก
        Dim cls_MainCompany As New MainCompany

        'Dim dao_falcn As New DAO.clsDBfalcn
        'Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
        'Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
        'Dim dao_syslctnm As New DAO_CPN.clsDBsyslctnm
        'Dim dao_syslctaddr As New DAO_CPN.clsDBsyslctaddr
        'dao_falcn.GetDataby_lcnsid_lcnno(901, 5200077)
        'dao_syslcnsid.GetDataby_lcnsid(Integer.Parse(901))
        'dao_syslcnsnm.GetDataby_lcnsid(Integer.Parse(901))
        'dao_syslctaddr.GetDataby_lcnsid_lctcd(Integer.Parse(901), dao_falcn.fields.lctcd)
        'WS_CENTER_systhmbl = WS_CENTER.Get_Thmblcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd), Integer.Parse(dao_syslctaddr.fields.thmblcd))
        'WS_CENTER_sysamphr = WS_CENTER.Get_Amphrcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd), Integer.Parse(dao_syslctaddr.fields.amphrcd))
        'WS_CENTER_syschngwt = WS_CENTER.Get_Chngwtcd(Integer.Parse(dao_syslctaddr.fields.chngwtcd))

        'cls_MainCompany.name = dao_syslcnsnm.fields.thanm + "  " + dao_syslcnsnm.fields.thalnm
        'cls_MainCompany.citiz_no = dao_syslcnsid.fields.ctzno
        'cls_MainCompany.room = dao_syslctaddr.fields.room
        'cls_MainCompany.floor = dao_syslctaddr.fields.floor
        'cls_MainCompany.building = dao_syslctaddr.fields.building
        'cls_MainCompany.number_addr = dao_syslctaddr.fields.thaaddr
        'cls_MainCompany.moo = dao_syslctaddr.fields.mu
        'cls_MainCompany.soi = dao_syslctaddr.fields.thasoi
        'cls_MainCompany.road = dao_syslctaddr.fields.tharoad
        'cls_MainCompany.thmbolcd = WS_CENTER_systhmbl.thathmblnm
        'cls_MainCompany.districtcd = WS_CENTER_sysamphr.thaamphrnm
        'cls_MainCompany.provincecd = WS_CENTER_syschngwt.thachngwtnm
        'cls_MainCompany.zipcode = dao_syslctaddr.fields.zipcode
        'cls_MainCompany.tel_home = dao_syslctaddr.fields.tel
        'cls_MainCompany.tel_telephone = ""
        'cls_MainCompany.email = ""
        'cls_MainCompany.nation = ""

        cls_MainCompany.name = ""
        cls_MainCompany.citiz_no = ""
        cls_MainCompany.room = ""
        cls_MainCompany.floor = ""
        cls_MainCompany.building = ""
        cls_MainCompany.number_addr = ""
        cls_MainCompany.moo = ""
        cls_MainCompany.soi = ""
        cls_MainCompany.road = ""
        cls_MainCompany.thmbolcd = ""
        cls_MainCompany.districtcd = ""
        cls_MainCompany.provincecd = ""
        cls_MainCompany.zipcode = ""
        cls_MainCompany.tel_home = ""
        cls_MainCompany.tel_telephone = ""
        cls_MainCompany.email = ""
        cls_MainCompany.nation = ""
        cls.MainCompany.Add(cls_MainCompany)


        cls.dalcn.lcnno = 0
        cls.dalcn.lcnsid = 0
        cls.dalcn.amphrcd = 0
        cls.dalcn.appdate = Date.Now()
        cls.dalcn.bsnage = 0
        cls.dalcn.bsncd = 0
        cls.dalcn.bsnid = 0
        cls.dalcn.bsnlctcd = 0
        cls.dalcn.chngwtcd = 0
        cls.dalcn.cnccd = 0
        cls.dalcn.cnccscd = 0
        cls.dalcn.cncdate = Date.Now()
        cls.dalcn.expyear = 0
        cls.dalcn.fdano = 0
        cls.dalcn.frtappdate = Date.Now()
        cls.dalcn.lcnpayst = 0
        cls.dalcn.lcntpcd = 0
        cls.dalcn.lctcd = 0
        cls.dalcn.lctnmcd = 0
        cls.dalcn.lmdfdate = Date.Now()
        cls.dalcn.lstfcd = 0
        cls.dalcn.opentime = 0
        cls.dalcn.phrflg = ""
        cls.dalcn.pvnabbr = 0
        cls.dalcn.pvncd = 0
        cls.dalcn.rcptpayst = 0
        cls.dalcn.remark = 0
        cls.dalcn.Co_name = 0

        cls.sysplace.nameplace = 0
        cls.sysplace.number_addr = 0
        cls.sysplace.room = 0
        cls.sysplace.moo = 0
        cls.sysplace.floor = 0
        cls.sysplace.soi = 0
        cls.sysplace.building = 0
        cls.sysplace.road = 0
        cls.sysplace.thmblcd = 0
        cls.sysplace.amphrcd = 0
        cls.sysplace.chngwtcd = 0
        cls.sysplace.tel_home = 0
        cls.sysplace.tel_telephone = 0
        cls.sysplace.type_process = 0
        cls.sysplace.rcvno = 0

        For i As Integer = 0 To 1
            Dim cls_dacncc As New dacncc
            cls_dacncc.cnccscd = 1
            cls_dacncc.cnccsnm = 10
            cls_dacncc.cnccsst = 1
            cls.dacnccs.Add(cls_dacncc)
        Next
        For i As Integer = 0 To 1
            Dim cls_dacnc As New dacnc
            cls_dacnc.cnccd = 1
            cls_dacnc.cncnm = 111
            cls.dacnc.Add(cls_dacnc)
        Next
        For i As Integer = 0 To 1
            Dim cls_dalcntype As New dalcntype
            cls_dalcntype.grplcncd = 10
            cls_dalcntype.lcntpcd = 1
            cls_dalcntype.lcntpnm = 0
            cls_dalcntype.lcntpnmeng = 0
            cls_dalcntype.useinpvn = 0
            cls.dalcntype.Add(cls_dalcntype)
        Next
        For i As Integer = 0 To 1
            Dim cls_dalcnphr As New dalcnphr
            cls_dalcnphr.pvncd = 10
            cls_dalcnphr.lcnno = 1
            cls_dalcnphr.functcd = 0
            cls_dalcnphr.lcntpcd = 0
            cls_dalcnphr.opentime = 0
            cls_dalcnphr.orderno = 0
            cls_dalcnphr.phrcd = 0
            cls_dalcnphr.phrcncst = 0
            cls_dalcnphr.phrid = 0
            cls_dalcnphr.phrno = 0
            cls_dalcnphr.pvncd = 0

            cls.dalcnphr.Add(cls_dalcnphr)
        Next
        For i As Integer = 0 To 1
            Dim cls_dalcnkep As New dalcnkep
            cls_dalcnkep.keplctnmcd = 10
            cls_dalcnkep.lcnno = 1
            cls_dalcnkep.lcnsid = 0
            cls_dalcnkep.lcntpcd = 0
            cls_dalcnkep.lctcd = 0
            cls_dalcnkep.orderno = 0
            cls_dalcnkep.pvncd = 0

            cls.dalcnkep.Add(cls_dalcnkep)
        Next

        Dim cls_syschngwt As New WS_CENTER.syschngwt
        For Each s_cls_syschngwt In WS_CENTER.GetData_Changwat()
            cls.syschngwt.Add(s_cls_syschngwt)
            cls_syschngwt = New WS_CENTER.syschngwt
        Next
        Dim cls_sysamphr As New WS_CENTER.sysamphr
        For Each s_cls_sysamphr In WS_CENTER.GetData_Amphur()
            cls.sysamphr.Add(s_cls_sysamphr)
            cls_sysamphr = New WS_CENTER.sysamphr
        Next
        Dim cls_systhmbl As New WS_CENTER.systhmbl
        For Each s_cls_systhmbl In WS_CENTER.GetData_Thumbol()
            cls.systhmbl.Add(s_cls_systhmbl)
            cls_systhmbl = New WS_CENTER.systhmbl
        Next

        Dim cls_daphrfunctcd As New WS_LGTDRUG.daphrfunctcd
        For Each s_cls_daphrfunctcd In WS_LGTDRUG.daphrfunctcd()
            cls.daphrfunctcd.Add(s_cls_daphrfunctcd)
            cls_daphrfunctcd = New WS_LGTDRUG.daphrfunctcd
        Next

        Dim path As String = Server.MapPath("XML")
        path = path & "/" & cls.ToString() & ".xml"
        Dim objStreamWriter As New StreamWriter(path)
        Dim x As New XmlSerializer(cls.GetType)
        x.Serialize(objStreamWriter, cls)
        objStreamWriter.Close()
    End Sub
    Protected Sub btn_dalcn_Click(sender As Object, e As EventArgs) Handles btn_dalcn.Click
        convert_Database_To_XML_dalcn()
    End Sub
End Class